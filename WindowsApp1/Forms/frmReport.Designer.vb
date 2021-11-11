<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmReport
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
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource3 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.NetPayBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.reports = New WindowsApp1.reports()
        Me.CommonDistributionBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CommonBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Reports_Tab = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.NetBranch_Combo = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Company_Combo = New System.Windows.Forms.ComboBox()
        Me.ReportV_NetPay = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.PaydateNet_ComboB = New System.Windows.Forms.ComboBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.PaydateCom_Combo = New System.Windows.Forms.ComboBox()
        Me.RptViewer_Common = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.d = New System.Windows.Forms.TabPage()
        Me.Modify_Panel = New System.Windows.Forms.Panel()
        Me.LeasingBR_TXT = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.ConHouse_TXT = New System.Windows.Forms.TextBox()
        Me.DR_Dalton_TXT = New System.Windows.Forms.TextBox()
        Me.ConPhoto_TXT = New System.Windows.Forms.TextBox()
        Me.DR_Photo_TXT = New System.Windows.Forms.TextBox()
        Me.ConDalton_TXT = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.DR_House_TXT = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.L_PG711_TXT = New System.Windows.Forms.TextBox()
        Me.L_Dalton_TXT = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.LeasingP_TXT = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DTR_Photo_TXT = New System.Windows.Forms.TextBox()
        Me.DTR_Dalton_TXT = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.D_Perfecom_TXT = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.D_DavaoP_TXT = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.D_Photo_TXT = New System.Windows.Forms.TextBox()
        Me.M_DaltonP_TXT = New System.Windows.Forms.TextBox()
        Me.D_DaltonP_TXT = New System.Windows.Forms.TextBox()
        Me.M_Photo_TXT = New System.Windows.Forms.TextBox()
        Me.M_DavaoP_TXT = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.M_Perfecom_TXT = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Clear_BTN = New System.Windows.Forms.Button()
        Me.Save_BTN = New System.Windows.Forms.Button()
        Me.Modify_BTN = New System.Windows.Forms.Button()
        Me.ComPrev_BTN = New System.Windows.Forms.Button()
        Me.RptViewer_Count = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
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
        CType(Me.NetPayBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.reports, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CommonDistributionBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CommonBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Reports_Tab.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.d.SuspendLayout()
        Me.Modify_Panel.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
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
        'CommonDistributionBindingSource
        '
        Me.CommonDistributionBindingSource.DataMember = "ComGensanPDistrib"
        Me.CommonDistributionBindingSource.DataSource = Me.reports
        '
        'CommonBindingSource
        '
        Me.CommonBindingSource.DataMember = "Common"
        Me.CommonBindingSource.DataSource = Me.reports
        '
        'Reports_Tab
        '
        Me.Reports_Tab.Controls.Add(Me.TabPage1)
        Me.Reports_Tab.Controls.Add(Me.TabPage3)
        Me.Reports_Tab.Controls.Add(Me.d)
        Me.Reports_Tab.Controls.Add(Me.TabPage2)
        Me.Reports_Tab.Controls.Add(Me.TabPage4)
        Me.Reports_Tab.Font = New System.Drawing.Font("Dubai", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Reports_Tab.Location = New System.Drawing.Point(5, 30)
        Me.Reports_Tab.Name = "Reports_Tab"
        Me.Reports_Tab.SelectedIndex = 0
        Me.Reports_Tab.Size = New System.Drawing.Size(1159, 636)
        Me.Reports_Tab.TabIndex = 69
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label31)
        Me.TabPage1.Controls.Add(Me.NetBranch_Combo)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Company_Combo)
        Me.TabPage1.Controls.Add(Me.ReportV_NetPay)
        Me.TabPage1.Controls.Add(Me.Label20)
        Me.TabPage1.Controls.Add(Me.PaydateNet_ComboB)
        Me.TabPage1.Location = New System.Drawing.Point(4, 41)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1151, 591)
        Me.TabPage1.TabIndex = 1
        Me.TabPage1.Text = "    Net Pay   "
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(611, 16)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(55, 25)
        Me.Label31.TabIndex = 107
        Me.Label31.Text = "Branch"
        '
        'NetBranch_Combo
        '
        Me.NetBranch_Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.NetBranch_Combo.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NetBranch_Combo.FormattingEnabled = True
        Me.NetBranch_Combo.Location = New System.Drawing.Point(672, 13)
        Me.NetBranch_Combo.Name = "NetBranch_Combo"
        Me.NetBranch_Combo.Size = New System.Drawing.Size(231, 33)
        Me.NetBranch_Combo.TabIndex = 106
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(1032, 6)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(114, 36)
        Me.Button1.TabIndex = 105
        Me.Button1.Text = "Send to Email"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(292, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 25)
        Me.Label2.TabIndex = 104
        Me.Label2.Text = "Company"
        '
        'Company_Combo
        '
        Me.Company_Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Company_Combo.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Company_Combo.FormattingEnabled = True
        Me.Company_Combo.Items.AddRange(New Object() {"PHOTO", "P&G UY", "DALTON", "PERFECOM"})
        Me.Company_Combo.Location = New System.Drawing.Point(366, 14)
        Me.Company_Combo.Name = "Company_Combo"
        Me.Company_Combo.Size = New System.Drawing.Size(221, 33)
        Me.Company_Combo.TabIndex = 103
        '
        'ReportV_NetPay
        '
        ReportDataSource1.Name = "DataSet1"
        ReportDataSource1.Value = Me.NetPayBindingSource
        Me.ReportV_NetPay.LocalReport.DataSources.Add(ReportDataSource1)
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
        'PaydateNet_ComboB
        '
        Me.PaydateNet_ComboB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PaydateNet_ComboB.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PaydateNet_ComboB.FormattingEnabled = True
        Me.PaydateNet_ComboB.Location = New System.Drawing.Point(111, 13)
        Me.PaydateNet_ComboB.Name = "PaydateNet_ComboB"
        Me.PaydateNet_ComboB.Size = New System.Drawing.Size(144, 33)
        Me.PaydateNet_ComboB.TabIndex = 8
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Label27)
        Me.TabPage3.Controls.Add(Me.PaydateCom_Combo)
        Me.TabPage3.Controls.Add(Me.RptViewer_Common)
        Me.TabPage3.Location = New System.Drawing.Point(4, 41)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(1151, 591)
        Me.TabPage3.TabIndex = 3
        Me.TabPage3.Text = "Common"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(6, 13)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(98, 25)
        Me.Label27.TabIndex = 108
        Me.Label27.Text = "Search Payroll"
        '
        'PaydateCom_Combo
        '
        Me.PaydateCom_Combo.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PaydateCom_Combo.FormattingEnabled = True
        Me.PaydateCom_Combo.Location = New System.Drawing.Point(111, 9)
        Me.PaydateCom_Combo.Name = "PaydateCom_Combo"
        Me.PaydateCom_Combo.Size = New System.Drawing.Size(197, 33)
        Me.PaydateCom_Combo.TabIndex = 107
        '
        'RptViewer_Common
        '
        ReportDataSource2.Name = "DataSet1"
        ReportDataSource2.Value = Me.CommonDistributionBindingSource
        Me.RptViewer_Common.LocalReport.DataSources.Add(ReportDataSource2)
        Me.RptViewer_Common.LocalReport.ReportEmbeddedResource = "WindowsApp1.rpt_CommonEmp.rdlc"
        Me.RptViewer_Common.Location = New System.Drawing.Point(6, 48)
        Me.RptViewer_Common.Name = "RptViewer_Common"
        Me.RptViewer_Common.ServerReport.BearerToken = Nothing
        Me.RptViewer_Common.Size = New System.Drawing.Size(1139, 530)
        Me.RptViewer_Common.TabIndex = 105
        '
        'd
        '
        Me.d.Controls.Add(Me.Modify_Panel)
        Me.d.Controls.Add(Me.Modify_BTN)
        Me.d.Controls.Add(Me.ComPrev_BTN)
        Me.d.Controls.Add(Me.RptViewer_Count)
        Me.d.Location = New System.Drawing.Point(4, 41)
        Me.d.Name = "d"
        Me.d.Size = New System.Drawing.Size(1151, 591)
        Me.d.TabIndex = 2
        Me.d.Text = "    Percentage   "
        Me.d.UseVisualStyleBackColor = True
        '
        'Modify_Panel
        '
        Me.Modify_Panel.BackColor = System.Drawing.Color.Silver
        Me.Modify_Panel.Controls.Add(Me.LeasingBR_TXT)
        Me.Modify_Panel.Controls.Add(Me.GroupBox2)
        Me.Modify_Panel.Controls.Add(Me.Label26)
        Me.Modify_Panel.Controls.Add(Me.Label14)
        Me.Modify_Panel.Controls.Add(Me.GroupBox1)
        Me.Modify_Panel.Controls.Add(Me.Clear_BTN)
        Me.Modify_Panel.Controls.Add(Me.Save_BTN)
        Me.Modify_Panel.Location = New System.Drawing.Point(60, 108)
        Me.Modify_Panel.Name = "Modify_Panel"
        Me.Modify_Panel.Size = New System.Drawing.Size(999, 229)
        Me.Modify_Panel.TabIndex = 106
        Me.Modify_Panel.Visible = False
        '
        'LeasingBR_TXT
        '
        Me.LeasingBR_TXT.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LeasingBR_TXT.Location = New System.Drawing.Point(764, 165)
        Me.LeasingBR_TXT.Name = "LeasingBR_TXT"
        Me.LeasingBR_TXT.Size = New System.Drawing.Size(62, 29)
        Me.LeasingBR_TXT.TabIndex = 17
        Me.LeasingBR_TXT.Text = "1"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label22)
        Me.GroupBox2.Controls.Add(Me.ConHouse_TXT)
        Me.GroupBox2.Controls.Add(Me.DR_Dalton_TXT)
        Me.GroupBox2.Controls.Add(Me.ConPhoto_TXT)
        Me.GroupBox2.Controls.Add(Me.DR_Photo_TXT)
        Me.GroupBox2.Controls.Add(Me.ConDalton_TXT)
        Me.GroupBox2.Controls.Add(Me.Label23)
        Me.GroupBox2.Controls.Add(Me.Label29)
        Me.GroupBox2.Controls.Add(Me.Label24)
        Me.GroupBox2.Controls.Add(Me.DR_House_TXT)
        Me.GroupBox2.Controls.Add(Me.Label25)
        Me.GroupBox2.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(621, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(271, 152)
        Me.GroupBox2.TabIndex = 122
        Me.GroupBox2.TabStop = False
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(101, 17)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(51, 22)
        Me.Label22.TabIndex = 110
        Me.Label22.Text = "Driver#"
        '
        'ConHouse_TXT
        '
        Me.ConHouse_TXT.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ConHouse_TXT.Location = New System.Drawing.Point(182, 113)
        Me.ConHouse_TXT.Name = "ConHouse_TXT"
        Me.ConHouse_TXT.Size = New System.Drawing.Size(62, 29)
        Me.ConHouse_TXT.TabIndex = 6
        '
        'DR_Dalton_TXT
        '
        Me.DR_Dalton_TXT.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DR_Dalton_TXT.Location = New System.Drawing.Point(96, 43)
        Me.DR_Dalton_TXT.Name = "DR_Dalton_TXT"
        Me.DR_Dalton_TXT.Size = New System.Drawing.Size(62, 29)
        Me.DR_Dalton_TXT.TabIndex = 11
        '
        'ConPhoto_TXT
        '
        Me.ConPhoto_TXT.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ConPhoto_TXT.Location = New System.Drawing.Point(182, 78)
        Me.ConPhoto_TXT.Name = "ConPhoto_TXT"
        Me.ConPhoto_TXT.Size = New System.Drawing.Size(62, 29)
        Me.ConPhoto_TXT.TabIndex = 15
        '
        'DR_Photo_TXT
        '
        Me.DR_Photo_TXT.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DR_Photo_TXT.Location = New System.Drawing.Point(96, 78)
        Me.DR_Photo_TXT.Name = "DR_Photo_TXT"
        Me.DR_Photo_TXT.Size = New System.Drawing.Size(62, 29)
        Me.DR_Photo_TXT.TabIndex = 12
        '
        'ConDalton_TXT
        '
        Me.ConDalton_TXT.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ConDalton_TXT.Location = New System.Drawing.Point(182, 43)
        Me.ConDalton_TXT.Name = "ConDalton_TXT"
        Me.ConDalton_TXT.Size = New System.Drawing.Size(62, 29)
        Me.ConDalton_TXT.TabIndex = 14
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(17, 46)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(53, 25)
        Me.Label23.TabIndex = 110
        Me.Label23.Text = "Dalton"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(173, 17)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(87, 22)
        Me.Label29.TabIndex = 117
        Me.Label29.Text = "Construction#"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(17, 80)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(49, 25)
        Me.Label24.TabIndex = 110
        Me.Label24.Text = "Photo"
        '
        'DR_House_TXT
        '
        Me.DR_House_TXT.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DR_House_TXT.Location = New System.Drawing.Point(96, 113)
        Me.DR_House_TXT.Name = "DR_House_TXT"
        Me.DR_House_TXT.Size = New System.Drawing.Size(62, 29)
        Me.DR_House_TXT.TabIndex = 13
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(17, 114)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(79, 25)
        Me.Label25.TabIndex = 113
        Me.Label25.Text = "Household"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(654, 169)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(105, 25)
        Me.Label26.TabIndex = 122
        Me.Label26.Text = "Leasing Branch"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(980, 3)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(21, 27)
        Me.Label14.TabIndex = 20
        Me.Label14.Text = "X"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label35)
        Me.GroupBox1.Controls.Add(Me.Label32)
        Me.GroupBox1.Controls.Add(Me.Label33)
        Me.GroupBox1.Controls.Add(Me.Label34)
        Me.GroupBox1.Controls.Add(Me.L_PG711_TXT)
        Me.GroupBox1.Controls.Add(Me.L_Dalton_TXT)
        Me.GroupBox1.Controls.Add(Me.Label28)
        Me.GroupBox1.Controls.Add(Me.Label30)
        Me.GroupBox1.Controls.Add(Me.LeasingP_TXT)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.DTR_Photo_TXT)
        Me.GroupBox1.Controls.Add(Me.DTR_Dalton_TXT)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.D_Perfecom_TXT)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.D_DavaoP_TXT)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.D_Photo_TXT)
        Me.GroupBox1.Controls.Add(Me.M_DaltonP_TXT)
        Me.GroupBox1.Controls.Add(Me.D_DaltonP_TXT)
        Me.GroupBox1.Controls.Add(Me.M_Photo_TXT)
        Me.GroupBox1.Controls.Add(Me.M_DavaoP_TXT)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.M_Perfecom_TXT)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Font = New System.Drawing.Font("Dubai", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(14, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(590, 213)
        Me.GroupBox1.TabIndex = 107
        Me.GroupBox1.TabStop = False
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(15, 179)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(106, 25)
        Me.Label35.TabIndex = 123
        Me.Label35.Text = "P&&G  (7Eleven)"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(490, 16)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(34, 22)
        Me.Label32.TabIndex = 122
        Me.Label32.Text = "LYU"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Dubai", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(542, 183)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(22, 21)
        Me.Label33.TabIndex = 121
        Me.Label33.Text = "%"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Dubai", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(541, 46)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(22, 21)
        Me.Label34.TabIndex = 120
        Me.Label34.Text = "%"
        '
        'L_PG711_TXT
        '
        Me.L_PG711_TXT.Location = New System.Drawing.Point(479, 179)
        Me.L_PG711_TXT.Name = "L_PG711_TXT"
        Me.L_PG711_TXT.Size = New System.Drawing.Size(62, 28)
        Me.L_PG711_TXT.TabIndex = 119
        '
        'L_Dalton_TXT
        '
        Me.L_Dalton_TXT.Location = New System.Drawing.Point(479, 41)
        Me.L_Dalton_TXT.Name = "L_Dalton_TXT"
        Me.L_Dalton_TXT.Size = New System.Drawing.Size(62, 28)
        Me.L_Dalton_TXT.TabIndex = 118
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(370, 117)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(50, 22)
        Me.Label28.TabIndex = 117
        Me.Label28.Text = "Leasing"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Dubai", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(427, 147)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(22, 21)
        Me.Label30.TabIndex = 116
        Me.Label30.Text = "%"
        '
        'LeasingP_TXT
        '
        Me.LeasingP_TXT.Location = New System.Drawing.Point(365, 142)
        Me.LeasingP_TXT.Name = "LeasingP_TXT"
        Me.LeasingP_TXT.Size = New System.Drawing.Size(62, 28)
        Me.LeasingP_TXT.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(376, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 22)
        Me.Label3.TabIndex = 114
        Me.Label3.Text = "DTR"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Dubai", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(427, 79)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(22, 21)
        Me.Label4.TabIndex = 113
        Me.Label4.Text = "%"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Dubai", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(427, 46)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(22, 21)
        Me.Label5.TabIndex = 112
        Me.Label5.Text = "%"
        '
        'DTR_Photo_TXT
        '
        Me.DTR_Photo_TXT.Location = New System.Drawing.Point(365, 75)
        Me.DTR_Photo_TXT.Name = "DTR_Photo_TXT"
        Me.DTR_Photo_TXT.Size = New System.Drawing.Size(62, 28)
        Me.DTR_Photo_TXT.TabIndex = 9
        '
        'DTR_Dalton_TXT
        '
        Me.DTR_Dalton_TXT.Location = New System.Drawing.Point(365, 41)
        Me.DTR_Dalton_TXT.Name = "DTR_Dalton_TXT"
        Me.DTR_Dalton_TXT.Size = New System.Drawing.Size(62, 28)
        Me.DTR_Dalton_TXT.TabIndex = 8
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Dubai", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(314, 145)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(22, 21)
        Me.Label15.TabIndex = 108
        Me.Label15.Text = "%"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(263, 14)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(36, 22)
        Me.Label21.TabIndex = 109
        Me.Label21.Text = "DYU"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Dubai", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(314, 111)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(22, 21)
        Me.Label16.TabIndex = 108
        Me.Label16.Text = "%"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(134, 14)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(65, 22)
        Me.Label19.TabIndex = 8
        Me.Label19.Text = "Marketing"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Dubai", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(314, 77)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(22, 21)
        Me.Label17.TabIndex = 9
        Me.Label17.Text = "%"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Dubai", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(194, 145)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(22, 21)
        Me.Label13.TabIndex = 108
        Me.Label13.Text = "%"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Dubai", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(314, 44)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(22, 21)
        Me.Label18.TabIndex = 8
        Me.Label18.Text = "%"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(15, 39)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 25)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Dalton"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(15, 73)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 25)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Photo"
        '
        'D_Perfecom_TXT
        '
        Me.D_Perfecom_TXT.Location = New System.Drawing.Point(252, 141)
        Me.D_Perfecom_TXT.Name = "D_Perfecom_TXT"
        Me.D_Perfecom_TXT.Size = New System.Drawing.Size(62, 28)
        Me.D_Perfecom_TXT.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(15, 107)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(98, 25)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Davao Perfect"
        '
        'D_DavaoP_TXT
        '
        Me.D_DavaoP_TXT.Location = New System.Drawing.Point(252, 107)
        Me.D_DavaoP_TXT.Name = "D_DavaoP_TXT"
        Me.D_DavaoP_TXT.Size = New System.Drawing.Size(62, 28)
        Me.D_DavaoP_TXT.TabIndex = 6
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Dubai", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(194, 111)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(22, 21)
        Me.Label12.TabIndex = 108
        Me.Label12.Text = "%"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(15, 141)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 25)
        Me.Label9.TabIndex = 7
        Me.Label9.Text = "Perfecom"
        '
        'D_Photo_TXT
        '
        Me.D_Photo_TXT.Location = New System.Drawing.Point(252, 73)
        Me.D_Photo_TXT.Name = "D_Photo_TXT"
        Me.D_Photo_TXT.Size = New System.Drawing.Size(62, 28)
        Me.D_Photo_TXT.TabIndex = 5
        '
        'M_DaltonP_TXT
        '
        Me.M_DaltonP_TXT.Location = New System.Drawing.Point(132, 39)
        Me.M_DaltonP_TXT.Name = "M_DaltonP_TXT"
        Me.M_DaltonP_TXT.Size = New System.Drawing.Size(62, 28)
        Me.M_DaltonP_TXT.TabIndex = 0
        '
        'D_DaltonP_TXT
        '
        Me.D_DaltonP_TXT.Location = New System.Drawing.Point(252, 39)
        Me.D_DaltonP_TXT.Name = "D_DaltonP_TXT"
        Me.D_DaltonP_TXT.Size = New System.Drawing.Size(62, 28)
        Me.D_DaltonP_TXT.TabIndex = 4
        '
        'M_Photo_TXT
        '
        Me.M_Photo_TXT.Location = New System.Drawing.Point(132, 73)
        Me.M_Photo_TXT.Name = "M_Photo_TXT"
        Me.M_Photo_TXT.Size = New System.Drawing.Size(62, 28)
        Me.M_Photo_TXT.TabIndex = 1
        '
        'M_DavaoP_TXT
        '
        Me.M_DavaoP_TXT.Location = New System.Drawing.Point(132, 107)
        Me.M_DavaoP_TXT.Name = "M_DavaoP_TXT"
        Me.M_DavaoP_TXT.Size = New System.Drawing.Size(62, 28)
        Me.M_DavaoP_TXT.TabIndex = 2
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Dubai", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(194, 77)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(22, 21)
        Me.Label11.TabIndex = 9
        Me.Label11.Text = "%"
        '
        'M_Perfecom_TXT
        '
        Me.M_Perfecom_TXT.Location = New System.Drawing.Point(132, 141)
        Me.M_Perfecom_TXT.Name = "M_Perfecom_TXT"
        Me.M_Perfecom_TXT.Size = New System.Drawing.Size(62, 28)
        Me.M_Perfecom_TXT.TabIndex = 3
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Dubai", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(194, 44)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(22, 21)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "%"
        '
        'Clear_BTN
        '
        Me.Clear_BTN.BackColor = System.Drawing.Color.PeachPuff
        Me.Clear_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Clear_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Clear_BTN.Location = New System.Drawing.Point(920, 97)
        Me.Clear_BTN.Name = "Clear_BTN"
        Me.Clear_BTN.Size = New System.Drawing.Size(57, 36)
        Me.Clear_BTN.TabIndex = 19
        Me.Clear_BTN.Text = "Clear"
        Me.Clear_BTN.UseVisualStyleBackColor = False
        '
        'Save_BTN
        '
        Me.Save_BTN.BackColor = System.Drawing.Color.DarkSalmon
        Me.Save_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Save_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Save_BTN.Location = New System.Drawing.Point(920, 143)
        Me.Save_BTN.Name = "Save_BTN"
        Me.Save_BTN.Size = New System.Drawing.Size(57, 36)
        Me.Save_BTN.TabIndex = 18
        Me.Save_BTN.Text = "Save"
        Me.Save_BTN.UseVisualStyleBackColor = False
        '
        'Modify_BTN
        '
        Me.Modify_BTN.BackColor = System.Drawing.Color.Silver
        Me.Modify_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Modify_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Modify_BTN.Location = New System.Drawing.Point(4, 13)
        Me.Modify_BTN.Name = "Modify_BTN"
        Me.Modify_BTN.Size = New System.Drawing.Size(87, 36)
        Me.Modify_BTN.TabIndex = 105
        Me.Modify_BTN.Text = "Modify"
        Me.Modify_BTN.UseVisualStyleBackColor = False
        '
        'ComPrev_BTN
        '
        Me.ComPrev_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComPrev_BTN.Location = New System.Drawing.Point(1059, 13)
        Me.ComPrev_BTN.Name = "ComPrev_BTN"
        Me.ComPrev_BTN.Size = New System.Drawing.Size(87, 36)
        Me.ComPrev_BTN.TabIndex = 104
        Me.ComPrev_BTN.Text = "Preview"
        Me.ComPrev_BTN.UseVisualStyleBackColor = True
        '
        'RptViewer_Count
        '
        ReportDataSource3.Name = "DataSet1"
        ReportDataSource3.Value = Me.CommonBindingSource
        Me.RptViewer_Count.LocalReport.DataSources.Add(ReportDataSource3)
        Me.RptViewer_Count.LocalReport.ReportEmbeddedResource = "WindowsApp1.rpt_Common.rdlc"
        Me.RptViewer_Count.Location = New System.Drawing.Point(4, 61)
        Me.RptViewer_Count.Name = "RptViewer_Count"
        Me.RptViewer_Count.ServerReport.BearerToken = Nothing
        Me.RptViewer_Count.Size = New System.Drawing.Size(1142, 527)
        Me.RptViewer_Count.TabIndex = 103
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 41)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1151, 591)
        Me.TabPage2.TabIndex = 5
        Me.TabPage2.Text = "    Payroll Summary    "
        Me.TabPage2.UseVisualStyleBackColor = True
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
        'frmReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1169, 665)
        Me.Controls.Add(Me.Close_LBL)
        Me.Controls.Add(Me.Reports_Tab)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmReport"
        Me.Text = "frmReport"
        CType(Me.NetPayBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.reports, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CommonDistributionBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CommonBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Reports_Tab.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.d.ResumeLayout(False)
        Me.Modify_Panel.ResumeLayout(False)
        Me.Modify_Panel.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Reports_Tab As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents Label20 As Label
    Friend WithEvents PaydateNet_ComboB As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Close_LBL As Label
    Friend WithEvents d As TabPage
    Friend WithEvents ReportV_NetPay As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents NetPayBindingSource As BindingSource
    Friend WithEvents reports As reports
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
    Friend WithEvents RptViewer_Count As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents Button1 As Button
    Friend WithEvents CommonBindingSource As BindingSource
    Friend WithEvents ComPrev_BTN As Button
    Friend WithEvents Modify_BTN As Button
    Friend WithEvents Modify_Panel As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents M_Photo_TXT As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents M_DaltonP_TXT As TextBox
    Friend WithEvents Clear_BTN As Button
    Friend WithEvents Save_BTN As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents M_Perfecom_TXT As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents M_DavaoP_TXT As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents D_Perfecom_TXT As TextBox
    Friend WithEvents D_DavaoP_TXT As TextBox
    Friend WithEvents D_Photo_TXT As TextBox
    Friend WithEvents D_DaltonP_TXT As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents DR_House_TXT As TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents DR_Photo_TXT As TextBox
    Friend WithEvents DR_Dalton_TXT As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents ConHouse_TXT As TextBox
    Friend WithEvents ConPhoto_TXT As TextBox
    Friend WithEvents ConDalton_TXT As TextBox
    Friend WithEvents Label29 As Label
    Friend WithEvents LeasingBR_TXT As TextBox
    Friend WithEvents Label26 As Label
    Friend WithEvents RptViewer_Common As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents DTR_Photo_TXT As TextBox
    Friend WithEvents DTR_Dalton_TXT As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents PaydateCom_Combo As ComboBox
    Friend WithEvents CommonDistributionBindingSource As BindingSource
    Friend WithEvents Label28 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents LeasingP_TXT As TextBox
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Label31 As Label
    Friend WithEvents NetBranch_Combo As ComboBox
    Friend WithEvents Label32 As Label
    Friend WithEvents Label33 As Label
    Friend WithEvents Label34 As Label
    Friend WithEvents L_PG711_TXT As TextBox
    Friend WithEvents L_Dalton_TXT As TextBox
    Friend WithEvents Label35 As Label
End Class
