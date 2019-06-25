Imports MySql.Data.MySqlClient

Public Class Form1
    Public mode As String
    Public id_data As String
    Public from As String
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call koneksi()
        Call isigrid()
        If dgv.RowCount > 0 Then
            Call judulgrid()
        End If
        Call reset()
    End Sub
    Sub isigrid()
        Dim query As String = "SELECT * FROM tb_menu"
        Dim da As New MySqlDataAdapter(query, konek)
        Dim ds As New DataSet()
        If da.Fill(ds) Then
            dgv.dataSource = ds.Tables(0)
            dgv.Refresh()
        End If
    End Sub
    Sub judulgrid()
        Dim objAlternatingCellStyle As New DataGridViewCellStyle()
        dgv.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle
        Dim style As DataGridViewCellStyle = dgv.Columns(0).DefaultCellStyle
        dgv.Columns(0).HeaderText = "ID MENU"
        dgv.Columns(1).HeaderText = "NAMA MENU"
        dgv.Columns(2).HeaderText = "HARGA MENU"
        dgv.Columns(0).Width = 100
        dgv.Columns(1).Width = 150
        dgv.Columns(2).Width = 120
        objAlternatingCellStyle.BackColor = Color.AliceBlue
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub


    Sub querytambah()
        Dim strsimpan As String = "INSERT INTO tb_menu(nama_menu,harga_menu)" _
                                & " VALUES('" & TextBox2.Text & "','" & TextBox3.Text & "')"
        simpandata(strsimpan)
        MsgBox("Berhasil tambah data!")
        isigrid()
    End Sub

    Sub queryedit()
        Dim strEdit As String = "UPDATE tb_menu SET nama_menu = '" & TextBox2.Text.ToUpper & "',harga_menu = '" & TextBox3.Text & "' " _
                              & "WHERE id_menu = '" & id_data & "'"
        editdata(strEdit)
        MsgBox("Berhasil edit data!")
        isigrid()
    End Sub

    Sub queryhapus()
        Dim strhapus As String = "DELETE FROM tb_menu WHERE id_menu = '" & id_data & "'"
        HAPUSDATA(strhapus)
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
                TextBox2.Text = .Item(1, baris).Value
                TextBox3.Text = .Item(2, baris).Value

            End With
        End If
    End Sub
    Sub reset()
        TextBox2.Enabled = False
        TextBox3.Enabled = False

        bersih()
        Button1.Enabled = True
        Button1.Text = "Tambah"
        Button3.Enabled = False
        Button2.Enabled = False
    End Sub

    Sub bersih()
        TextBox2.Text = ""
        TextBox3.Text = ""
    End Sub
    Sub modesimpan()
        TextBox2.Enabled = True
        TextBox3.Enabled = True

        Button1.Enabled = True
        Button1.Text = "Simpan"
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = True
        TextBox2.Focus()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Button1.Text = "Tambah" Then
            mode = "tambah"
            modesimpan()
            bersih()
        Else
            If TextBox2.Text = "" Or TextBox3.Text = "" Then
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
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        mode = "edit"
        modesimpan()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim nhps As Integer
        nhps = MsgBox("Yakin menghapus menu? " & TextBox2.Text & " ?", 48 + 4 + 256, "Konfirmasi")
        If nhps = 6 Then
            queryhapus()
            reset()
        End If
    End Sub

    Private Sub dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellClick
        reset()
        GridToTextBox()
        Button1.Enabled = False
        Button2.Enabled = True
        Button3.Enabled = True
    End Sub

    Private Sub dgv_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgv.CellMouseDoubleClick
        If from = "penjualan" Then
            Dim nhps As Integer
            nhps = MsgBox("Masukkan menu " & TextBox2.Text & " ?", 48 + 4 + 256, "Konfirmasi")
            If nhps = 6 Then
                Dim baris As Integer
                With dgv
                    baris = .CurrentRow.Index
                    Form2.id_menu = .Item(0, baris).Value
                    Form2.TextBox4.Text = .Item(1, baris).Value
                    Form2.TextBox3.Text = .Item(2, baris).Value
                End With
                Me.Close()
            End If
        End If
    End Sub
End Class
 


