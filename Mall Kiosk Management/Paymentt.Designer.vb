<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Paymentt
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
        Me.priceee = New System.Windows.Forms.LinkLabel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GridView1 = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GridView2 = New System.Windows.Forms.DataGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.UPI = New System.Windows.Forms.RadioButton()
        Me.COD = New System.Windows.Forms.RadioButton()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'priceee
        '
        Me.priceee.AutoSize = True
        Me.priceee.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.priceee.LinkColor = System.Drawing.Color.White
        Me.priceee.Location = New System.Drawing.Point(505, 476)
        Me.priceee.Name = "priceee"
        Me.priceee.Size = New System.Drawing.Size(0, 23)
        Me.priceee.TabIndex = 23
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label5.Location = New System.Drawing.Point(385, 475)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 24)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "Total Price"
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Button2.Location = New System.Drawing.Point(399, 582)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(85, 42)
        Me.Button2.TabIndex = 21
        Me.Button2.Text = "Cancle"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(261, 582)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(85, 42)
        Me.Button1.TabIndex = 20
        Me.Button1.Text = "Pay"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Comic Sans MS", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label1.Location = New System.Drawing.Point(318, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(124, 38)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Payment"
        '
        'GridView1
        '
        Me.GridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridView1.Location = New System.Drawing.Point(41, 133)
        Me.GridView1.Name = "GridView1"
        Me.GridView1.Size = New System.Drawing.Size(328, 324)
        Me.GridView1.TabIndex = 25
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label2.Location = New System.Drawing.Point(148, 85)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 24)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Items Bill"
        '
        'GridView2
        '
        Me.GridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridView2.Location = New System.Drawing.Point(427, 133)
        Me.GridView2.Name = "GridView2"
        Me.GridView2.Size = New System.Drawing.Size(193, 324)
        Me.GridView2.TabIndex = 27
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label3.Location = New System.Drawing.Point(462, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(102, 24)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "Parking Bill"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.UPI)
        Me.GroupBox1.Controls.Add(Me.COD)
        Me.GroupBox1.Location = New System.Drawing.Point(41, 475)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 100)
        Me.GroupBox1.TabIndex = 29
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        '
        'UPI
        '
        Me.UPI.AutoSize = True
        Me.UPI.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.UPI.Location = New System.Drawing.Point(7, 44)
        Me.UPI.Name = "UPI"
        Me.UPI.Size = New System.Drawing.Size(43, 17)
        Me.UPI.TabIndex = 1
        Me.UPI.TabStop = True
        Me.UPI.Text = "UPI"
        Me.UPI.UseVisualStyleBackColor = True
        '
        'COD
        '
        Me.COD.AutoSize = True
        Me.COD.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.COD.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.COD.Location = New System.Drawing.Point(7, 20)
        Me.COD.Name = "COD"
        Me.COD.Size = New System.Drawing.Size(48, 17)
        Me.COD.TabIndex = 0
        Me.COD.TabStop = True
        Me.COD.Text = "COD"
        Me.COD.UseVisualStyleBackColor = False
        '
        'Paymentt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ClientSize = New System.Drawing.Size(690, 647)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GridView2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GridView1)
        Me.Controls.Add(Me.priceee)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Paymentt"
        Me.Text = "Paymentt"
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents priceee As LinkLabel
    Friend WithEvents Label5 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents GridView1 As DataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents GridView2 As DataGridView
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents UPI As RadioButton
    Friend WithEvents COD As RadioButton
End Class
