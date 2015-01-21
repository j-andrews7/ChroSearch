Imports System.Drawing
Imports System.Windows.Forms.DataVisualization.Charting

Public Class ChartForm

    Private Sub Chart_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        resultsChart.ChartAreas("resultsChart").AxisX.Interval = 1
        resultsChart.ChartAreas("resultsChart").AxisX.IsLabelAutoFit = True
        resultsChart.ChartAreas("resultsChart").AxisX.LabelAutoFitStyle = DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont
        resultsChart.ChartAreas("resultsChart").AxisX.LabelStyle.Angle = -90
        resultsChart.ChartAreas("resultsChart").AxisX.MinorTickMark.Enabled = False
        resultsChart.Legends.RemoveAt(0)
    End Sub

    'Creates form and the subsequent chart.
    Public Sub New(ByVal dataPoints As List(Of Double), ByVal labels As List(Of String), ByVal chartType As Integer, _
                   ByVal chartXTitle As String, ByVal chartYTitle As String)

        InitializeComponent()


        resultsChart.ChartAreas("resultsChart").AxisX.Title = chartXTitle
        resultsChart.ChartAreas("resultsChart").AxisY.Title = chartYTitle


        If chartType = 0 Then
            resultsChart.Series(0).ChartType = SeriesChartType.Column
        Else
            resultsChart.Series(0).ChartType = SeriesChartType.Point
        End If

        For i As Integer = 0 To dataPoints.Count - 1
            resultsChart.Series(0).Points.Add(dataPoints(i))
            resultsChart.Series(0).Points(i).AxisLabel = labels(i)
        Next

    End Sub

    'Closes form when close button is clicked.
    Private Sub closeBtn_Click(sender As Object, e As EventArgs) Handles closeBtn.Click
        Me.Close()
    End Sub

    'Saves chart to file
    Public Sub ControlBmpToFile(control As Control, file As String)
        Dim bmp As New Bitmap(control.Width, control.Height)
        control.DrawToBitmap(bmp, control.DisplayRectangle)

        bmp.Save(file, System.Drawing.Imaging.ImageFormat.Tiff)
    End Sub

    'Lets user choose where to save image and name, etc when save button is clicked.
    Private Sub saveBtn_Click(sender As Object, e As EventArgs) Handles saveBtn.Click
        Dim saveImageDialog As New SaveFileDialog
        Dim filePath As String
        saveImageDialog.Title = "Save As..."
        saveImageDialog.Filter = "Image Files(*.tiff;*.jpg;*.png)|*.tiff;*.jpg;*.png"
        Dim result = saveImageDialog.ShowDialog()

        If result = Windows.Forms.DialogResult.OK Then
            filePath = saveImageDialog.FileName
            ControlBmpToFile(resultsChart, filePath)
        End If
    End Sub
End Class