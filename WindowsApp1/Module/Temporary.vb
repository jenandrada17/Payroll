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

End Module
