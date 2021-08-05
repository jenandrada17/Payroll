
Imports FirebirdSql.Data.FirebirdClient

Public Class frmPayslip
    Private Sub frmPayslip_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'LoadPayslip()
        LoadPayslippppp()
    End Sub

    Private Sub LoadPayslip()

        'Dim paydatee As String = Paydate_Combo.SelectedItem.ToString("MMMM dd, yyyy")


        Dim paydatee As String = "asdsad"

        Dim dataTable As New payslip.payslip_dataTableDataTable

        ReportViewer_payslip.LocalReport.DataSources.Clear()

        Dim paramList As New List(Of Microsoft.Reporting.WinForms.ReportParameter) From {
            New Microsoft.Reporting.WinForms.ReportParameter("paramDate", paydatee)
        }


        'New Microsoft.Reporting.WinForms.ReportParameter("paramHours", paydatee),
        'New Microsoft.Reporting.WinForms.ReportParameter("paramOtherLoan", PositionS_TXT.Text),
        'New Microsoft.Reporting.WinForms.ReportParameter("paramCharges", Person_TXT.Text),
        'New Microsoft.Reporting.WinForms.ReportParameter("paramCashAdvance", PositionP_TXT.Text),
        'New Microsoft.Reporting.WinForms.ReportParameter("paramAdditional", Department_TXT.Text),
        'New Microsoft.Reporting.WinForms.ReportParameter("paramDeduction", DateReceive),
        'New Microsoft.Reporting.WinForms.ReportParameter("paramName", IncidentLoc_TXT.Text),
        'New Microsoft.Reporting.WinForms.ReportParameter("param13Month", DateIncident_RichB.Text),
        'New Microsoft.Reporting.WinForms.ReportParameter("paramRegHoliday", Description_RichText.Text),
        'New Microsoft.Reporting.WinForms.ReportParameter("paramSpecHoliday ", IRNo_LBL.Text)

        Try
            'Dim sql As String = "select * from TBL_Employee A 
            '                            left join payroll_attendance B on B.BIOMETRICID = A.BIOMETRICID 
            '                            left join payroll_payout C on C.BIOMETRIC_ID = A.BIOMETRICID 
            '                            left join payroll_allowance D on D.BIOMETRIC_NO = A.BIOMETRICID 
            '                            left join payroll_deductions E on E.BIOMETRIC_NO = A.BIOMETRICID 
            '                            where A.BIOMETRICID = '3015';"
            Dim sql As String = "select * from TBL_Employee  where BIOMETRICID = '3015';"

            Using adapter As New FbDataAdapter(sql, con)
                adapter.Fill(dataTable)
            End Using

            Dim datasource As New Microsoft.Reporting.WinForms.ReportDataSource With
        {
            .Name = "payslip",
            .Value = dataTable
        }

            ReportViewer_payslip.LocalReport.DataSources.Add(datasource)
            ReportViewer_payslip.LocalReport.SetParameters(paramList)
            ReportViewer_payslip.RefreshReport()

        Catch ex As Exception
            Log_Report(ex.ToString)
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Private Sub LoadPayslippppp()

        'Dim paydatee As String = Paydate_Combo.SelectedItem.ToString("MMMM dd, yyyy") 

        Dim paydatee As String = "asdsad"

        Dim sada As New sample1xsd.thisSampleDataTable()

        ReportViewer1.LocalReport.DataSources.Clear()

        Dim paramList As New List(Of Microsoft.Reporting.WinForms.ReportParameter) From {
            New Microsoft.Reporting.WinForms.ReportParameter("paramName", paydatee)
        }

        'Try
        'Dim sql As String = "select * from TBL_Employee A 
        '                            left join payroll_attendance B on B.BIOMETRICID = A.BIOMETRICID 
        '                            left join payroll_payout C on C.BIOMETRIC_ID = A.BIOMETRICID 
        '                            left join payroll_allowance D on D.BIOMETRIC_NO = A.BIOMETRICID 
        '                            left join payroll_deductions E on E.BIOMETRIC_NO = A.BIOMETRICID 
        '                            where A.BIOMETRICID = '3015';"

        Dim sql As String = "select * from TBL_Employee"
        Using adapter As New FbDataAdapter(sql, con)
            adapter.Fill(sada)
        End Using

        Dim datasource As New Microsoft.Reporting.WinForms.ReportDataSource With
    {
        .Name = "DataSet1",
        .Value = sada
    }

        ReportViewer1.LocalReport.DataSources.Add(datasource)
        ReportViewer1.LocalReport.SetParameters(paramList)
        ReportViewer1.RefreshReport()

        'Catch ex As Exception
        '    Log_Report(ex.ToString)
        '    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try

    End Sub

End Class