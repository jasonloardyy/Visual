Imports MySql.Data.MySqlClient
Public Class Form2
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        cmd = New MySqlCommand("select * from pesawat where id_pesawat = '" & TextBox1.Text & "'", konek)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            dr.Close()
            MsgBox("ID Pesawat sudah ada...!!!", 16, "Informasi")
            TextBox1.Focus()
        Else
            dr.Close()
            Dim strsimpan As String = "Insert Into pesawat (id_pesawat,nama,jarak_jelajah) " _
                                 & "Values ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "')"
            Call simpandata(strsimpan)
            Call Form1.isigrid()
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox1.Focus()

        End If
    End Sub

    Private Sub Form2_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        '  Select Case e.KeyCode
        '     Case Keys.Enter
        ' TextBox2.Focus()
        ' End Select
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call koneksi()
    End Sub

    Private Sub TextBox2_LostFocus(sender As Object, e As EventArgs) Handles TextBox2.LostFocus

    End Sub

End Class