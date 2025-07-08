<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LabelingDepartmentDetail
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LabelingDepartmentDetail))
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gsrno = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GISSDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPARTYNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGODOWN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GHANDLINGINFO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GOTHERINFO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPACKEDBY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPROFORMANO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GJONO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GJOSRNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GJODATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GJOTYPE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSONO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSODATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSOTYPE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGRIDSRNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREMARK = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGRADE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GLOTNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GROLLNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGSM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGSMDETAILS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSIZE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GWT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ROLLOD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GROLLID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GFINALWT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDIFF = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GUNIT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GJOINT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNARRATION = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBARCODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALWASTAGE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TXTFROM = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TXTCOPIES = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TXTTO = New System.Windows.Forms.TextBox()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.TOOLREFRESH = New System.Windows.Forms.ToolStripButton()
        Me.TOOLWHATSAPP = New System.Windows.Forms.ToolStripButton()
        Me.TOOLMAIL = New System.Windows.Forms.ToolStripButton()
        Me.TOOLEXCEL = New System.Windows.Forms.ToolStripButton()
        Me.TOOLPRINT = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.PRINTDIALOG = New System.Windows.Forms.PrintDialog()
        Me.PRINTDOC = New System.Drawing.Printing.PrintDocument()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.TXTFROM)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.TXTCOPIES)
        Me.BlendPanel1.Controls.Add(Me.Label9)
        Me.BlendPanel1.Controls.Add(Me.Label10)
        Me.BlendPanel1.Controls.Add(Me.TXTTO)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1284, 581)
        Me.BlendPanel1.TabIndex = 5
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(11, 49)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(1260, 473)
        Me.gridbilldetails.TabIndex = 802
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.HeaderPanel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.HeaderPanel.Options.UseFont = True
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gsrno, Me.GISSDATE, Me.GPARTYNAME, Me.GGODOWN, Me.GHANDLINGINFO, Me.GOTHERINFO, Me.GPACKEDBY, Me.GPROFORMANO, Me.GJONO, Me.GJOSRNO, Me.GJODATE, Me.GJOTYPE, Me.GSONO, Me.GSODATE, Me.GSOTYPE, Me.GGRIDSRNO, Me.GREMARK, Me.GGRADE, Me.GLOTNO, Me.GROLLNO, Me.GGSM, Me.GGSMDETAILS, Me.GSIZE, Me.GWT, Me.ROLLOD, Me.GROLLID, Me.GFINALWT, Me.GDIFF, Me.GUNIT, Me.GJOINT, Me.GNARRATION, Me.GBARCODE, Me.GTOTALWASTAGE})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AutoExpandAllGroups = True
        Me.gridbill.OptionsBehavior.Editable = False
        Me.gridbill.OptionsSelection.CheckBoxSelectorColumnWidth = 30
        Me.gridbill.OptionsSelection.MultiSelect = True
        Me.gridbill.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        Me.gridbill.OptionsView.ShowGroupPanel = False
        '
        'gsrno
        '
        Me.gsrno.Caption = "Sr. No"
        Me.gsrno.FieldName = "TEMPLABNO"
        Me.gsrno.Name = "gsrno"
        Me.gsrno.OptionsColumn.AllowEdit = False
        Me.gsrno.Visible = True
        Me.gsrno.VisibleIndex = 1
        Me.gsrno.Width = 30
        '
        'GISSDATE
        '
        Me.GISSDATE.Caption = "Date"
        Me.GISSDATE.FieldName = "DATE"
        Me.GISSDATE.Name = "GISSDATE"
        Me.GISSDATE.OptionsColumn.AllowEdit = False
        Me.GISSDATE.Visible = True
        Me.GISSDATE.VisibleIndex = 2
        '
        'GPARTYNAME
        '
        Me.GPARTYNAME.Caption = "Party Name"
        Me.GPARTYNAME.FieldName = "PARTYNAME"
        Me.GPARTYNAME.Name = "GPARTYNAME"
        Me.GPARTYNAME.Visible = True
        Me.GPARTYNAME.VisibleIndex = 3
        Me.GPARTYNAME.Width = 200
        '
        'GGODOWN
        '
        Me.GGODOWN.Caption = "Godown"
        Me.GGODOWN.FieldName = "GODOWN"
        Me.GGODOWN.Name = "GGODOWN"
        Me.GGODOWN.OptionsColumn.AllowEdit = False
        Me.GGODOWN.Visible = True
        Me.GGODOWN.VisibleIndex = 4
        '
        'GHANDLINGINFO
        '
        Me.GHANDLINGINFO.Caption = "Handleing Info"
        Me.GHANDLINGINFO.FieldName = "HANDLINGINFO"
        Me.GHANDLINGINFO.Name = "GHANDLINGINFO"
        Me.GHANDLINGINFO.OptionsColumn.AllowEdit = False
        Me.GHANDLINGINFO.Visible = True
        Me.GHANDLINGINFO.VisibleIndex = 5
        Me.GHANDLINGINFO.Width = 100
        '
        'GOTHERINFO
        '
        Me.GOTHERINFO.Caption = "Other Info"
        Me.GOTHERINFO.FieldName = "OTHERINFO"
        Me.GOTHERINFO.Name = "GOTHERINFO"
        Me.GOTHERINFO.OptionsColumn.AllowEdit = False
        Me.GOTHERINFO.Visible = True
        Me.GOTHERINFO.VisibleIndex = 6
        Me.GOTHERINFO.Width = 100
        '
        'GPACKEDBY
        '
        Me.GPACKEDBY.Caption = "Packed By"
        Me.GPACKEDBY.FieldName = "PACKEDBY"
        Me.GPACKEDBY.Name = "GPACKEDBY"
        Me.GPACKEDBY.OptionsColumn.AllowEdit = False
        Me.GPACKEDBY.Visible = True
        Me.GPACKEDBY.VisibleIndex = 7
        Me.GPACKEDBY.Width = 100
        '
        'GPROFORMANO
        '
        Me.GPROFORMANO.Caption = "Proforma No"
        Me.GPROFORMANO.FieldName = "PROFORMANO"
        Me.GPROFORMANO.Name = "GPROFORMANO"
        Me.GPROFORMANO.OptionsColumn.AllowEdit = False
        Me.GPROFORMANO.Visible = True
        Me.GPROFORMANO.VisibleIndex = 8
        Me.GPROFORMANO.Width = 100
        '
        'GJONO
        '
        Me.GJONO.Caption = "Jo No"
        Me.GJONO.FieldName = "JONO"
        Me.GJONO.Name = "GJONO"
        Me.GJONO.OptionsColumn.AllowEdit = False
        Me.GJONO.Visible = True
        Me.GJONO.VisibleIndex = 9
        '
        'GJOSRNO
        '
        Me.GJOSRNO.Caption = "Jo Srno"
        Me.GJOSRNO.FieldName = "JOSRNO"
        Me.GJOSRNO.Name = "GJOSRNO"
        Me.GJOSRNO.OptionsColumn.AllowEdit = False
        '
        'GJODATE
        '
        Me.GJODATE.Caption = "Jo Date"
        Me.GJODATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GJODATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GJODATE.FieldName = "JODATE"
        Me.GJODATE.Name = "GJODATE"
        Me.GJODATE.OptionsColumn.AllowEdit = False
        Me.GJODATE.Visible = True
        Me.GJODATE.VisibleIndex = 10
        '
        'GJOTYPE
        '
        Me.GJOTYPE.Caption = "Jo Type"
        Me.GJOTYPE.FieldName = "JOTYPE"
        Me.GJOTYPE.Name = "GJOTYPE"
        Me.GJOTYPE.OptionsColumn.AllowEdit = False
        Me.GJOTYPE.Visible = True
        Me.GJOTYPE.VisibleIndex = 11
        '
        'GSONO
        '
        Me.GSONO.Caption = "So. No"
        Me.GSONO.FieldName = "SONO"
        Me.GSONO.Name = "GSONO"
        Me.GSONO.OptionsColumn.AllowEdit = False
        '
        'GSODATE
        '
        Me.GSODATE.Caption = "So Date"
        Me.GSODATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GSODATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GSODATE.FieldName = "SODATE"
        Me.GSODATE.Name = "GSODATE"
        Me.GSODATE.OptionsColumn.AllowEdit = False
        '
        'GSOTYPE
        '
        Me.GSOTYPE.Caption = "So Type"
        Me.GSOTYPE.FieldName = "SOTYPE"
        Me.GSOTYPE.Name = "GSOTYPE"
        Me.GSOTYPE.OptionsColumn.AllowEdit = False
        '
        'GGRIDSRNO
        '
        Me.GGRIDSRNO.Caption = "Gridsrno"
        Me.GGRIDSRNO.FieldName = "GRIDSRNO"
        Me.GGRIDSRNO.Name = "GGRIDSRNO"
        Me.GGRIDSRNO.OptionsColumn.AllowEdit = False
        '
        'GREMARK
        '
        Me.GREMARK.Caption = "Remarks"
        Me.GREMARK.FieldName = "REMARK"
        Me.GREMARK.Name = "GREMARK"
        Me.GREMARK.OptionsColumn.AllowEdit = False
        Me.GREMARK.Visible = True
        Me.GREMARK.VisibleIndex = 12
        '
        'GGRADE
        '
        Me.GGRADE.Caption = "Grade"
        Me.GGRADE.FieldName = "GRADE"
        Me.GGRADE.Name = "GGRADE"
        Me.GGRADE.OptionsColumn.AllowEdit = False
        Me.GGRADE.Visible = True
        Me.GGRADE.VisibleIndex = 13
        Me.GGRADE.Width = 200
        '
        'GLOTNO
        '
        Me.GLOTNO.Caption = "Lot No"
        Me.GLOTNO.FieldName = "LOTNO"
        Me.GLOTNO.Name = "GLOTNO"
        Me.GLOTNO.Visible = True
        Me.GLOTNO.VisibleIndex = 14
        Me.GLOTNO.Width = 100
        '
        'GROLLNO
        '
        Me.GROLLNO.Caption = "Roll No"
        Me.GROLLNO.FieldName = "ROLLNO"
        Me.GROLLNO.Name = "GROLLNO"
        Me.GROLLNO.OptionsColumn.AllowEdit = False
        Me.GROLLNO.Visible = True
        Me.GROLLNO.VisibleIndex = 15
        '
        'GGSM
        '
        Me.GGSM.Caption = "GSM"
        Me.GGSM.FieldName = "GSM"
        Me.GGSM.Name = "GGSM"
        Me.GGSM.OptionsColumn.AllowEdit = False
        Me.GGSM.Visible = True
        Me.GGSM.VisibleIndex = 16
        '
        'GGSMDETAILS
        '
        Me.GGSMDETAILS.Caption = "GSM Details"
        Me.GGSMDETAILS.FieldName = "GSMDETAILS"
        Me.GGSMDETAILS.Name = "GGSMDETAILS"
        Me.GGSMDETAILS.Visible = True
        Me.GGSMDETAILS.VisibleIndex = 17
        '
        'GSIZE
        '
        Me.GSIZE.Caption = "Size"
        Me.GSIZE.FieldName = "SIZE"
        Me.GSIZE.Name = "GSIZE"
        Me.GSIZE.OptionsColumn.AllowEdit = False
        Me.GSIZE.Visible = True
        Me.GSIZE.VisibleIndex = 18
        '
        'GWT
        '
        Me.GWT.Caption = "WT"
        Me.GWT.FieldName = "WT"
        Me.GWT.Name = "GWT"
        Me.GWT.OptionsColumn.AllowEdit = False
        Me.GWT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GWT.Visible = True
        Me.GWT.VisibleIndex = 19
        '
        'ROLLOD
        '
        Me.ROLLOD.Caption = "Roll OD"
        Me.ROLLOD.FieldName = "ROLLOD"
        Me.ROLLOD.Name = "ROLLOD"
        Me.ROLLOD.OptionsColumn.AllowEdit = False
        Me.ROLLOD.Visible = True
        Me.ROLLOD.VisibleIndex = 20
        '
        'GROLLID
        '
        Me.GROLLID.Caption = "Roll ID"
        Me.GROLLID.FieldName = "ROLLID"
        Me.GROLLID.Name = "GROLLID"
        Me.GROLLID.OptionsColumn.AllowEdit = False
        Me.GROLLID.Visible = True
        Me.GROLLID.VisibleIndex = 21
        '
        'GFINALWT
        '
        Me.GFINALWT.Caption = "Final WT"
        Me.GFINALWT.FieldName = "FINALWT"
        Me.GFINALWT.Name = "GFINALWT"
        Me.GFINALWT.OptionsColumn.AllowEdit = False
        Me.GFINALWT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GFINALWT.Visible = True
        Me.GFINALWT.VisibleIndex = 22
        '
        'GDIFF
        '
        Me.GDIFF.Caption = "DIFF"
        Me.GDIFF.FieldName = "DIFF"
        Me.GDIFF.Name = "GDIFF"
        Me.GDIFF.OptionsColumn.AllowEdit = False
        Me.GDIFF.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GDIFF.Visible = True
        Me.GDIFF.VisibleIndex = 23
        '
        'GUNIT
        '
        Me.GUNIT.Caption = "Unit"
        Me.GUNIT.FieldName = "UNIT"
        Me.GUNIT.Name = "GUNIT"
        Me.GUNIT.OptionsColumn.AllowEdit = False
        Me.GUNIT.Visible = True
        Me.GUNIT.VisibleIndex = 24
        '
        'GJOINT
        '
        Me.GJOINT.Caption = "Joint"
        Me.GJOINT.FieldName = "JOINT"
        Me.GJOINT.Name = "GJOINT"
        Me.GJOINT.OptionsColumn.AllowEdit = False
        Me.GJOINT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GJOINT.Visible = True
        Me.GJOINT.VisibleIndex = 25
        '
        'GNARRATION
        '
        Me.GNARRATION.Caption = "Narration"
        Me.GNARRATION.FieldName = "NARRATION"
        Me.GNARRATION.Name = "GNARRATION"
        Me.GNARRATION.OptionsColumn.AllowEdit = False
        Me.GNARRATION.Visible = True
        Me.GNARRATION.VisibleIndex = 26
        Me.GNARRATION.Width = 100
        '
        'GBARCODE
        '
        Me.GBARCODE.Caption = "Barcode"
        Me.GBARCODE.FieldName = "BARCODE"
        Me.GBARCODE.Name = "GBARCODE"
        Me.GBARCODE.OptionsColumn.AllowEdit = False
        Me.GBARCODE.Visible = True
        Me.GBARCODE.VisibleIndex = 27
        '
        'GTOTALWASTAGE
        '
        Me.GTOTALWASTAGE.Caption = "Total Wastage"
        Me.GTOTALWASTAGE.FieldName = "TOTALWASWT"
        Me.GTOTALWASTAGE.Name = "GTOTALWASTAGE"
        Me.GTOTALWASTAGE.OptionsColumn.AllowEdit = False
        Me.GTOTALWASTAGE.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GTOTALWASTAGE.Visible = True
        Me.GTOTALWASTAGE.VisibleIndex = 28
        Me.GTOTALWASTAGE.Width = 100
        '
        'TXTFROM
        '
        Me.TXTFROM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTFROM.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTFROM.Location = New System.Drawing.Point(248, 1)
        Me.TXTFROM.Name = "TXTFROM"
        Me.TXTFROM.Size = New System.Drawing.Size(50, 22)
        Me.TXTFROM.TabIndex = 796
        Me.TXTFROM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(382, 5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 14)
        Me.Label4.TabIndex = 801
        Me.Label4.Text = "Copies"
        '
        'TXTCOPIES
        '
        Me.TXTCOPIES.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTCOPIES.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCOPIES.Location = New System.Drawing.Point(430, 1)
        Me.TXTCOPIES.Name = "TXTCOPIES"
        Me.TXTCOPIES.Size = New System.Drawing.Size(29, 22)
        Me.TXTCOPIES.TabIndex = 798
        Me.TXTCOPIES.Text = "1"
        Me.TXTCOPIES.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.White
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(303, 5)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(19, 14)
        Me.Label9.TabIndex = 800
        Me.Label9.Text = "To"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.White
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(209, 5)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(34, 14)
        Me.Label10.TabIndex = 799
        Me.Label10.Text = "From"
        '
        'TXTTO
        '
        Me.TXTTO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTTO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTO.Location = New System.Drawing.Point(327, 1)
        Me.TXTTO.Name = "TXTTO"
        Me.TXTTO.Size = New System.Drawing.Size(52, 22)
        Me.TXTTO.TabIndex = 797
        Me.TXTTO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(664, 543)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 3
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.toolStripSeparator, Me.TOOLREFRESH, Me.TOOLWHATSAPP, Me.TOOLMAIL, Me.TOOLEXCEL, Me.TOOLPRINT, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1284, 25)
        Me.ToolStrip1.TabIndex = 255
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(59, 22)
        Me.ToolStripButton1.Text = "Add New"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'TOOLREFRESH
        '
        Me.TOOLREFRESH.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TOOLREFRESH.Image = Global.ZALANI.My.Resources.Resources.refresh1
        Me.TOOLREFRESH.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLREFRESH.Name = "TOOLREFRESH"
        Me.TOOLREFRESH.Size = New System.Drawing.Size(23, 22)
        Me.TOOLREFRESH.Text = "&Refresh"
        '
        'TOOLWHATSAPP
        '
        Me.TOOLWHATSAPP.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TOOLWHATSAPP.Image = Global.ZALANI.My.Resources.Resources.WHATSAPP
        Me.TOOLWHATSAPP.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLWHATSAPP.Name = "TOOLWHATSAPP"
        Me.TOOLWHATSAPP.Size = New System.Drawing.Size(23, 22)
        Me.TOOLWHATSAPP.Text = "Whatsapp"
        '
        'TOOLMAIL
        '
        Me.TOOLMAIL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TOOLMAIL.Image = Global.ZALANI.My.Resources.Resources.MAIL_IMAGE
        Me.TOOLMAIL.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLMAIL.Name = "TOOLMAIL"
        Me.TOOLMAIL.Size = New System.Drawing.Size(23, 22)
        Me.TOOLMAIL.Text = "Mail Gate Pass Directly"
        '
        'TOOLEXCEL
        '
        Me.TOOLEXCEL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TOOLEXCEL.Image = Global.ZALANI.My.Resources.Resources.Excel_icon
        Me.TOOLEXCEL.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLEXCEL.Name = "TOOLEXCEL"
        Me.TOOLEXCEL.Size = New System.Drawing.Size(23, 22)
        Me.TOOLEXCEL.Text = "&Print"
        '
        'TOOLPRINT
        '
        Me.TOOLPRINT.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TOOLPRINT.Image = CType(resources.GetObject("TOOLPRINT.Image"), System.Drawing.Image)
        Me.TOOLPRINT.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLPRINT.Name = "TOOLPRINT"
        Me.TOOLPRINT.Size = New System.Drawing.Size(23, 22)
        Me.TOOLPRINT.Text = "&Print"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.Black
        Me.cmdok.Location = New System.Drawing.Point(576, 543)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 2
        Me.cmdok.Text = "&Ok"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'PRINTDIALOG
        '
        Me.PRINTDIALOG.AllowSelection = True
        Me.PRINTDIALOG.AllowSomePages = True
        Me.PRINTDIALOG.ShowHelp = True
        Me.PRINTDIALOG.UseEXDialog = True
        '
        'LabelingDepartmentDetail
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1284, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "LabelingDepartmentDetail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Labeling Department Detail"
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents gsrno As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGODOWN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GHANDLINGINFO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPROFORMANO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GJONO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GOTHERINFO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GJOSRNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GJODATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GJOTYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSONO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSODATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSOTYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGRIDSRNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GISSDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREMARK As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGRADE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSIZE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDIFF As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GUNIT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALWASTAGE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TXTFROM As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TXTCOPIES As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents TXTTO As TextBox
    Friend WithEvents cmdexit As Button
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents toolStripSeparator As ToolStripSeparator
    Friend WithEvents TOOLREFRESH As ToolStripButton
    Friend WithEvents TOOLWHATSAPP As ToolStripButton
    Friend WithEvents TOOLMAIL As ToolStripButton
    Friend WithEvents TOOLEXCEL As ToolStripButton
    Friend WithEvents TOOLPRINT As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents cmdok As Button
    Friend WithEvents GPACKEDBY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ROLLOD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GROLLID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GFINALWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GJOINT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNARRATION As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBARCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GROLLNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGSM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPARTYNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GLOTNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PRINTDIALOG As PrintDialog
    Friend WithEvents PRINTDOC As Printing.PrintDocument
    Friend WithEvents GGSMDETAILS As DevExpress.XtraGrid.Columns.GridColumn
End Class
