<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NonInvItemMasterDetailReport
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
        Me.CMDREFRESH = New System.Windows.Forms.Button()
        Me.CMDEXCEL = New System.Windows.Forms.Button()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GITEMNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCATEGORY = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GHSNCODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GLENGTH = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GWIDTH = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GGSM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GINVITEMCODE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GISPLATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GISPAPER = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREMARKS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPAPERMATERIAL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPAPERMILL = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.cmdcancel = New System.Windows.Forms.Button()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CMDREFRESH)
        Me.BlendPanel1.Controls.Add(Me.CMDEXCEL)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.cmdcancel)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1234, 581)
        Me.BlendPanel1.TabIndex = 7
        '
        'CMDREFRESH
        '
        Me.CMDREFRESH.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDREFRESH.Location = New System.Drawing.Point(534, 540)
        Me.CMDREFRESH.Name = "CMDREFRESH"
        Me.CMDREFRESH.Size = New System.Drawing.Size(80, 28)
        Me.CMDREFRESH.TabIndex = 502
        Me.CMDREFRESH.Text = "&Refresh"
        Me.CMDREFRESH.UseVisualStyleBackColor = True
        '
        'CMDEXCEL
        '
        Me.CMDEXCEL.BackColor = System.Drawing.Color.Transparent
        Me.CMDEXCEL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CMDEXCEL.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDEXCEL.FlatAppearance.BorderSize = 0
        Me.CMDEXCEL.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDEXCEL.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDEXCEL.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMDEXCEL.Location = New System.Drawing.Point(503, 545)
        Me.CMDEXCEL.Name = "CMDEXCEL"
        Me.CMDEXCEL.Size = New System.Drawing.Size(25, 21)
        Me.CMDEXCEL.TabIndex = 501
        Me.CMDEXCEL.UseVisualStyleBackColor = False
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(19, 12)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(1203, 522)
        Me.gridbilldetails.TabIndex = 494
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GITEMNAME, Me.GCATEGORY, Me.GHSNCODE, Me.GLENGTH, Me.GWIDTH, Me.GGSM, Me.GINVITEMCODE, Me.GISPLATE, Me.GISPAPER, Me.GREMARKS, Me.GPAPERMATERIAL, Me.GPAPERMILL})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridbill.OptionsBehavior.Editable = False
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        '
        'GITEMNAME
        '
        Me.GITEMNAME.Caption = "Non Inventory Item Name"
        Me.GITEMNAME.FieldName = "ITEMNAME"
        Me.GITEMNAME.Name = "GITEMNAME"
        Me.GITEMNAME.Visible = True
        Me.GITEMNAME.VisibleIndex = 0
        Me.GITEMNAME.Width = 300
        '
        'GCATEGORY
        '
        Me.GCATEGORY.Caption = "Category"
        Me.GCATEGORY.FieldName = "CATEGORYNAME"
        Me.GCATEGORY.Name = "GCATEGORY"
        Me.GCATEGORY.Visible = True
        Me.GCATEGORY.VisibleIndex = 1
        Me.GCATEGORY.Width = 150
        '
        'GHSNCODE
        '
        Me.GHSNCODE.Caption = "HSN Code"
        Me.GHSNCODE.FieldName = "HSNCODE"
        Me.GHSNCODE.Name = "GHSNCODE"
        Me.GHSNCODE.Visible = True
        Me.GHSNCODE.VisibleIndex = 2
        Me.GHSNCODE.Width = 100
        '
        'GLENGTH
        '
        Me.GLENGTH.Caption = "Length"
        Me.GLENGTH.FieldName = "LENGTH"
        Me.GLENGTH.Name = "GLENGTH"
        Me.GLENGTH.Visible = True
        Me.GLENGTH.VisibleIndex = 3
        '
        'GWIDTH
        '
        Me.GWIDTH.Caption = "Width"
        Me.GWIDTH.FieldName = "WIDTH"
        Me.GWIDTH.Name = "GWIDTH"
        Me.GWIDTH.Visible = True
        Me.GWIDTH.VisibleIndex = 4
        '
        'GGSM
        '
        Me.GGSM.Caption = "GSM"
        Me.GGSM.FieldName = "GSM"
        Me.GGSM.Name = "GGSM"
        Me.GGSM.Visible = True
        Me.GGSM.VisibleIndex = 5
        '
        'GINVITEMCODE
        '
        Me.GINVITEMCODE.Caption = "Item Code"
        Me.GINVITEMCODE.FieldName = "INVITEMCODE"
        Me.GINVITEMCODE.Name = "GINVITEMCODE"
        Me.GINVITEMCODE.Visible = True
        Me.GINVITEMCODE.VisibleIndex = 6
        Me.GINVITEMCODE.Width = 300
        '
        'GISPLATE
        '
        Me.GISPLATE.Caption = "Plate"
        Me.GISPLATE.FieldName = "ISPLATE"
        Me.GISPLATE.Name = "GISPLATE"
        Me.GISPLATE.Visible = True
        Me.GISPLATE.VisibleIndex = 7
        '
        'GISPAPER
        '
        Me.GISPAPER.Caption = "Paper"
        Me.GISPAPER.FieldName = "ISPAPER"
        Me.GISPAPER.Name = "GISPAPER"
        Me.GISPAPER.Visible = True
        Me.GISPAPER.VisibleIndex = 8
        '
        'GREMARKS
        '
        Me.GREMARKS.Caption = "Remarks"
        Me.GREMARKS.FieldName = "REMARKS"
        Me.GREMARKS.Name = "GREMARKS"
        Me.GREMARKS.Visible = True
        Me.GREMARKS.VisibleIndex = 9
        Me.GREMARKS.Width = 150
        '
        'GPAPERMATERIAL
        '
        Me.GPAPERMATERIAL.Caption = "Paper Matrial"
        Me.GPAPERMATERIAL.FieldName = "PAPERMATERIAL"
        Me.GPAPERMATERIAL.Name = "GPAPERMATERIAL"
        Me.GPAPERMATERIAL.Visible = True
        Me.GPAPERMATERIAL.VisibleIndex = 10
        '
        'GPAPERMILL
        '
        Me.GPAPERMILL.Caption = "Paper Mill"
        Me.GPAPERMILL.FieldName = "PAPERMILL"
        Me.GPAPERMILL.Name = "GPAPERMILL"
        Me.GPAPERMILL.Visible = True
        Me.GPAPERMILL.VisibleIndex = 11
        '
        'cmdcancel
        '
        Me.cmdcancel.BackColor = System.Drawing.Color.Transparent
        Me.cmdcancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdcancel.FlatAppearance.BorderSize = 0
        Me.cmdcancel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancel.ForeColor = System.Drawing.Color.Black
        Me.cmdcancel.Location = New System.Drawing.Point(620, 540)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(80, 28)
        Me.cmdcancel.TabIndex = 316
        Me.cmdcancel.Text = "E&xit"
        Me.cmdcancel.UseVisualStyleBackColor = False
        '
        'NonInvItemMasterDetailReport
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1234, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "NonInvItemMasterDetailReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Non Inv ItemMaster Detail Report"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents CMDREFRESH As Button
    Friend WithEvents CMDEXCEL As Button
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GITEMNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCATEGORY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GHSNCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GLENGTH As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GWIDTH As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GGSM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GINVITEMCODE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GISPLATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GISPAPER As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREMARKS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPAPERMATERIAL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPAPERMILL As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmdcancel As Button
End Class
