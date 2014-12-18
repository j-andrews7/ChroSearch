<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HelpForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HelpForm))
        Me.instrLabel = New System.Windows.Forms.Label()
        Me.troLabel = New System.Windows.Forms.Label()
        Me.instrTxtB = New System.Windows.Forms.RichTextBox()
        Me.troubleTxtB = New System.Windows.Forms.RichTextBox()
        Me.closeBtn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'instrLabel
        '
        Me.instrLabel.AutoSize = True
        Me.instrLabel.Location = New System.Drawing.Point(12, 23)
        Me.instrLabel.Name = "instrLabel"
        Me.instrLabel.Size = New System.Drawing.Size(90, 13)
        Me.instrLabel.TabIndex = 0
        Me.instrLabel.Text = "Basic Instructions"
        '
        'troLabel
        '
        Me.troLabel.AutoSize = True
        Me.troLabel.Location = New System.Drawing.Point(400, 23)
        Me.troLabel.Name = "troLabel"
        Me.troLabel.Size = New System.Drawing.Size(83, 13)
        Me.troLabel.TabIndex = 1
        Me.troLabel.Text = "Troubleshooting"
        '
        'instrTxtB
        '
        Me.instrTxtB.BackColor = System.Drawing.Color.White
        Me.instrTxtB.Location = New System.Drawing.Point(15, 39)
        Me.instrTxtB.Name = "instrTxtB"
        Me.instrTxtB.ReadOnly = True
        Me.instrTxtB.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.instrTxtB.Size = New System.Drawing.Size(367, 364)
        Me.instrTxtB.TabIndex = 2
        Me.instrTxtB.Text = ""
        '
        'troubleTxtB
        '
        Me.troubleTxtB.BackColor = System.Drawing.Color.White
        Me.troubleTxtB.Location = New System.Drawing.Point(403, 39)
        Me.troubleTxtB.Name = "troubleTxtB"
        Me.troubleTxtB.ReadOnly = True
        Me.troubleTxtB.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.troubleTxtB.Size = New System.Drawing.Size(367, 364)
        Me.troubleTxtB.TabIndex = 3
        Me.troubleTxtB.Text = ""
        '
        'closeBtn
        '
        Me.closeBtn.Location = New System.Drawing.Point(353, 418)
        Me.closeBtn.Name = "closeBtn"
        Me.closeBtn.Size = New System.Drawing.Size(75, 23)
        Me.closeBtn.TabIndex = 4
        Me.closeBtn.Text = "Close"
        Me.closeBtn.UseVisualStyleBackColor = True
        '
        'HelpForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(783, 453)
        Me.Controls.Add(Me.closeBtn)
        Me.Controls.Add(Me.troubleTxtB)
        Me.Controls.Add(Me.instrTxtB)
        Me.Controls.Add(Me.troLabel)
        Me.Controls.Add(Me.instrLabel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "HelpForm"
        Me.Text = "Help"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents instrLabel As System.Windows.Forms.Label
    Friend WithEvents troLabel As System.Windows.Forms.Label
    Friend WithEvents instrTxtB As System.Windows.Forms.RichTextBox
    Friend WithEvents troubleTxtB As System.Windows.Forms.RichTextBox
    Friend WithEvents closeBtn As System.Windows.Forms.Button
End Class
