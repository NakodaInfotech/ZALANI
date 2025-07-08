
Imports BL
Imports DevExpress.XtraGrid.Views.Grid

Public Class InvoiceMasterDetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public TEMPINVOICENO As String
    Dim DTMAIL As New DataTable
    Dim DTWHATSAPP As New DataTable

    Private Sub cmdexit_Click(sender As Object, e As EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub ProformaInvoiceDetails_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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

    Private Sub InvoiceMasterDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID()
        'Try
        '    Dim OBJDEPT As New ClsInvoiceMaster
        '    OBJDEPT.alParaval.Add(0)
        '    OBJDEPT.alParaval.Add(CmpId)
        '    OBJDEPT.alParaval.Add(YearId)
        '    Dim DT As DataTable = OBJDEPT.SELECTSALEINVOICE()
        '    gridbilldetails.DataSource = DT
        'Catch ex As Exception
        '    Throw ex
        'End Try

        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search("ISNULL(INVOICEMASTER.INVOICE_NO, 0) AS TEMPINVOICENO, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(COUNTRYMASTER.country_name, '') AS DESTINATION, ISNULL(INVOICEMASTER.INVOICE_CIFFOB, '') AS CIFFOB, ISNULL(CURRENCYMASTER.CURR_NAME, '') AS CURRENCY, ISNULL(INVOICEMASTER.INVOICE_ORDERREFNO, '') AS ORDERREFNO, ISNULL(INVOICEMASTER.INVOICE_PAYMENTTERM, '') AS PAYMENTTERM, ISNULL(INVOICEMASTER.INVOICE_BANKDETAILS, '') AS BANKDETAILS, ISNULL(INVOICEMASTER.INVOICE_REMARKS, '') AS REMARKS, INVOICEMASTER.INVOICE_DATE AS DATE, ISNULL(ITEMMASTER.ITEM_NAME, '') AS FINISHEDQUALITY, ISNULL(INVOICEMASTER_DESC.INVOICE_GSM, 0) AS GSM, ISNULL(INVOICEMASTER_DESC.INVOICE_GSMDETAILS, 0) AS GSMDETAILS, ISNULL(INVOICEMASTER_DESC.INVOICE_SIZE, 0) AS SIZE, ISNULL(INVOICEMASTER_DESC.INVOICE_QTY, 0) AS QTY, ISNULL(INVOICEMASTER_DESC.INVOICE_RATE, 0) AS RATE, ISNULL(INVOICEMASTER_DESC.INVOICE_AMOUNT, 0) AS AMOUNT, ISNULL(INVOICEMASTER_DESC.INVOICE_GRIDSRNO, 0) AS GRIDSRNO, ISNULL(INVOICEMASTER_DESC.INVOICE_DESC, '') AS GRIDDESC, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT, ISNULL(PORTMASTER.PORT_name, '') AS PORTDISCHARGE, ISNULL(PORTMASTER_1.PORT_name, '') AS PORTLOADING, ISNULL(INVOICEMASTER.INVOICE_TOTALQTY, 0) AS TOTALQTY, ISNULL(INVOICEMASTER.INVOICE_TOTALAMT, 0) AS TOTALAMOUNT, ISNULL(SHIPTOLEDGERS.Acc_cmpname, '') AS SHIPTO, ISNULL(LEDGERS.Acc_email, '')  AS PARTYMAIL, ISNULL(LEDGERS.ACC_WHATSAPPNO, '') AS PARTYWHATSAPP, ISNULL(INVOICEMASTER.INVOICE_PRINTINITIALS, '') AS PRINTINITIALS, ISNULL(SHIPTOLEDGERS.Acc_cmpname, '') AS SHIPTO, ISNULL(INVOICEMASTER.INVOICE_CD, 0) AS CD, ISNULL(INVOICEMASTER.INVOICE_BILLAMT, 0)  AS BILLAMT, ISNULL(INVOICEMASTER.INVOICE_CHARGES, 0) AS CHARGES, ISNULL(INVOICEMASTER.INVOICE_SUBTOTAL, 0) AS SUBTOTAL, ISNULL(INVOICEMASTER.INVOICE_ROUNDOFF, 0) AS ROUNDOFF, ISNULL(INVOICEMASTER.INVOICE_GRANDTOTAL, 0) AS GRANDTOTAL, ISNULL(INVOICEMASTER.INVOICE_INWORDS, '') AS INWORDS, ISNULL(INVOICEMASTER.INVOICE_FREIGHT, 0) AS FREIGHT, ISNULL(INVOICEMASTER.INVOICE_DELIVERYTIME, '') AS DELIVERYTIME, ISNULL(INVOICEMASTER.INVOICE_ROE, 0) AS ROE, ISNULL(INVOICEMASTER.INVOICE_EXPTERMS, '') AS EXPTERMS, ISNULL(INVOICEMASTER.INVOICE_MARKNOS, '') AS MARKNOS, ISNULL(INVOICEMASTER.INVOICE_EXPINSURANCE, '') AS EXPINSURANCE, ISNULL(INVOICEMASTER.INVOICE_CONTAINER, '') AS CONTAINER, ISNULL(INVOICEMASTER.INVOICE_EXPHSN, '') AS EXPHSN, ISNULL(INVOICEMASTER.INVOICE_GROSSWT, 0) AS GROSSWT, ISNULL(INVOICEMASTER.INVOICE_NETTWT, 0) AS NETTWT, ISNULL(INVOICEMASTER.INVOICE_SQMTRS, 0) AS SQMTRS, ISNULL(INVOICEMASTER.INVOICE_TOTALUSDAMT, 0) AS TOTALUSDAMT, ISNULL(INVOICEMASTER.INVOICE_GSTINVRATE, 0) AS GSTINVRATE, ISNULL(INVOICEMASTER.INVOICE_CUSTOMINVRATE, 0) AS CUSTOMINVRATE, ISNULL(INVOICEMASTER.INVOICE_EXPDIFF, 0) AS EXPDIFF, ISNULL(INVOICEMASTER.INVOICE_INWORDSUSD, '') AS INWORDSUSD, ISNULL(HSNMASTER.HSN_CODE, '0') AS HSNCODE, ISNULL(INVOICEMASTER.INVOICE_PROFORMANO, '') AS PROFORMANO, INVOICEMASTER.INVOICE_PSDATE AS PSDATE, ISNULL(INVOICEMASTER.INVOICE_PSNO, '') AS PSNO, ISNULL(TRANSPORTMASTER.Acc_cmpname, '') AS TRANSPORTNAME, ISNULL(INVOICEMASTER.INVOICE_TOTALROLL, 0) AS TOTALROLL, ISNULL(INVOICEMASTER_DESC.INVOICE_ROLLNO, '') AS ROLLNO ", "", " CURRENCYMASTER RIGHT OUTER JOIN PORTMASTER RIGHT OUTER JOIN INVOICEMASTER LEFT OUTER JOIN LEDGERS AS TRANSPORTMASTER ON INVOICEMASTER.INVOICE_TRANSLEDGERID = TRANSPORTMASTER.Acc_id LEFT OUTER JOIN LEDGERS AS SHIPTOLEDGERS ON INVOICEMASTER.INVOICE_SHIPTOID = SHIPTOLEDGERS.Acc_id LEFT OUTER JOIN PORTMASTER AS PORTMASTER_1 ON INVOICEMASTER.INVOICE_PORTLOADINGID = PORTMASTER_1.PORT_id ON PORTMASTER.PORT_id = INVOICEMASTER.INVOICE_PORTDISCHARGEID LEFT OUTER JOIN LEDGERS ON INVOICEMASTER.INVOICE_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN COUNTRYMASTER ON INVOICEMASTER.INVOICE_DESTINATIONID = COUNTRYMASTER.country_id ON CURRENCYMASTER.CURR_ID = INVOICEMASTER.INVOICE_CURRENCYID LEFT OUTER JOIN ITEMMASTER RIGHT OUTER JOIN UNITMASTER RIGHT OUTER JOIN INVOICEMASTER_DESC LEFT OUTER JOIN HSNMASTER ON INVOICEMASTER_DESC.INVOICE_HSNCODEID = HSNMASTER.HSN_ID ON UNITMASTER.unit_id = INVOICEMASTER_DESC.INVOICE_UNITID ON ITEMMASTER.item_id = INVOICEMASTER_DESC.INVOICE_FINISHEDQUALITYID ON INVOICEMASTER.INVOICE_NO = INVOICEMASTER_DESC.INVOICE_NO ", " AND (INVOICEMASTER.INVOICE_YEARID = '" & YearId & "') ORDER BY INVOICEMASTER.INVOICE_NO")
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Sub showform(ByVal editval As Boolean, ByVal TEMPINVOICENO As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim objgdn As New InvoiceMaster
                objgdn.MdiParent = MDIMain
                objgdn.EDIT = editval
                objgdn.TEMPINVOICENO = TEMPINVOICENO
                objgdn.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
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

    Private Sub TOOLREFRESH_Click(sender As Object, e As EventArgs) Handles TOOLREFRESH.Click
        Try
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(sender As Object, e As EventArgs) Handles cmdok.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("TEMPINVOICENO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLEXCEL_Click(sender As Object, e As EventArgs) Handles TOOLEXCEL.Click
        Try
            Dim PATH As String = Application.StartupPath & "\Sale Invoice Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Sale Invoice Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Sale Invoice Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            MsgBox("Sale Invoice Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub TOOLWHATSAPP_Click(sender As Object, e As EventArgs) Handles TOOLWHATSAPP.Click
        Try
            If (Val(TXTFROM.Text.Trim) = 0 Or Val(TXTTO.Text.Trim) = 0 Or Val(TXTCOPIES.Text.Trim) = 0) AndAlso gridbill.SelectedRowsCount = 0 Then Exit Sub
            'IF WE HAVE SELECTED FROM AND TO THEN WORK WITH THE CURRENT CODE ELSE GO FOR SELECTED ENTRIES CODE
            If Val(TXTFROM.Text.Trim) > 0 And Val(TXTTO.Text.Trim) > 0 Then
                If Val(TXTFROM.Text.Trim) > Val(TXTTO.Text.Trim) Then
                    MsgBox("Enter Proper PO Nos", MsgBoxStyle.Critical)
                    Exit Sub
                Else
                    If MsgBox("Wish to Whatsapp PO from " & Val(TXTFROM.Text.Trim) & " To " & Val(TXTTO.Text.Trim) & " ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                    SERVERPROPDIRECT(False, True)
                End If
            Else
                If MsgBox("Wish to Whatsapp Selected PO ?", MsgBoxStyle.YesNo) = vbYes Then
                    SERVERPROPSELECTED(False, True)
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
                Dim OBJPO As New SaleInvoiceDesign
                OBJPO.MdiParent = MDIMain
                OBJPO.DIRECTPRINT = True
                OBJPO.FRMSTRING = "PROFORMA"
                OBJPO.DIRECTMAIL = INVOICEMAIL
                OBJPO.DIRECTWHATSAPP = WHATSAPP
                OBJPO.PRINTSETTING = PRINTDIALOG
                'OBJPO.PRINTPARTYDESIGN = PRINTPARTYDESIGN
                OBJPO.FORMULA = "{INVOICEMASTER.INVOICE_NO}=" & Val(I) & " and {INVOICEMASTER.INVOICE_yearid}=" & YearId
                OBJPO.INVNO = Val(I)
                OBJPO.NOOFCOPIES = Val(TXTCOPIES.Text.Trim)
                OBJPO.Show()
                OBJPO.Close()

                ALATTACHMENT.Add(Application.StartupPath & "\PROFORMA_" & I & ".pdf")
                FILENAME.Add("PIREPORT_" & I & ".pdf")
            Next

            If INVOICEMAIL Then
                Dim OBJMAIL As New SendMail
                OBJMAIL.ALATTACHMENT = ALATTACHMENT
                OBJMAIL.subject = "PROFORMA"
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

                Dim OBJPO As New SaleInvoiceDesign
                OBJPO.MdiParent = MDIMain
                OBJPO.DIRECTPRINT = True
                OBJPO.FRMSTRING = "PROFORMA"
                OBJPO.DIRECTMAIL = INVOICEMAIL
                OBJPO.DIRECTWHATSAPP = WHATSAPP
                OBJPO.PRINTSETTING = PRINTDIALOG
                OBJPO.FORMULA = "{INVOICEMASTER.INVOICE_NO}=" & Val(ROW("TEMPINVOICENO")) & " and {INVOICEMASTER.INVOICE_yearid}=" & YearId
                OBJPO.INVNO = Val(ROW("TEMPPORFORMA"))
                OBJPO.NOOFCOPIES = Val(TXTCOPIES.Text.Trim)
                OBJPO.Show()
                OBJPO.Close()
                ALATTACHMENT.Add(Application.StartupPath & "\PROFORMA_" & Val(ROW("TEMPINVOICENO")) & ".pdf")
                FILENAME.Add("INVOICE_" & Val(ROW("TEMPINVOICE")) & ".pdf")
            Next

            If INVOICEMAIL Then
                Dim OBJMAIL As New SendMail
                OBJMAIL.ALATTACHMENT = ALATTACHMENT
                OBJMAIL.subject = "INVOICE"
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

    Private Sub TOOLPRINT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLPRINT.Click
        Try
            If (Val(TXTFROM.Text.Trim) = 0 Or Val(TXTTO.Text.Trim) = 0 Or Val(TXTCOPIES.Text.Trim) = 0) AndAlso gridbill.SelectedRowsCount = 0 Then Exit Sub
            'IF WE HAVE SELECTED FROM AND TO THEN WORK WITH THE CURRENT CODE ELSE GO FOR SELECTED ENTRIES CODE
            If Val(TXTFROM.Text.Trim) > 0 And Val(TXTTO.Text.Trim) > 0 Then
                If Val(TXTFROM.Text.Trim) > Val(TXTTO.Text.Trim) Then
                    MsgBox("Enter Proper Sale Invoice Nos", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                If MsgBox("Wish to Print Sale Invoice from " & TXTFROM.Text.Trim & " To " & TXTTO.Text.Trim & " ?", MsgBoxStyle.YesNo) = vbYes Then
                    SERVERPROPDIRECT()
                End If
            Else
                If MsgBox("Wish to Print Selected Sale Invoice ?", MsgBoxStyle.YesNo) = vbYes Then
                    SERVERPROPSELECTED()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton9_Click(sender As Object, e As EventArgs) Handles ToolStripButton9.Click
        Try
            Dim OBJ As New InvoiceMasterGridDetails
            OBJ.MdiParent = MDIMain
            OBJ.Show()
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
                    MsgBox("Enter Proper PO Nos", MsgBoxStyle.Critical)
                    Exit Sub
                Else
                    If MsgBox("Wish to Mail PO from " & Val(TXTFROM.Text.Trim) & " To " & Val(TXTTO.Text.Trim) & " ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                    SERVERPROPDIRECT(True)
                End If
            Else
                If MsgBox("Wish to Mail Selected PO ?", MsgBoxStyle.YesNo) = vbYes Then
                    SERVERPROPSELECTED(True)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTFROM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTFROM.KeyPress, TXTTO.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub gridbilldetails_DoubleClick(sender As Object, e As EventArgs) Handles gridbilldetails.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("TEMPINVOICENO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class