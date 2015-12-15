Imports System.Data
Imports System.Data.SqlClient
Imports DevExpress.XtraEditors
Imports DevExpress.Utils
Imports DevExpress.XtraEditors.Repository

Imports Elliteserv.Fungsi.Ini
Imports Elliteserv.Fungsi.Utils
Imports Elliteserv.SQLServer.Connect
Imports mPOS.clsCetakReportDevExpress


Public Class frmLaporanSaldoStok
    Public FormName As String = Me.Name
    Public Judul As String = "Daftar "
    Public NoID As Long = -1

    Dim SQL As String = ""
    Dim repckedit As New RepositoryItemCheckEdit
    Dim repdateedit As New RepositoryItemDateEdit
    Dim reptextedit As New RepositoryItemTextEdit
    Dim reppicedit As New RepositoryItemPictureEdit

    Private Sub frmDaftarMaster_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GridView1.SaveLayoutToXml(FolderLayouts & "\" & FormName & GridView1.Name & ".xml")
        LayoutControl1.SaveLayoutToXml(FolderLayouts & "\" & FormName & LayoutControl1.Name & ".xml")
    End Sub

    Private Sub RefreshDataKontak()
        Dim ds As New DataSet
        Try
            SQL = "SELECT HKategori.NoID, HKategori.Kode, HKategori.Nama FROM HKategori WHERE HKategori.IsAktif=1 "
            EksekusiDataset(ds, "Data", SQL)
            txtIDKategori.Properties.DataSource = ds.Tables("Data")
            txtIDKategori.Properties.DisplayMember = "Kode"
            txtIDKategori.Properties.ValueMember = "NoID"

            SQL = "SELECT NoID, Kode, Nama, Alamat FROM HKontak WHERE IsAktif=1 AND IsSupplier=1"
            EksekusiDataset(ds, "Data", SQL)
            txtIDSupplier.Properties.DataSource = ds.Tables("Data")
            txtIDSupplier.Properties.ValueMember = "NoID"
            txtIDSupplier.Properties.DisplayMember = "Kode"
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
        Try
            SQL = "SELECT HBarang.*, HSupplier1.Nama AS Supplier1, HSupplier2.Nama AS Supplier2, HSupplier3.Nama AS Supplier3, HKategori.Nama AS Kategori, " & vbCrLf & _
                  " HSatuan.Kode AS Satuan, " & vbCrLf & _
                  " ISNULL((SELECT SUM((HKartuStok.QtyMasuk-HKartuStok.QtyKeluar)*HKartuStok.Konversi) FROM HKartuStok WHERE HKartuStok.IDBarang=HBarang.NoID AND HKartuStok.Tanggal<'" & DateEdit1.DateTime.AddDays(1).ToString("yyyy-MM-dd") & "'),0) AS TotalQty " & vbCrLf & _
                  " FROM HBarang" & vbCrLf & _
                  " LEFT JOIN HKategori ON HKategori.NoID=HBarang.IDKategori" & vbCrLf & _
                  " LEFT JOIN HKontak HSupplier1 ON HSupplier1.NoID=HBarang.IDSupplier1" & vbCrLf & _
                  " LEFT JOIN HKontak HSupplier2 ON HSupplier1.NoID=HBarang.IDSupplier2" & vbCrLf & _
                  " LEFT JOIN HKontak HSupplier3 ON HSupplier1.NoID=HBarang.IDSupplier3" & vbCrLf & _
                  " LEFT JOIN HSatuan ON HSatuan.NoID=HBarang.IDSatuanJual WHERE 1=1 "
            If ckNonAktif.Checked Then
                SQL &= " AND HBarang.IsAktif=1"
            End If
            If txtIDKategori.Text <> "" Then
                SQL &= " AND HBarang.IDKategori=" & NullToLong(txtIDKategori.EditValue)
            End If
            If txtIDSupplier.Text <> "" Then
                SQL &= " AND (HBarang.IDSupplier1=" & NullToLong(txtIDSupplier.EditValue) & " OR HBarang.IDSupplier2=" & NullToLong(txtIDSupplier.EditValue) & " OR HBarang.IDSupplier3=" & NullToLong(txtIDSupplier.EditValue) & ")"
            End If

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
        GridControl1.ShowPrintPreview()
    End Sub
End Class