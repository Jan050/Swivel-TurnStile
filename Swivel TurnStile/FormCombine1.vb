Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Threading.Tasks

Public Class FormCombine1
    Private currentPage As Integer = 1
    Private pageSize As Integer = 20
    Private totalRecords As Integer = 0
    Private allFilteredRecords As New DataTable()
    Private imageCache As New Dictionary(Of String, Image)()
    Private lastSearchTerm As String = String.Empty
    Private loadingImages As New HashSet(Of String)()
    Private isInitialLoad As Boolean = True
    Private cancellationTokenSource As New Threading.CancellationTokenSource()

    ' UI Controls for pagination
    Private WithEvents btnFirst As New Button() With {.Text = "<<", .Width = 40, .FlatStyle = FlatStyle.Flat}
    Private WithEvents btnPrev As New Button() With {.Text = "<", .Width = 40, .FlatStyle = FlatStyle.Flat}
    Private lblPageInfo As New Label() With {.Text = "Page 1 of 1", .AutoSize = True}
    Private WithEvents btnNext As New Button() With {.Text = ">", .Width = 40, .FlatStyle = FlatStyle.Flat}
    Private WithEvents btnLast As New Button() With {.Text = ">>", .Width = 40, .FlatStyle = FlatStyle.Flat}
    Private lblRecords As New Label() With {.Text = "Records: 0", .AutoSize = True}

    Private Sub FormCombine1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Initialize pagination controls
            InitializePaginationControls()

            ' Load data in background to prevent UI freeze
            Task.Run(Sub()
                         UpdateTblCombine()
                         Me.Invoke(Sub() loaddata())
                     End Sub)
        Catch ex As Exception
            MessageBox.Show("An error occurred during form load: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub InitializePaginationControls()
        ' Create pagination panel
        Dim paginationPanel As New Panel()
        paginationPanel.Dock = DockStyle.Bottom
        paginationPanel.Height = 30
        paginationPanel.BackColor = Color.FromArgb(236, 240, 241)

        ' Position controls
        btnFirst.Location = New Point(10, 5)
        btnPrev.Location = New Point(60, 5)
        lblPageInfo.Location = New Point(110, 10)
        btnNext.Location = New Point(200, 5)
        btnLast.Location = New Point(250, 5)
        lblRecords.Location = New Point(300, 10)

        ' Add controls to panel
        paginationPanel.Controls.AddRange({btnFirst, btnPrev, lblPageInfo, btnNext, btnLast, lblRecords})

        ' Add panel to form
        Me.Controls.Add(paginationPanel)
        paginationPanel.BringToFront()
    End Sub

    Private Async Sub loaddata()
        Try
            cancellationTokenSource.Cancel()
            cancellationTokenSource = New Threading.CancellationTokenSource()

            If tbSearch.Text <> lastSearchTerm Then
                ClearImageCache()
                lastSearchTerm = tbSearch.Text
            End If

            DataGridView1.Visible = False
            Application.DoEvents()

            totalRecords = Await GetTotalRecordCountAsync()
            allFilteredRecords = Await GetPaginatedDataAsync()
            UpdatePaginationUI()

            DataGridView1.SuspendLayout()
            DataGridView1.Rows.Clear()

            For Each row As DataRow In allFilteredRecords.Rows
                Dim studentId As String = row("studId").ToString()
                DataGridView1.Rows.Add(
                    row("studId"), row("rfid"), row("LName"), row("FName"),
                    row("MName"), row("NameExt"), row("Program"), row("Address"),
                    row("contactP"), row("contactN"), Nothing, row("Type"))

                If imageCache.ContainsKey(studentId) Then
                    DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells(10).Value = imageCache(studentId)
                End If
            Next

            DataGridView1.ResumeLayout()
            DataGridView1.Visible = True

            If isInitialLoad Then
                tbSearch.Focus()
                isInitialLoad = False
            End If

        Catch ex As OperationCanceledException
        Catch ex As Exception
            MessageBox.Show("An error occurred while loading data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Async Function GetTotalRecordCountAsync() As Task(Of Integer)
        Using con As New SqlConnection(GetConnectionString())
            Await con.OpenAsync()
            Using cmd As New SqlCommand("SELECT COUNT(*) FROM tblCombine WHERE LName LIKE @SearchTerm OR FName LIKE @SearchTerm", con)
                cmd.Parameters.AddWithValue("@SearchTerm", If(String.IsNullOrEmpty(tbSearch.Text), "%", "%" & tbSearch.Text & "%"))
                Return Convert.ToInt32(Await cmd.ExecuteScalarAsync())
            End Using
        End Using
    End Function

    Private Async Function GetPaginatedDataAsync() As Task(Of DataTable)
        Dim dt As New DataTable()
        Using con As New SqlConnection(GetConnectionString())
            Await con.OpenAsync()
            Using cmd As New SqlCommand("SELECT studId, rfid, LName, FName, MName, NameExt, Program, Address, contactP, contactN, Type " &
                                        "FROM tblCombine WHERE LName LIKE @SearchTerm OR FName LIKE @SearchTerm " &
                                        "ORDER BY studId OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY", con)
                cmd.Parameters.AddWithValue("@SearchTerm", If(String.IsNullOrEmpty(tbSearch.Text), "%", "%" & tbSearch.Text & "%"))
                cmd.Parameters.AddWithValue("@Offset", (currentPage - 1) * pageSize)
                cmd.Parameters.AddWithValue("@PageSize", pageSize)

                Using adapter As New SqlDataAdapter(cmd)
                    Await Task.Run(Sub() adapter.Fill(dt))
                End Using
            End Using
        End Using
        Return dt
    End Function

    Private Sub UpdatePaginationUI()
        Dim totalPages As Integer = If(totalRecords > 0, Math.Ceiling(totalRecords / pageSize), 1)
        lblPageInfo.Text = $"Page {currentPage} of {totalPages}"
        lblRecords.Text = $"Records: {totalRecords}"

        btnFirst.Enabled = currentPage > 1
        btnPrev.Enabled = currentPage > 1
        btnNext.Enabled = currentPage < totalPages
        btnLast.Enabled = currentPage < totalPages
    End Sub

    ' Pagination handlers
    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        currentPage = 1
        loaddata()
    End Sub

    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        If currentPage > 1 Then
            currentPage -= 1
            loaddata()
        End If
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Dim totalPages As Integer = Math.Ceiling(totalRecords / pageSize)
        If currentPage < totalPages Then
            currentPage += 1
            loaddata()
        End If
    End Sub

    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        Dim totalPages As Integer = Math.Ceiling(totalRecords / pageSize)
        currentPage = totalPages
        loaddata()
    End Sub

    ' Lazy load images when cell becomes visible
    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        If e.ColumnIndex = 10 AndAlso e.Value Is Nothing Then ' Image column
            Dim row = DataGridView1.Rows(e.RowIndex)
            Dim studentId As String = row.Cells(0).Value?.ToString()

            If Not String.IsNullOrEmpty(studentId) Then
                ' Only load if not already cached and not currently loading
                If Not imageCache.ContainsKey(studentId) AndAlso Not loadingImages.Contains(studentId) Then
                    loadingImages.Add(studentId)
                    Task.Run(Sub() LoadImageAsync(studentId, e.RowIndex, cancellationTokenSource.Token))
                End If
            End If
        End If
    End Sub

    Private Sub LoadImageAsync(studentId As String, rowIndex As Integer, cancellationToken As Threading.CancellationToken)
        Try
            ' Check for cancellation before starting
            cancellationToken.ThrowIfCancellationRequested()

            Using con As New SqlConnection(GetConnectionString())
                con.Open()
                Using cmd As New SqlCommand("SELECT Picture FROM tblStudent WHERE StudNo = @studId", con)
                    cmd.Parameters.AddWithValue("@studId", studentId)
                    Dim imageBytes As Object = cmd.ExecuteScalar()

                    ' Check for cancellation after database call
                    cancellationToken.ThrowIfCancellationRequested()

                    If imageBytes IsNot Nothing AndAlso Not IsDBNull(imageBytes) Then
                        Using ms As New IO.MemoryStream(DirectCast(imageBytes, Byte()))
                            Dim img As Image = Image.FromStream(ms)

                            ' Check for cancellation after loading image
                            cancellationToken.ThrowIfCancellationRequested()

                            Me.Invoke(Sub()
                                          ' Add to cache if not already there
                                          If Not imageCache.ContainsKey(studentId) Then
                                              imageCache.Add(studentId, img)
                                          End If

                                          ' Update the specific row if it's still visible
                                          If rowIndex < DataGridView1.Rows.Count AndAlso Not DataGridView1.Rows(rowIndex).IsNewRow Then
                                              If DataGridView1.Rows(rowIndex).Cells(0).Value?.ToString() = studentId Then
                                                  DataGridView1.Rows(rowIndex).Cells(10).Value = img
                                              End If
                                          End If

                                          ' Remove from loading set
                                          loadingImages.Remove(studentId)
                                      End Sub)
                        End Using
                    Else
                        ' No image found, remove from loading set
                        Me.Invoke(Sub() loadingImages.Remove(studentId))
                    End If
                End Using
            End Using
        Catch ex As OperationCanceledException
            ' Task was cancelled, remove from loading set
            Me.Invoke(Sub() loadingImages.Remove(studentId))
        Catch ex As Exception
            ' Handle errors and ensure we remove from loading set
            Me.Invoke(Sub()
                          loadingImages.Remove(studentId)
                          Debug.WriteLine($"Error loading image for student {studentId}: {ex.Message}")
                      End Sub)
        End Try
    End Sub

    Private Sub UpdateTblCombine()
        Try
            Using con As New SqlConnection(GetConnectionString())
                con.Open()

                ' Clear existing data with longer timeout
                Using cmd As New SqlCommand("DELETE FROM tblcombine", con)
                    cmd.CommandTimeout = 300 ' 5 minutes instead of default 30 seconds
                    cmd.ExecuteNonQuery()
                End Using

                ' Insert new data with longer timeout
                Using cmd As New SqlCommand("INSERT INTO tblcombine (studId, rfid, LName, FName, MName, NameExt, Program, Address, contactP, contactN, Picture, Type) " &
                                     "SELECT tblStudent.StudNo AS studId, tblRegistered.rfld, tblStudent.LName, tblStudent.FName, tblStudent.MName, " &
                                     "tblStudent.NameExt, tblStudent.Program, tblStudent.Address, tblRegistered.contactP, tblRegistered.contactN, tblStudent.Picture, tblStudent.Type " &
                                     "FROM tblStudent INNER JOIN tblRegistered ON tblStudent.StudNo = tblRegistered.studId", con)
                    cmd.CommandTimeout = 300 ' 5 minutes
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("An error occurred while updating tblCombine: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub tbSearch_TextChanged(sender As Object, e As EventArgs) Handles tbSearch.TextChanged
        ' Add a small delay to prevent rapid queries while typing
        Static lastText As String = ""
        Static timer As New Timer() With {.Interval = 500}

        If tbSearch.Text <> lastText Then
            lastText = tbSearch.Text
            timer.Stop()
            timer.Start()
        End If

        AddHandler timer.Tick, Sub()
                                   timer.Stop()
                                   currentPage = 1
                                   loaddata()
                               End Sub
    End Sub

    Private Sub ClearImageCache()
        For Each img In imageCache.Values
            img.Dispose()
        Next
        imageCache.Clear()
        loadingImages.Clear()
    End Sub

    Private Function GetConnectionString() As String
        Return ConfigurationManager.ConnectionStrings("Swivel_TurnStile.My.MySettings.MyDataBaseConnectionString").ConnectionString
    End Function

    ' Clean up resources when form closes
    Private Sub FormCombine1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        cancellationTokenSource.Cancel()
        ClearImageCache()
    End Sub
End Class