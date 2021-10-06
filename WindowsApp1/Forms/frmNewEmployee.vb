Imports Microsoft.Office.Interop

Public Class frmNewEmployee

    Dim MyConnection As System.Data.OleDb.OleDbConnection
    Dim DtSet As System.Data.DataSet
    Dim MyCommand As System.Data.OleDb.OleDbDataAdapter

    Dim eApp As New Excel.Application
    Dim eBook As Excel.Workbook = Nothing
    Dim eSheet As Excel.Worksheet = Nothing
    Dim eCell As Excel.Range

    Private allowCoolMove As Boolean = False
    Private myCoolPoint As New Point


    Private Sub frmNewEmployee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Lists_Employees(lvEmployee)
    End Sub

    Private Sub Close_LBL_Click(sender As Object, e As EventArgs) Handles Close_LBL.Click
        Close()
    End Sub

    Private Sub Label76_Click(sender As Object, e As EventArgs) Handles Label76.Click
        Excel_Panel.Visible = False
    End Sub

    Private Sub Browse_BTN_Click(sender As Object, e As EventArgs) Handles Browse_BTN.Click
        Using f As New OpenFileDialog
            f.Filter = "Excel 2003|*.xls|Excel 2007|*.xlsx"
            If DialogResult.OK = f.ShowDialog() Then
                Path_TXT.Text = f.FileName
                ExcelFilePath(Path_TXT.Text)
                Save_BTN.Enabled = True
            End If
        End Using
    End Sub

    Private Sub Save_BTN_Click(sender As Object, e As EventArgs) Handles Save_BTN.Click
        If Company_ComboB.SelectedIndex >= 0 Then

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

            For row = 3 To DtSet.Tables(0).Rows.Count + 1

                'If Font.Color = Color.B Then
                '    SaveNew_Employee(Company_ComboB.Text, eCell(row, 1).value, eCell(row, 2).Value, eCell(row, 3).Value, eCell(row, 4).Value, "ACTIVE", True)
                'Else
                '    SaveNew_Employee(Company_ComboB.Text, eCell(row, 1).value, eCell(row, 2).Value, eCell(row, 3).Value, eCell(row, 4).Value, "INACTIVE", True)
                'End If

                SaveNew_Employee(Company_ComboB.Text, eCell(row, 1).value, eCell(row, 2).Value, eCell(row, 3).Value, eCell(row, 4).Value, "ACTIVE", True)

                frmMainForm.AppProgressBar.Value += 1

            Next

            progressBarEnd()

            Lists_Employees(lvEmployee) ' ===== POPULATE DATAGRIDVIEW FROM SHEET ====    

            Import_BTN.Enabled = False
            Path_TXT.Clear()
            MyConnection.Close()
        Else
            MsgBox("Please Select Company.", MsgBoxStyle.Exclamation, "Error")
        End If

    End Sub

    Private Sub Import_BTN_Click(sender As Object, e As EventArgs) Handles Import_BTN.Click
        Excel_Panel.Visible = True
    End Sub

    Private Sub Excel_Panel_MouseDown(sender As Object, e As MouseEventArgs) Handles Excel_Panel.MouseDown
        allowCoolMove = True
        myCoolPoint = New Point(e.X, e.Y)
        Cursor = Cursors.SizeAll
    End Sub

    Private Sub Excel_Panel_MouseMove(sender As Object, e As MouseEventArgs) Handles Excel_Panel.MouseMove
        If allowCoolMove = True Then
            Excel_Panel.Location = New Point(Excel_Panel.Location.X + e.X - myCoolPoint.X, Excel_Panel.Location.Y + e.Y - myCoolPoint.Y)
        End If
    End Sub

    Private Sub Excel_Panel_MouseUp(sender As Object, e As MouseEventArgs) Handles Excel_Panel.MouseUp
        allowCoolMove = False
        Cursor = Cursors.Default
    End Sub

    Private Sub Path_TXT_TextChanged(sender As Object, e As EventArgs) Handles Path_TXT.TextChanged
        If Path_TXT.Text <> Nothing And Company_ComboB.SelectedIndex >= 0 Then
            Save_BTN.Enabled = True
        Else
            Save_BTN.Enabled = False
        End If
    End Sub

End Class