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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.Manual_Tab = New System.Windows.Forms.TabPage()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.PayDate_DTP = New System.Windows.Forms.DateTimePicker()
        Me.To_DTP = New System.Windows.Forms.DateTimePicker()
        Me.From_DTP = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Biometric_Tab = New System.Windows.Forms.TabPage()
        Me.Close_LBL = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.CheckALL_CheckBox = New System.Windows.Forms.CheckBox()
        Me.Date_DataGrid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AM_In_DataGrid = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.AM_Out_DataGrid = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.PM_IN_DataGrid = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.PM_Out_DataGrid = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Select_Datagrid = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.TabControl1.SuspendLayout()
        Me.Manual_Tab.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Dubai", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 36)
        Me.Label1.TabIndex = 66
        Me.Label1.Text = "Attendance"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.Manual_Tab)
        Me.TabControl1.Controls.Add(Me.Biometric_Tab)
        Me.TabControl1.Font = New System.Drawing.Font("Dubai", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(18, 48)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1146, 614)
        Me.TabControl1.TabIndex = 67
        '
        'Manual_Tab
        '
        Me.Manual_Tab.Controls.Add(Me.GroupBox3)
        Me.Manual_Tab.Controls.Add(Me.TextBox2)
        Me.Manual_Tab.Controls.Add(Me.Button1)
        Me.Manual_Tab.Controls.Add(Me.GroupBox2)
        Me.Manual_Tab.Controls.Add(Me.GroupBox1)
        Me.Manual_Tab.Location = New System.Drawing.Point(4, 41)
        Me.Manual_Tab.Name = "Manual_Tab"
        Me.Manual_Tab.Padding = New System.Windows.Forms.Padding(3)
        Me.Manual_Tab.Size = New System.Drawing.Size(1138, 569)
        Me.Manual_Tab.TabIndex = 0
        Me.Manual_Tab.Text = "Manual Encode"
        Me.Manual_Tab.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(112, 482)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(97, 37)
        Me.Button1.TabIndex = 66
        Me.Button1.Text = "Confirm"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Date_DataGrid, Me.AM_In_DataGrid, Me.AM_Out_DataGrid, Me.PM_IN_DataGrid, Me.PM_Out_DataGrid, Me.Select_Datagrid})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.InactiveCaption
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.Location = New System.Drawing.Point(15, 47)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(742, 510)
        Me.DataGridView1.TabIndex = 65
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.PayDate_DTP)
        Me.GroupBox2.Controls.Add(Me.To_DTP)
        Me.GroupBox2.Controls.Add(Me.From_DTP)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(6, 202)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(262, 252)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Date Covered"
        '
        'PayDate_DTP
        '
        Me.PayDate_DTP.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PayDate_DTP.Location = New System.Drawing.Point(34, 205)
        Me.PayDate_DTP.Name = "PayDate_DTP"
        Me.PayDate_DTP.Size = New System.Drawing.Size(209, 33)
        Me.PayDate_DTP.TabIndex = 8
        '
        'To_DTP
        '
        Me.To_DTP.CustomFormat = "d"
        Me.To_DTP.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.To_DTP.Location = New System.Drawing.Point(34, 130)
        Me.To_DTP.Name = "To_DTP"
        Me.To_DTP.Size = New System.Drawing.Size(209, 33)
        Me.To_DTP.TabIndex = 8
        '
        'From_DTP
        '
        Me.From_DTP.CustomFormat = "d"
        Me.From_DTP.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.From_DTP.Location = New System.Drawing.Point(34, 53)
        Me.From_DTP.Name = "From_DTP"
        Me.From_DTP.Size = New System.Drawing.Size(209, 33)
        Me.From_DTP.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(29, 177)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 25)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Pay Date"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(29, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 25)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "From"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(29, 97)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 25)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "To"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(6, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(262, 168)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Employee"
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(40, 138)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(209, 29)
        Me.TextBox2.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(29, 95)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 25)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Employee Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(29, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 25)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Biometric ID"
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(34, 58)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(209, 29)
        Me.TextBox1.TabIndex = 1
        '
        'Biometric_Tab
        '
        Me.Biometric_Tab.Location = New System.Drawing.Point(4, 41)
        Me.Biometric_Tab.Name = "Biometric_Tab"
        Me.Biometric_Tab.Padding = New System.Windows.Forms.Padding(3)
        Me.Biometric_Tab.Size = New System.Drawing.Size(1138, 548)
        Me.Biometric_Tab.TabIndex = 1
        Me.Biometric_Tab.Text = "Biometric"
        Me.Biometric_Tab.UseVisualStyleBackColor = True
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
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.CheckALL_CheckBox)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.DataGridView1)
        Me.GroupBox3.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(369, -10)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(763, 570)
        Me.GroupBox3.TabIndex = 67
        Me.GroupBox3.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(348, 20)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(36, 27)
        Me.Label7.TabIndex = 66
        Me.Label7.Text = "AM"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(549, 20)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(34, 27)
        Me.Label8.TabIndex = 67
        Me.Label8.Text = "PM"
        '
        'CheckALL_CheckBox
        '
        Me.CheckALL_CheckBox.AutoSize = True
        Me.CheckALL_CheckBox.Location = New System.Drawing.Point(738, 57)
        Me.CheckALL_CheckBox.Name = "CheckALL_CheckBox"
        Me.CheckALL_CheckBox.Size = New System.Drawing.Size(15, 14)
        Me.CheckALL_CheckBox.TabIndex = 68
        Me.CheckALL_CheckBox.UseVisualStyleBackColor = True
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
        'AM_In_DataGrid
        '
        Me.AM_In_DataGrid.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.AM_In_DataGrid.HeaderText = "In"
        Me.AM_In_DataGrid.Name = "AM_In_DataGrid"
        Me.AM_In_DataGrid.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'AM_Out_DataGrid
        '
        Me.AM_Out_DataGrid.HeaderText = "Out"
        Me.AM_Out_DataGrid.Name = "AM_Out_DataGrid"
        Me.AM_Out_DataGrid.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'PM_IN_DataGrid
        '
        Me.PM_IN_DataGrid.HeaderText = "In"
        Me.PM_IN_DataGrid.Name = "PM_IN_DataGrid"
        Me.PM_IN_DataGrid.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'PM_Out_DataGrid
        '
        Me.PM_Out_DataGrid.HeaderText = "Out"
        Me.PM_Out_DataGrid.Name = "PM_Out_DataGrid"
        Me.PM_Out_DataGrid.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'Select_Datagrid
        '
        Me.Select_Datagrid.HeaderText = "Select All"
        Me.Select_Datagrid.Name = "Select_Datagrid"
        Me.Select_Datagrid.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Select_Datagrid.Width = 90
        '
        'frmAttendance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1169, 665)
        Me.Controls.Add(Me.Close_LBL)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmAttendance"
        Me.Text = "frmAttendance"
        Me.TabControl1.ResumeLayout(False)
        Me.Manual_Tab.ResumeLayout(False)
        Me.Manual_Tab.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents Manual_Tab As TabPage
    Friend WithEvents Biometric_Tab As TabPage
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents PayDate_DTP As DateTimePicker
    Friend WithEvents To_DTP As DateTimePicker
    Friend WithEvents From_DTP As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button1 As Button
    Friend WithEvents Close_LBL As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents CheckALL_CheckBox As CheckBox
    Friend WithEvents Date_DataGrid As DataGridViewTextBoxColumn
    Friend WithEvents AM_In_DataGrid As DataGridViewComboBoxColumn
    Friend WithEvents AM_Out_DataGrid As DataGridViewComboBoxColumn
    Friend WithEvents PM_IN_DataGrid As DataGridViewComboBoxColumn
    Friend WithEvents PM_Out_DataGrid As DataGridViewComboBoxColumn
    Friend WithEvents Select_Datagrid As DataGridViewCheckBoxColumn
End Class
