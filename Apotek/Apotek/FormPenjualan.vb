Imports MySql.Data.MySqlClient

Public Class FormPenjualan

    Public no As Integer
    Private Sub FormPenjualan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
        no_antrian()
        TextBox1.Text = "TRX" & CLng(DateTime.UtcNow.Subtract(New DateTime(1970, 1, 1)).TotalSeconds)
        isigridKeranjang()
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
        dgvkeranjang.Columns(0).Visible = False
        dgvkeranjang.Columns(1).Visible = False
        objAlternatingCellStyle.BackColor = Color.AliceBlue
        dgvkeranjang.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvkeranjang.ReadOnly = True
    End Sub

    Sub no_antrian()
        cmd = New MySqlCommand("select * from antrian", konek)
        dr = cmd.ExecuteReader
        dr.Read()
        If Not dr.HasRows Then
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

    Sub ToKeranjang()
        no_urutkeranjang()
        Dim subtotal As Decimal = Convert.ToDecimal(TextBox6.Text) * Convert.ToDecimal(TextBox7.Text)
        Dim strsimpan As String = "INSERT INTO keranjang" _
                                & " VALUES ('" & TextBox8.Text & "','" & no & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox6.Text & "','" & TextBox7.Text & "','" & subtotal & "')"
        query(strsimpan)
        isigridKeranjang()
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
        Else
            ToKeranjang()
        End If
    End Sub

    Sub querytruncatekeranjang()
        Dim strreset As String = "TRUNCATE TABLE keranjang"
        query(strreset)
        dgvkeranjang.DataSource = Nothing
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim npilih As Integer
        npilih = MsgBox("Reset keranjang ?", 48 + 4 + 256, "Konfirmasi")
        If npilih = 6 Then
            querytruncatekeranjang()
        End If
    End Sub
End Class