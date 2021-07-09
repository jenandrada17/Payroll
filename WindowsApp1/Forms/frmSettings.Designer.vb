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
        Me.Close_LBL = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
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
        Me.Special_RB = New System.Windows.Forms.RadioButton()
        Me.Regular_RB = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Date_DTP = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Save_BTN = New System.Windows.Forms.Button()
        Me.Name_TXT = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Context_Remove = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RemoveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.TabControl1.SuspendLayout()
        Me.Holiday_Tab.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Context_Remove.SuspendLayout()
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
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.Holiday_Tab)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Font = New System.Drawing.Font("Dubai", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(10, 33)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1146, 614)
        Me.TabControl1.TabIndex = 76
        '
        'Holiday_Tab
        '
        Me.Holiday_Tab.Controls.Add(Me.GroupBox2)
        Me.Holiday_Tab.Controls.Add(Me.lvHoliday)
        Me.Holiday_Tab.Controls.Add(Me.Special_RB)
        Me.Holiday_Tab.Controls.Add(Me.Regular_RB)
        Me.Holiday_Tab.Controls.Add(Me.GroupBox1)
        Me.Holiday_Tab.Location = New System.Drawing.Point(4, 41)
        Me.Holiday_Tab.Name = "Holiday_Tab"
        Me.Holiday_Tab.Padding = New System.Windows.Forms.Padding(3)
        Me.Holiday_Tab.Size = New System.Drawing.Size(1138, 569)
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
        Me.GroupBox2.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.Label7.Size = New System.Drawing.Size(27, 27)
        Me.Label7.TabIndex = 90
        Me.Label7.Text = "%"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(262, 39)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(27, 27)
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
        Me.lvHoliday.Size = New System.Drawing.Size(650, 530)
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
        'Special_RB
        '
        Me.Special_RB.AutoSize = True
        Me.Special_RB.Font = New System.Drawing.Font("Dubai", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Special_RB.Location = New System.Drawing.Point(362, 18)
        Me.Special_RB.Name = "Special_RB"
        Me.Special_RB.Size = New System.Drawing.Size(87, 36)
        Me.Special_RB.TabIndex = 83
        Me.Special_RB.Text = "Special"
        Me.Special_RB.UseVisualStyleBackColor = True
        '
        'Regular_RB
        '
        Me.Regular_RB.AutoSize = True
        Me.Regular_RB.Checked = True
        Me.Regular_RB.Font = New System.Drawing.Font("Dubai", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Regular_RB.Location = New System.Drawing.Point(214, 18)
        Me.Regular_RB.Name = "Regular_RB"
        Me.Regular_RB.Size = New System.Drawing.Size(92, 36)
        Me.Regular_RB.TabIndex = 82
        Me.Regular_RB.TabStop = True
        Me.Regular_RB.Text = "Regular"
        Me.Regular_RB.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Date_DTP)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Save_BTN)
        Me.GroupBox1.Controls.Add(Me.Name_TXT)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(6, 74)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(458, 200)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Employee"
        '
        'Date_DTP
        '
        Me.Date_DTP.CalendarFont = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Date_DTP.CustomFormat = ""
        Me.Date_DTP.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Date_DTP.Location = New System.Drawing.Point(89, 39)
        Me.Date_DTP.Name = "Date_DTP"
        Me.Date_DTP.Size = New System.Drawing.Size(317, 33)
        Me.Date_DTP.TabIndex = 4
        Me.Date_DTP.Value = New Date(2021, 6, 2, 0, 0, 0, 0)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 91)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 25)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Name"
        '
        'Save_BTN
        '
        Me.Save_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Save_BTN.Location = New System.Drawing.Point(172, 153)
        Me.Save_BTN.Name = "Save_BTN"
        Me.Save_BTN.Size = New System.Drawing.Size(99, 37)
        Me.Save_BTN.TabIndex = 84
        Me.Save_BTN.Text = "Save"
        Me.Save_BTN.UseVisualStyleBackColor = True
        '
        'Name_TXT
        '
        Me.Name_TXT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Name_TXT.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name_TXT.Location = New System.Drawing.Point(89, 91)
        Me.Name_TXT.Name = "Name_TXT"
        Me.Name_TXT.Size = New System.Drawing.Size(317, 33)
        Me.Name_TXT.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 25)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Date"
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
        'Context_Remove
        '
        Me.Context_Remove.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RemoveToolStripMenuItem})
        Me.Context_Remove.Name = "ContextMenuStrip1"
        Me.Context_Remove.Size = New System.Drawing.Size(118, 26)
        '
        'RemoveToolStripMenuItem
        '
        Me.RemoveToolStripMenuItem.Name = "RemoveToolStripMenuItem"
        Me.RemoveToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.RemoveToolStripMenuItem.Text = "Remove"
        '
        'TabPage1
        '
        Me.TabPage1.Location = New System.Drawing.Point(4, 41)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1138, 569)
        Me.TabPage1.TabIndex = 1
        Me.TabPage1.Text = "  Allowances  "
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 41)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(1138, 569)
        Me.TabPage2.TabIndex = 2
        Me.TabPage2.Text = "  Deductions  "
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Location = New System.Drawing.Point(4, 41)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(1138, 569)
        Me.TabPage3.TabIndex = 3
        Me.TabPage3.Text = "  Charges  "
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'TabPage4
        '
        Me.TabPage4.Location = New System.Drawing.Point(4, 41)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(1138, 569)
        Me.TabPage4.TabIndex = 4
        Me.TabPage4.Text = "  Loans  "
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'frmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1169, 665)
        Me.Controls.Add(Me.Close_LBL)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmSettings"
        Me.Text = "frmSettings"
        Me.TabControl1.ResumeLayout(False)
        Me.Holiday_Tab.ResumeLayout(False)
        Me.Holiday_Tab.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Context_Remove.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Close_LBL As Label
    Friend WithEvents TabControl1 As TabControl
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
    Friend WithEvents Context_Remove As ContextMenuStrip
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
End Class
