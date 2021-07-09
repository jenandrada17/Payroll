Imports FirebirdSql.Data.FirebirdClient

Module SelectFromDatabase

    Public Function ThisHasRow(table As String)
        Dim mysql As String = "Select * FROM " & table & ""
        Dim ds As DataSet = LoadSQL(mysql, table)
        If ds.Tables(0).Rows.Count > 0 Then
            Return True
        End If
        Return False
    End Function


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


    Friend Sub AttendanceDetails(biometric As String, NoOfDays_TXT As TextBox, RegularOT_TXT As TextBox,
                             SpecialHol_TXT As TextBox, RegularHol_TXT As TextBox, Late_TXT As TextBox,
                             UnderTime_TXT As TextBox)


        Dim mysql As String = "Select * From PAYROLL_ATTENDANCE WHERE BIOMETRICID = '" & biometric & "'"
        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_ATTENDANCE")

            Dim dr As DataRow = ds.Tables(0).Rows(0)
            If dr.Table.Rows.Count > 0 Then

                With dr

                    If .Item("TOTALDAYSHOUR") = 0 Then
                        NoOfDays_TXT.Text = .Item("TOTALDAYS")
                        NoOfDays_TXT.Tag = .Item("TOTALDAYS")
                    Else
                        NoOfDays_TXT.Text = .Item("TOTALDAYS") & " and a Half Day"
                        NoOfDays_TXT.Tag = (.Item("TOTALDAYS") + 0.5).ToString
                        Console.WriteLine("Thiss " & NoOfDays_TXT.Tag)
                    End If

                    RegularOT_TXT.Text = .Item("TOTALOVERTIME")
                    SpecialHol_TXT.Text = .Item("TOTALSPECHOLIDAY")
                    RegularHol_TXT.Text = .Item("TOTALREGHOLIDAY")
                    Late_TXT.Text = .Item("TOTALLATE")
                    UnderTime_TXT.Text = .Item("TOTALUNDERTIME")
                End With
            Else
                Exit Sub
            End If

        End Using

        'mysql = "Select * From payroll_allow_deduc WHERE EMP_ID = '" & namee.Tag & "'"
        'Using ds As DataSet = LoadSQL(mysql, "payroll_allow_deduc")

        '    If ds.Tables(0).Rows.Count > 0 Then
        '        Dim data As DataRow = ds.Tables(0).Rows(0)
        '        With data

        '            If .Item("FIX_RATE") = "YES" Then
        '                yess.Checked = True
        '            Else
        '                yess.Checked = False
        '            End If

        '            ratee.Text = .Item("DAILY_SALARY")
        '            boarding.Text = .Item("BOARDING_ALLOWANCE")
        '            carekit.Text = .Item("CAREKIT_ALLOWANCE")
        '            positional.Text = .Item("POSITIONAL_ALLOWANCE")
        '            Transport.Text = .Item("TRANSPO_ALLOWANCE")
        '            Medical.Text = .Item("MEDICAL_ALLOWANCE")
        '            OtherAllowance.Text = .Item("OTHER_ALLOWANCE")

        '            CashAdvance.Text = .Item("CASH_ADVANCE")
        '            Savings.Text = .Item("SAVINGS_DEDUCTION")
        '            Loan.Text = .Item("LOANS_DEDUCTION")
        '            Charges.Text = .Item("CHARGES_DEDUCTION")
        '            Meal.Text = .Item("MEAL_DEDUCTION")
        '            OtherDeduction.Text = .Item("OTHER_DEDUCTION")

        '        End With
        '    End If

        'End Using
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


    Friend Sub HolidayRate(regularRate As TextBox, SpecialRate As TextBox)

        Dim mysql As String = "Select * From PAYROLL_HOLIDAY_RATE"
        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_HOLIDAY_RATE")

            If ds.Tables(0).Rows.Count > 0 Then
                For Each dr In ds.Tables(0).Rows
                    With dr
                        If .Item("HOLIDAY") = "REGULAR" Then
                            regularRate.Text = .Item("RATE")
                        Else
                            SpecialRate.Text = .Item("RATE")
                        End If
                    End With
                Next
            End If

        End Using



    End Sub


End Module
