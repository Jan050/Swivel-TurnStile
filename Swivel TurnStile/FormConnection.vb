Imports System.Data.SqlClient
Imports System.Configuration
Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading
Imports System.Net.NetworkInformation

Public Class FormConnection

    ' Student structure
    Public Class StudentRecord
        Public Property StudId As String
        Public Property FullName As String
        Public Property Picture As Image
        Public Property RFID As String
        Public Property Type As String
        Public Property ContactN As String
        Public Property RelayToActivate As Integer
    End Class

    ' TCP Servers
    Private tcpListener8080 As TcpListener
    Private tcpListener7070 As TcpListener
    Private clients8080 As New List(Of ClientInfo)()
    Private clients7070 As New List(Of ClientInfo)()
    Private isServerRunning As Boolean = False
    Private serverThread8080 As Thread
    Private serverThread7070 As Thread

    ' Client info
    Private Class ClientInfo
        Public Property Client As TcpClient
        Public Property IPAddress As String
        Public Property Port As Integer
        Public Property Writer As StreamWriter
        Public Property Reader As StreamReader
        Public Property Stream As NetworkStream
        Public Property LastProcessedCard As String = ""
        Public Property LastProcessedTime As DateTime = DateTime.MinValue

        Public Sub New(client As TcpClient, port As Integer)
            Me.Client = client
            Me.Port = port
            Me.IPAddress = DirectCast(client.Client.RemoteEndPoint, IPEndPoint).Address.ToString()
            Me.Stream = client.GetStream()
            Me.Reader = New StreamReader(Stream, Encoding.ASCII)
            Me.Writer = New StreamWriter(Stream, Encoding.ASCII) With {.AutoFlush = True}
        End Sub
    End Class

    ' Database
    Private ReadOnly conString As String = ConfigurationManager.ConnectionStrings("Swivel_TurnStile.My.MySettings.MyDataBaseConnectionString").ConnectionString
    Private studentCache As New Dictionary(Of String, StudentRecord)() ' Optional memory cache

    ' Events
    Public Event StudentScannedGate1 As EventHandler(Of StudentRecord)
    Public Event StudentScannedGate2 As EventHandler(Of StudentRecord)
    Public Event StudentScannedGate3 As EventHandler(Of StudentRecord)
    Public Event StudentScannedGate4 As EventHandler(Of StudentRecord)

    ' Track if form is disposed - use a different name to avoid conflict
    Private formIsDisposed As Boolean = False

    Private Sub FormConnection_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize the client list displays
        lbConnectedClients7070.Text = "Connected Clients (7070): 0"
        lbConnectedClients8080.Text = "Connected Clients (8080): 0"
        lstClients7070.Items.Clear()
        lstClients8080.Items.Clear()

        ' Start network monitoring
        MonitorNetworkChanges()

        StartServer()
    End Sub

    Private Sub MonitorNetworkChanges()
        AddHandler NetworkChange.NetworkAddressChanged, AddressOf OnNetworkAddressChanged
        AddHandler NetworkChange.NetworkAvailabilityChanged, AddressOf OnNetworkAvailabilityChanged
    End Sub

    Private Sub OnNetworkAddressChanged(sender As Object, e As EventArgs)
        Debug.WriteLine("Network address changed - checking client connections")
        CheckAllConnections()
    End Sub

    Private Sub OnNetworkAvailabilityChanged(sender As Object, e As NetworkAvailabilityEventArgs)
        Debug.WriteLine($"Network availability changed: {e.IsAvailable}")
        If Not e.IsAvailable Then
            ' Network went down - assume all clients disconnected
            ForceDisconnectAllClients()
        Else
            CheckAllConnections()
        End If
    End Sub

    Private Sub CheckAllConnections()
        ' Force check all client connections
        For Each clientInfo In clients7070.ToList()
            If Not IsClientReallyConnected(clientInfo) Then
                Debug.WriteLine($"Client {clientInfo.IPAddress} failed connection check")
                RemoveClient(clientInfo)
            End If
        Next
        For Each clientInfo In clients8080.ToList()
            If Not IsClientReallyConnected(clientInfo) Then
                Debug.WriteLine($"Client {clientInfo.IPAddress} failed connection check")
                RemoveClient(clientInfo)
            End If
        Next
    End Sub

    Private Function IsClientReallyConnected(clientInfo As ClientInfo) As Boolean
        Try
            ' More thorough connection check
            If Not clientInfo.Client.Connected Then Return False

            ' Try to send a tiny piece of data to check if connection is really alive
            If clientInfo.Client.Client.Poll(1000, SelectMode.SelectRead) AndAlso clientInfo.Client.Client.Available = 0 Then
                Return False
            End If

            Return True
        Catch
            Return False
        End Try
    End Function

    Private Sub ForceDisconnectAllClients()
        ' Network went down - close all connections
        CloseAllClientConnections(clients7070)
        CloseAllClientConnections(clients8080)

        UpdateUI(Sub()
                     lbConnectedClients7070.Text = "Connected Clients (7070): 0"
                     lbConnectedClients8080.Text = "Connected Clients (8080): 0"
                     lstClients7070.Items.Clear()
                     lstClients8080.Items.Clear()
                 End Sub)
    End Sub

    ' ================= Start Server =================
    Private Sub StartServer()
        Try
            ' Start server on port 8080
            tcpListener8080 = New TcpListener(IPAddress.Any, 8080)
            serverThread8080 = New Thread(AddressOf ListenForClients8080)
            serverThread8080.IsBackground = True
            serverThread8080.Start()

            ' Start server on port 7070
            tcpListener7070 = New TcpListener(IPAddress.Any, 7070)
            serverThread7070 = New Thread(AddressOf ListenForClients7070)
            serverThread7070.IsBackground = True
            serverThread7070.Start()

            isServerRunning = True

            UpdateUI(Sub()
                         If Not formIsDisposed Then
                             lbServerStatus.Text = "Server Status: Running (8080 & 7070)"
                             lbServerStatus.ForeColor = Color.Green
                         End If
                     End Sub)
        Catch ex As Exception
            MessageBox.Show($"Failed to start server: {ex.Message}")
        End Try
    End Sub

    Private Sub StopServer()
        isServerRunning = False

        ' Stop the listeners first to prevent new connections
        Try
            tcpListener8080?.Stop()
            tcpListener7070?.Stop()
        Catch ex As Exception
            ' Ignore errors when stopping listeners
        End Try

        ' Close all client connections gracefully
        CloseAllClientConnections(clients8080)
        CloseAllClientConnections(clients7070)

        ' Wait a moment for threads to terminate
        Thread.Sleep(100)

        UpdateUI(Sub()
                     If Not formIsDisposed Then
                         lbServerStatus.Text = "Server Status: Stopped"
                         lbServerStatus.ForeColor = Color.Red
                         lbConnectedClients7070.Text = "Connected Clients (7070): 0"
                         lbConnectedClients8080.Text = "Connected Clients (8080): 0"
                         lstClients7070.Items.Clear()
                         lstClients8080.Items.Clear()
                     End If
                 End Sub)
    End Sub

    Private Sub CloseAllClientConnections(clientList As List(Of ClientInfo))
        For Each clientInfo In clientList.ToList()
            Try
                ' Close the stream and client gracefully
                If clientInfo.Stream IsNot Nothing Then
                    clientInfo.Stream.Close()
                End If
                If clientInfo.Client IsNot Nothing Then
                    clientInfo.Client.Close()
                End If
            Catch ex As Exception
                ' Ignore errors when closing clients
            End Try
        Next
        clientList.Clear()
    End Sub

    ' ================= Listen for clients on port 8080 =================
    Private Sub ListenForClients8080()
        Try
            tcpListener8080.Start()
            While isServerRunning
                Try
                    If tcpListener8080.Pending() Then
                        Dim client As TcpClient = tcpListener8080.AcceptTcpClient()
                        Dim clientInfo As New ClientInfo(client, 8080)
                        clients8080.Add(clientInfo)
                        Dim t As New Thread(Sub() HandleClient(clientInfo))
                        t.IsBackground = True
                        t.Start()
                        UpdateUI(Sub()
                                     If Not formIsDisposed Then
                                         lbConnectedClients8080.Text = $"Connected Clients (8080): {clients8080.Count}"
                                         UpdateClientList8080()
                                     End If
                                 End Sub)
                    End If
                    Thread.Sleep(50)
                Catch ex As Exception When isServerRunning
                    ' Only log if server is still supposed to be running
                    Debug.WriteLine($"Error in 8080 listener loop: {ex.Message}")
                End Try
            End While
        Catch ex As Exception
            Debug.WriteLine($"8080 Listener thread error: {ex.Message}")
        Finally
            Try
                tcpListener8080?.Stop()
            Catch ex As Exception
                ' Ignore errors when stopping
            End Try
        End Try
    End Sub

    ' ================= Update Client List for Port 8080 =================
    Private Sub UpdateClientList8080()
        If formIsDisposed Then Return

        UpdateUI(Sub()
                     If Not formIsDisposed Then
                         lstClients8080.Items.Clear()
                         For Each clientInfo In clients8080
                             Dim status = If(clientInfo.Client.Connected, "Connected", "Disconnected")
                             lstClients8080.Items.Add($"{clientInfo.IPAddress} - {status}")
                         Next
                     End If
                 End Sub)
    End Sub

    ' ================= Listen for clients on port 7070 =================
    Private Sub ListenForClients7070()
        Try
            tcpListener7070.Start()
            While isServerRunning
                Try
                    If tcpListener7070.Pending() Then
                        Dim client As TcpClient = tcpListener7070.AcceptTcpClient()
                        Dim clientInfo As New ClientInfo(client, 7070)
                        clients7070.Add(clientInfo)
                        Dim t As New Thread(Sub() HandleClient(clientInfo))
                        t.IsBackground = True
                        t.Start()
                        UpdateUI(Sub()
                                     If Not formIsDisposed Then
                                         lbConnectedClients7070.Text = $"Connected Clients (7070): {clients7070.Count}"
                                         UpdateClientList7070()
                                     End If
                                 End Sub)
                    End If
                    Thread.Sleep(50)
                Catch ex As Exception When isServerRunning
                    ' Only log if server is still supposed to be running
                    Debug.WriteLine($"Error in 7070 listener loop: {ex.Message}")
                End Try
            End While
        Catch ex As Exception
            Debug.WriteLine($"7070 Listener thread error: {ex.Message}")
        Finally
            Try
                tcpListener7070?.Stop()
            Catch ex As Exception
                ' Ignore errors when stopping
            End Try
        End Try
    End Sub

    ' ================= Update Client List for Port 7070 =================
    Private Sub UpdateClientList7070()
        If formIsDisposed Then Return

        UpdateUI(Sub()
                     If Not formIsDisposed Then
                         lstClients7070.Items.Clear()
                         For Each clientInfo In clients7070
                             Dim status = If(clientInfo.Client.Connected, "Connected", "Disconnected")
                             lstClients7070.Items.Add($"{clientInfo.IPAddress} - {status}")
                         Next
                     End If
                 End Sub)
    End Sub


    ' ================= Handle Client =================
    Private Sub HandleClient(clientInfo As ClientInfo)
        Try
            ' Send welcome with port information
            clientInfo.Writer.WriteLine($"HELLO:{clientInfo.IPAddress}:{clientInfo.Port}")

            ' Update client list immediately after connection
            If clientInfo.Port = 7070 Then
                UpdateClientList7070()
            ElseIf clientInfo.Port = 8080 Then
                UpdateClientList8080()
            End If

            While clientInfo.Client.Connected AndAlso isServerRunning
                Try
                    ' Check if data is available before reading to avoid blocking
                    If clientInfo.Stream.DataAvailable Then
                        Dim message As String = clientInfo.Reader.ReadLine()
                        If message Is Nothing Then Exit While

                        message = message.Trim()
                        If message <> "" Then
                            ProcessClientMessage(message, clientInfo)

                            ' Update client status after processing message
                            If clientInfo.Port = 7070 Then
                                UpdateClientList7070()
                            ElseIf clientInfo.Port = 8080 Then
                                UpdateClientList8080()
                            End If
                        End If
                    Else
                        ' Small delay to prevent CPU spinning
                        Thread.Sleep(10)
                    End If
                Catch ex As IOException When Not isServerRunning
                    ' Server is stopping, exit gracefully
                    Exit While
                Catch ex As Exception When isServerRunning
                    ' Only handle exceptions if server is still running
                    Debug.WriteLine($"Error reading from client on port {clientInfo.Port}: {ex.Message}")
                    Exit While
                End Try
            End While
        Catch ex As Exception When isServerRunning
            Debug.WriteLine($"Error in client handler on port {clientInfo.Port}: {ex.Message}")
        Finally
            RemoveClient(clientInfo)
        End Try
    End Sub

    Private Sub RemoveClient(clientInfo As ClientInfo)
        Try
            ' Close streams and client first
            If clientInfo.Reader IsNot Nothing Then
                clientInfo.Reader.Close()
            End If
            If clientInfo.Writer IsNot Nothing Then
                clientInfo.Writer.Close()
            End If
            If clientInfo.Stream IsNot Nothing Then
                clientInfo.Stream.Close()
            End If
            If clientInfo.Client IsNot Nothing Then
                clientInfo.Client.Close()
            End If

            ' Remove from appropriate client list
            If clientInfo.Port = 8080 Then
                clients8080.Remove(clientInfo)
                UpdateUI(Sub()
                             If Not formIsDisposed Then
                                 lbConnectedClients8080.Text = $"Connected Clients (8080): {clients8080.Count}"
                                 UpdateClientList8080()
                             End If
                         End Sub)
            ElseIf clientInfo.Port = 7070 Then
                clients7070.Remove(clientInfo)
                UpdateUI(Sub()
                             If Not formIsDisposed Then
                                 lbConnectedClients7070.Text = $"Connected Clients (7070): {clients7070.Count}"
                                 UpdateClientList7070()
                             End If
                         End Sub)
            End If

        Catch ex As Exception
            Debug.WriteLine($"Error removing client on port {clientInfo.Port}: {ex.Message}")
        End Try
    End Sub

    ' ================= Process Client Message =================
    Private Sub ProcessClientMessage(message As String, clientInfo As ClientInfo)
        Try
            If message = "PING" Then
                clientInfo.Writer.WriteLine("PONG")
                Return
            End If

            ' Expect format: readerNumber:UID
            Dim parts = message.Split(":"c)
            If parts.Length = 2 Then
                Dim readerNumber As Integer
                If Integer.TryParse(parts(0), readerNumber) Then
                    Dim cardUID = parts(1)

                    ' Duplicate card filter (1 sec)
                    If clientInfo.LastProcessedCard = cardUID AndAlso (DateTime.Now - clientInfo.LastProcessedTime).TotalMilliseconds < 1000 Then
                        Return
                    End If

                    clientInfo.LastProcessedCard = cardUID
                    clientInfo.LastProcessedTime = DateTime.Now

                    ' Process immediately with client information
                    ProcessRFIDScan(readerNumber, cardUID, clientInfo)
                End If
            End If
        Catch ex As Exception
            Debug.WriteLine($"Error processing client message on port {clientInfo.Port}: {ex.Message}")
        End Try
    End Sub

    ' ================= Process RFID =================
    Private Sub ProcessRFIDScan(readerNumber As Integer, cardUID As String, clientInfo As ClientInfo)
        Try
            Dim student As StudentRecord = Nothing

            ' Check cache first
            If studentCache.ContainsKey(cardUID) Then
                student = studentCache(cardUID)
            Else
                ' DB lookup
                student = LoadStudent(cardUID)
                If student IsNot Nothing Then studentCache(cardUID) = student
            End If

            If student IsNot Nothing Then
                ' Update UI based on port and reader number
                UpdateUI(Sub()
                             If Not formIsDisposed Then
                                 ' Port 7070 = Gate 1
                                 If clientInfo.Port = 7070 Then
                                     Select Case readerNumber
                                         Case 1 : tbUDIGate1IN.Text = $"IN: {cardUID} (from {clientInfo.IPAddress})"
                                         Case 2 : tbUDIGate1OUT.Text = $"OUT: {cardUID} (from {clientInfo.IPAddress})"
                                         Case Else
                                             Debug.WriteLine($"Port 7070: Ignoring unknown reader number {readerNumber}")
                                     End Select
                                     ' Port 8080 = Gate 2
                                 ElseIf clientInfo.Port = 8080 Then
                                     Select Case readerNumber
                                         Case 1 : tbUDIGate2IN.Text = $"IN: {cardUID} (from {clientInfo.IPAddress})"
                                         Case 2 : tbUDIGate2OUT.Text = $"OUT: {cardUID} (from {clientInfo.IPAddress})"
                                         Case Else
                                             Debug.WriteLine($"Port 8080: Ignoring unknown reader number {readerNumber}")
                                     End Select
                                 Else
                                     Debug.WriteLine($"Unknown port {clientInfo.Port}: Ignoring reader number {readerNumber}")
                                 End If
                             End If
                         End Sub)

                ' Raise event based on port and reader number combination
                ' For port 7070 (Gate 1): reader 1 = Gate1 IN, reader 2 = Gate1 OUT
                ' For port 8080 (Gate 2): reader 1 = Gate2 IN, reader 2 = Gate2 OUT
                If clientInfo.Port = 7070 Then
                    Select Case readerNumber
                        Case 1 : RaiseEvent StudentScannedGate1(Me, student)
                        Case 2 : RaiseEvent StudentScannedGate2(Me, student)
                    End Select
                ElseIf clientInfo.Port = 8080 Then
                    Select Case readerNumber
                        Case 1 : RaiseEvent StudentScannedGate3(Me, student)
                        Case 2 : RaiseEvent StudentScannedGate4(Me, student)
                    End Select
                End If

                ' Approve card - send back the same reader number
                clientInfo.Writer.WriteLine($"OK{readerNumber}")
            Else
                clientInfo.Writer.WriteLine("UNKNOWN_CARD")
            End If
        Catch ex As Exception
            Debug.WriteLine($"Error processing RFID scan on port {clientInfo.Port}: {ex.Message}")
        End Try
    End Sub

    ' ================= Load Student from DB =================
    Private Function LoadStudent(rfid As String) As StudentRecord
        Try
            Using con As New SqlConnection(conString)
                con.Open()
                Dim query = "SELECT studId, FName, LName, Picture, Type, contactN FROM tblcombine WHERE rfid=@rfid"
                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@rfid", rfid)
                    Using reader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Dim student As New StudentRecord With {
                                .RFID = rfid,
                                .StudId = reader("studId").ToString(),
                                .FullName = $"{reader("LName")}, {reader("FName")}",
                                .Type = reader("Type").ToString(),
                                .ContactN = reader("contactN").ToString()
                            }

                            Dim imageBytes = If(IsDBNull(reader("Picture")), Nothing, CType(reader("Picture"), Byte()))
                            If imageBytes IsNot Nothing Then
                                Using ms As New MemoryStream(imageBytes)
                                    student.Picture = Image.FromStream(ms)
                                    student.Picture = New Bitmap(student.Picture)
                                End Using
                            End If
                            Return student
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Debug.WriteLine($"Error loading student: {ex.Message}")
        End Try
        Return Nothing
    End Function

    ' ================= Thread-safe UI Update =================
    Private Sub UpdateUI(action As Action)
        If formIsDisposed Then Return

        If InvokeRequired Then
            Try
                If Not formIsDisposed AndAlso IsHandleCreated AndAlso Not IsDisposed Then
                    Invoke(New MethodInvoker(Sub()
                                                 If Not formIsDisposed AndAlso Not IsDisposed Then
                                                     action()
                                                 End If
                                             End Sub))
                End If
            Catch ex As ObjectDisposedException
                formIsDisposed = True
            Catch ex As InvalidOperationException
                formIsDisposed = True
            Catch ex As Exception
                Debug.WriteLine($"Error in UI update: {ex.Message}")
            End Try
        Else
            If Not formIsDisposed AndAlso Not IsDisposed Then
                action()
            End If
        End If
    End Sub

    Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
        ' Set flag first
        formIsDisposed = True

        ' Stop server and clean up resources
        StopServer()

        ' Wait for server threads to finish
        If serverThread8080 IsNot Nothing AndAlso serverThread8080.IsAlive Then
            serverThread8080.Join(500) ' Wait up to 500ms
        End If

        If serverThread7070 IsNot Nothing AndAlso serverThread7070.IsAlive Then
            serverThread7070.Join(500) ' Wait up to 500ms
        End If

        MyBase.OnFormClosing(e)
    End Sub

    ' ================= Button Event Handlers =================
    Private Sub btnStartServer_Click(sender As Object, e As EventArgs) Handles btnStartServer.Click
        StartServer()
    End Sub

    Private Sub btnStopServer_Click(sender As Object, e As EventArgs) Handles btnStopServer.Click
        StopServer()
    End Sub


End Class