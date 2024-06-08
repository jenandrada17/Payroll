Public Class Employee


#Region "Employee Details"
    Public Property EMP_NO() As String
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

    Public Property TIME_IN() As String

    Public Property TIME_OUT() As String

    Public Property ADDRESS() As String

    Public Property BDATE() As String

    Public Property DATE_STARTED() As String

    Public Property SSSNO() As String

    Public Property TINNO() As String
#End Region


#Region "NEW Employee Details"
    Public Property BRANCH_CODE() As String

    Public Property DAILY_RATE() As String

    Public Property MONTHLY_RATE() As String

    Public Property FIX() As String

#End Region

#Region "BENEFITS"

    Public Property EE() As Double = 0

    Public Property ER() As Double = 0

    Public Property EC() As Double = 0

    Public Property SSS_TOTAL() As Double = 0

    Public Property Basic() As Double = 1

    Public Property SSS_EC() As Double = 0

    Public Property SSS_ER() As Double = 0

    Public Property PAGIBIG() As Double = 0

    Public Property PHILHEALTH() As Double = 0

    Public Property OVERTIME() As Double = 0

#End Region
    Friend Sub LoadEmployee_New(ByVal bioNo As Integer)
        Dim mysql As String = "Select A.*, 
                                LASTNAME || ', ' || FIRSTNAME || ' ' || 
                                     CASE 
                                         WHEN MIDDLENAME IS NOT NULL AND MIDDLENAME <> '' THEN LEFT(MIDDLENAME, 1) || '.'
                                         ELSE ''
                                     END AS FULLNAME 
                                From TBL_EMPLOYEE A where BIOMETRICID = '" & bioNo & "'"
        Using ds As DataSet = LoadSQL(mysql, "TBL_EMPLOYEE")

            If ds.Tables(0).Rows.Count > 0 Then

                Dim dr As DataRow = ds.Tables(0).Rows(0)
                With dr

                    EMP_ID = .Item("id")
                    Position = IIf(IsDBNull(.Item("Emp_Position")), "", .Item("Emp_Position"))
                    Company = IIf(IsDBNull(.Item("Company")), "", .Item("Company"))
                    BRANCH_CODE = IIf(IsDBNull(.Item("BRANCHCODE")), "", .Item("BRANCHCODE"))
                    Fullname = .Item("FULLNAME")
                    BiometricID = .Item("BIOMETRICID")
                    EmailAdd = IIf(IsDBNull(.Item("EMAILADD")), "", .Item("EMAILADD"))
                    DAILY_RATE = IIf(IsDBNull(.Item("RATE_DAILY")), "", .Item("RATE_DAILY"))
                    MONTHLY_RATE = IIf(IsDBNull(.Item("RATE_MONTHLY")), "", .Item("RATE_MONTHLY"))

                    Dim INN, OUTT As DateTime
                    INN = IIf(IsDBNull(.Item("TIME_IN")), Nothing, .Item("TIME_IN"))
                    OUTT = IIf(IsDBNull(.Item("TIME_OUT")), Nothing, .Item("TIME_OUT"))

                    TIME_IN = IIf(INN = Nothing, "", INN.ToShortTimeString)
                    TIME_OUT = IIf(OUTT = Nothing, "", OUTT.ToShortTimeString)

                    EMP_NO = IIf(IsDBNull(.Item("EMP_NO")), Nothing, .Item("EMP_NO"))
                    'ADDRESS = IIf(IsDBNull(.Item("ADDRESS")), Nothing, .Item("ADDRESS"))
                    BDATE = IIf(IsDBNull(.Item("DATEOFBIRTH")), Nothing, .Item("DATEOFBIRTH"))
                    DATE_STARTED = IIf(IsDBNull(.Item("DATEHIRED")), Nothing, .Item("DATEHIRED"))
                    SSSNO = IIf(IsDBNull(.Item("SSSNO")), Nothing, .Item("SSSNO"))
                    TINNO = IIf(IsDBNull(.Item("TINNO")), Nothing, .Item("TINNO"))

                End With
            End If
        End Using
    End Sub

    'Friend Sub LoadEmployee(ByVal idx As Integer)
    '    Dim mysql As String = "Select * From PAYROLL_EMPLOYEE where id = '" & idx & "'"
    '    Using ds As DataSet = LoadSQL(mysql, "PAYROLL_EMPLOYEE")

    '        If ds.Tables(0).Rows.Count > 0 Then

    '            Dim dr As DataRow = ds.Tables(0).Rows(0)
    '            With dr

    '                Dim MI As String

    '                If String.IsNullOrEmpty(.Item("MIDDLENAME")) Then
    '                    MI = ""
    '                Else
    '                    MI = .Item("MIDDLENAME").Substring(0, 1) & "."
    '                End If

    '                EMP_ID = .Item("id")
    '                BiometricID = .Item("BIOMETRICID")
    '                Fullname = $"{ .Item("LastName")}, { .Item("FirstName")} {MI}"
    '                FirstName = .Item("FIRSTNAME")
    '                MiddleName = .Item("MIDDLENAME")
    '                LastName = .Item("LASTNAME")
    '                Suffix = .Item("SUFFIX")
    '                EmailAdd = IIf(IsDBNull(.Item("EMAILADD")), "", .Item("EMAILADD"))
    '                Rate = IIf(IsDBNull(.Item("Rate")), "", .Item("Rate"))
    '                Status = IIf(IsDBNull(.Item("STATUS")), "", .Item("STATUS"))
    '                Position = IIf(IsDBNull(.Item("Emp_Position")), "", .Item("Emp_Position"))
    '                BranchID = IIf(IsDBNull(.Item("BRANCH_ID")), "", .Item("BRANCH_ID"))

    '            End With
    '        End If
    '    End Using

    '    If Not BranchID = Nothing Then
    '        Dim sql As String = "Select * From TBL_BRANCH  where id = '" & BranchID & "'"
    '        Using dss As DataSet = LoadSQL(sql, "TBL_BRANCH")

    '            If dss.Tables(0).Rows.Count > 0 Then
    '                Dim drr As DataRow = dss.Tables(0).Rows(0)
    '                With drr
    '                    Company = .Item("COMPANYNAME")
    '                    BranchName = .Item("BRANCHNAME")
    '                End With
    '            End If

    '        End Using
    '    End If

    'End Sub

End Class
