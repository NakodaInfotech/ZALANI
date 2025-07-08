
Imports System.ComponentModel
Imports BL

Public Class GRN

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean
    Dim GRIDDOUBLECLICK, gridUPLOADDoubleClick As Boolean
    Dim TEMPROW, PURREGID As Integer
    Dim TEMPPARTYBILLNO, TEMPFORM As String
    Public EDIT As Boolean
    Public TEMPGRNNO, TEMPREGNAME As String
    Public frmstring As String
    Dim PURREGABBR, PURREGINITIAL As String
    Dim tempUPLOADrow As Integer

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Sub CLEAR()
        CMBNAME.Text = ""
        CMBGODOWN.Text = ""
        CMBUNIT.Text = ""
        CMBQUALITY.Text = ""
        GRNDATE.Text = Now.Date
        DTPODATE.Value = Mydate
        CHALLANDATE.Text = Now.Date
        TXTLOTNO.Clear()
        txtremarks.Clear()
        TXTPARTYREFNO.Clear()
        TXTREELNO.Clear()
        TXTPONO.Clear()
        TXTCHALLANNO.Clear()
        GRIDGRN.RowCount = 0
        GRIDORDER.RowCount = 0
        GRIDDOUBLECLICK = False
        gridUPLOADDoubleClick = False
        CMBNAME.Enabled = True
        CMDSELECTPO.Enabled = True
        LBLTOTALQTY.Text = 0.0
        LBLTOTALREELNO.Text = 0.0
        TXTSRNO.Text = 1
        txtsize.Clear()
        TXTGSM.Clear()
        TXTGSMDETAILS.Clear()
        TXTQTY.Clear()
        GETMAX_GRN_NO()
        Ep.Clear()
        lbllocked.Visible = False
        PBlock.Visible = False
        tstxtbillno.Clear()
        GRIDORDER.RowCount = 0

    End Sub

    Sub GETMAX_GRN_NO()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(GRN_no),0) + 1 ", " GRN ", " AND GRN_YEARID = " & YearId)
        If DTTABLE.Rows.Count > 0 Then
            TXTGRNNO.Text = DTTABLE.Rows(0).Item(0)
        End If
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        CLEAR()
        EDIT = False
        CMBNAME.Focus()
    End Sub

    Private Sub GRN_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                If ERRORVALID() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.KeyCode = Keys.F8 Then
                GRIDGRN.Focus()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.D1) Then       'for CLEAR
                TabControl1.SelectedIndex = (0)
            ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.D2) Then       'for CLEAR
                TabControl1.SelectedIndex = (1)
            ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for billno foucs
                tstxtbillno.Focus()
            ElseIf e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            ElseIf e.KeyCode = Keys.Left And e.Alt = True Then
                Call toolprevious_Click(sender, e)
            ElseIf e.KeyCode = Keys.Right And e.Alt = True Then
                Call toolnext_Click(sender, e)
            ElseIf e.KeyCode = Windows.Forms.Keys.F1 And e.Alt = True Then
                Call OpenToolStripButton_Click(sender, e)
            End If

        Catch ex As Exception
            Throw ex
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

    Private Sub GRN_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'GRN'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            Cursor.Current = Cursors.WaitCursor

            FILLCMB()
            CLEAR()
            If USERGODOWN <> "" Then CMBGODOWN.Text = USERGODOWN Else CMBGODOWN.Text = ""

            If EDIT = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim DT As DataTable
                Dim ALPARAVAL As New ArrayList
                Dim OBJGRN As New ClsGRN

                ALPARAVAL.Add(TEMPGRNNO)
                ALPARAVAL.Add(YearId)

                OBJGRN.alParaval = ALPARAVAL
                DT = OBJGRN.selectGRN()

                If DT.Rows.Count > 0 Then
                    For Each DR As DataRow In DT.Rows

                        TXTGRNNO.Text = TEMPGRNNO
                        GRNDATE.Text = Format(Convert.ToDateTime(DR("GRNDATE")).Date, "dd/MM/yyyy")
                        CMBNAME.Text = Convert.ToString(DR("NAME"))
                        CMBGODOWN.Text = DT.Rows(0).Item("GODOWN")
                        TXTPONO.Text = DT.Rows(0).Item("PONO")
                        DTPODATE.Value = DT.Rows(0).Item("PODATE")
                        TXTCHALLANNO.Text = DT.Rows(0).Item("CHALLANNO")
                        CHALLANDATE.Text = Format(Convert.ToDateTime(DR("CHALLANDATE")).Date, "dd/MM/yyyy")
                        LBLTOTALQTY.Text = DT.Rows(0).Item("TOTALQTY")
                        txtremarks.Text = DT.Rows(0).Item("REMARKS")
                        TXTPARTYREFNO.Text = DR("PARTYREFNO")

                        'Item Grid
                        GRIDGRN.Rows.Add(DR("SRNO").ToString, DR("QUALITY").ToString, DR("LOTNO"), DR("REELNO"), DR("GSM"), DR("GSMDETAILS"), DR("SIZE"), Format(DR("qty"), "0.00"), DR("UNIT"), DR("DONE"), Format(DR("OUTQTY"), "0.00"), DR("CHECKDONE"))

                        If Convert.ToBoolean(DR("CHECKDONE")) = True Or Val(DR("OUTQTY")) > 0 Then
                            GRIDGRN.Rows(GRIDGRN.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If

                    Next
                    'ORDER GRID
                    Dim OBJCMN As New ClsCommon
                    DT = OBJCMN.SEARCH(" ISNULL(ITEMMASTER.ITEM_NAME, '') AS QUALITY, ISNULL(GRN_PODETAILS.GRN_GRIDSRNO, 0) AS GRIDSRNO, ISNULL(GRN_PODETAILS.GRN_GSM, '') AS GSM, ISNULL(GRN_PODETAILS.GRN_SIZE, '') AS SIZE, ISNULL(GRN_PODETAILS.GRN_QTY, 0) AS QTY, ISNULL(GRN_PODETAILS.GRN_PONO, '') AS PONO, ISNULL(GRN_PODETAILS.GRN_POSRNO, 0) AS POSRNO, ISNULL(GRN_PODETAILS.GRN_POTYPE, '') AS POTYPE, ISNULL(GRN_PODETAILS.GRN_GRNQTY, 0) AS GRNQTY, ISNULL(GRN_PODETAILS.GRN_RATE, 0) AS RATE ", "", " GRN_PODETAILS LEFT OUTER JOIN ITEMMASTER ON GRN_PODETAILS.GRN_QUALITYID = ITEMMASTER.item_id", " AND GRN_PODETAILS.GRN_NO = " & TEMPGRNNO & " AND  GRN_PODETAILS.GRN_YEARID = " & YearId)
                    If DT.Rows.Count > 0 Then
                        For Each DTR As DataRow In DT.Rows
                            GRIDORDER.Rows.Add(Val(DTR("GRIDSRNO")), DTR("QUALITY"), DTR("GSM"), DTR("SIZE"), Val(DTR("QTY")), DTR("PONO"), Val(DTR("POSRNO")), DTR("POTYPE"), Val(DTR("RATE")), Val(DTR("GRNQTY")))
                        Next
                    End If
                    getsrno(GRIDORDER)

                    GRIDGRN.FirstDisplayedScrollingRowIndex = GRIDGRN.RowCount - 1
                End If
                CMDSELECTPO.Enabled = False
                CMBNAME.Enabled = False
                TOTAL()


            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.WaitCursor
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Dim IntResult As Integer
        Try
            Cursor.Current = Cursors.WaitCursor
            Ep.Clear()
            If Not ERRORVALID() Then
                Exit Sub
            End If

            Dim ALPARAVAL As New ArrayList

            ALPARAVAL.Add(Format(Convert.ToDateTime(GRNDATE.Text).Date, "MM/dd/yyyy"))
            ALPARAVAL.Add(CMBNAME.Text.Trim)
            ALPARAVAL.Add(TXTPONO.Text.Trim)
            ALPARAVAL.Add(DTPODATE.Value.Date)
            ALPARAVAL.Add(TXTPARTYREFNO.Text.Trim)
            ALPARAVAL.Add(TXTCHALLANNO.Text.Trim)
            ALPARAVAL.Add(CMBGODOWN.Text.Trim)
            ALPARAVAL.Add(Format(Convert.ToDateTime(CHALLANDATE.Text).Date, "MM/dd/yyyy"))
            ALPARAVAL.Add(Val(LBLTOTALQTY.Text.Trim))
            ALPARAVAL.Add(Val(LBLTOTALREELNO.Text.Trim))
            ALPARAVAL.Add(txtremarks.Text.Trim)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)

            '' GRID PARAMETERS
            Dim SRNO As String = ""
            Dim QUALITY As String = ""
            Dim LOTNO As String = ""
            Dim REELNO As String = ""
            Dim GSM As String = ""
            Dim GSMDETAILS As String = ""
            Dim SIZE As String = ""
            Dim QTY As String = ""
            Dim UNIT As String = ""
            Dim OUTQTY As String = ""
            Dim CHECKDONE As String = ""

            For Each ROW As Windows.Forms.DataGridViewRow In GRIDGRN.Rows
                If ROW.Cells(0).Value <> Nothing Then
                    If SRNO = "" Then
                        SRNO = ROW.Cells(gsrno.Index).Value
                        QUALITY = ROW.Cells(GQUALITY.Index).Value.ToString
                        LOTNO = ROW.Cells(GLOTNO.Index).Value.ToString
                        REELNO = ROW.Cells(GREELNO.Index).Value.ToString
                        GSM = ROW.Cells(gGSM.Index).Value.ToString
                        GSMDETAILS = ROW.Cells(GGSMDETAILS.Index).Value.ToString
                        SIZE = ROW.Cells(Gsize.Index).Value.ToString
                        QTY = Val(ROW.Cells(GQTY.Index).Value)
                        UNIT = ROW.Cells(GUNIT.Index).Value.ToString
                        OUTQTY = Val(ROW.Cells(GOUTQTY.Index).Value)
                        If ROW.Cells(GCHECKDONE.Index).Value = True Then
                            CHECKDONE = 1
                        Else
                            CHECKDONE = 0
                        End If
                    Else
                        SRNO = SRNO & "|" & ROW.Cells(gsrno.Index).Value
                        QUALITY = QUALITY & "|" & ROW.Cells(GQUALITY.Index).Value.ToString
                        LOTNO = LOTNO & "|" & ROW.Cells(GLOTNO.Index).Value.ToString
                        REELNO = REELNO & "|" & ROW.Cells(GREELNO.Index).Value.ToString
                        GSM = GSM & "|" & ROW.Cells(gGSM.Index).Value.ToString
                        GSMDETAILS = GSMDETAILS & "|" & ROW.Cells(GGSMDETAILS.Index).Value.ToString
                        SIZE = SIZE & "|" & ROW.Cells(Gsize.Index).Value.ToString
                        QTY = QTY & "|" & Val(ROW.Cells(GQTY.Index).Value)
                        UNIT = UNIT & "|" & ROW.Cells(GUNIT.Index).Value.ToString
                        OUTQTY = OUTQTY & "|" & Val(ROW.Cells(GOUTQTY.Index).Value)
                        If ROW.Cells(GCHECKDONE.Index).Value = True Then
                            CHECKDONE = CHECKDONE & "|" & "1"
                        Else
                            CHECKDONE = CHECKDONE & "|" & "0"
                        End If
                    End If
                End If
            Next
            ALPARAVAL.Add(SRNO)
            ALPARAVAL.Add(QUALITY)
            ALPARAVAL.Add(LOTNO)
            ALPARAVAL.Add(REELNO)
            ALPARAVAL.Add(GSM)
            ALPARAVAL.Add(GSMDETAILS)
            ALPARAVAL.Add(SIZE)
            ALPARAVAL.Add(QTY)
            ALPARAVAL.Add(UNIT)
            ALPARAVAL.Add(OUTQTY)
            ALPARAVAL.Add(CHECKDONE)

            Dim ORDERGRIDSRNO As String = ""
            Dim ORDERQUALITY As String = ""
            Dim ORDERGSM As String = ""
            Dim ORDERSIZE As String = ""
            Dim ORDERQTY As String = ""
            Dim ORDERPONO As String = ""
            Dim ORDERPOSRNO As String = ""
            Dim ORDERPOTYPE As String = ""
            Dim ORDERGRNQTY As String = ""
            Dim ORDERRATE As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDORDER.Rows
                If row.Cells(OGRNQTY.Index).Value <> Nothing Then
                    If ORDERGRIDSRNO = "" Then
                        ORDERGRIDSRNO = row.Cells(OSRNO.Index).Value
                        ORDERQUALITY = row.Cells(OQUALITY.Index).Value.ToString
                        ORDERGSM = row.Cells(OGSM.Index).Value.ToString
                        ORDERSIZE = row.Cells(OSIZE.Index).Value.ToString
                        ORDERQTY = Val(row.Cells(OQTY.Index).Value)
                        ORDERPONO = row.Cells(OPONO.Index).Value
                        ORDERPOSRNO = row.Cells(OPOSRNO.Index).Value
                        ORDERPOTYPE = row.Cells(OPOTYPE.Index).Value.ToString
                        ORDERGRNQTY = Val(row.Cells(OGRNQTY.Index).Value)
                        ORDERRATE = Val(row.Cells(ORATE.Index).Value)

                    Else

                        ORDERGRIDSRNO = ORDERGRIDSRNO & "|" & row.Cells(OSRNO.Index).Value
                        ORDERQUALITY = ORDERQUALITY & "|" & row.Cells(OQUALITY.Index).Value.ToString
                        ORDERGSM = ORDERGSM & "|" & row.Cells(OGSM.Index).Value.ToString
                        ORDERSIZE = ORDERSIZE & "|" & row.Cells(OSIZE.Index).Value.ToString
                        ORDERQTY = ORDERQTY & "|" & Val(row.Cells(OQTY.Index).Value)
                        ORDERPONO = ORDERPONO & "|" & row.Cells(OPONO.Index).Value
                        ORDERPOSRNO = ORDERPOSRNO & "|" & row.Cells(OPOSRNO.Index).Value
                        ORDERPOTYPE = ORDERPOTYPE & "|" & row.Cells(OPOTYPE.Index).Value.ToString
                        ORDERGRNQTY = ORDERGRNQTY & "|" & Val(row.Cells(OGRNQTY.Index).Value)
                        ORDERRATE = ORDERRATE & "|" & Val(row.Cells(ORATE.Index).Value)

                    End If
                End If
            Next

            ALPARAVAL.Add(ORDERGRIDSRNO)
            ALPARAVAL.Add(ORDERQUALITY)
            ALPARAVAL.Add(ORDERGSM)
            ALPARAVAL.Add(ORDERSIZE)
            ALPARAVAL.Add(ORDERQTY)
            ALPARAVAL.Add(ORDERPONO)
            ALPARAVAL.Add(ORDERPOSRNO)
            ALPARAVAL.Add(ORDERPOTYPE)
            ALPARAVAL.Add(ORDERGRNQTY)
            ALPARAVAL.Add(ORDERRATE)

            Dim OBJGRN As New ClsGRN
            OBJGRN.alParaval = ALPARAVAL

            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim DTTABLE As DataTable = OBJGRN.SAVE()
                MsgBox("Details Added !!")
                TEMPGRNNO = DTTABLE.Rows(0).Item(0)
            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                ALPARAVAL.Add(TEMPGRNNO)
                IntResult = OBJGRN.UPDATE()
                MsgBox("Details Updated")
                EDIT = False
            End If
            'PRINTREPORT(TEMPGRNNO)

            CLEAR()
            CMBNAME.Focus()
            getsrno(GRIDGRN)
            CMDSELECTPO.Enabled = True
            TOTAL()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PRINTREPORT(ByVal GRNNO As Integer)
        Try
            If MsgBox("Print GRN Report", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            'Dim OBJGRN As New GRNDesign
            'OBJGRN.FRMSTRING = "GRN"
            'OBJGRN.WHERECLAUSE = "{GRN.GRN_NO} = " & GRNNO & " AND {GRN.GRN_YEARID} = " & YearId
            'OBJGRN.MdiParent = MDIMain
            'OBJGRN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function ERRORVALID() As Boolean

        Dim bln As Boolean = True

        If CMBNAME.Text.Trim.Length = 0 Then
            Ep.SetError(CMBNAME, "Please Enter Name")
            bln = False
        End If

        If CMBGODOWN.Text.Trim.Length = 0 Then
            Ep.SetError(CMBGODOWN, "Please Enter Godown Name")
            bln = False
        End If

        If TXTCHALLANNO.Text.Trim.Length = 0 Then
            Ep.SetError(TXTCHALLANNO, "Please Enter Challan/Inv No")
            bln = False
        End If

        If GRIDGRN.RowCount = 0 Then
            Ep.SetError(CMBNAME, "Please Enter Item Details")
            bln = False
        End If

        If lbllocked.Visible = True Then
            Ep.SetError(lbllocked, "Unable to Delelte, Entry Locked")
            bln = False
        End If

        If GRNDATE.Text = "__/__/____" Then
            Ep.SetError(GRNDATE, " Please Enter Proper Date")
            bln = False
        Else
            If Not datecheck(GRNDATE.Text) Then
                Ep.SetError(GRNDATE, "Date not in Accounting Year")
                bln = False
            End If
        End If


        'FOR ORDER CHECKING, FIRST REMOVE GDNQTY
        Dim TEMPORDERROWNO As Integer = -1
        Dim TEMPORDERMATCH As Boolean = False
        If GRIDORDER.RowCount > 0 Then

            For Each ORDROW As DataGridViewRow In GRIDORDER.Rows
                ORDROW.Cells(OGRNQTY.Index).Value = 0
            Next

            'GET MULTISONO
            Dim MULTISONO() As String = (From row As DataGridViewRow In GRIDORDER.Rows.Cast(Of DataGridViewRow)() Where Not row.IsNewRow Select CStr(row.Cells(OPONO.Index).Value)).Distinct.ToArray
            TXTPONO.Clear()
            For Each a As String In MULTISONO
                If TXTPONO.Text = "" Then
                    TXTPONO.Text = a
                Else
                    TXTPONO.Text = TXTPONO.Text & "," & a
                End If
            Next

            For Each ROW As DataGridViewRow In GRIDGRN.Rows
                For Each ORDROW As DataGridViewRow In GRIDORDER.Rows
                    If ROW.Cells(GQUALITY.Index).Value = ORDROW.Cells(OQUALITY.Index).Value And ROW.Cells(gGSM.Index).Value = ORDROW.Cells(OGSM.Index).Value And ROW.Cells(Gsize.Index).Value = ORDROW.Cells(OSIZE.Index).Value Then
                        TEMPORDERMATCH = True
                        'IF ITEM / DESIGN / SHADE IS MATCHED BUT THE QTY IS FULL THEN WE NEED TO KEEP THIS ROWNO IN TEMP AND NEED TO CHECK FURTHER ALSO
                        'IF WE GET ANY NEW MATHING THEN WE NEED TO INSERT THERE
                        'IF NO MATCHING IS FOUND IN FURTHER ROWS THEN WE NEED TO ADD QTY IN THIS TEMPROW
                        If Val(ORDROW.Cells(OGRNQTY.Index).Value) >= Val(ORDROW.Cells(OQTY.Index).Value) Then
                            TEMPORDERROWNO = ORDROW.Index
                            GoTo CHECKNEXTLINE
                        End If
                        ORDROW.Cells(OGRNQTY.Index).Value = Val(ORDROW.Cells(OGRNQTY.Index).Value) + Val(ROW.Cells(GQTY.Index).Value)
                        TEMPORDERROWNO = -1
                        Exit For
CHECKNEXTLINE:
                    End If
                Next
                'IF NO FURTHER MACHING IS FOUND BUT WE HAVE TEMPORDERROWNO THEN ADD VALUE IN THAT ROW
                If TEMPORDERROWNO >= 0 Then
                    GRIDORDER.Rows(TEMPORDERROWNO).Cells(OGRNQTY.Index).Value = Val(GRIDORDER.Rows(TEMPORDERROWNO).Cells(OGRNQTY.Index).Value) + Val(ROW.Cells(GQTY.Index).Value)
                    TEMPORDERROWNO = -1
                End If
                ROW.DefaultCellStyle.BackColor = Color.Empty
                If TEMPORDERMATCH = False Then
                    ROW.DefaultCellStyle.BackColor = Color.LightGreen
                    If MsgBox("There are Items which are not Present in Selected Order, Wish to Proceed", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                        Ep.SetError(CMBNAME, "There are Items which are not Present in Selected Order")
                        bln = False
                    End If
                End If
                ' TEMPORDERMATCH = False
                'If TXTREELNO.Text.Trim = GRIDGRN.Item(GREELNO.Index, TEMPROW).Value And CMBQUALITY.Text = GRIDGRN.Item(GQUALITY.Index, TEMPROW).Value Then
                '    Ep.SetError(CMBNAME, "ReelNo is already present in Grid Wish to Proceed")
                '    bln = False
                'End If

            Next
        End If


        Return bln
    End Function

    Sub getsrno(ByRef grid As System.Windows.Forms.DataGridView)
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
            LBLTOTALQTY.Text = 0
            For Each ROW As DataGridViewRow In GRIDGRN.Rows
                LBLTOTALQTY.Text = Format(Val(LBLTOTALQTY.Text) + Val(ROW.Cells(GQTY.Index).EditedFormattedValue), "0.00")
            Next
            REELCOUNT()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub REELCOUNT()
        'Try
        '    LBLTOTALREELNO.Text = 0
        '    Dim dic As New Dictionary(Of String, Integer)()
        '    Dim cellValue As String
        '    For i = 0 To GRIDGRN.Rows.Count - 1
        '        If Not GRIDGRN.Rows(i).IsNewRow Then
        '            cellValue = GRIDGRN(GREELNO.Index, i).EditedFormattedValue.ToString()
        '            If cellValue <> "" Then
        '                If Not dic.ContainsKey(cellValue) Then
        '                    dic.Add(cellValue, 1)
        '                Else
        '                    dic(cellValue) += 1
        '                End If
        '            End If
        '        End If
        '    Next
        '    LBLTOTALREELNO.Text = Val(dic.Count)
        'Catch ex As Exception
        '    Throw ex
        'End Try

        Try
            LBLTOTALREELNO.Text = 0
            Dim dic As New Dictionary(Of String, Integer)()
            Dim cellValue As String
            For i = 0 To GRIDGRN.Rows.Count - 1
                If Not GRIDGRN.Rows(i).IsNewRow Then
                    cellValue = GRIDGRN(GREELNO.Index, i).EditedFormattedValue.ToString()
                    If cellValue <> "" Then
                        If Not dic.ContainsKey(cellValue) Then
                            dic.Add(cellValue, 1)
                        Else
                            dic(cellValue) += 1
                        End If
                    End If
                End If
            Next
            LBLTOTALREELNO.Text = Val(dic.Count)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTSRNO_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTSRNO.Enter
        If GRIDDOUBLECLICK = False Then TXTSRNO.Text = GRIDGRN.RowCount + 1
    End Sub

    Private Sub CMBNAME_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then FILLNAME(CMBNAME, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE = 'ACCOUNTS'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, CMBCODE, e, Me, TXTADD, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "Sundry Creditors", "ACCOUNTS")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub FILLGRID()
        GRIDGRN.Enabled = True
        If GRIDDOUBLECLICK = False Then
            GRIDGRN.Rows.Add(Val(TXTSRNO.Text.Trim), CMBQUALITY.Text.Trim, TXTLOTNO.Text.Trim, TXTREELNO.Text.Trim, Val(TXTGSM.Text.Trim), TXTGSMDETAILS.Text.Trim, Val(txtsize.Text.Trim), Val(TXTQTY.Text.Trim), CMBUNIT.Text.Trim, 0, 0)
            getsrno(GRIDGRN)
            TXTREELNO.Focus()
        ElseIf GRIDDOUBLECLICK = True Then
            GRIDGRN.Item(gsrno.Index, TEMPROW).Value = Val(TXTSRNO.Text.Trim)
            GRIDGRN.Item(GQUALITY.Index, TEMPROW).Value = CMBQUALITY.Text.Trim
            GRIDGRN.Item(GLOTNO.Index, TEMPROW).Value = TXTLOTNO.Text.Trim
            GRIDGRN.Item(GREELNO.Index, TEMPROW).Value = TXTREELNO.Text.Trim
            GRIDGRN.Item(gGSM.Index, TEMPROW).Value = Val(TXTGSM.Text.Trim)
            GRIDGRN.Item(GGSMDETAILS.Index, TEMPROW).Value = TXTGSMDETAILS.Text.Trim
            GRIDGRN.Item(Gsize.Index, TEMPROW).Value = Val(txtsize.Text.Trim)
            GRIDGRN.Item(GQTY.Index, TEMPROW).Value = Val(TXTQTY.Text.Trim)
            GRIDGRN.Item(GUNIT.Index, TEMPROW).Value = CMBUNIT.Text.Trim

            GRIDDOUBLECLICK = False
        End If

        TOTAL()
        GRIDGRN.FirstDisplayedScrollingRowIndex = GRIDGRN.RowCount - 1

        TXTSRNO.Text = GRIDGRN.RowCount + 1
        ' CMBQUALITY.Text = ""
        ' TXTLOTNO.Clear()
        ' TXTREELNO.Clear()
        ' TXTGSM.Clear()
        ' TXTGSMDETAILS.Clear()
        ' txtsize.Clear()
        TXTQTY.Clear()



    End Sub

    Private Sub toolprevious_Click(sender As Object, e As EventArgs) Handles toolprevious.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Cursor.Current = Cursors.WaitCursor

            GRIDGRN.RowCount = 0
LINE1:

            TEMPGRNNO = Val(TXTGRNNO.Text) - 1
            If TEMPGRNNO > 0 Then
                EDIT = True
                GRN_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
            If GRIDGRN.RowCount = 0 And TEMPGRNNO > 1 Then
                TXTGRNNO.Text = TEMPGRNNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub toolnext_Click(sender As Object, e As EventArgs) Handles toolnext.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            GRIDGRN.RowCount = 0
LINE1:
            TEMPGRNNO = Val(TXTGRNNO.Text) + 1
            Dim MAXNO As Integer = TXTGRNNO.Text.Trim
            CLEAR()
            If Val(TXTGRNNO.Text) - 1 >= TEMPGRNNO Then
                EDIT = True
                GRN_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
            If GRIDGRN.RowCount = 0 And TEMPGRNNO < MAXNO Then
                TXTGRNNO.Text = TEMPGRNNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tstxtbillno.KeyPress, txtsize.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub CMBNAME_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBNAME.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and GROUPMASTER.GROUP_SECONDARY = 'Sundry CREDITORS' AND LEDGERS.ACC_TYPE = 'ACCOUNTS'"
                OBJLEDGER.ShowDialog()
                'If OBJLEDGER.TEMPCODE <> "" Then CMBCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then CMBNAME.Text = OBJLEDGER.TEMPNAME
            End If
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

    Private Sub CMBUNIT_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBUNIT.Enter
        Try
            If CMBUNIT.Text.Trim = "" Then FILLUNIT(CMBUNIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBUNIT_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBUNIT.Validating
        Try
            If CMBUNIT.Text.Trim <> "" Then unitvalidate(CMBUNIT, e, Me)
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
            Dim objgrndetails As New GRNDetails
            objgrndetails.MdiParent = MDIMain
            objgrndetails.Show()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TOOLDELETE_Click(sender As Object, e As EventArgs) Handles TOOLDELETE.Click
        Call cmddelete_Click(sender, e)
    End Sub

    Private Sub SaveToolStripButton_Click(sender As Object, e As EventArgs) Handles SaveToolStripButton.Click
        Call cmdok_Click(sender, e)
    End Sub

    Private Sub gridbill_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDGRN.KeyDown
        Try
            If e.KeyCode = Keys.Delete Then
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                GRIDGRN.Rows.RemoveAt(GRIDGRN.CurrentRow.Index)
                TOTAL()
                getsrno(GRIDGRN)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdselectpo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSELECTPO.Click
        Try

            If (EDIT = True And USEREDIT = False And USERVIEW = False) Or (EDIT = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If CMBNAME.Text.Trim <> "" Then

                Dim OBJSELECTPO As New SelectPO
                OBJSELECTPO.PARTYNAME = CMBNAME.Text
                Dim DTPO As DataTable = OBJSELECTPO.DT
                OBJSELECTPO.ShowDialog()

                If DTPO.Rows.Count > 0 Then

                    ''  GETTING DISTINCT PONO NO IN TEXTBOX
                    Dim DV As DataView = DTPO.DefaultView
                    Dim NEWDT As DataTable = DV.ToTable(True, "PONO")
                    For Each DTR As DataRow In NEWDT.Rows
                        If TXTPONO.Text.Trim = "" Then
                            TXTPONO.Text = DTR("PONO").ToString
                        Else
                            TXTPONO.Text = TXTPONO.Text & "," & DTR("PONO").ToString
                        End If
                    Next

                    For Each DTROW As DataRow In DTPO.Rows

                        For Each ROW As DataGridViewRow In GRIDORDER.Rows
                            If Val(ROW.Cells(OPONO.Index).Value) = Val(DTROW("PONO")) And Val(ROW.Cells(OPOSRNO.Index).Value) = Val(DTROW("POSRNO")) And ROW.Cells(OPOTYPE.Index).Value = DTROW("POTYPE") Then GoTo NEXTLINE
                        Next

                        GRIDORDER.Rows.Add(0, DTROW("QUALITY"), Val(DTROW("GSM")), Val(DTROW("SIZE")), Val(DTROW("QTY")), Val(DTROW("PONO")), Val(DTROW("POSRNO")), DTROW("POTYPE"), Val(DTROW("RATE")), 0)

NEXTLINE:
                    Next

                    getsrno(GRIDORDER)
                    TOTAL()

                    CMDSELECTPO.Enabled = False

                End If

            Else
                MsgBox("Enter Party Name")
                CMBNAME.Focus()
            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        Try
            If EDIT = True Then
                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                If lbllocked.Visible = True Then
                    MsgBox("Unable To Delete", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                If MsgBox("Wish to Delete GRN.?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    If MsgBox("Are you Sure?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                        Dim alParaval As New ArrayList
                        alParaval.Add(TXTGRNNO.Text.Trim)
                        alParaval.Add(YearId)

                        Dim clspo As New ClsGRN()
                        clspo.alParaval = alParaval
                        Dim IntResult As Integer = clspo.DELETE()
                        MsgBox("GRN Deleted")
                        CLEAR()
                        EDIT = False
                    End If
                End If

            End If

        Catch ex As Exception
            Throw ex

        End Try
    End Sub

    Private Sub gridbill_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDGRN.CellDoubleClick
        Try
            If GRIDGRN.CurrentRow.Index >= 0 And GRIDGRN.Item(gsrno.Index, GRIDGRN.CurrentRow.Index).Value <> Nothing Then

                GRIDDOUBLECLICK = True
                TXTSRNO.Text = GRIDGRN.Item(gsrno.Index, GRIDGRN.CurrentRow.Index).Value
                CMBQUALITY.Text = GRIDGRN.Item(GQUALITY.Index, GRIDGRN.CurrentRow.Index).Value.ToString
                TXTLOTNO.Text = GRIDGRN.Item(GLOTNO.Index, GRIDGRN.CurrentRow.Index).Value.ToString
                TXTREELNO.Text = GRIDGRN.Item(GREELNO.Index, GRIDGRN.CurrentRow.Index).Value.ToString
                TXTGSM.Text = GRIDGRN.Item(gGSM.Index, GRIDGRN.CurrentRow.Index).Value.ToString
                TXTGSMDETAILS.Text = GRIDGRN.Item(GGSMDETAILS.Index, GRIDGRN.CurrentRow.Index).Value.ToString
                txtsize.Text = GRIDGRN.Item(Gsize.Index, GRIDGRN.CurrentRow.Index).Value.ToString
                TXTQTY.Text = GRIDGRN.Item(GQTY.Index, GRIDGRN.CurrentRow.Index).Value
                CMBUNIT.Text = GRIDGRN.Item(GUNIT.Index, GRIDGRN.CurrentRow.Index).Value.ToString

                TEMPROW = GRIDGRN.CurrentRow.Index
                'TXTQTY.Focus()
                TXTREELNO.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBQUALITY_Validating(sender As Object, e As CancelEventArgs) Handles CMBQUALITY.Validating
        Try
            If CMBQUALITY.Text.Trim <> "" Then ITEMVALIDATE(CMBQUALITY, e, Me, "", "MERCHANT")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBQUALITY_Enter(sender As Object, e As EventArgs) Handles CMBQUALITY.Enter
        Try
            If CMBQUALITY.Text.Trim = "" Then FILLITEMNAME(CMBQUALITY, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBUNIT_Validated(sender As Object, e As EventArgs) Handles CMBUNIT.Validated
        Try
            If CMBQUALITY.Text.Trim <> "" And Val(TXTQTY.Text.Trim) > 0 And CMBUNIT.Text.Trim <> "" Then FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Validated(sender As Object, e As EventArgs) Handles CMBNAME.Validated
        Try
            If CMBNAME.Text.Trim <> "" Then
                'GET  WARNING TEXT
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.SEARCH(" ISNULL(ACC_WARNING, '') AS WARNING ", "", " LEDGERS ", " and LEDGERS.acc_cmpname = '" & CMBNAME.Text.Trim & "' and LEDGERS.acc_YEARid = " & YearId)
                If DT.Rows.Count > 0 Then
                    If DT.Rows(0).Item("WARNING") <> "" Then MsgBox(DT.Rows(0).Item("WARNING"), MsgBoxStyle.Critical)

                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTGSM_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTGSM.KeyPress, TXTQTY.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub CHALLANDATE_Validating(sender As Object, e As CancelEventArgs) Handles CHALLANDATE.Validating
        Try
            If CHALLANDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(CHALLANDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRNDATE_Validating(sender As Object, e As CancelEventArgs) Handles GRNDATE.Validating
        Try
            If GRNDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(GRNDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTREELNO_Validated(sender As Object, e As EventArgs) Handles TXTREELNO.Validated
        'Try
        '    Dim OBJCMN As New ClsCommon
        '    Dim DT As DataTable = OBJCMN.SEARCH(" STOCKMASTER.SM_REELNO AS REELNO, ITEMMASTER.ITEM_NAME AS ITEMNAME ", "", " STOCKMASTER LEFT OUTER JOIN ITEMMASTER ON STOCKMASTER.SM_ITEMID = ITEMMASTER.item_id ", " AND STOCKMASTER.SM_REELNO ='" & TXTREELNO.Text.Trim & "' AND ITEMMASTER.ITEM_NAME = '" & CMBQUALITY.Text & "' AND SM_CMPID = " & CmpId & " AND SM_LOCATIONID = " & Locationid & " AND SM_YEARID = " & YearId)
        '    If DT.Rows.Count > 0 Then
        '        If MsgBox("ReelNo is already present in Stock Wish to Proceed?", MsgBoxStyle.YesNo) = vbNo Then Exit Sub
        '    End If

        '    For Each ROW As DataGridViewRow In GRIDGRN.Rows
        '        If TXTREELNO.Text.Trim = GRIDGRN.Item(GREELNO.Index, TEMPROW).Value And CMBQUALITY.Text = GRIDGRN.Item(GQUALITY.Index, TEMPROW).Value Then
        '            Ep.SetError(GRIDGRN, "ReelNo is already present in Grid ")
        '            TXTREELNO.Focus()
        '        End If
        '    Next

        'Catch ex As Exception
        '    Throw ex
        'End Try
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.SEARCH(" STOCKMASTER.SM_REELNO AS REELNO, ITEMMASTER.ITEM_NAME AS ITEMNAME ", "", " STOCKMASTER LEFT OUTER JOIN ITEMMASTER ON STOCKMASTER.SM_ITEMID = ITEMMASTER.item_id ", " AND STOCKMASTER.SM_REELNO ='" & TXTREELNO.Text.Trim & "' AND ITEMMASTER.ITEM_NAME = '" & CMBQUALITY.Text & "' AND SM_CMPID = " & CmpId & " AND SM_LOCATIONID = " & Locationid & " AND SM_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                If MsgBox("ReelNo is already present in Stock Wish to Proceed?", MsgBoxStyle.YesNo) = vbNo Then Exit Sub
            End If
            If GRIDDOUBLECLICK = False Then

                For Each ROW As DataGridViewRow In GRIDGRN.Rows
                    If TXTREELNO.Text.Trim = ROW.Cells(GREELNO.Index).Value.ToString And CMBQUALITY.Text = GRIDGRN.Item(GQUALITY.Index, TEMPROW).Value Then
                        Ep.SetError(GRIDGRN, "ReelNo is already present in Grid ")
                        TXTREELNO.Focus()


                    End If
                Next
            ElseIf GRIDDOUBLECLICK = True Then

                If TXTREELNO.Text.Trim <> GRIDGRN.Item(GREELNO.Index, TEMPROW).Value And TXTSRNO.Text.Trim = GRIDGRN.Item(gsrno.Index, TEMPROW).Value And CMBQUALITY.Text = GRIDGRN.Item(GQUALITY.Index, TEMPROW).Value Then
                    Ep.SetError(GRIDGRN, "ReelNo is already present in Grid ")
                    TXTREELNO.Focus()
                End If

            End If



        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class