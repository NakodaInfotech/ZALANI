﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SendWhatsapp
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.CHKSELECTALL = New System.Windows.Forms.CheckBox()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCHK = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGROUP = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GAREA = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCITY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGROUPOFCOMPANIES = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GWHATSAPP = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TXTAUTOCC = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TXTERRORMSG = New System.Windows.Forms.TextBox()
        Me.TXTADD = New System.Windows.Forms.TextBox()
        Me.CMBCODE = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TXTOTHERNO3 = New System.Windows.Forms.TextBox()
        Me.TXTOTHERNO2 = New System.Windows.Forms.TextBox()
        Me.TXTOTHERNO1 = New System.Windows.Forms.TextBox()
        Me.TXTAGENTNO = New System.Windows.Forms.TextBox()
        Me.TXTPARTYNO = New System.Windows.Forms.TextBox()
        Me.TXTMESSAGE = New System.Windows.Forms.TextBox()
        Me.CMBOTHERNAME3 = New System.Windows.Forms.ComboBox()
        Me.CMBOTHERNAME2 = New System.Windows.Forms.ComboBox()
        Me.CMBOTHERNAME1 = New System.Windows.Forms.ComboBox()
        Me.CMBAGENTNAME = New System.Windows.Forms.ComboBox()
        Me.CMBNAME = New System.Windows.Forms.ComboBox()
        Me.cmdcancel = New System.Windows.Forms.Button()
        Me.CMDSEND = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.BlendPanel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.TabControl1)
        Me.BlendPanel1.Controls.Add(Me.Label8)
        Me.BlendPanel1.Controls.Add(Me.TXTAUTOCC)
        Me.BlendPanel1.Controls.Add(Me.Label7)
        Me.BlendPanel1.Controls.Add(Me.TXTERRORMSG)
        Me.BlendPanel1.Controls.Add(Me.TXTADD)
        Me.BlendPanel1.Controls.Add(Me.CMBCODE)
        Me.BlendPanel1.Controls.Add(Me.Label6)
        Me.BlendPanel1.Controls.Add(Me.TXTOTHERNO3)
        Me.BlendPanel1.Controls.Add(Me.TXTOTHERNO2)
        Me.BlendPanel1.Controls.Add(Me.TXTOTHERNO1)
        Me.BlendPanel1.Controls.Add(Me.TXTAGENTNO)
        Me.BlendPanel1.Controls.Add(Me.TXTPARTYNO)
        Me.BlendPanel1.Controls.Add(Me.TXTMESSAGE)
        Me.BlendPanel1.Controls.Add(Me.CMBOTHERNAME3)
        Me.BlendPanel1.Controls.Add(Me.CMBOTHERNAME2)
        Me.BlendPanel1.Controls.Add(Me.CMBOTHERNAME1)
        Me.BlendPanel1.Controls.Add(Me.CMBAGENTNAME)
        Me.BlendPanel1.Controls.Add(Me.CMBNAME)
        Me.BlendPanel1.Controls.Add(Me.cmdcancel)
        Me.BlendPanel1.Controls.Add(Me.CMDSEND)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.Label2)
        Me.BlendPanel1.Controls.Add(Me.Label3)
        Me.BlendPanel1.Controls.Add(Me.Label4)
        Me.BlendPanel1.Controls.Add(Me.Label5)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 581)
        Me.BlendPanel1.TabIndex = 1
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(518, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(713, 557)
        Me.TabControl1.TabIndex = 660
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.CHKSELECTALL)
        Me.TabPage1.Controls.Add(Me.gridbilldetails)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(705, 529)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Party Selection"
        '
        'CHKSELECTALL
        '
        Me.CHKSELECTALL.AutoSize = True
        Me.CHKSELECTALL.BackColor = System.Drawing.Color.Transparent
        Me.CHKSELECTALL.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHKSELECTALL.ForeColor = System.Drawing.Color.Black
        Me.CHKSELECTALL.Location = New System.Drawing.Point(6, 6)
        Me.CHKSELECTALL.Name = "CHKSELECTALL"
        Me.CHKSELECTALL.Size = New System.Drawing.Size(77, 18)
        Me.CHKSELECTALL.TabIndex = 2
        Me.CHKSELECTALL.Text = "Select All"
        Me.CHKSELECTALL.UseVisualStyleBackColor = False
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(3, 27)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(697, 496)
        Me.gridbilldetails.TabIndex = 3
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCHK, Me.GNAME, Me.GGROUP, Me.GAREA, Me.GCITY, Me.GGROUPOFCOMPANIES, Me.GWHATSAPP})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        '
        'GCHK
        '
        Me.GCHK.FieldName = "CHK"
        Me.GCHK.Name = "GCHK"
        Me.GCHK.Visible = True
        Me.GCHK.VisibleIndex = 0
        Me.GCHK.Width = 35
        '
        'GNAME
        '
        Me.GNAME.Caption = "Name"
        Me.GNAME.FieldName = "NAME"
        Me.GNAME.ImageIndex = 0
        Me.GNAME.Name = "GNAME"
        Me.GNAME.OptionsColumn.AllowEdit = False
        Me.GNAME.Visible = True
        Me.GNAME.VisibleIndex = 1
        Me.GNAME.Width = 250
        '
        'GGROUP
        '
        Me.GGROUP.Caption = "Group"
        Me.GGROUP.FieldName = "GROUP"
        Me.GGROUP.Name = "GGROUP"
        Me.GGROUP.Visible = True
        Me.GGROUP.VisibleIndex = 2
        Me.GGROUP.Width = 100
        '
        'GAREA
        '
        Me.GAREA.Caption = "Area"
        Me.GAREA.FieldName = "AREA"
        Me.GAREA.Name = "GAREA"
        Me.GAREA.Visible = True
        Me.GAREA.VisibleIndex = 3
        Me.GAREA.Width = 100
        '
        'GCITY
        '
        Me.GCITY.Caption = "City"
        Me.GCITY.FieldName = "CITY"
        Me.GCITY.Name = "GCITY"
        Me.GCITY.OptionsColumn.AllowEdit = False
        Me.GCITY.Visible = True
        Me.GCITY.VisibleIndex = 4
        Me.GCITY.Width = 100
        '
        'GGROUPOFCOMPANIES
        '
        Me.GGROUPOFCOMPANIES.Caption = "Group Of Companies"
        Me.GGROUPOFCOMPANIES.FieldName = "GRPCOM"
        Me.GGROUPOFCOMPANIES.Name = "GGROUPOFCOMPANIES"
        Me.GGROUPOFCOMPANIES.Visible = True
        Me.GGROUPOFCOMPANIES.VisibleIndex = 5
        Me.GGROUPOFCOMPANIES.Width = 120
        '
        'GWHATSAPP
        '
        Me.GWHATSAPP.Caption = "WhatsApp No"
        Me.GWHATSAPP.FieldName = "WHATSAPP"
        Me.GWHATSAPP.Name = "GWHATSAPP"
        Me.GWHATSAPP.Visible = True
        Me.GWHATSAPP.VisibleIndex = 6
        Me.GWHATSAPP.Width = 80
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(35, 268)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(49, 15)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Auto CC"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TXTAUTOCC
        '
        Me.TXTAUTOCC.Location = New System.Drawing.Point(89, 265)
        Me.TXTAUTOCC.MaxLength = 10
        Me.TXTAUTOCC.Name = "TXTAUTOCC"
        Me.TXTAUTOCC.Size = New System.Drawing.Size(176, 23)
        Me.TXTAUTOCC.TabIndex = 17
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(0, 460)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(86, 15)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Error Message"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TXTERRORMSG
        '
        Me.TXTERRORMSG.BackColor = System.Drawing.Color.Linen
        Me.TXTERRORMSG.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTERRORMSG.ForeColor = System.Drawing.Color.DimGray
        Me.TXTERRORMSG.Location = New System.Drawing.Point(89, 457)
        Me.TXTERRORMSG.Multiline = True
        Me.TXTERRORMSG.Name = "TXTERRORMSG"
        Me.TXTERRORMSG.ReadOnly = True
        Me.TXTERRORMSG.Size = New System.Drawing.Size(423, 112)
        Me.TXTERRORMSG.TabIndex = 15
        Me.TXTERRORMSG.TabStop = False
        '
        'TXTADD
        '
        Me.TXTADD.Location = New System.Drawing.Point(518, 97)
        Me.TXTADD.MaxLength = 10
        Me.TXTADD.Name = "TXTADD"
        Me.TXTADD.Size = New System.Drawing.Size(25, 23)
        Me.TXTADD.TabIndex = 14
        Me.TXTADD.Visible = False
        '
        'CMBCODE
        '
        Me.CMBCODE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBCODE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBCODE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBCODE.FormattingEnabled = True
        Me.CMBCODE.Location = New System.Drawing.Point(518, 68)
        Me.CMBCODE.MaxDropDownItems = 14
        Me.CMBCODE.Name = "CMBCODE"
        Me.CMBCODE.Size = New System.Drawing.Size(25, 23)
        Me.CMBCODE.TabIndex = 13
        Me.CMBCODE.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(29, 164)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 15)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Message"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TXTOTHERNO3
        '
        Me.TXTOTHERNO3.Location = New System.Drawing.Point(336, 132)
        Me.TXTOTHERNO3.MaxLength = 10
        Me.TXTOTHERNO3.Name = "TXTOTHERNO3"
        Me.TXTOTHERNO3.Size = New System.Drawing.Size(176, 23)
        Me.TXTOTHERNO3.TabIndex = 9
        '
        'TXTOTHERNO2
        '
        Me.TXTOTHERNO2.Location = New System.Drawing.Point(336, 102)
        Me.TXTOTHERNO2.MaxLength = 10
        Me.TXTOTHERNO2.Name = "TXTOTHERNO2"
        Me.TXTOTHERNO2.Size = New System.Drawing.Size(176, 23)
        Me.TXTOTHERNO2.TabIndex = 7
        '
        'TXTOTHERNO1
        '
        Me.TXTOTHERNO1.Location = New System.Drawing.Point(336, 72)
        Me.TXTOTHERNO1.MaxLength = 10
        Me.TXTOTHERNO1.Name = "TXTOTHERNO1"
        Me.TXTOTHERNO1.Size = New System.Drawing.Size(176, 23)
        Me.TXTOTHERNO1.TabIndex = 5
        '
        'TXTAGENTNO
        '
        Me.TXTAGENTNO.Location = New System.Drawing.Point(336, 42)
        Me.TXTAGENTNO.MaxLength = 10
        Me.TXTAGENTNO.Name = "TXTAGENTNO"
        Me.TXTAGENTNO.Size = New System.Drawing.Size(176, 23)
        Me.TXTAGENTNO.TabIndex = 3
        '
        'TXTPARTYNO
        '
        Me.TXTPARTYNO.Location = New System.Drawing.Point(336, 12)
        Me.TXTPARTYNO.MaxLength = 10
        Me.TXTPARTYNO.Name = "TXTPARTYNO"
        Me.TXTPARTYNO.Size = New System.Drawing.Size(176, 23)
        Me.TXTPARTYNO.TabIndex = 1
        '
        'TXTMESSAGE
        '
        Me.TXTMESSAGE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTMESSAGE.ForeColor = System.Drawing.Color.DimGray
        Me.TXTMESSAGE.Location = New System.Drawing.Point(89, 161)
        Me.TXTMESSAGE.Multiline = True
        Me.TXTMESSAGE.Name = "TXTMESSAGE"
        Me.TXTMESSAGE.Size = New System.Drawing.Size(423, 98)
        Me.TXTMESSAGE.TabIndex = 10
        '
        'CMBOTHERNAME3
        '
        Me.CMBOTHERNAME3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBOTHERNAME3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBOTHERNAME3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBOTHERNAME3.FormattingEnabled = True
        Me.CMBOTHERNAME3.Location = New System.Drawing.Point(89, 132)
        Me.CMBOTHERNAME3.MaxDropDownItems = 14
        Me.CMBOTHERNAME3.Name = "CMBOTHERNAME3"
        Me.CMBOTHERNAME3.Size = New System.Drawing.Size(241, 23)
        Me.CMBOTHERNAME3.TabIndex = 8
        '
        'CMBOTHERNAME2
        '
        Me.CMBOTHERNAME2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBOTHERNAME2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBOTHERNAME2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBOTHERNAME2.FormattingEnabled = True
        Me.CMBOTHERNAME2.Location = New System.Drawing.Point(89, 102)
        Me.CMBOTHERNAME2.MaxDropDownItems = 14
        Me.CMBOTHERNAME2.Name = "CMBOTHERNAME2"
        Me.CMBOTHERNAME2.Size = New System.Drawing.Size(241, 23)
        Me.CMBOTHERNAME2.TabIndex = 6
        '
        'CMBOTHERNAME1
        '
        Me.CMBOTHERNAME1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBOTHERNAME1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBOTHERNAME1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBOTHERNAME1.FormattingEnabled = True
        Me.CMBOTHERNAME1.Location = New System.Drawing.Point(89, 72)
        Me.CMBOTHERNAME1.MaxDropDownItems = 14
        Me.CMBOTHERNAME1.Name = "CMBOTHERNAME1"
        Me.CMBOTHERNAME1.Size = New System.Drawing.Size(241, 23)
        Me.CMBOTHERNAME1.TabIndex = 4
        '
        'CMBAGENTNAME
        '
        Me.CMBAGENTNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBAGENTNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBAGENTNAME.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBAGENTNAME.FormattingEnabled = True
        Me.CMBAGENTNAME.Location = New System.Drawing.Point(89, 42)
        Me.CMBAGENTNAME.MaxDropDownItems = 14
        Me.CMBAGENTNAME.Name = "CMBAGENTNAME"
        Me.CMBAGENTNAME.Size = New System.Drawing.Size(241, 23)
        Me.CMBAGENTNAME.TabIndex = 2
        '
        'CMBNAME
        '
        Me.CMBNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBNAME.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBNAME.FormattingEnabled = True
        Me.CMBNAME.Location = New System.Drawing.Point(89, 12)
        Me.CMBNAME.MaxDropDownItems = 14
        Me.CMBNAME.Name = "CMBNAME"
        Me.CMBNAME.Size = New System.Drawing.Size(241, 23)
        Me.CMBNAME.TabIndex = 0
        '
        'cmdcancel
        '
        Me.cmdcancel.BackColor = System.Drawing.Color.Transparent
        Me.cmdcancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdcancel.FlatAppearance.BorderSize = 0
        Me.cmdcancel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancel.ForeColor = System.Drawing.Color.Black
        Me.cmdcancel.Location = New System.Drawing.Point(283, 423)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(80, 28)
        Me.cmdcancel.TabIndex = 12
        Me.cmdcancel.Text = "E&xit"
        Me.cmdcancel.UseVisualStyleBackColor = False
        '
        'CMDSEND
        '
        Me.CMDSEND.BackColor = System.Drawing.Color.Transparent
        Me.CMDSEND.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.CMDSEND.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDSEND.FlatAppearance.BorderSize = 0
        Me.CMDSEND.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDSEND.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDSEND.Location = New System.Drawing.Point(197, 423)
        Me.CMDSEND.Name = "CMDSEND"
        Me.CMDSEND.Size = New System.Drawing.Size(80, 28)
        Me.CMDSEND.TabIndex = 11
        Me.CMDSEND.Text = "&Send"
        Me.CMDSEND.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.CMDSEND.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Party Name"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 15)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Agent Name"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 15)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Other Name"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 106)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 15)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Other Name"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 136)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 15)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Other Name"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SendWhatsapp
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "SendWhatsapp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Send Whatsapp"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents CHKSELECTALL As CheckBox
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GCHK As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents GNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGROUP As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GAREA As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCITY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGROUPOFCOMPANIES As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GWHATSAPP As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Label8 As Label
    Friend WithEvents TXTAUTOCC As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TXTERRORMSG As TextBox
    Friend WithEvents TXTADD As TextBox
    Friend WithEvents CMBCODE As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TXTOTHERNO3 As TextBox
    Friend WithEvents TXTOTHERNO2 As TextBox
    Friend WithEvents TXTOTHERNO1 As TextBox
    Friend WithEvents TXTAGENTNO As TextBox
    Friend WithEvents TXTPARTYNO As TextBox
    Friend WithEvents TXTMESSAGE As TextBox
    Friend WithEvents CMBOTHERNAME3 As ComboBox
    Friend WithEvents CMBOTHERNAME2 As ComboBox
    Friend WithEvents CMBOTHERNAME1 As ComboBox
    Friend WithEvents CMBAGENTNAME As ComboBox
    Friend WithEvents CMBNAME As ComboBox
    Friend WithEvents cmdcancel As Button
    Friend WithEvents CMDSEND As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
End Class
