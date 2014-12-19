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
        Me.searchBtn = New System.Windows.Forms.Button()
        Me.resetBtn = New System.Windows.Forms.Button()
        Me.chromLabel = New System.Windows.Forms.Label()
        Me.startLabel = New System.Windows.Forms.Label()
        Me.endLabel = New System.Windows.Forms.Label()
        Me.menuStrip = New System.Windows.Forms.MenuStrip()
        Me.FileMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.openMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.exportMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.paramGrpB = New System.Windows.Forms.GroupBox()
        Me.geneTxtB = New System.Windows.Forms.TextBox()
        Me.geneLabel = New System.Windows.Forms.Label()
        Me.chromTxtB = New System.Windows.Forms.TextBox()
        Me.startTxtB = New System.Windows.Forms.TextBox()
        Me.endTxtB = New System.Windows.Forms.TextBox()
        Me.mmpidTxtB = New System.Windows.Forms.TextBox()
        Me.mmpidLabel = New System.Windows.Forms.Label()
        Me.resetTT = New System.Windows.Forms.ToolTip(Me.components)
        Me.datasrcTxtB = New System.Windows.Forms.TextBox()
        Me.datasrcLabel = New System.Windows.Forms.Label()
        Me.importFD = New System.Windows.Forms.OpenFileDialog()
        Me.exportFD = New System.Windows.Forms.SaveFileDialog()
        Me.progBar = New System.Windows.Forms.ProgressBar()
        Me.runLabel = New System.Windows.Forms.Label()
        Me.exportBtn = New System.Windows.Forms.Button()
        Me.searLabel = New System.Windows.Forms.Label()
        Me.searchTxtB = New System.Windows.Forms.TextBox()
        Me.menuStrip.SuspendLayout()
        Me.paramGrpB.SuspendLayout()
        Me.SuspendLayout()
        '
        'searchBtn
        '
        Me.searchBtn.Location = New System.Drawing.Point(18, 302)
        Me.searchBtn.Name = "searchBtn"
        Me.searchBtn.Size = New System.Drawing.Size(75, 23)
        Me.searchBtn.TabIndex = 0
        Me.searchBtn.Text = "Search"
        Me.searchBtn.UseVisualStyleBackColor = True
        '
        'resetBtn
        '
        Me.resetBtn.Location = New System.Drawing.Point(105, 302)
        Me.resetBtn.Name = "resetBtn"
        Me.resetBtn.Size = New System.Drawing.Size(75, 23)
        Me.resetBtn.TabIndex = 1
        Me.resetBtn.Text = "Reset"
        Me.resetTT.SetToolTip(Me.resetBtn, "Clears all search parameters.")
        Me.resetBtn.UseVisualStyleBackColor = True
        '
        'chromLabel
        '
        Me.chromLabel.AutoSize = True
        Me.chromLabel.Location = New System.Drawing.Point(6, 33)
        Me.chromLabel.Name = "chromLabel"
        Me.chromLabel.Size = New System.Drawing.Size(68, 13)
        Me.chromLabel.TabIndex = 2
        Me.chromLabel.Text = "Chromosome"
        '
        'startLabel
        '
        Me.startLabel.AutoSize = True
        Me.startLabel.Location = New System.Drawing.Point(6, 85)
        Me.startLabel.Name = "startLabel"
        Me.startLabel.Size = New System.Drawing.Size(29, 13)
        Me.startLabel.TabIndex = 3
        Me.startLabel.Text = "Start"
        '
        'endLabel
        '
        Me.endLabel.AutoSize = True
        Me.endLabel.Location = New System.Drawing.Point(6, 143)
        Me.endLabel.Name = "endLabel"
        Me.endLabel.Size = New System.Drawing.Size(26, 13)
        Me.endLabel.TabIndex = 4
        Me.endLabel.Text = "End"
        '
        'menuStrip
        '
        Me.menuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileMenu, Me.HelpMenu})
        Me.menuStrip.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip.Name = "menuStrip"
        Me.menuStrip.Size = New System.Drawing.Size(1038, 24)
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
        'paramGrpB
        '
        Me.paramGrpB.Controls.Add(Me.geneTxtB)
        Me.paramGrpB.Controls.Add(Me.geneLabel)
        Me.paramGrpB.Controls.Add(Me.chromTxtB)
        Me.paramGrpB.Controls.Add(Me.resetBtn)
        Me.paramGrpB.Controls.Add(Me.startTxtB)
        Me.paramGrpB.Controls.Add(Me.searchBtn)
        Me.paramGrpB.Controls.Add(Me.endTxtB)
        Me.paramGrpB.Controls.Add(Me.mmpidTxtB)
        Me.paramGrpB.Controls.Add(Me.mmpidLabel)
        Me.paramGrpB.Controls.Add(Me.chromLabel)
        Me.paramGrpB.Controls.Add(Me.endLabel)
        Me.paramGrpB.Controls.Add(Me.startLabel)
        Me.paramGrpB.Location = New System.Drawing.Point(12, 60)
        Me.paramGrpB.Name = "paramGrpB"
        Me.paramGrpB.Size = New System.Drawing.Size(631, 340)
        Me.paramGrpB.TabIndex = 6
        Me.paramGrpB.TabStop = False
        Me.paramGrpB.Text = "Search Parameters"
        '
        'geneTxtB
        '
        Me.geneTxtB.Location = New System.Drawing.Point(9, 271)
        Me.geneTxtB.Name = "geneTxtB"
        Me.geneTxtB.Size = New System.Drawing.Size(182, 20)
        Me.geneTxtB.TabIndex = 11
        '
        'geneLabel
        '
        Me.geneLabel.AutoSize = True
        Me.geneLabel.Location = New System.Drawing.Point(6, 255)
        Me.geneLabel.Name = "geneLabel"
        Me.geneLabel.Size = New System.Drawing.Size(33, 13)
        Me.geneLabel.TabIndex = 10
        Me.geneLabel.Text = "Gene"
        '
        'chromTxtB
        '
        Me.chromTxtB.Location = New System.Drawing.Point(9, 49)
        Me.chromTxtB.Name = "chromTxtB"
        Me.chromTxtB.Size = New System.Drawing.Size(182, 20)
        Me.chromTxtB.TabIndex = 9
        '
        'startTxtB
        '
        Me.startTxtB.Location = New System.Drawing.Point(9, 101)
        Me.startTxtB.Name = "startTxtB"
        Me.startTxtB.Size = New System.Drawing.Size(182, 20)
        Me.startTxtB.TabIndex = 8
        '
        'endTxtB
        '
        Me.endTxtB.Location = New System.Drawing.Point(9, 159)
        Me.endTxtB.Name = "endTxtB"
        Me.endTxtB.Size = New System.Drawing.Size(182, 20)
        Me.endTxtB.TabIndex = 7
        '
        'mmpidTxtB
        '
        Me.mmpidTxtB.Location = New System.Drawing.Point(9, 218)
        Me.mmpidTxtB.Name = "mmpidTxtB"
        Me.mmpidTxtB.Size = New System.Drawing.Size(182, 20)
        Me.mmpidTxtB.TabIndex = 6
        '
        'mmpidLabel
        '
        Me.mmpidLabel.AutoSize = True
        Me.mmpidLabel.Location = New System.Drawing.Point(6, 202)
        Me.mmpidLabel.Name = "mmpidLabel"
        Me.mmpidLabel.Size = New System.Drawing.Size(43, 13)
        Me.mmpidLabel.TabIndex = 5
        Me.mmpidLabel.Text = "MMPID"
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
        'progBar
        '
        Me.progBar.Location = New System.Drawing.Point(418, 433)
        Me.progBar.Name = "progBar"
        Me.progBar.Size = New System.Drawing.Size(200, 21)
        Me.progBar.Step = 1
        Me.progBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.progBar.TabIndex = 18
        Me.progBar.Visible = False
        '
        'runLabel
        '
        Me.runLabel.AutoSize = True
        Me.runLabel.Location = New System.Drawing.Point(418, 417)
        Me.runLabel.Name = "runLabel"
        Me.runLabel.Size = New System.Drawing.Size(62, 13)
        Me.runLabel.TabIndex = 19
        Me.runLabel.Text = "Running. . ."
        Me.runLabel.Visible = False
        '
        'exportBtn
        '
        Me.exportBtn.Location = New System.Drawing.Point(911, 424)
        Me.exportBtn.Name = "exportBtn"
        Me.exportBtn.Size = New System.Drawing.Size(83, 23)
        Me.exportBtn.TabIndex = 20
        Me.exportBtn.Text = "Export Results"
        Me.exportBtn.UseVisualStyleBackColor = True
        '
        'searLabel
        '
        Me.searLabel.AutoSize = True
        Me.searLabel.Location = New System.Drawing.Point(652, 430)
        Me.searLabel.Name = "searLabel"
        Me.searLabel.Size = New System.Drawing.Size(65, 13)
        Me.searLabel.TabIndex = 21
        Me.searLabel.Text = "Search Hits:"
        '
        'searchTxtB
        '
        Me.searchTxtB.Location = New System.Drawing.Point(714, 427)
        Me.searchTxtB.Name = "searchTxtB"
        Me.searchTxtB.ReadOnly = True
        Me.searchTxtB.Size = New System.Drawing.Size(147, 20)
        Me.searchTxtB.TabIndex = 22
        '
        'MainForm
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1038, 466)
        Me.Controls.Add(Me.searchTxtB)
        Me.Controls.Add(Me.searLabel)
        Me.Controls.Add(Me.exportBtn)
        Me.Controls.Add(Me.runLabel)
        Me.Controls.Add(Me.progBar)
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
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents searchBtn As System.Windows.Forms.Button
    Friend WithEvents resetBtn As System.Windows.Forms.Button
    Friend WithEvents chromLabel As System.Windows.Forms.Label
    Friend WithEvents startLabel As System.Windows.Forms.Label
    Friend WithEvents endLabel As System.Windows.Forms.Label
    Friend WithEvents menuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents FileMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents openMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents exportMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents paramGrpB As System.Windows.Forms.GroupBox
    Friend WithEvents chromTxtB As System.Windows.Forms.TextBox
    Friend WithEvents startTxtB As System.Windows.Forms.TextBox
    Friend WithEvents endTxtB As System.Windows.Forms.TextBox
    Friend WithEvents mmpidTxtB As System.Windows.Forms.TextBox
    Friend WithEvents mmpidLabel As System.Windows.Forms.Label
    Friend WithEvents resetTT As System.Windows.Forms.ToolTip
    Friend WithEvents datasrcTxtB As System.Windows.Forms.TextBox
    Friend WithEvents datasrcLabel As System.Windows.Forms.Label
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents importFD As System.Windows.Forms.OpenFileDialog
    Friend WithEvents exportFD As System.Windows.Forms.SaveFileDialog
    Friend WithEvents geneTxtB As System.Windows.Forms.TextBox
    Friend WithEvents geneLabel As System.Windows.Forms.Label
    Friend WithEvents progBar As System.Windows.Forms.ProgressBar
    Friend WithEvents runLabel As System.Windows.Forms.Label
    Friend WithEvents exportBtn As System.Windows.Forms.Button
    Friend WithEvents searLabel As System.Windows.Forms.Label
    Friend WithEvents searchTxtB As System.Windows.Forms.TextBox

End Class
