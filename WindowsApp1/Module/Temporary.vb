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
                    Console.WriteLine("bioNOO " & .Item("BIO_NO"))
                    Console.WriteLine("EMP_NO " & .Item("EMP_NO"))
                    Console.WriteLine("RowNo " & RowNo)
                    .Item("DATE_ADDED") = datee
                End With
                SaveEntry(dssS, False)
            End If
        End Using
    End Sub

    Friend Sub SaveTemporary(BIO_NO As String, old_days As Double, new_days As Double, OLD_OVERTIME As Double, NEW_OVERTIME As Double, OLD_LATE As Double, NEW_LATE As Double, OLD_UNDERTIME As Double, NEW_UNDERTIME As Double)
        Dim mysql As String = $"Select * from TEMP_TABLE where BIO_NO = '{BIO_NO}'"
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
                    End With
                    dss.Tables(0).Rows.Add(dsNew)
                    SaveEntry(dss)
                End Using
            End If
        End Using
    End Sub

    Friend Sub 
End Module
