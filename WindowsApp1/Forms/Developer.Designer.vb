<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Developer
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Exit_code = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Execute_BTN = New System.Windows.Forms.Button()
        Me.Password_TXT = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.String_TXT = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'Exit_code
        '
        Me.Exit_code.AutoSize = True
        Me.Exit_code.Font = New System.Drawing.Font("Dubai", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Exit_code.Location = New System.Drawing.Point(594, -2)
        Me.Exit_code.Name = "Exit_code"
        Me.Exit_code.Size = New System.Drawing.Size(26, 32)
        Me.Exit_code.TabIndex = 5
        Me.Exit_code.Text = "X"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(18, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Command String"
        '
        'Execute_BTN
        '
        Me.Execute_BTN.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.Execute_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Execute_BTN.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Execute_BTN.Location = New System.Drawing.Point(251, 175)
        Me.Execute_BTN.Name = "Execute_BTN"
        Me.Execute_BTN.Size = New System.Drawing.Size(75, 32)
        Me.Execute_BTN.TabIndex = 6
        Me.Execute_BTN.Text = "Execute"
        Me.Execute_BTN.UseVisualStyleBackColor = False
        '
        'Password_TXT
        '
        Me.Password_TXT.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Password_TXT.Location = New System.Drawing.Point(22, 178)
        Me.Password_TXT.Name = "Password_TXT"
        Me.Password_TXT.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.Password_TXT.Size = New System.Drawing.Size(223, 29)
        Me.Password_TXT.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(19, 159)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 16)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Password"
        '
        'String_TXT
        '
        Me.String_TXT.Location = New System.Drawing.Point(21, 46)
        Me.String_TXT.Name = "String_TXT"
        Me.String_TXT.Size = New System.Drawing.Size(567, 96)
        Me.String_TXT.TabIndex = 9
        Me.String_TXT.Text = ""
        '
        'Developer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(616, 234)
        Me.Controls.Add(Me.String_TXT)
        Me.Controls.Add(Me.Password_TXT)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Execute_BTN)
        Me.Controls.Add(Me.Exit_code)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Developer"
        Me.Text = "Developer"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Exit_code As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Execute_BTN As Button
    Friend WithEvents Password_TXT As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents String_TXT As RichTextBox
End Class
