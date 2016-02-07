Imports System.Data
Imports System.Data.SqlClient
Imports DevExpress.XtraEditors
Imports DevExpress.Utils
Imports DevExpress.XtraEditors.Repository

Imports Elliteserv.Fungsi.Ini
Imports Elliteserv.Fungsi.Utils
Imports Elliteserv.SQLServer.Connect


Public Class frmDaftarMasterBarang
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
        GridView2.SaveLayoutToXml(FolderLayouts & "\" & FormName & GridView2.Name & ".xml")
        GridView3.SaveLayoutToXml(FolderLayouts & "\" & FormName & GridView3.Name & ".xml")
        LayoutControl1.SaveLayoutToXml(FolderLayouts & "\" & FormName & LayoutControl1.Name & ".xml")
    End Sub

    Private Sub frmDaftarMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Text = Judul
        LabelControl1.Text = Judul.ToUpper

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
            If ckNonAktif.Checked Then
                SQL = QueryString
            Else
                SQL = QueryString & " WHERE " & NamaTabel & ".IsAktif=1"
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
                            .Columns(i).DisplayFormat.FormatString = "dd-MM-yyyy HH:mm"
                        Case "byte[]", "image"
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

            RefreshDataDetil()
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

    Private Sub RefreshDataDetil()
        Dim ds As New DataSet
        'Dim cn As New SqlConnection
        'Dim com As New SqlCommand
        'Dim oDA As New SqlDataAdapter
        Dim Pic As Object
        Try
            SQL = "SELECT * FROM HBarangDHargaJual WHERE IDBarang=" & NullToLong(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "NoID"))
            EksekusiDataset(ds, NamaTabel, SQL)

            GridControl2.DataSource = ds.Tables(NamaTabel)
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
                Next
            End With

            SQL = "SELECT * FROM HBarangDBarcode WHERE IDBarang=" & NullToLong(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "NoID"))
            EksekusiDataset(ds, NamaTabel, SQL)

            GridControl3.DataSource = ds.Tables(NamaTabel)
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
                Next
            End With

            Pic = GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Photo") 'EksekusiScalar("SELECT [Photo] FROM HBarang WHERE NoID=" & NullToLong(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "NoID")))
            If IsDBNull(Pic) Or Pic Is Nothing Then
                PictureEdit1.Image = Nothing
            Else
                Using ms As New System.IO.MemoryStream(Pic, 0, Pic.Length)
                    ms.Write(Pic, 0, Pic.Length)
                    PictureEdit1.Image = Image.FromStream(ms, True)
                    ms.Dispose()
                End Using
            End If
            PictureEdit1.Refresh()
        Catch ex As Exception
            XtraMessageBox.Show("Info Kesalahan : " & ex.Message, NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            ds.Dispose()
        End Try
    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        RefreshData()
    End Sub

    Private Sub NonAktifkan()
        Try
            NoID = NullToLong(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "NoID"))
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
        NoID = NullToLong(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "NoID"))
        Select Case FormName.ToLower
            Case "frmDaftarUser".ToLower
                If NoID >= 1 AndAlso _
                XtraMessageBox.Show("Yakin ingin menghapus data user yang dipilih ini?", NamaAplikasi, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    EksekusiSQL("DELETE FROM HUser WHERE NoID=" & NoID)
                    EksekusiSQL("DELETE FROM HUserD WHERE NoID=" & NoID)
                    RefreshData()
                End If
            Case Else
                NonAktifkan()
        End Select
    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
        Select Case FormName.ToLower
            Case "frmDaftarBarang".ToLower
                Dim x As New frmEntriBarang(False)
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
        End Select
    End Sub

    Private Sub cmdBaru_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBaru.Click
        Select Case FormName.ToLower
            Case "frmDaftarBarang".ToLower
                Dim x As New frmEntriBarang(True)
                x.ShowInTaskbar = False
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

    Private Sub cmdPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPreview.Click
        GridControl1.ShowPrintPreview()
    End Sub

    Private Sub GridControl1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub GridView1_FocusedRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        RefreshDataDetil()
    End Sub
End Class