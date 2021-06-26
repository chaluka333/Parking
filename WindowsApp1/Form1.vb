Imports MySql.Data.MySqlClient

Public Class Form1
    Dim DBCon As MySqlConnection = DBConnection.GetConnection()
    Dim personCol As List(Of Person) = New List(Of Person)
    Dim vehicleCol As List(Of Vehicle) = New List(Of Vehicle)
    Dim isFromPerson As Boolean = False

    Private Sub GetPersonalDetails()
        personCol.Clear()

        Dim cmd = DBCon.CreateCommand
        Dim autoCol As New AutoCompleteStringCollection

        cmd.CommandText = "SELECT * FROM tblpersonal"
        Dim reader = cmd.ExecuteReader
        While reader.Read
            Dim temp = New Person
            temp.NIC = reader.GetString(0)
            temp.TP = reader.GetString(1)
            personCol.Add(temp)

            autoCol.Add(reader.GetString(0))
        End While
        reader.Close()

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
        Dim reader = cmd.ExecuteReader

        While reader.Read
            Dim temp = New Vehicle
            temp.Type = reader.GetString(0)
            temp.Charge = reader.GetDecimal(1)
            temp.vMin = reader.GetInt32(2)
            temp.vMax = reader.GetInt32(3)

            vehicleCol.Add(temp)
            cmbVType.Items.Add(temp.Type)
        End While
        reader.Close()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetPersonalDetails()
        GetVehicleTypes()

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
End Class
