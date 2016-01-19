Imports System.Data
Imports System.Data.SqlClient
Imports DevExpress.XtraEditors
Imports DevExpress.Utils
Imports DevExpress.XtraEditors.Repository

Imports Elliteserv.Fungsi.Ini
Imports Elliteserv.Fungsi.Utils
Imports Elliteserv.SQLServer.Connect
Imports mPOS.clsCetakReportDevExpress


Public Class frmDaftarTransaksi
    Public FormName As String = Me.Name
    Public Judul As String = "Daftar "
    Public QueryString As String = ""
    Public NamaTabel As String = ""
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
        Try
            Select Case FormName.ToLower
                Case "frmDaftarTukarPoin".ToLower
                    SQL = "SELECT HTukarPoin.*, HKontak.Kode + ' - ' + HKontak.Nama AS Customer FROM HTukarPoin LEFT JOIN HKontak ON HKontak.NoID=HTukarPoin.IDCustomer WHERE 1=1 "
                Case "frmDaftarPembelian".ToLower
                    SQL = "SELECT HBeli.*, HKontak.Nama AS Supplier, HUserEntri.Nama AS UserEntri, HUserEdit.Nama AS UserEdit" & vbCrLf & _
                          " FROM HBeli " & vbCrLf & _
                          " LEFT JOIN HKontak ON HKontak.NoID=HBeli.IDSupplier " & vbCrLf & _
                          " LEFT JOIN HUser HUserEntri ON HUserEntri.NoID=HBeli.IDUserEntri " & vbCrLf & _
                          " LEFT JOIN HUser HUserEdit ON HUserEntri.NoID=HBeli.IDUserEdit " & vbCrLf & _
                          " WHERE 1=1 "
                Case "frmDaftarPenyesuaian".ToLower
                    SQL = "SELECT HPenyesuaian.*, HUserEntri.Nama AS UserEntri, HUserEdit.Nama AS UserEdit" & vbCrLf & _
                          " FROM HPenyesuaian " & vbCrLf & _
                          " LEFT JOIN HUser HUserEntri ON HUserEntri.NoID=HPenyesuaian.IDUserEntri " & vbCrLf & _
                          " LEFT JOIN HUser HUserEdit ON HUserEntri.NoID=HPenyesuaian.IDUserEdit " & vbCrLf & _
                          " WHERE 1=1 "
                Case "frmDaftarSalesOrder".ToLower
                    SQL = "SELECT HSalesOrder.*, HSalesman.Nama AS Salesman, HKontak.Nama AS Customer, HUserEntri.Nama AS UserEntri, HUserEdit.Nama AS UserEdit" & vbCrLf & _
                          " FROM HSalesOrder " & vbCrLf & _
                          " LEFT JOIN HKontak ON HKontak.NoID=HSalesOrder.IDCustomer " & vbCrLf & _
                          " LEFT JOIN HKontak HSalesman ON HSalesman.NoID=HSalesOrder.IDSalesman " & vbCrLf & _
                          " LEFT JOIN HUser HUserEntri ON HUserEntri.NoID=HSalesOrder.IDUserEntri " & vbCrLf & _
                          " LEFT JOIN HUser HUserEdit ON HUserEntri.NoID=HSalesOrder.IDUserEdit " & vbCrLf & _
                          " WHERE 1=1 "
                Case "frmDaftarPenjualan".ToLower
                    SQL = "SELECT HJual.*, HSalesman.Nama AS Salesman, HKontak.Nama AS Customer, HUserEntri.Nama AS UserEntri, HUserEdit.Nama AS UserEdit" & vbCrLf & _
                          " FROM HJual " & vbCrLf & _
                          " LEFT JOIN HKontak ON HKontak.NoID=HJual.IDCustomer " & vbCrLf & _
                          " LEFT JOIN HKontak HSalesman ON HSalesman.NoID=HJual.IDSalesman " & vbCrLf & _
                          " LEFT JOIN HUser HUserEntri ON HUserEntri.NoID=HJual.IDUserEntri " & vbCrLf & _
                          " LEFT JOIN HUser HUserEdit ON HUserEntri.NoID=HJual.IDUserEdit " & vbCrLf & _
                          " WHERE 1=1 "
                Case "frmDaftarReturPenjualan".ToLower
                    SQL = "SELECT HReturJual.*, HKontak.Nama AS Customer, HUserEntri.Nama AS UserEntri, HUserEdit.Nama AS UserEdit" & vbCrLf & _
                          " FROM HReturJual " & vbCrLf & _
                          " LEFT JOIN HKontak ON HKontak.NoID=HReturJual.IDCustomer " & vbCrLf & _
                          " LEFT JOIN HUser HUserEntri ON HUserEntri.NoID=HReturJual.IDUserEntri " & vbCrLf & _
                          " LEFT JOIN HUser HUserEdit ON HUserEntri.NoID=HReturJual.IDUserEdit " & vbCrLf & _
                          " WHERE 1=1 "
                Case Else
                    SQL = QueryString
            End Select
            If DateEdit1.Enabled Then
                SQL &= " AND " & NamaTabel & ".Tanggal>='" & DateEdit1.DateTime.ToString("yyyy-MM-dd") & "' AND " & NamaTabel & ".Tanggal<'" & DateEdit2.DateTime.AddDays(1).ToString("yyyy-MM-dd") & "'"
            End If
            EksekusiDataset(ds, NamaTabel, SQL)

            GridControl1.DataSource = ds.Tables(NamaTabel)
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
        NoID = NullToLong(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "NoID"))
        Select Case FormName.ToLower
            Case "frmDaftarTukarPoin".ToLower
                If NoID >= 1 AndAlso _
                XtraMessageBox.Show("Yakin ingin menghapus data tukar poin yang dipilih ini?", NamaAplikasi, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    EksekusiSQL("DELETE FROM HKartuPoin WHERE IDJenisTransaksi=8 AND IDTransaksi=" & NoID)
                    EksekusiSQL("DELETE FROM HTukarPoin WHERE NoID=" & NoID)
                    RefreshData()
                End If
            Case "frmDaftarPembelian".ToLower
                If NoID >= 1 AndAlso _
               XtraMessageBox.Show("Yakin ingin menghapus data pembelian yang dipilih ini?", NamaAplikasi, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    EksekusiSQL("DELETE FROM HKartuStok WHERE IDJenisTransaksi=1 AND IDTransaksi=" & NoID)
                    EksekusiSQL("DELETE FROM HBeli WHERE NoID=" & NoID)
                    EksekusiSQL("DELETE FROM HBeliD WHERE IDHeader=" & NoID)
                    RefreshData()
                End If
            Case "frmDaftarPenyesuaian".ToLower
                If NoID >= 1 AndAlso _
               XtraMessageBox.Show("Yakin ingin menghapus data Penyesuaian yang dipilih ini?", NamaAplikasi, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    EksekusiSQL("DELETE FROM HKartuStok WHERE IDJenisTransaksi=5 AND IDTransaksi=" & NoID)
                    EksekusiSQL("DELETE FROM HPenyesuaian WHERE NoID=" & NoID)
                    EksekusiSQL("DELETE FROM HPenyesuaianD WHERE IDHeader=" & NoID)
                    RefreshData()
                End If
            Case "frmDaftarSalesOrder".ToLower
                If NoID >= 1 AndAlso _
               XtraMessageBox.Show("Yakin ingin menghapus data Sales Order yang dipilih ini?", NamaAplikasi, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    EksekusiSQL("DELETE FROM HSalesOrder WHERE NoID=" & NoID)
                    EksekusiSQL("DELETE FROM HSalesOrderD WHERE IDHeader=" & NoID)
                    RefreshData()
                End If
            Case "frmDaftarPenjualan".ToLower
                If NoID >= 1 AndAlso _
               XtraMessageBox.Show("Yakin ingin menghapus data Penjualan yang dipilih ini?", NamaAplikasi, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    EksekusiSQL("DELETE FROM HKartuStok WHERE IDJenisTransaksi=2 AND IDTransaksi=" & NoID)
                    EksekusiSQL("DELETE FROM HKartuPiutang WHERE IDJenisTransaksi=2 AND IDTransaksi=" & NoID)
                    EksekusiSQL("DELETE FROM HJual WHERE NoID=" & NoID)
                    EksekusiSQL("DELETE FROM HJualD WHERE IDHeader=" & NoID)
                    RefreshData()
                End If
            Case "frmDaftarReturPenjualan".ToLower
                If NoID >= 1 AndAlso _
               XtraMessageBox.Show("Yakin ingin menghapus data Retur Penjualan yang dipilih ini?", NamaAplikasi, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    EksekusiSQL("DELETE FROM HKartuStok WHERE IDJenisTransaksi=4 AND IDTransaksi=" & NoID)
                    EksekusiSQL("DELETE FROM HKartuPiutang WHERE IDJenisTransaksi=4 AND IDTransaksi=" & NoID)
                    EksekusiSQL("DELETE FROM HReturJual WHERE NoID=" & NoID)
                    EksekusiSQL("DELETE FROM HReturJualD WHERE IDHeader=" & NoID)
                    RefreshData()
                End If
        End Select
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        Select Case FormName.ToLower
            Case "frmDaftarTukarPoin".ToLower
                Dim x As New frmEntriTukarPoin(False)
                x.NoID = NullToLong(GridView1.GetFocusedRowCellValue(GridView1.Columns("NoID")))
                x.ShowInTaskbar = False
                x.StartPosition = FormStartPosition.CenterParent
                If x.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    cmdRefresh.PerformClick()
                    GridView1.ClearSelection()
                    GridView1.FocusedRowHandle = GridView1.LocateByDisplayText(0, GridView1.Columns("NoID"), x.NoID.ToString("n0"))
                    GridView1.SelectRow(GridView1.FocusedRowHandle)
                End If
                x.Dispose()
            Case "frmDaftarPembelian".ToLower
                Dim x As New frmEntriBeli(frmEntriBeli.Status.Edit)
                x.NoID = NullToLong(GridView1.GetFocusedRowCellValue(GridView1.Columns("NoID")))
                x.ShowInTaskbar = False
                x.WindowState = FormWindowState.Maximized
                x.StartPosition = FormStartPosition.CenterParent
                If x.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    cmdRefresh.PerformClick()
                    GridView1.ClearSelection()
                    GridView1.FocusedRowHandle = GridView1.LocateByDisplayText(0, GridView1.Columns("NoID"), x.NoID.ToString("n0"))
                    GridView1.SelectRow(GridView1.FocusedRowHandle)
                End If
                x.Dispose()
            Case "frmDaftarSalesOrder".ToLower
                Dim x As New frmEntriSalesOrder(frmEntriSalesOrder.Status.Edit)
                x.NoID = NullToLong(GridView1.GetFocusedRowCellValue(GridView1.Columns("NoID")))
                x.ShowInTaskbar = False
                x.WindowState = FormWindowState.Maximized
                x.StartPosition = FormStartPosition.CenterParent
                If x.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    cmdRefresh.PerformClick()
                    GridView1.ClearSelection()
                    GridView1.FocusedRowHandle = GridView1.LocateByDisplayText(0, GridView1.Columns("NoID"), x.NoID.ToString("n0"))
                    GridView1.SelectRow(GridView1.FocusedRowHandle)
                End If
                x.Dispose()
            Case "frmDaftarPenjualan".ToLower
                Dim x As New frmEntriJual(frmEntriJual.Status.Edit)
                x.NoID = NullToLong(GridView1.GetFocusedRowCellValue(GridView1.Columns("NoID")))
                x.ShowInTaskbar = False
                x.WindowState = FormWindowState.Maximized
                x.StartPosition = FormStartPosition.CenterParent
                If x.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    cmdRefresh.PerformClick()
                    GridView1.ClearSelection()
                    GridView1.FocusedRowHandle = GridView1.LocateByDisplayText(0, GridView1.Columns("NoID"), x.NoID.ToString("n0"))
                    GridView1.SelectRow(GridView1.FocusedRowHandle)
                End If
                x.Dispose()
            Case "frmDaftarReturPenjualan".ToLower
                Dim x As New frmEntriReturJual(frmEntriReturJual.Status.Edit)
                x.NoID = NullToLong(GridView1.GetFocusedRowCellValue(GridView1.Columns("NoID")))
                x.ShowInTaskbar = False
                x.WindowState = FormWindowState.Maximized
                x.StartPosition = FormStartPosition.CenterParent
                If x.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    cmdRefresh.PerformClick()
                    GridView1.ClearSelection()
                    GridView1.FocusedRowHandle = GridView1.LocateByDisplayText(0, GridView1.Columns("NoID"), x.NoID.ToString("n0"))
                    GridView1.SelectRow(GridView1.FocusedRowHandle)
                End If
                x.Dispose()
            Case "frmDaftarPenyesuaian".ToLower
                Dim x As New frmEntriPenyesuaian(frmEntriPenyesuaian.Status.Edit)
                x.NoID = NullToLong(GridView1.GetFocusedRowCellValue(GridView1.Columns("NoID")))
                x.ShowInTaskbar = False
                x.WindowState = FormWindowState.Maximized
                x.StartPosition = FormStartPosition.CenterParent
                If x.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    cmdRefresh.PerformClick()
                    GridView1.ClearSelection()
                    GridView1.FocusedRowHandle = GridView1.LocateByDisplayText(0, GridView1.Columns("NoID"), x.NoID.ToString("n0"))
                    GridView1.SelectRow(GridView1.FocusedRowHandle)
                End If
                x.Dispose()
        End Select
    End Sub

    Private Sub cmdBaru_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBaru.Click
        Select Case FormName.ToLower
            Case "frmDaftarTukarPoin".ToLower
                Dim x As New frmEntriTukarPoin(True)
                x.ShowInTaskbar = False
                x.StartPosition = FormStartPosition.CenterParent
                If x.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    cmdRefresh.PerformClick()
                    GridView1.ClearSelection()
                    GridView1.FocusedRowHandle = GridView1.LocateByDisplayText(0, GridView1.Columns("NoID"), x.NoID.ToString("n0"))
                    GridView1.SelectRow(GridView1.FocusedRowHandle)
                End If
                x.Dispose()
            Case "frmDaftarPembelian".ToLower
                Dim x As New frmEntriBeli(frmEntriBeli.Status.Baru)
                x.ShowInTaskbar = False
                x.StartPosition = FormStartPosition.CenterParent
                x.WindowState = FormWindowState.Maximized
                If x.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    cmdRefresh.PerformClick()
                    GridView1.ClearSelection()
                    GridView1.FocusedRowHandle = GridView1.LocateByDisplayText(0, GridView1.Columns("NoID"), x.NoID.ToString("n0"))
                    GridView1.SelectRow(GridView1.FocusedRowHandle)
                End If
                x.Dispose()
            Case "frmDaftarSalesOrder".ToLower
                Dim x As New frmEntriSalesOrder(frmEntriSalesOrder.Status.Baru)
                x.ShowInTaskbar = False
                x.StartPosition = FormStartPosition.CenterParent
                x.WindowState = FormWindowState.Maximized
                If x.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    cmdRefresh.PerformClick()
                    GridView1.ClearSelection()
                    GridView1.FocusedRowHandle = GridView1.LocateByDisplayText(0, GridView1.Columns("NoID"), x.NoID.ToString("n0"))
                    GridView1.SelectRow(GridView1.FocusedRowHandle)
                End If
                x.Dispose()
            Case "frmDaftarPenjualan".ToLower
                Dim x As New frmEntriJual(frmEntriJual.Status.Baru)
                x.ShowInTaskbar = False
                x.StartPosition = FormStartPosition.CenterParent
                x.WindowState = FormWindowState.Maximized
                If x.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    cmdRefresh.PerformClick()
                    GridView1.ClearSelection()
                    GridView1.FocusedRowHandle = GridView1.LocateByDisplayText(0, GridView1.Columns("NoID"), x.NoID.ToString("n0"))
                    GridView1.SelectRow(GridView1.FocusedRowHandle)
                End If
                x.Dispose()
            Case "frmDaftarReturPenjualan".ToLower
                Dim x As New frmEntriReturJual(frmEntriReturJual.Status.Baru)
                x.ShowInTaskbar = False
                x.StartPosition = FormStartPosition.CenterParent
                x.WindowState = FormWindowState.Maximized
                If x.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    cmdRefresh.PerformClick()
                    GridView1.ClearSelection()
                    GridView1.FocusedRowHandle = GridView1.LocateByDisplayText(0, GridView1.Columns("NoID"), x.NoID.ToString("n0"))
                    GridView1.SelectRow(GridView1.FocusedRowHandle)
                End If
                x.Dispose()
            Case "frmDaftarPenyesuaian".ToLower
                Dim x As New frmEntriPenyesuaian(frmEntriPenyesuaian.Status.Baru)
                x.ShowInTaskbar = False
                x.StartPosition = FormStartPosition.CenterParent
                x.WindowState = FormWindowState.Maximized
                If x.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    cmdRefresh.PerformClick()
                    GridView1.ClearSelection()
                    GridView1.FocusedRowHandle = GridView1.LocateByDisplayText(0, GridView1.Columns("NoID"), x.NoID.ToString("n0"))
                    GridView1.SelectRow(GridView1.FocusedRowHandle)
                End If
                x.Dispose()
        End Select
    End Sub

    Private Sub cmdPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPreview.Click
        GridControl1.ShowPrintPreview()
    End Sub

    Private Sub cmdCetakFaktur_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCetakFaktur.Click
        Dim ds As New DataSet
        Dim StrReader As System.IO.StreamReader
        Dim StrWriter As System.IO.StreamWriter
        Try
            NoID = NullToLong(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "NoID"))
            If System.IO.File.Exists(Application.StartupPath & "\Report\SQL\Faktur" & NamaTabel & ".SQL") Then
                StrReader = New System.IO.StreamReader(Application.StartupPath & "\Report\SQL\Faktur" & NamaTabel & ".SQL")
                SQL = StrReader.ReadToEnd
                StrReader.Close()
                StrReader.Dispose()
                SQL &= " WHERE " & NamaTabel & ".NoID=" & NoID
            Else
                SQL = "SELECT " & NamaTabel & "D.*, " & NamaTabel & ".Kode FROM " & NamaTabel & " INNER JOIN " & NamaTabel & "D ON " & NamaTabel & ".NoID=" & NamaTabel & "D.IDHeader "
                StrWriter = New System.IO.StreamWriter(Application.StartupPath & "\Report\SQL\Faktur" & NamaTabel & ".SQL")
                StrWriter.Write(SQL)
                StrWriter.Flush()
                StrWriter.Close()
                StrWriter.Dispose()
                SQL &= " WHERE " & NamaTabel & ".NoID=" & NoID
            End If

            EksekusiDataset(ds, "Data", SQL)
            ViewXtraReport(Me.MdiParent, IIf(IsEditReport, Action_.Edit, Action_.Preview), Application.StartupPath & "\Report\Faktur" & NamaTabel & ".repx", "CETAK " & Judul.ToUpper, "Faktur" & NamaTabel & ".repx", ds, "Nota")
        Catch ex As Exception
            XtraMessageBox.Show("Info Kesalahan : " & ex.Message, NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            ds.Dispose()
        End Try
    End Sub

    Private Sub DateEdit1_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateEdit1.EditValueChanged

    End Sub
End Class