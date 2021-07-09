

Public Class frmSettings


    Private Sub frmSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Date_DTP.CustomFormat = "MM/yyyy"

        If ThisHasRow("PAYROLL_HOLIDAY_RATE") Then
            HolidayRate(RegularRate_TXT, SpecialRate_TXT)
        End If

        PopulateComboBox(Rate_Branch_ComboB, "tbl_branch", "BRANCHNAME")
        PopulateComboBox(Rate_Pos_ComboB, "tbl_employee", "EMP_POSITION")

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
                Context_Remove.Show(lvHoliday, New Point(e.X, e.Y))
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
            SaveSettings(Rate_BioNo_TXT.Text, "RATE", Rate_EmpAmount_TXT.Text, False)
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
            BiometricNo_Payout(Rate_BioNo_TXT.Text, Rate_Employee_TXT)
        End If

    End Sub

    Private Sub Rate_Position_BTN_Click(sender As Object, e As EventArgs) Handles Rate_Position_BTN.Click
        If Rate_Pos_ComboB.SelectedIndex >= 0 Then
            Console.WriteLine("thiss " & )
            SaveSettings(Rate_Pos_ComboB.SelectedItem, "EMP_POSITION", Rate_PosAmount_TXT.Text, True)
            Rate_PosAmount_TXT.Text = "   Select Position"
            Rate_PosAmount_TXT.Clear()
        End If
    End Sub

    Private Sub Rate_Branch_ComboB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Rate_Branch_ComboB.SelectedIndexChanged
        Get_Branch_ID(Rate_Branch_ComboB.SelectedItem, Rate_Branch_ComboB)
    End Sub

    Private Sub Rate_Branch_BTN_Click(sender As Object, e As EventArgs) Handles Rate_Branch_BTN.Click

    End Sub
End Class