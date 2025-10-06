Public Class FormNews

    Public Property News As String = String.Empty
    Public Sub New()
        InitializeComponent()
        Me.DoubleBuffered = True
    End Sub
    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        ' Store the text from RichTextBox
        News = rtbNews.Text

        ' Set dialog result and close form
        Me.DialogResult = DialogResult.OK

    End Sub

End Class