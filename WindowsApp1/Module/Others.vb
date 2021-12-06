Module Others
    Public Function GetVersion() As String
        Dim version As String = Nothing
        Try
            Dim file As New System.IO.StreamReader("\\Pgcnas_server\hr\PAYROLL\version.txt")
            Dim Contents As String = file.ReadToEnd()
            file.Close()
            version = Contents
        Catch ex As Exception
            MsgBox("There was a problem runing the Auto Update." & vbCr &
                "Please Contact [contact info]" & vbCr & ex.Message, MsgBoxStyle.Critical)
        End Try
        Return version
    End Function

End Module
