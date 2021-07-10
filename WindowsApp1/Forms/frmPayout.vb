Public Class frmPayout

    Private Sub Select_BTN_Click(sender As Object, e As EventArgs) Handles Select_BTN.Click

        If frmEmployee Is Nothing Then
            Dim frm As New frmEmployee With {
                .MdiParent = frmMainForm
            }
            frmMainForm.pNavigate.Controls.Add(frm)
            frmMainForm.pNavigate.Tag = frm
            frm.txtSearch.Tag = "Payout"
            frm.Show()
            frm.Dock = DockStyle.Fill
            frm.BringToFront()
        Else
            frmEmployeeInfo.BringToFront()
        End If

        Close()
    End Sub


    Private Sub BiometricID_TXT_TextChanged(sender As Object, e As EventArgs) Handles BiometricID_TXT.TextChanged

        If BiometricID_TXT.Text = "" Then
            Name_TXT.Text = ""
        Else

            Dim mysql As String = "Select * From tbl_Employee WHERE BIOMETRICID= '" & BiometricID_TXT.Text & "'"
            Using ds As DataSet = LoadSQL(mysql, "tbl_Employee")

                If ds.Tables(0).Rows.Count > 0 Then

                    Dim data As DataRow = ds.Tables(0).Rows(0)

                    With data

                        Dim MI As String

                        If String.IsNullOrEmpty(.Item("MIDDLENAME")) Then
                            MI = ""
                        Else
                            MI = .Item("MIDDLENAME").Substring(0, 1) & "."
                        End If

                        Name_TXT.Text = .Item("FIRSTNAME") & " " & MI & " " & .Item("LASTNAME") & " " & .Item("SUFFIX")
                        Name_TXT.Tag = .Item("ID")
                    End With
                Else
                    Name_TXT.Text = ""
                End If
            End Using

        End If

    End Sub

    Private Sub Close_LBL_Click_1(sender As Object, e As EventArgs) Handles Close_LBL.Click
        Close()
    End Sub

    Private Sub Calculate_BTN_Click(sender As Object, e As EventArgs) Handles Calculate_BTN.Click

        If Not BiometricID_TXT.Text = "" And Not PayDate_DTP.Value = Date.Now Then

            Dim mysql As String = "Select * From payroll_attendance WHERE BIOMETRICID= '" & BiometricID_TXT.Text & "' and PAYDATE = '" & PayDate_DTP.Value.ToString("dd/MM/yyyy") & "'"
            Using ds As DataSet = LoadSQL(mysql, "payroll_attendance")

                If ds.Tables(0).Rows.Count > 0 Then
                    Dim data As DataRow = ds.Tables(0).Rows(0)
                    With data

                        NoOfDays_TXT.Text = .Item("TOTALDAYS")
                        Late_TXT.Text = .Item("TOTALLATEMINUTE")  '========== Minutes only
                        UnderTime_TXT.Text = .Item("TOTALUTMINUTE")

                    End With
                End If

            End Using
        End If
    End Sub

    Private Sub Name_TXT_TextChanged(sender As Object, e As EventArgs) Handles Name_TXT.TextChanged
        If String.IsNullOrEmpty(Name_TXT.Text) Then
        Else

            AttendanceDetails(BiometricID_TXT.Text, NoOfDays_TXT, RegularOT_TXT, SpecialHol_TXT, RegularHol_TXT,
                                    Late_TXT, UnderTime_TXT)
        End If
    End Sub

    Private Sub Rate_TXT_TextChanged(sender As Object, e As EventArgs) Handles Rate_TXT.TextChanged
        If Rate_TXT.Text = "" Then
            TotalBasic_LBL.Text = 0
        Else
            TotalBasic_LBL.Text = (NoOfDays_TXT.Tag * Rate_TXT.Text).ToString
            TotalOT_LBL.Text = ((Rate_TXT.Text / 8) * RegularOT_TXT.Text).ToString
        End If
    End Sub
End Class