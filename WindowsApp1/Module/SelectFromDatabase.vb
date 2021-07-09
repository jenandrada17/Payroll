Imports FirebirdSql.Data.FirebirdClient

Module SelectFromDatabase

    Public Function ThisHasRow(table As String)
        Dim mysql As String = "Select * FROM " & table & ""
        Dim ds As DataSet = LoadSQL(mysql, table)
        If ds.Tables(0).Rows.Count > 0 Then
            Return True
        End If
        Return False
    End Function


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
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            With dr
                NoOfDays_TXT.Text = .Item("PRESENT_DAYS")
                RegularOT_TXT.Text = .Item("OVERTIME")
                SpecialHol_TXT.Text = .Item("SPECHOLIDAY")
                RegularHol_TXT.Text = .Item("REGHOLIDAY")
                Late_TXT.Text = .Item("LATE")
                UnderTime_TXT.Text = .Item("UNDERTIME")
            End With

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
                AdjustHeightOfGridBasedOnRows(datagrid)
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
                        combo.Items.Remove(paydate)
                    ElseIf combo.Name = "RE_Paydate_Combo" Then
                        Dim datee As DateTime = rdr.Item(0).ToString
                        combo.Items.Add(datee.ToString("d"))
                        combo.Items.Remove(paydate)
                    Else
                        combo.Items.Add(rdr.Item(0).ToString)
                    End If

                End With
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
                AdjustHeightOfGridBasedOnRows(datagrid)
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

    Public Sub BiometricNo_Payout(bioNo As String, name As TextBox)

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

    Public Function Bio_Exist_Attendance(bioNo As String, paydate As String)
        Dim mysql As String = $"Select * FROM PAYROLL_ATTENDANCE where BIOMETRICID = '{bioNo}' and PAYDATE = '{paydate}'"
        Dim ds As DataSet = LoadSQL(mysql, "PAYROLL_ATTENDANCE")
        If ds.Tables(0).Rows.Count > 0 Then
            Return True
            Console.WriteLine("TRUE")
        End If
        Return False
    End Function

End Module
