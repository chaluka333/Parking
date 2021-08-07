Imports MySql.Data.MySqlClient

Public Class Details
    Private between = False
    Private dt As DataTable = New DataTable()
    Dim DBCon As MySqlConnection = DBConnection.GetConnection()
    Private Sub chkBetween_CheckedChanged(sender As Object, e As EventArgs) Handles chkBetween.CheckedChanged
        If chkBetween.Checked Then
            dtpTo.Enabled = True
            between = True
        Else
            dtpTo.Enabled = False
            between = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim cmd = DBCon.CreateCommand

        If between AndAlso dtpTo.Value <= dtpFrom.Value Then
            MessageBox.Show("To value must be higher than From value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        dt.Rows.Clear()
        Dim dateFrom = Convert.ToDateTime(dtpFrom.Value.Date + " " + "00:00:00")
        Dim dateTo = Convert.ToDateTime(dtpTo.Value.Date + " " + "00:00:00")
        Dim i = 1

        If between Then
            cmd.CommandText = "SELECT tblpersonal.NIC, TP_number, V_Type, V_Number, Arrival_Time, Depature_Time, Location FROM tblparking INNER JOIN tblpersonal ON tblparking.NIC = tblpersonal.NIC WHERE Arrival_Time > @arrTimeStart AND Arrival_Time < @arrTimeEnd AND Depature_Time IS NOT NULL"
            cmd.Parameters.AddWithValue("@arrTimeStart", dtpFrom.Value.ToString("yyyy-MM-dd"))
            cmd.Parameters.AddWithValue("@arrTimeEnd", dtpTo.Value.AddDays(1).ToString("yyyy-MM-dd"))
        Else
            cmd.CommandText = "SELECT tblpersonal.NIC, TP_number, V_Type, V_Number, Arrival_Time, Depature_Time, Location FROM tblparking INNER JOIN tblpersonal ON tblparking.NIC = tblpersonal.NIC WHERE Arrival_Time > @arrTimeStart AND Arrival_Time < @arrTimeEnd AND Depature_Time IS NOT NULL"
            cmd.Parameters.AddWithValue("@arrTimeStart", dtpFrom.Value.ToString("yyyy-MM-dd"))
            cmd.Parameters.AddWithValue("@arrTimeEnd", dtpFrom.Value.AddDays(1).ToString("yyyy-MM-dd"))
        End If

        Using reader = cmd.ExecuteReader
            While reader.Read
                dt.Rows.Add(i, reader.GetString(2), reader.GetString(3), reader.GetString(0), reader.GetString(1), reader.GetString(6), reader.GetDateTime(4).ToString("yy - MMM - dd"), reader.GetDateTime(4).ToString("HH:mm"), reader.GetDateTime(5).ToString("HH:mm"))
                i = i + 1
            End While
        End Using

        If dt.Rows.Count > 0 Then
            dgv1.DataSource = dt
            dgv1.Refresh()
        End If
    End Sub

    Private Sub Details_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dt.Columns.Add("#", GetType(Int32))
        dt.Columns.Add("Type", GetType(String))
        dt.Columns.Add("V. Num", GetType(String))
        dt.Columns.Add("NIC", GetType(String))
        dt.Columns.Add("TP", GetType(String))
        dt.Columns.Add("Location", GetType(Integer))
        dt.Columns.Add("Date", GetType(String))
        dt.Columns.Add("Arr. Time", GetType(String))
        dt.Columns.Add("Dep. Time", GetType(String))
    End Sub
End Class