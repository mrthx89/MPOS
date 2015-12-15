Imports DevExpress.XtraEditors
Imports System.Data.SqlClient
Imports System.Data
Imports Elliteserv.SQLServer.Connect

Public Class frmEntriBarang
    Public NoID As Long
    Dim KodeLama As String = ""
    Dim BarcodeLama As String = ""
    Dim pStatusBaru As Boolean = False
    Dim SQL As String = ""

    Public Sub New(ByVal IsNew As Boolean)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        pStatusBaru = IsNew
    End Sub

    Private Function IsValidasi() As Boolean
        Dim Hasil As Boolean = True
        If txtBarcode.Text = "" Then
            XtraMessageBox.Show("Barcode masih kosong.", NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtBarcode.Focus()
            Hasil = False
            IsValidasi = False
            Exit Function
        End If
        If txtKode.Text = "" Then
            XtraMessageBox.Show("Kode masih kosong.", NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtKode.Focus()
            Hasil = False
            IsValidasi = False
            Exit Function
        End If
        If txtNama.Text = "" Then
            XtraMessageBox.Show("Nama masih kosong.", NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtNama.Focus()
            Hasil = False
            IsValidasi = False
            Exit Function
        End If
        If txtIDKategori.Text = "" Then
            XtraMessageBox.Show("Kategori masih kosong.", NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtIDKategori.Focus()
            Hasil = False
            IsValidasi = False
            Exit Function
        End If
        If txtIDSatuanBeli.Text = "" Then
            XtraMessageBox.Show("Satuan Beli masih kosong.", NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtIDSatuanBeli.Focus()
            Hasil = False
            IsValidasi = False
            Exit Function
        End If
        If txtIDSatuanJual.Text = "" Then
            XtraMessageBox.Show("Satuan Jual masih kosong.", NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtIDSatuanJual.Focus()
            Hasil = False
            IsValidasi = False
            Exit Function
        End If
        If txtHargaJual.EditValue < txtHargaBeliNetto.EditValue Then
            XtraMessageBox.Show("Harga Jual masih dibawah Harga Beli.", NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtHargaJual.Focus()
            Hasil = False
            IsValidasi = False
            Exit Function
        End If
        Return Hasil
    End Function

    Private Function Simpan() As Boolean
        Dim Hasil As Boolean = False
        Try
            If pStatusBaru Then
                NoID = GetNewID("HBarang", "NoID")
                SQL = "INSERT INTO [HBarang] ([NoID],[IDKategori],[Barcode],[Kode],[Nama],[Keterangan],[Alias],[QtyMax],[QtyMin],[IDSupplier1],[IDSupplier2],[IDSupplier3],[IDSatuanBeli],[HargaBeli],[KonversiBeli],[HargaBeliNetto],[IDSatuanJual],[KonversiJual],[MarkUp],[HargaJual],[IsAktif],[IsPoin]) VALUES ( " & vbCrLf & _
                      NoID & ", " & NullToLong(txtIDKategori.EditValue) & vbCrLf & _
                      " ,'" & FixApostropi(txtBarcode.Text) & "'" & vbCrLf & _
                      " ,'" & FixApostropi(txtKode.Text) & "'" & vbCrLf & _
                      " ,'" & FixApostropi(txtNama.Text) & "'" & vbCrLf & _
                      " ,'" & FixApostropi(txtKeterangan.Text) & "'" & vbCrLf & _
                      " ,'" & FixApostropi(txtAlias.Text) & "'" & vbCrLf & _
                      " ," & FixKoma(txtQtyMax.EditValue) & vbCrLf & _
                      " ," & FixKoma(txtQtyMin.EditValue) & vbCrLf & _
                      " ," & NullToLong(txtIDSupplier1.EditValue) & vbCrLf & _
                      " ," & NullToLong(txtIDSupplier2.EditValue) & vbCrLf & _
                      " ," & NullToLong(txtIDSupplier3.EditValue) & vbCrLf & _
                      " ," & NullToLong(txtIDSatuanBeli.EditValue) & vbCrLf & _
                      " ," & FixKoma(txtHargaBeli.EditValue) & vbCrLf & _
                      " ," & FixKoma(txtKonversiBeli.EditValue) & vbCrLf & _
                      " ," & FixKoma(txtHargaBeliNetto.EditValue) & vbCrLf & _
                      " ," & NullToLong(txtIDSatuanJual.EditValue) & vbCrLf & _
                      " ," & FixKoma(txtKonversiJual.EditValue) & vbCrLf & _
                      " ," & FixKoma(txtMarkUp.EditValue) & vbCrLf & _
                      " ," & FixKoma(txtHargaJual.EditValue) & vbCrLf & _
                      " ," & IIf(ckAktif.Checked, 1, 0) & vbCrLf & _
                      " ," & IIf(ckPoin.Checked, 1, 0) & ")"
            Else
                SQL = "UPDATE [HBarang] SET " & vbCrLf & _
                      " [IDKategori] = " & NullToLong(txtIDKategori.EditValue) & vbCrLf & _
                      " ,[Barcode] = '" & FixApostropi(txtBarcode.Text) & "'" & vbCrLf & _
                      " ,[Kode] = '" & FixApostropi(txtKode.Text) & "'" & vbCrLf & _
                      " ,[Nama] = '" & FixApostropi(txtNama.Text) & "'" & vbCrLf & _
                      " ,[Keterangan] = '" & FixApostropi(txtKeterangan.Text) & "'" & vbCrLf & _
                      " ,[Alias] = '" & FixApostropi(txtAlias.Text) & "'" & vbCrLf & _
                      " ,[QtyMax] = " & FixKoma(txtQtyMax.EditValue) & vbCrLf & _
                      " ,[QtyMin] = " & FixKoma(txtQtyMin.EditValue) & vbCrLf & _
                      " ,[IDSupplier1] = " & NullToLong(txtIDSupplier1.EditValue) & vbCrLf & _
                      " ,[IDSupplier2] = " & NullToLong(txtIDSupplier2.EditValue) & vbCrLf & _
                      " ,[IDSupplier3] = " & NullToLong(txtIDSupplier3.EditValue) & vbCrLf & _
                      " ,[IDSatuanBeli] = " & NullToLong(txtIDSatuanBeli.EditValue) & vbCrLf & _
                      " ,[HargaBeli] = " & FixKoma(txtHargaBeli.EditValue) & vbCrLf & _
                      " ,[KonversiBeli] = " & FixKoma(txtKonversiBeli.EditValue) & vbCrLf & _
                      " ,[HargaBeliNetto] = " & FixKoma(txtHargaBeliNetto.EditValue) & vbCrLf & _
                      " ,[IDSatuanJual] = " & NullToLong(txtIDSatuanJual.EditValue) & vbCrLf & _
                      " ,[KonversiJual] = " & FixKoma(txtKonversiJual.EditValue) & vbCrLf & _
                      " ,[MarkUp] = " & FixKoma(txtMarkUp.EditValue) & vbCrLf & _
                      " ,[HargaJual] = " & FixKoma(txtHargaJual.EditValue) & vbCrLf & _
                      " ,[IsAktif] = " & IIf(ckAktif.Checked, 1, 0) & vbCrLf & _
                      " ,[IsPoin] = " & IIf(ckPoin.Checked, 1, 0) & vbCrLf & _
                      " WHERE NoID=" & NoID
            End If
            If EksekusiSQL(SQL) >= 1 Then
                SQL = "UPDATE HBarang SET [IDUserLastUpdate]=" & IDUserAktif & ", [LastUpdate]=Getdate() WHERE NoID=" & NoID
                If EksekusiSQL(SQL) >= 1 AndAlso SimpanGambar() Then
                    Hasil = True
                End If
            End If
        Catch ex As Exception
            XtraMessageBox.Show("Info Kesalahan : " & ex.Message, NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
        Return Hasil
    End Function

    Private Function SimpanGambar() As Boolean
        Dim cn As New SqlConnection
        Dim com As New SqlCommand
        Try
            cn.ConnectionString = Elliteserv.SQLServer.Connect.KoneksiString
            cn.Open()

            SQL = "UPDATE HBarang SET [Photo]=@photo WHERE NoID=" & NoID
            With com
                .CommandText = SQL
                .Connection = cn
                .Parameters.Add("@photo", SqlDbType.Image).Value = PictureEdit1.EditValue 'IIf(getDataGambar(PictureEdit1) Is Nothing, Nothing, getDataGambar(PictureEdit1))
                .ExecuteNonQuery()
                Return True
            End With
        Catch ex As Exception
            XtraMessageBox.Show("Info Kesalahan : " & ex.Message, NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            cn.Dispose()
            com.Dispose()
        End Try
    End Function
    Private Function getDataGambar(ByVal oPic As PictureEdit) As Byte()
        Dim ms As System.IO.MemoryStream = Nothing
        Try
            ms = New System.IO.MemoryStream()

            oPic.Image.Save(ms, oPic.Image.RawFormat)

            Dim dataGbr As Byte() = ms.GetBuffer()

            Return dataGbr
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Try
            HitungHargaBeli()
            HitungHargaJualByProsen()
            HitungProsenByHargaJual()
            If IsValidasi() Then
                If Simpan() Then
                    DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()
                End If
            End If
        Catch ex As Exception
            XtraMessageBox.Show("Info Kesalahan : " & ex.Message, NamaAplikasi, MessageBoxButtons.OK)
        End Try
    End Sub

    Private Sub RefreshDataKontak()
        Dim ds As New DataSet
        Try
            SQL = "SELECT NoID, Kode + ' ' + Nama AS Kode, Nama FROM HKategori WHERE IsAktif=1"
            EksekusiDataset(ds, "Data", SQL)
            txtIDKategori.Properties.DataSource = ds.Tables("Data")
            txtIDKategori.Properties.ValueMember = "NoID"
            txtIDKategori.Properties.DisplayMember = "Kode"

            SQL = "SELECT NoID, Kode, Nama FROM HKontak WHERE IsAktif=1 AND IsSupplier=1"
            EksekusiDataset(ds, "Data", SQL)
            txtIDSupplier1.Properties.DataSource = ds.Tables("Data")
            txtIDSupplier1.Properties.ValueMember = "NoID"
            txtIDSupplier1.Properties.DisplayMember = "Nama"
            txtIDSupplier2.Properties.DataSource = ds.Tables("Data")
            txtIDSupplier2.Properties.ValueMember = "NoID"
            txtIDSupplier2.Properties.DisplayMember = "Nama"
            txtIDSupplier3.Properties.DataSource = ds.Tables("Data")
            txtIDSupplier3.Properties.ValueMember = "NoID"
            txtIDSupplier3.Properties.DisplayMember = "Nama"

            SQL = "SELECT NoID, Kode, Nama FROM HSatuan WHERE IsAktif=1"
            EksekusiDataset(ds, "Data", SQL)
            txtIDSatuanBeli.Properties.DataSource = ds.Tables("Data")
            txtIDSatuanBeli.Properties.ValueMember = "NoID"
            txtIDSatuanBeli.Properties.DisplayMember = "Nama"
            txtIDSatuanJual.Properties.DataSource = ds.Tables("Data")
            txtIDSatuanJual.Properties.ValueMember = "NoID"
            txtIDSatuanJual.Properties.DisplayMember = "Nama"
        Catch ex As Exception

        Finally
            ds.Dispose()
        End Try
    End Sub

    Private Sub frmEntriBarang_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        LayoutControl1.SaveLayoutToXml(FolderLayouts & "\" & Me.Name & LayoutControl1.Name & ".xml")
    End Sub

    Private Sub frmEntriBarang_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ds As New DataSet
        Try
            RefreshDataKontak()
            If pStatusBaru Then
                ckAktif.Checked = True
                ckPoin.Checked = True
                txtIDSatuanBeli.EditValue = 1
                txtIDSatuanJual.EditValue = 1
                txtKonversiBeli.EditValue = 1
                txtKonversiJual.EditValue = 1

                txtQtyMax.EditValue = 1000
                txtQtyMin.EditValue = 10
            Else
                SQL = "SELECT * FROM HBarang WHERE NoID= " & NoID
                EksekusiDataset(ds, "HBarang", SQL)
                If ds.Tables("HBarang").Rows.Count >= 1 Then
                    txtIDKategori.EditValue = NullToLong(ds.Tables("HBarang").Rows(0).Item("IDKategori"))
                    txtIDKategori.Properties.ReadOnly = True
                    txtKode.Text = NullToStr(ds.Tables("HBarang").Rows(0).Item("Kode"))
                    KodeLama = txtKode.Text
                    txtKode.Properties.ReadOnly = True
                    txtBarcode.Text = NullToStr(ds.Tables("HBarang").Rows(0).Item("Barcode"))
                    BarcodeLama = txtBarcode.Text
                    txtBarcode.Properties.ReadOnly = True
                    txtAlias.Text = NullToStr(ds.Tables("HBarang").Rows(0).Item("Alias"))
                    txtNama.Text = NullToStr(ds.Tables("HBarang").Rows(0).Item("Nama"))
                    txtKeterangan.Text = NullToStr(ds.Tables("HBarang").Rows(0).Item("Keterangan"))
                    txtIDSatuanBeli.EditValue = NullToLong(ds.Tables("HBarang").Rows(0).Item("IDSatuanBeli"))
                    txtIDSatuanJual.EditValue = NullToLong(ds.Tables("HBarang").Rows(0).Item("IDSatuanJual"))
                    txtIDSupplier1.EditValue = NullToLong(ds.Tables("HBarang").Rows(0).Item("IDSupplier1"))
                    txtIDSupplier2.EditValue = NullToLong(ds.Tables("HBarang").Rows(0).Item("IDSupplier2"))
                    txtIDSupplier3.EditValue = NullToLong(ds.Tables("HBarang").Rows(0).Item("IDSupplier3"))
                    txtHargaBeli.EditValue = NullToDbl(ds.Tables("HBarang").Rows(0).Item("HargaBeli"))
                    txtKonversiBeli.EditValue = NullToDbl(ds.Tables("HBarang").Rows(0).Item("KonversiBeli"))
                    txtHargaBeliNetto.EditValue = NullToDbl(ds.Tables("HBarang").Rows(0).Item("HargaBeliNetto"))
                    txtHargaJual.EditValue = NullToDbl(ds.Tables("HBarang").Rows(0).Item("HargaJual"))
                    txtKonversiJual.EditValue = NullToDbl(ds.Tables("HBarang").Rows(0).Item("KonversiJual"))
                    txtMarkUp.EditValue = NullToDbl(ds.Tables("HBarang").Rows(0).Item("MarkUp"))
                    txtQtyMax.EditValue = NullToLong(ds.Tables("HBarang").Rows(0).Item("QtyMax"))
                    txtQtyMin.EditValue = NullToLong(ds.Tables("HBarang").Rows(0).Item("QtyMin"))

                    ckAktif.Checked = NullToBool(ds.Tables("HBarang").Rows(0).Item("IsAktif"))
                    ckPoin.Checked = NullToBool(ds.Tables("HBarang").Rows(0).Item("IsPoin"))

                    'If IsDBNull(ds.Tables("HBarang").Rows(0).Item("Photo")) Then 'Null
                    '    PictureEdit1.Image = Nothing
                    'Else
                    '    Dim imageData As Byte() = ds.Tables("HBarang").Rows(0).Item("Photo")
                    '    Dim newImage As Image
                    '    Using ms As System.IO.MemoryStream = New System.IO.MemoryStream(imageData, 0, imageData.Length)
                    '        ms.Write(imageData, 0, imageData.Length)
                    '        newImage = Image.FromStream(ms, True)
                    '        ms.Dispose()
                    '    End Using
                    '    PictureEdit1.Image = newImage
                    'End If
                    PictureEdit1.EditValue = ds.Tables("HBarang").Rows(0).Item("Photo")
                End If
            End If
            If System.IO.File.Exists(FolderLayouts & "\" & Me.Name & LayoutControl1.Name & ".xml") Then
                LayoutControl1.RestoreLayoutFromXml(FolderLayouts & "\" & Me.Name & LayoutControl1.Name & ".xml")
            End If
        Catch ex As Exception
            XtraMessageBox.Show("Info Kesalahan : " & ex.Message, NamaAplikasi, MessageBoxButtons.OK)
        Finally
            If Not ds Is Nothing Then
                ds.Dispose()
            End If
        End Try
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub txtIDKategori_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIDKategori.EditValueChanged
        Dim Nourut As Long = -1
        Dim Format As String = ""
        Try
            If pStatusBaru Then
                SQL = "SELECT HKategori.Kode FROM HKategori WHERE HKategori.NoID=" & NullToLong(txtIDKategori.EditValue)
                txtKode.Text = NullToStr(EksekusiScalar(SQL))
                SQL = "SELECT MAX(SUBSTRING(Kode," & txtKode.Text.Length + 1 & "," & 7 - txtKode.Text.Length & ")) FROM HBarang WHERE HBarang.IDKategori=" & NullToLong(txtIDKategori.EditValue)
                Nourut = NullToLong(EksekusiScalar(SQL)) + 1
                Format = ""
                For i As Integer = 0 To 7 - txtKode.Text.Length - 1
                    Format &= "0"
                Next
                txtKode.Text &= Nourut.ToString(Format)
                txtBarcode.Text = EAN8_Checksum(txtKode.Text)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtKonversiBeli_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKonversiBeli.EditValueChanged, txtHargaBeli.EditValueChanged, txtHargaBeliNetto.EditValueChanged
        HitungHargaBeli()
        HitungHargaJualByProsen()
    End Sub

    Private Sub HitungHargaBeli()
        Try
            If txtKonversiBeli.EditValue = 0 Then
                txtHargaBeliNetto.EditValue = txtHargaBeli.EditValue
            Else
                txtHargaBeliNetto.EditValue = txtHargaBeli.EditValue / txtKonversiBeli.EditValue
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub HitungHargaJualByProsen()
        Try
            txtHargaJual.EditValue = Bulatkan(txtHargaBeliNetto.EditValue * (1 + (txtMarkUp.EditValue / 100)), 0)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub HitungProsenByHargaJual()
        Try
            txtMarkUp.EditValue = (txtHargaJual.EditValue - txtHargaBeliNetto.EditValue) / txtHargaBeliNetto.EditValue * 100
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtMarkUp_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMarkUp.EditValueChanged
        HitungHargaJualByProsen()
    End Sub

    Private Sub txtHargaJual_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHargaJual.EditValueChanged
        HitungProsenByHargaJual()
    End Sub
End Class