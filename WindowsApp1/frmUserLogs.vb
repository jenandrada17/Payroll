Public Class frmUserLogs

    Private Sub frmUserLogs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UserLogs_Record(lvLogs)
    End Sub

    Private Sub Close_LBL_Click(sender As Object, e As EventArgs) Handles Close_LBL.Click
        Close()
    End Sub

End Class