Imports System.Data
Imports System.Data.SqlClient
Imports DevExpress.XtraEditors
Imports DevExpress.Utils
Imports DevExpress.XtraEditors.Repository

Imports Elliteserv.Fungsi.Ini
Imports Elliteserv.Fungsi.Utils
Imports Elliteserv.SQLServer.Connect


Public Class frmDaftarKontak
    Public FormName As String = Me.Name
    'Public Judul As String = "Daftar "
    'Public QueryString As String = ""
    Public NamaTabel As String = "HKontak"
    Public NoID As Long = -1

    Dim SQL As String = ""
    Dim repckedit As New RepositoryItemCheckEdit
    Dim repdateedit As New RepositoryItemDateEdit
    Dim reptextedit As New RepositoryItemTextEdit
    Dim reppicedit As New RepositoryItemPictureEdit

    Private Sub frmDaftarMaster_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GridView1.SaveLayoutToXml(FolderLayouts & "\" & FormName & GridView1.Name & ".xml")
        GridView2.SaveLayoutToXml(FolderLayouts & "\" & FormName & GridView2.Name & ".xml")
        GridView3.SaveLayoutToXml(FolderLayouts & "\" & FormName & GridView3.Name & ".xml")
        GridView4.SaveLayoutToXml(FolderLayouts & "\" & FormName & GridView4.Name & ".xml")
        LayoutControl1.SaveLayoutToXml(FolderLayouts & "\" & FormName & LayoutControl1.Name & ".xml")
    End Sub

    Private Sub frmDaftarMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RefreshData()

        If System.IO.File.Exists(FolderLayouts & "\" & FormName & LayoutControl1.Name & ".xml") Then
            LayoutControl1.RestoreLayoutFromXml(FolderLayouts & "\" & FormName & LayoutControl1.Name & ".xml")
        End If
        If System.IO.File.Exists(FolderLayouts & "\" & FormName & GridView1.Name & ".xml") Then
            GridView1.RestoreLayoutFromXml(FolderLayouts & "\" & FormName & GridView1.Name & ".xml")
        End If
        If System.IO.File.Exists(FolderLayouts & "\" & FormName & GridView2.Name & ".xml") Then
            GridView2.RestoreLayoutFromXml(FolderLayouts & "\" & FormName & GridView2.Name & ".xml")
        End If
        If System.IO.File.Exists(FolderLayouts & "\" & FormName & GridView3.Name & ".xml") Then
            GridView3.RestoreLayoutFromXml(FolderLayouts & "\" & FormName & GridView3.Name & ".xml")
        End If
        If System.IO.File.Exists(FolderLayouts & "\" & FormName & GridView4.Name & ".xml") Then
            GridView4.RestoreLayoutFromXml(FolderLayouts & "\" & FormName & GridView4.Name & ".xml")
        End If
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


    Private Sub RefreshData()
        Dim ds As New DataSet
        Try
            If ckNonAktif.Checked Then
                SQL = "SELECT HKontak.*, HSalesman.Nama AS Salesman FROM HKontak LEFT JOIN HKontak HSalesman ON HSalesman.NoID=HKontak.IDSalesman"
            Else
                SQL = "SELECT HKontak.*, HSalesman.Nama AS Salesman FROM HKontak LEFT JOIN HKontak HSalesman ON HSalesman.NoID=HKontak.IDSalesman WHERE HKontak.IsAktif=1"
            End If
            EksekusiDataset(ds, "MKontak", SQL)
            GridControl1.DataSource = ds.Tables("MKontak")
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
                    .ShowFindPanel()
                Next
            End With

            If ckNonAktif.Checked Then
                SQL = "SELECT HKontak.*, HSalesman.Nama AS Salesman FROM HKontak LEFT JOIN HKontak HSalesman ON HSalesman.NoID=HKontak.IDSalesman WHERE HKontak.IsSupplier=1 "
            Else
                SQL = "SELECT HKontak.*, HSalesman.Nama AS Salesman FROM HKontak LEFT JOIN HKontak HSalesman ON HSalesman.NoID=HKontak.IDSalesman WHERE HKontak.IsSupplier=1 AND HKontak.IsAktif=1"
            End If
            EksekusiDataset(ds, "MSupplier", SQL)
            GridControl2.DataSource = ds.Tables("MSupplier")
            With GridView2
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
                    .ShowFindPanel()
                Next
            End With

            If ckNonAktif.Checked Then
                SQL = "SELECT HKontak.*, HSalesman.Nama AS Salesman FROM HKontak LEFT JOIN HKontak HSalesman ON HSalesman.NoID=HKontak.IDSalesman WHERE HKontak.IsCustomer=1 "
            Else
                SQL = "SELECT HKontak.*, HSalesman.Nama AS Salesman FROM HKontak LEFT JOIN HKontak HSalesman ON HSalesman.NoID=HKontak.IDSalesman WHERE HKontak.IsCustomer=1 AND HKontak.IsAktif=1"
            End If
            EksekusiDataset(ds, "MCustomer", SQL)
            GridControl3.DataSource = ds.Tables("MCustomer")
            With GridView3
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
                    .ShowFindPanel()
                Next
            End With

            If ckNonAktif.Checked Then
                SQL = "SELECT HKontak.*, HSalesman.Nama AS Salesman FROM HKontak LEFT JOIN HKontak HSalesman ON HSalesman.NoID=HKontak.IDSalesman WHERE HKontak.IsPegawai=1 "
            Else
                SQL = "SELECT HKontak.*, HSalesman.Nama AS Salesman FROM HKontak LEFT JOIN HKontak HSalesman ON HSalesman.NoID=HKontak.IDSalesman WHERE HKontak.IsPegawai=1 AND HKontak.IsAktif=1"
            End If
            EksekusiDataset(ds, "MCustomer", SQL)
            GridControl4.DataSource = ds.Tables("MCustomer")
            With GridView4
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

    Private Sub NonAktifkan()
        Try
            If XtraTabControl1.SelectedTabPageIndex = 0 Then
                NoID = NullToLong(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "NoID"))
            ElseIf XtraTabControl1.SelectedTabPageIndex = 1 Then
                NoID = NullToLong(GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "NoID"))
            ElseIf XtraTabControl1.SelectedTabPageIndex = 2 Then
                NoID = NullToLong(GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "NoID"))
            Else
                NoID = NullToLong(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "NoID"))
            End If
            If NoID >= 1 AndAlso _
            XtraMessageBox.Show("Yakin ingin menghapus item yang dipilih ini?", NamaAplikasi, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                If EksekusiSQL("UPDATE " & NamaTabel & " SET IsAktif=0 WHERE NoID=" & NoID) >= 1 Then
                    RefreshData()
                End If
            End If
        Catch ex As Exception
            XtraMessageBox.Show("Info Kesalahan : " & ex.Message, NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub cmdHapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHapus.Click
        NonAktifkan()
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        Dim x As New frmEntriKontak(False)
        If XtraTabControl1.SelectedTabPageIndex = 0 Then
            x.NoID = NullToLong(GridView1.GetFocusedRowCellValue(GridView1.Columns("NoID")))
        ElseIf XtraTabControl1.SelectedTabPageIndex = 1 Then
            x.NoID = NullToLong(GridView2.GetFocusedRowCellValue(GridView2.Columns("NoID")))
        ElseIf XtraTabControl1.SelectedTabPageIndex = 2 Then
            x.NoID = NullToLong(GridView3.GetFocusedRowCellValue(GridView3.Columns("NoID")))
        ElseIf XtraTabControl1.SelectedTabPageIndex = 3 Then
            x.NoID = NullToLong(GridView4.GetFocusedRowCellValue(GridView4.Columns("NoID")))
        Else
            x.NoID = NullToLong(GridView1.GetFocusedRowCellValue(GridView1.Columns("NoID")))
        End If
        x.ShowInTaskbar = False
        x.StartPosition = FormStartPosition.CenterParent
        If x.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            cmdRefresh.PerformClick()
            If XtraTabControl1.SelectedTabPageIndex = 0 Then
                GridView1.ClearSelection()
                GridView1.FocusedRowHandle = GridView1.LocateByDisplayText(0, GridView1.Columns("NoID"), x.NoID.ToString("n0"))
                GridView1.SelectRow(GridView1.FocusedRowHandle)
            ElseIf XtraTabControl1.SelectedTabPageIndex = 1 Then
                GridView2.ClearSelection()
                GridView2.FocusedRowHandle = GridView2.LocateByDisplayText(0, GridView2.Columns("NoID"), x.NoID.ToString("n0"))
                GridView2.SelectRow(GridView2.FocusedRowHandle)
            ElseIf XtraTabControl1.SelectedTabPageIndex = 2 Then
                GridView3.ClearSelection()
                GridView3.FocusedRowHandle = GridView3.LocateByDisplayText(0, GridView3.Columns("NoID"), x.NoID.ToString("n0"))
                GridView3.SelectRow(GridView3.FocusedRowHandle)
            Else
                GridView1.ClearSelection()
                GridView1.FocusedRowHandle = GridView1.LocateByDisplayText(0, GridView1.Columns("NoID"), x.NoID.ToString("n0"))
                GridView1.SelectRow(GridView1.FocusedRowHandle)
            End If
        End If
        x.Dispose()
    End Sub

    Private Sub cmdBaru_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBaru.Click
        Dim x As New frmEntriKontak(True)
        x.ShowInTaskbar = False
        x.StartPosition = FormStartPosition.CenterParent
        If x.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            cmdRefresh.PerformClick()
            If XtraTabControl1.SelectedTabPageIndex = 0 Then
                GridView1.ClearSelection()
                GridView1.FocusedRowHandle = GridView1.LocateByDisplayText(0, GridView1.Columns("NoID"), x.NoID.ToString("n0"))
                GridView1.SelectRow(GridView1.FocusedRowHandle)
            ElseIf XtraTabControl1.SelectedTabPageIndex = 1 Then
                GridView2.ClearSelection()
                GridView2.FocusedRowHandle = GridView2.LocateByDisplayText(0, GridView2.Columns("NoID"), x.NoID.ToString("n0"))
                GridView2.SelectRow(GridView2.FocusedRowHandle)
            ElseIf XtraTabControl1.SelectedTabPageIndex = 2 Then
                GridView3.ClearSelection()
                GridView3.FocusedRowHandle = GridView3.LocateByDisplayText(0, GridView3.Columns("NoID"), x.NoID.ToString("n0"))
                GridView3.SelectRow(GridView3.FocusedRowHandle)
            ElseIf XtraTabControl1.SelectedTabPageIndex = 3 Then
                GridView4.ClearSelection()
                GridView4.FocusedRowHandle = GridView4.LocateByDisplayText(0, GridView4.Columns("NoID"), x.NoID.ToString("n0"))
                GridView4.SelectRow(GridView4.FocusedRowHandle)
            Else
                GridView1.ClearSelection()
                GridView1.FocusedRowHandle = GridView1.LocateByDisplayText(0, GridView1.Columns("NoID"), x.NoID.ToString("n0"))
                GridView1.SelectRow(GridView1.FocusedRowHandle)
            End If
        End If
        x.Dispose()
    End Sub

    Private Sub cmdPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPreview.Click
        GridControl1.ShowPrintPreview()
    End Sub
End Class