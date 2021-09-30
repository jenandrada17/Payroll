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
    Dim dateee As DateTime
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

        Dim array() As String = {".HO ACCOUNTING", ".HO ADMIN", ".HO HR", ".HO MAIN", ".HO REMATADO", ".HO WAREHOUSE"}

    End Sub

    Private Sub Close_LBL_Click(sender As Object, e As EventArgs) Handles Close_LBL.Click
        Close()
    End Sub

    Public Sub LoadDateTime(Optional datee As DateTime = Nothing)

        TotalAbsent_LBL.Text = 0
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
                    'DataGridView1.Rows(i).Cells(5) = New DataGridViewTextBoxCell()
                    'DataGridView1.Rows(i).Cells(5).ReadOnly = True
                    'DataGridView1.Rows(i).Cells(1).Value = ""
                    'DataGridView1.Rows(i).Cells(1).ReadOnly = True
                    'DataGridView1.Rows(i).Cells(2).Value = ""
                    'DataGridView1.Rows(i).Cells(1).ReadOnly = True
                    'DataGridView1.Rows(i).Cells(3).Value = ""
                    'DataGridView1.Rows(i).Cells(1).ReadOnly = True
                    'DataGridView1.Rows(i).Cells(4).Value = ""
                    'DataGridView1.Rows(i).Cells(1).ReadOnly = True

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

            If oRow.Cells(5).Value = True Then
                Present += 1
            End If
            'If Not oRow.DefaultCellStyle.ForeColor = Color.Red And oRow.Cells(5).Value = True Then
            '    Present += 1
            'ElseIf Not oRow.DefaultCellStyle.ForeColor = Color.Red And oRow.Cells(5).Value = False Then
            '    If Not oRow.DefaultCellStyle.BackColor = Color.MediumOrchid Or Not oRow.DefaultCellStyle.BackColor = Color.Plum Then
            '        Absent += 1
            '    End If
            'End If
        Next

        TotalDays_LBL.Text = Present
        'TotalAbsent_LBL.Text = Absent


        '===================================== SUM UP HALF DAY ====================================  
        Dim halfday_Hour As Integer = 0
        For Each oRow As DataGridViewRow In DataGridView1.Rows

            If CountCELL_Nothing(oRow) = 3 Or CountCELL_Consecutive(oRow) = "HALFDAY" Then
                halfday_Hour += 4
            End If
        Next

        'If halfday_Hour = 4 Then

        '    TotalAbsent_LBL.Text = Convert.ToInt32(TotalAbsent_LBL.Text) + 0.5

        'ElseIf halfday_Hour > 4 Then

        '    Dim result As Integer
        '    result = halfday_Hour / 8

        '    TotalAbsent_LBL.Text = result + Convert.ToInt32(TotalAbsent_LBL.Text)
        'End If

        Dim product As Double
        product = ((Convert.ToInt32(TotalDays_LBL.Text) * 8)) - halfday_Hour
        product = product / 8
        TotalDays_LBL.Text = product
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
        BiometricID_TXT.Clear()
        Name_TXT.Clear()
        CheckALL_CheckBox.Checked = False
        TotalAbsent_LBL.Text = 0
        TotalDays_LBL.Text = 0
        TotalRHoliday_LBL.Text = 0
        TotalSHoliday_LBL.Text = 0
        TotalLateHR_LBL.Text = 0
        TotalUTHR_LBL.Text = 0
        TotalOTHr_LBL.Text = 0
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

            Replacing($"BIOMETRIC_DTR where BIO_ID = '{BiometricID_TXT.Text}' and PAYDATE = '{PAYROLL}';")

            For Each row As DataGridViewRow In DataGridView1.Rows

                Dim dateOnly As DateTime = DataGridView1.Rows(row.Index).Tag

                If row.Cells(1).Value = "" And row.Cells(2).Value = "" And row.Cells(3).Value = "" And row.Cells(4).Value = "" Then
                Else
                    SaveDTR(BiometricID_TXT.Text, Paydate, dateOnly.ToString("d"),
                        row.Cells(1).Value, row.Cells(2).Value, row.Cells(3).Value, row.Cells(4).Value)
                End If

            Next

            SaveAttendanceEE(BiometricID_TXT.Text, PAYROLL, TotalDays_LBL.Text, TotalOTHr_LBL.Text, TotalLateHR_LBL.Text, TotalUTHR_LBL.Text,
                             TotalRHoliday_LBL.Text, TotalSHoliday_LBL.Text)

            SavePayout_IndividualL(BiometricID_TXT.Text, PAYROLL, startingDate, EndingDate)

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

        Try
            Dim all_in As New dtr_all.overAllDataTable

            Dim dt_DTR As New DataTable()
            With dt_DTR
                .Columns.Add("BIOMETRICID")
                .Columns.Add("FULLNAME")
                .Columns.Add("PRESENT_DAYS")
                .Columns.Add("OVERTIME")
                .Columns.Add("LATE")
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

                    mysqll = $"Select A.*, B.FULLNAME, B.BIO_NO as bioNo, C.* From PAYROLL_ATTENDANCE A 
                                        inner JOIN PAYROLL_EMPLOYEE B ON B.BIO_NO = A.BIOMETRICID 
                                        inner join BIOMETRIC_DTR C ON C.BIO_ID = A.BIOMETRICID where A.PAYDATE  = '{paydatee}' and A.BIOMETRICID IN ('{Bio1_DTR_TXT.Text}','{Bio2_DTR_TXT.Text}') ORDER BY DATE_ONLY"
                Else
                    If Bio1_DTR_TXT.Text <> Nothing And Bio2_DTR_TXT.Text = Nothing Then  '============ 1ST EMPLOYEE

                        mysqll = $"Select A.*, B.FULLNAME, B.BIO_NO as bioNo, C.* From PAYROLL_ATTENDANCE A 
                                        inner JOIN PAYROLL_EMPLOYEE B ON B.BIO_NO = A.BIOMETRICID 
                                        inner join BIOMETRIC_DTR C ON C.BIO_ID = A.BIOMETRICID where A.PAYDATE  = '{paydatee}' and A.BIOMETRICID = '{Bio1_DTR_TXT.Text}'  ORDER BY DATE_ONLY"

                    ElseIf Bio2_DTR_TXT.Text <> Nothing And Bio1_DTR_TXT.Text = Nothing Then '============ 2ND EMPLOYEE

                        mysqll = $"Select A.*, B.FULLNAME, B.BIO_NO as bioNo, C.* From PAYROLL_ATTENDANCE A 
                                        inner JOIN PAYROLL_EMPLOYEE B ON B.BIO_NO = A.BIOMETRICID 
                                        inner join BIOMETRIC_DTR C ON C.BIO_ID = A.BIOMETRICID where A.PAYDATE  = '{paydatee}' and A.BIOMETRICID = '{Bio2_DTR_TXT.Text}'  ORDER BY DATE_ONLY"

                    Else
                        MsgBox("Please Select Employee Name!")
                    End If
                End If

            ElseIf HO_RadioB.Checked Then    '=========================== HEAD OFFICE ==================================

                mysqll = $"Select A.*, B.FULLNAME, B.BIO_NO as bioNo, C.* From PAYROLL_ATTENDANCE A 
                                        inner JOIN PAYROLL_EMPLOYEE B ON B.BIO_NO = A.BIOMETRICID 
                                        inner join BIOMETRIC_DTR C ON C.BIO_ID = A.BIOMETRICID  
                                        where A.PAYDATE  = '{paydatee}' and COMPANY = 'HEAD OFFICE'  ORDER BY DATE_ONLY"

            End If

            Using ds As DataSet = LoadSQL(mysqll, "PAYROLL_ATTENDANCE")

                If ds.Tables(0).Rows.Count > 0 Then

                    For Each dr In ds.Tables(0).Rows
                        With dr

                            '============================= NAME AND ATTENDANCE ============================  
                            Dim namee As String = .Item("FULLNAME")
                            Dim bioNo As String = .Item("bioNo")
                            Dim DAYS As String = .Item("PRESENT_DAYS")
                            Dim OT As String = IIf(.Item("OVERTIME") = 0, 0, .Item("OVERTIME"))
                            Dim LATE As String = IIf(.Item("LATE").Equals("00:00:00"), "00:00:00", .Item("LATE").Substring(0, 5))
                            Dim REGHOLIDAY As String = .Item("REGHOLIDAY")
                            Dim SPECHOLIDAY As String = .Item("SPECHOLIDAY")


                            '============================= BIOMETRIC_DTR ============================
                            Dim dateE As DateTime = Convert.ToDateTime(.Item("DATE_ONLY"))
                            Dim AM_IN = IIf(IsDBNull(.Item("AM_IN")), "", .Item("AM_IN"))
                            Dim AM_OUT = IIf(IsDBNull(.Item("AM_OUT")), "", .Item("AM_OUT"))
                            Dim PM_IN = IIf(IsDBNull(.Item("PM_IN")), "", .Item("PM_IN"))
                            Dim PM_OUT = IIf(IsDBNull(.Item("PM_OUT")), "", .Item("PM_OUT"))

                            dt_DTR.Rows.Add(bioNo, namee, DAYS, OT, LATE, dateE.ToString("MMM dd, yyyy"), AM_IN, AM_OUT, PM_IN, PM_OUT, REGHOLIDAY, SPECHOLIDAY)

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

        Try
            Dim all_in As New dtr_all.overAllDataTable

            Dim dt_DTR As New DataTable()
            With dt_DTR
                .Columns.Add("FULLNAME")
                .Columns.Add("PRESENT_DAYS")
                .Columns.Add("OVERTIME")
                .Columns.Add("LATE")
                .Columns.Add("DATE_ONLY")
                .Columns.Add("AM_IN")
                .Columns.Add("AM_OUT")
                .Columns.Add("PM_IN")
                .Columns.Add("PM_OUT")
            End With

            mysqll = $"Select * From PAYROLL_ATTENDANCE A 
                                        inner JOIN PAYROLL_EMPLOYEE B ON B.BIO_NO = A.BIOMETRICID 
                                        inner join BIOMETRIC_DTR C ON C.BIO_ID = B.BIO_NO 
                                        where A.PAYDATE  = '{paydatee}' and B.BRANCH_CODE = '{DTR_Branch_Combo.Text}'  ORDER BY DATE_ONLY"

            Using ds As DataSet = LoadSQL(mysqll, "PAYROLL_EMPLOYEE")

                If ds.Tables(0).Rows.Count > 0 Then

                    For Each dr In ds.Tables(0).Rows
                        With dr

                            '============================= NAME AND ATTENDANCE ============================ 
                            Dim namee As String = .Item("FULLNAME")
                            Dim DAYS As String = .Item("PRESENT_DAYS")
                            Dim OT As String = IIf(.Item("OVERTIME") = 0, 0, .Item("OVERTIME"))
                            Dim LATE As String = IIf(.Item("LATE").Equals("00:00:00"), "00:00:00", .Item("LATE").Substring(0, 5))

                            '============================= BIOMETRIC_DTR ============================
                            Dim dateE As DateTime = Convert.ToDateTime(.Item("DATE_ONLY"))
                            Dim AM_IN = IIf(IsDBNull(.Item("AM_IN")), "", .Item("AM_IN"))
                            Dim AM_OUT = IIf(IsDBNull(.Item("AM_OUT")), "", .Item("AM_OUT"))
                            Dim PM_IN = IIf(IsDBNull(.Item("PM_IN")), "", .Item("PM_IN"))
                            Dim PM_OUT = IIf(IsDBNull(.Item("PM_OUT")), "", .Item("PM_OUT"))

                            dt_DTR.Rows.Add(namee, DAYS, OT, LATE, dateE.ToString("MMM dd, yyyy"), AM_IN, AM_OUT, PM_IN, PM_OUT)

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

        Dim paydate_ As String = Paydate.ToString("d")
        distinct_bio = distinct_bio.Distinct().ToList

        For Each biometric_No As String In distinct_bio
            list_inOut.Clear()

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

                    If time >= "5:00 AM" And time <= "11:59 AM" Then
                        If list_hour(0) = "" Then

                            list_hour(0) = time.ToString("t")
                        Else
                            list_hour(1) = time.ToString("t")
                        End If

                    ElseIf time >= "4:00 PM" And time <= "11:00 PM" Then

                        list_hour(3) = time.ToString("t")

                    ElseIf time >= "1:00 PM" And time <= "3:59 PM" Then
                        If list_hour(2) = "" Then

                            list_hour(2) = time.ToString("t")
                        Else
                            list_hour(3) = time.ToString("t")
                        End If

                    ElseIf time >= "12:00 PM" And time <= "12:59 PM" Then

                        Dim oldValuee As DateTime = dateTime
                        Dim newValuee As String = oldValuee.ToString("d") & " " & oldValuee.TimeOfDay.Hours
                        Dim val As String = oldValuee.ToString("d") & " " & "12"

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
        Next
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

        PopulateComboBox(Paydate_ComboB, "BIOMETRIC_DTR", "PAYDATE")
        RunCommand("DELETE FROM BIOMETRIC_DTR WHERE ID NOT IN  ( SELECT MAX(ID) FROM BIOMETRIC_DTR GROUP BY BIO_ID, DATE_ONLY )")

    End Sub


    Private Sub bio_TextFile()

        Dim Excel_FilePath = "C:\Biometric.xlsx"

        Dim oExcel = CreateObject("Excel.Application")

        oExcel.Workbooks.OpenText(FileName:=Path_TXT.Text, Origin:=65001)

        oExcel.Worksheets(1).Name = "Worksheet"

        oExcel.Worksheets(1).SaveAs(Excel_FilePath, FileFormat:=51)

        'oExcel.Quit()
        'oExcel = Nothing
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
            SaveBiometricSheet(Paydate, eCell(row, 1).Value, eCell(row, 2).Value)
            distinct_bio.Add(eCell(row, 1).Value)

            frmMainForm.AppProgressBar.Value += 1

        Next

        progressBarEnd()

        Cursor = Cursors.WaitCursor

        forLoop_ALL_IMPORTED()   ' ===== SAVE AM_IN, AM_OUT, PM_IN, PM_OUT ====
        SAVE_DIRECT_Attendance() ' ===== DIRECT SAVE TO ATTENDANCE ==== 
        PopulateBiometricSHEET(Bio_grid, Paydate) ' ===== POPULATE DATAGRIDVIEW FROM SHEET ==== 
        SavePayout_ALL(Paydate)

        Cursor = Cursors.Default

        Import_BTN.Enabled = False
        Path_TXT.Clear()
        MyConnection.Close()

        Has_Rows_Delete("IMPORT_DTR")
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
        SavePayout_ALL(Paydate)

        Cursor = Cursors.Default
    End Sub

    Private Sub Saving_InSys()

        Dim groups_time As New List(Of String)()
        Dim bio_no As String = "" ' ======================================== GIMOVE SA GAWAS BASI DILI MAGANA =======================

        progressBarStart(DtSet.Tables(0).Rows.Count)

        For row = 7 To DtSet.Tables(0).Rows.Count
            If eCell(row, 5).Value = Nothing Then
                Continue For
            End If

            Dim list_hour(3) As String

            '=============== BIO NUMBER ================
            If eCell(row, 2).Value <> Nothing Then
                bio_no = eCell(row, 2).Value
            End If

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

                If time >= "5:00 AM" And time <= "11:59 AM" Then
                    If list_hour(0) = "" Then

                        list_hour(0) = time.ToString("t")
                    Else
                        list_hour(1) = time.ToString("t")
                    End If

                ElseIf time >= "4:00 PM" And time <= "11:00 PM" Then

                    list_hour(3) = time.ToString("t")

                ElseIf time >= "1:00 PM" And time <= "3:59 PM" Then
                    If list_hour(2) = "" Then

                        list_hour(2) = time.ToString("t")
                    Else
                        list_hour(3) = time.ToString("t")
                    End If

                ElseIf time >= "12:00 PM" And time <= "12:59 PM" Then

                    Dim newValuee As String = time.TimeOfDay.Hours

                    If newValuee = "12" Then

                        If CountDate(groups_time, "12") >= 2 Then
                            list_Group = SortCountedDATE(groups_time, "12")
                        ElseIf CountDate(groups_time, "12") = 1 Then
                            list_Group = SortCountedDATE(groups_time, "12")
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
            Next

            If list_hour(1) = "12:00 AM" Then
                list_hour(1) = ""
            End If

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

        Cursor = Cursors.WaitCursor

        forLoop_ALL_IMPORTED()   ' ===== SAVE AM_IN, AM_OUT, PM_IN, PM_OUT ====
        SAVE_DIRECT_Attendance() ' ===== DIRECT SAVE TO ATTENDANCE ====
        PopulateBiometricSHEET(Bio_grid, Paydate) ' ===== POPULATE DATAGRIDVIEW FROM SHEET ====
        SavePayout_ALL(Paydate)

        Cursor = Cursors.Default

        Path_TXT.Clear()
        MyConnection.Close()

        Has_Rows_Delete("IMPORT_DTR")
    End Sub

    Public Sub SAVE_DIRECT_Attendance()
        LoadDateTime()

        AM_In_DataGrid.Items.Insert(0, "")
        AM_Out_DataGrid.Items.Insert(0, "")
        PM_IN_DataGrid.Items.Insert(0, "")
        PM_Out_DataGrid.Items.Insert(0, "")

        Dim paydate_ As String = Paydate.ToString("d")

        For Each biometric_No As String In distinct_bio

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

    'Private Sub Branch_ComboB_SelectedIndexChanged(sender As Object, e As EventArgs)
    '    If Paydate_ComboB.SelectedIndex >= 0 Then
    '        'PopulateBiometricSHEET(Bio_grid, Paydate_ComboB.SelectedItem, Branch_ComboB.SelectedItem)
    '        PopulateBiometricSHEET(Bio_grid, Paydate_ComboB.SelectedItem)
    '    Else
    '        'PopulateBiometricSHEET(Bio_grid, Paydate, Branch_ComboB.SelectedItem)
    '        PopulateBiometricSHEET(Bio_grid, Paydate)
    '    End If
    'End Sub

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
        Else
            GetName(BiometricID_TXT.Text, Name_TXT)

            If Not Name_TXT.Text = "" Then

                For Each oRow As DataGridViewRow In DataGridView1.Rows
                    oRow.Cells(5).Value = False
                    For cell As Integer = 1 To 4
                        oRow.Cells(cell).Value = Nothing
                    Next
                Next

                Attendance_Per_Employee(BiometricID_TXT.Text)
            End If
        End If

    End Sub

    Public Sub Attendance_Per_Employee(bioNo As String)
        Dim payroll As String
        If Paydate_ComboB.SelectedIndex >= 0 Then
            payroll = Paydate_ComboB.SelectedItem
        Else
            payroll = Paydate.ToString("d")
        End If

        Dim mysql As String = $"Select * From BIOMETRIC_DTR A inner join PAYROLL_ATTENDANCE B on B.BIOMETRICID = A.BIO_ID where A.BIO_ID = '{bioNo}' and A.PAYDATE = '{payroll}'"
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

                    End With
                Next
            Else
                ClearAfter()
            End If
        End Using

    End Sub

    Private Sub ClearAfter()
        CheckALL_CheckBox.Checked = False
        TotalAbsent_LBL.Text = 0
        TotalDays_LBL.Text = 0
        TotalRHoliday_LBL.Text = 0
        TotalSHoliday_LBL.Text = 0
        TotalLateHR_LBL.Text = 0
        TotalUTHR_LBL.Text = 0
        TotalOTHr_LBL.Text = 0
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

    Public Sub Load_Attendance(emp As Employee, empNo As Integer)
        With emp
            If empNo = 1 Then
                Bio1_DTR_TXT.Text = .BiometricID
                Bio1_DTR_TXT.Tag = .BranchID
                DTR_Emp1_TXT.Text = .Fullname
                DTR_Emp1_TXT.Tag = .EMP_ID
                Attendance_Tab.SelectedIndex = 2
                Employee_RadioB.Checked = True
            ElseIf empNo = 2 Then
                Bio2_DTR_TXT.Text = .BiometricID
                Bio2_DTR_TXT.Tag = .BranchID
                DTR_Emp2_TXT.Text = .Fullname
                DTR_Emp2_TXT.Tag = .EMP_ID
                Attendance_Tab.SelectedIndex = 2
                Employee_RadioB.Checked = True
            ElseIf empNo = 3 Then
                BiometricID_TXT.Text = .BiometricID
                Branch_Name = .BranchID
                Name_TXT.Text = .Fullname
                Name_TXT.Tag = .EMP_ID
                Attendance_Tab.SelectedIndex = 1
            End If
        End With
    End Sub


End Class