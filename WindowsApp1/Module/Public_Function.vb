Imports System.Data.Common
Imports System.Globalization
Imports System.IO
Imports System.Net.Mail
Imports System.Reflection
Imports System.Text.RegularExpressions
Imports System.Threading
Imports FirebirdSql.Data.FirebirdClient

Module Public_Function

    Friend trimmer As New Regex("\s\s+")
    Friend emp_status As String
    Friend dateEnded As String
    Friend dateStarted As String
    Friend payrollSched As String = ""
    Friend specialHolidayList As New List(Of String)


    Friend Function ExcelFilePath(ByVal filePath As String) As String
        DefaultFolder = Path.GetDirectoryName(filePath)
        TargetFile = filePath
        Return TargetFile
    End Function

    Friend Sub OpenWindowsForm(ByVal FormName As String)
        Try
            Dim instForm As Form = Application.OpenForms.OfType(Of Form)().Where(Function(frm) frm.Name = FormName).SingleOrDefault()
            If instForm Is Nothing Then
                Dim frm As Form
                frm = DirectCast(CreateObjectInstance(FormName), Form)
                frm.MdiParent = frmMainForm
                frmMainForm.pNavigate.Controls.Add(frm)
                frmMainForm.pNavigate.Tag = frm

                frm.Show()
                frm.Dock = DockStyle.Fill
                frm.BringToFront()
            Else
                instForm.BringToFront()
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Friend Enum FormName As Integer
        Attendance
        Payout
        Loans
        Settings
        Schedule
        Allowance
    End Enum

    Friend Sub SwitchForm_Attendance(ByVal gotoForm As FormName, emp As Employee, empNo As Integer, Optional btnSearch_tag As String = "")
        Select Case gotoForm
            Case FormName.Attendance
                Try
                    Dim instForm As frmAttendance = Application.OpenForms.OfType(Of Form)().Where(Function(frm) frm.Name = "frmAttendance").SingleOrDefault()
                    instForm.Load_Attendance(emp, empNo)

                    If instForm Is Nothing Then
                        instForm = DirectCast(CreateObjectInstance("frmAttendance"), Form)
                        instForm.MdiParent = frmMainForm
                        frmMainForm.pNavigate.Controls.Add(instForm)
                        frmMainForm.pNavigate.Tag = instForm
                        instForm.Show()
                        instForm.Dock = DockStyle.Fill
                        instForm.BringToFront()
                    Else
                        instForm.BringToFront()
                    End If

                Catch ex As Exception
                    Console.WriteLine(ex.ToString)
                End Try
        End Select
    End Sub

    Friend Sub SwitchForm_Scheduling(ByVal gotoForm As FormName, emp As Employee)
        Select Case gotoForm
            Case FormName.Schedule
                Try
                    Dim instForm As frmSchedule = Application.OpenForms.OfType(Of Form)().Where(Function(frm) frm.Name = "frmSchedule").SingleOrDefault()
                    instForm.Load_Schedule(emp)

                    If instForm Is Nothing Then
                        instForm = DirectCast(CreateObjectInstance("frmSchedule"), Form)
                        instForm.MdiParent = frmMainForm
                        frmMainForm.pNavigate.Controls.Add(instForm)
                        frmMainForm.pNavigate.Tag = instForm
                        instForm.Show()
                        instForm.Dock = DockStyle.Fill
                        instForm.BringToFront()
                    Else
                        instForm.BringToFront()
                    End If

                Catch ex As Exception

                End Try
        End Select
    End Sub

    Friend Sub SwitchForm_Payout(ByVal gotoForm As FormName, emp As Employee, paydate As String, empNo As String)
        Select Case gotoForm
            Case FormName.Payout
                Try
                    Dim instForm_ As frmPayout = Application.OpenForms.OfType(Of Form)().Where(Function(frm) frm.Name = "frmPayout").SingleOrDefault()
                    instForm_.Load_Payout(emp, paydate, empNo)

                    If instForm_ Is Nothing Then
                        instForm_ = DirectCast(CreateObjectInstance("frmPayout"), Form)
                        instForm_.MdiParent = frmMainForm
                        frmMainForm.pNavigate.Controls.Add(instForm_)
                        frmMainForm.pNavigate.Tag = instForm_
                        instForm_.Show()
                        instForm_.Dock = DockStyle.Fill
                        instForm_.BringToFront()
                    Else
                        instForm_.BringToFront()
                    End If

                Catch ex As Exception

                End Try
        End Select
    End Sub

    Friend Sub SwitchForm_Settings(ByVal gotoForm As FormName, emp As Employee, tabName As String)
        Select Case gotoForm
            Case FormName.Settings
                Try
                    Dim instForm_ As frmSettings = Application.OpenForms.OfType(Of Form)().Where(Function(frm) frm.Name = "frmSettings").SingleOrDefault()
                    instForm_.Load_Settings(emp, tabName)

                    If instForm_ Is Nothing Then
                        instForm_ = DirectCast(CreateObjectInstance("frmSettings"), Form)
                        instForm_.MdiParent = frmMainForm
                        frmMainForm.pNavigate.Controls.Add(instForm_)
                        frmMainForm.pNavigate.Tag = instForm_
                        instForm_.Show()
                        instForm_.Dock = DockStyle.Fill
                        instForm_.BringToFront()
                    Else
                        instForm_.BringToFront()
                    End If

                Catch ex As Exception

                End Try
        End Select
    End Sub

    Friend Sub SwitchForm_Allowance(ByVal gotoForm As FormName, emp As Employee, tabName As String)
        Select Case gotoForm
            Case FormName.Allowance
                Try
                    Dim instForm_ As frmAllowance = Application.OpenForms.OfType(Of Form)().Where(Function(frm) frm.Name = "frmAllowance").SingleOrDefault()
                    instForm_.Load_Allowance(emp, tabName)

                    If instForm_ Is Nothing Then
                        instForm_ = DirectCast(CreateObjectInstance("frmAllowance"), Form)
                        instForm_.MdiParent = frmMainForm
                        frmMainForm.pNavigate.Controls.Add(instForm_)
                        frmMainForm.pNavigate.Tag = instForm_
                        instForm_.Show()
                        instForm_.Dock = DockStyle.Fill
                        instForm_.BringToFront()
                    Else
                        instForm_.BringToFront()
                    End If

                Catch ex As Exception

                End Try
        End Select
    End Sub

    Friend Sub SwitchForm_Loans(ByVal gotoForm As FormName, emp As Employee, tabName As String)
        Select Case gotoForm
            Case FormName.Loans
                Try
                    Dim instForm_ As frmLoan = Application.OpenForms.OfType(Of Form)().Where(Function(frm) frm.Name = "frmLoan").SingleOrDefault()
                    instForm_.Load_Contrib_Loan(emp, tabName)

                    If instForm_ Is Nothing Then
                        instForm_ = DirectCast(CreateObjectInstance("frmLoan"), Form)
                        instForm_.MdiParent = frmMainForm
                        frmMainForm.pNavigate.Controls.Add(instForm_)
                        frmMainForm.pNavigate.Tag = instForm_
                        instForm_.Show()
                        instForm_.Dock = DockStyle.Fill
                        instForm_.BringToFront()
                    Else
                        instForm_.BringToFront()
                    End If

                Catch ex As Exception

                End Try
        End Select
    End Sub

    Public Function CreateObjectInstance(ByVal objectName As String) As Object
        Dim obj As Object
        Try
            If objectName.LastIndexOf(".") = -1 Then
                objectName = [Assembly].GetEntryAssembly.GetName.Name & "." & objectName
            End If

            obj = [Assembly].GetEntryAssembly.CreateInstance(objectName)
        Catch ex As Exception
            obj = Nothing
        End Try

        Return obj
    End Function

    Friend Function DreadKnight(ByVal str As String, Optional ByVal special As String = Nothing) As String
        str = str.Replace("'", "''")
        str = str.Replace("""", """""")

        If special <> Nothing Then
            str = str.Replace(special, "")
        End If

        Return str
    End Function

    'Friend Sub Log_Report(ByVal str As String)
    '    If Not File.Exists(LOG_FILE) Then CreateLog()

    '    Dim recorded_log As String = $"[{Now.ToString("MM/dd/yyyy HH:mm:ss") }] - {str }"

    '    Dim fs As New FileStream(LOG_FILE, FileMode.Append, FileAccess.Write)
    '    Dim fw As New StreamWriter(fs)
    '    fw.WriteLine(recorded_log)
    '    fw.Close()
    '    fs.Close()
    'End Sub

    Friend Function IsEnter(ByVal e As KeyPressEventArgs) As Boolean
        If Asc(e.KeyChar) = 13 Then
            Return True
        End If
        Return False
    End Function

#Region "Log Module"

    Const LOG_FILE As String = "syslog.txt"

    Private Sub CreateLog()
        Dim fsEsk As New FileStream(LOG_FILE, FileMode.CreateNew)
        fsEsk.Close()
    End Sub

#End Region

    'Friend Sub Send_Email(byteViewer As Byte(), recipient_Email As String, recipient_Name As String, paydate As String, BodyText As String, subjectt As String)
    '    Console.WriteLine(recipient_Email)
    'End Sub

    'Friend Sub Send_Email(byteViewer As Byte(), recipient_Email As String, recipient_Name As String, paydate As String, BodyText As String, subjectt As String, Optional bio_no As String = "", Optional payrollDate As String = "")
    '    Try

    '        Dim email As String = GetEmail()
    '        Dim password As String = GetPassword()

    '        Dim Smtp_Server As New SmtpClient
    '        Dim e_mail As New MailMessage()
    '        Smtp_Server.UseDefaultCredentials = False
    '        Smtp_Server.Credentials = New Net.NetworkCredential(email, password)
    '        Smtp_Server.Port = 587
    '        Smtp_Server.EnableSsl = True
    '        Smtp_Server.Host = "smtp.gmail.com"

    '        e_mail = New MailMessage()
    '        e_mail.From = New MailAddress(email)
    '        e_mail.To.Add(recipient_Email)
    '        e_mail.Subject = subjectt
    '        e_mail.IsBodyHtml = False

    '        Dim memoryStream = New MemoryStream(byteViewer)
    '        memoryStream.Seek(0, SeekOrigin.Begin)

    '        Dim attachment = New Attachment(memoryStream, recipient_Name & ".pdf")
    '        e_mail.Attachments.Add(attachment)

    '        e_mail.Body = BodyText
    '        Smtp_Server.Send(e_mail)

    '        If bio_no <> "" Then UpdateEMAIL_SENT(bio_no, payrollDate)
    '    Catch error_t As Exception
    '        MsgBox(error_t.ToString)
    '    End Try
    'End Sub

    Friend Sub Send_Email(byteViewer As Byte(), recipient_Email As String, recipient_Name As String, paydate As String, BodyText As String, subjectt As String, Optional bio_no As String = "", Optional payrollDate As String = "")
        Try
            Dim email As String = GetEmail()
            Dim password As String = GetPassword()

            Using smtpClient As New SmtpClient("smtp.gmail.com", 587)
                smtpClient.UseDefaultCredentials = False
                smtpClient.Credentials = New Net.NetworkCredential(email, password)
                smtpClient.EnableSsl = True

                Using mail As New MailMessage(email, recipient_Email)
                    mail.Subject = subjectt
                    mail.IsBodyHtml = False
                    mail.Body = BodyText

                    Using memoryStream As New MemoryStream(byteViewer)
                        memoryStream.Seek(0, SeekOrigin.Begin)
                        Dim attachment = New Attachment(memoryStream, recipient_Name & ".pdf", "application/pdf")
                        mail.Attachments.Add(attachment)

                        smtpClient.Send(mail)
                        'Thread.Sleep(3000) ' Delay to avoid throttling or connection issues
                    End Using
                End Using
            End Using

            If bio_no <> "" Then UpdateEMAIL_SENT(bio_no, payrollDate)

        Catch ex As Exception
            MsgBox("Error sending to " & recipient_Email & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Email Error")
        End Try
    End Sub



    Friend Sub TempAttendance()
        RunCommand("DELETE FROM TEMP_ATTENDANCE")
    End Sub

    Friend Sub InsertTempAttendance(BIOMETRICID As String, paydate_ As String, TotalDays As String, TotalOTHr As String,
                                    Late_Total As String, Under_Total As String, TotalRHoliday As String, TotalSHoliday As String)

        Dim mysql As String = "Select * From TEMP_ATTENDANCE Rows 1"
        Using ds As DataSet = LoadSQL(mysql, "TEMP_ATTENDANCE")

            Dim dsNewRow As DataRow = ds.Tables(0).NewRow
            With dsNewRow
                .Item("BIOMETRICID") = BIOMETRICID
                .Item("PAYDATE") = paydate_
                .Item("PRESENT_DAYS") = TotalDays
                .Item("OVERTIME") = TotalOTHr
                .Item("LATE") = Late_Total
                .Item("UNDERTIME") = Under_Total
                .Item("REGHOLIDAY") = TotalRHoliday
                .Item("SPECHOLIDAY") = TotalSHoliday
            End With
            ds.Tables(0).Rows.Add(dsNewRow)
            SaveEntry(ds)
        End Using
    End Sub

    Friend Function TitleCase(str As String)

        Dim toLower, toProper As String

        toLower = str.ToLower()
        Dim info As TextInfo = CultureInfo.InvariantCulture.TextInfo
        toProper = info.ToTitleCase(toLower)

        Return toProper
    End Function

    Friend Function ColumnChecker(table As String, col As String) As Boolean
        Dim alreadyExist = False
        Dim sql As String = String.Format("SELECT * FROM RDB$RELATION_FIELDS WHERE (RDB$RELATION_NAME = '{0}' AND RDB$FIELD_NAME = '{1}');", table, col)
        Try
            Dim ds = LoadSQL(trimmer.Replace(sql, ""))
            If ds.Tables(0).Rows.Count > 0 Then
                alreadyExist = True
            Else
                alreadyExist = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Autopatch")
        End Try
        Return alreadyExist
    End Function

#Region "FOR IMPORT ONLY frmNewEmployee"

    Friend Sub Save_Recorded_Allow_Deduc_13month(bio_no As String, PAYDATE As String, CATEGORY As String, AMOUNT As String, TRANSAC_NAME As String)
        Dim sql As String
        sql = $"Select * From RECORDED_ALLOW_DEDUC where BIO_NO = '{bio_no}' and PAYDATE = '{PAYDATE}' and CATEGORY = '13th Month Pay'"
        Using dss As DataSet = LoadSQL(sql, "RECORDED_ALLOW_DEDUC")
            If dss.Tables(0).Rows.Count > 0 Then
                Dim dsRow As DataRow = dss.Tables(0).Rows(0)
                With dsRow
                    .Item("BIO_NO") = bio_no
                    .Item("PAYDATE") = PAYDATE
                    .Item("CATEGORY") = CATEGORY
                    .Item("AMOUNT") = AMOUNT
                    .Item("TRANSAC_NAME") = TRANSAC_NAME
                End With

                SaveEntry(dss, False)
            Else

                sql = "Select * From RECORDED_ALLOW_DEDUC Rows 1"
                Using ds As DataSet = LoadSQL(sql, "RECORDED_ALLOW_DEDUC")

                    Dim dsNewRow As DataRow = ds.Tables(0).NewRow
                    With dsNewRow

                        .Item("BIO_NO") = bio_no
                        .Item("PAYDATE") = PAYDATE
                        .Item("CATEGORY") = CATEGORY
                        .Item("AMOUNT") = AMOUNT
                        .Item("TRANSAC_NAME") = TRANSAC_NAME

                    End With
                    ds.Tables(0).Rows.Add(dsNewRow)
                    SaveEntry(ds)
                End Using
            End If
        End Using

    End Sub

    Public Sub UPDATENETPAY(BIO_NO As String, PAYDATE As String, AMOUNT As String)
        Dim total_allowance As Decimal
        Dim mysql As String = $"Select SUM(AMOUNT) AS TOTS FROM RECORDED_ALLOW_DEDUC where BIO_NO = '{BIO_NO}' and PAYDATE = '{PAYDATE}' and TRANSAC_NAME = 'ALLOWANCE'"
        Dim dss As DataSet = LoadSQL(mysql, "RECORDED_ALLOW_DEDUC")
        If dss.Tables(0).Rows.Count > 0 Then
            For Each dr In dss.Tables(0).Rows()
                With dr
                    total_allowance = .Item("TOTS")
                End With
            Next
        End If

        mysql = $"Select * FROM PAYROLL_PAYOUT where BIOMETRIC_ID = '{BIO_NO}' and PAYDATE = '{PAYDATE}'"
        Dim ds As DataSet = LoadSQL(mysql, "PAYROLL_PAYOUT")
        If ds.Tables(0).Rows.Count > 0 Then
            With ds.Tables(0).Rows(0)

                Dim positive, negative As Decimal
                positive = .Item("GROSS_AMOUNT") + total_allowance
                negative = .Item("TOTAL_DEDUCTION")

                .Item("NET_PAY") = positive - negative

            End With

            SaveEntry(ds, False)
        End If

    End Sub

    Public Function SAVE_Emp_SBU_EXCEL(EMP_NO As String, RowNo As Integer)
        If Not HeadOffice_Employee(EMP_NO.TrimEnd) Then
            Dim mysql As String
            Dim BIO As String = ""

            '====================== GET BIO_NO FOR SAVING TO PAYROLL_SBU  ==================
            mysql = "Select * From TBL_EMPLOYEE WHERE EMP_NO = '" & EMP_NO.TrimEnd & "'"
            Using ds As DataSet = LoadSQL(mysql, "TBL_EMPLOYEE")
                If ds.Tables(0).Rows.Count > 0 Then
                    Dim data As DataRow = ds.Tables(0).Rows(0)
                    With data
                        BIO = .Item("BIOMETRICID")
                        Console.WriteLine($"SBU - { .Item("LASTNAME")}, { .Item("FIRSTNAME")}/ {BIO}")
                    End With
                Else
                    'Exit Function
                    Return False
                End If
            End Using

            '====================== DELETE EXISTING DATA PAYROLL_SBU ==================
            RunCommand($"DELETE FROM PAYROLL_SBU WHERE BIO_NO = {BIO}")

            '====================== ADD NEW PAYROLL_SBU ==================
            mysql = "Select * From PAYROLL_SBU Rows 1"
            Using dssS As DataSet = LoadSQL(mysql, "PAYROLL_SBU")

                Dim dsNewRow As DataRow = dssS.Tables(0).NewRow
                With dsNewRow

                    .Item("BIO_NO") = BIO
                    .Item("DATE_ADDED") = Today

                End With
                dssS.Tables(0).Rows.Add(dsNewRow)
                SaveEntry(dssS)
            End Using

            Return True
        End If
        Return False
    End Function

    Public Sub UPDATE_Emp_SBU_EXCEL(CATEGORY As String, AMOUNT As String, PRINCIPAL As String, CREDIT As String, BALANCE As String, RowNo As Integer)

        Dim mysql As String = "Select * From PAYROLL_SBU ORDER BY ID DESC Rows 1"
        Using dssS As DataSet = LoadSQL(mysql, "PAYROLL_SBU")
            If dssS.Tables(0).Rows.Count > 0 Then
                Dim data As DataRow = dssS.Tables(0).Rows(0)
                With data

                    If IsDBNull(.Item("PRINCIPAL")) Then .Item("PRINCIPAL") = IIf(PRINCIPAL = Nothing, 0, PRINCIPAL)
                    If IsDBNull(.Item("CREDIT")) Then .Item("CREDIT") = IIf(CREDIT = Nothing, 0, CREDIT)
                    If IsDBNull(.Item("BALANCE")) Then .Item("BALANCE") = IIf(BALANCE = Nothing, PRINCIPAL, BALANCE)
                    If IsDBNull(.Item("CATEGORY")) Then .Item("CATEGORY") = CATEGORY
                    If IsDBNull(.Item("AMOUNT")) Then .Item("AMOUNT") = IIf(AMOUNT = Nothing, 250, AMOUNT)

                End With
                SaveEntry(dssS, False)
            End If
        End Using
    End Sub

    'Public Sub SAVE_EmpNo_Deduction_EXCEL(EMP_NO As String, RowNo As Integer)
    '    Dim mysql As String
    '    Dim BIO As String = ""

    '    '====================== GET BIO_NO FOR SAVING TO PAYROLL_SBU  ==================
    '    mysql = "Select * From PAYROLL_EMPLOYEE WHERE EMP_NO = '" & EMP_NO.TrimEnd & "'"
    '    Using ds As DataSet = LoadSQL(mysql, "PAYROLL_EMPLOYEE")
    '        If ds.Tables(0).Rows.Count > 0 Then
    '            Dim data As DataRow = ds.Tables(0).Rows(0)
    '            With data
    '                BIO = .Item("BIO_NO")
    '            End With
    '        Else
    '            Exit Sub
    '        End If
    '    End Using

    '    '====================== ADD NEW PAYROLL_SBU ==================
    '    mysql = "Select * From PAYROLL_DEDUCTION Rows 1"
    '    Using dssS As DataSet = LoadSQL(mysql, "PAYROLL_DEDUCTION")

    '        Dim dsNewRow As DataRow = dssS.Tables(0).NewRow
    '        With dsNewRow

    '            .Item("BIO_NO") = BIO

    '        End With
    '        dssS.Tables(0).Rows.Add(dsNewRow)
    '        SaveEntry(dssS)
    '    End Using

    'End Sub

    Public Sub SAVE_Deduction_EXCEL(CATEGORY As String, AMOUNT As String, PRINCIPAL As String, CREDIT As String, BALANCE As String, DATEE As String, RowNo As Integer)

        Dim bio_no As String = ""
        '=============================== GET LAST BIO_NO =============================
        Dim mysql As String = "Select * From PAYROLL_DEDUCTION ORDER BY ID DESC Rows 1"
        Using dssS As DataSet = LoadSQL(mysql, "PAYROLL_DEDUCTION")
            If dssS.Tables(0).Rows.Count > 0 Then
                With dssS.Tables(0).Rows(0)
                    bio_no = .Item("BIO_NO")
                End With
            End If
        End Using

        '=============================== SAVE NEW ROW =============================
        Dim mysqlL As String = $"Select * From PAYROLL_DEDUCTION"
        Using dssS As DataSet = LoadSQL(mysqlL, "PAYROLL_DEDUCTION")
            If dssS.Tables(0).Rows.Count > 0 Then

                Dim dataA As DataRow = dssS.Tables(0).NewRow
                With dataA

                    .Item("BIO_NO") = bio_no
                    .Item("CATEGORY") = CATEGORY
                    .Item("PRINCIPAL") = PRINCIPAL
                    .Item("AMORT") = AMOUNT
                    .Item("CREDIT") = CREDIT
                    .Item("BALANCE") = BALANCE
                    .Item("DATEE") = DATEE
                    .Item("SCHEDULE") = "EVERY PAYROLL"

                End With

                dssS.Tables(0).Rows.Add(dataA)
                SaveEntry(dssS)
            End If
        End Using

        Console.WriteLine("ROWWW " & RowNo)
    End Sub

    Public Sub SAVE_LOANS_EXCEL(CATEGORY As String, AMOUNT As String, PRINCIPAL As String, CREDIT As String, BALANCE As String, DATEE As String, RowNo As Integer)

        Dim bio_no As String = ""
        '=============================== GET LAST BIO_NO =============================
        Dim mysql As String = "Select * From PAYROLL_DEDUCTION ORDER BY ID DESC Rows 1"
        Using dssS As DataSet = LoadSQL(mysql, "PAYROLL_DEDUCTION")
            If dssS.Tables(0).Rows.Count > 0 Then
                With dssS.Tables(0).Rows(0)
                    bio_no = .Item("BIO_NO")
                End With
            End If
        End Using

        '=============================== SAVE NEW ROW =============================
        Dim mysqlL As String = $"Select * From PAYROLL_LOANS"
        Using dssS As DataSet = LoadSQL(mysqlL, "PAYROLL_LOANS")
            Dim dataA As DataRow = dssS.Tables(0).NewRow
            With dataA

                .Item("BIO_NO") = bio_no
                .Item("CATEGORY") = CATEGORY
                .Item("PRINCIPAL") = PRINCIPAL
                .Item("AMORT") = AMOUNT
                .Item("CREDIT") = CREDIT
                .Item("BALANCE") = BALANCE
                .Item("DATEE") = DATEE

            End With

            dssS.Tables(0).Rows.Add(dataA)
            SaveEntry(dssS)
        End Using

        Console.WriteLine("ROWWW " & RowNo)
    End Sub

#End Region

#Region "PGCNAS"
    Friend Function SavePDF_ToPGCNAS(Fullname As String, byteViewer As Byte())
        Fullname = Fullname.ToString.TrimEnd()

        Dim DirFolderToCreate As String = My.Settings.PGCNAS_SOA
        Dim folderName As DirectoryInfo = New DirectoryInfo(DirFolderToCreate)
        If Not folderName.Exists Then folderName.Create()

        Dim path As String = $"{DirFolderToCreate}\{Fullname} - SOA.pdf"

        SaveToFOlder(path, byteViewer)

        Return path
    End Function

    Friend Sub SaveToFOlder(path As String, byteViewer As Byte())
        Try
            Dim newFile As New FileStream(path, FileMode.Create)
            newFile.Write(byteViewer, 0, byteViewer.Length)
            newFile.Close()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Exclamation)
        End Try
    End Sub
#End Region

#Region "UPDATE_DEDUCTION"
    Friend Sub CheckDeduction_inRecorded() '============== NO R_DEDUC_ID IN RECORDED_ALLOW_DEDUC
        Dim mysql As String = $"Select A.*, B.ID as deduct_id from RECORDED_ALLOW_DEDUC A 
                                              inner join PAYROLL_DEDUCTION B on B.BIO_NO = A.BIO_NO AND B.CATEGORY = A.CATEGORY 
                                              Where TRANSAC_NAME = 'DEDUCTION' and R_DEDUC_ID is null"
        Using ds As DataSet = LoadSQL(mysql, "RECORDED_ALLOW_DEDUC")
            If ds.Tables(0).Rows.Count > 0 Then
                For Each dr In ds.Tables(0).Rows
                    With dr
                        Dim deduct_id As String = .item("deduct_id")

                        Console.WriteLine(.item("PAYDATE"))
                        Console.WriteLine(.item("BIO_NO"))
                        Console.WriteLine(deduct_id)
                        Console.WriteLine(.item("CATEGORY"))
                        Console.WriteLine(.item("AMOUNT"))

                        .item("R_DEDUC_ID") = deduct_id
                    End With
                    SaveEntry(ds, False)
                Next
            End If
        End Using
    End Sub

    'Friend Function ShowPasswordForm()
    '    Dim passwordForm As New Form()
    '    passwordForm.Size = New Size(300, 120)
    '    passwordForm.StartPosition = FormStartPosition.CenterScreen

    '    passwordForm.FormBorderStyle = FormBorderStyle.FixedDialog
    '    passwordForm.MaximizeBox = False

    '    Dim lblPrompt As New Label()
    '    lblPrompt.Text = "Please enter your password:"
    '    lblPrompt.AutoSize = True
    '    lblPrompt.Location = New Point(10, 10)
    '    passwordForm.Controls.Add(lblPrompt)

    '    Dim txtPassword As New TextBox()
    '    txtPassword.Location = New Point(10, 40)
    '    txtPassword.Width = 260
    '    txtPassword.UseSystemPasswordChar = True
    '    passwordForm.Controls.Add(txtPassword)

    '    AddHandler txtPassword.KeyPress, AddressOf txtPassword_KeyPress

    '    passwordForm.ShowDialog()
    'End Function

    'Private Sub txtPassword_KeyPress(sender As Object, e As KeyPressEventArgs)
    '    If e.KeyChar = ChrW(Keys.Enter) Then
    '        Dim userID As String = frmMainForm.UserName_LBL.Tag
    '        Dim txtPassword As TextBox = DirectCast(sender, TextBox)

    '        Dim getPassword As String = GET_STRING("PAYROLL_USER", "PASSWORD", $"ID = {userID}")
    '        getPassword = DecryptString(getPassword)

    '        If txtPassword.Text = getPassword Then

    '        End If
    '    End If
    'End Sub

    Friend Function ShowPasswordForm() As Boolean
        Dim passwordForm As New Form()
        passwordForm.Size = New Size(300, 120)
        passwordForm.StartPosition = FormStartPosition.CenterScreen

        passwordForm.FormBorderStyle = FormBorderStyle.FixedDialog
        passwordForm.MaximizeBox = False
        passwordForm.MinimizeBox = False ' Also disable minimize button

        Dim lblPrompt As New Label()
        lblPrompt.Text = "Please enter your password:"
        lblPrompt.AutoSize = True
        lblPrompt.Location = New Point(10, 10)
        passwordForm.Controls.Add(lblPrompt)

        Dim txtPassword As New TextBox()
        txtPassword.Location = New Point(10, 40)
        txtPassword.Width = 260
        txtPassword.UseSystemPasswordChar = True
        passwordForm.Controls.Add(txtPassword)

        ' Variable to store the result
        Dim passwordMatch As Boolean = False

        ' Add a KeyPress event handler for txtPassword
        AddHandler txtPassword.KeyPress, Sub(sender As Object, e As KeyPressEventArgs)
                                             If e.KeyChar = ChrW(Keys.Enter) Then
                                                 Dim userID As Integer = frmMainForm.UserName_LBL.Tag
                                                 Dim txtPasswordBox As TextBox = DirectCast(sender, TextBox)

                                                 Dim getPassword As String = GET_STRING("PAYROLL_USER", "PASSWORD", $"ID = {userID}")
                                                 getPassword = DecryptString(getPassword)

                                                 If txtPasswordBox.Text = getPassword Then
                                                     passwordMatch = True
                                                     passwordForm.DialogResult = DialogResult.OK
                                                     passwordForm.Close()
                                                 Else
                                                     MsgBox("Incorrect password. Please try again.", MsgBoxStyle.Exclamation)
                                                 End If
                                                 e.Handled = True ' Prevent the default beep sound on Enter key press
                                             End If
                                         End Sub

        passwordForm.ShowDialog()

        Return passwordMatch
    End Function
#End Region

    Friend Function ValidServerConnection()
        Dim connectionString As String = "User=SYSDBA;Password=masterkey;Database=hodb;DataSource=PGC-Encashment;Port=3050;Dialect=3;Charset=UTF8;Pooling=true"

        Try
            Using con As New FbConnection(connectionString)
                con.Open()
                Console.WriteLine("Connection successful!")
            End Using
            Return True
        Catch ex As FbException
            Console.WriteLine("Error: " & ex.Message)
        Catch ex As Exception
            Console.WriteLine("General Error: " & ex.Message)
        End Try
        Return False
    End Function

End Module
