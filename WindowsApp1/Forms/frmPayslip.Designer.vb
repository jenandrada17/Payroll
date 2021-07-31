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
        Me.Paydate_Combo = New System.Windows.Forms.ComboBox()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.Branch_group = New System.Windows.Forms.GroupBox()
        Me.Branch_ComboB = New System.Windows.Forms.ComboBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Rate_Employee_TXT = New System.Windows.Forms.TextBox()
        Me.Rate_EmpSelect_BTN = New System.Windows.Forms.Button()
        Me.Close_LBL = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ReportViewer_payslip = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.Branch_group.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
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
        Me.Label21.Location = New System.Drawing.Point(23, 182)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(53, 25)
        Me.Label21.TabIndex = 69
        Me.Label21.Text = "Payroll"
        '
        'Paydate_Combo
        '
        Me.Paydate_Combo.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Paydate_Combo.FormattingEnabled = True
        Me.Paydate_Combo.Location = New System.Drawing.Point(28, 210)
        Me.Paydate_Combo.Name = "Paydate_Combo"
        Me.Paydate_Combo.Size = New System.Drawing.Size(319, 33)
        Me.Paydate_Combo.TabIndex = 68
        Me.Paydate_Combo.Text = "   Select Date"
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton1.Location = New System.Drawing.Point(28, 55)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(45, 29)
        Me.RadioButton1.TabIndex = 70
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "All"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton2.Location = New System.Drawing.Point(28, 90)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(97, 29)
        Me.RadioButton2.TabIndex = 71
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "Per Branch"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton3.Location = New System.Drawing.Point(28, 125)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(114, 29)
        Me.RadioButton3.TabIndex = 72
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "Per Employee"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'Branch_group
        '
        Me.Branch_group.Controls.Add(Me.Branch_ComboB)
        Me.Branch_group.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Branch_group.Location = New System.Drawing.Point(17, 264)
        Me.Branch_group.Name = "Branch_group"
        Me.Branch_group.Size = New System.Drawing.Size(402, 74)
        Me.Branch_group.TabIndex = 75
        Me.Branch_group.TabStop = False
        Me.Branch_group.Text = "Per Branch"
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
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Rate_Employee_TXT)
        Me.GroupBox5.Controls.Add(Me.Rate_EmpSelect_BTN)
        Me.GroupBox5.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(17, 361)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(402, 72)
        Me.GroupBox5.TabIndex = 88
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Per Employee"
        '
        'Rate_Employee_TXT
        '
        Me.Rate_Employee_TXT.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rate_Employee_TXT.Location = New System.Drawing.Point(11, 25)
        Me.Rate_Employee_TXT.Name = "Rate_Employee_TXT"
        Me.Rate_Employee_TXT.ReadOnly = True
        Me.Rate_Employee_TXT.Size = New System.Drawing.Size(319, 33)
        Me.Rate_Employee_TXT.TabIndex = 90
        '
        'Rate_EmpSelect_BTN
        '
        Me.Rate_EmpSelect_BTN.AutoSize = True
        Me.Rate_EmpSelect_BTN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rate_EmpSelect_BTN.Location = New System.Drawing.Point(336, 28)
        Me.Rate_EmpSelect_BTN.Name = "Rate_EmpSelect_BTN"
        Me.Rate_EmpSelect_BTN.Size = New System.Drawing.Size(57, 30)
        Me.Rate_EmpSelect_BTN.TabIndex = 89
        Me.Rate_EmpSelect_BTN.Text = "Select"
        Me.Rate_EmpSelect_BTN.UseVisualStyleBackColor = True
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
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(174, 504)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(93, 50)
        Me.Button1.TabIndex = 91
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
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
        'frmPayslip
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1169, 665)
        Me.Controls.Add(Me.ReportViewer_payslip)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Close_LBL)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.Branch_group)
        Me.Controls.Add(Me.RadioButton3)
        Me.Controls.Add(Me.RadioButton2)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Paydate_Combo)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.name = "frmPayslip"
        Me.Text = "frmPayslip"
        Me.Branch_group.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Paydate_Combo As ComboBox
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton3 As RadioButton
    Friend WithEvents Branch_group As GroupBox
    Friend WithEvents Branch_ComboB As ComboBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents Rate_Employee_TXT As TextBox
    Friend WithEvents Rate_EmpSelect_BTN As Button
    Friend WithEvents Close_LBL As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents ReportViewer_payslip As Microsoft.Reporting.WinForms.ReportViewer
End Class
