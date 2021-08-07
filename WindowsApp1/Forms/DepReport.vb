Imports Microsoft.Reporting.WinForms

Public Class DepReport
    Private ticketdpt As TicketDep
    Sub New(dpt As TicketDep)
        ticketdpt = dpt

        InitializeComponent()
    End Sub
    Private Sub DepReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dptDate, dptTime, fee, vNum As ReportParameter

        dptDate = New ReportParameter("Date", ticketdpt.dptDate.ToString("yy - MMM - dd"), True)
        dptTime = New ReportParameter("depature_time", ticketdpt.depTime.ToString("HH : mm"), True)
        fee = New ReportParameter("Fee", ticketdpt.fee.ToString(), True)
        vNum = New ReportParameter("Vehical_Number", ticketdpt.vNum.ToString(), True)

        ReportViewer1.LocalReport.SetParameters(New ReportParameter() {dptDate, dptTime, fee, vNum})

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class