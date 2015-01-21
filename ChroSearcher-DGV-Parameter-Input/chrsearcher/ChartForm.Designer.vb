<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChartForm
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ChartForm))
        Me.resultsChart = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.saveBtn = New System.Windows.Forms.Button()
        Me.closeBtn = New System.Windows.Forms.Button()
        Me.saveImageDialog = New System.Windows.Forms.SaveFileDialog()
        CType(Me.resultsChart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'resultsChart
        '
        ChartArea1.AxisX.IsLabelAutoFit = False
        ChartArea1.BackColor = System.Drawing.Color.White
        ChartArea1.BackImageTransparentColor = System.Drawing.Color.White
        ChartArea1.Name = "resultsChart"
        Me.resultsChart.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.resultsChart.Legends.Add(Legend1)
        Me.resultsChart.Location = New System.Drawing.Point(12, 12)
        Me.resultsChart.Name = "resultsChart"
        Series1.ChartArea = "resultsChart"
        Series1.Legend = "Legend1"
        Series1.Name = "dataSeries"
        Me.resultsChart.Series.Add(Series1)
        Me.resultsChart.Size = New System.Drawing.Size(800, 388)
        Me.resultsChart.TabIndex = 0
        Me.resultsChart.Text = "Results Chart"
        '
        'saveBtn
        '
        Me.saveBtn.Location = New System.Drawing.Point(296, 406)
        Me.saveBtn.Name = "saveBtn"
        Me.saveBtn.Size = New System.Drawing.Size(75, 23)
        Me.saveBtn.TabIndex = 1
        Me.saveBtn.Text = "Save"
        Me.saveBtn.UseVisualStyleBackColor = True
        '
        'closeBtn
        '
        Me.closeBtn.Location = New System.Drawing.Point(485, 406)
        Me.closeBtn.Name = "closeBtn"
        Me.closeBtn.Size = New System.Drawing.Size(75, 23)
        Me.closeBtn.TabIndex = 2
        Me.closeBtn.Text = "Close"
        Me.closeBtn.UseVisualStyleBackColor = True
        '
        'ChartForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(824, 444)
        Me.Controls.Add(Me.closeBtn)
        Me.Controls.Add(Me.saveBtn)
        Me.Controls.Add(Me.resultsChart)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "ChartForm"
        Me.Text = "Results Chart"
        CType(Me.resultsChart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents resultsChart As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents saveBtn As System.Windows.Forms.Button
    Friend WithEvents closeBtn As System.Windows.Forms.Button
    Friend WithEvents saveImageDialog As System.Windows.Forms.SaveFileDialog
End Class
