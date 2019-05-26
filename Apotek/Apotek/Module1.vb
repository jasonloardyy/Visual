Imports System.Data
Imports MySql.Data.MySqlClient

Module Module1
    Public strkon As String = "server=localhost;user=root;database=apotek;Convert Zero Datetime=True"
    Public konek As MySqlConnection = New MySqlConnection(strkon)
    Public da As MySqlDataAdapter
    Public ds As DataSet
    Public cmd As New MySqlCommand
    Public dt As DataTable
    Public dr As MySqlDataReader
    Public dtgl As String
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
    Sub query(ByVal query As String)
        Try
            Call koneksi()
            Using cmd As New MySqlCommand
                cmd.CommandText = query
                cmd.Connection = konek
                cmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            MsgBox(ex.ToString(), 16, "Errorki")
        End Try
    End Sub

    Function querycb(ByVal query As String)
        da = New MySqlDataAdapter(query, konek)
        Dim dt As New DataTable()
        da.Fill(dt)
        Return dt
    End Function


End Module
