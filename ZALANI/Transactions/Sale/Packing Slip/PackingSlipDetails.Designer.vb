<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PackingSlipDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PackingSlipDetails))
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.TXTFROM = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TXTCOPIES = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TXTTO = New System.Windows.Forms.TextBox()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gsrno = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPSDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSHIPTO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPORTOFDISCHARGE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPORTOFLOADING = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDESTINATION = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCURRENCY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCIFFOB = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCONTAINERNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GVEHICLENO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTRANSPORTNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALPALLETTEWT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPROFORMANO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GORDERREFNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGRADE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDESC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GROLLNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGSM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSIZE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GFINALWT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GWT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GROLLOD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GROLLID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GJOINT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMTRS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GUNIT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNARRATION = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREMARKS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBARCODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGODOWN = New DevExpress.XtraGrid.Columns.GridColumn()
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
        Me.lbl = New System.Windows.Forms.Label()
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
        Me.BlendPanel1.Controls.Add(Me.TXTFROM)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.TXTCOPIES)
        Me.BlendPanel1.Controls.Add(Me.Label9)
        Me.BlendPanel1.Controls.Add(Me.Label10)
        Me.BlendPanel1.Controls.Add(Me.TXTTO)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Controls.Add(Me.lbl)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 581)
        Me.BlendPanel1.TabIndex = 5
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
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(14, 52)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(1235, 478)
        Me.gridbilldetails.TabIndex = 1
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gsrno, Me.GPSDATE, Me.GNAME, Me.GSHIPTO, Me.GPORTOFDISCHARGE, Me.GPORTOFLOADING, Me.GDESTINATION, Me.GCURRENCY, Me.GCIFFOB, Me.GCONTAINERNO, Me.GVEHICLENO, Me.GTRANSPORTNAME, Me.GTOTALPALLETTEWT, Me.GPROFORMANO, Me.GORDERREFNO, Me.GGRADE, Me.GDESC, Me.GRATE, Me.GROLLNO, Me.GGSM, Me.GSIZE, Me.GFINALWT, Me.GWT, Me.GROLLOD, Me.GROLLID, Me.GJOINT, Me.GMTRS, Me.GUNIT, Me.GNARRATION, Me.GREMARKS, Me.GBARCODE, Me.GGODOWN})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.Editable = False
        Me.gridbill.OptionsSelection.CheckBoxSelectorColumnWidth = 30
        Me.gridbill.OptionsSelection.MultiSelect = True
        Me.gridbill.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        '
        'gsrno
        '
        Me.gsrno.Caption = "Sr. No"
        Me.gsrno.FieldName = "TEMPPSNO"
        Me.gsrno.Name = "gsrno"
        Me.gsrno.OptionsColumn.AllowEdit = False
        Me.gsrno.Visible = True
        Me.gsrno.VisibleIndex = 1
        Me.gsrno.Width = 40
        '
        'GPSDATE
        '
        Me.GPSDATE.Caption = "Date"
        Me.GPSDATE.FieldName = "DATE"
        Me.GPSDATE.Name = "GPSDATE"
        Me.GPSDATE.OptionsColumn.AllowEdit = False
        Me.GPSDATE.Visible = True
        Me.GPSDATE.VisibleIndex = 2
        '
        'GNAME
        '
        Me.GNAME.Caption = "Name"
        Me.GNAME.FieldName = "NAME"
        Me.GNAME.Name = "GNAME"
        Me.GNAME.OptionsColumn.AllowEdit = False
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 3
        Me.GNAME.Width = 200
        '
        'GSHIPTO
        '
        Me.GSHIPTO.Caption = "Ship To"
        Me.GSHIPTO.FieldName = "SHIPTO"
        Me.GSHIPTO.Name = "GSHIPTO"
        Me.GSHIPTO.OptionsColumn.AllowEdit = False
        Me.GSHIPTO.Visible = True
        Me.GSHIPTO.VisibleIndex = 4
        Me.GSHIPTO.Width = 200
        '
        'GPORTOFDISCHARGE
        '
        Me.GPORTOFDISCHARGE.Caption = "Port Of Discharge"
        Me.GPORTOFDISCHARGE.FieldName = "PORTDISCHARGE"
        Me.GPORTOFDISCHARGE.ImageIndex = 0
        Me.GPORTOFDISCHARGE.Name = "GPORTOFDISCHARGE"
        Me.GPORTOFDISCHARGE.OptionsColumn.AllowEdit = False
        Me.GPORTOFDISCHARGE.Visible = True
        Me.GPORTOFDISCHARGE.VisibleIndex = 5
        Me.GPORTOFDISCHARGE.Width = 100
        '
        'GPORTOFLOADING
        '
        Me.GPORTOFLOADING.Caption = "Port Of Loading"
        Me.GPORTOFLOADING.FieldName = "PORTLOADING"
        Me.GPORTOFLOADING.Name = "GPORTOFLOADING"
        Me.GPORTOFLOADING.OptionsColumn.AllowEdit = False
        Me.GPORTOFLOADING.Visible = True
        Me.GPORTOFLOADING.VisibleIndex = 6
        Me.GPORTOFLOADING.Width = 100
        '
        'GDESTINATION
        '
        Me.GDESTINATION.Caption = "Destination"
        Me.GDESTINATION.FieldName = "DESTINATION"
        Me.GDESTINATION.Name = "GDESTINATION"
        Me.GDESTINATION.OptionsColumn.AllowEdit = False
        Me.GDESTINATION.Visible = True
        Me.GDESTINATION.VisibleIndex = 7
        Me.GDESTINATION.Width = 100
        '
        'GCURRENCY
        '
        Me.GCURRENCY.Caption = "Currency"
        Me.GCURRENCY.FieldName = "CURRENCY"
        Me.GCURRENCY.Name = "GCURRENCY"
        Me.GCURRENCY.OptionsColumn.AllowEdit = False
        Me.GCURRENCY.Visible = True
        Me.GCURRENCY.VisibleIndex = 8
        Me.GCURRENCY.Width = 70
        '
        'GCIFFOB
        '
        Me.GCIFFOB.Caption = "CIF/FOB"
        Me.GCIFFOB.FieldName = "CIFOB"
        Me.GCIFFOB.Name = "GCIFFOB"
        Me.GCIFFOB.OptionsColumn.AllowEdit = False
        Me.GCIFFOB.Visible = True
        Me.GCIFFOB.VisibleIndex = 9
        Me.GCIFFOB.Width = 100
        '
        'GCONTAINERNO
        '
        Me.GCONTAINERNO.Caption = "Container No"
        Me.GCONTAINERNO.FieldName = "CONTAINER"
        Me.GCONTAINERNO.Name = "GCONTAINERNO"
        Me.GCONTAINERNO.OptionsColumn.AllowEdit = False
        Me.GCONTAINERNO.Visible = True
        Me.GCONTAINERNO.VisibleIndex = 10
        Me.GCONTAINERNO.Width = 100
        '
        'GVEHICLENO
        '
        Me.GVEHICLENO.Caption = "Vehicle No"
        Me.GVEHICLENO.FieldName = "VEHICLENO"
        Me.GVEHICLENO.Name = "GVEHICLENO"
        Me.GVEHICLENO.OptionsColumn.AllowEdit = False
        Me.GVEHICLENO.Visible = True
        Me.GVEHICLENO.VisibleIndex = 11
        Me.GVEHICLENO.Width = 100
        '
        'GTRANSPORTNAME
        '
        Me.GTRANSPORTNAME.Caption = "Transport Name"
        Me.GTRANSPORTNAME.FieldName = "TRANSPORTNAME"
        Me.GTRANSPORTNAME.Name = "GTRANSPORTNAME"
        Me.GTRANSPORTNAME.OptionsColumn.AllowEdit = False
        Me.GTRANSPORTNAME.Visible = True
        Me.GTRANSPORTNAME.VisibleIndex = 12
        Me.GTRANSPORTNAME.Width = 200
        '
        'GTOTALPALLETTEWT
        '
        Me.GTOTALPALLETTEWT.Caption = "Total Pallette WT"
        Me.GTOTALPALLETTEWT.FieldName = "TOTALPALLETTEWT"
        Me.GTOTALPALLETTEWT.Name = "GTOTALPALLETTEWT"
        Me.GTOTALPALLETTEWT.OptionsColumn.AllowEdit = False
        Me.GTOTALPALLETTEWT.Visible = True
        Me.GTOTALPALLETTEWT.VisibleIndex = 13
        Me.GTOTALPALLETTEWT.Width = 100
        '
        'GPROFORMANO
        '
        Me.GPROFORMANO.Caption = "Proforma No"
        Me.GPROFORMANO.FieldName = "PROFORMANO"
        Me.GPROFORMANO.Name = "GPROFORMANO"
        Me.GPROFORMANO.OptionsColumn.AllowEdit = False
        Me.GPROFORMANO.Visible = True
        Me.GPROFORMANO.VisibleIndex = 14
        Me.GPROFORMANO.Width = 100
        '
        'GORDERREFNO
        '
        Me.GORDERREFNO.Caption = "Order Refno"
        Me.GORDERREFNO.FieldName = "ORDERREFNO"
        Me.GORDERREFNO.Name = "GORDERREFNO"
        Me.GORDERREFNO.OptionsColumn.AllowEdit = False
        Me.GORDERREFNO.Visible = True
        Me.GORDERREFNO.VisibleIndex = 15
        Me.GORDERREFNO.Width = 100
        '
        'GGRADE
        '
        Me.GGRADE.Caption = "Grade"
        Me.GGRADE.FieldName = "FINISHEDQUALITY"
        Me.GGRADE.Name = "GGRADE"
        Me.GGRADE.OptionsColumn.AllowEdit = False
        Me.GGRADE.Visible = True
        Me.GGRADE.VisibleIndex = 16
        Me.GGRADE.Width = 125
        '
        'GDESC
        '
        Me.GDESC.Caption = "Desc"
        Me.GDESC.FieldName = "GRIDDESC"
        Me.GDESC.Name = "GDESC"
        Me.GDESC.OptionsColumn.AllowEdit = False
        Me.GDESC.Visible = True
        Me.GDESC.VisibleIndex = 17
        Me.GDESC.Width = 90
        '
        'GRATE
        '
        Me.GRATE.Caption = "Rate"
        Me.GRATE.FieldName = "RATE"
        Me.GRATE.Name = "GRATE"
        Me.GRATE.OptionsColumn.AllowEdit = False
        Me.GRATE.Visible = True
        Me.GRATE.VisibleIndex = 18
        '
        'GROLLNO
        '
        Me.GROLLNO.Caption = "Roll No"
        Me.GROLLNO.FieldName = "ROLLNO"
        Me.GROLLNO.Name = "GROLLNO"
        Me.GROLLNO.OptionsColumn.AllowEdit = False
        Me.GROLLNO.Visible = True
        Me.GROLLNO.VisibleIndex = 19
        '
        'GGSM
        '
        Me.GGSM.Caption = "GSM"
        Me.GGSM.FieldName = "GSM"
        Me.GGSM.Name = "GGSM"
        Me.GGSM.OptionsColumn.AllowEdit = False
        Me.GGSM.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GGSM.Visible = True
        Me.GGSM.VisibleIndex = 20
        '
        'GSIZE
        '
        Me.GSIZE.Caption = "Size"
        Me.GSIZE.DisplayFormat.FormatString = "0.00"
        Me.GSIZE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GSIZE.FieldName = "SIZE"
        Me.GSIZE.Name = "GSIZE"
        Me.GSIZE.OptionsColumn.AllowEdit = False
        Me.GSIZE.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GSIZE.Visible = True
        Me.GSIZE.VisibleIndex = 21
        '
        'GFINALWT
        '
        Me.GFINALWT.Caption = "Final WT"
        Me.GFINALWT.FieldName = "FINALWT"
        Me.GFINALWT.Name = "GFINALWT"
        Me.GFINALWT.OptionsColumn.AllowEdit = False
        Me.GFINALWT.Visible = True
        Me.GFINALWT.VisibleIndex = 22
        '
        'GWT
        '
        Me.GWT.Caption = "WT"
        Me.GWT.FieldName = "WT"
        Me.GWT.Name = "GWT"
        Me.GWT.OptionsColumn.AllowEdit = False
        Me.GWT.Visible = True
        Me.GWT.VisibleIndex = 23
        '
        'GROLLOD
        '
        Me.GROLLOD.Caption = "Roll OD"
        Me.GROLLOD.FieldName = "ROLLDIAMETER"
        Me.GROLLOD.Name = "GROLLOD"
        Me.GROLLOD.OptionsColumn.AllowEdit = False
        Me.GROLLOD.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GROLLOD.Visible = True
        Me.GROLLOD.VisibleIndex = 24
        Me.GROLLOD.Width = 100
        '
        'GROLLID
        '
        Me.GROLLID.Caption = "Roll ID"
        Me.GROLLID.FieldName = "COREPIPEWIDTH"
        Me.GROLLID.Name = "GROLLID"
        Me.GROLLID.OptionsColumn.AllowEdit = False
        Me.GROLLID.Visible = True
        Me.GROLLID.VisibleIndex = 25
        Me.GROLLID.Width = 100
        '
        'GJOINT
        '
        Me.GJOINT.Caption = "Joint"
        Me.GJOINT.FieldName = "JOINT"
        Me.GJOINT.Name = "GJOINT"
        Me.GJOINT.OptionsColumn.AllowEdit = False
        Me.GJOINT.Visible = True
        Me.GJOINT.VisibleIndex = 26
        '
        'GMTRS
        '
        Me.GMTRS.Caption = "Mtrs"
        Me.GMTRS.FieldName = "MTRS"
        Me.GMTRS.Name = "GMTRS"
        Me.GMTRS.OptionsColumn.AllowEdit = False
        Me.GMTRS.Visible = True
        Me.GMTRS.VisibleIndex = 27
        '
        'GUNIT
        '
        Me.GUNIT.Caption = "Unit"
        Me.GUNIT.DisplayFormat.FormatString = "0.00"
        Me.GUNIT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GUNIT.FieldName = "UNIT"
        Me.GUNIT.Name = "GUNIT"
        Me.GUNIT.OptionsColumn.AllowEdit = False
        Me.GUNIT.Visible = True
        Me.GUNIT.VisibleIndex = 28
        Me.GUNIT.Width = 80
        '
        'GNARRATION
        '
        Me.GNARRATION.Caption = "Narration"
        Me.GNARRATION.FieldName = "NARRATION"
        Me.GNARRATION.Name = "GNARRATION"
        Me.GNARRATION.OptionsColumn.AllowEdit = False
        Me.GNARRATION.Visible = True
        Me.GNARRATION.VisibleIndex = 29
        Me.GNARRATION.Width = 100
        '
        'GREMARKS
        '
        Me.GREMARKS.Caption = "Remarks"
        Me.GREMARKS.FieldName = "REMARKS"
        Me.GREMARKS.Name = "GREMARKS"
        Me.GREMARKS.OptionsColumn.AllowEdit = False
        Me.GREMARKS.Visible = True
        Me.GREMARKS.VisibleIndex = 30
        Me.GREMARKS.Width = 200
        '
        'GBARCODE
        '
        Me.GBARCODE.Caption = "Barcode"
        Me.GBARCODE.FieldName = "BARCODE"
        Me.GBARCODE.Name = "GBARCODE"
        Me.GBARCODE.OptionsColumn.AllowEdit = False
        Me.GBARCODE.Visible = True
        Me.GBARCODE.VisibleIndex = 31
        Me.GBARCODE.Width = 100
        '
        'GGODOWN
        '
        Me.GGODOWN.Caption = "Godown"
        Me.GGODOWN.FieldName = "GODOWN"
        Me.GGODOWN.Name = "GGODOWN"
        Me.GGODOWN.OptionsColumn.AllowEdit = False
        Me.GGODOWN.Visible = True
        Me.GGODOWN.VisibleIndex = 32
        Me.GGODOWN.Width = 100
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(664, 536)
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
        Me.ToolStrip1.Size = New System.Drawing.Size(1234, 25)
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
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl.Location = New System.Drawing.Point(19, 34)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(143, 14)
        Me.lbl.TabIndex = 251
        Me.lbl.Text = "Select an Entry to Change"
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.Black
        Me.cmdok.Location = New System.Drawing.Point(576, 536)
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
        'PackingSlipDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.KeyPreview = True
        Me.Name = "PackingSlipDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "PackingSlipDetails"
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
    Friend WithEvents TXTFROM As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TXTCOPIES As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents TXTTO As TextBox
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents gsrno As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGRADE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPORTOFDISCHARGE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPORTOFLOADING As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDESTINATION As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCIFFOB As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCURRENCY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSHIPTO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GORDERREFNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPROFORMANO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDESC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGSM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSIZE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GROLLOD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GROLLID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNARRATION As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GUNIT As DevExpress.XtraGrid.Columns.GridColumn
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
    Friend WithEvents lbl As Label
    Friend WithEvents cmdok As Button
    Friend WithEvents GBARCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCONTAINERNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GVEHICLENO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTRANSPORTNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALPALLETTEWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGODOWN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPSDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GROLLNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GFINALWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GWT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GJOINT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMTRS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREMARKS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PRINTDIALOG As PrintDialog
    Friend WithEvents PRINTDOC As Printing.PrintDocument
End Class
