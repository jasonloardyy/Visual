Imports MySql.Data.MySqlClient

Public Class Form2
    Public total As Integer
    Public id_menu As String
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Form1.from = "penjualan"
        Form1.Show()
    End Sub

    Sub gridkeranjang()
        refreshTotal()
        Dim query As String = "SELECT * FROM tb_keranjang WHERE no_meja = '" & TextBox1.Text & "'"
        Dim da As New MySqlDataAdapter(query, konek)
        Dim ds As New DataSet()
        If da.Fill(ds) Then
            dgvkeranjang.DataSource = ds.Tables(0)
            dgvkeranjang.Refresh()
        End If
        If dgvkeranjang.RowCount > 0 Then
            judulgridkeranjang()
        End If
    End Sub
    Sub judulgridkeranjang()
        Dim objAlternatingCellStyle As New DataGridViewCellStyle()
        dgvkeranjang.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle
        Dim style As DataGridViewCellStyle = dgvkeranjang.Columns(0).DefaultCellStyle
        dgvkeranjang.Columns(0).Visible = False
        dgvkeranjang.Columns(1).Visible = False
        dgvkeranjang.Columns(2).HeaderText = "NAMA MENU"
        dgvkeranjang.Columns(3).HeaderText = "HARGA MENU"
        dgvkeranjang.Columns(4).HeaderText = "QTY"
        dgvkeranjang.Columns(5).HeaderText = "SUBTOTAL"
        dgvkeranjang.Columns(0).Width = 100
        dgvkeranjang.Columns(1).Width = 150
        dgvkeranjang.Columns(2).Width = 120
        objAlternatingCellStyle.BackColor = Color.AliceBlue
        dgvkeranjang.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub

    Sub gridmeja()
        Dim query As String = "SELECT * FROM tb_meja"
        Dim da As New MySqlDataAdapter(query, konek)
        Dim ds As New DataSet()
        If da.Fill(ds) Then
            dgv.DataSource = ds.Tables(0)
            dgv.Refresh()
        End If
        If dgv.RowCount > 0 Then
            judulgridkeranjang()
        End If
    End Sub
    Sub judulgridmeja()
        Dim objAlternatingCellStyle As New DataGridViewCellStyle()
        dgv.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle
        Dim style As DataGridViewCellStyle = dgv.Columns(0).DefaultCellStyle
        dgv.Columns(0).HeaderText = "No. Meja"
        dgv.Columns(1).HeaderText = "Total"
        dgv.Columns(0).Width = 100
        dgv.Columns(1).Width = 150
        objAlternatingCellStyle.BackColor = Color.AliceBlue
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub

    Sub refreshTotal()
        cmd = New MySqlCommand("select coalesce(sum(subtotal),0) from tb_keranjang where no_meja = '" & TextBox1.Text & "'", konek)
        dr = cmd.ExecuteReader
        dr.Read()
        total = dr.GetString(0)
        dr.Close()
        Label7.Text = "Rp. " & FormatNumber(total, 0)
    End Sub


    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim subtotal As Integer = Convert.ToInt64(TextBox3.Text) * Convert.ToInt16(TextBox5.Text)
        Dim strsimpan As String = "INSERT INTO tb_keranjang" _
                                  & " SELECT '" & TextBox1.Text & "',id_menu,nama_menu,harga_menu,'" & Convert.ToInt16(TextBox5.Text) & "','" & subtotal & "' FROM tb_menu WHERE id_menu = '" & id_menu & "'"
        simpandata(strsimpan)
        TextBox4.Clear()
        TextBox3.Clear()
        TextBox5.Clear()
        gridkeranjang()
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim strsimpan As String = "INSERT INTO tb_meja" _
                                & " VALUES('" & TextBox1.Text & "','" & total & "')"
        simpandata(strsimpan)
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class