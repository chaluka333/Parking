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
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnDeparture = New System.Windows.Forms.Button()
        Me.lblArr = New System.Windows.Forms.Label()
        Me.lblLocation = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblNIC = New System.Windows.Forms.Label()
        Me.lblTP = New System.Windows.Forms.Label()
        Me.lblType = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtDepVehicle = New System.Windows.Forms.TextBox()
        Me.txtTP = New System.Windows.Forms.TextBox()
        Me.txtVID = New System.Windows.Forms.TextBox()
        Me.txtNIC = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnEnter = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbVType = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.lblTime = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnDeparture)
        Me.GroupBox2.Controls.Add(Me.lblArr)
        Me.GroupBox2.Controls.Add(Me.lblLocation)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.lblNIC)
        Me.GroupBox2.Controls.Add(Me.lblTP)
        Me.GroupBox2.Controls.Add(Me.lblType)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.txtDepVehicle)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 325)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(356, 351)
        Me.GroupBox2.TabIndex = 21
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Departure"
        '
        'btnDeparture
        '
        Me.btnDeparture.Location = New System.Drawing.Point(177, 259)
        Me.btnDeparture.Name = "btnDeparture"
        Me.btnDeparture.Size = New System.Drawing.Size(129, 45)
        Me.btnDeparture.TabIndex = 20
        Me.btnDeparture.Text = "Depature"
        Me.btnDeparture.UseVisualStyleBackColor = True
        '
        'lblArr
        '
        Me.lblArr.AutoSize = True
        Me.lblArr.Location = New System.Drawing.Point(116, 222)
        Me.lblArr.Name = "lblArr"
        Me.lblArr.Size = New System.Drawing.Size(75, 13)
        Me.lblArr.TabIndex = 29
        Me.lblArr.Text = "Vehicle Type :"
        '
        'lblLocation
        '
        Me.lblLocation.AutoSize = True
        Me.lblLocation.Location = New System.Drawing.Point(116, 185)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(75, 13)
        Me.lblLocation.TabIndex = 28
        Me.lblLocation.Text = "Vehicle Type :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(23, 185)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(54, 13)
        Me.Label10.TabIndex = 26
        Me.Label10.Text = "Location :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(23, 222)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(71, 13)
        Me.Label11.TabIndex = 27
        Me.Label11.Text = "Arrival Time : "
        '
        'lblNIC
        '
        Me.lblNIC.AutoSize = True
        Me.lblNIC.Location = New System.Drawing.Point(116, 74)
        Me.lblNIC.Name = "lblNIC"
        Me.lblNIC.Size = New System.Drawing.Size(78, 13)
        Me.lblNIC.TabIndex = 23
        Me.lblNIC.Text = "Customer NIC :"
        '
        'lblTP
        '
        Me.lblTP.AutoSize = True
        Me.lblTP.Location = New System.Drawing.Point(116, 111)
        Me.lblTP.Name = "lblTP"
        Me.lblTP.Size = New System.Drawing.Size(74, 13)
        Me.lblTP.TabIndex = 24
        Me.lblTP.Text = "Customer TP :"
        '
        'lblType
        '
        Me.lblType.AutoSize = True
        Me.lblType.Location = New System.Drawing.Point(116, 148)
        Me.lblType.Name = "lblType"
        Me.lblType.Size = New System.Drawing.Size(75, 13)
        Me.lblType.TabIndex = 25
        Me.lblType.Text = "Vehicle Type :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(23, 74)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(78, 13)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Customer NIC :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(23, 111)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(74, 13)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "Customer TP :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(23, 37)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 13)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Vehicle Num :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(23, 148)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(75, 13)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "Vehicle Type :"
        '
        'txtDepVehicle
        '
        Me.txtDepVehicle.Location = New System.Drawing.Point(119, 30)
        Me.txtDepVehicle.Name = "txtDepVehicle"
        Me.txtDepVehicle.Size = New System.Drawing.Size(187, 20)
        Me.txtDepVehicle.TabIndex = 21
        '
        'txtTP
        '
        Me.txtTP.Location = New System.Drawing.Point(119, 68)
        Me.txtTP.Name = "txtTP"
        Me.txtTP.Size = New System.Drawing.Size(187, 20)
        Me.txtTP.TabIndex = 7
        '
        'txtVID
        '
        Me.txtVID.Location = New System.Drawing.Point(119, 144)
        Me.txtVID.Name = "txtVID"
        Me.txtVID.Size = New System.Drawing.Size(187, 20)
        Me.txtVID.TabIndex = 9
        '
        'txtNIC
        '
        Me.txtNIC.Location = New System.Drawing.Point(119, 30)
        Me.txtNIC.Name = "txtNIC"
        Me.txtNIC.Size = New System.Drawing.Size(187, 20)
        Me.txtNIC.TabIndex = 6
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(177, 233)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(129, 45)
        Me.Button2.TabIndex = 12
        Me.Button2.Text = "Reset"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(28, 151)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Vehicle Num :"
        '
        'btnEnter
        '
        Me.btnEnter.Location = New System.Drawing.Point(26, 233)
        Me.btnEnter.Name = "btnEnter"
        Me.btnEnter.Size = New System.Drawing.Size(129, 45)
        Me.btnEnter.TabIndex = 13
        Me.btnEnter.Text = "Enter"
        Me.btnEnter.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(28, 113)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Vehicle Type :"
        '
        'cmbVType
        '
        Me.cmbVType.FormattingEnabled = True
        Me.cmbVType.Location = New System.Drawing.Point(119, 105)
        Me.cmbVType.Name = "cmbVType"
        Me.cmbVType.Size = New System.Drawing.Size(187, 21)
        Me.cmbVType.TabIndex = 15
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(28, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Customer TP :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(28, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Customer NIC :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(28, 189)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Current Time :"
        '
        'dgv1
        '
        Me.dgv1.AllowUserToAddRows = False
        Me.dgv1.AllowUserToDeleteRows = False
        Me.dgv1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgv1.Location = New System.Drawing.Point(374, 12)
        Me.dgv1.MultiSelect = False
        Me.dgv1.Name = "dgv1"
        Me.dgv1.ReadOnly = True
        Me.dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv1.Size = New System.Drawing.Size(807, 664)
        Me.dgv1.TabIndex = 17
        '
        'lblTime
        '
        Me.lblTime.AutoSize = True
        Me.lblTime.Location = New System.Drawing.Point(116, 189)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(62, 13)
        Me.lblTime.TabIndex = 19
        Me.lblTime.Text = "Vehicle ID :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblTime)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cmbVType)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.btnEnter)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.txtNIC)
        Me.GroupBox1.Controls.Add(Me.txtVID)
        Me.GroupBox1.Controls.Add(Me.txtTP)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(356, 307)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Arrival"
        '
        'frmRegisterVehicle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1193, 688)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.dgv1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmRegisterVehicle"
        Me.Text = "Register Vehicle"
        Me.TopMost = True
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Timer1 As Timer
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents lblNIC As Label
    Friend WithEvents lblTP As Label
    Friend WithEvents lblType As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents txtDepVehicle As TextBox
    Friend WithEvents txtTP As TextBox
    Friend WithEvents txtVID As TextBox
    Friend WithEvents txtNIC As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents btnEnter As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbVType As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dgv1 As DataGridView
    Friend WithEvents lblTime As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblArr As Label
    Friend WithEvents lblLocation As Label
    Friend WithEvents btnDeparture As Button
End Class
