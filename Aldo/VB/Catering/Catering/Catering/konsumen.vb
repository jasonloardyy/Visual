Imports MySql.Data.MySqlClient
Public Class konsumen
    Public from As String
    Public mode As String
    Public id_data As String
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        from = ""
        Call koneksi()
        Call isigrid()
        If dgv.RowCount > 0 Then
            Call judulgrid()
        End If
        Call reset()
    End Sub
    Sub isigrid()
        Dim query As String = "select id_konsumen,nama_konsumen,alamat,telepon, if(jenis_konsumen = 'I','Individu','Lembaga') from tbkonsumen"
        Dim da As New MySqlDataAdapter(query, konek)
        Dim ds As New DataSet()
        If da.Fill(ds) Then
            dgv.DataSource = ds.Tables(0)
            dgv.Refresh()
        End If
    End Sub
    Sub judulgrid()
        Dim objAlternatingCellStyle As New DataGridViewCellStyle()
        dgv.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle
        Dim style As DataGridViewCellStyle = dgv.Columns(0).DefaultCellStyle
        dgv.Columns(1).HeaderText = "Nama Pelanggan"
        dgv.Columns(2).HeaderText = "Alamat"
        dgv.Columns(3).HeaderText = "No.Telp"
        dgv.Columns(4).HeaderText = "Jenis Konsumen"

        dgv.Columns(0).Visible = False
        dgv.Columns(1).Width = 120
        dgv.Columns(2).Width = 150
        dgv.Columns(3).Width = 120
        dgv.Columns(4).Width = 120

        objAlternatingCellStyle.BackColor = Color.AliceBlue
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub



    Sub querytambah()
        Dim strsimpan As String = "INSERT INTO tbkonsumen(nama_konsumen,alamat,telepon,jenis_konsumen)" _
                                & " VALUES ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & ComboBox1.Text.Substring(0, 1) & "')"
        simpandata(strsimpan)
        MsgBox("Berhasil tambah data!")
        isigrid()
    End Sub
    Sub queryedit()
        Dim strEdit As String = "UPDATE tbkonsumen SET nama_konsumen = '" & TextBox1.Text & "',alamat = '" & TextBox2.Text & "',telepon = '" & TextBox3.Text & "',jenis_konsumen = '" & ComboBox1.Text.Substring(0, 1) & "' " _
                              & "WHERE id_konsumen = '" & id_data & "'"
        editdata(strEdit)
        MsgBox("Berhasil edit data!")
        isigrid()
    End Sub

    Sub queryhapus()
        Dim strhapus As String = "DELETE FROM tbkonsumen WHERE id_konsumen = '" & id_data & "'"
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
                TextBox1.Text = .Item(1, baris).Value
                TextBox2.Text = .Item(2, baris).Value
                TextBox3.Text = .Item(3, baris).Value
                ComboBox1.Text = .Item(4, baris).Value
            End With
        End If
    End Sub

    Sub reset()
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        ComboBox1.Enabled = False
        bersih()
        Button1.Enabled = True
        Button1.Text = "Tambah"
        Button3.Enabled = False
        Button2.Enabled = False
    End Sub

    Sub bersih()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        ComboBox1.SelectedIndex = -1
    End Sub

    Sub modesimpan()
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        ComboBox1.Enabled = True
        Button1.Enabled = True
        Button1.Text = "Simpan"
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = True
        TextBox1.Focus()
    End Sub


    Private Sub btntambah_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Button1.Text = "Tambah" Then
            mode = "tambah"
            modesimpan()
            bersih()
        Else
            If TextBox1.Text = "" Or TextBox2.Text = "" Then
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
        nhps = MsgBox("Yakin hapus data " & TextBox2.Text & " ?", 48 + 4 + 256, "Konfirmasi")
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

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        reset()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Close()
    End Sub

    Private Sub dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellDoubleClick
        If from = "trx" Then
            Dim nhps As Integer
            Dim baris As Integer

            baris = dgv.CurrentRow.Index
            nhps = MsgBox("Masukkan konsumen  " & dgv.Item(1, baris).Value & " ?", 48 + 4 + 256, "Konfirmasi")
            If nhps = 6 Then
                With dgv
                    Formtransaksi.idkonsumen.Text = .Item(0, baris).Value
                    Formtransaksi.tbnama.Text = .Item(1, baris).Value
                    Formtransaksi.alamat.Text = .Item(2, baris).Value
                    Formtransaksi.nohp.Text = .Item(3, baris).Value
                End With
                Me.Close()
            End If


        End If
    End Sub

End Class
