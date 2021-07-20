<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVehicleCategory
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
        Me.txtType = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.numFrom = New System.Windows.Forms.NumericUpDown()
        Me.numTo = New System.Windows.Forms.NumericUpDown()
        Me.numCharge = New System.Windows.Forms.NumericUpDown()
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        CType(Me.numFrom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numTo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numCharge, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtType
        '
        Me.txtType.Location = New System.Drawing.Point(159, 36)
        Me.txtType.Name = "txtType"
        Me.txtType.Size = New System.Drawing.Size(100, 20)
        Me.txtType.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(102, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Type :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(47, 93)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Charge Per Hour :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(46, 147)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Parking Location :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(265, 143)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(10, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "-"
        '
        'numFrom
        '
        Me.numFrom.Location = New System.Drawing.Point(159, 140)
        Me.numFrom.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.numFrom.Name = "numFrom"
        Me.numFrom.Size = New System.Drawing.Size(100, 20)
        Me.numFrom.TabIndex = 8
        '
        'numTo
        '
        Me.numTo.Location = New System.Drawing.Point(281, 140)
        Me.numTo.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.numTo.Name = "numTo"
        Me.numTo.Size = New System.Drawing.Size(100, 20)
        Me.numTo.TabIndex = 9
        '
        'numCharge
        '
        Me.numCharge.Location = New System.Drawing.Point(159, 86)
        Me.numCharge.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.numCharge.Name = "numCharge"
        Me.numCharge.Size = New System.Drawing.Size(100, 20)
        Me.numCharge.TabIndex = 10
        '
        'dgv1
        '
        Me.dgv1.AllowUserToAddRows = False
        Me.dgv1.AllowUserToDeleteRows = False
        Me.dgv1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv1.Location = New System.Drawing.Point(417, 36)
        Me.dgv1.Name = "dgv1"
        Me.dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv1.Size = New System.Drawing.Size(474, 338)
        Me.dgv1.TabIndex = 11
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(49, 213)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(101, 33)
        Me.btnAdd.TabIndex = 12
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(174, 213)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(101, 33)
        Me.btnUpdate.TabIndex = 13
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(295, 213)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(101, 33)
        Me.Button3.TabIndex = 14
        Me.Button3.Text = "Clear"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'frmVehicleCategory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(927, 404)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.dgv1)
        Me.Controls.Add(Me.numCharge)
        Me.Controls.Add(Me.numTo)
        Me.Controls.Add(Me.numFrom)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtType)
        Me.Name = "frmVehicleCategory"
        Me.Text = "Vehicle Category"
        CType(Me.numFrom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numTo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numCharge, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtType As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents numFrom As NumericUpDown
    Friend WithEvents numTo As NumericUpDown
    Friend WithEvents numCharge As NumericUpDown
    Friend WithEvents dgv1 As DataGridView
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents Button3 As Button
End Class
