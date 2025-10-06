Imports System.Data.SqlClient


Public Class FormRegistration

    Public Property ParentFormRegister As FormRegister
    Private WithEvents _formconn As FormGetUID
    Private _rfidChecked As Boolean = False
    Private Sub bSave_Click(sender As Object, e As EventArgs) Handles bSave.Click
        Try
            con.Open()
            ' Check if Student ID exists
            Dim checkStudentCmd As New SqlCommand("SELECT COUNT(*) FROM tblRegistered WHERE studId = @studid", con)
            checkStudentCmd.Parameters.AddWithValue("@studid", tbStudentId.Text)
            Dim studentCount As Integer = CInt(checkStudentCmd.ExecuteScalar())

            ' Check if RFID exists
            Dim checkRFIDCmd As New SqlCommand("SELECT COUNT(*) FROM tblRegistered WHERE rfld = @rfid", con)
            checkRFIDCmd.Parameters.AddWithValue("@rfid", tbRFIDno.Text)
            Dim rfidCount As Integer = CInt(checkRFIDCmd.ExecuteScalar())

            If studentCount > 0 AndAlso rfidCount > 0 Then
                MsgBox("Both Student ID and RFID already exist!", vbExclamation)
            ElseIf studentCount > 0 Then
                MsgBox("Student ID already exists!", vbExclamation)
            ElseIf rfidCount > 0 Then
                MsgBox("RFID already exists!", vbExclamation)
            Else

                With cmd
                    .Connection = con
                    .CommandType = CommandType.StoredProcedure
                    .CommandText = "sp_registeradd"
                    .Parameters.Clear()
                    .Parameters.AddWithValue("@studid", tbStudentId.Text)
                    .Parameters.AddWithValue("@rfid", tbRFIDno.Text)
                    .Parameters.AddWithValue("@contactp", tbContactP.Text)
                    .Parameters.AddWithValue("@contactn", tbContactN.Text)
                    .ExecuteNonQuery()
                    MsgBox("Record has been successfully saved", vbInformation)
                    clear()
                End With
            End If
            con.Close()
            ' Refresh the DataGridView in the parent form
            If ParentFormRegister IsNot Nothing Then
                ParentFormRegister.loadRecords4()
            End If

            'FormCombine1.UpdateTblCombine()
            FormRegister.Show()
            Me.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Sub clear()
        tbStudentId.Clear()
        tbRFIDno.Clear()
        tbContactP.Clear()
        tbContactN.Clear()
        tbStudentId2.Clear()
        tbRFIDNo2.Clear()
        tbContactP2.Clear()
        tbContactN2.Clear()
    End Sub

    Private WithEvents formInOut As FormRegister
    Private Sub bCancel_Click(sender As Object, e As EventArgs) Handles bCancel.Click

        If MsgBox("Do you want to cancel this operation?", vbYesNo) = vbYes Then
            If formInOut Is Nothing OrElse formInOut.IsDisposed Then
                formInOut = New FormRegister()
                formInOut.TopLevel = True
                formInOut.Owner = Nothing
                formInOut.ShowInTaskbar = True
                formInOut.Show()
            Else
                If formInOut.WindowState = FormWindowState.Minimized Then
                    formInOut.WindowState = FormWindowState.Maximized
                End If
                formInOut.BringToFront()
            End If
            clear()
            Close()
        End If

    End Sub

    Private Sub bUpdate_Click(sender As Object, e As EventArgs) Handles BUpdate2.Click
        Try
            ' Skip RFID check if it was already done in tbGetUID2
            If Not _rfidChecked Then
                con.Open()
                Dim checkCmd As New SqlCommand("SELECT COUNT(*) FROM tblRegistered WHERE rfld = @rfid", con)
                checkCmd.Parameters.AddWithValue("@rfid", tbRFIDNo2.Text)
                Dim count As Integer = CInt(checkCmd.ExecuteScalar())

                If count > 0 Then
                    MsgBox("Student RFID already exists. Please use a different student number.", vbExclamation)
                    con.Close()
                    Return
                End If
                con.Close()
            End If

            con.Open()
            With cmd
                .Connection = con
                .CommandType = CommandType.StoredProcedure
                .CommandText = "sp_registeredit"
                .Parameters.Clear()
                .Parameters.AddWithValue("@studid", tbStudentId2.Text)
                .Parameters.AddWithValue("@rfid", tbRFIDNo2.Text)
                .Parameters.AddWithValue("@contactp", tbContactP2.Text)
                .Parameters.AddWithValue("@contactn", tbContactN2.Text)
                .ExecuteNonQuery()
                MsgBox("Record has been successfully saved", vbInformation)
                clear()
            End With
            con.Close()

            ' Reset the flag after successful update
            _rfidChecked = False

            ' Refresh the DataGridView in the parent form
            If ParentFormRegister IsNot Nothing Then
                ParentFormRegister.loadRecords4()

            End If

            'FormCombine1.UpdateTblCombine()
            FormRegister.Show()
            Me.Close()
        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, vbCritical)

        End Try

    End Sub

    Private Sub BLook_Click(sender As Object, e As EventArgs) Handles BLook.Click
        Dim studentLookForm As New FormStudentLook
        ' Pass the parent form reference (if needed)
        studentLookForm.parentFormRegistration = Me
        Me.Hide()

        ' Show the form as a dialog
        studentLookForm.Show()

        ' Don't close the current form here
        ' The BLook button will remain clickable since we're not closing the form

        ' Optional: Add any code needed after the dialog closes
        ' For example, you might want to update fields based on the selection
    End Sub

    Private Sub FormRegistration_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If MsgBox("Do you want to cancel this operation?", vbYesNo) = vbYes Then
            If MsgBox("Do you want to cancel this operation?", vbYesNo) = vbYes Then
                If formInOut Is Nothing OrElse formInOut.IsDisposed Then
                    formInOut = New FormRegister()
                    formInOut.TopLevel = True
                    formInOut.Owner = Nothing
                    formInOut.ShowInTaskbar = True
                    formInOut.Show()
                Else
                    If formInOut.WindowState = FormWindowState.Minimized Then
                        formInOut.WindowState = FormWindowState.Maximized
                    End If
                    formInOut.BringToFront()
                End If
                clear()
                Close()
            End If
        End If
    End Sub
    Dim getUidForm As New FormGetUID
    Private Sub tbGetUID_Click_1(sender As Object, e As EventArgs) Handles tbGetUID.Click

        getUidForm.ParentRegistrationForm = Me ' Pass reference to the parent form
        getUidForm.Show()
    End Sub

    Private Sub tbGetUID2_Click_2(sender As Object, e As EventArgs) Handles tbGetUID2.Click
        Try
            con.Open()
            Dim checkCmd As New SqlCommand("SELECT COUNT(*) FROM tblRegistered WHERE rfld = @rfid", con)
            checkCmd.Parameters.AddWithValue("@rfid", tbRFIDNo2.Text)
            Dim count As Integer = CInt(checkCmd.ExecuteScalar())

            If count > 0 Then
                MsgBox("Student RFID already exists. Please use a different RFID.", vbExclamation)
                _rfidChecked = False
            Else
                _rfidChecked = True
                MsgBox("RFID is available for use.", vbInformation)
            End If
            con.Close()

            getUidForm.ParentRegistrationForm2 = Me
            getUidForm.Show()

        Catch ex As Exception
            con.Close()
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub bUpdate_Click_1(sender As Object, e As EventArgs) Handles bUpdate.Click

    End Sub

    'Dim RFID As New FormConnection






End Class