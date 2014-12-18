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
    Public Function makeInputDataTable(fileName As String) As DataTable
        Dim inputTable As New DataTable

        ' Clear all previous data
        inputTable.Clear()

        Try

            Dim textReader As New System.IO.StreamReader(fileName)
            Dim nextLine As String
            Dim i As Integer = 0
            Dim j As Integer = 0
            Dim colCount As Integer = 0

            ' Loop line by line
            Do While textReader.Peek() >= 0
                nextLine = textReader.ReadLine()

                ' String tokenizing by the tab character
                Dim arrayOfValues() As String = Split(nextLine, vbTab) 'Don't use splitoption.none here. Breaks it.
                colCount = arrayOfValues.Length 'Gets number of elements in the first array made
                j = colCount

                'Uses colCount to determine number of elements in header, allowing number of columns to be
                'made to be determined. This took way longer to figure out that it should have.
                If i = 0 Then
                    Do While colCount > 0
                        inputTable.Columns.Add(arrayOfValues.ElementAt(j - colCount))
                        colCount = colCount - 1
                    Loop
                    i = 1
                End If

                inputTable.Rows.Add(arrayOfValues) 'Adds a row with the elements in the array

            Loop
            inputTable.Rows.RemoveAt(0) 'Fixes additional row of headers being displayed in inputTable

            textReader.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return inputTable
    End Function

    
End Module


