﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLaporanAgingPiutang
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
        Me.cmdCetakFaktur = New DevExpress.XtraEditors.SimpleButton
        Me.cmdPreview = New DevExpress.XtraEditors.SimpleButton
        Me.cmdClose = New DevExpress.XtraEditors.SimpleButton
        Me.cmdRefresh = New DevExpress.XtraEditors.SimpleButton
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl
        Me.txtJenis = New DevExpress.XtraEditors.SearchLookUpEdit
        Me.SearchLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.DateEdit2 = New DevExpress.XtraEditors.DateEdit
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl
        Me.DateEdit1 = New DevExpress.XtraEditors.DateEdit
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl
        Me.cmdHapus = New DevExpress.XtraEditors.SimpleButton
        Me.cmdEdit = New DevExpress.XtraEditors.SimpleButton
        Me.cmdBaru = New DevExpress.XtraEditors.SimpleButton
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem
        Me.TabbedControlGroup1 = New DevExpress.XtraLayout.TabbedControlGroup
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.txtJenis.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit2.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit1.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabbedControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.cmdCetakFaktur)
        Me.LayoutControl1.Controls.Add(Me.cmdPreview)
        Me.LayoutControl1.Controls.Add(Me.cmdClose)
        Me.LayoutControl1.Controls.Add(Me.cmdRefresh)
        Me.LayoutControl1.Controls.Add(Me.GridControl1)
        Me.LayoutControl1.Controls.Add(Me.PanelControl2)
        Me.LayoutControl1.Controls.Add(Me.cmdHapus)
        Me.LayoutControl1.Controls.Add(Me.cmdEdit)
        Me.LayoutControl1.Controls.Add(Me.cmdBaru)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem9, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem5})
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(657, 292, 250, 350)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(709, 351)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'cmdCetakFaktur
        '
        Me.cmdCetakFaktur.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCetakFaktur.Appearance.Options.UseFont = True
        Me.cmdCetakFaktur.Location = New System.Drawing.Point(612, 296)
        Me.cmdCetakFaktur.Name = "cmdCetakFaktur"
        Me.cmdCetakFaktur.Size = New System.Drawing.Size(146, 24)
        Me.cmdCetakFaktur.StyleController = Me.LayoutControl1
        Me.cmdCetakFaktur.TabIndex = 2
        Me.cmdCetakFaktur.Text = "Print &Faktur"
        '
        'cmdPreview
        '
        Me.cmdPreview.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPreview.Appearance.Options.UseFont = True
        Me.cmdPreview.Location = New System.Drawing.Point(12, 315)
        Me.cmdPreview.Name = "cmdPreview"
        Me.cmdPreview.Size = New System.Drawing.Size(146, 24)
        Me.cmdPreview.StyleController = Me.LayoutControl1
        Me.cmdPreview.TabIndex = 2
        Me.cmdPreview.Text = "&Preview"
        '
        'cmdClose
        '
        Me.cmdClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClose.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.Appearance.Options.UseFont = True
        Me.cmdClose.Location = New System.Drawing.Point(551, 315)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(146, 24)
        Me.cmdClose.StyleController = Me.LayoutControl1
        Me.cmdClose.TabIndex = 4
        Me.cmdClose.Text = "&Close"
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRefresh.Appearance.Options.UseFont = True
        Me.cmdRefresh.Location = New System.Drawing.Point(401, 315)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(146, 24)
        Me.cmdRefresh.StyleController = Me.LayoutControl1
        Me.cmdRefresh.TabIndex = 3
        Me.cmdRefresh.Text = "&Refresh"
        '
        'GridControl1
        '
        Me.GridControl1.Location = New System.Drawing.Point(24, 116)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(661, 183)
        Me.GridControl1.TabIndex = 1
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsSelection.MultiSelect = True
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowFooter = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.LabelControl4)
        Me.PanelControl2.Controls.Add(Me.txtJenis)
        Me.PanelControl2.Controls.Add(Me.DateEdit2)
        Me.PanelControl2.Controls.Add(Me.LabelControl3)
        Me.PanelControl2.Controls.Add(Me.LabelControl2)
        Me.PanelControl2.Controls.Add(Me.DateEdit1)
        Me.PanelControl2.Controls.Add(Me.LabelControl1)
        Me.PanelControl2.Location = New System.Drawing.Point(12, 12)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(685, 68)
        Me.PanelControl2.TabIndex = 0
        '
        'LabelControl4
        '
        Me.LabelControl4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl4.Location = New System.Drawing.Point(481, 40)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(28, 16)
        Me.LabelControl4.TabIndex = 5
        Me.LabelControl4.Text = "Jenis"
        '
        'txtJenis
        '
        Me.txtJenis.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtJenis.EditValue = ""
        Me.txtJenis.EnterMoveNextControl = True
        Me.txtJenis.Location = New System.Drawing.Point(515, 37)
        Me.txtJenis.Name = "txtJenis"
        Me.txtJenis.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtJenis.Properties.Appearance.Options.UseFont = True
        Me.txtJenis.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtJenis.Properties.DisplayMember = "Nama"
        Me.txtJenis.Properties.NullText = ""
        Me.txtJenis.Properties.ValueMember = "NoID"
        Me.txtJenis.Properties.View = Me.SearchLookUpEdit1View
        Me.txtJenis.Size = New System.Drawing.Size(165, 22)
        Me.txtJenis.StyleController = Me.LayoutControl1
        Me.txtJenis.TabIndex = 6
        '
        'SearchLookUpEdit1View
        '
        Me.SearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.SearchLookUpEdit1View.Name = "SearchLookUpEdit1View"
        Me.SearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.SearchLookUpEdit1View.OptionsView.ShowGroupPanel = False
        '
        'DateEdit2
        '
        Me.DateEdit2.EditValue = New Date(2014, 6, 15, 16, 11, 38, 516)
        Me.DateEdit2.EnterMoveNextControl = True
        Me.DateEdit2.Location = New System.Drawing.Point(193, 40)
        Me.DateEdit2.Name = "DateEdit2"
        Me.DateEdit2.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateEdit2.Properties.Appearance.Options.UseFont = True
        Me.DateEdit2.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit2.Properties.DisplayFormat.FormatString = "dd-MM-yyyy"
        Me.DateEdit2.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit2.Properties.EditFormat.FormatString = "dd-MM-yyyy"
        Me.DateEdit2.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit2.Properties.Mask.EditMask = "dd-MM-yyyy"
        Me.DateEdit2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        Me.DateEdit2.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.DateEdit2.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.DateEdit2.Size = New System.Drawing.Size(100, 22)
        Me.DateEdit2.TabIndex = 4
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl3.Location = New System.Drawing.Point(169, 43)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(18, 16)
        Me.LabelControl3.TabIndex = 3
        Me.LabelControl3.Text = "s/d"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(11, 43)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(46, 16)
        Me.LabelControl2.TabIndex = 1
        Me.LabelControl2.Text = "Tanggal"
        '
        'DateEdit1
        '
        Me.DateEdit1.EditValue = New Date(2014, 6, 15, 16, 11, 38, 516)
        Me.DateEdit1.EnterMoveNextControl = True
        Me.DateEdit1.Location = New System.Drawing.Point(63, 40)
        Me.DateEdit1.Name = "DateEdit1"
        Me.DateEdit1.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateEdit1.Properties.Appearance.Options.UseFont = True
        Me.DateEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit1.Properties.DisplayFormat.FormatString = "dd-MM-yyyy"
        Me.DateEdit1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit1.Properties.EditFormat.FormatString = "dd-MM-yyyy"
        Me.DateEdit1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DateEdit1.Properties.Mask.EditMask = "dd-MM-yyyy"
        Me.DateEdit1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        Me.DateEdit1.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.DateEdit1.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.DateEdit1.Size = New System.Drawing.Size(100, 22)
        Me.DateEdit1.TabIndex = 2
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelControl1.Location = New System.Drawing.Point(5, 5)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(313, 32)
        Me.LabelControl1.StyleController = Me.LayoutControl1
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "LAPORAN AGING PIUTANG"
        '
        'cmdHapus
        '
        Me.cmdHapus.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdHapus.Appearance.Options.UseFont = True
        Me.cmdHapus.Location = New System.Drawing.Point(12, 296)
        Me.cmdHapus.Name = "cmdHapus"
        Me.cmdHapus.Size = New System.Drawing.Size(146, 24)
        Me.cmdHapus.StyleController = Me.LayoutControl1
        Me.cmdHapus.TabIndex = 2
        Me.cmdHapus.Text = "&Delete"
        '
        'cmdEdit
        '
        Me.cmdEdit.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEdit.Appearance.Options.UseFont = True
        Me.cmdEdit.Location = New System.Drawing.Point(12, 296)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(146, 24)
        Me.cmdEdit.StyleController = Me.LayoutControl1
        Me.cmdEdit.TabIndex = 1
        Me.cmdEdit.Text = "&Edit"
        '
        'cmdBaru
        '
        Me.cmdBaru.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBaru.Appearance.Options.UseFont = True
        Me.cmdBaru.Location = New System.Drawing.Point(12, 296)
        Me.cmdBaru.Name = "cmdBaru"
        Me.cmdBaru.Size = New System.Drawing.Size(146, 24)
        Me.cmdBaru.StyleController = Me.LayoutControl1
        Me.cmdBaru.TabIndex = 0
        Me.cmdBaru.Text = "&New"
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.cmdCetakFaktur
        Me.LayoutControlItem9.CustomizationFormText = "LayoutControlItem9"
        Me.LayoutControlItem9.Location = New System.Drawing.Point(600, 284)
        Me.LayoutControlItem9.MaxSize = New System.Drawing.Size(150, 28)
        Me.LayoutControlItem9.MinSize = New System.Drawing.Size(150, 28)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(150, 28)
        Me.LayoutControlItem9.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem9.Text = "LayoutControlItem9"
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem9.TextToControlDistance = 0
        Me.LayoutControlItem9.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.cmdBaru
        Me.LayoutControlItem3.CustomizationFormText = "LayoutControlItem3"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 284)
        Me.LayoutControlItem3.MaxSize = New System.Drawing.Size(150, 28)
        Me.LayoutControlItem3.MinSize = New System.Drawing.Size(150, 28)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(150, 28)
        Me.LayoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem3.Text = "LayoutControlItem3"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextToControlDistance = 0
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.cmdEdit
        Me.LayoutControlItem4.CustomizationFormText = "LayoutControlItem4"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 284)
        Me.LayoutControlItem4.MaxSize = New System.Drawing.Size(150, 28)
        Me.LayoutControlItem4.MinSize = New System.Drawing.Size(150, 28)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(150, 28)
        Me.LayoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem4.Text = "LayoutControlItem4"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextToControlDistance = 0
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.cmdHapus
        Me.LayoutControlItem5.CustomizationFormText = "LayoutControlItem5"
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 284)
        Me.LayoutControlItem5.MaxSize = New System.Drawing.Size(150, 28)
        Me.LayoutControlItem5.MinSize = New System.Drawing.Size(150, 28)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(150, 28)
        Me.LayoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem5.Text = "LayoutControlItem5"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextToControlDistance = 0
        Me.LayoutControlItem5.TextVisible = False
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "Root"
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem7, Me.LayoutControlItem8, Me.EmptySpaceItem1, Me.LayoutControlItem6, Me.TabbedControlGroup1})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(709, 351)
        Me.LayoutControlGroup1.Text = "Root"
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.PanelControl2
        Me.LayoutControlItem1.CustomizationFormText = "ATas"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.MaxSize = New System.Drawing.Size(0, 72)
        Me.LayoutControlItem1.MinSize = New System.Drawing.Size(104, 72)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(689, 72)
        Me.LayoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem1.Text = "Atas"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextToControlDistance = 0
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.cmdRefresh
        Me.LayoutControlItem7.CustomizationFormText = "LayoutControlItem7"
        Me.LayoutControlItem7.Location = New System.Drawing.Point(389, 303)
        Me.LayoutControlItem7.MaxSize = New System.Drawing.Size(150, 28)
        Me.LayoutControlItem7.MinSize = New System.Drawing.Size(150, 28)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(150, 28)
        Me.LayoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem7.Text = "LayoutControlItem7"
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextToControlDistance = 0
        Me.LayoutControlItem7.TextVisible = False
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.cmdClose
        Me.LayoutControlItem8.CustomizationFormText = "LayoutControlItem8"
        Me.LayoutControlItem8.Location = New System.Drawing.Point(539, 303)
        Me.LayoutControlItem8.MaxSize = New System.Drawing.Size(150, 28)
        Me.LayoutControlItem8.MinSize = New System.Drawing.Size(150, 28)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(150, 28)
        Me.LayoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem8.Text = "LayoutControlItem8"
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem8.TextToControlDistance = 0
        Me.LayoutControlItem8.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.CustomizationFormText = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(150, 303)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(239, 28)
        Me.EmptySpaceItem1.Text = "EmptySpaceItem1"
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.cmdPreview
        Me.LayoutControlItem6.CustomizationFormText = "LayoutControlItem6"
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 303)
        Me.LayoutControlItem6.MaxSize = New System.Drawing.Size(150, 28)
        Me.LayoutControlItem6.MinSize = New System.Drawing.Size(150, 28)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(150, 28)
        Me.LayoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem6.Text = "LayoutControlItem6"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextToControlDistance = 0
        Me.LayoutControlItem6.TextVisible = False
        '
        'TabbedControlGroup1
        '
        Me.TabbedControlGroup1.CustomizationFormText = "TabbedControlGroup1"
        Me.TabbedControlGroup1.Location = New System.Drawing.Point(0, 72)
        Me.TabbedControlGroup1.Name = "TabbedControlGroup1"
        Me.TabbedControlGroup1.SelectedTabPage = Me.LayoutControlGroup2
        Me.TabbedControlGroup1.SelectedTabPageIndex = 0
        Me.TabbedControlGroup1.Size = New System.Drawing.Size(689, 231)
        Me.TabbedControlGroup1.TabPages.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup2})
        Me.TabbedControlGroup1.Text = "TabbedControlGroup1"
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.CustomizationFormText = "Detil Per Barang"
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(665, 187)
        Me.LayoutControlGroup2.Text = "Detil Per Nota"
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.GridControl1
        Me.LayoutControlItem2.CustomizationFormText = "Grid"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(665, 187)
        Me.LayoutControlItem2.Text = "Grid"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextToControlDistance = 0
        Me.LayoutControlItem2.TextVisible = False
        '
        'frmLaporanAgingPiutang
        '
        Me.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(709, 351)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmLaporanAgingPiutang"
        Me.Text = "Laporan Aging Piutang"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.txtJenis.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SearchLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit2.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit1.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabbedControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents cmdClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdHapus As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdEdit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdBaru As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdRefresh As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents cmdPreview As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents DateEdit1 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DateEdit2 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmdCetakFaktur As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtJenis As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents SearchLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TabbedControlGroup1 As DevExpress.XtraLayout.TabbedControlGroup
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
End Class
