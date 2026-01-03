Imports System.Globalization
Imports System.IO
Imports System.Text.RegularExpressions
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports Microsoft.Reporting.WinForms
Imports PdfSharp.Pdf
Imports PdfSharp.Pdf.IO
Imports Syncfusion.Pdf.Lists
Imports PdfReader = iTextSharp.text.pdf.PdfReader

Public Class frmPayout

    Dim rowCount As Integer
    Dim STANDARD_DAYS As Integer = frmMainForm.DAYS_COUNT
    Dim regHoliday_, specHoliday_ As Double
    Public paydate_ As String = frmMainForm.Paydate.ToShortDateString
    Dim SBU, Charges, Loan, CashAdvance, other As Decimal
    Dim SBUUU, Chargesss, Loannn, CashAdvanceee, otherrr As Decimal
    Dim gross, netTax, sssLoan, pagibigLoan, allowance, deduction As Decimal
    Dim sched_deduc As String
    Dim SSS_ER, SSS_EC As Decimal
    Dim Zeroo As String = "0.00"

    Private allowCoolMove As Boolean = False
    Private myCoolPoint As New Point

    Private Sub frmPayout_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        regHoliday_ = Holiday_Rate("REGULAR")
        specHoliday_ = Holiday_Rate("SPECIAL")
        PopulateComboBox(Paydate_ComboB, "PAYROLL_PAYOUT", "PAYDATE", True)

        '========================== PAYSLIP ===========================
        PopulateComboBox(Payslip_paydate_Combo, "PAYROLL_PAYOUT", "PAYDATE", True)
        PopulateComboBox(Branch_ComboB, "TBL_EMPLOYEE", "BRANCHCODE")
        PopulateComboBox(Branch_ComboB, "TBL_EMPLOYEE", "BRANCHCODE")

        Paydate_ComboB.Text = "--Select Payroll--"
    End Sub

    Private Sub Select_BTN_Click(sender As Object, e As EventArgs) Handles Select_BTN.Click

        Try

            Dim instForm As Form = Application.OpenForms.OfType(Of Form)().Where(Function(frm) frm.Name = "frmNewEmployee").SingleOrDefault()
            If instForm Is Nothing Then
                Dim frm As frmNewEmployee
                frm = DirectCast(CreateObjectInstance("frmNewEmployee"), Form)
                frm.MdiParent = frmMainForm
                frmMainForm.pNavigate.Controls.Add(frm)
                frmMainForm.pNavigate.Tag = frm
                frm.txtSearch.Tag = "Payout"
                frm.Dock = DockStyle.Fill
                frm.BringToFront()
                frm.Show()
            Else
                instForm.BringToFront()
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub BiometricID_TXT_TextChanged(sender As Object, e As EventArgs) Handles BiometricID_TXT.TextChanged

        If BiometricID_TXT.Text = "" Then
            Cancel_BTN.PerformClick()
        Else
            DETAILS()
        End If

        Dim dateNow As DateTime = Date.Today
        Dim _paydate_ As DateTime = paydate_
        If dateNow > _paydate_ Then
            Details_Save_BTN.Enabled = False
        Else
            Details_Save_BTN.Enabled = True
        End If

    End Sub

    Public Sub DETAILS()

        Dim BIO_NO As String = BiometricID_TXT.Text

        Allowance_grid.Rows.Clear()
        Deduction_grid.Rows.Clear()

        If Bio_Exist_Attendance(BIO_NO, paydate_) Then

            AttendanceDetails(BIO_NO, paydate_, NoOfDays_TXT, RegularOT_TXT, SpecialHol_TXT, RegularHol_TXT,
                                        Late_TXT, UnderTime_TXT, TrainingDays_LBL, NightTime_TXT,
                                        TrainingOT_LBL, TrainningLate_LBL, TrainingUT_LBL, TrainingSHol_LBL, TrainningNight_LBL)

            PayoutDetails(BIO_NO, paydate_, Rate_TXT, Name_TXT, RateFixYes_RB, TotalBasic_LBL, TotalOT_LBL,
                                        TotalHol_LBL, TotalNight_LBL, TotalLateUnder_LBL, SSSComp_LBL, HDMF_LBL, Philhealth_LBL, GrossAmount_LBL)

            If RateFixYes_RB.Checked = True Then
                RegularOT_TXT.Text = 0
                SpecialHol_TXT.Text = 0
                RegularHol_TXT.Text = 0
                Late_TXT.Text = 0
                UnderTime_TXT.Text = 0
                NightTime_TXT.Text = 0
            End If

            ''============================ CHECK IF NOT TRAINEE ==================================  
            'If TrainingDays_LBL.Text = 0 Or TrainingDays_LBL.Text = Nothing Then
            '    Training_GB.Visible = False
            '    '============================ CHECK IF CLOSE PAYROLL ==================================  
            '    If IsLastDay(paydate_) Then
            '        If BIO_NO <> 58 Then

            '            Dim monthly_Basic As Double = GetMonthly_Basic(BIO_NO, paydate_)
            '            Prev_Amount_lbl.Text = (GetFirst_Basic(BIO_NO, paydate_)).ToString("N")

            '            Previous_groupB.Visible = True

            '            Remittance_LBL.Text = (CDbl(SSSComp_LBL.Text) + CDbl(HDMF_LBL.Text) + CDbl(Philhealth_LBL.Text)).ToString(”N”)
            '            Remittance_LBL.Tag = (CDbl(SSSComp_LBL.Text) + CDbl(HDMF_LBL.Text) + CDbl(Philhealth_LBL.Text)).ToString(”N”)

            '            sched_deduc = "CLOSE PAYROLL"
            '        End If

            '    Else
            '        Previous_groupB.Visible = False
            '        Remittance_LBL.Text = Zeroo

            '        sched_deduc = "OPEN PAYROLL"
            '    End If
            'Else
            '    Remittance_LBL.Text = Zeroo
            '    Training_GB.Visible = True
            'End If 

            '============================ WITHOUT TRAINING (REMOVED) ============================== 
            '============================ CHECK IF CLOSE PAYROLL ==================================  

            If CDec(Rate_TXT.Text) > 0 Then
                Remittance_LBL.Text = (CDbl(SSSComp_LBL.Text) + CDbl(HDMF_LBL.Text) + CDbl(Philhealth_LBL.Text)).ToString(”N”)
                Remittance_LBL.Tag = (CDbl(SSSComp_LBL.Text) + CDbl(HDMF_LBL.Text) + CDbl(Philhealth_LBL.Text)).ToString(”N”)
            End If

            If IsLastDay(paydate_) Then
                If BIO_NO <> 58 Then

                    Dim monthly_Basic As Double = GetMonthly_Basic(BIO_NO, paydate_)
                    Prev_Amount_lbl.Text = (GetFirst_Basic(BIO_NO, paydate_)).ToString("N")

                    Previous_groupB.Visible = True

                    sched_deduc = "CLOSE PAYROLL"
                End If
            Else
                Previous_groupB.Visible = False
                sched_deduc = "OPEN PAYROLL"
            End If


            '================ FETCHING ALLOWANCE RECORDED WHEN ATTENDANCE BIOMETRIC IMPORTED ================== 
            If isExist_String("RECORDED_ALLOW_DEDUC", $"WHERE BIO_NO = '{BIO_NO}' AND PAYDATE = '{paydate_}' AND TRANSAC_NAME = 'ALLOWANCE'") Then
                Recorded_Details(BIO_NO, Allowance_grid, paydate_, "ALLOWANCE")

                If Allowance_grid.Rows.Count >= 0 Then
                    Dim totalRowHeight As Integer = Allowance_grid.ColumnHeadersHeight
                    For Each row As DataGridViewRow In Allowance_grid.Rows
                        totalRowHeight += row.Height
                        row.Height = 25
                    Next
                    Allowance_grid.Height = totalRowHeight
                    'Allowance_grid.DefaultCellStyle.Font = New Font("Dubai", 11) 'TODO FONT
                End If

            End If

            '================ FETCHING ALLOWANCE RECORDED WHEN ATTENDANCE BIOMETRIC IMPORTED ==================
            If isExist_String("RECORDED_ALLOW_DEDUC", $"WHERE BIO_NO = '{BIO_NO}' AND PAYDATE = '{paydate_}' AND TRANSAC_NAME = 'DEDUCTION'") Then         '=========m RECORDED DEDUCTION IMPORTING ATTENDANCE
                Recorded_Details(BIO_NO, Deduction_grid, paydate_, "DEDUCTION")

                If Deduction_grid.Rows.Count >= 0 Then
                    Dim totalRowHeight As Integer = Deduction_grid.ColumnHeadersHeight
                    Dim totalColumnHeight As Integer = Deduction_grid.RowHeadersWidth
                    For Each row As DataGridViewRow In Deduction_grid.Rows
                        totalRowHeight += row.Height
                        row.Height = 25
                    Next
                    Deduction_grid.Height = totalRowHeight
                    'Deduction_grid.DefaultCellStyle.Font = New Font("Dubai", 11) 'TODO FONT
                End If

            End If

            '==========================  CHECK PAYDATE IF VALID FOR EDITING (DEDUCTION) =========================   
            If paydate_ = frmMainForm.Paydate.ToString("d") Then
                Deduction_grid.Enabled = True
                Deduction_BTN.Enabled = True
                Additional_BTN.Enabled = True
            Else
                Deduction_grid.Enabled = False
                Deduction_BTN.Enabled = False
                Additional_BTN.Enabled = False
            End If

            Calculate_Allowance()

            Calculate_Deduction()

            Calculate_NetPay()

            Checkgrid_Visible()
        Else

            For Each Ctl In GroupBox1.Controls
                If TypeOf Ctl Is TextBox Then Ctl.Text = ""
            Next

        End If
    End Sub

    Private Sub Checkgrid_Visible() ' ============== Allowance and Deduction

        '========================== Check if allowance grid has rows =====================  
        If Allowance_grid.RowCount > 0 Then
            Allowance_grid.Visible = True
        Else
            Allowance_grid.Visible = False
        End If

        '========================== Check if deduction grid has rows =====================  
        If Deduction_grid.RowCount > 0 Then
            Deduction_grid.Visible = True
        Else
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
                row.Cells(1).Value = CDec(row.Cells(0).Tag).ToString("N")
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

        For Each Ctl In GroupBox4.Controls
            If TypeOf Ctl Is Label Then

                If IsNumeric(Ctl.text) Then
                    Ctl.Text = 0
                End If

            End If
        Next

        Deduction_grid.Rows.Clear()
        Allowance_grid.Rows.Clear()
        Prev_Amount_lbl.Text = "-"
    End Sub

    Private Sub Details_Save_BTN_Click(sender As Object, e As EventArgs) Handles Details_Save_BTN.Click

        If Not Name_TXT.Text = String.Empty Then
            Dim BIO_NO As String = BiometricID_TXT.Text

            Dim allow_list = Nothing, deduc_list As String = Nothing

            Dim rate As Double = Rate_TXT.Text
            Dim reg_holiday As String = (CDbl(RegularHol_TXT.Text) * rate) * regHoliday_
            Dim spec_holiday As String = ((CDbl(SpecialHol_TXT.Text) / 8) * rate) * specHoliday_

            If TrainingDays_LBL.Text > 0 Then '====== IF TRAINEE / TRAINING HOLIDAY
                Dim trainee_rate = rate * 0.75
                Dim regHoliday = Holiday_Rate("REGULAR")
                Dim specHoliday = Holiday_Rate("SPECIAL")
                Dim RegularHol As Double = CDbl(RegularHol_TXT.Text)
                Dim Training_REGHoliday As Decimal = GetData_Decimal("TRAINING_REGHOLIDAY", $"PAYROLL_ATTENDANCE WHERE BIOMETRICID = '{BIO_NO}' AND PAYDATE = '{paydate_}'")
                Dim SpecialHol_hrs As Double = CDbl(SpecialHol_TXT.Text)
                Dim Training_SPECHoliday As Double = CDbl(TrainingSHol_LBL.Text)

                If RegularHol <> 0 Then RegularHol = Math.Abs(RegularHol - Training_REGHoliday)
                If SpecialHol_hrs <> 0 Then SpecialHol_hrs = Math.Abs(SpecialHol_hrs - Training_SPECHoliday)

                Dim REG_STANDARD As Decimal = (RegularHol * rate) * regHoliday
                Dim SPEC_STANDARD As Decimal = ((SpecialHol_hrs / 8) * rate) * specHoliday

                Dim REG_TRAINEE As Decimal = (Training_REGHoliday * trainee_rate) * regHoliday
                Dim SPEC_TRAINEE As Decimal = ((Training_SPECHoliday / 8) * trainee_rate) * specHoliday

                reg_holiday = REG_STANDARD + REG_TRAINEE
                spec_holiday = SPEC_STANDARD + SPEC_TRAINEE

            End If


            '===================== MINIMUM RATE CHANGED ===================== 
            If ThisHasRow($"CHANGE_MINIMUM_RATE WHERE PAYDATE = '{paydate_}'") AndAlso ThisHasRow($"TBL_EMPLOYEE WHERE BIOMETRICID = '{BIO_NO}' AND MINIMUM_RATE_UPDATED_AT = '{paydate_}'") Then
                Dim Old_Rate As Decimal = GetData_Decimal("OLD_RATE", $"TBL_EMPLOYEE WHERE BIOMETRICID = '{BIO_NO}'")
                Dim newMin_rholiday As Integer = REG_SPEC_HOLIDAY(BIO_NO, paydate_).rholiday
                Dim newMin_sholiday As Integer = REG_SPEC_HOLIDAY(BIO_NO, paydate_).sholiday

                Dim old_rholiday As Decimal = ((CDbl(RegularHol_TXT.Text) - newMin_rholiday) * Old_Rate) * regHoliday_
                Dim new_rholiday As Decimal = (newMin_rholiday * rate) * regHoliday_

                Dim old_sholiday As Decimal = (((CDbl(SpecialHol_TXT.Text) - newMin_sholiday) / 8) * Old_Rate) * specHoliday_
                Dim new_sholiday As Decimal = ((newMin_sholiday / 8) * rate) * specHoliday_

                If fix_monthly_rate Then
                    reg_holiday = 0
                    spec_holiday = 0
                Else
                    reg_holiday = old_rholiday + new_rholiday
                    spec_holiday = old_sholiday + new_sholiday
                End If

            End If

            Dim result As DialogResult = MessageBox.Show($"The record will be edited, do you want to proceed?", "Warning", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then

                'If payrollSched = "CLOSE PAYROLL" Then
                '    If BIO_NO <> 58 Then
                '        Dim first_Basic As Decimal = GetFirst_Basic(BIO_NO, paydate_)
                '        Dim monthly_Basic As Decimal = CDec(TotalBasic_LBL.Tag) + first_Basic

                '        If ThisNotIsNull("SSSNO", $"TBL_EMPLOYEE where BIOMETRICID = {BIO_NO} ") Then 'IF HAS SSSNO DETAILS 
                '            Get_SSS(monthly_Basic)
                '            'SSSComp = SSSEE
                '            SSS_ER = SSSER
                '            SSS_EC = SSSEC
                '        End If
                '    End If
                'End If 
                'FOR NEXT MONTH DIVISION OF REMITTANCE
                '======================== CHECK IF CLOSE PAYROLL ==================================  
                Dim hasSSSComp As Boolean = IIf(CDec(SSSComp_LBL.Text) = 0, False, True)
                If hasSSSComp Then
                    If payrollSched = "CLOSE PAYROLL" Then
                        If BIO_NO <> 58 And isRemittanceActivated(BIO_NO, paydate_) Then
                            Dim first_Basic As Decimal = GetFirst_Basic(BIO_NO, paydate_)
                            Dim monthly_Basic As Decimal = CDec(TotalBasic_LBL.Tag) + first_Basic

                            If ThisNotIsNull("SSSNO", $"TBL_EMPLOYEE where BIOMETRICID = {BIO_NO} ") Then 'IF HAS SSSNO DETAILS
                                Get_SSS(monthly_Basic)
                                Dim firstSSSComp As Decimal = GetFirst_Conttrib(BIO_NO, paydate_, "SSS_COMP")
                                Dim firstSSS_ER As Decimal = GetFirst_Conttrib(BIO_NO, paydate_, "SSS_ER")
                                Dim firstSSS_EC As Decimal = GetFirst_Conttrib(BIO_NO, paydate_, "SSS_EC")
                                SSS_ER = SSSER - firstSSS_ER
                                SSS_EC = SSSEC - firstSSS_EC

                                'TEMPORARILY (November 15, 2025 ADJUSTMENT) KALAHATI NALANG DAPAT ANG SSS_ER AND SSS_EC sa November 30, 2025
                                If paydate_ = "11/30/2025" Then
                                    SSS_EC = 5
                                End If

                            End If
                        End If
                    Else
                        If BIO_NO <> 58 And isRemittanceActivated(BIO_NO, paydate_) Then
                            If ThisNotIsNull("SSSNO", $"TBL_EMPLOYEE where BIOMETRICID = {BIO_NO} ") Then 'IF HAS SSSNO DETAILS
                                Get_SSS(CDec(TotalBasic_LBL.Tag))
                                SSS_ER = SSSER
                                SSS_EC = SSSEC
                            End If
                        End If
                    End If
                Else
                    SSS_ER = 0
                    SSS_EC = 0
                End If

                SavePayout(BIO_NO, paydate_, TotalBasic_LBL.Tag, TotalOT_LBL.Tag,
                  TotalLateUnder_LBL.Tag, GrossAmount_LBL.Tag, SSSComp_LBL.Text, SSS_ER, SSS_EC,
                  HDMF_LBL.Text, Philhealth_LBL.Text, Allowances_LBL.Tag, Deduction_LBL.Tag, NetPay_LBL.Tag,
                  reg_holiday, spec_holiday, TotalNight_LBL.Tag, Rate_TXT.Text, "")

                '====================================== SAVE NEW ADDITIONAL ===================================================
                If Allowance_grid.Rows.Count > 0 Then

                    If isExist_String("RECORDED_ALLOW_DEDUC", $"WHERE BIO_NO = '{BIO_NO}' AND PAYDATE = '{paydate_}' AND TRANSAC_NAME = 'ALLOWANCE'") Then
                        RunCommand($"DELETE FROM RECORDED_ALLOW_DEDUC WHERE BIO_NO = '{BIO_NO}' and PAYDATE = '{paydate_}' AND TRANSAC_NAME = 'ALLOWANCE';")
                    End If

                    For Each row As DataGridViewRow In Allowance_grid.Rows
                        Save_Recorded_Allow_Deduc(BiometricID_TXT.Text, paydate_, row.Cells(0).Value, row.Cells(0).Tag, "ALLOWANCE")

                        '======================== SAVING TRANSACTION ========================
                        If allow_list <> Nothing Then
                            allow_list = $"{allow_list}, {row.Cells(0).Value}({row.Cells(1).Value}), "
                        Else
                            allow_list = $"{row.Cells(0).Value}({row.Cells(1).Value}), "
                        End If

                    Next

                End If

                '====================================== SAVE NEW DEDUCTION ===================================================
                If Deduction_grid.Rows.Count > 0 Then

                    If isExist_String("RECORDED_ALLOW_DEDUC", $"WHERE BIO_NO = '{BIO_NO}' AND PAYDATE = '{paydate_}' AND TRANSAC_NAME = 'DEDUCTION'") Then
                        RunCommand($"DELETE FROM RECORDED_ALLOW_DEDUC WHERE BIO_NO = '{BIO_NO}' and PAYDATE = '{paydate_}' AND TRANSAC_NAME = 'DEDUCTION';")
                    End If

                    For Each row As DataGridViewRow In Deduction_grid.Rows

                        Dim deduct_id As String = IIf(IsDBNull(row.Cells(1).Tag), Nothing, row.Cells(1).Tag)

                        If row.Cells(1).Value <> 0 Then
                            Save_Recorded_Allow_Deduc(BiometricID_TXT.Text, paydate_, row.Cells(0).Value, row.Cells(0).Tag, "DEDUCTION", deduct_id)

                            '======================== SAVING TRANSACTION ========================
                            If deduc_list <> Nothing Then
                                deduc_list = $"{deduc_list}, {row.Cells(0).Value}({row.Cells(1).Value}), "
                            Else
                                deduc_list = $"{row.Cells(0).Value}({row.Cells(1).Value}), "
                            End If
                        End If

                    Next

                End If

                SaveLogs($"UPDATED PAYOUT {Name_TXT.Text}({BiometricID_TXT.Text}), Basic({TotalBasic_LBL.Text}), OT({TotalOT_LBL.Text}), Late/UT({TotalLateUnder_LBL.Text}), Gross Amount({GrossAmount_LBL.Text}), SSS({SSSComp_LBL.Text}), Pagibig({HDMF_LBL.Text}), Philhealth({Philhealth_LBL.Text}), Remittance({Remittance_LBL.Text}), Allowance({allow_list}), Deduction({deduc_list}), Net Pay({NetPay_LBL.Text}), Total Holiday({TotalHol_LBL.Text}), Total Night Rate({TotalNight_LBL.Text})", frmMainForm.UserName_LBL.Text)

                Cancel_BTN.PerformClick()

                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Information")
            End If
        End If
    End Sub

    Private Sub Pay_Refresh_BTN_Click(sender As Object, e As EventArgs) Handles Pay_Refresh_BTN.Click
        If ThisHasRow($"PAYROLL_PAYOUT WHERE PAYDATE = '{paydate_}'") Then
            Lists_Payout(Payout_list, paydate_)

            GetPayout_TOTALS(paydate_, P_GrossAmount_LBL, P_SSSComp_LBL, P_PagibigComp_LBL, P_PhilHComp_LBL,
                             P_Allowance_LBL, P_Deduction_LBL, P_NetPay_LBL)
        Else
            MsgBox($"NO RECORD FOR {paydate_} PAYROLL .", MsgBoxStyle.Exclamation, "INVALID")
        End If
    End Sub

    Private Sub Paydate_ComboB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Paydate_ComboB.SelectedIndexChanged
        paydate_ = Paydate_ComboB.SelectedItem

        Lists_Payout(Payout_list, paydate_)

        GetPayout_TOTALS(paydate_, P_GrossAmount_LBL, P_SSSComp_LBL, P_PagibigComp_LBL, P_PhilHComp_LBL,
                          P_Allowance_LBL, P_Deduction_LBL, P_NetPay_LBL)
    End Sub

    Private Sub Payout_list_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Payout_list.MouseDoubleClick
        If Payout_list.SelectedItems.Count > 0 Then
            Cancel_BTN.PerformClick()
            BiometricID_TXT.Clear()
            Name_TXT.Clear()

            BiometricID_TXT.Text = Payout_list.FocusedItem.SubItems(1).Tag
            TabControl1.SelectedIndex = 1
            Additional_Panel.Visible = False
        End If
    End Sub

    Private Sub Search_BTN_Click(sender As Object, e As EventArgs) Handles Search_BTN.Click
        subTotal_lbl.Text = Lists_Payout(Payout_list, paydate_, Search_TXT.Text)
    End Sub

    Private Sub Search_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Search_TXT.KeyPress
        If IsEnter(e) Then Search_BTN.PerformClick()
    End Sub

    Private Sub Company_RadioB_CheckedChanged(sender As Object, e As EventArgs) Handles Company_RadioB.CheckedChanged
        If Company_RadioB.Checked Then
            Company_group.Visible = True
        Else
            Company_group.Visible = False
        End If
    End Sub

    Private Sub Label37_Click(sender As Object, e As EventArgs) Handles Label37.Click
        Additional_Panel.Visible = False
    End Sub

    Private Sub CancelAdd_BTN_Click(sender As Object, e As EventArgs) Handles CancelAdd_BTN.Click
        cbCategoryAdd.Text = ""
        AmountAdd_TXT.Clear()
    End Sub

    Private Sub SaveAdd_BTN_Click(sender As Object, e As EventArgs) Handles SaveAdd_BTN.Click
        If cbCategoryAdd.Text <> String.Empty And AmountAdd_TXT.Text <> String.Empty Then

            If TransacAdd_lbl.Text = "Allowance" Then

                Dim result As DialogResult = MsgBox($"Additional Allowance for {Name_TXT.Text} will be added, proceed anyway?", MessageBoxButtons.YesNo)
                If result = DialogResult.Yes Then

                    Allowance_grid.Visible = True
                    Dim rowId As Integer = Allowance_grid.Rows.Add()
                    Dim row As DataGridViewRow = Allowance_grid.Rows(rowId)

                    Dim toProper As String
                    Dim info As TextInfo = CultureInfo.InvariantCulture.TextInfo

                    toProper = info.ToTitleCase(cbCategoryAdd.Text)
                    Dim amountt As Double = AmountAdd_TXT.Text

                    row.Cells(0).Value = toProper
                    row.Cells(0).Tag = amountt
                    row.Cells(1).Value = amountt.ToString("N")

                    CancelAdd_BTN.PerformClick()
                    Additional_Panel.Visible = False

                    AdjustHeightOfGridBasedOnRows(Allowance_grid)

                    Calculate_Allowance()
                End If

            ElseIf TransacAdd_lbl.Text = "Deduction" Then

                Dim result As DialogResult = MsgBox($"Additional Deduction for {Name_TXT.Text} will be added, proceed anyway?", MessageBoxButtons.YesNo)
                If result = DialogResult.Yes Then

                    Deduction_grid.Visible = True
                    Dim rowId As Integer = Deduction_grid.Rows.Add()
                    Dim row As DataGridViewRow = Deduction_grid.Rows(rowId)

                    Dim toProper As String
                    Dim info As TextInfo = CultureInfo.InvariantCulture.TextInfo

                    toProper = info.ToTitleCase(cbCategoryAdd.Text)
                    Dim amountt As Double = AmountAdd_TXT.Text

                    row.Cells(0).Value = toProper
                    row.Cells(0).Tag = amountt
                    row.Cells(1).Value = amountt.ToString("N")
                    row.Cells(3).Value = "OFF"

                    CancelAdd_BTN.PerformClick()
                    Additional_Panel.Visible = False

                    AdjustHeightOfGridBasedOnRows(Deduction_grid)

                    Calculate_Deduction()
                End If
            End If

            Calculate_NetPay()

        End If
    End Sub

    Private Sub AmountAdd_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles AmountAdd_TXT.KeyPress
        If e.KeyChar <> ChrW(Keys.Back) Then
            If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso Not e.KeyChar = "." Then
                e.Handled = True
            End If
        End If

        If IsEnter(e) Then SaveAdd_BTN.PerformClick()
    End Sub

    Private Sub Additional_BTN_Click(sender As Object, e As EventArgs) Handles Additional_BTN.Click
        Additional_Panel.Location = New Point(175, 200)
        Additional_Panel.Visible = True
        TransacAdd_lbl.Text = "Allowance"
        Additional_Panel.BackColor = Color.LightCoral
        PopulateComboBox(cbCategoryAdd, "CATEGORIES WHERE NAME = 'PAYOUT ADDITIONAL'", "CATEGORY")
    End Sub

    Private Sub Additional_Panel_MouseDown(sender As Object, e As MouseEventArgs) Handles Additional_Panel.MouseDown
        allowCoolMove = True
        myCoolPoint = New Point(e.X, e.Y)
        Cursor = Cursors.SizeAll
    End Sub

    Private Sub Additional_Panel_MouseMove(sender As Object, e As MouseEventArgs) Handles Additional_Panel.MouseMove
        If allowCoolMove = True Then
            Additional_Panel.Location = New Point(Additional_Panel.Location.X + e.X - myCoolPoint.X, Additional_Panel.Location.Y + e.Y - myCoolPoint.Y)
        End If
    End Sub

    Private Sub Deduction_BTN_Click(sender As Object, e As EventArgs) Handles Deduction_BTN.Click
        Additional_Panel.Location = New Point(175, 340)
        Additional_Panel.Visible = True
        TransacAdd_lbl.Text = "Deduction"
        Additional_Panel.BackColor = Color.Chocolate
        cbCategoryAdd.Items.Clear()
        PopulateComboBox(cbCategoryAdd, "CATEGORIES WHERE NAME = 'PAYOUT DEDUCTION'", "CATEGORY")
    End Sub

    Private Sub RateFixYes_RB_CheckedChanged(sender As Object, e As EventArgs) Handles RateFixYes_RB.CheckedChanged
        If RateFixYes_RB.Checked = False Then
            RateFixNo_RB.Checked = True
        End If
    End Sub

    Private Sub TrainingDays_LBL_TextChanged(sender As Object, e As EventArgs) Handles TrainingDays_LBL.TextChanged
        If TrainingDays_LBL.Text > 0 Then
            Training_GB.Visible = True
        End If
    End Sub

    Private Sub ConfirmDeduc_btn_Click(sender As Object, e As EventArgs) Handles ConfirmDeduc_btn.Click

        Dim mysqll As String = $"select distinct(BIOMETRIC_ID) from payroll_payout;"
        Using ds As DataSet = LoadSQL(mysqll, "payroll_payout")
            If ds.Tables(0).Rows.Count > 0 Then
                progressBarStart(ds.Tables(0).Rows.Count)
                For Each dr In ds.Tables(0).Rows
                    With dr
                        CheckDeduction_Loans_IfZeroBalance(.item("BIOMETRIC_ID"))
                    End With
                    frmMainForm.AppProgressBar.Value += 1
                Next
                progressBarEnd()
                MsgBox("Successfully updated!", MsgBoxStyle.Information)
            End If
        End Using

    End Sub

    Private Sub Additional_Panel_MouseUp(sender As Object, e As MouseEventArgs) Handles Additional_Panel.MouseUp
        allowCoolMove = False
        Cursor = Cursors.Default
    End Sub

    Private Sub Calculate_Allowance()
        Dim totals As Double = 0
        If Allowance_grid.Rows.Count > 0 Then
            For Each row As DataGridViewRow In Allowance_grid.Rows
                totals = totals + row.Cells(0).Tag
            Next
        End If

        Allowances_LBL.Text = FormatNumber(totals)
        Allowances_LBL.Tag = totals
    End Sub

    Private Sub Late_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Late_TXT.KeyPress
        If e.KeyChar <> ChrW(Keys.Back) Then
            If Char.IsNumber(e.KeyChar) Then
            Else
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub Late_TXT_TextChanged(sender As Object, e As EventArgs) Handles Late_TXT.TextChanged
        If Late_TXT.Text = Nothing Then
            TotalLateUnder_LBL.Text = 0
        Else
            Calculate_Late(Late_TXT.Text)
            Calculate_NetPay()
        End If
    End Sub

    Private Sub RemitOff_BTN_Click(sender As Object, e As EventArgs) Handles RemitOff_BTN.Click
        If RemitOff_BTN.Text = "OFF" Then
            SSSComp_LBL.Text = 0
            HDMF_LBL.Text = 0
            Philhealth_LBL.Text = 0
            Remittance_LBL.Text = 0
            RemitOff_BTN.Text = "ON"
        Else
            SSSComp_LBL.Text = SSSComp_LBL.Tag
            HDMF_LBL.Text = HDMF_LBL.Tag
            Philhealth_LBL.Text = Philhealth_LBL.Tag
            Remittance_LBL.Text = Remittance_LBL.Tag
            RemitOff_BTN.Text = "OFF"
        End If

        Calculate_NetPay()

        'HOLD SALARY
        Dim Hold_Salary As Boolean = GetDataBoolean("HOLD_SALARY", $"TBL_EMPLOYEE WHERE BIOMETRICID = {BiometricID_TXT.Text}")
        If Hold_Salary And RemitOff_BTN.Text = "ON" Then

            If CDec(NetPay_LBL.Text) > 0 Then

                Deduction_grid.Visible = True
                Dim rowId As Integer = Deduction_grid.Rows.Add()
                Dim row As DataGridViewRow = Deduction_grid.Rows(rowId)
                Dim amountt As Double = NetPay_LBL.Text

                row.Cells(0).Value = "HOLD SALARY"
                row.Cells(0).Tag = amountt
                row.Cells(1).Value = amountt.ToString("N")
                row.Cells(3).Value = "OFF"

                CancelAdd_BTN.PerformClick()
                Additional_Panel.Visible = False

                AdjustHeightOfGridBasedOnRows(Deduction_grid)
                Calculate_Deduction()
            End If

        ElseIf Hold_Salary And RemitOff_BTN.Text = "OFF" Then
            ' Remove any HOLD SALARY row if it exists
            If CDbl(Remittance_LBL.Text) > 0 Then

                For Each row As DataGridViewRow In Deduction_grid.Rows
                    If Not row.IsNewRow AndAlso row.Cells(0).Value?.ToString() = "HOLD SALARY" Then
                        Deduction_grid.Rows.Remove(row)
                        Exit For ' Remove only one instance (the first match)
                    End If
                Next

                AdjustHeightOfGridBasedOnRows(Deduction_grid)
                Calculate_Deduction()
            End If
        End If

        Calculate_NetPay()
    End Sub

    Private Sub Calculate_Late(latee As Integer)
        Dim ratee As Decimal = GetData_Decimal("RATE_DAILY", $"TBL_EMPLOYEE WHERE BIOMETRICID = '{BiometricID_TXT.Text}'")
        Dim late As Decimal = ((ratee / 8) / 60) * latee

        TotalLateUnder_LBL.Text = FormatNumber(late)
        TotalLateUnder_LBL.Tag = late

        Dim gross As Decimal = CDec(TotalBasic_LBL.Tag) + CDec(TotalOT_LBL.Tag) + CDec(TotalHol_LBL.Tag) + CDec(TotalNight_LBL.Tag) - CDec(TotalLateUnder_LBL.Tag)

        GrossAmount_LBL.Text = FormatNumber(gross)
        GrossAmount_LBL.Tag = gross
    End Sub

    Private Sub Calculate_Deduction()

        Dim totals As Double = 0
        If Deduction_grid.Rows.Count > 0 Then
            For Each row As DataGridViewRow In Deduction_grid.Rows
                If row.Cells(3).Value = "OFF" Then
                    totals = FormatNumber(totals + row.Cells(0).Tag)
                End If
            Next
        End If

        Deduction_LBL.Text = FormatNumber(totals)
        Deduction_LBL.Tag = totals

    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click

        Dim datee As DateTime

        If Payslip_paydate_Combo.SelectedIndex >= 0 Then
            datee = Payslip_paydate_Combo.Text
        Else
            MsgBox("Please Select Payroll.", MsgBoxStyle.Exclamation, "INVALID")
            Exit Sub
        End If

        If All_RadioB.Checked = True OrElse rbAllActive.Checked = True Then

            Print_Payslip_All()

        ElseIf Company_RadioB.Checked = True Then

            If Company_ComboB.SelectedIndex >= 0 Then
                Print_Payslip_By("COMPANY", Company_ComboB.Text)
            Else
                MsgBox("Please Select Company.", MsgBoxStyle.Exclamation, "INVALID")
            End If

        ElseIf Branch_RadioB.Checked = True Then

            If Branch_ComboB.SelectedIndex >= 0 Then
                Print_Payslip_By("BRANCHCODE", Branch_ComboB.Text)
            Else
                MsgBox("Please Select Branch.", MsgBoxStyle.Exclamation, "INVALID")
            End If

        Else

            If Employee_TXT.Tag <> Nothing Then
                Print_Payslip_By("BIOMETRICID", Employee_TXT.Tag)
            Else
                MsgBox("Please Select Employee.", MsgBoxStyle.Exclamation, "INVALID")
            End If

        End If
    End Sub

    Private Sub Calculate_NetPay()

        Dim CONTRIB As Decimal = CDbl(SSSComp_LBL.Text) + CDbl(HDMF_LBL.Text) + CDbl(Philhealth_LBL.Text)

        '============ SWITCH TO EVERY PAYROLL DISTRIBUTION ==========
        'Dim positive, negative As Decimal
        'If IsLastDay(paydate_) Then
        '    positive = FormatNumber(CDec(GrossAmount_LBL.Tag) + CDec(Allowances_LBL.Tag))
        '    negative = FormatNumber(CONTRIB + CDec(Deduction_LBL.Tag))
        'Else
        '    'Remittance_LBL.Text = 0.00
        '    positive = FormatNumber(CDec(GrossAmount_LBL.Tag) + CDec(Allowances_LBL.Tag))
        '    negative = FormatNumber(CDec(Deduction_LBL.Tag))
        'End If 

        Dim positive, negative As Decimal
        positive = FormatNumber(CDec(GrossAmount_LBL.Tag) + CDec(Allowances_LBL.Tag))
        negative = FormatNumber(CONTRIB + CDec(Deduction_LBL.Tag))

        NetPay_LBL.Text = FormatNumber(positive - negative)
        NetPay_LBL.Tag = FormatNumber(positive - negative)

    End Sub

    '====================================================== PAYSLIP ==========================================================
    Dim branchID As String

    Private Sub Preview_BTN_Click(sender As Object, e As EventArgs) Handles Preview_BTN.Click
        If Employee_TXT.Text <> Nothing Then
            LoadPayslip(Employee_TXT.Tag, Payslip_paydate_Combo.Text)
        Else
            MsgBox("Please Select Employee.", MsgBoxStyle.Exclamation, "INVALID")
        End If
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

    Private Sub Close_LBL_Click(sender As Object, e As EventArgs) Handles Close_LBL.Click
        Close()
    End Sub

    Private Sub Rate_EmpSelect_BTN_Click(sender As Object, e As EventArgs) Handles EmpSelect_BTN.Click
        If Payslip_paydate_Combo.SelectedIndex < 0 Then
            MsgBox("Please Select payroll date!", MsgBoxStyle.Exclamation, "Error")
        Else

            Try
                Dim instForm As Form = Application.OpenForms.OfType(Of Form)().Where(Function(frm) frm.Name = "frmNewEmployee").SingleOrDefault()
                If instForm Is Nothing Then
                    Dim frm As frmNewEmployee
                    frm = DirectCast(CreateObjectInstance("frmNewEmployee"), Form)
                    frm.MdiParent = frmMainForm
                    frmMainForm.pNavigate.Controls.Add(frm)
                    frmMainForm.pNavigate.Tag = frm
                    frm.txtSearch.Tag = "Payslip-Employee"
                    frm.btnSearch.Tag = Payslip_paydate_Combo.Text
                    frm.Dock = DockStyle.Fill
                    frm.BringToFront()
                    frm.Show()
                Else
                    instForm.BringToFront()
                End If

            Catch ex As Exception

            End Try

        End If
    End Sub

    Private Sub Send_BTN_Click(sender As Object, e As EventArgs) Handles Send_BTN.Click

        Dim result As DialogResult = MessageBox.Show($"Are you sure?", "Warning", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then

            Dim datee As DateTime
            Dim emailAddress As String = Email_TXT.Text.Trim

            If Payslip_paydate_Combo.SelectedIndex >= 0 Then
                datee = Payslip_paydate_Combo.Text
            Else
                MsgBox("Please Select Payroll.", MsgBoxStyle.Exclamation, "INVALID")
                Exit Sub
            End If

            If All_RadioB.Checked = True Then

                Payslip_All()

            ElseIf rbAllActive.Checked = True Then

                Payslip_All(True)

            ElseIf Company_RadioB.Checked = True Then

                If Company_ComboB.SelectedIndex >= 0 Then
                    Payslip_By("COMPANY", Company_ComboB.Text)
                Else
                    MsgBox("Please Select Branch.", MsgBoxStyle.Exclamation, "INVALID")
                End If

            ElseIf Branch_RadioB.Checked = True Then

                If Branch_ComboB.SelectedIndex >= 0 Then
                    Payslip_By("BRANCHCODE", Branch_ComboB.Text)

                    SaveLogs($"PAYSLIP EMAILED PER BRANCH - {Branch_ComboB.Text}, Payroll({datee.ToString("MMM dd, yyyy")})", frmMainForm.UserName_LBL.Text)
                Else
                    MsgBox("Please Select Branch.", MsgBoxStyle.Exclamation, "INVALID")
                End If

            Else

                LoadPayslip(Employee_TXT.Tag, Payslip_paydate_Combo.Text)

                CheckDeduction_Loans_IfZeroBalance(Employee_TXT.Tag)

                '================================ CHECK IF VALID EMAIL ADDRESS ============================
                Dim FoundMatch As Boolean = Regex.IsMatch(emailAddress, "\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase)

                If Not FoundMatch Then
                    MsgBox(Employee_TXT.Text & " has an invalid email address.", MsgBoxStyle.Exclamation, "INVALID")
                    Exit Sub
                Else

                    '================================ SEND TO EMAIL ADDRESS IF VALID ============================
                    Send_Email(ReportViewer_payslip.LocalReport.Render("PDF"), emailAddress, Employee_TXT.Text, Payslip_paydate_Combo.Text, BodyText_RichB.Text, datee.ToString("MMMM dd, yyyy") & " PAYROLL", Employee_TXT.Tag, datee)

                    MsgBox("Email sent to " & Employee_TXT.Text, MsgBoxStyle.Information, "Information")
                End If

                SaveLogs($"PAYSLIP EMAILED TO {Employee_TXT.Text}({Employee_TXT.Tag}), Payroll({datee.ToString("MMM dd, yyyy")})", frmMainForm.UserName_LBL.Text)

            End If
        End If
    End Sub

    Private Sub Print_Payslip_All(Optional allActive As Boolean = False)
        Dim payDate As DateTime = DateTime.Parse(Payslip_paydate_Combo.Text)

        Dim query As String = $"
             SELECT A.BIOMETRIC_ID, 
                    LASTNAME || ', ' || FIRSTNAME ||
                    CASE WHEN MIDDLENAME IS NOT NULL AND MIDDLENAME <> '' THEN ' ' || LEFT(MIDDLENAME, 1) || '.' ELSE '' END ||
                    CASE WHEN SUFFIX IS NOT NULL AND SUFFIX <> '' THEN ' ' || SUFFIX ELSE '' END AS FULLNAME
             FROM payroll_payout A
             INNER JOIN TBL_EMPLOYEE B ON B.BIOMETRICID = A.BIOMETRIC_ID 
             WHERE (paydate = '{payDate:yyyy-MM-dd}' AND EMAIL_SENT = 1)
             AND NOT EXISTS (
                     SELECT 1
                     FROM USER_ACCESSIBILITY UA
                     WHERE UA.COMPANY = B.COMPANY
                     AND UA.USERID = {userID})
             ORDER BY A.BIOMETRIC_ID;"

        Using ds As DataSet = LoadSQL(query, "payroll_payout")
            If ds.Tables(0).Rows.Count = 0 Then
                MsgBox("No payslips have been emailed.", MsgBoxStyle.Information, "Information")
                Exit Sub
            End If

            progressBarStart(ds.Tables(0).Rows.Count)

            Using fbd As New FolderBrowserDialog()
                fbd.Description = "Select folder to save individual payslips"
                If fbd.ShowDialog() <> DialogResult.OK Then Exit Sub

                Dim folderPath As String = Path.Combine(fbd.SelectedPath, $"Payslips_{payDate:MMddyyyy}")
                If Not Directory.Exists(folderPath) Then
                    Directory.CreateDirectory(folderPath)
                End If

                For Each dr As DataRow In ds.Tables(0).Rows
                    Dim bioId As String = dr("BIOMETRIC_ID").ToString()
                    Dim fullName As String = dr("FULLNAME").ToString()

                    LoadPayslip(bioId, Payslip_paydate_Combo.Text)
                    Dim pdfBytes As Byte() = ReportViewer_payslip.LocalReport.Render("PDF")

                    Dim safeName As String = String.Concat(fullName.Split(Path.GetInvalidFileNameChars()))
                    Dim filePath As String = Path.Combine(folderPath, $"{safeName}.pdf")

                    File.WriteAllBytes(filePath, pdfBytes)

                    frmMainForm.AppProgressBar.Value += 1
                Next
            End Using

            progressBarEnd()
            MessageBox.Show("All payslips saved successfully!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Using
    End Sub

    Private Sub Print_Payslip_By(tbl_column As String, column_value As String)
        Dim payDate As DateTime = DateTime.Parse(Payslip_paydate_Combo.Text)
        Dim query As String = $"Select A.*, B.*, B.id as emp_id,
                                    LASTNAME || ', ' || FIRSTNAME || 
                                    CASE
                                        WHEN MIDDLENAME IS NOT NULL AND MIDDLENAME <> '' THEN ' ' || LEFT(MIDDLENAME, 1) || '.' 
                                        ELSE ''
                                    END || 
                                    CASE 
                                        WHEN SUFFIX IS NOT NULL AND SUFFIX <> '' THEN ' ' || SUFFIX
                                        ELSE ''
                                    END AS FULLNAME 
                                    FROM PAYROLL_PAYOUT A 
                                    INNER JOIN TBL_EMPLOYEE B on B.BIOMETRICID = A.BIOMETRIC_ID   
                                    WHERE (PAYDATE = '{payDate:yyyy-MM-dd}' AND EMAIL_SENT = 1 AND B.{tbl_column} = '{column_value}')                           
                                    AND NOT EXISTS (
                                            SELECT 1
                                            FROM USER_ACCESSIBILITY UA
                                            WHERE UA.COMPANY = B.COMPANY
                                            AND UA.USERID = {userID});"

        Using ds As DataSet = LoadSQL(query, "payroll_payout")
            If ds.Tables(0).Rows.Count = 0 Then
                MsgBox("No payslips have been emailed.", MsgBoxStyle.OkOnly, "Information")
                Exit Sub
            End If

            progressBarStart(ds.Tables(0).Rows.Count)

            Using fbd As New FolderBrowserDialog()
                fbd.Description = "Select folder to save individual payslips"
                If fbd.ShowDialog() <> DialogResult.OK Then Exit Sub

                Dim folderPath As String = Path.Combine(fbd.SelectedPath, $"Payslips_{payDate:MMddyyyy}")
                If Not Directory.Exists(folderPath) Then
                    Directory.CreateDirectory(folderPath)
                End If

                For Each dr As DataRow In ds.Tables(0).Rows
                    Dim bioId As String = dr("BIOMETRIC_ID").ToString()
                    Dim fullName As String = dr("FULLNAME").ToString()

                    LoadPayslip(bioId, Payslip_paydate_Combo.Text)
                    Dim pdfBytes As Byte() = ReportViewer_payslip.LocalReport.Render("PDF")

                    Dim safeName As String = String.Concat(fullName.Split(Path.GetInvalidFileNameChars()))
                    Dim filePath As String = Path.Combine(folderPath, $"{safeName}.pdf")

                    File.WriteAllBytes(filePath, pdfBytes)

                    frmMainForm.AppProgressBar.Value += 1
                Next
            End Using

            progressBarEnd()
            MessageBox.Show("All payslips saved successfully!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Using
    End Sub

    Private Sub Payslip_All(Optional allActive As Boolean = False)
        Dim activeString As String = If(allActive, "AND EMP_STATUS <> 'INACTIVE'", "")
        Dim payDate As DateTime = DateTime.Parse(Payslip_paydate_Combo.Text)

        Dim query As String = $"
        SELECT A.BIOMETRIC_ID, 
               LASTNAME || ', ' || FIRSTNAME ||
               CASE WHEN MIDDLENAME IS NOT NULL AND MIDDLENAME <> '' THEN ' ' || LEFT(MIDDLENAME, 1) || '.' ELSE '' END ||
               CASE WHEN SUFFIX IS NOT NULL AND SUFFIX <> '' THEN ' ' || SUFFIX ELSE '' END AS FULLNAME
        FROM payroll_payout A
        INNER JOIN TBL_EMPLOYEE B ON B.BIOMETRICID = A.BIOMETRIC_ID
        {activeString}
        WHERE (paydate = '{payDate:yyyy-MM-dd}' AND EMAIL_SENT IS NULL)
        AND NOT EXISTS (
                SELECT 1
                FROM USER_ACCESSIBILITY UA
                WHERE UA.COMPANY = B.COMPANY
                AND UA.USERID = {userID})
        ORDER BY A.BIOMETRIC_ID;"

        Using ds As DataSet = LoadSQL(query, "payroll_payout")
            If ds.Tables(0).Rows.Count = 0 Then
                MsgBox("All emails have been sent already!", MsgBoxStyle.Information, "Information")
                Exit Sub
            End If

            progressBarStart(ds.Tables(0).Rows.Count)

            Dim counter As Integer = 0

            For Each dr As DataRow In ds.Tables(0).Rows
                Dim bioId As String = dr("BIOMETRIC_ID").ToString()
                Dim fullName As String = dr("FULLNAME").ToString()

                Dim recipient As String = GetEmail_recipient(bioId).Trim
                If Not Regex.IsMatch(recipient, "\A[\w\.-]+@[\w\.-]+\.\w{2,}\Z", RegexOptions.IgnoreCase) Then
                    MsgBox(fullName & " has an invalid email address.", MsgBoxStyle.Exclamation, "INVALID")
                    Continue For
                End If

                CheckDeduction_Loans_IfZeroBalance(bioId)

                ' ==== RENDER PAYSHEET REPORT INTO BYTE() FRESH PER PERSON ====
                LoadPayslip(bioId, Payslip_paydate_Combo.Text)

                Dim pdfBytes As Byte() = ReportViewer_payslip.LocalReport.Render("PDF")

                ' ==== EMAIL SEND ====
                Send_Email(
                    byteViewer:=pdfBytes,
                    recipient_Email:=recipient,
                    recipient_Name:=fullName,
                    paydate:=payDate.ToString("MMMM dd, yyyy"),
                    BodyText:=BodyText_RichB.Text,
                    subjectt:=$"{payDate:MMMM dd, yyyy} PAYROLL",
                    bio_no:=bioId,
                    payrollDate:=Payslip_paydate_Combo.Text
                )

                frmMainForm.AppProgressBar.Value += 1

                SaveLogs($"PAYSLIP EMAILED TO {fullName}({bioId}), Payroll({payDate:MMM dd, yyyy})", frmMainForm.UserName_LBL.Text)

            Next

            progressBarEnd()
            MsgBox("Email successfully sent!", MsgBoxStyle.Information, "Information")
        End Using
    End Sub

    Private Sub Payslip_By(tbl_column As String, column_value As String)

        Dim recipient As String
        Dim datee As DateTime = DateTime.Parse(Payslip_paydate_Combo.Text)

        Dim mysqll As String = $"Select A.*, B.*, B.id as emp_id,
                                    LASTNAME || ', ' || FIRSTNAME || 
                                    CASE
                                        WHEN MIDDLENAME IS NOT NULL AND MIDDLENAME <> '' THEN ' ' || LEFT(MIDDLENAME, 1) || '.' 
                                        ELSE ''
                                    END || 
                                    CASE 
                                        WHEN SUFFIX IS NOT NULL AND SUFFIX <> '' THEN ' ' || SUFFIX
                                        ELSE ''
                                    END AS FULLNAME 
                                    FROM PAYROLL_PAYOUT A 
                                    INNER JOIN TBL_EMPLOYEE B on B.BIOMETRICID = A.BIOMETRIC_ID   
                                    WHERE (PAYDATE = '{datee:yyyy-MM-dd}' AND EMAIL_SENT IS NULL)
                                    AND (PAYDATE = '{Payslip_paydate_Combo.Text}' and B.{tbl_column} = '{column_value}')                                 
                                    AND NOT EXISTS (
                                            SELECT 1
                                            FROM USER_ACCESSIBILITY UA
                                            WHERE UA.COMPANY = B.COMPANY
                                            AND UA.USERID = {userID});"

        Using ds As DataSet = LoadSQL(mysqll, "payroll_payout")
            If ds.Tables(0).Rows.Count > 0 Then
                progressBarStart(ds.Tables(0).Rows.Count)
                For Each dr In ds.Tables(0).Rows
                    With dr

                        Dim namee = .Item("FULLNAME")

                        LoadPayslip(.item("BIOMETRIC_ID"), Payslip_paydate_Combo.Text)

                        recipient = GetEmail_recipient(.item("BIOMETRIC_ID")).Trim

                        CheckDeduction_Loans_IfZeroBalance(.item("BIOMETRIC_ID"))

                        Dim FoundMatch As Boolean = Regex.IsMatch(recipient, "\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase)

                        If Not FoundMatch Then  '============= CHECK IF VALID EMAIL ADDRESS ============================
                            MsgBox(namee & " has an invalid email address.", MsgBoxStyle.Exclamation, "INVALID")
                            Continue For

                        Else                    '============== SEND TO EMAIL ADDRESS IF VALID ============================

                            Send_Email(ReportViewer_payslip.LocalReport.Render("PDF"), recipient, namee, Payslip_paydate_Combo.Text, BodyText_RichB.Text, datee.ToString("MMMM dd, yyyy") & " PAYROLL", .item("BIOMETRIC_ID"), datee)

                        End If

                        frmMainForm.AppProgressBar.Value += 1

                        SaveLogs($"PAYSLIP EMAILED TO {namee}({ .item("BIOMETRIC_ID")}), Payroll({datee.ToString("MMM dd, yyyy")})", frmMainForm.UserName_LBL.Text)
                    End With
                Next

                MsgBox("Email successfully sent ", MsgBoxStyle.Information, "Information")

                progressBarEnd()
            End If
        End Using
    End Sub

    Public Sub LoadPayslip(biometricID As String, paydatee As String)

        ReportViewer_payslip.LocalReport.DataSources.Clear()

        Dim sched As String
        Dim emp_id As String = ""
        Dim rate As Double = 0
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

            Dim sql As String = $"select RATE_DAILY, SSSNO, PHILHEALTHNO, TINNO, PAGIBIG, 
                                    LASTNAME || ', ' || FIRSTNAME || 
                                    CASE
                                        WHEN MIDDLENAME IS NOT NULL AND MIDDLENAME <> '' THEN ' ' || LEFT(MIDDLENAME, 1) || '.' 
                                        ELSE ''
                                    END || 
                                    CASE 
                                        WHEN SUFFIX IS NOT NULL AND SUFFIX <> '' THEN ' ' || SUFFIX
                                        ELSE ''
                                    END AS FULLNAME 
                                    from TBL_EMPLOYEE A where BIOMETRICID = '{biometricID}';"

            TestingScript_String(sql)
            Using ds As DataSet = LoadSQL(sql, "TBL_EMPLOYEE")
                If ds.Tables(0).Rows.Count > 0 Then
                    Dim data As DataRow = ds.Tables(0).Rows(0)
                    With data

                        rate = .Item("RATE_DAILY")
                        Dim namee As String = .Item("FULLNAME")
                        dt_employee.Rows.Add(namee, .Item("SSSNO"), .Item("PHILHEALTHNO"), .Item("TINNO"), .Item("PAGIBIG"))

                    End With
                End If
            End Using

            Dim rds_employee As New ReportDataSource("DataSet1", dt_employee)
            ReportViewer_payslip.LocalReport.DataSources.Add(rds_employee)

            '============================================ EMPLOYEE ATTENDANCE AND PAYOUT =======================================
            Dim dt_attendance As New DataTable()
            With dt_attendance
                .Columns.Add("PRESENT_DAYS")
                .Columns.Add("OVERTIME")
                .Columns.Add("REGHOLIDAY")
                .Columns.Add("SPECHOLIDAY")
                .Columns.Add("TOTAL_LATE_UT")
                .Columns.Add("TOTAL_BASIC")
                .Columns.Add("TOTAL_OVERTIME")
                .Columns.Add("LATE_UNDERTIME")
                .Columns.Add("GROSS_AMOUNT")
                .Columns.Add("SSS_COMP")
                .Columns.Add("PAGIBIG_COMP")
                .Columns.Add("PHILHEALTH_COMP")
                .Columns.Add("NET_PAY")
                .Columns.Add("TOTAL_DEDUCTION")
                .Columns.Add("present_hours")
                .Columns.Add("NIGHT_RATE")
                .Columns.Add("TOTAL_NIGHT_RATE")
            End With

            Dim PRESENT_DAYS As String = ""
            Dim OVERTIME As String = ""
            Dim REGHOLIDAY As Integer = 0
            Dim SPECHOLIDAY As Integer = 0
            Dim TOTAL_REGHOLIDAY As Decimal = 0
            Dim TOTAL_SPECHOLIDAY As Decimal = 0
            Dim LATE_UNDERTIME As String = ""
            Dim present_hours As Double = 0
            Dim total_Allowance As Double = 0
            Dim SPECHOLIDAY_HRS As Double = 0
            Dim NIGHT_RATE As Double = 0
            Dim TOTAL_NIGHT_RATE As Double = 0

            Dim _mysql As String = $"select PRESENT_DAYS, REGHOLIDAY, SPECHOLIDAY, OVERTIME, LATE, UNDERTIME, SPECHOLIDAY_HRS, NIGHT_RATE
                                    from payroll_attendance where BIOMETRICID = '{biometricID}' and paydate = '{paydatee}';"

            TestingScript_String(_mysql)
            Using ds1 As DataSet = LoadSQL(_mysql, "payroll_attendance")
                If ds1.Tables(0).Rows.Count > 0 Then
                    Dim data As DataRow = ds1.Tables(0).Rows(0)
                    With data

                        present_hours = (.Item("PRESENT_DAYS") / 0.5) * 4 'CALCULATE PRESENT DAYS TO HOURS

                        PRESENT_DAYS = .Item("PRESENT_DAYS")
                        REGHOLIDAY = .Item("REGHOLIDAY")
                        SPECHOLIDAY = .Item("SPECHOLIDAY")
                        OVERTIME = .Item("OVERTIME")
                        LATE_UNDERTIME = CInt(.Item("LATE")) + CInt(.Item("UNDERTIME"))
                        SPECHOLIDAY_HRS = IIf(IsDBNull(.Item("SPECHOLIDAY_HRS")), 0, .Item("SPECHOLIDAY_HRS"))
                        NIGHT_RATE = IIf(IsDBNull(.Item("NIGHT_RATE")), 0, .Item("NIGHT_RATE"))

                        If SPECHOLIDAY_HRS <> 0 Then SPECHOLIDAY = SPECHOLIDAY_HRS / 8

                    End With
                End If
            End Using

            Dim mysqll As String = $"select TOTAL_REGHOLIDAY, TOTAL_SPECHOLIDAY, TOTAL_ALLOWANCE, TOTAL_NIGHT_RATE, SSS_COMP, PAGIBIG_COMP, PHILHEALTH_COMP,
                                            TOTAL_LATE_UT, TOTAL_BASIC, TOTAL_OVERTIME, GROSS_AMOUNT, NET_PAY
                                    from payroll_payout where BIOMETRIC_ID = '{biometricID}' and paydate = '{paydatee}';"

            TestingScript_String(mysqll)
            Using ds2 As DataSet = LoadSQL(mysqll, "payroll_payout")
                If ds2.Tables(0).Rows.Count > 0 Then
                    Dim data As DataRow = ds2.Tables(0).Rows(0)
                    With data

                        TOTAL_REGHOLIDAY = .Item("TOTAL_REGHOLIDAY")
                        TOTAL_SPECHOLIDAY = .Item("TOTAL_SPECHOLIDAY")
                        total_Allowance = .Item("TOTAL_ALLOWANCE")
                        TOTAL_NIGHT_RATE = .Item("TOTAL_NIGHT_RATE")

                        Dim TOTAL_COMP As Double = .Item("SSS_COMP") + .Item("PAGIBIG_COMP") + .Item("PHILHEALTH_COMP")

                        dt_attendance.Rows.Add(PRESENT_DAYS, OVERTIME, REGHOLIDAY, SPECHOLIDAY, CDbl(.Item("TOTAL_LATE_UT")).ToString("N"),
                                        CDbl(.Item("TOTAL_BASIC")).ToString("N"), CDbl(.Item("TOTAL_OVERTIME")).ToString("N"), LATE_UNDERTIME,
                                        CDbl(.Item("GROSS_AMOUNT")).ToString("N"), CDbl(.Item("SSS_COMP")).ToString("N"), CDbl(.Item("PAGIBIG_COMP")).ToString("N"),
                                        CDbl(.Item("PHILHEALTH_COMP")).ToString("N"), CDbl(.Item("NET_PAY")).ToString("N"), TOTAL_COMP.ToString("N"),
                                        present_hours, NIGHT_RATE, TOTAL_NIGHT_RATE.ToString("N"))

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
            End With

            If isExist_String("RECORDED_ALLOW_DEDUC", $"WHERE BIO_NO = '{biometricID}' AND PAYDATE = '{paydatee}' AND TRANSAC_NAME = 'ALLOWANCE'") Then

                Dim mysql_1 As String = $"select AMOUNT, CATEGORY from RECORDED_ALLOW_DEDUC WHERE BIO_NO = '{biometricID}' AND PAYDATE = '{paydatee}' AND TRANSAC_NAME = 'ALLOWANCE'"

                TestingScript_String(mysql_1)
                Using ds3 As DataSet = LoadSQL(mysql_1, "RECORDED_ALLOW_DEDUC")
                    If ds3.Tables(0).Rows.Count > 0 Then
                        For Each dr In ds3.Tables(0).Rows
                            With dr
                                Dim amountt As Double = .item("AMOUNT")

                                dt_allowance.Rows.Add(.item("CATEGORY"), amountt.ToString(”N”))
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
                .Columns.Add("BALANCE")
            End With

            Dim total_deduction As Decimal = 0
            Dim mysql_ As String

            '================================================ DEDUCTIONS ================================================ 
            If isExist_String("RECORDED_ALLOW_DEDUC", $"WHERE BIO_NO = '{biometricID}' AND PAYDATE = '{paydatee}' and TRANSAC_NAME = 'DEDUCTION'") Then  '=======m MDIFIED DEDUCTION (ON/OFF) 

                mysql_ = $"select CATEGORY, AMOUNT, R_DEDUC_ID FROM RECORDED_ALLOW_DEDUC where BIO_NO = '{biometricID}' and PAYDATE = '{paydatee}' and TRANSAC_NAME = 'DEDUCTION'"

                TestingScript_String(mysql_)
                Using ds4 As DataSet = LoadSQL(mysql_, "RECORDED_ALLOW_DEDUC")
                    If ds4.Tables(0).Rows.Count > 0 Then
                        For Each dr In ds4.Tables(0).Rows
                            With dr

                                Dim category As String = .item("CATEGORY")
                                Dim amountt As Decimal = .item("AMOUNT")
                                Dim balance As Decimal = 0
                                Dim partial_payment As Decimal = 0

                                '=================== IF HAS PARTIAL PAYMENT SA DEDUCTION ==============
                                If IsDBNull(.item("R_DEDUC_ID")) Then
                                    Console.WriteLine("NO PARTIAL PAYMENT")
                                Else
                                    partial_payment = GetTotal("AMOUNT", $" PARTIAL_PAYMENT WHERE DEDUCT_ID = '{ .item("R_DEDUC_ID")}'")
                                End If

                                Dim R_DEDUCT_ID As Integer = IIf(IsDBNull(.item("R_DEDUC_ID")), 0, .item("R_DEDUC_ID"))

                                If category.Contains("MP2") Or category.Contains("MAXICARE") Then
                                ElseIf .item("CATEGORY") = "SSS LOAN" Then
                                    balance = GetBalance_Deduction(biometricID, .item("CATEGORY"), R_DEDUCT_ID, paydatee) - partial_payment
                                ElseIf .item("CATEGORY") = "PAG-IBIG LOAN" Then
                                    balance = GetBalance_Deduction(biometricID, .item("CATEGORY"), R_DEDUCT_ID, paydatee) - partial_payment
                                Else
                                    If R_DEDUCT_ID = 0 And category <> "SBU" Then
                                        balance = 0
                                    ElseIf category = "Charges" Then
                                        'balance = GetBalance_Deduction(biometricID, .item("CATEGORY"), R_DEDUCT_ID)
                                    Else
                                        balance = GetBalance_Deduction(biometricID, .item("CATEGORY"), R_DEDUCT_ID, paydatee) - partial_payment
                                    End If
                                End If

                                dt_deduction.Rows.Add(category.TrimEnd, amountt.ToString(”N”), balance.ToString(”N”))

                                total_deduction += amountt

                            End With
                        Next
                    End If
                End Using
            End If

            Dim rds_deduction As New Microsoft.Reporting.WinForms.ReportDataSource("DataSet4", dt_deduction)
            ReportViewer_payslip.LocalReport.DataSources.Add(rds_deduction)

            '============================================ PAYDATE, REGHOLIDAY AND SPECHOLIDAY ================================ 
            Dim reg_hrs As Decimal = REGHOLIDAY * 8
            Dim spec_hrs As Decimal = SPECHOLIDAY * 8

            date_pay = date_pay.ToString("MMMM dd, yyyy")

            Dim paramList As New List(Of Microsoft.Reporting.WinForms.ReportParameter) From {
            New Microsoft.Reporting.WinForms.ReportParameter("paramDeducTotal", total_deduction.ToString(”N”)),
            New Microsoft.Reporting.WinForms.ReportParameter("paramAllowTotal", total_Allowance.ToString(”N”)),
            New Microsoft.Reporting.WinForms.ReportParameter("paramRegRate", TOTAL_REGHOLIDAY.ToString(”N”)),
            New Microsoft.Reporting.WinForms.ReportParameter("paramSpecRate", TOTAL_SPECHOLIDAY.ToString(”N”)),
            New Microsoft.Reporting.WinForms.ReportParameter("paramRegHours", reg_hrs),
            New Microsoft.Reporting.WinForms.ReportParameter("paramSpecHours", SPECHOLIDAY_HRS),
            New Microsoft.Reporting.WinForms.ReportParameter("paramDate", date_pay)
            }

            ReportViewer_payslip.LocalReport.SetParameters(paramList)
            ReportViewer_payslip.RefreshReport()

        Catch ex As Exception
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub Load_Payout(emp As Employee, paydatee As String, tabName As String)
        With emp
            If tabName = "DETAILS" Then
                Cancel_BTN.PerformClick()
                BiometricID_TXT.Text = .BiometricID
                Name_TXT.Text = .Fullname
                Name_TXT.Tag = .EMP_ID
                paydate_ = paydatee
                TabControl1.SelectedIndex = 1
            Else
                Payslip_paydate_Combo.Text = paydatee
                Employee_TXT.Text = .Fullname
                Employee_TXT.Tag = .BiometricID
                Email_TXT.Text = .EmailAdd
                Email_TXT.Tag = .Rate
                EmpSelect_BTN.Tag = .BranchID
                Employee_RadioB.Checked = True
                TabControl1.SelectedIndex = 2
            End If
        End With
    End Sub

End Class