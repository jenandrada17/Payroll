Imports FirebirdSql.Data.FirebirdClient

Module SelectFromDatabase

    Dim rowCount As Integer

    'Friend Sub Grid_Payout(dataGrid As DataGridView, paydate As String, Optional searchName As String = "")

    '    Dim secured_str As String = searchName
    '    secured_str = DreadKnight(secured_str)
    '    Dim strWords As String() = secured_str.Split(New Char() {" "c})
    '    Dim name As String
    '    Dim mysql As String

    '    If searchName.Length <> 0 Then

    '        mysql = $"Select * From PAYROLL_PAYOUT A inner join tbl_employee B on B.BIOMETRICID = A.BIOMETRIC_ID  inner join tbl_branch C on C.ID = B.BRANCH_ID  where paydate =' {paydate}' and "

    '        For Each name In strWords
    '            mysql &= $"{vbCr}UPPER(BIOMETRIC_ID) LIKE UPPER('%{name}%') OR "
    '            mysql &= $"{vbCr}UPPER(firstname) LIKE UPPER('%{name}%') OR "
    '            mysql &= $"{vbCr}UPPER(lastname) LIKE UPPER('%{name}%') OR "
    '            mysql &= $"{vbCr}UPPER(EMP_POSITION) LIKE UPPER('%{name}%') OR "
    '            mysql &= $"{vbCr}UPPER(rate) LIKE UPPER('%{name}%') "
    '        Next

    '    Else
    '        mysql = $"Select * From PAYROLL_PAYOUT A inner join tbl_employee B on B.BIOMETRICID = A.BIOMETRIC_ID  inner join tbl_branch C on C.ID = B.BRANCH_ID  where paydate =' {paydate}'"
    '    End If

    '    Using ds As DataSet = LoadSQL(mysql, "PAYROLL_PAYOUT")
    '        dataGrid.Rows.Clear()
    '        progressBarStart(ds)
    '        For Each dr In ds.Tables(0).Rows
    '            AddRow_PAYOUT_GRID(dr, dataGrid)

    '            frmMainForm.AppProgressBar.Value += 1
    '        Next
    '        progressBarEnd()
    '    End Using

    'End Sub


    'Private Sub AddRow_PAYOUT_GRID(ByVal dr As DataRow, dataGrid As DataGridView)

    '    With dr
    '        Dim rowId As Integer = dataGrid.Rows.Add()
    '        Dim row As DataGridViewRow = dataGrid.Rows(rowId)
    '        row.Cells("Name_dgv").Value = .Item("LASTNAME") & ", " & .Item("FIRSTNAME") & " " & .Item("MIDDLENAME")
    '        row.Cells("Name_dgv").Tag = .Item("BIOMETRICID")
    '        row.Cells("basic_dgv").Value = .Item("TOTAL_BASIC")
    '        row.Cells("basic_dgv").Tag = .Item("BRANCH_ID")
    '        row.Cells("overtime_dgv").Value = .Item("TOTAL_OVERTIME")
    '        row.Cells("late_dgv").Value = .Item("TOTAL_LATE_UT")
    '        row.Cells("gross_dgv").Value = .Item("GROSS_AMOUNT")
    '        row.Cells("sssDis_dgv").Value = .Item("SSS_COMP")
    '        row.Cells("PagibigDis_dgv").Value = .Item("PAGIBIG_COMP")
    '        row.Cells("philH_dgv").Value = .Item("PHILHEALTH_COMP")
    '        row.Cells("taxable_dgv").Value = .Item("TAXABLE")
    '        row.Cells("taxWH_dgv").Value = .Item("TAX_WHELD")
    '        row.Cells("netTax_dgv").Value = .Item("NET_TAX_COMP")
    '        row.Cells("sssLoan_dgv").Value = .Item("SSS_LOAN")
    '        row.Cells("pagibigLoan_dgv").Value = .Item("PAGIBIG_LOAN")
    '        row.Cells("allowance_dgv").Value = .Item("TOTAL_ALLOWANCE")
    '        row.Cells("deduction_dgv").Value = .Item("TOTAL_DEDUCTION")
    '        row.Cells("netPay_dgv").Value = .Item("NET_PAY")
    '        row.Height = 35
    '    End With

    'End Sub

    Public Sub GetAttendance_Manual(bioNo As String, branch As String, paydate As String, datagrid As DataGridView,
                                    TotalDays_LBL As Label, TotalRHoliday_LBL As Label, TotalSHoliday_LBL As Label,
                                    TotalLateHR_LBL As Label, TotalUTHR_LBL As Label, TotalOTHr_LBL As Label)

        Dim mysql As String = $"Select * From BIOMETRIC_DTR where BIO_ID = '{bioNo}' and BRANCH = '{branch}' and PAYDATE = '{paydate}'"
        Using ds As DataSet = LoadSQL(mysql, "BIOMETRIC_DTR")
            If ds.Tables(0).Rows.Count > 0 Then
                For Each dr In ds.Tables(0).Rows
                    With dr

                        Dim date_ As Date = .Item("DATE_ONLY")

                        For Each row As DataGridViewRow In datagrid.Rows

                            Dim rowIndex As Integer = row.Index
                            Dim asss As Date = datagrid.Rows(rowIndex).Tag

                            If asss = date_ Then
                                row.Cells(1).Value = IIf(IsDBNull(.Item("AM_IN")), "", .Item("AM_IN"))
                                row.Cells(2).Value = IIf(IsDBNull(.Item("AM_OUT")), "", .Item("AM_OUT"))
                                row.Cells(3).Value = IIf(IsDBNull(.Item("PM_IN")), "", .Item("PM_IN"))
                                row.Cells(4).Value = IIf(IsDBNull(.Item("PM_OUT")), "", .Item("PM_OUT"))
                                row.Cells(5) = New DataGridViewCheckBoxCell With {.Value = True}
                            End If
                        Next
                    End With
                Next
            End If
        End Using


        Dim sql As String = $"Select * From PAYROLL_ATTENDANCE where BIOMETRICID = '{bioNo}' and BRANCH = '{branch}' and PAYDATE = '{paydate}'"
        Using ds As DataSet = LoadSQL(sql, "PAYROLL_ATTENDANCE")
            If ds.Tables(0).Rows.Count > 0 Then
                Dim data As DataRow = ds.Tables(0).Rows(0)
                With data
                    TotalDays_LBL.Text = .Item("PRESENT_DAYS")
                    TotalRHoliday_LBL.Text = .Item("REGHOLIDAY")
                    TotalSHoliday_LBL.Text = .Item("SPECHOLIDAY")
                    TotalLateHR_LBL.Text = IIf(IsDBNull(.Item("LATE")), "00:00:00", .Item("LATE"))
                    TotalUTHR_LBL.Text = IIf(IsDBNull(.Item("UNDERTIME")), "00:00:00", .Item("UNDERTIME"))
                    TotalOTHr_LBL.Text = .Item("OVERTIME")
                End With
            End If
        End Using

    End Sub


    Public Sub GetPayout_TOTALS(paydate As String, P_GrossAmount_LBL As Label, P_SSSComp_LBL As Label, P_PagibigComp_LBL As Label, P_PhilHComp_LBL As Label,
                                 P_Taxable_LBL As Label, P_TaxWH_LBL As Label, P_SSSLoan_LBL As Label, P_PagibigLoan_LBL As Label,
                                 P_Allowance_LBL As Label, P_Deduction_LBL As Label, P_NetPay_LBL As Label)

        Dim mysql As String = $"Select SUM(GROSS_AMOUNT) as gross, SUM(SSS_COMP) as sssC, SUM(PAGIBIG_COMP) as pagibiC, SUM(PHILHEALTH_COMP) as philHC,
                                       SUM(TAXABLE) as tax, SUM(TAX_WHELD) as taxWH, SUM(SSS_LOAN) as sssLoan, SUM(PAGIBIG_LOAN) as pagibigLoan,
                                       SUM(TOTAL_ALLOWANCE) as allowance, SUM(TOTAL_DEDUCTION) as deducttion,
                                       SUM(NET_PAY) as netPay FROM PAYROLL_PAYOUT where paydate = '{paydate}'"

        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_PAYOUT")
            If ds.Tables(0).Rows.Count > 0 Then
                Dim data As DataRow = ds.Tables(0).Rows(0)
                With data
                    P_GrossAmount_LBL.Text = IIf(IsDBNull(.Item("gross")), 0, .Item("gross"))
                    P_SSSComp_LBL.Text = IIf(IsDBNull(.Item("sssC")), 0, .Item("sssC"))
                    P_PagibigComp_LBL.Text = IIf(IsDBNull(.Item("pagibiC")), 0, .Item("pagibiC"))
                    P_PhilHComp_LBL.Text = IIf(IsDBNull(.Item("philHC")), 0, .Item("philHC"))

                    P_Taxable_LBL.Text = IIf(IsDBNull(.Item("tax")), 0, .Item("tax"))
                    P_TaxWH_LBL.Text = IIf(IsDBNull(.Item("taxWH")), 0, .Item("taxWH"))

                    P_SSSLoan_LBL.Text = IIf(IsDBNull(.Item("sssLoan")), 0, .Item("sssLoan"))
                    P_PagibigLoan_LBL.Text = IIf(IsDBNull(.Item("pagibigLoan")), 0, .Item("pagibigLoan"))

                    P_Allowance_LBL.Text = IIf(IsDBNull(.Item("allowance")), 0, .Item("allowance"))
                    P_Deduction_LBL.Text = IIf(IsDBNull(.Item("deducttion")), 0, .Item("deducttion"))
                    P_NetPay_LBL.Text = IIf(IsDBNull(.Item("netPay")), 0, .Item("netPay"))
                End With
            End If
        End Using
    End Sub

    Public Function ThisHasRow(table As String)
        Dim mysql As String = "Select * FROM " & table & ""
        Dim ds As DataSet = LoadSQL(mysql, table)
        If ds.Tables(0).Rows.Count > 0 Then
            Return True
        End If
        Return False
    End Function

    Public Sub GetSBU(label As Label)
        Dim mysql As String = "Select * FROM  PAYROLL_SBU WHERE ID = 1"
        Dim ds As DataSet = LoadSQL(mysql, "PAYROLL_SBU")
        If ds.Tables(0).Rows.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            With dr
                label.Text = .Item("AMOUNT")
            End With
        End If
    End Sub

    Public Sub LoadEmployee(listview As ListView, Optional ByVal str As String = "")

        Try

            Dim secured_str As String = str
            secured_str = DreadKnight(secured_str)
            Dim strWords As String() = secured_str.Split(New Char() {" "c})
            Dim name As String
            Dim mysql As String
            If str.Length <> 0 Then

                mysql = "Select * from tbl_Employee A inner join tbl_branch B On B.ID = A.BRANCH_ID Where "

                For Each name In strWords
                    mysql &= $"{vbCr}UPPER(BIOMETRICID) Like UPPER('%{name}%') OR "
                    mysql &= $"{vbCr}UPPER(firstname) Like UPPER('%{name}%') OR "
                    mysql &= $"{vbCr}UPPER(lastname) Like UPPER('%{name}%') OR "
                    mysql &= $"{vbCr}UPPER(branchname) Like UPPER('%{name}%') OR "
                    mysql &= $"{vbCr}UPPER(A.STATUS) Like UPPER('%{name}%') OR "
                    mysql &= $"{vbCr}UPPER(COMPANYNAME) Like UPPER('%{name}%')"
                Next

            Else
                mysql = "Select * From tbl_Employee A inner join tbl_branch B on B.ID = A.BRANCH_ID"
            End If

            Using ds As DataSet = LoadSQL(mysql, "tbl_Employee")
                rowCount = ds.Tables(0).Rows.Count
                Dim maxEntries As Integer = ds.Tables(0).Rows.Count
                frmMainForm.AppProgressBar.Maximum = maxEntries
                frmMainForm.AppProgressBar.Visible = True
                listview.Items.Clear()
                For Each dr In ds.Tables(0).Rows
                    AddItem(dr, listview)
                    frmMainForm.AppProgressBar.Value += 1
                Next
            End Using

            frmMainForm.AppProgressBar.Value = 0
            frmMainForm.AppProgressBar.Maximum = 1000
            frmMainForm.AppProgressBar.Visible = False
        Catch ex As Exception
            Log_Report(ex.ToString())
        End Try
    End Sub

    Private Sub AddItem(ByVal dr As DataRow, listview As ListView)

        With dr
            Dim a As Date = .Item("DATEHIRED")
            Dim datee As String
            datee = a.ToString("MMMM dd, yyyy")

            Dim lv As ListViewItem = listview.Items.Add(.Item("BIOMETRICID"))
            lv.SubItems.Add(String.Format("{0}, {1} {2}", .Item("LastName"), .Item("FirstName"), .Item("MiddleName")))
            lv.Tag = .Item("ID")
            lv.SubItems.Add(datee)
            lv.SubItems.Add(.Item("NO_OF_DAYS"))
            lv.SubItems.Add(.Item("CONTACTNO"))
            lv.SubItems.Add(.Item("EmailAdd"))
            lv.SubItems.Add(.Item("STATUS"))
            lv.SubItems.Add(.Item("EMP_POSITION"))
            lv.SubItems.Add(.Item("COMPANYNAME"))
            lv.SubItems.Add(.Item("BRANCHNAME")).Tag = .Item("BRANCH_ID")
        End With
    End Sub


    Friend Sub REGULDARHolidayLists(LV As ListView)
        Dim sql As String = "select  DATEE, NAME from PAYROLL_HOLIDAY where KINDS = 'REGULAR' "

        Using rdr As FbDataReader = LoadSQL_byDataReader(sql)
            LV.Items.Clear()

            While rdr.Read()
                If rdr.HasRows Then
                    With rdr
                        Dim i As ListViewItem = LV.Items.Add(.Item("DATEE"))
                        i.SubItems.Add(.Item("NAME"))
                    End With
                End If
            End While
        End Using
    End Sub

    Friend Sub SPECIALHolidayLists(LV As ListView)
        Dim sql As String = "select DATEE, NAME from PAYROLL_HOLIDAY where KINDS = 'SPECIAL' "

        Using rdr As FbDataReader = LoadSQL_byDataReader(sql)
            LV.Items.Clear()

            While rdr.Read()
                If rdr.HasRows Then
                    With rdr
                        Dim i As ListViewItem = LV.Items.Add(.Item("DATEE"))
                        i.SubItems.Add(.Item("NAME"))
                    End With
                End If
            End While
        End Using
    End Sub


    Friend Sub AttendanceDetails(biometric As String, paydate As String, NoOfDays_TXT As TextBox, RegularOT_TXT As TextBox,
                             SpecialHol_TXT As TextBox, RegularHol_TXT As TextBox, Late_TXT As TextBox,
                             UnderTime_TXT As TextBox)


        Dim mysql As String = $"Select * From PAYROLL_ATTENDANCE WHERE BIOMETRICID = '{biometric}' and paydate = '{paydate}'"
        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_ATTENDANCE")
            If ds.Tables(0).Rows.Count > 0 Then

                Dim dr As DataRow = ds.Tables(0).Rows(0)
                With dr
                    NoOfDays_TXT.Text = .Item("PRESENT_DAYS")
                    RegularOT_TXT.Text = .Item("OVERTIME")
                    SpecialHol_TXT.Text = .Item("SPECHOLIDAY")
                    RegularHol_TXT.Text = .Item("REGHOLIDAY")
                    Late_TXT.Text = .Item("LATE")
                    UnderTime_TXT.Text = .Item("UNDERTIME")
                End With
            End If
        End Using
    End Sub

    Friend Sub AllowanceDetails(biometric As String, branchID As String, Positional_TXT As TextBox, Incentive_TXT As TextBox,
                                Boarding_TXT As TextBox, Carekit_TXT As TextBox, Transport_TXT As TextBox)


        Positional_TXT.Clear()
        Incentive_TXT.Clear()
        Boarding_TXT.Clear()
        Carekit_TXT.Clear()
        Transport_TXT.Clear()

        Dim mysql As String = $"Select * From PAYROLL_ALLOWANCE WHERE BIOMETRIC_NO = '{biometric}' and BRANCH_ID = '{branchID}'"
        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_ALLOWANCE")
            If ds.Tables(0).Rows.Count > 0 Then
                For Each dr In ds.Tables(0).Rows
                    With dr
                        Positional_TXT.Text = IIf(IsDBNull(.Item("POSITIONAL")), "", .Item("POSITIONAL"))
                        Positional_TXT.Tag = IIf(IsDBNull(.Item("FIX")), "", .Item("FIX"))
                        Incentive_TXT.Text = IIf(IsDBNull(.Item("INCENTIVES")), "", .Item("INCENTIVES"))
                        Boarding_TXT.Text = IIf(IsDBNull(.Item("BOARDING")), "", .Item("BOARDING"))
                        Carekit_TXT.Text = IIf(IsDBNull(.Item("CAREKIT")), "", .Item("CAREKIT"))
                        Transport_TXT.Text = IIf(IsDBNull(.Item("TRANSPORTATION")), "", .Item("TRANSPORTATION"))
                    End With
                Next
            End If
        End Using
    End Sub

    Friend Sub DeductioneDetails(biometric As String, branchID As String, CashAdvance_TXT As TextBox, Loan_TXT As TextBox, Charges_TXT As TextBox)

        CashAdvance_TXT.Clear()
        Loan_TXT.Clear()
        Charges_TXT.Clear()

        Dim mysql As String = $"Select * From PAYROLL_DEDUCTIONS WHERE BIOMETRIC_NO = '{biometric}' and BRANCHID = '{branchID}'"
        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_DEDUCTIONS")
            If ds.Tables(0).Rows.Count > 0 Then
                For Each dr In ds.Tables(0).Rows
                    With dr

                        If .Item("CATEGORY") = "Loan" Then
                            Loan_TXT.Text = .Item("TOTAL_AMOUNT")
                        ElseIf .Item("CATEGORY") = "Charges" Then
                            Charges_TXT.Text = .Item("TOTAL_AMOUNT")
                        ElseIf .Item("CATEGORY") = "Cash Advance" Then
                            CashAdvance_TXT.Text = .Item("TOTAL_AMOUNT")
                        End If

                    End With
                Next
            End If
        End Using
    End Sub

    Friend Sub OtherDetails(biometric As String, branchID As String, PAYDATE As String, Savings_TXT As TextBox, OtherAllowance_TXT As TextBox, OtherDeduction_TXT As TextBox)

        OtherAllowance_TXT.Clear()
        OtherDeduction_TXT.Clear()
        Savings_TXT.Clear()

        Dim mysql As String = $"Select * FROM PAYROLL_PAYOUT where BIOMETRIC_ID = '{biometric}' and BRANCH_ID = '{branchID}' and PAYDATE = '{PAYDATE}'"
        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_PAYOUT")
            If ds.Tables(0).Rows.Count > 0 Then
                For Each dr In ds.Tables(0).Rows
                    With dr
                        Savings_TXT.Text = IIf(IsDBNull(.Item("SBU")), "", .Item("SBU"))
                        OtherAllowance_TXT.Text = IIf(IsDBNull(.Item("OTHER_ALLOWANCE")), "", .Item("OTHER_ALLOWANCE"))
                        OtherDeduction_TXT.Text = IIf(IsDBNull(.Item("OTHER_DEDUCTION")), "", .Item("OTHER_DEDUCTION"))
                    End With
                Next
            End If
        End Using
    End Sub

    Friend Sub Distribution_Details(biono As String, branchID As Integer, paydate As String, sss As Label, pagibig As Label, philhealth As Label,
                                    Prev_Amount_lbl As Label, TaxComp_LBL As Label, Tax_Wheld_LBL As Label)

        sss.Text = 0
        pagibig.Text = 0
        philhealth.Text = 0
        TaxComp_LBL.Text = 0
        Tax_Wheld_LBL.Text = 0

        Dim first_Basic, second_Basic, Monthly_Total As Double

        Dim paydate_ As DateTime = Convert.ToDateTime(paydate)
        paydate_ = paydate_.ToString("d")

        Dim first_payroll = New DateTime(paydate_.Year, paydate_.Month, 1)
        first_payroll = first_payroll.AddDays(14)
        '=================================================================== 1st Payroll ===========================================================
        Dim sql As String = $"Select * FROM PAYROLL_PAYOUT where BIOMETRIC_ID = '{biono}' and BRANCH_ID = '{branchID}' and PAYDATE = '{first_payroll.ToString("d")}'"
        Using ds As DataSet = LoadSQL(sql, "PAYROLL_PAYOUT")
            If ds.Tables(0).Rows.Count > 0 Then
                For Each dr In ds.Tables(0).Rows
                    With dr
                        first_Basic = .Item("TOTAL_BASIC")
                    End With
                Next
            End If
        End Using

        '=================================================================== 2nd Payroll ===========================================================
        Dim sqll As String = $"Select * FROM PAYROLL_PAYOUT where BIOMETRIC_ID = '{biono}' and BRANCH_ID = '{branchID}' and PAYDATE = '{paydate_.ToString("d")}'"
        Using ds As DataSet = LoadSQL(sqll, "PAYROLL_PAYOUT")
            If ds.Tables(0).Rows.Count > 0 Then
                For Each dr In ds.Tables(0).Rows
                    With dr
                        second_Basic = .Item("TOTAL_BASIC")
                    End With
                Next
            End If
        End Using

        Monthly_Total = first_Basic + second_Basic
        Prev_Amount_lbl.Text = first_Basic

        '=================================================================== Total SSS ===========================================================
        Dim mysql_SSS As String = $"Select * FROM PAYROLL_SSS"
        Using ds As DataSet = LoadSQL(mysql_SSS, "PAYROLL_SSS")
            If ds.Tables(0).Rows.Count > 0 Then
                For Each dr In ds.Tables(0).Rows
                    With dr

                        Dim range As String = .Item("RANGECOMP")
                        Dim strWords As String() = range.Split(New Char() {" "c})

                        If strWords(0).Contains("Below") Then
                            strWords(0) = 1
                        End If

                        If (Enumerable.Range(strWords(0), strWords.Last).Contains(Monthly_Total)) Then
                            sss.Text = .Item("RSS_EE")
                        End If
                    End With
                Next
            End If
        End Using

        '=================================================================== Total PAGIBIG ===========================================================
        Dim mysql_PAGIBIG As String = $"Select * FROM PAYROLL_PAGIBIG"
        Using ds As DataSet = LoadSQL(mysql_PAGIBIG, "PAYROLL_PAGIBIG")
            If ds.Tables(0).Rows.Count > 0 Then
                Dim dr As DataRow = ds.Tables(0).Rows(0)
                With dr
                    pagibig.Text = .Item("EMPLOYEE")
                End With
            End If
        End Using

        '=================================================================== Total PHILHEALTH ===========================================================
        Dim mysql_PHILHEALTH As String = $"Select * FROM PAYROLL_PHILHEALTH"
        Using ds As DataSet = LoadSQL(mysql_PHILHEALTH, "PAYROLL_PHILHEALTH")
            If ds.Tables(0).Rows.Count > 0 Then
                For Each dr In ds.Tables(0).Rows
                    With dr

                        Dim convertTopercent As Decimal = .Item("PREMIUM_RATE") / 100
                        Dim total As Decimal

                        If Monthly_Total <= 10000 Then
                            total = 10000 * convertTopercent
                            philhealth.Text = total / 2
                        Else
                            total = Monthly_Total * convertTopercent
                            philhealth.Text = total / 2
                        End If

                    End With
                Next
            End If
        End Using

        TaxComp_LBL.Text = Monthly_Total - (CDbl(sss.Text) + CDbl(pagibig.Text) + CDbl(philhealth.Text))

    End Sub

    Friend Function isNotExistHoliday(datee As String)
        Dim mysql As String = "SELECT * FROM PAYROLL_HOLIDAY Where DATEE = '" & datee & "'"
        Dim ds As DataSet = LoadSQL(mysql, "PAYROLL_HOLIDAY")
        If ds.Tables(0).Rows.Count > 0 Then
            Return False
        End If

        Return True
    End Function

    Friend Function HolidayExist(datee As String)
        Dim mysql As String = "SELECT * FROM PAYROLL_HOLIDAY Where DATEE = '" & datee & "' "
        Dim ds As DataSet = LoadSQL(mysql, "PAYROLL_HOLIDAY")

        If ds.Tables(0).Rows.Count > 0 Then
            Return True
        End If

        Return False
    End Function

    Friend Sub HolidayDetails(datee As String, rowID As Integer, dategrid As DataGridView)
        Dim mysql As String = "SELECT * FROM PAYROLL_HOLIDAY Where DATEE = '" & datee & "' "
        Dim ds As DataSet = LoadSQL(mysql, "PAYROLL_HOLIDAY")

        If ds.Tables(0).Rows.Count > 0 Then

            Dim data As DataRow = ds.Tables(0).Rows(0)
            With data

                Dim r As DataGridViewRow = dategrid.Rows(rowID)
                If .Item("KINDS") = "REGULAR" Then
                    r.DefaultCellStyle.BackColor = Color.MediumOrchid
                Else
                    r.DefaultCellStyle.BackColor = Color.Plum
                End If

                dategrid.Rows(rowID).Cells(0).Value = .Item("NAME")
                dategrid.Rows(rowID).Cells(0).Tag = .Item("DATEE")
                dategrid.Rows(rowID).Cells(1).Value = ""
                dategrid.Rows(rowID).Cells(2).Value = ""
                dategrid.Rows(rowID).Cells(3).Value = ""
                dategrid.Rows(rowID).Cells(4).Value = ""
                dategrid.Rows(rowID).Cells(5).Value = False

            End With

        End If
    End Sub


    Friend Sub HolidayRate(regularRate As TextBox, SpecialRate As TextBox)

        Dim mysql As String = "Select * From PAYROLL_HOLIDAY_RATE"
        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_HOLIDAY_RATE")

            If ds.Tables(0).Rows.Count > 0 Then
                For Each dr In ds.Tables(0).Rows
                    With dr
                        If .Item("HOLIDAY") = "REGULAR" Then
                            regularRate.Text = .Item("RATE")
                        Else
                            SpecialRate.Text = .Item("RATE")
                        End If
                    End With
                Next
            End If

        End Using
    End Sub

    Public Function File_Exist(branch As String, PAYDATE As String)
        Dim mysql As String = $"Select * FROM IMPORT_DTR where BRANCH = '{branch}' and PAYDATE = '{PAYDATE}'"
        Dim ds As DataSet = LoadSQL(mysql, "IMPORT_DTR")
        If ds.Tables(0).Rows.Count > 0 Then
            Dim result As DialogResult = MessageBox.Show("File already imported, Do you want to modify?", "Warning", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                RunCommand("DELETE FROM IMPORT_DTR WHERE BRANCH = '" & branch & "' and PAYDATE = '" & PAYDATE & "';")  'THIS IS TO DELETE EXISTING SHEETS IN IMPORT_DTR
                RunCommand("DELETE FROM BIOMETRIC_DTR WHERE BRANCH = '" & branch & "' and PAYDATE = '" & PAYDATE & "';")  'THIS IS TO DELETE EXISTING ATTENDANCE IN BIOMETRIC_DTR
                Return True
            End If
        End If
        Return False
    End Function

    Public Function File_NOT_Exist(branch As String, PAYDATE As String)
        Dim mysql As String = $"Select * FROM IMPORT_DTR where BRANCH = '{branch}' and PAYDATE = '{PAYDATE}'"
        Dim ds As DataSet = LoadSQL(mysql, "IMPORT_DTR")
        If ds.Tables(0).Rows.Count > 0 Then
            Return False
        Else
            Return True
        End If
        Return False
    End Function


    Public Function File_Exist_f200(branch As String, PAYDATE As String)
        Dim mysql As String = $"Select * FROM BIOMETRIC_DTR where BRANCH = '{branch}' and PAYDATE = '{PAYDATE}'"
        Dim ds As DataSet = LoadSQL(mysql, "BIOMETRIC_DTR")
        If ds.Tables(0).Rows.Count > 0 Then
            Dim result As DialogResult = MessageBox.Show("File already imported, Do you want to modify?", "Warning", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                RunCommand("DELETE FROM IMPORT_DTR WHERE BRANCH = '" & branch & "' and PAYDATE = '" & PAYDATE & "';")  'THIS IS TO DELETE EXISTING SHEETS IN IMPORT_DTR
                RunCommand("DELETE FROM BIOMETRIC_DTR WHERE BRANCH = '" & branch & "' and PAYDATE = '" & PAYDATE & "';")  'THIS IS TO DELETE EXISTING ATTENDANCE IN BIOMETRIC_DTR
                Return True
            End If
        End If
        Return False
    End Function


    Friend Sub PopulateBiometricSHEET(datagrid As DataGridView, Paydate As String, BRANCHNAME As String)

        datagrid.Rows.Clear()
        Dim mysql As String = $"Select * From PAYROLL_ATTENDANCE A inner join TBL_EMPLOYEE B on B.BIOMETRICID = A.BIOMETRICID where A.PAYDATE = '{Paydate}' and A.BRANCH = '{BRANCHNAME}'"

        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_ATTENDANCE")
            If ds.Tables(0).Rows.Count > 0 Then

                For Each dr In ds.Tables(0).Rows
                    AddRowBiometric(dr, datagrid)
                Next
            Else
                datagrid.Rows.Clear()
            End If
        End Using

    End Sub

    Public Sub AddRowBiometric(ByVal dr As DataRow, datagrid As DataGridView)

        With dr

            Dim rowId As Integer = datagrid.Rows.Add()
            Dim row As DataGridViewRow = datagrid.Rows(rowId)
            row.Cells("BIOID_DGVV").Value = .Item("BIOMETRICID")
            row.Cells("Name_DGVV").Value = .Item("LASTNAME") & ", " & .Item("FIRSTNAME") & " " & .Item("MIDDLENAME")
            row.Cells("Name_DGVV").Tag = .Item("ID")
            row.Cells("PRESENT_DGVV").Value = .Item("PRESENT_DAYS")

            If .Item("OVERTIME") = 0 Then
                row.Cells("Overtime_DGVV").Value = ""
            Else
                row.Cells("Overtime_DGVV").Value = .Item("OVERTIME")
            End If

            If .Item("LATE").Equals("00:00:00") Then
                row.Cells("Late_DGVV").Value = ""
            Else
                row.Cells("Late_DGVV").Value = IIf(IsDBNull(.Item("LATE")), "", .Item("LATE"))
            End If

            If .Item("UNDERTIME").Equals("00:00:00") Then
                row.Cells("Undertime_DGVV").Value = ""
            Else
                row.Cells("Undertime_DGVV").Value = IIf(IsDBNull(.Item("UNDERTIME")), "", .Item("UNDERTIME"))
            End If

            row.Height = 35

        End With

    End Sub

    Public Function CountDate(list As List(Of String), datee As String) As Integer
        Dim cnt As Integer = 0
        For Each c As String In list
            If c.StartsWith(datee) Then
                cnt = cnt + 1
            End If

            Console.WriteLine("CountDate list_value- " & c & "val " & datee)
        Next

        Return cnt
    End Function

    Public Function SortCountedDATE(list As List(Of String), datee As String) As List(Of String)

        Dim HourGroup As New List(Of String)()
        For Each c As String In list
            If c.StartsWith(datee) Then
                Dim AAA As DateTime = c
                AAA = AAA.ToString("t")
                HourGroup.Add(AAA)
            End If

            Console.WriteLine("SortCountedDATE " & c & "val " & datee)
        Next

        Return HourGroup
    End Function

    Public Sub AdjustHeightOfGridBasedOnRows(ByVal dataGrid As DataGridView)

        If dataGrid.Rows.Count > 0 Then
            Dim totalRowHeight As Integer = dataGrid.ColumnHeadersHeight
            For Each row As DataGridViewRow In dataGrid.Rows
                totalRowHeight += row.Height
            Next
            dataGrid.Height = totalRowHeight
        End If

    End Sub

    Public Sub PopulateComboBox(combo As ComboBox, table As String, column As String)
        Dim sql As String = $"select distinct({column}) from {table}"
        Dim rdr As FbDataReader = LoadSQL_byDataReader(sql)
        combo.Items.Clear()
        While rdr.Read()
            If rdr.HasRows Then
                With rdr

                    If combo.Name = "Paydate_ComboB" Then
                        Dim datee As DateTime = rdr.Item(0).ToString
                        combo.Items.Add(datee.ToString("d"))
                    ElseIf combo.Name = "RE_Paydate_Combo" Then
                        Dim datee As DateTime = rdr.Item(0).ToString
                        combo.Items.Add(datee.ToString("d"))
                    Else
                        combo.Items.Add(rdr.Item(0).ToString)
                        combo.Items.Remove("")
                    End If
                End With
            Else
                Exit Sub
            End If
        End While
    End Sub

    Public Function CountCELL_Nothing(row As DataGridViewRow) As Integer

        Dim count As New Integer
        If Not row.DefaultCellStyle.ForeColor = Color.Red And row.Cells(5).Value = True Then

            For cell As Integer = 1 To 4
                If row.Cells(cell).Value = Nothing Then
                    count += 1
                End If
            Next

        End If

        Return count
    End Function

    Public Function CountCELL_Consecutive(row As DataGridViewRow) As String

        Dim status As String = ""
        If Not row.DefaultCellStyle.ForeColor = Color.Red And row.Cells(5).Value = True Then

            If row.Cells(1).Value = Nothing And row.Cells(2).Value = Nothing Then
                status = "HALFDAY"
            ElseIf row.Cells(3).Value = Nothing And row.Cells(4).Value = Nothing Then
                status = "HALFDAY"
            End If

        End If

        Return status
    End Function

    Friend Sub PopulateAttendanceRECORD(datagrid As DataGridView, Paydate As String)

        datagrid.Rows.Clear()
        Dim mysql As String = $"Select * From PAYROLL_ATTENDANCE A inner join TBL_EMPLOYEE B on B.BIOMETRICID = A.BIOMETRICID where A.PAYDATE = '{Paydate}' ORDER BY BRANCH"

        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_ATTENDANCE")
            If ds.Tables(0).Rows.Count > 0 Then
                For Each dr In ds.Tables(0).Rows
                    AddRowRECORDS(dr, datagrid)
                Next
                'AdjustHeightOfGridBasedOnRows(datagrid)
            Else
                datagrid.Rows.Clear()
            End If
        End Using

    End Sub

    Public Sub AddRowRECORDS(ByVal dr As DataRow, datagrid As DataGridView)

        With dr
            Dim rowId As Integer = datagrid.Rows.Add()
            Dim row As DataGridViewRow = datagrid.Rows(rowId)
            row.Cells("RE_BIO_DGV").Value = .Item("BIOMETRICID")
            row.Cells("RE_NAME_DGV").Value = .Item("LASTNAME") & ", " & .Item("FIRSTNAME") & " " & .Item("MIDDLENAME")
            row.Cells("RE_NAME_DGV").Tag = .Item("ID")
            row.Cells("RE_OT_DGV").Value = .Item("OVERTIME")
            row.Cells("RE_LATE_DGV").Value = .Item("LATE")
            row.Cells("RE_UT_DGV").Value = .Item("UNDERTIME")
            row.Cells("RE_DAYS_DGV").Value = .Item("PRESENT_DAYS")
            row.Cells("RE_BRANCH_DGV").Value = .Item("BRANCH")
            row.Height = 35
        End With

    End Sub

    Public Sub Payout_Details(bioNo As String, name As TextBox, ratee As TextBox)

        Dim mysql As String = "Select * From tbl_employee WHERE BIOMETRICID= '" & bioNo & "'"
        Using ds As DataSet = LoadSQL(mysql, "tbl_employee")

            If ds.Tables(0).Rows.Count > 0 Then

                Dim data As DataRow = ds.Tables(0).Rows(0)

                With data

                    Dim MI As String

                    If String.IsNullOrEmpty(.Item("MIDDLENAME")) Then
                        MI = ""
                    Else
                        MI = .Item("MIDDLENAME").Substring(0, 1) & "."
                    End If

                    ratee.Text = IIf(IsDBNull(.Item("RATE")), 0, .Item("RATE"))
                    ratee.Tag = .Item("BRANCH_ID")
                    name.Text = .Item("FIRSTNAME") & " " & MI & " " & .Item("LASTNAME") & " " & .Item("SUFFIX")
                    name.Tag = .Item("ID")
                End With
            Else
                name.Text = ""
            End If
        End Using
    End Sub

    Public Function Holiday_Rate(holiday As String) As Integer
        Dim rate As Integer = 0
        Dim mysql As String = "Select * From payroll_holiday_rate WHERE HOLIDAY= '" & holiday & "'"
        Using ds As DataSet = LoadSQL(mysql, "payroll_holiday_rate")
            If ds.Tables(0).Rows.Count > 0 Then
                Dim data As DataRow = ds.Tables(0).Rows(0)
                With data
                    rate = .Item("RATE")
                End With
            End If
        End Using

        Return rate
    End Function

    Public Function SBU_Amount() As Integer
        Dim Amount As Integer = 0
        Dim mysql As String = "Select * From payroll_sbu WHERE id= '1'"
        Using ds As DataSet = LoadSQL(mysql, "payroll_sbu")
            If ds.Tables(0).Rows.Count > 0 Then
                Dim data As DataRow = ds.Tables(0).Rows(0)
                With data
                    Amount = .Item("amount")
                End With
            End If
        End Using

        Return Amount
    End Function


    Public Function Bio_Exist_Attendance(bioNo As String, paydate As String)
        Dim mysql As String = $"Select * FROM PAYROLL_ATTENDANCE where BIOMETRICID = '{bioNo}' and PAYDATE = '{paydate}'"
        Dim ds As DataSet = LoadSQL(mysql, "PAYROLL_ATTENDANCE")
        If ds.Tables(0).Rows.Count > 0 Then
            Return True
            Console.WriteLine("TRUE")
        End If
        Return False
    End Function

    Public Sub GetName(BiometricID_TXT As String, name As TextBox)

        Dim mysql As String = "Select * From tbl_Employee WHERE BIOMETRICID= '" & BiometricID_TXT & "'"
        Using ds As DataSet = LoadSQL(mysql, "tbl_Employee")
            If ds.Tables(0).Rows.Count > 0 Then
                Dim data As DataRow = ds.Tables(0).Rows(0)
                With data

                    Dim MI As String

                    If String.IsNullOrEmpty(.Item("MIDDLENAME")) Then
                        MI = ""
                    Else
                        MI = .Item("MIDDLENAME").Substring(0, 1) & "."
                    End If

                    name.Text = .Item("FIRSTNAME") & " " & MI & " " & .Item("LASTNAME") & " " & .Item("SUFFIX")
                    name.Tag = .Item("ID")

                End With
            Else
                name.Text = ""
            End If
        End Using
    End Sub

    Public Sub Get_Branch_ID(BranchName As String, combo As ComboBox)
        Dim mysql As String = "Select * FROM tbl_Branch where BRANCHNAME = '" & BranchName & "'"
        Using ds As DataSet = LoadSQL(mysql)
            If ds.Tables(0).Rows.Count > 0 Then
                Dim dr As DataRow = ds.Tables(0).Rows(0)
                With dr
                    combo.Tag = .Item("ID")
                End With
            End If
        End Using
    End Sub

    Friend Sub Lists_Allowance(LV As ListView, Optional searchName As String = "")

        Dim secured_str As String = searchName
        secured_str = DreadKnight(secured_str)
        Dim strWords As String() = secured_str.Split(New Char() {" "c})
        Dim name As String
        Dim mysql As String

        If searchName.Length <> 0 Then

            mysql = "select * from PAYROLL_ALLOWANCE A inner join TBL_EMPLOYEE B on B.BIOMETRICID = A.BIOMETRIC_NO and B.BRANCH_ID = A.BRANCH_ID where ALLOWED is null  and "

            For Each name In strWords
                mysql &= $"{vbCr}UPPER(BIOMETRIC_NO) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(firstname) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(lastname) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(FIX) LIKE UPPER('%{name}%') ORDER BY LASTNAME ASC "
            Next

        Else
            mysql = "select * from PAYROLL_ALLOWANCE A inner join TBL_EMPLOYEE B on B.BIOMETRICID = A.BIOMETRIC_NO where ALLOWED is null  ORDER BY LASTNAME ASC "
        End If

        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_ALLOWANCE")
            LV.Items.Clear()
            progressBarStart(ds.Tables(0).Rows.Count)
            For Each dr In ds.Tables(0).Rows
                AddRow_Allowance(dr, LV)
                frmMainForm.AppProgressBar.Value += 1
            Next
            progressBarEnd()
        End Using

    End Sub

    Private Sub AddRow_Allowance(ByVal dr As DataRow, LV As ListView)

        With dr
            Dim i As ListViewItem = LV.Items.Add(.Item("BIOMETRIC_NO"))
            i.SubItems.Add(.Item("LASTNAME") & ", " & .Item("FIRSTNAME") & " " & .Item("MIDDLENAME")).Tag = .Item("BRANCH_ID")
            i.SubItems.Add(IIf(IsDBNull(.Item("POSITIONAL")), "", .Item("POSITIONAL")))
            i.SubItems.Add(IIf(IsDBNull(.Item("INCENTIVES")), "", .Item("INCENTIVES")))
            i.SubItems.Add(IIf(IsDBNull(.Item("BOARDING")), "", .Item("BOARDING")))
            i.SubItems.Add(IIf(IsDBNull(.Item("CAREKIT")), "", .Item("CAREKIT")))
            i.SubItems.Add(IIf(IsDBNull(.Item("TRANSPORTATION")), "", .Item("TRANSPORTATION")))
        End With
    End Sub


    Friend Sub Lists_deduction(LV As ListView, Optional searchName As String = "")

        Dim secured_str As String = searchName
        secured_str = DreadKnight(secured_str)
        Dim strWords As String() = secured_str.Split(New Char() {" "c})
        Dim name As String
        Dim mysql As String

        If searchName.Length <> 0 Then

            mysql = "select * from PAYROLL_DEDUCTIONS A inner join TBL_EMPLOYEE B on B.BIOMETRICID = A.BIOMETRIC_NO and B.BRANCH_ID = A.BRANCHID where ALLOWED is null  and "

            For Each name In strWords
                mysql &= $"{vbCr}UPPER(BIOMETRIC_NO) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(CATEGORY) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(firstname) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(lastname) LIKE UPPER('%{name}%') ORDER BY LASTNAME ASC"
            Next

        Else
            mysql = "select * from PAYROLL_DEDUCTIONS A inner join TBL_EMPLOYEE B on B.BIOMETRICID = A.BIOMETRIC_NO and B.BRANCH_ID = A.BRANCHID where ALLOWED is null  ORDER BY LASTNAME ASC"
        End If

        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_DEDUCTIONS")
            LV.Items.Clear()
            progressBarStart(ds.Tables(0).Rows.Count)
            For Each dr In ds.Tables(0).Rows
                AddRow_Deduction(dr, LV)
                frmMainForm.AppProgressBar.Value += 1
            Next
            progressBarEnd()
        End Using

    End Sub

    Private Sub AddRow_Deduction(ByVal dr As DataRow, LV As ListView)

        With dr
            Dim i As ListViewItem = LV.Items.Add(.Item("BIOMETRIC_NO"))
            i.SubItems.Add(.Item("LASTNAME") & ", " & .Item("FIRSTNAME") & " " & .Item("MIDDLENAME")).Tag = .Item("BRANCH_ID")
            i.SubItems.Add(IIf(IsDBNull(.Item("CATEGORY")), "", .Item("CATEGORY")))
            i.SubItems.Add(IIf(IsDBNull(.Item("TOTAL_AMOUNT")), "", .Item("TOTAL_AMOUNT")))
            i.SubItems.Add(IIf(IsDBNull(.Item("NO_OF_GIVES")), "", .Item("NO_OF_GIVES")))
            i.SubItems.Add(IIf(IsDBNull(.Item("AMOUNT_PER_GIVE")), "", .Item("AMOUNT_PER_GIVE")))
        End With

    End Sub

    Friend Sub Lists_Rate(listview As ListView, Optional searchName As String = "", Optional orderBy As String = "")

        Dim secured_str As String = searchName
        secured_str = DreadKnight(secured_str)
        Dim strWords As String() = secured_str.Split(New Char() {" "c})
        Dim name As String
        Dim mysql As String

        If searchName.Length <> 0 Then

            mysql = $"Select * From TBL_EMPLOYEE A inner join TBL_BRANCH B on B.ID = A.BRANCH_ID where "

            For Each name In strWords
                mysql &= $"{vbCr}UPPER(BIOMETRICID) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(firstname) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(lastname) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(branchname) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(EMP_POSITION) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(rate) LIKE UPPER('%{name}%')  ORDER BY {orderBy}"
            Next

        Else
            mysql = $"Select * From TBL_EMPLOYEE A inner join TBL_BRANCH B on B.ID = A.BRANCH_ID ORDER BY BRANCHNAME"
        End If

        Using ds As DataSet = LoadSQL(mysql, "TBL_EMPLOYEE")
            If ds.Tables(0).Rows.Count > 0 Then

                listview.Items.Clear()
                progressBarStart(ds.Tables(0).Rows.Count)

                For Each dr In ds.Tables(0).Rows
                    AddRow_RATE(dr, listview)
                    frmMainForm.AppProgressBar.Value += 1
                Next
            End If
        End Using

        progressBarEnd()
    End Sub

    Private Sub AddRow_RATE(ByVal dr As DataRow, listview As ListView)

        With dr
            Dim i As ListViewItem = listview.Items.Add(.Item("BRANCHNAME"))
            i.SubItems.Add(.Item("LASTNAME") & ", " & .Item("FIRSTNAME") & " " & .Item("MIDDLENAME")).tag = .Item("BIOMETRICID")
            i.SubItems.Add(.Item("EMP_POSITION"))
            i.SubItems.Add(IIf(IsDBNull(.Item("RATE")), "", .Item("RATE")))
        End With

    End Sub

    Private Sub AddRow_PAYOUT(ByVal dr As DataRow, listview As ListView)

        With dr
            Dim i As ListViewItem = listview.Items.Add(.Item("LASTNAME") & ", " & .Item("FIRSTNAME") & " " & .Item("MIDDLENAME"))
            'i.SubItems.Add(.Item("TOTAL_BASIC")).Tag = .Item("BIOMETRIC_ID")
            'i.SubItems.Add(.Item("TOTAL_OVERTIME")).Tag = .Item("BRANCH_ID")
            'i.SubItems.Add(.Item("TOTAL_LATE_UT"))
            i.SubItems.Add(.Item("GROSS_AMOUNT")).Tag = .Item("BIOMETRIC_ID")
            i.SubItems.Add(.Item("SSS_COMP")).Tag = .Item("BRANCH_ID")
            i.SubItems.Add(.Item("PAGIBIG_COMP"))
            i.SubItems.Add(.Item("PHILHEALTH_COMP"))
            i.SubItems.Add(.Item("TAXABLE"))
            i.SubItems.Add(.Item("TAX_WHELD"))
            i.SubItems.Add(.Item("NET_TAX_COMP"))
            i.SubItems.Add(.Item("SSS_LOAN"))
            i.SubItems.Add(.Item("PAGIBIG_LOAN"))
            i.SubItems.Add(.Item("TOTAL_ALLOWANCE"))
            i.SubItems.Add(.Item("TOTAL_DEDUCTION"))
            i.SubItems.Add(.Item("NET_PAY"))

        End With

    End Sub

    Friend Sub Lists_Payout(LV As ListView, paydate As String, Optional searchName As String = "")

        Dim secured_str As String = searchName
        secured_str = DreadKnight(secured_str)
        Dim strWords As String() = secured_str.Split(New Char() {" "c})
        Dim name As String
        Dim mysql As String

        If searchName.Length <> 0 Then

            mysql = $"Select * From PAYROLL_PAYOUT A inner join tbl_employee B on B.BIOMETRICID = A.BIOMETRIC_ID  inner join tbl_branch C on C.ID = B.BRANCH_ID  where paydate = '{paydate}' and ( "

            For Each name In strWords
                mysql &= $"{vbCr}UPPER(BIOMETRIC_ID) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(firstname) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(lastname) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(EMP_POSITION) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(rate) LIKE UPPER('%{name}%') )"
            Next

        Else
            mysql = $"Select * From PAYROLL_PAYOUT A inner join tbl_employee B on B.BIOMETRICID = A.BIOMETRIC_ID  inner join tbl_branch C on C.ID = B.BRANCH_ID  where paydate ='{paydate}'"
        End If

        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_PAYOUT")
            LV.Items.Clear()
            progressBarStart(ds.Tables(0).Rows.Count)
            For Each dr In ds.Tables(0).Rows
                AddRow_PAYOUT(dr, LV)

                frmMainForm.AppProgressBar.Value += 1
            Next
            progressBarEnd()
        End Using

    End Sub

    Friend Sub progressBarStart(ByVal objectt As Integer)
        frmMainForm.AppProgressBar.Maximum = objectt
        frmMainForm.AppProgressBar.Visible = True
    End Sub

    Friend Sub progressBarEnd()

        frmMainForm.AppProgressBar.Value = 0
        frmMainForm.AppProgressBar.Maximum = 1000
        frmMainForm.AppProgressBar.Visible = False

    End Sub

    Friend Sub Populate_Pagibig(HMDF_EE_TXT As TextBox, HMDF_ER_TXT As TextBox)

        Dim mysql As String = $"Select * From PAYROLL_Pagibig"

        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_Pagibig")
            If ds.Tables(0).Rows.Count > 0 Then
                For Each dr In ds.Tables(0).Rows
                    With dr
                        HMDF_EE_TXT.Text = .Item("EMPLOYEE")
                        HMDF_ER_TXT.Text = .Item("EMPLOYER")
                    End With
                Next
            End If
        End Using

    End Sub

    Friend Sub Populate_PhilHeath(rate As TextBox)

        Dim mysql As String = $"Select * From PAYROLL_PHILHEALTH"
        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_PHILHEALTH")
            If ds.Tables(0).Rows.Count > 0 Then
                Dim data As DataRow = ds.Tables(0).Rows(0)
                With data
                    rate.Text = .Item("PREMIUM_RATE")
                End With
            End If
        End Using

    End Sub


    Friend Sub Populate_SSS(datagrid As DataGridView)

        datagrid.Rows.Clear()
        Dim mysql As String = $"Select * From PAYROLL_SSS "

        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_SSS")
            If ds.Tables(0).Rows.Count > 0 Then
                For Each dr In ds.Tables(0).Rows
                    With dr
                        Dim rowId As Integer = datagrid.Rows.Add()
                        Dim row As DataGridViewRow = datagrid.Rows(rowId)
                        row.Cells("one").Value = .Item("rangeComp")
                        row.Cells("two").Value = .Item("rss_ec")
                        row.Cells("three").Value = .Item("mpf")
                        row.Cells("four").Value = .Item("total")
                        row.Cells("five").Value = .Item("rss_er")
                        row.Cells("six").Value = .Item("rss_ee")
                        row.Cells("seven").Value = .Item("rss_total")
                        row.Cells("eight").Value = .Item("ec_er")
                        row.Cells("nine").Value = .Item("ec_ee")
                        row.Cells("ten").Value = .Item("ec_total")
                        row.Cells("eleven").Value = .Item("mpf_er")
                        row.Cells("twelve").Value = .Item("mpf_ee")
                        row.Cells("thirteen").Value = .Item("mpf_total")
                        row.Cells("fourteen").Value = .Item("total_er")
                        row.Cells("fifteen").Value = .Item("total_ee")
                        row.Cells("sixteen").Value = .Item("total_total")

                        row.Height = 25
                    End With
                Next
            Else
                datagrid.Rows.Clear()
            End If
        End Using

    End Sub

    Friend Sub Populate_WHOLDING_TAX(datagrid As DataGridView)

        datagrid.Rows.Clear()
        Dim mysql As String = $"Select * From PAYROLL_WHOLDING"
        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_WHOLDING")
            If ds.Tables(0).Rows.Count > 0 Then
                For Each dr In ds.Tables(0).Rows
                    With dr
                        Dim rowId As Integer = datagrid.Rows.Add()
                        Dim row As DataGridViewRow = datagrid.Rows(rowId)
                        row.Cells("range_dgv").Value = .Item("COMP_RANGE")
                        row.Cells("wh_dgv").Value = .Item("PRESCRIBE_WH_TAX")
                        row.Height = 40
                    End With
                Next
            Else
                datagrid.Rows.Clear()
            End If
        End Using

    End Sub

    Public Sub Has_Rows_Delete(table As String)

        Dim mysql As String = $"Select * FROM {table}"
        Dim dss As DataSet = LoadSQL(mysql, table)
        If dss.Tables(0).Rows.Count > 0 Then
            RunCommand($"DELETE FROM {table};")  'THIS IS TO DELETE EXISTING DATA 
        End If

    End Sub


End Module
