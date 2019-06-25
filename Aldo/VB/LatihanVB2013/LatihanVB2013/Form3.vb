Public Class Form3

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call koneksi()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim strEdit As String = "Update pesawat set nama = '" & TextBox2.Text & "',jarak_jelajah = '" & TextBox3.Text & "' " _
                              & "Where id_pesawat = '" & TextBox1.Text & "'"
        Call editdata(strEdit)
        Call Form1.isigrid()
        Dim nkur As Integer
        nkur = TextBox4.Text
        Form1.dgv.CurrentCell = Form1.dgv(Form1.dgv.CurrentCell.ColumnIndex, _
                                          Form1.dgv.CurrentCell.RowIndex + nkur)
        Me.Close()
    End Sub
End Class