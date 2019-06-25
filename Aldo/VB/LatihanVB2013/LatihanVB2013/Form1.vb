Imports MySql.Data.MySqlClient

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call koneksi()
        Call isigrid()
        Call judulgrid()
    End Sub

    Sub isigrid()
        Dim query As String = "SELECT * FROM pesawat"
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
        dgv.Columns(0).HeaderText = "ID. Pesawat"
        dgv.Columns(1).HeaderText = "Nama Pesawat"
        dgv.Columns(2).HeaderText = "Jarak Jelajah"
        dgv.Columns(0).Width = 100
        dgv.Columns(1).Width = 150
        dgv.Columns(2).Width = 120
        objAlternatingCellStyle.BackColor = Color.AliceBlue
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub
    Sub GridToTextBox()
        dgv.Refresh()
        If dgv.RowCount > 0 Then
            Dim baris As Integer
            With dgv
                baris = .CurrentRow.Index
                Form3.TextBox4.Text = .CurrentRow.Index
                Form3.TextBox1.Text = .Item(0, baris).Value
                Form3.TextBox2.Text = .Item(1, baris).Value
                Form3.TextBox3.Text = .Item(2, baris).Value
            End With
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim psn As Integer
        psn = MsgBox("Yakin menutup aplikasi ...!!!", 48 + 4 + 256, "Tututp Aplilasi")
        If psn = 6 Then
            Me.Close()
        End If

    End Sub

    Sub seleksi()
        Dim strtext As String = "SELECT * From pesawat WHERE nama like '%" & TextBox1.Text & "%'"
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
        Call seleksi()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form2.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Call GridToTextBox()
        Form3.Show()
    End Sub

    Private Sub dgv_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellEnter
        dgv.Refresh()
        Dim baris As Integer
        baris = dgv.CurrentRow.Index
        TextBox3.Text = dgv.CurrentRow.Index
        TextBox2.Text = dgv.Item(0, baris).Value

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim nhps As Integer
        nhps = MsgBox("Yakin data akan di hapus... ?", 48 + 4 + 256, "Hapus Data...")
        If nhps = 6 Then
            Dim strhapus As String = "Delete from pesawat Where id_pesawat = '" & TextBox2.Text & "'"
            Call HAPUSDATA(strhapus)
            Call isigrid()
        End If
    End Sub

End Class
