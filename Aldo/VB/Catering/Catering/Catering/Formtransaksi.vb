Imports MySql.Data.MySqlClient

Public Class Formtransaksi
    Sub isigrid1()
        Dim query As String = "select kt.id_menu,tp.nama_paket,kt.harga,kt.porsi from keranjang_trx kt join tbpaket tp on kt.id_menu = tp.id_paket"
        Dim da As New MySqlDataAdapter(query, konek)
        Dim ds As New DataSet()
        If da.Fill(ds) Then
            dgvmakanan.DataSource = ds.Tables(0)
            dgvmakanan.Refresh()
        Else
            dgvmakanan.DataSource = Nothing
        End If
        If dgvmakanan.RowCount > 0 Then
            Call judulgrid1()
        End If
    End Sub

    Sub judulgrid1()
        Dim objAlternatingCellStyle As New DataGridViewCellStyle()
        dgvmakanan.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle
        Dim style As DataGridViewCellStyle = dgvmakanan.Columns(0).DefaultCellStyle
        dgvmakanan.Columns(1).HeaderText = "Nama Paket"
        dgvmakanan.Columns(2).HeaderText = "Harga Paket"

        dgvmakanan.Columns(0).Visible = False
        dgvmakanan.Columns(1).Width = 120
        dgvmakanan.Columns(2).Width = 150

        objAlternatingCellStyle.BackColor = Color.AliceBlue
        dgvmakanan.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub
    Private Sub btntambahpaket_Click(sender As Object, e As EventArgs) Handles btncarikonsumen.Click
        konsumen.Show()
        konsumen.from = "trx"
    End Sub

    Private Sub btncari_Click(sender As Object, e As EventArgs) Handles btncari.Click
        FormPaket.Show()
        FormPaket.from = "trx"
    End Sub
    Sub tambahmakanan()
        Dim strsimpan As String = "INSERT INTO keranjang_trx" _
                                & " VALUES ('" & idmakanan.Text & "','" & TextBox1.Text & "','" & TextBox3.Text & "')"
        simpandata(strsimpan)
        isigrid1()
        TextBox1.Clear()
        TextBox2.Clear()
        MsgBox("Berhasil menambahkan makanan!")
    End Sub
    Private Sub btntambah_Click_1(sender As Object, e As EventArgs) Handles btntambah.Click
        tambahmakanan()
    End Sub

    Private Sub btnhapus_Click(sender As Object, e As EventArgs) Handles btnhapus.Click
        Dim strhapus As String = "DELETE FROM keranjang_trx WHERE id_menu = '" & idhapus.Text & "'"
        HAPUSDATA(strhapus)
        isigrid1()
    End Sub

    Private Sub dgvmakanan_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvmakanan.CellClick
        idhapus.Text = dgvmakanan.Item(0, dgvmakanan.CurrentRow.Index).Value
    End Sub

    Private Sub dgvmakanan_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvmakanan.CellContentClick

    End Sub

    Private Sub Formtransaksi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        isigrid1()
    End Sub

    Private Sub btnsimpan_Click(sender As Object, e As EventArgs) Handles btnsimpan.Click
    End Sub
End Class