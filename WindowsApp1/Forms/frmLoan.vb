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
                frm.btnSearch.Tag = Category_Combo.SelectedItem
                frm.Dock = DockStyle.Fill
                frm.BringToFront()
                frm.Show()
            Else
                instForm.BringToFront()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Loans_Tab.SelectedIndex = 1
        Deduct_txt.Select()
    End Sub

    Private Sub DeducSave_BTN_Click(sender As Object, e As EventArgs) Handles CatDeducSave_BTN.Click
        If Not Deduct_txt.Text = "" Then
            SaveCATEGORY(Deduct_txt.Text, "CATEGORY_DEDUCTION", "DEDUCTION_NAME")
            Load_Category_LIST(CatDeduc_list, "CATEGORY_DEDUCTION", "DEDUCTION_NAME")

            SaveLogs($"ADDED CATEGORY FOR DEDUCTION - {Deduct_txt.Text}", frmMainForm.UserName_LBL.Text)

            PopulateComboBox_Any(Category_Combo, "CATEGORY_DEDUCTION", "DEDUCTION_NAME")
            Deduct_txt.Text = ""
        End If
    End Sub

    Private Sub Deduct_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Deduct_txt.KeyPress
        If IsEnter(e) Then CatDeducSave_BTN.PerformClick()
    End Sub

    Private Sub frmLoan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Load_Category_LIST(CatDeduc_list, "CATEGORY_DEDUCTION", "DEDUCTION_NAME")
        PopulateComboBox_Any(Category_Combo, "CATEGORY_DEDUCTION", "DEDUCTION_NAME")
        Lists_deduction(Deduc_list)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Cancel_btn.Click
        Category_Combo.Text = "Select"
        Name_txt.Clear()
        Total_txt.Clear()
        noOfDeduc_txt.Clear()
        Amount_txt.Clear()
        Schedule_Combo.Text = "Select"
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Save_btn.Click

        If Not isValidSave_DEDUC() Then Exit Sub
        '======================================== CHECK IF CONTEXT EDIT CLICK =======================================
        If Deduc_list.Tag = 0 Then
            SaveDeductionS(Category_Combo.SelectedItem, Total_txt.Text, noOfDeduc_txt.Text, Amount_txt.Text, Schedule_Combo.Text, Name_txt.Tag, Effectiv_dtp.Value) 'Category_Combo.Tag (EMP_ID) | Name_TXT.Tag(Biometric) |  SearchEmp_BTN.Tag.Tag(Branch_id) | 
        Else
            updateDeductionS(Deduc_list.Tag, Category_Combo.Text, Total_txt.Text, noOfDeduc_txt.Text, Amount_txt.Text, Schedule_Combo.Text, Effectiv_dtp.Value) 'Category_Combo.Tag (EMP_ID)
        End If

        SaveLogs($"{DE_Save_BTN.Tag} DEDUCTION - {Name_txt.Text} ({Name_txt.Tag}), Category({Category_Combo.Text}), Total({Total_txt.Text}), No. of Gives({noOfDeduc_txt.Text}), Amount/Give({Amount_txt.Text}), Effectivity({Effectiv_dtp.Value.ToString("MMM dd, yyyy")})", frmMainForm.UserName_LBL.Text)

        Lists_deduction(Deduc_list)
        Cancel_btn.PerformClick()

    End Sub

    Private Function isValidSave_DEDUC()

        If String.IsNullOrEmpty(Name_txt.Text) Then
            MsgBox("Please select a name.", MsgBoxStyle.Critical, "Error")
            Return False

        ElseIf Category_Combo.SelectedIndex < 0 Then
            Category_Combo.Region = New Region(New Rectangle(2, 2, Category_Combo.Width - 4, Category_Combo.Height - 4))
            Return False

        ElseIf Schedule_Combo.SelectedIndex < 0 Then
            Schedule_Combo.Region = New Region(New Rectangle(2, 2, Schedule_Combo.Width - 4, Schedule_Combo.Height - 4))
            Return False

        ElseIf String.IsNullOrEmpty(Total_txt.Text) Then
            Total_txt.Region = New Region(New Rectangle(2, 2, Total_txt.Width - 4, Total_txt.Height - 4))
            Return False

        ElseIf String.IsNullOrEmpty(noOfDeduc_txt.Text) Then
            noOfDeduc_txt.Region = New Region(New Rectangle(2, 2, noOfDeduc_txt.Width - 4, noOfDeduc_txt.Height - 4))
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
        Dim bioNo, total_amount, open_amount, close_amount, every_amount, balance As String

        If Deduc_list.SelectedItems.Count > 0 Then
            bioNo = Deduc_list.Items(Deduc_list.FocusedItem.Index).SubItems(1).Tag
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

    Private Sub menu_edit_Click(sender As Object, e As EventArgs) Handles menu_edit.Click
        Name_txt.Text = Deduc_list.Items(Deduc_list.FocusedItem.Index).SubItems(0).Text
        Name_txt.Tag = Deduc_list.Items(Deduc_list.FocusedItem.Index).SubItems(1).Tag
        Category_Combo.Text = Deduc_list.Items(Deduc_list.FocusedItem.Index).SubItems(1).Text
        Schedule_Combo.Text = Deduc_list.Items(Deduc_list.FocusedItem.Index).SubItems(5).Text
        Total_txt.Text = Deduc_list.Items(Deduc_list.FocusedItem.Index).SubItems(2).Text
        noOfDeduc_txt.Text = Deduc_list.Items(Deduc_list.FocusedItem.Index).SubItems(3).Text
        Amount_txt.Text = Deduc_list.Items(Deduc_list.FocusedItem.Index).SubItems(4).Text
        Deduc_list.Tag = Deduc_list.Items(Deduc_list.FocusedItem.Index).SubItems(2).Tag
        Effectiv_dtp.Value = Deduc_list.Items(Deduc_list.FocusedItem.Index).SubItems(3).Tag

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

                'Contribution_Tab.SelectedIndex = 4
                'SSS_Name_TXT.Text = .Fullname
                'SSS_Name_TXT.Tag = .BiometricID

            Else
                'Contribution_Tab.SelectedIndex = 5
                'Pag_Name_TXT.Text = .Fullname
                'Pag_Name_TXT.Tag = .BiometricID
            End If
        End With
    End Sub

    Private Sub Total_txt_KeyPress_1(sender As Object, e As KeyPressEventArgs) Handles Total_txt.KeyPress, noOfDeduc_txt.KeyPress, Amount_txt.KeyPress

        If e.KeyChar <> ChrW(Keys.Back) Then

            If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso Not e.KeyChar = "." Then
                e.Handled = True
            End If
        End If

    End Sub

    Private Sub noOfDeduc_txt_TextChanged(sender As Object, e As EventArgs) Handles noOfDeduc_txt.TextChanged
        If Not Total_txt.Text = String.Empty And Not noOfDeduc_txt.Text = String.Empty And IsNumeric(noOfDeduc_txt.Text) Then
            Amount_txt.Text = Math.Ceiling(Convert.ToDouble(Total_txt.Text) / Convert.ToDouble(noOfDeduc_txt.Text))
            noOfDeduc_txt.Region = Nothing
        Else
            Amount_txt.Clear()
        End If
    End Sub

    Private Sub Total_txt_TextChanged(sender As Object, e As EventArgs) Handles Total_txt.TextChanged
        If Total_txt.Text = Nothing Then
            noOfDeduc_txt.Text = Nothing
            Amount_txt.Text = Nothing
        End If
    End Sub

    Private Sub Search_txt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Search_txt.KeyPress
        If IsEnter(e) Then Search_btn.PerformClick()
    End Sub
End Class