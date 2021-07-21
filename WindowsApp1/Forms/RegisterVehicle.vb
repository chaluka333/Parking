﻿Imports System.Text.RegularExpressions
Imports MySql.Data.MySqlClient

Public Class frmRegisterVehicle
    Dim DBCon As MySqlConnection = DBConnection.GetConnection()
    Dim metaData As VehicleData = VehicleData.GetInstance()
    Dim personCol As List(Of Person) = New List(Of Person)
    Dim vehicleCol As List(Of Vehicle) = New List(Of Vehicle)
    Dim isFromPerson As Boolean = False
    Dim vhList As New List(Of ParkedVehicle)
    Dim dt As New DataTable
    Dim isFromVHList As Boolean = False
    Dim depItem As ParkedVehicle

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetPersonalDetails()
        GetVehicleTypes()
        RefreshCMB()

        lblTime.Text = ""
        lblArr.Text = ""
        lblLocation.Text = ""
        lblNIC.Text = ""
        lblTP.Text = ""
        lblType.Text = ""
        cmbVType.DropDownStyle = ComboBoxStyle.DropDownList

        If cmbVType.Items.Count > 0 Then
            cmbVType.SelectedIndex = 0
        End If

        dt.Columns.Add("ID", GetType(Integer))
        dt.Columns.Add("V. Num", GetType(String))
        dt.Columns.Add("Type", GetType(String))
        dt.Columns.Add("Location", GetType(Integer))
        dt.Columns.Add("NIC", GetType(String))
        dt.Columns.Add("TP", GetType(String))
        dt.Columns.Add("Arr. Time", GetType(String))
    End Sub

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

    Private Sub RefreshCMB()
        Dim cmd = DBCon.CreateCommand()
        cmd.CommandText = "SELECT V_Type FROM tblvehicle"
        cmbVType.Items.Clear()

        Using reader = cmd.ExecuteReader
            While reader.Read()
                cmbVType.Items.Add(reader.GetString(0))
            End While
        End Using
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
            MessageBox.Show("Please fill all the fields to proceed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                RefreshDGV()
                MessageBox.Show("Vehicle registered" + Environment.NewLine + "Parking spot : " + response.Location.ToString(), "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

    Private Sub RefreshDGV()
        Dim vhList = metaData.GetParkedList()
        Dim autoCol As New AutoCompleteStringCollection
        dt.Rows.Clear()

        For Each item In vhList
            dt.Rows.Add(item.dbID, item.Vnum, item.Type, item.Location, item.ID, item.TP, item.ArrTime.ToString("dd/MMM | HH:mm"))
            autoCol.Add(item.Vnum)
        Next

        txtDepVehicle.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtDepVehicle.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtDepVehicle.AutoCompleteCustomSource = autoCol

        dgv1.DataSource = dt
        dgv1.Refresh()
    End Sub

    Private Sub txtDepVehicle_TextChanged(sender As Object, e As EventArgs) Handles txtDepVehicle.TextChanged
        Dim vhList = metaData.GetParkedList()

        For Each item In vhList
            If String.Equals(item.Vnum, txtDepVehicle.Text) Then
                lblArr.Text = item.ArrTime
                lblLocation.Text = item.Location
                lblNIC.Text = item.ID
                lblTP.Text = item.TP
                lblType.Text = item.Type
                isFromVHList = True
                btnDeparture.Enabled = True
                depItem = item
                Exit Sub
            Else
                ClearDep()
            End If
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnDeparture.Click
        If isFromVHList AndAlso depItem IsNot Nothing Then
            Dim response = metaData.DepartuerVehicle(depItem)
            If response Is Nothing Then
                MessageBox.Show("Vehicle departuring faild. Please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                RefreshDGV()
                ClearDep()
                txtDepVehicle.Text = ""
                MessageBox.Show("Vehicle departure complete", "Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub ClearDep()
        lblArr.Text = ""
        lblLocation.Text = ""
        lblNIC.Text = ""
        lblTP.Text = ""
        lblType.Text = ""
        isFromVHList = False
        btnDeparture.Enabled = False
        depItem = Nothing
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        txtNIC.Text = ""
        txtTP.Text = ""
        txtVID.Text = ""
    End Sub
End Class
