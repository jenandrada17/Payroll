<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPayslip
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Paydate_ComboB = New System.Windows.Forms.ComboBox()
        Me.All_RadioB = New System.Windows.Forms.RadioButton()
        Me.Branch_RadioB = New System.Windows.Forms.RadioButton()
        Me.Employee_RadioB = New System.Windows.Forms.RadioButton()
        Me.Branch_group = New System.Windows.Forms.GroupBox()
        Me.Branch_ComboB = New System.Windows.Forms.ComboBox()
        Me.Employee_GroupB = New System.Windows.Forms.GroupBox()
        Me.Email_TXT = New System.Windows.Forms.TextBox()
        Me.Employee_TXT = New System.Windows.Forms.TextBox()
        Me.EmpSelect_BTN = New System.Windows.Forms.Button()
        Me.Close_LBL = New System.Windows.Forms.Label()
        Me.ReportViewer_payslip = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.Send_BTN = New System.Windows.Forms.Button()
        Me.BodyText_RichB = New System.Windows.Forms.RichTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Preview_BTN = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Branch_group.SuspendLayout()
        Me.Employee_GroupB.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Dubai", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(4, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 36)
        Me.Label1.TabIndex = 67
        Me.Label1.Text = "Payslip"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(20, 183)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(53, 25)
        Me.Label21.TabIndex = 69
        Me.Label21.Text = "Payroll"
        '
        'Paydate_ComboB
        '
        Me.Paydate_ComboB.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Paydate_ComboB.FormattingEnabled = True
        Me.Paydate_ComboB.Location = New System.Drawing.Point(25, 211)
        Me.Paydate_ComboB.Name = "Paydate_ComboB"
        Me.Paydate_ComboB.Size = New System.Drawing.Size(319, 33)
        Me.Paydate_ComboB.TabIndex = 68
        Me.Paydate_ComboB.Text = "   Select Date"
        '
        'All_RadioB
        '
        Me.All_RadioB.AutoSize = True
        Me.All_RadioB.Checked = True
        Me.All_RadioB.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.All_RadioB.Location = New System.Drawing.Point(28, 55)
        Me.All_RadioB.Name = "All_RadioB"
        Me.All_RadioB.Size = New System.Drawing.Size(45, 29)
        Me.All_RadioB.TabIndex = 70
        Me.All_RadioB.TabStop = True
        Me.All_RadioB.Text = "All"
        Me.All_RadioB.UseVisualStyleBackColor = True
        '
        'Branch_RadioB
        '
        Me.Branch_RadioB.AutoSize = True
        Me.Branch_RadioB.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Branch_RadioB.Location = New System.Drawing.Point(28, 90)
        Me.Branch_RadioB.Name = "Branch_RadioB"
        Me.Branch_RadioB.Size = New System.Drawing.Size(97, 29)
        Me.Branch_RadioB.TabIndex = 71
        Me.Branch_RadioB.TabStop = True
        Me.Branch_RadioB.Text = "Per Branch"
        Me.Branch_RadioB.UseVisualStyleBackColor = True
        '
        'Employee_RadioB
        '
        Me.Employee_RadioB.AutoSize = True
        Me.Employee_RadioB.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Employee_RadioB.Location = New System.Drawing.Point(28, 125)
        Me.Employee_RadioB.Name = "Employee_RadioB"
        Me.Employee_RadioB.Size = New System.Drawing.Size(114, 29)
        Me.Employee_RadioB.TabIndex = 72
        Me.Employee_RadioB.TabStop = True
        Me.Employee_RadioB.Text = "Per Employee"
        Me.Employee_RadioB.UseVisualStyleBackColor = True
        '
        'Branch_group
        '
        Me.Branch_group.Controls.Add(Me.Branch_ComboB)
        Me.Branch_group.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Branch_group.Location = New System.Drawing.Point(3, 3)
        Me.Branch_group.Name = "Branch_group"
        Me.Branch_group.Size = New System.Drawing.Size(416, 74)
        Me.Branch_group.TabIndex = 75
        Me.Branch_group.TabStop = False
        Me.Branch_group.Text = "Per Branch"
        Me.Branch_group.Visible = False
        '
        'Branch_ComboB
        '
        Me.Branch_ComboB.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Branch_ComboB.FormattingEnabled = True
        Me.Branch_ComboB.Location = New System.Drawing.Point(11, 28)
        Me.Branch_ComboB.Name = "Branch_ComboB"
        Me.Branch_ComboB.Size = New System.Drawing.Size(319, 33)
        Me.Branch_ComboB.TabIndex = 8
        Me.Branch_ComboB.Text = "   Select Branch"
        '
        'Employee_GroupB
        '
        Me.Employee_GroupB.Controls.Add(Me.Preview_BTN)
        Me.Employee_GroupB.Controls.Add(Me.Email_TXT)
        Me.Employee_GroupB.Controls.Add(Me.Employee_TXT)
        Me.Employee_GroupB.Controls.Add(Me.EmpSelect_BTN)
        Me.Employee_GroupB.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Employee_GroupB.Location = New System.Drawing.Point(3, 83)
        Me.Employee_GroupB.Name = "Employee_GroupB"
        Me.Employee_GroupB.Size = New System.Drawing.Size(416, 119)
        Me.Employee_GroupB.TabIndex = 88
        Me.Employee_GroupB.TabStop = False
        Me.Employee_GroupB.Text = "Per Employee"
        Me.Employee_GroupB.Visible = False
        '
        'Email_TXT
        '
        Me.Email_TXT.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Email_TXT.Location = New System.Drawing.Point(11, 75)
        Me.Email_TXT.Name = "Email_TXT"
        Me.Email_TXT.ReadOnly = True
        Me.Email_TXT.Size = New System.Drawing.Size(319, 33)
        Me.Email_TXT.TabIndex = 91
        '
        'Employee_TXT
        '
        Me.Employee_TXT.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Employee_TXT.Location = New System.Drawing.Point(11, 25)
        Me.Employee_TXT.Name = "Employee_TXT"
        Me.Employee_TXT.ReadOnly = True
        Me.Employee_TXT.Size = New System.Drawing.Size(319, 33)
        Me.Employee_TXT.TabIndex = 90
        '
        'EmpSelect_BTN
        '
        Me.EmpSelect_BTN.AutoSize = True
        Me.EmpSelect_BTN.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EmpSelect_BTN.Location = New System.Drawing.Point(336, 26)
        Me.EmpSelect_BTN.Name = "EmpSelect_BTN"
        Me.EmpSelect_BTN.Size = New System.Drawing.Size(62, 37)
        Me.EmpSelect_BTN.TabIndex = 89
        Me.EmpSelect_BTN.Text = "Select"
        Me.EmpSelect_BTN.UseVisualStyleBackColor = True
        '
        'Close_LBL
        '
        Me.Close_LBL.AutoSize = True
        Me.Close_LBL.Font = New System.Drawing.Font("Dubai", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Close_LBL.Location = New System.Drawing.Point(1118, -4)
        Me.Close_LBL.Name = "Close_LBL"
        Me.Close_LBL.Size = New System.Drawing.Size(57, 32)
        Me.Close_LBL.TabIndex = 90
        Me.Close_LBL.Text = "Close"
        '
        'ReportViewer_payslip
        '
        Me.ReportViewer_payslip.LocalReport.ReportEmbeddedResource = "WindowsApp1.rpt_payslip.rdlc"
        Me.ReportViewer_payslip.Location = New System.Drawing.Point(640, 29)
        Me.ReportViewer_payslip.Name = "ReportViewer_payslip"
        Me.ReportViewer_payslip.ServerReport.BearerToken = Nothing
        Me.ReportViewer_payslip.Size = New System.Drawing.Size(481, 624)
        Me.ReportViewer_payslip.TabIndex = 92
        '
        'Send_BTN
        '
        Me.Send_BTN.Location = New System.Drawing.Point(487, 580)
        Me.Send_BTN.Name = "Send_BTN"
        Me.Send_BTN.Size = New System.Drawing.Size(93, 50)
        Me.Send_BTN.TabIndex = 93
        Me.Send_BTN.Text = "Send"
        Me.Send_BTN.UseVisualStyleBackColor = True
        '
        'BodyText_RichB
        '
        Me.BodyText_RichB.Location = New System.Drawing.Point(28, 576)
        Me.BodyText_RichB.Name = "BodyText_RichB"
        Me.BodyText_RichB.Size = New System.Drawing.Size(391, 58)
        Me.BodyText_RichB.TabIndex = 94
        Me.BodyText_RichB.Text = """Please reply ""received"" for confirmation with this emailed payslip. Thank you."""
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(26, 560)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 95
        Me.Label2.Text = "Body Text"
        '
        'Preview_BTN
        '
        Me.Preview_BTN.Location = New System.Drawing.Point(336, 73)
        Me.Preview_BTN.Name = "Preview_BTN"
        Me.Preview_BTN.Size = New System.Drawing.Size(62, 35)
        Me.Preview_BTN.TabIndex = 96
        Me.Preview_BTN.Text = "Preview"
        Me.Preview_BTN.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.Branch_group)
        Me.FlowLayoutPanel1.Controls.Add(Me.Employee_GroupB)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(12, 264)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(430, 224)
        Me.FlowLayoutPanel1.TabIndex = 96
        '
        'frmPayslip
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1169, 665)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BodyText_RichB)
        Me.Controls.Add(Me.Send_BTN)
        Me.Controls.Add(Me.ReportViewer_payslip)
        Me.Controls.Add(Me.Close_LBL)
        Me.Controls.Add(Me.Employee_RadioB)
        Me.Controls.Add(Me.Branch_RadioB)
        Me.Controls.Add(Me.All_RadioB)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Paydate_ComboB)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmPayslip"
        Me.Text = "frmPayslip"
        Me.Branch_group.ResumeLayout(False)
        Me.Employee_GroupB.ResumeLayout(False)
        Me.Employee_GroupB.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Paydate_ComboB As ComboBox
    Friend WithEvents All_RadioB As RadioButton
    Friend WithEvents Branch_RadioB As RadioButton
    Friend WithEvents Employee_RadioB As RadioButton
    Friend WithEvents Branch_group As GroupBox
    Friend WithEvents Branch_ComboB As ComboBox
    Friend WithEvents Employee_GroupB As GroupBox
    Friend WithEvents Employee_TXT As TextBox
    Friend WithEvents EmpSelect_BTN As Button
    Friend WithEvents Close_LBL As Label
    Friend WithEvents ReportViewer_payslip As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents Send_BTN As Button
    Friend WithEvents Email_TXT As TextBox
    Friend WithEvents BodyText_RichB As RichTextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Preview_BTN As Button
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
End Class
