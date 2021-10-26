Public Class Rdlc_Class
    Public Function MyFunction(ByVal column As String, ByVal one As String, ByVal two As String, ByVal three As String)

        Dim sum As Integer = 0
        Dim percent As Integer = 0
        sum = one + two + three

        percent = FormatPercent(column / sum, 2, TriState.False)

        Return percent
    End Function

End Class
