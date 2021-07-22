Imports MySql.Data.MySqlClient
Friend Class DBConnection
    Private Shared _obj As DBConnection
    Private Shared Connection As MySqlConnection
    Private Shared ReadOnly connString As String = "server=localhost; user=root; password=; database=parking;"

    Shared Sub New()
        Connection = New MySqlConnection(connString)
        Try
            Connection.Open()
            Debug.WriteLine("Connection opened")
        Catch ex As Exception
            MessageBox.Show("Couldn't open the connection. Please re-run the program. test1", "Database connection error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()
        End Try
    End Sub

    Protected Overloads Shared Sub Finalize()
        Connection.Close()
        Debug.WriteLine("Connection closed")
    End Sub

    Public Shared ReadOnly Property GetConnection() As MySqlConnection
        Get
            If _obj Is Nothing Then
                _obj = New DBConnection
            End If

            Return _obj.Connection
        End Get
    End Property
End Class
