
Public Class frmLoan
    Dim DEDUCT_ID As String = 0
    Dim SSS_ID As String = 0
    Dim PAGIBIG_ID As String = 0
    Dim MP2_ID As String = 0
    Dim MAXICARE_ID As String = 0
    Dim Editing_DEDUCT As Boolean = False
    Dim Editing_SSS As Boolean = False
    Dim Editing_PAGIBIG As Boolean = False
    'Dim Editing_SBU As Boolean = False
    Dim OrigAmount_DEDUCT As Decimal = 0
    Dim OrigAmount_SSS As Decimal = 0
    Dim OrigAmount_PAGIBIG As Decimal = 0

    Dim allowMove As Boolean = False
    Dim moveLocation As New Point

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
        Load_Loans(SSSLoan_LV, "PAYROLL_DEDUCTION", "SSS LOAN")
        Load_Loans(Pagibig_List, "PAYROLL_DEDUCTION", "PAG-IBIG LOAN")
        Load_Other_Deduction(Mp2_List, "PAYROLL_OTHER_DEDUCTION", "MP2")
        Load_Other_Deduction(Maxicare_List, "PAYROLL_OTHER_DEDUCTION", "MAXICARE")
        Lists_SBU(SBU_LV)
        PopulateINACTIVE_Employees(gridSOA)

        DateCharges_DTP.Value = Today
        SSS_Date_DTP.Value = Today
        PagDate_DTP.Value = Today
        Mp2Date_dtp.Value = Today
        MaxDate_dtp.Value = Today
        SBU_Date_dtp.Value = Today
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

            If Editing_DEDUCT = True Then
                SaveLogs($"DEDUCTION ALTERED (From {OrigAmount_DEDUCT} to {PrincipalDeduc_txt.Text})- {Name_txt.Text} ({Name_txt.Tag}), Category({CategoryDeduc_txt.Text}), Total({PrincipalDeduc_txt.Text}), Amort(from {DeductAmort_txt.Tag} to {DeductAmort_txt.Text}), Schedule({Schedule_Combo.Text}), Date({DateCharges_DTP.Value.ToString("MMM dd, yyyy")})", frmMainForm.UserName_LBL.Text)
                Editing_DEDUCT = False
            Else
                SaveLogs($"DEDUCTION ADDED - {Name_txt.Text} ({Name_txt.Tag}), Category({CategoryDeduc_txt.Text}), Total({PrincipalDeduc_txt.Text}), Schedule({Schedule_Combo.Text}), Date({DateCharges_DTP.Value.ToString("MMM dd, yyyy")})", frmMainForm.UserName_LBL.Text)
            End If

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
            total_amount = GetTotal("PRINCIPAL", $"PAYROLL_DEDUCTION WHERE BIO_NO = '{bioNo}'  AND STATUS IS NULL AND CATEGORY NOT IN ('PAG-IBIG LOAN', 'SSS LOAN')")

            If GetBranchCode(bioNo) = "" Then
                Amount_perPayroll = GetTotal("AMORT", $"PAYROLL_DEDUCTION WHERE BIO_NO = '{bioNo}' AND STATUS IS NULL AND CATEGORY NOT IN ('PAG-IBIG LOAN', 'SSS LOAN')")
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
        Dim IDX As Integer = Deduc_list.Items(Deduc_list.FocusedItem.Index).SubItems(4).Tag
        MsgBox("Balance               :  " & FormatNumber(GetDeduction_Balance(IDX)), MsgBoxStyle.Information, "TOTAL")
    End Sub

    Private Sub menu_edit_Click(sender As Object, e As EventArgs) Handles menu_edit.Click
        DEDUCT_ID = Deduc_list.Items(Deduc_list.FocusedItem.Index).SubItems(4).Tag
        Name_txt.Text = Deduc_list.Items(Deduc_list.FocusedItem.Index).SubItems(0).Text
        Name_txt.Tag = Deduc_list.Items(Deduc_list.FocusedItem.Index).SubItems(1).Tag
        CategoryDeduc_txt.Text = Deduc_list.Items(Deduc_list.FocusedItem.Index).SubItems(1).Text
        PrincipalDeduc_txt.Text = Deduc_list.Items(Deduc_list.FocusedItem.Index).SubItems(2).Text
        DeductAmort_txt.Text = Deduc_list.Items(Deduc_list.FocusedItem.Index).SubItems(3).Text
        DeductAmort_txt.Tag = Deduc_list.Items(Deduc_list.FocusedItem.Index).SubItems(3).Text
        Schedule_Combo.Text = Deduc_list.Items(Deduc_list.FocusedItem.Index).SubItems(4).Text
        CategoryDeduc_txt.Tag = DEDUCT_ID

        DateCharges_DTP.Value = GetDeduction_Datee(DEDUCT_ID)
        Editing_DEDUCT = True
        OrigAmount_DEDUCT = PrincipalDeduc_txt.Text
    End Sub

    Dim panelLocation As New Point

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

            ElseIf tabName = "SBU" Then
                Loans_Tab.SelectedIndex = 5
                SBU_Name_txt.Text = .Fullname
                SBU_Name_txt.Tag = .BiometricID

                'ElseIf tabName = "SOA" Then
                '    Loans_Tab.SelectedIndex = 6
                '    txtNameSOA.Tag = .BiometricID
                '    txtDesignation.Text = .Position
                '    txtDesignation.Tag = .DAILY_RATE
                '    txtCompany.Text = .Company
                '    txtNameSOA.Text = .Fullname

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

            SaveDeductionS(PAGIBIG_ID, "PAG-IBIG LOAN", PagPrincipal_TXT.Text, PagAmort_TXT.Text, "CLOSE PAYROLL", PagDate_DTP.Value, PagEmp_TXT.Tag)
            Load_Loans(Pagibig_List, "PAYROLL_DEDUCTION", "PAG-IBIG LOAN")

            If Editing_PAGIBIG = True Then
                SaveLogs($"ALTERED DEDUCTION - PAGIBIG LOAN (From {OrigAmount_PAGIBIG} to {PagPrincipal_TXT.Text}) - {PagEmp_TXT.Text} ({PagEmp_TXT.Tag}), Amount({PagAmort_TXT.Text}), Principal({PagPrincipal_TXT.Text}), Date({PagDate_DTP.Value.ToString("MMM dd, yyyy")})", frmMainForm.UserName_LBL.Text)
                Editing_PAGIBIG = False
            Else
                SaveLogs($"ADDED PAGIBIG LOAN - {PagEmp_TXT.Text} ({PagEmp_TXT.Tag}), Amount({PagAmort_TXT.Text}), Principal({PagPrincipal_TXT.Text}), Date({PagDate_DTP.Value.ToString("MMM dd, yyyy")})", frmMainForm.UserName_LBL.Text)
            End If

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

            SaveDeductionS(SSS_ID, "SSS LOAN", SSSPrincipal_TXT.Text, SSS_Amort_TXT.Text, "CLOSE PAYROLL", SSS_Date_DTP.Value, SSS_Name_TXT.Tag)
            Load_Loans(SSSLoan_LV, "PAYROLL_DEDUCTION", "SSS LOAN")

            If Editing_SSS = True Then
                SaveLogs($"ALTERED DEDUCTION - SSS LOAN (From {OrigAmount_SSS} to {SSSPrincipal_TXT.Text}) {SSS_Name_TXT.Text} ({SSS_Name_TXT.Tag}), Amort({SSS_Amort_TXT.Text}), Principal({SSSPrincipal_TXT.Text}), Date({SSS_Date_DTP.Value.ToString("MMM dd, yyyy")})", frmMainForm.UserName_LBL.Text)
                Editing_SSS = False
            Else
                SaveLogs($"ADDED DEDUCTION - SSS LOAN {SSS_Name_TXT.Text} ({SSS_Name_TXT.Tag}), Amort({SSS_Amort_TXT.Text}), Principal({SSSPrincipal_TXT.Text}), Date({SSS_Date_DTP.Value.ToString("MMM dd, yyyy")})", frmMainForm.UserName_LBL.Text)
            End If

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
        Load_Loans(Pagibig_List, "PAYROLL_DEDUCTION", "PAG-IBIG LOAN", PagSearch_TXT.Text)
    End Sub

    Private Sub SSS_Search_BTN_Click(sender As Object, e As EventArgs) Handles SSS_Search_BTN.Click
        Load_Loans(SSSLoan_LV, "PAYROLL_DEDUCTION", "SSS LOAN", SSS_Search_TXT.Text)
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
        SSS_Amort_TXT.Tag = SSSLoan_LV.Items(SSSLoan_LV.FocusedItem.Index).SubItems(2).Text
        SSS_Date_DTP.Value = SSSLoan_LV.Items(SSSLoan_LV.FocusedItem.Index).SubItems(3).Text
        Editing_SSS = True
        OrigAmount_SSS = SSSPrincipal_TXT.Text
    End Sub

    Private Sub PagEdit_Menu_Click(sender As Object, e As EventArgs) Handles PagEdit_Menu.Click
        PAGIBIG_ID = Pagibig_List.Items(Pagibig_List.FocusedItem.Index).SubItems(2).Tag
        PagEmp_TXT.Text = Pagibig_List.Items(Pagibig_List.FocusedItem.Index).SubItems(0).Text
        PagEmp_TXT.Tag = Pagibig_List.Items(Pagibig_List.FocusedItem.Index).SubItems(3).Tag
        PagPrincipal_TXT.Text = Pagibig_List.Items(Pagibig_List.FocusedItem.Index).SubItems(1).Text
        PagAmort_TXT.Text = Pagibig_List.Items(Pagibig_List.FocusedItem.Index).SubItems(2).Text
        PagAmort_TXT.Tag = Pagibig_List.Items(Pagibig_List.FocusedItem.Index).SubItems(2).Text
        PagDate_DTP.Value = Pagibig_List.Items(Pagibig_List.FocusedItem.Index).SubItems(3).Text
        Editing_PAGIBIG = True
        OrigAmount_PAGIBIG = PagPrincipal_TXT.Text
    End Sub

    Private Sub SSSBalance_Menu_Click(sender As Object, e As EventArgs) Handles SSSBalance_Menu.Click
        MsgBox("Balance               :  " & FormatNumber(GetSSS_Balance()), MsgBoxStyle.Information, "TOTAL")
    End Sub

    Private Function GetSSS_Balance()
        Dim bioNo As String = SSSLoan_LV.Items(SSSLoan_LV.FocusedItem.Index).SubItems(3).Tag
        Dim IDX As Integer = SSSLoan_LV.Items(SSSLoan_LV.FocusedItem.Index).SubItems(2).Tag
        Dim credit As Decimal = GetData_Decimal("CREDIT", $"PAYROLL_DEDUCTION WHERE ID = '{IDX}'")
        Dim CollectedCredit As Decimal = GetTotal("AMOUNT", $"RECORDED_ALLOW_DEDUC WHERE R_DEDUC_ID = '{IDX}' and PAYDATE <> '12/15/2021'")
        Dim PartialPayment As Decimal = GetTotal("AMOUNT", $"PARTIAL_PAYMENT WHERE DEDUCT_ID = '{IDX}';")
        Dim totalCredit As Decimal = credit + CollectedCredit + PartialPayment
        Dim balance As Decimal

        If GetData("STATUS", $"PAYROLL_DEDUCTION WHERE ID = '{IDX}'") = "PAID" Then
            balance = 0.00
        Else
            If (CollectedCredit + PartialPayment) > 0 Then
                balance = CDec(GetData_Decimal("PRINCIPAL", $"PAYROLL_DEDUCTION WHERE ID = '{IDX}'")) - totalCredit
            Else
                balance = CDec(GetData_Decimal("BALANCE", $"PAYROLL_DEDUCTION WHERE ID = '{IDX}'"))
            End If
        End If

        Return balance
    End Function

    Private Sub PagBalance_Menu_Click(sender As Object, e As EventArgs) Handles PagBalance_Menu.Click
        MsgBox("Balance               :  " & FormatNumber(GetPagibig_Balance()), MsgBoxStyle.Information, "TOTAL")
    End Sub

    Private Function GetPagibig_Balance()
        Dim bioNo As String = Pagibig_List.Items(Pagibig_List.FocusedItem.Index).SubItems(3).Tag
        Dim IDX As Integer = Pagibig_List.Items(Pagibig_List.FocusedItem.Index).SubItems(2).Tag
        Dim credit As Decimal = GetData_Decimal("CREDIT", $"PAYROLL_DEDUCTION WHERE ID = '{IDX}'")
        Dim CollectedCredit As Decimal = GetTotal("AMOUNT", $"RECORDED_ALLOW_DEDUC WHERE R_DEDUC_ID = '{IDX}' and PAYDATE <> '12/15/2021'")
        Dim PartialPayment As Decimal = GetTotal("AMOUNT", $"PARTIAL_PAYMENT WHERE DEDUCT_ID = '{IDX}';")
        Dim totalCredit As Decimal = credit + CollectedCredit + PartialPayment
        Dim balance As Decimal

        If GetData("STATUS", $"PAYROLL_DEDUCTION WHERE ID = '{IDX}'") = "PAID" Then
            balance = 0.00
        Else
            If (CollectedCredit + PartialPayment) > 0 Then
                balance = CDec(GetData_Decimal("PRINCIPAL", $"PAYROLL_DEDUCTION WHERE ID = '{IDX}'")) - totalCredit
            Else
                balance = CDec(GetData_Decimal("BALANCE", $"PAYROLL_DEDUCTION WHERE ID = '{IDX}'"))
            End If
        End If

        Return balance
    End Function

    Private Sub SSSSubtotal_Menu_Click(sender As Object, e As EventArgs) Handles SSSSubtotal_Menu.Click
        Dim bioNo As String
        Dim total_amount, Amount_perPayroll, balance As Decimal

        If SSSLoan_LV.SelectedItems.Count > 0 Then

            bioNo = SSSLoan_LV.Items(SSSLoan_LV.FocusedItem.Index).SubItems(3).Tag
            total_amount = GetTotal("PRINCIPAL", $"PAYROLL_DEDUCTION WHERE BIO_NO = '{bioNo}' AND CATEGORY = 'SSS LOAN' AND STATUS IS NULL")

            Amount_perPayroll = GetTotal("AMORT", $"PAYROLL_DEDUCTION WHERE BIO_NO = '{bioNo}' AND CATEGORY = 'SSS LOAN' AND STATUS IS NULL")

            balance = GetTotal("BALANCE", $"PAYROLL_DEDUCTION WHERE BIO_NO = '{bioNo}' AND CATEGORY = 'SSS LOAN' AND STATUS IS NULL")

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
            total_amount = GetTotal("PRINCIPAL", $"PAYROLL_DEDUCTION WHERE BIO_NO = '{bioNo}' AND CATEGORY = 'PAG-IBIG LOAN' AND STATUS IS NULL")

            Amount_perPayroll = GetTotal("AMORT", $"PAYROLL_DEDUCTION WHERE BIO_NO = '{bioNo}' AND CATEGORY = 'PAG-IBIG LOAN' AND STATUS IS NULL")

            balance = GetTotal("BALANCE", $"PAYROLL_DEDUCTION WHERE BIO_NO = '{bioNo}' AND CATEGORY = 'PAG-IBIG LOAN' AND STATUS IS NULL")

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
        MaxAmort_txt.Tag = Maxicare_List.Items(Maxicare_List.FocusedItem.Index).SubItems(1).Text
        MaxDate_dtp.Value = Maxicare_List.Items(Maxicare_List.FocusedItem.Index).SubItems(2).Text
        MaxStatus_Combo.Text = IIf(GetData("STATUS", $"PAYROLL_OTHER_DEDUCTION WHERE ID = '{MAXICARE_ID}'") = Nothing, "ON", "OFF")
    End Sub

    Private Sub Mp2Edit_Menu_Click(sender As Object, e As EventArgs) Handles Mp2Edit_Menu.Click
        MP2_ID = Mp2_List.Items(Mp2_List.FocusedItem.Index).SubItems(2).Tag
        Mp2Emp_txt.Text = Mp2_List.Items(Mp2_List.FocusedItem.Index).SubItems(0).Text
        Mp2Emp_txt.Tag = Mp2_List.Items(Mp2_List.FocusedItem.Index).SubItems(3).Tag
        Mp2Sched_Combo.Text = Mp2_List.Items(Mp2_List.FocusedItem.Index).SubItems(3).Text
        Mp2Amort_txt.Text = Mp2_List.Items(Mp2_List.FocusedItem.Index).SubItems(1).Text
        Mp2Amort_txt.Tag = Mp2_List.Items(Mp2_List.FocusedItem.Index).SubItems(1).Text
        Mp2Date_dtp.Value = Mp2_List.Items(Mp2_List.FocusedItem.Index).SubItems(2).Text
        Mp2Status_Combo.Text = IIf(GetData("STATUS", $"PAYROLL_OTHER_DEDUCTION WHERE ID = '{MP2_ID}'") = Nothing, "ON", "OFF")
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

    Private Sub Partial_txt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles PartialAmount_txt.KeyPress
        If e.KeyChar <> ChrW(Keys.Back) Then
            If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso Not e.KeyChar = "." Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub PartialPaymentMenu_Click(sender As Object, e As EventArgs) Handles PartialPaymentDeducMenu.Click
        Dim name As String = Deduc_list.Items(Deduc_list.FocusedItem.Index).SubItems(0).Text
        Dim bioNo As String = Deduc_list.Items(Deduc_list.FocusedItem.Index).SubItems(1).Tag
        Dim deduc_id As String = Deduc_list.Items(Deduc_list.FocusedItem.Index).SubItems(4).Tag
        Dim category As String = Deduc_list.Items(Deduc_list.FocusedItem.Index).SubItems(1).Text
        PartialPanel(name, bioNo, deduc_id, category, GetDeduction_Balance(deduc_id))
    End Sub

    Private Sub PartialPanel(name As String, bioNo As String, deduc_id As String, category As String, balance As String)
        PartialAmount_txt.Text = balance
        PartialName_txt.Text = name
        PartialName_txt.Tag = deduc_id
        PartialCat_txt.Text = category
        Label52.Tag = bioNo
        PartialAmount_txt.Focus()

        'SIZE AND LOCATION OF THE PARTIAL PANEL
        Dim x As Integer = (Parent.ClientSize.Width - Partial_Panel.Width) / 2
        Dim y As Integer = (Parent.ClientSize.Height - Partial_Panel.Height) / 2
        Partial_Panel.Location = New Point(x, y)
        Partial_Panel.Size = New Size(405, 189)
        Partial_Panel.Visible = True
    End Sub

    Private Sub Label50_Click(sender As Object, e As EventArgs) Handles Label50.Click
        Partial_Panel.Visible = False
    End Sub

    Private Sub Partial_Panel_MouseDown(sender As Object, e As MouseEventArgs) Handles Partial_Panel.MouseDown
        allowMove = True
        Cursor = Cursors.SizeAll
        moveLocation = New Point(e.X, e.Y)
    End Sub

    Private Sub Partial_Panel_MouseUp(sender As Object, e As MouseEventArgs) Handles Partial_Panel.MouseUp
        allowMove = False
        Cursor = Cursors.Default
    End Sub

    Private Sub Partial_Panel_MouseMove(sender As Object, e As MouseEventArgs) Handles Partial_Panel.MouseMove
        If allowMove = True Then
            Partial_Panel.Location = New Point(Partial_Panel.Location.X + e.X - moveLocation.X, Partial_Panel.Location.Y + e.Y - moveLocation.Y)
        End If
    End Sub

    Private Sub PartialCheck_btn_Click(sender As Object, e As EventArgs) Handles PartialCheck_btn.Click
        If PartialAmount_txt.Text = 0 Or PartialAmount_txt.Text = Nothing Then
        Else
            Dim result As DialogResult = MsgBox("Are you sure you want to save changes?", MsgBoxStyle.YesNo)
            If result = DialogResult.Yes Then
                SavePartialPayment(PartialName_txt.Tag, Label52.Tag, PartialAmount_txt.Text)
                CheckDeduction_Loans_IfZeroBalance(Label52.Tag) 'BIO_NO

                SaveLogs($"ADDED DEDUCTION PARTIAL PAYMENT - {PartialName_txt.Text} ({Label52.Tag}), Deduction_ID({PartialName_txt.Tag}),  Category({PartialCat_txt.Text}), Amount({PartialAmount_txt.Text})", frmMainForm.UserName_LBL.Text)

                PartialName_txt.Clear()
                PartialCat_txt.Clear()
                PartialAmount_txt.Clear()
                Partial_Panel.Visible = False
                Lists_deduction(Deduc_list)
                Load_Loans(SSSLoan_LV, "PAYROLL_DEDUCTION", "SSS LOAN")
                Load_Loans(Pagibig_List, "PAYROLL_DEDUCTION", "PAG-IBIG LOAN")
            End If
        End If
    End Sub

    Private Sub PartialX_btn_Click(sender As Object, e As EventArgs) Handles PartialX_btn.Click
        PartialName_txt.Clear()
        PartialCat_txt.Clear()
        PartialAmount_txt.Clear()
        Partial_Panel.Visible = False
        Lists_deduction(Deduc_list)
    End Sub

    Private Sub PartialPaymentSSSMenuItem_Click(sender As Object, e As EventArgs) Handles PartialPaymentSSSMenuItem.Click
        Dim name As String = SSSLoan_LV.Items(SSSLoan_LV.FocusedItem.Index).SubItems(0).Text
        Dim bioNo As String = SSSLoan_LV.Items(SSSLoan_LV.FocusedItem.Index).SubItems(3).Tag
        Dim sss_id As String = SSSLoan_LV.Items(SSSLoan_LV.FocusedItem.Index).SubItems(2).Tag
        Dim category As String = "SSS LOAN"
        PartialPanel(name, bioNo, sss_id, category, GetSSS_Balance())
    End Sub

    Private Sub Loans_Tab_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Loans_Tab.SelectedIndexChanged
        Partial_Panel.Visible = False
    End Sub

    Private Sub PartialPaymentPagMenuItem_Click(sender As Object, e As EventArgs) Handles PartialPaymentPagMenuItem.Click
        Dim name As String = Pagibig_List.Items(Pagibig_List.FocusedItem.Index).SubItems(0).Text
        Dim bioNo As String = Pagibig_List.Items(Pagibig_List.FocusedItem.Index).SubItems(3).Tag
        Dim pagibig_id As String = Pagibig_List.Items(Pagibig_List.FocusedItem.Index).SubItems(2).Tag
        Dim category As String = "PAG-IBIG LOAN"
        PartialPanel(name, bioNo, pagibig_id, category, GetPagibig_Balance())
    End Sub

    Private Sub SBU_Cancel_btn_Click(sender As Object, e As EventArgs) Handles SBU_Cancel_btn.Click
        SBU_Name_txt.Clear()
        SBU_Date_dtp.Value = Today
        SBU_Principal_txt.Clear()
        SBU_Amort_txt.Clear()
    End Sub

    Private Sub SBU_Save_btn_Click(sender As Object, e As EventArgs) Handles SBU_Save_btn.Click
        If SBU_Name_txt.Text = Nothing Then
            MsgBox("Please select employee.", MsgBoxStyle.Exclamation)
        ElseIf SBU_Principal_txt.Text = Nothing Then
            MsgBox("Please indicate the principal amount.", MsgBoxStyle.Exclamation)
        ElseIf SBU_Principal_txt.Text = Nothing Then
            MsgBox("Please indicate the amort.", MsgBoxStyle.Exclamation)
        ElseIf ScheduleSBU_Combo.Text = Nothing Then
            MsgBox("Please select the schedule.", MsgBoxStyle.Exclamation)
        Else
            SaveNewSBU(SBU_Name_txt.Text, SBU_Name_txt.Tag, SBU_Amort_txt.Text, SBU_Principal_txt.Text, ScheduleSBU_Combo.Text)
            Lists_SBU(SBU_LV)
            SBU_Cancel_btn.PerformClick()
        End If
    End Sub

    Private Sub SBU_Search_btn_Click(sender As Object, e As EventArgs) Handles SBU_SearchEmp_btn.Click
        Try
            Dim instForm As Form = Application.OpenForms.OfType(Of Form)().Where(Function(frm) frm.Name = "frmNewEmployee").SingleOrDefault()
            If instForm Is Nothing Then
                Dim frm As frmNewEmployee
                frm = DirectCast(CreateObjectInstance("frmNewEmployee"), Form)
                frm.MdiParent = frmMainForm
                frmMainForm.pNavigate.Controls.Add(frm)
                frmMainForm.pNavigate.Tag = frm
                frm.txtSearch.Tag = "Loan-SBU"
                frm.Dock = DockStyle.Fill
                frm.BringToFront()
                frm.Show()
            Else
                instForm.BringToFront()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub SBU_Search_btn_Click_1(sender As Object, e As EventArgs) Handles SBU_Search_btn.Click
        Lists_SBU(SBU_LV, SBU_Search_txt.Text)
    End Sub

    Private Sub SBU_Search_txt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles SBU_Search_txt.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SBU_Search_btn.PerformClick()
        End If
    End Sub

    Private Sub SBUEdit_Menu_Click(sender As Object, e As EventArgs) Handles SBUEdit_Menu.Click
        GetSBU_Details()
    End Sub

    Private Sub SBU_LV_DoubleClick(sender As Object, e As EventArgs) Handles SBU_LV.DoubleClick
        GetSBU_Details()
    End Sub

    Private Sub GetSBU_Details()
        SBU_Name_txt.Text = SBU_LV.Items(SBU_LV.FocusedItem.Index).SubItems(0).Text
        SBU_Name_txt.Tag = SBU_LV.Items(SBU_LV.FocusedItem.Index).SubItems(4).Tag
        SBU_Principal_txt.Text = SBU_LV.Items(SBU_LV.FocusedItem.Index).SubItems(2).Text
        SBU_Amort_txt.Text = SBU_LV.Items(SBU_LV.FocusedItem.Index).SubItems(1).Text
        ScheduleSBU_Combo.Text = GetData("SCHED", $"PAYROLL_SBU where BIO_NO ='{SBU_Name_txt.Tag}'")
        Dim datee As String = GetData("DATE_ADDED", $"PAYROLL_SBU where BIO_NO ='{SBU_Name_txt.Tag}'")
        SBU_Date_dtp.Value = IIf(datee = "", Today, datee)
    End Sub

    Private Sub menu_remove_Click(sender As Object, e As EventArgs) Handles menu_remove.Click
        Dim deductID As Integer = Deduc_list.Items(Deduc_list.FocusedItem.Index).SubItems(4).Tag
        Dim namee As String = Deduc_list.Items(Deduc_list.FocusedItem.Index).SubItems(0).Text
        Dim bioNo As Integer = Deduc_list.Items(Deduc_list.FocusedItem.Index).SubItems(1).Tag
        Dim category As String = Deduc_list.Items(Deduc_list.FocusedItem.Index).SubItems(1).Text
        Dim principal As String = Deduc_list.Items(Deduc_list.FocusedItem.Index).SubItems(2).Text
        Dim datee As Date = Deduc_list.Items(Deduc_list.FocusedItem.Index).SubItems(2).Tag
        Dim amort As String = Deduc_list.Items(Deduc_list.FocusedItem.Index).SubItems(3).Text
        Dim sched As String = Deduc_list.Items(Deduc_list.FocusedItem.Index).SubItems(4).Text
        If Deduc_list.Items(Deduc_list.FocusedItem.Index).BackColor <> Color.LightCoral Then
            Dim result As DialogResult = MsgBox("Are you sure you want to remove this?", MsgBoxStyle.YesNo)
            If result = DialogResult.Yes Then
                RunCommand($"UPDATE PAYROLL_DEDUCTION SET STATUS = 'REMOVED' WHERE ID = {deductID}")
                SaveLogs($"DEDUCTION DELETED - {namee} ({bioNo}), Category({category}), Total({principal}), Schedule({sched}), Date({datee.ToString("MMM dd, yyyy")})", frmMainForm.UserName_LBL.Text)
            End If
        End If
    End Sub


    Private Sub SearchEMP_BTN_Click(sender As Object, e As EventArgs)
        Try
            Dim instForm As Form = Application.OpenForms.OfType(Of Form)().Where(Function(frm) frm.Name = "frmNewEmployee").SingleOrDefault()
            If instForm Is Nothing Then
                Dim frm As frmNewEmployee
                frm = DirectCast(CreateObjectInstance("frmNewEmployee"), Form)
                frm.MdiParent = frmMainForm
                frmMainForm.pNavigate.Controls.Add(frm)
                frmMainForm.pNavigate.Tag = frm
                frm.txtSearch.Tag = "SOAForm"
                frm.Dock = DockStyle.Fill
                frm.BringToFront()
                frm.Show()
            Else
                instForm.BringToFront()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub gridSOA_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridSOA.CellDoubleClick
        Dim grid = DirectCast(sender, DataGridView)
        Dim selectedRow As DataGridViewRow = gridSOA.Rows(e.RowIndex)
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            If TypeOf gridSOA.Columns(e.ColumnIndex) Is DataGridViewButtonColumn Then
                If grid.Columns(e.ColumnIndex).Name = "dataRemarks" Then
                    If selectedRow.Cells("dataRemarks").Value = "Add" Then
                        rbRemarksSOA.Text = ""
                    Else
                        rbRemarksSOA.Text = selectedRow.Cells("dataRemarks").Tag
                    End If

                    Dim x As Integer = (Parent.ClientSize.Width - Partial_Panel.Width) / 2
                    Dim y As Integer = (Parent.ClientSize.Height - Partial_Panel.Height) / 2
                    panelRemarksSOA.Location = New Point(x, y)
                    panelRemarksSOA.Size = New Size(381, 240)
                    panelRemarksSOA.Visible = True

                Else

                    If selectedRow.Cells("dataAttachment").Value = "Upload" Then

                        CreateAndShowTemporaryPanel()

                    Else
                        'Dim path As String = $"{My.Settings.FileIRRecordsPath}\{fullname}\IR No. {irno}\Explanation.pdf"

                        'Try
                        '    Process.Start(path)
                        'Catch ex As Exception
                        '    MsgBox("File Does not exists!", MsgBoxStyle.Exclamation)
                        'End Try
                    End If
                End If
            Else

                bioNo = selectedRow.Cells("dataFullname").Tag
                fullname = selectedRow.Cells("dataFullname").Value.ToString()
                designation = selectedRow.Cells("dataDesignation").Value.ToString()
                minimumRate = selectedRow.Cells("dataDesignation").Tag
                company = selectedRow.Cells("dataCompany").Value.ToString()

                GetSOAInfo(bioNo, fullname, designation, company, minimumRate, rpt_SOA)
            End If
        End If
    End Sub
    Private Sub CreateAndShowTemporaryPanel()
        ' Create a new form for the popup
        Dim tempForm As New Form()
        tempForm.Text = "Temporary Panel Form"
        tempForm.Size = New Size(450, 150)
        tempForm.StartPosition = FormStartPosition.CenterScreen
        tempForm.FormBorderStyle = FormBorderStyle.None

        ' Initialize and configure the dynamic panel
        Dim panelDynamic As New Panel()
        panelDynamic.Size = New Size(609, 81)
        panelDynamic.Location = New Point(10, 10)
        panelDynamic.BackColor = Color.FromArgb(64, 0, 64)
        tempForm.Controls.Add(panelDynamic)

        ' Initialize and configure the label
        Dim labelBrowse As New Label()
        labelBrowse.Text = "Browse PDF file:"
        labelBrowse.Location = New Point(10, 10)
        panelDynamic.Controls.Add(labelBrowse)

        ' Initialize and configure the textbox
        Dim textBoxPath As New TextBox()
        textBoxPath.Location = New Point(120, 10)
        textBoxPath.Size = New Size(200, 20)
        panelDynamic.Controls.Add(textBoxPath)

        ' Initialize and configure the Browse button
        Dim buttonBrowse As New Button()
        buttonBrowse.Text = "Browse"
        buttonBrowse.Location = New Point(330, 10)
        AddHandler buttonBrowse.Click, Sub(sender As Object, e As EventArgs)
                                           Using openFileDialog As New OpenFileDialog()
                                               openFileDialog.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*"
                                               openFileDialog.Title = "Browse PDF File"

                                               If openFileDialog.ShowDialog() = DialogResult.OK Then
                                                   textBoxPath.Text = openFileDialog.FileName
                                               End If
                                           End Using
                                       End Sub
        panelDynamic.Controls.Add(buttonBrowse)

        ' Initialize and configure the Save button
        Dim buttonSave As New Button()
        buttonSave.Text = "Save"
        buttonSave.Location = New Point(330, 25)
        AddHandler buttonSave.Click, Sub(sender As Object, e As EventArgs)
                                         ' Implement the save functionality here
                                         MessageBox.Show("Save button clicked. Implement the save functionality as needed.")
                                     End Sub

        ' Initialize and configure the Save button
        Dim buttonCancel As New Button()
        buttonSave.Text = "Cancel"
        buttonSave.Location = New Point(330, 35)
        AddHandler buttonCancel.Click, Sub(sender As Object, e As EventArgs)
                                           ' Implement the save functionality here
                                           MessageBox.Show("Save button clicked. Implement the save functionality as needed.")
                                       End Sub
        panelDynamic.Controls.Add(buttonSave)

        ' Show the form as a dialog
        tempForm.ShowDialog()
    End Sub

    Dim bioNo As Integer = Nothing
    Dim fullname As String = Nothing
    Dim designation As String = Nothing
    Dim minimumRate As Decimal = Nothing
    Dim company As String = Nothing

    Private Sub gridSOA_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridSOA.CellContentClick
        Dim grid = DirectCast(sender, DataGridView)
        Dim selectedRow As DataGridViewRow = gridSOA.Rows(e.RowIndex)
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            If TypeOf gridSOA.Columns(e.ColumnIndex) Is DataGridViewButtonColumn Then
                If grid.Columns(e.ColumnIndex).Name = "dataRemarks" Then
                    If selectedRow.Cells("dataRemarks").Value = "Add" Then
                        rbRemarksSOA.Text = ""
                    Else
                        rbRemarksSOA.Text = selectedRow.Cells("dataRemarks").Tag
                    End If

                    Dim x As Integer = (Parent.ClientSize.Width - Partial_Panel.Width) / 2
                    Dim y As Integer = (Parent.ClientSize.Height - Partial_Panel.Height) / 2
                    panelRemarksSOA.Location = New Point(x, y)
                    panelRemarksSOA.Size = New Size(381, 240)
                    panelRemarksSOA.Visible = True

                Else

                    If selectedRow.Cells("dataAttachment").Value = "Upload" Then

                        CreateAndShowTemporaryPanel()

                    Else
                        'Dim path As String = $"{My.Settings.FileIRRecordsPath}\{fullname}\IR No. {irno}\Explanation.pdf"

                        'Try
                        '    Process.Start(path)
                        'Catch ex As Exception
                        '    MsgBox("File Does not exists!", MsgBoxStyle.Exclamation)
                        'End Try
                    End If
                End If
            Else

                bioNo = selectedRow.Cells("dataFullname").Tag
                fullname = selectedRow.Cells("dataFullname").Value.ToString()
                designation = selectedRow.Cells("dataDesignation").Value.ToString()
                minimumRate = selectedRow.Cells("dataDesignation").Tag
                company = selectedRow.Cells("dataCompany").Value.ToString()

                GetSOAInfo(bioNo, fullname, designation, company, minimumRate, rpt_SOA)
            End If
        End If
    End Sub

    Private Sub btnCancelSOA_Click(sender As Object, e As EventArgs) Handles btnCancelSOA.Click
        panelRemarksSOA.Visible = False
        rbRemarksSOA.Text = ""
    End Sub

    Private Sub btnSaveSOA_Click(sender As Object, e As EventArgs) Handles btnSaveSOA.Click

        'Dim i As Integer = Explain_datagrid.CurrentRow.Index
        'RemarksSave(Explain_datagrid.Item(0, i).Value, Exp_Remarks_RichB.Text)

        'Exp_Remarks_RichB.Text = ""
        'Remarks_Panel.Visible = False

        'PopulateExplaination(Explain_datagrid)

        'MessageBox.Show($"Successfully Saved", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub
End Class