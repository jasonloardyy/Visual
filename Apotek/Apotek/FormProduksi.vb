Imports MySql.Data.MySqlClient

Public Class FormProduksi

    Public mode As String
    Public id_data As String

    Private Sub FormKategori_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
        isigrid()
        reset()
    End Sub

    Sub isigrid()
        Dim query As String = "SELECT * FROM produksi"
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
        dgv.Columns(0).HeaderText = "ID Produksi"
        dgv.Columns(1).HeaderText = "Nama Produksi"
        dgv.Columns(0).Width = 100
        dgv.Columns(1).Width = 150
        objAlternatingCellStyle.BackColor = Color.AliceBlue
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgv.ReadOnly = True
    End Sub

    Sub querytambah()
        Dim strsimpan As String = "INSERT INTO produksi" _
                                & " VALUES ('" & TextBox1.Text.ToUpper & "','" & TextBox2.Text.ToUpper & "')"
        query(strsimpan)
        MsgBox("Berhasil tambah data!")
        isigrid()
    End Sub

    Sub queryedit()
        Dim strEdit As String = "UPDATE produksi SET id_produksi = '" & TextBox1.Text.ToUpper & "',nama_produksi = '" & TextBox2.Text.ToUpper & "' " _
                              & "WHERE id_produksi = '" & id_data & "'"
        query(strEdit)
        MsgBox("Berhasil edit data!")
        isigrid()
    End Sub

    Sub queryhapus()
        Dim strhapus As String = "DELETE FROM produksi WHERE id_produksi = '" & id_data & "'"
        query(strhapus)
        isigrid()
        MsgBox("Berhasil hapus data!")
    End Sub

    Sub reset()
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        bersih()
        Button1.Enabled = True
        Button1.Text = "Tambah"
        Button2.Enabled = False
        Button3.Enabled = False
    End Sub

    Sub bersih()
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub

    Sub tambah()
        cmd = New MySqlCommand("SELECT * FROM produksi WHERE id_produksi = '" & TextBox1.Text & "'", konek)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            dr.Close()
            MsgBox("ID Produksi sudah ada!", 16, "Informasi")
            TextBox1.Focus()
        Else
            dr.Close()
            querytambah()
        End If
    End Sub

    Sub edit()
        If id_data <> TextBox1.Text Then
            cmd = New MySqlCommand("SELECT * FROM produksi WHERE id_produksi = '" & TextBox1.Text & "'", konek)
            dr = cmd.ExecuteReader
            dr.Read()
            If dr.HasRows Then
                dr.Close()
                MsgBox("ID Produksi sudah ada!", 16, "Informasi")
                TextBox1.Focus()
            Else
                dr.Close()
                queryedit()
            End If
        Else
            queryedit()
        End If
    End Sub

    Sub GridToTextBox()
        dgv.Refresh()
        If dgv.RowCount > 0 Then
            Dim baris As Integer
            With dgv
                baris = .CurrentRow.Index
                id_data = .Item(0, baris).Value
                TextBox1.Text = .Item(0, baris).Value
                TextBox2.Text = .Item(1, baris).Value
            End With
        End If
    End Sub

    Sub modesimpan()
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        Button1.Enabled = True
        Button1.Text = "Simpan"
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = True
        TextBox1.Focus()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Button1.Text = "Tambah" Then
            mode = "tambah"
            modesimpan()
            bersih()
        Else
            If TextBox1.Text = "" Or TextBox2.Text = "" Then
                MsgBox("Lengkapi data yang kosong!", 16, "Informasi")
            Else
                If mode = "tambah" Then
                    tambah()
                    reset()
                Else
                    edit()
                    reset()
                End If
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        mode = "edit"
        modesimpan()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        reset()
    End Sub

    Private Sub dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellClick
        reset()
        GridToTextBox()
        Button1.Enabled = False
        Button2.Enabled = True
        Button3.Enabled = True
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim nhps As Integer
        nhps = MsgBox("Yakin hapus produksi " & TextBox2.Text & " ?", 48 + 4 + 256, "Konfirmasi")
        If nhps = 6 Then
            queryhapus()
            reset()
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Close()
    End Sub
End Class