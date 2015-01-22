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
        Me.searchBtn = New System.Windows.Forms.Button()
        Me.statusStrip = New System.Windows.Forms.StatusStrip()
        Me.loadingLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.searchProgBar = New System.Windows.Forms.ToolStripProgressBar()
        Me.searchResLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.loadBGWorker = New System.ComponentModel.BackgroundWorker()
        Me.criteriaPanel = New System.Windows.Forms.Panel()
        Me.progTimer = New System.Windows.Forms.Timer(Me.components)
        Me.cancelBtn = New System.Windows.Forms.Button()
        Me.previewDGV = New System.Windows.Forms.DataGridView()
        Me.previewLabel = New System.Windows.Forms.Label()
        Me.chartGrpBox = New System.Windows.Forms.GroupBox()
        Me.pointRadBtn = New System.Windows.Forms.RadioButton()
        Me.barRadBtn = New System.Windows.Forms.RadioButton()
        Me.typeLabel = New System.Windows.Forms.Label()
        Me.dataColLabel = New System.Windows.Forms.Label()
        Me.labelColLabel = New System.Windows.Forms.Label()
        Me.labelCboBox = New System.Windows.Forms.ComboBox()
        Me.dataCboBox = New System.Windows.Forms.ComboBox()
        Me.chartChkBox = New System.Windows.Forms.CheckBox()
        Me.menuStrip.SuspendLayout()
        Me.statusStrip.SuspendLayout()
        CType(Me.previewDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.chartGrpBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'menuStrip
        '
        Me.menuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileMenu, Me.HelpMenu})
        Me.menuStrip.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip.Name = "menuStrip"
        Me.menuStrip.Size = New System.Drawing.Size(836, 24)
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
        Me.resetBtn.Location = New System.Drawing.Point(330, 439)
        Me.resetBtn.Name = "resetBtn"
        Me.resetBtn.Size = New System.Drawing.Size(100, 23)
        Me.resetBtn.TabIndex = 1
        Me.resetBtn.Text = "Reset Parameters"
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
        'searchBtn
        '
        Me.searchBtn.Location = New System.Drawing.Point(76, 439)
        Me.searchBtn.Name = "searchBtn"
        Me.searchBtn.Size = New System.Drawing.Size(75, 23)
        Me.searchBtn.TabIndex = 0
        Me.searchBtn.Text = "Search"
        Me.searchBtn.UseVisualStyleBackColor = True
        '
        'statusStrip
        '
        Me.statusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.loadingLabel, Me.searchProgBar, Me.searchResLabel})
        Me.statusStrip.Location = New System.Drawing.Point(0, 474)
        Me.statusStrip.Name = "statusStrip"
        Me.statusStrip.Size = New System.Drawing.Size(836, 22)
        Me.statusStrip.TabIndex = 24
        '
        'loadingLabel
        '
        Me.loadingLabel.Name = "loadingLabel"
        Me.loadingLabel.Size = New System.Drawing.Size(276, 17)
        Me.loadingLabel.Text = "Loading. . .Please wait, this may take a few minutes"
        Me.loadingLabel.Visible = False
        '
        'searchProgBar
        '
        Me.searchProgBar.Name = "searchProgBar"
        Me.searchProgBar.Size = New System.Drawing.Size(100, 16)
        Me.searchProgBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.searchProgBar.Visible = False
        '
        'searchResLabel
        '
        Me.searchResLabel.Margin = New System.Windows.Forms.Padding(435, 3, 0, 2)
        Me.searchResLabel.Name = "searchResLabel"
        Me.searchResLabel.Size = New System.Drawing.Size(0, 17)
        Me.searchResLabel.Visible = False
        '
        'loadBGWorker
        '
        Me.loadBGWorker.WorkerReportsProgress = True
        Me.loadBGWorker.WorkerSupportsCancellation = True
        '
        'criteriaPanel
        '
        Me.criteriaPanel.AutoScroll = True
        Me.criteriaPanel.Location = New System.Drawing.Point(12, 53)
        Me.criteriaPanel.Name = "criteriaPanel"
        Me.criteriaPanel.Size = New System.Drawing.Size(814, 236)
        Me.criteriaPanel.TabIndex = 25
        '
        'progTimer
        '
        Me.progTimer.Interval = 1000
        '
        'cancelBtn
        '
        Me.cancelBtn.Location = New System.Drawing.Point(203, 439)
        Me.cancelBtn.Name = "cancelBtn"
        Me.cancelBtn.Size = New System.Drawing.Size(75, 23)
        Me.cancelBtn.TabIndex = 26
        Me.cancelBtn.Text = "Cancel"
        Me.cancelBtn.UseVisualStyleBackColor = True
        Me.cancelBtn.Visible = False
        '
        'previewDGV
        '
        Me.previewDGV.AllowUserToAddRows = False
        Me.previewDGV.AllowUserToDeleteRows = False
        Me.previewDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.previewDGV.ColumnHeadersVisible = False
        Me.previewDGV.Location = New System.Drawing.Point(12, 316)
        Me.previewDGV.Name = "previewDGV"
        Me.previewDGV.RowHeadersVisible = False
        Me.previewDGV.Size = New System.Drawing.Size(492, 111)
        Me.previewDGV.TabIndex = 27
        '
        'previewLabel
        '
        Me.previewLabel.AutoSize = True
        Me.previewLabel.Location = New System.Drawing.Point(9, 300)
        Me.previewLabel.Name = "previewLabel"
        Me.previewLabel.Size = New System.Drawing.Size(91, 13)
        Me.previewLabel.TabIndex = 28
        Me.previewLabel.Text = "Input File Preview"
        '
        'chartGrpBox
        '
        Me.chartGrpBox.Controls.Add(Me.pointRadBtn)
        Me.chartGrpBox.Controls.Add(Me.barRadBtn)
        Me.chartGrpBox.Controls.Add(Me.typeLabel)
        Me.chartGrpBox.Controls.Add(Me.dataColLabel)
        Me.chartGrpBox.Controls.Add(Me.labelColLabel)
        Me.chartGrpBox.Controls.Add(Me.labelCboBox)
        Me.chartGrpBox.Controls.Add(Me.dataCboBox)
        Me.chartGrpBox.Controls.Add(Me.chartChkBox)
        Me.chartGrpBox.Location = New System.Drawing.Point(515, 305)
        Me.chartGrpBox.Name = "chartGrpBox"
        Me.chartGrpBox.Size = New System.Drawing.Size(311, 122)
        Me.chartGrpBox.TabIndex = 29
        Me.chartGrpBox.TabStop = False
        Me.chartGrpBox.Text = "Charting Options"
        Me.chartGrpBox.Visible = False
        '
        'pointRadBtn
        '
        Me.pointRadBtn.AutoSize = True
        Me.pointRadBtn.Location = New System.Drawing.Point(6, 92)
        Me.pointRadBtn.Name = "pointRadBtn"
        Me.pointRadBtn.Size = New System.Drawing.Size(77, 17)
        Me.pointRadBtn.TabIndex = 7
        Me.pointRadBtn.TabStop = True
        Me.pointRadBtn.Text = "Point Chart"
        Me.pointRadBtn.UseVisualStyleBackColor = True
        Me.pointRadBtn.Visible = False
        '
        'barRadBtn
        '
        Me.barRadBtn.AutoSize = True
        Me.barRadBtn.Location = New System.Drawing.Point(6, 69)
        Me.barRadBtn.Name = "barRadBtn"
        Me.barRadBtn.Size = New System.Drawing.Size(69, 17)
        Me.barRadBtn.TabIndex = 6
        Me.barRadBtn.TabStop = True
        Me.barRadBtn.Text = "Bar Chart"
        Me.barRadBtn.UseVisualStyleBackColor = True
        Me.barRadBtn.Visible = False
        '
        'typeLabel
        '
        Me.typeLabel.AutoSize = True
        Me.typeLabel.Location = New System.Drawing.Point(3, 53)
        Me.typeLabel.Name = "typeLabel"
        Me.typeLabel.Size = New System.Drawing.Size(59, 13)
        Me.typeLabel.TabIndex = 5
        Me.typeLabel.Text = "Chart Type"
        Me.typeLabel.Visible = False
        '
        'dataColLabel
        '
        Me.dataColLabel.AutoSize = True
        Me.dataColLabel.Location = New System.Drawing.Point(155, 15)
        Me.dataColLabel.Name = "dataColLabel"
        Me.dataColLabel.Size = New System.Drawing.Size(106, 13)
        Me.dataColLabel.TabIndex = 4
        Me.dataColLabel.Text = "Data Column (Y-Axis)"
        Me.dataColLabel.Visible = False
        '
        'labelColLabel
        '
        Me.labelColLabel.AutoSize = True
        Me.labelColLabel.Location = New System.Drawing.Point(155, 69)
        Me.labelColLabel.Name = "labelColLabel"
        Me.labelColLabel.Size = New System.Drawing.Size(109, 13)
        Me.labelColLabel.TabIndex = 3
        Me.labelColLabel.Text = "Label Column (X-Axis)"
        Me.labelColLabel.Visible = False
        '
        'labelCboBox
        '
        Me.labelCboBox.FormattingEnabled = True
        Me.labelCboBox.Location = New System.Drawing.Point(158, 85)
        Me.labelCboBox.Name = "labelCboBox"
        Me.labelCboBox.Size = New System.Drawing.Size(147, 21)
        Me.labelCboBox.TabIndex = 2
        Me.labelCboBox.Visible = False
        '
        'dataCboBox
        '
        Me.dataCboBox.FormattingEnabled = True
        Me.dataCboBox.Location = New System.Drawing.Point(158, 31)
        Me.dataCboBox.Name = "dataCboBox"
        Me.dataCboBox.Size = New System.Drawing.Size(147, 21)
        Me.dataCboBox.TabIndex = 1
        Me.dataCboBox.Visible = False
        '
        'chartChkBox
        '
        Me.chartChkBox.AutoSize = True
        Me.chartChkBox.Location = New System.Drawing.Point(6, 19)
        Me.chartChkBox.Name = "chartChkBox"
        Me.chartChkBox.Size = New System.Drawing.Size(89, 17)
        Me.chartChkBox.TabIndex = 0
        Me.chartChkBox.Text = "Chart Results"
        Me.chartChkBox.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(836, 496)
        Me.Controls.Add(Me.chartGrpBox)
        Me.Controls.Add(Me.previewLabel)
        Me.Controls.Add(Me.previewDGV)
        Me.Controls.Add(Me.cancelBtn)
        Me.Controls.Add(Me.criteriaPanel)
        Me.Controls.Add(Me.statusStrip)
        Me.Controls.Add(Me.resetBtn)
        Me.Controls.Add(Me.searchBtn)
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
        Me.statusStrip.ResumeLayout(False)
        Me.statusStrip.PerformLayout()
        CType(Me.previewDGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.chartGrpBox.ResumeLayout(False)
        Me.chartGrpBox.PerformLayout()
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
    Friend WithEvents searchBtn As System.Windows.Forms.Button
    Friend WithEvents resetBtn As System.Windows.Forms.Button
    Friend WithEvents statusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents loadingLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents loadBGWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents criteriaPanel As System.Windows.Forms.Panel
    Friend WithEvents progTimer As System.Windows.Forms.Timer
    Friend WithEvents searchProgBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents cancelBtn As System.Windows.Forms.Button
    Friend WithEvents previewDGV As System.Windows.Forms.DataGridView
    Friend WithEvents previewLabel As System.Windows.Forms.Label
    Friend WithEvents searchResLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents chartGrpBox As System.Windows.Forms.GroupBox
    Friend WithEvents pointRadBtn As System.Windows.Forms.RadioButton
    Friend WithEvents barRadBtn As System.Windows.Forms.RadioButton
    Friend WithEvents typeLabel As System.Windows.Forms.Label
    Friend WithEvents dataColLabel As System.Windows.Forms.Label
    Friend WithEvents labelColLabel As System.Windows.Forms.Label
    Friend WithEvents labelCboBox As System.Windows.Forms.ComboBox
    Friend WithEvents dataCboBox As System.Windows.Forms.ComboBox
    Friend WithEvents chartChkBox As System.Windows.Forms.CheckBox

End Class
