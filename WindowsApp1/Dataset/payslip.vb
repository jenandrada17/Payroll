Partial Class payslip
    Partial Public Class other_deductionDataTable
        Private Sub other_deductionDataTable_other_deductionRowChanging(sender As Object, e As other_deductionRowChangeEvent) Handles Me.other_deductionRowChanging

        End Sub

    End Class

    Partial Public Class attendanceDataTable
        Private Sub attendanceDataTable_ColumnChanging(sender As Object, e As DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.TOTAL_LATE_UTColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

End Class
