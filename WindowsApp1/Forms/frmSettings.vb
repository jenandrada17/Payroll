Public Class frmSettings

    Private Sub frmSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Date_DTP.CustomFormat = "MM/yyyy"

        If ThisHasRow("PAYROLL_HOLIDAY_RATE") Then
            HolidayRate(RegularRate_TXT, SpecialRate_TXT)
        End If

        If ThisHasRow("PAYROLL_EMAIL") Then
            GetEmail(Email_TXT, Password_TXT)
        End If

        PopulateComboBox_Any(Rate_City_ComboB, "PAYROLL_CITY_BRANCH", "CITY")
        PopulateComboBox_Any(ClockBranch_CB, "PAYROLL_EMPLOYEE", "BRANCH_CODE")
        PopulateComboBox_Any(City_Combo, "PAYROLL_CITY_BRANCH", "CITY")
        PopulateComboBox_Any(CityCode_Combo, "PAYROLL_EMPLOYEE", "BRANCH_CODE")
        PopulateComboBox_Any(Address_Combo, "PAYROLL_CITY_BRANCH", "ADDRESS")
        Lists_Rate(Rate_list)
        Lists_TimeInOut(TimeInOut_LV)
        Load_Category_LIST(Allowance_List, "CATEGORY_ALLOWANCE", "ALLOWANCE_NAME")
        Load_Category_LIST(Cat_Deduc_List, "CATEGORY_DEDUCTION", "DEDUCTION_NAME")
        Lists_City_Branch(CityBranch_List)

        Dim tm As New Date(1, 1, 1, 0, 0, 0)
        For x = 1 To 48
            tm = tm.AddMinutes(30)
            ClockBranch_IN_CB.Items.Add(tm.ToShortTimeString)
            ClockBranch_OUT_CB.Items.Add(tm.ToShortTimeString)
            ClockEmp_IN_CB.Items.Add(tm.ToShortTimeString)
            ClockEmp_OUT_CB.Items.Add(tm.ToShortTimeString)
        Next

        Rate_City_ComboB.Items.Insert(0, "")
    End Sub

    Private Sub Close_LBL_Click(sender As Object, e As EventArgs) Handles Close_LBL.Click
        Close()
    End Sub

    Private Sub Close_LBL_MouseEnter(sender As Object, e As EventArgs) Handles Close_LBL.MouseEnter
        Close_LBL.ForeColor = Color.Red
    End Sub

    Private Sub Close_LBL_MouseLeave(sender As Object, e As EventArgs) Handles Close_LBL.MouseLeave
        Close_LBL.ForeColor = Color.Black
    End Sub

    Private Sub Save_BTN_Click(sender As Object, e As EventArgs) Handles Save_BTN.Click

        Dim customizeDate As String = Date_DTP.Value.ToString("M")

        If Not Name_TXT.Text = "" Then

            If isNotExistHoliday(customizeDate) Then

                If Regular_RB.Checked = True Then
                    SaveHoliday(customizeDate, Name_TXT.Text, "REGULAR")
                    UpdateAttendance(frmMainForm.Paydate, "REGHOLIDAY")
                    REGULDARHolidayLists(lvHoliday)
                Else
                    SaveHoliday(customizeDate, Name_TXT.Text, "SPECIAL")
                    UpdateAttendance(frmMainForm.Paydate, "SPECHOLIDAY")
                    SPECIALHolidayLists(lvHoliday)
                End If

            Else

                If Regular_RB.Checked = True Then
                    UpdateHoliday(customizeDate, Name_TXT.Text, "REGULAR")
                    UpdateAttendance(frmMainForm.Paydate, "REGHOLIDAY")
                    REGULDARHolidayLists(lvHoliday)
                Else
                    UpdateHoliday(customizeDate, Name_TXT.Text, "SPECIAL")
                    UpdateAttendance(frmMainForm.Paydate, "SPECHOLIDAY")
                    SPECIALHolidayLists(lvHoliday)
                End If

            End If

            UpdatePayout(frmMainForm.Paydate)

            SaveLogs($"ADDED HOLIDAY - Name({Name_TXT.Text}), Date({Date_DTP.Value.ToString("MMM dd, yyyy")})", frmMainForm.UserName_LBL.Text)
        Else
            MsgBox("Please Name of Holiday!", MsgBoxStyle.Critical, "Error")
        End If

        Date_DTP.Value = Date.Now
        Name_TXT.Text = ""

    End Sub


    Private Sub Regular_RB_CheckedChanged(sender As Object, e As EventArgs) Handles Regular_RB.CheckedChanged
        If Regular_RB.Checked = True Then
            REGULDARHolidayLists(lvHoliday)
        Else
            SPECIALHolidayLists(lvHoliday)
        End If
    End Sub

    Private Sub RemoveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem.Click
        If lvHoliday.SelectedItems.Count > 0 Then

            Dim result As DialogResult = MsgBox($"Holiday will be removed, proceed anyway?", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then

                For Each item As ListViewItem In lvHoliday.SelectedItems
                    RemoveHoliday(item.SubItems(0).Text)

                    If Regular_RB.Checked = True Then
                        REGULDARHolidayLists(lvHoliday)
                        UpdateAttendance(frmMainForm.Paydate, "REGHOLIDAY")
                    Else
                        SPECIALHolidayLists(lvHoliday)
                        UpdateAttendance(frmMainForm.Paydate, "SPECHOLIDAY")
                    End If

                    SaveLogs($"REMOVED HOLIDAY - Name({item.SubItems(1).Text}), Date({item.SubItems(0).Text})", frmMainForm.UserName_LBL.Text)
                Next

                UpdatePayout(frmMainForm.Paydate)
            End If
        End If
    End Sub

    Private Sub lvHoliday_MouseClick(sender As Object, e As MouseEventArgs) Handles lvHoliday.MouseClick
        If e.Button = MouseButtons.Right Then
            If lvHoliday.Items.Count > 0 Then
                Holiday_Remove.Show(lvHoliday, New Point(e.X, e.Y))
            End If
        End If
    End Sub

    Private Sub Name_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Name_TXT.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Save_BTN.PerformClick()
        End If
    End Sub

    Private Sub HolidayRate_BTN_Click(sender As Object, e As EventArgs) Handles HolidayRate_BTN.Click

        If HolidayRate_BTN.Text = "Change" Then
            RegularRate_TXT.ReadOnly = False
            SpecialRate_TXT.ReadOnly = False
            HolidayRate_BTN.Text = "Save"
        Else
            SaveHOLIDAY_RATE("REGULAR", RegularRate_TXT.Text)
            SaveHOLIDAY_RATE("SPECIAL", SpecialRate_TXT.Text)

            RegularRate_TXT.ReadOnly = True
            SpecialRate_TXT.ReadOnly = True
            HolidayRate_BTN.Text = "Change"

            MsgBox("Holiday Rate Saved!", MsgBoxStyle.Information, "Information")
            HolidayRate(RegularRate_TXT, SpecialRate_TXT)
        End If
    End Sub

    Private Sub Rate_EmpSelect_BTN_Click(sender As Object, e As EventArgs) Handles Rate_EmpSelect_BTN.Click
        Try
            Dim instForm As Form = Application.OpenForms.OfType(Of Form)().Where(Function(frm) frm.Name = "frmNewEmployee").SingleOrDefault()
            If instForm Is Nothing Then
                Dim frm As frmNewEmployee
                frm = DirectCast(CreateObjectInstance("frmNewEmployee"), Form)
                frm.MdiParent = frmMainForm
                frmMainForm.pNavigate.Controls.Add(frm)
                frmMainForm.pNavigate.Tag = frm
                frm.txtSearch.Tag = "Settings-Rate"
                frm.Dock = DockStyle.Fill
                frm.BringToFront()
                frm.Show()
            Else
                instForm.BringToFront()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Rate_EmpSave_BTN_Click(sender As Object, e As EventArgs) Handles Rate_EmpSave_BTN.Click
        If Not Rate_BioNo_TXT.Text = "" Then

            Dim result As DialogResult = MsgBox($"Rate for {Rate_Employee_TXT.Text} will be Save/Updated, proceed anyway?", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then

                Dim fix_monthly As Boolean = False
                If RateFixYes_RB.Checked = True Then
                    fix_monthly = True
                End If

                SaveRATE("BIO_NO", Rate_BioNo_TXT.Text, Rate_EmpAmount_TXT.Text, fix_monthly)

                SaveLogs($"UPDATED RATE - {Rate_Employee_TXT.Text} ({Rate_BioNo_TXT.Text}), Rate( from {Rate_EmpAmount_TXT.Tag} to {Rate_EmpAmount_TXT.Text} )", frmMainForm.UserName_LBL.Text)

                Rate_EmpClear_BTN.PerformClick()
                Lists_Rate(Rate_list)
            End If

        End If
    End Sub

    Private Sub Rate_EmpClear_BTN_Click(sender As Object, e As EventArgs) Handles Rate_EmpClear_BTN.Click
        Rate_BioNo_TXT.Text = ""
        Rate_Employee_TXT.Text = ""
        Rate_EmpAmount_TXT.Text = ""
        MonthlyRate_TXT.Text = ""
    End Sub

    Private Sub Rate_BioNo_TXT_TextChanged(sender As Object, e As EventArgs) Handles Rate_BioNo_TXT.TextChanged
        If Rate_BioNo_TXT.Text = "" Then
            Rate_Employee_TXT.Text = ""
            Rate_EmpAmount_TXT.Text = ""
            MonthlyRate_TXT.Text = ""
            RateFixNo_RB.Checked = True
        Else
            Payout_Details(Rate_BioNo_TXT.Text, Rate_Employee_TXT, Rate_EmpAmount_TXT, RateFixYes_RB, MonthlyRate_TXT)
        End If
    End Sub

    Private Sub Rate_Branch_BTN_Click(sender As Object, e As EventArgs) Handles Rate_Branch_BTN.Click
        If Rate_City_ComboB.SelectedIndex >= 0 And Not Rate_CityAmount_TXT.Text = "" Then

            Dim result As DialogResult = MsgBox($"Minimum rate will be updated, proceed anyway?", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then

                SaveRATE_City("CITY", Rate_City_ComboB.Text, Rate_CityAmount_TXT.Text, True)

                SaveMinimum_RATE(Rate_City_ComboB.Text, Rate_CityAmount_TXT.Text, Ecola_TXT.Text)

                SaveLogs($"UPDATED MINIMUM RATE - City({Rate_City_ComboB.Text}), Rate( from {Rate_CityAmount_TXT.Tag} to {Rate_CityAmount_TXT.Text} )", frmMainForm.UserName_LBL.Text)

                CityClear_BTN.PerformClick()

                MsgBox("Successfully updated!", MsgBoxStyle.Information, "Information")

                Lists_Rate(Rate_list)
            End If

        Else

            If Not Rate_City_ComboB.SelectedIndex >= 0 Then MsgBox("Invalid City! Kindly click CITY-BRANCH to add new City or Branch!", MsgBoxStyle.Exclamation, "Error")
            If Rate_CityAmount_TXT.Text = "" Then MsgBox("Kindly indicate rate amount!", MsgBoxStyle.Exclamation, "Error")

        End If
    End Sub

    Private Sub Rate_BranchAmount_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Rate_CityAmount_TXT.KeyPress,
                                                Rate_BioNo_TXT.KeyPress

        If e.KeyChar <> ChrW(Keys.Back) Then
            If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso Not e.KeyChar = "." Then
                e.Handled = True
            End If
        End If

    End Sub

    Private Sub Rate_Search_BTN_Click(sender As Object, e As EventArgs) Handles Rate_Search_BTN.Click
        Lists_Rate(Rate_list, Rate_Search_TXT.Text)
    End Sub

    Private Sub Rate_Search_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Rate_Search_TXT.KeyPress
        If IsEnter(e) Then Rate_Search_BTN.PerformClick()
    End Sub

    Private Sub Cat_Allow_Save_BTN_Click(sender As Object, e As EventArgs) Handles Cat_Allow_Save_BTN.Click
        If Not AllowCat_TXT.Text = "" Then
            SaveCATEGORY(AllowCat_TXT.Text, "CATEGORY_ALLOWANCE", "ALLOWANCE_NAME")
            Load_Category_LIST(Allowance_List, "CATEGORY_ALLOWANCE", "ALLOWANCE_NAME")

            SaveLogs($"ADDED CATEGORY FOR ALLOWANCE - {AllowCat_TXT.Text}", frmMainForm.UserName_LBL.Text)
            AllowCat_TXT.Text = ""
        End If
    End Sub

    Private Sub AllowCat_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles AllowCat_TXT.KeyPress
        If IsEnter(e) Then Cat_Allow_Save_BTN.PerformClick()
    End Sub

    Private Sub DeducSave_BTN_Click(sender As Object, e As EventArgs) Handles DeducSave_BTN.Click
        If Not Deduct_TXT.Text = "" Then
            SaveCATEGORY(Deduct_TXT.Text, "CATEGORY_DEDUCTION", "DEDUCTION_NAME")
            Load_Category_LIST(Cat_Deduc_List, "CATEGORY_DEDUCTION", "DEDUCTION_NAME")

            SaveLogs($"ADDED CATEGORY FOR DEDUCTION - {Deduct_TXT.Text}", frmMainForm.UserName_LBL.Text)

            Deduct_TXT.Text = ""
        End If
    End Sub

    Private Sub Deduct_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Deduct_TXT.KeyPress
        If IsEnter(e) Then DeducSave_BTN.PerformClick()
    End Sub

    Private Sub Email_Save_BTN_Click(sender As Object, e As EventArgs) Handles Email_Save_BTN.Click
        If Email_Save_BTN.Text = "Change" Then
            Email_Save_BTN.Text = "Save"
            Email_TXT.ReadOnly = False
            Password_TXT.ReadOnly = False
        Else
            If Not Email_TXT.Text = String.Empty Or Not Password_TXT.Text = String.Empty Then

                Dim result As DialogResult = MsgBox($"Email information will be changed, proceed anyway?", MessageBoxButtons.YesNo)
                If result = DialogResult.Yes Then

                    SaveEmail(Email_TXT.Text, Password_TXT.Text)

                    SaveLogs($"CHANGED EMAIL SENDER {Email_TXT.Text}", frmMainForm.UserName_LBL.Text)

                    Email_TXT.Clear()
                    Password_TXT.Clear()
                    Email_TXT.ReadOnly = True
                    Password_TXT.ReadOnly = True
                    GetEmail(Email_TXT, Password_TXT)
                    Email_Save_BTN.Text = "Change"
                End If

            Else
                MsgBox("Please Complete the information!", MsgBoxStyle.Information, "Information")
            End If
        End If
    End Sub

    Private Sub Allow_Category_Combo_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim cmb As ComboBox = DirectCast(sender, ComboBox)
        If cmb.SelectedIndex >= 0 Then
            cmb.Region = Nothing
        End If
    End Sub

    Private Sub DE_Category_Combo_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim cmb As ComboBox = DirectCast(sender, ComboBox)
        If cmb.SelectedIndex >= 0 Then
            cmb.Region = Nothing
        End If
    End Sub

    Private Sub Daily_BTN_Click(sender As Object, e As EventArgs) Handles Daily_BTN.Click
        Rate_EmpAmount_TXT.ReadOnly = False
        MonthlyRate_TXT.ReadOnly = True
        Rate_EmpAmount_TXT.Text = ""
        MonthlyRate_TXT.Text = ""
    End Sub

    Private Sub Monthly_BTN_Click(sender As Object, e As EventArgs) Handles Monthly_BTN.Click
        MonthlyRate_TXT.ReadOnly = False
        Rate_EmpAmount_TXT.ReadOnly = True
        Rate_EmpAmount_TXT.Text = ""
        MonthlyRate_TXT.Text = ""
    End Sub

    Private Sub Rate_EmpAmount_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Rate_EmpAmount_TXT.KeyPress
        If e.KeyChar <> ChrW(Keys.Back) Then

            If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso Not e.KeyChar = "." Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub Rate_EmpAmount_TXT_TextChanged(sender As Object, e As EventArgs) Handles Rate_EmpAmount_TXT.TextChanged
        If Rate_EmpAmount_TXT.ReadOnly = False Then
            If Rate_EmpAmount_TXT.Text <> Nothing Then
                MonthlyRate_TXT.Text = Convert.ToDouble(Rate_EmpAmount_TXT.Text) * 26
            Else
                MonthlyRate_TXT.Text = ""
            End If
        End If
    End Sub

    Private Sub MonthlyRate_TXT_TextChanged(sender As Object, e As EventArgs) Handles MonthlyRate_TXT.TextChanged
        If MonthlyRate_TXT.ReadOnly = False Then
            If MonthlyRate_TXT.Text <> Nothing Then
                Rate_EmpAmount_TXT.Text = Convert.ToDouble(MonthlyRate_TXT.Text) / 26
            Else
                Rate_EmpAmount_TXT.Text = ""
            End If
        End If
    End Sub

    Private Sub ClockBio_TXT_TextChanged(sender As Object, e As EventArgs) Handles ClockBio_TXT.TextChanged

        If ClockBio_TXT.Text = "" Then
            ClockEmp_TXT.Text = ""
            Rate_EmpAmount_TXT.Text = ""
            ClockEmp_IN_CB.Text = ""
            ClockEmp_OUT_CB.Text = ""
        Else
            Clock_IN_Details(ClockBio_TXT.Text, ClockEmp_TXT, ClockEmp_IN_CB, ClockEmp_OUT_CB)
        End If

    End Sub

    Private Sub ClockBranch_BTN_Click(sender As Object, e As EventArgs) Handles ClockBranch_BTN.Click

        If ClockBranch_CB.SelectedIndex >= 0 And ClockBranch_IN_CB.SelectedIndex >= 0 And ClockBranch_OUT_CB.SelectedIndex >= 0 Then

            Dim result As DialogResult = MsgBox($"Time in/out for {ClockBranch_CB.Text} will be Save/Updated, proceed anyway?", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then

                Save_ClockINOUT("BRANCH_CODE", ClockBranch_CB.Text, ClockBranch_IN_CB.Text, ClockBranch_OUT_CB.Text)
                Lists_TimeInOut(TimeInOut_LV)

                SaveLogs($"UPDATED TIME IN/OUT FOR BRANCH({ClockBranch_CB.Text}),  In/Out({ClockBranch_IN_CB.Text} - {ClockBranch_OUT_CB.Text})", frmMainForm.UserName_LBL.Text)
                ClearlBranch_BTN.PerformClick()
            End If

        End If

    End Sub

    Private Sub ClockSave_BTN_Click(sender As Object, e As EventArgs) Handles ClockSave_BTN.Click

        If ClockEmp_TXT.Text <> "" And ClockEmp_IN_CB.SelectedIndex >= 0 And ClockEmp_OUT_CB.SelectedIndex >= 0 Then

            Dim result As DialogResult = MsgBox($"Time in/out for {ClockEmp_TXT.Text} will be Save/Updated, proceed anyway?", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then

                Save_ClockINOUT("BIO_NO", ClockBio_TXT.Text, ClockEmp_IN_CB.Text, ClockEmp_OUT_CB.Text)
                Lists_TimeInOut(TimeInOut_LV)

                SaveLogs($"UPDATED TIME IN/OUT FOR {ClockEmp_TXT.Text} ({ClockBio_TXT.Text}),  In/Out({ClockEmp_IN_CB.Text} - {ClockEmp_OUT_CB.Text})", frmMainForm.UserName_LBL.Text)
                ClockClear_BTN.PerformClick()
            End If
        End If

    End Sub

    Private Sub ClockClear_BTN_Click(sender As Object, e As EventArgs) Handles ClockClear_BTN.Click
        ClockBio_TXT.Clear()
        ClockEmp_TXT.Clear()
        ClockEmp_IN_CB.SelectedIndex = -1
        ClockEmp_OUT_CB.SelectedIndex = -1
    End Sub

    Private Sub ClearlBranch_BTN_Click(sender As Object, e As EventArgs) Handles ClearlBranch_BTN.Click
        ClockBranch_CB.SelectedIndex = -1
        ClockBranch_IN_CB.SelectedIndex = -1
        ClockBranch_OUT_CB.SelectedIndex = -1
    End Sub

    Private Sub ClockSearch_BTN_Click(sender As Object, e As EventArgs) Handles ClockSearch_BTN.Click
        Try
            Dim instForm As Form = Application.OpenForms.OfType(Of Form)().Where(Function(frm) frm.Name = "frmNewEmployee").SingleOrDefault()
            If instForm Is Nothing Then
                Dim frm As frmNewEmployee
                frm = DirectCast(CreateObjectInstance("frmNewEmployee"), Form)
                frm.MdiParent = frmMainForm
                frmMainForm.pNavigate.Controls.Add(frm)
                frmMainForm.pNavigate.Tag = frm
                frm.txtSearch.Tag = "Settings-TimeInOUt"
                frm.Dock = DockStyle.Fill
                frm.BringToFront()
                frm.Show()
            Else
                instForm.BringToFront()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Public Sub Load_Settings(emp As Employee, tabName As String, Optional category As String = "")
        With emp

            If tabName = "RATE" Then

                Rate_BioNo_TXT.Text = .BiometricID
                Rate_BioNo_TXT.Tag = .BRANCH_CODE
                Rate_Employee_TXT.Text = .Fullname
                Rate_Employee_TXT.Tag = .EMP_ID

                'ElseIf tabName = "ALLOWANCE" Then

                '    Allow_Name_TXT.Text = .Fullname
                '    Allow_Name_TXT.Tag = .BiometricID
                '    Allow_SearchEmp_BTN.Tag = .BRANCH_CODE
                '    Label14.Tag = .EMP_ID
                '    Settings_Tab.SelectedIndex = 2
                '    Allow_Category_Combo.SelectedItem = category

            ElseIf tabName = "TIMEIN/OUT" Then

                ClockEmp_TXT.Text = .Fullname
                ClockBio_TXT.Text = .BiometricID
                ClockEmp_IN_CB.Text = .TIME_IN
                ClockEmp_OUT_CB.Text = .TIME_OUT
            End If

        End With
    End Sub

    Private Sub SearchTime_BTN_Click(sender As Object, e As EventArgs) Handles SearchTime_BTN.Click
        Lists_TimeInOut(TimeInOut_LV, SearchTime_TXT.Text)
    End Sub

    Private Sub SearchTime_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles SearchTime_TXT.KeyPress
        If IsEnter(e) Then SearchTime_BTN.PerformClick()
    End Sub

    Private Sub SaveCity_BTN_Click(sender As Object, e As EventArgs) Handles SaveCity_BTN.Click
        'SaveCityBranch() 

        If City_Combo.Text <> Nothing And CityBName_Combo.Text <> Nothing And CityCode_Combo.Text <> Nothing And Address_Combo.Text <> Nothing Then

            Dim result As DialogResult = MsgBox($"Branch information will be Saved/Updated, proceed anyway?", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then

                SaveCityBranch(CityCode_Combo.Text, CityBName_Combo.Text, City_Combo.Text, BranchCategory_Combo.Text, Address_Combo.Text)
                Lists_City_Branch(CityBranch_List)

                '==================== TRANSACTION LOGS =========================
                If SaveCity_BTN.Tag = Nothing Then SaveCity_BTN.Tag = "ADDED"
                SaveLogs($"{SaveCity_BTN.Tag} CITY BRANCH - City({City_Combo.Text}), Code({CityCode_Combo.Text}), BranchName({CityBName_Combo.Text}), BranchCat({BranchCategory_Combo.Text}), Address({Address_Combo.Text})", frmMainForm.UserName_LBL.Text)
            End If

        Else
            MsgBox("Please Complete the Details", MsgBoxStyle.Exclamation, "Error")
        End If
    End Sub

    Private Sub ClearCity_BTN_Click(sender As Object, e As EventArgs) Handles ClearCity_BTN.Click
        City_Combo.Text = Nothing
        CityBName_Combo.Text = Nothing
        CityCode_Combo.Text = Nothing
    End Sub

    Private Sub CityBranch_List_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles CityBranch_List.MouseDoubleClick

        If CityBranch_List.Items.Count = 0 Then Exit Sub
        City_Combo.Text = CityBranch_List.Items(CityBranch_List.FocusedItem.Index).SubItems(0).Text
        CityBName_Combo.Text = CityBranch_List.Items(CityBranch_List.FocusedItem.Index).SubItems(1).Text
        CityCode_Combo.Text = CityBranch_List.Items(CityBranch_List.FocusedItem.Index).SubItems(2).Text
        Address_Combo.Text = CityBranch_List.Items(CityBranch_List.FocusedItem.Index).SubItems(3).Text
        BranchCategory_Combo.Text = CityBranch_List.Items(CityBranch_List.FocusedItem.Index).SubItems(4).Text

        SaveCity_BTN.Tag = "UPDATE"
    End Sub

    Private Sub City_Combo_TextChanged(sender As Object, e As EventArgs) Handles CityCode_Combo.TextChanged, City_Combo.TextChanged
        Dim selectionStart As Integer = sender.SelectionStart

        sender.Text = sender.Text.ToUpper()
        sender.SelectionStart = selectionStart
    End Sub

    Private Sub SearchCity_BTN_Click(sender As Object, e As EventArgs) Handles SearchCity_BTN.Click
        Lists_City_Branch(CityBranch_List, SearchCity_TXT.Text)
    End Sub

    Private Sub SearchCity_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles SearchCity_TXT.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SearchCity_BTN.PerformClick()
        End If
    End Sub

    Private Sub Rate_list_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Rate_list.MouseDoubleClick
        If Rate_list.Items.Count = 0 Then Exit Sub
        Rate_BioNo_TXT.Text = Rate_list.Items(Rate_list.FocusedItem.Index).SubItems(2).Text
    End Sub

    Private Sub CityClear_BTN_Click(sender As Object, e As EventArgs) Handles CityClear_BTN.Click
        Rate_City_ComboB.Text = ""
        Rate_CityAmount_TXT.Clear()
        Ecola_TXT.Clear()
    End Sub

    Private Sub Rate_City_ComboB_SelectedValueChanged(sender As Object, e As EventArgs) Handles Rate_City_ComboB.SelectedValueChanged
        Dim ecola = GetEcola("CITY", Rate_City_ComboB.SelectedItem)
        Rate_CityAmount_TXT.Text = GetMinimumRate("CITY", Rate_City_ComboB.SelectedItem)
        Rate_CityAmount_TXT.Tag = Rate_CityAmount_TXT.Text
        Ecola_TXT.Text = IIf(ecola = 0, Nothing, ecola)
    End Sub

    Private Sub RegularRate_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles SpecialRate_TXT.KeyPress, RegularRate_TXT.KeyPress
        If e.KeyChar <> ChrW(Keys.Back) Then
            If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub

End Class