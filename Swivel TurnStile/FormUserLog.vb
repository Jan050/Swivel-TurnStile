Imports System.Data.SqlClient

Public Class FormUserLog





    Private Sub FormLoginLogs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            LoadLoginLogs()
        End Sub

    Private Sub LoadLoginLogs()
        Try
            ' Clear existing data
            dgvLogs.Rows.Clear()

            ' Initialize row counter
            Dim rowCount As Integer = 0

            con.Open()
            cmd = New SqlCommand("SELECT Username, FORMAT(LoginTime, 'yyyy-MM-dd HH:mm:ss') AS LoginTime " &
                            "FROM DailyLoginLogs ORDER BY LoginTime DESC", con)
            dr = cmd.ExecuteReader()

            While dr.Read()
                dgvLogs.Rows.Add(dr.Item(0), dr.Item(1))
                rowCount += 1 ' Increment counter for each row
            End While

            ' Update record count display
            If lblRecordCount IsNot Nothing Then
                lblRecordCount.Text = $"{rowCount} records found"
            End If

            dr.Close()
        Catch ex As Exception
            MessageBox.Show($"Error loading login logs: {ex.Message}", "Error",
                      MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If con.State = ConnectionState.Open Then con.Close()
        End Try
    End Sub
    'Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
    ' LoadLoginLogs()
    ' nd Sub()

    ' Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
    'Me.Close()
    'End Sub



    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        With FormUser
            Me.Close()
            .ShowDialog()

        End With
    End Sub



End Class