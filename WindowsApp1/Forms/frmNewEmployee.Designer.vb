<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNewEmployee
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
        Me.lvEmployee = New System.Windows.Forms.ListView()
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Import_BTN = New System.Windows.Forms.Button()
        Me.Close_LBL = New System.Windows.Forms.Label()
        Me.Excel_Panel = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Company_ComboB = New System.Windows.Forms.ComboBox()
        Me.Label75 = New System.Windows.Forms.Label()
        Me.Label76 = New System.Windows.Forms.Label()
        Me.Path_TXT = New System.Windows.Forms.TextBox()
        Me.Browse_BTN = New System.Windows.Forms.Button()
        Me.Save_BTN = New System.Windows.Forms.Button()
        Me.Add_BTN = New System.Windows.Forms.Button()
        Me.Add_Panel = New System.Windows.Forms.Panel()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TimeOut_Combo = New System.Windows.Forms.ComboBox()
        Me.TimeIn_Combo = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.EmpNo_TXT = New System.Windows.Forms.TextBox()
        Me.Started_DTP = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.InActive_RB = New System.Windows.Forms.RadioButton()
        Me.Active_RB = New System.Windows.Forms.RadioButton()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Email_TXT = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Fullname_TXT = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Bio_TXT = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Branch_ComboB = New System.Windows.Forms.ComboBox()
        Me.Add_Company_CB = New System.Windows.Forms.ComboBox()
        Me.Excel_Panel.SuspendLayout()
        Me.Add_Panel.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvEmployee
        '
        Me.lvEmployee.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvEmployee.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader12, Me.ColumnHeader8, Me.ColumnHeader1, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11})
        Me.lvEmployee.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvEmployee.FullRowSelect = True
        Me.lvEmployee.GridLines = True
        Me.lvEmployee.HideSelection = False
        Me.lvEmployee.Location = New System.Drawing.Point(20, 110)
        Me.lvEmployee.MultiSelect = False
        Me.lvEmployee.Name = "lvEmployee"
        Me.lvEmployee.Size = New System.Drawing.Size(1135, 544)
        Me.lvEmployee.TabIndex = 73
        Me.lvEmployee.UseCompatibleStateImageBehavior = False
        Me.lvEmployee.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Company"
        Me.ColumnHeader2.Width = 130
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Branch Code"
        Me.ColumnHeader3.Width = 130
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Employee's Name"
        Me.ColumnHeader6.Width = 380
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Bio No."
        Me.ColumnHeader7.Width = 100
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "EMP NO."
        Me.ColumnHeader12.Width = 120
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Email Address"
        Me.ColumnHeader8.Width = 250
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Date Started"
        Me.ColumnHeader1.Width = 120
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Position"
        Me.ColumnHeader4.Width = 100
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "TIN No."
        Me.ColumnHeader5.Width = 150
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "SSS No."
        Me.ColumnHeader9.Width = 150
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "PhilHealth No."
        Me.ColumnHeader10.Width = 150
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Pagibig No. "
        Me.ColumnHeader11.Width = 150
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(415, 51)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(106, 34)
        Me.btnSearch.TabIndex = 72
        Me.btnSearch.Text = "&Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(20, 53)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(389, 31)
        Me.txtSearch.TabIndex = 71
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Dubai", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(182, 36)
        Me.Label1.TabIndex = 70
        Me.Label1.Text = "Employee's Record"
        '
        'Import_BTN
        '
        Me.Import_BTN.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Import_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Import_BTN.Location = New System.Drawing.Point(1064, 50)
        Me.Import_BTN.Name = "Import_BTN"
        Me.Import_BTN.Size = New System.Drawing.Size(91, 34)
        Me.Import_BTN.TabIndex = 76
        Me.Import_BTN.Text = "Import"
        Me.Import_BTN.UseVisualStyleBackColor = True
        '
        'Close_LBL
        '
        Me.Close_LBL.AutoSize = True
        Me.Close_LBL.Font = New System.Drawing.Font("Dubai", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Close_LBL.Location = New System.Drawing.Point(1114, 0)
        Me.Close_LBL.Name = "Close_LBL"
        Me.Close_LBL.Size = New System.Drawing.Size(57, 32)
        Me.Close_LBL.TabIndex = 77
        Me.Close_LBL.Text = "Close"
        '
        'Excel_Panel
        '
        Me.Excel_Panel.AutoSize = True
        Me.Excel_Panel.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Excel_Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Excel_Panel.Controls.Add(Me.Label2)
        Me.Excel_Panel.Controls.Add(Me.Company_ComboB)
        Me.Excel_Panel.Controls.Add(Me.Label75)
        Me.Excel_Panel.Controls.Add(Me.Label76)
        Me.Excel_Panel.Controls.Add(Me.Path_TXT)
        Me.Excel_Panel.Controls.Add(Me.Browse_BTN)
        Me.Excel_Panel.Controls.Add(Me.Save_BTN)
        Me.Excel_Panel.Location = New System.Drawing.Point(20, 575)
        Me.Excel_Panel.Name = "Excel_Panel"
        Me.Excel_Panel.Size = New System.Drawing.Size(756, 78)
        Me.Excel_Panel.TabIndex = 93
        Me.Excel_Panel.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(17, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 16)
        Me.Label2.TabIndex = 85
        Me.Label2.Text = "Select Company"
        '
        'Company_ComboB
        '
        Me.Company_ComboB.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Company_ComboB.FormattingEnabled = True
        Me.Company_ComboB.Items.AddRange(New Object() {"PHOTO", "P&G UY", "DALTON", "PERFECOM", "HEAD OFFICE"})
        Me.Company_ComboB.Location = New System.Drawing.Point(20, 28)
        Me.Company_ComboB.Name = "Company_ComboB"
        Me.Company_ComboB.Size = New System.Drawing.Size(161, 28)
        Me.Company_ComboB.TabIndex = 84
        '
        'Label75
        '
        Me.Label75.AutoSize = True
        Me.Label75.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label75.ForeColor = System.Drawing.Color.White
        Me.Label75.Location = New System.Drawing.Point(203, 9)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(109, 16)
        Me.Label75.TabIndex = 83
        Me.Label75.Text = "Browse Excel file"
        '
        'Label76
        '
        Me.Label76.AutoSize = True
        Me.Label76.ForeColor = System.Drawing.Color.White
        Me.Label76.Location = New System.Drawing.Point(737, 0)
        Me.Label76.Name = "Label76"
        Me.Label76.Size = New System.Drawing.Size(14, 13)
        Me.Label76.TabIndex = 82
        Me.Label76.Text = "X"
        '
        'Path_TXT
        '
        Me.Path_TXT.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Path_TXT.Location = New System.Drawing.Point(206, 28)
        Me.Path_TXT.Name = "Path_TXT"
        Me.Path_TXT.Size = New System.Drawing.Size(365, 26)
        Me.Path_TXT.TabIndex = 81
        '
        'Browse_BTN
        '
        Me.Browse_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Browse_BTN.Location = New System.Drawing.Point(577, 25)
        Me.Browse_BTN.Name = "Browse_BTN"
        Me.Browse_BTN.Size = New System.Drawing.Size(76, 31)
        Me.Browse_BTN.TabIndex = 80
        Me.Browse_BTN.Text = "Browse"
        Me.Browse_BTN.UseVisualStyleBackColor = True
        '
        'Save_BTN
        '
        Me.Save_BTN.Enabled = False
        Me.Save_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Save_BTN.Location = New System.Drawing.Point(659, 25)
        Me.Save_BTN.Name = "Save_BTN"
        Me.Save_BTN.Size = New System.Drawing.Size(80, 31)
        Me.Save_BTN.TabIndex = 79
        Me.Save_BTN.Text = "Save"
        Me.Save_BTN.UseVisualStyleBackColor = True
        '
        'Add_BTN
        '
        Me.Add_BTN.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Add_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Add_BTN.Location = New System.Drawing.Point(935, 50)
        Me.Add_BTN.Name = "Add_BTN"
        Me.Add_BTN.Size = New System.Drawing.Size(109, 34)
        Me.Add_BTN.TabIndex = 94
        Me.Add_BTN.Text = "Add/Update"
        Me.Add_BTN.UseVisualStyleBackColor = True
        '
        'Add_Panel
        '
        Me.Add_Panel.BackColor = System.Drawing.Color.MidnightBlue
        Me.Add_Panel.Controls.Add(Me.Label14)
        Me.Add_Panel.Controls.Add(Me.Label13)
        Me.Add_Panel.Controls.Add(Me.TimeOut_Combo)
        Me.Add_Panel.Controls.Add(Me.TimeIn_Combo)
        Me.Add_Panel.Controls.Add(Me.Label12)
        Me.Add_Panel.Controls.Add(Me.EmpNo_TXT)
        Me.Add_Panel.Controls.Add(Me.Started_DTP)
        Me.Add_Panel.Controls.Add(Me.Label11)
        Me.Add_Panel.Controls.Add(Me.InActive_RB)
        Me.Add_Panel.Controls.Add(Me.Active_RB)
        Me.Add_Panel.Controls.Add(Me.Label10)
        Me.Add_Panel.Controls.Add(Me.Label9)
        Me.Add_Panel.Controls.Add(Me.Label8)
        Me.Add_Panel.Controls.Add(Me.Button2)
        Me.Add_Panel.Controls.Add(Me.Button1)
        Me.Add_Panel.Controls.Add(Me.Email_TXT)
        Me.Add_Panel.Controls.Add(Me.Label7)
        Me.Add_Panel.Controls.Add(Me.Label6)
        Me.Add_Panel.Controls.Add(Me.Fullname_TXT)
        Me.Add_Panel.Controls.Add(Me.Label5)
        Me.Add_Panel.Controls.Add(Me.Bio_TXT)
        Me.Add_Panel.Controls.Add(Me.Label4)
        Me.Add_Panel.Controls.Add(Me.Label3)
        Me.Add_Panel.Controls.Add(Me.Branch_ComboB)
        Me.Add_Panel.Controls.Add(Me.Add_Company_CB)
        Me.Add_Panel.Location = New System.Drawing.Point(350, 91)
        Me.Add_Panel.Name = "Add_Panel"
        Me.Add_Panel.Size = New System.Drawing.Size(575, 429)
        Me.Add_Panel.TabIndex = 95
        Me.Add_Panel.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.LightSalmon
        Me.Label14.Location = New System.Drawing.Point(318, 139)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(62, 16)
        Me.Label14.TabIndex = 118
        Me.Label14.Text = "Time Out"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.LightSalmon
        Me.Label13.Location = New System.Drawing.Point(318, 95)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(52, 16)
        Me.Label13.TabIndex = 117
        Me.Label13.Text = "Time In"
        '
        'TimeOut_Combo
        '
        Me.TimeOut_Combo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TimeOut_Combo.FormattingEnabled = True
        Me.TimeOut_Combo.Location = New System.Drawing.Point(384, 133)
        Me.TimeOut_Combo.Name = "TimeOut_Combo"
        Me.TimeOut_Combo.Size = New System.Drawing.Size(169, 28)
        Me.TimeOut_Combo.TabIndex = 116
        '
        'TimeIn_Combo
        '
        Me.TimeIn_Combo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TimeIn_Combo.FormattingEnabled = True
        Me.TimeIn_Combo.Location = New System.Drawing.Point(384, 89)
        Me.TimeIn_Combo.Name = "TimeIn_Combo"
        Me.TimeIn_Combo.Size = New System.Drawing.Size(169, 28)
        Me.TimeIn_Combo.TabIndex = 114
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.LightSalmon
        Me.Label12.Location = New System.Drawing.Point(318, 192)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(60, 16)
        Me.Label12.TabIndex = 113
        Me.Label12.Text = "Emp No."
        '
        'EmpNo_TXT
        '
        Me.EmpNo_TXT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.EmpNo_TXT.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EmpNo_TXT.Location = New System.Drawing.Point(384, 186)
        Me.EmpNo_TXT.Name = "EmpNo_TXT"
        Me.EmpNo_TXT.Size = New System.Drawing.Size(169, 26)
        Me.EmpNo_TXT.TabIndex = 112
        '
        'Started_DTP
        '
        Me.Started_DTP.CalendarFont = New System.Drawing.Font("Dubai", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Started_DTP.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Started_DTP.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Started_DTP.Location = New System.Drawing.Point(119, 187)
        Me.Started_DTP.Name = "Started_DTP"
        Me.Started_DTP.Size = New System.Drawing.Size(161, 24)
        Me.Started_DTP.TabIndex = 111
        Me.Started_DTP.Value = New Date(2000, 1, 1, 0, 0, 0, 0)
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.LightSalmon
        Me.Label11.Location = New System.Drawing.Point(23, 251)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(63, 16)
        Me.Label11.TabIndex = 110
        Me.Label11.Text = "Fullname"
        '
        'InActive_RB
        '
        Me.InActive_RB.AutoSize = True
        Me.InActive_RB.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InActive_RB.ForeColor = System.Drawing.Color.LightSalmon
        Me.InActive_RB.Location = New System.Drawing.Point(233, 333)
        Me.InActive_RB.Name = "InActive_RB"
        Me.InActive_RB.Size = New System.Drawing.Size(101, 24)
        Me.InActive_RB.TabIndex = 108
        Me.InActive_RB.Text = "INACTIVE"
        Me.InActive_RB.UseVisualStyleBackColor = True
        '
        'Active_RB
        '
        Me.Active_RB.AutoSize = True
        Me.Active_RB.Checked = True
        Me.Active_RB.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Active_RB.ForeColor = System.Drawing.Color.LightSalmon
        Me.Active_RB.Location = New System.Drawing.Point(119, 333)
        Me.Active_RB.Name = "Active_RB"
        Me.Active_RB.Size = New System.Drawing.Size(85, 24)
        Me.Active_RB.TabIndex = 107
        Me.Active_RB.TabStop = True
        Me.Active_RB.Text = "ACTIVE"
        Me.Active_RB.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.LightSalmon
        Me.Label10.Location = New System.Drawing.Point(186, 11)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(163, 18)
        Me.Label10.TabIndex = 106
        Me.Label10.Text = "Employee's Information"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.LightSalmon
        Me.Label9.Location = New System.Drawing.Point(555, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(20, 20)
        Me.Label9.TabIndex = 105
        Me.Label9.Text = "X"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.LightSalmon
        Me.Label8.Location = New System.Drawing.Point(116, 228)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(166, 16)
        Me.Label8.TabIndex = 104
        Me.Label8.Text = "(Last name, First name MI.)"
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(451, 383)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(102, 31)
        Me.Button2.TabIndex = 103
        Me.Button2.Text = "Save"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(26, 383)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(99, 31)
        Me.Button1.TabIndex = 86
        Me.Button1.Text = "Cancel"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Email_TXT
        '
        Me.Email_TXT.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Email_TXT.Location = New System.Drawing.Point(119, 290)
        Me.Email_TXT.Name = "Email_TXT"
        Me.Email_TXT.Size = New System.Drawing.Size(434, 26)
        Me.Email_TXT.TabIndex = 102
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.LightSalmon
        Me.Label7.Location = New System.Drawing.Point(23, 294)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 16)
        Me.Label7.TabIndex = 101
        Me.Label7.Text = "Email Add."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.LightSalmon
        Me.Label6.Location = New System.Drawing.Point(23, 54)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 16)
        Me.Label6.TabIndex = 100
        Me.Label6.Text = "Bio No."
        '
        'Fullname_TXT
        '
        Me.Fullname_TXT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Fullname_TXT.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Fullname_TXT.Location = New System.Drawing.Point(119, 247)
        Me.Fullname_TXT.Name = "Fullname_TXT"
        Me.Fullname_TXT.Size = New System.Drawing.Size(434, 26)
        Me.Fullname_TXT.TabIndex = 99
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.LightSalmon
        Me.Label5.Location = New System.Drawing.Point(23, 192)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 16)
        Me.Label5.TabIndex = 98
        Me.Label5.Text = "Date Started"
        '
        'Bio_TXT
        '
        Me.Bio_TXT.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bio_TXT.Location = New System.Drawing.Point(119, 49)
        Me.Bio_TXT.Name = "Bio_TXT"
        Me.Bio_TXT.Size = New System.Drawing.Size(161, 26)
        Me.Bio_TXT.TabIndex = 86
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.LightSalmon
        Me.Label4.Location = New System.Drawing.Point(23, 144)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 16)
        Me.Label4.TabIndex = 97
        Me.Label4.Text = "Branch Code"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.LightSalmon
        Me.Label3.Location = New System.Drawing.Point(23, 101)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 16)
        Me.Label3.TabIndex = 87
        Me.Label3.Text = "Company"
        '
        'Branch_ComboB
        '
        Me.Branch_ComboB.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Branch_ComboB.FormattingEnabled = True
        Me.Branch_ComboB.Items.AddRange(New Object() {"PHOTO", "P&G UY", "DALTON", "PERFECOM", "HEAD OFFICE"})
        Me.Branch_ComboB.Location = New System.Drawing.Point(119, 139)
        Me.Branch_ComboB.Name = "Branch_ComboB"
        Me.Branch_ComboB.Size = New System.Drawing.Size(161, 28)
        Me.Branch_ComboB.TabIndex = 96
        '
        'Add_Company_CB
        '
        Me.Add_Company_CB.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Add_Company_CB.FormattingEnabled = True
        Me.Add_Company_CB.Items.AddRange(New Object() {"PHOTO", "P&G UY", "DALTON", "PERFECOM", "HEAD OFFICE"})
        Me.Add_Company_CB.Location = New System.Drawing.Point(119, 95)
        Me.Add_Company_CB.Name = "Add_Company_CB"
        Me.Add_Company_CB.Size = New System.Drawing.Size(161, 28)
        Me.Add_Company_CB.TabIndex = 86
        '
        'frmNewEmployee
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1169, 665)
        Me.Controls.Add(Me.Add_Panel)
        Me.Controls.Add(Me.Add_BTN)
        Me.Controls.Add(Me.Excel_Panel)
        Me.Controls.Add(Me.Close_LBL)
        Me.Controls.Add(Me.Import_BTN)
        Me.Controls.Add(Me.lvEmployee)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmNewEmployee"
        Me.Text = "frmNewEmployee"
        Me.Excel_Panel.ResumeLayout(False)
        Me.Excel_Panel.PerformLayout()
        Me.Add_Panel.ResumeLayout(False)
        Me.Add_Panel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lvEmployee As ListView
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents btnSearch As Button
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Import_BTN As Button
    Friend WithEvents Close_LBL As Label
    Friend WithEvents Excel_Panel As Panel
    Friend WithEvents Label75 As Label
    Friend WithEvents Label76 As Label
    Friend WithEvents Path_TXT As TextBox
    Friend WithEvents Browse_BTN As Button
    Friend WithEvents Save_BTN As Button
    Friend WithEvents Add_BTN As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Company_ComboB As ComboBox
    Friend WithEvents Add_Panel As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Add_Company_CB As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Branch_ComboB As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Bio_TXT As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Fullname_TXT As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Email_TXT As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents InActive_RB As RadioButton
    Friend WithEvents Active_RB As RadioButton
    Friend WithEvents Started_DTP As DateTimePicker
    Friend WithEvents Label11 As Label
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader9 As ColumnHeader
    Friend WithEvents ColumnHeader10 As ColumnHeader
    Friend WithEvents ColumnHeader11 As ColumnHeader
    Friend WithEvents ColumnHeader12 As ColumnHeader
    Friend WithEvents Label12 As Label
    Friend WithEvents EmpNo_TXT As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents TimeOut_Combo As ComboBox
    Friend WithEvents TimeIn_Combo As ComboBox
End Class
