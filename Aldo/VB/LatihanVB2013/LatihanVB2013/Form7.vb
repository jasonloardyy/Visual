Imports System.Threading
Imports System.Globalization
Imports System.Windows.Forms.DataVisualization.Charting

Public Class Form7

    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    'Sub grafik2()
    '    Dim myCmd As New MySqlCommand
    '    Dim myReder As MySqlDataReader
    '    myCmd.CommandText = "SELECT * from tblaba"
    '    myCmd = New MySqlCommand(myCmd.CommandText, konek)
    '    myReder = myCmd.ExecuteReader
    '    Try
    '        While myReder.Read
    '            With Chart1
    '                Dim Laba() As String = {"Laba Kotor", "Laba Bersih"}
    '                .Series.Clear()
    '                For i As Integer = 0 To 1
    '                    'naa series
    '                    .Series.Add(Laba(i))
    '                Next
    '                .ChartAreas(0).AxisX.Interval = 1
    '                .ChartAreas(0).AxisX.IsStartedFromZero = True
    '                ' .Series(0).Name = myReder.Item("LabaB").ToString

    '                .Series(0).Points.Clear()
    '                For Each seri As Series In .Series
    '                    seri.ChartType = SeriesChartType.Column
    '                    seri.XValueType = ChartValueType.String
    '                    seri.YValueType = ChartValueType.Double
    '                Next

    '                Do While myReder.Read
    '                    .Series(0).Points.AddXY(myReder.Item("Bulan").ToString,
    '                    myReder.Item("LabaK"))
    '                    ' .Series(0). = myReder.Item("LabaK").ToString
    '                    .Series(1).Points.AddXY(myReder.Item("Bulan").ToString,
    '                    myReder.Item("LabaB"))
    '                Loop
    '            End With
    '        End While
    '    Finally
    '    End Try
    'End Sub

End Class