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

    Friend Sub SaveAttendanceEE(biometric As Integer, paydate As String, days As String, overTime As String, late_total As String,
                              under_total As String, regHoliday As String, specHoliday As String, branch As String)
        Dim mysql As String

        mysql = $"Select * FROM PAYROLL_ATTENDANCE where BIOMETRICID = '{biometric}' and PAYDATE = '{paydate}' and BRANCH = '{branch}'"
        Dim dss As DataSet = LoadSQL(mysql, "PAYROLL_ATTENDANCE")
        If dss.Tables(0).Rows.Count > 0 Then
            With dss.Tables(0).Rows(0)

                .Item("PRESENT_DAYS") = days

                .Item("OVERTIME") = overTime
                .Item("LATE") = late_total
                .Item("UNDERTIME") = under_total

                '.Item("ABSENT_DAYS") = absentDays

                .Item("REGHOLIDAY") = regHoliday
                .Item("SPECHOLIDAY") = specHoliday

                .Item("BRANCH") = branch

            End With
            SaveEntry(dss, False)
        Else

            mysql = "Select * From PAYROLL_ATTENDANCE Rows 1"
            Using ds As DataSet = LoadSQL(mysql, "PAYROLL_ATTENDANCE")

                Dim dsNewRow As DataRow = ds.Tables(0).NewRow
                With dsNewRow

                    .Item("BIOMETRICID") = biometric
                    .Item("PAYDATE") = paydate

                    .Item("PRESENT_DAYS") = days

                    .Item("OVERTIME") = overTime
                    .Item("LATE") = late_total
                    .Item("UNDERTIME") = under_total

                    '.Item("ABSENT_DAYS") = absentDays

                    .Item("REGHOLIDAY") = regHoliday
                    .Item("SPECHOLIDAY") = specHoliday

                    .Item("BRANCH") = branch

                End With
                ds.Tables(0).Rows.Add(dsNewRow)
                SaveEntry(ds)
            End Using
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


    Public Sub SaveSheet_FC200(payDate As String, bioID As String, datee As String, BRANCHNAME As String)

        Dim mysql As String = "Select * From IMPORT_DTR Rows 1"
        Using ds As DataSet = LoadSQL(mysql, "IMPORT_DTR")

            Dim dsNewRow As DataRow = ds.Tables(0).NewRow
            With dsNewRow

                .Item("BIO_ID") = bioID
                .Item("DATEANDTIME") = datee
                .Item("PAYDATE") = payDate
                .Item("BRANCH") = BRANCHNAME

            End With
            ds.Tables(0).Rows.Add(dsNewRow)
            SaveEntry(ds)
        End Using
    End Sub

    'Public Sub UpdateBiometricSheet(payDate As String, bioID As String, dateTime As String, BRANCHNAME As String)

    '    Dim mysql As String = $"Select * FROM IMPORT_DTR where BRANCH = '{BRANCHNAME}' and PAYDATE = '{payDate}'"
    '    Dim dss As DataSet = LoadSQL(mysql, "IMPORT_DTR")
    '    If dss.Tables(0).Rows.Count > 0 Then

    '        With dss.Tables(0).Rows(0)

    '            .Item("BIO_ID") = bioID
    '            .Item("DATEANDTIME") = dateTime

    '        End With
    '        SaveEntry(dss, False)
    '    End If
    'End Sub

    Public Sub SaveDTR(bioID As String, payDate As String, DATE_ONLY As String, BRANCH As String, AM_IN As String, AM_OUT As String, PM_IN As String, PM_OUT As String)

        Dim mysql As String = "Select * From BIOMETRIC_DTR Rows 1"
        Using dss As DataSet = LoadSQL(mysql, "BIOMETRIC_DTR")

            Dim dsNewRow As DataRow = dss.Tables(0).NewRow
            With dsNewRow

                .Item("BIO_ID") = bioID
                .Item("PAYDATE") = payDate
                .Item("DATE_ONLY") = DATE_ONLY
                .Item("BRANCH") = BRANCH
                .Item("AM_IN") = AM_IN
                .Item("AM_OUT") = AM_OUT
                .Item("PM_IN") = PM_IN
                .Item("PM_OUT") = PM_OUT

            End With
            dss.Tables(0).Rows.Add(dsNewRow)
            SaveEntry(dss)
        End Using

    End Sub


    Public Sub UpdateDTR(bioID As String, payDate As String, DATE_ONLY As String, BRANCH As String, AM_IN As String, AM_OUT As String, PM_IN As String, PM_OUT As String)

        Dim mysql As String = $"Select * FROM BIOMETRIC_DTR where BRANCH = '{BRANCH}' and PAYDATE = '{payDate}'"
        Dim dss As DataSet = LoadSQL(mysql, "BIOMETRIC_DTR")
        If dss.Tables(0).Rows.Count > 0 Then

            With dss.Tables(0).Rows(0)

                .Item("BIO_ID") = bioID
                .Item("DATE_ONLY") = DATE_ONLY
                .Item("AM_IN") = AM_IN
                .Item("AM_OUT") = AM_OUT
                .Item("PM_IN") = PM_IN
                .Item("PM_OUT") = PM_OUT

            End With
            SaveEntry(dss, False)
        End If
    End Sub

    Public Sub SaveIndividual(bioID As String, payDate As String, DATE_ONLY As String, BRANCH As String, hour As String, column As String)
        Dim mysql As String

        mysql = $"Select * FROM BIOMETRIC_DTR where BIO_ID = '{bioID}' and DATE_ONLY = '{DATE_ONLY}' and BRANCH = '{BRANCH}' and PAYDATE = '{payDate}'"
        Dim ds As DataSet = LoadSQL(mysql, "BIOMETRIC_DTR")
        If ds.Tables(0).Rows.Count > 0 Then

            With ds.Tables(0).Rows(0)

                .Item(column) = hour

            End With
            SaveEntry(ds, False)

        Else

            mysql = "Select * From BIOMETRIC_DTR Rows 1"
            Using dss As DataSet = LoadSQL(mysql, "BIOMETRIC_DTR")

                Dim dsNewRow As DataRow = dss.Tables(0).NewRow
                With dsNewRow

                    .Item("BIO_ID") = bioID
                    .Item("PAYDATE") = payDate
                    .Item("DATE_ONLY") = DATE_ONLY
                    .Item("BRANCH") = BRANCH
                    .Item(column) = hour

                End With
                dss.Tables(0).Rows.Add(dsNewRow)
                SaveEntry(dss)
            End Using
        End If

    End Sub

    Friend Sub SaveRATE(value As String, column As String, amount As String, moreThan As Boolean, Optional branchID As String = "") '=========== BOOLEAN IF MORE THAN 1 ==========

        Dim mysql As String

        If moreThan = True Then '============= PER BRANCH OR PER POSITION ==============

            mysql = $"Select * FROM TBL_EMPLOYEE where {column} = '{value}'"
            Dim dss As DataSet = LoadSQL(mysql, "TBL_EMPLOYEE")
            If dss.Tables(0).Rows.Count > 0 Then
                For Each dr In dss.Tables(0).Rows
                    With dr

                        .Item("RATE") = amount

                    End With
                    SaveEntry(dss, False)
                Next

                MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Information")
            End If

        Else  '============ PER EMPLOYEE (FOR THERE ARE SAME BIOMETRIC NUMBER BUT DIFFERENT NAME/EMPLOYEE) ===========

            mysql = $"Select * FROM TBL_EMPLOYEE where {column} = '{value}' and BRANCH_ID = '{branchID}'"
            Dim dss As DataSet = LoadSQL(mysql, "TBL_EMPLOYEE")
            If dss.Tables(0).Rows.Count > 0 Then
                With dss.Tables(0).Rows(0)

                    .Item("RATE") = amount

                End With
                SaveEntry(dss, False)

                MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Information")
            End If

        End If
    End Sub

    Friend Sub SaveAllowance(bioNo As String, branchID As String, categoryColumn As String, amount As String, fix As Boolean)
        Dim mysql As String

        mysql = $"Select * FROM PAYROLL_ALLOWANCE where BIOMETRIC_NO = '{bioNo}' and BRANCH_ID = '{branchID}'"
        Dim ds As DataSet = LoadSQL(mysql, "PAYROLL_ALLOWANCE")
        If ds.Tables(0).Rows.Count > 0 Then

            With ds.Tables(0).Rows(0)

                .Item(categoryColumn) = amount
                .Item("ALLOWED") = DBNull.Value

                If fix Then
                    .Item("fix") = "FIX"
                End If

            End With
            SaveEntry(ds, False)

            MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Information")

        Else
            mysql = "Select * From PAYROLL_ALLOWANCE Rows 1"
            Using dss As DataSet = LoadSQL(mysql, "PAYROLL_ALLOWANCE")

                Dim dsNewRow As DataRow = dss.Tables(0).NewRow
                With dsNewRow

                    .Item("BIOMETRIC_NO") = bioNo
                    .Item("BRANCH_ID") = branchID
                    .Item(categoryColumn) = amount

                    If fix Then
                        .Item("fix") = "FIX"
                    End If

                End With
                dss.Tables(0).Rows.Add(dsNewRow)
                SaveEntry(dss)

                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Information")
            End Using
        End If

    End Sub

    Friend Sub AllowanceRemove(bioNo As String, branchID As String, category As String)
        Dim mysql As String

        mysql = $"Select * FROM PAYROLL_ALLOWANCE where BIOMETRIC_NO = '{bioNo}' and BRANCH_ID = '{branchID}'"
        Dim ds As DataSet = LoadSQL(mysql, "PAYROLL_ALLOWANCE")
        If ds.Tables(0).Rows.Count > 0 Then

            With ds.Tables(0).Rows(0)

                .Item("ALLOWED") = "NO"

            End With
            SaveEntry(ds, False)

            MsgBox("Successfully Removed from the list!", MsgBoxStyle.Information, "Information")
        End If

    End Sub


    'Friend Sub SaveDeduction(bioNo As String, branchID As String, categoryColumn As String, amount As String)
    '    Dim mysql As String

    '    mysql = $"Select * FROM PAYROLL_DEDUCTION where BIOMETRIC_NO = '{bioNo}' and BRANCH_ID = '{branchID}'"
    '    Dim ds As DataSet = LoadSQL(mysql, "PAYROLL_DEDUCTION")
    '    If ds.Tables(0).Rows.Count > 0 Then

    '        With ds.Tables(0).Rows(0)

    '            .Item(categoryColumn) = amount

    '        End With
    '        SaveEntry(ds, False)

    '        MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Information")

    '    Else
    '        mysql = "Select * From PAYROLL_DEDUCTION Rows 1"
    '        Using dss As DataSet = LoadSQL(mysql, "PAYROLL_DEDUCTION")

    '            Dim dsNewRow As DataRow = dss.Tables(0).NewRow
    '            With dsNewRow

    '                .Item("BIOMETRIC_NO") = bioNo
    '                .Item("BRANCH_ID") = branchID
    '                .Item(categoryColumn) = amount

    '            End With
    '            dss.Tables(0).Rows.Add(dsNewRow)
    '            SaveEntry(dss)

    '            MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Information")
    '        End Using
    '    End If

    'End Sub


    Friend Sub SaveDeductionS(bioNo As String, branchID As String, category As String, TOTAL_AMOUNT As String, NO_OF_GIVES As String, AMOUNT_PER_GIVE As String)
        Dim mysql As String

        mysql = $"Select * FROM PAYROLL_DEDUCTIONS where BIOMETRIC_NO = '{bioNo}' and BRANCHID = '{branchID}' and CATEGORY = '{category}'"
        Dim ds As DataSet = LoadSQL(mysql, "PAYROLL_DEDUCTIONS")
        If ds.Tables(0).Rows.Count > 0 Then

            With ds.Tables(0).Rows(0)

                .Item("TOTAL_AMOUNT") = TOTAL_AMOUNT
                .Item("NO_OF_GIVES") = NO_OF_GIVES
                .Item("AMOUNT_PER_GIVE") = AMOUNT_PER_GIVE

            End With
            SaveEntry(ds, False)

            MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Information")

        Else
            mysql = "Select * From PAYROLL_DEDUCTIONS Rows 1"
            Using dss As DataSet = LoadSQL(mysql, "PAYROLL_DEDUCTIONS")

                Dim dsNewRow As DataRow = dss.Tables(0).NewRow
                With dsNewRow

                    .Item("BIOMETRIC_NO") = bioNo
                    .Item("BRANCHID") = branchID
                    .Item("CATEGORY") = category
                    .Item("TOTAL_AMOUNT") = TOTAL_AMOUNT
                    .Item("NO_OF_GIVES") = NO_OF_GIVES
                    .Item("AMOUNT_PER_GIVE") = AMOUNT_PER_GIVE

                End With
                dss.Tables(0).Rows.Add(dsNewRow)
                SaveEntry(dss)

                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Information")
            End Using
        End If

    End Sub

    Friend Sub SaveSBU(amount As String)
        Dim mysql As String

        mysql = $"Select * FROM PAYROLL_SBU WHERE id = 1 "
        Dim ds As DataSet = LoadSQL(mysql, "PAYROLL_SBU")
        If ds.Tables(0).Rows.Count > 0 Then

            With ds.Tables(0).Rows(0)

                .Item("AMOUNT") = amount

            End With
            SaveEntry(ds, False)

            MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Information")

        Else
            mysql = "Select * From PAYROLL_SBU Rows 1"
            Using dss As DataSet = LoadSQL(mysql, "PAYROLL_SBU")

                Dim dsNewRow As DataRow = dss.Tables(0).NewRow
                With dsNewRow

                    .Item("AMOUNT") = amount

                End With
                dss.Tables(0).Rows.Add(dsNewRow)
                SaveEntry(dss)

                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Information")
            End Using
        End If

    End Sub


    Friend Sub SavePayout(BIOMETRIC_ID As String, BRANCH_ID As String, PAYDATE As String, TOTAL_BASIC As String, TOTAL_OVERTIME As String, TOTAL_LATE_UT As String,
                          GROSS_AMOUNT As String, SSS_COMP As String, PAGIBIG_COMP As String, PHILHEALTH_COMP As String, TAXABLE As String,
                          TAX_WHELD As String, NET_TAX_COMP As String, SSS_LOAN As String, PAGIBIG_LOAN As String, TOTAL_ALLOWANCE As String,
                          TOTAL_DEDUCTION As String, NET_PAY As String, Optional all As Boolean = False)

        Dim mysql As String

        mysql = $"Select * FROM PAYROLL_PAYOUT where BIOMETRIC_ID = '{BIOMETRIC_ID}' and BRANCH_ID = '{BRANCH_ID}' and PAYDATE = '{PAYDATE}'"
        Dim dss As DataSet = LoadSQL(mysql, "PAYROLL_PAYOUT")
        If dss.Tables(0).Rows.Count > 0 Then
            For Each dr In dss.Tables(0).Rows
                With dr

                    .Item("TOTAL_BASIC") = TOTAL_BASIC
                    .Item("TOTAL_OVERTIME") = TOTAL_OVERTIME
                    .Item("TOTAL_LATE_UT") = TOTAL_LATE_UT
                    .Item("GROSS_AMOUNT") = GROSS_AMOUNT
                    .Item("SSS_COMP") = SSS_COMP
                    .Item("PAGIBIG_COMP") = PAGIBIG_COMP
                    .Item("PHILHEALTH_COMP") = PHILHEALTH_COMP
                    .Item("TAXABLE") = TAXABLE
                    .Item("TAX_WHELD") = TAX_WHELD
                    .Item("NET_TAX_COMP") = NET_TAX_COMP
                    .Item("SSS_LOAN") = SSS_LOAN
                    .Item("PAGIBIG_LOAN") = PAGIBIG_LOAN
                    .Item("TOTAL_ALLOWANCE") = TOTAL_ALLOWANCE
                    .Item("TOTAL_DEDUCTION") = TOTAL_DEDUCTION
                    .Item("NET_PAY") = NET_PAY

                End With
                SaveEntry(dss, False)
            Next

            If all = False Then
                MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Information")
            End If

        Else
            mysql = "Select * From PAYROLL_PAYOUT Rows 1"
            Using ds As DataSet = LoadSQL(mysql, "PAYROLL_PAYOUT")

                Dim dsNewRow As DataRow = ds.Tables(0).NewRow
                With dsNewRow

                    .Item("BIOMETRIC_ID") = BIOMETRIC_ID
                    .Item("BRANCH_ID") = BRANCH_ID
                    .Item("TOTAL_BASIC") = TOTAL_BASIC
                    .Item("TOTAL_OVERTIME") = TOTAL_OVERTIME
                    .Item("TOTAL_LATE_UT") = TOTAL_LATE_UT
                    .Item("GROSS_AMOUNT") = GROSS_AMOUNT
                    .Item("SSS_COMP") = SSS_COMP
                    .Item("PAGIBIG_COMP") = PAGIBIG_COMP
                    .Item("PHILHEALTH_COMP") = PHILHEALTH_COMP
                    .Item("TAXABLE") = TAXABLE
                    .Item("TAX_WHELD") = TAX_WHELD
                    .Item("NET_TAX_COMP") = NET_TAX_COMP
                    .Item("SSS_LOAN") = SSS_LOAN
                    .Item("PAGIBIG_LOAN") = PAGIBIG_LOAN
                    .Item("TOTAL_ALLOWANCE") = TOTAL_ALLOWANCE
                    .Item("TOTAL_DEDUCTION") = TOTAL_DEDUCTION
                    .Item("NET_PAY") = NET_PAY
                    .Item("PAYDATE") = PAYDATE

                End With
                ds.Tables(0).Rows.Add(dsNewRow)
                SaveEntry(ds)

                If all = False Then
                    MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Information")
                End If

            End Using
        End If


    End Sub


End Module
