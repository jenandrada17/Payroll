Imports System.IO
Imports System.Net.Mail
Imports System.Reflection

Module Public_Function

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

        End Try
    End Sub

    Friend Enum FormName As Integer
        Attendance
        Payout
        Loans
        Settings
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

    Friend Sub SwitchForm_Loans(ByVal gotoForm As FormName, emp As Employee, tabName As String)
        Select Case gotoForm
            Case FormName.Loans
                Try
                    Dim instForm_ As frmContribution = Application.OpenForms.OfType(Of Form)().Where(Function(frm) frm.Name = "frmContribution").SingleOrDefault()
                    instForm_.Load_Contrib_Loan(emp, tabName)

                    If instForm_ Is Nothing Then
                        instForm_ = DirectCast(CreateObjectInstance("frmContribution"), Form)
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

    Friend Sub Log_Report(ByVal str As String)
        If Not File.Exists(LOG_FILE) Then CreateLog()

        Dim recorded_log As String = $"[{Now.ToString("MM/dd/yyyy HH:mm:ss") }] - {str }"

        Dim fs As New FileStream(LOG_FILE, FileMode.Append, FileAccess.Write)
        Dim fw As New StreamWriter(fs)
        fw.WriteLine(recorded_log)
        fw.Close()
        fs.Close()
    End Sub

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

    'Friend Sub Send_Email(byteViewer As Byte(), recipient_Email As String, recipient_Name As String, paydate As String, BodyText As String, subjectt As String, Optional FOR_single As Boolean = False)
    Friend Sub Send_Email(byteViewer As Byte(), recipient_Email As String, recipient_Name As String, paydate As String, BodyText As String, subjectt As String)
        Try

            Dim email As String = GetEmail()
            Dim password As String = GetPassword()

            Dim Smtp_Server As New SmtpClient
            Dim e_mail As New MailMessage()
            Smtp_Server.UseDefaultCredentials = False
            Smtp_Server.Credentials = New Net.NetworkCredential(email, password)
            Smtp_Server.Port = 587
            Smtp_Server.EnableSsl = True
            Smtp_Server.Host = "smtp.gmail.com"

            e_mail = New MailMessage()
            e_mail.From = New MailAddress(email)
            e_mail.To.Add(recipient_Email)
            e_mail.Subject = subjectt
            e_mail.IsBodyHtml = False

            Dim memoryStream = New MemoryStream(byteViewer)
            memoryStream.Seek(0, SeekOrigin.Begin)

            Dim attachment = New Attachment(memoryStream, recipient_Name & ".pdf")
            e_mail.Attachments.Add(attachment)

            e_mail.Body = BodyText
            Smtp_Server.Send(e_mail)

            'If FOR_single Then
            '    MsgBox("Email Sent!")
            'End If

        Catch error_t As Exception
            MsgBox(error_t.ToString)
        End Try
    End Sub

End Module
