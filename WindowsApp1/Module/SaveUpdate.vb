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
                              under_total As String, regHoliday As String, specHoliday As String, branch As String, Optional group As String = "")
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

            If group = "" Then
                MsgBox("Succesfully Updated!", MsgBoxStyle.Information, "Information")
            End If
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

                If group = "" Then
                    MsgBox("Succesfully Saved!", MsgBoxStyle.Information, "Information")
                End If

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

    Friend Sub Deduct_ifExist(EMP_ID As String, PAYDATE As String)
        Dim mysql_1 As String = $"Select A.*, A.id as deduc_id, B.* From PAYROLL_DEDUCTIONS A 
                                        left join MODIFIED_DEDUCTION B on B.EMP_ID = A.EMP_ID  and B.PAYDATE = '{PAYDATE}'  and B.M_CATEGORY = A.CATEGORY
                                        WHERE A.EMP_ID = '{EMP_ID}'  and STATUS IS NULL"

        Using ds As DataSet = LoadSQL(mysql_1, "PAYROLL_DEDUCTIONS")
            If ds.Tables(0).Rows.Count > 0 Then

                If isExist_Double("HISTORY_DEDUCTION", "EMP_ID", EMP_ID, "PAYDATE", PAYDATE) Then 'DELETE RECORD (HISTORY_DEDUCTION) IF EXIST TO REPLACE NEW FROM GRID (IMPORTANT)
                    RunCommand($"DELETE FROM HISTORY_DEDUCTION WHERE EMP_ID = '{EMP_ID}' and PAYDATE = '{PAYDATE}';")
                End If

                For Each dr In ds.Tables(0).Rows
                    With dr

                        If isExist_Triple("MODIFIED_DEDUCTION", "EMP_ID", EMP_ID, "PAYDATE", PAYDATE, "M_CATEGORY", .item("CATEGORY")) Then '========= REFER TO MODIFIED_DEDUCTION IF EXIST (IMPORTANT)

                            If Not .item("M_AMOUNT") = 0.00 Or Not .item("M_AMOUNT") = 0 Then
                                SaveDEDUCTION_HISTORY(EMP_ID, .item("CATEGORY"), .item("M_AMOUNT"), Today, PAYDATE, .item("deduc_id"))
                            End If

                        Else '========= REFER TO THE ORGINAL DATA IF NOT EXIST  
                            SaveDEDUCTION_HISTORY(EMP_ID, .item("CATEGORY"), .item("AMOUNT_PER_GIVE"), Today, PAYDATE, .item("deduc_id"))
                        End If

                        Calculate_Balance(.item("deduc_id")) '========= CALCULATE DEDUCTION BALANCE =========
                    End With
                Next

            End If
        End Using

    End Sub

    Friend Sub Calculate_Balance(deduc_id As String)
        Dim total_amount As Double = 0

        '================================== GET TOTAL_AMOUNT ================================ 
        Dim mysql As String = $"Select TOTAL_AMOUNT From PAYROLL_DEDUCTIONS where ID = '{deduc_id}' "
        Using dss As DataSet = LoadSQL(mysql, "PAYROLL_DEDUCTIONS")
            If dss.Tables(0).Rows.Count > 0 Then
                Dim data As DataRow = dss.Tables(0).Rows(0)
                With data
                    total_amount = .Item("TOTAL_AMOUNT")
                End With
            End If
        End Using

        '================================== SUM UP ALL IN HISTORY_DEDUCTION ================================ 
        If isExist_single("HISTORY_DEDUCTION", "H_DEDUC_ID", deduc_id) Then
            Dim mysql_ As String = $"Select SUM(H_AMOUNT) as tots From HISTORY_DEDUCTION where H_DEDUC_ID = '{deduc_id}' "
            Using ds As DataSet = LoadSQL(mysql_, "HISTORY_DEDUCTION")
                If ds.Tables(0).Rows.Count > 0 Then
                    For Each drR In ds.Tables(0).Rows
                        With drR
                            If .item("tots") >= total_amount Then    '====== IF GREATER OR EQUAL TO TOTAL AMOUNT OF DEDUCTION ====== 
                                Update_DEDUCTION_STATUS(deduc_id)
                            End If
                        End With
                    Next
                End If
            End Using
        End If

    End Sub

    Public Sub Update_DEDUCTION_STATUS(deduc_id As String)

        Dim mysql As String = $"Select * From PAYROLL_DEDUCTIONS where ID = '{deduc_id}'"
        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_DEDUCTIONS")
            If ds.Tables(0).Rows.Count > 0 Then
                With ds.Tables(0).Rows(0)
                    .Item("STATUS") = "PAID"            '====== PAID STATUS IN PAYROLL_DEDUCTIONS ====== 
                End With
                SaveEntry(ds, False)
            End If
        End Using
    End Sub

    Friend Sub SaveDEDUCTION_HISTORY(EMP_ID As String, H_CATEGORY As String, H_AMOUNT As String, PAID_DATE As String, PAYDATE As String, H_DEDUC_ID As String)

        Dim mysql As String = "Select * From HISTORY_DEDUCTION Rows 1"
        Using ds As DataSet = LoadSQL(mysql, "HISTORY_DEDUCTION")

            Dim dsNewRow As DataRow = ds.Tables(0).NewRow
            With dsNewRow

                .Item("EMP_ID") = EMP_ID
                .Item("PAYDATE") = PAYDATE
                .Item("H_CATEGORY") = H_CATEGORY
                .Item("H_AMOUNT") = H_AMOUNT
                .Item("PAID_DATE") = PAID_DATE
                .Item("H_DEDUC_ID") = H_DEDUC_ID

            End With
            ds.Tables(0).Rows.Add(dsNewRow)
            SaveEntry(ds)
        End Using
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
    Friend Sub AllowanceRemove(bioNo As String, branchID As String, category As String)
        Dim mysql As String

        mysql = $"Select * FROM PAYROLL_ALLOWANCES where BIOMETRIC_NO = '{bioNo}' and BRANCH_ID = '{branchID}'"
        Dim ds As DataSet = LoadSQL(mysql, "PAYROLL_ALLOWANCES")
        If ds.Tables(0).Rows.Count > 0 Then

            With ds.Tables(0).Rows(0)

                .Item("ALLOWED") = "NO"

            End With
            SaveEntry(ds, False)

            MsgBox("Successfully Removed from the list!", MsgBoxStyle.Information, "Information")
        End If

    End Sub

    Friend Sub SaveDeductionS(EMP_ID As String, category As String, TOTAL_AMOUNT As String, NO_OF_GIVES As String, AMOUNT_PER_GIVE As String, SCHEDULE As String, bioNo As String, branchID As String, effectivity As String)

        Dim mysql As String = "Select * From PAYROLL_DEDUCTIONS Rows 1"
        Using dss As DataSet = LoadSQL(mysql, "PAYROLL_DEDUCTIONS")

            Dim dsNewRow As DataRow = dss.Tables(0).NewRow
            With dsNewRow

                .Item("BIOMETRIC_NO") = bioNo
                .Item("BRANCHID") = branchID
                .Item("EMP_ID") = EMP_ID
                .Item("CATEGORY") = category
                .Item("TOTAL_AMOUNT") = TOTAL_AMOUNT
                .Item("NO_OF_GIVES") = NO_OF_GIVES
                .Item("AMOUNT_PER_GIVE") = AMOUNT_PER_GIVE
                .Item("SCHEDULE") = SCHEDULE
                .Item("EFFECTIVE_DATE") = effectivity

            End With
            dss.Tables(0).Rows.Add(dsNewRow)
            SaveEntry(dss)

            MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Information")
        End Using
    End Sub

    Friend Sub updateDeductionS(deduc_id As String, category As String, TOTAL_AMOUNT As String, NO_OF_GIVES As String, AMOUNT_PER_GIVE As String, SCHEDULE As String, effectivity As String)

        Dim mysql As String = $"Select * FROM PAYROLL_DEDUCTIONS where id = '{deduc_id}'"
        Dim ds As DataSet = LoadSQL(mysql, "PAYROLL_DEDUCTIONS")
        If ds.Tables(0).Rows.Count > 0 Then

            With ds.Tables(0).Rows(0)

                .Item("CATEGORY") = category
                .Item("TOTAL_AMOUNT") = TOTAL_AMOUNT
                .Item("NO_OF_GIVES") = NO_OF_GIVES
                .Item("AMOUNT_PER_GIVE") = AMOUNT_PER_GIVE
                .Item("SCHEDULE") = SCHEDULE
                .Item("EFFECTIVE_DATE") = effectivity

            End With
            SaveEntry(ds, False)

            MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Information")

        End If

    End Sub

    Friend Sub SaveSBU(amount As String)
        Dim mysql As String

        mysql = $"Select * FROM PAYROLL_SBU WHERE id = 1 "
        Dim ds As DataSet = LoadSQL(mysql, "PAYROLL_SBU")
        If ds.Tables(0).Rows.Count > 0 Then

            With ds.Tables(0).Rows(0)

                .Item("SBU_AMOUNT") = amount

            End With
            SaveEntry(ds, False)

            MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Information")

        Else
            mysql = "Select * From PAYROLL_SBU Rows 1"
            Using dss As DataSet = LoadSQL(mysql, "PAYROLL_SBU")

                Dim dsNewRow As DataRow = dss.Tables(0).NewRow
                With dsNewRow

                    .Item("SBU_AMOUNT") = amount

                End With
                dss.Tables(0).Rows.Add(dsNewRow)
                SaveEntry(dss)

                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Information")
            End Using
        End If

    End Sub

    Friend Sub SavePayout(BIOMETRIC_ID As String, BRANCH_ID As String, PAYDATE As String, TOTAL_BASIC As String, TOTAL_OVERTIME As String, TOTAL_LATE_UT As String,
                          GROSS_AMOUNT As String, SSS_COMP As String, PAGIBIG_COMP As String, PHILHEALTH_COMP As String, TAX_WHELD As String,
                          NET_TAX_COMP As String, SSS_LOAN As String, PAGIBIG_LOAN As String, TOTAL_ALLOWANCE As String,
                          TOTAL_DEDUCTION As String, NET_PAY As String, Optional all As String = "")

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
                    '.Item("TAXABLE") = TAXABLE
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

            If all = "" Then
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
                    '.Item("TAXABLE") = TAXABLE
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
            End Using

            If all = "" Then
                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Information")
            End If
        End If
    End Sub

    Friend Sub SavePayout_MODIFIED_DEDUCTION(EMP_ID As String, PAYDATE As String, CATEGORY As String, M_Amount As String, AMOUNT_PER_GIVE As String, DATE_CREATED As String, M_DEDUC_ID As String)

        Dim mysql As String = "Select * From MODIFIED_DEDUCTION Rows 1"
        Using ds As DataSet = LoadSQL(mysql, "MODIFIED_DEDUCTION")
            Dim dsNewRow As DataRow = ds.Tables(0).NewRow
            With dsNewRow

                Dim toUpper = CATEGORY.ToUpper()

                .Item("EMP_ID") = EMP_ID
                .Item("PAYDATE") = PAYDATE
                .Item("M_CATEGORY") = toUpper
                .Item("M_Amount") = M_Amount
                .Item("AMOUNT_PER_GIVE") = AMOUNT_PER_GIVE
                .Item("DATE_CREATED") = DATE_CREATED
                .Item("M_DEDUC_ID") = M_DEDUC_ID

            End With

            ds.Tables(0).Rows.Add(dsNewRow)
            SaveEntry(ds)
        End Using
    End Sub

    Friend Sub SavePayout_ALL(paydate_ As String) '========== AUTO SAVE TO PAYOUT ============ 

        Dim regHoliday = Holiday_Rate("REGULAR")
        Dim specHoliday = Holiday_Rate("SPECIAL")
        Dim SBU = SBU_Amount()

        Dim mysql As String = $"Select A.*, B.*, B.id as emp_idd, C.* From payroll_attendance A 
                                inner join TBL_EMPLOYEE B on B.BIOMETRICID = A.BIOMETRICID 
                                left join TBL_BRANCH C on C.BRANCHNAME = A.BRANCH and B.BRANCH_ID = C.ID WHERE A.PAYDATE = '{paydate_}'"

        Using ds As DataSet = LoadSQL(mysql, "payroll_attendance")
            If ds.Tables(0).Rows.Count > 0 Then

                progressBarStart(ds.Tables(0).Rows.Count)

                For Each dr In ds.Tables(0).Rows
                    With dr

                        Dim emp_id, BiometricID, branchID, sched As String
                        Dim Late As String = ""
                        Dim UnderTime As String = ""
                        Dim rate, NoOfDays, RegularOT, SpecialHol, RegularHol As Double
                        Dim Allowances, Deduction As Double

                        BiometricID = .Item("BIOMETRICID")
                        rate = IIf(IsDBNull(.Item("RATE")), 0, .Item("RATE"))
                        branchID = .Item("BRANCH_ID")
                        emp_id = .Item("emp_idd")

                        '============================================= ATTENDANCE (TOTAL DAYS) =========================================================
                        Dim sql_1 As String = $"Select * From PAYROLL_ATTENDANCE WHERE BIOMETRICID = '{BiometricID}' and paydate = '{paydate_}'"
                        Using ds_1 As DataSet = LoadSQL(sql_1, "PAYROLL_ATTENDANCE")
                            If ds_1.Tables(0).Rows.Count > 0 Then

                                Dim dr_11 As DataRow = ds_1.Tables(0).Rows(0)
                                With dr_11
                                    NoOfDays = .Item("PRESENT_DAYS")
                                    RegularOT = .Item("OVERTIME")
                                    SpecialHol = .Item("SPECHOLIDAY")
                                    RegularHol = .Item("REGHOLIDAY")
                                    Late = .Item("LATE")
                                    UnderTime = .Item("UNDERTIME")
                                End With
                            End If
                        End Using

                        '============================================= BENIFITS CONTRIBUTION ========================================================= 
                        Dim TotalBasic, SSSComp, PagibigComp, PhilhealthComp, Tax_Wheld, netTax, sssLoan, pagibigLoan As Double

                        TotalBasic = NoOfDays * rate

                        Dim date_pay As DateTime = Convert.ToDateTime(paydate_)
                        date_pay = date_pay.ToString("d")

                        If IsLastDay(date_pay) Then

                            Dim first_Basic As Double = GetFirst_Basic(BiometricID, branchID, paydate_)
                            Dim monthly_Basic As Double = TotalBasic + first_Basic

                            SSSComp = Get_SSS(monthly_Basic)
                            PagibigComp = Get_Pagibig(monthly_Basic)
                            PhilhealthComp = Get_PhilHealth(monthly_Basic)
                            Tax_Wheld = Get_WHolding(monthly_Basic)

                            'TaxComp = Get_Taxable(monthly_Basic)
                            'SSS_ER = Get_SSS_ER(monthly_Basic)

                            netTax = monthly_Basic - (SSSComp + PagibigComp + PhilhealthComp + Tax_Wheld)

                            sssLoan = Get_LOAN_SSS(emp_id)
                            pagibigLoan = Get_LOAN_Pagibig(emp_id)

                            sched = "CLOSE PAYROLL"
                        Else
                            netTax = 0
                            sched = "OPEN PAYROLL"
                        End If


                        '============================================= ALLOWANCE =========================================================
                        Allowances = 0

                        Dim sql_2 As String = $"Select * From PAYROLL_ALLOWANCES WHERE BIOMETRIC_NO = '{BiometricID}' and BRANCH_ID = '{branchID}'  and ALLOWED is null and SCHEDULE = '{sched}'"
                        Using ds_2 As DataSet = LoadSQL(sql_2, "PAYROLL_ALLOWANCES")
                            If ds_2.Tables(0).Rows.Count > 0 Then
                                For Each dr_2 In ds_2.Tables(0).Rows
                                    With dr_2
                                        If .item("EFFECTIVE_DATE") <= Today Then
                                            Allowances = Allowances + .Item("AMOUNT")
                                        End If
                                    End With
                                Next
                            End If
                        End Using

                        '============================================= DEDUCTION =========================================================  
                        Deduction = 0

                        Dim sql_3 As String = $"Select * From PAYROLL_DEDUCTIONS WHERE BIOMETRIC_NO = '{BiometricID}' and BRANCHID = '{branchID}' and STATUS is null and (SCHEDULE = '{sched}' or SCHEDULE = 'EVERY PAYROLL')"
                        Using ds_3 As DataSet = LoadSQL(sql_3, "PAYROLL_DEDUCTIONS")
                            If ds_3.Tables(0).Rows.Count > 0 Then
                                For Each dr_3 In ds_3.Tables(0).Rows
                                    With dr_3
                                        If .item("EFFECTIVE_DATE") <= Today Then
                                            Deduction = Deduction + .Item("AMOUNT_PER_GIVE")
                                        End If
                                    End With
                                Next
                            End If
                        End Using
                        Deduction = Deduction + SBU

                        '============================================= Calculate_Gross() ========================================================= 
                        Dim TotalHol, TotalOT, TotalLateUnder, GrossAmount As Double

                        TotalHol = (((SpecialHol * rate) * specHoliday) / specHoliday) + (((RegularHol * rate) * regHoliday) / regHoliday) ' =========== CALCULATE hOLIDAY TO PESO ===========

                        TotalOT = ((rate / 8) * 1.25) * RegularOT ' =========== CALCULATE OVERTIME TO PESO ===========

                        Dim late_split() As String, under_split() As String, lateTOMinute, underToMinute As Double

                        late_split = Split(Late, ":")
                        under_split = Split(UnderTime, ":")

                        lateTOMinute = CDbl(late_split(0)) * 60 + CDbl(late_split(1)) + CDbl(late_split(2)) / 60
                        underToMinute = (CDbl(under_split(0)) * 60 + CDbl(under_split(1)) + CDbl(under_split(2)) / 60) / 60

                        Dim LATEE, UNDERTIMEE As Double
                        LATEE = ((rate / 8) / 60) * lateTOMinute
                        UNDERTIMEE = (rate / 8) * underToMinute

                        TotalLateUnder = LATEE + UNDERTIMEE

                        GrossAmount = (TotalBasic + TotalHol + TotalOT) - TotalLateUnder


                        '============================================= Calculate =========================================================  
                        Dim NetPay As Double

                        Dim CONTRIB As Double = SSSComp + PagibigComp + PhilhealthComp + Tax_Wheld

                        Dim positive, negative As Double
                        If IsLastDay(paydate_) Then
                            positive = GrossAmount + Allowances
                            negative = CONTRIB + sssLoan + pagibigLoan + Deduction
                        Else
                            'netTax = 0
                            positive = GrossAmount + Allowances
                            negative = Deduction
                        End If

                        NetPay = positive - negative

                        SavePayout(BiometricID, branchID, paydate_, TotalBasic, TotalOT,
                                  TotalLateUnder, GrossAmount, SSSComp, PagibigComp, PhilhealthComp,
                                  Tax_Wheld, netTax, sssLoan, pagibigLoan,
                                  Allowances, Deduction, NetPay, "Group")

                        frmMainForm.AppProgressBar.Value += 1
                    End With
                Next
            End If
        End Using

        progressBarEnd()
    End Sub


    Friend Sub SavePayout_IndividualL(bioNo As String, branch As String, paydate_ As String) '========== AUTO SAVE TO PAYOUT ============ 

        Dim regHoliday = Holiday_Rate("REGULAR")
        Dim specHoliday = Holiday_Rate("SPECIAL")
        Dim SBU = SBU_Amount()

        Dim mysql As String = $"Select * From payroll_attendance A 
                                inner join TBL_EMPLOYEE B on B.BIOMETRICID = A.BIOMETRICID 
                                left join TBL_BRANCH C on C.BRANCHNAME = A.BRANCH and B.BRANCH_ID = C.ID 
                                    WHERE A.BIOMETRICID = '{bioNo}' and A.BRANCH = '{branch}' and A.PAYDATE = '{paydate_}'"
        Using ds As DataSet = LoadSQL(mysql, "payroll_attendance")
            If ds.Tables(0).Rows.Count > 0 Then

                Dim dr As DataRow = ds.Tables(0).Rows(0)
                With dr

                    Dim branchID As String = .Item("BRANCH_ID")
                    Dim Late As String = ""
                    Dim UnderTime As String = ""
                    Dim rate, NoOfDays, RegularOT, SpecialHol, RegularHol As Double
                    Dim Positional, Incentive, Boarding, Carekit, Transport, CashAdvance, Loan, Charges, Allowances, Deduction As Double

                    rate = IIf(IsDBNull(.Item("RATE")), 0, .Item("RATE"))

                    '============================================= ATTENDANCE (TOTAL DAYS) =========================================================
                    Dim sql_1 As String = $"Select * From PAYROLL_ATTENDANCE WHERE BIOMETRICID = '{bioNo}' and paydate = '{paydate_}'"
                    Using ds_1 As DataSet = LoadSQL(sql_1, "PAYROLL_ATTENDANCE")
                        If ds_1.Tables(0).Rows.Count > 0 Then

                            Dim dr_11 As DataRow = ds_1.Tables(0).Rows(0)
                            With dr_11
                                NoOfDays = .Item("PRESENT_DAYS")
                                RegularOT = .Item("OVERTIME")
                                SpecialHol = .Item("SPECHOLIDAY")
                                RegularHol = .Item("REGHOLIDAY")
                                Late = .Item("LATE")
                                UnderTime = .Item("UNDERTIME")
                            End With
                        End If
                    End Using

                    '============================================= ALLOWANCE =========================================================
                    Allowances = 0

                    Dim sql_2 As String = $"Select * From PAYROLL_ALLOWANCES WHERE BIOMETRIC_NO = '{bioNo}' and BRANCH_ID = '{branchID}'"
                    Using ds_2 As DataSet = LoadSQL(sql_2, "PAYROLL_ALLOWANCES")
                        If ds_2.Tables(0).Rows.Count > 0 Then
                            For Each dr_2 In ds_2.Tables(0).Rows
                                With dr_2
                                    Allowances = Allowances + .Item("AMOUNT")
                                End With
                            Next
                        End If
                    End Using

                    '============================================= DEDUCTION =========================================================  
                    Deduction = 0

                    Dim sql_3 As String = $"Select * From PAYROLL_DEDUCTIONS WHERE BIOMETRIC_NO = '{bioNo}' and BRANCHID = '{branchID}'"
                    Using ds_3 As DataSet = LoadSQL(sql_3, "PAYROLL_DEDUCTIONS")
                        If ds_3.Tables(0).Rows.Count > 0 Then
                            For Each dr_3 In ds_3.Tables(0).Rows
                                With dr_3
                                    Deduction = Deduction + .Item("AMOUNT_PER_GIVE")
                                End With
                            Next
                        End If
                    End Using

                    '============================================= BENIFITS CONTRIBUTION ========================================================= 
                    Dim TotalBasic, SSSComp, PagibigComp, PhilhealthComp, Tax_Wheld, netTax, sssLoan, pagibigLoan As Double

                    TotalBasic = NoOfDays * rate

                    Dim date_pay As DateTime = Convert.ToDateTime(paydate_)
                    date_pay = date_pay.ToString("d")

                    If IsLastDay(date_pay) Then

                        Dim first_Basic As Double = GetFirst_Basic(bioNo, branchID, paydate_)
                        Dim monthly_Basic As Double = TotalBasic + first_Basic

                        SSSComp = Get_SSS(monthly_Basic)
                        PagibigComp = Get_Pagibig(monthly_Basic)
                        PhilhealthComp = Get_PhilHealth(monthly_Basic)
                        Tax_Wheld = Get_WHolding(monthly_Basic)

                        'TaxComp = Get_Taxable(monthly_Basic)
                        'SSS_ER = Get_SSS_ER(monthly_Basic)

                        netTax = monthly_Basic - (SSSComp + PagibigComp + PhilhealthComp + Tax_Wheld)
                    Else
                        netTax = 0
                    End If

                    '============================================= Calculate_Gross() ========================================================= 
                    Dim TotalHol, TotalOT, TotalLateUnder, GrossAmount As Double

                    TotalHol = (((SpecialHol * rate) * specHoliday) / specHoliday) + (((RegularHol * rate) * regHoliday) / regHoliday) ' =========== CALCULATE hOLIDAY TO PESO ===========

                    TotalOT = ((rate / 8) * 1.25) * RegularOT ' =========== CALCULATE OVERTIME TO PESO ===========

                    Dim late_split() As String, under_split() As String, lateTOMinute, underToMinute As Double

                    late_split = Split(Late, ":")
                    under_split = Split(UnderTime, ":")

                    lateTOMinute = CDbl(late_split(0)) * 60 + CDbl(late_split(1)) + CDbl(late_split(2)) / 60
                    underToMinute = (CDbl(under_split(0)) * 60 + CDbl(under_split(1)) + CDbl(under_split(2)) / 60) / 60

                    Dim LATEE, UNDERTIMEE As Double
                    LATEE = ((rate / 8) / 60) * lateTOMinute
                    UNDERTIMEE = (rate / 8) * underToMinute

                    TotalLateUnder = LATEE + UNDERTIMEE

                    GrossAmount = (TotalBasic + TotalHol + TotalOT) - TotalLateUnder


                    '============================================= Calculate =========================================================  
                    Dim NetPay As Double

                    Allowances = Carekit + Boarding + Incentive + Positional + Transport
                    Deduction = SBU + Charges + Loan + CashAdvance

                    Dim positive, negative As Double
                    If IsLastDay(paydate_) Then
                        positive = netTax + Allowances
                        negative = sssLoan + pagibigLoan + Deduction
                    Else
                        'netTax = 0
                        positive = GrossAmount + Allowances
                        negative = Deduction
                    End If

                    NetPay = positive - negative

                    SavePayout(bioNo, branchID, paydate_, TotalBasic, TotalOT,
                                  TotalLateUnder, GrossAmount, SSSComp, PagibigComp, PhilhealthComp,
                                  Tax_Wheld, netTax, sssLoan, pagibigLoan,
                                  Allowances, Deduction, NetPay)
                End With
            End If
        End Using
    End Sub


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

        For Each row As DataGridViewRow In datagird.Rows
            Dim mysql As String = $"Select * FROM PAYROLL_WHOLDING"
            Dim dss As DataSet = LoadSQL(mysql, "PAYROLL_WHOLDING")
            Dim dsNewRow As DataRow = dss.Tables(0).NewRow
            With dsNewRow
                .Item("COMP_RANGE") = row.Cells(0).Value
                .Item("PRESCRIBE_WH_TAX") = row.Cells(1).Value
            End With

            dss.Tables(0).Rows.Add(dsNewRow)
            SaveEntry(dss)
        Next

        MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Information")
        RunCommand("DELETE FROM PAYROLL_WHOLDING WHERE COMP_RANGE is null")

    End Sub

    Friend Sub SaveAllowance(emp_id As String, bioNo As String, branchID As String, category As String, amount As String, fix As String, SCHEDULE As String, DAY_DATE As String, EFFECTIVE_DATE As String)
        Dim mysql As String = "Select * From PAYROLL_ALLOWANCES Rows 1"
        Using dss As DataSet = LoadSQL(mysql, "PAYROLL_ALLOWANCES")

            Dim dsNewRow As DataRow = dss.Tables(0).NewRow
            With dsNewRow

                .Item("BIOMETRIC_NO") = bioNo
                .Item("BRANCH_ID") = branchID
                .Item("category") = category
                .Item("AMOUNT") = amount
                .Item("fix") = fix
                .Item("SCHEDULE") = SCHEDULE
                .Item("DAY_DATE") = DAY_DATE
                .Item("EFFECTIVE_DATE") = EFFECTIVE_DATE
                .Item("emp_id") = emp_id

            End With
            dss.Tables(0).Rows.Add(dsNewRow)
            SaveEntry(dss)

            MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Information")
        End Using

    End Sub

    Friend Sub Save_SSSLoan(emp_id As String, monthly_amort As String, first_date As String, maturity_date As String)
        Dim mysql As String

        mysql = $"Select * FROM PAYROLL_SSSLOAN where emp_id = '{emp_id}' and STATUS is null"
        Dim ds As DataSet = LoadSQL(mysql, "PAYROLL_SSSLOAN")
        If ds.Tables(0).Rows.Count > 0 Then

            With ds.Tables(0).Rows(0)

                .Item("monthly_amort") = monthly_amort
                .Item("first_date") = first_date
                .Item("maturity_date") = maturity_date

            End With

            SaveEntry(ds, False)
            MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Information")

        Else
            mysql = "Select * From PAYROLL_SSSLOAN Rows 1"
            Using dss As DataSet = LoadSQL(mysql, "PAYROLL_SSSLOAN")

                Dim dsNewRow As DataRow = dss.Tables(0).NewRow
                With dsNewRow

                    .Item("emp_id") = emp_id
                    .Item("monthly_amort") = monthly_amort
                    .Item("first_date") = first_date
                    .Item("maturity_date") = maturity_date

                End With
                dss.Tables(0).Rows.Add(dsNewRow)
                SaveEntry(dss)

                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Information")
            End Using
        End If

    End Sub

    Friend Sub Save_PAGIBIGLoan(emp_id As String, amount As String, start_date As String, end_date As String)
        Dim mysql As String

        mysql = $"Select * FROM PAYROLL_PAGIBIGLOAN where emp_id = '{emp_id}' and STATUS is null"
        Dim ds As DataSet = LoadSQL(mysql, "PAYROLL_PAGIBIGLOAN")
        If ds.Tables(0).Rows.Count > 0 Then

            With ds.Tables(0).Rows(0)

                .Item("monthly_amort") = amount
                .Item("first_date") = start_date
                .Item("maturity_date") = end_date

            End With

            SaveEntry(ds, False)
            MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Information")

        Else
            mysql = "Select * From PAYROLL_PAGIBIGLOAN Rows 1"
            Using dss As DataSet = LoadSQL(mysql, "PAYROLL_PAGIBIGLOAN")

                Dim dsNewRow As DataRow = dss.Tables(0).NewRow
                With dsNewRow

                    .Item("emp_id") = emp_id
                    .Item("monthly_amort") = amount
                    .Item("first_date") = start_date
                    .Item("maturity_date") = end_date

                End With
                dss.Tables(0).Rows.Add(dsNewRow)
                SaveEntry(dss)

                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Information")
            End Using
        End If

    End Sub

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

End Module
