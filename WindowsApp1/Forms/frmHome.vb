﻿Public Class frmHome
    Dim frmVHCat As frmVehicleCategory
    Dim frmReg As frmRegisterVehicle
    Dim frmDetails As frmDetails
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If frmReg Is Nothing OrElse frmReg.IsDisposed Then
            frmReg = New frmRegisterVehicle()
        End If

        frmReg.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If frmVHCat Is Nothing OrElse frmVHCat.IsDisposed Then
            frmVHCat = New frmVehicleCategory()
        End If

        frmVHCat.Show()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If frmDetails Is Nothing OrElse frmDetails.IsDisposed Then
            frmDetails = New frmDetails()
        End If

        frmDetails.Show()
    End Sub
End Class