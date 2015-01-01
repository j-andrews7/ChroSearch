<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.menuStrip = New System.Windows.Forms.MenuStrip()
        Me.FileMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.openMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.exportMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.resetTT = New System.Windows.Forms.ToolTip(Me.components)
        Me.resetBtn = New System.Windows.Forms.Button()
        Me.datasrcTxtB = New System.Windows.Forms.TextBox()
        Me.datasrcLabel = New System.Windows.Forms.Label()
        Me.importFD = New System.Windows.Forms.OpenFileDialog()
        Me.exportFD = New System.Windows.Forms.SaveFileDialog()
        Me.searchProgBar = New System.Windows.Forms.ProgressBar()
        Me.searchProgLabel = New System.Windows.Forms.Label()
        Me.searLabel = New System.Windows.Forms.Label()
        Me.searchTxtB = New System.Windows.Forms.TextBox()
        Me.startLabel = New System.Windows.Forms.Label()
        Me.endLabel = New System.Windows.Forms.Label()
        Me.chromLabel = New System.Windows.Forms.Label()
        Me.endTxtB = New System.Windows.Forms.TextBox()
        Me.startTxtB = New System.Windows.Forms.TextBox()
        Me.mmpidLabel = New System.Windows.Forms.Label()
        Me.mmpidTxtB = New System.Windows.Forms.TextBox()
        Me.searchBtn = New System.Windows.Forms.Button()
        Me.geneLabel = New System.Windows.Forms.Label()
        Me.geneTxtB = New System.Windows.Forms.TextBox()
        Me.sampleIdTxtB = New System.Windows.Forms.TextBox()
        Me.sampleIDLabel = New System.Windows.Forms.Label()
        Me.paramGrpB = New System.Windows.Forms.GroupBox()
        Me.filterGrpB = New System.Windows.Forms.GroupBox()
        Me.chrFiltPanel = New System.Windows.Forms.Panel()
        Me.ovlpRadBtn = New System.Windows.Forms.RadioButton()
        Me.btwnRadBtn = New System.Windows.Forms.RadioButton()
        Me.statusStrip = New System.Windows.Forms.StatusStrip()
        Me.loadingLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.backgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.chromTxtB = New System.Windows.Forms.TextBox()
        Me.menuStrip.SuspendLayout()
        Me.paramGrpB.SuspendLayout()
        Me.filterGrpB.SuspendLayout()
        Me.chrFiltPanel.SuspendLayout()
        Me.statusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'menuStrip
        '
        Me.menuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileMenu, Me.HelpMenu})
        Me.menuStrip.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip.Name = "menuStrip"
        Me.menuStrip.Size = New System.Drawing.Size(792, 24)
        Me.menuStrip.TabIndex = 5
        '
        'FileMenu
        '
        Me.FileMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.openMenuItem, Me.exportMenuItem, Me.ExitToolStripMenuItem})
        Me.FileMenu.Name = "FileMenu"
        Me.FileMenu.Size = New System.Drawing.Size(37, 20)
        Me.FileMenu.Text = "File"
        '
        'openMenuItem
        '
        Me.openMenuItem.Name = "openMenuItem"
        Me.openMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.openMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.openMenuItem.Text = "Open File"
        Me.openMenuItem.ToolTipText = "Select input for program."
        '
        'exportMenuItem
        '
        Me.exportMenuItem.Name = "exportMenuItem"
        Me.exportMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.exportMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.exportMenuItem.Text = "Export Results"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(187, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'HelpMenu
        '
        Me.HelpMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HelpToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.HelpMenu.Name = "HelpMenu"
        Me.HelpMenu.Size = New System.Drawing.Size(44, 20)
        Me.HelpMenu.Text = "Help"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.HelpToolStripMenuItem.Text = "Help"
        Me.HelpToolStripMenuItem.ToolTipText = "Instructions for usage of program"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'resetBtn
        '
        Me.resetBtn.Location = New System.Drawing.Point(454, 417)
        Me.resetBtn.Name = "resetBtn"
        Me.resetBtn.Size = New System.Drawing.Size(75, 23)
        Me.resetBtn.TabIndex = 1
        Me.resetBtn.Text = "Reset"
        Me.resetTT.SetToolTip(Me.resetBtn, "Clears all search parameters.")
        Me.resetBtn.UseVisualStyleBackColor = True
        '
        'datasrcTxtB
        '
        Me.datasrcTxtB.Location = New System.Drawing.Point(79, 27)
        Me.datasrcTxtB.Name = "datasrcTxtB"
        Me.datasrcTxtB.ReadOnly = True
        Me.datasrcTxtB.Size = New System.Drawing.Size(564, 20)
        Me.datasrcTxtB.TabIndex = 10
        '
        'datasrcLabel
        '
        Me.datasrcLabel.AutoSize = True
        Me.datasrcLabel.Location = New System.Drawing.Point(9, 30)
        Me.datasrcLabel.Name = "datasrcLabel"
        Me.datasrcLabel.Size = New System.Drawing.Size(70, 13)
        Me.datasrcLabel.TabIndex = 11
        Me.datasrcLabel.Text = "Data Source:"
        '
        'searchProgBar
        '
        Me.searchProgBar.Location = New System.Drawing.Point(57, 427)
        Me.searchProgBar.Name = "searchProgBar"
        Me.searchProgBar.Size = New System.Drawing.Size(200, 21)
        Me.searchProgBar.Step = 1
        Me.searchProgBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.searchProgBar.TabIndex = 18
        Me.searchProgBar.Visible = False
        '
        'searchProgLabel
        '
        Me.searchProgLabel.AutoSize = True
        Me.searchProgLabel.Location = New System.Drawing.Point(57, 411)
        Me.searchProgLabel.Name = "searchProgLabel"
        Me.searchProgLabel.Size = New System.Drawing.Size(62, 13)
        Me.searchProgLabel.TabIndex = 19
        Me.searchProgLabel.Text = "Running. . ."
        Me.searchProgLabel.Visible = False
        '
        'searLabel
        '
        Me.searLabel.AutoSize = True
        Me.searLabel.Location = New System.Drawing.Point(578, 422)
        Me.searLabel.Name = "searLabel"
        Me.searLabel.Size = New System.Drawing.Size(65, 13)
        Me.searLabel.TabIndex = 21
        Me.searLabel.Text = "Search Hits:"
        '
        'searchTxtB
        '
        Me.searchTxtB.Location = New System.Drawing.Point(640, 419)
        Me.searchTxtB.Name = "searchTxtB"
        Me.searchTxtB.ReadOnly = True
        Me.searchTxtB.Size = New System.Drawing.Size(106, 20)
        Me.searchTxtB.TabIndex = 22
        '
        'startLabel
        '
        Me.startLabel.AutoSize = True
        Me.startLabel.Location = New System.Drawing.Point(3, 24)
        Me.startLabel.Name = "startLabel"
        Me.startLabel.Size = New System.Drawing.Size(29, 13)
        Me.startLabel.TabIndex = 3
        Me.startLabel.Text = "Start"
        '
        'endLabel
        '
        Me.endLabel.AutoSize = True
        Me.endLabel.Location = New System.Drawing.Point(243, 24)
        Me.endLabel.Name = "endLabel"
        Me.endLabel.Size = New System.Drawing.Size(26, 13)
        Me.endLabel.TabIndex = 4
        Me.endLabel.Text = "End"
        '
        'chromLabel
        '
        Me.chromLabel.AutoSize = True
        Me.chromLabel.Location = New System.Drawing.Point(3, 85)
        Me.chromLabel.Name = "chromLabel"
        Me.chromLabel.Size = New System.Drawing.Size(79, 13)
        Me.chromLabel.TabIndex = 2
        Me.chromLabel.Text = "Chromosome(s)"
        '
        'endTxtB
        '
        Me.endTxtB.Location = New System.Drawing.Point(246, 40)
        Me.endTxtB.Name = "endTxtB"
        Me.endTxtB.Size = New System.Drawing.Size(150, 20)
        Me.endTxtB.TabIndex = 7
        '
        'startTxtB
        '
        Me.startTxtB.Location = New System.Drawing.Point(6, 40)
        Me.startTxtB.Name = "startTxtB"
        Me.startTxtB.Size = New System.Drawing.Size(150, 20)
        Me.startTxtB.TabIndex = 8
        '
        'mmpidLabel
        '
        Me.mmpidLabel.AutoSize = True
        Me.mmpidLabel.Location = New System.Drawing.Point(6, 24)
        Me.mmpidLabel.Name = "mmpidLabel"
        Me.mmpidLabel.Size = New System.Drawing.Size(43, 13)
        Me.mmpidLabel.TabIndex = 5
        Me.mmpidLabel.Text = "MMPID"
        '
        'mmpidTxtB
        '
        Me.mmpidTxtB.Location = New System.Drawing.Point(9, 40)
        Me.mmpidTxtB.Name = "mmpidTxtB"
        Me.mmpidTxtB.Size = New System.Drawing.Size(182, 20)
        Me.mmpidTxtB.TabIndex = 6
        '
        'searchBtn
        '
        Me.searchBtn.Location = New System.Drawing.Point(321, 417)
        Me.searchBtn.Name = "searchBtn"
        Me.searchBtn.Size = New System.Drawing.Size(75, 23)
        Me.searchBtn.TabIndex = 0
        Me.searchBtn.Text = "Search"
        Me.searchBtn.UseVisualStyleBackColor = True
        '
        'geneLabel
        '
        Me.geneLabel.AutoSize = True
        Me.geneLabel.Location = New System.Drawing.Point(6, 85)
        Me.geneLabel.Name = "geneLabel"
        Me.geneLabel.Size = New System.Drawing.Size(33, 13)
        Me.geneLabel.TabIndex = 10
        Me.geneLabel.Text = "Gene"
        '
        'geneTxtB
        '
        Me.geneTxtB.Location = New System.Drawing.Point(9, 101)
        Me.geneTxtB.Name = "geneTxtB"
        Me.geneTxtB.Size = New System.Drawing.Size(182, 20)
        Me.geneTxtB.TabIndex = 11
        '
        'sampleIdTxtB
        '
        Me.sampleIdTxtB.Location = New System.Drawing.Point(9, 159)
        Me.sampleIdTxtB.Name = "sampleIdTxtB"
        Me.sampleIdTxtB.Size = New System.Drawing.Size(182, 20)
        Me.sampleIdTxtB.TabIndex = 12
        '
        'sampleIDLabel
        '
        Me.sampleIDLabel.AutoSize = True
        Me.sampleIDLabel.Location = New System.Drawing.Point(6, 143)
        Me.sampleIDLabel.Name = "sampleIDLabel"
        Me.sampleIDLabel.Size = New System.Drawing.Size(56, 13)
        Me.sampleIDLabel.TabIndex = 13
        Me.sampleIDLabel.Text = "Sample ID"
        '
        'paramGrpB
        '
        Me.paramGrpB.Controls.Add(Me.sampleIDLabel)
        Me.paramGrpB.Controls.Add(Me.sampleIdTxtB)
        Me.paramGrpB.Controls.Add(Me.geneTxtB)
        Me.paramGrpB.Controls.Add(Me.geneLabel)
        Me.paramGrpB.Controls.Add(Me.mmpidTxtB)
        Me.paramGrpB.Controls.Add(Me.mmpidLabel)
        Me.paramGrpB.Location = New System.Drawing.Point(12, 60)
        Me.paramGrpB.Name = "paramGrpB"
        Me.paramGrpB.Size = New System.Drawing.Size(207, 326)
        Me.paramGrpB.TabIndex = 6
        Me.paramGrpB.TabStop = False
        Me.paramGrpB.Text = "Search Parameters"
        '
        'filterGrpB
        '
        Me.filterGrpB.Controls.Add(Me.chromTxtB)
        Me.filterGrpB.Controls.Add(Me.chrFiltPanel)
        Me.filterGrpB.Controls.Add(Me.chromLabel)
        Me.filterGrpB.Controls.Add(Me.endLabel)
        Me.filterGrpB.Controls.Add(Me.startLabel)
        Me.filterGrpB.Controls.Add(Me.endTxtB)
        Me.filterGrpB.Controls.Add(Me.startTxtB)
        Me.filterGrpB.Location = New System.Drawing.Point(225, 60)
        Me.filterGrpB.Name = "filterGrpB"
        Me.filterGrpB.Size = New System.Drawing.Size(558, 326)
        Me.filterGrpB.TabIndex = 23
        Me.filterGrpB.TabStop = False
        Me.filterGrpB.Text = "Filters"
        '
        'chrFiltPanel
        '
        Me.chrFiltPanel.Controls.Add(Me.ovlpRadBtn)
        Me.chrFiltPanel.Controls.Add(Me.btwnRadBtn)
        Me.chrFiltPanel.Location = New System.Drawing.Point(412, 19)
        Me.chrFiltPanel.Name = "chrFiltPanel"
        Me.chrFiltPanel.Size = New System.Drawing.Size(118, 57)
        Me.chrFiltPanel.TabIndex = 10
        '
        'ovlpRadBtn
        '
        Me.ovlpRadBtn.AutoSize = True
        Me.ovlpRadBtn.Location = New System.Drawing.Point(3, 23)
        Me.ovlpRadBtn.Name = "ovlpRadBtn"
        Me.ovlpRadBtn.Size = New System.Drawing.Size(106, 30)
        Me.ovlpRadBtn.TabIndex = 1
        Me.ovlpRadBtn.TabStop = True
        Me.ovlpRadBtn.Text = "Overlapping " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Start/End Range"
        Me.ovlpRadBtn.UseVisualStyleBackColor = True
        '
        'btwnRadBtn
        '
        Me.btwnRadBtn.AutoSize = True
        Me.btwnRadBtn.Location = New System.Drawing.Point(3, 0)
        Me.btwnRadBtn.Name = "btwnRadBtn"
        Me.btwnRadBtn.Size = New System.Drawing.Size(116, 17)
        Me.btwnRadBtn.TabIndex = 0
        Me.btwnRadBtn.TabStop = True
        Me.btwnRadBtn.Text = "Between Start/End"
        Me.btwnRadBtn.UseVisualStyleBackColor = True
        '
        'statusStrip
        '
        Me.statusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.loadingLabel})
        Me.statusStrip.Location = New System.Drawing.Point(0, 456)
        Me.statusStrip.Name = "statusStrip"
        Me.statusStrip.Size = New System.Drawing.Size(792, 22)
        Me.statusStrip.TabIndex = 24
        Me.statusStrip.Text = "StatusStrip1"
        Me.statusStrip.Visible = False
        '
        'loadingLabel
        '
        Me.loadingLabel.Name = "loadingLabel"
        Me.loadingLabel.Size = New System.Drawing.Size(125, 17)
        Me.loadingLabel.Text = "Loading. . .Please Wait"
        '
        'backgroundWorker1
        '
        Me.backgroundWorker1.WorkerReportsProgress = True
        Me.backgroundWorker1.WorkerSupportsCancellation = True
        '
        'chromTxtB
        '
        Me.chromTxtB.Location = New System.Drawing.Point(6, 101)
        Me.chromTxtB.Name = "chromTxtB"
        Me.chromTxtB.Size = New System.Drawing.Size(150, 20)
        Me.chromTxtB.TabIndex = 11
        '
        'MainForm
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 478)
        Me.Controls.Add(Me.statusStrip)
        Me.Controls.Add(Me.filterGrpB)
        Me.Controls.Add(Me.searchTxtB)
        Me.Controls.Add(Me.searLabel)
        Me.Controls.Add(Me.searchProgLabel)
        Me.Controls.Add(Me.resetBtn)
        Me.Controls.Add(Me.searchBtn)
        Me.Controls.Add(Me.searchProgBar)
        Me.Controls.Add(Me.datasrcLabel)
        Me.Controls.Add(Me.datasrcTxtB)
        Me.Controls.Add(Me.paramGrpB)
        Me.Controls.Add(Me.menuStrip)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.menuStrip
        Me.MaximizeBox = False
        Me.Name = "MainForm"
        Me.Text = "ChroSearch"
        Me.menuStrip.ResumeLayout(False)
        Me.menuStrip.PerformLayout()
        Me.paramGrpB.ResumeLayout(False)
        Me.paramGrpB.PerformLayout()
        Me.filterGrpB.ResumeLayout(False)
        Me.filterGrpB.PerformLayout()
        Me.chrFiltPanel.ResumeLayout(False)
        Me.chrFiltPanel.PerformLayout()
        Me.statusStrip.ResumeLayout(False)
        Me.statusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents menuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents FileMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents openMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents exportMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents resetTT As System.Windows.Forms.ToolTip
    Friend WithEvents datasrcTxtB As System.Windows.Forms.TextBox
    Friend WithEvents datasrcLabel As System.Windows.Forms.Label
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents importFD As System.Windows.Forms.OpenFileDialog
    Friend WithEvents exportFD As System.Windows.Forms.SaveFileDialog
    Friend WithEvents searchProgBar As System.Windows.Forms.ProgressBar
    Friend WithEvents searchProgLabel As System.Windows.Forms.Label
    Friend WithEvents searLabel As System.Windows.Forms.Label
    Friend WithEvents searchTxtB As System.Windows.Forms.TextBox
    Friend WithEvents startLabel As System.Windows.Forms.Label
    Friend WithEvents endLabel As System.Windows.Forms.Label
    Friend WithEvents chromLabel As System.Windows.Forms.Label
    Friend WithEvents endTxtB As System.Windows.Forms.TextBox
    Friend WithEvents startTxtB As System.Windows.Forms.TextBox
    Friend WithEvents mmpidLabel As System.Windows.Forms.Label
    Friend WithEvents mmpidTxtB As System.Windows.Forms.TextBox
    Friend WithEvents searchBtn As System.Windows.Forms.Button
    Friend WithEvents resetBtn As System.Windows.Forms.Button
    Friend WithEvents geneLabel As System.Windows.Forms.Label
    Friend WithEvents geneTxtB As System.Windows.Forms.TextBox
    Friend WithEvents sampleIdTxtB As System.Windows.Forms.TextBox
    Friend WithEvents sampleIDLabel As System.Windows.Forms.Label
    Friend WithEvents paramGrpB As System.Windows.Forms.GroupBox
    Friend WithEvents filterGrpB As System.Windows.Forms.GroupBox
    Friend WithEvents chrFiltPanel As System.Windows.Forms.Panel
    Friend WithEvents ovlpRadBtn As System.Windows.Forms.RadioButton
    Friend WithEvents btwnRadBtn As System.Windows.Forms.RadioButton
    Friend WithEvents statusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents loadingLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents backgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents chromTxtB As System.Windows.Forms.TextBox

End Class
