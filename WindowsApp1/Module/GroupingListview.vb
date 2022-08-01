Module GroupingListview

    Friend ReadOnly isRunningXPOrLater As Boolean = OSFeature.Feature.IsPresent(OSFeature.Themes)
    Friend groupTables() As Hashtable
    Friend groupColumn As Integer = 0

    Private Class ListViewGroupSorter
        Implements IComparer

        Private ReadOnly order As SortOrder

        Public Sub New(theOrder As SortOrder)
            order = theOrder
        End Sub 'New 

        Public Function Compare(x As Object, y As Object) As Integer _
            Implements IComparer.Compare
            Dim result As Integer = String.Compare(
                CType(x, ListViewGroup).Header,
                CType(y, ListViewGroup).Header)
            If order = SortOrder.Ascending Then
                Return result
            Else
                Return -result
            End If
        End Function 'Compare

    End Class

End Module
