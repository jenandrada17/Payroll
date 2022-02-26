<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAllowance
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
        Dim ReportDataSource6 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.PAFBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Forms = New WindowsApp1.Forms()
        Me.Close_LBL = New System.Windows.Forms.Label()
        Me.Allowance_Tab = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Allow_Search_BTN = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Allow_Category_Combo = New System.Windows.Forms.ComboBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Allow_Schedule_Combo = New System.Windows.Forms.ComboBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.A_EveryDate_Combo = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Allow_Amount_TXT = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.A_EffectiveDate_DTP = New System.Windows.Forms.DateTimePicker()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.FixYes_RadioB = New System.Windows.Forms.RadioButton()
        Me.FixNo_RadioB = New System.Windows.Forms.RadioButton()
        Me.Allow_Cancel_BTN = New System.Windows.Forms.Button()
        Me.Allow_Search_TXT = New System.Windows.Forms.TextBox()
        Me.Allowance_LV = New System.Windows.Forms.ListView()
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Allow_SearchEmp_BTN = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Allow_Name_TXT = New System.Windows.Forms.TextBox()
        Me.Allow_Save_BTN = New System.Windows.Forms.Button()
        Me.Form_Tab = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DeptTo_txt = New System.Windows.Forms.TextBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.DeptFrom_txt = New System.Windows.Forms.TextBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.PI_SchedTo_CB = New System.Windows.Forms.ComboBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.PI_SchedFrom_CB = New System.Windows.Forms.ComboBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Remarks_txt = New System.Windows.Forms.RichTextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.F_Calcel_btn = New System.Windows.Forms.Button()
        Me.F_Save_btn = New System.Windows.Forms.Button()
        Me.F_Preview_btn = New System.Windows.Forms.Button()
        Me.PIEffectTo_dtp = New System.Windows.Forms.DateTimePicker()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.PIEffectFrom_dtp = New System.Windows.Forms.DateTimePicker()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.PITo_txt = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.PIFrom_txt = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.SalryEffectTo_dtp = New System.Windows.Forms.DateTimePicker()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.SalryEffectFrom_dtp = New System.Windows.Forms.DateTimePicker()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.SalaryTo_txt = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.SalaryFrom_txt = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.JobLevelTo_txt = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.JobLevelFrom_txt = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.JobTitleTo_txt = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.JobTitleFrom_txt = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.CompanyT0_txt = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.CompanyFrom_txt = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.SalesCharges_CB = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Employment_CB = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Marital_CB = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Gender_CB = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TIN_txt = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.SSS_txt = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.DateHire_txt = New System.Windows.Forms.TextBox()
        Me.Bdate_txt = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Address_txt = New System.Windows.Forms.TextBox()
        Me.DatePrepared_dtp = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.EmpNo_txt = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SearchEMP_BTN = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BiometricID_TXT = New System.Windows.Forms.TextBox()
        Me.Name_TXT = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.rpt_Allowance = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Context_Allow = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Edit_MenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.PAFBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Forms, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Allowance_Tab.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.Form_Tab.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Context_Allow.SuspendLayout()
        Me.SuspendLayout()
        '
        'PAFBindingSource
        '
        Me.PAFBindingSource.DataMember = "PAF"
        Me.PAFBindingSource.DataSource = Me.Forms
        '
        'Forms
        '
        Me.Forms.DataSetName = "Forms"
        Me.Forms.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Close_LBL
        '
        Me.Close_LBL.AutoSize = True
        Me.Close_LBL.Font = New System.Drawing.Font("Dubai", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Close_LBL.Location = New System.Drawing.Point(1114, -2)
        Me.Close_LBL.Name = "Close_LBL"
        Me.Close_LBL.Size = New System.Drawing.Size(57, 32)
        Me.Close_LBL.TabIndex = 75
        Me.Close_LBL.Text = "Close"
        '
        'Allowance_Tab
        '
        Me.Allowance_Tab.Controls.Add(Me.TabPage1)
        Me.Allowance_Tab.Controls.Add(Me.Form_Tab)
        Me.Allowance_Tab.Controls.Add(Me.TabPage2)
        Me.Allowance_Tab.Font = New System.Drawing.Font("Dubai", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Allowance_Tab.Location = New System.Drawing.Point(5, 30)
        Me.Allowance_Tab.Name = "Allowance_Tab"
        Me.Allowance_Tab.SelectedIndex = 0
        Me.Allowance_Tab.Size = New System.Drawing.Size(1159, 636)
        Me.Allowance_Tab.TabIndex = 77
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Allow_Search_BTN)
        Me.TabPage1.Controls.Add(Me.FlowLayoutPanel1)
        Me.TabPage1.Controls.Add(Me.Allow_Cancel_BTN)
        Me.TabPage1.Controls.Add(Me.Allow_Search_TXT)
        Me.TabPage1.Controls.Add(Me.Allowance_LV)
        Me.TabPage1.Controls.Add(Me.Allow_SearchEmp_BTN)
        Me.TabPage1.Controls.Add(Me.Label14)
        Me.TabPage1.Controls.Add(Me.Allow_Name_TXT)
        Me.TabPage1.Controls.Add(Me.Allow_Save_BTN)
        Me.TabPage1.Location = New System.Drawing.Point(4, 41)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1151, 591)
        Me.TabPage1.TabIndex = 1
        Me.TabPage1.Text = "    List of Allowances    "
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Allow_Search_BTN
        '
        Me.Allow_Search_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Allow_Search_BTN.Location = New System.Drawing.Point(788, 29)
        Me.Allow_Search_BTN.Name = "Allow_Search_BTN"
        Me.Allow_Search_BTN.Size = New System.Drawing.Size(110, 33)
        Me.Allow_Search_BTN.TabIndex = 135
        Me.Allow_Search_BTN.Text = "Search"
        Me.Allow_Search_BTN.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.Label13)
        Me.FlowLayoutPanel1.Controls.Add(Me.Allow_Category_Combo)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label30)
        Me.FlowLayoutPanel1.Controls.Add(Me.Allow_Schedule_Combo)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label32)
        Me.FlowLayoutPanel1.Controls.Add(Me.A_EveryDate_Combo)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label16)
        Me.FlowLayoutPanel1.Controls.Add(Me.Allow_Amount_TXT)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label29)
        Me.FlowLayoutPanel1.Controls.Add(Me.A_EffectiveDate_DTP)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label25)
        Me.FlowLayoutPanel1.Controls.Add(Me.FixYes_RadioB)
        Me.FlowLayoutPanel1.Controls.Add(Me.FixNo_RadioB)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(14, 102)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(20)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(390, 243)
        Me.FlowLayoutPanel1.TabIndex = 134
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(3, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(70, 27)
        Me.Label13.TabIndex = 102
        Me.Label13.Text = "Category"
        '
        'Allow_Category_Combo
        '
        Me.Allow_Category_Combo.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Allow_Category_Combo.FormattingEnabled = True
        Me.Allow_Category_Combo.Location = New System.Drawing.Point(79, 3)
        Me.Allow_Category_Combo.Name = "Allow_Category_Combo"
        Me.Allow_Category_Combo.Size = New System.Drawing.Size(291, 33)
        Me.Allow_Category_Combo.TabIndex = 34
        Me.Allow_Category_Combo.Text = "Select "
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(3, 39)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(70, 27)
        Me.Label30.TabIndex = 127
        Me.Label30.Text = "Schedule"
        '
        'Allow_Schedule_Combo
        '
        Me.Allow_Schedule_Combo.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Allow_Schedule_Combo.FormattingEnabled = True
        Me.Allow_Schedule_Combo.Items.AddRange(New Object() {"OPEN PAYROLL", "CLOSE PAYROLL", "EVERY PAYROLL"})
        Me.Allow_Schedule_Combo.Location = New System.Drawing.Point(79, 42)
        Me.Allow_Schedule_Combo.Name = "Allow_Schedule_Combo"
        Me.Allow_Schedule_Combo.Size = New System.Drawing.Size(291, 33)
        Me.Allow_Schedule_Combo.TabIndex = 35
        Me.Allow_Schedule_Combo.Text = "Select "
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(3, 78)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(72, 27)
        Me.Label32.TabIndex = 131
        Me.Label32.Text = "Every      "
        Me.Label32.Visible = False
        '
        'A_EveryDate_Combo
        '
        Me.A_EveryDate_Combo.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.A_EveryDate_Combo.FormattingEnabled = True
        Me.A_EveryDate_Combo.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
        Me.A_EveryDate_Combo.Location = New System.Drawing.Point(81, 81)
        Me.A_EveryDate_Combo.Name = "A_EveryDate_Combo"
        Me.A_EveryDate_Combo.Size = New System.Drawing.Size(289, 33)
        Me.A_EveryDate_Combo.TabIndex = 36
        Me.A_EveryDate_Combo.Text = "Select date of the month"
        Me.A_EveryDate_Combo.Visible = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(3, 117)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(72, 27)
        Me.Label16.TabIndex = 95
        Me.Label16.Text = "Amount  "
        '
        'Allow_Amount_TXT
        '
        Me.Allow_Amount_TXT.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Allow_Amount_TXT.Location = New System.Drawing.Point(81, 120)
        Me.Allow_Amount_TXT.Name = "Allow_Amount_TXT"
        Me.Allow_Amount_TXT.Size = New System.Drawing.Size(289, 33)
        Me.Allow_Amount_TXT.TabIndex = 37
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(3, 156)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(73, 25)
        Me.Label29.TabIndex = 125
        Me.Label29.Text = "Effectivity"
        '
        'A_EffectiveDate_DTP
        '
        Me.A_EffectiveDate_DTP.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.A_EffectiveDate_DTP.Location = New System.Drawing.Point(82, 159)
        Me.A_EffectiveDate_DTP.Name = "A_EffectiveDate_DTP"
        Me.A_EffectiveDate_DTP.Size = New System.Drawing.Size(288, 33)
        Me.A_EffectiveDate_DTP.TabIndex = 38
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(3, 195)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(75, 27)
        Me.Label25.TabIndex = 111
        Me.Label25.Text = "Fix           "
        '
        'FixYes_RadioB
        '
        Me.FixYes_RadioB.AutoSize = True
        Me.FixYes_RadioB.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FixYes_RadioB.Location = New System.Drawing.Point(84, 198)
        Me.FixYes_RadioB.Name = "FixYes_RadioB"
        Me.FixYes_RadioB.Size = New System.Drawing.Size(86, 31)
        Me.FixYes_RadioB.TabIndex = 39
        Me.FixYes_RadioB.Text = "Yes        "
        Me.FixYes_RadioB.UseVisualStyleBackColor = True
        '
        'FixNo_RadioB
        '
        Me.FixNo_RadioB.AutoSize = True
        Me.FixNo_RadioB.Checked = True
        Me.FixNo_RadioB.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FixNo_RadioB.Location = New System.Drawing.Point(176, 198)
        Me.FixNo_RadioB.Name = "FixNo_RadioB"
        Me.FixNo_RadioB.Size = New System.Drawing.Size(49, 31)
        Me.FixNo_RadioB.TabIndex = 30
        Me.FixNo_RadioB.TabStop = True
        Me.FixNo_RadioB.Text = "No"
        Me.FixNo_RadioB.UseVisualStyleBackColor = True
        '
        'Allow_Cancel_BTN
        '
        Me.Allow_Cancel_BTN.BackColor = System.Drawing.Color.PeachPuff
        Me.Allow_Cancel_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Allow_Cancel_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Allow_Cancel_BTN.Location = New System.Drawing.Point(85, 388)
        Me.Allow_Cancel_BTN.Name = "Allow_Cancel_BTN"
        Me.Allow_Cancel_BTN.Size = New System.Drawing.Size(116, 33)
        Me.Allow_Cancel_BTN.TabIndex = 133
        Me.Allow_Cancel_BTN.Text = "Cancel"
        Me.Allow_Cancel_BTN.UseVisualStyleBackColor = False
        '
        'Allow_Search_TXT
        '
        Me.Allow_Search_TXT.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Allow_Search_TXT.Location = New System.Drawing.Point(456, 29)
        Me.Allow_Search_TXT.Name = "Allow_Search_TXT"
        Me.Allow_Search_TXT.Size = New System.Drawing.Size(326, 33)
        Me.Allow_Search_TXT.TabIndex = 127
        '
        'Allowance_LV
        '
        Me.Allowance_LV.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Allowance_LV.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader3, Me.ColumnHeader9, Me.ColumnHeader6, Me.ColumnHeader7})
        Me.Allowance_LV.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Allowance_LV.FullRowSelect = True
        Me.Allowance_LV.GridLines = True
        Me.Allowance_LV.HideSelection = False
        Me.Allowance_LV.Location = New System.Drawing.Point(456, 68)
        Me.Allowance_LV.MultiSelect = False
        Me.Allowance_LV.Name = "Allowance_LV"
        Me.Allowance_LV.Size = New System.Drawing.Size(689, 516)
        Me.Allowance_LV.TabIndex = 128
        Me.Allowance_LV.UseCompatibleStateImageBehavior = False
        Me.Allowance_LV.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Fullname"
        Me.ColumnHeader4.Width = 190
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Category"
        Me.ColumnHeader5.Width = 135
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Schedule"
        Me.ColumnHeader3.Width = 120
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Effectivity Date"
        Me.ColumnHeader9.Width = 120
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Amount"
        Me.ColumnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader6.Width = 100
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Approve"
        Me.ColumnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Allow_SearchEmp_BTN
        '
        Me.Allow_SearchEmp_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Allow_SearchEmp_BTN.Location = New System.Drawing.Point(386, 33)
        Me.Allow_SearchEmp_BTN.Name = "Allow_SearchEmp_BTN"
        Me.Allow_SearchEmp_BTN.Size = New System.Drawing.Size(47, 31)
        Me.Allow_SearchEmp_BTN.TabIndex = 129
        Me.Allow_SearchEmp_BTN.Text = "..."
        Me.Allow_SearchEmp_BTN.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(5, 35)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(49, 27)
        Me.Label14.TabIndex = 132
        Me.Label14.Text = "Name"
        '
        'Allow_Name_TXT
        '
        Me.Allow_Name_TXT.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Allow_Name_TXT.Location = New System.Drawing.Point(61, 31)
        Me.Allow_Name_TXT.Name = "Allow_Name_TXT"
        Me.Allow_Name_TXT.ReadOnly = True
        Me.Allow_Name_TXT.Size = New System.Drawing.Size(319, 33)
        Me.Allow_Name_TXT.TabIndex = 131
        '
        'Allow_Save_BTN
        '
        Me.Allow_Save_BTN.BackColor = System.Drawing.Color.DarkSalmon
        Me.Allow_Save_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Allow_Save_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Allow_Save_BTN.Location = New System.Drawing.Point(292, 388)
        Me.Allow_Save_BTN.Name = "Allow_Save_BTN"
        Me.Allow_Save_BTN.Size = New System.Drawing.Size(112, 33)
        Me.Allow_Save_BTN.TabIndex = 130
        Me.Allow_Save_BTN.Text = "Save"
        Me.Allow_Save_BTN.UseVisualStyleBackColor = False
        '
        'Form_Tab
        '
        Me.Form_Tab.Controls.Add(Me.Panel1)
        Me.Form_Tab.Controls.Add(Me.rpt_Allowance)
        Me.Form_Tab.Location = New System.Drawing.Point(4, 41)
        Me.Form_Tab.Name = "Form_Tab"
        Me.Form_Tab.Padding = New System.Windows.Forms.Padding(3)
        Me.Form_Tab.Size = New System.Drawing.Size(1151, 591)
        Me.Form_Tab.TabIndex = 0
        Me.Form_Tab.Text = "      Form      "
        Me.Form_Tab.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.DeptTo_txt)
        Me.Panel1.Controls.Add(Me.Label39)
        Me.Panel1.Controls.Add(Me.DeptFrom_txt)
        Me.Panel1.Controls.Add(Me.Label40)
        Me.Panel1.Controls.Add(Me.PI_SchedTo_CB)
        Me.Panel1.Controls.Add(Me.Label38)
        Me.Panel1.Controls.Add(Me.PI_SchedFrom_CB)
        Me.Panel1.Controls.Add(Me.Label37)
        Me.Panel1.Controls.Add(Me.Label36)
        Me.Panel1.Controls.Add(Me.Remarks_txt)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.PIEffectTo_dtp)
        Me.Panel1.Controls.Add(Me.Label31)
        Me.Panel1.Controls.Add(Me.PIEffectFrom_dtp)
        Me.Panel1.Controls.Add(Me.Label33)
        Me.Panel1.Controls.Add(Me.PITo_txt)
        Me.Panel1.Controls.Add(Me.Label34)
        Me.Panel1.Controls.Add(Me.PIFrom_txt)
        Me.Panel1.Controls.Add(Me.Label35)
        Me.Panel1.Controls.Add(Me.SalryEffectTo_dtp)
        Me.Panel1.Controls.Add(Me.Label28)
        Me.Panel1.Controls.Add(Me.SalryEffectFrom_dtp)
        Me.Panel1.Controls.Add(Me.Label27)
        Me.Panel1.Controls.Add(Me.SalaryTo_txt)
        Me.Panel1.Controls.Add(Me.Label24)
        Me.Panel1.Controls.Add(Me.SalaryFrom_txt)
        Me.Panel1.Controls.Add(Me.Label26)
        Me.Panel1.Controls.Add(Me.JobLevelTo_txt)
        Me.Panel1.Controls.Add(Me.Label22)
        Me.Panel1.Controls.Add(Me.JobLevelFrom_txt)
        Me.Panel1.Controls.Add(Me.Label23)
        Me.Panel1.Controls.Add(Me.JobTitleTo_txt)
        Me.Panel1.Controls.Add(Me.Label20)
        Me.Panel1.Controls.Add(Me.JobTitleFrom_txt)
        Me.Panel1.Controls.Add(Me.Label21)
        Me.Panel1.Controls.Add(Me.CompanyT0_txt)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.CompanyFrom_txt)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.SalesCharges_CB)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.Employment_CB)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.Marital_CB)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Gender_CB)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.TIN_txt)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.SSS_txt)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.DateHire_txt)
        Me.Panel1.Controls.Add(Me.Bdate_txt)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Address_txt)
        Me.Panel1.Controls.Add(Me.DatePrepared_dtp)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.EmpNo_txt)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.SearchEMP_BTN)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.BiometricID_TXT)
        Me.Panel1.Controls.Add(Me.Name_TXT)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Location = New System.Drawing.Point(639, 6)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(506, 579)
        Me.Panel1.TabIndex = 1
        '
        'DeptTo_txt
        '
        Me.DeptTo_txt.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DeptTo_txt.Location = New System.Drawing.Point(137, 595)
        Me.DeptTo_txt.Name = "DeptTo_txt"
        Me.DeptTo_txt.Size = New System.Drawing.Size(269, 29)
        Me.DeptTo_txt.TabIndex = 40
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(23, 596)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(67, 25)
        Me.Label39.TabIndex = 72
        Me.Label39.Text = "Dep't To"
        '
        'DeptFrom_txt
        '
        Me.DeptFrom_txt.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DeptFrom_txt.Location = New System.Drawing.Point(137, 557)
        Me.DeptFrom_txt.Name = "DeptFrom_txt"
        Me.DeptFrom_txt.Size = New System.Drawing.Size(269, 29)
        Me.DeptFrom_txt.TabIndex = 39
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(23, 560)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(83, 25)
        Me.Label40.TabIndex = 70
        Me.Label40.Text = "Dep't From"
        '
        'PI_SchedTo_CB
        '
        Me.PI_SchedTo_CB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PI_SchedTo_CB.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PI_SchedTo_CB.FormattingEnabled = True
        Me.PI_SchedTo_CB.Items.AddRange(New Object() {"every 15th month", "every 30th month", "every month"})
        Me.PI_SchedTo_CB.Location = New System.Drawing.Point(218, 1205)
        Me.PI_SchedTo_CB.Name = "PI_SchedTo_CB"
        Me.PI_SchedTo_CB.Size = New System.Drawing.Size(190, 30)
        Me.PI_SchedTo_CB.TabIndex = 66
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(25, 1207)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(86, 25)
        Me.Label38.TabIndex = 65
        Me.Label38.Text = "PI Sched To"
        '
        'PI_SchedFrom_CB
        '
        Me.PI_SchedFrom_CB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.PI_SchedFrom_CB.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PI_SchedFrom_CB.FormattingEnabled = True
        Me.PI_SchedFrom_CB.Items.AddRange(New Object() {"every 15th of the month", "every 30th of the month", "every month"})
        Me.PI_SchedFrom_CB.Location = New System.Drawing.Point(218, 1060)
        Me.PI_SchedFrom_CB.Name = "PI_SchedFrom_CB"
        Me.PI_SchedFrom_CB.Size = New System.Drawing.Size(190, 30)
        Me.PI_SchedFrom_CB.TabIndex = 60
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(25, 1062)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(102, 25)
        Me.Label37.TabIndex = 59
        Me.Label37.Text = "PI Sched From"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(25, 1285)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(65, 25)
        Me.Label36.TabIndex = 65
        Me.Label36.Text = "Remarks"
        '
        'Remarks_txt
        '
        Me.Remarks_txt.Location = New System.Drawing.Point(28, 1313)
        Me.Remarks_txt.Name = "Remarks_txt"
        Me.Remarks_txt.Size = New System.Drawing.Size(378, 96)
        Me.Remarks_txt.TabIndex = 67
        Me.Remarks_txt.Text = ""
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.F_Calcel_btn)
        Me.Panel2.Controls.Add(Me.F_Save_btn)
        Me.Panel2.Controls.Add(Me.F_Preview_btn)
        Me.Panel2.Location = New System.Drawing.Point(9, 1484)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(477, 61)
        Me.Panel2.TabIndex = 63
        '
        'F_Calcel_btn
        '
        Me.F_Calcel_btn.BackColor = System.Drawing.Color.PeachPuff
        Me.F_Calcel_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.F_Calcel_btn.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F_Calcel_btn.Location = New System.Drawing.Point(3, 18)
        Me.F_Calcel_btn.Name = "F_Calcel_btn"
        Me.F_Calcel_btn.Size = New System.Drawing.Size(115, 40)
        Me.F_Calcel_btn.TabIndex = 70
        Me.F_Calcel_btn.Text = "Cancel"
        Me.F_Calcel_btn.UseVisualStyleBackColor = False
        '
        'F_Save_btn
        '
        Me.F_Save_btn.BackColor = System.Drawing.Color.DarkSalmon
        Me.F_Save_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.F_Save_btn.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F_Save_btn.Location = New System.Drawing.Point(359, 18)
        Me.F_Save_btn.Name = "F_Save_btn"
        Me.F_Save_btn.Size = New System.Drawing.Size(115, 40)
        Me.F_Save_btn.TabIndex = 72
        Me.F_Save_btn.Text = "Save"
        Me.F_Save_btn.UseVisualStyleBackColor = False
        '
        'F_Preview_btn
        '
        Me.F_Preview_btn.BackColor = System.Drawing.Color.MistyRose
        Me.F_Preview_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.F_Preview_btn.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F_Preview_btn.Location = New System.Drawing.Point(188, 21)
        Me.F_Preview_btn.Name = "F_Preview_btn"
        Me.F_Preview_btn.Size = New System.Drawing.Size(115, 40)
        Me.F_Preview_btn.TabIndex = 71
        Me.F_Preview_btn.Text = "Preview"
        Me.F_Preview_btn.UseVisualStyleBackColor = False
        '
        'PIEffectTo_dtp
        '
        Me.PIEffectTo_dtp.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PIEffectTo_dtp.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.PIEffectTo_dtp.Location = New System.Drawing.Point(218, 1163)
        Me.PIEffectTo_dtp.Name = "PIEffectTo_dtp"
        Me.PIEffectTo_dtp.Size = New System.Drawing.Size(188, 33)
        Me.PIEffectTo_dtp.TabIndex = 64
        Me.PIEffectTo_dtp.Value = New Date(1990, 1, 1, 0, 0, 0, 0)
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(23, 1169)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(98, 25)
        Me.Label31.TabIndex = 63
        Me.Label31.Text = "Effective Date"
        '
        'PIEffectFrom_dtp
        '
        Me.PIEffectFrom_dtp.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PIEffectFrom_dtp.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.PIEffectFrom_dtp.Location = New System.Drawing.Point(218, 1017)
        Me.PIEffectFrom_dtp.Name = "PIEffectFrom_dtp"
        Me.PIEffectFrom_dtp.Size = New System.Drawing.Size(188, 33)
        Me.PIEffectFrom_dtp.TabIndex = 58
        Me.PIEffectFrom_dtp.Value = New Date(1990, 1, 1, 0, 0, 0, 0)
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(23, 1023)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(98, 25)
        Me.Label33.TabIndex = 59
        Me.Label33.Text = "Effective Date"
        '
        'PITo_txt
        '
        Me.PITo_txt.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PITo_txt.Location = New System.Drawing.Point(218, 1125)
        Me.PITo_txt.Name = "PITo_txt"
        Me.PITo_txt.Size = New System.Drawing.Size(188, 29)
        Me.PITo_txt.TabIndex = 62
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(23, 1128)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(170, 25)
        Me.Label34.TabIndex = 61
        Me.Label34.Text = "Performance Incentive To"
        '
        'PIFrom_txt
        '
        Me.PIFrom_txt.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PIFrom_txt.Location = New System.Drawing.Point(218, 979)
        Me.PIFrom_txt.Name = "PIFrom_txt"
        Me.PIFrom_txt.Size = New System.Drawing.Size(188, 29)
        Me.PIFrom_txt.TabIndex = 56
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(23, 982)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(186, 25)
        Me.Label35.TabIndex = 55
        Me.Label35.Text = "Performance Incentive From"
        '
        'SalryEffectTo_dtp
        '
        Me.SalryEffectTo_dtp.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SalryEffectTo_dtp.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.SalryEffectTo_dtp.Location = New System.Drawing.Point(218, 922)
        Me.SalryEffectTo_dtp.Name = "SalryEffectTo_dtp"
        Me.SalryEffectTo_dtp.Size = New System.Drawing.Size(188, 33)
        Me.SalryEffectTo_dtp.TabIndex = 54
        Me.SalryEffectTo_dtp.Value = New Date(1990, 1, 1, 0, 0, 0, 0)
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(23, 928)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(98, 25)
        Me.Label28.TabIndex = 53
        Me.Label28.Text = "Effective Date"
        '
        'SalryEffectFrom_dtp
        '
        Me.SalryEffectFrom_dtp.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SalryEffectFrom_dtp.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.SalryEffectFrom_dtp.Location = New System.Drawing.Point(218, 842)
        Me.SalryEffectFrom_dtp.Name = "SalryEffectFrom_dtp"
        Me.SalryEffectFrom_dtp.Size = New System.Drawing.Size(188, 33)
        Me.SalryEffectFrom_dtp.TabIndex = 50
        Me.SalryEffectFrom_dtp.Value = New Date(1990, 1, 1, 0, 0, 0, 0)
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(23, 848)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(98, 25)
        Me.Label27.TabIndex = 49
        Me.Label27.Text = "Effective Date"
        '
        'SalaryTo_txt
        '
        Me.SalaryTo_txt.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SalaryTo_txt.Location = New System.Drawing.Point(218, 884)
        Me.SalaryTo_txt.Name = "SalaryTo_txt"
        Me.SalaryTo_txt.Size = New System.Drawing.Size(188, 29)
        Me.SalaryTo_txt.TabIndex = 52
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(23, 887)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(109, 25)
        Me.Label24.TabIndex = 51
        Me.Label24.Text = "Salary Wage To"
        '
        'SalaryFrom_txt
        '
        Me.SalaryFrom_txt.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SalaryFrom_txt.Location = New System.Drawing.Point(218, 804)
        Me.SalaryFrom_txt.Name = "SalaryFrom_txt"
        Me.SalaryFrom_txt.Size = New System.Drawing.Size(188, 29)
        Me.SalaryFrom_txt.TabIndex = 48
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(23, 807)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(125, 25)
        Me.Label26.TabIndex = 47
        Me.Label26.Text = "Salary Wage From"
        '
        'JobLevelTo_txt
        '
        Me.JobLevelTo_txt.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.JobLevelTo_txt.Location = New System.Drawing.Point(137, 750)
        Me.JobLevelTo_txt.Name = "JobLevelTo_txt"
        Me.JobLevelTo_txt.Size = New System.Drawing.Size(269, 29)
        Me.JobLevelTo_txt.TabIndex = 46
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(23, 753)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(92, 25)
        Me.Label22.TabIndex = 45
        Me.Label22.Text = "Job Level To"
        '
        'JobLevelFrom_txt
        '
        Me.JobLevelFrom_txt.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.JobLevelFrom_txt.Location = New System.Drawing.Point(137, 712)
        Me.JobLevelFrom_txt.Name = "JobLevelFrom_txt"
        Me.JobLevelFrom_txt.Size = New System.Drawing.Size(269, 29)
        Me.JobLevelFrom_txt.TabIndex = 43
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(23, 715)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(108, 25)
        Me.Label23.TabIndex = 43
        Me.Label23.Text = "Job Level From"
        '
        'JobTitleTo_txt
        '
        Me.JobTitleTo_txt.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.JobTitleTo_txt.Location = New System.Drawing.Point(137, 673)
        Me.JobTitleTo_txt.Name = "JobTitleTo_txt"
        Me.JobTitleTo_txt.Size = New System.Drawing.Size(269, 29)
        Me.JobTitleTo_txt.TabIndex = 42
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(23, 676)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(87, 25)
        Me.Label20.TabIndex = 41
        Me.Label20.Text = "Job Title To"
        '
        'JobTitleFrom_txt
        '
        Me.JobTitleFrom_txt.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.JobTitleFrom_txt.Location = New System.Drawing.Point(137, 635)
        Me.JobTitleFrom_txt.Name = "JobTitleFrom_txt"
        Me.JobTitleFrom_txt.Size = New System.Drawing.Size(269, 29)
        Me.JobTitleFrom_txt.TabIndex = 41
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(23, 638)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(103, 25)
        Me.Label21.TabIndex = 39
        Me.Label21.Text = "Job Title From"
        '
        'CompanyT0_txt
        '
        Me.CompanyT0_txt.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CompanyT0_txt.Location = New System.Drawing.Point(137, 519)
        Me.CompanyT0_txt.Name = "CompanyT0_txt"
        Me.CompanyT0_txt.Size = New System.Drawing.Size(269, 29)
        Me.CompanyT0_txt.TabIndex = 38
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(23, 522)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(92, 25)
        Me.Label19.TabIndex = 37
        Me.Label19.Text = "Company To"
        '
        'CompanyFrom_txt
        '
        Me.CompanyFrom_txt.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CompanyFrom_txt.Location = New System.Drawing.Point(137, 481)
        Me.CompanyFrom_txt.Name = "CompanyFrom_txt"
        Me.CompanyFrom_txt.Size = New System.Drawing.Size(269, 29)
        Me.CompanyFrom_txt.TabIndex = 36
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(23, 484)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(108, 25)
        Me.Label18.TabIndex = 35
        Me.Label18.Text = "Company From"
        '
        'SalesCharges_CB
        '
        Me.SalesCharges_CB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.SalesCharges_CB.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SalesCharges_CB.FormattingEnabled = True
        Me.SalesCharges_CB.Items.AddRange(New Object() {"PERFORMANCE INCENTIVE", "MERIT INCREASE", "ADJUSTMENT", "OTHERS"})
        Me.SalesCharges_CB.Location = New System.Drawing.Point(137, 441)
        Me.SalesCharges_CB.Name = "SalesCharges_CB"
        Me.SalesCharges_CB.Size = New System.Drawing.Size(269, 30)
        Me.SalesCharges_CB.TabIndex = 34
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(23, 443)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(102, 25)
        Me.Label17.TabIndex = 33
        Me.Label17.Text = "Salary Charges"
        '
        'Employment_CB
        '
        Me.Employment_CB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Employment_CB.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Employment_CB.FormattingEnabled = True
        Me.Employment_CB.Items.AddRange(New Object() {"INITIAL HIRE", "CONFIRMATION OF REGULAR EMPLOYMENT", "RE-HIRE", "OTHERS"})
        Me.Employment_CB.Location = New System.Drawing.Point(137, 402)
        Me.Employment_CB.Name = "Employment_CB"
        Me.Employment_CB.Size = New System.Drawing.Size(269, 30)
        Me.Employment_CB.TabIndex = 32
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(23, 404)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(97, 25)
        Me.Label15.TabIndex = 31
        Me.Label15.Text = "Employement"
        '
        'Marital_CB
        '
        Me.Marital_CB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Marital_CB.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Marital_CB.FormattingEnabled = True
        Me.Marital_CB.Items.AddRange(New Object() {"SINGLE", "MARRIED", "SEPARATED", "WIDOWED"})
        Me.Marital_CB.Location = New System.Drawing.Point(137, 363)
        Me.Marital_CB.Name = "Marital_CB"
        Me.Marital_CB.Size = New System.Drawing.Size(269, 30)
        Me.Marital_CB.TabIndex = 30
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(23, 365)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(97, 25)
        Me.Label12.TabIndex = 29
        Me.Label12.Text = "Marital Status"
        '
        'Gender_CB
        '
        Me.Gender_CB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Gender_CB.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Gender_CB.FormattingEnabled = True
        Me.Gender_CB.Items.AddRange(New Object() {"MALE", "FEMALE"})
        Me.Gender_CB.Location = New System.Drawing.Point(137, 324)
        Me.Gender_CB.Name = "Gender_CB"
        Me.Gender_CB.Size = New System.Drawing.Size(269, 30)
        Me.Gender_CB.TabIndex = 28
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(23, 326)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(57, 25)
        Me.Label11.TabIndex = 27
        Me.Label11.Text = "Gender"
        '
        'TIN_txt
        '
        Me.TIN_txt.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TIN_txt.Location = New System.Drawing.Point(137, 285)
        Me.TIN_txt.Name = "TIN_txt"
        Me.TIN_txt.ReadOnly = True
        Me.TIN_txt.Size = New System.Drawing.Size(269, 29)
        Me.TIN_txt.TabIndex = 26
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(23, 291)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(60, 25)
        Me.Label10.TabIndex = 25
        Me.Label10.Text = "TIN No."
        '
        'SSS_txt
        '
        Me.SSS_txt.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SSS_txt.Location = New System.Drawing.Point(137, 247)
        Me.SSS_txt.Name = "SSS_txt"
        Me.SSS_txt.ReadOnly = True
        Me.SSS_txt.Size = New System.Drawing.Size(269, 29)
        Me.SSS_txt.TabIndex = 24
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(23, 253)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(61, 25)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "SSS No."
        '
        'DateHire_txt
        '
        Me.DateHire_txt.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateHire_txt.Location = New System.Drawing.Point(137, 209)
        Me.DateHire_txt.Name = "DateHire_txt"
        Me.DateHire_txt.ReadOnly = True
        Me.DateHire_txt.Size = New System.Drawing.Size(269, 29)
        Me.DateHire_txt.TabIndex = 22
        '
        'Bdate_txt
        '
        Me.Bdate_txt.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bdate_txt.Location = New System.Drawing.Point(137, 172)
        Me.Bdate_txt.Name = "Bdate_txt"
        Me.Bdate_txt.ReadOnly = True
        Me.Bdate_txt.Size = New System.Drawing.Size(269, 29)
        Me.Bdate_txt.TabIndex = 20
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(23, 137)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 25)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Address"
        '
        'Address_txt
        '
        Me.Address_txt.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Address_txt.Location = New System.Drawing.Point(137, 137)
        Me.Address_txt.Name = "Address_txt"
        Me.Address_txt.ReadOnly = True
        Me.Address_txt.Size = New System.Drawing.Size(269, 29)
        Me.Address_txt.TabIndex = 18
        '
        'DatePrepared_dtp
        '
        Me.DatePrepared_dtp.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DatePrepared_dtp.Location = New System.Drawing.Point(137, 1414)
        Me.DatePrepared_dtp.Name = "DatePrepared_dtp"
        Me.DatePrepared_dtp.Size = New System.Drawing.Size(269, 33)
        Me.DatePrepared_dtp.TabIndex = 69
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(23, 1420)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 25)
        Me.Label7.TabIndex = 68
        Me.Label7.Text = "Date Prepared"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(23, 215)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 25)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Date of Hire"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(23, 100)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 25)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Employee No."
        '
        'EmpNo_txt
        '
        Me.EmpNo_txt.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EmpNo_txt.Location = New System.Drawing.Point(137, 100)
        Me.EmpNo_txt.Name = "EmpNo_txt"
        Me.EmpNo_txt.ReadOnly = True
        Me.EmpNo_txt.Size = New System.Drawing.Size(269, 29)
        Me.EmpNo_txt.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(23, 176)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 25)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Date of Birth"
        '
        'SearchEMP_BTN
        '
        Me.SearchEMP_BTN.Location = New System.Drawing.Point(428, 66)
        Me.SearchEMP_BTN.Name = "SearchEMP_BTN"
        Me.SearchEMP_BTN.Size = New System.Drawing.Size(35, 26)
        Me.SearchEMP_BTN.TabIndex = 8
        Me.SearchEMP_BTN.Text = "..."
        Me.SearchEMP_BTN.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(23, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 25)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Name"
        '
        'BiometricID_TXT
        '
        Me.BiometricID_TXT.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BiometricID_TXT.Location = New System.Drawing.Point(137, 25)
        Me.BiometricID_TXT.Name = "BiometricID_TXT"
        Me.BiometricID_TXT.Size = New System.Drawing.Size(269, 29)
        Me.BiometricID_TXT.TabIndex = 1
        '
        'Name_TXT
        '
        Me.Name_TXT.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name_TXT.Location = New System.Drawing.Point(137, 62)
        Me.Name_TXT.Name = "Name_TXT"
        Me.Name_TXT.ReadOnly = True
        Me.Name_TXT.Size = New System.Drawing.Size(269, 29)
        Me.Name_TXT.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(23, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 25)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Biometric ID"
        '
        'rpt_Allowance
        '
        ReportDataSource6.Name = "DataSet1"
        ReportDataSource6.Value = Me.PAFBindingSource
        Me.rpt_Allowance.LocalReport.DataSources.Add(ReportDataSource6)
        Me.rpt_Allowance.LocalReport.ReportEmbeddedResource = "WindowsApp1.rpt_PAF.rdlc"
        Me.rpt_Allowance.Location = New System.Drawing.Point(6, 6)
        Me.rpt_Allowance.Name = "rpt_Allowance"
        Me.rpt_Allowance.ServerReport.BearerToken = Nothing
        Me.rpt_Allowance.Size = New System.Drawing.Size(627, 576)
        Me.rpt_Allowance.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 41)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1151, 591)
        Me.TabPage2.TabIndex = 4
        Me.TabPage2.Text = "      Approval      "
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Dubai", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(4, -2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 36)
        Me.Label1.TabIndex = 76
        Me.Label1.Text = "Allowance"
        '
        'Context_Allow
        '
        Me.Context_Allow.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Edit_MenuItem})
        Me.Context_Allow.Name = "ContextMenuStrip1"
        Me.Context_Allow.Size = New System.Drawing.Size(95, 26)
        '
        'Edit_MenuItem
        '
        Me.Edit_MenuItem.Name = "Edit_MenuItem"
        Me.Edit_MenuItem.Size = New System.Drawing.Size(94, 22)
        Me.Edit_MenuItem.Text = "Edit"
        '
        'frmAllowance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1169, 665)
        Me.Controls.Add(Me.Allowance_Tab)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Close_LBL)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmAllowance"
        Me.Text = "frmAllowance"
        CType(Me.PAFBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Forms, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Allowance_Tab.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.Form_Tab.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Context_Allow.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Close_LBL As Label
    Friend WithEvents Allowance_Tab As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents Form_Tab As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Label1 As Label
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents Label13 As Label
    Friend WithEvents Allow_Category_Combo As ComboBox
    Friend WithEvents Label30 As Label
    Friend WithEvents Allow_Schedule_Combo As ComboBox
    Friend WithEvents Label32 As Label
    Friend WithEvents A_EveryDate_Combo As ComboBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Allow_Amount_TXT As TextBox
    Friend WithEvents Label29 As Label
    Friend WithEvents A_EffectiveDate_DTP As DateTimePicker
    Friend WithEvents Label25 As Label
    Friend WithEvents FixYes_RadioB As RadioButton
    Friend WithEvents FixNo_RadioB As RadioButton
    Friend WithEvents Allow_Cancel_BTN As Button
    Friend WithEvents Allow_Search_TXT As TextBox
    Friend WithEvents Allowance_LV As ListView
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader9 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents Allow_SearchEmp_BTN As Button
    Friend WithEvents Label14 As Label
    Friend WithEvents Allow_Name_TXT As TextBox
    Friend WithEvents Allow_Save_BTN As Button
    Friend WithEvents Allow_Search_BTN As Button
    Friend WithEvents Context_Allow As ContextMenuStrip
    Friend WithEvents Edit_MenuItem As ToolStripMenuItem
    Friend WithEvents rpt_Allowance As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents PAFBindingSource As BindingSource
    Friend WithEvents Forms As Forms
    Friend WithEvents Panel1 As Panel
    Friend WithEvents SearchEMP_BTN As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Name_TXT As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents BiometricID_TXT As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents EmpNo_txt As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents DatePrepared_dtp As DateTimePicker
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Address_txt As TextBox
    Friend WithEvents DateHire_txt As TextBox
    Friend WithEvents Bdate_txt As TextBox
    Friend WithEvents TIN_txt As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents SSS_txt As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Gender_CB As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Marital_CB As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Employment_CB As ComboBox
    Friend WithEvents Label15 As Label
    Friend WithEvents SalesCharges_CB As ComboBox
    Friend WithEvents Label17 As Label
    Friend WithEvents CompanyFrom_txt As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents CompanyT0_txt As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents JobTitleTo_txt As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents JobTitleFrom_txt As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents JobLevelTo_txt As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents JobLevelFrom_txt As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents SalaryTo_txt As TextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents SalaryFrom_txt As TextBox
    Friend WithEvents Label26 As Label
    Friend WithEvents SalryEffectFrom_dtp As DateTimePicker
    Friend WithEvents Label27 As Label
    Friend WithEvents SalryEffectTo_dtp As DateTimePicker
    Friend WithEvents Label28 As Label
    Friend WithEvents PIEffectTo_dtp As DateTimePicker
    Friend WithEvents Label31 As Label
    Friend WithEvents PIEffectFrom_dtp As DateTimePicker
    Friend WithEvents Label33 As Label
    Friend WithEvents PITo_txt As TextBox
    Friend WithEvents Label34 As Label
    Friend WithEvents PIFrom_txt As TextBox
    Friend WithEvents Label35 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label36 As Label
    Friend WithEvents Remarks_txt As RichTextBox
    Friend WithEvents F_Save_btn As Button
    Friend WithEvents F_Preview_btn As Button
    Friend WithEvents F_Calcel_btn As Button
    Friend WithEvents PI_SchedFrom_CB As ComboBox
    Friend WithEvents Label37 As Label
    Friend WithEvents PI_SchedTo_CB As ComboBox
    Friend WithEvents Label38 As Label
    Friend WithEvents DeptTo_txt As TextBox
    Friend WithEvents Label39 As Label
    Friend WithEvents DeptFrom_txt As TextBox
    Friend WithEvents Label40 As Label
End Class
