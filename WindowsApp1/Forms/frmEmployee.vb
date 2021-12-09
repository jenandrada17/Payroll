Public Class frmEmployee

    Dim rowCount As Integer

    Private Sub Close_LBL_MouseEnter(sender As Object, e As EventArgs) Handles Close_LBL.MouseEnter
        Close_LBL.ForeColor = Color.Red
    End Sub

    Private Sub Close_LBL_MouseLeave(sender As Object, e As EventArgs) Handles Close_LBL.MouseLeave
        Close_LBL.ForeColor = Color.Black
    End Sub

    Private Sub Close_LBL_Click(sender As Object, e As EventArgs) Handles Close_LBL.Click
        Close()
    End Sub

    Private Sub frmEmployee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadEmployee(lvEmployee)
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        LoadEmployee(lvEmployee, txtSearch.Text)
    End Sub

    Private Sub lvEmployee_MouseClick(sender As Object, e As MouseEventArgs) Handles lvEmployee.MouseClick
        If e.Button = MouseButtons.Right Then
            If lvEmployee.Items.Count > 0 Then
                Context_Action.Show(lvEmployee, New Point(e.X, e.Y))
            End If
        End If
    End Sub

    Private Sub lvEmployee_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lvEmployee.MouseDoubleClick

        If lvEmployee.Items.Count = 0 Then Exit Sub

        Dim idx As Integer = lvEmployee.Items(lvEmployee.FocusedItem.Index).SubItems(1).Tag
        Dim tmpEmp As Employee
        tmpEmp = New Employee
        tmpEmp.LoadEmployee(idx)

        If txtSearch.Tag = "Attendance1" Then

            SwitchForm_Attendance(FormName.Attendance, tmpEmp, 3)
            Close()

        ElseIf txtSearch.Tag = "Attendance-PrintDTR_1" Then

            SwitchForm_Attendance(FormName.Attendance, tmpEmp, 1)
            Close()

        ElseIf txtSearch.Tag = "Attendance-PrintDTR_2" Then

            SwitchForm_Attendance(FormName.Attendance, tmpEmp, 2)
            Close()

        ElseIf txtSearch.Tag = "Payout" Then

            SwitchForm_Payout(FormName.Payout, tmpEmp, btnSearch.Tag, "DETAILS")
            Close()

        ElseIf txtSearch.Tag = "Payslip-Employee" Then

            SwitchForm_Payout(FormName.Payout, tmpEmp, btnSearch.Tag, "PAYSLIP")
            Close()

        ElseIf txtSearch.Tag = "Settings-Rate" Then

            SwitchForm_Settings(FormName.Settings, tmpEmp, "RATE")
            Close()

        ElseIf txtSearch.Tag = "Settings-Allowance" Then

            SwitchForm_Settings(FormName.Settings, tmpEmp, "ALLOWANCE")
            Close()

        ElseIf txtSearch.Tag = "Settings-Deduction" Then

            SwitchForm_Settings(FormName.Settings, tmpEmp, "DEDUCTION")
            Close()

        ElseIf txtSearch.Tag = "SSS Loan" Then

            SwitchForm_Loans(FormName.Loans, tmpEmp, "SSS")
            Close()

        ElseIf txtSearch.Tag = "Pagibig Loan" Then

            SwitchForm_Loans(FormName.Loans, tmpEmp, "PAGIBIG")
            Close()

        End If

    End Sub

    Private Sub Close_Modify_BTN_Click(sender As Object, e As EventArgs) Handles Close_Modify_BTN.Click
        Modify_Panel.Visible = False
    End Sub

    Private Sub lvEmployee_Click(sender As Object, e As EventArgs) Handles lvEmployee.Click
        Modify_Panel.Visible = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Check_BTN.Click
        UpdateRateDetails()
    End Sub

    Public Sub UpdateRateDetails()

        Dim idx As Integer = lvEmployee.FocusedItem.SubItems(2).Tag

        Dim mysql As String = "Select * From tbl_employee Where id = '" & idx & "'"
        Using ds As DataSet = LoadSQL(mysql, "tbl_employee")
            If ds.Tables(0).Rows.Count > 0 Then
                With ds.Tables(0).Rows(0)
                    If Not Rate_TXT.Text = "" Then
                        Modify_Panel.Visible = False
                        .Item("EMP_RATE") = Rate_TXT.Text
                        .Item("FIX_RATE") = Fix_Combo.Text
                        SaveEntry(ds, False)
                        LoadEmployee(lvEmployee)
                    Else
                        Rate_TXT.Region = New Region(New Rectangle(2, 2, Rate_TXT.Width - 4, Rate_TXT.Height - 4))
                    End If
                End With
            End If
        End Using

    End Sub

    Private Sub GroupBox1_Paint(sender As Object, e As PaintEventArgs) Handles GroupBox1.Paint
        Dim p As New Pen(Color.Red, 2)
        e.Graphics.DrawRectangle(p, New Rectangle(Rate_TXT.Location + New Size(1, 1), Rate_TXT.Size - New Size(2, 2)))
        p.Dispose()
    End Sub

    Private Sub Rate_TXT_TextChanged(sender As Object, e As EventArgs) Handles Rate_TXT.TextChanged
        If Rate_TXT.Text = "" Then
            Rate_TXT.Region = New Region(New Rectangle(2, 2, Rate_TXT.Width - 4, Rate_TXT.Height - 4))
        Else
            Rate_TXT.Region = Nothing
        End If
    End Sub

    Private Sub Rate_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Rate_TXT.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Check_BTN.PerformClick()
        End If
    End Sub

    Private Sub View_Context_Click(sender As Object, e As EventArgs) Handles View_Context.Click
        'If frmEmployeeInfo Is Nothing Then
        '    Dim frm As New frmEmployeeInfo With {
        '        .MdiParent = frmMainForm
        '    }
        '    frmMainForm.pNavigate.Controls.Add(frm)
        '    frmMainForm.pNavigate.Tag = frm
        '    frm.Biometric_TXT.Text = lvEmployee.FocusedItem.SubItems(0).Text
        '    frm.Show()
        '    frm.Dock = DockStyle.Fill
        '    frm.BringToFront()
        'Else
        '    frmEmployeeInfo.BringToFront()
        'End If
    End Sub

    Private Sub txtSearch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSearch.KeyPress
        If IsEnter(e) Then btnSearch.PerformClick()
    End Sub

End Class