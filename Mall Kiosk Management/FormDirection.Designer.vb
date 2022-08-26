<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDirection
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btniStore = New System.Windows.Forms.Button()
        Me.btnSpar = New System.Windows.Forms.Button()
        Me.btnLevis = New System.Windows.Forms.Button()
        Me.btnPuma = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btniStore)
        Me.Panel1.Controls.Add(Me.btnSpar)
        Me.Panel1.Controls.Add(Me.btnLevis)
        Me.Panel1.Controls.Add(Me.btnPuma)
        Me.Panel1.Location = New System.Drawing.Point(14, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(140, 426)
        Me.Panel1.TabIndex = 0
        '
        'btniStore
        '
        Me.btniStore.Location = New System.Drawing.Point(3, 99)
        Me.btniStore.Name = "btniStore"
        Me.btniStore.Size = New System.Drawing.Size(134, 23)
        Me.btniStore.TabIndex = 3
        Me.btniStore.Text = "I Store"
        Me.btniStore.UseVisualStyleBackColor = True
        '
        'btnSpar
        '
        Me.btnSpar.Location = New System.Drawing.Point(3, 70)
        Me.btnSpar.Name = "btnSpar"
        Me.btnSpar.Size = New System.Drawing.Size(134, 23)
        Me.btnSpar.TabIndex = 2
        Me.btnSpar.Text = "Spar"
        Me.btnSpar.UseVisualStyleBackColor = True
        '
        'btnLevis
        '
        Me.btnLevis.Location = New System.Drawing.Point(3, 41)
        Me.btnLevis.Name = "btnLevis"
        Me.btnLevis.Size = New System.Drawing.Size(134, 23)
        Me.btnLevis.TabIndex = 1
        Me.btnLevis.Text = "Levis"
        Me.btnLevis.UseVisualStyleBackColor = True
        '
        'btnPuma
        '
        Me.btnPuma.Location = New System.Drawing.Point(3, 12)
        Me.btnPuma.Name = "btnPuma"
        Me.btnPuma.Size = New System.Drawing.Size(134, 23)
        Me.btnPuma.TabIndex = 0
        Me.btnPuma.Text = "Puma"
        Me.btnPuma.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Location = New System.Drawing.Point(162, 13)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(627, 280)
        Me.Panel2.TabIndex = 1
        '
        'RichTextBox1
        '
        Me.RichTextBox1.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.RichTextBox1.Font = New System.Drawing.Font("Stencil", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RichTextBox1.ForeColor = System.Drawing.SystemColors.Window
        Me.RichTextBox1.Location = New System.Drawing.Point(162, 300)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(627, 138)
        Me.RichTextBox1.TabIndex = 2
        Me.RichTextBox1.Text = ""
        '
        'FormDirection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FormDirection"
        Me.Text = "FormDirection"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents btniStore As Button
    Friend WithEvents btnSpar As Button
    Friend WithEvents btnLevis As Button
    Friend WithEvents btnPuma As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents RichTextBox1 As RichTextBox
End Class
