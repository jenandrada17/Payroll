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
        Me.Attendance_Tab = New System.Windows.Forms.TabControl()
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
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Pagibig_grid = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PagChange_BTN = New System.Windows.Forms.Button()
        Me.Attendance_Tab.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.SSS_grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Manual_Tab.SuspendLayout()
        CType(Me.Pagibig_grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Attendance_Tab
        '
        Me.Attendance_Tab.Controls.Add(Me.TabPage1)
        Me.Attendance_Tab.Controls.Add(Me.Manual_Tab)
        Me.Attendance_Tab.Controls.Add(Me.TabPage2)
        Me.Attendance_Tab.Font = New System.Drawing.Font("Dubai", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Attendance_Tab.Location = New System.Drawing.Point(5, 30)
        Me.Attendance_Tab.Name = "Attendance_Tab"
        Me.Attendance_Tab.SelectedIndex = 0
        Me.Attendance_Tab.Size = New System.Drawing.Size(1159, 636)
        Me.Attendance_Tab.TabIndex = 69
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
        Me.SSS_grid.BackgroundColor = System.Drawing.Color.White
        Me.SSS_grid.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.SSS_grid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.SSS_grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.SSS_grid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.SSS_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.SSS_grid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.one, Me.two, Me.three, Me.four, Me.five, Me.six, Me.seven, Me.eight, Me.nine, Me.ten, Me.eleven, Me.twelve, Me.thirteen, Me.fourteen, Me.fifteen, Me.sixteen})
        Me.SSS_grid.Location = New System.Drawing.Point(6, 76)
        Me.SSS_grid.Name = "SSS_grid"
        Me.SSS_grid.ReadOnly = True
        Me.SSS_grid.RowHeadersVisible = False
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SSS_grid.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.SSS_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.SSS_grid.Size = New System.Drawing.Size(1139, 506)
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
        Me.Import_BTN.Location = New System.Drawing.Point(1063, 23)
        Me.Import_BTN.Name = "Import_BTN"
        Me.Import_BTN.Size = New System.Drawing.Size(82, 31)
        Me.Import_BTN.TabIndex = 86
        Me.Import_BTN.Text = "Import"
        Me.Import_BTN.UseVisualStyleBackColor = True
        '
        'Path_TXT
        '
        Me.Path_TXT.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Path_TXT.Location = New System.Drawing.Point(623, 25)
        Me.Path_TXT.Name = "Path_TXT"
        Me.Path_TXT.ReadOnly = True
        Me.Path_TXT.Size = New System.Drawing.Size(350, 29)
        Me.Path_TXT.TabIndex = 85
        '
        'OpenFile_BTN
        '
        Me.OpenFile_BTN.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OpenFile_BTN.Location = New System.Drawing.Point(979, 23)
        Me.OpenFile_BTN.Name = "OpenFile_BTN"
        Me.OpenFile_BTN.Size = New System.Drawing.Size(78, 31)
        Me.OpenFile_BTN.TabIndex = 84
        Me.OpenFile_BTN.Text = "Browse"
        Me.OpenFile_BTN.UseVisualStyleBackColor = True
        '
        'Manual_Tab
        '
        Me.Manual_Tab.Controls.Add(Me.PagChange_BTN)
        Me.Manual_Tab.Controls.Add(Me.Pagibig_grid)
        Me.Manual_Tab.Location = New System.Drawing.Point(4, 41)
        Me.Manual_Tab.Name = "Manual_Tab"
        Me.Manual_Tab.Padding = New System.Windows.Forms.Padding(3)
        Me.Manual_Tab.Size = New System.Drawing.Size(1151, 591)
        Me.Manual_Tab.TabIndex = 0
        Me.Manual_Tab.Text = "  Pagibig  "
        Me.Manual_Tab.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 41)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1151, 591)
        Me.TabPage2.TabIndex = 2
        Me.TabPage2.Text = "  Philhealth  "
        Me.TabPage2.UseVisualStyleBackColor = True
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
        'Pagibig_grid
        '
        Me.Pagibig_grid.AllowUserToDeleteRows = False
        Me.Pagibig_grid.AllowUserToResizeRows = False
        Me.Pagibig_grid.BackgroundColor = System.Drawing.Color.White
        Me.Pagibig_grid.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Pagibig_grid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.Pagibig_grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Pagibig_grid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Pagibig_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Pagibig_grid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4})
        Me.Pagibig_grid.Location = New System.Drawing.Point(17, 40)
        Me.Pagibig_grid.Name = "Pagibig_grid"
        Me.Pagibig_grid.RowHeadersVisible = False
        Me.Pagibig_grid.RowHeadersWidth = 50
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pagibig_grid.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.Pagibig_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Pagibig_grid.Size = New System.Drawing.Size(607, 329)
        Me.Pagibig_grid.TabIndex = 2
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.Frozen = True
        Me.DataGridViewTextBoxColumn1.HeaderText = "Monthly Salary"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 150
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Employees Contrib."
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 150
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Employer's Contrib."
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 150
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Total"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 150
        '
        'PagChange_BTN
        '
        Me.PagChange_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PagChange_BTN.Location = New System.Drawing.Point(682, 40)
        Me.PagChange_BTN.Name = "PagChange_BTN"
        Me.PagChange_BTN.Size = New System.Drawing.Size(93, 44)
        Me.PagChange_BTN.TabIndex = 87
        Me.PagChange_BTN.Text = "Change"
        Me.PagChange_BTN.UseVisualStyleBackColor = True
        '
        'frmContribution
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1169, 665)
        Me.Controls.Add(Me.Attendance_Tab)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmContribution"
        Me.Text = "frmContribution"
        Me.Attendance_Tab.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.SSS_grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Manual_Tab.ResumeLayout(False)
        CType(Me.Pagibig_grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Attendance_Tab As TabControl
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
    Friend WithEvents Pagibig_grid As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents PagChange_BTN As Button
End Class
