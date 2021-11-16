

Partial Class reports
    Partial Public Class ComLeasingDistribDataTable
    End Class

    Partial Public Class NetPayDataTable
        Private Sub NetPayDataTable_ColumnChanging(sender As Object, e As DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.FULLNAMEColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

End Class
