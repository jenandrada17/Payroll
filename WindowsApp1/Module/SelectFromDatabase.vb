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


    Friend Sub AttendanceDetails(biometric As String, NoOfDays_TXT As TextBox, RegularOT_TXT As TextBox,
                             SpecialHol_TXT As TextBox, RegularHol_TXT As TextBox, Late_TXT As TextBox,
                             UnderTime_TXT As TextBox)


        Dim mysql As String = "Select * From PAYROLL_ATTENDANCE WHERE BIOMETRICID = '" & biometric & "'"
        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_ATTENDANCE")

            Dim dr As DataRow = ds.Tables(0).Rows(0)
            If dr.Table.Rows.Count > 0 Then

                With dr

                    If .Item("TOTALDAYSHOUR") = 0 Then
                        NoOfDays_TXT.Text = .Item("TOTALDAYS")
                        NoOfDays_TXT.Tag = .Item("TOTALDAYS")
                    Else
                        NoOfDays_TXT.Text = .Item("TOTALDAYS") & " and a Half Day"
                        NoOfDays_TXT.Tag = (.Item("TOTALDAYS") + 0.5).ToString
                        Console.WriteLine("Thiss " & NoOfDays_TXT.Tag)
                    End If

                    RegularOT_TXT.Text = .Item("TOTALOVERTIME")
                    SpecialHol_TXT.Text = .Item("TOTALSPECHOLIDAY")
                    RegularHol_TXT.Text = .Item("TOTALREGHOLIDAY")
                    Late_TXT.Text = .Item("TOTALLATE")
                    UnderTime_TXT.Text = .Item("TOTALUNDERTIME")
                End With
            Else
                Exit Sub
            End If

        End Using

        'mysql = "Select * From payroll_allow_deduc WHERE EMP_ID = '" & namee.Tag & "'"
        'Using ds As DataSet = LoadSQL(mysql, "payroll_allow_deduc")

        '    If ds.Tables(0).Rows.Count > 0 Then
        '        Dim data As DataRow = ds.Tables(0).Rows(0)
        '        With data

        '            If .Item("FIX_RATE") = "YES" Then
        '                yess.Checked = True
        '            Else
        '                yess.Checked = False
        '            End If

        '            ratee.Text = .Item("DAILY_SALARY")
        '            boarding.Text = .Item("BOARDING_ALLOWANCE")
        '            carekit.Text = .Item("CAREKIT_ALLOWANCE")
        '            positional.Text = .Item("POSITIONAL_ALLOWANCE")
        '            Transport.Text = .Item("TRANSPO_ALLOWANCE")
        '            Medical.Text = .Item("MEDICAL_ALLOWANCE")
        '            OtherAllowance.Text = .Item("OTHER_ALLOWANCE")

        '            CashAdvance.Text = .Item("CASH_ADVANCE")
        '            Savings.Text = .Item("SAVINGS_DEDUCTION")
        '            Loan.Text = .Item("LOANS_DEDUCTION")
        '            Charges.Text = .Item("CHARGES_DEDUCTION")
        '            Meal.Text = .Item("MEAL_DEDUCTION")
        '            OtherDeduction.Text = .Item("OTHER_DEDUCTION")

        '        End With
        '    End If

        'End Using
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
        Dim mysql As String = $"Select distinct(BIO_ID), B.ID, B.LASTNAME, B.FIRSTNAME, B.MIDDLENAME From IMPORT_DTR A inner join TBL_EMPLOYEE B on B.BIOMETRICID = A.BIO_ID where A.PAYDATE = '{Paydate}' and A.BRANCH = '{BRANCHNAME}'"

        Using ds As DataSet = LoadSQL(mysql, "IMPORT_DTR")
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
            row.Cells("BIOID_DGVV").Value = .Item("BIO_ID")
            row.Cells("Name_DGVV").Value = .Item("LASTNAME") & ", " & .Item("FIRSTNAME") & " " & .Item("MIDDLENAME")
            row.Cells("Name_DGVV").Tag = .Item("ID")
            row.Height = 35


            Dim mysql As String = $"Select * From IMPORT_DTR where BIO_ID = '{ .Item("BIO_ID")}'"
            Using ds As DataSet = LoadSQL(mysql, "IMPORT_DTR")
                If ds.Tables(0).Rows.Count > 0 Then

                    Dim list_dateHour, list_dateonly As New List(Of String)()

                    For Each dr In ds.Tables(0).Rows
                        With dr
                            Dim datt As DateTime = .Item("DATEANDTIME")
                            datt.ToShortTimeString()
                            Dim str As String = .Item("PAYDATE") & " " & .Item("BIO_ID") & " " & datt

                            If str.Length <> 0 Then
                                str = str.Substring(0, str.Length - 9)
                                list_dateHour.Add(str)
                            End If
                        End With
                    Next

                    Dim result As List(Of String) = list_dateHour.Distinct().ToList  ' Date with hour


                    For Each value As String In result                      'Trim to convert to Date Only 
                        Dim pos As Integer = value.LastIndexOf(" ")
                        If pos <> -1 Then
                            value = value.Substring(0, pos)
                            list_dateonly.Add(value)
                        End If
                    Next


                    For Each value As String In result                      ' Check if Standard DTR

                        Dim pos As Integer = value.LastIndexOf(" ")
                        If pos <> -1 Then
                            value = value.Substring(0, pos)
                        End If

                        Console.WriteLine("Final " & value)

                        'If CountDate(list_dateonly, value) = 4 Then
                        '    row.DefaultCellStyle.ForeColor = Color.Black
                        'Else
                        '    row.DefaultCellStyle.ForeColor = Color.Red
                        'End If

                    Next

                End If
            End Using

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
                    Else
                        combo.Items.Add(rdr.Item(0).ToString)
                    End If

                End With
            End If
        End While
    End Sub

    Public Function CountCELL_Nothing(row As DataGridViewRow) As Integer

        Dim count As New Integer
        For cell As Integer = 1 To 4
            If Not row.DefaultCellStyle.ForeColor = Color.Red And row.Cells(5).Value = True And row.Cells(cell).Value = Nothing Then
                count += 1
            End If
        Next

        Console.WriteLine("Count " & count)
        Return count
    End Function

    'Friend Sub Select_IMPORT_TABLE()

    '    Dim mysql As String = "Select * From IMPORT_DTR GROUP BY BIO_ID"
    '    Using ds As DataSet = LoadSQL(mysql, "IMPORT_DTR")

    '        If ds.Tables(0).Rows.Count > 0 Then
    '            For Each dr In ds.Tables(0).Rows
    '                With dr
    '                    Console.WriteLine("Group by bio_id " & .Item("BIO_ID"))
    '                End With
    '            Next
    '        End If

    '    End Using

    'End Sub


End Module
