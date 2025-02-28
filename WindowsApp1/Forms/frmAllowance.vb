Imports System.Security
Imports Microsoft.Reporting.WinForms

Public Class frmAllowance

    Private Sub Close_LBL_Click(sender As Object, e As EventArgs) Handles Close_LBL.Click
        Close()
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

    Private Sub Allow_Save_BTN_Click_1(sender As Object, e As EventArgs) Handles Allow_Save_BTN.Click
        Dim SaveStat As String

        Dim fix As String = "NO"
        Dim everyThisDate As Integer = 0
        Dim idNo As Integer = 0

        If Not isValidSave_ALLOW() Then Exit Sub

        If Not A_EveryDate_Combo.Text = "Select date of the month" Then everyThisDate = A_EveryDate_Combo.SelectedItem

        If FixYes_RadioB.Checked Then fix = "YES"

        Dim result As DialogResult = MsgBox($"Allowance for {Allow_Name_TXT.Text} will be Recorded, proceed anyway?", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then

            If Name_lbl.Tag = "UPDATE" Then
                SaveStat = "UPDATED"
                idNo = Allowance_LV.Items(Allowance_LV.FocusedItem.Index).SubItems(4).Tag
            Else
                SaveStat = "ADDED"
            End If

            SaveAllowance(idNo, Allow_Name_TXT.Tag, Allow_Category_Combo.Text, Allow_Amount_TXT.Text, fix, Allow_Schedule_Combo.SelectedItem, everyThisDate, A_EffectiveDate_DTP.Value)

            '================= SAVE PI HISTORY ================ 
            If Allow_Category_Combo.Text = "PERFORMANCE INCENTIVES" Then
                SaveAllowance_HISTORY(Allow_Name_TXT.Tag, Allow_Category_Combo.Text, Allow_Amount_TXT.Text, fix, Allow_Schedule_Combo.SelectedItem, everyThisDate, A_EffectiveDate_DTP.Value)
            End If

            SaveLogs($"{SaveStat} ALLOWANCE - {Allow_Name_TXT.Text} ({Allow_Name_TXT.Tag}), Category({Allow_Category_Combo.Text}), Amount({Allow_Amount_TXT.Text}), Sched({Allow_Schedule_Combo.Text}), Effectivity({A_EffectiveDate_DTP.Value.ToString("MMM dd, yyyy")})", frmMainForm.UserName_LBL.Text)

            Lists_Allowance(Allowance_LV)
            Allow_Cancel_BTN.PerformClick()

        End If

    End Sub

    Private Sub Allow_Cancel_BTN_Click(sender As Object, e As EventArgs) Handles Allow_Cancel_BTN.Click
        Allow_Category_Combo.Text = "Select"
        Allow_Name_TXT.Text = ""
        Allow_Amount_TXT.Text = ""
        FixYes_RadioB.Checked = False
        FixNo_RadioB.Checked = True
        Allow_Schedule_Combo.Text = "Select"
        A_EveryDate_Combo.Text = "Select"
        A_EffectiveDate_DTP.Value = Today
    End Sub

    Private Sub Allow_SearchEmp_BTN_Click(sender As Object, e As EventArgs) Handles Allow_SearchEmp_BTN.Click
        Try
            Dim instForm As Form = Application.OpenForms.OfType(Of Form)().Where(Function(frm) frm.Name = "frmNewEmployee").SingleOrDefault()
            If instForm Is Nothing Then
                Dim frm As frmNewEmployee
                frm = DirectCast(CreateObjectInstance("frmNewEmployee"), Form)
                frm.MdiParent = frmMainForm
                frmMainForm.pNavigate.Controls.Add(frm)
                frmMainForm.pNavigate.Tag = frm
                frm.txtSearch.Tag = "Allowance"
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

    Private Sub Allow_Search_BTN_Click(sender As Object, e As EventArgs) Handles Allow_Search_BTN.Click
        Lists_Allowance(Allowance_LV, Allow_Search_TXT.Text)
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

    Private Sub frmAllowance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MonitorUser(Allowance_Tab)
        PopulateComboBox(Allow_Category_Combo, "CATEGORY_ALLOWANCE", "ALLOWANCE_NAME")
        Lists_Allowance(Allowance_LV)
        DatePrepared_dtp.Value = Today
        A_EffectiveDate_DTP.Value = Today

        Status_Combo.Items.Add("APPROVE")
        Status_Combo.Items.Add("PENDING")
    End Sub

    Public Sub Load_Allowance(emp As Employee, tabName As String, Optional category As String = "")
        With emp
            If tabName = "ALLOWANCE" Then
                Allow_Name_TXT.Text = .Fullname
                Allow_Name_TXT.Tag = .BiometricID
                Allow_SearchEmp_BTN.Tag = .BRANCH_CODE
                Name_lbl.Tag = .EMP_ID
                Allowance_Tab.SelectedIndex = 0
                Allow_Category_Combo.SelectedItem = category

            ElseIf tabName = "FORM" Then
                BiometricID_TXT.Text = .BiometricID
                GetInfo_Form(.BiometricID, Name_TXT, EmpNo_txt, Address_txt, Bdate_txt, DateHire_txt, SSS_txt, TIN_txt, PIFrom_txt, PIEffectFrom_dtp, PI_SchedFrom_CB, JobTitleFrom_txt, SalaryFrom_txt, SalaryTo_txt, Gender_CB, Marital_CB)
                Allowance_Tab.SelectedIndex = 1

            End If
        End With
    End Sub

    Private Sub Allow_Search_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Allow_Search_TXT.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Allow_Search_BTN.PerformClick()
        End If
    End Sub

    Private Sub Allowance_LV_MouseClick(sender As Object, e As MouseEventArgs) Handles Allowance_LV.MouseClick
        If e.Button = MouseButtons.Right Then
            Context_Allow.Show(Allowance_LV, New Point(e.X, e.Y))
        End If
    End Sub

    Private Sub Edit_MenuItem_Click(sender As Object, e As EventArgs) Handles Edit_MenuItem.Click
        If Allowance_LV.Items.Count = 0 Then Exit Sub
        Dim idNo As Integer = Allowance_LV.Items(Allowance_LV.FocusedItem.Index).SubItems(4).Tag

        GetAllowance_Details(idNo, Allow_Name_TXT, Allow_Category_Combo, Allow_Schedule_Combo, A_EveryDate_Combo, Allow_Amount_TXT, A_EffectiveDate_DTP, FixYes_RadioB, FixNo_RadioB)
        Name_lbl.Tag = "UPDATE"
    End Sub

    Private Sub CompanyFrom_txt_TextChanged(sender As Object, e As EventArgs) Handles CompanyFrom_txt.TextChanged
        CompanyT0_txt.Text = CompanyFrom_txt.Text
    End Sub

    Private Sub JobTitleFrom_txt_TextChanged(sender As Object, e As EventArgs) Handles JobTitleFrom_txt.TextChanged
        JobTitleTo_txt.Text = JobTitleFrom_txt.Text
    End Sub

    Private Sub JobLevelFrom_txt_TextChanged(sender As Object, e As EventArgs) Handles JobLevelFrom_txt.TextChanged
        JobLevelTo_txt.Text = JobLevelFrom_txt.Text
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
                frm.txtSearch.Tag = "Allowance-Form"
                frm.Dock = DockStyle.Fill
                frm.BringToFront()
                frm.Show()
            Else
                instForm.BringToFront()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Function PAF_ValidPreview()
        If Gender_CB.Text = Nothing Then
            MsgBox("Please Indicate the Gender", MsgBoxStyle.Exclamation, "Invalid")
            Return False
        ElseIf Marital_CB.Text = Nothing Then
            MsgBox("Please Indicate the Marital Status", MsgBoxStyle.Exclamation, "Invalid")
            Return False
        ElseIf Employment_CB.Text = Nothing Then
            MsgBox("Please Indicate the Employment", MsgBoxStyle.Exclamation, "Invalid")
            Return False
        ElseIf SalaryChanges_CB.Text = Nothing Then
            MsgBox("Please Indicate the type of Salary Changes", MsgBoxStyle.Exclamation, "Invalid")
            Return False
        ElseIf PITo_txt.Text = Nothing Or PITo_txt.Text = "0" Then
            MsgBox("Please Indicate the New PI Amount", MsgBoxStyle.Exclamation, "Invalid")
            Return False
        ElseIf PIEffectTo_dtp.Value = "1/1/1990" Then
            MsgBox("Please Indicate the New PI Effectivity Date", MsgBoxStyle.Exclamation, "Invalid")
            Return False
        ElseIf PI_SchedTo_CB.Text = Nothing Then
            MsgBox("Please Indicate the New PI Schedule", MsgBoxStyle.Exclamation, "Invalid")
            Return False
        End If
        Return True
    End Function

    Private Sub F_Preview_btn_Click(sender As Object, e As EventArgs) Handles F_Preview_btn.Click
        rpt_Allowance.LocalReport.DataSources.Clear()
        If Not PAF_ValidPreview() Then Exit Sub

        Try
            Dim dt As New DataTable()
            With dt
                .Columns.Add("LASTNAME")
                .Columns.Add("FIRSTNAME")
                .Columns.Add("MIDDLE")
                .Columns.Add("DATE_PREPARED")
                .Columns.Add("EMP_NO")
                .Columns.Add("BIRTH_DATE")
                .Columns.Add("DATE_HIRE")
                .Columns.Add("EMP_ADDRESS")
                .Columns.Add("SSS_NO")
                .Columns.Add("TAX_NO")
                .Columns.Add("SEX")
                .Columns.Add("MARITAL_STATUS")
                .Columns.Add("EMPLOYMENT")
                .Columns.Add("SALARY_CHANGES")
                .Columns.Add("COMPANY_FROM")
                .Columns.Add("COMPANY_TO")
                .Columns.Add("DEP_FROM")
                .Columns.Add("DEP_TO")
                .Columns.Add("JOBTITLE_FROM")
                .Columns.Add("JOBTITLE_TO")
                .Columns.Add("JOBLEVEL_FROM")
                .Columns.Add("JOBLEVEL_TO")
                .Columns.Add("S_FROM")
                .Columns.Add("S_EFFECTIVE_FROM")
                .Columns.Add("S_TO")
                .Columns.Add("S_EFFECTIVE_TO")
                .Columns.Add("PI_FROM")
                .Columns.Add("PI_EFFECTIVE_FROM")
                .Columns.Add("PI_SCHED_FROM")
                .Columns.Add("PI_TO")
                .Columns.Add("PI_EFFECTIVE_TO")
                .Columns.Add("PI_SCHED_TO")
                .Columns.Add("REMARKS")
                .Columns.Add("PREPARED_BY")
            End With

            Dim lastt, firstt As String
            Dim middlee As String = Nothing
            lastt = lastName
            firstt = firstName
            If middlee <> Nothing Then middlee = $"{middleName.Substring(1, 1)}. {suffix}"

            Dim datePrepared = Nothing, dateHire = Nothing, S_Effect_from = Nothing, S_Effect_to = Nothing, PI_Effect_from = Nothing, PI_Effect_to As String = Nothing

            If DatePrepared_dtp.Value <> Nothing Then datePrepared = CDate(DatePrepared_dtp.Value).ToString("MMMM dd, yyyy")
            If DateHire_txt.Text <> Nothing Then dateHire = CDate(DateHire_txt.Text).ToString("MMMM dd, yyyy")
            If SalryEffectFrom_dtp.Value <> "1/1/1990" Then S_Effect_from = CDate(SalryEffectFrom_dtp.Value).ToString("dd-MMM-yyyy")
            If SalryEffectTo_dtp.Value <> "1/1/1990" Then S_Effect_to = CDate(SalryEffectTo_dtp.Value).ToString("dd-MMM-yyyy")
            If PIEffectFrom_dtp.Value <> "1/1/1990" Then PI_Effect_from = CDate(PIEffectFrom_dtp.Value).ToString("dd-MMM-yyyy")
            If PIEffectTo_dtp.Value <> "1/1/1990" Then PI_Effect_to = CDate(PIEffectTo_dtp.Value).ToString("dd-MMM-yyyy")
            If SalaryFrom_txt.Text = Nothing Then SalaryFrom_txt.Text = 0
            If SalaryTo_txt.Text = Nothing Then SalaryTo_txt.Text = 0
            If PIFrom_txt.Text = Nothing Then PIFrom_txt.Text = 0
            If PITo_txt.Text = Nothing Then PITo_txt.Text = 0

            Dim preparedBy As String = "Pearly Queen C. Benemerito"
            If EmpNo_txt.Tag = "DALTON" Then preparedBy = "Novelty S. Cababat"

            dt.Rows.Add(lastName, firstt, middlee, datePrepared, EmpNo_txt.Text, Bdate_txt.Text, dateHire,
                        Address_txt.Text, SSS_txt.Text, TIN_txt.Text, Gender_CB.Text, Marital_CB.Text,
                        Employment_CB.Text, SalaryChanges_CB.Text,
                        CompanyFrom_txt.Text, CompanyT0_txt.Text,
                        DeptFrom_txt.Text, DeptTo_txt.Text,
                        JobTitleFrom_txt.Text, JobTitleTo_txt.Text,
                        JobLevelFrom_txt.Text, JobLevelTo_txt.Text,
                        SalaryFrom_txt.Text, S_Effect_from,
                        SalaryTo_txt.Text, S_Effect_to,
                        PIFrom_txt.Text, PI_Effect_from, PI_SchedFrom_CB.Text,
                        PITo_txt.Text, PI_Effect_to, PI_SchedTo_CB.Text,
                        Remarks_txt.Text, preparedBy)

            Dim dataSource As New ReportDataSource("DataSet1", dt)
            rpt_Allowance.LocalReport.DataSources.Add(dataSource)
            rpt_Allowance.RefreshReport()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub DeptFrom_txt_TextChanged(sender As Object, e As EventArgs) Handles DeptFrom_txt.TextChanged
        DeptTo_txt.Text = DeptFrom_txt.Text
    End Sub

    Private Sub BiometricID_TXT_TextChanged(sender As Object, e As EventArgs) Handles BiometricID_TXT.TextChanged
        If BiometricID_TXT.Text <> Nothing Then
            GetInfo_Form(BiometricID_TXT.Text, Name_TXT, EmpNo_txt, Address_txt, Bdate_txt, DateHire_txt, SSS_txt, TIN_txt, PIFrom_txt, PIEffectFrom_dtp, PI_SchedFrom_CB, JobTitleFrom_txt, SalaryFrom_txt, SalaryTo_txt, Gender_CB, Marital_CB)

            If Name_TXT.Tag <> "UPDATE" Then PIFrom_txt.Text = Nothing
        End If
    End Sub

    Private Sub SalaryFrom_txt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles SalaryTo_txt.KeyPress, SalaryFrom_txt.KeyPress, PITo_txt.KeyPress, PIFrom_txt.KeyPress
        If e.KeyChar <> ChrW(Keys.Back) Then
            If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not e.KeyChar = "." Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub F_Save_btn_Click(sender As Object, e As EventArgs) Handles F_Save_btn.Click
        If Name_TXT.Text <> Nothing Then

            Dim sched As String = PI_SchedTo_CB.Text
            If sched = "every 15th of the month" Then
                sched = "OPEN PAYROLL"
            ElseIf sched = "every 30th of the month" Then
                sched = "CLOSE PAYROLL"
            Else
                sched = "EVERY PAYROLL"
            End If

            SavePAF(0, BiometricID_TXT.Text, Gender_CB.Text, Marital_CB.Text, Employment_CB.Text, SalaryChanges_CB.Text,
                           DeptFrom_txt.Text, JobLevelFrom_txt.Text,
                           SalaryFrom_txt.Text, SalryEffectFrom_dtp.Value,
                           SalaryTo_txt.Text, SalryEffectTo_dtp.Value,
                           PIFrom_txt.Text, PIEffectFrom_dtp.Value, PI_SchedFrom_CB.Text,
                           PITo_txt.Text, PIEffectTo_dtp.Value, PI_SchedTo_CB.Text,
                           Remarks_txt.Text)

            If SalaryChanges_CB.Text = "PERFORMANCE INCENTIVES" Then        'SAVE PI HISTORY ================ 
                SaveAllowance(BiometricID_TXT.Tag, BiometricID_TXT.Text, "PERFORMANCE INCENTIVES", PITo_txt.Text, "YES", sched, 0, PIEffectTo_dtp.Value, "PAF")
                SaveAllowance_HISTORY(BiometricID_TXT.Text, "PERFORMANCE INCENTIVES", PITo_txt.Text, "YES", sched, 0, PIEffectTo_dtp.Value)
            End If

            SaveLogs($"ADDED PAF- {Name_TXT.Text} ({BiometricID_TXT.Text}), Marital({Marital_CB.Text}), Employment({Employment_CB.Text}), Sales Charges({SalaryChanges_CB.Text}), 
                    Department({DeptFrom_txt.Text}), Job Level({JobLevelFrom_txt.Text}), 
                    Salary_Wage_From({SalaryFrom_txt.Text}), Salary_Wage_From_Effectivity({SalryEffectTo_dtp.Value}), 
                    Salary_Wage_To({SalaryTo_txt.Text}), Salary_Wage_From_Effectivity({SalryEffectTo_dtp.Value}),
                    PI_From({PIFrom_txt.Text}), PI_To({PITo_txt.Text}), 
                    PI_From_Effectivity({PIEffectFrom_dtp.Value}), PI_To_Effectivity({PIEffectTo_dtp.Value}), 
                    PI_From_Schedule({PI_SchedFrom_CB.Text}) PI_To_Schedule({PI_SchedTo_CB.Text}), 
                    Remarks({Remarks_txt.Text})", frmMainForm.UserName_LBL.Text)

            F_Calcel_btn.PerformClick()
        End If
    End Sub

    Private Sub Allowance_Tab_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Allowance_Tab.SelectedIndexChanged
        If Allowance_Tab.SelectedTab.Equals(Approval_Tab) Then
            ListOF_PAF(Approve_grid)

        ElseIf Allowance_Tab.SelectedTab.Equals(Record_Tab) Then
            ListOF_PAF(Records_grid)

        ElseIf Allowance_Tab.SelectedTab.Equals(TabPage1) Then
            Lists_Allowance(Allowance_LV)

        End If
    End Sub

    Private Sub Approve_grid_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles Approve_grid.EditingControlShowing
        If Approve_grid.CurrentCell.ColumnIndex = 7 Then
            Dim combo As ComboBox = CType(e.Control, ComboBox)

            If (combo IsNot Nothing) Then
                RemoveHandler combo.SelectionChangeCommitted, New EventHandler(AddressOf StatusComboBox_SelectionChangeCommitted)

                AddHandler combo.SelectionChangeCommitted, New EventHandler(AddressOf StatusComboBox_SelectionChangeCommitted)
            End If

        End If
    End Sub

    Private Sub StatusComboBox_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim combo = CType(sender, ComboBox)
        If combo.SelectedIndex >= 0 Then
            Dim result As DialogResult = MsgBox("Are you sure you want to update record?", MsgBoxStyle.YesNo)
            If result = DialogResult.Yes Then
                Dim row As DataGridViewRow = Approve_grid.Rows(Approve_grid.CurrentRow.Index)
                UpdatePAF_Status(row.Cells(0).Tag, combo.Text)
            End If
            ListOF_PAF(Approve_grid)
        End If
    End Sub

    Private Sub F_Calcel_btn_Click(sender As Object, e As EventArgs) Handles F_Calcel_btn.Click
        rpt_Allowance.Clear()
        BiometricID_TXT.Clear()
        BiometricID_TXT.Tag = "0"
        Name_TXT.Clear()
        Name_TXT.Tag = ""
        EmpNo_txt.Clear()
        Address_txt.Clear()
        Bdate_txt.Clear()
        DateHire_txt.Clear()
        SSS_txt.Clear()
        TIN_txt.Clear()
        Gender_CB.SelectedIndex = -1
        Marital_CB.SelectedIndex = -1
        Employment_CB.SelectedIndex = -1
        SalaryChanges_CB.SelectedIndex = -1
        CompanyFrom_txt.Clear()
        DeptFrom_txt.Clear()
        JobTitleFrom_txt.Clear()
        JobLevelFrom_txt.Clear()
        SalaryFrom_txt.Clear()
        SalryEffectFrom_dtp.Value = "1/1/1990"
        SalaryTo_txt.Clear()
        SalryEffectTo_dtp.Value = "1/1/1990"
        PIFrom_txt.Clear()
        PIEffectFrom_dtp.Value = "1/1/1990"
        PI_SchedFrom_CB.SelectedIndex = -1
        PITo_txt.Clear()
        PIEffectTo_dtp.Value = "1/1/1990"
        PI_SchedTo_CB.SelectedIndex = -1
    End Sub

    Private Sub R_Search_btn_Click(sender As Object, e As EventArgs) Handles R_Search_btn.Click
        ListOF_PAF(Records_grid, R_Search_txt.Text)
    End Sub

    Private Sub ApproveSearch_btn_Click(sender As Object, e As EventArgs) Handles ApproveSearch_btn.Click
        ListOF_PAF(Approve_grid, ApproveSearch_txt.Text)
    End Sub

    Private Sub ApproveSearch_txt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ApproveSearch_txt.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            ListOF_PAF(Approve_grid, ApproveSearch_txt.Text)
        End If
    End Sub

    Private Sub R_Search_txt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles R_Search_txt.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            ListOF_PAF(Records_grid, R_Search_txt.Text)
        End If
    End Sub

    Private Sub Allowance_LV_DoubleClick(sender As Object, e As EventArgs) Handles Allowance_LV.DoubleClick
        If Allowance_LV.Items.Count = 0 Then Exit Sub
        Dim idNo As Integer = Allowance_LV.Items(Allowance_LV.FocusedItem.Index).SubItems(4).Tag

        GetAllowance_Details(idNo, Allow_Name_TXT, Allow_Category_Combo, Allow_Schedule_Combo, A_EveryDate_Combo, Allow_Amount_TXT, A_EffectiveDate_DTP, FixYes_RadioB, FixNo_RadioB)
        Name_lbl.Tag = "UPDATE"
    End Sub

    Private Sub Remove_MenuItem_Click(sender As Object, e As EventArgs) Handles Remove_MenuItem.Click
        Dim idNo As Integer = Allowance_LV.Items(Allowance_LV.FocusedItem.Index).SubItems(4).Tag
        Dim namee As String = Allowance_LV.Items(Allowance_LV.FocusedItem.Index).SubItems(0).Text
        Dim bioNo As Integer = Allowance_LV.Items(Allowance_LV.FocusedItem.Index).SubItems(0).Tag
        Dim category As String = Allowance_LV.Items(Allowance_LV.FocusedItem.Index).SubItems(1).Text
        Dim sched As String = Allowance_LV.Items(Allowance_LV.FocusedItem.Index).SubItems(2).Text
        Dim effectivity As Date = Allowance_LV.Items(Allowance_LV.FocusedItem.Index).SubItems(3).Text
        Dim amount As String = Allowance_LV.Items(Allowance_LV.FocusedItem.Index).SubItems(4).Text

        Dim result As DialogResult = MsgBox("Are you sure you want to remove this allowance?", MsgBoxStyle.YesNo)
        If result = DialogResult.Yes Then
            RunCommand($"UPDATE PAYROLL_ALLOWANCES SET ALLOWED = 'NO' WHERE ID = {idNo}")
            SaveLogs($"REMOVED ALLOWANCE - {namee} ({bioNo}), Category({category}), Amount({amount}), Sched({sched}), Effectivity({effectivity.ToString("MMM dd, yyyy")})", frmMainForm.UserName_LBL.Text)
            Lists_Allowance(Allowance_LV)
            MsgBox("Successfully Removed!", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub Form_MenuItem_Click(sender As Object, e As EventArgs) Handles Form_MenuItem.Click
        If Allowance_LV.Items.Count = 0 Then Exit Sub

        Dim sched As String = Allowance_LV.Items(Allowance_LV.FocusedItem.Index).SubItems(2).Text
        If sched = "OPEN PAYROLL" Then
            PI_SchedFrom_CB.Text = "every 15th of the month"
        ElseIf sched = "CLOSE PAYROLL" Then
            PI_SchedFrom_CB.Text = "every 30th of the month"
        Else
            PI_SchedFrom_CB.Text = "every month"
        End If

        BiometricID_TXT.Text = Allowance_LV.Items(Allowance_LV.FocusedItem.Index).SubItems(2).Tag
        BiometricID_TXT.Tag = Allowance_LV.Items(Allowance_LV.FocusedItem.Index).SubItems(4).Tag     'IDNO OF ALLOWANCE
        SalaryChanges_CB.Text = "PERFORMANCE INCENTIVES"
        SalaryTo_txt.Text = SalaryFrom_txt.Text     'SalaryTo SAME AS SalaryFrom (MOSTLY HINDI NAMAN NAGBABAGO ANG MONTHLY SALARY)
        GetInfo_Form(BiometricID_TXT.Text, Name_TXT, EmpNo_txt, Address_txt, Bdate_txt, DateHire_txt, SSS_txt, TIN_txt, PIFrom_txt, PIEffectFrom_dtp, PI_SchedFrom_CB, JobTitleFrom_txt, SalaryFrom_txt, SalaryTo_txt, Gender_CB, Marital_CB)
        Allowance_Tab.SelectedIndex = 1
        Name_TXT.Tag = "UPDATE"
    End Sub
End Class