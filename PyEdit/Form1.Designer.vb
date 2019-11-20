<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(86, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(177, 27)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Welcome to PyEdit!"
        Me.Label1.UseCompatibleTextRendering = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 435)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(169, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Install"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 416)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(273, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "You do not have python installed or added to the Path"
        Me.Label2.UseCompatibleTextRendering = True
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(434, 435)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(233, 35)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Label3"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.Label3.UseCompatibleTextRendering = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(90, 84)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(473, 23)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "New Project"
        Me.Button2.UseCompatibleTextRendering = True
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(90, 151)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(473, 23)
        Me.Button3.TabIndex = 5
        Me.Button3.Text = "Open Most Recent Project"
        Me.Button3.UseCompatibleTextRendering = True
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(90, 122)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(473, 23)
        Me.Button4.TabIndex = 6
        Me.Button4.Text = "Open Project"
        Me.Button4.UseCompatibleTextRendering = True
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(692, 470)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menu"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
End Class
