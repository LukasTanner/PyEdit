Public Class OpenedProject
    Dim projectfolder1 As String = ""
    Dim projecttype1 As String = ""
    Dim currentopenfile1 As String = ""

    Public Shared neweststring1
    Public Sub OutputHandler(sendingProcess As Object, outLine As DataReceivedEventArgs)
        ' Collect the sort command output.
        If Not String.IsNullOrEmpty(outLine.Data) Then
            ' Add the text to the collected output.

            neweststring1 &= (outLine.Data & vbCrLf)
        End If
    End Sub
    Public Sub OutputHandlerError(sendingProcess As Object, outLine As DataReceivedEventArgs)
        ' Collect the sort command output.
        If Not String.IsNullOrEmpty(outLine.Data) Then
            ' Add the text to the collected output.

            neweststring1 &= (outLine.Data & vbCrLf)
        End If
    End Sub

    Sub New(projectfilename1 As String)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        projectfolder1 = projectfilename1
    End Sub
    Function reloadfiles1()
        ListBox1.Items.Clear()
        For Each item In IO.Directory.GetFiles(projectfolder1 & "\src")
            ListBox1.Items.Add(IO.Path.GetFileName(item))

        Next
    End Function
    Function reloadtitle1()
        On Error Resume Next

        Dim title1 = ""
        title1 &= "Project "
        title1 &= "'"
        title1 &= IO.Path.GetFileName(projectfolder1)
        title1 &= "'"
        title1 &= " - "
        If projecttype1 = "empty cmd app" Then
            title1 &= "Console Application"
        End If
        If projecttype1 = "existing cmd source code" Then
            title1 &= "Existing Console Source Code"
        End If
        If Not IsNothing(process1) Then
            If process1.HasExited = False Then
                title1 &= " - Running"
            End If
        End If
        Text = title1
    End Function
    Private Sub OpenedProject_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        reloadfiles1()
        projecttype1 = IO.File.ReadAllText(projectfolder1 & "\tag")
        reloadtitle1()


    End Sub
    Function savefile1()
        IO.File.WriteAllText(projectfolder1 & "\src\" & currentopenfile1, CodeControl1.TextBox1.Text)
    End Function
    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        savefile1()

    End Sub

    Private Sub ListBox1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListBox1.MouseDoubleClick
        If ListBox1.SelectedIndex >= 0 Then
            currentopenfile1 = ListBox1.SelectedItem
            CodeControl1.TextBox1.Text = IO.File.ReadAllText(projectfolder1 & "\src\" & currentopenfile1)
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Close()

    End Sub
    Dim process1 As Process
    Sub runOtherProgram1(filename1 As String, argument1 As String)
        runOtherProgram1(filename1, argument1, False)
    End Sub
    Sub runOtherProgram1(filename1 As String, argument1 As String, waitUntilFinish As Boolean)
        stopProgram1()

        CodeControl2.TextBox1.Text = ""
        Dim info1 As New ProcessStartInfo
        info1.FileName = filename1
        info1.Arguments = argument1
        info1.RedirectStandardError = True
        info1.RedirectStandardOutput = True
        info1.RedirectStandardInput = True
        info1.UseShellExecute = False
        info1.CreateNoWindow = True
        info1.WorkingDirectory = projectfolder1 & "\src"
        process1 = Process.Start(info1)
        process1.BeginErrorReadLine()
        process1.BeginOutputReadLine()
        AddHandler process1.OutputDataReceived, AddressOf OutputHandler
        AddHandler process1.ErrorDataReceived, AddressOf OutputHandlerError
        If waitUntilFinish = True Then
            process1.WaitForExit()

        End If
    End Sub
    Sub runProgram1()
        Dim filetorun1 = projectfolder1 & "\src\" & currentopenfile1
        If Not IO.File.Exists(filetorun1) Then
            If Not IO.File.Exists(projectfolder1 & "\src\main.py") Then
                MsgBox("The File main.py doesnt exist. Please make sure you have a main.py in your Folder. or Open the file with the Program in it.")
                Return
            Else
                filetorun1 = (projectfolder1 & "\src\main.py")
            End If
        End If
        runOtherProgram1("python", Chr(34) & filetorun1 & Chr(34))
    End Sub
    Function stopProgram1()
        On Error Resume Next
        process1.StandardInput.Write(Keys.LControlKey)
        process1.StandardInput.Write(Keys.C)
        process1.Kill()
    End Function
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        runProgram1()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        On Error Resume Next
        Dim oldnewstring1 As String = neweststring1
        CodeControl2.TextBox1.AppendText(neweststring1)
        neweststring1 = ""
        If oldnewstring1.Contains(Chr(12)) Then
            CodeControl2.TextBox1.Clear()

        End If
        reloadtitle1()

        Timer1.Start()


    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub
    Dim appendtext1 As String = ""
    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs)
        On Error Resume Next
        e.SuppressKeyPress = True
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyDown
        On Error Resume Next

        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            CodeControl2.TextBox1.AppendText(TextBox2.Text & vbCrLf)
            process1.StandardInput.WriteLine(TextBox2.Text)
            TextBox2.Text = ""
            If process1.HasExited = True Then
                CodeControl2.TextBox1.AppendText("[STOPPED]" & vbCrLf)
            End If
        End If
    End Sub

    Private Sub OpenedProject_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Not IsNothing(process1) Then
            If process1.HasExited = False Then
                MsgBox("The Program is still Running." & vbCrLf & "Please Click on the Stop button")
                e.Cancel = True

            End If
        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        stopProgram1()


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        reloadfiles1()

    End Sub

    Private Sub OpenInExplorerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenInExplorerToolStripMenuItem.Click
        Process.Start("explorer", projectfolder1 & "\src")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        runOtherProgram1("cmd.exe", "")
    End Sub
    Dim waslastminusone1 = False
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        On Error Resume Next
        'process1.StandardOutput.BaseStream.Flush()

        'If process1.StandardOutput.Peek() >= 0 Then
        '    'Console.WriteLine("Check read byte " & process1.StandardOutput.BaseStream.Position & " LENGTH " & process1.StandardOutput.BaseStream.Length)
        '    Dim nextbyte1 = process1.StandardOutput.Read
        '    CodeControl2.TextBox1.AppendText(Chr(nextbyte1))
        '    waslastminusone1 = False
        'Else
        '    Console.WriteLine(process1.StandardOutput.Peek() & " " & waslastminusone1)
        '    If waslastminusone1 = False Then
        '        If process1.StandardOutput.Peek() = -1 Then
        '            process1.StandardOutput.Read()
        '            waslastminusone1 = True

        '        End If

        '    End If
        'End If
        Timer2.Start()

    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub BuildTheCurrentOpenPythonFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuildTheCurrentOpenPythonFileToolStripMenuItem.Click
        Dim pythonfile1 = projectfolder1 & "\src\" & currentopenfile1
        Try
            runOtherProgram1("pyinstaller", "", True)
        Catch ex As Exception
            MsgBox("Looks like you havent installed pyinstaller.")
            runOtherProgram1("pip", "install pyinstaller", True)

        End Try
        runOtherProgram1("pyinstaller", Chr(34) & pythonfile1 & Chr(34) & " --onefile", True)
        If IO.File.Exists(projectfolder1 & "\src\dist\main.exe") Then
            My.Computer.FileSystem.CopyFile(projectfolder1 & "\src\dist\main.exe", projectfolder1 & "\src\build.exe", True)
            reloadfiles1()

        End If
    End Sub

    Private Sub OpenedProject_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            e.SuppressKeyPress = True
            runProgram1()

        End If
    End Sub
End Class