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

    'Creates new input datatable when a file is imported
    Public Function makeSearchDataTable(fileName As String) As DataTable
        Dim searchTable As New DataTable

        ' Clear all previous data
        searchTable.Clear()

        Try

            Dim textReader As New System.IO.StreamReader(fileName)
            Dim nextLine As String
            Dim i As Integer = 0
            Dim j As Integer = 0
            Dim colCount As Integer = 0

            ' Loop line by line
            For k As Integer = 0 To 0
                nextLine = textReader.ReadLine()

                ' String tokenizing by the tab character
                Dim arrayOfValues() As String = Split(nextLine, vbTab) 'Don't use splitoption.none here. Breaks it.
                colCount = arrayOfValues.Length 'Gets number of elements in the first array made
                j = colCount

                'Uses colCount to determine number of elements in header, allowing number of columns to be
                'made to be determined. This took way longer to figure out that it should have.
                If i = 0 Then
                    Do While colCount > 0
                        searchTable.Columns.Add(arrayOfValues.ElementAt(j - colCount))
                        colCount = colCount - 1
                    Loop
                    i = 1
                End If
                k += 1
            Next


            textReader.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return searchTable
    End Function

    
End Module


