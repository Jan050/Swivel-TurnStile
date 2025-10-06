Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Threading.Tasks

Public Class FormStudentDetails

    Dim conString As String = ConfigurationManager.ConnectionStrings("Swivel_TurnStile.My.MySettings.MyDataBaseConnectionString").ConnectionString

    ' Convert Image to Byte array
    Private Function ImageToByte(img As Image) As Byte()
        Using ms As New IO.MemoryStream()
            img.Save(ms, Imaging.ImageFormat.Png)
            Return ms.ToArray()
        End Using
    End Function

    ' Async Save
    Private Async Sub bSave_Click(sender As Object, e As EventArgs) Handles bSave.Click
        Try

            ' Prepare image bytes asynchronously
            Dim imageBytes As Byte() = Nothing
            If PictureBox1.Image IsNot Nothing Then
                Dim resized As Image = ResizeImage(PictureBox1.Image, 320, 378)
                imageBytes = Await Task.Run(Function() ImageToByte(resized))
            End If

            Using con As New SqlConnection(conString)
                Await con.OpenAsync()

                Dim checkCmd As New SqlCommand("SELECT COUNT(*) FROM tblStudent WHERE studno = @studno", con)
                checkCmd.Parameters.AddWithValue("@studno", tbStudentNo.Text)
                Dim count As Integer = CInt(checkCmd.ExecuteScalar())

                If count > 0 Then
                    MsgBox("Student number already exists in the database. Please use a different student number.", vbExclamation)
                    con.Close()
                    Return
                End If

                Using cmd As New SqlCommand("sp_studentadd", con)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.AddWithValue("@studno", tbStudentNo.Text)
                    cmd.Parameters.AddWithValue("@lname", tbLastname.Text)
                    cmd.Parameters.AddWithValue("@fname", tbFirstname.Text)
                    cmd.Parameters.AddWithValue("@mname", tbMiddlename.Text)
                    cmd.Parameters.AddWithValue("@nameExt", cbNameExt.Text)
                    If Label1.Text = "Student ID" Then
                        cmd.Parameters.AddWithValue("@program", cbProgram.Text)
                    Else
                        cmd.Parameters.AddWithValue("@program", cbDepartment.Text)
                    End If
                    cmd.Parameters.AddWithValue("@address", tbAddress.Text)
                    cmd.Parameters.AddWithValue("@studimage", If(imageBytes, DBNull.Value))
                    cmd.Parameters.AddWithValue("@type", tbType.Text)

                    Await cmd.ExecuteNonQueryAsync()
                End Using
            End Using

            MsgBox("Record has been successfully saved", vbInformation)

            ' Append new row to DataGridView without reloading all
            AppendNewStudentToGrid()

            ClearFields()
            Me.Close()
            FormStudentList.Show()
            FormStudentList.BringToFront()

        Catch ex As SqlException
            If ex.Number = 2627 Then
                MsgBox("Student number already exists.", vbExclamation)
            Else
                MsgBox(ex.Message, vbCritical)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    ' Async Update
    ' Async Update
    Private Async Sub bUpdate_Click(sender As Object, e As EventArgs) Handles bUpdate.Click
        Try
            If MsgBox("Do you want to update this record?", vbYesNo) = vbYes Then
                ' Prepare image bytes asynchronously
                Dim imageBytes As Byte() = Nothing
                If PictureBox1.Image IsNot Nothing Then
                    Dim resized As Image = ResizeImage(PictureBox1.Image, 320, 378)
                    imageBytes = Await Task.Run(Function() ImageToByte(resized))
                End If

                Using con As New SqlConnection(conString)
                    Await con.OpenAsync()
                    Using cmd As New SqlCommand("sp_studentedit", con)
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.AddWithValue("@studno", tbStudentNo.Text)
                        cmd.Parameters.AddWithValue("@lname", tbLastname.Text)
                        cmd.Parameters.AddWithValue("@fname", tbFirstname.Text)
                        cmd.Parameters.AddWithValue("@mname", tbMiddlename.Text)
                        cmd.Parameters.AddWithValue("@nameExt", cbNameExt.Text)
                        cmd.Parameters.AddWithValue("@program", If(Label1.Text = "Student ID", cbProgram.Text, cbDepartment.Text))
                        cmd.Parameters.AddWithValue("@address", tbAddress.Text)
                        cmd.Parameters.AddWithValue("@studimage", If(imageBytes, DBNull.Value))
                        cmd.Parameters.AddWithValue("@type", tbType.Text)
                        Await cmd.ExecuteNonQueryAsync()
                    End Using
                End Using

                MsgBox("Record has been successfully updated", vbInformation)

                ' Update the row in DataGridView directly
                UpdateStudentRowInGrid()

                ClearFields()
                Me.Close()
                FormStudentList.Show()
                FormStudentList.BringToFront()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    ' Update the specific row in DataGridView without reloading all
    Private Sub UpdateStudentRowInGrid()
        Dim dgv As DataGridView = FormStudentList.DataGridView1
        For Each row As DataGridViewRow In dgv.Rows
            If row.Cells(0).Value?.ToString() = tbStudentNo.Text Then
                row.Cells(1).Value = tbLastname.Text
                row.Cells(2).Value = tbFirstname.Text
                row.Cells(3).Value = tbMiddlename.Text
                row.Cells(4).Value = cbNameExt.Text
                row.Cells(5).Value = If(Label1.Text = "Student ID", cbProgram.Text, cbDepartment.Text)
                row.Cells(6).Value = tbAddress.Text
                row.Cells(7).Value = PictureBox1.Image
                row.Cells(8).Value = tbType.Text

                ' Update image cache
                FormStudentList.imageCache(tbStudentNo.Text) = PictureBox1.Image
                Exit For
            End If
        Next
    End Sub

    ' Cancel operation
    Private Sub bCancel_Click(sender As Object, e As EventArgs) Handles bCancel.Click
        If MsgBox("Do you want to cancel this operation?", vbYesNo) = vbYes Then
            ClearFields()
            Me.Close()
            FormStudentList.Show()
            FormStudentList.BringToFront()
        End If
    End Sub

    ' Clear all input fields
    Private Sub ClearFields()
        tbAddress.Clear()
        tbFirstname.Clear()
        tbLastname.Clear()
        tbMiddlename.Clear()
        tbStudentNo.Clear()
        PictureBox1.Image = Nothing
        cbNameExt.Text = "<Select>"
        cbProgram.Text = "<Select>"
        cbDepartment.Text = "<Select>"
    End Sub

    ' Select Image
    Private Sub BSelectImage_Click(sender As Object, e As EventArgs) Handles BSelectImage.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
            PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        End If
    End Sub

    ' Resize image before saving
    Private Function ResizeImage(img As Image, maxWidth As Integer, maxHeight As Integer) As Image
        Dim ratioX As Double = maxWidth / img.Width
        Dim ratioY As Double = maxHeight / img.Height
        Dim ratio As Double = Math.Min(ratioX, ratioY)
        Dim newWidth As Integer = CInt(img.Width * ratio)
        Dim newHeight As Integer = CInt(img.Height * ratio)
        Dim newImg As New Bitmap(newWidth, newHeight)
        Using g As Graphics = Graphics.FromImage(newImg)
            g.DrawImage(img, 0, 0, newWidth, newHeight)
        End Using
        Return newImg
    End Function

    Private Sub AppendNewStudentToGrid()
        Dim dgv As DataGridView = FormStudentList.DataGridView1
        dgv.Rows.Add(tbStudentNo.Text, tbLastname.Text, tbFirstname.Text, tbMiddlename.Text,
                     cbNameExt.Text, If(Label1.Text = "Student ID", cbProgram.Text, cbDepartment.Text),
                     tbAddress.Text, PictureBox1.Image, tbType.Text)

        ' Optionally cache image
        FormStudentList.imageCache(tbStudentNo.Text) = PictureBox1.Image
    End Sub

End Class
