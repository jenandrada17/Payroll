Public Class frmReport

    Private Sub frmReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

        Try
            Dim all_in As New dtr_all.overAllDataTable

            Dim dt_DTR As New DataTable()
            With dt_DTR
                .Columns.Add("BIOMETRICID")
                .Columns.Add("FULLNAME")
                .Columns.Add("PRESENT_DAYS")
                .Columns.Add("OVERTIME")
                .Columns.Add("LATE")
                .Columns.Add("DATE_ONLY")
                .Columns.Add("AM_IN")
                .Columns.Add("AM_OUT")
                .Columns.Add("PM_IN")
                .Columns.Add("PM_OUT")
                .Columns.Add("REGHOLIDAY")
                .Columns.Add("SPECHOLIDAY")
            End With

            mysqll = $"Select A.*, B.FULLNAME, B.BIO_NO as bioNo, C.* From PAYROLL_PAYOUT A 
                                        inner JOIN PAYROLL_EMPLOYEE B ON B.BIO_NO = A.BIOMETRICID 
                                        where A.PAYDATE  = '{paydatee}' ORDER BY COMPANY, BRANCH_CODE, FULLNAME ASC"

            Using ds As DataSet = LoadSQL(mysqll, "PAYROLL_ATTENDANCE")

                If ds.Tables(0).Rows.Count > 0 Then

                    For Each dr In ds.Tables(0).Rows
                        With dr

                            '============================= NAME AND ATTENDANCE ============================  
                            Dim namee As String = .Item("FULLNAME")
                            Dim bioNo As String = .Item("bioNo")
                            Dim DAYS As String = .Item("PRESENT_DAYS")
                            Dim OT As String = IIf(.Item("OVERTIME") = 0, 0, .Item("OVERTIME"))
                            Dim LATE As String = IIf(.Item("LATE").Equals("00:00:00"), "00:00:00", .Item("LATE").Substring(0, 5))
                            Dim REGHOLIDAY As String = .Item("REGHOLIDAY")
                            Dim SPECHOLIDAY As String = .Item("SPECHOLIDAY")


                            '============================= BIOMETRIC_DTR ============================
                            Dim dateE As DateTime = Convert.ToDateTime(.Item("DATE_ONLY"))
                            Dim AM_IN = IIf(IsDBNull(.Item("AM_IN")), "", .Item("AM_IN"))
                            Dim AM_OUT = IIf(IsDBNull(.Item("AM_OUT")), "", .Item("AM_OUT"))
                            Dim PM_IN = IIf(IsDBNull(.Item("PM_IN")), "", .Item("PM_IN"))
                            Dim PM_OUT = IIf(IsDBNull(.Item("PM_OUT")), "", .Item("PM_OUT"))

                            dt_DTR.Rows.Add(bioNo, namee, DAYS, OT, LATE, dateE.ToString("MMM dd, yyyy"), AM_IN, AM_OUT, PM_IN, PM_OUT, REGHOLIDAY, SPECHOLIDAY)

                        End With
                    Next

                End If
            End Using

            Dim rds_DTR As New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt_DTR)
            RptViewer_DTR.LocalReport.DataSources.Add(rds_DTR)
            RptViewer_DTR.RefreshReport()

        Catch ex As Exception
            Log_Report(ex.ToString)
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

End Class