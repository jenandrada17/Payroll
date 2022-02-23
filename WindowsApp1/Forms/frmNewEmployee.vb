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

        Import_Employee_New()

        'Import_BranchesName()

        'Import_Employee_Fullname_biometric_ActiveOnly()

        'Import_Employee_DateStarted_Position()

        'Import_Employee_Benifits_Details_BY_NAME()

        'Import_Employee_SBU_AMOUNT_PRINCIPAL_CREDIT()

        'Import_13MONTH()

        'Import_Employee_DEDUCTION_2()

        'Import_Deduction() ''===== NAKACOMMENT ANG METHOD

    End Sub


    Private Sub Import_Employee_New()

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

        progressBarStart(DtSet.Tables(0).Rows.Count)

        For row = 2 To DtSet.Tables(0).Rows.Count + 1

            'Public Sub SaveNew_Employee(COMPANY As String, BRANCH_CODE As String, FULLNAME As String, BIO_NO As String, EMAIL_ADD As String,
            '                EMP_STATUS As String, Optional DATE_STARTED As String = "", Optional group As Boolean = False,
            '                Optional TIME_IN As String = "", Optional TIME_OUT As String = "", Optional EMP_NO As String = "",
            '                Optional TIN As String = "", Optional SSS As String = "", Optional PHILH As String = "",
            '                Optional HDMF As String = "", Optional HO_CATEGORY As String = "", Optional COMMON_CATEGORY As String = "",
            '                Optional EMP_POSITION As String = "", Optional COMMON_COMPANY As String = "", Optional PhotoCategory As String = "")

            SaveNew_Employee(eCell(row, 2).Value, eCell(row, 3).Value, eCell(row, 9).Value, eCell(row, 1).Value, eCell(row, 10).Value,
                             "ACTIVE", eCell(row, 4).Value, True, eCell(row, 7).Value, eCell(row, 8).Value, eCell(row, 5).Value,
                             eCell(row, 11).Value, eCell(row, 12).Value, eCell(row, 13).Value, eCell(row, 14).Value, "", "", eCell(row, 6).Value, "", eCell(row, 15).Value)

            frmMainForm.AppProgressBar.Value += 1

        Next

        progressBarEnd()

        Lists_Employees(lvEmployee)

        Path_TXT.Clear()
        MyConnection.Close()

        Excel_Panel.Visible = False

    End Sub


    Private Sub Import_Employee_DEDUCTION_2()

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
        If isExist_String("PAYROLL_DEDUCTION", "") Then
            RunCommand($"DELETE FROM PAYROLL_DEDUCTION ;")
        End If

        '====================== DELETE PAYROLL_SBU TO REPLACE NEW ==================
        If isExist_String("PAYROLL_LOANS", "") Then
            RunCommand($"DELETE FROM PAYROLL_LOANS ;")
        End If

        progressBarStart(DtSet.Tables(0).Rows.Count + 1)

        For row = 4 To DtSet.Tables(0).Rows.Count

            Dim EMP_NO As String = ""
            Dim CATEGORY As String = ""
            Dim AMOUNT As String = ""
            Dim PRINCIPAL As String = ""
            Dim DATEE As String = ""
            Dim CREDIT As String = ""
            Dim BALANCE As String = ""

            If eCell(row, 1).Font.Bold = True Then
                EMP_NO = eCell(row, 4).Value
                SAVE_EmpNo_Deduction_EXCEL(EMP_NO, row)
            End If

            If IsDate(eCell(row, 1).value) Then
                Dim IF_SBU As String = eCell(row, 3).value

                If IF_SBU.TrimEnd <> "SBU(Savings Build Up)" Then
                    DATEE = eCell(row, 1).Value
                    CATEGORY = eCell(row, 4).Value
                    AMOUNT = eCell(row, 5).Value
                    PRINCIPAL = eCell(row, 6).Value
                    CREDIT = IIf(eCell(row, 8).Value = Nothing, 0, eCell(row, 8).Value)
                    BALANCE = eCell(row, 9).Value

                    If (CATEGORY.Contains("LOAN") Or CATEGORY.Contains("Loan") Or CATEGORY.Contains("loan")) And Not CATEGORY.Contains("Car") Then

                        If CATEGORY.Contains("PAG-IBIG") Or CATEGORY.Contains("HDMF") Then
                            CATEGORY = "PAG-IBIG"
                        Else
                            CATEGORY = "SSS"
                        End If

                        SAVE_LOANS_EXCEL(CATEGORY, AMOUNT, PRINCIPAL, CREDIT, BALANCE, DATEE, row)
                    Else
                        SAVE_Deduction_EXCEL(CATEGORY, AMOUNT, PRINCIPAL, CREDIT, BALANCE, DATEE, row)
                    End If

                End If

            End If

            frmMainForm.AppProgressBar.Value += 1
        Next row

        progressBarEnd()

        RunCommand($"DELETE FROM PAYROLL_DEDUCTION WHERE CATEGORY is null;")

        Path_TXT.Clear()
        MyConnection.Close()
        eApp.Quit()
        eApp.Application.DisplayAlerts = False

        Excel_Panel.Visible = False

    End Sub

    'Private Sub Import_Deduction()

    '    eApp = New Excel.Application
    '    eBook = eApp.Workbooks.Open(Path_TXT.Text)
    '    eSheet = eBook.Worksheets(1)
    '    eCell = eSheet.UsedRange

    '    MyConnection = New System.Data.OleDb.OleDbConnection($"provider=Microsoft.Jet.OLEDB.4.0;Data Source='{Path_TXT.Text}';Extended Properties=Excel 8.0;")
    '    MyCommand = New System.Data.OleDb.OleDbDataAdapter($"select * from [{eSheet.Name}$]", MyConnection)
    '    MyCommand.TableMappings.Add("Table", "Net-informations.com")
    '    DtSet = New System.Data.DataSet
    '    MyCommand.Fill(DtSet)

    '    '====================== DELETE PAYROLL_SBU TO REPLACE NEW ==================
    '    If isExist_String("PAYROLL_DEDUCTION", "") Then
    '        RunCommand($"DELETE FROM PAYROLL_DEDUCTION;")
    '    End If

    '    progressBarStart(DtSet.Tables(0).Rows.Count + 1)

    '    For row = 1 To DtSet.Tables(0).Rows.Count

    '        Dim EMP_NO As String = ""
    '        Dim CATEGORY As String = ""
    '        Dim PRINCIPAL As Decimal = 0
    '        Dim AMOUNT As Decimal = 0

    '        Dim NUM As String = eCell(row, 1).value

    '        If eCell(row, 1).value = "NO.    : " Then
    '            EMP_NO = eCell(row, 2).Value
    '            SAVE_Emp_Deduction_EXCEL(EMP_NO, row)
    '        End If

    '        If Not IsNumeric(eCell(row, 2).value) And IsNumeric(eCell(row, 3).value) And IsNumeric(eCell(row, 4).value) Then

    '            If eCell(row, 4).value <> 0 Then
    '                CATEGORY = eCell(row, 2).Value
    '                AMOUNT = eCell(row, 3).Value
    '                PRINCIPAL = eCell(row, 4).Value
    '                UPDATE_Emp_Dedeuction_EXCEL(CATEGORY, AMOUNT, PRINCIPAL, row)


    '                Console.WriteLine("EMP_NO " & EMP_NO)
    '            End If

    '        End If

    '        frmMainForm.AppProgressBar.Value += 1

    '    Next row

    '    progressBarEnd()

    '    Path_TXT.Clear()
    '    MyConnection.Close()
    '    eApp.Quit()
    '    eApp.Application.DisplayAlerts = False

    '    Excel_Panel.Visible = False

    'End Sub 

    Private Sub Import_13MONTH()

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
        'If isExist_String("PAYROLL_13MONTH", "") Then
        '    RunCommand($"DELETE FROM PAYROLL_13MONTH ;")
        'End If

        progressBarStart(DtSet.Tables(0).Rows.Count + 1)

        For row = 1 To DtSet.Tables(0).Rows.Count


            If Not String.IsNullOrEmpty(eCell(row, 1).Value) Then
                If Not IsDate(eCell(row, 1).Value) Then
                    If eCell(row, 1).Value.Contains("EMPLOYEE NO.:") Then
                        Dim EMP_NO As String = eCell(row, 2).Value
                        SAVE_13MONTH_EMPNO(EMP_NO, row)
                    End If
                End If

            End If

            Dim val As Double
            If String.IsNullOrEmpty(eCell(row, 3).Value) Or Double.TryParse(eCell(row, 3).Value, val) Then
                Continue For
            Else
                If eCell(row, 3).Value = "13TH MONTH PAY" Then
                    Dim AMOUNT As Decimal = eCell(row, 5).Value
                    SAVE_13MONTH_AMOUNT(AMOUNT, row)
                End If
            End If

            frmMainForm.AppProgressBar.Value += 1
        Next row

        progressBarEnd()

        Path_TXT.Clear()
        MyConnection.Close()
        eApp.Quit()
        eApp.Application.DisplayAlerts = False

        Excel_Panel.Visible = False

        Dim mysql As String = $"Select * From payroll_payout A 
                                inner join payroll_employee B on B.BIO_NO = A.BIOMETRIC_ID 
                                inner Join payroll_13month C on B.EMP_NO = B.EMP_NO where C.EMP_NO = B.EMP_NO"

        Using ds As DataSet = LoadSQL(mysql, "payroll_payout")
            For Each dr In ds.Tables(0).Rows()
                With dr
                    Save_Recorded_Allow_Deduc_13month(.item("BIO_NO"), "12/15/2021", "13th Month Pay", .item("AMOUNT"), "ALLOWANCE")
                    UPDATENETPAY(.item("BIO_NO"), "12/15/2021", .item("AMOUNT"))
                End With
            Next
        End Using
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
            'RunCommand($"DELETE FROM PAYROLL_SBU A INNER JOIN PAYROLL_EMPLOYEE B ON A.BIO_NO = B.BIO_NO WHERE B.BIO_NO <> 'HEAD OFFICE' ;")
        End If

        progressBarStart(DtSet.Tables(0).Rows.Count + 1)

        For row = 7 To DtSet.Tables(0).Rows.Count

            Dim EMP_NO As String = ""
            Dim CATEGORY As String = ""
            Dim AMOUNT As String = ""
            Dim PRINCIPAL As String = ""
            Dim CREDIT As String = ""
            Dim BALANCE As String = ""

            If eCell(row, 1).Font.Bold = True Then
                EMP_NO = eCell(row, 4).Value
                SAVE_Emp_SBU_EXCEL(EMP_NO, row)
            End If

            If IsDate(eCell(row, 1).value) Then
                CATEGORY = eCell(row, 4).Value
                AMOUNT = eCell(row, 5).Value
                PRINCIPAL = eCell(row, 6).Value
                CREDIT = eCell(row, 8).Value
                BALANCE = eCell(row, 9).Value
                UPDATE_Emp_SBU_EXCEL(CATEGORY, AMOUNT, PRINCIPAL, CREDIT, BALANCE, row)
            End If

            frmMainForm.AppProgressBar.Value += 1
        Next row

        RunCommand($"UPDATE PAYROLL_SBU SET CATEGORY = 'SBU';")

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

    Private Sub Import_BranchesName()

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


        progressBarStart(DtSet.Tables(0).Rows.Count)

        For row = 1 To DtSet.Tables(0).Rows.Count

            Save_BranchesName(eCell(row, 1).Value, eCell(row, 2).Value)

            frmMainForm.AppProgressBar.Value += 1

        Next

        progressBarEnd()

        Path_TXT.Clear()
        MyConnection.Close()

        Excel_Panel.Visible = False

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
        FirstName_TXT.Clear()
        Email_TXT.Clear()
        TIN_TXT.Clear()
        SSS_TXT.Clear()
        PHILH_TXT.Clear()
        HDMF_TXT.Clear()
        Active_RB.Checked = True
        Add_Panel.Visible = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If Not isValidSave() Then Exit Sub

        Dim result As DialogResult = MsgBox($"Details for {FirstName_TXT.Text} will be Saved/Updated, proceed anyway?", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then

            Dim stat As String ' User Logs

            If Active_RB.Checked = True Then
                emp_status = Active_RB.Text
                stat = "Active"
            Else
                emp_status = InActive_RB.Text
                stat = "Inactive"
            End If

            Dim fullname As String

            If String.IsNullOrEmpty(MName_txt.Text) Then
                fullname = $"{LastName_txt.Text}, {FirstName_TXT.Text} "
            Else
                fullname = $"{LastName_txt.Text}, {FirstName_TXT.Text} {MName_txt.Text.Substring(0, 1)}."
            End If

            SaveNew_Employee(Add_Company_CB.Text, Branch_ComboB.Text, fullname, Bio_TXT.Text, Email_TXT.Text, emp_status, Started_DTP.Value, False,
                         TimeIn_Combo.Text, TimeOut_Combo.Text, EmpNo_TXT.Text, TIN_TXT.Text, SSS_TXT.Text, PHILH_TXT.Text, HDMF_TXT.Text, HO_Category.Text,
                         ComCategory_Combo.Text, Position_Combo.Text, ComCompany_Cmbo.Text, PhotoCategory_Combo.Text, MName_txt.Text, BDate_dtp.Value, Address_txt.Text)

            If Emp_Pic.Image IsNot Nothing Then
                SavePic(Bio_TXT.Text, SaveProfilePic(Emp_Pic.Image))
            End If

            If btnSave.Tag = "UPDATE" Then
                SaveLogs($"EDITED EMPLOYEE - Name({FirstName_TXT.Text}({Bio_TXT.Text})), Company({Add_Company_CB.Text}), Branch({Branch_ComboB.Text}), Email({Email_TXT.Text}), Status({stat}), Started({Started_DTP.Value.ToShortDateString}), Time in/out({TimeIn_Combo.Text}/{TimeOut_Combo.Text}), Emp No.({EmpNo_TXT.Text}), TIN({TIN_TXT.Text}), SSS({SSS_TXT.Text}), Philhealth({PHILH_TXT.Text}), Pagibig({HDMF_TXT.Text}), Position({Position_Combo.Text}), HO({HO_Category.Text}, {ComCategory_Combo.Text}, {ComCompany_Cmbo.Text})",
                     frmMainForm.UserName_LBL.Text)
            Else
                SaveLogs($"ADDED EMPLOYEE - Name({FirstName_TXT.Text}({Bio_TXT.Text})), Company({Add_Company_CB.Text}), Branch({Branch_ComboB.Text}), Email({Email_TXT.Text}), Status({stat}), Started({Started_DTP.Value.ToShortDateString}), Time in/out({TimeIn_Combo.Text}/{TimeOut_Combo.Text}), Emp No.({EmpNo_TXT.Text}), TIN({TIN_TXT.Text}), SSS({SSS_TXT.Text}), Philhealth({PHILH_TXT.Text}), Pagibig({HDMF_TXT.Text}), Position({Position_Combo.Text}), HO({HO_Category.Text}, {ComCategory_Combo.Text}, {ComCompany_Cmbo.Text})",
                     frmMainForm.UserName_LBL.Text)
            End If

            Lists_Employees(lvEmployee)

            clearAdd()
        End If

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

        ElseIf String.IsNullOrEmpty(FirstName_TXT.Text) Then
            MsgBox("Please Indicate Employee's First Name!", MsgBoxStyle.Exclamation, "Error")
            Return False

        ElseIf String.IsNullOrEmpty(LastName_txt.Text) Then
            MsgBox("Please Indicate Employee's Last Name!", MsgBoxStyle.Exclamation, "Error")
            Return False

        ElseIf BDate_dtp.Value = "12/31/1753" Then
            MsgBox("Please Indicate Birth Date!", MsgBoxStyle.Exclamation, "Error")
            Return False

        ElseIf String.IsNullOrEmpty(Address_txt.Text) Then
            MsgBox("Please Indicate Employee's Adress!", MsgBoxStyle.Exclamation, "Error")
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

        ElseIf txtSearch.Tag = "Attendance-Scheduling" Then

            SwitchForm_Attendance(FormName.Attendance, tmpEmp, 5)
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

        ElseIf txtSearch.Tag = "Allowance" Then

            SwitchForm_Allowance(FormName.Allowance, tmpEmp, "ALLOWANCE")
            Close()

        ElseIf txtSearch.Tag = "Allowance-Form" Then

            SwitchForm_Allowance(FormName.Allowance, tmpEmp, "FORM")
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

        ElseIf txtSearch.Tag = "Loan-Deduction" Then

            SwitchForm_Loans(FormName.Loans, tmpEmp, "DEDUCTION")
            Close()

        ElseIf txtSearch.Tag = "Loan-Mp2" Then

            SwitchForm_Loans(FormName.Loans, tmpEmp, "MP2")
            Close()

        ElseIf txtSearch.Tag = "Loan-Maxicare" Then

            SwitchForm_Loans(FormName.Loans, tmpEmp, "MAXICARE")
            Close()

        ElseIf txtSearch.Tag = "Scheduling" Then

            SwitchForm_Scheduling(FormName.Schedule, tmpEmp)
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

    Private Sub Add_Company_CB_TextChanged(sender As Object, e As EventArgs) Handles TimeOut_Combo.TextChanged, TimeIn_Combo.TextChanged, FirstName_TXT.TextChanged, EmpNo_TXT.TextChanged, Email_TXT.TextChanged

        If sender.Text = "" Then
            sender.Region = New Region(New Rectangle(2, 2, sender.Width - 4, sender.Height - 4))
        Else
            sender.Region = Nothing
        End If

    End Sub

    Private Sub Bio_TXT_TextChanged_1(sender As Object, e As EventArgs) Handles Bio_TXT.TextChanged

        If Bio_TXT.Text <> Nothing Then
            GetFullname(Bio_TXT.Text, Add_Company_CB, Branch_ComboB, FirstName_TXT, Email_TXT, InActive_RB,
                            Started_DTP, TimeIn_Combo, TimeOut_Combo, EmpNo_TXT, TIN_TXT, SSS_TXT, PHILH_TXT, HDMF_TXT, HO_Category, ComCategory_Combo,
                            Position_Combo, ComCompany_Cmbo, PhotoCategory_Combo, LastName_txt, MName_txt, BDate_dtp, Address_txt, btnSave)

            GetPic(Bio_TXT.Text, Emp_Pic)
        Else
            Add_Company_CB.Text = ""
            HO_Category.Text = ""
            PhotoCategory_Combo.Text = ""
            ComCategory_Combo.Text = ""
            ComCompany_Cmbo.Text = ""
            Branch_ComboB.Text = ""
            Started_DTP.Value = "1/1/2000"
            FirstName_TXT.Text = ""
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
            BDate_dtp.Value = "12/31/1753"
            Address_txt.Text = ""
            Emp_Pic.Image = Nothing
        End If

    End Sub


    Private Sub HO_Category_SelectedValueChanged(sender As Object, e As EventArgs) Handles HO_Category.SelectedValueChanged

        ComCategory_Combo.Text = ""

        'If HO_Category.SelectedIndex = 12 Or HO_Category.SelectedIndex = 10 Or HO_Category.SelectedIndex = 11 Then

        If HO_Category.SelectedIndex = 12 Then '================ PGC COMMON EMPLOYESS
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

    'Private Sub Add_Company_CB_TextChanged_1(sender As Object, e As EventArgs) Handles Position_Combo.TextChanged, HO_Category.TextChanged, ComCategory_Combo.TextChanged, Branch_ComboB.TextChanged, Add_Company_CB.TextChanged
    Private Sub Add_Company_CB_TextChanged_1(sender As Object, e As EventArgs) Handles Add_Company_CB.TextChanged

        If Add_Company_CB.SelectedIndex = 4 Then

            Label4.Visible = False
            Branch_ComboB.Text = ""
            Branch_ComboB.Visible = False

            Label24.Visible = False
            PhotoCategory_Combo.Visible = False
            PhotoCategory_Combo.Text = ""

            Label19.Visible = True
            HO_Category.Visible = True


        ElseIf Add_Company_CB.SelectedIndex = 0 Then

            Label19.Visible = False
            HO_Category.Visible = False
            HO_Category.Text = ""

            Label20.Visible = False
            ComCategory_Combo.Visible = False
            ComCategory_Combo.Text = ""

            Label23.Visible = False
            ComCompany_Cmbo.Visible = False
            ComCompany_Cmbo.Text = ""

            Label24.Visible = True
            PhotoCategory_Combo.Visible = True

            Label4.Visible = True
            Branch_ComboB.Visible = True

        Else

            Label4.Visible = True
            Branch_ComboB.Visible = True

            Label19.Visible = False
            HO_Category.Visible = False
            HO_Category.Text = ""

            Label24.Visible = False
            PhotoCategory_Combo.Visible = False
            PhotoCategory_Combo.Text = ""

            Label20.Visible = False
            ComCategory_Combo.Visible = False
            ComCategory_Combo.Text = ""

            Label23.Visible = False
            ComCompany_Cmbo.Visible = False
            ComCompany_Cmbo.Text = ""

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
        GetFullname(bio_No, Add_Company_CB, Branch_ComboB, FirstName_TXT, Email_TXT, InActive_RB, Started_DTP,
                    TimeIn_Combo, TimeOut_Combo, EmpNo_TXT, TIN_TXT, SSS_TXT, PHILH_TXT, HDMF_TXT, HO_Category,
                    ComCategory_Combo, Position_Combo, ComCompany_Cmbo, PhotoCategory_Combo, LastName_txt, MName_txt,
                    BDate_dtp, Address_txt, btnSave)

        Add_Panel.Location = New Point(ClientSize.Width / 2 - Add_Panel.Size.Width / 2, ClientSize.Height / 2 - Add_Panel.Size.Height / 2)
        Add_Panel.Visible = True
    End Sub

    Private Sub Clear_btn_Click(sender As Object, e As EventArgs) Handles Clear_btn.Click
        Dim result As DialogResult = MsgBox("Are you sure?", MsgBoxStyle.YesNo)
        If result = DialogResult.Yes Then
            clearAdd()
        End If
    End Sub

    Private Sub ImportPic_btn_Click(sender As Object, e As EventArgs) Handles ImportPic_btn.Click
        Using dlg As New OpenFileDialog()
            dlg.Title = "Open Image"
            dlg.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG"

            If dlg.ShowDialog = DialogResult.OK Then
                Emp_Pic.Image = New Bitmap(dlg.FileName)
                Emp_Pic.SizeMode = PictureBoxSizeMode.StretchImage
            End If
        End Using
    End Sub

End Class