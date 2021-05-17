Imports System.IO
Imports FirebirdSql.Data.FirebirdClient
Public Class frmAttendance
    Private Sub frmAttendance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub Button1_MouseEnter(sender As Object, e As EventArgs) Handles Button1.MouseEnter
        Button1.ForeColor = Color.Red
    End Sub

    Private Sub Button1_MouseLeave_1(sender As Object, e As EventArgs) Handles Button1.MouseLeave
        Button1.ForeColor = Color.Black
    End Sub

    Private Sub Close_LBL_Click(sender As Object, e As EventArgs) Handles Close_LBL.Click
        Close()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click

        DataGridView1.Rows.Clear()
        Dim startP As DateTime = From_DTP.Value
        Dim endP As DateTime = To_DTP.Value
        Dim CurrD As DateTime = startP

        While (CurrD <= endP)
            DataGridView1.Rows.Add(CurrD.AddDays(1).ToString("D"))
            CurrD = CurrD.AddDays(1)
        End While

        HourMinute(6, 9, AM_In_DataGrid)

        HourMinute(12, 13, AM_Out_DataGrid)

        HourMinute(12, 13, PM_IN_DataGrid)

        HourMinute(17, 18, PM_Out_DataGrid)

        For i = 0 To DataGridView1.Rows.Count - 1
            Dim r As DataGridViewRow = DataGridView1.Rows(i)
            r.Height = 30

        Next

    End Sub

    Private Sub HourMinute(from_HR As Integer, To_HR As Integer, combo As DataGridViewComboBoxColumn)

        combo.Items.Clear()

        Dim i As Integer
        Dim ii As Integer

        For i = from_HR To To_HR
            For ii = 0 To 59
                Dim ass As String = Format(i, "00")
                Dim asss As String = Format(ii, "00")
                combo.Items.Add((ass & ":" & asss))
            Next
        Next
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckALL_CheckBox.CheckedChanged

        Dim i As Integer = 0
        If CheckALL_CheckBox.Checked = True Then
            For i = 0 To DataGridView1.RowCount - 1
                DataGridView1.Rows(i).Cells(5).Value = True
            Next
        Else
            For i = 0 To DataGridView1.RowCount - 1
                DataGridView1.Rows(i).Cells(5).Value = False
            Next
        End If
    End Sub

    Private Sub DataGridView1_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles DataGridView1.CurrentCellDirtyStateChanged

        If TypeOf DataGridView1.CurrentCell Is DataGridViewCheckBoxCell Then
            DataGridView1.EndEdit()
            Dim Checked As Boolean = CType(DataGridView1.CurrentCell.Value, Boolean)
            If Checked Then
                MessageBox.Show("You have checked")
            Else
                MessageBox.Show("You have un-checked")
            End If
        End If

    End Sub
End Class