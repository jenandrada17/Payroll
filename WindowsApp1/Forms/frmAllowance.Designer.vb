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
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Context_Allow = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Edit_MenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Allowance_Tab.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.Context_Allow.SuspendLayout()
        Me.SuspendLayout()
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
        Me.Form_Tab.Location = New System.Drawing.Point(4, 41)
        Me.Form_Tab.Name = "Form_Tab"
        Me.Form_Tab.Padding = New System.Windows.Forms.Padding(3)
        Me.Form_Tab.Size = New System.Drawing.Size(1151, 591)
        Me.Form_Tab.TabIndex = 0
        Me.Form_Tab.Text = "      Form      "
        Me.Form_Tab.UseVisualStyleBackColor = True
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
        Me.Edit_MenuItem.Size = New System.Drawing.Size(180, 22)
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
        Me.Allowance_Tab.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
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
End Class
