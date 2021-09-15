Imports System.Text.RegularExpressions
Imports Microsoft.Office.Interop

Public Class frmNewEmployee

    Dim emp_status As String

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
        PopulateComboBox(Branch_ComboB, "PAYROLL_EMPLOYEE", "BRANCH_CODE")
        'PopulateComboBox(Position_Combo, "PAYROLL_EMPLOYEE", "EMP_POSITION")
        PopulateComboBox_Any(Position_Combo, "PAYROLL_EMPLOYEE", "EMP_POSITION")

        For x = 0 To 23
            Dim tm As New Date(1, 1, 1, x, 0, 0)
            TimeIn_Combo.Items.Add(tm.ToShortTimeString)
            TimeOut_Combo.Items.Add(tm.ToShortTimeString)
        Next
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
        'Import_Employee_Fullname_biometric_ActiveOnly()

        'Import_Employee_DateStarted_Position()

        'Import_Employee_Benifits_Details_BY_NAME()

        Import_Employee_SBU_AMOUNT_PRINCIPAL_CREDIT()
    End Sub

    Private Sub Import_Employee_SBU_AMOUNT_PRINCIPAL_CREDIT()

        eApp = New Excel.Application
        eBook = eApp.Workbooks.Open(Path_TXT.Text)
        eSheet = eBook.Worksheets(1)
        eCell = eSheet.UsedRange

        MyConnection = New System.Data.OleDb.OleDbConnection($"provider=Microsoft.Jet.OLEDB.4.0;Data Source='{Path_TXT.Text}';Extended Properties=Excel 8.0;")
        MyCommand = New System.Data.OleDb.OleDbDataAdapter($"select * from [{eSheet.Name}$]", MyConnection)
        MyCommand.TableMappings.Add("Table", "Net-informations.com")
        DtSet = New System.Data.DataSet
        MyCommand.Fill(DtSet)

        '====================== DELETE PAYROLL_SBU TO REPLACE NEW ==================
        If isExist_String("PAYROLL_SBU", "") Then
            RunCommand($"DELETE FROM PAYROLL_SBU ;")
        End If

        progressBarStart(DtSet.Tables(0).Rows.Count + 1)

        For row = 7 To DtSet.Tables(0).Rows.Count Step 3

            Dim EMP_NO As String = ""
            Dim CATEGORY As String = ""
            Dim AMOUNT As String = ""
            Dim PRINCIPAL As String = ""
            Dim CREDIT As String = ""
            Dim BALANCE As String = ""

            If String.IsNullOrEmpty(eCell(row, 4).Value) Then

                If eCell(row - 2, 4).Value.Contains("cash") Or eCell(row - 2, 4).Value.Contains("Cashbond") Or eCell(row - 2, 4).Value.Contains("CASH") Then
                    EMP_NO = eCell(row - 3, 4).Value
                Else
                    EMP_NO = eCell(row - 2, 4).Value
                End If

                CATEGORY = eCell(row - 1, 4).Value
                AMOUNT = eCell(row - 1, 5).Value
                PRINCIPAL = eCell(row - 1, 6).Value
                CREDIT = eCell(row - 1, 8).Value
                BALANCE = eCell(row - 1, 9).Value

                Console.WriteLine("EMPTY - ROWWW -" & EMP_NO & "- " & row - 1)
            Else

                EMP_NO = eCell(row, 4).Value
                CATEGORY = eCell(row + 1, 4).Value
                AMOUNT = eCell(row + 1, 5).Value
                PRINCIPAL = eCell(row + 1, 6).Value
                CREDIT = eCell(row + 1, 8).Value
                BALANCE = eCell(row + 1, 9).Value

                Console.WriteLine("NOT EMPTY - ROWWW -" & EMP_NO & "- " & row - 1)
            End If


            If CATEGORY.Contains("CASH") Or CATEGORY.Contains("Cashbond") Or CATEGORY.Contains("cash") Then
                CATEGORY = "CASH BOND"
            ElseIf CATEGORY.Contains("Build") Then
                CATEGORY = "SBU"
            End If

            SAVE_Emp_SBU_AMOUNT_PRINCIPAL_CREDIT_NAME(EMP_NO, CATEGORY, AMOUNT, PRINCIPAL, CREDIT, BALANCE, row)

            frmMainForm.AppProgressBar.Value += 1
        Next row

        progressBarEnd()

        Path_TXT.Clear()
        MyConnection.Close()
        eApp.Quit()
        eApp.Application.DisplayAlerts = False

        Excel_Panel.Visible = False

    End Sub

    Public Function IsDate(input As String) As Boolean '======== FOR IMPORTING SBU EXCEL =====
        Dim result As DateTime
        Return DateTime.TryParse(input, result)
    End Function


    Private Sub Import_Employee_Benifits_Details_BY_NAME()

        eApp = New Excel.Application
        eBook = eApp.Workbooks.Open(Path_TXT.Text)
        eSheet = eBook.Worksheets(1)
        eCell = eSheet.UsedRange

        MyConnection = New System.Data.OleDb.OleDbConnection($"provider=Microsoft.Jet.OLEDB.4.0;Data Source='{Path_TXT.Text}';Extended Properties=Excel 8.0;")
        MyCommand = New System.Data.OleDb.OleDbDataAdapter($"select * from [{eSheet.Name}$]", MyConnection)
        MyCommand.TableMappings.Add("Table", "Net-informations.com")
        DtSet = New System.Data.DataSet
        MyCommand.Fill(DtSet)


        progressBarStart(DtSet.Tables(0).Rows.Count + 1)

        For row = 2 To DtSet.Tables(0).Rows.Count + 1

            Dim MI As String

            If String.IsNullOrEmpty(eCell(row, 4).Value) Then
                MI = ""
            Else
                MI = eCell(row, 4).Value.Substring(0, 1) & "."
            End If

            Dim fullname As String = eCell(row, 2).Value & ", " & eCell(row, 3).Value & " " & MI

            Update_Emp_Benefits_DetailS_BY_NAME(fullname, eCell(row, 9).Value, eCell(row, 10).Value, eCell(row, 11).Value, eCell(row, 12).Value, eCell(row, 6).Value, eCell(row, 8).Value, eCell(row, 1).Value)

            frmMainForm.AppProgressBar.Value += 1

        Next

        progressBarEnd()


        Lists_Employees(lvEmployee)

        Path_TXT.Clear()
        MyConnection.Close()

        Excel_Panel.Visible = False

    End Sub

    'Private Sub Import_Employee_Benifits_Details_BY_BIO()

    '    eApp = New Excel.Application
    '    eBook = eApp.Workbooks.Open(Path_TXT.Text)
    '    eSheet = eBook.Worksheets(1)
    '    eCell = eSheet.UsedRange

    '    MyConnection = New System.Data.OleDb.OleDbConnection($"provider=Microsoft.Jet.OLEDB.4.0;Data Source='{Path_TXT.Text}';Extended Properties=Excel 8.0;")
    '    MyCommand = New System.Data.OleDb.OleDbDataAdapter($"select * from [{eSheet.Name}$]", MyConnection)
    '    MyCommand.TableMappings.Add("Table", "Net-informations.com")
    '    DtSet = New System.Data.DataSet
    '    MyCommand.Fill(DtSet)


    '    progressBarStart(DtSet.Tables(0).Rows.Count + 1)

    '    For row = 1 To DtSet.Tables(0).Rows.Count + 1

    '        Update_Emp_Benefits_Details(eCell(row, 5).Value, eCell(row, 9).Value, eCell(row, 10).Value, eCell(row, 11).Value, eCell(row, 12).Value, eCell(row, 6).Value, eCell(row, 8).Value, eCell(row, 1).Value)

    '        frmMainForm.AppProgressBar.Value += 1

    '    Next

    '    progressBarEnd()


    '    Lists_Employees(lvEmployee)

    '    Path_TXT.Clear()
    '    MyConnection.Close()

    '    Excel_Panel.Visible = False

    'End Sub

    Private Sub Import_Employee_DateStarted_Position()
        eApp = New Excel.Application
        eBook = eApp.Workbooks.Open(Path_TXT.Text)
        eSheet = eBook.Worksheets(1)
        eCell = eSheet.UsedRange

        MyConnection = New System.Data.OleDb.OleDbConnection($"provider=Microsoft.Jet.OLEDB.4.0;Data Source='{Path_TXT.Text}';Extended Properties=Excel 8.0;")
        MyCommand = New System.Data.OleDb.OleDbDataAdapter($"select * from [{eSheet.Name}$]", MyConnection)
        MyCommand.TableMappings.Add("Table", "Net-informations.com")
        DtSet = New System.Data.DataSet
        MyCommand.Fill(DtSet)


        progressBarStart(DtSet.Tables(0).Rows.Count + 1)

        For row = 1 To DtSet.Tables(0).Rows.Count + 1

            Update_Emp_DateHired_Position(eCell(row, 2).Value, eCell(row, 4).Value, eCell(row, 5).Value, eCell(row, 3).Value, eCell(row, 1).Value)

            frmMainForm.AppProgressBar.Value += 1

        Next

        progressBarEnd()


        Lists_Employees(lvEmployee)

        Path_TXT.Clear()
        MyConnection.Close()

        Excel_Panel.Visible = False

    End Sub

    Private Sub Import_Employee_Fullname_biometric_ActiveOnly()
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

            Path_TXT.Clear()
            MyConnection.Close()

            Excel_Panel.Visible = False
        Else
            MsgBox("Please Select Company.", MsgBoxStyle.Exclamation, "Error")
        End If

    End Sub

    Private Sub Import_BTN_Click(sender As Object, e As EventArgs) Handles Import_BTN.Click
        Excel_Panel.Location = New Point(ClientSize.Width / 2 - Excel_Panel.Size.Width / 2, ClientSize.Height / 2 - Excel_Panel.Size.Height / 2)
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
        Add_Panel.Location = New Point(ClientSize.Width / 2 - Add_Panel.Size.Width / 2, ClientSize.Height / 2 - Add_Panel.Size.Height / 2)
        Add_Panel.Visible = True
        PopulateComboBox(Branch_ComboB, "PAYROLL_EMPLOYEE", "BRANCH_CODE")
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click
        Add_Panel.Visible = False
        clearAdd()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        clearAdd()
    End Sub

    Private Sub clearAdd()
        Bio_TXT.Clear()
        Add_Company_CB.Text = ""
        HO_Category.Text = ""
        ComCategory_Combo.Text = ""
        Branch_ComboB.Text = ""
        Started_DTP.Text = "1/1/2000"
        EmpNo_TXT.Clear()
        Position_Combo.Text = ""
        TimeIn_Combo.Text = ""
        TimeOut_Combo.Text = ""
        Fullname_TXT.Clear()
        Email_TXT.Clear()
        TIN_TXT.Clear()
        SSS_TXT.Clear()
        PHILH_TXT.Clear()
        HDMF_TXT.Clear()
        Active_RB.Checked = True
        Add_Panel.Visible = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If Not isValidSave() Then Exit Sub

        If Active_RB.Checked = True Then
            emp_status = Active_RB.Text
        Else
            emp_status = InActive_RB.Text
        End If

        SaveNew_Employee(Add_Company_CB.Text, Branch_ComboB.Text, Fullname_TXT.Text, Bio_TXT.Text, Email_TXT.Text, emp_status, Started_DTP.Value, False,
                         TimeIn_Combo.Text, TimeOut_Combo.Text, EmpNo_TXT.Text, TIN_TXT.Text, SSS_TXT.Text, PHILH_TXT.Text, HDMF_TXT.Text, HO_Category.Text,
                         ComCategory_Combo.Text, Position_Combo.Text, ComCompany_Cmbo.Text)

        Lists_Employees(lvEmployee)

        clearAdd()

    End Sub

    Private Function isValidSave()

        Dim FoundMatch As Boolean = Regex.IsMatch(Email_TXT.Text, "\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase)

        If String.IsNullOrEmpty(Bio_TXT.Text) Then
            MsgBox("Biometric ID must not be empty!", MsgBoxStyle.Exclamation, "Error")
            Return False

        ElseIf String.IsNullOrEmpty(Add_Company_CB.Text) Then
            MsgBox("Please Select Company!", MsgBoxStyle.Exclamation, "Error")
            Return False

        ElseIf HO_Category.Visible = True And String.IsNullOrEmpty(HO_Category.Text) Then
            MsgBox("Please Select HO Category!", MsgBoxStyle.Exclamation, "Error")
            Return False

        ElseIf ComCategory_Combo.Visible = True And String.IsNullOrEmpty(ComCategory_Combo.Text) Then
            MsgBox("Please Select Common Category!", MsgBoxStyle.Exclamation, "Error")
            Return False

        ElseIf ComCompany_Cmbo.Visible = True And String.IsNullOrEmpty(ComCompany_Cmbo.Text) Then
            MsgBox("Please Select Common Company!", MsgBoxStyle.Exclamation, "Error")
            Return False

        ElseIf String.IsNullOrEmpty(Branch_ComboB.Text) And Add_Company_CB.Text <> "HEAD OFFICE" Then
            MsgBox("Please Select Branch!", MsgBoxStyle.Exclamation, "Error")
            Return False

        ElseIf Started_DTP.Value = "1/1/2000" Then
            MsgBox("Please Indicate Date Started!", MsgBoxStyle.Exclamation, "Error")
            Return False

        ElseIf String.IsNullOrEmpty(EmpNo_TXT.Text) Then
            MsgBox("Please Indicate Employee Number!", MsgBoxStyle.Exclamation, "Error")
            Return False

        ElseIf String.IsNullOrEmpty(TimeIn_Combo.Text) Then
            MsgBox("Please Select Time In!", MsgBoxStyle.Exclamation, "Error")
            Return False

        ElseIf String.IsNullOrEmpty(TimeOut_Combo.Text) Then
            MsgBox("Please Select Time Out!", MsgBoxStyle.Exclamation, "Error")
            Return False

        ElseIf String.IsNullOrEmpty(Fullname_TXT.Text) Then
            MsgBox("Please Indicate Employee's Fullname!", MsgBoxStyle.Exclamation, "Error")
            Return False

        ElseIf String.IsNullOrEmpty(Email_TXT.Text) Then
            MsgBox("Please Indicate Employee's Email!", MsgBoxStyle.Exclamation, "Error")
            Return False

        ElseIf Not FoundMatch Then
            Email_TXT.Region = New Region(New Rectangle(2, 2, Email_TXT.Width - 4, Email_TXT.Height - 4))
            MsgBox("Invalid Email Address!", MsgBoxStyle.Exclamation, "Error")
            Return False

        End If

        Return True
    End Function


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

        ElseIf txtSearch.Tag = "Attendance-7Eleven" Then

            SwitchForm_Attendance(FormName.Attendance, tmpEmp, 4)
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

        ElseIf txtSearch.Tag = "Settings-TimeInOUt" Then

            SwitchForm_Settings(FormName.Settings, tmpEmp, "TIMEIN/OUT")
            Close()

        ElseIf txtSearch.Tag = "SSS Loan" Then

            SwitchForm_Loans(FormName.Loans, tmpEmp, "SSS")
            Close()

        ElseIf txtSearch.Tag = "Pagibig Loan" Then

            SwitchForm_Loans(FormName.Loans, tmpEmp, "PAGIBIG")
            Close()

        End If

    End Sub

    Private Sub Started_DTP_CloseUp(sender As Object, e As EventArgs) Handles Started_DTP.CloseUp
        If Not Started_DTP.Value = "1/1/2000" Then

            Dim dateStarted As DateTime = Started_DTP.Value

            Dim year As String = dateStarted.ToString("yy")
            Dim month As String = dateStarted.ToString("MM")

            EmpNo_TXT.Text = year & "-0" & month & "-" & Bio_TXT.Text

        End If
    End Sub


    Private Sub Started_DTP_ValueChanged(sender As Object, e As EventArgs) Handles Started_DTP.ValueChanged
        If Started_DTP.Value <> "1/1/2000" Then
            sender.Region = Nothing
        End If
    End Sub

    Private Sub TIN_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TIN_TXT.KeyPress, SSS_TXT.KeyPress, PHILH_TXT.KeyPress, HDMF_TXT.KeyPress

        If e.KeyChar <> ChrW(Keys.Back) Then

            If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso Not e.KeyChar = "-" Then
                e.Handled = True
            End If
        End If

    End Sub

    Private Sub Add_Company_CB_TextChanged(sender As Object, e As EventArgs) Handles TimeOut_Combo.TextChanged, TimeIn_Combo.TextChanged, Fullname_TXT.TextChanged, EmpNo_TXT.TextChanged, Email_TXT.TextChanged

        If sender.Text = "" Then
            sender.Region = New Region(New Rectangle(2, 2, sender.Width - 4, sender.Height - 4))
        Else
            sender.Region = Nothing
        End If

    End Sub

    Private Sub Bio_TXT_TextChanged_1(sender As Object, e As EventArgs) Handles Bio_TXT.TextChanged

        If Bio_TXT.Text <> Nothing Then
            GetFullname(Bio_TXT.Text, Add_Company_CB, Branch_ComboB, Fullname_TXT, Email_TXT, InActive_RB,
                            Started_DTP, TimeIn_Combo, TimeOut_Combo, EmpNo_TXT, TIN_TXT, SSS_TXT, PHILH_TXT, HDMF_TXT, HO_Category,
                            ComCategory_Combo, Position_Combo, ComCompany_Cmbo)

        Else
            Add_Company_CB.Text = ""
            HO_Category.Text = ""
            ComCategory_Combo.Text = ""
            ComCompany_Cmbo.Text = ""
            Branch_ComboB.Text = ""
            Started_DTP.Value = "1/1/2000"
            Fullname_TXT.Text = ""
            Email_TXT.Text = ""
            Position_Combo.Text = ""
            TimeIn_Combo.Text = ""
            TimeOut_Combo.Text = ""
            EmpNo_TXT.Text = ""
            TIN_TXT.Text = ""
            SSS_TXT.Text = ""
            PHILH_TXT.Text = ""
            HDMF_TXT.Text = ""
            Active_RB.Checked = True
        End If

    End Sub


    Private Sub HO_Category_SelectedValueChanged(sender As Object, e As EventArgs) Handles HO_Category.SelectedValueChanged

        ComCategory_Combo.Text = ""

        If HO_Category.SelectedItem = "PGC Head Office" Or HO_Category.SelectedItem = "Construction" Or HO_Category.SelectedItem = "Leasing Admin Office" Then
            Label20.Visible = True
            ComCategory_Combo.Visible = True

            Label23.Visible = True
            ComCompany_Cmbo.Visible = True
        Else
            Label20.Visible = False
            ComCategory_Combo.Visible = False

            Label23.Visible = False
            ComCompany_Cmbo.Visible = False
        End If
    End Sub

    'Private Sub FlowLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles FlowLayoutPanel1.Paint
    '    If Bio_TXT.Text = Nothing Then
    '        Dim textbox As TextBox = Nothing
    '        Dim combo As ComboBox = Nothing
    '        Dim datepicker As DateTimePicker = Nothing
    '        For Each xObject As Object In FlowLayoutPanel1.Controls
    '            If TypeOf xObject Is TextBox Then
    '                textbox = xObject
    '                Dim p As New Pen(Color.Red, 2)
    '                e.Graphics.DrawRectangle(p, New Rectangle(textbox.Location + New Size(1, 1), textbox.Size - New Size(2, 2)))
    '                p.Dispose()
    '            ElseIf TypeOf xObject Is ComboBox Then
    '                If xObject.visible = True Then
    '                    combo = xObject
    '                    Dim p As New Pen(Color.Red, 2)
    '                    e.Graphics.DrawRectangle(p, New Rectangle(combo.Location + New Size(1, 1), combo.Size - New Size(2, 2)))
    '                    p.Dispose()
    '                End If
    '            ElseIf TypeOf xObject Is DateTimePicker Then
    '                datepicker = xObject
    '                Dim p As New Pen(Color.Red, 2)
    '                e.Graphics.DrawRectangle(p, New Rectangle(datepicker.Location + New Size(1, 1), datepicker.Size - New Size(2, 2)))
    '                p.Dispose()
    '            End If
    '        Next
    '    End If
    'End Sub


    Private Sub Add_Company_CB_TextChanged_1(sender As Object, e As EventArgs) Handles Position_Combo.TextChanged, HO_Category.TextChanged, ComCategory_Combo.TextChanged, Branch_ComboB.TextChanged, Add_Company_CB.TextChanged
        Dim selectionStart As Integer = sender.SelectionStart

        sender.Text = sender.Text.ToUpper()
        sender.SelectionStart = selectionStart


        If Add_Company_CB.SelectedItem <> "HEAD OFFICE" Then
            Label4.Visible = True
            Branch_ComboB.Visible = True

            Label19.Visible = False
            HO_Category.Visible = False
            HO_Category.Text = ""

            Label20.Visible = False
            ComCategory_Combo.Visible = False
            ComCategory_Combo.Text = ""

            Label23.Visible = False
            ComCompany_Cmbo.Visible = False
            ComCompany_Cmbo.Text = ""
        Else
            Label4.Visible = False
            Branch_ComboB.Visible = False

            Label19.Visible = True
            HO_Category.Visible = True
        End If

    End Sub

    Private Sub lvEmployee_MouseClick(sender As Object, e As MouseEventArgs) Handles lvEmployee.MouseClick
        If e.Button = MouseButtons.Right Then
            If lvEmployee.Items.Count > 0 Then
                Context_Details.Show(lvEmployee, New Point(e.X, e.Y))
            End If
        End If
    End Sub

    Private Sub View_Menu_Click(sender As Object, e As EventArgs) Handles View_Menu.Click

        Dim bio_No As Integer = lvEmployee.Items(lvEmployee.FocusedItem.Index).SubItems(3).Text

        Bio_TXT.Text = bio_No
        GetFullname(bio_No, Add_Company_CB, Branch_ComboB, Fullname_TXT, Email_TXT, InActive_RB, Started_DTP,
                    TimeIn_Combo, TimeOut_Combo, EmpNo_TXT, TIN_TXT, SSS_TXT, PHILH_TXT, HDMF_TXT, HO_Category,
                    ComCategory_Combo, Position_Combo, ComCompany_Cmbo)

        Add_Panel.Location = New Point(ClientSize.Width / 2 - Add_Panel.Size.Width / 2, ClientSize.Height / 2 - Add_Panel.Size.Height / 2)
        Add_Panel.Visible = True

    End Sub
End Class