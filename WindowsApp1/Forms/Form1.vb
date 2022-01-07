Public Class Form1
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim uName As String = "Admin"
        Dim pass As String = "1234"

        If (txtUName.Text = uName And txtPass.Text = pass) Then
            frmHome.Show()
            Me.Close()
        Else
            MessageBox.Show("Invalid credentials." + Environment.NewLine + "Please try again later", "Invalid credentials", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class