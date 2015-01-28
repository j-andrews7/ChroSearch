'Author contact: jared.andrews07@gmail.com
Imports System.IO.File
Imports System.ComponentModel
Imports System.Threading

Public Class MainForm

    'Declare variables
    Dim helpForm As New HelpForm
    Dim fileSizeKB As Integer
    Dim colCount As Integer
    Dim filepath As String
    Dim searchHits As Integer
    Dim lineBytes As Double
    Dim progBarValue As Double
    Dim cancelSearch As Boolean
    Dim chartResults As Boolean
    Dim dataCboSelection As Integer
    Dim labelCboSelection As Integer
    Dim dataList As New List(Of Double)
    Dim labelList As New List(Of String)
    Dim chartType As Integer
    Dim chartXTitle As String
    Dim chartYTitle As String
    Dim waitAll(1) As ManualResetEvent
    Dim searchMREs(1) As ManualResetEvent
    Dim threadDead(1) As Boolean

    Dim searchList As New Generic.List(Of SearchCriteria)

    'Imports the file and returns the file path.
    Public Sub getFileImport()
        Dim importFD As New OpenFileDialog

        importFD.Title = "Open a text file"
        importFD.Filter = "Text Files(*.txt;*.bed;*.tsv)|*.txt;*.bed;*.tsv|All Files (*.*)|*.*"
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

        loadingLabel.Visible = True
        datasrcTxtB.Text = filepath
        loadBGWorker.RunWorkerAsync(filepath)
        loadPreviewDGV(filepath)

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
            Dim reader As New IO.StreamReader(filepath)
            Dim line As New List(Of String)
            Me.Cursor = Cursors.WaitCursor 'Changes the cursor to wait cursor so user knows file is loading
            loadingLabel.Visible = True    'Makes loading label in statusbar visible to show user that file is loading
            loadingLabel.Text = "Loading...Please wait, this may take a moment."
            datasrcTxtB.Text = filepath

            loadBGWorker.RunWorkerAsync(filepath)

            loadPreviewDGV(filepath)

        End If


    End Sub

    'Loads the input file into the preview datagridview
    Private Sub loadPreviewDGV(filePath As String)
        Dim reader As New IO.StreamReader(filePath)
        Dim line As New List(Of String)

        For i As Integer = 0 To previewDGV.Rows.Count - 1
            previewDGV.Rows.RemoveAt(0)
        Next

        'Add first 3 lines of file to list so that they may be added to the preview datagridview
        For i As Integer = 0 To 3
            line.Add(reader.ReadLine())
        Next

        'Adds columns to previewDGV
        previewDGV.ColumnCount = Split(line(0), vbTab).Length

        'Adds rows to previewDGV
        For Each item As String In line
            previewDGV.Rows.Add(Split(item, vbTab))
        Next

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
        'Add to list
        searchList.Add(newSearchCriteria)

        'Allows for drawing of the controls
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
        MsgBox("ChroSearch: Developed by the Payton Lab", , "About ChroSearch")
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
    Private Async Sub searchBtn_Click(sender As Object, e As EventArgs) Handles searchBtn.Click
        Dim searchThreads As New Generic.List(Of System.Threading.Thread)
        Dim batchOne As New Generic.List(Of String)
        Dim batchTwo As New Generic.List(Of String)
        cancelSearch = False

        'Prompts user to enter title of file to be created
        exportFD.Title = "Save as. . ."
        exportFD.Filter = "Text Files(*.txt)|*.txt|All Files(*.*)|*.*" 'Limits user to only saving as .txt file
        Dim result = exportFD.ShowDialog()

        If result = DialogResult.Cancel Then 'Handles if Cancel Button of dialog is clicked
            Return
        Else

            Dim writer As New IO.StreamWriter(exportFD.FileName, False) 'False (overwrite now)
            Dim reader As New IO.StreamReader(filepath)

            searchHits = 0 'Reset search results
            progBarValue = 0
            searchProgBar.Visible = True
            searchResLabel.Visible = False
            progTimer.Start()

            If dataList.Count > 0 Then
                dataList.Clear()
            End If

            If labelList.Count > 0 Then
                labelList.Clear()
            End If

            If chartChkBox.Checked Then
                chartResults = True
                dataCboSelection = dataCboBox.SelectedIndex
                labelCboSelection = labelCboBox.SelectedIndex
            Else
                chartResults = False
            End If

            'Locks each searchbox/buttons so user can't change parameters during search
            For Each ctrl As Control In criteriaPanel.Controls
                ctrl.Enabled = False
            Next

            For Each contr As Control In chartGrpBox.Controls
                contr.Enabled = False
            Next

            Me.resetBtn.Enabled = False
            Me.searchBtn.Enabled = False
            Me.cancelBtn.Visible = True
            loadingLabel.Visible = True

            'Write columns into export file
            writer.WriteLine(reader.ReadLine())

            'Close out reader
            reader.Close()
            writer.Close()

            'Set wait all events
            waitAll(0) = New ManualResetEvent(False)
            waitAll(1) = New ManualResetEvent(False)

            searchMREs(0) = New ManualResetEvent(False)
            searchMREs(1) = New ManualResetEvent(False)


            'Starts two search threads
            searchThreads.Add(New System.Threading.Thread(Sub() Me.searchFile(batchOne, 0, 1)))
            searchThreads.Add(New System.Threading.Thread(Sub() Me.searchFile(batchTwo, 1, 1)))

            For i As Integer = 0 To searchThreads.Count - 1
                searchThreads(i).Name = i.ToString()
                searchThreads(i).IsBackground = True
                searchThreads(i).Start()
            Next

            'Waits for writing to finish so that charting won't be done till after all results are found.
            'Also handles if the cancel button is clicked
            Try
                Await Task.Run(Sub() Me.writePeriodically(exportFD.FileName, batchOne, batchTwo, searchThreads))
            Catch ex As OperationCanceledException
                loadingLabel.Text = "Search canceled."
            Catch ex As Exception
                MsgBox(ex.ToString, MsgBoxStyle.OkOnly, "Error!")
            End Try

            'If user selected charting, set the chart type and title based on the columns they selected.
            Try
                If chartResults Then
                    If chartType = 0 Then
                        chartXTitle = (labelCboBox.SelectedItem.ToString())
                        chartYTitle = (dataCboBox.SelectedItem.ToString())
                    Else
                        chartXTitle = (labelCboBox.SelectedItem.ToString())
                        chartYTitle = (dataCboBox.SelectedItem.ToString())
                    End If
                    createChart(dataList, labelList, chartType, chartXTitle, chartYTitle)
                End If
            Catch err As Exception
                MsgBox(err.ToString(), , "Charting Error")
            End Try

        End If

    End Sub

    'Writes the contents of the textbatches whenever they have
    '>50000 results in them, then clears the textbatches and resumes the search threads.
    Private Sub writePeriodically(fileName As String, batchOne As List(Of String), batchTwo As List(Of String), _
                                  searchThreads As List(Of System.Threading.Thread))
        Dim writer As New IO.StreamWriter(fileName, True)
        Dim searchFinished = False
        Dim searchWatch As Stopwatch = Stopwatch.StartNew()
        Dim writeOut As Boolean = False

        Do

            If searchFinished Then
                Exit Do
            End If

            WaitHandle.WaitAll(waitAll)
            waitAll(0).Reset()
            waitAll(1).Reset()

            'If search is canceled, clear the textbatches and safely reset UI
            If cancelSearch Then
                Try
                    progTimer.Stop()
                    batchOne.Clear()
                    batchTwo.Clear()
                    chartResults = False
                    threadCancelSafe()
                    Exit Sub
                Catch e As Exception
                    Console.Write(e.InnerException.ToString())
                End Try
            End If

            searchFinished = True
            For Each thread As System.Threading.Thread In searchThreads
                If Not threadDead(CInt(thread.Name())) Then
                    searchFinished = False
                    Exit For
                End If
            Next

            Console.WriteLine(batchOne.Count.ToString() + " " + batchTwo.Count.ToString())
            If batchOne.Count + batchTwo.Count >= 50000 Then
                writeOut = True
            End If


            If writeOut Then

                chartResults = False

                For Each result As String In batchOne
                    writer.WriteLine(result)
                    searchHits += 1
                Next
                For Each result As String In batchTwo
                    writer.WriteLine(result)
                    searchHits += 1
                Next
                batchOne.Clear()
                batchTwo.Clear()

                searchMREs(0).Set()
                searchMREs(1).Set()

                'Reset writeOut so it doesn't continually cause the writer to write
                writeOut = False


            End If

        Loop While searchFinished = False

        'Handle remaining results after loop has ended. 
        'Chart results if the user checked the chart results option
        If chartResults Then
            Dim temp() As String

            'Checks and sets chart type
            If barRadBtn.Checked Then
                chartType = 0
            ElseIf pointRadBtn.Checked Then
                chartType = 1
            End If

            'Writes the results to the export file, increases the searchHits variable 
            'and adds the data to the lists for the charts.
            Try
                For Each result As String In batchOne
                    writer.WriteLine(result)
                    searchHits += 1
                    temp = Split(result, vbTab)
                    dataList.Add(CDec(temp(dataCboSelection)))
                    labelList.Add(temp(labelCboSelection))
                Next
                For Each result As String In batchTwo
                    writer.WriteLine(result)
                    searchHits += 1
                    temp = Split(result, vbTab)
                    dataList.Add(CDec(temp(dataCboSelection)))
                    labelList.Add(temp(labelCboSelection))
                Next

            Catch e As Exception
                MsgBox(e.ToString(), , "Charting Error")
                chartResults = False
            End Try
        Else
            'If not charting, just write the results to file and increase the searchHits variable
            For Each result As String In batchOne
                writer.WriteLine(result)
                searchHits += 1
            Next
            For Each result As String In batchTwo
                writer.WriteLine(result)
                searchHits += 1
            Next

        End If

        'Clears the text batches after writing is complete, stops the stopwatch, stops the timer updated the UI
        'close the StreamWriter, and safely re-enable the appropriate controls with threadProcSafe().
        batchOne.Clear()
        batchTwo.Clear()

        searchWatch.Stop()
        progTimer.Stop()
        writer.Close()
        threadProcSafe()
        MsgBox("Saved to: " + fileName + ". " + searchHits.ToString() + " search results found in " + _
               searchWatch.Elapsed.ToString() + ".")

    End Sub

    'Creates the chart form and displays the appropriate data when called
    Private Sub createChart(dataList As List(Of Double), labelList As List(Of String), chartType As Integer, chartXTitle As String, _
                            chartYTitle As String)
        Dim chart As ChartForm
        chart = New ChartForm(dataList, labelList, chartType, chartXTitle, chartYTitle)
        chart.Show()
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

            If textBatch.Count >= 25000 Then
                waitAll(CInt(Thread.CurrentThread.Name)).Set()
                searchMREs(CInt(Thread.CurrentThread.Name)).WaitOne()
                searchMREs(CInt(Thread.CurrentThread.Name)).Reset()
            End If

            If cancelSearch Then
                Exit Do
            End If

            'new function:
            If validChromosome(currentLine) Then
                textBatch.Add(currentLine)
            End If

            'skip appropriately
            For i As Integer = 0 To skipSize - 1
                reader.ReadLine()
            Next

        Loop

        'Close out the reader and allow the writer thread to continue
        reader.Close()
        threadDead(CInt(Thread.CurrentThread.Name)) = True
        waitAll(CInt(Thread.CurrentThread.Name)).Set()

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
                            validChromosome = False
                            For i As Integer = 0 To currentSearchCriteria.stringSearch.Length - 1

                                If sameString(readRow(token), currentSearchCriteria.stringSearch(i)) = True Then
                                    validChromosome = True
                                    Exit For
                                End If
                            Next

                            'If after comparing all the strings in the search parameter, validChromosome is still false
                            'then don't check later search parameters.
                            If validChromosome = False Then
                                Exit For
                            End If
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

    Private Function sameString(string1 As String, string2 As String)
        sameString = False
        If String.Equals(string1.Trim(), string2.Trim(), StringComparison.OrdinalIgnoreCase) Then
            sameString = True
        End If

        Return sameString
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
        dataCboBox.Items.Clear()
        labelCboBox.Items.Clear()

        'Populates the charting options comboboxes and makes the charting options controls visible.
        For Each criteria As SearchCriteria In searchList
            dataCboBox.Items.Add(criteria.name)
            labelCboBox.Items.Add(criteria.name)
        Next

        'Sets comboboxes to a value so they aren't blank by default
        If dataCboBox.Items.Count > 0 Then
            dataCboBox.SelectedIndex = 0
        End If

        If labelCboBox.Items.Count > 0 Then
            labelCboBox.SelectedIndex = 0
        End If

        'Makes the charting options box visible.
        chartGrpBox.Visible = True
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

    'Cancels search when clicked.
    Private Sub cancelBtn_Click(sender As Object, e As EventArgs) Handles cancelBtn.Click
        cancelSearch = True
    End Sub

    'Controls visibility of chart controls when the chart results checkbox is checked/unchecked
    Private Sub chartChkBox_CheckedChanged(sender As Object, e As EventArgs) Handles chartChkBox.CheckedChanged
        If chartChkBox.Checked Then
            barRadBtn.Visible = True
            pointRadBtn.Visible = True
            typeLabel.Visible = True
            dataColLabel.Visible = True
            labelColLabel.Visible = True
            dataCboBox.Visible = True
            labelCboBox.Visible = True
        ElseIf chartChkBox.Checked = False Then
            barRadBtn.Visible = False
            pointRadBtn.Visible = False
            typeLabel.Visible = False
            dataColLabel.Visible = False
            labelColLabel.Visible = False
            dataCboBox.Visible = False
            labelCboBox.Visible = False
        End If
    End Sub


    'These three functions allow setting text of searchTxtB from outside UI thread
    'and allow controls in the criteriaPanel to be re-enabled after search finishes
    Delegate Sub setTextCallback([text] As String, [bool] As Boolean, [number] As Integer, [bool2] As Boolean, [num2] As Integer)

    Private Sub SetText(ByVal [text] As String, ByVal [bool] As Boolean, ByVal [number] As Integer, ByVal [bool2] As Boolean, ByVal [num2] As Integer)

        ' InvokeRequired required compares the thread ID of the 
        ' calling thread to the thread ID of the creating thread. 
        ' If these threads are different, it returns true. 

        'Re-enables each of the filter groupboxes once the search is complete
        If Me.criteriaPanel.InvokeRequired Then
            Dim f As New setTextCallback(AddressOf SetText)
            Me.Invoke(f, New Object() {[text], [bool], [number], [bool2], [num2]})
        Else
            For Each ctrl As Control In Me.criteriaPanel.Controls
                ctrl.Enabled = [bool]
                Me.searchResLabel.Text = "Search results: " + [text]
                Me.searchResLabel.Visible = [bool]
                Me.searchProgBar.Value = [number]
            Next

            For Each contr As Control In Me.chartGrpBox.Controls
                contr.Enabled = [bool]
            Next

            'Re-enables search and reset buttons once the search is complete
            Me.resetBtn.Enabled = [bool]
            Me.searchBtn.Enabled = [bool]
            Me.cancelBtn.Visible = [bool2]
        End If
    End Sub

    Private Sub threadProcSafe()
        Me.SetText(searchHits.ToString(), True, searchProgBar.Maximum, False, 0)
    End Sub

    'These three functions allow setting text of searchTxtB from outside UI thread
    'and allow controls in the criteriaPanel to be re-enabled after search finishes
    Delegate Sub setReset([text] As String, [bool] As Boolean, [number] As Integer, [bool2] As Boolean)

    Private Sub Reset(ByVal [text] As String, ByVal [bool] As Boolean, ByVal [number] As Integer, ByVal [bool2] As Boolean)

        ' InvokeRequired required compares the thread ID of the 
        ' calling thread to the thread ID of the creating thread. 
        ' If these threads are different, it returns true. 

        'Re-enables each of the filter groupboxes once the search is complete
        Try
            If Me.criteriaPanel.InvokeRequired Then
                Dim f As New setReset(AddressOf Reset)
                Me.Invoke(f, New Object() {[text], [bool], [number], [bool2]})
            Else
                For Each ctrl As Control In Me.criteriaPanel.Controls
                    ctrl.Enabled = [bool]
                Next

                Me.loadingLabel.Text = [text]
                Me.searchProgBar.Value = [number]

                For Each contr As Control In Me.chartGrpBox.Controls
                    contr.Enabled = [bool]
                Next

                'Re-enables search and reset buttons once the search is complete
                Me.resetBtn.Enabled = [bool]
                Me.searchBtn.Enabled = [bool]
                Me.cancelBtn.Visible = [bool2]
                Me.searchProgBar.Visible = [bool2]
            End If

        Catch e As Exception
            Console.Write(e.InnerException.ToString())
        End Try
    End Sub

    Private Sub threadCancelSafe()
        Try
            Me.Reset("Search canceled", True, 0, False)
        Catch e As Exception
            Console.Write(e.InnerException.ToString())
        End Try
    End Sub

    Private Sub barRadBtn_CheckedChanged(sender As Object, e As EventArgs) Handles barRadBtn.CheckedChanged
        If barRadBtn.Checked Then
            chartType = 0
        End If
    End Sub

    Private Sub pointRadBtn_CheckedChanged(sender As Object, e As EventArgs) Handles pointRadBtn.CheckedChanged
        If pointRadBtn.Checked Then
            chartType = 1
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
