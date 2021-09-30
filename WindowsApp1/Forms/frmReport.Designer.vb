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
        Dim ReportDataSource3 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.NetPayBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.reports = New WindowsApp1.reports()
        Me.Attendance_Tab = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Company_Combo = New System.Windows.Forms.ComboBox()
        Me.PrintNet_BTN = New System.Windows.Forms.Button()
        Me.ReportV_NetPay = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.PreviewNet_BTN = New System.Windows.Forms.Button()
        Me.PaydateNet_ComboB = New System.Windows.Forms.ComboBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.SearchSBU_TXT = New System.Windows.Forms.TextBox()
        Me.SearchSBU_BTN = New System.Windows.Forms.Button()
        Me.SBU_LV = New System.Windows.Forms.ListView()
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader29 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader30 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader23 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader28 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Close_LBL = New System.Windows.Forms.Label()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        CType(Me.NetPayBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.reports, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Attendance_Tab.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage4.SuspendLayout()
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
        Me.Attendance_Tab.Controls.Add(Me.TabPage3)
        Me.Attendance_Tab.Controls.Add(Me.TabPage4)
        Me.Attendance_Tab.Font = New System.Drawing.Font("Dubai", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Attendance_Tab.Location = New System.Drawing.Point(5, 30)
        Me.Attendance_Tab.Name = "Attendance_Tab"
        Me.Attendance_Tab.SelectedIndex = 0
        Me.Attendance_Tab.Size = New System.Drawing.Size(1159, 636)
        Me.Attendance_Tab.TabIndex = 69
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Company_Combo)
        Me.TabPage1.Controls.Add(Me.PrintNet_BTN)
        Me.TabPage1.Controls.Add(Me.ReportV_NetPay)
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(384, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 25)
        Me.Label2.TabIndex = 104
        Me.Label2.Text = "By Company"
        '
        'Company_Combo
        '
        Me.Company_Combo.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Company_Combo.FormattingEnabled = True
        Me.Company_Combo.Items.AddRange(New Object() {"PHOTO", "P&G UY", "DALTON", "PERFECOM", "HEAD OFFICE"})
        Me.Company_Combo.Location = New System.Drawing.Point(479, 14)
        Me.Company_Combo.Name = "Company_Combo"
        Me.Company_Combo.Size = New System.Drawing.Size(197, 33)
        Me.Company_Combo.TabIndex = 103
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
        ReportDataSource3.Name = "DataSet1"
        ReportDataSource3.Value = Me.NetPayBindingSource
        Me.ReportV_NetPay.LocalReport.DataSources.Add(ReportDataSource3)
        Me.ReportV_NetPay.LocalReport.ReportEmbeddedResource = "WindowsApp1.rpt_NetPay.rdlc"
        Me.ReportV_NetPay.Location = New System.Drawing.Point(4, 67)
        Me.ReportV_NetPay.Name = "ReportV_NetPay"
        Me.ReportV_NetPay.ServerReport.BearerToken = Nothing
        Me.ReportV_NetPay.Size = New System.Drawing.Size(1142, 520)
        Me.ReportV_NetPay.TabIndex = 101
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
        'TabPage3
        '
        Me.TabPage3.Location = New System.Drawing.Point(4, 41)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(1151, 591)
        Me.TabPage3.TabIndex = 3
        Me.TabPage3.Text = "    Employee Count   "
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.SearchSBU_TXT)
        Me.TabPage4.Controls.Add(Me.SearchSBU_BTN)
        Me.TabPage4.Controls.Add(Me.SBU_LV)
        Me.TabPage4.Location = New System.Drawing.Point(4, 41)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(1151, 591)
        Me.TabPage4.TabIndex = 4
        Me.TabPage4.Text = "    SBU    "
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'SearchSBU_TXT
        '
        Me.SearchSBU_TXT.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SearchSBU_TXT.Location = New System.Drawing.Point(6, 30)
        Me.SearchSBU_TXT.Name = "SearchSBU_TXT"
        Me.SearchSBU_TXT.Size = New System.Drawing.Size(395, 33)
        Me.SearchSBU_TXT.TabIndex = 122
        '
        'SearchSBU_BTN
        '
        Me.SearchSBU_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SearchSBU_BTN.Location = New System.Drawing.Point(407, 30)
        Me.SearchSBU_BTN.Name = "SearchSBU_BTN"
        Me.SearchSBU_BTN.Size = New System.Drawing.Size(82, 33)
        Me.SearchSBU_BTN.TabIndex = 123
        Me.SearchSBU_BTN.Text = "Search"
        Me.SearchSBU_BTN.UseVisualStyleBackColor = True
        '
        'SBU_LV
        '
        Me.SBU_LV.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SBU_LV.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader10, Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader29, Me.ColumnHeader30, Me.ColumnHeader23, Me.ColumnHeader28})
        Me.SBU_LV.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SBU_LV.FullRowSelect = True
        Me.SBU_LV.GridLines = True
        Me.SBU_LV.HideSelection = False
        Me.SBU_LV.Location = New System.Drawing.Point(6, 69)
        Me.SBU_LV.MultiSelect = False
        Me.SBU_LV.Name = "SBU_LV"
        Me.SBU_LV.Size = New System.Drawing.Size(1139, 519)
        Me.SBU_LV.TabIndex = 121
        Me.SBU_LV.UseCompatibleStateImageBehavior = False
        Me.SBU_LV.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Name"
        Me.ColumnHeader10.Width = 400
        '
        'ColumnHeader29
        '
        Me.ColumnHeader29.Text = "Principal"
        Me.ColumnHeader29.Width = 110
        '
        'ColumnHeader30
        '
        Me.ColumnHeader30.Text = "Credit"
        Me.ColumnHeader30.Width = 110
        '
        'ColumnHeader23
        '
        Me.ColumnHeader23.Text = "Balance"
        Me.ColumnHeader23.Width = 110
        '
        'ColumnHeader28
        '
        Me.ColumnHeader28.Text = "Last Update"
        Me.ColumnHeader28.Width = 155
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
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Category"
        Me.ColumnHeader1.Width = 130
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Amount"
        Me.ColumnHeader2.Width = 100
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
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
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
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents ReportV_NetPay As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents NetPayBindingSource As BindingSource
    Friend WithEvents reports As reports
    Friend WithEvents PrintNet_BTN As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Company_Combo As ComboBox
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents SearchSBU_TXT As TextBox
    Friend WithEvents SearchSBU_BTN As Button
    Friend WithEvents SBU_LV As ListView
    Friend WithEvents ColumnHeader10 As ColumnHeader
    Friend WithEvents ColumnHeader29 As ColumnHeader
    Friend WithEvents ColumnHeader30 As ColumnHeader
    Friend WithEvents ColumnHeader23 As ColumnHeader
    Friend WithEvents ColumnHeader28 As ColumnHeader
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
End Class
