Imports System.IO
Imports FirebirdSql.Data.FirebirdClient
Imports Microsoft.Office.Interop

Public Class frmAttendance

    Dim DateNow As DateTime = DateTime.Now
    Dim startingDate, EndingDate As DateTime
    Dim DateNowADDMonth As DateTime = DateTime.Now.AddMonths(1)
    Dim StartFour, EndFour, StartNineteen, EndNineteen, Paydate As DateTime
    Dim newNo As Integer
    Dim eApp As New Excel.Application
    Dim eBook As Excel.Workbook = Nothing
    Dim eSheet As Excel.Worksheet = Nothing
    Dim eCell As Excel.Range
    Dim late_count, under_count, over_count As New List(Of TimeSpan)()
    Dim list_dateHour, list_inOut, list_hourMin, list_Group, list_count, list_bio, distinct_bio As New List(Of String)()
    Dim hourMinn, timee, bio_list As List(Of String)
    Dim dateee As DateTime
    Dim DATE_ONLY, am_in, am_out, pm_in, pm_out As String
    'Dim list_hour(3) As String

    Private Sub frmAttendance_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LoadDateTime()
        DataGridView1.ClearSelection()
        CheckALL_CheckBox.Checked = True
        PopulateComboBox(Branch_ComboB, "tbl_branch", "BRANCHNAME")
        PopulateComboBox(Paydate_ComboB, "IMPORT_DTR", "PAYDATE", Paydate)
        Paydate_ComboB.Items.Insert(0, "Current")

    End Sub

    Private Sub Close_LBL_Click(sender As Object, e As EventArgs) Handles Close_LBL.Click
        Close()
    End Sub

    Private Sub LoadDateTime()

        TotalAbsent_LBL.Text = 0
        TotalDays_LBL.Text = 0
        TotalLateHR_LBL.Text = 0
        TotalUTHR_LBL.Text = 0
        TotalOTHr_LBL.Text = 0
        TotalRHoliday_LBL.Text = 0
        TotalSHoliday_LBL.Text = 0
        DataGridView1.Rows.Clear()

        Dim rowIndex As Integer

        StartFour = New DateTime(DateNow.Year, DateNow.Month, 4).AddDays(-1)
        EndFour = New DateTime(DateNow.Year, DateNow.Month, 18)

        StartNineteen = New DateTime(DateNow.Year, DateNow.Month, 19).AddMonths(-1).AddDays(-1)
        EndNineteen = New DateTime(StartNineteen.Year, StartNineteen.Month, 3).AddMonths(1)


        If DateNow.Day - 16 <= 2 And DateNow.Day - 16 >= -12 Then

            Paydate = EndNineteen.AddDays(12)
            DataGridView1.Tag = Paydate

            While (StartNineteen < EndNineteen)
                startingDate = StartNineteen.ToString("d")
                EndingDate = EndNineteen.ToString("d")

                rowIndex = DataGridView1.Rows.Add(StartNineteen.AddDays(1).ToString("D"))
                Console.WriteLine("TAG " & rowIndex)
                DataGridView1.Rows(rowIndex).Tag = StartNineteen.AddDays(1).ToString("D")

                StartNineteen = StartNineteen.AddDays(1)
            End While

        Else

            Paydate = New DateTime(EndFour.Year, EndFour.Month, DateTime.DaysInMonth(EndFour.Year, EndFour.Month))
            DataGridView1.Tag = Paydate

            While (StartFour < EndFour)

                startingDate = StartFour.ToString("d")
                EndingDate = EndFour.ToString("d")

                rowIndex = DataGridView1.Rows.Add(StartFour.AddDays(1).ToString("D"))
                DataGridView1.Rows(rowIndex).Tag = StartFour.AddDays(1).ToString("D")

                StartFour = StartFour.AddDays(1)

            End While


        End If

        Dim ss As DateTime = Date.UtcNow
        Dim CurrD As DateTime = ss.AddDays(-1)

        '==============================================AM IN 6AM to 9AM==================================================
        For y = 0 To 420

            Dim myDate = New DateTime(CurrD.Year, CurrD.Month, CurrD.Day, 5, 0, 0, 0).AddMinutes(y)
            AM_In_DataGrid.Items.Add(myDate.ToString("t"))

        Next


        '==============================================AM OUT 11AM to 1PM==================================================
        For y = 0 To 300

            Dim myDate = New DateTime(CurrD.Year, CurrD.Month, CurrD.Day, 8, 0, 0, 0).AddMinutes(y)
            AM_Out_DataGrid.Items.Add(myDate.ToString("t"))

        Next


        '==============================================PM IN 12AM to 3PM==================================================
        For y = 0 To 360

            Dim myDate = New DateTime(CurrD.Year, CurrD.Month, CurrD.Day, 12, 0, 0, 0).AddMinutes(y)
            PM_IN_DataGrid.Items.Add(myDate.ToString("t"))

        Next


        '==============================================PM OUT 3PM to 3PM==================================================
        For y = 0 To 660

            Dim myDate = New DateTime(CurrD.Year, CurrD.Month, CurrD.Day, 12, 0, 0, 0).AddMinutes(y)
            PM_Out_DataGrid.Items.Add(myDate.ToString("t"))

        Next

        For i = 0 To DataGridView1.Rows.Count - 1
            Dim r As DataGridViewRow = DataGridView1.Rows(i)
            r.Height = 28

            Dim asss As Date = DataGridView1.Rows(i).Cells(0).Value

            Dim customizeDate As String = asss.ToString("M")

            If asss.DayOfWeek = DayOfWeek.Sunday Then

                r.DefaultCellStyle.ForeColor = Color.Red

                DataGridView1.Rows(i).Cells(5) = New DataGridViewTextBoxCell()
                DataGridView1.Rows(i).Cells(1).Value = ""
                DataGridView1.Rows(i).Cells(2).Value = ""
                DataGridView1.Rows(i).Cells(3).Value = ""
                DataGridView1.Rows(i).Cells(4).Value = ""

            ElseIf HolidayExist(customizeDate) Then

                HolidayDetails(customizeDate, i, DataGridView1)

            End If

        Next

    End Sub

    Private Sub HourMinute(from_HR As Integer, To_HR As Integer, combo As DataGridViewComboBoxColumn)

        combo.Items.Clear()

        Dim i As Integer
        Dim ii As Integer

        For i = from_HR To To_HR
            For ii = 0 To 59
                Dim ass As String = Format(i, "00")
                Dim asss As String = Format(ii, "00")
                combo.Items.Add((ass & ":" & asss))
            Next
        Next
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckALL_CheckBox.CheckedChanged

        If CheckALL_CheckBox.Checked = True Then
            For i = 0 To DataGridView1.RowCount - 1
                Dim row As DataGridViewRow = DataGridView1.Rows(i)
                If row.DefaultCellStyle.ForeColor = Color.Red Then
                    DataGridView1.Rows(i).Cells(5) = New DataGridViewTextBoxCell()
                    DataGridView1.Rows(i).Cells(5).ReadOnly = True
                    DataGridView1.Rows(i).Cells(1).Value = ""
                    DataGridView1.Rows(i).Cells(1).ReadOnly = True
                    DataGridView1.Rows(i).Cells(2).Value = ""
                    DataGridView1.Rows(i).Cells(1).ReadOnly = True
                    DataGridView1.Rows(i).Cells(3).Value = ""
                    DataGridView1.Rows(i).Cells(1).ReadOnly = True
                    DataGridView1.Rows(i).Cells(4).Value = ""
                    DataGridView1.Rows(i).Cells(1).ReadOnly = True

                ElseIf row.DefaultCellStyle.BackColor = Color.MediumOrchid Or row.DefaultCellStyle.BackColor = Color.Plum Then
                    DataGridView1.Rows(i).Cells(5).Value = False
                    DataGridView1.Rows(i).Cells(1).Value = ""
                    DataGridView1.Rows(i).Cells(2).Value = ""
                    DataGridView1.Rows(i).Cells(3).Value = ""
                    DataGridView1.Rows(i).Cells(4).Value = ""

                Else
                    DataGridView1.Rows(i).Cells(5).Value = True
                    DataGridView1.Rows(i).Cells(1).Value = "8:00 AM"
                    DataGridView1.Rows(i).Cells(2).Value = "12:00 PM"
                    DataGridView1.Rows(i).Cells(3).Value = "1:00 PM"
                    DataGridView1.Rows(i).Cells(4).Value = "5:00 PM"
                End If
            Next
        Else
            For i = 0 To DataGridView1.RowCount - 1
                DataGridView1.Rows(i).Cells(5).Value = False
                DataGridView1.Rows(i).Cells(1).Value = ""
                DataGridView1.Rows(i).Cells(2).Value = ""
                DataGridView1.Rows(i).Cells(3).Value = ""
                DataGridView1.Rows(i).Cells(4).Value = ""
            Next
        End If
        Calculate_BTN.PerformClick()
    End Sub

    Private Sub DataGridView1_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DataGridView1.CurrentCellDirtyStateChanged

        If TypeOf DataGridView1.CurrentCell Is DataGridViewCheckBoxCell Then
            DataGridView1.EndEdit()
            Dim Checked As Boolean = CType(DataGridView1.CurrentCell.Value, Boolean)

            If Checked Then
                DataGridView1.Rows(DataGridView1.CurrentCell.RowIndex).Cells(1).Value = "8:00 AM"
                DataGridView1.Rows(DataGridView1.CurrentCell.RowIndex).Cells(2).Value = "12:00 PM"
                DataGridView1.Rows(DataGridView1.CurrentCell.RowIndex).Cells(3).Value = "1:00 PM"
                DataGridView1.Rows(DataGridView1.CurrentCell.RowIndex).Cells(4).Value = "5:00 PM"
            Else
                DataGridView1.Rows(DataGridView1.CurrentCell.RowIndex).Cells(1).Value = ""
                DataGridView1.Rows(DataGridView1.CurrentCell.RowIndex).Cells(2).Value = ""
                DataGridView1.Rows(DataGridView1.CurrentCell.RowIndex).Cells(3).Value = ""
                DataGridView1.Rows(DataGridView1.CurrentCell.RowIndex).Cells(4).Value = ""
            End If

        End If
        Calculate_BTN.PerformClick()
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Calculate_BTN.Click

        TotalAbsent_LBL.Text = 0
        TotalDays_LBL.Text = 0
        TotalRHoliday_LBL.Text = 0
        TotalSHoliday_LBL.Text = 0
        TotalLateHR_LBL.Text = 0
        TotalUTHR_LBL.Text = 0
        TotalOTHr_LBL.Text = 0

        For Each row As DataGridViewRow In DataGridView1.Rows

            If Not row.DefaultCellStyle.ForeColor = Color.Red Then

                '========================================================================= CALCULATE HOLIDAYS  ===========================================================
                If row.DefaultCellStyle.BackColor = Color.MediumOrchid Then


                    TotalRHoliday_LBL.Text = TotalRHoliday_LBL.Text + 1

                ElseIf row.DefaultCellStyle.BackColor = Color.Plum Then


                    TotalSHoliday_LBL.Text = TotalSHoliday_LBL.Text + 1

                End If


                CalculateLATE(row)

                CalculateuNDERTIME(row)

                CalculateuOVERTIME(row)

            End If
        Next

        '===================================== SUM UP LATE ==================================== 
        Dim Late_Total As New TimeSpan
        For Each valueE As TimeSpan In late_count
            Late_Total = Late_Total + valueE
        Next

        TotalLateHR_LBL.Text = Late_Total.ToString

        late_count.Clear()

        '===================================== SUM UP UNDERTIME ==================================== 
        Dim Under_Total As New TimeSpan
        For Each value As TimeSpan In under_count
            Under_Total = Under_Total + value
        Next

        TotalUTHR_LBL.Text = Under_Total.ToString

        under_count.Clear()

        '===================================== SUM UP PRESENT AND ABSENT ==================================== 
        Dim Present As Integer = 0
        Dim Absent As Integer = 0
        For Each oRow As DataGridViewRow In DataGridView1.Rows

            If Not oRow.DefaultCellStyle.ForeColor = Color.Red And oRow.Cells(5).Value = True Then
                Present += 1
            ElseIf Not oRow.DefaultCellStyle.ForeColor = Color.Red And oRow.Cells(5).Value = False Then
                If Not oRow.DefaultCellStyle.BackColor = Color.MediumOrchid Or Not oRow.DefaultCellStyle.BackColor = Color.Plum Then
                    Absent += 1
                End If
            End If
        Next

        TotalDays_LBL.Text = Present
        TotalAbsent_LBL.Text = Absent


        '===================================== SUM UP HALF DAY ====================================  
        Dim halfday_Hour As Integer = 0
        For Each oRow As DataGridViewRow In DataGridView1.Rows

            If CountCELL_Nothing(oRow) = 3 Or CountCELL_Consecutive(oRow) = "HALFDAY" Then
                halfday_Hour += 4
            End If
        Next

        If halfday_Hour = 4 Then

            TotalAbsent_LBL.Text = Convert.ToInt32(TotalAbsent_LBL.Text) + 0.5

        ElseIf halfday_Hour > 4 Then

            Dim result As Integer
            result = halfday_Hour / 8

            TotalAbsent_LBL.Text = result + Convert.ToInt32(TotalAbsent_LBL.Text)
        End If

        Dim product As Double
        product = ((Convert.ToInt32(TotalDays_LBL.Text) * 8)) - halfday_Hour
        product = product / 8
        TotalDays_LBL.Text = product

        'If product Mod 8 = 0 Then
        '    product = product / 8
        '    TotalDays_LBL.Text = product
        'Else
        '    product = (product / 8)
        '    TotalDays_LBL.Text = product
        'End If

        ''===================================== SUM UP HALF DAY ====================================  
        'Dim halfday_Hour As Integer = 0
        'For Each oRow As DataGridViewRow In DataGridView1.Rows

        '    If CountCELL_Nothing(oRow) = 3 Or CountCELL_Consecutive(oRow) = "HALFDAY" Then
        '        halfday_Hour += 4
        '    End If
        'Next

        'If halfday_Hour > 4 Then
        '    Dim result As Integer
        '    result = halfday_Hour / 8

        '    If halfday_Hour Mod 8 = 0 Then
        '        TotalAbsent_LBL.Text = result + Convert.ToInt32(TotalAbsent_LBL.Text)
        '    Else
        '        result = Math.Floor(result)
        '        TotalAbsent_LBL.Text = (result + Convert.ToInt32(TotalAbsent_LBL.Text)).ToString & ".5"
        '    End If
        'End If

        'Dim product As Double
        'product = ((Convert.ToInt32(TotalDays_LBL.Text) * 8)) - halfday_Hour

        'If product Mod 8 = 0 Then
        '    product = product / 8
        '    TotalDays_LBL.Text = product
        'Else
        '    product = product / 8
        '    TotalDays_LBL.Text = CInt(Math.Floor(product)).ToString & ".5"
        'End If

    End Sub

    Private Sub CalculateLATE(row As DataGridViewRow)

        '========================================================================= CELL NUMBER AM IN ===========================================================
        If Not row.Cells(1).Value = Nothing Then

            Dim inHour = New DateTime(Now.Year, Now.Month, Now.Day, 8, 0, 0, 0).ToString("t")
            Dim lateHour As TimeSpan = DateTime.Parse(row.Cells(1).Value).Subtract(DateTime.Parse(inHour))

            Dim cellValue As DateTime = row.Cells(1).Value
            Dim limit As DateTime = "7:59 AM"

            If cellValue > limit Then
                late_count.Add(lateHour)
            End If
        End If

        '========================================================================= CELL NUMBER PM IN ===========================================================
        If Not row.Cells(3).Value = Nothing Then

            Dim inHourr = New DateTime(Now.Year, Now.Month, Now.Day, 13, 0, 0, 0).ToString("t")
            Dim lateHourr As TimeSpan = DateTime.Parse(row.Cells(3).Value).Subtract(DateTime.Parse(inHourr))

            Dim cellValue As DateTime = row.Cells(3).Value
            Dim limit As DateTime = "12:59 PM"

            If cellValue > limit Then
                late_count.Add(lateHourr)
            End If
        End If

    End Sub

    Private Sub CalculateuNDERTIME(row As DataGridViewRow)

        '========================================================================= CELL NUMBER AM OUT ===========================================================
        If Not row.Cells(2).Value = Nothing Then

            Dim inHour = New DateTime(Now.Year, Now.Month, Now.Day, 12, 0, 0, 0).ToString("t")
            Dim underHour As TimeSpan = DateTime.Parse(inHour).Subtract(DateTime.Parse(row.Cells(2).Value))

            Dim cellValue As DateTime = row.Cells(2).Value
            Dim limit As DateTime = "12:00 PM"

            If cellValue < limit Then
                under_count.Add(underHour)
            End If

        End If

        '========================================================================= CELL NUMBER PM OUT ===========================================================
        If Not row.Cells(4).Value = Nothing Then

            Dim inHour = New DateTime(Now.Year, Now.Month, Now.Day, 17, 0, 0, 0).ToString("t")
            Dim underHour As TimeSpan = DateTime.Parse(inHour).Subtract(DateTime.Parse(row.Cells(4).Value))


            Dim cellValue As DateTime = row.Cells(4).Value
            Dim limit As DateTime = "17:00 PM"

            If cellValue < limit Then
                under_count.Add(underHour)
            End If

        End If

    End Sub

    Private Sub CalculateuOVERTIME(row As DataGridViewRow)
        '========================================================================= CELL NUMBER PM OUT ===========================================================
        If Not row.Cells(4).Value = Nothing Then

            Dim inHour = New DateTime(Now.Year, Now.Month, Now.Day, 17, 0, 0, 0).ToString("t")
            Dim OTHour As TimeSpan = DateTime.Parse(row.Cells(4).Value).Subtract(DateTime.Parse(inHour))

            If OTHour.Hours > 0 Then

                TotalOTHr_LBL.Text = Convert.ToInt32(TotalOTHr_LBL.Text) + OTHour.Hours
            End If

        End If

    End Sub

    Private Sub Cancel_BTN_Click(sender As Object, e As EventArgs) Handles Cancel_BTN.Click

        TotalAbsent_LBL.Text = 0
        TotalDays_LBL.Text = 0
        TotalRHoliday_LBL.Text = 0
        TotalSHoliday_LBL.Text = 0
        TotalLateHR_LBL.Text = 0
        TotalUTHR_LBL.Text = 0
        TotalOTHr_LBL.Text = 0

        'CheckALL_CheckBox.Checked = False

    End Sub

    Private Sub SearchEMP_BTN_Click(sender As Object, e As EventArgs) Handles SearchEMP_BTN.Click

        If frmEmployee Is Nothing Then
            Dim frm As New frmEmployee With {
                .MdiParent = frmMainForm
            }
            frmMainForm.pNavigate.Controls.Add(frm)
            frmMainForm.pNavigate.Tag = frm
            frm.txtSearch.Tag = "Attendance1"
            frm.Show()
            frm.Dock = DockStyle.Fill
            frm.BringToFront()

        Else
            frmEmployeeInfo.BringToFront()
        End If

    End Sub

    Private Sub Save_BTN_Click(sender As Object, e As EventArgs) Handles Save_BTN.Click

        If Not BiometricID_TXT.Text = "" Then

            'SaveAttendance(BiometricID_TXT.Text, DataGridView1.Tag, TotalDays_LBL.Text, hourOfDay_LBL.Text,
            '                TotalOTHr_LBL.Text, TotalLateHR_LBL.Tag, TotalUTHR_LBL.Tag,
            '                TotalAbsent_LBL.Text, AbsentHour_LBL.Text,
            '                TotalRHoliday_LBL.Text, TotalSHoliday_LBL.Text, Branch_ComboB.SelectedItem)


            SaveAttendanceEE(BiometricID_TXT.Text, DataGridView1.Tag, TotalDays_LBL.Text, TotalOTHr_LBL.Text, TotalLateHR_LBL.Tag, TotalUTHR_LBL.Tag,
                             TotalAbsent_LBL.Text, TotalRHoliday_LBL.Text, TotalSHoliday_LBL.Text, Branch_ComboB.SelectedItem)

            ClearAfter()
        Else
            MsgBox("Please Choose Employee's Name!", MsgBoxStyle.Critical, "Error")
        End If

    End Sub

    Private Sub LoadEmployeeDetails()

        Dim source As New AutoCompleteStringCollection()
        Dim sql As String = "SELECT * FROM tbl_employee Where Upper(LASTNAME) = Upper('" & Name_TXT.Text & "') or Upper(FIRSTNAME) = Upper('" & Name_TXT.Text & "')"

        DbReaderOpen()
        Using rd As FbDataReader = LoadSQL_byDataReader(sql)

            While rd.Read()
                If rd.HasRows Then
                    With rd
                        Dim MI As String

                        If String.IsNullOrEmpty(.Item("MIDDLENAME")) Then
                            MI = ""
                        Else
                            MI = .Item("MIDDLENAME").Substring(0, 1) & "."
                        End If

                        Dim name As String = $"{ .Item("FIRSTNAME")} { MI } { .Item("LASTNAME")} { .Item("SUFFIX")}"

                        source.Add(name.ToString)

                    End With
                End If
            End While
            rd.Close()
        End Using
        Name_TXT.AutoCompleteCustomSource = source
        Name_TXT.AutoCompleteMode = AutoCompleteMode.Suggest
        Name_TXT.AutoCompleteSource = AutoCompleteSource.CustomSource

    End Sub

    Private Function ExcelFilePath(ByVal filePath As String) As String
        DefaultFolder = Path.GetDirectoryName(filePath)
        TargetFile = filePath
        Return TargetFile
    End Function

    Private Sub OpenFile_BTN_Click(sender As Object, e As EventArgs) Handles OpenFile_BTN.Click
        Using f As New OpenFileDialog
            f.Filter = "Excel 2003|*.xls|Excel 2007|*.xlsx"
            If DialogResult.OK = f.ShowDialog() Then
                Path_TXT.Text = f.FileName
                ExcelFilePath(Path_TXT.Text)
                Import_BTN.Enabled = True
            End If
        End Using
    End Sub

    Private Sub forLoop_ALL_IMPORTED()   '================================ WORKS WELL- FOR ALL RECORDS ONLY (PARTNER WITH ToDAtabse()) =============================  
        distinct_bio.Clear()
        Dim paydate_ As String = Paydate.ToString("d")

        Dim sql As String = $"Select distinct(BIO_ID) From IMPORT_DTR where BRANCH = '{Branch_ComboB.SelectedItem}' and PAYDATE = '{paydate_}'"
        Using ds As DataSet = LoadSQL(sql, "IMPORT_DTR")
            If ds.Tables(0).Rows.Count > 0 Then
                For Each dr In ds.Tables(0).Rows
                    With dr
                        distinct_bio.Add(.Item("BIO_ID"))
                    End With
                Next
            End If
        End Using

        For Each biometric_No As String In distinct_bio
            list_inOut.Clear()
            Dim mysql As String = $"Select * From IMPORT_DTR where BIO_ID = '{biometric_No}' and BRANCH = '{Branch_ComboB.SelectedItem}' and PAYDATE = '{paydate_}'"
            Using ds As DataSet = LoadSQL(mysql, "IMPORT_DTR")
                If ds.Tables(0).Rows.Count > 0 Then
                    For Each dr In ds.Tables(0).Rows
                        With dr
                            Dim date_ As DateTime = .Item("DATEANDTIME")

                            list_inOut.Add(date_.ToString("d") & " " & date_.ToShortTimeString)
                        End With
                    Next
                End If
            End Using

            timee = list_inOut.Distinct().ToList

            For Each row As DataGridViewRow In DataGridView1.Rows

                Dim list_hour(3) As String
                Dim DATE_ONLY As String = ""

                Dim rowIndex As Integer = row.Index
                Dim asss As DateTime = DataGridView1.Rows(rowIndex).Tag
                Dim groups_timee As New List(Of String)()

                For Each timme As String In timee
                    If timme.StartsWith(asss.ToString("M/d/yyyy")) Then
                        groups_timee.Add(timme)
                    End If
                Next

                For Each dateTime As DateTime In groups_timee

                    Dim time As DateTime = dateTime.ToString("t")


                    DATE_ONLY = dateTime.ToString("d")
                    '============================== WORKED FINE ========================

                    If time >= "5:00 AM" And time <= "11:59 AM" Then
                        If list_hour(0) = "" Then

                            list_hour(0) = time.ToString("t")
                        Else
                            list_hour(1) = time.ToString("t")
                        End If

                    ElseIf time >= "4:00 PM" And time <= "11:00 PM" Then

                        list_hour(3) = time.ToString("t")

                    ElseIf time >= "1:00 PM" And time <= "3:00 PM" Then

                        list_hour(2) = time.ToString("t")

                    ElseIf time >= "12:00 PM" And time <= "12:59 PM" Then

                        Dim oldValuee As DateTime = dateTime
                        Dim newValuee As String = oldValuee.ToString("d") & " " & oldValuee.TimeOfDay.Hours
                        Dim val As String = oldValuee.ToString("d") & " " & "12"

                        If newValuee = val Then

                            If CountDate(groups_timee, val) = 2 Then
                                list_Group = SortCountedDATE(groups_timee, val)
                            ElseIf CountDate(groups_timee, val) = 1 Then
                                list_Group = SortCountedDATE(groups_timee, val)
                            End If

                            '======================== PRINT 12 NOON ================ WORKED FINE
                            If list_Group.Count = 2 Then

                                Dim list1 As DateTime = list_Group.Item(0)
                                Dim list2 As DateTime = list_Group.Item(1)

                                list_hour(1) = list1.ToString("t")
                                list_hour(2) = list2.ToString("t")

                                list_Group.Clear()
                            ElseIf list_Group.Count = 1 Then

                                Dim list1 As DateTime = list_Group.Item(0)

                                list_hour(1) = list1.ToString("t")

                                list_Group.Clear()
                            End If

                        End If
                    Else
                        list_hour(1) = time.ToString("t")
                    End If
                Next

                If list_hour(0) = "" And list_hour(1) = "" And list_hour(2) = "" And list_hour(3) = "" Then
                Else
                    SaveDTR(biometric_No, Paydate, DATE_ONLY, Branch_ComboB.SelectedItem, list_hour(0), list_hour(1), list_hour(2), list_hour(3))
                End If
            Next
        Next

    End Sub


    Private Sub Import_BTN_Click(sender As Object, e As EventArgs) Handles Import_BTN.Click

        '====================================================== ORIGIINAL ======================================
        If Branch_ComboB.SelectedItem = "" Then
            MsgBox("Please Select File", MsgBoxStyle.Critical, "Error")
        Else

            Dim MyConnection As System.Data.OleDb.OleDbConnection
            Dim DtSet As System.Data.DataSet
            Dim MyCommand As System.Data.OleDb.OleDbDataAdapter

            If Zkteco_RadioB.Checked Then

                eApp = New Excel.Application
                eBook = eApp.Workbooks.Open(Path_TXT.Text)
                eSheet = eBook.Worksheets(1)
                eCell = eSheet.UsedRange
                Dim row As Integer

                MyConnection = New System.Data.OleDb.OleDbConnection($"provider=Microsoft.Jet.OLEDB.4.0;Data Source='{Path_TXT.Text}';Extended Properties=Excel 8.0;")
                MyCommand = New System.Data.OleDb.OleDbDataAdapter($"select * from [{eSheet.Name}$]", MyConnection)
                MyCommand.TableMappings.Add("Table", "Net-informations.com")
                DtSet = New System.Data.DataSet
                MyCommand.Fill(DtSet)

                If File_Exist(Branch_ComboB.SelectedItem, Paydate) Then

                    Cursor = Cursors.WaitCursor

                    For row = 2 To DtSet.Tables(0).Rows.Count
                        SaveBiometricSheet(Paydate, eCell(row, 1).Value, eCell(row, 2).Value, Branch_ComboB.SelectedItem)
                    Next

                    Cursor = Cursors.Default

                ElseIf File_NOT_Exist(Branch_ComboB.SelectedItem, Paydate) Then

                    Cursor = Cursors.WaitCursor

                    For row = 2 To DtSet.Tables(0).Rows.Count
                        SaveBiometricSheet(Paydate, eCell(row, 1).Value, eCell(row, 2).Value, Branch_ComboB.SelectedItem)
                    Next

                    Cursor = Cursors.Default
                Else
                    Path_TXT.Text = ""
                End If

                Cursor = Cursors.WaitCursor

                forLoop_ALL_IMPORTED()   ' ===== SAVE AM_IN, AM_OUT, PM_IN, PM_OUT ====

                Cursor = Cursors.Default

                Import_BTN.Enabled = False
                Path_TXT.Clear()
                MyConnection.Close()

            Else

                eApp = New Excel.Application
                eBook = eApp.Workbooks.Open(Path_TXT.Text)
                eSheet = eBook.Worksheets(1)
                eCell = eSheet.UsedRange
                Dim row As Integer

                MyConnection = New System.Data.OleDb.OleDbConnection($"provider=Microsoft.Jet.OLEDB.4.0;Data Source='{Path_TXT.Text}';Extended Properties=Excel 8.0;")
                MyCommand = New System.Data.OleDb.OleDbDataAdapter($"select * from [{eSheet.Name}$]", MyConnection)
                MyCommand.TableMappings.Add("Table", "Net-informations.com")
                DtSet = New System.Data.DataSet
                MyCommand.Fill(DtSet)

                For row = 7 To DtSet.Tables(0).Rows.Count
                    SaveSheet_FC200(Paydate, eCell(row, 2).Value, eCell(row, 5).Value, Branch_ComboB.SelectedItem)
                Next


                'If File_Exist(Branch_ComboB.SelectedItem, Paydate) Then

                '    Cursor = Cursors.WaitCursor

                '    For row = 7 To DtSet.Tables(0).Rows.Count
                '        SaveSheet_FC200(Paydate, eCell(row, 2).Value, eCell(row, 2).Value, Branch_ComboB.SelectedItem)
                '    Next

                '    Cursor = Cursors.Default

                'ElseIf File_NOT_Exist(Branch_ComboB.SelectedItem, Paydate) Then

                '    Cursor = Cursors.WaitCursor

                '    For row = 2 To DtSet.Tables(0).Rows.Count
                '        SaveSheet_FC200(Paydate, eCell(row, 1).Value, eCell(row, 2).Value, Branch_ComboB.SelectedItem)
                '    Next

                '    Cursor = Cursors.Default
                'Else
                '    Path_TXT.Text = ""
                'End If

                'Cursor = Cursors.WaitCursor

                'forLoop_ALL_IMPORTED()   ' ===== SAVE AM_IN, AM_OUT, PM_IN, PM_OUT ====

                'Cursor = Cursors.Default

                Import_BTN.Enabled = False
                Path_TXT.Clear()
                MyConnection.Close()

            End If

            SAVE_DIRECT_Attendance() ' ===== DIRECT SAVE TO ATTENDANCE ====
            PopulateBiometricSHEET(Bio_grid, Paydate, Branch_ComboB.SelectedItem) ' ===== POPULATE DATAGRIDVIEW FROM SHEET ====
        End If

    End Sub

    Public Sub SAVE_DIRECT_Attendance()
        LoadDateTime()
        Dim paydate_ As String = Paydate.ToString("d")

        For Each biometric_No As String In distinct_bio


            For Each oRow As DataGridViewRow In DataGridView1.Rows
                oRow.Cells(5).Value = False
                For cell As Integer = 1 To 4
                    oRow.Cells(cell).Value = Nothing
                Next
            Next

            Dim mysql As String = $"Select * From BIOMETRIC_DTR where BIO_ID = '{biometric_No}' and BRANCH = '{Branch_ComboB.SelectedItem}' and PAYDATE = '{paydate_}'"
            Using ds As DataSet = LoadSQL(mysql, "BIOMETRIC_DTR")
                If ds.Tables(0).Rows.Count > 0 Then
                    For Each dr In ds.Tables(0).Rows
                        With dr

                            Dim date_ As Date = .Item("DATE_ONLY")

                            For Each row As DataGridViewRow In DataGridView1.Rows

                                Dim rowIndex As Integer = row.Index
                                Dim asss As Date = DataGridView1.Rows(rowIndex).Tag

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

            TotalAbsent_LBL.Text = 0
            TotalDays_LBL.Text = 0
            TotalRHoliday_LBL.Text = 0
            TotalSHoliday_LBL.Text = 0
            TotalLateHR_LBL.Text = 0
            TotalUTHR_LBL.Text = 0
            TotalOTHr_LBL.Text = 0

            For Each row As DataGridViewRow In DataGridView1.Rows

                If Not row.DefaultCellStyle.ForeColor = Color.Red Then

                    '========================================================================= CALCULATE HOLIDAYS  ===========================================================
                    If row.DefaultCellStyle.BackColor = Color.MediumOrchid Then


                        TotalRHoliday_LBL.Text = TotalRHoliday_LBL.Text + 1

                    ElseIf row.DefaultCellStyle.BackColor = Color.Plum Then


                        TotalSHoliday_LBL.Text = TotalSHoliday_LBL.Text + 1

                    End If

                    CalculateLATE(row)

                    CalculateuNDERTIME(row)

                    CalculateuOVERTIME(row)

                End If
            Next

            '===================================== SUM UP LATE ==================================== 
            Dim Late_Total As New TimeSpan
            For Each valueE As TimeSpan In late_count
                Late_Total = Late_Total + valueE
            Next

            late_count.Clear()

            '===================================== SUM UP UNDERTIME ==================================== 
            Dim Under_Total As New TimeSpan
            For Each value As TimeSpan In under_count
                Under_Total = Under_Total + value
            Next

            under_count.Clear()

            '===================================== SUM UP PRESENT AND ABSENT ==================================== 
            Dim Present As Integer = 0
            Dim Absent As Integer = 0
            For Each oRow As DataGridViewRow In DataGridView1.Rows

                If Not oRow.DefaultCellStyle.ForeColor = Color.Red And oRow.Cells(5).Value = True Then
                    Present += 1
                ElseIf Not oRow.DefaultCellStyle.ForeColor = Color.Red And oRow.Cells(5).Value = False Then
                    If Not oRow.DefaultCellStyle.BackColor = Color.MediumOrchid Or Not oRow.DefaultCellStyle.BackColor = Color.Plum Then
                        Absent += 1
                    End If
                End If
            Next

            TotalDays_LBL.Text = Present
            TotalAbsent_LBL.Text = Absent

            '===================================== SUM UP HALF DAY ====================================  
            Dim halfday_Hour As Integer = 0
            For Each oRow As DataGridViewRow In DataGridView1.Rows

                If CountCELL_Nothing(oRow) = 3 Or CountCELL_Consecutive(oRow) = "HALFDAY" Then
                    halfday_Hour += 4
                End If
            Next

            If halfday_Hour = 4 Then

                TotalAbsent_LBL.Text = Convert.ToInt32(TotalAbsent_LBL.Text) + 0.5

            ElseIf halfday_Hour > 4 Then

                Dim result As Integer
                result = halfday_Hour / 8

                TotalAbsent_LBL.Text = result + Convert.ToInt32(TotalAbsent_LBL.Text)
            End If

            Dim product As Double
            product = ((Convert.ToInt32(TotalDays_LBL.Text) * 8)) - halfday_Hour
            product = product / 8
            TotalDays_LBL.Text = product

            SaveAttendanceEE(biometric_No, paydate_, TotalDays_LBL.Text, TotalOTHr_LBL.Text, Late_Total.ToString, Under_Total.ToString,
                             TotalAbsent_LBL.Text, TotalRHoliday_LBL.Text, TotalSHoliday_LBL.Text, Branch_ComboB.SelectedItem)
        Next
    End Sub

    Private Sub Bio_grid_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Bio_grid.MouseDoubleClick

        For Each oRow As DataGridViewRow In DataGridView1.Rows
            oRow.Cells(5).Value = False
            For cell As Integer = 1 To 4
                oRow.Cells(cell).Value = Nothing
            Next
        Next

        CheckALL_CheckBox.Checked = False
        Dim i As Integer = Bio_grid.CurrentRow.Index
        Attendance_Tab.SelectedIndex = 1
        BiometricID_TXT.Text = Bio_grid.Item(0, i).Value
        Name_TXT.Text = Bio_grid.Item(1, i).Value

        DataGridView1.ClearSelection()

        Attendance(Bio_grid.Item(0, i).Value)
    End Sub

    Private Sub Attendance(bioNo As String)

        Dim paydate_ As String = Paydate.ToString("d")

        list_inOut.Clear()
        Dim mysql As String = $"Select * From BIOMETRIC_DTR where BIO_ID = '{bioNo}' and BRANCH = '{Branch_ComboB.SelectedItem}' and PAYDATE = '{paydate_}'"
        Using ds As DataSet = LoadSQL(mysql, "BIOMETRIC_DTR")
            If ds.Tables(0).Rows.Count > 0 Then
                For Each dr In ds.Tables(0).Rows
                    With dr

                        Dim date_ As Date = .Item("DATE_ONLY")

                        For Each row As DataGridViewRow In DataGridView1.Rows

                            Dim rowIndex As Integer = row.Index
                            Dim asss As Date = DataGridView1.Rows(rowIndex).Tag

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

        Calculate_BTN.PerformClick()
    End Sub

    Private Function CheckTimeRange(myDate As DateTime, minTime As TimeSpan, maxTime As TimeSpan) As Boolean
        If minTime > maxTime Then
            Return myDate.TimeOfDay >= minTime OrElse myDate.TimeOfDay < maxTime
        Else
            Return myDate.TimeOfDay >= minTime AndAlso myDate.TimeOfDay < maxTime
        End If
    End Function

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        If BiometricID_TXT.Text = "" Then
            MsgBox("Please Enter Employee's Name.", MsgBoxStyle.Critical, "Error")
        End If

    End Sub

    Private Sub Branch_ComboB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Branch_ComboB.SelectedIndexChanged

        If Zkteco_RadioB.Checked Then

            If Paydate_ComboB.SelectedIndex > 0 Then
                PopulateBiometricSHEET(Bio_grid, Paydate_ComboB.SelectedItem, Branch_ComboB.SelectedItem)
            Else
                PopulateBiometricSHEET(Bio_grid, Paydate, Branch_ComboB.SelectedItem)
            End If

        Else
            Bio_grid.Rows.Clear()
        End If
    End Sub

    Private Sub Paydate_ComboB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Paydate_ComboB.SelectedIndexChanged

        If Branch_ComboB.SelectedIndex >= 0 Then
            If Paydate_ComboB.SelectedIndex > 0 Then
                PopulateBiometricSHEET(Bio_grid, Paydate_ComboB.SelectedItem, Branch_ComboB.SelectedItem)
            Else
                PopulateBiometricSHEET(Bio_grid, Paydate, Branch_ComboB.SelectedItem)
            End If
        End If
    End Sub

    Private Sub Attendance_Tab_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Attendance_Tab.SelectedIndexChanged
        If Attendance_Tab.SelectedIndex = 1 Then
            DataGridView1.ClearSelection()
        End If
    End Sub

    Private Sub BiometricID_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles BiometricID_TXT.KeyPress
        If e.KeyChar <> ChrW(Keys.Back) Then
            If Char.IsNumber(e.KeyChar) Then
            Else
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub Name_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Name_TXT.KeyPress
        LoadEmployeeDetails()
    End Sub

    Private Sub DataGridView1_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError
        '========================= Need para di magERROR ang Datagrid==============
    End Sub

    Private Sub BiometricID_TXT_TextChanged(sender As Object, e As EventArgs) Handles BiometricID_TXT.TextChanged

        If BiometricID_TXT.Text = "" Then
            Name_TXT.Text = ""
        Else

            Dim mysql As String = "Select * From tbl_Employee WHERE BIOMETRICID= '" & BiometricID_TXT.Text & "'"
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

                        Name_TXT.Text = .Item("FIRSTNAME") & " " & MI & " " & .Item("LASTNAME") & " " & .Item("SUFFIX")
                        Name_TXT.Tag = .Item("ID")
                    End With
                Else
                    Name_TXT.Text = ""
                End If
            End Using

        End If

    End Sub

    Private Sub ClearAfter()

        BiometricID_TXT.Clear()
        Name_TXT.Clear()

        TotalDays_LBL.Text = 0

        TotalRHoliday_LBL.Text = 0
        TotalSHoliday_LBL.Text = 0

        TotalOTHr_LBL.Text = 0

        TotalLateHR_LBL.Text = 0

        TotalUTHR_LBL.Text = 0

        TotalAbsent_LBL.Text = 0

        LoadDateTime()
        CheckALL_CheckBox.Checked = True
    End Sub

    Private Sub LoadDTR()

        TotalAbsent_LBL.Text = 0
        TotalDays_LBL.Text = 0
        TotalLateHR_LBL.Text = 0
        TotalUTHR_LBL.Text = 0
        TotalOTHr_LBL.Text = 0
        TotalRHoliday_LBL.Text = 0
        TotalSHoliday_LBL.Text = 0
        DataGridView1.Rows.Clear()

        StartFour = New DateTime(DateNow.Year, DateNow.Month, 4).AddDays(-1)
        EndFour = New DateTime(DateNow.Year, DateNow.Month, 18)

        StartNineteen = New DateTime(DateNow.Year, DateNow.Month, 19).AddMonths(-1).AddDays(-1)
        EndNineteen = New DateTime(StartNineteen.Year, StartNineteen.Month, 3).AddMonths(1)


        If DateNow.Day - 16 <= 2 And DateNow.Day - 16 >= -12 Then

            Paydate = EndNineteen.AddDays(12)
            DataGridView1.Tag = Paydate

            While (StartNineteen < EndNineteen)
                startingDate = StartNineteen.ToString("d")
                EndingDate = EndNineteen.ToString("d")
                DataGridView1.Rows.Add(StartNineteen.AddDays(1).ToString("D"))
                StartNineteen = StartNineteen.AddDays(1)
            End While

        Else

            Paydate = New DateTime(EndFour.Year, EndFour.Month, DateTime.DaysInMonth(EndFour.Year, EndFour.Month))
            DataGridView1.Tag = Paydate

            While (StartFour < EndFour)

                startingDate = StartFour.ToString("d")
                EndingDate = EndFour.ToString("d")
                DataGridView1.Rows.Add(StartFour.AddDays(1).ToString("D"))
                StartFour = StartFour.AddDays(1)

            End While

        End If

        Dim ss As DateTime = Date.UtcNow
        Dim CurrD As DateTime = ss.AddDays(-1)

        '==============================================AM IN 6AM to 9AM==================================================
        For y = 0 To 180

            Dim myDate = New DateTime(CurrD.Year, CurrD.Month, CurrD.Day, 6, 0, 0, 0).AddMinutes(y)
            AM_In_DataGrid.Items.Add(myDate.ToString("t"))

        Next

        '==============================================AM OUT 11AM to 1PM==================================================
        For y = 0 To 120

            Dim myDate = New DateTime(CurrD.Year, CurrD.Month, CurrD.Day, 11, 0, 0, 0).AddMinutes(y)
            AM_Out_DataGrid.Items.Add(myDate.ToString("t"))

        Next

        '==============================================PM IN 12AM to 3PM==================================================
        For y = 0 To 180

            Dim myDate = New DateTime(CurrD.Year, CurrD.Month, CurrD.Day, 12, 0, 0, 0).AddMinutes(y)
            PM_IN_DataGrid.Items.Add(myDate.ToString("t"))

        Next


        '==============================================PM OUT 3PM to 3PM==================================================
        For y = 0 To 480

            Dim myDate = New DateTime(CurrD.Year, CurrD.Month, CurrD.Day, 15, 0, 0, 0).AddMinutes(y)
            PM_Out_DataGrid.Items.Add(myDate.ToString("t"))

        Next

        For i = 0 To DataGridView1.Rows.Count - 1
            Dim r As DataGridViewRow = DataGridView1.Rows(i)
            r.Height = 28

            Dim asss As Date = DataGridView1.Rows(i).Cells(0).Value

            Dim customizeDate As String = asss.ToString("M")

            If asss.DayOfWeek = DayOfWeek.Sunday Then

                r.DefaultCellStyle.ForeColor = Color.Red

                DataGridView1.Rows(i).Cells(5) = New DataGridViewTextBoxCell()
                DataGridView1.Rows(i).Cells(1).Value = ""
                DataGridView1.Rows(i).Cells(2).Value = ""
                DataGridView1.Rows(i).Cells(3).Value = ""
                DataGridView1.Rows(i).Cells(4).Value = ""

            ElseIf HolidayExist(customizeDate) Then

                HolidayDetails(customizeDate, i, DataGridView1)

            End If

        Next

    End Sub

End Class