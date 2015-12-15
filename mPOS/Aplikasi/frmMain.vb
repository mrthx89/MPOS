Imports DevExpress.XtraEditors
Imports Elliteserv.StyleIcon
Imports Elliteserv.SQLServer.Connect
Imports Elliteserv.Fungsi.Utils
Imports Elliteserv.Fungsi.Ini

Public Class frmMain

    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If XtraMessageBox.Show("Ingin Keluar dari Aplikasi " & NamaAplikasi & "?", NamaAplikasi, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
            e.Cancel = True
        Else
            End
        End If
    End Sub

    Private Sub GetStatusApplikasi()
        BarStaticNamaServer.Caption = "Server : " & Elliteserv.SQLServer.Connect.NamaServerMSSQL
        BarStaticNamaDB.Caption = "Database : " & Elliteserv.SQLServer.Connect.NamaDatabaseMSSQL
        BarStaticNamaUserAktif.Caption = "User Aktif : " & NamaUserAktif
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
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
                IsValidasiLogin("", "")
                AktifkanMenuUser()
                GetStatusApplikasi()
                IsLogin = False
            Else
                If x.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    AktifkanMenuUser()
                    GetStatusApplikasi()
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
        Dim ds As New DataSet
        'Dim RibbonPage() As DevExpress.XtraBars.Ribbon.RibbonPage = Nothing
        'Dim GroupKategori As DevExpress.XtraBars.Ribbon.RibbonPageGroup = Nothing
        Try


            'RC.Items.Clear()
            'RC.Pages.Clear()
            'RC.UnMergeRibbon()
            'Parent
            'For Each ctl In RC.Items
            '    If TypeOf ctl Is DevExpress.XtraBars.BarButtonItem Then
            '        DirectCast(ctl, DevExpress.XtraBars.BarButtonItem).Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            '        DirectCast(ctl, DevExpress.XtraBars.BarButtonItem).Enabled = False
            '    End If
            'Next
            'SQL = "SELECT [NoID],[Kode],[Caption],[CaptionInDaftar],[ObjectToRun],[Icon],[NoUrut],[IsAktif]" & vbCrLf & _
            '      " FROM [HMenu] WHERE [IDParent]=-1 AND [IsAktif]=1 ORDER BY [NoUrut]"
            'If EksekusiDataset(ds, "Page", SQL) Then
            '    Dim RibbonPage(ds.Tables("Page").Rows.Count - 1) As DevExpress.XtraBars.Ribbon.RibbonPage
            '    RC.Pages.Capacity = ds.Tables("Page").Rows.Count - 1
            '    RC.Manager.UseAltKeyForMenu = True
            '    RC.Manager.UseF10KeyForMenu = True
            '    RC.UnMergeRibbon()
            '    'RC.Manager = New DevExpress.XtraBars.Ribbon.RibbonBarManager
            '    For iPage As Integer = 1 To ds.Tables("Page").Rows.Count
            '        RibbonPage(iPage) = New DevExpress.XtraBars.Ribbon.RibbonPage
            '        RibbonPage(iPage).Name = "RP" & NullToStr(ds.Tables("Page").Rows(iPage).Item("Kode"))
            '        RibbonPage(iPage).Text = NullToStr(ds.Tables("Page").Rows(iPage).Item("Caption"))
            '        'RibbonPage(iPage).IsInDefaultCategory = True
            '        'RibbonPage(iPage).PageInfo = ""
            '        Try
            '            RC.Pages.Add(RibbonPage(iPage))
            '            'RC.Update()
            '            'RC.MergeRibbon(RibbonPage(iPage))
            '        Catch ex As Exception
            '            'XtraMessageBox.Show("Info Kesalahan : " & ex.Message, NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
            '        End Try
            '    Next
            '    'RC.Update()
            '    RC.Refresh()
            '    'RC.Pages.Capacity = ds.Tables("Page").Rows.Count - 1 + 1

            '    'RC.Pages.AddRange(RibbonPage)
            'End If
            ''RibbonPage1. = RibbonControl.Pages.Count - 1
        Catch ex As Exception
            XtraMessageBox.Show("Info Kesalahan : " & ex.Message, NamaAplikasi, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub mnLogin_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles mnLogin.ItemClick
        Login()
    End Sub

    Private Sub mnDaftarKategori_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles mnDaftarKategori.ItemClick
        'KODE DIBAWAH UNTUK MEMBUKA FORM HANYA 1
        Dim frmEntri As frmDaftarMaster = Nothing
        Dim F As Object
        For Each F In MdiChildren
            If TypeOf F Is frmDaftarMaster Then
                If TryCast(F, frmDaftarMaster).FormName.ToUpper = "DAFTARKATEGORI" Then
                    frmEntri = F
                    Exit For
                End If
            End If
        Next
        If frmEntri Is Nothing Then
            frmEntri = New frmDaftarMaster
            frmEntri.FormName = "DAFTARKATEGORI"
            frmEntri.Judul = "DAFTAR KATEGORI / GOLONGAN"
            frmEntri.QueryString = "SELECT HKategori.*, HParent.Nama AS Parent FROM HKategori LEFT JOIN HKategori HParent ON HParent.NoID=HKategori.IDKategori "
            frmEntri.NamaTabel = "HKategori"
            frmEntri.WindowState = FormWindowState.Maximized
            frmEntri.MdiParent = Me
        End If
        frmEntri.Show()
        frmEntri.Focus()
    End Sub

    Private Sub mnDaftarSatuan_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles mnDaftarSatuan.ItemClick
        'KODE DIBAWAH UNTUK MEMBUKA FORM HANYA 1
        Dim frmEntri As frmDaftarMaster = Nothing
        Dim F As Object
        For Each F In MdiChildren
            If TypeOf F Is frmDaftarMaster Then
                If TryCast(F, frmDaftarMaster).FormName.ToUpper = "DAFTARSATUAN" Then
                    frmEntri = F
                    Exit For
                End If
            End If
        Next
        If frmEntri Is Nothing Then
            frmEntri = New frmDaftarMaster
            frmEntri.FormName = "DAFTARSATUAN"
            frmEntri.Judul = "DAFTAR SATUAN"
            frmEntri.QueryString = "SELECT HSatuan.* FROM HSatuan "
            frmEntri.NamaTabel = "HSatuan"
            frmEntri.WindowState = FormWindowState.Maximized
            frmEntri.MdiParent = Me
        End If
        frmEntri.Show()
        frmEntri.Focus()
    End Sub
End Class