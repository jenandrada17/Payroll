<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSchedule
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Close_LBL = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Import_BTN = New System.Windows.Forms.Button()
        Me.Path_TXT = New System.Windows.Forms.TextBox()
        Me.Browse_BTN = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Paydate_ComboB = New System.Windows.Forms.ComboBox()
        Me.lvEmployee = New System.Windows.Forms.ListView()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Cancel_BTN = New System.Windows.Forms.Button()
        Me.Save_BTN = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.SearchEMP_BTN = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Name_TXT = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BiometricID_TXT = New System.Windows.Forms.TextBox()
        Me.Schedule_DG = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Attach_Panel = New System.Windows.Forms.Panel()
        Me.Label75 = New System.Windows.Forms.Label()
        Me.AttachClose_lbl = New System.Windows.Forms.Label()
        Me.AttachPath_txt = New System.Windows.Forms.TextBox()
        Me.AttachBrowse_btn = New System.Windows.Forms.Button()
        Me.AttachSave_btn = New System.Windows.Forms.Button()
        Me.Date_DataGrid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Time_In_DataGrid = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Time_Out_DataGrid = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Attach_btn = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Schedule_DG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Attach_Panel.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Dubai", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, -3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(199, 36)
        Me.Label1.TabIndex = 73
        Me.Label1.Text = "Employee's Schedule"
        '
        'Close_LBL
        '
        Me.Close_LBL.AutoSize = True
        Me.Close_LBL.Font = New System.Drawing.Font("Dubai", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Close_LBL.Location = New System.Drawing.Point(1115, -3)
        Me.Close_LBL.Name = "Close_LBL"
        Me.Close_LBL.Size = New System.Drawing.Size(57, 32)
        Me.Close_LBL.TabIndex = 82
        Me.Close_LBL.Text = "Close"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Font = New System.Drawing.Font("Dubai", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(5, 47)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1160, 605)
        Me.TabControl1.TabIndex = 83
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Import_BTN)
        Me.TabPage1.Controls.Add(Me.Path_TXT)
        Me.TabPage1.Controls.Add(Me.Browse_BTN)
        Me.TabPage1.Controls.Add(Me.Label20)
        Me.TabPage1.Controls.Add(Me.Paydate_ComboB)
        Me.TabPage1.Controls.Add(Me.lvEmployee)
        Me.TabPage1.Controls.Add(Me.btnSearch)
        Me.TabPage1.Controls.Add(Me.txtSearch)
        Me.TabPage1.Location = New System.Drawing.Point(4, 38)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1152, 563)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "     List of Employees Record     "
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Import_BTN
        '
        Me.Import_BTN.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Import_BTN.Enabled = False
        Me.Import_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Import_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Import_BTN.Location = New System.Drawing.Point(844, 28)
        Me.Import_BTN.Name = "Import_BTN"
        Me.Import_BTN.Size = New System.Drawing.Size(108, 31)
        Me.Import_BTN.TabIndex = 91
        Me.Import_BTN.Text = "Import"
        Me.Import_BTN.UseVisualStyleBackColor = False
        '
        'Path_TXT
        '
        Me.Path_TXT.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Path_TXT.Location = New System.Drawing.Point(12, 30)
        Me.Path_TXT.Name = "Path_TXT"
        Me.Path_TXT.ReadOnly = True
        Me.Path_TXT.Size = New System.Drawing.Size(683, 29)
        Me.Path_TXT.TabIndex = 90
        '
        'Browse_BTN
        '
        Me.Browse_BTN.BackColor = System.Drawing.Color.Gainsboro
        Me.Browse_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Browse_BTN.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Browse_BTN.Location = New System.Drawing.Point(712, 28)
        Me.Browse_BTN.Name = "Browse_BTN"
        Me.Browse_BTN.Size = New System.Drawing.Size(112, 31)
        Me.Browse_BTN.TabIndex = 89
        Me.Browse_BTN.Text = "Browse"
        Me.Browse_BTN.UseVisualStyleBackColor = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(13, 107)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(98, 25)
        Me.Label20.TabIndex = 88
        Me.Label20.Text = "Search Payroll"
        '
        'Paydate_ComboB
        '
        Me.Paydate_ComboB.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Paydate_ComboB.FormattingEnabled = True
        Me.Paydate_ComboB.Location = New System.Drawing.Point(118, 103)
        Me.Paydate_ComboB.Name = "Paydate_ComboB"
        Me.Paydate_ComboB.Size = New System.Drawing.Size(153, 33)
        Me.Paydate_ComboB.TabIndex = 87
        '
        'lvEmployee
        '
        Me.lvEmployee.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvEmployee.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3, Me.ColumnHeader2, Me.ColumnHeader1})
        Me.lvEmployee.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvEmployee.FullRowSelect = True
        Me.lvEmployee.GridLines = True
        Me.lvEmployee.HideSelection = False
        Me.lvEmployee.Location = New System.Drawing.Point(12, 142)
        Me.lvEmployee.MultiSelect = False
        Me.lvEmployee.Name = "lvEmployee"
        Me.lvEmployee.Size = New System.Drawing.Size(1134, 412)
        Me.lvEmployee.TabIndex = 84
        Me.lvEmployee.UseCompatibleStateImageBehavior = False
        Me.lvEmployee.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Biometric No."
        Me.ColumnHeader3.Width = 200
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Fullname"
        Me.ColumnHeader2.Width = 650
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Payroll Date"
        Me.ColumnHeader1.Width = 250
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(1039, 103)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(107, 34)
        Me.btnSearch.TabIndex = 83
        Me.btnSearch.Text = "&Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(646, 105)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(387, 31)
        Me.txtSearch.TabIndex = 82
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Attach_Panel)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.Panel3)
        Me.TabPage2.Controls.Add(Me.Panel2)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.Panel1)
        Me.TabPage2.Controls.Add(Me.Cancel_BTN)
        Me.TabPage2.Controls.Add(Me.Save_BTN)
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Controls.Add(Me.Schedule_DG)
        Me.TabPage2.Location = New System.Drawing.Point(4, 38)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1152, 563)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "     Schedule Details     "
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Cancel_BTN
        '
        Me.Cancel_BTN.BackColor = System.Drawing.Color.PeachPuff
        Me.Cancel_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cancel_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel_BTN.Location = New System.Drawing.Point(44, 202)
        Me.Cancel_BTN.Name = "Cancel_BTN"
        Me.Cancel_BTN.Size = New System.Drawing.Size(130, 37)
        Me.Cancel_BTN.TabIndex = 90
        Me.Cancel_BTN.Text = "Cancel"
        Me.Cancel_BTN.UseVisualStyleBackColor = False
        '
        'Save_BTN
        '
        Me.Save_BTN.BackColor = System.Drawing.Color.DarkSalmon
        Me.Save_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Save_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Save_BTN.Location = New System.Drawing.Point(301, 202)
        Me.Save_BTN.Name = "Save_BTN"
        Me.Save_BTN.Size = New System.Drawing.Size(115, 37)
        Me.Save_BTN.TabIndex = 89
        Me.Save_BTN.Text = "Save"
        Me.Save_BTN.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.SearchEMP_BTN)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Name_TXT)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.BiometricID_TXT)
        Me.GroupBox1.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 30)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(411, 120)
        Me.GroupBox1.TabIndex = 88
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Employee Details"
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
        'Schedule_DG
        '
        Me.Schedule_DG.AllowUserToAddRows = False
        Me.Schedule_DG.AllowUserToResizeColumns = False
        Me.Schedule_DG.AllowUserToResizeRows = False
        Me.Schedule_DG.BackgroundColor = System.Drawing.Color.White
        Me.Schedule_DG.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Schedule_DG.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Schedule_DG.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Schedule_DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Schedule_DG.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Date_DataGrid, Me.Time_In_DataGrid, Me.Time_Out_DataGrid, Me.Attach_btn})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.InactiveCaption
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Schedule_DG.DefaultCellStyle = DataGridViewCellStyle5
        Me.Schedule_DG.Location = New System.Drawing.Point(554, 8)
        Me.Schedule_DG.Name = "Schedule_DG"
        Me.Schedule_DG.RowHeadersVisible = False
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Transparent
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Transparent
        Me.Schedule_DG.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.Schedule_DG.Size = New System.Drawing.Size(592, 471)
        Me.Schedule_DG.TabIndex = 87
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.RosyBrown
        Me.Panel1.Location = New System.Drawing.Point(553, 514)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(40, 25)
        Me.Panel1.TabIndex = 91
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(599, 514)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(161, 27)
        Me.Label4.TabIndex = 92
        Me.Label4.Text = "Service Incentive Leave"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(859, 514)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(98, 27)
        Me.Label5.TabIndex = 94
        Me.Label5.Text = "Absent Leave"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.CadetBlue
        Me.Panel2.Location = New System.Drawing.Point(813, 514)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(40, 25)
        Me.Panel2.TabIndex = 93
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(1075, 512)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 27)
        Me.Label6.TabIndex = 94
        Me.Label6.Text = "Rest Day"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.SlateGray
        Me.Panel3.Location = New System.Drawing.Point(1029, 514)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(40, 25)
        Me.Panel3.TabIndex = 93
        '
        'Attach_Panel
        '
        Me.Attach_Panel.AutoSize = True
        Me.Attach_Panel.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Attach_Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Attach_Panel.Controls.Add(Me.Label75)
        Me.Attach_Panel.Controls.Add(Me.AttachClose_lbl)
        Me.Attach_Panel.Controls.Add(Me.AttachPath_txt)
        Me.Attach_Panel.Controls.Add(Me.AttachBrowse_btn)
        Me.Attach_Panel.Controls.Add(Me.AttachSave_btn)
        Me.Attach_Panel.Location = New System.Drawing.Point(12, 389)
        Me.Attach_Panel.Name = "Attach_Panel"
        Me.Attach_Panel.Size = New System.Drawing.Size(634, 90)
        Me.Attach_Panel.TabIndex = 95
        Me.Attach_Panel.Visible = False
        '
        'Label75
        '
        Me.Label75.AutoSize = True
        Me.Label75.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label75.ForeColor = System.Drawing.Color.White
        Me.Label75.Location = New System.Drawing.Point(5, 13)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(103, 16)
        Me.Label75.TabIndex = 83
        Me.Label75.Text = "Browse PDF file"
        '
        'AttachClose_lbl
        '
        Me.AttachClose_lbl.AutoSize = True
        Me.AttachClose_lbl.ForeColor = System.Drawing.Color.White
        Me.AttachClose_lbl.Location = New System.Drawing.Point(606, -1)
        Me.AttachClose_lbl.Name = "AttachClose_lbl"
        Me.AttachClose_lbl.Size = New System.Drawing.Size(23, 29)
        Me.AttachClose_lbl.TabIndex = 82
        Me.AttachClose_lbl.Text = "X"
        '
        'AttachPath_txt
        '
        Me.AttachPath_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AttachPath_txt.Location = New System.Drawing.Point(8, 32)
        Me.AttachPath_txt.Name = "AttachPath_txt"
        Me.AttachPath_txt.Size = New System.Drawing.Size(412, 26)
        Me.AttachPath_txt.TabIndex = 81
        '
        'AttachBrowse_btn
        '
        Me.AttachBrowse_btn.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AttachBrowse_btn.Location = New System.Drawing.Point(447, 31)
        Me.AttachBrowse_btn.Name = "AttachBrowse_btn"
        Me.AttachBrowse_btn.Size = New System.Drawing.Size(76, 31)
        Me.AttachBrowse_btn.TabIndex = 80
        Me.AttachBrowse_btn.Text = "Browse"
        Me.AttachBrowse_btn.UseVisualStyleBackColor = True
        '
        'AttachSave_btn
        '
        Me.AttachSave_btn.Enabled = False
        Me.AttachSave_btn.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AttachSave_btn.Location = New System.Drawing.Point(529, 31)
        Me.AttachSave_btn.Name = "AttachSave_btn"
        Me.AttachSave_btn.Size = New System.Drawing.Size(80, 31)
        Me.AttachSave_btn.TabIndex = 79
        Me.AttachSave_btn.Text = "Save"
        Me.AttachSave_btn.UseVisualStyleBackColor = True
        '
        'Date_DataGrid
        '
        DataGridViewCellStyle2.NullValue = Nothing
        Me.Date_DataGrid.DefaultCellStyle = DataGridViewCellStyle2
        Me.Date_DataGrid.HeaderText = "Date"
        Me.Date_DataGrid.Name = "Date_DataGrid"
        Me.Date_DataGrid.ReadOnly = True
        Me.Date_DataGrid.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Date_DataGrid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Date_DataGrid.Width = 250
        '
        'Time_In_DataGrid
        '
        DataGridViewCellStyle3.Format = "t"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.Time_In_DataGrid.DefaultCellStyle = DataGridViewCellStyle3
        Me.Time_In_DataGrid.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.Time_In_DataGrid.HeaderText = "  Time in  "
        Me.Time_In_DataGrid.Name = "Time_In_DataGrid"
        Me.Time_In_DataGrid.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Time_In_DataGrid.Width = 120
        '
        'Time_Out_DataGrid
        '
        Me.Time_Out_DataGrid.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.Time_Out_DataGrid.HeaderText = "  Time Out  "
        Me.Time_Out_DataGrid.Name = "Time_Out_DataGrid"
        Me.Time_Out_DataGrid.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Time_Out_DataGrid.Width = 120
        '
        'Attach_btn
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Attach_btn.DefaultCellStyle = DataGridViewCellStyle4
        Me.Attach_btn.HeaderText = "  Attach"
        Me.Attach_btn.Name = "Attach_btn"
        '
        'frmSchedule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1169, 665)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Close_LBL)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmSchedule"
        Me.Text = "frmSchedule"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.Schedule_DG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Attach_Panel.ResumeLayout(False)
        Me.Attach_Panel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Close_LBL As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents Label20 As Label
    Friend WithEvents Paydate_ComboB As ComboBox
    Friend WithEvents lvEmployee As ListView
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents btnSearch As Button
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Schedule_DG As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents SearchEMP_BTN As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Name_TXT As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents BiometricID_TXT As TextBox
    Friend WithEvents Cancel_BTN As Button
    Friend WithEvents Save_BTN As Button
    Friend WithEvents Import_BTN As Button
    Friend WithEvents Path_TXT As TextBox
    Friend WithEvents Browse_BTN As Button
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Attach_Panel As Panel
    Friend WithEvents Label75 As Label
    Friend WithEvents AttachClose_lbl As Label
    Friend WithEvents AttachPath_txt As TextBox
    Friend WithEvents AttachBrowse_btn As Button
    Friend WithEvents AttachSave_btn As Button
    Friend WithEvents Date_DataGrid As DataGridViewTextBoxColumn
    Friend WithEvents Time_In_DataGrid As DataGridViewComboBoxColumn
    Friend WithEvents Time_Out_DataGrid As DataGridViewComboBoxColumn
    Friend WithEvents Attach_btn As DataGridViewButtonColumn
End Class
