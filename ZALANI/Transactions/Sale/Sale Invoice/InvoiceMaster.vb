


Imports System.ComponentModel
Imports BL

Public Class InvoiceMaster

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE, GRIDDOUBLECLICK, GRIDCHGSDOUBLECLICK As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public EDIT As Boolean          'used for editing
    Public TEMPINVOICENO As String
    Dim TEMPROW, TEMPCHGSROW As Integer

    Private Sub cmdexit_Click(sender As Object, e As EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Private Sub cmdclear_Click(sender As Object, e As EventArgs) Handles CMDCLEAR.Click
        CLEAR()
        EDIT = False
        CMBNAME.Focus()
    End Sub

    Sub CLEAR()
        GRIDDOUBLECLICK = False
        GRIDCHGSDOUBLECLICK = False
        TXTINVOICENO.ReadOnly = True
        LBLCLOSED.Visible = False
        TXTINVOICENO.Clear()
        INVOICEDATE.Text = Now.Date
        CMBNAME.Text = ""
        CMBSHIPTO.Text = ""
        EP.Clear()
        CMBDESTINATION.Text = ""
        CMBPORTLOADING.Text = ""
        CMBPORTDISCHARGE.Text = ""
        CMBCURRENCY.Text = ""
        TXTORDERREFNO.Clear()
        TXTPAYMENTTERM.Clear()
        CMBCIFFOB.Text = ""
        CMBBANKDETAILS.SelectedIndex = 0
        TXTREMARKS.Clear()
        GRIDINVOICE.RowCount = 0
        LBLTOTALQTY.Text = 0.0
        LBLTOTALAMOUNT.Text = 0.0
        TXTSRNO.Text = 1
        CMBFINISHED.Text = ""
        TXTDESC.Text = ""
        TXTGSM.Clear()
        TXTSIZE.Clear()
        TXTQTY.Clear()
        CMBUNIT.Text = ""
        TXTRATE.Clear()
        TXTAMOUNT.Clear()
        lbllocked.Visible = False
        LBLCLOSED.Visible = False
        getmax_INVOICENO()
        tstxtbillno.Clear()
        CHKCD.CheckState = CheckState.Unchecked
        TXTCHGSSRNO.Text = 1
        CMBCHARGES.Text = ""
        TXTCHGSPER.Clear()
        TXTCHGSAMT.Clear()
        GRIDCHGS.RowCount = 0
        txtinwords.Clear()
        txtbillamt.Clear()
        TXTCHARGES.Clear()
        TXTSUBTOTAL.Clear()
        txtroundoff.Clear()
        txtgrandtotal.Clear()
        TXTFREIGHT.Clear()
        PBlock.Visible = False
        TXTDELIVERYTIME.Clear()

        'EXPORT
        TXTROE.Clear()
        CHKOVERSEAS.Checked = False
        TXTEXPTERMS.Clear()
        TXTMARKNOS.Clear()
        TXTEXPINSURANCE.Clear()
        TXTCONTAINER.Clear()
        TXTEXPHSN.Text = ""
        TXTGROSSWT.Clear()
        TXTNETTWT.Clear()
        TXTSQMTRS.Clear()
        TXTTOTALUSDAMT.Clear()
        TXTGSTINVRATE.Clear()
        TXTCUSTOMINVRATE.Clear()
        TXTEXPDIFF.Clear()
        TXTINWORDSUSD.Clear()
        TXTHSNCODE.Clear()
        CMDSELECTPS.Enabled = True
        TXTHSNCODE.Clear()
        TXTPROFORMANO.Clear()
        TXTPSNO.Clear()
        DTPSDATE.Text = Now.Date
        TXTGSMDETAILS.Clear()
        CMBTRANSPORTNAME.Text = ""
        TXTROLLNO.Clear()
        LBLTOTALROLL.Text = 0

        CMBNAME.Enabled = True
        CMBSHIPTO.Enabled = True

    End Sub

    Sub getmax_INVOICENO()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(INVOICE_NO),0) + 1 ", "INVOICEMASTER", "  AND INVOICE_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTINVOICENO.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Private Sub InvoiceMaster_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If ERRORVALID() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()

            ElseIf e.Alt = True And e.KeyCode = Keys.P Then
                Call PrintToolStripButton_Click(sender, e)
            ElseIf e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            ElseIf e.Alt = True And e.KeyCode = Keys.Left Then
                toolprevious_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Keys.Right Then
                toolnext_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
                Call OpenToolStripButton_Click(sender, e)
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.F5 Then
                GRIDINVOICE.Focus()
            ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for Delete
                tstxtbillno.Focus()
                tstxtbillno.SelectAll()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLCMB()
        Try
            If CMBNAME.Text.Trim = "" Then FILLNAME(CMBNAME, EDIT, "AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS'")
            If CMBSHIPTO.Text.Trim = "" Then FILLNAME(CMBSHIPTO, EDIT, "AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS'")
            If CMBDESTINATION.Text.Trim = "" Then fillCOUNTRY(CMBDESTINATION)
            If CMBPORTDISCHARGE.Text.Trim = "" Then FILLPORT(CMBPORTDISCHARGE)
            If CMBPORTLOADING.Text.Trim = "" Then FILLPORT(CMBPORTLOADING)
            If CMBCURRENCY.Text.Trim = "" Then fillCURRENCY(CMBCURRENCY)
            If CMBFINISHED.Text.Trim = "" Then FILLITEMNAME(CMBFINISHED, " AND ITEM_FRMSTRING = 'MERCHANT'")
            If CMBUNIT.Text.Trim = "" Then FILLUNIT(CMBUNIT)
            If CMBTRANSPORTNAME.Text.Trim = "" Then FILLNAME(CMBTRANSPORTNAME, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='TRANSPORT'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub InvoiceMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow

            DTROW = USERRIGHTS.Select("FormName = 'SALE INVOICE'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)
            Cursor.Current = Cursors.WaitCursor

            FILLCMB()
            CLEAR()

            If EDIT = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim OBJCMN As New ClsCommon
                Dim OBJCLINVOICE As New ClsInvoiceMaster
                OBJCLINVOICE.alParaval.Add(TEMPINVOICENO)
                OBJCLINVOICE.alParaval.Add(CmpId)
                OBJCLINVOICE.alParaval.Add(YearId)
                Dim dttable As DataTable = OBJCLINVOICE.SELECTSALEINVOICE()
                If dttable.Rows.Count > 0 Then

                    For Each dr As DataRow In dttable.Rows

                        TXTINVOICENO.Text = TEMPINVOICENO
                        TXTINVOICENO.ReadOnly = True
                        INVOICEDATE.Text = Format(Convert.ToDateTime(dr("DATE")), "dd/MM/yyyy")
                        CMBNAME.Text = dr("NAME")
                        CMBSHIPTO.Text = dr("SHIPTO")
                        CMBDESTINATION.Text = Convert.ToString(dr("DESTINATION"))
                        CMBPORTDISCHARGE.Text = Convert.ToString(dr("PORTDISCHARGE"))
                        CMBPORTLOADING.Text = Convert.ToString(dr("PORTLOADING"))
                        CMBCURRENCY.Text = Convert.ToString(dr("CURRENCY"))
                        TXTORDERREFNO.Text = dr("ORDERREFNO")
                        TXTPAYMENTTERM.Text = dr("PAYMENTTERM")
                        CMBCIFFOB.Text = Convert.ToString(dr("CIFFOB"))
                        CMBBANKDETAILS.Text = Convert.ToString(dr("BANKDETAILS"))
                        LBLTOTALQTY.Text = dr("TOTALQTY")
                        LBLTOTALAMOUNT.Text = dr("TOTALAMOUNT")
                        TXTREMARKS.Text = dr("REMARKS")
                        TXTFREIGHT.Text = dr("FREIGHT")
                        TXTDELIVERYTIME.Text = dr("DELIVERYTIME")


                        'EXPORT SECTION
                        'CHKOVERSEAS.Checked = Convert.ToBoolean(dr("OVERSEAS"))
                        'If CHKOVERSEAS.Checked = True And ClientName = "ZALANI" Then GQTY.HeaderText = "USD" Else GQTY.HeaderText = "Cut"
                        TXTROE.Text = Val(dr("ROE"))
                        TXTEXPTERMS.Text = dr("EXPTERMS")
                        TXTMARKNOS.Text = dr("MARKNOS")
                        TXTEXPINSURANCE.Text = dr("EXPINSURANCE")
                        TXTCONTAINER.Text = dr("CONTAINER")
                        TXTEXPHSN.Text = dr("EXPHSN")
                        TXTGROSSWT.Text = Val(dr("GROSSWT"))
                        TXTNETTWT.Text = Val(dr("NETTWT"))
                        TXTSQMTRS.Text = Val(dr("SQMTRS"))
                        TXTTOTALUSDAMT.Text = Val(dr("TOTALUSDAMT"))
                        TXTGSTINVRATE.Text = Val(dr("GSTINVRATE"))
                        TXTCUSTOMINVRATE.Text = Val(dr("CUSTOMINVRATE"))
                        TXTEXPDIFF.Text = Val(dr("EXPDIFF"))
                        TXTINWORDSUSD.Text = dr("INWORDSUSD")
                        TXTPROFORMANO.Text = dr("PROFORMANO")
                        DTPSDATE.Text = Format(Convert.ToDateTime(dr("DATE")), "dd/MM/yyyy")
                        TXTPSNO.Text = dr("PSNO")
                        CMBTRANSPORTNAME.Text = Convert.ToString(dr("TRANSPORTNAME"))
                        LBLTOTALROLL.Text = dr("TOTALROLL")

                        GRIDINVOICE.Rows.Add(Val(dr("GRIDSRNO")), dr("FINISHEDQUALITY"), dr("HSNCODE"), dr("GRIDDESC"), dr("ROLLNO"), dr("GSM"), dr("GSMDETAILS"), dr("SIZE"), Format(Val(dr("QTY")), "0.00"), dr("UNIT"), Format(Val(dr("RATE")), "0.00"), Format(Val(dr("AMOUNT")), "0.00"))

                        'If Convert.ToBoolean(dr("PODONE")) = True Or Convert.ToBoolean(dr("SODONE")) = True Then
                        '    GRIDINVOICE.Rows(GRIDINVOICE.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                        '    lbllocked.Visible = True
                        '    PBlock.Visible = True
                        'End If

                        'If Convert.ToBoolean(dr("CLOSED")) = True Then
                        '    GRIDINVOICE.Rows(GRIDINVOICE.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                        '    lbllocked.Visible = True
                        '    LBLCLOSED.Visible = True
                        '    PBlock.Visible = True
                        'End If

                    Next
                    'CHARGES GRID

                    Dim dtable As DataTable = OBJCMN.SEARCH(" INVOICEMASTER_CHGS.INVOICE_ESRNO AS GRIDSRNO, LEDGERS.Acc_cmpname AS CHARGES, INVOICEMASTER_CHGS.INVOICE_PER AS PER, INVOICEMASTER_CHGS.INVOICE_AMT AS AMT, INVOICEMASTER_CHGS.INVOICE_TAXID AS TAXID ", "", " INVOICEMASTER_CHGS INNER JOIN LEDGERS ON INVOICEMASTER_CHGS.INVOICE_CHARGESID = LEDGERS.Acc_id  ", " AND INVOICEMASTER_CHGS.INVOICE_NO = " & TEMPINVOICENO & " AND INVOICEMASTER_CHGS.INVOICE_YEARID = " & YearId & " ORDER BY INVOICEMASTER_CHGS.INVOICE_Esrno")
                    If dtable.Rows.Count > 0 Then
                        For Each DTR As DataRow In dtable.Rows
                            GRIDCHGS.Rows.Add(DTR("GRIDSRNO"), DTR("CHARGES"), DTR("PER"), DTR("AMT"), DTR("TAXID"))
                        Next
                    End If

                    GRIDINVOICE.FirstDisplayedScrollingRowIndex = GRIDINVOICE.RowCount - 1
                    TOTAL()
                    INVOICEDATE.Focus()
                Else
                    EDIT = False
                    CLEAR()
                End If
                CMBNAME.Enabled = False
                CMBSHIPTO.Enabled = False
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub cmdok_Click(sender As Object, e As EventArgs) Handles CMDOK.Click
        Try
            If ISLOCKYEAR = True Then
                MsgBox("Unable to Make changes, Year is Locked", MsgBoxStyle.Critical)
                Exit Sub
            End If

            Dim IntResult As Integer

            EP.Clear()
            If Not ERRORVALID() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList
            'If TXTINVOICENO.ReadOnly = False Then alParaval.Add(Val(TXTINVOICENO.Text.Trim)) Else alParaval.Add(0)
            If ALLOWMANUALINVNO = True Then
                alParaval.Add(Val(TXTINVOICENO.Text.Trim))
            Else
                alParaval.Add(0)
            End If

            alParaval.Add(Format(Convert.ToDateTime(INVOICEDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(CMBNAME.Text.Trim)
            alParaval.Add(CMBSHIPTO.Text.Trim)
            alParaval.Add(CMBDESTINATION.Text.Trim)
            alParaval.Add(CMBPORTDISCHARGE.Text.Trim)
            alParaval.Add(CMBPORTLOADING.Text.Trim)
            alParaval.Add(CMBCURRENCY.Text.Trim)
            alParaval.Add(TXTORDERREFNO.Text.Trim)
            alParaval.Add(TXTPAYMENTTERM.Text.Trim)
            alParaval.Add(CMBCIFFOB.Text.Trim)
            alParaval.Add(CMBBANKDETAILS.Text.Trim)
            alParaval.Add(TXTREMARKS.Text.Trim)
            alParaval.Add(Val(LBLTOTALQTY.Text.Trim))
            alParaval.Add(Val(LBLTOTALAMOUNT.Text.Trim))
            alParaval.Add(Val(TXTFREIGHT.Text.Trim))
            alParaval.Add(TXTDELIVERYTIME.Text.Trim)

            'EXPORT DETAILS
            alParaval.Add(Val(TXTROE.Text.Trim))
            alParaval.Add(TXTEXPTERMS.Text.Trim)
            alParaval.Add(TXTMARKNOS.Text.Trim)
            alParaval.Add(TXTEXPINSURANCE.Text.Trim)
            alParaval.Add(TXTCONTAINER.Text.Trim)
            alParaval.Add(TXTEXPHSN.Text.Trim)
            alParaval.Add(Val(TXTGROSSWT.Text.Trim))
            alParaval.Add(Val(TXTNETTWT.Text.Trim))
            alParaval.Add(Val(TXTSQMTRS.Text.Trim))
            alParaval.Add(Val(TXTTOTALUSDAMT.Text.Trim))
            alParaval.Add(Val(TXTGSTINVRATE.Text.Trim))
            alParaval.Add(Val(TXTCUSTOMINVRATE.Text.Trim))
            alParaval.Add(Val(TXTEXPDIFF.Text.Trim))
            alParaval.Add(TXTINWORDSUSD.Text.Trim)

            alParaval.Add(TXTPROFORMANO.Text.Trim)
            alParaval.Add(Format(Convert.ToDateTime(DTPSDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(TXTPSNO.Text.Trim)
            alParaval.Add(CMBTRANSPORTNAME.Text.Trim)

            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)

            Dim GRIDSRNO As String = ""
            Dim FINISHEDQUALITY As String = ""
            Dim HSNCODE As String = ""
            Dim DESC As String = ""
            Dim ROLLNO As String = ""
            Dim GSM As String = ""
            Dim GSMDETAILS As String = ""
            Dim SIZE As String = ""
            Dim QTY As String = ""
            Dim UNIT As String = ""
            Dim RATE As String = ""
            Dim AMOUNT As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDINVOICE.Rows
                If row.Cells(0).Value <> Nothing Then
                    If GRIDSRNO = "" Then
                        GRIDSRNO = Val(row.Cells(GSRNO.Index).Value)
                        FINISHEDQUALITY = row.Cells(GFINISHEDQUALITY.Index).Value.ToString
                        HSNCODE = row.Cells(GHSNCODE.Index).Value.ToString
                        DESC = row.Cells(GDESC.Index).Value.ToString
                        ROLLNO = row.Cells(GROLLNO.Index).Value.ToString
                        GSM = row.Cells(GGSM.Index).Value.ToString
                        GSMDETAILS = row.Cells(GGSMDETAILS.Index).Value.ToString
                        SIZE = row.Cells(GSIZE.Index).Value.ToString
                        QTY = Val(row.Cells(GQTY.Index).Value)
                        UNIT = row.Cells(GUNIT.Index).Value.ToString
                        RATE = Val(row.Cells(GRATE.Index).Value)
                        AMOUNT = Val(row.Cells(GAMOUNT.Index).Value)

                    Else

                        GRIDSRNO = GRIDSRNO & "|" & Val(row.Cells(GSRNO.Index).Value)
                        FINISHEDQUALITY = FINISHEDQUALITY & "|" & row.Cells(GFINISHEDQUALITY.Index).Value.ToString
                        HSNCODE = HSNCODE & "|" & row.Cells(GHSNCODE.Index).Value.ToString
                        DESC = DESC & "|" & row.Cells(GDESC.Index).Value.ToString
                        ROLLNO = ROLLNO & "|" & row.Cells(GROLLNO.Index).Value.ToString
                        GSM = GSM & "|" & row.Cells(GGSM.Index).Value.ToString
                        GSMDETAILS = GSMDETAILS & "|" & row.Cells(GGSMDETAILS.Index).Value.ToString
                        SIZE = SIZE & "|" & row.Cells(GSIZE.Index).Value
                        QTY = QTY & "|" & Val(row.Cells(GQTY.Index).Value)
                        UNIT = UNIT & "|" & row.Cells(GUNIT.Index).Value.ToString
                        RATE = RATE & "|" & Val(row.Cells(GRATE.Index).Value)
                        AMOUNT = AMOUNT & "|" & Val(row.Cells(GAMOUNT.Index).Value)


                    End If
                End If
            Next

            alParaval.Add(GRIDSRNO)
            alParaval.Add(FINISHEDQUALITY)
            alParaval.Add(HSNCODE)
            alParaval.Add(DESC)
            alParaval.Add(ROLLNO)
            alParaval.Add(GSM)
            alParaval.Add(GSMDETAILS)
            alParaval.Add(SIZE)
            alParaval.Add(QTY)
            alParaval.Add(UNIT)
            alParaval.Add(RATE)
            alParaval.Add(AMOUNT)

            Dim CSRNO As String = ""
            Dim CCHGS As String = ""
            Dim CPER As String = ""
            Dim CAMT As String = ""
            Dim CTAXID As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDCHGS.Rows
                If row.Cells(0).Value <> Nothing Then
                    If CSRNO = "" Then
                        CSRNO = row.Cells(ESRNO.Index).Value.ToString
                        CCHGS = row.Cells(ECHARGES.Index).Value.ToString
                        CPER = row.Cells(EPER.Index).Value.ToString
                        CAMT = Val(row.Cells(EAMT.Index).Value)
                        CTAXID = Val(row.Cells(ETAXID.Index).Value)
                    Else
                        CSRNO = CSRNO & "|" & row.Cells(ESRNO.Index).Value.ToString
                        CCHGS = CCHGS & "|" & row.Cells(ECHARGES.Index).Value.ToString
                        CPER = CPER & "|" & row.Cells(EPER.Index).Value.ToString
                        CAMT = CAMT & "|" & Val(row.Cells(EAMT.Index).Value)
                        CTAXID = CTAXID & "|" & Val(row.Cells(ETAXID.Index).Value)

                    End If
                End If
            Next

            alParaval.Add(CSRNO)
            alParaval.Add(CCHGS)
            alParaval.Add(CPER)
            alParaval.Add(CAMT)
            alParaval.Add(CTAXID)

            If CHKCD.Checked = True Then alParaval.Add(1) Else alParaval.Add(0)

            alParaval.Add(Val(txtbillamt.Text.Trim))
            alParaval.Add(Val(TXTCHARGES.Text.Trim))
            alParaval.Add(Val(TXTSUBTOTAL.Text.Trim))
            alParaval.Add(Val(txtroundoff.Text.Trim))
            alParaval.Add(Val(txtgrandtotal.Text.Trim))

            alParaval.Add(txtinwords.Text)
            alParaval.Add(Val(LBLTOTALROLL.Text.Trim))

            Dim objclsPurord As New ClsInvoiceMaster()
            objclsPurord.alParaval = alParaval

            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim DT As DataTable = objclsPurord.SAVE()
                MessageBox.Show("Details Added")
                TXTINVOICENO.Text = DT.Rows(0).Item(0)
            Else


                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPINVOICENO)
                IntResult = objclsPurord.UPDATE()
                MessageBox.Show("Details Updated")
                EDIT = False
            End If

            PRINTREPORT(Val(TXTINVOICENO.Text.Trim))
            CLEAR()
            CMBNAME.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub


    Sub PRINTREPORT(ByVal INVOICENO As Integer)
        Try
            If MsgBox("Wish to Print Invoice?", MsgBoxStyle.YesNo) = vbNo Then Exit Sub
            Dim OBJPROFORMA As New SaleInvoiceDesign
            OBJPROFORMA.FRMSTRING = "INVOICE"
            OBJPROFORMA.INVNO = INVOICENO
            OBJPROFORMA.PARTYNAME = CMBNAME.Text.Trim
            OBJPROFORMA.MdiParent = MDIMain
            OBJPROFORMA.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function ERRORVALID() As Boolean

        Dim bln As Boolean = True
        If CMBNAME.Text.Trim.Length = 0 Then
            EP.SetError(CMBNAME, " Please Fill Party Name ")
            bln = False
        End If

        If CMBSHIPTO.Text.Trim.Length = 0 Then
            EP.SetError(CMBSHIPTO, " Please Fill Ship To Name ")
            bln = False
        End If


        If lbllocked.Visible = True Or LBLCLOSED.Visible = True Then
            EP.SetError(lbllocked, " Entry Locked, Unable to Modify")
            bln = False
        End If

        If CMBCURRENCY.Text.Trim.Length = 0 Then
            EP.SetError(CMBCURRENCY, " Please Fill Currency")
            bln = False
        End If

        If CMBDESTINATION.Text.Trim.Length = 0 Then
            EP.SetError(CMBDESTINATION, " Please Fill Destination")
            bln = False
        End If

        If lbllocked.Visible = True Then
            EP.SetError(lbllocked, "Sale Order Done, Delete Sale Order First")
            bln = False
        End If

        If ALLOWMANUALINVNO = True Then
            If Val(TXTINVOICENO.Text.Trim) <> 0 And CMBNAME.Text.Trim <> "" And EDIT = False Then
                Dim OBJCMN As New ClsCommon
                Dim dttable As DataTable = OBJCMN.SEARCH(" ISNULL(INVOICEMASTER.INVOICE_NO, '') AS INVOICENO ", "", " INVOICEMASTER ", "  AND INVOICE_NO = " & Val(TXTINVOICENO.Text.Trim) & " AND INVOICEMASTER.INVOICE_YEARID = " & YearId)
                If dttable.Rows.Count > 0 Then
                    EP.SetError(TXTINVOICENO, "Invoice No Already Exist")
                    bln = False
                End If
            End If
        End If

        If INVOICEDATE.Text = "__/__/____" Then
            EP.SetError(INVOICEDATE, " Please Enter Proper Date")
            bln = False
        Else
            If Not datecheck(INVOICEDATE.Text) Then
                EP.SetError(INVOICEDATE, "Date not in Accounting Year")
                bln = False
            End If
        End If

        If GRIDINVOICE.RowCount = 0 Then
            EP.SetError(CMBNAME, " Please Enter Proper Details ")
            bln = False
        End If

        Return bln
    End Function

    Private Sub cmddelete_Click(sender As Object, e As EventArgs) Handles CMDDELETE.Click
        Try
            If ISLOCKYEAR = True Then
                MsgBox("Unable to Make changes, Year is Locked", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If EDIT = True Then
                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                If lbllocked.Visible = True Then
                    MsgBox("Unable To Delete, Sale Order Done", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                If Convert.ToDateTime(INVOICEDATE.Text).Date < SALEBLOCKDATE.Date Then
                    MsgBox("Date is Blocked, Please Delete entries after " & Format(SALEBLOCKDATE.Date, "dd/MM/yyyy"), MsgBoxStyle.Critical)
                    Exit Sub
                End If

                If MsgBox("Delete Sale Invoice?", MsgBoxStyle.YesNo) = vbYes Then
                    Dim alParaval As New ArrayList
                    alParaval.Add(Val(TEMPINVOICENO))
                    alParaval.Add(CmpId)
                    alParaval.Add(YearId)

                    Dim ClsINCTAG As New ClsInvoiceMaster()
                    ClsINCTAG.alParaval = alParaval
                    Dim IntResult As Integer = ClsINCTAG.DELETE()
                    MsgBox("Sale Invoice Deleted")
                    CLEAR()
                    EDIT = False

                End If
            Else
                MsgBox("Delete Is only In Edit Mode")
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolprevious_Click(sender As Object, e As EventArgs) Handles toolprevious.Click
        Try
            GRIDINVOICE.RowCount = 0
LINE1:
            TEMPINVOICENO = Val(TXTINVOICENO.Text) - 1
            If TEMPINVOICENO > 0 Then
                EDIT = True
                InvoiceMaster_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If

            If GRIDINVOICE.RowCount = 0 And TEMPINVOICENO > 1 Then
                TXTINVOICENO.Text = TEMPINVOICENO
                GoTo LINE1
            End If
            CMBNAME.Enabled = False
            CMBSHIPTO.Enabled = False
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(sender As Object, e As EventArgs) Handles toolnext.Click
        Try
            GRIDINVOICE.RowCount = 0
LINE1:
            TEMPINVOICENO = Val(TXTINVOICENO.Text) + 1
            getmax_INVOICENO()
            Dim MAXNO As Integer = TXTINVOICENO.Text.Trim
            CLEAR()
            If Val(TXTINVOICENO.Text) - 1 >= TEMPINVOICENO Then
                EDIT = True
                InvoiceMaster_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
            If GRIDINVOICE.RowCount = 0 And TEMPINVOICENO < MAXNO Then
                TXTINVOICENO.Text = TEMPINVOICENO
                GoTo LINE1
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub OpenToolStripButton_Click(sender As Object, e As EventArgs) Handles OpenToolStripButton.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim objINVDTLS As New InvoiceMasterDetails
            objINVDTLS.MdiParent = MDIMain
            objINVDTLS.Show()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(sender As Object, e As EventArgs) Handles SaveToolStripButton.Click
        Try
            cmdok_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try
            If EDIT = True Then PRINTREPORT(TEMPINVOICENO)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLDELETE.Click
        Try
            Call cmddelete_Click(sender, e)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(sender As Object, e As CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                GRIDINVOICE.RowCount = 0
                TEMPINVOICENO = Val(tstxtbillno.Text)
                If TEMPINVOICENO > 0 Then
                    EDIT = True
                    InvoiceMaster_Load(sender, e)
                Else
                    CLEAR()
                    EDIT = False
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub getsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(0).Value = row.Index + 1
            Next
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub


    Private Sub GRIDPROFORMA_KeyDown(sender As Object, e As KeyEventArgs) Handles GRIDINVOICE.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDINVOICE.RowCount > 0 Then
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                GRIDINVOICE.Rows.RemoveAt(GRIDINVOICE.CurrentRow.Index)
                TOTAL()
                getsrno(GRIDINVOICE)
            ElseIf e.KeyCode = Keys.F5 Then
                EDITROW()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Validated(sender As Object, e As EventArgs) Handles CMBNAME.Validated
        Try
            If CMBNAME.Text.Trim <> "" Then
                'GET PORTDISCHARGE,PORTLOADING AND PAYMENTTERM AND WARNING TEXT
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.SEARCH(" ISNULL(PORTMASTER.PORT_name, '') AS PORTDISCHARGE, ISNULL(PORTLOADINGPORTMASTER.PORT_name, '') AS PORTLOADING, ISNULL(LEDGERS.ACC_WARNING, '') AS WARNING, ISNULL(LEDGERS.Acc_remarks, '')  AS REMARKS", "", " LEDGERS LEFT OUTER JOIN PORTMASTER AS PORTLOADINGPORTMASTER ON LEDGERS.ACC_PORTLOADINGID = PORTLOADINGPORTMASTER.PORT_id LEFT OUTER JOIN PORTMASTER ON LEDGERS.ACC_PORTDISCHARGEID = PORTMASTER.PORT_id ", " and LEDGERS.acc_cmpname = '" & CMBNAME.Text.Trim & "' and LEDGERS.acc_YEARid = " & YearId)
                If DT.Rows.Count > 0 Then
                    If TXTPAYMENTTERM.Text.Trim = "" Then TXTPAYMENTTERM.Text = DT.Rows(0).Item("REMARKS")
                    If CMBPORTDISCHARGE.Text.Trim = "" Then CMBPORTDISCHARGE.Text = DT.Rows(0).Item("PORTDISCHARGE")
                    If CMBPORTLOADING.Text.Trim = "" Then CMBPORTLOADING.Text = DT.Rows(0).Item("PORTLOADING")
                    If DT.Rows(0).Item("WARNING") <> "" Then MsgBox(DT.Rows(0).Item("WARNING"), MsgBoxStyle.Critical)
                    If CMBSHIPTO.Text.Trim = "" Then CMBSHIPTO.Text = CMBNAME.Text.Trim
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub Fillgrid()
        Try
            If GRIDDOUBLECLICK = False Then
                GRIDINVOICE.Rows.Add(Val(TXTSRNO.Text.Trim), CMBFINISHED.Text.Trim, TXTHSNCODE.Text.Trim, TXTDESC.Text.Trim, TXTROLLNO.Text.Trim, TXTGSM.Text.Trim, TXTGSMDETAILS.Text.Trim, TXTSIZE.Text.Trim, Format(Val(TXTQTY.Text.Trim), "0.00"), CMBUNIT.Text.Trim, Format(Val(TXTRATE.Text.Trim), "0.00"), Format(Val(TXTAMOUNT.Text.Trim), "0.00"))
                getsrno(GRIDINVOICE)
            ElseIf GRIDDOUBLECLICK = True Then
                GRIDINVOICE.Item(GSRNO.Index, TEMPROW).Value = Val(TXTSRNO.Text.Trim)
                GRIDINVOICE.Item(GFINISHEDQUALITY.Index, TEMPROW).Value = CMBFINISHED.Text.Trim
                GRIDINVOICE.Item(GHSNCODE.Index, TEMPROW).Value = TXTHSNCODE.Text.Trim
                GRIDINVOICE.Item(GDESC.Index, TEMPROW).Value = TXTDESC.Text.Trim
                GRIDINVOICE.Item(GROLLNO.Index, TEMPROW).Value = TXTROLLNO.Text.Trim
                GRIDINVOICE.Item(GGSM.Index, TEMPROW).Value = TXTGSM.Text.Trim
                GRIDINVOICE.Item(GGSMDETAILS.Index, TEMPROW).Value = TXTGSMDETAILS.Text.Trim
                GRIDINVOICE.Item(GSIZE.Index, TEMPROW).Value = TXTSIZE.Text.Trim
                GRIDINVOICE.Item(GQTY.Index, TEMPROW).Value = Format(Val(TXTQTY.Text.Trim), "0.00")
                GRIDINVOICE.Item(GUNIT.Index, TEMPROW).Value = (CMBUNIT.Text.Trim)
                GRIDINVOICE.Item(GRATE.Index, TEMPROW).Value = Format(Val(TXTRATE.Text.Trim), "0.00")
                GRIDINVOICE.Item(GAMOUNT.Index, TEMPROW).Value = Format(Val(TXTAMOUNT.Text.Trim), "0.00")

                GRIDDOUBLECLICK = False

            End If
            TOTAL()

            GRIDINVOICE.FirstDisplayedScrollingRowIndex = GRIDINVOICE.RowCount - 1

            TXTSRNO.Text = GRIDINVOICE.RowCount + 1
            CMBFINISHED.Text = ""
            TXTHSNCODE.Clear()
            TXTDESC.Text = ""
            TXTROLLNO.Clear()
            TXTGSM.Clear()
            TXTGSMDETAILS.Clear()
            TXTSIZE.Clear()
            TXTQTY.Clear()
            CMBUNIT.Text = ""
            TXTRATE.Clear()
            TXTAMOUNT.Clear()

            CMBFINISHED.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub EDITROW()
        Try
            If GRIDINVOICE.CurrentRow.Index >= 0 And GRIDINVOICE.Item(GSRNO.Index, GRIDINVOICE.CurrentRow.Index).Value <> Nothing Then

                GRIDDOUBLECLICK = True
                TXTSRNO.Text = Val(GRIDINVOICE.Item(GSRNO.Index, GRIDINVOICE.CurrentRow.Index).Value)
                CMBFINISHED.Text = GRIDINVOICE.Item(GFINISHEDQUALITY.Index, GRIDINVOICE.CurrentRow.Index).Value.ToString
                TXTHSNCODE.Text = GRIDINVOICE.Item(GHSNCODE.Index, GRIDINVOICE.CurrentRow.Index).Value.ToString
                TXTDESC.Text = GRIDINVOICE.Item(GDESC.Index, GRIDINVOICE.CurrentRow.Index).Value.ToString
                TXTROLLNO.Text = GRIDINVOICE.Item(GROLLNO.Index, GRIDINVOICE.CurrentRow.Index).Value.ToString
                TXTGSM.Text = GRIDINVOICE.Item(GGSM.Index, GRIDINVOICE.CurrentRow.Index).Value.ToString
                TXTGSMDETAILS.Text = GRIDINVOICE.Item(GGSMDETAILS.Index, GRIDINVOICE.CurrentRow.Index).Value.ToString
                TXTSIZE.Text = GRIDINVOICE.Item(GSIZE.Index, GRIDINVOICE.CurrentRow.Index).Value.ToString
                TXTQTY.Text = Val(GRIDINVOICE.Item(GQTY.Index, GRIDINVOICE.CurrentRow.Index).Value)
                CMBUNIT.Text = GRIDINVOICE.Item(GUNIT.Index, GRIDINVOICE.CurrentRow.Index).Value.ToString
                TXTRATE.Text = Val(GRIDINVOICE.Item(GRATE.Index, GRIDINVOICE.CurrentRow.Index).Value)
                TXTAMOUNT.Text = Val(GRIDINVOICE.Item(GAMOUNT.Index, GRIDINVOICE.CurrentRow.Index).Value)

                TEMPROW = GRIDINVOICE.CurrentRow.Index
                CMBFINISHED.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCURRENCY_Validating(sender As Object, e As CancelEventArgs) Handles CMBCURRENCY.Validating
        Try
            If CMBCURRENCY.Text <> "" Then CURRENCYVALIDATE(CMBCURRENCY, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCURRENCY_Enter(sender As Object, e As EventArgs) Handles CMBCURRENCY.Enter
        Try
            If CMBCURRENCY.Text = "" Then fillCURRENCY(CMBCURRENCY)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(sender As Object, e As CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, CMBCODE, e, Me, TXTADD, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS'", "SUNDRY DEBTORS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Enter(sender As Object, e As EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then FILLNAME(CMBNAME, EDIT, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DTDATE_GotFocus(sender As Object, e As EventArgs) Handles INVOICEDATE.GotFocus
        INVOICEDATE.SelectionStart = 0
    End Sub

    Private Sub GRIDINVOICE_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRIDINVOICE.CellDoubleClick
        Try
            EDITROW()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDESTINATION_Validating(sender As Object, e As CancelEventArgs) Handles CMBDESTINATION.Validating
        Try
            If CMBDESTINATION.Text.Trim <> "" Then COUNTRYVALIDATE(CMBDESTINATION, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDESTINATION_Enter(sender As Object, e As EventArgs) Handles CMBDESTINATION.Enter
        Try
            If CMBDESTINATION.Text.Trim = "" Then fillCOUNTRY(CMBDESTINATION)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbportdischarge_Enter(sender As Object, e As EventArgs) Handles CMBPORTDISCHARGE.Enter
        Try
            If CMBPORTDISCHARGE.Text.Trim = "" Then FILLPORT(CMBPORTDISCHARGE)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBFINISHED_Enter(sender As Object, e As EventArgs) Handles CMBFINISHED.Enter
        Try
            If CMBFINISHED.Text.Trim = "" Then FILLITEMNAME(CMBFINISHED, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBFINISHED_Validating(sender As Object, e As CancelEventArgs) Handles CMBFINISHED.Validating
        Try
            If CMBFINISHED.Text.Trim <> "" Then ITEMVALIDATE(CMBFINISHED, e, Me, "", "MERCHANT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBUNIT_Validating(sender As Object, e As CancelEventArgs) Handles CMBUNIT.Validating
        Try
            If CMBUNIT.Text.Trim <> "" Then unitvalidate(CMBUNIT, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBUNIT_Enter(sender As Object, e As EventArgs) Handles CMBUNIT.Enter
        Try
            If CMBUNIT.Text.Trim <> "" Then FILLUNIT(CMBUNIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbportdischarge_Validating(sender As Object, e As CancelEventArgs) Handles CMBPORTDISCHARGE.Validating
        Try
            If CMBPORTDISCHARGE.Text.Trim <> "" Then portvalidate(CMBPORTDISCHARGE, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPORTLOADING_Validating(sender As Object, e As CancelEventArgs) Handles CMBPORTLOADING.Validating
        Try
            If CMBPORTLOADING.Text.Trim <> "" Then portvalidate(CMBPORTLOADING, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPORTLOADING_Enter(sender As Object, e As EventArgs) Handles CMBPORTLOADING.Enter
        Try
            If CMBPORTLOADING.Text.Trim = "" Then FILLPORT(CMBPORTLOADING)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBFINISHED_Validated(sender As Object, e As EventArgs) Handles CMBFINISHED.Validated
        Try
            If CMBFINISHED.Text.Trim <> "" And Convert.ToDateTime(INVOICEDATE.Text).Date >= "01/07/2017" Then GETHSNCODE()
            If CMBFINISHED.Text.Trim <> "" And CMBNAME.Text.Trim <> "" And TXTDESC.Text.Trim = "" Then
                Dim dt As New DataTable
                Dim OBJCMN As New ClsCommon
                Dim DTTCS As DataTable = OBJCMN.SEARCH(" PAR_STAMPING ", "", " PARTYITEMWISECHART LEFT OUTER JOIN ITEMMASTER ON PARTYITEMWISECHART.PAR_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN LEDGERS ON PARTYITEMWISECHART.PAR_LEDGERID = LEDGERS.Acc_id", " AND ISNULL(ITEMMASTER.ITEM_NAME,'')='" & CMBFINISHED.Text & "'  AND ISNULL(LEDGERS.Acc_cmpname,'')='" & CMBNAME.Text & "' and PAR_cmpid=" & CmpId & " AND  PAR_YEARID = " & YearId)
                If DTTCS.Rows.Count > 0 Then TXTDESC.Text = DTTCS.Rows(0).Item("PAR_STAMPING")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TOTAL()
        Try
            LBLTOTALQTY.Text = 0.0
            LBLTOTALAMOUNT.Text = 0.0
            TXTCHARGES.Text = 0.0
            TXTSUBTOTAL.Text = 0
            txtroundoff.Text = 0
            txtgrandtotal.Text = 0


            Dim dt As New DataTable
            Dim OBJCMN As New ClsCommon

            For Each ROW As DataGridViewRow In GRIDINVOICE.Rows
                If ROW.Cells(GSRNO.Index).Value <> Nothing Then
                    LBLTOTALQTY.Text = Format(Val(LBLTOTALQTY.Text) + Val(ROW.Cells(GQTY.Index).EditedFormattedValue), "0.00")
                    LBLTOTALAMOUNT.Text = Format(Val(LBLTOTALAMOUNT.Text) + Val(ROW.Cells(GAMOUNT.Index).EditedFormattedValue), "0.00")
                End If

                If ClientName = "ZALANI" And CHKOVERSEAS.Checked = True And Val(TXTROE.Text.Trim) > 0 And ROW.Cells(GQTY.Index).EditedFormattedValue > 0 Then
                    ROW.Cells(GRATE.Index).Value = Format(Val(ROW.Cells(GQTY.Index).EditedFormattedValue) * Val(TXTROE.Text.Trim), "0.00")
                End If
            Next
            txtbillamt.Text = Format(Val(LBLTOTALAMOUNT.Text.Trim), "0.00")
            ROLLCOUNT()

            If GRIDCHGS.RowCount > 0 Then
                For Each row As DataGridViewRow In GRIDCHGS.Rows
                    If SALEAUTODISCOUNT = True And ClientName <> "ZALANI" Then
                        'IF PERCENT IS > 0 THEN GETAUTO CHARGES
                        dt = OBJCMN.SEARCH("ISNULL(ACC_CALC,'GROSS') AS CALC", "", "LEDGERS", "AND ACC_CMPNAME = '" & row.Cells(ECHARGES.Index).Value & "' AND ACC_YEARID = " & YearId)
                        If dt.Rows.Count > 0 Then
                            If dt.Rows(0).Item("CALC") = "GROSS" And Val(row.Cells(EPER.Index).Value) <> 0 Then
                                row.Cells(EAMT.Index).Value = Format((Val(row.Cells(EPER.Index).Value) * Val(txtbillamt.Text.Trim)) / 100, "0.00")
                            ElseIf dt.Rows(0).Item("CALC") = "NETT" And Val(row.Cells(EPER.Index).Value) <> 0 Then
                                TXTNETTAMT.Text = Val(txtbillamt.Text.Trim)
                                For I As Integer = 0 To row.Index - 1
                                    TXTNETTAMT.Text = Format(Val(TXTNETTAMT.Text) + Val(GRIDCHGS.Rows(I).Cells(EAMT.Index).Value), "0.00")
                                Next
                                row.Cells(EAMT.Index).Value = Format((Val(row.Cells(EPER.Index).Value) * Val(TXTNETTAMT.Text.Trim)) / 100, "0.00")
                                TXTCHGSAMT.Text = Format((Val(TXTNETTAMT.Text) * Val(TXTCHGSPER.Text)) / 100, "0.00")
                            End If
                        End If
                    End If
                    TXTCHARGES.Text = Format(Val(TXTCHARGES.Text) + Val(row.Cells(EAMT.Index).Value), "0.00")
                Next
            End If
            TXTSUBTOTAL.Text = Format(Val(txtbillamt.Text) + Val(TXTCHARGES.Text.Trim), "0.00")

            txtgrandtotal.Text = Format(Val(TXTSUBTOTAL.Text) + Val(TXTFREIGHT.Text.Trim) + Val(TXTCGSTAMT1.Text.Trim) + Val(TXTSGSTAMT1.Text.Trim) + Val(TXTIGSTAMT1.Text.Trim) + Val(TXTTCSAMT.Text.Trim), "0.00")
            txtroundoff.Text = Format(Val(txtgrandtotal.Text) - (Val(TXTSUBTOTAL.Text) + Val(TXTCGSTAMT1.Text.Trim) + Val(TXTFREIGHT.Text.Trim) + Val(TXTSGSTAMT1.Text.Trim) + Val(TXTIGSTAMT1.Text.Trim) + Val(TXTTCSAMT.Text.Trim)), "0.00")

            If Val(txtgrandtotal.Text) > 0 Then txtinwords.Text = CurrencyToWord(txtgrandtotal.Text)

            ROLLCOUNT()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTAMOUNT_Validated(sender As Object, e As EventArgs) Handles TXTAMOUNT.Validated
        Try
            If CMBFINISHED.Text.Trim <> "" And Val(TXTQTY.Text.Trim) > 0 And CMBUNIT.Text.Trim <> "" And Val(TXTRATE.Text.Trim) > 0 Then Fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTAMOUNT_Validating(sender As Object, e As CancelEventArgs) Handles TXTAMOUNT.Validating
        Try
            If CMBFINISHED.Text.Trim <> "" Then
                Fillgrid()
                TOTAL()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub CMBSHIPTO_Enter(sender As Object, e As EventArgs) Handles CMBSHIPTO.Enter
        Try
            If CMBSHIPTO.Text.Trim = "" Then FILLNAME(CMBSHIPTO, EDIT, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLWHATSAPPCLICK_Click(sender As Object, e As EventArgs) Handles TOOLWHATSAPPCLICK.Click
        Try
            Dim DT As New DataTable
            Dim OBJCMN As New ClsCommon
            If EDIT = True Then SENDWHATSAPP(TEMPINVOICENO)
            ' DT = OBJCMN.Execute_Any_String("UPDATE SALEORDER SET SO_SENDWHATSAPP = 1 WHERE SO_NO = " & TEMPPORFORMA & " AND SO_YEARID = " & YearId, "", "")
            LBLWHATSAPP.Visible = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Async Sub SENDWHATSAPP(INVNO As Integer)
        Try
            If ALLOWWHATSAPP = False Then Exit Sub
            If Not CHECKWHASTAPPEXP() Then
                MsgBox("Whatsapp Package has Expired, Kindly contact Nakoda Infotech on 02249724411", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If MsgBox("Send Whatsapp?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            Dim WHATSAPPNO As String = ""
            Dim OBJSO As New SaleInvoiceDesign
            OBJSO.MdiParent = MDIMain
            OBJSO.DIRECTPRINT = True
            OBJSO.FRMSTRING = "Invoice"
            OBJSO.DIRECTMAIL = True
            OBJSO.vendorname = CMBNAME.Text.Trim
            OBJSO.FORMULA = "{INVOICEMASTER.INVOICE_NO}=" & Val(INVNO) & " and {INVOICEMASTER.INVOICE_YEARID}=" & YearId
            OBJSO.INVNO = INVNO
            OBJSO.NOOFCOPIES = 1
            OBJSO.Show()
            OBJSO.Close()

            Dim OBJWHATSAPP As New SendWhatsapp
            OBJWHATSAPP.PARTYNAME = CMBNAME.Text.Trim
            'OBJWHATSAPP.AGENTNAME = CMBAGENT.Text.Trim
            'If CMBNAME.Text.Trim <> CMBPACKING.Text.Trim Then OBJWHATSAPP.OTHERNAME1 = CMBPACKING.Text.Trim
            OBJWHATSAPP.PATH.Add(Application.StartupPath & "\PIREPORT_" & Val(INVNO) & ".pdf")
            OBJWHATSAPP.FILENAME.Add("PIREPORT_" & Val(INVNO) & ".pdf")
            OBJWHATSAPP.ShowDialog()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBSHIPTO_Validating(sender As Object, e As CancelEventArgs) Handles CMBSHIPTO.Validating
        Try
            If CMBSHIPTO.Text.Trim <> "" Then namevalidate(CMBSHIPTO, CMBCODE, e, Me, TXTADD, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS'", "SUNDRY DEBTORS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTQTY_Validated(sender As Object, e As EventArgs) Handles TXTQTY.Validated, TXTRATE.Validated
        CALC()
    End Sub

    Sub CALC()
        Try
            TXTAMOUNT.Text = Format(Val(TXTQTY.Text.Trim) * Val(TXTRATE.Text.Trim), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTQTY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTQTY.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub


    Private Sub TXTREMARKS_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTREMARKS.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJREMARKS As New SelectRemarks
                OBJREMARKS.FRMSTRING = "NARRATION"
                OBJREMARKS.ShowDialog()
                If OBJREMARKS.TEMPNAME <> "" Then TXTREMARKS.Text = OBJREMARKS.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DTDATE_Validating(sender As Object, e As CancelEventArgs) Handles INVOICEDATE.Validating
        Try
            If INVOICEDATE.Text.Trim <> "__/__/____" Then
                Dim TEMP As DateTime
                If Not DateTime.TryParse(INVOICEDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTSIZE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTSIZE.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Sub fillchgsgrid()
        If GRIDCHGSDOUBLECLICK = False Then
            GRIDCHGS.Rows.Add(Val(TXTCHGSSRNO.Text.Trim), CMBCHARGES.Text.Trim, Val(TXTCHGSPER.Text.Trim), Format(Val(TXTCHGSAMT.Text.Trim), "0.00"), Val(TXTTAXID.Text.Trim))
            getsrno(GRIDCHGS)
        ElseIf GRIDCHGSDOUBLECLICK = True Then
            GRIDCHGS.Item(ESRNO.Index, TEMPCHGSROW).Value = Val(TXTCHGSSRNO.Text.Trim)
            GRIDCHGS.Item(ECHARGES.Index, TEMPCHGSROW).Value = CMBCHARGES.Text.Trim
            GRIDCHGS.Item(EPER.Index, TEMPCHGSROW).Value = Format(Val(TXTCHGSPER.Text.Trim), "0.00")
            GRIDCHGS.Item(EAMT.Index, TEMPCHGSROW).Value = Format(Val(TXTCHGSAMT.Text.Trim), "0.00")
            GRIDCHGS.Item(ETAXID.Index, TEMPCHGSROW).Value = Val(TXTTAXID.Text.Trim)

            GRIDCHGSDOUBLECLICK = False

        End If
        TOTAL()

        GRIDCHGS.FirstDisplayedScrollingRowIndex = GRIDCHGS.RowCount - 1

        TXTCHGSSRNO.Clear()
        CMBCHARGES.Text = ""
        TXTCHGSPER.Clear()
        TXTCHGSAMT.Clear()
        TXTTAXID.Clear()
        If TXTCHGSPER.ReadOnly = True Then TXTCHGSPER.ReadOnly = False

        If GRIDCHGS.RowCount > 0 Then
            TXTCHGSSRNO.Text = Val(GRIDCHGS.Rows(GRIDCHGS.RowCount - 1).Cells(0).Value) + 1
        Else
            TXTCHGSSRNO.Text = 1
        End If
        TXTCHGSSRNO.Focus()
    End Sub

    Private Sub CMBCHARGES_Enter(sender As Object, e As EventArgs) Handles CMBCHARGES.Enter
        Try
            If CMBCHARGES.Text.Trim = "" Then FILLNAME(CMBCHARGES, EDIT, " and (GROUPMASTER.GROUP_SECONDARY = 'Duties & Taxes' OR GROUPMASTER.GROUP_SECONDARY = 'Sales A/C' OR GROUPMASTER.GROUP_SECONDARY = 'Indirect Income' or GROUPMASTER.GROUP_SECONDARY = 'Indirect Expenses' OR GROUPMASTER.GROUP_SECONDARY = 'Direct Income' or GROUPMASTER.GROUP_SECONDARY = 'Direct Expenses')")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCHARGES_Validated(sender As Object, e As EventArgs) Handles CMBCHARGES.Validated
        Try
            If CMBCHARGES.Text.Trim <> "" Then
                'filltax()

                'GET ADDLESS DONE BY GULKIT
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.SEARCH("ISNULL(LEDGERS.ACC_ADDLESS,'ADD') AS ADDLESS, ISNULL(LEDGERS.ACC_DISC,0) AS DISCPER ", "", "LEDGERS", " AND ACC_CMPNAME = '" & CMBCHARGES.Text.Trim & "' AND ACC_YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    If DT.Rows(0).Item("ADDLESS") = "LESS" Then
                        If Val(TXTCHGSPER.Text.Trim) = 0 Then
                            TXTCHGSPER.Text = "-"
                            If ClientName = "SOFTAS" And Val(DT.Rows(0).Item("DISCPER")) > 0 Then TXTCHGSPER.Text = Val(DT.Rows(0).Item("DISCPER")) * -1
                        End If
                        If Val(TXTCHGSAMT.Text.Trim) = 0 Then TXTCHGSAMT.Text = "-"
                        TXTCHGSPER.Select(TXTCHGSPER.Text.Length, 0)
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Sub filltax()
        Try
            TXTCHGSPER.ReadOnly = False
            TXTCHGSAMT.ReadOnly = False
            TXTTAXID.Text = 0
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable = objclscommon.search(" ISNULL(tax_tax, 0) as TAX, TAX_ID AS TAXID ", "", " TAXMASTER", " AND tax_name = '" & CMBCHARGES.Text & "'  AND tax_cmpid=" & CmpId & " AND tax_LOCATIONID = " & Locationid & " AND tax_YEARID = " & YearId)
            If dt.Rows.Count > 0 Then
                TXTCHGSPER.Text = dt.Rows(0).Item("TAX")
                TXTTAXID.Text = Val(dt.Rows(0).Item("TAXID"))
                If Val(TXTCHGSPER.Text.Trim) > 0 Then TXTCHGSAMT.ReadOnly = True
                TXTCHGSPER.ReadOnly = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBCHARGES_Validating(sender As Object, e As CancelEventArgs) Handles CMBCHARGES.Validating
        Try
            If CMBCHARGES.Text.Trim <> "" Then namevalidate(CMBCHARGES, CMBCODE, e, Me, TXTADD, " AND (GROUPMASTER.GROUP_SECONDARY = 'Duties & Taxes' OR GROUPMASTER.GROUP_SECONDARY = 'Indirect Income' or GROUPMASTER.GROUP_SECONDARY = 'Indirect Expenses' OR GROUPMASTER.GROUP_SECONDARY = 'Direct Income' or GROUPMASTER.GROUP_SECONDARY = 'Direct Expenses' OR GROUPMASTER.GROUP_SECONDARY = 'Sales A/C' )")
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub TXTCHGSAMT_Validated(sender As Object, e As EventArgs) Handles TXTCHGSAMT.Validated
        Try
            If CMBCHARGES.Text.Trim <> "" And Val(TXTCHGSAMT.Text.Trim) <> 0 Then
                Dim dDebit As Decimal
                Dim bValid As Boolean = Decimal.TryParse(TXTCHGSAMT.Text.Trim, dDebit)
                If bValid Then
                    TXTCHGSAMT.Text = Convert.ToDecimal(Val(TXTCHGSAMT.Text))


                    fillchgsgrid()
                    TOTAL()
                Else
                    MessageBox.Show("Invalid Number Entered")
                    'e.Cancel = True
                    TXTCHGSAMT.Clear()
                    Exit Sub
                End If
            Else
                If CMBCHARGES.Text.Trim = "" Then
                    MsgBox("Please Fill Charges Name ")
                    Exit Sub
                ElseIf Val(TXTCHGSPER.Text.Trim) = 0 And Val(TXTCHGSAMT.Text.Trim) = 0 Then
                    MsgBox("Amount can not be zero")
                    TXTCHGSAMT.Clear()
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCHGSPER_Validating(sender As Object, e As CancelEventArgs) Handles TXTCHGSPER.Validating
        Try
            Dim dDebit As Decimal
            Dim bValid As Boolean = Decimal.TryParse(TXTCHGSPER.Text.Trim, dDebit)
            If bValid Then
                If Val(TXTCHGSPER.Text) = 0 Then TXTCHGSPER.Text = ""
                TXTCHGSPER.Text = Convert.ToDecimal(Val(TXTCHGSPER.Text))
                '' everything is good
                calchgs()
            ElseIf Val(TXTCHGSPER.Text.Trim) = 0 Then
                TXTCHGSAMT.ReadOnly = False
            Else
                MessageBox.Show("Invalid Number Entered")
                'e.Cancel = True
                TXTCHGSPER.Clear()
                TXTCHGSPER.Focus()
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub calchgs()
        Try
            If Val(TXTCHGSPER.Text) <> 0 Then
                'before CALC CHECK HOW TO CALC CHARGES
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.SEARCH(" (CASE WHEN ISNULL(ACC_CALC,'') = '' THEN 'GROSS' ELSE ACC_CALC END) AS CALC", "", "LEDGERS", " AND ACC_CMPNAME = '" & CMBCHARGES.Text.Trim & "' AND ACC_YEARID = " & YearId)
                If DT.Rows(0).Item("CALC") = "GROSS" Then
                    TXTCHGSAMT.Text = Format((Val(txtbillamt.Text) * Val(TXTCHGSPER.Text)) / 100, "0.00")
                ElseIf DT.Rows(0).Item("CALC") = "NETT" Then
                    'FIRST CALC NETT THEN ADD CHARGES ON THAT NETT TOTAL
                    TXTNETTAMT.Text = Val(txtbillamt.Text.Trim)
                    For Each ROW As DataGridViewRow In GRIDCHGS.Rows
                        If GRIDCHGSDOUBLECLICK = True And ROW.Index >= TEMPCHGSROW Then Exit For
                        TXTNETTAMT.Text = Format(Val(TXTNETTAMT.Text) + Val(ROW.Cells(EAMT.Index).Value), "0.00")
                    Next
                    TXTCHGSAMT.Text = Format((Val(TXTNETTAMT.Text) * Val(TXTCHGSPER.Text)) / 100, "0.00")
                ElseIf DT.Rows(0).Item("CALC") = "QTY" Then
                    TXTCHGSAMT.Text = Format((Val(LBLTOTALQTY.Text) * Val(TXTCHGSPER.Text)), "0.00")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDCHGS_KeyDown(sender As Object, e As KeyEventArgs) Handles GRIDCHGS.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDCHGS.RowCount > 0 Then

                'dont allow user if any of the grid line is in edit mode.....
                'cmbMERCHANT.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If GRIDCHGSDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                GRIDCHGS.Rows.RemoveAt(GRIDCHGS.CurrentRow.Index)
                TOTAL()
                getsrno(GRIDCHGS)
            ElseIf e.KeyCode = Keys.F5 Then
                EDITCHGSROW()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub EDITCHGSROW()
        Try
            TXTCHGSPER.ReadOnly = False
            TXTCHGSAMT.ReadOnly = False
            If GRIDCHGS.CurrentRow.Index >= 0 And GRIDCHGS.Item(ESRNO.Index, GRIDCHGS.CurrentRow.Index).Value <> Nothing Then
                GRIDCHGSDOUBLECLICK = True
                TXTCHGSSRNO.Text = GRIDCHGS.Item(ESRNO.Index, GRIDCHGS.CurrentRow.Index).Value.ToString
                CMBCHARGES.Text = GRIDCHGS.Item(ECHARGES.Index, GRIDCHGS.CurrentRow.Index).Value.ToString
                TXTCHGSPER.Text = GRIDCHGS.Item(EPER.Index, GRIDCHGS.CurrentRow.Index).Value.ToString
                TXTCHGSAMT.Text = GRIDCHGS.Item(EAMT.Index, GRIDCHGS.CurrentRow.Index).Value.ToString
                TXTTAXID.Text = GRIDCHGS.Item(ETAXID.Index, GRIDCHGS.CurrentRow.Index).Value.ToString

                If Val(TXTCHGSPER.Text.Trim) > 0 Then TXTCHGSAMT.ReadOnly = True

                TEMPCHGSROW = GRIDCHGS.CurrentRow.Index
                TXTCHGSSRNO.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub CMDSELECTPS_Click(sender As Object, e As EventArgs) Handles CMDSELECTPS.Click
        Try
            EP.Clear()
            If CMBNAME.Text.Trim = "" Then
                MsgBox("Please Fill Party Name", MsgBoxStyle.Critical)
                CMBNAME.Focus()
                Exit Sub
            End If

            Dim OBJSO As New SelectPS
            OBJSO.PARTYNAME = CMBNAME.Text.Trim
            Dim DT As DataTable = OBJSO.DT
            OBJSO.ShowDialog()

            If DT.Rows.Count > 0 Then
                'FETCH DATA FROM SALEORDER_DESC WITH RESPECT TO SELECTED SONO
                TXTPSNO.Text = Val(DT.Rows(0).Item("PSNO"))
                DTPSDATE.Text = DT.Rows(0).Item("PSDATE")
                TXTPROFORMANO.Text = Val(DT.Rows(0).Item("PROFORMANO"))
                TXTORDERREFNO.Text = DT.Rows(0).Item("ORDERREFNO")
                TXTCONTAINER.Text = DT.Rows(0).Item("CONTAINER")
                CMBSHIPTO.Text = DT.Rows(0).Item("SHIPTO")
                CMBDESTINATION.Text = DT.Rows(0).Item("DESTINATION")
                CMBTRANSPORTNAME.Text = DT.Rows(0).Item("TRANSPORTNAME")
                CMBPORTDISCHARGE.Text = DT.Rows(0).Item("PORTDISCHARGE")
                CMBPORTLOADING.Text = DT.Rows(0).Item("PORTLOADING")
                CMBCURRENCY.Text = DT.Rows(0).Item("CURRENCY")
                CMBCIFFOB.Text = DT.Rows(0).Item("CIFFOB")
                TXTREMARKS.Text = DT.Rows(0).Item("REMARKS")

                For Each ROW As DataRow In DT.Rows
                    Dim OBJCMN As New ClsCommon
                    Dim DTSO As DataTable = OBJCMN.SEARCH(" ISNULL(PACKINGSLIP.PS_NO, 0) AS PSNO, PACKINGSLIP.PS_DATE AS PSDATE, ISNULL(PACKINGSLIP.PS_CIFOB, '') AS CIFFOB, ISNULL(PACKINGSLIP.PS_PROFORMANO, 0) AS PROFORMANO, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(SHIPTOLEDGERS.Acc_cmpname, '') AS SHIPTO, ISNULL(TRANSLEDGERS.Acc_cmpname, '') AS TRANSPORTNAME, ISNULL(PORTMASTER.PORT_name, '') AS PORTDISCHARGE, ISNULL(PORTLOADPORTMASTER.PORT_name, '') AS PORTLOADING, ISNULL(CURRENCYMASTER.CURR_NAME, '') AS CURRENCY,ISNULL(COUNTRYMASTER.COUNTRY_NAME, '') AS DESTINATION, ISNULL(PACKINGSLIP_DESC.PS_GRIDSRNO, 0) AS GRIDSRNO, ISNULL(PACKINGSLIP_DESC.PS_DESC, '')  AS GRIDDESC, ISNULL(PACKINGSLIP_DESC.PS_RATE, 0) AS RATE, ISNULL(PACKINGSLIP.PS_CONTAINER, '') AS CONTAINER, ISNULL(PACKINGSLIP_DESC.PS_GSM, 0) AS GSM, ISNULL(PACKINGSLIP_DESC.PS_GSMDETAILS, '') AS GSMDETAILS, ISNULL(PACKINGSLIP_DESC.PS_ROLLNO, '') AS ROLLNO, ISNULL(PACKINGSLIP_DESC.PS_SIZE, 0) AS SIZE, ISNULL(PACKINGSLIP_DESC.PS_FINALWT, 0) AS QTY, ISNULL(PACKINGSLIP_DESC.PS_JOINT, '') AS JOINT, ISNULL(PACKINGSLIP_DESC.PS_WT, 0) AS WT, ISNULL(PACKINGSLIP_DESC.PS_MTRS, 0) AS MTRS, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT, ISNULL(ITEMMASTER.ITEM_NAME, '') AS FINISHEDQUALITY, ISNULL(PACKINGSLIP.PS_ORDERREFNO, '') AS ORDERREFNO, ISNULL(PACKINGSLIP_DESC.PS_CLOSED, 0) AS CLOSED, ISNULL(PACKINGSLIP_DESC.PS_BARCODE, '') AS BARCODE, ISNULL(PACKINGSLIP_DESC.PS_FROMNO, 0) AS FROMNO, ISNULL(PACKINGSLIP_DESC.PS_FROMSRNO, 0) AS FROMSRNO ", "", " COUNTRYMASTER RIGHT OUTER JOIN PACKINGSLIP LEFT OUTER JOIN GODOWNMASTER ON PACKINGSLIP.PS_GODOWNID = GODOWNMASTER.GODOWN_id LEFT OUTER JOIN ITEMMASTER RIGHT OUTER JOIN PACKINGSLIP_DESC ON ITEMMASTER.item_id = PACKINGSLIP_DESC.PS_QUALITYID RIGHT OUTER JOIN UNITMASTER ON PACKINGSLIP_DESC.PS_UNITID = UNITMASTER.unit_id ON PACKINGSLIP.PS_YEARID = PACKINGSLIP_DESC.PS_YEARID AND PACKINGSLIP.PS_NO = PACKINGSLIP_DESC.PS_NO ON COUNTRYMASTER.COUNTRY_ID = PACKINGSLIP.PS_DESTINATIONID LEFT OUTER JOIN CURRENCYMASTER ON PACKINGSLIP.PS_CURRENCYID = CURRENCYMASTER.CURR_ID LEFT OUTER JOIN PORTMASTER AS PORTLOADPORTMASTER ON PACKINGSLIP.PS_PORTLOADINGID = PORTLOADPORTMASTER.PORT_id LEFT OUTER JOIN PORTMASTER ON PACKINGSLIP.PS_PORTDISCHARGEID = PORTMASTER.PORT_id LEFT OUTER JOIN LEDGERS AS TRANSLEDGERS ON PACKINGSLIP.PS_TRANSLEDGERID = TRANSLEDGERS.Acc_id LEFT OUTER JOIN LEDGERS AS SHIPTOLEDGERS ON PACKINGSLIP.PS_SHIPTOID = SHIPTOLEDGERS.Acc_id LEFT OUTER JOIN LEDGERS ON PACKINGSLIP.PS_LEDGERID = LEDGERS.Acc_id", " AND PACKINGSLIP_DESC.PS_NO = " & Val(TXTPSNO.Text.Trim) & " AND PACKINGSLIP_DESC.PS_YEARID = " & YearId)
                    For Each DTROW As DataRow In DTSO.Rows
                        GRIDINVOICE.Rows.Add(0, DTROW("FINISHEDQUALITY").ToString, "", DTROW("GRIDDESC").ToString, DTROW("ROLLNO").ToString, DTROW("GSM").ToString, DTROW("GSMDETAILS").ToString, DTROW("SIZE"), Format(DTROW("QTY"), "0.00"), DTROW("UNIT").ToString, Format(DTROW("RATE"), "0.00"), "")
                    Next
                Next
                getsrno(GRIDINVOICE)
                TOTAL()
                CMDSELECTPS.Enabled = False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDCHGS_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRIDCHGS.CellDoubleClick
        EDITCHGSROW()
    End Sub

    Private Sub TXTRATE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTRATE.KeyPress, TXTGSM.KeyPress, TXTFREIGHT.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub TXTGRIDTOTAL_Validating(sender As Object, e As CancelEventArgs)
        Fillgrid()
        TOTAL()
    End Sub

    Sub CALCEXPORT()
        Try
            'CAL RATE IF CLIENTNAME = AVIS AND EXPORTINV IS MADE
            If GRIDINVOICE.RowCount > 0 Then
                For Each row As DataGridViewRow In GRIDINVOICE.Rows
                    If ClientName = "ZALANI" And CHKOVERSEAS.Checked = True And Val(TXTROE.Text.Trim) > 0 Then
                        TXTSQMTRS.Text = Format(Val(TXTSQMTRS.Text.Trim) + Val(row.Cells(GQTY.Index).EditedFormattedValue) * 1.47, "0.00")
                        TXTTOTALUSDAMT.Text = Format(Val(TXTTOTALUSDAMT.Text.Trim) + (Val(row.Cells(GQTY.Index).EditedFormattedValue) * Val(row.Cells(GQTY.Index).EditedFormattedValue)), "0.00")
                        TXTCUSTOMINVRATE.Text = Format(Val(TXTTOTALUSDAMT.Text.Trim) / Val(TXTSQMTRS.Text.Trim), "0.000")
                        TXTGSTINVRATE.Text = Format((Val(TXTCUSTOMINVRATE.Text.Trim) * Val(TXTROE.Text.Trim)), "0.000")
                    End If
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETHSNCODE()
        Try
            If Convert.ToDateTime(INVOICEDATE.Text).Date >= "01/07/2017" Then

                Dim OBJCMN As New ClsCommon
                'Dim DT As DataTable = OBJCMN.search("  ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(HSNMASTER.HSN_CGST, 0) AS CGSTPER, ISNULL(HSNMASTER.HSN_SGST, 0) AS SGSTPER, ISNULL(HSNMASTER.HSN_IGST, 0) AS IGSTPER,  ISNULL(HSNMASTER.HSN_EXPCGST, 0) AS EXPCGSTPER, ISNULL(HSNMASTER.HSN_EXPSGST, 0) AS EXPSGSTPER, ISNULL(HSNMASTER.HSN_EXPIGST, 0) AS EXPIGSTPER ", "", "HSNMASTER INNER JOIN ITEMMASTER ON HSNMASTER.HSN_ID = ITEMMASTER.ITEM_HSNCODEID AND HSNMASTER.HSN_YEARID = ITEMMASTER.item_yearid ", " AND ITEMMASTER.ITEM_NAME= '" & CMBITEM.Text.Trim & "' AND HSNMASTER.HSN_YEARID='" & YearId & "' ORDER BY HSNMASTER.HSN_ID DESC")
                Dim DT As DataTable = OBJCMN.SEARCH(" TOP 1 ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(HSNMASTER_DESC.HSN_CGST, 0) AS CGSTPER, ISNULL(HSNMASTER_DESC.HSN_SGST, 0) AS SGSTPER, ISNULL(HSNMASTER_DESC.HSN_IGST, 0) AS IGSTPER,  ISNULL(HSNMASTER_DESC.HSN_EXPCGST, 0) AS EXPCGSTPER, ISNULL(HSNMASTER_DESC.HSN_EXPSGST, 0) AS EXPSGSTPER, ISNULL(HSNMASTER_DESC.HSN_EXPIGST, 0) AS EXPIGSTPER ", "", "HSNMASTER INNER JOIN HSNMASTER_DESC ON HSNMASTER.HSN_ID = HSNMASTER_DESC.HSN_ID INNER JOIN ITEMMASTER ON HSNMASTER.HSN_ID = ITEMMASTER.ITEM_HSNCODEID AND HSNMASTER.HSN_YEARID = ITEMMASTER.item_yearid ", " AND HSNMASTER_DESC.HSN_WEFDATE <= '" & Format(Convert.ToDateTime(INVOICEDATE.Text).Date, "MM/dd/yyyy") & "' AND ITEMMASTER.ITEM_NAME= '" & CMBFINISHED.Text.Trim & "' AND HSNMASTER.HSN_YEARID=" & YearId & " ORDER BY HSNMASTER_DESC.HSN_WEFDATE DESC")
                If DT.Rows.Count > 0 Then


                    TXTHSNCODE.Clear()
                    'TXTCGSTPER.Clear()
                    'TXTCGSTAMT.Clear()
                    'TXTSGSTPER.Clear()
                    'TXTSGSTAMT.Clear()
                    'TXTIGSTPER.Clear()
                    'TXTIGSTAMT.Clear()


                    If CHKMANUAL.CheckState = CheckState.Unchecked Then
                        TXTCGSTPER1.Clear()
                        TXTCGSTAMT1.Clear()
                        TXTSGSTPER1.Clear()
                        TXTSGSTAMT1.Clear()
                        TXTIGSTPER1.Clear()
                        TXTIGSTAMT1.Clear()
                    End If

                    TXTHSNCODE.Text = DT.Rows(0).Item("HSNCODE")
                    'If TXTSTATECODE.Text.Trim = CMPSTATECODE Then

                    '    TXTIGSTPER.Text = 0
                    '    TXTIGSTPER1.Text = 0
                    '    If CHKEXPORTGST.CheckState = CheckState.Unchecked Then
                    '        TXTCGSTPER.Text = Val(DT.Rows(0).Item("CGSTPER"))
                    '        TXTSGSTPER.Text = Val(DT.Rows(0).Item("SGSTPER"))
                    '        TXTCGSTPER1.Text = Val(DT.Rows(0).Item("CGSTPER"))
                    '        TXTSGSTPER1.Text = Val(DT.Rows(0).Item("SGSTPER"))
                    '    Else
                    '        TXTCGSTPER.Text = Val(DT.Rows(0).Item("EXPCGSTPER"))
                    '        TXTSGSTPER.Text = Val(DT.Rows(0).Item("EXPSGSTPER"))
                    '        TXTCGSTPER1.Text = Val(DT.Rows(0).Item("EXPCGSTPER"))
                    '        TXTSGSTPER1.Text = Val(DT.Rows(0).Item("EXPSGSTPER"))
                    '    End If

                    'Else
                    '    TXTCGSTPER.Text = 0
                    '    TXTSGSTPER.Text = 0
                    '    TXTCGSTPER1.Text = 0
                    '    TXTSGSTPER1.Text = 0
                    '    If CHKEXPORTGST.CheckState = CheckState.Unchecked Then
                    '        TXTIGSTPER1.Text = Val(DT.Rows(0).Item("IGSTPER"))
                    '        TXTIGSTPER.Text = Val(DT.Rows(0).Item("IGSTPER"))
                    '    Else
                    '        TXTIGSTPER1.Text = Val(DT.Rows(0).Item("EXPIGSTPER"))
                    '        TXTIGSTPER.Text = Val(DT.Rows(0).Item("EXPIGSTPER"))
                    '    End If

                    'End If
                End If
                CALC()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBTRANSPORTNAME_Enter(sender As Object, e As EventArgs) Handles CMBTRANSPORTNAME.Enter
        Try
            If CMBTRANSPORTNAME.Text.Trim <> "" Then namevalidate(CMBTRANSPORTNAME, CMBCODE, e, Me, TXTADD, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "SUNDRY CREDITORS", "TRANSPORT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBTRANSPORTNAME_Validating(sender As Object, e As CancelEventArgs) Handles CMBTRANSPORTNAME.Validating
        Try
            If CMBTRANSPORTNAME.Text.Trim = "" Then FILLNAME(CMBTRANSPORTNAME, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'TRANSPORT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub ROLLCOUNT()
        Try
            LBLTOTALROLL.Text = 0
            Dim dic As New Dictionary(Of String, Integer)()
            Dim cellValue As String
            For i = 0 To GRIDINVOICE.Rows.Count - 1
                If Not GRIDINVOICE.Rows(i).IsNewRow Then
                    cellValue = GRIDINVOICE(GROLLNO.Index, i).EditedFormattedValue.ToString()
                    If cellValue <> "" Then
                        If Not dic.ContainsKey(cellValue) Then
                            dic.Add(cellValue, 1)
                        Else
                            dic(cellValue) += 1
                        End If
                    End If
                End If
            Next
            LBLTOTALROLL.Text = Val(dic.Count)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class