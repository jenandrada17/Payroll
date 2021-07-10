

Public Class frmSettings


    Private Sub frmSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Date_DTP.CustomFormat = "MM/yyyy"

        If ThisHasRow("PAYROLL_HOLIDAY_RATE") Then
            HolidayRate(RegularRate_TXT, SpecialRate_TXT)
        End If

        PopulateComboBox(Rate_Branch_ComboB, "tbl_branch", "BRANCHNAME")
        PopulateComboBox(Rate_Pos_ComboB, "tbl_employee", "EMP_POSITION")
        PopulateSettings_Rate(Rate_grid, "BRANCHNAME")
        Lists_Allowance(Allowance_LV)

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

        If frmEmployee Is Nothing Then
            Dim frm As New frmEmployee With {
                .MdiParent = frmMainForm
            }
            frmMainForm.pNavigate.Controls.Add(frm)
            frmMainForm.pNavigate.Tag = frm
            frm.txtSearch.Tag = "Settings-Rate"
            frm.Show()
            frm.Dock = DockStyle.Fill
            frm.BringToFront()
        Else
            frmEmployeeInfo.BringToFront()
        End If

        Close()

    End Sub

    Private Sub Rate_EmpSave_BTN_Click(sender As Object, e As EventArgs) Handles Rate_EmpSave_BTN.Click
        If Not Rate_BioNo_TXT.Text = "" Then

            SaveRATE(Rate_BioNo_TXT.Text, "BIOMETRICID", Rate_EmpAmount_TXT.Text, False, Rate_BioNo_TXT.Tag) ' === Rate_BioNo_TXT.Tag is BRANCHid ====


            Rate_EmpClear_BTN.PerformClick()
        End If
    End Sub

    Private Sub Rate_EmpClear_BTN_Click(sender As Object, e As EventArgs) Handles Rate_EmpClear_BTN.Click
        Rate_BioNo_TXT.Text = ""
        Rate_Employee_TXT.Text = ""
        Rate_EmpAmount_TXT.Text = ""
    End Sub

    Private Sub Rate_BioNo_TXT_TextChanged(sender As Object, e As EventArgs) Handles Rate_BioNo_TXT.TextChanged

        If Rate_BioNo_TXT.Text = "" Then
            Rate_Employee_TXT.Text = ""
        Else
            BiometricNo_Payout(Rate_BioNo_TXT.Text, Rate_Employee_TXT, Rate_EmpAmount_TXT)
        End If

    End Sub

    Private Sub Rate_Position_BTN_Click(sender As Object, e As EventArgs) Handles Rate_Position_BTN.Click
        If Rate_Pos_ComboB.SelectedIndex >= 0 And Not Rate_PosAmount_TXT.Text = "" Then

            SaveRATE(Rate_Pos_ComboB.SelectedItem, "EMP_POSITION", Rate_PosAmount_TXT.Text, True)

            Rate_Pos_ComboB.Text = "   Select Position"
            Rate_PosAmount_TXT.Clear()

            PopulateSettings_Rate(Rate_grid, "EMP_POSITION")
        End If
    End Sub

    Private Sub Rate_Branch_ComboB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Rate_Branch_ComboB.SelectedIndexChanged
        Get_Branch_ID(Rate_Branch_ComboB.SelectedItem, Rate_Branch_ComboB)
    End Sub

    Private Sub Rate_Branch_BTN_Click(sender As Object, e As EventArgs) Handles Rate_Branch_BTN.Click
        If Rate_Branch_ComboB.SelectedIndex >= 0 And Not Rate_BranchAmount_TXT.Text = "" Then

            SaveRATE(Rate_Branch_ComboB.Tag, "BRANCH_ID", Rate_BranchAmount_TXT.Text, True)

            Rate_Branch_ComboB.Text = "   Select Branch"
            Rate_BranchAmount_TXT.Clear()

            PopulateSettings_Rate(Rate_grid, "BRANCHNAME")

        End If
    End Sub

    Private Sub Rate_BranchAmount_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Rate_PosAmount_TXT.KeyPress, Rate_EmpAmount_TXT.KeyPress, Rate_BranchAmount_TXT.KeyPress, Rate_BioNo_TXT.KeyPress, Allow_Amount_TXT.KeyPress
        If e.KeyChar <> ChrW(Keys.Back) Then
            If Char.IsNumber(e.KeyChar) Then
            Else
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub Rate_Search_BTN_Click(sender As Object, e As EventArgs) Handles Rate_Search_BTN.Click
        Search_Settings_Rate(Rate_Search_TXT.Text, Rate_grid)
    End Sub

    Private Sub Rate_Search_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Rate_Search_TXT.KeyPress
        If IsEnter(e) Then Rate_Search_BTN.PerformClick()
    End Sub

    Private Sub Allow_Search_BTN_Click(sender As Object, e As EventArgs) Handles Allow_SearchEmp_BTN.Click

        If frmEmployee Is Nothing Then
            Dim frm As New frmEmployee With {
                .MdiParent = frmMainForm
            }
            frmMainForm.pNavigate.Controls.Add(frm)
            frmMainForm.pNavigate.Tag = frm
            frm.txtSearch.Tag = "Settings-Allowance"
            frm.btnSearch.Tag = Allow_Category_Combo.SelectedItem
            frm.Show()
            frm.Dock = DockStyle.Fill
            frm.BringToFront()
        Else
            frmEmployeeInfo.BringToFront()
        End If

        Close()

    End Sub

    Private Sub Allow_Category_Combo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Allow_Category_Combo.SelectedIndexChanged
        If Allow_Category_Combo.SelectedIndex = 3 Then
            Allow_Fix_group.Visible = True
        Else
            Allow_Fix_group.Visible = False
        End If
    End Sub

    Private Sub Allow_Save_BTN_Click(sender As Object, e As EventArgs) Handles Allow_Save_BTN.Click

        If Allow_Category_Combo.SelectedIndex >= 0 And Not Allow_Name_TXT.Text = "" Then

            If FixYes_RadioB.Checked Then
                SaveSettings(Allow_Name_TXT.Tag, Allow_SearchEmp_BTN.Tag, Allow_Category_Combo.SelectedItem, Allow_Amount_TXT.Text, True)
            Else
                SaveSettings(Allow_Name_TXT.Tag, Allow_SearchEmp_BTN.Tag, Allow_Category_Combo.SelectedItem, Allow_Amount_TXT.Text, False)
            End If

            Lists_Allowance(Allowance_LV)
            Allow_Cancel_BTN.PerformClick()
        End If

    End Sub

    Private Sub Allow_Cancel_BTN_Click(sender As Object, e As EventArgs) Handles Allow_Cancel_BTN.Click
        Allow_Category_Combo.Text = "Select"
        Allow_Name_TXT.Text = ""
        Allow_Amount_TXT.Text = ""
        FixNo_RadioB.Checked = False
        Allow_Fix_group.Visible = False
    End Sub

    Private Sub Allow_Remove_Click(sender As Object, e As EventArgs) Handles Allow_Remove.Click
        If Allowance_LV.SelectedItems.Count > 0 Then
            For Each item As ListViewItem In Allowance_LV.SelectedItems
                AllowanceRemove(item.Tag, item.SubItems(1).Tag, item.SubItems(0).Text)
                Lists_Allowance(Allowance_LV)
            Next
        End If
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
End Class