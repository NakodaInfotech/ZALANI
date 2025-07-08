


Imports System.ComponentModel
Imports BL


Public Class StoreConsumptionReturn

    Dim GRIDDOUBLECLICK As Boolean
    Public EDIT As Boolean
    Public TEMPCONNO, TEMPROW As Integer
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub CMDEXIT_Click_1(sender As Object, e As EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Sub CLEAR()

        tstxtbillno.Clear()
        Ep.Clear()
        TXTNARRATION.Clear()
        CONDATE.Text = Now.Date
        CMBDEPARTMENT.Text = ""
        If USERGODOWN <> "" Then cmbGodown.Text = USERGODOWN Else cmbGodown.Text = ""
        TXTCHALLANNO.Clear()
        CHALLANDATE.Value = Now.Date
        TXTSRNO.Text = 1
        CMBNONINVITEMNAME.Text = ""
        TXTRETURNEDBY.Clear()
        TXTQTY.Text = ""
        CMBUNIT.Text = ""
        GRIDPR.RowCount = 0
        TXTREMARKS.Clear()
        GRIDDOUBLECLICK = False
        GETMAXNO()
        LBLTOTALQTY.Text = 0

    End Sub

    Sub TOTAL()
        Try
            LBLTOTALQTY.Text = 0
            For Each ROW As DataGridViewRow In GRIDPR.Rows
                LBLTOTALQTY.Text = Format(Val(LBLTOTALQTY.Text) + Val(ROW.Cells(gQty.Index).EditedFormattedValue), "0.00")
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETMAXNO()
        Try
            Dim DTTABLE As New DataTable
            DTTABLE = getmax(" isnull(max(CON_no),0) + 1 ", " CONSUMPTIONRETURN ", " and CON_yearid=" & YearId)
            If DTTABLE.Rows.Count > 0 Then TXTCONNO.Text = DTTABLE.Rows(0).Item(0)
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

            If CMBDEPARTMENT.Text.Trim.Length = 0 Then
                Ep.SetError(CMBDEPARTMENT, " Please Fill Department Name ")
                bln = False
            End If


            If GRIDPR.RowCount = 0 Then
                Ep.SetError(cmbGodown, "Fill Item Details")
                bln = False
            End If

            If CONDATE.Text = "__/__/____" Then
                Ep.SetError(CONDATE, " Please Enter Proper Date")
                bln = False
            Else
                If Not datecheck(CONDATE.Text) Then
                    Ep.SetError(CONDATE, "Date not in Accounting Year")
                    bln = False
                End If

                If Convert.ToDateTime(CONDATE.Text).Date < PURRETCHBLOCKDATE.Date Then
                    Ep.SetError(CONDATE, "Date is Blocked, Please make entries after " & Format(PURRETCHBLOCKDATE.Date, "dd/MM/yyyy"))
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


            alParaval.Add(Format(Convert.ToDateTime(CONDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(CMBDEPARTMENT.Text.Trim)
            alParaval.Add(TXTRETURNEDBY.Text.Trim)
            alParaval.Add(cmbGodown.Text.Trim)
            alParaval.Add(TXTCHALLANNO.Text.Trim)
            alParaval.Add(Format(Convert.ToDateTime(CHALLANDATE.Value).Date, "MM/dd/yyyy"))
            alParaval.Add(Val(LBLTOTALQTY.Text))
            alParaval.Add(TXTREMARKS.Text.Trim)

            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)


            Dim GRIDSRNO As String = ""
            Dim NONINVITEMNAME As String = ""
            Dim NARRATION As String = ""
            Dim QTY As String = ""
            Dim UNIT As String = ""
            Dim DONE As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDPR.Rows
                If row.Cells(0).Value <> Nothing Then
                    If GRIDSRNO = "" Then
                        GRIDSRNO = Val(row.Cells(gsrno.Index).Value)
                        NONINVITEMNAME = row.Cells(gNONINVITEMNAME.Index).Value.ToString
                        NARRATION = row.Cells(gNARRATION.Index).Value.ToString
                        QTY = Val(row.Cells(gQty.Index).Value)
                        UNIT = row.Cells(GUNIT.Index).Value.ToString
                        If row.Cells(GDONE.Index).Value = True Then DONE = 1 Else DONE = 0

                    Else

                        GRIDSRNO = GRIDSRNO & "|" & Val(row.Cells(gsrno.Index).Value)
                        NONINVITEMNAME = NONINVITEMNAME & "|" & row.Cells(gNONINVITEMNAME.Index).Value.ToString
                        NARRATION = NARRATION & "|" & row.Cells(gNARRATION.Index).Value.ToString
                        QTY = QTY & "|" & Val(row.Cells(gQty.Index).Value)
                        UNIT = UNIT & "|" & row.Cells(GUNIT.Index).Value
                        If row.Cells(GDONE.Index).Value = True Then
                            DONE = DONE & "|" & "1"
                        Else
                            DONE = DONE & "|" & "0"
                        End If

                    End If
                End If
            Next

            alParaval.Add(GRIDSRNO)
            alParaval.Add(NONINVITEMNAME)
            alParaval.Add(NARRATION)
            alParaval.Add(QTY)
            alParaval.Add(UNIT)
            alParaval.Add(DONE)


            Dim OBJSR As New ClsStoreConsumptionReturn()
            OBJSR.alParaval = alParaval
            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim DTTABLE As DataTable = OBJSR.SAVE()
                MsgBox("Details Added")
                TXTCONNO.Text = Val(DTTABLE.Rows(0).Item(0))
                TEMPCONNO = Val(DTTABLE.Rows(0).Item(0))

            ElseIf EDIT = True Then
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPCONNO)
                Dim IntResult As Integer = OBJSR.UPDATE()
                MsgBox("Details Updated")
            End If
            'PRINTREPORT(TEMPPRCHNO)

            EDIT = False
            CLEAR()
            CMBDEPARTMENT.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    'Sub PRINTREPORT(ByVal SRNO As Integer)
    '    Try
    '        If MsgBox("Wish to Print Purchase Return?", MsgBoxStyle.YesNo) = vbYes Then
    '            Dim OBJPUR As New PurchaseInvoiceDesign
    '            OBJPUR.MdiParent = MDIMain
    '            OBJPUR.FRMSTRING = "PURRETURNCHALLAN"
    '            OBJPUR.PURRETNO = Val(SRNO)
    '            OBJPUR.WHERECLAUSE = "{PURCHASERETURNCHALLAN.PRCH_NO}=" & Val(SRNO) & " and {PURCHASERETURNCHALLAN.PRCH_yearid}=" & YearId
    '            OBJPUR.Show()
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Private Sub ConsumptionReturn_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
                Call OpenToolStripButton_Click(sender, e)
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

    Private Sub ConsumptionReturn_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'STORES'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            Cursor.Current = Cursors.WaitCursor

            FILLCMB()
            CLEAR()
            CMBDEPARTMENT.Enabled = True


            If EDIT = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim OBJSR As New ClsStoreConsumptionReturn()
                OBJSR.alParaval.Add(TEMPCONNO)
                OBJSR.alParaval.Add(YearId)
                Dim dttable As DataTable = OBJSR.SELECTCONSUMPTIONRETURN()
                If dttable.Rows.Count > 0 Then

                    For Each dr As DataRow In dttable.Rows

                        TXTCONNO.Text = TEMPCONNO
                        TXTCONNO.ReadOnly = True

                        CONDATE.Text = Format(Convert.ToDateTime(dr("DATE")).Date, "dd/MM/yyyy")
                        CMBDEPARTMENT.Text = Convert.ToString(dr("DEPARTMENT"))
                        TXTRETURNEDBY.Text = dr("RETURNEDBY")
                        cmbGodown.Text = dr("GODOWN")
                        TXTCHALLANNO.Text = dr("CHALLANNO")
                        CHALLANDATE.Value = Format(Convert.ToDateTime(dr("CHALLANDATE")).Date, "dd/MM/yyyy")

                        LBLTOTALQTY.Text = Format(Val(dr("TOTALQTY")), "0.00")
                        TXTREMARKS.Text = Convert.ToString(dr("remarks").ToString)


                        'Item Grid
                        GRIDPR.Rows.Add(dr("GRIDSRNO").ToString, dr("NONINVITEMNAME"), dr("NARRATION").ToString, Format(Val(dr("qty")), "0.00"), dr("UNIT").ToString, dr("GRIDDONE"))

                    Next

                    TOTAL()
                    'GRIDPR.FirstDisplayedScrollingRowIndex = GRIDPR.RowCount - 1
                Else
                    EDIT = False
                    CLEAR()
                End If

            End If

            'TXTSRNO.Text = GRIDPR.RowCount

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLCMB()
        Try
            If CMBDEPARTMENT.Text.Trim = "" Then fillname(CMBDEPARTMENT, EDIT, " And GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors'")
            If cmbGodown.Text.Trim = "" Then fillGODOWN(cmbGodown, EDIT)
            FILLUNIT(CMBUNIT)
            FILLSTOREITEMNAME(CMBNONINVITEMNAME)
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
                TEMPCONNO = Val(tstxtbillno.Text)
                If TEMPCONNO > 0 Then
                    EDIT = True
                    ConsumptionReturn_Load(sender, e)
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
                GRIDPR.Rows.Add(Val(TXTSRNO.Text.Trim), CMBNONINVITEMNAME.Text.Trim, TXTNARRATION.Text.Trim, Format(Val(TXTQTY.Text.Trim), "0.00"), CMBUNIT.Text.Trim, 0)
                getsrno(GRIDPR)

            ElseIf GRIDDOUBLECLICK = True Then
                GRIDPR.Item(gsrno.Index, TEMPROW).Value = Val(TXTSRNO.Text.Trim)
                GRIDPR.Item(gNONINVITEMNAME.Index, TEMPROW).Value = CMBNONINVITEMNAME.Text.Trim
                GRIDPR.Item(gNARRATION.Index, TEMPROW).Value = TXTNARRATION.Text.Trim
                GRIDPR.Item(gQty.Index, TEMPROW).Value = Val(TXTQTY.Text.Trim)
                GRIDPR.Item(GUNIT.Index, TEMPROW).Value = CMBUNIT.Text.Trim

                GRIDDOUBLECLICK = False
            End If

            GRIDPR.FirstDisplayedScrollingRowIndex = GRIDPR.RowCount - 1
            TXTSRNO.Text = GRIDPR.RowCount + 1
            CMBNONINVITEMNAME.Text = ""
            TXTNARRATION.Clear()
            TXTQTY.Clear()
            CMBUNIT.Text = ""

            CMBNONINVITEMNAME.Focus()
            TOTAL()
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
            TEMPCONNO = Val(TXTCONNO.Text) - 1
            If TEMPCONNO > 0 Then
                EDIT = True
                ConsumptionReturn_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
            If GRIDPR.RowCount = 0 And TEMPCONNO > 1 Then
                TXTCONNO.Text = TEMPCONNO
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
            TEMPCONNO = Val(TXTCONNO.Text) + 1
            GETMAXNO()
            Dim MAXNO As Integer = TXTCONNO.Text.Trim
            CLEAR()
            If Val(TXTCONNO.Text) - 1 >= TEMPCONNO Then
                EDIT = True
                ConsumptionReturn_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
            If GRIDPR.RowCount = 0 And TEMPCONNO < MAXNO Then
                TXTCONNO.Text = TEMPCONNO
                GoTo LINE1
            End If
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

                If MsgBox("Delete Consumption Return ?", MsgBoxStyle.YesNo) = vbYes Then
                    Dim alParaval As New ArrayList
                    alParaval.Add(TXTCONNO.Text.Trim)
                    alParaval.Add(YearId)

                    Dim ClsDO As New ClsStoreConsumptionReturn
                    ClsDO.alParaval = alParaval
                    Dim IntResult As Integer = ClsDO.DELETE()
                    MsgBox("Entry Deleted Successfully")
                    CLEAR()
                    EDIT = False
                End If
            Else
                MsgBox("Delete is only in Edit Mode")
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
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

    Private Sub GRIDPR_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles GRIDPR.CellValidating
        Try
            Dim colNum As Integer = GRIDPR.Columns(e.ColumnIndex).Index
            If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return

            Select Case colNum

                Case gQty.Index
                    Dim dDebit As Decimal
                    Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                    If bValid Then
                        If GRIDPR.CurrentCell.Value = Nothing Then GRIDPR.CurrentCell.Value = "0.00"
                        GRIDPR.CurrentCell.Value = Convert.ToDecimal(GRIDPR.Item(colNum, e.RowIndex).Value)
                        ' everything is good
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

    Sub EDITROW()
        Try
            If GRIDPR.CurrentRow.Index >= 0 And GRIDPR.Item(gsrno.Index, GRIDPR.CurrentRow.Index).Value <> Nothing Then

                GRIDDOUBLECLICK = True
                TXTSRNO.Text = GRIDPR.Item(gsrno.Index, GRIDPR.CurrentRow.Index).Value.ToString
                CMBNONINVITEMNAME.Text = GRIDPR.Item(gNONINVITEMNAME.Index, GRIDPR.CurrentRow.Index).Value.ToString
                TXTNARRATION.Text = GRIDPR.Item(gNARRATION.Index, GRIDPR.CurrentRow.Index).Value.ToString
                TXTQTY.Text = GRIDPR.Item(gQty.Index, GRIDPR.CurrentRow.Index).Value.ToString
                CMBUNIT.Text = GRIDPR.Item(GUNIT.Index, GRIDPR.CurrentRow.Index).Value.ToString

                TEMPROW = GRIDPR.CurrentRow.Index
                CMBNONINVITEMNAME.Focus()
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

    Private Sub cmbitemname_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJItem As New SelectItem
                OBJItem.FRMSTRING = "MERCHANT"
                OBJItem.STRSEARCH = " and ITEM_YEARid = " & YearId
                OBJItem.ShowDialog()
                If OBJItem.TEMPNAME <> "" Then CMBNONINVITEMNAME.Text = OBJItem.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDEPARTMENT_KeyDown(sender As Object, e As KeyEventArgs) Handles CMBDEPARTMENT.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and GROUPMASTER.GROUP_SECONDARY = 'Sundry debtors'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPNAME <> "" Then CMBDEPARTMENT.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDCLEAR_Click(sender As Object, e As EventArgs) Handles CMDCLEAR.Click
        CLEAR()
        EDIT = False
        CMBDEPARTMENT.Focus()
    End Sub

    Private Sub CMBUNIT_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBUNIT.Enter
        Try
            If CMBUNIT.Text.Trim = "" Then FILLUNIT(CMBUNIT)
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

            Dim OBJSR As New StoreConsumptionReturnDetails
            OBJSR.MdiParent = MDIMain
            OBJSR.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub tooldelete_Click_1(sender As Object, e As EventArgs) Handles tooldelete.Click
        Try
            Call CMDDELETE_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBUNIT_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBUNIT.Validating
        Try
            If CMBUNIT.Text.Trim <> "" Then unitvalidate(CMBUNIT, e, Me)
            fillgrid()
            CMBNONINVITEMNAME.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTQTY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTQTY.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub CMBDEPARTMENT_Enter(sender As Object, e As EventArgs) Handles CMBDEPARTMENT.Enter
        Try
            If CMBDEPARTMENT.Text.Trim = "" Then filldepartment(CMBDEPARTMENT, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBDEPARTMENT_Validating(sender As Object, e As CancelEventArgs) Handles CMBDEPARTMENT.Validating
        Try
            If CMBDEPARTMENT.Text.Trim <> "" Then DEPARTMENTVALIDATE(CMBDEPARTMENT, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNONINVITEMNAME_Enter(sender As Object, e As EventArgs) Handles CMBNONINVITEMNAME.Enter
        Try
            If CMBNONINVITEMNAME.Text.Trim = "" Then FILLSTOREITEMNAME(CMBNONINVITEMNAME)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNONINVITEMNAME_Validating(sender As Object, e As CancelEventArgs) Handles CMBNONINVITEMNAME.Validating
        Try
            If CMBNONINVITEMNAME.Text.Trim <> "" Then STOREITEMVALIDATE(CMBNONINVITEMNAME, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tstxtbillno.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub CMBNONINVITEMNAME_Validated(sender As Object, e As EventArgs) Handles CMBNONINVITEMNAME.Validated
        Try
            If CMBNONINVITEMNAME.Text.Trim <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.SEARCH("UNIT_ABBR AS UNIT", "", " STOREITEMMASTER INNER JOIN UNITMASTER ON STOREITEM_UNITID = UNITMASTER.UNIT_ID", " AND STOREITEM_NAME = '" & CMBNONINVITEMNAME.Text.Trim & "' AND STOREITEM_YEARID = " & YearId)
                If DT.Rows.Count > 0 And CMBUNIT.Text.Trim = "" Then CMBUNIT.Text = DT.Rows(0).Item("UNIT")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class