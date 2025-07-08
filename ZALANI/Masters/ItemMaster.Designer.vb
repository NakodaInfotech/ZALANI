<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ItemMaster
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ItemMaster))
        Me.BLENDPANEL1 = New VbPowerPack.BlendPanel()
        Me.CHKSLITTING = New System.Windows.Forms.CheckBox()
        Me.CHKLAMINATION = New System.Windows.Forms.CheckBox()
        Me.CHKPE = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TXTCODE = New System.Windows.Forms.TextBox()
        Me.TXTQUALITY = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TXTWARPSRNO = New System.Windows.Forms.TextBox()
        Me.GRIDBOMDETAILS = New System.Windows.Forms.DataGridView()
        Me.GSRNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GITEMNAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GQUALITY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CMBITEMNAME = New System.Windows.Forms.ComboBox()
        Me.CMBHSNCODE = New System.Windows.Forms.ComboBox()
        Me.CHKBLOCKED = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TXTRATE = New System.Windows.Forms.TextBox()
        Me.LBLOPRATE = New System.Windows.Forms.Label()
        Me.cmddelete = New System.Windows.Forms.Button()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.cmbmaterial = New System.Windows.Forms.ComboBox()
        Me.CMBNAME = New System.Windows.Forms.ComboBox()
        Me.cmbunit = New System.Windows.Forms.ComboBox()
        Me.lblmaterial = New System.Windows.Forms.Label()
        Me.LBLUNIT = New System.Windows.Forms.Label()
        Me.CMBITEMTYPE = New System.Windows.Forms.ComboBox()
        Me.lblcategory = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Ep = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.TXTMICRON = New System.Windows.Forms.TextBox()
        Me.LBLMICRON = New System.Windows.Forms.Label()
        Me.TXTCALCULATEON = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BLENDPANEL1.SuspendLayout()
        CType(Me.GRIDBOMDETAILS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ep, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BLENDPANEL1
        '
        Me.BLENDPANEL1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BLENDPANEL1.Controls.Add(Me.TXTCALCULATEON)
        Me.BLENDPANEL1.Controls.Add(Me.Label4)
        Me.BLENDPANEL1.Controls.Add(Me.TXTMICRON)
        Me.BLENDPANEL1.Controls.Add(Me.LBLMICRON)
        Me.BLENDPANEL1.Controls.Add(Me.CHKSLITTING)
        Me.BLENDPANEL1.Controls.Add(Me.CHKLAMINATION)
        Me.BLENDPANEL1.Controls.Add(Me.CHKPE)
        Me.BLENDPANEL1.Controls.Add(Me.Label5)
        Me.BLENDPANEL1.Controls.Add(Me.TXTCODE)
        Me.BLENDPANEL1.Controls.Add(Me.TXTQUALITY)
        Me.BLENDPANEL1.Controls.Add(Me.Label17)
        Me.BLENDPANEL1.Controls.Add(Me.TXTWARPSRNO)
        Me.BLENDPANEL1.Controls.Add(Me.GRIDBOMDETAILS)
        Me.BLENDPANEL1.Controls.Add(Me.CMBITEMNAME)
        Me.BLENDPANEL1.Controls.Add(Me.CMBHSNCODE)
        Me.BLENDPANEL1.Controls.Add(Me.CHKBLOCKED)
        Me.BLENDPANEL1.Controls.Add(Me.Label2)
        Me.BLENDPANEL1.Controls.Add(Me.TXTRATE)
        Me.BLENDPANEL1.Controls.Add(Me.LBLOPRATE)
        Me.BLENDPANEL1.Controls.Add(Me.cmddelete)
        Me.BLENDPANEL1.Controls.Add(Me.cmdok)
        Me.BLENDPANEL1.Controls.Add(Me.cmdexit)
        Me.BLENDPANEL1.Controls.Add(Me.cmbmaterial)
        Me.BLENDPANEL1.Controls.Add(Me.CMBNAME)
        Me.BLENDPANEL1.Controls.Add(Me.cmbunit)
        Me.BLENDPANEL1.Controls.Add(Me.lblmaterial)
        Me.BLENDPANEL1.Controls.Add(Me.LBLUNIT)
        Me.BLENDPANEL1.Controls.Add(Me.CMBITEMTYPE)
        Me.BLENDPANEL1.Controls.Add(Me.lblcategory)
        Me.BLENDPANEL1.Controls.Add(Me.Label3)
        Me.BLENDPANEL1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BLENDPANEL1.Location = New System.Drawing.Point(0, 0)
        Me.BLENDPANEL1.Name = "BLENDPANEL1"
        Me.BLENDPANEL1.Size = New System.Drawing.Size(653, 397)
        Me.BLENDPANEL1.TabIndex = 0
        '
        'CHKSLITTING
        '
        Me.CHKSLITTING.AutoSize = True
        Me.CHKSLITTING.BackColor = System.Drawing.Color.Transparent
        Me.CHKSLITTING.Location = New System.Drawing.Point(429, 204)
        Me.CHKSLITTING.Name = "CHKSLITTING"
        Me.CHKSLITTING.Size = New System.Drawing.Size(212, 19)
        Me.CHKSLITTING.TabIndex = 922
        Me.CHKSLITTING.TabStop = False
        Me.CHKSLITTING.Text = "CONVERSION (SLITTING/SHEETING)"
        Me.CHKSLITTING.UseVisualStyleBackColor = False
        '
        'CHKLAMINATION
        '
        Me.CHKLAMINATION.AutoSize = True
        Me.CHKLAMINATION.BackColor = System.Drawing.Color.Transparent
        Me.CHKLAMINATION.Location = New System.Drawing.Point(429, 179)
        Me.CHKLAMINATION.Name = "CHKLAMINATION"
        Me.CHKLAMINATION.Size = New System.Drawing.Size(94, 19)
        Me.CHKLAMINATION.TabIndex = 921
        Me.CHKLAMINATION.TabStop = False
        Me.CHKLAMINATION.Text = "LAMINATION"
        Me.CHKLAMINATION.UseVisualStyleBackColor = False
        '
        'CHKPE
        '
        Me.CHKPE.AutoSize = True
        Me.CHKPE.BackColor = System.Drawing.Color.Transparent
        Me.CHKPE.Location = New System.Drawing.Point(429, 154)
        Me.CHKPE.Name = "CHKPE"
        Me.CHKPE.Size = New System.Drawing.Size(87, 19)
        Me.CHKPE.TabIndex = 920
        Me.CHKPE.TabStop = False
        Me.CHKPE.Text = "EXTRUSION"
        Me.CHKPE.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(322, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 15)
        Me.Label5.TabIndex = 919
        Me.Label5.Text = "Item Code"
        '
        'TXTCODE
        '
        Me.TXTCODE.BackColor = System.Drawing.Color.LemonChiffon
        Me.TXTCODE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTCODE.Location = New System.Drawing.Point(386, 28)
        Me.TXTCODE.MaxLength = 50
        Me.TXTCODE.Name = "TXTCODE"
        Me.TXTCODE.Size = New System.Drawing.Size(106, 23)
        Me.TXTCODE.TabIndex = 2
        '
        'TXTQUALITY
        '
        Me.TXTQUALITY.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTQUALITY.Location = New System.Drawing.Point(279, 156)
        Me.TXTQUALITY.Name = "TXTQUALITY"
        Me.TXTQUALITY.Size = New System.Drawing.Size(70, 23)
        Me.TXTQUALITY.TabIndex = 9
        Me.TXTQUALITY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(46, 139)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(105, 14)
        Me.Label17.TabIndex = 6
        Me.Label17.Text = "ITEM BOM DETAILS"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TXTWARPSRNO
        '
        Me.TXTWARPSRNO.BackColor = System.Drawing.Color.Linen
        Me.TXTWARPSRNO.Location = New System.Drawing.Point(49, 156)
        Me.TXTWARPSRNO.Name = "TXTWARPSRNO"
        Me.TXTWARPSRNO.ReadOnly = True
        Me.TXTWARPSRNO.Size = New System.Drawing.Size(30, 23)
        Me.TXTWARPSRNO.TabIndex = 7
        Me.TXTWARPSRNO.TabStop = False
        '
        'GRIDBOMDETAILS
        '
        Me.GRIDBOMDETAILS.AllowUserToAddRows = False
        Me.GRIDBOMDETAILS.AllowUserToDeleteRows = False
        Me.GRIDBOMDETAILS.AllowUserToResizeColumns = False
        Me.GRIDBOMDETAILS.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black
        Me.GRIDBOMDETAILS.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GRIDBOMDETAILS.BackgroundColor = System.Drawing.Color.White
        Me.GRIDBOMDETAILS.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GRIDBOMDETAILS.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.GRIDBOMDETAILS.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GRIDBOMDETAILS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GRIDBOMDETAILS.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GSRNO, Me.GITEMNAME, Me.GQUALITY})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDBOMDETAILS.DefaultCellStyle = DataGridViewCellStyle3
        Me.GRIDBOMDETAILS.GridColor = System.Drawing.SystemColors.Control
        Me.GRIDBOMDETAILS.Location = New System.Drawing.Point(48, 178)
        Me.GRIDBOMDETAILS.MultiSelect = False
        Me.GRIDBOMDETAILS.Name = "GRIDBOMDETAILS"
        Me.GRIDBOMDETAILS.ReadOnly = True
        Me.GRIDBOMDETAILS.RowHeadersVisible = False
        Me.GRIDBOMDETAILS.RowHeadersWidth = 30
        Me.GRIDBOMDETAILS.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        Me.GRIDBOMDETAILS.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.GRIDBOMDETAILS.RowTemplate.Height = 20
        Me.GRIDBOMDETAILS.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDBOMDETAILS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRIDBOMDETAILS.Size = New System.Drawing.Size(336, 123)
        Me.GRIDBOMDETAILS.TabIndex = 915
        Me.GRIDBOMDETAILS.TabStop = False
        '
        'GSRNO
        '
        Me.GSRNO.HeaderText = "Sr."
        Me.GSRNO.Name = "GSRNO"
        Me.GSRNO.ReadOnly = True
        Me.GSRNO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GSRNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GSRNO.Width = 30
        '
        'GITEMNAME
        '
        Me.GITEMNAME.HeaderText = "ItemName"
        Me.GITEMNAME.Name = "GITEMNAME"
        Me.GITEMNAME.ReadOnly = True
        Me.GITEMNAME.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GITEMNAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GITEMNAME.Width = 200
        '
        'GQUALITY
        '
        Me.GQUALITY.HeaderText = "Qty"
        Me.GQUALITY.Name = "GQUALITY"
        Me.GQUALITY.ReadOnly = True
        Me.GQUALITY.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GQUALITY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.GQUALITY.Width = 70
        '
        'CMBITEMNAME
        '
        Me.CMBITEMNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBITEMNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBITEMNAME.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBITEMNAME.FormattingEnabled = True
        Me.CMBITEMNAME.Location = New System.Drawing.Point(79, 156)
        Me.CMBITEMNAME.Name = "CMBITEMNAME"
        Me.CMBITEMNAME.Size = New System.Drawing.Size(200, 23)
        Me.CMBITEMNAME.TabIndex = 8
        '
        'CMBHSNCODE
        '
        Me.CMBHSNCODE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBHSNCODE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBHSNCODE.BackColor = System.Drawing.SystemColors.Window
        Me.CMBHSNCODE.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBHSNCODE.FormattingEnabled = True
        Me.CMBHSNCODE.Location = New System.Drawing.Point(107, 84)
        Me.CMBHSNCODE.MaxDropDownItems = 14
        Me.CMBHSNCODE.Name = "CMBHSNCODE"
        Me.CMBHSNCODE.Size = New System.Drawing.Size(73, 23)
        Me.CMBHSNCODE.TabIndex = 3
        '
        'CHKBLOCKED
        '
        Me.CHKBLOCKED.AutoSize = True
        Me.CHKBLOCKED.BackColor = System.Drawing.Color.Transparent
        Me.CHKBLOCKED.Location = New System.Drawing.Point(450, 90)
        Me.CHKBLOCKED.Name = "CHKBLOCKED"
        Me.CHKBLOCKED.Size = New System.Drawing.Size(69, 19)
        Me.CHKBLOCKED.TabIndex = 15
        Me.CHKBLOCKED.TabStop = False
        Me.CHKBLOCKED.Text = "Blocked"
        Me.CHKBLOCKED.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(14, 87)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 14)
        Me.Label2.TabIndex = 350
        Me.Label2.Text = "HSN / SAC Code"
        '
        'TXTRATE
        '
        Me.TXTRATE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTRATE.Location = New System.Drawing.Point(386, 85)
        Me.TXTRATE.Name = "TXTRATE"
        Me.TXTRATE.Size = New System.Drawing.Size(58, 22)
        Me.TXTRATE.TabIndex = 14
        Me.TXTRATE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LBLOPRATE
        '
        Me.LBLOPRATE.AutoSize = True
        Me.LBLOPRATE.BackColor = System.Drawing.Color.Transparent
        Me.LBLOPRATE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLOPRATE.Location = New System.Drawing.Point(348, 89)
        Me.LBLOPRATE.Name = "LBLOPRATE"
        Me.LBLOPRATE.Size = New System.Drawing.Size(32, 14)
        Me.LBLOPRATE.TabIndex = 346
        Me.LBLOPRATE.Text = "Rate"
        '
        'cmddelete
        '
        Me.cmddelete.BackColor = System.Drawing.Color.Transparent
        Me.cmddelete.FlatAppearance.BorderSize = 0
        Me.cmddelete.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmddelete.ForeColor = System.Drawing.Color.Black
        Me.cmddelete.Location = New System.Drawing.Point(286, 344)
        Me.cmddelete.Name = "cmddelete"
        Me.cmddelete.Size = New System.Drawing.Size(80, 28)
        Me.cmddelete.TabIndex = 12
        Me.cmddelete.Text = "&Delete"
        Me.cmddelete.UseVisualStyleBackColor = False
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.Black
        Me.cmdok.Location = New System.Drawing.Point(200, 344)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 11
        Me.cmdok.Text = "&Save"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(372, 344)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 13
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'cmbmaterial
        '
        Me.cmbmaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbmaterial.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbmaterial.FormattingEnabled = True
        Me.cmbmaterial.Items.AddRange(New Object() {"RAW MATERIAL", "WASTAGE", "FINISHED"})
        Me.cmbmaterial.Location = New System.Drawing.Point(107, 29)
        Me.cmbmaterial.MaxDropDownItems = 14
        Me.cmbmaterial.Name = "cmbmaterial"
        Me.cmbmaterial.Size = New System.Drawing.Size(206, 22)
        Me.cmbmaterial.TabIndex = 0
        '
        'CMBNAME
        '
        Me.CMBNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBNAME.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBNAME.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBNAME.FormattingEnabled = True
        Me.CMBNAME.Location = New System.Drawing.Point(107, 57)
        Me.CMBNAME.MaxDropDownItems = 14
        Me.CMBNAME.Name = "CMBNAME"
        Me.CMBNAME.Size = New System.Drawing.Size(206, 22)
        Me.CMBNAME.TabIndex = 1
        '
        'cmbunit
        '
        Me.cmbunit.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbunit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbunit.BackColor = System.Drawing.Color.LemonChiffon
        Me.cmbunit.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbunit.FormattingEnabled = True
        Me.cmbunit.Location = New System.Drawing.Point(253, 85)
        Me.cmbunit.MaxDropDownItems = 14
        Me.cmbunit.Name = "cmbunit"
        Me.cmbunit.Size = New System.Drawing.Size(60, 22)
        Me.cmbunit.TabIndex = 4
        '
        'lblmaterial
        '
        Me.lblmaterial.AutoSize = True
        Me.lblmaterial.BackColor = System.Drawing.Color.Transparent
        Me.lblmaterial.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblmaterial.Location = New System.Drawing.Point(27, 33)
        Me.lblmaterial.Name = "lblmaterial"
        Me.lblmaterial.Size = New System.Drawing.Size(81, 14)
        Me.lblmaterial.TabIndex = 314
        Me.lblmaterial.Text = "Material Type"
        '
        'LBLUNIT
        '
        Me.LBLUNIT.AutoSize = True
        Me.LBLUNIT.BackColor = System.Drawing.Color.Transparent
        Me.LBLUNIT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLUNIT.Location = New System.Drawing.Point(222, 90)
        Me.LBLUNIT.Name = "LBLUNIT"
        Me.LBLUNIT.Size = New System.Drawing.Size(29, 14)
        Me.LBLUNIT.TabIndex = 340
        Me.LBLUNIT.Text = "unit"
        '
        'CMBITEMTYPE
        '
        Me.CMBITEMTYPE.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBITEMTYPE.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBITEMTYPE.BackColor = System.Drawing.Color.LemonChiffon
        Me.CMBITEMTYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBITEMTYPE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBITEMTYPE.FormattingEnabled = True
        Me.CMBITEMTYPE.Items.AddRange(New Object() {"PAPER", "LDPE", "FOIL", "WASTAGE", "ADHESIVE"})
        Me.CMBITEMTYPE.Location = New System.Drawing.Point(386, 56)
        Me.CMBITEMTYPE.MaxDropDownItems = 14
        Me.CMBITEMTYPE.Name = "CMBITEMTYPE"
        Me.CMBITEMTYPE.Size = New System.Drawing.Size(227, 22)
        Me.CMBITEMTYPE.TabIndex = 5
        '
        'lblcategory
        '
        Me.lblcategory.AutoSize = True
        Me.lblcategory.BackColor = System.Drawing.Color.Transparent
        Me.lblcategory.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcategory.Location = New System.Drawing.Point(325, 60)
        Me.lblcategory.Name = "lblcategory"
        Me.lblcategory.Size = New System.Drawing.Size(59, 14)
        Me.lblcategory.TabIndex = 309
        Me.lblcategory.Text = "Item Type"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(64, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 14)
        Me.Label3.TabIndex = 308
        Me.Label3.Text = "Name"
        '
        'Ep
        '
        Me.Ep.BlinkRate = 0
        Me.Ep.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.Ep.ContainerControl = Me
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'TXTMICRON
        '
        Me.TXTMICRON.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTMICRON.Location = New System.Drawing.Point(107, 113)
        Me.TXTMICRON.Name = "TXTMICRON"
        Me.TXTMICRON.Size = New System.Drawing.Size(66, 22)
        Me.TXTMICRON.TabIndex = 923
        Me.TXTMICRON.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LBLMICRON
        '
        Me.LBLMICRON.AutoSize = True
        Me.LBLMICRON.BackColor = System.Drawing.Color.Transparent
        Me.LBLMICRON.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLMICRON.Location = New System.Drawing.Point(60, 117)
        Me.LBLMICRON.Name = "LBLMICRON"
        Me.LBLMICRON.Size = New System.Drawing.Size(44, 14)
        Me.LBLMICRON.TabIndex = 924
        Me.LBLMICRON.Text = "Micron"
        '
        'TXTCALCULATEON
        '
        Me.TXTCALCULATEON.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCALCULATEON.Location = New System.Drawing.Point(253, 113)
        Me.TXTCALCULATEON.Name = "TXTCALCULATEON"
        Me.TXTCALCULATEON.Size = New System.Drawing.Size(60, 22)
        Me.TXTCALCULATEON.TabIndex = 925
        Me.TXTCALCULATEON.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(175, 117)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 14)
        Me.Label4.TabIndex = 926
        Me.Label4.Text = "Calculate On"
        '
        'ItemMaster
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(653, 397)
        Me.Controls.Add(Me.BLENDPANEL1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "ItemMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Item Master"
        Me.BLENDPANEL1.ResumeLayout(False)
        Me.BLENDPANEL1.PerformLayout()
        CType(Me.GRIDBOMDETAILS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ep, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BLENDPANEL1 As VbPowerPack.BlendPanel
    Friend WithEvents cmddelete As System.Windows.Forms.Button
    Friend WithEvents lblcategory As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents cmbmaterial As System.Windows.Forms.ComboBox
    Friend WithEvents lblmaterial As System.Windows.Forms.Label
    Friend WithEvents cmbunit As System.Windows.Forms.ComboBox
    Friend WithEvents LBLUNIT As System.Windows.Forms.Label
    Friend WithEvents Ep As System.Windows.Forms.ErrorProvider
    Friend WithEvents CMBNAME As System.Windows.Forms.ComboBox
    Friend WithEvents TXTRATE As System.Windows.Forms.TextBox
    Friend WithEvents LBLOPRATE As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CHKBLOCKED As System.Windows.Forms.CheckBox
    Friend WithEvents CMBHSNCODE As ComboBox
    Friend WithEvents TXTQUALITY As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents TXTWARPSRNO As TextBox
    Friend WithEvents GRIDBOMDETAILS As DataGridView
    Friend WithEvents CMBITEMNAME As ComboBox
    Friend WithEvents GSRNO As DataGridViewTextBoxColumn
    Friend WithEvents GITEMNAME As DataGridViewTextBoxColumn
    Friend WithEvents GQUALITY As DataGridViewTextBoxColumn
    Friend WithEvents Label5 As Label
    Friend WithEvents TXTCODE As TextBox
    Friend WithEvents CHKSLITTING As CheckBox
    Friend WithEvents CHKLAMINATION As CheckBox
    Friend WithEvents CHKPE As CheckBox
    Friend WithEvents CMBITEMTYPE As ComboBox
    Friend WithEvents TXTCALCULATEON As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TXTMICRON As TextBox
    Friend WithEvents LBLMICRON As Label
End Class
