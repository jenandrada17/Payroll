Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

Public Class frmDecrypt
    Dim strFileToEncrypt As String
    Dim strFileToDecrypt As String
    Dim strOutputEncrypt As String
    Dim strOutputDecrypt As String
    Dim fsInput As System.IO.FileStream
    Dim fsOutput As System.IO.FileStream

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles browse.Click
        Dim openn As New OpenFileDialog()
        openn.FileName = ""
        openn.Title = "Choose a file to decrypt"
        openn.InitialDirectory = "C:\"
        openn.Filter = "All Files (*.*) | *.*"

        If openn.ShowDialog = DialogResult.OK Then

            strFileToDecrypt = openn.FileName
            txtFileToDecrypt.Text = strFileToDecrypt
            Dim iPosition As Integer = 0
            Dim i As Integer = 0

            While strFileToDecrypt.IndexOf("\"c, i) <> -1
                iPosition = strFileToDecrypt.IndexOf("\"c, i)
                i = iPosition + 1
            End While

            strOutputDecrypt = strFileToDecrypt.Substring(0, strFileToDecrypt.Length - 8)

            Dim S As String = strFileToDecrypt.Substring(0, iPosition + 1)

            strOutputDecrypt = strOutputDecrypt.Substring((iPosition + 1))

            txtDestinationDecrypt.Text = S + strOutputDecrypt.Replace("_"c, "."c)
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Decrypt.Click

        'CryptoStuff.EncryptFile(txtPassDecrypt.Text, txtFileToDecrypt.Text, txtDestinationDecrypt.Text)
        'RichTextBox1.Text = File.ReadAllText(txtDestinationDecrypt.Text)

        '=================================================================================================
        'Dim bytKey As Byte()
        'Dim bytIV As Byte()

        'bytKey = CreateKey(txtPassDecrypt.Text)

        'bytIV = CreateIV(txtPassDecrypt.Text)

        'EncryptOrDecryptFile(strFileToDecrypt, txtDestinationDecrypt.Text,
        '                     bytKey, bytIV, CryptoAction.ActionDecrypt)

        ''RichTextBox1.Text = File.ReadAllText(txtDestinationDecrypt.Text)

        '===================================================================================================  


    End Sub

    Public Function RSADecrypt(ByVal DataToDecrypt() As Byte, ByVal RSAKeyInfo As RSAParameters, ByVal DoOAEPPadding As Boolean) As Byte()
        Try
            Dim decryptedData() As Byte
            'Create a new instance of RSACryptoServiceProvider.
            Using RSA As New RSACryptoServiceProvider(1024)
                RSA.ImportParameters(RSAKeyInfo)
                decryptedData = RSA.Decrypt(DataToDecrypt, DoOAEPPadding)
            End Using
            Return decryptedData
        Catch e As CryptographicException
            Console.WriteLine(e.ToString())
            Return Nothing
        End Try
    End Function

    'Public Function Crypt(ByVal Text As String) As String
    '    Dim TempChar As String
    '    Dim i As Integer
    '    For i = 1 To Len(Text)
    '        If Asc(Mid$(Text, i, 1)) < 128 Then
    '            TempChar = CType(Asc(Mid$(Text, i, 1)) + 128, String)
    '        ElseIf Asc(Mid$(Text, i, 1)) > 128 Then
    '            TempChar = CType(Asc(Mid$(Text, i, 1)) - 128, String)
    '        End If
    '        Mid$(Text, i, 1) = Chr(CType(TempChar, Integer))
    '    Next i
    '    Return Text
    'End Function


    Private Function CreateKey(ByVal strPassword As String) As Byte()
        Dim chrData() As Char = strPassword.ToCharArray
        Dim intLength As Integer = chrData.GetUpperBound(0)
        Dim bytDataToHash(intLength) As Byte

        For i As Integer = 0 To chrData.GetUpperBound(0)
            bytDataToHash(i) = CByte(Asc(chrData(i)))
        Next

        Dim SHA512 As New System.Security.Cryptography.SHA512Managed
        Dim bytResult As Byte() = SHA512.ComputeHash(bytDataToHash)
        Dim bytKey(31) As Byte

        For i As Integer = 0 To 31
            bytKey(i) = bytResult(i)
        Next

        Return bytKey
    End Function

    'Private Function CreateKey(ByVal strPassword As String) As Byte()
    '    Dim bytKey As Byte()
    '    Dim bytSalt As Byte() = System.Text.Encoding.ASCII.GetBytes("salt")
    '    Dim pdb As New PasswordDeriveBytes(strPassword, bytSalt)

    '    bytKey = pdb.GetBytes(32)

    '    Return bytKey
    'End Function

    Private Function CreateIV(ByVal strPassword As String) As Byte()
        Dim chrData() As Char = strPassword.ToCharArray
        Dim intLength As Integer = chrData.GetUpperBound(0)
        Dim bytDataToHash(intLength) As Byte

        For i As Integer = 0 To chrData.GetUpperBound(0)
            bytDataToHash(i) = CByte(Asc(chrData(i)))
        Next

        Dim SHA512 As New System.Security.Cryptography.SHA512Managed
        Dim bytResult As Byte() = SHA512.ComputeHash(bytDataToHash)
        Dim bytIV(15) As Byte

        For i As Integer = 32 To 47
            bytIV(i - 32) = bytResult(i)
        Next

        Return bytIV
    End Function

    'Private Function CreateIV(ByVal strPassword As String) As Byte()
    '    Dim bytIV As Byte()
    '    Dim bytSalt As Byte() = System.Text.Encoding.ASCII.GetBytes("salt")
    '    Dim pdb As New PasswordDeriveBytes(strPassword, bytSalt)

    '    bytIV = pdb.GetBytes(16)

    '    Return bytIV
    'End Function

    Private Enum CryptoAction
        ActionEncrypt = 1
        ActionDecrypt = 2
    End Enum

    Private Sub EncryptOrDecryptFile(ByVal strInputFile As String,
                                     ByVal strOutputFile As String,
                                     ByVal bytKey() As Byte,
                                     ByVal bytIV() As Byte,
                                     ByVal Direction As CryptoAction)
        Try

            fsInput = New System.IO.FileStream(strInputFile, FileMode.Open,
                                                  FileAccess.Read)
            fsOutput = New System.IO.FileStream(strOutputFile,
                                                   FileMode.OpenOrCreate,
                                                   FileAccess.Write)
            fsOutput.SetLength(0)

            Dim bytBuffer(4096) As Byte
            Dim lngBytesProcessed As Long = 0
            Dim lngFileLength As Long = fsInput.Length
            Dim intBytesInCurrentBlock As Integer
            Dim csCryptoStream As CryptoStream = Nothing
            Dim cspRijndael As New System.Security.Cryptography.RijndaelManaged

            ''Setup Progress Bar
            'pbStatus.Value = 0
            'pbStatus.Maximum = 100 

            Select Case Direction
                Case CryptoAction.ActionEncrypt
                    csCryptoStream = New CryptoStream(fsOutput,
                    cspRijndael.CreateEncryptor(bytKey, bytIV),
                    CryptoStreamMode.Write)

                    cspRijndael.Padding = PaddingMode.None

                Case CryptoAction.ActionDecrypt
                    csCryptoStream = New CryptoStream(fsOutput,
                    cspRijndael.CreateDecryptor(bytKey, bytIV),
                    CryptoStreamMode.Write)

                    cspRijndael.Padding = PaddingMode.None
            End Select

            'Use While to loop until all of the file is processed.
            While lngBytesProcessed < lngFileLength
                intBytesInCurrentBlock = fsInput.Read(bytBuffer, 0, 4096)
                csCryptoStream.Write(bytBuffer, 0, intBytesInCurrentBlock)
                lngBytesProcessed = lngBytesProcessed +
                                        CLng(intBytesInCurrentBlock)

                'pbStatus.Value = CInt((lngBytesProcessed / lngFileLength) * 100)
            End While


            csCryptoStream.Close()
            fsInput.Close()
            fsOutput.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub frmDecrypt_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Dim myDESProvider As DESCryptoServiceProvider = New DESCryptoServiceProvider()
            myDESProvider.Key = ASCIIEncoding.ASCII.GetBytes("12345678")
            myDESProvider.IV = ASCIIEncoding.ASCII.GetBytes("12345678")
            Dim myICryptoTransform As ICryptoTransform = myDESProvider.CreateEncryptor(myDESProvider.Key, myDESProvider.IV)
            Dim ProcessFileStream As FileStream = New FileStream("D:\Users\ItsYou\Desktop\sample\Sample only.txt", FileMode.Open, FileAccess.Read)
            Dim ResultFileStream As FileStream = New FileStream("D:\Users\ItsYou\Desktop\sample\Decrypted.txt", FileMode.Create, FileAccess.Write)
            Dim myCryptoStream As CryptoStream = New CryptoStream(ResultFileStream, myICryptoTransform, CryptoStreamMode.Write)
            Dim bytearrayinput(ProcessFileStream.Length - 1) As Byte
            ProcessFileStream.Read(bytearrayinput, 0, bytearrayinput.Length)
            myCryptoStream.Write(bytearrayinput, 0, bytearrayinput.Length)
            myCryptoStream.Close()
            ProcessFileStream.Close()
            ResultFileStream.Close()
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
        Console.ReadLine()

    End Sub
End Class