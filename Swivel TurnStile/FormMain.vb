Imports System.Data.SqlClient
Imports System.IO


Public Class FormMain



    Sub Userpic()

        con.Open()
        cmd = New SqlCommand("SELECT * from tblUser where username like '" & username & "'", con)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            If Not IsDBNull(dr("image")) Then
                Dim imageBytes As Byte() = CType(dr("image"), Byte())
                UserImage.Image = ByteToImage(imageBytes)
                UserImage.SizeMode = PictureBoxSizeMode.StretchImage
            Else
                UserImage.Image = Nothing
            End If
        End If

        con.Close()

        If dr IsNot Nothing AndAlso Not dr.IsClosed Then
            dr.Close()
        End If
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        LblDate.Text = Now
    End Sub

    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
        userpic()


    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

        If MsgBox("Are you sure you want to exit?", vbYesNo) = vbYes Then
            Application.Exit()
        End If

    End Sub

    Private WithEvents FormuserLog As FormUserLog
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If FormuserLog Is Nothing OrElse FormuserLog.IsDisposed Then
            FormuserLog = New FormUserLog()
            FormuserLog.TopLevel = True
            FormuserLog.Owner = Nothing
            FormuserLog.ShowInTaskbar = True
            FormuserLog.Show()
        Else
            If FormuserLog.WindowState = FormWindowState.Minimized Then
                FormuserLog.WindowState = FormWindowState.Normal
                FormuserLog.BringToFront()
            End If
            FormuserLog.BringToFront()
        End If



    End Sub

    Private WithEvents Formstudlist As FormStudentList
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If Formstudlist Is Nothing OrElse Formstudlist.IsDisposed Then
            Formstudlist = New FormStudentList()
            Formstudlist.TopLevel = True
            Formstudlist.Owner = Nothing
            Formstudlist.ShowInTaskbar = True
            Formstudlist.Show()
        Else
            If Formstudlist.WindowState = FormWindowState.Minimized Then
                Formstudlist.WindowState = FormWindowState.Normal
                Formstudlist.BringToFront()
            End If
            Formstudlist.BringToFront()
        End If

    End Sub

    Private WithEvents FormReg As FormRegister
    Private Sub Bregister_Click(sender As Object, e As EventArgs) Handles Bregister.Click
        If FormReg Is Nothing OrElse FormReg.IsDisposed Then
            FormReg = New FormRegister()
            FormReg.TopLevel = True
            FormReg.Owner = Nothing
            FormReg.ShowInTaskbar = True
            FormReg.Show()
        Else
            If FormReg.WindowState = FormWindowState.Minimized Then
                FormReg.WindowState = FormWindowState.Normal
                FormReg.BringToFront()
            End If
            FormReg.BringToFront()
        End If
    End Sub

    Private WithEvents FormDashboard As Dashboard
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Dashboard.Click

        If FormDashboard Is Nothing OrElse FormDashboard.IsDisposed Then
            FormDashboard = New Dashboard
            FormDashboard.TopLevel = True
            FormDashboard.Owner = Nothing
            FormDashboard.ShowInTaskbar = True
            FormDashboard.Show()
        Else
            If FormDashboard.WindowState = FormWindowState.Minimized Then
                FormDashboard.WindowState = FormWindowState.Normal
                FormDashboard.BringToFront()
            End If
            FormDashboard.BringToFront()
        End If

    End Sub
    Private WithEvents Formcombine As FormCombine1
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Formcombine Is Nothing OrElse Formcombine.IsDisposed Then
            Formcombine = New FormCombine1
            Formcombine.TopLevel = True
            Formcombine.Owner = Nothing
            Formcombine.ShowInTaskbar = True
            Formcombine.Show()
        Else
            If Formcombine.WindowState = FormWindowState.Minimized Then
                Formcombine.WindowState = FormWindowState.Normal
                Formcombine.BringToFront()
            End If
            Formcombine.BringToFront()
        End If
    End Sub

    Private WithEvents FormAttendance As FormAttendance

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If FormAttendance Is Nothing OrElse FormAttendance.IsDisposed Then
            FormAttendance = New FormAttendance()
            FormAttendance.TopLevel = True
            FormAttendance.Owner = Nothing
            FormAttendance.ShowInTaskbar = True
            FormAttendance.Show()
        Else
            If FormAttendance.WindowState = FormWindowState.Minimized Then
                FormAttendance.WindowState = FormWindowState.Maximized
                FormAttendance.BringToFront()
            End If
            FormAttendance.BringToFront()
        End If


    End Sub



End Class