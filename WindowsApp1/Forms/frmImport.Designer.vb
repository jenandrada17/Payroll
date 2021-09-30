<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImport
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
        Me.Excel_Panel = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Company_ComboB = New System.Windows.Forms.ComboBox()
        Me.Label75 = New System.Windows.Forms.Label()
        Me.Label76 = New System.Windows.Forms.Label()
        Me.Path_TXT = New System.Windows.Forms.TextBox()
        Me.Browse_BTN = New System.Windows.Forms.Button()
        Me.Save_BTN = New System.Windows.Forms.Button()
        Me.Excel_Panel.SuspendLayout()
        Me.SuspendLayout()
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
        Me.Excel_Panel.Location = New System.Drawing.Point(25, 31)
        Me.Excel_Panel.Name = "Excel_Panel"
        Me.Excel_Panel.Size = New System.Drawing.Size(756, 78)
        Me.Excel_Panel.TabIndex = 94
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
        'frmImport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1169, 665)
        Me.Controls.Add(Me.Excel_Panel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmImport"
        Me.Text = "frmImport"
        Me.Excel_Panel.ResumeLayout(False)
        Me.Excel_Panel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Excel_Panel As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Company_ComboB As ComboBox
    Friend WithEvents Label75 As Label
    Friend WithEvents Label76 As Label
    Friend WithEvents Path_TXT As TextBox
    Friend WithEvents Browse_BTN As Button
    Friend WithEvents Save_BTN As Button
End Class
