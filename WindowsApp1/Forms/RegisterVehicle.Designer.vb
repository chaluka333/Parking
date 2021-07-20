<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRegisterVehicle
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtNIC = New System.Windows.Forms.TextBox()
        Me.txtTP = New System.Windows.Forms.TextBox()
        Me.txtVID = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btnEnter = New System.Windows.Forms.Button()
        Me.cmbVType = New System.Windows.Forms.ComboBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblTime = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(38, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Customer NIC :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(42, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Customer TP :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(41, 107)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Vehicle Type :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(43, 146)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Vehicle Num :"
        '
        'txtNIC
        '
        Me.txtNIC.Location = New System.Drawing.Point(134, 22)
        Me.txtNIC.Name = "txtNIC"
        Me.txtNIC.Size = New System.Drawing.Size(155, 20)
        Me.txtNIC.TabIndex = 6
        '
        'txtTP
        '
        Me.txtTP.Location = New System.Drawing.Point(134, 61)
        Me.txtTP.Name = "txtTP"
        Me.txtTP.Size = New System.Drawing.Size(155, 20)
        Me.txtTP.TabIndex = 7
        '
        'txtVID
        '
        Me.txtVID.Location = New System.Drawing.Point(134, 139)
        Me.txtVID.Name = "txtVID"
        Me.txtVID.Size = New System.Drawing.Size(155, 20)
        Me.txtVID.TabIndex = 9
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(192, 251)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(121, 45)
        Me.Button2.TabIndex = 12
        Me.Button2.Text = "Reset"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btnEnter
        '
        Me.btnEnter.Location = New System.Drawing.Point(41, 251)
        Me.btnEnter.Name = "btnEnter"
        Me.btnEnter.Size = New System.Drawing.Size(121, 45)
        Me.btnEnter.TabIndex = 13
        Me.btnEnter.Text = "Enter"
        Me.btnEnter.UseVisualStyleBackColor = True
        '
        'cmbVType
        '
        Me.cmbVType.FormattingEnabled = True
        Me.cmbVType.Items.AddRange(New Object() {"Car", "Van", "Bike", "ThreeWheel"})
        Me.cmbVType.Location = New System.Drawing.Point(134, 99)
        Me.cmbVType.Name = "cmbVType"
        Me.cmbVType.Size = New System.Drawing.Size(155, 21)
        Me.cmbVType.TabIndex = 15
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(352, 22)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(662, 274)
        Me.DataGridView1.TabIndex = 17
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(43, 184)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Current Time :"
        '
        'lblTime
        '
        Me.lblTime.AutoSize = True
        Me.lblTime.Location = New System.Drawing.Point(131, 184)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(62, 13)
        Me.lblTime.TabIndex = 19
        Me.lblTime.Text = "Vehicle ID :"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'frmRegisterVehicle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1044, 322)
        Me.Controls.Add(Me.lblTime)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.cmbVType)
        Me.Controls.Add(Me.btnEnter)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.txtVID)
        Me.Controls.Add(Me.txtTP)
        Me.Controls.Add(Me.txtNIC)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Name = "frmRegisterVehicle"
        Me.Text = "Register Vehicle"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtNIC As TextBox
    Friend WithEvents txtTP As TextBox
    Friend WithEvents txtVID As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents btnEnter As Button
    Friend WithEvents cmbVType As ComboBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents lblTime As Label
    Friend WithEvents Timer1 As Timer
End Class
