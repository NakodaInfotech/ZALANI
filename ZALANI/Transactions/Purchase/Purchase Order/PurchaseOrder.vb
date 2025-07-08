Imports System.ComponentModel
Imports BL

Public Class PurchaseOrder

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE, GRIDDOUBLECLICK As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public EDIT As Boolean          'used for editing
    Public TEMPPONO As String
    Dim TEMPROW As Integer

    Private Sub cmdok_Click(sender As Object, e As EventArgs) Handles CMDOK.Click
        Try
            EP.Clear()
            If Not ERRORVALID() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList
            alParaval.Add(Val(TXTPONO.Text.Trim))
            alParaval.Add(Format(Convert.ToDateTime(PODATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(CMBNAME.Text.Trim)
            alParaval.Add(TXTDELIVERY.Text.Trim)
            alParaval.Add(TXTORDERREFNO.Text.Trim)
            alParaval.Add(TXTPROFORMANO.Text.Trim)
            alParaval.Add(PROFORMADATE.Text)
            alParaval.Add(TXTPROFORMATYPE.Text)
            alParaval.Add(TXTPACKING.Text.Trim)
            alParaval.Add(TXTQUALITYNOTES.Text.Trim)
            alParaval.Add(TXTDIAMETER.Text.Trim)
            alParaval.Add(TXTPAYMENTTERM.Text.Trim)
            alParaval.Add(TXTBILLINGINFO.Text.Trim)
            alParaval.Add(TXTINSURANCE.Text.Trim)
            alParaval.Add(TXTREMARKS.Text.Trim)
            alParaval.Add(Val(LBLTOTALQTY.Text))
            alParaval.Add(Val(LBLTOTALAMT.Text))
            alParaval.Add(CHKVERIFY.Checked)

            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)

            Dim GRIDSRNO As String = ""
            Dim QUALITY As String = ""
            Dim NARRATION As String = ""
            Dim GSM As String = ""
            Dim SIZE As String = ""
            Dim QTY As String = ""
            Dim UNIT As String = ""
            Dim RATE As String = ""
            Dim AMOUNT As String = ""
            Dim RECDQTY As String = ""      'Qty recd in GRN
            Dim DONE As String = ""      'WHETHER GRN IS DONE FOR THIS LINE
            Dim CLOSED As String = ""
            Dim STOCK As String = ""


            For Each row As Windows.Forms.DataGridViewRow In GRIDPO.Rows
                If row.Cells(0).Value <> Nothing Then
                    If GRIDSRNO = "" Then
                        GRIDSRNO = Val(row.Cells(gsrno.Index).Value)
                        QUALITY = row.Cells(GQUALITY.Index).Value.ToString
                        NARRATION = row.Cells(GNARRATION.Index).Value.ToString
                        GSM = Val(row.Cells(GGSM.Index).Value)
                        SIZE = Val(row.Cells(GSIZE.Index).Value)
                        QTY = Val(row.Cells(GQTY.Index).Value)
                        UNIT = row.Cells(GUNIT.Index).Value.ToString
                        RATE = Val(row.Cells(GRATE.Index).Value)
                        AMOUNT = Val(row.Cells(GAMOUNT.Index).Value)
                        RECDQTY = Val(row.Cells(GRECDQTY.Index).Value)
                        If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then DONE = 1 Else DONE = 0
                        If Convert.ToBoolean(row.Cells(GCLOSED.Index).Value) = True Then CLOSED = 1 Else CLOSED = 0
                        STOCK = Val(row.Cells(GSTOCK.Index).Value)

                    Else

                        GRIDSRNO = GRIDSRNO & "|" & Val(row.Cells(gsrno.Index).Value)
                        QUALITY = QUALITY & "|" & row.Cells(GQUALITY.Index).Value.ToString
                        NARRATION = NARRATION & "|" & row.Cells(GNARRATION.Index).Value.ToString
                        GSM = GSM & "|" & Val(row.Cells(GGSM.Index).Value)
                        SIZE = SIZE & "|" & Val(row.Cells(GSIZE.Index).Value)
                        QTY = QTY & "|" & Val(row.Cells(GQTY.Index).Value)
                        UNIT = UNIT & "|" & row.Cells(GUNIT.Index).Value.ToString
                        RATE = RATE & "|" & Val(row.Cells(GRATE.Index).Value)
                        AMOUNT = AMOUNT & "|" & Val(row.Cells(GAMOUNT.Index).Value)
                        RECDQTY = RECDQTY & "|" & Val(row.Cells(GRECDQTY.Index).Value)
                        If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then DONE = DONE & "|" & "1" Else DONE = DONE & "|" & "0"
                        If Convert.ToBoolean(row.Cells(GCLOSED.Index).Value) = True Then CLOSED = CLOSED & "|" & "1" Else CLOSED = CLOSED & "|" & "0"
                        STOCK = STOCK & "|" & Val(row.Cells(GSTOCK.Index).Value)

                    End If
                End If
            Next

            alParaval.Add(GRIDSRNO)
            alParaval.Add(QUALITY)
            alParaval.Add(NARRATION)
            alParaval.Add(GSM)
            alParaval.Add(SIZE)
            alParaval.Add(QTY)
            alParaval.Add(UNIT)
            alParaval.Add(RATE)
            alParaval.Add(AMOUNT)
            alParaval.Add(RECDQTY)
            alParaval.Add(DONE)
            alParaval.Add(CLOSED)
            alParaval.Add(STOCK)

            alParaval.Add(Val(TXTWASTAGEPER.Text))

            Dim OBJPO As New ClsPurchaseOrder()
            OBJPO.alParaval = alParaval

            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim DT As DataTable = OBJPO.SAVE()
                TXTPONO.Text = Val(DT.Rows(0).Item(0))
                MessageBox.Show("Details Added")
            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPPONO)
                Dim IntResult As Integer = OBJPO.UPDATE()
                MessageBox.Show("Details Updated")
                EDIT = False
            End If
            PRINTREPORT()
            CLEAR()
            CMBNAME.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Function ERRORVALID() As Boolean

        Dim bln As Boolean = True
        If CMBNAME.Text.Trim.Length = 0 Then
            EP.SetError(CMBNAME, " Please Fill Party Name ")
            bln = False
        End If

        If PODATE.Text = "__/__/____" Then
            EP.SetError(PODATE, " Please Enter Proper Date")
            bln = False
        Else
            If Not datecheck(PODATE.Text) Then
                EP.SetError(PODATE, "Date not in Accounting Year")
                bln = False
            End If
        End If

        If lbllocked.Visible = True Or LBLCLOSED.Visible = True Then
            EP.SetError(lbllocked, "Entry Locked")
            bln = False
        End If

        If GRIDPO.RowCount = 0 Then
            EP.SetError(GRIDPO, " Please Enter Proper Details ")
            bln = False
        End If



        Return bln
    End Function

    Private Sub PurchaseOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow

            DTROW = USERRIGHTS.Select("FormName = 'PURCHASE ORDER'")

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
                Dim OBJPO As New ClsPurchaseOrder
                Dim DTTABLE As DataTable = OBJPO.SELECTPO(TEMPPONO, YearId)
                If DTTABLE.Rows.Count > 0 Then

                    For Each DR As DataRow In DTTABLE.Rows

                        TXTPONO.Text = TEMPPONO
                        TXTPONO.ReadOnly = True
                        PODATE.Text = Format(Convert.ToDateTime(DR("DATE")), "dd/MM/yyyy")
                        CMBNAME.Text = DR("NAME")
                        TXTDELIVERY.Text = DR("DELIVERY")
                        TXTORDERREFNO.Text = DR("ORDERREFNO")
                        TXTPROFORMANO.Text = Val(DR("PROFORMANO"))
                        PROFORMADATE.Text = DR("PROFORMADATE")
                        TXTPROFORMATYPE.Text = DR("PROFORMATYPE")

                        TXTPACKING.Text = DR("PACKING")
                        TXTQUALITYNOTES.Text = DR("QUALITYNOTES")
                        TXTDIAMETER.Text = DR("DIAMETER")
                        TXTPAYMENTTERM.Text = DR("PAYMENTTERM")
                        TXTBILLINGINFO.Text = DR("BILLINGINFO")
                        TXTINSURANCE.Text = DR("INSURANCE")
                        TXTREMARKS.Text = DR("REMARKS")
                        TXTPROFORMATYPE.Text = DR("PROFORMATYPE")
                        If Convert.ToBoolean(DR("VERIFIED")) = True Then CHKVERIFY.CheckState = CheckState.Checked
                        GRIDPO.Rows.Add(Val(DR("GRIDSRNO")), DR("QUALITY"), DR("NARRATION"), Val(DR("GSM")), Val(DR("SIZE")), Val(DR("STOCK")), Val(DR("QTY")), DR("UNIT"), Format(Val(DR("RATE")), "0.00"), Format(Val(DR("AMT")), "0.00"), Val(DR("RECDQTY")), DR("GRIDPODONE"), DR("CLOSED"))

                        If Convert.ToBoolean(DR("CLOSED")) = True Or Convert.ToBoolean(DR("GRIDPODONE")) = True Or Val(DR("RECDQTY")) > 0 Then
                            GRIDPO.Rows(GRIDPO.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                            lbllocked.Visible = True
                            If Convert.ToBoolean(DR("CLOSED")) = True Then LBLCLOSED.Visible = True
                            PBlock.Visible = True
                        End If
                        TXTWASTAGEPER.Text = DR("WASTAGEPER")
                    Next

                    TOTAL()
                    GRIDPO.FirstDisplayedScrollingRowIndex = GRIDPO.RowCount - 1
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

    Sub FILLCMB()
        Try
            FILLNAME(CMBNAME, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE = 'ACCOUNTS'")
            FILLITEMNAME(CMBQUALITY, False)
            FILLUNIT(CMBUNIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CLEAR()

        EP.Clear()
        PODATE.Text = Now.Date
        CMBNAME.Text = ""
        TXTDELIVERY.Clear()
        TXTORDERREFNO.Clear()

        TXTPROFORMANO.Clear()
        PROFORMADATE.Text = Now.Date
        TXTPROFORMATYPE.Clear()

        TXTSRNO.Text = 1
        CMBQUALITY.Text = ""
        TXTNARRATION.Clear()
        TXTGSM.Clear()
        TXTSIZE.Clear()
        TXTQTY.Clear()
        CMBUNIT.Text = ""
        TXTRATE.Clear()
        TXTAMOUNT.Clear()
        GRIDPO.RowCount = 0

        LBLTOTALAMT.Text = "0.00"
        LBLTOTALQTY.Text = "0.00"
        CHKVERIFY.CheckState = CheckState.Unchecked
        TXTPACKING.Text = " Please ensure the reels are packed well. No edge damages, core crush, or loose rewinding reels will be accepted, Ensure that the reels are loaded standing in the truck while dispatching."
        TXTQUALITYNOTES.Text = "Please ensure there is no powder, no piping or creasing coming in the paper or it will be directly rejected and debited to your account."
        TXTDIAMETER.Text = "Joint less reels and Outer Diameter 1000 MM & 760 MM (VERY IMP)"
        TXTPAYMENTTERM.Text = "15 DAYS AFTER INVOICE DATE"
        TXTBILLINGINFO.Text = "As you are supplying to an AEZ Unit, the Invoice will be under LUT & 0% GST, Attached - GST & Zalani LUT Copy, Please apply our Insurance Number which is shared with you and do not Charge Insurance Amount.
We have committed the rates with our buyer hence kindly process the order at the rates mentioned in our PO"
        TXTINSURANCE.Text = "Please use our insurance policy which is sent you on email and do not charge any insurance charges from your end."
        TXTREMARKS.Clear()
        TXTSTOCK.Clear()
        GRIDPUR.RowCount = 0
        tstxtbillno.Clear()
        PBlock.Visible = False
        lbllocked.Visible = False
        LBLCLOSED.Visible = False
        getmax_PONO()
        GRIDDOUBLECLICK = False


    End Sub

    Sub getmax_PONO()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(PO_NO),0) + 1 ", "PURCHASEORDER", " AND PO_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTPONO.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Private Sub TXTAMOUNT_Validated(sender As Object, e As EventArgs) Handles TXTAMOUNT.Validated
        If CMBQUALITY.Text.Trim <> "" And Val(TXTQTY.Text.Trim) > 0 And CMBUNIT.Text.Trim <> "" Then FILLGRID()
    End Sub

    Sub FILLGRID()
        GRIDPO.Enabled = True
        If GRIDDOUBLECLICK = False Then
            GRIDPO.Rows.Add(Val(TXTSRNO.Text.Trim), CMBQUALITY.Text.Trim, TXTNARRATION.Text.Trim, Val(TXTGSM.Text.Trim), Val(TXTSIZE.Text.Trim), Val(TXTSTOCK.Text.Trim), Val(TXTQTY.Text.Trim), CMBUNIT.Text.Trim, Val(TXTRATE.Text.Trim), Val(TXTAMOUNT.Text.Trim), 0, 0, 0)
            getsrno(GRIDPO)
        ElseIf GRIDDOUBLECLICK = True Then
            GRIDPO.Item(gsrno.Index, TEMPROW).Value = Val(TXTSRNO.Text.Trim)
            GRIDPO.Item(GQUALITY.Index, TEMPROW).Value = CMBQUALITY.Text.Trim
            GRIDPO.Item(GNARRATION.Index, TEMPROW).Value = TXTNARRATION.Text.Trim
            GRIDPO.Item(GGSM.Index, TEMPROW).Value = Val(TXTGSM.Text.Trim)
            GRIDPO.Item(GSIZE.Index, TEMPROW).Value = Val(TXTSIZE.Text.Trim)
            GRIDPO.Item(GSTOCK.Index, TEMPROW).Value = Val(TXTSTOCK.Text.Trim)
            GRIDPO.Item(GQTY.Index, TEMPROW).Value = Val(TXTQTY.Text.Trim)
            GRIDPO.Item(GUNIT.Index, TEMPROW).Value = CMBUNIT.Text.Trim
            GRIDPO.Item(GRATE.Index, TEMPROW).Value = Val(TXTRATE.Text.Trim)
            GRIDPO.Item(GAMOUNT.Index, TEMPROW).Value = Val(TXTAMOUNT.Text.Trim)

            GRIDDOUBLECLICK = False
        End If

        TOTAL()
        GRIDPO.FirstDisplayedScrollingRowIndex = GRIDPO.RowCount - 1

        TXTSRNO.Text = GRIDPO.RowCount + 1
        TXTQTY.Clear()
        TXTSIZE.Clear()
        TXTSTOCK.Clear()

        TXTGSM.Clear()
        TXTAMOUNT.Clear()
        TXTNARRATION.Clear()
        TXTRATE.Clear()


        CMBQUALITY.Focus()

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

    Private Sub CMBQUALITY_Enter(sender As Object, e As EventArgs) Handles CMBQUALITY.Enter
        Try
            If CMBQUALITY.Text.Trim = "" Then FILLITEMNAME(CMBQUALITY, "")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBQUALITY_Validating(sender As Object, e As CancelEventArgs) Handles CMBQUALITY.Validating
        Try
            If CMBQUALITY.Text.Trim <> "" Then ITEMVALIDATE(CMBQUALITY, e, Me, "", "MERCHANT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TOOLNEXT_Click(sender As Object, e As EventArgs) Handles TOOLNEXT.Click
        Try
            GRIDPO.RowCount = 0
LINE1:
            TEMPPONO = Val(TXTPONO.Text) + 1
            getmax_PONO()
            Dim MAXNO As Integer = TXTPONO.Text.Trim
            CLEAR()
            If Val(TXTPONO.Text) - 1 >= TEMPPONO Then
                EDIT = True
                PurchaseOrder_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
            If GRIDPO.RowCount = 0 And TEMPPONO < MAXNO Then
                TXTPONO.Text = TEMPPONO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TOOLPREVIOUS_Click(sender As Object, e As EventArgs) Handles TOOLPREVIOUS.Click
        Try
            GRIDPO.RowCount = 0
LINE1:
            TEMPPONO = Val(TXTPONO.Text) - 1
            If TEMPPONO > 0 Then
                EDIT = True
                PurchaseOrder_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
            If GRIDPO.RowCount = 0 And TEMPPONO > 1 Then
                TXTPONO.Text = TEMPPONO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(sender As Object, e As EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Private Sub cmdclear_Click(sender As Object, e As EventArgs) Handles CMDCLEAR.Click
        Try
            CLEAR()
            EDIT = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBUNIT_Enter(sender As Object, e As EventArgs) Handles CMBUNIT.Enter
        Try
            If CMBUNIT.Text.Trim = "" Then FILLUNIT(CMBUNIT)
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

    Private Sub txtpono_Validating(sender As Object, e As CancelEventArgs) Handles TXTPONO.Validating
        Try
            If Val(TXTPONO.Text.Trim) <> 0 And EDIT = False Then
                Dim OBJCMN As New ClsCommon
                Dim DTTABLE As DataTable = OBJCMN.SEARCH("ISNULL(PURCHASEORDER.PO_NO,0)  AS PONO", "", " PURCHASEORDER ", "  AND PURCHASEORDER.PO_NO=" & Val(TXTPONO.Text.Trim) & " AND PURCHASEORDER.PO_YEARID = " & YearId)
                If DTTABLE.Rows.Count > 0 Then
                    MsgBox("Purchase Order No Already Exist")
                    e.Cancel = True
                End If
            End If
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
            Dim OBJPAYDTLS As New PurchaseOrderDetails
            OBJPAYDTLS.MdiParent = MDIMain
            OBJPAYDTLS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDSELECTPROFORMA_Click(sender As Object, e As EventArgs) Handles CMDSELECTPROFORMA.Click
        Try
            If TXTWASTAGEPER.Text.Trim = "" Then
                MsgBox("Please Fill Wastage Percent", MsgBoxStyle.Critical)
                TXTWASTAGEPER.Focus()
                Exit Sub
            End If
            If Val(TXTWASTAGEPER.Text.Trim) = 0 Then Exit Sub

            Dim OBJPROFORMA As New SelectProformaForPO
            OBJPROFORMA.FRMSTRING = "PO"
            OBJPROFORMA.ShowDialog()
            Dim DT As DataTable = OBJPROFORMA.DT
            If DT.Rows.Count > 0 Then
                TXTPROFORMANO.Text = Val(DT.Rows(0).Item("PROFORMANO"))
                TXTPROFORMATYPE.Text = DT.Rows(0).Item("TYPE")
                PROFORMADATE.Text = DT.Rows(0).Item("DATE")

                Dim OBJCMN As New ClsCommon
                ' Dim DTSO As DataTable = OBJCMN.SEARCH("ISNULL(ITEMMASTER.ITEM_NAME, '') AS QUALITY , ROUND(PROFORMAINVOICEMASTER_DESC.INVOICE_GSM , 0 ) AS GSM, ROUND(PROFORMAINVOICEMASTER_DESC.INVOICE_SIZE, 0) AS REQDSIZE, ROUND(PROFORMAINVOICEMASTER_DESC.INVOICE_SIZE + 10, 0) AS SIZE, ISNULL(PROFORMAINVOICEMASTER_DESC.INVOICE_FOILQUALITYID, '') AS FOILQUALITY, ISNULL(PROFORMAINVOICEMASTER_DESC.INVOICE_FOILGSM, '') AS FOILGSM, ISNULL(PROFORMAINVOICEMASTER_DESC.INVOICE_PEGSM, '') AS PEGSM, ISNULL(PROFORMAINVOICEMASTER_DESC.INVOICE_ROLLDIAMETER, '') AS ROLLDIAMETER, ISNULL(PROFORMAINVOICEMASTER_DESC.INVOICE_COREPIPEWIDTH, '') AS COREPIPEWIDTH, ISNULL(PROFORMAINVOICEMASTER_DESC.INVOICE_PALLETIZED, '') AS PALLETIZED, ISNULL(PROFORMAINVOICEMASTER_DESC.INVOICE_NARRATION, '') AS NARRATION, ISNULL(PROFORMAINVOICEMASTER_DESC.INVOICE_QTY, 0) AS QTY, ISNULL(PROFORMAINVOICEMASTER_DESC.INVOICE_RATE, 0) AS RATE, ISNULL(PROFORMAINVOICEMASTER_DESC.INVOICE_AMOUNT, 0) AS AMOUNT, ISNULL(PROFORMAINVOICEMASTER_DESC.INVOICE_GRIDSRNO, 0) AS GRIDSRNO, ISNULL(PROFORMAINVOICEMASTER_DESC.INVOICE_DESC, '') AS GRIDDESC, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT", "", " ITEMMASTER RIGHT OUTER JOIN ITEMMASTER_DESC ON ITEMMASTER.item_id = ITEMMASTER_DESC.ITEM_ITEMID RIGHT OUTER JOIN  PROFORMAINVOICEMASTER_DESC ON ITEMMASTER_DESC.ITEM_ID = PROFORMAINVOICEMASTER_DESC.INVOICE_FINISHEDQUALITYID LEFT OUTER JOIN UNITMASTER ON PROFORMAINVOICEMASTER_DESC.INVOICE_UNITID = UNITMASTER.unit_id ", " AND INVOICE_NO = " & Val(TXTPROFORMANO.Text.Trim) & "  AND PROFORMAINVOICEMASTER_DESC.INVOICE_GRIDSRNO = '" & Val(DT.Rows(0).Item("GRIDSRNO")) & "' AND INVOICE_YEARID = " & YearId)
                Dim DTSO As DataTable = OBJCMN.SEARCH("ISNULL(ITEMMASTER.ITEM_NAME, '') AS QUALITY, ROUND(ALLPROFORMAINVOICEMASTER_DESC.INVOICE_GSM, 0) AS GSM, ROUND(ALLPROFORMAINVOICEMASTER_DESC.INVOICE_SIZE, 0) AS REQDSIZE,  ROUND(ALLPROFORMAINVOICEMASTER_DESC.INVOICE_SIZE + 10, 0) AS SIZE, ISNULL(ALLPROFORMAINVOICEMASTER_DESC.INVOICE_FOILQUALITYID, '') AS FOILQUALITY, ISNULL(ALLPROFORMAINVOICEMASTER_DESC.INVOICE_FOILGSM, '') AS FOILGSM, ISNULL(ALLPROFORMAINVOICEMASTER_DESC.INVOICE_PEGSM, '') AS PEGSM, ISNULL(ALLPROFORMAINVOICEMASTER_DESC.INVOICE_ROLLDIAMETER, '') AS ROLLDIAMETER, ISNULL(ALLPROFORMAINVOICEMASTER_DESC.INVOICE_COREPIPEWIDTH, '') AS COREPIPEWIDTH, ISNULL(ALLPROFORMAINVOICEMASTER_DESC.INVOICE_PALLETIZED, '') AS PALLETIZED, ISNULL(ALLPROFORMAINVOICEMASTER_DESC.INVOICE_NARRATION, '') AS NARRATION, ISNULL(ALLPROFORMAINVOICEMASTER_DESC.INVOICE_QTY, 0) AS QTY, ISNULL(ALLPROFORMAINVOICEMASTER_DESC.INVOICE_RATE, 0) AS RATE, ISNULL(ALLPROFORMAINVOICEMASTER_DESC.INVOICE_AMOUNT, 0) AS AMOUNT, ISNULL(ALLPROFORMAINVOICEMASTER_DESC.INVOICE_GRIDSRNO, 0) AS GRIDSRNO, ISNULL(ALLPROFORMAINVOICEMASTER_DESC.INVOICE_DESC, '') AS GRIDDESC, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT", "", " ITEMMASTER RIGHT OUTER JOIN ITEMMASTER_DESC ON ITEMMASTER.item_id = ITEMMASTER_DESC.ITEM_ITEMID RIGHT OUTER JOIN  ALLPROFORMAINVOICEMASTER_DESC ON ITEMMASTER_DESC.ITEM_ID = ALLPROFORMAINVOICEMASTER_DESC.INVOICE_FINISHEDQUALITYID LEFT OUTER JOIN UNITMASTER ON ALLPROFORMAINVOICEMASTER_DESC.INVOICE_UNITID = UNITMASTER.unit_id ", " AND ALLPROFORMAINVOICEMASTER_DESC.INVOICE_NO = " & Val(TXTPROFORMANO.Text.Trim) & "  AND ALLPROFORMAINVOICEMASTER_DESC.INVOICE_GRIDSRNO = '" & Val(DT.Rows(0).Item("GRIDSRNO")) & "' AND ALLPROFORMAINVOICEMASTER_DESC.INVOICE_YEARID = " & YearId)


                For Each DTROW As DataRow In DTSO.Rows

                    'GET PE GSM AND CALCULATE THE WT
                    Dim TOTALGSM As Double = Val(DTROW("GSM")) + Val(DTROW("PEGSM")) + Val(DTROW("FOILGSM"))
                    Dim PROFORMAWT As Double = 0.00
                    Dim QTY As Double = 0.00
                    Dim GSM As Double = 0.00
                    If DTROW("UNIT") = "MTS" Then PROFORMAWT = DTROW("QTY") * 1000
                    'PROFORMAWT = Format(Val(PROFORMAWT / Val(DTROW("REQDSIZE")) * Val(DTROW("SIZE"))), "0.000")
                    'PROFORMAWT = Format(Val(PROFORMAWT - (PROFORMAWT * 4 / 100)), "0.000")

                    If DTROW("QUALITY") = "LDPE" And Val(DTROW("PEGSM")) > 0 Then
                        QTY = Format(PROFORMAWT / TOTALGSM * Val(DTROW("PEGSM")), "0.000")
                        GSM = Val(DTROW("PEGSM"))
                    ElseIf DTROW("QUALITY") = "FOIL" Then
                        QTY = Format(PROFORMAWT / TOTALGSM * Val(DTROW("FOILGSM")), "0.000")
                        GSM = Val(DTROW("FOILGSM"))
                    Else
                        QTY = Format(PROFORMAWT / TOTALGSM * Val(DTROW("GSM")), "0.000")
                        GSM = Val(DTROW("GSM"))
                    End If
                    QTY = Format(QTY + (Val(TXTWASTAGEPER.Text.Trim) * QTY / 100), "0.00")
                    GRIDPO.Rows.Add(0, DTROW("QUALITY"), DTROW("NARRATION").ToString, Val(GSM), Val(DTROW("SIZE")), 0, QTY, "KGS", 0, 0, 0, 0, 0)
                Next
                getsrno(GRIDPO)
                TOTAL()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridpo_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRIDPO.CellDoubleClick
        EDITROW()
    End Sub

    Private Sub gridpo_KeyDown(sender As Object, e As KeyEventArgs) Handles GRIDPO.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDPO.RowCount > 0 Then

                If Convert.ToBoolean(GRIDPO.Rows(GRIDPO.CurrentRow.Index).Cells(GDONE.Index).Value) = True Or Convert.ToBoolean(GRIDPO.Rows(GRIDPO.CurrentRow.Index).Cells(GCLOSED.Index).Value) = True Then
                    MsgBox("Item Locked", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If

                GRIDPO.Rows.RemoveAt(GRIDPO.CurrentRow.Index)
                getsrno(GRIDPO)
                TOTAL()

            ElseIf e.KeyCode = Keys.F5 Then
                EDITROW()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub TOTAL()
        Try
            LBLTOTALQTY.Text = "0.00"
            LBLTOTALAMT.Text = "0.00"
            For Each ROW As DataGridViewRow In GRIDPO.Rows
                ROW.Cells(GAMOUNT.Index).Value = Format(Val(ROW.Cells(GQTY.Index).EditedFormattedValue) * Val(ROW.Cells(GRATE.Index).EditedFormattedValue), "0.00")
                LBLTOTALQTY.Text = Format(Val(LBLTOTALQTY.Text) + Val(ROW.Cells(GQTY.Index).EditedFormattedValue), "0.00")
                LBLTOTALAMT.Text = Val(LBLTOTALAMT.Text) + Val(ROW.Cells(GAMOUNT.Index).EditedFormattedValue)
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDDELETE_Click(sender As Object, e As EventArgs) Handles CMDDELETE.Click
        Try
            If EDIT = True Then

                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                If PBlock.Visible = True Then
                    MsgBox("PO Locked", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                If MsgBox("Delete Purchase Order ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                Dim alParaval As New ArrayList
                alParaval.Add(TEMPPONO)
                alParaval.Add(YearId)

                Dim OBJPO As New ClsPurchaseOrder()
                OBJPO.alParaval = alParaval
                Dim IntResult As Integer = OBJPO.DELETE()
                MsgBox("Purchase Order Deleted")
                CLEAR()
                EDIT = False
            Else
                MsgBox("Delete is only in Edit Mode")
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub EDITROW()
        Try
            If GRIDPO.CurrentRow.Index >= 0 And GRIDPO.Item(gsrno.Index, GRIDPO.CurrentRow.Index).Value <> Nothing Then

                If Convert.ToBoolean(GRIDPO.Rows(GRIDPO.CurrentRow.Index).Cells(GDONE.Index).Value) = True Or Convert.ToBoolean(GRIDPO.Rows(GRIDPO.CurrentRow.Index).Cells(GCLOSED.Index).Value) = True Then
                    MsgBox("Item Locked", MsgBoxStyle.Critical)
                    Exit Sub
                End If


                GRIDDOUBLECLICK = True
                TXTSRNO.Text = GRIDPO.Item(gsrno.Index, GRIDPO.CurrentRow.Index).Value.ToString
                CMBQUALITY.Text = GRIDPO.Item(GQUALITY.Index, GRIDPO.CurrentRow.Index).Value.ToString
                TXTNARRATION.Text = GRIDPO.Item(GNARRATION.Index, GRIDPO.CurrentRow.Index).Value.ToString
                TXTGSM.Text = GRIDPO.Item(GGSM.Index, GRIDPO.CurrentRow.Index).Value.ToString
                TXTSIZE.Text = GRIDPO.Item(GSIZE.Index, GRIDPO.CurrentRow.Index).Value.ToString
                TXTSTOCK.Text = Val(GRIDPO.Item(GSTOCK.Index, GRIDPO.CurrentRow.Index).Value)
                TXTQTY.Text = Val(GRIDPO.Item(GQTY.Index, GRIDPO.CurrentRow.Index).Value)
                CMBUNIT.Text = GRIDPO.Item(GUNIT.Index, GRIDPO.CurrentRow.Index).Value.ToString
                TXTRATE.Text = Val(GRIDPO.Item(GRATE.Index, GRIDPO.CurrentRow.Index).Value)
                TXTAMOUNT.Text = Val(GRIDPO.Item(GAMOUNT.Index, GRIDPO.CurrentRow.Index).Value)

                TEMPROW = GRIDPO.CurrentRow.Index
                CMBQUALITY.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(sender As Object, e As CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                GRIDPO.RowCount = 0
                TEMPPONO = Val(tstxtbillno.Text)
                If TEMPPONO > 0 Then
                    EDIT = True
                    PurchaseOrder_Load(sender, e)
                Else
                    CLEAR()
                    EDIT = False
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Validating(sender As Object, e As CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, CMBCODE, e, Me, TXTADD, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors'", "Sundry Creditors", "ACCOUNTS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Enter(sender As Object, e As EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then FILLNAME(CMBNAME, EDIT, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='ACCOUNTS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtremarks_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTREMARKS.KeyDown
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

    Private Sub PROFORMADATE_Validating(sender As Object, e As CancelEventArgs) Handles PROFORMADATE.Validating
        Try
            If PROFORMADATE.Text.Trim <> "__/__/____" Then
                Dim TEMP As DateTime
                If Not DateTime.TryParse(PROFORMADATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TOOLPRINT_Click(sender As Object, e As EventArgs) Handles TOOLPRINT.Click
        Try
            If EDIT = True Then PRINTREPORT()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PRINTREPORT()
        Try
            If CHKVERIFY.Checked = True Then

                If MsgBox("Wish to Print Order?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                Dim OBJPO As New PurchaseOrderDesign
                OBJPO.MdiParent = MDIMain
                OBJPO.PARTYNAME = CMBNAME.Text.Trim
                OBJPO.FRMSTRING = "POREPORT"
                OBJPO.FORMULA = "{PURCHASEORDER.PO_NO}=" & Val(TXTPONO.Text) & " and {PURCHASEORDER.PO_yearid}=" & YearId
                OBJPO.Show()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PODATE_Validating(sender As Object, e As CancelEventArgs) Handles PODATE.Validating
        Try
            If PODATE.Text.Trim <> "__/__/____" Then
                Dim TEMP As DateTime
                If Not DateTime.TryParse(PODATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTRATE_Validating(sender As Object, e As CancelEventArgs) Handles TXTRATE.Validating, TXTQTY.Validating
        CALC()
    End Sub

    Sub CALC()
        Try
            If Val(TXTRATE.Text.Trim) > 0 And Val(TXTQTY.Text.Trim) > 0 Then TXTAMOUNT.Text = Format(Val(TXTRATE.Text.Trim) * Val(TXTQTY.Text.Trim), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PurchaseOrder_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            If ERRORVALID() = True Then
                Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                If tempmsg = vbYes Then cmdok_Click(sender, e)
            End If
            Me.Close()
        ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for Delete
            tstxtbillno.Focus()
            tstxtbillno.SelectAll()
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D1 Then       'for Delete
            TabControl1.SelectedIndex = (0)
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D2 Then       'for Delete
            TabControl1.SelectedIndex = (1)
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D3 Then       'for Delete
            TabControl1.SelectedIndex = (2)
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D4 Then       'for Delete
            TabControl1.SelectedIndex = (3)
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D5 Then       'for Delete
            TabControl1.SelectedIndex = (4)
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D6 Then       'for Delete
            TabControl1.SelectedIndex = (5)
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D7 Then       'for Delete
            TabControl1.SelectedIndex = (6)
        ElseIf e.KeyCode = Keys.Oemcomma Then
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.F5 Then
            GRIDPO.Focus()
        ElseIf e.Alt = True And e.KeyCode = Keys.Left Then
            TOOLPREVIOUS_Click(sender, e)
        ElseIf e.Alt = True And e.KeyCode = Keys.Right Then
            TOOLNEXT_Click(sender, e)
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
            Call OpenToolStripButton_Click(sender, e)
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        ElseIf e.KeyCode = Keys.P And e.Alt = True Then
            Call TOOLPRINT_Click(sender, e)
        End If
    End Sub

    Private Sub TXTQTY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTQTY.KeyPress, TXTRATE.KeyPress, TXTGSM.KeyPress, TXTSIZE.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub TXTSIZE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTSIZE.KeyPress, tstxtbillno.KeyPress, TXTWASTAGEPER.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub CMBQUALITY_Validated(sender As Object, e As EventArgs) Handles CMBQUALITY.Validated, TXTSIZE.Validated, TXTGSM.Validated
        GETSTOCK()
        GETPURCHASE(CMBQUALITY.Text.Trim)
    End Sub

    Sub GETSTOCK()
        Try
            If CMBQUALITY.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.SEARCH("ISNULL(ITEMNAME, '') AS QUALITY, ISNULL(GSM, 0) AS GSM, ISNULL(SIZE, 0) AS SIZE, ISNULL(QTY, 0) AS QTY , SUM(QTY) AS QTY", "", "STOCKREGISTER", " AND STOCKREGISTER.ITEMNAME='" & CMBQUALITY.Text.Trim & "'  AND YEARID = " & YearId & "GROUP BY QTY , GSM ,SIZE , STOCKREGISTER.ITEMNAME")
                If DT.Rows.Count > 0 Then TXTSTOCK.Text = Val(DT.Rows(0).Item("QTY"))
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETPURCHASE(STORESITEMNAME As String)
        Try
            GRIDPUR.RowCount = 0
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.SEARCH(" TOP 5 ISNULL(PURCHASEORDER.PO_NO,0) AS BILLNO, PURCHASEORDER.PO_DATE AS BILLDATE, ISNULL(LEDGERS.ACC_CMPNAME,'') AS NAME, ISNULL(PURCHASEORDER_DESC.PO_QTY,0) AS QTY, ISNULL(PURCHASEORDER_DESC.PO_RATE,0) AS RATE, ISNULL(PURCHASEORDER_DESC.PO_AMT,0) AS AMT  ", "", " PURCHASEORDER INNER JOIN PURCHASEORDER_DESC ON PURCHASEORDER.PO_NO = PURCHASEORDER_DESC.PO_NO AND PURCHASEORDER.PO_YEARID = PURCHASEORDER_DESC.PO_YEARID INNER JOIN LEDGERS ON PURCHASEORDER.PO_LEDGERID = ACC_ID INNER JOIN ITEMMASTER ON PO_QUALITYID  = ITEM_ID ", " AND ITEMMASTER.ITEM_NAME = '" & STORESITEMNAME & "' ORDER BY PURCHASEORDER.PO_DATE DESC  ")
            For Each DTROW As DataRow In DT.Rows
                GRIDPUR.Rows.Add(0, Format(Convert.ToDateTime(DTROW("BILLDATE")).Date, "dd/MM/yyyy"), DTROW("NAME"), Format(Val(DTROW("QTY")), "0.00"), Format(Val(DTROW("RATE")), "0.00"), Format(Val(DTROW("AMT")), "0.00"))
            Next
            getsrno(GRIDPUR)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDPO_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles GRIDPO.RowEnter
        Try
            If e.RowIndex >= 0 AndAlso GRIDPO.SelectedRows.Count > 0 Then GETPURCHASE(GRIDPO.Rows(e.RowIndex).Cells(GQUALITY.Index).EditedFormattedValue)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Validated(sender As Object, e As EventArgs) Handles CMBNAME.Validated
        Try
            Try
                If CMBNAME.Text.Trim <> "" Then
                    'GET PORTDISCHARGE,PORTLOADING AND PAYMENTTERM AND WARNING TEXT
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.SEARCH(" ISNULL(LEDGERS.ACC_WARNING, '') AS WARNING", "", " LEDGERS ", " and LEDGERS.acc_cmpname = '" & CMBNAME.Text.Trim & "' and LEDGERS.acc_YEARid = " & YearId)
                    If DT.Rows.Count > 0 Then
                        If DT.Rows(0).Item("WARNING") <> "" Then MsgBox(DT.Rows(0).Item("WARNING"), MsgBoxStyle.Critical)

                    End If
                End If
            Catch ex As Exception
                Throw ex
            End Try
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTPACKING_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTPACKING.KeyDown
        Try
            Try
                If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
                If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

                If e.KeyCode = Keys.F1 Then
                    Dim OBJREMARKS As New SelectRemarks
                    OBJREMARKS.FRMSTRING = "NARRATION"
                    OBJREMARKS.ShowDialog()
                    If OBJREMARKS.TEMPNAME <> "" Then TXTPACKING.Text = OBJREMARKS.TEMPNAME
                End If
            Catch ex As Exception
                Throw ex
            End Try
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTQUALITYNOTES_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTQUALITYNOTES.KeyDown
        Try
            Try
                If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
                If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

                If e.KeyCode = Keys.F1 Then
                    Dim OBJREMARKS As New SelectRemarks
                    OBJREMARKS.FRMSTRING = "NARRATION"
                    OBJREMARKS.ShowDialog()
                    If OBJREMARKS.TEMPNAME <> "" Then TXTQUALITYNOTES.Text = OBJREMARKS.TEMPNAME
                End If
            Catch ex As Exception
                Throw ex
            End Try
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(sender As Object, e As EventArgs) Handles SaveToolStripButton.Click
        Call cmdok_Click(sender, e)
    End Sub

    Private Sub TOOLDELETE_Click(sender As Object, e As EventArgs) Handles TOOLDELETE.Click
        Call CMDDELETE_Click(sender, e)
    End Sub

    Private Sub TXTBILLINGINFO_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTBILLINGINFO.KeyDown
        Try
            Try
                If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
                If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

                If e.KeyCode = Keys.F1 Then
                    Dim OBJREMARKS As New SelectRemarks
                    OBJREMARKS.FRMSTRING = "NARRATION"
                    OBJREMARKS.ShowDialog()
                    If OBJREMARKS.TEMPNAME <> "" Then TXTBILLINGINFO.Text = OBJREMARKS.TEMPNAME
                End If
            Catch ex As Exception
                Throw ex
            End Try
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub TXTDIAMETER_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTDIAMETER.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJREMARKS As New SelectRemarks
                OBJREMARKS.FRMSTRING = "NARRATION"
                OBJREMARKS.ShowDialog()
                If OBJREMARKS.TEMPNAME <> "" Then TXTDIAMETER.Text = OBJREMARKS.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub TXTINSURANCE_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTINSURANCE.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJREMARKS As New SelectRemarks
                OBJREMARKS.FRMSTRING = "NARRATION"
                OBJREMARKS.ShowDialog()
                If OBJREMARKS.TEMPNAME <> "" Then TXTINSURANCE.Text = OBJREMARKS.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTPAYMENTTERM_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTPAYMENTTERM.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJREMARKS As New SelectRemarks
                OBJREMARKS.FRMSTRING = "NARRATION"
                OBJREMARKS.ShowDialog()
                If OBJREMARKS.TEMPNAME <> "" Then TXTPAYMENTTERM.Text = OBJREMARKS.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class