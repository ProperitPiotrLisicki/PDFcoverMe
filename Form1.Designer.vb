<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.btnSelectSources = New System.Windows.Forms.Button()
        Me.btnSelectAppends = New System.Windows.Forms.Button()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.lstSources = New System.Windows.Forms.ListBox()
        Me.lstAppend = New System.Windows.Forms.ListBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.btnRemoveSelected = New System.Windows.Forms.Button()
        Me.btnClearAll = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'btnSelectSources
        '
        Me.btnSelectSources.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSelectSources.Location = New System.Drawing.Point(37, 30)
        Me.btnSelectSources.Name = "btnSelectSources"
        Me.btnSelectSources.Size = New System.Drawing.Size(75, 23)
        Me.btnSelectSources.TabIndex = 0
        Me.btnSelectSources.Text = "Source Files"
        Me.btnSelectSources.UseVisualStyleBackColor = True
        '
        'btnSelectAppends
        '
        Me.btnSelectAppends.BackColor = System.Drawing.SystemColors.Window
        Me.btnSelectAppends.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSelectAppends.Location = New System.Drawing.Point(383, 30)
        Me.btnSelectAppends.Name = "btnSelectAppends"
        Me.btnSelectAppends.Size = New System.Drawing.Size(75, 23)
        Me.btnSelectAppends.TabIndex = 1
        Me.btnSelectAppends.Text = "Appendixes"
        Me.btnSelectAppends.UseVisualStyleBackColor = False
        '
        'btnStart
        '
        Me.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStart.Location = New System.Drawing.Point(383, 295)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(288, 52)
        Me.btnStart.TabIndex = 2
        Me.btnStart.Text = "Merge"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'lstSources
        '
        Me.lstSources.AllowDrop = True
        Me.lstSources.FormattingEnabled = True
        Me.lstSources.Location = New System.Drawing.Point(37, 59)
        Me.lstSources.Name = "lstSources"
        Me.lstSources.Size = New System.Drawing.Size(288, 342)
        Me.lstSources.TabIndex = 3
        '
        'lstAppend
        '
        Me.lstAppend.FormattingEnabled = True
        Me.lstAppend.Location = New System.Drawing.Point(383, 59)
        Me.lstAppend.Name = "lstAppend"
        Me.lstAppend.Size = New System.Drawing.Size(288, 186)
        Me.lstAppend.TabIndex = 4
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 428)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(691, 22)
        Me.StatusStrip1.TabIndex = 5
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(37, 428)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(195, 22)
        Me.ProgressBar1.Step = 1
        Me.ProgressBar1.TabIndex = 6
        '
        'btnRemoveSelected
        '
        Me.btnRemoveSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRemoveSelected.Location = New System.Drawing.Point(241, 30)
        Me.btnRemoveSelected.Name = "btnRemoveSelected"
        Me.btnRemoveSelected.Size = New System.Drawing.Size(75, 23)
        Me.btnRemoveSelected.TabIndex = 7
        Me.btnRemoveSelected.Text = "Remove"
        Me.btnRemoveSelected.UseVisualStyleBackColor = True
        '
        'btnClearAll
        '
        Me.btnClearAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClearAll.Location = New System.Drawing.Point(383, 378)
        Me.btnClearAll.Name = "btnClearAll"
        Me.btnClearAll.Size = New System.Drawing.Size(288, 23)
        Me.btnClearAll.TabIndex = 8
        Me.btnClearAll.Text = "Remove All"
        Me.btnClearAll.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(691, 450)
        Me.Controls.Add(Me.btnClearAll)
        Me.Controls.Add(Me.btnRemoveSelected)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.lstAppend)
        Me.Controls.Add(Me.lstSources)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.btnSelectAppends)
        Me.Controls.Add(Me.btnSelectSources)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "Form1"
        Me.Text = "PDF CoverMe"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents btnSelectSources As Button
    Friend WithEvents btnSelectAppends As Button
    Friend WithEvents btnStart As Button
    Friend WithEvents lstSources As ListBox
    Friend WithEvents lstAppend As ListBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents btnRemoveSelected As Button
    Friend WithEvents btnClearAll As Button
End Class
