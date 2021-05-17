Imports System.Globalization
Imports System.IO

Module Developer
    Friend Sub UpdateTablesImagesToFolder()

        '==========================TBL_EMPLOYEE ADD(POSITION AND BRANCH)=========================
        RunCommand("ALTER TABLE tbl_Employee ADD EMP_POSITION varchar(50) NOT NULL;") ' ADD TABLE COLUMNS - EMP_POSITION AND BRANCH_ID 
        RunCommand("ALTER TABLE tbl_Employee ADD BRANCH_ID SMALLINT NOT NULL;")

        MessageBox.Show("COLUMN - Position and Branch Successfully Added to TABLE_EMPLOYEE .")

        '==========================TBL_EMPLOYEE ADD(RATE, FIX_RATE, NUMBER OF DAYS)=========================
        RunCommand("ALTER TABLE TBL_EMPLOYEE ADD EMP_RATE DECIMAL(12, 2) DEFAULT 0 NOT NULL;")
        RunCommand("ALTER TABLE TBL_EMPLOYEE ADD FIX_RATE VARCHAR(5) DEFAULT 'NO' NOT NULL;;")
        RunCommand("ALTER TABLE TBL_EMPLOYEE ADD NO_OF_DAYS COMPUTED BY ( DateDiff(Day, DATEHIRED, CURRENT_TIMESTAMP)  );")

        MessageBox.Show("COLUMN - Rate, Fix_Rate, No_Of_Days Successfully Added to TABLE_EMPLOYEE .")

        '==========================TBL_EMPLOYEE UPDATE(STATUS LENGTH OF VARCHAR)=========================
        RunCommand(" ALTER TABLE TBL_EMPLOYEE ALTER COLUMN STATUS Type VARCHAR(25);")

        '==========================TBL_EMPLOYEE UPDATE(POSITION AND STATUS FROM TBLMANNING)=========================
        Dim mysql = "Select * From TBLMANNING INNER JOIN TBL_EMPLOYEE ON TBLMANNING.EMP_ID = TBL_EMPLOYEE.ID"
        Using ds As DataSet = LoadSQL(mysql)

            If ds.Tables(0).Rows.Count > 0 Then

                For Each dr As DataRow In ds.Tables(0).Rows
                    With dr
                        Dim mysqlL As String = "Select * From tbl_Employee Where ID = '" & dr.Item("EMP_ID") & "'"
                        Using dsS As DataSet = LoadSQL(mysqlL, "tbl_Employee")

                            For Each drr As DataRow In dsS.Tables(0).Rows
                                With drr
                                    If Not IsDBNull(.Item("ASSIGN_STATUS")) Then
                                        .Item("EMP_POSITION") = dr.Item("EMP_POSITION")
                                        .Item("BRANCH_ID") = dr.Item("BRANCH_ID")


                                        '==========================TBL_EMPLOYEE UPDATE(STATUS FROM REG TO REGULAR - COMPLETE WORD)=========================
                                        Select Case .Item("STATUS")
                                            Case "RPO"
                                                .Item("STATUS") = "PROBATIONARY"
                                            Case "REG"
                                                .Item("STATUS") = "REGULAR"
                                            Case "AWO"
                                                .Item("STATUS") = "AWOL"
                                            Case "RES"
                                                .Item("STATUS") = "RESIGNED"
                                            Case "TER"
                                                .Item("STATUS") = "TERMINATED"
                                            Case "SUS"
                                                .Item("STATUS") = "SUSPENDED"
                                            Case "APP"
                                                .Item("STATUS") = "APPOINTED"
                                            Case "End"
                                                .Item("STATUS") = "END OF PROBATIONARY"
                                        End Select

                                        SaveEntry(dsS, False)

                                        MessageBox.Show("COLUMN - Status updated to full (Ex. Regular, Probationary) in TABLE EMPLOYEE .")
                                    End If
                                End With
                            Next

                        End Using
                    End With
                Next
            End If
        End Using

        '==========================CREATE TBL_LEAVE, TBL_LASTDATE========================= 


        RunCommand("CREATE TABLE TBL_LEAVE (
                    ID SMALLINT NOT NULL,
                      EMP_ID BIGINT NOT NULL,
                      BRANCH_ID SMALLINT NOT NULL,
                      LEAVE_TYPE VARCHAR(50) NOT NULL,
                      L_DATE_STARTED DATE NOT NULL,
                      L_DATE_ENDED DATE NOT NULL,
                      DATE_ENCODED DATE NOT NULL,
                      NOTES VARCHAR(200),
                      STATUS SMALLINT) ")

        RunCommand("CREATE TABLE TBL_LASTDATE (
                      EMP_ID BIGINT NOT NULL,
                      LASTDATE DATE NOT NULL,
                      REASON VARCHAR(300))")

        'RunCommand("CREATE TABLE TBL_ATTENDANCE (
        '              EMP_ID SMALLINT NOT NULL,
        '              BRANCH_ID INTEGER NOT NULL,
        '              ATTENDANCE VARCHAR(20) NOT NULL,
        '              DATE_ENCODED DATE NOT NULL,
        '              REMARKS VARCHAR(200),
        '              NOTE VARCHAR(150),
        '              STATUS INTEGER NOT NULL,
        '              ID SMALLINT NOT NULL)")

        MessageBox.Show("Tables CREATED to DATABASE successfully!")

        LoadREquirementsPictures()  'THIS IS TO FETCH IMAGES REQUIREMENTS FROM TBL_REQARCHIVE  
        MessageBox.Show("Images Succesfully save to D: \201.")

    End Sub

    Friend Sub LoadREquirementsPictures()

        Dim mysql As String = "select A.*, c.Lastname, c.Firstname, c.Middlename, c.id as emp_id, d.PROFILE_PIC from TBL_REQARCHIVE A 
                                inner join tbl_req B on A.REQ_ID = B.REQ_ID 
                                inner join tbl_employee C on B.EMPLOYEE_ID = C.ID
                                inner join TBL_Profilepic D on C.ID = D.Emp_ID"

        Dim emptyByte() = New Byte() {1}
        Using ds As DataSet = LoadSQL(mysql)

            For Each dr In ds.Tables(0).Rows
                Dim name As String = dr("Lastname") & ", " & dr("Firstname") & " " & dr("Middlename")

                Console.WriteLine("NAME === " & name & " Req_ID === " & dr("REQ_ID") & "     ID === " & dr("emp_id"))

                FromDatabaseToFolder(IIf(IsDBNull(dr("PROFILE_PIC")), emptyByte, dr("PROFILE_PIC")), "Profile", name)
                FromDatabaseToFolder(IIf(IsDBNull(dr("SSS")), emptyByte, dr("SSS")), "SSS", name)
                FromDatabaseToFolder(IIf(IsDBNull(dr("PHILHEALTH")), emptyByte, dr("PHILHEALTH")), "PhilHealth", name)
                FromDatabaseToFolder(IIf(IsDBNull(dr("PAGIBIG")), emptyByte, dr("PAGIBIG")), "PagIbig", name)
                FromDatabaseToFolder(IIf(IsDBNull(dr("TIN")), emptyByte, dr("TIN")), "TIN", name)
                FromDatabaseToFolder(IIf(IsDBNull(dr("BARANGAYCLEARANCE")), emptyByte, dr("BARANGAYCLEARANCE")), "Barangay Clearance", name)
                FromDatabaseToFolder(IIf(IsDBNull(dr("CEDULA")), emptyByte, dr("CEDULA")), "Cedula", name)
                FromDatabaseToFolder(IIf(IsDBNull(dr("POLICECLEARANCE")), emptyByte, dr("POLICECLEARANCE")), "Police Clearance", name)
                FromDatabaseToFolder(IIf(IsDBNull(dr("NBICLEARANCE")), emptyByte, dr("NBICLEARANCE")), "NBI Clearance", name)
                FromDatabaseToFolder(IIf(IsDBNull(dr("HEALTHCARD")), emptyByte, dr("HEALTHCARD")), "Health Card", name)
                FromDatabaseToFolder(IIf(IsDBNull(dr("MAYORSPERMIT")), emptyByte, dr("MAYORSPERMIT")), "Mayors Permit", name)
                FromDatabaseToFolder(IIf(IsDBNull(dr("PDS")), emptyByte, dr("PDS")), "PDS", name)
                FromDatabaseToFolder(IIf(IsDBNull(dr("PROBA")), emptyByte, dr("PROBA")), "PROBA", name)
                FromDatabaseToFolder(IIf(IsDBNull(dr("MOA")), emptyByte, dr("MOA")), "MOA", name)
                FromDatabaseToFolder(IIf(IsDBNull(dr("IDFORM")), emptyByte, dr("IDFORM")), "ID Form", name)
                FromDatabaseToFolder(IIf(IsDBNull(dr("ACKNOWLEDGEMENTLETTER")), emptyByte, dr("ACKNOWLEDGEMENTLETTER")), "Acknowledgment Letter", name)
                FromDatabaseToFolder(IIf(IsDBNull(dr("ENDORSEMENTLETTER")), emptyByte, dr("ENDORSEMENTLETTER")), "Endorsement Letter", name)
            Next
        End Using

    End Sub

    Public Sub FromDatabaseToFolder(emp As Byte(), ImageName As String, Optional name As String = "")

        Dim folder As String = "201"
        Dim ms As New MemoryStream(emp)
        Dim folderName As DirectoryInfo = New DirectoryInfo("D:\" & folder)
        Dim employee As DirectoryInfo = New DirectoryInfo("D:\" & folder & "\" & name)

        Dim key As Integer = emp.Length
        Try

            If key < 800 Then
                Exit Sub
            Else

                If Not folderName.Exists Then

                    folderName.Create()

                    If Not employee.Exists Then

                        employee.Create()

                        Using img As Image = New Bitmap(Image.FromStream(ms))
                            img.Save("D:\201\" & name & "\" & ImageName & ".jpeg", System.Drawing.Imaging.ImageFormat.Jpeg)
                        End Using

                    Else

                        Using img As Image = New Bitmap(Image.FromStream(ms))
                            img.Save("D:\201\" & name & "\" & ImageName & ".jpeg", System.Drawing.Imaging.ImageFormat.Jpeg)
                        End Using

                    End If

                Else
                    If Not employee.Exists Then

                        employee.Create()

                        Using img As Image = New Bitmap(Image.FromStream(ms))
                            img.Save("D:\201\" & name & "\" & ImageName & ".jpeg", System.Drawing.Imaging.ImageFormat.Jpeg)
                        End Using

                    Else

                        Using img As Image = New Bitmap(Image.FromStream(ms))
                            img.Save("D:\201\" & name & "\" & ImageName & ".jpeg", System.Drawing.Imaging.ImageFormat.Jpeg)
                        End Using
                    End If

                End If
            End If

        Catch ex As Exception
            Console.WriteLine(ex.Message)
        Finally
            ms.Close()
            ms.Dispose()
        End Try
    End Sub

End Module
