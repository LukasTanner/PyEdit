Public Class Form1
    Dim haspythoninstalled1 = False
    Dim pyversion1 = ""
    Public settingsfolder1 As String = Application.UserAppDataPath & "\pyedit-settings"
    Public projectsfolder1 As String = ""
    Function getOutput(processname1, arguments1) As String
        Dim info1 As New ProcessStartInfo
        info1.FileName = processname1
        info1.Arguments = arguments1
        info1.UseShellExecute = False
        info1.RedirectStandardOutput = True
        info1.CreateNoWindow = True
        Dim process1 As Process = Process.Start(info1)

        Dim rte1 = process1.StandardOutput.ReadToEnd()
        Return rte1

    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Process.Start("https://www.python.org/downloads/")
    End Sub
    Function open1(projectfolder1 As String)
        Dim new1 As New OpenedProject(projectfolder1)
        new1.Show()
        IO.File.WriteAllText(settingsfolder1 & "\recentproject.txt", projectfolder1)
    End Function
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If IO.Directory.Exists(settingsfolder1) Then
        Else
            IO.Directory.CreateDirectory(settingsfolder1)
        End If

        Try
            Dim output1 = getOutput("python", "--version")
            pyversion1 = output1.Split(" ")(1)
            haspythoninstalled1 = True
        Catch ex As Exception
            haspythoninstalled1 = False
        End Try
        Label3.Text = ""
        If haspythoninstalled1 = True Then
            Label2.Visible = False
            Button1.Visible = False
            Label3.Text = "You have Python " & pyversion1
        Else
            Label2.Visible = True
            Button1.Visible = True
        End If
        If IO.File.Exists(settingsfolder1 & "\recentproject.txt") Then
            Button3.Visible = True
            Dim recentproject1 = IO.File.ReadAllText(settingsfolder1 & "\recentproject.txt")
            Button3.Text = "Open Most Recent Project '" & IO.Path.GetFileName(recentproject1) & "'"
        Else
            Button3.Visible = False
        End If
        If IO.File.Exists(settingsfolder1 & "\projectfilepath.txt") Then
        Else
            IO.File.WriteAllText(settingsfolder1 & "\projectfilepath.txt", Application.UserAppDataPath & "\pyedit-projects")
        End If
        projectsfolder1 = IO.File.ReadAllText(settingsfolder1 & "\projectfilepath.txt")

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        NewProjectForm.ShowDialog()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim recentproject1 = IO.File.ReadAllText(settingsfolder1 & "\recentproject.txt")
        open1(recentproject1)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim dirbrowse1 As New FolderBrowserDialog
        dirbrowse1.ShowNewFolderButton = False
        dirbrowse1.Description = "Select a Folder to be opened as a Project"
        dirbrowse1.SelectedPath = projectsfolder1
        If dirbrowse1.ShowDialog = DialogResult.OK Then
            open1(dirbrowse1.SelectedPath)
        End If
    End Sub
End Class
