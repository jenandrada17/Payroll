Public Class Employee


#Region "Employee Details"
    Public Property EMP_ID() As String

    Public Property BiometricID() As String

    Public Property Fullname() As String

    Public Property FirstName() As String

    Public Property MiddleName() As String

    Public Property LastName() As String

    Public Property Suffix() As String

    Public Property DateStarted() As String

    Public Property NoOfDays() As String

    Public Property EmailAdd() As String

    Public Property Status() As String

    Public Property Position() As String

    Public Property Company() As String

    Public Property BranchName() As String

    Public Property BranchID() As String

    Public Property Rate() As String
#End Region


    Friend Sub LoadEmployee(ByVal idx As Integer)
        Dim mysql As String = "Select * From tbl_Employee where id = '" & idx & "'"
        Using ds As DataSet = LoadSQL(mysql, "tbl_Employee")

            If ds.Tables(0).Rows.Count > 0 Then

                Dim dr As DataRow = ds.Tables(0).Rows(0)
                With dr

                    Dim MI As String

                    If String.IsNullOrEmpty(.Item("MIDDLENAME")) Then
                        MI = ""
                    Else
                        MI = .Item("MIDDLENAME").Substring(0, 1) & "."
                    End If


                    EMP_ID = .Item("id")
                    BiometricID = .Item("BIOMETRICID")
                    Fullname = $"{ .Item("LastName")}, { .Item("FirstName")} {MI}"
                    FirstName = .Item("FIRSTNAME")
                    MiddleName = .Item("MIDDLENAME")
                    LastName = .Item("LASTNAME")
                    Suffix = .Item("SUFFIX")
                    EmailAdd = IIf(IsDBNull(.Item("EMAILADD")), "", .Item("EMAILADD"))
                    Rate = IIf(IsDBNull(.Item("Rate")), "", .Item("Rate"))
                    Status = IIf(IsDBNull(.Item("STATUS")), "", .Item("STATUS"))
                    Position = IIf(IsDBNull(.Item("Emp_Position")), "", .Item("Emp_Position"))
                    BranchID = IIf(IsDBNull(.Item("BRANCH_ID")), "", .Item("BRANCH_ID"))

                End With
            End If
        End Using

        If Not BranchID = Nothing Then
            Dim sql As String = "Select * From TBL_BRANCH  where id = '" & BranchID & "'"
            Using dss As DataSet = LoadSQL(sql, "TBL_BRANCH")

                If dss.Tables(0).Rows.Count > 0 Then
                    Dim drr As DataRow = dss.Tables(0).Rows(0)
                    With drr
                        Company = .Item("COMPANYNAME")
                        BranchName = .Item("BRANCHNAME")
                    End With
                End If

            End Using
        End If

    End Sub

End Class
