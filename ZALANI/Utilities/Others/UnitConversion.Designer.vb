<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UnitConversion
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
        Me.components = New System.ComponentModel.Container()
        Me.BlendPanel1 = New VbPowerPack.BlendPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdok = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.CMBTOUNIT = New System.Windows.Forms.ComboBox()
        Me.LBLUNIT2 = New System.Windows.Forms.Label()
        Me.LBLVALUE = New System.Windows.Forms.Label()
        Me.TXTVALUE = New System.Windows.Forms.TextBox()
        Me.CMBFROMUNIT = New System.Windows.Forms.ComboBox()
        Me.LBLUNIT1 = New System.Windows.Forms.Label()
        Me.Ep = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TXTUNITNO = New System.Windows.Forms.TextBox()
        Me.BlendPanel1.SuspendLayout()
        CType(Me.Ep, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BlendPanel1
        '
        Me.BlendPanel1.Blend = New VbPowerPack.BlendFill(VbPowerPack.BlendStyle.Vertical, System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(248, Byte), Integer)), System.Drawing.SystemColors.Window)
        Me.BlendPanel1.Controls.Add(Me.TXTUNITNO)
        Me.BlendPanel1.Controls.Add(Me.Label1)
        Me.BlendPanel1.Controls.Add(Me.cmdok)
        Me.BlendPanel1.Controls.Add(Me.cmdexit)
        Me.BlendPanel1.Controls.Add(Me.CMBTOUNIT)
        Me.BlendPanel1.Controls.Add(Me.LBLUNIT2)
        Me.BlendPanel1.Controls.Add(Me.LBLVALUE)
        Me.BlendPanel1.Controls.Add(Me.TXTVALUE)
        Me.BlendPanel1.Controls.Add(Me.CMBFROMUNIT)
        Me.BlendPanel1.Controls.Add(Me.LBLUNIT1)
        Me.BlendPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BlendPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BlendPanel1.Name = "BlendPanel1"
        Me.BlendPanel1.Size = New System.Drawing.Size(410, 175)
        Me.BlendPanel1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(141, 32)
        Me.Label1.TabIndex = 159
        Me.Label1.Text = "CONVERTING  UNIT"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdok
        '
        Me.cmdok.BackColor = System.Drawing.Color.Transparent
        Me.cmdok.FlatAppearance.BorderSize = 0
        Me.cmdok.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdok.ForeColor = System.Drawing.Color.Black
        Me.cmdok.Location = New System.Drawing.Point(125, 136)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(80, 28)
        Me.cmdok.TabIndex = 157
        Me.cmdok.Text = "&Save"
        Me.cmdok.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Transparent
        Me.cmdexit.FlatAppearance.BorderSize = 0
        Me.cmdexit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Location = New System.Drawing.Point(211, 136)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(80, 28)
        Me.cmdexit.TabIndex = 158
        Me.cmdexit.Text = "E&xit"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'CMBTOUNIT
        '
        Me.CMBTOUNIT.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBTOUNIT.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBTOUNIT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBTOUNIT.FormattingEnabled = True
        Me.CMBTOUNIT.Location = New System.Drawing.Point(178, 70)
        Me.CMBTOUNIT.MaxDropDownItems = 14
        Me.CMBTOUNIT.Name = "CMBTOUNIT"
        Me.CMBTOUNIT.Size = New System.Drawing.Size(115, 22)
        Me.CMBTOUNIT.TabIndex = 155
        '
        'LBLUNIT2
        '
        Me.LBLUNIT2.BackColor = System.Drawing.Color.Transparent
        Me.LBLUNIT2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLUNIT2.ForeColor = System.Drawing.Color.Black
        Me.LBLUNIT2.Location = New System.Drawing.Point(122, 72)
        Me.LBLUNIT2.Name = "LBLUNIT2"
        Me.LBLUNIT2.Size = New System.Drawing.Size(50, 18)
        Me.LBLUNIT2.TabIndex = 156
        Me.LBLUNIT2.Text = "To Unit"
        Me.LBLUNIT2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LBLVALUE
        '
        Me.LBLVALUE.BackColor = System.Drawing.Color.Transparent
        Me.LBLVALUE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLVALUE.ForeColor = System.Drawing.Color.Black
        Me.LBLVALUE.Location = New System.Drawing.Point(128, 98)
        Me.LBLVALUE.Name = "LBLVALUE"
        Me.LBLVALUE.Size = New System.Drawing.Size(44, 20)
        Me.LBLVALUE.TabIndex = 154
        Me.LBLVALUE.Text = "Value"
        Me.LBLVALUE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TXTVALUE
        '
        Me.TXTVALUE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTVALUE.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTVALUE.Location = New System.Drawing.Point(178, 96)
        Me.TXTVALUE.Name = "TXTVALUE"
        Me.TXTVALUE.Size = New System.Drawing.Size(75, 22)
        Me.TXTVALUE.TabIndex = 153
        '
        'CMBFROMUNIT
        '
        Me.CMBFROMUNIT.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CMBFROMUNIT.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBFROMUNIT.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBFROMUNIT.FormattingEnabled = True
        Me.CMBFROMUNIT.Location = New System.Drawing.Point(178, 44)
        Me.CMBFROMUNIT.MaxDropDownItems = 14
        Me.CMBFROMUNIT.Name = "CMBFROMUNIT"
        Me.CMBFROMUNIT.Size = New System.Drawing.Size(115, 22)
        Me.CMBFROMUNIT.TabIndex = 151
        '
        'LBLUNIT1
        '
        Me.LBLUNIT1.BackColor = System.Drawing.Color.Transparent
        Me.LBLUNIT1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLUNIT1.ForeColor = System.Drawing.Color.Black
        Me.LBLUNIT1.Location = New System.Drawing.Point(74, 46)
        Me.LBLUNIT1.Name = "LBLUNIT1"
        Me.LBLUNIT1.Size = New System.Drawing.Size(98, 18)
        Me.LBLUNIT1.TabIndex = 152
        Me.LBLUNIT1.Text = "From Unit"
        Me.LBLUNIT1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Ep
        '
        Me.Ep.BlinkRate = 0
        Me.Ep.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.Ep.ContainerControl = Me
        '
        'TXTUNITNO
        '
        Me.TXTUNITNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTUNITNO.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTUNITNO.Location = New System.Drawing.Point(345, 17)
        Me.TXTUNITNO.Name = "TXTUNITNO"
        Me.TXTUNITNO.Size = New System.Drawing.Size(16, 22)
        Me.TXTUNITNO.TabIndex = 160
        Me.TXTUNITNO.Visible = False
        '
        'UnitConversion
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(410, 175)
        Me.Controls.Add(Me.BlendPanel1)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "UnitConversion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "UnitConversion"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.BlendPanel1.ResumeLayout(False)
        Me.BlendPanel1.PerformLayout()
        CType(Me.Ep, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BlendPanel1 As VbPowerPack.BlendPanel
    Public WithEvents CMBFROMUNIT As ComboBox
    Friend WithEvents LBLUNIT1 As Label
    Public WithEvents CMBTOUNIT As ComboBox
    Friend WithEvents LBLUNIT2 As Label
    Friend WithEvents LBLVALUE As Label
    Friend WithEvents TXTVALUE As TextBox
    Friend WithEvents cmdok As Button
    Friend WithEvents cmdexit As Button
    Friend WithEvents Ep As ErrorProvider
    Friend WithEvents Label1 As Label
    Friend WithEvents TXTUNITNO As TextBox
End Class
