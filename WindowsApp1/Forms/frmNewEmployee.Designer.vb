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
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Import_BTN = New System.Windows.Forms.Button()
        Me.Close_LBL = New System.Windows.Forms.Label()
        Me.Excel_Panel = New System.Windows.Forms.Panel()
        Me.Label75 = New System.Windows.Forms.Label()
        Me.Label76 = New System.Windows.Forms.Label()
        Me.Path_TXT = New System.Windows.Forms.TextBox()
        Me.Browse_BTN = New System.Windows.Forms.Button()
        Me.Save_BTN = New System.Windows.Forms.Button()
        Me.Add_BTN = New System.Windows.Forms.Button()
        Me.Company_ComboB = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Excel_Panel.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvEmployee
        '
        Me.lvEmployee.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvEmployee.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8})
        Me.lvEmployee.Font = New System.Drawing.Font("Dubai", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.ColumnHeader2.Width = 100
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Branch Code"
        Me.ColumnHeader3.Width = 130
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Employee's Name"
        Me.ColumnHeader6.Width = 450
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Bio No."
        Me.ColumnHeader7.Width = 130
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Email Address"
        Me.ColumnHeader8.Width = 300
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
        Me.Excel_Panel.Location = New System.Drawing.Point(206, 224)
        Me.Excel_Panel.Name = "Excel_Panel"
        Me.Excel_Panel.Size = New System.Drawing.Size(756, 78)
        Me.Excel_Panel.TabIndex = 93
        Me.Excel_Panel.Visible = False
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
        Me.Add_BTN.Location = New System.Drawing.Point(949, 50)
        Me.Add_BTN.Name = "Add_BTN"
        Me.Add_BTN.Size = New System.Drawing.Size(95, 34)
        Me.Add_BTN.TabIndex = 94
        Me.Add_BTN.Text = "Add"
        Me.Add_BTN.UseVisualStyleBackColor = True
        '
        'Company_ComboB
        '
        Me.Company_ComboB.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Company_ComboB.FormattingEnabled = True
        Me.Company_ComboB.Items.AddRange(New Object() {"PHOTO", "PERFECOM", "DALTON", "HEAD OFFICE", "P&G UY"})
        Me.Company_ComboB.Location = New System.Drawing.Point(20, 28)
        Me.Company_ComboB.Name = "Company_ComboB"
        Me.Company_ComboB.Size = New System.Drawing.Size(161, 28)
        Me.Company_ComboB.TabIndex = 84
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
        'frmNewEmployee
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1169, 665)
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
End Class
