Imports System.Data
Imports System.Data.SqlClient
Imports DevExpress.XtraEditors
Imports DevExpress.Utils
Imports Elliteserv.SQLServer.Connect
Imports DevExpress.XtraEditors.Repository

Public Class frmEntriReturJual
    Public NoID As Long = -1
    Dim KodeLama As String = ""
    Dim pStatus As Status
    Dim SQL As String = ""

    Public Enum Status
        Baru = 0
        TempEdit = 1
        Edit = 2
    End Enum

    Dim repckedit As New RepositoryItemCheckEdit
    Dim repdateedit As New RepositoryItemDateEdit
    Dim reptextedit As New RepositoryItemTextEdit
    Dim reppicedit As New RepositoryItemPictureEdit

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        If pStatus = Status.Edit Then 'Harus Disimpan
            cmdSave.PerformClick()
        ElseIf pStatus = Status.TempEdit Then 'Hapus Total
            SQL = "DELETE FROM [HKartuStok] WHERE IDJenisTransaksi=4 AND IDTransaksi=" & NoID
            EksekusiSQL(SQL)
            SQL = "DELETE FROM [HKartuPiutang] WHERE IDJenisTransaksi=4 AND IDTransaksi=" & NoID
            EksekusiSQL(SQL)
            SQL = "DELETE FROM [HKartuPoin] WHERE IDJenisTransaksi=4 AND IDTransaksi=" & NoID
            EksekusiSQL(SQL)
            SQL = "DELETE FROM [HReturJualD] WHERE IDHeader=" & NoID
            EksekusiSQL(SQL)
            SQL = "DELETE FROM [HReturJual] WHERE NoID=" & NoID
            EksekusiSQL(SQL)
            DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        Else
            DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Public Sub New(ByVal IsBaru As Status)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        pStatus = IIf(IsBaru = Status.Baru, Status.Baru, Status.Edit)
    End Sub

    Private Sub SetTombol()
        If pStatus = Status.Baru Then
            cmdNew.Enabled = False
            cmdEdit.Enabled = False
            cmdHapus.Enabled = False
        Else
            cmdNew.Enabled = True
            cmdEdit.Enabled = True
            cmdHapus.Enabled = True
        End If
    End Sub

    Private Sub frmEntriReturJual_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If pStatus = Status.Baru Then
                LayoutControl1.SaveLayoutToXml(FolderLayouts & "\" & Me.Name & LayoutControl1.Name & ".xml")
                GridView1.SaveLayoutToXml(FolderLayouts & "\" & Me.Name & GridView1.Name & ".xml")
            ElseIf pStatus = Status.Edit Then
                e.Cancel = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RefreshDataSO()
        Dim ds As New DataSet
        Try
            'Refresh Data Customer
            SQL = "SELECT HJual.NoID, HJual.Kode, HJual.Tanggal" & vbCrLf & _
                  " FROM HJual " & vbCrLf & _
                  " INNER JOIN HJualD ON HJual.NoID=HJualD.IDHeader " & vbCrLf & _
                  " WHERE (HJualD.Qty*HJualD.Konversi)-ISNULL((SELECT SUM(HReturJualD.Qty*HReturJualD.Konversi) FROM HReturJualD INNER JOIN HReturJual ON HReturJual.NoID=HReturJualD.IDHeader WHERE HReturJualD.IDJualD=HJualD.NoID),0)>=1 " & vbCrLf & _
                  " AND HJual.IDCustomer=" & NullToLong(txtIDCustomer.EditValue) & vbCrLf & _
                  " GROUP BY HJual.NoID, HJual.Kode, HJual.Tanggal"
            EksekusiDataset(ds, "Data", SQL)
            txtPenjualan.Properties.DataSource = ds.Tables("Data")
            txtPenjualan.Properties.ValueMember = "NoID"
            txtPenjualan.Properties.DisplayMember = "Kode"
        Catch ex As Exception
            XtraMessageBox.Show("Info Kesalahan : " & ex.Message, NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            ds.Dispose()
        End Try
    End Sub

    Private Sub frmEntriReturJual_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ds As New DataSet
        Dim dlg As New WaitDialogForm("Generate component ...", NamaAplikasi)
        Try
            dlg.ShowInTaskbar = False
            dlg.TopMost = True
            dlg.Show()
            dlg.Focus()
            Cursor = Cursors.WaitCursor

            'Refresh Data Customer
            SQL = "SELECT NoID, Kode, Nama, Alamat FROM HKontak WHERE IsAktif=1 AND IsCustomer=1"
            EksekusiDataset(ds, "Data", SQL)
            txtIDCustomer.Properties.DataSource = ds.Tables("Data")
            txtIDCustomer.Properties.ValueMember = "NoID"
            txtIDCustomer.Properties.DisplayMember = "Kode"

            If pStatus = Status.Baru Then
                txtTanggal.DateTime = TanggalSystem
                txtJatuhTempo.DateTime = TanggalSystem
            Else
                SQL = "SELECT * FROM HReturJual WHERE NoID=" & NoID
                EksekusiDataset(ds, "Data", SQL)
                If ds.Tables("Data").Rows.Count >= 1 Then
                    txtKode.Text = NullToStr(ds.Tables("Data").Rows(0).Item("Kode"))
                    KodeLama = txtKode.Text
                    txtReff.Text = NullToStr(ds.Tables("Data").Rows(0).Item("Reff"))
                    txtKeterangan.Text = NullToStr(ds.Tables("Data").Rows(0).Item("Keterangan"))
                    txtIDCustomer.EditValue = NullToLong(ds.Tables("Data").Rows(0).Item("IDCustomer"))
                    txtTanggal.DateTime = NullToDate(ds.Tables("Data").Rows(0).Item("Tanggal"))
                    txtJatuhTempo.DateTime = NullToDate(ds.Tables("Data").Rows(0).Item("TglTempo"))
                    txtTotal.EditValue = NullToDbl(ds.Tables("Data").Rows(0).Item("Total"))
                    txtBayar.EditValue = NullToDbl(ds.Tables("Data").Rows(0).Item("Bayar"))
                    txtSisa.EditValue = NullToDbl(ds.Tables("Data").Rows(0).Item("Sisa"))
                End If
            End If
            RefreshData()
            SetTombol()
            If System.IO.File.Exists(FolderLayouts & "\" & Me.Name & LayoutControl1.Name & ".xml") Then
                LayoutControl1.RestoreLayoutFromXml(FolderLayouts & "\" & Me.Name & LayoutControl1.Name & ".xml")
            End If
            If System.IO.File.Exists(FolderLayouts & "\" & Me.Name & GridView1.Name & ".xml") Then
                GridView1.RestoreLayoutFromXml(FolderLayouts & "\" & Me.Name & GridView1.Name & ".xml")
            End If
        Catch ex As Exception
            XtraMessageBox.Show("Info Kesalahan : " & ex.Message, NamaAplikasi, MessageBoxButtons.OK)
        Finally
            If Not ds Is Nothing Then
                ds.Dispose()
            End If
            dlg.Close()
            dlg.Dispose()
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub RefreshData()
        Dim ds As New DataSet
        Dim dlg As New WaitDialogForm("Refresh Data ...", NamaAplikasi)
        Try
            dlg.ShowInTaskbar = False
            dlg.TopMost = True
            dlg.Show()
            dlg.Focus()
            Cursor = Cursors.WaitCursor
            SQL = "SELECT HReturJualD.*, HBarang.Kode AS KodeBarang, HBarang.Nama AS NamaBarang, HSatuan.Kode AS Satuan, HJual.Kode AS Reff " & vbCrLf & _
                  " FROM HReturJualD " & vbCrLf & _
                  " LEFT JOIN HBarang ON HBarang.NoID=HReturJualD.IDBarang " & vbCrLf & _
                  " LEFT JOIN HSatuan ON HSatuan.NoID=HReturJualD.IDSatuan  " & vbCrLf & _
                  " LEFT JOIN (HJualD INNER JOIN HJual ON HJual.NoID=HJualD.IDHeader) ON HJualD.NoID=HReturJualD.IDJualD " & vbCrLf & _
                  " WHERE HReturJualD.IDHeader=" & NoID
            EksekusiDataset(ds, "Data", SQL)
            GridControl1.DataSource = ds.Tables("Data")
            With GridView1
                For i As Integer = 0 To .Columns.Count - 1
                    Select Case .Columns(i).ColumnType.Name.ToLower
                        Case "int32", "int64", "int"
                            .Columns(i).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                            .Columns(i).DisplayFormat.FormatString = "n0"
                        Case "decimal", "single", "money", "double"
                            .Columns(i).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                            .Columns(i).DisplayFormat.FormatString = "n2"
                        Case "string"
                            .Columns(i).DisplayFormat.FormatType = DevExpress.Utils.FormatType.None
                            .Columns(i).DisplayFormat.FormatString = ""
                        Case "date"
                            .Columns(i).DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                            .Columns(i).DisplayFormat.FormatString = "dd-MM-yyyy"
                        Case "datetime"
                            .Columns(i).DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                            .Columns(i).DisplayFormat.FormatString = "dd-MM-yyyy HH:mm"
                        Case "byte[]"
                            reppicedit.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze
                            .Columns(i).OptionsColumn.AllowGroup = False
                            .Columns(i).OptionsColumn.AllowSort = False
                            .Columns(i).OptionsFilter.AllowFilter = False
                            .Columns(i).ColumnEdit = reppicedit
                        Case "boolean"
                            .Columns(i).ColumnEdit = repckedit
                    End Select
                    '.ShowFindPanel()
                Next
            End With
            txtTotal.EditValue = 0
            For i As Integer = 0 To ds.Tables("Data").Rows.Count - 1
                txtTotal.EditValue += NullToDbl(ds.Tables("Data").Rows(i).Item("Jumlah"))
            Next
            HitungTotal()
            RefreshDataSO()
        Catch ex As Exception
            XtraMessageBox.Show("Info Kesalahan : " & ex.Message, NamaAplikasi, MessageBoxButtons.OK)
        Finally
            If Not ds Is Nothing Then
                ds.Dispose()
            End If
            dlg.Close()
            dlg.Dispose()
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub HitungTotal()
        txtSisa.EditValue = txtTotal.EditValue - txtBayar.EditValue
    End Sub

    Private Sub txtTanggal_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTanggal.EditValueChanged
        Try
            If pStatus = Status.Baru Or pStatus = Status.TempEdit Then
                txtKode.Text = MintaKodeBaru("RJ", "HReturJual", txtTanggal.DateTime, 5)
                txtJatuhTempo.DateTime = txtTanggal.DateTime.AddDays(NullToLong(EksekusiScalar("SELECT ISNULL(JTCustomer,0) FROM HKontak WHERE NoID=" & NullToLong(txtIDCustomer.EditValue))))
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtIDCustomer_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIDCustomer.EditValueChanged
        Dim ds As New DataSet
        Try
            SQL = "SELECT * FROM HKontak WHERE NoID=" & NullToLong(txtIDCustomer.EditValue)
            EksekusiDataset(ds, "Data", SQL)
            If ds.Tables("Data").Rows.Count >= 1 Then
                txtNamaCustomer.Text = NullToStr(ds.Tables("Data").Rows(0).Item("Nama"))
                txtAlamatCustomer.Text = NullToStr(ds.Tables("Data").Rows(0).Item("Alamat"))
                txtJatuhTempo.DateTime = txtTanggal.DateTime.AddDays(NullToLong(ds.Tables("Data").Rows(0).Item("JTCustomer")))
            End If
            RefreshDataSO()
        Catch ex As Exception
        Finally
            If Not ds Is Nothing Then
                ds.Dispose()
            End If
        End Try
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Dim dlg As New WaitDialogForm("Saving Data ...", NamaAplikasi)
        Dim ds As New DataSet
        Dim MinimumDapatPoin As Double = 0
        Dim SyaratDapatPoin As Double = 0
        Dim NilaiPoin As Double = 0, Poin As Double = 0
        Dim IsKelipatan As Boolean = False
        Dim JumlahBrgPoin As Double = 0

        Try
            dlg.ShowInTaskbar = False
            dlg.TopMost = True
            dlg.Show()
            dlg.Focus()
            Cursor = Cursors.WaitCursor
            RefreshData()
            If IsValidasi() Then
                If pStatus = Status.Baru Then
                    NoID = GetNewID("HReturJual", "NoID")
                    SQL = "INSERT INTO [HReturJual] ([NoID],[Kode],[IDCustomer],[Tanggal],[TglTempo],[Reff],[Keterangan],[Total],[IDUserEntri],[TglEntri],[IDUserEdit],[TglEdit]) VALUES (" & vbCrLf & _
                          NoID & ", '" & FixApostropi(txtKode.Text) & "', " & NullToLong(txtIDCustomer.EditValue) & ", '" & txtTanggal.DateTime.ToString("yyyy-MM-dd") & "', '" & txtJatuhTempo.DateTime.ToString("yyyy-MM-dd") & "', " & vbCrLf & _
                          "'" & FixApostropi(txtReff.Text) & "', '" & FixApostropi(txtKeterangan.Text) & "', " & FixKoma(txtTotal.EditValue) & ", " & IDUserAktif & ", GETDATE(), NULL, NULL)"
                    If EksekusiSQL(SQL) >= 1 Then
                        SQL = "DELETE FROM [HKartuStok] WHERE IDJenisTransaksi=4 AND IDTransaksi=" & NoID
                        EksekusiSQL(SQL)
                        SQL = "DELETE FROM [HKartuPiutang] WHERE IDJenisTransaksi=4 AND IDTransaksi=" & NoID
                        EksekusiSQL(SQL)

                        pStatus = Status.TempEdit
                        KodeLama = txtKode.Text
                        SetTombol()
                    End If
                Else
                    SQL = "UPDATE [HReturJual] SET " & vbCrLf & _
                          "[Kode]='" & FixApostropi(txtKode.Text) & "', [IDCustomer]=" & NullToLong(txtIDCustomer.EditValue) & ", [Tanggal]='" & txtTanggal.DateTime.ToString("yyyy-MM-dd") & "', [TglTempo]='" & txtJatuhTempo.DateTime.ToString("yyyy-MM-dd") & "', " & vbCrLf & _
                          "[Reff]='" & FixApostropi(txtReff.Text) & "', [Keterangan]='" & FixApostropi(txtKeterangan.Text) & "', [Total]=" & FixKoma(txtTotal.EditValue) & ", [Bayar]=" & FixKoma(txtBayar.EditValue) & ", [Sisa]=" & FixKoma(txtSisa.EditValue) & ", [IDUserEdit]=" & IDUserAktif & ", [TglEdit]=GETDATE() WHERE NoID=" & NoID
                    If EksekusiSQL(SQL) >= 1 Then
                        'Tambah Stok
                        SQL = "DELETE FROM [HKartuStok] WHERE IDJenisTransaksi=4 AND IDTransaksi=" & NoID
                        EksekusiSQL(SQL)

                        SQL = "INSERT INTO [HKartuStok] ([IDKontak],[KodeReff],[Tanggal],[IDJenisTransaksi],[IDTransaksi],[IDBarang],[IDSatuan],[QtyMasuk],[QtyKeluar],[Konversi],[HPP],[HargaBeliTerakhir],[HargaJualTerakhir]) " & vbCrLf & _
                              " SELECT HReturJual.IDCustomer, HReturJual.Kode, HReturJual.Tanggal, 4 AS IDJenisTransaksi, HReturJual.NoID, HReturJualD.IDBarang, HReturJualD.IDSatuan, HReturJualD.Qty AS QtyMasuk, 0 AS QtyKeluar, HReturJualD.Konversi, HReturJualD.Harga, HReturJualD.Harga, HReturJualD.Harga " & vbCrLf & _
                              " FROM HReturJualD INNER JOIN HReturJual ON HReturJual.NoID=HReturJualD.IDHeader " & vbCrLf & _
                              " WHERE HReturJualD.IDHeader=" & NoID
                        EksekusiSQL(SQL)

                        'Kurangi Piutang
                        SQL = "DELETE FROM [HKartuPiutang] WHERE IDJenisTransaksi=4 AND IDTransaksi=" & NoID
                        EksekusiSQL(SQL)

                        SQL = "INSERT INTO [HKartuPiutang] ([IDKontak],[KodeReff],[Tanggal],[IDJenisTransaksi],[IDTransaksi],[SaldoMasuk],[SaldoKeluar]) " & vbCrLf & _
                              " SELECT HReturJual.IDCustomer, HReturJual.Kode, HReturJual.Tanggal, 4 AS IDJenisTransaksi, HReturJual.NoID, 0 AS QtyMasuk, HReturJual.Sisa AS QtyKeluar " & vbCrLf & _
                              " FROM HReturJual " & vbCrLf & _
                              " WHERE HReturJual.Sisa>0 AND HReturJual.NoID=" & NoID
                        EksekusiSQL(SQL)

                        pStatus = Status.Baru
                        DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()
                    End If
                End If
            End If
        Catch ex As Exception
            XtraMessageBox.Show("Info Kesalahan : " & ex.Message, NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            ds.Dispose()
            Cursor = Cursors.Default
            dlg.Close()
            dlg.Dispose()
        End Try
    End Sub

    Private Function IsValidasi() As Boolean
        Dim Hasil As Boolean = True
        If txtKode.Text = "" Then
            XtraMessageBox.Show("Kode masih kosong.", NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtKode.Focus()
            Hasil = False
            IsValidasi = False
            Exit Function
        End If
        If txtTanggal.Text = "" Then
            XtraMessageBox.Show("Tanggal masih kosong.", NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtTanggal.Focus()
            Hasil = False
            IsValidasi = False
            Exit Function
        End If
        If txtJatuhTempo.Text = "" Then
            XtraMessageBox.Show("Jatuh Tempo masih kosong.", NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtJatuhTempo.Focus()
            Hasil = False
            IsValidasi = False
            Exit Function
        End If
        If txtIDCustomer.Text = "" Then
            XtraMessageBox.Show("Customer masih kosong.", NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtIDCustomer.Focus()
            Hasil = False
            IsValidasi = False
            Exit Function
        End If
        If CekKodeValid(txtKode.Text, KodeLama, "HReturJual", "Kode", IIf(pStatus = Status.Baru, False, True)) Then
            XtraMessageBox.Show("Kode sudah dipakai.", NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtKode.Focus()
            Hasil = False
            IsValidasi = False
            Exit Function
        End If
        If pStatus <> Status.Baru AndAlso GridView1.RowCount <= 0 Then
            XtraMessageBox.Show("Item masih kosong.", NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            GridView1.Focus()
            Hasil = False
            IsValidasi = False
            Exit Function
        End If
        Return Hasil
    End Function

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        RefreshData()
    End Sub

    Private Sub cmdNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNew.Click
        Dim x As New frmEntriReturJualD(True, NoID)
        x.ShowInTaskbar = False
        x.StartPosition = FormStartPosition.CenterParent
        x.IDCustomer = NullToLong(txtIDCustomer.EditValue)
        If x.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            cmdRefresh.PerformClick()
            GridView1.ClearSelection()
            GridView1.FocusedRowHandle = GridView1.LocateByDisplayText(0, GridView1.Columns("NoID"), x.NoID.ToString("n0"))
            GridView1.SelectRow(GridView1.FocusedRowHandle)
        End If
        x.Dispose()
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        Dim x As New frmEntriReturJualD(False, NoID)
        x.NoID = NullToLong(GridView1.GetFocusedRowCellValue(GridView1.Columns("NoID")))
        x.ShowInTaskbar = False
        x.IDCustomer = NullToLong(txtIDCustomer.EditValue)
        x.StartPosition = FormStartPosition.CenterParent
        If x.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            cmdRefresh.PerformClick()
            GridView1.ClearSelection()
            GridView1.FocusedRowHandle = GridView1.LocateByDisplayText(0, GridView1.Columns("NoID"), x.NoID.ToString("n0"))
            GridView1.SelectRow(GridView1.FocusedRowHandle)
        End If
        x.Dispose()
    End Sub

    Private Sub cmdHapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHapus.Click
        Dim NoID As Long = NullToLong(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "NoID"))
        If XtraMessageBox.Show("Yakin ingin menghapus item ReturJual yang dipilih ini?", NamaAplikasi, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            EksekusiSQL("DELETE FROM HReturJualD WHERE NoID=" & NoID)
            RefreshData()
        End If
    End Sub

    Private Sub txtJual_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtPenjualan.ButtonClick
        Try
            If pStatus <> Status.Baru AndAlso e.Button.Index = 1 Then
                ImportJual()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ImportJual()
        Dim ds As New DataSet
        Dim IDDetil As Long = -1
        Dim HargaJual As Double = 0
        Dim Qty As Double = 0
        Dim Konversi As Double = 0
        Dim Jumlah As Double = 0
        Try
            SQL = "SELECT HJualD.*, HBarang.HargaJual, (HJualD.Qty*HJualD.Konversi)-ISNULL((SELECT SUM(HReturJualD.Qty*HReturJualD.Konversi) FROM HReturJualD INNER JOIN HReturJual ON HReturJual.NoID=HReturJualD.IDHeader WHERE HReturJualD.IDJualD=HJualD.NoID),0) AS SisaQty " & vbCrLf & _
                  " FROM HJual " & vbCrLf & _
                  " INNER JOIN HJualD ON HJual.NoID=HJualD.IDHeader " & vbCrLf & _
                  " INNER JOIN HBarang ON HBarang.NoID=HJualD.IDBarang " & vbCrLf & _
                  " WHERE (HJualD.Qty*HJualD.Konversi)-ISNULL((SELECT SUM(HReturJualD.Qty*HReturJualD.Konversi) FROM HReturJualD INNER JOIN HReturJual ON HReturJual.NoID=HReturJualD.IDHeader WHERE HReturJualD.IDJualD=HJualD.NoID),0)>=1 " & vbCrLf & _
                  " AND HJual.NoID=" & NullToLong(txtPenjualan.EditValue)
            EksekusiDataset(ds, "Data", SQL)
            For i As Integer = 0 To ds.Tables("Data").Rows.Count - 1
                IDDetil = GetNewID("HReturJualD", "NoID")
                HargaJual = NullToDbl(ds.Tables("Data").Rows(i).Item("HargaJual"))
                Qty = NullToDbl(ds.Tables("Data").Rows(i).Item("SisaQty")) / NullToDbl(ds.Tables("Data").Rows(i).Item("Konversi"))
                Konversi = NullToDbl(ds.Tables("Data").Rows(i).Item("Konversi"))
                Jumlah = Qty * (Bulatkan(HargaJual * (1 - (NullToDbl(ds.Tables("Data").Rows(i).Item("DiscProsen1")))) * (1 - (NullToDbl(ds.Tables("Data").Rows(i).Item("DiscProsen2")))), 0) - NullToDbl(ds.Tables("Data").Rows(i).Item("DiscRp")))
                SQL = "INSERT INTO [HReturJualD] ([NoID],[IDJualD],[IDHeader],[IDBarang],[IDSatuan],[Konversi],[Qty],[Harga],[DiscProsen1],[DiscProsen2],[DiscRp],[Jumlah],[Keterangan]) VALUES (" & vbCrLf & _
                      IDDetil & ", " & NullToLong(ds.Tables("Data").Rows(i).Item("NoID")) & ", " & NoID & ", " & NullToLong(ds.Tables("Data").Rows(i).Item("IDBarang")) & ", " & NullToLong(ds.Tables("Data").Rows(i).Item("IDSatuan")) & ", " & vbCrLf & _
                      FixKoma(Konversi) & ", " & FixKoma(Qty) & ", " & FixKoma(HargaJual) & ", " & FixKoma(ds.Tables("Data").Rows(i).Item("DiscProsen1")) & ", " & FixKoma(ds.Tables("Data").Rows(i).Item("DiscProsen2")) & ", " & FixKoma(ds.Tables("Data").Rows(i).Item("DiscRp")) & ", " & FixKoma(Jumlah) & ", '" & FixApostropi(ds.Tables("Data").Rows(i).Item("Keterangan")) & "')"
                EksekusiSQL(SQL)
            Next
            cmdRefresh.PerformClick()
        Catch ex As Exception
            XtraMessageBox.Show("Info Kesalahan : " & ex.Message, NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            ds.Dispose()
        End Try
    End Sub
End Class