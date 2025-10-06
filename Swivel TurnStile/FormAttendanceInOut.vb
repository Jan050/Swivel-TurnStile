Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Media
Imports System.IO
Imports System.Threading.Tasks

Public Class FormAttendanceInOut
    Public Property ParentAttendance As FormAttendance
    Private WithEvents _formConn As FormConnection
    Public Event AttendanceApproved(gateNumber As Integer, student As FormConnection.StudentRecord)
    Private ReadOnly BUSY_FLAG_FILE As String = "database_busy.txt"

    ' Properties to track current mode
    Public Property CurrentGate1Mode As String = "IN/OUT"
    Public Property CurrentGate2Mode As String = "IN/OUT"

    Private lastScanTime As New Dictionary(Of String, DateTime)
    Private cooldownMs As Integer = 3000
    Private ReadOnly conString As String = ConfigurationManager.ConnectionStrings("Swivel_TurnStile.My.MySettings.MyDataBaseConnectionString").ConnectionString

    Public Sub New()
        InitializeComponent()
        Me.DoubleBuffered = True
        SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
    End Sub

    Private Sub FormAttendanceInOut_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Interval = 50
        Timer1.Start()
        Label1.Left = Me.ClientSize.Width
    End Sub

    ' Event handlers for each gate

    Private Sub HandleGate1(sender As Object, student As FormConnection.StudentRecord)
        ' Gate 1 - Reader 1 (IN)
        ' Only process if current mode allows IN scans
        If CurrentGate1Mode = "IN" OrElse CurrentGate1Mode = "IN/OUT" Then
            HandleGateScan(student, tbStudname, TbStudId1, Type1, PictureBox1, "IN", 1)
        Else
            ' Mode is OUT only, ignore IN scan
            Debug.WriteLine("Gate 1 IN scan ignored - current mode: " & CurrentGate1Mode)
        End If
    End Sub

    Private Sub HandleGate2(sender As Object, student As FormConnection.StudentRecord)
        ' Gate 1 - Reader 2 (OUT)
        ' Only process if current mode allows OUT scans
        If CurrentGate1Mode = "OUT" OrElse CurrentGate1Mode = "IN/OUT" Then
            HandleGateScan(student, tbStudname, TbStudId1, Type1, PictureBox1, "OUT", 2)
        Else
            ' Mode is IN only, ignore OUT scan
            Debug.WriteLine("Gate 1 OUT scan ignored - current mode: " & CurrentGate1Mode)
        End If
    End Sub

    Private Sub HandleGate3(sender As Object, student As FormConnection.StudentRecord)
        ' Gate 2 - Reader 3 (IN)
        ' Only process if current mode allows IN scans
        If CurrentGate2Mode = "IN" OrElse CurrentGate2Mode = "IN/OUT" Then
            HandleGateScan(student, tbstudname2, tbstudId2, Type2, PictureBox2, "IN", 3)
        Else
            ' Mode is OUT only, ignore IN scan
            Debug.WriteLine("Gate 2 IN scan ignored - current mode: " & CurrentGate2Mode)
        End If
    End Sub

    Private Sub HandleGate4(sender As Object, student As FormConnection.StudentRecord)
        ' Gate 2 - Reader 4 (OUT)
        ' Only process if current mode allows OUT scans
        If CurrentGate2Mode = "OUT" OrElse CurrentGate2Mode = "IN/OUT" Then
            HandleGateScan(student, tbstudname2, tbstudId2, Type2, PictureBox2, "OUT", 4)
        Else
            ' Mode is IN only, ignore OUT scan
            Debug.WriteLine("Gate 2 OUT scan ignored - current mode: " & CurrentGate2Mode)
        End If
    End Sub

    Private Sub HandleGateScan(student As FormConnection.StudentRecord, tbName As TextBox, tbId As TextBox,
                         tbType As TextBox, picBox As PictureBox, inout As String, gateNumber As Integer)
        ' ✅ SINGLE Invoke check
        If Me.InvokeRequired Then
            Me.Invoke(Sub() HandleGateScan(student, tbName, tbId, tbType, picBox, inout, gateNumber))
            Return
        End If

        ' Cooldown check
        If lastScanTime.ContainsKey(student.RFID) AndAlso (DateTime.Now - lastScanTime(student.RFID)).TotalMilliseconds < cooldownMs Then
            Return
        End If
        lastScanTime(student.RFID) = DateTime.Now

        ' ✅ INSTANT UI UPDATE
        tbId.Text = student.StudId
        tbName.Text = student.FullName
        tbType.Text = student.Type

        ' ✅ SMART IMAGE HANDLING BASED ON YOUR SIZES
        If student.Picture IsNot Nothing Then
            ' For your sizes: 320x378 and similar are PERFECT for instant display
            If student.Picture.Width <= 500 AndAlso student.Picture.Height <= 500 Then
                ' ✅ SMALL/MEDIUM IMAGES (320x378, etc.) - INSTANT DISPLAY
                picBox.Image = student.Picture
            Else
                ' ✅ LARGE IMAGES (>500x500) - INSTANT DISPLAY + BACKGROUND OPTIMIZATION
                picBox.Image = student.Picture ' Show immediately

                ' Optimize large images in background
                Task.Run(Sub() OptimizeLargeImageInBackground(student.Picture, picBox, student.RFID))
            End If
        Else
            picBox.Image = Nothing
        End If

        picBox.SizeMode = PictureBoxSizeMode.Zoom
        SystemSounds.Asterisk.Play()

        ' Save attendance in background
        Task.Run(Async Function()
                     Await SaveAttendanceAsync(student.StudId, student.FullName, inout, lbRemarks2.Text, student.Type, student.ContactN, "0", student.Program)
                     RaiseEvent AttendanceApproved(gateNumber, student)
                 End Function)
    End Sub

    ' ✅ Background optimization ONLY for truly large images
    Private Sub OptimizeLargeImageInBackground(originalImage As Image, picBox As PictureBox, rfid As String)
        Try
            ' Only optimize if image is significantly large
            If originalImage.Width <= 800 AndAlso originalImage.Height <= 800 Then
                Return ' Already reasonable size
            End If

            ' Resize to max 500px (good balance of quality/speed)
            Dim maxSize As Integer = 500
            Dim optimizedImage As Bitmap

            If originalImage.Width > originalImage.Height Then
                ' Landscape - width is larger
                optimizedImage = ResizeImage(originalImage, maxSize, CInt(originalImage.Height * maxSize / originalImage.Width))
            Else
                ' Portrait or square - height is larger
                optimizedImage = ResizeImage(originalImage, CInt(originalImage.Width * maxSize / originalImage.Height), maxSize)
            End If

            ' Update UI if still showing the same student
            Me.Invoke(Sub()
                          If picBox.Image Is originalImage Then
                              picBox.Image = optimizedImage
                              Debug.WriteLine($"Optimized large image: {originalImage.Width}x{originalImage.Height} → {optimizedImage.Width}x{optimizedImage.Height}")
                          Else
                              optimizedImage.Dispose() ' Clean up if not used
                          End If
                      End Sub)
        Catch ex As Exception
            Debug.WriteLine($"Background image optimization failed: {ex.Message}")
        End Try
    End Sub

    ' ✅ Fast image resizing
    Private Function ResizeImage(originalImage As Image, newWidth As Integer, newHeight As Integer) As Bitmap
        Dim newImage = New Bitmap(newWidth, newHeight)
        Using g = Graphics.FromImage(newImage)
            ' Use balanced quality settings
            g.InterpolationMode = Drawing2D.InterpolationMode.Bilinear ' Good balance
            g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias ' Smooth but fast
            g.DrawImage(originalImage, 0, 0, newWidth, newHeight)
        End Using
        Return newImage
    End Function

    ' Method to update modes from parent form
    Public Sub UpdateModes(gate1Mode As String, gate2Mode As String)
        CurrentGate1Mode = gate1Mode
        CurrentGate2Mode = gate2Mode

        ' Update display labels
        LBInOut.Text = gate1Mode
        LBOutIn.Text = gate2Mode

        Debug.WriteLine($"Modes updated - Gate1: {gate1Mode}, Gate2: {gate2Mode}")
    End Sub

    Private Async Function SaveAttendanceAsync(studId As String, studName As String, inout As String,
                                         remarks As String, type As String, contactN As String,
                                         processed As String, Program As String) As Task
        ' === ADD LOCKING HERE ===
        LockDatabase() ' 🔒 Lock only during the actual database save

        Try
            Using connection As New SqlConnection(conString)
                Using command As New SqlCommand("sp_attendance", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@studId", studId)
                    command.Parameters.AddWithValue("@studnam", studName)
                    command.Parameters.AddWithValue("@datetime", DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"))
                    command.Parameters.AddWithValue("@inout", inout)
                    command.Parameters.AddWithValue("@remarks", remarks)
                    command.Parameters.AddWithValue("@type", type)
                    command.Parameters.AddWithValue("@contactN", contactN)
                    command.Parameters.AddWithValue("@processed", processed)
                    command.Parameters.AddWithValue("@program", Program)

                    Await connection.OpenAsync()
                    Await command.ExecuteNonQueryAsync()
                End Using
            End Using

            If ParentAttendance IsNot Nothing Then
                ParentAttendance.Invoke(Sub()
                                            ParentAttendance.LoadAllRecords()
                                            ParentAttendance.DataGridView1.Refresh()
                                        End Sub)
            End If
        Catch ex As Exception
            Debug.WriteLine($"Attendance error: {ex.Message}")
        Finally
            ' === ADD UNLOCKING HERE ===
            UnlockDatabase() ' 🔓 Unlock immediately after database operation
        End Try
    End Function

    Private Sub BConnection_Click(sender As Object, e As EventArgs) Handles bConnection.Click
        If _formConn Is Nothing OrElse _formConn.IsDisposed Then
            _formConn = New FormConnection()

            ' Set the reference for mode checking
            _formConn.FormAttendanceInOutInstance = Me

            ' Register handlers
            AddHandler _formConn.StudentScannedGate1, AddressOf HandleGate1
            AddHandler _formConn.StudentScannedGate2, AddressOf HandleGate2
            AddHandler _formConn.StudentScannedGate3, AddressOf HandleGate3
            AddHandler _formConn.StudentScannedGate4, AddressOf HandleGate4
            AddHandler _formConn.FormClosed, AddressOf FormConnectionClosed

            _formConn.Show()
        Else
            _formConn.BringToFront()
        End If
    End Sub

    Private Sub FormConnectionClosed(sender As Object, e As FormClosedEventArgs)
        If _formConn IsNot Nothing Then
            RemoveHandler _formConn.StudentScannedGate1, AddressOf HandleGate1
            RemoveHandler _formConn.StudentScannedGate2, AddressOf HandleGate2
            RemoveHandler _formConn.StudentScannedGate3, AddressOf HandleGate3
            RemoveHandler _formConn.StudentScannedGate4, AddressOf HandleGate4
            RemoveHandler _formConn.FormClosed, AddressOf FormConnectionClosed
            _formConn = Nothing
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim timeNow = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")
        lbDateTime1.Text = timeNow
        lbDataTime.Text = timeNow
        Label1.Left += If(Label1.Left < -Label1.Width, Me.Width, -10)
    End Sub

    Private Sub BRemarks_Click(sender As Object, e As EventArgs) Handles bRemarks.Click
        Using remarksForm As New FormRemarks
            If remarksForm.ShowDialog() = DialogResult.OK Then
                lbRemarks.Text = remarksForm.RemarksText
                lbRemarks2.Text = remarksForm.RemarksText
            End If
        End Using
    End Sub

    Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
        FormConnectionClosed(Nothing, Nothing)
        MyBase.OnFormClosing(e)
    End Sub

    ' Database locking methods for SMS app coordination
    Private Sub LockDatabase()
        Try
            File.WriteAllText(BUSY_FLAG_FILE, DateTime.Now.ToString("HH:mm:ss"))
        Catch
            ' Ignore errors - don't stop the application if file operations fail
        End Try
    End Sub

    Private Sub UnlockDatabase()
        Try
            If File.Exists(BUSY_FLAG_FILE) Then
                File.Delete(BUSY_FLAG_FILE)
            End If
        Catch
            ' Ignore errors
        End Try
    End Sub

End Class