<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmUser
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
        Me.GunaClear_btn = New Guna.UI2.WinForms.Guna2GradientButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Confirm_txt = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.NewPass_txt = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SamplePass_txt = New Guna.UI2.WinForms.Guna2TextBox()
        Me.GunaSave_btn = New Guna.UI2.WinForms.Guna2GradientButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.SampleUser_txt = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.NewUser_txt = New Guna.UI2.WinForms.Guna2TextBox()
        Me.SuspendLayout()
        '
        'GunaClear_btn
        '
        Me.GunaClear_btn.Animated = True
        Me.GunaClear_btn.AutoRoundedCorners = True
        Me.GunaClear_btn.BorderRadius = 14
        Me.GunaClear_btn.CheckedState.Parent = Me.GunaClear_btn
        Me.GunaClear_btn.CustomImages.Parent = Me.GunaClear_btn
        Me.GunaClear_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.GunaClear_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.GunaClear_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.GunaClear_btn.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.GunaClear_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.GunaClear_btn.DisabledState.Parent = Me.GunaClear_btn
        Me.GunaClear_btn.FillColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.GunaClear_btn.FillColor2 = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaClear_btn.Font = New System.Drawing.Font("Dubai", 12.0!)
        Me.GunaClear_btn.ForeColor = System.Drawing.Color.Black
        Me.GunaClear_btn.HoverState.Parent = Me.GunaClear_btn
        Me.GunaClear_btn.Location = New System.Drawing.Point(201, 317)
        Me.GunaClear_btn.Name = "GunaClear_btn"
        Me.GunaClear_btn.ShadowDecoration.Parent = Me.GunaClear_btn
        Me.GunaClear_btn.Size = New System.Drawing.Size(95, 30)
        Me.GunaClear_btn.TabIndex = 26
        Me.GunaClear_btn.Text = "Clear"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(196, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(135, 25)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Change User Details"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(59, 255)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(131, 27)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Confirm Password"
        '
        'Confirm_txt
        '
        Me.Confirm_txt.AutoRoundedCorners = True
        Me.Confirm_txt.BorderColor = System.Drawing.Color.Maroon
        Me.Confirm_txt.BorderRadius = 15
        Me.Confirm_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Confirm_txt.DefaultText = ""
        Me.Confirm_txt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.Confirm_txt.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.Confirm_txt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Confirm_txt.DisabledState.Parent = Me.Confirm_txt
        Me.Confirm_txt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Confirm_txt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Confirm_txt.FocusedState.Parent = Me.Confirm_txt
        Me.Confirm_txt.Font = New System.Drawing.Font("Dubai", 12.0!)
        Me.Confirm_txt.ForeColor = System.Drawing.Color.Black
        Me.Confirm_txt.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Confirm_txt.HoverState.Parent = Me.Confirm_txt
        Me.Confirm_txt.Location = New System.Drawing.Point(201, 255)
        Me.Confirm_txt.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Confirm_txt.Name = "Confirm_txt"
        Me.Confirm_txt.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.Confirm_txt.PlaceholderText = ""
        Me.Confirm_txt.SelectedText = ""
        Me.Confirm_txt.ShadowDecoration.Parent = Me.Confirm_txt
        Me.Confirm_txt.Size = New System.Drawing.Size(236, 32)
        Me.Confirm_txt.TabIndex = 24
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(58, 213)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(108, 27)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "New Password"
        '
        'NewPass_txt
        '
        Me.NewPass_txt.AutoRoundedCorners = True
        Me.NewPass_txt.BorderColor = System.Drawing.Color.Maroon
        Me.NewPass_txt.BorderRadius = 15
        Me.NewPass_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.NewPass_txt.DefaultText = ""
        Me.NewPass_txt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.NewPass_txt.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.NewPass_txt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.NewPass_txt.DisabledState.Parent = Me.NewPass_txt
        Me.NewPass_txt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.NewPass_txt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.NewPass_txt.FocusedState.Parent = Me.NewPass_txt
        Me.NewPass_txt.Font = New System.Drawing.Font("Dubai", 12.0!)
        Me.NewPass_txt.ForeColor = System.Drawing.Color.Black
        Me.NewPass_txt.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.NewPass_txt.HoverState.Parent = Me.NewPass_txt
        Me.NewPass_txt.Location = New System.Drawing.Point(201, 213)
        Me.NewPass_txt.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.NewPass_txt.Name = "NewPass_txt"
        Me.NewPass_txt.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.NewPass_txt.PlaceholderText = ""
        Me.NewPass_txt.SelectedText = ""
        Me.NewPass_txt.ShadowDecoration.Parent = Me.NewPass_txt
        Me.NewPass_txt.Size = New System.Drawing.Size(236, 32)
        Me.NewPass_txt.TabIndex = 23
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Dubai", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(534, -3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 32)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "X"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(60, 101)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(126, 27)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Sample Password"
        '
        'SamplePass_txt
        '
        Me.SamplePass_txt.AutoRoundedCorners = True
        Me.SamplePass_txt.BorderColor = System.Drawing.Color.Maroon
        Me.SamplePass_txt.BorderRadius = 15
        Me.SamplePass_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.SamplePass_txt.DefaultText = ""
        Me.SamplePass_txt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.SamplePass_txt.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.SamplePass_txt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.SamplePass_txt.DisabledState.Parent = Me.SamplePass_txt
        Me.SamplePass_txt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.SamplePass_txt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.SamplePass_txt.FocusedState.Parent = Me.SamplePass_txt
        Me.SamplePass_txt.Font = New System.Drawing.Font("Dubai", 12.0!)
        Me.SamplePass_txt.ForeColor = System.Drawing.Color.Black
        Me.SamplePass_txt.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.SamplePass_txt.HoverState.Parent = Me.SamplePass_txt
        Me.SamplePass_txt.Location = New System.Drawing.Point(201, 101)
        Me.SamplePass_txt.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.SamplePass_txt.Name = "SamplePass_txt"
        Me.SamplePass_txt.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.SamplePass_txt.PlaceholderText = ""
        Me.SamplePass_txt.SelectedText = ""
        Me.SamplePass_txt.ShadowDecoration.Parent = Me.SamplePass_txt
        Me.SamplePass_txt.Size = New System.Drawing.Size(236, 32)
        Me.SamplePass_txt.TabIndex = 21
        '
        'GunaSave_btn
        '
        Me.GunaSave_btn.Animated = True
        Me.GunaSave_btn.AutoRoundedCorners = True
        Me.GunaSave_btn.BorderRadius = 14
        Me.GunaSave_btn.CheckedState.Parent = Me.GunaSave_btn
        Me.GunaSave_btn.CustomImages.Parent = Me.GunaSave_btn
        Me.GunaSave_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.GunaSave_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.GunaSave_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.GunaSave_btn.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.GunaSave_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.GunaSave_btn.DisabledState.Parent = Me.GunaSave_btn
        Me.GunaSave_btn.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GunaSave_btn.ForeColor = System.Drawing.Color.Black
        Me.GunaSave_btn.HoverState.Parent = Me.GunaSave_btn
        Me.GunaSave_btn.Location = New System.Drawing.Point(342, 317)
        Me.GunaSave_btn.Name = "GunaSave_btn"
        Me.GunaSave_btn.ShadowDecoration.Parent = Me.GunaSave_btn
        Me.GunaSave_btn.Size = New System.Drawing.Size(95, 30)
        Me.GunaSave_btn.TabIndex = 25
        Me.GunaSave_btn.Text = "Save"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(60, 59)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(128, 27)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "Sample Username"
        '
        'SampleUser_txt
        '
        Me.SampleUser_txt.AutoRoundedCorners = True
        Me.SampleUser_txt.BorderColor = System.Drawing.Color.Maroon
        Me.SampleUser_txt.BorderRadius = 15
        Me.SampleUser_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.SampleUser_txt.DefaultText = ""
        Me.SampleUser_txt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.SampleUser_txt.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.SampleUser_txt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.SampleUser_txt.DisabledState.Parent = Me.SampleUser_txt
        Me.SampleUser_txt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.SampleUser_txt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.SampleUser_txt.FocusedState.Parent = Me.SampleUser_txt
        Me.SampleUser_txt.Font = New System.Drawing.Font("Dubai", 12.0!)
        Me.SampleUser_txt.ForeColor = System.Drawing.Color.Black
        Me.SampleUser_txt.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.SampleUser_txt.HoverState.Parent = Me.SampleUser_txt
        Me.SampleUser_txt.Location = New System.Drawing.Point(201, 59)
        Me.SampleUser_txt.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.SampleUser_txt.Name = "SampleUser_txt"
        Me.SampleUser_txt.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.SampleUser_txt.PlaceholderText = ""
        Me.SampleUser_txt.SelectedText = ""
        Me.SampleUser_txt.ShadowDecoration.Parent = Me.SampleUser_txt
        Me.SampleUser_txt.Size = New System.Drawing.Size(236, 32)
        Me.SampleUser_txt.TabIndex = 20
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(58, 171)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(110, 27)
        Me.Label7.TabIndex = 23
        Me.Label7.Text = "New Username"
        '
        'NewUser_txt
        '
        Me.NewUser_txt.AutoRoundedCorners = True
        Me.NewUser_txt.BorderColor = System.Drawing.Color.Maroon
        Me.NewUser_txt.BorderRadius = 15
        Me.NewUser_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.NewUser_txt.DefaultText = ""
        Me.NewUser_txt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.NewUser_txt.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.NewUser_txt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.NewUser_txt.DisabledState.Parent = Me.NewUser_txt
        Me.NewUser_txt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.NewUser_txt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.NewUser_txt.FocusedState.Parent = Me.NewUser_txt
        Me.NewUser_txt.Font = New System.Drawing.Font("Dubai", 12.0!)
        Me.NewUser_txt.ForeColor = System.Drawing.Color.Black
        Me.NewUser_txt.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.NewUser_txt.HoverState.Parent = Me.NewUser_txt
        Me.NewUser_txt.Location = New System.Drawing.Point(201, 171)
        Me.NewUser_txt.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.NewUser_txt.Name = "NewUser_txt"
        Me.NewUser_txt.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.NewUser_txt.PlaceholderText = ""
        Me.NewUser_txt.SelectedText = ""
        Me.NewUser_txt.ShadowDecoration.Parent = Me.NewUser_txt
        Me.NewUser_txt.Size = New System.Drawing.Size(236, 32)
        Me.NewUser_txt.TabIndex = 22
        '
        'frmUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(556, 370)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.NewUser_txt)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.SampleUser_txt)
        Me.Controls.Add(Me.GunaClear_btn)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Confirm_txt)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.NewPass_txt)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SamplePass_txt)
        Me.Controls.Add(Me.GunaSave_btn)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmUser"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmUser"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GunaClear_btn As Guna.UI2.WinForms.Guna2GradientButton
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Confirm_txt As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents NewPass_txt As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents SamplePass_txt As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents GunaSave_btn As Guna.UI2.WinForms.Guna2GradientButton
    Friend WithEvents Label6 As Label
    Friend WithEvents SampleUser_txt As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents NewUser_txt As Guna.UI2.WinForms.Guna2TextBox
End Class
