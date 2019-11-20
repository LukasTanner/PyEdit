Public Class NewProjectForm
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        On Error Resume Next
        If TextBox1.Text = "" Then
            Button1.Enabled = False
        Else
            Button1.Enabled = True

        End If
        Timer1.Start()

    End Sub

    Private Sub NewProjectForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox2.Text = Form1.projectsfolder1
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        On Error Resume Next
        If ListView1.SelectedItems.Count = 1 Then
            IO.Directory.CreateDirectory(TextBox2.Text)
            Form1.projectsfolder1 = TextBox2.Text
            Dim finalpath1 = TextBox2.Text & "\" & TextBox1.Text
            IO.Directory.CreateDirectory(finalpath1)
            Dim tag1 = ListView1.SelectedItems(0).Tag
            IO.File.WriteAllText(finalpath1 & "\tag", tag1)
            IO.Directory.CreateDirectory(finalpath1 & "\src")
            If tag1 = "empty cmd app" Then
                IO.File.WriteAllText(finalpath1 & "\src\main.py", "# Ready for Code!")
            End If
            If tag1 = "existing cmd source code" Then
                Dim dirbrowse1 As New FolderBrowserDialog
                dirbrowse1.ShowNewFolderButton = False
                dirbrowse1.Description = "Select a Folder to be Cloned to the Project."
                dirbrowse1.SelectedPath = Form1.projectsfolder1
                If dirbrowse1.ShowDialog = DialogResult.OK Then
                    My.Computer.FileSystem.CopyDirectory(dirbrowse1.SelectedPath, finalpath1 & "\src", True)
                Else
                    IO.File.WriteAllText(finalpath1 & "\src\main.py", "# No Code has been cloned")
                End If
            End If
            Form1.open1(finalpath1)
            Close()
        Else
            MsgBox("You need to select one Object above.")
        End If

    End Sub
End Class