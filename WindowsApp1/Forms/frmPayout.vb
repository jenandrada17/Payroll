Public Class frmPayout

    Dim rowCount, regHoliday, specHoliday As Integer
    Dim paydate_ As String = frmMainForm.Paydate.ToString("d")
    Dim SBU, Charges, Loan, CashAdvance, other As Double
    Dim SBUUU, Chargesss, Loannn, CashAdvanceee, otherrr As Double
    Dim gross, netTax, sssLoan, pagibigLoan, allowance, deduction As Double

    Private Sub frmPayout_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        regHoliday = Holiday_Rate("REGULAR")
        specHoliday = Holiday_Rate("SPECIAL")
        Savings_TXT.Text = SBU_Amount()
        PopulateComboBox(Paydate_ComboB, "PAYROLL_PAYOUT", "PAYDATE")
    End Sub

    Private Sub Select_BTN_Click(sender As Object, e As EventArgs) Handles Select_BTN.Click

        If frmEmployee Is Nothing Then
            Dim frm As New frmEmployee With {
                .MdiParent = frmMainForm
            }
            frmMainForm.pNavigate.Controls.Add(frm)
            frmMainForm.pNavigate.Tag = frm
            frm.txtSearch.Tag = "Payout"
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
        End If

    End Sub

    Private Sub Close_LBL_Click_1(sender As Object, e As EventArgs) Handles Close_LBL.Click
        Close()
    End Sub

    Private Sub Name_TXT_TextChanged(sender As Object, e As EventArgs) Handles Name_TXT.TextChanged

        If String.IsNullOrEmpty(BiometricID_TXT.Text) And String.IsNullOrEmpty(Name_TXT.Text) Then
            'ElseIf String.IsNullOrEmpty(Rate_TXT.Text) Then
        Else
            If Bio_Exist_Attendance(BiometricID_TXT.Text, paydate_) Then

                AttendanceDetails(BiometricID_TXT.Text, paydate_, NoOfDays_TXT, RegularOT_TXT, SpecialHol_TXT, RegularHol_TXT,
                                            Late_TXT, UnderTime_TXT)

                AllowanceDetails(BiometricID_TXT.Text, Rate_TXT.Tag, Positional_TXT, Incentive_TXT, Boarding_TXT, Carekit_TXT, Transport_TXT)   '===== Rate_TXT.Tag is branchID (for same biometric) ======

                DeductioneDetails(BiometricID_TXT.Text, Rate_TXT.Tag, CashAdvance_TXT, Loan_TXT, Charges_TXT)

                OtherDetails(BiometricID_TXT.Text, Rate_TXT.Tag, paydate_, Savings_TXT, OtherAllowance_TXT, OtherDeduction_TXT)

                If IsLastDay(paydate_) Then
                    Distribution_Details(BiometricID_TXT.Text, Rate_TXT.Tag, paydate_, SSSComp_LBL, HDMF_LBL, Philhealth_LBL)
                End If

                Calculate_Gross()

                Calculate_Allowance()

                Calculate_Deduction()

                Calculate_NetPay()

            End If
        End If
    End Sub

    Function IsLastDay(ByVal myDate As Date) As Boolean
        Return myDate.Day = Date.DaysInMonth(myDate.Year, myDate.Month)
    End Function

    Private Sub Cancel_BTN_Click(sender As Object, e As EventArgs) Handles Cancel_BTN.Click

        For Each Ctl In GroupBox6.Controls
            If TypeOf Ctl Is TextBox Then Ctl.Text = ""
        Next

        For Each Ctl In GroupBox1.Controls
            If TypeOf Ctl Is TextBox Then Ctl.Text = ""
        Next

        For Each Ctl In GroupBox2.Controls
            If TypeOf Ctl Is TextBox Then Ctl.Text = ""
        Next

        For Each Ctl In GroupBox3.Controls
            If TypeOf Ctl Is TextBox Then Ctl.Text = ""
        Next

        For Each Ctl In GroupBox4.Controls

            If TypeOf Ctl Is Label Then

                If IsNumeric(Ctl.text) Then
                    Ctl.Text = 0
                End If

            End If
        Next
    End Sub

    Private Sub OtherAllowance_TXT_TextChanged(sender As Object, e As EventArgs) Handles OtherAllowance_TXT.TextChanged
        If Not Name_TXT.Text = String.Empty Then
            Calculate_Allowance()
            Calculate_NetPay()
        End If
    End Sub

    Private Sub Details_Save_BTN_Click(sender As Object, e As EventArgs) Handles Details_Save_BTN.Click
        If Not Name_TXT.Text = String.Empty Then

            SavePayout(BiometricID_TXT.Text, Rate_TXT.Tag, paydate_, TotalBasic_LBL.Text, TotalOT_LBL.Text,
                          TotalLateUnder_LBL.Text, GrossAmount_LBL.Text, SSSComp_LBL.Text, HDMF_LBL.Text, Philhealth_LBL.Text,
                          TaxComp_LBL.Text, Tax_Wheld_LBL.Text, NetTax_LBL.Text, SSSLoan_LBL.Text, PagibigLoan_LBL.Text,
                          Allowances_LBL.Text, Deduction_LBL.Text, NetPay_LBL.Text, Savings_TXT.Text)

            Save_SBU_AND_OTHER(BiometricID_TXT.Text, Rate_TXT.Tag, paydate_, OtherAllowance_TXT.Text, OtherDeduction_TXT.Text)

            Cancel_BTN.PerformClick()
        End If

    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        'If Paydate_ComboB.Text = "   Select Pay date" Then
        '    paydate_ = frmMainForm.Paydate.ToString("d")
        'Else
        '    paydate_ = Paydate_ComboB.SelectedItem
        'End If
        'If TabControl1.SelectedIndex = 0 Then
        '    Lists_Payout(Payout_list, paydate_)
        '    GetPayout_TOTALS(paydate_, P_GrossAmount_LBL, P_SSSComp_LBL, P_PagibigComp_LBL, P_PhilHComp_LBL, P_Taxable_LBL, P_TaxWH_LBL,
        '                     P_SSSLoan_LBL, P_PagibigLoan_LBL, P_Allowance_LBL, P_Deduction_LBL, P_NetPay_LBL)
        'End If

    End Sub

    Private Sub Pay_Refresh_BTN_Click(sender As Object, e As EventArgs) Handles Pay_Refresh_BTN.Click
        SavePayout_ALL(paydate_)

        Lists_Payout(Payout_list, paydate_)

        GetPayout_TOTALS(paydate_, P_GrossAmount_LBL, P_SSSComp_LBL, P_PagibigComp_LBL, P_PhilHComp_LBL, P_Taxable_LBL, P_TaxWH_LBL,
                         P_SSSLoan_LBL, P_PagibigLoan_LBL, P_Allowance_LBL, P_Deduction_LBL, P_NetPay_LBL)
    End Sub

    Private Sub Paydate_ComboB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Paydate_ComboB.SelectedIndexChanged
        paydate_ = Paydate_ComboB.SelectedItem

        Lists_Payout(Payout_list, paydate_)

        GetPayout_TOTALS(paydate_, P_GrossAmount_LBL, P_SSSComp_LBL, P_PagibigComp_LBL, P_PhilHComp_LBL, P_Taxable_LBL, P_TaxWH_LBL,
                         P_SSSLoan_LBL, P_PagibigLoan_LBL, P_Allowance_LBL, P_Deduction_LBL, P_NetPay_LBL)
        Console.WriteLine("payyyy_combo_change " & paydate_)
    End Sub

    Private Sub Payout_list_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Payout_list.MouseDoubleClick
        If Payout_list.SelectedItems.Count > 0 Then
            Cancel_BTN.PerformClick()
            BiometricID_TXT.Clear()
            Name_TXT.Clear()
            BiometricID_TXT.Text = Payout_list.FocusedItem.SubItems(1).Tag
            TabControl1.SelectedIndex = 1
        End If
    End Sub

    Private Sub Off_Cash_BTN_Click(sender As Object, e As EventArgs) Handles Off_Cash_BTN.Click
        If Off_Cash_BTN.Text = "OFF" Then
            Off_Cash_BTN.Text = "ON"
            CashAdvance_TXT.Text = ""
        Else
            Off_Cash_BTN.Text = "OFF"
            CashAdvance_TXT.Text = CashAdvance
        End If
        Calculate_ON_OFF()
        Calculate_NetPay()
    End Sub

    Private Sub Off_SBU_BTN_Click(sender As Object, e As EventArgs) Handles Off_SBU_BTN.Click
        If Off_SBU_BTN.Text = "OFF" Then
            Off_SBU_BTN.Text = "ON"
            Savings_TXT.Text = ""
        Else
            Off_SBU_BTN.Text = "OFF"
            Savings_TXT.Text = SBU
        End If
        Calculate_ON_OFF()
        Calculate_NetPay()
    End Sub

    Private Sub Search_BTN_Click(sender As Object, e As EventArgs) Handles Search_BTN.Click
        'Grid_Payout(Payout_grid, paydate_, Search_TXT.Text)  
        Lists_Payout(Payout_list, paydate_, Search_TXT.Text)
    End Sub

    Private Sub Search_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Search_TXT.KeyPress
        If IsEnter(e) Then Search_BTN.PerformClick()
    End Sub

    Private Sub Off_Loan_BTN_Click(sender As Object, e As EventArgs) Handles Off_Loan_BTN.Click
        If Off_Loan_BTN.Text = "OFF" Then
            Off_Loan_BTN.Text = "ON"
            Loan_TXT.Text = ""
        Else
            Off_Loan_BTN.Text = "OFF"
            Loan_TXT.Text = Loan
        End If
        Calculate_ON_OFF()
        Calculate_NetPay()
    End Sub

    Private Sub Off_Charges_BTN_Click(sender As Object, e As EventArgs) Handles Off_Charges_BTN.Click
        If Off_Charges_BTN.Text = "OFF" Then
            Off_Charges_BTN.Text = "ON"
            Charges_TXT.Text = ""
        Else
            Off_Charges_BTN.Text = "OFF"
            Charges_TXT.Text = Charges
        End If
        Calculate_ON_OFF()
        Calculate_NetPay()
    End Sub

    Private Sub OtherDeduction_TXT_TextChanged(sender As Object, e As EventArgs) Handles OtherDeduction_TXT.TextChanged
        If Not Name_TXT.Text = String.Empty Then
            Calculate_ON_OFF()
            Calculate_NetPay()
        End If
    End Sub

    Private Sub Calculate_Gross()

        TotalBasic_LBL.Text = NoOfDays_TXT.Text * Rate_TXT.Text

        TotalHol_LBL.Text = (((Convert.ToInt32(SpecialHol_TXT.Text) * Convert.ToInt32(Rate_TXT.Text)) * specHoliday) / specHoliday) + (((Convert.ToInt32(RegularHol_TXT.Text) * Convert.ToInt32(Rate_TXT.Text)) * regHoliday) / regHoliday) ' =========== CALCULATE hOLIDAY TO PESO ===========

        TotalOT_LBL.Text = ((Convert.ToInt32(Rate_TXT.Text) / 8) * 1.25) * Convert.ToInt32(RegularOT_TXT.Text) ' =========== CALCULATE OVERTIME TO PESO ===========

        Dim late_split() As String, under_split() As String, lateTOMinute, underToMinute As Double

        late_split = Split(Late_TXT.Text, ":")
        under_split = Split(UnderTime_TXT.Text, ":")

        lateTOMinute = CDbl(late_split(0)) * 60 + CDbl(late_split(1)) + CDbl(late_split(2)) / 60
        underToMinute = (CDbl(under_split(0)) * 60 + CDbl(under_split(1)) + CDbl(under_split(2)) / 60) / 60

        Dim LATEE, UNDERTIMEE As Double
        LATEE = ((Convert.ToInt32(Rate_TXT.Text) / 8) / 60) * lateTOMinute
        UNDERTIMEE = (Convert.ToInt32(Rate_TXT.Text) / 8) * underToMinute

        TotalLateUnder_LBL.Text = LATEE + UNDERTIMEE

        GrossAmount_LBL.Text = (Convert.ToDouble(TotalBasic_LBL.Text) + Convert.ToDouble(TotalHol_LBL.Text) + Convert.ToDouble(TotalOT_LBL.Text)) - Convert.ToDouble(TotalLateUnder_LBL.Text)

    End Sub

    Private Sub Calculate_Allowance()
        Dim CAREKIT, BOARDING, INCENTIVES, positional, TRANSPORTATION, other As Double

        CAREKIT = If(Not (Carekit_TXT.Text = String.Empty), Carekit_TXT.Text, 0)
        BOARDING = If(Not (Boarding_TXT.Text = String.Empty), Boarding_TXT.Text, 0)
        INCENTIVES = If(Not (Incentive_TXT.Text = String.Empty), Incentive_TXT.Text, 0)
        positional = If(Not (Positional_TXT.Text = String.Empty), Positional_TXT.Text, 0)
        TRANSPORTATION = If(Not (Transport_TXT.Text = String.Empty), Transport_TXT.Text, 0)
        other = If(Not (OtherAllowance_TXT.Text = String.Empty), OtherAllowance_TXT.Text, 0)

        Allowances_LBL.Text = CAREKIT + BOARDING + INCENTIVES + positional + TRANSPORTATION + other
    End Sub

    Private Sub Calculate_Deduction()

        SBU = If(Not (Savings_TXT.Text = String.Empty), Savings_TXT.Text, 0)
        CashAdvance = If(Not (CashAdvance_TXT.Text = String.Empty), CashAdvance_TXT.Text, 0)
        Loan = If(Not (Loan_TXT.Text = String.Empty), Loan_TXT.Text, 0)
        Charges = If(Not (Charges_TXT.Text = String.Empty), Charges_TXT.Text, 0)
        other = If(Not (OtherDeduction_TXT.Text = String.Empty), OtherDeduction_TXT.Text, 0)

        Deduction_LBL.Text = SBU + Charges + Loan + CashAdvance + other

    End Sub

    Private Sub Calculate_NetPay()

        gross = If(Not (GrossAmount_LBL.Text = String.Empty), GrossAmount_LBL.Text, 0)
        netTax = If(Not (NetTax_LBL.Text = String.Empty), NetTax_LBL.Text, 0)
        sssLoan = If(Not (SSSLoan_LBL.Text = String.Empty), SSSLoan_LBL.Text, 0)
        pagibigLoan = If(Not (PagibigLoan_LBL.Text = String.Empty), PagibigLoan_LBL.Text, 0)
        allowance = If(Not (Allowances_LBL.Text = String.Empty), Allowances_LBL.Text, 0)
        deduction = If(Not (Deduction_LBL.Text = String.Empty), Deduction_LBL.Text, 0)

        Dim positive = gross + allowance
        Dim negative = netTax + sssLoan + pagibigLoan + deduction

        NetPay_LBL.Text = positive - negative

    End Sub

    Private Sub OtherDeduction_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles OtherDeduction_TXT.KeyPress, OtherAllowance_TXT.KeyPress, BiometricID_TXT.KeyPress
        If e.KeyChar <> ChrW(Keys.Back) Then
            If Char.IsNumber(e.KeyChar) Then
            Else
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub Calculate_ON_OFF()

        SBUUU = If(Not (Savings_TXT.Text = String.Empty), Savings_TXT.Text, 0)
        CashAdvanceee = If(Not (CashAdvance_TXT.Text = String.Empty), CashAdvance_TXT.Text, 0)
        Loannn = If(Not (Loan_TXT.Text = String.Empty), Loan_TXT.Text, 0)
        Chargesss = If(Not (Charges_TXT.Text = String.Empty), Charges_TXT.Text, 0)
        otherrr = If(Not (OtherDeduction_TXT.Text = String.Empty), OtherDeduction_TXT.Text, 0)

        Deduction_LBL.Text = SBUUU + Chargesss + Loannn + CashAdvanceee + otherrr

    End Sub

End Class