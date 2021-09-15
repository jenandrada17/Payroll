<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPayout
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
        Dim DataGridViewCellStyle64 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle67 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle68 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle65 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle66 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle70 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle69 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle72 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle71 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Select_BTN = New System.Windows.Forms.Button()
        Me.Rate_TXT = New System.Windows.Forms.TextBox()
        Me.Name_TXT = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.BiometricID_TXT = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TotalHours_LBL = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.UnderTime_TXT = New System.Windows.Forms.TextBox()
        Me.Late_TXT = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.RegularHol_TXT = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.RegularOT_TXT = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SpecialHol_TXT = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.NoOfDays_TXT = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.NetPay_LBL = New System.Windows.Forms.Label()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.Deduction_LBL = New System.Windows.Forms.Label()
        Me.PagibigLoan_LBL = New System.Windows.Forms.Label()
        Me.SSSLoan_LBL = New System.Windows.Forms.Label()
        Me.Allowances_LBL = New System.Windows.Forms.Label()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.Tax_Wheld_LBL = New System.Windows.Forms.Label()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.Philhealth_LBL = New System.Windows.Forms.Label()
        Me.HDMF_LBL = New System.Windows.Forms.Label()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.SSSComp_LBL = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.TotalLateUnder_LBL = New System.Windows.Forms.Label()
        Me.TotalHol_LBL = New System.Windows.Forms.Label()
        Me.TotalOT_LBL = New System.Windows.Forms.Label()
        Me.TotalBasic_LBL = New System.Windows.Forms.Label()
        Me.NetTax_LBL = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.GrossAmount_LBL = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Close_LBL = New System.Windows.Forms.Label()
        Me.Cancel_BTN = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Pay_Refresh_BTN = New System.Windows.Forms.Button()
        Me.Payout_grid = New System.Windows.Forms.DataGridView()
        Me.Name_dgv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.basic_dgv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.overtime_dgv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.late_dgv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gross_dgv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sssDis_dgv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PagibigDis_dgv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.philH_dgv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.taxable_dgv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.taxWH_dgv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.netTax_dgv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sssLoan_dgv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pagibigLoan_dgv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.allowance_dgv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.deduction_dgv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.netPay_dgv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.ER_SSS = New System.Windows.Forms.Label()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.P_TaxWH_LBL = New System.Windows.Forms.Label()
        Me.P_NetPay_LBL = New System.Windows.Forms.Label()
        Me.P_PagibigLoan_LBL = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.P_GrossAmount_LBL = New System.Windows.Forms.Label()
        Me.P_PhilHComp_LBL = New System.Windows.Forms.Label()
        Me.P_PagibigComp_LBL = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.P_Allowance_LBL = New System.Windows.Forms.Label()
        Me.P_Deduction_LBL = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.P_SSSLoan_LBL = New System.Windows.Forms.Label()
        Me.P_SSSComp_LBL = New System.Windows.Forms.Label()
        Me.labelee = New System.Windows.Forms.Label()
        Me.labell = New System.Windows.Forms.Label()
        Me.Paydate_ComboB = New System.Windows.Forms.ComboBox()
        Me.Search_TXT = New System.Windows.Forms.TextBox()
        Me.Search_BTN = New System.Windows.Forms.Button()
        Me.Payout_list = New System.Windows.Forms.ListView()
        Me.ColumnHeader18 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Allowance_grid = New System.Windows.Forms.DataGridView()
        Me.grid_1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grid_2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Deduction_grid = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Deduc_BTN = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Previous_groupB = New System.Windows.Forms.GroupBox()
        Me.Prev_lbl = New System.Windows.Forms.Label()
        Me.Prev_Amount_lbl = New System.Windows.Forms.Label()
        Me.Details_Save_BTN = New System.Windows.Forms.Button()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Branch_group = New System.Windows.Forms.GroupBox()
        Me.Branch_ComboB = New System.Windows.Forms.ComboBox()
        Me.Employee_GroupB = New System.Windows.Forms.GroupBox()
        Me.Preview_BTN = New System.Windows.Forms.Button()
        Me.Email_TXT = New System.Windows.Forms.TextBox()
        Me.Employee_TXT = New System.Windows.Forms.TextBox()
        Me.EmpSelect_BTN = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.BodyText_RichB = New System.Windows.Forms.RichTextBox()
        Me.Send_BTN = New System.Windows.Forms.Button()
        Me.ReportViewer_payslip = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.Employee_RadioB = New System.Windows.Forms.RadioButton()
        Me.Branch_RadioB = New System.Windows.Forms.RadioButton()
        Me.All_RadioB = New System.Windows.Forms.RadioButton()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Payslip_paydate_Combo = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.Payout_grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        CType(Me.Allowance_grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Deduction_grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Previous_groupB.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.Branch_group.SuspendLayout()
        Me.Employee_GroupB.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Label15)
        Me.GroupBox6.Controls.Add(Me.Select_BTN)
        Me.GroupBox6.Controls.Add(Me.Rate_TXT)
        Me.GroupBox6.Controls.Add(Me.Name_TXT)
        Me.GroupBox6.Controls.Add(Me.Label17)
        Me.GroupBox6.Controls.Add(Me.BiometricID_TXT)
        Me.GroupBox6.Controls.Add(Me.Label16)
        Me.GroupBox6.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.Location = New System.Drawing.Point(6, 10)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(417, 141)
        Me.GroupBox6.TabIndex = 2
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Employee"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(33, 93)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(40, 25)
        Me.Label15.TabIndex = 10
        Me.Label15.Text = "Rate"
        '
        'Select_BTN
        '
        Me.Select_BTN.AutoSize = True
        Me.Select_BTN.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Select_BTN.Location = New System.Drawing.Point(370, 55)
        Me.Select_BTN.Name = "Select_BTN"
        Me.Select_BTN.Size = New System.Drawing.Size(34, 30)
        Me.Select_BTN.TabIndex = 69
        Me.Select_BTN.Text = "..."
        Me.Select_BTN.UseVisualStyleBackColor = True
        '
        'Rate_TXT
        '
        Me.Rate_TXT.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rate_TXT.Location = New System.Drawing.Point(156, 89)
        Me.Rate_TXT.Name = "Rate_TXT"
        Me.Rate_TXT.ReadOnly = True
        Me.Rate_TXT.Size = New System.Drawing.Size(208, 29)
        Me.Rate_TXT.TabIndex = 18
        '
        'Name_TXT
        '
        Me.Name_TXT.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name_TXT.Location = New System.Drawing.Point(156, 55)
        Me.Name_TXT.Name = "Name_TXT"
        Me.Name_TXT.ReadOnly = True
        Me.Name_TXT.Size = New System.Drawing.Size(208, 29)
        Me.Name_TXT.TabIndex = 17
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(33, 25)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(88, 25)
        Me.Label17.TabIndex = 8
        Me.Label17.Text = "Biometric ID"
        '
        'BiometricID_TXT
        '
        Me.BiometricID_TXT.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BiometricID_TXT.Location = New System.Drawing.Point(156, 21)
        Me.BiometricID_TXT.Name = "BiometricID_TXT"
        Me.BiometricID_TXT.Size = New System.Drawing.Size(208, 29)
        Me.BiometricID_TXT.TabIndex = 16
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(33, 60)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(48, 25)
        Me.Label16.TabIndex = 9
        Me.Label16.Text = "Name"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label34)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.TotalHours_LBL)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.UnderTime_TXT)
        Me.GroupBox1.Controls.Add(Me.Late_TXT)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.RegularHol_TXT)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.RegularOT_TXT)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.SpecialHol_TXT)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.NoOfDays_TXT)
        Me.GroupBox1.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(443, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(323, 266)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Input"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Dubai", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(261, 208)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 21)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "hh:mm"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Dubai", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(261, 175)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 21)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "hh:mm"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Dubai", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(260, 104)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(38, 21)
        Me.Label34.TabIndex = 32
        Me.Label34.Text = "day/s"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Dubai", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(260, 67)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(38, 21)
        Me.Label9.TabIndex = 31
        Me.Label9.Text = "day/s"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Dubai", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(260, 140)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 21)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "hh:mm"
        '
        'TotalHours_LBL
        '
        Me.TotalHours_LBL.AutoSize = True
        Me.TotalHours_LBL.Font = New System.Drawing.Font("Dubai", 8.999999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalHours_LBL.Location = New System.Drawing.Point(260, 33)
        Me.TotalHours_LBL.Name = "TotalHours_LBL"
        Me.TotalHours_LBL.Size = New System.Drawing.Size(38, 21)
        Me.TotalHours_LBL.TabIndex = 29
        Me.TotalHours_LBL.Text = "day/s"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(24, 211)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(85, 25)
        Me.Label11.TabIndex = 26
        Me.Label11.Text = "Under Time"
        '
        'UnderTime_TXT
        '
        Me.UnderTime_TXT.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UnderTime_TXT.Location = New System.Drawing.Point(147, 207)
        Me.UnderTime_TXT.Name = "UnderTime_TXT"
        Me.UnderTime_TXT.ReadOnly = True
        Me.UnderTime_TXT.Size = New System.Drawing.Size(108, 29)
        Me.UnderTime_TXT.TabIndex = 28
        '
        'Late_TXT
        '
        Me.Late_TXT.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Late_TXT.Location = New System.Drawing.Point(147, 171)
        Me.Late_TXT.Name = "Late_TXT"
        Me.Late_TXT.ReadOnly = True
        Me.Late_TXT.Size = New System.Drawing.Size(108, 29)
        Me.Late_TXT.TabIndex = 27
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(24, 178)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(39, 25)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "Late"
        '
        'RegularHol_TXT
        '
        Me.RegularHol_TXT.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RegularHol_TXT.Location = New System.Drawing.Point(147, 100)
        Me.RegularHol_TXT.Name = "RegularHol_TXT"
        Me.RegularHol_TXT.ReadOnly = True
        Me.RegularHol_TXT.Size = New System.Drawing.Size(108, 29)
        Me.RegularHol_TXT.TabIndex = 23
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(24, 105)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(109, 25)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "Regular Holiday"
        '
        'RegularOT_TXT
        '
        Me.RegularOT_TXT.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RegularOT_TXT.Location = New System.Drawing.Point(147, 136)
        Me.RegularOT_TXT.Name = "RegularOT_TXT"
        Me.RegularOT_TXT.ReadOnly = True
        Me.RegularOT_TXT.Size = New System.Drawing.Size(108, 29)
        Me.RegularOT_TXT.TabIndex = 17
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(24, 141)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 25)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Overtime"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(24, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(105, 25)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Special Holiday"
        '
        'SpecialHol_TXT
        '
        Me.SpecialHol_TXT.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SpecialHol_TXT.Location = New System.Drawing.Point(147, 65)
        Me.SpecialHol_TXT.Name = "SpecialHol_TXT"
        Me.SpecialHol_TXT.ReadOnly = True
        Me.SpecialHol_TXT.Size = New System.Drawing.Size(108, 29)
        Me.SpecialHol_TXT.TabIndex = 18
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(24, 33)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 25)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "No. of Days"
        '
        'NoOfDays_TXT
        '
        Me.NoOfDays_TXT.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NoOfDays_TXT.Location = New System.Drawing.Point(147, 29)
        Me.NoOfDays_TXT.Name = "NoOfDays_TXT"
        Me.NoOfDays_TXT.ReadOnly = True
        Me.NoOfDays_TXT.Size = New System.Drawing.Size(108, 29)
        Me.NoOfDays_TXT.TabIndex = 16
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.NetPay_LBL)
        Me.GroupBox4.Controls.Add(Me.Label63)
        Me.GroupBox4.Controls.Add(Me.Deduction_LBL)
        Me.GroupBox4.Controls.Add(Me.PagibigLoan_LBL)
        Me.GroupBox4.Controls.Add(Me.SSSLoan_LBL)
        Me.GroupBox4.Controls.Add(Me.Allowances_LBL)
        Me.GroupBox4.Controls.Add(Me.Label60)
        Me.GroupBox4.Controls.Add(Me.Label61)
        Me.GroupBox4.Controls.Add(Me.Tax_Wheld_LBL)
        Me.GroupBox4.Controls.Add(Me.Label58)
        Me.GroupBox4.Controls.Add(Me.Philhealth_LBL)
        Me.GroupBox4.Controls.Add(Me.HDMF_LBL)
        Me.GroupBox4.Controls.Add(Me.Label59)
        Me.GroupBox4.Controls.Add(Me.SSSComp_LBL)
        Me.GroupBox4.Controls.Add(Me.Label40)
        Me.GroupBox4.Controls.Add(Me.Label52)
        Me.GroupBox4.Controls.Add(Me.Label54)
        Me.GroupBox4.Controls.Add(Me.Label55)
        Me.GroupBox4.Controls.Add(Me.TotalLateUnder_LBL)
        Me.GroupBox4.Controls.Add(Me.TotalHol_LBL)
        Me.GroupBox4.Controls.Add(Me.TotalOT_LBL)
        Me.GroupBox4.Controls.Add(Me.TotalBasic_LBL)
        Me.GroupBox4.Controls.Add(Me.NetTax_LBL)
        Me.GroupBox4.Controls.Add(Me.Label45)
        Me.GroupBox4.Controls.Add(Me.GrossAmount_LBL)
        Me.GroupBox4.Controls.Add(Me.Label39)
        Me.GroupBox4.Controls.Add(Me.Label28)
        Me.GroupBox4.Controls.Add(Me.Label31)
        Me.GroupBox4.Controls.Add(Me.Label32)
        Me.GroupBox4.Controls.Add(Me.Label33)
        Me.GroupBox4.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(796, 5)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(340, 590)
        Me.GroupBox4.TabIndex = 31
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Salary Information"
        '
        'NetPay_LBL
        '
        Me.NetPay_LBL.Font = New System.Drawing.Font("Dubai", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NetPay_LBL.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.NetPay_LBL.Location = New System.Drawing.Point(182, 552)
        Me.NetPay_LBL.Name = "NetPay_LBL"
        Me.NetPay_LBL.Size = New System.Drawing.Size(129, 34)
        Me.NetPay_LBL.TabIndex = 94
        Me.NetPay_LBL.Text = "0"
        Me.NetPay_LBL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label63
        '
        Me.Label63.AutoSize = True
        Me.Label63.Font = New System.Drawing.Font("Dubai", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label63.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label63.Location = New System.Drawing.Point(15, 552)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(82, 34)
        Me.Label63.TabIndex = 93
        Me.Label63.Text = "Net Pay"
        '
        'Deduction_LBL
        '
        Me.Deduction_LBL.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Deduction_LBL.Location = New System.Drawing.Point(183, 407)
        Me.Deduction_LBL.Name = "Deduction_LBL"
        Me.Deduction_LBL.Size = New System.Drawing.Size(124, 27)
        Me.Deduction_LBL.TabIndex = 91
        Me.Deduction_LBL.Text = "0"
        Me.Deduction_LBL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PagibigLoan_LBL
        '
        Me.PagibigLoan_LBL.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PagibigLoan_LBL.Location = New System.Drawing.Point(183, 467)
        Me.PagibigLoan_LBL.Name = "PagibigLoan_LBL"
        Me.PagibigLoan_LBL.Size = New System.Drawing.Size(124, 27)
        Me.PagibigLoan_LBL.TabIndex = 89
        Me.PagibigLoan_LBL.Text = "0"
        Me.PagibigLoan_LBL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SSSLoan_LBL
        '
        Me.SSSLoan_LBL.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SSSLoan_LBL.Location = New System.Drawing.Point(183, 436)
        Me.SSSLoan_LBL.Name = "SSSLoan_LBL"
        Me.SSSLoan_LBL.Size = New System.Drawing.Size(124, 27)
        Me.SSSLoan_LBL.TabIndex = 88
        Me.SSSLoan_LBL.Text = "0"
        Me.SSSLoan_LBL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Allowances_LBL
        '
        Me.Allowances_LBL.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Allowances_LBL.Location = New System.Drawing.Point(183, 374)
        Me.Allowances_LBL.Name = "Allowances_LBL"
        Me.Allowances_LBL.Size = New System.Drawing.Size(124, 27)
        Me.Allowances_LBL.TabIndex = 90
        Me.Allowances_LBL.Text = "0"
        Me.Allowances_LBL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label60.Location = New System.Drawing.Point(17, 439)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(71, 25)
        Me.Label60.TabIndex = 83
        Me.Label60.Text = "SSS Loan"
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label61.Location = New System.Drawing.Point(18, 468)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(90, 25)
        Me.Label61.TabIndex = 84
        Me.Label61.Text = "Pagibig Loan"
        '
        'Tax_Wheld_LBL
        '
        Me.Tax_Wheld_LBL.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tax_Wheld_LBL.Location = New System.Drawing.Point(183, 294)
        Me.Tax_Wheld_LBL.Name = "Tax_Wheld_LBL"
        Me.Tax_Wheld_LBL.Size = New System.Drawing.Size(124, 27)
        Me.Tax_Wheld_LBL.TabIndex = 81
        Me.Tax_Wheld_LBL.Text = "0"
        Me.Tax_Wheld_LBL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label58.Location = New System.Drawing.Point(17, 406)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(75, 25)
        Me.Label58.TabIndex = 86
        Me.Label58.Text = "Deduction"
        '
        'Philhealth_LBL
        '
        Me.Philhealth_LBL.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Philhealth_LBL.Location = New System.Drawing.Point(183, 259)
        Me.Philhealth_LBL.Name = "Philhealth_LBL"
        Me.Philhealth_LBL.Size = New System.Drawing.Size(124, 27)
        Me.Philhealth_LBL.TabIndex = 79
        Me.Philhealth_LBL.Text = "0"
        Me.Philhealth_LBL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'HDMF_LBL
        '
        Me.HDMF_LBL.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HDMF_LBL.Location = New System.Drawing.Point(183, 226)
        Me.HDMF_LBL.Name = "HDMF_LBL"
        Me.HDMF_LBL.Size = New System.Drawing.Size(124, 27)
        Me.HDMF_LBL.TabIndex = 78
        Me.HDMF_LBL.Text = "0"
        Me.HDMF_LBL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label59.Location = New System.Drawing.Point(18, 373)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(79, 25)
        Me.Label59.TabIndex = 85
        Me.Label59.Text = "Allowances"
        '
        'SSSComp_LBL
        '
        Me.SSSComp_LBL.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SSSComp_LBL.Location = New System.Drawing.Point(183, 195)
        Me.SSSComp_LBL.Name = "SSSComp_LBL"
        Me.SSSComp_LBL.Size = New System.Drawing.Size(124, 27)
        Me.SSSComp_LBL.TabIndex = 77
        Me.SSSComp_LBL.Text = "0"
        Me.SSSComp_LBL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(17, 296)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(89, 25)
        Me.Label40.TabIndex = 76
        Me.Label40.Text = "Tax W/Held"
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.Location = New System.Drawing.Point(17, 259)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(112, 25)
        Me.Label52.TabIndex = 74
        Me.Label52.Text = "PhilHealth Cont."
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label54.Location = New System.Drawing.Point(16, 199)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(73, 25)
        Me.Label54.TabIndex = 72
        Me.Label54.Text = "SSS Cont."
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label55.Location = New System.Drawing.Point(17, 228)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(90, 25)
        Me.Label55.TabIndex = 73
        Me.Label55.Text = "HDMF Cont."
        '
        'TotalLateUnder_LBL
        '
        Me.TotalLateUnder_LBL.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalLateUnder_LBL.Location = New System.Drawing.Point(182, 121)
        Me.TotalLateUnder_LBL.Name = "TotalLateUnder_LBL"
        Me.TotalLateUnder_LBL.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TotalLateUnder_LBL.Size = New System.Drawing.Size(124, 27)
        Me.TotalLateUnder_LBL.TabIndex = 57
        Me.TotalLateUnder_LBL.Text = "0"
        Me.TotalLateUnder_LBL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TotalHol_LBL
        '
        Me.TotalHol_LBL.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalHol_LBL.Location = New System.Drawing.Point(182, 92)
        Me.TotalHol_LBL.Name = "TotalHol_LBL"
        Me.TotalHol_LBL.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TotalHol_LBL.Size = New System.Drawing.Size(124, 27)
        Me.TotalHol_LBL.TabIndex = 54
        Me.TotalHol_LBL.Text = "0"
        Me.TotalHol_LBL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TotalOT_LBL
        '
        Me.TotalOT_LBL.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalOT_LBL.Location = New System.Drawing.Point(182, 59)
        Me.TotalOT_LBL.Name = "TotalOT_LBL"
        Me.TotalOT_LBL.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TotalOT_LBL.Size = New System.Drawing.Size(124, 27)
        Me.TotalOT_LBL.TabIndex = 53
        Me.TotalOT_LBL.Text = "0"
        Me.TotalOT_LBL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TotalBasic_LBL
        '
        Me.TotalBasic_LBL.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalBasic_LBL.Location = New System.Drawing.Point(182, 28)
        Me.TotalBasic_LBL.Name = "TotalBasic_LBL"
        Me.TotalBasic_LBL.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TotalBasic_LBL.Size = New System.Drawing.Size(124, 27)
        Me.TotalBasic_LBL.TabIndex = 52
        Me.TotalBasic_LBL.Text = "0"
        Me.TotalBasic_LBL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'NetTax_LBL
        '
        Me.NetTax_LBL.Font = New System.Drawing.Font("Dubai", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NetTax_LBL.Location = New System.Drawing.Point(183, 334)
        Me.NetTax_LBL.Name = "NetTax_LBL"
        Me.NetTax_LBL.Size = New System.Drawing.Size(125, 29)
        Me.NetTax_LBL.TabIndex = 51
        Me.NetTax_LBL.Text = "0"
        Me.NetTax_LBL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.Location = New System.Drawing.Point(15, 336)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(122, 25)
        Me.Label45.TabIndex = 40
        Me.Label45.Text = "Comp. Net of Tax"
        '
        'GrossAmount_LBL
        '
        Me.GrossAmount_LBL.Font = New System.Drawing.Font("Dubai", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrossAmount_LBL.Location = New System.Drawing.Point(181, 154)
        Me.GrossAmount_LBL.Name = "GrossAmount_LBL"
        Me.GrossAmount_LBL.Size = New System.Drawing.Size(125, 29)
        Me.GrossAmount_LBL.TabIndex = 39
        Me.GrossAmount_LBL.Text = "0"
        Me.GrossAmount_LBL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(15, 157)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(105, 25)
        Me.Label39.TabIndex = 26
        Me.Label39.Text = "Gross Amount"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(16, 120)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(127, 25)
        Me.Label28.TabIndex = 21
        Me.Label28.Text = "Late / Under Time"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(16, 89)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(95, 25)
        Me.Label31.TabIndex = 10
        Me.Label31.Text = "Total Holiday"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(15, 29)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(79, 25)
        Me.Label32.TabIndex = 8
        Me.Label32.Text = "Total Basic"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(16, 58)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(105, 25)
        Me.Label33.TabIndex = 9
        Me.Label33.Text = "Total Overtime"
        '
        'Close_LBL
        '
        Me.Close_LBL.AutoSize = True
        Me.Close_LBL.Font = New System.Drawing.Font("Dubai", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Close_LBL.Location = New System.Drawing.Point(1149, -8)
        Me.Close_LBL.Name = "Close_LBL"
        Me.Close_LBL.Size = New System.Drawing.Size(31, 40)
        Me.Close_LBL.TabIndex = 75
        Me.Close_LBL.Text = "X"
        '
        'Cancel_BTN
        '
        Me.Cancel_BTN.BackColor = System.Drawing.Color.PeachPuff
        Me.Cancel_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cancel_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel_BTN.Location = New System.Drawing.Point(421, 546)
        Me.Cancel_BTN.Name = "Cancel_BTN"
        Me.Cancel_BTN.Size = New System.Drawing.Size(102, 37)
        Me.Cancel_BTN.TabIndex = 78
        Me.Cancel_BTN.Text = "Cancel"
        Me.Cancel_BTN.UseVisualStyleBackColor = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Font = New System.Drawing.Font("Dubai", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(7, 8)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1150, 650)
        Me.TabControl1.TabIndex = 79
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Label23)
        Me.TabPage2.Controls.Add(Me.Pay_Refresh_BTN)
        Me.TabPage2.Controls.Add(Me.Payout_grid)
        Me.TabPage2.Controls.Add(Me.GroupBox5)
        Me.TabPage2.Controls.Add(Me.Paydate_ComboB)
        Me.TabPage2.Controls.Add(Me.Search_TXT)
        Me.TabPage2.Controls.Add(Me.Search_BTN)
        Me.TabPage2.Controls.Add(Me.Payout_list)
        Me.TabPage2.Font = New System.Drawing.Font("Dubai Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage2.Location = New System.Drawing.Point(4, 41)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1142, 605)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "    Payout    "
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Pay_Refresh_BTN
        '
        Me.Pay_Refresh_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pay_Refresh_BTN.Location = New System.Drawing.Point(327, 41)
        Me.Pay_Refresh_BTN.Name = "Pay_Refresh_BTN"
        Me.Pay_Refresh_BTN.Size = New System.Drawing.Size(84, 31)
        Me.Pay_Refresh_BTN.TabIndex = 106
        Me.Pay_Refresh_BTN.Text = "Refresh"
        Me.Pay_Refresh_BTN.UseVisualStyleBackColor = True
        '
        'Payout_grid
        '
        Me.Payout_grid.AllowUserToAddRows = False
        Me.Payout_grid.AllowUserToResizeColumns = False
        Me.Payout_grid.AllowUserToResizeRows = False
        DataGridViewCellStyle64.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Payout_grid.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle64
        Me.Payout_grid.BackgroundColor = System.Drawing.Color.White
        Me.Payout_grid.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Payout_grid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.Payout_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Payout_grid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Name_dgv, Me.basic_dgv, Me.overtime_dgv, Me.late_dgv, Me.gross_dgv, Me.sssDis_dgv, Me.PagibigDis_dgv, Me.philH_dgv, Me.taxable_dgv, Me.taxWH_dgv, Me.netTax_dgv, Me.sssLoan_dgv, Me.pagibigLoan_dgv, Me.allowance_dgv, Me.deduction_dgv, Me.netPay_dgv})
        DataGridViewCellStyle67.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle67.BackColor = System.Drawing.SystemColors.InactiveCaption
        DataGridViewCellStyle67.Font = New System.Drawing.Font("Dubai Medium", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle67.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle67.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle67.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle67.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Payout_grid.DefaultCellStyle = DataGridViewCellStyle67
        Me.Payout_grid.Location = New System.Drawing.Point(6, 573)
        Me.Payout_grid.Name = "Payout_grid"
        Me.Payout_grid.RowHeadersVisible = False
        DataGridViewCellStyle68.SelectionBackColor = System.Drawing.Color.Transparent
        DataGridViewCellStyle68.SelectionForeColor = System.Drawing.Color.Transparent
        Me.Payout_grid.RowsDefaultCellStyle = DataGridViewCellStyle68
        Me.Payout_grid.Size = New System.Drawing.Size(1130, 26)
        Me.Payout_grid.TabIndex = 105
        Me.Payout_grid.Visible = False
        '
        'Name_dgv
        '
        DataGridViewCellStyle65.NullValue = Nothing
        Me.Name_dgv.DefaultCellStyle = DataGridViewCellStyle65
        Me.Name_dgv.Frozen = True
        Me.Name_dgv.HeaderText = "Name"
        Me.Name_dgv.Name = "Name_dgv"
        Me.Name_dgv.ReadOnly = True
        Me.Name_dgv.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Name_dgv.Width = 250
        '
        'basic_dgv
        '
        DataGridViewCellStyle66.NullValue = Nothing
        Me.basic_dgv.DefaultCellStyle = DataGridViewCellStyle66
        Me.basic_dgv.HeaderText = "Basic"
        Me.basic_dgv.Name = "basic_dgv"
        Me.basic_dgv.ReadOnly = True
        Me.basic_dgv.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.basic_dgv.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.basic_dgv.Width = 105
        '
        'overtime_dgv
        '
        Me.overtime_dgv.HeaderText = "Overtime"
        Me.overtime_dgv.Name = "overtime_dgv"
        Me.overtime_dgv.ReadOnly = True
        Me.overtime_dgv.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.overtime_dgv.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.overtime_dgv.Width = 105
        '
        'late_dgv
        '
        Me.late_dgv.HeaderText = "Late/UT"
        Me.late_dgv.Name = "late_dgv"
        Me.late_dgv.ReadOnly = True
        Me.late_dgv.Width = 105
        '
        'gross_dgv
        '
        Me.gross_dgv.HeaderText = "Gross"
        Me.gross_dgv.Name = "gross_dgv"
        Me.gross_dgv.ReadOnly = True
        Me.gross_dgv.Width = 105
        '
        'sssDis_dgv
        '
        Me.sssDis_dgv.HeaderText = "SSS Dist."
        Me.sssDis_dgv.Name = "sssDis_dgv"
        Me.sssDis_dgv.ReadOnly = True
        Me.sssDis_dgv.Width = 105
        '
        'PagibigDis_dgv
        '
        Me.PagibigDis_dgv.HeaderText = "Pagibig Dist."
        Me.PagibigDis_dgv.Name = "PagibigDis_dgv"
        Me.PagibigDis_dgv.ReadOnly = True
        Me.PagibigDis_dgv.Width = 105
        '
        'philH_dgv
        '
        Me.philH_dgv.HeaderText = "Phil Dist."
        Me.philH_dgv.Name = "philH_dgv"
        Me.philH_dgv.ReadOnly = True
        Me.philH_dgv.Width = 105
        '
        'taxable_dgv
        '
        Me.taxable_dgv.HeaderText = "Taxable"
        Me.taxable_dgv.Name = "taxable_dgv"
        Me.taxable_dgv.ReadOnly = True
        Me.taxable_dgv.Width = 105
        '
        'taxWH_dgv
        '
        Me.taxWH_dgv.HeaderText = "Tax WH"
        Me.taxWH_dgv.Name = "taxWH_dgv"
        Me.taxWH_dgv.ReadOnly = True
        Me.taxWH_dgv.Width = 105
        '
        'netTax_dgv
        '
        Me.netTax_dgv.HeaderText = "Net Tax"
        Me.netTax_dgv.Name = "netTax_dgv"
        Me.netTax_dgv.ReadOnly = True
        Me.netTax_dgv.Width = 105
        '
        'sssLoan_dgv
        '
        Me.sssLoan_dgv.HeaderText = "SSS Loan"
        Me.sssLoan_dgv.Name = "sssLoan_dgv"
        Me.sssLoan_dgv.ReadOnly = True
        Me.sssLoan_dgv.Width = 105
        '
        'pagibigLoan_dgv
        '
        Me.pagibigLoan_dgv.HeaderText = "Pagibig Loan"
        Me.pagibigLoan_dgv.Name = "pagibigLoan_dgv"
        Me.pagibigLoan_dgv.ReadOnly = True
        Me.pagibigLoan_dgv.Width = 105
        '
        'allowance_dgv
        '
        Me.allowance_dgv.HeaderText = "Allowance"
        Me.allowance_dgv.Name = "allowance_dgv"
        Me.allowance_dgv.ReadOnly = True
        Me.allowance_dgv.Width = 105
        '
        'deduction_dgv
        '
        Me.deduction_dgv.HeaderText = "Deduction"
        Me.deduction_dgv.Name = "deduction_dgv"
        Me.deduction_dgv.ReadOnly = True
        Me.deduction_dgv.Width = 105
        '
        'netPay_dgv
        '
        Me.netPay_dgv.HeaderText = "Net Pay"
        Me.netPay_dgv.Name = "netPay_dgv"
        Me.netPay_dgv.ReadOnly = True
        Me.netPay_dgv.Width = 105
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.ER_SSS)
        Me.GroupBox5.Controls.Add(Me.Label46)
        Me.GroupBox5.Controls.Add(Me.Label1)
        Me.GroupBox5.Controls.Add(Me.P_TaxWH_LBL)
        Me.GroupBox5.Controls.Add(Me.P_NetPay_LBL)
        Me.GroupBox5.Controls.Add(Me.P_PagibigLoan_LBL)
        Me.GroupBox5.Controls.Add(Me.Label30)
        Me.GroupBox5.Controls.Add(Me.Label13)
        Me.GroupBox5.Controls.Add(Me.P_GrossAmount_LBL)
        Me.GroupBox5.Controls.Add(Me.P_PhilHComp_LBL)
        Me.GroupBox5.Controls.Add(Me.P_PagibigComp_LBL)
        Me.GroupBox5.Controls.Add(Me.Label35)
        Me.GroupBox5.Controls.Add(Me.Label36)
        Me.GroupBox5.Controls.Add(Me.Label8)
        Me.GroupBox5.Controls.Add(Me.P_Allowance_LBL)
        Me.GroupBox5.Controls.Add(Me.P_Deduction_LBL)
        Me.GroupBox5.Controls.Add(Me.Label19)
        Me.GroupBox5.Controls.Add(Me.Label29)
        Me.GroupBox5.Controls.Add(Me.P_SSSLoan_LBL)
        Me.GroupBox5.Controls.Add(Me.P_SSSComp_LBL)
        Me.GroupBox5.Controls.Add(Me.labelee)
        Me.GroupBox5.Controls.Add(Me.labell)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(479, 1)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(657, 148)
        Me.GroupBox5.TabIndex = 104
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Total"
        '
        'ER_SSS
        '
        Me.ER_SSS.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ER_SSS.Location = New System.Drawing.Point(567, 46)
        Me.ER_SSS.Name = "ER_SSS"
        Me.ER_SSS.Size = New System.Drawing.Size(80, 22)
        Me.ER_SSS.TabIndex = 112
        Me.ER_SSS.Text = "0"
        Me.ER_SSS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ER_SSS.Visible = False
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.Location = New System.Drawing.Point(460, 45)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(83, 22)
        Me.Label46.TabIndex = 111
        Me.Label46.Text = "ER SSS Cont. "
        Me.Label46.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(29, 91)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 22)
        Me.Label1.TabIndex = 109
        Me.Label1.Text = "EE Withholding"
        '
        'P_TaxWH_LBL
        '
        Me.P_TaxWH_LBL.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.P_TaxWH_LBL.Location = New System.Drawing.Point(129, 90)
        Me.P_TaxWH_LBL.Name = "P_TaxWH_LBL"
        Me.P_TaxWH_LBL.Size = New System.Drawing.Size(87, 22)
        Me.P_TaxWH_LBL.TabIndex = 110
        Me.P_TaxWH_LBL.Text = "0"
        Me.P_TaxWH_LBL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'P_NetPay_LBL
        '
        Me.P_NetPay_LBL.Font = New System.Drawing.Font("Dubai", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.P_NetPay_LBL.ForeColor = System.Drawing.Color.DarkRed
        Me.P_NetPay_LBL.Location = New System.Drawing.Point(502, 114)
        Me.P_NetPay_LBL.Name = "P_NetPay_LBL"
        Me.P_NetPay_LBL.Size = New System.Drawing.Size(141, 28)
        Me.P_NetPay_LBL.TabIndex = 94
        Me.P_NetPay_LBL.Text = "0"
        Me.P_NetPay_LBL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'P_PagibigLoan_LBL
        '
        Me.P_PagibigLoan_LBL.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.P_PagibigLoan_LBL.Location = New System.Drawing.Point(345, 47)
        Me.P_PagibigLoan_LBL.Name = "P_PagibigLoan_LBL"
        Me.P_PagibigLoan_LBL.Size = New System.Drawing.Size(82, 22)
        Me.P_PagibigLoan_LBL.TabIndex = 108
        Me.P_PagibigLoan_LBL.Text = "0"
        Me.P_PagibigLoan_LBL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(261, 46)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(78, 22)
        Me.Label30.TabIndex = 107
        Me.Label30.Text = "Pagibig Loan"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(460, 23)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(87, 22)
        Me.Label13.TabIndex = 81
        Me.Label13.Text = "Gross Amount"
        Me.Label13.Visible = False
        '
        'P_GrossAmount_LBL
        '
        Me.P_GrossAmount_LBL.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.P_GrossAmount_LBL.Location = New System.Drawing.Point(567, 23)
        Me.P_GrossAmount_LBL.Name = "P_GrossAmount_LBL"
        Me.P_GrossAmount_LBL.Size = New System.Drawing.Size(80, 22)
        Me.P_GrossAmount_LBL.TabIndex = 85
        Me.P_GrossAmount_LBL.Text = "0"
        Me.P_GrossAmount_LBL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.P_GrossAmount_LBL.Visible = False
        '
        'P_PhilHComp_LBL
        '
        Me.P_PhilHComp_LBL.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.P_PhilHComp_LBL.Location = New System.Drawing.Point(129, 69)
        Me.P_PhilHComp_LBL.Name = "P_PhilHComp_LBL"
        Me.P_PhilHComp_LBL.Size = New System.Drawing.Size(87, 22)
        Me.P_PhilHComp_LBL.TabIndex = 106
        Me.P_PhilHComp_LBL.Text = "0"
        Me.P_PhilHComp_LBL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'P_PagibigComp_LBL
        '
        Me.P_PagibigComp_LBL.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.P_PagibigComp_LBL.Location = New System.Drawing.Point(129, 48)
        Me.P_PagibigComp_LBL.Name = "P_PagibigComp_LBL"
        Me.P_PagibigComp_LBL.Size = New System.Drawing.Size(87, 22)
        Me.P_PagibigComp_LBL.TabIndex = 94
        Me.P_PagibigComp_LBL.Text = "0"
        Me.P_PagibigComp_LBL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.ForeColor = System.Drawing.Color.DarkRed
        Me.Label35.Location = New System.Drawing.Point(408, 115)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(66, 27)
        Me.Label35.TabIndex = 93
        Me.Label35.Text = "Net Pay"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(29, 68)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(87, 22)
        Me.Label36.TabIndex = 105
        Me.Label36.Text = "EE PhilH Cont."
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(29, 47)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(94, 22)
        Me.Label8.TabIndex = 93
        Me.Label8.Text = "EE HDMF Cont."
        '
        'P_Allowance_LBL
        '
        Me.P_Allowance_LBL.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.P_Allowance_LBL.Location = New System.Drawing.Point(345, 66)
        Me.P_Allowance_LBL.Name = "P_Allowance_LBL"
        Me.P_Allowance_LBL.Size = New System.Drawing.Size(82, 22)
        Me.P_Allowance_LBL.TabIndex = 92
        Me.P_Allowance_LBL.Text = "0"
        Me.P_Allowance_LBL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'P_Deduction_LBL
        '
        Me.P_Deduction_LBL.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.P_Deduction_LBL.Location = New System.Drawing.Point(345, 90)
        Me.P_Deduction_LBL.Name = "P_Deduction_LBL"
        Me.P_Deduction_LBL.Size = New System.Drawing.Size(82, 22)
        Me.P_Deduction_LBL.TabIndex = 91
        Me.P_Deduction_LBL.Text = "0"
        Me.P_Deduction_LBL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(261, 68)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(64, 22)
        Me.Label19.TabIndex = 90
        Me.Label19.Text = "Allowance"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(261, 92)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(66, 22)
        Me.Label29.TabIndex = 89
        Me.Label29.Text = "Deduction"
        '
        'P_SSSLoan_LBL
        '
        Me.P_SSSLoan_LBL.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.P_SSSLoan_LBL.Location = New System.Drawing.Point(345, 23)
        Me.P_SSSLoan_LBL.Name = "P_SSSLoan_LBL"
        Me.P_SSSLoan_LBL.Size = New System.Drawing.Size(82, 22)
        Me.P_SSSLoan_LBL.TabIndex = 88
        Me.P_SSSLoan_LBL.Text = "0"
        Me.P_SSSLoan_LBL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'P_SSSComp_LBL
        '
        Me.P_SSSComp_LBL.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.P_SSSComp_LBL.Location = New System.Drawing.Point(129, 23)
        Me.P_SSSComp_LBL.Name = "P_SSSComp_LBL"
        Me.P_SSSComp_LBL.Size = New System.Drawing.Size(87, 22)
        Me.P_SSSComp_LBL.TabIndex = 86
        Me.P_SSSComp_LBL.Text = "0"
        Me.P_SSSComp_LBL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'labelee
        '
        Me.labelee.AutoSize = True
        Me.labelee.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelee.Location = New System.Drawing.Point(261, 22)
        Me.labelee.Name = "labelee"
        Me.labelee.Size = New System.Drawing.Size(61, 22)
        Me.labelee.TabIndex = 84
        Me.labelee.Text = "SSS Loan"
        '
        'labell
        '
        Me.labell.AutoSize = True
        Me.labell.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labell.Location = New System.Drawing.Point(29, 22)
        Me.labell.Name = "labell"
        Me.labell.Size = New System.Drawing.Size(82, 22)
        Me.labell.TabIndex = 82
        Me.labell.Text = "EE SSS Cont. "
        '
        'Paydate_ComboB
        '
        Me.Paydate_ComboB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Paydate_ComboB.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Paydate_ComboB.FormattingEnabled = True
        Me.Paydate_ComboB.Location = New System.Drawing.Point(105, 41)
        Me.Paydate_ComboB.Name = "Paydate_ComboB"
        Me.Paydate_ComboB.Size = New System.Drawing.Size(216, 33)
        Me.Paydate_ComboB.TabIndex = 103
        '
        'Search_TXT
        '
        Me.Search_TXT.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Search_TXT.Location = New System.Drawing.Point(6, 121)
        Me.Search_TXT.Name = "Search_TXT"
        Me.Search_TXT.Size = New System.Drawing.Size(315, 33)
        Me.Search_TXT.TabIndex = 101
        '
        'Search_BTN
        '
        Me.Search_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Search_BTN.Location = New System.Drawing.Point(327, 120)
        Me.Search_BTN.Name = "Search_BTN"
        Me.Search_BTN.Size = New System.Drawing.Size(82, 33)
        Me.Search_BTN.TabIndex = 102
        Me.Search_BTN.Text = "Search"
        Me.Search_BTN.UseVisualStyleBackColor = True
        '
        'Payout_list
        '
        Me.Payout_list.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Payout_list.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader18, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11, Me.ColumnHeader12, Me.ColumnHeader13})
        Me.Payout_list.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Payout_list.FullRowSelect = True
        Me.Payout_list.GridLines = True
        Me.Payout_list.HideSelection = False
        Me.Payout_list.Location = New System.Drawing.Point(6, 160)
        Me.Payout_list.MultiSelect = False
        Me.Payout_list.Name = "Payout_list"
        Me.Payout_list.Size = New System.Drawing.Size(1140, 433)
        Me.Payout_list.TabIndex = 100
        Me.Payout_list.UseCompatibleStateImageBehavior = False
        Me.Payout_list.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader18
        '
        Me.ColumnHeader18.Text = "Name"
        Me.ColumnHeader18.Width = 230
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Gross"
        Me.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader2.Width = 80
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "SSS Cont."
        Me.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader3.Width = 80
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "HDMF Cont."
        Me.ColumnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader4.Width = 80
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "PhilH Cont."
        Me.ColumnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader5.Width = 80
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Tax W/Held"
        Me.ColumnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader7.Width = 80
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Net Tax Comp."
        Me.ColumnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader8.Width = 80
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "SSS Loan"
        Me.ColumnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader9.Width = 80
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Pagibig Loan"
        Me.ColumnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader10.Width = 80
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Allowance"
        Me.ColumnHeader11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader11.Width = 80
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Deduction"
        Me.ColumnHeader12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader12.Width = 80
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "NET PAY"
        Me.ColumnHeader13.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader13.Width = 80
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.FlowLayoutPanel2)
        Me.TabPage1.Controls.Add(Me.Previous_groupB)
        Me.TabPage1.Controls.Add(Me.Details_Save_BTN)
        Me.TabPage1.Controls.Add(Me.GroupBox6)
        Me.TabPage1.Controls.Add(Me.Cancel_BTN)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.GroupBox4)
        Me.TabPage1.Location = New System.Drawing.Point(4, 41)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1142, 605)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "    Details    "
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Controls.Add(Me.Label18)
        Me.FlowLayoutPanel2.Controls.Add(Me.Allowance_grid)
        Me.FlowLayoutPanel2.Controls.Add(Me.Label20)
        Me.FlowLayoutPanel2.Controls.Add(Me.Label22)
        Me.FlowLayoutPanel2.Controls.Add(Me.Deduction_grid)
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(12, 224)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(333, 371)
        Me.FlowLayoutPanel2.TabIndex = 87
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(3, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(101, 25)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "Allowances ---"
        '
        'Allowance_grid
        '
        Me.Allowance_grid.AllowUserToAddRows = False
        Me.Allowance_grid.AllowUserToDeleteRows = False
        Me.Allowance_grid.AllowUserToResizeColumns = False
        Me.Allowance_grid.AllowUserToResizeRows = False
        Me.Allowance_grid.BackgroundColor = System.Drawing.SystemColors.HighlightText
        Me.Allowance_grid.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Allowance_grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.Allowance_grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.Allowance_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Allowance_grid.ColumnHeadersVisible = False
        Me.Allowance_grid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.grid_1, Me.grid_2})
        DataGridViewCellStyle70.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle70.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle70.Font = New System.Drawing.Font("Dubai", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle70.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle70.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle70.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle70.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Allowance_grid.DefaultCellStyle = DataGridViewCellStyle70
        Me.Allowance_grid.Enabled = False
        Me.Allowance_grid.Location = New System.Drawing.Point(3, 28)
        Me.Allowance_grid.Name = "Allowance_grid"
        Me.Allowance_grid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.Allowance_grid.RowHeadersVisible = False
        Me.Allowance_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Allowance_grid.Size = New System.Drawing.Size(300, 32)
        Me.Allowance_grid.TabIndex = 0
        '
        'grid_1
        '
        Me.grid_1.HeaderText = ""
        Me.grid_1.Name = "grid_1"
        Me.grid_1.ReadOnly = True
        Me.grid_1.Width = 130
        '
        'grid_2
        '
        DataGridViewCellStyle69.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.grid_2.DefaultCellStyle = DataGridViewCellStyle69
        Me.grid_2.HeaderText = ""
        Me.grid_2.Name = "grid_2"
        Me.grid_2.ReadOnly = True
        Me.grid_2.Width = 90
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(3, 63)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(320, 25)
        Me.Label20.TabIndex = 1
        Me.Label20.Text = "                                                                             "
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(3, 88)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(103, 25)
        Me.Label22.TabIndex = 2
        Me.Label22.Text = "Deductions ---"
        '
        'Deduction_grid
        '
        Me.Deduction_grid.AllowUserToAddRows = False
        Me.Deduction_grid.AllowUserToDeleteRows = False
        Me.Deduction_grid.AllowUserToResizeColumns = False
        Me.Deduction_grid.AllowUserToResizeRows = False
        Me.Deduction_grid.BackgroundColor = System.Drawing.SystemColors.HighlightText
        Me.Deduction_grid.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Deduction_grid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.Deduction_grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.Deduction_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Deduction_grid.ColumnHeadersVisible = False
        Me.Deduction_grid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.Column1, Me.Deduc_BTN})
        DataGridViewCellStyle72.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle72.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle72.Font = New System.Drawing.Font("Dubai", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle72.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle72.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle72.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle72.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Deduction_grid.DefaultCellStyle = DataGridViewCellStyle72
        Me.Deduction_grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.Deduction_grid.Location = New System.Drawing.Point(3, 116)
        Me.Deduction_grid.Name = "Deduction_grid"
        Me.Deduction_grid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.Deduction_grid.RowHeadersVisible = False
        Me.Deduction_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Deduction_grid.Size = New System.Drawing.Size(311, 36)
        Me.Deduction_grid.TabIndex = 1
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = ""
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 130
        '
        'DataGridViewTextBoxColumn2
        '
        DataGridViewCellStyle71.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle71
        Me.DataGridViewTextBoxColumn2.HeaderText = ""
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 90
        '
        'Column1
        '
        Me.Column1.HeaderText = ""
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 30
        '
        'Deduc_BTN
        '
        Me.Deduc_BTN.HeaderText = ""
        Me.Deduc_BTN.Name = "Deduc_BTN"
        Me.Deduc_BTN.ReadOnly = True
        Me.Deduc_BTN.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Deduc_BTN.Width = 60
        '
        'Previous_groupB
        '
        Me.Previous_groupB.Controls.Add(Me.Prev_lbl)
        Me.Previous_groupB.Controls.Add(Me.Prev_Amount_lbl)
        Me.Previous_groupB.Location = New System.Drawing.Point(443, 301)
        Me.Previous_groupB.Name = "Previous_groupB"
        Me.Previous_groupB.Size = New System.Drawing.Size(323, 48)
        Me.Previous_groupB.TabIndex = 85
        Me.Previous_groupB.TabStop = False
        Me.Previous_groupB.Visible = False
        '
        'Prev_lbl
        '
        Me.Prev_lbl.AutoSize = True
        Me.Prev_lbl.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Prev_lbl.Location = New System.Drawing.Point(33, 21)
        Me.Prev_lbl.Name = "Prev_lbl"
        Me.Prev_lbl.Size = New System.Drawing.Size(106, 25)
        Me.Prev_lbl.TabIndex = 83
        Me.Prev_lbl.Text = "Previous Basic :"
        '
        'Prev_Amount_lbl
        '
        Me.Prev_Amount_lbl.AutoSize = True
        Me.Prev_Amount_lbl.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Prev_Amount_lbl.Location = New System.Drawing.Point(151, 22)
        Me.Prev_Amount_lbl.Name = "Prev_Amount_lbl"
        Me.Prev_Amount_lbl.Size = New System.Drawing.Size(18, 25)
        Me.Prev_Amount_lbl.TabIndex = 84
        Me.Prev_Amount_lbl.Text = "-"
        '
        'Details_Save_BTN
        '
        Me.Details_Save_BTN.BackColor = System.Drawing.Color.Coral
        Me.Details_Save_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Details_Save_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Details_Save_BTN.Location = New System.Drawing.Point(677, 546)
        Me.Details_Save_BTN.Name = "Details_Save_BTN"
        Me.Details_Save_BTN.Size = New System.Drawing.Size(102, 37)
        Me.Details_Save_BTN.TabIndex = 79
        Me.Details_Save_BTN.Text = "Edit"
        Me.Details_Save_BTN.UseVisualStyleBackColor = False
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.FlowLayoutPanel1)
        Me.TabPage4.Controls.Add(Me.Label14)
        Me.TabPage4.Controls.Add(Me.BodyText_RichB)
        Me.TabPage4.Controls.Add(Me.Send_BTN)
        Me.TabPage4.Controls.Add(Me.ReportViewer_payslip)
        Me.TabPage4.Controls.Add(Me.Employee_RadioB)
        Me.TabPage4.Controls.Add(Me.Branch_RadioB)
        Me.TabPage4.Controls.Add(Me.All_RadioB)
        Me.TabPage4.Controls.Add(Me.Label21)
        Me.TabPage4.Controls.Add(Me.Payslip_paydate_Combo)
        Me.TabPage4.Location = New System.Drawing.Point(4, 41)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(1142, 605)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "    Payslip    "
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.Branch_group)
        Me.FlowLayoutPanel1.Controls.Add(Me.Employee_GroupB)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(12, 221)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(430, 224)
        Me.FlowLayoutPanel1.TabIndex = 106
        '
        'Branch_group
        '
        Me.Branch_group.Controls.Add(Me.Branch_ComboB)
        Me.Branch_group.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Branch_group.Location = New System.Drawing.Point(3, 3)
        Me.Branch_group.Name = "Branch_group"
        Me.Branch_group.Size = New System.Drawing.Size(416, 74)
        Me.Branch_group.TabIndex = 75
        Me.Branch_group.TabStop = False
        Me.Branch_group.Text = "Per Branch"
        Me.Branch_group.Visible = False
        '
        'Branch_ComboB
        '
        Me.Branch_ComboB.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Branch_ComboB.FormattingEnabled = True
        Me.Branch_ComboB.Location = New System.Drawing.Point(11, 28)
        Me.Branch_ComboB.Name = "Branch_ComboB"
        Me.Branch_ComboB.Size = New System.Drawing.Size(319, 33)
        Me.Branch_ComboB.TabIndex = 8
        Me.Branch_ComboB.Text = "   Select Branch"
        '
        'Employee_GroupB
        '
        Me.Employee_GroupB.Controls.Add(Me.Preview_BTN)
        Me.Employee_GroupB.Controls.Add(Me.Email_TXT)
        Me.Employee_GroupB.Controls.Add(Me.Employee_TXT)
        Me.Employee_GroupB.Controls.Add(Me.EmpSelect_BTN)
        Me.Employee_GroupB.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Employee_GroupB.Location = New System.Drawing.Point(3, 83)
        Me.Employee_GroupB.Name = "Employee_GroupB"
        Me.Employee_GroupB.Size = New System.Drawing.Size(416, 119)
        Me.Employee_GroupB.TabIndex = 88
        Me.Employee_GroupB.TabStop = False
        Me.Employee_GroupB.Text = "Per Employee"
        Me.Employee_GroupB.Visible = False
        '
        'Preview_BTN
        '
        Me.Preview_BTN.Location = New System.Drawing.Point(336, 73)
        Me.Preview_BTN.Name = "Preview_BTN"
        Me.Preview_BTN.Size = New System.Drawing.Size(62, 35)
        Me.Preview_BTN.TabIndex = 96
        Me.Preview_BTN.Text = "Preview"
        Me.Preview_BTN.UseVisualStyleBackColor = True
        '
        'Email_TXT
        '
        Me.Email_TXT.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Email_TXT.Location = New System.Drawing.Point(11, 75)
        Me.Email_TXT.Name = "Email_TXT"
        Me.Email_TXT.ReadOnly = True
        Me.Email_TXT.Size = New System.Drawing.Size(319, 33)
        Me.Email_TXT.TabIndex = 91
        '
        'Employee_TXT
        '
        Me.Employee_TXT.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Employee_TXT.Location = New System.Drawing.Point(11, 25)
        Me.Employee_TXT.Name = "Employee_TXT"
        Me.Employee_TXT.ReadOnly = True
        Me.Employee_TXT.Size = New System.Drawing.Size(319, 33)
        Me.Employee_TXT.TabIndex = 90
        '
        'EmpSelect_BTN
        '
        Me.EmpSelect_BTN.AutoSize = True
        Me.EmpSelect_BTN.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EmpSelect_BTN.Location = New System.Drawing.Point(336, 26)
        Me.EmpSelect_BTN.Name = "EmpSelect_BTN"
        Me.EmpSelect_BTN.Size = New System.Drawing.Size(62, 37)
        Me.EmpSelect_BTN.TabIndex = 89
        Me.EmpSelect_BTN.Text = "Select"
        Me.EmpSelect_BTN.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(12, 510)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(66, 22)
        Me.Label14.TabIndex = 105
        Me.Label14.Text = "Body Text"
        '
        'BodyText_RichB
        '
        Me.BodyText_RichB.Font = New System.Drawing.Font("Dubai", 9.7!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BodyText_RichB.Location = New System.Drawing.Point(15, 533)
        Me.BodyText_RichB.Name = "BodyText_RichB"
        Me.BodyText_RichB.Size = New System.Drawing.Size(427, 58)
        Me.BodyText_RichB.TabIndex = 104
        Me.BodyText_RichB.Text = "Please reply ""received"" for confirmation with this emailed payslip. Thank you."
        '
        'Send_BTN
        '
        Me.Send_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Send_BTN.Location = New System.Drawing.Point(487, 537)
        Me.Send_BTN.Name = "Send_BTN"
        Me.Send_BTN.Size = New System.Drawing.Size(93, 50)
        Me.Send_BTN.TabIndex = 103
        Me.Send_BTN.Text = "Send"
        Me.Send_BTN.UseVisualStyleBackColor = True
        '
        'ReportViewer_payslip
        '
        Me.ReportViewer_payslip.LocalReport.ReportEmbeddedResource = "WindowsApp1.rpt_payslip.rdlc"
        Me.ReportViewer_payslip.Location = New System.Drawing.Point(647, 14)
        Me.ReportViewer_payslip.Name = "ReportViewer_payslip"
        Me.ReportViewer_payslip.ServerReport.BearerToken = Nothing
        Me.ReportViewer_payslip.Size = New System.Drawing.Size(481, 582)
        Me.ReportViewer_payslip.TabIndex = 102
        '
        'Employee_RadioB
        '
        Me.Employee_RadioB.AutoSize = True
        Me.Employee_RadioB.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Employee_RadioB.Location = New System.Drawing.Point(28, 82)
        Me.Employee_RadioB.Name = "Employee_RadioB"
        Me.Employee_RadioB.Size = New System.Drawing.Size(114, 29)
        Me.Employee_RadioB.TabIndex = 101
        Me.Employee_RadioB.TabStop = True
        Me.Employee_RadioB.Text = "Per Employee"
        Me.Employee_RadioB.UseVisualStyleBackColor = True
        '
        'Branch_RadioB
        '
        Me.Branch_RadioB.AutoSize = True
        Me.Branch_RadioB.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Branch_RadioB.Location = New System.Drawing.Point(28, 47)
        Me.Branch_RadioB.Name = "Branch_RadioB"
        Me.Branch_RadioB.Size = New System.Drawing.Size(97, 29)
        Me.Branch_RadioB.TabIndex = 100
        Me.Branch_RadioB.TabStop = True
        Me.Branch_RadioB.Text = "Per Branch"
        Me.Branch_RadioB.UseVisualStyleBackColor = True
        '
        'All_RadioB
        '
        Me.All_RadioB.AutoSize = True
        Me.All_RadioB.Checked = True
        Me.All_RadioB.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.All_RadioB.Location = New System.Drawing.Point(28, 12)
        Me.All_RadioB.Name = "All_RadioB"
        Me.All_RadioB.Size = New System.Drawing.Size(45, 29)
        Me.All_RadioB.TabIndex = 99
        Me.All_RadioB.TabStop = True
        Me.All_RadioB.Text = "All"
        Me.All_RadioB.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(20, 140)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(53, 25)
        Me.Label21.TabIndex = 98
        Me.Label21.Text = "Payroll"
        '
        'Payslip_paydate_Combo
        '
        Me.Payslip_paydate_Combo.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Payslip_paydate_Combo.FormattingEnabled = True
        Me.Payslip_paydate_Combo.Location = New System.Drawing.Point(25, 168)
        Me.Payslip_paydate_Combo.Name = "Payslip_paydate_Combo"
        Me.Payslip_paydate_Combo.Size = New System.Drawing.Size(319, 33)
        Me.Payslip_paydate_Combo.TabIndex = 97
        Me.Payslip_paydate_Combo.Text = "   Select Date"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(1, 44)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(101, 27)
        Me.Label23.TabIndex = 107
        Me.Label23.Text = "Select Payroll"
        '
        'frmPayout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1169, 665)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Close_LBL)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmPayout"
        Me.Text = "frmPayout"
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.Payout_grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel2.PerformLayout()
        CType(Me.Allowance_grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Deduction_grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Previous_groupB.ResumeLayout(False)
        Me.Previous_groupB.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.Branch_group.ResumeLayout(False)
        Me.Employee_GroupB.ResumeLayout(False)
        Me.Employee_GroupB.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Rate_TXT As TextBox
    Friend WithEvents Name_TXT As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents BiometricID_TXT As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Select_BTN As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents SpecialHol_TXT As TextBox
    Friend WithEvents RegularOT_TXT As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents NoOfDays_TXT As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents UnderTime_TXT As TextBox
    Friend WithEvents Late_TXT As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents RegularHol_TXT As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Label39 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents Label31 As Label
    Friend WithEvents Label32 As Label
    Friend WithEvents Label33 As Label
    Friend WithEvents NetTax_LBL As Label
    Friend WithEvents Label45 As Label
    Friend WithEvents GrossAmount_LBL As Label
    Friend WithEvents TotalLateUnder_LBL As Label
    Friend WithEvents TotalHol_LBL As Label
    Friend WithEvents TotalOT_LBL As Label
    Friend WithEvents TotalBasic_LBL As Label
    Friend WithEvents NetPay_LBL As Label
    Friend WithEvents Label63 As Label
    Friend WithEvents Deduction_LBL As Label
    Friend WithEvents Allowances_LBL As Label
    Friend WithEvents PagibigLoan_LBL As Label
    Friend WithEvents SSSLoan_LBL As Label
    Friend WithEvents Label58 As Label
    Friend WithEvents Label59 As Label
    Friend WithEvents Label60 As Label
    Friend WithEvents Label61 As Label
    Friend WithEvents Tax_Wheld_LBL As Label
    Friend WithEvents Philhealth_LBL As Label
    Friend WithEvents HDMF_LBL As Label
    Friend WithEvents SSSComp_LBL As Label
    Friend WithEvents Label40 As Label
    Friend WithEvents Label52 As Label
    Friend WithEvents Label54 As Label
    Friend WithEvents Label55 As Label
    Friend WithEvents Close_LBL As Label
    Friend WithEvents Cancel_BTN As Button
    Friend WithEvents TotalHours_LBL As Label
    Friend WithEvents Label34 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents Payout_list As ListView
    Friend WithEvents ColumnHeader18 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents ColumnHeader9 As ColumnHeader
    Friend WithEvents ColumnHeader11 As ColumnHeader
    Friend WithEvents ColumnHeader12 As ColumnHeader
    Friend WithEvents ColumnHeader13 As ColumnHeader
    Friend WithEvents Search_TXT As TextBox
    Friend WithEvents Search_BTN As Button
    Friend WithEvents Paydate_ComboB As ComboBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents P_SSSLoan_LBL As Label
    Friend WithEvents P_SSSComp_LBL As Label
    Friend WithEvents P_GrossAmount_LBL As Label
    Friend WithEvents labelee As Label
    Friend WithEvents labell As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents P_NetPay_LBL As Label
    Friend WithEvents Label35 As Label
    Friend WithEvents P_Allowance_LBL As Label
    Friend WithEvents P_Deduction_LBL As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents P_PhilHComp_LBL As Label
    Friend WithEvents P_PagibigComp_LBL As Label
    Friend WithEvents Label36 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents P_PagibigLoan_LBL As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents P_TaxWH_LBL As Label
    Friend WithEvents Details_Save_BTN As Button
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader10 As ColumnHeader
    Friend WithEvents Payout_grid As DataGridView
    Friend WithEvents Name_dgv As DataGridViewTextBoxColumn
    Friend WithEvents basic_dgv As DataGridViewTextBoxColumn
    Friend WithEvents overtime_dgv As DataGridViewTextBoxColumn
    Friend WithEvents late_dgv As DataGridViewTextBoxColumn
    Friend WithEvents gross_dgv As DataGridViewTextBoxColumn
    Friend WithEvents sssDis_dgv As DataGridViewTextBoxColumn
    Friend WithEvents PagibigDis_dgv As DataGridViewTextBoxColumn
    Friend WithEvents philH_dgv As DataGridViewTextBoxColumn
    Friend WithEvents taxable_dgv As DataGridViewTextBoxColumn
    Friend WithEvents taxWH_dgv As DataGridViewTextBoxColumn
    Friend WithEvents netTax_dgv As DataGridViewTextBoxColumn
    Friend WithEvents sssLoan_dgv As DataGridViewTextBoxColumn
    Friend WithEvents pagibigLoan_dgv As DataGridViewTextBoxColumn
    Friend WithEvents allowance_dgv As DataGridViewTextBoxColumn
    Friend WithEvents deduction_dgv As DataGridViewTextBoxColumn
    Friend WithEvents netPay_dgv As DataGridViewTextBoxColumn
    Friend WithEvents Pay_Refresh_BTN As Button
    Friend WithEvents Prev_Amount_lbl As Label
    Friend WithEvents Prev_lbl As Label
    Friend WithEvents Previous_groupB As GroupBox
    Friend WithEvents ER_SSS As Label
    Friend WithEvents Label46 As Label
    Friend WithEvents Allowance_grid As DataGridView
    Friend WithEvents Deduction_grid As DataGridView
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents Label14 As Label
    Friend WithEvents BodyText_RichB As RichTextBox
    Friend WithEvents Send_BTN As Button
    Friend WithEvents ReportViewer_payslip As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents Employee_RadioB As RadioButton
    Friend WithEvents Branch_RadioB As RadioButton
    Friend WithEvents All_RadioB As RadioButton
    Friend WithEvents Label21 As Label
    Friend WithEvents Payslip_paydate_Combo As ComboBox
    Friend WithEvents Branch_group As GroupBox
    Friend WithEvents Branch_ComboB As ComboBox
    Friend WithEvents Employee_GroupB As GroupBox
    Friend WithEvents Preview_BTN As Button
    Friend WithEvents Email_TXT As TextBox
    Friend WithEvents Employee_TXT As TextBox
    Friend WithEvents EmpSelect_BTN As Button
    Friend WithEvents FlowLayoutPanel2 As FlowLayoutPanel
    Friend WithEvents Label18 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents grid_1 As DataGridViewTextBoxColumn
    Friend WithEvents grid_2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Deduc_BTN As DataGridViewButtonColumn
    Friend WithEvents Label23 As Label
End Class
