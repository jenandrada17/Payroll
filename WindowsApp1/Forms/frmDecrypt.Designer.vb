<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDecrypt
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.encrypt = New System.Windows.Forms.Button()
        Me.Decrypt = New System.Windows.Forms.Button()
        Me.pass2 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPassDecrypt = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Buttonn = New System.Windows.Forms.Button()
        Me.txtDestinationDecrypt = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.browse = New System.Windows.Forms.Button()
        Me.txtFileToDecrypt = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.RichTextBox2 = New System.Windows.Forms.RichTextBox()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.RichTextBox3 = New System.Windows.Forms.RichTextBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(27, 43)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(518, 335)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.encrypt)
        Me.TabPage1.Controls.Add(Me.Decrypt)
        Me.TabPage1.Controls.Add(Me.pass2)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.txtPassDecrypt)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Buttonn)
        Me.TabPage1.Controls.Add(Me.txtDestinationDecrypt)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.browse)
        Me.TabPage1.Controls.Add(Me.txtFileToDecrypt)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(510, 309)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Decrypt"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'encrypt
        '
        Me.encrypt.Location = New System.Drawing.Point(371, 205)
        Me.encrypt.Name = "encrypt"
        Me.encrypt.Size = New System.Drawing.Size(75, 56)
        Me.encrypt.TabIndex = 11
        Me.encrypt.Text = "Encrypt"
        Me.encrypt.UseVisualStyleBackColor = True
        '
        'Decrypt
        '
        Me.Decrypt.Location = New System.Drawing.Point(371, 128)
        Me.Decrypt.Name = "Decrypt"
        Me.Decrypt.Size = New System.Drawing.Size(75, 56)
        Me.Decrypt.TabIndex = 10
        Me.Decrypt.Text = "Decrypt"
        Me.Decrypt.UseVisualStyleBackColor = True
        '
        'pass2
        '
        Me.pass2.Location = New System.Drawing.Point(107, 164)
        Me.pass2.Name = "pass2"
        Me.pass2.Size = New System.Drawing.Size(258, 20)
        Me.pass2.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(38, 167)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Confirm"
        '
        'txtPassDecrypt
        '
        Me.txtPassDecrypt.Location = New System.Drawing.Point(107, 128)
        Me.txtPassDecrypt.Name = "txtPassDecrypt"
        Me.txtPassDecrypt.Size = New System.Drawing.Size(258, 20)
        Me.txtPassDecrypt.TabIndex = 7
        Me.txtPassDecrypt.Text = "The quick brown fox jumps over the lazy dog"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(38, 131)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Pass"
        '
        'Buttonn
        '
        Me.Buttonn.Location = New System.Drawing.Point(371, 69)
        Me.Buttonn.Name = "Buttonn"
        Me.Buttonn.Size = New System.Drawing.Size(75, 23)
        Me.Buttonn.TabIndex = 5
        Me.Buttonn.Text = "Change"
        Me.Buttonn.UseVisualStyleBackColor = True
        '
        'txtDestinationDecrypt
        '
        Me.txtDestinationDecrypt.Location = New System.Drawing.Point(107, 72)
        Me.txtDestinationDecrypt.Name = "txtDestinationDecrypt"
        Me.txtDestinationDecrypt.Size = New System.Drawing.Size(258, 20)
        Me.txtDestinationDecrypt.TabIndex = 4
        Me.txtDestinationDecrypt.Text = "‪D:\New folder\Encrypt\decrypted.txt"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(38, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Destination"
        '
        'browse
        '
        Me.browse.Location = New System.Drawing.Point(371, 33)
        Me.browse.Name = "browse"
        Me.browse.Size = New System.Drawing.Size(75, 23)
        Me.browse.TabIndex = 2
        Me.browse.Text = "Browse"
        Me.browse.UseVisualStyleBackColor = True
        '
        'txtFileToDecrypt
        '
        Me.txtFileToDecrypt.Location = New System.Drawing.Point(107, 36)
        Me.txtFileToDecrypt.Name = "txtFileToDecrypt"
        Me.txtFileToDecrypt.Size = New System.Drawing.Size(258, 20)
        Me.txtFileToDecrypt.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(38, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(23, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "File"
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(510, 309)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Encrypt"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'RichTextBox2
        '
        Me.RichTextBox2.Location = New System.Drawing.Point(604, 192)
        Me.RichTextBox2.Name = "RichTextBox2"
        Me.RichTextBox2.Size = New System.Drawing.Size(529, 134)
        Me.RichTextBox2.TabIndex = 1
        Me.RichTextBox2.Text = ""
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(604, 32)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(529, 134)
        Me.RichTextBox1.TabIndex = 17
        Me.RichTextBox1.Text = ""
        '
        'RichTextBox3
        '
        Me.RichTextBox3.Location = New System.Drawing.Point(604, 359)
        Me.RichTextBox3.Name = "RichTextBox3"
        Me.RichTextBox3.Size = New System.Drawing.Size(529, 134)
        Me.RichTextBox3.TabIndex = 18
        Me.RichTextBox3.Text = ""
        '
        'frmDecrypt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1169, 665)
        Me.Controls.Add(Me.RichTextBox3)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.RichTextBox2)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmDecrypt"
        Me.Text = "frmDecrypt"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents Buttonn As Button
    Friend WithEvents txtDestinationDecrypt As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents browse As Button
    Friend WithEvents txtFileToDecrypt As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents pass2 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtPassDecrypt As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Decrypt As Button
    Friend WithEvents RichTextBox2 As RichTextBox
    Friend WithEvents encrypt As Button
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents RichTextBox3 As RichTextBox
End Class
