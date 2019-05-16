Public Class FormUtama

    Private Sub DataGolonganToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataGolonganToolStripMenuItem.Click
        FormObat.Show()
    End Sub

    Private Sub PenjualanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PenjualanToolStripMenuItem.Click
        FormPenjualan.Show()
    End Sub

    Private Sub DataGolonganToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DataGolonganToolStripMenuItem1.Click
        FormGolongan.Show()
    End Sub

    Private Sub DataKategoriToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DataKategoriToolStripMenuItem1.Click
        FormKategori.Show()
    End Sub

    Private Sub DataPenjualanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataPenjualanToolStripMenuItem.Click
        FormProduksi.Show()
    End Sub

    Private Sub DataSatuanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataSatuanToolStripMenuItem.Click
        FormSatuan.Show()
    End Sub

    Private Sub DataSediaanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataSediaanToolStripMenuItem.Click
        FormSediaan.Show()
    End Sub

    Private Sub BerdasarkanNotaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BerdasarkanNotaToolStripMenuItem.Click
        FormCtkReport.Show()
    End Sub

    Private Sub BerdasarkanPeriodeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BerdasarkanPeriodeToolStripMenuItem.Click
        FormCtkReportPeriode.Show()
    End Sub
End Class