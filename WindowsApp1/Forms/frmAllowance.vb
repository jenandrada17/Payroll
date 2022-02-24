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

        'If ThisHasRow($"PAYROLL_ALLOWANCES where BIOMETRIC_NO = '{Allow_Name_TXT.Tag}'") Then
        '    MsgBox($"{Allow_Name_TXT.Text} has record already, right click to edit.", MsgBoxStyle.Critical)
        'End If

        Dim fix As String = "NO"
        Dim everyThisDate As Integer = 0
        Dim idNo As Integer = 0

        If Not isValidSave_ALLOW() Then Exit Sub

        If Not A_EveryDate_Combo.Text = "Select date of the month" Then everyThisDate = A_EveryDate_Combo.SelectedItem

        If FixYes_RadioB.Checked Then fix = "YES"

        Dim result As DialogResult = MsgBox($"Allowance for {Allow_Name_TXT.Text} will be Recorded, proceed anyway?", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then

            If Allowance_LV.SelectedItems.Count > 0 Then
                idNo = Allowance_LV.Items(Allowance_LV.FocusedItem.Index).SubItems(4).Tag
            End If

            SaveAllowance(idNo, Allow_Name_TXT.Tag, Allow_Category_Combo.Text, Allow_Amount_TXT.Text, fix, Allow_Schedule_Combo.SelectedItem, everyThisDate, A_EffectiveDate_DTP.Value) ' Label14 is EMP_ID

            SaveLogs($"ADDED ALLOWANCE - {Allow_Name_TXT.Text} ({Allow_Name_TXT.Tag}), Category({Allow_Category_Combo.Text}), Amount({Allow_Amount_TXT.Text}), Sched({Allow_Schedule_Combo.Text}), Effectivity({A_EffectiveDate_DTP.Value.ToString("MMM dd, yyyy")})", frmMainForm.UserName_LBL.Text)

            Lists_Allowance(Allowance_LV)
            Allow_Cancel_BTN.PerformClick()

        End If

    End Sub

    Private Sub Allow_Cancel_BTN_Click(sender As Object, e As EventArgs) Handles Allow_Cancel_BTN.Click
        Allow_Category_Combo.Text = "Select"
        Allow_Name_TXT.Text = ""
        Allow_Amount_TXT.Text = ""
        FixNo_RadioB.Checked = False
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
        PopulateComboBox(Allow_Category_Combo, "CATEGORY_ALLOWANCE", "ALLOWANCE_NAME")
        Lists_Allowance(Allowance_LV)
        Me.rpt_Allowance.RefreshReport()
    End Sub

    Private Sub Allowance_LV_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Allowance_LV.MouseDoubleClick
        If Allowance_LV.Items.Count = 0 Then Exit Sub
        Dim idNo As Integer = Allowance_LV.Items(Allowance_LV.FocusedItem.Index).SubItems(4).Tag

        GetAllowance_Details(idNo, Allow_Name_TXT, Allow_Category_Combo, Allow_Schedule_Combo, A_EveryDate_Combo, Allow_Amount_TXT, A_EffectiveDate_DTP, FixYes_RadioB, FixNo_RadioB)
    End Sub


    Public Sub Load_Allowance(emp As Employee, tabName As String, Optional category As String = "")
        With emp
            If tabName = "ALLOWANCE" Then
                Allow_Name_TXT.Text = .Fullname
                Allow_Name_TXT.Tag = .BiometricID
                Allow_SearchEmp_BTN.Tag = .BRANCH_CODE
                Label14.Tag = .EMP_ID
                Allowance_Tab.SelectedIndex = 0
                Allow_Category_Combo.SelectedItem = category

            ElseIf tabName = "FORM" Then
                Name_TXT.Text = .Fullname
                BiometricID_TXT.Text = .BiometricID
                EmpNo_txt.Text = .EMP_NO
                Address_txt.Text = .ADDRESS
                Bdate_txt.Text = .BDATE
                DateHire_txt.Text = .DATE_STARTED
                SSS_txt.Text = .SSSNO
                TIN_txt.Text = .TINNO
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

    Private Sub F_Preview_btn_Click(sender As Object, e As EventArgs) Handles F_Preview_btn.Click

        rpt_Allowance.LocalReport.DataSources.Clear()

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
            End With


            '======================== FIRSTNAME, LASTNAME, MIDDLENAME ========================== 
            Dim firstt, middlee As String
            Dim fullname As String = Name_TXT.Text
            Dim name As String() = fullname.Split(",")
            Dim sobra As String = name(1).TrimStart

            If sobra.EndsWith(".") Then
                Dim index As Integer = sobra.Length - 2
                middlee = sobra.Substring(index, 2)
                firstt = sobra.Replace(middlee, "").TrimEnd
            Else
                firstt = sobra
                middlee = Nothing
            End If

            Dim datePrepared = Nothing, dateHire As String = Nothing

            If DatePrepared_dtp.Value <> Nothing Then datePrepared = CDate(DatePrepared_dtp.Value).ToString("MMMM dd, yyyy")
            If DateHire_txt.Text <> Nothing Then dateHire = CDate(DateHire_txt.Text).ToString("MMMM dd, yyyy")

            dt.Rows.Add(name(0), firstt, middlee, datePrepared, EmpNo_txt.Text, Bdate_txt.Text, dateHire,
                        Address_txt.Text, SSS_txt.Text, TIN_txt.Text, Gender_CB.Text, Marital_CB.Text,
                        Employment_CB.Text, SalesCharges_CB.Text,
                        CompanyFrom_txt.Text, CompanyT0_txt.Text,
                        DeptFrom_txt.Text, DeptTo_txt.Text,
                        JobTitleFrom_txt.Text, JobTitleTo_txt.Text,
                        JobLevelFrom_txt.Text, JobLevelTo_txt.Text,
                        SalaryFrom_txt.Text, SalryEffectFrom_dtp.Value,
                        SalaryTo_txt.Text, SalryEffectTo_dtp.Value,
                        PIFrom_txt.Text, PIEffectFrom_dtp.Value, PI_SchedFrom_CB.Text,
                        PITo_txt.Text, PIEffectTo_dtp.Value, PI_SchedTo_CB.Text,
                        Remarks_txt.Text)

            Dim dataSource As New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt)
            rpt_Allowance.LocalReport.DataSources.Add(dataSource)
            rpt_Allowance.RefreshReport()

        Catch ex As Exception

        End Try
    End Sub
End Class