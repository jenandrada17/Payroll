Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Microsoft.Office.Interop
Imports OfficeOpenXml

Module Temporary

    Dim MyConnection As System.Data.OleDb.OleDbConnection
    Dim DtSet As System.Data.DataSet
    Dim MyCommand As System.Data.OleDb.OleDbDataAdapter

    Dim eApp As New Excel.Application
    Dim eBook As Excel.Workbook = Nothing
    Dim eSheet As Excel.Worksheet = Nothing
    Dim eCell As Excel.Range

    'Friend Sub Import_Employee_SBU_DATE_ONLY(Path As String)

    '    eApp = New Excel.Application
    '    eBook = eApp.Workbooks.Open(Path)
    '    eSheet = eBook.Worksheets(1)
    '    eCell = eSheet.UsedRange

    '    MyConnection = New System.Data.OleDb.OleDbConnection($"provider=Microsoft.Jet.OLEDB.4.0;Data Source='{Path}';Extended Properties=Excel 8.0;")
    '    MyCommand = New System.Data.OleDb.OleDbDataAdapter($"select * from [{eSheet.Name}$]", MyConnection)
    '    MyCommand.TableMappings.Add("Table", "Net-informations.com")
    '    DtSet = New System.Data.DataSet
    '    MyCommand.Fill(DtSet)

    '    progressBarStart(DtSet.Tables(0).Rows.Count + 1)

    '    Dim EMP_NO As String = Nothing

    '    For row = 7 To DtSet.Tables(0).Rows.Count

    '        If eCell(row, 1).Font.Bold = True Then
    '            EMP_NO = eCell(row, 4).Value
    '        End If

    '        If EMP_NO <> Nothing And IsDate(eCell(row, 1).value) Then
    '            Dim datee As DateTime = eCell(row, 1).Value
    '            UPDATE_Emp_SBU_EXCEL_DATEONLY(EMP_NO, datee, row)

    '            EMP_NO = Nothing
    '        End If

    '        frmMainForm.AppProgressBar.Value += 1
    '    Next row

    '    progressBarEnd()

    '    MyConnection.Close()
    '    eApp.Quit()
    '    eApp.Application.DisplayAlerts = False

    'End Sub

    Friend Sub SSS_Contribution_2023()

        Dim Path As String = "C:\Users\MISPC1\Desktop\SSS Contribution 2023.txt"

        For Each line As String In IO.File.ReadAllLines(Path)
            Dim slices As String() = line.Split(vbTab)

            'SaveToSSS_Table(slices(0), slices(1), slices(2), slices(3), slices(4), slices(5), slices(6), slices(7), slices(8), slices(9), slices(10), slices(11), slices(12), slices(13), slices(14), slices(15), 2023)
            UpdateSSS_Table(slices(0), slices(1), slices(2), slices(3), slices(4), slices(5), slices(6), slices(7), slices(8), slices(9), slices(10), slices(11), slices(12), slices(13), slices(14), slices(15), 2023)
        Next

    End Sub

    Public Sub UpdateSSS_Table(RANGECOMP As String, RSS_EC As String, MPF As String, TOTAL As String,
                               RSS_ER As String, RSS_EE As String, RSS_TOTAL As String,
                               EC_ER As String, EC_EE As String, EC_TOTAL As String,
                               MPF_ER As String, MPF_EE As String, MPF_TOTAL As String,
                               TOTAL_ER As String, TOTAL_EE As String, TOTAL_TOTAL As String, YEAR_COVERED As Integer)

        Dim mysql As String = $"Select * From PAYROLL_SSS where RANGECOMP = '{RANGECOMP}'"
        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_SSS")
            With ds.Tables(0).Rows(0)
                .Item("RANGECOMP") = RANGECOMP
                .Item("RSS_EC") = RSS_EC
                .Item("MPF") = MPF
                .Item("TOTAL") = TOTAL
                .Item("RSS_ER") = RSS_ER
                .Item("RSS_EE") = RSS_EE
                .Item("RSS_TOTAL") = RSS_TOTAL
                .Item("EC_ER") = EC_ER
                .Item("EC_EE") = EC_EE
                .Item("EC_TOTAL") = EC_TOTAL
                .Item("MPF_ER") = MPF_ER
                .Item("MPF_EE") = MPF_EE
                .Item("MPF_TOTAL") = MPF_TOTAL
                .Item("TOTAL_ER") = TOTAL_ER
                .Item("TOTAL_EE") = TOTAL_EE
                .Item("TOTAL_TOTAL") = TOTAL_TOTAL
                .Item("YEAR_COVERED") = YEAR_COVERED
            End With
            SaveEntry(ds, False)
        End Using
    End Sub

    Public Sub SaveToSSS_Table(RANGECOMP As String, RSS_EC As String, MPF As String, TOTAL As String,
                               RSS_ER As String, RSS_EE As String, RSS_TOTAL As String,
                               EC_ER As String, EC_EE As String, EC_TOTAL As String,
                               MPF_ER As String, MPF_EE As String, MPF_TOTAL As String,
                               TOTAL_ER As String, TOTAL_EE As String, TOTAL_TOTAL As String, YEAR_COVERED As Integer)

        Dim mysql As String = $"Select * From PAYROLL_SSS Rows 1"
        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_SSS")
            Dim dsNew As DataRow = ds.Tables(0).NewRow
            With dsNew
                .Item("RANGECOMP") = RANGECOMP
                .Item("RSS_EC") = RSS_EC
                .Item("MPF") = MPF
                .Item("TOTAL") = TOTAL
                .Item("RSS_ER") = RSS_ER
                .Item("EC_ER") = EC_ER
                .Item("EC_EE") = EC_EE
                .Item("EC_EE") = EC_TOTAL
                .Item("MPF_ER") = MPF_ER
                .Item("MPF_EE") = MPF_EE
                .Item("MPF_TOTAL") = MPF_TOTAL
                .Item("TOTAL_ER") = TOTAL_ER
                .Item("TOTAL_EE") = TOTAL_EE
                .Item("TOTAL_TOTAL") = TOTAL_TOTAL
                .Item("YEAR_COVERED") = YEAR_COVERED
            End With
            ds.Tables(0).Rows.Add(dsNew)
            SaveEntry(ds)
        End Using
    End Sub

    'Public Sub UPDATE_Emp_SBU_EXCEL_DATEONLY(emp_no As String, datee As String, RowNo As Integer)
    '    Dim mysql As String = $"Select * From PAYROLL_SBU A inner join PAYROLL_EMPLOYEE B on B.BIO_NO=A.BIO_NO where EMP_NO='{emp_no}'"
    '    Using dssS As DataSet = LoadSQL(mysql, "PAYROLL_SBU")
    '        If dssS.Tables(0).Rows.Count > 0 Then
    '            With dssS.Tables(0).Rows(0)
    '                .Item("DATE_ADDED") = datee
    '            End With
    '            SaveEntry(dssS, False)
    '        End If
    '    End Using
    'End Sub

    Friend Sub SaveTemporary(BIO_NO As String, old_days As Double, new_days As Double, OLD_OVERTIME As Double, NEW_OVERTIME As Double, OLD_LATE As Double, NEW_LATE As Double, OLD_UNDERTIME As Double, NEW_UNDERTIME As Double, RHOLIDAY As Double, SHOLIDAY As Double, PAYDATE As String)
        Dim mysql As String = $"Select * from TEMP_TABLE where BIO_NO = '{BIO_NO}' and PAYDATE = '{PAYDATE}'"
        Using ds As DataSet = LoadSQL(mysql, "TEMP_TABLE")
            If ds.Tables(0).Rows.Count > 0 Then
                With ds.Tables(0).Rows(0)
                    .Item("OLD_DAYS") = old_days
                    .Item("NEW_DAYS") = new_days
                    .Item("OLD_OVERTIME") = OLD_OVERTIME
                    .Item("NEW_OVERTIME") = NEW_OVERTIME
                    .Item("OLD_LATE") = OLD_LATE
                    .Item("NEW_LATE") = NEW_LATE
                    .Item("OLD_UNDERTIME") = OLD_UNDERTIME
                    .Item("NEW_UNDERTIME") = NEW_UNDERTIME
                    .Item("RHOLIDAY") = RHOLIDAY
                    .Item("SHOLIDAY") = SHOLIDAY
                    .Item("PAYDATE") = PAYDATE
                End With
                SaveEntry(ds, False)
            Else
                mysql = "Select * From TEMP_TABLE Rows 1"
                Using dss As DataSet = LoadSQL(mysql, "TEMP_TABLE")
                    Dim dsNew As DataRow = dss.Tables(0).NewRow
                    With dsNew
                        .Item("BIO_NO") = BIO_NO
                        .Item("OLD_DAYS") = old_days
                        .Item("NEW_DAYS") = new_days
                        .Item("OLD_OVERTIME") = OLD_OVERTIME
                        .Item("NEW_OVERTIME") = NEW_OVERTIME
                        .Item("OLD_LATE") = OLD_LATE
                        .Item("NEW_LATE") = NEW_LATE
                        .Item("OLD_UNDERTIME") = OLD_UNDERTIME
                        .Item("NEW_UNDERTIME") = NEW_UNDERTIME
                        .Item("RHOLIDAY") = RHOLIDAY
                        .Item("SHOLIDAY") = SHOLIDAY
                        .Item("PAYDATE") = PAYDATE
                    End With
                    dss.Tables(0).Rows.Add(dsNew)
                    SaveEntry(dss)
                End Using
            End If
        End Using
    End Sub

    '===================== TRAINING HOLIDAY ==================    
    Friend Function OLD_NEW_RATE(BIO_NO As String, paydate As String) As (old_days As Double, new_days As Double, old_overtime As Double,
                    new_overtime As Double, old_late As Double, new_late As Double, old_undertime As Double, new_undertime As Double)

        Dim old_days As Double = 0
        Dim new_days As Double = 0
        Dim old_overtime As Double = 0
        Dim new_overtime As Double = 0
        Dim old_late As Double = 0
        Dim new_late As Double = 0
        Dim old_undertime As Double = 0
        Dim new_undertime As Double = 0
        Dim temp_days As Double = 0

        Dim _mysql As String = $"Select * from TEMP_TABLE where BIO_NO = '{BIO_NO}' and PAYDATE = '{paydate}'"
        Using _ds As DataSet = LoadSQL(_mysql, "TEMP_TABLE")
            If _ds.Tables(0).Rows.Count > 0 Then
                With _ds.Tables(0).Rows(0)
                    old_days = .Item("OLD_DAYS")
                    new_days = .Item("NEW_DAYS")
                    old_overtime = .Item("OLD_OVERTIME")
                    new_overtime = .Item("NEW_OVERTIME")
                    old_late = .Item("OLD_LATE")
                    new_late = .Item("NEW_LATE")
                    old_undertime = .Item("OLD_UNDERTIME")
                    new_undertime = .Item("NEW_UNDERTIME")
                End With
            End If
        End Using

        Return (old_days, new_days, old_overtime, new_overtime, old_late, new_late, old_undertime, new_undertime)
    End Function
    '=========================================================

    '===================== MINIMUM HOLIDAY COVERED==================    
    Friend Function REG_SPEC_HOLIDAY(BIO_NO As String, paydate As String) As (rholiday As Integer, sholiday As Integer)

        Dim Rdays As Integer = 0
        Dim Sdays As Integer = 0

        Dim _mysql As String = $"Select * from TEMP_TABLE where BIO_NO = '{BIO_NO}' AND PAYDATE = '{paydate}'"
        Using _ds As DataSet = LoadSQL(_mysql, "TEMP_TABLE")
            If _ds.Tables(0).Rows.Count > 0 Then
                With _ds.Tables(0).Rows(0)
                    Rdays = .Item("RHOLIDAY")
                    Sdays = .Item("SHOLIDAY")
                End With
            End If
        End Using

        Return (Rdays, Sdays)
    End Function
    '=========================================================

    'Friend Sub PayoutRate()
    '    Dim mysql As String = "Select BIOMETRIC_ID, PRESENT_DAYS, TOTAL_BASIC, FIX_MONTHLY_RATE, RATE_MONTHLY, A.PAYDATE  from Payroll_Payout A 
    '                              inner join payroll_employee B on B.BIO_NO = A.BIOMETRIC_ID 
    '                              inner join payroll_attendance C on C.BIOMETRICID = A.BIOMETRIC_ID and C.PAYDATE = A.PAYDATE"

    '    Using ds As DataSet = LoadSQL(mysql, "Payroll_Payout")
    '        For Each dr In ds.Tables(0).Rows
    '            With dr

    '                Dim ratee As String = CDec(.item("TOTAL_BASIC")) / CDbl(.item("PRESENT_DAYS"))

    '                If .item("BIOMETRIC_ID") = 3888 Then
    '                    Console.WriteLine("TOTAL_BASIC  " & .item("TOTAL_BASIC"))
    '                End If

    '                If .item("TOTAL_BASIC") = "0" Then
    '                    ratee = 0
    '                ElseIf IsDBNull(.item("FIX_MONTHLY_RATE")) Then

    '                ElseIf .item("FIX_MONTHLY_RATE") = "True" Then
    '                    ratee = CDec(.item("RATE_MONTHLY")) / 26
    '                End If

    '                Console.WriteLine(.item("BIOMETRIC_ID"))
    '                Console.WriteLine(ratee)
    '                Console.WriteLine(.item("PAYDATE"))
    '                UpdateRate(.item("BIOMETRIC_ID"), ratee, .item("PAYDATE"))
    '            End With
    '        Next
    '    End Using
    'End Sub

    Friend Sub UpdateRate(bio As String, rate As String, paydate As String)
        Dim mysql As String = $"Select * from Payroll_Payout where BIOMETRIC_ID ='{bio}' and paydate = '{paydate}'"
        Using ds As DataSet = LoadSQL(mysql, "Payroll_Payout")
            If ds.Tables(0).Rows.Count > 0 Then
                With ds.Tables(0).Rows(0)

                    If paydate = "6/30/2022" Then rate = 352

                    .Item("RATE") = rate

                End With
                SaveEntry(ds, False)
            End If
        End Using
    End Sub

    Friend Sub Update_Recorded_Allow_Deduct_ID()

        Dim mysql As String = "Select A.*, B.ID as idd from RECORDED_ALLOW_DEDUC A 
                                  inner join payroll_deduction B on B.BIO_NO = A.BIO_NO and B.CATEGORY = A.CATEGORY 
                                  where A.PAYDATE = '7/31/2022'"

        Using ds As DataSet = LoadSQL(mysql, "RECORDED_ALLOW_DEDUC")
            For Each dr In ds.Tables(0).Rows
                With dr

                    Dim bio_no As String = .item("BIO_NO")
                    Dim category As String = .item("CATEGORY")
                    Dim paydate As String = .item("PAYDATE")
                    Dim r_deduct_id As String = .item("idd")

                    Console.WriteLine(bio_no)
                    Console.WriteLine(category)
                    Console.WriteLine(paydate)
                    Console.WriteLine(r_deduct_id)
                    UpdateDeduct_ID(bio_no, category, r_deduct_id, paydate)
                End With
            Next
        End Using
    End Sub

    Friend Sub UpdateDeduct_ID(BIO As String, category As String, R_DEDUC_ID As String, PAYDATE As String)
        Dim mysql As String = $"Select * from RECORDED_ALLOW_DEDUC where BIO_NO ='{BIO}' and category = '{category}' and paydate = '{PAYDATE}'"
        Using ds As DataSet = LoadSQL(mysql, "RECORDED_ALLOW_DEDUC")
            If ds.Tables(0).Rows.Count > 0 Then
                With ds.Tables(0).Rows(0)

                    .Item("R_DEDUC_ID") = R_DEDUC_ID

                End With
                SaveEntry(ds, False)
            End If
        End Using
    End Sub

    '=================================== PHILHEALTH ADJUSTMENTS (NAERASE) ===============================
    Friend Sub CopyPhilhealthAdjustment()
        Dim mysql As String = $"Select * from RECORDED_ALLOW_DEDUC1 where PAYDATE = '7/31/2022' and CATEGORY = 'Philhealth Adjustment'"
        Using ds As DataSet = LoadSQL(mysql, "RECORDED_ALLOW_DEDUC1")
            If ds.Tables(0).Rows.Count > 0 Then
                For Each dr In ds.Tables(0).Rows
                    With dr
                        SavePH_Adjustment(.Item("BIO_NO"), .Item("TRANSAC_NAME"), .Item("AMOUNT"), .Item("CATEGORY"), .Item("PAYDATE"))
                    End With
                Next
            End If
        End Using
    End Sub

    Private Sub SavePH_Adjustment(BIO_NO As String, TRANSAC_NAME As String, AMOUNT As String, CATEGORY As String, PAYDATE As String)
        Dim mysql As String = $"Select * from RECORDED_ALLOW_DEDUC"
        Using ds As DataSet = LoadSQL(mysql, "RECORDED_ALLOW_DEDUC")
            Dim dsNew As DataRow = ds.Tables(0).NewRow
            With dsNew
                .Item("BIO_NO") = BIO_NO
                .Item("TRANSAC_NAME") = TRANSAC_NAME
                .Item("AMOUNT") = AMOUNT
                .Item("CATEGORY") = CATEGORY
                .Item("PAYDATE") = PAYDATE
            End With

            ds.Tables(0).Rows.Add(dsNew)
            SaveEntry(ds)
        End Using
    End Sub

    Friend Sub CopyPAYOUT()
        Dim mysql As String = $"Select * from PAYROLL_PAYOUT1 where PAYDATE = '7/31/2022'"
        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_PAYOUT1")
            If ds.Tables(0).Rows.Count > 0 Then
                For Each dr In ds.Tables(0).Rows
                    With dr
                        SavePAYOUT(.Item("BIOMETRIC_ID"), .Item("RATE"), .Item("TOTAL_BASIC"), .Item("TOTAL_OVERTIME"), .Item("TOTAL_LATE_UT"),
                                          .Item("TOTAL_REGHOLIDAY"), .Item("TOTAL_SPECHOLIDAY"), .Item("GROSS_AMOUNT"), .Item("SSS_COMP"),
                                          .Item("SSS_ER"), .Item("SSS_EC"), .Item("PAGIBIG_COMP"), .Item("PHILHEALTH_COMP"),
                                          .Item("TOTAL_ALLOWANCE"), .Item("TOTAL_DEDUCTION"), .Item("TOTAL_NIGHT_RATE"), .Item("NET_PAY"))
                    End With
                Next
            End If
        End Using
    End Sub

    Private Sub SavePAYOUT(bio As String, RATE As Decimal, TOTAL_BASIC As Decimal, TOTAL_OVERTIME As Decimal, TOTAL_LATE_UT As Decimal,
                           TOTAL_REGHOLIDAY As Decimal, TOTAL_SPECHOLIDAY As Decimal, GROSS_AMOUNT As Decimal, SSS_COMP As Decimal,
                           SSS_ER As Decimal, SSS_EC As Decimal, PAGIBIG_COMP As Decimal, PHILHEALTH_COMP As Decimal,
                           TOTAL_ALLOWANCE As Decimal, TOTAL_DEDUCTION As Decimal, TOTAL_NIGHT_RATE As Decimal, NET_PAY As Decimal)

        Dim mysql As String = $"Select * from PAYROLL_PAYOUT WHERE BIOMETRIC_ID = '{bio}' AND PAYDATE = '7/31/2022'"
        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_PAYOUT")
            If ds.Tables(0).Rows.Count > 0 Then
                With ds.Tables(0).Rows(0)
                    .Item("RATE") = RATE
                    .Item("TOTAL_BASIC") = TOTAL_BASIC
                    .Item("TOTAL_OVERTIME") = TOTAL_OVERTIME
                    .Item("TOTAL_LATE_UT") = TOTAL_LATE_UT
                    .Item("TOTAL_REGHOLIDAY") = TOTAL_REGHOLIDAY
                    .Item("TOTAL_SPECHOLIDAY") = TOTAL_SPECHOLIDAY
                    .Item("GROSS_AMOUNT") = GROSS_AMOUNT
                    .Item("SSS_COMP") = SSS_COMP
                    .Item("SSS_ER") = SSS_ER
                    .Item("SSS_EC") = SSS_EC
                    .Item("PAGIBIG_COMP") = PAGIBIG_COMP
                    .Item("PHILHEALTH_COMP") = PHILHEALTH_COMP
                    .Item("TOTAL_ALLOWANCE") = TOTAL_ALLOWANCE
                    .Item("TOTAL_DEDUCTION") = TOTAL_DEDUCTION
                    .Item("TOTAL_NIGHT_RATE") = TOTAL_NIGHT_RATE
                    .Item("NET_PAY") = NET_PAY
                End With

                SaveEntry(ds, False)
            End If
        End Using
    End Sub
    '==========================================================================================

    Friend Sub EMAIL_SENT()
        For Each bio As String In IO.File.ReadAllLines("D:\Users\ItsYou\Desktop\Payslip.txt")
            Console.WriteLine(bio)
            Dim mysql As String = $"select * from payroll_payout where paydate = '10/31/2022' and BIOMETRIC_ID = '{bio}'"
            Using ds As DataSet = LoadSQL(mysql, "payroll_payout")
                If ds.Tables(0).Rows.Count > 0 Then
                    With ds.Tables(0).Rows(0)
                        .Item("EMAIL_SENT") = 1
                    End With
                    SaveEntry(ds, False)
                End If
            End Using
        Next
    End Sub

    Friend Sub UpdateEMAIL_SENT(bio As String, paydate As String)
        Dim mysql As String = $"select * from payroll_payout where paydate = '{paydate}' and BIOMETRIC_ID = '{bio}'"
        Using ds As DataSet = LoadSQL(mysql, "payroll_payout")
            If ds.Tables(0).Rows.Count > 0 Then
                With ds.Tables(0).Rows(0)
                    .Item("EMAIL_SENT") = 1
                End With
                SaveEntry(ds, False)
            End If
        End Using
    End Sub

    Friend Sub SelectFrom_InsertTo()
        Dim sql As String = "Select * from IMPORT_DTR where BIO_ID = '606'"
        Using ds As DataSet = LoadSQL(sql, "IMPORT_DTR")
            If ds.Tables(0).Rows.Count > 0 Then
                For Each dr In ds.Tables(0).Rows
                    'InsertTo_From()
                Next
            End If
        End Using
    End Sub

    Friend Sub InsertTo_From(DATE_ONLY As String, AM_IN As String, AM_OUT As String, PM_IN As String, PM_OUT As String)
        Dim mysql As String = "INSERT INTO BIOMETRIC_DTR (BIO_ID, PAYDATE, DATE_ONLY, AM_IN, AM_OUT, PM_IN, PM_OUT)"
        Using ds As DataSet = LoadSQL(mysql, "BIOMETRIC_DTR")
            If ds.Tables(0).Rows.Count > 0 Then
                With ds.Tables(0).NewRow
                    .Item("BIO_ID") = 606
                    .Item("PAYDATE") = "1/31/2023"
                    .Item("DATE_ONLY") = DATE_ONLY
                    .Item("AM_IN") = AM_IN
                    .Item("AM_OUT") = AM_OUT
                    .Item("PM_IN") = PM_IN
                    .Item("PM_OUT") = PM_OUT
                    .Item("LATE_APPROVED") = PM_OUT
                    .Item("LATE_MIN_APPROVED") = PM_OUT
                End With
                SaveEntry(ds)
            End If
        End Using
    End Sub

#Region "Cost Distribution Error"

    Dim appXL As Excel.Application
    Dim wbXl As Excel.Workbook
    Dim shXL As Excel.Worksheet
    Dim raXL As Excel.Range
    Dim row As Integer = 2

    'Friend Sub CostGetDetails()
    '    ' Start Excel and get Application object.
    '    appXL = CreateObject("Excel.Application")
    '    appXL.Visible = True

    '    ' Add a new workbook.
    '    wbXl = appXL.Workbooks.Add
    '    shXL = wbXl.ActiveSheet

    '    ' Add table headers going cell by cell.
    '    shXL.Cells(1, 1).Value = "BIOMETRIC_ID"
    '    shXL.Cells(1, 2).Value = "FULLNAME"
    '    shXL.Cells(1, 3).Value = "TOTAL_BASIC"
    '    shXL.Cells(1, 4).Value = "TOTAL_OVERTIME"
    '    shXL.Cells(1, 5).Value = "TOTAL_LATE_UT"
    '    shXL.Cells(1, 6).Value = "TOTAL_REGHOLIDAY"
    '    shXL.Cells(1, 7).Value = "TOTAL_SPECHOLIDAY"
    '    shXL.Cells(1, 8).Value = "GROSS_AMOUNT"
    '    shXL.Cells(1, 9).Value = "SSS_COMP"
    '    shXL.Cells(1, 10).Value = "SSS_ER"
    '    shXL.Cells(1, 11).Value = "SSS_EC"
    '    shXL.Cells(1, 12).Value = "PAGIBIG_COMP"
    '    shXL.Cells(1, 13).Value = "PHILHEALTH_COMP"
    '    shXL.Cells(1, 14).Value = "TOTAL_ALLOWANCE"
    '    shXL.Cells(1, 15).Value = "TOTAL_DEDUCTION"
    '    shXL.Cells(1, 16).Value = "NET_PAY"

    '    'Dim mysql As String = $"Select * from PAYROLL_PAYOUT A
    '    '                        inner join PAYROLL_EMPLOYEE B on A.BIOMETRIC_ID = B.BIO_NO  
    '    '                        where upper(HO_CATEGORY)  LIKE upper('%Dalton Admin Office%') and A.PAYDATE = '3/15/2023'"

    '    Dim mysql As String = $"Select * from PAYROLL_PAYOUT A
    '                            inner join PAYROLL_EMPLOYEE B on A.BIOMETRIC_ID = B.BIO_NO  
    '                            where A.PAYDATE = '3/15/2023' Order by HO_CATEGORY, FULLNAME"

    '    Using ds As DataSet = LoadSQL(mysql, "PAYROLL_PAYOUT")
    '        If ds.Tables(0).Rows.Count > 0 Then
    '            For Each dr In ds.Tables(0).Rows
    '                With dr

    '                    shXL.Cells(row, 1).Value = .item("BIOMETRIC_ID")
    '                    shXL.Cells(row, 2).Value = .item("FULLNAME")
    '                    shXL.Cells(row, 3).Value = .item("TOTAL_BASIC")
    '                    shXL.Cells(row, 4).Value = .item("TOTAL_OVERTIME")
    '                    shXL.Cells(row, 5).Value = .item("TOTAL_LATE_UT")
    '                    shXL.Cells(row, 6).Value = .item("TOTAL_REGHOLIDAY")
    '                    shXL.Cells(row, 7).Value = .item("TOTAL_SPECHOLIDAY")
    '                    shXL.Cells(row, 8).Value = .item("GROSS_AMOUNT")
    '                    shXL.Cells(row, 9).Value = .item("SSS_COMP")
    '                    shXL.Cells(row, 10).Value = .item("SSS_ER")
    '                    shXL.Cells(row, 11).Value = .item("SSS_EC")
    '                    shXL.Cells(row, 12).Value = .item("PAGIBIG_COMP")
    '                    shXL.Cells(row, 13).Value = .item("PHILHEALTH_COMP")
    '                    shXL.Cells(row, 14).Value = .item("TOTAL_ALLOWANCE")
    '                    shXL.Cells(row, 15).Value = .item("TOTAL_DEDUCTION")
    '                    shXL.Cells(row, 16).Value = .item("NET_PAY")
    '                    shXL.Cells(row, 17).Value = .item("HO_CATEGORY")

    '                    row += 1
    '                End With
    '            Next
    '        End If
    '    End Using

    '    GetRecordedAllowanceDeduction()
    'End Sub

    'Friend Sub GetRecordedAllowanceDeduction()
    '    row += 3

    '    shXL.Cells(row, 1).Value = "BIOMETRIC_ID"
    '    shXL.Cells(row, 2).Value = "FULLNAME"
    '    shXL.Cells(row, 3).Value = "HO_CATEGORY"
    '    shXL.Cells(row, 4).Value = "ADDITIONAL"
    '    shXL.Cells(row, 5).Value = "AMOUNT"
    '    shXL.Cells(row, 6).Value = "DEDUCTION"
    '    shXL.Cells(row, 7).Value = "AMOUNT"

    '    row += 1
    '    'Dim mysql As String = $"Select * from PAYROLL_PAYOUT A
    '    '                        inner join PAYROLL_EMPLOYEE B on A.BIOMETRIC_ID = B.BIO_NO  
    '    '                        where upper(HO_CATEGORY) like upper('%Dalton Admin Office%') and A.PAYDATE = '3/15/2023'"

    '    Dim mysql As String = $"Select * from PAYROLL_PAYOUT A
    '                            inner join PAYROLL_EMPLOYEE B on A.BIOMETRIC_ID = B.BIO_NO  
    '                            where A.PAYDATE = '3/15/2023'  Order by HO_CATEGORY, FULLNAME"

    '    Using ds As DataSet = LoadSQL(mysql, "PAYROLL_PAYOUT")
    '        If ds.Tables(0).Rows.Count > 0 Then
    '            For Each dr In ds.Tables(0).Rows
    '                With dr

    '                    shXL.Cells(row, 1).Value = .item("BIOMETRIC_ID")
    '                    shXL.Cells(row, 2).Value = .item("FULLNAME")
    '                    shXL.Cells(row, 3).Value = .item("HO_CATEGORY")
    '                    GetRecorded_Allow_Deduc(.item("BIOMETRIC_ID"))
    '                End With
    '            Next
    '        End If
    '    End Using

    '    raXL = Nothing
    '    shXL = Nothing
    '    wbXl = Nothing
    '    appXL.Quit()
    '    appXL = Nothing
    'End Sub

    Friend Sub GetRecorded_Allow_Deduc(bio As String)
        Dim mysql As String = $"Select * from RECORDED_ALLOW_DEDUC where BIO_NO={bio} and PAYDATE = '3/15/2023'"
        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_PAYOUT")
            If ds.Tables(0).Rows.Count > 0 Then
                Dim column As Integer = 4
                For Each dr In ds.Tables(0).Rows
                    With dr
                        If .item("TRANSAC_NAME") = "DEDUCTION" Then
                            column = 6
                        End If

                        shXL.Cells(row, column).Value = .item("CATEGORY")
                        shXL.Cells(row, column + 1).Value = .item("AMOUNT")

                        row += 1
                    End With
                Next
            End If
        End Using

    End Sub

#End Region

    Public Sub MergeData()
        Dim mysql As String = $"Select * from RECORDED_ALLOW_DEDUC1 where PAYDATE in ('3/31/2023','4/15/2023')"
        Using ds As DataSet = LoadSQL(mysql, "RECORDED_ALLOW_DEDUC1")
            If ds.Tables(0).Rows.Count > 0 Then
                For Each dr In ds.Tables(0).Rows
                    With dr
                        Dim BIO_NO As String = IIf(IsDBNull(.Item("BIO_NO")), "", .Item("BIO_NO"))
                        Dim TRANSAC_NAME As String = IIf(IsDBNull(.Item("TRANSAC_NAME")), "", .Item("TRANSAC_NAME"))
                        Dim AMOUNT As String = IIf(IsDBNull(.Item("AMOUNT")), "", .Item("AMOUNT"))
                        Dim CATEGORY As String = IIf(IsDBNull(.Item("CATEGORY")), "", .Item("CATEGORY"))
                        Dim PAYDATE As String = IIf(IsDBNull(.Item("PAYDATE")), "", .Item("PAYDATE"))
                        Dim R_DEDUC_ID As String = IIf(IsDBNull(.Item("R_DEDUC_ID")), "", .Item("R_DEDUC_ID"))
                        MergeData_Recorded_Allow_Deduc(BIO_NO, TRANSAC_NAME, AMOUNT, CATEGORY, PAYDATE, R_DEDUC_ID)
                    End With
                Next
            End If
        End Using
    End Sub

    Friend Sub MergeData_Recorded_Allow_Deduc(BIO_NO As String, TRANSAC_NAME As String, AMOUNT As String, CATEGORY As String, PAYDATE As String, R_DEDUC_ID As String)
        Dim mysql As String = $"Select * from RECORDED_ALLOW_DEDUC where BIO_NO = '{BIO_NO}' and TRANSAC_NAME = '{TRANSAC_NAME}' and AMOUNT = '{AMOUNT}' and CATEGORY = '{CATEGORY}' and PAYDATE = '{PAYDATE}'"
        Using ds As DataSet = LoadSQL(mysql, "RECORDED_ALLOW_DEDUC")
            If ds.Tables(0).Rows.Count > 0 Then
                MsgBox($"Exist! {PAYDATE} {BIO_NO} {TRANSAC_NAME}")
            Else
                mysql = "Select * From RECORDED_ALLOW_DEDUC Rows 1"
                Using dss As DataSet = LoadSQL(mysql, "RECORDED_ALLOW_DEDUC")
                    Dim dsNew As DataRow = dss.Tables(0).NewRow
                    With dsNew
                        .Item("BIO_NO") = BIO_NO
                        .Item("TRANSAC_NAME") = TRANSAC_NAME
                        .Item("AMOUNT") = AMOUNT
                        .Item("CATEGORY") = CATEGORY
                        .Item("PAYDATE") = PAYDATE

                        If R_DEDUC_ID <> Nothing Then .Item("R_DEDUC_ID") = R_DEDUC_ID
                    End With
                    dss.Tables(0).Rows.Add(dsNew)
                    SaveEntry(dss)
                End Using
            End If
        End Using
    End Sub

    Friend Sub GetTotalOF()
        Dim mysql As String = "Select SUM(AMOUNT) as total from RECORDED_ALLOW_DEDUC where PAYDATE='1/15/2024' and TRANSAC_NAME = 'DEDUCTION' and CATEGORY = 'Late Adjustment'"
        Using ds As DataSet = LoadSQL(mysql, "RECORDED_ALLOW_DEDUC")
            If ds.Tables(0).Rows.Count > 0 Then
                Console.WriteLine(ds.Tables(0).Rows(0).Item("total"))
            End If
        End Using
    End Sub

    'Friend Sub AddColumn_TBL_EMPLOYEE()
    '    If Not ColumnChecker("TBL_EMPLOYEE", "EMP_NO") Then
    '        RunCommand("ALTER TABLE TBL_EMPLOYEE ADD EMP_NO VARCHAR(50);")
    '    End If
    '    If Not ColumnChecker("TBL_EMPLOYEE", "COMPANY_CATEGORY") Then
    '        RunCommand("ALTER TABLE TBL_EMPLOYEE ADD COMPANY_CATEGORY VARCHAR(50);")
    '    End If
    '    If Not ColumnChecker("TBL_EMPLOYEE", "OLD_RATE") Then
    '        RunCommand("ALTER TABLE TBL_EMPLOYEE ADD OLD_RATE DECIMAL(12, 12);")
    '    End If
    '    If Not ColumnChecker("TBL_EMPLOYEE", "RATE_DAILY") Then
    '        RunCommand("ALTER TABLE TBL_EMPLOYEE ADD RATE_DAILY DECIMAL(12, 12);")
    '    End If
    '    If Not ColumnChecker("TBL_EMPLOYEE", "RATE_MONTHLY") Then
    '        RunCommand("ALTER TABLE TBL_EMPLOYEE ADD RATE_MONTHLY DECIMAL(12, 12);")
    '    End If
    '    If Not ColumnChecker("TBL_EMPLOYEE", "FIX_MONTHLY_RATE") Then
    '        RunCommand("ALTER TABLE TBL_EMPLOYEE ADD FIX_MONTHLY_RATE DECIMAL(12, 12);")
    '    End If
    '    If Not ColumnChecker("TBL_EMPLOYEE", "TIME_IN") Then
    '        RunCommand("ALTER TABLE TBL_EMPLOYEE ADD TIME_IN DECIMAL(12, 12);")
    '    End If
    '    If Not ColumnChecker("TBL_EMPLOYEE", "TIME_OUT") Then
    '        RunCommand("ALTER TABLE TBL_EMPLOYEE ADD TIME_OUT DECIMAL(12, 12);")
    '    End If
    '    If Not ColumnChecker("TBL_EMPLOYEE", "COMMON_CATEGORY") Then
    '        RunCommand("ALTER TABLE TBL_EMPLOYEE ADD COMMON_CATEGORY DECIMAL(12, 12);")
    '    End If
    '    If Not ColumnChecker("TBL_EMPLOYEE", "COMMON_COMPANY") Then
    '        RunCommand("ALTER TABLE TBL_EMPLOYEE ADD COMMON_COMPANY DECIMAL(12, 12);")
    '    End If
    '    If Not ColumnChecker("TBL_EMPLOYEE", "HO_CATEGORY") Then
    '        RunCommand("ALTER TABLE TBL_EMPLOYEE ADD HO_CATEGORY DECIMAL(12, 12);")
    '    End If

    '    'RunCommand("UPDATE TBL_EMPLOYEE
    '    '            SET TBL_EMPLOYEE.column1 = PAYROLL_EMPLOYEE.column1,
    '    '                TBL_EMPLOYEE.column2 = PAYROLL_EMPLOYEE.column2, 
    '    '            FROM TBL_EMPLOYEE
    '    '            JOIN PAYROLL_EMPLOYEE ON TBL_EMPLOYEE.employee_id = PAYROLL_EMPLOYEE.employee_id 
    '    '            WHERE TBL_EMPLOYEE.BIOMETRICID = PAYROLL_EMPLOYEE.BIO_NO;")
    'End Sub

    Friend Sub GetPositions()
        ''FROM PAYROLL_EMPLOYEE TO TEXTFILE
        'Dim mysql As String = "Select DISTINCT  EMP_POSITION from PAYROLL_EMPLOYEE"
        'Using ds As DataSet = LoadSQL(mysql, "PAYROLL_EMPLOYEE")
        '    If ds.Tables(0).Rows.Count > 0 Then
        '        Dim path As String = "C:\Users\MISPC1\Desktop\Employee's Position.txt"
        '        Dim filee As New FileInfo(path)

        '        If Not filee.Exists Then
        '            filee.Create().Close()
        '        End If

        '        For Each dr In ds.Tables(0).Rows
        '            With dr
        '                Dim writer As New StreamWriter(path, FileMode.Append)
        '                writer.WriteLine(.item("EMP_POSITION"))
        '                writer.Close()
        '            End With
        '        Next
        '    End If
        'End Using 

        'FROM TEXTFILE TO CATEGORIES
        Dim path As String = "C:\Users\MISPC1\Desktop\Employee's Position.txt"
        For Each line As String In IO.File.ReadAllLines(path)
            If Not IsEntryExist("CATEGORIES", "CATEGORY", line) Then
                SavePositionsToCategories(line)
            End If
        Next
    End Sub

    Friend Sub SavePositionsToCategories(line As String)
        Dim mysql As String = "Select * from CATEGORIES ROWS 1"
        Using ds As DataSet = LoadSQL(mysql, "CATEGORIES")
            Dim dsNew As DataRow = ds.Tables(0).NewRow
            With dsNew
                .Item("CATEGORY") = line
                .Item("NAME") = "POSITION"
            End With
            ds.Tables(0).Rows.Add(dsNew)
            SaveEntry(ds)
        End Using
    End Sub

    Friend Sub GetBranchCodeInTBL_EMPLOYEE()
        ''FROM TBL_EMPLOYEE BRANCH_ID TO TEXTFILE 
        'Dim mysql As String = "Select A.ID as empID, BRANCH_ID, B.BRANCHCODE as tblcode, C.BRANCHCODE as citycode from TBL_EMPLOYEE A inner join TBL_BRANCH B on B.ID=A.BRANCH_ID left join PAYROLL_CITY_BRANCH C on C.BRANCHCODE=B.BRANCHCODE"
        'Using ds As DataSet = LoadSQL(mysql, "TBL_EMPLOYEE")
        '    If ds.Tables(0).Rows.Count > 0 Then
        '        Dim path As String = "C:\Users\MISPC1\Desktop\Employee's BranchID.txt"
        '        Dim filee As New FileInfo(path)

        '        If Not filee.Exists Then
        '            filee.Create().Close()
        '        End If

        '        For Each dr In ds.Tables(0).Rows
        '            With dr
        '                Dim writer As New StreamWriter(path, FileMode.Append)
        '                writer.WriteLine(.item("empID") & vbTab & .item("BRANCH_ID") & vbTab & .item("tblcode") & vbTab & .item("citycode"))
        '                writer.Close()
        '            End With
        '        Next
        '    End If
        'End Using

        'FROM TEXTFILE TO TBL_EMPLOYEE
        Dim path As String = "C:\Users\MISPC1\Desktop\Employee's BranchID.txt"
        For Each line As String In IO.File.ReadAllLines(path)
            Dim slices As String() = line.Split(vbTab)
            Dim empID As Integer = slices(0)
            Dim brachCode As String = slices(3)
            UpdateBranchCodeEmployee(empID, brachCode)
            Console.WriteLine($"EmpID-{empID}  BranchCode-{brachCode}")
        Next
    End Sub

    Friend Sub UpdateBranchCodeEmployee(empId As Integer, brachCode As String)
        Dim mysql As String = $"Select * from TBL_EMPLOYEE where ID = {empId}"
        Using ds As DataSet = LoadSQL(mysql, "TBL_EMPLOYEE")
            If ds.Tables(0).Rows.Count > 0 Then
                With ds.Tables(0).Rows(0)
                    .Item("BRANCHCODE") = brachCode
                End With
                SaveEntry(ds, False)
            End If
        End Using
    End Sub

    Friend Function IsEntryExist(table As String, ColName As String, entry As String) As Boolean
        Dim mysql = $"SELECT * FROM {table} WHERE {ColName} = '{entry}'"
        Dim ds = LoadSQL(mysql)
        Dim st As Boolean
        If ds.Tables(0).Rows.Count <= 0 Then
            st = False
        Else
            st = True
        End If
        Return st
    End Function

    'Private Sub GetNotEqual_BIONO()
    '    Dim mysql As String = "Select * from PAYROLL_EMPLOYEE B inner join TBL_EMPLOYEE A on B.BIO_NO = A.BIOMETRICID"
    '    Using ds As DataSet = LoadSQL(mysql, "PAYROLL_EMPLOYEE")
    '        If ds.Tables(0).Rows.Count > 0 Then
    '            Dim path As String = "C:\Users\MISPC1\Desktop\Employees Equal BIONO.txt"
    '            Dim filee As New FileInfo(path)

    '            If Not filee.Exists Then
    '                filee.Create().Close()
    '            End If

    '            For Each dr In ds.Tables(0).Rows
    '                With dr
    '                    Dim writer As New StreamWriter(path)
    '                    writer.WriteLine(.item("FULLNAME"))
    '                    writer.Close()
    '                End With
    '            Next
    '        End If
    '    End Using
    'End Sub

    Friend Sub ExportDataToExcel()
        ' Set the license context to properly use EPPlus in a commercial context
        ExcelPackage.LicenseContext = LicenseContext.Commercial

        ' Your existing code here
        'Dim mysql As String = "Select * from TBL_EMPLOYEE"

        ''DuplicateBioNoEmployees
        'Dim mysql As String = "SELECT 
        '                            TBL_EMPLOYEE.*,                     
        '                            LASTNAME || ', ' || FIRSTNAME || ' ' || 
        '                            CASE 
        '                                WHEN MIDDLENAME IS NOT NULL AND MIDDLENAME <> '' THEN LEFT(MIDDLENAME, 1) || '.'  
        '                                ELSE '' 
        '                            END AS FULLNAME
        '                        FROM 
        '                            TBL_EMPLOYEE  
        '                        INNER JOIN (
        '                            SELECT 
        '                                BIOMETRICID
        '                            FROM 
        '                                TBL_EMPLOYEE
        '                            GROUP BY 
        '                                BIOMETRICID
        '                            HAVING 
        '                                COUNT(*) > 1
        '                        ) AS Duplicates ON TBL_EMPLOYEE.BIOMETRICID = Duplicates.BIOMETRICID
        '                        ORDER BY 
        '                            BIOMETRICID ASC;

        ''Incomplete Employee Record
        'Dim mysql As String = "Select BIOMETRICID, COMPANY, RATE_DAILY, RATE_MONTHLY, BRANCHCODE, 
        '                        LASTNAME || ', ' || FIRSTNAME || ' ' || CASE WHEN MIDDLENAME IS NOT NULL AND MIDDLENAME <> '' THEN LEFT(MIDDLENAME, 1) ELSE '' END AS FULLNAME 
        '                        From TBL_EMPLOYEE   
        '                        WHERE COMPANY IS NULL OR RATE_DAILY IS NULL OR BRANCHCODE IS NULL 
        '                        ORDER BY FULLNAME" 

        'Incomplete Employee Record - ATTENDANCE ACTIVE ONLY
        Dim mysql As String = "Select BIOMETRICID, COMPANY, RATE_DAILY, RATE_MONTHLY, BRANCHCODE, 
                                LASTNAME || ', ' || FIRSTNAME || ' ' || CASE WHEN MIDDLENAME IS NOT NULL AND MIDDLENAME <> '' THEN LEFT(MIDDLENAME, 1) ELSE '' END AS FULLNAME 
                                From TBL_EMPLOYEE   
                                WHERE (COMPANY IS NULL OR RATE_DAILY IS NULL OR BRANCHCODE IS NULL) AND EMP_STATUS <> 'INACTIVE' AND COMPANY <> 'HEAD OFFICE' 
                                ORDER BY FULLNAME"

        Using ds As DataSet = LoadSQL(mysql, "TBL_EMPLOYEE")
            If ds.Tables(0).Rows.Count > 0 Then
                Dim path As String = "C:\Users\MISPC1\Desktop\Database to Excel\Incomplete Employees Record.xlsx"

                ' Create a new Excel package
                Using package As New ExcelPackage(New FileInfo(path))
                    Dim worksheet As ExcelWorksheet = package.Workbook.Worksheets.Add("BRANCHES ONLY")

                    ' Write column names to the first row
                    For colIndex As Integer = 1 To ds.Tables(0).Columns.Count
                        worksheet.Cells(1, colIndex).Value = ds.Tables(0).Columns(colIndex - 1).ColumnName
                    Next

                    ' Write data to the worksheet
                    For rowIndex As Integer = 0 To ds.Tables(0).Rows.Count - 1
                        For colIndex As Integer = 1 To ds.Tables(0).Columns.Count
                            worksheet.Cells(rowIndex + 2, colIndex).Value = ds.Tables(0).Rows(rowIndex)(colIndex - 1)
                        Next
                    Next

                    ' Save the Excel package
                    package.Save()
                End Using
            End If
        End Using
    End Sub

    Friend Sub Update_HREmployee_From_PayrollEmployee()

        Dim mysql As String = "Select * from PAYROLL_EMPLOYEE"
        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_EMPLOYEE")
            For Each dr In ds.Tables(0).Rows
                With dr
                    Dim bio_no As String = .item("BIO_NO")
                    'Dim EMP_NO As String = IIf(IsDBNull(.Item("EMP_NO")), "", .Item("EMP_NO"))
                    'Dim COMPANY As String = IIf(IsDBNull(.Item("COMPANY")), "", .Item("COMPANY"))
                    'Dim BRANCH_CODE As String = IIf(IsDBNull(.Item("BRANCH_CODE")), "", .Item("BRANCH_CODE"))
                    'Dim HO_CATEGORY As String = IIf(IsDBNull(.Item("HO_CATEGORY")), "", .Item("HO_CATEGORY"))
                    'Dim PHOTO_CATEGORY As String = IIf(IsDBNull(.Item("COMPANY_CATEGORY")), "", .Item("COMPANY_CATEGORY"))
                    'Dim COMMON_CATEGORY As String = IIf(IsDBNull(.Item("COMMON_CATEGORY")), "", .Item("COMMON_CATEGORY"))
                    'Dim COMMON_COMPANY As String = IIf(IsDBNull(.Item("COMMON_COMPANY")), "", .Item("COMMON_COMPANY"))
                    'Dim OLD_RATE As String = IIf(IsDBNull(.Item("OLD_RATE")), "", .Item("OLD_RATE"))
                    'Dim RATE_DAILY As String = IIf(IsDBNull(.Item("RATE_DAILY")), "", .Item("RATE_DAILY"))
                    'Dim RATE_MONTHLY As String = IIf(IsDBNull(.Item("RATE_MONTHLY")), "", .Item("RATE_MONTHLY"))
                    'Dim FIX_MONTHLY_RATE As String = IIf(IsDBNull(.Item("FIX_MONTHLY_RATE")), "", .Item("FIX_MONTHLY_RATE"))
                    'Dim TIME_IN As String = IIf(IsDBNull(.Item("TIME_IN")), "", .Item("TIME_IN"))
                    'Dim TIME_OUT As String = IIf(IsDBNull(.Item("TIME_OUT")), "", .Item("TIME_OUT"))
                    'Dim EMAIL_ADD As String = IIf(IsDBNull(.Item("EMAIL_ADD")), "", .Item("EMAIL_ADD"))
                    'Dim EMP_STATUS As String = IIf(IsDBNull(.Item("EMP_STATUS")), "", .Item("EMP_STATUS"))
                    'Dim EMP_POSITION As String = IIf(IsDBNull(.Item("EMP_POSITION")), "", .Item("EMP_POSITION"))
                    'Dim SSSNO As String = IIf(IsDBNull(.Item("SSSNO")), "", .Item("SSSNO"))
                    'Dim PHILHEALTHNO As String = IIf(IsDBNull(.Item("PHILHEALTHNO")), "", .Item("PHILHEALTHNO"))
                    'Dim TINNO As String = IIf(IsDBNull(.Item("TINNO")), "", .Item("TINNO"))
                    'Dim PAGIBIG As String = IIf(IsDBNull(.Item("PAGIBIGNO")), "", .Item("PAGIBIGNO")) 
                    'Dim DATEHIRED As String = IIf(IsDBNull(.Item("DATE_STARTED")), "", .Item("DATE_STARTED"))
                    'Dim DATE_ENDED As String = IIf(IsDBNull(.Item("DATE_ENDED")), "", .Item("DATE_ENDED"))

                    Dim COMPANY As String = IIf(IsDBNull(.Item("COMPANY")), "", .Item("COMPANY"))

                    'UpdateeEMPLOYEE(bio_no, DATEHIRED, DATE_ENDED)
                    UpdateeEMPLOYEE(bio_no, COMPANY)
                End With
            Next
        End Using
    End Sub

    'Friend Sub UpdateeEMPLOYEE(BIO As Integer, EMP_NO As String, COMPANY As String, BRANCH_CODE As String,
    '                           HO_CATEGORY As String, PHOTO_CATEGORY As String, COMMON_CATEGORY As String, COMMON_COMPANY As String,
    '                           OLD_RATE As String, RATE_DAILY As String, RATE_MONTHLY As String, FIX_MONTHLY_RATE As String,
    '                           TIME_IN As String, TIME_OUT As String, EMAIL_ADD As String, EMP_STATUS As String,
    '                           EMP_POSITION As String, SSSNO As String, PHILHEALTHNO As String, TINNO As String, PAGIBIG As String)


    'Friend Sub UpdateeEMPLOYEE(BIO As Integer, DATEHIRED As String, DATE_ENDED As String)
    Friend Sub UpdateeEMPLOYEE(BIO As Integer, COMPANY As String)

        Dim mysql As String = $"Select * from TBL_EMPLOYEE where BIOMETRICID = {BIO}"
        Using ds As DataSet = LoadSQL(mysql, "TBL_EMPLOYEE")
            If ds.Tables(0).Rows.Count > 0 Then
                With ds.Tables(0).Rows(0)

                    'If EMP_NO <> "" Then .Item("EMP_NO") = EMP_NO
                    'If COMPANY <> "" Then .Item("COMPANY_CATEGORY") = COMPANY
                    'If BRANCH_CODE <> "" Then .Item("BRANCHCODE") = BRANCH_CODE
                    'If HO_CATEGORY <> "" Then .Item("HO_CATEGORY") = HO_CATEGORY
                    'If COMMON_CATEGORY <> "" Then .Item("COMMON_CATEGORY") = COMMON_CATEGORY
                    'If COMMON_COMPANY <> "" Then .Item("COMMON_COMPANY") = COMMON_COMPANY
                    'If OLD_RATE <> "" Then .Item("OLD_RATE") = OLD_RATE
                    'If RATE_DAILY <> "" Then .Item("RATE_DAILY") = RATE_DAILY
                    'If RATE_MONTHLY <> "" Then .Item("RATE_MONTHLY") = RATE_MONTHLY
                    'If fix_monthly_rate <> "" Then .Item("FIX_MONTHLY_RATE") = fix_monthly_rate
                    'If TIME_IN <> "" Then .Item("TIME_IN") = TIME_IN
                    'If TIME_OUT <> "" Then .Item("TIME_OUT") = TIME_OUT
                    'If EMAIL_ADD <> "" Then .Item("EMAILADD") = EMAIL_ADD
                    'If emp_status <> "" Then .Item("EMP_STATUS") = emp_status
                    'If EMP_POSITION <> "" Then .Item("EMP_POSITION") = EMP_POSITION
                    'If SSSNO <> "" Then .Item("SSSNO") = SSSNO
                    'If PHILHEALTHNO <> "" Then .Item("PHILHEALTHNO") = PHILHEALTHNO
                    'If TINNO <> "" Then .Item("TINNO") = TINNO
                    'If PAGIBIG <> "" Then .Item("PAGIBIG") = PAGIBIG

                    'If IsDBNull(.Item("PHOTO_CATEGORY")) Then
                    '    If PHOTO_CATEGORY <> "" Then .Item("PHOTO_CATEGORY") = PHOTO_CATEGORY
                    'End If 

                    'If DATEHIRED <> "" Then .Item("DATEHIRED") = DATEHIRED
                    'If DATE_ENDED <> "" Then .Item("DATE_ENDED") = DATE_ENDED 

                    If IsDBNull(.Item("COMPANY")) Then
                        If COMPANY <> "" Then .Item("COMPANY") = COMPANY
                    ElseIf String.IsNullOrEmpty(.Item("COMPANY")) Then
                        If COMPANY <> "" Then .Item("COMPANY") = COMPANY
                    End If

                End With
                SaveEntry(ds, False)
            End If
        End Using
    End Sub

    'Friend Sub Import_Employee_BRANCH_DTR()
    '    Dim path As String = "C:\Users\MISPC1\Desktop\Branch Import Formated.xlsx"
    '    eApp = New Excel.Application
    '    eBook = eApp.Workbooks.Open(path)
    '    eSheet = eBook.Worksheets(1)
    '    eCell = eSheet.UsedRange

    '    MyConnection = New System.Data.OleDb.OleDbConnection($"provider=Microsoft.Jet.OLEDB.4.0;Data Source='{Path}';Extended Properties=Excel 8.0;")
    '    MyCommand = New System.Data.OleDb.OleDbDataAdapter($"select * from [{eSheet.Name}$]", MyConnection)
    '    MyCommand.TableMappings.Add("Table", "Net-informations.com")
    '    DtSet = New System.Data.DataSet
    '    MyCommand.Fill(DtSet)

    '    progressBarStart(DtSet.Tables(0).Rows.Count + 1)

    '    Dim EMP_NO As String = Nothing

    '    For row = 2 To DtSet.Tables(0).Rows.Count

    '        If eCell(row, 1).Font.Bold = True Then
    '            EMP_NO = eCell(row, 4).Value
    '        End If

    '        If EMP_NO <> Nothing And IsDate(eCell(row, 1).value) Then
    '            Dim datee As DateTime = eCell(row, 1).Value
    '            UPDATE_Emp_SBU_EXCEL_DATEONLY(EMP_NO, datee, row)

    '            EMP_NO = Nothing
    '        End If

    '        frmMainForm.AppProgressBar.Value += 1
    '    Next row

    '    progressBarEnd()

    '    MyConnection.Close()
    '    eApp.Quit()
    '    eApp.Application.DisplayAlerts = False

    'End Sub

    Friend Sub SaveToText(bio As String, fullname As String, blank As String)
        Dim desktopPath As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        Dim path As String = $"{desktopPath}\PAYROLL BRANCH - EMPTY RECORD.txt"
        Dim filee As New FileInfo(path)

        If Not filee.Exists Then
            filee.Create().Close()
        End If

        Dim writer As New StreamWriter(path, FileMode.Append)
        writer.WriteLine(bio & vbTab & fullname & vbTab & blank)
        writer.Close()
    End Sub

    Friend Sub Import_Employee_BRANCH_DEDUCTION()
        Dim path As String = "C:\Users\MISPC1\Desktop\BRANCH PAYROLL\FINAL DEDUCTION BRANCHES.xlsx"
        eApp = New Excel.Application
        eBook = eApp.Workbooks.Open(path)
        eSheet = eBook.Worksheets(1)
        eCell = eSheet.UsedRange

        MyConnection = New System.Data.OleDb.OleDbConnection($"provider=Microsoft.Jet.OLEDB.4.0;Data Source='{path}';Extended Properties=Excel 8.0;")
        MyCommand = New System.Data.OleDb.OleDbDataAdapter($"select * from [{eSheet.Name}$]", MyConnection)
        MyCommand.TableMappings.Add("Table", "Net-informations.com")
        DtSet = New System.Data.DataSet
        MyCommand.Fill(DtSet)

        progressBarStart(DtSet.Tables(0).Rows.Count + 1)

        Dim EMP_NO As String = Nothing
        Dim TEMP_BIO As Integer = 0

        For row = 2 To DtSet.Tables(0).Rows.Count
            Dim bioNo As Integer = eCell(row, 2).Value
            Dim fullname As String = eCell(row, 3).Value
            Dim deducName As String = eCell(row, 4).Value
            Dim principal As Decimal = eCell(row, 5).Value
            Dim amort As Decimal = eCell(row, 6).Value
            Dim sched As String = "EVERY PAYROLL"

            If eCell(row, 7).Value = "15" Then
                sched = "OPEN PAYROLL"
            ElseIf eCell(row, 7).Value = "30" Then
                sched = "CLOSE PAYROLL"
            End If

            SaveDeductionS(0, deducName, principal, amort, sched, Today, bioNo)
            SaveLogs($"DEDUCTION ADDED FOR BRANCHES - {fullname} ({bioNo}), Category({deducName}), Total({principal}), Schedule({sched}), Date({Today.ToString("MMM dd, yyyy")})", frmMainForm.UserName_LBL.Text)

            frmMainForm.AppProgressBar.Value += 1
        Next row

        progressBarEnd()

        MyConnection.Close()
        eApp.Quit()
        eApp.Application.DisplayAlerts = False

    End Sub

    Friend Function HeadOffice_Employee(EMP_NO As String)
        Dim mysql As String = $"SELECT COMPANY FROM TBL_EMPLOYEE WHERE EMP_NO = '{EMP_NO}' AND COMPANY = 'HEAD OFFICE'"
        Using ds As DataSet = LoadSQL(mysql, "TBL_EMPLOYEE")
            If ds.Tables(0).Rows.Count > 0 Then
                Return True
            End If
        End Using
        Return False
    End Function

    Public Sub SAVE_SBU_INCOMPLETE(CATEGORY As String, AMOUNT As String, PRINCIPAL As String, CREDIT As String, BALANCE As String, BIONO As Integer)

        '====================== DELETE EXISTING DATA PAYROLL_SBU ==================
        RunCommand($"DELETE FROM PAYROLL_SBU WHERE BIO_NO = {BIONO}")

        Dim sql As String = "Select * From PAYROLL_SBU Rows 1"
        Using ds As DataSet = LoadSQL(sql, "PAYROLL_SBU")

            Dim dsNewRow As DataRow = ds.Tables(0).NewRow
            With dsNewRow

                .Item("BIO_NO") = BIONO
                .Item("DATE_ADDED") = Today
                .Item("PRINCIPAL") = PRINCIPAL
                .Item("CREDIT") = CREDIT
                .Item("BALANCE") = BALANCE
                .Item("CATEGORY") = CATEGORY
                .Item("AMOUNT") = AMOUNT
                .Item("SCHED") = "EVERY PAYROLL"

            End With

            ds.Tables(0).Rows.Add(dsNewRow)
            SaveEntry(ds)

        End Using
    End Sub

    Public Sub SAVE_EMPLOYEE_DETAILS_INCOMPLETE(BIONO As Integer, COMPANY As String, BRANCHCODE As String, RATE_DAILY As Decimal, RATE_MONTHLY As Decimal, PHOTO_CATEGORY As String)
        Dim sql As String = $"Select * From TBL_EMPLOYEE WHERE BIOMETRICID = {BIONO}"
        Using ds As DataSet = LoadSQL(sql, "TBL_EMPLOYEE")
            If ds.Tables(0).Rows.Count > 0 Then
                With ds.Tables(0).Rows(0)
                    .Item("COMPANY") = COMPANY
                    .Item("PHOTO_CATEGORY") = COMPANY
                    .Item("BRANCHCODE") = BRANCHCODE
                    .Item("RATE_DAILY") = RATE_DAILY
                    .Item("RATE_MONTHLY") = RATE_MONTHLY
                    If PHOTO_CATEGORY <> Nothing Then .Item("PHOTO_CATEGORY") = PHOTO_CATEGORY
                End With
                SaveEntry(ds, False)
            End If

        End Using
    End Sub

    Friend Sub TestingScript_String(mysql As String)
        Dim trimmedString As String = mysql.Trim()
        Dim regexPattern As String = "\s+"
        Dim resultString As String = System.Text.RegularExpressions.Regex.Replace(trimmedString, regexPattern, " ")
        Console.WriteLine(resultString)
    End Sub

    Friend Sub Branch13MonthFromRemantic()
        Dim path() As String = {"C:\Users\MISPC1\Desktop\Branch Import Format - 13TH MONTH PAY.xlsx", "C:\Users\MISPC1\Desktop\P&G, PCOM, PHOTO 13TH.xlsx"}

        For i = 0 To path.Length - 1

            eApp = New Excel.Application
            eBook = eApp.Workbooks.Open(path(i))
            eSheet = eBook.Worksheets(1)
            eCell = eSheet.UsedRange

            MyConnection = New System.Data.OleDb.OleDbConnection($"provider=Microsoft.Jet.OLEDB.4.0;Data Source='{path(i)}';Extended Properties=Excel 8.0;")
            MyCommand = New System.Data.OleDb.OleDbDataAdapter($"select * from [{eSheet.Name}$]", MyConnection)
            MyCommand.TableMappings.Add("Table", "Net-informations.com")
            DtSet = New System.Data.DataSet
            MyCommand.Fill(DtSet)

            progressBarStart(DtSet.Tables(0).Rows.Count + 1)

            For row = 2 To DtSet.Tables(0).Rows.Count + 1
                Dim bioNo As Integer = eCell(row, 1).Value
                Dim fullname As String = eCell(row, 2).Value
                Dim amount As Decimal = eCell(row, 3).Value
                Dim paydate As String = "5/15/2024"

                If bioNo <> 0 Or bioNo <> Nothing Then
                    Save13MonthFromRemantic(bioNo, amount, paydate)
                    SaveLogs($"13MONTH ADDED FROM REMANTIC (DEC-FEB) - {fullname} ({bioNo}), AMOUNT({amount}), PAYDATE({paydate})", frmMainForm.UserName_LBL.Text)
                End If

                Console.WriteLine($"Row {row}")
                frmMainForm.AppProgressBar.Value += 1
            Next row

            progressBarEnd()

            MyConnection.Close()
            eApp.Quit()
            eApp.Application.DisplayAlerts = False
        Next

        MsgBox("Importing Done!")
    End Sub


    Friend Sub Save13MonthFromRemantic(bioNo As Integer, amount As Decimal, paydate As String)
        Dim mysql As String = $"Select * FROM PAYROLL_13MONTH where BIO_NO = '{bioNo}' and PAYDATE = '{paydate}'"
        Dim ds As DataSet = LoadSQL(mysql, "PAYROLL_13MONTH")
        If ds.Tables(0).Rows.Count > 0 Then

            With ds.Tables(0).Rows(0)

                .Item("BIO_NO") = bioNo
                .Item("AMOUNT") = amount
                .Item("PAYDATE") = paydate

            End With
            SaveEntry(ds, False)
        Else

            mysql = "Select * From PAYROLL_13MONTH Rows 1"
            Using dss As DataSet = LoadSQL(mysql, "PAYROLL_13MONTH")

                Dim dsNewRow As DataRow = dss.Tables(0).NewRow
                With dsNewRow

                    .Item("BIO_NO") = bioNo
                    .Item("AMOUNT") = amount
                    .Item("PAYDATE") = paydate

                End With
                dss.Tables(0).Rows.Add(dsNewRow)
                SaveEntry(dss)
            End Using
        End If
    End Sub

    Friend Sub SSS_ER_EC()
        Dim mysql As String = $"SELECT * FROM PAYROLL_PAYOUT WHERE PAYDATE IN ('4/30/2024','5/31/2024')"
        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_PAYOUT")
            If ds.Tables(0).Rows.Count > 0 Then
                For Each dr In ds.Tables(0).Rows
                    With dr
                        Dim bioNo As Integer = .item("BIOMETRIC_ID")
                        Dim paydate As Date = .item("PAYDATE")
                        Dim sss_ee As Decimal = .item("SSS_COMP")
                        Dim sss_er As Decimal = .item("SSS_ER")
                        Dim secondBasic As Decimal = .item("TOTAL_BASIC")

                        Console.WriteLine(bioNo)
                        Console.WriteLine(paydate.ToShortDateString)
                        Console.WriteLine(sss_ee)
                        Console.WriteLine(sss_er)

                        If sss_ee <> 0 And sss_er = 0 Then
                            Dim first_Basic As Decimal = GetFirst_Basic(bioNo, paydate)
                            Dim monthly_Basic As Decimal = secondBasic + first_Basic

                            If ThisNotIsNull("SSSNO", $"TBL_EMPLOYEE where BIOMETRICID = {bioNo} ") Then 'IF HAS SSSNO DETAILS 
                                Get_SSS(monthly_Basic)
                                UpdateSSS_ER_EC(bioNo, paydate.ToShortDateString, SSSER, SSSEC)
                            End If

                        End If
                    End With
                Next
                Console.WriteLine("Finished!")
            End If
        End Using
    End Sub

    Friend Sub UpdateSSS_ER_EC(bioNo As Integer, paydate As String, SSS_ER As Decimal, SSS_EC As Decimal)
        Dim mysql As String = $"SELECT * FROM PAYROLL_PAYOUT WHERE BIOMETRIC_ID = {bioNo} AND PAYDATE = '{paydate}'"
        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_PAYOUT")
            If ds.Tables(0).Rows.Count > 0 Then
                With ds.Tables(0).Rows(0)
                    .Item("SSS_ER") = SSS_ER
                    .Item("SSS_EC") = SSS_EC
                End With
                SaveEntry(ds, False)
            End If
        End Using
    End Sub

    Friend Sub UpdateEmpStatus() '=========== BOOLEAN IF MORE THAN 1 ========== 
        Dim mysql As String = $"Select * FROM TBL_EMPLOYEE"
        Dim ds As DataSet = LoadSQL(mysql, "TBL_EMPLOYEE")
        If ds.Tables(0).Rows.Count > 0 Then
            For Each dr In ds.Tables(0).Rows
                With dr

                    Dim bioNo As String = .Item("BIOMETRICID")
                    Dim empid As String = .Item("ID")
                    Dim status As String = IIf(IsDBNull(.Item("STATUS")), Nothing, .Item("STATUS"))
                    Dim empstatus As String = IIf(IsDBNull(.Item("EMP_STATUS")), Nothing, .Item("EMP_STATUS"))
                    Dim dateEnded As String = GetDateEnded(empid)

                    If status <> Nothing Then
                        If empstatus <> "INACTIVE" And (status = "AWOL" Or status = "AWOL/BREACH OF CONTRACT" Or status = "END OF PROBATIONARY" Or status = "RESIGNED" Or status = "TERMINATED") Then
                            .Item("EMP_STATUS") = "INACTIVE"
                            If dateEnded <> Nothing Then .Item("DATE_ENDED") = dateEnded

                            Console.WriteLine($"INACTIVE = {bioNo}")
                        ElseIf empstatus <> "ACTIVE" And (status = "APPOINTED" Or status = "PROBATIONARY" Or status = "REGULAR" Or status = "SUSPENDED") Then
                            .Item("EMP_STATUS") = "ACTIVE"
                            .Item("DATE_ENDED") = DBNull.Value
                            Console.WriteLine($"ACTIVE = {bioNo}")
                        Else
                            Continue For
                        End If
                    Else
                        Continue For
                    End If
                End With
                SaveEntry(ds, False)
            Next
        End If
    End Sub

    Friend Function GetDateEnded(EmpID As Integer)
        Dim mysql As String = $"Select * FROM TBL_LASTDATE WHERE EMP_ID = {EmpID}"
        Dim ds As DataSet = LoadSQL(mysql, "TBL_LASTDATE")
        If ds.Tables(0).Rows.Count > 0 Then
            With ds.Tables(0).Rows(0)
                Return .Item("LASTDATE")
            End With
        End If
        Return Nothing
    End Function

    Friend Sub EmployeeStatus()
        Dim path() As String = {"C:\Users\MISPC1\Desktop\List of Employess (6-10-2024).xlsx"}

        For i = 0 To path.Length - 1

            eApp = New Excel.Application
            eBook = eApp.Workbooks.Open(path(i))
            eSheet = eBook.Worksheets(1)
            eCell = eSheet.UsedRange

            MyConnection = New System.Data.OleDb.OleDbConnection($"provider=Microsoft.Jet.OLEDB.4.0;Data Source='{path(i)}';Extended Properties=Excel 8.0;")
            MyCommand = New System.Data.OleDb.OleDbDataAdapter($"select * from [{eSheet.Name}$]", MyConnection)
            MyCommand.TableMappings.Add("Table", "Net-informations.com")
            DtSet = New System.Data.DataSet
            MyCommand.Fill(DtSet)

            progressBarStart(DtSet.Tables(0).Rows.Count + 1)

            For row = 2 To DtSet.Tables(0).Rows.Count + 1
                Dim fullname As String = eCell(row, 1).Value
                Dim bioNo As Integer = eCell(row, 2).Value
                Dim emp_status As String = eCell(row, 5).Value
                Dim status As String = eCell(row, 6).Value
                Dim email As String = eCell(row, 7).Value
                Dim sss As String = eCell(row, 8).Value
                Dim philhealth As String = eCell(row, 9).Value
                Dim tin As String = eCell(row, 10).Value
                Dim pagibig As String = eCell(row, 11).Value

                If bioNo <> 0 Or bioNo <> Nothing Then
                    SaveEmployeeStatus(bioNo, emp_status, status, email, sss, philhealth, tin, pagibig)
                    SaveLogs($"UPDATE EMPLOYEE INFO FROM EXCEL - {fullname} ({bioNo}), EMP_STATUS({emp_status}), STATUS({status}), EMAILADD({email}), SSSNO({sss}), PHILHEALTHNO({philhealth}), TINNO({tin}), PAGIBIG({pagibig})", frmMainForm.UserName_LBL.Text)
                End If

                Console.WriteLine($"Row {row}")
                frmMainForm.AppProgressBar.Value += 1
            Next row

            progressBarEnd()

            MyConnection.Close()
            eApp.Quit()
            eApp.Application.DisplayAlerts = False
        Next

        MsgBox("Importing Done!")
    End Sub

    Friend Sub SaveEmployeeStatus(bioNo As Integer, EMP_STATUS As String, STATUS As String, EMAILADD As String, SSSNO As String, PHILHEALTHNO As String, TINNO As String, PAGIBIG As String)
        Dim mysql As String = $"Select * FROM TBL_EMPLOYEE where BIOMETRICID = '{bioNo}'"
        Dim ds As DataSet = LoadSQL(mysql, "TBL_EMPLOYEE")
        If ds.Tables(0).Rows.Count > 0 Then

            With ds.Tables(0).Rows(0)

                If bioNo = 4185 Or bioNo = 4870 Then
                    Console.WriteLine("")
                End If

                .Item("EMP_STATUS") = EMP_STATUS
                If STATUS <> Nothing Then .Item("STATUS") = STATUS
                If EMAILADD <> Nothing Then .Item("EMAILADD") = EMAILADD
                If SSSNO <> Nothing Then .Item("SSSNO") = SSSNO
                If PHILHEALTHNO <> Nothing Then .Item("PHILHEALTHNO") = PHILHEALTHNO
                If TINNO <> Nothing Then .Item("TINNO") = TINNO
                If PAGIBIG <> Nothing Then .Item("PAGIBIG") = PAGIBIG

            End With
            SaveEntry(ds, False)
        End If
    End Sub

    Friend Sub EmployeeBankAccount()
        'Dim path() As String = {"C:\Users\MISPC1\Desktop\BIO # WITH  ACCT # DALTON ATM.xlsx"}
        Dim path() As String = {"C:\Users\MISPC1\Desktop\BIO # WITH ACCT # PHOTO ATM.xlsx"}

        For i = 0 To path.Length - 1

            eApp = New Excel.Application
            eBook = eApp.Workbooks.Open(path(i))
            eSheet = eBook.Worksheets(1)
            eCell = eSheet.UsedRange

            MyConnection = New System.Data.OleDb.OleDbConnection($"provider=Microsoft.Jet.OLEDB.4.0;Data Source='{path(i)}';Extended Properties=Excel 8.0;")
            MyCommand = New System.Data.OleDb.OleDbDataAdapter($"select * from [{eSheet.Name}$]", MyConnection)
            MyCommand.TableMappings.Add("Table", "Net-informations.com")
            DtSet = New System.Data.DataSet
            MyCommand.Fill(DtSet)

            progressBarStart(DtSet.Tables(0).Rows.Count + 1)

            For row = 3 To DtSet.Tables(0).Rows.Count + 1
                Dim bioNo As Integer = eCell(row, 1).Value
                Dim accountNo As String = eCell(row, 2).Value
                Dim fullname As String = eCell(row, 4).Value

                If bioNo <> 0 Or bioNo <> Nothing Then
                    RunCommand($"UPDATE TBL_EMPLOYEE SET ACCOUNTNO = '{accountNo}' WHERE BIOMETRICID = '{bioNo}'")
                    SaveLogs($"UPDATE ACCOUNT# FROM EXCEL PHOTO - {fullname} ({bioNo}), ACCOUNT NO.({accountNo})", frmMainForm.UserName_LBL.Text)
                End If

                Console.WriteLine($"Row {row}")
                frmMainForm.AppProgressBar.Value += 1
            Next row

            progressBarEnd()

            MyConnection.Close()
            eApp.Quit()
            eApp.Application.DisplayAlerts = False
        Next

        MsgBox("Importing Done!")
    End Sub

End Module
