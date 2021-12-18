Public Class frmUser
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Close()
    End Sub

    Private Sub GunaClear_btn_Click(sender As Object, e As EventArgs) Handles GunaClear_btn.Click
        SampleUser_txt.Clear()
        SamplePass_txt.Clear()
        NewUser_txt.Clear()
        NewPass_txt.Clear()
        Confirm_txt.Clear()
    End Sub

    Private Sub GunaSave_btn_Click(sender As Object, e As EventArgs) Handles GunaSave_btn.Click

        If Not validSave() Then Exit Sub

        SaveUserDetails(SampleUser_txt.Text, NewUser_txt.Text, NewPass_txt.Text)
        Replacing($"PAYROLL_USER where USERNAME = '{SampleUser_txt.Text}' oR PASSWORD = '{SamplePass_txt.Text}';")
        GunaClear_btn.PerformClick()

    End Sub

    Private Function validSave()

        If NewPass_txt.Text <> Confirm_txt.Text Then
            MsgBox("New password and confirm password are not match.", MsgBoxStyle.Exclamation, "INVALID")
            Return False
        ElseIf Not validSampleUser(SampleUser_txt.Text, EncryptString(SamplePass_txt.Text)) Then
            MsgBox("Invalid Sample Username and Sample Password.", MsgBoxStyle.Exclamation, "INVALID")
            Return False
        End If

        Return True
    End Function

End Class