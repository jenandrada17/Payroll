Public Class frmReport

    Private Sub frmReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PopulateComboBox(PaydateNet_ComboB, "PAYROLL_PAYOUT", "PAYDATE")
        Lists_SBU(SBU_LV)
    End Sub

    Private Sub SearchSBU_BTN_Click(sender As Object, e As EventArgs) Handles SearchSBU_BTN.Click
        Lists_SBU(SBU_LV, SearchSBU_TXT.Text)
    End Sub

    Private Sub SearchSBU_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles SearchSBU_TXT.KeyPress
        If IsEnter(e) Then SearchSBU_BTN.PerformClick()
    End Sub

    Private Sub PreviewNet_BTN_Click(sender As Object, e As EventArgs) Handles PreviewNet_BTN.Click

        If PaydateNet_ComboB.SelectedIndex >= 0 Then
            LoadNet_Print()
        Else
            MsgBox("Please select date of payroll.", MsgBoxStyle.Exclamation, "Error")
        End If

    End Sub

    Public Sub LoadNet_Print()

        ReportV_NetPay.LocalReport.DataSources.Clear()
        ReportV_NetPay.LocalReport.ReportEmbeddedResource = "WindowsApp1.rpt_NetPay.rdlc"

        Dim paydatee As String = PaydateNet_ComboB.SelectedItem
        Dim mysqll As String = ""
        Dim GROUP As String = ""
        Dim period As String

        Dim date_pay As DateTime = Convert.ToDateTime(PaydateNet_ComboB.Text)
        date_pay = date_pay.ToString("d")

        If IsLastDay(date_pay) Then
            period = "2nd Period"
        Else
            period = "1st Period"
        End If

        Try
            Dim all_in As New reports.NetPayDataTable

            Dim dt_NetPay As New DataTable()
            With dt_NetPay
                .Columns.Add("EMP_NO")
                .Columns.Add("FULLNAME")
                .Columns.Add("BASIC")
                .Columns.Add("OVERTIME")
                .Columns.Add("HOLIDAY")
                .Columns.Add("N_DIFF")
                .Columns.Add("PI_ECOLA_SIL")
                .Columns.Add("TARDINESS")
                .Columns.Add("SSS")
                .Columns.Add("PHIC")
                .Columns.Add("PAGIBIG")
                .Columns.Add("SBU_CHARGES")
                .Columns.Add("NET_PAY")
                .Columns.Add("BRANCH_CODE")
                .Columns.Add("PAYDATE")
                .Columns.Add("PERIOD")
                '.Columns.Add("RANGE")
                .Columns.Add("COMPANY")
            End With

            If Company_Combo.SelectedIndex >= 0 Then

                mysqll = $"Select * From PAYROLL_PAYOUT A 
                                        inner JOIN PAYROLL_EMPLOYEE B ON B.BIO_NO = A.BIOMETRIC_ID 
                                        where A.PAYDATE  = '{paydatee}' and B.COMPANY  = '{Company_Combo.Text}' ORDER BY BRANCH_CODE, FULLNAME ASC"

            Else

                mysqll = $"Select * From PAYROLL_PAYOUT A 
                                        inner JOIN PAYROLL_EMPLOYEE B ON B.BIO_NO = A.BIOMETRIC_ID 
                                        where A.PAYDATE  = '{paydatee}' ORDER BY COMPANY, BRANCH_CODE, FULLNAME ASC"

            End If
            Using ds As DataSet = LoadSQL(mysqll, "PAYROLL_PAYOUT")

                If ds.Tables(0).Rows.Count > 0 Then

                    For Each dr In ds.Tables(0).Rows
                        With dr

                            Dim dateStarted As DateTime = .Item("DATE_STARTED")

                            Dim year As String = dateStarted.ToString("yy")
                            Dim month As String = dateStarted.ToString("MM")

                            Dim EMP_NO As String = year & "-0" & month & "-" & .Item("BIOMETRIC_ID")

                            Dim payroll As DateTime = paydatee

                            '============================= NAME AND ATTENDANCE ============================  
                            Dim namee As String = .Item("FULLNAME")
                            Dim BASIC As Double = .Item("TOTAL_BASIC")
                            Dim OVERTIME As Double = .Item("TOTAL_OVERTIME")
                            Dim HOLIDAY As Double = .Item("TOTAL_HOLIDAY")
                            Dim N_DIFF As Double = .Item("TOTAL_NIGHT_RATE")
                            Dim PI_ECOLA_SIL As Double = .Item("TOTAL_ALLOWANCE")
                            Dim TARDINESS As Double = .Item("TOTAL_LATE_UT")
                            Dim SSS As Double = .Item("SSS_COMP")
                            Dim PHIC As Double = .Item("PHILHEALTH_COMP")
                            Dim PAGIBIG As Double = .Item("PAGIBIG_COMP")
                            Dim SBU_CHARGES As Double = .Item("TOTAL_DEDUCTION")
                            Dim NET_PAY As Double = .Item("NET_PAY")
                            Dim BRANCH_CODE As String = .Item("BRANCH_CODE")
                            Dim COMPANY As String = .Item("COMPANY")

                            dt_NetPay.Rows.Add(EMP_NO, namee, BASIC.ToString("n"), OVERTIME.ToString("n"), HOLIDAY.ToString("n"), N_DIFF.ToString("n"),
                                               PI_ECOLA_SIL.ToString("n"), TARDINESS.ToString("n"), SSS.ToString("n"), PHIC.ToString("n"), PAGIBIG.ToString("n"),
                                               SBU_CHARGES.ToString("n"), NET_PAY.ToString("n"), BRANCH_CODE, payroll.ToString("MMMM dd, yyyy"), period, COMPANY)

                        End With
                    Next
                End If
            End Using

            Dim rds_DTR As New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt_NetPay)
            ReportV_NetPay.LocalReport.DataSources.Add(rds_DTR)
            ReportV_NetPay.RefreshReport()

        Catch ex As Exception
            Log_Report(ex.ToString)
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


End Class