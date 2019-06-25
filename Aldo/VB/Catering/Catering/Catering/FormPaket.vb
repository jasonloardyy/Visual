Imports MySql.Data.MySqlClient
Public Class FormPaket

    Public from As String
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        from = ""
        Call koneksi()
        Call isigrid1()
        GroupBox2.Enabled = False
    End Sub
    Sub isigrid1()
        Dim query As String = "select * from tbpaket"
        Dim da As New MySqlDataAdapter(query, konek)
        Dim ds As New DataSet()
        If da.Fill(ds) Then
            dgvpaket.DataSource = ds.Tables(0)
            dgvpaket.Refresh()
        Else
            dgvpaket.DataSource = Nothing
        End If
        If dgvpaket.RowCount > 0 Then
            Call judulgrid1()
        End If
    End Sub

    Sub isigrid2()
        Dim query As String = "SELECT tbm.nama_makanan,tbm.harga_makanan FROM detail_paket dp JOIN tbmakanan tbm ON dp.id_makanan=tbm.id_makanan WHERE dp.id_paket = '" & idpaket.Text & "'"
        Dim da As New MySqlDataAdapter(query, konek)
        Dim ds As New DataSet()
        If da.Fill(ds) Then
            dgvmakanan.DataSource = ds.Tables(0)
            dgvmakanan.Refresh()
        Else
            dgvmakanan.DataSource = Nothing
        End If
        If dgvmakanan.RowCount > 0 Then
            Call judulgrid2()
        End If
    End Sub

    Sub judulgrid1()
        Dim objAlternatingCellStyle As New DataGridViewCellStyle()
        dgvpaket.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle
        Dim style As DataGridViewCellStyle = dgvpaket.Columns(0).DefaultCellStyle
        dgvpaket.Columns(1).HeaderText = "Nama Paket"
        dgvpaket.Columns(2).HeaderText = "Harga Paket"

        dgvpaket.Columns(0).Visible = False
        dgvpaket.Columns(1).Width = 120
        dgvpaket.Columns(2).Width = 150

        objAlternatingCellStyle.BackColor = Color.AliceBlue
        dgvpaket.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub

    Sub judulgrid2()
        Dim objAlternatingCellStyle As New DataGridViewCellStyle()
        dgvmakanan.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle
        Dim style As DataGridViewCellStyle = dgvmakanan.Columns(0).DefaultCellStyle
        dgvmakanan.Columns(0).HeaderText = "Nama Makanan"
        dgvmakanan.Columns(1).HeaderText = "Harga Makanan"
        dgvmakanan.Columns(0).Width = 120
        dgvmakanan.Columns(1).Width = 150

        objAlternatingCellStyle.BackColor = Color.AliceBlue
        dgvmakanan.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub

    Sub tambahpaket()
        Dim strsimpan As String = "INSERT INTO tbpaket(nama_paket,harga_paket)" _
                                & " VALUES ('" & tbnamapaket.Text & "','" & tbhargapaket.Text & "')"
        simpandata(strsimpan)
        isigrid1()
        MsgBox("Berhasil menambahkan paket!")
    End Sub

    Sub tambahmakanan()
        Dim strsimpan As String = "INSERT INTO detail_paket(id_paket,id_makanan)" _
                                & " VALUES ('" & idpaket.Text & "','" & idmakanan.Text & "')"
        simpandata(strsimpan)
        isigrid2()
        TextBox1.Clear()
        TextBox2.Clear()
        MsgBox("Berhasil menambahkan makanan!")
    End Sub

    Private Sub btntambahpaket_Click(sender As Object, e As EventArgs) Handles btntambahpaket.Click
        tambahpaket()
    End Sub

    Private Sub btncari_Click(sender As Object, e As EventArgs) Handles btncari.Click
        makanan.Show()
        makanan.from = "paket"
    End Sub

    Private Sub dgvpaket_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvpaket.CellClick
        GroupBox2.Enabled = True
        Dim baris As Integer
        With dgvpaket
            baris = .CurrentRow.Index
            idpaket.Text = .Item(0, baris).Value
            tbnamapaket.Text = .Item(1, baris).Value
            tbhargapaket.Text = .Item(2, baris).Value
        End With
        isigrid2()
    End Sub

    Private Sub dgvpaket_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvpaket.CellDoubleClick
        If from = "trx" Then
            Dim nhps As Integer
            Dim baris As Integer

            baris = dgvpaket.CurrentRow.Index
            nhps = MsgBox("Masukkan menu  " & dgvpaket.Item(1, baris).Value & " ?", 48 + 4 + 256, "Konfirmasi")
            If nhps = 6 Then
                With dgvpaket
                    Formtransaksi.idmakanan.Text = .Item(0, baris).Value
                    Formtransaksi.TextBox2.Text = .Item(1, baris).Value
                    Formtransaksi.TextBox1.Text = .Item(2, baris).Value
                End With
                Me.Close()
            End If


        End If
    End Sub

    Private Sub btntambah_Click(sender As Object, e As EventArgs) Handles btntambah.Click
        tambahmakanan()
    End Sub

    Sub hapuspaket()
        Dim strhapus As String = "DELETE FROM tbpaket WHERE id_paket = '" & idpaket.Text & "'"
        HAPUSDATA(strhapus)
        strhapus = "DELETE FROM detail_paket WHERE id_paket = '" & idpaket.Text & "'"
        HAPUSDATA(strhapus)
        isigrid1()
        MsgBox("Berhasil menghapus paket!")
        idpaket.Clear()
        GroupBox2.Enabled = False
        dgvmakanan.DataSource = Nothing
        tbnamapaket.Clear()
        tbhargapaket.Clear()
    End Sub


    Private Sub dgvpaket_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvpaket.CellEnter
        idpaket.Text = dgvpaket.Item(0, dgvpaket.CurrentRow.Index).Value

    End Sub

    Private Sub btnhapuspaket_Click(sender As Object, e As EventArgs) Handles btnhapuspaket.Click
        If idpaket.Text.Length > 0 Then
            Dim nhps As Integer
            nhps = MsgBox("Yakin menghapus paket " & dgvpaket.Item(1, dgvpaket.CurrentRow.Index).Value & " ?", 48 + 4 + 256, "Konfirmasi")
            If nhps = 6 Then
                hapuspaket()
            End If
        End If
    End Sub

    Private Sub dgvpaket_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvpaket.CellContentClick

    End Sub

    Private Sub btnhapus_Click(sender As Object, e As EventArgs) Handles btnhapus.Click

    End Sub
End Class