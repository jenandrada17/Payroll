<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmContribution
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Contribution_Tab = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.SSS_grid = New System.Windows.Forms.DataGridView()
        Me.one = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.two = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.three = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.four = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.five = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.six = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.seven = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.eight = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nine = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ten = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.eleven = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.twelve = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.thirteen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fourteen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fifteen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sixteen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Import_BTN = New System.Windows.Forms.Button()
        Me.Path_TXT = New System.Windows.Forms.TextBox()
        Me.OpenFile_BTN = New System.Windows.Forms.Button()
        Me.Manual_Tab = New System.Windows.Forms.TabPage()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.HMDF_ER_TXT = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.HMDF_EE_TXT = New System.Windows.Forms.TextBox()
        Me.PagChange_BTN = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PhilH_Rate_TXT = New System.Windows.Forms.TextBox()
        Me.PhilH_Save_BTN = New System.Windows.Forms.Button()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.WH_Change_BTN = New System.Windows.Forms.Button()
        Me.WH_grid = New System.Windows.Forms.DataGridView()
        Me.range_dgv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.wh_dgv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Close_LBL = New System.Windows.Forms.Label()
        Me.Contribution_Tab.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.SSS_grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Manual_Tab.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.WH_grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Contribution_Tab
        '
        Me.Contribution_Tab.Controls.Add(Me.TabPage1)
        Me.Contribution_Tab.Controls.Add(Me.Manual_Tab)
        Me.Contribution_Tab.Controls.Add(Me.TabPage2)
        Me.Contribution_Tab.Controls.Add(Me.TabPage3)
        Me.Contribution_Tab.Font = New System.Drawing.Font("Dubai", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Contribution_Tab.Location = New System.Drawing.Point(5, 30)
        Me.Contribution_Tab.Name = "Contribution_Tab"
        Me.Contribution_Tab.SelectedIndex = 0
        Me.Contribution_Tab.Size = New System.Drawing.Size(1159, 636)
        Me.Contribution_Tab.TabIndex = 69
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.SSS_grid)
        Me.TabPage1.Controls.Add(Me.Import_BTN)
        Me.TabPage1.Controls.Add(Me.Path_TXT)
        Me.TabPage1.Controls.Add(Me.OpenFile_BTN)
        Me.TabPage1.Location = New System.Drawing.Point(4, 41)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1151, 591)
        Me.TabPage1.TabIndex = 1
        Me.TabPage1.Text = "  SSS  "
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'SSS_grid
        '
        Me.SSS_grid.AllowUserToAddRows = False
        Me.SSS_grid.AllowUserToDeleteRows = False
        Me.SSS_grid.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue
        Me.SSS_grid.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.SSS_grid.BackgroundColor = System.Drawing.Color.White
        Me.SSS_grid.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.SSS_grid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.SSS_grid.ColumnHeadersHeight = 33
        Me.SSS_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.SSS_grid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.one, Me.two, Me.three, Me.four, Me.five, Me.six, Me.seven, Me.eight, Me.nine, Me.ten, Me.eleven, Me.twelve, Me.thirteen, Me.fourteen, Me.fifteen, Me.sixteen})
        Me.SSS_grid.Location = New System.Drawing.Point(6, 40)
        Me.SSS_grid.Name = "SSS_grid"
        Me.SSS_grid.ReadOnly = True
        Me.SSS_grid.RowHeadersVisible = False
        Me.SSS_grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SSS_grid.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.SSS_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.SSS_grid.Size = New System.Drawing.Size(1139, 542)
        Me.SSS_grid.TabIndex = 1
        '
        'one
        '
        Me.one.Frozen = True
        Me.one.HeaderText = "Range of Comp."
        Me.one.Name = "one"
        Me.one.ReadOnly = True
        Me.one.Width = 150
        '
        'two
        '
        Me.two.HeaderText = "RSS/EC"
        Me.two.Name = "two"
        Me.two.ReadOnly = True
        '
        'three
        '
        Me.three.HeaderText = "MPF"
        Me.three.Name = "three"
        Me.three.ReadOnly = True
        '
        'four
        '
        Me.four.HeaderText = "Total"
        Me.four.Name = "four"
        Me.four.ReadOnly = True
        '
        'five
        '
        Me.five.HeaderText = "RSS - ER"
        Me.five.Name = "five"
        Me.five.ReadOnly = True
        '
        'six
        '
        Me.six.HeaderText = "RSS - EE"
        Me.six.Name = "six"
        Me.six.ReadOnly = True
        '
        'seven
        '
        Me.seven.HeaderText = "RSS - Total"
        Me.seven.Name = "seven"
        Me.seven.ReadOnly = True
        '
        'eight
        '
        Me.eight.HeaderText = "EC - ER"
        Me.eight.Name = "eight"
        Me.eight.ReadOnly = True
        '
        'nine
        '
        Me.nine.HeaderText = "EC - EE"
        Me.nine.Name = "nine"
        Me.nine.ReadOnly = True
        '
        'ten
        '
        Me.ten.HeaderText = "EC - Total"
        Me.ten.Name = "ten"
        Me.ten.ReadOnly = True
        '
        'eleven
        '
        Me.eleven.HeaderText = "MPF - ER"
        Me.eleven.Name = "eleven"
        Me.eleven.ReadOnly = True
        '
        'twelve
        '
        Me.twelve.HeaderText = "MPF - EE"
        Me.twelve.Name = "twelve"
        Me.twelve.ReadOnly = True
        '
        'thirteen
        '
        Me.thirteen.HeaderText = "MPF - Total"
        Me.thirteen.Name = "thirteen"
        Me.thirteen.ReadOnly = True
        '
        'fourteen
        '
        Me.fourteen.HeaderText = "EE"
        Me.fourteen.Name = "fourteen"
        Me.fourteen.ReadOnly = True
        '
        'fifteen
        '
        Me.fifteen.HeaderText = "ER"
        Me.fifteen.Name = "fifteen"
        Me.fifteen.ReadOnly = True
        '
        'sixteen
        '
        Me.sixteen.HeaderText = "TOTAL"
        Me.sixteen.Name = "sixteen"
        Me.sixteen.ReadOnly = True
        '
        'Import_BTN
        '
        Me.Import_BTN.Enabled = False
        Me.Import_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Import_BTN.Location = New System.Drawing.Point(1063, 3)
        Me.Import_BTN.Name = "Import_BTN"
        Me.Import_BTN.Size = New System.Drawing.Size(82, 31)
        Me.Import_BTN.TabIndex = 86
        Me.Import_BTN.Text = "Import"
        Me.Import_BTN.UseVisualStyleBackColor = True
        '
        'Path_TXT
        '
        Me.Path_TXT.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Path_TXT.Location = New System.Drawing.Point(623, 5)
        Me.Path_TXT.Name = "Path_TXT"
        Me.Path_TXT.ReadOnly = True
        Me.Path_TXT.Size = New System.Drawing.Size(350, 29)
        Me.Path_TXT.TabIndex = 85
        '
        'OpenFile_BTN
        '
        Me.OpenFile_BTN.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OpenFile_BTN.Location = New System.Drawing.Point(979, 3)
        Me.OpenFile_BTN.Name = "OpenFile_BTN"
        Me.OpenFile_BTN.Size = New System.Drawing.Size(78, 31)
        Me.OpenFile_BTN.TabIndex = 84
        Me.OpenFile_BTN.Text = "Browse"
        Me.OpenFile_BTN.UseVisualStyleBackColor = True
        '
        'Manual_Tab
        '
        Me.Manual_Tab.Controls.Add(Me.Label3)
        Me.Manual_Tab.Controls.Add(Me.HMDF_ER_TXT)
        Me.Manual_Tab.Controls.Add(Me.Label2)
        Me.Manual_Tab.Controls.Add(Me.HMDF_EE_TXT)
        Me.Manual_Tab.Controls.Add(Me.PagChange_BTN)
        Me.Manual_Tab.Location = New System.Drawing.Point(4, 41)
        Me.Manual_Tab.Name = "Manual_Tab"
        Me.Manual_Tab.Padding = New System.Windows.Forms.Padding(3)
        Me.Manual_Tab.Size = New System.Drawing.Size(1151, 591)
        Me.Manual_Tab.TabIndex = 0
        Me.Manual_Tab.Text = "  HDMF  "
        Me.Manual_Tab.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 112)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 32)
        Me.Label3.TabIndex = 91
        Me.Label3.Text = "Employer"
        '
        'HMDF_ER_TXT
        '
        Me.HMDF_ER_TXT.Location = New System.Drawing.Point(143, 109)
        Me.HMDF_ER_TXT.Name = "HMDF_ER_TXT"
        Me.HMDF_ER_TXT.ReadOnly = True
        Me.HMDF_ER_TXT.Size = New System.Drawing.Size(179, 40)
        Me.HMDF_ER_TXT.TabIndex = 90
        Me.HMDF_ER_TXT.Text = "100"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 32)
        Me.Label2.TabIndex = 89
        Me.Label2.Text = "Employee"
        '
        'HMDF_EE_TXT
        '
        Me.HMDF_EE_TXT.Location = New System.Drawing.Point(143, 46)
        Me.HMDF_EE_TXT.Name = "HMDF_EE_TXT"
        Me.HMDF_EE_TXT.ReadOnly = True
        Me.HMDF_EE_TXT.Size = New System.Drawing.Size(179, 40)
        Me.HMDF_EE_TXT.TabIndex = 88
        Me.HMDF_EE_TXT.Text = "100"
        '
        'PagChange_BTN
        '
        Me.PagChange_BTN.BackColor = System.Drawing.Color.DarkSalmon
        Me.PagChange_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.PagChange_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PagChange_BTN.Location = New System.Drawing.Point(183, 174)
        Me.PagChange_BTN.Name = "PagChange_BTN"
        Me.PagChange_BTN.Size = New System.Drawing.Size(93, 44)
        Me.PagChange_BTN.TabIndex = 87
        Me.PagChange_BTN.Text = "Change"
        Me.PagChange_BTN.UseVisualStyleBackColor = False
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.PhilH_Rate_TXT)
        Me.TabPage2.Controls.Add(Me.PhilH_Save_BTN)
        Me.TabPage2.Location = New System.Drawing.Point(4, 41)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1151, 591)
        Me.TabPage2.TabIndex = 2
        Me.TabPage2.Text = "  Philhealth  "
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(301, 47)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 32)
        Me.Label5.TabIndex = 95
        Me.Label5.Text = "%"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(126, 32)
        Me.Label4.TabIndex = 94
        Me.Label4.Text = "Premium Rate"
        '
        'PhilH_Rate_TXT
        '
        Me.PhilH_Rate_TXT.Location = New System.Drawing.Point(160, 41)
        Me.PhilH_Rate_TXT.Name = "PhilH_Rate_TXT"
        Me.PhilH_Rate_TXT.ReadOnly = True
        Me.PhilH_Rate_TXT.Size = New System.Drawing.Size(135, 40)
        Me.PhilH_Rate_TXT.TabIndex = 93
        '
        'PhilH_Save_BTN
        '
        Me.PhilH_Save_BTN.BackColor = System.Drawing.Color.DarkSalmon
        Me.PhilH_Save_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.PhilH_Save_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PhilH_Save_BTN.Location = New System.Drawing.Point(175, 107)
        Me.PhilH_Save_BTN.Name = "PhilH_Save_BTN"
        Me.PhilH_Save_BTN.Size = New System.Drawing.Size(105, 38)
        Me.PhilH_Save_BTN.TabIndex = 92
        Me.PhilH_Save_BTN.Text = "Change"
        Me.PhilH_Save_BTN.UseVisualStyleBackColor = False
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Label6)
        Me.TabPage3.Controls.Add(Me.WH_Change_BTN)
        Me.TabPage3.Controls.Add(Me.WH_grid)
        Me.TabPage3.Location = New System.Drawing.Point(4, 41)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(1151, 591)
        Me.TabPage3.TabIndex = 3
        Me.TabPage3.Text = "  W/Holding Tax  "
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Dubai", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 6)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 32)
        Me.Label6.TabIndex = 94
        Me.Label6.Text = "Monthly"
        '
        'WH_Change_BTN
        '
        Me.WH_Change_BTN.BackColor = System.Drawing.Color.DarkSalmon
        Me.WH_Change_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.WH_Change_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WH_Change_BTN.Location = New System.Drawing.Point(528, 46)
        Me.WH_Change_BTN.Name = "WH_Change_BTN"
        Me.WH_Change_BTN.Size = New System.Drawing.Size(116, 33)
        Me.WH_Change_BTN.TabIndex = 93
        Me.WH_Change_BTN.Text = "Change"
        Me.WH_Change_BTN.UseVisualStyleBackColor = False
        '
        'WH_grid
        '
        Me.WH_grid.AllowUserToAddRows = False
        Me.WH_grid.AllowUserToDeleteRows = False
        Me.WH_grid.AllowUserToResizeRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.LightBlue
        Me.WH_grid.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.WH_grid.BackgroundColor = System.Drawing.Color.White
        Me.WH_grid.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.WH_grid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.WH_grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Dubai", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.WH_grid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.WH_grid.ColumnHeadersHeight = 41
        Me.WH_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.WH_grid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.range_dgv, Me.wh_dgv})
        Me.WH_grid.Location = New System.Drawing.Point(6, 42)
        Me.WH_grid.Name = "WH_grid"
        Me.WH_grid.ReadOnly = True
        Me.WH_grid.RowHeadersVisible = False
        Me.WH_grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WH_grid.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.WH_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.WH_grid.Size = New System.Drawing.Size(506, 524)
        Me.WH_grid.TabIndex = 2
        '
        'range_dgv
        '
        Me.range_dgv.Frozen = True
        Me.range_dgv.HeaderText = "Compensation Range"
        Me.range_dgv.Name = "range_dgv"
        Me.range_dgv.ReadOnly = True
        Me.range_dgv.Width = 250
        '
        'wh_dgv
        '
        Me.wh_dgv.HeaderText = "Prescribe Withholding tax"
        Me.wh_dgv.Name = "wh_dgv"
        Me.wh_dgv.ReadOnly = True
        Me.wh_dgv.Width = 250
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Dubai", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(4, -2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(127, 36)
        Me.Label1.TabIndex = 68
        Me.Label1.Text = "Contribution"
        '
        'Close_LBL
        '
        Me.Close_LBL.AutoSize = True
        Me.Close_LBL.Font = New System.Drawing.Font("Dubai", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Close_LBL.Location = New System.Drawing.Point(1119, -6)
        Me.Close_LBL.Name = "Close_LBL"
        Me.Close_LBL.Size = New System.Drawing.Size(56, 32)
        Me.Close_LBL.TabIndex = 76
        Me.Close_LBL.Text = "Close"
        '
        'frmContribution
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1169, 665)
        Me.Controls.Add(Me.Close_LBL)
        Me.Controls.Add(Me.Contribution_Tab)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmContribution"
        Me.Text = "frmContribution"
        Me.Contribution_Tab.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.SSS_grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Manual_Tab.ResumeLayout(False)
        Me.Manual_Tab.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.WH_grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Contribution_Tab As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents Manual_Tab As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Label1 As Label
    Friend WithEvents SSS_grid As DataGridView
    Friend WithEvents Import_BTN As Button
    Friend WithEvents Path_TXT As TextBox
    Friend WithEvents OpenFile_BTN As Button
    Friend WithEvents one As DataGridViewTextBoxColumn
    Friend WithEvents two As DataGridViewTextBoxColumn
    Friend WithEvents three As DataGridViewTextBoxColumn
    Friend WithEvents four As DataGridViewTextBoxColumn
    Friend WithEvents five As DataGridViewTextBoxColumn
    Friend WithEvents six As DataGridViewTextBoxColumn
    Friend WithEvents seven As DataGridViewTextBoxColumn
    Friend WithEvents eight As DataGridViewTextBoxColumn
    Friend WithEvents nine As DataGridViewTextBoxColumn
    Friend WithEvents ten As DataGridViewTextBoxColumn
    Friend WithEvents eleven As DataGridViewTextBoxColumn
    Friend WithEvents twelve As DataGridViewTextBoxColumn
    Friend WithEvents thirteen As DataGridViewTextBoxColumn
    Friend WithEvents fourteen As DataGridViewTextBoxColumn
    Friend WithEvents fifteen As DataGridViewTextBoxColumn
    Friend WithEvents sixteen As DataGridViewTextBoxColumn
    Friend WithEvents PagChange_BTN As Button
    Friend WithEvents HMDF_EE_TXT As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents HMDF_ER_TXT As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents PhilH_Rate_TXT As TextBox
    Friend WithEvents PhilH_Save_BTN As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents WH_Change_BTN As Button
    Friend WithEvents WH_grid As DataGridView
    Friend WithEvents range_dgv As DataGridViewTextBoxColumn
    Friend WithEvents wh_dgv As DataGridViewTextBoxColumn
    Friend WithEvents Label6 As Label
    Friend WithEvents Close_LBL As Label
End Class
