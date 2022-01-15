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
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.Date_DataGrid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Time_In_DataGrid = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Time_Out_DataGrid = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Schedule_DG, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.TabPage1.Location = New System.Drawing.Point(4, 41)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1152, 560)
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
        Me.Cancel_BTN.Location = New System.Drawing.Point(56, 202)
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
        Me.Save_BTN.Location = New System.Drawing.Point(313, 202)
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
        Me.GroupBox1.Location = New System.Drawing.Point(24, 30)
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
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Schedule_DG.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle12
        Me.Schedule_DG.BackgroundColor = System.Drawing.Color.White
        Me.Schedule_DG.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Schedule_DG.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.Schedule_DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Schedule_DG.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Date_DataGrid, Me.Time_In_DataGrid, Me.Time_Out_DataGrid})
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.InactiveCaption
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Schedule_DG.DefaultCellStyle = DataGridViewCellStyle15
        Me.Schedule_DG.Location = New System.Drawing.Point(552, 8)
        Me.Schedule_DG.Name = "Schedule_DG"
        Me.Schedule_DG.RowHeadersVisible = False
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.Transparent
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.Transparent
        Me.Schedule_DG.RowsDefaultCellStyle = DataGridViewCellStyle16
        Me.Schedule_DG.Size = New System.Drawing.Size(594, 557)
        Me.Schedule_DG.TabIndex = 87
        '
        'Date_DataGrid
        '
        DataGridViewCellStyle13.NullValue = Nothing
        Me.Date_DataGrid.DefaultCellStyle = DataGridViewCellStyle13
        Me.Date_DataGrid.HeaderText = "Date"
        Me.Date_DataGrid.Name = "Date_DataGrid"
        Me.Date_DataGrid.ReadOnly = True
        Me.Date_DataGrid.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Date_DataGrid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Date_DataGrid.Width = 350
        '
        'Time_In_DataGrid
        '
        DataGridViewCellStyle14.Format = "t"
        DataGridViewCellStyle14.NullValue = Nothing
        Me.Time_In_DataGrid.DefaultCellStyle = DataGridViewCellStyle14
        Me.Time_In_DataGrid.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.Time_In_DataGrid.HeaderText = "Time in"
        Me.Time_In_DataGrid.Name = "Time_In_DataGrid"
        Me.Time_In_DataGrid.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Time_In_DataGrid.Width = 120
        '
        'Time_Out_DataGrid
        '
        Me.Time_Out_DataGrid.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.Time_Out_DataGrid.HeaderText = "Time Out"
        Me.Time_Out_DataGrid.Name = "Time_Out_DataGrid"
        Me.Time_Out_DataGrid.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Time_Out_DataGrid.Width = 120
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
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.Schedule_DG, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents Date_DataGrid As DataGridViewTextBoxColumn
    Friend WithEvents Time_In_DataGrid As DataGridViewComboBoxColumn
    Friend WithEvents Time_Out_DataGrid As DataGridViewComboBoxColumn
End Class
