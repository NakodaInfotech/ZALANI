
Imports System.ComponentModel
Imports BL

Public Class StockReco

    Dim IntResult As Integer
    Dim GRIDDOUBLECLICK As Boolean
    Public TEMPRECONO As Integer          'used for editing
    Public EDIT As Boolean          'used for editing
    Dim TEMPROW As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim TEMPMSG As Integer
    Public TEMPPROFORMANO As Integer = 0
    Public UNCHECKEDSTOCK As Boolean = False
    Dim ALLOWMANUALRECNO As Boolean = False

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub StockReco_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            If ERRORVALID() = True Then
                Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                If tempmsg = vbYes Then cmdok_Click(sender, e)
            End If
            Me.Close()
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D1 Then       'for Delete
            TabControl1.SelectedIndex = (0)
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D2 Then       'for Delete
            TabControl1.SelectedIndex = (1)
        ElseIf e.KeyCode = Keys.OemPipe Then
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for billno foucs
            tstxtbillno.Focus()
            tstxtbillno.SelectAll()
        ElseIf e.Alt = True And e.KeyCode = Keys.Left Then
            toolprevious_Click(sender, e)
        ElseIf e.Alt = True And e.KeyCode = Keys.Right Then
            toolnext_Click(sender, e)
        ElseIf e.KeyCode = Keys.F5 Then     'grid focus
            GRIDSTOCK.Focus()
        ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
            Call OpenToolStripButton_Click(sender, e)
        End If
    End Sub

    Sub FILLCMB()
        Try
            If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, EDIT)
            If CMBINITEMNAME.Text = "" Then FILLITEMNAME(CMBINITEMNAME, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
            If CMBINUNIT.Text.Trim = "" Then FILLUNIT(CMBINUNIT)
            If cmbtrans.Text.Trim = "" Then FILLNAME(cmbtrans, EDIT, " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE='TRANSPORT'")
            If CMBNAME.Text.Trim = "" Then FILLNAME(CMBNAME, EDIT, " AND (GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' OR GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS') AND LEDGERS.ACC_TYPE='ACCOUNTS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub StockReco_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'SALE INVOICE'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            Cursor.Current = Cursors.WaitCursor
            'If ClientName = "AVIS" Then ALLOWMANUALRECNO = True

            FILLCMB()
            CLEAR()


            If EDIT = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If


                Dim objSTOCK As New ClsStockAdjustment()
                Dim dttable As DataTable = objSTOCK.SELECTSTOCKADJUSTMENT(TEMPRECONO, CmpId, Locationid, YearId)
                If dttable.Rows.Count > 0 Then

                    For Each dr As DataRow In dttable.Rows
                        TXTRECONO.Text = TEMPRECONO
                        TXTRECONO.ReadOnly = True
                        DTRECODATE.Value = Format(Convert.ToDateTime(dr("DATE")).Date, "dd/MM/yyyy")
                        CMBGODOWN.Text = Convert.ToString(dr("GODOWN").ToString)
                        cmbtrans.Text = dr("TRANSNAME")
                        CMBNAME.Text = dr("NAME")
                        txtremarks.Text = Convert.ToString(dr("remarks").ToString)

                        'Item Grid
                        If Val(dr("GRIDSRNO")) > 0 Then GRIDSTOCK.Rows.Add(dr("GRIDSRNO").ToString, dr("ITEMNAME").ToString, dr("LOTNO").ToString, dr("REELNO").ToString, dr("GSM").ToString, dr("GSMDETAILS").ToString, dr("SIZE").ToString, Format(dr("QTY"), "0.00"), dr("UNIT"), dr("BARCODE").ToString, dr("FROMNO"), dr("FROMSRNO"), dr("FROMTYPE"))

                    Next



                    'GET DATA FROM STOCKADJUSTMENT_INDESC
                    Dim OBJCMN As New ClsCommon
                    Dim DT As DataTable = OBJCMN.SEARCH("ISNULL(STOCKADJUSTMENT_INDESC.SA_GRIDSRNO, 0) AS GRIDSRNO, ISNULL(ITEMMASTER.ITEM_NAME, '') AS ITEM, ISNULL(STOCKADJUSTMENT_INDESC.SA_LOTNO, '') AS LOTNO, ISNULL(STOCKADJUSTMENT_INDESC.SA_REELNO, '') AS REELNO, ISNULL(STOCKADJUSTMENT_INDESC.SA_QTY, 0) AS QTY, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT, ISNULL(STOCKADJUSTMENT_INDESC.SA_BARCODE, '') AS BARCODE, ISNULL(STOCKADJUSTMENT_INDESC.SA_OUTQTY, 0) AS OUTQTY, STOCKADJUSTMENT_INDESC.SA_GRIDDONE AS GRIDDONE, ISNULL(STOCKADJUSTMENT_INDESC.SA_GSM, 0) AS GSM, ISNULL(STOCKADJUSTMENT_INDESC.SA_GSMDETAILS, '') AS GSMDETAILS, ISNULL(STOCKADJUSTMENT_INDESC.SA_SIZE, 0) AS SIZE ", "", "  STOCKADJUSTMENT_INDESC LEFT OUTER JOIN ITEMMASTER AS ITEMMASTER ON STOCKADJUSTMENT_INDESC.SA_YEARID = ITEMMASTER.item_yearid AND STOCKADJUSTMENT_INDESC.SA_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN UNITMASTER ON STOCKADJUSTMENT_INDESC.SA_UNITID = UNITMASTER.unit_id ", " AND SA_NO = " & TEMPRECONO & " AND SA_YEARID = " & YearId & " ORDER BY STOCKADJUSTMENT_INDESC.SA_GRIDSRNO")

                    'Dim DT As DataTable = OBJCMN.search(" ISNULL(STOCKADJUSTMENT_INDESC.SA_GRIDSRNO, 0) AS GRIDSRNO, ISNULL(PIECETYPEMASTER.PIECETYPE_name,'') AS PIECETYPE, ISNULL(ITEMMASTER.item_name, '') AS ITEM, ISNULL(QUALITYMASTER.QUALITY_name, '') AS QUALITY, ISNULL(STOCKADJUSTMENT_INDESC.SA_BALENO, '') AS BALENO, ISNULL(DESIGNMASTER.DESIGN_NO, '') AS DESIGN, ISNULL(COLORMASTER.COLOR_name, '') AS COLOR, ISNULL(STOCKADJUSTMENT_INDESC.SA_CUT, 0) AS CUT, ISNULL(STOCKADJUSTMENT_INDESC.SA_QTY, 0) AS QTY, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT, ISNULL(STOCKADJUSTMENT_INDESC.SA_MTRS, 0) AS MTRS,ISNULL(STOCKADJUSTMENT_INDESC.SA_RACKID, 0) AS RACK,ISNULL(STOCKADJUSTMENT_INDESC.SA_SHELFID, 0) AS SHELF, ISNULL(STOCKADJUSTMENT_INDESC.SA_BARCODE, '') AS BARCODE, ISNULL(STOCKADJUSTMENT_INDESC.SA_OUTPCS, 0) AS OUTPCS, ISNULL(STOCKADJUSTMENT_INDESC.SA_OUTMTRS, 0) AS OUTMTRS, STOCKADJUSTMENT_INDESC.SA_GRIDDONE AS GRIDDONE ", "", " STOCKADJUSTMENT_INDESC INNER JOIN PIECETYPEMASTER ON STOCKADJUSTMENT_INDESC.SA_PIECETYPEID = PIECETYPEMASTER.PIECETYPE_id LEFT OUTER JOIN UNITMASTER ON STOCKADJUSTMENT_INDESC.SA_QTYUNITID = UNITMASTER.unit_id LEFT OUTER JOIN DESIGNMASTER AS DESIGNMASTER ON STOCKADJUSTMENT_INDESC.SA_DESIGNID = DESIGNMASTER.DESIGN_id LEFT OUTER JOIN QUALITYMASTER ON STOCKADJUSTMENT_INDESC.SA_QUALITYID = QUALITYMASTER.QUALITY_id LEFT OUTER JOIN COLORMASTER ON STOCKADJUSTMENT_INDESC.SA_COLORID = COLORMASTER.COLOR_id LEFT OUTER JOIN ITEMMASTER AS ITEMMASTER ON STOCKADJUSTMENT_INDESC.SA_ITEMID = ITEMMASTER.item_id ", " AND SA_NO = " & TEMPRECONO & " AND SA_YEARID = " & YearId)
                    For Each DR As DataRow In DT.Rows
                        'Item Grid
                        GRIDSTOCKIN.Rows.Add(DR("GRIDSRNO").ToString, DR("ITEM").ToString, DR("LOTNO").ToString, DR("REELNO").ToString, DR("GSM").ToString, DR("GSMDETAILS").ToString, DR("SIZE").ToString, DR("QTY").ToString, DR("UNIT").ToString, DR("BARCODE").ToString, DR("GRIDDONE").ToString, DR("OUTQTY").ToString)

                        If Convert.ToBoolean(DR("GRIDDONE")) = True Or Val(DR("OUTQTY")) > 0 Then
                            GRIDSTOCKIN.Rows(GRIDSTOCKIN.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If
                        TabControl1.SelectedIndex = 1
                    Next

                Else
                    EDIT = False
                    CLEAR()
                End If


                TOTAL()
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Sub CLEAR()

        EP.Clear()
        LBLCATEGORY.Text = ""


        DTRECODATE.Value = Now.Date
        tstxtbillno.Clear()
        TXTFROM.Clear()
        TXTTO.Clear()

        txtremarks.Clear()

        CMDSELECTSTOCK.Enabled = True

        lbllocked.Visible = False
        PBlock.Visible = False
        CHKCOPY.Checked = False

        LBLTOTALINQTY.Text = 0.0
        cmbtrans.Text = ""

        TXTBARCODE.Clear()

        GRIDSTOCK.RowCount = 0


        txtsrno.Text = 1
        CMBINITEMNAME.Text = ""
        TXTINGSMDETAILS.Clear()
        TXTINREELNO.Clear()
        TXTINLOTNO.Clear()
        TXTINGSM.Clear()
        TXTINQTY.Clear()
        TXTNOOFENTRIES.Clear()
        CMBINUNIT.Text = ""
        TXTINSIZE.Clear()
        CMBNAME.Text = ""

        TXTINBARCODE.Clear()
        GRIDSTOCKIN.RowCount = 0


        GRIDDOUBLECLICK = False
        TabControl1.SelectedIndex = 0
        getmaxno()

        If ALLOWMANUALRECNO = True Then
            TXTRECONO.ReadOnly = False
            TXTRECONO.BackColor = Color.LemonChiffon
        Else
            TXTRECONO.ReadOnly = True
            TXTRECONO.BackColor = Color.Linen
            TXTMTRSDIFF.Clear()
            LBLTOTALQTY.Text = 0.0
        End If

    End Sub

    Function ERRORVALID() As Boolean
        Try
            Dim bln As Boolean = True




            If ALLOWMANUALRECNO = True Then
                If Val(TXTRECONO.Text.Trim) <> 0 And EDIT = False Then
                    Dim OBJCMNn As New ClsCommon
                    Dim dttable As DataTable = OBJCMNn.SEARCH(" ISNULL(STOCKADJUSTMENT.SA_NO,0)  AS RECONO", "", " STOCKADJUSTMENT ", "  AND STOCKADJUSTMENT.SA_NO=" & Val(TXTRECONO.Text.Trim) & " AND STOCKADJUSTMENT.SA_YEARID = " & YearId)
                    If dttable.Rows.Count > 0 Then
                        MsgBox("Rec No Already Exist")
                        bln = False
                    End If
                End If
            End If


            If CMBGODOWN.Text.Trim.Length = 0 Then
                EP.SetError(CMBGODOWN, " Please Fill Godown")
                bln = False
            End If

            If lbllocked.Visible = True Then
                EP.SetError(lbllocked, " Inward Done, Delete Inward First")
                bln = False
            End If

            If GRIDSTOCK.RowCount = 0 And GRIDSTOCKIN.RowCount = 0 Then
                EP.SetError(TabControl1, "Fill Item Details")
                bln = False
            End If

            For Each ROW As DataGridViewRow In GRIDSTOCK.Rows
                If Val(ROW.Cells(GQTY.Index).Value) = 0 Then
                    EP.SetError(GRIDSTOCK, "Qty Cannot be 0")
                    bln = False
                End If
            Next


            'CHEKC BARCODE IS PRESENT IN DATABASE OR NOT
            'If Not CHECKBARCODE() Then
            '    bln = False
            '    EP.SetError(TabControl1, "Barcode already present, Please re-enter data")
            'End If

            If Not datecheck(DTRECODATE.Text) Then
                EP.SetError(DTRECODATE, "Date not in Accounting Year")
                bln = False
            End If

            If Convert.ToDateTime(DTRECODATE.Text).Date < STOCKADJBLOCKDATE.Date Then
                EP.SetError(DTRECODATE, "Date is Blocked, Please make entries after " & Format(STOCKADJBLOCKDATE.Date, "dd/MM/yyyy"))
                bln = False
            End If

            Return bln
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try

    End Function

    'Private Function CHECKBARCODE() As Boolean
    '    Try
    '        Dim BLN As Boolean = True
    '        Dim OBJCMN As New ClsCommon
    '        Dim DT As DataTable = OBJCMN.SEARCH(" ISNULL(SA_BARCODE,'') AS BARCODE ", "", " STOCKADJUSTMENT_INDESC ", " AND SA_YEARID =  " & YearId)
    '        If DT.Rows.Count > 0 Then
    '            For Each DTR As DataRow In DT.Rows
    '                For Each ROW As Windows.Forms.DataGridViewRow In GRIDSTOCKIN.Rows
    '                    If ((EDIT = False) And Convert.ToString(DTR("BARCODE")) = ROW.Cells(EINBARCODE.Index).Value.ToString) Then
    '                        BLN = False
    '                        Exit Function
    '                    End If
    '                Next
    '            Next
    '        End If
    '        Return BLN
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        CLEAR()
        EDIT = False
        DTRECODATE.Focus()
        ' TEMPPROFORMANO = 0
    End Sub

    Sub getmaxno()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(SA_no),0) + 1 ", " STOCKADJUSTMENT ", " AND SA_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTRECONO.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            Cursor.Current = Cursors.WaitCursor
            EP.Clear()
            If Not ERRORVALID() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList

            If TXTRECONO.ReadOnly = False Then
                alParaval.Add(Val(TXTRECONO.Text.Trim))
            Else
                alParaval.Add(0)
            End If
            alParaval.Add(CMBNAME.Text.Trim)
            alParaval.Add(Format(DTRECODATE.Value.Date, "MM/dd/yyyy"))
            alParaval.Add(CMBGODOWN.Text.Trim)
            alParaval.Add(cmbtrans.Text.Trim)
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(Val(LBLTOTALINQTY.Text))
            alParaval.Add(Val(LBLTOTALQTY.Text.Trim))
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)


            Dim gridsrno As String = ""
            Dim ITEMNAME As String = ""
            Dim LOTNO As String = ""
            Dim REELNO As String = ""
            Dim GSM As String = ""
            Dim GSMDETAILS As String = ""
            Dim SIZE As String = ""
            Dim QTY As String = ""
            Dim UNIT As String = ""
            Dim BARCODE As String = "" 'BARCODE ADDED
            Dim FROMNO As String = ""
            Dim FROMSRNO As String = ""
            Dim FROMTYPE As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDSTOCK.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = row.Cells(GSRNO.Index).Value.ToString
                        ITEMNAME = row.Cells(GITEMNAME.Index).Value.ToString
                        LOTNO = row.Cells(GLOTNO.Index).Value.ToString
                        REELNO = row.Cells(GREELNO.Index).Value.ToString
                        GSM = row.Cells(GGSM.Index).Value.ToString
                        GSMDETAILS = row.Cells(GGSMDETAILS.Index).Value.ToString
                        SIZE = row.Cells(GSIZE.Index).Value.ToString
                        QTY = row.Cells(GQTY.Index).Value
                        UNIT = row.Cells(GUNIT.Index).Value.ToString
                        BARCODE = row.Cells(GBARCODE.Index).Value.ToString
                        FROMNO = row.Cells(GFROMNO.Index).Value.ToString
                        FROMSRNO = row.Cells(GFROMSRNO.Index).Value.ToString
                        FROMTYPE = row.Cells(GFROMTYPE.Index).Value.ToString

                    Else
                        gridsrno = gridsrno & "|" & row.Cells(GSRNO.Index).Value.ToString
                        ITEMNAME = ITEMNAME & "|" & row.Cells(GITEMNAME.Index).Value.ToString
                        LOTNO = LOTNO & "|" & row.Cells(GLOTNO.Index).Value.ToString
                        REELNO = REELNO & "|" & row.Cells(GREELNO.Index).Value.ToString
                        GSM = GSM & "|" & row.Cells(GGSM.Index).Value.ToString
                        GSMDETAILS = GSMDETAILS & "|" & row.Cells(GGSMDETAILS.Index).Value.ToString
                        SIZE = SIZE & "|" & row.Cells(GSIZE.Index).Value
                        QTY = QTY & "|" & row.Cells(GQTY.Index).Value
                        UNIT = UNIT & "|" & row.Cells(GUNIT.Index).Value.ToString
                        BARCODE = BARCODE & "|" & row.Cells(GBARCODE.Index).Value.ToString
                        FROMNO = FROMNO & "|" & row.Cells(GFROMNO.Index).Value.ToString
                        FROMSRNO = FROMSRNO & "|" & row.Cells(GFROMSRNO.Index).Value.ToString
                        FROMTYPE = FROMTYPE & "|" & row.Cells(GFROMTYPE.Index).Value.ToString

                    End If
                End If
            Next

            alParaval.Add(gridsrno)
            alParaval.Add(ITEMNAME)
            alParaval.Add(LOTNO)
            alParaval.Add(REELNO)
            alParaval.Add(GSM)
            alParaval.Add(GSMDETAILS)
            alParaval.Add(SIZE)
            alParaval.Add(QTY)
            alParaval.Add(UNIT)
            alParaval.Add(BARCODE)
            alParaval.Add(FROMNO)
            alParaval.Add(FROMSRNO)
            alParaval.Add(FROMTYPE)



            Dim INGRIDSRNO As String = ""
            Dim INITEMNAME As String = ""
            Dim INLOTNO As String = ""
            Dim INREELNO As String = ""
            Dim INGSM As String = ""
            Dim INGSMDETAILS As String = ""
            Dim INSIZE As String = ""
            Dim INQTY As String = ""
            Dim INUNIT As String = ""
            Dim INBARCODE As String = ""
            Dim INDONE As String = ""
            Dim INOUTQTY As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDSTOCKIN.Rows
                If row.Cells(0).Value <> Nothing Then
                    If INGRIDSRNO = "" Then
                        INGRIDSRNO = row.Cells(EINSRNO.Index).Value.ToString
                        INITEMNAME = row.Cells(EINITEMNAME.Index).Value.ToString
                        INLOTNO = row.Cells(EINLOTNO.Index).Value.ToString
                        INREELNO = row.Cells(EINREELNO.Index).Value.ToString
                        INGSM = row.Cells(EINGSM.Index).Value.ToString
                        INGSMDETAILS = row.Cells(EINGSMDETAILS.Index).Value.ToString
                        INSIZE = row.Cells(EINSIZE.Index).Value.ToString
                        INQTY = row.Cells(EINQTY.Index).Value.ToString
                        INUNIT = row.Cells(EINUNIT.Index).Value.ToString
                        INBARCODE = row.Cells(EINBARCODE.Index).Value.ToString
                        If row.Cells(EINDONE.Index).Value = True Then
                            INDONE = 1
                        Else
                            INDONE = 0
                        End If
                        INOUTQTY = row.Cells(EINOUTQTY.Index).Value.ToString

                    Else

                        INGRIDSRNO = INGRIDSRNO & "|" & row.Cells(EINSRNO.Index).Value.ToString
                        INITEMNAME = INITEMNAME & "|" & row.Cells(EINITEMNAME.Index).Value.ToString
                        INLOTNO = INLOTNO & "|" & row.Cells(EINLOTNO.Index).Value.ToString
                        INREELNO = INREELNO & "|" & row.Cells(EINREELNO.Index).Value.ToString
                        INGSM = INGSM & "|" & row.Cells(EINGSM.Index).Value.ToString
                        INGSMDETAILS = INGSMDETAILS & "|" & row.Cells(EINGSMDETAILS.Index).Value.ToString
                        INSIZE = INSIZE & "|" & row.Cells(EINSIZE.Index).Value.ToString
                        INQTY = INQTY & "|" & row.Cells(EINQTY.Index).Value.ToString
                        INUNIT = INUNIT & "|" & row.Cells(EINUNIT.Index).Value.ToString
                        INBARCODE = INBARCODE & "|" & row.Cells(EINBARCODE.Index).Value.ToString
                        If row.Cells(EINDONE.Index).Value = True Then
                            INDONE = INDONE & "|" & "1"
                        Else
                            INDONE = INDONE & "|" & "0"
                        End If
                        INOUTQTY = INOUTQTY & "|" & row.Cells(EINOUTQTY.Index).Value.ToString

                    End If
                End If
            Next

            alParaval.Add(INGRIDSRNO)
            alParaval.Add(INITEMNAME)
            alParaval.Add(INLOTNO)
            alParaval.Add(INREELNO)
            alParaval.Add(INGSM)
            alParaval.Add(INGSMDETAILS)
            alParaval.Add(INSIZE)
            alParaval.Add(INQTY)
            alParaval.Add(INUNIT)
            alParaval.Add(INBARCODE)
            alParaval.Add(INDONE)
            alParaval.Add(INOUTQTY)

            Dim objSTOCK As New ClsStockAdjustment()
            objSTOCK.alParaval = alParaval
            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim DTTABLE As DataTable = objSTOCK.SAVE()
                MsgBox("Details Added")
                TXTRECONO.Text = DTTABLE.Rows(0).Item(0)
                TEMPRECONO = DTTABLE.Rows(0).Item(0)
                'PRINTREPORT(DTTABLE.Rows(0).Item(0))

            ElseIf EDIT = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                alParaval.Add(TEMPRECONO)
                IntResult = objSTOCK.UPDATE()
                MsgBox("Details Updated")
                'PRINTREPORT(TEMPRECONO)
                EDIT = False
            End If

            '  TEMPPROFORMANO = 0
            CLEAR()
            DTRECODATE.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub



    Sub GETSRNO(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            For Each row As DataGridViewRow In grid.Rows
                row.Cells(0).Value = row.Index + 1
            Next
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub TOTAL()
        Try

            LBLTOTALINQTY.Text = 0.0
            LBLTOTALQTY.Text = 0.0

            For Each ROW As DataGridViewRow In GRIDSTOCK.Rows
                If ROW.Cells(GSRNO.Index).Value <> Nothing Then
                    LBLTOTALQTY.Text = Format(Val(LBLTOTALQTY.Text) + Val(ROW.Cells(GQTY.Index).EditedFormattedValue), "0.00")
                Else
                    '    ROW.Cells(GAMOUNT.Index).Value = Format(Val(ROW.Cells(GRATE.Index).EditedFormattedValue) * Val(ROW.Cells(GPCS.Index).EditedFormattedValue))
                End If
                ' LBLTOTALOUTQTY.Text = Format(Val(LBLTOTALOUTQTY.Text) + Val(ROW.Cells(GAMOUNT.Index).EditedFormattedValue), "0.00")
                ' LBLAVGRATE.Text = Format(Val(LBLAVGRATE.Text) + Val(ROW.Cells(GRATE.Index).EditedFormattedValue) / GRIDSTOCK.Rows.Count, "0.00")
            Next

            For Each ROW As DataGridViewRow In GRIDSTOCKIN.Rows
                If ROW.Cells(EINSRNO.Index).Value <> Nothing Then
                    ' If ROW.Cells(GINCUT.Index).EditedFormattedValue > 0 Then ROW.Cells(GINMTRS.Index).Value = Val(ROW.Cells(GINPCS.Index).EditedFormattedValue) * Val(ROW.Cells(GINCUT.Index).EditedFormattedValue)
                    LBLTOTALINQTY.Text = Format(Val(LBLTOTALINQTY.Text) + Val(ROW.Cells(EINQTY.Index).EditedFormattedValue), "0.00")
                    '  If Val(ROW.Cells(GINRATE.Index).EditedFormattedValue) = 0 And Val(LBLAVGRATE.Text) > 0 And CHKMANUALRATE.Checked = False Then ROW.Cells(GINRATE.Index).Value = Format(Val(LBLAVGRATE.Text), "0.00")
                    '  If ROW.Cells(GINPER.Index).EditedFormattedValue = "Mtrs" Then
                    '  ROW.Cells(GINAMOUNT.Index).Value = Format(Val(ROW.Cells(GINRATE.Index).EditedFormattedValue) * Val(ROW.Cells(GINMTRS.Index).EditedFormattedValue))
                Else
                    '     ROW.Cells(GINAMOUNT.Index).Value = Format(Val(ROW.Cells(GINRATE.Index).EditedFormattedValue) * Val(ROW.Cells(GINPCS.Index).EditedFormattedValue))
                End If
                '  LBLTOTALINAMOUNT.Text = Format(Val(LBLTOTALINAMOUNT.Text) + Val(ROW.Cells(GINAMOUNT.Index).EditedFormattedValue), "0.00")
                'End If
            Next
            '   TXTMTRSDIFF.Text = Format(Val(LBLTOTALOUTMTRS.Text) - Val(LBLTOTALINREELNO.Text), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGODOWN_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBGODOWN.Enter
        Try
            If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGODOWN_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBGODOWN.Validating
        Try
            If CMBGODOWN.Text.Trim <> "" Then GODOWNVALIDATE(CMBGODOWN, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtrans.Enter
        Try
            If cmbtrans.Text.Trim = "" Then FILLNAME(cmbtrans, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'TRANSPORT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbtrans_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbtrans.Validating
        Try
            If cmbtrans.Text.Trim <> "" Then namevalidate(cmbtrans, CMBCODE, e, Me, TXTTRANSADD, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "SUNDRY CREDITORS", "TRANSPORT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMDSELECTSTOCK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSELECTSTOCK.Click
        Try
            If CMBGODOWN.Text.Trim = "" Then
                MsgBox("Please Fill Godown", MsgBoxStyle.Critical)
                CMBGODOWN.Focus()
                Exit Sub
            End If


            If (EDIT = True And USEREDIT = False And USERVIEW = False) Or (EDIT = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If


            Dim OBJSELECTPS As New SelectStock
            ' OBJSELECTPS.FRMSTRING = "PS"
            OBJSELECTPS.GODOWN = CMBGODOWN.Text.Trim
            Dim DTPO As DataTable = OBJSELECTPS.DT
            OBJSELECTPS.ShowDialog()
            If DTPO.Rows.Count > 0 Then
                For Each DTROW As DataRow In DTPO.Rows
                    GRIDSTOCK.Rows.Add(0, DTROW("ITEMNAME"), DTROW("LOTNO"), DTROW("REELNO"), Val(DTROW("GSM")), DTROW("GSMDETAILS"), Val(DTROW("SIZE")), Val(DTROW("QTY")), DTROW("UNIT"), DTROW("BARCODE"), DTROW("FROMNO"), DTROW("FROMSRNO"), DTROW("FROMTYPE"))
NEXTLINE:
                    If CHKCOPY.Checked = True Then GRIDSTOCKIN.Rows.Add(0, DTROW("ITEMNAME"), DTROW("LOTNO"), DTROW("REELNO"), Val(DTROW("GSM")), DTROW("GSMDETAILS"), Val(DTROW("SIZE")), Val(DTROW("QTY")), DTROW("UNIT"), "", 0, 0)

                Next
                GETSRNO(GRIDSTOCK)
                GETSRNO(GRIDSTOCKIN)
                TOTAL()

            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub toolprevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolprevious.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Cursor.Current = Cursors.WaitCursor
            GRIDSTOCK.RowCount = 0
            GRIDSTOCKIN.RowCount = 0
LINE1:
            TEMPRECONO = Val(TXTRECONO.Text) - 1
            If TEMPRECONO > 0 Then
                EDIT = True
                StockReco_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
                TEMPPROFORMANO = 0
            End If
            If GRIDSTOCK.RowCount = 0 And GRIDSTOCKIN.RowCount = 0 And TEMPRECONO > 1 Then
                TXTRECONO.Text = TEMPRECONO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolnext.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
LINE1:
            TEMPRECONO = Val(TXTRECONO.Text) + 1
            getmaxno()
            Dim MAXNO As Integer = TXTRECONO.Text.Trim
            CLEAR()
            If Val(TXTRECONO.Text) - 1 >= TEMPRECONO Then
                EDIT = True
                StockReco_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
                TEMPPROFORMANO = 0
            End If
            If GRIDSTOCK.RowCount = 0 And GRIDSTOCKIN.RowCount = 0 And TEMPRECONO < MAXNO Then
                TXTRECONO.Text = TEMPRECONO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                GRIDSTOCK.RowCount = 0
                GRIDSTOCKIN.RowCount = 0
                TEMPRECONO = Val(tstxtbillno.Text)
                If TEMPRECONO > 0 Then
                    EDIT = True
                    StockReco_Load(sender, e)
                Else
                    CLEAR()
                    EDIT = False
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub FILLGRID()
        Try
            GRIDSTOCKIN.Enabled = True

            If GRIDDOUBLECLICK = False Then
                GRIDSTOCKIN.Rows.Add(Val(txtsrno.Text.Trim), CMBINITEMNAME.Text.Trim, TXTINLOTNO.Text.Trim, TXTINREELNO.Text.Trim, TXTINGSM.Text.Trim, TXTINGSMDETAILS.Text.Trim, TXTINSIZE.Text.Trim, TXTINQTY.Text.Trim, CMBINUNIT.Text.Trim, TXTINBARCODE.Text.Trim, 0, 0)
                GETSRNO(GRIDSTOCKIN)

            ElseIf GRIDDOUBLECLICK = True Then

                GRIDSTOCKIN.Item(EINSRNO.Index, TEMPROW).Value = Val(txtsrno.Text.Trim)
                GRIDSTOCKIN.Item(EINITEMNAME.Index, TEMPROW).Value = CMBINITEMNAME.Text.Trim
                GRIDSTOCKIN.Item(EINLOTNO.Index, TEMPROW).Value = TXTINLOTNO.Text.Trim
                GRIDSTOCKIN.Item(EINREELNO.Index, TEMPROW).Value = TXTINREELNO.Text.Trim
                GRIDSTOCKIN.Item(EINGSM.Index, TEMPROW).Value = TXTINGSM.Text.Trim
                GRIDSTOCKIN.Item(EINGSMDETAILS.Index, TEMPROW).Value = TXTINGSMDETAILS.Text.Trim
                GRIDSTOCKIN.Item(EINSIZE.Index, TEMPROW).Value = TXTINSIZE.Text.Trim
                GRIDSTOCKIN.Item(EINQTY.Index, TEMPROW).Value = TXTINQTY.Text.Trim
                GRIDSTOCKIN.Item(EINUNIT.Index, TEMPROW).Value = CMBINUNIT.Text.Trim


                GRIDDOUBLECLICK = False
            End If

            TOTAL()

            GRIDSTOCKIN.FirstDisplayedScrollingRowIndex = GRIDSTOCKIN.RowCount - 1

            txtsrno.Text = GRIDSTOCKIN.RowCount + 1
            CMBINITEMNAME.Text = ""
            CMBINUNIT.Text = ""
            TXTINGSMDETAILS.Clear()
            TXTINGSM.Clear()
            TXTINSIZE.Clear()
            TXTINREELNO.Clear()
            TXTINLOTNO.Clear()
            TXTINQTY.Clear()

            CMBINITEMNAME.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDSTOCKIN_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDSTOCKIN.CellDoubleClick
        EDITROW()
    End Sub

    Sub EDITROW()
        Try
            If GRIDSTOCKIN.CurrentRow.Index >= 0 And GRIDSTOCKIN.Item(GSRNO.Index, GRIDSTOCKIN.CurrentRow.Index).Value <> Nothing Then

                GRIDDOUBLECLICK = True
                txtsrno.Text = GRIDSTOCKIN.Item(EINSRNO.Index, GRIDSTOCKIN.CurrentRow.Index).Value.ToString
                CMBINITEMNAME.Text = GRIDSTOCKIN.Item(EINITEMNAME.Index, GRIDSTOCKIN.CurrentRow.Index).Value.ToString
                TXTINLOTNO.Text = GRIDSTOCKIN.Item(EINLOTNO.Index, GRIDSTOCKIN.CurrentRow.Index).Value.ToString
                TXTINREELNO.Text = GRIDSTOCKIN.Item(EINREELNO.Index, GRIDSTOCKIN.CurrentRow.Index).Value.ToString
                TXTINGSM.Text = GRIDSTOCKIN.Item(EINGSM.Index, GRIDSTOCKIN.CurrentRow.Index).Value.ToString
                TXTINGSMDETAILS.Text = GRIDSTOCKIN.Item(EINGSMDETAILS.Index, GRIDSTOCKIN.CurrentRow.Index).Value.ToString
                TXTINSIZE.Text = GRIDSTOCKIN.Item(EINSIZE.Index, GRIDSTOCKIN.CurrentRow.Index).Value.ToString
                TXTINQTY.Text = GRIDSTOCKIN.Item(EINQTY.Index, GRIDSTOCKIN.CurrentRow.Index).Value.ToString
                CMBINUNIT.Text = GRIDSTOCKIN.Item(EINUNIT.Index, GRIDSTOCKIN.CurrentRow.Index).Value.ToString

                TEMPROW = GRIDSTOCKIN.CurrentRow.Index
                txtsrno.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub txtqty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTINSIZE.KeyPress, TXTINGSM.KeyPress, TXTINREELNO.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub TXTMTRS_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTINQTY.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    'Private Sub TXTBARCODE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTBARCODE.Validating
    '    Try
    '        If TXTBARCODE.Text.Trim <> "" And CHECKBARCODEERRORVALID = True Then
    '            'CHECKING WHETHER IS IS GONE OUT OR NOT
    '            Dim OBJCMN As New ClsCommon
    '            Dim DT As DataTable = OBJCMN.SEARCH("TOP 1 TYPE, FROMNO", "", " OUTBARCODESTOCK ", " AND BARCODE = '" & TXTBARCODE.Text.Trim & "' AND CMPID = " & CmpId & " AND LOCATIONID = " & Locationid & " AND YEARID = " & YearId)
    '            If DT.Rows.Count > 0 Then
    '                MsgBox("Barcode Already Used in " & DT.Rows(0).Item("TYPE") & " Sr No " & DT.Rows(0).Item("FROMNO"))
    '                TXTBARCODE.Clear()
    '                e.Cancel = True
    '                'Else
    '                '    MsgBox("Invalid Barcode", MsgBoxStyle.Critical)
    '            End If
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Private Sub GRIDSTOCK_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles GRIDSTOCK.CellValidating
        Try
            Dim colNum As Integer = GRIDSTOCK.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            Select Case colNum

                Case GQTY.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If GRIDSTOCK.CurrentCell.Value = Nothing Then GRIDSTOCK.CurrentCell.Value = "0.00"
                        GRIDSTOCK.CurrentCell.Value = Convert.ToDecimal(GRIDSTOCK.Item(colNum, e.RowIndex).Value)
                        '' everything is good
                        TOTAL()
                    Else
                        MessageBox.Show("Invalid Number Entered")
                        e.Cancel = True
                        Exit Sub
                    End If

            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDSTOCK_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDSTOCK.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDSTOCK.RowCount > 0 Then
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                GRIDSTOCK.Rows.RemoveAt(GRIDSTOCK.CurrentRow.Index)
                GETSRNO(GRIDSTOCK)
                TOTAL()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If EDIT = True Then
                If MsgBox("Wish to Delete Stock Adjustment?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

                If lbllocked.Visible = True Then
                    MsgBox("Entry Locked", MsgBoxStyle.Critical)
                    Exit Sub
                End If


                Dim ALPARAVAL As New ArrayList
                Dim OBSTOCK As New ClsStockAdjustment

                ALPARAVAL.Add(TEMPRECONO)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(Userid)
                ALPARAVAL.Add(YearId)
                OBSTOCK.alParaval = ALPARAVAL
                Dim INTRES As Integer = OBSTOCK.DELETE()
                MsgBox("Stock Adjustment Deleted Succesfully")
                CLEAR()
                EDIT = False
                DTRECODATE.Focus()
                TEMPPROFORMANO = 0
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbqtyunit_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBINUNIT.Validating
        Try
            If CMBINUNIT.Text.Trim <> "" Then unitvalidate(CMBINUNIT, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GRIDJOBIN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDSTOCKIN.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDSTOCKIN.RowCount > 0 Then
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If

                'end of block
                GRIDSTOCKIN.Rows.RemoveAt(GRIDSTOCKIN.CurrentRow.Index)
                GETSRNO(GRIDSTOCKIN)
                TOTAL()
            ElseIf e.KeyCode = Keys.F5 Then
                EDITROW()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBINITEMNAME.Enter
        Try
            If CMBINITEMNAME.Text.Trim = "" Then FILLITEMNAME(CMBINITEMNAME, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbitemname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBINITEMNAME.Validating
        Try
            If CMBINITEMNAME.Text.Trim <> "" Then ITEMVALIDATE(CMBINITEMNAME, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'", "MERCHANT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTCUT_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTINGSM.Validated, TXTINQTY.Validated, TXTINSIZE.Validated
        CALC()
    End Sub

    Sub CALC()
        Try
            'If Val(txtqty.Text.Trim) > 0 And Val(TXTINGSM.Text.Trim) > 0 Then TXTMTRS.Text = Format(Val(txtqty.Text.Trim) * Val(TXTINGSM.Text.Trim), "0.00")
            '   If CMBPER.Text = "Mtrs" Then TXTAMOUNT.Text = Format(Val(TXTINSIZE.Text.Trim) * Val(TXTMTRS.Text.Trim), "0.00") Else TXTAMOUNT.Text = Format(Val(TXTINSIZE.Text.Trim) * Val(txtqty.Text.Trim), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDESIGN_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            '    If CMBDESIGN.Text.Trim = "" Then FILLDESIGN(CMBDESIGN, cmbitemname.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtremarks_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtremarks.KeyDown
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

    Private Sub cmbitemname_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBINITEMNAME.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJItem As New SelectItem
                OBJItem.FRMSTRING = "MERCHANT"
                OBJItem.STRSEARCH = " and ITEM_YEARid = " & YearId
                OBJItem.ShowDialog()
                If OBJItem.TEMPNAME <> "" Then CMBINITEMNAME.Text = OBJItem.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        Try

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim OBJstock As New StockRecoDetails
            OBJstock.MdiParent = MDIMain
            OBJstock.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(sender As Object, e As EventArgs) Handles PrintToolStripButton.Click
        Try
            If EDIT = True Then
                PRINTREPORT()
                ' If GRIDSTOCKIN.RowCount > 0 Then PRINTBARCODE()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PRINTREPORT()
        'Try
        '    If MsgBox("Wish to Print Entry?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
        '    Dim OBJSA As New SaleOrderDesign
        '    OBJSA.MdiParent = MDIMain
        '    OBJSA.FORMULA = "{STOCKADJUSTMENT.SA_NO} = " & Val(TXTRECONO.Text.Trim) & " AND {STOCKADJUSTMENT.SA_YEARID} = " & YearId
        '    OBJSA.FRMSTRING = "STOCKRECO"
        '    OBJSA.Show()
        'Catch ex As Exception
        '    Throw ex
        'End Try
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        Try
            Call cmdok_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tooldelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tooldelete.Click
        Try
            Call cmddelete_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub




    'Private Sub cmbitemname_Validated(sender As Object, e As EventArgs) Handles cmbitemname.Validated
    '    Try
    '        'GET CATEGORY
    '        Dim OBJCMN As New ClsCommon
    '        Dim DT As DataTable = OBJCMN.SEARCH("ISNULL(CATEGORY_NAME,'') AS CATEGORY", "", " ITEMMASTER LEFT OUTER JOIN CATEGORYMASTER ON ITEM_CATEGORYID = CATEGORY_ID", " AND ITEM_NAME = '" & cmbitemname.Text.Trim & "' AND ITEM_YEARID = " & YearId)
    '        If DT.Rows.Count > 0 Then
    '            LBLCATEGORY.Text = DT.Rows(0).Item("CATEGORY")
    '        End If

    '        If cmbitemname.Text.Trim <> "" And EDIT = False Then
    '            'GET DISPLAY NAME IN GRIDREMARKS
    '            If ClientName = "RAJKRIPA" Then
    '                DT = OBJCMN.SEARCH(" ISNULL(ITEMMASTER.ITEM_NAME, '') AS DISPLAYNAME", "", " ITEMMASTER ", " AND ITEMMASTER.ITEM_NAME = '" & cmbitemname.Text.Trim & "' AND ITEMMASTER.ITEM_YEARID = " & YearId)
    '                If DT.Rows.Count > 0 Then
    '                    For Each DTROW As DataRow In DT.Rows
    '                        TXTINGSMDETAILS.Text = (DT.Rows(0).Item("DISPLAYNAME"))
    '                    Next
    '                End If
    '            End If
    '        End If


    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Private Sub tstxtbillno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tstxtbillno.KeyPress, TXTFROM.KeyPress, TXTTO.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub TXTBARCODE_Validated(sender As Object, e As EventArgs) Handles TXTBARCODE.Validated
        Try
            If TXTBARCODE.Text.Trim.Length > 0 Then

                Dim OBJCMN As New ClsCommon
                Dim DT As New DataTable


                If CMBGODOWN.Text.Trim = "" Then
                    MsgBox("Select Godown First", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                'GET DATA FROM BARCODE
                DT = OBJCMN.SEARCH("TOP 1 *", "", "BARCODESTOCK", " AND BARCODE = '" & TXTBARCODE.Text.Trim & "' AND DONE = 0 AND CMPID = " & CmpId & " AND LOCATIONID  = " & Locationid & " AND YEARID = " & YearId)
                If DT.Rows.Count > 0 Then

                    'VALIDATE GODOWN
                    If DT.Rows(0).Item("GODOWN") <> CMBGODOWN.Text.Trim Then
                        MsgBox("Item Not in Selected Godown", MsgBoxStyle.Critical)
                        TXTBARCODE.Clear()
                        Exit Sub
                    End If

                    'CHECK WHETHER BARCODE IS ALREADY PRESENT IN GRID OR NOT
                    For Each ROW As DataGridViewRow In GRIDSTOCK.Rows
                        If LCase(ROW.Cells(GBARCODE.Index).Value) = LCase(TXTBARCODE.Text.Trim) Then GoTo LINE1
                    Next

                    Dim PCS As Double = 0
                    If ClientName = "TCOT" Then PCS = Val(DT.Rows(0).Item("PCS")) Else PCS = 1
                    If ClientName = "SAKARIA" Or ClientName = "CC" Or ClientName = "C3" Then CMBNAME.Text = DT.Rows(0).Item("PURNAME")

                    GRIDSTOCK.Rows.Add(GRIDSTOCK.RowCount + 1, DT.Rows(0).Item("PIECETYPE"), DT.Rows(0).Item("ITEMNAME"), DT.Rows(0).Item("QUALITY"), DT.Rows(0).Item("DESIGNNO"), DT.Rows(0).Item("COLOR"), PCS, DT.Rows(0).Item("UNIT"), Format(Val(DT.Rows(0).Item("MTRS")), "0.00"), Format(Val(DT.Rows(0).Item("PURRATE")), "0.00"), "Mtrs", 0, DT.Rows(0).Item("BARCODE"), DT.Rows(0).Item("FROMNO"), DT.Rows(0).Item("FROMSRNO"), DT.Rows(0).Item("TYPE"))
                    If CHKYARDMTR.Checked = True And CHKCOPY.Checked = True Then
                        DT.Rows(0).Item("MTRS") = Format(Val(DT.Rows(0).Item("MTRS")) * 0.9144, "0.00")
                        DT.Rows(0).Item("UNIT") = "Mtrs"
                    End If
                    If CHKCOPY.Checked = True Then GRIDSTOCKIN.Rows.Add(GRIDSTOCKIN.RowCount + 1, DT.Rows(0).Item("PIECETYPE"), DT.Rows(0).Item("ITEMNAME"), DT.Rows(0).Item("QUALITY"), DT.Rows(0).Item("BALENO"), "", "", DT.Rows(0).Item("DESIGNNO"), DT.Rows(0).Item("COLOR"), 0, PCS, DT.Rows(0).Item("UNIT"), Format(Val(DT.Rows(0).Item("MTRS")), "0.00"), Format(Val(DT.Rows(0).Item("PURRATE")), "0.00"), "Mtrs", 0, "", "", "", 0, 0, 0)
                    TOTAL()
LINE1:
                    TXTBARCODE.Clear()
                    TXTBARCODE.Focus()
                    'Else
                    '    MsgBox("Invalid Barcode / Barcode already Used", MsgBoxStyle.Critical)
                    '    GoTo LINE1
                    '    Exit Sub


                    'CHANGES AS PER REQUOREMENT
                    'If ClientName = "AVIS" Or ClientName = "RMANILAL" Or ClientName = "SUPRIYA" And GRIDSTOCK.RowCount > 0 Then
                    '    CMBPIECETYPE.Text = GRIDSTOCK.Rows(0).Cells(GPIECETYPE.Index).Value
                    '    cmbitemname.Text = GRIDSTOCK.Rows(0).Cells(GMERCHANT.Index).Value
                    '    CMBQUALITY.Text = GRIDSTOCK.Rows(0).Cells(GQUALITY.Index).Value
                    '    CMBDESIGN.Text = GRIDSTOCK.Rows(0).Cells(GDESIGN.Index).Value
                    '    cmbcolor.Text = GRIDSTOCK.Rows(0).Cells(GCOLOR.Index).Value

                    '    TXTMTRS.Text = Val(LBLTOTALOUTMTRS.Text.Trim)
                    '    TXTINSIZE.Text = Val(LBLAVGRATE.Text.Trim)
                    '    TXTINREELNO.Clear()
                    '    For Each ROW As DataGridViewRow In GRIDSTOCK.Rows
                    '        If TXTINREELNO.Text = "" Then
                    '            TXTINREELNO.Text = "(" & Val(ROW.Cells(GMTRS.Index).Value)
                    '        Else
                    '            TXTINREELNO.Text = TXTINREELNO.Text & " + " & Val(ROW.Cells(GMTRS.Index).Value)
                    '        End If
                    '    Next
                    '    If TXTINREELNO.Text.Trim <> "" Then TXTINREELNO.Text = TXTINREELNO.Text & ")"
                    'End If

                Else
                    MsgBox("Invalid Barcode", MsgBoxStyle.Critical)
                    TXTBARCODE.Clear()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub TXTCHNO_KeyPress(sender As Object, e As KeyPressEventArgs)
        numkeypress(e, sender, Me)
    End Sub

    Private Sub CMBNAME_Enter(sender As Object, e As EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then FILLNAME(CMBNAME, EDIT, " AND (GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' OR GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS') AND LEDGERS.ACC_TYPE='ACCOUNTS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Validating(sender As Object, e As CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, CMBCODE, e, Me, TXTTRANSADD, " AND (GROUPMASTER.GROUP_SECONDARY ='SUNDRY CREDITORS' OR GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS') AND LEDGERS.ACC_TYPE='ACCOUNTS'", "", "ACCOUNTS")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbqtyunit_Enter(sender As Object, e As EventArgs) Handles CMBINUNIT.Enter
        Try
            If CMBINUNIT.Text.Trim = "" Then FILLUNIT(CMBINUNIT)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTRECONO_Validating(sender As Object, e As CancelEventArgs) Handles TXTRECONO.Validating
        Try
            If Val(TXTRECONO.Text.Trim) <> 0 And EDIT = False Then
                Dim OBJCMN As New ClsCommon
                Dim dttable As DataTable = OBJCMN.SEARCH(" ISNULL(STOCKADJUSTMENT.SA_NO,0)  AS RECONO", "", " STOCKADJUSTMENT ", "  AND STOCKADJUSTMENT.SA_NO=" & Val(TXTRECONO.Text.Trim) & " AND STOCKADJUSTMENT.SA_YEARID = " & YearId)
                If dttable.Rows.Count > 0 Then
                    MsgBox("Rec No Already Exist")
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTRECONO_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTRECONO.KeyPress, tstxtbillno.KeyPress
        numkeypress(e, sender, Me)
    End Sub



    Private Sub GRIDSTOCKIN_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles GRIDSTOCKIN.CellValidating
        Try
            'Dim colNum As Integer = GRIDSTOCKIN.Columns(e.ColumnIndex).Index
            'If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            'Select Case colNum

            '    Case GINRATE.Index
            '        Dim dDebit As Decimal
            '        Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

            '        If bValid Then
            '            If GRIDSTOCKIN.CurrentCell.Value = Nothing Then GRIDSTOCKIN.CurrentCell.Value = "0.00"
            '            GRIDSTOCKIN.CurrentCell.Value = Convert.ToDecimal(GRIDSTOCKIN.Item(colNum, e.RowIndex).Value)
            '            '' everything is good
            '            TOTAL()
            '        Else
            '            MessageBox.Show("Invalid Number Entered")
            '            e.Cancel = True
            '            Exit Sub
            '        End If

            'End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBINUNIT_Validated(sender As Object, e As EventArgs) Handles CMBINUNIT.Validated
        Try
            If CMBINITEMNAME.Text.Trim <> "" And Val(TXTINQTY.Text.Trim) > 0 And CMBINUNIT.Text.Trim <> "" Then
                FILLGRID()
            Else
                MsgBox("Enter Proper Details", MsgBoxStyle.Critical)
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class