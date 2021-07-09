Imports System.IO
Imports Microsoft.Office.Interop


Public Class SampleImport

    Const FileIntegrity As String = "Iys1VyFQO26AVnU/1kqPRrn1uTgA1yUEd11xYfXmleif+xHxp/DGJa/2oICmWM8GNobpiCPRr0leiujSU4A1F8AA6+kB0hFpQsV2QgeMBp2uFF39TEVVNx1h47jEsX9/lgJb2/QINet7xQjTkH+AavDC89WceMEZOaJk7o4rMp4LC3feSjZV0dSKNi9iZkgMA0V6CUisOGxVzpVhn2td5dHCg1AQ/ktsU3AlKWvRJ+gFpKp4rXSZ31qxT3Zfsz2jDH1MW0ZZuIoM4frXyyw+R0i1M4tLq8BTARkA8rrh9n9wkN/uKmvkUWHKy03ncanze0GEpkijZqY="
    Dim eApp As New Excel.Application
    Dim eBook As Excel.Workbook = Nothing
    Dim eSheet As Excel.Worksheet = Nothing
    Dim eCell As Excel.Range

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles OpenFile_BTN.Click
        Using f As New OpenFileDialog
            f.Filter = "Excel 2003|*.xls|Excel 2007|*.xlsx"
            If DialogResult.OK = f.ShowDialog() Then
                Path_TXT.Text = f.FileName
                ExcelFilePath(Path_TXT.Text)
            End If
        End Using
    End Sub
    Private Function ExcelFilePath(ByVal filePath As String) As String
        DefaultFolder = Path.GetDirectoryName(filePath)
        TargetFile = filePath
        Return TargetFile
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Import_BTN.Click

        eApp = New Excel.Application
        eBook = eApp.Workbooks.Open(Path_TXT.Text)
        eSheet = eBook.Worksheets(1)
        eCell = eSheet.UsedRange
        Dim row As Integer

        Dim MyConnection As System.Data.OleDb.OleDbConnection
        Dim DtSet As System.Data.DataSet
        Dim MyCommand As System.Data.OleDb.OleDbDataAdapter
        MyConnection = New System.Data.OleDb.OleDbConnection($"provider=Microsoft.Jet.OLEDB.4.0;Data Source='{Path_TXT.Text}';Extended Properties=Excel 8.0;")
        MyCommand = New System.Data.OleDb.OleDbDataAdapter($"select * from [{eSheet.Name}$]", MyConnection)
        MyCommand.TableMappings.Add("Table", "Net-informations.com")
        DtSet = New System.Data.DataSet
        MyCommand.Fill(DtSet)

        For row = 2 To DtSet.Tables(0).Rows.Count

            Dim mysql As String = "Select * From SAMPLE Rows 1"
            Using ds As DataSet = LoadSQL(mysql, "SAMPLE")

                Dim dsNewRow As DataRow = ds.Tables(0).NewRow
                With dsNewRow
                    .Item("BIOMETRICID") = eCell(row, 1).Value
                    .Item("DATEANDTIME") = eCell(row, 2).Value
                End With
                ds.Tables(0).Rows.Add(dsNewRow)
                SaveEntry(ds)

            End Using
        Next

        'Bio_grid.DataSource = DtSet.Tables(0)

        MessageBox.Show("Succesfully Saved!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        MyConnection.Close()
    End Sub

End Class