Imports System.IO
Imports Microsoft.Office.Interop

Public Class frmSchedule

    Dim eApp As New Excel.Application
    Dim eBook As Excel.Workbook = Nothing
    Dim eSheet As Excel.Worksheet = Nothing
    Dim eCell As Excel.Range
    Dim MyConnection As System.Data.OleDb.OleDbConnection
    Dim DtSet As System.Data.DataSet
    Dim MyCommand As System.Data.OleDb.OleDbDataAdapter

    Dim startingDate, EndingDate As DateTime
    Dim starting_date, ending_date As DateTime
    Dim StartFour, EndFour, StartNineteen, EndNineteen, Paydate, DateNow As DateTime
    Dim paydate_ As String

    Dim allowMove As Boolean = False
    Dim movePoint As New Point

    Private Sub lvEmployee_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lvEmployee.MouseDoubleClick

        BiometricID_TXT.Text = lvEmployee.Items(lvEmployee.FocusedItem.Index).SubItems(0).Text
        Paydate = lvEmployee.Items(lvEmployee.FocusedItem.Index).SubItems(2).Text

        ListSchedule(Schedule_DG, BiometricID_TXT.Text, Paydate)

        TabControl1.SelectedIndex = 1

    End Sub

    Private Sub Save_BTN_Click(sender As Object, e As EventArgs) Handles Save_BTN.Click

        If BiometricID_TXT.Text <> Nothing And Name_TXT.Text <> Nothing Then

            Dim PAYROLL As String
            If Paydate_ComboB.SelectedIndex >= 0 Then
                PAYROLL = Paydate_ComboB.SelectedItem
            Else
                PAYROLL = Schedule_DG.Tag
            End If

            For Each row As DataGridViewRow In Schedule_DG.Rows
                If row.Cells(1).Value <> Nothing And row.Cells(2).Value <> Nothing Then
                    SaveSchedule(BiometricID_TXT.Text, row.Tag, row.Cells(1).Value, row.Cells(2).Value, PAYROLL, row.Cells(3).Tag)

                    If row.Cells(3).Tag <> Nothing Then

                        If row.Cells(3).Tag <> Nothing Then
                            If File.Exists(row.Cells(3).Tag) Then
                                File.Delete(row.Cells(3).Tag)
                            End If
                        ElseIf Not File.Exists(row.Cells(3).Tag) And row.Cells(2).Tag <> Nothing Then
                            Dim newFile As New FileInfo(row.Cells(2).Tag)
                            newFile.CopyTo(row.Cells(3).Tag)
                        End If

                    End If

                End If
            Next

            MsgBox("Successfully Saved!", MsgBoxStyle.Information)
            Cancel_BTN.PerformClick()
        Else
            MsgBox("Please indicate employee details before saving!", MsgBoxStyle.Exclamation)
        End If

    End Sub

    Private Sub BiometricID_TXT_TextChanged(sender As Object, e As EventArgs) Handles BiometricID_TXT.TextChanged
        If BiometricID_TXT.Text = "" Then
            Name_TXT.Text = ""

            For Each oRow As DataGridViewRow In Schedule_DG.Rows
                oRow.Cells(1).Value = Nothing
                oRow.Cells(2).Value = Nothing
                oRow.Cells(3).Value = Nothing
            Next

        Else
            GetName(BiometricID_TXT.Text, Name_TXT)
            ListSchedule(Schedule_DG, BiometricID_TXT.Text, Paydate)
        End If
    End Sub

    Private Sub Cancel_BTN_Click(sender As Object, e As EventArgs) Handles Cancel_BTN.Click
        BiometricID_TXT.Clear()
        LoadDateTime()
    End Sub

    Private Sub SearchEMP_BTN_Click(sender As Object, e As EventArgs) Handles SearchEMP_BTN.Click

        Dim instForm As Form = Application.OpenForms.OfType(Of Form)().Where(Function(frm) frm.Name = "frmNewEmployee").SingleOrDefault()
        If instForm Is Nothing Then
            Dim frm As frmNewEmployee
            frm = DirectCast(CreateObjectInstance("frmNewEmployee"), Form)
            frm.MdiParent = frmMainForm
            frmMainForm.pNavigate.Controls.Add(frm)
            frmMainForm.pNavigate.Tag = frm
            frm.txtSearch.Tag = "Scheduling"
            frm.Dock = DockStyle.Fill
            frm.BringToFront()
            frm.Show()
        Else
            instForm.BringToFront()
        End If

    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 0 Then
            PopulateComboBox(Paydate_ComboB, "PAYROLL_SCHEDULE", "PAYDATE")
        ElseIf TabControl1.SelectedIndex = 1 Then
            Schedule_DG.ClearSelection()
        End If
    End Sub

    Private Sub Path_TXT_TextChanged(sender As Object, e As EventArgs) Handles Path_TXT.TextChanged
        If Path_TXT.Text.Length > 0 Then
            Import_BTN.Enabled = True
        Else
            Import_BTN.Enabled = False
        End If
    End Sub

    Private Sub Schedule_DG_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Schedule_DG.CellContentClick

        Dim grid = DirectCast(sender, DataGridView)
        Dim row As DataGridViewRow = Schedule_DG.Rows(e.RowIndex)

        If TypeOf grid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn Then
            If row.Cells(3).Value = "View" Then
                If row.Cells(3).Tag = Nothing Then
                    Process.Start(row.Cells(2).Tag)
                Else
                    Process.Start(row.Cells(3).Tag)
                End If
            ElseIf row.Cells(3).Value = "Upload" Then
                Attach_Panel.Visible = True
                Attach_Panel.Location = New Point(345, 115)
            End If
        End If
    End Sub

    Private Sub AttachClose_lbl_Click(sender As Object, e As EventArgs) Handles AttachClose_lbl.Click
        Attach_Panel.Hide()
    End Sub

    Private Sub AttachBrowse_btn_Click(sender As Object, e As EventArgs) Handles AttachBrowse_btn.Click
        Using f As New OpenFileDialog
            f.Filter = "PDF files|*.pdf"
            If DialogResult.OK = f.ShowDialog() Then
                AttachPath_txt.Text = f.FileName
                AttachSave_btn.Enabled = True
            End If
        End Using
    End Sub

    Private Sub AttachSave_btn_Click(sender As Object, e As EventArgs) Handles AttachSave_btn.Click

        Dim row As DataGridViewRow = Schedule_DG.Rows(Schedule_DG.CurrentRow.Index)
        Dim datee As Date = row.Cells(0).Tag

        Dim Nas_Folder As DirectoryInfo = New DirectoryInfo("\\Pgcnas_server\hr\COMMON FILES\Schedule Attachment")
        Dim Nas_Employee_Folder As DirectoryInfo = New DirectoryInfo($"\\Pgcnas_server\hr\COMMON FILES\Schedule Attachment\{Name_TXT.Text}")

        If Not Nas_Folder.Exists Then Nas_Folder.Create()
        If Not Nas_Employee_Folder.Exists Then Nas_Employee_Folder.Create()

        Dim newName As String = $"{Nas_Employee_Folder}\{row.Cells(1).Value} - {datee.ToString("MMM dd, yyyy")}.pdf"

        row.Cells(2).Tag = AttachPath_txt.Text
        row.Cells(3).Tag = newName
        row.Cells(3).Value = "View"

        AttachPath_txt.Clear()
        AttachSave_btn.Enabled = False
        Attach_Panel.Hide()

    End Sub

    Private Sub Attach_Panel_MouseDown(sender As Object, e As MouseEventArgs) Handles Attach_Panel.MouseDown
        allowMove = True
        movePoint = New Point(e.X, e.Y)
        Cursor = Cursors.SizeAll
    End Sub

    Private Sub Attach_Panel_MouseUp(sender As Object, e As MouseEventArgs) Handles Attach_Panel.MouseUp
        allowMove = False
        Cursor = Cursors.Default
    End Sub

    Private Sub Attach_Panel_MouseMove(sender As Object, e As MouseEventArgs) Handles Attach_Panel.MouseMove
        If allowMove = True Then
            Attach_Panel.Location = New Point(Attach_Panel.Location.X + e.X - movePoint.X, Attach_Panel.Location.Y + e.Y - movePoint.Y)
        End If
    End Sub

    Private Sub Schedule_DG_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles Schedule_DG.DataError
        '========================= Need para di magERROR ang Datagrid==============
    End Sub

    Public Sub LoadDateTime(Optional datee As DateTime = Nothing)
        Schedule_DG.Rows.Clear()

        Dim rowIndex As Integer

        If datee = Nothing Then
            DateNow = DateTime.Now
        Else
            DateNow = datee
        End If

        StartFour = New DateTime(DateNow.Year, DateNow.Month, 4).AddDays(-1)
        EndFour = New DateTime(DateNow.Year, DateNow.Month, 18)

        StartNineteen = New DateTime(DateNow.Year, DateNow.Month, 19).AddMonths(-1).AddDays(-1)
        EndNineteen = New DateTime(StartNineteen.Year, StartNineteen.Month, 3).AddMonths(1)


        If DateNow.Day - 16 <= 2 And DateNow.Day - 16 >= -12 Then

            Paydate = EndNineteen.AddDays(12)
            Schedule_DG.Tag = Paydate
            starting_date = StartNineteen.AddDays(1)
            ending_date = EndNineteen

            While (StartNineteen < EndNineteen)
                startingDate = StartNineteen.ToString("d")
                EndingDate = EndNineteen.ToString("d")

                rowIndex = Schedule_DG.Rows.Add(StartNineteen.AddDays(1).ToString("D"))
                Schedule_DG.Rows(rowIndex).Tag = StartNineteen.AddDays(1).ToString("d")

                StartNineteen = StartNineteen.AddDays(1)
            End While

            Console.WriteLine("PAydateee1 " & Paydate)
        Else

            Paydate = New DateTime(EndFour.Year, EndFour.Month, DateTime.DaysInMonth(EndFour.Year, EndFour.Month))
            Schedule_DG.Tag = Paydate
            starting_date = StartFour.AddDays(1)
            ending_date = EndFour

            While (StartFour < EndFour)

                startingDate = StartFour.ToString("d")
                EndingDate = EndFour.ToString("d")

                rowIndex = Schedule_DG.Rows.Add(StartFour.AddDays(1).ToString("D"))
                Schedule_DG.Rows(rowIndex).Tag = StartFour.AddDays(1).ToString("d")

                StartFour = StartFour.AddDays(1)

            End While

            Console.WriteLine("PAydateee1 " & Paydate)
        End If

        Dim tm As New Date(1, 1, 1, 0, 0, 0)
        For x = 1 To 48
            tm = tm.AddMinutes(30)
            Time_In_DataGrid.Items.Add(tm.ToShortTimeString)
            Time_Out_DataGrid.Items.Add(tm.ToShortTimeString)
        Next

        For i = 0 To Schedule_DG.Rows.Count - 1
            Dim r As DataGridViewRow = Schedule_DG.Rows(i)
            r.Height = 28
        Next
    End Sub

    Private Sub Close_LBL_Click(sender As Object, e As EventArgs) Handles Close_LBL.Click
        Close()
    End Sub

    Private Sub Browse_BTN_Click(sender As Object, e As EventArgs) Handles Browse_BTN.Click

        Dim dialog = New OpenFileDialog
        If dialog.ShowDialog() = DialogResult.OK Then
            Path_TXT.Text = dialog.FileName
        End If

    End Sub

    Private Sub Import_BTN_Click(sender As Object, e As EventArgs) Handles Import_BTN.Click
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

        Dim countOfColumns = DtSet.Tables(0).Columns.Count

        For row = 7 To DtSet.Tables(0).Rows.Count + 1
            Dim start As DateTime = starting_date
            Dim endd As DateTime = ending_date

            If eCell(row, 1).Value = Nothing Then
                Exit For
            End If

            While (start <= endd)
                For columns = 4 To DtSet.Tables(0).Columns.Count + 1

                    If start = eCell(5, columns).Value Then

                        Dim bio As String = eCell(row, 1).Value
                        Dim datee As DateTime = eCell(5, columns).Value
                        Dim time_in, time_out As String

                        Dim valuee As String = eCell(row, columns).Value

                        If valuee = Nothing Then
                            Continue For
                        End If

                        If eCell(row, columns).Value.Equals("") Then
                            Continue For

                        Else

                            time_in = eCell(row, columns).Value
                            time_out = eCell(row, columns + 1).Value

                            SaveSchedule(bio, datee, time_in, time_out, Paydate)

                        End If
                    End If
                Next

                start = start.AddDays(1)
            End While

            frmMainForm.AppProgressBar.Value += 1

        Next

        progressBarEnd()
        PopulateShedule(lvEmployee, Paydate) ' ===== POPULATE DATAGRIDVIEW FROM SHEET ====  

        Import_BTN.Enabled = False
        Path_TXT.Clear()
        MyConnection.Close()

    End Sub

    Private Sub frmSchedule_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PopulateComboBox(Paydate_ComboB, "PAYROLL_SCHEDULE", "PAYDATE")
        LoadDateTime()

        Time_In_DataGrid.Items.Insert(0, "")
        Time_In_DataGrid.Items.Insert(1, "SIL")
        Time_In_DataGrid.Items.Insert(2, "AL")
        Time_In_DataGrid.Items.Insert(3, "RD")

        Time_Out_DataGrid.Items.Insert(0, "")
        Time_Out_DataGrid.Items.Insert(1, "SIL")
        Time_Out_DataGrid.Items.Insert(2, "AL")
        Time_Out_DataGrid.Items.Insert(3, "RD")
    End Sub

    Private Sub Paydate_ComboB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Paydate_ComboB.SelectedIndexChanged
        If Paydate_ComboB.SelectedIndex >= 0 Then
            paydate_ = Paydate_ComboB.SelectedItem
        Else
            paydate_ = Paydate.ToString("d")
        End If

        PopulateShedule(lvEmployee, paydate_)

        Dim datee As DateTime = paydate_
        LoadDateTime(paydate_)

        Time_In_DataGrid.Items.Insert(0, "")
        Time_Out_DataGrid.Items.Insert(0, "")
    End Sub

    Public Sub Load_Schedule(emp As Employee)
        With emp
            BiometricID_TXT.Text = .BiometricID
            Name_TXT.Text = .Fullname
            Name_TXT.Tag = .EMP_ID
        End With
    End Sub

End Class