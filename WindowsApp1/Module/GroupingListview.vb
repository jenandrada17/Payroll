Module GroupingListview

    Friend ReadOnly isRunningXPOrLater As Boolean = OSFeature.Feature.IsPresent(OSFeature.Themes)
    Friend groupTables() As Hashtable
    Friend groupColumn As Integer = 0

    Friend Sub ListViewGrouping(listView As ListView, Optional col As Integer = 0)
        If isRunningXPOrLater Then
            groupTables = New Hashtable(listView.Columns.Count) {}
            Dim column As Integer
            For column = 0 To listView.Columns.Count - 1
                groupTables(column) = CreateGroupsTable(column, listView)
            Next column

            SetGroups(col, listView)
        End If
    End Sub

    Friend Function CreateGroupsTable(column As Integer, listView As ListView) As Hashtable

        Dim groups As New Hashtable()
        Try
            Dim item As ListViewItem
            For Each item In listView.Items
                Dim subItemText As String = item.SubItems(column).Text
                If column = 0 Then
                    subItemText = subItemText.Substring(0, 1)
                End If

                If Not groups.Contains(subItemText) Then
                    groups.Add(subItemText, New ListViewGroup(subItemText,
                        HorizontalAlignment.Left))
                End If
            Next item

            Return groups
        Catch ex As Exception
            Log_Report(ex.ToString())
            Return groups
        End Try

    End Function

    Friend Sub SetGroups(column As Integer, listView As ListView)
        Try
            listView.Groups.Clear()
            Dim groups As Hashtable = groupTables(column)

            Dim groupsArray(groups.Count - 1) As ListViewGroup
            groups.Values.CopyTo(groupsArray, 0)

            Array.Sort(groupsArray, New ListViewGroupSorter(listView.Sorting))
            listView.Groups.AddRange(groupsArray)

            Dim item As ListViewItem
            For Each item In listView.Items
                Dim subItemText As String = item.SubItems(column).Text

                If column = 0 Then
                    subItemText = subItemText.Substring(0, 1)
                End If

                item.Group = CType(groups(subItemText), ListViewGroup)
            Next item
        Catch ex As Exception
            Log_Report(ex.ToString)
        End Try

    End Sub

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
