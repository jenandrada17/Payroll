<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPassword
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
        Me.GunaSave_btn = New Guna.UI2.WinForms.Guna2GradientButton()
        Me.GunaOld_txt = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GunaNew_txt = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GunaConfirm_txt = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GunaClear_btn = New Guna.UI2.WinForms.Guna2GradientButton()
        Me.SuspendLayout()
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
        Me.GunaSave_btn.Location = New System.Drawing.Point(326, 207)
        Me.GunaSave_btn.Name = "GunaSave_btn"
        Me.GunaSave_btn.ShadowDecoration.Parent = Me.GunaSave_btn
        Me.GunaSave_btn.Size = New System.Drawing.Size(95, 30)
        Me.GunaSave_btn.TabIndex = 0
        Me.GunaSave_btn.Text = "Save"
        '
        'GunaOld_txt
        '
        Me.GunaOld_txt.AutoRoundedCorners = True
        Me.GunaOld_txt.BorderColor = System.Drawing.Color.Maroon
        Me.GunaOld_txt.BorderRadius = 15
        Me.GunaOld_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaOld_txt.DefaultText = ""
        Me.GunaOld_txt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.GunaOld_txt.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.GunaOld_txt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.GunaOld_txt.DisabledState.Parent = Me.GunaOld_txt
        Me.GunaOld_txt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.GunaOld_txt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaOld_txt.FocusedState.Parent = Me.GunaOld_txt
        Me.GunaOld_txt.Font = New System.Drawing.Font("Dubai", 12.0!)
        Me.GunaOld_txt.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaOld_txt.HoverState.Parent = Me.GunaOld_txt
        Me.GunaOld_txt.Location = New System.Drawing.Point(185, 61)
        Me.GunaOld_txt.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.GunaOld_txt.Name = "GunaOld_txt"
        Me.GunaOld_txt.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaOld_txt.PlaceholderText = ""
        Me.GunaOld_txt.SelectedText = ""
        Me.GunaOld_txt.ShadowDecoration.Parent = Me.GunaOld_txt
        Me.GunaOld_txt.Size = New System.Drawing.Size(236, 32)
        Me.GunaOld_txt.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(44, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 27)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Old Password"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(460, -1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(21, 27)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "X"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(45, 103)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(108, 27)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "New Password"
        '
        'GunaNew_txt
        '
        Me.GunaNew_txt.AutoRoundedCorners = True
        Me.GunaNew_txt.BorderColor = System.Drawing.Color.Maroon
        Me.GunaNew_txt.BorderRadius = 15
        Me.GunaNew_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaNew_txt.DefaultText = ""
        Me.GunaNew_txt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.GunaNew_txt.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.GunaNew_txt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.GunaNew_txt.DisabledState.Parent = Me.GunaNew_txt
        Me.GunaNew_txt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.GunaNew_txt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaNew_txt.FocusedState.Parent = Me.GunaNew_txt
        Me.GunaNew_txt.Font = New System.Drawing.Font("Dubai", 12.0!)
        Me.GunaNew_txt.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaNew_txt.HoverState.Parent = Me.GunaNew_txt
        Me.GunaNew_txt.Location = New System.Drawing.Point(185, 103)
        Me.GunaNew_txt.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.GunaNew_txt.Name = "GunaNew_txt"
        Me.GunaNew_txt.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaNew_txt.PlaceholderText = ""
        Me.GunaNew_txt.SelectedText = ""
        Me.GunaNew_txt.ShadowDecoration.Parent = Me.GunaNew_txt
        Me.GunaNew_txt.Size = New System.Drawing.Size(236, 32)
        Me.GunaNew_txt.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(47, 145)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(131, 27)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Confirm Password"
        '
        'GunaConfirm_txt
        '
        Me.GunaConfirm_txt.AutoRoundedCorners = True
        Me.GunaConfirm_txt.BorderColor = System.Drawing.Color.Maroon
        Me.GunaConfirm_txt.BorderRadius = 15
        Me.GunaConfirm_txt.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.GunaConfirm_txt.DefaultText = ""
        Me.GunaConfirm_txt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.GunaConfirm_txt.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.GunaConfirm_txt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.GunaConfirm_txt.DisabledState.Parent = Me.GunaConfirm_txt
        Me.GunaConfirm_txt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.GunaConfirm_txt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaConfirm_txt.FocusedState.Parent = Me.GunaConfirm_txt
        Me.GunaConfirm_txt.Font = New System.Drawing.Font("Dubai", 12.0!)
        Me.GunaConfirm_txt.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GunaConfirm_txt.HoverState.Parent = Me.GunaConfirm_txt
        Me.GunaConfirm_txt.Location = New System.Drawing.Point(185, 145)
        Me.GunaConfirm_txt.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.GunaConfirm_txt.Name = "GunaConfirm_txt"
        Me.GunaConfirm_txt.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.GunaConfirm_txt.PlaceholderText = ""
        Me.GunaConfirm_txt.SelectedText = ""
        Me.GunaConfirm_txt.ShadowDecoration.Parent = Me.GunaConfirm_txt
        Me.GunaConfirm_txt.Size = New System.Drawing.Size(236, 32)
        Me.GunaConfirm_txt.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(174, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(120, 25)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Change Password"
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
        Me.GunaClear_btn.Location = New System.Drawing.Point(185, 207)
        Me.GunaClear_btn.Name = "GunaClear_btn"
        Me.GunaClear_btn.ShadowDecoration.Parent = Me.GunaClear_btn
        Me.GunaClear_btn.Size = New System.Drawing.Size(95, 30)
        Me.GunaClear_btn.TabIndex = 9
        Me.GunaClear_btn.Text = "Clear"
        '
        'frmPassword
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.ClientSize = New System.Drawing.Size(480, 261)
        Me.Controls.Add(Me.GunaClear_btn)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GunaConfirm_txt)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GunaNew_txt)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GunaOld_txt)
        Me.Controls.Add(Me.GunaSave_btn)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmPassword"
        Me.Text = "frmPassword"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GunaSave_btn As Guna.UI2.WinForms.Guna2GradientButton
    Friend WithEvents GunaOld_txt As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents GunaNew_txt As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents GunaConfirm_txt As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents GunaClear_btn As Guna.UI2.WinForms.Guna2GradientButton
End Class
