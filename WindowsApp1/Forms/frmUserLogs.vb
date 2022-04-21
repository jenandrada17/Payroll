Public Class frmUserLogs

    Private Sub frmUserLogs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UserLogs_Record(lvLogs)
    End Sub

    Private Sub Close_LBL_Click(sender As Object, e As EventArgs) Handles Close_LBL.Click
        Close()
    End Sub

    Private Sub Search_BTN_Click(sender As Object, e As EventArgs) Handles Search_BTN.Click
        UserLogs_Record(lvLogs, Search_TXT.Text)
    End Sub

    Private Sub Search_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Search_TXT.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Search_BTN.PerformClick()
        End If
    End Sub

End Class