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
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.overAllBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dtr_all = New WindowsApp1.dtr_all()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Attendance_Tab = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
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
        Me.CancelSIL_BTN = New System.Windows.Forms.Button()
        Me.AddSIL_BTN = New System.Windows.Forms.Button()
        Me.SIL_NUP = New System.Windows.Forms.NumericUpDown()
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
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Paydate7_CB = New System.Windows.Forms.ComboBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.SIL7_NUP = New System.Windows.Forms.NumericUpDown()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Undertime7_TXT = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Cancel7_BTN = New System.Windows.Forms.Button()
        Me.Save7_BTN = New System.Windows.Forms.Button()
        Me.Days7_TXT = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Overtime7_TXT = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Night7_TXT = New System.Windows.Forms.TextBox()
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
        Me.Seven_Grid = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.Close_LBL = New System.Windows.Forms.Label()
        Me.printDTRBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RE_UT_DGV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RE_LATE_DGV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RE_OT_DGV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RE_DAYS_DGV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RE_NAME_DGV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RE_BIO_DGV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RE_BRANCH_DGV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.overAllBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtr_all, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Attendance_Tab.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Manual_Tab.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.AM_OT_NUP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SIL_Panel.SuspendLayout()
        CType(Me.SIL_NUP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.SIL7_NUP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Seven_Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.Employee1_GroupB.SuspendLayout()
        Me.Employee2_GroupB.SuspendLayout()
        Me.Branch_group.SuspendLayout()
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
        Me.TabPage1.Text = "    Biometric    "
        Me.TabPage1.UseVisualStyleBackColor = True
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
        Me.Search_TXT.Location = New System.Drawing.Point(383, 87)
        Me.Search_TXT.Name = "Search_TXT"
        Me.Search_TXT.Size = New System.Drawing.Size(368, 33)
        Me.Search_TXT.TabIndex = 103
        '
        'Search_BTN
        '
        Me.Search_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Search_BTN.Location = New System.Drawing.Point(759, 87)
        Me.Search_BTN.Name = "Search_BTN"
        Me.Search_BTN.Size = New System.Drawing.Size(82, 33)
        Me.Search_BTN.TabIndex = 104
        Me.Search_BTN.Text = "Search"
        Me.Search_BTN.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(6, 91)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(98, 25)
        Me.Label20.TabIndex = 11
        Me.Label20.Text = "Search Payroll"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(1046, 96)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(87, 33)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "Refresh"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Paydate_ComboB
        '
        Me.Paydate_ComboB.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Paydate_ComboB.FormattingEnabled = True
        Me.Paydate_ComboB.Location = New System.Drawing.Point(111, 87)
        Me.Paydate_ComboB.Name = "Paydate_ComboB"
        Me.Paydate_ComboB.Size = New System.Drawing.Size(197, 33)
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
        Me.Manual_Tab.Text = "    Manual    "
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
        Me.SIL_Panel.Controls.Add(Me.CancelSIL_BTN)
        Me.SIL_Panel.Controls.Add(Me.AddSIL_BTN)
        Me.SIL_Panel.Controls.Add(Me.SIL_NUP)
        Me.SIL_Panel.Location = New System.Drawing.Point(437, 537)
        Me.SIL_Panel.Name = "SIL_Panel"
        Me.SIL_Panel.Size = New System.Drawing.Size(149, 48)
        Me.SIL_Panel.TabIndex = 115
        Me.SIL_Panel.Visible = False
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
        'SIL_NUP
        '
        Me.SIL_NUP.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SIL_NUP.Location = New System.Drawing.Point(7, 7)
        Me.SIL_NUP.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.SIL_NUP.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.SIL_NUP.Name = "SIL_NUP"
        Me.SIL_NUP.Size = New System.Drawing.Size(49, 35)
        Me.SIL_NUP.TabIndex = 0
        Me.SIL_NUP.Value = New Decimal(New Integer() {1, 0, 0, 0})
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
        Me.Cancel_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel_BTN.Location = New System.Drawing.Point(27, 526)
        Me.Cancel_BTN.Name = "Cancel_BTN"
        Me.Cancel_BTN.Size = New System.Drawing.Size(130, 37)
        Me.Cancel_BTN.TabIndex = 81
        Me.Cancel_BTN.Text = "Cancel"
        Me.Cancel_BTN.UseVisualStyleBackColor = True
        '
        'Save_BTN
        '
        Me.Save_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Save_BTN.Location = New System.Drawing.Point(300, 526)
        Me.Save_BTN.Name = "Save_BTN"
        Me.Save_BTN.Size = New System.Drawing.Size(99, 37)
        Me.Save_BTN.TabIndex = 76
        Me.Save_BTN.Text = "Save"
        Me.Save_BTN.UseVisualStyleBackColor = True
        '
        'Calculate_BTN
        '
        Me.Calculate_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Calculate_BTN.Location = New System.Drawing.Point(167, 526)
        Me.Calculate_BTN.Name = "Calculate_BTN"
        Me.Calculate_BTN.Size = New System.Drawing.Size(119, 37)
        Me.Calculate_BTN.TabIndex = 75
        Me.Calculate_BTN.Text = "Calculate"
        Me.Calculate_BTN.UseVisualStyleBackColor = True
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
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle10
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Date_DataGrid, Me.AM_In_DataGrid, Me.AM_Out_DataGrid, Me.PM_IN_DataGrid, Me.PM_Out_DataGrid, Me.Select_Datagrid})
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.InactiveCaption
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle13
        Me.DataGridView1.Location = New System.Drawing.Point(6, 44)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.Transparent
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.Transparent
        Me.DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle14
        Me.DataGridView1.Size = New System.Drawing.Size(684, 487)
        Me.DataGridView1.TabIndex = 65
        '
        'Date_DataGrid
        '
        DataGridViewCellStyle11.NullValue = Nothing
        Me.Date_DataGrid.DefaultCellStyle = DataGridViewCellStyle11
        Me.Date_DataGrid.HeaderText = "Date"
        Me.Date_DataGrid.Name = "Date_DataGrid"
        Me.Date_DataGrid.ReadOnly = True
        Me.Date_DataGrid.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Date_DataGrid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Date_DataGrid.Width = 233
        '
        'AM_In_DataGrid
        '
        DataGridViewCellStyle12.Format = "t"
        DataGridViewCellStyle12.NullValue = Nothing
        Me.AM_In_DataGrid.DefaultCellStyle = DataGridViewCellStyle12
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
        Me.TabPage2.Controls.Add(Me.Seven_Grid)
        Me.TabPage2.Location = New System.Drawing.Point(4, 41)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1151, 591)
        Me.TabPage2.TabIndex = 4
        Me.TabPage2.Text = "    With Shifting    "
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(9, 195)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(53, 25)
        Me.Label30.TabIndex = 111
        Me.Label30.Text = "Payroll"
        '
        'Paydate7_CB
        '
        Me.Paydate7_CB.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Paydate7_CB.FormattingEnabled = True
        Me.Paydate7_CB.Location = New System.Drawing.Point(89, 192)
        Me.Paydate7_CB.Name = "Paydate7_CB"
        Me.Paydate7_CB.Size = New System.Drawing.Size(151, 33)
        Me.Paydate7_CB.TabIndex = 110
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.SIL7_NUP)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.Undertime7_TXT)
        Me.Panel2.Controls.Add(Me.Label29)
        Me.Panel2.Controls.Add(Me.Cancel7_BTN)
        Me.Panel2.Controls.Add(Me.Save7_BTN)
        Me.Panel2.Controls.Add(Me.Days7_TXT)
        Me.Panel2.Controls.Add(Me.Label21)
        Me.Panel2.Controls.Add(Me.Overtime7_TXT)
        Me.Panel2.Controls.Add(Me.Label23)
        Me.Panel2.Controls.Add(Me.Night7_TXT)
        Me.Panel2.Controls.Add(Me.Label26)
        Me.Panel2.Controls.Add(Me.Late7_TXT)
        Me.Panel2.Controls.Add(Me.Label25)
        Me.Panel2.Location = New System.Drawing.Point(516, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(629, 183)
        Me.Panel2.TabIndex = 109
        '
        'SIL7_NUP
        '
        Me.SIL7_NUP.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SIL7_NUP.Location = New System.Drawing.Point(482, 93)
        Me.SIL7_NUP.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.SIL7_NUP.Name = "SIL7_NUP"
        Me.SIL7_NUP.Size = New System.Drawing.Size(135, 35)
        Me.SIL7_NUP.TabIndex = 113
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(351, 100)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(65, 27)
        Me.Label13.TabIndex = 112
        Me.Label13.Text = "SIL (dd)"
        '
        'Undertime7_TXT
        '
        Me.Undertime7_TXT.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Undertime7_TXT.Location = New System.Drawing.Point(482, 52)
        Me.Undertime7_TXT.Name = "Undertime7_TXT"
        Me.Undertime7_TXT.Size = New System.Drawing.Size(135, 35)
        Me.Undertime7_TXT.TabIndex = 109
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(351, 55)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(125, 27)
        Me.Label29.TabIndex = 110
        Me.Label29.Text = "Undertime  (mm)"
        '
        'Cancel7_BTN
        '
        Me.Cancel7_BTN.BackColor = System.Drawing.Color.RosyBrown
        Me.Cancel7_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cancel7_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel7_BTN.Location = New System.Drawing.Point(425, 143)
        Me.Cancel7_BTN.Name = "Cancel7_BTN"
        Me.Cancel7_BTN.Size = New System.Drawing.Size(87, 37)
        Me.Cancel7_BTN.TabIndex = 108
        Me.Cancel7_BTN.Text = "Cancel"
        Me.Cancel7_BTN.UseVisualStyleBackColor = False
        '
        'Save7_BTN
        '
        Me.Save7_BTN.BackColor = System.Drawing.Color.LightSalmon
        Me.Save7_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Save7_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Save7_BTN.Location = New System.Drawing.Point(536, 143)
        Me.Save7_BTN.Name = "Save7_BTN"
        Me.Save7_BTN.Size = New System.Drawing.Size(81, 37)
        Me.Save7_BTN.TabIndex = 107
        Me.Save7_BTN.Text = "Save"
        Me.Save7_BTN.UseVisualStyleBackColor = False
        '
        'Days7_TXT
        '
        Me.Days7_TXT.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Days7_TXT.Location = New System.Drawing.Point(137, 16)
        Me.Days7_TXT.Name = "Days7_TXT"
        Me.Days7_TXT.Size = New System.Drawing.Size(140, 35)
        Me.Days7_TXT.TabIndex = 74
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(22, 19)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(87, 27)
        Me.Label21.TabIndex = 75
        Me.Label21.Text = "No. of Days"
        '
        'Overtime7_TXT
        '
        Me.Overtime7_TXT.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Overtime7_TXT.Location = New System.Drawing.Point(137, 59)
        Me.Overtime7_TXT.Name = "Overtime7_TXT"
        Me.Overtime7_TXT.Size = New System.Drawing.Size(140, 35)
        Me.Overtime7_TXT.TabIndex = 76
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(22, 62)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(72, 27)
        Me.Label23.TabIndex = 77
        Me.Label23.Text = "Overtime"
        '
        'Night7_TXT
        '
        Me.Night7_TXT.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Night7_TXT.Location = New System.Drawing.Point(482, 10)
        Me.Night7_TXT.Name = "Night7_TXT"
        Me.Night7_TXT.Size = New System.Drawing.Size(135, 35)
        Me.Night7_TXT.TabIndex = 78
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(351, 13)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(82, 27)
        Me.Label26.TabIndex = 79
        Me.Label26.Text = "Night Rate"
        '
        'Late7_TXT
        '
        Me.Late7_TXT.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Late7_TXT.Location = New System.Drawing.Point(137, 100)
        Me.Late7_TXT.Name = "Late7_TXT"
        Me.Late7_TXT.Size = New System.Drawing.Size(140, 35)
        Me.Late7_TXT.TabIndex = 80
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(22, 100)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(88, 27)
        Me.Label25.TabIndex = 81
        Me.Label25.Text = "Late   (mm)"
        '
        'Search7_TXT
        '
        Me.Search7_TXT.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Search7_TXT.Location = New System.Drawing.Point(246, 192)
        Me.Search7_TXT.Name = "Search7_TXT"
        Me.Search7_TXT.Size = New System.Drawing.Size(368, 33)
        Me.Search7_TXT.TabIndex = 105
        '
        'Search7_BTN
        '
        Me.Search7_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Search7_BTN.Location = New System.Drawing.Point(630, 192)
        Me.Search7_BTN.Name = "Search7_BTN"
        Me.Search7_BTN.Size = New System.Drawing.Size(82, 33)
        Me.Search7_BTN.TabIndex = 106
        Me.Search7_BTN.Text = "Search"
        Me.Search7_BTN.UseVisualStyleBackColor = True
        '
        'SearchEmp7_BTN
        '
        Me.SearchEmp7_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SearchEmp7_BTN.Location = New System.Drawing.Point(379, 57)
        Me.SearchEmp7_BTN.Name = "SearchEmp7_BTN"
        Me.SearchEmp7_BTN.Size = New System.Drawing.Size(38, 30)
        Me.SearchEmp7_BTN.TabIndex = 87
        Me.SearchEmp7_BTN.Text = "..."
        Me.SearchEmp7_BTN.UseVisualStyleBackColor = True
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(9, 58)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(48, 25)
        Me.Label28.TabIndex = 85
        Me.Label28.Text = "Name"
        '
        'Emp7_TXT
        '
        Me.Emp7_TXT.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Emp7_TXT.Location = New System.Drawing.Point(89, 56)
        Me.Emp7_TXT.Name = "Emp7_TXT"
        Me.Emp7_TXT.ReadOnly = True
        Me.Emp7_TXT.Size = New System.Drawing.Size(278, 33)
        Me.Emp7_TXT.TabIndex = 86
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(9, 19)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(60, 27)
        Me.Label27.TabIndex = 84
        Me.Label27.Text = "Bio No."
        '
        'Bio7_TXT
        '
        Me.Bio7_TXT.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bio7_TXT.Location = New System.Drawing.Point(89, 14)
        Me.Bio7_TXT.Name = "Bio7_TXT"
        Me.Bio7_TXT.Size = New System.Drawing.Size(151, 29)
        Me.Bio7_TXT.TabIndex = 83
        '
        'Seven_Grid
        '
        Me.Seven_Grid.AllowUserToAddRows = False
        Me.Seven_Grid.AllowUserToDeleteRows = False
        Me.Seven_Grid.AllowUserToResizeRows = False
        Me.Seven_Grid.BackgroundColor = System.Drawing.Color.White
        Me.Seven_Grid.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Seven_Grid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.Seven_Grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Dubai", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Seven_Grid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.Seven_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Seven_Grid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.Column1})
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Dubai", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Seven_Grid.DefaultCellStyle = DataGridViewCellStyle9
        Me.Seven_Grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.Seven_Grid.Location = New System.Drawing.Point(3, 231)
        Me.Seven_Grid.Name = "Seven_Grid"
        Me.Seven_Grid.ReadOnly = True
        Me.Seven_Grid.RowHeadersVisible = False
        Me.Seven_Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Seven_Grid.Size = New System.Drawing.Size(1142, 353)
        Me.Seven_Grid.TabIndex = 82
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Bio No."
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 130
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Name"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 390
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Total Days"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 125
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Overtime"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 125
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Late"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 120
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Undertime"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 120
        '
        'Column1
        '
        Me.Column1.HeaderText = "Night Rate"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 110
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
        Me.Preview_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Preview_BTN.Location = New System.Drawing.Point(332, 530)
        Me.Preview_BTN.Name = "Preview_BTN"
        Me.Preview_BTN.Size = New System.Drawing.Size(103, 45)
        Me.Preview_BTN.TabIndex = 96
        Me.Preview_BTN.Text = "Preview"
        Me.Preview_BTN.UseVisualStyleBackColor = True
        '
        'CancelDTR_BTN
        '
        Me.CancelDTR_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CancelDTR_BTN.Location = New System.Drawing.Point(9, 530)
        Me.CancelDTR_BTN.Name = "CancelDTR_BTN"
        Me.CancelDTR_BTN.Size = New System.Drawing.Size(103, 45)
        Me.CancelDTR_BTN.TabIndex = 117
        Me.CancelDTR_BTN.Text = "Cancel"
        Me.CancelDTR_BTN.UseVisualStyleBackColor = True
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
        Me.Payslip_DTR_Combo.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Payslip_DTR_Combo.FormattingEnabled = True
        Me.Payslip_DTR_Combo.Location = New System.Drawing.Point(18, 108)
        Me.Payslip_DTR_Combo.Name = "Payslip_DTR_Combo"
        Me.Payslip_DTR_Combo.Size = New System.Drawing.Size(319, 33)
        Me.Payslip_DTR_Combo.TabIndex = 107
        Me.Payslip_DTR_Combo.Text = "   Select Date"
        '
        'Close_LBL
        '
        Me.Close_LBL.AutoSize = True
        Me.Close_LBL.Font = New System.Drawing.Font("Dubai", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Close_LBL.Location = New System.Drawing.Point(1116, -3)
        Me.Close_LBL.Name = "Close_LBL"
        Me.Close_LBL.Size = New System.Drawing.Size(57, 32)
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
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.SIL7_NUP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Seven_Grid, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents Label25 As Label
    Friend WithEvents Late7_TXT As TextBox
    Friend WithEvents Label26 As Label
    Friend WithEvents Night7_TXT As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents Overtime7_TXT As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents Days7_TXT As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents Bio7_TXT As TextBox
    Friend WithEvents Seven_Grid As DataGridView
    Friend WithEvents SearchEmp7_BTN As Button
    Friend WithEvents Label28 As Label
    Friend WithEvents Emp7_TXT As TextBox
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Search7_TXT As TextBox
    Friend WithEvents Search7_BTN As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Cancel7_BTN As Button
    Friend WithEvents Save7_BTN As Button
    Friend WithEvents Undertime7_TXT As TextBox
    Friend WithEvents Label29 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents Paydate7_CB As ComboBox
    Friend WithEvents SIL_BTN As Button
    Friend WithEvents SIL_Panel As Panel
    Friend WithEvents SIL_NUP As NumericUpDown
    Friend WithEvents CancelSIL_BTN As Button
    Friend WithEvents AddSIL_BTN As Button
    Friend WithEvents Label13 As Label
    Friend WithEvents SIL7_NUP As NumericUpDown
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
End Class
