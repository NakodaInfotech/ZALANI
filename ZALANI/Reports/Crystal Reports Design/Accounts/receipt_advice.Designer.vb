﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class receipt_advice
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
        Me.CRPO = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.sendmailtool = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.TOOLWHATSAPP = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CRPO
        '
        Me.CRPO.ActiveViewIndex = -1
        Me.CRPO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRPO.Cursor = System.Windows.Forms.Cursors.Default
        Me.CRPO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CRPO.EnableDrillDown = False
        Me.CRPO.Location = New System.Drawing.Point(0, 25)
        Me.CRPO.Name = "CRPO"
        Me.CRPO.SelectionFormula = ""
        Me.CRPO.Size = New System.Drawing.Size(485, 464)
        Me.CRPO.TabIndex = 205
        Me.CRPO.ViewTimeSelectionFormula = ""
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sendmailtool, Me.ToolStripSeparator1, Me.TOOLWHATSAPP, Me.ToolStripSeparator2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(485, 25)
        Me.ToolStrip1.TabIndex = 204
        Me.ToolStrip1.Text = "v"
        '
        'sendmailtool
        '
        Me.sendmailtool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.sendmailtool.Image = Global.ZALANI.My.Resources.Resources.email_initiator
        Me.sendmailtool.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.sendmailtool.Name = "sendmailtool"
        Me.sendmailtool.Size = New System.Drawing.Size(23, 22)
        Me.sendmailtool.Text = "Send E-Mail"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'TOOLWHATSAPP
        '
        Me.TOOLWHATSAPP.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TOOLWHATSAPP.Image = Global.ZALANI.My.Resources.Resources.WHATSAPP
        Me.TOOLWHATSAPP.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TOOLWHATSAPP.Name = "TOOLWHATSAPP"
        Me.TOOLWHATSAPP.Size = New System.Drawing.Size(23, 22)
        Me.TOOLWHATSAPP.Text = "&Whatsapp"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'receipt_advice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(485, 489)
        Me.Controls.Add(Me.CRPO)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "receipt_advice"
        Me.Text = "receipt_advice"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CRPO As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents sendmailtool As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents TOOLWHATSAPP As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
End Class
