'Author contact: jared.andrews07@gmail.com
Imports System.IO.File
Imports System.ComponentModel
Imports System.Threading

Public Class MainForm

    'Creates instance of HelpForm so multiple can't be created by clicking help multiple times
    'Create global instances of the datatables and line count of the input file
    Dim helpForm As New HelpForm
    Dim fileSizeKB As Integer
    Dim colCount As Integer
    Dim filepath As String
    Dim searchHits As Integer
    Dim lineBytes As Double
    Dim progBarValue As Double

    Dim searchList As New Generic.List(Of SearchCriteria)

    'Imports the file and returns the file path.
    Public Sub getFileImport()
        Dim importFD As New OpenFileDialog

        importFD.Title = "Open a text file"
        importFD.Filter = "Text Files(*.txt)|*.txt" 'Limits user to only opening .txt files.
        Dim result = importFD.ShowDialog()
        If result = DialogResult.Cancel Then 'Only recording path if file is actually opened.
            Me.Cursor = Cursors.Default
        Else
            filepath = importFD.FileName
            progTimer.Interval = 1000
        End If

        Return
    End Sub

    'Allows user to drag and drop input file into program
    Private Sub MainForm_DragDrop(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles Me.DragDrop
        Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
        filepath = System.IO.Path.GetFullPath(files(0))
        Dim fileExt As String = System.IO.Path.GetExtension(files(0))

        If fileExt = ".txt" Then 'Checks to be sure the input is a .txt file
            Me.Cursor = Cursors.WaitCursor 'Changes the cursor to wait cursor so user knows file is loading
            loadingLabel.Visible = True    'Makes loading label in statusbar visible to show user that file is loading
            loadingLabel.Text = "Loading...Please wait, this may take a few minutes."
            datasrcTxtB.Text = filepath
            loadBGWorker.RunWorkerAsync(filepath)
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
        getFileImport() 'Sets the file path

        'If filepath isn't blank, then loads the selected file using the loadBGWorker.
        If filepath <> "" Then
            Me.Cursor = Cursors.WaitCursor 'Changes the cursor to wait cursor so user knows file is loading
            loadingLabel.Visible = True    'Makes loading label in statusbar visible to show user that file is loading
            loadingLabel.Text = "Loading...Please wait, this may take a few minutes."
            datasrcTxtB.Text = filepath
            loadBGWorker.RunWorkerAsync(filepath)
        End If


    End Sub

    'Dynamically generated textboxes
    Private Sub createSearchOptions(filePath As String)
        Try
            Using reader As New IO.StreamReader(filePath)
                Dim tokenized() As String
                Dim xPosition As Integer = 0
                Dim yPosition As Integer = 0
                Dim newRow As Double

                'Clear any and all previous controls from the panel
                searchList.Clear()
                criteriaPanel.Controls.Clear()

                'Split line by tab characters
                tokenized = Split(reader.ReadLine(), vbTab)
                colCount = tokenized.Length

                'Make textBoxes
                For token As Integer = 0 To tokenized.Length - 1
                    'Make search criteria's controls
                    createSearchCriteria(tokenized(token), xPosition, yPosition)

                    newRow = ((token + 1) / 4)
                    'Shift x-position
                    xPosition += 200

                    If newRow = 1 Or newRow = 2 Or newRow = 3 Or newRow = 4 Or newRow = 5 Or newRow = 6 _
                        Or newRow = 7 Or newRow = 8 Or newRow = 9 Then
                        xPosition = 0
                        yPosition += 220
                    End If

                Next

            End Using
        Catch e As Exception
            Console.WriteLine(e.ToString)
        End Try
    End Sub

    'Make search criteria's controls
    Private Sub createSearchCriteria(criteriaName As String, xPosition As Integer, yPosition As Integer)
        Dim newSearchCriteria As New SearchCriteria(criteriaName, criteriaPanel, xPosition, yPosition)
        ' Add to list
        searchList.Add(newSearchCriteria)

        criteriaPanel.Refresh()
    End Sub

    Private Function getSearchBox(index As Integer) As SearchCriteria
        getSearchBox = Nothing

        If searchList.Count >= index Then
            getSearchBox = searchList.Item(index)
        End If

    End Function

    Private Function getSearchBox(name As String) As SearchCriteria
        getSearchBox = Nothing

        For Each criteria As SearchCriteria In searchList
            If criteria.name = name Then
                getSearchBox = criteria
                Exit For
            End If
        Next
    End Function

    'Shows "About" information from the help menu.
    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        MsgBox("ChroSearch Developed by the Payton Lab", , "About ChroSearch")
    End Sub


    'Clears the search parameters in the searchDataGridView when the reset button is clicked.
    Private Sub resetBtn_Click(sender As Object, e As EventArgs) Handles resetBtn.Click

        For Each grpBox As GroupBox In criteriaPanel.Controls.OfType(Of GroupBox)()

            For Each radbutton As RadioButton In grpBox.Controls.OfType(Of RadioButton)()
                radbutton.Checked = False
                radbutton.Visible = False
            Next

            For Each cbox As CheckBox In grpBox.Controls.OfType(Of CheckBox)()
                cbox.Checked = False

            Next

            For Each tbox As TextBox In grpBox.Controls.OfType(Of TextBox)()
                tbox.Text = vbNullString
                tbox.Visible = False
            Next

            For Each updown As NumericUpDown In grpBox.Controls.OfType(Of NumericUpDown)()
                updown.Value = 0
                updown.Visible = False
            Next

            For Each lbl As Label In grpBox.Controls.OfType(Of Label)()
                lbl.Visible = False
            Next

            For Each chkbox As CheckBox In grpBox.Controls.OfType(Of CheckBox)()
                If chkbox.Text = "Inclusive" Then
                    chkbox.Checked = False
                    chkbox.Visible = False
                End If
            Next
        Next

        Me.Update()

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
    Private Sub searchBtn_Click(sender As Object, e As EventArgs) Handles searchBtn.Click
        Dim searchThreads As New Generic.List(Of System.Threading.Thread)
        Dim textBatch As New Generic.List(Of String)
        Dim writeThread As New System.Threading.Thread(Sub() Me.writePeriodically(exportFD.FileName, textBatch, searchThreads))

        'Prompts user to enter title of file to be created
        exportFD.Title = "Save as. . ."
        exportFD.Filter = "Text Files(*.txt)|*.txt" 'Limits user to only saving as .txt file
        Dim result = exportFD.ShowDialog()

        If result = DialogResult.Cancel Then 'Handles if Cancel Button of dialog is clicked
            Return
        Else

            Dim writer As New IO.StreamWriter(exportFD.FileName, False) 'False (overwrite now)
            Dim reader As New IO.StreamReader(filepath)
            searchHits = 0 'Reset search results
            progBarValue = 0
            searchProgBar.Visible = True
            progTimer.Start()

            'Locks each searchbox so user can't change parameters during search
            For Each ctrl As Control In criteriaPanel.Controls
                ctrl.Enabled = False
            Next

            Me.resetBtn.Enabled = False
            Me.searchBtn.Enabled = False
            loadingLabel.Visible = True

            'write columns into export file
            writer.WriteLine(reader.ReadLine())

            'Close out reader
            reader.Close()
            writer.Close()

            'multithreading nonsense
            searchThreads.Add(New System.Threading.Thread(Sub() Me.searchFile(textBatch, 0, 1)))
            searchThreads.Add(New System.Threading.Thread(Sub() Me.searchFile(textBatch, 1, 1)))

            For i As Integer = 0 To searchThreads.Count - 1
                searchThreads(i).Name = "SearchProcess" & i.ToString()
                searchThreads(i).IsBackground = True
                searchThreads(i).Start()
            Next

            writeThread.Start()

        End If

    End Sub


    Private Sub writePeriodically(fileName As String, textBatch As List(Of String), searchThreads As List(Of System.Threading.Thread))
        Dim writer As New IO.StreamWriter(fileName, True)
        Dim searchFinished = False
        Dim searchWatch As Stopwatch = Stopwatch.StartNew()
        Dim sThreadsSleep As Boolean = False

        Do
            searchFinished = True
            For Each thread As System.Threading.Thread In searchThreads
                If thread.IsAlive = True Then
                    searchFinished = False
                    Exit For
                End If
            Next

            sThreadsSleep = True
            For Each thrd As System.Threading.Thread In searchThreads
                If thrd.ThreadState <> ThreadState.WaitSleepJoin Then
                    sThreadsSleep = False
                    Exit For
                End If
            Next

            If sThreadsSleep = True Then
                For Each result As String In textBatch
                    writer.WriteLine(result)
                    searchHits += 1
                Next
                textBatch.Clear()
                For Each thd As System.Threading.Thread In searchThreads
                    thd.Interrupt()
                Next
            End If


            If searchFinished = True Then
                For Each result As String In textBatch
                    writer.WriteLine(result)
                    searchHits += 1
                Next
                textBatch.Clear()
            End If

        Loop While searchFinished = False

        searchWatch.Stop()
        progTimer.Stop()
        writer.Close()
        threadProcSafe()
        MsgBox("Saved to: " + fileName + ". " + searchHits.ToString() + " search results found in " + _
               searchWatch.Elapsed.ToString() + ".")


    End Sub

    'These three functions allow setting text of searchTxtB from outside UI thread
    'and allow controls in the criteriaPanel to be re-enabled after search finishes
    Delegate Sub setTextCallback([text] As String, [bool] As Boolean, [number] As Integer)

    Private Sub SetText(ByVal [text] As String, ByVal [bool] As Boolean, ByVal [number] As Integer)

        ' InvokeRequired required compares the thread ID of the 
        ' calling thread to the thread ID of the creating thread. 
        ' If these threads are different, it returns true. 
        If Me.searchTxtB.InvokeRequired Then
            Dim d As New setTextCallback(AddressOf SetText)
            Me.Invoke(d, New Object() {[text], [bool], [number]})
        Else
            Me.searchTxtB.Text = [text]
            Me.searchProgBar.Value = [number]
        End If

        'Re-enables each of the filter groupboxes once the search is complete
        If Me.criteriaPanel.InvokeRequired Then
            Dim f As New setTextCallback(AddressOf SetText)
            Me.Invoke(f, New Object() {[text], [bool], [number]})
        Else
            For Each ctrl As Control In Me.criteriaPanel.Controls
                ctrl.Enabled = [bool]
            Next

            'Re-enables search and reset buttons once the search is complete
            For Each btn As Button In Me.Controls.OfType(Of Button)()
                btn.Enabled = [bool]
            Next
        End If
    End Sub

    Private Sub threadProcSafe()
        Me.SetText(searchHits.ToString(), True, searchProgBar.Maximum)
    End Sub


    Private Sub searchFile(textBatch As List(Of String), startPos As Integer, skipSize As Integer)
        Dim reader As New IO.StreamReader(filepath)
        Dim currentLine As String

        'Skip column headers
        currentLine = reader.ReadLine()

        'Startpos
        For i As Integer = 0 To startPos - 1
            reader.ReadLine()
        Next

        'Search whole file, line by line
        Do While reader.Peek() > 0
            'next line
            currentLine = reader.ReadLine()

            'new function:
            If validChromosome(currentLine) Then
                textBatch.Add(currentLine)
            End If

            'skip appropriately
            For i As Integer = 0 To skipSize - 1
                reader.ReadLine()
            Next

            Try
                If textBatch.Count >= 25000 Then
                    Thread.Sleep(Timeout.Infinite)
                End If
            Catch ex As ThreadInterruptedException
                Exit Try
            End Try
        Loop

        'Close out writer and reader and tell user file was saved
        reader.Close()

    End Sub

    'This function searches through the current chromosome and checks if it follows what the user has searched for
    Private Function validChromosome(chromString As String) As Boolean
        Dim readRow() As String
        validChromosome = True 'Start off as true

        'Split line by tab characters
        readRow = Split(chromString, vbTab)
        progBarValue += lineBytes

        'iterate through string tokens and compare (simple comparison for now, this working will be a miracle in itself)
        For token As Integer = 0 To readRow.Length - 1
            Dim currentSearchCriteria As SearchCriteria = getSearchBox(token)

            If Not currentSearchCriteria Is Nothing Then
                Try
                    Dim shouldSearch As Boolean = currentSearchCriteria.criteriaCheckBox.Checked

                    'User wants to search this parameter
                    If shouldSearch Then
                        Dim numericSearch As Boolean = currentSearchCriteria.numericRadio.Checked

                        'Searching by number
                        If numericSearch Then

                            Dim currValue As Decimal

                            'Try to convert the text to a decimal. If it fails, then the comparison is false and call it a day
                            If Not Decimal.TryParse(readRow(token), currValue) Then
                                validChromosome = False
                                Exit For
                            End If

                            'Not within the given range
                            If Not withinRange(currValue, currentSearchCriteria.numericLowerSearch,
                                                          currentSearchCriteria.numericUpperSearch,
                                                          currentSearchCriteria.numericIncludeLower,
                                                          currentSearchCriteria.numericIncludeUpper) Then
                                validChromosome = False
                                Exit For
                            End If

                        Else 'Searching by text

                            'If the comparison failed, then this chromosome is not valid. 
                            'Break out of loop and return false.
                            'Iterates through each string entered by user.
                            Dim tempValidity As Boolean = False
                            For i As Integer = 0 To currentSearchCriteria.stringSearch.Length - 1

                                If String.Equals(readRow(token), currentSearchCriteria.stringSearch(i), StringComparison.OrdinalIgnoreCase) Then

                                    tempValidity = True
                                    Exit For
                                End If
                            Next

                            If tempValidity = False Then
                                validChromosome = False
                                Exit For
                            End If
                            Exit For
                        End If

                    End If


                Catch ex As Exception

                    'Simple error checking. If everything goes to hell, return false and don't bother.
                    MsgBox(ex.ToString)
                    validChromosome = False
                    Exit For

                End Try
            End If

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
        Dim reader As New IO.StreamReader(filepath)
        Dim fileInfo As New IO.FileInfo(filepath)
        Dim fileLenKB As Long = fileInfo.Length / 1024
        fileSizeKB = CInt(fileLenKB)

        'Estimates size of each line in KB for use by progbar
        For i As Integer = 0 To 1
            lineBytes = ((reader.ReadLine().Length * 1.2) / 1024)
        Next

    End Sub

    'Updates statusbar and returns cursor to normal after loadBGWorker finishes work.
    Private Sub loadBGWorker_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles loadBGWorker.RunWorkerCompleted
        Me.Cursor = Cursors.Default
        loadingLabel.Text = "File loaded: " + fileSizeKB.ToString() + " KB to search"
        searchProgBar.Maximum = fileSizeKB

        createSearchOptions(filepath)
    End Sub

    'Updates progress bar every second
    Private Sub progTimer_Tick(sender As Object, e As EventArgs) Handles progTimer.Tick
        If progBarValue < searchProgBar.Maximum Then
            searchProgBar.Value = CInt(progBarValue)
            loadingLabel.Text = "Searching...Approximately " + _
                CInt((searchProgBar.Value / searchProgBar.Maximum) * 100).ToString() + "% Complete"
        Else
            searchProgBar.Value = searchProgBar.Maximum
            loadingLabel.Text = "Search complete!"
        End If
    End Sub
End Class

'custom class
Public Class SearchCriteria
    Public name As String
    Public radioBox As New GroupBox

    Public criteriaCheckBox As New CheckBox
    Public numericRadio As New RadioButton
    Public stringRadio As New RadioButton

    Dim numericLabel1 As New Label
    Dim numericLabel2 As New Label
    Public numericBoxLower As New TextBox
    Public numericBoxUpper As New TextBox
    Public numericInclusiveCheckLower As New CheckBox
    Public numericInclusiveCheckUpper As New CheckBox

    Dim stringLabel As New Label
    Public stringTextBox As New TextBox

    Public stringSearch() As String
    Public numericLowerSearch As Decimal
    Public numericUpperSearch As Decimal
    Public numericIncludeLower As Boolean = False
    Public numericIncludeUpper As Boolean = False

    Public Function isNumeric() As Boolean
        isNumeric = False
        If numericRadio.Checked = True Then
            isNumeric = True
        End If

    End Function

    Public Sub New(criteriaName As String, criteriaPanel As Panel, xPosition As Integer, yPosition As Integer)
        name = criteriaName

        'groupbox for entire thing
        radioBox.Name = criteriaName & "GroupBox"
        radioBox.Text = ""
        radioBox.Location = New Point(xPosition, yPosition)
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
        numericBoxLower.Location = New Point(7, 105)
        numericBoxLower.Width = 80
        numericBoxLower.Visible = False
        radioBox.Controls.Add(numericBoxLower)

        numericBoxUpper.Name = "NumericBoxUpper"
        numericBoxUpper.Location = New Point(105, 105)
        numericBoxUpper.Width = 80
        numericBoxUpper.Visible = False
        radioBox.Controls.Add(numericBoxUpper)

        numericLabel1.Name = "NumericLabel1"
        numericLabel1.Text = "Between:"
        numericLabel1.Location = New Point(10 - 2, 80) '-2 for sake of neat alignment
        numericLabel1.Visible = False
        radioBox.Controls.Add(numericLabel1)

        numericLabel2.Name = "NumericLabel2"
        numericLabel2.Text = "&"
        numericLabel2.UseMnemonic = False
        numericLabel2.Location = New Point(89, 108)
        numericLabel2.Visible = False
        radioBox.Controls.Add(numericLabel2)

        numericInclusiveCheckLower.Name = "NumericInclusiveLowerCheckBox"
        numericInclusiveCheckLower.Text = "Inclusive"
        numericInclusiveCheckLower.Width = 70
        numericInclusiveCheckLower.Location = New Point(10 - 2, 130)
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

        AddHandler stringTextBox.TextChanged,
        Sub()
            stringSearch = stringTextBox.Text().Split(New Char() {","c})
        End Sub

        AddHandler numericBoxLower.TextChanged,
        Sub()
            Decimal.TryParse(numericBoxLower.Text(), numericLowerSearch)
        End Sub

        AddHandler numericBoxUpper.TextChanged,
        Sub()
            Decimal.TryParse(numericBoxUpper.Text(), numericUpperSearch)
        End Sub

        AddHandler numericInclusiveCheckLower.CheckedChanged,
        Sub()
            numericIncludeLower = numericInclusiveCheckLower.Checked
        End Sub

        AddHandler numericInclusiveCheckUpper.CheckedChanged,
        Sub()
            numericIncludeUpper = numericInclusiveCheckUpper.Checked
        End Sub


        radioBox.Refresh()
    End Sub
End Class
