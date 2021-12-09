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

    Public Property TIME_IN() As String

    Public Property TIME_OUT() As String
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

    'Public Sub Get_SUM_PAYOUT(BRANCHCODE As String, PAYDATE As String)

    '    Dim mysql As String = $"Select BIO_NO, SUM(TOTAL_BASIC) AS BASIC, SUM(TOTAL_OVERTIME) AS OT FROM  PAYROLL_PAYOUT
    '                                INNER JOIN PAYROLL_EMPLOYEE on BIO_NO = BIOMETRIC_ID 
    '                                WHERE BRANCH_CODE = '{BRANCHCODE}' AND PAYDATE = '{PAYDATE}' GROUP BY BIO_NO"

    '    Dim ds As DataSet = LoadSQL(mysql, "PAYROLL_PAYOUT")
    '    If ds.Tables(0).Rows.Count > 0 Then
    '        For Each DR In ds.Tables(0).Rows
    '            With DR

    '                If IsLastDay(PAYDATE) Then
    '                    Dim monthly_Basic As Double = GetMonthly_Basic(.Item("BIO_NO"), PAYDATE)
    '                    Get_SSS(monthly_Basic)

    '                    SSS_EC += EC
    '                    SSS_ER += ER
    '                    PAGIBIG += Get_Pagibig(monthly_Basic)
    '                    PHILHEALTH += Get_PhilHealth(monthly_Basic)
    '                End If

    '                Basic = .Item("BASIC")
    '                OVERTIME = .Item("OT")

    '            End With
    '        Next
    '    End If
    'End Sub

    'Friend Function Get_SUM(NAMEE As String) As Double
    '    If NAMEE.Contains("Basic") Then
    '        Return Basic
    '    ElseIf NAMEE.Contains("ECC") Then
    '        Return SSS_EC
    '    ElseIf NAMEE.Contains("HDMF") Then
    '        Return PAGIBIG
    '    ElseIf NAMEE.Contains("Phil Health") Then
    '        Return PHILHEALTH
    '    Else
    '        Return 0
    '    End If
    'End Function

    'Public Sub Get_SSS(monthly_Basic As String)

    '    Console.WriteLine("monthly_Basic" & monthly_Basic)

    '    Dim mysql As String = $"Select * FROM PAYROLL_SSS"
    '    Using ds As DataSet = LoadSQL(mysql, "PAYROLL_SSS")
    '        If ds.Tables(0).Rows.Count > 0 Then
    '            For Each dr In ds.Tables(0).Rows
    '                With dr
    '                    Dim range As String = .Item("RANGECOMP")
    '                    Dim strWords As String() = range.Split(New Char() {" "c})

    '                    If strWords(0).Contains("Below") Then
    '                        strWords(0) = 1
    '                    End If

    '                    If (Enumerable.Range(strWords(0), strWords.Last).Contains(monthly_Basic)) Then
    '                        EE = .Item("total_ee")
    '                        ER = .Item("total_er")
    '                        EC = .Item("EC_TOTAL")
    '                        SSS_TOTAL = .Item("TOTAL_TOTAL")
    '                    End If

    '                End With
    '            Next
    '        End If
    '    End Using
    'End Sub


    Friend Sub LoadEmployee_New(ByVal bioNo As Integer)
        Dim mysql As String = "Select * From PAYROLL_EMPLOYEE where BIO_NO = '" & bioNo & "'"
        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_EMPLOYEE")

            If ds.Tables(0).Rows.Count > 0 Then

                Dim dr As DataRow = ds.Tables(0).Rows(0)
                With dr

                    EMP_ID = .Item("id")
                    Company = .Item("Company")
                    BRANCH_CODE = IIf(IsDBNull(.Item("BRANCH_CODE")), "", .Item("BRANCH_CODE"))
                    Fullname = .Item("Fullname")
                    BiometricID = .Item("BIO_NO")
                    EmailAdd = IIf(IsDBNull(.Item("EMAIL_ADD")), "", .Item("EMAIL_ADD"))
                    'FIX = IIf(IsDBNull(.Item("FIX")), "NO", .Item("FIX"))
                    DAILY_RATE = IIf(IsDBNull(.Item("RATE_DAILY")), "", .Item("RATE_DAILY"))
                    MONTHLY_RATE = IIf(IsDBNull(.Item("RATE_MONTHLY")), "", .Item("RATE_MONTHLY"))

                    Dim INN, OUTT As DateTime
                    INN = IIf(IsDBNull(.Item("TIME_IN")), Nothing, .Item("TIME_IN"))
                    OUTT = IIf(IsDBNull(.Item("TIME_OUT")), Nothing, .Item("TIME_OUT"))

                    TIME_IN = IIf(INN = Nothing, "", INN.ToShortTimeString)
                    TIME_OUT = IIf(OUTT = Nothing, "", OUTT.ToShortTimeString)

                End With
            End If
        End Using
    End Sub

    Friend Sub LoadEmployee(ByVal idx As Integer)
        Dim mysql As String = "Select * From PAYROLL_EMPLOYEE where id = '" & idx & "'"
        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_EMPLOYEE")

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
