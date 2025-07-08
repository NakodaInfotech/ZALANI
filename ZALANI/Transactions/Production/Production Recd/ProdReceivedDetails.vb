Imports BL
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid

Public Class ProdReceivedDetails

    Public EDIT As Boolean
    Dim TEMPPRODRECDNO As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub ProdReceivedDetails_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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

    Private Sub ProdReceivedDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'SALE INVOICE'")
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
            dt = obj.search("ISNULL(PRODUCTRECEIVED.RECD_NO, 0) AS TEMPPRODRECDNO, ISNULL(OPERATORMASTER.OPERATOR_name, '') AS OPERATOR, ISNULL(MACHINEMASTER.MACHINE_NAME, '') AS MACHINE, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT, PRODUCTRECEIVED.RECD_RECDDATE AS RECDDATE, PRODUCTRECEIVED.RECD_JODATE AS JODATE, ISNULL(PRODUCTRECEIVED.RECD_JOTYPE, '') AS JOTYPE, PRODUCTRECEIVED.RECD_SODATE AS SODATE, ISNULL(PRODUCTRECEIVED.RECD_SOTYPE, '') AS SOTYPE, ISNULL(PRODUCTRECEIVED.RECD_PROFORMANO, '') AS PROFORMANO, ISNULL(PRODUCTRECEIVED.RECD_JONO, '') AS JONO, ISNULL(PRODUCTRECEIVED.RECD_JOSRNO, '') AS JOSRNO, ISNULL(PRODUCTRECEIVED.RECD_SONO, '') AS SONO, ISNULL(PRODUCTRECEIVED.RECD_REMARK, '') AS REMARK, ISNULL(PRODUCTRECEIVED.RECD_ISSUENO, '') AS ISSUENO, PRODUCTRECEIVED.RECD_ISSUEDATE AS ISSUEDATE, ISNULL(PRODUCTRECEIVED.RECD_SHIFT, '') AS SHIFT, ISNULL(PRODUCTRECEIVED.RECD_HEATINGTIME, '') AS HEATINGTIME, ISNULL(PRODUCTRECEIVED.RECD_RUNNINGTIME, '') AS RUNNINGTIME, ISNULL(PRODUCTRECEIVED.RECD_STOPTIME, '') AS STOPTIME, ISNULL(PRODUCTRECEIVED.RECD_TOTALISSWT, 0) AS TOTALISSWT, ISNULL(PRODUCTRECEIVED.RECD_TOTALRECDWT, 0) AS TOTALRECDWT, ISNULL(PRODUCTRECEIVED.RECD_TOTALBALWT, 0) AS TOTALBALWT, ISNULL(PRODUCTRECEIVED.RECD_TOTALWASWT, 0) AS TOTALWASWT, ISNULL(PRODUCTRECEIVED.RECD_TOTALFINALBALWT, 0) AS TOTALFINALBALWT, ISNULL(PRODUCTRECEIVED.RECD_WASTAGEPERCENTAGE, 0) AS WASTAGEPERCENTAGE, ISNULL(PRODUCTRECEIVED.RECD_TOTALREELNO, 0) AS TOTALREELNO, ISNULL(PRODUCTRECEIVED.RECD_TOTALDIFF, 0) AS TOTALDIFF, ISNULL(PRODUCTRECEIVED.RECD_TOTALROLLNO, 0) AS TOTALROLLNO, ISNULL(PRODUCTRECEIVED.RECD_TOTALISSRECDWT, 0) AS TOTALISSRECDWT, ISNULL(PRODUCTRECEIVED.RECD_TOTALGSM, 0) AS TOTALGSM, ISNULL(PRODUCTRECEIVED_DESC.RECD_GRIDRECDSRNO, 0) AS GRIDPRISSUSRNO, ISNULL(PRODUCTRECEIVED_DESC.RECD_LOTNO, '') AS LOTNO, ISNULL(PRODUCTRECEIVED_DESC.RECD_REELROLLNO, '') AS REELROLLNO, ISNULL(PRODUCTRECEIVED_DESC.RECD_GSM, 0) AS GSM, ISNULL(PRODUCTRECEIVED_DESC.RECD_IGSMDETAILS,'') AS IGSMDETAILS, ISNULL(PRODUCTRECEIVED_DESC.RECD_SIZE, '') AS SIZE, ISNULL(PRODUCTRECEIVED_DESC.RECD_OURQTY, 0) AS OURQTY, ISNULL(PRODUCTRECEIVED_DESC.RECD_DIFF, 0) AS DIFF, ISNULL(GODOWNMASTER.GODOWN_name, '') AS GODOWN, ISNULL(PRODUCTRECEIVED.RECD_TOTALWT, 0) AS TOTALWT, ISNULL(PRODUCTRECEIVED_DESC.RECD_MILLQTY, 0) AS MILLQTY, ISNULL(ITEMMASTER.ITEM_NAME, '') AS FINALQUALITY, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(QUALITYITEMNAME.ITEM_NAME, '') AS QUALITY ", "", " PRODUCTRECEIVED INNER JOIN PRODUCTRECEIVED_DESC ON PRODUCTRECEIVED.RECD_NO = PRODUCTRECEIVED_DESC.RECD_NO AND PRODUCTRECEIVED.RECD_YEARID = PRODUCTRECEIVED_DESC.RECD_YEARID INNER JOIN ITEMMASTER AS QUALITYITEMNAME ON PRODUCTRECEIVED_DESC.RECD_QUALITYID = QUALITYITEMNAME.ITEM_ID LEFT OUTER JOIN LEDGERS ON PRODUCTRECEIVED.RECD_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN ITEMMASTER AS ITEMMASTER ON PRODUCTRECEIVED.RECD_FINALQUALITYID = ITEMMASTER.item_id LEFT OUTER JOIN UNITMASTER ON PRODUCTRECEIVED_DESC.RECD_UNITID = UNITMASTER.unit_id LEFT OUTER JOIN MACHINEMASTER ON PRODUCTRECEIVED.RECD_MACHINEID = MACHINEMASTER.MACHINE_ID LEFT OUTER JOIN GODOWNMASTER ON PRODUCTRECEIVED.RECD_GODOWNID = GODOWNMASTER.GODOWN_id LEFT OUTER JOIN OPERATORMASTER ON PRODUCTRECEIVED.RECD_OPERATORID = OPERATORMASTER.OPERATOR_id")
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal TEMPPRODRECDNO As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim OBJISSUE As New ProdReceived
                OBJISSUE.MdiParent = MDIMain
                OBJISSUE.EDIT = editval
                OBJISSUE.TEMPPRODRECDNO = TEMPPRODRECDNO
                OBJISSUE.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton.Click
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
            showform(True, gridbill.GetFocusedRowCellValue("TEMPPRODRECDNO"))
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
                    MsgBox("Enter Proper ProdReceived Nos", MsgBoxStyle.Critical)
                    Exit Sub
                Else
                    If MsgBox("Wish to Mail ProdReceived from " & Val(TXTFROM.Text.Trim) & " To " & Val(TXTTO.Text.Trim) & " ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                    SERVERPROPDIRECT(True)
                End If
            Else
                If MsgBox("Wish to Mail Selected ProdReceived ?", MsgBoxStyle.YesNo) = vbYes Then
                    SERVERPROPSELECTED(True)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub TOOLWHATSAPP_Click(sender As Object, e As EventArgs) Handles TOOLWHATSAPP.Click
        Try
            If (Val(TXTFROM.Text.Trim) = 0 Or Val(TXTTO.Text.Trim) = 0 Or Val(TXTCOPIES.Text.Trim) = 0) AndAlso gridbill.SelectedRowsCount = 0 Then Exit Sub
            'IF WE HAVE SELECTED FROM AND TO THEN WORK WITH THE CURRENT CODE ELSE GO FOR SELECTED ENTRIES CODE
            If Val(TXTFROM.Text.Trim) > 0 And Val(TXTTO.Text.Trim) > 0 Then
                If Val(TXTFROM.Text.Trim) > Val(TXTTO.Text.Trim) Then
                    MsgBox("Enter Proper GRN Nos", MsgBoxStyle.Critical)
                    Exit Sub
                Else
                    If MsgBox("Wish to Whatsapp GRN from " & Val(TXTFROM.Text.Trim) & " To " & Val(TXTTO.Text.Trim) & " ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                    SERVERPROPDIRECT(False, True)
                End If
            Else
                If MsgBox("Wish to Whatsapp Selected GRN ?", MsgBoxStyle.YesNo) = vbYes Then
                    SERVERPROPSELECTED(False, True)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLPRINT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLPRINT.Click
        Try
            If (Val(TXTFROM.Text.Trim) = 0 Or Val(TXTTO.Text.Trim) = 0 Or Val(TXTCOPIES.Text.Trim) = 0) AndAlso gridbill.SelectedRowsCount = 0 Then Exit Sub


            'IF WE HAVE SELECTED FROM AND TO THEN WORK WITH THE CURRENT CODE ELSE GO FOR SELECTED ENTRIES CODE
            If Val(TXTFROM.Text.Trim) > 0 And Val(TXTTO.Text.Trim) > 0 Then
                If Val(TXTFROM.Text.Trim) > Val(TXTTO.Text.Trim) Then
                    MsgBox("Enter Proper ProdReceived Nos", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                If MsgBox("Wish to Print ProdReceived from " & TXTFROM.Text.Trim & " To " & TXTTO.Text.Trim & " ?", MsgBoxStyle.YesNo) = vbYes Then
                    SERVERPROPDIRECT()
                End If
            Else
                If MsgBox("Wish to Print Selected ProdReceived Note ?", MsgBoxStyle.YesNo) = vbYes Then
                    SERVERPROPSELECTED()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SERVERPROPDIRECT(Optional ByVal INVOICEMAIL As Boolean = False, Optional ByVal WHATSAPP As Boolean = False)
        Try

            Dim PRINTPARTYDESIGN As Boolean = False
            Dim ALATTACHMENT As New ArrayList
            Dim FILENAME As New ArrayList
            If INVOICEMAIL = False And WHATSAPP = False Then
                If PRINTDIALOG.ShowDialog = DialogResult.OK Then PRINTDOC.PrinterSettings = PRINTDIALOG.PrinterSettings Else Exit Sub
            End If
            For I As Integer = Val(TXTFROM.Text.Trim) To Val(TXTTO.Text.Trim)
                Dim OBJPO As New ProductionDesign
                OBJPO.MdiParent = MDIMain
                OBJPO.DIRECTPRINT = True
                OBJPO.FRMSTRING = "PRODREC"
                OBJPO.DIRECTMAIL = INVOICEMAIL
                OBJPO.DIRECTWHATSAPP = WHATSAPP
                OBJPO.PRINTSETTING = PRINTDIALOG
                OBJPO.FORMULA = "{PRODUCTRECEIVED.RECD_NO}=" & Val(I) & " and {PRODUCTRECEIVED.RECD_YEARID}=" & YearId
                OBJPO.PRODNO = Val(I)
                OBJPO.NOOFCOPIES = Val(TXTCOPIES.Text.Trim)
                OBJPO.Show()
                OBJPO.Close()

                ALATTACHMENT.Add(Application.StartupPath & "\ProdRecdReport_" & I & ".pdf")
                FILENAME.Add("ProdRecdReport_" & I & ".pdf")
            Next

            If INVOICEMAIL Then
                Dim OBJMAIL As New SendMail
                OBJMAIL.ALATTACHMENT = ALATTACHMENT
                OBJMAIL.subject = "PRODUCTION"
                OBJMAIL.ShowDialog()
            End If

            If WHATSAPP = True Then
                Dim OBJWHATSAPP As New SendMultipleWhatsapp
                OBJWHATSAPP.PATH = ALATTACHMENT
                OBJWHATSAPP.FILENAME = FILENAME
                OBJWHATSAPP.ShowDialog()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SERVERPROPSELECTED(Optional ByVal INVOICEMAIL As Boolean = False, Optional ByVal WHATSAPP As Boolean = False)
        Try

            Dim ALATTACHMENT As New ArrayList
            Dim FILENAME As New ArrayList
            If INVOICEMAIL = False And WHATSAPP = False Then
                If PRINTDIALOG.ShowDialog = DialogResult.OK Then PRINTDOC.PrinterSettings = PRINTDIALOG.PrinterSettings Else Exit Sub
            End If
            Dim SELECTEDROWS As Int32() = gridbill.GetSelectedRows()
            For I As Integer = 0 To Val(SELECTEDROWS.Length - 1)
                Dim ROW As DataRow = gridbill.GetDataRow(SELECTEDROWS(I))

                Dim OBJPO As New ProductionDesign
                OBJPO.MdiParent = MDIMain
                OBJPO.DIRECTPRINT = True
                OBJPO.FRMSTRING = "PRODREC"
                OBJPO.DIRECTMAIL = INVOICEMAIL
                OBJPO.DIRECTWHATSAPP = WHATSAPP
                OBJPO.PRINTSETTING = PRINTDIALOG
                OBJPO.FORMULA = "{PRODUCTRECEIVED.RECD_NO}=" & Val(ROW("TEMPPRODRECDNO")) & " and {PRODUCTRECEIVED.RECD_YEARID}=" & YearId
                OBJPO.PRODNO = Val(ROW("TEMPPRODRECDNO"))
                OBJPO.NOOFCOPIES = Val(TXTCOPIES.Text.Trim)
                OBJPO.Show()
                OBJPO.Close()
                ALATTACHMENT.Add(Application.StartupPath & "\ProdRecdReport_" & Val(ROW("TEMPPRODRECDNO")) & ".pdf")
                FILENAME.Add("ProdRecdReport_" & Val(ROW("TEMPPRODRECDNO")) & ".pdf")
            Next

            If INVOICEMAIL Then
                Dim OBJMAIL As New SendMail
                OBJMAIL.ALATTACHMENT = ALATTACHMENT
                OBJMAIL.subject = "PRODUCTION"
                OBJMAIL.ShowDialog()
            End If

            If WHATSAPP = True Then
                Dim OBJWHATSAPP As New SendWhatsapp
                OBJWHATSAPP.PATH = ALATTACHMENT
                OBJWHATSAPP.FILENAME = FILENAME
                OBJWHATSAPP.ShowDialog()
            End If
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
            showform(True, gridbill.GetFocusedRowCellValue("TEMPPRODRECDNO"))
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
    Private Sub TOOLEXCEL_Click(sender As Object, e As EventArgs) Handles TOOLEXCEL.Click
        Try
            Dim PATH As String = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\ProdReceived Details.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            Dim PERIOD As String = ""
            PERIOD = AccFrom & " - " & AccTo

            opti.SheetName = "ProdReceived Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "ProdReceived Details", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)

        Catch ex As Exception
            MsgBox("ProdReceived Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

End Class