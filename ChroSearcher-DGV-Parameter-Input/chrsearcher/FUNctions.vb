Module FUNctions

    'Imports the file and returns the file path.
    Public Function getFileImport() As String
        Dim strFileName As String = ""
        Dim didWork As Integer
        Dim importFD As New OpenFileDialog

        importFD.Title = "Open a text file"
        importFD.Filter = "Text Files(*.txt)|*.txt" 'Limits user to only opening .txt files.
        importFD.ShowDialog()
        If didWork = DialogResult.Cancel Then 'Only recording path if file is actually opened.
            MsgBox("File Does Not Exist")
        Else
            strFileName = importFD.FileName
        End If

        Return strFileName
    End Function


    
End Module


