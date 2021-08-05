Imports Microsoft.Reporting.WinForms

Public Class frmReceipt
    Private ticketArr As TicketArrival

    Sub New(arr As TicketArrival)
        ticketArr = arr

        InitializeComponent()
    End Sub
    Private Sub frmReceipt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim arrDate, arrTime, location, vNum As ReportParameter

        arrDate = New ReportParameter("date", ticketArr.arrDate.ToString("yy - MMM - dd"), True)
        arrTime = New ReportParameter("time", ticketArr.arrDate.ToString("HH : mm"), True)
        location = New ReportParameter("location", ticketArr.location.ToString(), True)
        vNum = New ReportParameter("vNum", ticketArr.vNum.ToString(), True)

        ReportViewer1.LocalReport.SetParameters(New ReportParameter() {arrDate, arrTime, location, vNum})
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class