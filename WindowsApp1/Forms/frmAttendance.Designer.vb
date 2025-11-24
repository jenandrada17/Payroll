<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAttendance
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.overAllBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dtr_all = New WindowsApp1.dtr_all()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Attendance_Tab = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.PI_Panel = New System.Windows.Forms.Panel()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.AddPIDays_btn = New System.Windows.Forms.Button()
        Me.P_Add_Panel = New System.Windows.Forms.Panel()
        Me.PI_Days = New System.Windows.Forms.NumericUpDown()
        Me.PIDaysX_btn = New System.Windows.Forms.Button()
        Me.PIDaysCheck_btn = New System.Windows.Forms.Button()
        Me.PIDays_lbl = New System.Windows.Forms.Label()
        Me.Biometric_LV = New System.Windows.Forms.ListView()
        Me.ColumnHeader17 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader18 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader19 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader20 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Search_TXT = New System.Windows.Forms.TextBox()
        Me.Search_BTN = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Paydate_ComboB = New System.Windows.Forms.ComboBox()
        Me.Import_BTN = New System.Windows.Forms.Button()
        Me.Path_TXT = New System.Windows.Forms.TextBox()
        Me.OpenFile_BTN = New System.Windows.Forms.Button()
        Me.Manual_Tab = New System.Windows.Forms.TabPage()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Cancel_lbl = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.AM_OT_NUP = New System.Windows.Forms.NumericUpDown()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.SIL_Panel = New System.Windows.Forms.Panel()
        Me.SIL_NUP = New System.Windows.Forms.NumericUpDown()
        Me.CancelSIL_BTN = New System.Windows.Forms.Button()
        Me.AddSIL_BTN = New System.Windows.Forms.Button()
        Me.SIL_BTN = New System.Windows.Forms.Button()
        Me.UT_BTN = New System.Windows.Forms.Button()
        Me.Late_BTN = New System.Windows.Forms.Button()
        Me.OT_BTN = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TotalRHoliday_LBL = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TotalOTHr_LBL = New System.Windows.Forms.Label()
        Me.TotalSHoliday_LBL = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Cancel_BTN = New System.Windows.Forms.Button()
        Me.Save_BTN = New System.Windows.Forms.Button()
        Me.Calculate_BTN = New System.Windows.Forms.Button()
        Me.TotalUTHR_LBL = New System.Windows.Forms.Label()
        Me.TotalLateHR_LBL = New System.Windows.Forms.Label()
        Me.SIL_LBL = New System.Windows.Forms.Label()
        Me.TotalDays_LBL = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.CheckALL_CheckBox = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Date_DataGrid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AM_In_DataGrid = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.AM_Out_DataGrid = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.PM_IN_DataGrid = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.PM_Out_DataGrid = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Select_Datagrid = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.TimeOut_TXT = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.TimeIn_TXT = New System.Windows.Forms.TextBox()
        Me.SearchEMP_BTN = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Name_TXT = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BiometricID_TXT = New System.Windows.Forms.TextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.B_PI_Panel = New System.Windows.Forms.Panel()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.B_P_Add_Panel = New System.Windows.Forms.Panel()
        Me.B_PI_Days = New System.Windows.Forms.NumericUpDown()
        Me.B_PIDaysX_btn = New System.Windows.Forms.Button()
        Me.B_PIDaysCheck_btn = New System.Windows.Forms.Button()
        Me.B_AddPIDays_btn = New System.Windows.Forms.Button()
        Me.B_PIDays_lbl = New System.Windows.Forms.Label()
        Me.Browse7_BTN = New System.Windows.Forms.Button()
        Me.Path7_TXT = New System.Windows.Forms.TextBox()
        Me.Import7_BTN = New System.Windows.Forms.Button()
        Me.Branch_LV = New System.Windows.Forms.ListView()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Paydate7_CB = New System.Windows.Forms.ComboBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.newRateOT_NUP = New System.Windows.Forms.NumericUpDown()
        Me.txtNewRateUT = New System.Windows.Forms.TextBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.txtNewRateLate = New System.Windows.Forms.TextBox()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.NewRateDaysCovered_NUP = New System.Windows.Forms.NumericUpDown()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.txtRegNightShiftOT = New System.Windows.Forms.TextBox()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.txtSpecNightShiftOT = New System.Windows.Forms.TextBox()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.txtOrdNightShiftOT = New System.Windows.Forms.TextBox()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.txtRegRestDayOT = New System.Windows.Forms.TextBox()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.txtRegOT = New System.Windows.Forms.TextBox()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.txtSpecRestDayOT = New System.Windows.Forms.TextBox()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.txtSpecOT = New System.Windows.Forms.TextBox()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.txtRestDayOT = New System.Windows.Forms.TextBox()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.txtRegNightShift = New System.Windows.Forms.TextBox()
        Me.txtRegRestDay = New System.Windows.Forms.TextBox()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.txtSpecRestDay = New System.Windows.Forms.TextBox()
        Me.SIL7_NUP = New System.Windows.Forms.NumericUpDown()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtSpecNightShift = New System.Windows.Forms.TextBox()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.txtRestDayDuty = New System.Windows.Forms.TextBox()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Overtime7_NUP = New System.Windows.Forms.NumericUpDown()
        Me.Save7_BTN = New System.Windows.Forms.Button()
        Me.Cancel7_BTN = New System.Windows.Forms.Button()
        Me.SpecHol7_TXT = New System.Windows.Forms.TextBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Undertime7_TXT = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Days7_TXT = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.RegHol7_TXT = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Night7_TXT = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Late7_TXT = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Search7_TXT = New System.Windows.Forms.TextBox()
        Me.Search7_BTN = New System.Windows.Forms.Button()
        Me.SearchEmp7_BTN = New System.Windows.Forms.Button()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Emp7_TXT = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Bio7_TXT = New System.Windows.Forms.TextBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.GroupBranch_RadioB = New System.Windows.Forms.RadioButton()
        Me.Employee_RadioB = New System.Windows.Forms.RadioButton()
        Me.HO_RadioB = New System.Windows.Forms.RadioButton()
        Me.Preview_BTN = New System.Windows.Forms.Button()
        Me.CancelDTR_BTN = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.RptViewer_DTR = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Employee1_GroupB = New System.Windows.Forms.GroupBox()
        Me.DTR_Emp1_TXT = New System.Windows.Forms.TextBox()
        Me.Bio1_DTR_TXT = New System.Windows.Forms.TextBox()
        Me.EmpSelect1_BTN = New System.Windows.Forms.Button()
        Me.Employee2_GroupB = New System.Windows.Forms.GroupBox()
        Me.DTR_Emp2_TXT = New System.Windows.Forms.TextBox()
        Me.Bio2_DTR_TXT = New System.Windows.Forms.TextBox()
        Me.EmpSelect2_BTN = New System.Windows.Forms.Button()
        Me.Branch_group = New System.Windows.Forms.GroupBox()
        Me.Branch_DTR_TXT = New System.Windows.Forms.TextBox()
        Me.DTR_Branch_Combo = New System.Windows.Forms.ComboBox()
        Me.Email_BTN = New System.Windows.Forms.Button()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Payslip_DTR_Combo = New System.Windows.Forms.ComboBox()
        Me.ContextMenu_Late = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Menu_Approve = New System.Windows.Forms.ToolStripMenuItem()
        Me.Close_LBL = New System.Windows.Forms.Label()
        Me.printDTRBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RE_UT_DGV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RE_LATE_DGV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RE_OT_DGV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RE_DAYS_DGV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RE_NAME_DGV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RE_BIO_DGV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RE_BRANCH_DGV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtNewRateRegHoliday = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.txtNewRateSpecHoliday = New System.Windows.Forms.TextBox()
        Me.Label42 = New System.Windows.Forms.Label()
        CType(Me.overAllBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtr_all, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Attendance_Tab.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.PI_Panel.SuspendLayout()
        Me.P_Add_Panel.SuspendLayout()
        CType(Me.PI_Days, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Manual_Tab.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.AM_OT_NUP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SIL_Panel.SuspendLayout()
        CType(Me.SIL_NUP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.B_PI_Panel.SuspendLayout()
        Me.B_P_Add_Panel.SuspendLayout()
        CType(Me.B_PI_Days, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.newRateOT_NUP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NewRateDaysCovered_NUP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SIL7_NUP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Overtime7_NUP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.Employee1_GroupB.SuspendLayout()
        Me.Employee2_GroupB.SuspendLayout()
        Me.Branch_group.SuspendLayout()
        Me.ContextMenu_Late.SuspendLayout()
        CType(Me.printDTRBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'overAllBindingSource
        '
        Me.overAllBindingSource.DataMember = "overAll"
        Me.overAllBindingSource.DataSource = Me.dtr_all
        '
        'dtr_all
        '
        Me.dtr_all.DataSetName = "dtr_all"
        Me.dtr_all.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Dubai", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, -4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 36)
        Me.Label1.TabIndex = 66
        Me.Label1.Text = "Attendance"
        '
        'Attendance_Tab
        '
        Me.Attendance_Tab.Controls.Add(Me.TabPage1)
        Me.Attendance_Tab.Controls.Add(Me.Manual_Tab)
        Me.Attendance_Tab.Controls.Add(Me.TabPage2)
        Me.Attendance_Tab.Controls.Add(Me.TabPage3)
        Me.Attendance_Tab.Font = New System.Drawing.Font("Dubai", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Attendance_Tab.Location = New System.Drawing.Point(4, 28)
        Me.Attendance_Tab.Name = "Attendance_Tab"
        Me.Attendance_Tab.SelectedIndex = 0
        Me.Attendance_Tab.Size = New System.Drawing.Size(1159, 636)
        Me.Attendance_Tab.TabIndex = 67
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.PI_Panel)
        Me.TabPage1.Controls.Add(Me.Biometric_LV)
        Me.TabPage1.Controls.Add(Me.Search_TXT)
        Me.TabPage1.Controls.Add(Me.Search_BTN)
        Me.TabPage1.Controls.Add(Me.Label20)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.Paydate_ComboB)
        Me.TabPage1.Controls.Add(Me.Import_BTN)
        Me.TabPage1.Controls.Add(Me.Path_TXT)
        Me.TabPage1.Controls.Add(Me.OpenFile_BTN)
        Me.TabPage1.Location = New System.Drawing.Point(4, 41)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1151, 591)
        Me.TabPage1.TabIndex = 1
        Me.TabPage1.Text = "    Head Office     "
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'PI_Panel
        '
        Me.PI_Panel.Controls.Add(Me.Label38)
        Me.PI_Panel.Controls.Add(Me.AddPIDays_btn)
        Me.PI_Panel.Controls.Add(Me.P_Add_Panel)
        Me.PI_Panel.Controls.Add(Me.PIDays_lbl)
        Me.PI_Panel.Location = New System.Drawing.Point(923, 3)
        Me.PI_Panel.Name = "PI_Panel"
        Me.PI_Panel.Size = New System.Drawing.Size(227, 100)
        Me.PI_Panel.TabIndex = 128
        Me.PI_Panel.Visible = False
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(3, 6)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(125, 25)
        Me.Label38.TabIndex = 124
        Me.Label38.Text = "PI Additional Day :"
        '
        'AddPIDays_btn
        '
        Me.AddPIDays_btn.Font = New System.Drawing.Font("Dubai", 8.249999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AddPIDays_btn.Location = New System.Drawing.Point(165, 7)
        Me.AddPIDays_btn.Name = "AddPIDays_btn"
        Me.AddPIDays_btn.Size = New System.Drawing.Size(44, 26)
        Me.AddPIDays_btn.TabIndex = 127
        Me.AddPIDays_btn.Text = "Add"
        Me.AddPIDays_btn.UseVisualStyleBackColor = True
        '
        'P_Add_Panel
        '
        Me.P_Add_Panel.BackColor = System.Drawing.Color.Firebrick
        Me.P_Add_Panel.Controls.Add(Me.PI_Days)
        Me.P_Add_Panel.Controls.Add(Me.PIDaysX_btn)
        Me.P_Add_Panel.Controls.Add(Me.PIDaysCheck_btn)
        Me.P_Add_Panel.Location = New System.Drawing.Point(68, 39)
        Me.P_Add_Panel.Name = "P_Add_Panel"
        Me.P_Add_Panel.Size = New System.Drawing.Size(149, 48)
        Me.P_Add_Panel.TabIndex = 116
        Me.P_Add_Panel.Visible = False
        '
        'PI_Days
        '
        Me.PI_Days.DecimalPlaces = 1
        Me.PI_Days.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PI_Days.Increment = New Decimal(New Integer() {5, 0, 0, 65536})
        Me.PI_Days.Location = New System.Drawing.Point(11, 6)
        Me.PI_Days.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.PI_Days.Name = "PI_Days"
        Me.PI_Days.Size = New System.Drawing.Size(49, 35)
        Me.PI_Days.TabIndex = 122
        '
        'PIDaysX_btn
        '
        Me.PIDaysX_btn.Font = New System.Drawing.Font("Dubai", 8.249999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PIDaysX_btn.Location = New System.Drawing.Point(66, 7)
        Me.PIDaysX_btn.Name = "PIDaysX_btn"
        Me.PIDaysX_btn.Size = New System.Drawing.Size(37, 34)
        Me.PIDaysX_btn.TabIndex = 117
        Me.PIDaysX_btn.Text = "✖"
        Me.PIDaysX_btn.UseVisualStyleBackColor = True
        '
        'PIDaysCheck_btn
        '
        Me.PIDaysCheck_btn.Font = New System.Drawing.Font("Dubai", 8.249999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PIDaysCheck_btn.Location = New System.Drawing.Point(104, 7)
        Me.PIDaysCheck_btn.Name = "PIDaysCheck_btn"
        Me.PIDaysCheck_btn.Size = New System.Drawing.Size(37, 34)
        Me.PIDaysCheck_btn.TabIndex = 116
        Me.PIDaysCheck_btn.Text = " ✔"
        Me.PIDaysCheck_btn.UseVisualStyleBackColor = True
        '
        'PIDays_lbl
        '
        Me.PIDays_lbl.AutoSize = True
        Me.PIDays_lbl.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PIDays_lbl.Location = New System.Drawing.Point(131, 5)
        Me.PIDays_lbl.Name = "PIDays_lbl"
        Me.PIDays_lbl.Size = New System.Drawing.Size(21, 27)
        Me.PIDays_lbl.TabIndex = 125
        Me.PIDays_lbl.Text = "0"
        '
        'Biometric_LV
        '
        Me.Biometric_LV.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Biometric_LV.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader17, Me.ColumnHeader18, Me.ColumnHeader19, Me.ColumnHeader20, Me.ColumnHeader1, Me.ColumnHeader2})
        Me.Biometric_LV.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Biometric_LV.FullRowSelect = True
        Me.Biometric_LV.GridLines = True
        Me.Biometric_LV.HideSelection = False
        Me.Biometric_LV.Location = New System.Drawing.Point(3, 138)
        Me.Biometric_LV.MultiSelect = False
        Me.Biometric_LV.Name = "Biometric_LV"
        Me.Biometric_LV.Size = New System.Drawing.Size(1146, 450)
        Me.Biometric_LV.TabIndex = 105
        Me.Biometric_LV.UseCompatibleStateImageBehavior = False
        Me.Biometric_LV.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader17
        '
        Me.ColumnHeader17.Text = "Biometric No."
        Me.ColumnHeader17.Width = 150
        '
        'ColumnHeader18
        '
        Me.ColumnHeader18.Text = "Name"
        Me.ColumnHeader18.Width = 400
        '
        'ColumnHeader19
        '
        Me.ColumnHeader19.Text = "Total Days"
        Me.ColumnHeader19.Width = 140
        '
        'ColumnHeader20
        '
        Me.ColumnHeader20.Text = "Overtime"
        Me.ColumnHeader20.Width = 120
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Late"
        Me.ColumnHeader1.Width = 150
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Undertime"
        Me.ColumnHeader2.Width = 150
        '
        'Search_TXT
        '
        Me.Search_TXT.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Search_TXT.Location = New System.Drawing.Point(298, 98)
        Me.Search_TXT.Name = "Search_TXT"
        Me.Search_TXT.Size = New System.Drawing.Size(281, 33)
        Me.Search_TXT.TabIndex = 103
        '
        'Search_BTN
        '
        Me.Search_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Search_BTN.Location = New System.Drawing.Point(585, 97)
        Me.Search_BTN.Name = "Search_BTN"
        Me.Search_BTN.Size = New System.Drawing.Size(78, 33)
        Me.Search_BTN.TabIndex = 104
        Me.Search_BTN.Text = "Search"
        Me.Search_BTN.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(6, 101)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(98, 25)
        Me.Label20.TabIndex = 11
        Me.Label20.Text = "Search Payroll"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(669, 97)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(82, 33)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "Refresh"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Paydate_ComboB
        '
        Me.Paydate_ComboB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Paydate_ComboB.DropDownWidth = 144
        Me.Paydate_ComboB.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Paydate_ComboB.FormattingEnabled = True
        Me.Paydate_ComboB.Location = New System.Drawing.Point(111, 97)
        Me.Paydate_ComboB.Name = "Paydate_ComboB"
        Me.Paydate_ComboB.Size = New System.Drawing.Size(153, 33)
        Me.Paydate_ComboB.TabIndex = 8
        '
        'Import_BTN
        '
        Me.Import_BTN.Enabled = False
        Me.Import_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Import_BTN.Location = New System.Drawing.Point(669, 17)
        Me.Import_BTN.Name = "Import_BTN"
        Me.Import_BTN.Size = New System.Drawing.Size(82, 31)
        Me.Import_BTN.TabIndex = 5
        Me.Import_BTN.Text = "Import"
        Me.Import_BTN.UseVisualStyleBackColor = True
        '
        'Path_TXT
        '
        Me.Path_TXT.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Path_TXT.Location = New System.Drawing.Point(7, 19)
        Me.Path_TXT.Name = "Path_TXT"
        Me.Path_TXT.ReadOnly = True
        Me.Path_TXT.Size = New System.Drawing.Size(572, 29)
        Me.Path_TXT.TabIndex = 4
        '
        'OpenFile_BTN
        '
        Me.OpenFile_BTN.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OpenFile_BTN.Location = New System.Drawing.Point(585, 17)
        Me.OpenFile_BTN.Name = "OpenFile_BTN"
        Me.OpenFile_BTN.Size = New System.Drawing.Size(78, 31)
        Me.OpenFile_BTN.TabIndex = 3
        Me.OpenFile_BTN.Text = "Browse"
        Me.OpenFile_BTN.UseVisualStyleBackColor = True
        '
        'Manual_Tab
        '
        Me.Manual_Tab.Controls.Add(Me.Panel3)
        Me.Manual_Tab.Controls.Add(Me.Label34)
        Me.Manual_Tab.Controls.Add(Me.Label33)
        Me.Manual_Tab.Controls.Add(Me.Label19)
        Me.Manual_Tab.Controls.Add(Me.SIL_Panel)
        Me.Manual_Tab.Controls.Add(Me.SIL_BTN)
        Me.Manual_Tab.Controls.Add(Me.UT_BTN)
        Me.Manual_Tab.Controls.Add(Me.Late_BTN)
        Me.Manual_Tab.Controls.Add(Me.OT_BTN)
        Me.Manual_Tab.Controls.Add(Me.Label15)
        Me.Manual_Tab.Controls.Add(Me.Label14)
        Me.Manual_Tab.Controls.Add(Me.Label4)
        Me.Manual_Tab.Controls.Add(Me.Label24)
        Me.Manual_Tab.Controls.Add(Me.Label5)
        Me.Manual_Tab.Controls.Add(Me.Label16)
        Me.Manual_Tab.Controls.Add(Me.TotalRHoliday_LBL)
        Me.Manual_Tab.Controls.Add(Me.Label18)
        Me.Manual_Tab.Controls.Add(Me.TotalOTHr_LBL)
        Me.Manual_Tab.Controls.Add(Me.TotalSHoliday_LBL)
        Me.Manual_Tab.Controls.Add(Me.Label6)
        Me.Manual_Tab.Controls.Add(Me.Label17)
        Me.Manual_Tab.Controls.Add(Me.Cancel_BTN)
        Me.Manual_Tab.Controls.Add(Me.Save_BTN)
        Me.Manual_Tab.Controls.Add(Me.Calculate_BTN)
        Me.Manual_Tab.Controls.Add(Me.TotalUTHR_LBL)
        Me.Manual_Tab.Controls.Add(Me.TotalLateHR_LBL)
        Me.Manual_Tab.Controls.Add(Me.SIL_LBL)
        Me.Manual_Tab.Controls.Add(Me.TotalDays_LBL)
        Me.Manual_Tab.Controls.Add(Me.Label12)
        Me.Manual_Tab.Controls.Add(Me.Label11)
        Me.Manual_Tab.Controls.Add(Me.Label10)
        Me.Manual_Tab.Controls.Add(Me.Label9)
        Me.Manual_Tab.Controls.Add(Me.GroupBox3)
        Me.Manual_Tab.Controls.Add(Me.GroupBox1)
        Me.Manual_Tab.Location = New System.Drawing.Point(4, 41)
        Me.Manual_Tab.Name = "Manual_Tab"
        Me.Manual_Tab.Padding = New System.Windows.Forms.Padding(3)
        Me.Manual_Tab.Size = New System.Drawing.Size(1151, 591)
        Me.Manual_Tab.TabIndex = 0
        Me.Manual_Tab.Text = "    Head Office DTR "
        Me.Manual_Tab.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Cancel_lbl)
        Me.Panel3.Controls.Add(Me.Label35)
        Me.Panel3.Controls.Add(Me.AM_OT_NUP)
        Me.Panel3.Location = New System.Drawing.Point(887, 537)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(245, 46)
        Me.Panel3.TabIndex = 120
        '
        'Cancel_lbl
        '
        Me.Cancel_lbl.AutoSize = True
        Me.Cancel_lbl.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel_lbl.ForeColor = System.Drawing.Color.Red
        Me.Cancel_lbl.Location = New System.Drawing.Point(195, 11)
        Me.Cancel_lbl.Name = "Cancel_lbl"
        Me.Cancel_lbl.Size = New System.Drawing.Size(43, 25)
        Me.Cancel_lbl.TabIndex = 121
        Me.Cancel_lbl.Text = "Clear"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(3, 11)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(124, 25)
        Me.Label35.TabIndex = 119
        Me.Label35.Text = "Morning Overtime"
        '
        'AM_OT_NUP
        '
        Me.AM_OT_NUP.DecimalPlaces = 1
        Me.AM_OT_NUP.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AM_OT_NUP.Increment = New Decimal(New Integer() {5, 0, 0, 65536})
        Me.AM_OT_NUP.Location = New System.Drawing.Point(133, 7)
        Me.AM_OT_NUP.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.AM_OT_NUP.Name = "AM_OT_NUP"
        Me.AM_OT_NUP.Size = New System.Drawing.Size(49, 35)
        Me.AM_OT_NUP.TabIndex = 118
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Dubai Light", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(288, 402)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(48, 25)
        Me.Label34.TabIndex = 118
        Me.Label34.Text = "Min/s"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Dubai Light", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(288, 361)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(48, 25)
        Me.Label33.TabIndex = 117
        Me.Label33.Text = "Min/s"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Dubai Light", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(288, 317)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(56, 25)
        Me.Label19.TabIndex = 116
        Me.Label19.Text = "Hour/s"
        '
        'SIL_Panel
        '
        Me.SIL_Panel.BackColor = System.Drawing.Color.LightSalmon
        Me.SIL_Panel.Controls.Add(Me.SIL_NUP)
        Me.SIL_Panel.Controls.Add(Me.CancelSIL_BTN)
        Me.SIL_Panel.Controls.Add(Me.AddSIL_BTN)
        Me.SIL_Panel.Location = New System.Drawing.Point(437, 537)
        Me.SIL_Panel.Name = "SIL_Panel"
        Me.SIL_Panel.Size = New System.Drawing.Size(149, 48)
        Me.SIL_Panel.TabIndex = 115
        Me.SIL_Panel.Visible = False
        '
        'SIL_NUP
        '
        Me.SIL_NUP.DecimalPlaces = 1
        Me.SIL_NUP.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SIL_NUP.Increment = New Decimal(New Integer() {5, 0, 0, 65536})
        Me.SIL_NUP.Location = New System.Drawing.Point(11, 6)
        Me.SIL_NUP.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.SIL_NUP.Name = "SIL_NUP"
        Me.SIL_NUP.Size = New System.Drawing.Size(49, 35)
        Me.SIL_NUP.TabIndex = 122
        '
        'CancelSIL_BTN
        '
        Me.CancelSIL_BTN.Font = New System.Drawing.Font("Dubai", 8.249999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CancelSIL_BTN.Location = New System.Drawing.Point(66, 7)
        Me.CancelSIL_BTN.Name = "CancelSIL_BTN"
        Me.CancelSIL_BTN.Size = New System.Drawing.Size(37, 34)
        Me.CancelSIL_BTN.TabIndex = 117
        Me.CancelSIL_BTN.Text = "✖"
        Me.CancelSIL_BTN.UseVisualStyleBackColor = True
        '
        'AddSIL_BTN
        '
        Me.AddSIL_BTN.Font = New System.Drawing.Font("Dubai", 8.249999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AddSIL_BTN.Location = New System.Drawing.Point(104, 7)
        Me.AddSIL_BTN.Name = "AddSIL_BTN"
        Me.AddSIL_BTN.Size = New System.Drawing.Size(37, 34)
        Me.AddSIL_BTN.TabIndex = 116
        Me.AddSIL_BTN.Text = " ✔"
        Me.AddSIL_BTN.UseVisualStyleBackColor = True
        '
        'SIL_BTN
        '
        Me.SIL_BTN.Font = New System.Drawing.Font("Dubai", 8.249999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SIL_BTN.Location = New System.Drawing.Point(364, 454)
        Me.SIL_BTN.Name = "SIL_BTN"
        Me.SIL_BTN.Size = New System.Drawing.Size(44, 26)
        Me.SIL_BTN.TabIndex = 114
        Me.SIL_BTN.Text = "Add"
        Me.SIL_BTN.UseVisualStyleBackColor = True
        '
        'UT_BTN
        '
        Me.UT_BTN.Font = New System.Drawing.Font("Dubai", 8.249999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UT_BTN.Location = New System.Drawing.Point(364, 403)
        Me.UT_BTN.Name = "UT_BTN"
        Me.UT_BTN.Size = New System.Drawing.Size(44, 26)
        Me.UT_BTN.TabIndex = 113
        Me.UT_BTN.Text = "Clear"
        Me.UT_BTN.UseVisualStyleBackColor = True
        '
        'Late_BTN
        '
        Me.Late_BTN.Font = New System.Drawing.Font("Dubai", 8.249999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Late_BTN.Location = New System.Drawing.Point(364, 360)
        Me.Late_BTN.Name = "Late_BTN"
        Me.Late_BTN.Size = New System.Drawing.Size(44, 26)
        Me.Late_BTN.TabIndex = 112
        Me.Late_BTN.Text = "Clear"
        Me.Late_BTN.UseVisualStyleBackColor = True
        '
        'OT_BTN
        '
        Me.OT_BTN.Font = New System.Drawing.Font("Dubai", 8.249999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OT_BTN.Location = New System.Drawing.Point(364, 318)
        Me.OT_BTN.Name = "OT_BTN"
        Me.OT_BTN.Size = New System.Drawing.Size(44, 26)
        Me.OT_BTN.TabIndex = 9
        Me.OT_BTN.Text = "Clear"
        Me.OT_BTN.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.MediumOrchid
        Me.Label15.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(181, 238)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(22, 22)
        Me.Label15.TabIndex = 111
        Me.Label15.Text = "    "
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Plum
        Me.Label14.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(181, 276)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(22, 22)
        Me.Label14.TabIndex = 110
        Me.Label14.Text = "    "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Dubai Light", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(288, 454)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 25)
        Me.Label4.TabIndex = 106
        Me.Label4.Text = "Day/s"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Dubai Light", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(288, 193)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(49, 25)
        Me.Label24.TabIndex = 105
        Me.Label24.Text = "Day/s"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(17, 234)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(149, 25)
        Me.Label5.TabIndex = 90
        Me.Label5.Text = "Total Regular Holiday "
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(17, 276)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(145, 25)
        Me.Label16.TabIndex = 92
        Me.Label16.Text = "Total Special Holiday "
        '
        'TotalRHoliday_LBL
        '
        Me.TotalRHoliday_LBL.AutoSize = True
        Me.TotalRHoliday_LBL.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalRHoliday_LBL.Location = New System.Drawing.Point(232, 232)
        Me.TotalRHoliday_LBL.Name = "TotalRHoliday_LBL"
        Me.TotalRHoliday_LBL.Size = New System.Drawing.Size(21, 27)
        Me.TotalRHoliday_LBL.TabIndex = 93
        Me.TotalRHoliday_LBL.Text = "0"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Dubai Light", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(288, 274)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(49, 25)
        Me.Label18.TabIndex = 96
        Me.Label18.Text = "Day/s"
        '
        'TotalOTHr_LBL
        '
        Me.TotalOTHr_LBL.AutoSize = True
        Me.TotalOTHr_LBL.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalOTHr_LBL.Location = New System.Drawing.Point(232, 317)
        Me.TotalOTHr_LBL.Name = "TotalOTHr_LBL"
        Me.TotalOTHr_LBL.Size = New System.Drawing.Size(21, 27)
        Me.TotalOTHr_LBL.TabIndex = 97
        Me.TotalOTHr_LBL.Text = "0"
        '
        'TotalSHoliday_LBL
        '
        Me.TotalSHoliday_LBL.AutoSize = True
        Me.TotalSHoliday_LBL.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalSHoliday_LBL.Location = New System.Drawing.Point(232, 274)
        Me.TotalSHoliday_LBL.Name = "TotalSHoliday_LBL"
        Me.TotalSHoliday_LBL.Size = New System.Drawing.Size(21, 27)
        Me.TotalSHoliday_LBL.TabIndex = 94
        Me.TotalSHoliday_LBL.Text = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(16, 319)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(113, 25)
        Me.Label6.TabIndex = 91
        Me.Label6.Text = "Total Overtime  "
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Dubai Light", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(288, 232)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(49, 25)
        Me.Label17.TabIndex = 95
        Me.Label17.Text = "Day/s"
        '
        'Cancel_BTN
        '
        Me.Cancel_BTN.BackColor = System.Drawing.Color.PeachPuff
        Me.Cancel_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cancel_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel_BTN.Location = New System.Drawing.Point(27, 526)
        Me.Cancel_BTN.Name = "Cancel_BTN"
        Me.Cancel_BTN.Size = New System.Drawing.Size(130, 37)
        Me.Cancel_BTN.TabIndex = 81
        Me.Cancel_BTN.Text = "Cancel"
        Me.Cancel_BTN.UseVisualStyleBackColor = False
        '
        'Save_BTN
        '
        Me.Save_BTN.BackColor = System.Drawing.Color.DarkSalmon
        Me.Save_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Save_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Save_BTN.Location = New System.Drawing.Point(300, 526)
        Me.Save_BTN.Name = "Save_BTN"
        Me.Save_BTN.Size = New System.Drawing.Size(99, 37)
        Me.Save_BTN.TabIndex = 76
        Me.Save_BTN.Text = "Save"
        Me.Save_BTN.UseVisualStyleBackColor = False
        '
        'Calculate_BTN
        '
        Me.Calculate_BTN.BackColor = System.Drawing.Color.SeaShell
        Me.Calculate_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Calculate_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Calculate_BTN.Location = New System.Drawing.Point(167, 526)
        Me.Calculate_BTN.Name = "Calculate_BTN"
        Me.Calculate_BTN.Size = New System.Drawing.Size(119, 37)
        Me.Calculate_BTN.TabIndex = 75
        Me.Calculate_BTN.Text = "Calculate"
        Me.Calculate_BTN.UseVisualStyleBackColor = False
        '
        'TotalUTHR_LBL
        '
        Me.TotalUTHR_LBL.AutoSize = True
        Me.TotalUTHR_LBL.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalUTHR_LBL.Location = New System.Drawing.Point(232, 400)
        Me.TotalUTHR_LBL.Name = "TotalUTHR_LBL"
        Me.TotalUTHR_LBL.Size = New System.Drawing.Size(21, 27)
        Me.TotalUTHR_LBL.TabIndex = 74
        Me.TotalUTHR_LBL.Text = "0"
        '
        'TotalLateHR_LBL
        '
        Me.TotalLateHR_LBL.AutoSize = True
        Me.TotalLateHR_LBL.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalLateHR_LBL.Location = New System.Drawing.Point(232, 359)
        Me.TotalLateHR_LBL.Name = "TotalLateHR_LBL"
        Me.TotalLateHR_LBL.Size = New System.Drawing.Size(21, 27)
        Me.TotalLateHR_LBL.TabIndex = 73
        Me.TotalLateHR_LBL.Text = "0"
        '
        'SIL_LBL
        '
        Me.SIL_LBL.AutoSize = True
        Me.SIL_LBL.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SIL_LBL.Location = New System.Drawing.Point(232, 454)
        Me.SIL_LBL.Name = "SIL_LBL"
        Me.SIL_LBL.Size = New System.Drawing.Size(21, 27)
        Me.SIL_LBL.TabIndex = 72
        Me.SIL_LBL.Text = "0"
        '
        'TotalDays_LBL
        '
        Me.TotalDays_LBL.AutoSize = True
        Me.TotalDays_LBL.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalDays_LBL.Location = New System.Drawing.Point(232, 191)
        Me.TotalDays_LBL.Name = "TotalDays_LBL"
        Me.TotalDays_LBL.Size = New System.Drawing.Size(21, 27)
        Me.TotalDays_LBL.TabIndex = 71
        Me.TotalDays_LBL.Text = "0"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(17, 456)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(188, 25)
        Me.Label12.TabIndex = 70
        Me.Label12.Text = "Service Incentive Leave (SIL)"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(17, 402)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(129, 25)
        Me.Label11.TabIndex = 69
        Me.Label11.Text = "Total Under Time  "
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(19, 359)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(75, 25)
        Me.Label10.TabIndex = 68
        Me.Label10.Text = "Total Late"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(17, 192)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(82, 25)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Total Days "
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.CheckALL_CheckBox)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.DataGridView1)
        Me.GroupBox3.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(436, -10)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(696, 537)
        Me.GroupBox3.TabIndex = 67
        Me.GroupBox3.TabStop = False
        '
        'CheckALL_CheckBox
        '
        Me.CheckALL_CheckBox.AutoSize = True
        Me.CheckALL_CheckBox.Location = New System.Drawing.Point(671, 53)
        Me.CheckALL_CheckBox.Name = "CheckALL_CheckBox"
        Me.CheckALL_CheckBox.Size = New System.Drawing.Size(15, 14)
        Me.CheckALL_CheckBox.TabIndex = 68
        Me.CheckALL_CheckBox.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(481, 17)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(34, 27)
        Me.Label8.TabIndex = 67
        Me.Label8.Text = "PM"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(307, 17)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(36, 27)
        Me.Label7.TabIndex = 66
        Me.Label7.Text = "AM"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Date_DataGrid, Me.AM_In_DataGrid, Me.AM_Out_DataGrid, Me.PM_IN_DataGrid, Me.PM_Out_DataGrid, Me.Select_Datagrid})
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.InactiveCaption
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle9
        Me.DataGridView1.Location = New System.Drawing.Point(6, 44)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.Transparent
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Transparent
        Me.DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle10
        Me.DataGridView1.Size = New System.Drawing.Size(684, 487)
        Me.DataGridView1.TabIndex = 65
        '
        'Date_DataGrid
        '
        DataGridViewCellStyle7.NullValue = Nothing
        Me.Date_DataGrid.DefaultCellStyle = DataGridViewCellStyle7
        Me.Date_DataGrid.HeaderText = "Date"
        Me.Date_DataGrid.Name = "Date_DataGrid"
        Me.Date_DataGrid.ReadOnly = True
        Me.Date_DataGrid.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Date_DataGrid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Date_DataGrid.Width = 233
        '
        'AM_In_DataGrid
        '
        DataGridViewCellStyle8.Format = "t"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.AM_In_DataGrid.DefaultCellStyle = DataGridViewCellStyle8
        Me.AM_In_DataGrid.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.AM_In_DataGrid.HeaderText = "In"
        Me.AM_In_DataGrid.Name = "AM_In_DataGrid"
        Me.AM_In_DataGrid.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.AM_In_DataGrid.Width = 90
        '
        'AM_Out_DataGrid
        '
        Me.AM_Out_DataGrid.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.AM_Out_DataGrid.HeaderText = "Out"
        Me.AM_Out_DataGrid.Name = "AM_Out_DataGrid"
        Me.AM_Out_DataGrid.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.AM_Out_DataGrid.Width = 90
        '
        'PM_IN_DataGrid
        '
        Me.PM_IN_DataGrid.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.PM_IN_DataGrid.HeaderText = "In"
        Me.PM_IN_DataGrid.Name = "PM_IN_DataGrid"
        Me.PM_IN_DataGrid.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.PM_IN_DataGrid.Width = 90
        '
        'PM_Out_DataGrid
        '
        Me.PM_Out_DataGrid.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.PM_Out_DataGrid.HeaderText = "Out"
        Me.PM_Out_DataGrid.Name = "PM_Out_DataGrid"
        Me.PM_Out_DataGrid.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.PM_Out_DataGrid.Width = 90
        '
        'Select_Datagrid
        '
        Me.Select_Datagrid.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Select_Datagrid.HeaderText = "Select All"
        Me.Select_Datagrid.Name = "Select_Datagrid"
        Me.Select_Datagrid.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Select_Datagrid.Width = 90
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label32)
        Me.GroupBox1.Controls.Add(Me.TimeOut_TXT)
        Me.GroupBox1.Controls.Add(Me.Label31)
        Me.GroupBox1.Controls.Add(Me.TimeIn_TXT)
        Me.GroupBox1.Controls.Add(Me.SearchEMP_BTN)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Name_TXT)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.BiometricID_TXT)
        Me.GroupBox1.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(6, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(411, 149)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Employee"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(194, 108)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(71, 25)
        Me.Label32.TabIndex = 11
        Me.Label32.Text = "Time Out"
        '
        'TimeOut_TXT
        '
        Me.TimeOut_TXT.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TimeOut_TXT.Location = New System.Drawing.Point(272, 107)
        Me.TimeOut_TXT.Name = "TimeOut_TXT"
        Me.TimeOut_TXT.ReadOnly = True
        Me.TimeOut_TXT.Size = New System.Drawing.Size(70, 29)
        Me.TimeOut_TXT.TabIndex = 12
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(16, 107)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(59, 25)
        Me.Label31.TabIndex = 9
        Me.Label31.Text = "Time In"
        '
        'TimeIn_TXT
        '
        Me.TimeIn_TXT.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TimeIn_TXT.Location = New System.Drawing.Point(110, 107)
        Me.TimeIn_TXT.Name = "TimeIn_TXT"
        Me.TimeIn_TXT.ReadOnly = True
        Me.TimeIn_TXT.Size = New System.Drawing.Size(71, 29)
        Me.TimeIn_TXT.TabIndex = 10
        '
        'SearchEMP_BTN
        '
        Me.SearchEMP_BTN.Location = New System.Drawing.Point(358, 68)
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
        Me.Label3.Location = New System.Drawing.Point(16, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 25)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Name"
        '
        'Name_TXT
        '
        Me.Name_TXT.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name_TXT.Location = New System.Drawing.Point(110, 67)
        Me.Name_TXT.Name = "Name_TXT"
        Me.Name_TXT.ReadOnly = True
        Me.Name_TXT.Size = New System.Drawing.Size(232, 29)
        Me.Name_TXT.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 25)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Biometric ID"
        '
        'BiometricID_TXT
        '
        Me.BiometricID_TXT.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BiometricID_TXT.Location = New System.Drawing.Point(110, 27)
        Me.BiometricID_TXT.Name = "BiometricID_TXT"
        Me.BiometricID_TXT.Size = New System.Drawing.Size(232, 29)
        Me.BiometricID_TXT.TabIndex = 1
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.B_PI_Panel)
        Me.TabPage2.Controls.Add(Me.Browse7_BTN)
        Me.TabPage2.Controls.Add(Me.Path7_TXT)
        Me.TabPage2.Controls.Add(Me.Import7_BTN)
        Me.TabPage2.Controls.Add(Me.Branch_LV)
        Me.TabPage2.Controls.Add(Me.Label30)
        Me.TabPage2.Controls.Add(Me.Paydate7_CB)
        Me.TabPage2.Controls.Add(Me.Panel2)
        Me.TabPage2.Controls.Add(Me.Search7_TXT)
        Me.TabPage2.Controls.Add(Me.Search7_BTN)
        Me.TabPage2.Controls.Add(Me.SearchEmp7_BTN)
        Me.TabPage2.Controls.Add(Me.Label28)
        Me.TabPage2.Controls.Add(Me.Emp7_TXT)
        Me.TabPage2.Controls.Add(Me.Label27)
        Me.TabPage2.Controls.Add(Me.Bio7_TXT)
        Me.TabPage2.Location = New System.Drawing.Point(4, 41)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1151, 591)
        Me.TabPage2.TabIndex = 4
        Me.TabPage2.Text = "    Branches (Manual)    "
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'B_PI_Panel
        '
        Me.B_PI_Panel.Controls.Add(Me.Label47)
        Me.B_PI_Panel.Controls.Add(Me.B_P_Add_Panel)
        Me.B_PI_Panel.Controls.Add(Me.B_AddPIDays_btn)
        Me.B_PI_Panel.Controls.Add(Me.B_PIDays_lbl)
        Me.B_PI_Panel.Location = New System.Drawing.Point(772, 39)
        Me.B_PI_Panel.Name = "B_PI_Panel"
        Me.B_PI_Panel.Size = New System.Drawing.Size(376, 60)
        Me.B_PI_Panel.TabIndex = 129
        Me.B_PI_Panel.Visible = False
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label47.Location = New System.Drawing.Point(155, 29)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(125, 25)
        Me.Label47.TabIndex = 124
        Me.Label47.Text = "PI Additional Day :"
        '
        'B_P_Add_Panel
        '
        Me.B_P_Add_Panel.BackColor = System.Drawing.Color.Firebrick
        Me.B_P_Add_Panel.Controls.Add(Me.B_PI_Days)
        Me.B_P_Add_Panel.Controls.Add(Me.B_PIDaysX_btn)
        Me.B_P_Add_Panel.Controls.Add(Me.B_PIDaysCheck_btn)
        Me.B_P_Add_Panel.Location = New System.Drawing.Point(3, 6)
        Me.B_P_Add_Panel.Name = "B_P_Add_Panel"
        Me.B_P_Add_Panel.Size = New System.Drawing.Size(149, 48)
        Me.B_P_Add_Panel.TabIndex = 116
        Me.B_P_Add_Panel.Visible = False
        '
        'B_PI_Days
        '
        Me.B_PI_Days.DecimalPlaces = 1
        Me.B_PI_Days.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.B_PI_Days.Increment = New Decimal(New Integer() {5, 0, 0, 65536})
        Me.B_PI_Days.Location = New System.Drawing.Point(11, 6)
        Me.B_PI_Days.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.B_PI_Days.Name = "B_PI_Days"
        Me.B_PI_Days.Size = New System.Drawing.Size(49, 35)
        Me.B_PI_Days.TabIndex = 122
        '
        'B_PIDaysX_btn
        '
        Me.B_PIDaysX_btn.Font = New System.Drawing.Font("Dubai", 8.249999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.B_PIDaysX_btn.Location = New System.Drawing.Point(66, 7)
        Me.B_PIDaysX_btn.Name = "B_PIDaysX_btn"
        Me.B_PIDaysX_btn.Size = New System.Drawing.Size(37, 34)
        Me.B_PIDaysX_btn.TabIndex = 117
        Me.B_PIDaysX_btn.Text = "✖"
        Me.B_PIDaysX_btn.UseVisualStyleBackColor = True
        '
        'B_PIDaysCheck_btn
        '
        Me.B_PIDaysCheck_btn.Font = New System.Drawing.Font("Dubai", 8.249999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.B_PIDaysCheck_btn.Location = New System.Drawing.Point(104, 7)
        Me.B_PIDaysCheck_btn.Name = "B_PIDaysCheck_btn"
        Me.B_PIDaysCheck_btn.Size = New System.Drawing.Size(37, 34)
        Me.B_PIDaysCheck_btn.TabIndex = 116
        Me.B_PIDaysCheck_btn.Text = " ✔"
        Me.B_PIDaysCheck_btn.UseVisualStyleBackColor = True
        '
        'B_AddPIDays_btn
        '
        Me.B_AddPIDays_btn.Font = New System.Drawing.Font("Dubai", 8.249999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.B_AddPIDays_btn.Location = New System.Drawing.Point(324, 30)
        Me.B_AddPIDays_btn.Name = "B_AddPIDays_btn"
        Me.B_AddPIDays_btn.Size = New System.Drawing.Size(44, 26)
        Me.B_AddPIDays_btn.TabIndex = 127
        Me.B_AddPIDays_btn.Text = "Add"
        Me.B_AddPIDays_btn.UseVisualStyleBackColor = True
        '
        'B_PIDays_lbl
        '
        Me.B_PIDays_lbl.AutoSize = True
        Me.B_PIDays_lbl.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.B_PIDays_lbl.Location = New System.Drawing.Point(283, 28)
        Me.B_PIDays_lbl.Name = "B_PIDays_lbl"
        Me.B_PIDays_lbl.Size = New System.Drawing.Size(21, 27)
        Me.B_PIDays_lbl.TabIndex = 125
        Me.B_PIDays_lbl.Text = "0"
        '
        'Browse7_BTN
        '
        Me.Browse7_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Browse7_BTN.Location = New System.Drawing.Point(975, 5)
        Me.Browse7_BTN.Name = "Browse7_BTN"
        Me.Browse7_BTN.Size = New System.Drawing.Size(82, 33)
        Me.Browse7_BTN.TabIndex = 69
        Me.Browse7_BTN.Text = "Browse"
        Me.Browse7_BTN.UseVisualStyleBackColor = True
        '
        'Path7_TXT
        '
        Me.Path7_TXT.Enabled = False
        Me.Path7_TXT.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Path7_TXT.Location = New System.Drawing.Point(577, 6)
        Me.Path7_TXT.Name = "Path7_TXT"
        Me.Path7_TXT.Size = New System.Drawing.Size(392, 33)
        Me.Path7_TXT.TabIndex = 68
        '
        'Import7_BTN
        '
        Me.Import7_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Import7_BTN.Location = New System.Drawing.Point(1063, 5)
        Me.Import7_BTN.Name = "Import7_BTN"
        Me.Import7_BTN.Size = New System.Drawing.Size(82, 33)
        Me.Import7_BTN.TabIndex = 70
        Me.Import7_BTN.Text = "Import"
        Me.Import7_BTN.UseVisualStyleBackColor = True
        '
        'Branch_LV
        '
        Me.Branch_LV.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Branch_LV.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9})
        Me.Branch_LV.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Branch_LV.FullRowSelect = True
        Me.Branch_LV.GridLines = True
        Me.Branch_LV.HideSelection = False
        Me.Branch_LV.Location = New System.Drawing.Point(2, 404)
        Me.Branch_LV.MultiSelect = False
        Me.Branch_LV.Name = "Branch_LV"
        Me.Branch_LV.Size = New System.Drawing.Size(1146, 181)
        Me.Branch_LV.TabIndex = 94
        Me.Branch_LV.UseCompatibleStateImageBehavior = False
        Me.Branch_LV.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Biometric No."
        Me.ColumnHeader3.Width = 120
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Name"
        Me.ColumnHeader4.Width = 400
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Total Days"
        Me.ColumnHeader5.Width = 120
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Overtime"
        Me.ColumnHeader6.Width = 120
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Late"
        Me.ColumnHeader7.Width = 120
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Undertime"
        Me.ColumnHeader8.Width = 120
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Night Rate"
        Me.ColumnHeader9.Width = 120
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(8, 373)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(76, 22)
        Me.Label30.TabIndex = 111
        Me.Label30.Text = "Payroll Date"
        '
        'Paydate7_CB
        '
        Me.Paydate7_CB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Paydate7_CB.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Paydate7_CB.FormattingEnabled = True
        Me.Paydate7_CB.Location = New System.Drawing.Point(91, 369)
        Me.Paydate7_CB.Name = "Paydate7_CB"
        Me.Paydate7_CB.Size = New System.Drawing.Size(151, 30)
        Me.Paydate7_CB.TabIndex = 91
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.txtNewRateSpecHoliday)
        Me.Panel2.Controls.Add(Me.Label42)
        Me.Panel2.Controls.Add(Me.txtNewRateRegHoliday)
        Me.Panel2.Controls.Add(Me.Label41)
        Me.Panel2.Controls.Add(Me.newRateOT_NUP)
        Me.Panel2.Controls.Add(Me.txtNewRateUT)
        Me.Panel2.Controls.Add(Me.Label43)
        Me.Panel2.Controls.Add(Me.Label44)
        Me.Panel2.Controls.Add(Me.txtNewRateLate)
        Me.Panel2.Controls.Add(Me.Label45)
        Me.Panel2.Controls.Add(Me.NewRateDaysCovered_NUP)
        Me.Panel2.Controls.Add(Me.Label40)
        Me.Panel2.Controls.Add(Me.txtRegNightShiftOT)
        Me.Panel2.Controls.Add(Me.Label58)
        Me.Panel2.Controls.Add(Me.txtSpecNightShiftOT)
        Me.Panel2.Controls.Add(Me.Label59)
        Me.Panel2.Controls.Add(Me.txtOrdNightShiftOT)
        Me.Panel2.Controls.Add(Me.Label60)
        Me.Panel2.Controls.Add(Me.txtRegRestDayOT)
        Me.Panel2.Controls.Add(Me.Label56)
        Me.Panel2.Controls.Add(Me.txtRegOT)
        Me.Panel2.Controls.Add(Me.Label57)
        Me.Panel2.Controls.Add(Me.txtSpecRestDayOT)
        Me.Panel2.Controls.Add(Me.Label53)
        Me.Panel2.Controls.Add(Me.txtSpecOT)
        Me.Panel2.Controls.Add(Me.Label54)
        Me.Panel2.Controls.Add(Me.txtRestDayOT)
        Me.Panel2.Controls.Add(Me.Label55)
        Me.Panel2.Controls.Add(Me.txtRegNightShift)
        Me.Panel2.Controls.Add(Me.txtRegRestDay)
        Me.Panel2.Controls.Add(Me.Label51)
        Me.Panel2.Controls.Add(Me.Label50)
        Me.Panel2.Controls.Add(Me.txtSpecRestDay)
        Me.Panel2.Controls.Add(Me.SIL7_NUP)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.txtSpecNightShift)
        Me.Panel2.Controls.Add(Me.Label49)
        Me.Panel2.Controls.Add(Me.Label52)
        Me.Panel2.Controls.Add(Me.txtRestDayDuty)
        Me.Panel2.Controls.Add(Me.Label48)
        Me.Panel2.Controls.Add(Me.Label39)
        Me.Panel2.Controls.Add(Me.Overtime7_NUP)
        Me.Panel2.Controls.Add(Me.Save7_BTN)
        Me.Panel2.Controls.Add(Me.Cancel7_BTN)
        Me.Panel2.Controls.Add(Me.SpecHol7_TXT)
        Me.Panel2.Controls.Add(Me.Label36)
        Me.Panel2.Controls.Add(Me.Undertime7_TXT)
        Me.Panel2.Controls.Add(Me.Label29)
        Me.Panel2.Controls.Add(Me.Days7_TXT)
        Me.Panel2.Controls.Add(Me.Label21)
        Me.Panel2.Controls.Add(Me.RegHol7_TXT)
        Me.Panel2.Controls.Add(Me.Label23)
        Me.Panel2.Controls.Add(Me.Night7_TXT)
        Me.Panel2.Controls.Add(Me.Label37)
        Me.Panel2.Controls.Add(Me.Label26)
        Me.Panel2.Controls.Add(Me.Late7_TXT)
        Me.Panel2.Controls.Add(Me.Label25)
        Me.Panel2.Location = New System.Drawing.Point(4, 102)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1144, 255)
        Me.Panel2.TabIndex = 109
        '
        'newRateOT_NUP
        '
        Me.newRateOT_NUP.DecimalPlaces = 1
        Me.newRateOT_NUP.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.newRateOT_NUP.Increment = New Decimal(New Integer() {5, 0, 0, 65536})
        Me.newRateOT_NUP.Location = New System.Drawing.Point(1056, 108)
        Me.newRateOT_NUP.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.newRateOT_NUP.Name = "newRateOT_NUP"
        Me.newRateOT_NUP.Size = New System.Drawing.Size(79, 29)
        Me.newRateOT_NUP.TabIndex = 168
        '
        'txtNewRateUT
        '
        Me.txtNewRateUT.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNewRateUT.Location = New System.Drawing.Point(1056, 74)
        Me.txtNewRateUT.Name = "txtNewRateUT"
        Me.txtNewRateUT.Size = New System.Drawing.Size(79, 29)
        Me.txtNewRateUT.TabIndex = 167
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.Location = New System.Drawing.Point(933, 73)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(120, 22)
        Me.Label43.TabIndex = 171
        Me.Label43.Text = "New UT            (mm)"
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.Location = New System.Drawing.Point(933, 110)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(118, 22)
        Me.Label44.TabIndex = 169
        Me.Label44.Text = "New Overtime   (hr)"
        '
        'txtNewRateLate
        '
        Me.txtNewRateLate.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNewRateLate.Location = New System.Drawing.Point(1056, 40)
        Me.txtNewRateLate.Name = "txtNewRateLate"
        Me.txtNewRateLate.Size = New System.Drawing.Size(79, 29)
        Me.txtNewRateLate.TabIndex = 166
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.Location = New System.Drawing.Point(933, 39)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(121, 22)
        Me.Label45.TabIndex = 170
        Me.Label45.Text = "New Late          (mm)"
        '
        'NewRateDaysCovered_NUP
        '
        Me.NewRateDaysCovered_NUP.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NewRateDaysCovered_NUP.Location = New System.Drawing.Point(1056, 7)
        Me.NewRateDaysCovered_NUP.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.NewRateDaysCovered_NUP.Name = "NewRateDaysCovered_NUP"
        Me.NewRateDaysCovered_NUP.Size = New System.Drawing.Size(79, 29)
        Me.NewRateDaysCovered_NUP.TabIndex = 162
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(933, 9)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(114, 22)
        Me.Label40.TabIndex = 163
        Me.Label40.Text = "New Days         (dd)"
        '
        'txtRegNightShiftOT
        '
        Me.txtRegNightShiftOT.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegNightShiftOT.Location = New System.Drawing.Point(747, 218)
        Me.txtRegNightShiftOT.Name = "txtRegNightShiftOT"
        Me.txtRegNightShiftOT.Size = New System.Drawing.Size(79, 29)
        Me.txtRegNightShiftOT.TabIndex = 160
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label58.Location = New System.Drawing.Point(565, 225)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(174, 22)
        Me.Label58.TabIndex = 161
        Me.Label58.Text = "Reg. Night Shift, OT            (hr)"
        '
        'txtSpecNightShiftOT
        '
        Me.txtSpecNightShiftOT.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSpecNightShiftOT.Location = New System.Drawing.Point(747, 183)
        Me.txtSpecNightShiftOT.Name = "txtSpecNightShiftOT"
        Me.txtSpecNightShiftOT.Size = New System.Drawing.Size(79, 29)
        Me.txtSpecNightShiftOT.TabIndex = 158
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label59.Location = New System.Drawing.Point(565, 190)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(176, 22)
        Me.Label59.TabIndex = 159
        Me.Label59.Text = "Spec. Night Shift, OT           (hr)"
        '
        'txtOrdNightShiftOT
        '
        Me.txtOrdNightShiftOT.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOrdNightShiftOT.Location = New System.Drawing.Point(747, 148)
        Me.txtOrdNightShiftOT.Name = "txtOrdNightShiftOT"
        Me.txtOrdNightShiftOT.Size = New System.Drawing.Size(79, 29)
        Me.txtOrdNightShiftOT.TabIndex = 156
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label60.Location = New System.Drawing.Point(565, 155)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(175, 22)
        Me.Label60.TabIndex = 157
        Me.Label60.Text = "Ord. Day, Night shift, OT    (hr)"
        '
        'txtRegRestDayOT
        '
        Me.txtRegRestDayOT.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegRestDayOT.Location = New System.Drawing.Point(747, 43)
        Me.txtRegRestDayOT.Name = "txtRegRestDayOT"
        Me.txtRegRestDayOT.Size = New System.Drawing.Size(79, 29)
        Me.txtRegRestDayOT.TabIndex = 154
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label56.Location = New System.Drawing.Point(595, 50)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(144, 22)
        Me.Label56.TabIndex = 155
        Me.Label56.Text = "Reg., Rest Day, OT     (hr)"
        '
        'txtRegOT
        '
        Me.txtRegOT.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegOT.Location = New System.Drawing.Point(747, 8)
        Me.txtRegOT.Name = "txtRegOT"
        Me.txtRegOT.Size = New System.Drawing.Size(79, 29)
        Me.txtRegOT.TabIndex = 152
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label57.Location = New System.Drawing.Point(595, 15)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(142, 22)
        Me.Label57.TabIndex = 153
        Me.Label57.Text = "Reg., OT                      (hr)"
        '
        'txtSpecRestDayOT
        '
        Me.txtSpecRestDayOT.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSpecRestDayOT.Location = New System.Drawing.Point(424, 214)
        Me.txtSpecRestDayOT.Name = "txtSpecRestDayOT"
        Me.txtSpecRestDayOT.Size = New System.Drawing.Size(79, 29)
        Me.txtSpecRestDayOT.TabIndex = 150
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label53.Location = New System.Drawing.Point(272, 221)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(143, 22)
        Me.Label53.TabIndex = 151
        Me.Label53.Text = "Spec., Rest Day, OT   (hr)"
        '
        'txtSpecOT
        '
        Me.txtSpecOT.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSpecOT.Location = New System.Drawing.Point(424, 179)
        Me.txtSpecOT.Name = "txtSpecOT"
        Me.txtSpecOT.Size = New System.Drawing.Size(79, 29)
        Me.txtSpecOT.TabIndex = 148
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label54.Location = New System.Drawing.Point(272, 186)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(144, 22)
        Me.Label54.TabIndex = 149
        Me.Label54.Text = "Spec., OT                     (hr)"
        '
        'txtRestDayOT
        '
        Me.txtRestDayOT.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRestDayOT.Location = New System.Drawing.Point(424, 144)
        Me.txtRestDayOT.Name = "txtRestDayOT"
        Me.txtRestDayOT.Size = New System.Drawing.Size(79, 29)
        Me.txtRestDayOT.TabIndex = 146
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label55.Location = New System.Drawing.Point(272, 151)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(144, 22)
        Me.Label55.TabIndex = 147
        Me.Label55.Text = "Rest Day, OT              (hr)"
        '
        'txtRegNightShift
        '
        Me.txtRegNightShift.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegNightShift.Location = New System.Drawing.Point(747, 113)
        Me.txtRegNightShift.Name = "txtRegNightShift"
        Me.txtRegNightShift.Size = New System.Drawing.Size(79, 29)
        Me.txtRegNightShift.TabIndex = 144
        '
        'txtRegRestDay
        '
        Me.txtRegRestDay.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegRestDay.Location = New System.Drawing.Point(424, 109)
        Me.txtRegRestDay.Name = "txtRegRestDay"
        Me.txtRegRestDay.Size = New System.Drawing.Size(79, 29)
        Me.txtRegRestDay.TabIndex = 140
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.Location = New System.Drawing.Point(596, 120)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(137, 22)
        Me.Label51.TabIndex = 145
        Me.Label51.Text = "Reg., Night shift       (hr)"
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.Location = New System.Drawing.Point(272, 116)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(127, 22)
        Me.Label50.TabIndex = 141
        Me.Label50.Text = "Reg., Rest Day      (dd)"
        '
        'txtSpecRestDay
        '
        Me.txtSpecRestDay.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSpecRestDay.Location = New System.Drawing.Point(424, 77)
        Me.txtSpecRestDay.Name = "txtSpecRestDay"
        Me.txtSpecRestDay.Size = New System.Drawing.Size(79, 29)
        Me.txtSpecRestDay.TabIndex = 138
        '
        'SIL7_NUP
        '
        Me.SIL7_NUP.DecimalPlaces = 1
        Me.SIL7_NUP.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SIL7_NUP.Increment = New Decimal(New Integer() {5, 0, 0, 65536})
        Me.SIL7_NUP.Location = New System.Drawing.Point(131, 178)
        Me.SIL7_NUP.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.SIL7_NUP.Name = "SIL7_NUP"
        Me.SIL7_NUP.Size = New System.Drawing.Size(79, 29)
        Me.SIL7_NUP.TabIndex = 81
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(8, 180)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(54, 22)
        Me.Label13.TabIndex = 112
        Me.Label13.Text = "SIL (dd)"
        '
        'txtSpecNightShift
        '
        Me.txtSpecNightShift.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSpecNightShift.Location = New System.Drawing.Point(747, 78)
        Me.txtSpecNightShift.Name = "txtSpecNightShift"
        Me.txtSpecNightShift.Size = New System.Drawing.Size(79, 29)
        Me.txtSpecNightShift.TabIndex = 142
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label49.Location = New System.Drawing.Point(272, 84)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(126, 22)
        Me.Label49.TabIndex = 139
        Me.Label49.Text = "Spec., Rest Day    (dd)"
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.Location = New System.Drawing.Point(596, 85)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(136, 22)
        Me.Label52.TabIndex = 143
        Me.Label52.Text = "Spec., Night shift     (hr)"
        '
        'txtRestDayDuty
        '
        Me.txtRestDayDuty.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRestDayDuty.Location = New System.Drawing.Point(424, 44)
        Me.txtRestDayDuty.Name = "txtRestDayDuty"
        Me.txtRestDayDuty.Size = New System.Drawing.Size(79, 29)
        Me.txtRestDayDuty.TabIndex = 136
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label48.Location = New System.Drawing.Point(272, 51)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(124, 22)
        Me.Label48.TabIndex = 137
        Me.Label48.Text = "Rest Day Duty    (dd)"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Dubai", 8.249999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(19, 233)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(84, 18)
        Me.Label39.TabIndex = 116
        Me.Label39.Text = "(Additional only)"
        '
        'Overtime7_NUP
        '
        Me.Overtime7_NUP.DecimalPlaces = 1
        Me.Overtime7_NUP.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Overtime7_NUP.Increment = New Decimal(New Integer() {5, 0, 0, 65536})
        Me.Overtime7_NUP.Location = New System.Drawing.Point(131, 109)
        Me.Overtime7_NUP.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.Overtime7_NUP.Name = "Overtime7_NUP"
        Me.Overtime7_NUP.Size = New System.Drawing.Size(79, 29)
        Me.Overtime7_NUP.TabIndex = 77
        '
        'Save7_BTN
        '
        Me.Save7_BTN.BackColor = System.Drawing.Color.LightSalmon
        Me.Save7_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Save7_BTN.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Save7_BTN.Location = New System.Drawing.Point(1030, 213)
        Me.Save7_BTN.Name = "Save7_BTN"
        Me.Save7_BTN.Size = New System.Drawing.Size(111, 37)
        Me.Save7_BTN.TabIndex = 90
        Me.Save7_BTN.Text = "Save"
        Me.Save7_BTN.UseVisualStyleBackColor = False
        '
        'Cancel7_BTN
        '
        Me.Cancel7_BTN.BackColor = System.Drawing.Color.RosyBrown
        Me.Cancel7_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cancel7_BTN.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel7_BTN.Location = New System.Drawing.Point(896, 213)
        Me.Cancel7_BTN.Name = "Cancel7_BTN"
        Me.Cancel7_BTN.Size = New System.Drawing.Size(108, 37)
        Me.Cancel7_BTN.TabIndex = 89
        Me.Cancel7_BTN.Text = "Cancel"
        Me.Cancel7_BTN.UseVisualStyleBackColor = False
        '
        'SpecHol7_TXT
        '
        Me.SpecHol7_TXT.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SpecHol7_TXT.Location = New System.Drawing.Point(424, 8)
        Me.SpecHol7_TXT.Name = "SpecHol7_TXT"
        Me.SpecHol7_TXT.Size = New System.Drawing.Size(79, 29)
        Me.SpecHol7_TXT.TabIndex = 80
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(271, 15)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(104, 22)
        Me.Label36.TabIndex = 115
        Me.Label36.Text = "Spec. Hol.       (hr)"
        '
        'Undertime7_TXT
        '
        Me.Undertime7_TXT.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Undertime7_TXT.Location = New System.Drawing.Point(131, 75)
        Me.Undertime7_TXT.Name = "Undertime7_TXT"
        Me.Undertime7_TXT.Size = New System.Drawing.Size(79, 29)
        Me.Undertime7_TXT.TabIndex = 76
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(8, 74)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(108, 22)
        Me.Label29.TabIndex = 110
        Me.Label29.Text = "UT                 (mm)"
        '
        'Days7_TXT
        '
        Me.Days7_TXT.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Days7_TXT.Location = New System.Drawing.Point(131, 7)
        Me.Days7_TXT.Name = "Days7_TXT"
        Me.Days7_TXT.Size = New System.Drawing.Size(79, 29)
        Me.Days7_TXT.TabIndex = 74
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(8, 6)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(71, 22)
        Me.Label21.TabIndex = 75
        Me.Label21.Text = "No. of Days"
        '
        'RegHol7_TXT
        '
        Me.RegHol7_TXT.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RegHol7_TXT.Location = New System.Drawing.Point(131, 214)
        Me.RegHol7_TXT.Name = "RegHol7_TXT"
        Me.RegHol7_TXT.Size = New System.Drawing.Size(79, 29)
        Me.RegHol7_TXT.TabIndex = 79
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(8, 111)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(100, 22)
        Me.Label23.TabIndex = 77
        Me.Label23.Text = "Overtime      (hr)"
        '
        'Night7_TXT
        '
        Me.Night7_TXT.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Night7_TXT.Location = New System.Drawing.Point(131, 143)
        Me.Night7_TXT.Name = "Night7_TXT"
        Me.Night7_TXT.Size = New System.Drawing.Size(79, 29)
        Me.Night7_TXT.TabIndex = 78
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(7, 216)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(104, 22)
        Me.Label37.TabIndex = 118
        Me.Label37.Text = "Reg. Hol.        (dd)"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(8, 143)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(102, 22)
        Me.Label26.TabIndex = 79
        Me.Label26.Text = "Night Rate    (hr)"
        '
        'Late7_TXT
        '
        Me.Late7_TXT.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Late7_TXT.Location = New System.Drawing.Point(131, 41)
        Me.Late7_TXT.Name = "Late7_TXT"
        Me.Late7_TXT.Size = New System.Drawing.Size(79, 29)
        Me.Late7_TXT.TabIndex = 75
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(8, 40)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(109, 22)
        Me.Label25.TabIndex = 81
        Me.Label25.Text = "Late               (mm)"
        '
        'Search7_TXT
        '
        Me.Search7_TXT.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Search7_TXT.Location = New System.Drawing.Point(255, 369)
        Me.Search7_TXT.Name = "Search7_TXT"
        Me.Search7_TXT.Size = New System.Drawing.Size(414, 29)
        Me.Search7_TXT.TabIndex = 92
        '
        'Search7_BTN
        '
        Me.Search7_BTN.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Search7_BTN.Location = New System.Drawing.Point(675, 367)
        Me.Search7_BTN.Name = "Search7_BTN"
        Me.Search7_BTN.Size = New System.Drawing.Size(82, 33)
        Me.Search7_BTN.TabIndex = 93
        Me.Search7_BTN.Text = "Search"
        Me.Search7_BTN.UseVisualStyleBackColor = True
        '
        'SearchEmp7_BTN
        '
        Me.SearchEmp7_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SearchEmp7_BTN.Location = New System.Drawing.Point(364, 49)
        Me.SearchEmp7_BTN.Name = "SearchEmp7_BTN"
        Me.SearchEmp7_BTN.Size = New System.Drawing.Size(38, 30)
        Me.SearchEmp7_BTN.TabIndex = 73
        Me.SearchEmp7_BTN.Text = "..."
        Me.SearchEmp7_BTN.UseVisualStyleBackColor = True
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(12, 52)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(48, 25)
        Me.Label28.TabIndex = 85
        Me.Label28.Text = "Name"
        '
        'Emp7_TXT
        '
        Me.Emp7_TXT.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Emp7_TXT.Location = New System.Drawing.Point(80, 48)
        Me.Emp7_TXT.Name = "Emp7_TXT"
        Me.Emp7_TXT.ReadOnly = True
        Me.Emp7_TXT.Size = New System.Drawing.Size(278, 33)
        Me.Emp7_TXT.TabIndex = 72
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(12, 13)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(60, 27)
        Me.Label27.TabIndex = 84
        Me.Label27.Text = "Bio No."
        '
        'Bio7_TXT
        '
        Me.Bio7_TXT.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bio7_TXT.Location = New System.Drawing.Point(80, 11)
        Me.Bio7_TXT.Name = "Bio7_TXT"
        Me.Bio7_TXT.Size = New System.Drawing.Size(109, 29)
        Me.Bio7_TXT.TabIndex = 71
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.GroupBranch_RadioB)
        Me.TabPage3.Controls.Add(Me.Employee_RadioB)
        Me.TabPage3.Controls.Add(Me.HO_RadioB)
        Me.TabPage3.Controls.Add(Me.Preview_BTN)
        Me.TabPage3.Controls.Add(Me.CancelDTR_BTN)
        Me.TabPage3.Controls.Add(Me.Panel1)
        Me.TabPage3.Controls.Add(Me.FlowLayoutPanel1)
        Me.TabPage3.Controls.Add(Me.Label22)
        Me.TabPage3.Controls.Add(Me.Payslip_DTR_Combo)
        Me.TabPage3.Location = New System.Drawing.Point(4, 41)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(1151, 591)
        Me.TabPage3.TabIndex = 3
        Me.TabPage3.Text = "    Print DTR    "
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'GroupBranch_RadioB
        '
        Me.GroupBranch_RadioB.AutoSize = True
        Me.GroupBranch_RadioB.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBranch_RadioB.Location = New System.Drawing.Point(157, 23)
        Me.GroupBranch_RadioB.Name = "GroupBranch_RadioB"
        Me.GroupBranch_RadioB.Size = New System.Drawing.Size(135, 29)
        Me.GroupBranch_RadioB.TabIndex = 119
        Me.GroupBranch_RadioB.Text = "Group by Branch"
        Me.GroupBranch_RadioB.UseVisualStyleBackColor = True
        '
        'Employee_RadioB
        '
        Me.Employee_RadioB.AutoSize = True
        Me.Employee_RadioB.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Employee_RadioB.Location = New System.Drawing.Point(320, 23)
        Me.Employee_RadioB.Name = "Employee_RadioB"
        Me.Employee_RadioB.Size = New System.Drawing.Size(114, 29)
        Me.Employee_RadioB.TabIndex = 111
        Me.Employee_RadioB.Text = "Per Employee"
        Me.Employee_RadioB.UseVisualStyleBackColor = True
        '
        'HO_RadioB
        '
        Me.HO_RadioB.AutoSize = True
        Me.HO_RadioB.Checked = True
        Me.HO_RadioB.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HO_RadioB.Location = New System.Drawing.Point(18, 23)
        Me.HO_RadioB.Name = "HO_RadioB"
        Me.HO_RadioB.Size = New System.Drawing.Size(104, 29)
        Me.HO_RadioB.TabIndex = 118
        Me.HO_RadioB.TabStop = True
        Me.HO_RadioB.Text = "Head Office"
        Me.HO_RadioB.UseVisualStyleBackColor = True
        '
        'Preview_BTN
        '
        Me.Preview_BTN.BackColor = System.Drawing.Color.Thistle
        Me.Preview_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Preview_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Preview_BTN.Location = New System.Drawing.Point(332, 530)
        Me.Preview_BTN.Name = "Preview_BTN"
        Me.Preview_BTN.Size = New System.Drawing.Size(103, 45)
        Me.Preview_BTN.TabIndex = 96
        Me.Preview_BTN.Text = "Preview"
        Me.Preview_BTN.UseVisualStyleBackColor = False
        '
        'CancelDTR_BTN
        '
        Me.CancelDTR_BTN.BackColor = System.Drawing.Color.PeachPuff
        Me.CancelDTR_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CancelDTR_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CancelDTR_BTN.Location = New System.Drawing.Point(9, 530)
        Me.CancelDTR_BTN.Name = "CancelDTR_BTN"
        Me.CancelDTR_BTN.Size = New System.Drawing.Size(103, 45)
        Me.CancelDTR_BTN.TabIndex = 117
        Me.CancelDTR_BTN.Text = "Cancel"
        Me.CancelDTR_BTN.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.RptViewer_DTR)
        Me.Panel1.Location = New System.Drawing.Point(463, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(685, 585)
        Me.Panel1.TabIndex = 114
        '
        'RptViewer_DTR
        '
        Me.RptViewer_DTR.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource2.Name = "DataSet1"
        ReportDataSource2.Value = Me.overAllBindingSource
        Me.RptViewer_DTR.LocalReport.DataSources.Add(ReportDataSource2)
        Me.RptViewer_DTR.LocalReport.ReportEmbeddedResource = "WindowsApp1.rpt_DTR_ByGroup.rdlc"
        Me.RptViewer_DTR.Location = New System.Drawing.Point(0, 0)
        Me.RptViewer_DTR.Name = "RptViewer_DTR"
        Me.RptViewer_DTR.ServerReport.BearerToken = Nothing
        Me.RptViewer_DTR.Size = New System.Drawing.Size(685, 585)
        Me.RptViewer_DTR.TabIndex = 112
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.Employee1_GroupB)
        Me.FlowLayoutPanel1.Controls.Add(Me.Employee2_GroupB)
        Me.FlowLayoutPanel1.Controls.Add(Me.Branch_group)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(5, 157)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(430, 352)
        Me.FlowLayoutPanel1.TabIndex = 113
        '
        'Employee1_GroupB
        '
        Me.Employee1_GroupB.Controls.Add(Me.DTR_Emp1_TXT)
        Me.Employee1_GroupB.Controls.Add(Me.Bio1_DTR_TXT)
        Me.Employee1_GroupB.Controls.Add(Me.EmpSelect1_BTN)
        Me.Employee1_GroupB.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Employee1_GroupB.Location = New System.Drawing.Point(3, 3)
        Me.Employee1_GroupB.Name = "Employee1_GroupB"
        Me.Employee1_GroupB.Size = New System.Drawing.Size(416, 104)
        Me.Employee1_GroupB.TabIndex = 88
        Me.Employee1_GroupB.TabStop = False
        Me.Employee1_GroupB.Text = "Employee 1"
        Me.Employee1_GroupB.Visible = False
        '
        'DTR_Emp1_TXT
        '
        Me.DTR_Emp1_TXT.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTR_Emp1_TXT.Location = New System.Drawing.Point(11, 63)
        Me.DTR_Emp1_TXT.Name = "DTR_Emp1_TXT"
        Me.DTR_Emp1_TXT.ReadOnly = True
        Me.DTR_Emp1_TXT.Size = New System.Drawing.Size(319, 33)
        Me.DTR_Emp1_TXT.TabIndex = 91
        '
        'Bio1_DTR_TXT
        '
        Me.Bio1_DTR_TXT.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bio1_DTR_TXT.Location = New System.Drawing.Point(11, 25)
        Me.Bio1_DTR_TXT.Name = "Bio1_DTR_TXT"
        Me.Bio1_DTR_TXT.Size = New System.Drawing.Size(319, 33)
        Me.Bio1_DTR_TXT.TabIndex = 90
        '
        'EmpSelect1_BTN
        '
        Me.EmpSelect1_BTN.AutoSize = True
        Me.EmpSelect1_BTN.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EmpSelect1_BTN.Location = New System.Drawing.Point(336, 26)
        Me.EmpSelect1_BTN.Name = "EmpSelect1_BTN"
        Me.EmpSelect1_BTN.Size = New System.Drawing.Size(62, 37)
        Me.EmpSelect1_BTN.TabIndex = 89
        Me.EmpSelect1_BTN.Text = "Select"
        Me.EmpSelect1_BTN.UseVisualStyleBackColor = True
        '
        'Employee2_GroupB
        '
        Me.Employee2_GroupB.Controls.Add(Me.DTR_Emp2_TXT)
        Me.Employee2_GroupB.Controls.Add(Me.Bio2_DTR_TXT)
        Me.Employee2_GroupB.Controls.Add(Me.EmpSelect2_BTN)
        Me.Employee2_GroupB.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Employee2_GroupB.Location = New System.Drawing.Point(3, 113)
        Me.Employee2_GroupB.Name = "Employee2_GroupB"
        Me.Employee2_GroupB.Size = New System.Drawing.Size(416, 106)
        Me.Employee2_GroupB.TabIndex = 92
        Me.Employee2_GroupB.TabStop = False
        Me.Employee2_GroupB.Text = "Employee 2"
        Me.Employee2_GroupB.Visible = False
        '
        'DTR_Emp2_TXT
        '
        Me.DTR_Emp2_TXT.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTR_Emp2_TXT.Location = New System.Drawing.Point(11, 65)
        Me.DTR_Emp2_TXT.Name = "DTR_Emp2_TXT"
        Me.DTR_Emp2_TXT.ReadOnly = True
        Me.DTR_Emp2_TXT.Size = New System.Drawing.Size(319, 33)
        Me.DTR_Emp2_TXT.TabIndex = 91
        '
        'Bio2_DTR_TXT
        '
        Me.Bio2_DTR_TXT.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bio2_DTR_TXT.Location = New System.Drawing.Point(11, 25)
        Me.Bio2_DTR_TXT.Name = "Bio2_DTR_TXT"
        Me.Bio2_DTR_TXT.Size = New System.Drawing.Size(319, 33)
        Me.Bio2_DTR_TXT.TabIndex = 90
        '
        'EmpSelect2_BTN
        '
        Me.EmpSelect2_BTN.AutoSize = True
        Me.EmpSelect2_BTN.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EmpSelect2_BTN.Location = New System.Drawing.Point(336, 26)
        Me.EmpSelect2_BTN.Name = "EmpSelect2_BTN"
        Me.EmpSelect2_BTN.Size = New System.Drawing.Size(62, 37)
        Me.EmpSelect2_BTN.TabIndex = 89
        Me.EmpSelect2_BTN.Text = "Select"
        Me.EmpSelect2_BTN.UseVisualStyleBackColor = True
        '
        'Branch_group
        '
        Me.Branch_group.Controls.Add(Me.Branch_DTR_TXT)
        Me.Branch_group.Controls.Add(Me.DTR_Branch_Combo)
        Me.Branch_group.Controls.Add(Me.Email_BTN)
        Me.Branch_group.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Branch_group.Location = New System.Drawing.Point(3, 225)
        Me.Branch_group.Name = "Branch_group"
        Me.Branch_group.Size = New System.Drawing.Size(416, 114)
        Me.Branch_group.TabIndex = 89
        Me.Branch_group.TabStop = False
        Me.Branch_group.Text = "Branch"
        Me.Branch_group.Visible = False
        '
        'Branch_DTR_TXT
        '
        Me.Branch_DTR_TXT.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Branch_DTR_TXT.Location = New System.Drawing.Point(10, 67)
        Me.Branch_DTR_TXT.Name = "Branch_DTR_TXT"
        Me.Branch_DTR_TXT.Size = New System.Drawing.Size(319, 33)
        Me.Branch_DTR_TXT.TabIndex = 92
        '
        'DTR_Branch_Combo
        '
        Me.DTR_Branch_Combo.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTR_Branch_Combo.FormattingEnabled = True
        Me.DTR_Branch_Combo.Location = New System.Drawing.Point(11, 28)
        Me.DTR_Branch_Combo.Name = "DTR_Branch_Combo"
        Me.DTR_Branch_Combo.Size = New System.Drawing.Size(319, 33)
        Me.DTR_Branch_Combo.TabIndex = 8
        Me.DTR_Branch_Combo.Text = "   Select Branch"
        '
        'Email_BTN
        '
        Me.Email_BTN.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Email_BTN.Location = New System.Drawing.Point(335, 64)
        Me.Email_BTN.Name = "Email_BTN"
        Me.Email_BTN.Size = New System.Drawing.Size(62, 37)
        Me.Email_BTN.TabIndex = 115
        Me.Email_BTN.Text = "Send"
        Me.Email_BTN.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(13, 80)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(53, 25)
        Me.Label22.TabIndex = 108
        Me.Label22.Text = "Payroll"
        '
        'Payslip_DTR_Combo
        '
        Me.Payslip_DTR_Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Payslip_DTR_Combo.DropDownWidth = 144
        Me.Payslip_DTR_Combo.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Payslip_DTR_Combo.FormattingEnabled = True
        Me.Payslip_DTR_Combo.Location = New System.Drawing.Point(18, 108)
        Me.Payslip_DTR_Combo.Name = "Payslip_DTR_Combo"
        Me.Payslip_DTR_Combo.Size = New System.Drawing.Size(167, 33)
        Me.Payslip_DTR_Combo.TabIndex = 107
        '
        'ContextMenu_Late
        '
        Me.ContextMenu_Late.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_Approve})
        Me.ContextMenu_Late.Name = "ContextMenu_Late"
        Me.ContextMenu_Late.Size = New System.Drawing.Size(127, 26)
        '
        'Menu_Approve
        '
        Me.Menu_Approve.Name = "Menu_Approve"
        Me.Menu_Approve.Size = New System.Drawing.Size(126, 22)
        Me.Menu_Approve.Text = "Approved"
        '
        'Close_LBL
        '
        Me.Close_LBL.AutoSize = True
        Me.Close_LBL.Font = New System.Drawing.Font("Dubai", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Close_LBL.Location = New System.Drawing.Point(1116, -3)
        Me.Close_LBL.Name = "Close_LBL"
        Me.Close_LBL.Size = New System.Drawing.Size(56, 32)
        Me.Close_LBL.TabIndex = 74
        Me.Close_LBL.Text = "Close"
        '
        'RE_UT_DGV
        '
        Me.RE_UT_DGV.HeaderText = "Undertime"
        Me.RE_UT_DGV.Name = "RE_UT_DGV"
        Me.RE_UT_DGV.ReadOnly = True
        Me.RE_UT_DGV.Width = 110
        '
        'RE_LATE_DGV
        '
        Me.RE_LATE_DGV.HeaderText = "Late"
        Me.RE_LATE_DGV.Name = "RE_LATE_DGV"
        Me.RE_LATE_DGV.ReadOnly = True
        Me.RE_LATE_DGV.Width = 110
        '
        'RE_OT_DGV
        '
        Me.RE_OT_DGV.HeaderText = "Overtime"
        Me.RE_OT_DGV.Name = "RE_OT_DGV"
        Me.RE_OT_DGV.ReadOnly = True
        Me.RE_OT_DGV.Width = 110
        '
        'RE_DAYS_DGV
        '
        Me.RE_DAYS_DGV.HeaderText = "Total Days"
        Me.RE_DAYS_DGV.Name = "RE_DAYS_DGV"
        Me.RE_DAYS_DGV.ReadOnly = True
        Me.RE_DAYS_DGV.Width = 110
        '
        'RE_NAME_DGV
        '
        Me.RE_NAME_DGV.HeaderText = "Name"
        Me.RE_NAME_DGV.Name = "RE_NAME_DGV"
        Me.RE_NAME_DGV.ReadOnly = True
        Me.RE_NAME_DGV.Width = 380
        '
        'RE_BIO_DGV
        '
        Me.RE_BIO_DGV.HeaderText = "Biometric No."
        Me.RE_BIO_DGV.Name = "RE_BIO_DGV"
        Me.RE_BIO_DGV.ReadOnly = True
        Me.RE_BIO_DGV.Width = 150
        '
        'RE_BRANCH_DGV
        '
        Me.RE_BRANCH_DGV.HeaderText = "Branch"
        Me.RE_BRANCH_DGV.Name = "RE_BRANCH_DGV"
        Me.RE_BRANCH_DGV.ReadOnly = True
        Me.RE_BRANCH_DGV.Width = 140
        '
        'txtNewRateRegHoliday
        '
        Me.txtNewRateRegHoliday.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNewRateRegHoliday.Location = New System.Drawing.Point(1056, 142)
        Me.txtNewRateRegHoliday.Name = "txtNewRateRegHoliday"
        Me.txtNewRateRegHoliday.Size = New System.Drawing.Size(79, 29)
        Me.txtNewRateRegHoliday.TabIndex = 172
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(932, 144)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(122, 22)
        Me.Label41.TabIndex = 173
        Me.Label41.Text = "New Reg. Hol.     (dd)"
        '
        'txtNewRateSpecHoliday
        '
        Me.txtNewRateSpecHoliday.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNewRateSpecHoliday.Location = New System.Drawing.Point(1056, 177)
        Me.txtNewRateSpecHoliday.Name = "txtNewRateSpecHoliday"
        Me.txtNewRateSpecHoliday.Size = New System.Drawing.Size(79, 29)
        Me.txtNewRateSpecHoliday.TabIndex = 174
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.Location = New System.Drawing.Point(933, 180)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(122, 22)
        Me.Label42.TabIndex = 175
        Me.Label42.Text = "New Spec. Hol.    (hr)"
        '
        'frmAttendance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1169, 665)
        Me.Controls.Add(Me.Close_LBL)
        Me.Controls.Add(Me.Attendance_Tab)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmAttendance"
        Me.Text = " "
        CType(Me.overAllBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtr_all, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Attendance_Tab.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.PI_Panel.ResumeLayout(False)
        Me.PI_Panel.PerformLayout()
        Me.P_Add_Panel.ResumeLayout(False)
        CType(Me.PI_Days, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Manual_Tab.ResumeLayout(False)
        Me.Manual_Tab.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.AM_OT_NUP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SIL_Panel.ResumeLayout(False)
        CType(Me.SIL_NUP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.B_PI_Panel.ResumeLayout(False)
        Me.B_PI_Panel.PerformLayout()
        Me.B_P_Add_Panel.ResumeLayout(False)
        CType(Me.B_PI_Days, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.newRateOT_NUP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NewRateDaysCovered_NUP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SIL7_NUP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Overtime7_NUP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.Employee1_GroupB.ResumeLayout(False)
        Me.Employee1_GroupB.PerformLayout()
        Me.Employee2_GroupB.ResumeLayout(False)
        Me.Employee2_GroupB.PerformLayout()
        Me.Branch_group.ResumeLayout(False)
        Me.Branch_group.PerformLayout()
        Me.ContextMenu_Late.ResumeLayout(False)
        CType(Me.printDTRBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Attendance_Tab As TabControl
    Friend WithEvents Manual_Tab As TabPage
    Friend WithEvents Name_TXT As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents BiometricID_TXT As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Close_LBL As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents TotalUTHR_LBL As Label
    Friend WithEvents TotalLateHR_LBL As Label
    Friend WithEvents SIL_LBL As Label
    Friend WithEvents TotalDays_LBL As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents CheckALL_CheckBox As CheckBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Calculate_BTN As Button
    Friend WithEvents Save_BTN As Button
    Friend WithEvents Cancel_BTN As Button
    Friend WithEvents SearchEMP_BTN As Button
    Friend WithEvents Date_DataGrid As DataGridViewTextBoxColumn
    Friend WithEvents AM_In_DataGrid As DataGridViewComboBoxColumn
    Friend WithEvents AM_Out_DataGrid As DataGridViewComboBoxColumn
    Friend WithEvents PM_IN_DataGrid As DataGridViewComboBoxColumn
    Friend WithEvents PM_Out_DataGrid As DataGridViewComboBoxColumn
    Friend WithEvents Select_Datagrid As DataGridViewCheckBoxColumn
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents TotalSHoliday_LBL As Label
    Friend WithEvents TotalRHoliday_LBL As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents TotalOTHr_LBL As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents Import_BTN As Button
    Friend WithEvents Path_TXT As TextBox
    Friend WithEvents OpenFile_BTN As Button
    Friend WithEvents Paydate_ComboB As ComboBox
    Friend WithEvents UT_BTN As Button
    Friend WithEvents Late_BTN As Button
    Friend WithEvents OT_BTN As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Label20 As Label
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents Employee1_GroupB As GroupBox
    Friend WithEvents Preview_BTN As Button
    Friend WithEvents DTR_Emp1_TXT As TextBox
    Friend WithEvents Bio1_DTR_TXT As TextBox
    Friend WithEvents EmpSelect1_BTN As Button
    Friend WithEvents RptViewer_DTR As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents Employee_RadioB As RadioButton
    Friend WithEvents Label22 As Label
    Friend WithEvents Payslip_DTR_Combo As ComboBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents CancelDTR_BTN As Button
    Friend WithEvents Email_BTN As Button
    Friend WithEvents printDTRBindingSource As BindingSource
    Friend WithEvents Search_TXT As TextBox
    Friend WithEvents Search_BTN As Button
    Friend WithEvents RE_UT_DGV As DataGridViewTextBoxColumn
    Friend WithEvents RE_LATE_DGV As DataGridViewTextBoxColumn
    Friend WithEvents RE_OT_DGV As DataGridViewTextBoxColumn
    Friend WithEvents RE_DAYS_DGV As DataGridViewTextBoxColumn
    Friend WithEvents RE_NAME_DGV As DataGridViewTextBoxColumn
    Friend WithEvents RE_BIO_DGV As DataGridViewTextBoxColumn
    Friend WithEvents RE_BRANCH_DGV As DataGridViewTextBoxColumn
    Friend WithEvents overAllBindingSource As BindingSource
    Friend WithEvents dtr_all As dtr_all
    Friend WithEvents Branch_group As GroupBox
    Friend WithEvents DTR_Branch_Combo As ComboBox
    Friend WithEvents HO_RadioB As RadioButton
    Friend WithEvents GroupBranch_RadioB As RadioButton
    Friend WithEvents Employee2_GroupB As GroupBox
    Friend WithEvents DTR_Emp2_TXT As TextBox
    Friend WithEvents Bio2_DTR_TXT As TextBox
    Friend WithEvents EmpSelect2_BTN As Button
    Friend WithEvents Branch_DTR_TXT As TextBox
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Label27 As Label
    Friend WithEvents Bio7_TXT As TextBox
    Friend WithEvents SearchEmp7_BTN As Button
    Friend WithEvents Label28 As Label
    Friend WithEvents Emp7_TXT As TextBox
    Friend WithEvents Search7_TXT As TextBox
    Friend WithEvents Search7_BTN As Button
    Friend WithEvents Label30 As Label
    Friend WithEvents Paydate7_CB As ComboBox
    Friend WithEvents SIL_BTN As Button
    Friend WithEvents SIL_Panel As Panel
    Friend WithEvents CancelSIL_BTN As Button
    Friend WithEvents AddSIL_BTN As Button
    Friend WithEvents Label32 As Label
    Friend WithEvents TimeOut_TXT As TextBox
    Friend WithEvents Label31 As Label
    Friend WithEvents TimeIn_TXT As TextBox
    Friend WithEvents Biometric_LV As ListView
    Friend WithEvents ColumnHeader17 As ColumnHeader
    Friend WithEvents ColumnHeader18 As ColumnHeader
    Friend WithEvents ColumnHeader19 As ColumnHeader
    Friend WithEvents ColumnHeader20 As ColumnHeader
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents Label34 As Label
    Friend WithEvents Label33 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents AM_OT_NUP As NumericUpDown
    Friend WithEvents Label35 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Cancel_lbl As Label
    Friend WithEvents SIL_NUP As NumericUpDown
    Friend WithEvents P_Add_Panel As Panel
    Friend WithEvents PI_Days As NumericUpDown
    Friend WithEvents PIDaysX_btn As Button
    Friend WithEvents PIDaysCheck_btn As Button
    Friend WithEvents AddPIDays_btn As Button
    Friend WithEvents PIDays_lbl As Label
    Friend WithEvents Label38 As Label
    Friend WithEvents PI_Panel As Panel
    Friend WithEvents ContextMenu_Late As ContextMenuStrip
    Friend WithEvents Menu_Approve As ToolStripMenuItem
    Friend WithEvents Branch_LV As ListView
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents ColumnHeader9 As ColumnHeader
    Friend WithEvents Browse7_BTN As Button
    Friend WithEvents Path7_TXT As TextBox
    Friend WithEvents Import7_BTN As Button
    Friend WithEvents B_PI_Panel As Panel
    Friend WithEvents Label47 As Label
    Friend WithEvents B_AddPIDays_btn As Button
    Friend WithEvents B_P_Add_Panel As Panel
    Friend WithEvents B_PI_Days As NumericUpDown
    Friend WithEvents B_PIDaysX_btn As Button
    Friend WithEvents B_PIDaysCheck_btn As Button
    Friend WithEvents B_PIDays_lbl As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents txtRegNightShiftOT As TextBox
    Friend WithEvents Label58 As Label
    Friend WithEvents txtSpecNightShiftOT As TextBox
    Friend WithEvents Label59 As Label
    Friend WithEvents txtOrdNightShiftOT As TextBox
    Friend WithEvents Label60 As Label
    Friend WithEvents txtRegRestDayOT As TextBox
    Friend WithEvents Label56 As Label
    Friend WithEvents txtRegOT As TextBox
    Friend WithEvents Label57 As Label
    Friend WithEvents txtSpecRestDayOT As TextBox
    Friend WithEvents Label53 As Label
    Friend WithEvents txtSpecOT As TextBox
    Friend WithEvents Label54 As Label
    Friend WithEvents txtRestDayOT As TextBox
    Friend WithEvents Label55 As Label
    Friend WithEvents txtRegNightShift As TextBox
    Friend WithEvents txtRegRestDay As TextBox
    Friend WithEvents Label51 As Label
    Friend WithEvents Label50 As Label
    Friend WithEvents txtSpecRestDay As TextBox
    Friend WithEvents SIL7_NUP As NumericUpDown
    Friend WithEvents Label13 As Label
    Friend WithEvents txtSpecNightShift As TextBox
    Friend WithEvents Label49 As Label
    Friend WithEvents Label52 As Label
    Friend WithEvents txtRestDayDuty As TextBox
    Friend WithEvents Label48 As Label
    Friend WithEvents Label39 As Label
    Friend WithEvents Overtime7_NUP As NumericUpDown
    Friend WithEvents Save7_BTN As Button
    Friend WithEvents Cancel7_BTN As Button
    Friend WithEvents SpecHol7_TXT As TextBox
    Friend WithEvents Label36 As Label
    Friend WithEvents Undertime7_TXT As TextBox
    Friend WithEvents Label29 As Label
    Friend WithEvents Days7_TXT As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents RegHol7_TXT As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents Night7_TXT As TextBox
    Friend WithEvents Label37 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents Late7_TXT As TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents NewRateDaysCovered_NUP As NumericUpDown
    Friend WithEvents Label40 As Label
    Friend WithEvents newRateOT_NUP As NumericUpDown
    Friend WithEvents txtNewRateUT As TextBox
    Friend WithEvents Label43 As Label
    Friend WithEvents Label44 As Label
    Friend WithEvents txtNewRateLate As TextBox
    Friend WithEvents Label45 As Label
    Friend WithEvents txtNewRateSpecHoliday As TextBox
    Friend WithEvents Label42 As Label
    Friend WithEvents txtNewRateRegHoliday As TextBox
    Friend WithEvents Label41 As Label
End Class
