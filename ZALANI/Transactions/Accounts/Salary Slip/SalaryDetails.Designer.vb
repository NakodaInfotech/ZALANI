﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SalaryDetails
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
        Me.CMDOK = New System.Windows.Forms.Button()
        Me.cmdcancel = New System.Windows.Forms.Button()
        Me.gridbilldetails = New DevExpress.XtraGrid.GridControl()
        Me.gridbill = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gsrno = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDATE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GEMPNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GMONTH = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GWORKDAYS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GPAYDAYS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GLEAVE = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDED = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTOTALEAR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GLEDGERNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GLOANLEDGERNAME = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GADVANCETAKEN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNETT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GREMARKS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GLOANEMI = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.TOOLREFRESH = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.gridbilldetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridbill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CMDOK)
        Me.BlendPanel1.Controls.Add(Me.cmdcancel)
        Me.BlendPanel1.Controls.Add(Me.gridbilldetails)
        Me.BlendPanel1.Controls.Add(Me.ToolStrip1)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(1284, 581)
        Me.BlendPanel1.TabIndex = 4
        '
        'CMDOK
        '
        Me.CMDOK.BackColor = System.Drawing.Color.Transparent
        Me.CMDOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDOK.FlatAppearance.BorderSize = 0
        Me.CMDOK.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDOK.ForeColor = System.Drawing.Color.Black
        Me.CMDOK.Location = New System.Drawing.Point(560, 541)
        Me.CMDOK.Name = "CMDOK"
        Me.CMDOK.Size = New System.Drawing.Size(80, 28)
        Me.CMDOK.TabIndex = 317
        Me.CMDOK.Text = "&Ok"
        Me.CMDOK.UseVisualStyleBackColor = False
        '
        'cmdcancel
        '
        Me.cmdcancel.BackColor = System.Drawing.Color.Transparent
        Me.cmdcancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdcancel.FlatAppearance.BorderSize = 0
        Me.cmdcancel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancel.ForeColor = System.Drawing.Color.Black
        Me.cmdcancel.Location = New System.Drawing.Point(645, 541)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(80, 28)
        Me.cmdcancel.TabIndex = 316
        Me.cmdcancel.Text = "E&xit"
        Me.cmdcancel.UseVisualStyleBackColor = False
        '
        'gridbilldetails
        '
        Me.gridbilldetails.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbilldetails.Location = New System.Drawing.Point(16, 44)
        Me.gridbilldetails.LookAndFeel.UseDefaultLookAndFeel = False
        Me.gridbilldetails.MainView = Me.gridbill
        Me.gridbilldetails.Name = "gridbilldetails"
        Me.gridbilldetails.Size = New System.Drawing.Size(1256, 491)
        Me.gridbilldetails.TabIndex = 314
        Me.gridbilldetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridbill})
        '
        'gridbill
        '
        Me.gridbill.Appearance.Row.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridbill.Appearance.Row.Options.UseFont = True
        Me.gridbill.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gsrno, Me.GDATE, Me.GEMPNAME, Me.GMONTH, Me.GWORKDAYS, Me.GPAYDAYS, Me.GLEAVE, Me.GDED, Me.GTOTALEAR, Me.GLEDGERNAME, Me.GLOANLEDGERNAME, Me.GADVANCETAKEN, Me.GNETT, Me.GREMARKS, Me.GLOANEMI})
        Me.gridbill.GridControl = Me.gridbilldetails
        Me.gridbill.Name = "gridbill"
        Me.gridbill.OptionsBehavior.AllowIncrementalSearch = True
        Me.gridbill.OptionsBehavior.Editable = False
        Me.gridbill.OptionsCustomization.AllowGroup = False
        Me.gridbill.OptionsView.ColumnAutoWidth = False
        Me.gridbill.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways
        Me.gridbill.OptionsView.ShowAutoFilterRow = True
        Me.gridbill.OptionsView.ShowFooter = True
        '
        'gsrno
        '
        Me.gsrno.Caption = "Sr. No"
        Me.gsrno.FieldName = "SRNO"
        Me.gsrno.Name = "gsrno"
        Me.gsrno.OptionsColumn.AllowEdit = False
        Me.gsrno.Visible = True
        Me.gsrno.VisibleIndex = 0
        Me.gsrno.Width = 50
        '
        'GDATE
        '
        Me.GDATE.Caption = "Date"
        Me.GDATE.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.GDATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GDATE.FieldName = "SALDATE"
        Me.GDATE.Name = "GDATE"
        Me.GDATE.OptionsColumn.AllowEdit = False
        Me.GDATE.Visible = True
        Me.GDATE.VisibleIndex = 1
        Me.GDATE.Width = 80
        '
        'GEMPNAME
        '
        Me.GEMPNAME.Caption = "Employee Name"
        Me.GEMPNAME.FieldName = "EMPNAME"
        Me.GEMPNAME.Name = "GEMPNAME"
        Me.GEMPNAME.OptionsColumn.AllowEdit = False
        Me.GEMPNAME.Visible = True
        Me.GEMPNAME.VisibleIndex = 2
        Me.GEMPNAME.Width = 250
        '
        'GMONTH
        '
        Me.GMONTH.Caption = "Month"
        Me.GMONTH.FieldName = "MONTH"
        Me.GMONTH.Name = "GMONTH"
        Me.GMONTH.OptionsColumn.AllowEdit = False
        Me.GMONTH.Visible = True
        Me.GMONTH.VisibleIndex = 3
        '
        'GWORKDAYS
        '
        Me.GWORKDAYS.Caption = "Work Days"
        Me.GWORKDAYS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GWORKDAYS.FieldName = "WORKDAYS"
        Me.GWORKDAYS.Name = "GWORKDAYS"
        Me.GWORKDAYS.OptionsColumn.AllowEdit = False
        Me.GWORKDAYS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GWORKDAYS.Visible = True
        Me.GWORKDAYS.VisibleIndex = 4
        '
        'GPAYDAYS
        '
        Me.GPAYDAYS.Caption = "Pay Days"
        Me.GPAYDAYS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GPAYDAYS.FieldName = "PAYDAYS"
        Me.GPAYDAYS.Name = "GPAYDAYS"
        Me.GPAYDAYS.OptionsColumn.AllowEdit = False
        Me.GPAYDAYS.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GPAYDAYS.Visible = True
        Me.GPAYDAYS.VisibleIndex = 5
        '
        'GLEAVE
        '
        Me.GLEAVE.Caption = "Leave"
        Me.GLEAVE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GLEAVE.FieldName = "LEAVE"
        Me.GLEAVE.Name = "GLEAVE"
        Me.GLEAVE.OptionsColumn.AllowEdit = False
        Me.GLEAVE.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GLEAVE.Visible = True
        Me.GLEAVE.VisibleIndex = 6
        '
        'GDED
        '
        Me.GDED.Caption = "Total Ded"
        Me.GDED.DisplayFormat.FormatString = "0.00"
        Me.GDED.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GDED.FieldName = "TOTALDED"
        Me.GDED.Name = "GDED"
        Me.GDED.OptionsColumn.AllowEdit = False
        Me.GDED.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GDED.Visible = True
        Me.GDED.VisibleIndex = 7
        '
        'GTOTALEAR
        '
        Me.GTOTALEAR.Caption = "Total Ear"
        Me.GTOTALEAR.DisplayFormat.FormatString = "0.00"
        Me.GTOTALEAR.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GTOTALEAR.FieldName = "TOTALEAR"
        Me.GTOTALEAR.Name = "GTOTALEAR"
        Me.GTOTALEAR.OptionsColumn.AllowEdit = False
        Me.GTOTALEAR.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GTOTALEAR.Visible = True
        Me.GTOTALEAR.VisibleIndex = 8
        '
        'GLEDGERNAME
        '
        Me.GLEDGERNAME.Caption = "Ledger Name"
        Me.GLEDGERNAME.FieldName = "LEDGERNAME"
        Me.GLEDGERNAME.Name = "GLEDGERNAME"
        Me.GLEDGERNAME.OptionsColumn.AllowEdit = False
        Me.GLEDGERNAME.Visible = True
        Me.GLEDGERNAME.VisibleIndex = 9
        '
        'GLOANLEDGERNAME
        '
        Me.GLOANLEDGERNAME.Caption = "Loan Ledger Name"
        Me.GLOANLEDGERNAME.FieldName = "LOANLEDGERNAME"
        Me.GLOANLEDGERNAME.Name = "GLOANLEDGERNAME"
        Me.GLOANLEDGERNAME.OptionsColumn.AllowEdit = False
        Me.GLOANLEDGERNAME.Visible = True
        Me.GLOANLEDGERNAME.VisibleIndex = 10
        '
        'GADVANCETAKEN
        '
        Me.GADVANCETAKEN.Caption = "Advance Taken"
        Me.GADVANCETAKEN.FieldName = "ADVANCETAKEN"
        Me.GADVANCETAKEN.Name = "GADVANCETAKEN"
        Me.GADVANCETAKEN.OptionsColumn.AllowEdit = False
        Me.GADVANCETAKEN.Visible = True
        Me.GADVANCETAKEN.VisibleIndex = 11
        Me.GADVANCETAKEN.Width = 80
        '
        'GNETT
        '
        Me.GNETT.Caption = "Nett Payable"
        Me.GNETT.DisplayFormat.FormatString = "0.00"
        Me.GNETT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GNETT.FieldName = "NETTPAY"
        Me.GNETT.Name = "GNETT"
        Me.GNETT.OptionsColumn.AllowEdit = False
        Me.GNETT.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GNETT.Visible = True
        Me.GNETT.VisibleIndex = 12
        Me.GNETT.Width = 85
        '
        'GREMARKS
        '
        Me.GREMARKS.Caption = "Remarks"
        Me.GREMARKS.FieldName = "REMARKS"
        Me.GREMARKS.Name = "GREMARKS"
        Me.GREMARKS.OptionsColumn.AllowEdit = False
        Me.GREMARKS.Visible = True
        Me.GREMARKS.VisibleIndex = 13
        Me.GREMARKS.Width = 200
        '
        'GLOANEMI
        '
        Me.GLOANEMI.Caption = "LOAN EMI"
        Me.GLOANEMI.FieldName = "LOANEMI"
        Me.GLOANEMI.Name = "GLOANEMI"
        Me.GLOANEMI.OptionsColumn.AllowEdit = False
        Me.GLOANEMI.Visible = True
        Me.GLOANEMI.VisibleIndex = 14
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.toolStripSeparator, Me.PrintToolStripButton, Me.TOOLREFRESH, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1284, 25)
        Me.ToolStrip1.TabIndex = 4
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        'PrintToolStripButton
        '
        Me.PrintToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PrintToolStripButton.Image = Global.ZALANI.My.Resources.Resources.Excel_icon
        Me.PrintToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PrintToolStripButton.Name = "PrintToolStripButton"
        Me.PrintToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PrintToolStripButton.Text = "&Print"
        '
        'TOOLREFRESH
        '
        Me.TOOLREFRESH.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TOOLREFRESH.Image = Global.ZALANI.My.Resources.Resources.refresh1
        Me.TOOLREFRESH.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLREFRESH.Name = "TOOLREFRESH"
        Me.TOOLREFRESH.Size = New System.Drawing.Size(23, 22)
        Me.TOOLREFRESH.Text = "&Print"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'SalaryDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1284, 581)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "SalaryDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Salary Details"
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
    Friend WithEvents CMDOK As System.Windows.Forms.Button
    Friend WithEvents cmdcancel As System.Windows.Forms.Button
    Private WithEvents gridbilldetails As DevExpress.XtraGrid.GridControl
    Private WithEvents gridbill As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents gsrno As DevExpress.XtraGrid.Columns.GridColumn
    Private WithEvents GDATE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GEMPNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GMONTH As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GWORKDAYS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GPAYDAYS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GLEAVE As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDED As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GTOTALEAR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNETT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GREMARKS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents GLEDGERNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GLOANLEDGERNAME As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GADVANCETAKEN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TOOLREFRESH As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents GLOANEMI As DevExpress.XtraGrid.Columns.GridColumn
End Class
