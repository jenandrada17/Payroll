Public Class frmLoan
    Dim DEDUCT_ID As String = 0
    Dim SSS_ID As String = 0
    Dim PAGIBIG_ID As String = 0
    Dim MP2_ID As String = 0
    Dim MAXICARE_ID As String = 0

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim instForm As Form = Application.OpenForms.OfType(Of Form)().Where(Function(frm) frm.Name = "frmNewEmployee").SingleOrDefault()
            If instForm Is Nothing Then
                Dim frm As frmNewEmployee
                frm = DirectCast(CreateObjectInstance("frmNewEmployee"), Form)
                frm.MdiParent = frmMainForm
                frmMainForm.pNavigate.Controls.Add(frm)
                frmMainForm.pNavigate.Tag = frm
                frm.txtSearch.Tag = "Loan-Deduction"
                'frm.btnSearch.Tag = Category_Combo.SelectedItem
                frm.Dock = DockStyle.Fill
                frm.BringToFront()
                frm.Show()
            Else
                instForm.BringToFront()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmLoan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Lists_deduction(Deduc_list)
        Load_Loans(SSSLoan_LV, "PAYROLL_LOANS", "SSS")
        Load_Loans(Pagibig_List, "PAYROLL_LOANS", "PAG-IBIG")
        Load_Other_Deduction(Mp2_List, "PAYROLL_OTHER_DEDUCTION", "MP2")
        Load_Other_Deduction(Maxicare_List, "PAYROLL_OTHER_DEDUCTION", "MAXICARE")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Cancel_btn.Click
        Name_txt.Clear()
        PrincipalDeduc_txt.Clear()
        CategoryDeduc_txt.Clear()
        DeductAmort_txt.Clear()
        Schedule_Combo.Text = Nothing
        DateCharges_DTP.Value = Today
        DEDUCT_ID = 0
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Save_btn.Click

        If Not isValidSave_DEDUC() Then Exit Sub
        '======================================== CHECK IF CONTEXT EDIT CLICK =======================================

        Dim result As DialogResult = MsgBox($"Deduction for {Name_txt.Text} will be recorded, proceed anyway?", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then

            SaveDeductionS(DEDUCT_ID, CategoryDeduc_txt.Text, PrincipalDeduc_txt.Text, DeductAmort_txt.Text, Schedule_Combo.Text, DateCharges_DTP.Value, Name_txt.Tag) 'Category_Combo.Tag (EMP_ID) | Name_TXT.Tag(Biometric) |  SearchEmp_BTN.Tag.Tag(Branch_id) |   

            SaveLogs($"{DE_Save_BTN.Tag} DEDUCTION - {Name_txt.Text} ({Name_txt.Tag}), Category({CategoryDeduc_txt.Text}), Total({PrincipalDeduc_txt.Text}), Schedule({Schedule_Combo.Text}), Date({DateCharges_DTP.Value.ToString("MMM dd, yyyy")})", frmMainForm.UserName_LBL.Text)

            Lists_deduction(Deduc_list)
            Cancel_btn.PerformClick()
        End If

    End Sub

    Private Function isValidSave_DEDUC()

        If String.IsNullOrEmpty(Name_txt.Text) Then
            MsgBox("Please select a name.", MsgBoxStyle.Critical, "Error")
            Return False

        ElseIf String.IsNullOrEmpty(CategoryDeduc_txt.Text) Then
            CategoryDeduc_txt.Region = New Region(New Rectangle(2, 2, CategoryDeduc_txt.Width - 4, CategoryDeduc_txt.Height - 4))
            Return False

        ElseIf Schedule_Combo.SelectedIndex < 0 Then
            Schedule_Combo.Region = New Region(New Rectangle(2, 2, Schedule_Combo.Width - 4, Schedule_Combo.Height - 4))
            Return False

        ElseIf String.IsNullOrEmpty(CategoryDeduc_txt.Text) Then
            PrincipalDeduc_txt.Region = New Region(New Rectangle(2, 2, PrincipalDeduc_txt.Width - 4, PrincipalDeduc_txt.Height - 4))
            Return False

        End If

        Return True
    End Function

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

    Private Sub menu_subtotal_Click(sender As Object, e As EventArgs) Handles menu_subtotal.Click

        Dim bioNo As String
        Dim total_amount, Amount_perPayroll, balance As Decimal

        If Deduc_list.SelectedItems.Count > 0 Then

            bioNo = Deduc_list.Items(Deduc_list.FocusedItem.Index).SubItems(1).Tag
            total_amount = GetTotal("PRINCIPAL", "PAYROLL_DEDUCTION", $"WHERE BIO_NO = '{bioNo}' AND STATUS IS NULL")

            If GetBranchCode(bioNo) = "" Then
                Amount_perPayroll = GetTotal("AMORT", "PAYROLL_DEDUCTION", $"WHERE BIO_NO = '{bioNo}' AND STATUS IS NULL")
            Else
                Amount_perPayroll = GetDeduction_ChargesRange(bioNo, total_amount)
            End If

            balance = GetDeduction_OverAll_Balance(bioNo)

            MsgBox("Total Amount     :  " & FormatNumber(total_amount) & vbCrLf &
                       "Amount/Payroll  :  " & FormatNumber(Amount_perPayroll) & vbCrLf &
                       "Balance               :  " & FormatNumber(balance), MsgBoxStyle.Information, "TOTAL")
        End If
    End Sub

    Private Sub Balance_MenuItem_Click(sender As Object, e As EventArgs) Handles Balance_MenuItem.Click

        Dim bioNo As String = Deduc_list.Items(Deduc_list.FocusedItem.Index).SubItems(1).Tag
        Dim IDX As Integer = Deduc_list.Items(Deduc_list.FocusedItem.Index).SubItems(4).Tag
        Dim credit As Decimal = GetData("CREDIT", $"PAYROLL_DEDUCTION WHERE ID = '{IDX}'")
        Dim CollectedCredit As Decimal = GetTotal("AMOUNT", "RECORDED_ALLOW_DEDUC", $"WHERE R_DEDUC_ID = '{IDX}'")
        Dim totalCredit As Decimal = credit + CollectedCredit
        Dim balance As Decimal

        If CollectedCredit > 0 Then
            balance = CDec(GetData("PRINCIPAL", $"PAYROLL_DEDUCTION WHERE ID = '{IDX}'")) - totalCredit
        Else
            balance = CDec(GetData("BALANCE", $"PAYROLL_DEDUCTION WHERE ID = '{IDX}'"))
        End If

        MsgBox("Balance               :  " & FormatNumber(balance), MsgBoxStyle.Information, "TOTAL")

    End Sub

    Private Sub menu_edit_Click(sender As Object, e As EventArgs) Handles menu_edit.Click

        DEDUCT_ID = Deduc_list.Items(Deduc_list.FocusedItem.Index).SubItems(4).Tag
        Name_txt.Text = Deduc_list.Items(Deduc_list.FocusedItem.Index).SubItems(0).Text
        Name_txt.Tag = Deduc_list.Items(Deduc_list.FocusedItem.Index).SubItems(1).Tag
        CategoryDeduc_txt.Text = Deduc_list.Items(Deduc_list.FocusedItem.Index).SubItems(1).Text
        PrincipalDeduc_txt.Text = Deduc_list.Items(Deduc_list.FocusedItem.Index).SubItems(2).Text
        DeductAmort_txt.Text = Deduc_list.Items(Deduc_list.FocusedItem.Index).SubItems(3).Text
        Schedule_Combo.Text = Deduc_list.Items(Deduc_list.FocusedItem.Index).SubItems(4).Text
        CategoryDeduc_txt.Tag = DEDUCT_ID

        DateCharges_DTP.Value = GetDeduction_Datee(DEDUCT_ID)

    End Sub

    Private Sub Deduc_list_MouseClick(sender As Object, e As MouseEventArgs) Handles Deduc_list.MouseClick
        If e.Button = MouseButtons.Right Then
            If Deduc_list.Items.Count > 0 Then
                Context_Deduct.Show(Deduc_list, New Point(e.X, e.Y))
            End If
        End If
    End Sub

    Private Sub Search_btn_Click(sender As Object, e As EventArgs) Handles Search_btn.Click
        Lists_deduction(Deduc_list, Search_txt.Text)
    End Sub

    Public Sub Load_Contrib_Loan(emp As Employee, tabName As String)
        With emp
            If tabName = "DEDUCTION" Then

                Name_txt.Text = .Fullname
                Name_txt.Tag = .BiometricID

            ElseIf tabName = "SSS" Then

                Loans_Tab.SelectedIndex = 1
                SSS_Name_TXT.Text = .Fullname
                SSS_Name_TXT.Tag = .BiometricID

            ElseIf tabName = "PAGIBIG" Then
                Loans_Tab.SelectedIndex = 2
                PagEmp_TXT.Text = .Fullname
                PagEmp_TXT.Tag = .BiometricID

            ElseIf tabName = "MP2" Then
                Loans_Tab.SelectedIndex = 3
                Mp2Emp_txt.Text = .Fullname
                Mp2Emp_txt.Tag = .BiometricID

            ElseIf tabName = "MAXICARE" Then
                Loans_Tab.SelectedIndex = 4
                MaxEmp_txt.Text = .Fullname
                MaxEmp_txt.Tag = .BiometricID

            End If
        End With
    End Sub

    Private Sub Total_txt_KeyPress_1(sender As Object, e As KeyPressEventArgs) Handles PrincipalDeduc_txt.KeyPress, DeductAmort_txt.KeyPress

        If e.KeyChar <> ChrW(Keys.Back) Then

            If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso Not e.KeyChar = "." Then
                e.Handled = True
            End If
        End If

    End Sub


    Private Sub Search_txt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Search_txt.KeyPress
        If IsEnter(e) Then Search_btn.PerformClick()
    End Sub

    Private Sub SSS_SearchEmp_BTN_Click(sender As Object, e As EventArgs) Handles SSS_SearchEmp_BTN.Click

        Try
            Dim instForm As Form = Application.OpenForms.OfType(Of Form)().Where(Function(frm) frm.Name = "frmNewEmployee").SingleOrDefault()
            If instForm Is Nothing Then
                Dim frm As frmNewEmployee
                frm = DirectCast(CreateObjectInstance("frmNewEmployee"), Form)
                frm.MdiParent = frmMainForm
                frmMainForm.pNavigate.Controls.Add(frm)
                frmMainForm.pNavigate.Tag = frm
                frm.txtSearch.Tag = "SSS Loan"
                frm.Dock = DockStyle.Fill
                frm.BringToFront()
                frm.Show()
            Else
                instForm.BringToFront()
            End If

        Catch ex As Exception

        End Try
    End Sub



    Private Sub Emp_BTN_Click(sender As Object, e As EventArgs) Handles PagEmp_BTN.Click

        Try
            Dim instForm As Form = Application.OpenForms.OfType(Of Form)().Where(Function(frm) frm.Name = "frmNewEmployee").SingleOrDefault()
            If instForm Is Nothing Then
                Dim frm As frmNewEmployee
                frm = DirectCast(CreateObjectInstance("frmNewEmployee"), Form)
                frm.MdiParent = frmMainForm
                frmMainForm.pNavigate.Controls.Add(frm)
                frmMainForm.pNavigate.Tag = frm
                frm.txtSearch.Tag = "Pagibig Loan"
                frm.Dock = DockStyle.Fill
                frm.BringToFront()
                frm.Show()
            Else
                instForm.BringToFront()
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Pag_Save_BTN_Click(sender As Object, e As EventArgs) Handles Pag_Save_BTN.Click

        Dim result As DialogResult = MsgBox($"Pagibig Loan for {PagEmp_TXT.Text} will be recorded, proceed anyway?", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then

            Save_Loans(PAGIBIG_ID, PagEmp_TXT.Tag, "PAG-IBIG", PagPrincipal_TXT.Text, PagAmort_TXT.Text, PagDate_DTP.Value)
            Load_Loans(Pagibig_List, "PAYROLL_LOANS", "PAG-IBIG")

            SaveLogs($"ADDED PAGIBIG LOAN {PagEmp_TXT.Text} ({PagEmp_TXT.Tag}), Amount({PagAmort_TXT.Text}), Date({PagDate_DTP.Value.ToString("MMM dd, yyyy")})", frmMainForm.UserName_LBL.Text)
            Pag_Cancel_BTN.PerformClick()
        End If

    End Sub

    Private Sub Pag_Cancel_BTN_Click(sender As Object, e As EventArgs) Handles Pag_Cancel_BTN.Click
        PagEmp_TXT.Clear()
        PagAmort_TXT.Clear()
        PagPrincipal_TXT.Clear()
        PagDate_DTP.Value = Today
        PAGIBIG_ID = 0
    End Sub

    Private Sub Close_LBL_Click(sender As Object, e As EventArgs) Handles Close_LBL.Click
        Close()
    End Sub

    Private Sub SSS_Amount_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles SSSPrincipal_TXT.KeyPress, SSS_Amort_TXT.KeyPress, PagAmort_TXT.KeyPress, PagPrincipal_TXT.KeyPress, Mp2Amort_txt.KeyPress, MaxAmort_txt.KeyPress
        If Not e.KeyChar = ChrW(Keys.Back) Then
            If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not e.KeyChar = "." Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub Mp2Emp_btn_Click(sender As Object, e As EventArgs) Handles Mp2Emp_btn.Click
        Try
            Dim instForm As Form = Application.OpenForms.OfType(Of Form)().Where(Function(frm) frm.Name = "frmNewEmployee").SingleOrDefault()
            If instForm Is Nothing Then
                Dim frm As frmNewEmployee
                frm = DirectCast(CreateObjectInstance("frmNewEmployee"), Form)
                frm.MdiParent = frmMainForm
                frmMainForm.pNavigate.Controls.Add(frm)
                frmMainForm.pNavigate.Tag = frm
                frm.txtSearch.Tag = "Loan-Mp2"
                frm.Dock = DockStyle.Fill
                frm.BringToFront()
                frm.Show()
            Else
                instForm.BringToFront()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub MaxEmp_btn_Click(sender As Object, e As EventArgs) Handles MaxEmp_btn.Click
        Try
            Dim instForm As Form = Application.OpenForms.OfType(Of Form)().Where(Function(frm) frm.Name = "frmNewEmployee").SingleOrDefault()
            If instForm Is Nothing Then
                Dim frm As frmNewEmployee
                frm = DirectCast(CreateObjectInstance("frmNewEmployee"), Form)
                frm.MdiParent = frmMainForm
                frmMainForm.pNavigate.Controls.Add(frm)
                frmMainForm.pNavigate.Tag = frm
                frm.txtSearch.Tag = "Loan-Maxicare"
                frm.Dock = DockStyle.Fill
                frm.BringToFront()
                frm.Show()
            Else
                instForm.BringToFront()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub SSS_Save_BTN_Click(sender As Object, e As EventArgs) Handles SSS_Save_BTN.Click

        Dim result As DialogResult = MsgBox($"SSS Loan for {SSS_Name_TXT.Text} will be recorded, proceed anyway?", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then

            Save_Loans(SSS_ID, SSS_Name_TXT.Tag, "SSS", SSSPrincipal_TXT.Text, SSS_Amort_TXT.Text, SSS_Date_DTP.Value)
            Load_Loans(SSSLoan_LV, "PAYROLL_LOANS", "SSS")

            SaveLogs($"ADDED SSS LOAN {SSS_Name_TXT.Text} ({SSS_Name_TXT.Tag}), Amort({SSS_Amort_TXT.Text}), Principal({SSSPrincipal_TXT.Text}), Date({SSS_Date_DTP.Value.ToString("MMM dd, yyyy")})", frmMainForm.UserName_LBL.Text)
            SSSCancel_BTN.PerformClick()
        End If

    End Sub

    Private Sub SSSCancel_BTN_Click(sender As Object, e As EventArgs) Handles SSSCancel_BTN.Click
        SSS_Name_TXT.Clear()
        SSS_Amort_TXT.Clear()
        SSSPrincipal_TXT.Clear()
        SSS_Date_DTP.Value = Today
        SSS_ID = 0
    End Sub

    Private Sub PagSearch_BTN_Click(sender As Object, e As EventArgs) Handles PagSearch_BTN.Click
        Load_Loans(Pagibig_List, "PAYROLL_LOANS", "PAG-IBIG", PagSearch_TXT.Text)
    End Sub

    Private Sub SSS_Search_BTN_Click(sender As Object, e As EventArgs) Handles SSS_Search_BTN.Click
        Load_Loans(SSSLoan_LV, "PAYROLL_LOANS", "SSS", SSS_Search_TXT.Text)
    End Sub

    Private Sub SSS_Search_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles SSS_Search_TXT.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SSS_Search_BTN.PerformClick()
        End If
    End Sub

    Private Sub PagSearch_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles PagSearch_TXT.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            PagSearch_BTN.PerformClick()
        End If
    End Sub

    Private Sub SSSEdit_Menu_Click(sender As Object, e As EventArgs) Handles SSSEdit_Menu.Click

        SSS_ID = SSSLoan_LV.Items(SSSLoan_LV.FocusedItem.Index).SubItems(2).Tag
        SSS_Name_TXT.Text = SSSLoan_LV.Items(SSSLoan_LV.FocusedItem.Index).SubItems(0).Text
        SSS_Name_TXT.Tag = SSSLoan_LV.Items(SSSLoan_LV.FocusedItem.Index).SubItems(3).Tag
        SSSPrincipal_TXT.Text = SSSLoan_LV.Items(SSSLoan_LV.FocusedItem.Index).SubItems(1).Text
        SSS_Amort_TXT.Text = SSSLoan_LV.Items(SSSLoan_LV.FocusedItem.Index).SubItems(2).Text
        SSS_Date_DTP.Value = SSSLoan_LV.Items(SSSLoan_LV.FocusedItem.Index).SubItems(3).Text

    End Sub

    Private Sub PagEdit_Menu_Click(sender As Object, e As EventArgs) Handles PagEdit_Menu.Click

        PAGIBIG_ID = Pagibig_List.Items(Pagibig_List.FocusedItem.Index).SubItems(2).Tag
        PagEmp_TXT.Text = Pagibig_List.Items(Pagibig_List.FocusedItem.Index).SubItems(0).Text
        PagEmp_TXT.Tag = Pagibig_List.Items(Pagibig_List.FocusedItem.Index).SubItems(3).Tag
        PagPrincipal_TXT.Text = Pagibig_List.Items(Pagibig_List.FocusedItem.Index).SubItems(1).Text
        PagAmort_TXT.Text = Pagibig_List.Items(Pagibig_List.FocusedItem.Index).SubItems(2).Text
        PagDate_DTP.Value = Pagibig_List.Items(Pagibig_List.FocusedItem.Index).SubItems(3).Text

    End Sub

    Private Sub SSSLoan_LV_MouseClick(sender As Object, e As MouseEventArgs) Handles SSSLoan_LV.MouseClick
        If e.Button = MouseButtons.Right Then
            If SSSLoan_LV.Items.Count >= 0 Then
                Context_SSS.Show(SSSLoan_LV, New Point(e.X, e.Y))
            End If
        End If
    End Sub

    Private Sub Pagibig_List_MouseClick(sender As Object, e As MouseEventArgs) Handles Pagibig_List.MouseClick
        If e.Button = MouseButtons.Right Then
            If Pagibig_List.Items.Count > 0 Then
                Context_Pagibg.Show(Pagibig_List, New Point(e.X, e.Y))
            End If
        End If
    End Sub

    Private Sub SSSBalance_Menu_Click(sender As Object, e As EventArgs) Handles SSSBalance_Menu.Click

        Dim bioNo As String = SSSLoan_LV.Items(SSSLoan_LV.FocusedItem.Index).SubItems(3).Tag
        Dim IDX As Integer = SSSLoan_LV.Items(SSSLoan_LV.FocusedItem.Index).SubItems(2).Tag
        Dim credit As Decimal = GetData("CREDIT", $"PAYROLL_LOANS WHERE ID = '{IDX}'")
        Dim CollectedCredit As Decimal = GetTotal("AMOUNT", "RECORDED_ALLOW_DEDUC", $"WHERE BIO_NO = '{bioNo}' and UPPER(CATEGORY) LIKE '%SSS%'")
        Dim totalCredit As Decimal = credit + CollectedCredit
        Dim balance As Decimal

        If CollectedCredit > 0 Then
            balance = CDec(GetData("PRINCIPAL", $"PAYROLL_LOANS WHERE ID = '{IDX}'")) - totalCredit
        Else
            balance = CDec(GetData("BALANCE", $"PAYROLL_LOANS WHERE ID = '{IDX}'"))
        End If

        MsgBox("Balance               :  " & FormatNumber(balance), MsgBoxStyle.Information, "TOTAL")

    End Sub

    Private Sub PagBalance_Menu_Click(sender As Object, e As EventArgs) Handles PagBalance_Menu.Click

        Dim bioNo As String = Pagibig_List.Items(Pagibig_List.FocusedItem.Index).SubItems(3).Tag
        Dim IDX As Integer = Pagibig_List.Items(Pagibig_List.FocusedItem.Index).SubItems(2).Tag
        Dim credit As Decimal = GetData("CREDIT", $"PAYROLL_LOANS WHERE ID = '{IDX}'")
        Dim CollectedCredit As Decimal = GetTotal("AMOUNT", "RECORDED_ALLOW_DEDUC", $"WHERE BIO_NO = '{bioNo}' and CATEGORY = 'PAG IBIG LOAN'")
        Dim totalCredit As Decimal = credit + CollectedCredit
        Dim balance As Decimal

        If CollectedCredit > 0 Then
            balance = CDec(GetData("PRINCIPAL", $"PAYROLL_LOANS WHERE ID = '{IDX}'")) - totalCredit
        Else
            balance = CDec(GetData("BALANCE", $"PAYROLL_LOANS WHERE ID = '{IDX}'"))
        End If

        MsgBox("Balance               :  " & FormatNumber(balance), MsgBoxStyle.Information, "TOTAL")

    End Sub

    Private Sub SSSSubtotal_Menu_Click(sender As Object, e As EventArgs) Handles SSSSubtotal_Menu.Click

        Dim bioNo As String
        Dim total_amount, Amount_perPayroll, balance As Decimal

        If SSSLoan_LV.SelectedItems.Count > 0 Then

            bioNo = SSSLoan_LV.Items(SSSLoan_LV.FocusedItem.Index).SubItems(3).Tag
            total_amount = GetTotal("PRINCIPAL", "PAYROLL_LOANS", $"WHERE BIO_NO = '{bioNo}' AND CATEGORY = 'SSS' AND STATUS IS NULL")

            Amount_perPayroll = GetTotal("AMORT", "PAYROLL_LOANS", $"WHERE BIO_NO = '{bioNo}' AND CATEGORY = 'SSS'AND STATUS IS NULL")

            balance = GetTotal("BALANCE", "PAYROLL_LOANS", $"WHERE BIO_NO = '{bioNo}' AND CATEGORY = 'SSS' AND STATUS IS NULL")

            MsgBox("Total Amount     :  " & FormatNumber(total_amount) & vbCrLf &
                       "Amount/Payroll  :  " & FormatNumber(Amount_perPayroll) & vbCrLf &
                       "Balance               :  " & FormatNumber(balance), MsgBoxStyle.Information, "TOTAL")
        End If
    End Sub

    Private Sub PagSubTotal_Menu_Click(sender As Object, e As EventArgs) Handles PagSubTotal_Menu.Click

        Dim bioNo As String
        Dim total_amount, Amount_perPayroll, balance As Decimal

        If Pagibig_List.SelectedItems.Count > 0 Then

            bioNo = Pagibig_List.Items(Pagibig_List.FocusedItem.Index).SubItems(3).Tag
            total_amount = GetTotal("PRINCIPAL", "PAYROLL_LOANS", $"WHERE BIO_NO = '{bioNo}' AND CATEGORY = 'PAG-IBIG' AND STATUS IS NULL")

            Amount_perPayroll = GetTotal("AMORT", "PAYROLL_LOANS", $"WHERE BIO_NO = '{bioNo}' AND CATEGORY = 'PAG-IBIG' AND STATUS IS NULL")

            balance = GetTotal("BALANCE", "PAYROLL_LOANS", $"WHERE BIO_NO = '{bioNo}' AND CATEGORY = 'PAG-IBIG' AND STATUS IS NULL")

            MsgBox("Total Amount     :  " & FormatNumber(total_amount) & vbCrLf &
                       "Amount/Payroll  :  " & FormatNumber(Amount_perPayroll) & vbCrLf &
                       "Balance               :  " & FormatNumber(balance), MsgBoxStyle.Information, "TOTAL")
        End If
    End Sub

    Private Sub Mp2Save_btn_Click(sender As Object, e As EventArgs) Handles Mp2Save_btn.Click

        Dim result As DialogResult = MsgBox($"MP2 for {Mp2Emp_txt.Text} will be recorded, proceed anyway?", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then

            Dim STATUS As String = Nothing
            If Mp2Status_Combo.SelectedIndex = 1 Then
                STATUS = "OFF"
            End If

            Save_OtherDeduction(MP2_ID, Mp2Emp_txt.Tag, "MP2", Mp2Sched_Combo.Text, Mp2Amort_txt.Text, Mp2Date_dtp.Value, STATUS)
            Load_Other_Deduction(Mp2_List, "PAYROLL_OTHER_DEDUCTION", "MP2")

            SaveLogs($"ADDED MP2 {Mp2Emp_txt.Text} ({Mp2Emp_txt.Tag}), Amort({Mp2Amort_txt.Text}), Date({Mp2Date_dtp.Value.ToString("MMM dd, yyyy")})", frmMainForm.UserName_LBL.Text)
            Mp2Cancel_btn.PerformClick()
        End If

    End Sub

    Private Sub Mp2Cancel_btn_Click(sender As Object, e As EventArgs) Handles Mp2Cancel_btn.Click
        Mp2Emp_txt.Clear()
        Mp2Amort_txt.Clear()
        Mp2Sched_Combo.Text = Nothing
        Mp2Date_dtp.Value = Today
        Mp2Status_Combo.Text = Nothing
        MP2_ID = 0
    End Sub

    Private Sub MaxSave_btn_Click(sender As Object, e As EventArgs) Handles MaxSave_btn.Click

        Dim result As DialogResult = MsgBox($"Maxicare for {MaxEmp_txt.Text} will be recorded, proceed anyway?", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then

            Dim STATUS As String = Nothing
            If MaxStatus_Combo.SelectedIndex = 1 Then
                STATUS = "OFF"
            End If

            Save_OtherDeduction(MAXICARE_ID, MaxEmp_txt.Tag, "MAXICARE", MaxSched_Combo.Text, MaxAmort_txt.Text, MaxDate_dtp.Value, STATUS)
            Load_Other_Deduction(Maxicare_List, "PAYROLL_OTHER_DEDUCTION", "MAXICARE")

            SaveLogs($"ADDED MAXICARE {MaxEmp_txt.Text} ({MaxEmp_txt.Tag}), Amourt({MaxAmort_txt.Text}), Date({MaxDate_dtp.Value.ToString("MMM dd, yyyy")})", frmMainForm.UserName_LBL.Text)
            MaxCancel_btn.PerformClick()
        End If

    End Sub

    Private Sub MaxCancel_btn_Click(sender As Object, e As EventArgs) Handles MaxCancel_btn.Click
        MaxEmp_txt.Clear()
        MaxAmort_txt.Clear()
        MaxSched_Combo.Text = Nothing
        MaxDate_dtp.Value = Today
        MaxStatus_Combo.Text = Nothing
        MAXICARE_ID = 0
    End Sub

    Private Sub MaxEdit_Menu_Click(sender As Object, e As EventArgs) Handles MaxEdit_Menu.Click

        MAXICARE_ID = Maxicare_List.Items(Maxicare_List.FocusedItem.Index).SubItems(2).Tag
        MaxEmp_txt.Text = Maxicare_List.Items(Maxicare_List.FocusedItem.Index).SubItems(0).Text
        MaxEmp_txt.Tag = Maxicare_List.Items(Maxicare_List.FocusedItem.Index).SubItems(3).Tag
        MaxSched_Combo.Text = Maxicare_List.Items(Maxicare_List.FocusedItem.Index).SubItems(3).Text
        MaxAmort_txt.Text = Maxicare_List.Items(Maxicare_List.FocusedItem.Index).SubItems(1).Text
        MaxDate_dtp.Value = Maxicare_List.Items(Maxicare_List.FocusedItem.Index).SubItems(2).Text
        MaxStatus_Combo.Text = IIf(GetData("STATUS", $"PAYROLL_OTHER_DEDUCTION WHERE ID = '{MAXICARE_ID}'") = Nothing, "ON", "OFF")

    End Sub

    Private Sub Mp2Edit_Menu_Click(sender As Object, e As EventArgs) Handles Mp2Edit_Menu.Click

        MP2_ID = Mp2_List.Items(Mp2_List.FocusedItem.Index).SubItems(2).Tag
        Mp2Emp_txt.Text = Mp2_List.Items(Mp2_List.FocusedItem.Index).SubItems(0).Text
        Mp2Emp_txt.Tag = Mp2_List.Items(Mp2_List.FocusedItem.Index).SubItems(3).Tag
        Mp2Sched_Combo.Text = Mp2_List.Items(Mp2_List.FocusedItem.Index).SubItems(3).Text
        Mp2Amort_txt.Text = Mp2_List.Items(Mp2_List.FocusedItem.Index).SubItems(1).Text
        Mp2Date_dtp.Value = Mp2_List.Items(Mp2_List.FocusedItem.Index).SubItems(2).Text
        Mp2Status_Combo.Text = IIf(GetData("STATUS", $"PAYROLL_OTHER_DEDUCTION WHERE ID = '{MP2_ID}'") = Nothing, "ON", "OFF")

    End Sub

    Private Sub Maxicare_List_MouseClick(sender As Object, e As MouseEventArgs) Handles Maxicare_List.MouseClick
        If e.Button = MouseButtons.Right Then
            If Maxicare_List.SelectedItems.Count > 0 Then
                Context_Maxicare.Show(Maxicare_List, New Point(e.X, e.Y))
            End If
        End If
    End Sub

    Private Sub Mp2_List_MouseClick(sender As Object, e As MouseEventArgs) Handles Mp2_List.MouseClick
        If e.Button = MouseButtons.Right Then
            If Mp2_List.SelectedItems.Count > 0 Then
                Context_Mp2.Show(Mp2_List, New Point(e.X, e.Y))
            End If
        End If
    End Sub

    Private Sub Mp2Search_btn_Click(sender As Object, e As EventArgs) Handles Mp2Search_btn.Click
        Load_Other_Deduction(Mp2_List, "PAYROLL_OTHER_DEDUCTION", "MP2", Mp2Search_txt.Text)
    End Sub

    Private Sub MaxSearch_btn_Click(sender As Object, e As EventArgs) Handles MaxSearch_btn.Click
        Load_Other_Deduction(Maxicare_List, "PAYROLL_OTHER_DEDUCTION", "MAXICARE", MaxSearch_txt.Text)
    End Sub

    Private Sub MaxSearch_txt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MaxSearch_txt.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then MaxSearch_btn.PerformClick()
    End Sub

    Private Sub Mp2Search_txt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Mp2Search_txt.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Mp2Search_btn.PerformClick()
    End Sub

End Class