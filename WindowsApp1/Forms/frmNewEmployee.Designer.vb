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
        Me.components = New System.ComponentModel.Container()
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
        Me.Button2 = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Bio_TXT = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Add_Company_CB = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.HO_Category = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.ComCategory_Combo = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.ComCompany_Cmbo = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Branch_ComboB = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Started_DTP = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.EmpNo_TXT = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Position_Combo = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TimeIn_Combo = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TimeOut_Combo = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Fullname_TXT = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Email_TXT = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TIN_TXT = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.SSS_TXT = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.PHILH_TXT = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.HDMF_TXT = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Active_RB = New System.Windows.Forms.RadioButton()
        Me.InActive_RB = New System.Windows.Forms.RadioButton()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Add_Panel = New System.Windows.Forms.Panel()
        Me.Context_Details = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.View_Menu = New System.Windows.Forms.ToolStripMenuItem()
        Me.Excel_Panel.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.Add_Panel.SuspendLayout()
        Me.Context_Details.SuspendLayout()
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
        Me.Import_BTN.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Import_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Import_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Import_BTN.Location = New System.Drawing.Point(1064, 50)
        Me.Import_BTN.Name = "Import_BTN"
        Me.Import_BTN.Size = New System.Drawing.Size(91, 34)
        Me.Import_BTN.TabIndex = 76
        Me.Import_BTN.Text = "Import"
        Me.Import_BTN.UseVisualStyleBackColor = False
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
        Me.Add_BTN.BackColor = System.Drawing.Color.Silver
        Me.Add_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Add_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Add_BTN.Location = New System.Drawing.Point(935, 50)
        Me.Add_BTN.Name = "Add_BTN"
        Me.Add_BTN.Size = New System.Drawing.Size(109, 34)
        Me.Add_BTN.TabIndex = 94
        Me.Add_BTN.Text = "Add/Update"
        Me.Add_BTN.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Sienna
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(500, 486)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(76, 47)
        Me.Button2.TabIndex = 103
        Me.Button2.Text = "Save"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.Controls.Add(Me.Label6)
        Me.FlowLayoutPanel1.Controls.Add(Me.Bio_TXT)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label3)
        Me.FlowLayoutPanel1.Controls.Add(Me.Add_Company_CB)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label19)
        Me.FlowLayoutPanel1.Controls.Add(Me.HO_Category)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label20)
        Me.FlowLayoutPanel1.Controls.Add(Me.ComCategory_Combo)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label23)
        Me.FlowLayoutPanel1.Controls.Add(Me.ComCompany_Cmbo)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label4)
        Me.FlowLayoutPanel1.Controls.Add(Me.Branch_ComboB)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label5)
        Me.FlowLayoutPanel1.Controls.Add(Me.Started_DTP)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label12)
        Me.FlowLayoutPanel1.Controls.Add(Me.EmpNo_TXT)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label22)
        Me.FlowLayoutPanel1.Controls.Add(Me.Position_Combo)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label13)
        Me.FlowLayoutPanel1.Controls.Add(Me.TimeIn_Combo)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label14)
        Me.FlowLayoutPanel1.Controls.Add(Me.TimeOut_Combo)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label8)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label11)
        Me.FlowLayoutPanel1.Controls.Add(Me.Fullname_TXT)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label7)
        Me.FlowLayoutPanel1.Controls.Add(Me.Email_TXT)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label15)
        Me.FlowLayoutPanel1.Controls.Add(Me.TIN_TXT)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label16)
        Me.FlowLayoutPanel1.Controls.Add(Me.SSS_TXT)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label18)
        Me.FlowLayoutPanel1.Controls.Add(Me.PHILH_TXT)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label17)
        Me.FlowLayoutPanel1.Controls.Add(Me.HDMF_TXT)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label21)
        Me.FlowLayoutPanel1.Controls.Add(Me.Active_RB)
        Me.FlowLayoutPanel1.Controls.Add(Me.InActive_RB)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(20, 31)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(471, 586)
        Me.FlowLayoutPanel1.TabIndex = 96
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(3, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(121, 16)
        Me.Label6.TabIndex = 100
        Me.Label6.Text = "Bio No.                       "
        '
        'Bio_TXT
        '
        Me.Bio_TXT.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bio_TXT.Location = New System.Drawing.Point(130, 3)
        Me.Bio_TXT.Name = "Bio_TXT"
        Me.Bio_TXT.Size = New System.Drawing.Size(258, 26)
        Me.Bio_TXT.TabIndex = 86
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(3, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 16)
        Me.Label3.TabIndex = 87
        Me.Label3.Text = "Company                  "
        '
        'Add_Company_CB
        '
        Me.Add_Company_CB.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Add_Company_CB.FormattingEnabled = True
        Me.Add_Company_CB.Items.AddRange(New Object() {"PHOTO", "P&G UY", "DALTON", "PERFECOM", "HEAD OFFICE"})
        Me.Add_Company_CB.Location = New System.Drawing.Point(129, 35)
        Me.Add_Company_CB.Name = "Add_Company_CB"
        Me.Add_Company_CB.Size = New System.Drawing.Size(259, 28)
        Me.Add_Company_CB.TabIndex = 87
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(3, 66)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(119, 16)
        Me.Label19.TabIndex = 132
        Me.Label19.Text = "HO Category           "
        '
        'HO_Category
        '
        Me.HO_Category.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HO_Category.FormattingEnabled = True
        Me.HO_Category.Items.AddRange(New Object() {"GHS/P&G UY Admin Office", "GHS/P&G UY Admin Operation", "Dalton Admin Office", "Dalton Retail", "Dalton Admin Operation", "Perfecom Admin Office", "Perfecom Admin Operation", "Photo Admin Operation", "Photo Admin Office ", "Construction", "Leasing Admin Office", "PGC Head Office"})
        Me.HO_Category.Location = New System.Drawing.Point(128, 69)
        Me.HO_Category.Name = "HO_Category"
        Me.HO_Category.Size = New System.Drawing.Size(260, 28)
        Me.HO_Category.TabIndex = 88
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(3, 100)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(120, 16)
        Me.Label20.TabIndex = 134
        Me.Label20.Text = "Common Category"
        Me.Label20.Visible = False
        '
        'ComCategory_Combo
        '
        Me.ComCategory_Combo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComCategory_Combo.FormattingEnabled = True
        Me.ComCategory_Combo.Items.AddRange(New Object() {"PERFECOM/LEASING/7ELEVEN", "PHOTO/PERFECOM", "PHOTO/GHS/3G", "MARKETING", "EMPLOYEE", "BRANCH", "LEASING", "DYU", "LYU", "DTR"})
        Me.ComCategory_Combo.Location = New System.Drawing.Point(129, 103)
        Me.ComCategory_Combo.Name = "ComCategory_Combo"
        Me.ComCategory_Combo.Size = New System.Drawing.Size(259, 28)
        Me.ComCategory_Combo.TabIndex = 89
        Me.ComCategory_Combo.Visible = False
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Black
        Me.Label23.Location = New System.Drawing.Point(3, 134)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(120, 16)
        Me.Label23.TabIndex = 136
        Me.Label23.Text = "CommonCompany"
        Me.Label23.Visible = False
        '
        'ComCompany_Cmbo
        '
        Me.ComCompany_Cmbo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComCompany_Cmbo.FormattingEnabled = True
        Me.ComCompany_Cmbo.Items.AddRange(New Object() {"PHOTO", "P&G UY", "DALTON", "PERFECOM"})
        Me.ComCompany_Cmbo.Location = New System.Drawing.Point(129, 137)
        Me.ComCompany_Cmbo.Name = "ComCompany_Cmbo"
        Me.ComCompany_Cmbo.Size = New System.Drawing.Size(260, 28)
        Me.ComCompany_Cmbo.TabIndex = 137
        Me.ComCompany_Cmbo.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(3, 168)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(119, 16)
        Me.Label4.TabIndex = 97
        Me.Label4.Text = "Branch Code           "
        Me.Label4.Visible = False
        '
        'Branch_ComboB
        '
        Me.Branch_ComboB.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Branch_ComboB.FormattingEnabled = True
        Me.Branch_ComboB.Items.AddRange(New Object() {"PHOTO", "P&G UY", "DALTON", "PERFECOM", "HEAD OFFICE"})
        Me.Branch_ComboB.Location = New System.Drawing.Point(128, 171)
        Me.Branch_ComboB.Name = "Branch_ComboB"
        Me.Branch_ComboB.Size = New System.Drawing.Size(260, 28)
        Me.Branch_ComboB.TabIndex = 90
        Me.Branch_ComboB.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(3, 202)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(119, 16)
        Me.Label5.TabIndex = 98
        Me.Label5.Text = "Date Started            "
        '
        'Started_DTP
        '
        Me.Started_DTP.CalendarFont = New System.Drawing.Font("Dubai", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Started_DTP.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Started_DTP.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Started_DTP.Location = New System.Drawing.Point(128, 205)
        Me.Started_DTP.Name = "Started_DTP"
        Me.Started_DTP.Size = New System.Drawing.Size(260, 26)
        Me.Started_DTP.TabIndex = 91
        Me.Started_DTP.Value = New Date(2000, 1, 1, 0, 0, 0, 0)
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(3, 234)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(120, 16)
        Me.Label12.TabIndex = 113
        Me.Label12.Text = "Emp No.                    "
        '
        'EmpNo_TXT
        '
        Me.EmpNo_TXT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.EmpNo_TXT.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EmpNo_TXT.Location = New System.Drawing.Point(129, 237)
        Me.EmpNo_TXT.Name = "EmpNo_TXT"
        Me.EmpNo_TXT.Size = New System.Drawing.Size(259, 26)
        Me.EmpNo_TXT.TabIndex = 92
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(3, 266)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(119, 16)
        Me.Label22.TabIndex = 136
        Me.Label22.Text = "Position                     "
        '
        'Position_Combo
        '
        Me.Position_Combo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Position_Combo.FormattingEnabled = True
        Me.Position_Combo.Location = New System.Drawing.Point(128, 269)
        Me.Position_Combo.Name = "Position_Combo"
        Me.Position_Combo.Size = New System.Drawing.Size(261, 28)
        Me.Position_Combo.TabIndex = 137
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(3, 300)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(118, 16)
        Me.Label13.TabIndex = 117
        Me.Label13.Text = "Time In                      "
        '
        'TimeIn_Combo
        '
        Me.TimeIn_Combo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TimeIn_Combo.FormattingEnabled = True
        Me.TimeIn_Combo.Location = New System.Drawing.Point(127, 303)
        Me.TimeIn_Combo.Name = "TimeIn_Combo"
        Me.TimeIn_Combo.Size = New System.Drawing.Size(119, 28)
        Me.TimeIn_Combo.TabIndex = 93
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(252, 300)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(62, 16)
        Me.Label14.TabIndex = 118
        Me.Label14.Text = "Time Out"
        '
        'TimeOut_Combo
        '
        Me.TimeOut_Combo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TimeOut_Combo.FormattingEnabled = True
        Me.TimeOut_Combo.Location = New System.Drawing.Point(320, 303)
        Me.TimeOut_Combo.Name = "TimeOut_Combo"
        Me.TimeOut_Combo.Size = New System.Drawing.Size(126, 28)
        Me.TimeOut_Combo.TabIndex = 94
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(3, 334)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(379, 16)
        Me.Label8.TabIndex = 104
        Me.Label8.Text = "                                         (Last name, First name MI.)             " &
    "                 "
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(3, 350)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(120, 16)
        Me.Label11.TabIndex = 110
        Me.Label11.Text = "Fullname                   "
        '
        'Fullname_TXT
        '
        Me.Fullname_TXT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Fullname_TXT.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Fullname_TXT.Location = New System.Drawing.Point(129, 353)
        Me.Fullname_TXT.Name = "Fullname_TXT"
        Me.Fullname_TXT.Size = New System.Drawing.Size(318, 26)
        Me.Fullname_TXT.TabIndex = 95
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(3, 382)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(121, 16)
        Me.Label7.TabIndex = 101
        Me.Label7.Text = "Email Add.                "
        '
        'Email_TXT
        '
        Me.Email_TXT.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Email_TXT.Location = New System.Drawing.Point(130, 385)
        Me.Email_TXT.Name = "Email_TXT"
        Me.Email_TXT.Size = New System.Drawing.Size(316, 26)
        Me.Email_TXT.TabIndex = 96
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(3, 414)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(120, 16)
        Me.Label15.TabIndex = 120
        Me.Label15.Text = "TIN No.                      "
        '
        'TIN_TXT
        '
        Me.TIN_TXT.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TIN_TXT.Location = New System.Drawing.Point(129, 417)
        Me.TIN_TXT.Name = "TIN_TXT"
        Me.TIN_TXT.Size = New System.Drawing.Size(259, 26)
        Me.TIN_TXT.TabIndex = 97
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(3, 446)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(119, 16)
        Me.Label16.TabIndex = 122
        Me.Label16.Text = "SSS No.                    "
        '
        'SSS_TXT
        '
        Me.SSS_TXT.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SSS_TXT.Location = New System.Drawing.Point(128, 449)
        Me.SSS_TXT.Name = "SSS_TXT"
        Me.SSS_TXT.Size = New System.Drawing.Size(261, 26)
        Me.SSS_TXT.TabIndex = 98
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(3, 478)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(119, 16)
        Me.Label18.TabIndex = 124
        Me.Label18.Text = "PHILH No.                "
        '
        'PHILH_TXT
        '
        Me.PHILH_TXT.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PHILH_TXT.Location = New System.Drawing.Point(128, 481)
        Me.PHILH_TXT.Name = "PHILH_TXT"
        Me.PHILH_TXT.Size = New System.Drawing.Size(261, 26)
        Me.PHILH_TXT.TabIndex = 99
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(3, 510)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(119, 16)
        Me.Label17.TabIndex = 126
        Me.Label17.Text = "HDMF No.                "
        '
        'HDMF_TXT
        '
        Me.HDMF_TXT.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HDMF_TXT.Location = New System.Drawing.Point(128, 513)
        Me.HDMF_TXT.Name = "HDMF_TXT"
        Me.HDMF_TXT.Size = New System.Drawing.Size(261, 26)
        Me.HDMF_TXT.TabIndex = 100
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(3, 542)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(122, 16)
        Me.Label21.TabIndex = 138
        Me.Label21.Text = "                                      "
        '
        'Active_RB
        '
        Me.Active_RB.AutoSize = True
        Me.Active_RB.Checked = True
        Me.Active_RB.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Active_RB.ForeColor = System.Drawing.Color.Black
        Me.Active_RB.Location = New System.Drawing.Point(131, 545)
        Me.Active_RB.Name = "Active_RB"
        Me.Active_RB.Size = New System.Drawing.Size(137, 24)
        Me.Active_RB.TabIndex = 101
        Me.Active_RB.TabStop = True
        Me.Active_RB.Text = "ACTIVE             "
        Me.Active_RB.UseVisualStyleBackColor = True
        '
        'InActive_RB
        '
        Me.InActive_RB.AutoSize = True
        Me.InActive_RB.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InActive_RB.ForeColor = System.Drawing.Color.Black
        Me.InActive_RB.Location = New System.Drawing.Point(274, 545)
        Me.InActive_RB.Name = "InActive_RB"
        Me.InActive_RB.Size = New System.Drawing.Size(101, 24)
        Me.InActive_RB.TabIndex = 102
        Me.InActive_RB.Text = "INACTIVE"
        Me.InActive_RB.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.IndianRed
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(501, 423)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(76, 47)
        Me.Button1.TabIndex = 104
        Me.Button1.Text = "Cancel"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(199, 10)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(163, 18)
        Me.Label10.TabIndex = 106
        Me.Label10.Text = "Employee's Information"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(582, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(20, 20)
        Me.Label9.TabIndex = 105
        Me.Label9.Text = "X"
        '
        'Add_Panel
        '
        Me.Add_Panel.BackColor = System.Drawing.Color.Silver
        Me.Add_Panel.Controls.Add(Me.FlowLayoutPanel1)
        Me.Add_Panel.Controls.Add(Me.Button2)
        Me.Add_Panel.Controls.Add(Me.Button1)
        Me.Add_Panel.Controls.Add(Me.Label10)
        Me.Add_Panel.Controls.Add(Me.Label9)
        Me.Add_Panel.Location = New System.Drawing.Point(183, 12)
        Me.Add_Panel.Name = "Add_Panel"
        Me.Add_Panel.Size = New System.Drawing.Size(602, 620)
        Me.Add_Panel.TabIndex = 95
        Me.Add_Panel.Visible = False
        '
        'Context_Details
        '
        Me.Context_Details.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.View_Menu})
        Me.Context_Details.Name = "Context_Details"
        Me.Context_Details.Size = New System.Drawing.Size(138, 26)
        '
        'View_Menu
        '
        Me.View_Menu.Name = "View_Menu"
        Me.View_Menu.Size = New System.Drawing.Size(180, 22)
        Me.View_Menu.Text = "View Details"
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
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.Add_Panel.ResumeLayout(False)
        Me.Add_Panel.PerformLayout()
        Me.Context_Details.ResumeLayout(False)
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
    Friend WithEvents Label4 As Label
    Friend WithEvents Branch_ComboB As ComboBox
    Friend WithEvents Label5 As Label
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
    Friend WithEvents HDMF_TXT As TextBox
    Friend WithEvents PHILH_TXT As TextBox
    Friend WithEvents SSS_TXT As TextBox
    Friend WithEvents TIN_TXT As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents ComCategory_Combo As ComboBox
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents Label6 As Label
    Friend WithEvents Bio_TXT As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Add_Company_CB As ComboBox
    Friend WithEvents Label19 As Label
    Friend WithEvents HO_Category As ComboBox
    Friend WithEvents Label22 As Label
    Friend WithEvents Position_Combo As ComboBox
    Friend WithEvents Add_Panel As Panel
    Friend WithEvents Label23 As Label
    Friend WithEvents ComCompany_Cmbo As ComboBox
    Friend WithEvents Label21 As Label
    Friend WithEvents Context_Details As ContextMenuStrip
    Friend WithEvents View_Menu As ToolStripMenuItem
End Class
