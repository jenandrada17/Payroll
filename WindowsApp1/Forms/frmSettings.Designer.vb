<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSettings
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Close_LBL = New System.Windows.Forms.Label()
        Me.Settings_Tab = New System.Windows.Forms.TabControl()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.Rate_grid = New System.Windows.Forms.DataGridView()
        Me.Rate_Branch_DGV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Rate_Name_DGV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Rate_Pos_DGV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Rate_Rate_DGV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Rate_Search_TXT = New System.Windows.Forms.TextBox()
        Me.Rate_Search_BTN = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Rate_EmpClear_BTN = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Rate_BioNo_TXT = New System.Windows.Forms.TextBox()
        Me.Rate_Employee_TXT = New System.Windows.Forms.TextBox()
        Me.Rate_EmpSelect_BTN = New System.Windows.Forms.Button()
        Me.Rate_EmpSave_BTN = New System.Windows.Forms.Button()
        Me.Rate_EmpAmount_TXT = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Rate_Position_BTN = New System.Windows.Forms.Button()
        Me.Rate_Pos_ComboB = New System.Windows.Forms.ComboBox()
        Me.Rate_PosAmount_TXT = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Rate_Branch_BTN = New System.Windows.Forms.Button()
        Me.Rate_Branch_ComboB = New System.Windows.Forms.ComboBox()
        Me.Rate_BranchAmount_TXT = New System.Windows.Forms.TextBox()
        Me.Holiday_Tab = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SpecialRate_TXT = New System.Windows.Forms.TextBox()
        Me.RegularRate_TXT = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.HolidayRate_BTN = New System.Windows.Forms.Button()
        Me.lvHoliday = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Date_DTP = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Special_RB = New System.Windows.Forms.RadioButton()
        Me.Save_BTN = New System.Windows.Forms.Button()
        Me.Regular_RB = New System.Windows.Forms.RadioButton()
        Me.Name_TXT = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Allow_Cancel_BTN = New System.Windows.Forms.Button()
        Me.Allow_Search_TXT = New System.Windows.Forms.TextBox()
        Me.Allow_Search_BTN = New System.Windows.Forms.Button()
        Me.Allowance_LV = New System.Windows.Forms.ListView()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Allow_Fix_group = New System.Windows.Forms.GroupBox()
        Me.FixYes_RadioB = New System.Windows.Forms.RadioButton()
        Me.FixNo_RadioB = New System.Windows.Forms.RadioButton()
        Me.Allow_SearchEmp_BTN = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Allow_Name_TXT = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Allow_Save_BTN = New System.Windows.Forms.Button()
        Me.Allow_Category_Combo = New System.Windows.Forms.ComboBox()
        Me.Allow_Amount_TXT = New System.Windows.Forms.TextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Holiday_Remove = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RemoveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileSystemWatcher1 = New System.IO.FileSystemWatcher()
        Me.Allowance_Remove = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Allow_Remove = New System.Windows.Forms.ToolStripMenuItem()
        Me.Settings_Tab.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        CType(Me.Rate_grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.Holiday_Tab.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Allow_Fix_group.SuspendLayout()
        Me.Holiday_Remove.SuspendLayout()
        CType(Me.FileSystemWatcher1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Allowance_Remove.SuspendLayout()
        Me.SuspendLayout()
        '
        'Close_LBL
        '
        Me.Close_LBL.AutoSize = True
        Me.Close_LBL.Font = New System.Drawing.Font("Dubai", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Close_LBL.Location = New System.Drawing.Point(1117, -7)
        Me.Close_LBL.Name = "Close_LBL"
        Me.Close_LBL.Size = New System.Drawing.Size(57, 32)
        Me.Close_LBL.TabIndex = 77
        Me.Close_LBL.Text = "Close"
        '
        'Settings_Tab
        '
        Me.Settings_Tab.Controls.Add(Me.TabPage5)
        Me.Settings_Tab.Controls.Add(Me.Holiday_Tab)
        Me.Settings_Tab.Controls.Add(Me.TabPage1)
        Me.Settings_Tab.Controls.Add(Me.TabPage2)
        Me.Settings_Tab.Controls.Add(Me.TabPage3)
        Me.Settings_Tab.Controls.Add(Me.TabPage4)
        Me.Settings_Tab.Font = New System.Drawing.Font("Dubai", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Settings_Tab.Location = New System.Drawing.Point(10, 33)
        Me.Settings_Tab.Name = "Settings_Tab"
        Me.Settings_Tab.SelectedIndex = 0
        Me.Settings_Tab.Size = New System.Drawing.Size(1155, 646)
        Me.Settings_Tab.TabIndex = 76
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.Rate_grid)
        Me.TabPage5.Controls.Add(Me.Rate_Search_TXT)
        Me.TabPage5.Controls.Add(Me.Rate_Search_BTN)
        Me.TabPage5.Controls.Add(Me.GroupBox5)
        Me.TabPage5.Controls.Add(Me.GroupBox4)
        Me.TabPage5.Controls.Add(Me.GroupBox3)
        Me.TabPage5.Location = New System.Drawing.Point(4, 38)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(1147, 604)
        Me.TabPage5.TabIndex = 5
        Me.TabPage5.Text = "  Rate  "
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'Rate_grid
        '
        Me.Rate_grid.AllowUserToAddRows = False
        Me.Rate_grid.AllowUserToResizeRows = False
        Me.Rate_grid.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.Rate_grid.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Rate_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Rate_grid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Rate_Branch_DGV, Me.Rate_Name_DGV, Me.Rate_Pos_DGV, Me.Rate_Rate_DGV})
        Me.Rate_grid.GridColor = System.Drawing.Color.White
        Me.Rate_grid.Location = New System.Drawing.Point(526, 74)
        Me.Rate_grid.Name = "Rate_grid"
        Me.Rate_grid.RowHeadersVisible = False
        Me.Rate_grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.Rate_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Rate_grid.Size = New System.Drawing.Size(618, 523)
        Me.Rate_grid.TabIndex = 98
        '
        'Rate_Branch_DGV
        '
        Me.Rate_Branch_DGV.HeaderText = "Branch"
        Me.Rate_Branch_DGV.Name = "Rate_Branch_DGV"
        Me.Rate_Branch_DGV.ReadOnly = True
        Me.Rate_Branch_DGV.Width = 140
        '
        'Rate_Name_DGV
        '
        Me.Rate_Name_DGV.HeaderText = "Name"
        Me.Rate_Name_DGV.Name = "Rate_Name_DGV"
        Me.Rate_Name_DGV.ReadOnly = True
        Me.Rate_Name_DGV.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Rate_Name_DGV.Width = 250
        '
        'Rate_Pos_DGV
        '
        Me.Rate_Pos_DGV.HeaderText = "Position"
        Me.Rate_Pos_DGV.Name = "Rate_Pos_DGV"
        Me.Rate_Pos_DGV.ReadOnly = True
        Me.Rate_Pos_DGV.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Rate_Pos_DGV.Width = 130
        '
        'Rate_Rate_DGV
        '
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rate_Rate_DGV.DefaultCellStyle = DataGridViewCellStyle5
        Me.Rate_Rate_DGV.HeaderText = "Rate"
        Me.Rate_Rate_DGV.Name = "Rate_Rate_DGV"
        Me.Rate_Rate_DGV.ReadOnly = True
        Me.Rate_Rate_DGV.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Rate_Rate_DGV.Width = 80
        '
        'Rate_Search_TXT
        '
        Me.Rate_Search_TXT.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rate_Search_TXT.Location = New System.Drawing.Point(526, 25)
        Me.Rate_Search_TXT.Name = "Rate_Search_TXT"
        Me.Rate_Search_TXT.Size = New System.Drawing.Size(315, 33)
        Me.Rate_Search_TXT.TabIndex = 96
        '
        'Rate_Search_BTN
        '
        Me.Rate_Search_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rate_Search_BTN.Location = New System.Drawing.Point(847, 24)
        Me.Rate_Search_BTN.Name = "Rate_Search_BTN"
        Me.Rate_Search_BTN.Size = New System.Drawing.Size(82, 33)
        Me.Rate_Search_BTN.TabIndex = 97
        Me.Rate_Search_BTN.Text = "Search"
        Me.Rate_Search_BTN.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Rate_EmpClear_BTN)
        Me.GroupBox5.Controls.Add(Me.Label10)
        Me.GroupBox5.Controls.Add(Me.Label9)
        Me.GroupBox5.Controls.Add(Me.Label8)
        Me.GroupBox5.Controls.Add(Me.Rate_BioNo_TXT)
        Me.GroupBox5.Controls.Add(Me.Rate_Employee_TXT)
        Me.GroupBox5.Controls.Add(Me.Rate_EmpSelect_BTN)
        Me.GroupBox5.Controls.Add(Me.Rate_EmpSave_BTN)
        Me.GroupBox5.Controls.Add(Me.Rate_EmpAmount_TXT)
        Me.GroupBox5.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(13, 366)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(486, 184)
        Me.GroupBox5.TabIndex = 87
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Per Employee"
        '
        'Rate_EmpClear_BTN
        '
        Me.Rate_EmpClear_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rate_EmpClear_BTN.Location = New System.Drawing.Point(418, 80)
        Me.Rate_EmpClear_BTN.Name = "Rate_EmpClear_BTN"
        Me.Rate_EmpClear_BTN.Size = New System.Drawing.Size(57, 36)
        Me.Rate_EmpClear_BTN.TabIndex = 95
        Me.Rate_EmpClear_BTN.Text = "Clear"
        Me.Rate_EmpClear_BTN.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(16, 142)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(35, 22)
        Me.Label10.TabIndex = 94
        Me.Label10.Text = "Rate"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(15, 88)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 22)
        Me.Label9.TabIndex = 93
        Me.Label9.Text = "Name"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(15, 42)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(62, 22)
        Me.Label8.TabIndex = 92
        Me.Label8.Text = "Biometric"
        '
        'Rate_BioNo_TXT
        '
        Me.Rate_BioNo_TXT.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rate_BioNo_TXT.Location = New System.Drawing.Point(84, 38)
        Me.Rate_BioNo_TXT.Name = "Rate_BioNo_TXT"
        Me.Rate_BioNo_TXT.Size = New System.Drawing.Size(319, 33)
        Me.Rate_BioNo_TXT.TabIndex = 91
        '
        'Rate_Employee_TXT
        '
        Me.Rate_Employee_TXT.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rate_Employee_TXT.Location = New System.Drawing.Point(84, 85)
        Me.Rate_Employee_TXT.Name = "Rate_Employee_TXT"
        Me.Rate_Employee_TXT.ReadOnly = True
        Me.Rate_Employee_TXT.Size = New System.Drawing.Size(319, 33)
        Me.Rate_Employee_TXT.TabIndex = 90
        '
        'Rate_EmpSelect_BTN
        '
        Me.Rate_EmpSelect_BTN.AutoSize = True
        Me.Rate_EmpSelect_BTN.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rate_EmpSelect_BTN.Location = New System.Drawing.Point(418, 38)
        Me.Rate_EmpSelect_BTN.Name = "Rate_EmpSelect_BTN"
        Me.Rate_EmpSelect_BTN.Size = New System.Drawing.Size(57, 30)
        Me.Rate_EmpSelect_BTN.TabIndex = 89
        Me.Rate_EmpSelect_BTN.Text = "..."
        Me.Rate_EmpSelect_BTN.UseVisualStyleBackColor = True
        '
        'Rate_EmpSave_BTN
        '
        Me.Rate_EmpSave_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rate_EmpSave_BTN.Location = New System.Drawing.Point(418, 128)
        Me.Rate_EmpSave_BTN.Name = "Rate_EmpSave_BTN"
        Me.Rate_EmpSave_BTN.Size = New System.Drawing.Size(57, 36)
        Me.Rate_EmpSave_BTN.TabIndex = 85
        Me.Rate_EmpSave_BTN.Text = "Save"
        Me.Rate_EmpSave_BTN.UseVisualStyleBackColor = True
        '
        'Rate_EmpAmount_TXT
        '
        Me.Rate_EmpAmount_TXT.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rate_EmpAmount_TXT.Location = New System.Drawing.Point(84, 131)
        Me.Rate_EmpAmount_TXT.Name = "Rate_EmpAmount_TXT"
        Me.Rate_EmpAmount_TXT.Size = New System.Drawing.Size(319, 33)
        Me.Rate_EmpAmount_TXT.TabIndex = 9
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Controls.Add(Me.Rate_Position_BTN)
        Me.GroupBox4.Controls.Add(Me.Rate_Pos_ComboB)
        Me.GroupBox4.Controls.Add(Me.Rate_PosAmount_TXT)
        Me.GroupBox4.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(13, 181)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(486, 98)
        Me.GroupBox4.TabIndex = 86
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Per Position"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(247, 19)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(35, 22)
        Me.Label12.TabIndex = 96
        Me.Label12.Text = "Rate"
        '
        'Rate_Position_BTN
        '
        Me.Rate_Position_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rate_Position_BTN.Location = New System.Drawing.Point(418, 43)
        Me.Rate_Position_BTN.Name = "Rate_Position_BTN"
        Me.Rate_Position_BTN.Size = New System.Drawing.Size(57, 33)
        Me.Rate_Position_BTN.TabIndex = 85
        Me.Rate_Position_BTN.Text = "Save"
        Me.Rate_Position_BTN.UseVisualStyleBackColor = True
        '
        'Rate_Pos_ComboB
        '
        Me.Rate_Pos_ComboB.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rate_Pos_ComboB.FormattingEnabled = True
        Me.Rate_Pos_ComboB.Location = New System.Drawing.Point(11, 44)
        Me.Rate_Pos_ComboB.Name = "Rate_Pos_ComboB"
        Me.Rate_Pos_ComboB.Size = New System.Drawing.Size(211, 33)
        Me.Rate_Pos_ComboB.TabIndex = 8
        Me.Rate_Pos_ComboB.Text = "   Select Position"
        '
        'Rate_PosAmount_TXT
        '
        Me.Rate_PosAmount_TXT.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rate_PosAmount_TXT.Location = New System.Drawing.Point(251, 44)
        Me.Rate_PosAmount_TXT.Name = "Rate_PosAmount_TXT"
        Me.Rate_PosAmount_TXT.Size = New System.Drawing.Size(146, 33)
        Me.Rate_PosAmount_TXT.TabIndex = 9
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.Rate_Branch_BTN)
        Me.GroupBox3.Controls.Add(Me.Rate_Branch_ComboB)
        Me.GroupBox3.Controls.Add(Me.Rate_BranchAmount_TXT)
        Me.GroupBox3.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(13, 31)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(486, 97)
        Me.GroupBox3.TabIndex = 10
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Per Branch"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(247, 18)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(35, 22)
        Me.Label11.TabIndex = 95
        Me.Label11.Text = "Rate"
        '
        'Rate_Branch_BTN
        '
        Me.Rate_Branch_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rate_Branch_BTN.Location = New System.Drawing.Point(418, 41)
        Me.Rate_Branch_BTN.Name = "Rate_Branch_BTN"
        Me.Rate_Branch_BTN.Size = New System.Drawing.Size(57, 34)
        Me.Rate_Branch_BTN.TabIndex = 85
        Me.Rate_Branch_BTN.Text = "Save"
        Me.Rate_Branch_BTN.UseVisualStyleBackColor = True
        '
        'Rate_Branch_ComboB
        '
        Me.Rate_Branch_ComboB.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rate_Branch_ComboB.FormattingEnabled = True
        Me.Rate_Branch_ComboB.Location = New System.Drawing.Point(11, 42)
        Me.Rate_Branch_ComboB.Name = "Rate_Branch_ComboB"
        Me.Rate_Branch_ComboB.Size = New System.Drawing.Size(205, 33)
        Me.Rate_Branch_ComboB.TabIndex = 8
        Me.Rate_Branch_ComboB.Text = "   Select Branch"
        '
        'Rate_BranchAmount_TXT
        '
        Me.Rate_BranchAmount_TXT.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rate_BranchAmount_TXT.Location = New System.Drawing.Point(251, 43)
        Me.Rate_BranchAmount_TXT.Name = "Rate_BranchAmount_TXT"
        Me.Rate_BranchAmount_TXT.Size = New System.Drawing.Size(146, 33)
        Me.Rate_BranchAmount_TXT.TabIndex = 9
        '
        'Holiday_Tab
        '
        Me.Holiday_Tab.Controls.Add(Me.GroupBox2)
        Me.Holiday_Tab.Controls.Add(Me.lvHoliday)
        Me.Holiday_Tab.Controls.Add(Me.GroupBox1)
        Me.Holiday_Tab.Location = New System.Drawing.Point(4, 38)
        Me.Holiday_Tab.Name = "Holiday_Tab"
        Me.Holiday_Tab.Padding = New System.Windows.Forms.Padding(3)
        Me.Holiday_Tab.Size = New System.Drawing.Size(1147, 604)
        Me.Holiday_Tab.TabIndex = 0
        Me.Holiday_Tab.Text = "  Holiday  "
        Me.Holiday_Tab.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.SpecialRate_TXT)
        Me.GroupBox2.Controls.Add(Me.RegularRate_TXT)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.HolidayRate_BTN)
        Me.GroupBox2.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(6, 431)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(443, 132)
        Me.GroupBox2.TabIndex = 86
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Holiday Rate"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(262, 88)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(22, 22)
        Me.Label7.TabIndex = 90
        Me.Label7.Text = "%"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(262, 39)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(22, 22)
        Me.Label5.TabIndex = 89
        Me.Label5.Text = "%"
        '
        'SpecialRate_TXT
        '
        Me.SpecialRate_TXT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.SpecialRate_TXT.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SpecialRate_TXT.Location = New System.Drawing.Point(135, 88)
        Me.SpecialRate_TXT.Name = "SpecialRate_TXT"
        Me.SpecialRate_TXT.ReadOnly = True
        Me.SpecialRate_TXT.Size = New System.Drawing.Size(125, 29)
        Me.SpecialRate_TXT.TabIndex = 88
        '
        'RegularRate_TXT
        '
        Me.RegularRate_TXT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.RegularRate_TXT.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RegularRate_TXT.Location = New System.Drawing.Point(135, 38)
        Me.RegularRate_TXT.Name = "RegularRate_TXT"
        Me.RegularRate_TXT.ReadOnly = True
        Me.RegularRate_TXT.Size = New System.Drawing.Size(125, 29)
        Me.RegularRate_TXT.TabIndex = 85
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(49, 88)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 25)
        Me.Label6.TabIndex = 87
        Me.Label6.Text = "Special"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(49, 39)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 25)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Regular"
        '
        'HolidayRate_BTN
        '
        Me.HolidayRate_BTN.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HolidayRate_BTN.Location = New System.Drawing.Point(334, 63)
        Me.HolidayRate_BTN.Name = "HolidayRate_BTN"
        Me.HolidayRate_BTN.Size = New System.Drawing.Size(72, 31)
        Me.HolidayRate_BTN.TabIndex = 85
        Me.HolidayRate_BTN.Text = "Change"
        Me.HolidayRate_BTN.UseVisualStyleBackColor = True
        '
        'lvHoliday
        '
        Me.lvHoliday.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvHoliday.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lvHoliday.Font = New System.Drawing.Font("Dubai", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvHoliday.FullRowSelect = True
        Me.lvHoliday.GridLines = True
        Me.lvHoliday.HideSelection = False
        Me.lvHoliday.Location = New System.Drawing.Point(470, 18)
        Me.lvHoliday.MultiSelect = False
        Me.lvHoliday.Name = "lvHoliday"
        Me.lvHoliday.Size = New System.Drawing.Size(659, 565)
        Me.lvHoliday.TabIndex = 70
        Me.lvHoliday.UseCompatibleStateImageBehavior = False
        Me.lvHoliday.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Date"
        Me.ColumnHeader1.Width = 250
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Holiday Name"
        Me.ColumnHeader2.Width = 395
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Date_DTP)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Special_RB)
        Me.GroupBox1.Controls.Add(Me.Save_BTN)
        Me.GroupBox1.Controls.Add(Me.Regular_RB)
        Me.GroupBox1.Controls.Add(Me.Name_TXT)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(6, 36)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(458, 231)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Information"
        '
        'Date_DTP
        '
        Me.Date_DTP.CalendarFont = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Date_DTP.CustomFormat = ""
        Me.Date_DTP.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Date_DTP.Location = New System.Drawing.Point(88, 68)
        Me.Date_DTP.Name = "Date_DTP"
        Me.Date_DTP.Size = New System.Drawing.Size(317, 33)
        Me.Date_DTP.TabIndex = 4
        Me.Date_DTP.Value = New Date(2021, 6, 2, 0, 0, 0, 0)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(15, 120)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 25)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Name"
        '
        'Special_RB
        '
        Me.Special_RB.AutoSize = True
        Me.Special_RB.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Special_RB.Location = New System.Drawing.Point(222, 28)
        Me.Special_RB.Name = "Special_RB"
        Me.Special_RB.Size = New System.Drawing.Size(76, 31)
        Me.Special_RB.TabIndex = 83
        Me.Special_RB.Text = "Special"
        Me.Special_RB.UseVisualStyleBackColor = True
        '
        'Save_BTN
        '
        Me.Save_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Save_BTN.Location = New System.Drawing.Point(171, 182)
        Me.Save_BTN.Name = "Save_BTN"
        Me.Save_BTN.Size = New System.Drawing.Size(99, 37)
        Me.Save_BTN.TabIndex = 84
        Me.Save_BTN.Text = "Save"
        Me.Save_BTN.UseVisualStyleBackColor = True
        '
        'Regular_RB
        '
        Me.Regular_RB.AutoSize = True
        Me.Regular_RB.Checked = True
        Me.Regular_RB.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Regular_RB.Location = New System.Drawing.Point(88, 28)
        Me.Regular_RB.Name = "Regular_RB"
        Me.Regular_RB.Size = New System.Drawing.Size(79, 31)
        Me.Regular_RB.TabIndex = 82
        Me.Regular_RB.TabStop = True
        Me.Regular_RB.Text = "Regular"
        Me.Regular_RB.UseVisualStyleBackColor = True
        '
        'Name_TXT
        '
        Me.Name_TXT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Name_TXT.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name_TXT.Location = New System.Drawing.Point(88, 120)
        Me.Name_TXT.Name = "Name_TXT"
        Me.Name_TXT.Size = New System.Drawing.Size(317, 33)
        Me.Name_TXT.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 25)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Date"
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Allow_Cancel_BTN)
        Me.TabPage1.Controls.Add(Me.Allow_Search_TXT)
        Me.TabPage1.Controls.Add(Me.Allow_Search_BTN)
        Me.TabPage1.Controls.Add(Me.Allowance_LV)
        Me.TabPage1.Controls.Add(Me.Allow_Fix_group)
        Me.TabPage1.Controls.Add(Me.Allow_SearchEmp_BTN)
        Me.TabPage1.Controls.Add(Me.Label14)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.Allow_Name_TXT)
        Me.TabPage1.Controls.Add(Me.Label16)
        Me.TabPage1.Controls.Add(Me.Allow_Save_BTN)
        Me.TabPage1.Controls.Add(Me.Allow_Category_Combo)
        Me.TabPage1.Controls.Add(Me.Allow_Amount_TXT)
        Me.TabPage1.Location = New System.Drawing.Point(4, 38)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1147, 604)
        Me.TabPage1.TabIndex = 1
        Me.TabPage1.Text = "  Allowances  "
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Allow_Cancel_BTN
        '
        Me.Allow_Cancel_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Allow_Cancel_BTN.Location = New System.Drawing.Point(106, 310)
        Me.Allow_Cancel_BTN.Name = "Allow_Cancel_BTN"
        Me.Allow_Cancel_BTN.Size = New System.Drawing.Size(90, 34)
        Me.Allow_Cancel_BTN.TabIndex = 110
        Me.Allow_Cancel_BTN.Text = "Cancel"
        Me.Allow_Cancel_BTN.UseVisualStyleBackColor = True
        '
        'Allow_Search_TXT
        '
        Me.Allow_Search_TXT.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Allow_Search_TXT.Location = New System.Drawing.Point(502, 33)
        Me.Allow_Search_TXT.Name = "Allow_Search_TXT"
        Me.Allow_Search_TXT.Size = New System.Drawing.Size(315, 33)
        Me.Allow_Search_TXT.TabIndex = 108
        '
        'Allow_Search_BTN
        '
        Me.Allow_Search_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Allow_Search_BTN.Location = New System.Drawing.Point(823, 32)
        Me.Allow_Search_BTN.Name = "Allow_Search_BTN"
        Me.Allow_Search_BTN.Size = New System.Drawing.Size(82, 33)
        Me.Allow_Search_BTN.TabIndex = 109
        Me.Allow_Search_BTN.Text = "Search"
        Me.Allow_Search_BTN.UseVisualStyleBackColor = True
        '
        'Allowance_LV
        '
        Me.Allowance_LV.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Allowance_LV.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5})
        Me.Allowance_LV.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Allowance_LV.FullRowSelect = True
        Me.Allowance_LV.GridLines = True
        Me.Allowance_LV.HideSelection = False
        Me.Allowance_LV.Location = New System.Drawing.Point(502, 72)
        Me.Allowance_LV.MultiSelect = False
        Me.Allowance_LV.Name = "Allowance_LV"
        Me.Allowance_LV.Size = New System.Drawing.Size(639, 525)
        Me.Allowance_LV.TabIndex = 107
        Me.Allowance_LV.UseCompatibleStateImageBehavior = False
        Me.Allowance_LV.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Category"
        Me.ColumnHeader3.Width = 135
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Fullname"
        Me.ColumnHeader4.Width = 380
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Amount"
        Me.ColumnHeader5.Width = 90
        '
        'Allow_Fix_group
        '
        Me.Allow_Fix_group.Controls.Add(Me.FixYes_RadioB)
        Me.Allow_Fix_group.Controls.Add(Me.FixNo_RadioB)
        Me.Allow_Fix_group.Location = New System.Drawing.Point(106, 201)
        Me.Allow_Fix_group.Name = "Allow_Fix_group"
        Me.Allow_Fix_group.Size = New System.Drawing.Size(319, 52)
        Me.Allow_Fix_group.TabIndex = 106
        Me.Allow_Fix_group.TabStop = False
        Me.Allow_Fix_group.Text = "Fix"
        Me.Allow_Fix_group.Visible = False
        '
        'FixYes_RadioB
        '
        Me.FixYes_RadioB.AutoSize = True
        Me.FixYes_RadioB.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FixYes_RadioB.Location = New System.Drawing.Point(93, 15)
        Me.FixYes_RadioB.Name = "FixYes_RadioB"
        Me.FixYes_RadioB.Size = New System.Drawing.Size(54, 31)
        Me.FixYes_RadioB.TabIndex = 96
        Me.FixYes_RadioB.Text = "Yes"
        Me.FixYes_RadioB.UseVisualStyleBackColor = True
        '
        'FixNo_RadioB
        '
        Me.FixNo_RadioB.AutoSize = True
        Me.FixNo_RadioB.Checked = True
        Me.FixNo_RadioB.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FixNo_RadioB.Location = New System.Drawing.Point(182, 15)
        Me.FixNo_RadioB.Name = "FixNo_RadioB"
        Me.FixNo_RadioB.Size = New System.Drawing.Size(49, 31)
        Me.FixNo_RadioB.TabIndex = 97
        Me.FixNo_RadioB.TabStop = True
        Me.FixNo_RadioB.Text = "No"
        Me.FixNo_RadioB.UseVisualStyleBackColor = True
        '
        'Allow_SearchEmp_BTN
        '
        Me.Allow_SearchEmp_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Allow_SearchEmp_BTN.Location = New System.Drawing.Point(434, 104)
        Me.Allow_SearchEmp_BTN.Name = "Allow_SearchEmp_BTN"
        Me.Allow_SearchEmp_BTN.Size = New System.Drawing.Size(47, 31)
        Me.Allow_SearchEmp_BTN.TabIndex = 105
        Me.Allow_SearchEmp_BTN.Text = "..."
        Me.Allow_SearchEmp_BTN.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(16, 110)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(49, 27)
        Me.Label14.TabIndex = 103
        Me.Label14.Text = "Name"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(16, 52)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(70, 27)
        Me.Label13.TabIndex = 102
        Me.Label13.Text = "Category"
        '
        'Allow_Name_TXT
        '
        Me.Allow_Name_TXT.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Allow_Name_TXT.Location = New System.Drawing.Point(106, 104)
        Me.Allow_Name_TXT.Name = "Allow_Name_TXT"
        Me.Allow_Name_TXT.ReadOnly = True
        Me.Allow_Name_TXT.Size = New System.Drawing.Size(319, 33)
        Me.Allow_Name_TXT.TabIndex = 101
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(16, 164)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(64, 27)
        Me.Label16.TabIndex = 95
        Me.Label16.Text = "Amount"
        '
        'Allow_Save_BTN
        '
        Me.Allow_Save_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Allow_Save_BTN.Location = New System.Drawing.Point(335, 310)
        Me.Allow_Save_BTN.Name = "Allow_Save_BTN"
        Me.Allow_Save_BTN.Size = New System.Drawing.Size(90, 34)
        Me.Allow_Save_BTN.TabIndex = 85
        Me.Allow_Save_BTN.Text = "Save"
        Me.Allow_Save_BTN.UseVisualStyleBackColor = True
        '
        'Allow_Category_Combo
        '
        Me.Allow_Category_Combo.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Allow_Category_Combo.FormattingEnabled = True
        Me.Allow_Category_Combo.Items.AddRange(New Object() {"Carekit", "Boarding", "Incentives", "Positional", "Transportation"})
        Me.Allow_Category_Combo.Location = New System.Drawing.Point(106, 47)
        Me.Allow_Category_Combo.Name = "Allow_Category_Combo"
        Me.Allow_Category_Combo.Size = New System.Drawing.Size(319, 33)
        Me.Allow_Category_Combo.TabIndex = 8
        Me.Allow_Category_Combo.Text = "Select "
        '
        'Allow_Amount_TXT
        '
        Me.Allow_Amount_TXT.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Allow_Amount_TXT.Location = New System.Drawing.Point(106, 162)
        Me.Allow_Amount_TXT.Name = "Allow_Amount_TXT"
        Me.Allow_Amount_TXT.Size = New System.Drawing.Size(319, 33)
        Me.Allow_Amount_TXT.TabIndex = 9
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 38)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(1147, 604)
        Me.TabPage2.TabIndex = 2
        Me.TabPage2.Text = "  Deductions  "
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Location = New System.Drawing.Point(4, 38)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(1147, 604)
        Me.TabPage3.TabIndex = 3
        Me.TabPage3.Text = "  Charges  "
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'TabPage4
        '
        Me.TabPage4.Location = New System.Drawing.Point(4, 38)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(1147, 604)
        Me.TabPage4.TabIndex = 4
        Me.TabPage4.Text = "  Loans  "
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Dubai", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(4, -1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 36)
        Me.Label1.TabIndex = 75
        Me.Label1.Text = "Settings"
        '
        'Holiday_Remove
        '
        Me.Holiday_Remove.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RemoveToolStripMenuItem})
        Me.Holiday_Remove.Name = "ContextMenuStrip1"
        Me.Holiday_Remove.Size = New System.Drawing.Size(118, 26)
        '
        'RemoveToolStripMenuItem
        '
        Me.RemoveToolStripMenuItem.Name = "RemoveToolStripMenuItem"
        Me.RemoveToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.RemoveToolStripMenuItem.Text = "Remove"
        '
        'FileSystemWatcher1
        '
        Me.FileSystemWatcher1.EnableRaisingEvents = True
        Me.FileSystemWatcher1.SynchronizingObject = Me
        '
        'Allowance_Remove
        '
        Me.Allowance_Remove.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Allow_Remove})
        Me.Allowance_Remove.Name = "ContextMenuStrip1"
        Me.Allowance_Remove.Size = New System.Drawing.Size(118, 26)
        '
        'Allow_Remove
        '
        Me.Allow_Remove.Name = "Allow_Remove"
        Me.Allow_Remove.Size = New System.Drawing.Size(180, 22)
        Me.Allow_Remove.Text = "Remove"
        '
        'frmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1175, 680)
        Me.Controls.Add(Me.Close_LBL)
        Me.Controls.Add(Me.Settings_Tab)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmSettings"
        Me.Text = "frmSettings"
        Me.Settings_Tab.ResumeLayout(False)
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        CType(Me.Rate_grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.Holiday_Tab.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.Allow_Fix_group.ResumeLayout(False)
        Me.Allow_Fix_group.PerformLayout()
        Me.Holiday_Remove.ResumeLayout(False)
        CType(Me.FileSystemWatcher1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Allowance_Remove.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Close_LBL As Label
    Friend WithEvents Settings_Tab As TabControl
    Friend WithEvents Holiday_Tab As TabPage
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Name_TXT As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Special_RB As RadioButton
    Friend WithEvents Regular_RB As RadioButton
    Friend WithEvents Date_DTP As DateTimePicker
    Friend WithEvents lvHoliday As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents Save_BTN As Button
    Friend WithEvents Holiday_Remove As ContextMenuStrip
    Friend WithEvents RemoveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label4 As Label
    Friend WithEvents HolidayRate_BTN As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents SpecialRate_TXT As TextBox
    Friend WithEvents RegularRate_TXT As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents TabPage5 As TabPage
    Friend WithEvents Rate_BranchAmount_TXT As TextBox
    Friend WithEvents Rate_Branch_ComboB As ComboBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents FileSystemWatcher1 As IO.FileSystemWatcher
    Friend WithEvents Rate_Branch_BTN As Button
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Rate_Position_BTN As Button
    Friend WithEvents Rate_Pos_ComboB As ComboBox
    Friend WithEvents Rate_PosAmount_TXT As TextBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents Rate_EmpSave_BTN As Button
    Friend WithEvents Rate_EmpAmount_TXT As TextBox
    Friend WithEvents Rate_Employee_TXT As TextBox
    Friend WithEvents Rate_EmpSelect_BTN As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Rate_BioNo_TXT As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Rate_EmpClear_BTN As Button
    Friend WithEvents Rate_Search_TXT As TextBox
    Friend WithEvents Rate_Search_BTN As Button
    Friend WithEvents Rate_grid As DataGridView
    Friend WithEvents Rate_Branch_DGV As DataGridViewTextBoxColumn
    Friend WithEvents Rate_Name_DGV As DataGridViewTextBoxColumn
    Friend WithEvents Rate_Pos_DGV As DataGridViewTextBoxColumn
    Friend WithEvents Rate_Rate_DGV As DataGridViewTextBoxColumn
    Friend WithEvents FixNo_RadioB As RadioButton
    Friend WithEvents FixYes_RadioB As RadioButton
    Friend WithEvents Label13 As Label
    Friend WithEvents Allow_Name_TXT As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Allow_Save_BTN As Button
    Friend WithEvents Allow_Category_Combo As ComboBox
    Friend WithEvents Allow_Amount_TXT As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Allow_SearchEmp_BTN As Button
    Friend WithEvents Allow_Fix_group As GroupBox
    Friend WithEvents Allowance_LV As ListView
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents Allow_Search_TXT As TextBox
    Friend WithEvents Allow_Search_BTN As Button
    Friend WithEvents Allow_Cancel_BTN As Button
    Friend WithEvents Allowance_Remove As ContextMenuStrip
    Friend WithEvents Allow_Remove As ToolStripMenuItem
End Class
