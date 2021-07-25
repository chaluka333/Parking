Imports MySql.Data.MySqlClient

Public Class frmVehicleCategory
    Dim DBCon As MySqlConnection = DBConnection.GetConnection()
    Dim dt As New DataTable
    Private Sub VehicleCategory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ClearAll()
        RefreshDGV()
    End Sub

    Private Sub RefreshDGV()
        Dim cmd = DBCon.CreateCommand()
        cmd.CommandText = "SELECT V_Type as Type, V_Charge as Charge, V_Min as 'From', V_Max as 'To' FROM tblvehicle"

        dt.Clear()
        Using reader = cmd.ExecuteReader()
            dt.Load(reader)
        End Using

        dgv1.DataSource = dt
        dgv1.Refresh()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not String.IsNullOrEmpty(txtType.Text) AndAlso numCharge.Value > 0 AndAlso numFrom.Value > 0 And numTo.Value > 0 Then
            Dim cmd = DBCon.CreateCommand()
            cmd.CommandText = "INSERT INTO tblvehicle VALUES (@type, @charge, @min, @max)"
            cmd.Parameters.AddWithValue("@type", txtType.Text)
            cmd.Parameters.AddWithValue("@charge", numCharge.Value)
            cmd.Parameters.AddWithValue("@min", numFrom.Value)
            cmd.Parameters.AddWithValue("@max", numTo.Value)

            Dim result = cmd.ExecuteNonQuery()
            If result > 0 Then
                MessageBox.Show("Data added", "Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information)
                RefreshDGV()
                ClearAll()
            Else
                MessageBox.Show("Data inserting faild. Please try again.", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Please fill all the field", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub dgv1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgv1.CellMouseClick
        Dim i As Integer
        i = dgv1.CurrentRow.Index

        txtType.Text = dgv1.Item(0, i).Value
        numCharge.Value = dgv1.Item(1, i).Value
        numFrom.Value = dgv1.Item(2, i).Value
        numTo.Value = dgv1.Item(3, i).Value
    End Sub

    Private Sub txtType_TextChanged(sender As Object, e As EventArgs) Handles txtType.TextChanged
        For Each row As DataRow In dt.Rows
            If row.ItemArray(0).ToString().ToLower() = txtType.Text.ToLower() Then
                txtType.Enabled = False
                btnAdd.Enabled = False
                btnUpdate.Enabled = True
                numCharge.Value = Int(row.ItemArray(1).ToString())
                numFrom.Value = Int(row.ItemArray(2).ToString())
                numTo.Value = Int(row.ItemArray(3).ToString())
                Exit For
            End If
        Next
    End Sub

    Private Sub ClearAll()
        txtType.Enabled = True
        btnAdd.Enabled = True
        btnUpdate.Enabled = False
        txtType.Text = ""
        txtType.Focus()
        numCharge.Value = 0
        numFrom.Value = 0
        numTo.Value = 0
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ClearAll()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If numCharge.Value > 0 AndAlso numFrom.Value > 0 And numTo.Value > 0 Then
            Dim cmd = DBCon.CreateCommand()
            cmd.CommandText = "UPDATE tblvehicle SET V_Charge = @charge, V_Min = @min, V_Max = @max WHERE V_Type = @type"
            cmd.Parameters.AddWithValue("@type", txtType.Text)
            cmd.Parameters.AddWithValue("@charge", numCharge.Value)
            cmd.Parameters.AddWithValue("@min", numFrom.Value)
            cmd.Parameters.AddWithValue("@max", numTo.Value)

            Dim result = cmd.ExecuteNonQuery()
            If result > 0 Then
                MessageBox.Show("Data updated", "Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information)
                RefreshDGV()
                ClearAll()
            Else
                MessageBox.Show("Data updating faild. Please try again.", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Please fill all the field", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub dgv1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv1.CellContentClick

    End Sub
End Class