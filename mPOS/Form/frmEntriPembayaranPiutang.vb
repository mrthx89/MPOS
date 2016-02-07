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
    Dim repJenisPembayaran As New RepositoryItemSearchLookUpEdit

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        If pStatus = Status.Edit Then 'Harus Disimpan
            cmdSave.PerformClick()
        ElseIf pStatus = Status.TempEdit Then 'Hapus Total
            SQL = "DELETE FROM [HBayarPiutang] WHERE NoID=" & NoID
            EksekusiSQL(SQL)
            SQL = "DELETE FROM [HBayarPiutangDJual] WHERE IDBayarPiutang=" & NoID
            EksekusiSQL(SQL)
            SQL = "DELETE FROM [HBayarPiutangDReturJual] WHERE IDBayarPiutang=" & NoID
            EksekusiSQL(SQL)
            SQL = "DELETE FROM [HBayarPiutangDNotaDebet] WHERE IDBayarPiutang=" & NoID
            EksekusiSQL(SQL)
            SQL = "DELETE FROM [HBayarPiutangDNotaKredit] WHERE IDBayarPiutang=" & NoID
            EksekusiSQL(SQL)
            SQL = "DELETE FROM [HBayarPiutangDPembayaran] WHERE IDBayarPiutang=" & NoID
            EksekusiSQL(SQL)
            SQL = "DELETE FROM [HKartuPiutang] WHERE IDJenisTransaksi=9 AND IDTransaksi=" & NoID
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
            GVJual.OptionsBehavior.Editable = False
            GVReturJual.OptionsBehavior.Editable = False
            GVNotaDebet.OptionsBehavior.Editable = False
            GVNotaKredit.OptionsBehavior.Editable = False
            GVPembayaran.OptionsBehavior.Editable = False
        Else
            GVJual.OptionsBehavior.Editable = True
            GVReturJual.OptionsBehavior.Editable = True
            GVNotaDebet.OptionsBehavior.Editable = True
            GVNotaKredit.OptionsBehavior.Editable = True
            GVPembayaran.OptionsBehavior.Editable = True
        End If
    End Sub

    Private Sub frmEntriJual_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If pStatus = Status.Baru Then
                LayoutControl1.SaveLayoutToXml(FolderLayouts & "\" & Me.Name & LayoutControl1.Name & ".xml")
                GVJual.SaveLayoutToXml(FolderLayouts & "\" & Me.Name & GVJual.Name & ".xml")
                GVReturJual.SaveLayoutToXml(FolderLayouts & "\" & Me.Name & GVReturJual.Name & ".xml")
                GVNotaDebet.SaveLayoutToXml(FolderLayouts & "\" & Me.Name & GVNotaDebet.Name & ".xml")
                GVNotaKredit.SaveLayoutToXml(FolderLayouts & "\" & Me.Name & GVNotaKredit.Name & ".xml")
                GVPembayaran.SaveLayoutToXml(FolderLayouts & "\" & Me.Name & GVPembayaran.Name & ".xml")
            ElseIf pStatus = Status.Edit Then
                e.Cancel = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RefreshDataTransaksi(Optional ByVal HitungPendukung As Boolean = True)
        Dim ds As New DataSet
        Try
            'Refresh Data Penjualan
            SQL = "SELECT * FROM [dbo].[fn_DataPiutang] ('Penjualan', " & NoID & ", " & NullToLong(txtIDCustomer.EditValue) & ")"
            EksekusiDataset(ds, "Data", SQL)
            GCJual.DataSource = ds.Tables("Data")

            'Refresh Data Retur Penjualan
            SQL = "SELECT * FROM [dbo].[fn_DataPiutang] ('Retur Penjualan', " & NoID & ", " & NullToLong(txtIDCustomer.EditValue) & ")"
            EksekusiDataset(ds, "Data", SQL)
            GCReturJual.DataSource = ds.Tables("Data")

            If HitungPendukung Then
                'Refresh Data Nota Debet
                SQL = "SELECT A.NoID, A.Keterangan, A.Total" & vbCrLf & _
                      " FROM HBayarPiutangDNotaDebet AS A WHERE A.IDBayarPiutang=" & NoID
                EksekusiDataset(ds, "Data", SQL)
                GCNotaDebet.DataSource = ds.Tables("Data")

                'Refresh Data Nota Kredit
                SQL = "SELECT A.NoID, A.Keterangan, A.Total" & vbCrLf & _
                      " FROM HBayarPiutangDNotaKredit AS A WHERE A.IDBayarPiutang=" & NoID
                EksekusiDataset(ds, "Data", SQL)
                GCNotaKredit.DataSource = ds.Tables("Data")

                'Refresh Data Pembayaran
                SQL = "SELECT A.*" & vbCrLf & _
                      " FROM HBayarPiutangDPembayaran AS A WHERE A.IDBayarPiutang=" & NoID
                EksekusiDataset(ds, "Data", SQL)
                GCPembayaran.DataSource = ds.Tables("Data")
            End If

            HitungTotal()
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

            'Refresh Data Pembayaran
            SQL = "SELECT 1 AS NoID, 'Tunai' AS Pembayaran" & vbCrLf & _
                  " UNION ALL" & vbCrLf & _
                  " SELECT 2 AS NoID, 'Bank Mandiri' AS Pembayaran" & vbCrLf & _
                  " UNION ALL" & vbCrLf & _
                  " SELECT 3 AS NoID, 'Bank BCA' AS Pembayaran" & vbCrLf & _
                  " UNION ALL" & vbCrLf & _
                  " SELECT 4 AS NoID, 'Giro' AS Pembayaran" & vbCrLf & _
                  " UNION ALL" & vbCrLf & _
                  " SELECT 5 AS NoID, 'Lain-lain' AS Pembayaran"
            EksekusiDataset(ds, "Data", SQL)
            repJenisPembayaran.DataSource = ds.Tables("Data")
            repJenisPembayaran.ValueMember = "NoID"
            repJenisPembayaran.DisplayMember = "Pembayaran"

            With reptextedit
                .Mask.MaskType = Mask.MaskType.Numeric
                .Mask.EditMask = "n0"
                .Mask.UseMaskAsDisplayFormat = True
            End With

            With repdateedit
                .Mask.MaskType = Mask.MaskType.DateTimeAdvancingCaret
                .Mask.EditMask = "dd-MM-yyyy"
                .Mask.UseMaskAsDisplayFormat = True
            End With

            If pStatus = Status.Baru Then
                txtTanggal.DateTime = TanggalSystem
                txtJatuhTempo.DateTime = TanggalSystem
                txtIDCustomer.EditValue = 0
            Else
                SQL = "SELECT * FROM HBayarPiutang WHERE NoID=" & NoID
                EksekusiDataset(ds, "Data", SQL)
                If ds.Tables("Data").Rows.Count >= 1 Then
                    txtKode.Text = NullToStr(ds.Tables("Data").Rows(0).Item("Kode"))
                    KodeLama = txtKode.Text
                    txtReff.Text = NullToStr(ds.Tables("Data").Rows(0).Item("Reff"))
                    txtKeterangan.Text = NullToStr(ds.Tables("Data").Rows(0).Item("Keterangan"))
                    txtIDCustomer.EditValue = NullToLong(ds.Tables("Data").Rows(0).Item("IDCustomer"))
                    txtIDCustomer.Properties.ReadOnly = True
                    txtTanggal.DateTime = NullToDate(ds.Tables("Data").Rows(0).Item("Tanggal"))
                    txtJatuhTempo.DateTime = NullToDate(ds.Tables("Data").Rows(0).Item("TglTempo"))
                End If
            End If
            RefreshDataTransaksi()
            SetTombol()
            If System.IO.File.Exists(FolderLayouts & "\" & Me.Name & LayoutControl1.Name & ".xml") Then
                LayoutControl1.RestoreLayoutFromXml(FolderLayouts & "\" & Me.Name & LayoutControl1.Name & ".xml")
            End If
            If System.IO.File.Exists(FolderLayouts & "\" & Me.Name & GVJual.Name & ".xml") Then
                GVJual.RestoreLayoutFromXml(FolderLayouts & "\" & Me.Name & GVJual.Name & ".xml")
            End If
            If System.IO.File.Exists(FolderLayouts & "\" & Me.Name & GVNotaDebet.Name & ".xml") Then
                GVNotaDebet.RestoreLayoutFromXml(FolderLayouts & "\" & Me.Name & GVNotaDebet.Name & ".xml")
            End If
            If System.IO.File.Exists(FolderLayouts & "\" & Me.Name & GVNotaKredit.Name & ".xml") Then
                GVNotaKredit.RestoreLayoutFromXml(FolderLayouts & "\" & Me.Name & GVNotaKredit.Name & ".xml")
            End If
            If System.IO.File.Exists(FolderLayouts & "\" & Me.Name & GVReturJual.Name & ".xml") Then
                GVReturJual.RestoreLayoutFromXml(FolderLayouts & "\" & Me.Name & GVReturJual.Name & ".xml")
            End If
            If System.IO.File.Exists(FolderLayouts & "\" & Me.Name & GVPembayaran.Name & ".xml") Then
                GVPembayaran.RestoreLayoutFromXml(FolderLayouts & "\" & Me.Name & GVPembayaran.Name & ".xml")
            End If

            FormatingGridView(GVJual)
            FormatingGridView(GVReturJual)
            FormatingGridView(GVNotaDebet)
            FormatingGridView(GVNotaKredit)
            FormatingGridView(GVPembayaran)

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

    Private Sub FormatingGridView(ByVal GridView As DevExpress.XtraGrid.Views.Grid.GridView)
        With GridView
            For i As Integer = 0 To .Columns.Count - 1
                Select Case .Columns(i).ColumnType.Name.ToLower
                    Case "int32", "int64", "int"
                        .Columns(i).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        .Columns(i).DisplayFormat.FormatString = "n0"
                    Case "decimal", "single", "money", "double"
                        .Columns(i).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        .Columns(i).DisplayFormat.FormatString = "n0"
                        .Columns(i).ColumnEdit = reptextedit
                    Case "string"
                        .Columns(i).DisplayFormat.FormatType = DevExpress.Utils.FormatType.None
                        .Columns(i).DisplayFormat.FormatString = ""
                    Case "date"
                        .Columns(i).DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                        .Columns(i).DisplayFormat.FormatString = "dd-MM-yyyy"
                        .Columns(i).ColumnEdit = repdateedit
                    Case "datetime"
                        .Columns(i).DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                        .Columns(i).DisplayFormat.FormatString = "dd-MM-yyyy"
                        .Columns(i).ColumnEdit = repdateedit
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
                If .Name.ToLower = "GVPembayaran".ToLower AndAlso .Columns(i).FieldName.ToLower = "IDJenisPembayaran".ToLower Then
                    .Columns(i).Caption = "Jenis Pembayaran"
                    .Columns(i).ColumnEdit = repJenisPembayaran
                End If
            Next
        End With
    End Sub

    Private Sub HitungTotal()
        Dim Total As Double = 0, Bayar As Double = 0

        For i As Integer = 0 To GVJual.RowCount - 1
            Total += NullToDbl(GVJual.GetRowCellValue(i, "Bayar"))
        Next
        For i As Integer = 0 To GVReturJual.RowCount - 1
            Total -= NullToDbl(GVReturJual.GetRowCellValue(i, "Bayar"))
        Next
        For i As Integer = 0 To GVNotaDebet.RowCount - 1
            Total += NullToDbl(GVNotaDebet.GetRowCellValue(i, "Total"))
        Next
        For i As Integer = 0 To GVNotaKredit.RowCount - 1
            Total -= NullToDbl(GVNotaKredit.GetRowCellValue(i, "Total"))
        Next
        For i As Integer = 0 To GVPembayaran.RowCount - 1
            Bayar += NullToDbl(GVPembayaran.GetRowCellValue(i, "Total"))
        Next
        txtTotal.EditValue = Total
        txtBayar.EditValue = Bayar
        txtSisa.EditValue = txtTotal.EditValue - txtBayar.EditValue
    End Sub

    Private Sub txtTanggal_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTanggal.EditValueChanged
        Try
            If pStatus = Status.Baru Or pStatus = Status.TempEdit Then
                txtKode.Text = MintaKodeBaru("JL", "HBayarPiutang", txtTanggal.DateTime, 5)
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

        Try
            dlg.ShowInTaskbar = False
            dlg.TopMost = True
            dlg.Show()
            dlg.Focus()
            Cursor = Cursors.WaitCursor
            RefreshDataTransaksi(False)
            If IsValidasi() Then
                If pStatus = Status.Baru Then
                    NoID = GetNewID("HBayarPiutang", "NoID")
                    SQL = "INSERT INTO [dbo].[HBayarPiutang] ([NoID],[Kode],[IDCustomer],[Tanggal],[TglTempo],[Reff],[Keterangan],[Total],[IDUserEntri],[TglEntri],[IDUserEdit],[TglEdit]) VALUES (" & vbCrLf & _
                          NoID & ", '" & FixApostropi(txtKode.Text) & "', " & NullToLong(txtIDCustomer.EditValue) & ", '" & txtTanggal.DateTime.ToString("yyyy-MM-dd") & "', '" & txtJatuhTempo.DateTime.ToString("yyyy-MM-dd") & "', " & vbCrLf & _
                          "'" & FixApostropi(txtReff.Text) & "', '" & FixApostropi(txtKeterangan.Text) & "', " & FixKoma(txtTotal.EditValue) & ", " & IDUserAktif & ", GETDATE(), NULL, NULL)"
                    If EksekusiSQL(SQL) >= 1 Then
                        SQL = "DELETE FROM [HBayarPiutangDJual] WHERE IDBayarPiutang=" & NoID
                        EksekusiSQL(SQL)
                        SQL = "DELETE FROM [HBayarPiutangDReturJual] WHERE IDBayarPiutang=" & NoID
                        EksekusiSQL(SQL)
                        SQL = "DELETE FROM [HBayarPiutangDNotaDebet] WHERE IDBayarPiutang=" & NoID
                        EksekusiSQL(SQL)
                        SQL = "DELETE FROM [HBayarPiutangDNotaKredit] WHERE IDBayarPiutang=" & NoID
                        EksekusiSQL(SQL)
                        SQL = "DELETE FROM [HBayarPiutangDPembayaran] WHERE IDBayarPiutang=" & NoID
                        EksekusiSQL(SQL)
                        SQL = "DELETE FROM [HKartuPiutang] WHERE IDJenisTransaksi=9 AND IDTransaksi=" & NoID
                        EksekusiSQL(SQL)

                        txtIDCustomer.Properties.ReadOnly = True
                        pStatus = Status.TempEdit
                        KodeLama = txtKode.Text
                        SetTombol()
                    End If
                Else
                    SQL = "UPDATE [HBayarPiutang] SET " & vbCrLf & _
                          "[Kode]='" & FixApostropi(txtKode.Text) & "', [IDCustomer]=" & NullToLong(txtIDCustomer.EditValue) & ", [Tanggal]='" & txtTanggal.DateTime.ToString("yyyy-MM-dd") & "', [TglTempo]='" & txtJatuhTempo.DateTime.ToString("yyyy-MM-dd") & "', " & vbCrLf & _
                          "[Reff]='" & FixApostropi(txtReff.Text) & "', [Keterangan]='" & FixApostropi(txtKeterangan.Text) & "', [Total]=" & FixKoma(txtTotal.EditValue) & ", [IDUserEdit]=" & IDUserAktif & ", [TglEdit]=GETDATE() WHERE NoID=" & NoID
                    If EksekusiSQL(SQL) >= 1 Then
                        SQL = "DELETE FROM [HBayarPiutangDNotaDebet] WHERE IDBayarPiutang=" & NoID
                        EksekusiSQL(SQL)
                        For i As Integer = 0 To GVNotaDebet.RowCount - 1
                            SQL = "INSERT INTO [dbo].[HBayarPiutangDNotaDebet] ([IDBayarPiutang],[Tanggal],[Total],[Keterangan]) VALUES (" & NoID & ", " & vbCrLf & _
                            "GETDATE(), " & FixKoma(GVNotaDebet.GetRowCellValue(i, "Total")) & ", '" & FixApostropi(GVNotaDebet.GetRowCellValue(i, "Keterangan")) & "')"
                            EksekusiSQL(SQL)
                        Next

                        SQL = "DELETE FROM [HBayarPiutangDNotaKredit] WHERE IDBayarPiutang=" & NoID
                        EksekusiSQL(SQL)
                        For i As Integer = 0 To GVNotaKredit.RowCount - 1
                            SQL = "INSERT INTO [dbo].[HBayarPiutangDNotaKredit] ([IDBayarPiutang],[Tanggal],[Total],[Keterangan]) VALUES (" & NoID & ", " & vbCrLf & _
                            "GETDATE(), " & FixKoma(GVNotaKredit.GetRowCellValue(i, "Total")) & ", '" & FixApostropi(GVNotaKredit.GetRowCellValue(i, "Keterangan")) & "')"
                            EksekusiSQL(SQL)
                        Next

                        SQL = "DELETE FROM [HBayarPiutangDPembayaran] WHERE IDBayarPiutang=" & NoID
                        EksekusiSQL(SQL)
                        For i As Integer = 0 To GVPembayaran.RowCount - 1
                            SQL = "INSERT INTO [dbo].[HBayarPiutangDPembayaran] ([IDBayarPiutang],[Tanggal],[IDJenisPembayaran],[Total],[KodeReff],[Keterangan]) VALUES (" & NoID & ", " & vbCrLf & _
                            "GETDATE(), " & NullToLong(GVPembayaran.GetRowCellValue(i, "IDJenisPembayaran")) & ", " & FixKoma(GVPembayaran.GetRowCellValue(i, "Total")) & ", '" & FixApostropi(NullToStr(GVPembayaran.GetRowCellValue(i, "KodeReff"))) & "', '" & FixApostropi(NullToStr(GVPembayaran.GetRowCellValue(i, "Keterangan"))) & "')"
                            EksekusiSQL(SQL)
                        Next

                        'Kurangi Piutang
                        SQL = "DELETE FROM [HKartuPiutang] WHERE IDJenisTransaksi=2 AND IDTransaksi=" & NoID
                        EksekusiSQL(SQL)

                        SQL = "INSERT INTO [HKartuPiutang] ([IDKontak],[KodeReff],[Tanggal],[IDJenisTransaksi],[IDTransaksi],[SaldoMasuk],[SaldoKeluar]) " & vbCrLf & _
                              " SELECT HBayarPiutang.IDCustomer, HBayarPiutang.Kode, HBayarPiutang.Tanggal, 2 AS IDJenisTransaksi, HBayarPiutang.NoID, 0 AS QtyMasuk, " & FixKoma(txtBayar.EditValue) & " AS QtyKeluar " & vbCrLf & _
                              " FROM HBayarPiutang " & vbCrLf & _
                              " WHERE " & FixKoma(txtBayar.EditValue) & ">0 AND HBayarPiutang.NoID=" & NoID
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
        If CekKodeValid(txtKode.Text, KodeLama, "HBayarPiutang", "Kode", IIf(pStatus = Status.Baru, False, True)) Then
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
        If pStatus <> Status.Baru AndAlso txtTotal.EditValue <> txtBayar.EditValue Then
            XtraMessageBox.Show("Pembayaran masih belum sesuai.", NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            GVPembayaran.Focus()
            Hasil = False
            IsValidasi = False
            Exit Function
        End If
        Return Hasil
    End Function

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        RefreshDataTransaksi()
    End Sub

    Private Sub GVJual_CellValueChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVJual.CellValueChanged
        Select Case e.Column.FieldName.ToLower
            Case "Bayar".ToLower
                Dim Sisa As Double = NullToDbl(GVJual.GetFocusedRowCellValue(GVJual.Columns("Total"))) - NullToDbl(e.Value)
                If Sisa >= 0 Then
                    GVJual.SetFocusedRowCellValue("Sisa", NullToDbl(GVJual.GetFocusedRowCellValue(GVJual.Columns("Total"))) - NullToDbl(e.Value))
                    EksekusiSQL("UPDATE HBayarPiutangDJual SET Bayar=" & FixKoma(e.Value) & ", Sisa=Total-" & FixKoma(e.Value) & " WHERE IDBayarPiutang=" & NoID & " AND IDJual=" & NullToLong(GVJual.GetFocusedRowCellValue(GVJual.Columns("NoID"))))
                    HitungTotal()
                Else
                    GVJual.SetFocusedRowCellValue("Bayar", 0)
                End If
        End Select
    End Sub

    Private Sub GVReturJual_CellValueChanging(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVReturJual.CellValueChanging
        Select Case e.Column.FieldName.ToLower
            Case "Bayar".ToLower
                Dim Sisa As Double = NullToDbl(GVReturJual.GetFocusedRowCellValue(GVReturJual.Columns("Total"))) - NullToDbl(e.Value)
                If Sisa >= 0 Then
                    GVReturJual.SetFocusedRowCellValue("Sisa", NullToDbl(GVReturJual.GetFocusedRowCellValue(GVReturJual.Columns("Total"))) - NullToDbl(e.Value))
                    EksekusiSQL("UPDATE HBayarPiutangDReturJual SET Bayar=" & FixKoma(e.Value) & ", Sisa=Total-" & FixKoma(e.Value) & " WHERE IDBayarPiutang=" & NoID & " AND IDReturJual=" & NullToLong(GVReturJual.GetFocusedRowCellValue(GVReturJual.Columns("NoID"))))
                    HitungTotal()
                Else
                    GVReturJual.SetFocusedRowCellValue("Bayar", 0)
                End If
        End Select
    End Sub

    Private Sub GVLainnya_CellValueChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GVNotaDebet.CellValueChanged, GVNotaKredit.CellValueChanged, GVPembayaran.CellValueChanged
        Select Case e.Column.FieldName.ToLower
            Case "Bayar".ToLower, "Total".ToLower
                HitungTotal()
        End Select
    End Sub

    Private Sub GridView_FocusedColumnChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs) Handles GVJual.FocusedColumnChanged, _
    GVNotaDebet.FocusedColumnChanged, GVNotaKredit.FocusedColumnChanged, GVReturJual.FocusedColumnChanged, GVPembayaran.FocusedColumnChanged
        Select Case e.FocusedColumn.FieldName.ToLower
            Case "Bayar".ToLower, "Keterangan".ToLower, _
            "IDJenisPembayaran".ToLower, "KodeReff".ToLower
                sender.OptionsBehavior.Editable = True
            Case "Total".ToLower, "Tanggal".ToLower
                If sender.Name.ToLower = "GVJual".ToLower Then
                    sender.OptionsBehavior.Editable = False
                ElseIf GVJual.Name.ToLower = "GVReturJual".ToLower Then
                    sender.OptionsBehavior.Editable = False
                Else
                    sender.OptionsBehavior.Editable = True
                End If
            Case Else
                sender.OptionsBehavior.Editable = False
        End Select
    End Sub

    Private Sub GridView_FocusedRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GVJual.FocusedRowChanged, _
    GVNotaDebet.FocusedRowChanged, GVNotaKredit.FocusedRowChanged, GVPembayaran.FocusedRowChanged, GVReturJual.FocusedRowChanged
        Select Case sender.FocusedColumn.FieldName.ToLower
            Case "Bayar".ToLower, "Keterangan".ToLower, _
            "IDJenisPembayaran".ToLower, "KodeReff".ToLower
                sender.OptionsBehavior.Editable = True
            Case "Total".ToLower, "Tanggal".ToLower
                If sender.Name.ToLower = "GVJual".ToLower Then
                    sender.OptionsBehavior.Editable = False
                ElseIf sender.Name.ToLower = "GVReturJual".ToLower Then
                    sender.OptionsBehavior.Editable = False
                Else
                    sender.OptionsBehavior.Editable = True
                End If
            Case Else
                sender.OptionsBehavior.Editable = False
        End Select
    End Sub

    Private Sub GCJual_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GCJual.DoubleClick
        Try
            GVJual.SetRowCellValue(GVJual.FocusedRowHandle, "Bayar", GVJual.GetRowCellValue(GVJual.FocusedRowHandle, "Total"))
            GVJual.SetRowCellValue(GVJual.FocusedRowHandle, "Sisa", 0)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GCReturJual_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GCReturJual.DoubleClick
        Try
            GVReturJual.SetRowCellValue(GVReturJual.FocusedRowHandle, "Bayar", GVReturJual.GetRowCellValue(GVReturJual.FocusedRowHandle, "Total"))
            GVReturJual.SetRowCellValue(GVReturJual.FocusedRowHandle, "Sisa", 0)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GCNotaKredit_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GCNotaKredit.DoubleClick
        Try
            For i As Integer = 0 To GVNotaKredit.RowCount - 1
                If NullToStr(GVNotaKredit.GetRowCellValue(i, "Keterangan")) = "" Or NullToDbl(GVNotaKredit.GetRowCellValue(i, "Total")) = 0 Then
                    Exit Try
                End If
            Next
            GVNotaKredit.AddNewRow()
            GVNotaKredit.ClearSelection()
            GVNotaKredit.FocusedRowHandle = GVNotaKredit.RowCount - 1
            GVNotaKredit.SelectRow(GVNotaKredit.RowCount - 1)
            GVNotaKredit.SetRowCellValue(GVNotaKredit.RowCount - 1, "Total", 0)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GCNotaDebet_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GCNotaDebet.DoubleClick
        Try
            For i As Integer = 0 To GVNotaDebet.RowCount - 1
                If NullToStr(GVNotaDebet.GetRowCellValue(i, "Keterangan")) = "" Or NullToDbl(GVNotaDebet.GetRowCellValue(i, "Total")) = 0 Then
                    Exit Try
                End If
            Next
            GVNotaDebet.AddNewRow()
            GVNotaDebet.ClearSelection()
            GVNotaDebet.FocusedRowHandle = GVNotaDebet.RowCount - 1
            GVNotaDebet.SelectRow(GVNotaDebet.RowCount - 1)
            GVNotaDebet.SetRowCellValue(GVNotaDebet.RowCount - 1, "Total", 0)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GCPembayaran_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GCPembayaran.DoubleClick
        Try
            For i As Integer = 0 To GVPembayaran.RowCount - 1
                If NullToStr(GVPembayaran.GetRowCellValue(i, "Tanggal")) = "" Or NullToDbl(GVPembayaran.GetRowCellValue(i, "Total")) = 0 Or NullToDbl(GVPembayaran.GetRowCellValue(i, "IDJenisPembayaran")) = 0 Then
                    Exit Try
                End If
            Next
            GVPembayaran.AddNewRow()
            GVPembayaran.ClearSelection()
            GVPembayaran.FocusedRowHandle = GVPembayaran.RowCount - 1
            GVPembayaran.SelectRow(GVPembayaran.RowCount - 1)
            GVPembayaran.SetRowCellValue(GVPembayaran.RowCount - 1, "Tanggal", Now())
            GVPembayaran.SetRowCellValue(GVPembayaran.RowCount - 1, "IDJenisPembayaran", 1)
            GVPembayaran.SetRowCellValue(GVPembayaran.RowCount - 1, "Total", 0)
        Catch ex As Exception

        End Try
    End Sub
End Class