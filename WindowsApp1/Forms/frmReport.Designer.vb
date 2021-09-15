<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReport
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
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.NetPayBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.reports = New WindowsApp1.reports()
        Me.Attendance_Tab = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.PrintNet_BTN = New System.Windows.Forms.Button()
        Me.ReportV_NetPay = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.Rate_list = New System.Windows.Forms.ListView()
        Me.ColumnHeader17 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader18 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader19 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader20 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label20 = New System.Windows.Forms.Label()
        Me.PreviewNet_BTN = New System.Windows.Forms.Button()
        Me.PaydateNet_ComboB = New System.Windows.Forms.ComboBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Close_LBL = New System.Windows.Forms.Label()
        CType(Me.NetPayBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.reports, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Attendance_Tab.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'NetPayBindingSource
        '
        Me.NetPayBindingSource.DataMember = "NetPay"
        Me.NetPayBindingSource.DataSource = Me.reports
        '
        'reports
        '
        Me.reports.DataSetName = "reports"
        Me.reports.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Attendance_Tab
        '
        Me.Attendance_Tab.Controls.Add(Me.TabPage1)
        Me.Attendance_Tab.Controls.Add(Me.TabPage2)
        Me.Attendance_Tab.Font = New System.Drawing.Font("Dubai", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Attendance_Tab.Location = New System.Drawing.Point(5, 30)
        Me.Attendance_Tab.Name = "Attendance_Tab"
        Me.Attendance_Tab.SelectedIndex = 0
        Me.Attendance_Tab.Size = New System.Drawing.Size(1159, 636)
        Me.Attendance_Tab.TabIndex = 69
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.PrintNet_BTN)
        Me.TabPage1.Controls.Add(Me.ReportV_NetPay)
        Me.TabPage1.Controls.Add(Me.Rate_list)
        Me.TabPage1.Controls.Add(Me.Label20)
        Me.TabPage1.Controls.Add(Me.PreviewNet_BTN)
        Me.TabPage1.Controls.Add(Me.PaydateNet_ComboB)
        Me.TabPage1.Location = New System.Drawing.Point(4, 41)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1151, 591)
        Me.TabPage1.TabIndex = 1
        Me.TabPage1.Text = "    Net Pay   "
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'PrintNet_BTN
        '
        Me.PrintNet_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PrintNet_BTN.Location = New System.Drawing.Point(949, 10)
        Me.PrintNet_BTN.Name = "PrintNet_BTN"
        Me.PrintNet_BTN.Size = New System.Drawing.Size(87, 36)
        Me.PrintNet_BTN.TabIndex = 102
        Me.PrintNet_BTN.Text = "Print"
        Me.PrintNet_BTN.UseVisualStyleBackColor = True
        '
        'ReportV_NetPay
        '
        ReportDataSource1.Name = "DataSet1"
        ReportDataSource1.Value = Me.NetPayBindingSource
        Me.ReportV_NetPay.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportV_NetPay.LocalReport.ReportEmbeddedResource = "WindowsApp1.rpt_NetPay.rdlc"
        Me.ReportV_NetPay.Location = New System.Drawing.Point(3, 67)
        Me.ReportV_NetPay.Name = "ReportV_NetPay"
        Me.ReportV_NetPay.ServerReport.BearerToken = Nothing
        Me.ReportV_NetPay.Size = New System.Drawing.Size(1142, 488)
        Me.ReportV_NetPay.TabIndex = 101
        '
        'Rate_list
        '
        Me.Rate_list.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Rate_list.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader17, Me.ColumnHeader18, Me.ColumnHeader19, Me.ColumnHeader20, Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9})
        Me.Rate_list.Font = New System.Drawing.Font("Dubai", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rate_list.FullRowSelect = True
        Me.Rate_list.GridLines = True
        Me.Rate_list.HideSelection = False
        Me.Rate_list.Location = New System.Drawing.Point(3, 561)
        Me.Rate_list.MultiSelect = False
        Me.Rate_list.Name = "Rate_list"
        Me.Rate_list.Size = New System.Drawing.Size(1145, 27)
        Me.Rate_list.TabIndex = 100
        Me.Rate_list.UseCompatibleStateImageBehavior = False
        Me.Rate_list.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader17
        '
        Me.ColumnHeader17.Text = "EMP NO."
        Me.ColumnHeader17.Width = 90
        '
        'ColumnHeader18
        '
        Me.ColumnHeader18.Text = "EMPLOYEE NAME"
        Me.ColumnHeader18.Width = 250
        '
        'ColumnHeader19
        '
        Me.ColumnHeader19.Text = "BASIC"
        Me.ColumnHeader19.Width = 70
        '
        'ColumnHeader20
        '
        Me.ColumnHeader20.Text = "OVERTIME"
        Me.ColumnHeader20.Width = 70
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "HOLIDAY"
        Me.ColumnHeader1.Width = 70
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "N DIFF."
        Me.ColumnHeader2.Width = 70
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "PI/ECOLA/SIL PAY"
        Me.ColumnHeader3.Width = 70
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "TARDINESS"
        Me.ColumnHeader4.Width = 70
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "SSS"
        Me.ColumnHeader5.Width = 70
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "PHIC"
        Me.ColumnHeader6.Width = 70
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "PAGIBIG"
        Me.ColumnHeader7.Width = 70
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "SBU/CHARGES"
        Me.ColumnHeader8.Width = 70
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "NET PAY"
        Me.ColumnHeader9.Width = 80
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(6, 17)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(98, 25)
        Me.Label20.TabIndex = 11
        Me.Label20.Text = "Search Payroll"
        '
        'PreviewNet_BTN
        '
        Me.PreviewNet_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PreviewNet_BTN.Location = New System.Drawing.Point(1058, 10)
        Me.PreviewNet_BTN.Name = "PreviewNet_BTN"
        Me.PreviewNet_BTN.Size = New System.Drawing.Size(87, 36)
        Me.PreviewNet_BTN.TabIndex = 9
        Me.PreviewNet_BTN.Text = "Preview"
        Me.PreviewNet_BTN.UseVisualStyleBackColor = True
        '
        'PaydateNet_ComboB
        '
        Me.PaydateNet_ComboB.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PaydateNet_ComboB.FormattingEnabled = True
        Me.PaydateNet_ComboB.Location = New System.Drawing.Point(111, 13)
        Me.PaydateNet_ComboB.Name = "PaydateNet_ComboB"
        Me.PaydateNet_ComboB.Size = New System.Drawing.Size(197, 33)
        Me.PaydateNet_ComboB.TabIndex = 8
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 41)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(1151, 591)
        Me.TabPage2.TabIndex = 2
        Me.TabPage2.Text = "    Common   "
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Dubai", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(4, -2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 36)
        Me.Label1.TabIndex = 68
        Me.Label1.Text = "Reports"
        '
        'Close_LBL
        '
        Me.Close_LBL.AutoSize = True
        Me.Close_LBL.Font = New System.Drawing.Font("Dubai", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Close_LBL.Location = New System.Drawing.Point(1116, -2)
        Me.Close_LBL.Name = "Close_LBL"
        Me.Close_LBL.Size = New System.Drawing.Size(57, 32)
        Me.Close_LBL.TabIndex = 75
        Me.Close_LBL.Text = "Close"
        '
        'frmReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1169, 665)
        Me.Controls.Add(Me.Close_LBL)
        Me.Controls.Add(Me.Attendance_Tab)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmReport"
        Me.Text = "frmReport"
        CType(Me.NetPayBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.reports, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Attendance_Tab.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Attendance_Tab As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents Label20 As Label
    Friend WithEvents PaydateNet_ComboB As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Close_LBL As Label
    Friend WithEvents PreviewNet_BTN As Button
    Friend WithEvents Rate_list As ListView
    Friend WithEvents ColumnHeader17 As ColumnHeader
    Friend WithEvents ColumnHeader18 As ColumnHeader
    Friend WithEvents ColumnHeader19 As ColumnHeader
    Friend WithEvents ColumnHeader20 As ColumnHeader
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents ColumnHeader9 As ColumnHeader
    Friend WithEvents ReportV_NetPay As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents NetPayBindingSource As BindingSource
    Friend WithEvents reports As reports
    Friend WithEvents PrintNet_BTN As Button
End Class
