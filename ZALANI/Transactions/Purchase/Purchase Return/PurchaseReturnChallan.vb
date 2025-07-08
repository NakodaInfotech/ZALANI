
Imports System.ComponentModel
Imports BL

Public Class PurchaseReturnChallan

    Dim GRIDDOUBLECLICK As Boolean
    Public EDIT As Boolean
    Public TEMPPRCHNO, TEMPROW As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub CMDEXIT_Click_1(sender As Object, e As EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Sub CLEAR()

        tstxtbillno.Clear()
        Ep.Clear()
        TXTPONO.Clear()
        PRCHDATE.Text = Now.Date
        CMBNAME.Text = ""
        CMBNAME.Visible = True
        If USERGODOWN <> "" Then cmbGodown.Text = USERGODOWN Else cmbGodown.Text = ""
        TXTPARTYREFNO.Clear()
        TXTCHALLANNO.Clear()
        CHALLANDATE.Value = Now.Date
        DTPODATE.Text = Now.Date
        TXTPONO.Clear()
        TXTSRNO.Text = 1
        CMBINVTYPE.Text = ""
        CMBQUALITY.Text = ""
        TXTLOTNO.Clear()
        TXTGSM.Clear()
        TXTSIZE.Clear()
        TXTQTY.Text = ""
        CMBUNIT.Text = ""
        GRIDPR.RowCount = 0
        TXTREMARKS.Clear()
        lbllocked.Visible = False
        PBlock.Visible = False
        GRIDDOUBLECLICK = False
        GETMAXNO()
        LBLTOTALQTY.Text = 0
        LBLTOTALREELNO.Text = 0
        CMDSELECTSTOCK.Enabled = True
        TXTREELNO.Clear()
        CMDSELECTPO.Enabled = True
    End Sub

    Sub TOTAL()
        Try
            LBLTOTALQTY.Text = 0
            ' LBLTOTALREELNO.Text = 0
            For Each ROW As DataGridViewRow In GRIDPR.Rows
                LBLTOTALQTY.Text = Format(Val(LBLTOTALQTY.Text) + Val(ROW.Cells(gQty.Index).EditedFormattedValue), "0.00")
                ' LBLTOTALREELNO.Text = Format(Val(LBLTOTALREELNO.Text) + Val(ROW.Cells(GREELNO.Index).EditedFormattedValue), "0")
            Next
            REELCOUNT()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub REELCOUNT()
        Try
            LBLTOTALREELNO.Text = 0
            Dim dic As New Dictionary(Of String, Integer)()
            Dim cellValue As String
            For i = 0 To GRIDPR.Rows.Count - 1
                If Not GRIDPR.Rows(i).IsNewRow Then
                    cellValue = GRIDPR(GREELNO.Index, i).EditedFormattedValue.ToString()
                    If cellValue <> "" Then
                        If Not dic.ContainsKey(cellValue) Then
                            dic.Add(cellValue, 1)
                        Else
                            dic(cellValue) += 1
                        End If
                    End If
                End If
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDCLEAR_Click(sender As Object, e As EventArgs)
        CLEAR()
        EDIT = False
        CMBNAME.Focus()
    End Sub

    Sub GETMAXNO()
        Try
            Dim DTTABLE As New DataTable
            DTTABLE = getmax(" isnull(max(PRCH_no),0) + 1 ", " PURCHASERETURNCHALLAN ", " and PRCH_yearid=" & YearId)
            If DTTABLE.Rows.Count > 0 Then TXTPRCHNO.Text = DTTABLE.Rows(0).Item(0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Function ERRORVALID() As Boolean
        Try

            Dim bln As Boolean = True

            If cmbGodown.Text.Trim.Length = 0 Then
                Ep.SetError(cmbGodown, " Please Select Godown")
                bln = False
            End If

            If CMBNAME.Text.Trim.Length = 0 Then
                Ep.SetError(CMBNAME, " Please Fill Company Name ")
                bln = False
            End If


            If UserName <> "Admin" And lbllocked.Visible = True Then
                Ep.SetError(lbllocked, "Item Used, Item Locked")
                bln = False
            End If

            If GRIDPR.RowCount = 0 Then
                Ep.SetError(TabControl1, "Fill Item Details")
                bln = False
            End If

            If PRCHDATE.Text = "__/__/____" Then
                Ep.SetError(PRCHDATE, " Please Enter Proper Date")
                bln = False
            Else
                If Not datecheck(PRCHDATE.Text) Then
                    Ep.SetError(PRCHDATE, "Date not in Accounting Year")
                    bln = False
                End If

                If Convert.ToDateTime(PRCHDATE.Text).Date < PURRETCHBLOCKDATE.Date Then
                    Ep.SetError(PRCHDATE, "Date is Blocked, Please make entries after " & Format(PURRETCHBLOCKDATE.Date, "dd/MM/yyyy"))
                    bln = False
                End If
            End If

            Return bln
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub CMDOK_Click(sender As Object, e As EventArgs) Handles CMDOK.Click
        Try
            Cursor.Current = Cursors.WaitCursor

            Ep.Clear()
            If Not ERRORVALID() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList


            alParaval.Add(Format(Convert.ToDateTime(PRCHDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(CMBNAME.Text.Trim)
            alParaval.Add(cmbGodown.Text.Trim)

            alParaval.Add(TXTCHALLANNO.Text.Trim)
            alParaval.Add(Format(Convert.ToDateTime(CHALLANDATE.Value).Date, "MM/dd/yyyy"))

            alParaval.Add(TXTPONO.Text.Trim)
            alParaval.Add(Format(Convert.ToDateTime(DTPODATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(TXTPARTYREFNO.Text.Trim)
            alParaval.Add(CMBINVTYPE.Text.Trim)

            alParaval.Add(Val(LBLTOTALQTY.Text))
            alParaval.Add(Val(LBLTOTALREELNO.Text))

            alParaval.Add(TXTREMARKS.Text.Trim)

            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)


            Dim GRIDSRNO As String = ""
            Dim QUALITY As String = ""
            Dim MILLNAME As String = ""
            Dim LOTNO As String = ""
            Dim REELNO As String = ""
            Dim GSM As String = ""
            Dim SIZE As String = ""
            Dim QTY As String = ""
            Dim UNIT As String = ""
            Dim DONE As String = ""




            For Each row As Windows.Forms.DataGridViewRow In GRIDPR.Rows
                If row.Cells(0).Value <> Nothing Then
                    If GRIDSRNO = "" Then
                        GRIDSRNO = Val(row.Cells(gsrno.Index).Value)
                        QUALITY = row.Cells(GQUALITY.Index).Value.ToString
                        LOTNO = row.Cells(gLOTNO.Index).Value.ToString
                        REELNO = row.Cells(GREELNO.Index).Value.ToString
                        GSM = row.Cells(GGSM.Index).Value.ToString
                        SIZE = row.Cells(GSIZE.Index).Value.ToString
                        QTY = Val(row.Cells(gQty.Index).Value)
                        UNIT = row.Cells(gunit.Index).Value.ToString
                        If row.Cells(GDONE.Index).Value = True Then DONE = 1 Else DONE = 0

                    Else

                        GRIDSRNO = GRIDSRNO & "|" & Val(row.Cells(gsrno.Index).Value)
                        QUALITY = QUALITY & "|" & row.Cells(GQUALITY.Index).Value.ToString
                        LOTNO = LOTNO & "|" & row.Cells(gLOTNO.Index).Value.ToString
                        REELNO = REELNO & "|" & row.Cells(GREELNO.Index).Value.ToString
                        GSM = GSM & "|" & row.Cells(GGSM.Index).Value.ToString
                        SIZE = SIZE & "|" & row.Cells(GSIZE.Index).Value.ToString
                        QTY = QTY & "|" & Val(row.Cells(gQty.Index).Value)
                        UNIT = UNIT & "|" & row.Cells(gunit.Index).Value.ToString
                        If row.Cells(GDONE.Index).Value = True Then
                            DONE = DONE & "|" & "1"
                        Else
                            DONE = DONE & "|" & "0"
                        End If

                    End If
                End If
            Next

            alParaval.Add(GRIDSRNO)
            alParaval.Add(QUALITY)
            alParaval.Add(LOTNO)
            alParaval.Add(REELNO)
            alParaval.Add(GSM)
            alParaval.Add(SIZE)
            alParaval.Add(QTY)
            alParaval.Add(UNIT)
            alParaval.Add(DONE)


            Dim OBJSR As New ClsPurchaseReturnChallan()
            OBJSR.alParaval = alParaval
            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim DTTABLE As DataTable = OBJSR.SAVE()
                MsgBox("Details Added")
                TXTPRCHNO.Text = Val(DTTABLE.Rows(0).Item(0))
                TEMPPRCHNO = Val(DTTABLE.Rows(0).Item(0))

            ElseIf EDIT = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPPRCHNO)
                Dim IntResult As Integer = OBJSR.UPDATE()
                MsgBox("Details Updated")
            End If
            'PRINTREPORT(TEMPPRCHNO)

            EDIT = False
            CLEAR()
            CMBNAME.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub
    Private Sub TXTSRNO_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTSRNO.Enter
        If GRIDDOUBLECLICK = False Then TXTSRNO.Text = GRIDPR.RowCount + 1
    End Sub

    Sub PRINTREPORT(ByVal SRNO As Integer)
        Try
            If MsgBox("Wish to Print Purchase Return?", MsgBoxStyle.YesNo) = vbYes Then
                'Dim OBJPUR As New PurchaseInvoiceDesign
                'OBJPUR.MdiParent = MDIMain
                'OBJPUR.FRMSTRING = "PURRETURNCHALLAN"
                'OBJPUR.PURRETNO = Val(SRNO)
                'OBJPUR.WHERECLAUSE = "{PURCHASERETURNCHALLAN.PRCH_NO}=" & Val(SRNO) & " and {PURCHASERETURNCHALLAN.PRCH_yearid}=" & YearId
                'OBJPUR.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PurchaseReturnChallan_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If ERRORVALID() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then CMDOK_Click(sender, e)
                End If
                Me.Close()
            ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for billno foucs
                tstxtbillno.Focus()
                tstxtbillno.SelectAll()
            ElseIf e.KeyCode = Windows.Forms.Keys.F5 Then       'Grid Focus
                GRIDPR.Focus()
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D1 Then       'for Delete
                TabControl1.SelectedIndex = (0)
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.D2 Then       'for Delete
                TabControl1.SelectedIndex = (1)
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
                'Call OpenToolStripButton_Click(sender, e)
            ElseIf e.KeyCode = Keys.Oemcomma Then
                e.SuppressKeyPress = True
            ElseIf e.Alt = True And e.KeyCode = Keys.Left Then
                toolprevious_Click_1(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Keys.Right Then
                toolnext_Click_1(sender, e)
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PurchaseReturnChallan_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'PURCHASE RETURN'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            Cursor.Current = Cursors.WaitCursor

            FILLCMB()
            CLEAR()
            CMBNAME.Enabled = True

            If EDIT = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim OBJSR As New ClsPurchaseReturnChallan()
                OBJSR.alParaval.Add(TEMPPRCHNO)
                OBJSR.alParaval.Add(YearId)
                Dim dttable As DataTable = OBJSR.SELECTPURCHASERETURNCHALLAN()
                If dttable.Rows.Count > 0 Then

                    For Each dr As DataRow In dttable.Rows

                        TXTPRCHNO.Text = TEMPPRCHNO
                        TXTPRCHNO.ReadOnly = True

                        PRCHDATE.Text = Format(Convert.ToDateTime(dr("DATE")).Date, "dd/MM/yyyy")
                        CMBNAME.Text = Convert.ToString(dr("NAME"))
                        cmbGodown.Text = dr("GODOWN")
                        TXTPONO.Text = dr("PONO")
                        TXTCHALLANNO.Text = dr("CHALLANNO")
                        CHALLANDATE.Value = Format(Convert.ToDateTime(dr("CHALLANDATE")).Date, "dd/MM/yyyy")
                        DTPODATE.Text = Format(Convert.ToDateTime(dr("PODATE")).Date, "dd/MM/yyyy")
                        TXTPARTYREFNO.Text = dr("PARTYREFNO")
                        LBLTOTALQTY.Text = Format(Val(dr("TOTALQTY")), "0.00")
                        LBLTOTALREELNO.Text = Format(Val(dr("TOTALREELNO")), "0.00")
                        CMBINVTYPE.Text = dr("INVTYPE")
                        TXTREMARKS.Text = Convert.ToString(dr("remarks").ToString)


                        'Item Grid
                        GRIDPR.Rows.Add(dr("GRIDSRNO").ToString, dr("QUALITY").ToString, dr("LOTNO").ToString, dr("REELNO").ToString, dr("GSM").ToString, dr("SIZE"), Format(Val(dr("qty")), "0.00"), dr("UNIT").ToString, dr("GRIDDONE"))

                        If Convert.ToBoolean(dr("DONE")) = True Then
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If

                    Next

                    TOTAL()
                    GRIDPR.FirstDisplayedScrollingRowIndex = GRIDPR.RowCount - 1
                Else
                    EDIT = False
                    CLEAR()
                End If

            End If

            TXTSRNO.Text = GRIDPR.RowCount

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLCMB()
        Try
            If CMBNAME.Text.Trim = "" Then fillname(CMBNAME, EDIT, " And GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors'")
            If cmbGodown.Text.Trim = "" Then fillGODOWN(cmbGodown, EDIT)

            'fillQUALITY(CMBQUALITY, EDIT)
            FILLUNIT(CMBUNIT)

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbGodown_Enter(sender As Object, e As EventArgs)
        Try
            If cmbGodown.Text.Trim = "" Then fillGODOWN(cmbGodown, EDIT)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbGodown_Validating(sender As Object, e As CancelEventArgs)
        Try
            If cmbGodown.Text.Trim <> "" Then GODOWNVALIDATE(cmbGodown, e, Me)
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
    Private Sub tstxtbillno_Validating(sender As Object, e As CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                GRIDPR.RowCount = 0
                TEMPPRCHNO = Val(tstxtbillno.Text)
                If TEMPPRCHNO > 0 Then
                    EDIT = True
                    PurchaseReturnChallan_Load(sender, e)
                Else
                    CLEAR()
                    EDIT = False
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            GRIDPR.Enabled = True
            If GRIDDOUBLECLICK = False Then
                GRIDPR.Rows.Add(Val(TXTSRNO.Text.Trim), CMBQUALITY.Text.Trim, TXTLOTNO.Text.Trim, TXTREELNO.Text.Trim, TXTGSM.Text.Trim, TXTSIZE.Text.Trim, Val(TXTQTY.Text.Trim), CMBUNIT.Text.Trim, 0, 0)
                getsrno(GRIDPR)
            ElseIf GRIDDOUBLECLICK = True Then
                GRIDPR.Item(gsrno.Index, TEMPROW).Value = Val(TXTSRNO.Text.Trim)
                GRIDPR.Item(GQUALITY.Index, TEMPROW).Value = CMBQUALITY.Text.Trim
                GRIDPR.Item(gLOTNO.Index, TEMPROW).Value = TXTLOTNO.Text.Trim
                GRIDPR.Item(GREELNO.Index, TEMPROW).Value = TXTREELNO.Text.Trim
                GRIDPR.Item(GGSM.Index, TEMPROW).Value = TXTGSM.Text.Trim
                GRIDPR.Item(GSIZE.Index, TEMPROW).Value = TXTSIZE.Text.Trim
                GRIDPR.Item(gQty.Index, TEMPROW).Value = Val(TXTQTY.Text.Trim)
                GRIDPR.Item(gunit.Index, TEMPROW).Value = CMBUNIT.Text.Trim

                GRIDDOUBLECLICK = False
            End If

            TOTAL()
            GRIDPR.FirstDisplayedScrollingRowIndex = GRIDPR.RowCount - 1

            TXTSRNO.Text = GRIDPR.RowCount + 1
            CMBQUALITY.Text = ""
            TXTLOTNO.Clear()
            TXTREELNO.Clear()
            TXTGSM.Clear()
            TXTSIZE.Clear()
            TXTQTY.Clear()
            CMBUNIT.Text = ""

            CMBQUALITY.Focus()
            TOTAL()
            REELCOUNT()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub GRIDPR_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRIDPR.CellDoubleClick
        EDITROW()
    End Sub

    Private Sub toolprevious_Click_1(sender As Object, e As EventArgs) Handles toolprevious.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            Cursor.Current = Cursors.WaitCursor
            GRIDPR.RowCount = 0
LINE1:
            TEMPPRCHNO = Val(TXTPRCHNO.Text) - 1
            If TEMPPRCHNO > 0 Then
                EDIT = True
                PurchaseReturnChallan_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
            If GRIDPR.RowCount = 0 And TEMPPRCHNO > 1 Then
                TXTPRCHNO.Text = TEMPPRCHNO
                GoTo LINE1
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub toolnext_Click_1(sender As Object, e As EventArgs) Handles toolnext.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            GRIDPR.RowCount = 0
LINE1:
            TEMPPRCHNO = Val(TXTPRCHNO.Text) + 1
            GETMAXNO()
            Dim MAXNO As Integer = TXTPRCHNO.Text.Trim
            CLEAR()
            If Val(TXTPRCHNO.Text) - 1 >= TEMPPRCHNO Then
                EDIT = True
                PurchaseReturnChallan_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
            If GRIDPR.RowCount = 0 And TEMPPRCHNO < MAXNO Then
                TXTPRCHNO.Text = TEMPPRCHNO
                GoTo LINE1
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tooldelete_Click(sender As Object, e As EventArgs)
        Try
            Call CMDDELETE_Click_1(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDDELETE_Click_1(sender As Object, e As EventArgs) Handles CMDDELETE.Click
        Try
            Dim IntResult As Integer
            If EDIT = True Then

                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                If lbllocked.Visible = True Then
                    MsgBox("Purchase Return Challan Locked", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                If MsgBox("Delete Purchase Return Challan?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

                Dim alParaval As New ArrayList
                alParaval.Add(Val(TXTPRCHNO.Text.Trim))
                alParaval.Add(Userid)
                alParaval.Add(YearId)

                Dim OBJSR As New ClsPurchaseReturnChallan()
                OBJSR.alParaval = alParaval
                IntResult = OBJSR.DELETE()
                MsgBox("Purchase Return Challan Deleted")
                CLEAR()
                EDIT = False

            Else
                MsgBox("Delete is only in Edit Mode")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBQTYUNIT_Enter(sender As Object, e As EventArgs)
        Try
            If CMBUNIT.Text.Trim = "" Then fillunit(CMBUNIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBQTYUNIT_Validating(sender As Object, e As CancelEventArgs)
        Try
            If CMBUNIT.Text.Trim <> "" Then unitvalidate(CMBUNIT, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub EDITROW()
        Try
            If GRIDPR.CurrentRow.Index >= 0 And GRIDPR.Item(gsrno.Index, GRIDPR.CurrentRow.Index).Value <> Nothing Then

                GRIDDOUBLECLICK = True
                TXTSRNO.Text = GRIDPR.Item(gsrno.Index, GRIDPR.CurrentRow.Index).Value.ToString
                CMBQUALITY.Text = GRIDPR.Item(GQUALITY.Index, GRIDPR.CurrentRow.Index).Value.ToString
                TXTLOTNO.Text = GRIDPR.Item(gLOTNO.Index, GRIDPR.CurrentRow.Index).Value.ToString
                TXTREELNO.Text = GRIDPR.Item(GREELNO.Index, GRIDPR.CurrentRow.Index).Value.ToString
                TXTGSM.Text = GRIDPR.Item(GGSM.Index, GRIDPR.CurrentRow.Index).Value.ToString
                TXTSIZE.Text = GRIDPR.Item(GSIZE.Index, GRIDPR.CurrentRow.Index).Value.ToString
                TXTQTY.Text = GRIDPR.Item(gQty.Index, GRIDPR.CurrentRow.Index).Value
                CMBUNIT.Text = GRIDPR.Item(gunit.Index, GRIDPR.CurrentRow.Index).Value.ToString

                TEMPROW = GRIDPR.CurrentRow.Index
                CMBQUALITY.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDSR_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            If e.KeyCode = Keys.Delete And GRIDPR.RowCount > 0 Then
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If

                'end of block
                GRIDPR.Rows.RemoveAt(GRIDPR.CurrentRow.Index)
                getsrno(GRIDPR)
                TOTAL()
            ElseIf e.KeyCode = Keys.F5 Then
                EDITROW()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTCUT_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        TXTSIZE.SelectAll()
    End Sub

    Private Sub cmbGodown_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJGODOWN As New SelectGodown
                OBJGODOWN.FRMSTRING = "GODOWN"
                OBJGODOWN.ShowDialog()
                If OBJGODOWN.TEMPNAME <> "" Then cmbGodown.Text = OBJGODOWN.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Private Sub cmbPIECETYPE_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Try
    '        If CMBINVTYPE.Text.Trim = "" Then fillPIECETYPE(CMBINVTYPE)
    '    Catch ex As Exception
    '        If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
    '    End Try
    'End Sub
    Private Sub txtremarks_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
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

    Private Sub SRCHDATE_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        PRCHDATE.SelectionStart = 0
    End Sub

    Private Sub SRCHDATE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Try
            If PRCHDATE.Text.Trim <> "__/__/____" Then
                'PARSING DATE FORMATS WHETHER THEY ARE PROPER OR NOT
                Dim TEMP As DateTime
                If Not DateTime.TryParse(PRCHDATE.Text, TEMP) Then
                    MsgBox("Enter Proper Date")
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub CMBNAME_KeyDown(sender As Object, e As KeyEventArgs) Handles CMBNAME.KeyDown
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

    Private Sub PrintToolStripButton_Click(sender As Object, e As EventArgs)
        'If EDIT = True Then
        '    PRINTREPORT(TEMPPRCHNO)
        'End If
    End Sub



    Private Sub TOOLWHATSAPP_Click(sender As Object, e As EventArgs)
        Try
            Dim DT As New DataTable
            Dim OBJCMN As New ClsCommon
            If EDIT = True Then SENDWHATSAPP(TEMPPRCHNO)
            DT = OBJCMN.Execute_Any_String("UPDATE PURCHASERETURNCHALLAN SET PRCH_SENDWHATSAPP = 1 WHERE PRCH_NO = " & TEMPPRCHNO & " AND PRCH_YEARID = " & YearId, "", "")
            'LBLWHATSAPP.Visible = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SENDWHATSAPP(SRNO As Integer)
        Try
            If ALLOWWHATSAPP = False Then Exit Sub
            If Not CHECKWHASTAPPEXP() Then
                MsgBox("Whatsapp Package has Expired, Kindly contact Nakoda Infotech on 02249724411", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If MsgBox("Send Whatsapp?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            'Dim WHATSAPPNO As String = ""
            'Dim OBJSR As New PurchaseReturnDesign
            'OBJSR.MdiParent = MDIMain
            'OBJSR.DIRECTPRINT = True
            'OBJSR.FRMSTRING = "PURCHASERETURNCHALLAN"
            'OBJSR.DIRECTMAIL = True
            'OBJSR.WHERECLAUSE = "{PURCHASERETURNCHALLAN.PRCH_NO}=" & Val(SRNO) & " and {PURCHASERETURNCHALLAN.PRCH_yearid}=" & YearId
            'OBJSR.SALRETNO = SRNO
            'OBJSR.NOOFCOPIES = 1
            'OBJSR.Show()
            'OBJSR.Close()

            Dim OBJWHATSAPP As New SendWhatsapp
            OBJWHATSAPP.PARTYNAME = CMBNAME.Text.Trim
            OBJWHATSAPP.PATH.Add(Application.StartupPath & "\PURCHASERET_" & Val(SRNO) & ".pdf")
            OBJWHATSAPP.FILENAME.Add("PURCHASERET_" & Val(SRNO) & ".pdf")
            OBJWHATSAPP.ShowDialog()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDSELECTSTOCK_Click(sender As Object, e As EventArgs) Handles CMDSELECTSTOCK.Click
        Try

            If (EDIT = True And USEREDIT = False And USERVIEW = False) Or (EDIT = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If CMBNAME.Text.Trim <> "" Then

                Dim OBJSELECTPO As New SelectStock
                OBJSELECTPO.GODOWN = cmbGodown.Text.Trim
                Dim DTPO As DataTable = OBJSELECTPO.DT
                OBJSELECTPO.ShowDialog()

                If DTPO.Rows.Count > 0 Then

                    ''  GETTING DISTINCT PONO NO IN TEXTBOX
                    Dim DV As DataView = DTPO.DefaultView
                    Dim NEWDT As DataTable = DV.ToTable(True, "FROMNO")
                    For Each DTR As DataRow In NEWDT.Rows
                        If TXTPRCHNO.Text.Trim = "" Then
                            TXTPRCHNO.Text = DTR("FROMNO").ToString
                        Else
                            TXTPRCHNO.Text = TXTPRCHNO.Text & "," & DTR("FROMNO").ToString
                        End If
                    Next

                    For Each DTROW As DataRow In DTPO.Rows

                        For Each ROW As DataGridViewRow In GRIDPR.Rows
                            If Val(TXTPRCHNO.Text.Trim) = Val(DTROW("FROMNO")) And Val(ROW.Cells(gsrno.Index).Value) = Val(DTROW("FROMSRNO")) Then GoTo NEXTLINE
                        Next
                        GRIDPR.Rows.Add(0, DTROW("ITEMNAME"), DTROW("LOTNO"), DTROW("REELNO"), Val(DTROW("GSM")), Val(DTROW("SIZE")), Val(DTROW("QTY")), DTROW("UNIT"))

NEXTLINE:
                    Next

                    getsrno(GRIDPR)
                    TOTAL()
                    CMBNAME.Enabled = True
                    CMDSELECTSTOCK.Enabled = True

                End If
            Else
                MsgBox("Enter Machine Party Name")
                CMBNAME.Focus()
            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDSELECTPO_Click(sender As Object, e As EventArgs) Handles CMDSELECTPO.Click

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

                    ''FETCH DATA FROM joborder
                    TXTPONO.Text = Val(DTPO.Rows(0).Item("PONO"))
                    DTPODATE.Text = DTPO.Rows(0).Item("DATE")
                End If
            End If
            CMDSELECTPO.Enabled = True
            getsrno(GRIDPR)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDCLEAR_Click_1(sender As Object, e As EventArgs) Handles CMDCLEAR.Click
        CLEAR()
        EDIT = False
        CMBNAME.Focus()
    End Sub

    Sub WTCALC()
        Try
            If LCase(CMBUNIT.Text.Trim) = "reams" Then
                'get SIZE AND GSM FROM NONINV MASTER AND CALC WT
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.SEARCH("ISNULL(NONINV_LENGTH,0) AS LENGTH, ISNULL(NONINV_WIDTH,0) AS WIDTH, ISNULL(NONINV_GSM,0) AS GSM ", "", " NONINVITEMMASTER ", " AND NONINV_NAME = '" & CMBNAME.Text.Trim & "' AND NONINV_YEARID = " & YearId)
                If Val(DT.Rows(0).Item("LENGTH")) > 0 And Val(DT.Rows(0).Item("WIDTH")) > 0 And Val(DT.Rows(0).Item("GSM")) > 0 Then
                    TXTGSM.Text = Format(((((Val(DT.Rows(0).Item("LENGTH")) * Val(DT.Rows(0).Item("WIDTH")) * Val(DT.Rows(0).Item("GSM"))) / 3100) / 500) * Val(TXTREELNO.Text.Trim)) * (Val(TXTQTY.Text.Trim)), "0.000")
                End If
            End If
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

    Private Sub OpenToolStripButton_Click_1(sender As Object, e As EventArgs) Handles OpenToolStripButton.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim OBJSR As New PurchaseReturnChallanDetails
            OBJSR.MdiParent = MDIMain
            OBJSR.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
    Private Sub tooldelete_Click_1(sender As Object, e As EventArgs) Handles tooldelete.Click
        Try
            Dim IntResult As Integer
            If EDIT = True Then

                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                If lbllocked.Visible = True Then
                    MsgBox("Purchase Return Challan Locked", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                If MsgBox("Delete Purchase Return Challan?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

                Dim alParaval As New ArrayList
                alParaval.Add(Val(TXTPRCHNO.Text.Trim))
                alParaval.Add(Userid)
                alParaval.Add(YearId)

                Dim OBJSR As New ClsPurchaseReturnChallan()
                OBJSR.alParaval = alParaval
                IntResult = OBJSR.DELETE()
                MsgBox("Purchase Return Challan Deleted")
                CLEAR()
                EDIT = False

            Else
                MsgBox("Delete is only in Edit Mode")
            End If
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

    Private Sub CMBUNIT_Validated(sender As Object, e As EventArgs) Handles CMBUNIT.Validated, TXTQTY.Validated
        Try
            If CMBQUALITY.Text.Trim <> "" And Val(TXTQTY.Text.Trim) > 0 And CMBUNIT.Text.Trim <> "" Then fillgrid()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBQUALITY_Enter(sender As Object, e As EventArgs) Handles CMBQUALITY.Enter
        Try
            If CMBQUALITY.Text.Trim = "" Then fillitemname(CMBQUALITY, "")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBQUALITY_Validating(sender As Object, e As CancelEventArgs) Handles CMBQUALITY.Validating
        Try
            If CMBQUALITY.Text.Trim <> "" Then ITEMVALIDATE(CMBQUALITY, e, Me, "", "MERCHANT")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub TXTQTY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTQTY.KeyPress, TXTGSM.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub


    Private Sub tstxtbillno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTSIZE.KeyPress
        numkeypress(e, sender, Me)
    End Sub


    Private Sub CMBNAME_Enter(sender As Object, e As EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then FILLNAME(CMBNAME, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND ACC_TYPE = 'ACCOUNTS'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Validating(sender As Object, e As CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, CMBCODE, e, Me, txtadd, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "Sundry Creditors", "ACCOUNTS")
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
                    If TXTREMARKS.Text.Trim = "" Then TXTREMARKS.Text = DT.Rows(0).Item("REMARKS")
                    If DT.Rows(0).Item("WARNING") <> "" Then MsgBox(DT.Rows(0).Item("WARNING"), MsgBoxStyle.Critical)

                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub GRIDPR_KeyDown(sender As Object, e As KeyEventArgs) Handles GRIDPR.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDPR.RowCount > 0 Then

                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If

                GRIDPR.Rows.RemoveAt(GRIDPR.CurrentRow.Index)
                TOTAL()
                getsrno(GRIDPR)
                TOTAL()

            ElseIf e.KeyCode = Keys.F5 Then
                EDITROW()

            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

End Class