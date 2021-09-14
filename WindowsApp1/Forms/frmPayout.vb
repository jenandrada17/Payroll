Imports System.Globalization
Imports System.IO
Imports System.Net.Mail
Imports System.Text.RegularExpressions

Public Class frmPayout

    Dim rowCount, regHoliday, specHoliday As Integer
    Public paydate_ As String = frmMainForm.Paydate.ToString("d")
    Dim SBU, Charges, Loan, CashAdvance, other As Double
    Dim SBUUU, Chargesss, Loannn, CashAdvanceee, otherrr As Double
    Dim gross, netTax, sssLoan, pagibigLoan, allowance, deduction As Double
    Dim emp_id, sched_deduc As String

    Private Sub frmPayout_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        regHoliday = Holiday_Rate("REGULAR")
        specHoliday = Holiday_Rate("SPECIAL")
        PopulateComboBox(Paydate_ComboB, "PAYROLL_PAYOUT", "PAYDATE")

        '========================== PAYSLIP ===========================
        PopulateComboBox(Payslip_paydate_Combo, "PAYROLL_PAYOUT", "PAYDATE")
        PopulateComboBox(Branch_ComboB, "TBL_BRANCH", "BRANCHNAME")

    End Sub

    Private Sub Select_BTN_Click(sender As Object, e As EventArgs) Handles Select_BTN.Click

        If frmEmployee Is Nothing Then
            Dim frm As New frmEmployee With {
                .MdiParent = frmMainForm
            }
            frmMainForm.pNavigate.Controls.Add(frm)
            frmMainForm.pNavigate.Tag = frm
            frm.txtSearch.Tag = "Payout"

            If Paydate_ComboB.SelectedIndex >= 0 Then
                frm.btnSearch.Tag = Paydate_ComboB.SelectedItem
            Else
                frm.btnSearch.Tag = paydate_
            End If

            frm.Show()
            frm.Dock = DockStyle.Fill
            frm.BringToFront()
        Else
            frmEmployeeInfo.BringToFront()
        End If

        Close()
    End Sub

    Private Sub BiometricID_TXT_TextChanged(sender As Object, e As EventArgs) Handles BiometricID_TXT.TextChanged

        If BiometricID_TXT.Text = "" Then
            Cancel_BTN.PerformClick()
        Else
            Payout_Details(BiometricID_TXT.Text, Name_TXT, Rate_TXT)
            DETAILS()
        End If

    End Sub

    Public Sub DETAILS()
        If Bio_Exist_Attendance(BiometricID_TXT.Text, paydate_) Then

            AttendanceDetails(BiometricID_TXT.Text, paydate_, NoOfDays_TXT, RegularOT_TXT, SpecialHol_TXT, RegularHol_TXT,
                                        Late_TXT, UnderTime_TXT)

            '============================ CHECK IF CLOSE PAYROLL ================================== 
            If IsLastDay(paydate_) Then

                Dim monthly_Basic As Double = GetMonthly_Basic(BiometricID_TXT.Text, Rate_TXT.Tag, paydate_)
                Prev_Amount_lbl.Text = (GetFirst_Basic(BiometricID_TXT.Text, Rate_TXT.Tag, paydate_)).ToString("N")

                SSSComp_LBL.Text = (Get_SSS(monthly_Basic)).ToString("N")
                HDMF_LBL.Text = (Get_Pagibig(monthly_Basic)).ToString("N")
                Philhealth_LBL.Text = (Get_PhilHealth(monthly_Basic)).ToString("N")
                Tax_Wheld_LBL.Text = (Get_WHolding(monthly_Basic)).ToString("N")

                NetTax_LBL.Text = (monthly_Basic - (CDbl(SSSComp_LBL.Text) + CDbl(HDMF_LBL.Text) + CDbl(Philhealth_LBL.Text) + CDbl(Tax_Wheld_LBL.Text))).ToString(”N”)

                Previous_groupB.Visible = True

                SSSLoan_LBL.Text = (Get_LOAN_SSS(Name_TXT.Tag)).ToString("N")
                PagibigLoan_LBL.Text = (Get_LOAN_Pagibig(Name_TXT.Tag)).ToString("N")

                sched_deduc = "CLOSE PAYROLL"
            Else
                SSSComp_LBL.Text = 0.00
                HDMF_LBL.Text = 0.00
                Philhealth_LBL.Text = 0.00
                Tax_Wheld_LBL.Text = 0.00
                SSSLoan_LBL.Text = 0.00
                PagibigLoan_LBL.Text = 0.00
                Previous_groupB.Visible = False

                sched_deduc = "OPEN PAYROLL"
            End If

            '================ FETCHING ALLOWANCE RECORDED WHEN ATTENDANCE BIOMETRIC IMPORTED ==================
            If hasRecord_RECORDED(Name_TXT.Tag, paydate_, "RECORDED_ALLOW_DEDUC", "ALLOWANCE") Then
                Recorded_Details(Name_TXT.Tag, Allowance_grid, paydate_, "ALLOWANCE")
            Else
                AllowanceDetails(Name_TXT.Tag, Allowance_grid, sched_deduc)
            End If

            Allowance_grid.Visible = True

            '================ FETCHING ALLOWANCE RECORDED WHEN ATTENDANCE BIOMETRIC IMPORTED ==================
            If isExist_single("MODIFIED_DEDUCTION", "EMP_ID", Name_TXT.Tag) Then                                '=========m MDIFIED DEDUCTION (ON/OFF)
                DeductioneDetails_MODIFIED(Name_TXT.Tag, paydate_, Deduction_grid, sched_deduc)
            ElseIf hasRecord_RECORDED(Name_TXT.Tag, paydate_, "RECORDED_ALLOW_DEDUC", "DEDUCTION") Then         '=========m RECORDED DEDUCTION IMPORTING ATTENDANCE
                Recorded_Details(Name_TXT.Tag, Deduction_grid, paydate_, "DEDUCTION")
            Else                                                                                                '=========m ORIGINAL DEDUCTION INCLUDING NEW ADDED DEDUCTION                                                                                               
                DeductioneDetails_ORIG(Name_TXT.Tag, Deduction_grid, sched_deduc)
            End If

            ADD_SBU_GRID() ' =========== SBU DEDUCTION 

            '==========================  CHECK PAYDATE IF VALID FOR EDITING (DEDUCTION) =========================  

            If paydate_ = frmMainForm.Paydate.ToString("d") Then
                Deduction_grid.Enabled = True
            Else
                Deduction_grid.Enabled = False
            End If

            Calculate_Gross()

            Calculate_Allowance()

            Calculate_Deduction()

            Calculate_NetPay()

            Checkgrid_Visible()

        End If
    End Sub

    Private Sub Checkgrid_Visible() ' ============== Allowance and Deduction

        '========================== Check if allowance grid has rows ===================== 

        If Allowance_grid.RowCount > 0 Then
            Label18.Visible = True
            Allowance_grid.Visible = True
        Else
            Label18.Visible = False
            Allowance_grid.Visible = False
        End If

        '========================== Check if deduction grid has rows ===================== 

        If Deduction_grid.RowCount > 0 Then
            Label22.Visible = True
            Deduction_grid.Visible = True
        Else
            Label22.Visible = False
            Deduction_grid.Visible = False
        End If

    End Sub

    Private Sub Deduction_grid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Deduction_grid.CellContentClick

        Dim grid = DirectCast(sender, DataGridView)
        Dim row As DataGridViewRow = Deduction_grid.Rows(e.RowIndex)

        If TypeOf grid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn Then

            If row.Cells(3).Value = "OFF" Then
                row.Cells(3).Value = "ON"
                row.Cells(1).Value = "0.00"

            ElseIf row.Cells(3).Value = "ON" Then
                row.Cells(3).Value = "OFF"
                row.Cells(1).Value = row.Cells(0).Tag
            End If

            Calculate_Deduction()
            Calculate_NetPay()
        End If
    End Sub

    Private Sub Close_LBL_Click_1(sender As Object, e As EventArgs) Handles Close_LBL.Click
        Close()
    End Sub

    Private Sub Cancel_BTN_Click(sender As Object, e As EventArgs) Handles Cancel_BTN.Click

        For Each Ctl In GroupBox6.Controls
            If TypeOf Ctl Is TextBox Then Ctl.Text = ""
        Next

        For Each Ctl In GroupBox1.Controls
            If TypeOf Ctl Is TextBox Then Ctl.Text = ""
        Next

        'For Each Ctl In GroupBox2.Controls
        '    If TypeOf Ctl Is TextBox Then Ctl.Text = ""
        'Next

        'For Each Ctl In GroupBox3.Controls
        '    If TypeOf Ctl Is TextBox Then Ctl.Text = ""
        'Next

        For Each Ctl In GroupBox4.Controls

            If TypeOf Ctl Is Label Then

                If IsNumeric(Ctl.text) Then
                    Ctl.Text = 0
                End If

            End If
        Next

        Deduction_grid.Rows.Clear()
        Allowance_grid.Rows.Clear()

    End Sub

    Private Sub Details_Save_BTN_Click(sender As Object, e As EventArgs) Handles Details_Save_BTN.Click
        If Not Name_TXT.Text = String.Empty Then

            If Details_Save_BTN.Text = "Save" Then
                SavePayout(BiometricID_TXT.Text, Rate_TXT.Tag, paydate_, TotalBasic_LBL.Text, TotalOT_LBL.Text,
                      TotalLateUnder_LBL.Text, GrossAmount_LBL.Text, SSSComp_LBL.Text, HDMF_LBL.Text, Philhealth_LBL.Text,
                      Tax_Wheld_LBL.Text, NetTax_LBL.Text, SSSLoan_LBL.Text, PagibigLoan_LBL.Text,
                      Allowances_LBL.Text, Deduction_LBL.Text, NetPay_LBL.Text)

                If Deduction_grid.Rows.Count > 0 Then

                    If isExist_single("MODIFIED_DEDUCTION", "EMP_ID", Name_TXT.Tag) Then 'DELETE RECORD IF EXIST TO REPLACE NEW FROM GRID
                        RunCommand($"DELETE FROM MODIFIED_DEDUCTION WHERE EMP_ID = '{Name_TXT.Tag}' and PAYDATE = '{paydate_}';")
                    End If

                    For Each row As DataGridViewRow In Deduction_grid.Rows
                        If Not row.Cells(3).Value = String.Empty Then
                            SavePayout_MODIFIED_DEDUCTION(Name_TXT.Tag, paydate_, row.Cells(0).Value, row.Cells(1).Value, row.Cells(0).Tag, Today, row.Cells(2).Tag)
                        End If
                    Next
                End If

                Cancel_BTN.PerformClick()
                Details_Save_BTN.Text = "Edit"

            Else

                AllowanceDetails(Name_TXT.Tag, Allowance_grid, sched_deduc)
                DeductioneDetails_ORIG(Name_TXT.Tag, Deduction_grid, sched_deduc)

                ADD_SBU_GRID() ' =========== SBU DEDUCTION 

                Calculate_Gross()

                Calculate_Allowance()

                Calculate_Deduction()

                Calculate_NetPay()

                Checkgrid_Visible()

                Details_Save_BTN.Text = "Save"
                If paydate_ = frmMainForm.Paydate.ToString("d") Then     '======== CHECK IF VALID FOR EDITING IF NOT DISABLE SAVING
                    Details_Save_BTN.Enabled = True
                Else
                    Details_Save_BTN.Enabled = False
                End If

            End If
        End If


    End Sub

    Public Sub ADD_SBU_GRID()

        Dim rowIdd As Integer = Deduction_grid.Rows.Add()
        Dim roww As DataGridViewRow = Deduction_grid.Rows(rowIdd)

        Dim sbu As Double = SBU_Amount()

        roww.Cells(0).Value = "SBU"
        roww.Cells(1).Value = sbu.ToString(”N”)
        roww.Cells(3) = New DataGridViewTextBoxCell()

        AdjustHeightOfGridBasedOnRows(Deduction_grid)

    End Sub

    Private Sub Pay_Refresh_BTN_Click(sender As Object, e As EventArgs) Handles Pay_Refresh_BTN.Click
        'SavePayout_ALL(paydate_)

        Lists_Payout(Payout_list, paydate_)

        GetPayout_TOTALS(paydate_, P_GrossAmount_LBL, P_SSSComp_LBL, P_PagibigComp_LBL, P_PhilHComp_LBL, P_TaxWH_LBL,
                         P_SSSLoan_LBL, P_PagibigLoan_LBL, P_Allowance_LBL, P_Deduction_LBL, P_NetPay_LBL)
    End Sub

    Private Sub Paydate_ComboB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Paydate_ComboB.SelectedIndexChanged
        paydate_ = Paydate_ComboB.SelectedItem

        Lists_Payout(Payout_list, paydate_)

        GetPayout_TOTALS(paydate_, P_GrossAmount_LBL, P_SSSComp_LBL, P_PagibigComp_LBL, P_PhilHComp_LBL, P_TaxWH_LBL,
                         P_SSSLoan_LBL, P_PagibigLoan_LBL, P_Allowance_LBL, P_Deduction_LBL, P_NetPay_LBL)
    End Sub

    Private Sub Payout_list_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Payout_list.MouseDoubleClick
        If Payout_list.SelectedItems.Count > 0 Then
            Cancel_BTN.PerformClick()
            BiometricID_TXT.Clear()
            Name_TXT.Clear()

            BiometricID_TXT.Text = Payout_list.FocusedItem.SubItems(1).Tag
            emp_id = Payout_list.FocusedItem.SubItems(11).Tag
            TabControl1.SelectedIndex = 1

            Details_Save_BTN.Text = "Edit"
            Details_Save_BTN.Enabled = True
        End If
    End Sub

    Private Sub Search_BTN_Click(sender As Object, e As EventArgs) Handles Search_BTN.Click
        'Grid_Payout(Payout_grid, paydate_, Search_TXT.Text)  
        Lists_Payout(Payout_list, paydate_, Search_TXT.Text)
    End Sub

    Private Sub Search_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Search_TXT.KeyPress
        If IsEnter(e) Then Search_BTN.PerformClick()
    End Sub

    Private Sub Calculate_Gross()

        TotalBasic_LBL.Text = (NoOfDays_TXT.Text * Rate_TXT.Text).ToString("N")

        TotalHol_LBL.Text = ((((Convert.ToInt32(SpecialHol_TXT.Text) * Convert.ToInt32(Rate_TXT.Text)) * specHoliday) / specHoliday) + (((Convert.ToInt32(RegularHol_TXT.Text) * Convert.ToInt32(Rate_TXT.Text)) * regHoliday) / regHoliday)).ToString("N") ' =========== CALCULATE hOLIDAY TO PESO ===========

        TotalOT_LBL.Text = (((Convert.ToInt32(Rate_TXT.Text) / 8) * 1.25) * Convert.ToInt32(RegularOT_TXT.Tag)).ToString("N") ' =========== CALCULATE OVERTIME TO PESO ===========

        Dim late_split() As String, under_split() As String, lateTOMinute, underToMinute As Double

        late_split = Split(Late_TXT.Tag, ":")
        under_split = Split(UnderTime_TXT.Tag, ":")

        lateTOMinute = CDbl(late_split(0)) * 60 + CDbl(late_split(1)) + CDbl(late_split(2)) / 60
        underToMinute = (CDbl(under_split(0)) * 60 + CDbl(under_split(1)) + CDbl(under_split(2)) / 60) / 60

        Dim LATEE, UNDERTIMEE As Double
        LATEE = ((Convert.ToInt32(Rate_TXT.Text) / 8) / 60) * lateTOMinute
        UNDERTIMEE = (Convert.ToInt32(Rate_TXT.Text) / 8) * underToMinute

        TotalLateUnder_LBL.Text = (LATEE + UNDERTIMEE).ToString("N")

        GrossAmount_LBL.Text = ((Convert.ToDouble(TotalBasic_LBL.Text) + Convert.ToDouble(TotalHol_LBL.Text) + Convert.ToDouble(TotalOT_LBL.Text)) - Convert.ToDouble(TotalLateUnder_LBL.Text)).ToString("N")

    End Sub

    Private Sub Calculate_Allowance()
        Dim totals As Double = 0
        If Allowance_grid.Rows.Count > 0 Then
            For Each row As DataGridViewRow In Allowance_grid.Rows
                totals = totals + row.Cells(1).Value
            Next
        End If

        Allowances_LBL.Text = totals.ToString("N")
    End Sub

    Private Sub Calculate_Deduction()

        Dim totals As Double = 0
        If Deduction_grid.Rows.Count > 0 Then
            For Each row As DataGridViewRow In Deduction_grid.Rows
                totals = totals + row.Cells(1).Value
            Next
        End If

        Deduction_LBL.Text = totals.ToString("N")

    End Sub

    Private Sub Calculate_NetPay()

        'netTax = If(Not (NetTax_LBL.Text = String.Empty), NetTax_LBL.Text, 0)
        gross = If(Not (GrossAmount_LBL.Text = String.Empty), GrossAmount_LBL.Text, 0)
        sssLoan = If(Not (SSSLoan_LBL.Text = String.Empty), SSSLoan_LBL.Text, 0)
        pagibigLoan = If(Not (PagibigLoan_LBL.Text = String.Empty), PagibigLoan_LBL.Text, 0)
        allowance = If(Not (Allowances_LBL.Text = String.Empty), Allowances_LBL.Text, 0)
        deduction = If(Not (Deduction_LBL.Text = String.Empty), Deduction_LBL.Text, 0)

        Dim CONTRIB As Double = CDbl(SSSComp_LBL.Text) + CDbl(HDMF_LBL.Text) + CDbl(Philhealth_LBL.Text) + CDbl(Tax_Wheld_LBL.Text)

        Dim positive, negative As Double
        If IsLastDay(paydate_) Then
            positive = gross + allowance
            negative = CONTRIB + sssLoan + pagibigLoan + deduction
        Else
            NetTax_LBL.Text = 0
            positive = gross + allowance
            negative = deduction
        End If

        NetPay_LBL.Text = (positive - negative).ToString("N")

    End Sub

    Private Sub OtherDeduction_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles BiometricID_TXT.KeyPress
        If e.KeyChar <> ChrW(Keys.Back) Then
            If Char.IsNumber(e.KeyChar) Then
            Else
                e.Handled = True
            End If
        End If
    End Sub

    '====================================================== PAYSLIP ==========================================================
    'Dim paydate As String = "August 15, 2021"
    'Dim namee, sss, philH, tin, hdmf, payslip_no, rate_type As String
    'Dim incentives, positional, total_Additional As Double
    'Dim total_basic, present_days, gross_amount As String
    Dim branchID As String

    Private Sub Preview_BTN_Click(sender As Object, e As EventArgs) Handles Preview_BTN.Click
        LoadPayslip(Employee_TXT.Tag, EmpSelect_BTN.Tag, Payslip_paydate_Combo.Text, Email_TXT.Tag)
    End Sub

    Private Sub Branch_ComboB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Branch_ComboB.SelectedIndexChanged
        If Branch_ComboB.SelectedIndex >= 0 Then
            branchID = GetBranch_ID(Branch_ComboB.SelectedItem)
        End If
    End Sub

    Private Sub Branch_RadioB_CheckedChanged(sender As Object, e As EventArgs) Handles Branch_RadioB.CheckedChanged
        If Branch_RadioB.Checked = True Then
            Branch_group.Visible = True
        Else
            Branch_group.Visible = False
        End If
    End Sub

    Private Sub Employee_RadioB_CheckedChanged(sender As Object, e As EventArgs) Handles Employee_RadioB.CheckedChanged
        If Employee_RadioB.Checked = True Then
            Employee_GroupB.Visible = True
        Else
            Employee_GroupB.Visible = False
        End If
    End Sub

    'Dim hours, sss_comp, pagibig_comp, philh_comp, tax_WH As Double
    'Dim sbu, otherLoan_perGive, charges_perGive, cash_advance_perGive, total_deduction As Double
    'Dim sss_loan, pagibig_loan, net_pay As Double
    'Dim thirteen_month As Double = 0

    Private Sub Close_LBL_Click(sender As Object, e As EventArgs) Handles Close_LBL.Click
        Close()
    End Sub

    Public Sub Send_Email(byteViewer As Byte(), recipient_Email As String, recipient_Name As String, Optional FOR_single As String = "")
        Try
            Dim FoundMatch As Boolean = Regex.IsMatch(recipient_Email, "\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase)

            If Not FoundMatch Then
                MsgBox(recipient_Name & " has an INVALID EMAIL ADDRESS.", MsgBoxStyle.Exclamation, "INVALID")
                Exit Sub
            End If

            Dim email As String = GetEmail()
            Dim password As String = GetPassword()
            Dim datee As DateTime = Payslip_paydate_Combo.Text

            Dim Smtp_Server As New SmtpClient
            Dim e_mail As New MailMessage()
            Smtp_Server.UseDefaultCredentials = False
            Smtp_Server.Credentials = New Net.NetworkCredential(email, password)
            Smtp_Server.Port = 587
            Smtp_Server.EnableSsl = True
            Smtp_Server.Host = "smtp.gmail.com"

            e_mail = New MailMessage()
            e_mail.From = New MailAddress(email)
            e_mail.To.Add(recipient_Email)
            e_mail.Subject = datee.ToString("MMMM dd, yyyy") & " PAYROLL"
            e_mail.IsBodyHtml = False

            Dim memoryStream = New MemoryStream(byteViewer)
            memoryStream.Seek(0, SeekOrigin.Begin)

            Dim attachment = New Attachment(memoryStream, recipient_Name & ".pdf")
            e_mail.Attachments.Add(attachment)

            e_mail.Body = BodyText_RichB.Text
            Smtp_Server.Send(e_mail)

            If Not FOR_single = String.Empty Then
                MsgBox("Email Sent!")
            End If

        Catch error_t As Exception
            MsgBox(error_t.ToString)
        End Try
    End Sub

    Private Sub Rate_EmpSelect_BTN_Click(sender As Object, e As EventArgs) Handles EmpSelect_BTN.Click
        If Payslip_paydate_Combo.SelectedIndex < 0 Then
            MsgBox("Please Select payroll date!", MsgBoxStyle.Exclamation, "Error")
        Else
            If frmEmployee Is Nothing Then
                Dim frm As New frmEmployee With {
                    .MdiParent = frmMainForm
                }
                frmMainForm.pNavigate.Controls.Add(frm)
                frmMainForm.pNavigate.Tag = frm
                frm.txtSearch.Tag = "Payslip-Employee"
                frm.btnSearch.Tag = Payslip_paydate_Combo.Text
                frm.Show()
                frm.Dock = DockStyle.Fill
                frm.BringToFront()
            Else
                frmEmployeeInfo.BringToFront()
            End If
        End If
    End Sub

    Private Sub Send_BTN_Click(sender As Object, e As EventArgs) Handles Send_BTN.Click

        Dim recipient As String
        If All_RadioB.Checked = True Then
            Dim mysqll As String = $"select A.*, B.*, C.*, C.id as emp_id from payroll_payout A 
                                                inner join tbl_employee C on C.BIOMETRICID = A.BIOMETRIC_ID 
                                                inner join tbl_branch B on B.ID = A.BRANCH_ID  
                                                where paydate = '{Payslip_paydate_Combo.Text}';"

            Using ds As DataSet = LoadSQL(mysqll, "payroll_payout")
                If ds.Tables(0).Rows.Count > 0 Then
                    progressBarStart(ds.Tables(0).Rows.Count)
                    For Each dr In ds.Tables(0).Rows
                        With dr

                            Dim MI As String

                            If String.IsNullOrEmpty(.Item("MIDDLENAME")) Then
                                MI = ""
                            Else
                                MI = .Item("MIDDLENAME").Substring(0, 1) & "."
                            End If

                            Dim namee = String.Format("{0}, {1} {2}", .Item("LastName"), .Item("FirstName"), MI)

                            Dim branch_name As String = .item("BRANCHNAME")
                            LoadPayslip(.item("BIOMETRIC_ID"), .item("BRANCH_ID"), Payslip_paydate_Combo.Text, branch_name)

                            recipient = GetEmail_recipient(.item("BIOMETRIC_ID"), .item("BRANCH_ID"))

                            Deduct_ifExist(.Item("emp_id"), Payslip_paydate_Combo.Text)             '======= REFLECT DEDUCTION IF EXIST

                            Send_Email(ReportViewer_payslip.LocalReport.Render("PDF"), recipient, namee)

                            frmMainForm.AppProgressBar.Value += 1
                        End With
                    Next
                    progressBarEnd()
                End If
            End Using

        ElseIf Branch_RadioB.Checked = True Then

            Dim mysqll As String = $"select A.*, B.*, C.*, C.id as emp_id from payroll_payout A 
                                                inner join tbl_employee C on C.BIOMETRICID = A.BIOMETRIC_ID 
                                                inner join tbl_branch B on B.ID = A.BRANCH_ID  
                                                where paydate = '{Payslip_paydate_Combo.Text}' and A.BRANCH_ID = '{branchID}';"

            Using ds As DataSet = LoadSQL(mysqll, "payroll_payout")
                If ds.Tables(0).Rows.Count > 0 Then
                    progressBarStart(ds.Tables(0).Rows.Count)
                    For Each dr In ds.Tables(0).Rows
                        With dr

                            Dim MI As String

                            If String.IsNullOrEmpty(.Item("MIDDLENAME")) Then
                                MI = ""
                            Else
                                MI = .Item("MIDDLENAME").Substring(0, 1) & "."
                            End If

                            Dim namee = String.Format("{0}, {1} {2}", .Item("LastName"), .Item("FirstName"), MI)

                            Dim branch_name As String = .item("BRANCHNAME")
                            LoadPayslip(.item("BIOMETRIC_ID"), branchID, Payslip_paydate_Combo.Text, branch_name)

                            recipient = GetEmail_recipient(.item("BIOMETRIC_ID"), branchID)

                            Deduct_ifExist(.Item("emp_id"), Payslip_paydate_Combo.Text)             '======= REFLECT DEDUCTION IF EXIST

                            Send_Email(ReportViewer_payslip.LocalReport.Render("PDF"), recipient, namee)

                            frmMainForm.AppProgressBar.Value += 1
                        End With
                    Next

                    progressBarEnd()
                End If
            End Using
        Else
            'LoadPayslip(Employee_TXT.Tag, EmpSelect_BTN.Tag, Payslip_paydate_Combo.Text, Email_TXT.Tag)
            'recipient = GetEmail_recipient(Employee_TXT.Tag, EmpSelect_BTN.Tag)

            Deduct_ifExist(Preview_BTN.Tag, Payslip_paydate_Combo.Text)             '======= REFLECT DEDUCTION IF EXIST  (Preview_BTN.Tag = EMP_ID)
            'Send_Email(ReportViewer_payslip.LocalReport.Render("PDF"), recipient, Employee_TXT.Text, "single")
        End If

    End Sub

    Public Sub LoadPayslip(biometricID As String, branchID As String, paydatee As String, branch_name As String)

        ReportViewer_payslip.LocalReport.DataSources.Clear()

        Dim sched As String
        Dim date_pay As DateTime = Convert.ToDateTime(paydatee)
        date_pay = date_pay.ToString("d")

        If IsLastDay(date_pay) Then
            sched = "CLOSE PAYROLL"
        Else
            sched = "OPEN PAYROLL"
        End If

        Try
            '============================================ EMPLOYEE DETAILS ================================================
            Dim dt_employee As New DataTable()
            With dt_employee
                .Columns.Add("COMPLETE_NAME")
                .Columns.Add("SSSNO")
                .Columns.Add("PHILHEALTHNO")
                .Columns.Add("TINNO")
                .Columns.Add("PAGIBIG")
            End With

            Dim sql As String = $"select * from TBL_Employee where BIOMETRICID = '{biometricID}';"
            Using ds As DataSet = LoadSQL(sql, "TBL_Employee")
                If ds.Tables(0).Rows.Count > 0 Then
                    Dim data As DataRow = ds.Tables(0).Rows(0)
                    With data

                        Dim namee As String = String.Format("{0}, {1} {2}", .Item("LastName"), .Item("FirstName"), .Item("MiddleName"))
                        dt_employee.Rows.Add(namee, .Item("SSSNO"), .Item("PHILHEALTHNO"), .Item("TINNO"), .Item("PAGIBIG"))

                    End With
                End If
            End Using

            Dim rds_employee As New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt_employee)
            ReportViewer_payslip.LocalReport.DataSources.Add(rds_employee)


            '============================================ EMPLOYEE ATTENDANCE AND PAYOUT ================================================
            Dim dt_attendance As New DataTable()
            With dt_attendance
                .Columns.Add("PRESENT_DAYS")
                .Columns.Add("OVERTIME")
                .Columns.Add("REGHOLIDAY")
                .Columns.Add("SPECHOLIDAY")
                .Columns.Add("TOTAL_LATE_UT")
                .Columns.Add("TOTAL_BASIC")
                .Columns.Add("TOTAL_OVERTIME")
                .Columns.Add("LATE")
                .Columns.Add("GROSS_AMOUNT")
                .Columns.Add("SSS_COMP")
                .Columns.Add("PAGIBIG_COMP")
                .Columns.Add("PHILHEALTH_COMP")
                .Columns.Add("TAX_WHELD")
                .Columns.Add("SSS_LOAN")
                .Columns.Add("PAGIBIG_LOAN")
                .Columns.Add("NET_PAY")
                .Columns.Add("SBU")
                .Columns.Add("TOTAL_DEDUCTION")
                .Columns.Add("present_hours")
            End With

            Dim PRESENT_DAYS As String = ""
            Dim OVERTIME As String = ""
            Dim REGHOLIDAY As String = ""
            Dim SPECHOLIDAY As String = ""
            Dim LATE As String = ""
            Dim present_hours As Double = 0

            Dim _mysql As String = $"select * from payroll_attendance where BIOMETRICID = '{biometricID}' and paydate = '{paydatee}' and BRANCH = '{branch_name}';"
            Using ds As DataSet = LoadSQL(_mysql, "payroll_attendance")
                If ds.Tables(0).Rows.Count > 0 Then
                    Dim data As DataRow = ds.Tables(0).Rows(0)
                    With data

                        present_hours = (.Item("PRESENT_DAYS") / 0.5) * 4 'CALCULATE PRESENT DAYS TO HOURS

                        PRESENT_DAYS = .Item("PRESENT_DAYS")
                        OVERTIME = .Item("OVERTIME") & ":00"
                        REGHOLIDAY = .Item("REGHOLIDAY")
                        SPECHOLIDAY = .Item("SPECHOLIDAY")
                        LATE = .Item("LATE").Substring(0, 5)

                    End With
                End If
            End Using

            Dim mysqll As String = $"select * from payroll_payout where BIOMETRIC_ID = '{biometricID}' and paydate = '{paydatee}' and BRANCH_ID = '{branchID}';"
            Using ds As DataSet = LoadSQL(mysqll, "payroll_payout")
                If ds.Tables(0).Rows.Count > 0 Then
                    Dim data As DataRow = ds.Tables(0).Rows(0)
                    With data

                        Dim TOTAL_COMP As Double = .Item("SSS_COMP") + .Item("PAGIBIG_COMP") + .Item("PHILHEALTH_COMP") + .Item("TAX_WHELD") + .Item("SSS_LOAN") + .Item("PAGIBIG_LOAN")

                        dt_attendance.Rows.Add(PRESENT_DAYS, OVERTIME, REGHOLIDAY, SPECHOLIDAY, CDbl(.Item("TOTAL_LATE_UT")).ToString("N"),
                                        CDbl(.Item("TOTAL_BASIC")).ToString("N"), CDbl(.Item("TOTAL_OVERTIME")).ToString("N"), LATE,
                                        CDbl(.Item("GROSS_AMOUNT")).ToString("N"), CDbl(.Item("SSS_COMP")).ToString("N"), CDbl(.Item("PAGIBIG_COMP")).ToString("N"),
                                        CDbl(.Item("PHILHEALTH_COMP")).ToString("N"), CDbl(.Item("TAX_WHELD")).ToString("N"), CDbl(.Item("SSS_LOAN")).ToString("N"),
                                        CDbl(.Item("PAGIBIG_LOAN")).ToString("N"), CDbl(.Item("NET_PAY")).ToString("N"), CDbl(SBU_Amount()).ToString("N"), TOTAL_COMP.ToString("N"),
                                        present_hours)

                        Console.WriteLine("payouttt innn")
                    End With
                End If
            End Using

            Dim rds_attendance As New Microsoft.Reporting.WinForms.ReportDataSource("DataSet2", dt_attendance)
            ReportViewer_payslip.LocalReport.DataSources.Add(rds_attendance)

            '============================================ EMPLOYEE ALLOWANCES ================================================ 
            Dim dt_allowance As New DataTable()
            With dt_allowance
                .Columns.Add("CATEGORY")
                .Columns.Add("AMOUNT")
                .Columns.Add("TOTALS")
            End With

            'Allowances = 0

            'Dim sql_2 As String = $"Select * From PAYROLL_ALLOWANCES WHERE BIOMETRIC_NO = '{biometricID}' and BRANCH_ID = '{branchID}'  and ALLOWED is null and SCHEDULE = '{sched}'"
            'Using ds_2 As DataSet = LoadSQL(sql_2, "PAYROLL_ALLOWANCES")
            '    If ds_2.Tables(0).Rows.Count > 0 Then
            '        For Each dr_2 In ds_2.Tables(0).Rows
            '            With dr_2
            '                If .item("EFFECTIVE_DATE") <= Today Then
            '                    Allowances = Allowances + .Item("AMOUNT")
            '                End If
            '            End With
            '        Next
            '    End If
            'End Using


            Dim total_Allowance As Double = 0
            If isExist_single("payroll_allowances", "BIOMETRIC_NO", biometricID) Then

                Dim mysql_allow As String = $"select * from PAYROLL_ALLOWANCES WHERE BIOMETRIC_NO = '{biometricID}' and BRANCH_ID = '{branchID}'  and ALLOWED is null and SCHEDULE = '{sched}'"
                Using ds As DataSet = LoadSQL(mysql_allow, "payroll_allowances")
                    If ds.Tables(0).Rows.Count > 0 Then
                        For Each drr In ds.Tables(0).Rows
                            With drr
                                If .item("EFFECTIVE_DATE") <= Today Then
                                    total_Allowance = total_Allowance + .Item("AMOUNT")
                                End If
                            End With
                        Next
                    End If
                End Using

                Dim mysql_1 As String = $"select * from payroll_allowances  where BIOMETRIC_NO = '{biometricID}' and BRANCH_ID = '{branchID}'  and ALLOWED is null and SCHEDULE = '{sched}'"
                Using ds As DataSet = LoadSQL(mysql_1, "payroll_allowances")
                    If ds.Tables(0).Rows.Count > 0 Then
                        For Each dr In ds.Tables(0).Rows
                            With dr
                                If .item("EFFECTIVE_DATE") <= Today Then

                                    Dim amountt As Double = .item("AMOUNT")

                                    Dim toLower = .item("CATEGORY").ToLower()
                                    Dim info As TextInfo = CultureInfo.InvariantCulture.TextInfo
                                    Dim toProper As String = info.ToTitleCase(toLower)

                                    dt_allowance.Rows.Add(toProper, amountt.ToString(”N”), total_Allowance.ToString(”N”))

                                End If
                            End With
                        Next
                    End If
                End Using
            End If

            Dim rds_allowance As New Microsoft.Reporting.WinForms.ReportDataSource("DataSet3", dt_allowance)
            ReportViewer_payslip.LocalReport.DataSources.Add(rds_allowance)

            '============================================ EMPLOYEE OTHER DEDUCTIONS ================================================

            Dim dt_deduction As New DataTable()
            With dt_deduction
                .Columns.Add("CATEGORY")
                .Columns.Add("AMOUNT_PER_GIVE")
                .Columns.Add("TOTALS")
            End With

            Dim total_deduction As Double = 0
            If isExist_single("payroll_deductions", "BIOMETRIC_NO", biometricID) Then

                Dim mysql_de As String = $"Select * From payroll_deductions WHERE BIOMETRIC_NO = '{biometricID}' and BRANCHID = '{branchID}' and STATUS is null and (SCHEDULE = '{sched}' or SCHEDULE = 'EVERY PAYROLL')"
                Using ds As DataSet = LoadSQL(mysql_de, "payroll_deductions")
                    If ds.Tables(0).Rows.Count > 0 Then
                        For Each drr In ds.Tables(0).Rows
                            With drr
                                If .item("EFFECTIVE_DATE") <= Today Then
                                    total_deduction = total_deduction + .Item("AMOUNT_PER_GIVE")
                                End If
                            End With
                        Next
                    End If

                End Using

                Dim mysql_2 As String = $"select * from payroll_deductions  where BIOMETRIC_NO = '{biometricID}'  and BRANCHID = '{branchID}' and STATUS is null and (SCHEDULE = '{sched}' or SCHEDULE = 'EVERY PAYROLL')"
                Using ds As DataSet = LoadSQL(mysql_2, "payroll_deductions")
                    If ds.Tables(0).Rows.Count > 0 Then
                        For Each dr In ds.Tables(0).Rows
                            With dr
                                If .Item("EFFECTIVE_DATE") <= Today Then

                                    Dim amountt As Double = .item("AMOUNT_PER_GIVE")

                                    Dim toLower = .item("CATEGORY").ToLower()
                                    Dim info As TextInfo = CultureInfo.InvariantCulture.TextInfo
                                    Dim toProper As String = info.ToTitleCase(toLower)

                                    dt_deduction.Rows.Add(toProper, amountt.ToString(”N”), total_deduction.ToString(”N”))

                                End If
                            End With

                        Next
                    End If
                End Using
            End If

            Dim rds_deduction As New Microsoft.Reporting.WinForms.ReportDataSource("DataSet4", dt_deduction)
            ReportViewer_payslip.LocalReport.DataSources.Add(rds_deduction)

            '============================================ PAYDATE ================================================ 
            Dim paramList As New List(Of Microsoft.Reporting.WinForms.ReportParameter) From {
            New Microsoft.Reporting.WinForms.ReportParameter("paramDate", paydatee)
            }

            ReportViewer_payslip.LocalReport.SetParameters(paramList)
            ReportViewer_payslip.RefreshReport()

        Catch ex As Exception
            Log_Report(ex.ToString)
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


End Class