Imports System.Data
Imports MySql.Data.MySqlClient

Module Module1
    Public strkon As String = "server=localhost;user=root;database=jutar"
    Public konek As MySqlConnection = New MySqlConnection(strkon)
    Public da As MySqlDataAdapter
    Public ds As DataSet
    Public cmd As New MySqlCommand
    ' Public ds As DataSet
    Public dt As DataTable
    Public dr As MySqlDataReader

    Public Function koneksi() As Boolean
        Try
            If konek.State = ConnectionState.Closed Then
                konek.Open()
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox("Koneksi ke database bermasalah, Periksa koneksi jaringan...", 48, "Perhatian")
            Return False
        End Try
    End Function

    Sub simpandata(ByVal sqlisi As String)
        Try
            Call koneksi()
            ' Dim sqlquery As New Odbc.OdbcCommand
            Using cmd As New MySqlCommand
                cmd.CommandText = sqlisi
                cmd.Connection = konek
                cmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            MsgBox(ex.ToString(), 16, "Errorki")
        End Try
    End Sub
    Sub editdata(ByVal SQLEDIT As String)
        Try
            Call koneksi()
            Using cmd As New MySqlCommand
                cmd.Connection = konek
                cmd.CommandText = SQLEDIT
                cmd.ExecuteNonQuery()
                ' Call tampildata()
            End Using
        Catch ex As Exception
            MsgBox(ex.ToString(), 16, "Errorki")
            'MsgBox("Gagal mengupdate data", 16, "Errorki")
        End Try
    End Sub

    Sub HAPUSDATA(ByVal SQLHAPUS As String)
        Try
            Call koneksi()
            Using cmd As New MySqlCommand
                cmd.Connection = konek
                cmd.CommandText = SQLHAPUS
                cmd.ExecuteNonQuery()
                ' Call tampildata()
            End Using
        Catch ex As Exception
            MsgBox(ex.ToString(), 16, "Errorki")
        End Try
    End Sub
    Sub tampildata(ByVal sqldata As String, ByVal sqltabel As String)
        Try
            da = New MySqlDataAdapter(sqldata, konek)
            ds = New DataSet
            ds.Clear()
            da.Fill(ds, sqltabel)
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub
End Module
