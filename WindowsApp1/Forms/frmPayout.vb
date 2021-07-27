Public Class frmPayout

    Dim regHoliday As Integer
    Dim specHoliday As Integer
    Dim paydate_ As String = frmMainForm.Paydate.ToString("d")

    Private Sub frmPayout_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        regHoliday = Holiday_Rate("REGULAR")
        specHoliday = Holiday_Rate("SPECIAL")
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
            BiometricNo_Payout(BiometricID_TXT.Text, Name_TXT, Rate_TXT)
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
        Calculate_Allowance()
    End Sub

    Private Sub OtherDeduction_TXT_TextChanged(sender As Object, e As EventArgs) Handles OtherDeduction_TXT.TextChanged
        Calculate_Deduction()
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

        Dim SBU, Charges, Loan, CashAdvance, other As Double

        Charges = If(Not (CashAdvance_TXT.Text = String.Empty), CashAdvance_TXT.Text, 0)
        Loan = If(Not (Loan_TXT.Text = String.Empty), Loan_TXT.Text, 0)
        CashAdvance = If(Not (Charges_TXT.Text = String.Empty), Charges_TXT.Text, 0)
        other = If(Not (OtherDeduction_TXT.Text = String.Empty), OtherDeduction_TXT.Text, 0)

        Deduction_LBL.Text = Charges + Loan + CashAdvance + other

    End Sub

    Private Sub OtherDeduction_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles OtherDeduction_TXT.KeyPress, OtherAllowance_TXT.KeyPress, BiometricID_TXT.KeyPress
        If e.KeyChar <> ChrW(Keys.Back) Then
            If Char.IsNumber(e.KeyChar) Then
            Else
                e.Handled = True
            End If
        End If
    End Sub

End Class