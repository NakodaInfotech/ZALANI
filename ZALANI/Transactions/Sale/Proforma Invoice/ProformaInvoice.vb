
Imports System.ComponentModel
Imports BL

Public Class ProformaInvoice

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE, GRIDDOUBLECLICK, GRIDCHGSDOUBLECLICK As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public EDIT As Boolean          'used for editing
    Public TEMPPORFORMA As String
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
        'TXTPRONO.ReadOnly = True
        LBLCLOSED.Visible = False

        TXTPRONO.Clear()
        DTDATE.Text = Now.Date
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
        GRIDPROFORMA.RowCount = 0
        LBLTOTALQTY.Text = 0.0
        LBLTOTALAMOUNT.Text = 0.0
        TXTSRNO.Text = 1
        CMBFINISHED.Text = ""
        TXTDESC.Text = ""
        TXTGSM.Clear()
        TXTSIZE.Clear()
        CMBFOIL.Text = ""
        TXTFOILGSM.Clear()
        TXTPEGSM.Clear()
        TXTROLLDIAMETER.Clear()
        TXTCOREPIPEWIDTH.Clear()
        CMBPALLETIZED.SelectedIndex = 0
        TXTNARRATION.Clear()
        TXTQTY.Clear()
        CMBUNIT.Text = ""
        TXTRATE.Clear()
        TXTAMOUNT.Clear()
        lbllocked.Visible = False
        LBLCLOSED.Visible = False
        getmax_PRONO()
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
        TXTSIZEDETAILS.Clear()
        PBlock.Visible = False
        TXTDELIVERYTIME.Clear()
        GRIDCHGSDOUBLECLICK = False
        GRIDDOUBLECLICK = False
    End Sub

    Sub getmax_PRONO()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(INVOICE_NO),0) + 1 ", "PROFORMAINVOICEMASTER", "  AND INVOICE_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTPRONO.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Private Sub ProformaInvoice_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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
                GRIDPROFORMA.Focus()
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
            If CMBFOIL.Text.Trim = "" Then FILLITEMNAME(CMBFOIL, " AND ITEM_FRMSTRING = 'MERCHANT'", "AND item_ITEMTYPE = 'FOIL'")
            If CMBUNIT.Text.Trim = "" Then FILLUNIT(CMBUNIT)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ProformaInvoice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                Dim OBJCLSPROFORMA As New ClsProformaInvoice
                OBJCLSPROFORMA.alParaval.Add(TEMPPORFORMA)
                OBJCLSPROFORMA.alParaval.Add(CmpId)
                OBJCLSPROFORMA.alParaval.Add(YearId)
                Dim dttable As DataTable = OBJCLSPROFORMA.SELECTINVOICE()
                If dttable.Rows.Count > 0 Then

                    For Each dr As DataRow In dttable.Rows

                        TXTPRONO.Text = TEMPPORFORMA
                        'TXTPRONO.ReadOnly = True
                        DTDATE.Text = Format(Convert.ToDateTime(dr("DATE")), "dd/MM/yyyy")
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

                        GRIDPROFORMA.Rows.Add(Val(dr("GRIDSRNO")), dr("FINISHEDQUALITY"), dr("GRIDDESC"), dr("GSM"), dr("GSMDETAILS"), dr("SIZE"), dr("SIZEDETAILS"), dr("FOILQUALITY"), dr("FOILGSM"), dr("PEGSM"), dr("ROLLDIAMETER"), dr("COREPIPEWIDTH"), dr("PALLETIZED"), dr("NARRATION"), Format(Val(dr("QTY")), "0.00"), dr("UNIT"), Format(Val(dr("RATE")), "0.00"), Format(Val(dr("AMOUNT")), "0.00"), dr("PODONE"), dr("SODONE"), dr("CLOSED"), dr("TYPE"))

                        If Convert.ToBoolean(dr("PODONE")) = True Or Convert.ToBoolean(dr("SODONE")) = True Then
                            GRIDPROFORMA.Rows(GRIDPROFORMA.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If

                        If Convert.ToBoolean(dr("CLOSED")) = True Then
                            GRIDPROFORMA.Rows(GRIDPROFORMA.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                            lbllocked.Visible = True
                            LBLCLOSED.Visible = True
                            PBlock.Visible = True
                        End If

                    Next
                    'CHARGES GRID

                    Dim dtable As DataTable = OBJCMN.SEARCH(" PROFORMAINVOICEMASTER_CHGS.INVOICE_ESRNO AS GRIDSRNO, LEDGERS.Acc_cmpname AS CHARGES, PROFORMAINVOICEMASTER_CHGS.INVOICE_PER AS PER, PROFORMAINVOICEMASTER_CHGS.INVOICE_AMT AS AMT, PROFORMAINVOICEMASTER_CHGS.INVOICE_TAXID AS TAXID ", "", " PROFORMAINVOICEMASTER_CHGS INNER JOIN LEDGERS ON PROFORMAINVOICEMASTER_CHGS.INVOICE_CHARGESID = LEDGERS.Acc_id  ", " AND PROFORMAINVOICEMASTER_CHGS.INVOICE_NO = " & TEMPPORFORMA & " AND PROFORMAINVOICEMASTER_CHGS.INVOICE_YEARID = " & YearId & " ORDER BY PROFORMAINVOICEMASTER_CHGS.INVOICE_Esrno")
                    If dtable.Rows.Count > 0 Then
                        For Each DTR As DataRow In dtable.Rows
                            GRIDCHGS.Rows.Add(DTR("GRIDSRNO"), DTR("CHARGES"), DTR("PER"), DTR("AMT"), DTR("TAXID"))
                        Next
                    End If

                    GRIDPROFORMA.FirstDisplayedScrollingRowIndex = GRIDPROFORMA.RowCount - 1
                    TOTAL()
                    DTDATE.Focus()
                Else
                    EDIT = False
                    CLEAR()
                End If
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
            If TXTPRONO.ReadOnly = False Then alParaval.Add(Val(TXTPRONO.Text.Trim)) Else alParaval.Add(0)
            alParaval.Add(Format(Convert.ToDateTime(DTDATE.Text).Date, "MM/dd/yyyy"))
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

            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)

            Dim GRIDSRNO As String = ""
            Dim FINISHEDQUALITY As String = ""
            Dim DESC As String = ""
            Dim GSM As String = ""
            Dim GSMDETAILS As String = ""
            Dim SIZE As String = ""
            Dim SIZEDETAILS As String = ""
            Dim FOILQUALITY As String = ""
            Dim FOILGSM As String = ""
            Dim PEGSM As String = ""
            Dim ROLLDIAMETER As String = ""
            Dim COREPIPEWIDTH As String = ""
            Dim PALLETIZED As String = ""
            Dim NARRATION As String = ""
            Dim QTY As String = ""
            Dim UNIT As String = ""
            Dim RATE As String = ""
            Dim AMOUNT As String = ""
            Dim PODONE As String = ""
            Dim SODONE As String = ""
            Dim CLOSED As String = ""
            Dim TYPE As String = ""


            For Each row As Windows.Forms.DataGridViewRow In GRIDPROFORMA.Rows
                If row.Cells(0).Value <> Nothing Then
                    If GRIDSRNO = "" Then
                        GRIDSRNO = Val(row.Cells(GSRNO.Index).Value)
                        FINISHEDQUALITY = row.Cells(GFINISHEDQUALITY.Index).Value.ToString
                        DESC = row.Cells(GDESC.Index).Value.ToString
                        GSM = row.Cells(GGSM.Index).Value.ToString
                        GSMDETAILS = row.Cells(GGSMDETAILS.Index).Value.ToString
                        SIZE = row.Cells(GSIZE.Index).Value.ToString
                        SIZEDETAILS = row.Cells(GSIZEDETAILS.Index).Value.ToString
                        FOILQUALITY = row.Cells(GFOILQUALITY.Index).Value.ToString
                        FOILGSM = row.Cells(GFOILGSM.Index).Value.ToString
                        PEGSM = row.Cells(GPEGSM.Index).Value.ToString
                        ROLLDIAMETER = row.Cells(GROLLDIAMETER.Index).Value.ToString
                        COREPIPEWIDTH = row.Cells(GCOREPIPEWIDTH.Index).Value.ToString
                        PALLETIZED = row.Cells(GPALLETIZED.Index).Value.ToString
                        NARRATION = row.Cells(GNARRATION.Index).Value.ToString
                        QTY = Val(row.Cells(GQTY.Index).Value)
                        UNIT = row.Cells(GUNIT.Index).Value.ToString
                        RATE = Val(row.Cells(GRATE.Index).Value)
                        AMOUNT = Val(row.Cells(GAMOUNT.Index).Value)
                        If Convert.ToBoolean(row.Cells(GPODONE.Index).Value) = True Then PODONE = 1 Else PODONE = 0
                        If Convert.ToBoolean(row.Cells(GSODONE.Index).Value) = True Then SODONE = 1 Else SODONE = 0
                        If Convert.ToBoolean(row.Cells(GCLOSE.Index).Value) = True Then CLOSED = 1 Else CLOSED = 0
                        TYPE = row.Cells(GTYPE.Index).Value.ToString

                    Else

                        GRIDSRNO = GRIDSRNO & "|" & Val(row.Cells(GSRNO.Index).Value)
                        FINISHEDQUALITY = FINISHEDQUALITY & "|" & row.Cells(GFINISHEDQUALITY.Index).Value.ToString
                        DESC = DESC & "|" & row.Cells(GDESC.Index).Value.ToString
                        GSM = GSM & "|" & row.Cells(GGSM.Index).Value.ToString
                        GSMDETAILS = GSMDETAILS & "|" & row.Cells(GGSMDETAILS.Index).Value.ToString
                        SIZE = SIZE & "|" & row.Cells(GSIZE.Index).Value
                        SIZEDETAILS = SIZEDETAILS & "|" & row.Cells(GSIZEDETAILS.Index).Value
                        FOILQUALITY = FOILQUALITY & "|" & row.Cells(GFOILQUALITY.Index).Value.ToString
                        FOILGSM = FOILGSM & "|" & row.Cells(GFOILGSM.Index).Value.ToString
                        PEGSM = PEGSM & "|" & row.Cells(GPEGSM.Index).Value.ToString
                        ROLLDIAMETER = ROLLDIAMETER & "|" & row.Cells(GROLLDIAMETER.Index).Value.ToString
                        COREPIPEWIDTH = COREPIPEWIDTH & "|" & row.Cells(GCOREPIPEWIDTH.Index).Value.ToString
                        PALLETIZED = PALLETIZED & "|" & row.Cells(GPALLETIZED.Index).Value.ToString
                        NARRATION = NARRATION & "|" & row.Cells(GNARRATION.Index).Value.ToString
                        QTY = QTY & "|" & Val(row.Cells(GQTY.Index).Value)
                        UNIT = UNIT & "|" & row.Cells(GUNIT.Index).Value.ToString
                        RATE = RATE & "|" & Val(row.Cells(GRATE.Index).Value)
                        AMOUNT = AMOUNT & "|" & Val(row.Cells(GAMOUNT.Index).Value)
                        If Convert.ToBoolean(row.Cells(GPODONE.Index).Value) = True Then PODONE = PODONE & "|" & "1" Else PODONE = PODONE & "|" & "0"
                        If Convert.ToBoolean(row.Cells(GSODONE.Index).Value) = True Then SODONE = SODONE & "|" & "1" Else SODONE = SODONE & "|" & "0"
                        If Convert.ToBoolean(row.Cells(GCLOSE.Index).Value) = True Then CLOSED = CLOSED & "|" & "1" Else CLOSED = CLOSED & "|" & "0"
                        TYPE = TYPE & "|" & row.Cells(GTYPE.Index).Value.ToString


                    End If
                End If
            Next

            alParaval.Add(GRIDSRNO)
            alParaval.Add(FINISHEDQUALITY)
            alParaval.Add(DESC)
            alParaval.Add(GSM)
            alParaval.Add(GSMDETAILS)
            alParaval.Add(SIZE)
            alParaval.Add(SIZEDETAILS)
            alParaval.Add(FOILQUALITY)
            alParaval.Add(FOILGSM)
            alParaval.Add(PEGSM)
            alParaval.Add(ROLLDIAMETER)
            alParaval.Add(COREPIPEWIDTH)
            alParaval.Add(PALLETIZED)
            alParaval.Add(NARRATION)
            alParaval.Add(QTY)
            alParaval.Add(UNIT)
            alParaval.Add(RATE)
            alParaval.Add(AMOUNT)
            alParaval.Add(PODONE)
            alParaval.Add(SODONE)
            alParaval.Add(CLOSED)
            alParaval.Add(TYPE)


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


            Dim objclsPurord As New ClsProformaInvoice()
            objclsPurord.alParaval = alParaval

            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim DT As DataTable = objclsPurord.SAVE()
                MessageBox.Show("Details Added")
                TXTPRONO.Text = DT.Rows(0).Item(0)
            Else


                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPPORFORMA)
                IntResult = objclsPurord.UPDATE()
                MessageBox.Show("Details Updated")
                EDIT = False
            End If

            PRINTREPORT(Val(TXTPRONO.Text.Trim))
            CLEAR()
            CMBNAME.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub PRINTREPORT(ByVal PROFORMANO As Integer)
        Try
            If MsgBox("Wish to Print Proforma Invoice?", MsgBoxStyle.YesNo) = vbNo Then Exit Sub
            Dim OBJPROFORMA As New SaleInvoiceDesign
            OBJPROFORMA.FRMSTRING = "PROFORMA"
            OBJPROFORMA.INVNO = PROFORMANO
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
            If Val(TXTPRONO.Text.Trim) <> 0 And CMBNAME.Text.Trim <> "" And EDIT = False Then
                Dim OBJCMN As New ClsCommon
                Dim dttable As DataTable = OBJCMN.SEARCH(" ISNULL(PROFORMAINVOICEMASTER.INVOICE_NO, '') AS INVOICENO ", "", " PROFORMAINVOICEMASTER ", "  AND INVOICE_NO = " & Val(TXTPRONO.Text.Trim) & " AND PROFORMAINVOICEMASTER.INVOICE_YEARID = " & YearId)
                If dttable.Rows.Count > 0 Then
                    EP.SetError(TXTPRONO, "Proforma No Already Exist")
                    bln = False
                End If
            End If
        End If

        If DTDATE.Text = "__/__/____" Then
            EP.SetError(DTDATE, " Please Enter Proper Date")
            bln = False
        Else
            If Not datecheck(DTDATE.Text) Then
                EP.SetError(DTDATE, "Date not in Accounting Year")
                bln = False
            End If
        End If

        If GRIDPROFORMA.RowCount = 0 Then
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

                If Convert.ToDateTime(DTDATE.Text).Date < SALEBLOCKDATE.Date Then
                    MsgBox("Date is Blocked, Please Delete entries after " & Format(SALEBLOCKDATE.Date, "dd/MM/yyyy"), MsgBoxStyle.Critical)
                    Exit Sub
                End If

                If MsgBox("Delete Proforma Invoice?", MsgBoxStyle.YesNo) = vbYes Then
                    Dim alParaval As New ArrayList
                    alParaval.Add(Val(TEMPPORFORMA))
                    alParaval.Add(CmpId)
                    alParaval.Add(YearId)

                    Dim ClsINCTAG As New ClsProformaInvoice()
                    ClsINCTAG.alParaval = alParaval
                    Dim IntResult As Integer = ClsINCTAG.DELETE()
                    MsgBox("Proforma Invoice Deleted")
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
            GRIDPROFORMA.RowCount = 0
LINE1:
            TEMPPORFORMA = Val(TXTPRONO.Text) - 1
            If TEMPPORFORMA > 0 Then
                EDIT = True
                ProformaInvoice_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If

            If GRIDPROFORMA.RowCount = 0 And TEMPPORFORMA > 1 Then
                TXTPRONO.Text = TEMPPORFORMA
                GoTo LINE1
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(sender As Object, e As EventArgs) Handles toolnext.Click
        Try
            GRIDPROFORMA.RowCount = 0
LINE1:
            TEMPPORFORMA = Val(TXTPRONO.Text) + 1
            getmax_PRONO()
            Dim MAXNO As Integer = TXTPRONO.Text.Trim
            CLEAR()
            If Val(TXTPRONO.Text) - 1 >= TEMPPORFORMA Then
                EDIT = True
                ProformaInvoice_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
            If GRIDPROFORMA.RowCount = 0 And TEMPPORFORMA < MAXNO Then
                TXTPRONO.Text = TEMPPORFORMA
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

            Dim objINVDTLS As New ProformaInvoiceDetails
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
            If EDIT = True Then PRINTREPORT(TEMPPORFORMA)
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
                GRIDPROFORMA.RowCount = 0
                TEMPPORFORMA = Val(tstxtbillno.Text)
                If TEMPPORFORMA > 0 Then
                    EDIT = True
                    ProformaInvoice_Load(sender, e)
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

    Sub EDITROW()
        Try
            If GRIDPROFORMA.CurrentRow.Index >= 0 And GRIDPROFORMA.Item(GSRNO.Index, GRIDPROFORMA.CurrentRow.Index).Value <> Nothing Then
                If Convert.ToBoolean(GRIDPROFORMA.Rows(GRIDPROFORMA.CurrentRow.Index).Cells(GPODONE.Index).Value) = True Then
                    MsgBox("Item Locked. First Delete from Purchase Order")
                    Exit Sub
                End If

                If Convert.ToBoolean(GRIDPROFORMA.Rows(GRIDPROFORMA.CurrentRow.Index).Cells(GSODONE.Index).Value) = True Then
                    MsgBox("Item Locked. First Delete from Sale Order")
                    Exit Sub
                End If

                GRIDDOUBLECLICK = True
                TXTSRNO.Text = Val(GRIDPROFORMA.Item(GSRNO.Index, GRIDPROFORMA.CurrentRow.Index).Value)
                CMBFINISHED.Text = GRIDPROFORMA.Item(GFINISHEDQUALITY.Index, GRIDPROFORMA.CurrentRow.Index).Value.ToString
                TXTDESC.Text = GRIDPROFORMA.Item(GDESC.Index, GRIDPROFORMA.CurrentRow.Index).Value.ToString
                TXTGSM.Text = GRIDPROFORMA.Item(GGSM.Index, GRIDPROFORMA.CurrentRow.Index).Value.ToString
                TXTGSMDETAILS.Text = GRIDPROFORMA.Item(GGSMDETAILS.Index, GRIDPROFORMA.CurrentRow.Index).Value.ToString
                TXTSIZE.Text = GRIDPROFORMA.Item(GSIZE.Index, GRIDPROFORMA.CurrentRow.Index).Value.ToString
                TXTSIZEDETAILS.Text = GRIDPROFORMA.Item(GSIZEDETAILS.Index, GRIDPROFORMA.CurrentRow.Index).Value.ToString
                CMBFOIL.Text = GRIDPROFORMA.Item(GFOILQUALITY.Index, GRIDPROFORMA.CurrentRow.Index).Value.ToString
                TXTFOILGSM.Text = GRIDPROFORMA.Item(GFOILGSM.Index, GRIDPROFORMA.CurrentRow.Index).Value.ToString
                TXTPEGSM.Text = GRIDPROFORMA.Item(GPEGSM.Index, GRIDPROFORMA.CurrentRow.Index).Value.ToString
                TXTROLLDIAMETER.Text = GRIDPROFORMA.Item(GROLLDIAMETER.Index, GRIDPROFORMA.CurrentRow.Index).Value.ToString
                TXTCOREPIPEWIDTH.Text = GRIDPROFORMA.Item(GCOREPIPEWIDTH.Index, GRIDPROFORMA.CurrentRow.Index).Value.ToString
                CMBPALLETIZED.Text = GRIDPROFORMA.Item(GPALLETIZED.Index, GRIDPROFORMA.CurrentRow.Index).Value.ToString
                TXTNARRATION.Text = GRIDPROFORMA.Item(GNARRATION.Index, GRIDPROFORMA.CurrentRow.Index).Value.ToString
                TXTQTY.Text = Val(GRIDPROFORMA.Item(GQTY.Index, GRIDPROFORMA.CurrentRow.Index).Value)
                CMBUNIT.Text = GRIDPROFORMA.Item(GUNIT.Index, GRIDPROFORMA.CurrentRow.Index).Value.ToString
                TXTRATE.Text = Val(GRIDPROFORMA.Item(GRATE.Index, GRIDPROFORMA.CurrentRow.Index).Value)
                TXTAMOUNT.Text = Val(GRIDPROFORMA.Item(GAMOUNT.Index, GRIDPROFORMA.CurrentRow.Index).Value)

                TEMPROW = GRIDPROFORMA.CurrentRow.Index
                CMBFINISHED.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDPROFORMA_KeyDown(sender As Object, e As KeyEventArgs) Handles GRIDPROFORMA.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDPROFORMA.RowCount > 0 Then
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                GRIDPROFORMA.Rows.RemoveAt(GRIDPROFORMA.CurrentRow.Index)
                TOTAL()
                getsrno(GRIDPROFORMA)
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
                Dim DT As DataTable = OBJCMN.SEARCH(" ISNULL(PORTMASTER.PORT_name, '') AS PORTDISCHARGE, ISNULL(PORTLOADINGPORTMASTER.PORT_name, '') AS PORTLOADING, ISNULL(LEDGERS.ACC_WARNING, '') AS WARNING, ISNULL(LEDGERS.Acc_remarks, '')  AS REMARKS, ISNULL(COUNTRYMASTER.country_name, '') AS DESTINATION", "", " LEDGERS LEFT OUTER JOIN COUNTRYMASTER ON LEDGERS.Acc_countryid = COUNTRYMASTER.country_id LEFT OUTER JOIN PORTMASTER AS PORTLOADINGPORTMASTER ON LEDGERS.ACC_PORTLOADINGID = PORTLOADINGPORTMASTER.PORT_id LEFT OUTER JOIN PORTMASTER ON LEDGERS.ACC_PORTDISCHARGEID = PORTMASTER.PORT_id ", " and LEDGERS.acc_cmpname = '" & CMBNAME.Text.Trim & "' and LEDGERS.acc_YEARid = " & YearId)
                If DT.Rows.Count > 0 Then
                    If TXTPAYMENTTERM.Text.Trim = "" Then TXTPAYMENTTERM.Text = DT.Rows(0).Item("REMARKS")
                    If CMBPORTDISCHARGE.Text.Trim = "" Then CMBPORTDISCHARGE.Text = DT.Rows(0).Item("PORTDISCHARGE")
                    If CMBPORTLOADING.Text.Trim = "" Then CMBPORTLOADING.Text = DT.Rows(0).Item("PORTLOADING")
                    If CMBDESTINATION.Text.Trim = "" Then CMBDESTINATION.Text = DT.Rows(0).Item("DESTINATION")
                    If DT.Rows(0).Item("WARNING") <> "" Then MsgBox(DT.Rows(0).Item("WARNING"), MsgBoxStyle.Critical)
                End If
                If CMBSHIPTO.Text.Trim = "" Then CMBSHIPTO.Text = CMBNAME.Text.Trim
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub Fillgrid()
        Try
            If GRIDDOUBLECLICK = False Then
                GRIDPROFORMA.Rows.Add(Val(TXTSRNO.Text.Trim), CMBFINISHED.Text.Trim, TXTDESC.Text.Trim, TXTGSM.Text.Trim, TXTGSMDETAILS.Text.Trim, TXTSIZE.Text.Trim, TXTSIZEDETAILS.Text.Trim, CMBFOIL.Text.Trim, TXTFOILGSM.Text.Trim, TXTPEGSM.Text.Trim, TXTROLLDIAMETER.Text.Trim, TXTCOREPIPEWIDTH.Text.Trim, CMBPALLETIZED.Text.Trim, TXTNARRATION.Text.Trim, Format(Val(TXTQTY.Text.Trim), "0.00"), CMBUNIT.Text.Trim, Format(Val(TXTRATE.Text.Trim), "0.00"), Format(Val(TXTAMOUNT.Text.Trim), "0.00"), 0, 0, 0, "PROFORMA")
                getsrno(GRIDPROFORMA)
            ElseIf GRIDDOUBLECLICK = True Then
                GRIDPROFORMA.Item(GSRNO.Index, TEMPROW).Value = Val(TXTSRNO.Text.Trim)
                GRIDPROFORMA.Item(GFINISHEDQUALITY.Index, TEMPROW).Value = CMBFINISHED.Text.Trim
                GRIDPROFORMA.Item(GDESC.Index, TEMPROW).Value = TXTDESC.Text.Trim
                GRIDPROFORMA.Item(GGSM.Index, TEMPROW).Value = TXTGSM.Text.Trim
                GRIDPROFORMA.Item(GGSMDETAILS.Index, TEMPROW).Value = TXTGSMDETAILS.Text.Trim
                GRIDPROFORMA.Item(GSIZE.Index, TEMPROW).Value = TXTSIZE.Text.Trim
                GRIDPROFORMA.Item(GSIZEDETAILS.Index, TEMPROW).Value = TXTSIZEDETAILS.Text.Trim
                GRIDPROFORMA.Item(GFOILQUALITY.Index, TEMPROW).Value = (CMBFOIL.Text.Trim)
                GRIDPROFORMA.Item(GFOILGSM.Index, TEMPROW).Value = (TXTFOILGSM.Text.Trim)
                GRIDPROFORMA.Item(GPEGSM.Index, TEMPROW).Value = (TXTPEGSM.Text.Trim)
                GRIDPROFORMA.Item(GROLLDIAMETER.Index, TEMPROW).Value = (TXTROLLDIAMETER.Text.Trim)
                GRIDPROFORMA.Item(GCOREPIPEWIDTH.Index, TEMPROW).Value = (TXTCOREPIPEWIDTH.Text.Trim)
                GRIDPROFORMA.Item(GPALLETIZED.Index, TEMPROW).Value = CMBPALLETIZED.Text.Trim
                GRIDPROFORMA.Item(GNARRATION.Index, TEMPROW).Value = (TXTNARRATION.Text.Trim)
                GRIDPROFORMA.Item(GQTY.Index, TEMPROW).Value = Format(Val(TXTQTY.Text.Trim), "0.00")
                GRIDPROFORMA.Item(GUNIT.Index, TEMPROW).Value = (CMBUNIT.Text.Trim)
                GRIDPROFORMA.Item(GRATE.Index, TEMPROW).Value = Format(Val(TXTRATE.Text.Trim), "0.00")
                GRIDPROFORMA.Item(GAMOUNT.Index, TEMPROW).Value = Format(Val(TXTAMOUNT.Text.Trim), "0.00")


                GRIDDOUBLECLICK = False

            End If
            TOTAL()


            GRIDPROFORMA.FirstDisplayedScrollingRowIndex = GRIDPROFORMA.RowCount - 1

            TXTSRNO.Text = GRIDPROFORMA.RowCount + 1
            CMBFINISHED.Text = ""
            TXTDESC.Text = ""
            TXTGSM.Clear()
            TXTSIZE.Clear()
            TXTSIZEDETAILS.Clear()
            CMBFOIL.Text = ""
            TXTFOILGSM.Clear()
            TXTPEGSM.Clear()
            ' TXTROLLDIAMETER.Clear()
            '  TXTCOREPIPEWIDTH.Clear()
            CMBPALLETIZED.Text = ""
            TXTNARRATION.Clear()
            TXTGSMDETAILS.Clear()
            TXTQTY.Clear()
            CMBUNIT.Text = ""
            TXTRATE.Clear()
            TXTAMOUNT.Clear()

            CMBFINISHED.Focus()
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

    Private Sub DTDATE_GotFocus(sender As Object, e As EventArgs) Handles DTDATE.GotFocus
        DTDATE.SelectionStart = 0
    End Sub

    Private Sub GRIDPROFORMA_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRIDPROFORMA.CellDoubleClick
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

            For Each ROW As DataGridViewRow In GRIDPROFORMA.Rows
                If ROW.Cells(GSRNO.Index).Value <> Nothing Then
                    LBLTOTALQTY.Text = Format(Val(LBLTOTALQTY.Text) + Val(ROW.Cells(GQTY.Index).EditedFormattedValue), "0.00")
                    LBLTOTALAMOUNT.Text = Format(Val(LBLTOTALAMOUNT.Text) + Val(ROW.Cells(GAMOUNT.Index).EditedFormattedValue), "0.00")
                End If
            Next
            txtbillamt.Text = Format(Val(LBLTOTALAMOUNT.Text.Trim), "0.00")


            If GRIDCHGS.RowCount > 0 Then
                For Each row As DataGridViewRow In GRIDCHGS.Rows
                    If SALEAUTODISCOUNT = True And ClientName <> "YASHVI" Then
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

            If Val(txtgrandtotal.Text) > 0 Then txtinwords.Text = CMBCURRENCY.Text.Trim + CurrencyToWord(txtgrandtotal.Text)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBFOIL_Enter(sender As Object, e As EventArgs) Handles CMBFOIL.Enter
        Try
            If CMBFOIL.Text.Trim = "" Then FILLITEMNAME(CMBFOIL, "", " AND ITEMMASTER.item_ITEMTYPE = 'FOIL'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBFOIL_Validating(sender As Object, e As CancelEventArgs) Handles CMBFOIL.Validating
        Try
            If CMBFOIL.Text.Trim <> "" Then ITEMVALIDATE(CMBFOIL, e, Me, "", "MERCHANT", "ITEMMASTER.ITEM_TYPE ='FOIL'")
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
            If EDIT = True Then SENDWHATSAPP(TEMPPORFORMA)
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
            OBJSO.FRMSTRING = "PROFORMA"
            OBJSO.DIRECTMAIL = True
            OBJSO.vendorname = CMBNAME.Text.Trim
            OBJSO.FORMULA = "{PROFORMAINVOICEMASTER.INVOICE_NO}=" & Val(INVNO) & " and {PROFORMAINVOICEMASTER.INVOICE_YEARID}=" & YearId
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

    Private Sub DTDATE_Validating(sender As Object, e As CancelEventArgs) Handles DTDATE.Validating
        Try
            If DTDATE.Text.Trim <> "__/__/____" Then
                Dim TEMP As DateTime
                If Not DateTime.TryParse(DTDATE.Text, TEMP) Then
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

    Private Sub GRIDCHGS_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRIDCHGS.CellDoubleClick
        EDITCHGSROW()
    End Sub

    Private Sub TXTFREIGHT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTFREIGHT.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub TXTRATE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTRATE.KeyPress, TXTPEGSM.KeyPress, TXTFOILGSM.KeyPress, TXTGSM.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub
End Class