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

    '========= TEMPORARY FOR PAYDATE 6/30/2022 (CHANGED MINIMUM RATE) ===========  
    Dim temp_present As Double = 0
    Dim temp_half As Double = 0
    Dim temp_overtime As Double = 0
    Dim temp_late As Double = 0
    Dim temp_undertime As Double = 0
    Dim temp_Rholiday As Double = 0
    Dim temp_Sholiday As Double = 0

    '========= COUNT DAYS OF LATE TO APPLY LATE_DEDUCTION MULTIPLICATION =========
    Dim Late_days As Double = 0
    Dim Late_applied As Boolean = False
    Dim Late_percentage As String = Nothing
    Dim Late_total As Integer = 0
    Dim Late_approved As Integer = 0

    Private Sub frmAttendance_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LoadDateTime()

        PIDays_lbl.Text = GetData_Decimal("HO_NO_OF_DAYS", $"PAYROLL_PI_DAYS WHERE PAYDATE='{Paydate.ToString("d")}'")
        B_PIDays_lbl.Text = GetData_Decimal("BRANCH_NO_OF_DAYS", $"PAYROLL_PI_DAYS WHERE PAYDATE='{Paydate.ToString("d")}'")

        AM_In_DataGrid.Items.Insert(0, "")
        AM_Out_DataGrid.Items.Insert(0, "")
        PM_IN_DataGrid.Items.Insert(0, "")
        PM_Out_DataGrid.Items.Insert(0, "")

        DataGridView1.ClearSelection()

        CheckALL_CheckBox.Checked = True

        PopulateComboBox(Paydate_ComboB, "BIOMETRIC_DTR", "PAYDATE", True)
        PopulateComboBox(Payslip_DTR_Combo, "BIOMETRIC_DTR", "PAYDATE", True)
        PopulateComboBox(DTR_Branch_Combo, "TBL_EMPLOYEE", "BRANCHCODE")
        PopulateComboBox(Paydate7_CB, "BIOMETRIC_DTR", "PAYDATE", True)
        PopulateBiometricSHEET(Branch_LV, Paydate, True)
        PopulateBiometricSHEET(Biometric_LV, Paydate)

        If IsLastDay(Paydate.ToString("d")) Then
            PI_Panel.Visible = True
            B_PI_Panel.Visible = True
        End If

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

        If TypeOf DataGridView1.CurrentCell Is DataGridViewComboBoxCell Then '========== IF EMPTY ROW 
            Dim row As DataGridViewRow = DataGridView1.Rows(DataGridView1.CurrentRow.Index)

            If row.Cells(1).Value = Nothing And row.Cells(2).Value = Nothing And row.Cells(3).Value = Nothing And row.Cells(4).Value = Nothing Then
                row.Cells(5).Value = False
            End If
        End If


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

    Private Sub CalculateLATE(row As DataGridViewRow, timeIn As DateTime)
        '================================  CELL NUMBER AM IN =================================== 
        If Not row.Cells(1).Value = Nothing Then

            Dim lateHour As TimeSpan = DateTime.Parse(row.Cells(1).Value).Subtract(DateTime.Parse(timeIn.ToShortTimeString))

            Dim cellValue As DateTime = row.Cells(1).Value
            Dim limit As DateTime = (timeIn).ToShortTimeString

            If cellValue > limit Then
                late_count += lateHour

                row.Cells(1).Tag = lateHour.TotalMinutes

                '========= COUNT DAYS OF LATE TO APPLY LATE_DEDUCTION MULTIPLICATION =========
                Late_days += 1
                If Late_days >= 3 And late_count.TotalMinutes > 120 Then
                    Late_applied = True
                End If
            End If

        End If

    End Sub

    Private Sub CalculateuNDERTIME(row As DataGridViewRow, timeIn As DateTime, timeOut As DateTime)
        '=================================  CELL NUMBER PM OUT ==================================== 
        If Not row.Cells(4).Value = Nothing Then

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

    Private Sub ClearSIL()
        SIL_LBL.Text = 0
        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.DefaultCellStyle.BackColor = Color.Aquamarine Or row.DefaultCellStyle.BackColor = Color.MediumAquamarine Then
                row.DefaultCellStyle.BackColor = Color.Empty
                row.Cells(2).Tag = 0
            End If
        Next
    End Sub

    Private Sub Cancel_BTN_Click(sender As Object, e As EventArgs) Handles Cancel_BTN.Click

        BiometricID_TXT.Clear()
        Name_TXT.Clear()
        TotalDays_LBL.Text = 0
        TotalRHoliday_LBL.Text = 0
        TotalSHoliday_LBL.Text = 0
        TotalLateHR_LBL.Text = 0
        TotalUTHR_LBL.Text = 0
        TotalOTHr_LBL.Text = 0
        AM_OT_NUP.Text = 0
        CheckALL_CheckBox.Checked = False
        cbPresentPrevNextWorkingDay.Checked = False
        ClearSIL()

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
                Dim specHoliday_hrs As Integer = 0
                If Paydate_ComboB.SelectedIndex >= 0 Then
                    PAYROLL = Paydate_ComboB.SelectedItem
                Else
                    PAYROLL = DataGridView1.Tag
                End If

                If ThisHasRow($"BIOMETRIC_DTR where BIO_ID = '{BiometricID_TXT.Text}' and PAYDATE = '{PAYROLL}'") Then
                    Replacing($"BIOMETRIC_DTR where BIO_ID = '{BiometricID_TXT.Text}' and PAYDATE = '{PAYROLL}';")
                End If

                If ThisHasRow($"PAYROLL_SIL where BIONO = '{BiometricID_TXT.Text}' and PAYDATE = '{PAYROLL}'") Then
                    Replacing($"PAYROLL_SIL where BIONO = '{BiometricID_TXT.Text}' and PAYDATE = '{PAYROLL}';")
                End If

                For Each row As DataGridViewRow In DataGridView1.Rows

                    Dim dateOnly As DateTime = DataGridView1.Rows(row.Index).Tag

                    If row.Cells(1).Value = "" And row.Cells(2).Value = "" And row.Cells(3).Value = "" And row.Cells(4).Value = "" Then
                    Else

                        '============================ LATE APPROVED ================================
                        Dim LateApproved As Boolean = False
                        If row.Cells(1).Style.ForeColor = Color.Blue Then LateApproved = True

                        SaveDTR(BiometricID_TXT.Text, Paydate, dateOnly.ToString("d"),
                            row.Cells(1).Value, row.Cells(2).Value, row.Cells(3).Value, row.Cells(4).Value, LateApproved, row.Cells(1).Tag)

                        '============================== TOTAL SPECIAL HOLIDAY BASE ON TOTAL HOURS OF DUTY ====================
                        If DataeXIST($" PAYROLL_HOLIDAY WHERE DATEE = '{dateOnly.ToString("MMMM d")}' AND KINDS = 'SPECIAL'") Then

                            Dim list_ As New List(Of String)
                            list_.Add(row.Cells(1).Value)
                            list_.Add(row.Cells(2).Value)
                            list_.Add(row.Cells(3).Value)
                            list_.Add(row.Cells(4).Value)
                            list_ = list_.Where(Function(s) Not String.IsNullOrEmpty(s)).ToList()

                            'specHoliday_hrs
                            Dim hrs As Integer = GetSpecial_hrs(list_.First, list_.Last, BiometricID_TXT.Text)
                            specHoliday_hrs += hrs
                        End If
                    End If


                    'IF SIL
                    'Dim silCount As Double = 0
                    'If row.Cells(2).Tag IsNot Nothing AndAlso IsNumeric(row.Cells(2).Tag) Then
                    '    silCount = CDbl(row.Cells(2).Tag)
                    'End If

                    If CDbl(row.Cells(2).Tag) > 0 Then
                        SaveSIL(BiometricID_TXT.Text, CDate(row.Tag).ToString("d"), CDbl(row.Cells(2).Tag), Paydate)
                    End If
                Next

                '===================================== MINIMUM CHANGED =================================
                If ThisHasRow($"CHANGE_MINIMUM_RATE WHERE PAYDATE = '{paydate_}'") AndAlso ThisHasRow($"TBL_EMPLOYEE WHERE BIOMETRICID = '{BiometricID_TXT.Text}' AND MINIMUM_RATE_UPDATED_AT = '{paydate_}'") Then
                    Dim old_days As Double
                    old_days = (temp_present * 8) - temp_half
                    old_days = old_days / 8
                    Dim new_days As Double = CDbl(TotalDays_LBL.Text) - old_days
                    Dim new_overtime As Double = CDbl(TotalOTHr_LBL.Text) - temp_overtime
                    Dim new_late As Double = CDbl(TotalLateHR_LBL.Text) - temp_late
                    Dim new_undertime As Double = CDbl(TotalUTHR_LBL.Text) - temp_undertime
                    SaveTemporary(BiometricID_TXT.Text, old_days, new_days, temp_overtime, new_overtime, temp_late, new_late, temp_undertime, new_undertime, temp_Rholiday, temp_Sholiday, PAYROLL)
                End If

                '========== FOR EXCEEDING DAYS OF LATE (MORE THAN 2 DAYS OF LATE THIS WILL APPLIED) ==========
                If Late_applied = True Then
                    Dim total_latee As Integer = CInt(TotalLateHR_LBL.Text) - Late_approved
                    Late_percentage = LatePercentage(BiometricID_TXT.Text, PAYROLL, total_latee)
                Else
                    Late_percentage = Nothing
                End If

                SaveAttendanceEE(BiometricID_TXT.Text, PAYROLL, TotalDays_LBL.Text, TotalOTHr_LBL.Text, TotalLateHR_LBL.Text, TotalUTHR_LBL.Text,
                                 TotalRHoliday_LBL.Text, TotalSHoliday_LBL.Text, specHoliday_hrs, SIL_LBL.Text, Late_percentage, Late_approved, AM_OT_NUP.Value, TotalRHoliday_LBL.Tag)

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

                    mysqll = $"Select A.*, B.BIOMETRICID as bioNo, B.TIME_IN, B.TIME_OUT, C.*,
                                        LASTNAME || ', ' || FIRSTNAME || 
                                        CASE
                                            WHEN MIDDLENAME IS NOT NULL AND MIDDLENAME <> '' THEN ' ' || LEFT(MIDDLENAME, 1) || '.' 
                                            ELSE ''
                                        END || 
                                        CASE 
                                            WHEN SUFFIX IS NOT NULL AND SUFFIX <> '' THEN ' ' || SUFFIX
                                            ELSE ''
                                        END AS FULLNAME 
                                        From PAYROLL_ATTENDANCE A 
                                        inner JOIN TBL_EMPLOYEE B ON B.BIOMETRICID = A.BIOMETRICID 
                                        inner join BIOMETRIC_DTR C ON C.BIO_ID = A.BIOMETRICID AND C.PAYDATE  = A.PAYDATE where A.PAYDATE  = '{paydatee}' and A.BIOMETRICID IN ('{Bio1_DTR_TXT.Text}','{Bio2_DTR_TXT.Text}') ORDER BY DATE_ONLY"

                    LIST_BIOO.Clear()
                    LIST_BIOO.Add(Bio1_DTR_TXT.Text)
                    LIST_BIOO.Add(Bio2_DTR_TXT.Text)
                Else
                    If Bio1_DTR_TXT.Text <> Nothing And Bio2_DTR_TXT.Text = Nothing Then  '============ 1ST EMPLOYEE

                        mysqll = $"Select A.*, B.BIOMETRICID as bioNo, B.TIME_IN, B.TIME_OUT, C.*,
                                        LASTNAME || ', ' || FIRSTNAME || 
                                        CASE
                                            WHEN MIDDLENAME IS NOT NULL AND MIDDLENAME <> '' THEN ' ' || LEFT(MIDDLENAME, 1) || '.' 
                                            ELSE ''
                                        END || 
                                        CASE 
                                            WHEN SUFFIX IS NOT NULL AND SUFFIX <> '' THEN ' ' || SUFFIX
                                            ELSE ''
                                        END AS FULLNAME   
                                        From PAYROLL_ATTENDANCE A 
                                        inner JOIN TBL_EMPLOYEE B ON B.BIOMETRICID = A.BIOMETRICID 
                                        inner join BIOMETRIC_DTR C ON C.BIO_ID = A.BIOMETRICID AND C.PAYDATE  = A.PAYDATE where A.PAYDATE  = '{paydatee}' and A.BIOMETRICID = '{Bio1_DTR_TXT.Text}'  ORDER BY DATE_ONLY  ASC"

                        LIST_BIOO.Clear()
                        LIST_BIOO.Add(Bio1_DTR_TXT.Text)
                    ElseIf Bio2_DTR_TXT.Text <> Nothing And Bio1_DTR_TXT.Text = Nothing Then '============ 2ND EMPLOYEE

                        mysqll = $"Select A.*, B.BIOMETRICID as bioNo,  B.TIME_IN, B.TIME_OUT, C.*,
                                        LASTNAME || ', ' || FIRSTNAME || 
                                        CASE
                                            WHEN MIDDLENAME IS NOT NULL AND MIDDLENAME <> '' THEN ' ' || LEFT(MIDDLENAME, 1) || '.' 
                                            ELSE ''
                                        END || 
                                        CASE 
                                            WHEN SUFFIX IS NOT NULL AND SUFFIX <> '' THEN ' ' || SUFFIX
                                            ELSE ''
                                        END AS FULLNAME 
                                        From PAYROLL_ATTENDANCE A 
                                        inner JOIN TBL_EMPLOYEE B ON B.BIOMETRICID = A.BIOMETRICID 
                                        inner join BIOMETRIC_DTR C ON C.BIO_ID = A.BIOMETRICID  AND C.PAYDATE  = A.PAYDATE where A.PAYDATE  = '{paydatee}' and A.BIOMETRICID = '{Bio2_DTR_TXT.Text}'  ORDER BY DATE_ONLY  ASC"

                        LIST_BIOO.Clear()
                        LIST_BIOO.Add(Bio2_DTR_TXT.Text)

                    Else
                        MsgBox("Please Select Employee Name!")
                    End If
                End If

            ElseIf HO_RadioB.Checked Then    '=========================== HEAD OFFICE ==================================

                mysqll = $"Select A.*, B.BIOMETRICID as bioNo, B.TIME_IN, B.TIME_OUT, C.*,
                                        LASTNAME || ', ' || FIRSTNAME || 
                                        CASE
                                            WHEN MIDDLENAME IS NOT NULL AND MIDDLENAME <> '' THEN ' ' || LEFT(MIDDLENAME, 1) || '.' 
                                            ELSE ''
                                        END || 
                                        CASE 
                                            WHEN SUFFIX IS NOT NULL AND SUFFIX <> '' THEN ' ' || SUFFIX
                                            ELSE ''
                                        END AS FULLNAME 
                                        From PAYROLL_ATTENDANCE A 
                                        inner JOIN TBL_EMPLOYEE B ON B.BIOMETRICID = A.BIOMETRICID 
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
                    SaveDTR(VALUE_BIO, paydatee, OtherD, Nothing, Nothing, Nothing, Nothing, False, True)
                Next

            Next
            '==============================================================================  

            Using ds As DataSet = LoadSQL(mysqll, "PAYROLL_ATTENDANCE")
                If ds.Tables(0).Rows.Count > 0 Then
                    progressBarStart(ds.Tables(0).Rows.Count)
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

                            frmMainForm.AppProgressBar.Value += 1
                        End With
                    Next
                    progressBarEnd()
                End If
            End Using

            Dim rds_DTR As New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", RemoveDuplicateRows(dt_DTR))
            RptViewer_DTR.LocalReport.DataSources.Add(rds_DTR)
            RptViewer_DTR.RefreshReport()

        Catch ex As Exception
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Function RemoveDuplicateRows(ByRef rDataTable As DataTable)
        Dim pNewDataTable As DataTable
        Dim pCurrentRowCopy As DataRow
        Dim pColumnList As New List(Of String)
        Dim pColumn As DataColumn

        'Build column list
        For Each pColumn In rDataTable.Columns
            pColumnList.Add(pColumn.ColumnName)
        Next

        'Filter by all columns
        pNewDataTable = rDataTable.DefaultView.ToTable(True, pColumnList.ToArray)

        rDataTable = rDataTable.Clone

        'Import rows into original table structure
        For Each pCurrentRowCopy In pNewDataTable.Rows
            rDataTable.ImportRow(pCurrentRowCopy)
        Next

        Return rDataTable
    End Function

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

            mysqll = $"Select A.*, C.*, 
                        LASTNAME || ', ' || FIRSTNAME || 
                        CASE
                            WHEN MIDDLENAME IS NOT NULL AND MIDDLENAME <> '' THEN ' ' || LEFT(MIDDLENAME, 1) || '.' 
                            ELSE ''
                        END || 
                        CASE 
                            WHEN SUFFIX IS NOT NULL AND SUFFIX <> '' THEN ' ' || SUFFIX
                            ELSE ''
                        END AS FULLNAME 
                        From PAYROLL_ATTENDANCE A 
                        inner JOIN TBL_EMPLOYEE B ON B.BIOMETRICID = A.BIOMETRICID 
                        inner join BIOMETRIC_DTR C ON C.BIO_ID = B.BIOMETRICID  AND C.PAYDATE  = A.PAYDATE 
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

                    If DateExist_IN_Schedule(biometric_No, DATEE.ToShortDateString) Then
                        Dim valuee_in As String = GetData("TIME_IN", $"PAYROLL_SCHEDULE WHERE BIO_NO = '{biometric_No}' AND DATEE = '{DATEE.ToShortDateString}' ")

                        If valuee_in = "RD" Or valuee_in = "AL" Or valuee_in = "SIL" Or valuee_in = "AWOP" Then

                            TIME_IN = GetData("VALUEE", $"PAYROLL_DEFAULT_TIMEIN")
                            TIME_OUT = TIME_IN.AddHours(9)

                        Else
                            TIME_IN = GetData("TIME_IN", $"PAYROLL_SCHEDULE WHERE BIO_NO = '{biometric_No}' AND DATEE = '{DATEE.ToShortDateString}' ")
                            TIME_OUT = TIME_IN.AddHours(9)
                        End If

                    Else
                        TIME_IN = GetData("VALUEE", $"PAYROLL_DEFAULT_TIMEIN")
                        TIME_OUT = TIME_IN.AddHours(9)
                    End If

                Else
                    TIME_IN = GetTimeInOut(biometric_No).Time_in
                    TIME_OUT = GetTimeInOut(biometric_No).Time_out
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

                    '======================== TO REPLACE EXISTING RECORD ========================================================
                    If ThisHasRow($"BIOMETRIC_DTR where BIO_ID = '{biometric_No}' and PAYDATE = '{paydate_}' and DATE_ONLY = '{DATE_ONLY}'") Then Replacing($"BIOMETRIC_DTR where BIO_ID = '{biometric_No}' and PAYDATE = '{paydate_}' and DATE_ONLY = '{DATE_ONLY}';")
                    '======================== GET TIME IN/OUT TO CALCULATE LATE UNDERTIME OVERTIME ============================

                    distinct_bio.Add(biometric_No)
                    SaveDTR(biometric_No, Paydate, DATE_ONLY, new_list(0), new_list(1), new_list(2), new_list(3))
                End If
            Next

            frmMainForm.AppProgressBar.Value += 1
        Next
        progressBarEnd()

    End Sub

    Private Sub Search_BTN_Click(sender As Object, e As EventArgs) Handles Search_BTN.Click
        PopulateBiometricSHEET(Biometric_LV, Paydate, False, Search_TXT.Text)
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
                If Today.ToString("d") > CDate(Paydate7_CB.Text) Then
                    Save7_BTN.Enabled = False
                Else
                    Save7_BTN.Enabled = True
                End If
            Else
                If Today.ToString("d") > CDate(PAYROLL) Then
                    Save7_BTN.Enabled = False
                Else
                    Save7_BTN.Enabled = True
                End If
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
                        Overtime7_NUP.Text = IIf(IsDBNull(.Item("OVERTIME")) Or .Item("OVERTIME").Equals("0"), "", .Item("OVERTIME"))

                        Late7_TXT.Text = IIf(IsDBNull(.Item("LATE")) Or .Item("LATE").Equals("0"), "", .Item("LATE"))
                        Undertime7_TXT.Text = IIf(IsDBNull(.Item("UNDERTIME")) Or .Item("UNDERTIME").Equals("0"), "", .Item("UNDERTIME"))

                        Night7_TXT.Text = IIf(IsDBNull(.Item("NIGHT_RATE")) Or .Item("NIGHT_RATE") = 0, "", .Item("NIGHT_RATE"))
                        SIL7_NUP.Text = IIf(IsDBNull(.Item("SIL")) Or .Item("SIL") = 0, "", .Item("SIL"))
                        SpecHol7_TXT.Text = IIf(IsDBNull(.Item("SPECHOLIDAY_HRS")) Or .Item("SPECHOLIDAY_HRS") = 0, "", .Item("SPECHOLIDAY_HRS"))
                        RegHol7_TXT.Text = IIf(IsDBNull(.Item("REGHOLIDAY_ADDITIONAL")) Or .Item("REGHOLIDAY_ADDITIONAL") = 0, "", .Item("REGHOLIDAY_ADDITIONAL"))
                        txtRegHolDeduction.Text = IIf(IsDBNull(.Item("REGHOLIDAY_DEDUCTION")) Or .Item("REGHOLIDAY_DEDUCTION") = 0, "", .Item("REGHOLIDAY_DEDUCTION"))

                        txtRestDayDuty.Text = IIf(IsDBNull(.Item("DUTY_RESTDAY")) Or .Item("DUTY_RESTDAY").Equals("0"), "", .Item("DUTY_RESTDAY"))
                        txtSpecRestDay.Text = IIf(IsDBNull(.Item("DUTY_SPEC_RESTDAY")) Or .Item("DUTY_SPEC_RESTDAY").Equals("0"), "", .Item("DUTY_SPEC_RESTDAY"))
                        txtRegRestDay.Text = IIf(IsDBNull(.Item("DUTY_REG_RESTDAY")) Or .Item("DUTY_REG_RESTDAY").Equals("0"), "", .Item("DUTY_REG_RESTDAY"))

                        txtRestDayOT.Text = IIf(IsDBNull(.Item("DUTY_RESTDAY_OT")) Or .Item("DUTY_RESTDAY_OT").Equals("0"), "", .Item("DUTY_RESTDAY_OT"))
                        txtSpecOT.Text = IIf(IsDBNull(.Item("DUTY_SPEC_OT")) Or .Item("DUTY_SPEC_OT").Equals("0"), "", .Item("DUTY_SPEC_OT"))
                        txtSpecRestDayOT.Text = IIf(IsDBNull(.Item("DUTY_SPEC_RESTDAY_OT")) Or .Item("DUTY_SPEC_RESTDAY_OT").Equals("0"), "", .Item("DUTY_SPEC_RESTDAY_OT"))
                        txtRegOT.Text = IIf(IsDBNull(.Item("DUTY_REG_OT")) Or .Item("DUTY_REG_OT").Equals("0"), "", .Item("DUTY_REG_OT"))
                        txtRegRestDayOT.Text = IIf(IsDBNull(.Item("DUTY_REG_RESTDAY_OT")) Or .Item("DUTY_REG_RESTDAY_OT").Equals("0"), "", .Item("DUTY_REG_RESTDAY_OT"))

                        txtSpecNightShift.Text = IIf(IsDBNull(.Item("DUTY_SPEC_NIGHTSHIFT")) Or .Item("DUTY_SPEC_NIGHTSHIFT").Equals("0"), "", .Item("DUTY_SPEC_NIGHTSHIFT"))
                        txtRegNightShift.Text = IIf(IsDBNull(.Item("DUTY_REG_NIGHTSHIFT")) Or .Item("DUTY_REG_NIGHTSHIFT").Equals("0"), "", .Item("DUTY_REG_NIGHTSHIFT"))

                        txtOrdNightShiftOT.Text = IIf(IsDBNull(.Item("DUTY_ORD_NIGHTSHIFT_OT")) Or .Item("DUTY_ORD_NIGHTSHIFT_OT").Equals("0"), "", .Item("DUTY_ORD_NIGHTSHIFT_OT"))
                        txtSpecNightShiftOT.Text = IIf(IsDBNull(.Item("DUTY_SPEC_NIGHTSHIFT_OT")) Or .Item("DUTY_SPEC_NIGHTSHIFT_OT").Equals("0"), "", .Item("DUTY_SPEC_NIGHTSHIFT_OT"))
                        txtRegNightShiftOT.Text = IIf(IsDBNull(.Item("DUTY_REG_NIGHTSHIFT_OT")) Or .Item("DUTY_REG_NIGHTSHIFT_OT").Equals("0"), "", .Item("DUTY_REG_NIGHTSHIFT_OT"))

                        NewRateDaysCovered_NUP.Text = IIf(IsDBNull(.Item("NEW_RATE_DAYS_COVERED")) Or .Item("NEW_RATE_DAYS_COVERED").Equals("0"), "", .Item("NEW_RATE_DAYS_COVERED"))
                        txtNewRateLate.Text = IIf(IsDBNull(.Item("NEW_RATE_LATE_COVERED")) Or .Item("NEW_RATE_LATE_COVERED").Equals("0"), "", .Item("NEW_RATE_LATE_COVERED"))
                        txtNewRateUT.Text = IIf(IsDBNull(.Item("NEW_RATE_UT_COVERED")) Or .Item("NEW_RATE_UT_COVERED").Equals("0"), "", .Item("NEW_RATE_UT_COVERED"))
                        newRateOT_NUP.Text = IIf(IsDBNull(.Item("NEW_RATE_OT_COVERED")) Or .Item("NEW_RATE_OT_COVERED").Equals("0"), "", .Item("NEW_RATE_OT_COVERED"))
                        txtNewRateRegHoliday.Text = IIf(IsDBNull(.Item("NEW_RATE_REGHOLIDAY_COVERED")) Or .Item("NEW_RATE_REGHOLIDAY_COVERED").Equals("0"), "", .Item("NEW_RATE_REGHOLIDAY_COVERED"))
                        txtNewRateSpecHoliday.Text = IIf(IsDBNull(.Item("NEW_RATE_SPECHOLIDAY_COVERED")) Or .Item("NEW_RATE_SPECHOLIDAY_COVERED").Equals("0"), "", .Item("NEW_RATE_SPECHOLIDAY_COVERED"))

                    End With
                Next

                Save7_BTN.Tag = "UPDATED"
            Else

                Days7_TXT.Clear()
                Overtime7_NUP.Value = Nothing
                Late7_TXT.Clear()
                SpecHol7_TXT.Clear()
                RegHol7_TXT.Clear()
                txtRegHolDeduction.Clear()
                Undertime7_TXT.Clear()
                Night7_TXT.Clear()
                SIL7_NUP.TextAlign = 0
                Save7_BTN.Tag = "ADDED"

                txtRestDayDuty.Clear()
                txtSpecRestDay.Clear()
                txtRegRestDay.Clear()

                txtRestDayOT.Clear()
                txtSpecOT.Clear()
                txtSpecRestDayOT.Clear()
                txtRegOT.Clear()
                txtRegRestDayOT.Clear()

                txtSpecNightShift.Clear()
                txtRegNightShift.Clear()

                txtOrdNightShiftOT.Clear()
                txtSpecNightShiftOT.Clear()
                txtRegNightShiftOT.Clear()

                NewRateDaysCovered_NUP.TextAlign = 0
                txtNewRateLate.Clear()
                txtNewRateUT.Clear()
                newRateOT_NUP.TextAlign = 0
                txtNewRateRegHoliday.Clear()
                txtNewRateSpecHoliday.Clear()

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

                emp_status = GetData("EMP_STATUS", $"TBL_EMPLOYEE WHERE BIOMETRICID = '{Bio7_TXT.Text}'")
                dateEnded = GetData("DATE_ENDED", $"TBL_EMPLOYEE WHERE BIOMETRICID = '{Bio7_TXT.Text}'")
                dateStarted = GetData("DATEHIRED", $"TBL_EMPLOYEE WHERE BIOMETRICID = '{Bio7_TXT.Text}'")
                '======================== HOLIDAY ============================ 
                Dim regHol_additional As Double = IIf(String.IsNullOrWhiteSpace(RegHol7_TXT.Text), 0, RegHol7_TXT.Text)
                Dim regHol_deduction As Double = IIf(String.IsNullOrWhiteSpace(txtRegHolDeduction.Text), 0, txtRegHolDeduction.Text)    'ABSENT BEFORE/AFTER REGULAR HOLIDAY
                Dim RHOLIDAY As Double = (REGHolidayCount(starting_date, ending_date) + regHol_additional)

                If RHOLIDAY > 0 Then RHOLIDAY -= regHol_deduction   'PREVENT NEGATIVE VALUE (WHEN THERE'S NO REGULAR HOLIDAY)

                Dim specHoliday_hrs As Double = IIf(String.IsNullOrWhiteSpace(SpecHol7_TXT.Text), 0, SpecHol7_TXT.Text)
                Dim SHOLIDAY As Double = 0

                If specHoliday_hrs = 0 Or specHoliday_hrs < 8 Then
                    SHOLIDAY = 0
                ElseIf specHoliday_hrs >= 8 Then
                    SHOLIDAY = specHoliday_hrs / 8
                End If

                If specHoliday_hrs >= 8 And specHoliday_hrs Mod 8 > 0 Then SHOLIDAY += 1
                Dim overtime As Double = IIf(String.IsNullOrWhiteSpace(Overtime7_NUP.Text), 0, Overtime7_NUP.Text)
                Dim latee As Double = IIf(String.IsNullOrWhiteSpace(Late7_TXT.Text), 0, Late7_TXT.Text)
                Dim undertimee As Double = IIf(String.IsNullOrWhiteSpace(Undertime7_TXT.Text), 0, Undertime7_TXT.Text)
                Dim sil As Double = IIf(String.IsNullOrWhiteSpace(SIL7_NUP.Text), 0, SIL7_NUP.Text)
                Dim night7 As Double = IIf(String.IsNullOrWhiteSpace(Night7_TXT.Text), 0, Night7_TXT.Text)

                Dim DUTY_RESTDAY As Double = IIf(String.IsNullOrWhiteSpace(txtRestDayDuty.Text), 0, txtRestDayDuty.Text)
                Dim DUTY_SPEC_RESTDAY As Double = IIf(String.IsNullOrWhiteSpace(txtSpecRestDay.Text), 0, txtSpecRestDay.Text)
                Dim DUTY_REG_RESTDAY As Double = IIf(String.IsNullOrWhiteSpace(txtRegRestDay.Text), 0, txtRegRestDay.Text)

                Dim DUTY_RESTDAY_OT As Double = IIf(String.IsNullOrWhiteSpace(txtRestDayOT.Text), 0, txtRestDayOT.Text)
                Dim DUTY_SPEC_OT As Double = IIf(String.IsNullOrWhiteSpace(txtSpecOT.Text), 0, txtSpecOT.Text)
                Dim DUTY_SPEC_RESTDAY_OT As Double = IIf(String.IsNullOrWhiteSpace(txtSpecRestDayOT.Text), 0, txtSpecRestDayOT.Text)
                Dim DUTY_REG_OT As Double = IIf(String.IsNullOrWhiteSpace(txtRegOT.Text), 0, txtRegOT.Text)
                Dim DUTY_REG_RESTDAY_OT As Double = IIf(String.IsNullOrWhiteSpace(txtRegRestDayOT.Text), 0, txtRegRestDayOT.Text)

                Dim DUTY_SPEC_NIGHTSHIFT As Double = IIf(String.IsNullOrWhiteSpace(txtSpecNightShift.Text), 0, txtSpecNightShift.Text)
                Dim DUTY_REG_NIGHTSHIFT As Double = IIf(String.IsNullOrWhiteSpace(txtRegNightShift.Text), 0, txtRegNightShift.Text)

                Dim DUTY_ORD_NIGHTSHIFT_OT As Double = IIf(String.IsNullOrWhiteSpace(txtOrdNightShiftOT.Text), 0, txtOrdNightShiftOT.Text)
                Dim DUTY_SPEC_NIGHTSHIFT_OT As Double = IIf(String.IsNullOrWhiteSpace(txtSpecNightShiftOT.Text), 0, txtSpecNightShiftOT.Text)
                Dim DUTY_REG_NIGHTSHIFT_OT As Double = IIf(String.IsNullOrWhiteSpace(txtRegNightShiftOT.Text), 0, txtRegNightShiftOT.Text)

                Dim NEW_RATE_DAYS_COVERED As Double = IIf(String.IsNullOrWhiteSpace(NewRateDaysCovered_NUP.Text), 0, NewRateDaysCovered_NUP.Text)
                Dim NEW_RATE_LATE_COVERED As Double = IIf(String.IsNullOrWhiteSpace(txtNewRateLate.Text), 0, txtNewRateLate.Text)
                Dim NEW_RATE_UT_COVERED As Double = IIf(String.IsNullOrWhiteSpace(txtNewRateUT.Text), 0, txtNewRateUT.Text)
                Dim NEW_RATE_OT_COVERED As Double = IIf(String.IsNullOrWhiteSpace(newRateOT_NUP.Text), 0, newRateOT_NUP.Text)
                Dim NEW_RATE_REGHOLIDAY_COVERED As Double = IIf(String.IsNullOrWhiteSpace(txtNewRateRegHoliday.Text), 0, txtNewRateRegHoliday.Text)
                Dim NEW_RATE_SPECHOLIDAY_COVERED As Double = IIf(String.IsNullOrWhiteSpace(txtNewRateSpecHoliday.Text), 0, txtNewRateSpecHoliday.Text)

                Dim totalDays As Double = IIf(String.IsNullOrWhiteSpace(Days7_TXT.Text), 0, Days7_TXT.Text)

                '===================================== MINIMUM CHANGED =================================
                If ThisHasRow($"CHANGE_MINIMUM_RATE WHERE PAYDATE = '{paydate_}'") AndAlso ThisHasRow($"TBL_EMPLOYEE WHERE BIOMETRICID = '{Bio7_TXT.Text}' AND MINIMUM_RATE_UPDATED_AT = '{paydate_}'") Then
                    Dim new_days As Double = NEW_RATE_DAYS_COVERED
                    Dim old_days As Double = totalDays - new_days

                    Dim new_overtime As Double = NEW_RATE_OT_COVERED
                    Dim old_overtime As Double = overtime - new_overtime

                    Dim new_late As Double = NEW_RATE_LATE_COVERED
                    Dim old_late As Double = latee - new_late

                    Dim new_undertime As Double = NEW_RATE_UT_COVERED
                    Dim old_undertime As Double = undertimee - new_undertime

                    Dim new_regHoliday As Double = NEW_RATE_REGHOLIDAY_COVERED
                    Dim new_specHoliday As Double = NEW_RATE_SPECHOLIDAY_COVERED

                    SaveTemporary(Bio7_TXT.Text,
                                  old_days, new_days,
                                  old_overtime, new_overtime,
                                  old_late, new_late,
                                  old_undertime, new_undertime,
                                  new_regHoliday, new_specHoliday, PAYROLL)
                End If


                'SaveAttendanceEE(BiometricID_TXT.Text, PAYROLL, TotalDays_LBL.Text, TotalOTHr_LBL.Text, TotalLateHR_LBL.Text, TotalUTHR_LBL.Text,
                '                 TotalRHoliday_LBL.Text, TotalSHoliday_LBL.Text, specHoliday_hrs, SIL_LBL.Text, Late_percentage, Late_approved, AM_OT_NUP.Value)


                SaveAttendanceEE(Bio7_TXT.Text, PAYROLL, Days7_TXT.Text, overtime, latee, undertimee,
                                     RHOLIDAY, SHOLIDAY, specHoliday_hrs, sil, 0, "", "", regHol_deduction, night7, True,
                                     DUTY_RESTDAY, DUTY_SPEC_RESTDAY, DUTY_REG_RESTDAY, DUTY_RESTDAY_OT,
                                     DUTY_SPEC_OT, DUTY_SPEC_RESTDAY_OT, DUTY_REG_OT, DUTY_REG_RESTDAY_OT,
                                     DUTY_SPEC_NIGHTSHIFT, DUTY_REG_NIGHTSHIFT, DUTY_ORD_NIGHTSHIFT_OT, DUTY_SPEC_NIGHTSHIFT_OT, DUTY_REG_NIGHTSHIFT_OT,
                                     NEW_RATE_DAYS_COVERED, NEW_RATE_LATE_COVERED, NEW_RATE_UT_COVERED, NEW_RATE_OT_COVERED,
                                     NEW_RATE_REGHOLIDAY_COVERED, NEW_RATE_SPECHOLIDAY_COVERED, regHol_additional)

                SavePayout_IndividualL(Bio7_TXT.Text, PAYROLL, starting_date, ending_date)

                SaveLogs($"{Save7_BTN.Tag} ATTENDANCE ({Emp7_TXT.Text} ({Bio7_TXT.Text})) - Days({Days7_TXT.Text}), OT({Overtime7_NUP.Text}), Late({Late7_TXT.Text}), Undertime({Undertime7_TXT.Text}), R/S Holiday({TotalRHoliday_LBL.Text}/{TotalSHoliday_LBL.Text}), Night Rate({Night7_TXT.Text}), SIL({SIL7_NUP.Text})", frmMainForm.UserName_LBL.Text)

                Cancel7_BTN.PerformClick()

                PopulateBiometricSHEET(Branch_LV, Paydate, True) ' ===== POPULATE DATAGRIDVIEW FROM SHEET ==== 

                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Information")
            End If

        Else
            MsgBox("Please Ensure that Employee's Name and No. of days are inputed!", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    Private Sub Hours7_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Undertime7_TXT.KeyPress, txtRegHolDeduction.KeyPress, SpecHol7_TXT.KeyPress, RegHol7_TXT.KeyPress, Night7_TXT.KeyPress, Late7_TXT.KeyPress, Days7_TXT.KeyPress
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
        Overtime7_NUP.Value = Nothing
        Late7_TXT.Clear()
        Undertime7_TXT.Clear()
        Night7_TXT.Clear()
        RegHol7_TXT.Clear()
        txtRegHolDeduction.Clear()
        SpecHol7_TXT.Clear()

        txtRestDayDuty.Clear()
        txtSpecRestDay.Clear()
        txtRegRestDay.Clear()

        txtRestDayOT.Clear()
        txtSpecOT.Clear()
        txtSpecRestDayOT.Clear()
        txtRegOT.Clear()
        txtRegRestDayOT.Clear()

        txtSpecNightShift.Clear()
        txtRegNightShift.Clear()

        txtOrdNightShiftOT.Clear()
        txtSpecNightShiftOT.Clear()
        txtRegNightShiftOT.Clear()

        NewRateDaysCovered_NUP.Value = Nothing
        txtNewRateLate.Clear()
        txtNewRateUT.Clear()
        newRateOT_NUP.Value = Nothing
        txtNewRateRegHoliday.Clear()
        txtNewRateSpecHoliday.Clear()

    End Sub

    Private Sub Biometric_LV_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Biometric_LV.MouseDoubleClick
        CheckALL_CheckBox.Checked = False

        If Biometric_LV.Items.Count = 0 Then Exit Sub
        Late_approved = 0 '============= FOR LATE_APPROVED CALCULATION ==================
        BiometricID_TXT.Text = Biometric_LV.Items(Biometric_LV.FocusedItem.Index).SubItems(0).Text

        Attendance_Tab.SelectedIndex = 1

        Calculate_BTN.PerformClick()
    End Sub

    Private Sub PIDaysX_btn_Click(sender As Object, e As EventArgs) Handles PIDaysX_btn.Click
        P_Add_Panel.Visible = False
        PI_Days.Value = 0.0
    End Sub


    Private Sub DataGridView1_MouseClick(sender As Object, e As MouseEventArgs) Handles DataGridView1.MouseClick
        Dim row As DataGridViewRow = DataGridView1.Rows(DataGridView1.CurrentRow.Index)
        If e.Button = MouseButtons.Right Then

            'If row.Cells(1).Style.ForeColor = Color.Blue Then
            '    Menu_SILHalfDay.Text = "Disapproved"
            'Else
            '    Menu_SILHalfDay.Text = "Approved"
            'End If 

            If BiometricID_TXT.Text = "" Then
                MsgBox("Please Enter Employee's Name.", MsgBoxStyle.Critical, "Error")
            Else
                ContextMenu_SIL.Show(DataGridView1, New Point(e.X, e.Y))
            End If

        End If
    End Sub

    Private Sub Branch_LV_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Branch_LV.MouseDoubleClick
        If Branch_LV.Items.Count = 0 Then Exit Sub
        Cancel7_BTN.PerformClick()
        Bio7_TXT.Text = Branch_LV.Items(Branch_LV.FocusedItem.Index).SubItems(0).Text
    End Sub

    Private Sub Browse7_BTN_Click(sender As Object, e As EventArgs) Handles Browse7_BTN.Click
        Dim dialog = New OpenFileDialog
        If dialog.ShowDialog() = DialogResult.OK Then
            Path7_TXT.Text = dialog.FileName
        End If
    End Sub

    Private Sub Import7_BTN_Click(sender As Object, e As EventArgs) Handles Import7_BTN.Click
        '=====================  ORIGIINAL ==============================
        eApp = New Excel.Application
        eBook = eApp.Workbooks.Open(Path7_TXT.Text)
        eSheet = eBook.Worksheets(1)
        eCell = eSheet.UsedRange


        MyConnection = New System.Data.OleDb.OleDbConnection($"provider=Microsoft.Jet.OLEDB.4.0;Data Source='{Path7_TXT.Text}';Extended Properties=Excel 8.0;")

        'ONLY FOR JEN PC TESTING
        If Environment.MachineName = "JEN" Then
            Dim connStr As String = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={Path7_TXT.Text};Extended Properties='Excel 12.0 Xml;HDR=YES';"
            MyConnection = New System.Data.OleDb.OleDbConnection(connStr)
        End If

        MyCommand = New System.Data.OleDb.OleDbDataAdapter($"select * from [{eSheet.Name}$]", MyConnection)
        MyCommand.TableMappings.Add("Table", "Net-informations.com")
        DtSet = New System.Data.DataSet
        MyCommand.Fill(DtSet)

        Dim row As Integer
        Dim payroll As String = Paydate.ToShortDateString

        progressBarStart(DtSet.Tables(0).Rows.Count)

        For row = 2 To DtSet.Tables(0).Rows.Count + 1
            If IsNumeric(eCell(row, 1).Value) Then
                Dim bioNo As String = eCell(row, 1).Value
                Dim fullname As String = eCell(row, 2).Value
                Dim totalDays As String = IIf(String.IsNullOrWhiteSpace(eCell(row, 3).Value), 0, eCell(row, 3).Value)
                Dim overtime As String = IIf(String.IsNullOrWhiteSpace(eCell(row, 4).Value), 0, eCell(row, 4).Value)
                Dim late As String = IIf(String.IsNullOrWhiteSpace(eCell(row, 5).Value), 0, eCell(row, 5).Value)
                Dim undertime As String = IIf(String.IsNullOrWhiteSpace(eCell(row, 6).Value), 0, eCell(row, 6).Value)
                Dim specHoliday_hrs As String = IIf(String.IsNullOrWhiteSpace(eCell(row, 7).Value), 0, eCell(row, 7).Value)
                Dim nightRate As String = IIf(String.IsNullOrWhiteSpace(eCell(row, 8).Value), 0, eCell(row, 8).Value)
                Dim sil As String = IIf(String.IsNullOrWhiteSpace(eCell(row, 9).Value), 0, eCell(row, 9).Value)
                If sil > 5 Then sil = 5

                emp_status = GetData("EMP_STATUS", $"TBL_EMPLOYEE WHERE BIOMETRICID = '{bioNo}'")
                dateEnded = GetData("DATE_ENDED", $"TBL_EMPLOYEE WHERE BIOMETRICID = '{bioNo}'")
                dateStarted = GetData("DATEHIRED", $"TBL_EMPLOYEE WHERE BIOMETRICID = '{bioNo}'")
                '======================== HOLIDAY ============================   
                Dim regHol_additional As Integer = IIf(String.IsNullOrWhiteSpace(eCell(row, 10).Value), 0, eCell(row, 10).Value)
                Dim regHol_deduction As Double = IIf(String.IsNullOrWhiteSpace(eCell(row, 30).Value), 0, eCell(row, 30).Value)    'ABSENT BEFORE/AFTER REGULAR HOLIDAY
                Dim regHoliday As Integer = (REGHolidayCount(starting_date, ending_date) + regHol_additional)

                If regHoliday > 0 Then regHoliday -= regHol_deduction   'PREVENT NEGATIVE VALUE (WHEN THERE'S NO REGULAR HOLIDAY) 

                Dim DUTY_RESTDAY As Integer = IIf(String.IsNullOrWhiteSpace(eCell(row, 11).Value), 0, eCell(row, 11).Value)
                Dim DUTY_SPEC_RESTDAY As Integer = IIf(String.IsNullOrWhiteSpace(eCell(row, 12).Value), 0, eCell(row, 12).Value)
                Dim DUTY_REG_RESTDAY As Integer = IIf(String.IsNullOrWhiteSpace(eCell(row, 13).Value), 0, eCell(row, 13).Value)

                Dim DUTY_RESTDAY_OT As Double = IIf(String.IsNullOrWhiteSpace(eCell(row, 14).Value), 0, eCell(row, 14).Value)
                Dim DUTY_SPEC_OT As Double = IIf(String.IsNullOrWhiteSpace(eCell(row, 15).Value), 0, eCell(row, 15).Value)
                Dim DUTY_SPEC_RESTDAY_OT As Double = IIf(String.IsNullOrWhiteSpace(eCell(row, 16).Value), 0, eCell(row, 16).Value)
                Dim DUTY_REG_OT As Double = IIf(String.IsNullOrWhiteSpace(eCell(row, 17).Value), 0, eCell(row, 17).Value)
                Dim DUTY_REG_RESTDAY_OT As Double = IIf(String.IsNullOrWhiteSpace(eCell(row, 18).Value), 0, eCell(row, 18).Value)

                Dim DUTY_SPEC_NIGHTSHIFT As Integer = IIf(String.IsNullOrWhiteSpace(eCell(row, 19).Value), 0, eCell(row, 19).Value)
                Dim DUTY_REG_NIGHTSHIFT As Integer = IIf(String.IsNullOrWhiteSpace(eCell(row, 20).Value), 0, eCell(row, 20).Value)

                Dim DUTY_ORD_NIGHTSHIFT_OT As Double = IIf(String.IsNullOrWhiteSpace(eCell(row, 21).Value), 0, eCell(row, 21).Value)
                Dim DUTY_SPEC_NIGHTSHIFT_OT As Double = IIf(String.IsNullOrWhiteSpace(eCell(row, 22).Value), 0, eCell(row, 22).Value)
                Dim DUTY_REG_NIGHTSHIFT_OT As Double = IIf(String.IsNullOrWhiteSpace(eCell(row, 23).Value), 0, eCell(row, 23).Value)

                Dim NEW_RATE_DAYS_COVERED As Integer = IIf(String.IsNullOrWhiteSpace(eCell(row, 24).Value), 0, eCell(row, 24).Value)
                Dim NEW_RATE_LATE_COVERED As Integer = IIf(String.IsNullOrWhiteSpace(eCell(row, 25).Value), 0, eCell(row, 25).Value)
                Dim NEW_RATE_UT_COVERED As Integer = IIf(String.IsNullOrWhiteSpace(eCell(row, 26).Value), 0, eCell(row, 26).Value)
                Dim NEW_RATE_OT_COVERED As Integer = IIf(String.IsNullOrWhiteSpace(eCell(row, 27).Value), 0, eCell(row, 27).Value)
                Dim NEW_RATE_REGHOLIDAY_COVERED As Integer = IIf(String.IsNullOrWhiteSpace(eCell(row, 28).Value), 0, eCell(row, 28).Value)
                Dim NEW_RATE_SPECHOLIDAY_COVERED As Integer = IIf(String.IsNullOrWhiteSpace(eCell(row, 29).Value), 0, eCell(row, 29).Value)

                If totalDays <> 0 Then
                    RunCommand($"DELETE FROM PAYROLL_ATTENDANCE WHERE PAYDATE = '{payroll}' AND BRANCH_MANUAL = TRUE AND BIOMETRICID = {bioNo};")
                    RunCommand($"DELETE FROM PAYROLL_PAYOUT WHERE PAYDATE = '{payroll}' AND BIOMETRIC_ID = {bioNo};")
                    RunCommand($"DELETE FROM RECORDED_ALLOW_DEDUC WHERE PAYDATE = '{payroll}' AND BIO_NO = {bioNo};")

                    ''===================================== MINIMUM CHANGED STARTING SEPTEMBER 1, 2022 =================================
                    'If ThisHasRow($"CHANGE_MINIMUM_RATE WHERE PAYDATE = '{paydate_}'") Then
                    '    SaveTemporary(bioNo, 0, totalDays, 0, overtime, 0, late, 0, undertime, 0, 0, payroll)
                    'End If 

                    '===================================== MINIMUM CHANGED =================================
                    If ThisHasRow($"CHANGE_MINIMUM_RATE WHERE PAYDATE = '{paydate_}'") AndAlso ThisHasRow($"TBL_EMPLOYEE WHERE BIOMETRICID = '{bioNo}' AND MINIMUM_RATE_UPDATED_AT = '{paydate_}'") Then
                        Dim new_days As Double = NEW_RATE_DAYS_COVERED
                        Dim old_days As Double = totalDays - new_days

                        Dim new_overtime As Double = NEW_RATE_OT_COVERED
                        Dim old_overtime As Double = overtime - new_overtime

                        Dim new_late As Double = NEW_RATE_LATE_COVERED
                        Dim old_late As Double = late - new_late

                        Dim new_undertime As Double = NEW_RATE_UT_COVERED
                        Dim old_undertime As Double = undertime - new_undertime

                        Dim new_regHoliday As Double = NEW_RATE_REGHOLIDAY_COVERED
                        Dim new_specHoliday As Double = NEW_RATE_SPECHOLIDAY_COVERED

                        SaveTemporary(bioNo,
                                  old_days, new_days,
                                  old_overtime, new_overtime,
                                  old_late, new_late,
                                  old_undertime, new_undertime,
                                  new_regHoliday, new_specHoliday, payroll)
                    End If


                    'Friend Sub SaveAttendanceEE(biometric As Integer, paydate As String, days As String, overTime As String, late_total As String, under_total As String,
                    '                            regHoliday As String, specHoliday As String, specHoliday_hrs As Double, SIL As Double, LATE_ADJUSTMENT As String, Optional LATE_APPROVED As String = "",
                    '                                    Optional MORNING_OT As String = "", Optional regHol_deduction As Integer = 0, Optional NIGHT_RATE As String = "", Optional BRANCH As Boolean = False,
                    '                                    Optional DUTY_RESTDAY As Double = 0, Optional DUTY_SPEC_RESTDAY As Double = 0, Optional DUTY_REG_RESTDAY As Double = 0,
                    '                                    Optional DUTY_RESTDAY_OT As Double = 0, Optional DUTY_SPEC_OT As Double = 0, Optional DUTY_SPEC_RESTDAY_OT As Double = 0, Optional DUTY_REG_OT As Double = 0, Optional DUTY_REG_RESTDAY_OT As Double = 0,
                    '                                    Optional DUTY_SPEC_NIGHTSHIFT As Double = 0, Optional DUTY_REG_NIGHTSHIFT As Double = 0, Optional DUTY_ORD_NIGHTSHIFT_OT As Double = 0, Optional DUTY_SPEC_NIGHTSHIFT_OT As Double = 0, Optional DUTY_REG_NIGHTSHIFT_OT As Double = 0,
                    '                                    Optional NEW_RATE_DAYS_COVERED As Double = 0, Optional NEW_RATE_LATE_COVERED As Double = 0, Optional NEW_RATE_UT_COVERED As Double = 0, Optional NEW_RATE_OT_COVERED As Double = 0,
                    '                                    Optional NEW_RATE_REGHOLIDAY_COVERED As Double = 0, Optional NEW_RATE_SPECHOLIDAY_COVERED As Double = 0, Optional regHol_additional As Integer = 0)

                    SaveAttendanceEE(bioNo, payroll, totalDays, overtime, late, undertime,
                                 regHoliday, TotalSHoliday_LBL.Text, specHoliday_hrs, sil, Nothing, Nothing, Nothing, regHol_deduction, nightRate, True,
                                 DUTY_RESTDAY, DUTY_SPEC_RESTDAY, DUTY_REG_RESTDAY,
                                 DUTY_RESTDAY_OT, DUTY_SPEC_OT, DUTY_SPEC_RESTDAY_OT, DUTY_REG_OT, DUTY_REG_RESTDAY_OT,
                                 DUTY_SPEC_NIGHTSHIFT, DUTY_REG_NIGHTSHIFT,
                                 DUTY_ORD_NIGHTSHIFT_OT, DUTY_SPEC_NIGHTSHIFT_OT, DUTY_REG_NIGHTSHIFT_OT,
                                 NEW_RATE_DAYS_COVERED, NEW_RATE_LATE_COVERED, NEW_RATE_UT_COVERED, NEW_RATE_OT_COVERED,
                                 NEW_RATE_REGHOLIDAY_COVERED, NEW_RATE_SPECHOLIDAY_COVERED, regHol_additional)

                    SavePayout_IndividualL(bioNo, payroll, starting_date, ending_date)

                    distinct_bio.Add(eCell(row, 1).Value)
                End If

                If frmMainForm.AppProgressBar.Value <> DtSet.Tables(0).Rows.Count Then frmMainForm.AppProgressBar.Value += 1

            Else
                MsgBox($"row {row} is empty or not a valid Biometric No.!", MsgBoxStyle.Exclamation)
            End If
        Next

        progressBarEnd()

        '====================== TRANSACTION ==========================
        Dim listt As String = Nothing
        For Each bio As String In distinct_bio
            If listt = Nothing Then
                listt = bio
            Else
                listt = listt & ", " & bio
            End If
        Next

        SaveLogs($"IMPORTED BIOMETRIC - BRANCHES DTR ({listt})", frmMainForm.UserName_LBL.Text)

        '=============================================================
        PopulateComboBox(Paydate7_CB, "PAYROLL_ATTENDANCE", "PAYDATE", True)
        PopulateBiometricSHEET(Branch_LV, Paydate, True)
    End Sub

    Private Sub B_AddPIDays_btn_Click(sender As Object, e As EventArgs) Handles B_AddPIDays_btn.Click
        If B_P_Add_Panel.Visible = True Then
            B_P_Add_Panel.Visible = False
            B_PI_Days.Value = 0.0
        Else
            B_P_Add_Panel.Visible = True
            B_PI_Days.Value = B_PIDays_lbl.Text
        End If
    End Sub

    Private Sub B_PIDaysCheck_btn_Click(sender As Object, e As EventArgs) Handles B_PIDaysCheck_btn.Click
        Dim result As DialogResult = MsgBox("Additional days will be save for PI calculation, proceed anyway?", MsgBoxStyle.YesNo)
        If result = DialogResult.Yes Then
            B_PIDays_lbl.Text = B_PI_Days.Value
            Dim paydatee As String = Paydate.ToShortDateString
            SavePI_Additional_Days(B_PI_Days.Value, paydatee, "BRANCHES")
        End If

        B_P_Add_Panel.Visible = False
    End Sub

    Private Sub B_PIDaysX_btn_Click(sender As Object, e As EventArgs) Handles B_PIDaysX_btn.Click
        B_P_Add_Panel.Visible = False
        B_PI_Days.Value = 0.0
    End Sub

    Private Sub SIL7_NUP_ValueChanged(sender As Object, e As EventArgs) Handles SIL7_NUP.ValueChanged
        Dim totalMonths As Integer = CountYear_SIL(Bio7_TXT.Text, ending_date)

        If totalMonths >= 13 Then
            Dim sil_this_paydate As Double = GetData_Integer("SIL", $"PAYROLL_ATTENDANCE WHERE BIOMETRICID = '{Bio7_TXT.Text}' AND PAYDATE = '{paydate_}'")
            Dim total_SIL As Double = Count_SIL(Bio7_TXT.Text)
            Dim additional_SIL As Double = CDbl(SIL7_NUP.Text)
            Dim allowable_SIL As Double = 5 - (total_SIL - sil_this_paydate)

            If ((total_SIL - sil_this_paydate) + additional_SIL) <= 5 Then
            Else
                MsgBox($"Only {allowable_SIL} SIL is available. The rest have been used.", MsgBoxStyle.Critical, "Invalid")
                SIL7_NUP.Value = allowable_SIL
                Exit Sub
            End If

        Else
            MsgBox("Not yet allowed to avail SIL.", MsgBoxStyle.Critical, "Invalid")
            SIL7_NUP.Value = 0
            Exit Sub
        End If
    End Sub

    Private Sub SIL7_NUP_KeyDown(sender As Object, e As EventArgs) Handles SIL7_NUP.KeyDown
        Dim totalMonths As Integer = CountYear_SIL(Bio7_TXT.Text, ending_date)

        If totalMonths >= 13 Then
            Dim sil_this_paydate As Double = GetData_Integer("SIL", $"PAYROLL_ATTENDANCE WHERE BIOMETRICID = '{Bio7_TXT.Text}' AND PAYDATE = '{paydate_}'")
            Dim total_SIL As Double = Count_SIL(Bio7_TXT.Text)

            Dim additional_SIL As Double = 0
            If SIL7_NUP.Text <> Nothing Then additional_SIL = SIL7_NUP.Text     'IF THE USER ERASE THE INPUT SIL

            Dim allowable_SIL As Double = 5 - (total_SIL - sil_this_paydate)

            If ((total_SIL - sil_this_paydate) + additional_SIL) <= 5 Then
            Else
                MsgBox($"Only {allowable_SIL} SIL is available. The rest have been used.", MsgBoxStyle.Critical, "Invalid")
                SIL7_NUP.Value = allowable_SIL
                Exit Sub
            End If

        Else
            MsgBox("Not yet allowed to avail SIL.", MsgBoxStyle.Critical, "Invalid")
            SIL7_NUP.Value = 0
            Exit Sub
        End If
    End Sub

    Private previousValue As Integer
    Private Sub SIL7_NUP_MouseDown(sender As Object, e As EventArgs) Handles SIL7_NUP.MouseDown
        Dim totalMonths As Integer = CountYear_SIL(Bio7_TXT.Text, ending_date)

        If totalMonths >= 13 Then
            Dim sil_this_paydate As Double = GetData_Integer("SIL", $"PAYROLL_ATTENDANCE WHERE BIOMETRICID = '{Bio7_TXT.Text}' AND PAYDATE = '{paydate_}'")
            Dim total_SIL As Double = Count_SIL(Bio7_TXT.Text)

            Dim additional_SIL As Double = 0
            If SIL7_NUP.Text <> Nothing Then additional_SIL = SIL7_NUP.Text     'IF THE USER ERASE THE INPUT SIL

            Dim allowable_SIL As Double = 5 - (total_SIL - sil_this_paydate)

            If ((total_SIL - sil_this_paydate) + additional_SIL) <= 5 Then
            Else
                MsgBox($"Only {allowable_SIL} SIL is available. The rest have been used.", MsgBoxStyle.Critical, "Invalid")
                SIL7_NUP.Value = allowable_SIL
                Exit Sub
            End If

        Else
            MsgBox("Not yet allowed to avail SIL.", MsgBoxStyle.Critical, "Invalid")
            SIL7_NUP.Value = 0
            Exit Sub
        End If
    End Sub

    Private Sub SIL7_NUP_Enter(sender As Object, e As EventArgs) Handles SIL7_NUP.Enter
        Dim totalMonths As Integer = CountYear_SIL(Bio7_TXT.Text, ending_date)

        If totalMonths >= 13 Then
            Dim sil_this_paydate As Double = GetData_Integer("SIL", $"PAYROLL_ATTENDANCE WHERE BIOMETRICID = '{Bio7_TXT.Text}' AND PAYDATE = '{paydate_}'")
            Dim total_SIL As Double = Count_SIL(Bio7_TXT.Text)

            Dim additional_SIL As Double = 0
            If SIL7_NUP.Text <> Nothing Then additional_SIL = SIL7_NUP.Text     'IF THE USER ERASE THE INPUT SIL

            Dim allowable_SIL As Double = 5 - (total_SIL - sil_this_paydate)

            If ((total_SIL - sil_this_paydate) + additional_SIL) <= 5 Then
            Else
                MsgBox($"Only {allowable_SIL} SIL is available. The rest have been used.", MsgBoxStyle.Critical, "Invalid")
                SIL7_NUP.Value = allowable_SIL
                Exit Sub
            End If

        Else
            MsgBox("Not yet allowed to avail SIL.", MsgBoxStyle.Critical, "Invalid")
            SIL7_NUP.Value = 0
            Exit Sub
        End If
    End Sub

    Private Function IsFixedNoDutyDate(d As Date) As Boolean

        ' Sunday
        If d.DayOfWeek = DayOfWeek.Sunday Then Return True

        ' December 24 or 31
        If d.Month = 12 AndAlso (d.Day = 24 OrElse d.Day = 31) Then
            Return True
        End If

        ' Black Saturday (day after Good Friday)
        Dim easterSunday As Date = GetEasterSunday(d.Year)
        Dim goodFriday As Date = easterSunday.AddDays(-2)
        Dim blackSaturday As Date = goodFriday.AddDays(1)

        If d.Date = blackSaturday.Date Then Return True

        Return False
    End Function

    Private Function GetPreviousWorkingDay(d As Date) As Date
        Dim checkDate As Date = d.AddDays(-1)

        While IsNotWorkingDay(checkDate)
            checkDate = checkDate.AddDays(-1)
        End While

        Return checkDate
    End Function

    Private Function GetNextWorkingDay(d As Date) As Date
        Dim checkDate As Date = d.AddDays(1)

        While IsNotWorkingDay(checkDate)
            checkDate = checkDate.AddDays(1)
        End While

        Return checkDate
    End Function

    Function IsPresent_FromGrid(workDate As Date) As Boolean
        For Each r As DataGridViewRow In DataGridView1.Rows
            If CDate(r.Tag) = workDate Then
                Return CBool(r.Cells(5).Value)
            End If
        Next
        Return False ' date not found = absent
    End Function

    Private Function IsNotWorkingDay(d As Date) As Boolean
        ' Fixed no duty dates
        If IsFixedNoDutyDate(d) Then Return True

        ' Check if date is a holiday in the grid
        For Each r As DataGridViewRow In DataGridView1.Rows
            If CDate(r.Tag) = d Then
                If r.DefaultCellStyle.BackColor = Color.MediumOrchid _
               OrElse r.DefaultCellStyle.BackColor = Color.Plum Then
                    Return True
                End If
            End If
        Next

        Return False
    End Function

    Private Function CurrentSILCount()
        Dim total As Double = 0
        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.DefaultCellStyle.BackColor = Color.Aquamarine Or row.DefaultCellStyle.BackColor = Color.MediumAquamarine Then
                total += CDbl(row.Cells(2).Tag)
            End If
        Next
        Return total
    End Function

    Private Sub SIL_Check(half_or_Whole_day As Double)
        Dim bioNo As Integer = If(Integer.TryParse(CStr(BiometricID_TXT.Text), 0), CInt(BiometricID_TXT.Text), 0)
        Dim row As DataGridViewRow = DataGridView1.Rows(DataGridView1.CurrentRow.Index)
        Dim dateStarted As Date = CDate(GetData("DATEHIRED", $"TBL_EMPLOYEE WHERE BIOMETRICID = '{bioNo}'"))
        Dim oneYearAnniversary As Date = dateStarted.AddYears(1)
        Dim fiveYearAnniversary As Date = dateStarted.AddYears(5)
        Dim silDate As Date = CDate(DataGridView1.Rows(DataGridView1.CurrentRow.Index).Tag).ToString("d")
        Dim SIL_count As Integer = 0

        If silDate >= fiveYearAnniversary Then
            SIL_count = 10      'FIVE YEARS IN SERVICE
        ElseIf silDate >= oneYearAnniversary Then
            SIL_count = 5       'ONE YEAR IN SERVICE 
        End If

        Dim usedSIL As Double = Overall_SIL_Used(bioNo)
        Dim silPaydate As Double = Paydate_SIL_Used(bioNo, Paydate)
        Dim silExceptPaydate As Double = usedSIL - silPaydate
        Dim currentSIL As Double = CurrentSILCount()
        Dim totalSIL As Double = currentSIL + silExceptPaydate
        Dim allowable_SIL As Double = (SIL_count - totalSIL)

        If SIL_count > 0 Then
            Dim proposeSIL As Double = totalSIL + half_or_Whole_day
            If (allowable_SIL > 0) And (proposeSIL <= SIL_count) Then

                'Dim present As Boolean = row.Cells(5).Value
                'If present Then
                '    MsgBox("This employee is present on this date.", MsgBoxStyle.Exclamation, "Invalid")
                '    Exit Sub
                'End If

                If half_or_Whole_day = 0.5 Then
                    row.DefaultCellStyle.BackColor = Color.Aquamarine
                    row.Cells(2).Tag = half_or_Whole_day
                Else
                    row.DefaultCellStyle.BackColor = Color.MediumAquamarine
                    row.Cells(2).Tag = half_or_Whole_day
                End If

                SIL_LBL.Text = CurrentSILCount()
            Else
                MsgBox($"Only {allowable_SIL} SIL is available. The rest have been used.", MsgBoxStyle.Critical, "No more available SIL")
            End If
        Else
            MsgBox("Not yet allowed to avail SIL.", MsgBoxStyle.Critical, "Invalid")
        End If
    End Sub

    Private Sub Menu_SILHalfDay_Click(sender As Object, e As EventArgs) Handles Menu_SILHalfDay.Click
        SIL_Check(0.5)
    End Sub

    Private Sub Menu_SILWholeDay_Click(sender As Object, e As EventArgs) Handles Menu_SILWholeDay.Click
        SIL_Check(1)
    End Sub

    Private Sub SIL_BTN_Click(sender As Object, e As EventArgs) Handles SIL_BTN.Click
        ClearSIL()
    End Sub

    Private Sub Calculate_BTN_Click(sender As Object, e As EventArgs) Handles Calculate_BTN.Click
        If Name_TXT.Text <> Nothing Then
            TotalDays_LBL.Text = 0
            TotalRHoliday_LBL.Text = 0
            TotalRHoliday_LBL.Tag = 0
            TotalSHoliday_LBL.Text = 0
            TotalLateHR_LBL.Text = 0
            TotalUTHR_LBL.Text = 0
            TotalOTHr_LBL.Text = 0
            under_count = New TimeSpan(0, 0, 0, 0, 0)
            late_count = New TimeSpan(0, 0, 0, 0, 0)
            Late_days = 0
            Late_applied = False
            Dim product As Double = 0
            Dim sil As Double = 0
            Dim Present_FromWorkingSched As Double = 0

            Dim bioNum = BiometricID_TXT.Text
            Dim branchCode = GetBranchCode(bioNum)
            Dim dateStarted = GetData("DATEHIRED", $"TBL_EMPLOYEE WHERE BIOMETRICID = '{bioNum}'")
            emp_status = GetData("EMP_STATUS", $"TBL_EMPLOYEE WHERE BIOMETRICID = '{bioNum}'")
            dateEnded = GetData("DATE_ENDED", $"TBL_EMPLOYEE WHERE BIOMETRICID = '{bioNum}'")

            Dim PAYROLL As String
            If Paydate_ComboB.SelectedIndex >= 0 Then
                PAYROLL = Paydate_ComboB.SelectedItem
            Else
                PAYROLL = DataGridView1.Tag
            End If

            For Each row As DataGridViewRow In DataGridView1.Rows

                Dim DATEE As DateTime = row.Tag
                Dim am_in As String = row.Cells(1).Value
                Dim am_out As String = row.Cells(2).Value
                Dim pm_in As String = row.Cells(3).Value
                Dim pm_out As String = row.Cells(4).Value

                If Not row.DefaultCellStyle.ForeColor = Color.Red Then

#Region "WITHOUT REGULAR HOLIDAY DEDUCTION"

                    ''================================= CALCULATE HOLIDAYS  ===============================
                    'If row.DefaultCellStyle.BackColor = Color.MediumOrchid Then

                    '    If DATEE >= dateStarted Then
                    '        If emp_status = "INACTIVE" Then
                    '            If DATEE <= CDate(dateEnded).ToShortDateString Then
                    '                TotalRHoliday_LBL.Text = TotalRHoliday_LBL.Text + 1
                    '            Else
                    '                Console.WriteLine("INACTIVE - HOLIDAY NOT INCLUDED")
                    '            End If
                    '        Else
                    '            TotalRHoliday_LBL.Text = TotalRHoliday_LBL.Text + 1
                    '        End If
                    '    End If

                    'ElseIf row.DefaultCellStyle.BackColor = Color.Plum Then

                    '    If Paydate_ComboB.SelectedIndex >= 0 Then paydate_ = Paydate_ComboB.Text '======= IF PAYDATE SELECTED IN BIOMETRIC

                    '    If PRESENT_Date(bioNum, paydate_, row.Cells(0).Tag) Then
                    '        If row.Cells(0).Tag >= dateStarted Then
                    '            TotalSHoliday_LBL.Text = TotalSHoliday_LBL.Text + 1
                    '        End If
                    '    End If

                    'End If 

#End Region

                    '================================= CALCULATE HOLIDAYS ===============================
                    If row.DefaultCellStyle.BackColor = Color.MediumOrchid Then

                        Dim holidayDate As Date = CDate(row.Cells(0).Tag)

                        If holidayDate >= dateStarted Then

                            ' Get valid working days around holiday
                            Dim prevWorkDay As Date = GetPreviousWorkingDay(holidayDate)
                            Dim nextWorkDay As Date = GetNextWorkingDay(holidayDate)

                            Dim presentBefore As Boolean = IsPresent_FromGrid(prevWorkDay)
                            Dim presentAfter As Boolean = IsPresent_FromGrid(nextWorkDay)

                            If prevWorkDay < CDate(starting_date) Then
                                RegHolPresentNextWorkingDay.Visible = True
                                cbPresentPrevNextWorkingDay.Text = $"Present on {CDate(starting_date).AddDays(-1):M}"

                                If cbPresentPrevNextWorkingDay.Checked Then presentBefore = True
                            End If

                            If nextWorkDay > CDate(ending_date) Then
                                RegHolPresentNextWorkingDay.Visible = True
                                cbPresentPrevNextWorkingDay.Text = $"Present on {CDate(ending_date).AddDays(1):M}"

                                If cbPresentPrevNextWorkingDay.Checked Then presentAfter = True
                            End If

                            If presentBefore AndAlso presentAfter Then

                                If emp_status = "INACTIVE" Then
                                    If holidayDate <= CDate(dateEnded) Then
                                        TotalRHoliday_LBL.Text = CInt(TotalRHoliday_LBL.Text) + 1
                                    Else
                                        Console.WriteLine("INACTIVE - HOLIDAY NOT INCLUDED")
                                    End If
                                Else
                                    TotalRHoliday_LBL.Text = CInt(TotalRHoliday_LBL.Text) + 1
                                End If

                            Else
                                TotalRHoliday_LBL.Tag = CInt(TotalRHoliday_LBL.Tag) + 1
                                Console.WriteLine("HOLIDAY NOT COUNTED - ABSENT BEFORE AND AFTER")
                            End If

                        End If

                    ElseIf row.DefaultCellStyle.BackColor = Color.Plum Then

                        If Paydate_ComboB.SelectedIndex >= 0 Then
                            paydate_ = Paydate_ComboB.Text
                        End If

                        'If PRESENT_Date(bioNum, paydate_, CDate(row.Cells(0).Tag)) Then
                        If CBool(row.Cells(5).Value) Then   'IF CHECKED PRESENT
                            If CDate(row.Cells(0).Tag) >= dateStarted Then
                                TotalSHoliday_LBL.Text = CInt(TotalSHoliday_LBL.Text) + 1
                            End If
                        End If

                    End If

                End If

                '======================== GET TIME IN/OUT TO CALCULATE LATE UNDERTIME OVERTIME ============================  
                If CheckData("BIO_NO", $"PAYROLL_SCHEDULE WHERE BIO_NO = '{bioNum}' AND PAYDATE = '{PAYROLL}'") Then
                    If row.Cells(5).Value = True Then
                        If DateExist_IN_Schedule(bioNum, DATEE.ToShortDateString) Then

                            Dim timeIN As DateTime = Nothing
                            Dim timeOut As DateTime = Nothing

                            If DateTime.TryParse(GetData("TIME_IN", $"PAYROLL_SCHEDULE WHERE BIO_NO = '{bioNum}' AND DATEE = '{DATEE.ToShortDateString}' "), timeIN) Then
                                TIME_IN = timeIN
                            ElseIf GetData("TIME_IN", $"PAYROLL_SCHEDULE WHERE BIO_NO = '{bioNum}' AND DATEE = '{DATEE.ToShortDateString}' ") = "SIL" Then
                                sil += 0.5
                                SIL_LBL.Text = sil
                            End If

                            If DateTime.TryParse(GetData("TIME_OUT", $"PAYROLL_SCHEDULE WHERE BIO_NO = '{bioNum}' AND DATEE = '{DATEE.ToShortDateString}' "), timeOut) Then
                                TIME_OUT = timeOut

                                If TIME_OUT > TIME_IN.AddHours(9) Then
                                    TIME_OUT = TIME_IN.AddHours(9)
                                    ALLOW_OT = True
                                Else
                                    ALLOW_OT = False
                                End If
                            ElseIf GetData("TIME_OUT", $"PAYROLL_SCHEDULE WHERE BIO_NO = '{bioNum}' AND DATEE = '{DATEE.ToShortDateString}' ") = "SIL" Then
                                sil += 0.5
                                SIL_LBL.Text = sil
                            End If

                            Dim forTempHalfDay As Integer = 0
                            '=================== IF HALFDAY LANG ANG RD, AL, SIL ===============
                            If timeIN = Nothing And timeOut = Nothing Then
                                Continue For
                            ElseIf timeIN <> Nothing And timeOut = Nothing Then
                                TIME_IN = timeIN
                                TIME_OUT = timeIN.AddHours(4)

                                If am_in <> Nothing Then '======== IF PRESENT AM IN
                                    Present_FromWorkingSched += 0.5
                                    forTempHalfDay += 4
                                End If
                            ElseIf timeIN = Nothing And timeOut <> Nothing Then
                                TIME_IN = timeOut
                                TIME_OUT = timeOut.AddHours(4)

                                If pm_in <> Nothing Then  '======== IF PRESENT PM IN
                                    Present_FromWorkingSched += 0.5
                                    forTempHalfDay += 4
                                End If
                            Else
                                If am_in <> Nothing And am_out <> Nothing And pm_in <> Nothing And pm_out <> Nothing Then
                                    Present_FromWorkingSched += 1
                                Else
                                    Present_FromWorkingSched += 0.5 '======== IF HALFDAY EXAMPLE AM_IN AND AM_OUT LANG
                                    forTempHalfDay += 4
                                End If
                            End If

                            '=========================== MINIMUM RATE CHANGED STARTED SEPTEMBER 1, 2022 ONLY (JUNE 30, 2022)=====================  
                            If ThisHasRow($"CHANGE_MINIMUM_RATE WHERE PAYDATE = '{paydate_}'") AndAlso ThisHasRow($"TBL_EMPLOYEE WHERE BIOMETRICID = '{bioNum}' AND MINIMUM_RATE_UPDATED_AT = '{paydate_}'") Then
                                Dim newMin_startingDate As Date = GetData("STARTING_DATE", $"CHANGE_MINIMUM_RATE WHERE PAYDATE = '{paydate_}'")
                                Dim short_date As String = DATEE.ToShortDateString

                                If short_date = newMin_startingDate.AddDays(-1) Then
                                    temp_present = Present_FromWorkingSched
                                    temp_half = forTempHalfDay
                                End If
                            End If

                        Else
                            TIME_IN = GetData("VALUEE", $"PAYROLL_DEFAULT_TIMEIN")
                            TIME_OUT = TIME_IN.AddHours(9)
                        End If

                    End If
                Else
                    TIME_IN = GetTimeInOut(bioNum).Time_in
                    TIME_OUT = GetTimeInOut(bioNum).Time_out
                End If

                CalculateLATE(row, TIME_IN)

                CalculateuNDERTIME(row, TIME_IN, TIME_OUT)

                CalculateuOVERTIME(row, TIME_OUT)

                '=========================== MINIMUM RATE CHANGED STARTED SEPTEMBER 1, 2022 ONLY (JUNE 30, 2022)=====================  
                If ThisHasRow($"CHANGE_MINIMUM_RATE WHERE PAYDATE = '{paydate_}'") AndAlso ThisHasRow($"TBL_EMPLOYEE WHERE BIOMETRICID = '{bioNum}' AND MINIMUM_RATE_UPDATED_AT = '{paydate_}'") Then
                    Dim newMin_startingDate As Date = GetData("STARTING_DATE", $"CHANGE_MINIMUM_RATE WHERE PAYDATE = '{paydate_}'")
                    Dim short_date As String = DATEE.ToShortDateString
                    If short_date = newMin_startingDate.AddDays(-1) Then
                        temp_overtime = TotalOTHr_LBL.Text
                        temp_late = late_count.TotalMinutes
                        temp_undertime = under_count.TotalMinutes
                    End If
                End If

            Next

            TotalLateHR_LBL.Text = late_count.TotalMinutes

            TotalUTHR_LBL.Text = under_count.TotalMinutes

            TotalOTHr_LBL.Text = CDbl(TotalOTHr_LBL.Text) + AM_OT_NUP.Value

            'TODO - INACTIVE REGULAR HOLIDAY
            '=========================== MINIMUM RATE CHANGED STARTED SEPTEMBER 1, 2022 ONLY (JUNE 30, 2022)===================== 
            If ThisHasRow($"CHANGE_MINIMUM_RATE WHERE PAYDATE = '{paydate_}'") AndAlso ThisHasRow($"TBL_EMPLOYEE WHERE BIOMETRICID = '{bioNum}' AND MINIMUM_RATE_UPDATED_AT = '{paydate_}'") Then
                Dim newMin_startingDate As Date = GetData("STARTING_DATE", $"CHANGE_MINIMUM_RATE WHERE PAYDATE = '{paydate_}'")
                temp_Rholiday = REGHolidayCount(newMin_startingDate.AddDays(-1), ending_date)
                temp_Sholiday = SPECHolidayCount(newMin_startingDate.AddDays(-1), ending_date)
            End If

            '===================================== SUM UP PRESENT AND ABSENT ====================================    
            If Present_FromWorkingSched = 0 Then '=============== HEAD OFFICE

                Dim Present As Integer = 0
                Dim halfday_Hour As Integer = 0

                For Each oRow As DataGridViewRow In DataGridView1.Rows

                    If oRow.Cells(5).Value = True Then
                        Present += 1
                    End If

                    If CountCELL_Nothing(oRow) = 3 Or CountCELL_Consecutive(oRow) = "HALFDAY" Then
                        halfday_Hour += 4
                    End If

                    '=========================== MINIMUM RATE CHANGED STARTED SEPTEMBER 1, 2022 ONLY (JUNE 30, 2022)=====================  
                    If ThisHasRow($"CHANGE_MINIMUM_RATE WHERE PAYDATE = '{paydate_}'") AndAlso ThisHasRow($"TBL_EMPLOYEE WHERE BIOMETRICID = '{bioNum}' AND MINIMUM_RATE_UPDATED_AT = '{paydate_}'") Then
                        Dim newMin_startingDate As Date = GetData("STARTING_DATE", $"CHANGE_MINIMUM_RATE WHERE PAYDATE = '{paydate_}'")
                        Dim DATEE As DateTime = oRow.Tag
                        Dim short_date As String = DATEE.ToShortDateString

                        If short_date = newMin_startingDate.AddDays(-1) Then
                            temp_present = Present
                            temp_half = halfday_Hour
                        End If
                    End If

                Next

                '===================================== SUM UP HALF DAY ==================================== 
                product = ((Convert.ToInt32(Present) * 8)) - halfday_Hour
                product = product / 8
                TotalDays_LBL.Text = product

            Else '=============== BRANCHES WITH WORKING SCHEDULE
                TotalDays_LBL.Text = Present_FromWorkingSched
            End If

            late_count = New TimeSpan(0, 0, 0, 0, 0)
            under_count = New TimeSpan(0, 0, 0, 0, 0)
        Else
            MsgBox("Please Enter Employee's Name.", MsgBoxStyle.Critical, "Error")
        End If

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
            SavePI_Additional_Days(PI_Days.Value, paydatee, "HEAD OFFICE")
        End If

        P_Add_Panel.Visible = False
    End Sub

    Private Sub Cancel_lbl_Click(sender As Object, e As EventArgs) Handles Cancel_lbl.Click
        AM_OT_NUP.Value = 0.0
    End Sub

    Private Sub Bio2_DTR_TXT_TextChanged(sender As Object, e As EventArgs) Handles Bio2_DTR_TXT.TextChanged
        If Bio2_DTR_TXT.Text = "" Then
            DTR_Emp2_TXT.Text = ""
        Else
            GetName(Bio2_DTR_TXT.Text, DTR_Emp2_TXT)
        End If
    End Sub

    Private Sub Paydate7_CB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Paydate7_CB.SelectedIndexChanged
        Cancel7_BTN.PerformClick()

        If Paydate7_CB.SelectedIndex >= 0 Then
            paydate_ = Paydate7_CB.SelectedItem
        Else
            paydate_ = Paydate.ToString("d")
        End If

        PopulateBiometricSHEET(Branch_LV, paydate_, True)
    End Sub

    Private Sub Search7_BTN_Click(sender As Object, e As EventArgs) Handles Search7_BTN.Click
        PopulateBiometricSHEET(Branch_LV, Paydate, True, Search7_TXT.Text)
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

        Has_Rows_Delete($"IMPORT_DTR where PAYDATE <> '{Paydate.ToShortDateString}'") '===== EMPTY THIS TABLE

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
        PopulateComboBox(Paydate_ComboB, "BIOMETRIC_DTR", "PAYDATE", True)
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

                    If frmMainForm.AppProgressBar.Value <> DtSet.Tables(0).Rows.Count Then frmMainForm.AppProgressBar.Value += 1

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

            Dim DATEE As DateTime = Nothing
            Dim groups_time, list_hour As New List(Of String)()

            '=============== BIO NUMBER ================
            If eCell(row, 2).Value <> Nothing Then
                bio_no = eCell(row, 2).Value
                If ThisHasRow($"BIOMETRIC_DTR where BIO_ID = '{bio_no}' and PAYDATE = '{Paydate.ToShortDateString}'") Then Replacing($"BIOMETRIC_DTR where BIO_ID = '{bio_no}' and PAYDATE = '{Paydate.ToShortDateString}';") 'TO REPLACE EXISTING RECORD =========================
            End If

            Dim column_ As Integer = 3

            '========================= IF NOT VALID DATE ==================
            While (column_ <= 5)
                Dim date_ As DateTime
                If DateTime.TryParse(eCell(row, column_).Value, date_) Then
                    DATEE = date_
                    Exit While
                Else
                    column_ += 1
                End If
            End While

            If CheckData("BIO_NO", $"PAYROLL_SCHEDULE WHERE BIO_NO = '{bio_no}'") Then

                If DateExist_IN_Schedule(bio_no, DATEE.ToShortDateString) Then
                    Dim valuee_in As String = GetData("TIME_IN", $"PAYROLL_SCHEDULE WHERE BIO_NO = '{bio_no}' AND DATEE = '{DATEE.ToShortDateString}' ")

                    If valuee_in = "RD" Or valuee_in = "AL" Or valuee_in = "SIL" Or valuee_in = "AWOP" Then

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

            '=============== CHECK PER CELL IN A ROW ============= 
            For column = 5 To 13

                Dim time As DateTime

                '========================= IF NOT VALID TIME ==================  
                Try
                    time = (New DateTime()).AddDays(eCell(row, column).Value)
                Catch ex As Exception
                    Continue For
                End Try


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
                        SaveDTR(bio_no, Paydate, DATEE.ToShortDateString, new_list(0), new_list(1), new_list(2), new_list(3))

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

            'ONLY FOR JEN PC TESTING
            If Environment.MachineName = "JEN" Then
                Dim connStr As String = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={Path_TXT.Text};Extended Properties='Excel 12.0 Xml;HDR=YES';"
                MyConnection = New System.Data.OleDb.OleDbConnection(connStr)
            End If

            MyCommand = New System.Data.OleDb.OleDbDataAdapter($"select * from [{eSheet.Name}$]", MyConnection)
            MyCommand.TableMappings.Add("Table", "Net-informations.com")
            DtSet = New System.Data.DataSet
            MyCommand.Fill(DtSet)

            distinct_bio.Clear()
            list_inOut.Clear()

            progressBarStart(DtSet.Tables(0).Rows.Count)

            For row = 1 To DtSet.Tables(0).Rows.Count
                If IsNumeric(eCell(row, 3).Value) Then
                    SaveBiometricSheet(Paydate, eCell(row, 3).Value, eCell(row, 4).Value)
                    distinct_bio.Add(eCell(row, 3).Value)

                    frmMainForm.AppProgressBar.Value += 1
                Else
                    Continue For
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
            Console.WriteLine(ex.ToString)
            MsgBox("Excel is open or inaccessible!" & vbNewLine & ex.ToString, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub SAVE_DIRECT_Attendance()
        LoadDateTime()
        TempAttendance()

        Dim paydate_ As String = Paydate.ToString("d")

        '======================== HOLIDAY ============================ 
        'Dim RHOLIDAY As Integer = REGHolidayCount(starting_date, ending_date) 
        Dim RHOLIDAY As Integer = 0
        Dim regHol_deduction As Integer = 0
        Dim SHOLIDAY As Integer = SPECHolidayCount(starting_date, ending_date)

        distinct_bio = distinct_bio.Distinct.ToList

        progressBarStart(distinct_bio.Count)
        For Each biometric_No As String In distinct_bio

            Dim dateStarted = GetData("DATEHIRED", $"TBL_EMPLOYEE WHERE BIOMETRICID = '{biometric_No}'")
            emp_status = GetData("EMP_STATUS", $"TBL_EMPLOYEE WHERE BIOMETRICID = '{biometric_No}'")
            dateEnded = GetData("DATE_ENDED", $"TBL_EMPLOYEE WHERE BIOMETRICID = '{biometric_No}'")

            Dim all_date, exist_date, add_date As New List(Of String)()

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

                            'POPULATE FIRST THE DataGridView1 FROM TABLE
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
            Dim specHoliday_hrs As Integer = 0

            '========= TEMPORARY FOR PAYDATE 6/30/2022 ===========  
            temp_present = 0
            temp_half = 0
            temp_overtime = 0
            temp_late = 0
            temp_undertime = 0

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

                    Dim list_ As New List(Of String)
                    list_.Add(row.Cells(1).Value)
                    list_.Add(row.Cells(2).Value)
                    list_.Add(row.Cells(3).Value)
                    list_.Add(row.Cells(4).Value)
                    list_ = list_.Where(Function(s) Not String.IsNullOrEmpty(s)).ToList()

                    'specHoliday_hrs
                    'Dim hrs As Integer = GetSpecial_hrs(list_.First, list_.Last, biometric_No)
                    'specHoliday_hrs += hrs

                    If list_.Any() AndAlso list_.Count >= 2 Then
                        Dim timeStart = list_(0)
                        Dim timeEnd = list_(list_.Count - 1)

                        Dim hrs As Integer = GetSpecial_hrs(timeStart, timeEnd, biometric_No)
                        specHoliday_hrs += hrs
                    End If

                End If

#Region "TO DELETE"

                ''============================== TOTAL SPECIAL HOLIDAY BASE ON TOTAL HOURS OF DUTY ==================== 
                'If DataeXIST($" PAYROLL_HOLIDAY WHERE DATEE = '{DATEE.ToString("MMMM d")}' AND KINDS = 'SPECIAL'") Then

                '    If DataeXIST($" PAYROLL_SCHEDULE WHERE BIO_NO = '{biometric_No}' AND DATEE = '{DATEE.ToShortDateString}'") Then
                '        Dim list_ As New List(Of String)
                '        list_.Add(row.Cells(1).Value)
                '        list_.Add(row.Cells(2).Value)
                '        list_.Add(row.Cells(3).Value)
                '        list_.Add(row.Cells(4).Value)
                '        list_ = list_.Where(Function(s) Not String.IsNullOrEmpty(s)).ToList()

                '        'specHoliday_hrs
                '        Dim hrs As Integer = GetSpecial_hrs(list_.First, list_.Last, biometric_No)
                '        Dim hrss As Integer = hrs / 8
                '        Dim hrsss As Integer = hrss * 8
                '        specHoliday_hrs += hrsss
                '    End If

                'End If
#End Region

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

                '=========================== MINIMUM RATE CHANGED =====================  
                If ThisHasRow($"CHANGE_MINIMUM_RATE WHERE PAYDATE = '{paydate_}'") AndAlso ThisHasRow($"TBL_EMPLOYEE WHERE BIOMETRICID = '{biometric_No}' AND MINIMUM_RATE_UPDATED_AT = '{paydate_}'") Then
                    Dim newMin_startingDate As Date = GetData("STARTING_DATE", $"CHANGE_MINIMUM_RATE WHERE PAYDATE = '{paydate_}'")
                    If DATEE.ToShortDateString = newMin_startingDate.AddDays(-1) Then
                        temp_present = Present
                        temp_half = halfday_Hour
                        temp_overtime = TotalOTHr_LBL.Text
                        temp_late = late_count.TotalMinutes
                        temp_undertime = under_count.TotalMinutes
                    End If
                End If

                Console.WriteLine(DATEE)
                '================================= CALCULATE HOLIDAYS ===============================
                If row.DefaultCellStyle.BackColor = Color.MediumOrchid Then

                    Dim holidayDate As Date = CDate(row.Cells(0).Tag)

                    If holidayDate >= dateStarted Then

                        ' Get valid working days around holiday
                        Dim prevWorkDay As Date = GetPreviousWorkingDay(holidayDate)
                        Dim nextWorkDay As Date = GetNextWorkingDay(holidayDate)

                        Dim presentBefore As Boolean = IsPresent_FromGrid(prevWorkDay)
                        Dim presentAfter As Boolean = IsPresent_FromGrid(nextWorkDay)

                        If presentBefore AndAlso presentAfter Then

                            If emp_status = "INACTIVE" Then
                                If holidayDate <= CDate(dateEnded) Then
                                    RHOLIDAY += 1
                                Else
                                    Console.WriteLine("INACTIVE - HOLIDAY NOT INCLUDED")
                                End If
                            Else
                                RHOLIDAY += 1
                            End If

                        Else
                            regHol_deduction += 1
                            Console.WriteLine("HOLIDAY NOT COUNTED - ABSENT BEFORE AND AFTER")
                        End If

                    End If
                End If

            Next

            TotalDays_LBL.Text = Present

            Dim product As Double
            product = ((Convert.ToInt32(TotalDays_LBL.Text) * 8)) - halfday_Hour
            product = product / 8
            TotalDays_LBL.Text = product

            '========== FOR EXCEEDING DAYS OF LATE (MORE THAN 2 DAYS OF LATE THIS WILL APPLIED)==========
            If Late_applied = True Then
                Late_percentage = LatePercentage(biometric_No, paydate_, late_count.TotalMinutes)
            End If

            SaveAttendanceEE(biometric_No, paydate_, TotalDays_LBL.Text, TotalOTHr_LBL.Text, late_count.TotalMinutes, under_count.TotalMinutes,
                             RHOLIDAY, SHOLIDAY, specHoliday_hrs, 0, Late_percentage, Nothing, Nothing, regHol_deduction)

            InsertTempAttendance(biometric_No, paydate_, TotalDays_LBL.Text, TotalOTHr_LBL.Text,
                                    late_count.TotalMinutes, under_count.TotalMinutes, RHOLIDAY, SHOLIDAY)

            '===================================== MINIMUM CHANGED =================================  
            If ThisHasRow($"CHANGE_MINIMUM_RATE WHERE PAYDATE = '{paydate_}'") AndAlso ThisHasRow($"TBL_EMPLOYEE WHERE BIOMETRICID = '{biometric_No}' AND MINIMUM_RATE_UPDATED_AT = '{paydate_}'") Then
                Dim newMin_startingDate As Date = GetData("STARTING_DATE", $"CHANGE_MINIMUM_RATE WHERE PAYDATE = '{paydate_}'")
                If biometric_No <> Nothing Then
                    Dim old_days As Double
                    old_days = (temp_present * 8) - temp_half
                    old_days = old_days / 8
                    Dim new_days As Double = product - old_days
                    Dim new_overtime As Double = CDbl(TotalOTHr_LBL.Text) - temp_overtime
                    Dim new_late As Double = CDbl(late_count.TotalMinutes) - temp_late
                    Dim new_undertime As Double = CDbl(under_count.TotalMinutes) - temp_undertime
                    temp_Rholiday = REGHolidayCount(newMin_startingDate.AddDays(-1), ending_date) '================= CALCULATE HOLIDAYS COVERED  
                    temp_Sholiday = SPECHolidayCount(newMin_startingDate.AddDays(-1), ending_date) '================= CALCULATE HOLIDAYS COVERED  
                    SaveTemporary(biometric_No, old_days, new_days, temp_overtime, new_overtime, temp_late, new_late, temp_undertime, new_undertime, temp_Rholiday, temp_Sholiday, paydate_)
                End If
            End If

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

        PIDays_lbl.Text = GetData_Decimal("HO_NO_OF_DAYS", $"PAYROLL_PI_DAYS WHERE PAYDATE='{paydate_}'")
        B_PIDays_lbl.Text = GetData_Decimal("BRANCH_NO_OF_DAYS", $"PAYROLL_PI_DAYS WHERE PAYDATE='{paydate_}'")

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

    Friend Sub GetSILDates(bioNo As Integer, paydate As String)
        Dim mysql As String = $"SELECT * FROM PAYROLL_SIL WHERE BIONO = {bioNo} AND PAYDATE = '{paydate}'"
        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_SIL")
            If ds.Tables(0).Rows.Count > 0 Then
                For Each dr In ds.Tables(0).Rows
                    With dr
                        Dim SIL_DATE As Date = CDate(.item("SIL_DATE"))
                        Dim count As Double = .item("COUNT")
                        For Each row As DataGridViewRow In DataGridView1.Rows
                            If SIL_DATE = CDate(row.Tag) Then
                                row.Cells(2).Tag = count

                                If count = 0.5 Then
                                    row.DefaultCellStyle.BackColor = Color.Aquamarine
                                Else
                                    row.DefaultCellStyle.BackColor = Color.MediumAquamarine
                                End If
                            End If
                        Next
                    End With
                Next
            End If
        End Using
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

            For Each oRow As DataGridViewRow In DataGridView1.Rows
                oRow.Cells(5).Value = False
                For cell As Integer = 1 To 4
                    oRow.Cells(cell).Value = Nothing
                Next
            Next

        Else

            GetName(BiometricID_TXT.Text, Name_TXT)

            ClearSIL()
            SIL_LBL.Text = Get_SIL("PAYROLL_ATTENDANCE", $"PAYROLL_ATTENDANCE WHERE BIOMETRICID = '{BiometricID_TXT.Text}' AND PAYDATE = '{PAYROLL}'") + Get_SIL("PAYROLL_SCHED_COUNT", $"PAYROLL_SCHED_COUNT WHERE BIO_NO = '{BiometricID_TXT.Text}' AND PAYDATE = '{PAYROLL}'")

            If CDbl(SIL_LBL.Text) > 0 Then
                GetSILDates(BiometricID_TXT.Text, PAYROLL)
            End If

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

                                If IsDBNull(.Item("LATE_APPROVED")) Then
                                    row.Cells(1).Style.ForeColor = Color.Black
                                Else
                                    row.Cells(1).Style.ForeColor = Color.Blue
                                    Late_approved += IIf(IsDBNull(.Item("LATE_MIN_APPROVED")), 0, .Item("LATE_MIN_APPROVED"))
                                End If

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
                With dsS.Tables(0).Rows(0)

                    TotalDays_LBL.Text = .Item("PRESENT_DAYS")
                    TotalRHoliday_LBL.Text = .Item("REGHOLIDAY")
                    TotalSHoliday_LBL.Text = .Item("SPECHOLIDAY")
                    TotalLateHR_LBL.Text = .Item("LATE")
                    TotalUTHR_LBL.Text = .Item("UNDERTIME")
                    TotalOTHr_LBL.Text = .Item("OVERTIME")
                    AM_OT_NUP.Value = IIf(IsDBNull(.Item("MORNING_OT")), 0, .Item("MORNING_OT"))
                    TotalLateHR_LBL.Tag = IIf(IsDBNull(.Item("LATE_APPROVED")), 0, .Item("LATE_APPROVED"))

                End With

                Calculate_BTN.PerformClick()

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