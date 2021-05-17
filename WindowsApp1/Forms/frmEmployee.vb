
Public Class frmEmployee

    Dim rowCount As Integer

    Private Sub Close_LBL_MouseEnter(sender As Object, e As EventArgs) Handles Close_LBL.MouseEnter
        Close_LBL.ForeColor = Color.Red
    End Sub

    Private Sub Close_LBL_MouseLeave(sender As Object, e As EventArgs) Handles Close_LBL.MouseLeave
        Close_LBL.ForeColor = Color.Black
    End Sub

    Private Sub Close_LBL_Click(sender As Object, e As EventArgs) Handles Close_LBL.Click
        Close()
    End Sub

    Private Sub LoadEmployee(Optional ByVal str As String = "")

        Try
            Dim secured_str As String = str
            secured_str = DreadKnight(secured_str)
            'Dim strWords As String() = secured_str.Split(New Char() {" "c})
            'Dim name As String
            Dim mysql As String


            If str.Length <> 0 Then
                mysql = "select * from tbl_Employee A inner join tbl_branch B on A.BRANCH_ID = B.ID
                    Where Upper(A.firstname) Like Upper('%" & secured_str & "%') OR Upper(A.lastname) Like Upper('%" & secured_str & "%') 
                    OR Upper(B.branchname) Like Upper('%" & secured_str & "%')  OR Upper(B.COMPANYNAME) Like Upper('%" & secured_str & "%')
                    OR Upper(A.STATUS) Like Upper('%" & secured_str & "%') "
            Else
                mysql = "Select * From tbl_Employee A inner join tbl_branch B on A.BRANCH_ID = B.ID  "
            End If


            Using ds As DataSet = LoadSQL(mysql, "tbl_Employee")
                rowCount = ds.Tables(0).Rows.Count
                Dim maxEntries As Integer = ds.Tables(0).Rows.Count
                frmMainForm.AppProgressBar.Maximum = maxEntries
                frmMainForm.AppProgressBar.Visible = True
                lvEmployee.Items.Clear()
                For Each dr In ds.Tables(0).Rows
                    AddItem(dr)
                    frmMainForm.AppProgressBar.Value += 1
                Next
            End Using

            frmMainForm.AppProgressBar.Value = 0
            frmMainForm.AppProgressBar.Maximum = 1000
            frmMainForm.AppProgressBar.Visible = False
        Catch ex As Exception
            Log_Report(ex.ToString())
        End Try
    End Sub

    Private Sub AddItem(ByVal dr As DataRow)
        With dr
            Dim lv As ListViewItem = lvEmployee.Items.Add(.Item("ID"))
            lv.SubItems.Add(.Item("BIOMETRICID"))
            lv.SubItems.Add(String.Format("{0}, {1} {2}", .Item("LastName"), .Item("FirstName"), .Item("MiddleName")))
            lv.SubItems.Add(.Item("EMP_RATE"))
            lv.SubItems.Add(.Item("FIX_RATE"))
            lv.SubItems.Add(.Item("DATEHIRED"))
            lv.SubItems.Add(.Item("NO_OF_DAYS"))
            lv.SubItems.Add(.Item("CONTACTNO"))
            lv.SubItems.Add(.Item("EmailAdd"))
            lv.SubItems.Add(.Item("STATUS"))
            lv.SubItems.Add(.Item("EMP_POSITION"))
            lv.SubItems.Add(.Item("COMPANYNAME"))
            lv.SubItems.Add(.Item("BRANCHNAME"))
        End With
    End Sub

    Private Sub frmEmployee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadEmployee()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        LoadEmployee(txtSearch.Text)
    End Sub

    Private Sub lvEmployee_MouseClick(sender As Object, e As MouseEventArgs) Handles lvEmployee.MouseClick
        If e.Button = MouseButtons.Right Then
            If lvEmployee.Items.Count > 0 Then
                Context_Action.Show(lvEmployee, New Point(e.X, e.Y))
            End If
        End If
    End Sub

    Private Sub lvEmployee_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lvEmployee.MouseDoubleClick
        Modify_Panel.Location = New Point(e.X, e.Y)
        Modify_Panel.Visible = True

        Rate_TXT.Text = lvEmployee.SelectedItems(0).SubItems(3).Text
        Fix_Combo.SelectedItem = lvEmployee.SelectedItems(0).SubItems(4).Text

    End Sub

    Private Sub Close_Modify_BTN_Click(sender As Object, e As EventArgs) Handles Close_Modify_BTN.Click
        Modify_Panel.Visible = False
    End Sub

    Private Sub lvEmployee_Click(sender As Object, e As EventArgs) Handles lvEmployee.Click
        Modify_Panel.Visible = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Check_BTN.Click
        UpdateRateDetails()
    End Sub

    Public Sub UpdateRateDetails()

        Dim idx As Integer = lvEmployee.FocusedItem.Text

        Dim mysql As String = "Select * From tbl_employee Where id = '" & idx & "'"
        Using ds As DataSet = LoadSQL(mysql, "tbl_employee")
            If ds.Tables(0).Rows.Count > 0 Then
                With ds.Tables(0).Rows(0)
                    If Not Rate_TXT.Text = "" Then
                        Modify_Panel.Visible = False
                        .Item("EMP_RATE") = Rate_TXT.Text
                        .Item("FIX_RATE") = Fix_Combo.Text
                        SaveEntry(ds, False)
                        LoadEmployee()
                    Else
                        Rate_TXT.Region = New Region(New Rectangle(2, 2, Rate_TXT.Width - 4, Rate_TXT.Height - 4))
                    End If
                End With
            End If
        End Using

    End Sub

    Private Sub GroupBox1_Paint(sender As Object, e As PaintEventArgs) Handles GroupBox1.Paint
        Dim p As New Pen(Color.Red, 2)
        e.Graphics.DrawRectangle(p, New Rectangle(Rate_TXT.Location + New Size(1, 1), Rate_TXT.Size - New Size(2, 2)))
        p.Dispose()
    End Sub

    Private Sub Rate_TXT_TextChanged(sender As Object, e As EventArgs) Handles Rate_TXT.TextChanged
        If Rate_TXT.Text = "" Then
            Rate_TXT.Region = New Region(New Rectangle(2, 2, Rate_TXT.Width - 4, Rate_TXT.Height - 4))
        Else
            Rate_TXT.Region = Nothing
        End If
    End Sub

    Private Sub Rate_TXT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Rate_TXT.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Check_BTN.PerformClick()
        End If
    End Sub
End Class