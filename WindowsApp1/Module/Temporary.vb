Imports System.IO
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
    Dim row As Integer = 2

    Friend Sub SSS_Contribution_2023()

        Dim Path As String = "C:\Users\MISPC1\Desktop\SSS Contribution 2023.txt"

        For Each line As String In IO.File.ReadAllLines(Path)
            Dim slices As String() = line.Split(vbTab)

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

                        eSheet.Cells(row, column).Value = .item("CATEGORY")
                        eSheet.Cells(row, column + 1).Value = .item("AMOUNT")

                        row += 1
                    End With
                Next
            End If
        End Using
    End Sub

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

    Friend Sub GetBranchCodeInTBL_EMPLOYEE()
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

    <Obsolete>
    Friend Sub ExportDataToExcel()
        ' Set the license context to properly use EPPlus in a commercial context
        ExcelPackage.LicenseContext = LicenseContext.Commercial

        'Incomplete Employee Record - ATTENDANCE ACTIVE ONLY
        Dim mysql As String = "Select BIOMETRICID, COMPANY, RATE_DAILY, RATE_MONTHLY, BRANCHCODE, 
                                    LASTNAME || ', ' || FIRSTNAME || 
                                    CASE
                                        WHEN MIDDLENAME IS NOT NULL AND MIDDLENAME <> '' THEN ' ' || LEFT(MIDDLENAME, 1) || '.' 
                                        ELSE ''
                                    END || 
                                    CASE 
                                        WHEN SUFFIX IS NOT NULL AND SUFFIX <> '' THEN ' ' || SUFFIX
                                        ELSE ''
                                    END AS FULLNAME 
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
                    Dim COMPANY As String = IIf(IsDBNull(.Item("COMPANY")), "", .Item("COMPANY"))

                    UpdateeEMPLOYEE(bio_no, COMPANY)
                End With
            Next
        End Using
    End Sub

    Friend Sub UpdateeEMPLOYEE(BIO As Integer, COMPANY As String)
        Dim mysql As String = $"Select * from TBL_EMPLOYEE where BIOMETRICID = {BIO}"
        Using ds As DataSet = LoadSQL(mysql, "TBL_EMPLOYEE")
            If ds.Tables(0).Rows.Count > 0 Then
                With ds.Tables(0).Rows(0)

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
            SaveLogs($"DEDUCTION ADDED FOR BRANCHES - {fullname} ({bioNo}), Category({deducName}), Total({principal}), Schedule({sched}), Date({Today:MMM dd, yyyy})", frmMainForm.UserName_LBL.Text)

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
        Dim mysql As String = $"SELECT * FROM PAYROLL_PAYOUT WHERE PAYDATE IN ('6/30/2024')"
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

    Friend Function GetMAX(table As String, column As String)
        Dim mysql As String = $"Select MAX({column}) FROM {table}"
        Dim ds As DataSet = LoadSQL(mysql, table)
        If ds.Tables(0).Rows.Count > 0 Then
            Console.WriteLine(CDate(ds.Tables(0).Rows(0).Item(0)).ToShortDateString)
            Return CDate(ds.Tables(0).Rows(0).Item(0)).ToShortDateString
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
