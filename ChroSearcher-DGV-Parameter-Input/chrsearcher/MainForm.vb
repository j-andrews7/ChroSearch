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

        createSearchOptions(filePath)

    End Sub

    'Dynamically generated textboxes
    Private Sub createSearchOptions(filePath As String)
        Try
            Using reader As New IO.StreamReader(filePath)
                Dim tokenized() As String
                Dim xPosition As Integer = 0
                Dim yPosition As Integer = 0

                'Clear any and all previous controls from the panel
                criteriaPanel.Controls.Clear()

                'Split line by tab characters
                tokenized = Split(reader.ReadLine(), vbTab)

                'Make textBoxes
                For token As Integer = 0 To tokenized.Length - 1
                    'Make search criteria's controls
                    createSearchCriteria(tokenized(token), xPosition)

                    'Shift x-position
                    xPosition += 200
                Next

            End Using
        Catch e As Exception
            Console.WriteLine(e.ToString)
        End Try
    End Sub

    'Make search criteria's controls
    Private Sub createSearchCriteria(criteriaName As String, xPosition As Integer)
        Dim radioBox As New GroupBox

        Dim criteriaCheckBox As New CheckBox
        Dim numericRadio As New RadioButton
        Dim stringRadio As New RadioButton

        Dim numericLabel1 As New Label
        Dim numericLabel2 As New Label
        Dim numericBoxLower As New NumericUpDown
        Dim numericBoxUpper As New NumericUpDown
        Dim numericInclusiveCheckLower As New CheckBox
        Dim numericInclusiveCheckUpper As New CheckBox

        Dim stringLabel As New Label
        Dim stringTextBox As New TextBox

        'groupbox for entire thing
        radioBox.Name = criteriaName & "GroupBox"
        radioBox.Text = ""
        radioBox.Location = New Point(xPosition, 0)
        radioBox.Size = New Size(190, 200)
        radioBox.Visible = True
        criteriaPanel.Controls.Add(radioBox)

        'checkbox
        criteriaCheckBox.Name = "CheckBox"
        criteriaCheckBox.Text = "Search by '" & criteriaName & "'"
        criteriaCheckBox.Width = 170
        criteriaCheckBox.Location = New Point(10, 10)
        radioBox.Controls.Add(criteriaCheckBox)

        'radiobuttons (seriously what kind of name is that)
        numericRadio.Name = "NumericRadio"
        numericRadio.Text = "Numeric Search"
        numericRadio.Width = 150
        numericRadio.Location = New Point(10 + 15, 30)
        numericRadio.Checked = True 'Numeric by default
        numericRadio.Visible = False 'Invisible by default
        radioBox.Controls.Add(numericRadio)

        stringRadio.Name = "StringRadio"
        stringRadio.Text = "Text Search"
        stringRadio.Width = 150
        stringRadio.Location = New Point(10 + 15, 50)
        stringRadio.Checked = False 'Numeric by default
        stringRadio.Visible = False 'Invisible by default
        radioBox.Controls.Add(stringRadio)

        'STRING SEARCH
        'Textbox
        stringTextBox.Name = "TextBox"
        stringTextBox.Location = New Point(10 + 15, 105) 'set the position according to your layout
        stringTextBox.Visible = False
        radioBox.Controls.Add(stringTextBox) 'add to the criteriaPanel for neat scrollbar and stuff

        'Label
        stringLabel.Name = "Label"
        stringLabel.Text = "Filter:"
        stringLabel.Location = New Point(10 - 2, 80) '-2 for sake of neat alignment
        stringLabel.Visible = False
        radioBox.Controls.Add(stringLabel)

        'NUMERIC SEARCH
        numericBoxLower.Name = "NumericBoxLower"
        numericBoxLower.Location = New Point(25, 105)
        numericBoxLower.Width = 50
        numericBoxLower.Visible = False
        radioBox.Controls.Add(numericBoxLower)

        numericBoxUpper.Name = "NumericBoxUpper"
        numericBoxUpper.Location = New Point(105, 105)
        numericBoxUpper.Width = 50
        numericBoxUpper.Visible = False
        radioBox.Controls.Add(numericBoxUpper)

        numericLabel1.Name = "NumericLabel1"
        numericLabel1.Text = "Between:"
        numericLabel1.Location = New Point(10 - 2, 80) '-2 for sake of neat alignment
        numericLabel1.Visible = False
        radioBox.Controls.Add(numericLabel1)

        numericLabel2.Name = "NumericLabel2"
        numericLabel2.Text = "and"
        numericLabel2.Location = New Point(79, 108)
        numericLabel2.Visible = False
        radioBox.Controls.Add(numericLabel2)

        numericInclusiveCheckLower.Name = "NumericInclusiveLowerCheckBox"
        numericInclusiveCheckLower.Text = "Inclusive"
        numericInclusiveCheckLower.Width = 70
        numericInclusiveCheckLower.Location = New Point(25, 130)
        numericInclusiveCheckLower.Visible = False
        radioBox.Controls.Add(numericInclusiveCheckLower)

        numericInclusiveCheckUpper.Name = "NumericInclusiveUpperCheckBox"
        numericInclusiveCheckUpper.Text = "Inclusive"
        numericInclusiveCheckUpper.Width = 70
        numericInclusiveCheckUpper.Location = New Point(105, 130)
        numericInclusiveCheckUpper.Visible = False
        radioBox.Controls.Add(numericInclusiveCheckUpper)

        'AddHandlers. MESSY MESSY
        'Should probably explain. All this does is manage various control visibilities.
        'ie if you want numeric search, make all the numeric search-relevant stuff appear and all the text search stuff disappear
        AddHandler criteriaCheckBox.Click,
        Sub()
            If criteriaCheckBox.Checked = True Then
                numericRadio.Visible = True
                stringRadio.Visible = True

                If numericRadio.Checked = True Then
                    stringTextBox.Visible = False
                    stringLabel.Visible = False

                    numericBoxUpper.Visible = True
                    numericBoxLower.Visible = True
                    numericLabel1.Visible = True
                    numericLabel2.Visible = True

                    numericInclusiveCheckLower.Visible = True
                    numericInclusiveCheckUpper.Visible = True
                ElseIf stringRadio.Checked = True Then
                    stringTextBox.Visible = True
                    stringLabel.Visible = True

                    numericBoxUpper.Visible = False
                    numericBoxLower.Visible = False
                    numericLabel1.Visible = False
                    numericLabel2.Visible = False

                    numericInclusiveCheckLower.Visible = False
                    numericInclusiveCheckUpper.Visible = False
                End If
            Else
                numericRadio.Visible = False
                stringRadio.Visible = False

                stringTextBox.Visible = False
                stringLabel.Visible = False

                numericBoxUpper.Visible = False
                numericBoxLower.Visible = False
                numericLabel1.Visible = False
                numericLabel2.Visible = False

                numericInclusiveCheckLower.Visible = False
                numericInclusiveCheckUpper.Visible = False
            End If
        End Sub

        AddHandler stringRadio.Click,
        Sub()
            stringTextBox.Visible = True
            stringLabel.Visible = True

            numericBoxUpper.Visible = False
            numericBoxLower.Visible = False
            numericLabel1.Visible = False
            numericLabel2.Visible = False

            numericInclusiveCheckLower.Visible = False
            numericInclusiveCheckUpper.Visible = False
        End Sub

        AddHandler numericRadio.Click,
        Sub()
            stringTextBox.Visible = False
            stringLabel.Visible = False

            numericBoxUpper.Visible = True
            numericBoxLower.Visible = True
            numericLabel1.Visible = True
            numericLabel2.Visible = True

            numericInclusiveCheckLower.Visible = True
            numericInclusiveCheckUpper.Visible = True
        End Sub

        radioBox.Refresh()
        criteriaPanel.Refresh()
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

        'Prompts user to enter title of file to be created
        exportFD.Title = "Save as a text file"
        exportFD.Filter = "Text Files(*.txt)|*.txt" 'Limits user to only saving as .txt file
        exportFD.ShowDialog()

        If didWork = DialogResult.Cancel Then 'Handles if Cancel Button of dialog is clicked
            Return
        Else
            strFileName = exportFD.FileName
            Dim writer As New IO.StreamWriter(strFileName, False) 'False because I -think- we want to overwrite, not append
            Dim reader As New IO.StreamReader(datasrcTxtB.Text)
            Dim currentLine As String

            'First: Insert column names into NEW text file
            For col As Integer = 0 To searchTable.Columns.Count - 1
                writer.Write(searchTable.Columns.Item(col).ColumnName & vbTab)
            Next
            writer.Write(vbNewLine)

            'Skip first line of SOURCE text file
            currentLine = reader.ReadLine()

            'Search whole file, line by line
            Do While reader.Peek() > 0
                'next line
                currentLine = reader.ReadLine()

                'new function:
                If validChromosome(currentLine) Then
                    writer.WriteLine(currentLine)
                End If
            Loop

            'Close out writer and reader and tell user file was saved
            writer.Close()
            reader.Close()
            MsgBox("Saved to: " + strFileName)
        End If

    End Sub

    'This function searches through the current chromosome and checks if it follows what the user has searched for
    Private Function validChromosome(chromString As String) As Boolean
        Dim readRow() As String
        validChromosome = True 'Start off as true

        'Split line by tab characters
        readRow = Split(chromString, vbTab)

        'iterate through string tokens and compare (simple comparison for now, this working will be a miracle in itself)
        For token As Integer = 0 To readRow.Length - 1
            Try
                Dim currentGroupBox As GroupBox = criteriaPanel.Controls.Item(token)
                Dim checkedParameter As CheckBox = currentGroupBox.Controls("CheckBox")

                'User wants to search this parameter
                If checkedParameter.Checked = True Then
                    Dim numericRadio As RadioButton = currentGroupBox.Controls("NumericRadio")

                    'Searching by number
                    If numericRadio.Checked = True Then
                        Dim value As Decimal
                        Dim lowerBox As NumericUpDown = currentGroupBox.Controls("NumericBoxLower")
                        Dim upperBox As NumericUpDown = currentGroupBox.Controls("NumericBoxUpper")

                        Dim lowerInclusiveCheck As CheckBox = currentGroupBox.Controls("NumericInclusiveLowerCheckBox")
                        Dim upperInclusiveCheck As CheckBox = currentGroupBox.Controls("NumericInclusiveUpperCheckBox")

                        'Try to convert the text to a decimal. If it fails, then the comparison is false and call it a day
                        If Not Decimal.TryParse(readRow(token), value) Then
                            validChromosome = False
                            Exit For
                        End If

                        'Not within the given range
                        If Not withinRange(value, lowerBox.Value, upperBox.Value, lowerInclusiveCheck.Checked, upperInclusiveCheck.Checked) Then
                            validChromosome = False
                            Exit For
                        End If

                    Else 'Searching by text
                        Dim textBox As TextBox = currentGroupBox.Controls("TextBox")

                        'If the comparison failed, then this chromosome is not valid. Break out of loop and return false
                        If readRow(token) <> textBox.Text.ToString() Then

                            validChromosome = False
                            Exit For

                        End If
                    End If

                End If


            Catch ex As Exception

                'Simple error checking. If shit hits the fan return false and don't bother
                MsgBox(ex.ToString)
                validChromosome = False
                Exit For

            End Try
        Next

    End Function

    'Function to check if value safely in betweeen two values
    Private Function withinRange(value As Decimal, lower As Decimal, upper As Decimal, inclusiveLower As Boolean, inclusiveUpper As Boolean) As Boolean
        withinRange = False
        Dim lowerCheck As Boolean = False
        Dim upperCheck As Boolean = False

        If inclusiveLower Then
            lowerCheck = value >= lower
        Else
            lowerCheck = value > lower
        End If

        If inclusiveUpper Then
            upperCheck = value <= upper
        Else
            upperCheck = value < upper
        End If

        withinRange = lowerCheck And upperCheck

    End Function

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
