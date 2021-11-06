

Public Class frmSettings

    Private Sub frmSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Date_DTP.CustomFormat = "MM/yyyy"

        If ThisHasRow("PAYROLL_HOLIDAY_RATE") Then
            HolidayRate(RegularRate_TXT, SpecialRate_TXT)
        End If

        If ThisHasRow("PAYROLL_EMAIL") Then
            GetEmail(Email_TXT, Password_TXT)
        End If

        PopulateComboBox_Any(Rate_City_ComboB, "PAYROLL_EMPLOYEE", "BRANCH_CITY")
        PopulateComboBox_Any(ClockBranch_CB, "PAYROLL_EMPLOYEE", "BRANCH_CODE")
        PopulateComboBox(Allow_Category_Combo, "CATEGORY_ALLOWANCE", "ALLOWANCE_NAME")
        PopulateComboBox(DE_Category_Combo, "CATEGORY_DEDUCTION", "DEDUCTION_NAME")
        PopulateComboBox_Any(City_Combo, "PAYROLL_EMPLOYEE", "BRANCH_CITY")
        PopulateComboBox_Any(CityCode_Combo, "PAYROLL_EMPLOYEE", "BRANCH_CODE")
        Lists_Rate(Rate_list)
        Lists_Allowance(Allowance_LV)
        Lists_deduction(Deduction_List)
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
                    REGULDARHolidayLists(lvHoliday)
                Else
                    SaveHoliday(customizeDate, Name_TXT.Text, "SPECIAL")
                    SPECIALHolidayLists(lvHoliday)
                End If

            Else

                If Regular_RB.Checked = True Then
                    UpdateHoliday(customizeDate, Name_TXT.Text, "REGULAR")
                    REGULDARHolidayLists(lvHoliday)
                Else
                    UpdateHoliday(customizeDate, Name_TXT.Text, "SPECIAL")
                    SPECIALHolidayLists(lvHoliday)
                End If

            End If

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
            For Each item As ListViewItem In lvHoliday.SelectedItems
                RemoveHoliday(item.SubItems(0).Text)

                If Regular_RB.Checked = True Then
                    REGULDARHolidayLists(lvHoliday)
                Else
                    SPECIALHolidayLists(lvHoliday)
                End If

            Next
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

            SaveRATE("BIO_NO", Rate_BioNo_TXT.Text, Rate_EmpAmount_TXT.Text)

            Rate_EmpClear_BTN.PerformClick()
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
        Else
            Payout_Details(Rate_BioNo_TXT.Text, Rate_Employee_TXT, Rate_EmpAmount_TXT, MonthlyRate_TXT)
        End If

    End Sub

    Private Sub Rate_Branch_BTN_Click(sender As Object, e As EventArgs) Handles Rate_Branch_BTN.Click
        If Rate_City_ComboB.SelectedIndex >= 0 And Not Rate_CityAmount_TXT.Text = "" Then

            SaveRATE("BRANCH_CITY", Rate_City_ComboB.Text, Rate_CityAmount_TXT.Text, True)

            SaveMinimum_RATE(Rate_City_ComboB.Text, Rate_CityAmount_TXT.Text)

            Rate_City_ComboB.Text = "   Select Branch"
            Rate_CityAmount_TXT.Clear()

            MsgBox("Successfully updated!", MsgBoxStyle.Information, "Information")

            Lists_Rate(Rate_list)

        End If
    End Sub

    Private Sub Rate_BranchAmount_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Rate_CityAmount_TXT.KeyPress,
                                                Rate_BioNo_TXT.KeyPress, Allow_Amount_TXT.KeyPress, DE_NoOfGives_TXT.KeyPress,
                                                DE_AmountGive_TXT.KeyPress, DE_Total_TXT.KeyPress

        If e.KeyChar <> ChrW(Keys.Back) Then

            If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso Not e.KeyChar = "." Then
                e.Handled = True
            End If
        End If

        'If e.KeyChar <> ChrW(Keys.Back) Then
        '    If Char.IsNumber(e.KeyChar) Then
        '    Else
        '        e.Handled = True
        '    End If
        'End If

    End Sub

    Private Sub Rate_Search_BTN_Click(sender As Object, e As EventArgs) Handles Rate_Search_BTN.Click
        Lists_Rate(Rate_list, Rate_Search_TXT.Text)
    End Sub

    Private Sub Rate_Search_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Rate_Search_TXT.KeyPress
        If IsEnter(e) Then Rate_Search_BTN.PerformClick()
    End Sub

    Private Sub Allow_Search_BTN_Click(sender As Object, e As EventArgs) Handles Allow_SearchEmp_BTN.Click
        Try
            Dim instForm As Form = Application.OpenForms.OfType(Of Form)().Where(Function(frm) frm.Name = "frmNewEmployee").SingleOrDefault()
            If instForm Is Nothing Then
                Dim frm As frmNewEmployee
                frm = DirectCast(CreateObjectInstance("frmNewEmployee"), Form)
                frm.MdiParent = frmMainForm
                frmMainForm.pNavigate.Controls.Add(frm)
                frmMainForm.pNavigate.Tag = frm
                frm.txtSearch.Tag = "Settings-Allowance"
                frm.btnSearch.Tag = Allow_Category_Combo.SelectedItem
                frm.Dock = DockStyle.Fill
                frm.BringToFront()
                frm.Show()
            Else
                instForm.BringToFront()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Allow_Save_BTN_Click(sender As Object, e As EventArgs) Handles Allow_Save_BTN.Click

        Dim fix As String = "No"
        Dim everyThisDate As Integer = 0

        If Not isValidSave_ALLOW() Then Exit Sub

        If Not A_EveryDate_Combo.Text = "Select date of the month" Then everyThisDate = A_EveryDate_Combo.SelectedItem

        If FixYes_RadioB.Checked Then fix = "YES"

        SaveAllowance(Allow_Name_TXT.Tag, Allow_Category_Combo.Text, Allow_Amount_TXT.Text, fix, Allow_Schedule_Combo.SelectedItem, everyThisDate, A_EffectiveDate_DTP.Value) ' Label14 is EMP_ID

        Lists_Allowance(Allowance_LV)
        Allow_Cancel_BTN.PerformClick()

    End Sub

    Private Function isValidSave_ALLOW()

        Dim num2 = Val(Allow_Amount_TXT.Text)

        If String.IsNullOrEmpty(Allow_Name_TXT.Text) Then
            MsgBox("Please select a name.", MsgBoxStyle.Critical, "Error")
            Return False

        ElseIf Allow_Category_Combo.SelectedIndex < 0 Then
            Allow_Category_Combo.Region = New Region(New Rectangle(2, 2, Allow_Category_Combo.Width - 4, Allow_Category_Combo.Height - 4))
            Return False

        ElseIf Allow_Schedule_Combo.SelectedIndex < 0 Then
            Allow_Schedule_Combo.Region = New Region(New Rectangle(2, 2, Allow_Schedule_Combo.Width - 4, Allow_Schedule_Combo.Height - 4))
            Return False

        ElseIf Allow_Schedule_Combo.SelectedIndex = 3 Or Allow_Schedule_Combo.SelectedIndex = 4 Then

            If A_EveryDate_Combo.SelectedIndex < 0 Then
                A_EveryDate_Combo.Region = New Region(New Rectangle(2, 2, A_EveryDate_Combo.Width - 4, A_EveryDate_Combo.Height - 4))
                Return False
            End If

        ElseIf String.IsNullOrEmpty(Allow_Amount_TXT.Text) Then
            Allow_Amount_TXT.Region = New Region(New Rectangle(2, 2, Allow_Amount_TXT.Width - 4, Allow_Amount_TXT.Height - 4))
            Return False

        End If

        Return True
    End Function


    Private Function isValidSave_DEDUC()

        Dim num2 = Val(Allow_Amount_TXT.Text)

        If String.IsNullOrEmpty(DE_Name_TXT.Text) Then
            MsgBox("Please select a name.", MsgBoxStyle.Critical, "Error")
            Return False

        ElseIf DE_Category_Combo.SelectedIndex < 0 Then
            DE_Category_Combo.Region = New Region(New Rectangle(2, 2, DE_Category_Combo.Width - 4, DE_Category_Combo.Height - 4))
            Return False

        ElseIf DE_Schedule_Combo.SelectedIndex < 0 Then
            DE_Schedule_Combo.Region = New Region(New Rectangle(2, 2, DE_Schedule_Combo.Width - 4, DE_Schedule_Combo.Height - 4))
            Return False

        ElseIf String.IsNullOrEmpty(DE_Total_TXT.Text) Then
            DE_Total_TXT.Region = New Region(New Rectangle(2, 2, DE_Total_TXT.Width - 4, DE_Total_TXT.Height - 4))
            Return False

        ElseIf String.IsNullOrEmpty(DE_NoOfGives_TXT.Text) Then
            DE_NoOfGives_TXT.Region = New Region(New Rectangle(2, 2, DE_NoOfGives_TXT.Width - 4, DE_NoOfGives_TXT.Height - 4))
            Return False
        End If

        Return True
    End Function


    Private Sub Allow_Cancel_BTN_Click(sender As Object, e As EventArgs) Handles Allow_Cancel_BTN.Click
        Allow_Category_Combo.Text = "Select"
        Allow_Name_TXT.Text = ""
        Allow_Amount_TXT.Text = ""
        FixNo_RadioB.Checked = False
        Allow_Schedule_Combo.Text = "Select"
        A_EveryDate_Combo.Text = "Select"
        A_EffectiveDate_DTP.Value = Today
    End Sub

    Private Sub Allowance_LV_MouseClick(sender As Object, e As MouseEventArgs) Handles Allowance_LV.MouseClick
        If e.Button = MouseButtons.Right Then
            If Allowance_LV.Items.Count > 0 Then
                Allowance_Remove.Show(Allowance_LV, New Point(e.X, e.Y))
            End If
        End If
    End Sub

    Private Sub Allow_Search_BTN_Click_1(sender As Object, e As EventArgs) Handles Allow_Search_BTN.Click
        Lists_Allowance(Allowance_LV, Allow_Search_TXT.Text)
    End Sub

    Private Sub Allow_Search_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Allow_Search_TXT.KeyPress
        If IsEnter(e) Then Allow_Search_BTN.PerformClick()
    End Sub

    Private Sub DE_SearchEmp_BTN_Click(sender As Object, e As EventArgs) Handles DE_SearchEmp_BTN.Click
        Try
            Dim instForm As Form = Application.OpenForms.OfType(Of Form)().Where(Function(frm) frm.Name = "frmNewEmployee").SingleOrDefault()
            If instForm Is Nothing Then
                Dim frm As frmNewEmployee
                frm = DirectCast(CreateObjectInstance("frmNewEmployee"), Form)
                frm.MdiParent = frmMainForm
                frmMainForm.pNavigate.Controls.Add(frm)
                frmMainForm.pNavigate.Tag = frm
                frm.txtSearch.Tag = "Settings-Deduction"
                frm.btnSearch.Tag = DE_Category_Combo.SelectedItem
                frm.Dock = DockStyle.Fill
                frm.BringToFront()
                frm.Show()
            Else
                instForm.BringToFront()
            End If

        Catch ex As Exception

        End Try

        'If frmEmployee Is Nothing Then
        '    Dim frm As New frmEmployee With {
        '        .MdiParent = frmMainForm
        '    }
        '    frmMainForm.pNavigate.Controls.Add(frm)
        '    frmMainForm.pNavigate.Tag = frm
        '    frm.txtSearch.Tag = "Settings-Deduction"
        '    frm.btnSearch.Tag = DE_Category_Combo.SelectedItem
        '    frm.Show()
        '    frm.Dock = DockStyle.Fill
        '    frm.BringToFront()
        'Else
        '    frmEmployee.BringToFront()
        'End If

        'Close()

    End Sub

    Private Sub DE_Cancel_BTN_Click(sender As Object, e As EventArgs) Handles DE_Cancel_BTN.Click
        DE_Category_Combo.Text = "Select"
        DE_Name_TXT.Clear()
        DE_Total_TXT.Clear()
        DE_NoOfGives_TXT.Clear()
        DE_AmountGive_TXT.Clear()
        DE_Schedule_Combo.Text = "Select"
    End Sub

    Private Sub DE_Save_BTN_Click(sender As Object, e As EventArgs) Handles DE_Save_BTN.Click

        If Not isValidSave_DEDUC() Then Exit Sub
        '======================================== CHECK IF CONTEXT EDIT CLICK =======================================
        If Deduction_List.Tag = 0 Then
            SaveDeductionS(DE_Category_Combo.SelectedItem, DE_Total_TXT.Text, DE_NoOfGives_TXT.Text, DE_AmountGive_TXT.Text, DE_Schedule_Combo.Text, DE_Name_TXT.Tag, DE_Effectivity_DTP.Value) 'DE_Category_Combo.Tag (EMP_ID) | DE_Name_TXT.Tag(Biometric) |  DE_SearchEmp_BTN.Tag.Tag(Branch_id) | 
        Else
            updateDeductionS(Deduction_List.Tag, DE_Category_Combo.Text, DE_Total_TXT.Text, DE_NoOfGives_TXT.Text, DE_AmountGive_TXT.Text, DE_Schedule_Combo.Text, DE_Effectivity_DTP.Value) 'DE_Category_Combo.Tag (EMP_ID)
        End If

        Lists_deduction(Deduction_List)
        DE_Cancel_BTN.PerformClick()

    End Sub


    Private Sub DE_Search_BTN_Click(sender As Object, e As EventArgs) Handles DE_Search_BTN.Click
        Lists_deduction(Deduction_List, DE_Search_TXT.Text)
    End Sub

    Private Sub DE_Search_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DE_Search_TXT.KeyPress
        If IsEnter(e) Then DE_Search_BTN.PerformClick()
    End Sub

    Private Sub Cat_Allow_Save_BTN_Click(sender As Object, e As EventArgs) Handles Cat_Allow_Save_BTN.Click
        If Not AllowCat_TXT.Text = "" Then
            SaveCATEGORY(AllowCat_TXT.Text, "CATEGORY_ALLOWANCE", "ALLOWANCE_NAME")
            Load_Category_LIST(Allowance_List, "CATEGORY_ALLOWANCE", "ALLOWANCE_NAME")
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
                SaveEmail(Email_TXT.Text, Password_TXT.Text)
                Email_TXT.Clear()
                Password_TXT.Clear()
                Email_TXT.ReadOnly = True
                Password_TXT.ReadOnly = True
                GetEmail(Email_TXT, Password_TXT)
                Email_Save_BTN.Text = "Change"
            Else
                MsgBox("Please Complete the information!", MsgBoxStyle.Information, "Information")
            End If
        End If

    End Sub

    Private Sub Allow_Schedule_Combo_SelectedIndexChanged(sender As Object, e As EventArgs)
        If Allow_Schedule_Combo.SelectedIndex = 3 Or Allow_Schedule_Combo.SelectedIndex = 4 Then
            Label32.Visible = True
            A_EveryDate_Combo.Visible = True
        Else
            Label32.Visible = False
            A_EveryDate_Combo.Visible = False
        End If
    End Sub

    Private Sub menu_subtotal_Click(sender As Object, e As EventArgs) Handles menu_subtotal.Click
        Dim bioNo, total_amount, open_amount, close_amount, every_amount, balance As String

        If Deduction_List.SelectedItems.Count > 0 Then
            bioNo = Deduction_List.Items(Deduction_List.FocusedItem.Index).SubItems(1).Tag
            total_amount = GetDeduction_TotalAmount(bioNo)

            every_amount = GetDeduction_EVERY(bioNo)

            open_amount = GetDeduction_OPEN(bioNo) + every_amount
            close_amount = GetDeduction_CLOSE(bioNo) + every_amount
            balance = GetDeduction_OverAll_Balance(bioNo)

            MsgBox("Total Amount     :  " & total_amount & vbCrLf &
                   "Open Payroll      :  " & open_amount & vbCrLf &
                   "Close Payroll      :  " & close_amount & vbCrLf &
                   "Balance               :  " & balance, MsgBoxStyle.Information, "TOTAL")
        End If

    End Sub

    Private Sub Deduction_List_MouseClick(sender As Object, e As MouseEventArgs) Handles Deduction_List.MouseClick
        If e.Button = MouseButtons.Right Then
            If Deduction_List.Items.Count > 0 Then
                Context_deduct.Show(Deduction_List, New Point(e.X, e.Y))
            End If
        End If
    End Sub

    Private Sub menu_edit_Click(sender As Object, e As EventArgs) Handles menu_edit.Click
        DE_Name_TXT.Text = Deduction_List.Items(Deduction_List.FocusedItem.Index).SubItems(0).Text
        DE_Name_TXT.Tag = Deduction_List.Items(Deduction_List.FocusedItem.Index).SubItems(1).Tag
        DE_Category_Combo.Text = Deduction_List.Items(Deduction_List.FocusedItem.Index).SubItems(1).Text
        DE_Schedule_Combo.Text = Deduction_List.Items(Deduction_List.FocusedItem.Index).SubItems(5).Text
        DE_Total_TXT.Text = Deduction_List.Items(Deduction_List.FocusedItem.Index).SubItems(2).Text
        DE_NoOfGives_TXT.Text = Deduction_List.Items(Deduction_List.FocusedItem.Index).SubItems(3).Text
        DE_AmountGive_TXT.Text = Deduction_List.Items(Deduction_List.FocusedItem.Index).SubItems(4).Text
        Deduction_List.Tag = Deduction_List.Items(Deduction_List.FocusedItem.Index).SubItems(2).Tag
    End Sub

    Private Sub FlowLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles FlowLayoutPanel1.Paint
        Dim txtbox As TextBox = Nothing
        Dim comboB As ComboBox = Nothing
        For Each xObject As Object In FlowLayoutPanel1.Controls
            Dim p As New Pen(Color.Red, 2)
            If TypeOf xObject Is TextBox Then
                txtbox = xObject
                e.Graphics.DrawRectangle(p, New Rectangle(txtbox.Location + New Size(1, 1), txtbox.Size - New Size(2, 2)))
            ElseIf TypeOf xObject Is ComboBox Then
                comboB = xObject
                e.Graphics.DrawRectangle(p, New Rectangle(comboB.Location + New Size(1, 1), comboB.Size - New Size(2, 2)))
            End If
            p.Dispose()
        Next
    End Sub

    Private Sub Allow_Category_Combo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Allow_Schedule_Combo.SelectedIndexChanged, Allow_Category_Combo.SelectedIndexChanged, A_EveryDate_Combo.SelectedIndexChanged
        Dim cmb As ComboBox = DirectCast(sender, ComboBox)
        If cmb.SelectedIndex >= 0 Then
            cmb.Region = Nothing
        End If
    End Sub

    Private Sub Allow_Amount_TXT_TextChanged(sender As Object, e As EventArgs) Handles Allow_Amount_TXT.TextChanged
        If Allow_Amount_TXT.Text <> Nothing Then
            Allow_Amount_TXT.Region = Nothing
        End If
    End Sub

    Private Sub GroupBox6_Paint(sender As Object, e As PaintEventArgs) Handles GroupBox6.Paint
        Dim txtbox As TextBox = Nothing
        Dim comboB As ComboBox = Nothing
        For Each xObject As Object In GroupBox6.Controls
            Dim p As New Pen(Color.Red, 2)
            If TypeOf xObject Is TextBox Then
                txtbox = xObject
                e.Graphics.DrawRectangle(p, New Rectangle(txtbox.Location + New Size(1, 1), txtbox.Size - New Size(2, 2)))
            ElseIf TypeOf xObject Is ComboBox Then
                comboB = xObject
                e.Graphics.DrawRectangle(p, New Rectangle(comboB.Location + New Size(1, 1), comboB.Size - New Size(2, 2)))
            End If
            p.Dispose()
        Next
    End Sub

    Private Sub DE_Category_Combo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DE_Schedule_Combo.SelectedIndexChanged, DE_Category_Combo.SelectedIndexChanged
        Dim cmb As ComboBox = DirectCast(sender, ComboBox)
        If cmb.SelectedIndex >= 0 Then
            cmb.Region = Nothing
        End If
    End Sub

    Private Sub DE_NoOfGives_TXT_TextChanged(sender As Object, e As EventArgs) Handles DE_NoOfGives_TXT.TextChanged
        If Not DE_Total_TXT.Text = String.Empty And Not DE_NoOfGives_TXT.Text = String.Empty And IsNumeric(DE_NoOfGives_TXT.Text) Then
            DE_AmountGive_TXT.Text = Math.Ceiling(Convert.ToDouble(DE_Total_TXT.Text) / Convert.ToDouble(DE_NoOfGives_TXT.Text))
            DE_NoOfGives_TXT.Region = Nothing
        Else
            DE_AmountGive_TXT.Clear()
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


    Private Sub ApproveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ApproveToolStripMenuItem.Click

        If Allowance_LV.SelectedItems.Count > 0 Then

            Dim bio_No As String = Allowance_LV.Items(Allowance_LV.FocusedItem.Index).SubItems(1).Tag

            AllowanceRemove(bio_No, "YES") ' ===== ALLOWANCE ID =====
            Lists_Allowance(Allowance_LV)

        End If

    End Sub

    Private Sub Allow_Disapprove_Click(sender As Object, e As EventArgs) Handles Allow_Disapprove.Click
        If Allowance_LV.SelectedItems.Count > 0 Then

            Dim bio_No As String = Allowance_LV.Items(Allowance_LV.FocusedItem.Index).SubItems(1).Tag

            AllowanceRemove(bio_No, "NO") ' ===== ALLOWANCE ID =====
            Lists_Allowance(Allowance_LV)
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
            Save_ClockINOUT("BRANCH_CODE", ClockBranch_CB.Text, ClockBranch_IN_CB.Text, ClockBranch_OUT_CB.Text)
            Lists_TimeInOut(TimeInOut_LV)
            ClearlBranch_BTN.PerformClick()
        End If

    End Sub

    Private Sub ClockSave_BTN_Click(sender As Object, e As EventArgs) Handles ClockSave_BTN.Click

        If ClockEmp_TXT.Text <> "" And ClockEmp_IN_CB.SelectedIndex >= 0 And ClockEmp_OUT_CB.SelectedIndex >= 0 Then
            Save_ClockINOUT("BIO_NO", ClockBio_TXT.Text, ClockEmp_IN_CB.Text, ClockEmp_OUT_CB.Text)
            Lists_TimeInOut(TimeInOut_LV)
            ClockClear_BTN.PerformClick()
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

            ElseIf tabName = "ALLOWANCE" Then

                Allow_Name_TXT.Text = .Fullname
                Allow_Name_TXT.Tag = .BiometricID
                Allow_SearchEmp_BTN.Tag = .BRANCH_CODE
                Label14.Tag = .EMP_ID
                Settings_Tab.SelectedIndex = 2
                Allow_Category_Combo.SelectedItem = category

            ElseIf tabName = "DEDUCTION" Then

                DE_Name_TXT.Text = .Fullname
                DE_Category_Combo.Tag = .EMP_ID
                DE_Name_TXT.Tag = .BiometricID
                DE_SearchEmp_BTN.Tag = .BRANCH_CODE
                Settings_Tab.SelectedIndex = 3
                DE_Category_Combo.SelectedItem = category

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


        If City_Combo.Text <> Nothing And CityBName_Combo.Text <> Nothing And CityCode_Combo.Text <> Nothing Then
            SaveCityBranch(CityCode_Combo.Text, CityBName_Combo.Text, City_Combo.Text)
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

    End Sub

    Private Sub City_Combo_TextChanged(sender As Object, e As EventArgs) Handles CityCode_Combo.TextChanged, CityBName_Combo.TextChanged, City_Combo.TextChanged
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

End Class