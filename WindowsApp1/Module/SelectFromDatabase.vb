Imports System.Globalization
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

    Public Function IsLastDay(ByVal myDate As Date) As Boolean
        Return myDate.Day = Date.DaysInMonth(myDate.Year, myDate.Month)
    End Function

    Public Sub GetAttendance_Manual(bioNo As String, paydate As String, datagrid As DataGridView,
                                    TotalDays_LBL As Label, TotalRHoliday_LBL As Label, TotalSHoliday_LBL As Label,
                                    TotalLateHR_LBL As Label, TotalUTHR_LBL As Label, TotalOTHr_LBL As Label)

        'Dim mysql As String = $"Select * From BIOMETRIC_DTR where BIO_ID = '{bioNo}' and BRANCH = '{branch}' and PAYDATE = '{paydate}'"
        Dim mysql As String = $"Select * From BIOMETRIC_DTR where BIO_ID = '{bioNo}' and PAYDATE = '{paydate}'"
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


        Dim sql As String = $"Select * From PAYROLL_ATTENDANCE where BIOMETRICID = '{bioNo}' and PAYDATE = '{paydate}'"
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
                                 P_TaxWH_LBL As Label, P_SSSLoan_LBL As Label, P_PagibigLoan_LBL As Label,
                                 P_Allowance_LBL As Label, P_Deduction_LBL As Label, P_NetPay_LBL As Label)

        Dim mysql As String = $"Select SUM(GROSS_AMOUNT) as gross, SUM(SSS_COMP) as sssC, SUM(PAGIBIG_COMP) as pagibiC, SUM(PHILHEALTH_COMP) as philHC,
                                       SUM(TAX_WHELD) as taxWH, SUM(SSS_LOAN) as sssLoan, SUM(PAGIBIG_LOAN) as pagibigLoan,
                                       SUM(TOTAL_ALLOWANCE) as allowance, SUM(TOTAL_DEDUCTION) as deducttion,
                                       SUM(NET_PAY) as netPay FROM PAYROLL_PAYOUT where paydate = '{paydate}'"

        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_PAYOUT")
            If ds.Tables(0).Rows.Count > 0 Then
                Dim data As DataRow = ds.Tables(0).Rows(0)
                With data
                    P_GrossAmount_LBL.Text = CDbl(IIf(IsDBNull(.Item("gross")), 0, .Item("gross"))).ToString("N")
                    P_SSSComp_LBL.Text = CDbl(IIf(IsDBNull(.Item("sssC")), 0, .Item("sssC"))).ToString("N")
                    P_PagibigComp_LBL.Text = CDbl(IIf(IsDBNull(.Item("pagibiC")), 0, .Item("pagibiC"))).ToString("N")
                    P_PhilHComp_LBL.Text = CDbl(IIf(IsDBNull(.Item("philHC")), 0, .Item("philHC"))).ToString("N")

                    P_TaxWH_LBL.Text = CDbl(IIf(IsDBNull(.Item("taxWH")), 0, .Item("taxWH"))).ToString("N")

                    P_SSSLoan_LBL.Text = CDbl(IIf(IsDBNull(.Item("sssLoan")), 0, .Item("sssLoan"))).ToString("N")
                    P_PagibigLoan_LBL.Text = CDbl(IIf(IsDBNull(.Item("pagibigLoan")), 0, .Item("pagibigLoan"))).ToString("N")

                    P_Allowance_LBL.Text = CDbl(IIf(IsDBNull(.Item("allowance")), 0, .Item("allowance"))).ToString("N")
                    P_Deduction_LBL.Text = CDbl(IIf(IsDBNull(.Item("deducttion")), 0, .Item("deducttion"))).ToString("N")
                    P_NetPay_LBL.Text = CDbl(IIf(IsDBNull(.Item("netPay")), 0, .Item("netPay"))).ToString("N")
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

    'Public Function isExist_single(table As String, column As String, value As String)
    '    Dim mysql As String = $"Select * FROM {table} where {column} = '{value}'"
    '    Dim ds As DataSet = LoadSQL(mysql, table)
    '    If ds.Tables(0).Rows.Count > 0 Then
    '        Return True
    '    End If
    '    Return False
    'End Function

    'Public Function isExist_Double(table As String, column1 As String, value1 As String, column2 As String, value2 As String)
    '    Dim mysql As String = $"Select * FROM {table} where {column1} = '{value1}' and {column2} = '{value2}'"
    '    Dim ds As DataSet = LoadSQL(mysql, table)
    '    If ds.Tables(0).Rows.Count > 0 Then
    '        Return True
    '    End If
    '    Return False
    'End Function

    'Public Function isExist_Triple(table As String, column1 As String, value1 As String, column2 As String, value2 As String, column3 As String, value3 As String)
    '    Dim mysql As String = $"Select * FROM {table} where {column1} = '{value1}' and {column2} = '{value2}' and {column3} = '{value3}'"
    '    Dim ds As DataSet = LoadSQL(mysql, table)
    '    If ds.Tables(0).Rows.Count > 0 Then
    '        Return True
    '    End If
    '    Return False
    'End Function

    Public Function isExist_String(table As String, str As String)
        Dim mysql As String = $"Select * FROM {table} {str}"
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
                label.Text = .Item("SBU_AMOUNT")
            End With
        End If
    End Sub

    Public Sub GetEmail(email As TextBox, pass As TextBox)
        Dim mysql As String = "Select * FROM  PAYROLL_EMAIL WHERE ID = '1'"
        Dim ds As DataSet = LoadSQL(mysql, "PAYROLL_EMAIL")
        If ds.Tables(0).Rows.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            With dr
                email.Text = .Item("EMAIL")
                pass.Text = .Item("PASS")
            End With
        End If
    End Sub

    Public Function GetEmail() As String
        Dim email As String = ""
        Dim mysql As String = "Select * FROM  PAYROLL_EMAIL WHERE ID = 1"
        Dim ds As DataSet = LoadSQL(mysql, "PAYROLL_EMAIL")
        If ds.Tables(0).Rows.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            With dr
                email = .Item("EMAIL")
            End With
        End If
        Return email
    End Function

    Public Function GetBranch_ID(branch_name As String) As String

        Dim email As String = ""
        Dim mysql As String = $"Select * FROM  tbl_branch WHERE BRANCHNAME = '{branch_name}'"
        Dim ds As DataSet = LoadSQL(mysql, "tbl_branch")
        If ds.Tables(0).Rows.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            With dr
                email = .Item("ID")
            End With
        End If
        Return email
    End Function

    'Public Function GetEmail_recipient(biometric As String, branchID As String) As String
    Public Function GetEmail_recipient(biometric As String) As String

        Dim email As String = ""
        'Dim mysql As String = $"Select * FROM  tbl_Employee WHERE BIOMETRICID = '{biometric}' and BRANCH_ID= '{branchID}'"
        Dim mysql As String = $"Select * FROM  tbl_Employee WHERE BIOMETRICID = '{biometric}'"
        Dim ds As DataSet = LoadSQL(mysql, "tbl_Employee")
        If ds.Tables(0).Rows.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            With dr
                email = IIf(IsDBNull(.Item("EMAILADD")) Or String.IsNullOrWhiteSpace(.Item("EMAILADD")), "noData", .Item("EMAILADD"))
            End With
        End If
        Return email
    End Function

    Public Function GetPassword() As String
        Dim pass As String = ""
        Dim mysql As String = "Select * FROM  PAYROLL_EMAIL WHERE ID = 1"
        Dim ds As DataSet = LoadSQL(mysql, "PAYROLL_EMAIL")
        If ds.Tables(0).Rows.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            With dr
                pass = .Item("PASS")
            End With
        End If
        Return pass
    End Function

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
                    mysql &= $"{vbCr}UPPER(COMPANYNAME) Like UPPER('%{name}%') order by BIOMETRICID ASC"
                Next

            Else
                mysql = "Select * From tbl_Employee A inner join tbl_branch B on B.ID = A.BRANCH_ID  order by BIOMETRICID ASC"
            End If

            Using ds As DataSet = LoadSQL(mysql, "tbl_Employee")
                If ds.Tables(0).Rows.Count > 0 Then
                    listview.Items.Clear()
                    progressBarStart(ds.Tables(0).Rows.Count)

                    For Each dr In ds.Tables(0).Rows
                        AddItem(dr, listview)
                        frmMainForm.AppProgressBar.Value += 1
                    Next
                End If
            End Using

            progressBarEnd()

        Catch ex As Exception
            Log_Report(ex.ToString())
        End Try

    End Sub

    Private Sub AddItem(ByVal dr As DataRow, listview As ListView)

        With dr
            Dim a As Date = .Item("DATEHIRED")
            Dim datee As String
            datee = a.ToString("MMMM dd, yyyy")

            Dim MI As String

            If String.IsNullOrEmpty(.Item("MIDDLENAME")) Then
                MI = ""
            Else
                MI = .Item("MIDDLENAME").Substring(0, 1) & "."
            End If

            Dim lv As ListViewItem = listview.Items.Add(.Item("BIOMETRICID"))
            lv.SubItems.Add(String.Format("{0}, {1} {2}", .Item("LastName"), .Item("FirstName"), MI)).Tag = .Item("ID")
            lv.SubItems.Add(datee).Tag = IIf(IsDBNull(.Item("RATE")), "", .Item("RATE"))
            lv.SubItems.Add(IIf(IsDBNull(.Item("NO_OF_DAYS")), "", .Item("NO_OF_DAYS")))
            lv.SubItems.Add(IIf(IsDBNull(.Item("CONTACTNO")), "", .Item("CONTACTNO")))
            lv.SubItems.Add(IIf(IsDBNull(.Item("EmailAdd")), "", .Item("EmailAdd")))
            lv.SubItems.Add(IIf(IsDBNull(.Item("STATUS")), "", .Item("STATUS")))
            lv.SubItems.Add(IIf(IsDBNull(.Item("EMP_POSITION")), "", .Item("EMP_POSITION")))
            lv.SubItems.Add(IIf(IsDBNull(.Item("COMPANYNAME")), "", .Item("COMPANYNAME")))
            lv.SubItems.Add(IIf(IsDBNull(.Item("BRANCHNAME")), "", .Item("BRANCHNAME"))).Tag = IIf(IsDBNull(.Item("BRANCH_ID")), "", .Item("BRANCH_ID"))
        End With
    End Sub

    Public Sub Load_Loans(listview As ListView, tablee As String, Optional ByVal str As String = "")

        Try

            Dim secured_str As String = str
            secured_str = DreadKnight(secured_str)
            Dim strWords As String() = secured_str.Split(New Char() {" "c})
            Dim name As String
            Dim mysql As String
            If str.Length <> 0 Then

                mysql = $"Select * from {tablee} A inner join tbl_employee B On B.ID = A.emp_id Where "

                For Each name In strWords
                    mysql &= $"{vbCr}UPPER(BIOMETRICID) Like UPPER('%{name}%') OR "
                    mysql &= $"{vbCr}UPPER(firstname) Like UPPER('%{name}%') OR "
                    mysql &= $"{vbCr}UPPER(lastname) Like UPPER('%{name}%') OR "
                    mysql &= $"{vbCr}UPPER(A.STATUS) Like UPPER('%{name}%') OR "
                Next

            Else
                mysql = $"Select * from {tablee} A inner join tbl_employee B On B.ID = A.emp_id"
            End If

            Using ds As DataSet = LoadSQL(mysql, tablee)
                rowCount = ds.Tables(0).Rows.Count
                Dim maxEntries As Integer = ds.Tables(0).Rows.Count
                frmMainForm.AppProgressBar.Maximum = maxEntries
                frmMainForm.AppProgressBar.Visible = True
                listview.Items.Clear()
                For Each dr In ds.Tables(0).Rows
                    AddItem_Loan(dr, listview)
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

    Private Sub AddItem_Loan(ByVal dr As DataRow, listview As ListView)

        With dr
            Dim MI As String

            If String.IsNullOrEmpty(.Item("MIDDLENAME")) Then
                MI = ""
            Else
                MI = .Item("MIDDLENAME").Substring(0, 1) & "."
            End If

            Dim lv As ListViewItem = listview.Items.Add(String.Format("{0}, {1} {2}", .Item("LastName"), .Item("FirstName"), MI))
            lv.SubItems.Add(String.Format("{0}, {1} {2}", .Item("LastName"), .Item("FirstName"), MI)).Tag = .Item("ID")
            lv.SubItems.Add(.Item("monthly_amort"))
            lv.SubItems.Add(.Item("first_date	"))
            lv.SubItems.Add(.Item("maturity_date"))
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
                    RegularOT_TXT.Text = .Item("OVERTIME") & ":00"
                    RegularOT_TXT.Tag = .Item("OVERTIME")
                    SpecialHol_TXT.Text = .Item("SPECHOLIDAY")
                    RegularHol_TXT.Text = .Item("REGHOLIDAY")
                    Late_TXT.Text = .Item("LATE").Substring(0, 5)
                    Late_TXT.Tag = .Item("LATE")
                    UnderTime_TXT.Text = .Item("UNDERTIME").Substring(0, 5)
                    UnderTime_TXT.Tag = .Item("UNDERTIME")
                End With
            End If
        End Using
    End Sub

    Friend Sub Recorded_Details(emp_id As String, datagrid As DataGridView, paydate As String, transac_name As String)

        datagrid.Rows.Clear()
        Dim mysql_ As String = $"select * from RECORDED_ALLOW_DEDUC  where emp_id = '{emp_id}' and PAYDATE = '{paydate}' and TRANSAC_NAME = '{transac_name}'"
        Using ds As DataSet = LoadSQL(mysql_, "RECORDED_ALLOW_DEDUC")
            If ds.Tables(0).Rows.Count > 0 Then
                For Each dr In ds.Tables(0).Rows
                    With dr

                        Dim amountt As Double = .item("AMOUNT")

                        Dim toLower = .item("CATEGORY").ToLower()
                        Dim info As TextInfo = CultureInfo.InvariantCulture.TextInfo
                        Dim toProper As String = info.ToTitleCase(toLower)
                        Dim rowId As Integer = datagrid.Rows.Add()
                        Dim row As DataGridViewRow = datagrid.Rows(rowId)
                        row.Cells(0).Value = toProper
                        row.Cells(0).Tag = amountt.ToString(”N”)
                        row.Cells(1).Value = amountt.ToString(”N”)

                        If datagrid.Name = "Deduction_grid" Then
                            row.Cells(3).Value = "OFF"
                        End If

                    End With

                Next
            End If
        End Using
    End Sub


    Friend Sub AllowanceDetails(emp_id As String, datagrid As DataGridView, sched As String)

        datagrid.Rows.Clear()
        Dim mysql_1 As String = $"select * from payroll_allowances  where emp_id = '{emp_id}' and ALLOWED = 'YES' and (SCHEDULE = '{sched}' or SCHEDULE = 'EVERY PAYROLL')"
        Using ds As DataSet = LoadSQL(mysql_1, "payroll_allowances")
            If ds.Tables(0).Rows.Count > 0 Then
                For Each dr In ds.Tables(0).Rows
                    With dr

                        Dim amountt As Double = .item("AMOUNT")

                        Dim toLower = .item("CATEGORY").ToLower()
                        Dim info As TextInfo = CultureInfo.InvariantCulture.TextInfo
                        Dim toProper As String = info.ToTitleCase(toLower)

                        If .item("EFFECTIVE_DATE") <= Today Then

                            Dim rowId As Integer = datagrid.Rows.Add()
                            Dim row As DataGridViewRow = datagrid.Rows(rowId)
                            row.Cells(0).Value = toProper
                            row.Cells(1).Value = amountt.ToString(”N”)

                        End If

                    End With
                Next

                datagrid.Visible = True
            Else
                datagrid.Visible = False
            End If
        End Using
    End Sub

    Friend Sub DeductioneDetails_ORIG(emp_id As String, datagrid As DataGridView, sched As String)

        datagrid.Rows.Clear()

        'Dim sql_3 As String = $"Select * From PAYROLL_DEDUCTIONS WHERE EMP_ID = '{emp_id}' and STATUS is null and (SCHEDULE = '{sched}' or SCHEDULE = 'EVERY PAYROLL')"

        Dim mysql_1 As String = $"Select * From PAYROLL_DEDUCTIONS WHERE EMP_ID = '{emp_id}' and STATUS is null and (SCHEDULE = '{sched}' or SCHEDULE = 'EVERY PAYROLL')"
        Using ds As DataSet = LoadSQL(mysql_1, "PAYROLL_DEDUCTIONS")
            If ds.Tables(0).Rows.Count > 0 Then
                For Each dr In ds.Tables(0).Rows
                    With dr
                        Dim amountt As Double = .item("AMOUNT_PER_GIVE")

                        Dim toLower = .item("CATEGORY").ToLower()
                        Dim info As TextInfo = CultureInfo.InvariantCulture.TextInfo
                        Dim toProper As String = info.ToTitleCase(toLower)

                        If .item("EFFECTIVE_DATE") <= Today Then

                            Dim rowId As Integer = datagrid.Rows.Add()
                            Dim row As DataGridViewRow = datagrid.Rows(rowId)
                            row.Cells(0).Value = toProper
                            row.Cells(0).Tag = amountt.ToString(”N”)
                            row.Cells(1).Value = amountt.ToString(”N”)
                            row.Cells(3).Value = "OFF"
                            row.Cells(2).Tag = .item("ID")
                        End If
                    End With
                Next
            End If
        End Using
    End Sub

    Friend Sub DeductioneDetails_MODIFIED(EMP_ID As String, PAYDATE As String, datagrid As DataGridView, sched As String)

        datagrid.Rows.Clear()
        Dim mysql_1 As String = $"Select * From MODIFIED_DEDUCTION A inner join PAYROLL_DEDUCTIONS B on A.m_deduc_id = B.id and STATUS is null and (SCHEDULE = '{sched}' or SCHEDULE = 'EVERY PAYROLL')
                                            WHERE A.EMP_ID = '{EMP_ID}' and PAYDATE = '{PAYDATE}'"

        Using ds As DataSet = LoadSQL(mysql_1, "MODIFIED_DEDUCTION")
            If ds.Tables(0).Rows.Count > 0 Then

                For Each dr In ds.Tables(0).Rows

                    With dr

                        Dim rowId As Integer = datagrid.Rows.Add()
                        Dim row As DataGridViewRow = datagrid.Rows(rowId)

                        Dim amountt_modif As Double = .item("M_AMOUNT")
                        Dim amountt_orig As Double = .item("AMOUNT_PER_GIVE")

                        Dim toLower = .item("M_CATEGORY").ToLower()
                        Dim info As TextInfo = CultureInfo.InvariantCulture.TextInfo
                        Dim toProper As String = info.ToTitleCase(toLower)

                        row.Cells(0).Value = toProper
                        row.Cells(0).Tag = amountt_orig.ToString(”N”)
                        row.Cells(1).Value = amountt_modif.ToString(”N”)
                        row.Cells(2).Tag = .item("M_DEDUC_ID")

                        If .item("M_AMOUNT") = 0.00 Or .item("M_AMOUNT") = 0 Then
                            row.Cells(3).Value = "ON"
                        Else
                            row.Cells(3).Value = "OFF"
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

    'Public Function GetFirst_Basic(biono As String, branchID As String, paydate As String) As Double 
    Public Function GetFirst_Basic(EMP_ID As String, paydate As String) As Double
        Dim first_Basic As Double

        Dim paydate_ As DateTime = Convert.ToDateTime(paydate)
        paydate_ = paydate_.ToString("d")

        Dim first_payroll = New DateTime(paydate_.Year, paydate_.Month, 1)
        first_payroll = first_payroll.AddDays(14)

        Dim sql As String = $"Select * FROM PAYROLL_PAYOUT where EMP_ID = '{EMP_ID}' and PAYDATE = '{first_payroll.ToString("d")}'"
        Using ds As DataSet = LoadSQL(sql, "PAYROLL_PAYOUT")
            If ds.Tables(0).Rows.Count > 0 Then
                For Each dr In ds.Tables(0).Rows
                    With dr
                        first_Basic = .Item("TOTAL_BASIC")
                    End With
                Next
            Else
                first_Basic = 0
            End If
        End Using
        Return first_Basic
    End Function

    Public Function GetMonthly_Basic(EMP_ID As String, paydate As String) As Double
        Dim first_basic As Double = GetFirst_Basic(EMP_ID, paydate)
        Dim second_basic As Double = 0
        Dim monthly_Basic As Double = 0

        Dim sqll As String = $"Select * FROM PAYROLL_PAYOUT where EMP_ID = '{EMP_ID}' and PAYDATE = '{paydate}'"
        Using ds As DataSet = LoadSQL(sqll, "PAYROLL_PAYOUT")
            If ds.Tables(0).Rows.Count > 0 Then
                For Each dr In ds.Tables(0).Rows
                    With dr
                        second_basic = .Item("TOTAL_BASIC")
                    End With
                Next
            End If
        End Using

        monthly_Basic = first_basic + second_basic
        Return monthly_Basic
    End Function

    Public Function Get_SSS(monthly_Basic As String) As Double

        Console.WriteLine("monthly_Basic" & monthly_Basic)
        Dim sss As Double = 0

        Dim mysql As String = $"Select * FROM PAYROLL_SSS"
        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_SSS")
            If ds.Tables(0).Rows.Count > 0 Then
                For Each dr In ds.Tables(0).Rows
                    With dr
                        Dim range As String = .Item("RANGECOMP")
                        Dim strWords As String() = range.Split(New Char() {" "c})

                        If strWords(0).Contains("Below") Then
                            strWords(0) = 1
                        End If

                        If (Enumerable.Range(strWords(0), strWords.Last).Contains(monthly_Basic)) Then
                            'sss = .Item("TOTAL_EE")
                            sss = .Item("RSS_EE")
                        End If
                    End With
                Next
            End If
        End Using
        Return sss
    End Function

    Public Function Get_LOAN_SSS(emp_id As String) As Double
        Dim sssLoan As Double = 0

        Dim mysql As String = $"Select * From PAYROLL_SSSLOAN WHERE emp_id = '{emp_id}' and STATUS is null"
        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_SSSLOAN")
            If ds.Tables(0).Rows.Count > 0 Then

                Dim dr As DataRow = ds.Tables(0).Rows(0)
                With dr
                    sssLoan = .Item("MONTHLY_AMORT")

                End With
            End If
        End Using

        Return sssLoan
    End Function

    Public Function Get_LOAN_Pagibig(emp_id As String) As Double
        Dim pagibigLoan As Double = 0

        Dim mysql As String = $"Select * From PAYROLL_PAGIBIGLOAN WHERE EMP_ID = '{emp_id}' and STATUS is null"
        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_PAGIBIGLOAN")
            If ds.Tables(0).Rows.Count > 0 Then
                Dim dr As DataRow = ds.Tables(0).Rows(0)
                With dr
                    pagibigLoan = .Item("MONTHLY_AMORT")
                End With
            End If
        End Using

        Return pagibigLoan
    End Function

    Public Function Get_SSS_ER(monthly_Basic As String) As Double
        Dim sss_ER As Double

        Dim mysql As String = $"Select * FROM PAYROLL_SSS"
        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_SSS")
            If ds.Tables(0).Rows.Count > 0 Then
                For Each dr In ds.Tables(0).Rows
                    With dr

                        Dim range As String = .Item("RANGECOMP")
                        Dim strWords As String() = range.Split(New Char() {" "c})

                        If strWords(0).Contains("Below") Then
                            strWords(0) = 1
                        End If

                        If (Enumerable.Range(strWords(0), strWords.Last).Contains(monthly_Basic)) Then
                            sss_ER = .Item("TOTAL_ER")
                        End If
                    End With
                Next
            End If
        End Using

        Return sss_ER
    End Function

    Public Function Get_Pagibig_ER(monthly_Basic As String) As Double
        Dim pagibig_ER As Double

        Dim mysql As String = $"Select * FROM PAYROLL_PAGIBIG"
        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_PAGIBIG")
            If ds.Tables(0).Rows.Count > 0 Then
                Dim dr As DataRow = ds.Tables(0).Rows(0)
                With dr
                    pagibig_ER = .Item("EMPLOYER")
                End With
            End If
        End Using

        Return pagibig_ER
    End Function


    Public Function Get_Pagibig(monthly_Basic As String) As Double
        Dim pagibig As Double

        Dim mysql As String = $"Select * FROM PAYROLL_PAGIBIG"
        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_PAGIBIG")
            If ds.Tables(0).Rows.Count > 0 Then
                Dim dr As DataRow = ds.Tables(0).Rows(0)
                With dr
                    pagibig = .Item("EMPLOYEE")
                End With
            End If
        End Using

        Return pagibig
    End Function

    Public Function Get_PhilHealth(monthly_Basic As String) As Double
        Dim philhealth As Double

        Dim mysql As String = $"Select * FROM PAYROLL_PHILHEALTH"
        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_PHILHEALTH")
            If ds.Tables(0).Rows.Count > 0 Then
                For Each dr In ds.Tables(0).Rows
                    With dr

                        Dim convertTopercent As Decimal = .Item("PREMIUM_RATE") / 100
                        Dim total As Decimal

                        If monthly_Basic <= 10000 Then
                            total = 10000 * convertTopercent
                            philhealth = total / 2
                        Else
                            total = monthly_Basic * convertTopercent
                            philhealth = total / 2
                        End If

                    End With
                Next
            End If
        End Using

        Return philhealth
    End Function

    Public Function Get_Taxable(monthly_Basic As String) As Double
        Dim sss As Double = Get_SSS(monthly_Basic)
        Dim pagibig As Double = Get_Pagibig(monthly_Basic)
        Dim philhealth As Double = Get_PhilHealth(monthly_Basic)
        Dim taxable As Double

        taxable = monthly_Basic - (sss + pagibig + philhealth)

        Return taxable
    End Function

    Public Function Get_WHolding(monthly_Basic As String) As Double
        Dim taxable As Double = Get_Taxable(monthly_Basic)
        Dim Tax_Wheld As Double
        Dim mysql As String = $"Select * FROM PAYROLL_WHOLDING"
        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_WHOLDING")
            If ds.Tables(0).Rows.Count > 0 Then
                For Each dr In ds.Tables(0).Rows
                    With dr

                        Dim range As String = .Item("COMP_RANGE")
                        Dim range_array As String() = range.Split(New Char() {" "c})

                        Dim prescribe_WH As String = .Item("PRESCRIBE_WH_TAX")
                        Dim prescrib_array As String() = prescribe_WH.Split(New Char() {" "c})

                        If range_array.Last.Contains("elow") Then
                            Tax_Wheld = 0
                        Else
                            Dim onlyDigits = New String(prescrib_array(2).Where(Function(c) Char.IsDigit(c)).ToArray())
                            Dim num = Int32.Parse(onlyDigits)
                            Dim percent = num / 100

                            If range.Contains("above") Then
                            Else
                                If (Enumerable.Range(range_array.First, range_array.Last).Contains(taxable)) Then
                                    Tax_Wheld = (CDbl(taxable) - CDbl(prescrib_array.Last)) * percent
                                End If
                            End If
                        End If

                    End With
                Next
            End If
        End Using

        Return Tax_Wheld
    End Function

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
        Dim mysql As String = $"Select * FROM BIOMETRIC_DTR where BRANCH = '{branch}' and PAYDATE = '{PAYDATE}'"
        Dim ds As DataSet = LoadSQL(mysql, "BIOMETRIC_DTR")
        If ds.Tables(0).Rows.Count > 0 Then
            Dim result As DialogResult = MessageBox.Show("You have already imported biometric data for this branch, do you want to modify?", "Warning", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                RunCommand("DELETE FROM BIOMETRIC_DTR WHERE BRANCH = '" & branch & "' and PAYDATE = '" & PAYDATE & "';")  'THIS IS TO DELETE EXISTING ATTENDANCE IN BIOMETRIC_DTR 
                RunCommand("DELETE FROM RECORDED_ALLOW_DEDUC WHERE BRANCH = '" & branch & "' and PAYDATE = '" & PAYDATE & "';")  'THIS IS TO DELETE EXISTING ATTENDANCE IN BIOMETRIC_DTR 
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

    Friend Sub PopulateBiometricSHEET(datagrid As DataGridView, Paydate As String, Optional searchName As String = "")

        datagrid.Rows.Clear()

        Dim secured_str As String = searchName
        secured_str = DreadKnight(secured_str)
        Dim strWords As String() = secured_str.Split(New Char() {" "c})
        Dim name As String
        Dim mysql As String

        If searchName.Length <> 0 Then

            mysql = $"Select * From PAYROLL_ATTENDANCE A inner join TBL_EMPLOYEE B on B.BIOMETRICID = A.BIOMETRICID 
                                inner join TBL_BRANCH C on C.ID = B.BRANCH_ID where A.PAYDATE = '{Paydate}' and ("

            For Each name In strWords
                mysql &= $"{vbCr}UPPER(A.BIOMETRICID) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(firstname) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(lastname) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(EMP_POSITION) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(BRANCHNAME) LIKE UPPER('%{name}%') )"
            Next

        Else
            mysql = $"Select * From PAYROLL_ATTENDANCE A inner join TBL_EMPLOYEE B on B.BIOMETRICID = A.BIOMETRICID where A.PAYDATE = '{Paydate}'"
        End If


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

            row.Height = 30

        End With

    End Sub

    Public Function CountDate(list As List(Of String), datee As String) As Integer
        Dim cnt As Integer = 0
        For Each c As String In list
            If c.StartsWith(datee) Then
                cnt = cnt + 1
            End If

            Console.WriteLine("Count 12 " & cnt)
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
        Next

        Return HourGroup
    End Function

    Public Sub AdjustHeightOfGridBasedOnRows(ByVal dataGrid As DataGridView, Optional size As Integer = 0)

        If dataGrid.Rows.Count >= 0 Then
            Dim totalRowHeight As Integer = dataGrid.ColumnHeadersHeight
            For Each row As DataGridViewRow In dataGrid.Rows
                totalRowHeight += row.Height
                If size = 0 Then
                    row.Height = 28
                Else
                    row.Height = size
                End If
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

                    If combo.Name = "Branch_ComboB" Or combo.Name = "DTR_Branch_Combo" Or combo.Name = "Rate_Branch_ComboB" Or combo.Name = "Rate_Pos_ComboB" Or combo.Name = "Allow_Category_Combo" Or combo.Name = "DE_Category_Combo" Then
                        combo.Items.Add(rdr.Item(0).ToString)
                        combo.Items.Remove("")
                    Else
                        Dim datee As DateTime = rdr.Item(0).ToString
                        combo.Items.Add(datee.ToString("d"))
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

    Public Sub Payout_Details(bioNo As String, name As TextBox, ratee As TextBox)

        Dim mysql As String = "Select * From PAYROLL_EMPLOYEE WHERE BIO_NO= '" & bioNo & "'"
        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_EMPLOYEE")

            If ds.Tables(0).Rows.Count > 0 Then

                Dim data As DataRow = ds.Tables(0).Rows(0)

                With data

                    ratee.Text = IIf(IsDBNull(.Item("RATE_DAILY")), 0, .Item("RATE_DAILY"))
                    ratee.Tag = .Item("BRANCH_CODE")
                    name.Text = .Item("FULLNAME")
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

    Public Function SBU_Amount() As Double
        Dim Amount As Integer = 0
        Dim mysql As String = "Select * From payroll_sbu WHERE id= '1'"
        Using ds As DataSet = LoadSQL(mysql, "payroll_sbu")
            If ds.Tables(0).Rows.Count > 0 Then
                Dim data As DataRow = ds.Tables(0).Rows(0)
                With data
                    Amount = .Item("SBU_AMOUNT")
                End With
            End If
        End Using

        Return Amount.ToString(”N”)
    End Function

    Public Function Bio_Exist_Attendance(bioNo As String, paydate As String)
        Dim mysql As String = $"Select * FROM PAYROLL_ATTENDANCE where BIOMETRICID = '{bioNo}' and PAYDATE = '{paydate}'"
        Dim ds As DataSet = LoadSQL(mysql, "PAYROLL_ATTENDANCE")
        If ds.Tables(0).Rows.Count > 0 Then
            Return True
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

            mysql = "select A.*, A.id as allow_id, B.* from PAYROLL_ALLOWANCES A inner join TBL_EMPLOYEE B on B.ID = A.EMP_ID where ALLOWED = 'YES' and "

            For Each name In strWords
                mysql &= $"{vbCr}UPPER(BIOMETRIC_NO) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(firstname) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(lastname) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(AMOUNT) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(FIX) LIKE UPPER('%{name}%') ORDER BY LASTNAME ASC "
            Next

        Else
            mysql = "select A.*, A.id as allow_id, B.* from PAYROLL_ALLOWANCES A inner join TBL_EMPLOYEE B on B.ID = A.EMP_ID where ALLOWED = 'YES' ORDER BY LASTNAME ASC "
        End If

        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_ALLOWANCES")
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
            Dim sched As String

            If .Item("SCHEDULE") = "ONCE A MONTH" Then
                sched = .Item("SCHEDULE") & " - Every " & .Item("DAY_DATE")
            Else
                sched = .Item("SCHEDULE")
            End If


            Dim MI As String

            If String.IsNullOrEmpty(.Item("MIDDLENAME")) Then
                MI = ""
            Else
                MI = .Item("MIDDLENAME").Substring(0, 1) & "."
            End If

            Dim effectivity As DateTime = .Item("EFFECTIVE_DATE")
            Dim i As ListViewItem = LV.Items.Add(.Item("LASTNAME") & ", " & .Item("FIRSTNAME") & " " & MI)
            i.Tag = .Item("EMP_ID")
            i.SubItems.Add(.Item("CATEGORY")).Tag = .Item("allow_id")
            i.SubItems.Add(sched)
            i.SubItems.Add(effectivity.ToString("MMM dd, yyyy"))
            i.SubItems.Add(.Item("AMOUNT"))
        End With
    End Sub

    Friend Sub Lists_deduction(LV As ListView, Optional searchName As String = "")

        Dim secured_str As String = searchName
        secured_str = DreadKnight(secured_str)
        Dim strWords As String() = secured_str.Split(New Char() {" "c})
        Dim name As String
        Dim mysql As String

        If searchName.Length <> 0 Then

            'mysql = "select * from PAYROLL_DEDUCTIONS A inner join TBL_EMPLOYEE B on B.BIOMETRICID = A.BIOMETRIC_NO and B.BRANCH_ID = A.BRANCHID where ALLOWED is null  and "
            mysql = "select A.*, B.*, B.id as emp_id from PAYROLL_DEDUCTIONS A inner join TBL_EMPLOYEE B on B.id = A.emp_id where A.STATUS is null  and "

            For Each name In strWords
                mysql &= $"{vbCr}UPPER(BIOMETRIC_NO) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(CATEGORY) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(firstname) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(lastname) LIKE UPPER('%{name}%') ORDER BY LASTNAME ASC"
            Next

        Else
            mysql = "select A.*,B.*, B.id as emp_id from PAYROLL_DEDUCTIONS A inner join TBL_EMPLOYEE B on B.id = A.emp_id where A.STATUS is null  ORDER BY LASTNAME ASC"
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
            Dim i As ListViewItem = LV.Items.Add(.Item("LASTNAME") & ", " & .Item("FIRSTNAME") & " " & .Item("MIDDLENAME"))
            i.SubItems.Add(.Item("CATEGORY")).Tag = .Item("emp_id")
            i.SubItems.Add(.Item("TOTAL_AMOUNT")).Tag = .Item("id")
            i.SubItems.Add(.Item("NO_OF_GIVES"))
            i.SubItems.Add(.Item("AMOUNT_PER_GIVE"))
            i.SubItems.Add(.Item("SCHEDULE"))
            i.SubItems.Add(GetDeduction_balance(.Item("id")))
        End With

    End Sub


    Public Function GetDeduction_balance(deduc_id As String) As String

        Dim total_amount As Double = 0
        Dim balance As String = ""
        Dim mysql As String = $"Select TOTAL_AMOUNT From PAYROLL_DEDUCTIONS where ID = '{deduc_id}' "
        Dim ds As DataSet = LoadSQL(mysql, "PAYROLL_DEDUCTIONS")
        If ds.Tables(0).Rows.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            With dr
                total_amount = .Item("TOTAL_AMOUNT")
            End With
        End If

        'If isExist_single("HISTORY_DEDUCTION", "H_DEDUC_ID", deduc_id) Then
        If isExist_String("HISTORY_DEDUCTION", $"WHERE H_DEDUC_ID = '{deduc_id}'") Then
            Dim mysql_ As String = $"Select SUM(H_AMOUNT) as tots From HISTORY_DEDUCTION where H_DEDUC_ID = '{deduc_id}'"
            Dim dSs As DataSet = LoadSQL(mysql_, "HISTORY_DEDUCTION")
            If dSs.Tables(0).Rows.Count > 0 Then
                Dim dr As DataRow = dSs.Tables(0).Rows(0)
                With dr
                    balance = total_amount - .Item("tots")
                End With
            End If
        Else
            balance = total_amount
        End If

        Return balance
    End Function

    Public Function GetDeduction_OverAll_Balance(emp_id As String) As String

        Dim total_amount = GetDeduction_TotalAmount(emp_id)
        Dim balance As Double

        If isExist_String("HISTORY_DEDUCTION", $"WHERE EMP_ID = '{emp_id}'") Then
            Dim mysql_ As String = $"Select SUM(H_AMOUNT) as tots From HISTORY_DEDUCTION A inner join PAYROLL_DEDUCTIONS B on B.EMP_ID = A.EMP_ID where B.EMP_ID = '{emp_id}' and B.STATUS is null"
            Dim dSs As DataSet = LoadSQL(mysql_, "HISTORY_DEDUCTION")
            If dSs.Tables(0).Rows.Count > 0 Then
                Dim dr As DataRow = dSs.Tables(0).Rows(0)
                With dr
                    balance = total_amount - .Item("tots")
                End With
            End If
        Else
            balance = total_amount
        End If

        Return balance
    End Function


    Public Function GetDeduction_TotalAmount(emp_id As String) As Double

        Dim total_amount As Double = 0
        Dim mysql As String = $"Select SUM(TOTAL_AMOUNT) as totals From PAYROLL_DEDUCTIONS where emp_id = '{emp_id}' AND STATUS is null"
        Dim ds As DataSet = LoadSQL(mysql, "PAYROLL_DEDUCTIONS")
        If ds.Tables(0).Rows.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            With dr
                total_amount = .Item("totals")
            End With
        End If

        Return total_amount
    End Function

    Public Function GetDeduction_OPEN(emp_id As String) As Double '=================== OPEN PAYROLL ======================

        Dim amount_per_deduc As Double = 0
        Dim mysql As String = $"Select SUM(AMOUNT_PER_GIVE) as totals From PAYROLL_DEDUCTIONS where emp_id = '{emp_id}' AND STATUS is null and SCHEDULE = 'OPEN PAYROLL'"
        Dim ds As DataSet = LoadSQL(mysql, "PAYROLL_DEDUCTIONS")
        If ds.Tables(0).Rows.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            With dr
                amount_per_deduc = IIf(IsDBNull(.Item("totals")), 0, .Item("totals"))
            End With
        End If

        Return amount_per_deduc
    End Function


    Public Function GetDeduction_CLOSE(emp_id As String) As Double '=================== CLOSE PAYROLL ======================

        Dim amount_per_deduc As Double = 0
        Dim mysql As String = $"Select SUM(AMOUNT_PER_GIVE) as totals From PAYROLL_DEDUCTIONS where emp_id = '{emp_id}' AND STATUS is null and SCHEDULE = 'CLOSE PAYROLL'"
        Dim ds As DataSet = LoadSQL(mysql, "PAYROLL_DEDUCTIONS")
        If ds.Tables(0).Rows.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            With dr
                amount_per_deduc = IIf(IsDBNull(.Item("totals")), 0, .Item("totals"))
            End With
        End If

        Return amount_per_deduc
    End Function


    Public Function GetDeduction_EVERY(emp_id As String) As Double '=================== EVERY PAYROLL ======================

        Dim amount_per_deduc As Double = 0
        Dim mysql As String = $"Select SUM(AMOUNT_PER_GIVE) as totals From PAYROLL_DEDUCTIONS where emp_id = '{emp_id}' AND STATUS is null and SCHEDULE = 'EVERY PAYROLL'"
        Dim ds As DataSet = LoadSQL(mysql, "PAYROLL_DEDUCTIONS")
        If ds.Tables(0).Rows.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            With dr
                amount_per_deduc = IIf(IsDBNull(.Item("totals")), 0, .Item("totals"))
            End With
        End If

        Return amount_per_deduc
    End Function


    Friend Sub Lists_Rate(listview As ListView, Optional searchName As String = "")

        Dim secured_str As String = searchName
        secured_str = DreadKnight(secured_str)
        Dim strWords As String() = secured_str.Split(New Char() {" "c})
        Dim name As String
        Dim mysql As String

        If searchName.Length <> 0 Then

            mysql = $"Select * From PAYROLL_EMPLOYEE where "

            For Each name In strWords
                mysql &= $"{vbCr}UPPER(COMPANY) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(BRANCH_CODE) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(FULLNAME) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(BIO_NO) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(EMP_STATUS) LIKE UPPER('%{name}%') ORDER BY COMPANY, BRANCH_CODE ASC "
            Next

        Else
            mysql = $"Select * From PAYROLL_EMPLOYEE ORDER BY COMPANY, BRANCH_CODE ASC "
        End If

        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_EMPLOYEE")
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
            Dim i As ListViewItem = listview.Items.Add(.Item("BRANCH_CODE"))
            i.SubItems.Add(.Item("FULLNAME"))
            i.SubItems.Add(.Item("BIO_NO"))
            i.SubItems.Add(IIf(IsDBNull(.Item("RATE_DAILY")), "", .Item("RATE_DAILY")))
        End With

        'With dr
        '    Dim i As ListViewItem = listview.Items.Add(.Item("BRANCHNAME"))
        '    i.SubItems.Add(.Item("LASTNAME") & ", " & .Item("FIRSTNAME") & " " & .Item("MIDDLENAME")).tag = .Item("BIOMETRICID")
        '    i.SubItems.Add(IIf(IsDBNull(.Item("EMP_POSITION")), "", .Item("EMP_POSITION")))
        '    i.SubItems.Add(IIf(IsDBNull(.Item("RATE")), "", .Item("RATE")))
        'End With

    End Sub

    Private Sub AddRow_PAYOUT(ByVal dr As DataRow, listview As ListView)

        With dr
            Dim i As ListViewItem = listview.Items.Add(.Item("LASTNAME") & ", " & .Item("FIRSTNAME") & " " & .Item("MIDDLENAME"))
            'i.SubItems.Add(.Item("TOTAL_BASIC")).Tag = .Item("BIOMETRIC_ID")
            'i.SubItems.Add(.Item("TOTAL_OVERTIME")).Tag = .Item("BRANCH_ID")
            'i.SubItems.Add(.Item("TOTAL_LATE_UT"))
            i.SubItems.Add(CDbl(.Item("GROSS_AMOUNT")).ToString("N")).Tag = .Item("BIOMETRIC_ID")
            i.SubItems.Add(CDbl(.Item("SSS_COMP")).ToString("N")).Tag = .Item("BRANCH_ID")
            i.SubItems.Add(CDbl(.Item("PAGIBIG_COMP")).ToString("N"))
            i.SubItems.Add(CDbl(.Item("PHILHEALTH_COMP")).ToString("N"))
            'i.SubItems.Add(CDbl(.Item("TAXABLE")).ToString("N"))
            i.SubItems.Add(CDbl(.Item("TAX_WHELD")).ToString("N"))
            i.SubItems.Add(CDbl(.Item("NET_TAX_COMP")).ToString("N"))
            i.SubItems.Add(CDbl(.Item("SSS_LOAN")).ToString("N"))
            i.SubItems.Add(CDbl(.Item("PAGIBIG_LOAN")).ToString("N"))
            i.SubItems.Add(CDbl(.Item("TOTAL_ALLOWANCE")).ToString("N"))
            i.SubItems.Add(CDbl(.Item("TOTAL_DEDUCTION")).ToString("N"))
            i.SubItems.Add(CDbl(.Item("NET_PAY")).ToString("N")).Tag = .Item("emp_id")

        End With

    End Sub

    Friend Sub Lists_Payout(LV As ListView, paydate As String, Optional searchName As String = "")

        Dim secured_str As String = searchName
        secured_str = DreadKnight(secured_str)
        Dim strWords As String() = secured_str.Split(New Char() {" "c})
        Dim name As String
        Dim mysql As String

        If searchName.Length <> 0 Then

            mysql = $"Select A.*, B.*, B.id as emp_id From PAYROLL_PAYOUT A inner join tbl_employee B on B.ID = A.EMP_ID where paydate = '{paydate}' and ( "

            For Each name In strWords
                mysql &= $"{vbCr}UPPER(BIOMETRIC_ID) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(firstname) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(lastname) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(EMP_POSITION) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(rate) LIKE UPPER('%{name}%') )"
            Next

        Else
            mysql = $"Select A.*, B.*, B.id as emp_id From PAYROLL_PAYOUT A inner join tbl_employee B on B.ID = A.EMP_ID where paydate ='{paydate}'"
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
                        row.Height = 30
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

    Public Sub Load_Category_LIST(LIST As ListView, table As String, coulumn As String)

        LIST.Items.Clear()
        Dim mysql As String = $"Select * From {table}"
        Using ds As DataSet = LoadSQL(mysql, table)

            For Each dr As DataRow In ds.Tables(0).Rows
                With dr
                    Dim lvitem As ListViewItem = LIST.Items.Add(.Item(coulumn))
                End With
            Next

        End Using
    End Sub

    Friend Sub Lists_Employees(LV As ListView, Optional searchName As String = "")

        Dim secured_str As String = searchName
        secured_str = DreadKnight(secured_str)
        Dim strWords As String() = secured_str.Split(New Char() {" "c})
        Dim name As String
        Dim mysql As String

        If searchName.Length <> 0 Then

            mysql = "select * from PAYROLL_EMPLOYEE where EMP_STATUS = 'ACTIVE' and "

            For Each name In strWords
                mysql &= $"{vbCr}UPPER(COMPANY) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(BRANCH_CODE) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(FULLNAME) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(BIO_NO) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(EMP_STATUS) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(EMAIL_ADD) LIKE UPPER('%{name}%') ORDER BY COMPANY, BRANCH_CODE ASC "
            Next

        Else
            mysql = "select * from PAYROLL_EMPLOYEE ORDER BY COMPANY, BRANCH_CODE ASC "
        End If

        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_EMPLOYEE")
            LV.Items.Clear()
            progressBarStart(ds.Tables(0).Rows.Count)
            For Each dr In ds.Tables(0).Rows
                AddRow_Payroll_Employee(dr, LV)

                frmMainForm.AppProgressBar.Value += 1
            Next
            progressBarEnd()
        End Using
    End Sub

    Private Sub AddRow_Payroll_Employee(ByVal dr As DataRow, LV As ListView)
        With dr
            Dim i As ListViewItem = LV.Items.Add(.Item("COMPANY"))
            i.Tag = .Item("ID")
            i.SubItems.Add(.Item("BRANCH_CODE"))
            i.SubItems.Add(.Item("FULLNAME"))
            i.SubItems.Add(.Item("BIO_NO"))
            i.SubItems.Add(IIf(IsDBNull(.Item("EMAIL_ADD")), "", .Item("EMAIL_ADD")))
        End With
    End Sub

    Public Sub GetFullname(bio_no As String, Add_Company_CB As ComboBox, Branch_ComboB As ComboBox, Fullname_TXT As TextBox, Email_TXT As TextBox, Active_RB As RadioButton, InActive_RB As RadioButton)

        Dim mysql As String = $"select * from PAYROLL_EMPLOYEE where BIO_NO = '{bio_no}'"
        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_EMPLOYEE")
            If ds.Tables(0).Rows.Count > 0 Then
                Dim dr As DataRow = ds.Tables(0).Rows(0)
                With dr
                    Add_Company_CB.SelectedItem = .Item("COMPANY")
                    Branch_ComboB.SelectedItem = .Item("BRANCH_CODE")
                    Fullname_TXT.Text = .Item("FULLNAME")
                    Email_TXT.Text = .Item("EMAIL_ADD")

                    If .Item("EMP_STATUS") = "ACTIVE" Then
                        Active_RB.Checked = True
                    Else
                        InActive_RB.Checked = True
                    End If

                End With
            Else
                Add_Company_CB.Text = ""
                Branch_ComboB.Text = ""
                Fullname_TXT.Text = ""
                Email_TXT.Text = ""
            End If
        End Using

    End Sub


    Public Sub Replacing(str As String)
        RunCommand($"DELETE FROM {str}")  'THIS IS TO DELETE EXISTING DATA TO REPLACE ESPECIALLY FROM DATAGRID
    End Sub

End Module
