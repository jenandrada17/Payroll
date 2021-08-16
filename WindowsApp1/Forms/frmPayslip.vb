Imports System.Globalization
Imports System.IO
Imports System.Net.Mail


Public Class frmPayslip

    Dim namee, sss, philH, tin, hdmf, payslip_no, rate_type As String
    Dim incentives, positional, total_Additional As Double
    Dim total_basic, present_days, regHoliday, specHoliday, gross_amount As String

    Private Sub Rate_EmpSelect_BTN_Click(sender As Object, e As EventArgs) Handles Rate_EmpSelect_BTN.Click
        Dim CurDir As String = Application.StartupPath
        Console.WriteLine("Easdads " & CurDir)
    End Sub

    Dim hours, sss_comp, pagibig_comp, philh_comp, tax_WH As Double
    Dim sbu, otherLoan_perGive, charges_perGive, cash_advance_perGive, total_deduction As Double
    Dim sss_loan, pagibig_loan, net_pay As Double
    Dim thirteen_month As Double = 0

    Private Sub frmPayslip_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim Smtp_Server As New SmtpClient
            Dim e_mail As New MailMessage()
            Smtp_Server.UseDefaultCredentials = False
            Smtp_Server.Credentials = New Net.NetworkCredential("dexter.dexter1717@gmail.com", "keandrejohn1")
            Smtp_Server.Port = 587
            Smtp_Server.EnableSsl = True
            Smtp_Server.Host = "smtp.gmail.com"

            e_mail = New MailMessage()
            e_mail.From = New MailAddress("dexter.dexter1717@gmail.com")
            e_mail.To.Add("jenandrada17@gmail.com")
            e_mail.Subject = "Payroll-jen"
            e_mail.IsBodyHtml = False

            Dim byteViewer As Byte() = ReportViewer_payslip.LocalReport.Render("PDF")

            Dim memoryStream = New MemoryStream(byteViewer)
            memoryStream.Seek(0, SeekOrigin.Begin)

            Dim attachment = New Attachment(memoryStream, "Payroll.pdf")
            e_mail.Attachments.Add(attachment)

            'e_mail.Body = txtMessage.Text 
            Smtp_Server.Send(e_mail)
            MsgBox("Mail Sent")

        Catch error_t As Exception
            MsgBox(error_t.ToString)
        End Try
    End Sub




    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        LoadPayslip()
    End Sub

    Private Sub LoadPayslip()

        'Dim paydatee As String = Paydate_Combo.SelectedItem.ToString("MMMM dd, yyyy") 

        Dim paydatee As String = "7/15/2021"

        ReportViewer_payslip.LocalReport.DataSources.Clear()

        Try
            '============================================ EMPLOYEE DETAILS ================================================
            Dim dt_employee As New DataTable()
            With dt_employee
                .Columns.Add("COMPLETE_NAME")
                .Columns.Add("SSSNO")
                .Columns.Add("PHILHEALTHNO")
                .Columns.Add("TINNO")
                .Columns.Add("PAGIBIG")
            End With

            Dim sql As String = "select * from TBL_Employee where BIOMETRICID = '3946';"
            Using ds As DataSet = LoadSQL(sql, "TBL_Employee")
                If ds.Tables(0).Rows.Count > 0 Then
                    Dim data As DataRow = ds.Tables(0).Rows(0)
                    With data
                        Dim namee As String = String.Format("{0}, {1} {2}", .Item("LastName"), .Item("FirstName"), .Item("MiddleName"))

                        dt_employee.Rows.Add(namee, .Item("SSSNO"), .Item("PHILHEALTHNO"), .Item("TINNO"), .Item("PAGIBIG"))
                    End With
                End If
            End Using

            Dim rds_employee As New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt_employee)
            ReportViewer_payslip.LocalReport.DataSources.Add(rds_employee)


            '============================================ EMPLOYEE ATTENDANCE AND PAYOUT ================================================
            Dim dt_attendance As New DataTable()
            With dt_attendance
                .Columns.Add("PRESENT_DAYS")
                .Columns.Add("OVERTIME")
                .Columns.Add("REGHOLIDAY")
                .Columns.Add("SPECHOLIDAY")
                .Columns.Add("TOTAL_LATE_UT")
                .Columns.Add("TOTAL_BASIC")
                .Columns.Add("TOTAL_OVERTIME")
                .Columns.Add("LATE")
                .Columns.Add("GROSS_AMOUNT")
                .Columns.Add("SSS_COMP")
                .Columns.Add("PAGIBIG_COMP")
                .Columns.Add("PHILHEALTH_COMP")
                .Columns.Add("TAX_WHELD")
                .Columns.Add("SSS_LOAN")
                .Columns.Add("PAGIBIG_LOAN")
                .Columns.Add("NET_PAY")
                .Columns.Add("SBU")
                .Columns.Add("TOTAL_DEDUCTION")
                .Columns.Add("present_hours")
            End With

            Dim mysqll As String = "select * from payroll_payout A inner join payroll_attendance B on B.BIOMETRICID = A.BIOMETRIC_ID  where A.BIOMETRIC_ID = '3946' and A.paydate = '7/15/2021';"
            Using ds As DataSet = LoadSQL(mysqll, "payroll_payout")
                If ds.Tables(0).Rows.Count > 0 Then
                    Dim data As DataRow = ds.Tables(0).Rows(0)
                    With data

                        Dim TOTAL_COMP As Double = .Item("SSS_COMP") + .Item("PAGIBIG_COMP") + .Item("PHILHEALTH_COMP") + .Item("TAX_WHELD") + .Item("SSS_LOAN") + .Item("PAGIBIG_LOAN")

                        Dim index = .Item("LATE").LastIndexOf(":") 'CUT LATE string to HH:mm   
                        Dim present_hours = (.Item("PRESENT_DAYS") / 0.5) * 4 'CALCULATE PRESENT DAYS TO HOURS

                        dt_attendance.Rows.Add(.Item("PRESENT_DAYS"), .Item("OVERTIME") & ":00", .Item("REGHOLIDAY"), .Item("SPECHOLIDAY"), CDbl(.Item("TOTAL_LATE_UT")).ToString("N"),
                                        CDbl(.Item("TOTAL_BASIC")).ToString("N"), CDbl(.Item("TOTAL_OVERTIME")).ToString("N"), .Item("LATE").Substring(0, index),
                                        CDbl(.Item("GROSS_AMOUNT")).ToString("N"), CDbl(.Item("SSS_COMP")).ToString("N"), CDbl(.Item("PAGIBIG_COMP")).ToString("N"),
                                        CDbl(.Item("PHILHEALTH_COMP")).ToString("N"), CDbl(.Item("TAX_WHELD")).ToString("N"), CDbl(.Item("SSS_LOAN")).ToString("N"),
                                        CDbl(.Item("PAGIBIG_LOAN")).ToString("N"), CDbl(.Item("NET_PAY")).ToString("N"), CDbl(.Item("SBU")).ToString("N"), TOTAL_COMP.ToString("N"),
                                        present_hours)

                    End With
                End If
            End Using

            Dim rds_attendance As New Microsoft.Reporting.WinForms.ReportDataSource("DataSet2", dt_attendance)
            ReportViewer_payslip.LocalReport.DataSources.Add(rds_attendance)


            'Dim mysqll As String = "select * from payroll_payout A left join payroll_attendance B on B.BIOMETRICID = A.BIOMETRIC_ID  where A.BIOMETRIC_ID = '3946' and A.paydate = '7/31/2021';"

            'Using adapter As New FbDataAdapter(mysqll, con)
            '    adapter.Fill(tbl_attendance)
            'End Using

            'Dim datasource As New Microsoft.Reporting.WinForms.ReportDataSource With
            '{
            '    .Name = "DataSet2",
            '    .Value = tbl_attendance
            '}
            'ReportViewer_payslip.LocalReport.DataSources.Add(datasource)

            '============================================ EMPLOYEE ALLOWANCES ================================================

            Dim dt_allowance As New DataTable()
            With dt_allowance
                .Columns.Add("CATEGORY")
                .Columns.Add("AMOUNT")
                .Columns.Add("TOTALS")
            End With

            Dim total_Allowance As Double = 0
            Dim mysql_allow As String = "select SUM(AMOUNT) as totals from payroll_allowances  where BIOMETRIC_NO = '3946';"
            Using ds As DataSet = LoadSQL(mysql_allow, "payroll_allowances")
                If ds.Tables(0).Rows.Count > 0 Then
                    Dim data As DataRow = ds.Tables(0).Rows(0)
                    With data
                        total_Allowance = .Item("totals")
                    End With
                End If
            End Using

            Dim mysql_1 As String = "select * from payroll_allowances  where BIOMETRIC_NO = '3946';"
            Using ds As DataSet = LoadSQL(mysql_1, "payroll_allowances")
                If ds.Tables(0).Rows.Count > 0 Then
                    For Each dr In ds.Tables(0).Rows
                        With dr

                            Dim amountt As Double = .item("AMOUNT")

                            Dim toLower = .item("CATEGORY").ToLower()
                            Dim info As TextInfo = CultureInfo.InvariantCulture.TextInfo
                            Dim toProper As String = info.ToTitleCase(toLower)

                            dt_allowance.Rows.Add(toProper, amountt.ToString(”N”), total_Allowance.ToString(”N”))

                        End With

                    Next
                End If
            End Using

            Dim rds_allowance As New Microsoft.Reporting.WinForms.ReportDataSource("DataSet3", dt_allowance)
            ReportViewer_payslip.LocalReport.DataSources.Add(rds_allowance)

            '============================================ EMPLOYEE OTHER DEDUCTIONS ================================================

            Dim dt_deduction As New DataTable()
            With dt_deduction
                .Columns.Add("CATEGORY")
                .Columns.Add("AMOUNT_PER_GIVE")
                .Columns.Add("TOTALS")
            End With

            Dim total_deduction As Double = 0
            Dim mysql_de As String = "select SUM(AMOUNT_PER_GIVE) as totals from payroll_deductions  where BIOMETRIC_NO = '3946';"
            Using ds As DataSet = LoadSQL(mysql_de, "payroll_deductions")
                If ds.Tables(0).Rows.Count > 0 Then
                    Dim data As DataRow = ds.Tables(0).Rows(0)
                    With data
                        total_deduction = .Item("totals")
                    End With
                End If
            End Using

            Dim mysql_2 As String = "select * from payroll_deductions  where BIOMETRIC_NO = '3946';"
            Using ds As DataSet = LoadSQL(mysql_2, "payroll_deductions")
                If ds.Tables(0).Rows.Count > 0 Then
                    For Each dr In ds.Tables(0).Rows
                        With dr

                            Dim amountt As Double = .item("AMOUNT_PER_GIVE")

                            Dim toLower = .item("CATEGORY").ToLower()
                            Dim info As TextInfo = CultureInfo.InvariantCulture.TextInfo
                            Dim toProper As String = info.ToTitleCase(toLower)

                            dt_deduction.Rows.Add(toProper, amountt.ToString(”N”), total_deduction.ToString(”N”))

                        End With

                    Next
                End If
            End Using

            Dim rds_deduction As New Microsoft.Reporting.WinForms.ReportDataSource("DataSet4", dt_deduction)
            ReportViewer_payslip.LocalReport.DataSources.Add(rds_deduction)

            '============================================ PAYDATE ================================================
            Dim paramList As New List(Of Microsoft.Reporting.WinForms.ReportParameter) From {
            New Microsoft.Reporting.WinForms.ReportParameter("paramDate", paydatee)
            }

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