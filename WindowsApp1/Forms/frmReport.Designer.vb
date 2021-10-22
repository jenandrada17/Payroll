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
        Dim ReportDataSource6 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource5 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
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
        Me.d = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.SearchSBU_TXT = New System.Windows.Forms.TextBox()
        Me.SearchSBU_BTN = New System.Windows.Forms.Button()
        Me.SBU_LV = New System.Windows.Forms.ListView()
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader29 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader30 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader23 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader28 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Close_LBL = New System.Windows.Forms.Label()
        Me.Rate_list = New System.Windows.Forms.ListView()
        Me.ColumnHeader17 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader18 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader19 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader20 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ComClear_BTN = New System.Windows.Forms.Button()
        Me.Employee_TXT = New System.Windows.Forms.TextBox()
        Me.ComSelect_BTN = New System.Windows.Forms.Button()
        Me.ComSave_BTN = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ComCategory_Combo = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.AddCommon_BTN = New System.Windows.Forms.Button()
        Me.RptViewer_Common = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ComCompany_Combo = New System.Windows.Forms.ComboBox()
        CType(Me.NetPayBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.reports, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Attendance_Tab.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.d.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.Panel1.SuspendLayout()
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
        Me.Attendance_Tab.Controls.Add(Me.d)
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
        ReportDataSource6.Name = "DataSet1"
        ReportDataSource6.Value = Me.NetPayBindingSource
        Me.ReportV_NetPay.LocalReport.DataSources.Add(ReportDataSource6)
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
        'd
        '
        Me.d.Controls.Add(Me.Panel1)
        Me.d.Controls.Add(Me.RptViewer_Common)
        Me.d.Controls.Add(Me.AddCommon_BTN)
        Me.d.Location = New System.Drawing.Point(4, 41)
        Me.d.Name = "d"
        Me.d.Size = New System.Drawing.Size(1151, 591)
        Me.d.TabIndex = 2
        Me.d.Text = "    Common   "
        Me.d.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Rate_list)
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
        'Rate_list
        '
        Me.Rate_list.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Rate_list.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader17, Me.ColumnHeader18, Me.ColumnHeader19, Me.ColumnHeader20})
        Me.Rate_list.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rate_list.FullRowSelect = True
        Me.Rate_list.GridLines = True
        Me.Rate_list.HideSelection = False
        Me.Rate_list.Location = New System.Drawing.Point(6, 19)
        Me.Rate_list.MultiSelect = False
        Me.Rate_list.Name = "Rate_list"
        Me.Rate_list.Size = New System.Drawing.Size(618, 566)
        Me.Rate_list.TabIndex = 100
        Me.Rate_list.UseCompatibleStateImageBehavior = False
        Me.Rate_list.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader17
        '
        Me.ColumnHeader17.Text = "Branch"
        Me.ColumnHeader17.Width = 130
        '
        'ColumnHeader18
        '
        Me.ColumnHeader18.Text = "Name"
        Me.ColumnHeader18.Width = 300
        '
        'ColumnHeader19
        '
        Me.ColumnHeader19.Text = "Bio No."
        Me.ColumnHeader19.Width = 85
        '
        'ColumnHeader20
        '
        Me.ColumnHeader20.Text = "Daily Rate"
        Me.ColumnHeader20.Width = 80
        '
        'ComClear_BTN
        '
        Me.ComClear_BTN.BackColor = System.Drawing.Color.PeachPuff
        Me.ComClear_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComClear_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComClear_BTN.Location = New System.Drawing.Point(432, 58)
        Me.ComClear_BTN.Name = "ComClear_BTN"
        Me.ComClear_BTN.Size = New System.Drawing.Size(57, 36)
        Me.ComClear_BTN.TabIndex = 99
        Me.ComClear_BTN.Text = "Clear"
        Me.ComClear_BTN.UseVisualStyleBackColor = False
        '
        'Employee_TXT
        '
        Me.Employee_TXT.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Employee_TXT.Location = New System.Drawing.Point(107, 14)
        Me.Employee_TXT.Name = "Employee_TXT"
        Me.Employee_TXT.ReadOnly = True
        Me.Employee_TXT.Size = New System.Drawing.Size(319, 33)
        Me.Employee_TXT.TabIndex = 98
        '
        'ComSelect_BTN
        '
        Me.ComSelect_BTN.AutoSize = True
        Me.ComSelect_BTN.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComSelect_BTN.Location = New System.Drawing.Point(432, 13)
        Me.ComSelect_BTN.Name = "ComSelect_BTN"
        Me.ComSelect_BTN.Size = New System.Drawing.Size(57, 36)
        Me.ComSelect_BTN.TabIndex = 97
        Me.ComSelect_BTN.Text = "..."
        Me.ComSelect_BTN.UseVisualStyleBackColor = True
        '
        'ComSave_BTN
        '
        Me.ComSave_BTN.BackColor = System.Drawing.Color.DarkSalmon
        Me.ComSave_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComSave_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComSave_BTN.Location = New System.Drawing.Point(432, 107)
        Me.ComSave_BTN.Name = "ComSave_BTN"
        Me.ComSave_BTN.Size = New System.Drawing.Size(57, 36)
        Me.ComSave_BTN.TabIndex = 96
        Me.ComSave_BTN.Text = "Save"
        Me.ComSave_BTN.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.ComCompany_Combo)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.ComClear_BTN)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.ComCategory_Combo)
        Me.Panel1.Controls.Add(Me.Employee_TXT)
        Me.Panel1.Controls.Add(Me.ComSave_BTN)
        Me.Panel1.Controls.Add(Me.ComSelect_BTN)
        Me.Panel1.Location = New System.Drawing.Point(633, 95)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(503, 159)
        Me.Panel1.TabIndex = 100
        Me.Panel1.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(14, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 27)
        Me.Label3.TabIndex = 99
        Me.Label3.Text = "Name"
        '
        'ComCategory_Combo
        '
        Me.ComCategory_Combo.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComCategory_Combo.FormattingEnabled = True
        Me.ComCategory_Combo.Items.AddRange(New Object() {"PERFECOM/LEASING/7ELEVEN", "PHOTO/PERFECCOM", "PHOTO/GHS/3G", "MARKETING", "BRANCH", "DYU", "DTR"})
        Me.ComCategory_Combo.Location = New System.Drawing.Point(107, 108)
        Me.ComCategory_Combo.Name = "ComCategory_Combo"
        Me.ComCategory_Combo.Size = New System.Drawing.Size(319, 35)
        Me.ComCategory_Combo.TabIndex = 100
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(14, 111)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 27)
        Me.Label4.TabIndex = 101
        Me.Label4.Text = "Category"
        '
        'AddCommon_BTN
        '
        Me.AddCommon_BTN.BackColor = System.Drawing.Color.RosyBrown
        Me.AddCommon_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.AddCommon_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AddCommon_BTN.Location = New System.Drawing.Point(5, 15)
        Me.AddCommon_BTN.Name = "AddCommon_BTN"
        Me.AddCommon_BTN.Size = New System.Drawing.Size(189, 36)
        Me.AddCommon_BTN.TabIndex = 102
        Me.AddCommon_BTN.Text = "Add Common Employee"
        Me.AddCommon_BTN.UseVisualStyleBackColor = False
        '
        'RptViewer_Common
        '
        ReportDataSource5.Name = "DataSet1"
        ReportDataSource5.Value = Me.NetPayBindingSource
        Me.RptViewer_Common.LocalReport.DataSources.Add(ReportDataSource5)
        Me.RptViewer_Common.LocalReport.ReportEmbeddedResource = "WindowsApp1.rpt_NetPay.rdlc"
        Me.RptViewer_Common.Location = New System.Drawing.Point(4, 61)
        Me.RptViewer_Common.Name = "RptViewer_Common"
        Me.RptViewer_Common.ServerReport.BearerToken = Nothing
        Me.RptViewer_Common.Size = New System.Drawing.Size(1142, 527)
        Me.RptViewer_Common.TabIndex = 103
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(14, 61)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 27)
        Me.Label5.TabIndex = 103
        Me.Label5.Text = "Company "
        '
        'ComCompany_Combo
        '
        Me.ComCompany_Combo.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComCompany_Combo.FormattingEnabled = True
        Me.ComCompany_Combo.Items.AddRange(New Object() {"DALTON PAWNSHOP", "GENSAN PERFECT", "JR. PHOTO LAB", "DAVAO PERFECT", "PERFECOM (Inc. Kiosk)", "3G", "7-ELEVEN ROX   P&G UY", "7-ELEVEN POL", "COMMISSARY    ", "FOOD COURT", "PBA", "KTV", "PAULINO'S", "COFFE LOVER", "Wave", "FUJIYAKI"})
        Me.ComCompany_Combo.Location = New System.Drawing.Point(107, 58)
        Me.ComCompany_Combo.Name = "ComCompany_Combo"
        Me.ComCompany_Combo.Size = New System.Drawing.Size(319, 35)
        Me.ComCompany_Combo.TabIndex = 102
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
        Me.d.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
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
    Friend WithEvents d As TabPage
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
    Friend WithEvents Rate_list As ListView
    Friend WithEvents ColumnHeader17 As ColumnHeader
    Friend WithEvents ColumnHeader18 As ColumnHeader
    Friend WithEvents ColumnHeader19 As ColumnHeader
    Friend WithEvents ColumnHeader20 As ColumnHeader
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents ComCategory_Combo As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Employee_TXT As TextBox
    Friend WithEvents ComSave_BTN As Button
    Friend WithEvents ComSelect_BTN As Button
    Friend WithEvents ComClear_BTN As Button
    Friend WithEvents AddCommon_BTN As Button
    Friend WithEvents RptViewer_Common As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents Label5 As Label
    Friend WithEvents ComCompany_Combo As ComboBox
End Class
