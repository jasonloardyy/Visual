<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormUtama
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.DataMasterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataGolonganToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataKategoriToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataGolonganToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataKategoriToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataPenjualanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataSatuanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataSediaanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TransaksiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PenjualanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DataMasterToolStripMenuItem, Me.TransaksiToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1184, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'DataMasterToolStripMenuItem
        '
        Me.DataMasterToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DataGolonganToolStripMenuItem, Me.DataKategoriToolStripMenuItem})
        Me.DataMasterToolStripMenuItem.Name = "DataMasterToolStripMenuItem"
        Me.DataMasterToolStripMenuItem.Size = New System.Drawing.Size(82, 20)
        Me.DataMasterToolStripMenuItem.Text = "Data Master"
        '
        'DataGolonganToolStripMenuItem
        '
        Me.DataGolonganToolStripMenuItem.Name = "DataGolonganToolStripMenuItem"
        Me.DataGolonganToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.DataGolonganToolStripMenuItem.Text = "Data Obat"
        '
        'DataKategoriToolStripMenuItem
        '
        Me.DataKategoriToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DataGolonganToolStripMenuItem1, Me.DataKategoriToolStripMenuItem1, Me.DataPenjualanToolStripMenuItem, Me.DataSatuanToolStripMenuItem, Me.DataSediaanToolStripMenuItem})
        Me.DataKategoriToolStripMenuItem.Name = "DataKategoriToolStripMenuItem"
        Me.DataKategoriToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.DataKategoriToolStripMenuItem.Text = "Data Kecil"
        '
        'DataGolonganToolStripMenuItem1
        '
        Me.DataGolonganToolStripMenuItem1.Name = "DataGolonganToolStripMenuItem1"
        Me.DataGolonganToolStripMenuItem1.Size = New System.Drawing.Size(153, 22)
        Me.DataGolonganToolStripMenuItem1.Text = "Data Golongan"
        '
        'DataKategoriToolStripMenuItem1
        '
        Me.DataKategoriToolStripMenuItem1.Name = "DataKategoriToolStripMenuItem1"
        Me.DataKategoriToolStripMenuItem1.Size = New System.Drawing.Size(153, 22)
        Me.DataKategoriToolStripMenuItem1.Text = "Data Kategori"
        '
        'DataPenjualanToolStripMenuItem
        '
        Me.DataPenjualanToolStripMenuItem.Name = "DataPenjualanToolStripMenuItem"
        Me.DataPenjualanToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.DataPenjualanToolStripMenuItem.Text = "Data Produksi"
        '
        'DataSatuanToolStripMenuItem
        '
        Me.DataSatuanToolStripMenuItem.Name = "DataSatuanToolStripMenuItem"
        Me.DataSatuanToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.DataSatuanToolStripMenuItem.Text = "Data Satuan"
        '
        'DataSediaanToolStripMenuItem
        '
        Me.DataSediaanToolStripMenuItem.Name = "DataSediaanToolStripMenuItem"
        Me.DataSediaanToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.DataSediaanToolStripMenuItem.Text = "Data Sediaan"
        '
        'TransaksiToolStripMenuItem
        '
        Me.TransaksiToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PenjualanToolStripMenuItem})
        Me.TransaksiToolStripMenuItem.Name = "TransaksiToolStripMenuItem"
        Me.TransaksiToolStripMenuItem.Size = New System.Drawing.Size(67, 20)
        Me.TransaksiToolStripMenuItem.Text = "Transaksi"
        '
        'PenjualanToolStripMenuItem
        '
        Me.PenjualanToolStripMenuItem.Name = "PenjualanToolStripMenuItem"
        Me.PenjualanToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
        Me.PenjualanToolStripMenuItem.Text = "Penjualan"
        '
        'FormUtama
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1184, 561)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "FormUtama"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormUtama"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents DataMasterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataGolonganToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataKategoriToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TransaksiToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PenjualanToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataGolonganToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataKategoriToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataPenjualanToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataSatuanToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataSediaanToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
