Public Class frmReport

    Private allowCoolMove As Boolean = False
    Private myCoolPoint As New Point

    Private Sub frmReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PopulateComboBox(PaydateNet_ComboB, "PAYROLL_PAYOUT", "PAYDATE")
        PopulateComboBox(PaydateCom_Combo, "PAYROLL_PAYOUT", "PAYDATE")
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
                                        where HO_CATEGORY <> 'PGC Head Office' and A.PAYDATE  = '{paydatee}' ORDER BY COMPANY, BRANCH_CODE, FULLNAME ASC"

            End If
            Using ds As DataSet = LoadSQL(mysqll, "PAYROLL_PAYOUT")

                If ds.Tables(0).Rows.Count > 0 Then

                    For Each dr In ds.Tables(0).Rows
                        With dr

                            Dim dateStarted As DateTime = .Item("DATE_STARTED")
                            Dim EMP_NO As String = .Item("EMP_NO")

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

        RptViewer_Count.LocalReport.DataSources.Clear()

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
                .Columns.Add("M_DALTONP")
                .Columns.Add("M_PHOTO")
                .Columns.Add("M_DAVAOP")
                .Columns.Add("M_PERFECOM")
                .Columns.Add("D_DALTONP")
                .Columns.Add("D_PHOTO")
                .Columns.Add("D_DAVAOP")
                .Columns.Add("D_PERFECOM")
                .Columns.Add("DR_Dalton")
                .Columns.Add("DR_Photo")
                .Columns.Add("DR_House")
                .Columns.Add("ConDalton")
                .Columns.Add("ConPhoto")
                .Columns.Add("ConHouse")
                .Columns.Add("LEASINGBR")
            End With

            Dim DALTON_BB, DALTON_HO, GENSANPERFECT_BB, GENSANPERFECT_HO, JRPHOTO_BB, JRPHOTO_HO, DAVAOP_BB, DAVAOP_HO, PERFECOM_BB,
                PERFECOM_HO, G3_BB, G3_HO, Seven11_ROX_BB, Seven11_ROX_HO, Seven11_POL_BB, Seven11_POL_HO, COMI_BB, COMI_HO, PBA_BB,
                PBA_HO, KTV_BB, KTV_HO, WAVE_BB, WAVE_HO, PGC, LEASING, LEASING_BR, DALTON_BR, GENSANPERFECT_BR, DAVAOP_BR, PERFECOM_BR, G3_BR,
                Seven11_BR, COMI_TO_FUJI_BR, M_DALTONP, M_PHOTO, M_DAVAOP, M_PERFECOM, D_DALTONP, D_PHOTO, D_DAVAOP, D_PERFECOM,
                DR_Dalton, DR_Photo, DR_House, ConDalton, ConPhoto, ConHouse As Integer

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
            M_DALTONP = GetModify_Reports("M_DALTONP")
            M_PHOTO = GetModify_Reports("M_PHOTO")
            M_DAVAOP = GetModify_Reports("M_DAVAOP")
            M_PERFECOM = GetModify_Reports("M_PERFECOM")
            D_DALTONP = GetModify_Reports("D_DALTONP")
            D_PHOTO = GetModify_Reports("D_PHOTO")
            D_DAVAOP = GetModify_Reports("D_DAVAOP")
            D_PERFECOM = GetModify_Reports("D_PERFECOM")
            DR_Dalton = GetModify_Reports("DR_Dalton")
            DR_Photo = GetModify_Reports("DR_Photo")
            DR_House = GetModify_Reports("DR_House")
            ConDalton = GetModify_Reports("ConDalton")
            ConPhoto = GetModify_Reports("ConPhoto")
            ConHouse = GetModify_Reports("ConHouse")
            LEASING_BR = GetModify_Reports("LEASINGBR")

            dt_Common.Rows.Add(DALTON_BB, DALTON_HO, GENSANPERFECT_BB, GENSANPERFECT_HO, JRPHOTO_BB, JRPHOTO_HO, DAVAOP_BB, DAVAOP_HO, PERFECOM_BB,
                               PERFECOM_HO, G3_BB, G3_HO, Seven11_ROX_BB, Seven11_ROX_HO, Seven11_POL_BB, Seven11_POL_HO, COMI_BB, COMI_HO, PBA_BB,
                               PBA_HO, KTV_BB, KTV_HO, WAVE_BB, WAVE_HO, PGC, LEASING, DALTON_BR, GENSANPERFECT_BR, DAVAOP_BR, PERFECOM_BR,
                               G3_BR, Seven11_BR, COMI_TO_FUJI_BR, M_DALTONP, M_PHOTO, M_DAVAOP, M_PERFECOM, D_DALTONP, D_PHOTO, D_DAVAOP, D_PERFECOM,
                               DR_Dalton, DR_Photo, DR_House, ConDalton, ConPhoto, ConHouse, LEASING_BR)

            Dim rds_DTR As New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt_Common)
            RptViewer_Count.LocalReport.DataSources.Add(rds_DTR)
            RptViewer_Count.RefreshReport()

        Catch ex As Exception
            Log_Report(ex.ToString)
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub SavePercentage_Common()

        Dim DALTON_BB, DALTON_HO, GENSANPERFECT_BB, GENSANPERFECT_HO, JRPHOTO_BB, JRPHOTO_HO, DAVAOP_BB, DAVAOP_HO, PERFECOM_BB,
            PERFECOM_HO, G3_BB, G3_HO, Seven11_ROX_BB, Seven11_ROX_HO, Seven11_POL_BB, Seven11_POL_HO, COMI_BB, COMI_HO, PBA_BB,
            PBA_HO, KTV_BB, KTV_HO, WAVE_BB, WAVE_HO, PGC, LEASING, LEASING_BR, DALTON_BR, GENSANPERFECT_BR, DAVAOP_BR, PERFECOM_BR, G3_BR,
            Seven11_BR, COMI_TO_FUJI_BR, M_DALTONP, M_PHOTO, M_DAVAOP, M_PERFECOM, D_DALTONP, D_PHOTO, D_DAVAOP, D_PERFECOM,
            DR_Dalton, DR_Photo, DR_House, ConDalton, ConPhoto, LEASING_P As Integer

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

        LEASING_BR = GetModify_Reports("LEASINGBR")
        LEASING_P = GetModify_Reports("LEASINGP")

        Dim DALTON_EMP = DALTON_BB + DALTON_HO
        Dim GENSANP_EMP = GENSANPERFECT_BB + GENSANPERFECT_HO
        Dim PHOTO_EMP = JRPHOTO_BB + JRPHOTO_HO
        Dim DAVAOP_EMP = DAVAOP_BB + DAVAOP_HO
        Dim PERFECOM_EMP = PERFECOM_BB + PERFECOM_HO
        Dim G3_EMP = G3_BB + G3_HO
        Dim SEVENROX_EMP = Seven11_ROX_BB + Seven11_ROX_HO
        Dim SEVENPOL_EMP = Seven11_POL_BB + Seven11_POL_HO
        Dim COMI_EMP = COMI_BB + COMI_HO
        Dim PBA_EMP = PBA_BB + PBA_HO
        Dim KTV_EMP = KTV_BB + KTV_HO
        Dim WAVE_EMP = WAVE_BB + WAVE_HO

        Dim TOTAL_EE = DALTON_EMP + GENSANP_EMP + PHOTO_EMP + DAVAOP_EMP + PERFECOM_EMP + G3_EMP +
                    SEVENROX_EMP + SEVENPOL_EMP + COMI_EMP + PBA_EMP + KTV_EMP + WAVE_EMP

        Dim TOTAL_BB = DALTON_BR + GENSANPERFECT_BR + DAVAOP_BR + PERFECOM_BR + G3_BR + Seven11_BR +
                    COMI_TO_FUJI_BR + LEASING_BR

        '============================ EMPLOYEE PERCENTAGE ==========================
        Dim DALTON_EMP_P As Decimal = (DALTON_EMP / TOTAL_EE) * 100
        Dim GENSAN_PHOTO_EMP_P As Decimal = ((GENSANP_EMP + PHOTO_EMP) / TOTAL_EE) * 100
        Dim DAVAOP_EMP_P As Decimal = (DAVAOP_EMP / TOTAL_EE) * 100
        Dim PERFECOM_EMP_P As Decimal = (PERFECOM_EMP / TOTAL_EE) * 100
        Dim G3_EMP_P As Decimal = (G3_EMP / TOTAL_EE) * 100
        Dim SEVEN11_EMP_P As Decimal = ((SEVENROX_EMP + SEVENPOL_EMP) / TOTAL_EE) * 100
        Dim COMI_TO_FUJI_EMP_P As Decimal = ((COMI_EMP + PBA_EMP + KTV_EMP + WAVE_EMP) / TOTAL_EE) * 100

        '============================ BRANCH PERCENTAGE ==========================
        Dim DALTON_BR_P = (DALTON_BR / TOTAL_BB) * 100
        Dim GENSAN_BR_P = (GENSANPERFECT_BR / TOTAL_BB) * 100
        Dim DAVAOP_BR_P = (DAVAOP_BR / TOTAL_BB) * 100
        Dim PERFECOM_BR_P = (PERFECOM_BR / TOTAL_BB) * 100
        Dim G3_BR_P = (G3_BR / TOTAL_BB) * 100
        Dim Seven11_BR_P = (Seven11_BR / TOTAL_BB) * 100
        Dim COMI_TO_FUJI_BR_P = (COMI_TO_FUJI_BR / TOTAL_BB) * 100
        Dim LEASING_BR_P = (LEASING_BR / TOTAL_BB) * 100

        '============================ MARKETING PERCENTAGE ==========================
        M_DALTONP = GetModify_Reports("M_DALTONP")
        M_PHOTO = GetModify_Reports("M_PHOTO")
        M_DAVAOP = GetModify_Reports("M_DAVAOP")
        M_PERFECOM = GetModify_Reports("M_PERFECOM")

        '============================ DYU PERCENTAGE ==========================
        D_DALTONP = GetModify_Reports("D_DALTONP")
        D_PHOTO = GetModify_Reports("D_PHOTO")
        D_DAVAOP = GetModify_Reports("D_DAVAOP")
        D_PERFECOM = GetModify_Reports("D_PERFECOM")

        '============================ PHOTO_PERFECT PERCENTAGE ==========================
        Dim sum_3 As Integer = GENSANPERFECT_BR + DAVAOP_BR + PERFECOM_BR

        Dim GENSAN_PHOTO_PERFECT_P = (GENSANPERFECT_BR / sum_3) * 100
        Dim DAVAOP_PHOTO_PERFECT_P = (DAVAOP_BR / sum_3) * 100
        Dim PERFECOM_PHOTO_PERFECT_P = (PERFECOM_BR / sum_3) * 100

        '============================ PHOTO_GHS_3G PERCENTAGE ==========================
        Dim sum_4 As Integer = GENSANPERFECT_BR + DAVAOP_BR + G3_BR + COMI_TO_FUJI_BR

        Dim GENSAN_PHOTO_GHS_3G_P = (GENSANPERFECT_BR / sum_4) * 100
        Dim DAVAOP_PHOTO_GHS_3GT_P = (DAVAOP_BR / sum_4) * 100
        Dim G3_PHOTO_GHS_3G_P = (G3_BR / sum_4) * 100
        Dim COMI_TO_FUJI_PHOTO_GHS_3G_P = (COMI_TO_FUJI_BR / sum_4) * 100

        '============================ PERFECOM_LEASING_711 PERCENTAGE ==========================
        Dim sum_5 As Integer = PERFECOM_BR + Seven11_BR + LEASING_BR

        Dim PERFECOM_PL7_P = (PERFECOM_BR / sum_5) * 100
        Dim SEVEN11_PL7_P = (Seven11_BR / sum_5) * 100
        Dim LEASING_PL7_P = (LEASING_BR / sum_5) * 100

        '============================ DRIVER PERCENTAGE ========================== 
        DR_Dalton = GetModify_Reports("DR_Dalton")
        DR_Photo = GetModify_Reports("DR_Photo")
        DR_House = GetModify_Reports("DR_House")

        Dim sum_driver As Integer = DR_Dalton + DR_Photo + DR_House

        Dim DR_Dalton_P = (DR_Dalton / sum_driver) * 100
        Dim DR_Photo_P = (DR_Photo / sum_driver) * 100
        Dim DR_House_P = (DR_House / sum_driver) * 100

        '============================ CONSTRUCTION PERCENTAGE ==========================  
        ConDalton = GetModify_Reports("ConDalton")
        ConPhoto = GetModify_Reports("ConPhoto")

        Dim ConDalton_P = (ConDalton / sum_driver) * 100
        Dim ConPhoto_P = (ConPhoto / sum_driver) * 100

        Dim DTR_DATON_P = GetModify_Reports("DTR_Dalton")
        Dim DTR_PHOTO_P = GetModify_Reports("DTR_Photo")

        Replacing("PAYROLL_PERCENTAGEE")

        Save_PERCENTAGE(DALTON_EMP_P, GENSAN_PHOTO_EMP_P, DAVAOP_EMP_P, PERFECOM_EMP_P, G3_EMP_P, SEVEN11_EMP_P, COMI_TO_FUJI_EMP_P, 0, 0, "EMPLOYEE")
        Save_PERCENTAGE(DALTON_BR_P, GENSAN_BR_P, DAVAOP_BR_P, PERFECOM_BR_P, G3_BR_P, Seven11_BR_P, COMI_TO_FUJI_BR_P, 0, LEASING_BR_P, "BRANCH")
        Save_PERCENTAGE(M_DALTONP, M_PHOTO, M_DAVAOP, M_PERFECOM, 0, 0, 0, 0, 0, "MARKETING")
        Save_PERCENTAGE(0, GENSAN_PHOTO_PERFECT_P, DAVAOP_PHOTO_PERFECT_P, PERFECOM_PHOTO_PERFECT_P, 0, 0, 0, 0, 0, "PHOTO/PERFECOM")
        Save_PERCENTAGE(0, GENSAN_PHOTO_GHS_3G_P, DAVAOP_PHOTO_GHS_3GT_P, 0, G3_PHOTO_GHS_3G_P, 0, COMI_TO_FUJI_PHOTO_GHS_3G_P, 0, 0, "PHOTO/GHS/3G")
        Save_PERCENTAGE(0, 0, 0, PERFECOM_PL7_P, 0, SEVEN11_PL7_P, 0, 0, LEASING_PL7_P, "PERFECOM/LEASING/7ELEVEN")
        Save_PERCENTAGE(D_DALTONP, D_PHOTO, D_DAVAOP, D_PERFECOM, 0, 0, 0, 0, 0, "DYU")
        Save_PERCENTAGE(DR_Dalton_P, DR_Photo_P, 0, 0, 0, 0, 0, DR_House_P, 0, "DRIVER")
        Save_PERCENTAGE(ConDalton_P, ConPhoto_P, 0, 0, 0, 0, 0, 0, 0, "CONSTRUCTION")
        Save_PERCENTAGE(DTR_DATON_P, DTR_PHOTO_P, 0, 0, 0, 0, 0, 0, 0, "DTR")
        Save_PERCENTAGE(0, 0, 0, 0, 0, 0, 0, 0, LEASING_P, "LEASING")

    End Sub

    Private Sub PrevCommon_BTN_Click(sender As Object, e As EventArgs) Handles PrevCommon_BTN.Click
        LoadCommonPercentage_Print()
    End Sub


    Public Sub LoadCommonPercentage_Print()

        RptViewer_Common.LocalReport.DataSources.Clear()

        Try

            Dim dt_CommonDis As New DataTable()
            With dt_CommonDis
                .Columns.Add("FULLNAME")
                .Columns.Add("COMMON_CATEGORY")
                .Columns.Add("NETPAY")
                .Columns.Add("DALTON")
                .Columns.Add("PHOTO")
                .Columns.Add("DAVAOP")
                .Columns.Add("PERFECOM")
                .Columns.Add("G3")
                .Columns.Add("Seven11")
                .Columns.Add("COMI_TO_FUJI")
                .Columns.Add("HOUSEHOLD")
                .Columns.Add("LEASING")
                .Columns.Add("PAYDATE")
            End With

            Dim mysqll As String = $"Select * From PAYROLL_EMPLOYEE A 
                                        INNER JOIN PAYROLL_PERCENTAGEE B ON B.CATEGORY = A.COMMON_CATEGORY
                                        INNER JOIN PAYROLL_PAYOUT C ON A.BIO_NO = C.BIOMETRIC_ID
                                        where HO_CATEGORY = 'PGC Head Office' AND PAYDATE = '{PaydateCom_Combo.Text}' ORDER BY FULLNAME ASC"


            Using ds As DataSet = LoadSQL(mysqll, "PAYROLL_EMPLOYEE")
                If ds.Tables(0).Rows.Count > 0 Then
                    For Each dr In ds.Tables(0).Rows
                        With dr

                            Dim PAYROLL As DateTime = PaydateCom_Combo.Text

                            '============================= NAME AND ATTENDANCE ============================  
                            Dim namee As String = .Item("FULLNAME")
                            Dim CATEGORY As String = .Item("CATEGORY")
                            Dim NET_PAY As Double = .Item("NET_PAY")
                            Dim DALTON As Double = .Item("DALTON")
                            Dim PHOTO As Double = .Item("PHOTO")
                            Dim DAVAOP As Double = .Item("DAVAOP")
                            Dim PERFECOM As Double = .Item("PERFECOM")
                            Dim G3 As Double = .Item("G3")
                            Dim Seven11 As Double = .Item("Seven11")
                            Dim COMI_TO_FUJI As Double = .Item("COMI_TO_FUJI")
                            Dim HOUSEHOLD As Double = .Item("HOUSEHOLD")
                            Dim LEASING As Double = .Item("LEASING")

                            dt_CommonDis.Rows.Add(namee, CATEGORY, NET_PAY.ToString("n"), DALTON, PHOTO, DAVAOP,
                                               PERFECOM, G3, Seven11, COMI_TO_FUJI, HOUSEHOLD, LEASING, Format(PAYROLL, "MMMM dd, yyyy").ToUpper())

                        End With
                    Next
                End If
            End Using

            Dim rds_common As New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt_CommonDis)

            Dim dt_ComLeasingDis As New DataTable()
            With dt_ComLeasingDis
                .Columns.Add("FULLNAME_L")
                .Columns.Add("COMMON_CATEGORY_L")
                .Columns.Add("NETPAY_L")
                .Columns.Add("DALTON_L")
                .Columns.Add("PHOTO_L")
                .Columns.Add("DAVAOP_L")
                .Columns.Add("PERFECOM_L")
                .Columns.Add("G3_L")
                .Columns.Add("Seven11_L")
                .Columns.Add("COMI_TO_FUJI_L")
                .Columns.Add("HOUSEHOLD_L")
                .Columns.Add("LEASING_L")
            End With

            Dim mysql As String = $"Select * From PAYROLL_EMPLOYEE A 
                                        LEFT JOIN PAYROLL_PERCENTAGEE B ON B.CATEGORY = A.COMMON_CATEGORY
                                        INNER JOIN PAYROLL_PAYOUT C ON A.BIO_NO = C.BIOMETRIC_ID
                                        where HO_CATEGORY IN ('Construction', 'Leasing Admin Office') AND PAYDATE = '{PaydateCom_Combo.Text}' ORDER BY FULLNAME ASC"

            Using dss As DataSet = LoadSQL(mysql, "PAYROLL_EMPLOYEE")
                If dss.Tables(0).Rows.Count > 0 Then
                    For Each drR In dss.Tables(0).Rows
                        With drR

                            Dim dateStarted As DateTime = PaydateCom_Combo.Text

                            '============================= NAME AND ATTENDANCE ============================  
                            Dim namee As String = .Item("FULLNAME")
                            Dim CATEGORY As String = .Item("CATEGORY")
                            Dim NET_PAY As Double = .Item("NET_PAY")
                            Dim DALTON As Double = .Item("DALTON")
                            Dim PHOTO As Double = .Item("PHOTO")
                            Dim DAVAOP As Double = .Item("DAVAOP")
                            Dim PERFECOM As Double = .Item("PERFECOM")
                            Dim G3 As Double = .Item("G3")
                            Dim Seven11 As Double = .Item("Seven11")
                            Dim COMI_TO_FUJI As Double = .Item("COMI_TO_FUJI")
                            Dim HOUSEHOLD As Double = .Item("HOUSEHOLD")
                            Dim LEASING As Double = .Item("LEASING")

                            dt_ComLeasingDis.Rows.Add(namee, CATEGORY, NET_PAY.ToString("n"), DALTON, PHOTO, DAVAOP,
                                               PERFECOM, G3, Seven11, COMI_TO_FUJI, HOUSEHOLD, LEASING)

                        End With
                    Next
                End If
            End Using

            Dim rds_leasing As New Microsoft.Reporting.WinForms.ReportDataSource("DataSet2", dt_ComLeasingDis)
            RptViewer_Common.LocalReport.DataSources.Add(rds_common)
            RptViewer_Common.LocalReport.DataSources.Add(rds_leasing)
            RptViewer_Common.RefreshReport()

        Catch ex As Exception
            Log_Report(ex.ToString)
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ComPrev_BTN_Click(sender As Object, e As EventArgs) Handles ComPrev_BTN.Click
        SavePercentage_Common()
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
        GetModify_Report(M_DaltonP_TXT, M_Photo_TXT, M_DavaoP_TXT, M_Perfecom_TXT, D_DaltonP_TXT, D_Photo_TXT, D_DavaoP_TXT, D_Perfecom_TXT,
                                DR_Dalton_TXT, DR_Photo_TXT, DR_House_TXT, ConDalton_TXT, ConPhoto_TXT, ConHouse_TXT, LeasingBR_TXT, DTR_Dalton_TXT, DTR_Photo_TXT, LeasingP_TXT)
        Modify_Panel.Visible = True
        Modify_Panel.Location = New Point(ClientSize.Width / 2 - Modify_Panel.Size.Width / 2, ClientSize.Height / 2 - Modify_Panel.Size.Height / 2)
    End Sub

    Private Sub Label14_Click(sender As Object, e As EventArgs) Handles Label14.Click
        Modify_Panel.Visible = False
    End Sub

    Private Sub Save_BTN_Click(sender As Object, e As EventArgs) Handles Save_BTN.Click

        Save_Marketing_DYU(M_DaltonP_TXT.Text, M_Photo_TXT.Text, M_DavaoP_TXT.Text, M_Perfecom_TXT.Text,
                           D_DaltonP_TXT.Text, D_Photo_TXT.Text, D_DavaoP_TXT.Text, D_Perfecom_TXT.Text,
                           DR_Dalton_TXT.Text, DR_Photo_TXT.Text, DR_House_TXT.Text, ConDalton_TXT.Text,
                           ConPhoto_TXT.Text, ConHouse_TXT.Text, LeasingBR_TXT.Text, DTR_Dalton_TXT.Text,
                           DTR_Photo_TXT.Text, LeasingP_TXT.Text)

        Modify_Panel.Visible = False

    End Sub

    Private Sub Clear_BTN_Click(sender As Object, e As EventArgs) Handles Clear_BTN.Click

        M_DaltonP_TXT.Clear()
        M_Photo_TXT.Clear()
        M_DavaoP_TXT.Clear()
        M_Perfecom_TXT.Clear()
        D_DaltonP_TXT.Clear()
        D_Photo_TXT.Clear()
        D_DavaoP_TXT.Clear()
        D_Perfecom_TXT.Clear()
        DR_Dalton_TXT.Clear()
        DR_Photo_TXT.Clear()
        DR_House_TXT.Clear()
        ConDalton_TXT.Clear()
        ConPhoto_TXT.Clear()
        ConHouse_TXT.Clear()
        LeasingBR_TXT.Clear()
        LeasingP_TXT.Clear()

    End Sub

    Private Sub Modify_Panel_MouseDown(sender As Object, e As MouseEventArgs) Handles Modify_Panel.MouseDown
        allowCoolMove = True
        myCoolPoint = New Point(e.X, e.Y)
        Cursor = Cursors.SizeAll
    End Sub

    Private Sub Modify_Panel_MouseMove(sender As Object, e As MouseEventArgs) Handles Modify_Panel.MouseMove
        If allowCoolMove = True Then
            Modify_Panel.Location = New Point(Modify_Panel.Location.X + e.X - myCoolPoint.X, Modify_Panel.Location.Y + e.Y - myCoolPoint.Y)
        End If
    End Sub

    Private Sub Modify_Panel_MouseUp(sender As Object, e As MouseEventArgs) Handles Modify_Panel.MouseUp
        allowCoolMove = False
        Cursor = Cursors.Default
    End Sub

End Class