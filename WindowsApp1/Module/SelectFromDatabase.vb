Imports FirebirdSql.Data.FirebirdClient

Module SelectFromDatabase

    Friend Sub REGULDARHolidayLists(LV As ListView)
        Dim sql As String = "select  DATEE, NAME from PAYROLL_HOLIDAY where KINDS = 'REGULAR' "

        Using rdr As FbDataReader = LoadSQL_byDataReader(sql)
            LV.Items.Clear()

            While rdr.Read()
                If rdr.HasRows Then
                    With rdr
                        Dim i As ListViewItem = LV.Items.Add(.Item("DATEE"))
                        i.SubItems.Add(.Item("NAME"))
                    End With
                End If
            End While
        End Using
    End Sub

    Friend Sub SPECIALHolidayLists(LV As ListView)
        Dim sql As String = "select DATEE, NAME from PAYROLL_HOLIDAY where KINDS = 'SPECIAL' "

        Using rdr As FbDataReader = LoadSQL_byDataReader(sql)
            LV.Items.Clear()

            While rdr.Read()
                If rdr.HasRows Then
                    With rdr
                        Dim i As ListViewItem = LV.Items.Add(.Item("DATEE"))
                        i.SubItems.Add(.Item("NAME"))
                    End With
                End If
            End While
        End Using
    End Sub


    Friend Sub AllowanceDeductionDetails(biometric As String, namee As TextBox, yess As RadioButton,
                             ratee As TextBox, boarding As TextBox, carekit As TextBox,
                             positional As TextBox, Transport As TextBox, Medical As TextBox,
                             OtherAllowance As TextBox, CashAdvance As TextBox, Savings As TextBox,
                             Loan As TextBox, Charges As TextBox, Meal As TextBox, OtherDeduction As TextBox)
        Dim mysql As String

        mysql = "Select * From tbl_Employee WHERE BIOMETRICID= '" & biometric & "'"
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

                    namee.Text = .Item("FIRSTNAME") & " " & MI & " " & .Item("LASTNAME") & " " & .Item("SUFFIX")
                    namee.Tag = .Item("ID")
                End With
            End If

        End Using

        mysql = "Select * From payroll_allow_deduc WHERE EMP_ID = '" & namee.Tag & "'"
        Using ds As DataSet = LoadSQL(mysql, "payroll_allow_deduc")

            If ds.Tables(0).Rows.Count > 0 Then
                Dim data As DataRow = ds.Tables(0).Rows(0)
                With data

                    If .Item("FIX_RATE") = "YES" Then
                        yess.Checked = True
                    Else
                        yess.Checked = False
                    End If

                    ratee.Text = .Item("DAILY_SALARY")
                    boarding.Text = .Item("BOARDING_ALLOWANCE")
                    carekit.Text = .Item("CAREKIT_ALLOWANCE")
                    positional.Text = .Item("POSITIONAL_ALLOWANCE")
                    Transport.Text = .Item("TRANSPO_ALLOWANCE")
                    Medical.Text = .Item("MEDICAL_ALLOWANCE")
                    OtherAllowance.Text = .Item("OTHER_ALLOWANCE")

                    CashAdvance.Text = .Item("CASH_ADVANCE")
                    Savings.Text = .Item("SAVINGS_DEDUCTION")
                    Loan.Text = .Item("LOANS_DEDUCTION")
                    Charges.Text = .Item("CHARGES_DEDUCTION")
                    Meal.Text = .Item("MEAL_DEDUCTION")
                    OtherDeduction.Text = .Item("OTHER_DEDUCTION")

                End With
            End If

        End Using
    End Sub


    Friend Function isNotExistHoliday(datee As String)
        Dim mysql As String = "SELECT * FROM PAYROLL_HOLIDAY Where DATEE = '" & datee & "'"
        Dim ds As DataSet = LoadSQL(mysql, "PAYROLL_HOLIDAY")
        If ds.Tables(0).Rows.Count > 0 Then
            Return False
        End If

        Return True
    End Function


    Friend Function HolidayExist(datee As String)
        Dim mysql As String = "SELECT * FROM PAYROLL_HOLIDAY Where DATEE = '" & datee & "' "
        Dim ds As DataSet = LoadSQL(mysql, "PAYROLL_HOLIDAY")

        If ds.Tables(0).Rows.Count > 0 Then
            Return True
        End If

        Return False
    End Function

    Friend Sub HolidayDetails(datee As String, rowID As Integer, dategrid As DataGridView)
        Dim mysql As String = "SELECT * FROM PAYROLL_HOLIDAY Where DATEE = '" & datee & "' "
        Dim ds As DataSet = LoadSQL(mysql, "PAYROLL_HOLIDAY")

        If ds.Tables(0).Rows.Count > 0 Then

            Dim data As DataRow = ds.Tables(0).Rows(0)
            With data

                Dim r As DataGridViewRow = dategrid.Rows(rowID)
                If .Item("KINDS") = "REGULAR" Then
                    r.DefaultCellStyle.BackColor = Color.MediumOrchid
                Else
                    r.DefaultCellStyle.BackColor = Color.Plum
                End If

                dategrid.Rows(rowID).Cells(0).Value = .Item("NAME")
                dategrid.Rows(rowID).Cells(1).Value = ""
                dategrid.Rows(rowID).Cells(2).Value = ""
                dategrid.Rows(rowID).Cells(3).Value = ""
                dategrid.Rows(rowID).Cells(4).Value = ""
                dategrid.Rows(rowID).Cells(5).Value = False

            End With

        End If
    End Sub

End Module
