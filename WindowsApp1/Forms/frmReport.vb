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
                .Columns.Add("HO_CATEGORY")
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
                            Dim HO_CATEGORY As String = IIf(IsDBNull(.Item("HO_CATEGORY")), "", .Item("HO_CATEGORY"))

                            dt_NetPay.Rows.Add(EMP_NO, namee, BASIC.ToString("n"), OVERTIME.ToString("n"), HOLIDAY.ToString("n"), N_DIFF.ToString("n"),
                                               PI_ECOLA_SIL.ToString("n"), TARDINESS.ToString("n"), SSS.ToString("n"), PHIC.ToString("n"), PAGIBIG.ToString("n"),
                                               SBU_CHARGES.ToString("n"), NET_PAY.ToString("n"), BRANCH_CODE, payroll.ToString("MMMM dd, yyyy"), period, COMPANY, HO_CATEGORY)

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

    Public Sub LoadCommon_Print()

        RptViewer_Common.LocalReport.DataSources.Clear()

        Dim mysqll As String = ""

        Try
            Dim all_in As New reports.CommonDataTable

            Dim dt_Common As New DataTable()
            With dt_Common
                .Columns.Add("DALTON_BB")
                .Columns.Add("DALTON_HO")
                .Columns.Add("GENSANPERFECT_BB")
                .Columns.Add("GENSANPERFECT_HO")
                .Columns.Add("JRPHOTO_BB")
                .Columns.Add("JRPHOTO_HO")
                .Columns.Add("DAVAOP_BB")
                .Columns.Add("DAVAOP_HO")
                .Columns.Add("PERFECOM_BB")
                .Columns.Add("PERFECOM_HO")
                .Columns.Add("G3_BB")
                .Columns.Add("G3_HO")
                .Columns.Add("Seven11_ROX_BB")
                .Columns.Add("Seven11_ROX_HO")
                .Columns.Add("Seven11_POL_BB")
                .Columns.Add("Seven11_POL_HO")
                .Columns.Add("COMI_BB")
                .Columns.Add("COMI_HO")
                .Columns.Add("PBA_BB")
                .Columns.Add("PBA_HO")
                .Columns.Add("KTV_BB")
                .Columns.Add("KTV_HO")
                .Columns.Add("WAVE_BB")
                .Columns.Add("WAVE_HO")
                .Columns.Add("PGC")
                .Columns.Add("LEASING")
                .Columns.Add("DALTON_BR")
                .Columns.Add("GENSANPERFECT_BR")
                .Columns.Add("DAVAOP_BR")
                .Columns.Add("PERFECOM_BR")
                .Columns.Add("G3_BR")
                .Columns.Add("Seven11_BR")
                .Columns.Add("COMI_TO_FUJI_BR")
            End With

            Dim DALTON_BB, DALTON_HO, GENSANPERFECT_BB, GENSANPERFECT_HO, JRPHOTO_BB, JRPHOTO_HO, DAVAOP_BB, DAVAOP_HO, PERFECOM_BB,
                PERFECOM_HO, G3_BB, G3_HO, Seven11_ROX_BB, Seven11_ROX_HO, Seven11_POL_BB, Seven11_POL_HO, COMI_BB, COMI_HO, PBA_BB,
                PBA_HO, KTV_BB, KTV_HO, WAVE_BB, WAVE_HO, PGC, LEASING, DALTON_BR, GENSANPERFECT_BR, DAVAOP_BR, PERFECOM_BR, G3_BR,
                Seven11_BR, COMI_TO_FUJI_BR As Integer

            DALTON_BB = GetCount_Common("where company = 'DALTON'")
            DALTON_HO = GetCount_Common("where UPPER(HO_CATEGORY) LIKE UPPER('%Dalton%')")
            GENSANPERFECT_BB = GetCount_Common("where branch_code IN ('ROG','ROX','FINEPIX','GMA','DIG','SNP','SMD')")
            GENSANPERFECT_HO = Nothing
            JRPHOTO_BB = Nothing
            JRPHOTO_HO = Nothing
            DAVAOP_BB = GetCount_Common("where branch_code IN ('SMG','KCG','ACM','TAC')")
            DAVAOP_HO = Nothing
            PERFECOM_BB = GetCount_Common("where company = 'PERFECOM'")
            PERFECOM_HO = GetCount_Common("where company = 'HEAD OFFICE' AND UPPER(HO_CATEGORY) LIKE UPPER('%Perfecom%')")
            G3_BB = GetCount_Common("where branch_code = '3G'")
            G3_HO = Nothing
            Seven11_ROX_BB = GetCount_Common("where branch_code = '711-ROX'")
            Seven11_ROX_HO = Nothing
            Seven11_POL_BB = GetCount_Common("where branch_code = '711-POL'")
            Seven11_POL_HO = Nothing
            COMI_BB = GetCount_Common("where branch_code = 'COMI'")
            COMI_HO = Nothing
            PBA_BB = GetCount_Common("where branch_code = 'PBA'")
            PBA_HO = Nothing
            KTV_BB = GetCount_Common("where branch_code = 'KTV'")
            KTV_HO = Nothing
            WAVE_BB = GetCount_Common("where branch_code = 'WAVE'")
            WAVE_HO = Nothing
            PGC = GetCount_Common("where ho_category = 'PGC Head Office'")
            LEASING = GetCount_Common("where ho_category IN ('Leasing Admin Office','Construction')")
            DALTON_BR = GetDistinctCount("branch_code", "where company = 'DALTON'")
            GENSANPERFECT_BR = GetDistinctCount("branch_code", "where company = 'PHOTO'")
            DAVAOP_BR = GetDistinctCount("branch_code", "where branch_code IN ('SMG','KCG','ACM','TAC')")
            PERFECOM_BR = GetDistinctCount("branch_code", "where company = 'PERFECOM'")
            G3_BR = GetDistinctCount("branch_code", "where branch_code = '3G'")
            Seven11_BR = GetDistinctCount("branch_code", "where branch_code IN ('711-ROX','711-POL')")
            COMI_TO_FUJI_BR = GetDistinctCount("branch_code", "where branch_code IN ('COMI','PBA','KTV','WAVE')")

            dt_Common.Rows.Add(DALTON_BB, DALTON_HO, GENSANPERFECT_BB, GENSANPERFECT_HO, JRPHOTO_BB, JRPHOTO_HO, DAVAOP_BB, DAVAOP_HO, PERFECOM_BB,
                               PERFECOM_HO, G3_BB, G3_HO, Seven11_ROX_BB, Seven11_ROX_HO, Seven11_POL_BB, Seven11_POL_HO, COMI_BB, COMI_HO, PBA_BB,
                               PBA_HO, KTV_BB, KTV_HO, WAVE_BB, WAVE_HO, PGC, LEASING, DALTON_BR, GENSANPERFECT_BR, DAVAOP_BR, PERFECOM_BR,
                               G3_BR, Seven11_BR, COMI_TO_FUJI_BR)

            Dim rds_DTR As New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt_Common)
            RptViewer_Common.LocalReport.DataSources.Add(rds_DTR)
            RptViewer_Common.RefreshReport()

        Catch ex As Exception
            Log_Report(ex.ToString)
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ComPrev_BTN_Click(sender As Object, e As EventArgs) Handles ComPrev_BTN.Click
        LoadCommon_Print()
    End Sub

    Private Sub DaltonP_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles M_Photo_TXT.KeyPress, M_Perfecom_TXT.KeyPress, M_DavaoP_TXT.KeyPress, M_DaltonP_TXT.KeyPress

        If e.KeyChar <> ChrW(Keys.Back) Then

            If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        End If

    End Sub

    Private Sub Modify_BTN_Click(sender As Object, e As EventArgs) Handles Modify_BTN.Click
        Modify_Panel.Visible = True
    End Sub

    Private Sub Label14_Click(sender As Object, e As EventArgs) Handles Label14.Click
        Modify_Panel.Visible = False
    End Sub

End Class