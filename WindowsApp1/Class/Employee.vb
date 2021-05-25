Public Class Employee


#Region "Salary and Allowance"

    Public Property ID() As String

    Public Property Monthly() As String

    Public Property Daily() As String

    Public Property Boarding() As String

    Public Property Carekit() As String

    Public Property Transportation() As String

    Public Property Medical() As String

    Public Property Positional() As String

    Public Property OtherAllowance() As String

    Public Property IDExist() As String

    Public Property Fix() As String

#End Region

#Region "Deduction"

    Public Property CashAdvance() As String

    Public Property Savings() As String

    Public Property Loans() As String

    Public Property Charges() As String

    Public Property Meal() As String

    Public Property OtherDeduction() As String

#End Region

    Friend Sub UpdateAllowDeduc()
        Dim mysql As String = "Select * From PAYROLL_ALLOW_DEDUC Where EMP_ID = '" & ID & "'"
        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_ALLOW_DEDUC")

            With ds.Tables(0).Rows(0)
                .Item("MONTHLY_SALARY") = Monthly
                .Item("DAILY_SALARY") = Daily
                .Item("BOARDING_ALLOWANCE") = Boarding
                .Item("CAREKIT_ALLOWANCE") = Carekit
                .Item("TRANSPO_ALLOWANCE") = Transportation
                .Item("MEDICAL_ALLOWANCE") = Medical
                .Item("POSITIONAL_ALLOWANCE") = Positional
                .Item("OTHER_ALLOWANCE") = OtherAllowance
                .Item("FIX_RATE") = Fix()

                .Item("CASH_ADVANCE") = CashAdvance
                .Item("SAVINGS_DEDUCTION") = Savings
                .Item("LOANS_DEDUCTION") = Loans
                .Item("CHARGES_DEDUCTION") = Charges
                .Item("MEAL_DEDUCTION") = Meal
                .Item("OTHER_DEDUCTION") = OtherDeduction
            End With
            SaveEntry(ds, False)
        End Using

    End Sub

    Friend Sub SaveAllowDeduc()
        Dim mysql As String = "Select * From PAYROLL_ALLOW_DEDUC Rows 1"
        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_ALLOW_DEDUC")

            Dim dsNewRow As DataRow
            dsNewRow = ds.Tables(0).NewRow
            With dsNewRow
                .Item("EMP_ID") = ID
                .Item("MONTHLY_SALARY") = Monthly
                .Item("DAILY_SALARY") = Daily
                .Item("BOARDING_ALLOWANCE") = Boarding
                .Item("CAREKIT_ALLOWANCE") = Carekit
                .Item("TRANSPO_ALLOWANCE") = Transportation
                .Item("MEDICAL_ALLOWANCE") = Medical
                .Item("POSITIONAL_ALLOWANCE") = Positional
                .Item("OTHER_ALLOWANCE") = OtherAllowance
                .Item("FIX_RATE") = Fix

                .Item("CASH_ADVANCE") = CashAdvance
                .Item("SAVINGS_DEDUCTION") = Savings
                .Item("LOANS_DEDUCTION") = Loans
                .Item("CHARGES_DEDUCTION") = Charges
                .Item("MEAL_DEDUCTION") = Meal
                .Item("OTHER_DEDUCTION") = OtherDeduction
            End With
            ds.Tables(0).Rows.Add(dsNewRow)
            SaveEntry(ds)
        End Using
    End Sub

End Class
