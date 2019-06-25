<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPaket
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
        Me.dgvpaket = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnhapuspaket = New System.Windows.Forms.Button()
        Me.btntambahpaket = New System.Windows.Forms.Button()
        Me.tbhargapaket = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbnamapaket = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.idpaket = New System.Windows.Forms.TextBox()
        Me.idmakanan = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnhapus = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dgvmakanan = New System.Windows.Forms.DataGridView()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.btntambah = New System.Windows.Forms.Button()
        Me.btncari = New System.Windows.Forms.Button()
        CType(Me.dgvpaket, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvmakanan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvpaket
        '
        Me.dgvpaket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvpaket.Location = New System.Drawing.Point(6, 97)
        Me.dgvpaket.Name = "dgvpaket"
        Me.dgvpaket.Size = New System.Drawing.Size(240, 247)
        Me.dgvpaket.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnhapuspaket)
        Me.GroupBox1.Controls.Add(Me.btntambahpaket)
        Me.GroupBox1.Controls.Add(Me.dgvpaket)
        Me.GroupBox1.Controls.Add(Me.tbhargapaket)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.tbnamapaket)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(254, 379)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Paket"
        '
        'btnhapuspaket
        '
        Me.btnhapuspaket.Location = New System.Drawing.Point(6, 349)
        Me.btnhapuspaket.Name = "btnhapuspaket"
        Me.btnhapuspaket.Size = New System.Drawing.Size(97, 23)
        Me.btnhapuspaket.TabIndex = 3
        Me.btnhapuspaket.Text = "Hapus Paket"
        Me.btnhapuspaket.UseVisualStyleBackColor = True
        '
        'btntambahpaket
        '
        Me.btntambahpaket.Location = New System.Drawing.Point(151, 68)
        Me.btntambahpaket.Name = "btntambahpaket"
        Me.btntambahpaket.Size = New System.Drawing.Size(97, 23)
        Me.btntambahpaket.TabIndex = 2
        Me.btntambahpaket.Text = "Tambah Paket"
        Me.btntambahpaket.UseVisualStyleBackColor = True
        '
        'tbhargapaket
        '
        Me.tbhargapaket.Location = New System.Drawing.Point(89, 42)
        Me.tbhargapaket.Name = "tbhargapaket"
        Me.tbhargapaket.Size = New System.Drawing.Size(157, 20)
        Me.tbhargapaket.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Nama Paket"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Harga Paket"
        '
        'tbnamapaket
        '
        Me.tbnamapaket.Location = New System.Drawing.Point(89, 16)
        Me.tbnamapaket.Name = "tbnamapaket"
        Me.tbnamapaket.Size = New System.Drawing.Size(157, 20)
        Me.tbnamapaket.TabIndex = 3
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.idpaket)
        Me.GroupBox2.Controls.Add(Me.idmakanan)
        Me.GroupBox2.Controls.Add(Me.TextBox1)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.btnhapus)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.dgvmakanan)
        Me.GroupBox2.Controls.Add(Me.TextBox2)
        Me.GroupBox2.Controls.Add(Me.btntambah)
        Me.GroupBox2.Controls.Add(Me.btncari)
        Me.GroupBox2.Location = New System.Drawing.Point(272, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(261, 379)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Pilihan Menu"
        '
        'idpaket
        '
        Me.idpaket.Enabled = False
        Me.idpaket.Location = New System.Drawing.Point(108, 352)
        Me.idpaket.Name = "idpaket"
        Me.idpaket.Size = New System.Drawing.Size(44, 20)
        Me.idpaket.TabIndex = 11
        '
        'idmakanan
        '
        Me.idmakanan.Enabled = False
        Me.idmakanan.Location = New System.Drawing.Point(109, 71)
        Me.idmakanan.Name = "idmakanan"
        Me.idmakanan.Size = New System.Drawing.Size(44, 20)
        Me.idmakanan.TabIndex = 10
        '
        'TextBox1
        '
        Me.TextBox1.Enabled = False
        Me.TextBox1.Location = New System.Drawing.Point(95, 45)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(157, 20)
        Me.TextBox1.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Nama Makanan"
        '
        'btnhapus
        '
        Me.btnhapus.Location = New System.Drawing.Point(6, 350)
        Me.btnhapus.Name = "btnhapus"
        Me.btnhapus.Size = New System.Drawing.Size(97, 23)
        Me.btnhapus.TabIndex = 3
        Me.btnhapus.Text = "Hapus Makanan"
        Me.btnhapus.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Harga Makanan"
        '
        'dgvmakanan
        '
        Me.dgvmakanan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvmakanan.Location = New System.Drawing.Point(8, 101)
        Me.dgvmakanan.Name = "dgvmakanan"
        Me.dgvmakanan.Size = New System.Drawing.Size(247, 243)
        Me.dgvmakanan.TabIndex = 3
        '
        'TextBox2
        '
        Me.TextBox2.Enabled = False
        Me.TextBox2.Location = New System.Drawing.Point(95, 19)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(157, 20)
        Me.TextBox2.TabIndex = 7
        '
        'btntambah
        '
        Me.btntambah.Location = New System.Drawing.Point(159, 72)
        Me.btntambah.Name = "btntambah"
        Me.btntambah.Size = New System.Drawing.Size(97, 23)
        Me.btntambah.TabIndex = 3
        Me.btntambah.Text = "Tambah"
        Me.btntambah.UseVisualStyleBackColor = True
        '
        'btncari
        '
        Me.btncari.Location = New System.Drawing.Point(6, 72)
        Me.btncari.Name = "btncari"
        Me.btncari.Size = New System.Drawing.Size(97, 23)
        Me.btncari.TabIndex = 3
        Me.btncari.Text = "Cari"
        Me.btncari.UseVisualStyleBackColor = True
        '
        'FormPaket
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(542, 396)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FormPaket"
        Me.Text = "Paket"
        CType(Me.dgvpaket, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgvmakanan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvpaket As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btntambahpaket As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnhapus As System.Windows.Forms.Button
    Friend WithEvents dgvmakanan As System.Windows.Forms.DataGridView
    Friend WithEvents btntambah As System.Windows.Forms.Button
    Friend WithEvents btncari As System.Windows.Forms.Button
    Friend WithEvents tbhargapaket As System.Windows.Forms.TextBox
    Friend WithEvents tbnamapaket As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnhapuspaket As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents idmakanan As System.Windows.Forms.TextBox
    Friend WithEvents idpaket As System.Windows.Forms.TextBox
End Class
