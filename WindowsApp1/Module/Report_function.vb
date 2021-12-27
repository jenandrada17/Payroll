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

        mysql = $"Select * From PAYROLL_PAYOUT A  
                                        INNER JOIN PAYROLL_EMPLOYEE C ON BIO_NO = BIOMETRIC_ID    
                                        LEFT JOIN PAYROLL_CITY_BRANCH B ON BRANCHCODE = BRANCH_CODE    
                                        WHERE (BRANCHCODE IN ('DIG','ISU','M1','POL', 'ROG','ROX','FINEPIX','COT','MID','KID','SNP','GMA','SML','ZAM','SMD')
                                                AND  PAYDATE = '{paydate}' AND COMPANY = 'PHOTO') OR (HO_CATEGORY LIKE 'Photo%' AND  PAYDATE = '{paydate}')
                                        ORDER BY CASE WHEN UPPER(HO_CATEGORY) LIKE UPPER('%Admin%') THEN 0  
                                                WHEN UPPER(ADDRESS) LIKE UPPER('GENSAN') THEN 1 
                                                WHEN UPPER(ADDRESS) LIKE UPPER('POLOMOLOK') THEN 2 
                                                WHEN UPPER(ADDRESS) LIKE UPPER('MARBEL') THEN 3 
                                                WHEN UPPER(ADDRESS) LIKE UPPER('ISULAN') THEN 4 
                                                WHEN UPPER(ADDRESS) LIKE UPPER('COTABATO') THEN 5 
                                                WHEN UPPER(ADDRESS) LIKE UPPER('KIDAPAWAN') THEN 6 
                                                WHEN UPPER(ADDRESS) LIKE UPPER('MIDSAYAP') THEN 7 
                                                WHEN UPPER(ADDRESS) LIKE UPPER('DAVAO') THEN 8 
                                                WHEN UPPER(ADDRESS) LIKE UPPER('SM SAN LAZARO') THEN 9 
                                                WHEN UPPER(ADDRESS) LIKE UPPER('ZAMBOANGA') THEN 10  
                                                END"

        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_PAYOUT")
            If ds.Tables(0).Rows.Count > 0 Then

                progressBarStart(ds.Tables(0).Rows.Count)
                For Each dr In ds.Tables(0).Rows
                    With dr

                        '============================= NAME AND ATTENDANCE ============================  
                        Dim COMPANY As String = "PHOTO"
                        Dim ADDRESS As String = IIf(IsDBNull(.Item("ADDRESS")), "", .Item("ADDRESS"))
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

                        Dim HO_array As String() = HO_CATEGORY.Split(New Char() {" "c}) '=== ADMIN   
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

        mysql = $"Select * From PAYROLL_PAYOUT A  
                                        INNER JOIN PAYROLL_EMPLOYEE C ON BIO_NO = BIOMETRIC_ID    
                                        LEFT JOIN PAYROLL_CITY_BRANCH B ON BRANCHCODE = BRANCH_CODE    
                                        WHERE PAYDATE = '{paydate}'  AND COMPANY = 'PHOTO'
                                            AND BRANCHCODE IN ('SMG','KCG','ACM','TAC')  
                                        ORDER BY CASE WHEN ADDRESS = 'GENSAN' THEN 0  
                                                WHEN ADDRESS = 'MARBEL' THEN 1    
                                                else 2 END"

        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_PAYOUT")
            If ds.Tables(0).Rows.Count > 0 Then

                progressBarStart(ds.Tables(0).Rows.Count)
                For Each dr In ds.Tables(0).Rows
                    With dr

                        '============================= NAME AND ATTENDANCE ============================  
                        Dim COMPANY As String = "PHOTO"
                        Dim ADDRESS As String = IIf(IsDBNull(.Item("ADDRESS")), "", .Item("ADDRESS"))
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

        mysql = $"Select * From PAYROLL_PAYOUT A  
                                        INNER JOIN PAYROLL_EMPLOYEE C ON BIO_NO = BIOMETRIC_ID    
                                        LEFT JOIN PAYROLL_CITY_BRANCH B ON BRANCHCODE = BRANCH_CODE    
                                        WHERE PAYDATE = '{paydate}' AND COMPANY  = 'DALTON'
                                            OR  (HO_CATEGORY LIKE 'Dalton%' AND PAYDATE = '{paydate}' )
                                        ORDER BY CASE WHEN UPPER(HO_CATEGORY) LIKE UPPER('%Admin%') THEN 0 
                                                WHEN UPPER(HO_CATEGORY) LIKE UPPER('%Retail%') THEN 1 
                                                WHEN UPPER(ADDRESS) LIKE UPPER('GENSAN') THEN 2  
                                                WHEN UPPER(ADDRESS) LIKE UPPER('POLOMOLOK') THEN 3 
                                                WHEN UPPER(ADDRESS) LIKE UPPER('MARBEL') THEN 4 
                                                WHEN UPPER(ADDRESS) LIKE UPPER('ISULAN') THEN 5 
                                                WHEN UPPER(ADDRESS) LIKE UPPER('TACURONG') THEN 6 
                                                WHEN UPPER(ADDRESS) LIKE UPPER('SURALLAH') THEN 7 
                                                WHEN UPPER(ADDRESS) LIKE UPPER('BANGA') THEN 8 
                                                WHEN UPPER(ADDRESS) LIKE UPPER('TBOLI') THEN 9 
                                                WHEN UPPER(ADDRESS) LIKE UPPER('ESPERANZA') THEN 10 
                                                WHEN UPPER(ADDRESS) LIKE UPPER('KALAMANSIG') THEN 11  
                                                WHEN UPPER(ADDRESS) LIKE UPPER('LAMBAYONG') THEN 12  
                                                WHEN UPPER(ADDRESS) LIKE UPPER('LEBAK') THEN 13  
                                                WHEN UPPER(ADDRESS) LIKE UPPER('AWANG') THEN 14  
                                                WHEN UPPER(ADDRESS) LIKE UPPER('DALICAN') THEN 15  
                                                WHEN UPPER(ADDRESS) LIKE UPPER('COTABATO') THEN 16  
                                                WHEN UPPER(ADDRESS) LIKE UPPER('KIDAPAWAN') THEN 17  
                                                WHEN UPPER(ADDRESS) LIKE UPPER('KIDAPAWAN') THEN 18   
                                                WHEN UPPER(ADDRESS) LIKE UPPER('MIDSAYAP') THEN 19 
                                                WHEN UPPER(ADDRESS) LIKE UPPER('KABACAN') THEN 20 
                                                WHEN UPPER(ADDRESS) LIKE UPPER('PIKIT') THEN 21 
                                                WHEN UPPER(ADDRESS) LIKE UPPER('MLANG') THEN 22 
                                                WHEN UPPER(ADDRESS) LIKE UPPER('TULUNAN') THEN 23 
                                                WHEN UPPER(ADDRESS) LIKE UPPER('PARANG') THEN 24 
                                                WHEN UPPER(ADDRESS) LIKE UPPER('BULUAN') THEN 25 
                                                WHEN UPPER(ADDRESS) LIKE UPPER('UPI') THEN 26 
                                                WHEN UPPER(ADDRESS) LIKE UPPER('SHARIFF') THEN 27 
                                                WHEN UPPER(ADDRESS) LIKE UPPER('DAVAO') THEN 28 
                                                WHEN UPPER(ADDRESS) LIKE UPPER('SARANGANI') THEN 29 
                                                WHEN UPPER(ADDRESS) LIKE UPPER('SURIGAO') THEN 30 
                                                WHEN UPPER(ADDRESS) LIKE UPPER('BUTUAN') THEN 31  
                                                WHEN UPPER(ADDRESS) LIKE UPPER('CAGAYAN') THEN 32  
                                                ELSE 33 END"

        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_PAYOUT")
            If ds.Tables(0).Rows.Count > 0 Then

                progressBarStart(ds.Tables(0).Rows.Count)
                For Each dr In ds.Tables(0).Rows
                    With dr

                        '============================= NAME AND ATTENDANCE ============================  
                        Dim COMPANY As String = "DALTON"
                        Dim ADDRESS As String = IIf(IsDBNull(.Item("ADDRESS")), "", .Item("ADDRESS"))
                        Dim CATEGORY As String = IIf(IsDBNull(.Item("CATEGORY")), "", .Item("CATEGORY"))
                        Dim BRANCHCODE As String = IIf(IsDBNull(.Item("BRANCHCODE")), "", .Item("BRANCHCODE"))
                        Dim HO_CATEGORY As String = IIf(IsDBNull(.Item("HO_CATEGORY")), "", .Item("HO_CATEGORY"))
                        Dim EMAIL As Decimal

                        Dim BRANCH_LIST As String = GetList_Branch(ADDRESS, $"COMPANY = '{COMPANY}'")

                        If BRANCH_LIST <> Nothing Then
                            EMAIL = GetSummary_Email(PAYROLL, $"BRANCH_CODE In ({BRANCH_LIST}) AND COMPANY = '{COMPANY}' AND ADDRESS = '{ADDRESS}'")
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

        mysql = $"Select * From PAYROLL_PAYOUT A  
                                        INNER JOIN PAYROLL_EMPLOYEE C ON BIO_NO = BIOMETRIC_ID    
                                        LEFT JOIN PAYROLL_CITY_BRANCH B ON BRANCHCODE = BRANCH_CODE    
                                        WHERE PAYDATE = '{paydate}' AND COMPANY  = 'PERFECOM'
                                            OR (HO_CATEGORY LIKE 'Perfecom%' AND  PAYDATE = '{paydate}')
                                        ORDER BY CASE WHEN UPPER(HO_CATEGORY) LIKE UPPER('%Admin%') THEN 0  
                                                WHEN UPPER(ADDRESS) LIKE UPPER('GENSAN') THEN 1   
                                                WHEN UPPER(ADDRESS) LIKE UPPER('MARBEL') THEN 2 
                                                WHEN UPPER(ADDRESS) LIKE UPPER('ZAMBOANGA') THEN 3 END"

        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_PAYOUT")
            If ds.Tables(0).Rows.Count > 0 Then

                progressBarStart(ds.Tables(0).Rows.Count)
                For Each dr In ds.Tables(0).Rows
                    With dr

                        '============================= NAME AND ATTENDANCE ============================  
                        Dim COMPANY As String = "PERFECOM"
                        Dim ADDRESS As String = IIf(IsDBNull(.Item("ADDRESS")), "", .Item("ADDRESS"))
                        Dim CATEGORY As String = IIf(IsDBNull(.Item("CATEGORY")), "", .Item("CATEGORY"))
                        Dim BRANCHCODE As String = IIf(IsDBNull(.Item("BRANCHCODE")), "", .Item("BRANCHCODE"))
                        Dim HO_CATEGORY As String = IIf(IsDBNull(.Item("HO_CATEGORY")), "", .Item("HO_CATEGORY"))
                        Dim EMAIL As Decimal

                        Dim BRANCH_LIST As String = GetList_Branch(ADDRESS, $"COMPANY = '{COMPANY}'")

                        If BRANCH_LIST <> Nothing Then
                            EMAIL = GetSummary_Email(PAYROLL, $"BRANCH_CODE In ({BRANCH_LIST}) AND COMPANY = '{COMPANY}' AND ADDRESS = '{ADDRESS}'")
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

        mysql = $"Select * From PAYROLL_PAYOUT A  
                                        INNER JOIN PAYROLL_EMPLOYEE C ON BIO_NO = BIOMETRIC_ID     
                                        LEFT JOIN PAYROLL_CITY_BRANCH B ON BRANCHCODE = BRANCH_CODE      
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
                        Dim ADDRESS As String = IIf(IsDBNull(.Item("ADDRESS")), "", .Item("ADDRESS"))
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

        Dim mysqll As String = $"Select * From PAYROLL_EMPLOYEE A  
                                        INNER JOIN PAYROLL_PAYOUT C ON A.BIO_NO = C.BIOMETRIC_ID
                                        where BIO_NO = '2788' AND PAYDATE = '{paydate}'"

        Using ds As DataSet = LoadSQL(mysqll, "PAYROLL_EMPLOYEE")
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

        Dim mysqll As String = $"Select * From PAYROLL_EMPLOYEE A 
                                        INNER JOIN PAYROLL_PERCENTAGEE B ON B.CATEGORY = A.COMMON_CATEGORY
                                        INNER JOIN PAYROLL_PAYOUT C ON A.BIO_NO = C.BIOMETRIC_ID
                                        where PAYDATE = '{paydate}' AND HO_CATEGORY = 'PGC Head Office' OR (HO_CATEGORY IN ('Construction', 'Leasing Admin Office') AND PAYDATE = '{paydate}')
                                          ORDER BY FULLNAME ASC"

        Using ds As DataSet = LoadSQL(mysqll, "PAYROLL_EMPLOYEE")
            If ds.Tables(0).Rows.Count > 0 Then

                progressBarStart(ds.Tables(0).Rows.Count)
                For Each dr In ds.Tables(0).Rows
                    With dr

                        '============================= NAME AND ATTENDANCE ============================  
                        Dim namee As String = .Item("FULLNAME")
                        Dim CATEGORY As String = .Item("CATEGORY")
                        Dim NET_PAY As Decimal = .Item("NET_PAY")
                        Dim LEASING As String = .Item("LEASING")

                        If .ITEM("BIO_NO") = "2788" Then ' MADERA  
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
        Dim TOTALS As Decimal = 0
        Dim G3_tot As Decimal = 0
        Dim Seven11_tot As Decimal = 0
        Dim COMI_TO_FUJI_tot As Decimal = 0

        Dim mysqll As String = $"Select * From PAYROLL_EMPLOYEE A 
                                        INNER JOIN PAYROLL_PERCENTAGEE B ON B.CATEGORY = A.COMMON_CATEGORY
                                        INNER JOIN PAYROLL_PAYOUT C ON A.BIO_NO = C.BIOMETRIC_ID
                                        where  PAYDATE = '{paydate}' AND HO_CATEGORY = 'PGC Head Office' 
                                            OR (HO_CATEGORY IN ('Construction', 'Leasing Admin Office') AND  PAYDATE = '{paydate}')
                                            ORDER BY FULLNAME ASC"

        Using ds As DataSet = LoadSQL(mysqll, "PAYROLL_EMPLOYEE")
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

                        If .ITEM("BIO_NO") = "2788" Then ' MADERA 
                            VALUEE = (50 * VALUEE) / 100
                        End If

                        If column = "COMI_TO_FUJI" Then ' P&G UY SONS

                            If .ITEM("BIO_NO") = "2788" Then ' MADERA  
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

        Dim dt_Remittance As New DataTable()
        With dt_Remittance
            .Columns.Add("NAME")
            .Columns.Add("NO")
            .Columns.Add("EE")
            .Columns.Add("ER")
            .Columns.Add("EC")
        End With

        mysql = $"Select * From PAYROLL_PAYOUT INNER JOIN PAYROLL_EMPLOYEE ON BIO_NO = BIOMETRIC_ID       
                                        WHERE PAYDATE = '{paydate}' and {str} ORDER BY FULLNAME"

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

                        dt_Remittance.Rows.Add(FULLNAME, NOO, EE, ER, EC)

                        frmMainForm.AppProgressBar.Value += 1
                    End With

                Next
                progressBarEnd()
            Else

            End If
        End Using

        Return dt_Remittance
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
        End With

        mysql = $"Select * From PAYROLL_PAYOUT INNER JOIN PAYROLL_EMPLOYEE ON BIO_NO = BIOMETRIC_ID       
                                        WHERE PAYDATE = '{paydate}' and {str}  ORDER BY FULLNAME"

        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_PAYOUT")
            If ds.Tables(0).Rows.Count > 0 Then

                progressBarStart(ds.Tables(0).Rows.Count)
                For Each dr In ds.Tables(0).Rows
                    With dr

                        '============================= NAME AND ATTENDANCE ============================  
                        Dim FULLNAME As String = IIf(IsDBNull(.Item("FULLNAME")), "", .Item("FULLNAME"))
                        Dim monthly_Basic As Decimal = GetMonthly_Basic(.item("BIOMETRIC_ID"), paydate)

                        Dim NOO As String = IIf(IsDBNull(.Item("PAGIBIGNO")), "", .Item("PAGIBIGNO"))
                        Dim EE As String = Get_Pagibig(monthly_Basic)

                        dt_Remittance.Rows.Add(FULLNAME, NOO, EE, EE)

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
        End With

        mysql = $"Select * From PAYROLL_PAYOUT INNER JOIN PAYROLL_EMPLOYEE ON BIO_NO = BIOMETRIC_ID       
                                        WHERE PAYDATE = '{paydate}' and {str}  ORDER BY FULLNAME"

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

                        dt_Remittance.Rows.Add(FULLNAME, NOO, EE, EE)

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
        Dim mysql As String = $"Select BRANCHCODE from PAYROLL_CITY_BRANCH 
                                inner join PAYROLL_EMPLOYEE ON BRANCHCODE = BRANCH_CODE 
                                where address = '{address}' and {str}"
        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_CITY_BRANCH")
            If ds.Tables(0).Rows.Count > 0 Then
                For Each dr In ds.Tables(0).Rows
                    With dr
                        branch_group.Add($"'{ .item("BRANCHCODE")}'")
                    End With
                Next
            End If
        End Using

        branch_group = branch_group.Distinct().ToList

        Dim list_String As String = String.Join(",", branch_group)

        Return list_String
    End Function

    'Has_Rows_Delete("PAYROLL_EMPLOYEE")

    Public Sub Check_This()

        Dim mysql As String = $"Select * FROM  RECORDED_ALLOW_DEDUC "

        Using ds As DataSet = LoadSQL(mysql, "RECORDED_ALLOW_DEDUC")
            If ds.Tables(0).Rows.Count > 0 Then
                For Each DR In ds.Tables(0).Rows
                    With DR
                        Dim AMOUNT As Decimal = .Item("AMOUNTT")
                        Dim CATEGORY As String = .Item("CATEGORY")

                        update_rECORD_ALLOW_DEDUC(.Item("BIO_NO"), AMOUNT, CATEGORY)
                    End With
                Next
            End If
        End Using

        'Dim mysql As String = $"Select * FROM PAYROLL_EMPLOYEE B 
        '                           INNER Join PAYROLL_13MONTH C ON C.EMP_NO = B.EMP_NO"

        'Using ds As DataSet = LoadSQL(mysql, "PAYROLL_EMPLOYEE")
        '    If ds.Tables(0).Rows.Count > 0 Then
        '        For Each DR In ds.Tables(0).Rows
        '            With DR
        '                Dim AMOUNT As Decimal = .Item("AMOUNT")

        '                update_13thMonth(.Item("BIO_NO"), AMOUNT, "13th Month Pay")
        '            End With
        '        Next
        '    End If
        'End Using

        'Dim mysql As String = $"Select Sum(TOTAL_LATE_UT) as tots From payroll_payout B inner join payroll_employee A on B.BIOMETRIC_ID = A.bio_no 
        '                        WHERE HO_CATEGORY = 'PGC Head Office' "

        'Using ds As DataSet = LoadSQL(mysql, "payroll_employee")
        '    If ds.Tables(0).Rows.Count > 0 Then
        '        For Each DR In ds.Tables(0).Rows
        '            With DR

        '                Dim asas As String = .Item("tots")
        '                MsgBox(asas)

        '                'MsgBox(asas.ToString("N"))

        '                'SAVEE(.item("BIOMETRIC_ID"), .item("TOTAL_LATE_UT"))
        '            End With
        '        Next
        '    End If
        'End Using

    End Sub

    Public Sub update_rECORD_ALLOW_DEDUC(BIO As String, AMOUNT As String, CATEGORY As String)

        Dim sql As String = $"Select * From RECORDED_ALLOW_DEDUC where BIO_NO = '{BIO}' AND CATEGORY = '{CATEGORY}'"
        Using ds As DataSet = LoadSQL(sql, "RECORDED_ALLOW_DEDUC")
            If ds.Tables(0).Rows.Count > 0 Then
                Dim dsNewRow As DataRow = ds.Tables(0).Rows(0)
                With dsNewRow

                    .Item("AMOUNT") = AMOUNT

                End With
                SaveEntry(ds, False)
            End If
        End Using

    End Sub

    Public Sub update_13thMonth(BIO As String, AMOUNT As String, CATEGORY As String)

        Dim sql As String = $"Select * From RECORDED_ALLOW_DEDUC where BIO_NO = '{BIO}' AND CATEGORY = '{CATEGORY}'"
        Using ds As DataSet = LoadSQL(sql, "RECORDED_ALLOW_DEDUC")
            If ds.Tables(0).Rows.Count > 0 Then
                Dim dsNewRow As DataRow = ds.Tables(0).Rows(0)
                With dsNewRow

                    .Item("AMOUNT") = AMOUNT

                End With
                SaveEntry(ds, False)
            End If
        End Using

    End Sub

    'Public Sub SAVEE(BIO As String, LASTE As String)

    '    Dim mysqlL As String = $"Select * FROM PAYROLL_PAYOUT where BIOMETRIC_ID = '{BIO}' and PAYDATE = '9/15/2021'"
    '    Dim dss As DataSet = LoadSQL(mysqlL, "PAYROLL_PAYOUT")
    '    If dss.Tables(0).Rows.Count > 0 Then
    '        For Each dr In dss.Tables(0).Rows
    '            With dr

    '                .Item("TOTAL_LATE_UTT") = LASTE

    '    End With
    '    dss.Tables(0).Rows.Add(DSnEW)
    '    SaveEntry(dss)

    'End Sub

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

    Public Sub SAVE_ALLATTENDANCE()

        Has_Rows_Delete("TEMP_ATTENDANCE")

        Dim mysql As String = $"Select * From PAYROLL_ATTENDANCE"
        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_ATTENDANCE")
            If ds.Tables(0).Rows.Count > 0 Then
                For Each dr In ds.Tables(0).Rows
                    With dr

                        Dim TRAINING_DAYS = IIf(IsDBNull(.Item("TRAINING_DAYS")), 0, .Item("TRAINING_DAYS"))
                        Dim TRAINING_REGHOLIDAY = IIf(IsDBNull(.Item("TRAINING_REGHOLIDAY")), 0, .Item("TRAINING_REGHOLIDAY"))
                        Dim TRAINING_SPECHOLIDAY = IIf(IsDBNull(.Item("TRAINING_SPECHOLIDAY")), 0, .Item("TRAINING_SPECHOLIDAY"))
                        Dim NIGHT_RATE = IIf(IsDBNull(.Item("NIGHT_RATE")), 0, .Item("NIGHT_RATE"))

                        GetTempAttendance(.Item("BIOMETRICID"), .Item("PAYDATE"), .Item("PRESENT_DAYS"), .Item("OVERTIME"),
                                                .Item("LATE"), .Item("UNDERTIME"), .Item("REGHOLIDAY"), .Item("SPECHOLIDAY"),
                                                TRAINING_DAYS, TRAINING_REGHOLIDAY, TRAINING_SPECHOLIDAY, NIGHT_RATE)

                        frmMainForm.AppProgressBar.Value += 1
                    End With
                Next
            End If
        End Using

        progressBarEnd()
    End Sub

    Friend Sub GetTempAttendance(BIOMETRICID As String, paydate_ As String, TotalDays As String, TotalOTHr As String,
                                    Late_Total As String, Under_Total As String, TotalRHoliday As String, TotalSHoliday As String,
                                    TRAINING_DAYS As String, TRAINING_REGHOLIDAY As String, TRAINING_SPECHOLIDAY As String,
                                    NIGHT_RATE As String)

        Dim mysql As String = "Select * From TEMP_ATTENDANCE Rows 1"
        Using ds As DataSet = LoadSQL(mysql, "TEMP_ATTENDANCE")

            Dim dsNewRow As DataRow = ds.Tables(0).NewRow
            With dsNewRow
                .Item("BIOMETRICID") = BIOMETRICID
                .Item("PAYDATE") = paydate_
                .Item("PRESENT_DAYS") = TotalDays
                .Item("OVERTIME") = TotalOTHr
                .Item("LATE") = Late_Total
                .Item("UNDERTIME") = Under_Total
                .Item("REGHOLIDAY") = TotalRHoliday
                .Item("SPECHOLIDAY") = TotalSHoliday
                .Item("TRAINING_DAYS") = TRAINING_DAYS
                .Item("TRAINING_REGHOLIDAY") = TRAINING_REGHOLIDAY
                .Item("TRAINING_SPECHOLIDAY") = TRAINING_SPECHOLIDAY
                .Item("NIGHT_RATE") = NIGHT_RATE
            End With
            ds.Tables(0).Rows.Add(dsNewRow)
            SaveEntry(ds)
        End Using
    End Sub

End Module
