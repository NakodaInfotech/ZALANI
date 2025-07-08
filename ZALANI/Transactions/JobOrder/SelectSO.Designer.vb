<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectSO
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
        Me.CHKSELECTALL = New System.Windows.Forms.CheckBox()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCHK = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CHKEDIT = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GSRNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSOSRNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSOTYPE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSHIPTO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GITEM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPORTDISCHARGE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPORTLOADING = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GQTY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GUNIT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GAMT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPRONO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDES = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCIFFOB = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCURRENCY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GORDERNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPAYMENT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBANK = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGSM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGSMDETAILS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSIZE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GFOILQUALITY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GFOILGSM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPEGSM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GROLLDIAMETER = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCOREPIPEWIDTH = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPALLETIZED = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNARR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGRIDSRNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTYPE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGRIDDESC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.APPROXDATE = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.GSIZEDETAILS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CHKEDIT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.APPROXDATE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.APPROXDATE.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CHKSELECTALL)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 581)
        Me.BlendPanel1.TabIndex = 1
        '
        'CHKSELECTALL
        '
        Me.CHKSELECTALL.AutoSize = True
        Me.CHKSELECTALL.BackColor = System.Drawing.Color.Transparent
        Me.CHKSELECTALL.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKSELECTALL.ForeColor = System.Drawing.Color.Black
        Me.CHKSELECTALL.Location = New System.Drawing.Point(45, 12)
        Me.CHKSELECTALL.Name = "CHKSELECTALL"
        Me.CHKSELECTALL.Size = New System.Drawing.Size(77, 18)
        Me.CHKSELECTALL.TabIndex = 0
        Me.CHKSELECTALL.Text = "Select All"
        Me.CHKSELECTALL.UseVisualStyleBackColor = False
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(22, 33)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.CHKEDIT, Me.APPROXDATE})
        Me.gridbilldetails.Size = New System.Drawing.Size(1191, 493)
        Me.gridbilldetails.TabIndex = 1
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCHK, Me.GSRNO, Me.GSOSRNO, Me.GSOTYPE, Me.GDATE, Me.GNAME, Me.GSHIPTO, Me.GITEM, Me.GPORTDISCHARGE, Me.GPORTLOADING, Me.GQTY, Me.GUNIT, Me.GRATE, Me.GAMT, Me.GPRONO, Me.GDES, Me.GCIFFOB, Me.GCURRENCY, Me.GORDERNO, Me.GPAYMENT, Me.GBANK, Me.GGSM, Me.GGSMDETAILS, Me.GSIZE, Me.GSIZEDETAILS, Me.GFOILQUALITY, Me.GFOILGSM, Me.GPEGSM, Me.GROLLDIAMETER, Me.GCOREPIPEWIDTH, Me.GPALLETIZED, Me.GNARR, Me.GGRIDSRNO, Me.GTYPE, Me.GGRIDDESC})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridbill.OptionsCustomization.AllowColumnMoving = False
        Me.gridbill.OptionsCustomization.AllowGroup = False
        Me.gridbill.OptionsCustomization.AllowQuickHideColumns = False
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        Me.gridbill.OptionsView.ShowGroupPanel = False
        '
        'GCHK
        '
        Me.GCHK.ColumnEdit = Me.CHKEDIT
        Me.GCHK.FieldName = "CHK"
        Me.GCHK.Name = "GCHK"
        Me.GCHK.OptionsColumn.ShowCaption = False
        Me.GCHK.Visible = True
        Me.GCHK.VisibleIndex = 0
        Me.GCHK.Width = 30
        '
        'CHKEDIT
        '
        Me.CHKEDIT.AutoHeight = False
        Me.CHKEDIT.Name = "CHKEDIT"
        Me.CHKEDIT.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked
        '
        'GSRNO
        '
        Me.GSRNO.Caption = "SO. No"
        Me.GSRNO.FieldName = "SONO"
        Me.GSRNO.Name = "GSRNO"
        Me.GSRNO.OptionsColumn.AllowEdit = False
        Me.GSRNO.OptionsColumn.ReadOnly = True
        Me.GSRNO.Visible = True
        Me.GSRNO.VisibleIndex = 1
        '
        'GSOSRNO
        '
        Me.GSOSRNO.Caption = "So Sr No"
        Me.GSOSRNO.FieldName = "GRIDSRNO"
        Me.GSOSRNO.Name = "GSOSRNO"
        Me.GSOSRNO.OptionsColumn.AllowEdit = False
        Me.GSOSRNO.Visible = True
        Me.GSOSRNO.VisibleIndex = 2
        '
        'GSOTYPE
        '
        Me.GSOTYPE.Caption = "So Type"
        Me.GSOTYPE.FieldName = "TYPE"
        Me.GSOTYPE.Name = "GSOTYPE"
        Me.GSOTYPE.OptionsColumn.AllowEdit = False
        Me.GSOTYPE.Visible = True
        Me.GSOTYPE.VisibleIndex = 3
        Me.GSOTYPE.Width = 100
        '
        'GDATE
        '
        Me.GDATE.Caption = "Date"
        Me.GDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GDATE.FieldName = "DATE"
        Me.GDATE.Name = "GDATE"
        Me.GDATE.OptionsColumn.AllowEdit = False
        Me.GDATE.Visible = True
        Me.GDATE.VisibleIndex = 4
        '
        'GNAME
        '
        Me.GNAME.Caption = "Name"
        Me.GNAME.FieldName = "NAME"
        Me.GNAME.Name = "GNAME"
        Me.GNAME.OptionsColumn.AllowEdit = False
        Me.GNAME.OptionsColumn.ReadOnly = True
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 5
        Me.GNAME.Width = 250
        '
        'GSHIPTO
        '
        Me.GSHIPTO.Caption = "Ship to"
        Me.GSHIPTO.FieldName = "SHIPTO"
        Me.GSHIPTO.Name = "GSHIPTO"
        Me.GSHIPTO.OptionsColumn.AllowEdit = False
        Me.GSHIPTO.Width = 200
        '
        'GITEM
        '
        Me.GITEM.Caption = "Item Name"
        Me.GITEM.FieldName = "FINISHEDQUALITY"
        Me.GITEM.Name = "GITEM"
        Me.GITEM.OptionsColumn.AllowEdit = False
        Me.GITEM.OptionsColumn.ReadOnly = True
        Me.GITEM.Visible = True
        Me.GITEM.VisibleIndex = 6
        Me.GITEM.Width = 200
        '
        'GPORTDISCHARGE
        '
        Me.GPORTDISCHARGE.Caption = "Port Discharge"
        Me.GPORTDISCHARGE.FieldName = "PORTDISCHARGE"
        Me.GPORTDISCHARGE.Name = "GPORTDISCHARGE"
        Me.GPORTDISCHARGE.OptionsColumn.AllowEdit = False
        Me.GPORTDISCHARGE.OptionsColumn.ReadOnly = True
        Me.GPORTDISCHARGE.Width = 120
        '
        'GPORTLOADING
        '
        Me.GPORTLOADING.Caption = "Port Loading"
        Me.GPORTLOADING.FieldName = "PORTLOADING"
        Me.GPORTLOADING.Name = "GPORTLOADING"
        Me.GPORTLOADING.OptionsColumn.AllowEdit = False
        Me.GPORTLOADING.OptionsColumn.ReadOnly = True
        Me.GPORTLOADING.Width = 100
        '
        'GQTY
        '
        Me.GQTY.Caption = "Qty"
        Me.GQTY.DisplayFormat.FormatString = "0.00"
        Me.GQTY.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GQTY.FieldName = "QTY"
        Me.GQTY.Name = "GQTY"
        Me.GQTY.OptionsColumn.AllowEdit = False
        Me.GQTY.OptionsColumn.ReadOnly = True
        Me.GQTY.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GQTY.Visible = True
        Me.GQTY.VisibleIndex = 7
        Me.GQTY.Width = 60
        '
        'GUNIT
        '
        Me.GUNIT.Caption = "Unit"
        Me.GUNIT.FieldName = "UNIT"
        Me.GUNIT.Name = "GUNIT"
        Me.GUNIT.OptionsColumn.AllowEdit = False
        Me.GUNIT.Visible = True
        Me.GUNIT.VisibleIndex = 8
        '
        'GRATE
        '
        Me.GRATE.Caption = "Rate"
        Me.GRATE.DisplayFormat.FormatString = "0.00"
        Me.GRATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GRATE.FieldName = "RATE"
        Me.GRATE.Name = "GRATE"
        Me.GRATE.OptionsColumn.AllowEdit = False
        '
        'GAMT
        '
        Me.GAMT.Caption = "Amt"
        Me.GAMT.FieldName = "AMOUNT"
        Me.GAMT.Name = "GAMT"
        Me.GAMT.OptionsColumn.AllowEdit = False
        '
        'GPRONO
        '
        Me.GPRONO.Caption = "Proforma No"
        Me.GPRONO.FieldName = "PROFORMANO"
        Me.GPRONO.Name = "GPRONO"
        Me.GPRONO.OptionsColumn.AllowEdit = False
        Me.GPRONO.Visible = True
        Me.GPRONO.VisibleIndex = 20
        '
        'GDES
        '
        Me.GDES.Caption = "Destination"
        Me.GDES.FieldName = "DESTINATION"
        Me.GDES.Name = "GDES"
        Me.GDES.OptionsColumn.AllowEdit = False
        '
        'GCIFFOB
        '
        Me.GCIFFOB.Caption = "CIFFOB"
        Me.GCIFFOB.FieldName = "CIFFOB"
        Me.GCIFFOB.Name = "GCIFFOB"
        Me.GCIFFOB.OptionsColumn.AllowEdit = False
        '
        'GCURRENCY
        '
        Me.GCURRENCY.Caption = "Currency"
        Me.GCURRENCY.FieldName = "CURRENCY"
        Me.GCURRENCY.Name = "GCURRENCY"
        Me.GCURRENCY.OptionsColumn.AllowEdit = False
        '
        'GORDERNO
        '
        Me.GORDERNO.Caption = "Order Ref No"
        Me.GORDERNO.FieldName = "ORDERREFNO"
        Me.GORDERNO.Name = "GORDERNO"
        Me.GORDERNO.OptionsColumn.AllowEdit = False
        '
        'GPAYMENT
        '
        Me.GPAYMENT.Caption = "Payment Term"
        Me.GPAYMENT.FieldName = "PAYMENTTERM"
        Me.GPAYMENT.Name = "GPAYMENT"
        Me.GPAYMENT.OptionsColumn.AllowEdit = False
        '
        'GBANK
        '
        Me.GBANK.Caption = "Bank Details"
        Me.GBANK.FieldName = "BANKDETAILS"
        Me.GBANK.Name = "GBANK"
        Me.GBANK.OptionsColumn.AllowEdit = False
        '
        'GGSM
        '
        Me.GGSM.Caption = "GSM"
        Me.GGSM.FieldName = "GSM"
        Me.GGSM.Name = "GGSM"
        Me.GGSM.OptionsColumn.AllowEdit = False
        Me.GGSM.Visible = True
        Me.GGSM.VisibleIndex = 9
        '
        'GGSMDETAILS
        '
        Me.GGSMDETAILS.Caption = "Gsm Details"
        Me.GGSMDETAILS.FieldName = "GSMDETAILS"
        Me.GGSMDETAILS.Name = "GGSMDETAILS"
        Me.GGSMDETAILS.Visible = True
        Me.GGSMDETAILS.VisibleIndex = 10
        Me.GGSMDETAILS.Width = 100
        '
        'GSIZE
        '
        Me.GSIZE.Caption = "Size"
        Me.GSIZE.FieldName = "SIZE"
        Me.GSIZE.Name = "GSIZE"
        Me.GSIZE.OptionsColumn.AllowEdit = False
        Me.GSIZE.Visible = True
        Me.GSIZE.VisibleIndex = 11
        '
        'GFOILQUALITY
        '
        Me.GFOILQUALITY.Caption = "Foil Quality"
        Me.GFOILQUALITY.FieldName = "FOILQUALITY"
        Me.GFOILQUALITY.Name = "GFOILQUALITY"
        Me.GFOILQUALITY.OptionsColumn.AllowEdit = False
        Me.GFOILQUALITY.Visible = True
        Me.GFOILQUALITY.VisibleIndex = 13
        '
        'GFOILGSM
        '
        Me.GFOILGSM.Caption = "Foil Thickness"
        Me.GFOILGSM.FieldName = "FOILGSM"
        Me.GFOILGSM.Name = "GFOILGSM"
        Me.GFOILGSM.OptionsColumn.AllowEdit = False
        Me.GFOILGSM.Visible = True
        Me.GFOILGSM.VisibleIndex = 14
        '
        'GPEGSM
        '
        Me.GPEGSM.Caption = "PE GSM"
        Me.GPEGSM.FieldName = "PEGSM"
        Me.GPEGSM.Name = "GPEGSM"
        Me.GPEGSM.OptionsColumn.AllowEdit = False
        Me.GPEGSM.Visible = True
        Me.GPEGSM.VisibleIndex = 15
        '
        'GROLLDIAMETER
        '
        Me.GROLLDIAMETER.Caption = "Roll Diameter"
        Me.GROLLDIAMETER.FieldName = "ROLLDIAMETER"
        Me.GROLLDIAMETER.Name = "GROLLDIAMETER"
        Me.GROLLDIAMETER.OptionsColumn.AllowEdit = False
        Me.GROLLDIAMETER.Visible = True
        Me.GROLLDIAMETER.VisibleIndex = 16
        '
        'GCOREPIPEWIDTH
        '
        Me.GCOREPIPEWIDTH.Caption = "Core Pipe Width"
        Me.GCOREPIPEWIDTH.FieldName = "COREPIPEWIDTH"
        Me.GCOREPIPEWIDTH.Name = "GCOREPIPEWIDTH"
        Me.GCOREPIPEWIDTH.OptionsColumn.AllowEdit = False
        Me.GCOREPIPEWIDTH.Visible = True
        Me.GCOREPIPEWIDTH.VisibleIndex = 17
        '
        'GPALLETIZED
        '
        Me.GPALLETIZED.Caption = "Palletized"
        Me.GPALLETIZED.FieldName = "PALLETIZED"
        Me.GPALLETIZED.Name = "GPALLETIZED"
        Me.GPALLETIZED.OptionsColumn.AllowEdit = False
        Me.GPALLETIZED.Visible = True
        Me.GPALLETIZED.VisibleIndex = 18
        '
        'GNARR
        '
        Me.GNARR.Caption = "Narration"
        Me.GNARR.FieldName = "NARRATION"
        Me.GNARR.Name = "GNARR"
        Me.GNARR.OptionsColumn.AllowEdit = False
        '
        'GGRIDSRNO
        '
        Me.GGRIDSRNO.Caption = "Grid SrNo"
        Me.GGRIDSRNO.FieldName = "GRIDSRNO"
        Me.GGRIDSRNO.Name = "GGRIDSRNO"
        Me.GGRIDSRNO.OptionsColumn.AllowEdit = False
        Me.GGRIDSRNO.OptionsColumn.ReadOnly = True
        '
        'GTYPE
        '
        Me.GTYPE.Caption = "Type"
        Me.GTYPE.FieldName = "TYPE"
        Me.GTYPE.Name = "GTYPE"
        Me.GTYPE.OptionsColumn.AllowEdit = False
        Me.GTYPE.OptionsColumn.ReadOnly = True
        Me.GTYPE.Visible = True
        Me.GTYPE.VisibleIndex = 19
        '
        'GGRIDDESC
        '
        Me.GGRIDDESC.Caption = "Grid Desc"
        Me.GGRIDDESC.FieldName = "GRIDDESC"
        Me.GGRIDDESC.Name = "GGRIDDESC"
        Me.GGRIDDESC.OptionsColumn.AllowEdit = False
        '
        'APPROXDATE
        '
        Me.APPROXDATE.AutoHeight = False
        Me.APPROXDATE.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.APPROXDATE.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.APPROXDATE.Name = "APPROXDATE"
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(620, 529)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 3
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.Black
        Me.cmdok.Location = New System.Drawing.Point(534, 529)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 2
        Me.cmdok.Text = "&Ok"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'GSIZEDETAILS
        '
        Me.GSIZEDETAILS.Caption = "Size Details"
        Me.GSIZEDETAILS.FieldName = "SIZEDETAILS"
        Me.GSIZEDETAILS.Name = "GSIZEDETAILS"
        Me.GSIZEDETAILS.OptionsColumn.AllowEdit = False
        Me.GSIZEDETAILS.Visible = True
        Me.GSIZEDETAILS.VisibleIndex = 12
        Me.GSIZEDETAILS.Width = 100
        '
        'SelectSO
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "SelectSO"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Select SO"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CHKEDIT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.APPROXDATE.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.APPROXDATE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents CHKSELECTALL As CheckBox
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCHK As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CHKEDIT As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GSRNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSHIPTO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGRIDSRNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GITEM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPORTDISCHARGE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPORTLOADING As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GQTY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GUNIT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents APPROXDATE As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents cmdexit As Button
    Friend WithEvents cmdok As Button
    Friend WithEvents GAMT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPRONO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDES As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCIFFOB As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCURRENCY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GORDERNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPAYMENT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBANK As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGSM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSIZE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GFOILQUALITY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GFOILGSM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPEGSM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GROLLDIAMETER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCOREPIPEWIDTH As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPALLETIZED As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNARR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGRIDDESC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGSMDETAILS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSOSRNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSOTYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSIZEDETAILS As DevExpress.XtraGrid.Columns.GridColumn
End Class
