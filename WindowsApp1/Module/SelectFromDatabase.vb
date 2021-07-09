Imports FirebirdSql.Data.FirebirdClient

Module SelectFromDatabase

    Dim rowCount As Integer

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

                mysql = "select * from tbl_Employee A inner join tbl_branch B on B.ID = A.BRANCH_ID Where "

                For Each name In strWords
                    mysql &= $"{vbCr}UPPER(BIOMETRICID) LIKE UPPER('%{name}%') OR "
                    mysql &= $"{vbCr}UPPER(firstname) LIKE UPPER('%{name}%') OR "
                    mysql &= $"{vbCr}UPPER(lastname) LIKE UPPER('%{name}%') OR "
                    mysql &= $"{vbCr}UPPER(branchname) LIKE UPPER('%{name}%') OR "
                    mysql &= $"{vbCr}UPPER(A.STATUS) LIKE UPPER('%{name}%') OR "
                    mysql &= $"{vbCr}UPPER(COMPANYNAME) LIKE UPPER('%{name}%')"
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

    Friend Sub PopulateBiometricSHEET(datagrid As DataGridView, Paydate As String, BRANCHNAME As String)

        datagrid.Rows.Clear()
        Dim mysql As String = $"Select * From PAYROLL_ATTENDANCE A inner join TBL_EMPLOYEE B on B.BIOMETRICID = A.BIOMETRICID where A.PAYDATE = '{Paydate}' and A.BRANCH = '{BRANCHNAME}'"

        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_ATTENDANCE")
            If ds.Tables(0).Rows.Count > 0 Then
                For Each dr In ds.Tables(0).Rows
                    AddRowBiometric(dr, datagrid)
                Next
                'AdjustHeightOfGridBasedOnRows(datagrid)
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

    Public Sub PopulateComboBox(combo As ComboBox, table As String, column As String, Optional paydate As String = "")
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


    'Public Sub Payout_ALL(bioNo As String, name As TextBox, ratee As TextBox, paydate As String)

    '    Dim mysql As String = "Select * From payroll_attendance WHERE PAYDATE= '" & paydate & "'"
    '    Using ds As DataSet = LoadSQL(mysql, "payroll_attendance")

    '        If ds.Tables(0).Rows.Count > 0 Then
    '            For Each dr In ds.Tables(0).Rows
    '                With dr 
    '                    Dim MI As String

    '                    If String.IsNullOrEmpty(.Item("MIDDLENAME")) Then
    '                        MI = ""
    '                    Else
    '                        MI = .Item("MIDDLENAME").Substring(0, 1) & "."
    '                    End If

    '                    ratee.Text = IIf(IsDBNull(.Item("RATE")), 0, .Item("RATE"))
    '                    ratee.Tag = .Item("BRANCH_ID")
    '                    name.Text = .Item("FIRSTNAME") & " " & MI & " " & .Item("LASTNAME") & " " & .Item("SUFFIX")
    '                    name.Tag = .Item("ID")
    '                End With
    '            Next
    '        Else
    '            Exit Sub
    '        End If
    '    End Using
    'End Sub


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
            For Each dr In ds.Tables(0).Rows
                AddRow_Allowance(dr, LV)
            Next
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
            For Each dr In ds.Tables(0).Rows
                AddRow_Deduction(dr, LV)
            Next
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

                rowCount = ds.Tables(0).Rows.Count
                Dim maxEntries As Integer = ds.Tables(0).Rows.Count
                frmMainForm.AppProgressBar.Maximum = maxEntries
                frmMainForm.AppProgressBar.Visible = True

                listview.Items.Clear()
                For Each dr In ds.Tables(0).Rows
                    AddRow_RATE(dr, listview)
                    frmMainForm.AppProgressBar.Value += 1
                Next
            End If
        End Using

        frmMainForm.AppProgressBar.Value = 0
        frmMainForm.AppProgressBar.Maximum = 1000
        frmMainForm.AppProgressBar.Visible = False
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
            i.SubItems.Add(.Item("TOTAL_BASIC")).Tag = .Item("BIOMETRIC_ID")
            i.SubItems.Add(.Item("TOTAL_OVERTIME")).Tag = .Item("BRANCH_ID")
            i.SubItems.Add(.Item("TOTAL_LATE_UT"))
            i.SubItems.Add(.Item("GROSS_AMOUNT"))
            i.SubItems.Add(.Item("SSS_COMP"))
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

            mysql = $"Select * From PAYROLL_PAYOUT A inner join tbl_employee B on B.BIOMETRICID = A.BIOMETRIC_ID  inner join tbl_branch C on C.ID = B.BRANCH_ID  where paydate =' {paydate}' and "

            For Each name In strWords
                mysql &= $"{vbCr}UPPER(BIOMETRIC_ID) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(firstname) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(lastname) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(EMP_POSITION) LIKE UPPER('%{name}%') OR "
                mysql &= $"{vbCr}UPPER(rate) LIKE UPPER('%{name}%') "
            Next

        Else
            mysql = $"Select * From PAYROLL_PAYOUT A inner join tbl_employee B on B.BIOMETRICID = A.BIOMETRIC_ID  inner join tbl_branch C on C.ID = B.BRANCH_ID  where paydate =' {paydate}'"
        End If

        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_PAYOUT")
            LV.Items.Clear()
            For Each dr In ds.Tables(0).Rows
                AddRow_PAYOUT(dr, LV)
            Next
        End Using

    End Sub


End Module
