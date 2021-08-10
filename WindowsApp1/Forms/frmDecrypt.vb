Imports System.IO

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

            'Dim fi As New FileInfo(openn.FileName)
            'Dim filePath As String = fi.Directory.ToString

            'txtFileToDecrypt.Text = openn.FileName

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

        CryptoStuff.DecryptFile(txtPassDecrypt.Text, txtFileToDecrypt.Text, txtDestinationDecrypt.Text)

        RichTextBox1.Text = File.ReadAllText(txtDestinationDecrypt.Text)

    End Sub
End Class