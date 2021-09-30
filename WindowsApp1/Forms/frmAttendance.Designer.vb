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
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.overAllBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dtr_all = New WindowsApp1.dtr_all()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Attendance_Tab = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Search_TXT = New System.Windows.Forms.TextBox()
        Me.Search_BTN = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Bio_grid = New System.Windows.Forms.DataGridView()
        Me.BIOID_DGVV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Name_DGVV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRESENT_DGVV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Overtime_DGVV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Late_DGVV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Undertime_DGVV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Paydate_ComboB = New System.Windows.Forms.ComboBox()
        Me.Import_BTN = New System.Windows.Forms.Button()
        Me.Path_TXT = New System.Windows.Forms.TextBox()
        Me.OpenFile_BTN = New System.Windows.Forms.Button()
        Me.Manual_Tab = New System.Windows.Forms.TabPage()
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
        Me.Label19 = New System.Windows.Forms.Label()
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
        Me.TotalAbsent_LBL = New System.Windows.Forms.Label()
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
        Me.SearchEMP_BTN = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Name_TXT = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BiometricID_TXT = New System.Windows.Forms.TextBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.GroupBranch_RadioB = New System.Windows.Forms.RadioButton()
        Me.Employee_RadioB = New System.Windows.Forms.RadioButton()
        Me.HO_RadioB = New System.Windows.Forms.RadioButton()
        Me.Preview_BTN = New System.Windows.Forms.Button()
        Me.CancelDTR_BTN = New System.Windows.Forms.Button()
        Me.Email_BTN = New System.Windows.Forms.Button()
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
        Me.DTR_Branch_Combo = New System.Windows.Forms.ComboBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Payslip_DTR_Combo = New System.Windows.Forms.ComboBox()
        Me.Close_LBL = New System.Windows.Forms.Label()
        Me.printDTRBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Context_Records = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Menu_Remove = New System.Windows.Forms.ToolStripMenuItem()
        Me.RE_UT_DGV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RE_LATE_DGV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RE_OT_DGV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RE_DAYS_DGV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RE_NAME_DGV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RE_BIO_DGV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RE_BRANCH_DGV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Branch_DTR_TXT = New System.Windows.Forms.TextBox()
        CType(Me.overAllBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtr_all, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Attendance_Tab.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.Bio_grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Manual_Tab.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.Employee1_GroupB.SuspendLayout()
        Me.Employee2_GroupB.SuspendLayout()
        Me.Branch_group.SuspendLayout()
        CType(Me.printDTRBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Context_Records.SuspendLayout()
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
        Me.TabPage1.Controls.Add(Me.Search_TXT)
        Me.TabPage1.Controls.Add(Me.Search_BTN)
        Me.TabPage1.Controls.Add(Me.Label20)
        Me.TabPage1.Controls.Add(Me.Bio_grid)
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
        'Bio_grid
        '
        Me.Bio_grid.AllowUserToAddRows = False
        Me.Bio_grid.AllowUserToDeleteRows = False
        Me.Bio_grid.AllowUserToResizeRows = False
        Me.Bio_grid.BackgroundColor = System.Drawing.Color.White
        Me.Bio_grid.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Bio_grid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.Bio_grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Bio_grid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.Bio_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Bio_grid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BIOID_DGVV, Me.Name_DGVV, Me.PRESENT_DGVV, Me.Overtime_DGVV, Me.Late_DGVV, Me.Undertime_DGVV})
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Bio_grid.DefaultCellStyle = DataGridViewCellStyle9
        Me.Bio_grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.Bio_grid.Location = New System.Drawing.Point(6, 136)
        Me.Bio_grid.Name = "Bio_grid"
        Me.Bio_grid.ReadOnly = True
        Me.Bio_grid.RowHeadersVisible = False
        Me.Bio_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Bio_grid.Size = New System.Drawing.Size(1127, 449)
        Me.Bio_grid.TabIndex = 1
        '
        'BIOID_DGVV
        '
        Me.BIOID_DGVV.HeaderText = "Biometric No."
        Me.BIOID_DGVV.Name = "BIOID_DGVV"
        Me.BIOID_DGVV.ReadOnly = True
        Me.BIOID_DGVV.Width = 150
        '
        'Name_DGVV
        '
        Me.Name_DGVV.HeaderText = "Name"
        Me.Name_DGVV.Name = "Name_DGVV"
        Me.Name_DGVV.ReadOnly = True
        Me.Name_DGVV.Width = 430
        '
        'PRESENT_DGVV
        '
        Me.PRESENT_DGVV.HeaderText = "Total Days"
        Me.PRESENT_DGVV.Name = "PRESENT_DGVV"
        Me.PRESENT_DGVV.ReadOnly = True
        Me.PRESENT_DGVV.Width = 135
        '
        'Overtime_DGVV
        '
        Me.Overtime_DGVV.HeaderText = "Overtime"
        Me.Overtime_DGVV.Name = "Overtime_DGVV"
        Me.Overtime_DGVV.ReadOnly = True
        Me.Overtime_DGVV.Width = 135
        '
        'Late_DGVV
        '
        Me.Late_DGVV.HeaderText = "Late"
        Me.Late_DGVV.Name = "Late_DGVV"
        Me.Late_DGVV.ReadOnly = True
        Me.Late_DGVV.Width = 130
        '
        'Undertime_DGVV
        '
        Me.Undertime_DGVV.HeaderText = "Undertime"
        Me.Undertime_DGVV.Name = "Undertime_DGVV"
        Me.Undertime_DGVV.ReadOnly = True
        Me.Undertime_DGVV.Width = 130
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
        Me.Import_BTN.Location = New System.Drawing.Point(467, 17)
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
        Me.Path_TXT.Size = New System.Drawing.Size(368, 29)
        Me.Path_TXT.TabIndex = 4
        '
        'OpenFile_BTN
        '
        Me.OpenFile_BTN.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OpenFile_BTN.Location = New System.Drawing.Point(383, 17)
        Me.OpenFile_BTN.Name = "OpenFile_BTN"
        Me.OpenFile_BTN.Size = New System.Drawing.Size(78, 31)
        Me.OpenFile_BTN.TabIndex = 3
        Me.OpenFile_BTN.Text = "Browse"
        Me.OpenFile_BTN.UseVisualStyleBackColor = True
        '
        'Manual_Tab
        '
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
        Me.Manual_Tab.Controls.Add(Me.Label19)
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
        Me.Manual_Tab.Controls.Add(Me.TotalAbsent_LBL)
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
        'UT_BTN
        '
        Me.UT_BTN.Font = New System.Drawing.Font("Dubai", 8.249999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UT_BTN.Location = New System.Drawing.Point(364, 407)
        Me.UT_BTN.Name = "UT_BTN"
        Me.UT_BTN.Size = New System.Drawing.Size(44, 26)
        Me.UT_BTN.TabIndex = 113
        Me.UT_BTN.Text = "Clear"
        Me.UT_BTN.UseVisualStyleBackColor = True
        '
        'Late_BTN
        '
        Me.Late_BTN.Font = New System.Drawing.Font("Dubai", 8.249999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Late_BTN.Location = New System.Drawing.Point(364, 364)
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
        Me.Label4.Location = New System.Drawing.Point(282, 441)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 25)
        Me.Label4.TabIndex = 106
        Me.Label4.Text = "Day/s"
        Me.Label4.Visible = False
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Dubai Light", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(282, 193)
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
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Dubai Light", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(281, 318)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(56, 25)
        Me.Label19.TabIndex = 98
        Me.Label19.Text = "Hour/s"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Dubai Light", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(282, 274)
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
        Me.Label17.Location = New System.Drawing.Point(282, 232)
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
        Me.TotalUTHR_LBL.Location = New System.Drawing.Point(232, 404)
        Me.TotalUTHR_LBL.Name = "TotalUTHR_LBL"
        Me.TotalUTHR_LBL.Size = New System.Drawing.Size(21, 27)
        Me.TotalUTHR_LBL.TabIndex = 74
        Me.TotalUTHR_LBL.Text = "0"
        '
        'TotalLateHR_LBL
        '
        Me.TotalLateHR_LBL.AutoSize = True
        Me.TotalLateHR_LBL.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalLateHR_LBL.Location = New System.Drawing.Point(232, 363)
        Me.TotalLateHR_LBL.Name = "TotalLateHR_LBL"
        Me.TotalLateHR_LBL.Size = New System.Drawing.Size(21, 27)
        Me.TotalLateHR_LBL.TabIndex = 73
        Me.TotalLateHR_LBL.Text = "0"
        '
        'TotalAbsent_LBL
        '
        Me.TotalAbsent_LBL.AutoSize = True
        Me.TotalAbsent_LBL.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalAbsent_LBL.Location = New System.Drawing.Point(232, 441)
        Me.TotalAbsent_LBL.Name = "TotalAbsent_LBL"
        Me.TotalAbsent_LBL.Size = New System.Drawing.Size(21, 27)
        Me.TotalAbsent_LBL.TabIndex = 72
        Me.TotalAbsent_LBL.Text = "0"
        Me.TotalAbsent_LBL.Visible = False
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
        Me.Label12.Location = New System.Drawing.Point(17, 443)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(119, 25)
        Me.Label12.TabIndex = 70
        Me.Label12.Text = "Total Absent       "
        Me.Label12.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(17, 406)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(129, 25)
        Me.Label11.TabIndex = 69
        Me.Label11.Text = "Total Under Time  "
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(19, 363)
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
        Me.GroupBox1.Controls.Add(Me.SearchEMP_BTN)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Name_TXT)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.BiometricID_TXT)
        Me.GroupBox1.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(6, 25)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(411, 125)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Employee"
        '
        'SearchEMP_BTN
        '
        Me.SearchEMP_BTN.Location = New System.Drawing.Point(358, 75)
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
        Me.Label3.Location = New System.Drawing.Point(16, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 25)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Name"
        '
        'Name_TXT
        '
        Me.Name_TXT.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name_TXT.Location = New System.Drawing.Point(110, 74)
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
        Me.RptViewer_DTR.LocalReport.ReportEmbeddedResource = "WindowsApp1.rptDTR_All.rdlc"
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
        'Context_Records
        '
        Me.Context_Records.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_Remove})
        Me.Context_Records.Name = "Context_Records"
        Me.Context_Records.Size = New System.Drawing.Size(180, 26)
        '
        'Menu_Remove
        '
        Me.Menu_Remove.Name = "Menu_Remove"
        Me.Menu_Remove.Size = New System.Drawing.Size(179, 22)
        Me.Menu_Remove.Text = "Remove this branch"
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
        'Branch_DTR_TXT
        '
        Me.Branch_DTR_TXT.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Branch_DTR_TXT.Location = New System.Drawing.Point(10, 67)
        Me.Branch_DTR_TXT.Name = "Branch_DTR_TXT"
        Me.Branch_DTR_TXT.Size = New System.Drawing.Size(319, 33)
        Me.Branch_DTR_TXT.TabIndex = 92
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
        Me.Text = "frmAttendance"
        CType(Me.overAllBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtr_all, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Attendance_Tab.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.Bio_grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Manual_Tab.ResumeLayout(False)
        Me.Manual_Tab.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
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
        Me.Context_Records.ResumeLayout(False)
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
    Friend WithEvents TotalAbsent_LBL As Label
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
    Friend WithEvents Label19 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents Bio_grid As DataGridView
    Friend WithEvents Import_BTN As Button
    Friend WithEvents Path_TXT As TextBox
    Friend WithEvents OpenFile_BTN As Button
    Friend WithEvents Paydate_ComboB As ComboBox
    Friend WithEvents UT_BTN As Button
    Friend WithEvents Late_BTN As Button
    Friend WithEvents OT_BTN As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents BIOID_DGVV As DataGridViewTextBoxColumn
    Friend WithEvents Name_DGVV As DataGridViewTextBoxColumn
    Friend WithEvents PRESENT_DGVV As DataGridViewTextBoxColumn
    Friend WithEvents Overtime_DGVV As DataGridViewTextBoxColumn
    Friend WithEvents Late_DGVV As DataGridViewTextBoxColumn
    Friend WithEvents Undertime_DGVV As DataGridViewTextBoxColumn
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
    Friend WithEvents Context_Records As ContextMenuStrip
    Friend WithEvents Menu_Remove As ToolStripMenuItem
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
End Class
