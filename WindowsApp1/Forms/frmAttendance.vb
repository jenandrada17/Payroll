Imports FirebirdSql.Data.FirebirdClient
Imports Microsoft.Office.Interop

Public Class frmAttendance

    Dim DateNow As DateTime
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
    Dim dateee, starting_date, ending_date, TIME_IN, TIME_OUT As DateTime
    Dim DATE_ONLY, am_in, am_out, pm_in, pm_out As String
    Public branchID, Branch_Name, paydate_, paydate_Records As String

    Dim MyConnection As System.Data.OleDb.OleDbConnection
    Dim DtSet As System.Data.DataSet
    Dim MyCommand As System.Data.OleDb.OleDbDataAdapter

    Private Sub frmAttendance_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LoadDateTime()

        AM_In_DataGrid.Items.Insert(0, "")
        AM_Out_DataGrid.Items.Insert(0, "")
        PM_IN_DataGrid.Items.Insert(0, "")
        PM_Out_DataGrid.Items.Insert(0, "")

        DataGridView1.ClearSelection()

        CheckALL_CheckBox.Checked = True

        PopulateComboBox(Paydate_ComboB, "BIOMETRIC_DTR", "PAYDATE")
        PopulateComboBox(Payslip_DTR_Combo, "BIOMETRIC_DTR", "PAYDATE")
        PopulateComboBox(DTR_Branch_Combo, "PAYROLL_EMPLOYEE", "BRANCH_CODE")
        PopulateComboBox(Paydate7_CB, "BIOMETRIC_DTR", "PAYDATE")

    End Sub

    Private Sub Close_LBL_Click(sender As Object, e As EventArgs) Handles Close_LBL.Click
        Close()
    End Sub

    Public Sub LoadDateTime(Optional datee As DateTime = Nothing)

        SIL_LBL.Text = 0
        TotalDays_LBL.Text = 0
        TotalLateHR_LBL.Text = 0
        TotalUTHR_LBL.Text = 0
        TotalOTHr_LBL.Text = 0
        TotalRHoliday_LBL.Text = 0
        TotalSHoliday_LBL.Text = 0
        DataGridView1.Rows.Clear()

        Dim rowIndex As Integer

        If datee = Nothing Then
            DateNow = DateTime.Now
        Else
            DateNow = datee
        End If

        StartFour = New DateTime(DateNow.Year, DateNow.Month, 4).AddDays(-1)
        EndFour = New DateTime(DateNow.Year, DateNow.Month, 18)

        StartNineteen = New DateTime(DateNow.Year, DateNow.Month, 19).AddMonths(-1).AddDays(-1)
        EndNineteen = New DateTime(StartNineteen.Year, StartNineteen.Month, 3).AddMonths(1)


        If DateNow.Day - 16 <= 2 And DateNow.Day - 16 >= -12 Then

            Paydate = EndNineteen.AddDays(12)
            DataGridView1.Tag = Paydate
            starting_date = StartNineteen.AddDays(1)
            ending_date = EndNineteen

            While (StartNineteen < EndNineteen)
                startingDate = StartNineteen.ToString("d")
                EndingDate = EndNineteen.ToString("d")

                rowIndex = DataGridView1.Rows.Add(StartNineteen.AddDays(1).ToString("D"))
                DataGridView1.Rows(rowIndex).Tag = StartNineteen.AddDays(1).ToString("D")

                StartNineteen = StartNineteen.AddDays(1)
            End While

            Console.WriteLine("PAydateee1 " & Paydate)
        Else

            Paydate = New DateTime(EndFour.Year, EndFour.Month, DateTime.DaysInMonth(EndFour.Year, EndFour.Month))
            DataGridView1.Tag = Paydate
            starting_date = StartFour.AddDays(1)
            ending_date = EndFour

            While (StartFour < EndFour)

                startingDate = StartFour.ToString("d")
                EndingDate = EndFour.ToString("d")

                rowIndex = DataGridView1.Rows.Add(StartFour.AddDays(1).ToString("D"))
                DataGridView1.Rows(rowIndex).Tag = StartFour.AddDays(1).ToString("D")

                StartFour = StartFour.AddDays(1)

            End While

            Console.WriteLine("PAydateee2 " & Paydate)
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

                'DataGridView1.Rows(i).Cells(5) = New DataGridViewTextBoxCell()
                'DataGridView1.Rows(i).Cells(1).Value = ""
                'DataGridView1.Rows(i).Cells(2).Value = ""
                'DataGridView1.Rows(i).Cells(3).Value = ""
                'DataGridView1.Rows(i).Cells(4).Value = ""

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

            Calculate_BTN.PerformClick()
        Else
            For i = 0 To DataGridView1.RowCount - 1
                DataGridView1.Rows(i).Cells(5).Value = False
                DataGridView1.Rows(i).Cells(1).Value = ""
                DataGridView1.Rows(i).Cells(2).Value = ""
                DataGridView1.Rows(i).Cells(3).Value = ""
                DataGridView1.Rows(i).Cells(4).Value = ""
            Next
        End If
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
        If Name_TXT.Text <> Nothing Then
            SIL_LBL.Text = 0
            TotalDays_LBL.Text = 0
            TotalRHoliday_LBL.Text = 0
            TotalSHoliday_LBL.Text = 0
            TotalLateHR_LBL.Text = 0
            TotalUTHR_LBL.Text = 0
            TotalOTHr_LBL.Text = 0
            under_count.Clear()
            late_count.Clear()

            Dim bioNum = BiometricID_TXT.Text
            Dim branchCode = GetBranchCode(bioNum)
            Dim timeIn = GetTime_In(bioNum)
            Dim timeOut = GetTime_Out(bioNum)

            For Each row As DataGridViewRow In DataGridView1.Rows

                If Not row.DefaultCellStyle.ForeColor = Color.Red Then

                    '================================= CALCULATE HOLIDAYS  ===============================
                    If row.DefaultCellStyle.BackColor = Color.MediumOrchid Then


                        TotalRHoliday_LBL.Text = TotalRHoliday_LBL.Text + 1

                    ElseIf row.DefaultCellStyle.BackColor = Color.Plum Then


                        TotalSHoliday_LBL.Text = TotalSHoliday_LBL.Text + 1

                    End If
                End If


                CalculateLATE(row, timeIn, bioNum, branchCode)

                CalculateuNDERTIME(row, timeIn, timeOut, bioNum, branchCode)

                CalculateuOVERTIME(row, timeOut)

            Next

            '===================================== SUM UP LATE ==================================== 
            Dim Late_Total As TimeSpan = New TimeSpan(0, 0, 0, 0, 0)
            For Each valueE As TimeSpan In late_count
                Late_Total = Late_Total + valueE
            Next

            TotalLateHR_LBL.Text = Late_Total.ToString
            late_count.Clear()

            '===================================== SUM UP UNDERTIME ==================================== 
            Dim Under_Total As TimeSpan = New TimeSpan(0, 0, 0, 0, 0)
            For Each value As TimeSpan In under_count
                Under_Total = Under_Total + value
            Next

            TotalUTHR_LBL.Text = Under_Total.ToString
            under_count.Clear()

            '===================================== SUM UP PRESENT AND ABSENT ==================================== 
            Dim Present As Integer = 0
            For Each oRow As DataGridViewRow In DataGridView1.Rows

                If oRow.Cells(5).Value = True Then
                    Present += 1
                End If
            Next

            TotalDays_LBL.Text = Present

            '===================================== SUM UP HALF DAY ====================================  
            Dim halfday_Hour As Integer = 0
            For Each oRow As DataGridViewRow In DataGridView1.Rows

                If CountCELL_Nothing(oRow) = 3 Or CountCELL_Consecutive(oRow) = "HALFDAY" Then
                    halfday_Hour += 4
                End If
            Next

            Dim product As Double
            product = ((Convert.ToInt32(TotalDays_LBL.Text) * 8)) - halfday_Hour
            product = product / 8
            TotalDays_LBL.Text = product

        Else
            MsgBox("Please Enter Employee's Name.", MsgBoxStyle.Critical, "Error")
        End If

    End Sub

    Private Sub CalculateLATE(row As DataGridViewRow, timeIn As DateTime, bioNo As String, branchCode As String)

        '========================================================================= CELL NUMBER AM IN ===========================================================
        If Not row.Cells(1).Value = Nothing Then

            Dim lateHour As TimeSpan = DateTime.Parse(row.Cells(1).Value).Subtract(DateTime.Parse(timeIn.ToShortTimeString))

            Dim cellValue As DateTime = row.Cells(1).Value
            Dim limit As DateTime = (timeIn.AddMinutes(-1)).ToShortTimeString

            If cellValue > limit Then
                late_count.Add(lateHour)
            End If
        End If

        '========================================================================= CELL NUMBER PM IN ===========================================================
        If branchCode = "" Then
            If Not row.Cells(3).Value = Nothing Then

                Dim lateHourr As TimeSpan = DateTime.Parse(row.Cells(3).Value).Subtract(DateTime.Parse(timeIn.AddHours(5).ToShortTimeString))

                Dim cellValue As DateTime = row.Cells(3).Value
                Dim limit As DateTime = timeIn.AddHours(5).AddMinutes(-1).ToShortTimeString

                If cellValue > limit Then
                    late_count.Add(lateHourr)
                End If
            End If
        End If

    End Sub

    Private Sub CalculateuNDERTIME(row As DataGridViewRow, timeIn As DateTime, timeOut As DateTime, bioNo As String, branchCode As String)

        '========================================================================= CELL NUMBER AM OUT ===========================================================
        If branchCode = Nothing Then
            If Not row.Cells(2).Value = Nothing Then

                Dim underHour As TimeSpan = DateTime.Parse(timeIn.AddHours(4).ToShortTimeString).Subtract(DateTime.Parse(row.Cells(2).Value))

                Dim cellValue As DateTime = row.Cells(2).Value
                Dim limit As DateTime = timeIn.AddHours(4).ToShortTimeString

                If cellValue < limit Then
                    under_count.Add(underHour)
                End If

            End If
        End If

        '========================================================================= CELL NUMBER PM OUT ===========================================================
        If Not row.Cells(4).Value = Nothing Then

            Dim underHour As TimeSpan = DateTime.Parse(timeOut.ToShortTimeString).Subtract(DateTime.Parse(row.Cells(4).Value))

            Dim cellValue As DateTime = row.Cells(4).Value
            Dim limit As DateTime = timeOut.ToShortTimeString

            If cellValue < limit Then
                under_count.Add(underHour)
            End If

        End If

    End Sub

    Private Sub CalculateuOVERTIME(row As DataGridViewRow, timeOut As DateTime)
        '========================================================================= CELL NUMBER PM OUT ===========================================================
        If Not row.Cells(4).Value = Nothing Then

            Dim OTHour As TimeSpan = DateTime.Parse(row.Cells(4).Value).Subtract(DateTime.Parse(timeOut.ToShortTimeString))

            If OTHour.Hours > 0 Then
                TotalOTHr_LBL.Text = Convert.ToInt32(TotalOTHr_LBL.Text) + OTHour.Hours
            End If

        End If
    End Sub

    Private Sub Cancel_BTN_Click(sender As Object, e As EventArgs) Handles Cancel_BTN.Click
        BiometricID_TXT.Clear()
        Name_TXT.Clear()
        SIL_LBL.Text = 0
        TotalDays_LBL.Text = 0
        TotalRHoliday_LBL.Text = 0
        TotalSHoliday_LBL.Text = 0
        TotalLateHR_LBL.Text = 0
        TotalUTHR_LBL.Text = 0
        TotalOTHr_LBL.Text = 0
        CheckALL_CheckBox.Checked = False

        'For Each row As DataGridViewRow In DataGridView1.Rows
        '    Dim rowIndex As Integer = row.Index
        '    row.Cells(5) = New DataGridViewCheckBoxCell With {.Value = False}
        'Next
    End Sub

    Private Sub SearchEMP_BTN_Click(sender As Object, e As EventArgs) Handles SearchEMP_BTN.Click

        Try

            Dim instForm As Form = Application.OpenForms.OfType(Of Form)().Where(Function(frm) frm.Name = "frmNewEmployee").SingleOrDefault()
            If instForm Is Nothing Then
                Dim frm As frmNewEmployee
                frm = DirectCast(CreateObjectInstance("frmNewEmployee"), Form)
                frm.MdiParent = frmMainForm
                frmMainForm.pNavigate.Controls.Add(frm)
                frmMainForm.pNavigate.Tag = frm
                frm.txtSearch.Tag = "Attendance1"
                frm.Dock = DockStyle.Fill
                frm.BringToFront()
                frm.Show()
            Else
                instForm.BringToFront()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Save_BTN_Click(sender As Object, e As EventArgs) Handles Save_BTN.Click

        If Not BiometricID_TXT.Text = "" Then
            Dim PAYROLL As String
            If Paydate_ComboB.SelectedIndex >= 0 Then
                PAYROLL = Paydate_ComboB.SelectedItem
            Else
                PAYROLL = DataGridView1.Tag
            End If


            If ThisHasRow($"BIOMETRIC_DTR where BIO_ID = '{BiometricID_TXT.Text}' and PAYDATE = '{PAYROLL}'") Then
                Replacing($"BIOMETRIC_DTR where BIO_ID = '{BiometricID_TXT.Text}' and PAYDATE = '{PAYROLL}';")
            End If


            For Each row As DataGridViewRow In DataGridView1.Rows

                Dim dateOnly As DateTime = DataGridView1.Rows(row.Index).Tag

                If row.Cells(1).Value = "" And row.Cells(2).Value = "" And row.Cells(3).Value = "" And row.Cells(4).Value = "" Then
                Else
                    SaveDTR(BiometricID_TXT.Text, Paydate, dateOnly.ToString("d"),
                        row.Cells(1).Value, row.Cells(2).Value, row.Cells(3).Value, row.Cells(4).Value)
                End If

            Next

            SaveAttendanceEE(BiometricID_TXT.Text, PAYROLL, TotalDays_LBL.Text, TotalOTHr_LBL.Text, TotalLateHR_LBL.Text, TotalUTHR_LBL.Text,
                             TotalRHoliday_LBL.Text, TotalSHoliday_LBL.Text, SIL_LBL.Text)

            SavePayout_IndividualL(BiometricID_TXT.Text, PAYROLL, starting_date, ending_date)

            If Save_BTN.Tag = "UPDATE" Then
                SaveLogs($"UPDATED ATTENDANCE ({Name_TXT.Text} ({BiometricID_TXT.Text})) - Days({TotalDays_LBL.Text}), OT({TotalOTHr_LBL.Text}), Late({TotalLateHR_LBL.Text}), Undertime({TotalUTHR_LBL.Text}), R/S Holiday({TotalRHoliday_LBL.Text}/{TotalSHoliday_LBL.Text}), SIL({SIL_LBL.Text})", frmMainForm.UserName_LBL.Text)
            Else
                SaveLogs($"ADDED ATTENDANCE ({Name_TXT.Text} ({BiometricID_TXT.Text})) - Days({TotalDays_LBL.Text}), OT({TotalOTHr_LBL.Text}), Late({TotalLateHR_LBL.Text}), Undertime({TotalUTHR_LBL.Text}), R/S Holiday({TotalRHoliday_LBL.Text}/{TotalSHoliday_LBL.Text}), SIL({SIL_LBL.Text})", frmMainForm.UserName_LBL.Text)
            End If

            Cancel_BTN.PerformClick()
        Else
            MsgBox("Please Choose Employee's Name!", MsgBoxStyle.Critical, "Error")
        End If

    End Sub

    Private Sub OT_BTN_Click(sender As Object, e As EventArgs) Handles OT_BTN.Click
        TotalOTHr_LBL.Text = 0
    End Sub

    Private Sub Late_BTN_Click(sender As Object, e As EventArgs) Handles Late_BTN.Click
        TotalLateHR_LBL.Text = "00:00:00"
    End Sub

    Private Sub UT_BTN_Click(sender As Object, e As EventArgs) Handles UT_BTN.Click
        TotalUTHR_LBL.Text = "00:00:00"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Paydate_ComboB.SelectedIndex > 0 Then
            PopulateBiometricSHEET(Bio_grid, Paydate_ComboB.SelectedItem)
        Else
            PopulateBiometricSHEET(Bio_grid, Paydate)
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

    Private Sub Path_TXT_TextChanged(sender As Object, e As EventArgs) Handles Path_TXT.TextChanged
        If Not Path_TXT.Text = Nothing Then
            Import_BTN.Enabled = True
        Else
            Import_BTN.Enabled = False
        End If
    End Sub

    Private Sub OpenFile_BTN_Click(sender As Object, e As EventArgs) Handles OpenFile_BTN.Click

        Dim dialog = New OpenFileDialog
        If dialog.ShowDialog() = DialogResult.OK Then
            Path_TXT.Text = dialog.FileName
        End If

        'Using f As New OpenFileDialog
        '    f.Filter = "Excel 2003|*.xls|Excel 2007|*.xlsx"
        '    If DialogResult.OK = f.ShowDialog() Then
        '        Path_TXT.Text = f.FileName
        '        ExcelFilePath(Path_TXT.Text)
        '        Import_BTN.Enabled = True
        '    End If
        'End Using
    End Sub

    Private Sub Preview_BTN_Click(sender As Object, e As EventArgs) Handles Preview_BTN.Click

        If Payslip_DTR_Combo.SelectedIndex >= 0 Then

            If GroupBranch_RadioB.Checked Then
                If DTR_Branch_Combo.SelectedIndex >= 0 Then
                    LoadDTR_Print_Group()
                Else
                    MsgBox("Please select branch.", MsgBoxStyle.Exclamation, "Error")
                End If
            Else
                LoadDTR_Print()
            End If

        Else
            MsgBox("Please select date of payroll.", MsgBoxStyle.Exclamation, "Error")
        End If

    End Sub

    Public Sub LoadDTR_Print()

        RptViewer_DTR.LocalReport.DataSources.Clear()
        RptViewer_DTR.LocalReport.ReportEmbeddedResource = "WindowsApp1.rptDTR_All.rdlc"

        Dim paydatee As String = Payslip_DTR_Combo.SelectedItem
        Dim mysqll As String = ""
        Dim GROUP As String = ""
        Dim StartDate, EndDate As DateTime
        Dim LIST_BIOO As New List(Of String)
        Dim LIST_DATE, EXIST_DATE As New HashSet(Of String)

        '=========================== COMPLETE DATE LIST ==================================
        Dim date_pay As DateTime = Convert.ToDateTime(paydatee)
        date_pay = date_pay.ToString("d")

        If IsLastDay(date_pay) Then
            StartDate = New DateTime(date_pay.Year, date_pay.Month, 4)
            EndDate = New DateTime(date_pay.Year, date_pay.Month, 18)
        Else
            StartDate = New DateTime(date_pay.Year, date_pay.Month, 19).AddMonths(-1)
            EndDate = New DateTime(date_pay.Year, date_pay.Month, 3)
        End If

        While (StartDate <= EndDate)
            LIST_DATE.Add(StartDate.ToString("d"))
            StartDate = StartDate.AddDays(1)
        End While
        '========================================================================

        Try
            Dim all_in As New dtr_all.overAllDataTable

            Dim dt_DTR As New DataTable()
            With dt_DTR
                .Columns.Add("BIOMETRICID")
                .Columns.Add("FULLNAME")
                .Columns.Add("PRESENT_DAYS")
                .Columns.Add("OVERTIME")
                .Columns.Add("LATE")
                .Columns.Add("UNDERTIME")
                .Columns.Add("TIME_IN")
                .Columns.Add("TIME_OUT")
                .Columns.Add("DATE_ONLY")
                .Columns.Add("AM_IN")
                .Columns.Add("AM_OUT")
                .Columns.Add("PM_IN")
                .Columns.Add("PM_OUT")
                .Columns.Add("REGHOLIDAY")
                .Columns.Add("SPECHOLIDAY")
            End With

            If Employee_RadioB.Checked Then  '=========================== EMPLOYEE ==================================

                If Bio1_DTR_TXT.Text <> Nothing And Bio2_DTR_TXT.Text <> Nothing Then  '============ DOUBLE EMPLOYEE

                    mysqll = $"Select A.*, B.FULLNAME, B.BIO_NO as bioNo, B.TIME_IN, B.TIME_OUT, C.* From PAYROLL_ATTENDANCE A 
                                        inner JOIN PAYROLL_EMPLOYEE B ON B.BIO_NO = A.BIOMETRICID 
                                        inner join BIOMETRIC_DTR C ON C.BIO_ID = A.BIOMETRICID AND C.PAYDATE  = A.PAYDATE where A.PAYDATE  = '{paydatee}' and A.BIOMETRICID IN ('{Bio1_DTR_TXT.Text}','{Bio2_DTR_TXT.Text}') ORDER BY DATE_ONLY"

                    LIST_BIOO.Clear()
                    LIST_BIOO.Add(Bio1_DTR_TXT.Text)
                    LIST_BIOO.Add(Bio2_DTR_TXT.Text)
                Else
                    If Bio1_DTR_TXT.Text <> Nothing And Bio2_DTR_TXT.Text = Nothing Then  '============ 1ST EMPLOYEE

                        mysqll = $"Select A.*, B.FULLNAME, B.BIO_NO as bioNo, B.TIME_IN, B.TIME_OUT, C.* From PAYROLL_ATTENDANCE A 
                                        inner JOIN PAYROLL_EMPLOYEE B ON B.BIO_NO = A.BIOMETRICID 
                                        inner join BIOMETRIC_DTR C ON C.BIO_ID = A.BIOMETRICID AND C.PAYDATE  = A.PAYDATE where A.PAYDATE  = '{paydatee}' and A.BIOMETRICID = '{Bio1_DTR_TXT.Text}'  ORDER BY DATE_ONLY  ASC"

                        LIST_BIOO.Clear()
                        LIST_BIOO.Add(Bio1_DTR_TXT.Text)
                    ElseIf Bio2_DTR_TXT.Text <> Nothing And Bio1_DTR_TXT.Text = Nothing Then '============ 2ND EMPLOYEE

                        mysqll = $"Select A.*, B.FULLNAME, B.BIO_NO as bioNo,  B.TIME_IN, B.TIME_OUT, C.* From PAYROLL_ATTENDANCE A 
                                        inner JOIN PAYROLL_EMPLOYEE B ON B.BIO_NO = A.BIOMETRICID 
                                        inner join BIOMETRIC_DTR C ON C.BIO_ID = A.BIOMETRICID  AND C.PAYDATE  = A.PAYDATE where A.PAYDATE  = '{paydatee}' and A.BIOMETRICID = '{Bio2_DTR_TXT.Text}'  ORDER BY DATE_ONLY  ASC"

                        LIST_BIOO.Clear()
                        LIST_BIOO.Add(Bio2_DTR_TXT.Text)

                    Else
                        MsgBox("Please Select Employee Name!")
                    End If
                End If

            ElseIf HO_RadioB.Checked Then    '=========================== HEAD OFFICE ==================================

                mysqll = $"Select A.*, B.FULLNAME, B.BIO_NO as bioNo, B.TIME_IN, B.TIME_OUT, C.* From PAYROLL_ATTENDANCE A 
                                        inner JOIN PAYROLL_EMPLOYEE B ON B.BIO_NO = A.BIOMETRICID 
                                        inner join BIOMETRIC_DTR C ON C.BIO_ID = A.BIOMETRICID AND C.PAYDATE  = A.PAYDATE 
                                        where A.PAYDATE  = '{paydatee}' and COMPANY = 'HEAD OFFICE'  ORDER BY DATE_ONLY ASC"
                LIST_BIOO.Clear()
                LIST_BIOO = ListOfBio(LIST_BIOO, mysqll)
                LIST_BIOO = LIST_BIOO.Distinct().ToList
            End If

            '============================= SAVING ALL DATE ============================  
            For Each VALUE_BIO As String In LIST_BIOO

                EXIST_DATE.Clear()
                EXIST_DATE = ListOfDate(EXIST_DATE, VALUE_BIO, paydatee)

                Dim NEW_LIST_DATE As IEnumerable(Of String) = LIST_DATE.Except(EXIST_DATE)

                For Each OtherD As String In NEW_LIST_DATE
                    SaveDTR(VALUE_BIO, paydatee, OtherD, Nothing, Nothing, Nothing, Nothing, True)
                Next

            Next
            '==============================================================================  

            Using ds As DataSet = LoadSQL(mysqll, "PAYROLL_ATTENDANCE")

                If ds.Tables(0).Rows.Count > 0 Then
                    For Each dr In ds.Tables(0).Rows
                        With dr

                            '============================= NAME AND ATTENDANCE ============================  
                            Dim namee = .Item("FULLNAME")
                            Dim bioNo = .Item("bioNo")
                            Dim DAYS = .Item("PRESENT_DAYS")
                            Dim OT = IIf(.Item("OVERTIME") = 0, 0, .Item("OVERTIME"))
                            Dim LATE = IIf(.Item("LATE").Equals("00:00:00"), "00:00:00", .Item("LATE").Substring(0, 5))
                            Dim UNDERTIME As String = IIf(.Item("UNDERTIME").Equals("00:00:00"), "00:00:00", .Item("UNDERTIME").Substring(0, 5))
                            Dim REGHOLIDAY = .Item("REGHOLIDAY")
                            Dim SPECHOLIDAY = .Item("SPECHOLIDAY")
                            Dim INN As DateTime = IIf(IsDBNull(.Item("TIME_IN")), Nothing, .Item("TIME_IN"))
                            Dim OUTT As DateTime = IIf(IsDBNull(.Item("TIME_OUT")), Nothing, .Item("TIME_OUT"))

                            Dim TIME_IN As String = IIf(INN = Nothing, "", INN.ToShortTimeString)
                            Dim TIME_OUT As String = IIf(OUTT = Nothing, "", OUTT.ToShortTimeString)

                            '============================= BIOMETRIC_DTR ============================
                            Dim dateE As DateTime = Convert.ToDateTime(.Item("DATE_ONLY"))
                            Dim AM_IN = IIf(IsDBNull(.Item("AM_IN")), "", .Item("AM_IN"))
                            Dim AM_OUT = IIf(IsDBNull(.Item("AM_OUT")), "", .Item("AM_OUT"))
                            Dim PM_IN = IIf(IsDBNull(.Item("PM_IN")), "", .Item("PM_IN"))
                            Dim PM_OUT = IIf(IsDBNull(.Item("PM_OUT")), "", .Item("PM_OUT"))

                            dt_DTR.Rows.Add(bioNo, namee, DAYS, OT, LATE, UNDERTIME, TIME_IN, TIME_OUT, dateE.ToString("MMM dd, yyyy"), AM_IN, AM_OUT, PM_IN, PM_OUT, REGHOLIDAY, SPECHOLIDAY)

                            If AM_IN = "" And AM_OUT = "" And PM_IN = "" And PM_OUT = "" Then
                                Replacing($"BIOMETRIC_DTR WHERE BIO_ID = '{bioNo}' AND  PAYDATE = '{paydatee}' AND DATE_ONLY = '{dateE.ToString("d")}'")
                            End If

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

    Public Sub LoadDTR_Print_Group()

        RptViewer_DTR.LocalReport.DataSources.Clear()
        RptViewer_DTR.LocalReport.ReportEmbeddedResource = "WindowsApp1.rpt_DTR_ByGroup.rdlc"

        Dim paydatee As String = Payslip_DTR_Combo.SelectedItem
        Dim mysqll As String = ""

        Dim StartDate, EndDate As DateTime
        Dim LIST_BIOO As New List(Of String)
        Dim LIST_DATE, EXIST_DATE As New HashSet(Of String)

        '=========================== COMPLETE DATE LIST ==================================
        Dim date_pay As DateTime = Convert.ToDateTime(paydatee)
        date_pay = date_pay.ToString("d")

        If IsLastDay(date_pay) Then
            StartDate = New DateTime(date_pay.Year, date_pay.Month, 4)
            EndDate = New DateTime(date_pay.Year, date_pay.Month, 18)
        Else
            StartDate = New DateTime(date_pay.Year, date_pay.Month, 19).AddMonths(-1)
            EndDate = New DateTime(date_pay.Year, date_pay.Month, 3)
        End If

        While (StartDate <= EndDate)
            LIST_DATE.Add(StartDate.ToString("d"))
            StartDate = StartDate.AddDays(1)
        End While
        '========================================================================

        Try
            Dim all_in As New dtr_all.overAllDataTable

            Dim dt_DTR As New DataTable()
            With dt_DTR
                .Columns.Add("FULLNAME")
                .Columns.Add("PRESENT_DAYS")
                .Columns.Add("OVERTIME")
                .Columns.Add("LATE")
                .Columns.Add("UNDERTIME")
                .Columns.Add("TIME_IN")
                .Columns.Add("TIME_OUT")
                .Columns.Add("DATE_ONLY")
                .Columns.Add("AM_IN")
                .Columns.Add("AM_OUT")
                .Columns.Add("PM_IN")
                .Columns.Add("PM_OUT")
            End With

            mysqll = $"Select * From PAYROLL_ATTENDANCE A 
                                        inner JOIN PAYROLL_EMPLOYEE B ON B.BIO_NO = A.BIOMETRICID 
                                        inner join BIOMETRIC_DTR C ON C.BIO_ID = B.BIO_NO  AND C.PAYDATE  = A.PAYDATE 
                                        where A.PAYDATE  = '{paydatee}' and B.BRANCH_CODE = '{DTR_Branch_Combo.Text}'  ORDER BY DATE_ONLY"

            '=========================== LIST OF BIO (COMPLETE DATE) ==================================
            LIST_BIOO.Clear()
            LIST_BIOO = ListOfBio(LIST_BIOO, mysqll)
            LIST_BIOO = LIST_BIOO.Distinct().ToList
            '============================= SAVING ALL DATE ============================  
            For Each VALUE_BIO As String In LIST_BIOO

                EXIST_DATE.Clear()
                EXIST_DATE = ListOfDate(EXIST_DATE, VALUE_BIO, paydatee)

                Dim NEW_LIST_DATE As IEnumerable(Of String) = LIST_DATE.Except(EXIST_DATE)

                For Each OtherD As String In NEW_LIST_DATE
                    SaveDTR(VALUE_BIO, paydatee, OtherD, Nothing, Nothing, Nothing, Nothing)
                Next

            Next
            '==================================================================================

            Using ds As DataSet = LoadSQL(mysqll, "PAYROLL_ATTENDANCE")

                If ds.Tables(0).Rows.Count > 0 Then

                    For Each dr In ds.Tables(0).Rows
                        With dr

                            '============================= NAME AND ATTENDANCE ============================ 
                            Dim namee As String = .Item("FULLNAME")
                            Dim DAYS As String = .Item("PRESENT_DAYS")
                            Dim OT As String = IIf(.Item("OVERTIME") = 0, 0, .Item("OVERTIME"))
                            Dim LATE As String = IIf(.Item("LATE").Equals("00:00:00"), "00:00:00", .Item("LATE").Substring(0, 5))
                            Dim UNDERTIME As String = IIf(.Item("UNDERTIME").Equals("00:00:00"), "00:00:00", .Item("UNDERTIME").Substring(0, 5))
                            Dim INN As DateTime = IIf(IsDBNull(.Item("TIME_IN")), Nothing, .Item("TIME_IN"))
                            Dim OUTT As DateTime = IIf(IsDBNull(.Item("TIME_OUT")), Nothing, .Item("TIME_OUT"))

                            Dim TIME_IN As String = IIf(INN = Nothing, "", INN.ToShortTimeString)
                            Dim TIME_OUT As String = IIf(OUTT = Nothing, "", OUTT.ToShortTimeString)

                            '============================= BIOMETRIC_DTR ============================
                            Dim dateE As DateTime = Convert.ToDateTime(.Item("DATE_ONLY"))
                            Dim AM_IN = IIf(IsDBNull(.Item("AM_IN")), "", .Item("AM_IN"))
                            Dim AM_OUT = IIf(IsDBNull(.Item("AM_OUT")), "", .Item("AM_OUT"))
                            Dim PM_IN = IIf(IsDBNull(.Item("PM_IN")), "", .Item("PM_IN"))
                            Dim PM_OUT = IIf(IsDBNull(.Item("PM_OUT")), "", .Item("PM_OUT"))

                            dt_DTR.Rows.Add(namee, DAYS, OT, LATE, UNDERTIME, TIME_IN, TIME_OUT, dateE.ToString("MMM dd, yyyy"), AM_IN, AM_OUT, PM_IN, PM_OUT)

                        End With
                    Next
                End If
            End Using

            Dim rds_DTR As New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt_DTR)
            RptViewer_DTR.LocalReport.DataSources.Add(rds_DTR)
            RptViewer_DTR.RefreshReport()

            Replacing($"BIOMETRIC_DTR WHERE PAYDATE = '{paydatee}' AND am_in IS NULL AND  am_out  IS NULL AND  pm_in  IS NULL AND  pm_out  IS NULL ")

        Catch ex As Exception
            Log_Report(ex.ToString)
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub EmpSelect_BTN_Click(sender As Object, e As EventArgs) Handles EmpSelect1_BTN.Click

        Try

            Dim instForm As Form = Application.OpenForms.OfType(Of Form)().Where(Function(frm) frm.Name = "frmNewEmployee").SingleOrDefault()
            If instForm Is Nothing Then
                Dim frm As frmNewEmployee
                frm = DirectCast(CreateObjectInstance("frmNewEmployee"), Form)
                frm.MdiParent = frmMainForm
                frmMainForm.pNavigate.Controls.Add(frm)
                frmMainForm.pNavigate.Tag = frm
                frm.txtSearch.Tag = "Attendance-PrintDTR_1"
                frm.Dock = DockStyle.Fill
                frm.BringToFront()
                frm.Show()
            Else
                instForm.BringToFront()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Employee_RadioB_CheckedChanged(sender As Object, e As EventArgs) Handles Employee_RadioB.CheckedChanged
        If Employee_RadioB.Checked = True Then
            Employee1_GroupB.Visible = True
            Employee2_GroupB.Visible = True
        Else
            Employee1_GroupB.Visible = False
            Employee2_GroupB.Visible = False
        End If
    End Sub

    Private Sub Bio_DTR_TXT_TextChanged(sender As Object, e As EventArgs) Handles Bio1_DTR_TXT.TextChanged
        If Bio1_DTR_TXT.Text = "" Then
            DTR_Emp1_TXT.Text = ""
        Else
            GetName(Bio1_DTR_TXT.Text, DTR_Emp1_TXT)
        End If
    End Sub

    Private Sub forLoop_ALL_IMPORTED()   '================================ WORKS WELL- FOR ALL RECORDS ONLY (PARTNER WITH SAVE_DIRECT_Attendance()()) =============================   
        LoadDateTime()
        AM_In_DataGrid.Items.Insert(0, "")
        AM_Out_DataGrid.Items.Insert(0, "")
        PM_IN_DataGrid.Items.Insert(0, "")
        PM_Out_DataGrid.Items.Insert(0, "")

        Dim group_Empty, group_Save As New List(Of String)()

        Dim paydate_ As String = Paydate.ToString("d")
        distinct_bio = distinct_bio.Distinct().ToList


        progressBarStart(distinct_bio.Count)

        For Each biometric_No As String In distinct_bio
            list_inOut.Clear()

            '======================== GET TIME IN/OUT TO CALCULATE LATE UNDERTIME OVERTIME ============================
            TIME_IN = GetTime_In(biometric_No)
            TIME_OUT = GetTime_Out(biometric_No)

            Dim mysql As String = $"Select * From IMPORT_DTR where BIO_ID = '{biometric_No}' and PAYDATE = '{paydate_}'"
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
                    If timme.StartsWith(asss.ToString("d")) Then
                        groups_timee.Add(timme)
                    End If
                Next

                For Each dateTime As DateTime In groups_timee

                    Dim time As DateTime = dateTime.ToString("t")

                    DATE_ONLY = dateTime.ToString("d")
                    '============================== WORKED FINE ========================

                    If time >= TIME_IN.AddHours(-3).ToShortTimeString And time <= TIME_IN.AddHours(4).AddMinutes(-1).ToShortTimeString And Not time.Hour = 12 Then
                        If list_hour(0) = "" Then

                            list_hour(0) = time.ToString("t")
                        Else
                            list_hour(1) = time.ToString("t")
                        End If

                    ElseIf time >= TIME_OUT.AddHours(-1).ToShortTimeString Then
                        list_hour(3) = time.ToString("t")

                    ElseIf time >= TIME_IN.AddHours(5).ToShortTimeString And time <= TIME_IN.AddHours(7).AddMinutes(-1).ToShortTimeString Then
                        If list_hour(2) = "" Then

                            list_hour(2) = time.ToString("t")
                        Else
                            list_hour(3) = time.ToString("t")
                        End If

                    ElseIf (time >= "12:00 PM" Or time >= TIME_IN.AddHours(4).ToShortTimeString) And (time <= "12:59 PM" Or time <= TIME_IN.AddHours(5).AddMinutes(-1).ToShortTimeString) Then

                        Dim breaktime As DateTime = TIME_IN.AddHours(4)
                        Dim oldValuee As DateTime = dateTime
                        Dim newValuee As String = oldValuee.ToString("d") & " " & oldValuee.TimeOfDay.Hours
                        Dim val As String = oldValuee.ToString("d") & " " & breaktime.TimeOfDay.Hours

                        If time >= "12:00 PM" And time <= "12:59 PM" Then
                            newValuee = oldValuee.ToString("d") & " " & oldValuee.TimeOfDay.Hours
                            val = oldValuee.ToString("d") & " " & "12"
                        End If

                        If newValuee = val Then

                            If CountDate(groups_timee, val) >= 2 Then
                                list_Group = SortCountedDATE(groups_timee, val)
                            ElseIf CountDate(groups_timee, val) = 1 Then
                                list_Group = SortCountedDATE(groups_timee, val)
                            End If

                            '======================== PRINT 12 NOON ================ WORKED FINE
                            If list_Group.Count >= 2 Then

                                Dim list1 As DateTime = list_Group.Item(0)
                                Dim list2 As DateTime = list_Group.Item(list_Group.Count - 1)

                                list_hour(1) = list1.ToString("t")
                                list_hour(2) = list2.ToString("t")

                                list_Group.Clear()
                            ElseIf list_Group.Count = 1 Then

                                Dim list1 As DateTime = list_Group.Item(0)

                                list_hour(1) = list1.ToString("t")

                                list_Group.Clear()

                            Else   ' =========== PRINT SINGLE 12:00 TO 12:59 ==========
                                If list_hour(2) = "" Then

                                    list_hour(2) = time.ToString("t")
                                Else
                                    list_hour(3) = time.ToString("t")
                                End If
                            End If

                        End If
                    Else
                        list_hour(1) = time.ToString("t")
                    End If
                Next

                If list_hour(0) = "" And list_hour(1) = "" And list_hour(2) = "" And list_hour(3) = "" Then
                Else
                    SaveDTR(biometric_No, Paydate, DATE_ONLY, list_hour(0), list_hour(1), list_hour(2), list_hour(3))
                End If

            Next

            frmMainForm.AppProgressBar.Value += 1
        Next

        progressBarEnd()
    End Sub

    Private Sub Search_BTN_Click(sender As Object, e As EventArgs) Handles Search_BTN.Click
        PopulateBiometricSHEET(Bio_grid, Paydate, Search_TXT.Text)
    End Sub

    Private Sub Search_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Search_TXT.KeyPress
        If IsEnter(e) Then Search_BTN.PerformClick()
    End Sub

    Private Sub GroupBranch_RadioB_CheckedChanged(sender As Object, e As EventArgs) Handles GroupBranch_RadioB.CheckedChanged
        If GroupBranch_RadioB.Checked = True Then
            Branch_group.Visible = True
        Else
            Branch_group.Visible = False
        End If
    End Sub

    Private Sub EmpSelect2_BTN_Click(sender As Object, e As EventArgs) Handles EmpSelect2_BTN.Click

        Try
            Dim instForm As Form = Application.OpenForms.OfType(Of Form)().Where(Function(frm) frm.Name = "frmNewEmployee").SingleOrDefault()
            If instForm Is Nothing Then
                Dim frm As frmNewEmployee
                frm = DirectCast(CreateObjectInstance("frmNewEmployee"), Form)
                frm.MdiParent = frmMainForm
                frmMainForm.pNavigate.Controls.Add(frm)
                frmMainForm.pNavigate.Tag = frm
                frm.txtSearch.Tag = "Attendance-PrintDTR_2"
                frm.Dock = DockStyle.Fill
                frm.BringToFront()
                frm.Show()
            Else
                instForm.BringToFront()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Bio_grid_MouseClick(sender As Object, e As MouseEventArgs) Handles Bio_grid.MouseClick
        If e.Button = MouseButtons.Right Then
            If Bio_grid.Rows.Count >= 0 Then
                Context_Records.Show(Bio_grid, New Point(e.X, e.Y))
            End If
        End If
    End Sub

    Private Sub CancelDTR_BTN_Click(sender As Object, e As EventArgs) Handles CancelDTR_BTN.Click
        RptViewer_DTR.Clear()
        Bio1_DTR_TXT.Clear()
        DTR_Emp1_TXT.Clear()
        Bio2_DTR_TXT.Clear()
        DTR_Emp2_TXT.Clear()
        DTR_Branch_Combo.Text = "   Select Branch"
        Branch_DTR_TXT.Clear()
    End Sub

    Private Sub Email_BTN_Click(sender As Object, e As EventArgs) Handles Email_BTN.Click
        If RptViewer_DTR.LocalReport.DataSources.Count <> 0 Then
            Send_Email(RptViewer_DTR.LocalReport.Render("PDF"), Branch_DTR_TXT.Text, DTR_Branch_Combo.Text, Payslip_DTR_Combo.Text, "", "DAILY TIME RECORD")
        Else
            MsgBox("Please Click Preview before Sending", MsgBoxStyle.Exclamation, "INVALID")
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)

        Dim dialog = New OpenFileDialog
        If dialog.ShowDialog() = DialogResult.OK Then
            Emp7_TXT.Text = dialog.FileName
        End If
    End Sub

    Private Sub IMPORTED_7eleven()   '================================ WORKS WELL- FOR ALL RECORDS ONLY (PARTNER WITH SAVE_DIRECT_Attendance()()) =============================   

        'LoadDateTime()
        'AM_In_DataGrid.Items.Insert(0, "")
        'AM_Out_DataGrid.Items.Insert(0, "")
        'PM_IN_DataGrid.Items.Insert(0, "")
        'PM_Out_DataGrid.Items.Insert(0, "")

        Dim timee_ As List(Of DateTime) = Nothing
        Dim list_inOut_ As List(Of DateTime) = Nothing

        Dim paydate_ As String = Paydate.ToString("d")
        distinct_bio = distinct_bio.Distinct().ToList

        For Each biometric_No As String In distinct_bio
            list_inOut_.Clear()

            Dim mysql As String = $"Select * From IMPORT_DTR where BIO_ID = '{biometric_No}' and PAYDATE = '{paydate_}'"
            Using ds As DataSet = LoadSQL(mysql, "IMPORT_DTR")
                If ds.Tables(0).Rows.Count > 0 Then
                    For Each dr In ds.Tables(0).Rows
                        With dr
                            Dim date_ As DateTime = .Item("DATEANDTIME")

                            list_inOut_.Add(date_.ToString("d") & " " & date_.ToShortTimeString)
                        End With
                    Next
                End If
            End Using


            timee_ = list_inOut_.Distinct().ToList


            'For i = 0 To timee_.Count

            '    Dim timePeriod As TimeSpan
            '    Dim time1 As DateTime = timee.Item(i)
            '    Dim time2 As DateTime = timee.Item(i + 1)

            'Next


            'For Each row As DataGridViewRow In DataGridView1.Rows

            '    Dim list_hour(3) As String
            '    Dim DATE_ONLY As String = ""

            '    Dim rowIndex As Integer = row.Index
            '    Dim asss As DateTime = DataGridView1.Rows(rowIndex).Tag
            '    Dim groups_timee As New List(Of DateTime)()

            'For Each timme As String In timee
            '    If timme.StartsWith(asss.ToString("d")) Then
            '        groups_timee.Add(timme)

            '    End If
            'Next

            'groups_timee.Sort(New Comparison(Of Date)(Function(x As Date, y As Date) y.CompareTo(x)))
            'groups_timee.Reverse()

            'For Each dateTime As String In groups_timee
            '    Console.WriteLine("Sorted dateTime  " & dateTime)
            'Next

            'Console.WriteLine("tOTAL HOUR " & )
            'Console.WriteLine()

            'If list_hour(0) = "" And list_hour(1) = "" And list_hour(2) = "" And list_hour(3) = "" Then
            'Else
            '    SaveDTR(biometric_No, Paydate, DATE_ONLY, list_hour(0), list_hour(1), list_hour(2), list_hour(3))
            'End If
            'Next
        Next
    End Sub

    Private Sub SearchEmp7_BTN_Click(sender As Object, e As EventArgs) Handles SearchEmp7_BTN.Click

        Try

            Dim instForm As Form = Application.OpenForms.OfType(Of Form)().Where(Function(frm) frm.Name = "frmNewEmployee").SingleOrDefault()
            If instForm Is Nothing Then
                Dim frm As frmNewEmployee
                frm = DirectCast(CreateObjectInstance("frmNewEmployee"), Form)
                frm.MdiParent = frmMainForm
                frmMainForm.pNavigate.Controls.Add(frm)
                frmMainForm.pNavigate.Tag = frm
                frm.txtSearch.Tag = "Attendance-7Eleven"
                frm.Dock = DockStyle.Fill
                frm.BringToFront()
                frm.Show()
            Else
                instForm.BringToFront()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Bio7_TXT_TextChanged(sender As Object, e As EventArgs) Handles Bio7_TXT.TextChanged

        Dim PAYROLL As String
        If Paydate_ComboB.SelectedIndex >= 0 Then
            PAYROLL = Paydate_ComboB.SelectedItem
        Else
            PAYROLL = DataGridView1.Tag
        End If

        If Not String.IsNullOrEmpty(Bio7_TXT.Text) Then

            GetName(Bio7_TXT.Text, Emp7_TXT)
            GetAttendance_Shifting(Bio7_TXT.Text, PAYROLL)


            '==========================  CHECK PAYDATE IF VALID FOR EDITING =========================   
            If Paydate_ComboB.SelectedIndex >= 0 Then
                If Paydate_ComboB.Text = frmMainForm.Paydate.ToString("d") Then
                    Save7_BTN.Enabled = True
                Else
                    Save7_BTN.Enabled = False
                End If
            Else
                Save7_BTN.Enabled = True
            End If

        Else
            Emp7_TXT.Clear()
        End If

    End Sub

    Public Sub GetAttendance_Shifting(bioNo As String, PAYROLL As String)

        Dim mysql As String = $"Select * From  PAYROLL_ATTENDANCE where BIOMETRICID = '{bioNo}' and PAYDATE = '{PAYROLL}'"
        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_ATTENDANCE")
            If ds.Tables(0).Rows.Count > 0 Then
                For Each dr In ds.Tables(0).Rows
                    With dr

                        Days7_TXT.Text = .Item("PRESENT_DAYS")
                        Overtime7_TXT.Text = .Item("OVERTIME")
                        'Dim Latee As String = IIf(IsDBNull(.Item("LATE")), "", .Item("LATE"))
                        'Dim Undertime As String = IIf(IsDBNull(.Item("UNDERTIME")), "", .Item("UNDERTIME"))
                        Late7_TXT.Text = IIf(IsDBNull(.Item("LATE")), "00:00:00", .Item("LATE"))
                        Undertime7_TXT.Text = IIf(IsDBNull(.Item("UNDERTIME")), "00:00:00", .Item("UNDERTIME"))
                        Night7_TXT.Text = IIf(IsDBNull(.Item("NIGHT_RATE")), "", .Item("NIGHT_RATE"))
                        SIL7_NUP.Text = IIf(IsDBNull(.Item("SIL")), "", .Item("SIL"))

                        'If Latee.Length > 5 Then
                        '    Late7_TXT.Text = Latee.Substring(0, Latee.Length - 3)
                        'End If

                        'If Undertime.Length > 5 Then
                        '    Undertime7_TXT.Text = Undertime.Substring(0, Undertime.Length - 3)
                        'End If

                        Save7_BTN.Tag = "UPDATE"

                    End With
                Next
            Else

                Days7_TXT.Clear()
                Overtime7_TXT.Clear()
                Late7_TXT.Clear()
                Undertime7_TXT.Clear()
                Night7_TXT.Clear()
                SIL7_NUP.TextAlign = 0

                Save7_BTN.Tag = "NEW"
            End If
        End Using

    End Sub


    Private Sub Save7_BTN_Click(sender As Object, e As EventArgs) Handles Save7_BTN.Click

        If Not Bio7_TXT.Text = "" And Not Days7_TXT.Text = "" Then
            Dim PAYROLL As String
            If Paydate7_CB.SelectedIndex >= 0 Then
                PAYROLL = Paydate7_CB.SelectedItem
            Else
                PAYROLL = DataGridView1.Tag
            End If

            '====================== LATE CONVERTER ==============
            Dim Late_TS, UT_TS As TimeSpan
            Late_TS = TimeSpan.Zero
            UT_TS = TimeSpan.Zero

            If Not String.IsNullOrEmpty(Late7_TXT.Text) Then
                Late_TS = TimeSpan.FromMinutes(Late7_TXT.Text)
            End If

            If Not String.IsNullOrEmpty(Undertime7_TXT.Text) Then
                UT_TS = TimeSpan.FromMinutes(Undertime7_TXT.Text)
            End If

            SaveAttendanceEE(Bio7_TXT.Text, PAYROLL, Days7_TXT.Text, IIf(Overtime7_TXT.Text = "", "0", Overtime7_TXT.Text), Late_TS.ToString, UT_TS.ToString,
                             TotalRHoliday_LBL.Text, TotalSHoliday_LBL.Text, Night7_TXT.Text, SIL7_NUP.Text)

            'updateHoliday_Attendance(Bio7_TXT.Text, PAYROLL)

            SavePayout_IndividualL(Bio7_TXT.Text, PAYROLL, starting_date, ending_date)

            If Save_BTN.Tag = "UPDATE" Then
                SaveLogs($"UPDATED ATTENDANCE ({Emp7_TXT.Text} ({Bio7_TXT.Text})) - Days({Days7_TXT.Text}), OT({Overtime7_TXT.Text}), Late({Late_TS.ToString}), Undertime({UT_TS.ToString}), R/S Holiday({TotalRHoliday_LBL.Text}/{TotalSHoliday_LBL.Text}), Night Rate({Night7_TXT.Text}), SIL({SIL7_NUP.Text})", frmMainForm.UserName_LBL.Text)
            Else
                SaveLogs($"ADDED ATTENDANCE ({Emp7_TXT.Text} ({Bio7_TXT.Text})) - Days({Days7_TXT.Text}), OT({Overtime7_TXT.Text}), Late({Late_TS.ToString}), Undertime({UT_TS.ToString}), R/S Holiday({TotalRHoliday_LBL.Text}/{TotalSHoliday_LBL.Text}), Night Rate({Night7_TXT.Text}), SIL({SIL7_NUP.Text})", frmMainForm.UserName_LBL.Text)
            End If

            Cancel7_BTN.PerformClick()
        Else
            MsgBox("Please Ensure that Employee's Name and No. of days are inputed!", MsgBoxStyle.Critical, "Error")
        End If

    End Sub

    Private Sub Hours7_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Undertime7_TXT.KeyPress, Overtime7_TXT.KeyPress, Night7_TXT.KeyPress, Late7_TXT.KeyPress, Days7_TXT.KeyPress

        If e.KeyChar <> ChrW(Keys.Back) Then

            If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso Not e.KeyChar = "." Then
                e.Handled = True
            End If
        End If

    End Sub

    Private Sub Cancel7_BTN_Click(sender As Object, e As EventArgs) Handles Cancel7_BTN.Click
        Bio7_TXT.Clear()
        Emp7_TXT.Clear()
        Days7_TXT.Clear()
        Overtime7_TXT.Clear()
        Late7_TXT.Clear()
        Undertime7_TXT.Clear()
        Night7_TXT.Clear()
    End Sub

    Private Sub SIL_BTN_Click(sender As Object, e As EventArgs) Handles SIL_BTN.Click
        If Name_TXT.Text <> "" Then
            If SIL_BTN.Text = "Add" Then

                Dim totalMonths As Integer = CountYear_SIL(BiometricID_TXT.Text, ending_date)

                If totalMonths >= 13 Then
                    SIL_Panel.Visible = True
                    SIL_Panel.Location = New Point(SIL_BTN.Location.X - 160, SIL_BTN.Location.Y - 10)
                Else
                    MsgBox($"Not yet allowed to avail SIL.", MsgBoxStyle.Critical, "Invalid")
                End If

            Else
                SIL_BTN.Text = "Add"
                SIL_LBL.Text = 0
                SIL_NUP.Text = 1
            End If
        Else
            MsgBox($"Please select employee.", MsgBoxStyle.Exclamation, "Invalid")
        End If
    End Sub

    Private Sub Label37_Click(sender As Object, e As EventArgs)
        SIL_Panel.Visible = False
    End Sub

    Private Sub AddSIL_BTN_Click(sender As Object, e As EventArgs) Handles AddSIL_BTN.Click
        SIL_LBL.Text = SIL_NUP.Text
        SIL_BTN.Text = "Clear"
        SIL_Panel.Visible = False
    End Sub

    Private Sub CancelSIL_BTN_Click(sender As Object, e As EventArgs) Handles CancelSIL_BTN.Click
        SIL_NUP.Text = 1
        SIL_Panel.Visible = False
    End Sub

    Private Sub Bio2_DTR_TXT_TextChanged(sender As Object, e As EventArgs) Handles Bio2_DTR_TXT.TextChanged
        If Bio2_DTR_TXT.Text = "" Then
            DTR_Emp2_TXT.Text = ""
        Else
            GetName(Bio2_DTR_TXT.Text, DTR_Emp2_TXT)
        End If
    End Sub

    Private Sub Paydate7_CB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Paydate7_CB.SelectedIndexChanged

        If Paydate7_CB.SelectedIndex >= 0 Then
            paydate_ = Paydate7_CB.SelectedItem
        Else
            paydate_ = Paydate.ToString("d")
        End If

        Populate_S7ELVEN(Seven_Grid, paydate_)

    End Sub

    Private Sub Search7_BTN_Click(sender As Object, e As EventArgs) Handles Search7_BTN.Click
        Populate_S7ELVEN(Seven_Grid, paydate_, Search7_TXT.Text)
    End Sub

    Private Sub Search7_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Search7_TXT.KeyPress
        If IsEnter(e) Then Search7_BTN.PerformClick()
    End Sub

    Private Sub DTR_Branch_Combo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DTR_Branch_Combo.SelectedIndexChanged
        If DTR_Branch_Combo.SelectedIndex >= 0 Then
            branchID = GetBranch_ID(DTR_Branch_Combo.SelectedItem)
        End If
    End Sub

    Private Sub Menu_Remove_Click(sender As Object, e As EventArgs) Handles Menu_Remove.Click
        If Paydate_ComboB.SelectedIndex >= 0 Then
            Dim i As Integer = Bio_grid.CurrentRow.Index
            Dim branch As String = Bio_grid.Item(0, i).Tag  '============ WRONG
            Dim result As DialogResult = MessageBox.Show($"{branch} record will be removed from the list, do you want to proceed?", "Warning", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                Replacing($"BIOMETRIC_DTR where BRANCH = '{branch}' and PAYDATE = '{Paydate_ComboB.SelectedItem}';") 'THIS IS TO REMOVE BRANCH RECORD  
                MsgBox("Succesfully removed!")

                PopulateBiometricSHEET(Bio_grid, Paydate)
            End If
        Else
            MsgBox("Please Select Payroll")
        End If
    End Sub

    Private Sub Import_BTN_Click(sender As Object, e As EventArgs) Handles Import_BTN.Click

        '====================================================== ORIGIINAL ====================================== 
        eApp = New Excel.Application
        eBook = eApp.Workbooks.Open(Path_TXT.Text)
        eSheet = eBook.Worksheets(1)
        eCell = eSheet.UsedRange

        Dim FirstColumn As String = eCell(2, 1).Value

        If Integer.TryParse(FirstColumn, vbNull) Then
            bio_White()
        Else
            If FirstColumn = "OUR COMPANY" Then
                bio_OURCOMPANY()
            Else
                bio_InSys()
            End If
        End If

        '====================== TRANSACTION ==========================
        Dim listt As String = Nothing
        For Each bio As String In distinct_bio
            If listt = Nothing Then
                listt = bio
            Else
                listt = listt & ", " & bio
            End If
        Next

        SaveLogs($"IMPORTED BIOMETRIC ({listt})", frmMainForm.UserName_LBL.Text)

        '=============================================================
        PopulateComboBox(Paydate_ComboB, "BIOMETRIC_DTR", "PAYDATE")
        Has_Rows_Delete("IMPORT_DTR")

    End Sub


    Private Sub bio_White()
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

        distinct_bio.Clear()
        list_inOut.Clear()

        progressBarStart(DtSet.Tables(0).Rows.Count)

        For row = 2 To DtSet.Tables(0).Rows.Count + 1
            If eCell(row, 1).Value <> Nothing And eCell(row, 2).Value <> Nothing Then

                SaveBiometricSheet(Paydate, eCell(row, 1).Value, eCell(row, 2).Value)
                distinct_bio.Add(eCell(row, 1).Value)

                frmMainForm.AppProgressBar.Value += 1

            End If

        Next

        progressBarEnd()

        forLoop_ALL_IMPORTED()   ' ===== SAVE AM_IN, AM_OUT, PM_IN, PM_OUT ====
        SAVE_DIRECT_Attendance() ' ===== DIRECT SAVE TO ATTENDANCE ==== 
        PopulateBiometricSHEET(Bio_grid, Paydate) ' ===== POPULATE DATAGRIDVIEW FROM SHEET ==== 
        SavePayout_ALL(Paydate, starting_date, ending_date)

        Import_BTN.Enabled = False
        Path_TXT.Clear()
        MyConnection.Close()

    End Sub

    Private Sub bio_InSys()

        eApp = New Excel.Application
        eBook = eApp.Workbooks.Open(Path_TXT.Text)
        eSheet = eBook.Worksheets(1)
        eCell = eSheet.UsedRange

        MyConnection = New System.Data.OleDb.OleDbConnection($"provider=Microsoft.Jet.OLEDB.4.0;Data Source='{Path_TXT.Text}';Extended Properties=Excel 8.0;")
        MyCommand = New System.Data.OleDb.OleDbDataAdapter($"select * from [{eSheet.Name}$]", MyConnection)
        MyCommand.TableMappings.Add("Table", "Net-informations.com")
        DtSet = New System.Data.DataSet
        MyCommand.Fill(DtSet)

        distinct_bio.Clear()

        Saving_InSys()

        Import_BTN.Enabled = False
        Path_TXT.Clear()
        MyConnection.Close()

        Cursor = Cursors.WaitCursor

        SAVE_DIRECT_Attendance() ' ===== DIRECT SAVE TO ATTENDANCE ==== 
        PopulateBiometricSHEET(Bio_grid, Paydate) ' ===== POPULATE DATAGRIDVIEW FROM SHEET ====  
        SavePayout_ALL(Paydate, starting_date, ending_date)

        Cursor = Cursors.Default
    End Sub

    Private Sub Saving_InSys()

        Dim groups_time As New List(Of String)()

        Dim bio_no As String = ""

        progressBarStart(DtSet.Tables(0).Rows.Count)

        For row = 7 To DtSet.Tables(0).Rows.Count + 1
            If eCell(row, 5).Value = Nothing Then
                Continue For
            End If

            Dim list_hour(3) As String

            '=============== BIO NUMBER ================
            If eCell(row, 2).Value <> Nothing Then
                bio_no = eCell(row, 2).Value
            End If

            '======================== GET TIME IN/OUT TO CALCULATE LATE UNDERTIME OVERTIME ============================
            TIME_IN = GetTimeInOut(bio_no).Time_in
            TIME_OUT = GetTimeInOut(bio_no).Time_out

            '=============== GROUP 4 TIME IN ============= 
            For column = 7 To 11
                If eCell(row, column).Value <> Nothing Then
                    groups_time.Add(eCell(row, column).Value)
                End If
            Next

            '=============== CHECK PER CELL IN A ROW ============= 
            For column = 7 To 11
                Dim time As DateTime = (New DateTime()).AddDays(eCell(row, column).Value)

                '============================== WORKED FINE ========================  

                If time = "1/1/0001 12:00:00 AM" Then
                    Continue For
                Else

                    If time >= TIME_IN.AddHours(-3).ToShortTimeString And time <= TIME_IN.AddHours(4).AddMinutes(-1).ToShortTimeString Then
                        If list_hour(0) = "" Then

                            list_hour(0) = time.ToString("t")
                        Else
                            list_hour(1) = time.ToString("t")
                        End If

                    ElseIf time >= TIME_OUT.AddHours(-1).ToShortTimeString Then

                        list_hour(3) = time.ToString("t")

                    ElseIf time >= TIME_IN.AddHours(5).ToShortTimeString And time <= TIME_OUT.AddHours(7).AddMinutes(-1).ToShortTimeString Then
                        If list_hour(2) = "" Then

                            list_hour(2) = time.ToString("t")
                        Else
                            list_hour(3) = time.ToString("t")
                        End If

                    ElseIf (time >= "12:00 PM" And time <= "12:59 PM") OrElse (time >= TIME_IN.AddHours(4).ToShortTimeString And time <= TIME_IN.AddHours(5).AddMinutes(-1).ToShortTimeString) Then

                        Dim newValuee As String = time.TimeOfDay.Hours
                        Dim breaktime As DateTime = TIME_IN.AddHours(4)
                        Dim break = breaktime.TimeOfDay.Hours

                        If time >= "12:00 PM" And time <= "12:59 PM" Then
                            break = "12"
                        End If

                        If newValuee = break Then

                            If CountDate(groups_time, break) >= 2 Then
                                list_Group = SortCountedDATE(groups_time, break)
                            ElseIf CountDate(groups_time, break) = 1 Then
                                list_Group = SortCountedDATE(groups_time, break)
                            End If

                            '======================== PRINT 12 NOON ================ WORKED FINE
                            If list_Group.Count >= 2 Then

                                Dim list1 As DateTime = list_Group.Item(0)
                                Dim list2 As DateTime = list_Group.Item(list_Group.Count - 1)

                                list_hour(1) = list1.ToString("t")
                                list_hour(2) = list2.ToString("t")

                                list_Group.Clear()
                            ElseIf list_Group.Count = 1 Then

                                Dim list1 As DateTime = list_Group.Item(0)

                                list_hour(1) = list1.ToString("t")

                                list_Group.Clear()
                            Else
                                If list_hour(2) = "" Then

                                    list_hour(2) = time.ToString("t")
                                Else
                                    list_hour(3) = time.ToString("t")
                                End If
                            End If

                        End If
                    Else
                        list_hour(1) = time.ToString("t")
                    End If
                End If
            Next

            'If list_hour(1) = "12:00 AM" Then
            '    list_hour(1) = ""
            'End If

            If list_hour(0) = "" And list_hour(1) = "" And list_hour(2) = "" And list_hour(3) = "" Then
            Else

                distinct_bio.Add(bio_no)
                SaveDTR(bio_no, Paydate, eCell(row, 5).Value, list_hour(0), list_hour(1), list_hour(2), list_hour(3))

                frmMainForm.AppProgressBar.Value += 1
            End If

        Next
        progressBarEnd()
    End Sub


    Private Sub bio_OURCOMPANY()
        Try

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

            distinct_bio.Clear()
            list_inOut.Clear()

            progressBarStart(DtSet.Tables(0).Rows.Count)

            For row = 2 To DtSet.Tables(0).Rows.Count
                SaveBiometricSheet(Paydate, eCell(row, 3).Value, eCell(row, 4).Value)
                distinct_bio.Add(eCell(row, 3).Value)

                frmMainForm.AppProgressBar.Value += 1
            Next

            progressBarEnd()

            forLoop_ALL_IMPORTED()   ' ===== SAVE AM_IN, AM_OUT, PM_IN, PM_OUT ====
            SAVE_DIRECT_Attendance() ' ===== DIRECT SAVE TO ATTENDANCE ====
            PopulateBiometricSHEET(Bio_grid, Paydate) ' ===== POPULATE DATAGRIDVIEW FROM SHEET ====
            SavePayout_ALL(Paydate, starting_date, ending_date)

            Path_TXT.Clear()
            MyConnection.Close()

        Catch ex As Exception
            MsgBox("Excel is open or inaccessible!", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub SAVE_DIRECT_Attendance()
        LoadDateTime()
        TempAttendance()

        AM_In_DataGrid.Items.Insert(0, "")
        AM_Out_DataGrid.Items.Insert(0, "")
        PM_IN_DataGrid.Items.Insert(0, "")
        PM_Out_DataGrid.Items.Insert(0, "")

        Dim paydate_ As String = Paydate.ToString("d")

        progressBarStart(distinct_bio.Count)
        For Each biometric_No As String In distinct_bio

            Dim all_date, exist_date, add_date As New List(Of String)()
            '======================== GET TIME IN/OUT TO CALCULATE LATE UNDERTIME OVERTIME ============================ 
            TIME_IN = GetTimeInOut(biometric_No).Time_in
            TIME_OUT = GetTimeInOut(biometric_No).Time_out
            Dim branchCode As String = GetBranchCode(biometric_No)
            '=========================================================================================================

            For Each oRow As DataGridViewRow In DataGridView1.Rows
                oRow.Cells(5).Value = False
                For cell As Integer = 1 To 4
                    oRow.Cells(cell).Value = Nothing
                Next
            Next

            Dim mysql As String = $"Select * From BIOMETRIC_DTR where BIO_ID = '{biometric_No}' and PAYDATE = '{paydate_}'"
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


            SIL_LBL.Text = 0
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

                End If

                CalculateLATE(row, TIME_IN, biometric_No, branchCode)

                CalculateuNDERTIME(row, TIME_IN, TIME_OUT, biometric_No, branchCode)

                CalculateuOVERTIME(row, TIME_OUT)

            Next

            '===================================== SUM UP LATE ==================================== 
            Dim Late_Total As TimeSpan = New TimeSpan(0, 0, 0, 0, 0)
            For Each valueE As TimeSpan In late_count
                Late_Total = Late_Total + valueE
            Next

            late_count.Clear()

            '===================================== SUM UP UNDERTIME ==================================== 
            Dim Under_Total As TimeSpan = New TimeSpan(0, 0, 0, 0, 0)
            For Each value As TimeSpan In under_count
                Under_Total = Under_Total + value
            Next

            under_count.Clear()

            '===================================== SUM UP PRESENT AND ABSENT ==================================== 
            Dim Present As Integer = 0
            For Each oRow As DataGridViewRow In DataGridView1.Rows

                If oRow.Cells(5).Value = True Then
                    Present += 1
                End If
            Next

            TotalDays_LBL.Text = Present

            '===================================== SUM UP HALF DAY ====================================  
            Dim halfday_Hour As Integer = 0
            For Each oRow As DataGridViewRow In DataGridView1.Rows

                If CountCELL_Nothing(oRow) = 3 Or CountCELL_Consecutive(oRow) = "HALFDAY" Then
                    halfday_Hour += 4
                End If
            Next

            Dim product As Double
            product = ((Convert.ToInt32(TotalDays_LBL.Text) * 8)) - halfday_Hour
            product = product / 8
            TotalDays_LBL.Text = product

            SaveAttendanceEE(biometric_No, paydate_, TotalDays_LBL.Text, TotalOTHr_LBL.Text, Late_Total.ToString, Under_Total.ToString,
                             TotalRHoliday_LBL.Text, TotalSHoliday_LBL.Text)

            InsertTempAttendance(biometric_No, paydate_, TotalDays_LBL.Text, TotalOTHr_LBL.Text,
                                    Late_Total.ToString, Under_Total.ToString, TotalRHoliday_LBL.Text, TotalSHoliday_LBL.Text)

            frmMainForm.AppProgressBar.Value += 1
        Next

        progressBarEnd()
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
        Name_TXT.Tag = Bio_grid.Item(1, i).Tag

        If Paydate_ComboB.SelectedIndex < 0 Then
            paydate_ = Paydate.ToString("d")
        Else
            paydate_ = Paydate_ComboB.SelectedItem
        End If

        DataGridView1.ClearSelection()
        GetAttendance_Manual(Bio_grid.Item(0, i).Value, paydate_, DataGridView1,
                                    TotalDays_LBL, TotalRHoliday_LBL, TotalSHoliday_LBL, TotalLateHR_LBL, TotalUTHR_LBL, TotalOTHr_LBL)
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

    Private Sub Paydate_ComboB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Paydate_ComboB.SelectedIndexChanged

        If Paydate_ComboB.SelectedIndex >= 0 Then
            paydate_ = Paydate_ComboB.SelectedItem
        Else
            paydate_ = Paydate.ToString("d")
        End If

        PopulateBiometricSHEET(Bio_grid, paydate_)

        Dim datee As DateTime = paydate_
        LoadDateTime(datee)

        AM_In_DataGrid.Items.Insert(0, "")
        AM_Out_DataGrid.Items.Insert(0, "")
        PM_IN_DataGrid.Items.Insert(0, "")
        PM_Out_DataGrid.Items.Insert(0, "")
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
            SIL_Panel.Visible = False

            For Each oRow As DataGridViewRow In DataGridView1.Rows
                oRow.Cells(5).Value = False
                For cell As Integer = 1 To 4
                    oRow.Cells(cell).Value = Nothing
                Next
            Next

        Else
            GetName(BiometricID_TXT.Text, Name_TXT)

            Get_SIL(BiometricID_TXT.Text, SIL_LBL)

            If Not Name_TXT.Text = String.Empty Then
                TIME_IN = GetTime_In(BiometricID_TXT.Text)
                TIME_OUT = GetTime_Out(BiometricID_TXT.Text)

                TimeIn_TXT.Text = TIME_IN.ToShortTimeString
                TimeOut_TXT.Text = TIME_OUT.ToShortTimeString
            End If


            If Not Name_TXT.Text = "" Then

                For Each oRow As DataGridViewRow In DataGridView1.Rows
                    oRow.Cells(5).Value = False
                    For cell As Integer = 1 To 4
                        oRow.Cells(cell).Value = Nothing
                    Next
                Next

                Attendance_Per_Employee(BiometricID_TXT.Text)
            End If

            '==========================  CHECK PAYDATE IF VALID FOR EDITING =========================   
            If Paydate_ComboB.SelectedIndex >= 0 Then
                If Paydate_ComboB.Text = frmMainForm.Paydate.ToString("d") Then
                    Save_BTN.Enabled = True
                Else
                    Save_BTN.Enabled = False
                End If
            Else
                Save_BTN.Enabled = True
            End If
        End If

    End Sub

    Public Sub Attendance_Per_Employee(bioNo As String)
        Dim PAYROLL As String
        If Paydate_ComboB.SelectedIndex >= 0 Then
            PAYROLL = Paydate_ComboB.SelectedItem
        Else
            PAYROLL = DataGridView1.Tag
        End If

        Dim mysql As String = $"Select * From BIOMETRIC_DTR A inner join PAYROLL_ATTENDANCE B on B.BIOMETRICID = A.BIO_ID  and A.PAYDATE = B.PAYDATE where A.BIO_ID = '{bioNo}' and A.PAYDATE = '{PAYROLL}'"
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

                        TotalDays_LBL.Text = .Item("PRESENT_DAYS")
                        TotalRHoliday_LBL.Text = .Item("REGHOLIDAY")
                        TotalSHoliday_LBL.Text = .Item("SPECHOLIDAY")
                        TotalLateHR_LBL.Text = IIf(IsDBNull(.Item("LATE")), "00:00:00", .Item("LATE"))
                        TotalUTHR_LBL.Text = IIf(IsDBNull(.Item("UNDERTIME")), "00:00:00", .Item("UNDERTIME"))
                        TotalOTHr_LBL.Text = .Item("OVERTIME")

                        Save_BTN.Tag = "UPDATE"
                    End With
                Next
            Else
                ClearAfter()
                Save_BTN.Tag = "NEW"
            End If
        End Using

    End Sub

    Private Sub ClearAfter()
        CheckALL_CheckBox.Checked = False
        SIL_LBL.Text = 0
        TotalDays_LBL.Text = 0
        TotalRHoliday_LBL.Text = 0
        TotalSHoliday_LBL.Text = 0
        TotalLateHR_LBL.Text = 0
        TotalUTHR_LBL.Text = 0
        TotalOTHr_LBL.Text = 0
    End Sub

    Private Sub LoadDTR()

        SIL_LBL.Text = 0
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

    Private Sub Seven_Grid_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Seven_Grid.MouseDoubleClick
        Bio7_TXT.Text = Seven_Grid.CurrentRow.Cells(0).Value
        Emp7_TXT.Text = Seven_Grid.CurrentRow.Cells(1).Value
        Days7_TXT.Text = Seven_Grid.CurrentRow.Cells(2).Value
        Overtime7_TXT.Text = Seven_Grid.CurrentRow.Cells(3).Value
        Late7_TXT.Text = Seven_Grid.CurrentRow.Cells(4).Value
        Undertime7_TXT.Text = Seven_Grid.CurrentRow.Cells(5).Value
        Night7_TXT.Text = Seven_Grid.CurrentRow.Cells(6).Value
    End Sub

    Public Sub Load_Attendance(emp As Employee, empNo As Integer)
        With emp
            If empNo = 1 Then
                Bio1_DTR_TXT.Text = .BiometricID
                Bio1_DTR_TXT.Tag = .BranchID
                DTR_Emp1_TXT.Text = .Fullname
                DTR_Emp1_TXT.Tag = .EMP_ID
                Attendance_Tab.SelectedIndex = 3
                Employee_RadioB.Checked = True
            ElseIf empNo = 2 Then
                Bio2_DTR_TXT.Text = .BiometricID
                Bio2_DTR_TXT.Tag = .BranchID
                DTR_Emp2_TXT.Text = .Fullname
                DTR_Emp2_TXT.Tag = .EMP_ID
                Attendance_Tab.SelectedIndex = 3
                Employee_RadioB.Checked = True
            ElseIf empNo = 3 Then
                BiometricID_TXT.Text = .BiometricID
                Branch_Name = .BranchID
                Name_TXT.Text = .Fullname
                Name_TXT.Tag = .EMP_ID
                Attendance_Tab.SelectedIndex = 1
            ElseIf empNo = 4 Then
                Bio7_TXT.Text = .BiometricID
                Emp7_TXT.Text = .Fullname
                Emp7_TXT.Tag = .EMP_ID
                Attendance_Tab.SelectedIndex = 2
            End If
        End With
    End Sub


End Class