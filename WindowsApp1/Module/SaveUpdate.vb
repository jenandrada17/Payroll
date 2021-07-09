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

    Friend Sub SaveAttendance(biometric As String, paydate As String, days As String, daysHR As String, lateHR As String, lateMIN As String,
                              underHR As String, underMIN As String, absentDays As String, absentHR As String, overTime As String,
                              regHoliday As String, specHoliday As String)

        Dim mysql As String = "Select * From PAYROLL_ATTENDANCE Rows 1"
        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_ATTENDANCE")

            Dim dsNewRow As DataRow
            dsNewRow = ds.Tables(0).NewRow
            With dsNewRow

                .Item("BIOMETRICID") = biometric
                .Item("PAYDATE") = paydate
                .Item("TOTALDAYS") = days
                .Item("TOTALDAYSHOUR") = daysHR
                .Item("TOTALLATEHOUR") = lateHR
                .Item("TOTALLATEMINUTE") = lateMIN

                .Item("TOTALUTHOUR") = underHR
                .Item("TOTALUTMINUTE") = underMIN

                .Item("TOTALABSENTDAYS") = absentDays
                .Item("TOTALABSENTHOUR") = absentHR

                .Item("TOTALOVERTIME") = overTime
                .Item("TOTALREGHOLIDAY") = regHoliday
                .Item("TOTALSPECHOLIDAY") = specHoliday

            End With
            ds.Tables(0).Rows.Add(dsNewRow)
            SaveEntry(ds)
        End Using

        MsgBox("New Attendance Added!", MsgBoxStyle.Information, "Information")
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

    Public Sub SaveBiometricSheet(sheetName As String, bio As String, dateTime As String, payDate As String)

        Dim mysql As String

        mysql = "Select * FROM SAMPLE where SHEETNAME = '" & sheetName & "'"
        Dim dss As DataSet = LoadSQL(mysql, "SAMPLE")
        If dss.Tables(0).Rows.Count > 0 Then

            Dim result As DialogResult = MessageBox.Show("File already imported, Do you want to modify?", "Already Imported", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then

                With dss.Tables(0).Rows(0)

                    .Item("BIOMETRICID") = bio
                    .Item("DATEANDTIME") = dateTime
                    .Item("PAYDATE") = payDate

                End With
                SaveEntry(dss, False)
            Else
                Exit Sub
            End If
        Else

            mysql = "Select * From SAMPLE Rows 1"
            Using ds As DataSet = LoadSQL(mysql, "SAMPLE")

                Dim dsNewRow As DataRow = ds.Tables(0).NewRow
                With dsNewRow

                    .Item("BIOMETRICID") = bio
                    .Item("DATEANDTIME") = dateTime

                End With
                ds.Tables(0).Rows.Add(dsNewRow)
                SaveEntry(ds)
            End Using

        End If
    End Sub

End Module
