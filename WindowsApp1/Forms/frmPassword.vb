Public Class frmPassword
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Close()
    End Sub

    Private Sub GunaClear_btn_Click(sender As Object, e As EventArgs) Handles GunaClear_btn.Click
        GunaNew_txt.Clear()
        GunaOld_txt.Clear()
        GunaConfirm_txt.Clear()
    End Sub

    Private Sub GunaSave_btn_Click(sender As Object, e As EventArgs) Handles GunaSave_btn.Click

    End Sub

End Class