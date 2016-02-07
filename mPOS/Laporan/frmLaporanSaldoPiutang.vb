Imports System.Data
Imports System.Data.SqlClient
Imports DevExpress.XtraEditors
Imports DevExpress.Utils
Imports DevExpress.XtraEditors.Repository

Imports Elliteserv.Fungsi.Ini
Imports Elliteserv.Fungsi.Utils
Imports Elliteserv.SQLServer.Connect
Imports mPOS.clsCetakReportDevExpress


Public Class frmLaporanSaldoPiutang
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

    Private Sub frmDaftarMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Text = Judul
        LabelControl1.Text = Judul.ToUpper

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
    Dim dsReport As New DataSet
    Private Sub RefreshData()
        Dim ds As New DataSet
        Try
            SQL = "SELECT HKontak.NoID, HKontak.Kode, HKontak.Nama, ISNULL(Saldo.[Belum JT],0) AS [Belum JT], ISNULL(Saldo.[JT 1-30 Hari],0) AS [JT 1-30 Hari], ISNULL(Saldo.[JT 31-60 Hari],0) AS [JT 31-60 Hari], ISNULL(Saldo.[JT 60 Hari Lebih],0) AS [JT 60 Hari Lebih], ISNULL(Saldo.[JT Hari Ini],0) AS [JT Hari Ini], ISNULL(Saldo.[Total Piutang],0) AS [Total Piutang] " & vbCrLf & _
                    "FROM HKontak " & vbCrLf & _
                    "LEFT JOIN (" & vbCrLf & _
                    "SELECT HJual.IDCustomer," & vbCrLf & _
                    "SUM(CASE WHEN DATEDIFF(DAY, GETDATE(), HJual.TglTempo)>0 AND A.Sisa >=1 THEN A.Sisa ELSE 0 END) AS [Belum JT]," & vbCrLf & _
                    "SUM(CASE WHEN DATEDIFF(DAY, GETDATE(), HJual.TglTempo)=0 AND A.Sisa >=1 THEN A.Sisa ELSE 0 END) AS [JT Hari Ini]," & vbCrLf & _
                    "SUM(CASE WHEN (DATEDIFF(DAY, GETDATE(), HJual.TglTempo) BETWEEN -30 AND -1) AND A.Sisa >=1 THEN A.Sisa ELSE 0 END) AS [JT 1-30 Hari]," & vbCrLf & _
                    "SUM(CASE WHEN (DATEDIFF(DAY, GETDATE(), HJual.TglTempo) BETWEEN -60 AND -31) AND A.Sisa >=1 THEN A.Sisa ELSE 0 END) AS [JT 31-60 Hari]," & vbCrLf & _
                    "SUM(CASE WHEN (DATEDIFF(DAY, GETDATE(), HJual.TglTempo)<-60) AND A.Sisa >=1 THEN A.Sisa ELSE 0 END) AS [JT 60 Hari Lebih]," & vbCrLf & _
                    "SUM(A.Sisa) AS [Total Piutang]" & vbCrLf & _
                    "FROM HJual" & vbCrLf & _
                    "INNER JOIN [dbo].[fn_DataPiutang] ('Penjualan',-1,-1) AS A ON A.NoID = HJual.NoID" & vbCrLf & _
                    "WHERE HJual.Tanggal<'" & DateEdit2.DateTime.AddDays(1).ToString("yyyy-MM-dd") & "' " & vbCrLf & _
                    "GROUP BY HJual.IDCustomer) AS Saldo ON Saldo.IDCustomer = HKontak.NoID" & vbCrLf & _
                    "WHERE HKontak.IsCustomer=1 AND (HKontak.IsAktif=1 OR ISNULL(Saldo.[Total Piutang],0)<>0)"
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

        Catch ex As Exception
            XtraMessageBox.Show("Info Kesalahan : " & ex.Message, NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            ds.Dispose()
        End Try
    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        RefreshData()
    End Sub

    Private Sub cmdPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPreview.Click
        Dim NamaFile As String = Application.StartupPath & "\Report\LaporanSaldoPiutang.repx"
        Try
            ViewXtraReport(Me.MdiParent, IIf(IsEditReport, Action_.Edit, Action_.Preview), NamaFile, "Laporan Saldo Piutang", "LaporanSaldoPiutang.repx", dsReport, "A4", "TglSampai=Datetime=#" & DateEdit2.DateTime.ToString("yyyy-MM-dd") & "#")
        Catch ex As Exception
            XtraMessageBox.Show("Info Kesalahan : " & ex.Message, NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
End Class