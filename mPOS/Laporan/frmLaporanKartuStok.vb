Imports System.Data
Imports System.Data.SqlClient
Imports DevExpress.XtraEditors
Imports DevExpress.Utils
Imports DevExpress.XtraEditors.Repository

Imports Elliteserv.Fungsi.Ini
Imports Elliteserv.Fungsi.Utils
Imports Elliteserv.SQLServer.Connect
Imports mPOS.clsCetakReportDevExpress


Public Class frmLaporanKartuStok
    Public FormName As String = Me.Name
    Public Judul As String = "Daftar "
    Public NoID As Long = -1

    Dim SQL As String = ""
    Dim repckedit As New RepositoryItemCheckEdit
    Dim repdateedit As New RepositoryItemDateEdit
    Dim reptextedit As New RepositoryItemTextEdit
    Dim reppicedit As New RepositoryItemPictureEdit
    Dim dsReport As New DataSet

    Private Sub frmDaftarMaster_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GridView1.SaveLayoutToXml(FolderLayouts & "\" & FormName & GridView1.Name & ".xml")
        LayoutControl1.SaveLayoutToXml(FolderLayouts & "\" & FormName & LayoutControl1.Name & ".xml")
    End Sub

    Private Sub RefreshDataKontak()
        Dim ds As New DataSet
        Try
            SQL = "SELECT HBarang.NoID, HBarang.Kode, HBarang.Nama, HSatuan.Kode AS Satuan, HBarang.HargaJual FROM HBarang LEFT JOIN HSatuan ON HSatuan.NOID=HBarang.IDSatuanJual WHERE HBarang.IsAktif=1 "
            EksekusiDataset(ds, "Data", SQL)
            txtIDBarang.Properties.DataSource = ds.Tables("Data")
            txtIDBarang.Properties.DisplayMember = "Kode"
            txtIDBarang.Properties.ValueMember = "NoID"
        Catch ex As Exception
            XtraMessageBox.Show("Info Kesalahan : " & ex.Message, NamaAplikasi, MessageBoxButtons.OK)
        Finally
            ds.Dispose()
        End Try
    End Sub

    Private Sub frmDaftarMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Text = Judul
        LabelControl1.Text = Judul.ToUpper

        RefreshDataKontak()
        DateEdit1.DateTime = TanggalSystem
        DateEdit2.DateTime = TanggalSystem
        RefreshData()

        If System.IO.File.Exists(FolderLayouts & "\" & FormName & LayoutControl1.Name & ".xml") Then
            LayoutControl1.RestoreLayoutFromXml(FolderLayouts & "\" & FormName & LayoutControl1.Name & ".xml")
        End If
        If System.IO.File.Exists(FolderLayouts & "\" & FormName & GridView1.Name & ".xml") Then
            GridView1.RestoreLayoutFromXml(FolderLayouts & "\" & FormName & GridView1.Name & ".xml")
        End If
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


    Private Sub RefreshData()
        Dim ds As New DataSet
        'Dim cn As New SqlConnection
        'Dim com As New SqlCommand
        'Dim oDA As New SqlDataAdapter
        Dim SaldoAwal As Double = 0
        Dim SaldoAkhir As Double = 0
        Try
            SQL = "SELECT HBarang.Kode, HBarang.Barcode, HBarang.Nama, HKartuStok.QtyMasuk*HKartuStok.Konversi AS QtyMasukPcs, HKartuStok.QtyKeluar*HKartuStok.Konversi AS QtyKeluarPcs, HJenisTransaksi.Nama AS JenisTransaksi, HKartuStok.*, HSatuan.Kode AS Satuan, 0 AS SaldoAwal, 0 AS SaldoAkhir" & vbCrLf & _
                  " FROM HKartuStok " & vbCrLf & _
                  " INNER JOIN HBarang ON HBarang.NoID=HKartuStok.IDBarang " & vbCrLf & _
                  " INNER JOIN HJenisTransaksi ON HJenisTransaksi.NoID=HKartuStok.IDJenisTransaksi " & vbCrLf & _
                  " LEFT JOIN HKontak ON HKontak.NoID=HKartuStok.IDKontak " & vbCrLf & _
                  " LEFT JOIN HSatuan ON HSatuan.NoID=HKartuStok.IDSatuan  " & vbCrLf & _
                  " WHERE HKartuStok.Tanggal>='" & DateEdit1.DateTime.ToString("yyyy-MM-dd") & "' AND HKartuStok.Tanggal<'" & DateEdit2.DateTime.AddDays(1).ToString("yyyy-MM-dd") & "' AND HKartuStok.IDBarang=" & NullToLong(txtIDBarang.EditValue) & vbCrLf & _
                  " ORDER BY CONVERT(DATE, HKartuStok.Tanggal), HJenisTransaksi.NoUrut"
            EksekusiDataset(ds, "Data", SQL)
            GridControl1.DataSource = ds.Tables("Data")
            dsReport = ds
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
                            .Columns(i).DisplayFormat.FormatString = "dd-MM-yyyy"
                        Case "byte[]"
                            reppicedit.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze
                            .Columns(i).OptionsColumn.AllowGroup = False
                            .Columns(i).OptionsColumn.AllowSort = False
                            .Columns(i).OptionsFilter.AllowFilter = False
                            .Columns(i).ColumnEdit = reppicedit
                        Case "boolean"
                            .Columns(i).ColumnEdit = repckedit
                    End Select
                    .ShowFindPanel()
                Next
            End With

            'Hitung Saldo
            SQL = "SELECT SUM((HKartuStok.QtyMasuk-HKartuStok.QtyKeluar)*HKartuStok.Konversi) " & vbCrLf & _
                  " FROM HKartuStok " & vbCrLf & _
                  " WHERE HKartuStok.Tanggal<'" & DateEdit1.DateTime.ToString("yyyy-MM-dd") & "' AND HKartuStok.IDBarang=" & NullToLong(txtIDBarang.EditValue)
            SaldoAwal = NullToDbl(EksekusiScalar(SQL))
            SaldoAkhir = 0
            txtSaldoAwal.EditValue = SaldoAwal
            For i As Integer = 0 To GridView1.RowCount - 1
                If i <> 0 Then
                    SaldoAwal = SaldoAkhir
                End If
                SaldoAkhir = SaldoAwal + NullToDbl(GridView1.GetRowCellValue(i, "QtyMasukPcs")) - NullToDbl(GridView1.GetRowCellValue(i, "QtyKeluarPcs"))
                GridView1.SetRowCellValue(i, "SaldoAwal", SaldoAwal)
                GridView1.SetRowCellValue(i, "SaldoAkhir", SaldoAkhir)
            Next
            txtSaldoAkhir.EditValue = SaldoAkhir
        Catch ex As Exception
            XtraMessageBox.Show("Info Kesalahan : " & ex.Message, NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            'If cn.State = ConnectionState.Open Then
            '    cn.Close()
            'End If
            'cn.Dispose()
            'com.Dispose()
            'oDA.Dispose()
            ds.Dispose()
        End Try
    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        RefreshData()
    End Sub

    Private Sub cmdHapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHapus.Click
        
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        
    End Sub

    Private Sub cmdBaru_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBaru.Click
        
    End Sub

    Private Sub cmdPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPreview.Click
        Dim NamaFile As String = Application.StartupPath & "\Report\LaporanKartuStok.repx"
        Try
            ViewXtraReport(Me.MdiParent, IIf(IsEditReport, Action_.Edit, Action_.Preview), NamaFile, "Kartu Stok", "LaporanKartuStok.repx", dsReport, "A4", "TglDari=Datetime=#" & DateEdit1.DateTime.ToString("yyyy-MM-dd") & "#|TglSampai=Datetime=#" & DateEdit2.DateTime.ToString("yyyy-MM-dd") & "#|KodeBarang=String='" & FixApostropi(txtIDBarang.Text) & "'|NamaBarang=String='" & FixApostropi(txtNamaBarang.Text) & "'|SAw=Double=" & FixKoma(txtSaldoAwal.EditValue) & "|SAk=Double=" & FixKoma(txtSaldoAkhir.EditValue) & "")
        Catch ex As Exception
            XtraMessageBox.Show("Info Kesalahan : " & ex.Message, NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub cmdCetakFaktur_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCetakFaktur.Click
        
    End Sub

    Private Sub txtIDBarang_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIDBarang.EditValueChanged
        Dim ds As New DataSet
        Try
            SQL = "SELECT * FROM HBarang WHERE NoID=" & NullToLong(txtIDBarang.EditValue)
            EksekusiDataset(ds, "Data", SQL)
            If ds.Tables("Data").Rows.Count >= 1 Then
                txtNamaBarang.Text = NullToStr(ds.Tables("Data").Rows(0).Item("Nama"))
            Else
                txtNamaBarang.Text = ""
            End If
        Catch ex As Exception
        Finally
            ds.Dispose()
        End Try
    End Sub
End Class