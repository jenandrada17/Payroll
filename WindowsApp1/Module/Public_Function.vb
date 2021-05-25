Imports System.IO
Imports System.Reflection

Module Public_Function
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
        Console.WriteLine("Recorded")
    End Sub



#Region "Log Module"

    Const LOG_FILE As String = "syslog.txt"

    Private Sub CreateLog()
        Dim fsEsk As New FileStream(LOG_FILE, FileMode.CreateNew)
        fsEsk.Close()
    End Sub

#End Region

End Module
