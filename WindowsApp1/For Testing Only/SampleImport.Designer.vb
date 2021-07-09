<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SampleImport
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
        Me.OpenFile_BTN = New System.Windows.Forms.Button()
        Me.Path_TXT = New System.Windows.Forms.TextBox()
        Me.Import_BTN = New System.Windows.Forms.Button()
        Me.ImportProgress_PB = New System.Windows.Forms.ProgressBar()
        Me.Progress_LBL = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'OpenFile_BTN
        '
        Me.OpenFile_BTN.Location = New System.Drawing.Point(24, 7)
        Me.OpenFile_BTN.Name = "OpenFile_BTN"
        Me.OpenFile_BTN.Size = New System.Drawing.Size(82, 25)
        Me.OpenFile_BTN.TabIndex = 0
        Me.OpenFile_BTN.Text = "Import"
        Me.OpenFile_BTN.UseVisualStyleBackColor = True
        '
        'Path_TXT
        '
        Me.Path_TXT.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Path_TXT.Location = New System.Drawing.Point(24, 38)
        Me.Path_TXT.Name = "Path_TXT"
        Me.Path_TXT.Size = New System.Drawing.Size(427, 24)
        Me.Path_TXT.TabIndex = 1
        '
        'Import_BTN
        '
        Me.Import_BTN.Location = New System.Drawing.Point(175, 68)
        Me.Import_BTN.Name = "Import_BTN"
        Me.Import_BTN.Size = New System.Drawing.Size(82, 23)
        Me.Import_BTN.TabIndex = 2
        Me.Import_BTN.Text = "Go"
        Me.Import_BTN.UseVisualStyleBackColor = True
        '
        'ImportProgress_PB
        '
        Me.ImportProgress_PB.Location = New System.Drawing.Point(24, 127)
        Me.ImportProgress_PB.Name = "ImportProgress_PB"
        Me.ImportProgress_PB.Size = New System.Drawing.Size(427, 23)
        Me.ImportProgress_PB.TabIndex = 3
        '
        'Progress_LBL
        '
        Me.Progress_LBL.AutoEllipsis = True
        Me.Progress_LBL.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Progress_LBL.Location = New System.Drawing.Point(20, 101)
        Me.Progress_LBL.Name = "Progress_LBL"
        Me.Progress_LBL.Size = New System.Drawing.Size(431, 23)
        Me.Progress_LBL.TabIndex = 4
        Me.Progress_LBL.Text = "-"
        '
        'SampleImport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(463, 167)
        Me.Controls.Add(Me.Progress_LBL)
        Me.Controls.Add(Me.ImportProgress_PB)
        Me.Controls.Add(Me.Import_BTN)
        Me.Controls.Add(Me.Path_TXT)
        Me.Controls.Add(Me.OpenFile_BTN)
        Me.Name = "SampleImport"
        Me.Text = "SampleImport"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents OpenFile_BTN As Button
    Friend WithEvents Path_TXT As TextBox
    Friend WithEvents Import_BTN As Button
    Friend WithEvents ImportProgress_PB As ProgressBar
    Friend WithEvents Progress_LBL As Label
End Class
