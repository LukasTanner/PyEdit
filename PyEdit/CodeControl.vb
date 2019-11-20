Public Class CodeControl
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        On Error Resume Next


        Dim font1 = TextBox1.Font
        Dim fontfamily1 = New FontFamily("Consolas")
        Dim size1 = font1.Size
        Dim afterfont1 = New Font(fontfamily1, size1 + 2)
        TextBox1.Font = afterfont1
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        On Error Resume Next

        Dim font1 = TextBox1.Font
        Dim fontfamily1 = New FontFamily("Consolas")
        Dim size1 = font1.Size
        Dim afterfont1 = New Font(fontfamily1, size1 - 2)
        TextBox1.Font = afterfont1
    End Sub

    Function addtotextbox(insertText As String)
        Dim insertPos As Integer = TextBox1.SelectionStart
        TextBox1.Text = TextBox1.Text.Insert(insertPos, insertText)
        TextBox1.SelectionStart = insertPos + insertText.Length
        TextBox1.ScrollToCaret()

    End Function
    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            addtotextbox(Space(4))
        End If
    End Sub
End Class
