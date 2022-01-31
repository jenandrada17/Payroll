Imports System.Globalization

Module SaveUpdate

    Dim STANDARD_DAYS As Integer = frmMainForm.DAYS_COUNT

    Friend Sub SaveHoliday(datee As String, namee As String, kinds As String)
        Dim mysql As String = "Select * From PAYROLL_HOLIDAY Rows 1"
        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_HOLIDAY")

            Dim dsNewRow As DataRow = ds.Tables(0).NewRow
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

    'Friend Sub SaveAttendanceEE(biometric As Integer, paydate As String, days As String, overTime As String, late_total As String,
    '                              under_total As String, regHoliday As String, specHoliday As String, Optional SIL As Double = 0, Optional NIGHT_RATE As String = "")

    Friend Sub SaveAttendanceEE(biometric As Integer, paydate As String, days As String, overTime As String, late_total As String,
                                      under_total As String, regHoliday As String, specHoliday As String, Optional SIL As Double = 0, Optional MORNING_OT As String = "", Optional NIGHT_RATE As String = "")

        Dim mysql As String

        mysql = $"Select * FROM PAYROLL_ATTENDANCE inner join payroll_employee on BIO_NO = BIOMETRICID where BIOMETRICID = '{biometric}' and PAYDATE = '{paydate}'"
        Dim dss As DataSet = LoadSQL(mysql, "PAYROLL_ATTENDANCE")
        If dss.Tables(0).Rows.Count > 0 Then
            For Each dr In dss.Tables(0).Rows
                With dr

                    Dim fix_monthly As Boolean = IIf(IsDBNull(.item("FIX_MONTHLY_RATE")), False, .item("FIX_MONTHLY_RATE"))

                    .Item("PRESENT_DAYS") = days
                    .Item("SIL") = SIL
                    .Item("OVERTIME") = overTime
                    .Item("LATE") = late_total
                    .Item("UNDERTIME") = under_total
                    .Item("REGHOLIDAY") = regHoliday
                    .Item("SPECHOLIDAY") = specHoliday
                    .Item("TRAINING_DAYS") = 0
                    .Item("TRAINING_REGHOLIDAY") = 0
                    .Item("TRAINING_SPECHOLIDAY") = 0
                    '.Item("TRAINING_OVERTIME") = 0
                    '.Item("TRAINING_LATE") = 0
                    '.Item("TRAINING_UNDERTIME") = 0

                    If NIGHT_RATE <> Nothing Then
                        .Item("NIGHT_RATE") = NIGHT_RATE
                    End If

                    If MORNING_OT <> Nothing Then
                        .Item("MORNING_OT") = MORNING_OT
                    End If

                End With
                SaveEntry(dss, False)
            Next
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
                    .Item("REGHOLIDAY") = regHoliday
                    .Item("SPECHOLIDAY") = specHoliday
                    .Item("SIL") = SIL
                    .Item("TRAINING_DAYS") = 0
                    .Item("TRAINING_REGHOLIDAY") = 0
                    .Item("TRAINING_SPECHOLIDAY") = 0
                    '.Item("TRAINING_OVERTIME") = 0
                    '.Item("TRAINING_LATE") = 0
                    '.Item("TRAINING_UNDERTIME") = 0

                    If NIGHT_RATE <> Nothing Then
                        .Item("NIGHT_RATE") = NIGHT_RATE
                    End If

                    If MORNING_OT <> Nothing Then
                        .Item("MORNING_OT") = MORNING_OT
                    End If

                End With
                ds.Tables(0).Rows.Add(dsNewRow)
                SaveEntry(ds)
            End Using
        End If
    End Sub

    Friend Sub SaveHOLIDAY_RATE(HOLIDAY As String, RATE As String)
        Dim mysql As String
        RATE = CDbl(RATE) / 100

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

    Public Sub Update_DEDUCTION_LOANS_STATUS(deduc_id As String, table As String)

        Dim mysql As String = $"Select * From {table} where ID = '{deduc_id}'"
        Using ds As DataSet = LoadSQL(mysql, table)
            If ds.Tables(0).Rows.Count > 0 Then
                With ds.Tables(0).Rows(0)
                    .Item("STATUS") = "PAID"
                End With
                SaveEntry(ds, False)
            End If
        End Using

    End Sub

    Public Sub SaveBiometricSheet(payDate As String, bioID As String, dateTime As String)
        Dim mysql As String = "Select * From IMPORT_DTR Rows 1"
        Using ds As DataSet = LoadSQL(mysql, "IMPORT_DTR")

            Dim dsNewRow As DataRow = ds.Tables(0).NewRow
            With dsNewRow

                .Item("BIO_ID") = bioID
                .Item("DATEANDTIME") = dateTime
                .Item("PAYDATE") = payDate

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

    Public Sub SaveDTR(bioID As String, payDate As String, DATE_ONLY As String, AM_IN As String, AM_OUT As String, PM_IN As String, PM_OUT As String, Optional dtr As Boolean = False)

        If dtr = False Then
            RunCommand($"DELETE FROM BIOMETRIC_DTR WHERE BIO_ID = '{bioID}' AND  PAYDATE = '{payDate}' AND DATE_ONLY = '{DATE_ONLY}'")
        End If

        Dim mysql As String = "Select * From BIOMETRIC_DTR Rows 1"
        Using dss As DataSet = LoadSQL(mysql, "BIOMETRIC_DTR")

            Dim dsNewRow As DataRow = dss.Tables(0).NewRow
            With dsNewRow

                .Item("BIO_ID") = bioID
                .Item("PAYDATE") = payDate
                .Item("DATE_ONLY") = DATE_ONLY
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

    'Friend Sub SaveRATE(value As String, column As String, amount As String, moreThan As Boolean) '=========== BOOLEAN IF MORE THAN 1 ========== 

    '    Dim mysql As String

    '    If moreThan = True Then '============= PER BRANCH OR PER POSITION ==============

    '        mysql = $"Select * FROM TBL_EMPLOYEE where {column} = '{value}'"
    '        Dim dss As DataSet = LoadSQL(mysql, "TBL_EMPLOYEE")
    '        If dss.Tables(0).Rows.Count > 0 Then
    '            For Each dr In dss.Tables(0).Rows
    '                With dr

    '                    .Item("DAILY_RATE") = amount

    '                End With
    '                SaveEntry(dss, False)
    '            Next

    '            MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Information")
    '        End If

    '    Else  '============ PER EMPLOYEE (FOR THERE ARE SAME BIOMETRIC NUMBER BUT DIFFERENT NAME/EMPLOYEE) ===========

    '        'mysql = $"Select * FROM TBL_EMPLOYEE where {column} = '{value}' and BRANCH_ID = '{branchID}'"

    '        mysql = $"Select * FROM TBL_EMPLOYEE where {column} = '{value}'"
    '        Dim dss As DataSet = LoadSQL(mysql, "TBL_EMPLOYEE")
    '        If dss.Tables(0).Rows.Count > 0 Then
    '            With dss.Tables(0).Rows(0)

    '                .Item("RATE") = amount

    '            End With
    '            SaveEntry(dss, False)

    '            MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Information")
    '        End If 
    '    End If
    'End Sub 

    Friend Sub SaveRATE_City(column As String, value As String, daily_rate As String, Optional group As Boolean = False) '=========== BOOLEAN IF MORE THAN 1 ========== 
        If value = "" Then
            SaveRATE("BRANCH_CODE", "", daily_rate, False, True)
            Exit Sub
        End If

        Dim mysql As String = $"Select * FROM PAYROLL_CITY_BRANCH  WHERE {column} = '{value}'"
        Dim dss As DataSet = LoadSQL(mysql, "PAYROLL_CITY_BRANCH")
        If dss.Tables(0).Rows.Count > 0 Then
            For Each dr In dss.Tables(0).Rows
                With dr
                    Dim branchCode As String = .Item("BRANCHCODE")

                    SaveRATE("BRANCH_CODE", branchCode, daily_rate, False, True)
                End With
            Next
        End If
    End Sub

    Friend Sub SaveRATE(column As String, value As String, daily_rate As String, Optional fix_monthly As Boolean = False, Optional group As Boolean = False) '=========== BOOLEAN IF MORE THAN 1 ========== 

        Dim mysql As String = $"Select * FROM  PAYROLL_EMPLOYEE WHERE {column} = '{value}'"
        Dim dss As DataSet = LoadSQL(mysql, "PAYROLL_EMPLOYEE")
        If dss.Tables(0).Rows.Count > 0 Then

            progressBarStart(dss.Tables(0).Rows.Count)
            For Each dr In dss.Tables(0).Rows
                With dr

                    Dim existing_rate As Decimal = IIf(IsDBNull(.Item("RATE_DAILY")), 0, .Item("RATE_DAILY"))

                    If existing_rate <= daily_rate Then
                        .Item("RATE_DAILY") = daily_rate
                        .Item("RATE_MONTHLY") = daily_rate * 26
                    End If

                    If fix_monthly = True Then
                        .item("FIX_MONTHLY_RATE") = fix_monthly
                    End If

                End With
                SaveEntry(dss, False)
                frmMainForm.AppProgressBar.Value += 1
            Next
            progressBarEnd()

            If group = False Then
                MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Information")
            End If
        End If
    End Sub

    'Friend Sub SaveRATE(column As String, value As String, daily_rate As String, Optional group As Boolean = False) '=========== BOOLEAN IF MORE THAN 1 ========== 

    '    'Dim mysql As String

    '    If group <> False Then

    '        Dim mysql As String = $"Select * FROM PAYROLL_EMPLOYEE A LEFT join PAYROLL_CITY_BRANCH B on BRANCH_CODE = BRANCHCODE AND {column} = '{value}'"
    '        Dim dss As DataSet = LoadSQL(mysql, "PAYROLL_EMPLOYEE")

    '        'Dim mysql As String = $"Select * FROM PAYROLL_CITY_BRANCH A inner join PAYROLL_EMPLOYEE B on BRANCH_CODE = A.BRANCHCODE where {column} = '{value}'"
    '        'Dim dss As DataSet = LoadSQL(mysql, "PAYROLL_CITY_BRANCH")
    '        If dss.Tables(0).Rows.Count > 0 Then
    '            For Each dr In dss.Tables(0).Rows
    '                With dr

    '                    Dim existing_rate As Double = IIf(IsDBNull(.Item("RATE_DAILY")), 0, .Item("RATE_DAILY"))

    '                    If existing_rate < daily_rate Then
    '                        .Item("RATE_DAILY") = daily_rate
    '                    End If

    '                End With
    '                SaveEntry(dss, False)
    '            Next

    '        End If
    '    Else

    '        Dim mysqll As String = $"Select * FROM PAYROLL_EMPLOYEE where {column} = '{value}'"
    '        Dim ds As DataSet = LoadSQL(mysqll, "PAYROLL_EMPLOYEE")
    '        If ds.Tables(0).Rows.Count > 0 Then

    '            With ds.Tables(0).Rows(0)
    '                Dim existing_rate As Double = IIf(IsDBNull(.Item("RATE_DAILY")), 0, .Item("RATE_DAILY"))

    '                If existing_rate < daily_rate Then
    '                    .Item("RATE_DAILY") = daily_rate
    '                End If
    '            End With
    '            SaveEntry(ds, False)
    '        End If 
    '    End If
    'End Sub

    Friend Sub SaveMinimum_RATE(value As String, MINIMUM_RATE As String, ECOLA As String) '=========== BOOLEAN IF MORE THAN 1 ========== 
        Dim mysql As String

        mysql = $"Select * FROM PAYROLL_CITY_BRANCH where CITY = '{value}'"
        Dim dss As DataSet = LoadSQL(mysql, "PAYROLL_CITY_BRANCH")
        If dss.Tables(0).Rows.Count > 0 Then
            For Each dr In dss.Tables(0).Rows
                With dr
                    .Item("MINIMUM_RATE") = MINIMUM_RATE

                    If ECOLA <> Nothing Then
                        .Item("ECOLA") = ECOLA
                    End If

                End With
                SaveEntry(dss, False)
            Next
        End If
    End Sub


    Friend Sub AllowanceRemove(id As String, value As String)
        Dim mysql As String

        mysql = $"Select * FROM PAYROLL_ALLOWANCES where id = '{id}'"
        Dim ds As DataSet = LoadSQL(mysql, "PAYROLL_ALLOWANCES")
        If ds.Tables(0).Rows.Count > 0 Then
            For Each dr In ds.Tables(0).Rows
                With dr

                    .Item("ALLOWED") = value
                    .Item("ALLOW_REMOVE_DATE") = Today

                End With
                SaveEntry(ds, False)
            Next

            MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Information")
        End If

    End Sub

    'SaveDeductionS(DEDUCT_ID, PrincipalDeduc_txt.Text, DeductAmort_txt.Text, Schedule_Combo.Text, DateCharges_DTP.Value, Name_txt.Tag) 'Category_Combo.Tag (EMP_ID) | Name_TXT.Tag(Biometric) |  SearchEmp_BTN.Tag.Tag(Branch_id) |   

    Friend Sub SaveDeductionS(deduc_id As String, category As String, PRINCIPAL As String, AMORT As String, SCHEDULE As String, DATEE As String, bioNo As String)
        Dim mysql As String

        mysql = $"Select * FROM PAYROLL_DEDUCTION where id = '{deduc_id}'"
        Dim ds As DataSet = LoadSQL(mysql, "PAYROLL_DEDUCTION")
        If ds.Tables(0).Rows.Count > 0 Then

            With ds.Tables(0).Rows(0)

                .Item("CATEGORY") = category
                .Item("PRINCIPAL") = PRINCIPAL
                .Item("AMORT") = AMORT
                .Item("CREDIT") = 0
                .Item("BALANCE") = PRINCIPAL
                .Item("SCHEDULE") = SCHEDULE
                .Item("DATEE") = DATEE

            End With
            SaveEntry(ds, False)

            MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Information")
        Else

            mysql = "Select * From PAYROLL_DEDUCTION Rows 1"
            Using dss As DataSet = LoadSQL(mysql, "PAYROLL_DEDUCTION")

                Dim dsNewRow As DataRow = dss.Tables(0).NewRow
                With dsNewRow

                    .Item("BIO_NO") = bioNo
                    .Item("CATEGORY") = category
                    .Item("PRINCIPAL") = PRINCIPAL
                    .Item("AMORT") = AMORT
                    .Item("CREDIT") = 0
                    .Item("BALANCE") = PRINCIPAL
                    .Item("SCHEDULE") = SCHEDULE
                    .Item("DATEE") = DATEE

                End With
                dss.Tables(0).Rows.Add(dsNewRow)
                SaveEntry(dss)

                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Information")
            End Using
        End If
    End Sub

    'Friend Sub updateDeductionS(deduc_id As String, category As String, PRINCIPAL As String, AMORT As String, SCHEDULE As String, DATEE As String)

    '    Dim mysql As String = $"Select * FROM PAYROLL_DEDUCTION where id = '{deduc_id}'"
    '    Dim ds As DataSet = LoadSQL(mysql, "PAYROLL_DEDUCTION")
    '    If ds.Tables(0).Rows.Count > 0 Then

    '        With ds.Tables(0).Rows(0)

    '            .Item("CATEGORY") = category
    '            .Item("PRINCIPAL") = PRINCIPAL
    '            .Item("AMORT") = AMORT
    '            .Item("SCHEDULE") = SCHEDULE
    '            .Item("DATEE") = DATEE

    '        End With
    '        SaveEntry(ds, False)

    '        MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Information")
    '    End If
    'End Sub

    Friend Sub SavePayout(BIOMETRIC_ID As String, PAYDATE As String, TOTAL_BASIC As Decimal, TOTAL_OVERTIME As Decimal, TOTAL_LATE_UT As Decimal,
                          GROSS_AMOUNT As Decimal, SSS_COMP As Decimal, SSS_ER As Decimal, SSS_EC As Decimal, PAGIBIG_COMP As Decimal, PHILHEALTH_COMP As Decimal,
                          TOTAL_ALLOWANCE As Decimal, TOTAL_DEDUCTION As Decimal, NET_PAY As Decimal, REGHOLIDAY As Decimal, SPECHOLIDAY As Decimal,
                          TOTAL_NIGHT_RATE As Decimal, Optional all As String = "")

        'Friend Sub SavePayout(BIOMETRIC_ID As String, PAYDATE As String, TOTAL_BASIC As Decimal, TOTAL_OVERTIME As Decimal, TOTAL_LATE_UT As Decimal,
        '                      GROSS_AMOUNT As Decimal, SSS_COMP As Decimal, SSS_ER As Decimal, SSS_EC As Decimal, PAGIBIG_COMP As Decimal, PHILHEALTH_COMP As Decimal,
        '                      SSS_LOAN As Decimal, PAGIBIG_LOAN As Decimal, TOTAL_ALLOWANCE As Decimal,
        '                      TOTAL_DEDUCTION As Decimal, NET_PAY As Decimal, REGHOLIDAY As Decimal, SPECHOLIDAY As Decimal, TOTAL_NIGHT_RATE As Decimal, Optional all As String = "")

        Dim mysql As String = $"Select * FROM PAYROLL_PAYOUT where BIOMETRIC_ID = '{BIOMETRIC_ID}' and PAYDATE = '{PAYDATE}'"
        Dim dss As DataSet = LoadSQL(mysql, "PAYROLL_PAYOUT")
        If dss.Tables(0).Rows.Count > 0 Then
            For Each dr In dss.Tables(0).Rows
                With dr

                    .Item("TOTAL_BASIC") = TOTAL_BASIC
                    .Item("TOTAL_OVERTIME") = TOTAL_OVERTIME
                    .Item("TOTAL_LATE_UT") = TOTAL_LATE_UT
                    .Item("GROSS_AMOUNT") = GROSS_AMOUNT
                    .Item("SSS_COMP") = SSS_COMP
                    .Item("SSS_ER") = SSS_ER
                    .Item("SSS_EC") = SSS_EC
                    .Item("PAGIBIG_COMP") = PAGIBIG_COMP
                    .Item("PHILHEALTH_COMP") = PHILHEALTH_COMP
                    '.Item("SSS_LOAN") = SSS_LOAN
                    '.Item("PAGIBIG_LOAN") = PAGIBIG_LOAN
                    .Item("TOTAL_ALLOWANCE") = TOTAL_ALLOWANCE
                    .Item("TOTAL_DEDUCTION") = TOTAL_DEDUCTION
                    .Item("NET_PAY") = NET_PAY
                    .Item("TOTAL_NIGHT_RATE") = TOTAL_NIGHT_RATE
                    .Item("TOTAL_REGHOLIDAY") = REGHOLIDAY
                    .Item("TOTAL_SPECHOLIDAY") = SPECHOLIDAY

                End With
                SaveEntry(dss, False)
            Next

        Else
            mysql = "Select * From PAYROLL_PAYOUT Rows 1"
            Using ds As DataSet = LoadSQL(mysql, "PAYROLL_PAYOUT")
                Dim dsNewRow As DataRow = ds.Tables(0).NewRow
                With dsNewRow
                    .Item("BIOMETRIC_ID") = BIOMETRIC_ID
                    .Item("TOTAL_BASIC") = TOTAL_BASIC
                    .Item("TOTAL_OVERTIME") = TOTAL_OVERTIME
                    .Item("TOTAL_LATE_UT") = TOTAL_LATE_UT
                    .Item("GROSS_AMOUNT") = GROSS_AMOUNT
                    .Item("SSS_COMP") = SSS_COMP
                    .Item("SSS_ER") = SSS_ER
                    .Item("SSS_EC") = SSS_EC
                    .Item("PAGIBIG_COMP") = PAGIBIG_COMP
                    .Item("PHILHEALTH_COMP") = PHILHEALTH_COMP
                    '.Item("TAXABLE") = TAXABLE
                    '.Item("TAX_WHELD") = TAX_WHELD
                    '.Item("NET_TAX_COMP") = NET_TAX_COMP
                    '.Item("SSS_LOAN") = SSS_LOAN
                    '.Item("PAGIBIG_LOAN") = PAGIBIG_LOAN
                    .Item("TOTAL_ALLOWANCE") = TOTAL_ALLOWANCE
                    .Item("TOTAL_DEDUCTION") = TOTAL_DEDUCTION
                    .Item("PAYDATE") = PAYDATE
                    .Item("NET_PAY") = NET_PAY
                    .Item("TOTAL_NIGHT_RATE") = TOTAL_NIGHT_RATE
                    .Item("TOTAL_REGHOLIDAY") = REGHOLIDAY
                    .Item("TOTAL_SPECHOLIDAY") = SPECHOLIDAY

                End With

                ds.Tables(0).Rows.Add(dsNewRow)
                SaveEntry(ds)
            End Using
        End If
    End Sub

    Friend Sub SavePayout_MODIFIED_DEDUCTION(BIO_NO As String, PAYDATE As String, CATEGORY As String, M_Amount As String, AMOUNT_PER_GIVE As String, DATE_CREATED As String, M_DEDUC_ID As String)

        Dim mysql As String = "Select * From MODIFIED_DEDUCTION Rows 1"
        Using ds As DataSet = LoadSQL(mysql, "MODIFIED_DEDUCTION")
            Dim dsNewRow As DataRow = ds.Tables(0).NewRow
            With dsNewRow

                Dim toUpper = CATEGORY.ToUpper()

                .Item("BIO_NO") = BIO_NO
                .Item("PAYDATE") = PAYDATE
                .Item("M_CATEGORY") = toUpper
                .Item("M_Amount") = M_Amount
                .Item("AMOUNT_PER_GIVE") = AMOUNT_PER_GIVE
                .Item("DATE_CREATED") = DATE_CREATED

                If M_DEDUC_ID = Nothing Then
                    .Item("M_DEDUC_ID") = DBNull.Value
                Else
                    .Item("M_DEDUC_ID") = M_DEDUC_ID
                End If

            End With

            ds.Tables(0).Rows.Add(dsNewRow)
            SaveEntry(ds)
        End Using
    End Sub

    Friend Sub SaveTraining_days(BIO_NO As String, PAYDATE As String, TRAINING_DAYS As String, TRAINING_REGHOLIDAY As String, TRAINING_SPECHOLIDAY As String,
                                   TRAINING_OVERTIME As Double, TRAINING_LATE As Double, TRAINING_UNDERTIME As Double)
        Dim mysql As String = $"Select * FROM PAYROLL_ATTENDANCE where BIOMETRICID = '{BIO_NO}' and PAYDATE = '{PAYDATE}'"
        Dim dss As DataSet = LoadSQL(mysql, "PAYROLL_ATTENDANCE")
        If dss.Tables(0).Rows.Count > 0 Then
            Dim dr As DataRow = dss.Tables(0).Rows(0)
            With dr
                .Item("TRAINING_DAYS") = TRAINING_DAYS
                .Item("TRAINING_REGHOLIDAY") = TRAINING_REGHOLIDAY
                .Item("TRAINING_SPECHOLIDAY") = TRAINING_SPECHOLIDAY
                .Item("TRAINING_OVERTIME") = TRAINING_OVERTIME
                .Item("TRAINING_LATE") = TRAINING_LATE
                .Item("TRAINING_UNDERTIME") = TRAINING_UNDERTIME
            End With
            SaveEntry(dss, False)
        End If
    End Sub

    Friend Sub SavePayout_IndividualL(bioNo As String, paydate_ As String, startingDate As DateTime, EndingDate As DateTime) '========== AUTO SAVE TO PAYOUT ============  
        Dim regHoliday = Holiday_Rate("REGULAR")
        Dim specHoliday = Holiday_Rate("SPECIAL")

        Dim mysql As String = $"Select * From payroll_attendance A 
                                inner join PAYROLL_EMPLOYEE B on B.BIO_NO = A.BIOMETRICID  WHERE A.BIOMETRICID = '{bioNo}' and A.PAYDATE = '{paydate_}'"

        Using ds As DataSet = LoadSQL(mysql, "payroll_attendance")
            If ds.Tables(0).Rows.Count > 0 Then

                Dim dr As DataRow = ds.Tables(0).Rows(0)
                With dr

                    Dim Late As String = ""
                    Dim UnderTime As String = ""
                    Dim RegularOT As String = ""
                    Dim nightRate As Decimal = 0
                    Dim NoOfDays, SpecialHol, RegularHol As Double
                    Dim Deduction, SBU As Decimal
                    Dim Company As String
                    Dim sched As String = ""
                    Dim noOf_days_training As Double = 0
                    Dim TotalBasic As Decimal = 0
                    Dim SSSComp As Decimal = 0
                    Dim SSS_ER As Decimal = 0
                    Dim SSS_EC As Decimal = 0
                    Dim PagibigComp As Decimal = 0
                    Dim PhilhealthComp As Decimal = 0
                    'Dim sssLoan As Decimal = 0
                    'Dim pagibigLoan As Decimal = 0
                    Dim rate As Decimal = 0
                    Dim SIL As Decimal = 0
                    Dim Allowances As Decimal = 0
                    Dim TotalREGHol, TotalSPECHol, TotalOT, TotalLateUnder, TotalNight, GrossAmount As Decimal
                    Dim Minimum_rate As Decimal = IIf(IsDBNull(.Item("BRANCH_CODE")) Or .Item("BRANCH_CODE").Equals(""), GetMinimumRate("CITY", "GENSAN"), GetMinimumRate("BRANCHCODE", .Item("BRANCH_CODE")))
                    Dim Ecola As Double = GetEcola("BRANCHCODE", .Item("BRANCH_CODE"))
                    Dim fix_monthly_rate As Boolean = IIf(IsDBNull(.Item("FIX_MONTHLY_RATE")), False, .Item("FIX_MONTHLY_RATE"))

                    rate = IIf(IsDBNull(.Item("RATE_DAILY")) Or .Item("RATE_DAILY") = 0, Minimum_rate, .Item("RATE_DAILY"))
                    Dim Monthly_rate As Decimal = IIf(IsDBNull(.Item("RATE_MONTHLY")) Or .Item("RATE_MONTHLY").Equals("0"), rate * 26, .Item("RATE_MONTHLY"))
                    Company = IIf(IsDBNull(.Item("COMPANY")), "", .Item("COMPANY"))
                    Dim Time_In As DateTime = IIf(IsDBNull(.Item("TIME_IN")), "", .Item("TIME_IN"))
                    Dim Time_Out As DateTime = IIf(IsDBNull(.Item("TIME_OUT")), "", .Item("TIME_OUT"))
                    Dim BranchCode As String = .Item("BRANCH_CODE")
                    Dim Training_REGHoliday = 0, Training_SPECHoliday As Integer = 0

                    Dim training_overtime As Double = 0
                    Dim training_late As TimeSpan = New TimeSpan(0, 0, 0, 0, 0)
                    Dim training_undertime As TimeSpan = New TimeSpan(0, 0, 0, 0, 0)

                    ''============================================= ATTENDANCE (TOTAL DAYS) =========================================================
                    Dim sql_1 As String = $"Select * From PAYROLL_ATTENDANCE WHERE BIOMETRICID = '{bioNo}' and paydate = '{paydate_}'"
                    Using ds_1 As DataSet = LoadSQL(sql_1, "PAYROLL_ATTENDANCE")
                        If ds_1.Tables(0).Rows.Count > 0 Then

                            Dim dr_11 As DataRow = ds_1.Tables(0).Rows(0)
                            With dr_11
                                NoOfDays = .Item("PRESENT_DAYS")

                                If fix_monthly_rate = False Then
                                    RegularOT = .Item("OVERTIME")
                                    SpecialHol = .Item("SPECHOLIDAY")
                                    RegularHol = .Item("REGHOLIDAY")
                                    Late = .Item("LATE")
                                    UnderTime = .Item("UNDERTIME")
                                    nightRate = IIf(IsDBNull(.Item("NIGHT_RATE")), 0, .Item("NIGHT_RATE"))
                                End If

                                SIL = IIf(IsDBNull(.Item("SIL")), 0, .Item("SIL"))
                            End With
                        End If
                    End Using

                    '====================================== IF TRAINEE GET TRAINING DAYS TO CALCULATE TRAINING FEE ===============================================
                    If Not IsDBNull(.Item("DATE_STARTED")) Then
                        Dim training_days As Integer

                        If Company = "DALTON" Or Company = "PHOTO" Or Company = "HEAD OFFICE" Then
                            training_days = 15
                        Else
                            training_days = 30
                        End If

                        Dim Started As DateTime = .Item("DATE_STARTED")

                        Dim days As Long = DateDiff(DateInterval.Day, Started, startingDate)

                        Dim days_covred As Integer = training_days - days

                        If days_covred > 0 Then

                            Dim ending As DateTime = startingDate.AddDays(days_covred)

                            While (startingDate <= ending)

                                If PRESENT_Date(bioNo, paydate_, startingDate) Then

                                    noOf_days_training += 1

                                    training_overtime += Calculate_Training_Overtime(bioNo, paydate_, startingDate, Time_Out)
                                    training_late += Calculate_Training_Late(bioNo, paydate_, startingDate, Time_In)
                                    training_undertime += Calculate_Training_Undertime(bioNo, paydate_, startingDate, Time_Out)

                                    If Halfday_Training(bioNo, paydate_, startingDate) Then
                                        noOf_days_training -= 0.5
                                    End If

                                    If DataeXIST($" PAYROLL_HOLIDAY WHERE DATEE = '{startingDate.ToString("M")}' AND KINDS = 'SPECIAL'") Then
                                        Training_SPECHoliday += 1
                                    End If

                                End If

                                '=============== IF HOLIDAY TRAINING COVERED ================
                                If DataeXIST($" PAYROLL_HOLIDAY WHERE DATEE = '{startingDate.ToString("M")}' AND KINDS = 'REGULAR'") Then
                                    If startingDate >= Started Then
                                        Training_REGHoliday += 1
                                    End If
                                End If

                                startingDate = startingDate.AddDays(1)
                            End While

                            SaveTraining_days(bioNo, paydate_, noOf_days_training, Training_REGHoliday, Training_SPECHoliday, training_overtime, training_late.TotalMinutes, training_undertime.TotalMinutes)
                        End If
                    End If

                    '============================================= BENIFITS CONTRIBUTION =========================================================  

                    Dim trainee_rate As Decimal = rate * 0.75

                    If noOf_days_training <> 0 Then '================ IF TRAINEE BASE CALCULATE NEW RATE =================

                        Dim total_train As Decimal = (Convert.ToDouble(rate) - trainee_rate) * Convert.ToDouble(noOf_days_training)
                        TotalBasic = (NoOfDays * rate) - total_train

                        '===================== TRAINING HOLIDAY ==================  
                        RegularHol = RegularHol - Training_REGHoliday
                        SpecialHol = SpecialHol - Training_SPECHoliday

                        Dim REG_STANDARD As Decimal = (RegularHol * rate) * regHoliday
                        Dim SPEC_STANDARD As Decimal = (SpecialHol * rate) * specHoliday

                        Dim REG_TRAINEE As Decimal = (Training_REGHoliday * trainee_rate) * regHoliday
                        Dim SPEC_TRAINEE As Decimal = (Training_SPECHoliday * trainee_rate) * specHoliday

                        TotalREGHol = REG_STANDARD + REG_TRAINEE
                        TotalSPECHol = SPEC_STANDARD + SPEC_TRAINEE

                    Else

                        TotalBasic = (NoOfDays * rate)
                        TotalREGHol = (RegularHol * rate) * regHoliday
                        TotalSPECHol = (SpecialHol * rate) * specHoliday

                    End If

                    ''============================= FOR MONTHLY RATE (IF ABOVE MINIMUM RATE)================================== 
                    If rate > Minimum_rate Then
                        Monthly_rate = Monthly_rate / 2

                        If fix_monthly_rate = True Then
                            TotalBasic = Monthly_rate
                        Else
                            If NoOfDays >= STANDARD_DAYS Then  '=== CHECK IF ABOVE MINIMUM
                                TotalBasic = Monthly_rate
                            Else
                                Dim MINUS_DAYS As Double = STANDARD_DAYS - NoOfDays
                                TotalBasic = Monthly_rate - (MINUS_DAYS * rate)
                            End If
                        End If
                    End If

                    '============================ CHECK WITH TRAINING DAYS COVERED ==================================   
                    If noOf_days_training = 0 Then
                        '============================ CHECK IF CLOSE PAYROLL ==================================   
                        Dim date_pay As DateTime = Convert.ToDateTime(paydate_)
                        date_pay = date_pay.ToString("d")

                        If IsLastDay(date_pay) Then
                            If bioNo <> 58 Then
                                Dim first_Basic As Decimal = GetFirst_Basic(bioNo, paydate_)
                                Dim monthly_Basic As Decimal = TotalBasic + first_Basic

                                SSSComp = Get_SSS(monthly_Basic).EE
                                SSS_ER = Get_SSS(monthly_Basic).ER
                                SSS_EC = Get_SSS(monthly_Basic).EC
                                PagibigComp = Get_Pagibig(monthly_Basic)
                                PhilhealthComp = Get_PhilHealth(monthly_Basic)

                                'sssLoan = Get_LOAN_SSS(bioNo)
                                'pagibigLoan = Get_LOAN_Pagibig(bioNo)

                                sched = "CLOSE PAYROLL"
                            End If
                        Else
                            sched = "OPEN PAYROLL"
                        End If
                    End If

                    '============================================= DELETE ALLOWANCE AND DEDUCTION TO REPLACE =================================================
                    Replacing($"RECORDED_ALLOW_DEDUC where BIO_NO = '{bioNo}' and PAYDATE = '{paydate_}';")
                    '============================================= ALLOWANCE ========================================================= 

                    If SIL <> 0 Then ' FOR SIL ADDITIONAL ================================
                        Dim SIL_Total As Decimal = SIL * rate
                        Allowances = SIL_Total
                        Save_Recorded_Allow_Deduc(bioNo, paydate_, "SIL", SIL_Total, "ALLOWANCE")
                    End If

                    If Ecola <> 0 Then ' FOR ECOLA ADDITIONAL ================================
                        Allowances = Allowances + Ecola
                        Save_Recorded_Allow_Deduc(bioNo, paydate_, "ECOLA", Ecola, "ALLOWANCE")
                    End If

                    If paydate_ = "12/15/2021" Then ' FOR 13 MONTH DECEMBER 15 ONLY =============== 
                        Dim Month13 As Decimal = Get_13Month(bioNo)
                        Allowances = Allowances + Month13
                        Save_Recorded_Allow_Deduc(bioNo, paydate_, "13th Month Pay", Month13, "ALLOWANCE")
                    End If

                    '============================================= OTHER ALLOWANCES =========================================================
                    Dim sql_2 As String = $"Select * From PAYROLL_ALLOWANCES WHERE BIOMETRIC_NO = '{bioNo}' and ALLOWED = 'YES' and (SCHEDULE = '{sched}' or SCHEDULE = 'EVERY PAYROLL')"
                    Using ds_2 As DataSet = LoadSQL(sql_2, "PAYROLL_ALLOWANCES")
                        If ds_2.Tables(0).Rows.Count > 0 Then
                            For Each dr_2 In ds_2.Tables(0).Rows
                                With dr_2
                                    If .item("EFFECTIVE_DATE") <= paydate_ Then

                                        '============== PERFORMANCE INCENTIVES DEDUCTION IF EVER MAY ABSENT ===================
                                        Dim PI As Decimal = 0
                                        Dim deduc_to_PI As Decimal = 0

                                        If .item("CATEGORY") = "PERFORMANCE INCENTIVES" Then
                                            If fix_monthly_rate = False And .item("FIX") = "NO" Then
                                                Dim PI_totalDays As Double = GetFirst_NoOfDays(bioNo, paydate_) + NoOfDays + RegularHol + SIL
                                                Dim absent As Double = 0

                                                If PI_totalDays < 26 Then
                                                    absent = 26 - PI_totalDays
                                                    deduc_to_PI = (.Item("AMOUNT") / 26) * absent
                                                End If

                                                Allowances = (Allowances + .Item("AMOUNT")) - deduc_to_PI
                                                Save_Recorded_Allow_Deduc(bioNo, paydate_, .Item("CATEGORY"), .Item("AMOUNT") - deduc_to_PI, "ALLOWANCE")
                                                Continue For  '========= EXIT FOR (PARA DILI MAGDOUBLE SAVING ========
                                            Else
                                                Allowances = Allowances + .Item("AMOUNT")
                                                Save_Recorded_Allow_Deduc(bioNo, paydate_, .Item("CATEGORY"), .Item("AMOUNT"), "ALLOWANCE")
                                                Continue For  '========= EXIT FOR (PARA DILI MAGDOUBLE SAVING ========
                                            End If
                                        End If

                                        Allowances = Allowances + .Item("AMOUNT")
                                        Save_Recorded_Allow_Deduc(bioNo, paydate_, .Item("CATEGORY"), .Item("AMOUNT"), "ALLOWANCE")
                                    End If
                                End With
                            Next
                        End If
                    End Using

                    '============================================= DEDUCTION =========================================================  
                    Deduction = 0

                    If BranchCode <> Nothing Then '=============== BRANCHES (BY RANGE)

                        Dim balance As Decimal = GetDeduction_OverAll_Balance(bioNo)
                        Dim Amount_perPayroll As Decimal = GetDeduction_ChargesRange(bioNo, balance)

                        If Amount_perPayroll > balance Then
                            Amount_perPayroll = balance
                        End If

                        Deduction = Deduction + Amount_perPayroll
                        Save_Recorded_Allow_Deduc(bioNo, paydate_, "Charges", Amount_perPayroll, "DEDUCTION", .Item("ID"))

                    Else '=============== HEAD OFFICE (BY AMORT)

                        Dim sql_3 As String = $"Select * From PAYROLL_DEDUCTION WHERE BIO_NO = '{bioNo}' and STATUS is null and (SCHEDULE = '{sched}' or SCHEDULE = 'EVERY PAYROLL')"
                        Using ds_3 As DataSet = LoadSQL(sql_3, "PAYROLL_DEDUCTION")
                            If ds_3.Tables(0).Rows.Count > 0 Then
                                For Each dr_3 In ds_3.Tables(0).Rows
                                    With dr_3

                                        Dim amountt As Decimal = 0

                                        If IsDBNull(.Item("BALANCE")) Then

                                            Deduction = Deduction + .Item("AMORT")
                                            amountt = .Item("AMORT")

                                        Else

                                            If .Item("AMORT") > .Item("BALANCE") Then
                                                Deduction = Deduction + .Item("BALANCE")
                                                amountt = .Item("BALANCE")
                                            Else
                                                Deduction = Deduction + .Item("AMORT")
                                                amountt = .Item("AMORT")
                                            End If

                                        End If

                                        Save_Recorded_Allow_Deduc(bioNo, paydate_, .Item("CATEGORY"), amountt, "DEDUCTION", .Item("ID"))

                                    End With
                                Next
                            End If
                        End Using
                    End If

                    ''============================================= LOANS LIKE SSS/PAGIBIG LOAN ==================================================  

                    'If sched = "CLOSE PAYROLL" Then
                    '    Dim sql_4 As String = $"Select * From PAYROLL_LOANS WHERE BIO_NO = '{bioNo}' and STATUS is null"
                    '    Using ds_4 As DataSet = LoadSQL(sql_4, "PAYROLL_LOANS")
                    '        If ds_4.Tables(0).Rows.Count > 0 Then
                    '            For Each dr_4 In ds_4.Tables(0).Rows
                    '                With dr_4
                    '                    Deduction = Deduction + .Item("AMORT")
                    '                    Save_Recorded_Allow_Deduc(bioNo, paydate_, .Item("CATEGORY") & "LOAN", .Item("AMORT"), "DEDUCTION")
                    '                End With
                    '            Next
                    '        End If
                    '    End Using
                    'End If

                    '============================================= OTHER DEDUCTION LIKE MP2, MAXICARE ==================================================  
                    Dim sql_5 As String = $"Select * From PAYROLL_OTHER_DEDUCTION WHERE BIO_NO = '{bioNo}' and (SCHEDULE = '{sched}' or SCHEDULE = 'EVERY PAYROLL')"
                    Using ds_5 As DataSet = LoadSQL(sql_5, "PAYROLL_OTHER_DEDUCTION")
                        If ds_5.Tables(0).Rows.Count > 0 Then
                            For Each dr_5 In ds_5.Tables(0).Rows
                                With dr_5
                                    Deduction = Deduction + .Item("AMORT")
                                    Save_Recorded_Allow_Deduc(bioNo, paydate_, .Item("CATEGORY"), .Item("AMORT"), "DEDUCTION")
                                End With
                            Next
                        End If
                    End Using

                    '============================================= IF NOT TRAINEE CALCULATE SBU ==================================================  
                    If noOf_days_training = 0 Then

                        If SBU_With_Balance(bioNo) Then

                            SBU = SBU_Amount(bioNo)

                            If SBU = 500 Then
                                If sched = "CLOSE PAYROLL" Then
                                    Save_Recorded_Allow_Deduc(bioNo, paydate_, "SBU", SBU, "DEDUCTION")
                                    Deduction = Deduction + SBU
                                End If
                            Else
                                Save_Recorded_Allow_Deduc(bioNo, paydate_, "SBU", SBU, "DEDUCTION")
                                Deduction = Deduction + SBU
                            End If

                        End If
                    End If

                    '============================================= Calculate_Gross() ========================================================= 

                    If fix_monthly_rate = True Then
                        GrossAmount = TotalBasic
                    Else

                        '===================== STANDARD AND TRAINING OVERTIME/LATE/UNDERTIME ==================   
                        Dim LATEE, LATE_TRAIN, UNDERTIMEE, UNDERTIMEE_TRAIN, OVERTIMEE, OVERTIMEE_TRAIN As Decimal
                        LATEE = ((rate / 8) / 60) * (Late - training_late.TotalMinutes)
                        UNDERTIMEE = ((rate / 8) / 60) * (UnderTime - training_undertime.TotalMinutes)
                        OVERTIMEE = ((rate / 8) * 1.25) * (RegularOT - training_overtime)

                        LATE_TRAIN = ((trainee_rate / 8) / 60) * training_late.TotalMinutes
                        UNDERTIMEE_TRAIN = ((trainee_rate / 8) / 60) * training_undertime.TotalMinutes
                        OVERTIMEE_TRAIN = ((trainee_rate / 8) * 1.25) * training_overtime

                        LATEE = LATEE + LATE_TRAIN
                        UNDERTIMEE = UNDERTIMEE + UNDERTIMEE_TRAIN
                        OVERTIMEE = OVERTIMEE + OVERTIMEE_TRAIN

                        TotalNight = ((rate / 8) * 0.1) * nightRate ' =========== CALCULATE NIGHT RATE TO PESO ===========

                        TotalOT = OVERTIMEE

                        TotalLateUnder = LATEE + UNDERTIMEE

                        GrossAmount = (TotalBasic + TotalREGHol + TotalSPECHol + TotalOT + TotalNight) - TotalLateUnder

                    End If

                    '============================================= Calculate =========================================================  
                    Dim NetPay As Decimal

                    Dim CONTRIB As Decimal = SSSComp + PagibigComp + PhilhealthComp

                    Dim positive, negative As Decimal
                    If IsLastDay(paydate_) Then
                        positive = GrossAmount + Allowances
                        negative = CONTRIB + Deduction
                        'negative = CONTRIB + sssLoan + pagibigLoan + Deduction
                    Else
                        positive = GrossAmount + Allowances
                        negative = Deduction
                    End If

                    NetPay = positive - negative

                    SavePayout(bioNo, paydate_, TotalBasic, TotalOT,
                                  TotalLateUnder, GrossAmount,
                                  SSSComp, SSS_ER, SSS_EC,
                                  PagibigComp, PhilhealthComp,
                                  Allowances, Deduction, NetPay,
                                  TotalREGHol, TotalSPECHol, TotalNight)

                    'SavePayout(bioNo, paydate_, TotalBasic, TotalOT,
                    '              TotalLateUnder, GrossAmount,
                    '              SSSComp, SSS_ER, SSS_EC,
                    '              PagibigComp, PhilhealthComp,
                    '              sssLoan, pagibigLoan,
                    '              Allowances, Deduction, NetPay,
                    '              TotalREGHol, TotalSPECHol, TotalNight)

                End With
            End If
        End Using
    End Sub

    Friend Sub SavePayout_ALL(paydate_ As String, startingDate As DateTime, EndingDate As DateTime) '========== AUTO SAVE TO PAYOUT ============   

        Dim mysql As String = $"Select * From TEMP_ATTENDANCE A 
                                inner join PAYROLL_EMPLOYEE B on B.BIO_NO = A.BIOMETRICID"
        Using ds As DataSet = LoadSQL(mysql, "TEMP_ATTENDANCE")
            If ds.Tables(0).Rows.Count > 0 Then

                progressBarStart(ds.Tables(0).Rows.Count)

                For Each dr In ds.Tables(0).Rows
                    With dr
                        SavePayout_IndividualL(.Item("BIOMETRICID"), paydate_, startingDate, EndingDate)

                        frmMainForm.AppProgressBar.Value += 1
                    End With
                Next

                MsgBox("Successfully saved!", MsgBoxStyle.Information, "Information")
            End If
        End Using
        progressBarEnd()
    End Sub

    Friend Sub Save_Recorded_Allow_Deduc(bio_no As String, PAYDATE As String, CATEGORY As String, AMOUNT As String, TRANSAC_NAME As String, Optional R_DEDUC_ID As Integer = 0, Optional R_LOAN_ID As Integer = 0)

        Dim sql As String = "Select * From RECORDED_ALLOW_DEDUC Rows 1"
        Using ds As DataSet = LoadSQL(sql, "RECORDED_ALLOW_DEDUC")

            Dim dsNewRow As DataRow = ds.Tables(0).NewRow
            With dsNewRow

                .Item("BIO_NO") = bio_no
                .Item("PAYDATE") = PAYDATE
                .Item("CATEGORY") = CATEGORY
                .Item("AMOUNT") = AMOUNT
                .Item("TRANSAC_NAME") = TRANSAC_NAME

                If R_DEDUC_ID <> 0 Then
                    .Item("R_DEDUC_ID") = R_DEDUC_ID
                End If

                If R_LOAN_ID <> 0 Then
                    .Item("R_LOAN_ID") = R_LOAN_ID
                End If

            End With
            ds.Tables(0).Rows.Add(dsNewRow)
            SaveEntry(ds)

        End Using

    End Sub

    'Friend Sub Save_Recorded_Loan(emp_id As String, PAYDATE As String, CATEGORY As String, AMOUNT As String)

    '    Dim sql As String = "Select * From RECORDED_DEDUCTION Rows 1"
    '    Using ds As DataSet = LoadSQL(sql, "RECORDED_DEDUCTION")

    '        Dim dsNewRow As DataRow = ds.Tables(0).NewRow
    '        With dsNewRow

    '            .Item("EMP_ID") = emp_id
    '            .Item("PAYDATE") = PAYDATE
    '            .Item("CATEGORY") = CATEGORY
    '            .Item("AMOUNT") = AMOUNT

    '        End With
    '        ds.Tables(0).Rows.Add(dsNewRow)
    '        SaveEntry(ds)
    '    End Using
    'End Sub

    Public Sub SaveSSS_Contribution(one As String, two As String, three As String, four As String, five As String, six As String, seven As String,
                                    eight As String, nine As String, ten As String, eleven As String, twelve As String, thirteen As String, fourteen As String,
                                    fifteen As String, sixteen As String)

        Dim sql As String = "Select * From PAYROLL_SSS Rows 1"
        Using ds As DataSet = LoadSQL(sql, "PAYROLL_SSS")

            Dim dsNewRow As DataRow = ds.Tables(0).NewRow
            With dsNewRow

                .Item("rangeComp") = one
                .Item("rss_ec") = two
                .Item("mpf") = three
                .Item("total") = four
                .Item("rss_er") = five
                .Item("rss_ee") = six
                .Item("rss_total") = seven
                .Item("ec_er") = eight
                .Item("ec_ee") = nine
                .Item("ec_total") = ten
                .Item("mpf_er") = eleven
                .Item("mpf_ee") = twelve
                .Item("mpf_total") = thirteen
                .Item("total_er") = fourteen
                .Item("total_ee") = fifteen
                .Item("total_total") = sixteen

            End With
            ds.Tables(0).Rows.Add(dsNewRow)
            SaveEntry(ds)
        End Using
    End Sub

    Friend Sub Save_Pagibig(HMDF_EE_TXT As String, HMDF_ER_TXT As String)

        Has_Rows_Delete("PAYROLL_PAGIBIG")

        Dim mysql As String = $"Select * FROM PAYROLL_PAGIBIG"
        Dim dss As DataSet = LoadSQL(mysql, "PAYROLL_PAGIBIG")
        Dim dsNewRow As DataRow = dss.Tables(0).NewRow
        With dsNewRow
            .Item("EMPLOYEE") = HMDF_EE_TXT
            .Item("EMPLOYER") = HMDF_ER_TXT
        End With

        dss.Tables(0).Rows.Add(dsNewRow)
        SaveEntry(dss)

        MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Information")

    End Sub

    Friend Sub Save_PhilHealth(rate As String)

        Has_Rows_Delete("PAYROLL_PHILHEALTH")

        Dim mysql As String = $"Select * FROM PAYROLL_PHILHEALTH"
        Dim dss As DataSet = LoadSQL(mysql, "PAYROLL_PHILHEALTH")
        Dim dsNewRow As DataRow = dss.Tables(0).NewRow
        With dsNewRow

            .Item("PREMIUM_RATE") = rate

        End With

        dss.Tables(0).Rows.Add(dsNewRow)
        SaveEntry(dss)

        MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Information")

    End Sub

    Friend Sub Save_WihtholdingTax(datagird As DataGridView)
        Has_Rows_Delete("PAYROLL_WHOLDING")
        Dim RANGE_LIST As String = Nothing

        For Each row As DataGridViewRow In datagird.Rows
            Dim mysql As String = $"Select * FROM PAYROLL_WHOLDING"
            Dim dss As DataSet = LoadSQL(mysql, "PAYROLL_WHOLDING")
            Dim dsNewRow As DataRow = dss.Tables(0).NewRow
            With dsNewRow

                .Item("COMP_RANGE") = row.Cells(0).Value
                .Item("PRESCRIBE_WH_TAX") = row.Cells(1).Value

                '========= TRANSACTION LOGS ========
                If RANGE_LIST <> Nothing Then
                    RANGE_LIST = $"{RANGE_LIST} - Range({row.Cells(0).Value}), Prescribe({row.Cells(1).Value}) "
                Else
                    RANGE_LIST = $"Range({row.Cells(0).Value}), Prescribe({row.Cells(1).Value}) "
                End If

            End With

            dss.Tables(0).Rows.Add(dsNewRow)
            SaveEntry(dss)
        Next

        MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Information")
        RunCommand("DELETE FROM PAYROLL_WHOLDING WHERE COMP_RANGE Is null")

        SaveLogs($"CHANGED WITHOLDING TAX {RANGE_LIST}", frmMainForm.UserName_LBL.Text)
    End Sub

    Friend Sub SaveAllowance(idNO As Integer, bioNo As String, category As String, amount As String, fix As String, SCHEDULE As String, DAY_DATE As String, EFFECTIVE_DATE As String)
        Dim mysql As String

        mysql = $"Select * From PAYROLL_ALLOWANCES WHERE ID = '{idNO}'"
        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_ALLOWANCES")
            If ds.Tables(0).Rows.Count > 0 Then
                For Each dr In ds.Tables(0).Rows
                    With dr
                        .Item("category") = category
                        .Item("AMOUNT") = amount
                        .Item("fix") = fix
                        .Item("SCHEDULE") = SCHEDULE
                        .Item("DAY_DATE") = DAY_DATE
                        .Item("EFFECTIVE_DATE") = EFFECTIVE_DATE
                    End With
                    SaveEntry(ds, False)
                    MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Information")
                Next
            Else

                mysql = "Select * From PAYROLL_ALLOWANCES Rows 1"
                Using dss As DataSet = LoadSQL(mysql, "PAYROLL_ALLOWANCES")

                    Dim dsNewRow As DataRow = dss.Tables(0).NewRow
                    With dsNewRow

                        .Item("BIOMETRIC_NO") = bioNo
                        .Item("category") = category
                        .Item("AMOUNT") = amount
                        .Item("fix") = fix
                        .Item("SCHEDULE") = SCHEDULE
                        .Item("DAY_DATE") = DAY_DATE
                        .Item("EFFECTIVE_DATE") = EFFECTIVE_DATE

                    End With
                    dss.Tables(0).Rows.Add(dsNewRow)
                    SaveEntry(dss)

                    MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Information")
                End Using

            End If
        End Using

    End Sub

    Friend Sub Save_Loans(idx As String, BIO_NO As String, CATEGORY As String, principal As String, AMORT As String, DATEE As String)
        Dim mysql As String

        mysql = $"Select * FROM PAYROLL_LOANS where id = '{idx}'"
        Dim ds As DataSet = LoadSQL(mysql, "PAYROLL_LOANS")
        If ds.Tables(0).Rows.Count > 0 Then

            With ds.Tables(0).Rows(0)

                .Item("CATEGORY") = CATEGORY
                .Item("PRINCIPAL") = principal
                .Item("AMORT") = AMORT
                .Item("DATEE") = DATEE

            End With

            SaveEntry(ds, False)
            MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Information")

        Else
            mysql = "Select * From PAYROLL_LOANS Rows 1"
            Using dss As DataSet = LoadSQL(mysql, "PAYROLL_LOANS")

                Dim dsNewRow As DataRow = dss.Tables(0).NewRow
                With dsNewRow

                    .Item("BIO_NO") = BIO_NO
                    .Item("CATEGORY") = CATEGORY
                    .Item("PRINCIPAL") = principal
                    .Item("AMORT") = AMORT
                    .Item("DATEE") = DATEE

                End With
                dss.Tables(0).Rows.Add(dsNewRow)
                SaveEntry(dss)

                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Information")
            End Using
        End If
    End Sub

    Friend Sub Save_OtherDeduction(idx As String, BIO_NO As String, CATEGORY As String, schedule As String, AMORT As String, DATEE As String, STATUS As String)
        Dim mysql As String

        mysql = $"Select * FROM PAYROLL_OTHER_DEDUCTION where id = '{idx}'"
        Dim ds As DataSet = LoadSQL(mysql, "PAYROLL_OTHER_DEDUCTION")
        If ds.Tables(0).Rows.Count > 0 Then

            With ds.Tables(0).Rows(0)

                .Item("CATEGORY") = CATEGORY
                .Item("SCHEDULE") = schedule
                .Item("AMORT") = AMORT
                .Item("DATEE") = DATEE

                If STATUS <> Nothing Then
                    .Item("STATUS") = STATUS
                End If

            End With

            SaveEntry(ds, False)
            MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Information")

        Else
            mysql = "Select * From PAYROLL_OTHER_DEDUCTION Rows 1"
            Using dss As DataSet = LoadSQL(mysql, "PAYROLL_OTHER_DEDUCTION")

                Dim dsNewRow As DataRow = dss.Tables(0).NewRow
                With dsNewRow

                    .Item("BIO_NO") = BIO_NO
                    .Item("CATEGORY") = CATEGORY
                    .Item("SCHEDULE") = schedule
                    .Item("AMORT") = AMORT
                    .Item("DATEE") = DATEE

                End With
                dss.Tables(0).Rows.Add(dsNewRow)
                SaveEntry(dss)

                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Information")
            End Using
        End If
    End Sub

    'Friend Sub Save_PAGIBIGLoan(BIO_NO As String, amount As String, start_date As String, end_date As String, principal As String)
    '    Dim mysql As String

    '    mysql = $"Select * FROM PAYROLL_PAGIBIGLOAN where BIO_NO = '{BIO_NO}' and STATUS is null"
    '    Dim ds As DataSet = LoadSQL(mysql, "PAYROLL_PAGIBIGLOAN")
    '    If ds.Tables(0).Rows.Count > 0 Then

    '        With ds.Tables(0).Rows(0)

    '            .Item("monthly_amort") = amount
    '            .Item("first_date") = start_date
    '            .Item("maturity_date") = end_date
    '            .Item("PAGIBIG_PRINCIPAL") = principal

    '        End With

    '        SaveEntry(ds, False)
    '        MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Information")

    '    Else
    '        mysql = "Select * From PAYROLL_PAGIBIGLOAN Rows 1"
    '        Using dss As DataSet = LoadSQL(mysql, "PAYROLL_PAGIBIGLOAN")

    '            Dim dsNewRow As DataRow = dss.Tables(0).NewRow
    '            With dsNewRow

    '                .Item("BIO_NO") = BIO_NO
    '                .Item("monthly_amort") = amount
    '                .Item("first_date") = start_date
    '                .Item("maturity_date") = end_date
    '                .Item("PAGIBIG_PRINCIPAL") = principal

    '            End With
    '            dss.Tables(0).Rows.Add(dsNewRow)
    '            SaveEntry(dss)

    '            MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Information")
    '        End Using
    '    End If

    'End Sub

    Friend Sub SaveCATEGORY(category As String, table As String, coulumn As String)

        Dim mysql As String = $"Select * From {table} Rows 1"
        Using dss As DataSet = LoadSQL(mysql, table)
            Dim dsNewRow As DataRow = dss.Tables(0).NewRow
            With dsNewRow

                .Item(coulumn) = category

            End With
            dss.Tables(0).Rows.Add(dsNewRow)
            SaveEntry(dss)
        End Using

    End Sub

    Friend Sub SaveEmail(email As String, pass As String)
        Dim mysql As String

        mysql = $"Select * FROM PAYROLL_EMAIL  where id = '1'"
        Dim ds As DataSet = LoadSQL(mysql, "PAYROLL_EMAIL ")
        If ds.Tables(0).Rows.Count > 0 Then

            With ds.Tables(0).Rows(0)

                .Item("email") = email
                .Item("pass") = pass

            End With

            SaveEntry(ds, False)
            MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Information")

        Else
            mysql = "Select * From PAYROLL_EMAIL Rows 1"
            Using dss As DataSet = LoadSQL(mysql, "PAYROLL_EMAIL")

                Dim dsNewRow As DataRow = dss.Tables(0).NewRow
                With dsNewRow


                    .Item("email") = email
                    .Item("pass") = pass

                End With
                dss.Tables(0).Rows.Add(dsNewRow)
                SaveEntry(dss)

                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Information")
            End Using
        End If
    End Sub

    Public Sub SaveNew_Employee(COMPANY As String, BRANCH_CODE As String, FULLNAME As String, BIO_NO As String, EMAIL_ADD As String,
                                EMP_STATUS As String, Optional DATE_STARTED As String = "", Optional group As Boolean = False,
                                Optional TIME_IN As String = "", Optional TIME_OUT As String = "", Optional EMP_NO As String = "",
                                Optional TIN As String = "", Optional SSS As String = "", Optional PHILH As String = "",
                                Optional HDMF As String = "", Optional HO_CATEGORY As String = "", Optional COMMON_CATEGORY As String = "",
                                Optional EMP_POSITION As String = "", Optional COMMON_COMPANY As String = "", Optional PhotoCategory As String = "")

        Dim mysql As String

        mysql = $"Select * FROM PAYROLL_EMPLOYEE  where BIO_NO = '{BIO_NO}'"
        Dim ds As DataSet = LoadSQL(mysql, "PAYROLL_EMPLOYEE ")
        If ds.Tables(0).Rows.Count > 0 Then

            With ds.Tables(0).Rows(0)

                .Item("COMPANY") = COMPANY
                .Item("BRANCH_CODE") = BRANCH_CODE
                .Item("FULLNAME") = FULLNAME
                .Item("EMAIL_ADD") = EMAIL_ADD
                .Item("EMP_STATUS") = EMP_STATUS
                .Item("RATE_DAILY") = IIf(.Item("BRANCH_CODE") = Nothing, GetMinimumRate("CITY", "GENSAN"), GetMinimumRate("BRANCHCODE", .Item("BRANCH_CODE")))

                If COMPANY = "PHOTO" Then
                    .Item("COMPANY_CATEGORY") = GetData("CATEGORY", $"PAYROLL_CITY_BRANCH WHERE BRANCHCODE = '{BRANCH_CODE}'")
                End If

                Dim toLower As String = ""
                Dim toProper As String = ""

                If HO_CATEGORY <> "" Then
                    If HO_CATEGORY = "PGC HEAD OFFICE" Then
                        toProper = "PGC HEAD OFFICE"
                    Else
                        toLower = HO_CATEGORY.ToLower()
                        Dim info As TextInfo = CultureInfo.InvariantCulture.TextInfo
                        toProper = info.ToTitleCase(toLower)
                    End If
                End If

                If DATE_STARTED <> "" Then .Item("DATE_STARTED") = DATE_STARTED
                If TIME_IN <> "" Then .Item("TIME_IN") = TIME_IN
                If TIME_OUT <> "" Then .Item("TIME_OUT") = TIME_OUT
                If EMP_NO <> "" Then .Item("EMP_NO") = EMP_NO
                If TIN <> "" Then .Item("TINNO") = TIN
                If SSS <> "" Then .Item("SSSNO") = SSS
                If PHILH <> "" Then .Item("PHILHEALTHNO") = PHILH
                If HDMF <> "" Then .Item("PAGIBIGNO") = HDMF
                If HO_CATEGORY <> "" Then .Item("HO_CATEGORY") = toProper
                If COMMON_CATEGORY <> "" Then .Item("COMMON_CATEGORY") = COMMON_CATEGORY
                If EMP_POSITION <> "" Then .Item("EMP_POSITION") = EMP_POSITION
                If COMMON_COMPANY <> "" Then .Item("COMMON_COMPANY") = COMMON_COMPANY
                If PhotoCategory <> "" Then .Item("COMPANY_CATEGORY") = PhotoCategory

            End With

            SaveEntry(ds, False)

            If group = False Then
                MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Information")
            End If

        Else
            mysql = "Select * From PAYROLL_EMPLOYEE Rows 1"
            Using dss As DataSet = LoadSQL(mysql, "PAYROLL_EMPLOYEE")

                Dim dsNewRow As DataRow = dss.Tables(0).NewRow
                With dsNewRow

                    .Item("BIO_NO") = BIO_NO
                    .Item("COMPANY") = COMPANY
                    .Item("BRANCH_CODE") = BRANCH_CODE
                    .Item("FULLNAME") = FULLNAME
                    .Item("EMAIL_ADD") = EMAIL_ADD
                    .Item("EMP_STATUS") = EMP_STATUS
                    .Item("RATE_DAILY") = IIf(.Item("BRANCH_CODE") = Nothing, GetMinimumRate("CITY", "GENSAN"), GetMinimumRate("BRANCHCODE", .Item("BRANCH_CODE")))

                    If DATE_STARTED <> "" Then .Item("DATE_STARTED") = DATE_STARTED
                    If TIME_IN <> "" Then .Item("TIME_IN") = TIME_IN
                    If TIME_OUT <> "" Then .Item("TIME_OUT") = TIME_OUT
                    If EMP_NO <> "" Then .Item("EMP_NO") = EMP_NO
                    If TIN <> "" Then .Item("TINNO") = TIN
                    If SSS <> "" Then .Item("SSSNO") = SSS
                    If PHILH <> "" Then .Item("PHILHEALTHNO") = PHILH
                    If HDMF <> "" Then .Item("PAGIBIGNO") = HDMF
                    If HO_CATEGORY <> "" Then .Item("HO_CATEGORY") = HO_CATEGORY
                    If COMMON_CATEGORY <> "" Then .Item("COMMON_CATEGORY") = COMMON_CATEGORY
                    If EMP_POSITION <> "" Then .Item("EMP_POSITION") = EMP_POSITION
                    If COMMON_COMPANY <> "" Then .Item("COMMON_COMPANY") = COMMON_COMPANY
                    If PhotoCategory <> "" Then .Item("COMPANY_CATEGORY") = PhotoCategory

                End With

                dss.Tables(0).Rows.Add(dsNewRow)
                SaveEntry(dss)

                SaveNew_SBU(BIO_NO, COMPANY)

                If group = False Then
                    MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Information")
                End If

            End Using
        End If

    End Sub

    Public Sub SaveNew_SBU(BIO_NO As String, COMPANY As String)

        Dim mysql As String
        Dim PRINCIPAL As Double

        If COMPANY = "DALTON" Then
            PRINCIPAL = 50000
        ElseIf COMPANY = "PHOTO" Then
            PRINCIPAL = 30000
        Else
            PRINCIPAL = 15000
        End If

        mysql = "Select * From PAYROLL_SBU Rows 1"
        Using dss As DataSet = LoadSQL(mysql, "PAYROLL_SBU")

            Dim dsNewRow As DataRow = dss.Tables(0).NewRow
            With dsNewRow

                .Item("BIO_NO") = BIO_NO
                .Item("AMOUNT") = 250
                .Item("CATEGORY") = "SBU"
                .Item("PRINCIPAL") = PRINCIPAL

            End With

            dss.Tables(0).Rows.Add(dsNewRow)
            SaveEntry(dss)

        End Using

    End Sub

    Public Sub Save_BranchesName(code As String, name As String)

        Dim mysql As String

        mysql = $"Select * From PAYROLL_CITY_BRANCH  where BRANCHCODE = '{code}'"
        Using dss As DataSet = LoadSQL(mysql, "PAYROLL_CITY_BRANCH")
            If dss.Tables(0).Rows.Count > 0 Then

                With dss.Tables(0).Rows(0)
                    .Item("BRANCHNAME") = name
                End With
                SaveEntry(dss)

                'Else
                '    mysql = "Select * From PAYROLL_CITY_BRANCH "
                '    Using ds As DataSet = LoadSQL(mysql, "PAYROLL_CITY_BRANCH")
                '        Dim dsNewRow As DataRow = ds.Tables(0).NewRow
                '        With dsNewRow

                '            .Item("BRANCHCODE") = code
                '            .Item("BRANCHNAME") = name

                '        End With

                '        ds.Tables(0).Rows.Add(dsNewRow)
                '        SaveEntry(ds)
                '    End Using

            End If

        End Using

    End Sub

    Public Sub Update_Emp_DateHired_Position(FULLNAME As String, DATE_STARTED As String, EMP_POSITION As String, EMP_NO As String, empNo As String)

        Dim mysql As String = $"Select * FROM PAYROLL_EMPLOYEE  where FULLNAME = '{FULLNAME}'"
        Dim ds As DataSet = LoadSQL(mysql, "PAYROLL_EMPLOYEE ")
        If ds.Tables(0).Rows.Count > 0 Then

            With ds.Tables(0).Rows(0)

                If DATE_STARTED <> Nothing Then
                    .Item("DATE_STARTED") = DATE_STARTED
                End If

                .Item("EMP_POSITION") = EMP_POSITION.ToUpper
                .Item("EMP_NO") = EMP_NO

            End With

            SaveEntry(ds, False)
        End If

    End Sub

    Public Sub Update_Emp_Benefits_Details(BIO_NO As String, TINNO As String, SSSNO As String, PHILHEALTHNO As String, PAGIBIGNO As String, DATE_STARTED As String, EMP_POSITION As String, empNo As String)

        Dim id_no As String() = BIO_NO.Split(New Char() {"-"c})


        Console.WriteLine("empNo " & empNo)

        If id_no.Length >= 3 Then

            Dim mysql As String = $"Select * FROM PAYROLL_EMPLOYEE  where BIO_NO = '{id_no(2)}'"
            Dim ds As DataSet = LoadSQL(mysql, "PAYROLL_EMPLOYEE ")
            If ds.Tables(0).Rows.Count > 0 Then

                With ds.Tables(0).Rows(0)

                    .Item("DATE_STARTED") = DATE_STARTED
                    .Item("EMP_POSITION") = EMP_POSITION
                    .Item("TINNO") = TINNO
                    .Item("SSSNO") = SSSNO
                    .Item("PHILHEALTHNO") = PHILHEALTHNO
                    .Item("PAGIBIGNO") = PAGIBIGNO

                End With

                SaveEntry(ds, False)
            End If

        Else

            MsgBox(empNo)

        End If

    End Sub

    Function RemoveWhitespace(fullString As String) As String
        Return New String(fullString.Where(Function(x) Not Char.IsWhiteSpace(x)).ToArray())
    End Function

    'Public Sub SAVE_Emp_SBU_AMOUNT_PRINCIPAL_CREDIT_NAME(EMP_NO As String, CATEGORY As String, AMOUNT As String, PRINCIPAL As String, CREDIT As String, BALANCE As String, RowNo As Integer)
    '    If EMP_NO.TrimEnd = "addt'l. cash bond" Then
    '        Exit Sub
    '    End If

    '    If EMP_NO <> "" Or EMP_NO <> Nothing Then

    '        Dim mysql As String
    '        Dim BIO As String = ""

    '        '====================== GET BIO_NO FOR SAVING TO PAYROLL_SBU  ==================
    '        mysql = "Select * From PAYROLL_EMPLOYEE WHERE EMP_NO = '" & EMP_NO.TrimEnd & "'"
    '        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_EMPLOYEE")
    '            If ds.Tables(0).Rows.Count > 0 Then
    '                Dim data As DataRow = ds.Tables(0).Rows(0)
    '                With data
    '                    BIO = .Item("BIO_NO")
    '                End With
    '            Else
    '                Exit Sub
    '            End If
    '        End Using

    '        '====================== ADD NEW PAYROLL_SBU ==================
    '        mysql = "Select * From PAYROLL_SBU Rows 1"
    '        Using dssS As DataSet = LoadSQL(mysql, "PAYROLL_SBU")

    '            Dim dsNewRow As DataRow = dssS.Tables(0).NewRow
    '            With dsNewRow

    '                .Item("BIO_NO") = BIO
    '                .Item("PRINCIPAL") = IIf(PRINCIPAL = Nothing, 0, PRINCIPAL)
    '                .Item("CREDIT") = IIf(CREDIT = Nothing, 0, CREDIT)
    '                .Item("BALANCE") = IIf(BALANCE = Nothing, PRINCIPAL, BALANCE)
    '                .Item("CATEGORY") = CATEGORY
    '                .Item("AMOUNT") = IIf(AMOUNT = Nothing, 250, AMOUNT)

    '            End With
    '            dssS.Tables(0).Rows.Add(dsNewRow)
    '            SaveEntry(dssS)
    '            Console.WriteLine("NEWWWW -" & EMP_NO & "- " & RowNo - 1)
    '        End Using
    '    End If

    'End Sub

    Public Sub SAVE_13MONTH_EMPNO(EMP_NO As String, RowNo As Integer)
        Dim mysql As String = "Select * From PAYROLL_13MONTH Rows 1"
        Using dssS As DataSet = LoadSQL(mysql, "PAYROLL_13MONTH")

            Dim dsNewRow As DataRow = dssS.Tables(0).NewRow
            With dsNewRow

                .Item("EMP_NO") = EMP_NO

            End With
            dssS.Tables(0).Rows.Add(dsNewRow)
            SaveEntry(dssS)
            Console.WriteLine("EMP_NOOO-" & RowNo)
        End Using
    End Sub

    Public Sub SAVE_13MONTH_AMOUNT(AMOUNT As String, RowNo As Integer)

        Dim mysql As String = $"SelecT * FROM PAYROLL_13MONTH ORDER BY ID DESC rows 1"
        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_13MONTH")
            If ds.Tables(0).Rows.Count > 0 Then
                Dim data As DataRow = ds.Tables(0).Rows(0)
                With data
                    .Item("AMOUNT") = AMOUNT
                End With

                SaveEntry(ds, False)
            End If

            Console.WriteLine("AMOUNTTTT-" & RowNo)
        End Using
    End Sub


    'Public Sub SAVE_Emp_SBU_AMOUNT_PRINCIPAL_CREDIT_BIO(EMP_NO As String, SBU_AMOUNT As String, SBU_PRINCIPAL As String, SBU_CREDIT As String, SBU_BALANCE As String, RowNo As Integer)
    '    If EMP_NO <> "" Then
    '        Dim REMOVE_SPACE As String = RemoveWhitespace(EMP_NO)
    '        Dim BIO As String() = REMOVE_SPACE.Split(New Char() {"-"c})

    '        '====================== UPDATE OR ADD PAYROLL_SBU ==================
    '        Dim mysql As String

    '        If BIO.Length = 3 Then

    '            If Match_Employee(BIO(2)) Then
    '                mysql = $"Select * FROM PAYROLL_SBU where BIO_NO = '{BIO(2)}'"
    '                Dim dss As DataSet = LoadSQL(mysql, "PAYROLL_SBU")
    '                If dss.Tables(0).Rows.Count > 0 Then

    '                    With dss.Tables(0).Rows(0)

    '                        .Item("SBU_AMOUNT") = SBU_AMOUNT
    '                        .Item("SBU_PRINCIPAL") = SBU_PRINCIPAL
    '                        .Item("SBU_CREDIT") = SBU_CREDIT
    '                        .Item("SBU_BALANCE") = SBU_BALANCE

    '                    End With

    '                    SaveEntry(dss, False)

    '                Else
    '                    mysql = "Select * From PAYROLL_SBU Rows 1"
    '                    Using dssS As DataSet = LoadSQL(mysql, "PAYROLL_SBU")

    '                        Dim dsNewRow As DataRow = dssS.Tables(0).NewRow
    '                        With dsNewRow

    '                            .Item("BIO_NO") = BIO(2)
    '                            .Item("SBU_AMOUNT") = SBU_AMOUNT
    '                            .Item("SBU_PRINCIPAL") = SBU_PRINCIPAL
    '                            .Item("SBU_CREDIT") = SBU_CREDIT
    '                            .Item("SBU_BALANCE") = SBU_BALANCE

    '                        End With
    '                        dssS.Tables(0).Rows.Add(dsNewRow)
    '                        SaveEntry(dssS)
    '                    End Using
    '                End If
    '            Else
    '                Console.WriteLine("ROWWW -" & REMOVE_SPACE & "- " & RowNo - 1)
    '            End If

    '        End If
    '    End If
    'End Sub


    'Update_Emp_Benefits_DetailS_BY_NAME(fullname, eCell(row, 9).Value, eCell(row, 10).Value, eCell(row, 11).Value, eCell(row, 12).Value, eCell(row, 6).Value, eCell(row, 8).Value, eCell(row, 1).Value)

    Public Sub Update_Emp_Benefits_DetailS_BY_NAME(FULLNAME As String, TINNO As String, SSSNO As String, PHILHEALTHNO As String, PAGIBIGNO As String, DATE_STARTED As String, EMP_POSITION As String, empNo As String)

        Console.WriteLine("empNo " & empNo)

        Dim mysql As String = $"Select * FROM PAYROLL_EMPLOYEE  where FULLNAME = '{FULLNAME}'"
        Dim ds As DataSet = LoadSQL(mysql, "PAYROLL_EMPLOYEE ")
        If ds.Tables(0).Rows.Count > 0 Then

            With ds.Tables(0).Rows(0)

                If DATE_STARTED <> Nothing Then
                    .Item("DATE_STARTED") = DATE_STARTED
                End If

                .Item("EMP_POSITION") = EMP_POSITION
                .Item("TINNO") = TINNO
                .Item("SSSNO") = SSSNO
                .Item("PHILHEALTHNO") = PHILHEALTHNO
                .Item("PAGIBIGNO") = PAGIBIGNO

            End With

            SaveEntry(ds, False)
        End If

    End Sub

    Friend Sub Save_ClockINOUT(column As String, columnValue As String, TIME_IN As String, TIME_OUT As String)
        Dim mysql As String

        mysql = $"Select * FROM PAYROLL_EMPLOYEE where {column} = '{columnValue}'"
        Dim ds As DataSet = LoadSQL(mysql, "PAYROLL_EMPLOYEE")
        If ds.Tables(0).Rows.Count > 0 Then
            For Each dr In ds.Tables(0).Rows
                With dr
                    .Item("TIME_IN") = TIME_IN
                    .Item("TIME_OUT") = TIME_OUT

                End With

                SaveEntry(ds, False)
            Next

            MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Information")
        End If
    End Sub

    Friend Sub Save_Marketing_DYU(M_DaltonP As String, M_Photo As String, M_DavaoP As String, M_Perfecom As String,
                                  D_DaltonP As String, D_Photo As String, D_DavaoP As String, D_Perfecom As String,
                                  L_DaLTON As String, L_PG711 As String,
                                  DR_Dalton As String, DR_Photo As String, DR_House As String, ConDalton As String,
                                  ConPhoto As String, ConHouse As String, LeasingBR As String,
                                  DTR_Dalton As String, DTR_Photo As String, LeasingP As String)

        Replacing("PAYROLL_MARKETING_DYU")

        Dim mysql As String = "Select * From PAYROLL_MARKETING_DYU Rows 1"
        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_MARKETING_DYU")

            Dim dsNewRow As DataRow = ds.Tables(0).NewRow
            With dsNewRow

                .Item("M_DaltonP") = IIf(M_DaltonP = Nothing, 0, M_DaltonP)
                .Item("M_Photo") = IIf(M_Photo = Nothing, 0, M_Photo)
                .Item("M_DavaoP") = IIf(M_DavaoP = Nothing, 0, M_DavaoP)
                .Item("M_Perfecom") = IIf(M_Perfecom = Nothing, 0, M_Perfecom)
                .Item("D_DaltonP") = IIf(D_DaltonP = Nothing, 0, D_DaltonP)
                .Item("D_Photo") = IIf(D_Photo = Nothing, 0, D_Photo)
                .Item("D_DavaoP") = IIf(D_DavaoP = Nothing, 0, D_DavaoP)
                .Item("D_Perfecom") = IIf(D_Perfecom = Nothing, 0, D_Perfecom)
                .Item("L_Dalton") = IIf(L_DaLTON = Nothing, 0, L_DaLTON)
                .Item("L_PG711") = IIf(L_PG711 = Nothing, 0, L_PG711)
                .Item("DR_Dalton") = IIf(DR_Dalton = Nothing, 0, DR_Dalton)
                .Item("DR_Photo") = IIf(DR_Photo = Nothing, 0, DR_Photo)
                .Item("DR_House") = IIf(DR_House = Nothing, 0, DR_House)
                .Item("ConDalton") = IIf(ConDalton = Nothing, 0, ConDalton)
                .Item("ConPhoto") = IIf(ConPhoto = Nothing, 0, ConPhoto)
                .Item("ConHouse") = IIf(ConHouse = Nothing, 0, ConHouse)
                .Item("LeasingBR") = IIf(LeasingBR = Nothing, 0, LeasingBR)
                .Item("DTR_Dalton") = IIf(DTR_Dalton = Nothing, 0, DTR_Dalton)
                .Item("DTR_Photo") = IIf(DTR_Photo = Nothing, 0, DTR_Photo)
                .Item("LEASINGP") = IIf(LeasingP = Nothing, 0, LeasingP)

            End With
            ds.Tables(0).Rows.Add(dsNewRow)
            SaveEntry(ds)

            MsgBox("Successfully Save!", MsgBoxStyle.Information, "Information")
        End Using
    End Sub

    Friend Sub Save_PERCENTAGE(DALTON As String, PHOTO As String, DAVAOP As String, PERFECOM As String, G3 As String,
                                  SEVEN11 As String, COMI_TO_FUJI As String, HOUSEHOLD As String, LEASING As String, CATEGORY As String)

        'Friend Sub Save_PERCENTAGE(DALTON As Decimal, PHOTO As Decimal, DAVAOP As Decimal, PERFECOM As Decimal, G3 As Decimal,
        '                              SEVEN11 As Decimal, COMI_TO_FUJI As Decimal, HOUSEHOLD As Decimal, LEASING As Decimal, CATEGORY As String)

        Dim mysql As String = "Select * From PAYROLL_PERCENTAGEE Rows 1"
        Using dss As DataSet = LoadSQL(mysql, "PAYROLL_PERCENTAGEE")

            Dim dsNewRow As DataRow = dss.Tables(0).NewRow
            With dsNewRow

                .Item("DALTON") = DALTON
                .Item("PHOTO") = PHOTO
                .Item("DAVAOP") = DAVAOP
                .Item("PERFECOM") = PERFECOM
                .Item("G3") = G3
                .Item("SEVEN11") = SEVEN11
                .Item("COMI_TO_FUJI") = COMI_TO_FUJI
                .Item("HOUSEHOLD") = HOUSEHOLD
                .Item("LEASING") = LEASING
                .Item("CATEGORY") = CATEGORY

                '.Item("DALTON") = IIf(Not DALTON.Contains("%"), DALTON, DALTON.Substring(0, DALTON.Length - 1))
                '.Item("PHOTO") = IIf(Not PHOTO.Contains("%"), PHOTO, PHOTO.Substring(0, PHOTO.Length - 1))
                '.Item("DAVAOP") = IIf(Not DAVAOP.Contains("%"), DAVAOP, DAVAOP.Substring(0, DAVAOP.Length - 1))
                '.Item("PERFECOM") = IIf(Not PERFECOM.Contains("%"), PERFECOM, PERFECOM.Substring(0, PERFECOM.Length - 1))
                '.Item("G3") = IIf(Not G3.Contains("%"), G3, G3.Substring(0, G3.Length - 1))
                '.Item("SEVEN11") = IIf(Not SEVEN11.Contains("%"), SEVEN11, SEVEN11.Substring(0, SEVEN11.Length - 1))
                '.Item("COMI_TO_FUJI") = IIf(Not COMI_TO_FUJI.Contains("%"), COMI_TO_FUJI, COMI_TO_FUJI.Substring(0, COMI_TO_FUJI.Length - 1))
                '.Item("HOUSEHOLD") = IIf(Not HOUSEHOLD.Contains("%"), HOUSEHOLD, HOUSEHOLD.Substring(0, HOUSEHOLD.Length - 1))
                '.Item("LEASING") = IIf(Not LEASING.Contains("%"), LEASING, LEASING.Substring(0, LEASING.Length - 1))
                '.Item("CATEGORY") = CATEGORY

                '.Item("DALTON") = Format(DALTON, "0.00")
                '.Item("PHOTO") = Format(PHOTO, "0.00")
                '.Item("DAVAOP") = Format(DAVAOP, "0.00")
                '.Item("PERFECOM") = Format(PERFECOM, "0.00")
                '.Item("G3") = Format(G3, "0.00")
                '.Item("SEVEN11") = Format(SEVEN11, "0.00")
                '.Item("COMI_TO_FUJI") = Format(COMI_TO_FUJI, "0.00")
                '.Item("HOUSEHOLD") = Format(HOUSEHOLD, "0.00")
                '.Item("LEASING") = Format(LEASING, "0.00")
                '.Item("CATEGORY") = CATEGORY
            End With
            dss.Tables(0).Rows.Add(dsNewRow)
            SaveEntry(dss)
        End Using
    End Sub

    'Friend Sub SaveCityBranch()

    '    Dim mysql As String
    '    Dim city As String = Nothing
    '    Dim code As String = Nothing
    '    Dim namee As String = Nothing

    '    mysql = "Select * From PAYROLL_EMPLOYEE WHERE BRANCH_CITY = 'LAMBAYONG'"
    '    Using ds As DataSet = LoadSQL(mysql, "PAYROLL_EMPLOYEE")
    '        If ds.Tables(0).Rows.Count > 0 Then
    '            For Each dr In ds.Tables(0).Rows
    '                With dr
    '                    city = 
    '                End With
    '            Next
    '        End If
    '    End Using

    '    mysql = "Select * From PAYROLL_CITY_BRANCH Rows 1"
    '    Using dss As DataSet = LoadSQL(mysql, "PAYROLL_CITY_BRANCH")

    '        Dim dsNewRow As DataRow = dss.Tables(0).NewRow
    '        With dsNewRow

    '            .Item("CITY") = city
    '            .Item("BRANCHCODE") = BRANCHCODE
    '            .Item("BRANCHNAME") = BRANCHNAME

    '        End With

    '        dss.Tables(0).Rows.Add(dsNewRow)
    '        SaveEntry(dss)

    '        MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Information")

    '    End Using
    'End Sub

    Friend Sub SaveCityBranch(BRANCHCODE As String, BRANCHNAME As String, CITY As String, CATEGORY As String, ADDRESS As String)

        Dim mysql As String

        mysql = $"Select * FROM PAYROLL_CITY_BRANCH  where BRANCHCODE = '{BRANCHCODE}'"
        Dim ds As DataSet = LoadSQL(mysql, "PAYROLL_CITY_BRANCH ")
        If ds.Tables(0).Rows.Count > 0 Then
            With ds.Tables(0).Rows(0)

                .Item("CITY") = CITY
                .Item("BRANCHNAME") = BRANCHNAME
                .Item("CATEGORY") = CATEGORY
                .Item("ADDRESS") = ADDRESS

            End With

            SaveEntry(ds, False)

            MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Information")

        Else
            mysql = "Select * From PAYROLL_CITY_BRANCH Rows 1"
            Using dss As DataSet = LoadSQL(mysql, "PAYROLL_CITY_BRANCH")

                Dim dsNewRow As DataRow = dss.Tables(0).NewRow
                With dsNewRow

                    .Item("CITY") = CITY
                    .Item("BRANCHCODE") = BRANCHCODE
                    .Item("BRANCHNAME") = BRANCHNAME
                    .Item("CATEGORY") = CATEGORY
                    .Item("ADDRESS") = ADDRESS

                End With

                dss.Tables(0).Rows.Add(dsNewRow)
                SaveEntry(dss)

                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Information")

            End Using
        End If
    End Sub

    Friend Sub SaveLogs(TRANSACTIONN As String, USER As String)
        Dim mysql As String = $"Select * from PAYROLL_LOGS"
        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_LOGS")
            Dim dsNew As DataRow = ds.Tables(0).NewRow
            With dsNew
                .Item("TRANSACTIONN") = TRANSACTIONN
                .Item("USER") = USER
                .Item("DATEE") = Date.Now
            End With

            ds.Tables(0).Rows.Add(dsNew)
            SaveEntry(ds)
        End Using
    End Sub

    Public Sub SaveUserDetails(oldUsername As String, newUsername As String, newPassword As String)

        Dim namee As String = GetData("USER_FULLNAME", $"PAYROLL_USER where USERNAME = '{oldUsername}'")

        Dim mysql As String = $"Select * from PAYROLL_USER rows 1"
        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_USER")
            Dim dsRow As DataRow = ds.Tables(0).NewRow
            With dsRow
                .Item("USERNAME") = newUsername
                .Item("PASSWORD") = EncryptString(newPassword)
                .Item("USER_FULLNAME") = namee
            End With

            ds.Tables(0).Rows.Add(dsRow)
            SaveEntry(ds)

            MsgBox("Successfully Saved.", MsgBoxStyle.Information, "Success")
        End Using
    End Sub

End Module
