Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Media
Imports System.Threading.Tasks

Public Class FormAttendanceInOut
    Public Property ParentAttendance As FormAttendance
    Private WithEvents _formConn As FormConnection
    Public Event AttendanceApproved(gateNumber As Integer, student As FormConnection.StudentRecord)

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
        HandleGateScan(student, tbStudname, TbStudId1, Type1, PictureBox1, LBInOut.Text, "IN", 1)
    End Sub

    Private Sub HandleGate2(sender As Object, student As FormConnection.StudentRecord)
        HandleGateScan(student, tbStudname, TbStudId1, Type1, PictureBox1, LBInOut.Text, "OUT", 2)
    End Sub

    Private Sub HandleGate3(sender As Object, student As FormConnection.StudentRecord)
        HandleGateScan(student, tbstudname2, tbstudId2, Type2, PictureBox2, LBOutIn.Text, "IN", 3)
    End Sub

    Private Sub HandleGate4(sender As Object, student As FormConnection.StudentRecord)
        HandleGateScan(student, tbstudname2, tbstudId2, Type2, PictureBox2, LBOutIn.Text, "OUT", 4)
    End Sub

    Private Sub HandleGateScan(student As FormConnection.StudentRecord, tbName As TextBox, tbId As TextBox,
                             tbType As TextBox, picBox As PictureBox, modeLabel As String,
                             defaultInOut As String, gateNumber As Integer)
        If Me.InvokeRequired Then
            Me.Invoke(Sub() HandleGateScan(student, tbName, tbId, tbType, picBox, modeLabel, defaultInOut, gateNumber))
            Return
        End If

        ' Cooldown check
        If lastScanTime.ContainsKey(student.RFID) AndAlso (DateTime.Now - lastScanTime(student.RFID)).TotalMilliseconds < cooldownMs Then
            Return
        End If
        lastScanTime(student.RFID) = DateTime.Now

        ' Update UI
        tbId.Text = student.StudId
        tbName.Text = student.FullName
        tbType.Text = student.Type
        If student.Picture IsNot Nothing Then
            ' Create a high-quality copy
            Dim originalBitmap = DirectCast(student.Picture, Bitmap)
            Dim highQualityBitmap = New Bitmap(originalBitmap.Width, originalBitmap.Height)

            Using g = Graphics.FromImage(highQualityBitmap)
                g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
                g.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
                g.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
                g.DrawImage(originalBitmap, 0, 0, originalBitmap.Width, originalBitmap.Height)
            End Using

            picBox.Image = highQualityBitmap
        Else
            picBox.Image = Nothing
        End If

        ' Set size mode AFTER setting the image
        picBox.SizeMode = PictureBoxSizeMode.Zoom
        'picBox.Image = If(student.Picture?.Clone(), Nothing)
        'picBox.SizeMode = PictureBoxSizeMode.StretchImage

        ' Sound feedback
        SystemSounds.Asterisk.Play()

        Dim inout As String = If(modeLabel = "IN/OUT", defaultInOut, modeLabel)

        ' Save attendance
        Task.Run(Async Function()
                     Await SaveAttendanceAsync(student.StudId, student.FullName, inout, lbRemarks2.Text, student.Type, student.ContactN, "0")
                     RaiseEvent AttendanceApproved(gateNumber, student)
                 End Function)
    End Sub

    Private Async Function SaveAttendanceAsync(studId As String, studName As String, inout As String,
                                             remarks As String, type As String, contactN As String,
                                             processed As String) As Task
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
        End Try
    End Function

    Private Sub BConnection_Click(sender As Object, e As EventArgs) Handles bConnection.Click
        If _formConn Is Nothing OrElse _formConn.IsDisposed Then
            _formConn = New FormConnection()

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
End Class