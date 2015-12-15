<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEntriGudang
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
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl
        Me.txtPenanggungJawab = New DevExpress.XtraEditors.TextEdit
        Me.ckAktif = New DevExpress.XtraEditors.CheckEdit
        Me.cmdClose = New DevExpress.XtraEditors.SimpleButton
        Me.cmdSave = New DevExpress.XtraEditors.SimpleButton
        Me.txtNamaUser = New DevExpress.XtraEditors.TextEdit
        Me.txtKodeUser = New DevExpress.XtraEditors.TextEdit
        Me.txtAlamat = New DevExpress.XtraEditors.MemoEdit
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.txtPenanggungJawab.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ckAktif.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNamaUser.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtKodeUser.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAlamat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.txtPenanggungJawab)
        Me.LayoutControl1.Controls.Add(Me.ckAktif)
        Me.LayoutControl1.Controls.Add(Me.cmdClose)
        Me.LayoutControl1.Controls.Add(Me.cmdSave)
        Me.LayoutControl1.Controls.Add(Me.txtNamaUser)
        Me.LayoutControl1.Controls.Add(Me.txtKodeUser)
        Me.LayoutControl1.Controls.Add(Me.txtAlamat)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(510, 110, 250, 350)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(350, 214)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'txtPenanggungJawab
        '
        Me.txtPenanggungJawab.EnterMoveNextControl = True
        Me.txtPenanggungJawab.Location = New System.Drawing.Point(110, 126)
        Me.txtPenanggungJawab.Name = "txtPenanggungJawab"
        Me.txtPenanggungJawab.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPenanggungJawab.Properties.Appearance.Options.UseFont = True
        Me.txtPenanggungJawab.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPenanggungJawab.Size = New System.Drawing.Size(228, 22)
        Me.txtPenanggungJawab.StyleController = Me.LayoutControl1
        Me.txtPenanggungJawab.TabIndex = 6
        '
        'ckAktif
        '
        Me.ckAktif.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ckAktif.Location = New System.Drawing.Point(12, 152)
        Me.ckAktif.Name = "ckAktif"
        Me.ckAktif.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckAktif.Properties.Appearance.Options.UseFont = True
        Me.ckAktif.Properties.Caption = "Aktif"
        Me.ckAktif.Size = New System.Drawing.Size(326, 22)
        Me.ckAktif.StyleController = Me.LayoutControl1
        Me.ckAktif.TabIndex = 10
        '
        'cmdClose
        '
        Me.cmdClose.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.Appearance.Options.UseFont = True
        Me.cmdClose.Location = New System.Drawing.Point(177, 178)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(161, 24)
        Me.cmdClose.StyleController = Me.LayoutControl1
        Me.cmdClose.TabIndex = 2
        Me.cmdClose.Text = "&Close"
        '
        'cmdSave
        '
        Me.cmdSave.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSave.Appearance.Options.UseFont = True
        Me.cmdSave.Location = New System.Drawing.Point(12, 178)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(161, 24)
        Me.cmdSave.StyleController = Me.LayoutControl1
        Me.cmdSave.TabIndex = 1
        Me.cmdSave.Text = "&Save"
        '
        'txtNamaUser
        '
        Me.txtNamaUser.EnterMoveNextControl = True
        Me.txtNamaUser.Location = New System.Drawing.Point(110, 38)
        Me.txtNamaUser.Name = "txtNamaUser"
        Me.txtNamaUser.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNamaUser.Properties.Appearance.Options.UseFont = True
        Me.txtNamaUser.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNamaUser.Size = New System.Drawing.Size(228, 22)
        Me.txtNamaUser.StyleController = Me.LayoutControl1
        Me.txtNamaUser.TabIndex = 5
        '
        'txtKodeUser
        '
        Me.txtKodeUser.EnterMoveNextControl = True
        Me.txtKodeUser.Location = New System.Drawing.Point(110, 12)
        Me.txtKodeUser.Name = "txtKodeUser"
        Me.txtKodeUser.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKodeUser.Properties.Appearance.Options.UseFont = True
        Me.txtKodeUser.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtKodeUser.Size = New System.Drawing.Size(228, 22)
        Me.txtKodeUser.StyleController = Me.LayoutControl1
        Me.txtKodeUser.TabIndex = 4
        '
        'txtAlamat
        '
        Me.txtAlamat.Location = New System.Drawing.Point(110, 64)
        Me.txtAlamat.Name = "txtAlamat"
        Me.txtAlamat.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAlamat.Properties.Appearance.Options.UseFont = True
        Me.txtAlamat.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAlamat.Size = New System.Drawing.Size(228, 58)
        Me.txtAlamat.StyleController = Me.LayoutControl1
        Me.txtAlamat.TabIndex = 6
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "Root"
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem6, Me.LayoutControlItem7, Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem8, Me.LayoutControlItem3, Me.LayoutControlItem4})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(350, 214)
        Me.LayoutControlGroup1.Text = "Root"
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.cmdSave
        Me.LayoutControlItem6.CustomizationFormText = "LayoutControlItem6"
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 166)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(165, 28)
        Me.LayoutControlItem6.Text = "LayoutControlItem6"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextToControlDistance = 0
        Me.LayoutControlItem6.TextVisible = False
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.cmdClose
        Me.LayoutControlItem7.CustomizationFormText = "LayoutControlItem7"
        Me.LayoutControlItem7.Location = New System.Drawing.Point(165, 166)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(165, 28)
        Me.LayoutControlItem7.Text = "LayoutControlItem7"
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextToControlDistance = 0
        Me.LayoutControlItem7.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.txtKodeUser
        Me.LayoutControlItem1.CustomizationFormText = "Kode User"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(330, 26)
        Me.LayoutControlItem1.Text = "Kode"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(94, 13)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.txtNamaUser
        Me.LayoutControlItem2.CustomizationFormText = "Nama User"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 26)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(330, 26)
        Me.LayoutControlItem2.Text = "Nama"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(94, 13)
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.ckAktif
        Me.LayoutControlItem8.CustomizationFormText = "LayoutControlItem8"
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 140)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(330, 26)
        Me.LayoutControlItem8.Text = "LayoutControlItem8"
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem8.TextToControlDistance = 0
        Me.LayoutControlItem8.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.txtAlamat
        Me.LayoutControlItem3.CustomizationFormText = "Alamat"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 52)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(330, 62)
        Me.LayoutControlItem3.Text = "Alamat"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(94, 13)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.txtPenanggungJawab
        Me.LayoutControlItem4.CustomizationFormText = "Penanggung Jawab"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 114)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(330, 26)
        Me.LayoutControlItem4.Text = "Penanggung Jawab"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(94, 13)
        '
        'frmEntriGudang
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(350, 214)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmEntriGudang"
        Me.Text = "Entri Gudang"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.txtPenanggungJawab.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ckAktif.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNamaUser.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtKodeUser.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAlamat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents txtNamaUser As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtKodeUser As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cmdClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ckAktif As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtPenanggungJawab As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtAlamat As DevExpress.XtraEditors.MemoEdit
End Class
