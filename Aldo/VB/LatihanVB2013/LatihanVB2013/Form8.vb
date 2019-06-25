Public Class Form8

    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Button1.Text = "Tambah" Then
            Button1.Text = "Simpan"
            Button2.Text = "Batal"
            Button3.Enabled = False
        Else
            If TextBox1.Text = "" Then
                MsgBox("Tambah Data")
            Else
                MsgBox("Edit Data")
            End If

        End If


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Button2.Text = "Edit" Then
            Button1.Text = "Simpan"
            Button2.Text = "Batal"
            Button3.Enabled = False
            TextBox1.Text = "E"
        Else
            Button1.Text = "Tambah"
            Button2.Text = "Edit"
            Button3.Enabled = True
            TextBox1.Text = ""
        End If



    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Form9.Show()
    End Sub
End Class