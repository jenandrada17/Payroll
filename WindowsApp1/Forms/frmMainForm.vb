Imports System.Globalization
Imports DBConnect

Public Class frmMainForm

    Dim DateNow As DateTime = DateTime.Now
    Dim StartFour, EndFour, StartNineteen, EndNineteen As DateTime
    Public Paydate As DateTime
    Public CommandLine As String
    Public DAYS_COUNT As Integer = 0

    Private Sub frmMainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Check_This()

        Login_Form.ShowDialog()

        AppDateTime.Text = Date.Now.ToString("dddd, MMMM dd, yyyy hh:mm:ss tt", CultureInfo.CurrentCulture)

        StartFour = New DateTime(DateNow.Year, DateNow.Month, 4).AddDays(-1)
        EndFour = New DateTime(DateNow.Year, DateNow.Month, 18)

        StartNineteen = New DateTime(DateNow.Year, DateNow.Month, 19).AddMonths(-1).AddDays(-1)
        EndNineteen = New DateTime(StartNineteen.Year, StartNineteen.Month, 3).AddMonths(1)

        Dim startt, endd As Date
        If DateNow.Day - 16 <= 2 And DateNow.Day - 16 >= -12 Then
            Paydate = EndNineteen.AddDays(12)
            startt = StartNineteen.AddDays(1)
            endd = EndNineteen
        Else
            Paydate = New DateTime(EndFour.Year, EndFour.Month, DateTime.DaysInMonth(EndFour.Year, EndFour.Month))
            startt = StartFour.AddDays(1)
            endd = EndFour
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
                If MyAutoUpdate.AutoUpdate(CommandLine) Then
                    Close()
                End If
            End If
        End If

        Console.WriteLine(EncryptString("jenkeandre"))
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

    '======================================MouseEnter-MouseLeave================================================== 

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


    Private Sub ConnectToDatabaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConnectToDatabaseToolStripMenuItem.Click
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

    Private Sub UserLogsMenuItem_Click(sender As Object, e As EventArgs) Handles UserLogsMenuItem.Click
        OpenWindowsForm("frmUserLogs")
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub ChangePasswordToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangePasswordToolStripMenuItem.Click
        Dim form As New frmUser
        form.ShowDialog()
    End Sub

    Private Sub Calculator_BTN_MouseLeave(sender As Object, e As EventArgs) Handles Contribution_BTN.MouseLeave
        Contribution_BTN.BackColor = Color.Black
    End Sub

    Private Sub Settings_BTN_MouseEnter(sender As Object, e As EventArgs) Handles Settings_BTN.MouseEnter
        Settings_BTN.BackColor = Color.DimGray
    End Sub

    Private Sub Settings_BTN_MouseLeave(sender As Object, e As EventArgs) Handles Settings_BTN.MouseLeave
        Settings_BTN.BackColor = Color.Black
    End Sub

End Class
