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
        Me.Guna2DragControl1 = New Guna.UI2.WinForms.Guna2DragControl(Me.components)
        Me.Guna2Elipse2 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.Guna2CirclePictureBox5 = New Guna.UI2.WinForms.Guna2CirclePictureBox()
        Me.Guna2CirclePictureBox7 = New Guna.UI2.WinForms.Guna2CirclePictureBox()
        Me.Guna2CirclePictureBox8 = New Guna.UI2.WinForms.Guna2CirclePictureBox()
        Me.Guna2CirclePictureBox9 = New Guna.UI2.WinForms.Guna2CirclePictureBox()
        Me.Guna2CirclePictureBox3 = New Guna.UI2.WinForms.Guna2CirclePictureBox()
        Me.Guna2CirclePictureBox4 = New Guna.UI2.WinForms.Guna2CirclePictureBox()
        Me.Guna2CirclePictureBox6 = New Guna.UI2.WinForms.Guna2CirclePictureBox()
        Me.Guna2CirclePictureBox10 = New Guna.UI2.WinForms.Guna2CirclePictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnLogin = New Guna.UI2.WinForms.Guna2GradientButton()
        Me.txtUser = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Guna2CirclePictureBox1 = New Guna.UI2.WinForms.Guna2CirclePictureBox()
        Me.txtPass = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Guna2CirclePictureBox2 = New Guna.UI2.WinForms.Guna2CirclePictureBox()
        Me.Guna2AnimateWindow1 = New Guna.UI2.WinForms.Guna2AnimateWindow(Me.components)
        CType(Me.Guna2CirclePictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Guna2CirclePictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Guna2CirclePictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Guna2CirclePictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Guna2CirclePictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Guna2CirclePictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Guna2CirclePictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Guna2CirclePictureBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Guna2CirclePictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Guna2CirclePictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Guna2ShadowForm1.ShadowColor = System.Drawing.Color.Maroon
        Me.Guna2ShadowForm1.TargetForm = Me
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(8, 269)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 22)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Payroll System"
        '
        'Box_Minimize
        '
        Me.Box_Minimize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Box_Minimize.BackColor = System.Drawing.Color.Transparent
        Me.Box_Minimize.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox
        Me.Box_Minimize.FillColor = System.Drawing.Color.White
        Me.Box_Minimize.ForeColor = System.Drawing.Color.Black
        Me.Box_Minimize.HoverState.Parent = Me.Box_Minimize
        Me.Box_Minimize.IconColor = System.Drawing.Color.Black
        Me.Box_Minimize.Location = New System.Drawing.Point(528, 5)
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
        Me.Box_X.FillColor = System.Drawing.Color.White
        Me.Box_X.ForeColor = System.Drawing.Color.Black
        Me.Box_X.HoverState.Parent = Me.Box_X
        Me.Box_X.IconColor = System.Drawing.Color.Black
        Me.Box_X.Location = New System.Drawing.Point(562, 5)
        Me.Box_X.Name = "Box_X"
        Me.Box_X.ShadowDecoration.Parent = Me.Box_X
        Me.Box_X.Size = New System.Drawing.Size(31, 29)
        Me.Box_X.TabIndex = 5
        Me.Box_X.UseTransparentBackground = True
        '
        'Guna2DragControl1
        '
        Me.Guna2DragControl1.DockIndicatorTransparencyValue = 0.6R
        Me.Guna2DragControl1.TargetControl = Me
        Me.Guna2DragControl1.TransparentWhileDrag = False
        '
        'Guna2Elipse2
        '
        Me.Guna2Elipse2.BorderRadius = 10
        '
        'Guna2CirclePictureBox5
        '
        Me.Guna2CirclePictureBox5.Image = Global.WindowsApp1.My.Resources.Resources.sample3
        Me.Guna2CirclePictureBox5.ImageRotate = 0!
        Me.Guna2CirclePictureBox5.Location = New System.Drawing.Point(-4, 18)
        Me.Guna2CirclePictureBox5.Name = "Guna2CirclePictureBox5"
        Me.Guna2CirclePictureBox5.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle
        Me.Guna2CirclePictureBox5.ShadowDecoration.Parent = Me.Guna2CirclePictureBox5
        Me.Guna2CirclePictureBox5.Size = New System.Drawing.Size(109, 93)
        Me.Guna2CirclePictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Guna2CirclePictureBox5.TabIndex = 9
        Me.Guna2CirclePictureBox5.TabStop = False
        '
        'Guna2CirclePictureBox7
        '
        Me.Guna2CirclePictureBox7.FillColor = System.Drawing.Color.Transparent
        Me.Guna2CirclePictureBox7.Image = Global.WindowsApp1.My.Resources.Resources.sample3
        Me.Guna2CirclePictureBox7.ImageRotate = 180.0!
        Me.Guna2CirclePictureBox7.Location = New System.Drawing.Point(-4, -10)
        Me.Guna2CirclePictureBox7.Name = "Guna2CirclePictureBox7"
        Me.Guna2CirclePictureBox7.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle
        Me.Guna2CirclePictureBox7.ShadowDecoration.Parent = Me.Guna2CirclePictureBox7
        Me.Guna2CirclePictureBox7.Size = New System.Drawing.Size(109, 101)
        Me.Guna2CirclePictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Guna2CirclePictureBox7.TabIndex = 11
        Me.Guna2CirclePictureBox7.TabStop = False
        '
        'Guna2CirclePictureBox8
        '
        Me.Guna2CirclePictureBox8.FillColor = System.Drawing.Color.Transparent
        Me.Guna2CirclePictureBox8.Image = Global.WindowsApp1.My.Resources.Resources.sample3
        Me.Guna2CirclePictureBox8.ImageRotate = 180.0!
        Me.Guna2CirclePictureBox8.Location = New System.Drawing.Point(96, 46)
        Me.Guna2CirclePictureBox8.Name = "Guna2CirclePictureBox8"
        Me.Guna2CirclePictureBox8.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle
        Me.Guna2CirclePictureBox8.ShadowDecoration.Parent = Me.Guna2CirclePictureBox8
        Me.Guna2CirclePictureBox8.Size = New System.Drawing.Size(109, 101)
        Me.Guna2CirclePictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Guna2CirclePictureBox8.TabIndex = 13
        Me.Guna2CirclePictureBox8.TabStop = False
        '
        'Guna2CirclePictureBox9
        '
        Me.Guna2CirclePictureBox9.Image = Global.WindowsApp1.My.Resources.Resources.sample3
        Me.Guna2CirclePictureBox9.ImageRotate = 0!
        Me.Guna2CirclePictureBox9.Location = New System.Drawing.Point(96, 74)
        Me.Guna2CirclePictureBox9.Name = "Guna2CirclePictureBox9"
        Me.Guna2CirclePictureBox9.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle
        Me.Guna2CirclePictureBox9.ShadowDecoration.Parent = Me.Guna2CirclePictureBox9
        Me.Guna2CirclePictureBox9.Size = New System.Drawing.Size(109, 93)
        Me.Guna2CirclePictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Guna2CirclePictureBox9.TabIndex = 12
        Me.Guna2CirclePictureBox9.TabStop = False
        '
        'Guna2CirclePictureBox3
        '
        Me.Guna2CirclePictureBox3.FillColor = System.Drawing.Color.Transparent
        Me.Guna2CirclePictureBox3.Image = Global.WindowsApp1.My.Resources.Resources.sample3
        Me.Guna2CirclePictureBox3.ImageRotate = 180.0!
        Me.Guna2CirclePictureBox3.Location = New System.Drawing.Point(-4, 117)
        Me.Guna2CirclePictureBox3.Name = "Guna2CirclePictureBox3"
        Me.Guna2CirclePictureBox3.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle
        Me.Guna2CirclePictureBox3.ShadowDecoration.Parent = Me.Guna2CirclePictureBox3
        Me.Guna2CirclePictureBox3.Size = New System.Drawing.Size(109, 101)
        Me.Guna2CirclePictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Guna2CirclePictureBox3.TabIndex = 15
        Me.Guna2CirclePictureBox3.TabStop = False
        '
        'Guna2CirclePictureBox4
        '
        Me.Guna2CirclePictureBox4.Image = Global.WindowsApp1.My.Resources.Resources.sample3
        Me.Guna2CirclePictureBox4.ImageRotate = 0!
        Me.Guna2CirclePictureBox4.Location = New System.Drawing.Point(-4, 145)
        Me.Guna2CirclePictureBox4.Name = "Guna2CirclePictureBox4"
        Me.Guna2CirclePictureBox4.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle
        Me.Guna2CirclePictureBox4.ShadowDecoration.Parent = Me.Guna2CirclePictureBox4
        Me.Guna2CirclePictureBox4.Size = New System.Drawing.Size(109, 93)
        Me.Guna2CirclePictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Guna2CirclePictureBox4.TabIndex = 14
        Me.Guna2CirclePictureBox4.TabStop = False
        '
        'Guna2CirclePictureBox6
        '
        Me.Guna2CirclePictureBox6.FillColor = System.Drawing.Color.Transparent
        Me.Guna2CirclePictureBox6.Image = Global.WindowsApp1.My.Resources.Resources.sample3
        Me.Guna2CirclePictureBox6.ImageRotate = 180.0!
        Me.Guna2CirclePictureBox6.Location = New System.Drawing.Point(96, 184)
        Me.Guna2CirclePictureBox6.Name = "Guna2CirclePictureBox6"
        Me.Guna2CirclePictureBox6.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle
        Me.Guna2CirclePictureBox6.ShadowDecoration.Parent = Me.Guna2CirclePictureBox6
        Me.Guna2CirclePictureBox6.Size = New System.Drawing.Size(109, 101)
        Me.Guna2CirclePictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Guna2CirclePictureBox6.TabIndex = 17
        Me.Guna2CirclePictureBox6.TabStop = False
        '
        'Guna2CirclePictureBox10
        '
        Me.Guna2CirclePictureBox10.Image = Global.WindowsApp1.My.Resources.Resources.sample3
        Me.Guna2CirclePictureBox10.ImageRotate = 0!
        Me.Guna2CirclePictureBox10.Location = New System.Drawing.Point(96, 212)
        Me.Guna2CirclePictureBox10.Name = "Guna2CirclePictureBox10"
        Me.Guna2CirclePictureBox10.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle
        Me.Guna2CirclePictureBox10.ShadowDecoration.Parent = Me.Guna2CirclePictureBox10
        Me.Guna2CirclePictureBox10.Size = New System.Drawing.Size(109, 93)
        Me.Guna2CirclePictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Guna2CirclePictureBox10.TabIndex = 16
        Me.Guna2CirclePictureBox10.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(34, 252)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 22)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "PGC"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Dubai", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(370, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 32)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "User Login"
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
        Me.btnLogin.FillColor = System.Drawing.Color.DarkMagenta
        Me.btnLogin.FillColor2 = System.Drawing.Color.DeepSkyBlue
        Me.btnLogin.Font = New System.Drawing.Font("Dubai", 12.0!)
        Me.btnLogin.ForeColor = System.Drawing.Color.White
        Me.btnLogin.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.btnLogin.HoverState.Parent = Me.btnLogin
        Me.btnLogin.Location = New System.Drawing.Point(368, 223)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.ShadowDecoration.Parent = Me.btnLogin
        Me.btnLogin.Size = New System.Drawing.Size(102, 31)
        Me.btnLogin.TabIndex = 3
        Me.btnLogin.Text = "Login"
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
        Me.txtUser.Location = New System.Drawing.Point(306, 109)
        Me.txtUser.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtUser.PlaceholderText = "Username"
        Me.txtUser.SelectedText = ""
        Me.txtUser.ShadowDecoration.Parent = Me.txtUser
        Me.txtUser.Size = New System.Drawing.Size(233, 32)
        Me.txtUser.TabIndex = 1
        Me.txtUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Guna2CirclePictureBox1
        '
        Me.Guna2CirclePictureBox1.FillColor = System.Drawing.Color.Maroon
        Me.Guna2CirclePictureBox1.Image = CType(resources.GetObject("Guna2CirclePictureBox1.Image"), System.Drawing.Image)
        Me.Guna2CirclePictureBox1.ImageRotate = 0!
        Me.Guna2CirclePictureBox1.Location = New System.Drawing.Point(266, 109)
        Me.Guna2CirclePictureBox1.Name = "Guna2CirclePictureBox1"
        Me.Guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle
        Me.Guna2CirclePictureBox1.ShadowDecoration.Parent = Me.Guna2CirclePictureBox1
        Me.Guna2CirclePictureBox1.Size = New System.Drawing.Size(36, 28)
        Me.Guna2CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Guna2CirclePictureBox1.TabIndex = 7
        Me.Guna2CirclePictureBox1.TabStop = False
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
        Me.txtPass.Location = New System.Drawing.Point(306, 157)
        Me.txtPass.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.txtPass.Name = "txtPass"
        Me.txtPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPass.PlaceholderText = "Password"
        Me.txtPass.SelectedText = ""
        Me.txtPass.ShadowDecoration.Parent = Me.txtPass
        Me.txtPass.Size = New System.Drawing.Size(233, 32)
        Me.txtPass.TabIndex = 2
        Me.txtPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Guna2CirclePictureBox2
        '
        Me.Guna2CirclePictureBox2.FillColor = System.Drawing.Color.Maroon
        Me.Guna2CirclePictureBox2.Image = CType(resources.GetObject("Guna2CirclePictureBox2.Image"), System.Drawing.Image)
        Me.Guna2CirclePictureBox2.ImageRotate = 0!
        Me.Guna2CirclePictureBox2.Location = New System.Drawing.Point(270, 157)
        Me.Guna2CirclePictureBox2.Name = "Guna2CirclePictureBox2"
        Me.Guna2CirclePictureBox2.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle
        Me.Guna2CirclePictureBox2.ShadowDecoration.Parent = Me.Guna2CirclePictureBox2
        Me.Guna2CirclePictureBox2.Size = New System.Drawing.Size(28, 28)
        Me.Guna2CirclePictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Guna2CirclePictureBox2.TabIndex = 8
        Me.Guna2CirclePictureBox2.TabStop = False
        '
        'Guna2AnimateWindow1
        '
        Me.Guna2AnimateWindow1.AnimationType = Guna.UI2.WinForms.Guna2AnimateWindow.AnimateWindowType.AW_HOR_POSITIVE
        Me.Guna2AnimateWindow1.TargetForm = Me
        '
        'Login_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(597, 310)
        Me.Controls.Add(Me.Guna2CirclePictureBox2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtPass)
        Me.Controls.Add(Me.Guna2CirclePictureBox6)
        Me.Controls.Add(Me.Guna2CirclePictureBox1)
        Me.Controls.Add(Me.Guna2CirclePictureBox10)
        Me.Controls.Add(Me.txtUser)
        Me.Controls.Add(Me.Guna2CirclePictureBox3)
        Me.Controls.Add(Me.btnLogin)
        Me.Controls.Add(Me.Guna2CirclePictureBox4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Guna2CirclePictureBox8)
        Me.Controls.Add(Me.Guna2CirclePictureBox9)
        Me.Controls.Add(Me.Guna2CirclePictureBox7)
        Me.Controls.Add(Me.Guna2CirclePictureBox5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Box_X)
        Me.Controls.Add(Me.Box_Minimize)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Login_Form"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "s"
        CType(Me.Guna2CirclePictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Guna2CirclePictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Guna2CirclePictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Guna2CirclePictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Guna2CirclePictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Guna2CirclePictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Guna2CirclePictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Guna2CirclePictureBox10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Guna2CirclePictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Guna2CirclePictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Guna2Elipse1 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents Guna2ShadowForm1 As Guna.UI2.WinForms.Guna2ShadowForm
    Friend WithEvents Box_X As Guna.UI2.WinForms.Guna2ControlBox
    Friend WithEvents Box_Minimize As Guna.UI2.WinForms.Guna2ControlBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Guna2DragControl1 As Guna.UI2.WinForms.Guna2DragControl
    Friend WithEvents Guna2Elipse2 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents Guna2CirclePictureBox6 As Guna.UI2.WinForms.Guna2CirclePictureBox
    Friend WithEvents Guna2CirclePictureBox10 As Guna.UI2.WinForms.Guna2CirclePictureBox
    Friend WithEvents Guna2CirclePictureBox3 As Guna.UI2.WinForms.Guna2CirclePictureBox
    Friend WithEvents Guna2CirclePictureBox4 As Guna.UI2.WinForms.Guna2CirclePictureBox
    Friend WithEvents Guna2CirclePictureBox8 As Guna.UI2.WinForms.Guna2CirclePictureBox
    Friend WithEvents Guna2CirclePictureBox9 As Guna.UI2.WinForms.Guna2CirclePictureBox
    Friend WithEvents Guna2CirclePictureBox7 As Guna.UI2.WinForms.Guna2CirclePictureBox
    Friend WithEvents Guna2CirclePictureBox5 As Guna.UI2.WinForms.Guna2CirclePictureBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Guna2CirclePictureBox2 As Guna.UI2.WinForms.Guna2CirclePictureBox
    Friend WithEvents txtPass As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Guna2CirclePictureBox1 As Guna.UI2.WinForms.Guna2CirclePictureBox
    Friend WithEvents txtUser As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents btnLogin As Guna.UI2.WinForms.Guna2GradientButton
    Friend WithEvents Label1 As Label
    Friend WithEvents Guna2AnimateWindow1 As Guna.UI2.WinForms.Guna2AnimateWindow
End Class
