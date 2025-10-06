Imports System.Timers
Imports System.Security.Cryptography
Imports System.Text
Imports System.Data.SqlClient

Public Class FormUser

    Dim oldpass As String

    ' Function to convert an image to a byte array


    Private Sub ButtonSave_Click(sender As Object, e As EventArgs) Handles bSave.Click
        If tbConPass1.Text <> tbPassword1.Text Then
            MsgBox("Password not match", vbExclamation)
            Return

        End If

        Try

            con.Open()
            Dim imageBytes As Byte() = ImageToByte(PictureBox1.Image)
            With cmd
                .Connection = con
                .CommandType = CommandType.StoredProcedure
                .CommandText = "sp_useradd"
                .Parameters.Clear()
                .Parameters.AddWithValue("@username", tbUsername1.Text)
                .Parameters.AddWithValue("@password", tbPassword1.Text)
                .Parameters.AddWithValue("@name", tbFullname1.Text)
                .Parameters.AddWithValue("@accType", cbAccType1.Text)
                If imageBytes Is Nothing Then
                    .Parameters.AddWithValue("@userImage", DBNull.Value) ' Handle null image
                Else
                    .Parameters.AddWithValue("@userImage", imageBytes)
                End If
                .ExecuteNonQuery()
            End With
            con.Close()
            MsgBox("Account has been successfully created.", vbInformation)
            Me.Close()
            FormUserLog.Show()
            FormUserLog.BringToFront()

        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, vbCritical)

        End Try
        ClearFields()
    End Sub

    Sub ClearFields()
        tbConPass1.Clear()
        tbFullname1.Clear()
        tbPassword1.Clear()
        tbUsername1.Clear()
        cbAccType1.Text = "<Select>"
        PictureBox1.Image = Nothing
        tbConPass2.Clear()
        tbFullname2.Clear()
        tbNewPass.Clear()
        tbUsername2.Clear()
        tbOldPass.Clear()
        cbAccType2.Text = "<Select>"
    End Sub

    Private Sub tbUsername2_TextChange(sender As Object, e As EventArgs) Handles tbUsername2.TextChanged

        con.Open()
        cmd = New SqlCommand("SELECT * from tblUser where username like '" & tbUsername2.Text & "'", con)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            tbFullname2.Text = dr.Item("fullname")
            oldpass = dr.Item("password")
            ' Fetch and display the existing image
            If Not IsDBNull(dr("image")) Then
                Dim imageBytes As Byte() = CType(dr("image"), Byte())
                PictureBox2.Image = ByteToImage(imageBytes)
                PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
            Else
                PictureBox2.Image = Nothing
            End If

            tbFullname2.Enabled = True
            tbConPass2.Enabled = True
            tbNewPass.Enabled = True
            tbOldPass.Enabled = True
            cbAccType2.Enabled = True

        Else
            tbFullname2.Enabled = False
            tbConPass2.Enabled = False
            tbNewPass.Enabled = False
            tbOldPass.Enabled = False
            cbAccType2.Enabled = False
            tbFullname2.Clear()
            oldpass = ""

        End If
        dr.Close()
        con.Close()

        If dr IsNot Nothing AndAlso Not dr.IsClosed Then
            dr.Close()
        End If

    End Sub


    Private Sub bUpdate_Click(sender As Object, e As EventArgs) Handles bUpdate.Click
        Try

            If tbOldPass.Text <> oldpass Then
                MsgBox("Old password did not match with the password", vbExclamation)
                Return
            End If
            If tbConPass2.Text <> tbNewPass.Text Then
                MsgBox("New password did not match", vbExclamation)
                Return
            End If

            con.Open()
            Dim imageBytes As Byte() = ImageToByte(PictureBox2.Image)
            With cmd
                .Connection = con
                .CommandType = CommandType.StoredProcedure
                .CommandText = "sp_userupdate"
                .Parameters.Clear()
                .Parameters.AddWithValue("@username", tbUsername2.Text)
                .Parameters.AddWithValue("@password", tbNewPass.Text)
                .Parameters.AddWithValue("@name", tbFullname2.Text)
                .Parameters.AddWithValue("@accType", cbAccType2.Text)
                If imageBytes Is Nothing Then
                    .Parameters.AddWithValue("@picture", DBNull.Value) ' Handle null image
                Else
                    .Parameters.AddWithValue("@picture", imageBytes)
                End If
                .ExecuteNonQuery()
            End With
            con.Close()
            MsgBox("Account has been sucessfully updated", vbInformation)
            ClearFields()
            Me.Close()
            FormUserLog.Show()
            FormUserLog.BringToFront()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, vbCritical)


        End Try



    End Sub


    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles tbUsername3.TextChanged



    End Sub

    Private Sub bDelete_Click(sender As Object, e As EventArgs) Handles bDelete.Click

        Dim found As Boolean = False


        con.Open()
        cmd = New SqlCommand("Select * from tblUser where username like '" & tbUsername3.Text & "' and password like '" & tbOldpass2.Text & "'", con)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            found = True
        Else
            found = False

        End If

        dr.Close()
        con.Close()
        If dr IsNot Nothing AndAlso Not dr.IsClosed Then
            dr.Close()
        End If
        If found = True Then

            con.Open()
            With cmd
                .Connection = con
                .CommandType = CommandType.StoredProcedure
                .CommandText = "sp_deletesuser"
                .Parameters.AddWithValue("@username", tbUsername3.Text)
                .ExecuteNonQuery()
            End With
            con.Close()
            MsgBox("Account has been successfully Delete", vbInformation)
        Else
            MsgBox("Account not found", vbExclamation)
        End If
        tbUsername3.Clear()
        tbOldpass2.Clear()





    End Sub

    Private Sub bImage_Click(sender As Object, e As EventArgs) Handles bImage.Click

        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
            PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        End If

    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk

    End Sub

    Private Sub UpSelectImage_Click(sender As Object, e As EventArgs) Handles UpSelectImage.Click

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            PictureBox2.Image = Image.FromFile(OpenFileDialog1.FileName)
            PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
        End If

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

    End Sub


End Class