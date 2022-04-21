Public Class Login_Form

    Dim loginNo As Integer

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If txtUser.Text <> Nothing And txtPass.Text <> Nothing Then
            Dim user As String = validLogin(txtUser.Text, txtPass.Text)
            If user <> Nothing Then
                frmMainForm.UserName_LBL.Text = user
                loginNo = 0

                Dim idx As Integer = GetData_Integer("ID", $"PAYROLL_USER where USERNAME = '{txtUser.Text}' AND PASSWORD = '{EncryptString(txtPass.Text)}'")
                frmMainForm.Accessibility(idx)
                frmMainForm.UserName_LBL.Tag = idx

                txtUser.Clear()
                txtPass.Clear()
                Close()
            Else
                loginNo += 1
                MsgBox("Invalid Username or password", MsgBoxStyle.Critical, "Error")
            End If

        Else
            MsgBox("Please complete username and password", MsgBoxStyle.Exclamation, "Error")
        End If
    End Sub

    Friend Function validLogin(user As String, pass As String) As String
        Dim username As String = Nothing
        Dim mysql As String = $"Select * from PAYROLL_USER where USERNAME = '{user}' and PASSWORD = '{EncryptString(pass)}'"
        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_USER")
            If ds.Tables(0).Rows.Count > 0 Then
                With ds.Tables(0).Rows(0)
                    username = .Item("USER_FULLNAME")
                End With
            End If
        End Using

        Return username
    End Function

    Private Sub txtPass_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUser.KeyPress, txtPass.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            btnLogin.PerformClick()
        End If
    End Sub

    Private Sub Login_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()

        Console.WriteLine(EncryptString("jen"))
    End Sub

    Private Sub Box_X_Click(sender As Object, e As EventArgs) Handles Box_X.Click
        txtUser.Clear()
        txtPass.Clear()
        frmMainForm.Close()
    End Sub
End Class