Imports System.Globalization
Imports FirebirdSql.Data.FirebirdClient

Module SelectFromDatabase

    Dim rowCount As Integer

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

    'Public Function GetSingle_String(table As String, column As String, value As String, getColumn As String)
    '    Dim columnValue As Double
    '    Dim mysql As String = $"Select * FROM  {table} WHERE {column} = {value}"
    '    Dim ds As DataSet = LoadSQL(mysql, table)
    '    If ds.Tables(0).Rows.Count > 0 Then
    '        Dim dr As DataRow = ds.Tables(0).Rows(0)
    '        With dr
    '            columnValue = IIf(IsDBNull(.Item(getColumn)), Nothing, .Item(getColumn))
    '        End With
    '    End If
    '    Return columnValue
    'End Function 

    'Public Function GetSingle_Numeric(table As String, column As String, value As String, getColumn As String)
    '    Dim columnValue As Double
    '    Dim mysql As String = $"Select * FROM  {table} WHERE {column} = {value}"
    '    Dim ds As DataSet = LoadSQL(mysql, table)
    '    If ds.Tables(0).Rows.Count > 0 Then
    '        Dim dr As DataRow = ds.Tables(0).Rows(0)
    '        With dr
    '            columnValue = IIf(IsDBNull(.Item(getColumn)), 0, .Item(getColumn))
    '        End With
    '    End If
    '    Return columnValue
    'End Function

    Public Function GetMinimumRate(column As String, value As String) As Double
        Dim minimum_rate As Integer = 0
        Dim mysql As String = $"Select MINIMUM_RATE From PAYROLL_CITY_BRANCH where {column} = '{value}'"
        Dim ds As DataSet = LoadSQL(mysql, "PAYROLL_CITY_BRANCH")
        If ds.Tables(0).Rows.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            With dr
                minimum_rate = IIf(IsDBNull(.Item("MINIMUM_RATE")), 0, .Item("MINIMUM_RATE"))
            End With
        End If
        Return minimum_rate
    End Function

    Public Function GetEcola(column As String, value As String) As Double
        Dim ecola As Integer = 0
        Dim mysql As String = $"Select ECOLA From PAYROLL_CITY_BRANCH where {column} = '{value}'"
        Dim ds As DataSet = LoadSQL(mysql, "PAYROLL_CITY_BRANCH")
        If ds.Tables(0).Rows.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            With dr
                ecola = IIf(IsDBNull(.Item("ECOLA")), 0, .Item("ECOLA"))
            End With
        End If
        Return ecola
    End Function

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

    Public Function GetEmail_recipient(biometric As String) As String

        Dim email As String = ""
        Dim mysql As String = $"Select * FROM  PAYROLL_EMPLOYEE WHERE BIO_NO = '{biometric}'"
        Dim ds As DataSet = LoadSQL(mysql, "PAYROLL_EMPLOYEE")
        If ds.Tables(0).Rows.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            With dr
                email = IIf(IsDBNull(.Item("EMAIL_ADD")), "noData", .Item("EMAIL_ADD"))
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

                mysql = $"Select * from {tablee} A inner join PAYROLL_EMPLOYEE B on B.BIO_NO = A.BIO_NO Where "

                For Each name In strWords
                    mysql &= $"{vbCr}UPPER(BIO_NO) Like UPPER('%{name}%') OR "
                    mysql &= $"{vbCr}UPPER(FULLNAME) Like UPPER('%{name}%') OR "
                    mysql &= $"{vbCr}UPPER(COMPANY) Like UPPER('%{name}%') OR "
                    mysql &= $"{vbCr}UPPER(BRANCH_CODE) LIKE UPPER('%{name}%') OR "
                    mysql &= $"{vbCr}UPPER(A.STATUS) Like UPPER('%{name}%') ORDER BY FULLNAME ASC "
                Next

            Else
                mysql = $"Select * from {tablee} A inner join PAYROLL_EMPLOYEE B On B.BIO_NO = A.BIO_NO"
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
            Dim lv As ListViewItem = listview.Items.Add(.Item("FULLNAME"))
            lv.SubItems.Add(.Item("monthly_amort"))
            lv.SubItems.Add(.Item("first_date"))
            lv.SubItems.Add(.Item("maturity_date"))
        End With
    End Sub

    Friend Sub REGULDARHolidayLists(LV As ListView)

        LV.Items.Clear()
        Dim sql As String = "select * from PAYROLL_HOLIDAY where KINDS = 'REGULAR' "
        Using ds As DataSet = LoadSQL(sql, "PAYROLL_HOLIDAY")
            If ds.Tables(0).Rows.Count > 0 Then
                For Each dr In ds.Tables(0).Rows
                    With dr
                        Dim i As ListViewItem = LV.Items.Add(.Item("DATEE"))
                        i.SubItems.Add(.Item("NAME"))
                    End With
                Next

            End If
        End Using
    End Sub

    Friend Sub SPECIALHolidayLists(LV As ListView)

        LV.Items.Clear()
        Dim sql As String = "select * from PAYROLL_HOLIDAY where KINDS = 'SPECIAL' "
        Using ds As DataSet = LoadSQL(sql, "PAYROLL_HOLIDAY")
            If ds.Tables(0).Rows.Count > 0 Then
                For Each dr In ds.Tables(0).Rows
                    With dr
                        Dim i As ListViewItem = LV.Items.Add(.Item("DATEE"))
                        i.SubItems.Add(.Item("NAME"))
                    End With
                Next

            End If
        End Using

        'Dim sql As String = "select DATEE, NAME from PAYROLL_HOLIDAY where KINDS = 'SPECIAL' "

        'Using rdr As FbDataReader = LoadSQL_byDataReader(sql)
        '    LV.Items.Clear()

        '    While rdr.Read()
        '        If rdr.HasRows Then
        '            With rdr
        '                Dim i As ListViewItem = LV.Items.Add(.Item("DATEE"))
        '                i.SubItems.Add(.Item("NAME"))
        '            End With
        '        End If
        '    End While
        'End Using
    End Sub

    Friend Sub AttendanceDetails(biometric As String, paydate As String, NoOfDays_TXT As TextBox, RegularOT_TXT As TextBox,
                             SpecialHol_TXT As TextBox, RegularHol_TXT As TextBox, Late_TXT As TextBox,
                             UnderTime_TXT As TextBox, TrainingDays_LBL As Label, NightTime_TXT As TextBox)

        Dim mysql As String = $"Select * From PAYROLL_ATTENDANCE WHERE BIOMETRICID = '{biometric}' and paydate = '{paydate}'"
        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_ATTENDANCE")
            If ds.Tables(0).Rows.Count > 0 Then

                Dim dr As DataRow = ds.Tables(0).Rows(0)
                With dr
                    NoOfDays_TXT.Text = .Item("PRESENT_DAYS")
                    RegularOT_TXT.Text = IIf(.Item("OVERTIME") = 0, "", .Item("OVERTIME") & ":00")
                    RegularOT_TXT.Tag = .Item("OVERTIME")
                    SpecialHol_TXT.Text = .Item("SPECHOLIDAY")
                    RegularHol_TXT.Text = .Item("REGHOLIDAY")
                    Late_TXT.Text = IIf(.Item("LATE") = "00:00:00", "", .Item("LATE").Substring(0, 5))
                    Late_TXT.Tag = .Item("LATE")
                    UnderTime_TXT.Text = IIf(.Item("UNDERTIME") = "00:00:00", "", .Item("UNDERTIME").Substring(0, 5))
                    UnderTime_TXT.Tag = .Item("UNDERTIME")
                    NightTime_TXT.Text = IIf(IsDBNull(.Item("NIGHT_RATE")), "", .Item("NIGHT_RATE") & ":00")
                    NightTime_TXT.Tag = IIf(IsDBNull(.Item("NIGHT_RATE")), 0, .Item("NIGHT_RATE"))
                    TrainingDays_LBL.Text = IIf(IsDBNull(.Item("TRAINING_DAYS")), 0, .Item("TRAINING_DAYS"))
                End With
            End If
        End Using
    End Sub

    Friend Sub Recorded_Details(BIO_NO As String, datagrid As DataGridView, paydate As String, transac_name As String)

        datagrid.Rows.Clear()
        Dim mysql_ As String = $"select * from RECORDED_ALLOW_DEDUC  where BIO_NO = '{BIO_NO}' and PAYDATE = '{paydate}' and TRANSAC_NAME = '{transac_name}'"
        Using ds As DataSet = LoadSQL(mysql_, "RECORDED_ALLOW_DEDUC")

            If ds.Tables(0).Rows.Count > 0 Then
                For Each dr In ds.Tables(0).Rows
                    With dr

                        Dim toLower, toProper As String

                        toLower = .item("CATEGORY").ToLower()
                        Dim info As TextInfo = CultureInfo.InvariantCulture.TextInfo
                        toProper = info.ToTitleCase(toLower)

                        Dim amountt As Double = .item("AMOUNT")

                        Dim rowId As Integer = datagrid.Rows.Add()
                        Dim row As DataGridViewRow = datagrid.Rows(rowId)

                        row.Cells(0).Value = toProper
                        row.Cells(0).Tag = amountt.ToString(”N”)
                        row.Cells(1).Value = amountt.ToString(”N”)


                        If .item("CATEGORY") = "SBU" Then
                            row.Cells(0).Value = "SBU"
                        End If

                        If .item("CATEGORY") = "SIL" Then
                            row.Cells(0).Value = "SIL"
                        End If

                        If datagrid.Name = "Deduction_grid" Then
                            row.Cells(3).Value = "OFF"
                        End If

                    End With

                Next
            End If

            AdjustHeightOfGridBasedOnRows(datagrid, 25)
        End Using
    End Sub

    Friend Sub AllowanceDetails(BIO_NO As String, datagrid As DataGridView, sched As String)

        datagrid.Rows.Clear()
        Dim mysql_1 As String = $"select * from payroll_allowances  where BIOMETRIC_NO = '{BIO_NO}' and ALLOWED = 'YES' and (SCHEDULE = '{sched}' or SCHEDULE = 'EVERY PAYROLL')"
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

            End If

            AdjustHeightOfGridBasedOnRows(datagrid, 25)
        End Using
    End Sub

    Friend Sub DeductioneDetails_ORIG(BIO_NO As String, datagrid As DataGridView, sched As String)

        datagrid.Rows.Clear()

        Dim mysql_1 As String = $"Select * From PAYROLL_DEDUCTIONS WHERE BIONO = '{BIO_NO}' and STATUS is null and (SCHEDULE = '{sched}' or SCHEDULE = 'EVERY PAYROLL')"
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

            ' ================ SBU DEDUCTION  ================  

            Dim sbu As Double = SBU_Amount(BIO_NO)

            Dim rowIdd As Integer = datagrid.Rows.Add()
            Dim roww As DataGridViewRow = datagrid.Rows(rowIdd)

            roww.Cells(0).Value = "SBU"
            roww.Cells(0).Tag = sbu.ToString(”N”)
            roww.Cells(1).Value = sbu.ToString(”N”)
            roww.Cells(3).Value = "OFF"

            AdjustHeightOfGridBasedOnRows(datagrid, 25)
        End Using
    End Sub

    Friend Sub DeductioneDetails_MODIFIED(BIO_NO As String, PAYDATE As String, datagrid As DataGridView, sched As String)

        datagrid.Rows.Clear()
        Dim mysql_1 As String = $"Select * From MODIFIED_DEDUCTION A inner join PAYROLL_DEDUCTIONS B on (A.m_deduc_id = B.id or A.m_deduc_id is null ) 
                                            and STATUS is null and (SCHEDULE = '{sched}' or SCHEDULE = 'EVERY PAYROLL')
                                            WHERE A.BIO_NO = '{BIO_NO}' and PAYDATE = '{PAYDATE}'"

        Using ds As DataSet = LoadSQL(mysql_1, "MODIFIED_DEDUCTION")

            If ds.Tables(0).Rows.Count > 0 Then

                For Each dr In ds.Tables(0).Rows

                    With dr
                        Dim toLower, toProper As String

                        Dim amountt_modif As Double = .item("M_AMOUNT")
                        Dim amountt_orig As Double = .item("AMOUNT_PER_GIVE")

                        If .item("M_CATEGORY") <> "SBU" Then
                            toLower = .item("M_CATEGORY").ToLower()
                            Dim info As TextInfo = CultureInfo.InvariantCulture.TextInfo
                            toProper = info.ToTitleCase(toLower)
                        Else
                            toProper = .item("M_CATEGORY")
                        End If

                        Dim rowId As Integer = datagrid.Rows.Add()
                        Dim row As DataGridViewRow = datagrid.Rows(rowId)

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
            AdjustHeightOfGridBasedOnRows(datagrid, 25)
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

    Public Function GetFirst_Basic(BIO_NO As String, paydate As String) As Double
        Dim first_Basic As Double

        Dim paydate_ As DateTime = Convert.ToDateTime(paydate)
        paydate_ = paydate_.ToString("d")

        Dim first_payroll = New DateTime(paydate_.Year, paydate_.Month, 15)

        'Dim first_payroll = New DateTime(paydate_.Year, paydate_.Month, 1)
        'first_payroll = first_payroll.AddDays(14)

        Dim sql As String = $"Select * FROM PAYROLL_PAYOUT where BIOMETRIC_ID = '{BIO_NO}' and PAYDATE = '{first_payroll.ToString("d")}'"
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

    Public Function GetFirst_NoOfDays(bio_no As String, paydate As String) As Double
        Dim first_NoOfDays As Double

        Dim paydate_ As DateTime = Convert.ToDateTime(paydate)
        paydate_ = paydate_.ToString("d")

        Dim first_payroll = New DateTime(paydate_.Year, paydate_.Month, 1)
        first_payroll = first_payroll.AddDays(14)

        Dim sql As String = $"Select * FROM PAYROLL_ATTENDANCE where BIOMETRICID = '{bio_no}' and PAYDATE = '{first_payroll.ToString("d")}'"
        Using ds As DataSet = LoadSQL(sql, "PAYROLL_ATTENDANCE")

            If ds.Tables(0).Rows.Count > 0 Then
                For Each dr In ds.Tables(0).Rows
                    With dr
                        first_NoOfDays = .Item("PRESENT_DAYS") + .Item("REGHOLIDAY") + .Item("SPECHOLIDAY") + .Item("SIL")
                    End With
                Next
            Else
                first_NoOfDays = 0
            End If

        End Using

        Return first_NoOfDays
    End Function

    Public Function GetMonthly_Basic(BIOMETRIC_ID As String, paydate As String) As Double
        Dim first_basic As Double = GetFirst_Basic(BIOMETRIC_ID, paydate)
        Dim second_basic As Double = 0
        Dim monthly_Basic As Double = 0
        Dim sqll As String = $"Select * FROM PAYROLL_PAYOUT where BIOMETRIC_ID = '{BIOMETRIC_ID}' and PAYDATE = '{paydate}'"
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

    Public Function Get_SSS(monthly_Basic As String) As (EE As Double, ER As Double, EC As Double, total As Double)

        Console.WriteLine("monthly_Basic" & monthly_Basic)
        Dim ee As Double = 0
        Dim er As Double = 0
        Dim ec As Double = 0
        Dim total As Double = 0

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
                            ee = .Item("total_ee")
                            er = .Item("total_er")
                            ec = .Item("EC_TOTAL")
                            total = .Item("TOTAL_TOTAL")
                        End If

                    End With
                Next
            End If
        End Using

        Return (ee, er, ec, total)
    End Function

    Public Function Get_LOAN_SSS(bio_no As String) As Double
        Dim sssLoan As Double = 0

        Dim mysql As String = $"Select * From PAYROLL_SSSLOAN WHERE bio_no = '{bio_no}' and STATUS is null"
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

    Public Function Get_LOAN_Pagibig(bio_no As String) As Double
        Dim pagibigLoan As Double = 0

        Dim mysql As String = $"Select * From PAYROLL_PAGIBIGLOAN WHERE bio_no = '{bio_no}' and STATUS is null"
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
        Dim sss As Double = Get_SSS(monthly_Basic).EE
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
                            regularRate.Text = FormatPercent(.Item("RATE"), 0)
                        Else
                            SpecialRate.Text = FormatPercent(.Item("RATE"), 0)
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

            mysql = $"Select * From PAYROLL_ATTENDANCE A inner join PAYROLL_EMPLOYEE B on B.BIO_NO = A.BIOMETRICID 
                                 where A.PAYDATE = '{Paydate}' and (BRANCH_CODE <> '711-POL' or BRANCH_CODE <> '711-ROX') and ("

            For Each name In strWords
                mysql &= $"{vbCr}UPPER(BIOMETRICID) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(FULLNAME) LIKE UPPER('%{name}%')) ORDER BY FULLNAME ASC "
            Next

        Else
            mysql = $"Select * From PAYROLL_ATTENDANCE A inner join PAYROLL_EMPLOYEE B on B.BIO_NO = A.BIOMETRICID where A.PAYDATE = '{Paydate}' 
                                   and (BRANCH_CODE <> '711-POL' or BRANCH_CODE <> '711-ROX') ORDER BY FULLNAME ASC "
        End If


        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_ATTENDANCE")
            If ds.Tables(0).Rows.Count > 0 Then

                progressBarStart(ds.Tables(0).Rows.Count)

                For Each dr In ds.Tables(0).Rows
                    AddRowBiometric(dr, datagrid)

                    frmMainForm.AppProgressBar.Value += 1
                Next

                progressBarEnd()
            Else
                datagrid.Rows.Clear()
            End If
        End Using

    End Sub

    Public Sub AddRowBiometric(ByVal dr As DataRow, datagrid As DataGridView)
        'If datagrid.Rows.Count <= 12 Then
        With dr

            Dim rowId As Integer = datagrid.Rows.Add()
            Dim row As DataGridViewRow = datagrid.Rows(rowId)
            row.Cells("BIOID_DGVV").Value = .Item("BIOMETRICID")
            row.Cells("Name_DGVV").Value = .Item("FULLNAME")
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
        'End If
    End Sub

    Friend Sub Populate_S7ELVEN(datagrid As DataGridView, Paydate As String, Optional searchName As String = "")

        datagrid.Rows.Clear()

        Dim secured_str As String = searchName
        secured_str = DreadKnight(secured_str)
        Dim strWords As String() = secured_str.Split(New Char() {" "c})
        Dim name As String
        Dim mysql As String

        If searchName.Length <> 0 Then

            mysql = $"Select * From PAYROLL_ATTENDANCE A inner join PAYROLL_EMPLOYEE B on B.BIO_NO = A.BIOMETRICID 
                                 where A.PAYDATE = '{Paydate}' and BRANCH_CODE IN ('711-POL','711-ROX') and ("

            For Each name In strWords
                mysql &= $"{vbCr}UPPER(BIOMETRICID) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(FULLNAME) LIKE UPPER('%{name}%')) ORDER BY FULLNAME ASC "
            Next

        Else
            mysql = $"Select * From PAYROLL_ATTENDANCE A inner join PAYROLL_EMPLOYEE B on B.BIO_NO = A.BIOMETRICID where A.PAYDATE = '{Paydate}' 
                                   and BRANCH_CODE IN ('711-POL','711-ROX') ORDER BY FULLNAME ASC "
        End If


        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_ATTENDANCE")
            If ds.Tables(0).Rows.Count > 0 Then

                For Each dr In ds.Tables(0).Rows

                    With dr

                        Dim rowId As Integer = datagrid.Rows.Add()
                        Dim row As DataGridViewRow = datagrid.Rows(rowId)
                        row.Cells(0).Value = .Item("BIOMETRICID")
                        row.Cells(1).Value = .Item("FULLNAME")
                        row.Cells(1).Tag = .Item("ID")
                        row.Cells(2).Value = .Item("PRESENT_DAYS")

                        If .Item("OVERTIME") = 0 Then
                            row.Cells(3).Value = ""
                        Else
                            row.Cells(3).Value = .Item("OVERTIME")
                        End If

                        If .Item("LATE").Equals("00:00:00") Then
                            row.Cells(4).Value = ""
                        Else
                            row.Cells(4).Value = IIf(IsDBNull(.Item("LATE")), "", .Item("LATE"))
                        End If

                        If .Item("UNDERTIME").Equals("00:00:00") Then
                            row.Cells(5).Value = ""
                        Else
                            row.Cells(5).Value = IIf(IsDBNull(.Item("UNDERTIME")), "", .Item("UNDERTIME"))
                        End If

                        row.Cells(6).Value = IIf(IsDBNull(.Item("NIGHT_RATE")) Or .Item("NIGHT_RATE").Equals("0"), "", .Item("NIGHT_RATE"))

                        row.Height = 30

                    End With

                Next
            Else
                datagrid.Rows.Clear()
            End If
        End Using

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

    Public Sub PopulateComboBox_Any(combo As ComboBox, table As String, column As String)
        Dim sql As String = $"select distinct({column}) from {table}"
        Dim rdr As FbDataReader = LoadSQL_byDataReader(sql)
        combo.Items.Clear()
        While rdr.Read()
            If rdr.HasRows Then
                With rdr


                    If combo.Name = "Rem_Paydate_Combo" Then '====== REMITTANCE =============
                        If IsLastDay(rdr.Item(0).ToString) Then
                            Dim datee As DateTime = rdr.Item(0).ToString
                            combo.Items.Add(datee.ToString("d"))
                        End If
                    Else
                        combo.Items.Add(rdr.Item(0).ToString)
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

    Public Sub Payout_Details(bioNo As String, name As TextBox, ratee As TextBox, Optional MonthlyRate_TXT As TextBox = Nothing)

        Dim mysql As String = "Select * From PAYROLL_EMPLOYEE WHERE BIO_NO = '" & bioNo & "'"
        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_EMPLOYEE")

            If ds.Tables(0).Rows.Count > 0 Then

                Dim data As DataRow = ds.Tables(0).Rows(0)
                With data

                    Dim rate As Double = IIf(IsDBNull(.Item("RATE_DAILY")), 0, .Item("RATE_DAILY"))
                    Dim minimum As Double = IIf(.Item("BRANCH_CODE") = Nothing, GetMinimumRate("CITY", "GENSAN"), GetMinimumRate("BRANCHCODE", .Item("BRANCH_CODE")))

                    ratee.Text = IIf(rate = 0, minimum, rate)
                    ratee.Tag = .Item("BRANCH_CODE")
                    name.Text = .Item("FULLNAME")

                    If MonthlyRate_TXT IsNot Nothing Then
                        MonthlyRate_TXT.Text = IIf(IsDBNull(.Item("RATE_MONTHLY")), 0, .Item("RATE_MONTHLY"))
                    End If
                End With

            Else
                name.Text = ""
            End If
        End Using
    End Sub

    Public Sub Clock_IN_Details(bioNo As String, name As TextBox, ClockEmp_IN_CB As ComboBox, ClockEmp_OUT_CB As ComboBox)

        Dim mysql As String = "Select * From PAYROLL_EMPLOYEE WHERE BIO_NO = '" & bioNo & "'"
        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_EMPLOYEE")
            If ds.Tables(0).Rows.Count > 0 Then

                Dim data As DataRow = ds.Tables(0).Rows(0)
                With data
                    name.Text = .Item("FULLNAME")
                    ClockEmp_IN_CB.Text = IIf(IsDBNull(.Item("TIME_IN")), "", .Item("TIME_IN").ToShortTimeString)
                    ClockEmp_OUT_CB.Text = IIf(IsDBNull(.Item("TIME_OUT")), "", .Item("TIME_OUT").ToShortTimeString)
                End With

            Else
                name.Text = ""
                ClockEmp_IN_CB.Text = ""
                ClockEmp_OUT_CB.Text = ""
            End If
        End Using
    End Sub

    Public Function Holiday_Rate(holiday As String) As Double
        Dim rate As Double = 0
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

    Public Function SBU_Amount(bio_no As String) As Double
        Dim Amount As Integer = 0
        Dim mysql As String = $"Select * From PAYROLL_SBU WHERE BIO_NO = '{bio_no}' and CATEGORY = 'SBU' and (BALANCE IS NULL or BALANCE <> 0)"
        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_SBU")
            If ds.Tables(0).Rows.Count > 0 Then
                Dim data As DataRow = ds.Tables(0).Rows(0)
                With data
                    Amount = .Item("AMOUNT")
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

    Public Function Match_Employee(BIO_NO As String)
        Dim mysql As String = $"Select * FROM PAYROLL_EMPLOYEE where BIO_NO = '{BIO_NO}' "
        Dim ds As DataSet = LoadSQL(mysql, "PAYROLL_EMPLOYEE")
        If ds.Tables(0).Rows.Count > 0 Then
            Return True
        End If
        Return False
    End Function

    Public Sub GetName(BiometricID_TXT As String, name As TextBox)

        Dim mysql As String = "Select * From PAYROLL_EMPLOYEE WHERE BIO_NO= '" & BiometricID_TXT & "'"
        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_EMPLOYEE")
            If ds.Tables(0).Rows.Count > 0 Then
                Dim data As DataRow = ds.Tables(0).Rows(0)
                With data

                    name.Text = .Item("FULLNAME")
                    name.Tag = .Item("ID")

                End With
            Else
                name.Text = ""
            End If
        End Using
    End Sub

    Public Sub Get_SIL(BiometricID_TXT As String, SIL As Label)

        Dim mysql As String = $"Select * From PAYROLL_ATTENDANCE WHERE BIOMETRICID = '{BiometricID_TXT}'"
        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_ATTENDANCE")
            If ds.Tables(0).Rows.Count > 0 Then
                Dim data As DataRow = ds.Tables(0).Rows(0)
                With data
                    SIL.Text = IIf(IsDBNull(.Item("SIL")), 0, .Item("SIL"))
                End With
            Else
                SIL.Text = 0
            End If
        End Using
    End Sub

    'Public Sub Get_Branch_ID(BranchName As String, combo As ComboBox)
    '    Dim mysql As String = "Select * FROM tbl_Branch where BRANCHNAME = '" & BranchName & "'"
    '    Using ds As DataSet = LoadSQL(mysql)
    '        If ds.Tables(0).Rows.Count > 0 Then
    '            Dim dr As DataRow = ds.Tables(0).Rows(0)
    '            With dr
    '                combo.Tag = .Item("ID")
    '            End With
    '        End If
    '    End Using
    'End Sub

    Friend Sub Lists_Allowance(LV As ListView, Optional searchName As String = "")

        Dim secured_str As String = searchName
        secured_str = DreadKnight(secured_str)
        Dim strWords As String() = secured_str.Split(New Char() {" "c})
        Dim name As String
        Dim mysql As String

        If searchName.Length <> 0 Then

            mysql = "select A.*, A.id as allow_id, B.* from PAYROLL_ALLOWANCES A inner join PAYROLL_EMPLOYEE B on B.BIO_NO = A.BIOMETRIC_NO where ALLOWED = 'YES' and ("

            For Each name In strWords
                mysql &= $"{vbCr}UPPER(BIOMETRIC_NO) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(FULLNAME) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(COMPANY) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(BRANCH_CODE) LIKE UPPER('%{name}%')) ORDER BY FULLNAME ASC "
            Next

        Else
            mysql = "select A.*, A.id as allow_id, B.* from PAYROLL_ALLOWANCES A inner join PAYROLL_EMPLOYEE B on B.BIO_NO = A.BIOMETRIC_NO ORDER BY FULLNAME ASC "
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

            Dim effectivity As DateTime = .Item("EFFECTIVE_DATE")
            Dim i As ListViewItem = LV.Items.Add(.Item("FULLNAME"))
            i.SubItems.Add(.Item("CATEGORY")).Tag = .Item("allow_id")
            i.SubItems.Add(sched)
            i.SubItems.Add(effectivity.ToString("MMM dd, yyyy"))
            i.SubItems.Add(.Item("AMOUNT"))
            i.SubItems.Add(.Item("ALLOWED"))
        End With
    End Sub

    Friend Sub Lists_deduction(LV As ListView, Optional searchName As String = "")

        Dim secured_str As String = searchName
        secured_str = DreadKnight(secured_str)
        Dim strWords As String() = secured_str.Split(New Char() {" "c})
        Dim name As String
        Dim mysql As String

        If searchName.Length <> 0 Then

            mysql = "select A.*, A.id as deduc_id, B.* from PAYROLL_DEDUCTIONS A inner join PAYROLL_EMPLOYEE B on B.BIO_NO = A.BIONO WHERE "

            For Each name In strWords
                mysql &= $"{vbCr}UPPER(BIONO) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(FULLNAME) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(COMPANY) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(STATUS) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(BRANCH_CODE) LIKE UPPER('%{name}%')"
            Next

        Else
            mysql = "select A.*, A.id as deduc_id, B.* from PAYROLL_DEDUCTIONS A inner join PAYROLL_EMPLOYEE B on B.BIO_NO = A.BIONO "
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
            Dim i As ListViewItem = LV.Items.Add(.Item("FULLNAME"))
            i.SubItems.Add(.Item("CATEGORY")).Tag = .Item("BIONO")
            i.SubItems.Add(.Item("TOTAL_AMOUNT")).Tag = .Item("deduc_id")
            i.SubItems.Add(.Item("NO_OF_GIVES")).Tag = .Item("EFFECTIVE_DATE")
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

    Public Function GetDeduction_OverAll_Balance(BIO_NO As String) As String

        Dim total_amount = GetDeduction_TotalAmount(BIO_NO)
        Dim balance As Double

        If isExist_String("HISTORY_DEDUCTION", $"WHERE BIO_NO = '{BIO_NO}'") Then
            Dim mysql_ As String = $"Select SUM(H_AMOUNT) as tots From HISTORY_DEDUCTION A inner join PAYROLL_DEDUCTIONS B on B.BIONO = A.BIO_NO where B.BIONO = '{BIO_NO}' and B.STATUS is null"
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


    Public Function GetDeduction_TotalAmount(BIO_NO As String) As Double

        Dim total_amount As Double = 0
        Dim mysql As String = $"Select SUM(TOTAL_AMOUNT) as totals From PAYROLL_DEDUCTIONS where BIONO = '{BIO_NO}' AND STATUS is null"
        Dim ds As DataSet = LoadSQL(mysql, "PAYROLL_DEDUCTIONS")
        If ds.Tables(0).Rows.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            With dr
                total_amount = .Item("totals")
            End With
        End If

        Return total_amount
    End Function

    Public Function GetDeduction_OPEN(BIO_NO As String) As Double '=================== OPEN PAYROLL ======================

        Dim amount_per_deduc As Double = 0
        Dim mysql As String = $"Select SUM(AMOUNT_PER_GIVE) as totals From PAYROLL_DEDUCTIONS where BIONO = '{BIO_NO}' AND STATUS is null and SCHEDULE = 'OPEN PAYROLL'"
        Dim ds As DataSet = LoadSQL(mysql, "PAYROLL_DEDUCTIONS")
        If ds.Tables(0).Rows.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            With dr
                amount_per_deduc = IIf(IsDBNull(.Item("totals")), 0, .Item("totals"))
            End With
        End If

        Return amount_per_deduc
    End Function


    Public Function GetDeduction_CLOSE(BIO_NO As String) As Double '=================== CLOSE PAYROLL ======================

        Dim amount_per_deduc As Double = 0
        Dim mysql As String = $"Select SUM(AMOUNT_PER_GIVE) as totals From PAYROLL_DEDUCTIONS where BIONO = '{BIO_NO}' AND STATUS is null and SCHEDULE = 'CLOSE PAYROLL'"
        Dim ds As DataSet = LoadSQL(mysql, "PAYROLL_DEDUCTIONS")
        If ds.Tables(0).Rows.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            With dr
                amount_per_deduc = IIf(IsDBNull(.Item("totals")), 0, .Item("totals"))
            End With
        End If

        Return amount_per_deduc
    End Function


    Public Function GetDeduction_EVERY(BIO_NO As String) As Double '=================== EVERY PAYROLL ======================

        Dim amount_per_deduc As Double = 0
        Dim mysql As String = $"Select SUM(AMOUNT_PER_GIVE) as totals From PAYROLL_DEDUCTIONS where BIONO = '{BIO_NO}' AND STATUS is null and SCHEDULE = 'EVERY PAYROLL'"
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
                    With dr
                        Dim i As ListViewItem = listview.Items.Add(.Item("BRANCH_CODE"))
                        i.SubItems.Add(.Item("FULLNAME"))
                        i.SubItems.Add(.Item("BIO_NO"))
                        i.SubItems.Add(IIf(IsDBNull(.Item("RATE_DAILY")), "", .Item("RATE_DAILY")))
                    End With
                    frmMainForm.AppProgressBar.Value += 1
                Next
            End If
        End Using

        progressBarEnd()
    End Sub


    Friend Sub Lists_City_Branch(listview As ListView, Optional searchName As String = "")

        Dim secured_str As String = searchName
        secured_str = DreadKnight(secured_str)
        Dim strWords As String() = secured_str.Split(New Char() {" "c})
        Dim name As String
        Dim mysql As String

        If searchName.Length <> 0 Then

            mysql = $"Select * From PAYROLL_CITY_BRANCH where "

            For Each name In strWords
                mysql &= $"{vbCr}UPPER(BRANCHCODE) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(BRANCHNAME) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(CITY) LIKE UPPER('%{name}%') ORDER BY CITY, BRANCHNAME , BRANCHCODE ASC "
            Next

        Else
            mysql = $"Select * From PAYROLL_CITY_BRANCH ORDER BY CITY, BRANCHNAME, BRANCHCODE ASC "
        End If

        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_CITY_BRANCH")
            If ds.Tables(0).Rows.Count > 0 Then

                listview.Items.Clear()
                progressBarStart(ds.Tables(0).Rows.Count)

                For Each dr In ds.Tables(0).Rows
                    With dr
                        Dim i As ListViewItem = listview.Items.Add(IIf(IsDBNull(.Item("CITY")), "", .Item("CITY")))
                        i.SubItems.Add(IIf(IsDBNull(.Item("BRANCHNAME")), "", .Item("BRANCHNAME")))
                        i.SubItems.Add(IIf(IsDBNull(.Item("BRANCHCODE")), "", .Item("BRANCHCODE")))
                        i.SubItems.Add(IIf(IsDBNull(.Item("ADDRESS")), "", .Item("ADDRESS")))
                        i.SubItems.Add(IIf(IsDBNull(.Item("CATEGORY")), "", .Item("CATEGORY")))
                    End With
                    frmMainForm.AppProgressBar.Value += 1
                Next
            End If
        End Using

        progressBarEnd()
    End Sub


    Friend Sub Lists_SBU(LV As ListView, Optional searchName As String = "")

        Dim secured_str As String = searchName
        secured_str = DreadKnight(secured_str)
        Dim strWords As String() = secured_str.Split(New Char() {" "c})
        Dim name As String
        Dim mysql As String

        If searchName.Length <> 0 Then

            mysql = "select * from PAYROLL_EMPLOYEE A inner join PAYROLL_SBU B on B.BIO_NO = A.BIO_NO WHERE "

            For Each name In strWords
                mysql &= $"{vbCr}UPPER(B.BIO_NO) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(FULLNAME) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(COMPANY) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(BRANCH_CODE) LIKE UPPER('%{name}%') ORDER BY FULLNAME ASC "
            Next

        Else
            mysql = "select * from PAYROLL_EMPLOYEE A inner join PAYROLL_SBU B on B.BIO_NO = A.BIO_NO ORDER BY FULLNAME ASC "
        End If

        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_EMPLOYEE")
            LV.Items.Clear()
            progressBarStart(ds.Tables(0).Rows.Count)
            For Each dr In ds.Tables(0).Rows
                With dr

                    Dim Last_update As DateTime = IIf(IsDBNull(.Item("LAST_SBU")), Nothing, .Item("LAST_SBU"))

                    Dim i As ListViewItem = LV.Items.Add(.Item("FULLNAME"))
                    i.SubItems.Add(.Item("CATEGORY"))
                    i.SubItems.Add(.Item("AMOUNT"))
                    i.SubItems.Add(IIf(IsDBNull(.Item("PRINCIPAL")), "", .Item("PRINCIPAL")))
                    i.SubItems.Add(IIf(IsDBNull(.Item("CREDIT")), "", .Item("CREDIT")))
                    i.SubItems.Add(IIf(IsDBNull(.Item("BALANCE")), "", .Item("BALANCE")))
                    i.SubItems.Add(IIf(Last_update = Nothing, "", Last_update.ToString("MMM dd, yyyy")))

                End With
                frmMainForm.AppProgressBar.Value += 1
            Next
            progressBarEnd()
        End Using

    End Sub

    Friend Sub Lists_Payout(LV As ListView, paydate As String, Optional searchName As String = "")

        Dim secured_str As String = searchName
        secured_str = DreadKnight(secured_str)
        Dim strWords As String() = secured_str.Split(New Char() {" "c})
        Dim name As String
        Dim mysql As String

        If searchName.Length <> 0 Then

            mysql = $"Select * From PAYROLL_PAYOUT A 
                                        inner join PAYROLL_EMPLOYEE B on B.BIO_NO = A.BIOMETRIC_ID 
                                        where paydate = '{paydate}' and ( "

            For Each name In strWords
                mysql &= $"{vbCr}UPPER(BIOMETRIC_ID) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(FULLNAME) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(BRANCH_CODE) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(COMPANY) LIKE UPPER('%{name}%')) ORDER BY FULLNAME"
            Next

        Else
            mysql = $"Select * From PAYROLL_PAYOUT A inner join PAYROLL_EMPLOYEE B on B.BIO_NO = A.BIOMETRIC_ID where paydate ='{paydate}'  ORDER BY FULLNAME"
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

    Private Sub AddRow_PAYOUT(ByVal dr As DataRow, listview As ListView)

        With dr
            Dim i As ListViewItem = listview.Items.Add(.Item("FULLNAME"))
            'i.SubItems.Add(.Item("TOTAL_BASIC")).Tag = .Item("BIOMETRIC_ID")
            'i.SubItems.Add(.Item("TOTAL_OVERTIME")).Tag = .Item("BRANCH_ID")
            'i.SubItems.Add(.Item("TOTAL_LATE_UT"))
            i.SubItems.Add(CDbl(.Item("GROSS_AMOUNT")).ToString("N")).Tag = .Item("BIOMETRIC_ID")
            i.SubItems.Add(CDbl(.Item("SSS_COMP")).ToString("N"))
            i.SubItems.Add(CDbl(.Item("PAGIBIG_COMP")).ToString("N"))
            i.SubItems.Add(CDbl(.Item("PHILHEALTH_COMP")).ToString("N"))
            'i.SubItems.Add(CDbl(.Item("TAXABLE")).ToString("N"))
            i.SubItems.Add(CDbl(.Item("TAX_WHELD")).ToString("N"))
            i.SubItems.Add(CDbl(.Item("NET_TAX_COMP")).ToString("N"))
            i.SubItems.Add(CDbl(.Item("SSS_LOAN")).ToString("N"))
            i.SubItems.Add(CDbl(.Item("PAGIBIG_LOAN")).ToString("N"))
            i.SubItems.Add(CDbl(.Item("TOTAL_ALLOWANCE")).ToString("N"))
            i.SubItems.Add(CDbl(.Item("TOTAL_DEDUCTION")).ToString("N"))
            i.SubItems.Add(CDbl(.Item("NET_PAY")).ToString("N"))

        End With

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
                        row.Cells("fourteen").Value = .Item("total_ee")
                        row.Cells("fifteen").Value = .Item("total_er")
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

            mysql = "select * from PAYROLL_EMPLOYEE where EMP_STATUS = 'ACTIVE' and ("

            For Each name In strWords
                mysql &= $"{vbCr}UPPER(COMPANY) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(BRANCH_CODE) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(FULLNAME) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(BIO_NO) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(EMP_STATUS) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(EMP_POSITION) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(SSSNO) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(PHILHEALTHNO) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(TINNO) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(PAGIBIGNO) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(HO_CATEGORY) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(COMMON_CATEGORY) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(EMAIL_ADD) LIKE UPPER('%{name}%')) ORDER BY COMPANY, BRANCH_CODE ASC "
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

            Dim datee As DateTime

            If Not IsDBNull(.Item("DATE_STARTED")) Then
                datee = CDate(.Item("DATE_STARTED"))
            Else
                datee = Nothing
            End If

            Dim i As ListViewItem = LV.Items.Add(.Item("COMPANY"))
            i.Tag = .Item("ID")
            i.SubItems.Add(.Item("BRANCH_CODE"))
            i.SubItems.Add(.Item("FULLNAME"))
            i.SubItems.Add(.Item("BIO_NO"))
            i.SubItems.Add(IIf(IsDBNull(.Item("EMP_NO")), "", .Item("EMP_NO")))
            i.SubItems.Add(IIf(IsDBNull(.Item("EMAIL_ADD")), "", .Item("EMAIL_ADD")))
            i.SubItems.Add(IIf(datee = Nothing, "", datee.ToString("MMM dd, yyyy")))
            i.SubItems.Add(IIf(IsDBNull(.Item("EMP_POSITION")), "", .Item("EMP_POSITION")))
            i.SubItems.Add(IIf(IsDBNull(.Item("TINNO")), "", .Item("TINNO")))
            i.SubItems.Add(IIf(IsDBNull(.Item("SSSNO")), "", .Item("SSSNO")))
            i.SubItems.Add(IIf(IsDBNull(.Item("PHILHEALTHNO")), "", .Item("PHILHEALTHNO")))
            i.SubItems.Add(IIf(IsDBNull(.Item("PAGIBIGNO")), "", .Item("PAGIBIGNO")))

        End With
    End Sub

    Public Sub GetFullname(bio_no As String, Add_Company_CB As ComboBox, Branch_ComboB As ComboBox, Fullname_TXT As TextBox,
                           Email_TXT As TextBox, InActive_RB As RadioButton, Started_DTP As DateTimePicker,
                           TimeIn_Combo As ComboBox, TimeOut_Combo As ComboBox, EmoNo_TXT As TextBox, TIN_TXT As TextBox,
                           SSS_TXT As TextBox, PHILH_TXT As TextBox, HDMF_TXT As TextBox, HO_Category As ComboBox,
                           ComCategory_Combo As ComboBox, Position_Combo As ComboBox, ComCompany_Cmbo As ComboBox,
                           Optional btnSave As Button = Nothing)

        Dim mysql As String = $"select * from PAYROLL_EMPLOYEE where BIO_NO = '{bio_no}'"
        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_EMPLOYEE")
            If ds.Tables(0).Rows.Count > 0 Then
                Dim dr As DataRow = ds.Tables(0).Rows(0)
                With dr
                    Dim TIME_IN, TIME_OUT As DateTime
                    TIME_IN = IIf(IsDBNull(.Item("TIME_IN")), Nothing, .Item("TIME_IN"))
                    TIME_OUT = IIf(IsDBNull(.Item("TIME_OUT")), Nothing, .Item("TIME_OUT"))

                    Add_Company_CB.Text = .Item("COMPANY")
                    HO_Category.Text = IIf(IsDBNull(.Item("HO_CATEGORY")), Nothing, .Item("HO_CATEGORY"))
                    ComCategory_Combo.Text = IIf(IsDBNull(.Item("COMMON_CATEGORY")), Nothing, .Item("COMMON_CATEGORY"))
                    ComCompany_Cmbo.Text = IIf(IsDBNull(.Item("COMMON_COMPANY")), Nothing, .Item("COMMON_COMPANY"))
                    Branch_ComboB.Text = .Item("BRANCH_CODE")
                    Fullname_TXT.Text = .Item("FULLNAME")
                    Email_TXT.Text = IIf(IsDBNull(.Item("EMAIL_ADD")), "", .Item("EMAIL_ADD"))
                    Position_Combo.Text = IIf(IsDBNull(.Item("EMP_POSITION")), "", .Item("EMP_POSITION"))
                    Started_DTP.Text = IIf(IsDBNull(.Item("DATE_STARTED")), "", .Item("DATE_STARTED"))
                    TimeIn_Combo.Text = IIf(TIME_IN = Nothing, "", TIME_IN.ToShortTimeString())
                    TimeOut_Combo.Text = IIf(TIME_OUT = Nothing, "", TIME_OUT.ToShortTimeString())
                    EmoNo_TXT.Text = IIf(IsDBNull(.Item("EMP_NO")), "", .Item("EMP_NO"))
                    TIN_TXT.Text = IIf(IsDBNull(.Item("TINNO")), "", .Item("TINNO"))
                    SSS_TXT.Text = IIf(IsDBNull(.Item("SSSNO")), "", .Item("SSSNO"))
                    PHILH_TXT.Text = IIf(IsDBNull(.Item("PHILHEALTHNO")), "", .Item("PHILHEALTHNO"))
                    HDMF_TXT.Text = IIf(IsDBNull(.Item("PAGIBIGNO")), "", .Item("PAGIBIGNO"))

                    If .Item("EMP_STATUS") = "INACTIVE" Then
                        InActive_RB.Checked = True
                    End If

                    btnSave.Tag = "UPDATE" ' FOR USER_LOGS
                End With
            Else
                Add_Company_CB.Text = ""
                HO_Category.Text = ""
                ComCategory_Combo.Text = ""
                Branch_ComboB.Text = ""
                Started_DTP.Value = "1/1/2000"
                Fullname_TXT.Text = ""
                Email_TXT.Text = ""
                Position_Combo.Text = ""
                TimeIn_Combo.Text = ""
                TimeOut_Combo.Text = ""
                EmoNo_TXT.Text = ""
                TIN_TXT.Text = ""
                SSS_TXT.Text = ""
                PHILH_TXT.Text = ""
                HDMF_TXT.Text = ""
                btnSave.Tag = "SAVE" ' FOR USER_LOGS
            End If
        End Using
    End Sub


    Public Function Halfday_Training(BIO_NO As String, PAYDATE As String, datee As String)

        Dim count As Double = 0
        Dim status As String = ""

        Dim mysql As String = $"select * from BIOMETRIC_DTR where BIO_ID = '{BIO_NO}' AND PAYDATE = '{PAYDATE}' and DATE_ONLY = '{datee}'"
        Using ds As DataSet = LoadSQL(mysql, "BIOMETRIC_DTR")
            If ds.Tables(0).Rows.Count > 0 Then
                Dim dr As DataRow = ds.Tables(0).Rows(0)
                With dr

                    '===================== COUNT HALFDAY ==========================
                    Dim IN_OUT() As String = {"AM_IN", "AM_OUT", "PM_IN", "PM_OUT"}

                    For column As Integer = 0 To 3

                        If IsDBNull(.Item(IN_OUT(column))) Or .Item(IN_OUT(column)) Is String.Empty Then
                            count += 1
                        End If
                    Next


                    If (IsDBNull(.Item("AM_IN")) Or .Item("AM_IN") Is String.Empty) And (IsDBNull(.Item("AM_OUT")) Or .Item("AM_OUT") Is String.Empty) Then
                        status = "HALFDAY"
                    ElseIf (IsDBNull(.Item("PM_IN")) Or .Item("PM_IN") Is String.Empty) And (IsDBNull(.Item("PM_OUT")) Or .Item("PM_OUT") Is String.Empty) Then
                        status = "HALFDAY"
                    End If

                    If count = 3 Or status = "HALFDAY" Then
                        Return True
                    End If

                End With
            End If
        End Using

        Return False
    End Function

    Public Function PRESENT_Date(BIO_NO As String, PAYDATE As String, datee As String)
        Dim mysql As String = $"Select DATE_ONLY From BIOMETRIC_DTR where BIO_ID = '{BIO_NO}' AND PAYDATE = '{PAYDATE}' and DATE_ONLY = '{datee}'"
        Using dss As DataSet = LoadSQL(mysql, "BIOMETRIC_DTR")
            If dss.Tables(0).Rows.Count > 0 Then
                Dim data As DataRow = dss.Tables(0).Rows(0)
                With data
                    Return True
                End With
            End If
        End Using

        Return False
    End Function


    Friend Sub Lists_TimeInOut(listview As ListView, Optional searchName As String = "")

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
                    With dr

                        Dim TIME_IN, TIME_OUT As DateTime

                        Dim i As ListViewItem = listview.Items.Add(.Item("BRANCH_CODE"))
                        i.SubItems.Add(.Item("FULLNAME"))

                        If Not IsDBNull(.Item("TIME_IN")) Then
                            TIME_IN = .Item("TIME_IN")
                            i.SubItems.Add(TIME_IN.ToShortTimeString)
                        End If

                        If Not IsDBNull(.Item("TIME_OUT")) Then
                            TIME_OUT = .Item("TIME_OUT")
                            i.SubItems.Add(TIME_OUT.ToShortTimeString)
                        End If

                    End With

                    frmMainForm.AppProgressBar.Value += 1
                Next
            End If
        End Using

        progressBarEnd()
    End Sub

    Public Function GetTimeInOut(BIO_NO As String) As (Time_in As DateTime, Time_out As DateTime)
        Dim inn As DateTime = "9/15/2021 8:00:00 AM"
        Dim outt As DateTime = "9/15/2021 5:00:00 PM"

        Dim mysql As String = $"Select TIME_IN, TIME_OUT FROM  PAYROLL_EMPLOYEE WHERE BIO_NO = '{BIO_NO}'"
        Dim ds As DataSet = LoadSQL(mysql, "PAYROLL_EMPLOYEE")
        If ds.Tables(0).Rows.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            With dr

                If IsDBNull(.Item("TIME_IN")) Then
                    inn = "9/15/2021 8:00:00 AM"
                Else
                    inn = .Item("TIME_IN")
                End If

                If IsDBNull(.Item("TIME_OUT")) Then
                    outt = "9/15/2021 5:00:00 PM"
                Else
                    outt = .Item("TIME_OUT")
                End If
            End With
        End If

        Return (inn, outt)
    End Function

    Public Function GetTime_In(BIO_NO As String)
        Dim inn As DateTime = "9/15/2021 8:00:00 AM"

        Dim mysql As String = $"Select TIME_IN FROM  PAYROLL_EMPLOYEE WHERE BIO_NO = '{BIO_NO}'"
        Dim ds As DataSet = LoadSQL(mysql, "PAYROLL_EMPLOYEE")
        If ds.Tables(0).Rows.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            With dr
                inn = IIf(IsDBNull(.Item("TIME_IN")), "9/15/2021 8:00:00 AM", .Item("TIME_IN"))
            End With
        End If
        Return inn
    End Function

    Public Function GetTime_Out(BIO_NO As String)
        Dim outt As DateTime = "9/15/2021 5:00:00 PM"

        Dim mysql As String = $"Select TIME_OUT FROM  PAYROLL_EMPLOYEE WHERE BIO_NO = '{BIO_NO}'"
        Dim ds As DataSet = LoadSQL(mysql, "PAYROLL_EMPLOYEE")
        If ds.Tables(0).Rows.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            With dr
                outt = IIf(IsDBNull(.Item("TIME_OUT")), "9/15/2021 5:00:00 PM", .Item("TIME_OUT"))
            End With
        End If
        Return outt
    End Function

    Public Function GetBranchCode(BIO_NO As String)
        Dim BRANCH_CODE As String = ""

        Dim mysql As String = $"Select BRANCH_CODE FROM  PAYROLL_EMPLOYEE WHERE BIO_NO = '{BIO_NO}'"
        Dim ds As DataSet = LoadSQL(mysql, "PAYROLL_EMPLOYEE")
        If ds.Tables(0).Rows.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            With dr
                BRANCH_CODE = .Item("BRANCH_CODE")
            End With
        End If
        Return BRANCH_CODE
    End Function

    Public Function SBU_notFull(BIO_NO As String)
        Dim mysql As String = $"Select DATE_STARTED, A.COMPANY, FULLNAME, B.* From PAYROLL_EMPLOYEE A inner join PAYROLL_SBU B ON A.BIO_NO = B.BIO_NO where A.BIO_NO = '{BIO_NO}' AND CATEGORY = 'SBU'"
        Using dss As DataSet = LoadSQL(mysql, "PAYROLL_EMPLOYEE")
            If dss.Tables(0).Rows.Count > 0 Then
                For Each dr In dss.Tables(0).Rows
                    With dr

                        Dim training_days As Integer = 0
                        Dim Started As DateTime = IIf(IsDBNull(.Item("DATE_STARTED")), "1/1/1000", .Item("DATE_STARTED"))
                        Dim sbu_bal As Double = .Item("BALANCE")

                        '=============== TRAINING DAYS ================
                        If .Item("COMPANY") = "DALTON" Or .Item("COMPANY") = "PHOTO" Or .Item("COMPANY") = "HEAD OFFICE" Then
                            training_days = 15
                        Else
                            training_days = 30
                        End If

                        '=============== CALCULATE SBU ================  
                        If Started = "1/1/1000" Then
                            MsgBox($"There's no date of started recorded for { .item("FULLNAME")}", MsgBoxStyle.Critical, "INVALID")
                        Else
                            Dim count_days = New DateTime(Started.Year, Started.Month, Started.Day)
                            count_days = count_days.AddDays(training_days)

                            If Today >= count_days Then

                                If sbu_bal > 0 Then
                                    Return True
                                End If

                            End If
                        End If
                    End With
                Next
            End If
        End Using

        Return False
    End Function

    Public Function CountYear_SIL(Bio_no As String, endingDate As DateTime) As Integer

        Dim cnt As Integer = 0
        Dim mysql As String = $"Select DATE_STARTED From PAYROLL_EMPLOYEE where BIO_NO = '{Bio_no}'"
        Using dss As DataSet = LoadSQL(mysql, "PAYROLL_EMPLOYEE")
            If dss.Tables(0).Rows.Count > 0 Then
                Dim dr As DataRow = dss.Tables(0).Rows(0)
                With dr
                    Dim date_started As DateTime = IIf(IsDBNull(.Item("DATE_STARTED")), Today, .Item("DATE_STARTED"))
                    cnt = DateDiff(DateInterval.Month, date_started, endingDate)
                End With
            End If
        End Using

        Return cnt
    End Function

    Public Function Count_SIL(Bio_no As String) As Integer

        Dim cnt As Integer = 0
        Dim mysql As String = $"Select SUM(SIL) as tots From PAYROLL_ATTENDANCE where BIOMETRICID = '{Bio_no}' AND EXTRACT (YEAR FROM PAYDATE) = '{Date.Now.Year}'"
        Using dss As DataSet = LoadSQL(mysql, "PAYROLL_ATTENDANCE")
            If dss.Tables(0).Rows.Count > 0 Then
                For Each dr In dss.Tables(0).Rows
                    With dr
                        cnt += .Item("tots")
                    End With
                Next
            End If
        End Using

        Return cnt
    End Function

    Public Function GetCount_Common(whereString As String) As Integer
        Dim countt As Integer = 0
        Dim mysql As String = $"Select Count(*) as Countt From PAYROLL_EMPLOYEE {whereString}"
        Dim ds As DataSet = LoadSQL(mysql, "PAYROLL_EMPLOYEE")
        If ds.Tables(0).Rows.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            With dr
                countt = .Item("Countt")
            End With
        End If
        Return countt
    End Function

    Public Function GetDistinctCount(column As String, whereString As String) As Integer
        Dim countt As Integer = 0
        Dim mysql As String = $"Select Count(distinct {column}) as Countt From PAYROLL_EMPLOYEE {whereString}"
        Dim ds As DataSet = LoadSQL(mysql, "PAYROLL_EMPLOYEE")
        If ds.Tables(0).Rows.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            With dr
                countt = .Item("Countt")
            End With
        End If
        Return countt
    End Function

    Public Function GetModify_Reports(column As String) As Double
        Dim value As Integer = 0
        Dim mysql As String = $"Select * From PAYROLL_MARKETING_DYU"
        Dim ds As DataSet = LoadSQL(mysql, "PAYROLL_MARKETING_DYU")
        If ds.Tables(0).Rows.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            With dr
                value = IIf(IsDBNull(.Item(column)), Nothing, .Item(column))
            End With
        End If
        Return value
    End Function

    Public Sub GetModify_Report(M_DaltonP_TXT As TextBox, M_Photo_TXT As TextBox, M_DavaoP_TXT As TextBox, M_Perfecom_TXT As TextBox,
                                D_DaltonP_TXT As TextBox, D_Photo_TXT As TextBox, D_DavaoP_TXT As TextBox, D_Perfecom_TXT As TextBox,
                                L_Dalton As TextBox, L_PG711 As TextBox,
                                DR_Dalton_TXT As TextBox, DR_Photo_TXT As TextBox, DR_House_TXT As TextBox, ConDalton_TXT As TextBox,
                                ConPhoto_TXT As TextBox, ConHouse_TXT As TextBox, LeasingBR_TXT As TextBox, DTR_Dalton As TextBox,
                                DTR_Photo As TextBox, LeasingP_TXT As TextBox)

        Dim mysql As String = "Select * FROM  PAYROLL_MARKETING_DYU"
        Dim ds As DataSet = LoadSQL(mysql, "PAYROLL_MARKETING_DYU")
        If ds.Tables(0).Rows.Count > 0 Then
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            With dr

                M_DaltonP_TXT.Text = IIf(IsDBNull(.Item("M_DALTONP")), Nothing, .Item("M_DALTONP"))
                M_Photo_TXT.Text = IIf(IsDBNull(.Item("M_PHOTO")), Nothing, .Item("M_PHOTO"))
                M_DavaoP_TXT.Text = IIf(IsDBNull(.Item("M_DAVAOP")), Nothing, .Item("M_DAVAOP"))
                M_Perfecom_TXT.Text = IIf(IsDBNull(.Item("M_PERFECOM")), Nothing, .Item("M_PERFECOM"))
                D_DaltonP_TXT.Text = IIf(IsDBNull(.Item("D_DALTONP")), Nothing, .Item("D_DALTONP"))
                D_Photo_TXT.Text = IIf(IsDBNull(.Item("D_PHOTO")), Nothing, .Item("D_PHOTO"))
                D_DavaoP_TXT.Text = IIf(IsDBNull(.Item("D_DAVAOP")), Nothing, .Item("D_DAVAOP"))
                D_Perfecom_TXT.Text = IIf(IsDBNull(.Item("D_PERFECOM")), Nothing, .Item("D_PERFECOM"))
                L_Dalton.Text = IIf(IsDBNull(.Item("L_DALTON")), Nothing, .Item("L_DALTON"))
                L_PG711.Text = IIf(IsDBNull(.Item("L_PG711")), Nothing, .Item("L_PG711"))
                DR_Dalton_TXT.Text = IIf(IsDBNull(.Item("DR_DALTON")), Nothing, .Item("DR_DALTON"))
                DR_Photo_TXT.Text = IIf(IsDBNull(.Item("DR_PHOTO")), Nothing, .Item("DR_PHOTO"))
                DR_House_TXT.Text = IIf(IsDBNull(.Item("DR_HOUSE")), Nothing, .Item("DR_HOUSE"))
                ConDalton_TXT.Text = IIf(IsDBNull(.Item("CONDALTON")), Nothing, .Item("CONDALTON"))
                ConPhoto_TXT.Text = IIf(IsDBNull(.Item("CONPHOTO")), Nothing, .Item("CONPHOTO"))
                ConHouse_TXT.Text = IIf(IsDBNull(.Item("CONHOUSE")), Nothing, .Item("CONHOUSE"))
                LeasingBR_TXT.Text = IIf(IsDBNull(.Item("LEASINGBR")), Nothing, .Item("LEASINGBR"))
                DTR_Dalton.Text = IIf(IsDBNull(.Item("DTR_Dalton")), Nothing, .Item("DTR_Dalton"))
                DTR_Photo.Text = IIf(IsDBNull(.Item("DTR_Photo")), Nothing, .Item("DTR_Photo"))
                LeasingP_TXT.Text = IIf(IsDBNull(.Item("LEASINGP")), Nothing, .Item("LEASINGP"))

            End With
        End If
    End Sub

    Friend Sub UserLogs_Record(lv As ListView)
        Dim mysql As String = $"Select * from PAYROLL_LOGS ORDER BY DATEE DESC"
        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_LOGS")
            For Each dr In ds.Tables(0).Rows
                With dr
                    Dim datee As DateTime = .Item("DATEE")
                    Dim list As ListViewItem = lv.Items.Add(datee.ToString("MMM dd, yyyy hh:mm tt"))
                    list.SubItems.Add(.Item("USER"))
                    list.SubItems.Add(.Item("TRANSACTIONN"))
                End With
            Next
        End Using
    End Sub

    Public Sub Replacing(str As String)
        RunCommand($"DELETE FROM {str}")  'THIS IS TO DELETE EXISTING DATA TO REPLACE ESPECIALLY FROM DATAGRID
    End Sub

    Public Function ListOfDate(EXIST_DATE As HashSet(Of String), BIO_NO As String, paydatee As String) As HashSet(Of String)

        Dim mysql As String = $"Select * From BIOMETRIC_DTR where BIO_ID = '{BIO_NO}' and PAYDATE = '{paydatee}' ORDER BY DATE_ONLY"
        Using ds As DataSet = LoadSQL(mysql, "BIOMETRIC_DTR")
            If ds.Tables(0).Rows.Count > 0 Then
                For Each dr In ds.Tables(0).Rows
                    With dr
                        EXIST_DATE.Add(.Item("DATE_ONLY"))
                    End With
                Next
            End If
        End Using

        Return EXIST_DATE
    End Function

    Public Function ListOfBio(LIST_BIOO As List(Of String), mysql As String) As List(Of String)
        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_ATTENDANCE")
            If ds.Tables(0).Rows.Count > 0 Then
                For Each dr In ds.Tables(0).Rows
                    With dr
                        LIST_BIOO.Add(.Item("BIOMETRICID"))
                    End With
                Next
            End If
        End Using

        Return LIST_BIOO
    End Function

    Friend Function GetData(column As String, str As String)
        Dim dataa As String = ""
        Dim mysql As String = $"Select {column} from {str}"
        Using ds As DataSet = LoadSQL(mysql)
            If ds.Tables(0).Rows.Count > 0 Then
                With ds.Tables(0).Rows(0)
                    dataa = IIf(IsDBNull(.Item(column)), "", .Item(column))
                End With
            End If
        End Using
        Return dataa
    End Function

    Public Function GetSummary_Email(PAYDATE As String, str As String)
        Dim TOTALS As String = 0
        Dim mysql_ As String = $"Select COALESCE(sum(NET_PAY), 0) as tots From PAYROLL_PAYOUT A 
                                    INNER JOIN PAYROLL_EMPLOYEE B ON B.BIO_NO = A.BIOMETRIC_ID
                                    LEFT JOIN PAYROLL_CITY_BRANCH ON BRANCHCODE = BRANCH_CODE  
                                    where  PAYDATE = '{PAYDATE}' AND {str}"

        Dim dSs As DataSet = LoadSQL(mysql_, "PAYROLL_PAYOUT")
        If dSs.Tables(0).Rows.Count > 0 Then
            Dim dr As DataRow = dSs.Tables(0).Rows(0)
            With dr
                TOTALS = .Item("tots")
            End With
        End If

        Return TOTALS
    End Function

End Module
