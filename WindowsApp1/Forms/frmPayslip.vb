Public Class frmPayslip

    Dim namee, sss, philH, tin, hdmf, payslip_no, rate_type As String
    Dim incentives, positional, total_Additional As Double
    Dim total_basic, present_days, regHoliday, specHoliday, gross_amount As String
    Dim hours, sss_comp, pagibig_comp, philh_comp, tax_WH As Double
    Dim sbu, otherLoan_perGive, charges_perGive, cash_advance_perGive, total_deduction As Double
    Dim sss_loan, pagibig_loan, net_pay As Double
    Dim thirteen_month As Double = 0

    Private Sub frmPayslip_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        LoadPayslip()
    End Sub

    Private Sub LoadPayslip()

        'Dim paydatee As String = Paydate_Combo.SelectedItem.ToString("MMMM dd, yyyy") 

        Dim paydatee As String = "7/15/2021"
        Dim int As String = "8"

        'Dim dataTable As New payslip.payslip_dataTableDataTable

        ReportViewer_payslip.LocalReport.DataSources.Clear()

        '================================================= EMPLOYEE DETAILS ==============================================
        namee = ""
        sss = ""
        philH = ""
        tin = ""
        hdmf = ""
        present_days = ""
        hours = 0
        regHoliday = ""
        specHoliday = ""

        payslip_no = "001"
        rate_type = "Daily"
        int = "8"

        Dim mysql As String = "Select * From TBL_Employee A inner join payroll_attendance B on B.BIOMETRICID = A.BIOMETRICID where A.BIOMETRICID = '3946' and B.paydate = '7/15/2021'"
        Using ds As DataSet = LoadSQL(mysql, "TBL_Employee")
            If ds.Tables(0).Rows.Count > 0 Then
                Dim data As DataRow = ds.Tables(0).Rows(0)
                With data

                    Dim MI As String

                    If String.IsNullOrEmpty(.Item("MIDDLENAME")) Then
                        MI = ""
                    Else
                        MI = .Item("MIDDLENAME").Substring(0, 1) & "."
                    End If

                    namee = .Item("FIRSTNAME") & " " & MI & " " & .Item("LASTNAME") & " " & .Item("SUFFIX")
                    sss = .Item("SSSNO")
                    philH = .Item("PHILHEALTHNO")
                    tin = .Item("TINNO")
                    hdmf = .Item("PAGIBIG")

                    present_days = .Item("PRESENT_DAYS")
                    If present_days <> 0 Then
                        hours = present_days / 0.5
                    Else
                        hours = 0
                    End If

                    regHoliday = .Item("REGHOLIDAY")
                    specHoliday = .Item("SPECHOLIDAY")

                End With
            End If
        End Using

        '================================================= ADDITIONAL ==============================================

        incentives = 0
        positional = 0
        Dim mysql_1 As String = "Select * From payroll_allowance where BIOMETRIC_NO = '3946'"
        Using ds As DataSet = LoadSQL(mysql_1, "payroll_allowance")
            If ds.Tables(0).Rows.Count > 0 Then
                Dim data As DataRow = ds.Tables(0).Rows(0)
                With data

                    incentives = IIf(IsDBNull(.Item("INCENTIVES")), 0, .Item("INCENTIVES"))
                    positional = IIf(IsDBNull(.Item("POSITIONAL")), 0, .Item("POSITIONAL"))

                End With
            End If
        End Using

        '================================================= DEDUCTION ============================================== 
        otherLoan_perGive = 0
        charges_perGive = 0
        cash_advance_perGive = 0
        Dim mysql_3 As String = $"Select * From PAYROLL_DEDUCTIONS WHERE BIOMETRIC_NO = '3946' and BRANCHID = '20' and ALLOWED is null"
        Using ds As DataSet = LoadSQL(mysql_3, "PAYROLL_DEDUCTIONS")
            If ds.Tables(0).Rows.Count > 0 Then
                For Each dr In ds.Tables(0).Rows
                    With dr

                        If .Item("CATEGORY") = "Loan" Then
                            otherLoan_perGive = .Item("AMOUNT_PER_GIVE")
                        ElseIf .Item("CATEGORY") = "Charges" Then
                            charges_perGive = .Item("AMOUNT_PER_GIVE")
                        ElseIf .Item("CATEGORY") = "Cash Advance" Then
                            cash_advance_perGive = .Item("AMOUNT_PER_GIVE")
                        End If

                    End With
                Next
            End If
        End Using

        '================================================= PAYOUT ==============================================

        total_basic = 0
        gross_amount = 0
        sss_comp = 0
        pagibig_comp = 0
        philh_comp = 0
        tax_WH = 0
        sss_loan = 0
        pagibig_loan = 0
        net_pay = 0
        sbu = 0
        Dim mysql_4 As String = "Select * From payroll_payout where BIOMETRIC_ID = '3946' and paydate = '7/15/2021'"
        Using ds As DataSet = LoadSQL(mysql_4, "payroll_payout")
            If ds.Tables(0).Rows.Count > 0 Then
                Dim data As DataRow = ds.Tables(0).Rows(0)
                With data
                    total_basic = IIf(IsDBNull(.Item("TOTAL_BASIC")), 0, .Item("TOTAL_BASIC"))
                    gross_amount = IIf(IsDBNull(.Item("GROSS_AMOUNT")), 0, .Item("GROSS_AMOUNT"))

                    sss_comp = IIf(IsDBNull(.Item("SSS_COMP")), 0, .Item("SSS_COMP"))
                    pagibig_comp = IIf(IsDBNull(.Item("PAGIBIG_COMP")), 0, .Item("PAGIBIG_COMP"))
                    philh_comp = IIf(IsDBNull(.Item("PHILHEALTH_COMP")), 0, .Item("PHILHEALTH_COMP"))
                    tax_WH = IIf(IsDBNull(.Item("TAX_WHELD")), 0, .Item("TAX_WHELD"))
                    sss_loan = IIf(IsDBNull(.Item("SSS_LOAN")), 0, .Item("SSS_LOAN"))
                    pagibig_loan = IIf(IsDBNull(.Item("PAGIBIG_LOAN")), 0, .Item("PAGIBIG_LOAN"))
                    sbu = IIf(IsDBNull(.Item("SBU")), 0, .Item("SBU"))
                    net_pay = IIf(IsDBNull(.Item("NET_PAY")), 0, .Item("NET_PAY"))

                    total_Additional = IIf(IsDBNull(.Item("OTHER_ALLOWANCE")), 0, .Item("OTHER_ALLOWANCE"))
                    total_deduction = IIf(IsDBNull(.Item("OTHER_DEDUCTION")), 0, .Item("OTHER_DEDUCTION"))
                End With
            End If
        End Using


        Dim paramList As New List(Of Microsoft.Reporting.WinForms.ReportParameter) From {
                    New Microsoft.Reporting.WinForms.ReportParameter("paramDate", paydatee),
                    New Microsoft.Reporting.WinForms.ReportParameter("paramNo", payslip_no),
                    New Microsoft.Reporting.WinForms.ReportParameter("paramRateType", rate_type),
                    New Microsoft.Reporting.WinForms.ReportParameter("paramName", namee),
                    New Microsoft.Reporting.WinForms.ReportParameter("paramNetPay", net_pay)
                    }

        'New Microsoft.Reporting.WinForms.ReportParameter("paramTIN", tin),
        'New Microsoft.Reporting.WinForms.ReportParameter("paramHDMF", hdmf),
        'New Microsoft.Reporting.WinForms.ReportParameter("paramPhilH", philH),
        'New Microsoft.Reporting.WinForms.ReportParameter("paramSSS", sss),
        'New Microsoft.Reporting.WinForms.ReportParameter("paramBasic", total_basic),
        'New Microsoft.Reporting.WinForms.ReportParameter("paramPresentDays", present_days),
        'New Microsoft.Reporting.WinForms.ReportParameter("paramHours", hours),
        'New Microsoft.Reporting.WinForms.ReportParameter("param13Month", thirteen_month),
        'New Microsoft.Reporting.WinForms.ReportParameter("paramRegHoliday", regHoliday),
        'New Microsoft.Reporting.WinForms.ReportParameter("paramSpecHoliday", specHoliday),
        'New Microsoft.Reporting.WinForms.ReportParameter("paramGrossAmount", gross_amount),
        'New Microsoft.Reporting.WinForms.ReportParameter("paramIncentives", incentives),
        'New Microsoft.Reporting.WinForms.ReportParameter("paramPositional", positional),
        'New Microsoft.Reporting.WinForms.ReportParameter("paramAdditional", total_Additional),
        'New Microsoft.Reporting.WinForms.ReportParameter("paramSSSComp", sss_comp),
        'New Microsoft.Reporting.WinForms.ReportParameter("paramPagibigComp", pagibig_comp),
        'New Microsoft.Reporting.WinForms.ReportParameter("paramPhilHComp", philh_comp),
        'New Microsoft.Reporting.WinForms.ReportParameter("paramTaxWH", tax_WH),
        'New Microsoft.Reporting.WinForms.ReportParameter("paramSBU", sbu),
        'New Microsoft.Reporting.WinForms.ReportParameter("paramSSSLoan", sss_loan),
        'New Microsoft.Reporting.WinForms.ReportParameter("paramPagibigLoan", pagibig_loan),
        'New Microsoft.Reporting.WinForms.ReportParameter("paramCharges", charges_perGive),
        'New Microsoft.Reporting.WinForms.ReportParameter("paramCashAdvance", cash_advance_perGive),
        'New Microsoft.Reporting.WinForms.ReportParameter("paramOtherLoan", otherLoan_perGive),
        'New Microsoft.Reporting.WinForms.ReportParameter("paramDeduction", total_deduction),

        Try
            '    DbOpen()
            '    Dim sql As String = "select * from TBL_Employee A 
            '                            left join payroll_attendance B on B.BIOMETRICID = A.BIOMETRICID 
            '                            left join payroll_payout C on C.BIOMETRIC_ID = A.BIOMETRICID 
            '                            left join payroll_allowance D on D.BIOMETRIC_NO = A.BIOMETRICID 
            '                            left join payroll_deductions E on E.BIOMETRIC_NO = A.BIOMETRICID 
            '                            where A.BIOMETRICID = '3946' and C.paydate = '7/15/2021' ;"

            '    Using adapter As New FbDataAdapter(sql, con)
            '        adapter.Fill(dataTable)
            '    End Using
            '    DbClose()

            '    Dim datasource As New Microsoft.Reporting.WinForms.ReportDataSource With
            '{
            '    .Name = "payslip",
            '    .Value = dataTable
            '}

            'ReportViewer_payslip.LocalReport.DataSources.Add(datasource)

            ReportViewer_payslip.LocalReport.SetParameters(paramList)
            ReportViewer_payslip.RefreshReport()

        Catch ex As Exception
            Log_Report(ex.ToString)
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    'Private Sub LoadPayslippppp()

    '    'Dim paydatee As String = Paydate_Combo.SelectedItem.ToString("MMMM dd, yyyy") 

    '    Dim paydatee As String = "asdsad"

    '    Dim tbl As New sample1xsd.thisSampleDataTable()

    '    ReportViewer1.LocalReport.DataSources.Clear()

    '    Dim paramList As New List(Of Microsoft.Reporting.WinForms.ReportParameter) From {
    '        New Microsoft.Reporting.WinForms.ReportParameter("paramName", paydatee)
    '    }

    '    Try

    '        DbOpen()
    '        Dim sql As String = "select * from TBL_Employee A 
    '                                left join payroll_attendance B on B.BIOMETRICID = A.BIOMETRICID 
    '                                left join payroll_payout C on C.BIOMETRIC_ID = A.BIOMETRICID 
    '                                left join payroll_allowance D on D.BIOMETRIC_NO = A.BIOMETRICID 
    '                                left join payroll_deductions E on E.BIOMETRIC_NO = A.BIOMETRICID 
    '                                where A.BIOMETRICID = '3015';"
    '        'Dim sql As String = "select * from TBL_EMPLOYEE where id = '8';"
    '        Using adapter As New FbDataAdapter(sql, con)
    '            adapter.Fill(tbl)
    '        End Using
    '        DbClose()

    '        Dim datasource As New Microsoft.Reporting.WinForms.ReportDataSource With
    '    {
    '        .Name = "DataSet1",
    '        .Value = tbl
    '    }

    '        ReportViewer1.LocalReport.DataSources.Add(datasource)
    '        ReportViewer1.LocalReport.SetParameters(paramList)
    '        ReportViewer1.RefreshReport()

    '    Catch ex As Exception
    '        Log_Report(ex.ToString)
    '        MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try

    'End Sub

End Class