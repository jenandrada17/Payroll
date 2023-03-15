Imports System.Data.Common
Imports System.IO
Imports Microsoft.Office.Interop

Module Temporary

    Dim MyConnection As System.Data.OleDb.OleDbConnection
    Dim DtSet As System.Data.DataSet
    Dim MyCommand As System.Data.OleDb.OleDbDataAdapter

    Dim eApp As New Excel.Application
    Dim eBook As Excel.Workbook = Nothing
    Dim eSheet As Excel.Worksheet = Nothing
    Dim eCell As Excel.Range

    Friend Sub Import_Employee_SBU_DATE_ONLY(Path As String)

        eApp = New Excel.Application
        eBook = eApp.Workbooks.Open(Path)
        eSheet = eBook.Worksheets(1)
        eCell = eSheet.UsedRange

        MyConnection = New System.Data.OleDb.OleDbConnection($"provider=Microsoft.Jet.OLEDB.4.0;Data Source='{Path}';Extended Properties=Excel 8.0;")
        MyCommand = New System.Data.OleDb.OleDbDataAdapter($"select * from [{eSheet.Name}$]", MyConnection)
        MyCommand.TableMappings.Add("Table", "Net-informations.com")
        DtSet = New System.Data.DataSet
        MyCommand.Fill(DtSet)

        progressBarStart(DtSet.Tables(0).Rows.Count + 1)

        Dim EMP_NO As String = Nothing

        For row = 7 To DtSet.Tables(0).Rows.Count

            If eCell(row, 1).Font.Bold = True Then
                EMP_NO = eCell(row, 4).Value
            End If

            If EMP_NO <> Nothing And IsDate(eCell(row, 1).value) Then
                Dim datee As DateTime = eCell(row, 1).Value
                UPDATE_Emp_SBU_EXCEL_DATEONLY(EMP_NO, datee, row)

                EMP_NO = Nothing
            End If

            frmMainForm.AppProgressBar.Value += 1
        Next row

        progressBarEnd()

        MyConnection.Close()
        eApp.Quit()
        eApp.Application.DisplayAlerts = False

    End Sub

    Public Sub UPDATE_Emp_SBU_EXCEL_DATEONLY(emp_no As String, datee As String, RowNo As Integer)
        Dim mysql As String = $"Select * From PAYROLL_SBU A inner join PAYROLL_EMPLOYEE B on B.BIO_NO=A.BIO_NO where EMP_NO='{emp_no}'"
        Using dssS As DataSet = LoadSQL(mysql, "PAYROLL_SBU")
            If dssS.Tables(0).Rows.Count > 0 Then
                With dssS.Tables(0).Rows(0)
                    .Item("DATE_ADDED") = datee
                End With
                SaveEntry(dssS, False)
            End If
        End Using
    End Sub

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
    Friend Function OLD_NEW_RATE(BIO_NO As String) As (old_days As Double, new_days As Double, old_overtime As Double,
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

        Dim _mysql As String = $"Select * from TEMP_TABLE where BIO_NO = '{BIO_NO}'"
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
    Friend Function REG_SPEC_HOLIDAY(BIO_NO As String) As (rholiday As Integer, sholiday As Integer)

        Dim Rdays As Integer = 0
        Dim Sdays As Integer = 0

        Dim _mysql As String = $"Select * from TEMP_TABLE where BIO_NO = '{BIO_NO}'"
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

    Friend Sub PayoutRate()
        Dim mysql As String = "Select BIOMETRIC_ID, PRESENT_DAYS, TOTAL_BASIC, FIX_MONTHLY_RATE, RATE_MONTHLY, A.PAYDATE  from Payroll_Payout A 
                                  inner join payroll_employee B on B.BIO_NO = A.BIOMETRIC_ID 
                                  inner join payroll_attendance C on C.BIOMETRICID = A.BIOMETRIC_ID and C.PAYDATE = A.PAYDATE"

        Using ds As DataSet = LoadSQL(mysql, "Payroll_Payout")
            For Each dr In ds.Tables(0).Rows
                With dr

                    Dim ratee As String = CDec(.item("TOTAL_BASIC")) / CDbl(.item("PRESENT_DAYS"))

                    If .item("BIOMETRIC_ID") = 3888 Then
                        Console.WriteLine("TOTAL_BASIC  " & .item("TOTAL_BASIC"))
                    End If

                    If .item("TOTAL_BASIC") = "0" Then
                        ratee = 0
                    ElseIf IsDBNull(.item("FIX_MONTHLY_RATE")) Then

                    ElseIf .item("FIX_MONTHLY_RATE") = "True" Then
                        ratee = CDec(.item("RATE_MONTHLY")) / 26
                    End If

                    Console.WriteLine(.item("BIOMETRIC_ID"))
                    Console.WriteLine(ratee)
                    Console.WriteLine(.item("PAYDATE"))
                    UpdateRate(.item("BIOMETRIC_ID"), ratee, .item("PAYDATE"))
                End With
            Next
        End Using
    End Sub

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

    Friend Sub CostGetDetails()
        ' Start Excel and get Application object.
        appXL = CreateObject("Excel.Application")
        appXL.Visible = True

        ' Add a new workbook.
        wbXl = appXL.Workbooks.Add
        shXL = wbXl.ActiveSheet

        ' Add table headers going cell by cell.
        shXL.Cells(1, 1).Value = "BIOMETRIC_ID"
        shXL.Cells(1, 2).Value = "FULLNAME"
        shXL.Cells(1, 3).Value = "TOTAL_BASIC"
        shXL.Cells(1, 4).Value = "TOTAL_OVERTIME"
        shXL.Cells(1, 5).Value = "TOTAL_LATE_UT"
        shXL.Cells(1, 6).Value = "TOTAL_REGHOLIDAY"
        shXL.Cells(1, 7).Value = "TOTAL_SPECHOLIDAY"
        shXL.Cells(1, 8).Value = "GROSS_AMOUNT"
        shXL.Cells(1, 9).Value = "SSS_COMP"
        shXL.Cells(1, 10).Value = "SSS_ER"
        shXL.Cells(1, 11).Value = "SSS_EC"
        shXL.Cells(1, 12).Value = "PAGIBIG_COMP"
        shXL.Cells(1, 13).Value = "PHILHEALTH_COMP"
        shXL.Cells(1, 14).Value = "TOTAL_ALLOWANCE"
        shXL.Cells(1, 15).Value = "TOTAL_DEDUCTION"
        shXL.Cells(1, 16).Value = "NET_PAY"

        'Dim mysql As String = $"Select * from PAYROLL_PAYOUT A
        '                        inner join PAYROLL_EMPLOYEE B on A.BIOMETRIC_ID = B.BIO_NO  
        '                        where upper(HO_CATEGORY)  LIKE upper('%Dalton Admin Office%') and A.PAYDATE = '3/15/2023'"

        Dim mysql As String = $"Select * from PAYROLL_PAYOUT A
                                inner join PAYROLL_EMPLOYEE B on A.BIOMETRIC_ID = B.BIO_NO  
                                where A.PAYDATE = '3/15/2023' Order by HO_CATEGORY, FULLNAME"

        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_PAYOUT")
            If ds.Tables(0).Rows.Count > 0 Then
                For Each dr In ds.Tables(0).Rows
                    With dr

                        shXL.Cells(row, 1).Value = .item("BIOMETRIC_ID")
                        shXL.Cells(row, 2).Value = .item("FULLNAME")
                        shXL.Cells(row, 3).Value = .item("TOTAL_BASIC")
                        shXL.Cells(row, 4).Value = .item("TOTAL_OVERTIME")
                        shXL.Cells(row, 5).Value = .item("TOTAL_LATE_UT")
                        shXL.Cells(row, 6).Value = .item("TOTAL_REGHOLIDAY")
                        shXL.Cells(row, 7).Value = .item("TOTAL_SPECHOLIDAY")
                        shXL.Cells(row, 8).Value = .item("GROSS_AMOUNT")
                        shXL.Cells(row, 9).Value = .item("SSS_COMP")
                        shXL.Cells(row, 10).Value = .item("SSS_ER")
                        shXL.Cells(row, 11).Value = .item("SSS_EC")
                        shXL.Cells(row, 12).Value = .item("PAGIBIG_COMP")
                        shXL.Cells(row, 13).Value = .item("PHILHEALTH_COMP")
                        shXL.Cells(row, 14).Value = .item("TOTAL_ALLOWANCE")
                        shXL.Cells(row, 15).Value = .item("TOTAL_DEDUCTION")
                        shXL.Cells(row, 16).Value = .item("NET_PAY")
                        shXL.Cells(row, 17).Value = .item("HO_CATEGORY")

                        row += 1
                    End With
                Next
            End If
        End Using

        GetRecordedAllowanceDeduction()
    End Sub

    Friend Sub GetRecordedAllowanceDeduction()
        row += 3

        shXL.Cells(row, 1).Value = "BIOMETRIC_ID"
        shXL.Cells(row, 2).Value = "FULLNAME"
        shXL.Cells(row, 3).Value = "HO_CATEGORY"
        shXL.Cells(row, 4).Value = "ADDITIONAL"
        shXL.Cells(row, 5).Value = "AMOUNT"
        shXL.Cells(row, 6).Value = "DEDUCTION"
        shXL.Cells(row, 7).Value = "AMOUNT"

        row += 1
        'Dim mysql As String = $"Select * from PAYROLL_PAYOUT A
        '                        inner join PAYROLL_EMPLOYEE B on A.BIOMETRIC_ID = B.BIO_NO  
        '                        where upper(HO_CATEGORY) like upper('%Dalton Admin Office%') and A.PAYDATE = '3/15/2023'"

        Dim mysql As String = $"Select * from PAYROLL_PAYOUT A
                                inner join PAYROLL_EMPLOYEE B on A.BIOMETRIC_ID = B.BIO_NO  
                                where A.PAYDATE = '3/15/2023'  Order by HO_CATEGORY, FULLNAME"

        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_PAYOUT")
            If ds.Tables(0).Rows.Count > 0 Then
                For Each dr In ds.Tables(0).Rows
                    With dr

                        shXL.Cells(row, 1).Value = .item("BIOMETRIC_ID")
                        shXL.Cells(row, 2).Value = .item("FULLNAME")
                        shXL.Cells(row, 3).Value = .item("HO_CATEGORY")
                        GetRecorded_Allow_Deduc(.item("BIOMETRIC_ID"))
                    End With
                Next
            End If
        End Using

        raXL = Nothing
        shXL = Nothing
        wbXl = Nothing
        appXL.Quit()
        appXL = Nothing
    End Sub

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
End Module
