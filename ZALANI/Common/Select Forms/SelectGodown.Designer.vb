﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectGodown
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.CMDREFRESH = New System.Windows.Forms.Button()
        Me.cmbname = New System.Windows.Forms.ComboBox()
        Me.rbpart = New System.Windows.Forms.RadioButton()
        Me.rbstart = New System.Windows.Forms.RadioButton()
        Me.CMDOK = New System.Windows.Forms.Button()
        Me.CMDEXIT = New System.Windows.Forms.Button()
        Me.TXTTEMPNAME = New System.Windows.Forms.TextBox()
        Me.TXTNAME = New System.Windows.Forms.TextBox()
        Me.GRIDGODOWN = New System.Windows.Forms.DataGridView()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.GRIDGODOWN, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CMDREFRESH)
        Me.BlendPanel1.Controls.Add(Me.cmbname)
        Me.BlendPanel1.Controls.Add(Me.rbpart)
        Me.BlendPanel1.Controls.Add(Me.rbstart)
        Me.BlendPanel1.Controls.Add(Me.CMDOK)
        Me.BlendPanel1.Controls.Add(Me.CMDEXIT)
        Me.BlendPanel1.Controls.Add(Me.TXTTEMPNAME)
        Me.BlendPanel1.Controls.Add(Me.TXTNAME)
        Me.BlendPanel1.Controls.Add(Me.GRIDGODOWN)
        Me.BlendPanel1.Controls.Add(Me.Label8)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(384, 471)
        Me.BlendPanel1.TabIndex = 3
        '
        'CMDREFRESH
        '
        Me.CMDREFRESH.BackColor = System.Drawing.Color.Transparent
        Me.CMDREFRESH.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDREFRESH.FlatAppearance.BorderSize = 0
        Me.CMDREFRESH.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDREFRESH.ForeColor = System.Drawing.Color.Black
        Me.CMDREFRESH.Location = New System.Drawing.Point(146, 425)
        Me.CMDREFRESH.Name = "CMDREFRESH"
        Me.CMDREFRESH.Size = New System.Drawing.Size(80, 28)
        Me.CMDREFRESH.TabIndex = 355
        Me.CMDREFRESH.Text = "&Refresh"
        Me.CMDREFRESH.UseVisualStyleBackColor = False
        '
        'cmbname
        '
        Me.cmbname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbname.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbname.FormattingEnabled = True
        Me.cmbname.Items.AddRange(New Object() {"", "Name"})
        Me.cmbname.Location = New System.Drawing.Point(23, 54)
        Me.cmbname.MaxDropDownItems = 14
        Me.cmbname.Name = "cmbname"
        Me.cmbname.Size = New System.Drawing.Size(71, 22)
        Me.cmbname.TabIndex = 6
        '
        'rbpart
        '
        Me.rbpart.AutoSize = True
        Me.rbpart.BackColor = System.Drawing.Color.Transparent
        Me.rbpart.Checked = True
        Me.rbpart.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbpart.Location = New System.Drawing.Point(173, 30)
        Me.rbpart.Name = "rbpart"
        Me.rbpart.Size = New System.Drawing.Size(113, 18)
        Me.rbpart.TabIndex = 5
        Me.rbpart.TabStop = True
        Me.rbpart.Text = "Any Part of Field"
        Me.rbpart.UseVisualStyleBackColor = False
        '
        'rbstart
        '
        Me.rbstart.AutoSize = True
        Me.rbstart.BackColor = System.Drawing.Color.Transparent
        Me.rbstart.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbstart.Location = New System.Drawing.Point(173, 8)
        Me.rbstart.Name = "rbstart"
        Me.rbstart.Size = New System.Drawing.Size(80, 18)
        Me.rbstart.TabIndex = 4
        Me.rbstart.Text = "From Start"
        Me.rbstart.UseVisualStyleBackColor = False
        '
        'CMDOK
        '
        Me.CMDOK.BackColor = System.Drawing.Color.Transparent
        Me.CMDOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDOK.FlatAppearance.BorderSize = 0
        Me.CMDOK.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDOK.ForeColor = System.Drawing.Color.Black
        Me.CMDOK.Location = New System.Drawing.Point(64, 425)
        Me.CMDOK.Name = "CMDOK"
        Me.CMDOK.Size = New System.Drawing.Size(80, 28)
        Me.CMDOK.TabIndex = 2
        Me.CMDOK.Text = "&Ok"
        Me.CMDOK.UseVisualStyleBackColor = False
        '
        'CMDEXIT
        '
        Me.CMDEXIT.BackColor = System.Drawing.Color.Transparent
        Me.CMDEXIT.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CMDEXIT.FlatAppearance.BorderSize = 0
        Me.CMDEXIT.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDEXIT.ForeColor = System.Drawing.Color.Black
        Me.CMDEXIT.Location = New System.Drawing.Point(228, 425)
        Me.CMDEXIT.Name = "CMDEXIT"
        Me.CMDEXIT.Size = New System.Drawing.Size(80, 28)
        Me.CMDEXIT.TabIndex = 3
        Me.CMDEXIT.Text = "E&xit"
        Me.CMDEXIT.UseVisualStyleBackColor = False
        '
        'TXTTEMPNAME
        '
        Me.TXTTEMPNAME.BackColor = System.Drawing.Color.White
        Me.TXTTEMPNAME.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTTEMPNAME.ForeColor = System.Drawing.Color.Black
        Me.TXTTEMPNAME.Location = New System.Drawing.Point(265, 56)
        Me.TXTTEMPNAME.Name = "TXTTEMPNAME"
        Me.TXTTEMPNAME.ReadOnly = True
        Me.TXTTEMPNAME.Size = New System.Drawing.Size(27, 20)
        Me.TXTTEMPNAME.TabIndex = 240
        Me.TXTTEMPNAME.TabStop = False
        Me.TXTTEMPNAME.Visible = False
        '
        'TXTNAME
        '
        Me.TXTNAME.BackColor = System.Drawing.Color.White
        Me.TXTNAME.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTNAME.ForeColor = System.Drawing.Color.Black
        Me.TXTNAME.Location = New System.Drawing.Point(95, 54)
        Me.TXTNAME.Name = "TXTNAME"
        Me.TXTNAME.Size = New System.Drawing.Size(168, 22)
        Me.TXTNAME.TabIndex = 0
        '
        'GRIDGODOWN
        '
        Me.GRIDGODOWN.AllowUserToAddRows = False
        Me.GRIDGODOWN.AllowUserToDeleteRows = False
        Me.GRIDGODOWN.AllowUserToResizeColumns = False
        Me.GRIDGODOWN.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        Me.GRIDGODOWN.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GRIDGODOWN.BackgroundColor = System.Drawing.Color.White
        Me.GRIDGODOWN.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.GRIDGODOWN.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GRIDGODOWN.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GRIDGODOWN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(248, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GRIDGODOWN.DefaultCellStyle = DataGridViewCellStyle3
        Me.GRIDGODOWN.GridColor = System.Drawing.SystemColors.ControlText
        Me.GRIDGODOWN.Location = New System.Drawing.Point(23, 77)
        Me.GRIDGODOWN.Margin = New System.Windows.Forms.Padding(2)
        Me.GRIDGODOWN.MultiSelect = False
        Me.GRIDGODOWN.Name = "GRIDGODOWN"
        Me.GRIDGODOWN.ReadOnly = True
        Me.GRIDGODOWN.RowHeadersVisible = False
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        Me.GRIDGODOWN.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.GRIDGODOWN.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.GRIDGODOWN.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GRIDGODOWN.Size = New System.Drawing.Size(335, 335)
        Me.GRIDGODOWN.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Calibri", 14.0!)
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(18, 11)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(125, 23)
        Me.Label8.TabIndex = 210
        Me.Label8.Text = "Select Godown"
        '
        'SelectGodown
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(384, 471)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "SelectGodown"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select Godown"
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.GRIDGODOWN, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents CMDREFRESH As System.Windows.Forms.Button
    Friend WithEvents cmbname As System.Windows.Forms.ComboBox
    Friend WithEvents rbpart As System.Windows.Forms.RadioButton
    Friend WithEvents rbstart As System.Windows.Forms.RadioButton
    Friend WithEvents CMDOK As System.Windows.Forms.Button
    Friend WithEvents CMDEXIT As System.Windows.Forms.Button
    Friend WithEvents TXTTEMPNAME As System.Windows.Forms.TextBox
    Friend WithEvents TXTNAME As System.Windows.Forms.TextBox
    Friend WithEvents GRIDGODOWN As System.Windows.Forms.DataGridView
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
