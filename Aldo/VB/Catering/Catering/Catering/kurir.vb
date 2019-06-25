Imports MySql.Data.MySqlClient

Public Class kurir
    Public mode As String
    Public id_data As String
    Private Sub kurir_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call koneksi()
        Call isigrid()
        If dgv.RowCount > 0 Then
            Call judulgrid()
        End If
        Call Reset()
    End Sub

    Sub isigrid()
        Dim query As String = "select id_kurir,nama_kurir,status from tbkurir"
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
        dgv.Columns(1).HeaderText = "Nama Kurir"
        dgv.Columns(2).HeaderText = "Status Kurir"

        dgv.Columns(0).Visible = False
        dgv.Columns(1).Width = 120
        dgv.Columns(2).Width = 150

        objAlternatingCellStyle.BackColor = Color.AliceBlue
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub

    Sub querytambah()
        Dim strsimpan As String = "INSERT INTO tbkurir(nama_kurir,status)" _
                                & " VALUES ('" & TextBox1.Text & "','A')"
        simpandata(strsimpan)
        MsgBox("Berhasil menambahkan kurir!")
        isigrid()
    End Sub
    Sub queryedit()
        Dim strEdit As String = "UPDATE tbkurir SET nama_kurir = '" & TextBox1.Text & "'" _
                              & "WHERE id_kurir = '" & id_data & "'"
        editdata(strEdit)
        MsgBox("Berhasil mengubah data!")
        isigrid()
    End Sub

    Sub queryhapus()
        Dim strhapus As String = "DELETE FROM tbkurir WHERE id_kurir = '" & id_data & "'"
        HAPUSDATA(strhapus)
        isigrid()
        MsgBox("Berhasil menghapus data!")
    End Sub

    Sub GridToTextBox()
        dgv.Refresh()
        If dgv.RowCount > 0 Then
            Dim baris As Integer
            With dgv
                baris = .CurrentRow.Index
                id_data = .Item(0, baris).Value
                TextBox1.Text = .Item(1, baris).Value


            End With
        End If
    End Sub

    Sub reset()
        TextBox1.Enabled = False

        bersih()
        Button1.Enabled = True
        Button1.Text = "Tambah"
        Button3.Enabled = False
        Button2.Enabled = False
    End Sub

    Sub bersih()
        TextBox1.Text = ""

    End Sub

    Sub modesimpan()
        TextBox1.Enabled = True


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
            If TextBox1.Text = "" Then
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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        mode = "edit"
        modesimpan()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim nhps As Integer
        nhps = MsgBox("Yakin menghapus menu? " & TextBox1.Text & " ?", 48 + 4 + 256, "Konfirmasi")
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
End Class