Imports MySql.Data.MySqlClient

Public Class FormCtkReport
    Public id_data As String
    Public cari As String

    Private Sub FormCtkReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        isigridpenj()
    End Sub
    Sub isigridpenj()
        Dim query As String = "SELECT * FROM penjualan WHERE id_penjualan LIKE '%" & cari & "%' ORDER BY tanggal DESC"
        Dim da As New MySqlDataAdapter(query, konek)
        Dim ds As New DataSet()
        If da.Fill(ds) Then
            dgvpenjualan.DataSource = ds.Tables(0)
            dgvpenjualan.Refresh()
        End If
        If dgvpenjualan.RowCount > 0 Then
            judulgridpenj()
        End If
    End Sub

    Sub judulgridpenj()
        Dim objAlternatingCellStyle As New DataGridViewCellStyle()
        dgvpenjualan.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle
        Dim style As DataGridViewCellStyle = dgvpenjualan.Columns(0).DefaultCellStyle
        dgvpenjualan.Columns(0).HeaderText = "ID Penjualan"
        dgvpenjualan.Columns(1).HeaderText = "Tanggal"
        dgvpenjualan.Columns(0).Width = 100
        dgvpenjualan.Columns(1).Width = 75
        objAlternatingCellStyle.BackColor = Color.AliceBlue
        dgvpenjualan.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvpenjualan.ReadOnly = True
    End Sub

    Sub isigriddetail()
        Dim query As String = "SELECT pj.id_obat,o.nama_obat,pj.harga,pj.qty,pj.harga*pj.qty FROM penjualan_detail pj JOIN obat o ON pj.id_obat=o.id_obat WHERE id_penjualan='" & id_data & "'"
        Dim da As New MySqlDataAdapter(query, konek)
        Dim ds As New DataSet()
        If da.Fill(ds) Then
            dgvdetail.DataSource = ds.Tables(0)
            dgvdetail.Refresh()
        End If
        If dgvpenjualan.RowCount > 0 Then
            judulgriddetail()
        End If
    End Sub

    Sub judulgriddetail()
        Dim objAlternatingCellStyle As New DataGridViewCellStyle()
        dgvdetail.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle
        Dim style As DataGridViewCellStyle = dgvdetail.Columns(0).DefaultCellStyle
        dgvdetail.Columns(0).HeaderText = "ID Obat"
        dgvdetail.Columns(1).HeaderText = "Nama Obat"
        dgvdetail.Columns(2).HeaderText = "Harga"
        dgvdetail.Columns(3).HeaderText = "Qty"
        dgvdetail.Columns(4).HeaderText = "Subtotal"
        dgvdetail.Columns(0).Width = 75
        dgvdetail.Columns(1).Width = 150
        dgvdetail.Columns(2).Width = 75
        dgvdetail.Columns(3).Width = 50
        dgvdetail.Columns(4).Width = 75

        objAlternatingCellStyle.BackColor = Color.AliceBlue
        dgvdetail.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvdetail.ReadOnly = True
    End Sub
    Sub hitunggrandtotal()
        Dim total As Integer
        For index As Integer = 0 To dgvdetail.RowCount - 1
            total += Convert.ToInt32(dgvdetail.Rows(index).Cells(4).Value)
        Next
        Label3.Text = "Grand Total = Rp. " & FormatNumber(total, 0)
    End Sub


    Sub isidetail()
        dgvpenjualan.Refresh()
        If dgvpenjualan.RowCount > 0 Then
            Dim baris As Integer
            With dgvpenjualan
                baris = .CurrentRow.Index
                id_data = .Item(0, baris).Value
                Label2.Text = "ID Penjualan : " & .Item(0, baris).Value
                isigriddetail()
                hitunggrandtotal()
            End With
        End If
    End Sub

    Private Sub dgvpenjualan_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvpenjualan.CellEnter
        isidetail()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        cari = TextBox1.Text
        isigridpenj()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim baris As Integer = dgvpenjualan.CurrentRow.Index
        Dim cno As String = dgvpenjualan.Item(0, baris).Value
        FormViewReport.CRNota1.RecordSelectionFormula = "{penjualan1.id_penjualan} = '" & cno & "'"
        FormViewReport.CRNota1.Refresh()
        FormViewReport.Show()
    End Sub
End Class