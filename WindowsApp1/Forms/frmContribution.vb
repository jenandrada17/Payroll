Imports Microsoft.Office.Interop

Public Class frmContribution

    Dim eApp As New Excel.Application
    Dim eBook As Excel.Workbook = Nothing
    Dim eSheet As Excel.Worksheet = Nothing
    Dim eCell As Excel.Range

    Private Sub frmContribution_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SSS_grid.ClearSelection()
        Populate_SSS(SSS_grid)
        Populate_Pagibig(HMDF_EE_TXT, HMDF_ER_TXT)
        Populate_PhilHeath(PhilH_Rate_TXT)
        Populate_WHOLDING_TAX(WH_grid)
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
            HMDF_EE_TXT.ReadOnly = False
            HMDF_ER_TXT.ReadOnly = False
        Else
            Save_Pagibig(HMDF_EE_TXT.Text, HMDF_ER_TXT.Text)
            PagChange_BTN.Text = "Change"
            HMDF_EE_TXT.ReadOnly = True
            HMDF_ER_TXT.ReadOnly = True
            Populate_Pagibig(HMDF_EE_TXT, HMDF_ER_TXT)
        End If
    End Sub

    Private Sub PhilH_Save_BTN_Click(sender As Object, e As EventArgs) Handles PhilH_Save_BTN.Click
        If PhilH_Save_BTN.Text = "Change" Then
            PhilH_Save_BTN.Text = "Save"
            PhilH_Rate_TXT.ReadOnly = False
        Else
            Save_PhilHealth(PhilH_Rate_TXT.Text)
            PhilH_Save_BTN.Text = "Change"
            PhilH_Rate_TXT.ReadOnly = True
            Populate_PhilHeath(PhilH_Rate_TXT)
        End If
    End Sub

    Private Sub HMDF_EE_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles HMDF_ER_TXT.KeyPress, HMDF_EE_TXT.KeyPress, PhilH_Rate_TXT.KeyPress
        If e.KeyChar <> ChrW(Keys.Back) Then
            If Char.IsNumber(e.KeyChar) Then
            Else
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub WH_Change_BTN_Click(sender As Object, e As EventArgs) Handles WH_Change_BTN.Click
        If WH_Change_BTN.Text = "Change" Then
            WH_Change_BTN.Text = "Save"
            WH_grid.ReadOnly = False
            WH_grid.AllowUserToAddRows = True
        Else
            Save_WihtholdingTax(WH_grid)
            WH_Change_BTN.Text = "Change"
            WH_grid.ReadOnly = True
            WH_grid.AllowUserToAddRows = False
            Populate_WHOLDING_TAX(WH_grid)
        End If
    End Sub
End Class