Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel
Imports System.Data.SqlClient

Public Class FormLogin

    Dim mainForm As New FormMain()

    Private Sub LogSuccessfulLogin(username As String)
        Try
            Using connection As New SqlConnection(con.ConnectionString)
                connection.Open()

                Dim cmdText As String = "INSERT INTO DailyLoginLogs (Username) VALUES (@username)"
                Using cmd As New SqlCommand(cmdText, connection)
                    cmd.Parameters.AddWithValue("@username", username)
                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        ' Successfully logged the login
                        Debug.WriteLine($"Successfully logged login for {username}")
                    Else
                        ' Logging failed
                        LogToFile($"Failed to log login for {username}")
                    End If
                End Using
            End Using
        Catch ex As Exception
            LogToFile($"Error logging login for {username}: {ex.Message}")
        End Try
    End Sub

    Private Sub LogToFile(message As String)
        Try
            Dim logPath As String = Path.Combine(Application.StartupPath, "LoginErrorLog.txt")
            Dim logMessage As String = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}{Environment.NewLine}"
            File.AppendAllText(logPath, logMessage)
        Catch
            ' If file logging fails, there's not much we can do
        End Try
    End Sub

    Private Sub BLogin_Click(sender As Object, e As EventArgs) Handles bLogin.Click
        Try
            Using connection As New SqlConnection(con.ConnectionString)
                connection.Open()

                Using cmd As New SqlCommand("splogin", connection)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@user", tbUsername.Text)
                    cmd.Parameters.AddWithValue("@pass", tbPassword.Text)
                    cmd.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output
                    cmd.Parameters.Add("@acctype", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output
                    cmd.ExecuteNonQuery()

                    Dim loginResult As Integer = CInt(cmd.Parameters("@result").Value)
                    Dim accountType As String = If(cmd.Parameters("@acctype").Value Is DBNull.Value, "", cmd.Parameters("@acctype").Value.ToString())

                    If loginResult = 1 Then
                        ' Record successful login - moved before any UI changes
                        LogSuccessfulLogin(tbUsername.Text)

                        ' Check if account type is "guard"
                        If accountType.ToLower() = "guard" Then
                            MsgBox("Access Granted", vbInformation)
                            username = tbUsername.Text
                            password = tbPassword.Text

                            Me.Hide()
                            GetUserName()
                            FormAttendance.Show()
                        Else
                            MsgBox("Access Granted", vbInformation)
                            username = tbUsername.Text
                            password = tbPassword.Text

                            Me.Hide()
                            GetUserName()

                            ' Create a new instance of FormMain
                            mainForm.Dashboard.Enabled = True
                            mainForm.LblUser.Text = fullname ' Set the fullname in FormMain
                            mainForm.Show() ' Show FormMain as a dialog
                        End If
                    Else
                        MsgBox("Access Denied. Invalid username or password", vbCritical)
                    End If
                End Using
            End Using
        Catch ex As Exception
            LogToFile($"Login error: {ex.Message}")
            MsgBox($"Login error: {ex.Message}", vbCritical)
        End Try
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connection() ' Initialize the connection
    End Sub

    Private Sub BCancel_Click(sender As Object, e As EventArgs) Handles bCancel.Click
        If MsgBox("Are you sure you want to exit?", vbQuestion + vbYesNo, "Exit") = vbYes Then
            Application.Exit()
        End If
    End Sub

    Private Sub Panel1_KeyDown(sender As Object, e As KeyEventArgs) Handles tbPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            bLogin.PerformClick() ' Trigger the login button click event
        End If
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        ' Your existing code here
    End Sub
End Class