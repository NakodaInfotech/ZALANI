﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReconcileData
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
        Me.CHKRECOPURCHASE = New System.Windows.Forms.CheckBox()
        Me.CHKRECONONPURCHASE = New System.Windows.Forms.CheckBox()
        Me.CHKRECOINV = New System.Windows.Forms.CheckBox()
        Me.CHKRECOSTOCK = New System.Windows.Forms.CheckBox()
        Me.CMDOK = New System.Windows.Forms.Button()
        Me.CMDCLEAR = New System.Windows.Forms.Button()
        Me.CMDEXIT = New System.Windows.Forms.Button()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.CHKRECOISSUEPACK = New System.Windows.Forms.CheckBox()
        Me.CHKRECOPROGRAM = New System.Windows.Forms.CheckBox()
        Me.CHKRECOORDER = New System.Windows.Forms.CheckBox()
        Me.CHKRECOPENDINGDATA = New System.Windows.Forms.CheckBox()
        Me.BlendPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CHKRECOPURCHASE
        '
        Me.CHKRECOPURCHASE.AutoSize = True
        Me.CHKRECOPURCHASE.BackColor = System.Drawing.Color.Transparent
        Me.CHKRECOPURCHASE.Location = New System.Drawing.Point(27, 45)
        Me.CHKRECOPURCHASE.Name = "CHKRECOPURCHASE"
        Me.CHKRECOPURCHASE.Size = New System.Drawing.Size(120, 19)
        Me.CHKRECOPURCHASE.TabIndex = 1
        Me.CHKRECOPURCHASE.Text = "Purchase Invoice"
        Me.CHKRECOPURCHASE.UseVisualStyleBackColor = False
        '
        'CHKRECONONPURCHASE
        '
        Me.CHKRECONONPURCHASE.AutoSize = True
        Me.CHKRECONONPURCHASE.BackColor = System.Drawing.Color.Transparent
        Me.CHKRECONONPURCHASE.Location = New System.Drawing.Point(27, 70)
        Me.CHKRECONONPURCHASE.Name = "CHKRECONONPURCHASE"
        Me.CHKRECONONPURCHASE.Size = New System.Drawing.Size(267, 19)
        Me.CHKRECONONPURCHASE.TabIndex = 2
        Me.CHKRECONONPURCHASE.Text = "Non-Purchase | Receipt | Payment | Journal"
        Me.CHKRECONONPURCHASE.UseVisualStyleBackColor = False
        '
        'CHKRECOINV
        '
        Me.CHKRECOINV.AutoSize = True
        Me.CHKRECOINV.BackColor = System.Drawing.Color.Transparent
        Me.CHKRECOINV.Location = New System.Drawing.Point(27, 20)
        Me.CHKRECOINV.Name = "CHKRECOINV"
        Me.CHKRECOINV.Size = New System.Drawing.Size(92, 19)
        Me.CHKRECOINV.TabIndex = 0
        Me.CHKRECOINV.Text = "Sale Invoice"
        Me.CHKRECOINV.UseVisualStyleBackColor = False
        '
        'CHKRECOSTOCK
        '
        Me.CHKRECOSTOCK.AutoSize = True
        Me.CHKRECOSTOCK.BackColor = System.Drawing.Color.Transparent
        Me.CHKRECOSTOCK.Location = New System.Drawing.Point(27, 120)
        Me.CHKRECOSTOCK.Name = "CHKRECOSTOCK"
        Me.CHKRECOSTOCK.Size = New System.Drawing.Size(111, 19)
        Me.CHKRECOSTOCK.TabIndex = 4
        Me.CHKRECOSTOCK.Text = "Reconcile Stock"
        Me.CHKRECOSTOCK.UseVisualStyleBackColor = False
        '
        'CMDOK
        '
        Me.CMDOK.Location = New System.Drawing.Point(16, 236)
        Me.CMDOK.Name = "CMDOK"
        Me.CMDOK.Size = New System.Drawing.Size(80, 28)
        Me.CMDOK.TabIndex = 8
        Me.CMDOK.Text = "&OK"
        Me.CMDOK.UseVisualStyleBackColor = True
        '
        'CMDCLEAR
        '
        Me.CMDCLEAR.Location = New System.Drawing.Point(102, 236)
        Me.CMDCLEAR.Name = "CMDCLEAR"
        Me.CMDCLEAR.Size = New System.Drawing.Size(80, 28)
        Me.CMDCLEAR.TabIndex = 9
        Me.CMDCLEAR.Text = "&Clear"
        Me.CMDCLEAR.UseVisualStyleBackColor = True
        '
        'CMDEXIT
        '
        Me.CMDEXIT.Location = New System.Drawing.Point(188, 236)
        Me.CMDEXIT.Name = "CMDEXIT"
        Me.CMDEXIT.Size = New System.Drawing.Size(80, 28)
        Me.CMDEXIT.TabIndex = 10
        Me.CMDEXIT.Text = "&Exit"
        Me.CMDEXIT.UseVisualStyleBackColor = True
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.CHKRECOISSUEPACK)
        Me.BlendPanel1.Controls.Add(Me.CHKRECOPROGRAM)
        Me.BlendPanel1.Controls.Add(Me.CHKRECOORDER)
        Me.BlendPanel1.Controls.Add(Me.CMDEXIT)
        Me.BlendPanel1.Controls.Add(Me.CMDCLEAR)
        Me.BlendPanel1.Controls.Add(Me.CHKRECOPENDINGDATA)
        Me.BlendPanel1.Controls.Add(Me.CMDOK)
        Me.BlendPanel1.Controls.Add(Me.CHKRECOSTOCK)
        Me.BlendPanel1.Controls.Add(Me.CHKRECOINV)
        Me.BlendPanel1.Controls.Add(Me.CHKRECONONPURCHASE)
        Me.BlendPanel1.Controls.Add(Me.CHKRECOPURCHASE)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(371, 276)
        Me.BlendPanel1.TabIndex = 0
        '
        'CHKRECOISSUEPACK
        '
        Me.CHKRECOISSUEPACK.AutoSize = True
        Me.CHKRECOISSUEPACK.BackColor = System.Drawing.Color.Transparent
        Me.CHKRECOISSUEPACK.Location = New System.Drawing.Point(27, 95)
        Me.CHKRECOISSUEPACK.Name = "CHKRECOISSUEPACK"
        Me.CHKRECOISSUEPACK.Size = New System.Drawing.Size(287, 19)
        Me.CHKRECOISSUEPACK.TabIndex = 3
        Me.CHKRECOISSUEPACK.Text = "Issue To Pack (Please Reconcile Stock after this)"
        Me.CHKRECOISSUEPACK.UseVisualStyleBackColor = False
        '
        'CHKRECOPROGRAM
        '
        Me.CHKRECOPROGRAM.AutoSize = True
        Me.CHKRECOPROGRAM.BackColor = System.Drawing.Color.Transparent
        Me.CHKRECOPROGRAM.Location = New System.Drawing.Point(27, 195)
        Me.CHKRECOPROGRAM.Name = "CHKRECOPROGRAM"
        Me.CHKRECOPROGRAM.Size = New System.Drawing.Size(113, 19)
        Me.CHKRECOPROGRAM.TabIndex = 7
        Me.CHKRECOPROGRAM.Text = "Dyeing Program"
        Me.CHKRECOPROGRAM.UseVisualStyleBackColor = False
        '
        'CHKRECOORDER
        '
        Me.CHKRECOORDER.AutoSize = True
        Me.CHKRECOORDER.BackColor = System.Drawing.Color.Transparent
        Me.CHKRECOORDER.Location = New System.Drawing.Point(27, 170)
        Me.CHKRECOORDER.Name = "CHKRECOORDER"
        Me.CHKRECOORDER.Size = New System.Drawing.Size(147, 19)
        Me.CHKRECOORDER.TabIndex = 6
        Me.CHKRECOORDER.Text = "Sale | Purchase Order"
        Me.CHKRECOORDER.UseVisualStyleBackColor = False
        '
        'CHKRECOPENDINGDATA
        '
        Me.CHKRECOPENDINGDATA.AutoSize = True
        Me.CHKRECOPENDINGDATA.BackColor = System.Drawing.Color.Transparent
        Me.CHKRECOPENDINGDATA.Location = New System.Drawing.Point(27, 145)
        Me.CHKRECOPENDINGDATA.Name = "CHKRECOPENDINGDATA"
        Me.CHKRECOPENDINGDATA.Size = New System.Drawing.Size(187, 19)
        Me.CHKRECOPENDINGDATA.TabIndex = 5
        Me.CHKRECOPENDINGDATA.Text = "Pending Data (GRN / Challan)"
        Me.CHKRECOPENDINGDATA.UseVisualStyleBackColor = False
        '
        'ReconcileData
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(371, 276)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "ReconcileData"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Reconcile Data"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CHKRECOPURCHASE As System.Windows.Forms.CheckBox
    Friend WithEvents CHKRECONONPURCHASE As System.Windows.Forms.CheckBox
    Friend WithEvents CHKRECOINV As System.Windows.Forms.CheckBox
    Friend WithEvents CHKRECOSTOCK As System.Windows.Forms.CheckBox
    Friend WithEvents CMDOK As System.Windows.Forms.Button
    Friend WithEvents CMDCLEAR As System.Windows.Forms.Button
    Friend WithEvents CMDEXIT As System.Windows.Forms.Button
    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Friend WithEvents CHKRECOPENDINGDATA As System.Windows.Forms.CheckBox
    Friend WithEvents CHKRECOORDER As CheckBox
    Friend WithEvents CHKRECOPROGRAM As CheckBox
    Friend WithEvents CHKRECOISSUEPACK As CheckBox
End Class
