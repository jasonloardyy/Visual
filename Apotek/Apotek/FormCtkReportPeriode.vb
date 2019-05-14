
Public Class FormCtkReportPeriode

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FormViewReport.CRHarian1.RecordSelectionFormula = "{penjualan1.tanggal} = Date('" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "')"
        FormViewReport.Show()
    End Sub
End Class