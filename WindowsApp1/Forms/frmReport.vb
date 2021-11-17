

Public Class frmReport

    Private allowCoolMove As Boolean = False
    Private myCoolPoint As New Point
    Dim PlusS As String = ""

    Private Sub frmReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PopulateComboBox(PaydateNet_ComboB, "PAYROLL_PAYOUT", "PAYDATE")
        PopulateComboBox(PaydateCom_Combo, "PAYROLL_PAYOUT", "PAYDATE")
        PopulateComboBox(SumPaydate_Combo, "PAYROLL_PAYOUT", "PAYDATE")
        Lists_SBU(SBU_LV)
    End Sub

    Private Sub SearchSBU_BTN_Click(sender As Object, e As EventArgs) Handles SearchSBU_BTN.Click
        Lists_SBU(SBU_LV, SearchSBU_TXT.Text)
    End Sub

    Private Sub SearchSBU_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles SearchSBU_TXT.KeyPress
        If IsEnter(e) Then SearchSBU_BTN.PerformClick()
    End Sub


    Public Sub LoadNet_Print(mysqll As String)

        ReportV_NetPay.LocalReport.DataSources.Clear()

        Dim paydatee As String = PaydateNet_ComboB.SelectedItem
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
                .Columns.Add("PLUS")
            End With

            Using ds As DataSet = LoadSQL(mysqll, "PAYROLL_PAYOUT")

                If ds.Tables(0).Rows.Count > 0 Then

                    For Each dr In ds.Tables(0).Rows
                        With dr
                            Dim dateStarted As DateTime = .Item("DATE_STARTED")
                            Dim EMP_NO As String = IIf(IsDBNull(.Item("EMP_NO")), "", .Item("EMP_NO"))

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
                            Dim BRANCH_CODE As String = IIf(.Item("BRANCH_CODE") = "", .Item("HO_CATEGORY"), .Item("BRANCHNAME"))
                            Dim COMPANY As String = .Item("COMPANY")
                            Dim HO_CATEGORY As String = IIf(IsDBNull(.Item("HO_CATEGORY")), "", .Item("HO_CATEGORY"))

                            If COMPANY = "DALTON" Then
                                BRANCH_CODE = IIf(.Item("BRANCH_CODE") = "", .Item("HO_CATEGORY"), TitleCase(.Item("COMPANY")) & "-" & .Item("BRANCHNAME"))
                            End If

                            If HO_CATEGORY = "GHS/P&G UY Admin Office" Or HO_CATEGORY = "GHS/P&G UY Admin Operation" Then
                                COMPANY = "P&G UY"
                                BRANCH_CODE = HO_CATEGORY

                            ElseIf HO_CATEGORY.Contains("Dalton") Then
                                COMPANY = "DALTON"
                                BRANCH_CODE = HO_CATEGORY

                            ElseIf HO_CATEGORY.Contains("Photo") Or HO_CATEGORY.Contains("PGC") Then
                                COMPANY = "PHOTO"
                                BRANCH_CODE = HO_CATEGORY
                            End If

                            If PlusS = "PGC" Then
                                COMPANY = "PGC"
                                BRANCH_CODE = HO_CATEGORY
                            End If

                            Dim tempPlus As String = PlusS

                            If PlusS = "DAVAO PERFECT" Or PlusS = "GENSAN PERFECT" And HO_CATEGORY = "" Then BRANCH_CODE = "Perfect" & "-" & .Item("BRANCHNAME")
                            If PlusS = "JR PHOTO" Then BRANCH_CODE = "JR Photo" & "-" & .Item("BRANCHNAME")
                            If COMPANY = "PHOTO" Then tempPlus = $"{COMPANY}({PlusS})"

                            dt_NetPay.Rows.Add(EMP_NO, namee, BASIC.ToString("n"), OVERTIME.ToString("n"), HOLIDAY.ToString("n"), N_DIFF.ToString("n"),
                                               PI_ECOLA_SIL.ToString("n"), TARDINESS.ToString("n"), SSS.ToString("n"), PHIC.ToString("n"), PAGIBIG.ToString("n"),
                                               SBU_CHARGES.ToString("n"), NET_PAY.ToString("n"), BRANCH_CODE, payroll.ToString("MMMM dd, yyyy"), period, COMPANY,
                                               HO_CATEGORY, tempPlus)

                        End With
                    Next

                    Dim TOTAL_EMP As Integer = GetOVERALL_COUNT("ID", paydatee)
                    Dim TOTAL_BASIC As Double = GetOVERALL_SUM("TOTAL_BASIC", paydatee)
                    Dim TOTAL_OT As Double = GetOVERALL_SUM("TOTAL_OVERTIME", paydatee)
                    Dim TOTAL_HOLIDAY As Double = GetOVERALL_SUM("TOTAL_HOLIDAY", paydatee)
                    Dim TOTAL_NDIFF As Double = GetOVERALL_SUM("TOTAL_NIGHT_RATE", paydatee)
                    Dim TOTAL_PI_ECOLA_SIL As Double = GetOVERALL_SUM("TOTAL_ALLOWANCE", paydatee)
                    Dim TOTAL_TARDINESS As Double = GetOVERALL_SUM("TOTAL_LATE_UT", paydatee)
                    Dim TOTAL_SSS As Double = GetOVERALL_SUM("SSS_COMP", paydatee)
                    Dim TOTAL_PHIC As Double = GetOVERALL_SUM("PHILHEALTH_COMP", paydatee)
                    Dim TOTAL_PAGIBIG As Double = GetOVERALL_SUM("PAGIBIG_COMP", paydatee)
                    Dim TOTAL_SBU_CHARGES As Double = GetOVERALL_SUM("TOTAL_DEDUCTION", paydatee)
                    Dim TOTAL_NET_PAY As Double = GetOVERALL_SUM("NET_PAY", paydatee)

                    Dim paramList As New List(Of Microsoft.Reporting.WinForms.ReportParameter) From {
                    New Microsoft.Reporting.WinForms.ReportParameter("paramEmployees", TOTAL_EMP),
                    New Microsoft.Reporting.WinForms.ReportParameter("paramBasic", TOTAL_BASIC.ToString(”N”)),
                    New Microsoft.Reporting.WinForms.ReportParameter("paramOvertime", TOTAL_OT.ToString(”N”)),
                    New Microsoft.Reporting.WinForms.ReportParameter("paramHoliday", TOTAL_HOLIDAY.ToString(”N”)),
                    New Microsoft.Reporting.WinForms.ReportParameter("paramNDiff", TOTAL_NDIFF.ToString(”N”)),
                    New Microsoft.Reporting.WinForms.ReportParameter("paramPI_Ecola_SIL", TOTAL_PI_ECOLA_SIL.ToString(”N”)),
                    New Microsoft.Reporting.WinForms.ReportParameter("paramTardiness", TOTAL_TARDINESS.ToString(”N”)),
                    New Microsoft.Reporting.WinForms.ReportParameter("paramSSS", TOTAL_SSS.ToString(”N”)),
                    New Microsoft.Reporting.WinForms.ReportParameter("paramPHIC", TOTAL_PHIC.ToString(”N”)),
                    New Microsoft.Reporting.WinForms.ReportParameter("paramPagibig", TOTAL_PAGIBIG.ToString(”N”)),
                    New Microsoft.Reporting.WinForms.ReportParameter("paramSBU_Charges", TOTAL_SBU_CHARGES.ToString(”N”)),
                    New Microsoft.Reporting.WinForms.ReportParameter("paramNetPay", TOTAL_NET_PAY.ToString(”N”))
                    }

                    Dim rds_DTR As New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt_NetPay)
                    ReportV_NetPay.LocalReport.DataSources.Add(rds_DTR)
                    ReportV_NetPay.LocalReport.SetParameters(paramList)
                    ReportV_NetPay.RefreshReport()

                    PlusS = Nothing
                Else
                    MsgBox("No Records Found!", MsgBoxStyle.Exclamation, "Information")
                End If
            End Using

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
            GENSANPERFECT_HO = GetCount_Common("where UPPER(HO_CATEGORY) LIKE UPPER('%Photo%')")
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
            PBA_HO = GetCount_Common("where UPPER(HO_CATEGORY) LIKE UPPER('%GHS%')")
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
            Seven11_BR, COMI_TO_FUJI_BR, L_DALTON, L_PG711, DR_Dalton, DR_Photo, DR_House, ConDalton, ConPhoto, LEASING_P As Integer

        Dim M_DALTONP, M_PHOTO, M_DAVAOP, M_PERFECOM, D_DALTONP, D_PHOTO, D_DAVAOP, D_PERFECOM As Double

        DALTON_BB = GetCount_Common("where company = 'DALTON'")
        DALTON_HO = GetCount_Common("where UPPER(HO_CATEGORY) LIKE UPPER('%Dalton%')")
        GENSANPERFECT_BB = GetCount_Common("where branch_code IN ('ROG','ROX','FINEPIX','GMA','DIG','SNP','SMD')")
        GENSANPERFECT_HO = GetCount_Common("where UPPER(HO_CATEGORY) LIKE UPPER('%Photo%')")
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
        PBA_HO = GetCount_Common("where UPPER(HO_CATEGORY) LIKE UPPER('%GHS%')")
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

        LEASING_BR = GetModify_Reports("LEASINGBR") / 100
        LEASING_P = GetModify_Reports("LEASINGP") / 100

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
        Dim DALTON_EMP_P As String = DALTON_EMP / TOTAL_EE
        Dim GENSAN_PHOTO_EMP_P As String = (GENSANP_EMP + PHOTO_EMP) / TOTAL_EE
        Dim DAVAOP_EMP_P As String = DAVAOP_EMP / TOTAL_EE
        Dim PERFECOM_EMP_P As String = PERFECOM_EMP / TOTAL_EE
        Dim G3_EMP_P As String = G3_EMP / TOTAL_EE
        Dim SEVEN11_EMP_P As String = (SEVENROX_EMP + SEVENPOL_EMP) / TOTAL_EE
        Dim COMI_TO_FUJI_EMP_P As String = (COMI_EMP + PBA_EMP + KTV_EMP + WAVE_EMP) / TOTAL_EE

        '============================ BRANCH PERCENTAGE ==========================
        Dim DALTON_BR_P As String = DALTON_BR / TOTAL_BB
        Dim GENSAN_BR_P As String = GENSANPERFECT_BR / TOTAL_BB
        Dim DAVAOP_BR_P As String = DAVAOP_BR / TOTAL_BB
        Dim PERFECOM_BR_P As String = PERFECOM_BR / TOTAL_BB
        Dim G3_BR_P As String = G3_BR / TOTAL_BB
        Dim Seven11_BR_P As String = Seven11_BR / TOTAL_BB
        Dim COMI_TO_FUJI_BR_P As String = COMI_TO_FUJI_BR / TOTAL_BB
        Dim LEASING_BR_P As String = LEASING_BR / TOTAL_BB

        '============================ MARKETING PERCENTAGE ==========================
        M_DALTONP = GetModify_Reports("M_DALTONP") / 100
        M_PHOTO = GetModify_Reports("M_PHOTO") / 100
        M_DAVAOP = GetModify_Reports("M_DAVAOP") / 100
        M_PERFECOM = GetModify_Reports("M_PERFECOM") / 100

        '============================ DYU PERCENTAGE ==========================
        D_DALTONP = GetModify_Reports("D_DALTONP") / 100
        D_PHOTO = GetModify_Reports("D_PHOTO") / 100
        D_DAVAOP = GetModify_Reports("D_DAVAOP") / 100
        D_PERFECOM = GetModify_Reports("D_PERFECOM") / 100

        '============================ LYU PERCENTAGE ==========================
        L_DALTON = GetModify_Reports("L_DALTON") / 100
        L_PG711 = GetModify_Reports("L_PG711") / 100

        '============================ PHOTO_PERFECT PERCENTAGE ==========================
        Dim sum_3 As Integer = GENSANPERFECT_BR + DAVAOP_BR + PERFECOM_BR

        Dim GENSAN_PHOTO_PERFECT_P As String = GENSANPERFECT_BR / sum_3
        Dim DAVAOP_PHOTO_PERFECT_P As String = DAVAOP_BR / sum_3
        Dim PERFECOM_PHOTO_PERFECT_P As String = PERFECOM_BR / sum_3

        '============================ PHOTO_GHS_3G PERCENTAGE ==========================
        Dim sum_4 As Integer = GENSANPERFECT_BR + DAVAOP_BR + G3_BR + COMI_TO_FUJI_BR

        Dim GENSAN_PHOTO_GHS_3G_P As String = GENSANPERFECT_BR / sum_4
        Dim DAVAOP_PHOTO_GHS_3GT_P As String = DAVAOP_BR / sum_4
        Dim G3_PHOTO_GHS_3G_P As String = G3_BR / sum_4
        Dim COMI_TO_FUJI_PHOTO_GHS_3G_P As String = COMI_TO_FUJI_BR / sum_4

        '============================ PERFECOM_LEASING_711 PERCENTAGE ==========================
        Dim sum_5 As Integer = PERFECOM_BR + Seven11_BR + LEASING_BR

        Dim PERFECOM_PL7_P As String = PERFECOM_BR / sum_5
        Dim SEVEN11_PL7_P As String = Seven11_BR / sum_5
        Dim LEASING_PL7_P As String = LEASING_BR / sum_5

        '============================ DRIVER PERCENTAGE ========================== 
        DR_Dalton = GetModify_Reports("DR_Dalton")
        DR_Photo = GetModify_Reports("DR_Photo")
        DR_House = GetModify_Reports("DR_House")

        Dim sum_driver As Integer = DR_Dalton + DR_Photo + DR_House

        Dim DR_Dalton_P As String = DR_Dalton / sum_driver
        Dim DR_Photo_P As String = DR_Photo / sum_driver
        Dim DR_House_P As String = DR_House / sum_driver

        '============================ CONSTRUCTION PERCENTAGE ==========================  
        ConDalton = GetModify_Reports("ConDalton")
        ConPhoto = GetModify_Reports("ConPhoto")

        Dim ConDalton_P As String = ConDalton / sum_driver
        Dim ConPhoto_P As String = ConPhoto / sum_driver

        Dim DTR_DATON_P As String = GetModify_Reports("DTR_Dalton") / 100
        Dim DTR_PHOTO_P As String = GetModify_Reports("DTR_Photo") / 100

        Replacing("PAYROLL_PERCENTAGEE")

        Save_PERCENTAGE(DALTON_EMP_P, GENSAN_PHOTO_EMP_P, DAVAOP_EMP_P, PERFECOM_EMP_P, G3_EMP_P, SEVEN11_EMP_P, COMI_TO_FUJI_EMP_P, 0, 0, "EMPLOYEE")
        Save_PERCENTAGE(DALTON_BR_P, GENSAN_BR_P, DAVAOP_BR_P, PERFECOM_BR_P, G3_BR_P, Seven11_BR_P, COMI_TO_FUJI_BR_P, 0, LEASING_BR_P, "BRANCH")
        Save_PERCENTAGE(M_DALTONP, M_PHOTO, M_DAVAOP, M_PERFECOM, 0, 0, 0, 0, 0, "MARKETING")
        Save_PERCENTAGE(0, GENSAN_PHOTO_PERFECT_P, DAVAOP_PHOTO_PERFECT_P, PERFECOM_PHOTO_PERFECT_P, 0, 0, 0, 0, 0, "PHOTO/PERFECOM")
        Save_PERCENTAGE(0, GENSAN_PHOTO_GHS_3G_P, DAVAOP_PHOTO_GHS_3GT_P, 0, G3_PHOTO_GHS_3G_P, 0, COMI_TO_FUJI_PHOTO_GHS_3G_P, 0, 0, "PHOTO/GHS/3G")
        Save_PERCENTAGE(0, 0, 0, PERFECOM_PL7_P, 0, SEVEN11_PL7_P, 0, 0, LEASING_PL7_P, "PERFECOM/LEASING/7ELEVEN")
        Save_PERCENTAGE(D_DALTONP, D_PHOTO, D_DAVAOP, D_PERFECOM, 0, 0, 0, 0, 0, "DYU")
        Save_PERCENTAGE(L_DALTON, 0, 0, 0, 0, L_PG711, 0, 0, 0, "LYU")
        Save_PERCENTAGE(DR_Dalton_P, DR_Photo_P, 0, 0, 0, 0, 0, DR_House_P, 0, "DRIVER")
        Save_PERCENTAGE(ConDalton_P, ConPhoto_P, 0, 0, 0, 0, 0, 0, 0, "CONSTRUCTION")
        Save_PERCENTAGE(DTR_DATON_P, DTR_PHOTO_P, 0, 0, 0, 0, 0, 0, 0, "DTR")
        Save_PERCENTAGE(0, 0, 0, 0, 0, 0, 0, 0, LEASING_P, "LEASING")

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

                            If .ITEM("BIO_NO") = "2788" Then ' MADERA
                                HOUSEHOLD = 50 / 100
                                DALTON = (50 * DALTON) / 100
                                PHOTO = (50 * PHOTO) / 100
                                DAVAOP = (50 * DAVAOP) / 100
                                PERFECOM = (50 * PERFECOM) / 100
                                G3 = (50 * G3) / 100
                                Seven11 = (50 * Seven11) / 100
                                COMI_TO_FUJI = (50 * COMI_TO_FUJI) / 100
                            End If

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

    Public Sub LoadSummary_Print()

        RptViewer_Summary.LocalReport.DataSources.Clear()

        Try

            Dim PAYDATEE As String = SumPaydate_Combo.Text
            Dim GensanJR As DataTable = LoadDataTable_GensanJR(SumPaydate_Combo.Text)

            Dim Photo_GensanJR As New Microsoft.Reporting.WinForms.ReportDataSource("Photo_GensanJR", LoadDataTable_GensanJR(PAYDATEE))
            Dim Photo_Davao As New Microsoft.Reporting.WinForms.ReportDataSource("Photo_Davao", LoadDataTable_DavaoPerfect(PAYDATEE))
            Dim Dalton As New Microsoft.Reporting.WinForms.ReportDataSource("Dalton", LoadDataTable_Dalton(PAYDATEE))
            Dim Perfecom As New Microsoft.Reporting.WinForms.ReportDataSource("Perfecom", LoadDataTable_Perfecom(PAYDATEE))
            Dim PG_UY As New Microsoft.Reporting.WinForms.ReportDataSource("PG_UY", LoadDataTable_PG_UY(PAYDATEE))
            Dim Household As New Microsoft.Reporting.WinForms.ReportDataSource("Household", LoadDataTable_Household(PAYDATEE))
            Dim PG_Realty As New Microsoft.Reporting.WinForms.ReportDataSource("PG_Realty", GensanJR)
            RptViewer_Summary.LocalReport.DataSources.Add(Photo_GensanJR)
            RptViewer_Summary.LocalReport.DataSources.Add(Photo_Davao)
            RptViewer_Summary.LocalReport.DataSources.Add(Dalton)
            RptViewer_Summary.LocalReport.DataSources.Add(Perfecom)
            RptViewer_Summary.LocalReport.DataSources.Add(PG_UY)
            RptViewer_Summary.LocalReport.DataSources.Add(Household)
            RptViewer_Summary.LocalReport.DataSources.Add(PG_Realty)
            RptViewer_Summary.RefreshReport()

        Catch ex As Exception
            Log_Report(ex.ToString)
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub SumPaydate_Combo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SumPaydate_Combo.SelectedIndexChanged
        LoadSummary_Print()
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
        GetModify_Report(M_DaltonP_TXT, M_Photo_TXT, M_DavaoP_TXT, M_Perfecom_TXT, D_DaltonP_TXT, D_Photo_TXT, D_DavaoP_TXT, D_Perfecom_TXT, L_Dalton_TXT, L_PG711_TXT,
                                DR_Dalton_TXT, DR_Photo_TXT, DR_House_TXT, ConDalton_TXT, ConPhoto_TXT, ConHouse_TXT, LeasingBR_TXT, DTR_Dalton_TXT, DTR_Photo_TXT, LeasingP_TXT)
        Modify_Panel.Visible = True
        'Modify_Panel.Location = New Point(ClientSize.Width / 2 - Modify_Panel.Size.Width / 2, ClientSize.Height / 2 - Modify_Panel.Size.Height / 2)
    End Sub

    Private Sub Label14_Click(sender As Object, e As EventArgs) Handles Label14.Click
        Modify_Panel.Visible = False
    End Sub

    Private Sub Save_BTN_Click(sender As Object, e As EventArgs) Handles Save_BTN.Click

        Save_Marketing_DYU(M_DaltonP_TXT.Text, M_Photo_TXT.Text, M_DavaoP_TXT.Text, M_Perfecom_TXT.Text,
                           D_DaltonP_TXT.Text, D_Photo_TXT.Text, D_DavaoP_TXT.Text, D_Perfecom_TXT.Text, L_Dalton_TXT.Text, L_PG711_TXT.Text,
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

    Private Sub Company_Combo_SelectedValueChanged(sender As Object, e As EventArgs) Handles Company_Combo.SelectedValueChanged

        If Company_Combo.SelectedIndex = 0 Then '=== PHOTO
            NetBranch_Combo.Items.Clear()
            NetBranch_Combo.Items.Insert(0, "Davao Perfect")
            NetBranch_Combo.Items.Insert(1, "JR Photo")
            NetBranch_Combo.Items.Insert(2, "Gensan Perfect")

        ElseIf Company_Combo.SelectedIndex = 1 Then '=== P&G UY
            NetBranch_Combo.Items.Clear()
            NetBranch_Combo.Items.Insert(0, "3G")
            NetBranch_Combo.Items.Insert(1, "7Eleven")
            NetBranch_Combo.Items.Insert(2, "COMI-GHS Admin Operation")

        ElseIf Company_Combo.SelectedIndex = 2 Then '=== DALTON
            NetBranch_Combo.Items.Clear()
            NetBranch_Combo.Items.Insert(0, "Dalton Head Office")
            NetBranch_Combo.Items.Insert(1, "Dalton Branch")

        ElseIf Company_Combo.SelectedIndex = 3 Then '=== PERFECOM 

            NetBranch_Combo.Items.Clear()
            Dim mysql = $"Select * From PAYROLL_PAYOUT A 
                                        inner JOIN PAYROLL_EMPLOYEE B ON B.BIO_NO = A.BIOMETRIC_ID 
                                        left JOIN PAYROLL_CITY_BRANCH C ON C.BRANCHCODE = B.BRANCH_CODE
                                        where A.PAYDATE  = '{PaydateNet_ComboB.Text}' 
                                        and  B.COMPANY  = 'PERFECOM' OR B.HO_CATEGORY In ('Perfecom Admin Office','Perfecom Admin Operation')
                                        ORDER BY CASE WHEN B.BRANCH_CODE = 'SMG' THEN 1
                                                      WHEN B.BRANCH_CODE = 'KCG' THEN 2
                                                      WHEN B.BRANCH_CODE = 'OPK' THEN 3
                                                      WHEN B.BRANCH_CODE = 'ARC' THEN 4
                                                      WHEN B.BRANCH_CODE = 'ARC' THEN 5
                                                      WHEN B.BRANCH_CODE = 'KCM' THEN 6
                                                      WHEN B.BRANCH_CODE = 'ZAM' THEN 7
                                                      else 0 end, B.HO_CATEGORY asc, B.BRANCH_CODE asc"
            PlusS = "PERFECOM"

            LoadNet_Print(mysql)
        ElseIf Company_Combo.SelectedIndex = 4 Then '=== PGC HEAD OFFICE

            NetBranch_Combo.Items.Clear()

            Dim mysql = $"Select * From PAYROLL_PAYOUT A 
                                        inner JOIN PAYROLL_EMPLOYEE B ON B.BIO_NO = A.BIOMETRIC_ID 
                                        left JOIN PAYROLL_CITY_BRANCH C ON C.BRANCHCODE = B.BRANCH_CODE
                                        where A.PAYDATE  = '{PaydateNet_ComboB.Text}' AND B.HO_CATEGORY IN ('PGC Head Office','Construction' , 'Leasing Admin Office') "
            PlusS = "PGC"
            LoadNet_Print(mysql)
        End If
    End Sub

    Private Sub NetBranch_Combo_SelectedValueChanged(sender As Object, e As EventArgs) Handles NetBranch_Combo.SelectedValueChanged
        If PaydateNet_ComboB.SelectedIndex >= 0 Then

            Dim paydatee As String = PaydateNet_ComboB.SelectedItem
            Dim mysql As String = ""

            If Company_Combo.SelectedIndex = 0 Then '=== PHOTO

                If PaydateNet_ComboB.SelectedIndex >= 0 Then
                    If NetBranch_Combo.SelectedIndex = 0 Then '=== Davao Perfect

                        mysql = $"Select * From PAYROLL_PAYOUT A 
                                        inner JOIN PAYROLL_EMPLOYEE B ON B.BIO_NO = A.BIOMETRIC_ID 
                                        left JOIN PAYROLL_CITY_BRANCH C ON C.BRANCHCODE = B.BRANCH_CODE
                                        where A.PAYDATE  = '{paydatee}' and B.COMPANY  = 'PHOTO' and B.BRANCH_CODE IN ('SMG','KCG','ACM','TAC') 
                                        Order by case when B.BRANCH_CODE = 'KCG' then 0
                                                      when B.BRANCH_CODE = 'SMG' then 1
                                                      when B.BRANCH_CODE = 'TAC' then 2
                                                      when B.BRANCH_CODE = 'ACM' then 3 end"

                        PlusS = "DAVAO PERFECT"

                    ElseIf NetBranch_Combo.SelectedIndex = 1 Then '=== JR Photo

                        mysql = $"Select * From PAYROLL_PAYOUT A 
                                        inner JOIN PAYROLL_EMPLOYEE B ON B.BIO_NO = A.BIOMETRIC_ID 
                                        left JOIN PAYROLL_CITY_BRANCH C ON C.BRANCHCODE = B.BRANCH_CODE
                                        where A.PAYDATE  = '{paydatee}' and B.COMPANY  = 'PHOTO' and B.BRANCH_CODE IN ('DIG','ISU','M1','POL')
                                        Order by case when B.BRANCH_CODE = 'DIG' then 0
                                                      when B.BRANCH_CODE = 'ISU' then 1
                                                      when B.BRANCH_CODE = 'M1' then 2
                                                      when B.BRANCH_CODE = 'POL' then 3 end"

                        PlusS = "JR PHOTO"
                    ElseIf NetBranch_Combo.SelectedIndex = 2 Then '=== Gensan Perfect

                        mysql = $"Select * From PAYROLL_PAYOUT A 
                                        inner JOIN PAYROLL_EMPLOYEE B ON B.BIO_NO = A.BIOMETRIC_ID 
                                        left JOIN PAYROLL_CITY_BRANCH C ON C.BRANCHCODE = B.BRANCH_CODE
                                        where A.PAYDATE  = '{paydatee}' and B.COMPANY  = 'PHOTO' 
                                        and B.BRANCH_CODE IN ('ROG','ROX','FINEPIX','COT','MID','KID','SNP','GMA','SML','ZAM','SMD')
                                        or B.HO_CATEGORY IN ('Photo Admin Office', 'Photo Admin Operation')
                                        Order by case when B.BRANCH_CODE = 'ROG' then 1
                                                      when B.BRANCH_CODE = 'ROX' then 2
                                                      when B.BRANCH_CODE = 'FINEPIX' then 3
                                                      when B.BRANCH_CODE = 'COT' then 4 
                                                      when B.BRANCH_CODE = 'KID' then 5 
                                                      when B.BRANCH_CODE = 'MID' then 6 
                                                      when B.BRANCH_CODE = 'GMA' then 7 
                                                      when B.BRANCH_CODE = 'SNP' then 8 
                                                      when B.BRANCH_CODE = 'SMD' then 9 
                                                      when B.BRANCH_CODE = 'SML' then 10 
                                                      when B.BRANCH_CODE = 'ZAM' then 11 
                                                      else 0 end"

                        PlusS = "GENSAN PERFECT"

                    End If
                Else
                    MsgBox("Please select date of payroll.", MsgBoxStyle.Exclamation, "Error")
                End If

            ElseIf Company_Combo.SelectedIndex = 1 Then '=== P&G UY 

                If PaydateNet_ComboB.SelectedIndex >= 0 Then
                    If NetBranch_Combo.SelectedIndex = 0 Then '=== 3G

                        mysql = $"Select * From PAYROLL_PAYOUT A 
                                        inner JOIN PAYROLL_EMPLOYEE B ON B.BIO_NO = A.BIOMETRIC_ID 
                                        left JOIN PAYROLL_CITY_BRANCH C ON C.BRANCHCODE = B.BRANCH_CODE
                                        where A.PAYDATE  = '{paydatee}' and B.COMPANY  = 'P&G UY' and B.BRANCH_CODE = '3G'"

                    ElseIf NetBranch_Combo.SelectedIndex = 1 Then '=== 7Eleven

                        mysql = $"Select * From PAYROLL_PAYOUT A 
                                        inner JOIN PAYROLL_EMPLOYEE B ON B.BIO_NO = A.BIOMETRIC_ID   
                                        left JOIN PAYROLL_CITY_BRANCH C ON C.BRANCHCODE = B.BRANCH_CODE  
                                        where A.PAYDATE  = '{paydatee}' and B.COMPANY  = 'P&G UY' and B.BRANCH_CODE IN ('711-POL','711-ROX')"

                    ElseIf NetBranch_Combo.SelectedIndex = 2 Then '=== COMI-GHS Admin Operation

                        mysql = $"Select * From PAYROLL_PAYOUT A 
                                        inner Join PAYROLL_EMPLOYEE B ON B.BIO_NO = A.BIOMETRIC_ID
                                        left JOIN PAYROLL_CITY_BRANCH C ON C.BRANCHCODE = B.BRANCH_CODE  
                                        where A.PAYDATE = '{paydatee}' and B.COMPANY  = 'P&G UY' 
                                        And B.BRANCH_CODE IN ('COMI','KTV','PBA','WAVE') Or B.HO_CATEGORY In ('GHS/P&G UY Admin Office','GHS/P&G UY Admin Operation','GHS/P&G UY Maintenance')
                                        Order by case when B.HO_CATEGORY LIKE UPPER('%GHS%') then 1 else 0  end, B.HO_CATEGORY asc, B.BRANCH_CODE asc"

                    End If
                Else
                    MsgBox("Please select date of payroll.", MsgBoxStyle.Exclamation, "Error")
                End If

            ElseIf Company_Combo.SelectedIndex = 2 Then '=== DALTON

                If PaydateNet_ComboB.SelectedIndex >= 0 Then
                    If NetBranch_Combo.SelectedIndex = 0 Then '=== Dalton Office-Operation

                        mysql = $"Select * From PAYROLL_PAYOUT A 
                                        inner JOIN PAYROLL_EMPLOYEE B ON B.BIO_NO = A.BIOMETRIC_ID   
                                        left JOIN PAYROLL_CITY_BRANCH C ON C.BRANCHCODE = B.BRANCH_CODE  
                                        where A.PAYDATE  = '{paydatee}' and B.HO_CATEGORY IN ('Dalton Admin Office','Dalton Retail','Dalton Admin Operation') 
                                        Order by case when B.HO_CATEGORY LIKE '%Operation%' then 1 else 0  end, B.HO_CATEGORY asc"

                    ElseIf NetBranch_Combo.SelectedIndex = 1 Then '=== All Dalton Branches Maually Order

                        mysql = $"Select * From PAYROLL_PAYOUT A 
                                        inner JOIN PAYROLL_EMPLOYEE B ON B.BIO_NO = A.BIOMETRIC_ID 
                                        left JOIN PAYROLL_CITY_BRANCH C ON C.BRANCHCODE = B.BRANCH_CODE
                                        where A.PAYDATE  = '{paydatee}' AND B.COMPANY  = 'DALTON'
                                         Order by case when B.BRANCH_CODE = 'CAG' then 0 
                                                       when B.BRANCH_CODE = 'JCAT 2' then 1 
                                                       when B.BRANCH_CODE = 'KCG' then 2 
                                                       when B.BRANCH_CODE = 'LAG' then 3 
                                                       when B.BRANCH_CODE = 'PMA' then 4  
                                                       when B.BRANCH_CODE = 'NUN' then 5  
                                                       when B.BRANCH_CODE = 'PEN' then 6  
                                                       when B.BRANCH_CODE = 'PGN' then 7  
                                                       when B.BRANCH_CODE = 'PIO' then 8  
                                                       when B.BRANCH_CODE = 'ROG' then 9  
                                                       when B.BRANCH_CODE = 'ROX' then 10  
                                                       when B.BRANCH_CODE = 'SAN' then 11  
                                                       when B.BRANCH_CODE = 'UHA' then 12  
                                                       when B.BRANCH_CODE = 'POL' then 13  
                                                       when B.BRANCH_CODE = 'POL2' then 14  
                                                       when B.BRANCH_CODE = 'POL3' then 15  
                                                       when B.BRANCH_CODE = 'GAP' then 16  
                                                       when B.BRANCH_CODE = 'ACM' then 17  
                                                       when B.BRANCH_CODE = 'GAM' then 18  
                                                       when B.BRANCH_CODE = 'AL1' then 19  
                                                       when B.BRANCH_CODE = 'AL2' then 20  
                                                       when B.BRANCH_CODE = 'ZUL' then 21   
                                                       when B.BRANCH_CODE = 'ISU 1' then 22  
                                                       when B.BRANCH_CODE = 'ISU 2' then 23  
                                                       when B.BRANCH_CODE = 'ISU 3' then 24   
                                                       when B.BRANCH_CODE = 'TAC 1' then 25  
                                                       when B.BRANCH_CODE = 'TAC 2' then 26  
                                                       when B.BRANCH_CODE = 'PQO' then 27   
                                                       when B.BRANCH_CODE = 'SRA' then 28  
                                                       when B.BRANCH_CODE = 'TBOLI' then 29  
                                                       when B.BRANCH_CODE = 'BANG' then 30   
                                                       when B.BRANCH_CODE = 'ESPE' then 31  
                                                       when B.BRANCH_CODE = 'KAL' then 32  
                                                       when B.BRANCH_CODE = 'LAM' then 33  
                                                       when B.BRANCH_CODE = 'LEBAK' then 34   
                                                       when B.BRANCH_CODE = 'AWANG' then 35  
                                                       when B.BRANCH_CODE = 'DAL' then 36  
                                                       when B.BRANCH_CODE = 'COT 1' then 37  
                                                       when B.BRANCH_CODE = 'COT 2' then 38   
                                                       when B.BRANCH_CODE = 'COT 3' then 39   
                                                       when B.BRANCH_CODE = 'COT 4' then 40   
                                                       when B.BRANCH_CODE = 'KID' then 41  
                                                       when B.BRANCH_CODE = 'KID2' then 42  
                                                       when B.BRANCH_CODE = 'GAK' then 43   
                                                       when B.BRANCH_CODE = 'MID' then 44  
                                                       when B.BRANCH_CODE = 'KAB' then 45  
                                                       when B.BRANCH_CODE = 'KAB 2' then 46  
                                                       when B.BRANCH_CODE = 'KAB3' then 47   
                                                       when B.BRANCH_CODE = 'PIKIT' then 48    
                                                       when B.BRANCH_CODE = 'MLANG' then 49 
                                                       when B.BRANCH_CODE = 'TUL' then 50 
                                                       when B.BRANCH_CODE = 'SHARIFF' then 51 
                                                       when B.BRANCH_CODE = 'SHARIFF 2' then 52 
                                                       when B.BRANCH_CODE = 'UPI' then 53 
                                                       when B.BRANCH_CODE = 'PAR' then 54 
                                                       when B.BRANCH_CODE = 'BUL' then 55  
                                                       when B.BRANCH_CODE = 'DIG 1' then 56 
                                                       when B.BRANCH_CODE = 'DIG 2' then 57 
                                                       when B.BRANCH_CODE = 'GAD' then 58  
                                                       when B.BRANCH_CODE = 'GGP' then 59 
                                                       when B.BRANCH_CODE = 'SNP' then 60 
                                                       when B.BRANCH_CODE = 'TAG' then 61  
                                                       when B.BRANCH_CODE = 'ALA' then 62  
                                                       when B.BRANCH_CODE = 'GLAN' then 63 
                                                       when B.BRANCH_CODE = 'KIA' then 64 
                                                       when B.BRANCH_CODE = 'MAA' then 65 
                                                       when B.BRANCH_CODE = 'MAITUM' then 66 
                                                       when B.BRANCH_CODE = 'ABREA' then 67 
                                                       when B.BRANCH_CODE = 'SURI 2' then 68  
                                                       when B.BRANCH_CODE = 'SURI 3' then 69 
                                                       when B.BRANCH_CODE = 'GCS' then 70  
                                                       when B.BRANCH_CODE = 'BUT' then 71 
                                                       when B.BRANCH_CODE = 'GCA' then 72  
                                                       end, B.BRANCH_CODE asc"

                    End If

                Else
                    MsgBox("Please select date of payroll.", MsgBoxStyle.Exclamation, "Error")
                End If

            End If

            LoadNet_Print(mysql)
        End If
    End Sub

    Private Sub Close_LBL_Click(sender As Object, e As EventArgs) Handles Close_LBL.Click
        Close()
    End Sub

    Private Sub PaydateCom_Combo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PaydateCom_Combo.SelectedIndexChanged
        If PaydateCom_Combo.SelectedIndex >= 0 Then
            SavePercentage_Common()
            LoadCommonPercentage_Print()
        End If
    End Sub

End Class