Imports MySql.Data.MySqlClient

Public Class Form6
    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call koneksi()
        grafik1()
    End Sub
    Sub grafik()
        Try
            Dim str As String = "SELECT * from tblaba"
            da = New MySqlDataAdapter(str, konek)
            Dim dt As New DataTable()
            da.Fill(dt)
            Chart1.BackGradientStyle = DataVisualization.Charting.GradientStyle.HorizontalCenter
            Chart1.Series("GPM").XValueMember = "Bulan"
            Chart1.Series(0).YValueMembers = "LabaK"
            Chart1.Series(1).YValueMembers = "LabaB"
            Chart1.DataSource = dt

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub grafik1()
        Try
            Dim str As String = "SELECT * from tblaba"
            da = New MySqlDataAdapter(str, konek)
            'Dim dt As New DataTable()
            Dim ds As New DataSet
            'da.Fill(dt)
            da.Fill(ds, "grafik")
            Chart1.Series("GPM").XValueMember = "Bulan"
            Chart1.Series(0).YValueMembers = "LabaK"
            Chart1.Series(1).YValueMembers = "LabaB"
            'Chart1.DataSource = dt
            Chart1.DataSource = ds.Tables("grafik")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call koneksi()
        grafik()

    End Sub
End Class