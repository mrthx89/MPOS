<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUtama
    Inherits DevExpress.XtraEditors.XtraForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUtama))
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar
        Me.Bar2 = New DevExpress.XtraBars.Bar
        Me.BarSubItem1 = New DevExpress.XtraBars.BarSubItem
        Me.mnLogin = New DevExpress.XtraBars.BarButtonItem
        Me.mnExit = New DevExpress.XtraBars.BarButtonItem
        Me.BarSubItem4 = New DevExpress.XtraBars.BarSubItem
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem
        Me.ckEditReport = New DevExpress.XtraBars.BarCheckItem
        Me.mnUserAksesMenu = New DevExpress.XtraBars.BarButtonItem
        Me.mnSkins = New DevExpress.XtraBars.BarSubItem
        Me.BarSubItem3 = New DevExpress.XtraBars.BarSubItem
        Me.BarCKTabModel = New DevExpress.XtraBars.BarCheckItem
        Me.mniCascade = New DevExpress.XtraBars.BarButtonItem
        Me.mniTileVertical = New DevExpress.XtraBars.BarButtonItem
        Me.mniTileHorizontal = New DevExpress.XtraBars.BarButtonItem
        Me.BarMdiChildrenListItem = New DevExpress.XtraBars.BarMdiChildrenListItem
        Me.BarSubItem2 = New DevExpress.XtraBars.BarSubItem
        Me.mnHelp = New DevExpress.XtraBars.BarButtonItem
        Me.mnAbout = New DevExpress.XtraBars.BarButtonItem
        Me.Bar3 = New DevExpress.XtraBars.Bar
        Me.mnStatusServer = New DevExpress.XtraBars.BarStaticItem
        Me.mnStatusDatabase = New DevExpress.XtraBars.BarStaticItem
        Me.mnStatusUser = New DevExpress.XtraBars.BarStaticItem
        Me.mnStatusTanggal = New DevExpress.XtraBars.BarStaticItem
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl
        Me.ImageCollectionSmall = New DevExpress.Utils.ImageCollection(Me.components)
        Me.mnSetting = New DevExpress.XtraBars.BarSubItem
        Me.mnSettingPerusahaan = New DevExpress.XtraBars.BarButtonItem
        Me.ImageCollectionLarge = New DevExpress.Utils.ImageCollection(Me.components)
        Me.XtraTabbedMdiManager1 = New DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.DefaultLookAndFeel1 = New DevExpress.LookAndFeel.DefaultLookAndFeel(Me.components)
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollectionSmall, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollectionLarge, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabbedMdiManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BarManager1
        '
        Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar1, Me.Bar2, Me.Bar3})
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Images = Me.ImageCollectionSmall
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.mnStatusServer, Me.mnStatusDatabase, Me.mnStatusUser, Me.mnStatusTanggal, Me.BarSubItem1, Me.mnExit, Me.mnLogin, Me.BarSubItem2, Me.mnHelp, Me.mnAbout, Me.BarSubItem3, Me.mniCascade, Me.BarCKTabModel, Me.mniTileVertical, Me.mniTileHorizontal, Me.BarMdiChildrenListItem, Me.BarSubItem4, Me.BarButtonItem1, Me.ckEditReport, Me.mnSkins, Me.mnSetting, Me.mnSettingPerusahaan, Me.mnUserAksesMenu})
        Me.BarManager1.LargeImages = Me.ImageCollectionLarge
        Me.BarManager1.MainMenu = Me.Bar2
        Me.BarManager1.MaxItemId = 24
        Me.BarManager1.StatusBar = Me.Bar3
        '
        'Bar1
        '
        Me.Bar1.BarName = "Tools"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 1
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar1.Text = "Tools"
        '
        'Bar2
        '
        Me.Bar2.BarName = "Main menu"
        Me.Bar2.DockCol = 0
        Me.Bar2.DockRow = 0
        Me.Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarSubItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.BarSubItem4), New DevExpress.XtraBars.LinkPersistInfo(Me.BarSubItem3), New DevExpress.XtraBars.LinkPersistInfo(Me.BarSubItem2)})
        Me.Bar2.OptionsBar.MultiLine = True
        Me.Bar2.OptionsBar.UseWholeRow = True
        Me.Bar2.Text = "Main menu"
        '
        'BarSubItem1
        '
        Me.BarSubItem1.Caption = "&File"
        Me.BarSubItem1.Id = 4
        Me.BarSubItem1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.mnLogin), New DevExpress.XtraBars.LinkPersistInfo(Me.mnExit, True)})
        Me.BarSubItem1.Name = "BarSubItem1"
        '
        'mnLogin
        '
        Me.mnLogin.Caption = "&Login"
        Me.mnLogin.Id = 6
        Me.mnLogin.ItemShortcut = New DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.L))
        Me.mnLogin.Name = "mnLogin"
        '
        'mnExit
        '
        Me.mnExit.Caption = "&Keluar"
        Me.mnExit.Id = 5
        Me.mnExit.ItemShortcut = New DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Q))
        Me.mnExit.Name = "mnExit"
        '
        'BarSubItem4
        '
        Me.BarSubItem4.Caption = "&System"
        Me.BarSubItem4.Id = 17
        Me.BarSubItem4.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.ckEditReport), New DevExpress.XtraBars.LinkPersistInfo(Me.mnUserAksesMenu, True), New DevExpress.XtraBars.LinkPersistInfo(Me.mnSkins, True)})
        Me.BarSubItem4.Name = "BarSubItem4"
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Caption = "&Koneksi Database"
        Me.BarButtonItem1.Id = 18
        Me.BarButtonItem1.Name = "BarButtonItem1"
        '
        'ckEditReport
        '
        Me.ckEditReport.Caption = "&Edit Report"
        Me.ckEditReport.Id = 19
        Me.ckEditReport.ItemShortcut = New DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E))
        Me.ckEditReport.Name = "ckEditReport"
        '
        'mnUserAksesMenu
        '
        Me.mnUserAksesMenu.Caption = "User Akses Menu"
        Me.mnUserAksesMenu.Id = 23
        Me.mnUserAksesMenu.Name = "mnUserAksesMenu"
        '
        'mnSkins
        '
        Me.mnSkins.Caption = "&Skins"
        Me.mnSkins.Id = 20
        Me.mnSkins.Name = "mnSkins"
        '
        'BarSubItem3
        '
        Me.BarSubItem3.Caption = "&Window"
        Me.BarSubItem3.Id = 11
        Me.BarSubItem3.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarCKTabModel), New DevExpress.XtraBars.LinkPersistInfo(Me.mniCascade, True), New DevExpress.XtraBars.LinkPersistInfo(Me.mniTileVertical), New DevExpress.XtraBars.LinkPersistInfo(Me.mniTileHorizontal), New DevExpress.XtraBars.LinkPersistInfo(Me.BarMdiChildrenListItem, True)})
        Me.BarSubItem3.Name = "BarSubItem3"
        '
        'BarCKTabModel
        '
        Me.BarCKTabModel.Caption = "&Gunakan Tab Model"
        Me.BarCKTabModel.Checked = True
        Me.BarCKTabModel.Id = 13
        Me.BarCKTabModel.Name = "BarCKTabModel"
        '
        'mniCascade
        '
        Me.mniCascade.Caption = "&Cascade"
        Me.mniCascade.Id = 12
        Me.mniCascade.Name = "mniCascade"
        '
        'mniTileVertical
        '
        Me.mniTileVertical.Caption = "Tile &Vertical"
        Me.mniTileVertical.Id = 14
        Me.mniTileVertical.Name = "mniTileVertical"
        '
        'mniTileHorizontal
        '
        Me.mniTileHorizontal.Caption = "Tile &Horinzontal"
        Me.mniTileHorizontal.Id = 15
        Me.mniTileHorizontal.Name = "mniTileHorizontal"
        '
        'BarMdiChildrenListItem
        '
        Me.BarMdiChildrenListItem.Caption = "&Window List"
        Me.BarMdiChildrenListItem.Id = 16
        Me.BarMdiChildrenListItem.Name = "BarMdiChildrenListItem"
        '
        'BarSubItem2
        '
        Me.BarSubItem2.Caption = "&About"
        Me.BarSubItem2.Id = 8
        Me.BarSubItem2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.mnHelp), New DevExpress.XtraBars.LinkPersistInfo(Me.mnAbout)})
        Me.BarSubItem2.Name = "BarSubItem2"
        '
        'mnHelp
        '
        Me.mnHelp.Caption = "&Help"
        Me.mnHelp.Id = 9
        Me.mnHelp.ItemShortcut = New DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F1)
        Me.mnHelp.Name = "mnHelp"
        '
        'mnAbout
        '
        Me.mnAbout.Caption = "&About"
        Me.mnAbout.Id = 10
        Me.mnAbout.Name = "mnAbout"
        '
        'Bar3
        '
        Me.Bar3.BarName = "Status bar"
        Me.Bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom
        Me.Bar3.DockCol = 0
        Me.Bar3.DockRow = 0
        Me.Bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom
        Me.Bar3.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.mnStatusServer), New DevExpress.XtraBars.LinkPersistInfo(Me.mnStatusDatabase, True), New DevExpress.XtraBars.LinkPersistInfo(Me.mnStatusUser, True), New DevExpress.XtraBars.LinkPersistInfo(Me.mnStatusTanggal, True)})
        Me.Bar3.OptionsBar.AllowQuickCustomization = False
        Me.Bar3.OptionsBar.DrawDragBorder = False
        Me.Bar3.OptionsBar.UseWholeRow = True
        Me.Bar3.Text = "Status bar"
        '
        'mnStatusServer
        '
        Me.mnStatusServer.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.mnStatusServer.Caption = "Server : (None)"
        Me.mnStatusServer.Id = 0
        Me.mnStatusServer.Name = "mnStatusServer"
        Me.mnStatusServer.TextAlignment = System.Drawing.StringAlignment.Near
        '
        'mnStatusDatabase
        '
        Me.mnStatusDatabase.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.mnStatusDatabase.Caption = "DB : (None)"
        Me.mnStatusDatabase.Id = 1
        Me.mnStatusDatabase.Name = "mnStatusDatabase"
        Me.mnStatusDatabase.TextAlignment = System.Drawing.StringAlignment.Near
        '
        'mnStatusUser
        '
        Me.mnStatusUser.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.mnStatusUser.Caption = "User Aktif : (None)"
        Me.mnStatusUser.Id = 2
        Me.mnStatusUser.Name = "mnStatusUser"
        Me.mnStatusUser.TextAlignment = System.Drawing.StringAlignment.Near
        '
        'mnStatusTanggal
        '
        Me.mnStatusTanggal.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
        Me.mnStatusTanggal.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.mnStatusTanggal.Caption = "Tanggal Aktif : (None)"
        Me.mnStatusTanggal.Id = 3
        Me.mnStatusTanggal.Name = "mnStatusTanggal"
        Me.mnStatusTanggal.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.barDockControlTop.Size = New System.Drawing.Size(741, 51)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 225)
        Me.barDockControlBottom.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.barDockControlBottom.Size = New System.Drawing.Size(741, 25)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 51)
        Me.barDockControlLeft.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 174)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(741, 51)
        Me.barDockControlRight.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 174)
        '
        'ImageCollectionSmall
        '
        Me.ImageCollectionSmall.ImageStream = CType(resources.GetObject("ImageCollectionSmall.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.ImageCollectionSmall.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageCollectionSmall.Images.SetKeyName(0, "01-MASTER.png")
        Me.ImageCollectionSmall.Images.SetKeyName(1, "02-PEMBELIAN.png")
        Me.ImageCollectionSmall.Images.SetKeyName(2, "03-PENJUALAN.png")
        Me.ImageCollectionSmall.Images.SetKeyName(3, "04-LAPORAN.png")
        '
        'mnSetting
        '
        Me.mnSetting.Caption = "Setting Perusahaan dan User Menu"
        Me.mnSetting.Id = 21
        Me.mnSetting.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.None, False, Me.mnSettingPerusahaan, False)})
        Me.mnSetting.Name = "mnSetting"
        '
        'mnSettingPerusahaan
        '
        Me.mnSettingPerusahaan.Caption = "Setting Perusahaan"
        Me.mnSettingPerusahaan.Id = 22
        Me.mnSettingPerusahaan.Name = "mnSettingPerusahaan"
        '
        'ImageCollectionLarge
        '
        Me.ImageCollectionLarge.ImageSize = New System.Drawing.Size(24, 24)
        Me.ImageCollectionLarge.ImageStream = CType(resources.GetObject("ImageCollectionLarge.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.ImageCollectionLarge.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageCollectionLarge.Images.SetKeyName(0, "01-MASTER.png")
        Me.ImageCollectionLarge.Images.SetKeyName(1, "02-PEMBELIAN.png")
        Me.ImageCollectionLarge.Images.SetKeyName(2, "03-PENJUALAN.png")
        Me.ImageCollectionLarge.Images.SetKeyName(3, "04-INTERNAL.png")
        Me.ImageCollectionLarge.Images.SetKeyName(4, "05-SETTING AWAL.png")
        Me.ImageCollectionLarge.Images.SetKeyName(5, "06-LAPORAN.png")
        '
        'XtraTabbedMdiManager1
        '
        Me.XtraTabbedMdiManager1.MdiParent = Me
        '
        'Timer1
        '
        '
        'frmUtama
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(741, 250)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.IsMdiContainer = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmUtama"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "mPOS - CV. LANGGENG JAYA"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollectionSmall, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollectionLarge, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabbedMdiManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
    Friend WithEvents Bar3 As DevExpress.XtraBars.Bar
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents mnStatusServer As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents mnStatusDatabase As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents mnStatusUser As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents mnStatusTanggal As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents XtraTabbedMdiManager1 As DevExpress.XtraTabbedMdi.XtraTabbedMdiManager
    Friend WithEvents BarSubItem1 As DevExpress.XtraBars.BarSubItem
    Friend WithEvents mnLogin As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mnExit As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Public WithEvents ImageCollectionSmall As DevExpress.Utils.ImageCollection
    Public WithEvents ImageCollectionLarge As DevExpress.Utils.ImageCollection
    Friend WithEvents BarSubItem3 As DevExpress.XtraBars.BarSubItem
    Friend WithEvents BarCKTabModel As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents mniCascade As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mniTileVertical As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mniTileHorizontal As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarMdiChildrenListItem As DevExpress.XtraBars.BarMdiChildrenListItem
    Friend WithEvents BarSubItem2 As DevExpress.XtraBars.BarSubItem
    Friend WithEvents mnHelp As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mnAbout As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarSubItem4 As DevExpress.XtraBars.BarSubItem
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ckEditReport As DevExpress.XtraBars.BarCheckItem
    Friend WithEvents mnSkins As DevExpress.XtraBars.BarSubItem
    Friend WithEvents DefaultLookAndFeel1 As DevExpress.LookAndFeel.DefaultLookAndFeel
    Friend WithEvents mnSetting As DevExpress.XtraBars.BarSubItem
    Friend WithEvents mnSettingPerusahaan As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents mnUserAksesMenu As DevExpress.XtraBars.BarButtonItem
End Class
