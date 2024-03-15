Imports System.Globalization
Imports DBConnect

Public Class frmMainForm

    Public DateNow As DateTime = DateTime.Now
    Public StartFour, EndFour, StartNineteen, EndNineteen As DateTime
    Public Paydate As DateTime
    Public DAYS_COUNT As Integer = 0
    Public starting, ending As Date

    Private Sub frmMainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'ExportDataToExcel()

        'Update_HREmployee_From_PayrollEmployee()

        'Import_Employee_BRANCH_DEDUCTION()

        'ExportDataToExcel()

        'GetTotalOF()

        'GetBranchCodeInTBL_EMPLOYEE()

        'GetBranchCodeInTBL()

        'GetPositions()

        'AddColumn_TBL_EMPLOYEE()

        'SSS_Contribution_2023()

        'GetTotalOF() 'COST DISTRIBUTION DISBALANCE TRACING

        'MergeData()

        'CostGetDetails()

        'Using conSettings As New ServerSettings
        '    conSettings.ShowDialog()
        'End Using

        'EMAIL_SENT()

        '========= DEDUCTION ID IN RECORDED_ALLOW_DEDUC ===
        'CheckDeduction_inRecorded()

        '=== PHILHEALTH ADJUSTMENTS (NAERASE) ====== 
        'CopyPhilhealthAdjustment() 
        'CopyPAYOUT() 
        'MsgBox("SuccessFully Updated!")
        '=========================================== 

        'Update_Recorded_Allow_Deduct_ID()

        'PayoutRate()

        'RunCommand("Delete from Payroll_Attendance where BIOMETRICID IN (4732,
        '            4600, 4456, 4733, 4742, 4710, 4717, 4317, 4226,  4430) ")

        'GetHO_Category()

        'RUN_This()

        'Loans_to_Deduction()

        'CheckDeduction_Loans_IfZeroBalance(3869)
        '======================================== 

        Login_Form.ShowDialog()

        AppDateTime.Text = Date.Now.ToString("dddd, MMMM dd, yyyy hh: mm:ss tt", CultureInfo.CurrentCulture)

        StartFour = New DateTime(DateNow.Year, DateNow.Month, 4).AddDays(-1)
        EndFour = New DateTime(DateNow.Year, DateNow.Month, 18)

        StartNineteen = New DateTime(DateNow.Year, DateNow.Month, 19).AddMonths(-1).AddDays(-1)
        EndNineteen = New DateTime(StartNineteen.Year, StartNineteen.Month, 3).AddMonths(1)

        Dim startt, endd As Date
        If DateNow.Day - 16 <= 2 And DateNow.Day - 16 >= -12 Then
            Paydate = EndNineteen.AddDays(12)
            startt = StartNineteen.AddDays(1)
            endd = EndNineteen

            starting = StartNineteen.AddDays(1)
            ending = EndNineteen
        Else
            Paydate = New DateTime(EndFour.Year, EndFour.Month, DateTime.DaysInMonth(EndFour.Year, EndFour.Month))
            startt = StartFour.AddDays(1)
            endd = EndFour

            starting = StartFour.AddDays(1)
            ending = EndFour
        End If

        '=================== COUNT STANDARD DAYS ==================
        Dim RHOLIDAY As Integer = REGHolidayCount(startt, endd)
        Dim SHOLIDAY As Integer = SPECHolidayCount(startt, endd)

        While (startt <= endd)
            If startt.DayOfWeek <> DayOfWeek.Sunday Then
                DAYS_COUNT += 1
            End If
            startt = startt.AddDays(1)
        End While

        DAYS_COUNT = DAYS_COUNT - (RHOLIDAY + SHOLIDAY)
        '===========================================================

        If GetVersion() > Application.ProductVersion Then
            Dim result As DialogResult = MessageBox.Show($"New {GetVersion()} version of the program is available, do you want to upgrade?", "Question", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                Dim MyAutoUpdate As New Updater
                If MyAutoUpdate.AutoUpdate() Then
                    Close()
                End If
            End If
        End If

        'UpdatePayout("6/30/2023")
    End Sub

    '======================================Buttons==================================================  
    Private Sub btnManageEmployee_Click(sender As Object, e As EventArgs) Handles Employee_BTN.Click
        'OpenWindowsForm("frmEmployee")
        OpenWindowsForm("frmNewEmployee")
    End Sub

    Private Sub Attendance_BTN_Click(sender As Object, e As EventArgs) Handles Attendance_BTN.Click
        OpenWindowsForm("frmAttendance")
    End Sub

    Private Sub Payout_BTN_Click(sender As Object, e As EventArgs) Handles Payout_BTN.Click
        OpenWindowsForm("frmPayout")
    End Sub

    Private Sub Settings_BTN_Click(sender As Object, e As EventArgs) Handles Settings_BTN.Click
        OpenWindowsForm("frmSettings")
    End Sub

    '======================================MouseEnter-MouseLeave=============================== 
    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Exit_LBL.Click
        Close()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Minimize_LBL.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Label3_MouseEnter(sender As Object, e As EventArgs) Handles Exit_LBL.MouseEnter
        Exit_LBL.ForeColor = Color.Red
    End Sub

    Private Sub Exit_LBL_MouseLeave(sender As Object, e As EventArgs) Handles Exit_LBL.MouseLeave
        Exit_LBL.ForeColor = Color.Black
    End Sub

    Private Sub Label1_MouseEnter(sender As Object, e As EventArgs) Handles Minimize_LBL.MouseEnter
        Minimize_LBL.ForeColor = Color.Red
    End Sub

    Private Sub Minimize_LBL_MouseLeave(sender As Object, e As EventArgs) Handles Minimize_LBL.MouseLeave
        Minimize_LBL.ForeColor = Color.Black
    End Sub

    '========================================MOUSEENTER MOUSELEAVE=======================
    Private Sub BTN_Dashboard_MouseEnter(sender As Object, e As EventArgs) Handles Dashboard_BTN.MouseEnter
        Dashboard_BTN.BackColor = Color.DimGray
    End Sub

    Private Sub BTN_Dashboard_MouseLeave(sender As Object, e As EventArgs) Handles Dashboard_BTN.MouseLeave
        Dashboard_BTN.BackColor = Color.Black
    End Sub

    Private Sub Employee_BTN_MouseEnter(sender As Object, e As EventArgs) Handles Employee_BTN.MouseEnter
        Employee_BTN.BackColor = Color.DimGray
    End Sub

    Private Sub Employee_BTN_MouseLeave(sender As Object, e As EventArgs) Handles Employee_BTN.MouseLeave
        Employee_BTN.BackColor = Color.Black
    End Sub

    Private Sub Management_BTN_MouseEnter(sender As Object, e As EventArgs) Handles Attendance_BTN.MouseEnter
        Attendance_BTN.BackColor = Color.DimGray
    End Sub

    Private Sub Management_BTN_MouseLeave(sender As Object, e As EventArgs) Handles Attendance_BTN.MouseLeave
        Attendance_BTN.BackColor = Color.Black
    End Sub

    Private Sub DTR_BTN_MouseEnter(sender As Object, e As EventArgs) Handles Payout_BTN.MouseEnter
        Payout_BTN.BackColor = Color.DimGray
    End Sub

    Private Sub DTR_BTN_MouseLeave(sender As Object, e As EventArgs) Handles Payout_BTN.MouseLeave
        Payout_BTN.BackColor = Color.Black
    End Sub

    Private Sub Paysilp_BTN_MouseEnter(sender As Object, e As EventArgs) Handles Paysilp_BTN.MouseEnter
        Paysilp_BTN.BackColor = Color.DimGray
    End Sub

    Private Sub Paysilp_BTN_MouseLeave(sender As Object, e As EventArgs) Handles Paysilp_BTN.MouseLeave
        Paysilp_BTN.BackColor = Color.Black
    End Sub

    Private Sub Loan_BTN_MouseEnter(sender As Object, e As EventArgs) Handles Loan_BTN.MouseEnter
        Loan_BTN.BackColor = Color.DimGray
    End Sub

    Private Sub Loan_BTN_MouseLeave(sender As Object, e As EventArgs) Handles Loan_BTN.MouseLeave
        Loan_BTN.BackColor = Color.Black
    End Sub

    Private Sub Calculator_BTN_MouseEnter(sender As Object, e As EventArgs) Handles Contribution_BTN.MouseEnter
        Contribution_BTN.BackColor = Color.DimGray
    End Sub

    Private Sub Contribution_BTN_Click(sender As Object, e As EventArgs) Handles Contribution_BTN.Click
        OpenWindowsForm("frmContribution")
    End Sub

    Private Sub Paysilp_BTN_Click(sender As Object, e As EventArgs) Handles Paysilp_BTN.Click
        OpenWindowsForm("frmReport")
    End Sub

    Private Sub Loan_BTN_Click(sender As Object, e As EventArgs) Handles Loan_BTN.Click
        OpenWindowsForm("frmLoan")
    End Sub

    Private Sub ConnectToDatabaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConnectToDatabase_Menu.Click
        Using conSettings As New ServerSettings
            conSettings.ShowDialog()
        End Using
    End Sub

    Private Sub PictureBox1_DoubleClick(sender As Object, e As EventArgs) Handles PictureBox1.DoubleClick
        Using comString As New Developer
            comString.ShowDialog()
            comString.BringToFront()
        End Using
    End Sub

    Private Sub UserLogsMenuItem_Click(sender As Object, e As EventArgs) Handles UserLogs_Menu.Click
        OpenWindowsForm("frmUserLogs")
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Exit_Menu.Click
        Close()
    End Sub

    Private Sub ChangePasswordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangeUserInfo_Menu.Click
        Dim form As New frmUser
        form.ShowDialog()
    End Sub

    Private Sub ImportEmployeeScheduleHRToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Schedule_Menu.Click
        'OpenWindowsForm("frmSchedule")
    End Sub

    Private Sub Calculator_BTN_MouseLeave(sender As Object, e As EventArgs) Handles Contribution_BTN.MouseLeave
        Contribution_BTN.BackColor = Color.Black
    End Sub

    Private Sub Dashboard_lbl_Click(sender As Object, e As EventArgs) Handles Dashboard_lbl.Click
        OpenWindowsForm("frmDashboard")
    End Sub

    Private Sub Allowance_btn_Click(sender As Object, e As EventArgs) Handles Allowance_btn.Click
        OpenWindowsForm("frmAllowance")
    End Sub

    Private Sub Dashboard_BTN_Click(sender As Object, e As EventArgs) Handles Dashboard_BTN.Click
        OpenWindowsForm("frmSchedule")
    End Sub

    Private Sub Settings_BTN_MouseEnter(sender As Object, e As EventArgs) Handles Settings_BTN.MouseEnter
        Settings_BTN.BackColor = Color.DimGray
    End Sub

    Private Sub Settings_BTN_MouseLeave(sender As Object, e As EventArgs) Handles Settings_BTN.MouseLeave
        Settings_BTN.BackColor = Color.Black
    End Sub

    Friend Sub Accessibility(idx As String)

        For Each btn As Button In NavagationPanel.Controls.OfType(Of Button)()
            Dim mysql As String = $"Select * FROM PAYROLL_ACCESSIBILITY where USER_ID = '{idx}'"
            Using ds As DataSet = LoadSQL(mysql, "PAYROLL_ACCESSIBILITY")
                If ds.Tables(0).Rows.Count > 0 Then
                    For Each dr In ds.Tables(0).Rows
                        With dr
                            If btn.AccessibleName = .Item("FUNCTION") Then
                                btn.Enabled = False
                            End If
                        End With
                    Next
                End If
            End Using
        Next

        Dim mysqll As String = $"Select * FROM PAYROLL_ACCESSIBILITY where USER_ID = '{idx}'"
        Using dss As DataSet = LoadSQL(mysqll, "PAYROLL_ACCESSIBILITY")
            If dss.Tables(0).Rows.Count > 0 Then
                For Each drr In dss.Tables(0).Rows
                    With drr

                        If ChangeUserInfo_Menu.AccessibleName = .Item("FUNCTION") Then
                            ChangeUserInfo_Menu.Visible = False
                        ElseIf UserLogs_Menu.AccessibleName = .Item("FUNCTION") Then
                            UserLogs_Menu.Visible = False
                        End If

                    End With
                Next
            End If
        End Using

    End Sub

End Class
