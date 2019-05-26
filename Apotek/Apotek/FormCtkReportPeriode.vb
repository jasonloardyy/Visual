Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO

Public Class FormCtkReportPeriode

    Sub cb_tahun()
        Dim q As String = "SELECT DISTINCT LEFT(tanggal,4) AS Tahun FROM penjualan order by tahun"
        ComboBox2.DataSource = querycb(q)
        ComboBox2.ValueMember = "Tahun"
        ComboBox2.DisplayMember = "Tahun"

        ComboBox3.DataSource = querycb(q)
        ComboBox3.ValueMember = "Tahun"
        ComboBox3.DisplayMember = "Tahun"
    End Sub
    Sub cb_bulan()
        Dim q As String = "SELECT DISTINCT MID(tanggal,6,2) AS NoBulan," _
                           & "(CASE WHEN MID(tanggal,6,2) = 01 THEN 'JANUARI'" _
                           & "WHEN MID(tanggal,6,2) = 02 THEN 'FEBRUARI'" _
                           & "WHEN MID(tanggal,6,2) = 03 THEN 'MARET'" _
                           & "WHEN MID(tanggal,6,2) = 04 THEN 'APRIL'" _
                           & "WHEN MID(tanggal,6,2) = 05 THEN 'MEI'" _
                           & "WHEN MID(tanggal,6,2) = 06 THEN 'JUNI'" _
                           & "WHEN MID(tanggal,6,2) = 07 THEN 'JULI'" _
                           & "WHEN MID(tanggal,6,2) = 08 THEN 'AGUSTUS'" _
                           & "WHEN MID(tanggal,6,2) = 09 THEN 'SEPTEMBER'" _
                           & "WHEN MID(tanggal,6,2) = 10 THEN 'OKTOBER'" _
                           & "WHEN MID(tanggal,6,2) = 11 THEN 'NOVEMBER'" _
                           & "WHEN MID(tanggal,6,2) = 12 THEN 'DESEMBER'" _
                           & "END) AS NamaBulan " _
                           & "FROM penjualan WHERE LEFT(tanggal,4) = '" & ComboBox2.Text & "'"
        ComboBox1.DataSource = querycb(q)
        ComboBox1.ValueMember = "NoBulan"
        ComboBox1.DisplayMember = "NamaBulan"
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim cryReport As New ReportDocument
        Dim RepLocation = Path.GetFullPath( _
                Path.Combine(Application.StartupPath, "..\.."))
        If RadioButton1.Checked = True Then
            cryReport.Load(RepLocation & "\CRHarian.rpt")
            cryReport.RecordSelectionFormula = "{penjualan1.tanggal} = Date('" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "')"
            FormViewReport.CrystalReportViewer1.ReportSource = cryReport
            FormViewReport.CrystalReportViewer1.Refresh()
            FormViewReport.Show()
        ElseIf RadioButton2.Checked = True And CheckBox1.Checked = False Then
            cryReport.Load(RepLocation & "\CRBulanan.rpt")
            cryReport.RecordSelectionFormula = "Month({penjualan1.tanggal}) = " & ComboBox1.SelectedValue & " and Year({penjualan1.tanggal}) = " & ComboBox2.SelectedValue
            FormViewReport.CrystalReportViewer1.ReportSource = cryReport
            FormViewReport.CrystalReportViewer1.Refresh()
            FormViewReport.Show()
        ElseIf RadioButton3.Checked = True Then
            cryReport.Load(RepLocation & "\CRTahunan.rpt")
            cryReport.RecordSelectionFormula = "Year({penjualan1.tanggal}) = " & ComboBox3.SelectedValue
            FormViewReport.CrystalReportViewer1.ReportSource = cryReport
            FormViewReport.CrystalReportViewer1.Refresh()
            FormViewReport.Show()
        ElseIf RadioButton2.Checked = True And CheckBox1.Checked = True Then
            cryReport.Load(RepLocation & "\CRBulananObat.rpt")
            cryReport.RecordSelectionFormula = "Month({penjualan1.tanggal}) = " & ComboBox1.SelectedValue & " and Year({penjualan1.tanggal}) = " & ComboBox2.SelectedValue
            FormViewReport.CrystalReportViewer1.ReportSource = cryReport
            FormViewReport.CrystalReportViewer1.Refresh()
            FormViewReport.Show()
        End If

    End Sub

    Private Sub FormCtkReportPeriode_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cb_tahun()
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        cb_bulan()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged

    End Sub
End Class