Imports System.Data.SqlClient

Public Class FormRegister




    Sub loadRecords4()

        Try
            DataGridView2.Rows.Clear()

            con.Open()
            cmd = New SqlCommand("SELECT * FROM tblRegistered WHERE studId LIKE @SearchTerm", con)
            cmd.Parameters.AddWithValue("@SearchTerm", "%" & tbsearch.Text() & "%")
            dr = cmd.ExecuteReader()

            ' Loop through all rows
            While dr.Read()
                DataGridView2.Rows.Add(dr.Item(0), dr.Item(1), dr.Item(2), dr.Item(3))
            End While

            dr.Close()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally

            If dr IsNot Nothing AndAlso Not dr.IsClosed Then
                dr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
        ' Set the default cell style for the DataGridView
        DataGridView2.RowsDefaultCellStyle.BackColor = Color.FromArgb(236, 240, 241)

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click

        Dim frmReg As New FormRegistration()  ' Create NEW instance
        'frmReg.ParentFormRegister = Me        ' Set parent to FormRegister
        'Me.WindowState = FormWindowState.Minimized
        Me.Close()
        frmReg.bSave.Enabled = True
        frmReg.bUpdate.Enabled = False
        frmReg.Panel1.BringToFront()
        frmReg.Show()



    End Sub


    Private Sub FormRegister_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadRecords4()
    End Sub

    Private Sub tbsearch_Click(sender As Object, e As EventArgs) Handles tbsearch.TextChanged
        loadRecords4()
    End Sub



    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click

        datagrid2()

    End Sub

    Dim formreg As New FormRegistration

    Sub datagrid2()



        If DataGridView2.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = DataGridView2.SelectedRows(0)

            Dim formreg As New FormRegistration

            'formreg.tbStudentId.Text = selectedRow.Cells(0).Value.ToString()
            'formreg.tbRFIDno.Text = selectedRow.Cells(1).Value.ToString()
            'formreg.tbContactP.Text = selectedRow.Cells(2).Value.ToString()
            'formreg.tbContactN.Text = selectedRow.Cells(3).Value.ToString()
            formreg.tbStudentId2.Text = selectedRow.Cells(0).Value.ToString()
            formreg.tbRFIDNo2.Text = selectedRow.Cells(1).Value.ToString()
            formreg.tbContactP2.Text = selectedRow.Cells(2).Value.ToString()
            formreg.tbContactN2.Text = selectedRow.Cells(3).Value.ToString()
            formreg.bUpdate.Enabled = True
            formreg.BSave2.Enabled = False
            formreg.tbStudentId2.Enabled = False
            ' Show FormStudentDetails
            formreg.Panel3.BringToFront()
            formreg.Show()
            Me.Hide()



        Else
            MsgBox("Please select a row first")

        End If

    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click

        ' Check if a row is selected
        If DataGridView2.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a record to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Confirm deletion
        If MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            Try
                Dim selectedRow As DataGridViewRow = DataGridView2.SelectedRows(0)
                Dim studId As String = selectedRow.Cells(0).Value.ToString() ' Assuming column 0 is StudentID

                con.Open()
                cmd = New SqlCommand("DELETE FROM tblRegistered WHERE studId like @studid", con)
                cmd.Parameters.AddWithValue("@studid", studId)
                cmd.ExecuteNonQuery()
                MessageBox.Show("Record deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Refresh the DataGridView
                con.Close()
                loadRecords4()

            Catch ex As Exception
                MessageBox.Show("Error deleting record: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
            End Try

        End If
    End Sub

End Class