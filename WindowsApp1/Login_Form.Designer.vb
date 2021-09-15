<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Login_Form
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login_Form))
        Me.Guna2Elipse1 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.Guna2ShadowForm1 = New Guna.UI2.WinForms.Guna2ShadowForm(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Box_Minimize = New Guna.UI2.WinForms.Guna2ControlBox()
        Me.Box_X = New Guna.UI2.WinForms.Guna2ControlBox()
        Me.Guna2Elipse2 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.txtPass = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtUser = New Guna.UI2.WinForms.Guna2TextBox()
        Me.btnLogin = New Guna.UI2.WinForms.Guna2GradientButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Guna2CirclePictureBox2 = New Guna.UI2.WinForms.Guna2CirclePictureBox()
        Me.Guna2CirclePictureBox1 = New Guna.UI2.WinForms.Guna2CirclePictureBox()
        Me.Guna2DragControl1 = New Guna.UI2.WinForms.Guna2DragControl(Me.components)
        Me.Guna2Panel1.SuspendLayout()
        CType(Me.Guna2CirclePictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Guna2CirclePictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Guna2Elipse1
        '
        Me.Guna2Elipse1.BorderRadius = 10
        Me.Guna2Elipse1.TargetControl = Me
        '
        'Guna2ShadowForm1
        '
        Me.Guna2ShadowForm1.BorderRadius = 20
        Me.Guna2ShadowForm1.ShadowColor = System.Drawing.Color.White
        Me.Guna2ShadowForm1.TargetForm = Me
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(119, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(249, 22)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Perfecto Group of Companies Payroll System"
        '
        'Box_Minimize
        '
        Me.Box_Minimize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Box_Minimize.BackColor = System.Drawing.Color.Transparent
        Me.Box_Minimize.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox
        Me.Box_Minimize.FillColor = System.Drawing.Color.Black
        Me.Box_Minimize.HoverState.Parent = Me.Box_Minimize
        Me.Box_Minimize.IconColor = System.Drawing.Color.White
        Me.Box_Minimize.Location = New System.Drawing.Point(421, 5)
        Me.Box_Minimize.Name = "Box_Minimize"
        Me.Box_Minimize.ShadowDecoration.Parent = Me.Box_Minimize
        Me.Box_Minimize.Size = New System.Drawing.Size(31, 29)
        Me.Box_Minimize.TabIndex = 4
        Me.Box_Minimize.UseTransparentBackground = True
        '
        'Box_X
        '
        Me.Box_X.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Box_X.BackColor = System.Drawing.Color.Transparent
        Me.Box_X.FillColor = System.Drawing.Color.Black
        Me.Box_X.HoverState.Parent = Me.Box_X
        Me.Box_X.IconColor = System.Drawing.Color.White
        Me.Box_X.Location = New System.Drawing.Point(455, 5)
        Me.Box_X.Name = "Box_X"
        Me.Box_X.ShadowDecoration.Parent = Me.Box_X
        Me.Box_X.Size = New System.Drawing.Size(31, 29)
        Me.Box_X.TabIndex = 5
        Me.Box_X.UseTransparentBackground = True
        '
        'Guna2Panel1
        '
        Me.Guna2Panel1.BackColor = System.Drawing.Color.White
        Me.Guna2Panel1.BorderColor = System.Drawing.Color.Maroon
        Me.Guna2Panel1.BorderThickness = 1
        Me.Guna2Panel1.Controls.Add(Me.Guna2CirclePictureBox2)
        Me.Guna2Panel1.Controls.Add(Me.txtPass)
        Me.Guna2Panel1.Controls.Add(Me.Guna2CirclePictureBox1)
        Me.Guna2Panel1.Controls.Add(Me.txtUser)
        Me.Guna2Panel1.Controls.Add(Me.btnLogin)
        Me.Guna2Panel1.Controls.Add(Me.Label1)
        Me.Guna2Panel1.Location = New System.Drawing.Point(94, 37)
        Me.Guna2Panel1.Name = "Guna2Panel1"
        Me.Guna2Panel1.ShadowDecoration.Parent = Me.Guna2Panel1
        Me.Guna2Panel1.Size = New System.Drawing.Size(296, 245)
        Me.Guna2Panel1.TabIndex = 3
        '
        'txtPass
        '
        Me.txtPass.Animated = True
        Me.txtPass.AutoRoundedCorners = True
        Me.txtPass.BorderColor = System.Drawing.Color.Maroon
        Me.txtPass.BorderRadius = 15
        Me.txtPass.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPass.DefaultText = ""
        Me.txtPass.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtPass.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtPass.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtPass.DisabledState.Parent = Me.txtPass
        Me.txtPass.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtPass.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtPass.FocusedState.Parent = Me.txtPass
        Me.txtPass.Font = New System.Drawing.Font("Dubai", 12.0!)
        Me.txtPass.ForeColor = System.Drawing.Color.Black
        Me.txtPass.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtPass.HoverState.Parent = Me.txtPass
        Me.txtPass.Location = New System.Drawing.Point(57, 122)
        Me.txtPass.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.txtPass.Name = "txtPass"
        Me.txtPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPass.PlaceholderText = "Password"
        Me.txtPass.SelectedText = ""
        Me.txtPass.ShadowDecoration.Parent = Me.txtPass
        Me.txtPass.Size = New System.Drawing.Size(217, 32)
        Me.txtPass.TabIndex = 2
        Me.txtPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtUser
        '
        Me.txtUser.Animated = True
        Me.txtUser.AutoRoundedCorners = True
        Me.txtUser.BorderColor = System.Drawing.Color.Maroon
        Me.txtUser.BorderRadius = 15
        Me.txtUser.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtUser.DefaultText = ""
        Me.txtUser.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtUser.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtUser.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtUser.DisabledState.Parent = Me.txtUser
        Me.txtUser.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtUser.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtUser.FocusedState.Parent = Me.txtUser
        Me.txtUser.Font = New System.Drawing.Font("Dubai", 12.0!)
        Me.txtUser.ForeColor = System.Drawing.Color.Black
        Me.txtUser.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtUser.HoverState.Parent = Me.txtUser
        Me.txtUser.Location = New System.Drawing.Point(57, 77)
        Me.txtUser.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtUser.PlaceholderText = "Username"
        Me.txtUser.SelectedText = ""
        Me.txtUser.ShadowDecoration.Parent = Me.txtUser
        Me.txtUser.Size = New System.Drawing.Size(217, 32)
        Me.txtUser.TabIndex = 1
        Me.txtUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnLogin
        '
        Me.btnLogin.Animated = True
        Me.btnLogin.AutoRoundedCorners = True
        Me.btnLogin.BackColor = System.Drawing.Color.Transparent
        Me.btnLogin.BorderColor = System.Drawing.Color.Transparent
        Me.btnLogin.BorderRadius = 14
        Me.btnLogin.BorderThickness = 1
        Me.btnLogin.CheckedState.Parent = Me.btnLogin
        Me.btnLogin.CustomImages.Parent = Me.btnLogin
        Me.btnLogin.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnLogin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnLogin.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnLogin.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnLogin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnLogin.DisabledState.Parent = Me.btnLogin
        Me.btnLogin.FillColor = System.Drawing.Color.Black
        Me.btnLogin.FillColor2 = System.Drawing.Color.Maroon
        Me.btnLogin.Font = New System.Drawing.Font("Dubai", 12.0!)
        Me.btnLogin.ForeColor = System.Drawing.Color.White
        Me.btnLogin.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.btnLogin.HoverState.Parent = Me.btnLogin
        Me.btnLogin.Location = New System.Drawing.Point(103, 187)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.ShadowDecoration.Parent = Me.btnLogin
        Me.btnLogin.Size = New System.Drawing.Size(102, 31)
        Me.btnLogin.TabIndex = 3
        Me.btnLogin.Text = "Login"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Dubai", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(105, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 32)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "User Login"
        '
        'Guna2CirclePictureBox2
        '
        Me.Guna2CirclePictureBox2.FillColor = System.Drawing.Color.Maroon
        Me.Guna2CirclePictureBox2.Image = CType(resources.GetObject("Guna2CirclePictureBox2.Image"), System.Drawing.Image)
        Me.Guna2CirclePictureBox2.ImageRotate = 0!
        Me.Guna2CirclePictureBox2.Location = New System.Drawing.Point(21, 122)
        Me.Guna2CirclePictureBox2.Name = "Guna2CirclePictureBox2"
        Me.Guna2CirclePictureBox2.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle
        Me.Guna2CirclePictureBox2.ShadowDecoration.Parent = Me.Guna2CirclePictureBox2
        Me.Guna2CirclePictureBox2.Size = New System.Drawing.Size(28, 28)
        Me.Guna2CirclePictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Guna2CirclePictureBox2.TabIndex = 8
        Me.Guna2CirclePictureBox2.TabStop = False
        '
        'Guna2CirclePictureBox1
        '
        Me.Guna2CirclePictureBox1.FillColor = System.Drawing.Color.Maroon
        Me.Guna2CirclePictureBox1.Image = CType(resources.GetObject("Guna2CirclePictureBox1.Image"), System.Drawing.Image)
        Me.Guna2CirclePictureBox1.ImageRotate = 0!
        Me.Guna2CirclePictureBox1.Location = New System.Drawing.Point(17, 77)
        Me.Guna2CirclePictureBox1.Name = "Guna2CirclePictureBox1"
        Me.Guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle
        Me.Guna2CirclePictureBox1.ShadowDecoration.Parent = Me.Guna2CirclePictureBox1
        Me.Guna2CirclePictureBox1.Size = New System.Drawing.Size(36, 28)
        Me.Guna2CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Guna2CirclePictureBox1.TabIndex = 7
        Me.Guna2CirclePictureBox1.TabStop = False
        '
        'Guna2DragControl1
        '
        Me.Guna2DragControl1.DockIndicatorTransparencyValue = 0.6R
        Me.Guna2DragControl1.TargetControl = Me
        Me.Guna2DragControl1.TransparentWhileDrag = False
        '
        'Login_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(487, 310)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Guna2Panel1)
        Me.Controls.Add(Me.Box_X)
        Me.Controls.Add(Me.Box_Minimize)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Login_Form"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "s"
        Me.Guna2Panel1.ResumeLayout(False)
        Me.Guna2Panel1.PerformLayout()
        CType(Me.Guna2CirclePictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Guna2CirclePictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Guna2Elipse1 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents Guna2ShadowForm1 As Guna.UI2.WinForms.Guna2ShadowForm
    Friend WithEvents Guna2Elipse2 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents btnLogin As Guna.UI2.WinForms.Guna2GradientButton
    Friend WithEvents txtPass As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtUser As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Box_X As Guna.UI2.WinForms.Guna2ControlBox
    Friend WithEvents Box_Minimize As Guna.UI2.WinForms.Guna2ControlBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Guna2CirclePictureBox1 As Guna.UI2.WinForms.Guna2CirclePictureBox
    Friend WithEvents Guna2CirclePictureBox2 As Guna.UI2.WinForms.Guna2CirclePictureBox
    Friend WithEvents Guna2DragControl1 As Guna.UI2.WinForms.Guna2DragControl
End Class
