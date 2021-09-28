<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmEmployee
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
        Me.lvEmployee = New System.Windows.Forms.ListView()
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Close_LBL = New System.Windows.Forms.Label()
        Me.Context_Action = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.View_Context = New System.Windows.Forms.ToolStripMenuItem()
        Me.Modify_Panel = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Rate_TXT = New System.Windows.Forms.TextBox()
        Me.Close_Modify_BTN = New System.Windows.Forms.Button()
        Me.Check_BTN = New System.Windows.Forms.Button()
        Me.Fix_Combo = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Context_Action.SuspendLayout()
        Me.Modify_Panel.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvEmployee
        '
        Me.lvEmployee.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvEmployee.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11, Me.ColumnHeader12, Me.ColumnHeader13})
        Me.lvEmployee.Font = New System.Drawing.Font("Dubai", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvEmployee.FullRowSelect = True
        Me.lvEmployee.GridLines = True
        Me.lvEmployee.HideSelection = False
        Me.lvEmployee.Location = New System.Drawing.Point(22, 109)
        Me.lvEmployee.MultiSelect = False
        Me.lvEmployee.Name = "lvEmployee"
        Me.lvEmployee.Size = New System.Drawing.Size(1135, 544)
        Me.lvEmployee.TabIndex = 69
        Me.lvEmployee.UseCompatibleStateImageBehavior = False
        Me.lvEmployee.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Bio ID"
        Me.ColumnHeader2.Width = 80
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Fullname"
        Me.ColumnHeader3.Width = 350
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Date Started"
        Me.ColumnHeader6.Width = 150
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "No. of Days"
        Me.ColumnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader7.Width = 100
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Contact No."
        Me.ColumnHeader8.Width = 120
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Email Address"
        Me.ColumnHeader9.Width = 250
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Status"
        Me.ColumnHeader10.Width = 120
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Position"
        Me.ColumnHeader11.Width = 150
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Company"
        Me.ColumnHeader12.Width = 150
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "Branch"
        Me.ColumnHeader13.Width = 250
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.Font = New System.Drawing.Font("Dubai", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(417, 50)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(106, 34)
        Me.btnSearch.TabIndex = 68
        Me.btnSearch.Text = "&Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(22, 52)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(389, 31)
        Me.txtSearch.TabIndex = 67
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Dubai", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(182, 36)
        Me.Label1.TabIndex = 65
        Me.Label1.Text = "Employee's Record"
        '
        'Close_LBL
        '
        Me.Close_LBL.AutoSize = True
        Me.Close_LBL.Font = New System.Drawing.Font("Dubai", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Close_LBL.Location = New System.Drawing.Point(1117, -2)
        Me.Close_LBL.Name = "Close_LBL"
        Me.Close_LBL.Size = New System.Drawing.Size(57, 32)
        Me.Close_LBL.TabIndex = 73
        Me.Close_LBL.Text = "Close"
        '
        'Context_Action
        '
        Me.Context_Action.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.View_Context})
        Me.Context_Action.Name = "Context_Action"
        Me.Context_Action.Size = New System.Drawing.Size(142, 26)
        '
        'View_Context
        '
        Me.View_Context.Name = "View_Context"
        Me.View_Context.Size = New System.Drawing.Size(141, 22)
        Me.View_Context.Text = "Go to Details"
        '
        'Modify_Panel
        '
        Me.Modify_Panel.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Modify_Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Modify_Panel.Controls.Add(Me.GroupBox1)
        Me.Modify_Panel.Controls.Add(Me.Close_Modify_BTN)
        Me.Modify_Panel.Controls.Add(Me.Check_BTN)
        Me.Modify_Panel.Controls.Add(Me.Fix_Combo)
        Me.Modify_Panel.Controls.Add(Me.Label4)
        Me.Modify_Panel.Controls.Add(Me.Label3)
        Me.Modify_Panel.Location = New System.Drawing.Point(578, 192)
        Me.Modify_Panel.Name = "Modify_Panel"
        Me.Modify_Panel.Size = New System.Drawing.Size(229, 106)
        Me.Modify_Panel.TabIndex = 74
        Me.Modify_Panel.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Rate_TXT)
        Me.GroupBox1.Location = New System.Drawing.Point(65, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(109, 46)
        Me.GroupBox1.TabIndex = 75
        Me.GroupBox1.TabStop = False
        '
        'Rate_TXT
        '
        Me.Rate_TXT.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rate_TXT.Location = New System.Drawing.Point(3, 7)
        Me.Rate_TXT.Name = "Rate_TXT"
        Me.Rate_TXT.Size = New System.Drawing.Size(103, 35)
        Me.Rate_TXT.TabIndex = 75
        '
        'Close_Modify_BTN
        '
        Me.Close_Modify_BTN.Font = New System.Drawing.Font("Dubai", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Close_Modify_BTN.Location = New System.Drawing.Point(181, 18)
        Me.Close_Modify_BTN.Name = "Close_Modify_BTN"
        Me.Close_Modify_BTN.Size = New System.Drawing.Size(31, 27)
        Me.Close_Modify_BTN.TabIndex = 80
        Me.Close_Modify_BTN.Text = "X"
        Me.Close_Modify_BTN.UseVisualStyleBackColor = True
        '
        'Check_BTN
        '
        Me.Check_BTN.Font = New System.Drawing.Font("Dubai", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_BTN.Location = New System.Drawing.Point(181, 58)
        Me.Check_BTN.Name = "Check_BTN"
        Me.Check_BTN.Size = New System.Drawing.Size(31, 27)
        Me.Check_BTN.TabIndex = 79
        Me.Check_BTN.Text = "√"
        Me.Check_BTN.UseVisualStyleBackColor = True
        '
        'Fix_Combo
        '
        Me.Fix_Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Fix_Combo.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Fix_Combo.FormattingEnabled = True
        Me.Fix_Combo.Items.AddRange(New Object() {"YES", "NO"})
        Me.Fix_Combo.Location = New System.Drawing.Point(69, 58)
        Me.Fix_Combo.Name = "Fix_Combo"
        Me.Fix_Combo.Size = New System.Drawing.Size(103, 33)
        Me.Fix_Combo.TabIndex = 78
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(20, 59)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 27)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Fix"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(17, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 27)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Rate"
        '
        'frmEmployee
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1169, 665)
        Me.Controls.Add(Me.Modify_Panel)
        Me.Controls.Add(Me.Close_LBL)
        Me.Controls.Add(Me.lvEmployee)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmEmployee"
        Me.Text = "frmEmployee"
        Me.Context_Action.ResumeLayout(False)
        Me.Modify_Panel.ResumeLayout(False)
        Me.Modify_Panel.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lvEmployee As ListView
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents ColumnHeader9 As ColumnHeader
    Friend WithEvents btnSearch As Button
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Close_LBL As Label
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader10 As ColumnHeader
    Friend WithEvents ColumnHeader11 As ColumnHeader
    Friend WithEvents ColumnHeader12 As ColumnHeader
    Friend WithEvents ColumnHeader13 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents Context_Action As ContextMenuStrip
    Friend WithEvents View_Context As ToolStripMenuItem
    Friend WithEvents Modify_Panel As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Rate_TXT As TextBox
    Friend WithEvents Check_BTN As Button
    Friend WithEvents Fix_Combo As ComboBox
    Friend WithEvents Close_Modify_BTN As Button
    Friend WithEvents GroupBox1 As GroupBox
End Class
