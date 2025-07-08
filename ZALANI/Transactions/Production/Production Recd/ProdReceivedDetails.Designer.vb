<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProdReceivedDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProdReceivedDetails))
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gsrno = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGRIDPRISSUSRNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRECDDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMACHINENO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GOPERATOR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPROFORMANO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GJONO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GFINALQUALITY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GJOSRNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GJODATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GJOTYPE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSONO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSODATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSOTYPE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GISSUENO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GISSDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GQUALITY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GLOTNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GROLLNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGSM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GIGSMDETAILS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSIZE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMILLQTY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GOURQTY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDIFF = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GUNIT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGODOWN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREMARKS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSHIFT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GHEATINGTIME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRUNNINGTIME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSTOPTIME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALISSWT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALRECDWT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALBALWT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALWASWT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALFINALBALWT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GWASTAGEPERCENTAGE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALREELNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALDIFF = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALWT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALROLLNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALISSRECDWT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALGSM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TXTFROM = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TXTCOPIES = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TXTTO = New System.Windows.Forms.TextBox()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.TOOLREFRESH = New System.Windows.Forms.ToolStripButton()
        Me.TOOLWHATSAPP = New System.Windows.Forms.ToolStripButton()
        Me.TOOLMAIL = New System.Windows.Forms.ToolStripButton()
        Me.TOOLEXCEL = New System.Windows.Forms.ToolStripButton()
        Me.TOOLPRINT = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.PRINTDOC = New System.Drawing.Printing.PrintDocument()
        Me.PRINTDIALOG = New System.Windows.Forms.PrintDialog()
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
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 581)
        Me.BlendPanel1.TabIndex = 5
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(11, 49)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(1200, 473)
        Me.gridbilldetails.TabIndex = 802
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.HeaderPanel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.HeaderPanel.Options.UseFont = True
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gsrno, Me.GGRIDPRISSUSRNO, Me.GRECDDATE, Me.GMACHINENO, Me.GOPERATOR, Me.GPROFORMANO, Me.GDATE, Me.GJONO, Me.GFINALQUALITY, Me.GJOSRNO, Me.GJODATE, Me.GJOTYPE, Me.GSONO, Me.GSODATE, Me.GSOTYPE, Me.GISSUENO, Me.GISSDATE, Me.GQUALITY, Me.GLOTNO, Me.GROLLNO, Me.GGSM, Me.GIGSMDETAILS, Me.GSIZE, Me.GMILLQTY, Me.GOURQTY, Me.GDIFF, Me.GUNIT, Me.GGODOWN, Me.GREMARKS, Me.GSHIFT, Me.GHEATINGTIME, Me.GRUNNINGTIME, Me.GSTOPTIME, Me.GTOTALISSWT, Me.GTOTALRECDWT, Me.GTOTALBALWT, Me.GTOTALWASWT, Me.GTOTALFINALBALWT, Me.GWASTAGEPERCENTAGE, Me.GTOTALREELNO, Me.GTOTALDIFF, Me.GTOTALWT, Me.GTOTALROLLNO, Me.GTOTALISSRECDWT, Me.GTOTALGSM, Me.GNAME})
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
        Me.gsrno.FieldName = "TEMPPRODRECDNO"
        Me.gsrno.Name = "gsrno"
        Me.gsrno.OptionsColumn.AllowEdit = False
        Me.gsrno.Visible = True
        Me.gsrno.VisibleIndex = 1
        '
        'GGRIDPRISSUSRNO
        '
        Me.GGRIDPRISSUSRNO.Caption = "Grid Issue No"
        Me.GGRIDPRISSUSRNO.FieldName = "GRIDPRISSUSRNO"
        Me.GGRIDPRISSUSRNO.Name = "GGRIDPRISSUSRNO"
        Me.GGRIDPRISSUSRNO.OptionsColumn.AllowEdit = False
        Me.GGRIDPRISSUSRNO.Visible = True
        Me.GGRIDPRISSUSRNO.VisibleIndex = 2
        '
        'GRECDDATE
        '
        Me.GRECDDATE.Caption = "Recd Date"
        Me.GRECDDATE.FieldName = "RECDDATE"
        Me.GRECDDATE.Name = "GRECDDATE"
        Me.GRECDDATE.OptionsColumn.AllowEdit = False
        Me.GRECDDATE.Visible = True
        Me.GRECDDATE.VisibleIndex = 3
        '
        'GMACHINENO
        '
        Me.GMACHINENO.Caption = "Machine No"
        Me.GMACHINENO.FieldName = "MACHINE"
        Me.GMACHINENO.Name = "GMACHINENO"
        Me.GMACHINENO.OptionsColumn.AllowEdit = False
        Me.GMACHINENO.Visible = True
        Me.GMACHINENO.VisibleIndex = 4
        Me.GMACHINENO.Width = 140
        '
        'GOPERATOR
        '
        Me.GOPERATOR.Caption = "Operator"
        Me.GOPERATOR.FieldName = "OPERATOR"
        Me.GOPERATOR.Name = "GOPERATOR"
        Me.GOPERATOR.OptionsColumn.AllowEdit = False
        Me.GOPERATOR.Visible = True
        Me.GOPERATOR.VisibleIndex = 5
        Me.GOPERATOR.Width = 200
        '
        'GPROFORMANO
        '
        Me.GPROFORMANO.Caption = "Proforma No"
        Me.GPROFORMANO.FieldName = "PROFORMANO"
        Me.GPROFORMANO.Name = "GPROFORMANO"
        Me.GPROFORMANO.OptionsColumn.AllowEdit = False
        Me.GPROFORMANO.Visible = True
        Me.GPROFORMANO.VisibleIndex = 6
        '
        'GDATE
        '
        Me.GDATE.Caption = "Proforma Date"
        Me.GDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GDATE.FieldName = "PROFORMADATE"
        Me.GDATE.Name = "GDATE"
        Me.GDATE.OptionsColumn.AllowEdit = False
        Me.GDATE.Visible = True
        Me.GDATE.VisibleIndex = 7
        '
        'GJONO
        '
        Me.GJONO.Caption = "Jo No"
        Me.GJONO.FieldName = "JONO"
        Me.GJONO.Name = "GJONO"
        Me.GJONO.OptionsColumn.AllowEdit = False
        Me.GJONO.Visible = True
        Me.GJONO.VisibleIndex = 8
        '
        'GFINALQUALITY
        '
        Me.GFINALQUALITY.Caption = "Final Quality"
        Me.GFINALQUALITY.FieldName = "FINALQUALITY"
        Me.GFINALQUALITY.Name = "GFINALQUALITY"
        Me.GFINALQUALITY.OptionsColumn.AllowEdit = False
        Me.GFINALQUALITY.Visible = True
        Me.GFINALQUALITY.VisibleIndex = 9
        Me.GFINALQUALITY.Width = 200
        '
        'GJOSRNO
        '
        Me.GJOSRNO.Caption = "Jo Srno"
        Me.GJOSRNO.FieldName = "JOSRNO"
        Me.GJOSRNO.Name = "GJOSRNO"
        Me.GJOSRNO.OptionsColumn.AllowEdit = False
        Me.GJOSRNO.Visible = True
        Me.GJOSRNO.VisibleIndex = 10
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
        Me.GJODATE.VisibleIndex = 11
        '
        'GJOTYPE
        '
        Me.GJOTYPE.Caption = "Jo Type"
        Me.GJOTYPE.FieldName = "JOTYPE"
        Me.GJOTYPE.Name = "GJOTYPE"
        Me.GJOTYPE.OptionsColumn.AllowEdit = False
        Me.GJOTYPE.Visible = True
        Me.GJOTYPE.VisibleIndex = 12
        Me.GJOTYPE.Width = 120
        '
        'GSONO
        '
        Me.GSONO.Caption = "So. No"
        Me.GSONO.FieldName = "SONO"
        Me.GSONO.Name = "GSONO"
        Me.GSONO.OptionsColumn.AllowEdit = False
        Me.GSONO.Visible = True
        Me.GSONO.VisibleIndex = 13
        '
        'GSODATE
        '
        Me.GSODATE.Caption = "So Date"
        Me.GSODATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GSODATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GSODATE.FieldName = "SODATE"
        Me.GSODATE.Name = "GSODATE"
        Me.GSODATE.OptionsColumn.AllowEdit = False
        Me.GSODATE.Visible = True
        Me.GSODATE.VisibleIndex = 14
        '
        'GSOTYPE
        '
        Me.GSOTYPE.Caption = "So Type"
        Me.GSOTYPE.FieldName = "SOTYPE"
        Me.GSOTYPE.Name = "GSOTYPE"
        Me.GSOTYPE.OptionsColumn.AllowEdit = False
        Me.GSOTYPE.Visible = True
        Me.GSOTYPE.VisibleIndex = 15
        Me.GSOTYPE.Width = 120
        '
        'GISSUENO
        '
        Me.GISSUENO.Caption = "Issue No"
        Me.GISSUENO.FieldName = "GRIDISSUESRNO"
        Me.GISSUENO.Name = "GISSUENO"
        Me.GISSUENO.OptionsColumn.AllowEdit = False
        Me.GISSUENO.Visible = True
        Me.GISSUENO.VisibleIndex = 16
        '
        'GISSDATE
        '
        Me.GISSDATE.Caption = "Issue Date"
        Me.GISSDATE.FieldName = "ISSUEDATE"
        Me.GISSDATE.Name = "GISSDATE"
        Me.GISSDATE.OptionsColumn.AllowEdit = False
        Me.GISSDATE.Visible = True
        Me.GISSDATE.VisibleIndex = 17
        '
        'GQUALITY
        '
        Me.GQUALITY.Caption = "Quality"
        Me.GQUALITY.FieldName = "QUALITY"
        Me.GQUALITY.Name = "GQUALITY"
        Me.GQUALITY.OptionsColumn.AllowEdit = False
        Me.GQUALITY.Visible = True
        Me.GQUALITY.VisibleIndex = 18
        Me.GQUALITY.Width = 200
        '
        'GLOTNO
        '
        Me.GLOTNO.Caption = "Lotno"
        Me.GLOTNO.FieldName = "LOTNO"
        Me.GLOTNO.Name = "GLOTNO"
        Me.GLOTNO.OptionsColumn.AllowEdit = False
        Me.GLOTNO.Visible = True
        Me.GLOTNO.VisibleIndex = 19
        Me.GLOTNO.Width = 100
        '
        'GROLLNO
        '
        Me.GROLLNO.Caption = "Reel/RollNo"
        Me.GROLLNO.FieldName = "REELROLLNO"
        Me.GROLLNO.Name = "GROLLNO"
        Me.GROLLNO.OptionsColumn.AllowEdit = False
        Me.GROLLNO.Visible = True
        Me.GROLLNO.VisibleIndex = 20
        Me.GROLLNO.Width = 100
        '
        'GGSM
        '
        Me.GGSM.Caption = "Gsm"
        Me.GGSM.FieldName = "GSM"
        Me.GGSM.Name = "GGSM"
        Me.GGSM.OptionsColumn.AllowEdit = False
        Me.GGSM.Visible = True
        Me.GGSM.VisibleIndex = 21
        Me.GGSM.Width = 100
        '
        'GIGSMDETAILS
        '
        Me.GIGSMDETAILS.Caption = "Issue Gsm Details"
        Me.GIGSMDETAILS.FieldName = "IGSMDETAILS"
        Me.GIGSMDETAILS.Name = "GIGSMDETAILS"
        Me.GIGSMDETAILS.Visible = True
        Me.GIGSMDETAILS.VisibleIndex = 22
        Me.GIGSMDETAILS.Width = 100
        '
        'GSIZE
        '
        Me.GSIZE.Caption = "Size"
        Me.GSIZE.FieldName = "SIZE"
        Me.GSIZE.Name = "GSIZE"
        Me.GSIZE.OptionsColumn.AllowEdit = False
        Me.GSIZE.Visible = True
        Me.GSIZE.VisibleIndex = 23
        Me.GSIZE.Width = 100
        '
        'GMILLQTY
        '
        Me.GMILLQTY.Caption = "Mill Qty"
        Me.GMILLQTY.FieldName = "MILLQTY"
        Me.GMILLQTY.Name = "GMILLQTY"
        Me.GMILLQTY.OptionsColumn.AllowEdit = False
        Me.GMILLQTY.Visible = True
        Me.GMILLQTY.VisibleIndex = 24
        '
        'GOURQTY
        '
        Me.GOURQTY.Caption = "Our Qty"
        Me.GOURQTY.FieldName = "OURQTY"
        Me.GOURQTY.Name = "GOURQTY"
        Me.GOURQTY.OptionsColumn.AllowEdit = False
        Me.GOURQTY.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GOURQTY.Visible = True
        Me.GOURQTY.VisibleIndex = 25
        Me.GOURQTY.Width = 100
        '
        'GDIFF
        '
        Me.GDIFF.Caption = "DIFF"
        Me.GDIFF.FieldName = "DIFF"
        Me.GDIFF.Name = "GDIFF"
        Me.GDIFF.OptionsColumn.AllowEdit = False
        Me.GDIFF.Visible = True
        Me.GDIFF.VisibleIndex = 26
        Me.GDIFF.Width = 100
        '
        'GUNIT
        '
        Me.GUNIT.Caption = "Unit"
        Me.GUNIT.FieldName = "UNIT"
        Me.GUNIT.Name = "GUNIT"
        Me.GUNIT.OptionsColumn.AllowEdit = False
        Me.GUNIT.Visible = True
        Me.GUNIT.VisibleIndex = 27
        Me.GUNIT.Width = 100
        '
        'GGODOWN
        '
        Me.GGODOWN.Caption = "Godown"
        Me.GGODOWN.FieldName = "GODOWN"
        Me.GGODOWN.Name = "GGODOWN"
        Me.GGODOWN.OptionsColumn.AllowEdit = False
        Me.GGODOWN.Visible = True
        Me.GGODOWN.VisibleIndex = 29
        Me.GGODOWN.Width = 120
        '
        'GREMARKS
        '
        Me.GREMARKS.Caption = "Remarks"
        Me.GREMARKS.FieldName = "REMARK"
        Me.GREMARKS.Name = "GREMARKS"
        Me.GREMARKS.OptionsColumn.AllowEdit = False
        Me.GREMARKS.Visible = True
        Me.GREMARKS.VisibleIndex = 46
        Me.GREMARKS.Width = 150
        '
        'GSHIFT
        '
        Me.GSHIFT.Caption = "Shift"
        Me.GSHIFT.FieldName = "SHIFT"
        Me.GSHIFT.Name = "GSHIFT"
        Me.GSHIFT.OptionsColumn.AllowEdit = False
        Me.GSHIFT.Visible = True
        Me.GSHIFT.VisibleIndex = 28
        '
        'GHEATINGTIME
        '
        Me.GHEATINGTIME.Caption = "Heating Time"
        Me.GHEATINGTIME.FieldName = "HEATINGTIME"
        Me.GHEATINGTIME.Name = "GHEATINGTIME"
        Me.GHEATINGTIME.OptionsColumn.AllowEdit = False
        Me.GHEATINGTIME.Visible = True
        Me.GHEATINGTIME.VisibleIndex = 30
        '
        'GRUNNINGTIME
        '
        Me.GRUNNINGTIME.Caption = "Running Time"
        Me.GRUNNINGTIME.FieldName = "RUNNINGTIME"
        Me.GRUNNINGTIME.Name = "GRUNNINGTIME"
        Me.GRUNNINGTIME.OptionsColumn.AllowEdit = False
        Me.GRUNNINGTIME.Visible = True
        Me.GRUNNINGTIME.VisibleIndex = 31
        '
        'GSTOPTIME
        '
        Me.GSTOPTIME.Caption = "Stop Time"
        Me.GSTOPTIME.FieldName = "STOPTIME"
        Me.GSTOPTIME.Name = "GSTOPTIME"
        Me.GSTOPTIME.OptionsColumn.AllowEdit = False
        Me.GSTOPTIME.Visible = True
        Me.GSTOPTIME.VisibleIndex = 32
        '
        'GTOTALISSWT
        '
        Me.GTOTALISSWT.Caption = "Total Issue WT"
        Me.GTOTALISSWT.FieldName = "TOTALISSWT"
        Me.GTOTALISSWT.Name = "GTOTALISSWT"
        Me.GTOTALISSWT.OptionsColumn.AllowEdit = False
        Me.GTOTALISSWT.Visible = True
        Me.GTOTALISSWT.VisibleIndex = 33
        '
        'GTOTALRECDWT
        '
        Me.GTOTALRECDWT.Caption = "Total Recd WT"
        Me.GTOTALRECDWT.FieldName = "TOTALRECDWT"
        Me.GTOTALRECDWT.Name = "GTOTALRECDWT"
        Me.GTOTALRECDWT.OptionsColumn.AllowEdit = False
        Me.GTOTALRECDWT.Visible = True
        Me.GTOTALRECDWT.VisibleIndex = 34
        '
        'GTOTALBALWT
        '
        Me.GTOTALBALWT.Caption = "Total Bal WT"
        Me.GTOTALBALWT.FieldName = "TOTALBALWT"
        Me.GTOTALBALWT.Name = "GTOTALBALWT"
        Me.GTOTALBALWT.OptionsColumn.AllowEdit = False
        Me.GTOTALBALWT.Visible = True
        Me.GTOTALBALWT.VisibleIndex = 35
        '
        'GTOTALWASWT
        '
        Me.GTOTALWASWT.Caption = "Total Was WT"
        Me.GTOTALWASWT.FieldName = "TOTALWASWT"
        Me.GTOTALWASWT.Name = "GTOTALWASWT"
        Me.GTOTALWASWT.OptionsColumn.AllowEdit = False
        Me.GTOTALWASWT.Visible = True
        Me.GTOTALWASWT.VisibleIndex = 36
        '
        'GTOTALFINALBALWT
        '
        Me.GTOTALFINALBALWT.Caption = "Total Final Bal WT"
        Me.GTOTALFINALBALWT.FieldName = "TOTALFINALBALWT"
        Me.GTOTALFINALBALWT.Name = "GTOTALFINALBALWT"
        Me.GTOTALFINALBALWT.OptionsColumn.AllowEdit = False
        Me.GTOTALFINALBALWT.Visible = True
        Me.GTOTALFINALBALWT.VisibleIndex = 37
        '
        'GWASTAGEPERCENTAGE
        '
        Me.GWASTAGEPERCENTAGE.Caption = "Wastage %"
        Me.GWASTAGEPERCENTAGE.FieldName = "WASTAGEPERCENTAGE"
        Me.GWASTAGEPERCENTAGE.Name = "GWASTAGEPERCENTAGE"
        Me.GWASTAGEPERCENTAGE.OptionsColumn.AllowEdit = False
        Me.GWASTAGEPERCENTAGE.Visible = True
        Me.GWASTAGEPERCENTAGE.VisibleIndex = 38
        '
        'GTOTALREELNO
        '
        Me.GTOTALREELNO.Caption = "Total Reel No"
        Me.GTOTALREELNO.FieldName = "TOTALREELNO"
        Me.GTOTALREELNO.Name = "GTOTALREELNO"
        Me.GTOTALREELNO.OptionsColumn.AllowEdit = False
        Me.GTOTALREELNO.Visible = True
        Me.GTOTALREELNO.VisibleIndex = 39
        '
        'GTOTALDIFF
        '
        Me.GTOTALDIFF.Caption = "Total Diff"
        Me.GTOTALDIFF.FieldName = "TOTALDIFF"
        Me.GTOTALDIFF.Name = "GTOTALDIFF"
        Me.GTOTALDIFF.OptionsColumn.AllowEdit = False
        Me.GTOTALDIFF.Visible = True
        Me.GTOTALDIFF.VisibleIndex = 40
        '
        'GTOTALWT
        '
        Me.GTOTALWT.Caption = "Total WT"
        Me.GTOTALWT.FieldName = "TOTALWT"
        Me.GTOTALWT.Name = "GTOTALWT"
        Me.GTOTALWT.OptionsColumn.AllowEdit = False
        Me.GTOTALWT.Visible = True
        Me.GTOTALWT.VisibleIndex = 41
        '
        'GTOTALROLLNO
        '
        Me.GTOTALROLLNO.Caption = "Total Roll No"
        Me.GTOTALROLLNO.FieldName = "TOTALROLLNO"
        Me.GTOTALROLLNO.Name = "GTOTALROLLNO"
        Me.GTOTALROLLNO.OptionsColumn.AllowEdit = False
        Me.GTOTALROLLNO.Visible = True
        Me.GTOTALROLLNO.VisibleIndex = 42
        '
        'GTOTALISSRECDWT
        '
        Me.GTOTALISSRECDWT.Caption = "Total Issue Recd WT"
        Me.GTOTALISSRECDWT.FieldName = "TOTALISSRECDWT"
        Me.GTOTALISSRECDWT.Name = "GTOTALISSRECDWT"
        Me.GTOTALISSRECDWT.OptionsColumn.AllowEdit = False
        Me.GTOTALISSRECDWT.Visible = True
        Me.GTOTALISSRECDWT.VisibleIndex = 43
        '
        'GTOTALGSM
        '
        Me.GTOTALGSM.Caption = "Total GSM"
        Me.GTOTALGSM.FieldName = "TOTALGSM"
        Me.GTOTALGSM.Name = "GTOTALGSM"
        Me.GTOTALGSM.OptionsColumn.AllowEdit = False
        Me.GTOTALGSM.Visible = True
        Me.GTOTALGSM.VisibleIndex = 44
        '
        'GNAME
        '
        Me.GNAME.Caption = "Party Name"
        Me.GNAME.FieldName = "NAME"
        Me.GNAME.Name = "GNAME"
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 45
        Me.GNAME.Width = 250
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
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton, Me.toolStripSeparator, Me.TOOLREFRESH, Me.TOOLWHATSAPP, Me.TOOLMAIL, Me.TOOLEXCEL, Me.TOOLPRINT, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1234, 25)
        Me.ToolStrip1.TabIndex = 255
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton
        '
        Me.ToolStripButton.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton.Name = "ToolStripButton"
        Me.ToolStripButton.Size = New System.Drawing.Size(59, 22)
        Me.ToolStripButton.Text = "Add New"
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
        'ProdReceivedDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "ProdReceivedDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "ProdReceivedDetails"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
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
    Friend WithEvents GMACHINENO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPROFORMANO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GJONO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GFINALQUALITY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GJOSRNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GJODATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GJOTYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSONO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSODATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSOTYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GISSUENO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GISSDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREMARKS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GQUALITY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GLOTNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GROLLNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGSM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSIZE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GOURQTY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDIFF As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GUNIT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TXTFROM As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TXTCOPIES As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents TXTTO As TextBox
    Friend WithEvents cmdexit As Button
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButton As ToolStripButton
    Friend WithEvents toolStripSeparator As ToolStripSeparator
    Friend WithEvents TOOLREFRESH As ToolStripButton
    Friend WithEvents TOOLWHATSAPP As ToolStripButton
    Friend WithEvents TOOLMAIL As ToolStripButton
    Friend WithEvents TOOLEXCEL As ToolStripButton
    Friend WithEvents TOOLPRINT As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents cmdok As Button
    Friend WithEvents GRECDDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GOPERATOR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGRIDPRISSUSRNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSHIFT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GHEATINGTIME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRUNNINGTIME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSTOPTIME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALISSWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALRECDWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALBALWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALWASWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALFINALBALWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GWASTAGEPERCENTAGE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALREELNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALDIFF As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALROLLNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALISSRECDWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALGSM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMILLQTY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PRINTDOC As Printing.PrintDocument
    Friend WithEvents PRINTDIALOG As PrintDialog
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GIGSMDETAILS As DevExpress.XtraGrid.Columns.GridColumn
End Class
