Public Class frmPayout
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

        If Not BiometricID_TXT.Text = "" Then
            Console.WriteLine("MEEE = " & BiometricID_TXT.Text)

            AllowanceDeductionDetails(BiometricID_TXT.Text, Name_TXT, Yes_RB, Rate_TXT, Boarding_TXT, Carekit_TXT, Positional_TXT, Transport_TXT,
                                    Medical_TXT, OtherAllowance_TXT, CashAdvance_TXT, Savings_TXT, Loan_TXT, Charges_TXT, Meal_TXT, OtherDeduction_TXT)

        End If

    End Sub

    Private Sub Close_LBL_Click_1(sender As Object, e As EventArgs) Handles Close_LBL.Click
        Close()
    End Sub

    Private Sub Calculate_BTN_Click(sender As Object, e As EventArgs) Handles Calculate_BTN.Click

        If Not BiometricID_TXT.Text = "" And Not PayDate_DTP.Value = Date.Now Then

            Dim mysql As String = "Select * From payroll_attendance WHERE BIOMETRICID= '" & BiometricID_TXT.Text & "' and PAYDATE = '" & PayDate_DTP.Value.ToString("dd/MM/yyyy") & "'"
            Using ds As DataSet = LoadSQL(mysql, "payroll_attendance")

                If ds.Tables(0).Rows.Count > 0 Then
                    Dim data As DataRow = ds.Tables(0).Rows(0)
                    With data

                        NoOfDays_TXT.Text = .Item("TOTALDAYS")
                        Late_TXT.Text = .Item("TOTALLATEMINUTE")  '========== Minutes only
                        UnderTime_TXT.Text = .Item("TOTALUTMINUTE")

                    End With
                End If

            End Using
        End If
    End Sub

    Private Sub frmPayout_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class