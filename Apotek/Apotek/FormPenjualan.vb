Imports MySql.Data.MySqlClient
Imports System.Globalization

Public Class FormPenjualan
    Public no As Integer
    Public id_data As String
    Public total As String
    Public totalantrian As String
    Private Sub FormPenjualan_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
        System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo("en-US")
        koneksi()
        isigridantrian()
        reset()
    End Sub

    Sub reset()
        baru()
        TextBox8.Clear()
        TextBox1.Clear()
        GroupBox2.Enabled = False
    End Sub


    Sub isigridKeranjang()
        Dim query As String = "SELECT * FROM keranjang where id_antrian = '" & TextBox8.Text & "' ORDER BY no desc"
        Dim da As New MySqlDataAdapter(query, konek)
        Dim ds As New DataSet()
        If da.Fill(ds) Then
            dgvkeranjang.DataSource = ds.Tables(0)
            dgvkeranjang.Refresh()
        End If
        If dgvkeranjang.RowCount > 0 Then
            judulgridKeranjang()
        End If
        grandtotal()
    End Sub

    Sub judulgridKeranjang()
        Dim objAlternatingCellStyle As New DataGridViewCellStyle()
        dgvkeranjang.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle
        Dim style As DataGridViewCellStyle = dgvkeranjang.Columns(0).DefaultCellStyle
        dgvkeranjang.Columns(2).HeaderText = "ID Obat"
        dgvkeranjang.Columns(3).HeaderText = "Nama Obat"
        dgvkeranjang.Columns(4).HeaderText = "Qty"
        dgvkeranjang.Columns(5).HeaderText = "Harga"
        dgvkeranjang.Columns(6).HeaderText = "Subtotal"
        dgvkeranjang.Columns(2).Width = 70
        dgvkeranjang.Columns(3).Width = 300
        dgvkeranjang.Columns(4).Width = 45
        dgvkeranjang.Columns(5).Width = 80
        dgvkeranjang.Columns(6).Width = 80
        dgvkeranjang.Columns(5).DefaultCellStyle.Format = "n"
        dgvkeranjang.Columns(6).DefaultCellStyle.Format = "n"
        dgvkeranjang.Columns(0).Visible = False
        dgvkeranjang.Columns(1).Visible = False
        objAlternatingCellStyle.BackColor = Color.AliceBlue
        dgvkeranjang.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvkeranjang.ReadOnly = True
    End Sub

    Sub baru()
        GroupBox2.Enabled = True
        no_antrian()
        queryresetkeranjang()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox7.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        total = "0"
        Label8.Text = "Rp. 0"
    End Sub


    Sub no_antrian()
        cmd = New MySqlCommand("select coalesce(MAX(id_antrian), 0) from antrian", konek)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.GetString(0) = 0 Then
            TextBox8.Text = "0001"
        Else
            Dim hitung As Integer = dr.GetString(0) + 1
            If Len(hitung.ToString) = 1 Then
                TextBox8.Text = "000" & hitung
            ElseIf Len(hitung.ToString) = 2 Then
                TextBox8.Text = "00" & hitung
            ElseIf Len(hitung.ToString) = 3 Then
                TextBox8.Text = "0" & hitung
            ElseIf Len(hitung.ToString) = 4 Then
                TextBox8.Text = hitung
            End If
        End If
        dr.Close()
        TextBox1.Text = "TRX" & CLng(DateTime.UtcNow.Subtract(New DateTime(1970, 1, 1)).TotalSeconds)
    End Sub

    Sub no_urutkeranjang()
        cmd = New MySqlCommand("select coalesce(MAX(no), 0) from keranjang where id_antrian = '" & TextBox8.Text & "'", konek)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.GetString(0) = 0 Then
            no = 1
        Else
            no = dr.GetString(0) + 1
        End If
        dr.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FormObat.Show()
        FormObat.from = "penjualan"
    End Sub

    Sub grandtotal()
        cmd = New MySqlCommand("select coalesce(sum(subtotal),0) from keranjang where id_antrian = '" & TextBox8.Text & "'", konek)
        dr = cmd.ExecuteReader
        dr.Read()
        total = FormatNumber(dr.GetString(0), 0)
        dr.Close()
        Label8.Text = "Rp. " & total
    End Sub

    Sub hitungtotalAntrian()
        cmd = New MySqlCommand("select coalesce(sum(total),0) from antrian", konek)
        dr = cmd.ExecuteReader
        dr.Read()
        totalantrian = FormatNumber(dr.GetString(0), 0)
        dr.Close()
        Label9.Text = "Total = Rp. " & totalantrian
    End Sub

    Sub ToKeranjang()
        no_urutkeranjang()
        Dim subtotal As Decimal = Convert.ToDecimal(TextBox6.Text) * Convert.ToDecimal(TextBox7.Text)
        Dim strsimpan As String = "INSERT INTO keranjang" _
                                & " VALUES ('" & TextBox8.Text & "','" & no & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox6.Text & "','" & TextBox7.Text & "','" & subtotal & "')"
        query(strsimpan)
        isigridKeranjang()
        refreshantrian()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox7.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
    End Sub


    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If TextBox3.Text = "" Then
            MsgBox("Silahkan pilih data obat!")
        ElseIf TextBox6.Text = "" Then
            MsgBox("Masukkan jumlah obat!")
        ElseIf Convert.ToInt16(TextBox6.Text) > Convert.ToInt16(TextBox5.Text) Then
            MsgBox("Stok tidak tersedia!")
        Else
            ToKeranjang()
        End If
    End Sub

    Sub queryresetkeranjang()
        Dim strreset As String = "delete from keranjang where id_antrian = '" & TextBox8.Text & "'"
        query(strreset)
        dgvkeranjang.DataSource = Nothing
        grandtotal()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim npilih As Integer
        npilih = MsgBox("Reset keranjang ?", 48 + 4 + 256, "Konfirmasi")
        If npilih = 6 Then
            queryresetkeranjang()
        End If
    End Sub

    Private Sub dgvkeranjang_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvkeranjang.CellEnter
        id_data = dgvkeranjang.Item(1, dgvkeranjang.CurrentRow.Index).Value
    End Sub

    Sub queryhapus()
        Dim strhapus As String = "DELETE FROM keranjang WHERE id_antrian = '" & TextBox8.Text & "' AND no = '" & id_data & "'"
        query(strhapus)
        isigridKeranjang()
        cmd = New MySqlCommand("SELECT * FROM keranjang WHERE id_antrian = '" & TextBox8.Text & "'", konek)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            dr.Close()
        Else
            dr.Close()
            dgvkeranjang.DataSource = Nothing
        End If

    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim nhps As Integer
        nhps = MsgBox("Hapus obat " & dgvkeranjang.Item(3, dgvkeranjang.CurrentRow.Index).Value & " dari keranjang ?", 48 + 4 + 256, "Konfirmasi")
        If nhps = 6 Then
            queryhapus()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        baru()
    End Sub
    Sub batal()
        Dim strhapus As String = "DELETE FROM antrian WHERE id_antrian = '" & TextBox8.Text & "';DELETE FROM keranjang WHERE id_antrian = '" & TextBox8.Text & "'"
        query(strhapus)
        cmd = New MySqlCommand("SELECT * FROM antrian WHERE id_antrian = '" & TextBox8.Text & "'", konek)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            dr.Close()
        Else
            dr.Close()
            dgvantrian.DataSource = Nothing
        End If
        reset()
        isigridantrian()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim npilih As Integer
        npilih = MsgBox("Batalkan penjualan ?", 48 + 4 + 256, "Konfirmasi")
        If npilih = 6 Then
            batal()
        End If
    End Sub

    Sub isigridantrian()
        Dim query As String = "SELECT * FROM antrian"
        Dim da As New MySqlDataAdapter(query, konek)
        Dim ds As New DataSet()
        If da.Fill(ds) Then
            dgvantrian.DataSource = ds.Tables(0)
            dgvantrian.Refresh()
        End If
        If dgvantrian.RowCount > 0 Then
            judulgridantrian()
        End If
        hitungtotalAntrian()
    End Sub

    Sub judulgridantrian()
        Dim objAlternatingCellStyle As New DataGridViewCellStyle()
        dgvantrian.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle
        Dim style As DataGridViewCellStyle = dgvantrian.Columns(0).DefaultCellStyle
        dgvantrian.Columns(0).HeaderText = "No."
        dgvantrian.Columns(2).HeaderText = "Nama Pelanggan"
        dgvantrian.Columns(3).HeaderText = "Total"
        dgvantrian.Columns(3).DefaultCellStyle.Format = "n"
        dgvantrian.Columns(0).Width = 35
        dgvantrian.Columns(2).Width = 115
        dgvantrian.Columns(3).Width = 100
        dgvantrian.Columns(1).Visible = False
        objAlternatingCellStyle.BackColor = Color.AliceBlue
        dgvantrian.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvantrian.ReadOnly = True
    End Sub

    Sub refreshantrian()
        Dim strEdit As String = "UPDATE antrian SET nama = '" & TextBox2.Text.ToUpper & "',total = '" & Convert.ToDecimal(total) & "'" _
                              & " WHERE id_antrian = '" & TextBox8.Text & "'"
        query(strEdit)
        isigridantrian()
    End Sub


    Sub querytambahantrian()
        cmd = New MySqlCommand("SELECT * FROM antrian WHERE id_antrian = '" & TextBox8.Text & "'", konek)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            dr.Close()
            Dim strEdit As String = "UPDATE antrian SET nama = '" & TextBox2.Text.ToUpper & "',total = '" & Convert.ToDecimal(total) & "'" _
                              & " WHERE id_antrian = '" & TextBox8.Text & "'"
            query(strEdit)
        Else
            dr.Close()
            Dim strsimpan As String = "INSERT INTO antrian" _
                                & " VALUES ('" & TextBox8.Text & "','" & TextBox1.Text & "','" & TextBox2.Text & "','" & Convert.ToDecimal(total) & "')"
            query(strsimpan)
        End If
        isigridantrian()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim npilih As Integer
        npilih = MsgBox("Masukkan ke antrian ?", 48 + 4 + 256, "Konfirmasi")
        If npilih = 6 Then
            querytambahantrian()
            reset()
        End If

    End Sub

    Sub detailantrian()
        cmd = New MySqlCommand("SELECT * FROM antrian WHERE id_antrian = '" & dgvantrian.Item(0, dgvantrian.CurrentRow.Index).Value & "'", konek)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            TextBox8.Text = dr.GetString(0)
            TextBox1.Text = dr.GetString(1)
            TextBox2.Text = dr.GetString(2)
            dr.Close()
            isigridKeranjang()
        Else
            dr.Close()
        End If
    End Sub


    Private Sub dgvantrian_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvantrian.CellDoubleClick
        baru()
        detailantrian()
    End Sub
    Sub truncateantrian()
        Dim strhapus As String = "truncate table antrian;truncate table keranjang"
        query(strhapus)
        dgvantrian.DataSource = Nothing
        Label9.Text = "Total = Rp. 0"
        reset()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim npilih As Integer
        npilih = MsgBox("Bersihkan antrian ?", 48 + 4 + 256, "Konfirmasi")
        If npilih = 6 Then
            truncateantrian()
        End If
    End Sub

    Sub simpanpenjualandetail()
        Dim strsimpan As String = "INSERT INTO penjualan_detail (id_penjualan,id_obat,harga,qty)" _
                                & " SELECT '" & TextBox1.Text & "',id_obat,harga,qty FROM keranjang WHERE id_antrian = '" & TextBox8.Text & "'"
        query(strsimpan)
    End Sub

    Sub simpanpenjualan()
        Dim strsimpan As String = "INSERT INTO penjualan" _
                                & " VALUES ('" & TextBox1.Text & "','" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "')"
        query(strsimpan)
        MsgBox("Penjualan berhasil!")
    End Sub


    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim npilih As Integer
        npilih = MsgBox("Proses penjualan ?", 48 + 4 + 256, "Konfirmasi")
        If npilih = 6 Then
            simpanpenjualandetail()
            simpanpenjualan()
            batal()
        End If
    End Sub
End Class