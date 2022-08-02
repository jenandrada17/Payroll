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
    Dim late_count, under_count, over_count As New TimeSpan
    Dim list_dateHour, list_inOut, list_hourMin, list_Group, list_count, list_bio, distinct_bio As New List(Of String)()
    Dim hourMinn, timee, bio_list As List(Of String)
    Dim dateee, starting_date, ending_date, TIME_IN, TIME_OUT As DateTime
    Dim DATE_ONLY, am_in, am_out, pm_in, pm_out As String
    Public branchID, Branch_Name, paydate_, paydate_Records As String
    Dim MyConnection As System.Data.OleDb.OleDbConnection
    Dim DtSet As System.Data.DataSet
    Dim MyCommand As System.Data.OleDb.OleDbDataAdapter
    Dim ALLOW_OT As Boolean = True

    Private Sub frmAttendance_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LoadDateTime()

        PIDays_lbl.Text = GetData_Decimal("NO_OF_DAYS", $"PAYROLL_PI_DAYS WHERE PAYDATE='{Paydate.ToString("d")}'")

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

        If IsLastDay(Paydate.ToString("d")) Then PI_Panel.Visible = True

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
            paydate_ = Paydate
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
            paydate_ = Paydate
            starting_date = StartFour.AddDays(1)
            ending_date = EndFour

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

        '==============================================AM IN 5AM to 1PM==================================================
        For y = 0 To 1440

            Dim myDate = New DateTime(CurrD.Year, CurrD.Month, CurrD.Day, 5, 0, 0, 0).AddMinutes(y)
            AM_In_DataGrid.Items.Add(myDate.ToString("t"))

        Next

        '==============================================AM OUT 8AM to 6PM==================================================
        For y = 0 To 1440

            Dim myDate = New DateTime(CurrD.Year, CurrD.Month, CurrD.Day, 8, 0, 0, 0).AddMinutes(y)
            AM_Out_DataGrid.Items.Add(myDate.ToString("t"))

        Next

        '==============================================PM IN 12AM to 7PM==================================================
        For y = 0 To 1440

            Dim myDate = New DateTime(CurrD.Year, CurrD.Month, CurrD.Day, 12, 0, 0, 0).AddMinutes(y)
            PM_IN_DataGrid.Items.Add(myDate.ToString("t"))

        Next

        '==============================================PM OUT 12PM to 11PM==================================================
        For y = 0 To 1440

            Dim myDate = New DateTime(CurrD.Year, CurrD.Month, CurrD.Day, 12, 0, 0, 0).AddMinutes(y)
            PM_Out_DataGrid.Items.Add(myDate.ToString("t"))

        Next

        For i = 0 To DataGridView1.Rows.Count - 1

            Dim r As DataGridViewRow = DataGridView1.Rows(i)
            r.Height = 28

            Dim asss As Date = DataGridView1.Rows(i).Cells(0).Value

            Dim customizeDate As String = asss.ToString("M")

            If asss.DayOfWeek = DayOfWeek.Sunday Then r.DefaultCellStyle.ForeColor = Color.Red

            If HolidayExist(asss) Then
                HolidayDetails(asss, i, DataGridView1)
                r.DefaultCellStyle.ForeColor = Color.Black
            End If

        Next

        AM_In_DataGrid.Items.Insert(0, "")
        AM_Out_DataGrid.Items.Insert(0, "")
        PM_IN_DataGrid.Items.Insert(0, "")
        PM_Out_DataGrid.Items.Insert(0, "")

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

    End Sub

    ''========= TEMPORARY FOR PAYDATE 6/30/2022 ===========  
    'Dim temp_present As Double = 0
    'Dim temp_half As Double = 0
    'Dim temp_overtime As Double = 0
    'Dim temp_late As Double = 0
    'Dim temp_undertime As Double = 0

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Calculate_BTN.Click
        If Name_TXT.Text <> Nothing Then
            TotalDays_LBL.Text = 0
            TotalRHoliday_LBL.Text = 0
            TotalSHoliday_LBL.Text = 0
            TotalLateHR_LBL.Text = 0
            TotalUTHR_LBL.Text = 0
            TotalOTHr_LBL.Text = 0
            under_count = New TimeSpan(0, 0, 0, 0, 0)
            late_count = New TimeSpan(0, 0, 0, 0, 0)

            Dim bioNum = BiometricID_TXT.Text
            Dim branchCode = GetBranchCode(bioNum)
            Dim dateStarted = GetData("DATE_STARTED", $"PAYROLL_EMPLOYEE WHERE BIO_NO = '{bioNum}'")

            For Each row As DataGridViewRow In DataGridView1.Rows

                Dim DATEE As DateTime = row.Tag

                If Not row.DefaultCellStyle.ForeColor = Color.Red Then

                    '================================= CALCULATE HOLIDAYS  ===============================
                    If row.DefaultCellStyle.BackColor = Color.MediumOrchid Then

                        If DATEE >= dateStarted Then
                            TotalRHoliday_LBL.Text = TotalRHoliday_LBL.Text + 1
                        End If

                    ElseIf row.DefaultCellStyle.BackColor = Color.Plum Then

                        If Paydate_ComboB.SelectedIndex >= 0 Then paydate_ = Paydate_ComboB.Text '======= IF PAYDATE SELECTED IN BIOMETRIC

                        If PRESENT_Date(bioNum, paydate_, row.Cells(0).Tag) Then
                            If row.Cells(0).Tag >= dateStarted Then
                                TotalSHoliday_LBL.Text = TotalSHoliday_LBL.Text + 1
                            End If
                        End If

                    End If
                End If

                '======================== GET TIME IN/OUT TO CALCULATE LATE UNDERTIME OVERTIME ============================ 

                If CheckData("BIO_NO", $"PAYROLL_SCHEDULE WHERE BIO_NO = '{bioNum}'") Then

                    If DateExist_IN_Schedule(bioNum, DATEE.ToShortDateString) Then
                        Dim timeIN, timeOut As DateTime
                        If DateTime.TryParse(GetData("TIME_IN", $"PAYROLL_SCHEDULE WHERE BIO_NO = '{bioNum}' AND DATEE = '{DATEE.ToShortDateString}' "), timeIN) Then
                            TIME_IN = timeIN
                        Else
                            Continue For
                        End If

                        If DateTime.TryParse(GetData("TIME_OUT", $"PAYROLL_SCHEDULE WHERE BIO_NO = '{bioNum}' AND DATEE = '{DATEE.ToShortDateString}' "), timeOut) Then
                            TIME_OUT = timeOut

                            If TIME_OUT > TIME_IN.AddHours(9) Then
                                TIME_OUT = TIME_IN.AddHours(9)
                                ALLOW_OT = True
                            Else
                                ALLOW_OT = False
                            End If
                        Else
                            Continue For
                        End If

                    Else
                        TIME_IN = GetData("VALUEE", $"PAYROLL_DEFAULT_TIMEIN")
                        TIME_OUT = TIME_IN.AddHours(9)
                    End If

                Else
                    TIME_IN = GetTimeInOut(bioNum).Time_in
                    TIME_OUT = GetTimeInOut(bioNum).Time_out
                End If

                CalculateLATE(row, TIME_IN)

                CalculateuNDERTIME(row, TIME_IN, TIME_OUT)

                CalculateuOVERTIME(row, TIME_OUT)

                ''===========================  TEMPORARYYYYYYY JUNE 30, 2022 ONLY===================== 
                'If paydate_ = "6/30/2022" Then
                '    Dim short_date As String = DATEE.ToShortDateString
                '    If short_date = "6/8/2022" Then
                '        temp_overtime = TotalOTHr_LBL.Text
                '        temp_late = late_count.TotalMinutes
                '        temp_undertime = under_count.TotalMinutes
                '    End If
                'End If

            Next

            TotalLateHR_LBL.Text = late_count.TotalMinutes

            TotalUTHR_LBL.Text = under_count.TotalMinutes

            TotalOTHr_LBL.Text = CDbl(TotalOTHr_LBL.Text) + AM_OT_NUP.Value

            '===================================== SUM UP PRESENT AND ABSENT ==================================== 
            Dim Present As Integer = 0
            Dim halfday_Hour As Integer = 0
            For Each oRow As DataGridViewRow In DataGridView1.Rows

                If oRow.Cells(5).Value = True Then
                    Present += 1
                End If

                If CountCELL_Nothing(oRow) = 3 Or CountCELL_Consecutive(oRow) = "HALFDAY" Then
                    halfday_Hour += 4
                End If

                ''===========================  TEMPORARYYYYYYY JUNE 30, 2022 ONLY===================== 
                'If paydate_ = "6/30/2022" Then
                '    Dim DATEE As DateTime = oRow.Tag
                '    Dim short_date As String = DATEE.ToShortDateString
                '    If short_date = "6/8/2022" Then
                '        temp_present = Present
                '        temp_half = halfday_Hour
                '    End If
                'End If

            Next

            TotalDays_LBL.Text = Present

            '===================================== SUM UP HALF DAY ====================================  
            'Dim halfday_Hour As Integer = 0
            'For Each oRow As DataGridViewRow In DataGridView1.Rows

            '    If CountCELL_Nothing(oRow) = 3 Or CountCELL_Consecutive(oRow) = "HALFDAY" Then
            '        halfday_Hour += 4
            '    End If
            'Next

            Dim product As Double
            product = ((Convert.ToInt32(TotalDays_LBL.Text) * 8)) - halfday_Hour
            product = product / 8
            TotalDays_LBL.Text = product

            ''===================================== TEMPORARYYYYYYY =================================  
            'If paydate_ = "6/30/2022" Then
            '    Dim old_days As Double
            '    old_days = (temp_present * 8) - temp_half
            '    old_days = old_days / 8
            '    Dim new_days As Double = product - old_days
            '    Dim new_overtime As Double = CDbl(TotalOTHr_LBL.Text) - temp_overtime
            '    Dim new_late As Double = CDbl(late_count.TotalMinutes) - temp_late
            '    Dim new_undertime As Double = CDbl(under_count.TotalMinutes) - temp_undertime
            '    SaveTemporary(bioNum, old_days, new_days, temp_overtime, new_overtime, temp_late, new_late, temp_undertime, new_undertime)
            'End If

            late_count = New TimeSpan(0, 0, 0, 0, 0)
            under_count = New TimeSpan(0, 0, 0, 0, 0)
        Else
            MsgBox("Please Enter Employee's Name.", MsgBoxStyle.Critical, "Error")
        End If

    End Sub

    Private Sub CalculateLATE(row As DataGridViewRow, timeIn As DateTime)
        '================================  CELL NUMBER AM IN =================================== 
        If Not row.Cells(1).Value = Nothing Then

            Dim lateHour As TimeSpan = DateTime.Parse(row.Cells(1).Value).Subtract(DateTime.Parse(timeIn.ToShortTimeString))

            Dim cellValue As DateTime = row.Cells(1).Value
            Dim limit As DateTime = (timeIn.AddMinutes(-1)).ToShortTimeString

            If cellValue > limit Then
                late_count += lateHour
            End If

        End If

        ''================================  CELL NUMBER PM IN =================================== 
        'If Not row.Cells(3).Value = Nothing Then
        '    Dim lateHour As TimeSpan = DateTime.Parse(row.Cells(3).Value).Subtract(DateTime.Parse(timeIn.AddHours(5).ToShortTimeString))

        '    Dim cellValue As DateTime = row.Cells(3).Value
        '    Dim limit As DateTime = (timeIn.AddMinutes(-1)).ToShortTimeString

        '    If cellValue > limit Then
        '        late_count += lateHour
        '    End If

        'End If

    End Sub

    Private Sub CalculateuNDERTIME(row As DataGridViewRow, timeIn As DateTime, timeOut As DateTime)
        '=================================  CELL NUMBER PM OUT ==================================== 
        If Not row.Cells(4).Value = Nothing Then

            'Dim _out As DateTime = DateTime.Parse(row.Cells(4).Value).Subtract(New TimeSpan(0, DateTime.Parse(row.Cells(4).Value).Minute, 0))  
            'Dim _timeOut As DateTime = timeOut.ToShortTimeString 
            'Dim underHour As TimeSpan = _timeOut.Subtract(_out.ToShortTimeString)

            Dim convert_out As DateTime = DateTime.Parse(row.Cells(4).Value)
            Dim orig_outt As TimeSpan = New TimeSpan(timeOut.Hour, timeOut.Minute, 0)
            Dim outt As TimeSpan = New TimeSpan(convert_out.Hour, convert_out.Minute, 0)

            Dim underHour As TimeSpan = orig_outt - outt

            Dim cellValue As DateTime = row.Cells(4).Value
            Dim limit As DateTime = timeOut.ToShortTimeString

            If cellValue < limit Then
                under_count += underHour
            End If

        End If
    End Sub

    Private Sub CalculateuOVERTIME(row As DataGridViewRow, timeOut As DateTime)
        '====================================  CELL NUMBER PM OUT ==================================== 
        If Not row.Cells(4).Value = Nothing Then
            If ALLOW_OT = True Then
                Dim OTHour As TimeSpan = DateTime.Parse(row.Cells(4).Value).Subtract(DateTime.Parse(timeOut.ToShortTimeString))

                If OTHour.Hours > 0 Then
                    TotalOTHr_LBL.Text = CDbl(TotalOTHr_LBL.Text) + OTHour.Hours

                    If OTHour.Minutes >= 30 Then
                        TotalOTHr_LBL.Text = CDbl(TotalOTHr_LBL.Text) + 0.5
                    End If
                End If
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
        AM_OT_NUP.Text = 0
        CheckALL_CheckBox.Checked = False
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
            Calculate_BTN.PerformClick()
            Dim result As DialogResult = MsgBox($"Record for {Name_TXT.Text} will be Save/Updated, proceed anyway?", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then

                Dim PAYROLL As String
                Dim specHoliday_hrs As Double = 0
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

                        '============================== TOTAL SPECIAL HOLIDAY BASE ON TOTAL HOURS OF DUTY ====================
                        If DataeXIST($" PAYROLL_HOLIDAY WHERE DATEE = '{dateOnly.ToString("MMMM d")}' AND KINDS = 'SPECIAL'") Then

                            Dim list_ As New List(Of String)
                            list_.Add(row.Cells(1).Value)
                            list_.Add(row.Cells(2).Value)
                            list_.Add(row.Cells(3).Value)
                            list_.Add(row.Cells(4).Value)
                            list_ = list_.Where(Function(s) Not String.IsNullOrEmpty(s)).ToList()

                            specHoliday_hrs += GetSpecial_hrs(list_.First, list_.Last)

                            If specHoliday_hrs > 8 Then
                                specHoliday_hrs = 8
                            End If
                        End If
                    End If
                Next

                SaveAttendanceEE(BiometricID_TXT.Text, PAYROLL, TotalDays_LBL.Text, TotalOTHr_LBL.Text, TotalLateHR_LBL.Text, TotalUTHR_LBL.Text,
                                 TotalRHoliday_LBL.Text, TotalSHoliday_LBL.Text, specHoliday_hrs, SIL_LBL.Text, AM_OT_NUP.Value)

                SavePayout_IndividualL(BiometricID_TXT.Text, PAYROLL, starting_date, ending_date)

                SaveLogs($"{Save_BTN.Tag} ATTENDANCE ({Name_TXT.Text} ({BiometricID_TXT.Text})) - Days({TotalDays_LBL.Text}), OT({TotalOTHr_LBL.Text}), Late({TotalLateHR_LBL.Text}), Undertime({TotalUTHR_LBL.Text}), R/S Holiday({TotalRHoliday_LBL.Text}/{TotalSHoliday_LBL.Text}), SIL({SIL_LBL.Text})", frmMainForm.UserName_LBL.Text)

                Cancel_BTN.PerformClick()

                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Information")
            End If
        Else
            MsgBox("Please Choose Employee's Name!", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    Private Sub OT_BTN_Click(sender As Object, e As EventArgs) Handles OT_BTN.Click
        TotalOTHr_LBL.Text = 0
    End Sub

    Private Sub Late_BTN_Click(sender As Object, e As EventArgs) Handles Late_BTN.Click
        TotalLateHR_LBL.Text = 0
    End Sub

    Private Sub UT_BTN_Click(sender As Object, e As EventArgs) Handles UT_BTN.Click
        TotalUTHR_LBL.Text = 0
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Paydate_ComboB.SelectedIndex > 0 Then
            PopulateBiometricSHEET(Biometric_LV, Paydate_ComboB.SelectedItem)
        Else
            PopulateBiometricSHEET(Biometric_LV, Paydate)
        End If
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
                            Dim OT = .Item("OVERTIME")
                            Dim LATE = .Item("LATE")
                            Dim UNDERTIME As String = .Item("UNDERTIME")
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

            '=========================== LIST OF BIO (COMPLETE DATE) ==========================
            LIST_BIOO.Clear()
            LIST_BIOO = ListOfBio(LIST_BIOO, mysqll)
            LIST_BIOO = LIST_BIOO.Distinct().ToList
            '=========================== SAVING ALL DATE ====================================== 
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
                            Dim OT As String = .Item("OVERTIME")
                            Dim LATE As String = .Item("LATE")
                            Dim UNDERTIME As String = .Item("UNDERTIME")
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

        Dim group_Empty, group_Save As New List(Of String)()

        Dim paydate_ As String = Paydate.ToString("d")
        distinct_bio = distinct_bio.Distinct().ToList

        progressBarStart(distinct_bio.Count)
        For i = 0 To distinct_bio.Count - 1
            Dim biometric_No As String = distinct_bio(i)
            list_inOut.Clear()

            '======================== TO REPLACE EXISTING RECORD ========================================================
            If ThisHasRow($"BIOMETRIC_DTR where BIO_ID = '{biometric_No}' and PAYDATE = '{paydate_}'") Then Replacing($"BIOMETRIC_DTR where BIO_ID = '{biometric_No}' and PAYDATE = '{paydate_}';")
            '======================== GET TIME IN/OUT TO CALCULATE LATE UNDERTIME OVERTIME ============================

            Dim mysql As String = $"Select DATEANDTIME From IMPORT_DTR where BIO_ID = '{biometric_No}' and PAYDATE = '{paydate_}'"
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

            list_inOut = list_inOut.Distinct().ToList

            For Each row As DataGridViewRow In DataGridView1.Rows

                Dim list_hour(3) As String
                Dim DATE_ONLY As String = ""

                Dim rowIndex As Integer = row.Index
                Dim asss As DateTime = DataGridView1.Rows(rowIndex).Tag
                Dim groups_timee As New List(Of String)()

                For x = 0 To list_inOut.Count - 1
                    If list_inOut(x).StartsWith(asss.ToString("d")) Then
                        groups_timee.Add(list_inOut(x))
                    End If
                Next

                '========================================= TIME IN/OUT ========================================= 
                Dim DATEE As DateTime = row.Tag

                If CheckData("BIO_NO", $"PAYROLL_SCHEDULE WHERE BIO_NO = '{biometric_No}'") Then
                    Dim timeIn As DateTime
                    If DateExist_IN_Schedule(biometric_No, DATEE.ToShortDateString) Then

                        If DateTime.TryParse(GetData("TIME_IN", $"PAYROLL_SCHEDULE WHERE BIO_NO = '{biometric_No}' AND DATEE = '{DATEE.ToShortDateString}'  "), timeIn) Then
                            TIME_IN = timeIn
                            TIME_OUT = timeIn.AddHours(9)
                        Else
                            Continue For
                        End If

                    Else

                        TIME_IN = GetData("VALUEE", $"PAYROLL_DEFAULT_TIMEIN")
                        TIME_OUT = TIME_IN.AddHours(9)

                    End If

                Else
                    TIME_IN = GetTime_In(biometric_No)
                    TIME_OUT = GetTime_Out(biometric_No)
                End If

                Dim new_list(3) As String

                If groups_timee.Count > 0 Then

                    groups_timee = groups_timee.Distinct.ToList

                    For y = 0 To groups_timee.Count - 1

                        Dim dateTime As DateTime = groups_timee(y)
                        Dim time As DateTime = dateTime.ToString("t")

                        DATE_ONLY = dateTime.ToString("d")

                        If time >= TIME_IN.AddHours(-3).ToShortTimeString And time <= TIME_IN.AddHours(3).AddMinutes(-1).ToShortTimeString Then
                            If new_list(0) = "" Then

                                new_list(0) = time.ToString("t")
                            ElseIf new_list(1) = "" Then
                                new_list(1) = time.ToString("t")
                            Else
                                new_list(2) = time.ToString("t")
                            End If

                        ElseIf time >= TIME_OUT.AddHours(-1).ToShortTimeString Then

                            new_list(3) = time.ToString("t")

                        ElseIf (time >= "12:00 PM" And time <= "12:59 PM") Or (time >= TIME_IN.AddHours(4).ToShortTimeString And time <= TIME_IN.AddHours(5).AddMinutes(-1).ToShortTimeString) Then

                            If new_list(1) = "" Then
                                new_list(1) = time.ToString("t")
                            ElseIf new_list(1) <> "" And new_list(2) <> "" Then
                                new_list(3) = time.ToString("t")
                            Else
                                new_list(2) = time.ToString("t")
                            End If

                        Else

                            If new_list(1) = "" Then
                                new_list(1) = time.ToString("t")
                            ElseIf new_list(1) <> "" And new_list(2) <> "" Then
                                new_list(3) = time.ToString("t")
                            Else
                                new_list(2) = time.ToString("t")
                            End If
                        End If
                    Next

                    '=================== IF DISARRANGE BLANKS =================
                    If new_list(0) = "" And new_list(1) <> "" And new_list(2) = "" And new_list(3) <> "" Then '== IF (0101)
                        new_list(2) = new_list(1)
                        new_list(1) = ""
                    ElseIf new_list(0) <> "" And new_list(1) = "" And new_list(2) <> "" And new_list(3) = "" Then '== IF  (1010)
                        Dim timeDiff As TimeSpan = DateTime.Parse(new_list(2)).Subtract(DateTime.Parse(new_list(0)))
                        If timeDiff.Hours > 5 Then
                            new_list(3) = new_list(2)
                            new_list(2) = ""
                        Else
                            new_list(1) = new_list(2)
                            new_list(2) = ""
                        End If
                    ElseIf new_list(0) <> "" And new_list(1) <> "" And new_list(2) = "" And new_list(3) = "" Then '== IF  (1100)
                        Dim timeDiff As TimeSpan = DateTime.Parse(new_list(1)).Subtract(DateTime.Parse(new_list(0)))
                        If timeDiff.Hours > 5 Then
                            new_list(3) = new_list(1)
                            new_list(1) = ""
                        End If
                    End If

                    distinct_bio.Add(biometric_No)
                    SaveDTR(biometric_No, Paydate, DATE_ONLY, new_list(0), new_list(1), new_list(2), new_list(3))
                End If
            Next

            frmMainForm.AppProgressBar.Value += 1
        Next
        progressBarEnd()

    End Sub

    Private Sub Search_BTN_Click(sender As Object, e As EventArgs) Handles Search_BTN.Click
        PopulateBiometricSHEET(Biometric_LV, Paydate, Search_TXT.Text)
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

            SaveLogs($"SENT DTR BY BRANCH ({DTR_Branch_Combo.Text}) PAYROLL({Payslip_DTR_Combo})", frmMainForm.UserName_LBL.Text)
        Else
            MsgBox("Please Click Preview before Sending", MsgBoxStyle.Exclamation, "INVALID")
        End If
    End Sub

    Private Sub SearchEmp7_BTN_Click(sender As Object, e As EventArgs) Handles SearchEmp7_BTN.Click
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
    End Sub

    Private Sub Bio7_TXT_TextChanged(sender As Object, e As EventArgs) Handles Bio7_TXT.TextChanged

        Dim PAYROLL As String
        If Paydate7_CB.SelectedIndex >= 0 Then
            PAYROLL = Paydate7_CB.SelectedItem
        Else
            PAYROLL = DataGridView1.Tag
        End If

        If Not String.IsNullOrEmpty(Bio7_TXT.Text) Then

            GetName(Bio7_TXT.Text, Emp7_TXT)
            GetAttendance_Shifting(Bio7_TXT.Text, PAYROLL)

            '==========================  CHECK PAYDATE IF VALID FOR EDITING =========================   
            If Paydate7_CB.SelectedIndex >= 0 Then
                If Paydate7_CB.Text = frmMainForm.Paydate.ToString("d") Then
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

                        Late7_TXT.Text = .Item("LATE")
                        Undertime7_TXT.Text = .Item("UNDERTIME")

                        Night7_TXT.Text = IIf(IsDBNull(.Item("NIGHT_RATE")), "", .Item("NIGHT_RATE"))
                        SIL7_NUP.Text = IIf(IsDBNull(.Item("SIL")), "", .Item("SIL"))

                    End With
                Next

                Save7_BTN.Tag = "UPDATED"
            Else

                Days7_TXT.Clear()
                Overtime7_TXT.Clear()
                Late7_TXT.Clear()
                Undertime7_TXT.Clear()
                Night7_TXT.Clear()
                SIL7_NUP.TextAlign = 0
                Save7_BTN.Tag = "ADDED"
            End If
        End Using
    End Sub

    Private Sub Save7_BTN_Click(sender As Object, e As EventArgs) Handles Save7_BTN.Click
        If Not Bio7_TXT.Text = "" And Not Days7_TXT.Text = "" Then

            Dim result As DialogResult = MsgBox($"Record for {Emp7_TXT.Text} will be Save/Updated, proceed anyway?", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then

                Dim PAYROLL As String
                If Paydate7_CB.SelectedIndex >= 0 Then
                    PAYROLL = Paydate7_CB.SelectedItem
                Else
                    PAYROLL = DataGridView1.Tag
                End If

                '======================== HOLIDAY ============================ 
                Dim RHOLIDAY As Integer = REGHolidayCount(starting_date, ending_date)
                Dim SHOLIDAY As Integer = SPECHolidayCount(starting_date, ending_date)
                Dim latee As Integer = IIf(Late7_TXT.Text = Nothing, 0, Late7_TXT.Text)
                Dim undertimee As Integer = IIf(Undertime7_TXT.Text = Nothing, 0, Undertime7_TXT.Text)
                Dim night7 As Integer = IIf(Night7_TXT.Text = Nothing, 0, Night7_TXT.Text)
                Dim specHoliday_hrs As Double = 0

                SaveAttendanceEE(Bio7_TXT.Text, PAYROLL, Days7_TXT.Text, Overtime7_TXT.Text, latee, undertimee,
                             RHOLIDAY, SHOLIDAY, specHoliday_hrs, SIL7_NUP.Text, 0, night7)

                SavePayout_IndividualL(Bio7_TXT.Text, PAYROLL, starting_date, ending_date)

                SaveLogs($"{Save7_BTN.Tag} ATTENDANCE ({Emp7_TXT.Text} ({Bio7_TXT.Text})) - Days({Days7_TXT.Text}), OT({Overtime7_TXT.Text}), Late({Late7_TXT.Text}), Undertime({Undertime7_TXT.Text}), R/S Holiday({TotalRHoliday_LBL.Text}/{TotalSHoliday_LBL.Text}), Night Rate({Night7_TXT.Text}), SIL({SIL7_NUP.Text})", frmMainForm.UserName_LBL.Text)

                Cancel7_BTN.PerformClick()

                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Information")
            End If

        Else
            MsgBox("Please Ensure that Employee's Name and No. of days are inputed!", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    Private Sub Hours7_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Undertime7_TXT.KeyPress, Overtime7_TXT.KeyPress, Night7_TXT.KeyPress, Late7_TXT.KeyPress, Days7_TXT.KeyPress
        If e.KeyChar <> ChrW(Keys.Back) Then
            If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
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

                    If Count_SIL(BiometricID_TXT.Text) < 5 Then
                        SIL_Panel.Visible = True
                        SIL_Panel.Location = New Point(SIL_BTN.Location.X - 160, SIL_BTN.Location.Y - 10)
                    Else
                        MsgBox($"Already reached the maximum number of SIL for this year.", MsgBoxStyle.Critical, "Invalid")
                    End If

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

    Private Sub AddSIL_BTN_Click(sender As Object, e As EventArgs) Handles AddSIL_BTN.Click
        SIL_LBL.Text = SIL_NUP.Text
        SIL_BTN.Text = "Clear"
        SIL_Panel.Visible = False
    End Sub

    Private Sub Biometric_LV_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Biometric_LV.MouseDoubleClick
        CheckALL_CheckBox.Checked = False

        If Biometric_LV.Items.Count = 0 Then Exit Sub
        BiometricID_TXT.Text = Biometric_LV.Items(Biometric_LV.FocusedItem.Index).SubItems(0).Text

        Attendance_Tab.SelectedIndex = 1
    End Sub

    Private Sub PIDaysX_btn_Click(sender As Object, e As EventArgs) Handles PIDaysX_btn.Click
        P_Add_Panel.Visible = False
        PI_Days.Value = 0.0
    End Sub

    Private Sub AddPIDays_btn_Click_1(sender As Object, e As EventArgs) Handles AddPIDays_btn.Click
        If P_Add_Panel.Visible = True Then
            P_Add_Panel.Visible = False
            PI_Days.Value = 0.0
        Else
            P_Add_Panel.Visible = True
            PI_Days.Value = PIDays_lbl.Text
        End If
    End Sub

    Private Sub PIDaysCheck_btn_Click(sender As Object, e As EventArgs) Handles PIDaysCheck_btn.Click
        Dim result As DialogResult = MsgBox("Additional days will be save for PI calculation, proceed anyway?", MsgBoxStyle.YesNo)
        If result = DialogResult.Yes Then
            PIDays_lbl.Text = PI_Days.Value
            Dim paydatee As String = Paydate.ToShortDateString
            SavePI_Additional_Days(PI_Days.Value, paydatee)
        End If

        P_Add_Panel.Visible = False
    End Sub

    Private Sub Cancel_lbl_Click(sender As Object, e As EventArgs) Handles Cancel_lbl.Click
        AM_OT_NUP.Value = 0.0
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

    Private Sub Import_BTN_Click(sender As Object, e As EventArgs) Handles Import_BTN.Click

        '=====================  ORIGIINAL ==============================
        eApp = New Excel.Application
        eBook = eApp.Workbooks.Open(Path_TXT.Text)
        eSheet = eBook.Worksheets(1)
        eCell = eSheet.UsedRange

        Dim FirstColumn As String = eCell(2, 1).Value

        Has_Rows_Delete("IMPORT_DTR") '===== EMPTY THIS TABLE

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

        For row = 1 To DtSet.Tables(0).Rows.Count + 1
            If eCell(row, 1).Value <> Nothing And eCell(row, 2).Value <> Nothing Then
                If IsNumeric(eCell(row, 1).Value) Then

                    SaveBiometricSheet(Paydate, eCell(row, 1).Value, eCell(row, 2).Value)
                    distinct_bio.Add(eCell(row, 1).Value)

                    frmMainForm.AppProgressBar.Value += 1
                Else
                    MsgBox("row 1 Column 1 is empty or not a valid Biometric No.!", MsgBoxStyle.Exclamation)
                End If
            End If
        Next

        progressBarEnd()

        forLoop_ALL_IMPORTED()   ' ===== SAVE AM_IN, AM_OUT, PM_IN, PM_OUT ====
        SAVE_DIRECT_Attendance() ' ===== DIRECT SAVE TO ATTENDANCE ==== 
        PopulateBiometricSHEET(Biometric_LV, Paydate) ' ===== POPULATE DATAGRIDVIEW FROM SHEET ==== 
        SavePayout_ALL(Paydate, starting_date, ending_date)

        Import_BTN.Enabled = False
        Path_TXT.Clear()
        MyConnection.Close()
        eBook.Close()
        eApp.Quit()

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
        eBook.Close()
        eApp.Quit()

        SAVE_DIRECT_Attendance() ' ===== DIRECT SAVE TO ATTENDANCE ==== 
        PopulateBiometricSHEET(Biometric_LV, Paydate) ' ===== POPULATE DATAGRIDVIEW FROM SHEET ====  
        SavePayout_ALL(Paydate, starting_date, ending_date)
    End Sub

    Private Sub Saving_InSys()

        Dim bio_no As String = ""

        progressBarStart(DtSet.Tables(0).Rows.Count)

        For row = 7 To DtSet.Tables(0).Rows.Count + 1

            Dim groups_time, list_hour As New List(Of String)()

            '=============== BIO NUMBER ================
            If eCell(row, 2).Value <> Nothing Then
                bio_no = eCell(row, 2).Value
                If ThisHasRow($"BIOMETRIC_DTR where BIO_ID = '{bio_no}' and PAYDATE = '{Paydate.ToShortDateString}'") Then Replacing($"BIOMETRIC_DTR where BIO_ID = '{bio_no}' and PAYDATE = '{Paydate.ToShortDateString}';") 'TO REPLACE EXISTING RECORD =========================
            End If

            '======================== GET TIME IN/OUT TO CALCULATE LATE UNDERTIME OVERTIME ============================
            If eCell(row, 3).Value <> Nothing Then

                Dim DATEE As DateTime = eCell(row, 3).Value

                If CheckData("BIO_NO", $"PAYROLL_SCHEDULE WHERE BIO_NO = '{bio_no}'") Then

                    If DateExist_IN_Schedule(bio_no, DATEE.ToShortDateString) Then
                        Dim valuee_in As String = GetData("TIME_IN", $"PAYROLL_SCHEDULE WHERE BIO_NO = '{bio_no}' AND DATEE = '{DATEE.ToShortDateString}' ")

                        If valuee_in = "RD" Or valuee_in = "AL" Or valuee_in = "SIL" Then

                            TIME_IN = GetData("VALUEE", $"PAYROLL_DEFAULT_TIMEIN")
                            TIME_OUT = TIME_IN.AddHours(9)

                        Else
                            TIME_IN = GetData("TIME_IN", $"PAYROLL_SCHEDULE WHERE BIO_NO = '{bio_no}' AND DATEE = '{DATEE.ToShortDateString}' ")
                            TIME_OUT = TIME_IN.AddHours(9)
                        End If

                    Else
                        TIME_IN = GetData("VALUEE", $"PAYROLL_DEFAULT_TIMEIN")
                        TIME_OUT = TIME_IN.AddHours(9)
                    End If

                Else
                    TIME_IN = GetTimeInOut(bio_no).Time_in
                    TIME_OUT = GetTimeInOut(bio_no).Time_out
                End If
            End If

            '=============== GROUP 4 TIME IN ============= 
            For column = 6 To 11
                If eCell(row, column).Value <> Nothing Then
                    Dim VALUEE, TIMEEE As New DateTime

                    VALUEE = eCell(row, 3).Value
                    TIMEEE = DateTime.FromOADate(eCell(row, column).Value)

                    groups_time.Add(VALUEE.Add(TIMEEE.TimeOfDay))
                End If
            Next

            '=============== CHECK PER CELL IN A ROW ============= 
            For column = 5 To 11
                Dim time As DateTime = (New DateTime()).AddDays(eCell(row, column).Value)

                '============================== WORKED FINE ========================   
                If time = "1/1/0001 12:00:00 AM" Then

                    list_hour = list_hour.Distinct.ToList

                    If list_hour.Count > 0 Then

                        Dim new_list(3) As String

                        For i = 0 To list_hour.Count - 1
                            Dim _time As DateTime = CDate(list_hour(i))
                            If _time >= TIME_IN.AddHours(-3).ToShortTimeString And _time <= TIME_IN.AddHours(3).AddMinutes(-1).ToShortTimeString Then
                                If new_list(0) = "" Then

                                    new_list(0) = _time.ToString("t")
                                Else
                                    new_list(1) = _time.ToString("t")
                                End If

                            ElseIf _time >= TIME_OUT.AddHours(-1).ToShortTimeString Then

                                new_list(3) = _time.ToString("t")

                            ElseIf (_time >= "12:00 PM" And _time <= "12:59 PM") Or (_time >= TIME_IN.AddHours(4).ToShortTimeString And _time <= TIME_IN.AddHours(5).AddMinutes(-1).ToShortTimeString) Then

                                If new_list(1) = "" Then
                                    new_list(1) = _time.ToString("t")
                                ElseIf new_list(1) <> "" And new_list(2) <> "" Then
                                    new_list(3) = _time.ToString("t")
                                Else
                                    new_list(2) = _time.ToString("t")
                                End If

                            Else

                                If new_list(1) = "" Then
                                    new_list(1) = _time.ToString("t")
                                ElseIf new_list(1) <> "" And new_list(2) <> "" Then
                                    new_list(3) = _time.ToString("t")
                                Else
                                    new_list(2) = _time.ToString("t")
                                End If

                            End If

                        Next

                        '=================== IF DISARRANGE BLANKS =================
                        If new_list(0) = "" And new_list(1) <> "" And new_list(2) = "" And new_list(3) <> "" Then '== IF (0101)
                            new_list(2) = new_list(1)
                            new_list(1) = ""
                        ElseIf new_list(0) <> "" And new_list(1) = "" And new_list(2) <> "" And new_list(3) = "" Then '== IF  (1010)
                            Dim timeDiff As TimeSpan = DateTime.Parse(new_list(2)).Subtract(DateTime.Parse(new_list(0)))
                            If timeDiff.Hours > 5 Then
                                new_list(3) = new_list(2)
                                new_list(2) = ""
                            Else
                                new_list(1) = new_list(2)
                                new_list(2) = ""
                            End If
                        ElseIf new_list(0) <> "" And new_list(1) <> "" And new_list(2) = "" And new_list(3) = "" Then '== IF  (1100)
                            Dim timeDiff As TimeSpan = DateTime.Parse(new_list(1)).Subtract(DateTime.Parse(new_list(0)))
                            If timeDiff.Hours > 5 Then
                                new_list(3) = new_list(1)
                                new_list(1) = ""
                            End If
                        End If

                        distinct_bio.Add(bio_no)
                        SaveDTR(bio_no, Paydate, eCell(row, 3).Value, new_list(0), new_list(1), new_list(2), new_list(3))

                    End If

                    Exit For
                Else

                    list_hour.Add(time.ToString("t"))

                End If
            Next

            frmMainForm.AppProgressBar.Value += 1
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

            For row = 1 To DtSet.Tables(0).Rows.Count
                'For row = 1 To DtSet.Tables(0).Rows.Count + 1
                If IsNumeric(eCell(row, 3).Value) Then
                    SaveBiometricSheet(Paydate, eCell(row, 3).Value, eCell(row, 4).Value)
                    distinct_bio.Add(eCell(row, 3).Value)

                    frmMainForm.AppProgressBar.Value += 1
                Else
                    MsgBox("Row 1 Column 1 is empty or not a valid Biometric No.!", MsgBoxStyle.Exclamation)
                End If
            Next

            progressBarEnd()

            forLoop_ALL_IMPORTED()   ' ===== SAVE AM_IN, AM_OUT, PM_IN, PM_OUT ====
            SAVE_DIRECT_Attendance() ' ===== DIRECT SAVE TO ATTENDANCE ====
            PopulateBiometricSHEET(Biometric_LV, Paydate) ' ===== POPULATE DATAGRIDVIEW FROM SHEET ====
            SavePayout_ALL(Paydate, starting_date, ending_date)

            Path_TXT.Clear()
            MyConnection.Close()
            eBook.Close()
            eApp.Quit()

        Catch ex As Exception
            MsgBox("Excel is open or inaccessible!" & vbNewLine & ex.ToString, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub SAVE_DIRECT_Attendance()
        LoadDateTime()
        TempAttendance()

        Dim paydate_ As String = Paydate.ToString("d")

        '======================== HOLIDAY ============================ 
        Dim RHOLIDAY As Integer = REGHolidayCount(starting_date, ending_date)
        Dim SHOLIDAY As Integer = SPECHolidayCount(starting_date, ending_date)

        distinct_bio = distinct_bio.Distinct.ToList

        progressBarStart(distinct_bio.Count)
        For Each biometric_No As String In distinct_bio

            Dim all_date, exist_date, add_date As New List(Of String)()

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

            TotalDays_LBL.Text = 0
            SIL_LBL.Text = 0
            TotalLateHR_LBL.Text = 0
            TotalUTHR_LBL.Text = 0
            TotalOTHr_LBL.Text = 0
            late_count = New TimeSpan(0, 0, 0, 0, 0)
            under_count = New TimeSpan(0, 0, 0, 0, 0)

            Dim Present As Integer = 0
            Dim halfday_Hour As Integer = 0
            Dim specHoliday_hrs As Double = 0

            ''========= TEMPORARY FOR PAYDATE 6/30/2022 ===========  
            'Dim temp_present As Double = 0
            'Dim temp_half As Double = 0
            'Dim temp_overtime As Double = 0
            'Dim temp_late As Double = 0
            'Dim temp_undertime As Double = 0

            For Each row As DataGridViewRow In DataGridView1.Rows

                '======================== GET TIME IN/OUT TO CALCULATE LATE UNDERTIME OVERTIME ============================ 
                Dim DATEE As DateTime = row.Tag

                If CheckData("BIO_NO", $"PAYROLL_SCHEDULE WHERE BIO_NO = '{biometric_No}'") Then

                    If DateExist_IN_Schedule(biometric_No, DATEE.ToShortDateString) Then

                        Try

                            Dim timeIN, timeOut As DateTime
                            If DateTime.TryParse(GetData("TIME_IN", $"PAYROLL_SCHEDULE WHERE BIO_NO = '{biometric_No}' AND DATEE = '{DATEE.ToShortDateString}' "), timeIN) Then
                                TIME_IN = timeIN
                            Else
                                Continue For
                            End If

                            If DateTime.TryParse(GetData("TIME_OUT", $"PAYROLL_SCHEDULE WHERE BIO_NO = '{biometric_No}' AND DATEE = '{DATEE.ToShortDateString}' "), timeOut) Then
                                TIME_OUT = timeOut

                                If TIME_OUT > TIME_IN.AddHours(9) Then
                                    TIME_OUT = TIME_IN.AddHours(9)
                                    ALLOW_OT = True
                                Else
                                    ALLOW_OT = False
                                End If
                            Else
                                Continue For
                            End If

                        Catch ex As Exception
                            MsgBox("invalid " & ex.ToString)
                        End Try

                    Else
                        TIME_IN = GetData("VALUEE", $"PAYROLL_DEFAULT_TIMEIN")
                        TIME_OUT = TIME_IN.AddHours(9)
                    End If

                Else
                    TIME_IN = GetTimeInOut(biometric_No).Time_in
                    TIME_OUT = GetTimeInOut(biometric_No).Time_out
                End If

                '============================== TOTAL SPECIAL HOLIDAY BASE ON TOTAL HOURS OF DUTY ==================== 
                If DataeXIST($" PAYROLL_HOLIDAY WHERE DATEE = '{DATEE.ToString("MMMM d")}' AND KINDS = 'SPECIAL'") Then

                    If DataeXIST($" PAYROLL_SCHEDULE WHERE BIO_NO = '{biometric_No}' AND DATEE = '{DATEE.ToShortDateString}'") Then
                        Dim list_ As New List(Of String)
                        list_.Add(row.Cells(1).Value)
                        list_.Add(row.Cells(2).Value)
                        list_.Add(row.Cells(3).Value)
                        list_.Add(row.Cells(4).Value)
                        list_ = list_.Where(Function(s) Not String.IsNullOrEmpty(s)).ToList()

                        specHoliday_hrs += GetSpecial_hrs(list_.First, list_.Last)

                        If specHoliday_hrs > 8 Then
                            specHoliday_hrs = 8
                        End If
                    End If

                End If

                CalculateLATE(row, TIME_IN)

                CalculateuNDERTIME(row, TIME_IN, TIME_OUT)

                CalculateuOVERTIME(row, TIME_OUT)

                ''===================================== SUM UP PRESENT AND ABSENT =================== 
                If row.Cells(5).Value = True Then
                    Present += 1
                End If

                ''===================================== SUM UP HALF DAY ============================= 
                If CountCELL_Nothing(row) = 3 Or CountCELL_Consecutive(row) = "HALFDAY" Then
                    halfday_Hour += 4
                End If

                ''===========================  TEMPORARYYYYYYY JUNE 30, 2022 ONLY===================== 
                'If paydate_ = "6/30/2022" Then
                '    Dim short_date As String = DATEE.ToShortDateString
                '    If short_date = "6/8/2022" Then
                '        temp_present = Present
                '        temp_half = halfday_Hour
                '        temp_overtime = TotalOTHr_LBL.Text
                '        temp_late = late_count.TotalMinutes
                '        temp_undertime = under_count.TotalMinutes
                '    End If
                'End If

            Next

            TotalDays_LBL.Text = Present

            Dim product As Double
            product = ((Convert.ToInt32(TotalDays_LBL.Text) * 8)) - halfday_Hour
            product = product / 8
            TotalDays_LBL.Text = product

            SaveAttendanceEE(biometric_No, paydate_, TotalDays_LBL.Text, TotalOTHr_LBL.Text, late_count.TotalMinutes, under_count.TotalMinutes,
                             RHOLIDAY, SHOLIDAY, specHoliday_hrs, 0)

            InsertTempAttendance(biometric_No, paydate_, TotalDays_LBL.Text, TotalOTHr_LBL.Text,
                                    late_count.TotalMinutes, under_count.TotalMinutes, RHOLIDAY, SHOLIDAY)

            ''===================================== TEMPORARYYYYYYY =================================  
            'If paydate_ = "6/30/2022" Then
            '    Dim old_days As Double
            '    old_days = (temp_present * 8) - temp_half
            '    old_days = old_days / 8
            '    Dim new_days As Double = product - old_days
            '    Dim new_overtime As Double = CDbl(TotalOTHr_LBL.Text) - temp_overtime
            '    Dim new_late As Double = CDbl(late_count.TotalMinutes) - temp_late
            '    Dim new_undertime As Double = CDbl(under_count.TotalMinutes) - temp_undertime
            '    SaveTemporary(biometric_No, old_days, new_days, temp_overtime, new_overtime, temp_late, new_late, temp_undertime, new_undertime)
            'End If

            frmMainForm.AppProgressBar.Value += 1
        Next

        progressBarEnd()
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

        PopulateBiometricSHEET(Biometric_LV, paydate_)

        Dim datee As DateTime = paydate_
        LoadDateTime(datee)

        PIDays_lbl.Text = GetData_Decimal("NO_OF_DAYS", $"PAYROLL_PI_DAYS WHERE PAYDATE='{paydate_}'")

        '==========================  CHECK PAYDATE IF VALID FOR EDITING =========================   
        If Today.ToString("d") > CDate(paydate_) Then
            AddPIDays_btn.Enabled = False
        Else
            AddPIDays_btn.Enabled = True
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

    Private Sub DataGridView1_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError
        '========================= Need para di magERROR ang Datagrid==============
    End Sub

    Private Sub BiometricID_TXT_TextChanged(sender As Object, e As EventArgs) Handles BiometricID_TXT.TextChanged

        Dim PAYROLL As String
        If Paydate_ComboB.SelectedIndex >= 0 Then
            PAYROLL = Paydate_ComboB.SelectedItem
        Else
            PAYROLL = DataGridView1.Tag
        End If

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

            SIL_LBL.Text = Get_SIL("PAYROLL_ATTENDANCE", $"PAYROLL_ATTENDANCE WHERE BIOMETRICID = '{BiometricID_TXT.Text}' AND PAYDATE = '{PAYROLL}'") + Get_SIL("PAYROLL_SCHED_COUNT", $"PAYROLL_SCHED_COUNT WHERE BIO_NO = '{BiometricID_TXT.Text}' AND PAYDATE = '{PAYROLL}'")

            If Not Name_TXT.Text = String.Empty Then
                TIME_IN = GetTime_In(BiometricID_TXT.Text)
                TIME_OUT = GetTime_Out(BiometricID_TXT.Text)

                TimeIn_TXT.Text = TIME_IN.ToShortTimeString
                TimeOut_TXT.Text = TIME_OUT.ToShortTimeString
            End If

            If Not Name_TXT.Text = "" Then
                Attendance_Per_Employee(BiometricID_TXT.Text, PAYROLL)
            End If

            '==========================  CHECK PAYDATE IF VALID FOR EDITING =========================   
            If Today.ToString("d") > CDate(PAYROLL) Then
                Save_BTN.Enabled = False
            Else
                Save_BTN.Enabled = True
            End If

        End If

    End Sub

    Public Sub Attendance_Per_Employee(bioNo As String, PAYROLL As String)

        For Each oRow As DataGridViewRow In DataGridView1.Rows
            oRow.Cells(5).Value = False
            For cell As Integer = 1 To 4
                oRow.Cells(cell).Value = Nothing
            Next
        Next

        Dim mysql As String = $"Select * From BIOMETRIC_DTR where BIO_ID = '{bioNo}' and PAYDATE = '{PAYROLL}'"
        Using ds As DataSet = LoadSQL(mysql, "BIOMETRIC_DTR")
            If ds.Tables(0).Rows.Count > 0 Then

                progressBarStart(ds.Tables(0).Rows.Count)
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
                                Exit For
                            End If

                        Next
                    End With

                    frmMainForm.AppProgressBar.Value += 1
                Next
                progressBarEnd()
            End If
        End Using

        Dim mysqlL As String = $"Select * From  PAYROLL_ATTENDANCE where BIOMETRICID = '{bioNo}' and PAYDATE = '{PAYROLL}'"
        Using dsS As DataSet = LoadSQL(mysqlL, "PAYROLL_ATTENDANCE")
            If dsS.Tables(0).Rows.Count > 0 Then

                progressBarStart(dsS.Tables(0).Rows.Count)
                For Each drR In dsS.Tables(0).Rows
                    With drR

                        TotalDays_LBL.Text = .Item("PRESENT_DAYS")
                        TotalRHoliday_LBL.Text = .Item("REGHOLIDAY")
                        TotalSHoliday_LBL.Text = .Item("SPECHOLIDAY")
                        TotalLateHR_LBL.Text = .Item("LATE")
                        TotalUTHR_LBL.Text = .Item("UNDERTIME")
                        TotalOTHr_LBL.Text = .Item("OVERTIME")
                        AM_OT_NUP.Value = IIf(IsDBNull(.Item("MORNING_OT")), 0, .Item("MORNING_OT"))

                    End With
                Next

                Save_BTN.Tag = "UPDATED"
            Else
                ClearAfter()
                Save_BTN.Tag = "ADDED"
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

    Private Sub Seven_Grid_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Seven_Grid.MouseDoubleClick
        Bio7_TXT.Text = Seven_Grid.CurrentRow.Cells(0).Value
        Emp7_TXT.Text = Seven_Grid.CurrentRow.Cells(1).Value
        Days7_TXT.Text = Seven_Grid.CurrentRow.Cells(2).Value
        Overtime7_TXT.Text = IIf(Seven_Grid.CurrentRow.Cells(3).Value = Nothing, 0, Seven_Grid.CurrentRow.Cells(3).Value)
        Night7_TXT.Text = IIf(Seven_Grid.CurrentRow.Cells(6).Value = Nothing, 0, Seven_Grid.CurrentRow.Cells(6).Value)

        If Seven_Grid.CurrentRow.Cells(4).Value <> Nothing Then Late7_TXT.Text = TimeSpan.Parse(Seven_Grid.CurrentRow.Cells(4).Value).TotalMinutes
        If Seven_Grid.CurrentRow.Cells(5).Value <> Nothing Then Undertime7_TXT.Text = TimeSpan.Parse(Seven_Grid.CurrentRow.Cells(5).Value).TotalMinutes

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