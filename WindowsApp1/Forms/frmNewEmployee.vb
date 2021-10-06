Imports Microsoft.Office.Interop

Public Class frmNewEmployee

    Dim MyConnection As System.Data.OleDb.OleDbConnection
    Dim DtSet As System.Data.DataSet
    Dim MyCommand As System.Data.OleDb.OleDbDataAdapter

    Dim eApp As New Excel.Application
    Dim eBook As Excel.Workbook = Nothing
    Dim eSheet As Excel.Worksheet = Nothing
    Dim eCell As Excel.Range

    Private allowCoolMove As Boolean = False
    Private myCoolPoint As New Point


    Private Sub frmNewEmployee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Lists_Employees(lvEmployee)
        'ListViewGrouping(lvEmployee, 0)
    End Sub

    Private Sub Close_LBL_Click(sender As Object, e As EventArgs) Handles Close_LBL.Click
        Close()
    End Sub

    Private Sub Label76_Click(sender As Object, e As EventArgs) Handles Label76.Click
        Excel_Panel.Visible = False
    End Sub

    Private Sub Browse_BTN_Click(sender As Object, e As EventArgs) Handles Browse_BTN.Click
        Using f As New OpenFileDialog
            f.Filter = "Excel 2003|*.xls|Excel 2007|*.xlsx"
            If DialogResult.OK = f.ShowDialog() Then
                Path_TXT.Text = f.FileName
                ExcelFilePath(Path_TXT.Text)
                Save_BTN.Enabled = True
            End If
        End Using
    End Sub

    Private Sub Save_BTN_Click(sender As Object, e As EventArgs) Handles Save_BTN.Click
        If Company_ComboB.SelectedIndex >= 0 Then

            eApp = New Excel.Application
            eBook = eApp.Workbooks.Open(Path_TXT.Text)
            eSheet = eBook.Worksheets(1)
            eCell = eSheet.UsedRange
            Dim row As Integer

            MyConnection = New System.Data.OleDb.OleDbConnection($"provider=Microsoft.Jet.OLEDB.4.0;Data Source='{Path_TXT.Text}';Extended Properties=Excel 8.0;")
            MyCommand = New System.Data.OleDb.OleDbDataAdapter($"select * from [{eSheet.Name}$]", MyConnection)
            MyCommand.TableMappings.Add("Table", "Net-informations.com")
            DtSet = New System.Data.DataSet
            MyCommand.Fill(DtSet)

            If Company_ComboB.SelectedIndex = 4 Then

                progressBarStart(DtSet.Tables(0).Rows.Count)

                For row = 3 To DtSet.Tables(0).Rows.Count + 1

                    SaveNew_Employee(Company_ComboB.Text, "", eCell(row, 2).Value, eCell(row, 3).Value, eCell(row, 4).Value, "ACTIVE", True)

                    frmMainForm.AppProgressBar.Value += 1

                Next

                progressBarEnd()

            Else

                progressBarStart(DtSet.Tables(0).Rows.Count)

                For row = 3 To DtSet.Tables(0).Rows.Count + 1

                    SaveNew_Employee(Company_ComboB.Text, eCell(row, 1).value, eCell(row, 2).Value, eCell(row, 3).Value, eCell(row, 4).Value, "ACTIVE", True)

                    frmMainForm.AppProgressBar.Value += 1

                Next

                progressBarEnd()

            End If

            Lists_Employees(lvEmployee)

            Import_BTN.Enabled = False
            Path_TXT.Clear()
            MyConnection.Close()

            Excel_Panel.Visible = False
        Else
            MsgBox("Please Select Company.", MsgBoxStyle.Exclamation, "Error")
        End If

    End Sub

    Private Sub Import_BTN_Click(sender As Object, e As EventArgs) Handles Import_BTN.Click
        Excel_Panel.Visible = True
    End Sub

    Private Sub Excel_Panel_MouseMove(sender As Object, e As MouseEventArgs) Handles Excel_Panel.MouseMove
        If allowCoolMove = True Then
            Excel_Panel.Location = New Point(Excel_Panel.Location.X + e.X - myCoolPoint.X, Excel_Panel.Location.Y + e.Y - myCoolPoint.Y)
        End If
    End Sub

    Private Sub Path_TXT_TextChanged(sender As Object, e As EventArgs) Handles Path_TXT.TextChanged
        If Path_TXT.Text <> Nothing And Company_ComboB.SelectedIndex >= 0 Then
            Save_BTN.Enabled = True
        Else
            Save_BTN.Enabled = False
        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Lists_Employees(lvEmployee, txtSearch.Text)
        'ListViewGrouping(lvEmployee, 0)
    End Sub

    Private Sub txtSearch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSearch.KeyPress
        If IsEnter(e) Then btnSearch.PerformClick()
    End Sub

    Private Sub Excel_Panel_MouseDown_1(sender As Object, e As MouseEventArgs) Handles Excel_Panel.MouseDown, Add_Panel.MouseDown
        allowCoolMove = True
        myCoolPoint = New Point(e.X, e.Y)
        Cursor = Cursors.SizeAll
    End Sub

    Private Sub Excel_Panel_MouseUp_1(sender As Object, e As MouseEventArgs) Handles Excel_Panel.MouseUp, Add_Panel.MouseUp
        allowCoolMove = False
        Cursor = Cursors.Default
    End Sub

    Private Sub Add_Panel_MouseMove(sender As Object, e As MouseEventArgs) Handles Add_Panel.MouseMove
        If allowCoolMove = True Then
            Add_Panel.Location = New Point(Add_Panel.Location.X + e.X - myCoolPoint.X, Add_Panel.Location.Y + e.Y - myCoolPoint.Y)
        End If
    End Sub

    Private Sub Add_BTN_Click(sender As Object, e As EventArgs) Handles Add_BTN.Click
        Add_Panel.Visible = True
        PopulateComboBox(Branch_ComboB, "PAYROLL_EMPLOYEE", "BRANCH_CODE")
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click
        Add_Panel.Visible = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        clearAdd()
    End Sub

    Private Sub clearAdd()
        Add_Company_CB.Text = ""
        Branch_ComboB.Text = ""
        Bio_TXT.Clear()
        Fullname_TXT.Clear()
        Email_TXT.Clear()
        Add_Panel.Visible = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Add_Company_CB.Text <> "" And Branch_ComboB.Text <> "" And Branch_ComboB.Text <> "" And Bio_TXT.Text <> "" And Fullname_TXT.Text <> "" And Email_TXT.Text <> "" Then
            SaveNew_Employee(Add_Company_CB.Text, Branch_ComboB.Text, Fullname_TXT.Text, Bio_TXT.Text, Email_TXT.Text, "ACTIVE")
            clearAdd()
        Else
            MsgBox("Incomplete information.", MsgBoxStyle.Exclamation, "Error")
        End If

    End Sub

    Private Sub Bio_TXT_TextChanged(sender As Object, e As EventArgs) Handles Bio_TXT.TextChanged
        If Bio_TXT.Text <> Nothing Then
            GetFullname(Bio_TXT.Text, Add_Company_CB, Branch_ComboB, Fullname_TXT, Email_TXT, Active_RB, InActive_RB)
        Else
            Add_Company_CB.Text = ""
            Branch_ComboB.Text = ""
            Fullname_TXT.Text = ""
            Email_TXT.Text = ""
        End If
    End Sub

    Private Sub lvEmployee_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lvEmployee.MouseDoubleClick

        If lvEmployee.Items.Count = 0 Then Exit Sub

        Dim bio_No As Integer = lvEmployee.Items(lvEmployee.FocusedItem.Index).SubItems(3).Text
        Dim tmpEmp As Employee
        tmpEmp = New Employee
        tmpEmp.LoadEmployee_New(bio_No)

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
End Class