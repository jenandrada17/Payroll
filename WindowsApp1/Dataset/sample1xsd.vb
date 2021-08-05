Partial Class sample1xsd
    Partial Public Class thisSampleDataTable
        Private Sub thisSampleDataTable_ColumnChanging(sender As Object, e As DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.LASTNAMEColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class
End Class
