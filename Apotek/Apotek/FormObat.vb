Imports MySql.Data.MySqlClient

Public Class FormObat

    Public mode As String
    Public id_data As String

    Private Sub FormObat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
        isigrid()
        isicb()
        reset()
    End Sub

    Sub isigrid()
        Dim query As String = "SELECT o.id_obat,o.nama_obat,k.nama_kategori,g.nama_golongan,p.nama_produksi,sd.nama_sediaan,st.nama_satuan,o.tgl_expired,o.stok,o.harga FROM obat o JOIN kategori k on k.id_kategori = o.id_kategori JOIN golongan g on g.id_golongan = o.id_golongan JOIN produksi p on p.id_produksi = o.id_produksi JOIN sediaan sd on sd.id_sediaan = o.id_sediaan JOIN satuan st on st.id_satuan = o.id_satuan"
        Dim da As New MySqlDataAdapter(query, konek)
        Dim ds As New DataSet()
        If da.Fill(ds) Then
            dgv.DataSource = ds.Tables(0)
            dgv.Refresh()
        End If
        If dgv.RowCount > 0 Then
            judulgrid()
        End If
    End Sub

    Sub judulgrid()
        Dim objAlternatingCellStyle As New DataGridViewCellStyle()
        dgv.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle
        Dim style As DataGridViewCellStyle = dgv.Columns(0).DefaultCellStyle
        dgv.Columns(0).HeaderText = "ID Obat"
        dgv.Columns(1).HeaderText = "Nama Obat"
        dgv.Columns(8).HeaderText = "Stok"
        dgv.Columns(9).HeaderText = "Harga"
        dgv.Columns(0).Width = 100
        dgv.Columns(1).Width = 150
        dgv.Columns(8).Width = 50
        dgv.Columns(9).Width = 80
        dgv.Columns(2).Visible = False
        dgv.Columns(3).Visible = False
        dgv.Columns(4).Visible = False
        dgv.Columns(5).Visible = False
        dgv.Columns(6).Visible = False
        dgv.Columns(7).Visible = False
        objAlternatingCellStyle.BackColor = Color.AliceBlue
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgv.ReadOnly = True
    End Sub

    Sub isicb()
        Dim q As String = "select * from kategori"
        ComboBox1.DataSource = querycb(q)
        ComboBox1.ValueMember = "id_kategori"
        ComboBox1.DisplayMember = "nama_kategori"

        q = "select * from golongan"
        ComboBox2.DataSource = querycb(q)
        ComboBox2.ValueMember = "id_golongan"
        ComboBox2.DisplayMember = "nama_golongan"

        q = "select * from produksi"
        ComboBox3.DataSource = querycb(q)
        ComboBox3.ValueMember = "id_produksi"
        ComboBox3.DisplayMember = "nama_produksi"

        q = "select * from sediaan"
        ComboBox4.DataSource = querycb(q)
        ComboBox4.ValueMember = "id_sediaan"
        ComboBox4.DisplayMember = "nama_sediaan"

        q = "select * from satuan"
        ComboBox5.DataSource = querycb(q)
        ComboBox5.ValueMember = "id_satuan"
        ComboBox5.DisplayMember = "nama_satuan"
    End Sub


    Sub reset()
        TextBox3.Enabled = False
        ComboBox1.Enabled = False
        ComboBox2.Enabled = False
        ComboBox3.Enabled = False
        ComboBox4.Enabled = False
        ComboBox5.Enabled = False
        DateTimePicker1.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        bersih()
        Button1.Enabled = True
        Button1.Text = "Tambah"
        Button2.Enabled = False
        Button3.Enabled = False
    End Sub

    Sub bersih()
        TextBox3.Text = ""
        ComboBox1.SelectedIndex = -1
        ComboBox2.SelectedIndex = -1
        ComboBox3.SelectedIndex = -1
        ComboBox4.SelectedIndex = -1
        ComboBox5.SelectedIndex = -1
        TextBox4.Text = ""
        TextBox5.Text = ""
        no_obat()
    End Sub

    Sub modesimpan()
        TextBox3.Enabled = True
        ComboBox1.Enabled = True
        ComboBox2.Enabled = True
        ComboBox3.Enabled = True
        ComboBox4.Enabled = True
        ComboBox5.Enabled = True
        DateTimePicker1.Enabled = True
        TextBox4.Enabled = True
        TextBox5.Enabled = True
        Button1.Enabled = True
        Button1.Text = "Simpan"
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = True
        TextBox3.Focus()
    End Sub

    Sub modeedit()
        TextBox3.Enabled = True
        ComboBox1.Enabled = False
        ComboBox2.Enabled = False
        ComboBox3.Enabled = False
        ComboBox4.Enabled = False
        ComboBox5.Enabled = False
        DateTimePicker1.Enabled = True
        TextBox4.Enabled = True
        TextBox5.Enabled = True
        Button1.Enabled = True
        Button1.Text = "Simpan"
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = True
        TextBox3.Focus()
    End Sub
    Sub querytambah()
        Dim strsimpan As String = "INSERT INTO obat" _
                                & " VALUES ('" & TextBox2.Text & "','" & TextBox3.Text.ToUpper & "','" & ComboBox1.SelectedValue.ToString & "','" & ComboBox2.SelectedValue.ToString & "','" & ComboBox3.SelectedValue.ToString & "','" & ComboBox4.SelectedValue.ToString & "','" & ComboBox5.SelectedValue.ToString & "','" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "','" & Convert.ToInt32(TextBox4.Text) & "','" & Convert.ToInt32(TextBox5.Text) & "')"
        query(strsimpan)
        MsgBox("Berhasil tambah data!")
        isigrid()
    End Sub
    Sub queryedit()
        Dim strEdit As String = "UPDATE obat SET nama_obat = '" & TextBox3.Text.ToUpper & "',tgl_expired = '" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "',stok = '" & Convert.ToInt32(TextBox4.Text) & "',harga = '" & Convert.ToInt32(TextBox5.Text) & "' " _
                              & "WHERE id_obat = '" & id_data & "'"
        query(strEdit)
        MsgBox("Berhasil edit data!")
        isigrid()
    End Sub

    Sub queryhapus()
        Dim strhapus As String = "DELETE FROM obat WHERE id_obat = '" & id_data & "'"
        query(strhapus)
        isigrid()
        MsgBox("Berhasil hapus data!")
    End Sub

    Sub GridToTextBox()
        dgv.Refresh()
        If dgv.RowCount > 0 Then
            Dim baris As Integer
            With dgv
                baris = .CurrentRow.Index
                id_data = .Item(0, baris).Value
                TextBox2.Text = .Item(0, baris).Value
                TextBox3.Text = .Item(1, baris).Value
                ComboBox1.Text = .Item(2, baris).Value
                ComboBox2.Text = .Item(3, baris).Value
                ComboBox3.Text = .Item(4, baris).Value
                ComboBox4.Text = .Item(5, baris).Value
                ComboBox5.Text = .Item(6, baris).Value
                DateTimePicker1.Value = .Item(7, baris).Value
                TextBox4.Text = .Item(8, baris).Value
                TextBox5.Text = .Item(9, baris).Value
            End With
        End If
    End Sub

    Sub no_obat()
        If ComboBox2.SelectedIndex = -1 Then
            TextBox2.Text = "00000000"
        Else
            cmd = New MySqlCommand("SELECT counter FROM golongan WHERE id_golongan = '" & ComboBox2.SelectedValue.ToString & "'", konek)
            dr = cmd.ExecuteReader
            dr.Read()
            If Not dr.HasRows Then
            Else
                Dim hitung As Integer = dr.GetString(0) + 1
                If Len(hitung.ToString) = 1 Then
                    TextBox2.Text = TextBox2.Text.Remove(5, 3).Insert(5, "00" & hitung)
                ElseIf Len(hitung.ToString) = 2 Then
                    TextBox2.Text = TextBox2.Text.Remove(5, 3).Insert(5, "0" & hitung)
                ElseIf Len(hitung.ToString) = 3 Then
                    TextBox2.Text = TextBox2.Text.Remove(5, 3).Insert(5, hitung)
                End If
            End If
            dr.Close()
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Button1.Text = "Tambah" Then
            mode = "tambah"
            modesimpan()
            bersih()
        Else
            If TextBox3.Text = "" Or ComboBox1.SelectedIndex = -1 Or ComboBox2.SelectedIndex = -1 _
                Or ComboBox3.SelectedIndex = -1 Or ComboBox4.SelectedIndex = -1 Or _
                ComboBox5.SelectedIndex = -1 Or TextBox4.Text = "" Or TextBox5.Text = "" Then
                MsgBox("Lengkapi data yang kosong!", 16, "Informasi")
            Else
                If mode = "tambah" Then
                    querytambah()
                    reset()
                Else
                    queryedit()
                    reset()
                End If
            End If
        End If
    End Sub


    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedIndex <> -1 Then
            TextBox2.Text = TextBox2.Text.Remove(0, 1).Insert(0, ComboBox1.SelectedValue.ToString)
        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        If ComboBox2.SelectedIndex <> -1 Then
            TextBox2.Text = TextBox2.Text.Remove(1, 1).Insert(1, ComboBox2.SelectedValue.ToString)
            If ComboBox2.Enabled = True Then
                no_obat()
            End If
        End If
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        If ComboBox3.SelectedIndex <> -1 Then
            TextBox2.Text = TextBox2.Text.Remove(2, 1).Insert(2, ComboBox3.SelectedValue.ToString)
        End If
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        If ComboBox4.SelectedIndex <> -1 Then
            TextBox2.Text = TextBox2.Text.Remove(3, 2).Insert(3, ComboBox4.SelectedValue.ToString)
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        reset()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Close()
    End Sub

    Private Sub dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellClick
        reset()
        GridToTextBox()
        Button1.Enabled = False
        Button2.Enabled = True
        Button3.Enabled = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        mode = "edit"
        modeedit()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim nhps As Integer
        nhps = MsgBox("Yakin hapus obat " & TextBox3.Text & " (" & TextBox2.Text & ") ?", 48 + 4 + 256, "Konfirmasi")
        If nhps = 6 Then
            queryhapus()
            reset()
        End If
    End Sub

    Sub pencarian()
        Dim strtext As String = "SELECT o.id_obat,o.nama_obat,k.nama_kategori,g.nama_golongan,p.nama_produksi,sd.nama_sediaan,st.nama_satuan,o.tgl_expired,o.stok,o.harga FROM obat o JOIN kategori k on k.id_kategori = o.id_kategori JOIN golongan g on g.id_golongan = o.id_golongan JOIN produksi p on p.id_produksi = o.id_produksi JOIN sediaan sd on sd.id_sediaan = o.id_sediaan JOIN satuan st on st.id_satuan = o.id_satuan WHERE (o.id_obat LIKE '%" & TextBox1.Text & "%' or o.nama_obat like '%" & TextBox1.Text & "%')"
        Using cmd As New MySqlCommand(strtext, konek)
            Using adapter As New MySqlDataAdapter(cmd)
                Using DataSet As New DataSet()
                    adapter.Fill(DataSet)
                    dgv.DataSource = DataSet.Tables(0)
                    dgv.ReadOnly = True
                    judulgrid()
                End Using
            End Using
        End Using

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        pencarian()
    End Sub
End Class