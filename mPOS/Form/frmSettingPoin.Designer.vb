<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSettingPoin
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
        Me.txtMinimumBelanja = New DevExpress.XtraEditors.TextEdit
        Me.cmdClose = New DevExpress.XtraEditors.SimpleButton
        Me.cmdSave = New DevExpress.XtraEditors.SimpleButton
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem
        Me.txtSyaratBelanja = New DevExpress.XtraEditors.TextEdit
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem
        Me.ckKelipatan = New DevExpress.XtraEditors.CheckEdit
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem
        Me.txtNilaiPoin = New DevExpress.XtraEditors.TextEdit
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem
        Me.ckCustomer = New DevExpress.XtraEditors.CheckEdit
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.txtMinimumBelanja.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSyaratBelanja.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ckKelipatan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNilaiPoin.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ckCustomer.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.ckCustomer)
        Me.LayoutControl1.Controls.Add(Me.txtNilaiPoin)
        Me.LayoutControl1.Controls.Add(Me.ckKelipatan)
        Me.LayoutControl1.Controls.Add(Me.txtSyaratBelanja)
        Me.LayoutControl1.Controls.Add(Me.txtMinimumBelanja)
        Me.LayoutControl1.Controls.Add(Me.cmdClose)
        Me.LayoutControl1.Controls.Add(Me.cmdSave)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(510, 110, 250, 350)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(313, 242)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'txtMinimumBelanja
        '
        Me.txtMinimumBelanja.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtMinimumBelanja.EnterMoveNextControl = True
        Me.txtMinimumBelanja.Location = New System.Drawing.Point(118, 12)
        Me.txtMinimumBelanja.Name = "txtMinimumBelanja"
        Me.txtMinimumBelanja.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMinimumBelanja.Properties.Appearance.Options.UseFont = True
        Me.txtMinimumBelanja.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMinimumBelanja.Properties.Mask.EditMask = "n0"
        Me.txtMinimumBelanja.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtMinimumBelanja.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtMinimumBelanja.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtMinimumBelanja.Size = New System.Drawing.Size(183, 22)
        Me.txtMinimumBelanja.StyleController = Me.LayoutControl1
        Me.txtMinimumBelanja.TabIndex = 6
        '
        'cmdClose
        '
        Me.cmdClose.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.Appearance.Options.UseFont = True
        Me.cmdClose.Location = New System.Drawing.Point(158, 206)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(143, 24)
        Me.cmdClose.StyleController = Me.LayoutControl1
        Me.cmdClose.TabIndex = 2
        Me.cmdClose.Text = "&Close"
        '
        'cmdSave
        '
        Me.cmdSave.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSave.Appearance.Options.UseFont = True
        Me.cmdSave.Location = New System.Drawing.Point(12, 206)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(142, 24)
        Me.cmdSave.StyleController = Me.LayoutControl1
        Me.cmdSave.TabIndex = 1
        Me.cmdSave.Text = "&Save"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "Root"
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem6, Me.LayoutControlItem7, Me.EmptySpaceItem1, Me.LayoutControlItem3, Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem4, Me.LayoutControlItem5})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(313, 242)
        Me.LayoutControlGroup1.Text = "Root"
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.cmdSave
        Me.LayoutControlItem6.CustomizationFormText = "LayoutControlItem6"
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 194)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(146, 28)
        Me.LayoutControlItem6.Text = "LayoutControlItem6"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextToControlDistance = 0
        Me.LayoutControlItem6.TextVisible = False
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.cmdClose
        Me.LayoutControlItem7.CustomizationFormText = "LayoutControlItem7"
        Me.LayoutControlItem7.Location = New System.Drawing.Point(146, 194)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(147, 28)
        Me.LayoutControlItem7.Text = "LayoutControlItem7"
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextToControlDistance = 0
        Me.LayoutControlItem7.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.CustomizationFormText = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 130)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(293, 64)
        Me.EmptySpaceItem1.Text = "EmptySpaceItem1"
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.txtMinimumBelanja
        Me.LayoutControlItem3.CustomizationFormText = "Konversi"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(293, 26)
        Me.LayoutControlItem3.Text = "Mimimum Belanja"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(102, 13)
        '
        'txtSyaratBelanja
        '
        Me.txtSyaratBelanja.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtSyaratBelanja.EnterMoveNextControl = True
        Me.txtSyaratBelanja.Location = New System.Drawing.Point(118, 38)
        Me.txtSyaratBelanja.Name = "txtSyaratBelanja"
        Me.txtSyaratBelanja.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSyaratBelanja.Properties.Appearance.Options.UseFont = True
        Me.txtSyaratBelanja.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSyaratBelanja.Properties.Mask.EditMask = "n0"
        Me.txtSyaratBelanja.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtSyaratBelanja.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtSyaratBelanja.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtSyaratBelanja.Size = New System.Drawing.Size(183, 22)
        Me.txtSyaratBelanja.StyleController = Me.LayoutControl1
        Me.txtSyaratBelanja.TabIndex = 7
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.txtSyaratBelanja
        Me.LayoutControlItem1.CustomizationFormText = "Syarat Belanja 1 Poin"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 26)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(293, 26)
        Me.LayoutControlItem1.Text = "Syarat Belanja 1 Poin"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(102, 13)
        '
        'ckKelipatan
        '
        Me.ckKelipatan.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ckKelipatan.Location = New System.Drawing.Point(12, 90)
        Me.ckKelipatan.Name = "ckKelipatan"
        Me.ckKelipatan.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckKelipatan.Properties.Appearance.Options.UseFont = True
        Me.ckKelipatan.Properties.Caption = "Berlaku Kelipatan"
        Me.ckKelipatan.Size = New System.Drawing.Size(289, 22)
        Me.ckKelipatan.StyleController = Me.LayoutControl1
        Me.ckKelipatan.TabIndex = 11
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.ckKelipatan
        Me.LayoutControlItem2.CustomizationFormText = "LayoutControlItem2"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 78)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(293, 26)
        Me.LayoutControlItem2.Text = "LayoutControlItem2"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextToControlDistance = 0
        Me.LayoutControlItem2.TextVisible = False
        '
        'txtNilaiPoin
        '
        Me.txtNilaiPoin.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txtNilaiPoin.EnterMoveNextControl = True
        Me.txtNilaiPoin.Location = New System.Drawing.Point(118, 64)
        Me.txtNilaiPoin.Name = "txtNilaiPoin"
        Me.txtNilaiPoin.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNilaiPoin.Properties.Appearance.Options.UseFont = True
        Me.txtNilaiPoin.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNilaiPoin.Properties.Mask.EditMask = "n0"
        Me.txtNilaiPoin.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtNilaiPoin.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtNilaiPoin.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtNilaiPoin.Size = New System.Drawing.Size(183, 22)
        Me.txtNilaiPoin.StyleController = Me.LayoutControl1
        Me.txtNilaiPoin.TabIndex = 8
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.txtNilaiPoin
        Me.LayoutControlItem4.CustomizationFormText = "Nilai Poin"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 52)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(293, 26)
        Me.LayoutControlItem4.Text = "Nilai Poin"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(102, 13)
        '
        'ckCustomer
        '
        Me.ckCustomer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ckCustomer.Location = New System.Drawing.Point(12, 116)
        Me.ckCustomer.Name = "ckCustomer"
        Me.ckCustomer.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckCustomer.Properties.Appearance.Options.UseFont = True
        Me.ckCustomer.Properties.Caption = "Hanya U/ Customer"
        Me.ckCustomer.Size = New System.Drawing.Size(289, 22)
        Me.ckCustomer.StyleController = Me.LayoutControl1
        Me.ckCustomer.TabIndex = 12
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.ckCustomer
        Me.LayoutControlItem5.CustomizationFormText = "LayoutControlItem5"
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 104)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(293, 26)
        Me.LayoutControlItem5.Text = "LayoutControlItem5"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextToControlDistance = 0
        Me.LayoutControlItem5.TextVisible = False
        '
        'frmSettingPoin
        '
        Me.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(313, 242)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmSettingPoin"
        Me.Text = "Setting Poin"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.txtMinimumBelanja.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSyaratBelanja.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ckKelipatan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNilaiPoin.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ckCustomer.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents cmdClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtMinimumBelanja As DevExpress.XtraEditors.TextEdit
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtSyaratBelanja As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ckKelipatan As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ckCustomer As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents txtNilaiPoin As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
End Class
