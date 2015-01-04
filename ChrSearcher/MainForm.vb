'Author contact: jared.andrews07@gmail.com
Imports System.IO.File
Imports System.ComponentModel
Public Class MainForm

    'Creates instance of HelpForm so multiple can't be created by clicking help multiple times
    'Create global instances of the datatables and line count of the input file
    Dim helpForm As New HelpForm
    Dim searchTable As DataTable
    Dim paramTable As DataTable
    Dim lineCount As Integer
    Dim colCount As Integer


    'Allows user to drag and drop input file into program
    Private Sub MainForm_DragDrop(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles Me.DragDrop
        Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
        Dim filePath As String = System.IO.Path.GetFullPath(files(0))
        Dim fileExt As String = System.IO.Path.GetExtension(files(0))

        If fileExt = ".txt" Then 'Checks to be sure the input is a .txt file
            Me.Cursor = Cursors.WaitCursor 'Changes the cursor to wait cursor so user knows file is loading
            loadingLabel.Visible = True    'Makes loading label in statusbar visible to show user that file is loading
            loadingLabel.Text = "Loading...Please wait, this may take a few minutes."
            datasrcTxtB.Text = filePath
            loadBGWorker.RunWorkerAsync(filePath)
        End If

    End Sub

    'Needed for drag and drop file inputs
    Private Sub MainForm_DragEnter(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles Me.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    'Imports file for use as input by program when user uses File -> Import path. Also displays file path 
    'in datasrcTxtB for reference.
    Private Sub openMenuItem_Click(sender As Object, e As EventArgs) Handles openMenuItem.Click
        Dim filePath As String = getFileImport() 'Returns the file path
        Me.Cursor = Cursors.WaitCursor 'Changes the cursor to wait cursor so user knows file is loading
        loadingLabel.Visible = True    'Makes loading label in statusbar visible to show user that file is loading
        loadingLabel.Text = "Loading...Please wait, this may take a few minutes."

        'If filepath isn't blank, then loads the select file using the loadBGWorker.
        If filePath <> "" Then
            datasrcTxtB.Text = filePath
            loadBGWorker.RunWorkerAsync(filePath)
        End If

    End Sub

    'Shows "About" information from the help menu.
    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        MsgBox("ChroSearch Developed by the Payton Lab", , "About ChroSearch")
    End Sub


    'Clears the search parameters in the searchDataGridView when the reset button is clicked.
    Private Sub resetBtn_Click(sender As Object, e As EventArgs) Handles resetBtn.Click
        If colCount <> Nothing Then
            For i As Integer = 0 To colCount - 1
                searchDataGridView.Rows.Item(i).Cells.Item(i) = Nothing
            Next
        End If
    End Sub

    'Asks user if they really want to quit when Exit in the File menu is clicked. Only closes if they click yes. 
    'Force user to do this every time due to Exit's close proximity to export in the menu. Don't want misclicks to waste time.
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Dim result = MessageBox.Show(" Are you sure you want to quit?", "Are you sure?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    'Loads the help form when user clicks -> Help -> Help
    Private Sub HelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem.Click
        helpForm.Show()
    End Sub

    'Searches the loaded file
    Private Async Sub searchBtn_Click(sender As Object, e As EventArgs) Handles searchBtn.Click
        Dim strFileName As String
        Dim didWork As Integer

        Dim mmpidParam As Integer
        Dim startParam As Integer
        Dim endParam As Integer
        Dim geneParam As String
        Dim chromParam As String
        Dim result() As DataRow
        Dim searchHits As Integer = 0
        Dim i As Integer = 0

        'Prompts user to enter title of file to be created
        exportFD.Title = "Save as a text file"
        exportFD.Filter = "Text Files(*.txt)|*.txt" 'Limits user to only saving as .txt file
        exportFD.ShowDialog()

        'If didWork = DialogResult.Cancel Then 'Handles if Cancel Button of dialog is clicked
        'Return
        'Else
        'strFileName = exportFD.FileName
        'Dim writer As New IO.StreamWriter(strFileName, True)
        'Dim reader As New IO.StreamReader(datasrcTxtB.Text)
        'Dim line As String
        'Dim readRow() As String

        'Resets progress bar and label
        searchProgBar.Value = 0
        searchProgLabel.Text = Nothing

        'If mmpidTxtB.Text <> "" Or Nothing And geneTxtB.Text <> "" Or Nothing Then 'Checks that parameter is filled
        'mmpidParam = Convert.ToInt64(mmpidTxtB.Text)
        'geneParam = geneTxtB.Text

        'Sets up progressbar
        searchProgBar.Maximum = lineCount
        searchProgBar.Visible = True
        searchProgLabel.Visible = True

        'Search whole file, line by line
        'Do While reader.Peek() > 0
        'line = reader.ReadLine()
        'readRow = Split(line, vbTab)
        'searchTable.Rows.Add(readRow) 'Add row to searchtable

        'result = searchTable.Select("MMPID='" & mmpidParam & "'") 'Search for MMPID in the single row

        'If search parameter is found in the newly added row, write it to new export file
        ' If result.Count() > 0 Then
        'result = searchTable.Select("GENE='" & geneParam & "'")
        'If result.Count() > 0 Then
        'Dim stringBuild As New System.Text.StringBuilder()

        'Write headers of the search datatable first to export file
        'While i < 1
        'For Each column As DataColumn In searchTable.Columns
        'stringBuild.Append(column.ColumnName + vbTab)
        'Next
        'i += 1
        'Await writer.WriteLineAsync(stringBuild.ToString())
        'stringBuild.Clear()
        'End While

        'Add the row to the export file, cell by cell
        'For Each row As DataRow In result
        'For cell As Integer = 0 To searchTable.Columns.Count - 1
        'Dim cellContents As String
        'cellContents = searchTable.Rows.Item(0).Item(cell).ToString()
        'stringBuild.Append(cellContents + vbTab)
        'Next
        'Await writer.WriteLineAsync(stringBuild.ToString())
        'stringBuild.Clear()
        'Next

        'searchHits += 1
        'Debug.Print(searchHits)
        'End If
        'End If

        searchTable.Rows(0).Delete() 'Delete the searched row

        'Makes sure progress bar doesn't go out of range
        If searchProgBar.Value = searchProgBar.Maximum Then

        Else
            searchProgBar.Value += 1 'Increase value of search bar for each line searched
        End If

        'Updates label for progress bar with percentage, time remaining.
        'searchProgLabel.Text = "Running..." + (Int((searchProgBar.Value / searchProgBar.Maximum) * 100).ToString()) + "% Complete"
        'searchProgLabel.Update() 'Must manually force since this function isn't asynchronous yet

        'Loop 'Move to next row in input file

        'searchTxtB.Text = searchHits 'Shows number of hits from search
        'Else
        'MsgBox("Please input a search parameter!", MsgBoxStyle.OkOnly, "No search parameters entered!")
        'End If

        'Close out writer and reader and tell user file was saved
        'writer.Close()
        'reader.Close()
        'MsgBox("Saved to: " + strFileName)
        'End If

    End Sub



    'Takes care of the file loading so the program doesn't just hang when loading
    Private Sub loadBGWorker_DoWork(sender As Object, e As DoWorkEventArgs) Handles loadBGWorker.DoWork
        Dim worker As BackgroundWorker = CType(sender, BackgroundWorker)
        Dim filepath As String = e.Argument 'Argument passed to determine filepath
        Dim watch As Stopwatch = Stopwatch.StartNew() 'Times loading
        Dim reader As New IO.StreamReader(filepath)
        lineCount = 0 'Resets lineCount variable of loaded file

        searchTable = makeSearchDataTable(filepath) 'Makes search datatable from file

        While reader.ReadLine() <> Nothing 'Counts lines of file
            lineCount += 1
        End While

        watch.Stop()
        lineCount -= 1 'Removes a line to account for the headers

        MsgBox(lineCount.ToString() + " lines searched in " + watch.Elapsed.Minutes().ToString() + " minutes and " _
                + watch.Elapsed.Seconds().ToString() + " seconds.")

        'Sets datatable to be used for user input for search parameters in datagridview
        paramTable = searchTable.Clone()
        paramTable.Rows.Add()

        colCount = searchTable.Columns.Count()


    End Sub

    'Updates statusbar and returns cursor to normal after loadBGWorker finishes work.
    Private Sub loadBGWorker_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles loadBGWorker.RunWorkerCompleted
        Dim colCompare As String
        Me.Cursor = Cursors.Default
        loadingLabel.Text = "File loaded: " + lineCount.ToString() + " lines to search"
        searchDataGridView.DataSource = paramTable
        searchDataGridView.Rows.Item(0).ReadOnly = False

        For Each column As DataColumn In searchTable.Columns
            colCompare = column.ColumnName.Trim().ToUpper()
            If colCompare = "GENE" OrElse colCompare = "CHR" OrElse colCompare = "SAMPLE_ID" _
                OrElse colCompare = "CHROM" Then
                column.DataType = System.Type.GetType("System.String")
            ElseIf colCompare = "START" OrElse colCompare = "END" OrElse colCompare = "CHROMSTART" OrElse _
                colCompare = "CHROMEND" OrElse colCompare = "MMPID" Then
                column.DataType = System.Type.GetType("System.Int64")
            Else
                column.DataType = System.Type.GetType("System.Double")
            End If
        Next
    End Sub

    
End Class
