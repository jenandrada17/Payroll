Public Class Updater

    Public Function AutoUpdate(ByRef CommandLine As String) As Boolean

        Dim ret As Boolean = False

        Try

            Dim file As New System.IO.StreamReader("\\Pgcnas_server\hr\PAYROLL\version.txt")
            Dim Contents As String = file.ReadToEnd()
            file.Close()
            If Contents <> "" Then
                If Contents > Application.ProductVersion Then
                    System.Diagnostics.Process.Start("\\Pgcnas_server\hr\PAYROLL\PayrollSystem.exe")
                    ret = True
                End If
            End If
        Catch ex As Exception
            ret = True
            MsgBox("There was a problem runing the Auto Update." & vbCr &
                "Please Check network connection" & vbCr & ex.Message, MsgBoxStyle.Critical)
        End Try
        Return ret
    End Function

End Class
