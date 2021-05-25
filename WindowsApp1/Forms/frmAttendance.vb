Imports FirebirdSql.Data.FirebirdClient

Public Class frmAttendance

    Dim DateNow As DateTime = DateTime.Now
    Dim startingDate, EndingDate As DateTime
    Dim DateNowADDMonth As DateTime = DateTime.Now.AddMonths(1)
    Dim StartFour, EndFour, StartNineteen, EndNineteen As DateTime
    Dim newNo As Integer

    Private Sub frmAttendance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDateTime()
        CheckALL_CheckBox.Checked = True
    End Sub

    Private Sub Close_LBL_Click(sender As Object, e As EventArgs) Handles Close_LBL.Click
        Close()
    End Sub

    Private Sub LoadDateTime()

        TotalAbsent_LBL.Text = 0
        TotalDays_LBL.Text = 0
        TotalLateHR_LBL.Text = 0
        TotalLateMIN_LBL.Text = 0
        TotalUTHR_LBL.Text = 0
        TotalUTMIN_LBL.Text = 0
        TotalOTHr_LBL.Text = 0
        TotalRHoliday_LBL.Text = 0
        TotalSHoliday_LBL.Text = 0
        DataGridView1.Rows.Clear()

        StartFour = New DateTime(DateNow.Year, DateNow.Month, 4).AddDays(-1)
        EndFour = New DateTime(DateNow.Year, DateNow.Month, 18)

        StartNineteen = New DateTime(DateNow.Year, DateNow.Month, 19).AddMonths(-1).AddDays(-1)
        EndNineteen = New DateTime(StartNineteen.Year, StartNineteen.Month, 3).AddMonths(1)

        If DateNow.Day - 16 <= 2 And DateNow.Day - 16 >= -12 Then

            While (StartNineteen < EndNineteen)
                startingDate = StartNineteen.ToString("d")
                EndingDate = EndNineteen.ToString("d")
                DataGridView1.Rows.Add(StartNineteen.AddDays(1).ToString("D"))
                StartNineteen = StartNineteen.AddDays(1)
            End While

        Else

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

                r.DefaultCellStyle.BackColor = Color.Coral

                DataGridView1.Rows(i).Cells(5).Value = False
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
                If row.DefaultCellStyle.BackColor = Color.Coral Then
                    DataGridView1.Rows(i).Cells(5).Value = False
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
        TotalLateMIN_LBL.Text = 0
        TotalUTHR_LBL.Text = 0
        TotalUTMIN_LBL.Text = 0
        hourOfDay_LBL.Text = 0
        TotalOTHr_LBL.Text = 0

        For i = 0 To DataGridView1.RowCount - 1
            Dim row As DataGridViewRow = DataGridView1.Rows(i)

            '========================================================================= CALCULATE DAYS PRESENT AND ABSENT  ===========================================================
            If Not row.DefaultCellStyle.BackColor = Color.Red Then

                If DataGridView1.Rows(i).Cells(5).Value = False Then

                    'TotalAbsent_LBL.Text = TotalAbsent_LBL.Text + 1

                    '========================================================================= CALCULATE AM NUMBER OF HOURS IF HALFDAY  ===========================================================
                    If Not DataGridView1.Rows(i).Cells(1).Value = Nothing And Not DataGridView1.Rows(i).Cells(2).Value = Nothing Then

                        Dim AM As TimeSpan = DateTime.Parse(DataGridView1.Rows(i).Cells(2).Value).Subtract(DateTime.Parse(DataGridView1.Rows(i).Cells(1).Value))

                        If AM.Hours > 4 Then
                            newNo = 4
                        Else
                            newNo = AM.Hours
                        End If

                        hourOfDay_LBL.Text = Convert.ToInt32(hourOfDay_LBL.Text) + newNo


                        If hourOfDay_LBL.Text >= 8 Then
                            Dim ConvertToDAy As Integer = Convert.ToInt32(hourOfDay_LBL.Text) / 8

                            TotalDays_LBL.Text = Convert.ToInt32(TotalDays_LBL.Text) + ConvertToDAy

                            hourOfDay_LBL.Text = Convert.ToInt32(hourOfDay_LBL.Text) Mod 8
                        End If

                        '========================================================================= CALCULATE PM NUMBER OF HOURS IF HALFDAY   ===========================================================
                    ElseIf Not DataGridView1.Rows(i).Cells(3).Value = Nothing And Not DataGridView1.Rows(i).Cells(4).Value = Nothing Then

                        Dim PM As TimeSpan = DateTime.Parse(DataGridView1.Rows(i).Cells(4).Value).Subtract(DateTime.Parse(DataGridView1.Rows(i).Cells(3).Value))

                        If PM.Hours > 4 Then
                            newNo = 4
                        Else
                            newNo = PM.Hours
                        End If

                        hourOfDay_LBL.Text = Convert.ToInt32(hourOfDay_LBL.Text) + newNo

                        If hourOfDay_LBL.Text >= 8 Then
                            Dim ConvertToDAy As Integer = Convert.ToInt32(hourOfDay_LBL.Text) / 8

                            TotalDays_LBL.Text = Convert.ToInt32(TotalDays_LBL.Text) + ConvertToDAy

                            hourOfDay_LBL.Text = Convert.ToInt32(hourOfDay_LBL.Text) Mod 8
                        End If

                    ElseIf Not DataGridView1.Rows(i).Cells(1).Value = Nothing AndAlso Not DataGridView1.Rows(i).Cells(2).Value = Nothing AndAlso Not DataGridView1.Rows(i).Cells(3).Value = Nothing AndAlso Not DataGridView1.Rows(i).Cells(4).Value = Nothing Then

                        hourOfDay_LBL.Text = 0
                        DataGridView1.Rows(i).Cells(5).Value = True

                    End If

                Else

                    TotalDays_LBL.Text = TotalDays_LBL.Text + 1

                End If


                '========================================================================= CALCULATE HOLIDAYS  ===========================================================
                If row.DefaultCellStyle.BackColor = Color.MediumOrchid Then


                    TotalRHoliday_LBL.Text = TotalRHoliday_LBL.Text + 1

                ElseIf row.DefaultCellStyle.BackColor = Color.Plum Then


                    TotalSHoliday_LBL.Text = TotalSHoliday_LBL.Text + 1

                End If


                CalculateLATE(i)

                CalculateuNDERTIME(i)

                CalculateuOVERTIME(i)

            End If
        Next

    End Sub

    Private Sub CalculateLATE(rowNumber As Integer)

        '========================================================================= CELL NUMBER AM IN ===========================================================
        If Not DataGridView1.Rows(rowNumber).Cells(1).Value = Nothing Then

            Dim inHour = New DateTime(Now.Year, Now.Month, Now.Day, 8, 0, 0, 0).ToString("t")
            Dim lateHour As TimeSpan = DateTime.Parse(DataGridView1.Rows(rowNumber).Cells(1).Value).Subtract(DateTime.Parse(inHour))
            Dim lateMin As TimeSpan = DateTime.Parse(DataGridView1.Rows(rowNumber).Cells(1).Value).Subtract(DateTime.Parse(inHour))

            If lateHour.Hours > 0 Then

                TotalLateHR_LBL.Text = Convert.ToInt32(TotalLateHR_LBL.Text) + lateHour.Hours

            ElseIf lateMin.Minutes > 0 Then

                TotalLateMIN_LBL.Text = Convert.ToInt32(TotalLateMIN_LBL.Text) + Format(lateMin.Minutes, "00")

            End If

        End If

        '========================================================================= CELL NUMBER PM IN ===========================================================
        If Not DataGridView1.Rows(rowNumber).Cells(3).Value = Nothing Then

            Dim inHour = New DateTime(Now.Year, Now.Month, Now.Day, 13, 0, 0, 0).ToString("t")
            Dim lateHour As TimeSpan = DateTime.Parse(DataGridView1.Rows(rowNumber).Cells(3).Value).Subtract(DateTime.Parse(inHour))
            Dim lateMin As TimeSpan = DateTime.Parse(DataGridView1.Rows(rowNumber).Cells(3).Value).Subtract(DateTime.Parse(inHour))

            If lateHour.Hours > 0 Then

                TotalLateHR_LBL.Text = Convert.ToInt32(TotalLateHR_LBL.Text) + lateHour.Hours

            ElseIf lateMin.Minutes > 0 Then

                TotalLateMIN_LBL.Text = Convert.ToInt32(TotalLateMIN_LBL.Text) + Format(lateMin.Minutes, "00")

            End If

        End If

    End Sub

    Private Sub CalculateuNDERTIME(rowNumber As Integer)

        '========================================================================= CELL NUMBER AM OUT ===========================================================
        If Not DataGridView1.Rows(rowNumber).Cells(2).Value = Nothing Then

            Dim inHour = New DateTime(Now.Year, Now.Month, Now.Day, 12, 0, 0, 0).ToString("t")
            Dim underHour As TimeSpan = DateTime.Parse(inHour).Subtract(DateTime.Parse(DataGridView1.Rows(rowNumber).Cells(2).Value))
            Dim underMin As TimeSpan = DateTime.Parse(inHour).Subtract(DateTime.Parse(DataGridView1.Rows(rowNumber).Cells(2).Value))

            If underHour.Hours > 0 Then

                TotalUTHR_LBL.Text = Convert.ToInt32(TotalUTHR_LBL.Text) + underHour.Hours

            ElseIf underMin.Minutes > 0 Then

                TotalUTMIN_LBL.Text = Convert.ToInt32(TotalUTMIN_LBL.Text) + Format(underMin.Minutes, "00")

            End If

        End If

        '========================================================================= CELL NUMBER PM OUT ===========================================================
        If Not DataGridView1.Rows(rowNumber).Cells(4).Value = Nothing Then

            Dim inHour = New DateTime(Now.Year, Now.Month, Now.Day, 17, 0, 0, 0).ToString("t")
            Dim underHour As TimeSpan = DateTime.Parse(inHour).Subtract(DateTime.Parse(DataGridView1.Rows(rowNumber).Cells(4).Value))
            Dim underMin As TimeSpan = DateTime.Parse(inHour).Subtract(DateTime.Parse(DataGridView1.Rows(rowNumber).Cells(4).Value))

            If underHour.Hours > 0 Then

                TotalUTHR_LBL.Text = Convert.ToInt32(TotalUTHR_LBL.Text) + underHour.Hours

            ElseIf underMin.Minutes > 0 Then

                TotalUTMIN_LBL.Text = Convert.ToInt32(TotalUTMIN_LBL.Text) + Format(underMin.Minutes, "00")

            End If

        End If

        If TotalUTMIN_LBL.Text >= 60 Then
            Dim ConvertToDAy As Integer = Convert.ToInt32(TotalUTMIN_LBL.Text) / 60

            TotalUTHR_LBL.Text = Convert.ToInt32(TotalUTHR_LBL.Text) + ConvertToDAy

            TotalUTMIN_LBL.Text = Convert.ToInt32(TotalUTMIN_LBL.Text) Mod 60
        End If

    End Sub

    Private Sub CalculateuOVERTIME(rowNumber As Integer)
        '========================================================================= CELL NUMBER PM OUT ===========================================================
        If Not DataGridView1.Rows(rowNumber).Cells(4).Value = Nothing Then

            Dim inHour = New DateTime(Now.Year, Now.Month, Now.Day, 17, 0, 0, 0).ToString("t")

            Dim OTHour As TimeSpan = DateTime.Parse(DataGridView1.Rows(rowNumber).Cells(4).Value).Subtract(DateTime.Parse(inHour))

            If OTHour.Hours > 0 Then

                TotalOTHr_LBL.Text = Convert.ToInt32(TotalOTHr_LBL.Text) + OTHour.Hours
            End If

        End If

    End Sub

    Private Sub Cancel_BTN_Click(sender As Object, e As EventArgs) Handles Cancel_BTN.Click

        TotalAbsent_LBL.Text = 0
        TotalDays_LBL.Text = 0
        TotalLateHR_LBL.Text = 0
        TotalLateMIN_LBL.Text = 0
        TotalUTHR_LBL.Text = 0
        TotalUTMIN_LBL.Text = 0

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

            'If isNotExist() Then

            'SaveAttendance(BiometricID_TXT.Text, DataGridView1.Tag, TotalDays_LBL.Text, hourOfDay_LBL.Text, TotalLateHR_LBL.Text, TotalLateMIN_LBL.Text,
            '                TotalUTHR_LBL.Text, TotalUTMIN_LBL.Text, TotalAbsent_LBL.Text, AbsentHour_LBL.Text, TotalOTHr_LBL.Text,
            '                TotalRHoliday_LBL.Text, TotalSHoliday_LBL.Text)

            Dim mysql As String = "Select * From PAYROLL_ATTENDANCE Rows 1"
            Using ds As DataSet = LoadSQL(mysql, "PAYROLL_ATTENDANCE")

                Dim dsNewRow As DataRow
                dsNewRow = ds.Tables(0).NewRow
                With dsNewRow

                    .Item("BIOMETRICID") = BiometricID_TXT.Text
                    .Item("PAYDATE") = DataGridView1.Tag
                    .Item("TOTALDAYS") = TotalDays_LBL.Text
                    .Item("TOTALDAYSHOUR") = hourOfDay_LBL.Text
                    .Item("TOTALLATEHOUR") = TotalLateHR_LBL.Text
                    .Item("TOTALLATEMINUTE") = TotalLateMIN_LBL.Text

                    .Item("TOTALUTHOUR") = TotalUTHR_LBL.Text
                    .Item("TOTALUTMINUTE") = TotalUTMIN_LBL.Text

                    .Item("TOTALABSENTDAYS") = TotalAbsent_LBL.Text
                    .Item("TOTALABSENTHOUR") = AbsentHour_LBL.Text

                    .Item("TOTALOVERTIME") = TotalOTHr_LBL.Text
                    .Item("TOTALREGHOLIDAY") = TotalRHoliday_LBL.Text
                    .Item("TOTALSPECHOLIDAY") = TotalSHoliday_LBL.Text

                End With
                ds.Tables(0).Rows.Add(dsNewRow)
                SaveEntry(ds)
            End Using

            MsgBox("New Record Added!", MsgBoxStyle.Information, "Information")

            'Else

            'Dim result As DialogResult = MessageBox.Show("Name already exist. Do you want to update the existing record?", "Warning", MessageBoxButtons.YesNo)

            '    If result = DialogResult.Yes Then

            '        Dim mysql As String = "Select * From PAYROLL_ATTENDANCE Where BIOMETRICID = '" & BiometricID_TXT.Text & "'"
            '        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_ATTENDANCE")

            '            With ds.Tables(0).Rows(0)
            '                .Item("PAYDATE") = DataGridView1.Tag

            '                .Item("TOTALDAYS") = TotalDays_LBL.Text
            '                .Item("TOTALDAYSHOUR") = hourOfDay_LBL.Text

            '                .Item("TOTALLATEHOUR") = TotalLateHR_LBL.Text
            '                .Item("TOTALLATEMINUTE") = TotalLateMIN_LBL.Text

            '                .Item("TOTALUTHOUR") = TotalUTHR_LBL.Text
            '                .Item("TOTALUTMINUTE") = TotalUTMIN_LBL.Text

            '                .Item("TOTALABSENTDAYS") = TotalAbsent_LBL.Text
            '                .Item("TOTALABSENTHOUR") = AbsentHour_LBL.Text

            '                .Item("TOTALOVERTIME") = TotalOTHr_LBL.Text
            '                .Item("TOTALREGHOLIDAY") = TotalRHoliday_LBL.Text
            '                .Item("TOTALSPECHOLIDAY") = TotalSHoliday_LBL.Text
            '            End With
            '            SaveEntry(ds, False)
            '        End Using

            '        MsgBox("Succesfully Updated!", MsgBoxStyle.Information, "Information")

            '    End If

            'End If

        Else
            MsgBox("Please Enter Employee's Name!", MsgBoxStyle.Critical, "Error")
        End If

        ClearAfter()
    End Sub


    'Private Function isNotExist()

    '    Dim mysql As String = "SELECT * FROM PAYROLL_ATTENDANCE Where BIOMETRICID = '" & BiometricID_TXT.Text & "' and FROMDATE = '" & startingDate & "' and TODATE = '" & startingDate & "'"
    '    Dim ds As DataSet = LoadSQL(mysql, "PAYROLL_ATTENDANCE")
    '    If ds.Tables(0).Rows.Count > 0 Then
    '        Return True
    '    End If

    '    Return False

    'End Function

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

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        If BiometricID_TXT.Text = "" Then
            MsgBox("Please Enter Employee's Name.", MsgBoxStyle.Critical, "Error")
        End If

    End Sub

    'Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
    '    Calculate_BTN.PerformClick()
    'End Sub

    'Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
    '    Calculate_BTN.PerformClick()
    'End Sub

    Private Sub Name_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Name_TXT.KeyPress
        LoadEmployeeDetails()
    End Sub

    Private Sub DataGridView1_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError
        '========================= Need para di magERROR ang Datagrid==============
    End Sub

    Private Sub BiometricID_TXT_TextChanged(sender As Object, e As EventArgs) Handles BiometricID_TXT.TextChanged

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
                End With
            End If
        End Using
    End Sub

    Private Sub ClearAfter()
        BiometricID_TXT.Clear()
        Name_TXT.Clear()

        TotalDays_LBL.Text = 0
        TotalLateHR_LBL.Text = 0
        TotalLateMIN_LBL.Text = 0
        TotalUTHR_LBL.Text = 0
        TotalUTMIN_LBL.Text = 0
        TotalOTHr_LBL.Text = 0
        TotalRHoliday_LBL.Text = 0
        TotalSHoliday_LBL.Text = 0

        TotalAbsent_LBL.Text = 0
        AbsentHour_LBL.Text = 0
        LoadDateTime()
        CheckALL_CheckBox.Checked = True
    End Sub

End Class