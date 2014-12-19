'Author contact: jared.andrews07@gmail.com
Public Class MainForm

    'Creates instance of HelpForm so multiple can't be created by clicking help multiple times
    'Create global instances of the datatables
    Dim helpForm As New HelpForm
    Dim inputTable As DataTable
    Dim outputTable As DataTable

    'Allows user to drag and drop input file into program
    Private Sub MainForm_DragDrop(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles Me.DragDrop
        Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
        Dim filePath As String = System.IO.Path.GetFullPath(files(0))
        Dim fileExt As String = System.IO.Path.GetExtension(files(0))
        datasrcTxtB.Text = filePath

        If fileExt = ".txt" Then 'Checks to be sure the input is a .txt file
            inputTable = makeInputDataTable(filePath)
        Else
            MsgBox("Only .txt files are accepted.") 'Tells user only .txt files are accepted for input if they try to use different file type
        End If

    End Sub

    'Needed for drag and drop file inputs
    Private Sub MainForm_DragEnter(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles Me.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub

    'Shows "About" information from the help menu.
    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        MsgBox("ChroSearch Developed by the Payton Lab", , "About ChroSearch")
    End Sub

    'Imports file for use as input by program when user uses File -> Import path. Also displays file path 
    'in datasrcTxtB for reference.
    Private Sub openMenuItem_Click(sender As Object, e As EventArgs) Handles openMenuItem.Click
        Dim strFileName As String = getFileImport() 'Returns the file path

        If strFileName <> "" Then 'Makes it so no error is thrown if cancel is clicked in the file select window
            datasrcTxtB.Text = strFileName

            inputTable = makeInputDataTable(strFileName) 'Creates a new data table for the file and populates columns

        End If
    End Sub


    'Saves output when user uses File -> Export path.
    Private Async Sub exportMenuItem_Click(sender As Object, e As EventArgs) Handles exportMenuItem.Click
        Dim strFileName As String
        Dim didWork As Integer
        Dim sb As New System.Text.StringBuilder()
        Dim exportData As New DataTable
        exportData = outputTable.Clone()
        exportFD.Title = "Save as a text file"
        exportFD.Filter = "Text Files(*.txt)|*.txt" 'Limits user to only saving as .txt file
        exportFD.ShowDialog()

        If didWork = DialogResult.Cancel Then 'Handles if Cancel Button is clicked
            Return
        Else
            strFileName = exportFD.FileName

            ' If table has results
            If outputTable.Rows.Count <> 0 Then

                ' Column Titles
                For Each column As DataColumn In exportData.Columns
                    sb.Append(column.ColumnName + vbTab)
                Next

                sb.Append(vbCr & vbLf)

                ' Loop each row
                For row As Integer = 0 To outputTable.Rows.Count - 1
                    ' Loop each cell
                    For cell As Integer = 0 To outputTable.Columns.Count - 1
                        Dim cellContents As String

                        cellContents = outputTable.Rows.Item(row).Item(cell).ToString()

                        sb.Append(cellContents + vbTab)
                    Next

                    sb.Append(vbCr & vbLf)
                Next

                ' Open a stream writer to a new text file named "UserInputFile.txt" and write the contents  
                ' of the stringbuilder to it.
                ' Set bool to false in order to overwrite (and avoid messy nonsense)
                Using outfile As IO.StreamWriter = New IO.StreamWriter(strFileName, False)
                    Await outfile.WriteAsync(sb.ToString())
                    Debug.Print(sb.ToString())
                End Using

            End If

        End If

        MsgBox("Saved to: " + strFileName)
    End Sub

    'Clears the search parameters when the reset button is clicked.
    Private Sub resetBtn_Click(sender As Object, e As EventArgs) Handles resetBtn.Click
        chromTxtB.Text = ""
        startTxtB.Text = ""
        endTxtB.Text = ""
        mmpidTxtB.Text = ""
    End Sub

    'Asks user if they really want to quit when Exit in the File menu is clicked. Only closes if they click yes. 
    'Force user to do this every time due to Exit's close proximity to export in the menu. Don't want misclicks to waste time.
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Dim result = MessageBox.Show(" Are you sure you want to quit?", "Are you sure?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub HelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem.Click
        helpForm.Show()
    End Sub

    Private Sub searchBtn_Click(sender As Object, e As EventArgs) Handles searchBtn.Click
        Dim mmpidParam As Integer
        Dim startParam As Integer
        Dim endParam As Integer
        Dim geneParam As String
        Dim chromParam As String
        Dim result() As DataRow
        Dim progMax As Integer

        outputTable = inputTable.Clone()
        outputTable.Rows.Clear()
        progBar.Value = 0
        runLabel.Text = Nothing

        If mmpidTxtB.Text <> "" Then

            mmpidParam = Convert.ToInt64(mmpidTxtB.Text)
            result = inputTable.Select("MMPID='" & mmpidParam & "'")
            progMax = result.Count()
            progBar.Maximum = progMax
            progBar.Visible = True
            runLabel.Visible = True
            For Each row As DataRow In result
                outputTable.ImportRow(row)
                progBar.Value += 1
                runLabel.Text = "Running..." + (Int(progBar.Value * 100 / progBar.Maximum)).ToString() + "%"
                For i = 0 To 100

                Next
            Next
            outputDataGridView.DataSource = outputTable
            searchTxtB.Text = outputTable.Rows.Count().ToString()
        Else
            MsgBox("Please input a search parameter!", MsgBoxStyle.OkOnly, "No search parameters entered!")
        End If
    End Sub

    'Saves output when user clicks the Export button.
    Private Async Sub exportBtn_Click(sender As Object, e As EventArgs) Handles exportBtn.Click
        Dim strFileName As String
        Dim didWork As Integer
        Dim sb As New System.Text.StringBuilder()
        Dim exportData As New DataTable
        exportData = outputTable.Clone()
        exportFD.Title = "Save as a text file"
        exportFD.Filter = "Text Files(*.txt)|*.txt" 'Limits user to only saving as .txt file
        exportFD.ShowDialog()

        If didWork = DialogResult.Cancel Then 'Handles if Cancel Button is clicked
            Return
        Else
            strFileName = exportFD.FileName

            ' If table has results
            If outputTable.Rows.Count <> 0 Then

                ' Column Titles
                For Each column As DataColumn In exportData.Columns
                    sb.Append(column.ColumnName + vbTab)
                Next

                sb.Append(vbCr & vbLf)

                ' Loop each row
                For row As Integer = 0 To outputTable.Rows.Count - 1
                    ' Loop each cell
                    For cell As Integer = 0 To outputTable.Columns.Count - 1
                        Dim cellContents As String

                        cellContents = outputTable.Rows.Item(row).Item(cell).ToString()

                        sb.Append(cellContents + vbTab)
                    Next

                    sb.Append(vbCr & vbLf)
                Next

                ' Open a stream writer to a new text file named "UserInputFile.txt" and write the contents  
                ' of the stringbuilder to it.
                ' Set bool to false in order to overwrite (and avoid messy nonsense)
                Using outfile As IO.StreamWriter = New IO.StreamWriter(strFileName, False)
                    Await outfile.WriteAsync(sb.ToString())
                    Debug.Print(sb.ToString())
                End Using

            End If

        End If

        MsgBox("Saved to: " + strFileName)
    End Sub

End Class
