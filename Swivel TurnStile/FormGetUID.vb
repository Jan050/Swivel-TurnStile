Imports System.IO
Imports System.Net
Imports System.Net.Sockets

Public Class FormGetUID
    Private cardBuffer As String = ""
    Private lastKeyTime As DateTime = DateTime.Now
    Private Const READ_TIMEOUT_MS As Integer = 100 ' Time between keypresses to consider as new scan
    Public Property ParentRegistrationForm As FormRegistration
    Public Property ParentRegistrationForm2 As FormRegistration


    Private Sub FormRFIDReader_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True ' Critical for capturing key events
        lblStatus.Text = "Ready - Tap RFID Card"
        LogMessage("Application started. Tap RFID card to scan.")
    End Sub

    ' Capture ALL key presses (like Notepad does)
    Private Sub FormGetUID_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        ' Check if this is part of the same card scan or a new one
        If (DateTime.Now - lastKeyTime).TotalMilliseconds > READ_TIMEOUT_MS Then
            cardBuffer = "" ' Reset buffer if too much time between keys
        End If

        ' Store the key press
        cardBuffer += e.KeyChar
        lastKeyTime = DateTime.Now

        ' Check for complete scan (RFID readers typically send Enter after the ID)
        If e.KeyChar = ChrW(13) Then ' Enter key
            Dim decimalID As String = cardBuffer.TrimEnd(ChrW(13))
            ProcessCardData(decimalID)
            cardBuffer = ""
        End If
    End Sub

    Private Sub ProcessCardData(decimalID As String)
        Try
            ' Convert decimal string to hexadecimal (without 0x prefix)
            Dim decValue As Long = Long.Parse(decimalID)
            Dim hexValue As String = decValue.ToString("X") ' X formats as hex without prefix

            ' Display hex in card ID box (without 0x)
            txtCardID.Text = hexValue

            ' Log original decimal value
            LogMessage($"Card detected: {decimalID} (Hex: {hexValue})")

            System.Media.SystemSounds.Beep.Play()
        Catch ex As Exception
            LogMessage($"Error processing card: {ex.Message}")
        End Try
    End Sub

    Private Sub LogMessage(message As String)
        txtLog.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}{vbCrLf}")
        txtLog.SelectionStart = txtLog.TextLength
        txtLog.ScrollToCaret()
    End Sub

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        If Not String.IsNullOrEmpty(txtCardID.Text) Then
            ' Set the RFID textbox in the parent form
            If ParentRegistrationForm IsNot Nothing Then
                ParentRegistrationForm.tbRFIDno.Text = txtCardID.Text
                ParentRegistrationForm.tbRFIDNo2.Text = txtCardID.Text
            End If
            If ParentRegistrationForm2 IsNot Nothing Then
                ParentRegistrationForm2.tbRFIDNo2.Text = txtCardID.Text
            End If
            'Me.DialogResult = DialogResult.OK
            Me.Close()
        Else
            MessageBox.Show("No UID has been scanned yet.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        txtLog.Clear()
    End Sub


End Class