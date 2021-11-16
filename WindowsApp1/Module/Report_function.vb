Imports System.Globalization

Module Report_function

    Friend Function LoadDataTable_GensanJR(paydate As String) As DataTable

        Dim mysql As String
        Dim PAYROLL As DateTime = paydate
        Dim info As TextInfo = CultureInfo.InvariantCulture.TextInfo ' === TITLE CASE ADDRESS
        Dim total_email As Double = 0

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
                                        WHERE PAYDATE = '{paydate}' 
                                            AND BRANCHCODE IN ('DIG','ISU','M1','POL', 'ROG','ROX','FINEPIX','COT','MID','KID','SNP','GMA','SML','ZAM','SMD')
                                            OR HO_CATEGORY LIKE 'Photo%' OR (HO_CATEGORY LIKE 'PGC%' and COMMON_COMPANY = 'PHOTO') 
                                        ORDER BY CASE WHEN UPPER(HO_CATEGORY) LIKE UPPER('PGC%') THEN 0
                                                WHEN UPPER(HO_CATEGORY) LIKE UPPER('%Admin%') THEN 1 
                                                WHEN UPPER(HO_CATEGORY) LIKE UPPER('%Retail%') THEN 2 
                                                WHEN UPPER(ADDRESS) LIKE UPPER('GENSAN') THEN 3 
                                                WHEN UPPER(ADDRESS) LIKE UPPER('POLOMOLOK') THEN 4 
                                                WHEN UPPER(ADDRESS) LIKE UPPER('MARBEL') THEN 5 
                                                WHEN UPPER(ADDRESS) LIKE UPPER('ISULAN') THEN 6 
                                                WHEN UPPER(ADDRESS) LIKE UPPER('COTABATO') THEN 7 
                                                WHEN UPPER(ADDRESS) LIKE UPPER('KIDAPAWAN') THEN 8 
                                                WHEN UPPER(ADDRESS) LIKE UPPER('MIDSAYAP') THEN 9 
                                                WHEN UPPER(ADDRESS) LIKE UPPER('DAVAO') THEN 10 
                                                WHEN UPPER(ADDRESS) LIKE UPPER('SM SAN LAZARO') THEN 11 
                                                WHEN UPPER(ADDRESS) LIKE UPPER('ZAMBOANGA') THEN 12  
                                                END"

        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_PAYOUT")
            If ds.Tables(0).Rows.Count > 0 Then
                For Each dr In ds.Tables(0).Rows
                    With dr

                        '============================= NAME AND ATTENDANCE ============================  
                        Dim COMPANY As String
                        Dim ADDRESS As String = IIf(IsDBNull(.Item("ADDRESS")), "", .Item("ADDRESS"))
                        Dim CATEGORY As String = IIf(IsDBNull(.Item("CATEGORY")), "", .Item("CATEGORY"))
                        Dim BRANCHCODE As String = IIf(IsDBNull(.Item("BRANCHCODE")), "", .Item("BRANCHCODE"))
                        Dim HO_CATEGORY As String = IIf(IsDBNull(.Item("HO_CATEGORY")), "", .Item("HO_CATEGORY"))
                        Dim EMAIL As Double = GetSummary_Email(PAYROLL, $"BRANCH_CODE = '{BRANCHCODE}'")
                        Dim HO_array As String() = HO_CATEGORY.Split(New Char() {" "c}) '=== ADMIN   
                        ADDRESS = ADDRESS.ToLower()

                        If HO_CATEGORY.Contains("Photo") Then
                            ADDRESS = $"Admin {HO_array.Last}"
                            EMAIL = GetSummary_Email(PAYROLL, $"HO_CATEGORY = '{HO_CATEGORY}'")
                        End If

                        If HO_CATEGORY.Contains("PGC") Then
                            ADDRESS = $"PGC"
                            EMAIL = GetSummary_Email(PAYROLL, $"HO_CATEGORY = '{HO_CATEGORY}' AND COMMON_COMPANY = 'PHOTO'")
                        End If

                        COMPANY = "PHOTO(GENSAN PERFECT/JR PHOTO)"

                        dt_PhotoGensanJR.Rows.Add(PAYROLL.ToString("MMMM dd, yyyy").ToUpper(), COMPANY,
                                                  info.ToTitleCase(ADDRESS), EMAIL.ToString("n"), 0, 0, 0)

                    End With
                Next
            End If
        End Using

        Return dt_PhotoGensanJR
    End Function

    Friend Function LoadDataTable_DavaoPerfect(paydate As String) As DataTable

        Dim mysql As String
        Dim PAYROLL As DateTime = paydate
        Dim info As TextInfo = CultureInfo.InvariantCulture.TextInfo ' === TITLE CASE ADDRESS
        Dim total_email As Double = 0

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
                                        WHERE PAYDATE = '{paydate}' 
                                            AND BRANCHCODE IN ('SMG','KCG','ACM','TAC') 
                                            OR (HO_CATEGORY LIKE 'PGC%' and COMMON_COMPANY = 'PHOTO') 
                                        ORDER BY CASE WHEN HO_CATEGORY LIKE 'PGC%' THEN 0 
                                                WHEN ADDRESS = 'GENSAN' THEN 1  
                                                WHEN ADDRESS = 'MARBEL' THEN 2    
                                                else 3 END"

        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_PAYOUT")
            If ds.Tables(0).Rows.Count > 0 Then
                For Each dr In ds.Tables(0).Rows
                    With dr

                        '============================= NAME AND ATTENDANCE ============================  
                        Dim COMPANY As String
                        Dim ADDRESS As String = IIf(IsDBNull(.Item("ADDRESS")), "", .Item("ADDRESS"))
                        Dim CATEGORY As String = IIf(IsDBNull(.Item("CATEGORY")), "", .Item("CATEGORY"))
                        Dim BRANCHCODE As String = IIf(IsDBNull(.Item("BRANCHCODE")), "", .Item("BRANCHCODE"))
                        Dim HO_CATEGORY As String = IIf(IsDBNull(.Item("HO_CATEGORY")), "", .Item("HO_CATEGORY"))
                        Dim EMAIL As Double = GetSummary_Email(PAYROLL, $"BRANCH_CODE = '{BRANCHCODE}'")
                        Dim HO_array As String() = HO_CATEGORY.Split(New Char() {" "c}) '=== ADMIN   
                        ADDRESS = ADDRESS.ToLower()

                        If HO_CATEGORY.Contains("PGC") Then
                            ADDRESS = $"PGC"
                            EMAIL = GetSummary_Email(PAYROLL, $"HO_CATEGORY = '{HO_CATEGORY}' AND COMMON_COMPANY = 'PHOTO'")
                        End If

                        COMPANY = $"PHOTO(DAVAO PERFECT)"

                        dt_PhotoDavao.Rows.Add(PAYROLL.ToString("MMMM dd, yyyy").ToUpper(), COMPANY,
                                               info.ToTitleCase(ADDRESS), EMAIL.ToString("n"), 0, 0, 0)

                    End With
                Next
            End If
        End Using

        Return dt_PhotoDavao
    End Function

    Friend Function LoadDataTable_Dalton(paydate As String) As DataTable

        Dim mysql As String
        Dim PAYROLL As DateTime = paydate
        Dim info As TextInfo = CultureInfo.InvariantCulture.TextInfo ' === TITLE CASE ADDRESS
        Dim total_email As Double = 0

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
                                            OR (HO_CATEGORY LIKE 'PGC%' and COMMON_COMPANY = 'DALTON') 
                                        ORDER BY CASE WHEN UPPER(HO_CATEGORY) LIKE UPPER('PGC%') THEN 0 
                                                WHEN UPPER(HO_CATEGORY) LIKE UPPER('%Admin%') THEN 1 
                                                WHEN UPPER(HO_CATEGORY) LIKE UPPER('%Retail%') THEN 2 
                                                WHEN UPPER(ADDRESS) LIKE UPPER('GENSAN') THEN 3  
                                                WHEN UPPER(ADDRESS) LIKE UPPER('POLOMOLOK') THEN 4 
                                                WHEN UPPER(ADDRESS) LIKE UPPER('MARBEL') THEN 5 
                                                WHEN UPPER(ADDRESS) LIKE UPPER('ISULAN') THEN 6 
                                                WHEN UPPER(ADDRESS) LIKE UPPER('TACURONG') THEN 7 
                                                WHEN UPPER(ADDRESS) LIKE UPPER('SURALLAH') THEN 8 
                                                WHEN UPPER(ADDRESS) LIKE UPPER('BANGA') THEN 9 
                                                WHEN UPPER(ADDRESS) LIKE UPPER('TBOLI') THEN 10 
                                                WHEN UPPER(ADDRESS) LIKE UPPER('ESPERANZA') THEN 11 
                                                WHEN UPPER(ADDRESS) LIKE UPPER('KALAMANSIG') THEN 12  
                                                WHEN UPPER(ADDRESS) LIKE UPPER('LAMBAYONG') THEN 13  
                                                WHEN UPPER(ADDRESS) LIKE UPPER('LEBAK') THEN 14  
                                                WHEN UPPER(ADDRESS) LIKE UPPER('AWANG') THEN 15  
                                                WHEN UPPER(ADDRESS) LIKE UPPER('DALICAN') THEN 16  
                                                WHEN UPPER(ADDRESS) LIKE UPPER('COTABATO') THEN 17  
                                                WHEN UPPER(ADDRESS) LIKE UPPER('KIDAPAWAN') THEN 18  
                                                WHEN UPPER(ADDRESS) LIKE UPPER('KIDAPAWAN') THEN 19   
                                                WHEN UPPER(ADDRESS) LIKE UPPER('MIDSAYAP') THEN 20 
                                                WHEN UPPER(ADDRESS) LIKE UPPER('KABACAN') THEN 21 
                                                WHEN UPPER(ADDRESS) LIKE UPPER('PIKIT') THEN 22 
                                                WHEN UPPER(ADDRESS) LIKE UPPER('MLANG') THEN 23 
                                                WHEN UPPER(ADDRESS) LIKE UPPER('TULUNAN') THEN 24 
                                                WHEN UPPER(ADDRESS) LIKE UPPER('PARANG') THEN 25 
                                                WHEN UPPER(ADDRESS) LIKE UPPER('BULUAN') THEN 26 
                                                WHEN UPPER(ADDRESS) LIKE UPPER('UPI') THEN 27 
                                                WHEN UPPER(ADDRESS) LIKE UPPER('SHARIFF') THEN 28 
                                                WHEN UPPER(ADDRESS) LIKE UPPER('DAVAO') THEN 29 
                                                WHEN UPPER(ADDRESS) LIKE UPPER('SARANGANI') THEN 30 
                                                WHEN UPPER(ADDRESS) LIKE UPPER('SURIGAO') THEN 31 
                                                WHEN UPPER(ADDRESS) LIKE UPPER('BUTUAN') THEN 32  
                                                WHEN UPPER(ADDRESS) LIKE UPPER('CAGAYAN') THEN 33  
                                                ELSE 34 END"

        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_PAYOUT")
            If ds.Tables(0).Rows.Count > 0 Then
                For Each dr In ds.Tables(0).Rows
                    With dr

                        '============================= NAME AND ATTENDANCE ============================  
                        Dim COMPANY As String
                        Dim ADDRESS As String = IIf(IsDBNull(.Item("ADDRESS")), "", .Item("ADDRESS"))
                        Dim CATEGORY As String = IIf(IsDBNull(.Item("CATEGORY")), "", .Item("CATEGORY"))
                        Dim BRANCHCODE As String = IIf(IsDBNull(.Item("BRANCHCODE")), "", .Item("BRANCHCODE"))
                        Dim HO_CATEGORY As String = IIf(IsDBNull(.Item("HO_CATEGORY")), "", .Item("HO_CATEGORY"))
                        Dim EMAIL As Double = GetSummary_Email(PAYROLL, $"BRANCH_CODE = '{BRANCHCODE}'")
                        Dim HO_array As String() = HO_CATEGORY.Split(New Char() {" "c}) '=== ADMIN   
                        ADDRESS = ADDRESS.ToLower()

                        If HO_CATEGORY.Contains("Dalton") Then
                            ADDRESS = $"Admin {HO_array.Last}"
                            EMAIL = GetSummary_Email(PAYROLL, $"HO_CATEGORY = '{HO_CATEGORY}'")
                        End If

                        If HO_CATEGORY.Contains("PGC") Then
                            ADDRESS = $"PGC"
                            EMAIL = GetSummary_Email(PAYROLL, $"HO_CATEGORY = '{HO_CATEGORY}' AND COMMON_COMPANY = 'DALTON'")
                        End If

                        COMPANY = "DALTON"

                        dt_Dalton.Rows.Add(PAYROLL.ToString("MMMM dd, yyyy").ToUpper(), COMPANY,
                                               info.ToTitleCase(ADDRESS), EMAIL.ToString("n"), 0, 0, 0)

                    End With
                Next
            End If
        End Using

        Return dt_Dalton
    End Function

    Friend Function LoadDataTable_Perfecom(paydate As String) As DataTable

        Dim mysql As String
        Dim PAYROLL As DateTime = paydate
        Dim info As TextInfo = CultureInfo.InvariantCulture.TextInfo ' === TITLE CASE ADDRESS
        Dim total_email As Double = 0

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
                                            OR HO_CATEGORY LIKE 'Perfecom%' OR (HO_CATEGORY LIKE 'PGC%' and COMMON_COMPANY = 'PERFECOM') 
                                        ORDER BY CASE WHEN UPPER(HO_CATEGORY) LIKE UPPER('PGC%') THEN 0 
                                                WHEN UPPER(HO_CATEGORY) LIKE UPPER('%Admin%') THEN 1  
                                                WHEN UPPER(ADDRESS) LIKE UPPER('GENSAN') THEN 2   
                                                WHEN UPPER(ADDRESS) LIKE UPPER('MARBEL') THEN 3 
                                                WHEN UPPER(ADDRESS) LIKE UPPER('ZAMBOANGA') THEN 4 END"

        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_PAYOUT")
            If ds.Tables(0).Rows.Count > 0 Then
                For Each dr In ds.Tables(0).Rows
                    With dr

                        '============================= NAME AND ATTENDANCE ============================  
                        Dim COMPANY As String
                        Dim ADDRESS As String = IIf(IsDBNull(.Item("ADDRESS")), "", .Item("ADDRESS"))
                        Dim CATEGORY As String = IIf(IsDBNull(.Item("CATEGORY")), "", .Item("CATEGORY"))
                        Dim BRANCHCODE As String = IIf(IsDBNull(.Item("BRANCHCODE")), "", .Item("BRANCHCODE"))
                        Dim HO_CATEGORY As String = IIf(IsDBNull(.Item("HO_CATEGORY")), "", .Item("HO_CATEGORY"))
                        Dim EMAIL As Double = GetSummary_Email(PAYROLL, $"BRANCH_CODE = '{BRANCHCODE}'")
                        Dim HO_array As String() = HO_CATEGORY.Split(New Char() {" "c}) '=== ADMIN   
                        ADDRESS = ADDRESS.ToLower()

                        If HO_CATEGORY.Contains("Perfecom") Then
                            ADDRESS = $"Admin {HO_array.Last}"
                            EMAIL = GetSummary_Email(PAYROLL, $"HO_CATEGORY = '{HO_CATEGORY}'")
                        End If

                        If HO_CATEGORY.Contains("PGC") Then
                            ADDRESS = $"PGC"
                            EMAIL = GetSummary_Email(PAYROLL, $"HO_CATEGORY = '{HO_CATEGORY}' AND COMMON_COMPANY = 'PERFECOM'")
                        End If

                        COMPANY = "PERFECOM"

                        dt_Dalton.Rows.Add(PAYROLL.ToString("MMMM dd, yyyy").ToUpper(), COMPANY,
                                               info.ToTitleCase(ADDRESS), EMAIL.ToString("n"), 0, 0, 0)

                    End With
                Next
            End If
        End Using

        Return dt_Dalton
    End Function

    Friend Function LoadDataTable_PG_UY(paydate As String) As DataTable

        Dim mysql As String
        Dim PAYROLL As DateTime = paydate
        Dim info As TextInfo = CultureInfo.InvariantCulture.TextInfo ' === TITLE CASE ADDRESS
        Dim total_email As Double = 0

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
                                            OR HO_CATEGORY LIKE 'GHS/P&G UY%' OR (HO_CATEGORY LIKE 'PGC%' and COMMON_COMPANY = 'P&G UY') 
                                        ORDER BY CASE WHEN UPPER(HO_CATEGORY) LIKE UPPER('PGC%') THEN 0 
                                                WHEN UPPER(HO_CATEGORY) LIKE UPPER('%Admin%') THEN 1  
                                                WHEN BRANCHCODE = '3G' THEN 2   
                                                WHEN BRANCHNAME LIKE '7 Eleven' THEN 3   
                                                WHEN BRANCHCODE = 'COMI' THEN 4 
                                                WHEN BRANCHCODE = 'KTV' THEN 5 
                                                WHEN BRANCHCODE = 'PBA' THEN 6 
                                                WHEN BRANCHCODE = 'WAVE' THEN 7 END"

        Using ds As DataSet = LoadSQL(mysql, "PAYROLL_PAYOUT")
            If ds.Tables(0).Rows.Count > 0 Then
                For Each dr In ds.Tables(0).Rows
                    With dr

                        '============================= NAME AND ATTENDANCE ============================  
                        Dim COMPANY As String
                        Dim ADDRESS As String = IIf(IsDBNull(.Item("ADDRESS")), "", .Item("ADDRESS"))
                        Dim CATEGORY As String = IIf(IsDBNull(.Item("CATEGORY")), "", .Item("CATEGORY"))
                        Dim BRANCHCODE As String = IIf(IsDBNull(.Item("BRANCHCODE")), "", .Item("BRANCHCODE"))
                        Dim HO_CATEGORY As String = IIf(IsDBNull(.Item("HO_CATEGORY")), "", .Item("HO_CATEGORY"))
                        Dim EMAIL As Double = GetSummary_Email(PAYROLL, $"BRANCH_CODE = '{BRANCHCODE}'")
                        Dim HO_array As String() = HO_CATEGORY.Split(New Char() {" "c}) '=== ADMIN   
                        ADDRESS = ADDRESS.ToLower()

                        If HO_CATEGORY.Contains("GHS") Then
                            ADDRESS = $"Admin {HO_array.Last}"
                            EMAIL = GetSummary_Email(PAYROLL, $"HO_CATEGORY = '{HO_CATEGORY}'")
                        End If

                        If HO_CATEGORY.Contains("PGC") Then
                            ADDRESS = $"PGC"
                            EMAIL = GetSummary_Email(PAYROLL, $"HO_CATEGORY = '{HO_CATEGORY}' AND COMMON_COMPANY = 'P&G UY'")
                        End If

                        COMPANY = "P & G UY SONS/GHS"

                        dt_Dalton.Rows.Add(PAYROLL.ToString("MMMM dd, yyyy").ToUpper(), COMPANY,
                                               info.ToTitleCase(ADDRESS), EMAIL.ToString("n"), 0, 0, 0)

                    End With
                Next
            End If
        End Using

        Return dt_Dalton
    End Function

End Module
