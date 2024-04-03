Imports System.Globalization

Module Report_function

    Friend Function LoadDataTable_GensanJR(paydate As String) As DataTable

        Dim mysql As String
        Dim PAYROLL As DateTime = paydate
        Dim info As TextInfo = CultureInfo.InvariantCulture.TextInfo ' === TITLE CASE ADDRESS
        Dim total_email As Decimal = 0

        Dim dt_PhotoGensanJR As New DataTable()
        With dt_PhotoGensanJR
            .Columns.Add("PAYDATE")
            .Columns.Add("COMPANY")
            .Columns.Add("ADDRESS")
            .Columns.Add("EMAIL_GENSANJR")
            .Columns.Add("WD")
            .Columns.Add("DEP")
            .Columns.Add("TOTAL_AMOUNT")
        End With

        mysql = $"Select A.*, B.*, C.*, C.ADDRESS as ADDRESS_  From PAYROLL_PAYOUT A  
                                        INNER JOIN TBL_EMPLOYEE C ON BIOMETRICID = BIOMETRIC_ID    
                                        LEFT JOIN PAYROLL_CITY_BRANCH B ON B.BRANCHCODE = C.BRANCHCODE
                                        WHERE (B.BRANCHCODE IN ('DIG','ISU','M1','POL', 'ROG','ROX','FINEPIX','COT','MID','KID','SNP','GMA','SML','ZAM','SMD')
                                                AND  PAYDATE = '{paydate}' AND COMPANY = 'PHOTO') OR (HO_CATEGORY LIKE 'Photo%' AND  PAYDATE = '{paydate}')
                                        ORDER BY CASE WHEN UPPER(HO_CATEGORY) LIKE UPPER('%Admin%') THEN 0  
                                                WHEN UPPER(C.ADDRESS) LIKE UPPER('GENSAN') THEN 1 
                                                WHEN UPPER(C.ADDRESS) LIKE UPPER('POLOMOLOK') THEN 2 
                                                WHEN UPPER(C.ADDRESS) LIKE UPPER('MARBEL') THEN 3 
                                                WHEN UPPER(C.ADDRESS) LIKE UPPER('ISULAN') THEN 4 
                                                WHEN UPPER(C.ADDRESS) LIKE UPPER('COTABATO') THEN 5 
                                                WHEN UPPER(C.ADDRESS) LIKE UPPER('KIDAPAWAN') THEN 6 
                                                WHEN UPPER(C.ADDRESS) LIKE UPPER('MIDSAYAP') THEN 7 
                                                WHEN UPPER(C.ADDRESS) LIKE UPPER('DAVAO') THEN 8 
                                                WHEN UPPER(C.ADDRESS) LIKE UPPER('SM SAN LAZARO') THEN 9 
                                                WHEN UPPER(C.ADDRESS) LIKE UPPER('ZAMBOANGA') THEN 10  
                                                END"

        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_PAYOUT")
            If ds.Tables(0).Rows.Count > 0 Then

                progressBarStart(ds.Tables(0).Rows.Count)
                For Each dr In ds.Tables(0).Rows
                    With dr

                        '============================= NAME AND ATTENDANCE ============================  
                        Dim COMPANY As String = "PHOTO"
                        Dim ADDRESS As String = IIf(IsDBNull(.Item("ADDRESS_")), "", .Item("ADDRESS_"))
                        Dim CATEGORY As String = IIf(IsDBNull(.Item("CATEGORY")), "", .Item("CATEGORY"))
                        Dim BRANCHCODE As String = IIf(IsDBNull(.Item("BRANCHCODE")), "", .Item("BRANCHCODE"))
                        Dim HO_CATEGORY As String = IIf(IsDBNull(.Item("HO_CATEGORY")), "", .Item("HO_CATEGORY"))
                        Dim EMAIL As Decimal

                        Dim BRANCH_LIST As String = GetList_Branch(ADDRESS, "CATEGORY In ('GENSAN PERFECT', 'JR PHOTO')")

                        If BRANCH_LIST <> Nothing Then
                            EMAIL = GetSummary_Email(PAYROLL, $" BRANCH_CODE In ({BRANCH_LIST}) AND COMPANY = '{COMPANY}'")
                        Else
                            EMAIL = GetSummary_Email(PAYROLL, $"BRANCH_CODE = '{BRANCHCODE}'")
                        End If

                        Dim HO_array As String() = HO_CATEGORY.TrimEnd.Split(New Char() {" "c}) '=== ADMIN   
                        ADDRESS = ADDRESS.ToLower()

                        If HO_CATEGORY.Contains("Photo") Then
                            ADDRESS = $"Admin {HO_array.Last}"
                            EMAIL = GetSummary_Email(PAYROLL, $"HO_CATEGORY = '{HO_CATEGORY}'")
                        End If

                        COMPANY = "PHOTO(GENSAN PERFECT/JR PHOTO)"

                        dt_PhotoGensanJR.Rows.Add(PAYROLL.ToString("MMMM dd, yyyy").ToUpper(), COMPANY,
                                                  info.ToTitleCase(ADDRESS), EMAIL.ToString("n"), 0, 0, 0)

                        frmMainForm.AppProgressBar.Value += 1
                    End With
                Next
                progressBarEnd()
            End If
        End Using

        Return dt_PhotoGensanJR
    End Function

    Friend Function LoadDataTable_DavaoPerfect(paydate As String) As DataTable

        Dim mysql As String
        Dim PAYROLL As DateTime = paydate
        Dim info As TextInfo = CultureInfo.InvariantCulture.TextInfo ' === TITLE CASE ADDRESS
        Dim total_email As Decimal = 0
        Dim COMPANY As String = "PHOTO"

        Dim dt_PhotoDavao As New DataTable()
        With dt_PhotoDavao
            .Columns.Add("PAYDATE")
            .Columns.Add("COMPANY")
            .Columns.Add("ADDRESS")
            .Columns.Add("EMAIL")
            .Columns.Add("WD")
            .Columns.Add("DEP")
            .Columns.Add("TOTAL_AMOUNT")
        End With

        mysql = $"Select A.*, B.*, C.*, C.ADDRESS as ADDRESS_ From PAYROLL_PAYOUT A  
                                        INNER JOIN TBL_EMPLOYEE C ON C.BIOMETRICID = BIOMETRIC_ID    
                                        LEFT JOIN PAYROLL_CITY_BRANCH B ON B.BRANCHCODE = C.BIOMETRICID    
                                        WHERE PAYDATE = '{paydate}'  AND COMPANY = 'PHOTO'
                                            AND BRANCHCODE IN ('SMG','KCG','ACM','TAC')  
                                        ORDER BY CASE WHEN C.ADDRESS = 'GENSAN' THEN 0  
                                                WHEN C.ADDRESS = 'MARBEL' THEN 1    
                                                else 2 END"

        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_PAYOUT")
            If ds.Tables(0).Rows.Count > 0 Then

                progressBarStart(ds.Tables(0).Rows.Count)
                For Each dr In ds.Tables(0).Rows
                    With dr

                        '============================= NAME AND ATTENDANCE ============================  
                        Dim ADDRESS As String = IIf(IsDBNull(.Item("ADDRESS_")), "", .Item("ADDRESS_"))
                        Dim CATEGORY As String = IIf(IsDBNull(.Item("CATEGORY")), "", .Item("CATEGORY"))
                        Dim BRANCHCODE As String = IIf(IsDBNull(.Item("BRANCHCODE")), "", .Item("BRANCHCODE"))
                        Dim HO_CATEGORY As String = IIf(IsDBNull(.Item("HO_CATEGORY")), "", .Item("HO_CATEGORY"))
                        Dim EMAIL As Decimal

                        Dim BRANCH_LIST As String = GetList_Branch(ADDRESS, "CATEGORY = 'DAVAO PERFECT'")

                        If BRANCH_LIST <> Nothing Then
                            EMAIL = GetSummary_Email(PAYROLL, $" BRANCH_CODE In ({BRANCH_LIST}) AND COMPANY = '{COMPANY}'")
                        Else
                            EMAIL = GetSummary_Email(PAYROLL, $"BRANCH_CODE = '{BRANCHCODE}'")
                        End If

                        Dim HO_array As String() = HO_CATEGORY.Split(New Char() {" "c}) '=== ADMIN    
                        ADDRESS = ADDRESS.ToLower()

                        COMPANY = $"PHOTO(DAVAO PERFECT)"

                        dt_PhotoDavao.Rows.Add(PAYROLL.ToString("MMMM dd, yyyy").ToUpper(), COMPANY,
                                               info.ToTitleCase(ADDRESS), EMAIL.ToString("n"), 0, 0, 0)

                        frmMainForm.AppProgressBar.Value += 1
                    End With
                Next
                progressBarEnd()
            End If
        End Using

        Return dt_PhotoDavao
    End Function

    Friend Function LoadDataTable_Dalton(paydate As String) As DataTable

        Dim mysql As String
        Dim PAYROLL As DateTime = paydate
        Dim info As TextInfo = CultureInfo.InvariantCulture.TextInfo ' === TITLE CASE ADDRESS
        Dim total_email As Decimal = 0

        Dim dt_Dalton As New DataTable()
        With dt_Dalton
            .Columns.Add("PAYDATE")
            .Columns.Add("COMPANY")
            .Columns.Add("ADDRESS")
            .Columns.Add("EMAIL")
            .Columns.Add("WD")
            .Columns.Add("DEP")
            .Columns.Add("TOTAL_AMOUNT")
        End With

        mysql = $"Select A.*, B.*, C.*, C.ADDRESS as ADDRESS_  From PAYROLL_PAYOUT A  
                                        INNER JOIN TBL_EMPLOYEE C ON BIOMETRICID = BIOMETRIC_ID    
                                        LEFT JOIN PAYROLL_CITY_BRANCH B ON B.BRANCHCODE = C.BRANCHCODE    
                                        WHERE PAYDATE = '{paydate}' AND COMPANY  = 'DALTON'
                                            OR  (HO_CATEGORY LIKE 'Dalton%' AND PAYDATE = '{paydate}' )
                                        ORDER BY CASE WHEN UPPER(HO_CATEGORY) LIKE UPPER('%Admin%') THEN 0 
                                                WHEN UPPER(HO_CATEGORY) LIKE UPPER('%Retail%') THEN 1 
                                                WHEN UPPER(C.ADDRESS) LIKE UPPER('GENSAN') THEN 2  
                                                WHEN UPPER(C.ADDRESS) LIKE UPPER('POLOMOLOK') THEN 3 
                                                WHEN UPPER(C.ADDRESS) LIKE UPPER('MARBEL') THEN 4 
                                                WHEN UPPER(C.ADDRESS) LIKE UPPER('ISULAN') THEN 5 
                                                WHEN UPPER(C.ADDRESS) LIKE UPPER('TACURONG') THEN 6 
                                                WHEN UPPER(C.ADDRESS) LIKE UPPER('SURALLAH') THEN 7 
                                                WHEN UPPER(C.ADDRESS) LIKE UPPER('BANGA') THEN 8 
                                                WHEN UPPER(C.ADDRESS) LIKE UPPER('TBOLI') THEN 9 
                                                WHEN UPPER(C.ADDRESS) LIKE UPPER('ESPERANZA') THEN 10 
                                                WHEN UPPER(C.ADDRESS) LIKE UPPER('KALAMANSIG') THEN 11  
                                                WHEN UPPER(C.ADDRESS) LIKE UPPER('LAMBAYONG') THEN 12  
                                                WHEN UPPER(C.ADDRESS) LIKE UPPER('LEBAK') THEN 13  
                                                WHEN UPPER(C.ADDRESS) LIKE UPPER('AWANG') THEN 14  
                                                WHEN UPPER(C.ADDRESS) LIKE UPPER('DALICAN') THEN 15  
                                                WHEN UPPER(C.ADDRESS) LIKE UPPER('COTABATO') THEN 16  
                                                WHEN UPPER(C.ADDRESS) LIKE UPPER('KIDAPAWAN') THEN 17  
                                                WHEN UPPER(C.ADDRESS) LIKE UPPER('KIDAPAWAN') THEN 18   
                                                WHEN UPPER(C.ADDRESS) LIKE UPPER('MIDSAYAP') THEN 19 
                                                WHEN UPPER(C.ADDRESS) LIKE UPPER('KABACAN') THEN 20 
                                                WHEN UPPER(C.ADDRESS) LIKE UPPER('PIKIT') THEN 21 
                                                WHEN UPPER(C.ADDRESS) LIKE UPPER('MLANG') THEN 22 
                                                WHEN UPPER(C.ADDRESS) LIKE UPPER('TULUNAN') THEN 23 
                                                WHEN UPPER(C.ADDRESS) LIKE UPPER('PARANG') THEN 24 
                                                WHEN UPPER(C.ADDRESS) LIKE UPPER('BULUAN') THEN 25 
                                                WHEN UPPER(C.ADDRESS) LIKE UPPER('UPI') THEN 26 
                                                WHEN UPPER(C.ADDRESS) LIKE UPPER('SHARIFF') THEN 27 
                                                WHEN UPPER(C.ADDRESS) LIKE UPPER('DAVAO') THEN 28 
                                                WHEN UPPER(C.ADDRESS) LIKE UPPER('SARANGANI') THEN 29 
                                                WHEN UPPER(C.ADDRESS) LIKE UPPER('SURIGAO') THEN 30 
                                                WHEN UPPER(C.ADDRESS) LIKE UPPER('BUTUAN') THEN 31  
                                                WHEN UPPER(C.ADDRESS) LIKE UPPER('CAGAYAN') THEN 32  
                                                ELSE 33 END"

        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_PAYOUT")
            If ds.Tables(0).Rows.Count > 0 Then

                progressBarStart(ds.Tables(0).Rows.Count)
                For Each dr In ds.Tables(0).Rows
                    With dr

                        '============================= NAME AND ATTENDANCE ============================  
                        Dim COMPANY As String = "DALTON"
                        Dim ADDRESS As String = IIf(IsDBNull(.Item("ADDRESS_")), "", .Item("ADDRESS_"))
                        Dim CATEGORY As String = IIf(IsDBNull(.Item("CATEGORY")), "", .Item("CATEGORY"))
                        Dim BRANCHCODE As String = IIf(IsDBNull(.Item("BRANCHCODE")), "", .Item("BRANCHCODE"))
                        Dim HO_CATEGORY As String = IIf(IsDBNull(.Item("HO_CATEGORY")), "", .Item("HO_CATEGORY"))
                        Dim EMAIL As Decimal

                        Dim BRANCH_LIST As String = GetList_Branch(ADDRESS, $"COMPANY = '{COMPANY}'")

                        If BRANCH_LIST <> Nothing Then
                            EMAIL = GetSummary_Email(PAYROLL, $"BRANCH_CODE In ({BRANCH_LIST}) AND COMPANY = '{COMPANY}' AND C.ADDRESS = '{ADDRESS}'")
                        Else
                            EMAIL = GetSummary_Email(PAYROLL, $"BRANCH_CODE = '{BRANCHCODE}'")
                        End If

                        Dim HO_array As String() = HO_CATEGORY.Split(New Char() {" "c}) '=== ADMIN   
                        ADDRESS = ADDRESS.ToLower()

                        If HO_CATEGORY.Contains("Dalton") Then
                            ADDRESS = $"Admin {HO_array.Last}"
                            EMAIL = GetSummary_Email(PAYROLL, $"HO_CATEGORY = '{HO_CATEGORY}'")
                        End If

                        COMPANY = "DALTON"

                        dt_Dalton.Rows.Add(PAYROLL.ToString("MMMM dd, yyyy").ToUpper(), COMPANY,
                                               info.ToTitleCase(ADDRESS), EMAIL.ToString("n"), 0, 0, 0)

                        frmMainForm.AppProgressBar.Value += 1
                    End With
                Next
                progressBarEnd()
            End If
        End Using

        Return dt_Dalton
    End Function

    Friend Function LoadDataTable_Perfecom(paydate As String) As DataTable

        Dim mysql As String
        Dim PAYROLL As DateTime = paydate
        Dim info As TextInfo = CultureInfo.InvariantCulture.TextInfo ' === TITLE CASE ADDRESS
        Dim total_email As Decimal = 0

        Dim dt_Dalton As New DataTable()
        With dt_Dalton
            .Columns.Add("PAYDATE")
            .Columns.Add("COMPANY")
            .Columns.Add("ADDRESS")
            .Columns.Add("EMAIL")
            .Columns.Add("WD")
            .Columns.Add("DEP")
            .Columns.Add("TOTAL_AMOUNT")
        End With

        mysql = $"Select  A.*, B.*, C.*, C.ADDRESS as ADDRESS_ From PAYROLL_PAYOUT A  
                                        INNER JOIN TBL_EMPLOYEE C ON BIOMETRICID = BIOMETRIC_ID    
                                        LEFT JOIN PAYROLL_CITY_BRANCH B ON B.BRANCHCODE = C.BRANCHCODE    
                                        WHERE PAYDATE = '{paydate}' AND COMPANY  = 'PERFECOM'
                                            OR (HO_CATEGORY LIKE 'Perfecom%' AND  PAYDATE = '{paydate}')
                                        ORDER BY CASE WHEN UPPER(HO_CATEGORY) LIKE UPPER('%Admin%') THEN 0  
                                                WHEN UPPER(C.ADDRESS) LIKE UPPER('GENSAN') THEN 1   
                                                WHEN UPPER(C.ADDRESS) LIKE UPPER('MARBEL') THEN 2 
                                                WHEN UPPER(C.ADDRESS) LIKE UPPER('ZAMBOANGA') THEN 3 END"

        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_PAYOUT")
            If ds.Tables(0).Rows.Count > 0 Then

                progressBarStart(ds.Tables(0).Rows.Count)
                For Each dr In ds.Tables(0).Rows
                    With dr

                        '============================= NAME AND ATTENDANCE ============================  
                        Dim COMPANY As String = "PERFECOM"
                        Dim ADDRESS As String = IIf(IsDBNull(.Item("ADDRESS_")), "", .Item("ADDRESS_"))
                        Dim CATEGORY As String = IIf(IsDBNull(.Item("CATEGORY")), "", .Item("CATEGORY"))
                        Dim BRANCHCODE As String = IIf(IsDBNull(.Item("BRANCHCODE")), "", .Item("BRANCHCODE"))
                        Dim HO_CATEGORY As String = IIf(IsDBNull(.Item("HO_CATEGORY")), "", .Item("HO_CATEGORY"))
                        Dim EMAIL As Decimal

                        Dim BRANCH_LIST As String = GetList_Branch(ADDRESS, $"COMPANY = '{COMPANY}'")

                        If BRANCH_LIST <> Nothing Then
                            EMAIL = GetSummary_Email(PAYROLL, $"BRANCH_CODE In ({BRANCH_LIST}) AND COMPANY = '{COMPANY}' AND C.ADDRESS = '{ADDRESS}'")
                        Else
                            EMAIL = GetSummary_Email(PAYROLL, $"BRANCH_CODE = '{BRANCHCODE}'")
                        End If

                        Dim HO_array As String() = HO_CATEGORY.Split(New Char() {" "c}) '=== ADMIN   
                        ADDRESS = ADDRESS.ToLower()

                        If HO_CATEGORY.Contains("Perfecom") Then
                            ADDRESS = $"Admin {HO_array.Last}"
                            EMAIL = GetSummary_Email(PAYROLL, $"HO_CATEGORY = '{HO_CATEGORY}'")
                        End If

                        dt_Dalton.Rows.Add(PAYROLL.ToString("MMMM dd, yyyy").ToUpper(), COMPANY,
                                               info.ToTitleCase(ADDRESS), EMAIL.ToString("n"), 0, 0, 0)

                        frmMainForm.AppProgressBar.Value += 1
                    End With
                Next
                progressBarEnd()
            End If
        End Using

        Return dt_Dalton
    End Function

    Friend Function LoadDataTable_PG_UY(paydate As String) As DataTable

        Dim mysql As String
        Dim PAYROLL As DateTime = paydate
        Dim info As TextInfo = CultureInfo.InvariantCulture.TextInfo ' === TITLE CASE ADDRESS
        Dim total_email As Decimal = 0

        Dim dt_Dalton As New DataTable()
        With dt_Dalton
            .Columns.Add("PAYDATE")
            .Columns.Add("COMPANY")
            .Columns.Add("ADDRESS")
            .Columns.Add("EMAIL")
            .Columns.Add("WD")
            .Columns.Add("DEP")
            .Columns.Add("TOTAL_AMOUNT")
        End With

        mysql = $"Select A.*, B.*, C.*, C.ADDRESS as ADDRESS_ From PAYROLL_PAYOUT A  
                                        INNER JOIN TBL_EMPLOYEE C ON BIOMETRICID = BIOMETRIC_ID     
                                        LEFT JOIN PAYROLL_CITY_BRANCH B ON B.BRANCHCODE = C.BRANCHCODE      
                                        WHERE PAYDATE = '{paydate}' AND COMPANY  = 'P&G UY'
                                            OR (HO_CATEGORY LIKE 'GHS/P&G UY%' AND PAYDATE = '{paydate}')
                                        ORDER BY CASE WHEN UPPER(HO_CATEGORY) LIKE UPPER('%Admin%') THEN 0  
                                                WHEN BRANCH_CODE = '3G' THEN 1    
                                                WHEN BRANCH_CODE = 'COMI' THEN 3 
                                                WHEN BRANCH_CODE = 'KTV' THEN 4 
                                                WHEN BRANCH_CODE = 'PBA' THEN 5 
                                                WHEN BRANCH_CODE = 'WAVE' THEN 6 
                                                else 2 END"

        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_PAYOUT")
            If ds.Tables(0).Rows.Count > 0 Then

                progressBarStart(ds.Tables(0).Rows.Count)
                For Each dr In ds.Tables(0).Rows
                    With dr

                        '============================= NAME AND ATTENDANCE ============================  
                        Dim COMPANY As String = "P&G UY"
                        Dim ADDRESS As String = IIf(IsDBNull(.Item("ADDRESS_")), "", .Item("ADDRESS_"))
                        Dim BRANCHCODE As String = IIf(IsDBNull(.Item("BRANCH_CODE")), "", .Item("BRANCH_CODE"))
                        Dim HO_CATEGORY As String = IIf(IsDBNull(.Item("HO_CATEGORY")), "", .Item("HO_CATEGORY"))
                        Dim EMAIL As Decimal = GetSummary_Email(PAYROLL, $"BRANCH_CODE = '{BRANCHCODE}'")
                        Dim HO_array As String() = HO_CATEGORY.Split(New Char() {" "c}) '=== ADMIN   
                        ADDRESS = HO_CATEGORY.ToLower()

                        If HO_CATEGORY.Contains("GHS") Then
                            ADDRESS = HO_CATEGORY
                            EMAIL = GetSummary_Email(PAYROLL, $"HO_CATEGORY = '{HO_CATEGORY}'")
                        End If

                        If Not HO_CATEGORY.Contains("PGC") And Not HO_CATEGORY.Contains("GHS") Then
                            ADDRESS = IIf(IsDBNull(.Item("BRANCHNAME")), "", .Item("BRANCHNAME"))

                            If BRANCHCODE = "711-ROX" Or BRANCHCODE = "711-POL" Then
                                EMAIL = GetSummary_Email(PAYROLL, $"(BRANCH_CODE = '711-ROX' Or BRANCH_CODE = '711-POL') ")
                                ADDRESS = "7 Eleven"
                            End If

                        End If

                        COMPANY = "P & G UY SONS/GHS"

                        dt_Dalton.Rows.Add(PAYROLL.ToString("MMMM dd, yyyy").ToUpper(), COMPANY,
                                               info.ToTitleCase(ADDRESS), EMAIL.ToString("n"), 0, 0, 0)

                        frmMainForm.AppProgressBar.Value += 1
                    End With
                Next
                progressBarEnd()
            End If
        End Using

        Return dt_Dalton
    End Function

    Friend Function LoadDataTable_Household(paydate As String) As DataTable

        Dim PAYROLL As DateTime = paydate
        Dim info As TextInfo = CultureInfo.InvariantCulture.TextInfo ' === TITLE CASE ADDRESS
        Dim total_email As Decimal = 0

        Dim dt_Dalton As New DataTable()
        With dt_Dalton
            .Columns.Add("PAYDATE")
            .Columns.Add("COMPANY")
            .Columns.Add("ADDRESS")
            .Columns.Add("EMAIL")
            .Columns.Add("WD")
            .Columns.Add("DEP")
            .Columns.Add("TOTAL_AMOUNT")
        End With

        Dim TOTALS As Decimal = 0
        Dim NET_PAY As Decimal = 0

        Dim mysqll As String = $"Select * From TBL_EMPLOYEE A  
                                        INNER JOIN PAYROLL_PAYOUT C ON A.BIOMETRICID = C.BIOMETRIC_ID
                                        where BIOMETRICID = '2788' AND PAYDATE = '{paydate}'"

        Using ds As DataSet = LoadSQL(mysqll, "TBL_EMPLOYEE")
            If ds.Tables(0).Rows.Count > 0 Then
                For Each dr In ds.Tables(0).Rows
                    With dr

                        '============================= NAME AND ATTENDANCE ============================  
                        NET_PAY = .Item("NET_PAY")
                        TOTALS = NET_PAY * 0.5
                    End With
                Next

                Dim COMPANY As String = "HOUSEHOLD"
                Dim ADDRESS As String = "PGC/GENSAN"

                dt_Dalton.Rows.Add(PAYROLL.ToString("MMMM dd, yyyy").ToUpper(), COMPANY,
                                                       info.ToTitleCase(ADDRESS), TOTALS.ToString("n"), 0, 0, 0)

            End If
        End Using

        Return dt_Dalton
    End Function

    Friend Function LoadDataTable_Realty(paydate As String) As DataTable

        Dim PAYROLL As DateTime = paydate
        Dim info As TextInfo = CultureInfo.InvariantCulture.TextInfo ' === TITLE CASE ADDRESS
        Dim total_email As Decimal = 0

        Dim dt_Dalton As New DataTable()
        With dt_Dalton
            .Columns.Add("PAYDATE")
            .Columns.Add("COMPANY")
            .Columns.Add("ADDRESS")
            .Columns.Add("EMAIL")
            .Columns.Add("WD")
            .Columns.Add("DEP")
            .Columns.Add("TOTAL_AMOUNT")
        End With

        Dim TOTALS As Decimal = 0

        Dim mysqll As String = $"Select A.*, B.*, C.*, 
                                        LASTNAME || ', ' || FIRSTNAME || ' ' || 
                                             CASE 
                                                 WHEN MIDDLENAME IS NOT NULL AND MIDDLENAME <> '' THEN LEFT(MIDDLENAME, 1) || '.'
                                                 ELSE ''
                                             END AS FULLNAME
                                        From TBL_EMPLOYEE A 
                                        INNER JOIN PAYROLL_PERCENTAGEE B ON B.CATEGORY = A.COMMON_CATEGORY
                                        INNER JOIN PAYROLL_PAYOUT C ON A.BIOMETRICID = C.BIOMETRIC_ID
                                        where PAYDATE = '{paydate}' AND HO_CATEGORY = 'PGC Head Office' OR (HO_CATEGORY IN ('Construction', 'Leasing Admin Office') AND PAYDATE = '{paydate}')
                                          ORDER BY FULLNAME ASC"

        Using ds As DataSet = LoadSQL(mysqll, "TBL_EMPLOYEE")
            If ds.Tables(0).Rows.Count > 0 Then

                progressBarStart(ds.Tables(0).Rows.Count)
                For Each dr In ds.Tables(0).Rows
                    With dr

                        '============================= NAME AND ATTENDANCE ============================  
                        Dim namee As String = .Item("FULLNAME")
                        Dim CATEGORY As String = .Item("CATEGORY")
                        Dim NET_PAY As Decimal = .Item("NET_PAY")
                        Dim LEASING As String = .Item("LEASING")

                        If .ITEM("BIOMETRICID") = "2788" Then ' MADERA  
                            LEASING = (50 * LEASING) / 100
                        End If

                        TOTALS += NET_PAY * LEASING

                        frmMainForm.AppProgressBar.Value += 1
                    End With
                Next
                progressBarEnd()

                Dim COMPANY As String = "P&G REALTY"
                Dim ADDRESS As String = "PGC/GENSAN"

                dt_Dalton.Rows.Add(PAYROLL.ToString("MMMM dd, yyyy").ToUpper(), COMPANY,
                                                       info.ToTitleCase(ADDRESS), TOTALS.ToString("n"), 0, 0, 0)

            End If
        End Using

        Return dt_Dalton
    End Function

    Public Function GetOVERALL_COUNT(COLUMN As String, PAYDATE As String)
        Dim VALUEE As Integer
        Dim mysql As String = $"Select COUNT({COLUMN}) AS TOTS FROM  PAYROLL_PAYOUT WHERE PAYDATE = '{PAYDATE}'"
        Dim ds As DataSet = LoadSQL(mysql, "PAYROLL_PAYOUT")
        If ds.Tables(0).Rows.Count > 0 Then
            progressBarStart(ds.Tables(0).Rows.Count)
            For Each DR In ds.Tables(0).Rows
                With DR
                    VALUEE = IIf(IsDBNull(.Item("TOTS")), 0, .Item("TOTS"))
                    frmMainForm.AppProgressBar.Value += 1
                End With
            Next
            progressBarEnd()
        End If

        Return VALUEE
    End Function

    Public Function GetOVERALL_SUM(COLUMN As String, PAYDATE As String)
        Dim VALUEE As Decimal
        Dim mysql As String = $"Select SUM({COLUMN}) AS TOTS FROM  PAYROLL_PAYOUT WHERE PAYDATE = '{PAYDATE}'"
        Dim ds As DataSet = LoadSQL(mysql, "PAYROLL_PAYOUT")
        If ds.Tables(0).Rows.Count > 0 Then

            progressBarStart(ds.Tables(0).Rows.Count)
            For Each DR In ds.Tables(0).Rows
                With DR
                    VALUEE = IIf(IsDBNull(.Item("TOTS")), 0, .Item("TOTS"))

                    frmMainForm.AppProgressBar.Value += 1
                End With
            Next
            progressBarEnd()
        End If

        Return VALUEE
    End Function

    Public Function Get13MONTH_TOTAL(PAYDATE As String)
        Dim VALUEE As Decimal
        Dim mysql As String = $"Select SUM(AMOUNT) AS TOTS FROM  RECORDED_ALLOW_DEDUC WHERE PAYDATE = '{PAYDATE}' AND CATEGORY = '13th Month Pay'"
        Dim ds As DataSet = LoadSQL(mysql, "RECORDED_ALLOW_DEDUC")
        If ds.Tables(0).Rows.Count > 0 Then
            Dim DR As DataRow = ds.Tables(0).Rows(0)
            With DR
                VALUEE = IIf(IsDBNull(.Item("TOTS")), 0, .Item("TOTS"))
            End With
        End If

        Return VALUEE
    End Function

    Public Function Get_PI_ECOLA_SIL_TOTAL(PAYDATE As String)
        Dim VALUEE As Decimal
        Dim mysql As String = $"Select SUM(AMOUNT) AS TOTS FROM  RECORDED_ALLOW_DEDUC WHERE PAYDATE = '{PAYDATE}' AND TRANSAC_NAME = 'ALLOWANCE' AND CATEGORY <> '13th Month Pay'"
        Dim ds As DataSet = LoadSQL(mysql, "RECORDED_ALLOW_DEDUC")
        If ds.Tables(0).Rows.Count > 0 Then
            Dim DR As DataRow = ds.Tables(0).Rows(0)
            With DR
                VALUEE = IIf(IsDBNull(.Item("TOTS")), 0, .Item("TOTS"))
            End With
        End If

        Return VALUEE
    End Function

    Public Function Get_PI_ECOLA_SIL(BIO_NO As String, PAYDATE As String)
        Dim VALUEE As Decimal
        Dim mysql As String = $"Select SUM(AMOUNT) AS TOTS FROM  RECORDED_ALLOW_DEDUC WHERE BIO_NO = '{BIO_NO}' AND  PAYDATE = '{PAYDATE}' AND TRANSAC_NAME = 'ALLOWANCE' AND CATEGORY <> '13th Month Pay'"
        Dim ds As DataSet = LoadSQL(mysql, "RECORDED_ALLOW_DEDUC")
        If ds.Tables(0).Rows.Count > 0 Then
            Dim DR As DataRow = ds.Tables(0).Rows(0)
            With DR
                VALUEE = IIf(IsDBNull(.Item("TOTS")), 0, .Item("TOTS"))
            End With
        End If

        Return VALUEE
    End Function

    Public Function Get_PGC(column As String, paydate As String) As Double

        If column = "DAVAOP" Then
            Console.WriteLine(column)
        End If

        Dim TOTALS As Decimal = 0
        Dim G3_tot As Decimal = 0
        Dim Seven11_tot As Decimal = 0
        Dim COMI_TO_FUJI_tot As Decimal = 0

        Dim mysqll As String = $"Select A.*, B.*, C.*, 
                                        LASTNAME || ', ' || FIRSTNAME || ' ' || 
                                             CASE 
                                                 WHEN MIDDLENAME IS NOT NULL AND MIDDLENAME <> '' THEN LEFT(MIDDLENAME, 1) || '.'
                                                 ELSE ''
                                             END AS FULLNAME
                                        From TBL_EMPLOYEE A 
                                        INNER JOIN PAYROLL_PERCENTAGEE B ON B.CATEGORY = A.COMMON_CATEGORY
                                        INNER JOIN PAYROLL_PAYOUT C ON A.BIOMETRICID = C.BIOMETRIC_ID
                                        where  PAYDATE = '{paydate}' AND HO_CATEGORY = 'PGC Head Office' 
                                            OR (HO_CATEGORY IN ('Construction', 'Leasing Admin Office') AND  PAYDATE = '{paydate}')
                                            ORDER BY FULLNAME ASC"

        Using ds As DataSet = LoadSQL(mysqll, "TBL_EMPLOYEE")
            If ds.Tables(0).Rows.Count > 0 Then

                progressBarStart(ds.Tables(0).Rows.Count)
                For Each dr In ds.Tables(0).Rows
                    With dr

                        '============================= NAME AND ATTENDANCE ============================  
                        Dim namee As String = .Item("FULLNAME")
                        Dim CATEGORY As String = .Item("CATEGORY")
                        Dim NET_PAY As Decimal = .Item("NET_PAY")
                        Dim G3 As String = .Item("G3")
                        Dim Seven11 As String = .Item("Seven11")
                        Dim COMI_TO_FUJI As String = .Item("COMI_TO_FUJI")
                        Dim VALUEE As String = .Item(column)

                        If .ITEM("BIOMETRICID") = "2788" Then ' MADERA 
                            VALUEE = (50 * VALUEE) / 100
                        End If

                        If column = "COMI_TO_FUJI" Then ' P&G UY SONS

                            If .ITEM("BIOMETRICID") = "2788" Then ' MADERA  
                                G3_tot += NET_PAY * ((50 * G3) / 100)
                                Seven11_tot += NET_PAY * ((50 * Seven11) / 100)
                                COMI_TO_FUJI_tot += NET_PAY * ((50 * COMI_TO_FUJI) / 100)
                            Else
                                G3_tot += NET_PAY * G3
                                Seven11_tot += NET_PAY * Seven11
                                COMI_TO_FUJI_tot += NET_PAY * COMI_TO_FUJI
                            End If

                        End If

                        TOTALS += NET_PAY * VALUEE

                        frmMainForm.AppProgressBar.Value += 1
                    End With
                Next
                progressBarEnd()
            End If
        End Using

        If column = "COMI_TO_FUJI" Then
            TOTALS = G3_tot + Seven11_tot + COMI_TO_FUJI_tot
        End If

        Return TOTALS
    End Function

    Friend Function Load_Remittance_SSS(paydate As String, str As String) As DataTable

        Dim mysql As String
        Dim PAYROLL As DateTime = paydate
        Dim linee As String = Nothing

        Dim dt_Remittance As New DataTable()
        With dt_Remittance
            .Columns.Add("NAME")
            .Columns.Add("NO")
            .Columns.Add("EE")
            .Columns.Add("ER")
            .Columns.Add("EC")
            .Columns.Add("BRANCH")
        End With

        Try

            mysql = $"Select A.*, B.*, C.*, 
                    LASTNAME || ', ' || FIRSTNAME || ' ' || 
                         CASE 
                             WHEN MIDDLENAME IS NOT NULL AND MIDDLENAME <> '' THEN LEFT(MIDDLENAME, 1) || '.'
                             ELSE ''
                         END AS FULLNAME  
                    From PAYROLL_PAYOUT A 
                    INNER JOIN TBL_EMPLOYEE B ON B.BIOMETRICID = A.BIOMETRIC_ID 
                    LEFT JOIN PAYROLL_CITY_BRANCH C ON C.BRANCHCODE = B.BRANCHCODE 
                    WHERE PAYDATE = '{paydate}' {str} and SSS_COMP <> 0 ORDER BY FULLNAME"

            Using ds As DataSet = LoadSQL(mysql, "PAYROLL_PAYOUT")
                If ds.Tables(0).Rows.Count > 0 Then

                    progressBarStart(ds.Tables(0).Rows.Count)
                    For Each dr In ds.Tables(0).Rows
                        With dr

                            '============================= NAME AND ATTENDANCE ============================  
                            Dim FULLNAME As String = IIf(IsDBNull(.Item("FULLNAME")), "", .Item("FULLNAME"))
                            Dim monthly_Basic As Decimal = GetMonthly_Basic(.item("BIOMETRIC_ID"), paydate)

                            Dim NOO As String = IIf(IsDBNull(.Item("SSSNO")), "", .Item("SSSNO"))
                            Dim EE As String = Get_SSS(monthly_Basic).EE
                            Dim ER As String = Get_SSS(monthly_Basic).ER
                            Dim EC As String = Get_SSS(monthly_Basic).EC

                            '===================================== BRANCHES ===============================
                            linee = $"BRANCH_CODE -{FULLNAME}"
                            Dim BRANCH_CODE As String '= IIf(IsDBNull(.Item("BRANCHCODE")) Or .Item("BRANCHCODE") = "", .Item("HO_CATEGORY"), .Item("BRANCHNAME"))

                            If IsDBNull(.Item("BRANCHCODE")) Then
                                BRANCH_CODE = .Item("HO_CATEGORY")
                            ElseIf .Item("BRANCHCODE") = "" Then
                                BRANCH_CODE = .Item("HO_CATEGORY")
                            Else
                                BRANCH_CODE = .Item("BRANCHNAME")
                            End If

                            linee = $"COMPANY -{FULLNAME}"
                            Dim COMPANY As String = IIf(IsDBNull(.Item("COMPANY")), "", .Item("COMPANY"))
                            linee = $"HO_CATEGORY -{FULLNAME}"
                            Dim HO_CATEGORY As String = IIf(IsDBNull(.Item("HO_CATEGORY")), "", .Item("HO_CATEGORY"))
                            linee = $"COMPANY_CATEGORY -{FULLNAME}"
                            Dim COMPANY_CATEGORY As String = IIf(IsDBNull(.Item("PHOTO_CATEGORY")), "", .Item("PHOTO_CATEGORY"))

                            If COMPANY = "DALTON" Then
                                linee = $"COMPANY - BRANCH_CODE -{FULLNAME}"
                                BRANCH_CODE = IIf(IsDBNull(.Item("BRANCHCODE")) Or .Item("BRANCHCODE") = "", .Item("HO_CATEGORY"), TitleCase(.Item("COMPANY")) & "-" & .Item("BRANCHNAME"))
                            End If

                            If HO_CATEGORY = "GHS/P&G UY Admin Office" Or HO_CATEGORY = "GHS/P&G UY Admin Operation" Then
                                BRANCH_CODE = HO_CATEGORY

                            ElseIf HO_CATEGORY.Contains("Dalton") Then
                                BRANCH_CODE = HO_CATEGORY

                            ElseIf HO_CATEGORY.Contains("Photo") Or HO_CATEGORY.Contains("PGC") Then
                                BRANCH_CODE = HO_CATEGORY
                            End If

                            If COMPANY_CATEGORY <> "" Then
                                BRANCH_CODE = COMPANY_CATEGORY
                            End If

                            dt_Remittance.Rows.Add(FULLNAME, NOO, EE, ER, EC, BRANCH_CODE)

                            frmMainForm.AppProgressBar.Value += 1
                        End With

                    Next
                    progressBarEnd()
                End If
            End Using
        Catch ex As Exception
            MsgBox($"{ex.ToString} {vbCrLf} {linee}")
        End Try

        Return dt_Remittance
    End Function

    Friend Function Load_Loan_Report(paydate As String, str As String, category As String) As DataTable

        Dim mysql As String
        Dim PAYROLL As DateTime = paydate

        Dim dt_Loans As New DataTable()
        With dt_Loans
            .Columns.Add("NAME")
            .Columns.Add("EE")
            .Columns.Add("BRANCH")
        End With

        If category = "SSS" Then
            mysql = $"Select A.*, B.*, C.*, 
                        LASTNAME || ', ' || FIRSTNAME || ' ' || 
                             CASE 
                                 WHEN MIDDLENAME IS NOT NULL AND MIDDLENAME <> '' THEN LEFT(MIDDLENAME, 1) || '.'
                                 ELSE ''
                             END AS FULLNAME
                        From RECORDED_ALLOW_DEDUC A INNER JOIN TBL_EMPLOYEE B ON B.BIOMETRICID = A.BIO_NO 
                        LEFT JOIN PAYROLL_CITY_BRANCH C ON C.BRANCHCODE = B.BRANCHCODE       
                        WHERE PAYDATE = '{paydate}' AND TRANSAC_NAME = 'DEDUCTION' AND UPPER(A.CATEGORY) LIKE UPPER('%SSS%') {str} ORDER BY FULLNAME"
        Else
            mysql = $"Select A.*, B.*, C.*, 
                        LASTNAME || ', ' || FIRSTNAME || ' ' || 
                             CASE 
                                 WHEN MIDDLENAME IS NOT NULL AND MIDDLENAME <> '' THEN LEFT(MIDDLENAME, 1) || '.'
                                 ELSE ''
                             END AS FULLNAME
                        From RECORDED_ALLOW_DEDUC A INNER JOIN TBL_EMPLOYEE B ON B.BIOMETRICID = A.BIO_NO  
                        LEFT JOIN PAYROLL_CITY_BRANCH C ON C.BRANCHCODE = B.BRANCHCODE        
                        WHERE PAYDATE = '{paydate}' AND TRANSAC_NAME = 'DEDUCTION' AND (UPPER(A.CATEGORY) LIKE UPPER('%PAG IBIG%') oR UPPER(A.CATEGORY) LIKE UPPER('%PAG-IBIG%')) {str} ORDER BY FULLNAME"
        End If

        Using ds As DataSet = LoadSQL(mysql, "RECORDED_ALLOW_DEDUC")
            If ds.Tables(0).Rows.Count > 0 Then

                progressBarStart(ds.Tables(0).Rows.Count)
                For Each dr In ds.Tables(0).Rows
                    With dr

                        '============================= NAME AND ATTENDANCE ============================  
                        Dim FULLNAME As String = IIf(IsDBNull(.Item("FULLNAME")), "", .Item("FULLNAME"))
                        Dim AMOUNT As String = FormatNumber(.Item("AMOUNT"))

                        '===================================== BRANCHES ===============================
                        Dim BRANCH_CODE As String '= IIf(.Item("BRANCHCODE") = "" Or IsDBNull(.Item("BRANCHCODE")), .Item("HO_CATEGORY"), .Item("BRANCHNAME"))

                        If IsDBNull(.Item("BRANCHCODE")) Then
                            BRANCH_CODE = .Item("HO_CATEGORY")
                        ElseIf .Item("BRANCHCODE") = "" Then
                            BRANCH_CODE = .Item("HO_CATEGORY")
                        Else
                            BRANCH_CODE = .Item("BRANCHNAME")
                        End If

                        Dim COMPANY As String = IIf(IsDBNull(.Item("COMPANY")), "", .Item("COMPANY"))
                        Dim HO_CATEGORY As String = IIf(IsDBNull(.Item("HO_CATEGORY")), "", .Item("HO_CATEGORY"))
                        Dim PHOTO_CATEGORY As String = IIf(IsDBNull(.Item("PHOTO_CATEGORY")), "", .Item("PHOTO_CATEGORY"))

                        If COMPANY = "DALTON" Then
                            BRANCH_CODE = IIf(.Item("BRANCHCODE") = "" Or IsDBNull(.Item("BRANCHCODE")), .Item("HO_CATEGORY"), TitleCase(.Item("COMPANY")) & "-" & .Item("BRANCHNAME"))
                        End If

                        If HO_CATEGORY = "GHS/P&G UY Admin Office" Or HO_CATEGORY = "GHS/P&G UY Admin Operation" Then
                            BRANCH_CODE = HO_CATEGORY

                        ElseIf HO_CATEGORY.Contains("Dalton") Then
                            BRANCH_CODE = HO_CATEGORY

                        ElseIf HO_CATEGORY.Contains("Photo") Or HO_CATEGORY.Contains("PGC") Then
                            BRANCH_CODE = HO_CATEGORY
                        End If

                        If PHOTO_CATEGORY <> "" Then
                            BRANCH_CODE = PHOTO_CATEGORY
                        End If

                        dt_Loans.Rows.Add(FULLNAME, AMOUNT, BRANCH_CODE)

                        frmMainForm.AppProgressBar.Value += 1
                    End With

                Next
                progressBarEnd()
            Else

            End If
        End Using

        Return dt_Loans
    End Function

    Friend Function Load_Remittance_Pagibig(paydate As String, str As String) As DataTable

        Dim mysql As String
        Dim PAYROLL As DateTime = paydate

        Dim dt_Remittance As New DataTable()
        With dt_Remittance
            .Columns.Add("NAME")
            .Columns.Add("NO")
            .Columns.Add("EE")
            .Columns.Add("ER")
            .Columns.Add("EC")
            .Columns.Add("BRANCH")
        End With

        mysql = $"Select A.*, B.*, B.BRANCHCODE AS BRANCH_CODE, C.*,
                                        LASTNAME || ', ' || FIRSTNAME || ' ' || 
                                             CASE 
                                                 WHEN MIDDLENAME IS NOT NULL AND MIDDLENAME <> '' THEN LEFT(MIDDLENAME, 1) || '.'
                                                 ELSE ''
                                             END AS FULLNAME
                                        From PAYROLL_PAYOUT A INNER JOIN TBL_EMPLOYEE B ON BIOMETRICID = BIOMETRIC_ID   
                                        LEFT JOIN PAYROLL_CITY_BRANCH C ON C.BRANCHCODE = B.BRANCHCODE     
                                        WHERE PAYDATE = '{paydate}' {str} and PAGIBIG_COMP <> 0 ORDER BY FULLNAME"

        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_PAYOUT")
            If ds.Tables(0).Rows.Count > 0 Then

                progressBarStart(ds.Tables(0).Rows.Count)
                For Each dr In ds.Tables(0).Rows
                    With dr

                        '============================= NAME AND ATTENDANCE ============================  
                        Dim FULLNAME As String = IIf(IsDBNull(.Item("FULLNAME")), "", .Item("FULLNAME"))
                        Dim monthly_Basic As Decimal = GetMonthly_Basic(.item("BIOMETRIC_ID"), paydate)

                        Dim NOO As String = IIf(IsDBNull(.Item("PAGIBIG")), "", .Item("PAGIBIG"))
                        Dim EE As String = Get_Pagibig(monthly_Basic)
                        Dim BRANCH As String = ""

                        '===================================== BRANCHES ===============================
                        Dim BRANCH_CODE As String '= IIf(.Item("BRANCH_CODE") = "" Or IsDBNull(.Item("BRANCH_CODE")), .Item("HO_CATEGORY"), .Item("BRANCHNAME"))

                        If IsDBNull(.Item("BRANCHCODE")) Then
                            BRANCH_CODE = .Item("HO_CATEGORY")
                        ElseIf .Item("BRANCHCODE") = "" Then
                            BRANCH_CODE = .Item("HO_CATEGORY")
                        Else
                            BRANCH_CODE = .Item("BRANCHNAME")
                        End If

                        Dim COMPANY As String = .Item("COMPANY")
                        Dim HO_CATEGORY As String = IIf(IsDBNull(.Item("HO_CATEGORY")), "", .Item("HO_CATEGORY"))
                        Dim COMPANY_CATEGORY As String = IIf(IsDBNull(.Item("PHOTO_CATEGORY")), "", .Item("PHOTO_CATEGORY"))

                        If COMPANY = "DALTON" Then
                            BRANCH_CODE = IIf(.Item("BRANCH_CODE") = "" Or IsDBNull(.Item("BRANCH_CODE")), .Item("HO_CATEGORY"), TitleCase(.Item("COMPANY")) & "-" & .Item("BRANCHNAME"))
                        End If

                        If HO_CATEGORY = "GHS/P&G UY Admin Office" Or HO_CATEGORY = "GHS/P&G UY Admin Operation" Then
                            BRANCH_CODE = HO_CATEGORY

                        ElseIf HO_CATEGORY.Contains("Dalton") Then
                            BRANCH_CODE = HO_CATEGORY

                        ElseIf HO_CATEGORY.Contains("Photo") Or HO_CATEGORY.Contains("PGC") Then
                            BRANCH_CODE = HO_CATEGORY
                        End If

                        If COMPANY_CATEGORY <> "" Then
                            BRANCH_CODE = COMPANY_CATEGORY
                        End If

                        dt_Remittance.Rows.Add(FULLNAME, NOO, EE, EE, Nothing, BRANCH_CODE)

                        frmMainForm.AppProgressBar.Value += 1
                    End With

                Next
                progressBarEnd()
            End If
        End Using

        Return dt_Remittance
    End Function

    Friend Function Load_Remittance_PhilHealth(paydate As String, str As String) As DataTable

        Dim mysql As String
        Dim PAYROLL As DateTime = paydate

        Dim dt_Remittance As New DataTable()
        With dt_Remittance
            .Columns.Add("NAME")
            .Columns.Add("NO")
            .Columns.Add("EE")
            .Columns.Add("ER")
            .Columns.Add("EC")
            .Columns.Add("BRANCH")
        End With

        mysql = $"Select A.*, B.*, C.*,  B.BRANCHCODE AS BRANCH_CODE, 
                                        LASTNAME || ', ' || FIRSTNAME || ' ' || 
                                             CASE 
                                                 WHEN MIDDLENAME IS NOT NULL AND MIDDLENAME <> '' THEN LEFT(MIDDLENAME, 1) || '.'
                                                 ELSE ''
                                             END AS FULLNAME 
                                        From PAYROLL_PAYOUT A INNER JOIN TBL_EMPLOYEE B ON BIOMETRICID = BIOMETRIC_ID   
                                        LEFT JOIN PAYROLL_CITY_BRANCH C ON C.BRANCHCODE = B.BRANCHCODE     
                                        WHERE PAYDATE = '{paydate}' {str} and PHILHEALTH_COMP <> 0 ORDER BY FULLNAME"

        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_PAYOUT")
            If ds.Tables(0).Rows.Count > 0 Then

                progressBarStart(ds.Tables(0).Rows.Count)
                For Each dr In ds.Tables(0).Rows
                    With dr

                        '============================= NAME AND ATTENDANCE ============================  
                        Dim FULLNAME As String = IIf(IsDBNull(.Item("FULLNAME")), "", .Item("FULLNAME"))
                        Dim monthly_Basic As Decimal = GetMonthly_Basic(.item("BIOMETRIC_ID"), paydate)

                        Dim NOO As String = IIf(IsDBNull(.Item("PHILHEALTHNO")), "", .Item("PHILHEALTHNO"))
                        Dim EE As String = Get_PhilHealth(monthly_Basic)
                        Dim BRANCH As String = ""

                        '===================================== BRANCHES ===============================
                        Dim BRANCH_CODE As String '= IIf(.Item("BRANCH_CODE") = "" Or IsDBNull(.Item("BRANCH_CODE")), .Item("HO_CATEGORY"), .Item("BRANCHNAME"))

                        If IsDBNull(.Item("BRANCHCODE")) Then
                            BRANCH_CODE = .Item("HO_CATEGORY")
                        ElseIf .Item("BRANCHCODE") = "" Then
                            BRANCH_CODE = .Item("HO_CATEGORY")
                        Else
                            BRANCH_CODE = .Item("BRANCHNAME")
                        End If

                        Dim COMPANY As String = IIf(IsDBNull(.Item("COMPANY")), "", .Item("COMPANY"))
                        Dim HO_CATEGORY As String = IIf(IsDBNull(.Item("HO_CATEGORY")), "", .Item("HO_CATEGORY"))
                        Dim COMPANY_CATEGORY As String = IIf(IsDBNull(.Item("PHOTO_CATEGORY")), "", .Item("PHOTO_CATEGORY"))

                        If COMPANY = "DALTON" Then
                            BRANCH_CODE = IIf(.Item("BRANCH_CODE") = "" Or IsDBNull(.Item("BRANCH_CODE")), .Item("HO_CATEGORY"), TitleCase(.Item("COMPANY")) & "-" & .Item("BRANCHNAME"))
                        End If

                        If HO_CATEGORY = "GHS/P&G UY Admin Office" Or HO_CATEGORY = "GHS/P&G UY Admin Operation" Then
                            BRANCH_CODE = HO_CATEGORY

                        ElseIf HO_CATEGORY.Contains("Dalton") Then
                            BRANCH_CODE = HO_CATEGORY

                        ElseIf HO_CATEGORY.Contains("Photo") Or HO_CATEGORY.Contains("PGC") Then
                            BRANCH_CODE = HO_CATEGORY
                        End If

                        If COMPANY_CATEGORY <> "" Then
                            BRANCH_CODE = COMPANY_CATEGORY
                        End If

                        dt_Remittance.Rows.Add(FULLNAME, NOO, EE, EE, Nothing, BRANCH_CODE)

                        frmMainForm.AppProgressBar.Value += 1
                    End With

                Next
                progressBarEnd()
            End If
        End Using

        Return dt_Remittance
    End Function

    Public Function GetList_Branch(address As String, str As String) As String

        Dim branch_group As New List(Of String)()
        Dim mysql As String = $"Select A.BRANCHCODE AS BRANCH_CODE from PAYROLL_CITY_BRANCH A
                                inner join TBL_EMPLOYEE B ON A.BRANCHCODE = B.BRANCHCODE 
                                where A.ADDRESS = '{address}' and {str}"
        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_CITY_BRANCH")
            If ds.Tables(0).Rows.Count > 0 Then
                For Each dr In ds.Tables(0).Rows
                    With dr
                        branch_group.Add($"'{ .item("BRANCH_CODE")}'")
                    End With
                Next
            End If
        End Using

        branch_group = branch_group.Distinct().ToList

        Dim list_String As String = String.Join(",", branch_group)

        Return list_String
    End Function

    Friend Function GET_STRING(TABLE As String, column As String, STR As String)
        Dim VALUEE As String = ""
        Dim MYSQL = $"SELECT {column} FROM {TABLE} WHERE {STR}"
        Using ds As DataSet = LoadSQL(MYSQL, TABLE)
            If ds.Tables(0).Rows.Count > 0 Then
                Dim dr As DataRow = ds.Tables(0).Rows(0)
                With dr
                    VALUEE = .Item(column)
                End With
            End If
        End Using

        Return VALUEE
    End Function

    Friend Sub Laod_13Month(bioNo As String, report As Microsoft.Reporting.WinForms.ReportViewer, Optional range As DateTime = Nothing)

        Dim datee As DateTime = IIf(range = Nothing, Date.Now, range)
        Dim December_April As DateTime = New DateTime(datee.AddYears(-1).Year, 12, 1)
        Dim May_Nov As DateTime = New DateTime(datee.Year, 5, 1)

        Dim starting_date, ending_date As String
        Dim startt As New DateTime(datee.Year, 5, 16)
        Dim endd As New DateTime(datee.Year, 12, 15)
        If (datee >= startt AndAlso datee <= endd) Then
            starting_date = May_Nov.ToString("d")

            Dim days As Integer = System.DateTime.DaysInMonth(May_Nov.Year, May_Nov.Month)
            ending_date = May_Nov.AddMonths(6).AddDays(days).AddDays(-1).ToString("d")
        Else
            starting_date = December_April.ToString("d")

            Dim days As Integer = System.DateTime.DaysInMonth(December_April.Year, December_April.Month)
            ending_date = December_April.AddMonths(4).AddDays(days).AddDays(-1).ToString("d")
        End If

        report.LocalReport.DataSources.Clear()

        Try

            Dim dt As New DataTable()
            With dt
                .Columns.Add("EMP_NAME")
                .Columns.Add("PAYROLL_PERIOD")
                .Columns.Add("NO_OF_DAYS")
                .Columns.Add("BASIC_PAY")
                .Columns.Add("OTHER_INCOME")
                .Columns.Add("REGULAR_PAY")
            End With

            Dim mysql As String = $"Select BIOMETRIC_ID, PAYDATE, 
                                LASTNAME || ', ' || FIRSTNAME || ' ' || 
                                     CASE 
                                         WHEN MIDDLENAME IS NOT NULL AND MIDDLENAME <> '' THEN LEFT(MIDDLENAME, 1) || '.'
                                         ELSE ''
                                     END AS FULLNAME
                                from TBL_EMPLOYEE inner join PAYROLL_PAYOUT on BIOMETRIC_ID = BIOMETRICID where BIOMETRICID='{bioNo}' and PAYDATE BETWEEN '{starting_date}' AND '{ending_date}'"
            Using ds As DataSet = LoadSQL(mysql, "TBL_EMPLOYEE")
                progressBarStart(ds.Tables(0).Rows.Count)
                For Each dr In ds.Tables(0).Rows
                    With dr

                        Dim OTHER_INCOME As Decimal = 0
                        Dim FULLNAME As String = .item("FULLNAME")
                        Dim PAYDATE As String = .item("PAYDATE")
                        Dim NO_OF_DAYS As Decimal = GetData_Decimal("PRESENT_DAYS", $"PAYROLL_ATTENDANCE where BIOMETRICID = '{bioNo}' and PAYDATE = '{PAYDATE}'")
                        Dim tOTAL_BASIC As Decimal = GetData_Decimal("TOTAL_BASIC", $"PAYROLL_PAYOUT where BIOMETRIC_ID = '{bioNo}' and PAYDATE  = '{PAYDATE}'")

                        Dim tOTAL_ECOLA As Decimal = GetData_Decimal("AMOUNT", $"RECORDED_ALLOW_DEDUC where BIOMETRICID = '{bioNo}' and CATEGORY = 'ECOLA' and PAYDATE = '{PAYDATE}'")
                        Dim tOTAL_SIL As Decimal = GetData_Decimal("AMOUNT", $"RECORDED_ALLOW_DEDUC where BIOMETRICID = '{bioNo}' and CATEGORY like '%SIL' and PAYDATE = '{PAYDATE}'")
                        Dim tOTAL_PI As Decimal = GetData_Decimal("AMOUNT", $"RECORDED_ALLOW_DEDUC where BIOMETRICID = '{bioNo}' and CATEGORY = 'PERFORMANCE INCENTIVES' and PAYDATE = '{PAYDATE}'")
                        Dim tOTAL_LATE_UT As Decimal = GetData_Decimal("TOTAL_LATE_UT", $"PAYROLL_PAYOUT BIOMETRICID  BIOMETRIC_ID = '{bioNo}' and PAYDATE = '{PAYDATE}'")

                        OTHER_INCOME = (tOTAL_ECOLA + tOTAL_SIL + tOTAL_PI) - tOTAL_LATE_UT
                        Dim TOTALS As Decimal = tOTAL_BASIC + OTHER_INCOME

                        dt.Rows.Add(FULLNAME, CDate(PAYDATE).ToString("MMMM dd, yyyy"), NO_OF_DAYS, tOTAL_BASIC.ToString("N"), OTHER_INCOME.ToString("N"), TOTALS.ToString("N"))

                    End With
                    frmMainForm.AppProgressBar.Value += 1
                Next

                Dim dataSource As New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt)
                report.LocalReport.ReportEmbeddedResource = "WindowsApp1.rpt_13Month.rdlc"
                report.LocalReport.DataSources.Add(dataSource)
                report.RefreshReport()
                progressBarEnd()
            End Using

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

End Module
