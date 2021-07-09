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
        Payout_ALL()
        Lists_Payout(Payout_list, paydate_)
        PopulateComboBox(Paydate_ComboB, "PAYROLL_PAYOUT", "PAYDATE", paydate_)
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

    Private Sub Payout_ALL() '========== AUTO SAVE TO PAYOUT ============

        Dim mysql As String = "Select * From payroll_attendance A 
                                inner join TBL_EMPLOYEE B on B.BIOMETRICID = A.BIOMETRICID 
                                left join TBL_BRANCH C on C.BRANCHNAME = A.BRANCH and B.BRANCH_ID = C.ID WHERE A.PAYDATE = '" & paydate_ & "'"

        Using ds As DataSet = LoadSQL(mysql, "payroll_attendance")

            If ds.Tables(0).Rows.Count > 0 Then

                rowCount = ds.Tables(0).Rows.Count
                Dim maxEntries As Integer = ds.Tables(0).Rows.Count
                frmMainForm.AppProgressBar.Maximum = maxEntries
                frmMainForm.AppProgressBar.Visible = True

                For Each dr In ds.Tables(0).Rows
                    With dr
                        Cancel_BTN.PerformClick()

                        Dim MI As String

                        If String.IsNullOrEmpty(.Item("MIDDLENAME")) Then
                            MI = ""
                        Else
                            MI = .Item("MIDDLENAME").Substring(0, 1) & "."
                        End If

                        BiometricID_TXT.Text = .Item("BIOMETRICID")
                        Name_TXT.Text = .Item("FIRSTNAME") & " " & MI & " " & .Item("LASTNAME") & " " & .Item("SUFFIX")
                        Name_TXT.Tag = .Item("ID")
                        Rate_TXT.Text = IIf(IsDBNull(.Item("RATE")), 0, .Item("RATE"))
                        Rate_TXT.Tag = .Item("BRANCH_ID")

                        AttendanceDetails(BiometricID_TXT.Text, paydate_, NoOfDays_TXT, RegularOT_TXT, SpecialHol_TXT, RegularHol_TXT,
                                                    Late_TXT, UnderTime_TXT)

                        AllowanceDetails(BiometricID_TXT.Text, Rate_TXT.Tag, Positional_TXT, Incentive_TXT, Boarding_TXT, Carekit_TXT, Transport_TXT)   '============ Rate_TXT.Tag is branchID (for same biometric) ======

                        DeductioneDetails(BiometricID_TXT.Text, Rate_TXT.Tag, CashAdvance_TXT, Loan_TXT, Charges_TXT)

                        Calculate_Gross()

                        Calculate_Allowance()

                        Calculate_Deduction()

                        Calculate_NetPay()

                        SavePayout(BiometricID_TXT.Text, Rate_TXT.Tag, paydate_, TotalBasic_LBL.Text, TotalOT_LBL.Text,
                                  TotalLateUnder_LBL.Text, GrossAmount_LBL.Text, SSSComp_LBL.Text, Pagibig_LBL.Text, Philhealth_LBL.Text,
                                  TaxComp_LBL.Text, Tax_Wheld_LBL.Text, NetTax_LBL.Text, SSSLoan_LBL.Text, PagibigLoan_LBL.Text,
                                  Allowances_LBL.Text, Deduction_LBL.Text, NetPay_LBL.Text, True)

                        frmMainForm.AppProgressBar.Value += 1
                    End With
                Next
            End If
        End Using

        frmMainForm.AppProgressBar.Value = 0
        frmMainForm.AppProgressBar.Maximum = 1000
        frmMainForm.AppProgressBar.Visible = False
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
        If String.IsNullOrEmpty(Name_TXT.Text) And String.IsNullOrEmpty(Rate_TXT.Text) Then
        Else
            If Bio_Exist_Attendance(BiometricID_TXT.Text, paydate_) Then

                AttendanceDetails(BiometricID_TXT.Text, paydate_, NoOfDays_TXT, RegularOT_TXT, SpecialHol_TXT, RegularHol_TXT,
                                            Late_TXT, UnderTime_TXT)

                AllowanceDetails(BiometricID_TXT.Text, Rate_TXT.Tag, Positional_TXT, Incentive_TXT, Boarding_TXT, Carekit_TXT, Transport_TXT)   '============ Rate_TXT.Tag is branchID (for same biometric) ======

                DeductioneDetails(BiometricID_TXT.Text, Rate_TXT.Tag, CashAdvance_TXT, Loan_TXT, Charges_TXT)


                Calculate_Gross()

                Calculate_Allowance()

                Calculate_Deduction()

                Calculate_NetPay()

            End If
        End If
    End Sub

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
        End If
    End Sub

    Private Sub Payout_list_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Payout_list.MouseDoubleClick
        Cancel_BTN.PerformClick()
        TabControl1.SelectedIndex = 1
        BiometricID_TXT.Text = Payout_list.FocusedItem.SubItems(1).Tag
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
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Not Name_TXT.Text = String.Empty Then

            SavePayout(BiometricID_TXT.Text, Rate_TXT.Tag, paydate_, TotalBasic_LBL.Text, TotalOT_LBL.Text,
                          TotalLateUnder_LBL.Text, GrossAmount_LBL.Text, SSSComp_LBL.Text, Pagibig_LBL.Text, Philhealth_LBL.Text,
                          TaxComp_LBL.Text, Tax_Wheld_LBL.Text, NetTax_LBL.Text, SSSLoan_LBL.Text, PagibigLoan_LBL.Text,
                          Allowances_LBL.Text, Deduction_LBL.Text, NetPay_LBL.Text)
        End If
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
    End Sub

    Private Sub Search_BTN_Click(sender As Object, e As EventArgs) Handles Search_BTN.Click
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
    End Sub

    Private Sub OtherDeduction_TXT_TextChanged(sender As Object, e As EventArgs) Handles OtherDeduction_TXT.TextChanged
        If Not Name_TXT.Text = String.Empty Then
            Calculate_ON_OFF()
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