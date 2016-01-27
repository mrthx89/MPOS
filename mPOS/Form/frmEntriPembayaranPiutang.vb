Imports System.Data
Imports System.Data.SqlClient
Imports DevExpress.XtraEditors
Imports DevExpress.Utils
Imports Elliteserv.SQLServer.Connect
Imports DevExpress.XtraEditors.Repository

Public Class frmEntriPembayaranPiutang
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
            SQL = "DELETE FROM [HKartuStok] WHERE IDJenisTransaksi=2 AND IDTransaksi=" & NoID
            EksekusiSQL(SQL)
            SQL = "DELETE FROM [HKartuPiutang] WHERE IDJenisTransaksi=2 AND IDTransaksi=" & NoID
            EksekusiSQL(SQL)
            SQL = "DELETE FROM [HKartuPoin] WHERE IDJenisTransaksi=2 AND IDTransaksi=" & NoID
            EksekusiSQL(SQL)
            SQL = "DELETE FROM [HJualD] WHERE IDHeader=" & NoID
            EksekusiSQL(SQL)
            SQL = "DELETE FROM [HJual] WHERE NoID=" & NoID
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
        pStatus = IsBaru
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

    Private Sub frmEntriJual_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If pStatus = Status.Baru Then
                LayoutControl1.SaveLayoutToXml(FolderLayouts & "\" & Me.Name & LayoutControl1.Name & ".xml")
                GVJual.SaveLayoutToXml(FolderLayouts & "\" & Me.Name & GVJual.Name & ".xml")
            ElseIf pStatus = Status.Edit Then
                e.Cancel = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RefreshDataTransaksi()
        Dim ds As New DataSet
        Try
            'Refresh Data Penjualan
            SQL = ""
            SQL = "SELECT HSalesOrder.NoID, HSalesOrder.Kode, HSalesOrder.Tanggal" & vbCrLf & _
                  " FROM HSalesOrder " & vbCrLf & _
                  " INNER JOIN HSalesOrderD ON HSalesOrder.NoID=HSalesOrderD.IDHeader " & vbCrLf & _
                  " WHERE (HSalesOrderD.Qty*HSalesOrderD.Konversi)-ISNULL((SELECT SUM(HJualD.Qty*HJualD.Konversi) FROM HJualD INNER JOIN HJual ON HJual.NoID=HJualD.IDHeader WHERE HJualD.IDSalesOrderD=HSalesOrderD.NoID),0)>=1 " & vbCrLf & _
                  " AND HSalesOrder.IDCustomer=" & NullToLong(txtIDCustomer.EditValue) & vbCrLf & _
                  " GROUP BY HSalesOrder.NoID, HSalesOrder.Kode, HSalesOrder.Tanggal"
            EksekusiDataset(ds, "Data", SQL)
            txtSalesOrder.Properties.DataSource = ds.Tables("Data")
            txtSalesOrder.Properties.ValueMember = "NoID"
            txtSalesOrder.Properties.DisplayMember = "Kode"
        Catch ex As Exception
            XtraMessageBox.Show("Info Kesalahan : " & ex.Message, NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            ds.Dispose()
        End Try
    End Sub

    Private Sub frmEntriJual_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

            'Refresh Data Salesman
            SQL = "SELECT NoID, Kode, Nama, Alamat FROM HKontak WHERE IsAktif=1 AND IsPegawai=1"
            EksekusiDataset(ds, "Data", SQL)
            txtSalesman.Properties.DataSource = ds.Tables("Data")
            txtSalesman.Properties.ValueMember = "NoID"
            txtSalesman.Properties.DisplayMember = "Nama"

            If pStatus = Status.Baru Then
                txtTanggal.DateTime = TanggalSystem
                txtJatuhTempo.DateTime = TanggalSystem
            Else
                SQL = "SELECT * FROM HJual WHERE NoID=" & NoID
                EksekusiDataset(ds, "Data", SQL)
                If ds.Tables("Data").Rows.Count >= 1 Then
                    txtKode.Text = NullToStr(ds.Tables("Data").Rows(0).Item("Kode"))
                    KodeLama = txtKode.Text
                    txtReff.Text = NullToStr(ds.Tables("Data").Rows(0).Item("Reff"))
                    txtKeterangan.Text = NullToStr(ds.Tables("Data").Rows(0).Item("Keterangan"))
                    txtSalesman.EditValue = NullToLong(ds.Tables("Data").Rows(0).Item("IDSalesman"))
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
            If System.IO.File.Exists(FolderLayouts & "\" & Me.Name & GVJual.Name & ".xml") Then
                GVJual.RestoreLayoutFromXml(FolderLayouts & "\" & Me.Name & GVJual.Name & ".xml")
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
            SQL = "SELECT HJualD.*, HBarang.Kode AS KodeBarang, HBarang.Nama AS NamaBarang, HSatuan.Kode AS Satuan, HSalesOrder.Kode AS Reff " & vbCrLf & _
                  " FROM HJualD " & vbCrLf & _
                  " LEFT JOIN HBarang ON HBarang.NoID=HJualD.IDBarang " & vbCrLf & _
                  " LEFT JOIN HSatuan ON HSatuan.NoID=HJualD.IDSatuan  " & vbCrLf & _
                  " LEFT JOIN (HSalesOrderD INNER JOIN HSalesOrder ON HSalesOrder.NoID=HSalesOrderD.IDHeader) ON HSalesOrderD.NoID=HJualD.IDSalesOrderD " & vbCrLf & _
                  " WHERE HJualD.IDHeader=" & NoID
            EksekusiDataset(ds, "Data", SQL)
            GCJual.DataSource = ds.Tables("Data")
            With GVJual
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
                txtKode.Text = MintaKodeBaru("JL", "HJual", txtTanggal.DateTime, 5)
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
            RefreshDataTransaksi()
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
                    NoID = GetNewID("HJual", "NoID")
                    SQL = "INSERT INTO [HJual] ([NoID],[Kode],[IDCustomer],[IDSalesman],[Tanggal],[TglTempo],[Reff],[Keterangan],[Total],[IDUserEntri],[TglEntri],[IDUserEdit],[TglEdit]) VALUES (" & vbCrLf & _
                          NoID & ", '" & FixApostropi(txtKode.Text) & "', " & NullToLong(txtIDCustomer.EditValue) & ", " & NullToLong(txtSalesman.EditValue) & ", '" & txtTanggal.DateTime.ToString("yyyy-MM-dd") & "', '" & txtJatuhTempo.DateTime.ToString("yyyy-MM-dd") & "', " & vbCrLf & _
                          "'" & FixApostropi(txtReff.Text) & "', '" & FixApostropi(txtKeterangan.Text) & "', " & FixKoma(txtTotal.EditValue) & ", " & IDUserAktif & ", GETDATE(), NULL, NULL)"
                    If EksekusiSQL(SQL) >= 1 Then
                        SQL = "DELETE FROM [HKartuStok] WHERE IDJenisTransaksi=2 AND IDTransaksi=" & NoID
                        EksekusiSQL(SQL)
                        SQL = "DELETE FROM [HKartuPiutang] WHERE IDJenisTransaksi=2 AND IDTransaksi=" & NoID
                        EksekusiSQL(SQL)
                        SQL = "DELETE FROM [HKartuPoin] WHERE IDJenisTransaksi=2 AND IDTransaksi=" & NoID
                        EksekusiSQL(SQL)

                        pStatus = Status.TempEdit
                        KodeLama = txtKode.Text
                        SetTombol()
                    End If
                Else
                    SQL = "UPDATE [HJual] SET " & vbCrLf & _
                          "[Kode]='" & FixApostropi(txtKode.Text) & "', [IDCustomer]=" & NullToLong(txtIDCustomer.EditValue) & ", [IDSalesman]=" & NullToLong(txtSalesman.EditValue) & ", [Tanggal]='" & txtTanggal.DateTime.ToString("yyyy-MM-dd") & "', [TglTempo]='" & txtJatuhTempo.DateTime.ToString("yyyy-MM-dd") & "', " & vbCrLf & _
                          "[Reff]='" & FixApostropi(txtReff.Text) & "', [Keterangan]='" & FixApostropi(txtKeterangan.Text) & "', [Total]=" & FixKoma(txtTotal.EditValue) & ", [Bayar]=" & FixKoma(txtBayar.EditValue) & ", [Sisa]=" & FixKoma(txtSisa.EditValue) & ", [IDUserEdit]=" & IDUserAktif & ", [TglEdit]=GETDATE() WHERE NoID=" & NoID
                    If EksekusiSQL(SQL) >= 1 Then
                        'Potong Stok
                        SQL = "DELETE FROM [HKartuStok] WHERE IDJenisTransaksi=2 AND IDTransaksi=" & NoID
                        EksekusiSQL(SQL)

                        SQL = "INSERT INTO [HKartuStok] ([IDKontak],[KodeReff],[Tanggal],[IDJenisTransaksi],[IDTransaksi],[IDBarang],[IDSatuan],[QtyMasuk],[QtyKeluar],[Konversi],[HPP],[HargaBeliTerakhir]) " & vbCrLf & _
                              " SELECT HJual.IDCustomer, HJual.Kode, HJual.Tanggal, 2 AS IDJenisTransaksi, HJual.NoID, HJualD.IDBarang, HJualD.IDSatuan, 0 AS QtyMasuk, HJualD.Qty AS QtyKeluar, HJualD.Konversi, HJualD.Harga, HJualD.Harga " & vbCrLf & _
                              " FROM HJualD INNER JOIN HJual ON HJual.NoID=HJualD.IDHeader " & vbCrLf & _
                              " WHERE HJualD.IDHeader=" & NoID
                        EksekusiSQL(SQL)

                        'Nambah Piutang
                        SQL = "DELETE FROM [HKartuPiutang] WHERE IDJenisTransaksi=2 AND IDTransaksi=" & NoID
                        EksekusiSQL(SQL)

                        SQL = "INSERT INTO [HKartuPiutang] ([IDKontak],[KodeReff],[Tanggal],[IDJenisTransaksi],[IDTransaksi],[SaldoMasuk],[SaldoKeluar]) " & vbCrLf & _
                              " SELECT HJual.IDCustomer, HJual.Kode, HJual.Tanggal, 2 AS IDJenisTransaksi, HJual.NoID, HJual.Sisa AS QtyMasuk, 0 AS QtyKeluar " & vbCrLf & _
                              " FROM HJual " & vbCrLf & _
                              " WHERE HJual.Sisa>0 AND HJual.NoID=" & NoID
                        EksekusiSQL(SQL)

                        'Hitung Nilai Poin
                        SQL = "SELECT * FROM HSettingPoin"
                        EksekusiDataset(ds, "Poin", SQL)
                        If ds.Tables("Poin").Rows.Count >= 1 Then
                            MinimumDapatPoin = NullToDbl(ds.Tables("Poin").Rows(0).Item("MinimumBelanjaDapatPoin"))
                            SyaratDapatPoin = NullToDbl(ds.Tables("Poin").Rows(0).Item("SyaratBelanjaDapatPoin"))
                            NilaiPoin = NullToDbl(ds.Tables("Poin").Rows(0).Item("NilaiPoin"))
                            IsKelipatan = NullToBool(ds.Tables("Poin").Rows(0).Item("IsKelipatan"))
                        End If

                        SQL = "SELECT SUM(HJualD.Jumlah) AS Jumlah FROM HJualD INNER JOIN HBarang ON HBarang.NoID=HJualD.IDBarang WHERE HBarang.IsPoin=1 AND HJualD.IDHeader=" & NoID
                        EksekusiDataset(ds, "BrgPoin", SQL)
                        If ds.Tables("BrgPoin").Rows.Count >= 1 Then
                            JumlahBrgPoin = NullToDbl(ds.Tables("BrgPoin").Rows(0).Item("Jumlah"))
                        End If
                        'Nambah Poin
                        SQL = "DELETE FROM [HKartuPoin] WHERE IDJenisTransaksi=2 AND IDTransaksi=" & NoID
                        EksekusiSQL(SQL)
                        If MinimumDapatPoin >= 1 AndAlso JumlahBrgPoin >= MinimumDapatPoin Then
                            If IsKelipatan Then
                                If JumlahBrgPoin >= SyaratDapatPoin AndAlso SyaratDapatPoin >= 1 Then
                                    Poin = Int(JumlahBrgPoin / SyaratDapatPoin) * NilaiPoin
                                Else
                                    Poin = 0
                                End If
                            Else
                                If JumlahBrgPoin >= SyaratDapatPoin AndAlso SyaratDapatPoin >= 1 Then
                                    Poin = NilaiPoin
                                Else
                                    Poin = 0
                                End If
                            End If
                            SQL = "UPDATE HJual SET TotalPoin=" & FixKoma(Poin) & " WHERE NoID=" & NoID
                            EksekusiSQL(SQL)

                            SQL = "INSERT INTO [HKartuPoin] ([IDCustomer],[KodeReff],[Tanggal],[IDJenisTransaksi],[IDTransaksi],[PoinMasuk],[PoinKeluar])" & vbCrLf & _
                                  " SELECT HJual.IDCustomer, HJual.Kode, HJual.Tanggal, 2 AS IDJenisTransaksi, HJual.NoID, HJual.TotalPoin AS QtyMasuk, 0 AS QtyKeluar " & vbCrLf & _
                                  " FROM HJual " & vbCrLf & _
                                  " WHERE ISNULL(HJual.TotalPoin,0)>0 AND HJual.NoID=" & NoID
                            EksekusiSQL(SQL)
                        Else
                            SQL = "UPDATE HJual SET TotalPoin=" & FixKoma(0) & " WHERE NoID=" & NoID
                            EksekusiSQL(SQL)
                        End If

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
        If txtSalesman.Text = "" Then
            XtraMessageBox.Show("Salesman masih kosong.", NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtSalesman.Focus()
            Hasil = False
            IsValidasi = False
            Exit Function
        End If
        If CekKodeValid(txtKode.Text, KodeLama, "HJual", "Kode", IIf(pStatus = Status.Baru, False, True)) Then
            XtraMessageBox.Show("Kode sudah dipakai.", NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtKode.Focus()
            Hasil = False
            IsValidasi = False
            Exit Function
        End If
        If pStatus <> Status.Baru AndAlso GVJual.RowCount <= 0 Then
            XtraMessageBox.Show("Item masih kosong.", NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            GVJual.Focus()
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
        Dim x As New frmEntriJualD(True, NoID)
        x.ShowInTaskbar = False
        x.StartPosition = FormStartPosition.CenterParent
        x.IDCustomer = NullToLong(txtIDCustomer.EditValue)
        If x.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            cmdRefresh.PerformClick()
            GVJual.ClearSelection()
            GVJual.FocusedRowHandle = GVJual.LocateByDisplayText(0, GVJual.Columns("NoID"), x.NoID.ToString("n0"))
            GVJual.SelectRow(GVJual.FocusedRowHandle)
        End If
        x.Dispose()
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        Dim x As New frmEntriJualD(False, NoID)
        x.NoID = NullToLong(GVJual.GetFocusedRowCellValue(GVJual.Columns("NoID")))
        x.ShowInTaskbar = False
        x.IDCustomer = NullToLong(txtIDCustomer.EditValue)
        x.StartPosition = FormStartPosition.CenterParent
        If x.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            cmdRefresh.PerformClick()
            GVJual.ClearSelection()
            GVJual.FocusedRowHandle = GVJual.LocateByDisplayText(0, GVJual.Columns("NoID"), x.NoID.ToString("n0"))
            GVJual.SelectRow(GVJual.FocusedRowHandle)
        End If
        x.Dispose()
    End Sub

    Private Sub cmdHapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHapus.Click
        Dim NoID As Long = NullToLong(GVJual.GetRowCellValue(GVJual.FocusedRowHandle, "NoID"))
        If XtraMessageBox.Show("Yakin ingin menghapus item Jual yang dipilih ini?", NamaAplikasi, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            EksekusiSQL("DELETE FROM HJualD WHERE NoID=" & NoID)
            RefreshData()
        End If
    End Sub
End Class