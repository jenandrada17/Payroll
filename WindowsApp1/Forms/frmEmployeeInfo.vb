Public Class frmEmployeeInfo

    Private Sub frmEmployeeInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EmployeeDetails()
        EnableThis()
    End Sub

    Private Sub Close_LBL_MouseEnter(sender As Object, e As EventArgs) Handles Close_LBL.MouseEnter
        Close_LBL.ForeColor = Color.Red
    End Sub

    Private Sub Close_LBL_MouseLeave(sender As Object, e As EventArgs) Handles Close_LBL.MouseLeave
        Close_LBL.ForeColor = Color.Black
    End Sub

    Private Sub Close_LBL_Click(sender As Object, e As EventArgs) Handles Close_LBL.Click
        Close()
    End Sub

    Private Sub Save_BTN_Click(sender As Object, e As EventArgs) Handles Save_BTN.Click
        SaveAllowancesDedcution()
    End Sub

    Private Sub SaveAllowancesDedcution()

        If Fix_RB.Checked = True Then
            Fix_RB.Tag = "YES"
        Else
            Fix_RB.Tag = "NO"
        End If

        If isNotExist() Then

            Dim tmpEmployee As New Employee

            With tmpEmployee
                .ID = Biometric_TXT.Tag
                .Monthly = FixMonthly_TXT.Text
                .Daily = NotFixDaily_TXT.Text
                .Boarding = Boarding_TXT.Text
                .Carekit = CareKitAllowance_TXT.Text
                .Transportation = Transportation_TXT.Text
                .Medical = Medical_TXT.Text
                .Positional = Positional_TXT.Text
                .OtherAllowance = OtherAllowance_TXT.Text
                .Fix = Fix_RB.Tag

                .CashAdvance = CashAdvance_TXT.Text
                .Savings = Savings_TXT.Text
                .Loans = Loans_TXT.Text
                .Charges = Charges_TXT.Text
                .Meal = MealDeduction_TXT.Text
                .OtherDeduction = OtherDeduction_TXT.Text

                .SaveAllowDeduc()
            End With
            MsgBox("New Record Added", MsgBoxStyle.Information, "Information")
            Close()


        Else

            Dim tmpEmployee As New Employee

            With tmpEmployee

                .ID = Biometric_TXT.Tag
                .Monthly = FixMonthly_TXT.Text
                .Daily = NotFixDaily_TXT.Text
                .Boarding = Boarding_TXT.Text
                .Carekit = CareKitAllowance_TXT.Text
                .Transportation = Transportation_TXT.Text
                .Medical = Medical_TXT.Text
                .Positional = Positional_TXT.Text
                .OtherAllowance = OtherAllowance_TXT.Text
                .Fix = Fix_RB.Tag

                .CashAdvance = CashAdvance_TXT.Text
                .Savings = Savings_TXT.Text
                .Loans = Loans_TXT.Text
                .Charges = Charges_TXT.Text
                .Meal = MealDeduction_TXT.Text
                .OtherDeduction = OtherDeduction_TXT.Text

                .UpdateAllowDeduc()
            End With

            MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Information")
            Close()

        End If
    End Sub

    Private Sub EmployeeDetails()
        Dim mysql As String

        mysql = "Select * From tbl_employee  A
                    INNER JOIN TBL_BRANCH B ON A.BRANCH_id = B.ID 
                    INNER JOIN TBL_ADDRESS E ON A.PRESENT_ADDID = E.ID

                    WHERE A.BIOMETRICID = '" & Biometric_TXT.Text & "'"
        Using ds As DataSet = LoadSQL(mysql, "tbl_employee")

            If ds.Tables(0).Rows.Count > 0 Then

                Dim dr As DataRow = ds.Tables(0).Rows(0)
                With dr
                    Biometric_TXT.Tag = .Item("id")

                    Fname_TXT.Text = .Item("FIRSTNAME")
                    Mname_TXT.Text = .Item("MIDDLENAME")
                    Lname_TXT.Text = .Item("LASTNAME")

                    BDate_DTP.Text = .Item("DATEOFBIRTH")
                    Contact_TXT.Text = .Item("CONTACTNO")
                    Gender.Text = .Item("GENDER")
                    Marital_TXT.Text = .Item("CIVILSTATUS")
                    DateHired_TXT.Text = .Item("DATEHIRED")
                    Position_TXT.Text = .Item("EMP_POSITION")

                    TIN_TXT.Text = .Item("TINNO")
                    SSS_TXT.Text = .Item("SSSNO")
                    PhilHealth_TXT.Text = .Item("PHILHEALTHNO")

                    If Not IsDBNull(.Item("PAGIBIG")) Then
                        Pagibig_TXT.Text = .Item("PAGIBIG")
                    End If

                    Company_TXT.Text = .Item("COMPANYNAME")
                    Branch_TXT.Text = .Item("BRANCHNAME")

                    Street_TXT.Text = .Item("PRESENT_STREET")
                    Barangay_TXT.Text = .Item("BARANGAY")
                    Province_TXT.Text = .Item("PROVINCE")
                    City_TXT.Text = .Item("CITYMUN")
                End With
            End If
        End Using

        mysql = "Select * From tbl_employee INNER JOIN PAYROLL_ALLOW_DEDUC ON tbl_employee.ID = PAYROLL_ALLOW_DEDUC.EMP_ID  
                        WHERE tbl_employee.BIOMETRICID = '" & Biometric_TXT.Text & "'"

        Using ds As DataSet = LoadSQL(mysql, "tbl_employee")
            If ds.Tables(0).Rows.Count > 0 Then

                Dim dr As DataRow = ds.Tables(0).Rows(0)
                With dr

                    FixMonthly_TXT.Text = .Item("MONTHLY_SALARY")
                    NotFixDaily_TXT.Text = .Item("DAILY_SALARY")
                    Boarding_TXT.Text = .Item("BOARDING_ALLOWANCE")
                    CareKitAllowance_TXT.Text = .Item("CAREKIT_ALLOWANCE")
                    Transportation_TXT.Text = .Item("TRANSPO_ALLOWANCE")
                    Medical_TXT.Text = .Item("MEDICAL_ALLOWANCE")
                    Positional_TXT.Text = .Item("POSITIONAL_ALLOWANCE")
                    OtherAllowance_TXT.Text = .Item("OTHER_ALLOWANCE")

                    If .Item("FIX_RATE") = "NO" Then
                        Fix_RB.Checked = False
                        NotFix_RB.Checked = True
                    Else
                        Fix_RB.Checked = True
                        NotFix_RB.Checked = False
                    End If

                    CashAdvance_TXT.Text = .Item("CASH_ADVANCE")
                    Savings_TXT.Text = .Item("SAVINGS_DEDUCTION")
                    Loans_TXT.Text = .Item("LOANS_DEDUCTION")
                    Charges_TXT.Text = .Item("CHARGES_DEDUCTION")
                    MealDeduction_TXT.Text = .Item("MEAL_DEDUCTION")
                    OtherDeduction_TXT.Text = .Item("OTHER_DEDUCTION")

                End With

            End If
        End Using
    End Sub

    Private Function isNotExist()
        Dim mysql As String = "SELECT * FROM PAYROLL_ALLOW_DEDUC Where EMP_ID  = '" & Biometric_TXT.Tag & "'"
        Dim ds As DataSet = LoadSQL(mysql, "PAYROLL_ALLOW_DEDUC")
        If ds.Tables(0).Rows.Count > 0 Then
            Return False
        End If

        Return True
    End Function

    Private Sub Edit_BTN_Click(sender As Object, e As EventArgs) Handles Edit_BTN.Click

        Fix_RB.Enabled = True
        NotFix_RB.Enabled = True

        If Fix_RB.Checked = True Then
            FixMonthly_TXT.ReadOnly = False
            NotFixDaily_TXT.ReadOnly = True
        Else
            FixMonthly_TXT.ReadOnly = True
            NotFixDaily_TXT.ReadOnly = False
        End If

        Boarding_TXT.ReadOnly = False
        CareKitAllowance_TXT.ReadOnly = False
        Transportation_TXT.ReadOnly = False
        Medical_TXT.ReadOnly = False
        Positional_TXT.ReadOnly = False
        OtherAllowance_TXT.ReadOnly = False

        CashAdvance_TXT.ReadOnly = False
        Savings_TXT.ReadOnly = False
        Loans_TXT.ReadOnly = False
        Charges_TXT.ReadOnly = False
        MealDeduction_TXT.ReadOnly = False
        OtherDeduction_TXT.ReadOnly = False
        Save_BTN.Visible = True
        Edit_BTN.Visible = False

    End Sub

    Private Sub EnableThis()

        If FixMonthly_TXT.Text = "" And NotFixDaily_TXT.Text = "" Then
            Save_BTN.Visible = True
            Edit_BTN.Visible = False

            Fix_RB.Enabled = True
            NotFix_RB.Enabled = True
            NotFixDaily_TXT.ReadOnly = False
            Boarding_TXT.ReadOnly = False
            CareKitAllowance_TXT.ReadOnly = False
            Transportation_TXT.ReadOnly = False
            Medical_TXT.ReadOnly = False
            Positional_TXT.ReadOnly = False
            OtherAllowance_TXT.ReadOnly = False

            CashAdvance_TXT.ReadOnly = False
            Savings_TXT.ReadOnly = False
            Loans_TXT.ReadOnly = False
            Charges_TXT.ReadOnly = False
            MealDeduction_TXT.ReadOnly = False
            OtherDeduction_TXT.ReadOnly = False
            Edit_BTN.Visible = False
        Else
            Save_BTN.Visible = False
            Edit_BTN.Visible = True
        End If
    End Sub


    Private Sub Fix_RB_EnabledChanged(sender As Object, e As EventArgs) Handles Fix_RB.EnabledChanged

        If Fix_RB.Enabled = False Then
            NotFixDaily_TXT.ReadOnly = True
            FixMonthly_TXT.ReadOnly = True
        End If

    End Sub

    Private Sub Fix_RB_CheckedChanged(sender As Object, e As EventArgs) Handles Fix_RB.CheckedChanged

        If Fix_RB.Checked = True Then
            NotFixDaily_TXT.ReadOnly = True
            FixMonthly_TXT.ReadOnly = False
            NotFixDaily_TXT.Clear()
        Else
            FixMonthly_TXT.ReadOnly = True
            NotFixDaily_TXT.ReadOnly = False
            FixMonthly_TXT.Clear()
        End If

    End Sub
End Class