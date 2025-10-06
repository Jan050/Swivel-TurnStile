Imports System.Data.SqlClient
Imports System.IO
Imports System.IO.Ports
Imports System.Text

Public Class Form1

    Public cmd As New SqlCommand
    Public dr As SqlDataReader
    Public da As SqlDataAdapter
    Private connection As SqlConnection
    Private lastCheckedTime As DateTime = DateTime.MinValue
    Private inTemplate As String = ""
    Private outTemplate As String = ""
    Private ReadOnly CONNECTION_STRING As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User-PC\Documents\Swivel TurnStile-2\Swivel TurnStile\MyDataBase.mdf;Integrated Security=True;Connect Timeout=30"
    Private sentMessagesFile As String = "sent_messages.txt"

    Private lastLogMessage As String = ""
    Private checkInterval As Integer = 5000 ' Default 5 seconds
    Private isAutoChecking As Boolean = True
    Private logFile As String = "activity_log.txt"

    Private Const ARDUINO_RESPONSE_TIMEOUT As Integer = 5000 ' 5 seconds
    Private Const ARDUINO_BAUD_RATE As Integer = 9600
    Private processingRecords As New HashSet(Of String)

    Private Function GetConnection() As SqlConnection
        Return New SqlConnection(CONNECTION_STRING)
    End Function



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshPorts()
        LoadTemplates()
        InitializeSentMessagesGrid()
        LoadSentMessages()
        LoadAttendanceData()

        ' Load configuration
        LoadConfiguration()

        ' Initialize status
        UpdateStatus("System initialized. Waiting for records...")

        ' Set up timer with proper interval (REMOVED AddHandler)
        Timer1.Interval = checkInterval
        Timer1.Enabled = isAutoChecking

        ' Start background logger
        StartBackgroundLogger()

        ' Optimize database on startup
        OptimizeDatabase()
    End Sub

    Private Sub RefreshPorts()
        cmbPorts.Items.Clear()
        For Each port As String In SerialPort.GetPortNames()
            cmbPorts.Items.Add(port)
        Next
        If cmbPorts.Items.Count > 0 Then
            cmbPorts.SelectedIndex = 0
        End If
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        RefreshPorts()
    End Sub

    Private Sub btnConnect_Click(sender As Object, e As EventArgs) Handles btnConnect.Click
        If btnConnect.Text = "Connect" Then
            If cmbPorts.SelectedItem IsNot Nothing Then
                Try
                    If SerialPort1.IsOpen Then
                        SerialPort1.Close()
                    End If

                    SerialPort1.PortName = cmbPorts.SelectedItem.ToString()
                    SerialPort1.BaudRate = ARDUINO_BAUD_RATE
                    SerialPort1.Parity = Parity.None
                    SerialPort1.StopBits = StopBits.One
                    SerialPort1.DataBits = 8
                    SerialPort1.Handshake = Handshake.None
                    SerialPort1.NewLine = vbLf ' Standardize line ending
                    SerialPort1.ReadTimeout = ARDUINO_RESPONSE_TIMEOUT
                    SerialPort1.WriteTimeout = ARDUINO_RESPONSE_TIMEOUT
                    SerialPort1.Open()
                    btnConnect.Text = "Disconnect"
                    lblStatus.Text = "Connected"
                    btnSend.Enabled = True
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
                btnConnect.Text = "Connect"
                lblStatus.Text = "Disconnected"
                btnSend.Enabled = False
            Catch ex As Exception
                MessageBox.Show("Error disconnecting: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        If txtPhoneNumber.Text = "" Then
            MessageBox.Show("Please enter a phone number")
            Return
        End If

        If txtMessage.Text = "" Then
            MessageBox.Show("Please enter a message")
            Return
        End If

        Try
            SendCompleteMessage(txtPhoneNumber.Text, txtMessage.Text)
            MessageBox.Show("SMS sent to Arduino for processing")
        Catch ex As Exception
            MessageBox.Show("Error sending SMS: " & ex.Message)
        End Try
    End Sub

    Private Sub btnLoadData_Click(sender As Object, e As EventArgs) Handles btnLoadData.Click
        LoadAttendanceData()
    End Sub

    Private Sub LoadAttendanceData()
        ' Use a new connection for this operation
        Using connection As SqlConnection = GetConnection()
            Try
                dgvAttendance.Rows.Clear()
                connection.Open()

                Using cmd As New SqlCommand("Select studId, studname, DateTime, InOut, remarks, Processed From tblAttendance", connection)
                    Using dr As SqlDataReader = cmd.ExecuteReader()
                        While dr.Read()
                            ' Safely get values with null checks
                            Dim col0 As String = If(dr.IsDBNull(0), String.Empty, dr.GetString(0))
                            Dim col1 As Object = If(dr.IsDBNull(1), String.Empty, dr.Item(1))
                            Dim col2 As Object = If(dr.IsDBNull(2), String.Empty, dr.Item(2))
                            Dim col3 As Object = If(dr.IsDBNull(3), String.Empty, dr.Item(3))
                            Dim col4 As Object = If(dr.IsDBNull(4), String.Empty, dr.Item(4))
                            Dim processed As Boolean = If(dr.IsDBNull(5), False, CBool(dr.Item(5)))

                            ' Add a visual indicator for processed records
                            Dim row As DataGridViewRow = New DataGridViewRow()
                            row.CreateCells(dgvAttendance, col0, col1, col2, col3, col4, If(processed, "Yes", "No"))

                            ' Color processed rows differently
                            If processed Then
                                row.DefaultCellStyle.BackColor = Color.LightGray
                            End If

                            dgvAttendance.Rows.Add(row)
                        End While
                    End Using
                End Using

            Catch ex As Exception
                MessageBox.Show("Error loading attendance data: " & ex.Message)
            End Try
        End Using ' Connection will be disposed here
    End Sub

    Private Sub btnCheckNewRecords_Click(sender As Object, e As EventArgs) Handles btnCheckNewRecords.Click
        CheckForNewRecords()
    End Sub

    Private Sub btnSaveConfig_Click(sender As Object, e As EventArgs) Handles btnSaveConfig.Click
        checkInterval = CInt(numCheckInterval.Value)
        isAutoChecking = chkAutoCheckEnabled.Checked
        Timer1.Interval = checkInterval
        Timer1.Enabled = isAutoChecking
        SaveConfiguration()
        UpdateStatus($"Configuration saved. Auto-check: {isAutoChecking}, Interval: {checkInterval}ms")
    End Sub

    Private Sub btnViewLog_Click(sender As Object, e As EventArgs) Handles btnViewLog.Click
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


    Private Sub UpdateStatus(message As String)
        If InvokeRequired Then
            Invoke(Sub() UpdateStatus(message))
            Return
        End If

        lastLogMessage = $"{DateTime.Now:HH:mm:ss} - {message}"
        statusLabel.Text = lastLogMessage
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

    Private Sub StartBackgroundLogger()
        ' This would be more robust as a proper background worker
        AddHandler Timer1.Tick, Sub(s, e)
                                    If Not String.IsNullOrEmpty(lastLogMessage) Then
                                        Debug.WriteLine(lastLogMessage)
                                    End If
                                End Sub
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

    Private Sub CheckForNewRecords()
        ' Verify connections first
        If Not VerifyConnections() Then Return

        ' Use thread pool for background checking
        Threading.ThreadPool.QueueUserWorkItem(Sub(state)
                                                   SyncLock Me
                                                       CheckForNewRecordsInternal()
                                                   End SyncLock
                                               End Sub)
    End Sub

    Private Sub CheckForNewRecordsInternal()

        Dim recordsToProcess As New List(Of String)
        Dim successCount As Integer = 0

        ' Use a new connection for this operation
        Using connection As SqlConnection = GetConnection()
            Try
                connection.Open()

                ' Get unprocessed records
                Dim query As String = "SELECT studId, studname, DateTime, InOut, remarks, Type, contactN " &
                             "FROM tblAttendance " &
                             "WHERE Processed = 0 AND contactN IS NOT NULL AND contactN <> '' " &
                             "ORDER BY DateTime"


                Using cmd As New SqlCommand(query, connection)
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Try
                                Dim studId As String = reader("studId").ToString()
                                Dim phoneNumber As String = If(reader.IsDBNull(reader.GetOrdinal("contactN")), String.Empty, reader("contactN").ToString())
                                Dim studentName As String = If(reader.IsDBNull(reader.GetOrdinal("studname")), String.Empty, reader("studname").ToString())
                                Dim inOut As String = reader("InOut").ToString()
                                Dim dateTime As DateTime = If(reader.IsDBNull(reader.GetOrdinal("DateTime")), DateTime.Now, Convert.ToDateTime(reader("DateTime")))
                                Dim remarks As String = reader("remarks").ToString()

                                If InvokeRequired Then
                                    Invoke(Sub()
                                               If ProcessMessageTemplate(phoneNumber, studentName, dateTime, remarks, inOut) Then
                                                   recordsToProcess.Add(studId)
                                                   successCount += 1
                                               End If
                                           End Sub)
                                Else
                                    If ProcessMessageTemplate(phoneNumber, studentName, dateTime, remarks, inOut) Then
                                        recordsToProcess.Add(studId)
                                        successCount += 1
                                    End If
                                End If

                            Catch ex As Exception
                                LogActivity($"Error processing record: {ex.Message}")
                            End Try
                        End While
                    End Using
                End Using


                ' Mark successfully sent records as processed
                If recordsToProcess.Count > 0 Then
                    MarkRecordsAsProcessed(recordsToProcess, connection)
                    UpdateStatus($"Auto-sent {successCount} messages")
                End If
            Catch ex As Exception
                UpdateStatus($"Error in auto-check: {ex.Message}")
                LogActivity($"CheckForNewRecordsInternal Error: {ex.ToString()}")
            End Try
        End Using
    End Sub


    Private Sub MarkRecordsAsProcessed(recordIds As List(Of String), Optional connection As SqlConnection = Nothing)
        Dim useExternalConnection As Boolean = (connection IsNot Nothing)
        Dim localConnection As SqlConnection = Nothing

        Try
            ' Use provided connection or create new one
            If Not useExternalConnection Then
                localConnection = GetConnection()
                localConnection.Open()
                connection = localConnection
            End If

            ' Create properly quoted list of string IDs
            Dim quotedIds = recordIds.Select(Function(id) $"'{id.Replace("'", "''")}'")
            Dim idList As String = String.Join(",", quotedIds)

            Dim updateQuery As String = $"UPDATE tblAttendance SET Processed = 1 WHERE studId IN ({idList})"

            Using cmd As New SqlCommand(updateQuery, connection)
                cmd.ExecuteNonQuery()
            End Using

            LogActivity($"Marked {recordIds.Count} records as processed")
        Catch ex As Exception
            LogActivity($"Error marking records as processed: {ex.Message}")
        Finally
            ' Only close if we created the connection locally
            If Not useExternalConnection AndAlso localConnection IsNot Nothing AndAlso localConnection.State = ConnectionState.Open Then
                localConnection.Close()
            End If
        End Try
    End Sub

    Private Sub btnSaveTemplates_Click(sender As Object, e As EventArgs) Handles btnSaveTemplates.Click
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

    Private Sub OptimizeDatabase()
        Try
            Using con As SqlConnection = GetConnection()
                EnsureConnectionOpen(con) ' Pass the connection parameter

                Dim cmdText As String = "IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_tblAttendance_DateTime') " &
                                "CREATE INDEX IX_tblAttendance_DateTime ON tblAttendance(DateTime)"

                Using cmd As New SqlCommand(cmdText, con)
                    cmd.ExecuteNonQuery()
                End Using

                cmdText = "IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_tblAttendance_contactN') " &
                  "CREATE INDEX IX_tblAttendance_contactN ON tblAttendance(contactN) WHERE contactN IS NOT NULL"

                Using cmd As New SqlCommand(cmdText, con)
                    cmd.ExecuteNonQuery()
                End Using

                UpdateStatus("Database optimization complete")
            End Using
        Catch ex As Exception
            LogActivity("Error optimizing database: " & ex.Message)
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

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Not isAutoChecking Then Exit Sub

        Try
            ' Verify connections are ready
            If Not SerialPort1.IsOpen OrElse Not PingArduino() Then
                UpdateStatus("Connection not ready - attempting to reconnect...")
                If Not TryReconnectSerialPort() Then Exit Sub
            End If

            ' Direct check without threading
            CheckAndProcessNewRecords()
        Catch ex As Exception
            UpdateStatus($"Timer error: {ex.Message}")
            LogActivity($"Timer error: {ex.ToString()}")
        End Try
    End Sub

    Private Sub CheckAndProcessNewRecords()
        ' Use a transaction to ensure data consistency
        Using conn As New SqlConnection(CONNECTION_STRING)
            conn.Open()
            Dim transaction As SqlTransaction = conn.BeginTransaction(IsolationLevel.ReadCommitted)

            Try
                ' Get only unprocessed records not currently being processed
                Dim sql = "SELECT TOP 10 studId, studname, DateTime, InOut, remarks, contactN " &
                 "FROM tblAttendance WITH (UPDLOCK, ROWLOCK) " &  ' Add locking hints
                 "WHERE Processed = 0 AND contactN IS NOT NULL AND LEN(contactN) >= 10 " &
                 "ORDER BY DateTime"

                Dim recordsToProcess As New List(Of Dictionary(Of String, String))

                Using cmd As New SqlCommand(sql, conn, transaction)
                    Using dr = cmd.ExecuteReader()
                        While dr.Read()
                            Dim record As New Dictionary(Of String, String)
                            record("studId") = dr("studId").ToString()
                            record("phone") = dr("contactN").ToString().Trim()
                            record("name") = dr("studname").ToString()
                            record("inOut") = dr("InOut").ToString()
                            record("time") = Convert.ToDateTime(dr("DateTime")).ToString("yyyy-MM-dd HH:mm")
                            record("remarks") = dr("remarks").ToString()

                            ' Add to processing list and mark as in-progress
                            SyncLock processingRecords
                                If Not processingRecords.Contains(record("studId")) Then
                                    processingRecords.Add(record("studId"))
                                    recordsToProcess.Add(record)
                                End If
                            End SyncLock
                        End While
                    End Using
                End Using

                ' Process each record with proper error handling
                For Each record In recordsToProcess
                    Try
                        If ProcessSingleRecord(record("phone"), record("name"),
                                       DateTime.Parse(record("time")),
                                       record("remarks"),
                                       record("inOut"),
                                       record("studId")) Then

                            ' Mark as processed in the same transaction
                            Dim updateSql = "UPDATE tblAttendance SET Processed = 1 WHERE studId = @id"
                            Using updateCmd As New SqlCommand(updateSql, conn, transaction)
                                updateCmd.Parameters.AddWithValue("@id", record("studId"))
                                updateCmd.ExecuteNonQuery()
                            End Using
                        End If
                    Catch ex As Exception
                        LogActivity($"Error processing record {record("studId")}: {ex.Message}")
                    Finally
                        ' Remove from processing set
                        SyncLock processingRecords
                            processingRecords.Remove(record("studId"))
                        End SyncLock
                    End Try
                Next

                ' Commit if all successful
                transaction.Commit()

                ' Refresh UI if we processed anything
                If recordsToProcess.Count > 0 Then
                    Invoke(Sub() LoadAttendanceData())
                End If

            Catch ex As Exception
                Try
                    transaction.Rollback()
                Catch
                End Try

                UpdateStatus($"Database error: {ex.Message}")
                LogActivity($"CheckAndProcessNewRecords error: {ex.ToString()}")
            End Try
        End Using
    End Sub

    Private Function ProcessSingleRecord(phone As String, name As String, time As DateTime,
                              remarks As String, inOut As String, studId As String) As Boolean
        ' Validate phone number first
        If String.IsNullOrWhiteSpace(phone) OrElse phone.Length < 10 Then
            LogActivity($"Invalid phone number for {name}")
            Return False
        End If

        ' Verify serial port is open and ready
        If Not SerialPort1.IsOpen OrElse Not PingArduino() Then
            If Not TryReconnectSerialPort() Then
                LogActivity($"Serial port not ready - cannot send to {name}")
                Return False
            End If
        End If

        ' Get template
        Dim template As String = If(inOut = "IN", inTemplate, outTemplate)
        If String.IsNullOrEmpty(template) Then
            LogActivity($"No template configured for {name}")
            Return False
        End If

        ' Build message
        Dim message As String = template
        message = message.Replace("{studname}", name)
        message = message.Replace("{datetime}", time.ToString("yyyy-MM-dd HH:mm"))
        message = message.Replace("{remarks}", remarks)
        message = message.Replace(vbCr, "").Replace(vbLf, " ")

        ' Try sending up to 2 times with proper delays
        For retry = 1 To 2
            Try
                If SendCompleteMessage(phone, message) Then
                    LogActivity($"Successfully sent to {name} ({phone})")
                    LogSentMessage(phone, message, "Auto")
                    Return True
                End If
            Catch ex As Exception
                LogActivity($"Attempt {retry}/2 failed for {name}: {ex.Message}")
            End Try

            If retry < 2 Then
                Threading.Thread.Sleep(2000) ' Wait before retry
            End If
        Next

        LogActivity($"Failed to send to {name} after 2 attempts")
        Return False
    End Function

    Private Function SendMessageToArduino(phone As String, name As String,
                                   time As DateTime, remarks As String,
                                   inOut As String) As Boolean
        If Not SerialPort1.IsOpen Then Return False

        Try
            ' Get template and validate
            Dim template As String = If(inOut = "IN", inTemplate, outTemplate)
            If String.IsNullOrEmpty(template) Then
                'LogActivity("Error: Template is empty")
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
            'LogActivity($"Complete message: {fullMessage}")
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
                        'LogActivity("SMS sent successfully")
                        Return True
                    ElseIf response.ToString().Contains("ERROR") Then
                        ' LogActivity($"SMS failed: {response}")
                        Return False
                    End If
                End If
                Application.DoEvents()
                Threading.Thread.Sleep(100)
            End While

            'LogActivity("Timeout waiting for response")
            Return False
        Catch ex As Exception
            'LogActivity($"Send error: {ex.Message}")
            Return False
        End Try
    End Function

    Private Function TryReconnectSerialPort() As Boolean
        If cmbPorts.SelectedItem Is Nothing Then Return False

        Try
            If SerialPort1.IsOpen Then SerialPort1.Close()

            SerialPort1.PortName = cmbPorts.SelectedItem.ToString()
            SerialPort1.Open()
            Threading.Thread.Sleep(2000) ' Allow time for initialization

            ' Verify connection
            Return PingArduino()
        Catch ex As Exception
            UpdateStatus($"Reconnect failed: {ex.Message}")
            Return False
        End Try
    End Function

    Private Sub MarkAsProcessed(studId As String)
        Using conn As New SqlConnection(CONNECTION_STRING)
            conn.Open()
            Using cmd = New SqlCommand("UPDATE tblAttendance SET Processed = 1 WHERE studId = @id", conn)
                cmd.Parameters.AddWithValue("@id", studId)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

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

    Private Function VerifyConnections() As Boolean
        ' Verify serial port
        If Not SerialPort1.IsOpen Then
            UpdateStatus("Serial port disconnected")
            Return False
        End If

        ' Verify database connection
        Try
            Using connection As SqlConnection = GetConnection()
                EnsureConnectionOpen(connection)
                Return True
            End Using
        Catch ex As Exception
            UpdateStatus($"Database error: {ex.Message}")
            Return False
        End Try
    End Function

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If connection IsNot Nothing AndAlso connection.State = ConnectionState.Open Then
            connection.Close()
            connection.Dispose()
        End If

        If SerialPort1.IsOpen Then
            SerialPort1.Close()
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

    ' Add these with your other private methods in Form1 class
    Private Function SendCompleteMessage(phoneNumber As String, message As String) As Boolean
        If Not SerialPort1.IsOpen Then Return False

        Try
            ' Clear buffers
            SerialPort1.DiscardInBuffer()
            SerialPort1.DiscardOutBuffer()
            Threading.Thread.Sleep(200)

            ' Send command with proper formatting
            Dim command As String = $"AT|SMS|{phoneNumber}|{message}"
            SerialPort1.WriteLine(command)

            ' Wait for response with timeout
            Dim response As New StringBuilder()
            Dim startTime = DateTime.Now

            While (DateTime.Now - startTime).TotalMilliseconds < 10000 ' 10 second timeout
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
                Threading.Thread.Sleep(100)
            End While

            Return False
        Catch ex As Exception
            LogActivity($"Send error: {ex.Message}")
            Return False
        End Try
    End Function

    Private Function ProcessMessageTemplate(phoneNumber As String, studentName As String,
                                      dateTime As DateTime, remarks As String, inOut As String) As Boolean
        ' Skip if phone number is invalid
        If String.IsNullOrWhiteSpace(phoneNumber) OrElse phoneNumber.Length < 10 Then
            LogActivity($"Invalid phone number for {studentName}")
            Return False
        End If

        ' Verify serial port is open
        If Not SerialPort1.IsOpen Then
            LogActivity($"Serial port closed - cannot send to {studentName}")
            Return False
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
            Return SendCompleteMessage(phoneNumber, message)
        Catch ex As Exception
            LogActivity($"Error processing template for {studentName}: {ex.Message}")
            Return False
        End Try
    End Function

    ' Modify the EnsureConnectionOpen method
    Private Sub EnsureConnectionOpen(connection As SqlConnection)
        If connection.State = ConnectionState.Closed Then
            connection.Open()
        ElseIf connection.State = ConnectionState.Broken Then
            connection.Close()
            connection.Open()
        End If
    End Sub

    Private Sub btnReprocess_Click(sender As Object, e As EventArgs) Handles btnReprocess.Click
        ' Get selected rows
        Dim selectedIds As New List(Of Integer)
        For Each row As DataGridViewRow In dgvAttendance.SelectedRows
            selectedIds.Add(CInt(row.Cells("Column1").Value))
        Next

        If selectedIds.Count > 0 Then
            ' Mark records as unprocessed
            Try
                Using con As SqlConnection = GetConnection()
                    EnsureConnectionOpen(con) ' Pass the connection parameter
                    Dim idList As String = String.Join(",", selectedIds)
                    Dim updateQuery As String = $"UPDATE tblAttendance SET Processed = 0 WHERE studId IN ({idList})"

                    Using cmd As New SqlCommand(updateQuery, con)
                        cmd.ExecuteNonQuery()
                    End Using

                    MessageBox.Show($"{selectedIds.Count} records marked for reprocessing")
                    LoadAttendanceData() ' Refresh the view
                End Using
            Catch ex As Exception
                MessageBox.Show("Error marking records: " & ex.Message)
            End Try
        Else
            MessageBox.Show("Please select records to reprocess")
        End If
    End Sub
End Class