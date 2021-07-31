Imports Microsoft.Office.Interop

Public Class frmContribution

    Dim eApp As New Excel.Application
    Dim eBook As Excel.Workbook = Nothing
    Dim eSheet As Excel.Worksheet = Nothing
    Dim eCell As Excel.Range

    Private Sub frmContribution_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SSS_grid.ClearSelection()
        Populate_SSS(SSS_grid)
    End Sub

    Private Sub OpenFile_BTN_Click(sender As Object, e As EventArgs) Handles OpenFile_BTN.Click
        Using f As New OpenFileDialog
            f.Filter = "Excel 2003|*.xls|Excel 2007|*.xlsx"
            If DialogResult.OK = f.ShowDialog() Then
                Path_TXT.Text = f.FileName
                ExcelFilePath(Path_TXT.Text)
                Import_BTN.Enabled = True
            End If
        End Using
    End Sub

    Private Sub Import_BTN_Click(sender As Object, e As EventArgs) Handles Import_BTN.Click

        SSS_grid.Rows.Clear()
        Dim MyConnection As System.Data.OleDb.OleDbConnection
        Dim DtSet As System.Data.DataSet
        Dim MyCommand As System.Data.OleDb.OleDbDataAdapter

        Try
            eApp = New Excel.Application
            eBook = eApp.Workbooks.Open(Path_TXT.Text)
            eSheet = eBook.Worksheets(1)
            eCell = eSheet.UsedRange
            Dim row As Integer

            MyConnection = New System.Data.OleDb.OleDbConnection($"provider=Microsoft.Jet.OLEDB.4.0;Data Source='{Path_TXT.Text}';Extended Properties=Excel 8.0;")
            MyCommand = New System.Data.OleDb.OleDbDataAdapter($"select * from [{eSheet.Name}$]", MyConnection)
            MyCommand.TableMappings.Add("Table", "Net-informations.com")
            DtSet = New System.Data.DataSet
            MyCommand.Fill(DtSet)

            progressBarStart(DtSet.Tables(0).Rows.Count)

            Has_Rows_Delete("PAYROLL_SSS")

            For row = 4 To DtSet.Tables(0).Rows.Count

                SaveSSS_Contribution(eCell(row, 1).Value, eCell(row, 2).Value, eCell(row, 3).Value, eCell(row, 4).Value, eCell(row, 5).Value, eCell(row, 6).Value, eCell(row, 7).Value,
                                     eCell(row, 8).Value, eCell(row, 9).Value, eCell(row, 10).Value, eCell(row, 11).Value, eCell(row, 12).Value, eCell(row, 13).Value, eCell(row, 14).Value,
                                     eCell(row, 15).Value, eCell(row, 16).Value)

                frmMainForm.AppProgressBar.Value += 1

            Next

            Populate_SSS(SSS_grid)

            progressBarEnd()

            Import_BTN.Enabled = False
            Path_TXT.Clear()
            MyConnection.Close()

        Catch ee As Exception
            MsgBox("Excel Format is not supported! -" & ee.Message, MsgBoxStyle.Information, "Information")
        End Try

    End Sub

    Private Sub PagChange_BTN_Click(sender As Object, e As EventArgs) Handles PagChange_BTN.Click
        If PagChange_BTN.Text = "Change" Then
            PagChange_BTN.Text = "Save"
        Else
            Save_Pagibig(Pagibig_grid)
            PagChange_BTN.Text = "Change"
        End If

    End Sub
End Class