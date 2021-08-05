
Imports Microsoft.Reporting.WinForms

Public Class frmReceipt
    Private Sub frmReceipt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ReportViewer1.LocalReport.ReportPath = "c:\users\chaluka hashan\desktop\p3\WindowsApp1\Reports\DepartureTicker.rdlc"

        Dim r(o) As ReportParameter

        Me.ReportViewer1.RefreshReport()
    End Sub

End Class