Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Security
Imports System.Security.Policy
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports FirebirdSql.Data

Public Class frmReport

    Private allowCoolMove As Boolean = False
    Private myCoolPoint As New Point
    Dim PlusS As String = ""

    Private Sub frmReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim comboBoxes As New List(Of System.Windows.Forms.ComboBox) From {
            PaydateNet_ComboB,
            PaydateCom_Combo,
            SumPaydate_Combo,
            Rem_Paydate_Combo,
            CostPaydate_Combo,
            PaydateSBU_Combo,
            LoanPaydate_Combo
        }

        PopulateComboBoxes_PayDate(comboBoxes, "PAYROLL_PAYOUT", "PAYDATE")
        PopulatePaydate_Monthly(Allow_Paydate_Combo, "RECORDED_ALLOW_DEDUC", "PAYDATE")
        PopulatePaydate_Yearly(SILYear_Combo, "RECORDED_ALLOW_DEDUC", "PAYDATE")
        PopulatePaydate_Monthly(cbDateEffectivity, "HR_LETTER", "EFFECTIVE_DATE", " WHERE ACTION_NAME = 'REASSIGNMENT'")
    End Sub

    Private Sub SearchSBU_BTN_Click(sender As Object, e As EventArgs) Handles SearchSBU_BTN.Click
        Lists_SBU(SBU_LV, SearchSBU_TXT.Text)
    End Sub

    Private Sub SearchSBU_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles SearchSBU_TXT.KeyPress
        If IsEnter(e) Then SearchSBU_BTN.PerformClick()
    End Sub

    Friend Sub LoadSBU(Optional bioNo As Integer = 0)
        Rpt_SBU.LocalReport.DataSources.Clear()

        Try
            Dim dt As New DataTable()
            With dt
                .Columns.Add("NAME")
                .Columns.Add("P_AMOUNT")
                .Columns.Add("A_AMOUNT")
                .Columns.Add("PRINCIPAL")
                .Columns.Add("CREDIT")
                .Columns.Add("BALANCE")
                .Columns.Add("DATE")
                .Columns.Add("RECORDS_")
                .Columns.Add("AMOUNT")
            End With


            Dim credit As Decimal = 0
            Dim totalCredit As Decimal = 0
            Dim principal As Decimal = 0
            Dim balance As Decimal = 0

            Dim mysql As String
            Dim fullname As String = Nothing

            mysql = $"select  COALESCE(sum(C.AMOUNT), 0) AS TOTALS, CREDIT, PRINCIPAL, A.DATEHIRED, B.AMOUNT as amnt, DATE_ADDED, BALANCE,
                            LASTNAME || ', ' || FIRSTNAME || 
                            CASE
                                WHEN MIDDLENAME IS NOT NULL AND MIDDLENAME <> '' THEN ' ' || LEFT(MIDDLENAME, 1) || '.' 
                                ELSE ''
                            END || 
                            CASE 
                                WHEN SUFFIX IS NOT NULL AND SUFFIX <> '' THEN ' ' || SUFFIX
                                ELSE ''
                            END AS FULLNAME
                            from TBL_EMPLOYEE A 
                            inner join PAYROLL_SBU B on B.BIO_NO = A.BIOMETRICID 
                            left join RECORDED_ALLOW_DEDUC C on C.BIO_NO = A.BIOMETRICID and C.CATEGORY = 'SBU' and PAYDATE <> '12/15/2021' 
                            WHERE  B.BIO_NO = '{bioNo}' GROUP BY C.AMOUNT, FULLNAME, CREDIT, PRINCIPAL, A.DATEHIRED, B.AMOUNT, DATE_ADDED, BALANCE   ORDER BY FULLNAME ASC "

            Using ds As DataSet = LoadSQL(mysql, "TBL_EMPLOYEE")
                If ds.Tables(0).Rows.Count > 0 Then
                    With ds.Tables(0).Rows(0)
                        fullname = .Item("FULLNAME")
                        credit = IIf(IsDBNull(.Item("CREDIT")), 0, .Item("CREDIT"))
                        totalCredit = credit + CDbl(.Item("TOTALS"))
                        principal = IIf(IsDBNull(.Item("PRINCIPAL")), 0, .Item("PRINCIPAL"))
                        balance = principal - totalCredit

                        Dim datee As Date = IIf(IsDBNull(.Item("DATE_ADDED")), .Item("DATEHIRED"), .Item("DATE_ADDED"))
                        dt.Rows.Add(fullname, principal, principal, FormatNumber(principal), FormatNumber(totalCredit), FormatNumber(balance), datee.ToString("MM/dd/yyyy"), "NO", .Item("amnt"))

                        If credit <> 0 Then     'IF NOT ZERO PARA DILI MASOBRA ANG COUNT NG DATE
                            dt.Rows.Add(fullname, credit, credit, FormatNumber(principal), FormatNumber(totalCredit), FormatNumber(balance), "12/15/2021", "YES", .Item("amnt"))
                        End If

                    End With
                End If
            End Using

            Dim mysqll As String = $"Select  PAYDATE, B.DATEHIRED, AMOUNT  from RECORDED_ALLOW_DEDUC A  
                            left join TBL_EMPLOYEE B on B.BIOMETRICID = A.BIO_NO 
                            WHERE  A.BIO_NO = '{bioNo}'  and A.CATEGORY = 'SBU' and PAYDATE <> '12/15/2021' ORDER BY PAYDATE ASC "

            Using dss As DataSet = LoadSQL(mysqll, "RECORDED_ALLOW_DEDUC")
                If dss.Tables(0).Rows.Count > 0 Then
                    For Each dr In dss.Tables(0).Rows
                        With dr

                            Dim datee As Date = .Item("PAYDATE")
                            Dim amount As Double = .Item("AMOUNT")

                            dt.Rows.Add(fullname, amount, amount, FormatNumber(principal), FormatNumber(totalCredit), FormatNumber(balance), Format(datee, "MM/dd/yyyy"), "YES", amount)

                        End With
                    Next
                End If
            End Using

            Dim DATASET As New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt)
            Rpt_SBU.LocalReport.DataSources.Add(DATASET)
            Rpt_SBU.RefreshReport()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Friend Sub LoadSBU_Company(company As String)
        Rpt_SBU.LocalReport.DataSources.Clear()

        Try
            Dim dt As New DataTable()
            With dt
                .Columns.Add("NAME")
                .Columns.Add("P_AMOUNT")
                .Columns.Add("A_AMOUNT")
                .Columns.Add("PRINCIPAL")
                .Columns.Add("CREDIT")
                .Columns.Add("BALANCE")
                .Columns.Add("DATE")
                .Columns.Add("RECORDS_")
                .Columns.Add("AMOUNT")
            End With

            Dim remanticCredit As Decimal = 0
            Dim totalCredit As Decimal = 0
            Dim principal As Decimal = 0
            Dim balance As Decimal = 0
            Dim newPayrollCredit As Decimal = 0
            Dim totalAmount As Decimal = 0
            Dim companyName As String = Nothing

            principal = GetTotal("PRINCIPAL", $"PAYROLL_SBU A LEFT JOIN TBL_EMPLOYEE B ON B.BIOMETRICID = A.BIO_NO WHERE COMPANY = '{company}' AND A.CATEGORY = 'SBU'")
            remanticCredit = GetTotal("CREDIT", $"PAYROLL_SBU A LEFT JOIN TBL_EMPLOYEE B ON B.BIOMETRICID = A.BIO_NO WHERE COMPANY = '{company}' AND A.CATEGORY = 'SBU'")
            totalAmount = GetTotal("AMOUNT", $"PAYROLL_SBU A LEFT JOIN TBL_EMPLOYEE B ON B.BIOMETRICID = A.BIO_NO WHERE COMPANY = '{company}' AND A.CATEGORY = 'SBU'")
            newPayrollCredit = GetTotal("AMOUNT", $"RECORDED_ALLOW_DEDUC A LEFT JOIN TBL_EMPLOYEE B ON B.BIOMETRICID = A.BIO_NO WHERE COMPANY = '{company}' AND A.CATEGORY = 'SBU' AND PAYDATE <> '12/15/2021' ")
            totalCredit = remanticCredit + newPayrollCredit
            balance = principal - totalCredit

            dt.Rows.Add(company, principal, principal, FormatNumber(principal), FormatNumber(totalCredit), FormatNumber(balance), "Principal", "NO", totalAmount)

            If remanticCredit <> 0 Then     'IF NOT ZERO PARA DILI MASOBRA ANG COUNT NG DATE
                dt.Rows.Add(company, remanticCredit, remanticCredit, FormatNumber(principal), FormatNumber(totalCredit), FormatNumber(balance), "From Remantic", "YES", totalAmount)
            End If

            Dim mysqll As String = $"SELECT
                                    EXTRACT(MONTH FROM A.PAYDATE) AS MONTHH,
                                    EXTRACT(YEAR FROM A.PAYDATE) AS YEARR,
                                    SUM(AMOUNT) AS TOTAL_AMOUNT
                                FROM
                                    RECORDED_ALLOW_DEDUC A
                                LEFT JOIN
                                    TBL_EMPLOYEE B ON B.BIOMETRICID = A.BIO_NO
                                WHERE
                                    COMPANY = '{company}' AND
                                    A.CATEGORY = 'SBU' AND
                                    A.PAYDATE <> '12/15/2021' AND 
                                    SOA_PATH IS NULL
                                GROUP BY
                                    EXTRACT(MONTH FROM A.PAYDATE),
                                    EXTRACT(YEAR FROM A.PAYDATE)
                                ORDER BY
                                    EXTRACT(YEAR FROM A.PAYDATE),
                                    EXTRACT(MONTH FROM A.PAYDATE) ASC; "

            Using dss As DataSet = LoadSQL(mysqll, "RECORDED_ALLOW_DEDUC")
                If dss.Tables(0).Rows.Count > 0 Then
                    progressBarStart(dss.Tables(0).Rows.Count)
                    For Each dr In dss.Tables(0).Rows
                        With dr

                            Dim amount As Double = .Item("TOTAL_AMOUNT")
                            Dim monthName As String = New DateTime(.Item("YEARR"), .Item("MONTHH"), 1).ToString("Y")

                            dt.Rows.Add(company, amount, amount, FormatNumber(principal), FormatNumber(totalCredit), FormatNumber(balance), monthName, "YES", amount)

                        End With
                        frmMainForm.AppProgressBar.Value += 1
                    Next
                    progressBarEnd()
                End If
            End Using

            Dim DATASET As New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt)
            Rpt_SBU.LocalReport.ReportEmbeddedResource = "WindowsApp1.rpt_SBU_Company.rdlc"
            Rpt_SBU.LocalReport.DataSources.Add(DATASET)
            Rpt_SBU.RefreshReport()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Friend Sub LoadSBU_ViewList()
        Rpt_SBU.LocalReport.DataSources.Clear()
        Dim payDate As String = $"AND C.PAYDATE BETWEEN '12/31/2021' AND '{GetMAX("PAYROLL_PAYOUT", "PAYDATE")}'"
        Dim selectedCompany As String = ""
        If PaydateSBU_Combo.Text <> "" Then payDate = $"AND C.PAYDATE BETWEEN '12/31/2021' AND '{PaydateSBU_Combo.Text}'"

        Dim empStatus As String = ""
        If statusSBU_combo.SelectedIndex <> 0 Then empStatus = $" AND EMP_STATUS = '{statusSBU_combo.Text}'"

        If CompanySBU_CB.SelectedIndex = 1 Then '=== PHOTO
            selectedCompany = $"AND A.COMPANY  = 'PHOTO'"
        ElseIf CompanySBU_CB.SelectedIndex = 2 Then '=== P&G UY
            selectedCompany = $"AND A.COMPANY  = 'P&G UY'"
        ElseIf CompanySBU_CB.SelectedIndex = 3 Then '=== DALTON
            selectedCompany = $"AND A.COMPANY  = 'DALTON'"
        ElseIf CompanySBU_CB.SelectedIndex = 4 Then '=== PERFECOM  
            selectedCompany = $"AND A.COMPANY  = 'PERFECOM' OR A.HO_CATEGORY In ('Perfecom Admin Office','Perfecom Admin Operation')"
        ElseIf CompanySBU_CB.SelectedIndex = 5 Then '=== PTU REALTY  
            selectedCompany = $"AND A.HO_CATEGORY IN ('Construction' , 'Leasing Admin Office')"
        ElseIf CompanySBU_CB.SelectedIndex = 6 Then '=== HEAD OFFICE  
            selectedCompany = $"AND A.COMPANY  = 'HEAD OFFICE'"
        ElseIf CompanySBU_CB.SelectedIndex = 7 Then '=== COMMON EMPLOYEES
            selectedCompany = $"AND A.HO_CATEGORY = 'PGC Head Office'"
        End If

        Try
            Dim dt As New DataTable()
            With dt
                .Columns.Add("BRANCH")
                .Columns.Add("NAME")
                .Columns.Add("PRINCIPAL")
                .Columns.Add("AMORT")
                .Columns.Add("CREDIT")
                .Columns.Add("BALANCE")
                .Columns.Add("FORM_NAME")
            End With

#Region "To Delete"
            'Dim mysqll As String = $"select  
            '                            CASE
            '                          WHEN BRANCHNAME IS NOT NULL AND BRANCHNAME <> '' THEN BRANCHNAME
            '                          ELSE HO_CATEGORY
            '                            END AS BRANCHNAME,

            '                            LASTNAME || ', ' || FIRSTNAME || 
            '                            CASE
            '                                WHEN MIDDLENAME IS NOT NULL AND MIDDLENAME <> '' THEN ' ' || LEFT(MIDDLENAME, 1) || '.' 
            '                                ELSE ''
            '                            END || 
            '                            CASE 
            '                                WHEN SUFFIX IS NOT NULL AND SUFFIX <> '' THEN ' ' || SUFFIX
            '                                ELSE ''
            '                            END AS FULLNAME,

            '                            PRINCIPAL,
            '                            B.AMOUNT as AMORT, 
            '                            COMPANY, 

            '                            CASE 
            '                             WHEN CREDIT IS NULL AND BALANCE IS NULL THEN COALESCE(sum(C.AMOUNT), 0)
            '                                ELSE COALESCE(sum(C.AMOUNT), 0) + CREDIT 
            '                                END AS NEW_CREDIT,

            '                            PRINCIPAL - CASE 
            '                                            WHEN CREDIT IS NULL AND BALANCE IS NULL THEN COALESCE(sum(C.AMOUNT), 0)
            '                                            ELSE COALESCE(sum(C.AMOUNT), 0) + CREDIT 
            '                                        END
            '                            AS NEW_BALANCE

            '                        from
            '                         TBL_EMPLOYEE A
            '                        inner join
            '                         PAYROLL_SBU B on B.BIO_NO = A.BIOMETRICID
            '                        left join
            '                         RECORDED_ALLOW_DEDUC C on C.BIO_NO = A.BIOMETRICID and C.CATEGORY = 'SBU' and {payDate}
            '                        LEFT JOIN
            '                         PAYROLL_CITY_BRANCH D ON D.BRANCHCODE = A.BRANCHCODE
            '                        WHERE SOA_PATH IS NULL {selectedCompany}
            '                        GROUP BY FULLNAME, BRANCHNAME, CREDIT, PRINCIPAL, B.AMOUNT, COMPANY, BALANCE
            '                        ORDER BY BRANCHNAME, FULLNAME ASC; "
#End Region

            Dim mysqll As String = $"SELECT 
                                    CASE 
                                        WHEN BRANCHNAME IS NOT NULL AND BRANCHNAME <> '' THEN BRANCHNAME 
                                        ELSE HO_CATEGORY 
                                    END AS BRANCHNAME, 
                                    LASTNAME || ', ' || FIRSTNAME || 
                                    CASE 
                                        WHEN MIDDLENAME IS NOT NULL AND MIDDLENAME <> '' THEN ' ' || LEFT(MIDDLENAME, 1) || '.' 
                                        ELSE '' 
                                    END || 
                                    CASE 
                                        WHEN SUFFIX IS NOT NULL AND SUFFIX <> '' THEN ' ' || SUFFIX 
                                        ELSE '' 
                                    END AS FULLNAME, 
                                    PRINCIPAL, 
                                    B.AMOUNT AS AMORT, 
                                    COMPANY, 
                                    CASE 
                                        WHEN CREDIT IS NULL AND BALANCE IS NULL 
                                        THEN COALESCE(SUM(C.AMOUNT), 0) 
                                        ELSE COALESCE(SUM(C.AMOUNT), 0) + CREDIT 
                                    END AS NEW_CREDIT, 
                                    PRINCIPAL - CASE 
                                        WHEN CREDIT IS NULL AND BALANCE IS NULL 
                                        THEN COALESCE(SUM(C.AMOUNT), 0) 
                                        ELSE COALESCE(SUM(C.AMOUNT), 0) + CREDIT 
                                    END AS NEW_BALANCE 
                                FROM TBL_EMPLOYEE A 
                                INNER JOIN PAYROLL_SBU B ON B.BIO_NO = A.BIOMETRICID 
                                LEFT JOIN RECORDED_ALLOW_DEDUC C 
                                    ON C.BIO_NO = A.BIOMETRICID 
                                    AND C.CATEGORY = 'SBU' 
                                    {payDate}  
                                LEFT JOIN PAYROLL_CITY_BRANCH D ON D.BRANCHCODE = A.BRANCHCODE 
                                WHERE SOA_PATH IS NULL {empStatus} {selectedCompany}
                                GROUP BY FULLNAME, BRANCHNAME, CREDIT, PRINCIPAL, B.AMOUNT, COMPANY, BALANCE 
                                ORDER BY BRANCHNAME, FULLNAME ASC;"

            TestingScript_String(mysqll)
            Using dss As DataSet = LoadSQL(mysqll, "TBL_EMPLOYEE")
                If dss.Tables(0).Rows.Count > 0 Then
                    progressBarStart(dss.Tables(0).Rows.Count)
                    For Each dr In dss.Tables(0).Rows
                        With dr

                            Dim company As String = Nothing
                            Dim branch As String = Nothing
                            Dim fullname As String = .Item("FULLNAME")
                            Dim principal As Decimal = .Item("PRINCIPAL")
                            Dim amort As Decimal = .Item("AMORT")
                            Dim credit As Decimal = .Item("NEW_CREDIT")
                            Dim balance As Decimal = .Item("NEW_BALANCE")

                            If IsDBNull(.Item("BRANCHNAME")) Then
                                branch = "No branch"
                            ElseIf String.IsNullOrEmpty(.Item("BRANCHNAME")) Then
                                branch = "No branch"
                            Else
                                branch = .Item("BRANCHNAME")
                            End If

                            If IsDBNull(.Item("COMPANY")) Then
                                company = "No company"
                            ElseIf String.IsNullOrEmpty(.Item("COMPANY")) Then
                                company = "No company"
                            Else
                                company = .Item("COMPANY")
                            End If

                            If company <> "HEAD OFFICE" Then branch = $"{company} - {branch}"

                            dt.Rows.Add(branch, fullname, FormatNumber(principal), FormatNumber(amort), FormatNumber(credit), FormatNumber(balance), $"LIST OF SBU - {Now}")

                        End With
                        frmMainForm.AppProgressBar.Value += 1
                    Next
                    progressBarEnd()
                End If
            End Using

            Dim paramPaydate As String = IIf(PaydateSBU_Combo.Text = Nothing, "", $"Payroll Date: {PaydateSBU_Combo.Text} - ({statusSBU_combo.Text})")
            Dim parameter As New List(Of Microsoft.Reporting.WinForms.ReportParameter) From {
                New Microsoft.Reporting.WinForms.ReportParameter("paramPaydate", paramPaydate)
                }

            Dim DATASET As New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt)
            Rpt_SBU.LocalReport.ReportEmbeddedResource = "WindowsApp1.rpt_SBU_All.rdlc"
            Rpt_SBU.LocalReport.SetParameters(parameter)
            Rpt_SBU.LocalReport.DataSources.Add(DATASET)
            Rpt_SBU.RefreshReport()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Friend Sub LoadDeduction_Company(conditional As String)
        Rpt_Deduction.LocalReport.DataSources.Clear()

        Try

            Dim dt As New DataTable()
            With dt
                .Columns.Add("COMPANY")
                .Columns.Add("PHOTO_CATEGORY")
                .Columns.Add("AMOUNT")
                .Columns.Add("PRINCIPAL")
                .Columns.Add("CREDIT")
                .Columns.Add("BALANCE")
                .Columns.Add("DATE")
                .Columns.Add("AMOUNT_CREDIT")
                .Columns.Add("RECORDS_")
            End With

            Dim amort As Decimal = 0
            Dim remanticCredit As Decimal = 0
            Dim totalCredit As Decimal = 0
            Dim newPayrollCredit As Decimal = 0
            Dim principal As Decimal = 0
            Dim balance As Decimal = 0
            Dim partialPayment As Decimal = 0
            Dim status As String = ""
            Dim company As String = ""
            Dim company_category As String = ""
            Dim ho_category As String = ""

            Dim mysql As String = $"SELECT  
	                                    SUM(AMORT) AS TOTAL_AMORT,
                                        SUM(A.CREDIT) AS TOTAL_CREDIT,
                                        SUM(A.PRINCIPAL) AS TOTAL_PRINCIPAL, 
                                        SUM((SELECT COALESCE(SUM(AMOUNT), 0) FROM RECORDED_ALLOW_DEDUC WHERE R_DEDUC_ID = A.ID AND PAYDATE <> '12/15/2021')) AS TOTAL_NEWCREDIT,
                                        SUM((SELECT COALESCE(SUM(AMOUNT), 0) FROM PARTIAL_PAYMENT WHERE DEDUCT_ID = A.ID)) AS TOTAL_PARTIAL, 
                                        COMPANY, PHOTO_CATEGORY, HO_CATEGORY 
                                    FROM
                                        
A 
                                    INNER JOIN 
                                        TBL_EMPLOYEE B ON B.BIOMETRICID = A.BIO_NO
                                    WHERE 
                                         {conditional}
                                    GROUP BY  
                                        COMPANY, PHOTO_CATEGORY, HO_CATEGORY"

            TestingScript_String(mysql)
            Using ds As DataSet = LoadSQL(mysql, "TBL_EMPLOYEE")
                If ds.Tables(0).Rows.Count > 0 Then
                    For Each dr In ds.Tables(0).Rows
                        With dr
                            amort = .Item("TOTAL_AMORT")
                            remanticCredit = .Item("TOTAL_CREDIT")
                            principal = .Item("TOTAL_PRINCIPAL")
                            newPayrollCredit = .Item("TOTAL_NEWCREDIT")
                            partialPayment = .Item("TOTAL_PARTIAL")
                            totalCredit = remanticCredit + newPayrollCredit + partialPayment
                            balance = principal - totalCredit
                            company = .Item("COMPANY")
                            ho_category = .Item("HO_CATEGORY")

                            If company = "PHOTO" Then
                                company_category = .Item("PHOTO_CATEGORY")
                            ElseIf ho_category <> Nothing Then
                                company_category = ho_category
                            End If

                            dt.Rows.Add(company, company_category, FormatNumber(amort), FormatNumber(principal), FormatNumber(totalCredit), FormatNumber(balance), "Principal", principal.ToString("N"), "NO")

                            If remanticCredit <> 0 Then     'IF NOT ZERO PARA DILI MASOBRA ANG COUNT NG DATE
                                dt.Rows.Add(company, company_category, FormatNumber(amort), FormatNumber(principal), FormatNumber(totalCredit), FormatNumber(balance), "From Remantic", remanticCredit.ToString("N"), "YES")
                            End If
                            If partialPayment <> 0 Then
                                dt.Rows.Add(company, company_category, FormatNumber(amort), FormatNumber(principal), FormatNumber(totalCredit), FormatNumber(balance), "Partial Payment", partialPayment.ToString("N"), "YES")
                            End If
                        End With
                    Next
                End If
            End Using

            Dim mysqll As String = $"SELECT 
                                        EXTRACT(MONTH FROM C.PAYDATE) AS MONTHH, 
                                        EXTRACT(YEAR FROM C.PAYDATE) AS YEARR,
                                        COMPANY, PHOTO_CATEGORY, HO_CATEGORY,
                                        SUM(AMOUNT) AS TOTAL_AMOUNT 
                                    FROM
                                        PAYROLL_DEDUCTION A
                                    INNER JOIN 
                                        TBL_EMPLOYEE B ON B.BIOMETRICID = A.BIO_NO   
                                    LEFT JOIN 
                                        RECORDED_ALLOW_DEDUC C ON C.BIO_NO = A.BIO_NO AND C.R_DEDUC_ID = A.ID  
                                    WHERE
                                        {conditional} AND C.PAYDATE <> '12/15/2021'
                                    GROUP BY 
                                        EXTRACT(MONTH FROM C.PAYDATE),
                                        EXTRACT(YEAR FROM C.PAYDATE), 
                                        COMPANY, PHOTO_CATEGORY, HO_CATEGORY
                                    ORDER BY 
	                                    EXTRACT(YEAR FROM C.PAYDATE),
                                        EXTRACT(MONTH FROM C.PAYDATE)"

            TestingScript_String(mysqll)
            Using dss As DataSet = LoadSQL(mysqll, "RECORDED_ALLOW_DEDUC")
                If dss.Tables(0).Rows.Count > 0 Then
                    progressBarStart(dss.Tables(0).Rows.Count)
                    For Each dr In dss.Tables(0).Rows
                        With dr

                            Dim amount As Double = .Item("TOTAL_AMOUNT")
                            Dim monthName As String = New DateTime(.Item("YEARR"), .Item("MONTHH"), 1).ToString("Y")
                            company = .Item("COMPANY")
                            ho_category = .Item("HO_CATEGORY")

                            If company = "PHOTO" Then
                                company_category = .Item("PHOTO_CATEGORY")
                            ElseIf ho_category <> Nothing Then
                                company_category = ho_category
                            End If

                            dt.Rows.Add(company, company_category, FormatNumber(amort), FormatNumber(principal), FormatNumber(totalCredit), FormatNumber(balance), monthName, amount.ToString("N"), "YES")

                        End With
                        frmMainForm.AppProgressBar.Value += 1
                    Next
                    progressBarEnd()
                End If
            End Using

            Dim DATASET As New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt)
            Rpt_Deduction.LocalReport.ReportEmbeddedResource = "WindowsApp1.rpt_Deduction_Company.rdlc"
            Rpt_Deduction.LocalReport.DataSources.Add(DATASET)
            Rpt_Deduction.RefreshReport()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Friend Sub LoadDeduction(deduct_id As Integer, category As String, fullname As String)
        Rpt_Deduction.LocalReport.DataSources.Clear()

        Try

            Dim dt As New DataTable()
            With dt
                .Columns.Add("PAYDATE")
                .Columns.Add("AMOUNT")
                .Columns.Add("RECORDS_")
            End With

            Dim a_amount As Decimal = 0
            Dim credit As Decimal = 0
            Dim totalCredit As Decimal = 0
            Dim principal As Decimal = 0
            Dim balance As Decimal = 0
            Dim partialPayment As Decimal = 0
            Dim status As String = ""

            a_amount = GetData_Decimal("AMORT", $"PAYROLL_DEDUCTION WHERE ID = '{deduct_id}'")
            credit = GetData_Decimal("CREDIT", $"PAYROLL_DEDUCTION WHERE ID = '{deduct_id}'")
            principal = GetData_Decimal("PRINCIPAL", $"PAYROLL_DEDUCTION WHERE ID = '{deduct_id}'")
            partialPayment = GetData_Decimal("AMOUNT", $"PARTIAL_PAYMENT WHERE DEDUCT_ID = '{deduct_id}'")
            totalCredit = credit + partialPayment + GetTotal("AMOUNT", $"RECORDED_ALLOW_DEDUC WHERE R_DEDUC_ID = '{deduct_id}' and PAYDATE <> '12/15/2021'")
            balance = principal - totalCredit

            Dim datt As Date = GetData("DATEE", $"PAYROLL_DEDUCTION WHERE ID = '{deduct_id}'")

            dt.Rows.Add(Format(datt, "MMMM dd, yyyy"), principal.ToString("N"), "NO")
            dt.Rows.Add("December 15, 2021", credit.ToString("N"), "YES")

            Dim mysqll As String = $"Select  *  from RECORDED_ALLOW_DEDUC A  
                            inner join TBL_EMPLOYEE B on B.BIOMETRICID = A.BIO_NO 
                            WHERE R_DEDUC_ID = '{deduct_id}' and PAYDATE <> '12/15/2021' ORDER BY PAYDATE ASC "

            Using dss As DataSet = LoadSQL(mysqll, "RECORDED_ALLOW_DEDUC")
                If dss.Tables(0).Rows.Count > 0 Then
                    For Each dr In dss.Tables(0).Rows
                        With dr

                            Dim datee As Date = .Item("PAYDATE")
                            Dim amount As Double = .Item("AMOUNT")

                            dt.Rows.Add(Format(datee, "MMMM dd, yyyy"), amount.ToString("N"), "YES")

                        End With
                    Next
                End If
            End Using

            '====================== PARTIAL PAYMENT ===================
            mysqll = $"Select  *  from PARTIAL_PAYMENT WHERE DEDUCT_ID = '{deduct_id}' ORDER BY DATEE ASC "
            Using dss As DataSet = LoadSQL(mysqll, "PARTIAL_PAYMENT")
                If dss.Tables(0).Rows.Count > 0 Then
                    For Each dr In dss.Tables(0).Rows
                        With dr
                            dt.Rows.Add($"Partial Payment", CDbl(.Item("AMOUNT")).ToString("N"), "YES")
                        End With
                    Next
                End If
            End Using

            If GetData("STATUS", $"PAYROLL_DEDUCTION WHERE ID = '{deduct_id}'") <> "" And balance > 0 Then
                dt.Rows.Add("Advance Payment", balance.ToString("N"), "YES")
                balance = 0
            End If

            Dim parameter As New List(Of Microsoft.Reporting.WinForms.ReportParameter) From {
                New Microsoft.Reporting.WinForms.ReportParameter("paramName", fullname),
                New Microsoft.Reporting.WinForms.ReportParameter("paramCategory", category),
                New Microsoft.Reporting.WinForms.ReportParameter("paramAmount", a_amount.ToString("N")),
                New Microsoft.Reporting.WinForms.ReportParameter("paramPrincipal", principal.ToString("N")),
                New Microsoft.Reporting.WinForms.ReportParameter("paramAmountPaid", totalCredit.ToString("N")),
                New Microsoft.Reporting.WinForms.ReportParameter("paramCategory", category),
                New Microsoft.Reporting.WinForms.ReportParameter("paramBalance", balance.ToString("N") & status)
                }

            Dim DATASET As New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt)
            Rpt_Deduction.LocalReport.DataSources.Add(DATASET)
            Rpt_Deduction.LocalReport.SetParameters(parameter)
            Rpt_Deduction.RefreshReport()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Public Sub LoadNet_Print(mysqll As String)
        If PaydateNet_ComboB.SelectedIndex >= 0 Then
            ReportV_NetPay.LocalReport.DataSources.Clear()

            Dim paydatee As String = PaydateNet_ComboB.SelectedItem
            Dim GROUP As String = ""
            Dim period As String
            Dim linee As String = Nothing
            Dim fullname As String = Nothing

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
                    .Columns.Add("CHARGES_SBU")
                    .Columns.Add("NET_PAY")
                    .Columns.Add("BRANCH_CODE")
                    .Columns.Add("PAYDATE")
                    .Columns.Add("PERIOD")
                    .Columns.Add("COMPANY")
                    .Columns.Add("HO_CATEGORY")
                    .Columns.Add("PLUS")
                    .Columns.Add("MONTH_13")
                    .Columns.Add("ACCOUNT_NO")
                    .Columns.Add("CHARGES_MP2")
                    .Columns.Add("CHARGES_CA")
                    .Columns.Add("CHARGES_ECS")
                    .Columns.Add("CHARGES_OTHERS")
                    .Columns.Add("LOAN_SSS")
                    .Columns.Add("LOAN_PAGIBIG")
                End With

                TestingScript_String(mysqll)

                Using ds As DataSet = LoadSQL(mysqll, "PAYROLL_PAYOUT")

                    If ds.Tables(0).Rows.Count > 0 Then

                        progressBarStart(ds.Tables(0).Rows.Count)
                        For Each dr In ds.Tables(0).Rows
                            With dr
                                Dim EMP_NO As String = IIf(IsDBNull(.Item("EMP_NO")), "", .Item("EMP_NO"))
                                Dim BIO_NO As String = .Item("BIOMETRIC_ID")

                                Dim payroll As DateTime = paydatee

                                '============================= NAME AND ATTENDANCE ============================  
                                linee = "FULLNAME"
                                Dim namee As String = .Item("FULLNAME")
                                linee = "ACCOUNTNO"
                                Dim ACCOUNTNO As String = IIf(IsDBNull(.Item("ACCOUNTNO")), "", .Item("ACCOUNTNO"))
                                fullname = namee
                                linee = "BASIC"
                                Dim BASIC As Double = .Item("TOTAL_BASIC")
                                linee = "OVERTIME"
                                Dim OVERTIME As Decimal = .Item("TOTAL_OVERTIME")
                                linee = "HOLIDAY"
                                Dim HOLIDAY As Decimal = .Item("TOTAL_REGHOLIDAY") + .Item("TOTAL_SPECHOLIDAY")
                                linee = "N_DIFF"
                                Dim N_DIFF As Decimal = .Item("TOTAL_NIGHT_RATE")
                                linee = "PI_ECOLA_SIL"
                                Dim PI_ECOLA_SIL As Double = Get_PI_ECOLA_SIL(BIO_NO, paydatee)
                                linee = "TARDINESS"
                                Dim TARDINESS As Double = .Item("TOTAL_LATE_UT")
                                linee = "SSS"
                                Dim SSS As Double = .Item("SSS_COMP")
                                linee = "PHIC"
                                Dim PHIC As Double = .Item("PHILHEALTH_COMP")
                                linee = "PAGIBIG"
                                Dim PAGIBIG As Double = .Item("PAGIBIG_COMP")
                                linee = "NET_PAY"
                                Dim NET_PAY As Double = .Item("NET_PAY")
                                linee = "COMPANY"
                                Dim COMPANY As String = .Item("COMPANY")
                                linee = "HO_CATEGORY"
                                Dim HO_CATEGORY As String = IIf(IsDBNull(.Item("HO_CATEGORY")), "", .Item("HO_CATEGORY"))
                                linee = "fix_monthly_rate"
                                Dim fix_monthly_rate As Boolean = IIf(IsDBNull(.Item("FIX_MONTHLY_RATE")), False, .Item("FIX_MONTHLY_RATE"))
                                'SEGRE CHARGES  
                                linee = "CHARGES_SBU"
                                Dim CHARGES_SBU As Decimal = GetDeductionAmount_SBU(paydatee, BIO_NO)
                                linee = "CHARGES_MP2"
                                Dim CHARGES_MP2 As Decimal = GetDeductionAmount_MP2(paydatee, BIO_NO)
                                linee = "CHARGES_CA"
                                Dim CHARGES_CA As Decimal = GetDeductionAmount_CA(paydatee, BIO_NO)
                                linee = "CHARGES_ECS"
                                Dim CHARGES_ECS As Decimal = GetDeductionAmount_ECS(paydatee, BIO_NO)
                                linee = "LOAN_SSS"
                                Dim LOAN_SSS As Decimal = GetDeductionAmount_SSSLOAN(paydatee, BIO_NO)
                                linee = "LOAN_PAGIBIG"
                                Dim LOAN_PAGIBIG As Decimal = GetDeductionAmount_PAGIBIGLOAN(paydatee, BIO_NO)
                                linee = "FULLNAME"
                                Dim OVERALL_CHARGES As Decimal = .Item("TOTAL_DEDUCTION")
                                Dim COMBINE_CHARGES As Decimal = CHARGES_SBU + CHARGES_MP2 + CHARGES_CA + CHARGES_ECS + LOAN_SSS + LOAN_PAGIBIG
                                linee = "CHARGES_OTHERS"
                                Dim CHARGES_OTHERS As Decimal = IIf(OVERALL_CHARGES >= COMBINE_CHARGES, OVERALL_CHARGES - COMBINE_CHARGES, 0)

                                linee = "BRANCH_CODE - Minimum_rate"
                                Dim Minimum_rate As Double = 0
                                Dim BRANCH_CODE As String = Nothing
                                If IsDBNull(.Item("BRANCH_CODE")) Then
                                    BRANCH_CODE = .Item("HO_CATEGORY")
                                    Minimum_rate = GetMinimumRate("CITY", "GENSAN")
                                ElseIf .Item("BRANCH_CODE").Equals("") Then
                                    BRANCH_CODE = .Item("HO_CATEGORY")
                                    Minimum_rate = GetMinimumRate("CITY", "GENSAN")
                                Else
                                    BRANCH_CODE = IIf(IsDBNull(.Item("BRANCHNAME")), "", .Item("BRANCHNAME"))
                                    Minimum_rate = GetMinimumRate("BRANCHCODE", .Item("BRANCH_CODE"))
                                End If

                                linee = "Rate"
                                Dim Rate As Decimal = IIf(IsDBNull(.Item("RATE_DAILY")) Or .Item("RATE_DAILY") = 0, Minimum_rate, .Item("RATE_DAILY"))

                                If fix_monthly_rate = True Then
                                    OVERTIME = 0
                                    HOLIDAY = 0
                                    TARDINESS = 0
                                End If

                                If COMPANY = "DALTON" Then
                                    BRANCH_CODE = IIf(.Item("BRANCH_CODE") = "" Or IsDBNull(.Item("BRANCH_CODE")), .Item("HO_CATEGORY"), TitleCase(.Item("COMPANY")) & "-" & .Item("BRANCHNAME"))
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

                                If PlusS = "PTU" Then
                                    COMPANY = "PGC"
                                    BRANCH_CODE = HO_CATEGORY
                                End If

                                Dim tempPlus As String = PlusS

                                If PlusS = "DAVAO PERFECT" Or PlusS = "GENSAN PERFECT" And HO_CATEGORY = "" Then BRANCH_CODE = "Perfect" & "-" & .Item("BRANCHNAME")
                                If PlusS = "JR PHOTO" Then BRANCH_CODE = "JR Photo" & "-" & .Item("BRANCHNAME")
                                If COMPANY = "PHOTO" Then tempPlus = $"{COMPANY}({PlusS})"

                                If PlusS = "ALL" Then
                                    COMPANY = "ALL COMPANY"
                                    BRANCH_CODE = "ALL BRANCHES"
                                End If

                                '======================= 13 MONTH ================
                                Dim MONTH_13 As Decimal = 0

                                If paydatee = $"5/15/{Today.Year}" Or paydatee = $"12/15/{Today.Year}" Then
                                    MONTH_13 = GetData_Decimal("AMOUNT", $"RECORDED_ALLOW_DEDUC WHERE BIO_NO ='{BIO_NO}' AND CATEGORY='13th Month Pay' AND PAYDATE='{paydatee}'")
                                End If

                                dt_NetPay.Rows.Add(EMP_NO, namee, BASIC.ToString("n"), OVERTIME.ToString("n"), HOLIDAY.ToString("n"), N_DIFF.ToString("n"),
                                                   PI_ECOLA_SIL.ToString("n"), TARDINESS.ToString("n"), SSS.ToString("n"), PHIC.ToString("n"), PAGIBIG.ToString("n"),
                                                   CHARGES_SBU.ToString("n"), NET_PAY.ToString("n"), BRANCH_CODE, payroll.ToString("MMMM dd, yyyy"), period, COMPANY,
                                                   HO_CATEGORY, tempPlus, MONTH_13.ToString("n"), ACCOUNTNO, CHARGES_MP2, CHARGES_CA, CHARGES_ECS, CHARGES_OTHERS,
                                                   LOAN_SSS, LOAN_PAGIBIG)

                                frmMainForm.AppProgressBar.Value += 1
                            End With
                        Next

                        progressBarEnd()
                        Dim TOTAL_EMP As Integer = GetOVERALL_COUNT("ID", paydatee)
                        Dim TOTAL_BASIC As Decimal = GetOVERALL_SUM("TOTAL_BASIC", paydatee)
                        Dim TOTAL_OT As Decimal = GetOVERALL_SUM("TOTAL_OVERTIME", paydatee)

                        Dim TOTAL_REGHOLIDAY As Decimal = GetOVERALL_SUM("TOTAL_REGHOLIDAY", paydatee)
                        Dim TOTAL_SPECHOLIDAY As Decimal = GetOVERALL_SUM("TOTAL_SPECHOLIDAY", paydatee)
                        Dim TOTAL_HOLIDAY As Decimal = TOTAL_REGHOLIDAY + TOTAL_SPECHOLIDAY

                        Dim TOTAL_NDIFF As Double = GetOVERALL_SUM("TOTAL_NIGHT_RATE", paydatee)
                        Dim TOTAL_PI_ECOLA_SIL As Double = Get_PI_ECOLA_SIL_TOTAL(paydatee)
                        Dim TOTAL_TARDINESS As Double = GetOVERALL_SUM("TOTAL_LATE_UT", paydatee)
                        Dim TOTAL_SSS As Double = GetOVERALL_SUM("SSS_COMP", paydatee)
                        Dim TOTAL_PHIC As Double = GetOVERALL_SUM("PHILHEALTH_COMP", paydatee)
                        Dim TOTAL_PAGIBIG As Double = GetOVERALL_SUM("PAGIBIG_COMP", paydatee)
                        Dim TOTAL_NET_PAY As Double = GetOVERALL_SUM("NET_PAY", paydatee)
                        Dim TOTAL_13MONTH As Double = Get13MONTH_TOTAL(paydatee)

                        Dim TOTAL_CHARGES_SBU As Decimal = GetDeductionAmount_SBU(paydatee)
                        Dim TOTAL_CHARGES_MP2 As Decimal = GetDeductionAmount_MP2(paydatee)
                        Dim TOTAL_CHARGES_CA As Decimal = GetDeductionAmount_CA(paydatee)
                        Dim TOTAL_CHARGES_ECS As Decimal = GetDeductionAmount_ECS(paydatee)
                        Dim TOTAL_LOAN_SSS As Decimal = GetDeductionAmount_SSSLOAN(paydatee)
                        Dim TOTAL_LOAN_PAGIBIG As Decimal = GetDeductionAmount_PAGIBIGLOAN(paydatee)

                        Dim TOTAL_CHARGES As Double = GetOVERALL_SUM("TOTAL_DEDUCTION", paydatee)
                        Dim TOTAL_COMBINE_CHARGES As Decimal = TOTAL_CHARGES_SBU + TOTAL_CHARGES_MP2 + TOTAL_CHARGES_CA + TOTAL_CHARGES_ECS + TOTAL_LOAN_SSS + TOTAL_LOAN_PAGIBIG
                        Dim TOTAL_CHARGES_OTHERS As Decimal = IIf(TOTAL_CHARGES >= TOTAL_COMBINE_CHARGES, TOTAL_CHARGES - TOTAL_COMBINE_CHARGES, 0)

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
                    New Microsoft.Reporting.WinForms.ReportParameter("paramNetPay", TOTAL_NET_PAY.ToString(”N”)),
                    New Microsoft.Reporting.WinForms.ReportParameter("param13Month", TOTAL_13MONTH.ToString(”N”)),
                    New Microsoft.Reporting.WinForms.ReportParameter("paramCharges_SBU", TOTAL_CHARGES_SBU.ToString(”N”)),
                    New Microsoft.Reporting.WinForms.ReportParameter("paramCharges_MP2", TOTAL_CHARGES_MP2.ToString(”N”)),
                    New Microsoft.Reporting.WinForms.ReportParameter("paramCharges_CA", TOTAL_CHARGES_CA.ToString(”N”)),
                    New Microsoft.Reporting.WinForms.ReportParameter("paramCharges_ECS", TOTAL_CHARGES_ECS.ToString(”N”)),
                    New Microsoft.Reporting.WinForms.ReportParameter("paramLoans_SSS", TOTAL_LOAN_SSS.ToString(”N”)),
                    New Microsoft.Reporting.WinForms.ReportParameter("paramLoans_PAGIBIG", TOTAL_LOAN_PAGIBIG.ToString(”N”)),
                    New Microsoft.Reporting.WinForms.ReportParameter("paramCharges_OTHERS", TOTAL_CHARGES_OTHERS.ToString(”N”))
                    }

                        Dim rds_DTR As New Microsoft.Reporting.WinForms.ReportDataSource("DataSet2", dt_NetPay)
                        ReportV_NetPay.LocalReport.DataSources.Add(rds_DTR)
                        ReportV_NetPay.LocalReport.SetParameters(paramList)
                        ReportV_NetPay.RefreshReport()

                        PlusS = Nothing
                    Else
                        MsgBox("No Records Found!", MsgBoxStyle.Exclamation, "Information")
                    End If
                End Using

            Catch ex As Exception
                Console.WriteLine($"{ex.ToString}{vbCrLf}{linee}{vbCrLf}{fullname}")
                MsgBox($"{ex.ToString}{vbCrLf}{linee}{vbCrLf}{fullname}")
            End Try
        End If
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
            GENSANPERFECT_BB = GetCount_Common("where branch_code IN ('PRG','PRX','FINEPIX','GMA','DIG','PSP','SMD')")
            GENSANPERFECT_HO = GetCount_Common("where UPPER(HO_CATEGORY) LIKE UPPER('%Photo%')")
            JRPHOTO_BB = Nothing
            JRPHOTO_HO = Nothing
            DAVAOP_BB = GetCount_Common("where branch_code IN ('PSG','KCG','ACM','TAC')")
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
            LEASING = GetCount_Common("where ho_category IN ('Leasing Admin Office', 'Construction')")
            DALTON_BR = GetDistinctCount("branch_code", "where company = 'DALTON'")
            GENSANPERFECT_BR = GetDistinctCount("branch_code", "where company = 'PHOTO'")
            DAVAOP_BR = GetDistinctCount("branch_code", "where branch_code IN ('PSG','KCG','ACM','TAC')")
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
            DR_House = GetCount_Common("where ho_category = 'Construction'")
            ConDalton = GetModify_Reports("ConDalton")
            ConPhoto = GetModify_Reports("ConPhoto")
            ConHouse = GetModify_Reports("ConHouse")
            LEASING_BR = GetCount_Common("where ho_category = 'Leasing Admin Office'")

            dt_Common.Rows.Add(DALTON_BB, DALTON_HO, GENSANPERFECT_BB, GENSANPERFECT_HO, JRPHOTO_BB, JRPHOTO_HO, DAVAOP_BB, DAVAOP_HO, PERFECOM_BB,
                               PERFECOM_HO, G3_BB, G3_HO, Seven11_ROX_BB, Seven11_ROX_HO, Seven11_POL_BB, Seven11_POL_HO, COMI_BB, COMI_HO, PBA_BB,
                               PBA_HO, KTV_BB, KTV_HO, WAVE_BB, WAVE_HO, PGC, LEASING, DALTON_BR, GENSANPERFECT_BR, DAVAOP_BR, PERFECOM_BR,
                               G3_BR, Seven11_BR, COMI_TO_FUJI_BR, M_DALTONP, M_PHOTO, M_DAVAOP, M_PERFECOM, D_DALTONP, D_PHOTO, D_DAVAOP, D_PERFECOM,
                               DR_Dalton, DR_Photo, DR_House, ConDalton, ConPhoto, ConHouse, LEASING_BR)

            Dim rds_DTR As New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt_Common)
            RptViewer_Count.LocalReport.DataSources.Add(rds_DTR)
            RptViewer_Count.RefreshReport()

        Catch ex As Exception
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
        GENSANPERFECT_BB = GetCount_Common("where branch_code IN ('PRG','PRX','FINEPIX','GMA','DIG','PSP','SMD')")
        GENSANPERFECT_HO = GetCount_Common("where UPPER(HO_CATEGORY) LIKE UPPER('%Photo%')")
        JRPHOTO_BB = Nothing
        JRPHOTO_HO = Nothing
        DAVAOP_BB = GetCount_Common("where branch_code IN ('PSG','KCG','ACM','TAC')")
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
        DAVAOP_BR = GetDistinctCount("branch_code", "where branch_code IN ('PSG','KCG','ACM','TAC')")
        PERFECOM_BR = GetDistinctCount("branch_code", "where company = 'PERFECOM'")
        G3_BR = GetDistinctCount("branch_code", "where branch_code = '3G'")
        Seven11_BR = GetDistinctCount("branch_code", "where branch_code IN ('711-ROX','711-POL')")
        COMI_TO_FUJI_BR = GetDistinctCount("branch_code", "where branch_code IN ('COMI','PBA','KTV','WAVE')")

        LEASING_BR = GetCount_Common("where ho_category = 'Leasing Admin Office'")
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

    Public Sub LoadCommonNETPAY_Print()
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
                .Columns.Add("REPORT_CATEGORY")
            End With

            Dim mysqll As String = $"Select A.*, B.*, C.*, 
                                        LASTNAME || ', ' || FIRSTNAME || 
                                        CASE
                                            WHEN MIDDLENAME IS NOT NULL AND MIDDLENAME <> '' THEN ' ' || LEFT(MIDDLENAME, 1) || '.' 
                                            ELSE ''
                                        END || 
                                        CASE 
                                            WHEN SUFFIX IS NOT NULL AND SUFFIX <> '' THEN ' ' || SUFFIX
                                            ELSE ''
                                        END AS FULLNAME
                                        From TBL_EMPLOYEE A 
                                        INNER JOIN PAYROLL_PERCENTAGEE B ON B.CATEGORY = A.COMMON_CATEGORY
                                        INNER JOIN PAYROLL_PAYOUT C ON A.BIOMETRICID = C.BIOMETRIC_ID
                                        where HO_CATEGORY = 'PGC Head Office' AND PAYDATE = '{PaydateCom_Combo.Text}' ORDER BY FULLNAME ASC"

            Using ds As DataSet = LoadSQL(mysqll, "TBL_EMPLOYEE")
                If ds.Tables(0).Rows.Count > 0 Then
                    For Each dr In ds.Tables(0).Rows
                        With dr

                            Dim PAYROLL As DateTime = PaydateCom_Combo.Text

                            '============================= NAME AND ATTENDANCE ============================  
                            Dim namee As String = .Item("FULLNAME")
                            Dim CATEGORY As String = .Item("CATEGORY")
                            Dim TOTALS As Decimal = 0
                            Dim DALTON As String = .Item("DALTON")
                            Dim PHOTO As String = .Item("PHOTO")
                            Dim DAVAOP As String = .Item("DAVAOP")
                            Dim PERFECOM As String = .Item("PERFECOM")
                            Dim G3 As String = .Item("G3")
                            Dim Seven11 As String = .Item("Seven11")
                            Dim COMI_TO_FUJI As String = .Item("COMI_TO_FUJI")
                            Dim HOUSEHOLD As String = .Item("HOUSEHOLD")
                            Dim LEASING As String = .Item("LEASING")

                            If .ITEM("BIOMETRICID") = "2788" Then ' MADERA
                                HOUSEHOLD = 50 / 100
                                DALTON = (50 * DALTON) / 100
                                PHOTO = (50 * PHOTO) / 100
                                DAVAOP = (50 * DAVAOP) / 100
                                PERFECOM = (50 * PERFECOM) / 100
                                G3 = (50 * G3) / 100
                                Seven11 = (50 * Seven11) / 100
                                COMI_TO_FUJI = (50 * COMI_TO_FUJI) / 100
                                LEASING = (50 * LEASING) / 100
                            End If

                            If CommonCat_Combo.SelectedIndex = 0 Then
                                TOTALS = .Item("GROSS_AMOUNT")
                            ElseIf CommonCat_Combo.SelectedIndex = 1 Then
                                TOTALS = .Item("NET_PAY")
                            ElseIf CommonCat_Combo.SelectedIndex = 2 Then
                                TOTALS = .Item("TOTAL_DEDUCTION")
                            ElseIf CommonCat_Combo.SelectedIndex = 3 Then
                                TOTALS = GetData_Decimal("AMOUNT", $"RECORDED_ALLOW_DEDUC WHERE BIO_NO ='{ .ITEM("BIO_NO")}' AND CATEGORY='13th Month Pay' AND PAYDATE='{PAYROLL.ToShortDateString}'")
                            End If

                            dt_CommonDis.Rows.Add(namee, CATEGORY, TOTALS.ToString("n"), DALTON, PHOTO, DAVAOP,
                                           PERFECOM, G3, Seven11, COMI_TO_FUJI, HOUSEHOLD, LEASING, Format(PAYROLL, "MMMM dd, yyyy").ToUpper(), CommonCat_Combo.Text)

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

            Dim mysql As String = $"Select A.*, B.*, C.*, 
                                        LASTNAME || ', ' || FIRSTNAME || 
                                        CASE
                                            WHEN MIDDLENAME IS NOT NULL AND MIDDLENAME <> '' THEN ' ' || LEFT(MIDDLENAME, 1) || '.' 
                                            ELSE ''
                                        END || 
                                        CASE 
                                            WHEN SUFFIX IS NOT NULL AND SUFFIX <> '' THEN ' ' || SUFFIX
                                            ELSE ''
                                        END AS FULLNAME
                                        From TBL_EMPLOYEE A 
                                        LEFT JOIN PAYROLL_PERCENTAGEE B ON B.CATEGORY = A.COMMON_CATEGORY
                                        INNER JOIN PAYROLL_PAYOUT C ON A.BIOMETRICID = C.BIOMETRIC_ID
                                        where HO_CATEGORY IN ('Construction', 'Leasing Admin Office') AND PAYDATE = '{PaydateCom_Combo.Text}' ORDER BY FULLNAME ASC"

            Using dss As DataSet = LoadSQL(mysql, "TBL_EMPLOYEE")
                If dss.Tables(0).Rows.Count > 0 Then
                    For Each drR In dss.Tables(0).Rows
                        With drR
                            Try

                                Dim dateStarted As DateTime = PaydateCom_Combo.Text

                                '============================= NAME AND ATTENDANCE ============================  
                                Dim namee As String = .Item("FULLNAME")
                                Dim CATEGORY As String = IIf(IsDBNull(.Item("CATEGORY")), Nothing, .Item("CATEGORY"))
                                Dim TOTALS As Decimal = 0
                                Dim DALTON As Double = IIf(IsDBNull(.Item("DALTON")), 0, .Item("DALTON"))
                                Dim PHOTO As Double = IIf(IsDBNull(.Item("PHOTO")), 0, .Item("PHOTO"))
                                Dim DAVAOP As Double = IIf(IsDBNull(.Item("DAVAOP")), 0, .Item("DAVAOP"))
                                Dim PERFECOM As Double = IIf(IsDBNull(.Item("PERFECOM")), 0, .Item("PERFECOM"))
                                Dim G3 As Double = IIf(IsDBNull(.Item("G3")), 0, .Item("G3"))
                                Dim Seven11 As Double = IIf(IsDBNull(.Item("Seven11")), 0, .Item("Seven11"))
                                Dim COMI_TO_FUJI As Double = IIf(IsDBNull(.Item("COMI_TO_FUJI")), 0, .Item("COMI_TO_FUJI"))
                                Dim HOUSEHOLD As Double = IIf(IsDBNull(.Item("HOUSEHOLD")), 0, .Item("HOUSEHOLD"))
                                Dim LEASING As Double = IIf(IsDBNull(.Item("LEASING")), 0, .Item("LEASING"))

                                If CommonCat_Combo.SelectedIndex = 0 Then
                                    TOTALS = .Item("GROSS_AMOUNT")
                                ElseIf CommonCat_Combo.SelectedIndex = 1 Then
                                    TOTALS = .Item("NET_PAY")
                                ElseIf CommonCat_Combo.SelectedIndex = 2 Then
                                    TOTALS = .Item("TOTAL_DEDUCTION")
                                ElseIf CommonCat_Combo.SelectedIndex = 3 Then
                                    TOTALS = GetData_Decimal("AMOUNT", $"RECORDED_ALLOW_DEDUC WHERE BIO_NO ='{ .ITEM("BIO_NO")}' AND CATEGORY='13th Month Pay' AND PAYDATE='{dateStarted.ToShortDateString}'")
                                End If

                                dt_ComLeasingDis.Rows.Add(namee, CATEGORY, TOTALS.ToString("n"), DALTON, PHOTO, DAVAOP,
                                                   PERFECOM, G3, Seven11, COMI_TO_FUJI, HOUSEHOLD, LEASING)
                            Catch ex As Exception
                                Console.WriteLine(ex.ToString)
                            End Try

                        End With
                    Next
                End If
            End Using

            Dim rds_leasing As New Microsoft.Reporting.WinForms.ReportDataSource("DataSet2", dt_ComLeasingDis)
            RptViewer_Common.LocalReport.DataSources.Add(rds_common)
            RptViewer_Common.LocalReport.DataSources.Add(rds_leasing)
            RptViewer_Common.RefreshReport()

        Catch ex As Exception
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub LoadSummary_Print()

        RptViewer_Summary.LocalReport.DataSources.Clear()

        Try

            Dim PAYDATEE As String = SumPaydate_Combo.Text

            Dim Photo_GensanJR As New Microsoft.Reporting.WinForms.ReportDataSource("Photo_GensanJR", LoadDataTable_GensanJR(PAYDATEE))
            Dim Photo_Davao As New Microsoft.Reporting.WinForms.ReportDataSource("Photo_Davao", LoadDataTable_DavaoPerfect(PAYDATEE))
            Dim Dalton As New Microsoft.Reporting.WinForms.ReportDataSource("Dalton", LoadDataTable_Dalton(PAYDATEE))
            Dim Perfecom As New Microsoft.Reporting.WinForms.ReportDataSource("Perfecom", LoadDataTable_Perfecom(PAYDATEE))
            Dim PG_UY As New Microsoft.Reporting.WinForms.ReportDataSource("PG_UY", LoadDataTable_PG_UY(PAYDATEE))
            Dim Household As New Microsoft.Reporting.WinForms.ReportDataSource("Household", LoadDataTable_Household(PAYDATEE))
            Dim PG_Realty As New Microsoft.Reporting.WinForms.ReportDataSource("PG_Realty", LoadDataTable_Realty(PAYDATEE))

            Dim paramList As New List(Of Microsoft.Reporting.WinForms.ReportParameter) From {
                    New Microsoft.Reporting.WinForms.ReportParameter("paramPhotoG", Get_PGC("PHOTO", PAYDATEE).ToString(”N”)),
                    New Microsoft.Reporting.WinForms.ReportParameter("paramPhotoD", Get_PGC("DAVAOP", PAYDATEE).ToString(”N”)),
                    New Microsoft.Reporting.WinForms.ReportParameter("paramDalton", Get_PGC("DALTON", PAYDATEE).ToString(”N”)),
                    New Microsoft.Reporting.WinForms.ReportParameter("paramPerfecom", Get_PGC("PERFECOM", PAYDATEE).ToString(”N”)),
                    New Microsoft.Reporting.WinForms.ReportParameter("paramPGUY", Get_PGC("COMI_TO_FUJI", PAYDATEE).ToString(”N”))
                    }

            RptViewer_Summary.LocalReport.DataSources.Add(Photo_GensanJR)
            RptViewer_Summary.LocalReport.DataSources.Add(Photo_Davao)
            RptViewer_Summary.LocalReport.DataSources.Add(Dalton)
            RptViewer_Summary.LocalReport.DataSources.Add(Perfecom)
            RptViewer_Summary.LocalReport.DataSources.Add(PG_UY)
            RptViewer_Summary.LocalReport.DataSources.Add(Household)
            RptViewer_Summary.LocalReport.DataSources.Add(PG_Realty)
            RptViewer_Summary.LocalReport.SetParameters(paramList)
            RptViewer_Summary.RefreshReport()

        Catch ex As Exception
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub LoadRemittance()

        Rpt_Distribution.LocalReport.DataSources.Clear()
        Dim PAYDATE As DateTime = Rem_Paydate_Combo.Text

        Try

            Dim FORMNAME As String = ""
            Dim str As String = ""
            Dim report As String = "WindowsApp1.rpt_Remittance.rdlc"
            Dim DATASOURCE As Microsoft.Reporting.WinForms.ReportDataSource = Nothing

            If RemCompany_Combo.SelectedIndex = 0 Then
                str = $"AND HO_CATEGORY LIKE '%Photo%'"
            ElseIf RemCompany_Combo.SelectedIndex = 1 Then
                str = $"AND PHOTO_CATEGORY = 'GENSAN PERFECT'"
            ElseIf RemCompany_Combo.SelectedIndex = 2 Then
                str = $"AND PHOTO_CATEGORY = 'DAVAO PERFECT'"
            ElseIf RemCompany_Combo.SelectedIndex = 3 Then
                str = $"AND PHOTO_CATEGORY = 'JR PHOTO' "
            ElseIf RemCompany_Combo.SelectedIndex = 4 Then
                str = $"AND (COMPANY = 'DALTON' OR HO_CATEGORY LIKE '%Dalton%')"
            ElseIf RemCompany_Combo.SelectedIndex = 5 Then
                str = $"AND (COMPANY = 'PERFECOM' OR HO_CATEGORY LIKE '%Perfecom%')"
            ElseIf RemCompany_Combo.SelectedIndex = 6 Then
                str = $"AND (COMPANY = 'P&G UY' OR HO_CATEGORY LIKE '%GHS%')"
            ElseIf RemCompany_Combo.SelectedIndex = 7 Then
                str = $"AND HO_CATEGORY IN ('Leasing Admin Office','Construction')"
            ElseIf RemCompany_Combo.SelectedIndex = 8 Then
                str = $"AND HO_CATEGORY = 'PGC Head Office'"
            ElseIf RemCompany_Combo.SelectedIndex = 9 Then
                str = ""
                report = "WindowsApp1.rpt_RemittanceALL.rdlc"
            End If

            If RemCat_Combo.SelectedIndex = 0 Then

                DATASOURCE = New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", Load_Remittance_SSS(Rem_Paydate_Combo.Text, str))
                FORMNAME = $"SSS Remittance for {RemCompany_Combo.Text} - {PAYDATE.ToString("MMMM dd, yyyy")}"

            ElseIf RemCat_Combo.SelectedIndex = 1 Then

                DATASOURCE = New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", Load_Remittance_Pagibig(Rem_Paydate_Combo.Text, str))
                FORMNAME = $"Pagibig Remittance {RemCompany_Combo.Text} - {PAYDATE.ToString("MMMM dd, yyyy")}"

            ElseIf RemCat_Combo.SelectedIndex = 2 Then

                DATASOURCE = New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", Load_Remittance_PhilHealth(Rem_Paydate_Combo.Text, str))
                FORMNAME = $"PhilHealth Remittance {RemCompany_Combo.Text} - {PAYDATE.ToString("MMMM dd, yyyy")}"

            End If

            Dim paramList As New List(Of Microsoft.Reporting.WinForms.ReportParameter) From {
                        New Microsoft.Reporting.WinForms.ReportParameter("paramFormName", FORMNAME)
                        }

            Rpt_Distribution.LocalReport.ReportEmbeddedResource = report
            Rpt_Distribution.LocalReport.DataSources.Add(DATASOURCE)
            Rpt_Distribution.LocalReport.SetParameters(paramList)
            Rpt_Distribution.RefreshReport()

        Catch ex As Exception
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub LoadLoans()

        Rpt_Loans.LocalReport.DataSources.Clear()
        Dim PAYDATE As DateTime = LoanPaydate_Combo.Text

        Try

            Dim FORMNAME As String = ""
            Dim str As String = ""
            Dim report As String = "WindowsApp1.rpt_Loans.rdlc"
            Dim DATASOURCE As Microsoft.Reporting.WinForms.ReportDataSource = Nothing

            If LoanCompany_Combo.SelectedIndex = 0 Then
                str = $"AND HO_CATEGORY LIKE '%Photo%'"
            ElseIf LoanCompany_Combo.SelectedIndex = 1 Then
                str = $"AND PHOTO_CATEGORY = 'GENSAN PERFECT'"
            ElseIf LoanCompany_Combo.SelectedIndex = 2 Then
                str = $"AND PHOTO_CATEGORY = 'DAVAO PERFECT'"
            ElseIf LoanCompany_Combo.SelectedIndex = 3 Then
                str = $"AND PHOTO_CATEGORY = 'JR PHOTO' "
            ElseIf LoanCompany_Combo.SelectedIndex = 4 Then
                str = $"AND (COMPANY = 'DALTON' OR HO_CATEGORY LIKE '%Dalton%')"
            ElseIf LoanCompany_Combo.SelectedIndex = 5 Then
                str = $"AND (COMPANY = 'PERFECOM' OR HO_CATEGORY LIKE '%Perfecom%')"
            ElseIf LoanCompany_Combo.SelectedIndex = 6 Then
                str = $"AND (COMPANY = 'P&G UY' OR HO_CATEGORY LIKE '%GHS%')"
            ElseIf LoanCompany_Combo.SelectedIndex = 7 Then
                str = $"AND HO_CATEGORY IN ('Leasing Admin Office','Construction')"
            ElseIf LoanCompany_Combo.SelectedIndex = 8 Then
                str = $"AND HO_CATEGORY = 'PGC Head Office'"
            Else
                str = ""
                report = "WindowsApp1.rpt_LoansALL.rdlc"
            End If

            If LoanCat_Combo.SelectedIndex = 0 Then

                DATASOURCE = New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", Load_Loan_Report(LoanPaydate_Combo.Text, str, LoanCat_Combo.Text))
                FORMNAME = $"SSS Loan for {LoanCompany_Combo.Text} - {PAYDATE.ToString("MMMM dd, yyyy")}"

            ElseIf LoanCat_Combo.SelectedIndex = 1 Then

                DATASOURCE = New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", Load_Loan_Report(LoanPaydate_Combo.Text, str, LoanCat_Combo.Text))
                FORMNAME = $"Pagibig Loan {LoanCompany_Combo.Text} - {PAYDATE.ToString("MMMM dd, yyyy")}"

            End If

            Dim paramList As New List(Of Microsoft.Reporting.WinForms.ReportParameter) From {
                        New Microsoft.Reporting.WinForms.ReportParameter("paramFormName", FORMNAME)
                        }

            Rpt_Loans.LocalReport.ReportEmbeddedResource = report
            Rpt_Loans.LocalReport.DataSources.Add(DATASOURCE)
            Rpt_Loans.LocalReport.SetParameters(paramList)
            Rpt_Loans.RefreshReport()

        Catch ex As Exception
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub LoadCostDistribution()
        Rpt_CostContrib.LocalReport.DataSources.Clear()
        Dim linee As String = Nothing

        Try

            Dim mysql As String
            Dim PAYDATE As String = CostPaydate_Combo.Text
            Dim PAYROLL As DateTime = CostPaydate_Combo.Text

            Dim FORMNAME As String = "2nd PERIOD"

            If PAYROLL.Day = 15 Then
                FORMNAME = "1ST PERIOD"
            End If

            FORMNAME = $"{(PAYROLL.ToString("MMMM dd, yyyy")).ToUpper} - {FORMNAME}"

            Dim dt_Cost As New DataTable()
            With dt_Cost
                .Columns.Add("COMPANY")
                .Columns.Add("BRANCH")
                .Columns.Add("NAME")
                .Columns.Add("AMOUNT")
                .Columns.Add("CATEGORY")
            End With

            '========================================= RECORDED_ALLOW_DEDUC ================================================
            mysql = $"Select 
                        CASE 
                            WHEN BRANCHCODE IS NULL THEN ''
                            WHEN BRANCHCODE = '' THEN ''
                            ELSE BRANCHCODE 
                        END AS BRANCH_CODE,
                        CASE 
                            WHEN HO_CATEGORY IS NULL THEN ''
                            WHEN HO_CATEGORY = '' THEN ''
                            ELSE HO_CATEGORY 
                        END AS HO_CATEGORY,  
                        C.CATEGORY, 
                        TRANSAC_NAME,  
                        COMPANY, 
                        SUM(AMOUNT) AS TOTS 
                    From 
                     TBL_EMPLOYEE A 
                    LEFT JOIN 
                     RECORDED_ALLOW_DEDUC C ON C.BIO_NO = A.BIOMETRICID and C.PAYDATE = '{PAYDATE}'    
                    GROUP BY 
                     BRANCH_CODE, COMPANY, C.CATEGORY, TRANSAC_NAME, HO_CATEGORY"

            TestingScript_String(mysql)
            Using ds As DataSet = LoadSQL(mysql, "TBL_EMPLOYEE")
                If ds.Tables(0).Rows.Count > 0 Then
                    progressBarStart(ds.Tables(0).Rows.Count)
                    For Each dr In ds.Tables(0).Rows
                        With dr

                            linee = "COMPANY - 1"
                            Dim COMPANY As String = IIf(IsDBNull(.Item("COMPANY")), "", .Item("COMPANY"))
                            linee = "BRANCHCODE - 1"
                            Dim BRANCHCODE As String = IIf(IsDBNull(.Item("BRANCH_CODE")), "", .Item("BRANCH_CODE"))
                            linee = "BRANCHNAME - 1"
                            Dim BRANCHNAME As String = GET_STRING("PAYROLL_CITY_BRANCH", "BRANCHNAME", $"BRANCHCODE = '{BRANCHCODE}'")
                            linee = "CATEGORY - 1"
                            Dim CATEGORY As String = IIf(IsDBNull(.Item("CATEGORY")), "", .Item("CATEGORY"))
                            linee = "DC_Amount - 1"
                            Dim DC_Amount As Decimal = IIf(IsDBNull(.Item("TOTS")), 0, .Item("TOTS"))
                            linee = $"Debit_Credit - 1 {COMPANY} - {BRANCHCODE} - {CATEGORY}"
                            Dim Debit_Credit As String = IIf(IsDBNull(.Item("TRANSAC_NAME")), "", .Item("TRANSAC_NAME"))

                            If BRANCHCODE = Nothing Then
                                linee = "BRANCHNAME = HO_CATEGORY - 1"
                                BRANCHNAME = IIf(IsDBNull(.Item("HO_CATEGORY")), "", CStr(.Item("HO_CATEGORY")).TrimEnd)
                            End If

                            If CATEGORY.ToUpper = "BASIC PAY" Or CATEGORY.ToUpper = "BASIC REFUND" Then
                                CATEGORY = "Basic Refund"
                            End If

                            If DC_Amount <> 0 Then

                                If COMPANY <> "" Then
                                    BRANCHNAME = $"{COMPANY} - {BRANCHNAME}"
                                End If

                                dt_Cost.Rows.Add(COMPANY, BRANCHNAME, CATEGORY, DC_Amount, Debit_Credit)
                            End If

                        End With

                        frmMainForm.AppProgressBar.Value += 1
                    Next
                    progressBarEnd()
                End If
            End Using

            '========================================= PAYROLL_COSTDISTRIBUTION ================================================
            mysql = $"SELECT   
                        CASE 
                            WHEN BRANCHCODE IS NULL THEN ''
                            WHEN BRANCHCODE = '' THEN ''
                            ELSE BRANCHCODE 
                        END AS BRANCH_CODE,
                        CASE 
                            WHEN HO_CATEGORY IS NULL THEN ''
                            WHEN HO_CATEGORY = '' THEN ''
                            ELSE HO_CATEGORY 
                        END AS HO_CATEGORY, 
                        COMPANY,  
                        SUM((SELECT COALESCE(SUM(TOTAL_BASIC), 0) FROM PAYROLL_PAYOUT WHERE BIOMETRIC_ID = A.BIOMETRICID AND PAYDATE = '{PAYDATE}')) AS BASIC,
                        SUM((SELECT COALESCE(SUM(TOTAL_OVERTIME), 0) FROM PAYROLL_PAYOUT WHERE BIOMETRIC_ID = A.BIOMETRICID AND PAYDATE = '{PAYDATE}')) AS OT,
                        SUM((SELECT COALESCE(SUM(SSS_ER), 0) FROM PAYROLL_PAYOUT WHERE BIOMETRIC_ID = A.BIOMETRICID AND PAYDATE = '{PAYDATE}')) AS SSS_ER,
                        SUM((SELECT COALESCE(SUM(SSS_EC), 0) FROM PAYROLL_PAYOUT WHERE BIOMETRIC_ID = A.BIOMETRICID AND PAYDATE = '{PAYDATE}')) AS SSS_EC,
                        SUM((SELECT COALESCE(SUM(PAGIBIG_COMP), 0) FROM PAYROLL_PAYOUT WHERE BIOMETRIC_ID = A.BIOMETRICID AND PAYDATE = '{PAYDATE}')) AS HDMF,
                        SUM((SELECT COALESCE(SUM(PHILHEALTH_COMP), 0) FROM PAYROLL_PAYOUT WHERE BIOMETRIC_ID = A.BIOMETRICID AND PAYDATE = '{PAYDATE}')) AS PHILH,
                        SUM((SELECT COALESCE(SUM(TOTAL_REGHOLIDAY), 0) FROM PAYROLL_PAYOUT WHERE BIOMETRIC_ID = A.BIOMETRICID AND PAYDATE = '{PAYDATE}')) AS REGHOLIDAY,
                        SUM((SELECT COALESCE(SUM(TOTAL_SPECHOLIDAY), 0) FROM PAYROLL_PAYOUT WHERE BIOMETRIC_ID = A.BIOMETRICID AND PAYDATE = '{PAYDATE}')) AS SPECHOLIDAY,
                        SUM((SELECT COALESCE(SUM(TOTAL_NIGHT_RATE), 0) FROM PAYROLL_PAYOUT WHERE BIOMETRIC_ID = A.BIOMETRICID AND PAYDATE = '{PAYDATE}')) AS NIGHT_RATE,
                        SUM((SELECT COALESCE(SUM(TOTAL_LATE_UT), 0) FROM PAYROLL_PAYOUT WHERE BIOMETRIC_ID = A.BIOMETRICID AND PAYDATE = '{PAYDATE}')) AS LATE_UT,
                        SUM((SELECT COALESCE(SUM(SSS_ER), 0) FROM PAYROLL_PAYOUT WHERE BIOMETRIC_ID = A.BIOMETRICID AND PAYDATE = '{PAYDATE}') +
                        (SELECT COALESCE(SUM(SSS_COMP), 0) FROM PAYROLL_PAYOUT WHERE BIOMETRIC_ID = A.BIOMETRICID AND PAYDATE = '{PAYDATE}')) AS SSS_PAYABLE,
                        SUM((SELECT COALESCE(SUM(PAGIBIG_COMP), 0) FROM PAYROLL_PAYOUT WHERE BIOMETRIC_ID = A.BIOMETRICID AND PAYDATE = '{PAYDATE}') * 2) AS HDMF_PAYABLE,
                        SUM((SELECT COALESCE(SUM(PHILHEALTH_COMP), 0) FROM PAYROLL_PAYOUT WHERE BIOMETRIC_ID = A.BIOMETRICID AND PAYDATE = '{PAYDATE}') * 2) AS PHILH_PAYABLE,
                        SUM((SELECT COALESCE(SUM(NET_PAY), 0) FROM PAYROLL_PAYOUT WHERE BIOMETRIC_ID = A.BIOMETRICID AND PAYDATE = '{PAYDATE}')) AS NETPAY
                    FROM
                        TBL_EMPLOYEE A   
                    GROUP BY 
                        COMPANY, BRANCH_CODE, HO_CATEGORY;"

            TestingScript_String(mysql)
            Using dss As DataSet = LoadSQL(mysql, "TBL_EMPLOYEE")
                If dss.Tables(0).Rows.Count > 0 Then
                    progressBarStart(dss.Tables(0).Rows.Count)
                    For Each dr In dss.Tables(0).Rows
                        With dr

                            linee = "COMPANY - 2"
                            Dim COMPANY As String = IIf(IsDBNull(.Item("COMPANY")), "", .Item("COMPANY"))
                            linee = "BRANCHCODE - 2"
                            Dim BRANCHCODE As String = IIf(IsDBNull(.Item("BRANCH_CODE")), "", .Item("BRANCH_CODE"))
                            linee = "BRANCHNAME - 2"
                            Dim BRANCHNAME As String = GET_STRING("PAYROLL_CITY_BRANCH", "BRANCHNAME", $"BRANCHCODE = '{BRANCHCODE}'")

                            If BRANCHCODE = Nothing Then
                                linee = "BRANCHNAME = HO_CATEGORY - 2"
                                BRANCHNAME = CStr(.Item("HO_CATEGORY")).TrimEnd
                            End If

                            If COMPANY <> "" Then
                                BRANCHNAME = $"{COMPANY} - {BRANCHNAME}"
                            End If

                            Dim TOTAL_BASIC As Decimal = .Item("BASIC")

                            If TOTAL_BASIC <> 0 Then
                                dt_Cost.Rows.Add(COMPANY, BRANCHNAME, "Basic Pay", .Item("BASIC"), "DEBIT")

                                dt_Cost.Rows.Add(COMPANY, BRANCHNAME, "Regular Overtime", .Item("OT"), "DEBIT")

                                dt_Cost.Rows.Add(COMPANY, BRANCHNAME, "SSS Employer Share", .Item("SSS_ER"), "DEBIT")

                                dt_Cost.Rows.Add(COMPANY, BRANCHNAME, "ECC", .Item("SSS_EC"), "DEBIT")

                                dt_Cost.Rows.Add(COMPANY, BRANCHNAME, "HDMF Employer Share", .Item("HDMF"), "DEBIT")

                                dt_Cost.Rows.Add(COMPANY, BRANCHNAME, "Phil Health Employer Share", .Item("PHILH"), "DEBIT")

                                dt_Cost.Rows.Add(COMPANY, BRANCHNAME, "Regular Holiday", .Item("REGHOLIDAY"), "DEBIT")

                                dt_Cost.Rows.Add(COMPANY, BRANCHNAME, "Special Holiday", .Item("SPECHOLIDAY"), "DEBIT")

                                dt_Cost.Rows.Add(COMPANY, BRANCHNAME, "Night Premium", .Item("NIGHT_RATE"), "DEBIT")

                                dt_Cost.Rows.Add(COMPANY, BRANCHNAME, "EC PAYABLE", .Item("SSS_EC"), "CREDIT")

                                dt_Cost.Rows.Add(COMPANY, BRANCHNAME, "LATE", .Item("LATE_UT"), "CREDIT")

                                dt_Cost.Rows.Add(COMPANY, BRANCHNAME, "SSS PAYABLE", .Item("SSS_PAYABLE"), "CREDIT")

                                dt_Cost.Rows.Add(COMPANY, BRANCHNAME, "HDMF PAYABLE", .Item("HDMF_PAYABLE"), "CREDIT")

                                dt_Cost.Rows.Add(COMPANY, BRANCHNAME, "PHIL HEALTH PAYABLE", .Item("PHILH_PAYABLE"), "CREDIT")

                                dt_Cost.Rows.Add(COMPANY, BRANCHNAME, "CASH IN BANK", .Item("NETPAY"), "CREDIT")
                            End If

                        End With

                        frmMainForm.AppProgressBar.Value += 1
                    Next
                    progressBarEnd()
                End If
            End Using

            Dim paramList As New List(Of Microsoft.Reporting.WinForms.ReportParameter) From {
                    New Microsoft.Reporting.WinForms.ReportParameter("paramPaydate", FORMNAME)
                    }

            Dim DATASOURCE As New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt_Cost)
            Rpt_CostContrib.LocalReport.DataSources.Add(DATASOURCE)
            Rpt_CostContrib.LocalReport.SetParameters(paramList)
            Rpt_CostContrib.RefreshReport()

        Catch ex As Exception
            MessageBox.Show($"{ex.Message} {vbCrLf} {linee}", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
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

        If Company_Combo.SelectedIndex = 0 Then '=== ALL COMPANY
            NetBranch_Combo.Items.Clear()
            Dim mysql = $"Select A.*, B.*, C.*, B.BRANCHCODE as BRANCH_CODE,
                                 LASTNAME || ', ' || FIRSTNAME || 
                                        CASE
                                            WHEN MIDDLENAME IS NOT NULL AND MIDDLENAME <> '' THEN ' ' || LEFT(MIDDLENAME, 1) || '.' 
                                            ELSE ''
                                        END || 
                                        CASE 
                                            WHEN SUFFIX IS NOT NULL AND SUFFIX <> '' THEN ' ' || SUFFIX
                                            ELSE ''
                                        END AS FULLNAME 
                         From PAYROLL_PAYOUT A 
                         inner JOIN TBL_EMPLOYEE B ON B.BIOMETRICID = A.BIOMETRIC_ID 
                         left JOIN PAYROLL_CITY_BRANCH C ON C.BRANCHCODE = B.BRANCHCODE
                         where A.PAYDATE  = '{PaydateNet_ComboB.Text}' ORDER BY BRANCHNAME"
            PlusS = "ALL"

            LoadNet_Print(mysql)
        ElseIf Company_Combo.SelectedIndex = 1 Then '=== PHOTO
            NetBranch_Combo.Items.Clear()
            NetBranch_Combo.Items.Insert(0, "Davao Perfect")
            NetBranch_Combo.Items.Insert(1, "JR Photo")
            NetBranch_Combo.Items.Insert(2, "Gensan Perfect")
            NetBranch_Combo.Items.Insert(3, "Photo Head Office")

        ElseIf Company_Combo.SelectedIndex = 2 Then '=== P&G UY
            NetBranch_Combo.Items.Clear()
            NetBranch_Combo.Items.Insert(0, "3G")
            NetBranch_Combo.Items.Insert(1, "7Eleven")
            NetBranch_Combo.Items.Insert(2, "COMI-WAVE")
            NetBranch_Combo.Items.Insert(3, "P&G UY Head Office")

        ElseIf Company_Combo.SelectedIndex = 3 Then '=== DALTON
            NetBranch_Combo.Items.Clear()
            NetBranch_Combo.Items.Insert(0, "Dalton Head Office")
            NetBranch_Combo.Items.Insert(1, "Dalton Branch")

        ElseIf Company_Combo.SelectedIndex = 4 Then '=== PERFECOM 

            NetBranch_Combo.Items.Clear()
            Dim mysql = $"Select A.*, B.*, C.*, B.BRANCHCODE as BRANCH_CODE,
                                 LASTNAME || ', ' || FIRSTNAME || 
                                        CASE
                                            WHEN MIDDLENAME IS NOT NULL AND MIDDLENAME <> '' THEN ' ' || LEFT(MIDDLENAME, 1) || '.' 
                                            ELSE ''
                                        END || 
                                        CASE 
                                            WHEN SUFFIX IS NOT NULL AND SUFFIX <> '' THEN ' ' || SUFFIX
                                            ELSE ''
                                        END AS FULLNAME 
                        From PAYROLL_PAYOUT A 
                        inner JOIN TBL_EMPLOYEE B ON B.BIOMETRICID = A.BIOMETRIC_ID 
                        left JOIN PAYROLL_CITY_BRANCH C ON C.BRANCHCODE = B.BRANCHCODE
                        where A.PAYDATE  = '{PaydateNet_ComboB.Text}' 
                             and  (B.COMPANY  = 'PERFECOM' OR B.HO_CATEGORY In ('Perfecom Admin Office','Perfecom Admin Operation'))
                        ORDER BY B.BRANCHCODE asc"
            PlusS = "PERFECOM"

            LoadNet_Print(mysql)
        ElseIf Company_Combo.SelectedIndex = 5 Then '=== PTU REALTY

            NetBranch_Combo.Items.Clear()

            Dim mysql = $"Select A.*, B.*, C.*, B.BRANCHCODE as BRANCH_CODE,
                                 LASTNAME || ', ' || FIRSTNAME || 
                                        CASE
                                            WHEN MIDDLENAME IS NOT NULL AND MIDDLENAME <> '' THEN ' ' || LEFT(MIDDLENAME, 1) || '.' 
                                            ELSE ''
                                        END || 
                                        CASE 
                                            WHEN SUFFIX IS NOT NULL AND SUFFIX <> '' THEN ' ' || SUFFIX
                                            ELSE ''
                                        END AS FULLNAME 
                        From PAYROLL_PAYOUT A 
                        inner JOIN TBL_EMPLOYEE B ON B.BIOMETRICID = A.BIOMETRIC_ID 
                        left JOIN PAYROLL_CITY_BRANCH C ON C.BRANCHCODE = B.BRANCHCODE
                        where A.PAYDATE  = '{PaydateNet_ComboB.Text}' AND B.HO_CATEGORY IN ('Construction' , 'Leasing Admin Office') "

            PlusS = "PTU"
            LoadNet_Print(mysql)
        ElseIf Company_Combo.SelectedIndex = 6 Then '=== PGC HEAD OFFICE

            NetBranch_Combo.Items.Clear()

            Dim mysql = $"Select B.*, C.*,
                                 LASTNAME || ', ' || FIRSTNAME || 
                                        CASE
                                            WHEN MIDDLENAME IS NOT NULL AND MIDDLENAME <> '' THEN ' ' || LEFT(MIDDLENAME, 1) || '.' 
                                            ELSE ''
                                        END || 
                                        CASE 
                                            WHEN SUFFIX IS NOT NULL AND SUFFIX <> '' THEN ' ' || SUFFIX
                                            ELSE ''
                                        END AS FULLNAME 
                        From PAYROLL_PAYOUT A 
                        inner JOIN TBL_EMPLOYEE B ON B.BIOMETRICID = A.BIOMETRIC_ID 
                        left JOIN PAYROLL_CITY_BRANCH C ON C.BRANCHCODE = B.BRANCHCODE
                        where A.PAYDATE  = '{PaydateNet_ComboB.Text}' AND B.HO_CATEGORY = 'PGC Head Office'"

            PlusS = "PGC"
            LoadNet_Print(mysql)
        End If
    End Sub

    Private Sub NetBranch_Combo_SelectedValueChanged(sender As Object, e As EventArgs) Handles NetBranch_Combo.SelectedValueChanged
        If PaydateNet_ComboB.SelectedIndex >= 0 Then

            Dim paydatee As String = PaydateNet_ComboB.Text
            Dim mysql As String = ""

            If Company_Combo.SelectedIndex = 1 Then '=== PHOTO

                If PaydateNet_ComboB.SelectedIndex >= 0 Then
                    If NetBranch_Combo.SelectedIndex = 0 Then '=== Davao Perfect 

                        mysql = $"Select * From PAYROLL_PAYOUT A 
                                        inner JOIN TBL_EMPLOYEE B ON B.BIOMETRICID = A.BIOMETRIC_ID 
                                        left JOIN PAYROLL_CITY_BRANCH C ON C.BRANCHCODE = B.BRANCHCODE
                                        where A.PAYDATE  = '{paydatee}' and B.COMPANY  = 'PHOTO' and B.PHOTO_CATEGORY = 'DAVAO PERFECT'
                                        Order by B.BRANCHCODE"

                        PlusS = "DAVAO PERFECT"

                    ElseIf NetBranch_Combo.SelectedIndex = 1 Then '=== JR Photo 

                        mysql = $"Select * From PAYROLL_PAYOUT A 
                                        inner JOIN TBL_EMPLOYEE B ON B.BIOMETRICID = A.BIOMETRIC_ID 
                                        left JOIN PAYROLL_CITY_BRANCH C ON C.BRANCHCODE = B.BRANCHCODE
                                        where A.PAYDATE  = '{paydatee}' and B.COMPANY  = 'PHOTO' and B.PHOTO_CATEGORY = 'JR PHOTO'
                                        Order by B.BRANCHCODE "

                        PlusS = "JR PHOTO"
                    ElseIf NetBranch_Combo.SelectedIndex = 2 Then '=== Gensan Perfect 

                        mysql = $"Select * From PAYROLL_PAYOUT A 
                                        inner JOIN TBL_EMPLOYEE B ON B.BRANCHCODE = A.BIOMETRIC_ID 
                                        left JOIN PAYROLL_CITY_BRANCH C ON C.BRANCHCODE = B.BRANCHCODE
                                        where PAYDATE  = '{paydatee}' and B.COMPANY  = 'PHOTO' 
                                            and B.PHOTO_CATEGORY = 'GENSAN PERFECT'
                                            or B.HO_CATEGORY IN ('Photo Admin Office', 'Photo Admin Operation'))
                                        Order by B.BRANCHCODE"

                        PlusS = "GENSAN PERFECT"
                    ElseIf NetBranch_Combo.SelectedIndex = 3 Then '=== Photo Head Office

                        mysql = $"Select * From PAYROLL_PAYOUT A 
                                        inner JOIN TBL_EMPLOYEE B ON B.BIOMETRICID = A.BIOMETRIC_ID 
                                        left JOIN PAYROLL_CITY_BRANCH C ON C.BRANCHCODE = B.BRANCHCODE
                                        where PAYDATE  = '{paydatee}' and B.HO_CATEGORY like 'Photo%' order by HO_CATEGORY"

                    End If
                Else
                    MsgBox("Please select date of payroll.", MsgBoxStyle.Exclamation, "Error")
                End If

            ElseIf Company_Combo.SelectedIndex = 2 Then '=== P&G UY 

                If PaydateNet_ComboB.SelectedIndex >= 0 Then
                    If NetBranch_Combo.SelectedIndex = 0 Then '=== 3G

                        mysql = $"Select * From PAYROLL_PAYOUT A 
                                        inner JOIN TBL_EMPLOYEE B ON B.BIOMETRICID = A.BIOMETRIC_ID 
                                        left JOIN PAYROLL_CITY_BRANCH C ON C.BRANCHCODE = B.BRANCHCODE
                                        where A.PAYDATE  = '{paydatee}' and B.COMPANY  = 'P&G UY' and B.BRANCHCODE = '3G'"

                    ElseIf NetBranch_Combo.SelectedIndex = 1 Then '=== 7Eleven

                        mysql = $"Select * From PAYROLL_PAYOUT A 
                                        inner JOIN TBL_EMPLOYEE B ON B.BIOMETRICID = A.BIOMETRIC_ID   
                                        left JOIN PAYROLL_CITY_BRANCH C ON C.BRANCHCODE = B.BRANCHCODE  
                                        where A.PAYDATE  = '{paydatee}' and B.COMPANY  = 'P&G UY' and B.BRANCHCODE IN ('711-POL','711-ROX')"

                    ElseIf NetBranch_Combo.SelectedIndex = 2 Then '=== COMI-WAVE

                        mysql = $"Select * From PAYROLL_PAYOUT A 
                                        inner Join TBL_EMPLOYEE B ON B.BIOMETRICID = A.BIOMETRIC_ID
                                        left JOIN PAYROLL_CITY_BRANCH C ON C.BRANCHCODE = B.BRANCHCODE  
                                        where A.PAYDATE = '{paydatee}' and B.COMPANY  = 'P&G UY' 
                                        And B.BRANCHCODE IN ('COMI','KTV','PBA','WAVE', 'GHS MAINTENANCE') 
                                        Order by B.BRANCHCODE asc"

                    ElseIf NetBranch_Combo.SelectedIndex = 3 Then '=== P&G UY HEAD OFFICE

                        mysql = $"Select * From PAYROLL_PAYOUT A 
                                        inner Join TBL_EMPLOYEE B ON B.BIOMETRICID = A.BIOMETRIC_ID
                                        left JOIN PAYROLL_CITY_BRANCH C ON C.BRANCHCODE = B.BRANCHCODE  
                                        where A.PAYDATE = '{paydatee}' and B.HO_CATEGORY LIKE '%GHS%'
                                        Order by case when B.HO_CATEGORY LIKE UPPER('%GHS%') then 1 else 0  end, B.HO_CATEGORY asc"

                    End If
                Else
                    MsgBox("Please select date of payroll.", MsgBoxStyle.Exclamation, "Error")
                End If

            ElseIf Company_Combo.SelectedIndex = 3 Then '=== DALTON

                If PaydateNet_ComboB.SelectedIndex >= 0 Then
                    If NetBranch_Combo.SelectedIndex = 0 Then '=== Dalton Office-Operation

                        mysql = $"Select * From PAYROLL_PAYOUT A 
                                        inner JOIN TBL_EMPLOYEE B ON B.BIOMETRICID = A.BIOMETRIC_ID   
                                        left JOIN PAYROLL_CITY_BRANCH C ON C.BRANCHCODE = B.BRANCHCODE  
                                        where A.PAYDATE  = '{paydatee}' and B.HO_CATEGORY IN ('Dalton Admin Office','Dalton Retail','Dalton Admin Operation') 
                                        Order by case when B.HO_CATEGORY LIKE '%Operation%' then 1 else 0  end, B.HO_CATEGORY asc"

                    ElseIf NetBranch_Combo.SelectedIndex = 1 Then '=== All Dalton Branches Maually Order 

                        mysql = $"Select * From PAYROLL_PAYOUT A 
                                        inner JOIN TBL_EMPLOYEE B ON B.BIOMETRICID = A.BIOMETRIC_ID 
                                        left JOIN PAYROLL_CITY_BRANCH C ON C.BRANCHCODE = B.BRANCHCODE
                                        where A.PAYDATE  = '{paydatee}' AND B.COMPANY  = 'DALTON'
                                         Order by B.BRANCHCODE asc"

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
        End If
    End Sub

    Private Sub CostPaydate_Combo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CostPaydate_Combo.SelectedIndexChanged
        If CostPaydate_Combo.SelectedIndex >= 0 Then
            LoadCostDistribution()
        End If
    End Sub

    Private Sub CommonCat_Combo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CommonCat_Combo.SelectedIndexChanged
        If PaydateCom_Combo.SelectedIndex >= 0 Then
            LoadCommonNETPAY_Print()
        Else
            MsgBox("Please select payroll date!", MsgBoxStyle.Exclamation, "Invalid")
        End If
    End Sub

    Private Sub RemCompany_Combo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RemCompany_Combo.SelectedIndexChanged
        If Not Rem_Paydate_Combo.SelectedIndex >= 0 Then
            MsgBox("Please select payroll date!", MsgBoxStyle.Exclamation, "Invalid")
        ElseIf Not RemCat_Combo.SelectedIndex >= 0 Then
            MsgBox("Please select category!", MsgBoxStyle.Exclamation, "Invalid")
        ElseIf Not RemCompany_Combo.SelectedIndex >= 0 Then
            MsgBox("Please select company!", MsgBoxStyle.Exclamation, "Invalid")
        Else
            LoadRemittance()
        End If
    End Sub

    Private Sub DeducHistory_btn_Click(sender As Object, e As EventArgs) Handles DeducHistory_btn.Click
        Lists_Deduction_History(DeducHistory_List, DeducHistory_txt.Text)
    End Sub

    Private Sub DeducHistory_txt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DeducHistory_txt.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            DeducHistory_btn.PerformClick()
        End If
    End Sub

    Private Sub LoanCompany_Combo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LoanCompany_Combo.SelectedIndexChanged
        If Not LoanPaydate_Combo.SelectedIndex >= 0 Then
            MsgBox("Please select payroll date!", MsgBoxStyle.Exclamation, "Invalid")
        ElseIf Not LoanCat_Combo.SelectedIndex >= 0 Then
            MsgBox("Please select category!", MsgBoxStyle.Exclamation, "Invalid")
        ElseIf Not LoanCompany_Combo.SelectedIndex >= 0 Then
            MsgBox("Please select company!", MsgBoxStyle.Exclamation, "Invalid")
        Else
            LoadLoans()
        End If
    End Sub

    Private Sub Month_Search_btn_Click(sender As Object, e As EventArgs) Handles Month_Search_btn.Click
        Lists_13Month(Month_LV, Month_Search_txt.Text)
    End Sub

    Private Sub Month_Search_txt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Month_Search_txt.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Lists_13Month(Month_LV, Month_Search_txt.Text)
        End If
    End Sub

    Private Sub Allow_Company_CB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Allow_Company_CB.SelectedIndexChanged
        If Allow_Paydate_Combo.SelectedIndex >= 0 And Allow_Category_CB.SelectedIndex >= 0 And Allow_Company_CB.SelectedIndex >= 0 Then
            LoadPI(Allow_Category_CB.Text)
        Else
            MsgBox("Paydate and Company must not be empty.", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Public Sub LoadPI(category As String)

        Rpt_PI.LocalReport.DataSources.Clear()
        Dim PAYDATE_start As DateTime = Allow_Paydate_Combo.Text
        Dim PAYDATE_end As New DateTime(PAYDATE_start.Year, PAYDATE_start.Month, System.DateTime.DaysInMonth(PAYDATE_start.Year, PAYDATE_start.Month))
        Dim FULLNAME As String = Nothing

        Try

            Dim str As String = ""
            Dim report As String = "WindowsApp1.rpt_PI.rdlc"

            Dim dt_PI As New DataTable()
            With dt_PI
                .Columns.Add("NAME")
                .Columns.Add("AMOUNT")
                .Columns.Add("BRANCH")
            End With

            If Allow_Company_CB.SelectedIndex = 0 Then
                str = $" AND HO_CATEGORY LIKE '%Photo%'"
            ElseIf Allow_Company_CB.SelectedIndex = 1 Then
                str = $" AND PHOTO_CATEGORY = 'GENSAN PERFECT'"
            ElseIf Allow_Company_CB.SelectedIndex = 2 Then
                str = $" AND PHOTO_CATEGORY = 'DAVAO PERFECT'"
            ElseIf Allow_Company_CB.SelectedIndex = 3 Then
                str = $" AND PHOTO_CATEGORY = 'JR PHOTO' "
            ElseIf Allow_Company_CB.SelectedIndex = 4 Then
                str = $" AND (COMPANY = 'DALTON' OR HO_CATEGORY LIKE '%Dalton%')"
            ElseIf Allow_Company_CB.SelectedIndex = 5 Then
                str = $" AND  (COMPANY = 'PERFECOM' OR HO_CATEGORY LIKE '%Perfecom%')"
            ElseIf Allow_Company_CB.SelectedIndex = 6 Then
                str = $" AND  (COMPANY = 'P&G UY' OR HO_CATEGORY LIKE '%GHS%')"
            ElseIf Allow_Company_CB.SelectedIndex = 7 Then
                str = $" AND  HO_CATEGORY IN ('Leasing Admin Office','Construction')"
            ElseIf Allow_Company_CB.SelectedIndex = 8 Then
                str = $" AND  HO_CATEGORY = 'PGC Head Office'"
            Else
                str = ""
                report = "WindowsApp1.rpt_PI_All.rdlc"
            End If

            Dim mysql As String = $"SELECT 
                                      A.BIO_NO,
                                      SUM(A.AMOUNT) AS TOTAL_AMOUNT,
                                      C.BRANCHNAME,
                                      B.PHOTO_CATEGORY,
                                      B.BRANCHCODE AS BRANCH_CODE,
                                      B.HO_CATEGORY,
                                      B.COMPANY,
                                      LASTNAME || ', ' || FIRSTNAME || 
                                        CASE 
                                          WHEN MIDDLENAME IS NOT NULL AND MIDDLENAME <> '' THEN ' ' || LEFT(MIDDLENAME, 1) || '.' 
                                          ELSE '' 
                                        END || 
                                        CASE 
                                          WHEN SUFFIX IS NOT NULL AND SUFFIX <> '' THEN ' ' || SUFFIX 
                                          ELSE '' 
                                        END AS FULLNAME
                                    FROM 
                                      RECORDED_ALLOW_DEDUC A
                                    INNER JOIN 
                                      TBL_EMPLOYEE B ON B.BIOMETRICID = A.BIO_NO {str} 
                                    LEFT JOIN 
                                      PAYROLL_CITY_BRANCH C ON C.BRANCHCODE = B.BRANCHCODE
                                    WHERE 
                                      UPPER(A.CATEGORY) LIKE UPPER('%{category}%') 
                                      AND A.PAYDATE BETWEEN '{PAYDATE_start.ToShortDateString}' AND '{PAYDATE_end.ToShortDateString}' 
                                    GROUP BY 
                                      A.BIO_NO, C.BRANCHNAME, B.PHOTO_CATEGORY, B.BRANCHCODE, B.HO_CATEGORY, B.COMPANY,
                                      LASTNAME, FIRSTNAME, MIDDLENAME, SUFFIX
                                    ORDER BY 
                                      FULLNAME; "

            TestingScript_String(mysql)
            Using ds As DataSet = LoadSQL(mysql, "RECORDED_ALLOW_DEDUC")
                If ds.Tables(0).Rows.Count > 0 Then

                    progressBarStart(ds.Tables(0).Rows.Count)
                    For Each dr In ds.Tables(0).Rows
                        With dr

                            '============================= NAME AND ATTENDANCE ============================  
                            FULLNAME = IIf(IsDBNull(.Item("FULLNAME")), "", .Item("FULLNAME"))
                            'Dim bioNo As Integer = CInt(.Item("BIO_NO"))
                            Dim AMOUNT As String = FormatNumber(.Item("TOTAL_AMOUNT"))

                            '===================================== BRANCHES ===============================
                            Dim BRANCH_CODE As String = ""

                            If IsDBNull(.Item("BRANCH_CODE")) Then
                                BRANCH_CODE = .Item("HO_CATEGORY")
                            ElseIf .Item("BRANCH_CODE") = "" Then
                                BRANCH_CODE = .Item("HO_CATEGORY")
                            Else
                                BRANCH_CODE = .Item("BRANCHNAME")
                            End If

                            Dim COMPANY As String = .Item("COMPANY")
                            Dim HO_CATEGORY As String = IIf(IsDBNull(.Item("HO_CATEGORY")), "", .Item("HO_CATEGORY"))
                            Dim COMPANY_CATEGORY As String = IIf(IsDBNull(.Item("PHOTO_CATEGORY")), "", .Item("PHOTO_CATEGORY"))

                            If COMPANY = "DALTON" Then
                                BRANCH_CODE = IIf(.Item("BRANCH_CODE") = "" Or IsDBNull(.Item("BRANCH_CODE")), .Item("HO_CATEGORY"), TitleCase(.Item("COMPANY")) & "-" & .Item("BRANCHNAME"))
                            End If

                            If HO_CATEGORY = "GHS/P&G UY Admin Office" Or HO_CATEGORY = "GHS/P&G UY Admin Operation" Then
                                BRANCH_CODE = HO_CATEGORY

                            ElseIf HO_CATEGORY.Contains("Dalton") Then
                                BRANCH_CODE = HO_CATEGORY

                            ElseIf HO_CATEGORY.Contains("Photo") Or HO_CATEGORY.Contains("PGC") Then
                                BRANCH_CODE = HO_CATEGORY
                            End If

                            If COMPANY_CATEGORY <> "" Then
                                BRANCH_CODE = COMPANY_CATEGORY
                            End If

                            dt_PI.Rows.Add(FULLNAME, AMOUNT, BRANCH_CODE)

                            frmMainForm.AppProgressBar.Value += 1
                        End With

                    Next
                    progressBarEnd()
                End If
            End Using

            Dim DATASOURCE As New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt_PI)
            Dim FORMNAME As String = $"LIST OF {category} - {Allow_Paydate_Combo.Text}"

            Dim paramList As New List(Of Microsoft.Reporting.WinForms.ReportParameter) From {
                    New Microsoft.Reporting.WinForms.ReportParameter("paramFormName", FORMNAME)
                    }

            Rpt_PI.LocalReport.ReportEmbeddedResource = report
            Rpt_PI.LocalReport.DataSources.Add(DATASOURCE)
            Rpt_PI.LocalReport.SetParameters(paramList)
            Rpt_PI.RefreshReport()

        Catch ex As Exception
            MessageBox.Show($"{ex.Message}{vbCrLf}{FULLNAME}", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub LoadEmployeeRate(Optional search As String = Nothing)
        Rpt_Rate.LocalReport.DataSources.Clear()
        Dim linee As String = Nothing
        Try

            Dim dt_Rate As New DataTable()
            With dt_Rate
                .Columns.Add("NAME")
                .Columns.Add("RATE")
                .Columns.Add("MONTHLY")
                .Columns.Add("BRANCH")
            End With

            Dim str As String = ""
            If RateCompany_CB.SelectedIndex = 0 Then
                str = $"WHERE HO_CATEGORY LIKE '%Photo%'"
            ElseIf RateCompany_CB.SelectedIndex = 1 Then
                str = $"WHERE PHOTO_CATEGORY = 'GENSAN PERFECT'"
            ElseIf RateCompany_CB.SelectedIndex = 2 Then
                str = $"WHERE PHOTO_CATEGORY = 'DAVAO PERFECT'"
            ElseIf RateCompany_CB.SelectedIndex = 3 Then
                str = $"WHERE PHOTO_CATEGORY = 'JR PHOTO' "
            ElseIf RateCompany_CB.SelectedIndex = 4 Then
                str = $"WHERE (COMPANY = 'DALTON' OR HO_CATEGORY LIKE '%Dalton%')"
            ElseIf RateCompany_CB.SelectedIndex = 5 Then
                str = $"WHERE  (COMPANY = 'PERFECOM' OR HO_CATEGORY LIKE '%Perfecom%')"
            ElseIf RateCompany_CB.SelectedIndex = 6 Then
                str = $"WHERE  (COMPANY = 'P&G UY' OR HO_CATEGORY LIKE '%GHS%')"
            ElseIf RateCompany_CB.SelectedIndex = 7 Then
                str = $"WHERE  HO_CATEGORY IN ('Leasing Admin Office','Construction')"
            ElseIf RateCompany_CB.SelectedIndex = 8 Then
                str = $"WHERE  HO_CATEGORY = 'PGC Head Office'"
            End If

            Dim mysql As String = $"Select A.*, B.*, 
                                        LASTNAME || ', ' || FIRSTNAME || 
                                        CASE
                                            WHEN MIDDLENAME IS NOT NULL AND MIDDLENAME <> '' THEN ' ' || LEFT(MIDDLENAME, 1) || '.' 
                                            ELSE ''
                                        END || 
                                        CASE 
                                            WHEN SUFFIX IS NOT NULL AND SUFFIX <> '' THEN ' ' || SUFFIX
                                            ELSE ''
                                        END AS FULLNAME
                                        From TBL_EMPLOYEE A 
                                        LEFT JOIN PAYROLL_CITY_BRANCH B ON B.BRANCHCODE = A.BRANCHCODE {str} ORDER BY FULLNAME"

            If search <> Nothing Then
                If IsNumeric(search) Then
                    mysql = $"Select A.*, B.*, 
                                        LASTNAME || ', ' || FIRSTNAME || 
                                        CASE
                                            WHEN MIDDLENAME IS NOT NULL AND MIDDLENAME <> '' THEN ' ' || LEFT(MIDDLENAME, 1) || '.' 
                                            ELSE ''
                                        END || 
                                        CASE 
                                            WHEN SUFFIX IS NOT NULL AND SUFFIX <> '' THEN ' ' || SUFFIX
                                            ELSE ''
                                        END AS FULLNAME
                                        From TBL_EMPLOYEE A 
                                        LEFT JOIN PAYROLL_CITY_BRANCH B ON B.BRANCHCODE = A.BRANCHCODE 
                                        where BIOMETRICID ='{search}' or EMP_NO ='{search}' or RATE_DAILY ='{search}' or RATE_MONTHLY ='{search}'  
                                        ORDER BY FULLNAME"
                Else
                    mysql = $"Select A.*, B.*, 
                                        LASTNAME || ', ' || FIRSTNAME || 
                                        CASE
                                            WHEN MIDDLENAME IS NOT NULL AND MIDDLENAME <> '' THEN ' ' || LEFT(MIDDLENAME, 1) || '.' 
                                            ELSE ''
                                        END || 
                                        CASE 
                                            WHEN SUFFIX IS NOT NULL AND SUFFIX <> '' THEN ' ' || SUFFIX
                                            ELSE ''
                                        END AS FULLNAME
                                        From TBL_EMPLOYEE A 
                                        LEFT JOIN PAYROLL_CITY_BRANCH B ON B.BRANCHCODE = A.BRANCHCODE 
                                        where upper(FULLNAME) like upper('%{search}%') or upper(COMPANY) like upper('%{search}%') or upper(BRANCHCODE) like upper('%{search}%') 
                                        ORDER BY FULLNAME"
                End If
            End If


            Using ds As DataSet = LoadSQL(mysql, "TBL_EMPLOYEE")
                If ds.Tables(0).Rows.Count > 0 Then
                    progressBarStart(ds.Tables(0).Rows.Count)
                    For Each dr In ds.Tables(0).Rows
                        With dr

                            '============================= NAME AND ATTENDANCE ============================  
                            Dim FULLNAME As String = IIf(IsDBNull(.Item("FULLNAME")), "", .Item("FULLNAME"))
                            Dim RATE As Decimal = IIf(IsDBNull(.Item("RATE_DAILY")), 0, .Item("RATE_DAILY"))
                            Dim MONTHLY As Decimal = IIf(IsDBNull(.Item("RATE_MONTHLY")), 0, .Item("RATE_MONTHLY"))

                            '===================================== BRANCHES ===============================
                            linee = "HO_CATEGORY"
                            Dim HO_CATEGORY As String = IIf(IsDBNull(.Item("HO_CATEGORY")), "", .Item("HO_CATEGORY"))
                            linee = "BRANCHNAME"
                            Dim BRANCHNAME As String = IIf(IsDBNull(.Item("BRANCHNAME")) Or .Item("BRANCHNAME").Equals(""), "", .Item("BRANCHNAME"))
                            linee = "BRANCHCODE"
                            Dim BRANCH_CODE As String = IIf(IsDBNull(.Item("BRANCHCODE")) Or .Item("BRANCHCODE").Equals(""), "", BRANCHNAME)

                            If IsDBNull(.Item("BRANCHCODE")) Then
                                BRANCH_CODE = ""
                            ElseIf .Item("BRANCHCODE") = "" Then
                                BRANCH_CODE = ""
                            Else
                                BRANCH_CODE = BRANCHNAME
                            End If

                            linee = "COMPANY"
                            Dim COMPANY As String = IIf(IsDBNull(.Item("COMPANY")), "", .Item("COMPANY"))
                            linee = "COMPANY_CATEGORY"
                            Dim COMPANY_CATEGORY As String = IIf(IsDBNull(.Item("PHOTO_CATEGORY")), "", .Item("PHOTO_CATEGORY"))

                            If COMPANY = "DALTON" Then
                                linee = "DALTON =BRANCH_CODE"
                                BRANCH_CODE = IIf(IsDBNull(.Item("BRANCHCODE")) Or .Item("BRANCHCODE").Equals(""), HO_CATEGORY, TitleCase(COMPANY) & "-" & .Item("BRANCHNAME"))
                            End If

                            If HO_CATEGORY = "GHS/P&G UY Admin Office" Or HO_CATEGORY = "GHS/P&G UY Admin Operation" Then
                                BRANCH_CODE = HO_CATEGORY

                            ElseIf HO_CATEGORY.Contains("Dalton") Then
                                BRANCH_CODE = HO_CATEGORY

                            ElseIf HO_CATEGORY.Contains("Photo") Or HO_CATEGORY.Contains("PGC") Then
                                BRANCH_CODE = HO_CATEGORY
                            End If

                            If COMPANY_CATEGORY <> "" Then
                                BRANCH_CODE = COMPANY_CATEGORY
                            End If

                            dt_Rate.Rows.Add(FULLNAME, FormatNumber(RATE), FormatNumber(MONTHLY), BRANCH_CODE)

                            frmMainForm.AppProgressBar.Value += 1
                        End With

                    Next
                    progressBarEnd()
                End If
            End Using

            Dim DATASOURCE As New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt_Rate)
            Dim FORMNAME As String = "List of Employee's Rate"

            Dim paramList As New List(Of Microsoft.Reporting.WinForms.ReportParameter) From {
                    New Microsoft.Reporting.WinForms.ReportParameter("paramFormName", FORMNAME)
                    }

            Rpt_Rate.LocalReport.DataSources.Add(DATASOURCE)
            Rpt_Rate.LocalReport.SetParameters(paramList)
            Rpt_Rate.RefreshReport()

        Catch ex As Exception
            MessageBox.Show($"{ex.Message} {vbCrLf} {linee}", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub SILYear_Combo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SILYear_Combo.SelectedIndexChanged
        If SILYear_Combo.SelectedIndex >= 0 Then
            Lists_SIL(SIL_list, SILYear_Combo.Text)
        End If
    End Sub

    Private Sub SILSeacrh_btn_Click(sender As Object, e As EventArgs) Handles SILSeacrh_btn.Click
        Lists_SIL(SIL_list, SILYear_Combo.Text, SILSearch_txt.Text)
    End Sub

    Private Sub SILSearch_txt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles SILSearch_txt.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SILSeacrh_btn.PerformClick()
        End If
    End Sub

    Private Sub SBU_LV_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles SBU_LV.MouseDoubleClick
        If SBU_LV.Items.Count >= 0 Then
            LoadSBU(SBU_LV.Items(SBU_LV.FocusedItem.Index).SubItems(4).Tag)
        End If
    End Sub

    Private Sub Month_LV_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Month_LV.MouseDoubleClick
        If Month_LV.Items.Count >= 0 Then
            If Range_Combo.SelectedIndex >= 0 Then
                Laod_13Month(Month_LV.Items(Month_LV.FocusedItem.Index).SubItems(1).Tag, rpt_13Month, Range_Combo.Text)
            Else
                Laod_13Month(Month_LV.Items(Month_LV.FocusedItem.Index).SubItems(1).Tag, rpt_13Month)
            End If
        End If
    End Sub

    Private Sub DeducHistory_List_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DeducHistory_List.MouseDoubleClick
        If DeducHistory_List.Items.Count > 0 Then
            Dim deduct_id As Integer = DeducHistory_List.Items(DeducHistory_List.FocusedItem.Index).SubItems(1).Tag
            Dim category As String = DeducHistory_List.Items(DeducHistory_List.FocusedItem.Index).SubItems(1).Text
            Dim fullname As String = DeducHistory_List.Items(DeducHistory_List.FocusedItem.Index).SubItems(0).Text
            LoadDeduction(deduct_id, category, fullname)
        End If
    End Sub

    Private Sub PaydateNet_ComboB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PaydateNet_ComboB.SelectedIndexChanged
        LoadNet_AllCompanyBranches()
    End Sub

    Private Sub LoadNet_AllCompanyBranches()
        ReportV_NetPay.LocalReport.DataSources.Clear()
        Dim paydatee As String = PaydateNet_ComboB.SelectedItem

        Try
            Dim dt_NetPay As New DataTable()
            With dt_NetPay
                .Columns.Add("EMP_NO")
                .Columns.Add("FULLNAME")
                .Columns.Add("BASIC")
                .Columns.Add("OVERTIME")
                .Columns.Add("HOLIDAY")
                .Columns.Add("N_DIFF")
                .Columns.Add("TARDINESS")
                .Columns.Add("SSS")
                .Columns.Add("PHIC")
                .Columns.Add("PAGIBIG")
                .Columns.Add("CHARGES_SBU")
                .Columns.Add("NET_PAY")
                .Columns.Add("BRANCH_CODE")
                .Columns.Add("PAYDATE")
                .Columns.Add("PERIOD")
                .Columns.Add("COMPANY")
                .Columns.Add("HO_CATEGORY")
                .Columns.Add("PLUS")
                .Columns.Add("MONTH_13")
                .Columns.Add("ACCOUNT_NO")
                .Columns.Add("CHARGES_MP2")
                .Columns.Add("CHARGES_CA")
                .Columns.Add("CHARGES_ECS")
                .Columns.Add("CHARGES_OTHERS")
                .Columns.Add("LOAN_SSS")
                .Columns.Add("LOAN_PAGIBIG")
                .Columns.Add("WH_TAX")
                .Columns.Add("SIL")
                .Columns.Add("PERF_IN")
                .Columns.Add("SALES_IN")
                .Columns.Add("OTHER_ADDITIONAL")
            End With

            Dim mysqll As String = $"Select A.*, B.*, C.*, B.BRANCHCODE as BRANCH_CODE,
                                        LASTNAME || ', ' || FIRSTNAME || 
                                        CASE
                                            WHEN MIDDLENAME IS NOT NULL AND MIDDLENAME <> '' THEN ' ' || LEFT(MIDDLENAME, 1) || '.' 
                                            ELSE ''
                                        END || 
                                        CASE 
                                            WHEN SUFFIX IS NOT NULL AND SUFFIX <> '' THEN ' ' || SUFFIX
                                            ELSE ''
                                        END AS FULLNAME 
                                        From PAYROLL_PAYOUT A 
                                        inner JOIN TBL_EMPLOYEE B ON B.BIOMETRICID = A.BIOMETRIC_ID 
                                        left JOIN PAYROLL_CITY_BRANCH C ON C.BRANCHCODE = B.BRANCHCODE
                                        where A.PAYDATE  = '{paydatee}'
                                        Order by B.COMPANY, BRANCHNAME, B.HO_CATEGORY, FULLNAME"

            LoadRows_NetPay(mysqll, paydatee, dt_NetPay)

            Dim rds_DTR As New Microsoft.Reporting.WinForms.ReportDataSource("DataSet2", dt_NetPay)
            ReportV_NetPay.LocalReport.DataSources.Add(rds_DTR)
            ReportV_NetPay.RefreshReport()

            PlusS = Nothing

        Catch ex As Exception
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Function LoadRows_NetPay(mysql As String, paydatee As String, dataTable As DataTable, Optional plus_ As String = Nothing) As DataTable
        TestingScript_String(mysql)

        Dim GROUP As String = ""
        Dim period As String
        Dim linee As String = Nothing
        Dim fullname As String = Nothing

        Dim date_pay As DateTime = Convert.ToDateTime(PaydateNet_ComboB.Text)
        date_pay = date_pay.ToString("d")

        If IsLastDay(date_pay) Then
            period = "2nd Period"
        Else
            period = "1st Period"
        End If

        Try

            Using ds As DataSet = LoadSQL(mysql, "PAYROLL_PAYOUT")

                If ds.Tables(0).Rows.Count > 0 Then

                    progressBarStart(ds.Tables(0).Rows.Count)
                    For Each dr In ds.Tables(0).Rows
                        With dr
                            linee = "EMP_NO"
                            Dim EMP_NO As String = IIf(IsDBNull(.Item("EMP_NO")), "", .Item("EMP_NO"))
                            linee = "BIO_NO"
                            Dim BIO_NO As Integer = .Item("BIOMETRICID")
                            linee = "ACCOUNTNO"
                            Dim ACCOUNTNO As String = IIf(IsDBNull(.Item("ACCOUNTNO")), "", .Item("ACCOUNTNO"))

                            Dim payroll As DateTime = paydatee

                            '============================= NAME AND ATTENDANCE ============================ 
                            linee = "namee"
                            Dim namee As String = .Item("FULLNAME")
                            fullname = namee    'FOR ERROR ONLY 
                            linee = "BASIC"
                            Dim BASIC As Double = .Item("TOTAL_BASIC")
                            linee = "OVERTIME"
                            Dim OVERTIME As Decimal = .Item("TOTAL_OVERTIME")
                            linee = "HOLIDAY"
                            Dim HOLIDAY As Decimal = .Item("TOTAL_REGHOLIDAY") + .Item("TOTAL_SPECHOLIDAY")
                            linee = "N_DIFF"
                            Dim N_DIFF As Decimal = .Item("TOTAL_NIGHT_RATE")
                            linee = "SIL"
                            Dim SIL As Double = Get_TOTAL_SIL(BIO_NO, paydatee)
                            linee = "PERF_IN"
                            Dim PERF_IN As Double = Get_PERF_IN(BIO_NO, paydatee)
                            linee = "SALES_IN"
                            Dim SALES_IN As Double = Get_SALES_IN(BIO_NO, paydatee)
                            linee = "OTHER_ADDTL"
                            Dim OTHER_ADDTL As Double = Get_OTHER_ADDTL(BIO_NO, paydatee)
                            linee = "TARDINESS"
                            Dim TARDINESS As Double = .Item("TOTAL_LATE_UT")
                            linee = "SSS"
                            Dim SSS As Double = .Item("SSS_COMP")
                            linee = "PHIC"
                            Dim PHIC As Double = .Item("PHILHEALTH_COMP")
                            linee = "PAGIBIG"
                            Dim PAGIBIG As Double = .Item("PAGIBIG_COMP")
                            linee = "CHARGES_SBU"
                            Dim CHARGES_SBU As Decimal = GetDeductionAmount_SBU(paydatee, BIO_NO)
                            linee = "CHARGES_MP2"
                            Dim CHARGES_MP2 As Decimal = GetDeductionAmount_MP2(paydatee, BIO_NO)
                            linee = "CHARGES_CA"
                            Dim CHARGES_CA As Decimal = GetDeductionAmount_CA(paydatee, BIO_NO)
                            linee = "CHARGES_ECS"
                            Dim CHARGES_ECS As Decimal = GetDeductionAmount_ECS(paydatee, BIO_NO)
                            linee = "CHARGES_WHTAX"
                            Dim CHARGES_WHTAX As Decimal = GetDeductionAmount_WHTAX(paydatee, BIO_NO)
                            linee = "LOAN_SSS"
                            Dim LOAN_SSS As Decimal = GetDeductionAmount_SSSLOAN(paydatee, BIO_NO)
                            linee = "LOAN_PAGIBIG"
                            Dim LOAN_PAGIBIG As Decimal = GetDeductionAmount_PAGIBIGLOAN(paydatee, BIO_NO)
                            linee = "CHARGES_OTHERS"
                            Dim OVERALL_CHARGES As Decimal = .Item("TOTAL_DEDUCTION")
                            Dim COMBINE_CHARGES As Decimal = CHARGES_SBU + CHARGES_MP2 + CHARGES_CA + CHARGES_ECS + LOAN_SSS + LOAN_PAGIBIG
                            Dim CHARGES_OTHERS As Decimal = IIf(OVERALL_CHARGES >= COMBINE_CHARGES, OVERALL_CHARGES - COMBINE_CHARGES, 0)
                            linee = "NET_PAY"
                            Dim NET_PAY As Double = .Item("NET_PAY")

                            linee = "COMPANY"
                            Dim COMPANY As String = IIf(IsDBNull(.Item("COMPANY")), "", .Item("COMPANY"))
                            linee = "HO_CATEGORY"
                            Dim HO_CATEGORY As String = IIf(IsDBNull(.Item("HO_CATEGORY")), "", .Item("HO_CATEGORY"))
                            linee = "Minimum_rate"
                            Dim Minimum_rate As Double = 0

                            linee = "BRANCH_CODE"
                            Dim BRANCH_CODE As String = Nothing
                            Dim BRANCHNAME As String = Nothing
                            If IsDBNull(.Item("BRANCH_CODE")) Then
                                BRANCHNAME = .Item("HO_CATEGORY")
                                Minimum_rate = GetMinimumRate("CITY", "GENSAN")
                            ElseIf .Item("BRANCH_CODE").Equals("") Then
                                BRANCHNAME = .Item("HO_CATEGORY")
                                Minimum_rate = GetMinimumRate("CITY", "GENSAN")
                            Else
                                BRANCH_CODE = .Item("BRANCH_CODE")
                                BRANCHNAME = IIf(IsDBNull(.Item("BRANCHNAME")), "", .Item("BRANCHNAME"))
                                Minimum_rate = GetMinimumRate("BRANCHCODE", .Item("BRANCH_CODE"))
                            End If

                            linee = "Rate"
                            Dim Rate As Decimal = IIf(IsDBNull(.Item("RATE_DAILY")) Or .Item("RATE_DAILY") = 0, Minimum_rate, .Item("RATE_DAILY"))

                            If fix_monthly_rate = True Then
                                OVERTIME = 0
                                HOLIDAY = 0
                                TARDINESS = 0
                            End If

                            '--- RECENTLY ADDED ----
                            If BRANCH_CODE = Nothing Then
                                BRANCHNAME = IIf(IsDBNull(.Item("HO_CATEGORY")), "", CStr(.Item("HO_CATEGORY")).TrimEnd)
                            End If

                            If COMPANY <> "" Then
                                BRANCHNAME = $"{COMPANY} - {BRANCHNAME}"
                            End If

                            Dim tempPlus As String = plus_

                            '======================= 13 MONTH ================
                            Dim MONTH_13 As Decimal = 0

                            If paydatee = $"5/15/{Today.Year}" Or paydatee = $"12/15/{Today.Year}" Then
                                MONTH_13 = Get13Month(BIO_NO, paydatee)
                            End If

                            COMPANY = "ALL COMPANY"

                            dataTable.Rows.Add(EMP_NO, namee, BASIC.ToString("n"), OVERTIME.ToString("n"), HOLIDAY.ToString("n"), N_DIFF.ToString("n"),
                                               TARDINESS.ToString("n"), SSS.ToString("n"), PHIC.ToString("n"), PAGIBIG.ToString("n"),
                                               CHARGES_SBU.ToString("n"), NET_PAY.ToString("n"), BRANCHNAME, payroll.ToString("MMMM dd, yyyy"), period, COMPANY,
                                               HO_CATEGORY, tempPlus, MONTH_13.ToString("n"), ACCOUNTNO, CHARGES_MP2, CHARGES_CA, CHARGES_ECS, CHARGES_OTHERS,
                                               LOAN_SSS, LOAN_PAGIBIG, CHARGES_WHTAX, SIL.ToString("n"), PERF_IN.ToString("n"), SALES_IN.ToString("n"), OTHER_ADDTL.ToString("n"))

                            frmMainForm.AppProgressBar.Value += 1
                        End With
                    Next
                    progressBarEnd()
                End If
            End Using

            Return dataTable
        Catch ex As Exception
            Console.WriteLine($"{ex.ToString}{vbCrLf}{linee}{vbCrLf}{fullname}")
            MsgBox($"{ex.ToString}{vbCrLf}{linee}{vbCrLf}{fullname}")
        End Try
        Return dataTable
    End Function

    Private Sub Range_Combo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Range_Combo.SelectedIndexChanged
        rpt_13Month.Clear()

        Lists_13Month(Month_LV, "", Range_Combo.Text)
    End Sub

    Private Sub PopulateDateRange13Month()
        'Dim mysql As String = "SELECT DISTINCT PAYDATE FROM PAYROLL_PAYOUT 
        '                        WHERE (EXTRACT(MONTH FROM PAYDATE) = 5 AND EXTRACT(DAY FROM PAYDATE) = 15) 
        '                        OR (EXTRACT(MONTH FROM PAYDATE) = 12 AND EXTRACT(DAY FROM PAYDATE) = 15) ORDER BY PAYDATE

        Dim mysql As String = "SELECT PAYDATE
                                FROM (
                                    SELECT DISTINCT PAYDATE
                                    FROM PAYROLL_PAYOUT
                                    WHERE 
                                        (EXTRACT(MONTH FROM PAYDATE) = 5  AND EXTRACT(DAY FROM PAYDATE) = 15)
                                     OR (EXTRACT(MONTH FROM PAYDATE) = 12 AND EXTRACT(DAY FROM PAYDATE) = 15)

                                    UNION

                                    SELECT
                                        CAST(
                                            (EXTRACT(YEAR FROM CURRENT_DATE) + 1) || '-05-15'
                                            AS DATE
                                        )
                                    FROM RDB$DATABASE
                                    WHERE EXISTS (
                                        SELECT 1
                                        FROM PAYROLL_PAYOUT
                                        WHERE 
                                            EXTRACT(MONTH FROM PAYDATE) = 12
                                            AND EXTRACT(DAY FROM PAYDATE) = 15
                                            AND EXTRACT(YEAR FROM PAYDATE) = EXTRACT(YEAR FROM CURRENT_DATE)
                                    )
                                )
                                ORDER BY 1;"

        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_PAYOUT")
            If ds.Tables(0).Rows.Count > 0 Then
                For Each dr In ds.Tables(0).Rows
                    Range_Combo.Items.Add(CDate(dr.Item("PAYDATE")).ToShortDateString)
                Next
            End If
        End Using

        Dim midYear As Date = New Date(Today.Year, 5, 15)
        Dim thirteenth As Date = New Date(Today.Year, 12, 15)

        If Not Range_Combo.Items.Contains(midYear.ToShortDateString) Then
            If Date.Now <= midYear Then
                Range_Combo.Items.Add(midYear)
            End If
        End If

        If Not Range_Combo.Items.Contains(thirteenth.ToShortDateString) Then
            If Date.Now > midYear Then
                Range_Combo.Items.Add(thirteenth)
            End If
        End If
    End Sub

    Private Sub PrintList_btn_Click(sender As Object, e As EventArgs) Handles PrintList_btn.Click
        If Month_LV.Items.Count >= 0 Then
            Print_13Month_LIST(Range_Combo.Text)
        End If
    End Sub

    Friend Sub Print_13Month_LIST(Optional range As DateTime = Nothing)
        rpt_13Month.LocalReport.DataSources.Clear()
        Try

            Dim dt As New DataTable()
            With dt
                .Columns.Add("NAME")
                .Columns.Add("AMOUNT")
            End With

            For row = 0 To Month_LV.Items.Count - 1
                dt.Rows.Add(Month_LV.Items(row).SubItems(0).Text, Month_LV.Items(row).SubItems(1).Text)
            Next

            Dim dataSource As New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt)
            rpt_13Month.LocalReport.ReportEmbeddedResource = "WindowsApp1.rpt_PI.rdlc"
            rpt_13Month.LocalReport.DataSources.Add(dataSource)
            rpt_13Month.RefreshReport()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub RateSearch_btn_Click(sender As Object, e As EventArgs) Handles RateSearch_btn.Click
        LoadEmployeeRate(RateSearch_txt.Text)
    End Sub

    Private Sub RateSearch_txt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles RateSearch_txt.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            RateSearch_btn.PerformClick()
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RateCompany_CB.SelectedIndexChanged
        LoadEmployeeRate()
    End Sub

    Private Sub CompanySBU_CB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CompanySBU_CB.SelectedIndexChanged
        'LoadSBU_Company(CompanySBU_CB.Text)
    End Sub

    Private Sub CompanyDeduct_CB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CompanyDeduct_CB.SelectedIndexChanged
        Dim conditional As String = $"COMPANY = '{CompanyDeduct_CB.Text}'"
        If CompanyDeduct_CB.Text = "PTU REALTY" Then
            conditional = "HO_CATEGORY IN ('Construction' , 'Leasing Admin Office')"
        ElseIf CompanyDeduct_CB.Text = "PGC HEAD OFFICE" Then
            conditional = "HO_CATEGORY = 'PGC Head Office'"
        ElseIf CompanyDeduct_CB.Text = "ALL" Then
            conditional = "COMPANY IS NOT NULL"
        End If

        LoadDeduction_Company(conditional)
    End Sub

    Private Sub btnViewList_Click(sender As Object, e As EventArgs) Handles btnViewList.Click
        LoadSBU_ViewList()
    End Sub

    Private Sub btnDeductionList_Click(sender As Object, e As EventArgs) Handles btnDeductionList.Click
        LoadDEDUCTION_ViewList()
    End Sub

    Friend Sub LoadDEDUCTION_ViewList()
        Rpt_Deduction.LocalReport.DataSources.Clear()

        Try
            Dim dt As New DataTable()
            With dt
                .Columns.Add("BRANCH")
                .Columns.Add("NAME")
                .Columns.Add("CATEGORY")
                .Columns.Add("DATE_ADDED")
                .Columns.Add("PRINCIPAL")
                .Columns.Add("AMORT")
                .Columns.Add("CREDIT")
                .Columns.Add("PARTIAL")
                .Columns.Add("BALANCE")
                .Columns.Add("FORM_NAME")
            End With

            Dim mysqll As String = $"SELECT
                                        A.BIO_NO,
                                        LASTNAME || ', ' || FIRSTNAME || 
                                        CASE
                                            WHEN MIDDLENAME IS NOT NULL AND MIDDLENAME <> '' THEN ' ' || LEFT(MIDDLENAME, 1) || '.' 
                                            ELSE ''
                                        END || 
                                        CASE 
                                            WHEN SUFFIX IS NOT NULL AND SUFFIX <> '' THEN ' ' || SUFFIX
                                            ELSE ''
                                        END AS FULLNAME,
                                        BRANCHNAME,
                                        COMPANY,
    
                                        A.ID,
                                        A.CATEGORY,
                                        A.DATEE,
                                        PRINCIPAL,
                                        A.AMORT, 
    
                                        CASE 
                                            WHEN CREDIT IS NULL AND BALANCE IS NULL THEN COALESCE(C_SUM, 0)
                                            ELSE COALESCE(C_SUM, 0) + CREDIT 
                                        END AS TOTAL_CREDIT,
     
                                        COALESCE(P_TOTAL, 0) AS TOTAL_PARTIAL,
    
                                        PRINCIPAL - CASE 
                                                        WHEN CREDIT IS NULL AND BALANCE IS NULL THEN COALESCE(C_SUM, 0)
                                                        ELSE COALESCE(C_SUM, 0) + CREDIT + COALESCE(P_TOTAL, 0)
                                                    END AS TOTAL_BALANCE,
                                        A.STATUS
                                    FROM
                                        PAYROLL_DEDUCTION A
                                    INNER JOIN
                                        TBL_EMPLOYEE B ON B.BIOMETRICID = A.BIO_NO
                                    LEFT JOIN
                                        (SELECT BIO_NO, R_DEDUC_ID, COALESCE(SUM(AMOUNT), 0) AS C_SUM
                                         FROM RECORDED_ALLOW_DEDUC
                                         WHERE PAYDATE <> '12/15/2021'
                                         GROUP BY BIO_NO, R_DEDUC_ID) C ON C.BIO_NO = A.BIO_NO AND C.R_DEDUC_ID = A.ID
                                    LEFT JOIN
                                        (SELECT DEDUCT_ID, COALESCE(SUM(AMOUNT), 0) AS P_TOTAL
                                         FROM PARTIAL_PAYMENT
                                         GROUP BY DEDUCT_ID) D ON D.DEDUCT_ID = A.ID
                                    LEFT JOIN 
	                                    PAYROLL_CITY_BRANCH E ON E.BRANCHCODE = B.BRANCHCODE 
                                    GROUP BY 
                                        A.BIO_NO, FULLNAME, BRANCHNAME, COMPANY, A.ID, A.CATEGORY, A.DATEE, CREDIT,
                                        PRINCIPAL, A.AMORT, BALANCE, A.STATUS, C.C_SUM, D.P_TOTAL
                                    ORDER BY FULLNAME ASC;"

            Using dss As DataSet = LoadSQL(mysqll, "TBL_EMPLOYEE")
                If dss.Tables(0).Rows.Count > 0 Then
                    progressBarStart(dss.Tables(0).Rows.Count)
                    For Each dr In dss.Tables(0).Rows
                        With dr

                            Dim company As String = Nothing
                            Dim branch As String = Nothing
                            Dim fullname As String = .Item("FULLNAME")
                            Dim category As String = .Item("CATEGORY")
                            Dim dateAdded As String = CDate(.Item("DATEE")).ToShortDateString
                            Dim principal As Decimal = .Item("PRINCIPAL")
                            Dim amort As Decimal = .Item("AMORT")
                            Dim credit As Decimal = .Item("TOTAL_CREDIT")
                            Dim partialPayment As Decimal = .Item("TOTAL_PARTIAL")
                            Dim balance As Decimal = .Item("TOTAL_BALANCE")

                            If IsDBNull(.Item("BRANCHNAME")) Then
                                branch = "No branch"
                            ElseIf String.IsNullOrEmpty(.Item("BRANCHNAME")) Then
                                branch = "No branch"
                            Else
                                branch = .Item("BRANCHNAME")
                            End If

                            If IsDBNull(.Item("COMPANY")) Then
                                company = "No company"
                            ElseIf String.IsNullOrEmpty(.Item("COMPANY")) Then
                                company = "No company"
                            Else
                                company = .Item("COMPANY")
                            End If

                            If company <> "HEAD OFFICE" Then branch = $"{company} - {branch}"

                            frmMainForm.AppProgressBar.Value += 1

                            dt.Rows.Add(branch, fullname, category, dateAdded, FormatNumber(principal), FormatNumber(amort), FormatNumber(credit), FormatNumber(partialPayment), FormatNumber(balance), $"LIST OF DEDUCTION - {Now}")

                        End With
                    Next
                    progressBarEnd()
                End If
            End Using

            Dim DATASET As New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt)
            Rpt_Deduction.LocalReport.ReportEmbeddedResource = "WindowsApp1.rpt_Deduction_All.rdlc"
            Rpt_Deduction.LocalReport.DataSources.Add(DATASET)
            Rpt_Deduction.RefreshReport()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub PaydateSBU_Combo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PaydateSBU_Combo.SelectedIndexChanged
        If CompanySBU_CB.Text = Nothing Then
            MsgBox("Please select a Company.", MsgBoxStyle.Exclamation)
        ElseIf PaydateSBU_Combo.Text = Nothing Then
            MsgBox("Please select a Payroll Date.", MsgBoxStyle.Exclamation)
        Else
            LoadSBU_ViewList()
        End If
    End Sub

    Private Sub cbDateEffectivity_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbDateEffectivity.SelectedIndexChanged
        ReassignmentAppointment_Filter()
    End Sub

    Private Sub cbAction_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbAction.SelectedIndexChanged
        ReassignmentAppointment_Filter()
    End Sub

    Private Sub ReassignmentAppointment_Filter()
        Dim addCondition As String = ""
        If cbAction.Text <> Nothing Then addCondition = $"AND ACTION_NAME = '{cbAction.Text}'"
        If cbDateEffectivity.SelectedItem <> Nothing Then
            Dim DATE_start As DateTime = cbDateEffectivity.Text
            Dim DATE_end As New DateTime(DATE_start.Year, DATE_start.Month, System.DateTime.DaysInMonth(DATE_start.Year, DATE_start.Month))
            addCondition &= $"AND EFFECTIVE_DATE BETWEEN '{DATE_start.ToShortDateString}' AND '{DATE_end.ToShortDateString}'"
        End If
        LoadReassigment(addCondition)
    End Sub

    Private Sub btnSearchReassign_Click(sender As Object, e As EventArgs) Handles btnSearchReassign.Click
        If txtReassignment.Text <> Nothing Then LoadReassigment($"AND UPPER(LASTNAME || ', ' || FIRSTNAME || 
                                    CASE WHEN MIDDLENAME IS NOT NULL AND MIDDLENAME <> '' THEN ' ' || LEFT(MIDDLENAME, 1) || '.' ELSE ''
                                    END || 
                                    CASE WHEN SUFFIX IS NOT NULL AND SUFFIX <> '' THEN ' ' || SUFFIX  ELSE ''
                                    END) LIKE UPPER('%{txtReassignment.Text}%')")
    End Sub

    Public Sub LoadReassigment(Optional addCondition As String = Nothing)
        rptReassignment.LocalReport.DataSources.Clear()
        Try

            Dim dt_Reassignment As New DataTable()
            With dt_Reassignment
                .Columns.Add("FULLNAME")
                .Columns.Add("EFFECTIVE_DATE")
                .Columns.Add("EMP_POSITION")
                .Columns.Add("FROM_BRANCH")
                .Columns.Add("TO_BRANCH")
                .Columns.Add("REMARKS")
                .Columns.Add("DATE_CREATED")
                .Columns.Add("ACTION_NAME")
                .Columns.Add("ACTION_STATUS")
            End With

            Dim sql As String = $"Select A.*, lastName || ', ' || FIRSTNAME || 
                                        Case
                                            WHEN MIDDLENAME Is Not NULL And MIDDLENAME <> '' THEN ' ' || LEFT(MIDDLENAME, 1) || '.' 
                                            Else ''
                                        End || 
                                        Case 
                                            WHEN SUFFIX Is Not NULL And SUFFIX <> '' THEN ' ' || SUFFIX
                                            Else ''
                                        End As FULLNAME
                                FROM HR_LETTER A 
                                INNER JOIN TBL_EMPLOYEE B ON B.ID = A.EMP_ID
                                WHERE ACTION_NAME IS NOT NULL {addCondition}"

            TestingScript_String(sql)
            Using ds As DataSet = LoadSQL(sql, "HR_LETTER")
                If ds.Tables(0).Rows.Count > 0 Then
                    progressBarStart(ds.Tables(0).Rows.Count)
                    For Each dr In ds.Tables(0).Rows
                        With dr

                            Dim FULLNAME As String = .Item("FULLNAME")
                            Dim EFFECTIVE_DATE As String = .Item("EFFECTIVE_DATE")
                            Dim EMP_POSITION As String = .Item("EMP_POSITION")
                            Dim FROM_BRANCH As String = .Item("FROM_BRANCH")
                            Dim TO_BRANCH As String = .Item("TO_BRANCH")
                            Dim REMARKS As String = .Item("REMARKS")
                            Dim DATE_CREATED As String = IIf(IsDBNull(.Item("DATE_CREATED")), Nothing, .Item("DATE_CREATED"))
                            Dim ACTION_NAME As String = .Item("ACTION_NAME")
                            Dim ACTION_STATUS As String = .Item("ACTION_STATUS")

                            dt_Reassignment.Rows.Add(FULLNAME, EFFECTIVE_DATE, EMP_POSITION, FROM_BRANCH, TO_BRANCH, REMARKS, DATE_CREATED, ACTION_NAME, ACTION_STATUS)

                            frmMainForm.AppProgressBar.Value += 1
                        End With

                    Next
                    progressBarEnd()
                End If
            End Using

            Dim DATASOURCE As New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt_Reassignment)
            rptReassignment.LocalReport.DataSources.Add(DATASOURCE)
            rptReassignment.RefreshReport()

        Catch ex As Exception
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Reports_Tab_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Reports_Tab.SelectedIndexChanged
        If Reports_Tab.SelectedTab Is tabReassignment Then
            LoadReassigment()
        ElseIf Reports_Tab.SelectedTab Is tabDeduction Then
            Lists_Deduction_History(DeducHistory_List)
        ElseIf Reports_Tab.SelectedTab Is tabSBU Then
            Lists_SBU(SBU_LV)
        ElseIf Reports_Tab.SelectedTab Is tab13month Then
            PopulateDateRange13Month()
        End If
    End Sub

    Private Sub txtReassignment_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtReassignment.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            btnSearchReassign.PerformClick()
        End If
    End Sub
End Class