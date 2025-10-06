Imports System.Configuration
Imports System.Data.SqlClient

Public Class FormAttendance
    Private WithEvents FormInOut As FormAttendanceInOut
    Private ReadOnly conString As String = ConfigurationManager.ConnectionStrings("Swivel_TurnStile.My.MySettings.MyDataBaseConnectionString").ConnectionString

    ' Timer for bulk updates
    Private WithEvents updateTimer As New Timer()
    Private updateCounter As Integer = 0
    Private batchSize As Integer = 5 ' Update every 5 records or 5 seconds

    Private Sub FormAttendance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbSearch.Items.AddRange({"<Select>", "By Name", "By IN / OUT", "By Remarks"})
        cbSearch.SelectedIndex = 0

        cbInOut.Text = "IN"
        cbOutIn.Text = "OUT"

        LoadInOutOptions()
        LoadAllRecords()
        UpdateSearchVisibility()

        ' Initialize timer for bulk updates (every 5 seconds)
        updateTimer.Interval = 5000 ' 5 seconds
        updateTimer.Enabled = True
        updateTimer.Start()
    End Sub

    '============================ TIMER-BASED UPDATES ============================
    Private Sub UpdateTimer_Tick(sender As Object, e As EventArgs) Handles updateTimer.Tick
        ' Update either when counter reaches batch size or every 5 seconds
        If updateCounter >= batchSize Then
            LoadAllRecords()
            updateCounter = 0
        Else
            updateCounter += 1
        End If
    End Sub

    '============================ LOAD RECORDS ============================
    Public Sub LoadAllRecords()
        Using connection As New SqlConnection(conString)
            Try
                connection.Open()
                Dim query As String = "SELECT * FROM tblAttendance ORDER BY DateTime DESC"
                Using command As New SqlCommand(query, connection)
                    Using adapter As New SqlDataAdapter(command)
                        Dim dt As New DataTable()
                        adapter.Fill(dt)

                        ' Suspend layout for better performance during bulk update
                        DataGridView1.SuspendLayout()
                        DataGridView1.Rows.Clear()

                        For Each row As DataRow In dt.Rows
                            DataGridView1.Rows.Add(row.ItemArray)
                        Next

                        DataGridView1.ResumeLayout()
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show($"Error loading records: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
        DataGridView1.RowsDefaultCellStyle.BackColor = Color.FromArgb(236, 240, 241)
    End Sub

    Private Sub LoadInOutOptions()
        Using connection As New SqlConnection(conString)
            Try
                connection.Open()
                Dim query As String = "SELECT DISTINCT InOut FROM tblAttendance"
                Using command As New SqlCommand(query, connection)
                    Using reader As SqlDataReader = command.ExecuteReader()
                        cbforinandout.Items.Clear()
                        While reader.Read()
                            cbforinandout.Items.Add(reader("InOut"))
                        End While
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show($"Error loading IN/OUT options: {ex.Message}")
            End Try
        End Using
    End Sub

    Private Sub UpdateSearchVisibility()
        If cbSearch.Text = "By IN / OUT" Then
            cbforinandout.Visible = True
            tbSearch.Visible = False
        ElseIf cbSearch.Text = "By Name" OrElse cbSearch.Text = "By Remarks" Then
            tbSearch.Visible = True
            cbforinandout.Visible = False
        Else
            tbSearch.Visible = False
            cbforinandout.Visible = False
        End If
    End Sub

    '============================ START FORMINOUT ============================
    Private Sub BStart_Click(sender As Object, e As EventArgs) Handles BStart.Click
        If FormInOut Is Nothing OrElse FormInOut.IsDisposed Then
            FormInOut = New FormAttendanceInOut() With {
                .TopLevel = True,
                .ShowInTaskbar = True,
                .ParentAttendance = Me
            }

            FormInOut.LBInOut.Text = cbInOut.Text
            FormInOut.LBOutIn.Text = cbOutIn.Text
            FormInOut.Show()
            FormInOut.bConnection.PerformClick()
        Else
            If FormInOut.WindowState = FormWindowState.Minimized Then
                FormInOut.WindowState = FormWindowState.Normal
            End If
            FormInOut.BringToFront()
        End If

        Dim validOptions = {"IN", "OUT", "IN/OUT"}
        If Not validOptions.Contains(cbInOut.Text) OrElse Not validOptions.Contains(cbOutIn.Text) Then
            MsgBox("Please select IN, OUT or IN/OUT", vbExclamation)
        End If
    End Sub

    '============================ FORM CLOSING ============================
    Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
        ' Stop the timer when form is closing
        updateTimer.Stop()
        updateTimer.Dispose()

        If FormInOut IsNot Nothing Then
            FormInOut.Close()
            FormInOut.Dispose()
        End If
        MyBase.OnFormClosing(e)
    End Sub

    Sub Forinout()
        Using connection As New SqlConnection(conString)
            Try
                connection.Open()

                Dim query As String = "SELECT DISTINCT InOut FROM tblAttendance"
                Using command As New SqlCommand(query, connection)
                    Using reader As SqlDataReader = command.ExecuteReader()
                        cbforinandout.Items.Clear()
                        While reader.Read()
                            cbforinandout.Items.Add(reader.Item("InOut"))
                        End While
                    End Using
                End Using

            Catch ex As Exception
                MessageBox.Show("Error loading IN/OUT options: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub Cbforinandout_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbforinandout.SelectedIndexChanged
        SearchRecordsWithDate()
        UpdateSearchVisibility()
    End Sub

    Private Sub CbSearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSearch.SelectedIndexChanged
        UpdateSearchVisibility()
        If cbSearch.Text = "<Select>" Then
            LoadAllRecords()
        End If
    End Sub

    Private Sub TbSearch_TextChanged(sender As Object, e As EventArgs) Handles tbSearch.TextChanged
        SearchRecordsWithDate()
        UpdateSearchVisibility()
    End Sub

    Private Sub BLoad_Click(sender As Object, e As EventArgs) Handles BLoad.Click
        SearchRecordsWithDate()
    End Sub

    '============================ SEARCH WITH DATE ============================
    Private Sub SearchRecordsWithDate()
        Using connection As New SqlConnection(conString)
            Try
                connection.Open()

                ' Base query
                Dim baseQuery As String = "SELECT * FROM tblAttendance WHERE DateTime >= @startDate AND DateTime <= @endDate"
                Dim conditions As New List(Of String)

                Using command As New SqlCommand("", connection)
                    ' Add search conditions
                    Select Case cbSearch.Text
                        Case "By IN / OUT"
                            If Not String.IsNullOrWhiteSpace(cbforinandout.Text) Then
                                conditions.Add("UPPER(InOut) = @SearchTerm")
                                command.Parameters.AddWithValue("@SearchTerm", cbforinandout.Text.Trim().ToUpper())
                            End If
                        Case "By Name"
                            If Not String.IsNullOrWhiteSpace(tbSearch.Text) Then
                                conditions.Add("studname LIKE @SearchTerm")
                                command.Parameters.AddWithValue("@SearchTerm", $"%{tbSearch.Text.Trim()}%")
                            End If
                        Case "By Remarks"
                            If Not String.IsNullOrWhiteSpace(tbSearch.Text) Then
                                conditions.Add("Remarks LIKE @SearchTerm")
                                command.Parameters.AddWithValue("@SearchTerm", $"%{tbSearch.Text.Trim()}%")
                            End If
                    End Select

                    ' Combine base + dynamic conditions
                    Dim finalQuery As String = baseQuery
                    If conditions.Count > 0 Then
                        finalQuery &= " AND " & String.Join(" AND ", conditions)
                    End If

                    finalQuery &= " ORDER BY DateTime DESC"
                    command.CommandText = finalQuery

                    ' Add date parameters
                    command.Parameters.AddWithValue("@startDate", DateTimePicker1.Value.Date)
                    command.Parameters.AddWithValue("@endDate", DateTimePicker2.Value.Date.AddDays(1).AddTicks(-1))

                    ' Execute with suspended layout for better performance
                    DataGridView1.SuspendLayout()
                    DataGridView1.Rows.Clear()

                    Using reader As SqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            DataGridView1.Rows.Add(
                            reader("studId"),
                            reader("studname"),
                            reader("DateTime"),
                            reader("InOut"),
                            reader("Remarks"),
                            reader("Type"),
                            reader("ContactN"),
                            reader("Processed")
                        )
                        End While
                    End Using

                    DataGridView1.ResumeLayout()
                End Using

            Catch ex As Exception
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub MainForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit() ' Exit the application after the form has closed
    End Sub

    '============================ MANUAL UPDATE BUTTON ============================
    ' Optional: Add a button to manually trigger update if needed
    ' Private Sub BManualUpdate_Click(sender As Object, e As EventArgs) Handles BManualUpdate.Click
    '   LoadAllRecords()
    '    updateCounter = 0 ' Reset counter after manual update
    'End Sub

End Class