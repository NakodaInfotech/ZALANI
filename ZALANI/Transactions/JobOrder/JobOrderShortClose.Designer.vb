<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class JobOrderShortClose
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.LBLSLITTING = New System.Windows.Forms.Label()
        Me.LBLLAMINATION = New System.Windows.Forms.Label()
        Me.LBLPE = New System.Windows.Forms.Label()
        Me.CMDREFRESH = New System.Windows.Forms.Button()
        Me.RBENTERED = New System.Windows.Forms.RadioButton()
        Me.RBPENDING = New System.Windows.Forms.RadioButton()
        Me.CHKSELECTALL = New System.Windows.Forms.CheckBox()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GSONO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCLOSED = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGRIDSRNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGRADE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDESTINATION = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCIFFOB = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTYPE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCURRENCY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSHIPTO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GORDERREFNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPAYMENT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBANK = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREMARKS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGSM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSIZE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GFOILQUALITY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GFOILGSM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPEGSM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GROLLOD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GROLLID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPALLETIZED = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNARRATION = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GAMOUNT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGRIDDESC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GUNIT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPORTDISCHARGE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPORTLOADING = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPROFORMANO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.LBLSLITTING)
        Me.BlendPanel1.Controls.Add(Me.LBLLAMINATION)
        Me.BlendPanel1.Controls.Add(Me.LBLPE)
        Me.BlendPanel1.Controls.Add(Me.CMDREFRESH)
        Me.BlendPanel1.Controls.Add(Me.RBENTERED)
        Me.BlendPanel1.Controls.Add(Me.RBPENDING)
        Me.BlendPanel1.Controls.Add(Me.CHKSELECTALL)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 581)
        Me.BlendPanel1.TabIndex = 1
        '
        'LBLSLITTING
        '
        Me.LBLSLITTING.AutoSize = True
        Me.LBLSLITTING.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.LBLSLITTING.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLSLITTING.Location = New System.Drawing.Point(270, 29)
        Me.LBLSLITTING.Name = "LBLSLITTING"
        Me.LBLSLITTING.Size = New System.Drawing.Size(99, 19)
        Me.LBLSLITTING.TabIndex = 259
        Me.LBLSLITTING.Text = "CONVERSION"
        Me.LBLSLITTING.Visible = False
        '
        'LBLLAMINATION
        '
        Me.LBLLAMINATION.AutoSize = True
        Me.LBLLAMINATION.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.LBLLAMINATION.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLLAMINATION.Location = New System.Drawing.Point(272, 28)
        Me.LBLLAMINATION.Name = "LBLLAMINATION"
        Me.LBLLAMINATION.Size = New System.Drawing.Size(98, 19)
        Me.LBLLAMINATION.TabIndex = 258
        Me.LBLLAMINATION.Text = "LAMINATION"
        Me.LBLLAMINATION.Visible = False
        '
        'LBLPE
        '
        Me.LBLPE.AutoSize = True
        Me.LBLPE.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.LBLPE.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLPE.Location = New System.Drawing.Point(272, 29)
        Me.LBLPE.Name = "LBLPE"
        Me.LBLPE.Size = New System.Drawing.Size(87, 19)
        Me.LBLPE.TabIndex = 257
        Me.LBLPE.Text = "EXTRUSION"
        Me.LBLPE.Visible = False
        '
        'CMDREFRESH
        '
        Me.CMDREFRESH.BackColor = System.Drawing.Color.Transparent
        Me.CMDREFRESH.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDREFRESH.FlatAppearance.BorderSize = 0
        Me.CMDREFRESH.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDREFRESH.ForeColor = System.Drawing.Color.Black
        Me.CMDREFRESH.Location = New System.Drawing.Point(577, 541)
        Me.CMDREFRESH.Name = "CMDREFRESH"
        Me.CMDREFRESH.Size = New System.Drawing.Size(80, 28)
        Me.CMDREFRESH.TabIndex = 4
        Me.CMDREFRESH.Text = "&Refresh"
        Me.CMDREFRESH.UseVisualStyleBackColor = False
        '
        'RBENTERED
        '
        Me.RBENTERED.AutoSize = True
        Me.RBENTERED.BackColor = System.Drawing.Color.Transparent
        Me.RBENTERED.Location = New System.Drawing.Point(198, 29)
        Me.RBENTERED.Name = "RBENTERED"
        Me.RBENTERED.Size = New System.Drawing.Size(66, 19)
        Me.RBENTERED.TabIndex = 1
        Me.RBENTERED.Text = "Entered"
        Me.RBENTERED.UseVisualStyleBackColor = False
        '
        'RBPENDING
        '
        Me.RBPENDING.AutoSize = True
        Me.RBPENDING.BackColor = System.Drawing.Color.Transparent
        Me.RBPENDING.Checked = True
        Me.RBPENDING.Location = New System.Drawing.Point(123, 29)
        Me.RBPENDING.Name = "RBPENDING"
        Me.RBPENDING.Size = New System.Drawing.Size(69, 19)
        Me.RBPENDING.TabIndex = 0
        Me.RBPENDING.TabStop = True
        Me.RBPENDING.Text = "Pending"
        Me.RBPENDING.UseVisualStyleBackColor = False
        '
        'CHKSELECTALL
        '
        Me.CHKSELECTALL.AutoSize = True
        Me.CHKSELECTALL.BackColor = System.Drawing.Color.Transparent
        Me.CHKSELECTALL.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKSELECTALL.ForeColor = System.Drawing.Color.Black
        Me.CHKSELECTALL.Location = New System.Drawing.Point(15, 30)
        Me.CHKSELECTALL.Name = "CHKSELECTALL"
        Me.CHKSELECTALL.Size = New System.Drawing.Size(77, 18)
        Me.CHKSELECTALL.TabIndex = 2
        Me.CHKSELECTALL.Text = "Select All"
        Me.CHKSELECTALL.UseVisualStyleBackColor = False
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(15, 54)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(1207, 481)
        Me.gridbilldetails.TabIndex = 256
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GSONO, Me.GCLOSED, Me.GGRIDSRNO, Me.GDATE, Me.GNAME, Me.GGRADE, Me.GDESTINATION, Me.GCIFFOB, Me.GTYPE, Me.GCURRENCY, Me.GSHIPTO, Me.GORDERREFNO, Me.GPAYMENT, Me.GBANK, Me.GREMARKS, Me.GGSM, Me.GSIZE, Me.GFOILQUALITY, Me.GFOILGSM, Me.GPEGSM, Me.GROLLOD, Me.GROLLID, Me.GPALLETIZED, Me.GNARRATION, Me.GRATE, Me.GAMOUNT, Me.GGRIDDESC, Me.GUNIT, Me.GPORTDISCHARGE, Me.GPORTLOADING, Me.GPROFORMANO})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsCustomization.AllowGroup = False
        Me.gridbill.OptionsSelection.MultiSelect = True
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        Me.gridbill.OptionsView.ShowGroupPanel = False
        '
        'GSONO
        '
        Me.GSONO.Caption = "SO NO"
        Me.GSONO.FieldName = "JONO"
        Me.GSONO.Name = "GSONO"
        Me.GSONO.OptionsColumn.AllowEdit = False
        Me.GSONO.Visible = True
        Me.GSONO.VisibleIndex = 1
        '
        'GCLOSED
        '
        Me.GCLOSED.Caption = "Closed"
        Me.GCLOSED.FieldName = "CLOSED"
        Me.GCLOSED.Name = "GCLOSED"
        Me.GCLOSED.OptionsColumn.ShowCaption = False
        Me.GCLOSED.Visible = True
        Me.GCLOSED.VisibleIndex = 0
        Me.GCLOSED.Width = 50
        '
        'GGRIDSRNO
        '
        Me.GGRIDSRNO.Caption = "GRIDSRNO"
        Me.GGRIDSRNO.FieldName = "GRIDSRNO"
        Me.GGRIDSRNO.Name = "GGRIDSRNO"
        Me.GGRIDSRNO.OptionsColumn.AllowEdit = False
        '
        'GDATE
        '
        Me.GDATE.Caption = "Date"
        Me.GDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GDATE.FieldName = "PODATE"
        Me.GDATE.Name = "GDATE"
        Me.GDATE.OptionsColumn.AllowEdit = False
        Me.GDATE.Visible = True
        Me.GDATE.VisibleIndex = 2
        Me.GDATE.Width = 80
        '
        'GNAME
        '
        Me.GNAME.Caption = "Name"
        Me.GNAME.FieldName = "NAME"
        Me.GNAME.ImageIndex = 0
        Me.GNAME.Name = "GNAME"
        Me.GNAME.OptionsColumn.AllowEdit = False
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 3
        Me.GNAME.Width = 210
        '
        'GGRADE
        '
        Me.GGRADE.Caption = "Grade"
        Me.GGRADE.FieldName = "FINISHEDQUALITY"
        Me.GGRADE.Name = "GGRADE"
        Me.GGRADE.OptionsColumn.AllowEdit = False
        Me.GGRADE.Visible = True
        Me.GGRADE.VisibleIndex = 13
        '
        'GDESTINATION
        '
        Me.GDESTINATION.Caption = "Destination"
        Me.GDESTINATION.FieldName = "DESTINATION"
        Me.GDESTINATION.Name = "GDESTINATION"
        Me.GDESTINATION.OptionsColumn.AllowEdit = False
        Me.GDESTINATION.Visible = True
        Me.GDESTINATION.VisibleIndex = 4
        '
        'GCIFFOB
        '
        Me.GCIFFOB.Caption = "CIF/FOB"
        Me.GCIFFOB.FieldName = "CIFFOB"
        Me.GCIFFOB.Name = "GCIFFOB"
        Me.GCIFFOB.OptionsColumn.AllowEdit = False
        Me.GCIFFOB.Visible = True
        Me.GCIFFOB.VisibleIndex = 5
        '
        'GTYPE
        '
        Me.GTYPE.Caption = "Type"
        Me.GTYPE.FieldName = "TYPE"
        Me.GTYPE.Name = "GTYPE"
        Me.GTYPE.OptionsColumn.AllowEdit = False
        Me.GTYPE.Visible = True
        Me.GTYPE.VisibleIndex = 6
        '
        'GCURRENCY
        '
        Me.GCURRENCY.Caption = "Currency"
        Me.GCURRENCY.FieldName = "CURRENCY"
        Me.GCURRENCY.Name = "GCURRENCY"
        Me.GCURRENCY.OptionsColumn.AllowEdit = False
        Me.GCURRENCY.Visible = True
        Me.GCURRENCY.VisibleIndex = 7
        '
        'GSHIPTO
        '
        Me.GSHIPTO.Caption = "Ship To"
        Me.GSHIPTO.FieldName = "SHIPTO"
        Me.GSHIPTO.Name = "GSHIPTO"
        Me.GSHIPTO.OptionsColumn.AllowEdit = False
        Me.GSHIPTO.Visible = True
        Me.GSHIPTO.VisibleIndex = 8
        '
        'GORDERREFNO
        '
        Me.GORDERREFNO.Caption = "Order Ref No"
        Me.GORDERREFNO.FieldName = "ORDERREFNO"
        Me.GORDERREFNO.Name = "GORDERREFNO"
        Me.GORDERREFNO.OptionsColumn.AllowEdit = False
        Me.GORDERREFNO.Visible = True
        Me.GORDERREFNO.VisibleIndex = 9
        '
        'GPAYMENT
        '
        Me.GPAYMENT.Caption = "Payment TerM"
        Me.GPAYMENT.FieldName = "PAYMENTTERM"
        Me.GPAYMENT.Name = "GPAYMENT"
        Me.GPAYMENT.OptionsColumn.AllowEdit = False
        Me.GPAYMENT.Visible = True
        Me.GPAYMENT.VisibleIndex = 10
        '
        'GBANK
        '
        Me.GBANK.Caption = "Bank Deatils"
        Me.GBANK.FieldName = "BANKDETAILS"
        Me.GBANK.Name = "GBANK"
        Me.GBANK.OptionsColumn.AllowEdit = False
        Me.GBANK.Visible = True
        Me.GBANK.VisibleIndex = 11
        '
        'GREMARKS
        '
        Me.GREMARKS.Caption = "Remarks"
        Me.GREMARKS.FieldName = "REMARKS"
        Me.GREMARKS.Name = "GREMARKS"
        Me.GREMARKS.OptionsColumn.AllowEdit = False
        Me.GREMARKS.Visible = True
        Me.GREMARKS.VisibleIndex = 12
        '
        'GGSM
        '
        Me.GGSM.Caption = "GSM"
        Me.GGSM.FieldName = "GSM"
        Me.GGSM.Name = "GGSM"
        Me.GGSM.OptionsColumn.AllowEdit = False
        Me.GGSM.Visible = True
        Me.GGSM.VisibleIndex = 14
        '
        'GSIZE
        '
        Me.GSIZE.Caption = "Size"
        Me.GSIZE.FieldName = "SIZE"
        Me.GSIZE.Name = "GSIZE"
        Me.GSIZE.OptionsColumn.AllowEdit = False
        Me.GSIZE.Visible = True
        Me.GSIZE.VisibleIndex = 15
        '
        'GFOILQUALITY
        '
        Me.GFOILQUALITY.Caption = "Foil Quality"
        Me.GFOILQUALITY.FieldName = "FOILQUALITY"
        Me.GFOILQUALITY.Name = "GFOILQUALITY"
        Me.GFOILQUALITY.OptionsColumn.AllowEdit = False
        Me.GFOILQUALITY.Visible = True
        Me.GFOILQUALITY.VisibleIndex = 16
        '
        'GFOILGSM
        '
        Me.GFOILGSM.Caption = "Foil GSM"
        Me.GFOILGSM.FieldName = "FOILGSM"
        Me.GFOILGSM.Name = "GFOILGSM"
        Me.GFOILGSM.OptionsColumn.AllowEdit = False
        Me.GFOILGSM.Visible = True
        Me.GFOILGSM.VisibleIndex = 17
        '
        'GPEGSM
        '
        Me.GPEGSM.Caption = "Pegsm"
        Me.GPEGSM.FieldName = "PEGSM"
        Me.GPEGSM.Name = "GPEGSM"
        Me.GPEGSM.OptionsColumn.AllowEdit = False
        Me.GPEGSM.Visible = True
        Me.GPEGSM.VisibleIndex = 18
        '
        'GROLLOD
        '
        Me.GROLLOD.Caption = "Roll OD"
        Me.GROLLOD.FieldName = "ROLLDIAMETER"
        Me.GROLLOD.Name = "GROLLOD"
        Me.GROLLOD.OptionsColumn.AllowEdit = False
        Me.GROLLOD.Visible = True
        Me.GROLLOD.VisibleIndex = 19
        '
        'GROLLID
        '
        Me.GROLLID.Caption = "Roll ID"
        Me.GROLLID.FieldName = "COREPIPEWIDTH"
        Me.GROLLID.Name = "GROLLID"
        Me.GROLLID.OptionsColumn.AllowEdit = False
        Me.GROLLID.Visible = True
        Me.GROLLID.VisibleIndex = 20
        '
        'GPALLETIZED
        '
        Me.GPALLETIZED.Caption = "Palletized"
        Me.GPALLETIZED.FieldName = "PALLETIZED"
        Me.GPALLETIZED.Name = "GPALLETIZED"
        Me.GPALLETIZED.OptionsColumn.AllowEdit = False
        Me.GPALLETIZED.Visible = True
        Me.GPALLETIZED.VisibleIndex = 21
        '
        'GNARRATION
        '
        Me.GNARRATION.Caption = "Narration"
        Me.GNARRATION.FieldName = "NARRATION"
        Me.GNARRATION.Name = "GNARRATION"
        Me.GNARRATION.OptionsColumn.AllowEdit = False
        Me.GNARRATION.Visible = True
        Me.GNARRATION.VisibleIndex = 22
        '
        'GRATE
        '
        Me.GRATE.Caption = "Rate"
        Me.GRATE.FieldName = "RATE"
        Me.GRATE.Name = "GRATE"
        Me.GRATE.OptionsColumn.AllowEdit = False
        Me.GRATE.Visible = True
        Me.GRATE.VisibleIndex = 23
        '
        'GAMOUNT
        '
        Me.GAMOUNT.Caption = "Amount"
        Me.GAMOUNT.FieldName = "AMOUNT"
        Me.GAMOUNT.Name = "GAMOUNT"
        Me.GAMOUNT.OptionsColumn.AllowEdit = False
        Me.GAMOUNT.Visible = True
        Me.GAMOUNT.VisibleIndex = 24
        '
        'GGRIDDESC
        '
        Me.GGRIDDESC.Caption = "Grid Desc"
        Me.GGRIDDESC.FieldName = "GRIDDESC"
        Me.GGRIDDESC.Name = "GGRIDDESC"
        Me.GGRIDDESC.OptionsColumn.AllowEdit = False
        Me.GGRIDDESC.Visible = True
        Me.GGRIDDESC.VisibleIndex = 25
        '
        'GUNIT
        '
        Me.GUNIT.Caption = "Unit"
        Me.GUNIT.FieldName = "UNIT"
        Me.GUNIT.Name = "GUNIT"
        Me.GUNIT.OptionsColumn.AllowEdit = False
        Me.GUNIT.Visible = True
        Me.GUNIT.VisibleIndex = 26
        '
        'GPORTDISCHARGE
        '
        Me.GPORTDISCHARGE.Caption = "Port Discharge"
        Me.GPORTDISCHARGE.FieldName = "PORTDISCHARGE"
        Me.GPORTDISCHARGE.Name = "GPORTDISCHARGE"
        Me.GPORTDISCHARGE.OptionsColumn.AllowEdit = False
        Me.GPORTDISCHARGE.Visible = True
        Me.GPORTDISCHARGE.VisibleIndex = 27
        '
        'GPORTLOADING
        '
        Me.GPORTLOADING.Caption = "Port Loading"
        Me.GPORTLOADING.FieldName = "PORTLOADING"
        Me.GPORTLOADING.Name = "GPORTLOADING"
        Me.GPORTLOADING.OptionsColumn.AllowEdit = False
        Me.GPORTLOADING.Visible = True
        Me.GPORTLOADING.VisibleIndex = 28
        '
        'GPROFORMANO
        '
        Me.GPROFORMANO.Caption = "Proforma No"
        Me.GPROFORMANO.FieldName = "PROFORMANO"
        Me.GPROFORMANO.Name = "GPROFORMANO"
        Me.GPROFORMANO.OptionsColumn.AllowEdit = False
        Me.GPROFORMANO.Visible = True
        Me.GPROFORMANO.VisibleIndex = 29
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(663, 541)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 5
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripSeparator, Me.PrintToolStripButton})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1234, 25)
        Me.ToolStrip1.TabIndex = 255
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'PrintToolStripButton
        '
        Me.PrintToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PrintToolStripButton.Image = Global.ZALANI.My.Resources.Resources.Excel_icon
        Me.PrintToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PrintToolStripButton.Name = "PrintToolStripButton"
        Me.PrintToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PrintToolStripButton.Text = "&Print"
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.Black
        Me.cmdok.Location = New System.Drawing.Point(491, 541)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 3
        Me.cmdok.Text = "&Save"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'JobOrderShortClose
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "JobOrderShortClose"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Job Order Short Close"
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
    Friend WithEvents CMDREFRESH As Button
    Friend WithEvents RBENTERED As RadioButton
    Friend WithEvents RBPENDING As RadioButton
    Friend WithEvents CHKSELECTALL As CheckBox
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCLOSED As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGRIDSRNO As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents GDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmdexit As Button
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents toolStripSeparator As ToolStripSeparator
    Friend WithEvents PrintToolStripButton As ToolStripButton
    Friend WithEvents cmdok As Button
    Friend WithEvents GSONO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDESTINATION As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCIFFOB As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCURRENCY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSHIPTO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GORDERREFNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPAYMENT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBANK As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREMARKS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGRADE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGSM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSIZE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GFOILQUALITY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GFOILGSM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPEGSM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GROLLOD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GROLLID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPALLETIZED As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNARRATION As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GAMOUNT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGRIDDESC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GUNIT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPORTDISCHARGE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPORTLOADING As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPROFORMANO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LBLPE As Label
    Friend WithEvents LBLSLITTING As Label
    Friend WithEvents LBLLAMINATION As Label
End Class
