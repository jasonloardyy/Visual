'Imports System.Data
Imports MySql.Data.MySqlClient

Public Class Form5
    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call koneksi()
        Call isipesawat()
        'Call isiidpilot()
        Call isigrid()
        Call ambilid()
        ComboBox1.Text = ""
        TextBox1.Text = ""
    End Sub
    Sub isipesawat()
        Dim qpes As String = "select * from pesawat"
        da = New MySqlDataAdapter(qpes, konek)
        Dim dt As New DataTable()
        Try
            da.Fill(dt)
            ComboBox1.DataSource = dt
            ComboBox1.ValueMember = "Id_Pesawat"
            ComboBox1.DisplayMember = "Nama"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub isigrid()
        Dim query As String = "SELECT * FROM pilot order by id_pilot desc"
        ' order by desc"
        Dim da As New MySqlDataAdapter(query, konek)
        Dim ds As New DataSet()
        If da.Fill(ds) Then
            DataGridView1.DataSource = ds.Tables(0)
            DataGridView1.Refresh()
        End If
    End Sub
    Sub ambilid()
        DataGridView1.Refresh()
        If DataGridView1.RowCount > 0 Then
            Dim baris As Integer
            baris = DataGridView1.CurrentRow.Index
            TextBox7.Text = DataGridView1.Item(0, baris).Value
        End If
    End Sub
    Sub isiidpilot()
        Dim nid As Integer = "select max(id_pilot) from pilot"

        'dr = cmd.ExecuteReader()
        'Do While dr.Read
        '    nid = dr!id_stok
        'Loop
        TextBox7.Text = nid
        'dr.Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        TextBox1.Text = ComboBox1.SelectedValue.ToString
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        cmd = New MySqlCommand("select * from pilot where nama = '" & TextBox2.Text & "'", konek)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            dr.Close()
            MsgBox("Nama Pilot sudah ada...!!!", 16, "Informasi")
            TextBox1.Focus()
        Else
            dr.Close()
            Dim strsimpan As String = "Insert Into pilot (nama,gaji) " _
                                 & "Values ('" & TextBox2.Text & "','" & TextBox3.Text & "')"
            Call simpandata(strsimpan)
            ' Call Form1.isigrid()
            'TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox2.Focus()

        End If
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox5.Text = DateAdd(DateInterval.Day, 3, DateTimePicker1.Value.Date)
        TextBox6.Text = DateDiff(DateInterval.Day, Now, DateTimePicker1.Value.Date)
    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged

    End Sub
End Class