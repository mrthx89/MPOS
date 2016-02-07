Imports DevExpress.XtraEditors
Imports System.Data.SqlClient
Imports System.Data
Imports DevExpress.XtraBars
Imports Elliteserv.Fungsi.Ini

Public Class frmUtama
    Dim SkinKu As String = "Summer 2008"

    Private Sub GetStatusApplikasi()
        mnStatusServer.Caption = "Server : " & Elliteserv.SQLServer.Connect.NamaServerMSSQL
        mnStatusDatabase.Caption = "Database : " & Elliteserv.SQLServer.Connect.NamaDatabaseMSSQL
        mnStatusUser.Caption = "User Aktif : " & NamaUserAktif
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Text = "mPOS - " & NamaPerusahaan.ToUpper
            GetStatusApplikasi()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmMain_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Login()
    End Sub

    Private Sub Login()
        Dim x As New frmLogin
        Try
            If IsLogin Then
                If XtraMessageBox.Show("Yakin mau menutup form?", NamaAplikasi, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    For Each frm In Me.MdiChildren
                        frm.Close()
                    Next
                    Bar1.ClearLinks()
                    mnLogin.Caption = "&Login"
                    IsValidasiLogin("", "")
                    AktifkanMenuUser()
                    GetStatusApplikasi()
                    If IsSupervisor Then
                        'mnSetting.Visibility = BarItemVisibility.Always
                        mnUserAksesMenu.Visibility = BarItemVisibility.Always
                    Else
                        'mnSetting.Visibility = BarItemVisibility.Never
                        mnUserAksesMenu.Visibility = BarItemVisibility.Never
                    End If
                    IsLogin = False
                End If
            Else
                If x.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    UpdateSistemData()
                    AktifkanMenuUser()
                    GetStatusApplikasi()
                    mnLogin.Caption = "&Log Out"
                    If IsSupervisor Then
                        mnUserAksesMenu.Visibility = BarItemVisibility.Always
                    Else
                        mnUserAksesMenu.Visibility = BarItemVisibility.Never
                    End If
                    IsLogin = True
                End If
            End If
            'If x.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            '    GetStatusApplikasi()
            'End If
        Catch ex As Exception
            XtraMessageBox.Show("Info Kesalahan : " & ex.Message, NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            x.Dispose()
        End Try
    End Sub

    Private Sub AktifkanMenuUser()
        GenerateMenu()
    End Sub

    Private Sub GenerateMenu()
        Dim SQL As String = ""
        Dim strSQL As String = ""

        Dim ItemParent As BarSubItem
        Dim ItemSubItem As BarSubItem
        Dim ItemMenu As BarButtonItem

        Dim oConn As New SqlConnection
        Dim oComm As New SqlCommand
        Dim oDA As New SqlDataAdapter
        Dim oDS As New DataSet
        Try
            oConn.ConnectionString = Elliteserv.SQLServer.Connect.KoneksiString
            oConn.Open()
            oComm.Connection = oConn

            strSQL = "SELECT DISTINCT HMenu.*, HUserD.[Visible], HUserD.[Enable]" & vbCrLf & _
                     " FROM HMenu " & vbCrLf & _
                     " INNER JOIN HUserD ON HUserD.IDMenu=HMenu.NoID " & vbCrLf & _
                     " WHERE HMenu.IsAktif=1 AND HMenu.IDParent=-1 AND HUserD.IDUser=" & IDUserAktif & " AND HUserD.Visible=1 ORDER BY HMenu.NoUrut"
            oComm.CommandText = strSQL
            oDA.SelectCommand = oComm
            If Not oDS.Tables("MParent") Is Nothing Then
                oDS.Tables("MParent").Clear()
            End If
            oDA.Fill(oDS, "MParent")

            For iParent As Integer = 0 To oDS.Tables("MParent").Rows.Count - 1
                'Create a new bar item representing a hyperlink editor
                ItemParent = New BarSubItem
                ItemParent.PaintStyle = BarItemPaintStyle.CaptionGlyph
                ItemParent.Name = NullToStr(oDS.Tables("MParent").Rows(iParent).Item("Kode"))
                ItemParent.Caption = NullToStr(oDS.Tables("MParent").Rows(iParent).Item("Caption"))
                ItemParent.MenuCaption = NullToStr(oDS.Tables("MParent").Rows(iParent).Item("Caption"))
                ItemParent.ShowMenuCaption = True
                ItemParent.Enabled = NullToBool(oDS.Tables("MParent").Rows(iParent).Item("Enable"))
                Try
                    ItemParent.Glyph = ImageCollectionLarge.Images(NullTolInt(oDS.Tables("MParent").Rows(iParent).Item("Icon")))
                    ItemParent.GlyphDisabled = ImageCollectionLarge.Images(NullTolInt(oDS.Tables("MParent").Rows(iParent).Item("Icon")))
                Catch
                End Try
                Bar1.AddItem(ItemParent)

                'Create a new bar sub item representing a hyperlink editor
                strSQL = "SELECT DISTINCT HMenu.*, HUserD.[Visible], HUserD.[Enable]" & vbCrLf & _
                         " FROM HMenu " & vbCrLf & _
                         " INNER JOIN HUserD ON HUserD.IDMenu=HMenu.NoID " & vbCrLf & _
                         " WHERE ISNULL(HMenu.IsBarSubItem,0)=0 AND HMenu.IDParent=" & NullToLong(oDS.Tables("MParent").Rows(iParent).Item("NoID")) & " AND HMenu.IsAktif=1 AND HUserD.IDUser=" & IDUserAktif & " AND HUserD.Visible=1 ORDER BY HMenu.NoUrut"
                oComm.CommandText = strSQL
                If Not oDS.Tables("MSubItem") Is Nothing Then
                    oDS.Tables("MSubItem").Clear()
                End If
                oDA.Fill(oDS, "MSubItem")
                For iSubItem As Integer = 0 To oDS.Tables("MSubItem").Rows.Count - 1
                    If NullToBool(oDS.Tables("MSubItem").Rows(iSubItem).Item("IsBarSubItem")) Then 'Berarti BarSub
                        ItemSubItem = New BarSubItem
                        ItemSubItem.PaintStyle = BarItemPaintStyle.Standard
                        ItemSubItem.Name = NullToStr(oDS.Tables("MSubItem").Rows(iSubItem).Item("Kode"))
                        ItemSubItem.Caption = NullToStr(oDS.Tables("MSubItem").Rows(iSubItem).Item("Caption"))
                        ItemSubItem.Enabled = NullToBool(oDS.Tables("MSubItem").Rows(iSubItem).Item("Enable"))
                        ItemSubItem.Tag = NullToStr(oDS.Tables("MSubItem").Rows(iSubItem).Item("ObjectToRun")) & ":" & NullToLong(oDS.Tables("MSubItem").Rows(iSubItem).Item("NoID")) & ":" & NullToStr(oDS.Tables("MSubItem").Rows(iSubItem).Item("CaptionInDaftar"))
                        ItemSubItem.ImageIndex = NullTolInt(oDS.Tables("MSubItem").Rows(iSubItem).Item("Icon"))
                        strSQL = "SELECT DISTINCT HMenu.*, HUserD.[Visible], HUserD.[Enable]" & vbCrLf & _
                                 " FROM HMenu " & vbCrLf & _
                                 " INNER JOIN HUserD ON HUserD.IDMenu=HMenu.NoID " & vbCrLf & _
                                 " WHERE HMenu.IDBarSubItem=" & NullToLong(oDS.Tables("MSubItem").Rows(iSubItem).Item("NoID")) & " AND HMenu.IDParent=" & NullToLong(oDS.Tables("MParent").Rows(iParent).Item("NoID")) & " AND HMenu.IsAktif=1 AND HUserD.IDUser=" & IDUserAktif & " AND HUserD.Visible=1 ORDER BY HMenu.NoUrut"
                        oComm.CommandText = strSQL
                        If Not oDS.Tables("MMenuItem") Is Nothing Then
                            oDS.Tables("MMenuItem").Clear()
                        End If
                        oDA.Fill(oDS, "MMenuItem")
                        For iMenuItem As Integer = 0 To oDS.Tables("MMenuItem").Rows.Count - 1
                            ItemMenu = New BarButtonItem
                            ItemMenu.PaintStyle = BarItemPaintStyle.Standard
                            ItemMenu.Name = NullToStr(oDS.Tables("MMenuItem").Rows(iMenuItem).Item("Kode"))
                            ItemMenu.Caption = NullToStr(oDS.Tables("MMenuItem").Rows(iMenuItem).Item("Caption"))
                            ItemMenu.Enabled = NullToBool(oDS.Tables("MMenuItem").Rows(iMenuItem).Item("Enable"))
                            ItemMenu.Tag = NullToStr(oDS.Tables("MMenuItem").Rows(iMenuItem).Item("ObjectToRun")) & ":" & NullToLong(oDS.Tables("MMenuItem").Rows(iMenuItem).Item("NoID")) & ":" & NullToStr(oDS.Tables("MMenuItem").Rows(iMenuItem).Item("CaptionInDaftar"))
                            ItemMenu.ImageIndex = NullTolInt(oDS.Tables("MMenuItem").Rows(iMenuItem).Item("Icon"))
                            AddHandler ItemMenu.ItemClick, AddressOf Itemmenu_ItemClick
                            ItemSubItem.ItemLinks.Add(ItemMenu, NullToBool(oDS.Tables("MMenuItem").Rows(iMenuItem).Item("IsBeginGroup")))
                        Next
                        'AddHandler ItemSubItem.ItemClick, AddressOf Itemmenu_ItemClick
                        ItemParent.ItemLinks.Add(ItemSubItem, NullToBool(oDS.Tables("MSubItem").Rows(iSubItem).Item("IsBeginGroup")))
                    Else 'Button
                        ItemMenu = New BarButtonItem
                        ItemMenu.PaintStyle = BarItemPaintStyle.Standard
                        ItemMenu.Name = NullToStr(oDS.Tables("MSubItem").Rows(iSubItem).Item("Kode"))
                        ItemMenu.Caption = NullToStr(oDS.Tables("MSubItem").Rows(iSubItem).Item("Caption"))
                        ItemMenu.Enabled = NullToBool(oDS.Tables("MSubItem").Rows(iSubItem).Item("Enable"))
                        ItemMenu.Tag = NullToStr(oDS.Tables("MSubItem").Rows(iSubItem).Item("ObjectToRun")) & ":" & NullToLong(oDS.Tables("MSubItem").Rows(iSubItem).Item("NoID")) & ":" & NullToStr(oDS.Tables("MSubItem").Rows(iSubItem).Item("CaptionInDaftar"))
                        ItemMenu.ImageIndex = NullTolInt(oDS.Tables("MSubItem").Rows(iSubItem).Item("Icon"))
                        AddHandler ItemMenu.ItemClick, AddressOf Itemmenu_ItemClick
                        ItemParent.ItemLinks.Add(ItemMenu, NullToBool(oDS.Tables("MSubItem").Rows(iSubItem).Item("IsBeginGroup")))
                    End If
                Next
            Next
        Catch ex As Exception
            XtraMessageBox.Show("Info Kesalahan : " & ex.Message, NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            If oConn.State = ConnectionState.Open Then
                oConn.Close()
            End If
            oConn.Dispose()
            oComm.Dispose()
            oDA.Dispose()
            oDS.Dispose()
        End Try
    End Sub
    Private Sub Itemmenu_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
        Dim Str() As String
        Try
            Str = e.Item.Tag.ToString.Split(":")
            Select Case NullToStr(Str(0)).ToLower 'Object To Run
                Case "laporansomenggantung".ToLower
                    Dim frmEntri As frmLaporanSalesOrderDetil = Nothing
                    Dim F As Object
                    For Each F In MdiChildren
                        If TypeOf F Is frmLaporanSalesOrderDetil Then
                            frmEntri = F
                            Exit For
                        End If
                    Next
                    If frmEntri Is Nothing Then
                        frmEntri = New frmLaporanSalesOrderDetil
                        frmEntri.Judul = NullToStr(Str(2)).ToUpper
                        frmEntri.FormName = "frm" & NullToStr(Str(0))
                        frmEntri.WindowState = FormWindowState.Maximized
                        frmEntri.MdiParent = Me
                    End If
                    frmEntri.Show()
                    frmEntri.Focus()
                Case "LaporanSaldoPiutang".ToLower
                    Dim frmEntri As frmLaporanSaldoPiutang = Nothing
                    Dim F As Object
                    For Each F In MdiChildren
                        If TypeOf F Is frmLaporanSaldoPiutang Then
                            frmEntri = F
                            Exit For
                        End If
                    Next
                    If frmEntri Is Nothing Then
                        frmEntri = New frmLaporanSaldoPiutang
                        frmEntri.Judul = NullToStr(Str(2)).ToUpper
                        frmEntri.FormName = "frm" & NullToStr(Str(0))
                        frmEntri.WindowState = FormWindowState.Maximized
                        frmEntri.MdiParent = Me
                    End If
                    frmEntri.Show()
                    frmEntri.Focus()
                Case "LaporanAgingPiutang".ToLower
                    Dim frmEntri As frmLaporanAgingPiutang = Nothing
                    Dim F As Object
                    For Each F In MdiChildren
                        If TypeOf F Is frmLaporanAgingPiutang Then
                            frmEntri = F
                            Exit For
                        End If
                    Next
                    If frmEntri Is Nothing Then
                        frmEntri = New frmLaporanAgingPiutang
                        frmEntri.Judul = NullToStr(Str(2)).ToUpper
                        frmEntri.FormName = "frm" & NullToStr(Str(0))
                        frmEntri.WindowState = FormWindowState.Maximized
                        frmEntri.MdiParent = Me
                    End If
                    frmEntri.Show()
                    frmEntri.Focus()
                Case "LaporanPembelianDetil".ToLower
                    Dim frmEntri As frmLaporanPembelianDetil = Nothing
                    Dim F As Object
                    For Each F In MdiChildren
                        If TypeOf F Is frmLaporanPembelianDetil Then
                            frmEntri = F
                            Exit For
                        End If
                    Next
                    If frmEntri Is Nothing Then
                        frmEntri = New frmLaporanPembelianDetil
                        frmEntri.Judul = NullToStr(Str(2)).ToUpper
                        frmEntri.FormName = "frm" & NullToStr(Str(0))
                        frmEntri.WindowState = FormWindowState.Maximized
                        frmEntri.MdiParent = Me
                    End If
                    frmEntri.Show()
                    frmEntri.Focus()
                Case "LaporanPenjualanPerCustomer".ToLower
                    Dim frmEntri As frmLaporanPenjualanPerCustomer = Nothing
                    Dim F As Object
                    For Each F In MdiChildren
                        If TypeOf F Is frmLaporanPenjualanPerCustomer Then
                            frmEntri = F
                            Exit For
                        End If
                    Next
                    If frmEntri Is Nothing Then
                        frmEntri = New frmLaporanPenjualanPerCustomer
                        frmEntri.Judul = NullToStr(Str(2)).ToUpper
                        frmEntri.FormName = "frm" & NullToStr(Str(0))
                        frmEntri.WindowState = FormWindowState.Maximized
                        frmEntri.MdiParent = Me
                    End If
                    frmEntri.Show()
                    frmEntri.Focus()
                Case "LaporanPenjualanPalingLaku".ToLower
                    Dim frmEntri As frmLaporanPenjualanPalingLaku = Nothing
                    Dim F As Object
                    For Each F In MdiChildren
                        If TypeOf F Is frmLaporanPenjualanPalingLaku Then
                            frmEntri = F
                            Exit For
                        End If
                    Next
                    If frmEntri Is Nothing Then
                        frmEntri = New frmLaporanPenjualanPalingLaku
                        frmEntri.Judul = NullToStr(Str(2)).ToUpper
                        frmEntri.FormName = "frm" & NullToStr(Str(0))
                        frmEntri.WindowState = FormWindowState.Maximized
                        frmEntri.MdiParent = Me
                    End If
                    frmEntri.Show()
                    frmEntri.Focus()
                Case "LaporanPenjualanPerSales".ToLower
                    Dim frmEntri As frmLaporanPenjualanPerSales = Nothing
                    Dim F As Object
                    For Each F In MdiChildren
                        If TypeOf F Is frmLaporanPenjualanPerSales Then
                            frmEntri = F
                            Exit For
                        End If
                    Next
                    If frmEntri Is Nothing Then
                        frmEntri = New frmLaporanPenjualanPerSales
                        frmEntri.Judul = NullToStr(Str(2)).ToUpper
                        frmEntri.FormName = "frm" & NullToStr(Str(0))
                        frmEntri.WindowState = FormWindowState.Maximized
                        frmEntri.MdiParent = Me
                    End If
                    frmEntri.Show()
                    frmEntri.Focus()
                Case "LaporanKartuStok".ToLower
                    Dim frmEntri As frmLaporanKartuStok = Nothing
                    Dim F As Object
                    For Each F In MdiChildren
                        If TypeOf F Is frmLaporanKartuStok Then
                            frmEntri = F
                            Exit For
                        End If
                    Next
                    If frmEntri Is Nothing Then
                        frmEntri = New frmLaporanKartuStok
                        frmEntri.Judul = NullToStr(Str(2)).ToUpper
                        frmEntri.FormName = "frm" & NullToStr(Str(0))
                        frmEntri.WindowState = FormWindowState.Maximized
                        frmEntri.MdiParent = Me
                    End If
                    frmEntri.Show()
                    frmEntri.Focus()
                Case "LaporanSaldoStok".ToLower
                    Dim frmEntri As frmLaporanSaldoStok = Nothing
                    Dim F As Object
                    For Each F In MdiChildren
                        If TypeOf F Is frmLaporanSaldoStok Then
                            frmEntri = F
                            Exit For
                        End If
                    Next
                    If frmEntri Is Nothing Then
                        frmEntri = New frmLaporanSaldoStok
                        frmEntri.Judul = NullToStr(Str(2)).ToUpper
                        frmEntri.FormName = "frm" & NullToStr(Str(0))
                        frmEntri.WindowState = FormWindowState.Maximized
                        frmEntri.MdiParent = Me
                    End If
                    frmEntri.Show()
                    frmEntri.Focus()
                Case "DaftarBarang".ToLower
                    Dim frmEntri As frmDaftarMasterBarang = Nothing
                    Dim F As Object
                    For Each F In MdiChildren
                        If TypeOf F Is frmDaftarMasterBarang AndAlso F.name = "frm" & NullToStr(Str(0)) Then
                            frmEntri = F
                            Exit For
                        End If
                    Next
                    If frmEntri Is Nothing Then
                        frmEntri = New frmDaftarMasterBarang
                        frmEntri.Judul = NullToStr(Str(2)).ToUpper
                        frmEntri.QueryString = "SELECT HBarang.*, HSupplier1.Nama AS Supplier1, HSupplier2.Nama AS Supplier2, HSupplier3.Nama AS Supplier3, HKategori.Nama AS Kategori," & vbCrLf & _
                                                "HSatuan.Kode AS Satuan" & vbCrLf & _
                                                "FROM HBarang" & vbCrLf & _
                                                "LEFT JOIN HKategori ON HKategori.NoID=HBarang.IDKategori" & vbCrLf & _
                                                "LEFT JOIN HKontak HSupplier1 ON HSupplier1.NoID=HBarang.IDSupplier1" & vbCrLf & _
                                                "LEFT JOIN HKontak HSupplier2 ON HSupplier1.NoID=HBarang.IDSupplier2" & vbCrLf & _
                                                "LEFT JOIN HKontak HSupplier3 ON HSupplier1.NoID=HBarang.IDSupplier3" & vbCrLf & _
                                                "LEFT JOIN HSatuan ON HSatuan.NoID=HBarang.IDSatuanJual"
                        frmEntri.NamaTabel = "HBarang"
                        frmEntri.FormName = "frm" & NullToStr(Str(0))
                        frmEntri.Name = frmEntri.FormName.ToUpper
                        frmEntri.WindowState = FormWindowState.Maximized
                        frmEntri.MdiParent = Me
                    End If
                    frmEntri.Show()
                    frmEntri.Focus()
                Case "SettingPoin".ToLower
                    Dim x As New frmSettingPoin
                    x.ShowInTaskbar = False
                    x.StartPosition = FormStartPosition.CenterParent
                    If x.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                        XtraMessageBox.Show("Data Setting Poin telah disimpan.", NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    x.Dispose()
                Case "DaftarGudang".ToLower
                    Dim frmEntri As frmDaftarMaster = Nothing
                    Dim F As Object
                    For Each F In MdiChildren
                        If TypeOf F Is frmDaftarMaster AndAlso F.name = "frm" & NullToStr(Str(0)) Then
                            frmEntri = F
                            Exit For
                        End If
                    Next
                    If frmEntri Is Nothing Then
                        frmEntri = New frmDaftarMaster
                        frmEntri.Judul = NullToStr(Str(2)).ToUpper
                        frmEntri.QueryString = "SELECT HGudang.* FROM HGudang"
                        frmEntri.NamaTabel = "HGudang"
                        frmEntri.FormName = "frm" & NullToStr(Str(0))
                        frmEntri.Name = frmEntri.FormName.ToUpper
                        frmEntri.WindowState = FormWindowState.Maximized
                        frmEntri.MdiParent = Me
                    End If
                    frmEntri.Show()
                    frmEntri.Focus()
                Case "DaftarSalesOrder".ToLower
                    Dim frmEntri As frmDaftarTransaksi = Nothing
                    Dim F As Object
                    For Each F In MdiChildren
                        If TypeOf F Is frmDaftarTransaksi AndAlso F.name = "frm" & NullToStr(Str(0)) Then
                            frmEntri = F
                            Exit For
                        End If
                    Next
                    If frmEntri Is Nothing Then
                        frmEntri = New frmDaftarTransaksi
                        frmEntri.Judul = NullToStr(Str(2)).ToUpper
                        frmEntri.QueryString = ""
                        frmEntri.NamaTabel = "HSalesOrder"
                        frmEntri.FormName = "frm" & NullToStr(Str(0))
                        frmEntri.Name = frmEntri.FormName.ToUpper
                        frmEntri.WindowState = FormWindowState.Maximized
                        frmEntri.MdiParent = Me
                    End If
                    frmEntri.Show()
                    frmEntri.Focus()
                Case "DaftarReturPenjualan".ToLower
                    Dim frmEntri As frmDaftarTransaksi = Nothing
                    Dim F As Object
                    For Each F In MdiChildren
                        If TypeOf F Is frmDaftarTransaksi AndAlso F.name = "frm" & NullToStr(Str(0)) Then
                            frmEntri = F
                            Exit For
                        End If
                    Next
                    If frmEntri Is Nothing Then
                        frmEntri = New frmDaftarTransaksi
                        frmEntri.Judul = NullToStr(Str(2)).ToUpper
                        frmEntri.QueryString = ""
                        frmEntri.NamaTabel = "HReturJual"
                        frmEntri.FormName = "frm" & NullToStr(Str(0))
                        frmEntri.Name = frmEntri.FormName.ToUpper
                        frmEntri.WindowState = FormWindowState.Maximized
                        frmEntri.MdiParent = Me
                    End If
                    frmEntri.Show()
                    frmEntri.Focus()
                Case "DaftarPenjualan".ToLower
                    Dim frmEntri As frmDaftarTransaksi = Nothing
                    Dim F As Object
                    For Each F In MdiChildren
                        If TypeOf F Is frmDaftarTransaksi AndAlso F.name = "frm" & NullToStr(Str(0)) Then
                            frmEntri = F
                            Exit For
                        End If
                    Next
                    If frmEntri Is Nothing Then
                        frmEntri = New frmDaftarTransaksi
                        frmEntri.Judul = NullToStr(Str(2)).ToUpper
                        frmEntri.QueryString = ""
                        frmEntri.NamaTabel = "HJual"
                        frmEntri.FormName = "frm" & NullToStr(Str(0))
                        frmEntri.Name = frmEntri.FormName.ToUpper
                        frmEntri.WindowState = FormWindowState.Maximized
                        frmEntri.MdiParent = Me
                    End If
                    frmEntri.Show()
                    frmEntri.Focus()
                Case "DaftarPembelian".ToLower
                    Dim frmEntri As frmDaftarTransaksi = Nothing
                    Dim F As Object
                    For Each F In MdiChildren
                        If TypeOf F Is frmDaftarTransaksi AndAlso F.name = "frm" & NullToStr(Str(0)) Then
                            frmEntri = F
                            Exit For
                        End If
                    Next
                    If frmEntri Is Nothing Then
                        frmEntri = New frmDaftarTransaksi
                        frmEntri.Judul = NullToStr(Str(2)).ToUpper
                        frmEntri.QueryString = ""
                        frmEntri.NamaTabel = "HBeli"
                        frmEntri.FormName = "frm" & NullToStr(Str(0))
                        frmEntri.Name = frmEntri.FormName.ToUpper
                        frmEntri.WindowState = FormWindowState.Maximized
                        frmEntri.MdiParent = Me
                    End If
                    frmEntri.Show()
                    frmEntri.Focus()
                Case "DaftarPenyesuaian".ToLower
                    Dim frmEntri As frmDaftarTransaksi = Nothing
                    Dim F As Object
                    For Each F In MdiChildren
                        If TypeOf F Is frmDaftarTransaksi AndAlso F.name = "frm" & NullToStr(Str(0)) Then
                            frmEntri = F
                            Exit For
                        End If
                    Next
                    If frmEntri Is Nothing Then
                        frmEntri = New frmDaftarTransaksi
                        frmEntri.Judul = NullToStr(Str(2)).ToUpper
                        frmEntri.QueryString = ""
                        frmEntri.NamaTabel = "HPenyesuaian"
                        frmEntri.FormName = "frm" & NullToStr(Str(0))
                        frmEntri.Name = frmEntri.FormName.ToUpper
                        frmEntri.WindowState = FormWindowState.Maximized
                        frmEntri.MdiParent = Me
                    End If
                    frmEntri.Show()
                    frmEntri.Focus()
                Case "DaftarTukarPoin".ToLower
                    Dim frmEntri As frmDaftarTransaksi = Nothing
                    Dim F As Object
                    For Each F In MdiChildren
                        If TypeOf F Is frmDaftarTransaksi AndAlso F.name = "frm" & NullToStr(Str(0)) Then
                            frmEntri = F
                            Exit For
                        End If
                    Next
                    If frmEntri Is Nothing Then
                        frmEntri = New frmDaftarTransaksi
                        frmEntri.Judul = NullToStr(Str(2)).ToUpper
                        frmEntri.QueryString = "SELECT HTukarPoin.*, HKontak.Nama AS Customer FROM HTukarPoin LEFT JOIN HKontak ON HKontak.NoID=HTukarPoin.IDCustomer "
                        frmEntri.NamaTabel = "HTukarPoin"
                        frmEntri.FormName = "frm" & NullToStr(Str(0))
                        frmEntri.Name = frmEntri.FormName.ToUpper
                        frmEntri.WindowState = FormWindowState.Maximized
                        frmEntri.MdiParent = Me
                    End If
                    frmEntri.Show()
                    frmEntri.Focus()
                Case "DaftarPembayaranPiutang".ToLower
                    Dim frmEntri As frmDaftarTransaksi = Nothing
                    Dim F As Object
                    For Each F In MdiChildren
                        If TypeOf F Is frmDaftarTransaksi AndAlso F.name = "frm" & NullToStr(Str(0)) Then
                            frmEntri = F
                            Exit For
                        End If
                    Next
                    If frmEntri Is Nothing Then
                        frmEntri = New frmDaftarTransaksi
                        frmEntri.Judul = NullToStr(Str(2)).ToUpper
                        frmEntri.QueryString = ""
                        frmEntri.NamaTabel = "HBayarPiutang"
                        frmEntri.FormName = "frm" & NullToStr(Str(0))
                        frmEntri.Name = frmEntri.FormName.ToUpper
                        frmEntri.WindowState = FormWindowState.Maximized
                        frmEntri.MdiParent = Me
                    End If
                    frmEntri.Show()
                    frmEntri.Focus()
                Case "DaftarSatuan".ToLower
                    Dim frmEntri As frmDaftarMaster = Nothing
                    Dim F As Object
                    For Each F In MdiChildren
                        If TypeOf F Is frmDaftarMaster AndAlso F.name = "frm" & NullToStr(Str(0)) Then
                            frmEntri = F
                            Exit For
                        End If
                    Next
                    If frmEntri Is Nothing Then
                        frmEntri = New frmDaftarMaster
                        frmEntri.Judul = NullToStr(Str(2)).ToUpper
                        frmEntri.QueryString = "SELECT HSatuan.* FROM HSatuan"
                        frmEntri.NamaTabel = "HSatuan"
                        frmEntri.FormName = "frm" & NullToStr(Str(0))
                        frmEntri.Name = frmEntri.FormName.ToUpper
                        frmEntri.WindowState = FormWindowState.Maximized
                        frmEntri.MdiParent = Me
                    End If
                    frmEntri.Show()
                    frmEntri.Focus()
                Case "DaftarKategori".ToLower
                    Dim frmEntri As frmDaftarMaster = Nothing
                    Dim F As Object
                    For Each F In MdiChildren
                        If TypeOf F Is frmDaftarMaster AndAlso F.name = "frm" & NullToStr(Str(0)) Then
                            frmEntri = F
                            Exit For
                        End If
                    Next
                    If frmEntri Is Nothing Then
                        frmEntri = New frmDaftarMaster
                        frmEntri.Judul = NullToStr(Str(2)).ToUpper
                        frmEntri.QueryString = "SELECT HKategori.*, HParent.Kode + ' ' + HParent.Nama AS Parent FROM HKategori LEFT JOIN HKategori HParent ON HParent.NoID=HKategori.IDKategori"
                        frmEntri.NamaTabel = "HKategori"
                        frmEntri.FormName = "frm" & NullToStr(Str(0))
                        frmEntri.Name = frmEntri.FormName.ToUpper
                        frmEntri.WindowState = FormWindowState.Maximized
                        frmEntri.MdiParent = Me
                    End If
                    frmEntri.Show()
                    frmEntri.Focus()
                Case "DaftarSupplierCustomer".ToLower
                    Dim frmEntri As frmDaftarKontak = Nothing
                    Dim F As Object
                    For Each F In MdiChildren
                        If TypeOf F Is frmDaftarKontak Then
                            frmEntri = F
                            Exit For
                        End If
                    Next
                    If frmEntri Is Nothing Then
                        frmEntri = New frmDaftarKontak
                        frmEntri.NamaTabel = "HKontak"
                        frmEntri.FormName = "frm" & NullToStr(Str(0))
                        frmEntri.Name = frmEntri.FormName.ToUpper
                        frmEntri.WindowState = FormWindowState.Maximized
                        frmEntri.MdiParent = Me
                    End If
                    frmEntri.Show()
                    frmEntri.Focus()
            End Select
        Catch ex As Exception

        End Try
    End Sub
    Private Sub mnLogin_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles mnLogin.ItemClick
        Login()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        TanggalSystem = Date.Now
        mnStatusTanggal.Caption = "Tanggal Aktif : " & TanggalSystem.ToString("dd/MM/yyyy HH:mm")
    End Sub

    Private Sub frmUtama_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If XtraMessageBox.Show("Yakin ingin keluar dari " & NamaAplikasi & "?", NamaAplikasi, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
            e.Cancel = True
        Else
            TulisIni("Applications", "Skins", DefaultLookAndFeel1.LookAndFeel.SkinName.ToString)
        End If
    End Sub
    Private Sub OnPaintStyleClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
        SkinKu = e.Item.Tag.ToString()
        DefaultLookAndFeel1.LookAndFeel.SetSkinStyle(SkinKu)
    End Sub
    Private Sub Loadskin()
        Try
            For Each skin As DevExpress.Skins.SkinContainer In DevExpress.Skins.SkinManager.Default.Skins
                Dim item As DevExpress.XtraBars.BarButtonItem = BarManager1.Items.CreateButton(skin.SkinName)
                item.Tag = skin.SkinName
                'Dim item As BarButtonItem = New BarButtonItem(BarManager1, skin.SkinName)
                mnSkins.AddItem(item)
                AddHandler item.ItemClick, AddressOf OnPaintStyleClick
            Next skin
            SkinKu = BacaIni("Applications", "Skins", "Summer 2008")
            If SkinKu = "" Or SkinKu = Nothing Then
                SkinKu = "Summer 2008"
            End If
            Me.DefaultLookAndFeel1.LookAndFeel.UseWindowsXPTheme = False
            Me.DefaultLookAndFeel1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin
            Me.DefaultLookAndFeel1.LookAndFeel.SkinName = SkinKu
        Catch ex As Exception
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Admin Says", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmUtama_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Loadskin()
        BarCKTabModel.Checked = True
        mniCascade.Visibility = BarItemVisibility.Never
        mniTileHorizontal.Visibility = BarItemVisibility.Never
        mniTileVertical.Visibility = BarItemVisibility.Never
        Timer1.Interval = 5000
        Timer1.Enabled = True
    End Sub

    Private Sub mnExit_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles mnExit.ItemClick
        Me.Close()
    End Sub

    Private Sub BarCKTabModel_CheckedChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarCKTabModel.CheckedChanged
        If Not BarCKTabModel.Checked Then
            XtraTabbedMdiManager1.MdiParent = Nothing
            mniCascade.Visibility = BarItemVisibility.Always
            mniTileHorizontal.Visibility = BarItemVisibility.Always
            mniTileVertical.Visibility = BarItemVisibility.Always
        Else
            XtraTabbedMdiManager1.MdiParent = Me
            mniCascade.Visibility = BarItemVisibility.Never
            mniTileHorizontal.Visibility = BarItemVisibility.Never
            mniTileVertical.Visibility = BarItemVisibility.Never
        End If
    End Sub

    Private Sub mniCascade_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles mniCascade.ItemClick
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub mniTileVertical_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles mniTileVertical.ItemClick
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub mniTileHorizontal_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles mniTileHorizontal.ItemClick
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub BarButtonItem1_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Dim x As New frmSettingDatabase
        If x.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then

        End If
    End Sub

    Private Sub mnSettingPerusahaan_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles mnSettingPerusahaan.ItemClick
        If IsLogin Then

        End If
    End Sub

    Private Sub mnUserAksesMenu_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles mnUserAksesMenu.ItemClick
        If IsLogin Then
            Dim frmEntri As frmDaftarMaster = Nothing
            Dim F As Object
            For Each F In MdiChildren
                If TypeOf F Is frmDaftarMaster AndAlso F.name = "frmDaftarUser" Then
                    frmEntri = F
                    Exit For
                End If
            Next
            If frmEntri Is Nothing Then
                frmEntri = New frmDaftarMaster
                frmEntri.Judul = "DAFTAR AKSES USER DAN MENU"
                frmEntri.QueryString = "SELECT HUser.* FROM HUser"
                frmEntri.NamaTabel = "HUser"
                frmEntri.FormName = "frmDaftarUser"
                frmEntri.Name = frmEntri.FormName
                frmEntri.WindowState = FormWindowState.Maximized
                frmEntri.MdiParent = Me
            End If
            frmEntri.Show()
            frmEntri.Focus()
        End If
    End Sub

    Private Sub ckEditReport_CheckedChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles ckEditReport.CheckedChanged
        IsEditReport = ckEditReport.Checked
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
End Class