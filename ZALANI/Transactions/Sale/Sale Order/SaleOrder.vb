
Imports System.ComponentModel
Imports BL

Public Class SaleOrder

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE, GRIDDOUBLECLICK As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public EDIT As Boolean          'used for editing
    Public TEMPSONO As Integer
    Dim TEMPROW As Integer

    Private Sub CMDCLEAR_Click(sender As Object, e As EventArgs) Handles CMDCLEAR.Click
        CLEAR()
        EDIT = False
    End Sub

    Private Sub CMDEXIT_Click(sender As Object, e As EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Sub CLEAR()

        EP.Clear()
        TXTSONO.ReadOnly = True
        CMBDESTINATION.Text = ""
        CMBSHIPTO.Text = ""
        TXTPROFORMANO.Clear()
        CMBPORTLOADING.Text = ""
        CMBPORTDISCHARGE.Text = ""
        CMBCURRENCY.Text = ""
        CMBCIFFOB.Text = ""
        CMBBANKDETAILS.Text = ""
        TXTPAYMENTTERM.Clear()
        TXTREMARKS.Clear()
        GRIDSO.RowCount = 0
        TXTSRNO.Clear()
        LBLTOTALQTY.Text = 0.0
        LBLTOTALAMOUNT.Text = 0.0
        TXTFREIGHT.Clear()
        TXTINSURANCE.Clear()
        CMBFINISHED.Text = ""
        TXTDESC.Clear()
        TXTGSM.Clear()
        TXTSIZE.Clear()
        CMBFOIL.Text = ""
        TXTFOILGSM.Clear()
        TXTPEGSM.Clear()
        TXTORDERREFNO.Clear()
        TXTROLLDIAMETER.Clear()
        TXTCOREPIPEWIDTH.Clear()
        CMBPALLETIZED.Text = ""
        TXTNARRATION.Clear()
        TXTQTY.Clear()
        CMBUNIT.Text = ""
        TXTRATE.Clear()
        TXTAMOUNT.Clear()
        TXTREMARKS.Clear()
        CMBNAME.Text = ""
        getmax_SO_NO()
        TXTSRNO.Text = 1
        TSTXTBILLNO.Clear()
        SODATE.Text = Now.Date
        TXTPROFORMATYPE.Clear()
        PBLOCK.Visible = False
        LBLLOCKED.Visible = False
        PROFORMADATE.Clear()
        GRIDDOUBLECLICK = False
        TXTGSMDETAILS.Clear()
        TXTSPECIALREMARKS.Clear()
        TXTSIZEDETAILS.Clear()
        TXTMOTHERSIZE.Clear()
        TXTWASTAGEPER.Clear()


    End Sub

    Sub getmax_SO_NO()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(SO_NO),0) + 1 ", "SALEORDER", "  AND SO_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTSONO.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Private Sub SaleOrder_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If ERRORVALID() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()

            ElseIf e.KeyCode = Keys.OemQuotes Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.F5 Then
                GRIDSO.Focus()
            ElseIf e.Alt = True And e.KeyCode = Keys.Left Then
                toolprevious_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Keys.Right Then
                toolnext_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
                Call OpenToolStripButton_Click(sender, e)

            ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for billno foucs
                TSTXTBILLNO.Focus()
                TSTXTBILLNO.SelectAll()

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

    Private Sub SaleOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                Dim OBJSO As New ClsSaleOrder()
                Dim DTTABLE As DataTable = OBJSO.SELECTSO(TEMPSONO, YearId)
                If DTTABLE.Rows.Count > 0 Then
                    For Each DR As DataRow In DTTABLE.Rows
                        TXTSONO.Text = TEMPSONO
                        TXTSONO.ReadOnly = True
                        SODATE.Text = Format(Convert.ToDateTime(DR("DATE")), "dd/MM/yyyy")
                        CMBNAME.Text = Convert.ToString(DR("NAME"))
                        CMBPORTDISCHARGE.Text = Convert.ToString(DR("PORTDISCHARGE"))
                        CMBPORTLOADING.Text = Convert.ToString(DR("PORTLOADING"))
                        CMBDESTINATION.Text = Convert.ToString(DR("DESTINATION"))
                        CMBCIFFOB.Text = Convert.ToString(DR("CIFFOB"))
                        CMBCURRENCY.Text = Convert.ToString(DR("CURRENCY"))
                        CMBBANKDETAILS.Text = Convert.ToString(DR("BANKDETAILS"))
                        CMBSHIPTO.Text = DR("SHIPTO")
                        TXTORDERREFNO.Text = DR("ORDERREFNO")
                        TXTPAYMENTTERM.Text = DR("PAYMENTTERM")
                        TXTREMARKS.Text = DR("REMARKS")
                        TXTPROFORMANO.Text = DR("PROFORMANO")
                        PROFORMADATE.Text = DR("PROFORMADATE")
                        TXTPROFORMATYPE.Text = DR("PROFORMATYPE")
                        LBLTOTALQTY.Text = DR("TOTALQTY")
                        LBLTOTALAMOUNT.Text = DR("TOTALAMOUNT")
                        TXTFREIGHT.Text = DR("FREIGHT")
                        TXTINSURANCE.Text = DR("INSURANCE")
                        TXTSPECIALREMARKS.Text = DR("SPECIALREMARKS")
                        TXTWASTAGEPER.Text = DR("WASTAGEPER")



                        GRIDSO.Rows.Add(Val(DR("GRIDSRNO")), DR("FINISHEDQUALITY"), DR("GRIDDESC"), DR("GSM"), DR("GSMDETAILS"), DR("MOTHERSIZE"), DR("SIZE"), DR("SIZEDETAILS"), DR("FOILQUALITY"), DR("FOILGSM"), DR("PEGSM"), DR("ROLLDIAMETER"), DR("COREPIPEWIDTH"), DR("PALLETIZED"), DR("NARRATION"), Format(Val(DR("QTY")), "0.00"), DR("UNIT"), Format(Val(DR("RATE")), "0.00"), Format(Val(DR("AMOUNT")), "0.00"), DR("JOQTYPE"), DR("JOQTYLAMINATION"), DR("JOQTYSLITTING"), DR("OUTQTY"), DR("CLOSED"), Val(DR("FROMNO")), DR("REQDONE"), DR("TYPE"))
                        If Val(DR("QTY")) = Val(DR("JOQTYPE")) Or Val(DR("QTY")) = Val(DR("JOQTYLAMINATION")) Or Val(DR("QTY")) = Val(DR("JOQTYSLITTING")) Then
                            GRIDSO.Rows(GRIDSO.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                            LBLLOCKED.Visible = True
                            PBLOCK.Visible = True
                        End If

                        If Val(DR("QTY")) = Val(DR("OUTQTY")) Then
                            GRIDSO.Rows(GRIDSO.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                            LBLLOCKED.Visible = True
                            PBLOCK.Visible = True
                        End If

                        If Convert.ToBoolean(DR("REQDONE")) = True Then
                            GRIDSO.Rows(GRIDSO.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                            LBLLOCKED.Visible = True
                            PBLOCK.Visible = True
                        End If

                    Next

                    GRIDSO.FirstDisplayedScrollingRowIndex = GRIDSO.RowCount - 1
                    TOTAL()
                    SODATE.Focus()
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
    Private Sub CMDOK_Click(sender As Object, e As EventArgs) Handles CMDOK.Click
        If ISLOCKYEAR = True Then
            MsgBox("Unable to Make changes, Year is Locked", MsgBoxStyle.Critical)
            Exit Sub
        End If
        Try


            Cursor.Current = Cursors.WaitCursor

            Dim IntResult As Integer

            EP.Clear()
            If Not ERRORVALID() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList
            If TXTSONO.ReadOnly = False Then
                alParaval.Add(Val(TXTSONO.Text.Trim))
            Else
                alParaval.Add(0)
            End If


            alParaval.Add(Format(Convert.ToDateTime(SODATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(CMBNAME.Text.Trim)
            alParaval.Add(CMBSHIPTO.Text.Trim)
            alParaval.Add(TXTPROFORMANO.Text.Trim)
            alParaval.Add(PROFORMADATE.Text.Trim)
            alParaval.Add(TXTPROFORMATYPE.Text.Trim)
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
            alParaval.Add(Val(TXTINSURANCE.Text.Trim))
            alParaval.Add(TXTSPECIALREMARKS.Text.Trim)
            alParaval.Add(TXTWASTAGEPER.Text.Trim)


            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)

            Dim gridsrno As String = ""
            Dim FINISHEDQUALITY As String = ""
            Dim DESC As String = ""
            Dim GSM As String = ""
            Dim GSMDETAILS As String = ""
            Dim MOTHERSIZE As String = ""
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
            Dim JOQTYPE As String = ""
            Dim JOQTYLAMINATION As String = ""
            Dim JOQTYSLITTING As String = ""
            Dim OUTQTY As String = ""
            Dim CLOSED As String = ""
            Dim FROMNO As String = ""
            Dim REQDONE As String = ""
            Dim TYPE As String = ""




            For Each row As Windows.Forms.DataGridViewRow In GRIDSO.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = Val(row.Cells(GSRNO.Index).Value)
                        FINISHEDQUALITY = row.Cells(GFINISHEDQUALITY.Index).Value.ToString
                        DESC = row.Cells(GDESC.Index).Value.ToString
                        GSM = row.Cells(GGSM.Index).Value.ToString
                        GSMDETAILS = row.Cells(GGSMDETAILS.Index).Value.ToString
                        MOTHERSIZE = row.Cells(GMOTHERSIZE.Index).Value.ToString
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
                        JOQTYPE = Val(row.Cells(GJOQTYPE.Index).Value)
                        JOQTYLAMINATION = Val(row.Cells(GJOQTYLAMINATION.Index).Value)
                        JOQTYSLITTING = Val(row.Cells(GJOQTYSLITTING.Index).Value)
                        OUTQTY = Val(row.Cells(GOUTQTY.Index).Value)
                        If Convert.ToBoolean(row.Cells(GCLOSED.Index).Value) = True Then CLOSED = 1 Else CLOSED = 0
                        FROMNO = Val(row.Cells(GFROMNO.Index).Value)
                        If Convert.ToBoolean(row.Cells(GREQDONE.Index).Value) = True Then REQDONE = 1 Else REQDONE = 0
                        TYPE = row.Cells(GTYPE.Index).Value.ToString


                    Else

                        gridsrno = gridsrno & "|" & Val(row.Cells(GSRNO.Index).Value)
                        FINISHEDQUALITY = FINISHEDQUALITY & "|" & row.Cells(GFINISHEDQUALITY.Index).Value.ToString
                        DESC = DESC & "|" & row.Cells(GDESC.Index).Value.ToString
                        GSM = GSM & "|" & row.Cells(GGSM.Index).Value.ToString
                        GSMDETAILS = GSMDETAILS & "|" & row.Cells(GGSMDETAILS.Index).Value.ToString
                        MOTHERSIZE = MOTHERSIZE & "|" & row.Cells(GMOTHERSIZE.Index).Value.ToString
                        SIZE = SIZE & "|" & row.Cells(GSIZE.Index).Value.ToString
                        SIZEDETAILS = SIZEDETAILS & "|" & row.Cells(GSIZEDETAILS.Index).Value.ToString
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
                        JOQTYPE = JOQTYPE & "|" & Val(row.Cells(GJOQTYPE.Index).Value)
                        JOQTYLAMINATION = JOQTYLAMINATION & "|" & Val(row.Cells(GJOQTYLAMINATION.Index).Value)
                        JOQTYSLITTING = JOQTYSLITTING & "|" & Val(row.Cells(GJOQTYSLITTING.Index).Value)
                        OUTQTY = OUTQTY & "|" & Val(row.Cells(GOUTQTY.Index).Value)
                        If Convert.ToBoolean(row.Cells(GCLOSED.Index).Value) = True Then CLOSED = CLOSED & "|" & "1" Else CLOSED = CLOSED & "|" & "0"
                        FROMNO = FROMNO & "|" & Val(row.Cells(GFROMNO.Index).Value)
                        If Convert.ToBoolean(row.Cells(GREQDONE.Index).Value) = True Then REQDONE = REQDONE & "|" & "1" Else REQDONE = REQDONE & "|" & "0"
                        TYPE = TYPE & "|" & row.Cells(GTYPE.Index).Value.ToString



                    End If
                End If
            Next

            alParaval.Add(gridsrno)
            alParaval.Add(FINISHEDQUALITY)
            alParaval.Add(DESC)
            alParaval.Add(GSM)
            alParaval.Add(GSMDETAILS)
            alParaval.Add(MOTHERSIZE)
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
            alParaval.Add(JOQTYPE)
            alParaval.Add(JOQTYLAMINATION)
            alParaval.Add(JOQTYSLITTING)
            alParaval.Add(OUTQTY)
            alParaval.Add(CLOSED)
            alParaval.Add(FROMNO)
            alParaval.Add(REQDONE)
            alParaval.Add(TYPE)





            Dim objclsPurord As New ClsSaleOrder()
            objclsPurord.alParaval = alParaval

            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim DT As DataTable = objclsPurord.SAVE()
                MessageBox.Show("Details Added")
                If MsgBox("Wish to Job Order Directly?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    JOBORDERSAVE()
                End If
                TXTSONO.Text = DT.Rows(0).Item(0)

            Else


                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPSONO)
                IntResult = objclsPurord.UPDATE()
                MessageBox.Show("Details Updated")
                EDIT = False
            End If

            PRINTREPORT(Val(TXTSONO.Text.Trim))
            CLEAR()
            CMBNAME.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub


    Sub JOBORDERSAVE()
        Try
            For Each ROW As Windows.Forms.DataGridViewRow In GRIDSO.Rows
                Dim OBJCMN As New ClsCommon
                Dim srNoCounter As Integer = 1
                Dim dttable As DataTable = OBJCMN.SEARCH("ISNULL(ITEM_NAME, '') AS ITEMNAME, ISNULL(ITEM_PE, 0) AS PE, ISNULL(ITEM_LAMINATION, 0) AS LAMINATION, ISNULL(ITEM_SLITTING, 0) AS SLITTING", "", " ITEMMASTER ", " AND ITEM_NAME = '" & ROW.Cells(GFINISHEDQUALITY.Index).Value & "' AND ITEM_YEARID =" & YearId)
                If dttable.Rows.Count > 0 Then
                    If Convert.ToBoolean(dttable.Rows(0).Item("PE")) = True Then

                        Dim alParaval As New ArrayList
                        alParaval.Add(0)        'MANUALJONO
                        alParaval.Add(Format(Convert.ToDateTime(SODATE.Text).Date, "MM/dd/yyyy"))
                        alParaval.Add(CMBNAME.Text.Trim)
                        alParaval.Add(CMBPORTDISCHARGE.Text.Trim)
                        alParaval.Add(CMBPORTLOADING.Text.Trim)
                        alParaval.Add(CMBDESTINATION.Text.Trim)
                        alParaval.Add(CMBCIFFOB.Text.Trim)
                        alParaval.Add(CMBCURRENCY.Text.Trim)
                        alParaval.Add(CMBSHIPTO.Text.Trim)
                        alParaval.Add(TXTPROFORMANO.Text.Trim)
                        alParaval.Add(TXTSONO.Text.Trim)
                        alParaval.Add("SALEORDER")
                        alParaval.Add(Format(Convert.ToDateTime(SODATE.Text).Date, "MM/dd/yyyy"))
                        alParaval.Add(CMBBANKDETAILS.Text.Trim)
                        alParaval.Add(TXTSPECIALREMARKS.Text.Trim)
                        alParaval.Add(Val(LBLTOTALQTY.Text.Trim))
                        alParaval.Add(Val(TXTWASTAGEPER.Text.Trim))

                        alParaval.Add(CmpId)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)

                        Dim gridsrno As String = ""
                        Dim FINISHEDQUALITY As String = ""
                        Dim DESC As String = ""
                        Dim GSM As String = ""
                        Dim GSMDETAILS As String = ""
                        Dim MOTHERSIZE As String = ""
                        Dim SIZE As String = ""
                        Dim SIZEDETAILS As String = ""
                        Dim FOILQUALITY As String = ""
                        Dim FOILGSM As String = ""
                        Dim PEGSM As String = ""
                        Dim ROLLDIEAMETER As String = ""
                        Dim COREPIPEWIDTH As String = ""
                        Dim PALLETIZED As String = ""
                        Dim NARRATION As String = ""
                        Dim QTY As String = ""
                        Dim UNIT As String = ""
                        Dim CLOSED As String = ""
                        Dim READYQTY As String = ""
                        Dim FROMNO As String = ""
                        Dim FROMSRNO As String = ""
                        Dim TYPE As String = ""
                        Dim PRODISSDONE As String = ""


                        If gridsrno = "" Then
                            gridsrno = 1
                            ' gridsrno = srNoCounter
                            '  srNoCounter += 1
                            FINISHEDQUALITY = ROW.Cells(GFINISHEDQUALITY.Index).Value.ToString
                            DESC = ROW.Cells(GDESC.Index).Value.ToString
                            GSM = ROW.Cells(GGSM.Index).Value.ToString
                            GSMDETAILS = ROW.Cells(GGSMDETAILS.Index).Value.ToString
                            MOTHERSIZE = ROW.Cells(GMOTHERSIZE.Index).Value.ToString
                            SIZE = ROW.Cells(GSIZE.Index).Value.ToString
                            SIZEDETAILS = ROW.Cells(GSIZEDETAILS.Index).Value.ToString
                            FOILQUALITY = ROW.Cells(GFOILQUALITY.Index).Value.ToString
                            FOILGSM = ROW.Cells(GFOILGSM.Index).Value.ToString
                            PEGSM = ROW.Cells(GPEGSM.Index).Value.ToString
                            ROLLDIEAMETER = ROW.Cells(GROLLDIAMETER.Index).Value.ToString
                            COREPIPEWIDTH = ROW.Cells(GCOREPIPEWIDTH.Index).Value.ToString
                            PALLETIZED = ROW.Cells(GPALLETIZED.Index).Value.ToString
                            NARRATION = ROW.Cells(GNARRATION.Index).Value.ToString
                            QTY = Val(ROW.Cells(GQTY.Index).Value)
                            UNIT = ROW.Cells(GUNIT.Index).Value.ToString
                            If Convert.ToBoolean(ROW.Cells(GCLOSED.Index).Value) = True Then CLOSED = 1 Else CLOSED = 0
                            READYQTY = 0
                            FROMNO = TXTSONO.Text.Trim
                            FROMSRNO = ROW.Cells(GSRNO.Index).Value.ToString
                            TYPE = "SALEORDER"
                            PRODISSDONE = 0
                        End If

                        alParaval.Add(gridsrno)
                        alParaval.Add(FINISHEDQUALITY)
                        alParaval.Add(DESC)
                        alParaval.Add(GSM)
                        alParaval.Add(GSMDETAILS)
                        alParaval.Add(MOTHERSIZE)
                        alParaval.Add(SIZE)
                        alParaval.Add(SIZEDETAILS)
                        alParaval.Add(FOILQUALITY)
                        alParaval.Add(FOILGSM)
                        alParaval.Add(PEGSM)
                        alParaval.Add(ROLLDIEAMETER)
                        alParaval.Add(COREPIPEWIDTH)
                        alParaval.Add(PALLETIZED)
                        alParaval.Add(NARRATION)
                        alParaval.Add(QTY)
                        alParaval.Add(UNIT)
                        alParaval.Add(CLOSED)
                        alParaval.Add(READYQTY)
                        alParaval.Add(FROMNO)
                        alParaval.Add(FROMSRNO)
                        alParaval.Add(TYPE)
                        alParaval.Add(PRODISSDONE)

                        Dim objclsPurord As New ClsJobOrderForPE()
                        objclsPurord.alParaval = alParaval

                        Dim DT As DataTable = objclsPurord.SAVE()

                    End If


                    'FOR LAMINOATION
                    If Convert.ToBoolean(dttable.Rows(0).Item("LAMINATION")) = True Then
                        Dim alParaval As New ArrayList
                        alParaval.Add(0)        'MANUALJONO

                        alParaval.Add(Format(Convert.ToDateTime(SODATE.Text).Date, "MM/dd/yyyy"))
                        alParaval.Add(CMBNAME.Text.Trim)
                        alParaval.Add(CMBPORTDISCHARGE.Text.Trim)
                        alParaval.Add(CMBPORTLOADING.Text.Trim)
                        alParaval.Add(CMBDESTINATION.Text.Trim)
                        alParaval.Add(CMBCIFFOB.Text.Trim)
                        alParaval.Add(CMBCURRENCY.Text.Trim)
                        alParaval.Add(CMBSHIPTO.Text.Trim)
                        alParaval.Add(TXTPROFORMANO.Text.Trim)
                        alParaval.Add(TXTSONO.Text.Trim)
                        alParaval.Add("SALEORDER")
                        alParaval.Add(Format(Convert.ToDateTime(SODATE.Text).Date, "MM/dd/yyyy"))
                        alParaval.Add(CMBBANKDETAILS.Text.Trim)
                        alParaval.Add(TXTSPECIALREMARKS.Text.Trim)
                        alParaval.Add(Val(LBLTOTALQTY.Text.Trim))
                        alParaval.Add(Val(TXTWASTAGEPER.Text.Trim))


                        alParaval.Add(CmpId)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)

                        Dim gridsrno As String = ""
                        Dim FINISHEDQUALITY As String = ""
                        Dim DESC As String = ""
                        Dim GSM As String = ""
                        Dim GSMDETAILS As String = ""
                        Dim MOTHERSIZE As String = ""
                        Dim SIZE As String = ""
                        Dim SIZEDETAILS As String = ""
                        Dim FOILQUALITY As String = ""
                        Dim FOILGSM As String = ""
                        Dim PEGSM As String = ""
                        Dim ROLLDIEAMETER As String = ""
                        Dim COREPIPEWIDTH As String = ""
                        Dim PALLETIZED As String = ""
                        Dim NARRATION As String = ""
                        Dim QTY As String = ""
                        Dim UNIT As String = ""
                        Dim CLOSED As String = ""
                        Dim READYQTY As String = ""
                        Dim FROMNO As String = ""
                        Dim FROMSRNO As String = ""
                        Dim TYPE As String = ""
                        Dim PRODISSDONE As String = ""

                        If gridsrno = "" Then
                            gridsrno = 1
                            ' gridsrno = Val(ROW.Cells(GSRNO.Index).Value)
                            ' gridsrno = srNoCounter
                            ' srNoCounter += 1
                            FINISHEDQUALITY = ROW.Cells(GFINISHEDQUALITY.Index).Value.ToString
                            DESC = ROW.Cells(GDESC.Index).Value.ToString
                            GSM = ROW.Cells(GGSM.Index).Value.ToString
                            GSMDETAILS = ROW.Cells(GGSMDETAILS.Index).Value.ToString
                            MOTHERSIZE = ROW.Cells(GMOTHERSIZE.Index).Value.ToString
                            SIZE = ROW.Cells(GSIZE.Index).Value.ToString
                            SIZEDETAILS = ROW.Cells(GSIZEDETAILS.Index).Value.ToString
                            FOILQUALITY = ROW.Cells(GFOILQUALITY.Index).Value.ToString
                            FOILGSM = ROW.Cells(GFOILGSM.Index).Value.ToString
                            PEGSM = ROW.Cells(GPEGSM.Index).Value.ToString
                            ROLLDIEAMETER = ROW.Cells(GROLLDIAMETER.Index).Value.ToString
                            COREPIPEWIDTH = ROW.Cells(GCOREPIPEWIDTH.Index).Value.ToString
                            PALLETIZED = ROW.Cells(GPALLETIZED.Index).Value.ToString
                            NARRATION = ROW.Cells(GNARRATION.Index).Value.ToString
                            QTY = Val(ROW.Cells(GQTY.Index).Value)
                            UNIT = ROW.Cells(GUNIT.Index).Value.ToString
                            If Convert.ToBoolean(ROW.Cells(GCLOSED.Index).Value) = True Then CLOSED = 1 Else CLOSED = 0
                            READYQTY = 0
                            FROMNO = TXTSONO.Text.Trim
                            FROMSRNO = ROW.Cells(GSRNO.Index).Value.ToString
                            TYPE = "SALEORDER"
                            PRODISSDONE = 0

                        End If

                        alParaval.Add(gridsrno)
                        alParaval.Add(FINISHEDQUALITY)
                        alParaval.Add(DESC)
                        alParaval.Add(GSM)
                        alParaval.Add(GSMDETAILS)
                        alParaval.Add(MOTHERSIZE)
                        alParaval.Add(SIZE)
                        alParaval.Add(SIZEDETAILS)
                        alParaval.Add(FOILQUALITY)
                        alParaval.Add(FOILGSM)
                        alParaval.Add(PEGSM)
                        alParaval.Add(ROLLDIEAMETER)
                        alParaval.Add(COREPIPEWIDTH)
                        alParaval.Add(PALLETIZED)
                        alParaval.Add(NARRATION)
                        alParaval.Add(QTY)
                        alParaval.Add(UNIT)
                        alParaval.Add(CLOSED)
                        alParaval.Add(READYQTY)
                        alParaval.Add(FROMNO)
                        alParaval.Add(FROMSRNO)
                        alParaval.Add(TYPE)
                        alParaval.Add(PRODISSDONE)

                        Dim objclsPurord As New ClsJobOrderForLamination()
                        objclsPurord.alParaval = alParaval
                        Dim DT As DataTable = objclsPurord.SAVE()

                    End If


                    'FOR SLITTING
                    If Convert.ToBoolean(dttable.Rows(0).Item("SLITTING")) = True Then
                        Dim alParaval As New ArrayList
                        alParaval.Add(0)        'MANUALJONO

                        alParaval.Add(Format(Convert.ToDateTime(SODATE.Text).Date, "MM/dd/yyyy"))
                        alParaval.Add(CMBNAME.Text.Trim)
                        alParaval.Add(CMBPORTDISCHARGE.Text.Trim)
                        alParaval.Add(CMBPORTLOADING.Text.Trim)
                        alParaval.Add(CMBDESTINATION.Text.Trim)
                        alParaval.Add(CMBCIFFOB.Text.Trim)
                        alParaval.Add(CMBCURRENCY.Text.Trim)
                        alParaval.Add(CMBSHIPTO.Text.Trim)
                        alParaval.Add(TXTPROFORMANO.Text.Trim)
                        alParaval.Add(TXTSONO.Text.Trim)
                        alParaval.Add("SALEORDER")
                        alParaval.Add(Format(Convert.ToDateTime(SODATE.Text).Date, "MM/dd/yyyy"))
                        alParaval.Add(CMBBANKDETAILS.Text.Trim)
                        alParaval.Add(TXTSPECIALREMARKS.Text.Trim)
                        alParaval.Add(Val(LBLTOTALQTY.Text.Trim))
                        alParaval.Add(Val(TXTWASTAGEPER.Text.Trim))


                        alParaval.Add(CmpId)
                        alParaval.Add(Userid)
                        alParaval.Add(YearId)

                        Dim gridsrno As String = ""
                        Dim FINISHEDQUALITY As String = ""
                        Dim DESC As String = ""
                        Dim GSM As String = ""
                        Dim GSMDETAILS As String = ""
                        Dim MOTHERSIZE As String = ""
                        Dim SIZE As String = ""
                        Dim SIZEDETAILS As String = ""
                        Dim FOILQUALITY As String = ""
                        Dim FOILGSM As String = ""
                        Dim PEGSM As String = ""
                        Dim ROLLDIEAMETER As String = ""
                        Dim COREPIPEWIDTH As String = ""
                        Dim PALLETIZED As String = ""
                        Dim NARRATION As String = ""
                        Dim QTY As String = ""
                        Dim UNIT As String = ""
                        Dim CLOSED As String = ""
                        Dim READYQTY As String = ""
                        Dim FROMNO As String = ""
                        Dim FROMSRNO As String = ""
                        Dim TYPE As String = ""
                        Dim PRODISSDONE As String = ""


                        If gridsrno = "" Then
                            gridsrno = 1
                            ' gridsrno = Val(ROW.Cells(GSRNO.Index).Value)
                            'gridsrno = srNoCounter
                            'srNoCounter += 1
                            FINISHEDQUALITY = ROW.Cells(GFINISHEDQUALITY.Index).Value.ToString
                            DESC = ROW.Cells(GDESC.Index).Value.ToString
                            GSM = ROW.Cells(GGSM.Index).Value.ToString
                            GSMDETAILS = ROW.Cells(GGSMDETAILS.Index).Value.ToString
                            MOTHERSIZE = ROW.Cells(GMOTHERSIZE.Index).Value.ToString
                            SIZE = ROW.Cells(GSIZE.Index).Value.ToString
                            SIZEDETAILS = ROW.Cells(GSIZEDETAILS.Index).Value.ToString
                            FOILQUALITY = ROW.Cells(GFOILQUALITY.Index).Value.ToString
                            FOILGSM = ROW.Cells(GFOILGSM.Index).Value.ToString
                            PEGSM = ROW.Cells(GPEGSM.Index).Value.ToString
                            ROLLDIEAMETER = ROW.Cells(GROLLDIAMETER.Index).Value.ToString
                            COREPIPEWIDTH = ROW.Cells(GCOREPIPEWIDTH.Index).Value.ToString
                            PALLETIZED = ROW.Cells(GPALLETIZED.Index).Value.ToString
                            NARRATION = ROW.Cells(GNARRATION.Index).Value.ToString
                            QTY = Val(ROW.Cells(GQTY.Index).Value)
                            UNIT = ROW.Cells(GUNIT.Index).Value.ToString
                            If Convert.ToBoolean(ROW.Cells(GCLOSED.Index).Value) = True Then CLOSED = 1 Else CLOSED = 0
                            READYQTY = 0
                            FROMNO = TXTSONO.Text.Trim
                            FROMSRNO = ROW.Cells(GSRNO.Index).Value.ToString
                            TYPE = "SALEORDER"
                            PRODISSDONE = 0
                        End If

                        alParaval.Add(gridsrno)
                        alParaval.Add(FINISHEDQUALITY)
                        alParaval.Add(DESC)
                        alParaval.Add(GSM)
                        alParaval.Add(GSMDETAILS)
                        alParaval.Add(MOTHERSIZE)
                        alParaval.Add(SIZE)
                        alParaval.Add(SIZEDETAILS)
                        alParaval.Add(FOILQUALITY)
                        alParaval.Add(FOILGSM)
                        alParaval.Add(PEGSM)
                        alParaval.Add(ROLLDIEAMETER)
                        alParaval.Add(COREPIPEWIDTH)
                        alParaval.Add(PALLETIZED)
                        alParaval.Add(NARRATION)
                        alParaval.Add(QTY)
                        alParaval.Add(UNIT)
                        alParaval.Add(CLOSED)
                        alParaval.Add(READYQTY)
                        alParaval.Add(FROMNO)
                        alParaval.Add(FROMSRNO)
                        alParaval.Add(TYPE)
                        alParaval.Add(PRODISSDONE)

                        Dim objclsPurord As New ClsJobOrderForSlitting()
                        objclsPurord.alParaval = alParaval
                        Dim DT As DataTable = objclsPurord.SAVE()
                    End If


                End If
            Next

            MsgBox("Job Order Save Successfully!")



        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PRINTREPORT(ByVal SALEORDERNO As Integer)
        Try
            If MsgBox("Wish to Print Sale Order?", MsgBoxStyle.YesNo) = vbNo Then Exit Sub
            Dim OBJPROFORMA As New SaleInvoiceDesign
            OBJPROFORMA.FRMSTRING = "SALEORDER"
            OBJPROFORMA.INVNO = SALEORDERNO
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

        If CMBDESTINATION.Text.Trim.Length = 0 Then
            EP.SetError(CMBDESTINATION, " Please Destination Name ")
            bln = False
        End If

        If LBLLOCKED.Visible = True Or LBLCLOSED.Visible = True Then
            EP.SetError(LBLLOCKED, " Entry Locked, Unable to Modify")
            bln = False
        End If

        If CMBCURRENCY.Text.Trim.Length = 0 Then
            EP.SetError(CMBCURRENCY, " Please Fill Currency Details ")
            bln = False
        End If

        If CMBSHIPTO.Text.Trim.Length = 0 Then
            EP.SetError(CMBSHIPTO, " Please Fill Party Name ")
            bln = False
        End If

        If SODATE.Text = "__/__/____" Then
            EP.SetError(SODATE, " Please Enter Proper Date")
            bln = False
        Else
            If Not datecheck(SODATE.Text) Then
                EP.SetError(SODATE, "Date not in Accounting Year")
                bln = False
            End If
        End If

        If GRIDSO.RowCount = 0 Then
            EP.SetError(CMBNAME, " Please Enter Item Details ")
            bln = False
        End If



        Return bln
    End Function

    Private Sub CMDDELETE_Click(sender As Object, e As EventArgs) Handles CMDDELETE.Click
        Try

            If EDIT = True Then
                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                If LBLLOCKED.Visible = True Then
                    MsgBox("Unable To Delete, Order Is Locked ", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                If MsgBox("Delete Sale Order?", MsgBoxStyle.YesNo) = vbYes Then
                    Dim alParaval As New ArrayList
                    alParaval.Add(TXTSONO.Text.Trim)
                    alParaval.Add(YearId)

                    Dim OBJSO As New ClsSaleOrder()
                    OBJSO.alParaval = alParaval
                    Dim IntResult As Integer = OBJSO.DELETE()
                    MsgBox("Sale Order Deleted")
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
            GRIDSO.RowCount = 0
LINE1:
            TEMPSONO = Val(TXTSONO.Text) - 1
            If TEMPSONO > 0 Then
                EDIT = True
                SaleOrder_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If

            If GRIDSO.RowCount = 0 And TEMPSONO > 1 Then
                TXTSONO.Text = TEMPSONO
                GoTo LINE1
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
    Private Sub toolnext_Click(sender As Object, e As EventArgs) Handles toolnext.Click
        Try
            GRIDSO.RowCount = 0
LINE1:
            TEMPSONO = Val(TXTSONO.Text) + 1
            getmax_SO_NO()
            Dim MAXNO As Integer = TXTSONO.Text.Trim
            CLEAR()
            If Val(TXTSONO.Text) - 1 >= TEMPSONO Then
                EDIT = True
                SaleOrder_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
            If GRIDSO.RowCount = 0 And TEMPSONO < MAXNO Then
                TXTSONO.Text = TEMPSONO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub Fillgrid()
        Try
            If GRIDDOUBLECLICK = False Then
                GRIDSO.Rows.Add(Val(TXTSRNO.Text.Trim), CMBFINISHED.Text.Trim, TXTDESC.Text.Trim, TXTGSM.Text.Trim, TXTGSMDETAILS.Text.Trim, TXTMOTHERSIZE.Text.Trim, TXTSIZE.Text.Trim, TXTSIZEDETAILS.Text.Trim, CMBFOIL.Text.Trim, TXTFOILGSM.Text.Trim, TXTPEGSM.Text.Trim, TXTROLLDIAMETER.Text.Trim, TXTCOREPIPEWIDTH.Text.Trim, CMBPALLETIZED.Text.Trim, TXTNARRATION.Text.Trim, Format(Val(TXTQTY.Text.Trim), "0.00"), CMBUNIT.Text.Trim, Format(Val(TXTRATE.Text.Trim), "0.00"), Format(Val(TXTAMOUNT.Text.Trim), "0.00"), 0, 0, 0, 0, 0, 0, 0, "SALEORDER")
                getsrno(GRIDSO)
            ElseIf GRIDDOUBLECLICK = True Then
                GRIDSO.Item(GSRNO.Index, TEMPROW).Value = Val(TXTSRNO.Text.Trim)
                GRIDSO.Item(GFINISHEDQUALITY.Index, TEMPROW).Value = CMBFINISHED.Text.Trim
                GRIDSO.Item(GDESC.Index, TEMPROW).Value = TXTDESC.Text.Trim
                GRIDSO.Item(GGSM.Index, TEMPROW).Value = (TXTGSM.Text.Trim)
                GRIDSO.Item(GGSMDETAILS.Index, TEMPROW).Value = TXTGSMDETAILS.Text.Trim
                GRIDSO.Item(GMOTHERSIZE.Index, TEMPROW).Value = (TXTMOTHERSIZE.Text.Trim)
                GRIDSO.Item(GSIZE.Index, TEMPROW).Value = (TXTSIZE.Text.Trim)
                GRIDSO.Item(GSIZEDETAILS.Index, TEMPROW).Value = TXTSIZEDETAILS.Text.Trim
                GRIDSO.Item(GFOILQUALITY.Index, TEMPROW).Value = (CMBFOIL.Text.Trim)
                GRIDSO.Item(GFOILGSM.Index, TEMPROW).Value = (TXTFOILGSM.Text.Trim)
                GRIDSO.Item(GPEGSM.Index, TEMPROW).Value = (TXTPEGSM.Text.Trim)
                GRIDSO.Item(GROLLDIAMETER.Index, TEMPROW).Value = (TXTROLLDIAMETER.Text.Trim)
                GRIDSO.Item(GCOREPIPEWIDTH.Index, TEMPROW).Value = (TXTCOREPIPEWIDTH.Text.Trim)
                GRIDSO.Item(GPALLETIZED.Index, TEMPROW).Value = CMBPALLETIZED.Text.Trim
                GRIDSO.Item(GNARRATION.Index, TEMPROW).Value = (TXTNARRATION.Text.Trim)
                GRIDSO.Item(GQTY.Index, TEMPROW).Value = Format(Val(TXTQTY.Text.Trim), "0.00")
                GRIDSO.Item(GUNIT.Index, TEMPROW).Value = (CMBUNIT.Text.Trim)
                GRIDSO.Item(GRATE.Index, TEMPROW).Value = Format(Val(TXTRATE.Text.Trim), "0.00")
                GRIDSO.Item(GAMOUNT.Index, TEMPROW).Value = Format(Val(TXTAMOUNT.Text.Trim), "0.00")



                GRIDDOUBLECLICK = False

            End If

            TOTAL()
            GRIDSO.FirstDisplayedScrollingRowIndex = GRIDSO.RowCount - 1

            TXTSRNO.Text = GRIDSO.RowCount + 1
            CMBFINISHED.Text = ""
            TXTDESC.Clear()
            TXTGSM.Clear()
            TXTGSMDETAILS.Clear()
            TXTSIZE.Clear()
            TXTSIZEDETAILS.Clear()
            CMBFOIL.Text = ""
            TXTFOILGSM.Clear()
            TXTPEGSM.Clear()
            TXTGSMDETAILS.Clear()
            'TXTROLLDIAMETER.Clear()
            ' TXTCOREPIPEWIDTH.Clear()
            CMBPALLETIZED.Text = ""
            TXTNARRATION.Clear()
            TXTQTY.Clear()
            CMBUNIT.Text = ""
            TXTRATE.Clear()
            TXTAMOUNT.Clear()
            TXTMOTHERSIZE.Clear()


            CMBFINISHED.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OpenToolStripButton_Click(sender As Object, e As EventArgs) Handles OpenToolStripButton.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim objINVDTLS As New SaleOrderDetails
            objINVDTLS.MdiParent = MDIMain
            objINVDTLS.Show()
            objINVDTLS.BringToFront()
            ' Me.Close()
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

    Private Sub tstxtbillno_Validating(sender As Object, e As CancelEventArgs) Handles TSTXTBILLNO.Validating
        Try
            If Val(TSTXTBILLNO.Text.Trim) > 0 Then
                GRIDSO.RowCount = 0
                TEMPSONO = Val(TSTXTBILLNO.Text)
                If TEMPSONO > 0 Then
                    EDIT = True
                    SaleOrder_Load(sender, e)
                Else
                    CLEAR()
                    EDIT = False
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub EDITROW()
        Try

            If GRIDSO.CurrentRow.Index >= 0 And GRIDSO.Item(GSRNO.Index, GRIDSO.CurrentRow.Index).Value <> Nothing Then
                If Convert.ToBoolean(GRIDSO.Rows(GRIDSO.CurrentRow.Index).Cells(GCLOSED.Index).Value) = True Then
                    MsgBox("Item Locked. First Delete from Job Order")
                    Exit Sub
                End If

                'CMBFINISHED.Enabled = False
                'CMBFOIL.Enabled = False
                'CMBUNIT.Enabled = False
                GRIDDOUBLECLICK = True
                TXTSRNO.Text = GRIDSO.Item(GSRNO.Index, GRIDSO.CurrentRow.Index).Value.ToString
                CMBFINISHED.Text = GRIDSO.Item(GFINISHEDQUALITY.Index, GRIDSO.CurrentRow.Index).Value.ToString
                TXTDESC.Text = GRIDSO.Item(GDESC.Index, GRIDSO.CurrentRow.Index).Value.ToString
                TXTGSM.Text = GRIDSO.Item(GGSM.Index, GRIDSO.CurrentRow.Index).Value.ToString
                TXTGSMDETAILS.Text = GRIDSO.Item(GGSMDETAILS.Index, GRIDSO.CurrentRow.Index).Value.ToString
                TXTMOTHERSIZE.Text = GRIDSO.Item(GMOTHERSIZE.Index, GRIDSO.CurrentRow.Index).Value.ToString
                TXTSIZE.Text = GRIDSO.Item(GSIZE.Index, GRIDSO.CurrentRow.Index).Value.ToString
                TXTSIZEDETAILS.Text = GRIDSO.Item(GSIZEDETAILS.Index, GRIDSO.CurrentRow.Index).Value.ToString
                CMBFOIL.Text = GRIDSO.Item(GFOILQUALITY.Index, GRIDSO.CurrentRow.Index).Value.ToString
                TXTFOILGSM.Text = GRIDSO.Item(GFOILGSM.Index, GRIDSO.CurrentRow.Index).Value.ToString
                TXTPEGSM.Text = GRIDSO.Item(GPEGSM.Index, GRIDSO.CurrentRow.Index).Value.ToString
                TXTROLLDIAMETER.Text = GRIDSO.Item(GROLLDIAMETER.Index, GRIDSO.CurrentRow.Index).Value.ToString
                TXTCOREPIPEWIDTH.Text = GRIDSO.Item(GCOREPIPEWIDTH.Index, GRIDSO.CurrentRow.Index).Value.ToString
                CMBPALLETIZED.Text = GRIDSO.Item(GPALLETIZED.Index, GRIDSO.CurrentRow.Index).Value.ToString
                TXTNARRATION.Text = GRIDSO.Item(GNARRATION.Index, GRIDSO.CurrentRow.Index).Value.ToString
                TXTQTY.Text = GRIDSO.Item(GQTY.Index, GRIDSO.CurrentRow.Index).Value.ToString
                CMBUNIT.Text = GRIDSO.Item(GUNIT.Index, GRIDSO.CurrentRow.Index).Value.ToString
                TXTRATE.Text = GRIDSO.Item(GRATE.Index, GRIDSO.CurrentRow.Index).Value.ToString
                TXTAMOUNT.Text = GRIDSO.Item(GAMOUNT.Index, GRIDSO.CurrentRow.Index).Value.ToString

                TEMPROW = GRIDSO.CurrentRow.Index
                CMBFINISHED.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDSALEORDER_KeyDown(sender As Object, e As KeyEventArgs) Handles GRIDSO.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDSO.RowCount > 0 Then
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                GRIDSO.Rows.RemoveAt(GRIDSO.CurrentRow.Index)
                TOTAL()
                getsrno(GRIDSO)
            ElseIf e.KeyCode = Keys.F5 Then
                EDITROW()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub




    Private Sub DTDATE_GotFocus(sender As Object, e As EventArgs) Handles SODATE.GotFocus
        SODATE.SelectionStart = 0
    End Sub

    Private Sub GRIDSALEORDER_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRIDSO.CellDoubleClick
        Try
            EDITROW()
        Catch ex As Exception
            Throw ex
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

    Private Sub CMBDESTINATION_Validating(sender As Object, e As CancelEventArgs) Handles CMBDESTINATION.Validating
        Try
            If CMBDESTINATION.Text.Trim = "" Then fillCOUNTRY(CMBDESTINATION)
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

    Private Sub txtamount_Validating(sender As Object, e As CancelEventArgs) Handles TXTAMOUNT.Validating
        Try
            If CMBFINISHED.Text.Trim <> "" Then
                Fillgrid()
                TOTAL()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub



    Private Sub cmbportdischarge_Enter(sender As Object, e As EventArgs) Handles CMBPORTDISCHARGE.Enter
        Try
            If CMBPORTDISCHARGE.Text.Trim <> "" Then FILLPORT(CMBPORTDISCHARGE)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBPORTLOADING_Enter(sender As Object, e As EventArgs) Handles CMBPORTLOADING.Enter
        Try
            If CMBPORTLOADING.Text.Trim <> "" Then FILLPORT(CMBPORTLOADING)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Call cmddelete_Click(sender, e)
    End Sub

    Private Sub CMBFINISHED_Enter(sender As Object, e As EventArgs) Handles CMBFINISHED.Enter
        Try
            If CMBFINISHED.Text = "" Then FILLITEMNAME(CMBFINISHED, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBFINISHED_Validating(sender As Object, e As CancelEventArgs) Handles CMBFINISHED.Validating
        Try
            If CMBFINISHED.Text.Trim <> "" Then ITEMVALIDATE(CMBFINISHED, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'", "MERCHANT")
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

    Private Sub CMDSELECTPROFORMA_Click(sender As Object, e As EventArgs) Handles CMDSELECTPROFORMA.Click
        Try
            EP.Clear()
            If CMBNAME.Text.Trim = "" Then
                MsgBox("Please Fill Party Name", MsgBoxStyle.Critical)
                CMBNAME.Focus()
                Exit Sub
            End If


            Dim OBJSO As New SelectProformaForPO
            OBJSO.FRMSTRING = "SO"
            OBJSO.PARTYNAME = CMBNAME.Text.Trim
            OBJSO.ShowDialog()
            Dim DT As DataTable = OBJSO.DT
            If DT.Rows.Count > 0 Then

                'FETCH DATA FROM SALEORDER_DESC WITH RESPECT TO SELECTED SONO
                TXTPROFORMANO.Text = Val(DT.Rows(0).Item("PROFORMANO"))
                TXTPROFORMATYPE.Text = DT.Rows(0).Item("TYPE")
                PROFORMADATE.Text = DT.Rows(0).Item("DATE")
                TXTORDERREFNO.Text = DT.Rows(0).Item("ORDERREFNO")
                TXTPAYMENTTERM.Text = DT.Rows(0).Item("PAYMENTTERMS")
                TXTREMARKS.Text = DT.Rows(0).Item("REMARKS")
                CMBSHIPTO.Text = DT.Rows(0).Item("SHIPTO")
                CMBDESTINATION.Text = DT.Rows(0).Item("DESTINATION")
                CMBPORTDISCHARGE.Text = DT.Rows(0).Item("PORTDISCHARGE")
                CMBPORTLOADING.Text = DT.Rows(0).Item("PORTLOADING")
                CMBCURRENCY.Text = DT.Rows(0).Item("CURRENCY")
                CMBCIFFOB.Text = DT.Rows(0).Item("CIFFOB")
                CMBBANKDETAILS.Text = DT.Rows(0).Item("BANKDETAILS")
                'LBLTOTALQTY.Text = DT.Rows(0).Item("TOTALQTY")
                'LBLTOTALAMOUNT.Text = DT.Rows(0).Item("TOTALAMOUNT")


                Dim OBJCMN As New ClsCommon
                Dim DTSO As DataTable = OBJCMN.SEARCH(" ISNULL(ALLPROFORMAINVOICEMASTER_DESC.INVOICE_TYPE, '') AS TYPE, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT, ISNULL(ALLPROFORMAINVOICEMASTER_DESC.INVOICE_DESC, '') AS GRIDDESC, ISNULL(ALLPROFORMAINVOICEMASTER_DESC.INVOICE_GSM, 0) AS GSM, ISNULL(ALLPROFORMAINVOICEMASTER_DESC.INVOICE_GSMDETAILS,'') AS GSMDETAILS, ISNULL(ALLPROFORMAINVOICEMASTER_DESC.INVOICE_SIZE, 0) AS SIZE,  ISNULL(ALLPROFORMAINVOICEMASTER_DESC.INVOICE_SIZEDETAILS,'') AS SIZEDETAILS, ISNULL(ITEMMASTER.ITEM_MICRON * ITEMMASTER.ITEM_CALCULATEON, 0)  AS FOILGSM, ISNULL(ALLPROFORMAINVOICEMASTER_DESC.INVOICE_PEGSM, 0) AS PEGSM, ISNULL(ALLPROFORMAINVOICEMASTER_DESC.INVOICE_ROLLDIAMETER, '') AS ROLLDIAMETER,  ISNULL(ALLPROFORMAINVOICEMASTER_DESC.INVOICE_COREPIPEWIDTH, '') AS COREPIPEWIDTH, ISNULL(ALLPROFORMAINVOICEMASTER_DESC.INVOICE_PALLETIZED, '') AS PALLETIZED,  ISNULL(ALLPROFORMAINVOICEMASTER_DESC.INVOICE_NARRATION, '') AS NARRATION, ISNULL(ALLPROFORMAINVOICEMASTER_DESC.INVOICE_QTY, 0) AS QTY,  ISNULL(ALLPROFORMAINVOICEMASTER_DESC.INVOICE_RATE, 0) AS RATE, ISNULL(ALLPROFORMAINVOICEMASTER_DESC.INVOICE_AMOUNT, 0) AS AMOUNT, ISNULL(ITEMMASTER.ITEM_NAME, '') AS FINISHEDQUALITY,  ISNULL(FOILQUALITYITEMMASTER.ITEM_NAME, '') AS FOILQUALITY", "", " UNITMASTER RIGHT OUTER JOIN ITEMMASTER AS FOILQUALITYITEMMASTER RIGHT OUTER JOIN ALLPROFORMAINVOICEMASTER_DESC ON FOILQUALITYITEMMASTER.item_id = ALLPROFORMAINVOICEMASTER_DESC.INVOICE_FOILQUALITYID LEFT OUTER JOIN ITEMMASTER ON ALLPROFORMAINVOICEMASTER_DESC.INVOICE_FINISHEDQUALITYID = ITEMMASTER.item_id ON UNITMASTER.unit_id = ALLPROFORMAINVOICEMASTER_DESC.INVOICE_UNITID ", " AND ALLPROFORMAINVOICEMASTER_DESC.INVOICE_NO = " & Val(TXTPROFORMANO.Text.Trim) & " AND ALLPROFORMAINVOICEMASTER_DESC.INVOICE_YEARID = " & YearId)
                If DTSO.Rows.Count > 0 Then
                    For Each DTROW As DataRow In DTSO.Rows
                        GRIDSO.Rows.Add(0, DTROW("FINISHEDQUALITY").ToString, DTROW("GRIDDESC").ToString, DTROW("GSM").ToString, DTROW("GSMDETAILS").ToString, 0, DTROW("SIZE"), DTROW("SIZEDETAILS").ToString, DTROW("FOILQUALITY").ToString, DTROW("FOILGSM").ToString, DTROW("PEGSM").ToString, DTROW("ROLLDIAMETER").ToString, DTROW("COREPIPEWIDTH").ToString, DTROW("PALLETIZED").ToString, DTROW("NARRATION").ToString, Format(DTROW("QTY"), "0.00"), DTROW("UNIT").ToString, Format(DTROW("RATE"), "0.00"), Format(DTROW("AMOUNT"), "0.00"), 0, 0, 0, 0, 0, 0, 0, "SALEORDER")
                    Next
                End If

                getsrno(GRIDSO)
            End If

        Catch ex As Exception
            Throw ex
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

    Private Sub CMBFINISHED_Validated(sender As Object, e As EventArgs) Handles CMBFINISHED.Validated
        Try
            If CMBFINISHED.Text <> "" And CMBNAME.Text <> "" Then
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

            For Each ROW As DataGridViewRow In GRIDSO.Rows
                If ROW.Cells(GSRNO.Index).Value <> Nothing Then
                    LBLTOTALQTY.Text = Format(Val(LBLTOTALQTY.Text) + Val(ROW.Cells(GQTY.Index).EditedFormattedValue), "0.00")
                    LBLTOTALAMOUNT.Text = Format(Val(LBLTOTALAMOUNT.Text) + Val(ROW.Cells(GAMOUNT.Index).EditedFormattedValue), "0.00")
                End If
            Next

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

    Private Sub CMBSHIPTO_Enter(sender As Object, e As EventArgs) Handles CMBSHIPTO.Enter
        Try
            If CMBSHIPTO.Text.Trim = "" Then fillname(CMBSHIPTO, EDIT, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS'")
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
    Private Sub TXTQTY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTQTY.KeyPress, TXTWASTAGEPER.KeyPress, TXTMOTHERSIZE.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub TXTREMARKS_KeyDown(sender As Object, e As KeyEventArgs)
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJREMARKS As New SelectRemarks
                OBJREMARKS.FRMSTRING = "NARRATION"
                OBJREMARKS.ShowDialog()
                If OBJREMARKS.TEMPNAME <> "" Then txtremarks.Text = OBJREMARKS.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTGSM_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTGSM.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub PrintToolStripButton_Click(sender As Object, e As EventArgs) Handles PrintToolStripButton.Click
        Try
            If EDIT = True Then PRINTREPORT(TEMPSONO)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TOOLWHATSAPPCLICK_Click(sender As Object, e As EventArgs) Handles TOOLWHATSAPPCLICK.Click
        'Try
        '    Dim DT As New DataTable
        '    Dim OBJCMN As New ClsCommon
        '    If EDIT = True Then SENDWHATSAPP(TEMPSONO)
        '    ' DT = OBJCMN.Execute_Any_String("UPDATE SALEORDER SET SO_SENDWHATSAPP = 1 WHERE SO_NO = " & TEMPPORFORMA & " AND SO_YEARID = " & YearId, "", "")
        '    LBLWHATSAPP.Visible = True
        'Catch ex As Exception
        '    Throw ex
        'End Try
    End Sub

    Async Sub SENDWHATSAPP(INVNO As Integer)
        'Try
        '    If ALLOWWHATSAPP = False Then Exit Sub
        '    If Not CHECKWHASTAPPEXP() Then
        '        MsgBox("Whatsapp Package has Expired, Kindly contact Nakoda Infotech on 02249724411", MsgBoxStyle.Critical)
        '        Exit Sub
        '    End If

        '    If MsgBox("Send Whatsapp?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

        '    Dim WHATSAPPNO As String = ""
        '    Dim OBJSO As New SaleInvoiceDesign
        '    OBJSO.MdiParent = MDIMain
        '    OBJSO.DIRECTPRINT = True
        '    OBJSO.FRMSTRING = "PROFORMA"
        '    OBJSO.DIRECTMAIL = True
        '    OBJSO.vendorname = CMBNAME.Text.Trim
        '    OBJSO.FORMULA = "{PROFORMAINVOICEMASTER.INVOICE_NO}=" & Val(INVNO) & " and {PROFORMAINVOICEMASTER.INVOICE_YEARID}=" & YearId
        '    OBJSO.INVNO = INVNO
        '    OBJSO.NOOFCOPIES = 1
        '    OBJSO.Show()
        '    OBJSO.Close()

        '    Dim OBJWHATSAPP As New SendWhatsapp
        '    OBJWHATSAPP.PARTYNAME = CMBNAME.Text.Trim
        '    'OBJWHATSAPP.AGENTNAME = CMBAGENT.Text.Trim
        '    'If CMBNAME.Text.Trim <> CMBPACKING.Text.Trim Then OBJWHATSAPP.OTHERNAME1 = CMBPACKING.Text.Trim
        '    OBJWHATSAPP.PATH.Add(Application.StartupPath & "\PIREPORT_" & Val(INVNO) & ".pdf")
        '    OBJWHATSAPP.FILENAME.Add("PIREPORT_" & Val(INVNO) & ".pdf")
        '    OBJWHATSAPP.ShowDialog()

        'Catch ex As Exception
        '    Throw ex
        'End Try
    End Sub


    Private Sub TXTSIZE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTSIZE.KeyPress
        numkeypress(e, sender, Me)
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

                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTFOILGSM_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTFOILGSM.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub TXTPEGSM_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTPEGSM.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub TXTFREIGHT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTFREIGHT.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub TXTINSURANCE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTINSURANCE.KeyPress
        numkeypress(e, sender, Me)
    End Sub
End Class