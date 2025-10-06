Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Threading.Tasks

Public Class FormStudentList
    Private currentPage As Integer = 1
    Private pageSize As Integer = 10
    Private totalRecords As Integer = 0
    Private allFilteredRecords As New DataTable()
    Public imageCache As New Dictionary(Of String, Image)()
    Private lastSearchTerm As String = String.Empty

    ' Read connection string from app.config
    Dim conString As String = ConfigurationManager.ConnectionStrings("Swivel_TurnStile.My.MySettings.MyDataBaseConnectionString").ConnectionString

    ' Cancellation token for async tasks
    Private cts As Threading.CancellationTokenSource = New Threading.CancellationTokenSource()

    ' Fully async load records
    Public Async Function LoadRecordsAsync() As Task
        Try
            ' Cancel previous image loading tasks if search term changed
            cts.Cancel()
            cts = New Threading.CancellationTokenSource()

            If tstSearchHere.Text <> lastSearchTerm Then
                ClearImageCache()
                lastSearchTerm = tstSearchHere.Text
            End If

            Dim dt As New DataTable()

            ' Get all filtered records asynchronously
            Using con As New SqlConnection(conString)
                Await con.OpenAsync()
                Using cmd As New SqlCommand("SELECT StudNo, LName, FName, MName, NameExt, Program, Address, Type FROM tblStudent " &
                                             "WHERE LName LIKE @SearchTerm OR StudNo LIKE @SearchTerm", con)
                    cmd.Parameters.AddWithValue("@SearchTerm", "%" & tstSearchHere.Text & "%")

                    Using adapter As New SqlDataAdapter(cmd)
                        Await Task.Run(Sub() adapter.Fill(dt))
                    End Using
                End Using
            End Using

            ' Assign to global DataTable and count records
            allFilteredRecords = dt
            totalRecords = dt.Rows.Count

            ' Pagination calculations
            Dim totalPages As Integer = Math.Ceiling(totalRecords / pageSize)
            currentPage = Math.Min(Math.Max(currentPage, 1), Math.Max(totalPages, 1))

            ' Update UI labels
            lblPageInfo.Text = $"Page {currentPage} of {totalPages}"
            lblRecordCount.Text = $"Total Records: {totalRecords}"
            btnFirst.Enabled = currentPage > 1
            btnPrev.Enabled = currentPage > 1
            btnNext.Enabled = currentPage < totalPages
            btnLast.Enabled = currentPage < totalPages

            ' Load current page rows
            DataGridView1.Rows.Clear()
            Dim startIndex As Integer = (currentPage - 1) * pageSize
            Dim endIndex As Integer = Math.Min(startIndex + pageSize - 1, totalRecords - 1)

            For i As Integer = startIndex To endIndex
                Dim row As DataRow = allFilteredRecords.Rows(i)
                Dim studentId As String = row(0).ToString()

                ' Add row with placeholder for image
                DataGridView1.Rows.Add(row(0), row(1), row(2), row(3), row(4), row(5), row(6), Nothing, row(7))

                ' Load cached image if available
                If imageCache.ContainsKey(studentId) Then
                    DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells(7).Value = imageCache(studentId)
                End If
            Next

            ' Optionally, preload all images for visible page asynchronously
            Await Task.WhenAll(Enumerable.Range(startIndex, endIndex - startIndex + 1).Select(Function(i)
                                                                                                  Dim sId As String = allFilteredRecords.Rows(i)(0).ToString()
                                                                                                  If Not imageCache.ContainsKey(sId) Then
                                                                                                      Return LoadImageAsync(sId, cts.Token)
                                                                                                  Else
                                                                                                      Return Task.CompletedTask
                                                                                                  End If
                                                                                              End Function))

        Catch ex As Exception
            MessageBox.Show("Error loading records: " & ex.Message)
        End Try
    End Function

    ' Async image loading with cancellation support
    Private Async Function LoadImageAsync(studentId As String, token As Threading.CancellationToken) As Task
        Try
            Using con As New SqlConnection(conString)
                Await con.OpenAsync(token)
                Using cmd As New SqlCommand("SELECT Picture FROM tblStudent WHERE StudNo = @StudNo", con)
                    cmd.Parameters.AddWithValue("@StudNo", studentId)
                    Dim imageBytesObj As Object = Await cmd.ExecuteScalarAsync(token)

                    If imageBytesObj IsNot Nothing AndAlso Not IsDBNull(imageBytesObj) Then
                        Dim imageBytes As Byte() = DirectCast(imageBytesObj, Byte())
                        Using ms As New IO.MemoryStream(imageBytes)
                            Dim img As Image = Image.FromStream(ms)

                            ' Add to cache and update UI on main thread
                            If Not imageCache.ContainsKey(studentId) Then
                                imageCache.Add(studentId, img)
                            End If

                            Me.Invoke(Sub()
                                          For Each row As DataGridViewRow In DataGridView1.Rows
                                              If row.IsNewRow Then Continue For
                                              If row.Cells(0).Value?.ToString() = studentId Then
                                                  row.Cells(7).Value = img
                                                  Exit For
                                              End If
                                          Next
                                      End Sub)
                        End Using
                    End If
                End Using
            End Using
        Catch ex As OperationCanceledException
            ' Task was cancelled, safe to ignore
        Catch ex As Exception
            ' Optional: log errors
        End Try
    End Function

    Private Sub ClearImageCache()
        For Each img In imageCache.Values
            img.Dispose()
        Next
        imageCache.Clear()
    End Sub

    ' Load records on form load
    Private Async Sub FormStudentList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Await LoadRecordsAsync()
    End Sub

    ' Search textbox changed
    Private Async Sub tstSearchHere_TextChanged(sender As Object, e As EventArgs) Handles tstSearchHere.TextChanged
        currentPage = 1
        Await LoadRecordsAsync()
    End Sub

    ' Pagination handlers
    Private Async Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        currentPage = 1
        Await LoadRecordsAsync()
    End Sub

    Private Async Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        If currentPage > 1 Then
            currentPage -= 1
            Await LoadRecordsAsync()
        End If
    End Sub

    Private Async Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Dim totalPages As Integer = Math.Ceiling(totalRecords / pageSize)
        If currentPage < totalPages Then
            currentPage += 1
            Await LoadRecordsAsync()
        End If
    End Sub

    Private Async Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        Dim totalPages As Integer = Math.Ceiling(totalRecords / pageSize)
        currentPage = totalPages
        Await LoadRecordsAsync()
    End Sub

    Private Async Sub cmbPageSize_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPageSize.SelectedIndexChanged
        pageSize = Integer.Parse(cmbPageSize.SelectedItem.ToString())
        currentPage = 1
        Await LoadRecordsAsync()
    End Sub

    ' Opens student form for adding a new student
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        With FormStudentDetails
            Me.Close()
            .cbProgram.BringToFront()
            .tbType.Text = "Student"
            .bUpdate.Enabled = False
            .bSave.Enabled = True
            .Show()
        End With
    End Sub

    ' Edit selected student/employee
    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Datagrid() ' Corrected call to your method
    End Sub

    ' Delete selected student/employee
    Private Async Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        If DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a record to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim selectedRow As DataGridViewRow = DataGridView1.SelectedRows(0)
            Dim studId As String = selectedRow.Cells(0).Value.ToString()

            Try
                Using con As New SqlConnection(conString)
                    Await con.OpenAsync()
                    Using cmd As New SqlCommand("DELETE FROM tblStudent WHERE StudNo = @studno", con)
                        cmd.Parameters.AddWithValue("@studno", studId)
                        Await cmd.ExecuteNonQueryAsync()
                    End Using
                End Using

                MessageBox.Show("Record deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Await LoadRecordsAsync()
            Catch ex As Exception
                MessageBox.Show("Error deleting record: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    ' Opens employee form for adding a new employee
    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        With FormStudentDetails
            Me.Close()
            .Label1.Text = "Faculty ID"
            .tbType.Text = "Employee"
            .cbDepartment.BringToFront()
            .bUpdate.Enabled = False
            .bSave.Enabled = True
            .Show()
        End With
    End Sub

    ' Open selected row in FormStudentDetails
    Private Sub Datagrid()
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = DataGridView1.SelectedRows(0)
            Dim newform As New FormStudentDetails()

            newform.tbStudentNo.Text = selectedRow.Cells(0).Value.ToString()
            newform.tbLastname.Text = selectedRow.Cells(1).Value.ToString()
            newform.tbFirstname.Text = selectedRow.Cells(2).Value.ToString()
            newform.tbMiddlename.Text = selectedRow.Cells(3).Value.ToString()
            newform.cbNameExt.Text = selectedRow.Cells(4).Value.ToString()
            newform.cbProgram.Text = selectedRow.Cells(5).Value.ToString()
            newform.tbAddress.Text = selectedRow.Cells(6).Value.ToString()
            newform.tbType.Text = selectedRow.Cells(8).Value.ToString()

            If selectedRow.Cells(7).Value IsNot Nothing Then
                newform.PictureBox1.Image = CType(selectedRow.Cells(7).Value, Image)
            Else
                newform.PictureBox1.Image = Nothing
            End If

            newform.PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
            newform.bUpdate.Enabled = True
            newform.bSave.Enabled = False
            newform.tbStudentNo.Enabled = False
            Me.Close()
            newform.Show()
        Else
            MessageBox.Show("Please select a row first.")
        End If
    End Sub
End Class
