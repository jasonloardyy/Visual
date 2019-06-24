Imports MySql.Data.MySqlClient

Public Class FormGrafik
    Sub grafik_penjualan_harian()
        Label1.Text = "Grafik Penjualan Harian"
        Label2.Text = "Periode : " & FormCtkGrafikPeriode.DateTimePicker1.Text
        Dim cmd As New SqlClient.SqlCommand
        konek.Open()
        Dim sql As String = "SELECT p.id_penjualan,(SELECT sum(harga*qty) from penjualan_detail" & _
                            " WHERE id_penjualan = p.id_penjualan) as nominal FROM penjualan p" & _
                            " WHERE p.tanggal = '" & Format(FormCtkGrafikPeriode.DateTimePicker1.Value, "yyyy-MM-dd") & "'"
        Dim da As New MySqlDataAdapter(sql, konek)
        Dim ds As New DataSet
        da.Fill(ds, "grafik")
        Chart1.Series("Ket").XValueMember = "id_penjualan"
        Chart1.Series("Ket").YValueMembers = "nominal"
        Chart1.DataSource = ds.Tables("grafik")
        konek.Close()
    End Sub

    Sub grafik_penjualan_periode_harian()
        Label1.Text = "Grafik Penjualan Periode Harian"
        Label2.Text = "Periode : " & FormCtkGrafikPeriode.DateTimePicker2.Text & " - " & FormCtkGrafikPeriode.DateTimePicker3.Text
        Dim cmd As New SqlClient.SqlCommand
        konek.Open()
        Dim sql As String = "SELECT p.tanggal,sum(pd.harga*pd.qty) as nominal FROM penjualan p" & _
                            " join penjualan_detail pd on p.id_penjualan=pd.id_penjualan" & _
                            " where p.tanggal BETWEEN '" & Format(FormCtkGrafikPeriode.DateTimePicker2.Value, "yyyy-MM-dd") & _
                            "' and '" & Format(FormCtkGrafikPeriode.DateTimePicker3.Value, "yyyy-MM-dd") & "' group by tanggal"
        Dim da As New MySqlDataAdapter(sql, konek)
        Dim ds As New DataSet
        da.Fill(ds, "grafik")
        Chart1.Series("Ket").XValueMember = "tanggal"
        Chart1.Series("Ket").YValueMembers = "nominal"
        Chart1.DataSource = ds.Tables("grafik")
        konek.Close()
    End Sub

    Sub grafik_penjualan_bulanan()
        Label1.Text = "Grafik Penjualan Bulanan"
        Label2.Text = "Periode : " & FormCtkGrafikPeriode.ComboBox1.Text & " " & FormCtkGrafikPeriode.ComboBox2.Text
        Dim cmd As New SqlClient.SqlCommand
        konek.Open()
        Dim sql As String = "SELECT p.tanggal,sum(pd.harga*pd.qty) as nominal FROM penjualan p" & _
                            " join penjualan_detail pd on p.id_penjualan=pd.id_penjualan" & _
                            " where year(tanggal) = '" & FormCtkGrafikPeriode.ComboBox2.SelectedValue & _
                            "' and month(tanggal) = '" & FormCtkGrafikPeriode.ComboBox1.SelectedValue & _
                            "' group by tanggal"
        Dim da As New MySqlDataAdapter(sql, konek)
        Dim ds As New DataSet
        da.Fill(ds, "grafik")
        Chart1.Series("Ket").XValueMember = "tanggal"
        Chart1.Series("Ket").YValueMembers = "nominal"
        Chart1.DataSource = ds.Tables("grafik")
        konek.Close()
    End Sub

    Sub grafik_penjualan_tahunan()
        Label1.Text = "Grafik Penjualan Tahunan"
        Label2.Text = "Periode : " & FormCtkGrafikPeriode.ComboBox3.Text
        Dim cmd As New SqlClient.SqlCommand
        konek.Open()
        Dim sql As String = "SELECT monthname(p.tanggal) as bulan,sum(pd.harga*pd.qty) as nominal FROM penjualan p" & _
                            " join penjualan_detail pd on p.id_penjualan=pd.id_penjualan" & _
                            " where year(tanggal) = '" & FormCtkGrafikPeriode.ComboBox3.SelectedValue & _
                            "' group by month(tanggal)"
        Dim da As New MySqlDataAdapter(sql, konek)
        Dim ds As New DataSet
        da.Fill(ds, "grafik")
        Chart1.Series("Ket").XValueMember = "bulan"
        Chart1.Series("Ket").YValueMembers = "nominal"
        Chart1.DataSource = ds.Tables("grafik")
        konek.Close()
    End Sub

    Sub grafik_penjualan_harian_obat()
        Label1.Text = "Grafik Penjualan Harian 5 Obat Terlaku"
        Label2.Text = "Periode : " & FormCtkGrafikPeriode.DateTimePicker1.Text
        Dim cmd As New SqlClient.SqlCommand
        konek.Open()
        Dim sql As String = "select o.nama_obat,sum(pd.qty) as qty from penjualan p" & _
                            " join penjualan_detail pd on p.id_penjualan = pd.id_penjualan" & _
                            " join obat o on pd.id_obat = o.id_obat" & _
                            " where p.tanggal = '" & Format(FormCtkGrafikPeriode.DateTimePicker1.Value, "yyyy-MM-dd") & "'" & _
                            " GROUP by pd.id_obat order by qty desc limit 5"
        Dim da As New MySqlDataAdapter(sql, konek)
        Dim ds As New DataSet
        da.Fill(ds, "grafik")
        Chart1.Series("Ket").XValueMember = "nama_obat"
        Chart1.Series("Ket").YValueMembers = "qty"
        Chart1.DataSource = ds.Tables("grafik")
        konek.Close()
    End Sub

    Sub grafik_penjualan_harian_gol_obat()
        Label1.Text = "Grafik Penjualan Harian Golongan Obat"
        Label2.Text = "Periode : " & FormCtkGrafikPeriode.DateTimePicker1.Text
        Dim cmd As New SqlClient.SqlCommand
        konek.Open()
        Dim sql As String = "select g.nama_golongan,sum(pd.qty) as qty from penjualan p" & _
                            " join penjualan_detail pd on p.id_penjualan = pd.id_penjualan" & _
                            " join obat o on pd.id_obat = o.id_obat" & _
                            " join golongan g on o.id_golongan = g.id_golongan" & _
                            " where p.tanggal = '" & Format(FormCtkGrafikPeriode.DateTimePicker1.Value, "yyyy-MM-dd") & "'" & _
                            " GROUP by g.id_golongan"
        Dim da As New MySqlDataAdapter(sql, konek)
        Dim ds As New DataSet
        da.Fill(ds, "grafik")
        Chart1.Series("Ket").XValueMember = "nama_golongan"
        Chart1.Series("Ket").YValueMembers = "qty"
        Chart1.DataSource = ds.Tables("grafik")
        konek.Close()
    End Sub

    Sub grafik_penjualan_harian_pro_obat()
        Label1.Text = "Grafik Penjualan Harian Produksi Obat"
        Label2.Text = "Periode : " & FormCtkGrafikPeriode.DateTimePicker1.Text
        Dim cmd As New SqlClient.SqlCommand
        konek.Open()
        Dim sql As String = "select pro.nama_produksi,sum(pd.qty) as qty from penjualan p" & _
                            " join penjualan_detail pd on p.id_penjualan = pd.id_penjualan" & _
                            " join obat o on pd.id_obat = o.id_obat" & _
                            " join produksi pro on o.id_produksi = pro.id_produksi" & _
                            " where p.tanggal = '" & Format(FormCtkGrafikPeriode.DateTimePicker1.Value, "yyyy-MM-dd") & "'" & _
                            " GROUP by pro.id_produksi"
        Dim da As New MySqlDataAdapter(sql, konek)
        Dim ds As New DataSet
        da.Fill(ds, "grafik")
        Chart1.Series("Ket").XValueMember = "nama_produksi"
        Chart1.Series("Ket").YValueMembers = "qty"
        Chart1.DataSource = ds.Tables("grafik")
        konek.Close()
    End Sub

    Sub grafik_penjualan_harian_gol_obat_all()
        Label1.Text = "Grafik Penjualan Harian Berdasarkan Golongan Obat"
        Label2.Text = "Periode : " & FormCtkGrafikPeriode.DateTimePicker1.Text
        Dim cmd As New SqlClient.SqlCommand
        konek.Open()
        Dim sql As String = "select o.nama_obat,sum(pd.qty) as qty from penjualan p" & _
                            " join penjualan_detail pd on p.id_penjualan = pd.id_penjualan" & _
                            " join obat o on pd.id_obat = o.id_obat" & _
                            " join golongan g on o.id_golongan = g.id_golongan" & _
                            " where g.id_golongan = '" & FormCtkGrafikPeriode.ComboBox4.SelectedValue & "' and p.tanggal = '" & Format(FormCtkGrafikPeriode.DateTimePicker1.Value, "yyyy-MM-dd") & "'" & _
                            " GROUP by pd.id_obat"
        Dim da As New MySqlDataAdapter(sql, konek)
        Dim ds As New DataSet
        da.Fill(ds, "grafik")
        Chart1.Series("Ket").XValueMember = "nama_obat"
        Chart1.Series("Ket").YValueMembers = "qty"
        Chart1.DataSource = ds.Tables("grafik")
        konek.Close()
    End Sub

    Sub grafik_penjualan_harian_pro_obat_all()
        Label1.Text = "Grafik Penjualan Harian Berdasarkan Produksi Obat"
        Label2.Text = "Periode : " & FormCtkGrafikPeriode.DateTimePicker1.Text
        Dim cmd As New SqlClient.SqlCommand
        konek.Open()
        Dim sql As String = "select o.nama_obat,sum(pd.qty) as qty from penjualan p" & _
                            " join penjualan_detail pd on p.id_penjualan = pd.id_penjualan" & _
                            " join obat o on pd.id_obat = o.id_obat" & _
                            " join produksi pro on o.id_produksi = pro.id_produksi" & _
                            " where pro.id_produksi = '" & FormCtkGrafikPeriode.ComboBox5.SelectedValue & "' and p.tanggal = '" & Format(FormCtkGrafikPeriode.DateTimePicker1.Value, "yyyy-MM-dd") & "'" & _
                            " GROUP by pd.id_obat"
        Dim da As New MySqlDataAdapter(sql, konek)
        Dim ds As New DataSet
        da.Fill(ds, "grafik")
        Chart1.Series("Ket").XValueMember = "nama_obat"
        Chart1.Series("Ket").YValueMembers = "qty"
        Chart1.DataSource = ds.Tables("grafik")
        konek.Close()
    End Sub

    Sub grafik_penjualan_periode_harian_obat()
        Label1.Text = "Grafik Penjualan Periode Harian 5 Obat Terlaku"
        Label2.Text = "Periode : " & FormCtkGrafikPeriode.DateTimePicker2.Text & " - " & FormCtkGrafikPeriode.DateTimePicker3.Text
        Dim cmd As New SqlClient.SqlCommand
        konek.Open()
        Dim sql As String = "select o.nama_obat,sum(pd.qty) as qty from penjualan p" & _
                            " join penjualan_detail pd on p.id_penjualan = pd.id_penjualan" & _
                            " join obat o on pd.id_obat = o.id_obat" & _
                            " where p.tanggal between '" & Format(FormCtkGrafikPeriode.DateTimePicker2.Value, "yyyy-MM-dd") & "'" & _
                            " and '" & Format(FormCtkGrafikPeriode.DateTimePicker3.Value, "yyyy-MM-dd") & "'" & _
                            " GROUP by pd.id_obat order by qty desc limit 5"
        Dim da As New MySqlDataAdapter(sql, konek)
        Dim ds As New DataSet
        da.Fill(ds, "grafik")
        Chart1.Series("Ket").XValueMember = "nama_obat"
        Chart1.Series("Ket").YValueMembers = "qty"
        Chart1.DataSource = ds.Tables("grafik")
        konek.Close()
    End Sub

    Sub grafik_penjualan_periode_harian_gol_obat()
        Label1.Text = "Grafik Penjualan Harian Golongan Obat"
        Label2.Text = "Periode : " & FormCtkGrafikPeriode.DateTimePicker2.Text & " - " & FormCtkGrafikPeriode.DateTimePicker3.Text
        Dim cmd As New SqlClient.SqlCommand
        konek.Open()
        Dim sql As String = "select g.nama_golongan,sum(pd.qty) as qty from penjualan p" & _
                            " join penjualan_detail pd on p.id_penjualan = pd.id_penjualan" & _
                            " join obat o on pd.id_obat = o.id_obat" & _
                            " join golongan g on o.id_golongan = g.id_golongan" & _
                            " where p.tanggal between '" & Format(FormCtkGrafikPeriode.DateTimePicker2.Value, "yyyy-MM-dd") & "'" & _
                            " and '" & Format(FormCtkGrafikPeriode.DateTimePicker3.Value, "yyyy-MM-dd") & "'" & _
                            " GROUP by g.id_golongan"
        Dim da As New MySqlDataAdapter(sql, konek)
        Dim ds As New DataSet
        da.Fill(ds, "grafik")
        Chart1.Series("Ket").XValueMember = "nama_golongan"
        Chart1.Series("Ket").YValueMembers = "qty"
        Chart1.DataSource = ds.Tables("grafik")
        konek.Close()
    End Sub

    Sub grafik_penjualan_periode_harian_pro_obat()
        Label1.Text = "Grafik Penjualan Periode Harian Produksi Obat"
        Label2.Text = "Periode : " & FormCtkGrafikPeriode.DateTimePicker2.Text & " - " & FormCtkGrafikPeriode.DateTimePicker3.Text
        Dim cmd As New SqlClient.SqlCommand
        konek.Open()
        Dim sql As String = "select pro.nama_produksi,sum(pd.qty) as qty from penjualan p" & _
                            " join penjualan_detail pd on p.id_penjualan = pd.id_penjualan" & _
                            " join obat o on pd.id_obat = o.id_obat" & _
                            " join produksi pro on o.id_produksi = pro.id_produksi" & _
                            " where p.tanggal between '" & Format(FormCtkGrafikPeriode.DateTimePicker2.Value, "yyyy-MM-dd") & "'" & _
                            " and '" & Format(FormCtkGrafikPeriode.DateTimePicker3.Value, "yyyy-MM-dd") & "'" & _
                            " GROUP by pro.id_produksi"
        Dim da As New MySqlDataAdapter(sql, konek)
        Dim ds As New DataSet
        da.Fill(ds, "grafik")
        Chart1.Series("Ket").XValueMember = "nama_produksi"
        Chart1.Series("Ket").YValueMembers = "qty"
        Chart1.DataSource = ds.Tables("grafik")
        konek.Close()
    End Sub

    Sub grafik_penjualan_periode_harian_gol_obat_all()
        Label1.Text = "Grafik Penjualan Periode Harian Berdasarkan Golongan Obat"
        Label2.Text = "Periode : " & FormCtkGrafikPeriode.DateTimePicker2.Text & " - " & FormCtkGrafikPeriode.DateTimePicker3.Text
        Dim cmd As New SqlClient.SqlCommand
        konek.Open()
        Dim sql As String = "select o.nama_obat,sum(pd.qty) as qty from penjualan p" & _
                            " join penjualan_detail pd on p.id_penjualan = pd.id_penjualan" & _
                            " join obat o on pd.id_obat = o.id_obat" & _
                            " join golongan g on o.id_golongan = g.id_golongan" & _
                            " where g.id_golongan = '" & FormCtkGrafikPeriode.ComboBox4.SelectedValue & "' and p.tanggal between '" & Format(FormCtkGrafikPeriode.DateTimePicker2.Value, "yyyy-MM-dd") & "'" & _
                            " and '" & Format(FormCtkGrafikPeriode.DateTimePicker3.Value, "yyyy-MM-dd") & "'" & _
                            " GROUP by pd.id_obat"
        Dim da As New MySqlDataAdapter(sql, konek)
        Dim ds As New DataSet
        da.Fill(ds, "grafik")
        Chart1.Series("Ket").XValueMember = "nama_obat"
        Chart1.Series("Ket").YValueMembers = "qty"
        Chart1.DataSource = ds.Tables("grafik")
        konek.Close()
    End Sub

    Sub grafik_penjualan_periode_harian_pro_obat_all()
        Label1.Text = "Grafik Penjualan Periode Harian Berdasarkan Produksi Obat"
        Label2.Text = "Periode : " & FormCtkGrafikPeriode.DateTimePicker2.Text & " - " & FormCtkGrafikPeriode.DateTimePicker3.Text
        Dim cmd As New SqlClient.SqlCommand
        konek.Open()
        Dim sql As String = "select o.nama_obat,sum(pd.qty) as qty from penjualan p" & _
                            " join penjualan_detail pd on p.id_penjualan = pd.id_penjualan" & _
                            " join obat o on pd.id_obat = o.id_obat" & _
                            " join produksi pro on o.id_produksi = pro.id_produksi" & _
                            " where pro.id_produksi = '" & FormCtkGrafikPeriode.ComboBox5.SelectedValue & "' and p.tanggal between '" & Format(FormCtkGrafikPeriode.DateTimePicker2.Value, "yyyy-MM-dd") & "'" & _
                            " and '" & Format(FormCtkGrafikPeriode.DateTimePicker3.Value, "yyyy-MM-dd") & "'" & _
                            " GROUP by pd.id_obat"
        Dim da As New MySqlDataAdapter(sql, konek)
        Dim ds As New DataSet
        da.Fill(ds, "grafik")
        Chart1.Series("Ket").XValueMember = "nama_obat"
        Chart1.Series("Ket").YValueMembers = "qty"
        Chart1.DataSource = ds.Tables("grafik")
        konek.Close()
    End Sub
End Class