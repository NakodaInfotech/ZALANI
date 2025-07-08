Imports BL
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid

Public Class GRNDetails

    Public EDIT As Boolean
    Dim TEMPGRNNO As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub GRNDetails_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            ElseIf e.KeyCode = Keys.N And e.Control = True Then
                showform(False, 0)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GRNDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'GRN'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Sub fillgrid()
        Try
            Dim obj As New ClsCommonMaster
            Dim dt As DataTable
            dt = obj.search("ISNULL(GRN.GRN_NO, 0) AS GRNNO, GRN.GRN_DATE AS GRNDATE, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(GRN.GRN_PONO, 0) AS PONO, GRN.GRN_PODATE AS PODATE, ISNULL(GRN.GRN_CHALLANNO, 0) AS CHALLANNO, GRN.GRN_CHALLANDT AS CHALLANDATE, ISNULL(GODOWNMASTER.GODOWN_name, '') AS GODOWN, ISNULL(GRN.GRN_PARTYREFNO, 0) AS PARTYREFNO, ISNULL(GRN.GRN_TOTALQTY, 0) AS TOTALQTY, ISNULL(GRN.GRN_TOTALREELNO, 0) AS TOTALREELNO, ISNULL(GRN.GRN_REMARKS, '') AS REMARKS, ISNULL(GRN.GRN_DONE, 0) AS DONE, ISNULL(GRN_DESC.GRN_GRIDSRNO, 0) AS SRNO, ISNULL(ITEMMASTER.ITEM_NAME, '') AS QUALITY, ISNULL(GRN_DESC.GRN_LOTNO, 0) AS LOTNO, ISNULL(GRN_DESC.GRN_REELNO, 0) AS REELNO, ISNULL(GRN_DESC.GRN_GSM, '') AS GSM, ISNULL(GRN_DESC.GRN_SIZE, 0) AS SIZE, ISNULL(GRN_DESC.GRN_QTY, 0) AS QTY, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT, ISNULL(GRN_DESC.GRN_OUTQTY, 0) AS OUTQTY, ISNULL(GRN_DESC.GRN_CHECKDONE, 0) AS CHECKDONE", "", "GRN INNER JOIN GODOWNMASTER ON GRN.GRN_GODOWNID = GODOWNMASTER.GODOWN_id INNER JOIN LEDGERS ON GRN.GRN_LEDGERID = LEDGERS.Acc_id INNER JOIN GRN_DESC ON GRN.GRN_NO = GRN_DESC.GRN_NO AND GRN.GRN_YEARID = GRN_DESC.GRN_YEARID INNER JOIN ITEMMASTER  ON ITEMMASTER.item_id = GRN_DESC.GRN_ITEMID LEFT OUTER JOIN UNITMASTER ON GRN_DESC.GRN_UNITID = UNITMASTER.unit_id")
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Sub showform(ByVal editval As Boolean, ByVal GRNNO As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim objPO As New GRN
                objPO.MdiParent = MDIMain
                objPO.EDIT = editval
                objPO.TEMPGRNNO = GRNNO
                objPO.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Try
            If USERADD = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            showform(False, 0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbilldetails_DoubleClick(sender As Object, e As EventArgs) Handles gridbilldetails.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("GRNNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub TOOLMAIL_Click(sender As Object, e As EventArgs) Handles TOOLMAIL.Click
        Try
            If (Val(TXTFROM.Text.Trim) = 0 Or Val(TXTTO.Text.Trim) = 0 Or Val(TXTCOPIES.Text.Trim) = 0) AndAlso gridbill.SelectedRowsCount = 0 Then Exit Sub
            'IF WE HAVE SELECTED FROM AND TO THEN WORK WITH THE CURRENT CODE ELSE GO FOR SELECTED ENTRIES CODE
            If Val(TXTFROM.Text.Trim) > 0 And Val(TXTTO.Text.Trim) > 0 Then
                If Val(TXTFROM.Text.Trim) > Val(TXTTO.Text.Trim) Then
                    MsgBox("Enter Proper GRN Nos", MsgBoxStyle.Critical)
                    Exit Sub
                Else
                    If MsgBox("Wish to Mail GRN from " & Val(TXTFROM.Text.Trim) & " To " & Val(TXTTO.Text.Trim) & " ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                    SERVERPROPDIRECT(True)
                End If
            Else
                If MsgBox("Wish to Mail Selected GRN ?", MsgBoxStyle.YesNo) = vbYes Then
                    SERVERPROPSELECTED(True)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub TOOLWHATSAPP_Click(sender As Object, e As EventArgs) Handles TOOLWHATSAPP.Click
        'Try
        '    If (Val(TXTFROM.Text.Trim) = 0 Or Val(TXTTO.Text.Trim) = 0 Or Val(TXTCOPIES.Text.Trim) = 0) AndAlso gridbill.SelectedRowsCount = 0 Then Exit Sub
        '    'IF WE HAVE SELECTED FROM AND TO THEN WORK WITH THE CURRENT CODE ELSE GO FOR SELECTED ENTRIES CODE
        '    If Val(TXTFROM.Text.Trim) > 0 And Val(TXTTO.Text.Trim) > 0 Then
        '        If Val(TXTFROM.Text.Trim) > Val(TXTTO.Text.Trim) Then
        '            MsgBox("Enter Proper GRN Nos", MsgBoxStyle.Critical)
        '            Exit Sub
        '        Else
        '            If MsgBox("Wish to Whatsapp GRN from " & Val(TXTFROM.Text.Trim) & " To " & Val(TXTTO.Text.Trim) & " ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        '            SERVERPROPDIRECT(False, True)
        '        End If
        '    Else
        '        If MsgBox("Wish to Whatsapp Selected GRN ?", MsgBoxStyle.YesNo) = vbYes Then
        '            SERVERPROPSELECTED(False, True)
        '        End If
        '    End If
        'Catch ex As Exception
        '    Throw ex
        'End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If (Val(TXTFROM.Text.Trim) = 0 Or Val(TXTTO.Text.Trim) = 0 Or Val(TXTCOPIES.Text.Trim) = 0) AndAlso gridbill.SelectedRowsCount = 0 Then Exit Sub


            'IF WE HAVE SELECTED FROM AND TO THEN WORK WITH THE CURRENT CODE ELSE GO FOR SELECTED ENTRIES CODE
            If Val(TXTFROM.Text.Trim) > 0 And Val(TXTTO.Text.Trim) > 0 Then
                If Val(TXTFROM.Text.Trim) > Val(TXTTO.Text.Trim) Then
                    MsgBox("Enter Proper GRN Nos", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                If MsgBox("Wish to Print GRN from " & TXTFROM.Text.Trim & " To " & TXTTO.Text.Trim & " ?", MsgBoxStyle.YesNo) = vbYes Then
                    SERVERPROPDIRECT()
                End If
            Else
                If MsgBox("Wish to Print Selected GRN Note ?", MsgBoxStyle.YesNo) = vbYes Then
                    SERVERPROPSELECTED()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub



    Sub SERVERPROPDIRECT(Optional ByVal INVOICEMAIL As Boolean = False, Optional ByVal WHATSAPP As Boolean = False)
        Try

            'Dim PRINTPARTYDESIGN As Boolean = False
            'If ClientName = "MAHAVIRPOLYCOT" And MsgBox("Print PO With Party Design?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then PRINTPARTYDESIGN = True Else PRINTPARTYDESIGN = False
            'Dim ALATTACHMENT As New ArrayList
            'Dim FILENAME As New ArrayList
            'If INVOICEMAIL = False And WHATSAPP = False Then
            '    If PrintDialog.ShowDialog = DialogResult.OK Then PRINTDOC.PrinterSettings = PrintDialog.PrinterSettings Else Exit Sub
            'End If
            'For I As Integer = Val(TXTFROM.Text.Trim) To Val(TXTTO.Text.Trim)
            '    Dim OBJPO As New PurchaseOrderDesign
            '    OBJPO.MdiParent = MDIMain
            '    OBJPO.DIRECTPRINT = True
            '    OBJPO.FRMSTRING = "POREPORT"
            '    OBJPO.DIRECTMAIL = INVOICEMAIL
            '    OBJPO.DIRECTWHATSAPP = WHATSAPP
            '    OBJPO.PRINTSETTING = PrintDialog
            '    OBJPO.PRINTPARTYDESIGN = PRINTPARTYDESIGN
            '    OBJPO.FORMULA = "{PURCHASEORDER.PO_NO}=" & Val(I) & " and {PURCHASEORDER.PO_yearid}=" & YearId
            '    OBJPO.PONO = Val(I)
            '    OBJPO.NOOFCOPIES = Val(TXTCOPIES.Text.Trim)
            '    OBJPO.Show()
            '    OBJPO.Close()

            '    ALATTACHMENT.Add(Application.StartupPath & "\POREPORT_" & I & ".pdf")
            '    FILENAME.Add("POREPORT_" & I & ".pdf")
            'Next

            'If INVOICEMAIL Then
            '    Dim OBJMAIL As New SendMail
            '    OBJMAIL.ALATTACHMENT = ALATTACHMENT
            '    OBJMAIL.subject = "POREPORT"
            '    OBJMAIL.ShowDialog()
            'End If

            'If WHATSAPP = True Then
            '    Dim OBJWHATSAPP As New SendWhatsapp
            '    OBJWHATSAPP.PATH = ALATTACHMENT
            '    OBJWHATSAPP.FILENAME = FILENAME
            '    OBJWHATSAPP.ShowDialog()
            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Sub SERVERPROPSELECTED(Optional ByVal INVOICEMAIL As Boolean = False, Optional ByVal WHATSAPP As Boolean = False)
        Try

            '    Dim ALATTACHMENT As New ArrayList
            '    Dim FILENAME As New ArrayList
            '    Dim PRINTPARTYDESIGN As Boolean = False
            '    If ClientName = "MAHAVIRPOLYCOT" And MsgBox("Print PO With Party Design?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then PRINTPARTYDESIGN = True Else PRINTPARTYDESIGN = False

            '    If INVOICEMAIL = False And WHATSAPP = False Then
            '        If PrintDialog.ShowDialog = DialogResult.OK Then PRINTDOC.PrinterSettings = PrintDialog.PrinterSettings Else Exit Sub
            '    End If
            '    Dim SELECTEDROWS As Int32() = gridbill.GetSelectedRows()
            '    For I As Integer = 0 To Val(SELECTEDROWS.Length - 1)
            '        Dim ROW As DataRow = gridbill.GetDataRow(SELECTEDROWS(I))

            '        Dim OBJPO As New PurchaseOrderDesign
            '        OBJPO.MdiParent = MDIMain
            '        OBJPO.DIRECTPRINT = True
            '        OBJPO.FRMSTRING = "POREPORT"
            '        OBJPO.DIRECTMAIL = INVOICEMAIL
            '        OBJPO.DIRECTWHATSAPP = WHATSAPP
            '        OBJPO.PRINTSETTING = PrintDialog
            '        OBJPO.PRINTPARTYDESIGN = PRINTPARTYDESIGN
            '        OBJPO.FORMULA = "{PURCHASEORDER.PO_NO}=" & Val(ROW("PONO")) & " and {PURCHASEORDER.PO_yearid}=" & YearId
            '        OBJPO.PONO = Val(ROW("PONO"))
            '        OBJPO.NOOFCOPIES = Val(TXTCOPIES.Text.Trim)
            '        OBJPO.Show()
            '        OBJPO.Close()
            '        ALATTACHMENT.Add(Application.StartupPath & "\POREPORT_" & Val(ROW("PONO")) & ".pdf")
            '        FILENAME.Add("POREPORT_" & Val(ROW("PONO")) & ".pdf")
            '    Next

            '    If INVOICEMAIL Then
            '        Dim OBJMAIL As New SendMail
            '        OBJMAIL.ALATTACHMENT = ALATTACHMENT
            '        OBJMAIL.subject = "POREPORT"
            '        OBJMAIL.ShowDialog()
            '    End If

            '    If WHATSAPP = True Then
            '        Dim OBJWHATSAPP As New SendWhatsapp
            '        OBJWHATSAPP.PATH = ALATTACHMENT
            '        OBJWHATSAPP.FILENAME = FILENAME
            '        OBJWHATSAPP.ShowDialog()
            '    End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub TXTFROM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTFROM.KeyPress, TXTTO.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub TOOLREFRESH_Click(sender As Object, e As EventArgs) Handles TOOLREFRESH.Click
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("PONO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    ''Private Sub gridbill_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles gridbill.RowStyle
    ''    Try
    ''        If e.RowHandle >= 0 Then
    ''            Dim View As GridView = sender
    ''            If View.GetRowCellDisplayText(e.RowHandle, View.Columns("CLOSED")) = "Checked" Then
    ''                e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Bold)
    ''                e.Appearance.BackColor = Color.Yellow
    ''            ElseIf View.GetRowCellDisplayText(e.RowHandle, View.Columns("DONE")) = "Checked" Then
    ''                e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Bold)
    ''                e.Appearance.BackColor = Color.LightGreen
    ''            End If
    ''        End If
    ''    Catch ex As Exception
    ''        Throw ex
    ''    End Try
    ''End Sub
    Private Sub TOOLEXPORT_Click(sender As Object, e As EventArgs) Handles TOOLEXPORT.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\GRN Details.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            Dim PERIOD As String = ""
            PERIOD = AccFrom & " - " & AccTo

            opti.SheetName = "GRN Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "GRN Details", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)

        Catch ex As Exception
            MsgBox("GRN Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub
End Class