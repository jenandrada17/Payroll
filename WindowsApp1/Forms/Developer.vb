Public Class Developer

    Private allowCoolMove As Boolean = False
    Private myCoolPoint As New Point

    Private Sub Exit_code_Click(sender As Object, e As EventArgs) Handles Exit_code.Click
        Close()
    End Sub

    Private Sub Developer_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        allowCoolMove = True
        myCoolPoint = New Point(e.X, e.Y)
        Cursor = Cursors.SizeAll
    End Sub

    Private Sub Developer_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        If allowCoolMove = True Then
            MyBase.Location = New Point(MyBase.Location.X + e.X - myCoolPoint.X, MyBase.Location.Y + e.Y - myCoolPoint.Y)
        End If
    End Sub

    Private Sub Developer_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp
        allowCoolMove = False
        Cursor = Cursors.Default
    End Sub

    Private Sub Developer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
    End Sub

    Private Sub Execute_BTN_Click(sender As Object, e As EventArgs) Handles Execute_BTN.Click

        If Password_TXT.Text <> Nothing And String_TXT.Text <> Nothing Then

            If ValidPassword(Password_TXT.Text) Then
                If ValidString(String_TXT.Text) Then
                    MsgBox("Successfully Executed.", MsgBoxStyle.Information, "Information")
                End If
            Else
                MsgBox("Invalid Password.", MsgBoxStyle.Critical, "Error")
            End If
        Else
            MsgBox("InComplete.", MsgBoxStyle.Critical, "Error")
        End If

        ''====================================== BRANCH ADDRESS FROM PAYROLL_EMPLOYEE ====================================
        'Dim mysql = "Select * From PAYROLL_CITY_BRANCH A INNER JOIN PAYROLL_EMPLOYEE B ON B.BRANCH_CODE = A.BRANCHCODE"
        'Using ds As DataSet = LoadSQL(mysql)

        '    If ds.Tables(0).Rows.Count > 0 Then

        '        For Each dr As DataRow In ds.Tables(0).Rows
        '            With dr

        '                Dim mysqlL As String = "Select * From PAYROLL_CITY_BRANCH Where BRANCHCODE = '" & dr.Item("BRANCH_CODE") & "'"
        '                Using dsS As DataSet = LoadSQL(mysqlL, "PAYROLL_CITY_BRANCH")
        '                    If dsS.Tables(0).Rows.Count > 0 Then
        '                        With dsS.Tables(0).Rows(0)

        '                            .Item("ADDRESS") = dr.Item("BRANCH_CITY")

        '                            SaveEntry(dsS, False)
        '                        End With
        '                    End If

        '                End Using
        '            End With
        '        Next
        '    Else
        '        Console.WriteLine("No Match")
        '    End If

        'End Using
    End Sub

    Private Function ValidString(str As String)
        Try
            RunCommand(String_TXT.Text)
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Error")
            Return False
        End Try
        Return True
    End Function

    Private Function ValidPassword(ByVal tmpPass As String) As Boolean
        Dim mysql As String = $"Select * From COMMAND_PASSWORD"
        Using ds As DataSet = LoadSQL(mysql, "COMMAND_PASSWORD")

            If ds.Tables(0).Rows(0).Item("COM_PASSWORD") <> EncryptString(tmpPass) Then
                Return False
            End If

        End Using
        Return True
    End Function


    'Private Sub SavePassword()
    '    Dim mysql As String = "Select * From COMMAND_PASSWORD Rows 1"
    '    Using dss As DataSet = LoadSQL(mysql, "COMMAND_PASSWORD")

    '        Dim dsNewRow As DataRow = dss.Tables(0).NewRow
    '        With dsNewRow

    '            .Item("COM_PASSWORD") = EncryptString(Password_TXT.Text)

    '        End With
    '        dss.Tables(0).Rows.Add(dsNewRow)
    '        SaveEntry(dss)
    '    End Using
    'End Sub
End Class