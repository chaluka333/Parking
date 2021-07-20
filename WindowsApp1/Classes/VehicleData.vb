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
            cmd.CommandText = "INSERT INTO tblparking (V_Type, V_Number, Arrival_Time) VALUES (@type, @num, @arr); SELECT LAST_INSERT_ID();"
            cmd.Parameters.AddWithValue("@type", item.Type)
            cmd.Parameters.AddWithValue("@num", item.Vnum)
            cmd.Parameters.AddWithValue("@arr", item.ArrTime)

            Dim dbID As Integer = cmd.ExecuteScalar()

            If dbID > 0 Then
                item.dbID = dbID
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try


        Return item
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
