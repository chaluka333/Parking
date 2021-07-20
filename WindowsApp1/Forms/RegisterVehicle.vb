Imports System.Text.RegularExpressions
Imports MySql.Data.MySqlClient

Public Class frmRegisterVehicle
    Dim DBCon As MySqlConnection = DBConnection.GetConnection()
    Dim metaData As VehicleData = VehicleData.GetInstance()
    Dim personCol As List(Of Person) = New List(Of Person)
    Dim vehicleCol As List(Of Vehicle) = New List(Of Vehicle)
    Dim isFromPerson As Boolean = False
    Dim vhList As New List(Of ParkedVehicle)

    Private Sub GetPersonalDetails()
        personCol.Clear()

        Dim cmd = DBCon.CreateCommand
        Dim autoCol As New AutoCompleteStringCollection

        cmd.CommandText = "SELECT * FROM tblpersonal"
        Using reader = cmd.ExecuteReader
            While reader.Read
                Dim temp = New Person
                temp.NIC = reader.GetString(0)
                temp.TP = reader.GetString(1)
                personCol.Add(temp)

                autoCol.Add(reader.GetString(0))
            End While
        End Using

        txtNIC.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtNIC.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtNIC.AutoCompleteCustomSource = autoCol
    End Sub

    Private Sub GetVehicleTypes()
        If vehicleCol.Any Then
            vehicleCol.Clear()
        End If
        cmbVType.Items.Clear()

        Dim cmd = DBCon.CreateCommand
        cmd.CommandText = "SELECT * FROM tblvehicle"
        Using reader = cmd.ExecuteReader
            While reader.Read
                Dim temp = New Vehicle
                temp.Type = reader.GetString(0)
                temp.Charge = reader.GetDecimal(1)
                temp.vMin = reader.GetInt32(2)
                temp.vMax = reader.GetInt32(3)

                vehicleCol.Add(temp)
                cmbVType.Items.Add(temp.Type)
            End While
        End Using
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetPersonalDetails()
        GetVehicleTypes()
        lblTime.Text = ""

        If cmbVType.Items.Count > 0 Then
            cmbVType.SelectedIndex = 0
        End If
    End Sub

    Private Sub txtNIC_TextChanged(sender As Object, e As EventArgs) Handles txtNIC.TextChanged
        For Each item As Person In personCol
            txtTP.Text = ""
            isFromPerson = False
            If txtNIC.Text = item.NIC Then
                txtTP.Text = item.TP
                isFromPerson = True
                Exit For
            End If
        Next
    End Sub

    Private Sub btnEnter_Click(sender As Object, e As EventArgs) Handles btnEnter.Click
        Dim nic As Boolean = String.IsNullOrEmpty(txtNIC.Text)
        Dim tp As Boolean = String.IsNullOrEmpty(txtTP.Text)
        Dim type As Boolean = String.IsNullOrEmpty(cmbVType.Text)
        Dim id As Boolean = String.IsNullOrEmpty(txtVID.Text)

        If nic Or tp Or type Or id Then
            MessageBox.Show("Please dill all the fields to proceed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Try
            Dim temp As New ParkedVehicle
            temp.ID = txtNIC.Text
            temp.TP = txtTP.Text
            temp.Type = cmbVType.Text
            temp.Vnum = txtVID.Text
            temp.ArrTime = DateTime.Now

            Dim response = metaData.RegisterVehicle(temp)

            If response Is Nothing Then
                MessageBox.Show("Error occured during the process. Please insert the data again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf response.Location = -1 Then
                MessageBox.Show("There is no room available for this type of vehicle", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("Vehicle registered", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Error occured during the process. Please insert the data again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtTP_TextChanged(sender As Object, e As EventArgs) Handles txtTP.TextChanged
        If Not Regex.Match(txtTP.Text, "^[0-9]*$").Success Then
            txtTP.Text = ""
            MessageBox.Show("Inalid contact number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblTime.Text = DateTime.Now.ToString("yyyy/MMM/dd | HH:mm:ss")
    End Sub
End Class
