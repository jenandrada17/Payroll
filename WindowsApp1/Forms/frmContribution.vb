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
        Load_Loans(SSSLoan_LV, "PAYROLL_SSSLOAN")
        Load_Loans(Pag_grid, "PAYROLL_PAGIBIGLOAN")

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

            SaveLogs($"CHANGED PAGIBIG DISTRIBUTION Employee({HMDF_EE_TXT.Text}), Employer({HMDF_ER_TXT.Text})", frmMainForm.UserName_LBL.Text)
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

            SaveLogs($"CHANGED PHILHEALTH DISTRIBUTION Amount({PhilH_Rate_TXT.Text})", frmMainForm.UserName_LBL.Text)
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

    Private Sub Close_LBL_Click(sender As Object, e As EventArgs) Handles Close_LBL.Click
        Close()
    End Sub

    Private Sub SSS_SearchEmp_BTN_Click(sender As Object, e As EventArgs) Handles SSS_SearchEmp_BTN.Click

        Try
            Dim instForm As Form = Application.OpenForms.OfType(Of Form)().Where(Function(frm) frm.Name = "frmNewEmployee").SingleOrDefault()
            If instForm Is Nothing Then
                Dim frm As frmNewEmployee
                frm = DirectCast(CreateObjectInstance("frmNewEmployee"), Form)
                frm.MdiParent = frmMainForm
                frmMainForm.pNavigate.Controls.Add(frm)
                frmMainForm.pNavigate.Tag = frm
                frm.txtSearch.Tag = "SSS Loan"
                frm.Dock = DockStyle.Fill
                frm.BringToFront()
                frm.Show()
            Else
                instForm.BringToFront()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Allow_Cancel_BTN_Click(sender As Object, e As EventArgs) Handles Allow_Cancel_BTN.Click
        SSS_Name_TXT.Clear()
        SSS_Amount_TXT.Clear()
        SSS_FirstAmort_DTP.Value = Today
        SSS_MaturityAmort_DTP.Value = Today
    End Sub

    Private Sub Allow_Save_BTN_Click(sender As Object, e As EventArgs) Handles Allow_Save_BTN.Click
        Save_SSSLoan(SSS_Name_TXT.Tag, SSS_Amount_TXT.Text, SSS_FirstAmort_DTP.Value, SSS_MaturityAmort_DTP.Value)
        Load_Loans(SSSLoan_LV, "PAYROLL_SSSLOAN")

        SaveLogs($"ADDED SSS LOAN {SSS_Name_TXT.Text} ({SSS_Name_TXT.Tag}), Amount({SSS_Amount_TXT.Text}), Start({SSS_FirstAmort_DTP.Value.ToString("MMM dd, yyyy")}), End({SSS_MaturityAmort_DTP.Value.ToString("MMM dd, yyyy")})", frmMainForm.UserName_LBL.Text)
    End Sub

    Private Sub Emp_BTN_Click(sender As Object, e As EventArgs) Handles Emp_BTN.Click

        Try
            Dim instForm As Form = Application.OpenForms.OfType(Of Form)().Where(Function(frm) frm.Name = "frmNewEmployee").SingleOrDefault()
            If instForm Is Nothing Then
                Dim frm As frmNewEmployee
                frm = DirectCast(CreateObjectInstance("frmNewEmployee"), Form)
                frm.MdiParent = frmMainForm
                frmMainForm.pNavigate.Controls.Add(frm)
                frmMainForm.pNavigate.Tag = frm
                frm.txtSearch.Tag = "Pagibig Loan"
                frm.Dock = DockStyle.Fill
                frm.BringToFront()
                frm.Show()
            Else
                instForm.BringToFront()
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Pag_Save_BTN_Click(sender As Object, e As EventArgs) Handles Pag_Save_BTN.Click
        Save_PAGIBIGLoan(Pag_Name_TXT.Tag, Pag_Amount_TXT.Text, Pag_Start_DTP.Value, Pag_End_DTP.Value)
        Load_Loans(Pag_grid, "PAYROLL_PAGIBIGLOAN")

        SaveLogs($"ADDED PAGIBIG LOAN {Pag_Name_TXT.Text} ({Pag_Name_TXT.Tag}), Amount({Pag_Amount_TXT.Text}), Start({Pag_Start_DTP.Value.ToString("MMM dd, yyyy")}), End({Pag_End_DTP.Value.ToString("MMM dd, yyyy")})", frmMainForm.UserName_LBL.Text)
    End Sub

    Public Sub Load_Contrib_Loan(emp As Employee, tabName As String)
        With emp
            If tabName = "SSS" Then

                Contribution_Tab.SelectedIndex = 4
                SSS_Name_TXT.Text = .Fullname
                SSS_Name_TXT.Tag = .BiometricID

            Else
                Contribution_Tab.SelectedIndex = 5
                Pag_Name_TXT.Text = .Fullname
                Pag_Name_TXT.Tag = .BiometricID
            End If
        End With
    End Sub

    Private Sub SSS_Amount_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles SSS_Amount_TXT.KeyPress, Pag_Amount_TXT.KeyPress
        If e.KeyChar <> ChrW(Keys.Back) Then
            If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub
End Class