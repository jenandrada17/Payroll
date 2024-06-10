<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLoan
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
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim ReportDataSource4 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle27 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle28 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle29 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle30 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle31 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle32 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Close_LBL = New System.Windows.Forms.Label()
        Me.Loans_Tab = New System.Windows.Forms.TabControl()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DeductAmort_txt = New System.Windows.Forms.TextBox()
        Me.CategoryDeduc_txt = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DateCharges_DTP = New System.Windows.Forms.DateTimePicker()
        Me.Schedule_Combo = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Save_btn = New System.Windows.Forms.Button()
        Me.Cancel_btn = New System.Windows.Forms.Button()
        Me.Name_txt = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.PrincipalDeduc_txt = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Search_txt = New System.Windows.Forms.TextBox()
        Me.Search_btn = New System.Windows.Forms.Button()
        Me.Deduc_list = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Context_Deduct = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.PartialPaymentDeducMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_subtotal = New System.Windows.Forms.ToolStripMenuItem()
        Me.Balance_MenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_edit = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_remove = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.SSSPrincipal_TXT = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.SSSCancel_BTN = New System.Windows.Forms.Button()
        Me.SSS_Save_BTN = New System.Windows.Forms.Button()
        Me.SSS_Date_DTP = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.SSS_Search_TXT = New System.Windows.Forms.TextBox()
        Me.SSS_Search_BTN = New System.Windows.Forms.Button()
        Me.SSSLoan_LV = New System.Windows.Forms.ListView()
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader17 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader18 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Context_SSS = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.PartialPaymentSSSMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SSSSubtotal_Menu = New System.Windows.Forms.ToolStripMenuItem()
        Me.SSSBalance_Menu = New System.Windows.Forms.ToolStripMenuItem()
        Me.SSSEdit_Menu = New System.Windows.Forms.ToolStripMenuItem()
        Me.SSS_SearchEmp_BTN = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.SSS_Name_TXT = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.SSS_Amort_TXT = New System.Windows.Forms.TextBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Pagibig_List = New System.Windows.Forms.ListView()
        Me.ColumnHeader30 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader31 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader32 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader33 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Context_Pagibg = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.PartialPaymentPagMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PagSubTotal_Menu = New System.Windows.Forms.ToolStripMenuItem()
        Me.PagBalance_Menu = New System.Windows.Forms.ToolStripMenuItem()
        Me.PagEdit_Menu = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.PagPrincipal_TXT = New System.Windows.Forms.TextBox()
        Me.Pag_Cancel_BTN = New System.Windows.Forms.Button()
        Me.Pag_Save_BTN = New System.Windows.Forms.Button()
        Me.PagSearch_BTN = New System.Windows.Forms.Button()
        Me.PagDate_DTP = New System.Windows.Forms.DateTimePicker()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.PagSearch_TXT = New System.Windows.Forms.TextBox()
        Me.PagEmp_BTN = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.PagEmp_TXT = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.PagAmort_TXT = New System.Windows.Forms.TextBox()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Mp2Status_Combo = New System.Windows.Forms.ComboBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Mp2Sched_Combo = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Mp2Cancel_btn = New System.Windows.Forms.Button()
        Me.Mp2Save_btn = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Mp2Date_dtp = New System.Windows.Forms.DateTimePicker()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Mp2Search_txt = New System.Windows.Forms.TextBox()
        Me.Mp2Search_btn = New System.Windows.Forms.Button()
        Me.Mp2_List = New System.Windows.Forms.ListView()
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader24 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader25 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader26 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Context_Mp2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Mp2Edit_Menu = New System.Windows.Forms.ToolStripMenuItem()
        Me.Mp2Emp_btn = New System.Windows.Forms.Button()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Mp2Emp_txt = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Mp2Amort_txt = New System.Windows.Forms.TextBox()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.MaxStatus_Combo = New System.Windows.Forms.ComboBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.MaxSched_Combo = New System.Windows.Forms.ComboBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.MaxCancel_btn = New System.Windows.Forms.Button()
        Me.MaxSave_btn = New System.Windows.Forms.Button()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.MaxDate_dtp = New System.Windows.Forms.DateTimePicker()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.MaxSearch_txt = New System.Windows.Forms.TextBox()
        Me.MaxSearch_btn = New System.Windows.Forms.Button()
        Me.Maxicare_List = New System.Windows.Forms.ListView()
        Me.ColumnHeader22 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader27 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader28 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader29 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Context_Maxicare = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MaxEdit_Menu = New System.Windows.Forms.ToolStripMenuItem()
        Me.MaxEmp_btn = New System.Windows.Forms.Button()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.MaxEmp_txt = New System.Windows.Forms.TextBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.MaxAmort_txt = New System.Windows.Forms.TextBox()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.Context_SBU = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SBUEdit_Menu = New System.Windows.Forms.ToolStripMenuItem()
        Me.SBU_Search_txt = New System.Windows.Forms.TextBox()
        Me.SBU_Search_btn = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ScheduleSBU_Combo = New System.Windows.Forms.ComboBox()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.SBU_Amort_txt = New System.Windows.Forms.TextBox()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.SBU_Date_dtp = New System.Windows.Forms.DateTimePicker()
        Me.SBU_Save_btn = New System.Windows.Forms.Button()
        Me.SBU_Cancel_btn = New System.Windows.Forms.Button()
        Me.SBU_Name_txt = New System.Windows.Forms.TextBox()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.SBU_Principal_txt = New System.Windows.Forms.TextBox()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.SBU_SearchEmp_btn = New System.Windows.Forms.Button()
        Me.SBU_LV = New System.Windows.Forms.ListView()
        Me.ColumnHeader34 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader35 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader36 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader37 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader38 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabPage7 = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.cbStatus = New System.Windows.Forms.ComboBox()
        Me.txtSearchSOA = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.gridSOA = New System.Windows.Forms.DataGridView()
        Me.rpt_SOA = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.Partial_Panel = New System.Windows.Forms.Panel()
        Me.PartialName_txt = New System.Windows.Forms.TextBox()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.PartialCat_txt = New System.Windows.Forms.TextBox()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.PartialX_btn = New System.Windows.Forms.Button()
        Me.PartialCheck_btn = New System.Windows.Forms.Button()
        Me.PartialAmount_txt = New System.Windows.Forms.TextBox()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.ColumnHeader19 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader20 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader21 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader23 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader15 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader16 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.DE_Save_BTN = New System.Windows.Forms.Button()
        Me.DE_Total_TXT = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.DE_SearchEmp_BTN = New System.Windows.Forms.Button()
        Me.DE_NoOfGives_TXT = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.DE_Cancel_BTN = New System.Windows.Forms.Button()
        Me.DE_AmountGive_TXT = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.DE_Name_TXT = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.DE_Category_Combo = New System.Windows.Forms.ComboBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.DE_Schedule_Combo = New System.Windows.Forms.ComboBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.DE_Effectivity_DTP = New System.Windows.Forms.DateTimePicker()
        Me.lblAdd = New System.Windows.Forms.Label()
        Me.panelRemarksSOA = New System.Windows.Forms.Panel()
        Me.btnSaveSOA = New System.Windows.Forms.Button()
        Me.btnCancelSOA = New System.Windows.Forms.Button()
        Me.Label69 = New System.Windows.Forms.Label()
        Me.rbRemarksSOA = New System.Windows.Forms.RichTextBox()
        Me.dataFullname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dataDesignation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dataCompany = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dataStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dataDateEnded = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dataRemarks = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.dataAttachment = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Loans_Tab.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.Context_Deduct.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Context_SSS.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.Context_Pagibg.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.Context_Mp2.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.Context_Maxicare.SuspendLayout()
        Me.TabPage6.SuspendLayout()
        Me.Context_SBU.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage7.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.gridSOA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Partial_Panel.SuspendLayout()
        Me.panelRemarksSOA.SuspendLayout()
        Me.SuspendLayout()
        '
        'Close_LBL
        '
        Me.Close_LBL.AutoSize = True
        Me.Close_LBL.Font = New System.Drawing.Font("Dubai", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Close_LBL.Location = New System.Drawing.Point(1117, 2)
        Me.Close_LBL.Name = "Close_LBL"
        Me.Close_LBL.Size = New System.Drawing.Size(56, 32)
        Me.Close_LBL.TabIndex = 80
        Me.Close_LBL.Text = "Close"
        '
        'Loans_Tab
        '
        Me.Loans_Tab.Controls.Add(Me.TabPage2)
        Me.Loans_Tab.Controls.Add(Me.TabPage1)
        Me.Loans_Tab.Controls.Add(Me.TabPage3)
        Me.Loans_Tab.Controls.Add(Me.TabPage4)
        Me.Loans_Tab.Controls.Add(Me.TabPage5)
        Me.Loans_Tab.Controls.Add(Me.TabPage6)
        Me.Loans_Tab.Controls.Add(Me.TabPage7)
        Me.Loans_Tab.Font = New System.Drawing.Font("Dubai", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Loans_Tab.Location = New System.Drawing.Point(6, 32)
        Me.Loans_Tab.Name = "Loans_Tab"
        Me.Loans_Tab.SelectedIndex = 0
        Me.Loans_Tab.Size = New System.Drawing.Size(1155, 646)
        Me.Loans_Tab.TabIndex = 78
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Label40)
        Me.TabPage2.Controls.Add(Me.Label41)
        Me.TabPage2.Controls.Add(Me.GroupBox6)
        Me.TabPage2.Controls.Add(Me.Search_txt)
        Me.TabPage2.Controls.Add(Me.Search_btn)
        Me.TabPage2.Controls.Add(Me.Deduc_list)
        Me.TabPage2.Location = New System.Drawing.Point(4, 38)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(1147, 604)
        Me.TabPage2.TabIndex = 2
        Me.TabPage2.Text = "  Deductions  "
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(1098, 34)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(46, 27)
        Me.Label40.TabIndex = 163
        Me.Label40.Text = "PAID"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.BackColor = System.Drawing.Color.LightCoral
        Me.Label41.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(1064, 36)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(28, 22)
        Me.Label41.TabIndex = 162
        Me.Label41.Text = "      "
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Label2)
        Me.GroupBox6.Controls.Add(Me.DeductAmort_txt)
        Me.GroupBox6.Controls.Add(Me.CategoryDeduc_txt)
        Me.GroupBox6.Controls.Add(Me.Label3)
        Me.GroupBox6.Controls.Add(Me.DateCharges_DTP)
        Me.GroupBox6.Controls.Add(Me.Schedule_Combo)
        Me.GroupBox6.Controls.Add(Me.Label4)
        Me.GroupBox6.Controls.Add(Me.Save_btn)
        Me.GroupBox6.Controls.Add(Me.Cancel_btn)
        Me.GroupBox6.Controls.Add(Me.Name_txt)
        Me.GroupBox6.Controls.Add(Me.Label6)
        Me.GroupBox6.Controls.Add(Me.Label9)
        Me.GroupBox6.Controls.Add(Me.PrincipalDeduc_txt)
        Me.GroupBox6.Controls.Add(Me.Label8)
        Me.GroupBox6.Controls.Add(Me.Button2)
        Me.GroupBox6.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.Location = New System.Drawing.Point(4, 19)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(429, 445)
        Me.GroupBox6.TabIndex = 126
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Information"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(-1, 302)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 25)
        Me.Label2.TabIndex = 130
        Me.Label2.Text = "Amort"
        '
        'DeductAmort_txt
        '
        Me.DeductAmort_txt.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DeductAmort_txt.Location = New System.Drawing.Point(122, 298)
        Me.DeductAmort_txt.Name = "DeductAmort_txt"
        Me.DeductAmort_txt.Size = New System.Drawing.Size(238, 33)
        Me.DeductAmort_txt.TabIndex = 39
        '
        'CategoryDeduc_txt
        '
        Me.CategoryDeduc_txt.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CategoryDeduc_txt.Location = New System.Drawing.Point(75, 85)
        Me.CategoryDeduc_txt.Name = "CategoryDeduc_txt"
        Me.CategoryDeduc_txt.Size = New System.Drawing.Size(285, 33)
        Me.CategoryDeduc_txt.TabIndex = 35
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(-1, 194)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 25)
        Me.Label3.TabIndex = 127
        Me.Label3.Text = "Date"
        '
        'DateCharges_DTP
        '
        Me.DateCharges_DTP.Location = New System.Drawing.Point(122, 190)
        Me.DateCharges_DTP.Name = "DateCharges_DTP"
        Me.DateCharges_DTP.Size = New System.Drawing.Size(238, 29)
        Me.DateCharges_DTP.TabIndex = 37
        Me.DateCharges_DTP.Value = New Date(2022, 1, 6, 0, 0, 0, 0)
        '
        'Schedule_Combo
        '
        Me.Schedule_Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Schedule_Combo.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Schedule_Combo.FormattingEnabled = True
        Me.Schedule_Combo.Items.AddRange(New Object() {"OPEN PAYROLL", "CLOSE PAYROLL", "EVERY PAYROLL"})
        Me.Schedule_Combo.Location = New System.Drawing.Point(75, 138)
        Me.Schedule_Combo.Name = "Schedule_Combo"
        Me.Schedule_Combo.Size = New System.Drawing.Size(285, 33)
        Me.Schedule_Combo.TabIndex = 36
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(-1, 140)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 25)
        Me.Label4.TabIndex = 123
        Me.Label4.Text = "Schedule"
        '
        'Save_btn
        '
        Me.Save_btn.BackColor = System.Drawing.Color.DarkSalmon
        Me.Save_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Save_btn.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Save_btn.Location = New System.Drawing.Point(288, 391)
        Me.Save_btn.Name = "Save_btn"
        Me.Save_btn.Size = New System.Drawing.Size(102, 38)
        Me.Save_btn.TabIndex = 41
        Me.Save_btn.Text = "Save"
        Me.Save_btn.UseVisualStyleBackColor = False
        '
        'Cancel_btn
        '
        Me.Cancel_btn.BackColor = System.Drawing.Color.MistyRose
        Me.Cancel_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cancel_btn.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel_btn.Location = New System.Drawing.Point(77, 391)
        Me.Cancel_btn.Name = "Cancel_btn"
        Me.Cancel_btn.Size = New System.Drawing.Size(105, 38)
        Me.Cancel_btn.TabIndex = 40
        Me.Cancel_btn.Text = "Cancel"
        Me.Cancel_btn.UseVisualStyleBackColor = False
        '
        'Name_txt
        '
        Me.Name_txt.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name_txt.Location = New System.Drawing.Point(75, 35)
        Me.Name_txt.Name = "Name_txt"
        Me.Name_txt.ReadOnly = True
        Me.Name_txt.Size = New System.Drawing.Size(285, 33)
        Me.Name_txt.TabIndex = 109
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(-1, 87)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 25)
        Me.Label6.TabIndex = 110
        Me.Label6.Text = "Category"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(-1, 245)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(117, 25)
        Me.Label9.TabIndex = 108
        Me.Label9.Text = "Principal Amount"
        '
        'PrincipalDeduc_txt
        '
        Me.PrincipalDeduc_txt.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PrincipalDeduc_txt.Location = New System.Drawing.Point(122, 241)
        Me.PrincipalDeduc_txt.Name = "PrincipalDeduc_txt"
        Me.PrincipalDeduc_txt.Size = New System.Drawing.Size(238, 33)
        Me.PrincipalDeduc_txt.TabIndex = 38
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(-1, 37)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 25)
        Me.Label8.TabIndex = 111
        Me.Label8.Text = "Name"
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(372, 35)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(47, 31)
        Me.Button2.TabIndex = 34
        Me.Button2.Text = "..."
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Search_txt
        '
        Me.Search_txt.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Search_txt.Location = New System.Drawing.Point(449, 35)
        Me.Search_txt.Name = "Search_txt"
        Me.Search_txt.Size = New System.Drawing.Size(358, 33)
        Me.Search_txt.TabIndex = 42
        '
        'Search_btn
        '
        Me.Search_btn.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Search_btn.Location = New System.Drawing.Point(813, 34)
        Me.Search_btn.Name = "Search_btn"
        Me.Search_btn.Size = New System.Drawing.Size(82, 33)
        Me.Search_btn.TabIndex = 43
        Me.Search_btn.Text = "Search"
        Me.Search_btn.UseVisualStyleBackColor = True
        '
        'Deduc_list
        '
        Me.Deduc_list.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Deduc_list.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader6, Me.ColumnHeader5})
        Me.Deduc_list.ContextMenuStrip = Me.Context_Deduct
        Me.Deduc_list.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Deduc_list.FullRowSelect = True
        Me.Deduc_list.GridLines = True
        Me.Deduc_list.HideSelection = False
        Me.Deduc_list.Location = New System.Drawing.Point(450, 73)
        Me.Deduc_list.MultiSelect = False
        Me.Deduc_list.Name = "Deduc_list"
        Me.Deduc_list.Size = New System.Drawing.Size(695, 519)
        Me.Deduc_list.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.Deduc_list.TabIndex = 44
        Me.Deduc_list.UseCompatibleStateImageBehavior = False
        Me.Deduc_list.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Fullname"
        Me.ColumnHeader1.Width = 200
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Category"
        Me.ColumnHeader2.Width = 200
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Principal"
        Me.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader3.Width = 80
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Amort"
        Me.ColumnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader6.Width = 80
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Schedule"
        Me.ColumnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader5.Width = 110
        '
        'Context_Deduct
        '
        Me.Context_Deduct.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PartialPaymentDeducMenu, Me.menu_subtotal, Me.Balance_MenuItem, Me.menu_edit, Me.menu_remove})
        Me.Context_Deduct.Name = "Context_deduct"
        Me.Context_Deduct.Size = New System.Drawing.Size(157, 114)
        '
        'PartialPaymentDeducMenu
        '
        Me.PartialPaymentDeducMenu.Name = "PartialPaymentDeducMenu"
        Me.PartialPaymentDeducMenu.Size = New System.Drawing.Size(156, 22)
        Me.PartialPaymentDeducMenu.Text = "Partial Payment"
        '
        'menu_subtotal
        '
        Me.menu_subtotal.Name = "menu_subtotal"
        Me.menu_subtotal.Size = New System.Drawing.Size(156, 22)
        Me.menu_subtotal.Text = "View Subtotal"
        '
        'Balance_MenuItem
        '
        Me.Balance_MenuItem.Name = "Balance_MenuItem"
        Me.Balance_MenuItem.Size = New System.Drawing.Size(156, 22)
        Me.Balance_MenuItem.Text = "Balance"
        '
        'menu_edit
        '
        Me.menu_edit.Name = "menu_edit"
        Me.menu_edit.Size = New System.Drawing.Size(156, 22)
        Me.menu_edit.Text = "Edit"
        '
        'menu_remove
        '
        Me.menu_remove.Name = "menu_remove"
        Me.menu_remove.Size = New System.Drawing.Size(156, 22)
        Me.menu_remove.Text = "Remove"
        Me.menu_remove.Visible = False
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label38)
        Me.TabPage1.Controls.Add(Me.Label39)
        Me.TabPage1.Controls.Add(Me.Label25)
        Me.TabPage1.Controls.Add(Me.SSSPrincipal_TXT)
        Me.TabPage1.Controls.Add(Me.Label23)
        Me.TabPage1.Controls.Add(Me.SSSCancel_BTN)
        Me.TabPage1.Controls.Add(Me.SSS_Save_BTN)
        Me.TabPage1.Controls.Add(Me.SSS_Date_DTP)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.SSS_Search_TXT)
        Me.TabPage1.Controls.Add(Me.SSS_Search_BTN)
        Me.TabPage1.Controls.Add(Me.SSSLoan_LV)
        Me.TabPage1.Controls.Add(Me.SSS_SearchEmp_BTN)
        Me.TabPage1.Controls.Add(Me.Label14)
        Me.TabPage1.Controls.Add(Me.SSS_Name_TXT)
        Me.TabPage1.Controls.Add(Me.Label16)
        Me.TabPage1.Controls.Add(Me.SSS_Amort_TXT)
        Me.TabPage1.Location = New System.Drawing.Point(4, 38)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(1147, 604)
        Me.TabPage1.TabIndex = 8
        Me.TabPage1.Text = "    SSS Loan    "
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(1094, 15)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(46, 27)
        Me.Label38.TabIndex = 163
        Me.Label38.Text = "PAID"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.BackColor = System.Drawing.Color.LightCoral
        Me.Label39.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(1060, 17)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(28, 22)
        Me.Label39.TabIndex = 162
        Me.Label39.Text = "      "
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(7, 132)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(69, 27)
        Me.Label25.TabIndex = 148
        Me.Label25.Text = "Principal"
        '
        'SSSPrincipal_TXT
        '
        Me.SSSPrincipal_TXT.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SSSPrincipal_TXT.Location = New System.Drawing.Point(77, 128)
        Me.SSSPrincipal_TXT.Name = "SSSPrincipal_TXT"
        Me.SSSPrincipal_TXT.Size = New System.Drawing.Size(194, 33)
        Me.SSSPrincipal_TXT.TabIndex = 135
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(272, 199)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(54, 22)
        Me.Label23.TabIndex = 144
        Me.Label23.Text = "/Month"
        '
        'SSSCancel_BTN
        '
        Me.SSSCancel_BTN.BackColor = System.Drawing.Color.PeachPuff
        Me.SSSCancel_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SSSCancel_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SSSCancel_BTN.Location = New System.Drawing.Point(77, 394)
        Me.SSSCancel_BTN.Name = "SSSCancel_BTN"
        Me.SSSCancel_BTN.Size = New System.Drawing.Size(110, 47)
        Me.SSSCancel_BTN.TabIndex = 138
        Me.SSSCancel_BTN.Text = "Cancel"
        Me.SSSCancel_BTN.UseVisualStyleBackColor = False
        '
        'SSS_Save_BTN
        '
        Me.SSS_Save_BTN.BackColor = System.Drawing.Color.DarkSalmon
        Me.SSS_Save_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SSS_Save_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SSS_Save_BTN.Location = New System.Drawing.Point(271, 394)
        Me.SSS_Save_BTN.Name = "SSS_Save_BTN"
        Me.SSS_Save_BTN.Size = New System.Drawing.Size(110, 47)
        Me.SSS_Save_BTN.TabIndex = 139
        Me.SSS_Save_BTN.Text = "Save"
        Me.SSS_Save_BTN.UseVisualStyleBackColor = False
        '
        'SSS_Date_DTP
        '
        Me.SSS_Date_DTP.Font = New System.Drawing.Font("Dubai", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SSS_Date_DTP.Location = New System.Drawing.Point(77, 258)
        Me.SSS_Date_DTP.Name = "SSS_Date_DTP"
        Me.SSS_Date_DTP.Size = New System.Drawing.Size(304, 32)
        Me.SSS_Date_DTP.TabIndex = 137
        Me.SSS_Date_DTP.Value = New Date(2022, 1, 5, 0, 0, 0, 0)
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(7, 258)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(43, 27)
        Me.Label10.TabIndex = 140
        Me.Label10.Text = "Date"
        '
        'SSS_Search_TXT
        '
        Me.SSS_Search_TXT.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SSS_Search_TXT.Location = New System.Drawing.Point(473, 13)
        Me.SSS_Search_TXT.Name = "SSS_Search_TXT"
        Me.SSS_Search_TXT.Size = New System.Drawing.Size(312, 33)
        Me.SSS_Search_TXT.TabIndex = 140
        '
        'SSS_Search_BTN
        '
        Me.SSS_Search_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SSS_Search_BTN.Location = New System.Drawing.Point(791, 13)
        Me.SSS_Search_BTN.Name = "SSS_Search_BTN"
        Me.SSS_Search_BTN.Size = New System.Drawing.Size(82, 33)
        Me.SSS_Search_BTN.TabIndex = 141
        Me.SSS_Search_BTN.Text = "Search"
        Me.SSS_Search_BTN.UseVisualStyleBackColor = True
        '
        'SSSLoan_LV
        '
        Me.SSSLoan_LV.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SSSLoan_LV.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader17, Me.ColumnHeader18})
        Me.SSSLoan_LV.ContextMenuStrip = Me.Context_SSS
        Me.SSSLoan_LV.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SSSLoan_LV.FullRowSelect = True
        Me.SSSLoan_LV.GridLines = True
        Me.SSSLoan_LV.HideSelection = False
        Me.SSSLoan_LV.Location = New System.Drawing.Point(473, 52)
        Me.SSSLoan_LV.MultiSelect = False
        Me.SSSLoan_LV.Name = "SSSLoan_LV"
        Me.SSSLoan_LV.Size = New System.Drawing.Size(667, 539)
        Me.SSSLoan_LV.TabIndex = 135
        Me.SSSLoan_LV.UseCompatibleStateImageBehavior = False
        Me.SSSLoan_LV.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Fullname"
        Me.ColumnHeader9.Width = 250
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Principal"
        Me.ColumnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader10.Width = 135
        '
        'ColumnHeader17
        '
        Me.ColumnHeader17.Text = "Amort."
        Me.ColumnHeader17.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader17.Width = 130
        '
        'ColumnHeader18
        '
        Me.ColumnHeader18.Text = "Date"
        Me.ColumnHeader18.Width = 130
        '
        'Context_SSS
        '
        Me.Context_SSS.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PartialPaymentSSSMenuItem, Me.SSSSubtotal_Menu, Me.SSSBalance_Menu, Me.SSSEdit_Menu})
        Me.Context_SSS.Name = "Context_deduct"
        Me.Context_SSS.Size = New System.Drawing.Size(157, 92)
        '
        'PartialPaymentSSSMenuItem
        '
        Me.PartialPaymentSSSMenuItem.Name = "PartialPaymentSSSMenuItem"
        Me.PartialPaymentSSSMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.PartialPaymentSSSMenuItem.Text = "Partial Payment"
        '
        'SSSSubtotal_Menu
        '
        Me.SSSSubtotal_Menu.Name = "SSSSubtotal_Menu"
        Me.SSSSubtotal_Menu.Size = New System.Drawing.Size(156, 22)
        Me.SSSSubtotal_Menu.Text = "View Subtotal"
        '
        'SSSBalance_Menu
        '
        Me.SSSBalance_Menu.Name = "SSSBalance_Menu"
        Me.SSSBalance_Menu.Size = New System.Drawing.Size(156, 22)
        Me.SSSBalance_Menu.Text = "Balance"
        '
        'SSSEdit_Menu
        '
        Me.SSSEdit_Menu.Name = "SSSEdit_Menu"
        Me.SSSEdit_Menu.Size = New System.Drawing.Size(156, 22)
        Me.SSSEdit_Menu.Text = "Edit"
        '
        'SSS_SearchEmp_BTN
        '
        Me.SSS_SearchEmp_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SSS_SearchEmp_BTN.Location = New System.Drawing.Point(387, 64)
        Me.SSS_SearchEmp_BTN.Name = "SSS_SearchEmp_BTN"
        Me.SSS_SearchEmp_BTN.Size = New System.Drawing.Size(47, 31)
        Me.SSS_SearchEmp_BTN.TabIndex = 134
        Me.SSS_SearchEmp_BTN.Text = "..."
        Me.SSS_SearchEmp_BTN.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(7, 68)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(49, 27)
        Me.Label14.TabIndex = 133
        Me.Label14.Text = "Name"
        '
        'SSS_Name_TXT
        '
        Me.SSS_Name_TXT.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SSS_Name_TXT.Location = New System.Drawing.Point(77, 62)
        Me.SSS_Name_TXT.Name = "SSS_Name_TXT"
        Me.SSS_Name_TXT.ReadOnly = True
        Me.SSS_Name_TXT.Size = New System.Drawing.Size(304, 33)
        Me.SSS_Name_TXT.TabIndex = 132
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(7, 199)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(54, 27)
        Me.Label16.TabIndex = 131
        Me.Label16.Text = "Amort"
        '
        'SSS_Amort_TXT
        '
        Me.SSS_Amort_TXT.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SSS_Amort_TXT.Location = New System.Drawing.Point(77, 195)
        Me.SSS_Amort_TXT.Name = "SSS_Amort_TXT"
        Me.SSS_Amort_TXT.Size = New System.Drawing.Size(194, 33)
        Me.SSS_Amort_TXT.TabIndex = 136
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Label37)
        Me.TabPage3.Controls.Add(Me.Label12)
        Me.TabPage3.Controls.Add(Me.Pagibig_List)
        Me.TabPage3.Controls.Add(Me.Label27)
        Me.TabPage3.Controls.Add(Me.Label26)
        Me.TabPage3.Controls.Add(Me.PagPrincipal_TXT)
        Me.TabPage3.Controls.Add(Me.Pag_Cancel_BTN)
        Me.TabPage3.Controls.Add(Me.Pag_Save_BTN)
        Me.TabPage3.Controls.Add(Me.PagSearch_BTN)
        Me.TabPage3.Controls.Add(Me.PagDate_DTP)
        Me.TabPage3.Controls.Add(Me.Label13)
        Me.TabPage3.Controls.Add(Me.PagSearch_TXT)
        Me.TabPage3.Controls.Add(Me.PagEmp_BTN)
        Me.TabPage3.Controls.Add(Me.Label19)
        Me.TabPage3.Controls.Add(Me.PagEmp_TXT)
        Me.TabPage3.Controls.Add(Me.Label21)
        Me.TabPage3.Controls.Add(Me.PagAmort_TXT)
        Me.TabPage3.Location = New System.Drawing.Point(4, 38)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(1147, 604)
        Me.TabPage3.TabIndex = 9
        Me.TabPage3.Text = "    Pagibig Loan    "
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(1094, 19)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(46, 27)
        Me.Label37.TabIndex = 161
        Me.Label37.Text = "PAID"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.LightCoral
        Me.Label12.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(1060, 21)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(28, 22)
        Me.Label12.TabIndex = 160
        Me.Label12.Text = "      "
        '
        'Pagibig_List
        '
        Me.Pagibig_List.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Pagibig_List.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader30, Me.ColumnHeader31, Me.ColumnHeader32, Me.ColumnHeader33})
        Me.Pagibig_List.ContextMenuStrip = Me.Context_Pagibg
        Me.Pagibig_List.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pagibig_List.FullRowSelect = True
        Me.Pagibig_List.GridLines = True
        Me.Pagibig_List.HideSelection = False
        Me.Pagibig_List.Location = New System.Drawing.Point(473, 59)
        Me.Pagibig_List.MultiSelect = False
        Me.Pagibig_List.Name = "Pagibig_List"
        Me.Pagibig_List.Size = New System.Drawing.Size(667, 539)
        Me.Pagibig_List.TabIndex = 159
        Me.Pagibig_List.UseCompatibleStateImageBehavior = False
        Me.Pagibig_List.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader30
        '
        Me.ColumnHeader30.Text = "Fullname"
        Me.ColumnHeader30.Width = 250
        '
        'ColumnHeader31
        '
        Me.ColumnHeader31.Text = "Principal"
        Me.ColumnHeader31.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader31.Width = 135
        '
        'ColumnHeader32
        '
        Me.ColumnHeader32.Text = "Amort."
        Me.ColumnHeader32.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader32.Width = 130
        '
        'ColumnHeader33
        '
        Me.ColumnHeader33.Text = "Date"
        Me.ColumnHeader33.Width = 130
        '
        'Context_Pagibg
        '
        Me.Context_Pagibg.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PartialPaymentPagMenuItem, Me.PagSubTotal_Menu, Me.PagBalance_Menu, Me.PagEdit_Menu})
        Me.Context_Pagibg.Name = "Context_deduct"
        Me.Context_Pagibg.Size = New System.Drawing.Size(157, 92)
        '
        'PartialPaymentPagMenuItem
        '
        Me.PartialPaymentPagMenuItem.Name = "PartialPaymentPagMenuItem"
        Me.PartialPaymentPagMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.PartialPaymentPagMenuItem.Text = "Partial Payment"
        '
        'PagSubTotal_Menu
        '
        Me.PagSubTotal_Menu.Name = "PagSubTotal_Menu"
        Me.PagSubTotal_Menu.Size = New System.Drawing.Size(156, 22)
        Me.PagSubTotal_Menu.Text = "View Subtotal"
        '
        'PagBalance_Menu
        '
        Me.PagBalance_Menu.Name = "PagBalance_Menu"
        Me.PagBalance_Menu.Size = New System.Drawing.Size(156, 22)
        Me.PagBalance_Menu.Text = "Balance"
        '
        'PagEdit_Menu
        '
        Me.PagEdit_Menu.Name = "PagEdit_Menu"
        Me.PagEdit_Menu.Size = New System.Drawing.Size(156, 22)
        Me.PagEdit_Menu.Text = "Edit"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(273, 199)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(54, 22)
        Me.Label27.TabIndex = 158
        Me.Label27.Text = "/Month"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(7, 133)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(69, 27)
        Me.Label26.TabIndex = 157
        Me.Label26.Text = "Principal"
        '
        'PagPrincipal_TXT
        '
        Me.PagPrincipal_TXT.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PagPrincipal_TXT.Location = New System.Drawing.Point(77, 129)
        Me.PagPrincipal_TXT.Name = "PagPrincipal_TXT"
        Me.PagPrincipal_TXT.Size = New System.Drawing.Size(194, 33)
        Me.PagPrincipal_TXT.TabIndex = 148
        '
        'Pag_Cancel_BTN
        '
        Me.Pag_Cancel_BTN.BackColor = System.Drawing.Color.PeachPuff
        Me.Pag_Cancel_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Pag_Cancel_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pag_Cancel_BTN.Location = New System.Drawing.Point(79, 390)
        Me.Pag_Cancel_BTN.Name = "Pag_Cancel_BTN"
        Me.Pag_Cancel_BTN.Size = New System.Drawing.Size(106, 39)
        Me.Pag_Cancel_BTN.TabIndex = 151
        Me.Pag_Cancel_BTN.Text = "Cancel"
        Me.Pag_Cancel_BTN.UseVisualStyleBackColor = False
        '
        'Pag_Save_BTN
        '
        Me.Pag_Save_BTN.BackColor = System.Drawing.Color.DarkSalmon
        Me.Pag_Save_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Pag_Save_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pag_Save_BTN.Location = New System.Drawing.Point(275, 390)
        Me.Pag_Save_BTN.Name = "Pag_Save_BTN"
        Me.Pag_Save_BTN.Size = New System.Drawing.Size(106, 39)
        Me.Pag_Save_BTN.TabIndex = 152
        Me.Pag_Save_BTN.Text = "Save"
        Me.Pag_Save_BTN.UseVisualStyleBackColor = False
        '
        'PagSearch_BTN
        '
        Me.PagSearch_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PagSearch_BTN.Location = New System.Drawing.Point(786, 13)
        Me.PagSearch_BTN.Name = "PagSearch_BTN"
        Me.PagSearch_BTN.Size = New System.Drawing.Size(82, 33)
        Me.PagSearch_BTN.TabIndex = 154
        Me.PagSearch_BTN.Text = "Search"
        Me.PagSearch_BTN.UseVisualStyleBackColor = True
        '
        'PagDate_DTP
        '
        Me.PagDate_DTP.Font = New System.Drawing.Font("Dubai", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PagDate_DTP.Location = New System.Drawing.Point(77, 263)
        Me.PagDate_DTP.Name = "PagDate_DTP"
        Me.PagDate_DTP.Size = New System.Drawing.Size(304, 32)
        Me.PagDate_DTP.TabIndex = 149
        Me.PagDate_DTP.Value = New Date(2021, 8, 27, 21, 55, 17, 0)
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(7, 263)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(43, 27)
        Me.Label13.TabIndex = 149
        Me.Label13.Text = "Date"
        '
        'PagSearch_TXT
        '
        Me.PagSearch_TXT.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PagSearch_TXT.Location = New System.Drawing.Point(473, 13)
        Me.PagSearch_TXT.Name = "PagSearch_TXT"
        Me.PagSearch_TXT.Size = New System.Drawing.Size(307, 33)
        Me.PagSearch_TXT.TabIndex = 153
        '
        'PagEmp_BTN
        '
        Me.PagEmp_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PagEmp_BTN.Location = New System.Drawing.Point(387, 64)
        Me.PagEmp_BTN.Name = "PagEmp_BTN"
        Me.PagEmp_BTN.Size = New System.Drawing.Size(47, 31)
        Me.PagEmp_BTN.TabIndex = 146
        Me.PagEmp_BTN.Text = "..."
        Me.PagEmp_BTN.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(7, 68)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(49, 27)
        Me.Label19.TabIndex = 145
        Me.Label19.Text = "Name"
        '
        'PagEmp_TXT
        '
        Me.PagEmp_TXT.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PagEmp_TXT.Location = New System.Drawing.Point(77, 62)
        Me.PagEmp_TXT.Name = "PagEmp_TXT"
        Me.PagEmp_TXT.ReadOnly = True
        Me.PagEmp_TXT.Size = New System.Drawing.Size(304, 33)
        Me.PagEmp_TXT.TabIndex = 144
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(7, 194)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(54, 27)
        Me.Label21.TabIndex = 143
        Me.Label21.Text = "Amort"
        '
        'PagAmort_TXT
        '
        Me.PagAmort_TXT.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PagAmort_TXT.Location = New System.Drawing.Point(77, 194)
        Me.PagAmort_TXT.Name = "PagAmort_TXT"
        Me.PagAmort_TXT.Size = New System.Drawing.Size(194, 33)
        Me.PagAmort_TXT.TabIndex = 147
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.Label44)
        Me.TabPage4.Controls.Add(Me.Label45)
        Me.TabPage4.Controls.Add(Me.Mp2Status_Combo)
        Me.TabPage4.Controls.Add(Me.Label42)
        Me.TabPage4.Controls.Add(Me.Mp2Sched_Combo)
        Me.TabPage4.Controls.Add(Me.Label7)
        Me.TabPage4.Controls.Add(Me.Mp2Cancel_btn)
        Me.TabPage4.Controls.Add(Me.Mp2Save_btn)
        Me.TabPage4.Controls.Add(Me.Label11)
        Me.TabPage4.Controls.Add(Me.Mp2Date_dtp)
        Me.TabPage4.Controls.Add(Me.Label24)
        Me.TabPage4.Controls.Add(Me.Mp2Search_txt)
        Me.TabPage4.Controls.Add(Me.Mp2Search_btn)
        Me.TabPage4.Controls.Add(Me.Mp2_List)
        Me.TabPage4.Controls.Add(Me.Mp2Emp_btn)
        Me.TabPage4.Controls.Add(Me.Label29)
        Me.TabPage4.Controls.Add(Me.Mp2Emp_txt)
        Me.TabPage4.Controls.Add(Me.Label30)
        Me.TabPage4.Controls.Add(Me.Mp2Amort_txt)
        Me.TabPage4.Location = New System.Drawing.Point(4, 38)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(1147, 604)
        Me.TabPage4.TabIndex = 10
        Me.TabPage4.Text = "     MP2     "
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.Location = New System.Drawing.Point(1094, 13)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(39, 27)
        Me.Label44.TabIndex = 186
        Me.Label44.Text = "OFF"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.BackColor = System.Drawing.Color.LightCoral
        Me.Label45.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.Location = New System.Drawing.Point(1060, 15)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(28, 22)
        Me.Label45.TabIndex = 185
        Me.Label45.Text = "      "
        '
        'Mp2Status_Combo
        '
        Me.Mp2Status_Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Mp2Status_Combo.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Mp2Status_Combo.FormattingEnabled = True
        Me.Mp2Status_Combo.Items.AddRange(New Object() {"ON", "OFF"})
        Me.Mp2Status_Combo.Location = New System.Drawing.Point(77, 314)
        Me.Mp2Status_Combo.Name = "Mp2Status_Combo"
        Me.Mp2Status_Combo.Size = New System.Drawing.Size(121, 33)
        Me.Mp2Status_Combo.TabIndex = 184
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.Location = New System.Drawing.Point(7, 316)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(55, 27)
        Me.Label42.TabIndex = 166
        Me.Label42.Text = "Status"
        '
        'Mp2Sched_Combo
        '
        Me.Mp2Sched_Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Mp2Sched_Combo.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Mp2Sched_Combo.FormattingEnabled = True
        Me.Mp2Sched_Combo.Items.AddRange(New Object() {"OPEN PAYROLL", "CLOSE PAYROLL", "EVERY PAYROLL"})
        Me.Mp2Sched_Combo.Location = New System.Drawing.Point(77, 188)
        Me.Mp2Sched_Combo.Name = "Mp2Sched_Combo"
        Me.Mp2Sched_Combo.Size = New System.Drawing.Size(285, 33)
        Me.Mp2Sched_Combo.TabIndex = 163
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(1, 190)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 25)
        Me.Label7.TabIndex = 164
        Me.Label7.Text = "Schedule"
        '
        'Mp2Cancel_btn
        '
        Me.Mp2Cancel_btn.BackColor = System.Drawing.Color.PeachPuff
        Me.Mp2Cancel_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Mp2Cancel_btn.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Mp2Cancel_btn.Location = New System.Drawing.Point(71, 408)
        Me.Mp2Cancel_btn.Name = "Mp2Cancel_btn"
        Me.Mp2Cancel_btn.Size = New System.Drawing.Size(116, 43)
        Me.Mp2Cancel_btn.TabIndex = 161
        Me.Mp2Cancel_btn.Text = "Cancel"
        Me.Mp2Cancel_btn.UseVisualStyleBackColor = False
        '
        'Mp2Save_btn
        '
        Me.Mp2Save_btn.BackColor = System.Drawing.Color.DarkSalmon
        Me.Mp2Save_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Mp2Save_btn.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Mp2Save_btn.Location = New System.Drawing.Point(289, 408)
        Me.Mp2Save_btn.Name = "Mp2Save_btn"
        Me.Mp2Save_btn.Size = New System.Drawing.Size(110, 43)
        Me.Mp2Save_btn.TabIndex = 162
        Me.Mp2Save_btn.Text = "Save"
        Me.Mp2Save_btn.UseVisualStyleBackColor = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(272, 254)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(54, 22)
        Me.Label11.TabIndex = 160
        Me.Label11.Text = "/Month"
        '
        'Mp2Date_dtp
        '
        Me.Mp2Date_dtp.Font = New System.Drawing.Font("Dubai", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Mp2Date_dtp.Location = New System.Drawing.Point(77, 128)
        Me.Mp2Date_dtp.Name = "Mp2Date_dtp"
        Me.Mp2Date_dtp.Size = New System.Drawing.Size(304, 32)
        Me.Mp2Date_dtp.TabIndex = 156
        Me.Mp2Date_dtp.Value = New Date(2022, 1, 5, 0, 0, 0, 0)
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(7, 128)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(43, 27)
        Me.Label24.TabIndex = 157
        Me.Label24.Text = "Date"
        '
        'Mp2Search_txt
        '
        Me.Mp2Search_txt.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Mp2Search_txt.Location = New System.Drawing.Point(462, 13)
        Me.Mp2Search_txt.Name = "Mp2Search_txt"
        Me.Mp2Search_txt.Size = New System.Drawing.Size(408, 33)
        Me.Mp2Search_txt.TabIndex = 158
        '
        'Mp2Search_btn
        '
        Me.Mp2Search_btn.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Mp2Search_btn.Location = New System.Drawing.Point(887, 13)
        Me.Mp2Search_btn.Name = "Mp2Search_btn"
        Me.Mp2Search_btn.Size = New System.Drawing.Size(82, 33)
        Me.Mp2Search_btn.TabIndex = 159
        Me.Mp2Search_btn.Text = "Search"
        Me.Mp2Search_btn.UseVisualStyleBackColor = True
        '
        'Mp2_List
        '
        Me.Mp2_List.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Mp2_List.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader7, Me.ColumnHeader24, Me.ColumnHeader25, Me.ColumnHeader26})
        Me.Mp2_List.ContextMenuStrip = Me.Context_Mp2
        Me.Mp2_List.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Mp2_List.FullRowSelect = True
        Me.Mp2_List.GridLines = True
        Me.Mp2_List.HideSelection = False
        Me.Mp2_List.Location = New System.Drawing.Point(462, 52)
        Me.Mp2_List.MultiSelect = False
        Me.Mp2_List.Name = "Mp2_List"
        Me.Mp2_List.Size = New System.Drawing.Size(678, 539)
        Me.Mp2_List.TabIndex = 154
        Me.Mp2_List.UseCompatibleStateImageBehavior = False
        Me.Mp2_List.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Fullname"
        Me.ColumnHeader7.Width = 250
        '
        'ColumnHeader24
        '
        Me.ColumnHeader24.Text = "Amort."
        Me.ColumnHeader24.Width = 130
        '
        'ColumnHeader25
        '
        Me.ColumnHeader25.Text = "Date"
        Me.ColumnHeader25.Width = 140
        '
        'ColumnHeader26
        '
        Me.ColumnHeader26.Text = "Schedule"
        Me.ColumnHeader26.Width = 130
        '
        'Context_Mp2
        '
        Me.Context_Mp2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Mp2Edit_Menu})
        Me.Context_Mp2.Name = "Context_deduct"
        Me.Context_Mp2.Size = New System.Drawing.Size(95, 26)
        '
        'Mp2Edit_Menu
        '
        Me.Mp2Edit_Menu.Name = "Mp2Edit_Menu"
        Me.Mp2Edit_Menu.Size = New System.Drawing.Size(94, 22)
        Me.Mp2Edit_Menu.Text = "Edit"
        '
        'Mp2Emp_btn
        '
        Me.Mp2Emp_btn.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Mp2Emp_btn.Location = New System.Drawing.Point(387, 64)
        Me.Mp2Emp_btn.Name = "Mp2Emp_btn"
        Me.Mp2Emp_btn.Size = New System.Drawing.Size(47, 31)
        Me.Mp2Emp_btn.TabIndex = 152
        Me.Mp2Emp_btn.Text = "..."
        Me.Mp2Emp_btn.UseVisualStyleBackColor = True
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(7, 68)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(49, 27)
        Me.Label29.TabIndex = 151
        Me.Label29.Text = "Name"
        '
        'Mp2Emp_txt
        '
        Me.Mp2Emp_txt.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Mp2Emp_txt.Location = New System.Drawing.Point(77, 62)
        Me.Mp2Emp_txt.Name = "Mp2Emp_txt"
        Me.Mp2Emp_txt.ReadOnly = True
        Me.Mp2Emp_txt.Size = New System.Drawing.Size(304, 33)
        Me.Mp2Emp_txt.TabIndex = 150
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(7, 254)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(54, 27)
        Me.Label30.TabIndex = 149
        Me.Label30.Text = "Amort"
        '
        'Mp2Amort_txt
        '
        Me.Mp2Amort_txt.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Mp2Amort_txt.Location = New System.Drawing.Point(77, 250)
        Me.Mp2Amort_txt.Name = "Mp2Amort_txt"
        Me.Mp2Amort_txt.Size = New System.Drawing.Size(194, 33)
        Me.Mp2Amort_txt.TabIndex = 155
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.Label46)
        Me.TabPage5.Controls.Add(Me.Label47)
        Me.TabPage5.Controls.Add(Me.MaxStatus_Combo)
        Me.TabPage5.Controls.Add(Me.Label43)
        Me.TabPage5.Controls.Add(Me.MaxSched_Combo)
        Me.TabPage5.Controls.Add(Me.Label32)
        Me.TabPage5.Controls.Add(Me.MaxCancel_btn)
        Me.TabPage5.Controls.Add(Me.MaxSave_btn)
        Me.TabPage5.Controls.Add(Me.Label33)
        Me.TabPage5.Controls.Add(Me.MaxDate_dtp)
        Me.TabPage5.Controls.Add(Me.Label34)
        Me.TabPage5.Controls.Add(Me.MaxSearch_txt)
        Me.TabPage5.Controls.Add(Me.MaxSearch_btn)
        Me.TabPage5.Controls.Add(Me.Maxicare_List)
        Me.TabPage5.Controls.Add(Me.MaxEmp_btn)
        Me.TabPage5.Controls.Add(Me.Label35)
        Me.TabPage5.Controls.Add(Me.MaxEmp_txt)
        Me.TabPage5.Controls.Add(Me.Label36)
        Me.TabPage5.Controls.Add(Me.MaxAmort_txt)
        Me.TabPage5.Location = New System.Drawing.Point(4, 38)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(1147, 604)
        Me.TabPage5.TabIndex = 11
        Me.TabPage5.Text = "     Maxicare     "
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.Location = New System.Drawing.Point(1104, 13)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(39, 27)
        Me.Label46.TabIndex = 188
        Me.Label46.Text = "OFF"
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.BackColor = System.Drawing.Color.LightCoral
        Me.Label47.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label47.Location = New System.Drawing.Point(1070, 15)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(28, 22)
        Me.Label47.TabIndex = 187
        Me.Label47.Text = "      "
        '
        'MaxStatus_Combo
        '
        Me.MaxStatus_Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MaxStatus_Combo.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaxStatus_Combo.FormattingEnabled = True
        Me.MaxStatus_Combo.Items.AddRange(New Object() {"ON", "OFF"})
        Me.MaxStatus_Combo.Location = New System.Drawing.Point(80, 315)
        Me.MaxStatus_Combo.Name = "MaxStatus_Combo"
        Me.MaxStatus_Combo.Size = New System.Drawing.Size(121, 33)
        Me.MaxStatus_Combo.TabIndex = 183
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.Location = New System.Drawing.Point(9, 317)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(55, 27)
        Me.Label43.TabIndex = 181
        Me.Label43.Text = "Status"
        '
        'MaxSched_Combo
        '
        Me.MaxSched_Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MaxSched_Combo.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaxSched_Combo.FormattingEnabled = True
        Me.MaxSched_Combo.Items.AddRange(New Object() {"OPEN PAYROLL", "CLOSE PAYROLL", "EVERY PAYROLL"})
        Me.MaxSched_Combo.Location = New System.Drawing.Point(80, 188)
        Me.MaxSched_Combo.Name = "MaxSched_Combo"
        Me.MaxSched_Combo.Size = New System.Drawing.Size(304, 33)
        Me.MaxSched_Combo.TabIndex = 178
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(4, 190)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(67, 25)
        Me.Label32.TabIndex = 179
        Me.Label32.Text = "Schedule"
        '
        'MaxCancel_btn
        '
        Me.MaxCancel_btn.BackColor = System.Drawing.Color.PeachPuff
        Me.MaxCancel_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.MaxCancel_btn.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaxCancel_btn.Location = New System.Drawing.Point(82, 406)
        Me.MaxCancel_btn.Name = "MaxCancel_btn"
        Me.MaxCancel_btn.Size = New System.Drawing.Size(119, 43)
        Me.MaxCancel_btn.TabIndex = 176
        Me.MaxCancel_btn.Text = "Cancel"
        Me.MaxCancel_btn.UseVisualStyleBackColor = False
        '
        'MaxSave_btn
        '
        Me.MaxSave_btn.BackColor = System.Drawing.Color.DarkSalmon
        Me.MaxSave_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.MaxSave_btn.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaxSave_btn.Location = New System.Drawing.Point(301, 406)
        Me.MaxSave_btn.Name = "MaxSave_btn"
        Me.MaxSave_btn.Size = New System.Drawing.Size(109, 43)
        Me.MaxSave_btn.TabIndex = 177
        Me.MaxSave_btn.Text = "Save"
        Me.MaxSave_btn.UseVisualStyleBackColor = False
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(275, 254)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(54, 22)
        Me.Label33.TabIndex = 175
        Me.Label33.Text = "/Month"
        '
        'MaxDate_dtp
        '
        Me.MaxDate_dtp.Font = New System.Drawing.Font("Dubai", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaxDate_dtp.Location = New System.Drawing.Point(80, 128)
        Me.MaxDate_dtp.Name = "MaxDate_dtp"
        Me.MaxDate_dtp.Size = New System.Drawing.Size(304, 32)
        Me.MaxDate_dtp.TabIndex = 171
        Me.MaxDate_dtp.Value = New Date(2022, 1, 5, 0, 0, 0, 0)
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(10, 128)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(43, 27)
        Me.Label34.TabIndex = 172
        Me.Label34.Text = "Date"
        '
        'MaxSearch_txt
        '
        Me.MaxSearch_txt.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaxSearch_txt.Location = New System.Drawing.Point(465, 13)
        Me.MaxSearch_txt.Name = "MaxSearch_txt"
        Me.MaxSearch_txt.Size = New System.Drawing.Size(408, 33)
        Me.MaxSearch_txt.TabIndex = 173
        '
        'MaxSearch_btn
        '
        Me.MaxSearch_btn.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaxSearch_btn.Location = New System.Drawing.Point(890, 13)
        Me.MaxSearch_btn.Name = "MaxSearch_btn"
        Me.MaxSearch_btn.Size = New System.Drawing.Size(82, 33)
        Me.MaxSearch_btn.TabIndex = 174
        Me.MaxSearch_btn.Text = "Search"
        Me.MaxSearch_btn.UseVisualStyleBackColor = True
        '
        'Maxicare_List
        '
        Me.Maxicare_List.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Maxicare_List.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader22, Me.ColumnHeader27, Me.ColumnHeader28, Me.ColumnHeader29})
        Me.Maxicare_List.ContextMenuStrip = Me.Context_Maxicare
        Me.Maxicare_List.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Maxicare_List.FullRowSelect = True
        Me.Maxicare_List.GridLines = True
        Me.Maxicare_List.HideSelection = False
        Me.Maxicare_List.Location = New System.Drawing.Point(465, 52)
        Me.Maxicare_List.MultiSelect = False
        Me.Maxicare_List.Name = "Maxicare_List"
        Me.Maxicare_List.Size = New System.Drawing.Size(678, 539)
        Me.Maxicare_List.TabIndex = 169
        Me.Maxicare_List.UseCompatibleStateImageBehavior = False
        Me.Maxicare_List.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader22
        '
        Me.ColumnHeader22.Text = "Fullname"
        Me.ColumnHeader22.Width = 250
        '
        'ColumnHeader27
        '
        Me.ColumnHeader27.Text = "Amort."
        Me.ColumnHeader27.Width = 130
        '
        'ColumnHeader28
        '
        Me.ColumnHeader28.Text = "Date"
        Me.ColumnHeader28.Width = 140
        '
        'ColumnHeader29
        '
        Me.ColumnHeader29.Text = "Schedule"
        Me.ColumnHeader29.Width = 130
        '
        'Context_Maxicare
        '
        Me.Context_Maxicare.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MaxEdit_Menu})
        Me.Context_Maxicare.Name = "Context_deduct"
        Me.Context_Maxicare.Size = New System.Drawing.Size(95, 26)
        '
        'MaxEdit_Menu
        '
        Me.MaxEdit_Menu.Name = "MaxEdit_Menu"
        Me.MaxEdit_Menu.Size = New System.Drawing.Size(94, 22)
        Me.MaxEdit_Menu.Text = "Edit"
        '
        'MaxEmp_btn
        '
        Me.MaxEmp_btn.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaxEmp_btn.Location = New System.Drawing.Point(390, 64)
        Me.MaxEmp_btn.Name = "MaxEmp_btn"
        Me.MaxEmp_btn.Size = New System.Drawing.Size(47, 31)
        Me.MaxEmp_btn.TabIndex = 168
        Me.MaxEmp_btn.Text = "..."
        Me.MaxEmp_btn.UseVisualStyleBackColor = True
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(10, 68)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(49, 27)
        Me.Label35.TabIndex = 167
        Me.Label35.Text = "Name"
        '
        'MaxEmp_txt
        '
        Me.MaxEmp_txt.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaxEmp_txt.Location = New System.Drawing.Point(80, 62)
        Me.MaxEmp_txt.Name = "MaxEmp_txt"
        Me.MaxEmp_txt.ReadOnly = True
        Me.MaxEmp_txt.Size = New System.Drawing.Size(304, 33)
        Me.MaxEmp_txt.TabIndex = 166
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(10, 254)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(54, 27)
        Me.Label36.TabIndex = 165
        Me.Label36.Text = "Amort"
        '
        'MaxAmort_txt
        '
        Me.MaxAmort_txt.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaxAmort_txt.Location = New System.Drawing.Point(80, 250)
        Me.MaxAmort_txt.Name = "MaxAmort_txt"
        Me.MaxAmort_txt.Size = New System.Drawing.Size(194, 33)
        Me.MaxAmort_txt.TabIndex = 170
        '
        'TabPage6
        '
        Me.TabPage6.ContextMenuStrip = Me.Context_SBU
        Me.TabPage6.Controls.Add(Me.SBU_Search_txt)
        Me.TabPage6.Controls.Add(Me.SBU_Search_btn)
        Me.TabPage6.Controls.Add(Me.GroupBox1)
        Me.TabPage6.Controls.Add(Me.SBU_LV)
        Me.TabPage6.Location = New System.Drawing.Point(4, 38)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage6.Size = New System.Drawing.Size(1147, 604)
        Me.TabPage6.TabIndex = 12
        Me.TabPage6.Text = "        SBU        "
        Me.TabPage6.UseVisualStyleBackColor = True
        '
        'Context_SBU
        '
        Me.Context_SBU.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SBUEdit_Menu})
        Me.Context_SBU.Name = "Context_deduct"
        Me.Context_SBU.Size = New System.Drawing.Size(95, 26)
        '
        'SBUEdit_Menu
        '
        Me.SBUEdit_Menu.Name = "SBUEdit_Menu"
        Me.SBUEdit_Menu.Size = New System.Drawing.Size(94, 22)
        Me.SBUEdit_Menu.Text = "Edit"
        '
        'SBU_Search_txt
        '
        Me.SBU_Search_txt.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SBU_Search_txt.Location = New System.Drawing.Point(466, 33)
        Me.SBU_Search_txt.Name = "SBU_Search_txt"
        Me.SBU_Search_txt.Size = New System.Drawing.Size(358, 33)
        Me.SBU_Search_txt.TabIndex = 129
        '
        'SBU_Search_btn
        '
        Me.SBU_Search_btn.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SBU_Search_btn.Location = New System.Drawing.Point(830, 32)
        Me.SBU_Search_btn.Name = "SBU_Search_btn"
        Me.SBU_Search_btn.Size = New System.Drawing.Size(82, 33)
        Me.SBU_Search_btn.TabIndex = 130
        Me.SBU_Search_btn.Text = "Search"
        Me.SBU_Search_btn.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ScheduleSBU_Combo)
        Me.GroupBox1.Controls.Add(Me.Label55)
        Me.GroupBox1.Controls.Add(Me.Label53)
        Me.GroupBox1.Controls.Add(Me.SBU_Amort_txt)
        Me.GroupBox1.Controls.Add(Me.Label54)
        Me.GroupBox1.Controls.Add(Me.SBU_Date_dtp)
        Me.GroupBox1.Controls.Add(Me.SBU_Save_btn)
        Me.GroupBox1.Controls.Add(Me.SBU_Cancel_btn)
        Me.GroupBox1.Controls.Add(Me.SBU_Name_txt)
        Me.GroupBox1.Controls.Add(Me.Label57)
        Me.GroupBox1.Controls.Add(Me.SBU_Principal_txt)
        Me.GroupBox1.Controls.Add(Me.Label58)
        Me.GroupBox1.Controls.Add(Me.SBU_SearchEmp_btn)
        Me.GroupBox1.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(16, 22)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(429, 382)
        Me.GroupBox1.TabIndex = 127
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Information"
        '
        'ScheduleSBU_Combo
        '
        Me.ScheduleSBU_Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ScheduleSBU_Combo.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ScheduleSBU_Combo.FormattingEnabled = True
        Me.ScheduleSBU_Combo.Items.AddRange(New Object() {"OPEN PAYROLL", "CLOSE PAYROLL", "EVERY PAYROLL"})
        Me.ScheduleSBU_Combo.Location = New System.Drawing.Point(122, 261)
        Me.ScheduleSBU_Combo.Name = "ScheduleSBU_Combo"
        Me.ScheduleSBU_Combo.Size = New System.Drawing.Size(238, 33)
        Me.ScheduleSBU_Combo.TabIndex = 131
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label55.Location = New System.Drawing.Point(-1, 263)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(67, 25)
        Me.Label55.TabIndex = 132
        Me.Label55.Text = "Schedule"
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label53.Location = New System.Drawing.Point(-1, 207)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(51, 25)
        Me.Label53.TabIndex = 130
        Me.Label53.Text = "Amort"
        '
        'SBU_Amort_txt
        '
        Me.SBU_Amort_txt.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SBU_Amort_txt.Location = New System.Drawing.Point(122, 203)
        Me.SBU_Amort_txt.Name = "SBU_Amort_txt"
        Me.SBU_Amort_txt.Size = New System.Drawing.Size(238, 33)
        Me.SBU_Amort_txt.TabIndex = 39
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label54.Location = New System.Drawing.Point(-1, 99)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(41, 25)
        Me.Label54.TabIndex = 127
        Me.Label54.Text = "Date"
        '
        'SBU_Date_dtp
        '
        Me.SBU_Date_dtp.Location = New System.Drawing.Point(122, 95)
        Me.SBU_Date_dtp.Name = "SBU_Date_dtp"
        Me.SBU_Date_dtp.Size = New System.Drawing.Size(238, 29)
        Me.SBU_Date_dtp.TabIndex = 37
        Me.SBU_Date_dtp.Value = New Date(2022, 1, 6, 0, 0, 0, 0)
        '
        'SBU_Save_btn
        '
        Me.SBU_Save_btn.BackColor = System.Drawing.Color.DarkSalmon
        Me.SBU_Save_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SBU_Save_btn.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SBU_Save_btn.Location = New System.Drawing.Point(288, 330)
        Me.SBU_Save_btn.Name = "SBU_Save_btn"
        Me.SBU_Save_btn.Size = New System.Drawing.Size(102, 38)
        Me.SBU_Save_btn.TabIndex = 41
        Me.SBU_Save_btn.Text = "Save"
        Me.SBU_Save_btn.UseVisualStyleBackColor = False
        '
        'SBU_Cancel_btn
        '
        Me.SBU_Cancel_btn.BackColor = System.Drawing.Color.MistyRose
        Me.SBU_Cancel_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SBU_Cancel_btn.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SBU_Cancel_btn.Location = New System.Drawing.Point(77, 330)
        Me.SBU_Cancel_btn.Name = "SBU_Cancel_btn"
        Me.SBU_Cancel_btn.Size = New System.Drawing.Size(105, 38)
        Me.SBU_Cancel_btn.TabIndex = 40
        Me.SBU_Cancel_btn.Text = "Cancel"
        Me.SBU_Cancel_btn.UseVisualStyleBackColor = False
        '
        'SBU_Name_txt
        '
        Me.SBU_Name_txt.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SBU_Name_txt.Location = New System.Drawing.Point(75, 35)
        Me.SBU_Name_txt.Name = "SBU_Name_txt"
        Me.SBU_Name_txt.ReadOnly = True
        Me.SBU_Name_txt.Size = New System.Drawing.Size(285, 33)
        Me.SBU_Name_txt.TabIndex = 109
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label57.Location = New System.Drawing.Point(-1, 150)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(117, 25)
        Me.Label57.TabIndex = 108
        Me.Label57.Text = "Principal Amount"
        '
        'SBU_Principal_txt
        '
        Me.SBU_Principal_txt.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SBU_Principal_txt.Location = New System.Drawing.Point(122, 146)
        Me.SBU_Principal_txt.Name = "SBU_Principal_txt"
        Me.SBU_Principal_txt.Size = New System.Drawing.Size(238, 33)
        Me.SBU_Principal_txt.TabIndex = 38
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label58.Location = New System.Drawing.Point(-1, 37)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(48, 25)
        Me.Label58.TabIndex = 111
        Me.Label58.Text = "Name"
        '
        'SBU_SearchEmp_btn
        '
        Me.SBU_SearchEmp_btn.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SBU_SearchEmp_btn.Location = New System.Drawing.Point(372, 35)
        Me.SBU_SearchEmp_btn.Name = "SBU_SearchEmp_btn"
        Me.SBU_SearchEmp_btn.Size = New System.Drawing.Size(47, 31)
        Me.SBU_SearchEmp_btn.TabIndex = 34
        Me.SBU_SearchEmp_btn.Text = "..."
        Me.SBU_SearchEmp_btn.UseVisualStyleBackColor = True
        '
        'SBU_LV
        '
        Me.SBU_LV.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SBU_LV.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader34, Me.ColumnHeader35, Me.ColumnHeader36, Me.ColumnHeader37, Me.ColumnHeader38})
        Me.SBU_LV.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SBU_LV.FullRowSelect = True
        Me.SBU_LV.GridLines = True
        Me.SBU_LV.HideSelection = False
        Me.SBU_LV.Location = New System.Drawing.Point(466, 76)
        Me.SBU_LV.MultiSelect = False
        Me.SBU_LV.Name = "SBU_LV"
        Me.SBU_LV.Size = New System.Drawing.Size(675, 483)
        Me.SBU_LV.TabIndex = 128
        Me.SBU_LV.UseCompatibleStateImageBehavior = False
        Me.SBU_LV.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader34
        '
        Me.ColumnHeader34.Text = "Name"
        Me.ColumnHeader34.Width = 250
        '
        'ColumnHeader35
        '
        Me.ColumnHeader35.Text = "Amount"
        Me.ColumnHeader35.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader35.Width = 100
        '
        'ColumnHeader36
        '
        Me.ColumnHeader36.Text = "Principal"
        Me.ColumnHeader36.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader36.Width = 100
        '
        'ColumnHeader37
        '
        Me.ColumnHeader37.Text = "Amount Paid"
        Me.ColumnHeader37.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader37.Width = 100
        '
        'ColumnHeader38
        '
        Me.ColumnHeader38.Text = "Balance"
        Me.ColumnHeader38.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader38.Width = 100
        '
        'TabPage7
        '
        Me.TabPage7.Controls.Add(Me.Panel1)
        Me.TabPage7.Controls.Add(Me.rpt_SOA)
        Me.TabPage7.Location = New System.Drawing.Point(4, 38)
        Me.TabPage7.Name = "TabPage7"
        Me.TabPage7.Size = New System.Drawing.Size(1147, 604)
        Me.TabPage7.TabIndex = 13
        Me.TabPage7.Text = "      SOA Form    "
        Me.TabPage7.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label56)
        Me.Panel1.Controls.Add(Me.cbStatus)
        Me.Panel1.Controls.Add(Me.txtSearchSOA)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.gridSOA)
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1141, 228)
        Me.Panel1.TabIndex = 135
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label56.Location = New System.Drawing.Point(462, 19)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(51, 25)
        Me.Label56.TabIndex = 134
        Me.Label56.Text = "Status"
        '
        'cbStatus
        '
        Me.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbStatus.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbStatus.FormattingEnabled = True
        Me.cbStatus.Items.AddRange(New Object() {"ALL", "PHOTO", "P&G UY", "DALTON", "PERFECOM", "PTU REALTY", "PGC HEAD OFFICE"})
        Me.cbStatus.Location = New System.Drawing.Point(513, 15)
        Me.cbStatus.Name = "cbStatus"
        Me.cbStatus.Size = New System.Drawing.Size(168, 33)
        Me.cbStatus.TabIndex = 133
        '
        'txtSearchSOA
        '
        Me.txtSearchSOA.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearchSOA.Location = New System.Drawing.Point(3, 16)
        Me.txtSearchSOA.Name = "txtSearchSOA"
        Me.txtSearchSOA.Size = New System.Drawing.Size(276, 33)
        Me.txtSearchSOA.TabIndex = 131
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(294, 12)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(82, 33)
        Me.Button3.TabIndex = 132
        Me.Button3.Text = "Search"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'gridSOA
        '
        Me.gridSOA.AllowUserToAddRows = False
        Me.gridSOA.AllowUserToDeleteRows = False
        Me.gridSOA.AllowUserToResizeColumns = False
        Me.gridSOA.AllowUserToResizeRows = False
        Me.gridSOA.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.gridSOA.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.gridSOA.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle25.Font = New System.Drawing.Font("Dubai", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.gridSOA.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle25
        Me.gridSOA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridSOA.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dataFullname, Me.dataDesignation, Me.dataCompany, Me.dataStatus, Me.dataDateEnded, Me.dataRemarks, Me.dataAttachment})
        Me.gridSOA.Location = New System.Drawing.Point(5, 56)
        Me.gridSOA.Name = "gridSOA"
        Me.gridSOA.RowHeadersVisible = False
        Me.gridSOA.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.gridSOA.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridSOA.Size = New System.Drawing.Size(1133, 165)
        Me.gridSOA.TabIndex = 75
        '
        'rpt_SOA
        '
        ReportDataSource4.Name = "DataSet1"
        ReportDataSource4.Value = Nothing
        Me.rpt_SOA.LocalReport.DataSources.Add(ReportDataSource4)
        Me.rpt_SOA.LocalReport.ReportEmbeddedResource = "WindowsApp1.rpt_SOA.rdlc"
        Me.rpt_SOA.Location = New System.Drawing.Point(6, 248)
        Me.rpt_SOA.Name = "rpt_SOA"
        Me.rpt_SOA.ServerReport.BearerToken = Nothing
        Me.rpt_SOA.Size = New System.Drawing.Size(1141, 350)
        Me.rpt_SOA.TabIndex = 1
        '
        'Partial_Panel
        '
        Me.Partial_Panel.BackColor = System.Drawing.Color.LightSalmon
        Me.Partial_Panel.Controls.Add(Me.PartialName_txt)
        Me.Partial_Panel.Controls.Add(Me.Label52)
        Me.Partial_Panel.Controls.Add(Me.PartialCat_txt)
        Me.Partial_Panel.Controls.Add(Me.Label51)
        Me.Partial_Panel.Controls.Add(Me.Label50)
        Me.Partial_Panel.Controls.Add(Me.PartialX_btn)
        Me.Partial_Panel.Controls.Add(Me.PartialCheck_btn)
        Me.Partial_Panel.Controls.Add(Me.PartialAmount_txt)
        Me.Partial_Panel.Controls.Add(Me.Label49)
        Me.Partial_Panel.Controls.Add(Me.Label48)
        Me.Partial_Panel.Location = New System.Drawing.Point(706, 10)
        Me.Partial_Panel.Name = "Partial_Panel"
        Me.Partial_Panel.Size = New System.Drawing.Size(71, 22)
        Me.Partial_Panel.TabIndex = 164
        Me.Partial_Panel.Visible = False
        '
        'PartialName_txt
        '
        Me.PartialName_txt.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PartialName_txt.Location = New System.Drawing.Point(88, 39)
        Me.PartialName_txt.Name = "PartialName_txt"
        Me.PartialName_txt.ReadOnly = True
        Me.PartialName_txt.Size = New System.Drawing.Size(239, 33)
        Me.PartialName_txt.TabIndex = 124
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.Location = New System.Drawing.Point(12, 47)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(48, 25)
        Me.Label52.TabIndex = 123
        Me.Label52.Text = "Name"
        '
        'PartialCat_txt
        '
        Me.PartialCat_txt.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PartialCat_txt.Location = New System.Drawing.Point(88, 83)
        Me.PartialCat_txt.Name = "PartialCat_txt"
        Me.PartialCat_txt.ReadOnly = True
        Me.PartialCat_txt.Size = New System.Drawing.Size(239, 33)
        Me.PartialCat_txt.TabIndex = 122
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.Location = New System.Drawing.Point(12, 91)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(67, 25)
        Me.Label51.TabIndex = 121
        Me.Label51.Text = "Category"
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.Location = New System.Drawing.Point(361, 0)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(38, 22)
        Me.Label50.TabIndex = 120
        Me.Label50.Text = "Close"
        '
        'PartialX_btn
        '
        Me.PartialX_btn.Font = New System.Drawing.Font("Dubai", 8.249999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PartialX_btn.Location = New System.Drawing.Point(333, 80)
        Me.PartialX_btn.Name = "PartialX_btn"
        Me.PartialX_btn.Size = New System.Drawing.Size(52, 38)
        Me.PartialX_btn.TabIndex = 119
        Me.PartialX_btn.Text = "✖"
        Me.PartialX_btn.UseVisualStyleBackColor = True
        '
        'PartialCheck_btn
        '
        Me.PartialCheck_btn.Font = New System.Drawing.Font("Dubai", 8.249999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PartialCheck_btn.Location = New System.Drawing.Point(334, 130)
        Me.PartialCheck_btn.Name = "PartialCheck_btn"
        Me.PartialCheck_btn.Size = New System.Drawing.Size(52, 38)
        Me.PartialCheck_btn.TabIndex = 118
        Me.PartialCheck_btn.Text = " ✔"
        Me.PartialCheck_btn.UseVisualStyleBackColor = True
        '
        'PartialAmount_txt
        '
        Me.PartialAmount_txt.Font = New System.Drawing.Font("Dubai", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PartialAmount_txt.Location = New System.Drawing.Point(89, 126)
        Me.PartialAmount_txt.Name = "PartialAmount_txt"
        Me.PartialAmount_txt.Size = New System.Drawing.Size(238, 40)
        Me.PartialAmount_txt.TabIndex = 2
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label49.Location = New System.Drawing.Point(13, 134)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(62, 25)
        Me.Label49.TabIndex = 1
        Me.Label49.Text = "Amount"
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label48.Location = New System.Drawing.Point(138, 11)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(115, 27)
        Me.Label48.TabIndex = 0
        Me.Label48.Text = "Partial Payment"
        '
        'ColumnHeader19
        '
        Me.ColumnHeader19.Text = "Fullname"
        Me.ColumnHeader19.Width = 250
        '
        'ColumnHeader20
        '
        Me.ColumnHeader20.Text = "Principal"
        Me.ColumnHeader20.Width = 135
        '
        'ColumnHeader21
        '
        Me.ColumnHeader21.Text = "Amort"
        Me.ColumnHeader21.Width = 130
        '
        'ColumnHeader23
        '
        Me.ColumnHeader23.Text = "Date"
        Me.ColumnHeader23.Width = 130
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Dubai", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 36)
        Me.Label1.TabIndex = 79
        Me.Label1.Text = "Loans"
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.DisplayIndex = 0
        Me.ColumnHeader11.Text = "Fullname"
        Me.ColumnHeader11.Width = 400
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.DisplayIndex = 1
        Me.ColumnHeader12.Text = "Category"
        Me.ColumnHeader12.Width = 130
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.DisplayIndex = 2
        Me.ColumnHeader13.Text = "Total"
        Me.ColumnHeader13.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader13.Width = 85
        '
        'ColumnHeader15
        '
        Me.ColumnHeader15.DisplayIndex = 3
        Me.ColumnHeader15.Text = "No. of Deduc."
        Me.ColumnHeader15.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader15.Width = 110
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.DisplayIndex = 4
        Me.ColumnHeader14.Text = "Amount/Deduc"
        Me.ColumnHeader14.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader14.Width = 130
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.DisplayIndex = 5
        Me.ColumnHeader8.Text = "Schedule"
        Me.ColumnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader8.Width = 140
        '
        'ColumnHeader16
        '
        Me.ColumnHeader16.DisplayIndex = 6
        Me.ColumnHeader16.Text = "Balance"
        Me.ColumnHeader16.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader16.Width = 100
        '
        'DE_Save_BTN
        '
        Me.DE_Save_BTN.BackColor = System.Drawing.Color.RosyBrown
        Me.DE_Save_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DE_Save_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DE_Save_BTN.Location = New System.Drawing.Point(1050, 132)
        Me.DE_Save_BTN.Name = "DE_Save_BTN"
        Me.DE_Save_BTN.Size = New System.Drawing.Size(78, 33)
        Me.DE_Save_BTN.TabIndex = 41
        Me.DE_Save_BTN.Text = "Save"
        Me.DE_Save_BTN.UseVisualStyleBackColor = False
        '
        'DE_Total_TXT
        '
        Me.DE_Total_TXT.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DE_Total_TXT.Location = New System.Drawing.Point(693, 21)
        Me.DE_Total_TXT.Name = "DE_Total_TXT"
        Me.DE_Total_TXT.Size = New System.Drawing.Size(223, 29)
        Me.DE_Total_TXT.TabIndex = 37
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(548, 26)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(44, 25)
        Me.Label18.TabIndex = 108
        '
        'DE_SearchEmp_BTN
        '
        Me.DE_SearchEmp_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DE_SearchEmp_BTN.Location = New System.Drawing.Point(422, 36)
        Me.DE_SearchEmp_BTN.Name = "DE_SearchEmp_BTN"
        Me.DE_SearchEmp_BTN.Size = New System.Drawing.Size(47, 31)
        Me.DE_SearchEmp_BTN.TabIndex = 34
        Me.DE_SearchEmp_BTN.Text = "..."
        Me.DE_SearchEmp_BTN.UseVisualStyleBackColor = True
        '
        'DE_NoOfGives_TXT
        '
        Me.DE_NoOfGives_TXT.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DE_NoOfGives_TXT.Location = New System.Drawing.Point(693, 54)
        Me.DE_NoOfGives_TXT.Name = "DE_NoOfGives_TXT"
        Me.DE_NoOfGives_TXT.Size = New System.Drawing.Size(223, 29)
        Me.DE_NoOfGives_TXT.TabIndex = 38
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(8, 37)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(48, 25)
        Me.Label15.TabIndex = 111
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(548, 56)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(93, 25)
        Me.Label20.TabIndex = 119
        '
        'DE_Cancel_BTN
        '
        Me.DE_Cancel_BTN.BackColor = System.Drawing.Color.MistyRose
        Me.DE_Cancel_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DE_Cancel_BTN.Font = New System.Drawing.Font("Dubai", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DE_Cancel_BTN.Location = New System.Drawing.Point(964, 132)
        Me.DE_Cancel_BTN.Name = "DE_Cancel_BTN"
        Me.DE_Cancel_BTN.Size = New System.Drawing.Size(78, 33)
        Me.DE_Cancel_BTN.TabIndex = 42
        Me.DE_Cancel_BTN.Text = "Cancel"
        Me.DE_Cancel_BTN.UseVisualStyleBackColor = False
        '
        'DE_AmountGive_TXT
        '
        Me.DE_AmountGive_TXT.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DE_AmountGive_TXT.Location = New System.Drawing.Point(693, 87)
        Me.DE_AmountGive_TXT.Name = "DE_AmountGive_TXT"
        Me.DE_AmountGive_TXT.Size = New System.Drawing.Size(223, 29)
        Me.DE_AmountGive_TXT.TabIndex = 39
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(8, 79)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(67, 25)
        Me.Label17.TabIndex = 110
        '
        'DE_Name_TXT
        '
        Me.DE_Name_TXT.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DE_Name_TXT.Location = New System.Drawing.Point(97, 35)
        Me.DE_Name_TXT.Name = "DE_Name_TXT"
        Me.DE_Name_TXT.ReadOnly = True
        Me.DE_Name_TXT.Size = New System.Drawing.Size(319, 33)
        Me.DE_Name_TXT.TabIndex = 109
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(548, 91)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(132, 25)
        Me.Label22.TabIndex = 121
        '
        'DE_Category_Combo
        '
        Me.DE_Category_Combo.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DE_Category_Combo.FormattingEnabled = True
        Me.DE_Category_Combo.Location = New System.Drawing.Point(97, 77)
        Me.DE_Category_Combo.Name = "DE_Category_Combo"
        Me.DE_Category_Combo.Size = New System.Drawing.Size(319, 33)
        Me.DE_Category_Combo.TabIndex = 35
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(8, 118)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(67, 25)
        Me.Label28.TabIndex = 123
        '
        'DE_Schedule_Combo
        '
        Me.DE_Schedule_Combo.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DE_Schedule_Combo.FormattingEnabled = True
        Me.DE_Schedule_Combo.Items.AddRange(New Object() {"OPEN PAYROLL", "CLOSE PAYROLL", "EVERY PAYROLL"})
        Me.DE_Schedule_Combo.Location = New System.Drawing.Point(97, 116)
        Me.DE_Schedule_Combo.Name = "DE_Schedule_Combo"
        Me.DE_Schedule_Combo.Size = New System.Drawing.Size(319, 33)
        Me.DE_Schedule_Combo.TabIndex = 36
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(548, 139)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(73, 25)
        Me.Label31.TabIndex = 124
        '
        'DE_Effectivity_DTP
        '
        Me.DE_Effectivity_DTP.Location = New System.Drawing.Point(693, 137)
        Me.DE_Effectivity_DTP.Name = "DE_Effectivity_DTP"
        Me.DE_Effectivity_DTP.Size = New System.Drawing.Size(223, 20)
        Me.DE_Effectivity_DTP.TabIndex = 40
        Me.DE_Effectivity_DTP.Value = New Date(2021, 9, 15, 0, 0, 0, 0)
        '
        'lblAdd
        '
        Me.lblAdd.AutoSize = True
        Me.lblAdd.Font = New System.Drawing.Font("Dubai", 9.749999!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAdd.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lblAdd.Location = New System.Drawing.Point(429, 82)
        Me.lblAdd.Name = "lblAdd"
        Me.lblAdd.Size = New System.Drawing.Size(32, 22)
        Me.lblAdd.TabIndex = 125
        '
        'panelRemarksSOA
        '
        Me.panelRemarksSOA.BackColor = System.Drawing.Color.PapayaWhip
        Me.panelRemarksSOA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelRemarksSOA.Controls.Add(Me.btnSaveSOA)
        Me.panelRemarksSOA.Controls.Add(Me.btnCancelSOA)
        Me.panelRemarksSOA.Controls.Add(Me.Label69)
        Me.panelRemarksSOA.Controls.Add(Me.rbRemarksSOA)
        Me.panelRemarksSOA.Location = New System.Drawing.Point(795, 10)
        Me.panelRemarksSOA.Name = "panelRemarksSOA"
        Me.panelRemarksSOA.Size = New System.Drawing.Size(71, 22)
        Me.panelRemarksSOA.TabIndex = 165
        Me.panelRemarksSOA.Visible = False
        '
        'btnSaveSOA
        '
        Me.btnSaveSOA.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveSOA.Location = New System.Drawing.Point(317, 201)
        Me.btnSaveSOA.Name = "btnSaveSOA"
        Me.btnSaveSOA.Size = New System.Drawing.Size(53, 27)
        Me.btnSaveSOA.TabIndex = 3
        Me.btnSaveSOA.Text = "Save"
        Me.btnSaveSOA.UseVisualStyleBackColor = True
        '
        'btnCancelSOA
        '
        Me.btnCancelSOA.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelSOA.Location = New System.Drawing.Point(12, 201)
        Me.btnCancelSOA.Name = "btnCancelSOA"
        Me.btnCancelSOA.Size = New System.Drawing.Size(65, 27)
        Me.btnCancelSOA.TabIndex = 2
        Me.btnCancelSOA.Text = "Cancel/Close"
        Me.btnCancelSOA.UseVisualStyleBackColor = True
        '
        'Label69
        '
        Me.Label69.AutoSize = True
        Me.Label69.Location = New System.Drawing.Point(152, 10)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(49, 13)
        Me.Label69.TabIndex = 1
        Me.Label69.Text = "Remarks"
        '
        'rbRemarksSOA
        '
        Me.rbRemarksSOA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rbRemarksSOA.Location = New System.Drawing.Point(12, 37)
        Me.rbRemarksSOA.Name = "rbRemarksSOA"
        Me.rbRemarksSOA.Size = New System.Drawing.Size(358, 158)
        Me.rbRemarksSOA.TabIndex = 0
        Me.rbRemarksSOA.Text = ""
        '
        'dataFullname
        '
        DataGridViewCellStyle26.Font = New System.Drawing.Font("Dubai", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dataFullname.DefaultCellStyle = DataGridViewCellStyle26
        Me.dataFullname.HeaderText = "Name"
        Me.dataFullname.Name = "dataFullname"
        Me.dataFullname.ReadOnly = True
        Me.dataFullname.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dataFullname.Width = 280
        '
        'dataDesignation
        '
        DataGridViewCellStyle27.Font = New System.Drawing.Font("Dubai", 11.25!)
        Me.dataDesignation.DefaultCellStyle = DataGridViewCellStyle27
        Me.dataDesignation.HeaderText = "Designation"
        Me.dataDesignation.Name = "dataDesignation"
        Me.dataDesignation.ReadOnly = True
        Me.dataDesignation.Width = 180
        '
        'dataCompany
        '
        DataGridViewCellStyle28.Font = New System.Drawing.Font("Dubai", 11.25!)
        Me.dataCompany.DefaultCellStyle = DataGridViewCellStyle28
        Me.dataCompany.HeaderText = "Company"
        Me.dataCompany.Name = "dataCompany"
        Me.dataCompany.ReadOnly = True
        Me.dataCompany.Width = 150
        '
        'dataStatus
        '
        DataGridViewCellStyle29.Font = New System.Drawing.Font("Dubai", 11.25!)
        Me.dataStatus.DefaultCellStyle = DataGridViewCellStyle29
        Me.dataStatus.HeaderText = "Status"
        Me.dataStatus.Name = "dataStatus"
        Me.dataStatus.ReadOnly = True
        Me.dataStatus.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dataStatus.Width = 170
        '
        'dataDateEnded
        '
        DataGridViewCellStyle30.Font = New System.Drawing.Font("Dubai", 11.25!)
        Me.dataDateEnded.DefaultCellStyle = DataGridViewCellStyle30
        Me.dataDateEnded.HeaderText = "Date Ended"
        Me.dataDateEnded.Name = "dataDateEnded"
        Me.dataDateEnded.ReadOnly = True
        Me.dataDateEnded.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dataDateEnded.Width = 130
        '
        'dataRemarks
        '
        DataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle31.Font = New System.Drawing.Font("Dubai", 11.25!)
        Me.dataRemarks.DefaultCellStyle = DataGridViewCellStyle31
        Me.dataRemarks.HeaderText = "Remarks"
        Me.dataRemarks.Name = "dataRemarks"
        Me.dataRemarks.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dataRemarks.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dataRemarks.Width = 90
        '
        'dataAttachment
        '
        DataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle32.Font = New System.Drawing.Font("Dubai", 11.25!)
        Me.dataAttachment.DefaultCellStyle = DataGridViewCellStyle32
        Me.dataAttachment.HeaderText = "Attachment"
        Me.dataAttachment.Name = "dataAttachment"
        Me.dataAttachment.Width = 115
        '
        'frmLoan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1175, 680)
        Me.Controls.Add(Me.panelRemarksSOA)
        Me.Controls.Add(Me.Partial_Panel)
        Me.Controls.Add(Me.Close_LBL)
        Me.Controls.Add(Me.Loans_Tab)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmLoan"
        Me.Text = "frmLoan"
        Me.Loans_Tab.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.Context_Deduct.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.Context_SSS.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.Context_Pagibg.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.Context_Mp2.ResumeLayout(False)
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        Me.Context_Maxicare.ResumeLayout(False)
        Me.TabPage6.ResumeLayout(False)
        Me.TabPage6.PerformLayout()
        Me.Context_SBU.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage7.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.gridSOA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Partial_Panel.ResumeLayout(False)
        Me.Partial_Panel.PerformLayout()
        Me.panelRemarksSOA.ResumeLayout(False)
        Me.panelRemarksSOA.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Close_LBL As Label
    Friend WithEvents Loans_Tab As TabControl
    Friend WithEvents Label1 As Label
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents ColumnHeader11 As ColumnHeader
    Friend WithEvents ColumnHeader12 As ColumnHeader
    Friend WithEvents ColumnHeader13 As ColumnHeader
    Friend WithEvents ColumnHeader15 As ColumnHeader
    Friend WithEvents ColumnHeader14 As ColumnHeader
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents ColumnHeader16 As ColumnHeader
    Friend WithEvents DE_Save_BTN As Button
    Friend WithEvents DE_Total_TXT As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents DE_SearchEmp_BTN As Button
    Friend WithEvents DE_NoOfGives_TXT As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents DE_Cancel_BTN As Button
    Friend WithEvents DE_AmountGive_TXT As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents DE_Name_TXT As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents DE_Category_Combo As ComboBox
    Friend WithEvents Label28 As Label
    Friend WithEvents DE_Schedule_Combo As ComboBox
    Friend WithEvents Label31 As Label
    Friend WithEvents DE_Effectivity_DTP As DateTimePicker
    Friend WithEvents lblAdd As Label
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents Schedule_Combo As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Name_txt As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Amount_txt As TextBox
    Friend WithEvents Cancel_btn As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents PrincipalDeduc_txt As TextBox
    Friend WithEvents Save_btn As Button
    Friend WithEvents Search_txt As TextBox
    Friend WithEvents Search_btn As Button
    Friend WithEvents Deduc_list As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents Context_Deduct As ContextMenuStrip
    Friend WithEvents menu_subtotal As ToolStripMenuItem
    Friend WithEvents menu_edit As ToolStripMenuItem
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents SSSCancel_BTN As Button
    Friend WithEvents SSS_Save_BTN As Button
    Friend WithEvents SSS_Search_TXT As TextBox
    Friend WithEvents SSS_Search_BTN As Button
    Friend WithEvents SSSLoan_LV As ListView
    Friend WithEvents ColumnHeader9 As ColumnHeader
    Friend WithEvents ColumnHeader10 As ColumnHeader
    Friend WithEvents ColumnHeader17 As ColumnHeader
    Friend WithEvents ColumnHeader18 As ColumnHeader
    Friend WithEvents SSS_SearchEmp_BTN As Button
    Friend WithEvents Label14 As Label
    Friend WithEvents SSS_Name_TXT As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents SSS_Amort_TXT As TextBox
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents Pag_Cancel_BTN As Button
    Friend WithEvents Pag_Save_BTN As Button
    Friend WithEvents PagSearch_BTN As Button
    Friend WithEvents PagSearch_TXT As TextBox
    Friend WithEvents Mp2_List As ListView
    Friend WithEvents ColumnHeader19 As ColumnHeader
    Friend WithEvents ColumnHeader20 As ColumnHeader
    Friend WithEvents ColumnHeader21 As ColumnHeader
    Friend WithEvents ColumnHeader23 As ColumnHeader
    Friend WithEvents PagEmp_BTN As Button
    Friend WithEvents Label19 As Label
    Friend WithEvents PagEmp_TXT As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents PagAmort_TXT As TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents SSSPrincipal_TXT As TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents PagPrincipal_TXT As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents DateCharges_DTP As DateTimePicker
    Friend WithEvents CategoryDeduc_txt As TextBox
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents Label2 As Label
    Friend WithEvents DeductAmort_txt As TextBox
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents Balance_MenuItem As ToolStripMenuItem
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents TabPage5 As TabPage
    Friend WithEvents Label11 As Label
    Friend WithEvents Mp2Search_txt As TextBox
    Friend WithEvents Mp2Search_btn As Button
    'Friend WithEvents Mp2_List As ListView
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents ColumnHeader24 As ColumnHeader
    Friend WithEvents ColumnHeader25 As ColumnHeader
    Friend WithEvents Mp2Emp_btn As Button
    Friend WithEvents Label29 As Label
    Friend WithEvents Mp2Emp_txt As TextBox
    Friend WithEvents Label30 As Label
    Friend WithEvents Mp2Amort_txt As TextBox
    Friend WithEvents Mp2Cancel_btn As Button
    Friend WithEvents Mp2Save_btn As Button
    Friend WithEvents ColumnHeader26 As ColumnHeader
    Friend WithEvents Mp2Sched_Combo As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents MaxSched_Combo As ComboBox
    Friend WithEvents Label32 As Label
    Friend WithEvents MaxCancel_btn As Button
    Friend WithEvents MaxSave_btn As Button
    Friend WithEvents Label33 As Label
    Friend WithEvents MaxSearch_txt As TextBox
    Friend WithEvents MaxSearch_btn As Button
    Friend WithEvents Maxicare_List As ListView
    Friend WithEvents ColumnHeader22 As ColumnHeader
    Friend WithEvents ColumnHeader27 As ColumnHeader
    Friend WithEvents ColumnHeader28 As ColumnHeader
    Friend WithEvents ColumnHeader29 As ColumnHeader
    Friend WithEvents MaxEmp_btn As Button
    Friend WithEvents Label35 As Label
    Friend WithEvents MaxEmp_txt As TextBox
    Friend WithEvents Label36 As Label
    Friend WithEvents MaxAmort_txt As TextBox
    Friend WithEvents Context_SSS As ContextMenuStrip
    Friend WithEvents SSSSubtotal_Menu As ToolStripMenuItem
    Friend WithEvents SSSBalance_Menu As ToolStripMenuItem
    Friend WithEvents SSSEdit_Menu As ToolStripMenuItem
    Friend WithEvents Context_Pagibg As ContextMenuStrip
    Friend WithEvents PagSubTotal_Menu As ToolStripMenuItem
    Friend WithEvents PagBalance_Menu As ToolStripMenuItem
    Friend WithEvents PagEdit_Menu As ToolStripMenuItem
    Friend WithEvents Context_Mp2 As ContextMenuStrip
    Friend WithEvents Mp2Edit_Menu As ToolStripMenuItem
    Friend WithEvents Context_Maxicare As ContextMenuStrip
    Friend WithEvents MaxEdit_Menu As ToolStripMenuItem
    Friend WithEvents Pagibig_List As ListView
    Friend WithEvents ColumnHeader30 As ColumnHeader
    Friend WithEvents ColumnHeader31 As ColumnHeader
    Friend WithEvents ColumnHeader32 As ColumnHeader
    Friend WithEvents ColumnHeader33 As ColumnHeader
    Friend WithEvents Label37 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label38 As Label
    Friend WithEvents Label39 As Label
    Friend WithEvents Label40 As Label
    Friend WithEvents Label41 As Label
    Friend WithEvents Label42 As Label
    Friend WithEvents Label43 As Label
    Friend WithEvents MaxStatus_Combo As ComboBox
    Friend WithEvents Mp2Status_Combo As ComboBox
    Friend WithEvents Label44 As Label
    Friend WithEvents Label45 As Label
    Friend WithEvents Label46 As Label
    Friend WithEvents Label47 As Label
    Friend WithEvents PartialPaymentDeducMenu As ToolStripMenuItem
    Friend WithEvents Partial_Panel As Panel
    Friend WithEvents Label48 As Label
    Friend WithEvents PartialAmount_txt As TextBox
    Friend WithEvents Label49 As Label
    Friend WithEvents PartialX_btn As Button
    Friend WithEvents PartialCheck_btn As Button
    Friend WithEvents Label50 As Label
    Friend WithEvents PartialCat_txt As TextBox
    Friend WithEvents Label51 As Label
    Friend WithEvents PartialName_txt As TextBox
    Friend WithEvents Label52 As Label
    Friend WithEvents PartialPaymentSSSMenuItem As ToolStripMenuItem
    Friend WithEvents PartialPaymentPagMenuItem As ToolStripMenuItem
    Friend WithEvents TabPage6 As TabPage
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label53 As Label
    Friend WithEvents SBU_Amort_txt As TextBox
    Friend WithEvents SBU_Save_btn As Button
    Friend WithEvents SBU_Cancel_btn As Button
    Friend WithEvents SBU_Name_txt As TextBox
    Friend WithEvents Label57 As Label
    Friend WithEvents SBU_Principal_txt As TextBox
    Friend WithEvents Label58 As Label
    Friend WithEvents SBU_SearchEmp_btn As Button
    Friend WithEvents SBU_LV As ListView
    Friend WithEvents ColumnHeader34 As ColumnHeader
    Friend WithEvents ColumnHeader35 As ColumnHeader
    Friend WithEvents ColumnHeader36 As ColumnHeader
    Friend WithEvents ColumnHeader37 As ColumnHeader
    Friend WithEvents ColumnHeader38 As ColumnHeader
    Friend WithEvents Context_SBU As ContextMenuStrip
    Friend WithEvents SBUEdit_Menu As ToolStripMenuItem
    Friend WithEvents SBU_Search_txt As TextBox
    Friend WithEvents SBU_Search_btn As Button
    Friend WithEvents SSS_Date_DTP As DateTimePicker
    Friend WithEvents Label10 As Label
    Friend WithEvents PagDate_DTP As DateTimePicker
    Friend WithEvents Label13 As Label
    Friend WithEvents Mp2Date_dtp As DateTimePicker
    Friend WithEvents Label24 As Label
    Friend WithEvents MaxDate_dtp As DateTimePicker
    Friend WithEvents Label34 As Label
    Friend WithEvents Label54 As Label
    Friend WithEvents SBU_Date_dtp As DateTimePicker
    Friend WithEvents ScheduleSBU_Combo As ComboBox
    Friend WithEvents Label55 As Label
    Friend WithEvents menu_remove As ToolStripMenuItem
    Friend WithEvents TabPage7 As TabPage
    Friend WithEvents rpt_SOA As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents gridSOA As DataGridView
    Friend WithEvents txtSearchSOA As TextBox
    Friend WithEvents Button3 As Button
    Friend WithEvents Label56 As Label
    Friend WithEvents cbStatus As ComboBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents panelRemarksSOA As Panel
    Friend WithEvents btnSaveSOA As Button
    Friend WithEvents btnCancelSOA As Button
    Friend WithEvents Label69 As Label
    Friend WithEvents rbRemarksSOA As RichTextBox
    Friend WithEvents dataFullname As DataGridViewTextBoxColumn
    Friend WithEvents dataDesignation As DataGridViewTextBoxColumn
    Friend WithEvents dataCompany As DataGridViewTextBoxColumn
    Friend WithEvents dataStatus As DataGridViewTextBoxColumn
    Friend WithEvents dataDateEnded As DataGridViewTextBoxColumn
    Friend WithEvents dataRemarks As DataGridViewButtonColumn
    Friend WithEvents dataAttachment As DataGridViewButtonColumn
End Class
