<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SelectIssue
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
        Me.CHKSELECTALL = New System.Windows.Forms.CheckBox()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCHK = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CHKEDIT = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GISSUENO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GROLLNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGSM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGSMDETAILS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSIZE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMILLQTY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GOURQTY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GJOSRNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GJOTYPE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GJONO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GJODATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPROFORMANO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSONO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSODATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSOTYPE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GFINALQUALITY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMACHINENO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGRIDISSUERNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GQUALITY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GLOTNO = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDIFF = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GUNIT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGODOWN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.APPROXDATE = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.cmdok = New System.Windows.Forms.Button()
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
        Me.BlendPanel1.Size = New System.Drawing.Size(1247, 577)
        Me.BlendPanel1.TabIndex = 5
        '
        'CHKSELECTALL
        '
        Me.CHKSELECTALL.AutoSize = True
        Me.CHKSELECTALL.BackColor = System.Drawing.Color.Transparent
        Me.CHKSELECTALL.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKSELECTALL.ForeColor = System.Drawing.Color.Black
        Me.CHKSELECTALL.Location = New System.Drawing.Point(36, 14)
        Me.CHKSELECTALL.Name = "CHKSELECTALL"
        Me.CHKSELECTALL.Size = New System.Drawing.Size(15, 14)
        Me.CHKSELECTALL.TabIndex = 11
        Me.CHKSELECTALL.UseVisualStyleBackColor = False
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(12, 12)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.CHKEDIT, Me.APPROXDATE})
        Me.gridbilldetails.Size = New System.Drawing.Size(1223, 519)
        Me.gridbilldetails.TabIndex = 10
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCHK, Me.GISSUENO, Me.GROLLNO, Me.GGSM, Me.GGSMDETAILS, Me.GSIZE, Me.GMILLQTY, Me.GOURQTY, Me.GDATE, Me.GJOSRNO, Me.GJOTYPE, Me.GJONO, Me.GJODATE, Me.GNAME, Me.GPROFORMANO, Me.GSONO, Me.GSODATE, Me.GSOTYPE, Me.GFINALQUALITY, Me.GMACHINENO, Me.GGRIDISSUERNO, Me.GQUALITY, Me.GLOTNO, Me.GDIFF, Me.GUNIT, Me.GGODOWN})
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
        'GISSUENO
        '
        Me.GISSUENO.Caption = "Issue No"
        Me.GISSUENO.FieldName = "ISSUENO"
        Me.GISSUENO.Name = "GISSUENO"
        Me.GISSUENO.OptionsColumn.AllowEdit = False
        Me.GISSUENO.OptionsColumn.ReadOnly = True
        Me.GISSUENO.Visible = True
        Me.GISSUENO.VisibleIndex = 1
        Me.GISSUENO.Width = 50
        '
        'GROLLNO
        '
        Me.GROLLNO.Caption = "Roll No"
        Me.GROLLNO.FieldName = "ROLLNO"
        Me.GROLLNO.Name = "GROLLNO"
        Me.GROLLNO.OptionsColumn.AllowEdit = False
        Me.GROLLNO.Visible = True
        Me.GROLLNO.VisibleIndex = 2
        Me.GROLLNO.Width = 90
        '
        'GGSM
        '
        Me.GGSM.Caption = "GSM"
        Me.GGSM.FieldName = "GSM"
        Me.GGSM.Name = "GGSM"
        Me.GGSM.OptionsColumn.AllowEdit = False
        Me.GGSM.Visible = True
        Me.GGSM.VisibleIndex = 4
        Me.GGSM.Width = 70
        '
        'GGSMDETAILS
        '
        Me.GGSMDETAILS.Caption = "Gsm Details"
        Me.GGSMDETAILS.FieldName = "GSMDETAILS"
        Me.GGSMDETAILS.Name = "GGSMDETAILS"
        Me.GGSMDETAILS.Visible = True
        Me.GGSMDETAILS.VisibleIndex = 3
        Me.GGSMDETAILS.Width = 70
        '
        'GSIZE
        '
        Me.GSIZE.Caption = "Size"
        Me.GSIZE.FieldName = "SIZE"
        Me.GSIZE.Name = "GSIZE"
        Me.GSIZE.OptionsColumn.AllowEdit = False
        Me.GSIZE.Visible = True
        Me.GSIZE.VisibleIndex = 5
        Me.GSIZE.Width = 70
        '
        'GMILLQTY
        '
        Me.GMILLQTY.Caption = "Mill Qty"
        Me.GMILLQTY.FieldName = "MILLQTY"
        Me.GMILLQTY.Name = "GMILLQTY"
        Me.GMILLQTY.OptionsColumn.AllowEdit = False
        Me.GMILLQTY.Visible = True
        Me.GMILLQTY.VisibleIndex = 6
        Me.GMILLQTY.Width = 50
        '
        'GOURQTY
        '
        Me.GOURQTY.Caption = "Our Qty"
        Me.GOURQTY.FieldName = "OURQTY"
        Me.GOURQTY.Name = "GOURQTY"
        Me.GOURQTY.OptionsColumn.AllowEdit = False
        Me.GOURQTY.Visible = True
        Me.GOURQTY.VisibleIndex = 7
        Me.GOURQTY.Width = 50
        '
        'GDATE
        '
        Me.GDATE.Caption = " ISSUE DATE"
        Me.GDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GDATE.FieldName = "DATE"
        Me.GDATE.Name = "GDATE"
        Me.GDATE.OptionsColumn.AllowEdit = False
        '
        'GJOSRNO
        '
        Me.GJOSRNO.Caption = "JOSRNO"
        Me.GJOSRNO.FieldName = "JOSRNO"
        Me.GJOSRNO.Name = "GJOSRNO"
        Me.GJOSRNO.OptionsColumn.AllowEdit = False
        '
        'GJOTYPE
        '
        Me.GJOTYPE.Caption = "JO Type"
        Me.GJOTYPE.FieldName = "JOTYPE"
        Me.GJOTYPE.Name = "GJOTYPE"
        Me.GJOTYPE.OptionsColumn.AllowEdit = False
        '
        'GJONO
        '
        Me.GJONO.Caption = "JONO"
        Me.GJONO.FieldName = "JONO"
        Me.GJONO.Name = "GJONO"
        Me.GJONO.OptionsColumn.AllowEdit = False
        '
        'GJODATE
        '
        Me.GJODATE.Caption = "JODATE"
        Me.GJODATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GJODATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GJODATE.FieldName = "JODATE"
        Me.GJODATE.Name = "GJODATE"
        Me.GJODATE.OptionsColumn.AllowEdit = False
        '
        'GNAME
        '
        Me.GNAME.Caption = "Party Name"
        Me.GNAME.FieldName = "NAME"
        Me.GNAME.Name = "GNAME"
        Me.GNAME.OptionsColumn.AllowEdit = False
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 8
        Me.GNAME.Width = 200
        '
        'GPROFORMANO
        '
        Me.GPROFORMANO.Caption = "Proforma No"
        Me.GPROFORMANO.FieldName = "PROFORMANO"
        Me.GPROFORMANO.Name = "GPROFORMANO"
        Me.GPROFORMANO.OptionsColumn.AllowEdit = False
        '
        'GSONO
        '
        Me.GSONO.Caption = "SONO"
        Me.GSONO.FieldName = "SONO"
        Me.GSONO.Name = "GSONO"
        Me.GSONO.OptionsColumn.AllowEdit = False
        Me.GSONO.OptionsColumn.ReadOnly = True
        '
        'GSODATE
        '
        Me.GSODATE.Caption = "SO Date"
        Me.GSODATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GSODATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GSODATE.FieldName = "SODATE"
        Me.GSODATE.Name = "GSODATE"
        Me.GSODATE.OptionsColumn.AllowEdit = False
        '
        'GSOTYPE
        '
        Me.GSOTYPE.Caption = "SO Type"
        Me.GSOTYPE.FieldName = "SOTYPE"
        Me.GSOTYPE.Name = "GSOTYPE"
        Me.GSOTYPE.OptionsColumn.AllowEdit = False
        '
        'GFINALQUALITY
        '
        Me.GFINALQUALITY.Caption = "Final Quality"
        Me.GFINALQUALITY.FieldName = "FINALQUALITY"
        Me.GFINALQUALITY.Name = "GFINALQUALITY"
        Me.GFINALQUALITY.OptionsColumn.AllowEdit = False
        Me.GFINALQUALITY.Visible = True
        Me.GFINALQUALITY.VisibleIndex = 9
        Me.GFINALQUALITY.Width = 180
        '
        'GMACHINENO
        '
        Me.GMACHINENO.Caption = "Machine No"
        Me.GMACHINENO.FieldName = "MACHINE"
        Me.GMACHINENO.Name = "GMACHINENO"
        Me.GMACHINENO.OptionsColumn.AllowEdit = False
        '
        'GGRIDISSUERNO
        '
        Me.GGRIDISSUERNO.Caption = "Grid Issue SRNO"
        Me.GGRIDISSUERNO.FieldName = "GRIDISSUESRNO"
        Me.GGRIDISSUERNO.Name = "GGRIDISSUERNO"
        Me.GGRIDISSUERNO.OptionsColumn.AllowEdit = False
        Me.GGRIDISSUERNO.Width = 100
        '
        'GQUALITY
        '
        Me.GQUALITY.Caption = "Quality"
        Me.GQUALITY.FieldName = "QUALITY"
        Me.GQUALITY.Name = "GQUALITY"
        Me.GQUALITY.OptionsColumn.AllowEdit = False
        Me.GQUALITY.Visible = True
        Me.GQUALITY.VisibleIndex = 10
        Me.GQUALITY.Width = 180
        '
        'GLOTNO
        '
        Me.GLOTNO.Caption = "Lot No"
        Me.GLOTNO.FieldName = "LOTNO"
        Me.GLOTNO.Name = "GLOTNO"
        Me.GLOTNO.OptionsColumn.AllowEdit = False
        Me.GLOTNO.Visible = True
        Me.GLOTNO.VisibleIndex = 11
        Me.GLOTNO.Width = 60
        '
        'GDIFF
        '
        Me.GDIFF.Caption = "Diff"
        Me.GDIFF.FieldName = "DIFF"
        Me.GDIFF.Name = "GDIFF"
        Me.GDIFF.OptionsColumn.AllowEdit = False
        Me.GDIFF.Visible = True
        Me.GDIFF.VisibleIndex = 12
        Me.GDIFF.Width = 60
        '
        'GUNIT
        '
        Me.GUNIT.Caption = "Unit"
        Me.GUNIT.FieldName = "UNIT"
        Me.GUNIT.Name = "GUNIT"
        Me.GUNIT.OptionsColumn.AllowEdit = False
        Me.GUNIT.Visible = True
        Me.GUNIT.VisibleIndex = 13
        Me.GUNIT.Width = 50
        '
        'GGODOWN
        '
        Me.GGODOWN.Caption = "Godown"
        Me.GGODOWN.FieldName = "GODOWN"
        Me.GGODOWN.Name = "GGODOWN"
        Me.GGODOWN.OptionsColumn.AllowEdit = False
        Me.GGODOWN.Width = 100
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
        Me.cmdexit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdexit.Location = New System.Drawing.Point(626, 537)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 9
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdok.Location = New System.Drawing.Point(540, 537)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 8
        Me.cmdok.Text = "&Ok"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'SelectIssue
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1247, 577)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "SelectIssue"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Select Issue"
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
    Friend WithEvents cmdexit As Button
    Friend WithEvents cmdok As Button
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCHK As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CHKEDIT As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GISSUENO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GJOSRNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GJOTYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPROFORMANO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSONO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSODATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSOTYPE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GFINALQUALITY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents APPROXDATE As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents GJONO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GJODATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMACHINENO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGRIDISSUERNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GQUALITY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GLOTNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GROLLNO As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGSM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSIZE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GOURQTY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDIFF As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GUNIT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGODOWN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CHKSELECTALL As CheckBox
    Friend WithEvents GMILLQTY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGSMDETAILS As DevExpress.XtraGrid.Columns.GridColumn
End Class
