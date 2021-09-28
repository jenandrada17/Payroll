Imports System.IO

Public Module FileDirectory
    Public Property DefaultFolder() As String = ""
    Public Property TargetFile() As String = ""

    Public Function ExcelTargetDirectoryIsValid() As Boolean

        Try
            Dim dir = Path.GetDirectoryName(TargetFile)
            If Directory.Exists(dir) Then
                Directory.CreateDirectory(dir)
            End If
            Return True
        Catch ex As Exception
            Log_Report(String.Format("User: {0}", fbUser))
            Log_Report(String.Format("Database: {0}", dbName))
            Log_Report(ex.ToString)
            Return False
        End Try

    End Function

End Module