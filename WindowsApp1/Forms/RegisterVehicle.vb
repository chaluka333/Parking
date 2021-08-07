Imports System.Text.RegularExpressions
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
        RefreshListView()

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

        RefreshDGV()
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

        If vhList.FirstOrDefault(Function(s) s.Vnum = txtVID.Text) IsNot Nothing Then
            MessageBox.Show("This vehicle register number is already in the parking lot. Please check registeration number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

            If Not isFromPerson Then
                Dim cmd = DBCon.CreateCommand()
                cmd.CommandText = "INSERT INTO tblPersonal VALUES (@nic, @num)"
                cmd.Parameters.AddWithValue("@nic", txtNIC.Text)
                cmd.Parameters.AddWithValue("@num", txtTP.Text)
                cmd.ExecuteNonQuery()
                GetPersonalDetails()
            End If

            If response Is Nothing Then
                MessageBox.Show("Error occured during the process. Please insert the data again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf response.Location = -1 Then
                MessageBox.Show("There is no room available for this type of vehicle", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                RefreshListView()
                RefreshDGV()
                Dim arrTicket = New TicketArrival()
                arrTicket.vNum = response.Vnum
                arrTicket.arrDate = response.ArrTime
                arrTicket.location = response.Location
                Dim ticket = New frmReceipt(arrTicket)
                ticket.Show()
                'MessageBox.Show("Vehicle registered" + Environment.NewLine + "Parking spot : " + response.Location.ToString(), "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            Throw
            MessageBox.Show("Error occured during the process. Please insert the data again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtTP_TextChanged(sender As Object, e As EventArgs) Handles txtTP.TextChanged

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblTime.Text = DateTime.Now.ToString("yyyy/MMM/dd | HH:mm:ss")
    End Sub

    Private Sub RefreshDGV()
        vhList = metaData.GetParkedList()
        dt.Rows.Clear()

        If vhList.Count > 0 Then
            Dim autoCol As New AutoCompleteStringCollection

            For Each item In vhList
                dt.Rows.Add(item.dbID, item.Vnum, item.Type, item.Location, item.ID, item.TP, item.ArrTime.ToString("dd/MMM | HH:mm"))
                autoCol.Add(item.Vnum)
            Next

            txtDepVehicle.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            txtDepVehicle.AutoCompleteSource = AutoCompleteSource.CustomSource
            txtDepVehicle.AutoCompleteCustomSource = autoCol

            dgv1.DataSource = dt
            dgv1.Refresh()
        End If
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
                MessageBox.Show("Vehicle departuring failed. Please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                Dim hrDiff = Convert.ToDecimal(DateDiff(DateInterval.Minute, response.ArrTime, response.DepTime))
                Dim fee As Integer, perHr As Integer

                For Each item In vehicleCol
                    If String.Equals(item.Type, response.Type) Then
                        perHr = item.Charge
                        Exit For
                    End If
                Next
                fee = perHr * Math.Ceiling(hrDiff / 60)

                RefreshListView()
                RefreshDGV()

                ClearDep()
                txtDepVehicle.Text = ""
                MessageBox.Show("Vehicle departure complete" + Environment.NewLine + "Fee : Rs." + fee.ToString() + ".00", "Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Dim dptTicket = New TicketDep()
                dptTicket.vNum = response.Vnum
                dptTicket.dptDate = response.DepTime.ToString("yy - MMM - dd")
                dptTicket.depTime = response.DepTime.ToString("HH : mm")
                dptTicket.fee = "Rs." + fee.ToString() + ".00"
                Dim ticket = New DepReport(dptTicket)
                ticket.Show()


            End If
        End If
    End Sub

    Private Sub RefreshListView()
        Dim slots = metaData.GetRemainSlots()
        lv1.Items.Clear()

        For Each items In slots
            lv1.Items.Add(items.Key + " : Slots " + items.Value.Count.ToString())
        Next
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

    Private Sub txtTP_Leave(sender As Object, e As EventArgs) Handles txtTP.Leave
        If Not String.IsNullOrWhiteSpace(txtTP.Text) AndAlso Not Regex.Match(txtTP.Text, "^[0-9]{10}$").Success Then
            txtTP.Text = ""
            MessageBox.Show("Invalid contact number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub txtNIC_Enter(sender As Object, e As EventArgs) Handles txtNIC.Enter

    End Sub

    Private Sub txtNIC_Leave(sender As Object, e As EventArgs) Handles txtNIC.Leave
        If Not String.IsNullOrWhiteSpace(txtNIC.Text) AndAlso Not Regex.Match(txtNIC.Text, "^([0-9]{11})$|^([0-9]{9}[v|V|x|X])$").Success Then
            txtNIC.Text = ""
            MessageBox.Show("Invalid NIC number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub lv1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lv1.SelectedIndexChanged

    End Sub
End Class
