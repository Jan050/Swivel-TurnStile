Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO
Imports System.IO.Ports
Imports System.Text
Imports System.Threading.Tasks
Imports System.Collections.Concurrent

Public Class FormAttendance
    Private WithEvents FormInOut As FormAttendanceInOut
    Private ReadOnly conString As String = ConfigurationManager.ConnectionStrings("Swivel_TurnStile.My.MySettings.MyDataBaseConnectionString").ConnectionString

    ' Timer for bulk updates
    Private WithEvents attendanceUpdateTimer As New Timer()
    Private updateCounter As Integer = 0
    Private batchSize As Integer = 5 ' Update every 5 records or 5 seconds

    ' ===== ENHANCED FILTERING VARIABLES =====
    Private currentFilters As New Dictionary(Of String, String)()
    Private filterTimer As New Timer()
    Private Const FILTER_DELAY As Integer = 500 ' Delay after typing before filtering

    ' ===== SMS FUNCTIONALITY VARIABLES =====
    Private inTemplate As String = ""
    Private outTemplate As String = ""
    Private sentMessagesFile As String = "sent_messages.txt"
    Private lastLogMessage As String = ""
    Private checkInterval As Integer = 10000 ' Increased to 10 seconds
    Private isAutoChecking As Boolean = True
    Private logFile As String = "activity_log.txt"
    Private Const ARDUINO_RESPONSE_TIMEOUT As Integer = 5000 ' 5 seconds
    Private Const ARDUINO_BAUD_RATE As Integer = 9600
    Private processingRecords As New ConcurrentDictionary(Of String, Boolean) ' Thread-safe collection

    Private isProcessing As Boolean = False

    ' Add connection timeout and retry settings
    Private ReadOnly DB_TIMEOUT As Integer = 30 ' seconds
    Private ReadOnly MAX_RETRIES As Integer = 3
    Private lastSelectedRow As Integer = -1

    Private Sub FormAttendance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize attendance components
        cbSearch.Items.AddRange({"<Select>", "By Name", "By IN / OUT", "By Remarks", "By Program", "Advanced Filter"})
        cbSearch.SelectedIndex = 0

        ' ===== INITIALIZE ENHANCED PROGRAM FILTERS =====      
        LoadProgramsFromDatabase()

        ' Initialize with default values
        cbInOut.Items.AddRange({"IN", "OUT", "IN/OUT"})
        cbOutIn.Items.AddRange({"IN", "OUT", "IN/OUT"})
        cbInOut.SelectedIndex = 0 ' IN
        cbOutIn.SelectedIndex = 1 ' OUT

        ' Initialize filter timer
        filterTimer.Interval = FILTER_DELAY
        filterTimer.Enabled = False
        AddHandler filterTimer.Tick, AddressOf FilterTimer_Tick

        LoadAllRecordsInternal()
        LoadAllRecords()
        UpdateSearchVisibility()

        ' Initialize timer for bulk updates (every 5 seconds)
        attendanceUpdateTimer.Interval = 5000 ' 5 seconds
        attendanceUpdateTimer.Enabled = True
        attendanceUpdateTimer.Start()

        ' ===== INITIALIZE SMS COMPONENTS =====
        InitializeSmsComponents()
    End Sub

    ' ===== SMS INITIALIZATION =====
    Private Sub InitializeSmsComponents()
        ' Load SMS templates and settings
        LoadTemplates()
        InitializeSentMessagesGrid()
        LoadSentMessages()
        RefreshPorts()

        ' Load SMS configuration
        LoadConfiguration()

        ' Set up SMS timer with longer interval
        TimerSMS.Interval = checkInterval
        TimerSMS.Enabled = isAutoChecking

        UpdateSmsStatus("SMS system initialized. Waiting for records...")
    End Sub

    ' ===== ATTENDANCE METHODS (EXISTING) =====
    '============================ TIMER-BASED UPDATES ============================
    Private Sub AttendanceUpdateTimer_Tick(sender As Object, e As EventArgs) Handles attendanceUpdateTimer.Tick
        ' Update either when counter reaches batch size or every 5 seconds
        If updateCounter >= batchSize Then
            ' Use Task.Run to avoid blocking UI thread
            Task.Run(Sub() LoadAllRecords())
            updateCounter = 0
        Else
            updateCounter += 1
        End If
    End Sub

    '============================ LOAD RECORDS ============================
    Public Sub LoadAllRecords()
        Task.Run(Sub() LoadAllRecordsInternal())
    End Sub

    Private Sub LoadAllRecordsInternal()
        Using connection As New SqlConnection(conString)
            Try
                ' Set longer timeout for connection
                connection.Open()

                Dim query As String = "SELECT * FROM tblAttendance ORDER BY DateTime DESC"
                Using command As New SqlCommand(query, connection)
                    command.CommandTimeout = DB_TIMEOUT ' Set command timeout

                    Using adapter As New SqlDataAdapter(command)
                        Dim dt As New DataTable()
                        adapter.Fill(dt)

                        ' Suspend layout for better performance during bulk update
                        If DataGridView1.InvokeRequired Then
                            DataGridView1.Invoke(Sub()
                                                     DataGridView1.SuspendLayout()
                                                     DataGridView1.Rows.Clear()

                                                     For Each row As DataRow In dt.Rows
                                                         DataGridView1.Rows.Add(row.ItemArray)
                                                     Next

                                                     DataGridView1.ResumeLayout()
                                                 End Sub)
                        Else
                            DataGridView1.SuspendLayout()
                            DataGridView1.Rows.Clear()

                            For Each row As DataRow In dt.Rows
                                DataGridView1.Rows.Add(row.ItemArray)
                            Next

                            DataGridView1.ResumeLayout()
                        End If
                    End Using
                End Using
            Catch ex As SqlException
                ' Don't show message box for timeout - just log it
                If ex.Number = -2 Then ' Timeout error
                    Debug.WriteLine("Database timeout in LoadAllRecords - this is normal during heavy SMS processing")
                Else
                    MessageBox.Show($"Error loading records: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MessageBox.Show($"Error loading records: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using

        If DataGridView1.InvokeRequired Then
            DataGridView1.Invoke(Sub() DataGridView1.RowsDefaultCellStyle.BackColor = Color.FromArgb(236, 240, 241))
        Else
            DataGridView1.RowsDefaultCellStyle.BackColor = Color.FromArgb(236, 240, 241)
        End If
    End Sub

    ' ===== ENHANCED FILTERING METHODS =====
    Private Sub UpdateSearchVisibility()
        ' Clear previous visibility
        tbSearch.Visible = False
        cbforinandout.Visible = False
        cbProgramFilter.Visible = False
        btnClearFilters.Visible = False
        lblAdvancedFilter.Visible = False

        Select Case cbSearch.Text
            Case "By IN / OUT"
                cbforinandout.Visible = True
                btnClearFilters.Visible = True

            Case "By Name", "By Remarks"
                tbSearch.Visible = True
                btnClearFilters.Visible = True

            Case "By Program"
                cbProgramFilter.Visible = True
                btnClearFilters.Visible = True

            Case "Advanced Filter"
                ' Show all filter controls for advanced filtering
                tbSearch.Visible = True
                cbforinandout.Visible = True
                cbProgramFilter.Visible = True
                btnClearFilters.Visible = True
                lblAdvancedFilter.Visible = True
                lblAdvancedFilter.Text = "Advanced Filter: Combine multiple criteria"

            Case Else
                ' <Select> - show clear filters button if any filters are active
                btnClearFilters.Visible = currentFilters.Count > 0
        End Select

        ' Update clear filters button text
        If btnClearFilters.Visible Then
            btnClearFilters.Text = $"Clear Filters ({currentFilters.Count} active)"
        End If
    End Sub

    '============================ Load Programs ============================

    ' ===== ENHANCED PROGRAM FILTERING =====
    Private Sub LoadProgramsFromDatabase()
        Task.Run(Sub()
                     Using connection As New SqlConnection(conString)
                         Try
                             connection.Open()

                             ' Get distinct program names from multiple sources for better coverage
                             Dim queries As New List(Of String) From {
                                 "SELECT DISTINCT Program FROM tblAttendance WHERE Program IS NOT NULL AND Program <> ''",
                                 "SELECT DISTINCT Program FROM tblcombine WHERE Program IS NOT NULL AND Program <> ''",
                                 "SELECT DISTINCT Type FROM tblAttendance WHERE Type IS NOT NULL AND Type <> ''"
                             }

                             Dim allPrograms As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
                             allPrograms.Add("<All Programs>")

                             For Each query In queries
                                 Using command As New SqlCommand(query, connection)
                                     Using reader As SqlDataReader = command.ExecuteReader()
                                         While reader.Read()
                                             Dim programName As String = reader(0).ToString().Trim()
                                             If Not String.IsNullOrWhiteSpace(programName) Then
                                                 allPrograms.Add(programName)
                                             End If
                                         End While
                                     End Using
                                 End Using
                             Next

                             ' Update combobox on UI thread
                             If cbProgramFilter.InvokeRequired Then
                                 cbProgramFilter.Invoke(Sub()
                                                            cbProgramFilter.Items.Clear()
                                                            cbProgramFilter.Items.AddRange(allPrograms.OrderBy(Function(p) p).ToArray())
                                                            If cbProgramFilter.Items.Count > 0 Then
                                                                cbProgramFilter.SelectedIndex = 0
                                                            End If
                                                        End Sub)
                             Else
                                 cbProgramFilter.Items.Clear()
                                 cbProgramFilter.Items.AddRange(allPrograms.OrderBy(Function(p) p).ToArray())
                                 If cbProgramFilter.Items.Count > 0 Then
                                     cbProgramFilter.SelectedIndex = 0
                                 End If
                             End If

                         Catch ex As Exception
                             Debug.WriteLine($"Error loading programs: {ex.Message}")
                         End Try
                     End Using
                 End Sub)
    End Sub



    '============================ START FORMINOUT ============================
    Private Sub BStart_Click(sender As Object, e As EventArgs) Handles BStart.Click
        If FormInOut Is Nothing OrElse FormInOut.IsDisposed Then
            FormInOut = New FormAttendanceInOut() With {
                .TopLevel = True,
                .ShowInTaskbar = True,
                .ParentAttendance = Me
            }

            ' Set the modes based on combobox selections
            FormInOut.UpdateModes(cbInOut.Text, cbOutIn.Text)
            FormInOut.Show()
            FormInOut.bConnection.PerformClick()
        Else
            ' Update modes in case they changed
            FormInOut.UpdateModes(cbInOut.Text, cbOutIn.Text)

            If FormInOut.WindowState = FormWindowState.Minimized Then
                FormInOut.WindowState = FormWindowState.Normal
            End If
            FormInOut.BringToFront()
        End If
    End Sub

    ' Update modes when comboboxes change (if FormInOut is already open)
    Private Sub cbInOut_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbInOut.SelectedIndexChanged
        If FormInOut IsNot Nothing AndAlso Not FormInOut.IsDisposed Then
            FormInOut.UpdateModes(cbInOut.Text, cbOutIn.Text)
        End If
    End Sub

    Private Sub cbOutIn_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbOutIn.SelectedIndexChanged
        If FormInOut IsNot Nothing AndAlso Not FormInOut.IsDisposed Then
            FormInOut.UpdateModes(cbInOut.Text, cbOutIn.Text)
        End If
    End Sub

    '============================ FORM CLOSING ============================
    Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
        ' Stop the timer when form is closing
        attendanceUpdateTimer.Stop()
        attendanceUpdateTimer.Dispose()

        ' Close SMS serial port
        If SerialPort1.IsOpen Then
            SerialPort1.Close()
        End If

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
        If cbSearch.Text = "Advanced Filter" OrElse cbSearch.Text = "By IN / OUT" Then
            StartFilterTimer()
        End If
    End Sub

    Private Sub BtnClearFilters_Click(sender As Object, e As EventArgs) Handles btnClearFilters.Click
        ClearAllFilters()
    End Sub

    Private Sub ClearAllFilters()
        tbSearch.Text = ""
        cbforinandout.SelectedIndex = -1
        cbProgramFilter.SelectedIndex = 0
        currentFilters.Clear()
        cbSearch.SelectedIndex = 0 ' Reset to <Select>
        LoadAllRecords()
        UpdateSearchVisibility()
    End Sub

    ' ===== ENHANCED SEARCH METHODS =====
    Private Sub CbSearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSearch.SelectedIndexChanged
        UpdateSearchVisibility()

        If cbSearch.Text = "<Select>" Then
            currentFilters.Clear()
            LoadAllRecords()
        Else
            ' Auto-apply filter if switching to a filter type with existing values
            If (cbSearch.Text = "By IN / OUT" AndAlso Not String.IsNullOrEmpty(cbforinandout.Text)) OrElse
               (cbSearch.Text = "By Program" AndAlso cbProgramFilter.SelectedIndex > 0) OrElse
               (cbSearch.Text = "By Name" AndAlso Not String.IsNullOrEmpty(tbSearch.Text)) OrElse
               (cbSearch.Text = "By Remarks" AndAlso Not String.IsNullOrEmpty(tbSearch.Text)) Then
                StartFilterTimer()
            End If
        End If
    End Sub

    Private Sub TbSearch_TextChanged(sender As Object, e As EventArgs) Handles tbSearch.TextChanged
        If cbSearch.Text = "Advanced Filter" OrElse cbSearch.Text = "By Name" OrElse cbSearch.Text = "By Remarks" Then
            StartFilterTimer()
        End If
    End Sub

    Private Sub cbProgramFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbProgramFilter.SelectedIndexChanged
        If cbSearch.Text = "Advanced Filter" OrElse cbSearch.Text = "By Program" Then
            StartFilterTimer()
        End If
    End Sub

    Private Sub BLoad_Click(sender As Object, e As EventArgs) Handles BLoad.Click
        SearchRecordsWithDate()
    End Sub

    '============================ SEARCH WITH DATE ============================
    Private Sub SearchRecordsWithDate()
        Task.Run(Sub() SearchRecordsWithDateInternal())
    End Sub

    Private Sub SearchRecordsWithDateInternal()
        Using connection As New SqlConnection(conString)
            Try
                connection.Open()

                Dim baseQuery As String = "SELECT * FROM tblAttendance WHERE DateTime >= @startDate AND DateTime <= @endDate"
                Dim conditions As New List(Of String)
                currentFilters.Clear()

                Using command As New SqlCommand("", connection)
                    command.CommandTimeout = DB_TIMEOUT

                    ' Build conditions based on current search mode
                    Select Case cbSearch.Text
                        Case "By IN / OUT"
                            If Not String.IsNullOrWhiteSpace(cbforinandout.Text) Then
                                conditions.Add("UPPER(InOut) = @InOut")
                                command.Parameters.AddWithValue("@InOut", cbforinandout.Text.Trim().ToUpper())
                                currentFilters.Add("IN/OUT", cbforinandout.Text)
                            End If

                        Case "By Name"
                            If Not String.IsNullOrWhiteSpace(tbSearch.Text) Then
                                conditions.Add("studname LIKE @Name")
                                command.Parameters.AddWithValue("@Name", $"%{tbSearch.Text.Trim()}%")
                                currentFilters.Add("Name", tbSearch.Text)
                            End If

                        Case "By Remarks"
                            If Not String.IsNullOrWhiteSpace(tbSearch.Text) Then
                                conditions.Add("Remarks LIKE @Remarks")
                                command.Parameters.AddWithValue("@Remarks", $"%{tbSearch.Text.Trim()}%")
                                currentFilters.Add("Remarks", tbSearch.Text)
                            End If

                        Case "By Program"
                            If cbProgramFilter.SelectedIndex > 0 Then
                                conditions.Add("Program = @Program")
                                command.Parameters.AddWithValue("@Program", cbProgramFilter.Text)
                                currentFilters.Add("Program", cbProgramFilter.Text)
                            End If

                        Case "Advanced Filter"
                            ' Combine multiple criteria
                            If Not String.IsNullOrWhiteSpace(tbSearch.Text) Then
                                conditions.Add("(studname LIKE @SearchText OR Remarks LIKE @SearchText)")
                                command.Parameters.AddWithValue("@SearchText", $"%{tbSearch.Text.Trim()}%")
                                currentFilters.Add("Search Text", tbSearch.Text)
                            End If

                            If Not String.IsNullOrWhiteSpace(cbforinandout.Text) Then
                                conditions.Add("UPPER(InOut) = @InOut")
                                command.Parameters.AddWithValue("@InOut", cbforinandout.Text.Trim().ToUpper())
                                currentFilters.Add("IN/OUT", cbforinandout.Text)
                            End If

                            If cbProgramFilter.SelectedIndex > 0 Then
                                conditions.Add("Program = @Program")
                                command.Parameters.AddWithValue("@Program", cbProgramFilter.Text)
                                currentFilters.Add("Program", cbProgramFilter.Text)
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

                    ' Update UI to show active filters
                    UpdateFilterDisplay()

                    ' Execute with suspended layout for better performance
                    If DataGridView1.InvokeRequired Then
                        DataGridView1.Invoke(Sub()
                                                 DataGridView1.SuspendLayout()
                                                 DataGridView1.Rows.Clear()
                                             End Sub)
                    Else
                        DataGridView1.SuspendLayout()
                        DataGridView1.Rows.Clear()
                    End If

                    Using reader As SqlDataReader = command.ExecuteReader()
                        Dim recordCount As Integer = 0
                        While reader.Read()
                            recordCount += 1
                            If DataGridView1.InvokeRequired Then
                                DataGridView1.Invoke(Sub()
                                                         DataGridView1.Rows.Add(
                                                     reader("studId"),
                                                     reader("studname"),
                                                     reader("DateTime"),
                                                     reader("InOut"),
                                                     reader("Remarks"),
                                                     reader("Type"),
                                                     reader("ContactN"),
                                                     reader("Processed"),
                                                     reader("Program"))
                                                     End Sub)
                            Else
                                DataGridView1.Rows.Add(
                                reader("studId"),
                                reader("studname"),
                                reader("DateTime"),
                                reader("InOut"),
                                reader("Remarks"),
                                reader("Type"),
                                reader("ContactN"),
                                reader("Processed"),
                                reader("Program"))
                            End If
                        End While

                        ' Update status with record count
                        UpdateSearchStatus(recordCount)
                    End Using

                    If DataGridView1.InvokeRequired Then
                        DataGridView1.Invoke(Sub() DataGridView1.ResumeLayout())
                    Else
                        DataGridView1.ResumeLayout()
                    End If
                End Using

            Catch ex As Exception
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub MainForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit() ' Exit the application after the form has closed
    End Sub

    ' ===== SMS METHODS (FROM FORM1) =====
    Private Sub RefreshPorts()
        cmbSmsPorts.Items.Clear()
        For Each port As String In SerialPort.GetPortNames()
            cmbSmsPorts.Items.Add(port)
        Next
        If cmbSmsPorts.Items.Count > 0 Then
            cmbSmsPorts.SelectedIndex = 0
        End If
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefreshPorts.Click
        RefreshPorts()
    End Sub

    Private Sub BtnConnect_Click(sender As Object, e As EventArgs) Handles btnSmsConnect.Click
        If btnSmsConnect.Text = "Connect" Then
            If cmbSmsPorts.SelectedItem IsNot Nothing Then
                Try
                    If SerialPort1.IsOpen Then
                        SerialPort1.Close()
                    End If

                    SerialPort1.PortName = cmbSmsPorts.SelectedItem.ToString()
                    SerialPort1.BaudRate = ARDUINO_BAUD_RATE
                    SerialPort1.Parity = Parity.None
                    SerialPort1.StopBits = StopBits.One
                    SerialPort1.DataBits = 8
                    SerialPort1.Handshake = Handshake.None
                    SerialPort1.NewLine = vbLf ' Standardize line ending
                    SerialPort1.ReadTimeout = ARDUINO_RESPONSE_TIMEOUT
                    SerialPort1.WriteTimeout = ARDUINO_RESPONSE_TIMEOUT
                    SerialPort1.Open()
                    btnSmsConnect.Text = "Disconnect"
                    lblSmsStatus.Text = "Connected"
                    btnSendSms.Enabled = True
                Catch ex As UnauthorizedAccessException
                    MessageBox.Show("Access denied to COM port. Possible causes:" & vbCrLf & vbCrLf &
                                "1. Port is already in use by another application" & vbCrLf &
                                "2. Arduino IDE serial monitor is open" & vbCrLf &
                                "3. Insufficient permissions" & vbCrLf & vbCrLf &
                                "Please close other applications and try again.",
                                "Port Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Catch ex As Exception
                    MessageBox.Show("Error connecting: " & ex.Message,
                              "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        Else
            Try
                SerialPort1.Close()
                btnSmsConnect.Text = "Connect"
                lblSmsStatus.Text = "Disconnected"
                btnSendSms.Enabled = False
            Catch ex As Exception
                MessageBox.Show("Error disconnecting: " & ex.Message)
            End Try
        End If
    End Sub

    Private Async Sub BtnSend_Click(sender As Object, e As EventArgs) Handles btnSendSms.Click
        If txtSmsPhone.Text = "" Then
            MessageBox.Show("Please enter a phone number")
            Return
        End If

        If txtSmsMessage.Text = "" Then
            MessageBox.Show("Please enter a message")
            Return
        End If

        Try
            Dim success As Boolean = Await SendCompleteMessageAsync(txtSmsPhone.Text, txtSmsMessage.Text)
            If success Then
                MessageBox.Show("SMS sent to Arduino for processing")
            Else
                MessageBox.Show("Failed to send SMS")
            End If
        Catch ex As Exception
            MessageBox.Show("Error sending SMS: " & ex.Message)
        End Try
    End Sub

    Private Async Sub BtnCheckNewRecords_Click(sender As Object, e As EventArgs) Handles btnCheckNewRecords.Click
        btnCheckNewRecords.Enabled = False
        btnCheckNewRecords.Text = "Checking..."

        Await CheckAndProcessNewRecordsAsync()

        btnCheckNewRecords.Enabled = True
        btnCheckNewRecords.Text = "Check New Records"
    End Sub

    Private Sub BtnSaveConfig_Click(sender As Object, e As EventArgs) Handles btnSaveConfig.Click
        checkInterval = CInt(numCheckInterval.Value)
        isAutoChecking = chkAutoCheckEnabled.Checked
        TimerSMS.Interval = checkInterval
        TimerSMS.Enabled = isAutoChecking
        SaveConfiguration()
        UpdateSmsStatus($"Configuration saved. Auto-check: {isAutoChecking}, Interval: {checkInterval}ms")
    End Sub

    Private Sub BtnViewLog_Click(sender As Object, e As EventArgs) Handles btnViewLog2.Click
        Try
            If File.Exists(logFile) Then
                Process.Start("notepad.exe", logFile)
            Else
                MessageBox.Show("No log file exists yet.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Error opening log file: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadConfiguration()
        Try
            If File.Exists("config.txt") Then
                Dim lines = File.ReadAllLines("config.txt")
                For Each line In lines
                    Dim parts = line.Split("="c)
                    If parts.Length = 2 Then
                        Select Case parts(0).Trim()
                            Case "CheckInterval"
                                Integer.TryParse(parts(1).Trim(), checkInterval)
                            Case "AutoCheckEnabled"
                                Boolean.TryParse(parts(1).Trim(), isAutoChecking)
                        End Select
                    End If
                Next
            End If
        Catch ex As Exception
            LogActivity("Error loading configuration: " & ex.Message)
        End Try
    End Sub

    Private Sub UpdateSmsStatus(message As String)
        If InvokeRequired Then
            Invoke(Sub() UpdateSmsStatus(message))
            Return
        End If

        lastLogMessage = $"{DateTime.Now:HH:mm:ss} - {message}"
        lblSmsStatus.Text = lastLogMessage
        ' Add to log file for debugging
        Try
            File.AppendAllText("status_log.txt", $"{lastLogMessage}{vbCrLf}")
        Catch
            ' Ignore log errors
        End Try
    End Sub

    Private Sub LogActivity(message As String)
        Try
            File.AppendAllText(logFile, $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}{vbCrLf}")
        Catch ex As Exception
            ' Silently fail if logging fails
        End Try
    End Sub

    Private Sub SaveConfiguration()
        Try
            Dim configLines As New List(Of String)
            configLines.Add($"CheckInterval={checkInterval}")
            configLines.Add($"AutoCheckEnabled={isAutoChecking}")
            File.WriteAllLines("config.txt", configLines)
        Catch ex As Exception
            LogActivity("Error saving configuration: " & ex.Message)
        End Try
    End Sub

    Private Sub BtnSaveTemplates_Click(sender As Object, e As EventArgs) Handles btnSaveTemplates.Click
        SaveTemplates()
    End Sub

    Private Sub SaveTemplates()
        Try
            inTemplate = txtInTemplate.Text
            outTemplate = txtOutTemplate.Text

            My.Computer.FileSystem.WriteAllText("in_template.txt", inTemplate, False)
            My.Computer.FileSystem.WriteAllText("out_template.txt", outTemplate, False)

            MessageBox.Show("Templates saved successfully")
        Catch ex As Exception
            MessageBox.Show("Error saving templates: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadTemplates()
        Try
            If File.Exists("in_template.txt") Then
                inTemplate = My.Computer.FileSystem.ReadAllText("in_template.txt")
                txtInTemplate.Text = inTemplate
            End If

            If File.Exists("out_template.txt") Then
                outTemplate = My.Computer.FileSystem.ReadAllText("out_template.txt")
                txtOutTemplate.Text = outTemplate
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading templates: " & ex.Message)
        End Try
    End Sub

    Private Sub LogSentMessage(phoneNumber As String, message As String, sentBy As String)
        Dim logEntry As String = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}|{phoneNumber}|{sentBy}|{message}{vbCrLf}"

        ' Append to file
        File.AppendAllText(sentMessagesFile, logEntry)

        ' Add to DataGridView
        dgvSentMessages.Rows.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), phoneNumber, sentBy, message)
    End Sub

    Private Sub LoadSentMessages()
        If File.Exists(sentMessagesFile) Then
            Dim lines As String() = File.ReadAllLines(sentMessagesFile)
            For Each line As String In lines
                Dim parts As String() = line.Split("|"c)
                If parts.Length >= 4 Then
                    dgvSentMessages.Rows.Add(parts(0), parts(1), parts(2), parts(3))
                End If
            Next
        End If
    End Sub

    Private Sub InitializeSentMessagesGrid()
        dgvSentMessages.Columns.Clear()
        dgvSentMessages.Columns.Add("colTime", "Time")
        dgvSentMessages.Columns.Add("colPhone", "Phone Number")
        dgvSentMessages.Columns.Add("colSentBy", "Sent By")
        dgvSentMessages.Columns.Add("colMessage", "Message")

        ' Optional: Set column widths
        dgvSentMessages.Columns("colTime").Width = 120
        dgvSentMessages.Columns("colPhone").Width = 100
        dgvSentMessages.Columns("colSentBy").Width = 80
        dgvSentMessages.Columns("colMessage").Width = 300
    End Sub

    Private Async Sub TimerSMS_Tick(sender As Object, e As EventArgs) Handles TimerSMS.Tick
        If Not isAutoChecking OrElse isProcessing Then Exit Sub

        isProcessing = True
        TimerSMS.Stop() ' Stop timer during processing

        Try
            ' Run SMS processing on background thread
            Await CheckAndProcessNewRecordsAsync()
        Catch ex As Exception
            UpdateSmsStatus($"Processing error: {ex.Message}")
        Finally
            isProcessing = False
            If isAutoChecking Then
                TimerSMS.Start() ' Restart timer only if auto-checking is still enabled
            End If
        End Try
    End Sub

    Private Async Function CheckAndProcessNewRecordsAsync() As Task
        For retry = 1 To MAX_RETRIES
            Try
                ' Use a transaction to ensure data consistency
                Using conn As New SqlConnection(conString)
                    Await conn.OpenAsync()
                    conn.StatisticsEnabled = True ' Enable statistics to monitor

                    ' Get only unprocessed records - LIMIT to 3 records at a time
                    Dim sql = "SELECT TOP 3 studId, studname, DateTime, InOut, remarks, contactN, Program " &
                     "FROM tblAttendance WITH (NOLOCK) " & ' Use NOLOCK to avoid blocking
                     "WHERE Processed = 0 AND contactN IS NOT NULL AND LEN(contactN) >= 10 " &
                     "ORDER BY DateTime"

                    Dim recordsToProcess As New List(Of Dictionary(Of String, String))

                    Using cmd As New SqlCommand(sql, conn)
                        cmd.CommandTimeout = DB_TIMEOUT

                        Using dr = Await cmd.ExecuteReaderAsync()
                            While Await dr.ReadAsync()
                                Dim record As New Dictionary(Of String, String)
                                record("studId") = dr("studId").ToString()
                                record("phone") = dr("contactN").ToString().Trim()
                                record("name") = dr("studname").ToString()
                                record("inOut") = dr("InOut").ToString()
                                record("time") = Convert.ToDateTime(dr("DateTime")).ToString("yyyy-MM-dd HH:mm")
                                record("remarks") = dr("remarks").ToString()
                                record("Program") = dr("Program").ToString()

                                ' Use thread-safe concurrent dictionary instead of SyncLock
                                If processingRecords.TryAdd(record("studId"), True) Then
                                    recordsToProcess.Add(record)
                                End If
                            End While
                        End Using
                    End Using

                    ' Process each record with controlled timing
                    For Each record In recordsToProcess
                        Try
                            ' Process the record
                            If Await ProcessSingleRecordAsync(record("phone"), record("name"),
                                           DateTime.Parse(record("time")),
                                           record("remarks"),
                                           record("inOut"),
                                           record("studId")) Then

                                ' Mark as processed
                                Await MarkRecordAsProcessedAsync(record("studId"))
                            End If
                        Catch ex As Exception
                            LogActivity($"Error processing record {record("studId")}: {ex.Message}")
                        Finally
                            ' Remove from processing set - thread-safe
                            processingRecords.TryRemove(record("studId"), Nothing)
                        End Try

                        ' Add delay between processing each record to reduce load
                        Await Task.Delay(3000) ' 3-second delay between messages
                    Next
                End Using

                Exit For ' Success - exit retry loop
            Catch ex As SqlException When ex.Number = -2 AndAlso retry < MAX_RETRIES
                ' Timeout error - wait and retry - remove Await from Catch block
                UpdateSmsStatus($"Database timeout (attempt {retry}/{MAX_RETRIES}) - retrying...")
                ' Use synchronous delay in Catch block
                Threading.Thread.Sleep(2000 * retry) ' Exponential backoff
            Catch ex As Exception
                UpdateSmsStatus($"Database error: {ex.Message}")
                Exit For
            End Try
        Next
    End Function

    Private Async Function MarkRecordAsProcessedAsync(studId As String) As Task
        For retry = 1 To MAX_RETRIES
            Try
                Using conn As New SqlConnection(conString)
                    Await conn.OpenAsync()
                    Using cmd As New SqlCommand("UPDATE tblAttendance SET Processed = 1 WHERE studId = @id", conn)
                        cmd.CommandTimeout = DB_TIMEOUT
                        cmd.Parameters.AddWithValue("@id", studId)
                        Await cmd.ExecuteNonQueryAsync()
                    End Using
                End Using
                Exit For
            Catch ex As SqlException When ex.Number = -2 AndAlso retry < MAX_RETRIES
                ' Remove Await from Catch block - use synchronous delay
                Threading.Thread.Sleep(1000 * retry)
            Catch ex As Exception
                LogActivity($"Error marking record {studId} as processed: {ex.Message}")
                Exit For
            End Try
        Next
    End Function

    Private Async Function ProcessSingleRecordAsync(phone As String, name As String, time As DateTime,
                                      remarks As String, inOut As String, studId As String) As Task(Of Boolean)
        ' Validate phone number first
        If String.IsNullOrWhiteSpace(phone) OrElse phone.Length < 10 Then
            LogActivity($"Invalid phone number for {name}")
            Return True ' Mark as processed even if invalid number
        End If

        ' Verify serial port is open and ready
        If Not SerialPort1.IsOpen OrElse Not PingArduino() Then
            If Not TryReconnectSerialPort() Then
                LogActivity($"Serial port not ready - cannot send to {name}")
                Return True ' Mark as processed even if port unavailable
            End If
        End If

        ' Build message
        Dim template As String = If(inOut = "IN", inTemplate, outTemplate)
        If String.IsNullOrEmpty(template) Then
            LogActivity($"No template configured for {name}")
            Return True ' Mark as processed even if no template
        End If

        Dim message As String = template
        message = message.Replace("{studname}", name)
        message = message.Replace("{datetime}", time.ToString("yyyy-MM-dd HH:mm"))
        message = message.Replace("{remarks}", remarks)
        message = message.Replace(vbCr, "").Replace(vbLf, " ")

        Dim success As Boolean = False

        ' Try sending up to 2 times with proper async delays (reduced from 3)
        For retry = 1 To 2
            Try
                If Await SendCompleteMessageAsync(phone, message) Then
                    LogActivity($"Successfully sent to {name} ({phone})")
                    LogSentMessage(phone, message, "Auto")
                    success = True
                    Exit For
                End If
            Catch ex As Exception
                LogActivity($"Attempt {retry}/2 failed for {name}: {ex.Message}")
            End Try

            If retry < 2 Then
                Await Task.Delay(2000) ' Wait 2 seconds before retry
            End If
        Next

        If Not success Then
            LogActivity($"Failed to send to {name} after 2 attempts - marking as processed anyway")
        End If

        Return True
    End Function

    Private Function SendMessageToArduino(phone As String, name As String,
                                   time As DateTime, remarks As String,
                                   inOut As String) As Boolean
        If Not SerialPort1.IsOpen Then Return False

        Try
            ' Get template and validate
            Dim template As String = If(inOut = "IN", inTemplate, outTemplate)
            If String.IsNullOrEmpty(template) Then
                Return False
            End If

            ' Build message carefully - without method chaining
            Dim message As New StringBuilder(template)
            message.Replace("{studname}", name)
            message.Replace("{datetime}", time.ToString("yyyy-MM-dd HH:mm"))
            message.Replace("{remarks}", remarks)
            message.Replace(vbCr, "") ' Remove carriage returns
            message.Replace(vbLf, " ") ' Replace newlines with spaces

            ' Debug output
            Dim fullMessage As String = message.ToString()
            Debug.WriteLine($"Sending SMS to {phone}: {fullMessage}")

            ' Clear buffers
            SerialPort1.DiscardInBuffer()
            SerialPort1.DiscardOutBuffer()
            Threading.Thread.Sleep(200)

            ' Send command with proper formatting
            Dim command As String = $"AT|SMS|{phone}|{fullMessage}"
            SerialPort1.WriteLine(command)

            ' Wait for response with longer timeout
            Dim response As New StringBuilder()
            Dim startTime = DateTime.Now

            While (DateTime.Now - startTime).TotalMilliseconds < 10000 ' 10 second timeout
                If SerialPort1.BytesToRead > 0 Then
                    response.Append(SerialPort1.ReadExisting())

                    ' Check for positive response
                    If response.ToString().Contains("+CMGS:") Then
                        Return True
                    ElseIf response.ToString().Contains("ERROR") Then
                        Return False
                    End If
                End If
                Application.DoEvents()
                Threading.Thread.Sleep(100)
            End While

            Return False
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function TryReconnectSerialPort() As Boolean
        If cmbSmsPorts.SelectedItem Is Nothing Then Return False

        Try
            If SerialPort1.IsOpen Then SerialPort1.Close()

            SerialPort1.PortName = cmbSmsPorts.SelectedItem.ToString()
            SerialPort1.Open()
            Threading.Thread.Sleep(2000) ' Allow time for initialization

            ' Verify connection
            Return PingArduino()
        Catch ex As Exception
            UpdateSmsStatus($"Reconnect failed: {ex.Message}")
            Return False
        End Try
    End Function

    Private Function PingArduino() As Boolean
        If Not SerialPort1.IsOpen Then Return False

        Try
            ' Clear buffers
            SerialPort1.DiscardInBuffer()
            SerialPort1.DiscardOutBuffer()

            ' Send ping
            SerialPort1.WriteLine("AT|PING")

            ' Wait for response
            Dim startTime As DateTime = DateTime.Now
            While (DateTime.Now - startTime).TotalSeconds < 2
                If SerialPort1.BytesToRead > 0 Then
                    Dim response As String = SerialPort1.ReadLine()
                    If response.Contains("PONG") Then
                        Return True
                    End If
                End If
                System.Threading.Thread.Sleep(100)
            End While

            Return False
        Catch
            Return False
        End Try
    End Function

    Public Async Function SendCompleteMessageAsync(phoneNumber As String, message As String) As Task(Of Boolean)
        If Not SerialPort1.IsOpen Then Return False

        Try
            ' Small initial delay
            Await Task.Delay(100)

            ' Clear buffers
            SerialPort1.DiscardInBuffer()
            SerialPort1.DiscardOutBuffer()

            Await Task.Delay(200) ' Additional delay after clearing

            ' Send command with proper formatting
            Dim command As String = $"AT|SMS|{phoneNumber}|{message}"
            SerialPort1.WriteLine(command)

            ' Wait for response with async timeout
            Dim response As New StringBuilder()
            Dim startTime = DateTime.Now

            While (DateTime.Now - startTime).TotalMilliseconds < 10000 ' 10 second timeout
                Await Task.Delay(100) ' Non-blocking delay

                If SerialPort1.BytesToRead > 0 Then
                    Dim incoming As String = SerialPort1.ReadExisting()
                    response.Append(incoming)

                    ' Check for positive response
                    If response.ToString().Contains("+CMGS:") Then
                        Return True
                    ElseIf response.ToString().Contains("ERROR") Then
                        Return False
                    End If
                End If
            End While

            Return False
        Catch ex As Exception
            LogActivity($"Send error: {ex.Message}")
            Return False
        End Try
    End Function

    Private Function ProcessMessageTemplate(phoneNumber As String, studentName As String,
dateTime As DateTime, remarks As String, inOut As String) As Task(Of Boolean)
        ' Skip if phone number is invalid
        If String.IsNullOrWhiteSpace(phoneNumber) OrElse phoneNumber.Length < 10 Then
            LogActivity($"Invalid phone number for {studentName}")
            Return Task.FromResult(False)
        End If

        ' Verify serial port is open
        If Not SerialPort1.IsOpen Then
            LogActivity($"Serial port closed - cannot send to {studentName}")
            Return Task.FromResult(False)
        End If

        Try
            Dim template As String = If(inOut = "IN", inTemplate, outTemplate)

            ' Replace placeholders with actual values
            Dim message As String = template
            message = message.Replace("{studname}", studentName)
            message = message.Replace("{datetime}", dateTime.ToString("yyyy-MM-dd HH:mm"))
            message = message.Replace("{remarks}", remarks)

            ' Remove any problematic characters
            message = message.Replace(vbCr, "").Replace(vbLf, " ")

            ' Send the complete message
            Return Task.FromResult(SendMessageToArduino(phoneNumber, studentName, dateTime, remarks, inOut))
        Catch ex As Exception
            LogActivity($"Error processing template for {studentName}: {ex.Message}")
            Return Task.FromResult(False)
        End Try
    End Function

    Private Sub UpdateFilterDisplay()
        If InvokeRequired Then
            Invoke(Sub() UpdateFilterDisplay())
            Return
        End If

        If currentFilters.Count > 0 Then
            Dim filterText As String = "Active filters: " & String.Join("; ", currentFilters.Select(Function(f) $"{f.Key}: {f.Value}"))
            lblAdvancedFilter.Text = filterText
            lblAdvancedFilter.Visible = True
            lblAdvancedFilter.ForeColor = Color.Blue
        Else
            lblAdvancedFilter.Visible = False
        End If
    End Sub

    Private Sub UpdateSearchStatus(recordCount As Integer)
        If InvokeRequired Then
            Invoke(Sub() UpdateSearchStatus(recordCount))
            Return
        End If

        If currentFilters.Count > 0 Then
            lblSmsStatus.Text = $"Found {recordCount} records matching {currentFilters.Count} filter(s)"
        Else
            lblSmsStatus.Text = $"Showing {recordCount} records"
        End If
    End Sub

    Private Sub FilterTimer_Tick(sender As Object, e As EventArgs)
        filterTimer.Stop()
        SearchRecordsWithDate()
    End Sub

    Private Sub StartFilterTimer()
        filterTimer.Stop()
        filterTimer.Start()
    End Sub


End Class