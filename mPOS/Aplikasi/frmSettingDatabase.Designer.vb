<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSettingDatabase
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
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSettingDatabase))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl
        Me.cmdCancel = New DevExpress.XtraEditors.SimpleButton
        Me.txtTimeOut = New DevExpress.XtraEditors.TextEdit
        Me.cmdOK = New DevExpress.XtraEditors.SimpleButton
        Me.txtPwd = New DevExpress.XtraEditors.TextEdit
        Me.txtUserID = New DevExpress.XtraEditors.TextEdit
        Me.txtServer = New DevExpress.XtraEditors.TextEdit
        Me.txtDatabase = New DevExpress.XtraEditors.ComboBoxEdit
        Me.txtODBC = New DevExpress.XtraEditors.ButtonEdit
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem
        Me.ImageCollection = New DevExpress.Utils.ImageCollection(Me.components)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.txtTimeOut.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPwd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUserID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtServer.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDatabase.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtODBC.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.cmdCancel)
        Me.LayoutControl1.Controls.Add(Me.txtTimeOut)
        Me.LayoutControl1.Controls.Add(Me.cmdOK)
        Me.LayoutControl1.Controls.Add(Me.txtPwd)
        Me.LayoutControl1.Controls.Add(Me.txtUserID)
        Me.LayoutControl1.Controls.Add(Me.txtServer)
        Me.LayoutControl1.Controls.Add(Me.txtDatabase)
        Me.LayoutControl1.Controls.Add(Me.txtODBC)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(738, 139, 250, 350)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(384, 295)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'cmdCancel
        '
        Me.cmdCancel.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.Appearance.ForeColor = System.Drawing.Color.DarkBlue
        Me.cmdCancel.Appearance.Options.UseFont = True
        Me.cmdCancel.Appearance.Options.UseForeColor = True
        Me.cmdCancel.ImageIndex = 2
        Me.cmdCancel.Location = New System.Drawing.Point(194, 247)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(166, 24)
        Me.cmdCancel.StyleController = Me.LayoutControl1
        Me.cmdCancel.TabIndex = 11
        Me.cmdCancel.Text = "CANCEL"
        '
        'txtTimeOut
        '
        Me.txtTimeOut.EditValue = CType(15, Short)
        Me.txtTimeOut.EnterMoveNextControl = True
        Me.txtTimeOut.Location = New System.Drawing.Point(106, 132)
        Me.txtTimeOut.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.txtTimeOut.Name = "txtTimeOut"
        Me.txtTimeOut.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTimeOut.Properties.Appearance.Options.UseFont = True
        Me.txtTimeOut.Properties.DisplayFormat.FormatString = "n0"
        Me.txtTimeOut.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtTimeOut.Properties.EditFormat.FormatString = "n0"
        Me.txtTimeOut.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtTimeOut.Properties.Mask.EditMask = "n0"
        Me.txtTimeOut.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtTimeOut.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtTimeOut.Size = New System.Drawing.Size(254, 24)
        Me.txtTimeOut.StyleController = Me.LayoutControl1
        Me.txtTimeOut.TabIndex = 6
        '
        'cmdOK
        '
        Me.cmdOK.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOK.Appearance.ForeColor = System.Drawing.Color.DarkBlue
        Me.cmdOK.Appearance.Options.UseFont = True
        Me.cmdOK.Appearance.Options.UseForeColor = True
        Me.cmdOK.ImageIndex = 1
        Me.cmdOK.Location = New System.Drawing.Point(24, 247)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(166, 24)
        Me.cmdOK.StyleController = Me.LayoutControl1
        Me.cmdOK.TabIndex = 10
        Me.cmdOK.Text = "OK"
        '
        'txtPwd
        '
        Me.txtPwd.EnterMoveNextControl = True
        Me.txtPwd.Location = New System.Drawing.Point(106, 104)
        Me.txtPwd.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.txtPwd.Name = "txtPwd"
        Me.txtPwd.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPwd.Properties.Appearance.Options.UseFont = True
        Me.txtPwd.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPwd.Size = New System.Drawing.Size(254, 24)
        Me.txtPwd.StyleController = Me.LayoutControl1
        Me.txtPwd.TabIndex = 5
        '
        'txtUserID
        '
        Me.txtUserID.EnterMoveNextControl = True
        Me.txtUserID.Location = New System.Drawing.Point(106, 76)
        Me.txtUserID.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.txtUserID.Name = "txtUserID"
        Me.txtUserID.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUserID.Properties.Appearance.Options.UseFont = True
        Me.txtUserID.Size = New System.Drawing.Size(254, 24)
        Me.txtUserID.StyleController = Me.LayoutControl1
        Me.txtUserID.TabIndex = 5
        '
        'txtServer
        '
        Me.txtServer.EnterMoveNextControl = True
        Me.txtServer.Location = New System.Drawing.Point(106, 48)
        Me.txtServer.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtServer.Properties.Appearance.Options.UseFont = True
        Me.txtServer.Size = New System.Drawing.Size(254, 24)
        Me.txtServer.StyleController = Me.LayoutControl1
        Me.txtServer.TabIndex = 5
        '
        'txtDatabase
        '
        Me.txtDatabase.EnterMoveNextControl = True
        Me.txtDatabase.Location = New System.Drawing.Point(106, 160)
        Me.txtDatabase.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.txtDatabase.Name = "txtDatabase"
        Me.txtDatabase.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDatabase.Properties.Appearance.Options.UseFont = True
        Me.txtDatabase.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.OK, "", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "Cek Koneksi Tersambung", Nothing, Nothing, True)})
        Me.txtDatabase.Size = New System.Drawing.Size(254, 24)
        Me.txtDatabase.StyleController = Me.LayoutControl1
        Me.txtDatabase.TabIndex = 6
        '
        'txtODBC
        '
        Me.txtODBC.EnterMoveNextControl = True
        Me.txtODBC.Location = New System.Drawing.Point(106, 188)
        Me.txtODBC.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.txtODBC.Name = "txtODBC"
        Me.txtODBC.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtODBC.Properties.Appearance.Options.UseFont = True
        Me.txtODBC.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject2, "Tampilkan ODBC Administrator", Nothing, Nothing, True), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.OK, "", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject3, "Cek Koneksi ODBC Tersambung", Nothing, Nothing, True)})
        Me.txtODBC.Size = New System.Drawing.Size(254, 24)
        Me.txtODBC.StyleController = Me.LayoutControl1
        Me.txtODBC.TabIndex = 6
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.AppearanceGroup.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlGroup1.AppearanceGroup.Options.UseFont = True
        Me.LayoutControlGroup1.AppearanceItemCaption.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LayoutControlGroup1.AppearanceItemCaption.Options.UseFont = True
        Me.LayoutControlGroup1.CustomizationFormText = "Root"
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup2})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(384, 295)
        Me.LayoutControlGroup1.Text = "Root"
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.CustomizationFormText = "Setting Data SQL Server"
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem5, Me.LayoutControlItem6, Me.LayoutControlItem7, Me.EmptySpaceItem1, Me.LayoutControlItem8})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(364, 275)
        Me.LayoutControlGroup2.Text = "Setting Data SQL Server"
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.txtServer
        Me.LayoutControlItem1.CustomizationFormText = "Server"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(340, 28)
        Me.LayoutControlItem1.Text = "Server"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(78, 17)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.txtUserID
        Me.LayoutControlItem2.CustomizationFormText = "User ID"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 28)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(340, 28)
        Me.LayoutControlItem2.Text = "User ID"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(78, 17)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.txtPwd
        Me.LayoutControlItem3.CustomizationFormText = "Password"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 56)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(340, 28)
        Me.LayoutControlItem3.Text = "Password"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(78, 17)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.txtTimeOut
        Me.LayoutControlItem4.CustomizationFormText = "Time Out"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 84)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(340, 28)
        Me.LayoutControlItem4.Text = "Time Out"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(78, 17)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.txtDatabase
        Me.LayoutControlItem5.CustomizationFormText = "Database"
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 112)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(340, 28)
        Me.LayoutControlItem5.Text = "Database"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(78, 17)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.cmdOK
        Me.LayoutControlItem6.CustomizationFormText = "LayoutControlItem6"
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 199)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(170, 28)
        Me.LayoutControlItem6.Text = "LayoutControlItem6"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextToControlDistance = 0
        Me.LayoutControlItem6.TextVisible = False
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.cmdCancel
        Me.LayoutControlItem7.CustomizationFormText = "LayoutControlItem7"
        Me.LayoutControlItem7.Location = New System.Drawing.Point(170, 199)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(170, 28)
        Me.LayoutControlItem7.Text = "LayoutControlItem7"
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextToControlDistance = 0
        Me.LayoutControlItem7.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.CustomizationFormText = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 168)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(340, 31)
        Me.EmptySpaceItem1.Text = "EmptySpaceItem1"
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.txtODBC
        Me.LayoutControlItem8.CustomizationFormText = "ODBC Report"
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 140)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(340, 28)
        Me.LayoutControlItem8.Text = "ODBC Report"
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(78, 17)
        '
        'ImageCollection
        '
        Me.ImageCollection.ImageStream = CType(resources.GetObject("ImageCollection.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.ImageCollection.Images.SetKeyName(0, "data_gear.png")
        Me.ImageCollection.Images.SetKeyName(1, "floppy_disk_ok.png")
        Me.ImageCollection.Images.SetKeyName(2, "door2_open.png")
        '
        'frmSettingDatabase
        '
        Me.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(384, 295)
        Me.Controls.Add(Me.LayoutControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSettingDatabase"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Setting Koneksi"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.txtTimeOut.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPwd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUserID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtServer.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDatabase.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtODBC.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollection, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents txtPwd As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtUserID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtServer As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents txtTimeOut As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtDatabase As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents cmdCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdOK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents txtODBC As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ImageCollection As DevExpress.Utils.ImageCollection
End Class
