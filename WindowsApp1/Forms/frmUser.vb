Public Class frmUser

    Dim user_id As Integer = 0
    Dim allowMove As Boolean = False
    Dim movePosition As New Point

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Close()
    End Sub

    Private Sub GunaClear_btn_Click(sender As Object, e As EventArgs) Handles GunaClear_btn.Click
        SampleUser_txt.Clear()
        SamplePass_txt.Clear()
        NewUser_txt.Clear()
        NewPass_txt.Clear()
        Confirm_txt.Clear()
        For i As Integer = 0 To Access_CheckB.Items.Count - 1
            Access_CheckB.SetItemChecked(i, False)
        Next
    End Sub

    Private Sub GunaSave_btn_Click(sender As Object, e As EventArgs) Handles GunaSave_btn.Click

        If Not validSave() Then Exit Sub

        SaveUserDetails(SampleUser_txt.Text, NewUser_txt.Text, NewPass_txt.Text)

        If SampleUser_txt.Text = NewUser_txt.Text And SamplePass_txt.Text = NewPass_txt.Text Then

            Dim namee As String = GetData("USER_FULLNAME", $"PAYROLL_USER where USERNAME = '{SampleUser_txt.Text}'")
            Dim oldUser As String = GetData("USERNAME", $"PAYROLL_USER where USERNAME = '{SampleUser_txt.Text}'")
            Dim oldPass As String = GetData("PASSWORD", $"PAYROLL_USER where USERNAME = '{SampleUser_txt.Text}'")

            RunCommand($"DELETE FROM PAYROLL_USER WHERE USER_FULLNAME = '{namee}' and USERNAME = '{oldUser}'  and PASSWORD = '{oldPass}' and ID <> '{user_id}'")  'TO DELETE DUPLICATE IN PAYROLL_USER 
        Else
            Replacing($"PAYROLL_USER where USERNAME = '{SampleUser_txt.Text}' AND PASSWORD = '{EncryptString(SamplePass_txt.Text)}';")
        End If

        '===================== ACCESSIBILITY =================== 
        Replacing($"PAYROLL_ACCESSIBILITY WHERE USER_ID = '{user_id}'")

        For i = 0 To Access_CheckB.Items.Count - 1
            Dim Item As Object = Access_CheckB.Items(i)

            If Not Access_CheckB.GetItemChecked(i) Then
                Save_Accessibility(user_id, Access_CheckB.Items(i).ToString)
            End If

        Next

        GunaClear_btn.PerformClick()

    End Sub

    Private Sub SampleUser_txt_TextChanged(sender As Object, e As EventArgs) Handles SampleUser_txt.TextChanged, SamplePass_txt.TextChanged
        If SampleUser_txt.Text <> Nothing And SamplePass_txt.Text <> Nothing Then
            user_id = GetData_Integer("ID", $"PAYROLL_USER where USERNAME = '{SampleUser_txt.Text}' AND PASSWORD = '{EncryptString(SamplePass_txt.Text)}'")
        End If
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

    Private Sub frmUser_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        allowMove = True
        movePosition = New Point(e.X, e.Y)
        Cursor = Cursors.SizeAll
    End Sub

    Private Sub frmUser_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        If allowMove = True Then
            Me.Location = New Point(Me.Location.X + e.X - movePosition.X, Me.Location.Y + e.Y - movePosition.Y)
        End If
    End Sub

    Private Sub frmUser_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp
        allowMove = False
        Cursor = Cursors.Default
    End Sub
End Class