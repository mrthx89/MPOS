<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits DevExpress.XtraBars.Ribbon.RibbonForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.RC = New DevExpress.XtraBars.Ribbon.RibbonControl
        Me.mnSettingDB = New DevExpress.XtraBars.BarButtonItem
        Me.mnLogin = New DevExpress.XtraBars.BarButtonItem
        Me.mnDaftarKategori = New DevExpress.XtraBars.BarButtonItem
        Me.mnDaftarSatuan = New DevExpress.XtraBars.BarButtonItem
        Me.mnDaftarBarang = New DevExpress.XtraBars.BarButtonItem
        Me.BarStaticNamaServer = New DevExpress.XtraBars.BarStaticItem
        Me.BarStaticNamaDB = New DevExpress.XtraBars.BarStaticItem
        Me.BarStaticNamaUserAktif = New DevExpress.XtraBars.BarStaticItem
        Me.imageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup
        Me.RibbonStatusBar = New DevExpress.XtraBars.Ribbon.RibbonStatusBar
        Me.XtraTabbedMdiManager1 = New DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(Me.components)
        Me.defaultLookAndFeel1 = New DevExpress.LookAndFeel.DefaultLookAndFeel(Me.components)
        Me.mnAlamat = New DevExpress.XtraBars.BarButtonItem
        CType(Me.RC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabbedMdiManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RC
        '
        Me.RC.ApplicationButtonText = Nothing
        '
        '
        '
        Me.RC.ExpandCollapseItem.Id = 0
        Me.RC.ExpandCollapseItem.Name = ""
        Me.RC.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RC.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RC.ExpandCollapseItem, Me.mnSettingDB, Me.mnLogin, Me.mnDaftarKategori, Me.mnDaftarSatuan, Me.mnDaftarBarang, Me.BarStaticNamaServer, Me.BarStaticNamaDB, Me.BarStaticNamaUserAktif, Me.mnAlamat})
        Me.RC.LargeImages = Me.imageCollection1
        Me.RC.Location = New System.Drawing.Point(0, 0)
        Me.RC.MaxItemId = 10
        Me.RC.Name = "RC"
        Me.RC.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage1})
        Me.RC.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010
        Me.RC.SelectedPage = Me.RibbonPage1
        Me.RC.Size = New System.Drawing.Size(763, 144)
        Me.RC.StatusBar = Me.RibbonStatusBar
        Me.RC.Toolbar.ItemLinks.Add(Me.mnLogin)
        '
        'mnSettingDB
        '
        Me.mnSettingDB.Caption = "Koneksi Database"
        Me.mnSettingDB.Id = 1
        Me.mnSettingDB.ImageIndex = 12
        Me.mnSettingDB.ImageIndexDisabled = 12
        Me.mnSettingDB.LargeImageIndex = 12
        Me.mnSettingDB.LargeImageIndexDisabled = 12
        Me.mnSettingDB.Name = "mnSettingDB"
        Me.mnSettingDB.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'mnLogin
        '
        Me.mnLogin.Caption = "Login"
        Me.mnLogin.Id = 2
        Me.mnLogin.LargeImageIndex = 2
        Me.mnLogin.LargeImageIndexDisabled = 2
        Me.mnLogin.Name = "mnLogin"
        Me.mnLogin.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'mnDaftarKategori
        '
        Me.mnDaftarKategori.Caption = "Kategori / Golongan Barang"
        Me.mnDaftarKategori.Id = 3
        Me.mnDaftarKategori.ImageIndex = 6
        Me.mnDaftarKategori.ImageIndexDisabled = 6
        Me.mnDaftarKategori.LargeImageIndex = 6
        Me.mnDaftarKategori.LargeImageIndexDisabled = 6
        Me.mnDaftarKategori.Name = "mnDaftarKategori"
        Me.mnDaftarKategori.RibbonStyle = CType(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) _
                    Or DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText), DevExpress.XtraBars.Ribbon.RibbonItemStyles)
        '
        'mnDaftarSatuan
        '
        Me.mnDaftarSatuan.Caption = "Satuan Barang"
        Me.mnDaftarSatuan.Id = 4
        Me.mnDaftarSatuan.ImageIndex = 16
        Me.mnDaftarSatuan.ImageIndexDisabled = 16
        Me.mnDaftarSatuan.LargeImageIndex = 16
        Me.mnDaftarSatuan.LargeImageIndexDisabled = 16
        Me.mnDaftarSatuan.Name = "mnDaftarSatuan"
        Me.mnDaftarSatuan.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText
        '
        'mnDaftarBarang
        '
        Me.mnDaftarBarang.Caption = "Daftar Barang / Inventor"
        Me.mnDaftarBarang.Id = 5
        Me.mnDaftarBarang.ImageIndex = 24
        Me.mnDaftarBarang.ImageIndexDisabled = 24
        Me.mnDaftarBarang.LargeImageIndex = 24
        Me.mnDaftarBarang.LargeImageIndexDisabled = 24
        Me.mnDaftarBarang.Name = "mnDaftarBarang"
        Me.mnDaftarBarang.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'BarStaticNamaServer
        '
        Me.BarStaticNamaServer.Caption = "Server : "
        Me.BarStaticNamaServer.Id = 6
        Me.BarStaticNamaServer.Name = "BarStaticNamaServer"
        Me.BarStaticNamaServer.TextAlignment = System.Drawing.StringAlignment.Near
        '
        'BarStaticNamaDB
        '
        Me.BarStaticNamaDB.Caption = "Database : "
        Me.BarStaticNamaDB.Id = 7
        Me.BarStaticNamaDB.Name = "BarStaticNamaDB"
        Me.BarStaticNamaDB.TextAlignment = System.Drawing.StringAlignment.Near
        '
        'BarStaticNamaUserAktif
        '
        Me.BarStaticNamaUserAktif.Caption = "User Aktif :"
        Me.BarStaticNamaUserAktif.Id = 8
        Me.BarStaticNamaUserAktif.Name = "BarStaticNamaUserAktif"
        Me.BarStaticNamaUserAktif.TextAlignment = System.Drawing.StringAlignment.Near
        '
        'imageCollection1
        '
        Me.imageCollection1.ImageSize = New System.Drawing.Size(32, 32)
        Me.imageCollection1.ImageStream = CType(resources.GetObject("imageCollection1.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        '
        'RibbonPage1
        '
        Me.RibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup1})
        Me.RibbonPage1.Name = "RibbonPage1"
        Me.RibbonPage1.Text = "Master"
        Me.RibbonPage1.Visible = False
        '
        'RibbonPageGroup1
        '
        Me.RibbonPageGroup1.ItemLinks.Add(Me.mnDaftarKategori)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.mnDaftarSatuan)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.mnDaftarBarang)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.mnAlamat)
        Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
        Me.RibbonPageGroup1.Text = "Daftar Master"
        '
        'RibbonStatusBar
        '
        Me.RibbonStatusBar.ItemLinks.Add(Me.BarStaticNamaServer)
        Me.RibbonStatusBar.ItemLinks.Add(Me.BarStaticNamaDB)
        Me.RibbonStatusBar.ItemLinks.Add(Me.BarStaticNamaUserAktif)
        Me.RibbonStatusBar.Location = New System.Drawing.Point(0, 417)
        Me.RibbonStatusBar.Name = "RibbonStatusBar"
        Me.RibbonStatusBar.Ribbon = Me.RC
        Me.RibbonStatusBar.Size = New System.Drawing.Size(763, 32)
        '
        'XtraTabbedMdiManager1
        '
        Me.XtraTabbedMdiManager1.MdiParent = Me
        '
        'defaultLookAndFeel1
        '
        Me.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2010 Black"
        '
        'mnAlamat
        '
        Me.mnAlamat.Caption = "Supplier dan Customer"
        Me.mnAlamat.Id = 9
        Me.mnAlamat.Name = "mnAlamat"
        Me.mnAlamat.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(763, 449)
        Me.Controls.Add(Me.RibbonStatusBar)
        Me.Controls.Add(Me.RC)
        Me.IsMdiContainer = True
        Me.Name = "frmMain"
        Me.Ribbon = Me.RC
        Me.StatusBar = Me.RibbonStatusBar
        Me.Text = "mPOS - System"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.RC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabbedMdiManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents RC As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents RibbonStatusBar As DevExpress.XtraBars.Ribbon.RibbonStatusBar
    Friend WithEvents XtraTabbedMdiManager1 As DevExpress.XtraTabbedMdi.XtraTabbedMdiManager
    Friend WithEvents mnSettingDB As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mnLogin As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mnDaftarKategori As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mnDaftarSatuan As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mnDaftarBarang As DevExpress.XtraBars.BarButtonItem
    Public Shared WithEvents ImageCollectionLarge As DevExpress.Utils.ImageCollection
    Public Shared WithEvents ImageCollectionSmall As DevExpress.Utils.ImageCollection
    Public Shared WithEvents ImageCollectionCommands As DevExpress.Utils.ImageCollection
    Public Shared WithEvents ImageCollectionShortcut As DevExpress.Utils.ImageCollection

    Private WithEvents defaultLookAndFeel1 As DevExpress.LookAndFeel.DefaultLookAndFeel


    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Elliteserv.StyleIcon.IconShock.RubahIconMenu(ImageCollectionLarge)
        Elliteserv.StyleIcon.IconShock.RubahIconMenu(ImageCollectionSmall)
        Elliteserv.StyleIcon.IconShock.RubahIconCommand64(ImageCollectionCommands)
        Elliteserv.StyleIcon.IconShock.RubahIconShortcut64(ImageCollectionShortcut)

        ImageCollectionLarge.ImageSize = New System.Drawing.Size(32, 32)
        ImageCollectionSmall.ImageSize = New System.Drawing.Size(16, 16)
        ImageCollectionShortcut.ImageSize = New System.Drawing.Size(32, 32)
        ImageCollectionCommands.ImageSize = New System.Drawing.Size(32, 32)

        RC.LargeImages = ImageCollectionLarge
        RC.Images = ImageCollectionSmall


    End Sub
    Private WithEvents imageCollection1 As DevExpress.Utils.ImageCollection
    Friend WithEvents BarStaticNamaServer As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents BarStaticNamaDB As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents BarStaticNamaUserAktif As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents mnAlamat As DevExpress.XtraBars.BarButtonItem
End Class
