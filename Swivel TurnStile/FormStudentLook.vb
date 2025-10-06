Imports System.Data.SqlClient

Public Class FormStudentLook
    Public Property ParentFormRegistration As FormRegistration
    Private currentPage As Integer = 1
    Private pageSize As Integer = 20
    Private totalRecords As Integer = 0
    Private allFilteredRecords As New DataTable()
    Private lastSearchTerm As String = String.Empty

    Private Sub FormStudentLook_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize pagination controls
        InitializePaginationControls()
        loaddata()
    End Sub

    Private Sub InitializePaginationControls()
        ' Add pagination controls to Panel1
        Dim paginationPanel As New Panel()
        paginationPanel.Dock = DockStyle.Bottom
        paginationPanel.Height = 30
        paginationPanel.BackColor = Color.FromArgb(0, 51, 0)

        ' Add buttons and labels
        Dim btnFirst As New Button() With {.Text = "<<", .Width = 40}
        Dim btnPrev As New Button() With {.Text = "<", .Width = 40}
        Dim lblPageInfo As New Label() With {.Text = "Page 1 of 1", .ForeColor = Color.White, .AutoSize = True}
        Dim btnNext As New Button() With {.Text = ">", .Width = 40}
        Dim btnLast As New Button() With {.Text = ">>", .Width = 40}
        Dim lblRecords As New Label() With {.Text = "Records: 0", .ForeColor = Color.White, .AutoSize = True}

        ' Position controls
        btnFirst.Location = New Point(10, 5)
        btnPrev.Location = New Point(60, 5)
        lblPageInfo.Location = New Point(110, 10)
        btnNext.Location = New Point(200, 5)
        btnLast.Location = New Point(250, 5)
        lblRecords.Location = New Point(300, 10)

        ' Add handlers
        AddHandler btnFirst.Click, AddressOf BtnFirst_Click
        AddHandler btnPrev.Click, AddressOf BtnPrev_Click
        AddHandler btnNext.Click, AddressOf BtnNext_Click
        AddHandler btnLast.Click, AddressOf BtnLast_Click

        ' Add controls to panel
        paginationPanel.Controls.AddRange({btnFirst, btnPrev, lblPageInfo, btnNext, btnLast, lblRecords})

        ' Add panel to form
        Me.Panel1.Controls.Add(paginationPanel)
        paginationPanel.BringToFront()
    End Sub

    Sub loaddata()
        Try
            ' Update last search term
            If tbSHere.Text <> lastSearchTerm Then
                lastSearchTerm = tbSHere.Text
            End If

            ' Get all filtered records
            Using con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\MyDataBase.mdf;Integrated Security=True")
                con.Open()
                Using cmd As New SqlCommand("SELECT COUNT(*) FROM tblStudent WHERE LName LIKE @SearchTerm OR FName LIKE @SearchTerm", con)
                    cmd.Parameters.AddWithValue("@SearchTerm", "%" & tbSHere.Text & "%")
                    totalRecords = Convert.ToInt32(cmd.ExecuteScalar())
                End Using

                ' Get paginated data (without images)
                Using cmd As New SqlCommand("SELECT StudNo, LName, FName, MName, NameExt, Program, Address, Type FROM tblStudent " &
                                         "WHERE LName LIKE @SearchTerm OR FName LIKE @SearchTerm " &
                                         "ORDER BY StudNo OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY", con)
                    cmd.Parameters.AddWithValue("@SearchTerm", "%" & tbSHere.Text & "%")
                    cmd.Parameters.AddWithValue("@Offset", (currentPage - 1) * pageSize)
                    cmd.Parameters.AddWithValue("@PageSize", pageSize)

                    Using adapter As New SqlDataAdapter(cmd)
                        allFilteredRecords.Clear()
                        adapter.Fill(allFilteredRecords)
                    End Using
                End Using
            End Using

            ' Update pagination UI
            Dim totalPages As Integer = If(totalRecords > 0, Math.Ceiling(totalRecords / pageSize), 1)
            Dim paginationPanel = Panel1.Controls.OfType(Of Panel)().FirstOrDefault()
            If paginationPanel IsNot Nothing Then
                Dim lblPageInfo = paginationPanel.Controls.OfType(Of Label)().FirstOrDefault(Function(l) l.Text.StartsWith("Page"))
                Dim lblRecords = paginationPanel.Controls.OfType(Of Label)().FirstOrDefault(Function(l) l.Text.StartsWith("Records"))

                If lblPageInfo IsNot Nothing Then lblPageInfo.Text = $"Page {currentPage} of {totalPages}"
                If lblRecords IsNot Nothing Then lblRecords.Text = $"Records: {totalRecords}"

                ' Enable/disable navigation buttons
                For Each ctrl In paginationPanel.Controls
                    If TypeOf ctrl Is Button Then
                        Dim btn = DirectCast(ctrl, Button)
                        Select Case btn.Text
                            Case "<<", "<"
                                btn.Enabled = currentPage > 1
                            Case ">", ">>"
                                btn.Enabled = currentPage < totalPages
                        End Select
                    End If
                Next
            End If

            ' Load current page data
            DataGridView3.Rows.Clear()
            For Each row As DataRow In allFilteredRecords.Rows
                DataGridView3.Rows.Add(row(0), row(1), row(2), row(3), row(4), row(5), row(6), row(7))
            Next

        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message)
        End Try
    End Sub

    ' Pagination handlers
    Private Sub BtnFirst_Click(sender As Object, e As EventArgs)
        currentPage = 1
        loaddata()
    End Sub

    Private Sub BtnPrev_Click(sender As Object, e As EventArgs)
        If currentPage > 1 Then
            currentPage -= 1
            loaddata()
        End If
    End Sub

    Private Sub BtnNext_Click(sender As Object, e As EventArgs)
        Dim totalPages As Integer = Math.Ceiling(totalRecords / pageSize)
        If currentPage < totalPages Then
            currentPage += 1
            loaddata()
        End If
    End Sub

    Private Sub BtnLast_Click(sender As Object, e As EventArgs)
        Dim totalPages As Integer = Math.Ceiling(totalRecords / pageSize)
        currentPage = totalPages
        loaddata()
    End Sub

    ' Existing methods remain the same
    Private Sub BSubmit_Click(sender As Object, e As EventArgs) Handles BSubmit.Click
        If DataGridView3.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = DataGridView3.SelectedRows(0)
            Dim newform As New FormRegistration
            newform.tbStudentId.Text = selectedRow.Cells(0).Value.ToString()
            Dim LName As String = selectedRow.Cells(1).Value.ToString()
            Dim FName As String = selectedRow.Cells(2).Value.ToString()
            newform.tbStudName.Text = $"{FName} {LName}"
            newform.BLook.Enabled = True
            newform.tbStudentId.Enabled = False
            newform.bUpdate.Enabled = False
            newform.BSave2.Enabled = True
            newform.Panel1.BringToFront()
            newform.Show()
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Else
            MessageBox.Show("Please select a row first.")
        End If
    End Sub

    Private Sub TbSHere_TextChanged(sender As Object, e As EventArgs) Handles tbSHere.TextChanged
        currentPage = 1
        loaddata()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
    End Sub
End Class