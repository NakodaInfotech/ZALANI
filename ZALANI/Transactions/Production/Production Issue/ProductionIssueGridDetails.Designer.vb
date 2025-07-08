<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProductionIssueGridDetails
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
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gsrno = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GISSDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GFINALQUALITY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMACHINENO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GQUALITY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GLOTNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GROLLNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGSM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSIZE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMILLWT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GOURQTY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDIFF = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GUNIT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCUSTOMERNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREMARKS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGODOWN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPROFORMANO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GJONO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GJOSRNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GJODATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GJOTYPE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSONO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSODATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSOTYPE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GISSUENO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALWASTAGE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.TOOLREFRESH = New System.Windows.Forms.ToolStripButton()
        Me.TOOLEXCEL = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.GGSMDETAILS = New DevExpress.XtraGrid.Columns.GridColumn()
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
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gsrno, Me.GISSDATE, Me.GFINALQUALITY, Me.GMACHINENO, Me.GQUALITY, Me.GLOTNO, Me.GROLLNO, Me.GGSM, Me.GGSMDETAILS, Me.GSIZE, Me.GMILLWT, Me.GOURQTY, Me.GDIFF, Me.GUNIT, Me.GCUSTOMERNAME, Me.GREMARKS, Me.GGODOWN, Me.GPROFORMANO, Me.GDATE, Me.GJONO, Me.GJOSRNO, Me.GJODATE, Me.GJOTYPE, Me.GSONO, Me.GSODATE, Me.GSOTYPE, Me.GISSUENO, Me.GTOTALWASTAGE})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AutoExpandAllGroups = True
        Me.gridbill.OptionsBehavior.Editable = False
        Me.gridbill.OptionsSelection.CheckBoxSelectorColumnWidth = 30
        Me.gridbill.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        Me.gridbill.OptionsView.ShowGroupPanel = False
        '
        'gsrno
        '
        Me.gsrno.Caption = "Sr. No"
        Me.gsrno.FieldName = "TEMPPRODISSUENO"
        Me.gsrno.Name = "gsrno"
        Me.gsrno.OptionsColumn.AllowEdit = False
        Me.gsrno.Visible = True
        Me.gsrno.VisibleIndex = 0
        '
        'GISSDATE
        '
        Me.GISSDATE.Caption = "Date"
        Me.GISSDATE.FieldName = "ISSUEDATE"
        Me.GISSDATE.Name = "GISSDATE"
        Me.GISSDATE.OptionsColumn.AllowEdit = False
        Me.GISSDATE.Visible = True
        Me.GISSDATE.VisibleIndex = 1
        '
        'GFINALQUALITY
        '
        Me.GFINALQUALITY.Caption = "Final Quality"
        Me.GFINALQUALITY.FieldName = "FINALQUALITY"
        Me.GFINALQUALITY.Name = "GFINALQUALITY"
        Me.GFINALQUALITY.OptionsColumn.AllowEdit = False
        Me.GFINALQUALITY.Visible = True
        Me.GFINALQUALITY.VisibleIndex = 2
        Me.GFINALQUALITY.Width = 200
        '
        'GMACHINENO
        '
        Me.GMACHINENO.Caption = "Machine No"
        Me.GMACHINENO.FieldName = "MACHINE"
        Me.GMACHINENO.Name = "GMACHINENO"
        Me.GMACHINENO.OptionsColumn.AllowEdit = False
        Me.GMACHINENO.Visible = True
        Me.GMACHINENO.VisibleIndex = 3
        Me.GMACHINENO.Width = 100
        '
        'GQUALITY
        '
        Me.GQUALITY.Caption = "Quality"
        Me.GQUALITY.FieldName = "QUALITY"
        Me.GQUALITY.Name = "GQUALITY"
        Me.GQUALITY.OptionsColumn.AllowEdit = False
        Me.GQUALITY.Visible = True
        Me.GQUALITY.VisibleIndex = 4
        Me.GQUALITY.Width = 200
        '
        'GLOTNO
        '
        Me.GLOTNO.Caption = "Lotno"
        Me.GLOTNO.FieldName = "LOTNO"
        Me.GLOTNO.Name = "GLOTNO"
        Me.GLOTNO.OptionsColumn.AllowEdit = False
        Me.GLOTNO.Visible = True
        Me.GLOTNO.VisibleIndex = 5
        Me.GLOTNO.Width = 100
        '
        'GROLLNO
        '
        Me.GROLLNO.Caption = "Reel/RollNo"
        Me.GROLLNO.FieldName = "ROLLNO"
        Me.GROLLNO.Name = "GROLLNO"
        Me.GROLLNO.OptionsColumn.AllowEdit = False
        Me.GROLLNO.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)})
        Me.GROLLNO.Visible = True
        Me.GROLLNO.VisibleIndex = 6
        Me.GROLLNO.Width = 100
        '
        'GGSM
        '
        Me.GGSM.Caption = "Gsm"
        Me.GGSM.FieldName = "GSM"
        Me.GGSM.Name = "GGSM"
        Me.GGSM.OptionsColumn.AllowEdit = False
        Me.GGSM.Visible = True
        Me.GGSM.VisibleIndex = 7
        '
        'GSIZE
        '
        Me.GSIZE.Caption = "Size"
        Me.GSIZE.FieldName = "SIZE"
        Me.GSIZE.Name = "GSIZE"
        Me.GSIZE.OptionsColumn.AllowEdit = False
        Me.GSIZE.Visible = True
        Me.GSIZE.VisibleIndex = 9
        '
        'GMILLWT
        '
        Me.GMILLWT.Caption = "Mill Qty"
        Me.GMILLWT.DisplayFormat.FormatString = "0.00"
        Me.GMILLWT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GMILLWT.FieldName = "MILLQTY"
        Me.GMILLWT.Name = "GMILLWT"
        Me.GMILLWT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GMILLWT.Visible = True
        Me.GMILLWT.VisibleIndex = 10
        Me.GMILLWT.Width = 85
        '
        'GOURQTY
        '
        Me.GOURQTY.Caption = "Our Qty"
        Me.GOURQTY.FieldName = "OURQTY"
        Me.GOURQTY.Name = "GOURQTY"
        Me.GOURQTY.OptionsColumn.AllowEdit = False
        Me.GOURQTY.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GOURQTY.Visible = True
        Me.GOURQTY.VisibleIndex = 11
        Me.GOURQTY.Width = 85
        '
        'GDIFF
        '
        Me.GDIFF.Caption = "Diff"
        Me.GDIFF.FieldName = "DIFF"
        Me.GDIFF.Name = "GDIFF"
        Me.GDIFF.OptionsColumn.AllowEdit = False
        Me.GDIFF.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GDIFF.Visible = True
        Me.GDIFF.VisibleIndex = 12
        Me.GDIFF.Width = 85
        '
        'GUNIT
        '
        Me.GUNIT.Caption = "Unit"
        Me.GUNIT.FieldName = "UNIT"
        Me.GUNIT.Name = "GUNIT"
        Me.GUNIT.OptionsColumn.AllowEdit = False
        Me.GUNIT.Visible = True
        Me.GUNIT.VisibleIndex = 13
        '
        'GCUSTOMERNAME
        '
        Me.GCUSTOMERNAME.Caption = "Customer Name"
        Me.GCUSTOMERNAME.FieldName = "PARTYNAME"
        Me.GCUSTOMERNAME.Name = "GCUSTOMERNAME"
        Me.GCUSTOMERNAME.Visible = True
        Me.GCUSTOMERNAME.VisibleIndex = 14
        Me.GCUSTOMERNAME.Width = 250
        '
        'GREMARKS
        '
        Me.GREMARKS.Caption = "Remarks"
        Me.GREMARKS.FieldName = "REMARKS"
        Me.GREMARKS.Name = "GREMARKS"
        Me.GREMARKS.OptionsColumn.AllowEdit = False
        Me.GREMARKS.Visible = True
        Me.GREMARKS.VisibleIndex = 15
        Me.GREMARKS.Width = 250
        '
        'GGODOWN
        '
        Me.GGODOWN.Caption = "Godown"
        Me.GGODOWN.FieldName = "GODOWN"
        Me.GGODOWN.Name = "GGODOWN"
        Me.GGODOWN.OptionsColumn.AllowEdit = False
        '
        'GPROFORMANO
        '
        Me.GPROFORMANO.Caption = "Proforma No"
        Me.GPROFORMANO.FieldName = "PROFORMANO"
        Me.GPROFORMANO.Name = "GPROFORMANO"
        Me.GPROFORMANO.OptionsColumn.AllowEdit = False
        '
        'GDATE
        '
        Me.GDATE.Caption = "Date"
        Me.GDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GDATE.FieldName = "PROFORMADATE"
        Me.GDATE.Name = "GDATE"
        Me.GDATE.OptionsColumn.AllowEdit = False
        '
        'GJONO
        '
        Me.GJONO.Caption = "Jo No"
        Me.GJONO.FieldName = "JONO"
        Me.GJONO.Name = "GJONO"
        Me.GJONO.OptionsColumn.AllowEdit = False
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
        '
        'GJOTYPE
        '
        Me.GJOTYPE.Caption = "Jo Type"
        Me.GJOTYPE.FieldName = "JOTYPE"
        Me.GJOTYPE.Name = "GJOTYPE"
        Me.GJOTYPE.OptionsColumn.AllowEdit = False
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
        'GISSUENO
        '
        Me.GISSUENO.Caption = "Issue No"
        Me.GISSUENO.FieldName = "GRIDISSUESRNO"
        Me.GISSUENO.Name = "GISSUENO"
        Me.GISSUENO.OptionsColumn.AllowEdit = False
        '
        'GTOTALWASTAGE
        '
        Me.GTOTALWASTAGE.Caption = "Total Wastage"
        Me.GTOTALWASTAGE.FieldName = "TOTALWT"
        Me.GTOTALWASTAGE.Name = "GTOTALWASTAGE"
        Me.GTOTALWASTAGE.OptionsColumn.AllowEdit = False
        Me.GTOTALWASTAGE.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GTOTALWASTAGE.Width = 100
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
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.toolStripSeparator, Me.TOOLREFRESH, Me.TOOLEXCEL, Me.ToolStripSeparator1})
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
        'TOOLEXCEL
        '
        Me.TOOLEXCEL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TOOLEXCEL.Image = Global.ZALANI.My.Resources.Resources.Excel_icon
        Me.TOOLEXCEL.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLEXCEL.Name = "TOOLEXCEL"
        Me.TOOLEXCEL.Size = New System.Drawing.Size(23, 22)
        Me.TOOLEXCEL.Text = "&Print"
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
        'GGSMDETAILS
        '
        Me.GGSMDETAILS.Caption = "Gsm Details"
        Me.GGSMDETAILS.FieldName = "GSMDETAILS"
        Me.GGSMDETAILS.Name = "GGSMDETAILS"
        Me.GGSMDETAILS.OptionsColumn.AllowEdit = False
        Me.GGSMDETAILS.Visible = True
        Me.GGSMDETAILS.VisibleIndex = 8
        '
        'ProductionIssueGridDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1284, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "ProductionIssueGridDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Production Issue Grid Details"
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
    Friend WithEvents GTOTALWASTAGE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCUSTOMERNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmdexit As Button
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents toolStripSeparator As ToolStripSeparator
    Friend WithEvents TOOLREFRESH As ToolStripButton
    Friend WithEvents TOOLEXCEL As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents cmdok As Button
    Friend WithEvents GMILLWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGSMDETAILS As DevExpress.XtraGrid.Columns.GridColumn
End Class
