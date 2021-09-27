Imports System.IO
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
        Attendance_DTR
        Attendance_Mannual
        Payout_Details
        Payout_Payslip
    End Enum

    Friend Sub SwitchForm_Attendance(ByVal gotoForm As FormName, emp As Employee, empNo As Integer, Optional btnSearch_tag As String = "")
        Select Case gotoForm
            Case FormName.Attendance_DTR
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

            Case FormName.Attendance_Mannual
                Try
                    Dim instForm_ As frmAttendance = Application.OpenForms.OfType(Of Form)().Where(Function(frm) frm.Name = "frmAttendance").SingleOrDefault()
                    instForm_.Load_Attendance(emp, empNo)

                    If instForm_ Is Nothing Then
                        instForm_ = DirectCast(CreateObjectInstance("frmAttendance"), Form)
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

    Friend Sub SwitchForm_Payout(ByVal gotoForm As FormName, emp As Employee, paydate As String, empNo As String)
        Select Case gotoForm
            Case FormName.Payout_Details
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

    Friend Sub SwitchForm_Settings(ByVal gotoForm As FormName, emp As Employee)
        Select Case gotoForm
            Case FormName.Payout_Details
                Try
                    Dim instForm_ As frmPayout = Application.OpenForms.OfType(Of Form)().Where(Function(frm) frm.Name = "frmPayout").SingleOrDefault()
                    'instForm_.Load_Payout(emp, paydate)

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

End Module
