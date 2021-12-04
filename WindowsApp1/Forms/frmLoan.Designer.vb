<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLoan
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
        Me.Close_LBL = New System.Windows.Forms.Label()
        Me.Loans_Tab = New System.Windows.Forms.TabControl()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Effectiv_dtp = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Schedule_Combo = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Category_Combo = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Name_txt = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Amount_txt = New System.Windows.Forms.TextBox()
        Me.Cancel_btn = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.noOfDeduc_txt = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Total_txt = New System.Windows.Forms.TextBox()
        Me.Save_btn = New System.Windows.Forms.Button()
        Me.Search_txt = New System.Windows.Forms.TextBox()
        Me.Search_btn = New System.Windows.Forms.Button()
        Me.Deduc_list = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.CatDeduc_list = New System.Windows.Forms.ListView()
        Me.ColumnHeader22 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CatDeducSave_BTN = New System.Windows.Forms.Button()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Deduct_txt = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader15 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader16 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.DE_Save_BTN = New System.Windows.Forms.Button()
        Me.DE_Total_TXT = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.DE_SearchEmp_BTN = New System.Windows.Forms.Button()
        Me.DE_NoOfGives_TXT = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.DE_Cancel_BTN = New System.Windows.Forms.Button()
        Me.DE_AmountGive_TXT = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.DE_Name_TXT = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.DE_Category_Combo = New System.Windows.Forms.ComboBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.DE_Schedule_Combo = New System.Windows.Forms.ComboBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.DE_Effectivity_DTP = New System.Windows.Forms.DateTimePicker()
        Me.lblAdd = New System.Windows.Forms.Label()
        Me.Context_deduct = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.menu_subtotal = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_edit = New System.Windows.Forms.ToolStripMenuItem()
        Me.Loans_Tab.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.Context_deduct.SuspendLayout()
        Me.SuspendLayout()
        '
        'Close_LBL
        '
        Me.Close_LBL.AutoSize = True
        Me.Close_LBL.Font = New System.Drawing.Font("Dubai", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Close_LBL.Location = New System.Drawing.Point(1117, 2)
        Me.Close_LBL.Name = "Close_LBL"
        Me.Close_LBL.Size = New System.Drawing.Size(57, 32)
        Me.Close_LBL.TabIndex = 80
        Me.Close_LBL.Text = "Close"
        '
        'Loans_Tab
        '
        Me.Loans_Tab.Controls.Add(Me.TabPage2)
        Me.Loans_Tab.Controls.Add(Me.TabPage4)
        Me.Loans_Tab.Font = New System.Drawing.Font("Dubai", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Loans_Tab.Location = New System.Drawing.Point(6, 32)
        Me.Loans_Tab.Name = "Loans_Tab"
        Me.Loans_Tab.SelectedIndex = 0
        Me.Loans_Tab.Size = New System.Drawing.Size(1155, 646)
        Me.Loans_Tab.TabIndex = 78
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox6)
        Me.TabPage2.Controls.Add(Me.Search_txt)
        Me.TabPage2.Controls.Add(Me.Search_btn)
        Me.TabPage2.Controls.Add(Me.Deduc_list)
        Me.TabPage2.Location = New System.Drawing.Point(4, 38)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(1147, 604)
        Me.TabPage2.TabIndex = 2
        Me.TabPage2.Text = "  Deductions  "
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Label2)
        Me.GroupBox6.Controls.Add(Me.Effectiv_dtp)
        Me.GroupBox6.Controls.Add(Me.Label3)
        Me.GroupBox6.Controls.Add(Me.Schedule_Combo)
        Me.GroupBox6.Controls.Add(Me.Label4)
        Me.GroupBox6.Controls.Add(Me.Category_Combo)
        Me.GroupBox6.Controls.Add(Me.Label5)
        Me.GroupBox6.Controls.Add(Me.Name_txt)
        Me.GroupBox6.Controls.Add(Me.Label6)
        Me.GroupBox6.Controls.Add(Me.Amount_txt)
        Me.GroupBox6.Controls.Add(Me.Cancel_btn)
        Me.GroupBox6.Controls.Add(Me.Label7)
        Me.GroupBox6.Controls.Add(Me.Label8)
        Me.GroupBox6.Controls.Add(Me.noOfDeduc_txt)
        Me.GroupBox6.Controls.Add(Me.Button2)
        Me.GroupBox6.Controls.Add(Me.Label9)
        Me.GroupBox6.Controls.Add(Me.Total_txt)
        Me.GroupBox6.Controls.Add(Me.Save_btn)
        Me.GroupBox6.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.Location = New System.Drawing.Point(4, 4)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(1134, 180)
        Me.GroupBox6.TabIndex = 126
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Information"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label2.Location = New System.Drawing.Point(429, 82)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 22)
        Me.Label2.TabIndex = 125
        Me.Label2.Text = "Add"
        '
        'Effectiv_dtp
        '
        Me.Effectiv_dtp.Location = New System.Drawing.Point(693, 137)
        Me.Effectiv_dtp.Name = "Effectiv_dtp"
        Me.Effectiv_dtp.Size = New System.Drawing.Size(223, 29)
        Me.Effectiv_dtp.TabIndex = 40
        Me.Effectiv_dtp.Value = New Date(2021, 9, 15, 0, 0, 0, 0)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(548, 139)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 25)
        Me.Label3.TabIndex = 124
        Me.Label3.Text = "Effectivity"
        '
        'Schedule_Combo
        '
        Me.Schedule_Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Schedule_Combo.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Schedule_Combo.FormattingEnabled = True
        Me.Schedule_Combo.Items.AddRange(New Object() {"OPEN PAYROLL", "CLOSE PAYROLL", "EVERY PAYROLL"})
        Me.Schedule_Combo.Location = New System.Drawing.Point(97, 116)
        Me.Schedule_Combo.Name = "Schedule_Combo"
        Me.Schedule_Combo.Size = New System.Drawing.Size(319, 33)
        Me.Schedule_Combo.TabIndex = 36
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 118)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 25)
        Me.Label4.TabIndex = 123
        Me.Label4.Text = "Schedule"
        '
        'Category_Combo
        '
        Me.Category_Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Category_Combo.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Category_Combo.FormattingEnabled = True
        Me.Category_Combo.Location = New System.Drawing.Point(97, 77)
        Me.Category_Combo.Name = "Category_Combo"
        Me.Category_Combo.Size = New System.Drawing.Size(319, 33)
        Me.Category_Combo.TabIndex = 35
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(548, 91)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(132, 25)
        Me.Label5.TabIndex = 121
        Me.Label5.Text = "Amount per Deduc."
        '
        'Name_txt
        '
        Me.Name_txt.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name_txt.Location = New System.Drawing.Point(97, 35)
        Me.Name_txt.Name = "Name_txt"
        Me.Name_txt.ReadOnly = True
        Me.Name_txt.Size = New System.Drawing.Size(319, 33)
        Me.Name_txt.TabIndex = 109
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(8, 79)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 25)
        Me.Label6.TabIndex = 110
        Me.Label6.Text = "Category"
        '
        'Amount_txt
        '
        Me.Amount_txt.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Amount_txt.Location = New System.Drawing.Point(693, 87)
        Me.Amount_txt.Name = "Amount_txt"
        Me.Amount_txt.Size = New System.Drawing.Size(223, 29)
        Me.Amount_txt.TabIndex = 39
        '
        'Cancel_btn
        '
        Me.Cancel_btn.BackColor = System.Drawing.Color.MistyRose
        Me.Cancel_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cancel_btn.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel_btn.Location = New System.Drawing.Point(964, 132)
        Me.Cancel_btn.Name = "Cancel_btn"
        Me.Cancel_btn.Size = New System.Drawing.Size(78, 33)
        Me.Cancel_btn.TabIndex = 42
        Me.Cancel_btn.Text = "Cancel"
        Me.Cancel_btn.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(548, 56)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(93, 25)
        Me.Label7.TabIndex = 119
        Me.Label7.Text = "No of Deduc."
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(8, 37)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 25)
        Me.Label8.TabIndex = 111
        Me.Label8.Text = "Name"
        '
        'noOfDeduc_txt
        '
        Me.noOfDeduc_txt.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.noOfDeduc_txt.Location = New System.Drawing.Point(693, 54)
        Me.noOfDeduc_txt.Name = "noOfDeduc_txt"
        Me.noOfDeduc_txt.Size = New System.Drawing.Size(223, 29)
        Me.noOfDeduc_txt.TabIndex = 38
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(422, 36)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(47, 31)
        Me.Button2.TabIndex = 34
        Me.Button2.Text = "..."
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(548, 26)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(44, 25)
        Me.Label9.TabIndex = 108
        Me.Label9.Text = "Total"
        '
        'Total_txt
        '
        Me.Total_txt.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Total_txt.Location = New System.Drawing.Point(693, 21)
        Me.Total_txt.Name = "Total_txt"
        Me.Total_txt.Size = New System.Drawing.Size(223, 29)
        Me.Total_txt.TabIndex = 37
        '
        'Save_btn
        '
        Me.Save_btn.BackColor = System.Drawing.Color.RosyBrown
        Me.Save_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Save_btn.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Save_btn.Location = New System.Drawing.Point(1050, 132)
        Me.Save_btn.Name = "Save_btn"
        Me.Save_btn.Size = New System.Drawing.Size(78, 33)
        Me.Save_btn.TabIndex = 41
        Me.Save_btn.Text = "Save"
        Me.Save_btn.UseVisualStyleBackColor = False
        '
        'Search_txt
        '
        Me.Search_txt.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Search_txt.Location = New System.Drawing.Point(17, 204)
        Me.Search_txt.Name = "Search_txt"
        Me.Search_txt.Size = New System.Drawing.Size(358, 33)
        Me.Search_txt.TabIndex = 123
        '
        'Search_btn
        '
        Me.Search_btn.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Search_btn.Location = New System.Drawing.Point(381, 203)
        Me.Search_btn.Name = "Search_btn"
        Me.Search_btn.Size = New System.Drawing.Size(82, 33)
        Me.Search_btn.TabIndex = 124
        Me.Search_btn.Text = "Search"
        Me.Search_btn.UseVisualStyleBackColor = True
        '
        'Deduc_list
        '
        Me.Deduc_list.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Deduc_list.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7})
        Me.Deduc_list.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Deduc_list.FullRowSelect = True
        Me.Deduc_list.GridLines = True
        Me.Deduc_list.HideSelection = False
        Me.Deduc_list.Location = New System.Drawing.Point(18, 252)
        Me.Deduc_list.MultiSelect = False
        Me.Deduc_list.Name = "Deduc_list"
        Me.Deduc_list.Size = New System.Drawing.Size(1125, 348)
        Me.Deduc_list.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.Deduc_list.TabIndex = 125
        Me.Deduc_list.UseCompatibleStateImageBehavior = False
        Me.Deduc_list.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Fullname"
        Me.ColumnHeader1.Width = 400
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Category"
        Me.ColumnHeader2.Width = 130
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Total"
        Me.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader3.Width = 85
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "No. of Deduc."
        Me.ColumnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader4.Width = 110
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Amount/Deduc"
        Me.ColumnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader5.Width = 130
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Schedule"
        Me.ColumnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader6.Width = 140
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Balance"
        Me.ColumnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader7.Width = 100
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.GroupBox8)
        Me.TabPage4.Location = New System.Drawing.Point(4, 38)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(1147, 604)
        Me.TabPage4.TabIndex = 7
        Me.TabPage4.Text = "  Category  "
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.CatDeduc_list)
        Me.GroupBox8.Controls.Add(Me.CatDeducSave_BTN)
        Me.GroupBox8.Controls.Add(Me.Label24)
        Me.GroupBox8.Controls.Add(Me.Deduct_txt)
        Me.GroupBox8.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox8.Location = New System.Drawing.Point(18, 19)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(403, 570)
        Me.GroupBox8.TabIndex = 122
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Deductions"
        '
        'CatDeduc_list
        '
        Me.CatDeduc_list.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CatDeduc_list.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader22})
        Me.CatDeduc_list.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CatDeduc_list.FullRowSelect = True
        Me.CatDeduc_list.GridLines = True
        Me.CatDeduc_list.HideSelection = False
        Me.CatDeduc_list.Location = New System.Drawing.Point(16, 120)
        Me.CatDeduc_list.MultiSelect = False
        Me.CatDeduc_list.Name = "CatDeduc_list"
        Me.CatDeduc_list.Size = New System.Drawing.Size(309, 444)
        Me.CatDeduc_list.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.CatDeduc_list.TabIndex = 51
        Me.CatDeduc_list.UseCompatibleStateImageBehavior = False
        Me.CatDeduc_list.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader22
        '
        Me.ColumnHeader22.Text = "List of Deduction"
        Me.ColumnHeader22.Width = 300
        '
        'CatDeducSave_BTN
        '
        Me.CatDeducSave_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CatDeducSave_BTN.Location = New System.Drawing.Point(332, 69)
        Me.CatDeducSave_BTN.Name = "CatDeducSave_BTN"
        Me.CatDeducSave_BTN.Size = New System.Drawing.Size(61, 35)
        Me.CatDeducSave_BTN.TabIndex = 50
        Me.CatDeducSave_BTN.Text = "Save"
        Me.CatDeducSave_BTN.UseVisualStyleBackColor = True
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(11, 35)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(111, 27)
        Me.Label24.TabIndex = 122
        Me.Label24.Text = "Category Name"
        '
        'Deduct_txt
        '
        Me.Deduct_txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Deduct_txt.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Deduct_txt.Location = New System.Drawing.Point(15, 69)
        Me.Deduct_txt.Name = "Deduct_txt"
        Me.Deduct_txt.Size = New System.Drawing.Size(310, 35)
        Me.Deduct_txt.TabIndex = 49
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Dubai", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 36)
        Me.Label1.TabIndex = 79
        Me.Label1.Text = "Loans"
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.DisplayIndex = 0
        Me.ColumnHeader11.Text = "Fullname"
        Me.ColumnHeader11.Width = 400
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.DisplayIndex = 1
        Me.ColumnHeader12.Text = "Category"
        Me.ColumnHeader12.Width = 130
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.DisplayIndex = 2
        Me.ColumnHeader13.Text = "Total"
        Me.ColumnHeader13.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader13.Width = 85
        '
        'ColumnHeader15
        '
        Me.ColumnHeader15.DisplayIndex = 3
        Me.ColumnHeader15.Text = "No. of Deduc."
        Me.ColumnHeader15.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader15.Width = 110
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.DisplayIndex = 4
        Me.ColumnHeader14.Text = "Amount/Deduc"
        Me.ColumnHeader14.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader14.Width = 130
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.DisplayIndex = 5
        Me.ColumnHeader8.Text = "Schedule"
        Me.ColumnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader8.Width = 140
        '
        'ColumnHeader16
        '
        Me.ColumnHeader16.DisplayIndex = 6
        Me.ColumnHeader16.Text = "Balance"
        Me.ColumnHeader16.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader16.Width = 100
        '
        'DE_Save_BTN
        '
        Me.DE_Save_BTN.BackColor = System.Drawing.Color.RosyBrown
        Me.DE_Save_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DE_Save_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DE_Save_BTN.Location = New System.Drawing.Point(1050, 132)
        Me.DE_Save_BTN.Name = "DE_Save_BTN"
        Me.DE_Save_BTN.Size = New System.Drawing.Size(78, 33)
        Me.DE_Save_BTN.TabIndex = 41
        Me.DE_Save_BTN.Text = "Save"
        Me.DE_Save_BTN.UseVisualStyleBackColor = False
        '
        'DE_Total_TXT
        '
        Me.DE_Total_TXT.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DE_Total_TXT.Location = New System.Drawing.Point(693, 21)
        Me.DE_Total_TXT.Name = "DE_Total_TXT"
        Me.DE_Total_TXT.Size = New System.Drawing.Size(223, 29)
        Me.DE_Total_TXT.TabIndex = 37
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(548, 26)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(44, 25)
        Me.Label18.TabIndex = 108
        '
        'DE_SearchEmp_BTN
        '
        Me.DE_SearchEmp_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DE_SearchEmp_BTN.Location = New System.Drawing.Point(422, 36)
        Me.DE_SearchEmp_BTN.Name = "DE_SearchEmp_BTN"
        Me.DE_SearchEmp_BTN.Size = New System.Drawing.Size(47, 31)
        Me.DE_SearchEmp_BTN.TabIndex = 34
        Me.DE_SearchEmp_BTN.Text = "..."
        Me.DE_SearchEmp_BTN.UseVisualStyleBackColor = True
        '
        'DE_NoOfGives_TXT
        '
        Me.DE_NoOfGives_TXT.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DE_NoOfGives_TXT.Location = New System.Drawing.Point(693, 54)
        Me.DE_NoOfGives_TXT.Name = "DE_NoOfGives_TXT"
        Me.DE_NoOfGives_TXT.Size = New System.Drawing.Size(223, 29)
        Me.DE_NoOfGives_TXT.TabIndex = 38
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(8, 37)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(48, 25)
        Me.Label15.TabIndex = 111
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(548, 56)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(93, 25)
        Me.Label20.TabIndex = 119
        '
        'DE_Cancel_BTN
        '
        Me.DE_Cancel_BTN.BackColor = System.Drawing.Color.MistyRose
        Me.DE_Cancel_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DE_Cancel_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DE_Cancel_BTN.Location = New System.Drawing.Point(964, 132)
        Me.DE_Cancel_BTN.Name = "DE_Cancel_BTN"
        Me.DE_Cancel_BTN.Size = New System.Drawing.Size(78, 33)
        Me.DE_Cancel_BTN.TabIndex = 42
        Me.DE_Cancel_BTN.Text = "Cancel"
        Me.DE_Cancel_BTN.UseVisualStyleBackColor = False
        '
        'DE_AmountGive_TXT
        '
        Me.DE_AmountGive_TXT.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DE_AmountGive_TXT.Location = New System.Drawing.Point(693, 87)
        Me.DE_AmountGive_TXT.Name = "DE_AmountGive_TXT"
        Me.DE_AmountGive_TXT.Size = New System.Drawing.Size(223, 29)
        Me.DE_AmountGive_TXT.TabIndex = 39
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(8, 79)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(67, 25)
        Me.Label17.TabIndex = 110
        '
        'DE_Name_TXT
        '
        Me.DE_Name_TXT.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DE_Name_TXT.Location = New System.Drawing.Point(97, 35)
        Me.DE_Name_TXT.Name = "DE_Name_TXT"
        Me.DE_Name_TXT.ReadOnly = True
        Me.DE_Name_TXT.Size = New System.Drawing.Size(319, 33)
        Me.DE_Name_TXT.TabIndex = 109
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(548, 91)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(132, 25)
        Me.Label22.TabIndex = 121
        '
        'DE_Category_Combo
        '
        Me.DE_Category_Combo.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DE_Category_Combo.FormattingEnabled = True
        Me.DE_Category_Combo.Location = New System.Drawing.Point(97, 77)
        Me.DE_Category_Combo.Name = "DE_Category_Combo"
        Me.DE_Category_Combo.Size = New System.Drawing.Size(319, 33)
        Me.DE_Category_Combo.TabIndex = 35
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(8, 118)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(67, 25)
        Me.Label28.TabIndex = 123
        '
        'DE_Schedule_Combo
        '
        Me.DE_Schedule_Combo.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DE_Schedule_Combo.FormattingEnabled = True
        Me.DE_Schedule_Combo.Items.AddRange(New Object() {"OPEN PAYROLL", "CLOSE PAYROLL", "EVERY PAYROLL"})
        Me.DE_Schedule_Combo.Location = New System.Drawing.Point(97, 116)
        Me.DE_Schedule_Combo.Name = "DE_Schedule_Combo"
        Me.DE_Schedule_Combo.Size = New System.Drawing.Size(319, 33)
        Me.DE_Schedule_Combo.TabIndex = 36
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(548, 139)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(73, 25)
        Me.Label31.TabIndex = 124
        '
        'DE_Effectivity_DTP
        '
        Me.DE_Effectivity_DTP.Location = New System.Drawing.Point(693, 137)
        Me.DE_Effectivity_DTP.Name = "DE_Effectivity_DTP"
        Me.DE_Effectivity_DTP.Size = New System.Drawing.Size(223, 20)
        Me.DE_Effectivity_DTP.TabIndex = 40
        Me.DE_Effectivity_DTP.Value = New Date(2021, 9, 15, 0, 0, 0, 0)
        '
        'lblAdd
        '
        Me.lblAdd.AutoSize = True
        Me.lblAdd.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAdd.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lblAdd.Location = New System.Drawing.Point(429, 82)
        Me.lblAdd.Name = "lblAdd"
        Me.lblAdd.Size = New System.Drawing.Size(32, 22)
        Me.lblAdd.TabIndex = 125
        '
        'Context_deduct
        '
        Me.Context_deduct.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menu_subtotal, Me.menu_edit})
        Me.Context_deduct.Name = "Context_deduct"
        Me.Context_deduct.Size = New System.Drawing.Size(147, 48)
        '
        'menu_subtotal
        '
        Me.menu_subtotal.Name = "menu_subtotal"
        Me.menu_subtotal.Size = New System.Drawing.Size(146, 22)
        Me.menu_subtotal.Text = "View Subtotal"
        '
        'menu_edit
        '
        Me.menu_edit.Name = "menu_edit"
        Me.menu_edit.Size = New System.Drawing.Size(146, 22)
        Me.menu_edit.Text = "Edit"
        '
        'frmLoan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1175, 680)
        Me.Controls.Add(Me.Close_LBL)
        Me.Controls.Add(Me.Loans_Tab)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmLoan"
        Me.Text = "frmLoan"
        Me.Loans_Tab.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.Context_deduct.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Close_LBL As Label
    Friend WithEvents Loans_Tab As TabControl
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents GroupBox8 As GroupBox
    Friend WithEvents CatDeduc_list As ListView
    Friend WithEvents ColumnHeader22 As ColumnHeader
    Friend WithEvents CatDeducSave_BTN As Button
    Friend WithEvents Label24 As Label
    Friend WithEvents Deduct_txt As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents ColumnHeader11 As ColumnHeader
    Friend WithEvents ColumnHeader12 As ColumnHeader
    Friend WithEvents ColumnHeader13 As ColumnHeader
    Friend WithEvents ColumnHeader15 As ColumnHeader
    Friend WithEvents ColumnHeader14 As ColumnHeader
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents ColumnHeader16 As ColumnHeader
    Friend WithEvents DE_Save_BTN As Button
    Friend WithEvents DE_Total_TXT As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents DE_SearchEmp_BTN As Button
    Friend WithEvents DE_NoOfGives_TXT As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents DE_Cancel_BTN As Button
    Friend WithEvents DE_AmountGive_TXT As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents DE_Name_TXT As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents DE_Category_Combo As ComboBox
    Friend WithEvents Label28 As Label
    Friend WithEvents DE_Schedule_Combo As ComboBox
    Friend WithEvents Label31 As Label
    Friend WithEvents DE_Effectivity_DTP As DateTimePicker
    Friend WithEvents lblAdd As Label
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Effectiv_dtp As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents Schedule_Combo As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Category_Combo As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Name_txt As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Amount_txt As TextBox
    Friend WithEvents Cancel_btn As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents noOfDeduc_txt As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents Total_txt As TextBox
    Friend WithEvents Save_btn As Button
    Friend WithEvents Search_txt As TextBox
    Friend WithEvents Search_btn As Button
    Friend WithEvents Deduc_list As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents Context_deduct As ContextMenuStrip
    Friend WithEvents menu_subtotal As ToolStripMenuItem
    Friend WithEvents menu_edit As ToolStripMenuItem
End Class
