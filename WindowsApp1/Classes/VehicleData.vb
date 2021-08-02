Imports System.IO
Imports MySql.Data.MySqlClient

Public Class VehicleData
    Private Shared _obj As VehicleData
    Private Shared _vehicleList As List(Of ParkedVehicle)
    Private Shared _dictionary As Dictionary(Of String, List(Of Integer))
    Private Shared DBCon As MySqlConnection = DBConnection.GetConnection()

    Shared Sub New()
        _vehicleList = New List(Of ParkedVehicle)
        _dictionary = New Dictionary(Of String, List(Of Integer))

        Dim cmd = DBCon.CreateCommand()
        cmd.CommandText = "SELECT * FROM tblvehicle"

        Using reader = cmd.ExecuteReader
            While reader.Read()
                Dim tempList As New List(Of Integer)
                For i = reader.GetInt32(2) To reader.GetInt32(3)
                    tempList.Add(i)
                Next

                _dictionary.Add(reader.GetString(0), tempList)
            End While
        End Using

        cmd.CommandText = "SELECT ID, V_Type, V_Number, Arrival_Time, prk.NIC, Location, TP_Number FROM tblparking as prk INNER JOIN tblpersonal as prs ON prk.NIC = prs.NIC WHERE Depature_Time IS NULL"
        Using reader = cmd.ExecuteReader
            While reader.Read()
                Dim temp = New ParkedVehicle()
                temp.dbID = reader.GetInt32(0)
                temp.Type = reader.GetString(1)
                temp.Vnum = reader.GetString(2)
                temp.ArrTime = reader.GetDateTime(3)
                temp.ID = reader.GetString(4)
                temp.Location = reader.GetInt32(5)
                temp.TP = reader.GetString(6)
                _vehicleList.Add(temp)
            End While
        End Using

        For Each item In _vehicleList
            _dictionary.Item(item.Type).Remove(item.Location)
        Next

    End Sub

    Public Function RegisterVehicle(item As ParkedVehicle) As ParkedVehicle
        If _dictionary.Item(item.Type).Count > 0 Then
            item.Location = _dictionary.Item(item.Type).First()
            _dictionary.Item(item.Type).RemoveAt(0)
        Else
            item.Location = -1
            Return item
        End If

        Try
            Dim cmd = DBCon.CreateCommand()
            cmd.CommandText = "INSERT INTO tblparking (V_Type, V_Number, Arrival_Time, NIC, Location) VALUES (@type, @num, @arr, @nic, @loc); SELECT LAST_INSERT_ID();"
            cmd.Parameters.AddWithValue("@type", item.Type)
            cmd.Parameters.AddWithValue("@num", item.Vnum)
            cmd.Parameters.AddWithValue("@arr", item.ArrTime)
            cmd.Parameters.AddWithValue("@nic", item.ID)
            cmd.Parameters.AddWithValue("@loc", item.Location)

            Dim dbID As Integer = cmd.ExecuteScalar()

            If dbID > 0 Then
                item.dbID = dbID
            Else
                Return Nothing
            End If

        Catch ex As Exception
            Return Nothing
        End Try

        _vehicleList.Add(item)
        Return item
    End Function

    Public Function DepartuerVehicle(item As ParkedVehicle) As ParkedVehicle
        Try
            Dim time = DateTime.Now
            Dim cmd = DBCon.CreateCommand()

            cmd.CommandText = "UPDATE tblparking SET Depature_Time = @depTime WHERE ID = @id"
            cmd.Parameters.AddWithValue("@depTime", time)
            cmd.Parameters.AddWithValue("@id", item.dbID)

            Dim res = cmd.ExecuteNonQuery()

            If res > 0 Then
                Dim temp = _dictionary.Item(item.Type)
                temp.Add(item.Location)
                temp.Sort()

                _dictionary.Item(item.Type) = temp
                _vehicleList.Remove(item)

                item.DepTime = time

                Return item
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetParkedList() As List(Of ParkedVehicle)
        Return _vehicleList
    End Function

    Public Function GetRemainSlots() As Dictionary(Of String, List(Of Integer))
        Return _dictionary
    End Function

    Public Shared ReadOnly Property GetInstance() As VehicleData
        Get
            If _obj Is Nothing Then
                _obj = New VehicleData
            End If

            Return _obj
        End Get
    End Property
End Class
