Imports System.Configuration
Imports FirebirdSql.Data.FirebirdClient

Module Database

    Public con As FbConnection
    Public ReaderCon As FbConnection
    Private reader As FbDataReader = Nothing
    Friend fbDataSet As New DataSet
    Friend conStr As String = String.Empty
    Dim scr_val As Integer

    Private language() As String =
        {"Connection error failed."} 'verification if the database is connected.

    'Friend Function LoadSQL(ByVal mySql As String, Optional ByVal tblName As String = "QuickSQL") As DataSet
    '    Dim da As FbDataAdapter
    '    Dim ds As New DataSet, fillData As String = tblName
    '    Try
    '        DbOpen() 'open the database.

    '        Try
    '            da = New FbDataAdapter(mySql, con)
    '            da.Fill(ds, fillData)
    '        Catch ex As Exception

    '            MsgBox(ex.ToString)

    '        End Try

    '        DbClose()

    '        Return ds
    '    Catch ex As FbException
    '        Console.WriteLine(">>>>>" & mySql)
    '        MessageBox.Show($"[{ex.ErrorCode.ToString}] - {ex.Message}", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        'Log_Report("LoadSQL - " & ex.ToString)
    '        ds = Nothing
    '        Return ds
    '    End Try
    'End Function

    Friend Function LoadSQL(ByVal mySql As String, Optional ByVal tblName As String = "QuickSQL") As DataSet
        Dim ds As New DataSet()
        Dim conStr As String = ConfigurationManager.ConnectionStrings("FbConString").ConnectionString

        Try
            Using con As New FbConnection(conStr)
                con.Open()
                Using da As New FbDataAdapter(mySql, con)
                    da.Fill(ds, tblName)
                End Using
            End Using
        Catch ex As FbException
            Console.WriteLine("Firebird SQL Error: " & ex.Message)
            MessageBox.Show($"[{ex.ErrorCode}] - {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ds = Nothing
        Catch ex As Exception
            Console.WriteLine("General Error: " & ex.Message)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ds = Nothing
        End Try

        Return ds
    End Function

    'Public Sub DbClose()
    '    con.Close()
    'End Sub

    'Public Sub DbOpen()
    '    conStr = ConfigurationManager.ConnectionStrings("FbConString").ConnectionString.ToString

    '    Try
    '        con = New FbConnection(conStr)
    '        con.Open()
    '    Catch ex As FbException
    '        MsgBox(language(0) & ex.ErrorCode & vbCrLf & ex.Message.ToString, vbCritical, "Connecting Error")
    '        con.Dispose()
    '        Exit Sub
    '    Catch ex As Exception
    '        MsgBox(language(0) & ex.HResult & vbCrLf & ex.Message.ToString, vbCritical, "Connecting Error")
    '        con.Dispose()
    '        Exit Sub
    '    End Try
    'End Sub

    'Friend Function SaveEntry(ByVal dsEntry As DataSet, Optional ByVal isNew As Boolean = True) As Boolean
    '    Try
    '        If dsEntry Is Nothing Then Return False

    '        DbOpen()

    '        Dim da As FbDataAdapter
    '        Dim mySql As String, fillData As String
    '        Dim ds As DataSet = dsEntry

    '        For Each dsTable As DataTable In dsEntry.Tables
    '            fillData = dsTable.TableName
    '            mySql = "SELECT * FROM " & fillData
    '            If Not isNew Then
    '                Dim colName As String = dsTable.Columns(0).ColumnName
    '                Dim idx As Integer = dsTable.Rows(0).Item(0)
    '                mySql &= String.Format(" WHERE {0} = {1}", colName, idx)
    '            End If

    '            da = New FbDataAdapter(mySql, con)
    '            Dim cb As New FbCommandBuilder(da)
    '            cb.ConflictOption = ConflictOption.CompareRowVersion
    '            da.Update(ds, fillData)
    '        Next

    '        DbClose()
    '        Return True
    '    Catch ex As FbException
    '        MessageBox.Show($"[{ex.ErrorCode.ToString}] - {ex.Message}", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        Return False
    '    End Try
    'End Function

    Friend Function SaveEntry(ByVal dsEntry As DataSet, Optional ByVal isNew As Boolean = True) As Boolean
        If dsEntry Is Nothing Then Return False

        Dim conStr As String = ConfigurationManager.ConnectionStrings("FbConString").ConnectionString

        Try
            Using con As New FbConnection(conStr)
                con.Open()

                For Each dsTable As DataTable In dsEntry.Tables
                    Dim fillData As String = dsTable.TableName
                    Dim mySql As String = "SELECT * FROM " & fillData

                    If Not isNew Then
                        Dim colName As String = dsTable.Columns(0).ColumnName
                        Dim idx As Object = dsTable.Rows(0).Item(0)
                        mySql &= String.Format(" WHERE {0} = {1}", colName, idx)
                    End If

                    Using da As New FbDataAdapter(mySql, con)
                        Using cb As New FbCommandBuilder(da)
                            cb.ConflictOption = ConflictOption.CompareRowVersion
                            da.Update(dsEntry, fillData)
                        End Using
                    End Using
                Next
            End Using

            Return True

        Catch ex As FbException
            MessageBox.Show($"[{ex.ErrorCode}] - {ex.Message}", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function


    Friend Function LoadSQL_byDataReader(ByVal mySql As String) As FbDataReader
        DbReaderOpen()
        Dim myCom As FbCommand = New FbCommand(mySql, con)
        Try
            reader = myCom.ExecuteReader()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            FbConnection.ClearPool(con)
        Finally
            FbConnection.ClearPool(con)
        End Try
        Return reader
    End Function

    Public Sub DbReaderOpen()

        conStr = ConfigurationManager.ConnectionStrings("FbConString").ConnectionString.ToString

        con = New FbConnection(conStr)
        Try
            If con.State = ConnectionState.Open Then
                con.Close()
            ElseIf con.State = ConnectionState.Closed Then
                con.Open() 'open the database.
            End If
        Catch ex As Exception
            con.Dispose()
            MsgBox(language(0) + vbCrLf + ex.Message.ToString, vbCritical, "Connecting Error")
            'Log_Report(ex.Message.ToString)
            Exit Sub
        End Try
    End Sub

    Public Sub RunCommand(ByVal sql As String)

        conStr = ConfigurationManager.ConnectionStrings("FbConString").ConnectionString.ToString

        con = New FbConnection(conStr)

        Dim cmd As FbCommand = New FbCommand(sql, con)

        Try
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
            'Log_Report(String.Format("[{0}] - ", sql) & ex.ToString)
            con.Dispose()
            Exit Sub
        End Try

    End Sub

End Module
