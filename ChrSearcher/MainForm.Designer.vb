﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.searchBtn = New System.Windows.Forms.Button()
        Me.filterGrpB = New System.Windows.Forms.GroupBox()
        Me.searchDataGridView = New System.Windows.Forms.DataGridView()
        Me.chrFiltPanel = New System.Windows.Forms.Panel()
        Me.ovlpRadBtn = New System.Windows.Forms.RadioButton()
        Me.btwnRadBtn = New System.Windows.Forms.RadioButton()
        Me.statusStrip = New System.Windows.Forms.StatusStrip()
        Me.loadingLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.loadBGWorker = New System.ComponentModel.BackgroundWorker()
        Me.optionsGrpB = New System.Windows.Forms.GroupBox()
        Me.menuStrip.SuspendLayout()
        Me.filterGrpB.SuspendLayout()
        CType(Me.searchDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.chrFiltPanel.SuspendLayout()
        Me.statusStrip.SuspendLayout()
        Me.optionsGrpB.SuspendLayout()
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
        Me.resetBtn.Location = New System.Drawing.Point(437, 307)
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
        Me.searchProgBar.Location = New System.Drawing.Point(40, 317)
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
        Me.searchProgLabel.Location = New System.Drawing.Point(40, 301)
        Me.searchProgLabel.Name = "searchProgLabel"
        Me.searchProgLabel.Size = New System.Drawing.Size(62, 13)
        Me.searchProgLabel.TabIndex = 19
        Me.searchProgLabel.Text = "Running. . ."
        Me.searchProgLabel.Visible = False
        '
        'searLabel
        '
        Me.searLabel.AutoSize = True
        Me.searLabel.Location = New System.Drawing.Point(561, 312)
        Me.searLabel.Name = "searLabel"
        Me.searLabel.Size = New System.Drawing.Size(65, 13)
        Me.searLabel.TabIndex = 21
        Me.searLabel.Text = "Search Hits:"
        '
        'searchTxtB
        '
        Me.searchTxtB.Location = New System.Drawing.Point(623, 309)
        Me.searchTxtB.Name = "searchTxtB"
        Me.searchTxtB.ReadOnly = True
        Me.searchTxtB.Size = New System.Drawing.Size(106, 20)
        Me.searchTxtB.TabIndex = 22
        '
        'searchBtn
        '
        Me.searchBtn.Location = New System.Drawing.Point(304, 307)
        Me.searchBtn.Name = "searchBtn"
        Me.searchBtn.Size = New System.Drawing.Size(75, 23)
        Me.searchBtn.TabIndex = 0
        Me.searchBtn.Text = "Search"
        Me.searchBtn.UseVisualStyleBackColor = True
        '
        'filterGrpB
        '
        Me.filterGrpB.Controls.Add(Me.optionsGrpB)
        Me.filterGrpB.Controls.Add(Me.searchDataGridView)
        Me.filterGrpB.Location = New System.Drawing.Point(12, 60)
        Me.filterGrpB.Name = "filterGrpB"
        Me.filterGrpB.Size = New System.Drawing.Size(771, 231)
        Me.filterGrpB.TabIndex = 23
        Me.filterGrpB.TabStop = False
        Me.filterGrpB.Text = "Filters"
        '
        'searchDataGridView
        '
        Me.searchDataGridView.AllowUserToAddRows = False
        Me.searchDataGridView.AllowUserToDeleteRows = False
        Me.searchDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.searchDataGridView.Location = New System.Drawing.Point(6, 19)
        Me.searchDataGridView.Name = "searchDataGridView"
        Me.searchDataGridView.RowHeadersVisible = False
        Me.searchDataGridView.Size = New System.Drawing.Size(759, 63)
        Me.searchDataGridView.TabIndex = 2
        '
        'chrFiltPanel
        '
        Me.chrFiltPanel.Controls.Add(Me.ovlpRadBtn)
        Me.chrFiltPanel.Controls.Add(Me.btwnRadBtn)
        Me.chrFiltPanel.Location = New System.Drawing.Point(6, 19)
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
        Me.statusStrip.Location = New System.Drawing.Point(0, 348)
        Me.statusStrip.Name = "statusStrip"
        Me.statusStrip.Size = New System.Drawing.Size(792, 22)
        Me.statusStrip.TabIndex = 24
        Me.statusStrip.UseWaitCursor = True
        '
        'loadingLabel
        '
        Me.loadingLabel.Name = "loadingLabel"
        Me.loadingLabel.Size = New System.Drawing.Size(276, 17)
        Me.loadingLabel.Text = "Loading. . .Please wait, this may take a few minutes"
        Me.loadingLabel.Visible = False
        '
        'loadBGWorker
        '
        Me.loadBGWorker.WorkerReportsProgress = True
        Me.loadBGWorker.WorkerSupportsCancellation = True
        '
        'optionsGrpB
        '
        Me.optionsGrpB.Controls.Add(Me.chrFiltPanel)
        Me.optionsGrpB.Location = New System.Drawing.Point(6, 88)
        Me.optionsGrpB.Name = "optionsGrpB"
        Me.optionsGrpB.Size = New System.Drawing.Size(759, 137)
        Me.optionsGrpB.TabIndex = 11
        Me.optionsGrpB.TabStop = False
        Me.optionsGrpB.Text = "Options"
        '
        'MainForm
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 370)
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
        Me.Controls.Add(Me.menuStrip)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.menuStrip
        Me.MaximizeBox = False
        Me.Name = "MainForm"
        Me.Text = "ChroSearch"
        Me.menuStrip.ResumeLayout(False)
        Me.menuStrip.PerformLayout()
        Me.filterGrpB.ResumeLayout(False)
        CType(Me.searchDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.chrFiltPanel.ResumeLayout(False)
        Me.chrFiltPanel.PerformLayout()
        Me.statusStrip.ResumeLayout(False)
        Me.statusStrip.PerformLayout()
        Me.optionsGrpB.ResumeLayout(False)
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
    Friend WithEvents searchBtn As System.Windows.Forms.Button
    Friend WithEvents resetBtn As System.Windows.Forms.Button
    Friend WithEvents filterGrpB As System.Windows.Forms.GroupBox
    Friend WithEvents chrFiltPanel As System.Windows.Forms.Panel
    Friend WithEvents ovlpRadBtn As System.Windows.Forms.RadioButton
    Friend WithEvents btwnRadBtn As System.Windows.Forms.RadioButton
    Friend WithEvents statusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents loadingLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents loadBGWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents searchDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents optionsGrpB As System.Windows.Forms.GroupBox

End Class
