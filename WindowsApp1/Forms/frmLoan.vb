Public Class frmLoan

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
        Load_Loans(Pag_grid, "PAYROLL_LOANS", "PAG-IBIG")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Cancel_btn.Click
        Name_txt.Clear()
        PrincipalDeduc_txt.Clear()
        CategoryDeduc_txt.Clear()
        Schedule_Combo.Text = Nothing
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Save_btn.Click

        If Not isValidSave_DEDUC() Then Exit Sub
        '======================================== CHECK IF CONTEXT EDIT CLICK =======================================

        Dim result As DialogResult = MsgBox($"Deduction for {Name_txt.Text} will be recorded, proceed anyway?", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then

            If Deduc_list.Tag = 0 Then
                SaveDeductionS(CategoryDeduc_txt.Text, PrincipalDeduc_txt.Text, Schedule_Combo.Text, DateCharges_DTP.Value, Name_txt.Tag) 'Category_Combo.Tag (EMP_ID) | Name_TXT.Tag(Biometric) |  SearchEmp_BTN.Tag.Tag(Branch_id) |  
            Else
                updateDeductionS(CategoryDeduc_txt.Tag.Tag, CategoryDeduc_txt.Text, PrincipalDeduc_txt.Text, Schedule_Combo.Text, DateCharges_DTP.Value) 'Category_Combo.Tag (EMP_ID)
            End If

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

            'ElseIf String.IsNullOrEmpty(noOfDeduc_txt.Text) Then
            '    noOfDeduc_txt.Region = New Region(New Rectangle(2, 2, noOfDeduc_txt.Width - 4, noOfDeduc_txt.Height - 4))
            '    Return False
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
            total_amount = GetDeduction_PRINCIPAL(bioNo)

            Amount_perPayroll = GetDeduction_ChargesRange(bioNo, total_amount)
            balance = GetDeduction_OverAll_Balance(bioNo)

            MsgBox("Total Amount     :  " & FormatNumber(total_amount) & vbCrLf &
                       "Amount/Payroll  :  " & FormatNumber(Amount_perPayroll) & vbCrLf &
                       "Balance               :  " & FormatNumber(balance), MsgBoxStyle.Information, "TOTAL")
        End If

    End Sub

    Private Sub menu_edit_Click(sender As Object, e As EventArgs) Handles menu_edit.Click
        Dim DEDUCT_ID As String = Deduc_list.Items(Deduc_list.FocusedItem.Index).SubItems(3).Tag
        Name_txt.Text = Deduc_list.Items(Deduc_list.FocusedItem.Index).SubItems(0).Text
        Name_txt.Tag = Deduc_list.Items(Deduc_list.FocusedItem.Index).SubItems(1).Tag
        CategoryDeduc_txt.Text = Deduc_list.Items(Deduc_list.FocusedItem.Index).SubItems(1).Text
        PrincipalDeduc_txt.Text = Deduc_list.Items(Deduc_list.FocusedItem.Index).SubItems(2).Text
        Schedule_Combo.Text = Deduc_list.Items(Deduc_list.FocusedItem.Index).SubItems(3).Text
        CategoryDeduc_txt.Tag = DEDUCT_ID

        DateCharges_DTP.Value = GetDeduction_Datee(DEDUCT_ID)

        Save_btn.Tag = "UPDATE"

    End Sub

    Private Sub Deduc_list_MouseClick(sender As Object, e As MouseEventArgs) Handles Deduc_list.MouseClick
        If e.Button = MouseButtons.Right Then
            If Deduc_list.Items.Count > 0 Then
                Context_deduct.Show(Deduc_list, New Point(e.X, e.Y))
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

                Loans_Tab.SelectedIndex = 4
                SSS_Name_TXT.Text = .Fullname
                SSS_Name_TXT.Tag = .BiometricID

            Else
                Loans_Tab.SelectedIndex = 5
                Pag_Name_TXT.Text = .Fullname
                Pag_Name_TXT.Tag = .BiometricID
            End If
        End With
    End Sub

    Private Sub Total_txt_KeyPress_1(sender As Object, e As KeyPressEventArgs) Handles PrincipalDeduc_txt.KeyPress

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

    Private Sub Allow_Cancel_BTN_Click(sender As Object, e As EventArgs) Handles Allow_Cancel_BTN.Click
        SSS_Name_TXT.Clear()
        SSS_Amort_TXT.Clear()
        SSSPrincipal_TXT.Clear()
        SSS_Date_DTP.Value = Today
    End Sub

    Private Sub Allow_Save_BTN_Click(sender As Object, e As EventArgs) Handles Allow_Save_BTN.Click

        Dim result As DialogResult = MsgBox($"SSS Loan for {SSS_Name_TXT.Text} will be recorded, proceed anyway?", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then

            Save_Loans(SSS_Name_TXT.Tag, SSS_Amort_TXT.Text, SSSPrincipal_TXT.Text, SSS_Amort_TXT.Text, SSS_Date_DTP.Value)
            Load_Loans(SSSLoan_LV, "PAYROLL_LOANS", "SSS")

            SaveLogs($"ADDED SSS LOAN {SSS_Name_TXT.Text} ({SSS_Name_TXT.Tag}), Amort({SSS_Amort_TXT.Text}), Principal({SSSPrincipal_TXT.Text}), Date({SSS_Date_DTP.Value.ToString("MMM dd, yyyy")})", frmMainForm.UserName_LBL.Text)
            Allow_Cancel_BTN.PerformClick()
        End If

    End Sub

    Private Sub Emp_BTN_Click(sender As Object, e As EventArgs) Handles Emp_BTN.Click

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

        Dim result As DialogResult = MsgBox($"Pagibig Loan for {Pag_Name_TXT.Text} will be recorded, proceed anyway?", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then

            Save_PAGIBIGLoan(Pag_Name_TXT.Tag, Pag_Amount_TXT.Text, Pag_Start_DTP.Value, Pag_End_DTP.Value, PagibigPrincipal_TXT.Text)
            Load_Loans(Pag_grid, "PAYROLL_LOANS", "PAG-IBIG")

            SaveLogs($"ADDED PAGIBIG LOAN {Pag_Name_TXT.Text} ({Pag_Name_TXT.Tag}), Amount({Pag_Amount_TXT.Text}), Start({Pag_Start_DTP.Value.ToString("MMM dd, yyyy")}), End({Pag_End_DTP.Value.ToString("MMM dd, yyyy")})", frmMainForm.UserName_LBL.Text)
            Pag_Cancel_BTN.PerformClick()
        End If

    End Sub

    Private Sub Pag_Cancel_BTN_Click(sender As Object, e As EventArgs) Handles Pag_Cancel_BTN.Click
        Pag_Name_TXT.Clear()
        Pag_Amount_TXT.Clear()
        Pag_Start_DTP.Value = Today
        Pag_End_DTP.Value = Today
    End Sub

    Private Sub Close_LBL_Click(sender As Object, e As EventArgs) Handles Close_LBL.Click
        Close()
    End Sub

    Private Sub SSS_Amount_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles SSSPrincipal_TXT.KeyPress, SSS_Amort_TXT.KeyPress
        If Not e.KeyChar = ChrW(Keys.Back) Then
            If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not e.KeyChar = "." Then
                e.Handled = True
            End If
        End If
    End Sub
End Class