Public Class FormRemarks
    ' Public property to expose the remarks text
    Public Property RemarksText As String = String.Empty

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Store the text from RichTextBox
        RemarksText = rtbRemarks.Text

        ' Set dialog result and close form
        Me.DialogResult = DialogResult.OK
    End Sub
End Class