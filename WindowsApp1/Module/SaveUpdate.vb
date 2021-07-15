Module SaveUpdate

    Friend Sub SaveHoliday(datee As String, namee As String, kinds As String)
        Dim mysql As String = "Select * From PAYROLL_HOLIDAY Rows 1"
        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_HOLIDAY")

            Dim dsNewRow As DataRow
            dsNewRow = ds.Tables(0).NewRow
            With dsNewRow

                .Item("DATEE") = datee
                .Item("NAME") = namee
                .Item("KINDS") = kinds

            End With
            ds.Tables(0).Rows.Add(dsNewRow)
            SaveEntry(ds)
        End Using

        MsgBox("New Holiday Added!", MsgBoxStyle.Information, "Information")
    End Sub

    Friend Sub UpdateHoliday(datee As String, namee As String, kinds As String)
        Dim mysql As String = "Select * From PAYROLL_HOLIDAY Where DATEE = '" & datee & "'"
        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_HOLIDAY")

            With ds.Tables(0).Rows(0)
                .Item("NAME") = namee
                .Item("KINDS") = kinds
            End With
            SaveEntry(ds, False)
        End Using

        MsgBox("Succesfully Updated!", MsgBoxStyle.Information, "Information")
    End Sub


    Friend Sub RemoveHoliday(datee As String)
        RunCommand("DELETE FROM PAYROLL_HOLIDAY WHERE DATEE = '" & datee & "'")
    End Sub

    Friend Sub SaveAttendance(biometric As String, emp_id As String, paydate As String, days As String, daysHR As String, overTime As String, late_total As String,
                              under_total As String, absentDays As String, absentHR As String,
                              regHoliday As String, specHoliday As String)
        Dim mysql As String

        mysql = $"Select * FROM PAYROLL_ATTENDANCE where BIOMETRICID = '{biometric}' and PAYDATE = '{paydate}' and EMP_ID = '{emp_id}'"
        Dim dss As DataSet = LoadSQL(mysql, "PAYROLL_ATTENDANCE")
        If dss.Tables(0).Rows.Count > 0 Then
            With dss.Tables(0).Rows(0)

                .Item("TOTALDAYS") = days
                .Item("TOTALDAYSHOUR") = daysHR

                .Item("TOTALOVERTIME") = overTime
                .Item("TOTALLATE") = late_total
                .Item("TOTALUNDERTIME") = under_total

                .Item("TOTALABSENTDAYS") = absentDays
                .Item("TOTALABSENTHOUR") = absentHR

                .Item("TOTALREGHOLIDAY") = regHoliday
                .Item("TOTALSPECHOLIDAY") = specHoliday

            End With
            SaveEntry(dss, False)

            MsgBox("Attendance updated!", MsgBoxStyle.Information, "Information")
        Else

            mysql = "Select * From PAYROLL_ATTENDANCE Rows 1"
            Using ds As DataSet = LoadSQL(mysql, "PAYROLL_ATTENDANCE")

                Dim dsNewRow As DataRow = ds.Tables(0).NewRow
                With dsNewRow

                    .Item("BIOMETRICID") = biometric
                    .Item("EMP_ID") = emp_id
                    .Item("PAYDATE") = paydate
                    .Item("TOTALDAYS") = days
                    .Item("TOTALDAYSHOUR") = daysHR

                    .Item("TOTALOVERTIME") = overTime
                    .Item("TOTALLATE") = late_total
                    .Item("TOTALUNDERTIME") = under_total

                    .Item("TOTALABSENTDAYS") = absentDays
                    .Item("TOTALABSENTHOUR") = absentHR

                    .Item("TOTALREGHOLIDAY") = regHoliday
                    .Item("TOTALSPECHOLIDAY") = specHoliday

                End With
                ds.Tables(0).Rows.Add(dsNewRow)
                SaveEntry(ds)
            End Using

            MsgBox("New Attendance Added!", MsgBoxStyle.Information, "Information")
        End If

    End Sub


    Friend Sub SaveHOLIDAY_RATE(HOLIDAY As String, RATE As String)
        Dim mysql As String

        mysql = "Select * FROM PAYROLL_HOLIDAY_RATE where HOLIDAY = '" & HOLIDAY & "'"
        Dim dss As DataSet = LoadSQL(mysql, "PAYROLL_HOLIDAY_RATE")
        If dss.Tables(0).Rows.Count > 0 Then
            With dss.Tables(0).Rows(0)

                .Item("RATE") = RATE

            End With
            SaveEntry(dss, False)

        Else

            mysql = "Select * From PAYROLL_HOLIDAY_RATE Rows 1"
            Using ds As DataSet = LoadSQL(mysql, "PAYROLL_HOLIDAY_RATE")

                Dim dsNewRow As DataRow = ds.Tables(0).NewRow
                With dsNewRow

                    .Item("HOLIDAY") = HOLIDAY
                    .Item("RATE") = RATE

                End With
                ds.Tables(0).Rows.Add(dsNewRow)
                SaveEntry(ds)
            End Using

        End If

    End Sub

    Public Sub SaveBiometricSheet(payDate As String, bioID As String, dateTime As String, BRANCHNAME As String)

        Dim mysql As String = "Select * From IMPORT_DTR Rows 1"
        Using ds As DataSet = LoadSQL(mysql, "IMPORT_DTR")

            Dim dsNewRow As DataRow = ds.Tables(0).NewRow
            With dsNewRow

                .Item("BIO_ID") = bioID
                .Item("DATEANDTIME") = dateTime
                .Item("PAYDATE") = payDate
                .Item("BRANCH") = BRANCHNAME

            End With
            ds.Tables(0).Rows.Add(dsNewRow)
            SaveEntry(ds)
        End Using
    End Sub

    Public Sub UpdateBiometricSheet(payDate As String, bioID As String, dateTime As String, BRANCHNAME As String)

        Dim mysql As String = $"Select * FROM IMPORT_DTR where BRANCH = '{BRANCHNAME}' and PAYDATE = '{payDate}'"
        Dim dss As DataSet = LoadSQL(mysql, "IMPORT_DTR")
        If dss.Tables(0).Rows.Count > 0 Then

            With dss.Tables(0).Rows(0)

                .Item("BIO_ID") = bioID
                .Item("DATEANDTIME") = dateTime

            End With
            SaveEntry(dss, False)
        End If
    End Sub

End Module
