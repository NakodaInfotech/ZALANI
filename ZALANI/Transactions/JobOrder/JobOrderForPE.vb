Imports System.ComponentModel
Imports BL
Public Class JobOrderForPE
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE, GRIDDOUBLECLICK As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public EDIT As Boolean          'used for editing
    Public TEMPJONO As String
    Public TEMPMSG As Integer
    Dim TEMPROW As Integer


    Private Sub cmdexit_Click(sender As Object, e As EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdclear_Click(sender As Object, e As EventArgs) Handles cmdclear.Click
        clear()
        EDIT = False
    End Sub

    Sub clear()
        TXTJONO.ReadOnly = True
        CMBDESTINATION.Text = ""
        CMBSHIPTO.Text = ""
        CMBPORTLOADING.Text = ""
        CMBPORTDISCHARGE.Text = ""
        CMBCURRENCY.Text = ""
        CMBCIFFOB.Text = ""
        CMBBANKDETAILS.Text = ""
        TXTPROFORMANO.Clear()
        TXTREMARKS.Clear()
        GRIDJO.RowCount = 0
        txtsrno.Clear()
        LBLTOTALQTY.Text = 0
        CMBFINISHED.Text = ""
        TXTDESC.Text = ""
        TXTGSM.Clear()
        TXTSIZE.Clear()
        CMBFOIL.Text = ""
        TXTFOILGSM.Clear()
        TXTPEGSM.Clear()
        TXTSONO.Clear()
        TXTROLLDIAMETER.Clear()
        TXTCOREPIPEWIDTH.Clear()
        CMBPALLETIZED.Text = ""
        TXTNARRATION.Clear()
        TXTQTY.Clear()
        CMBUNIT.Text = ""
        TXTREMARKS.Clear()
        CMBNAME.Text = ""
        getmax_JONO()
        txtsrno.Text = 1
        tstxtbillno.Clear()
        DTDATE.Text = Now.Date
        DTSODATE.Text = Now.Date
        TXTSOTYPE.Clear()
        LBLCLOSED.Visible = False
        cmdselectso.Enabled = True
        PBlock.Visible = False
        lbllocked.Visible = False
        GRIDDOUBLECLICK = False
        CMBNAME.Enabled = True
        TXTGSMDETAILS.Clear()
        TXTSIZEDETAILS.Clear()
        TXTMOTHERSIZE.Clear()
        TXTWASTAGEPER.Clear()

    End Sub

    Private Sub JobOrderForPE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow

            DTROW = USERRIGHTS.Select("FormName = 'JOB WORK'")

            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)
            Cursor.Current = Cursors.WaitCursor

            FILLCMB()
            clear()
            TOTAL()


            If EDIT = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim OBJCMN As New ClsCommon
                Dim OBJCLSINCENTIVE As New ClsJobOrderForPE
                Dim dttable As New DataTable

                dttable = OBJCLSINCENTIVE.selectJOPE(TEMPJONO, CmpId, YearId)
                If dttable.Rows.Count > 0 Then

                    For Each dr As DataRow In dttable.Rows

                        TXTJONO.Text = TEMPJONO
                        TXTJONO.ReadOnly = True
                        DTDATE.Text = Format(Convert.ToDateTime(dr("DATE")), "dd/MM/yyyy")
                        CMBNAME.Text = Convert.ToString(dr("NAME"))
                        CMBPORTDISCHARGE.Text = Convert.ToString(dr("PORTDISCHARGE"))
                        CMBPORTLOADING.Text = Convert.ToString(dr("PORTLOADING"))
                        CMBDESTINATION.Text = Convert.ToString(dr("DESTINATION"))
                        CMBCIFFOB.Text = Convert.ToString(dr("CIFFOB"))
                        CMBCURRENCY.Text = Convert.ToString(dr("CURRENCY"))
                        CMBBANKDETAILS.Text = Convert.ToString(dr("BANKDETAILS"))
                        CMBSHIPTO.Text = dr("SHIPTO")
                        TXTPROFORMANO.Text = dr("PROFORMANO")
                        TXTSONO.Text = dr("SONO")

                        TXTSOTYPE.Text = dr("SOTYPE")
                        DTSODATE.Text = Format(Convert.ToDateTime(dr("SODATE")), "dd/MM/yyyy")
                        TXTREMARKS.Text = dr("REMARKS")
                        LBLTOTALQTY.Text = dr("TOTALQTY")
                        TXTWASTAGEPER.Text = dr("WASTAGEPER")




                        GRIDJO.Rows.Add(Val(dr("GRIDSRNO")), dr("FINISHEDQUALITY"), dr("GRIDDESC"), dr("GSM"), dr("GSMDETAILS"), dr("MOTHERSIZE"), dr("SIZE"), dr("SIZEDETAILS"), dr("FOILQUALITY"), dr("FOILGSM"), dr("PEGSM"), dr("ROLLDIAMETER"), dr("COREPIPEWIDTH"), dr("PALLETIZED"), dr("NARRATION"), Format(Val(dr("QTY")), "0.00"), dr("UNIT"), dr("CLOSED"), dr("READYQTY"), Val(dr("FROMNO")), Val(dr("FROMSRNO")), dr("TYPE"), dr("PRODISSDONE"))
                        If Convert.ToBoolean(dr("CLOSED")) Or Convert.ToBoolean(dr("PRODISSDONE")) = True Then
                            GRIDJO.Rows(GRIDJO.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                            lbllocked.Visible = True
                            If Convert.ToBoolean(dr("CLOSED")) = True Then LBLCLOSED.Visible = True
                            PBlock.Visible = True
                        End If

                    Next


                    GRIDJO.FirstDisplayedScrollingRowIndex = GRIDJO.RowCount - 1
                    GRIDJO.FirstDisplayedScrollingRowIndex = GRIDJO.RowCount - 1
                    TOTAL()
                    DTDATE.Focus()
                    cmdselectso.Enabled = False

                Else
                    EDIT = False
                    clear()
                End If
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub cmdok_Click(sender As Object, e As EventArgs) Handles cmdok.Click
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
            If TXTJONO.ReadOnly = False Then
                alParaval.Add(Val(TXTJONO.Text.Trim))
            Else
                alParaval.Add(0)
            End If


            alParaval.Add(Format(Convert.ToDateTime(DTDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(CMBNAME.Text.Trim)
            alParaval.Add(CMBPORTDISCHARGE.Text.Trim)
            alParaval.Add(CMBPORTLOADING.Text.Trim)
            alParaval.Add(CMBDESTINATION.Text.Trim)
            alParaval.Add(CMBCIFFOB.Text.Trim)
            alParaval.Add(CMBCURRENCY.Text.Trim)
            alParaval.Add(CMBSHIPTO.Text.Trim)
            alParaval.Add(TXTPROFORMANO.Text.Trim)
            alParaval.Add(TXTSONO.Text.Trim)

            alParaval.Add(TXTSOTYPE.Text.Trim)
            alParaval.Add(Format(Convert.ToDateTime(DTSODATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(CMBBANKDETAILS.Text.Trim)
            alParaval.Add(TXTREMARKS.Text.Trim)
            alParaval.Add(Val(LBLTOTALQTY.Text.Trim))
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


            For Each row As Windows.Forms.DataGridViewRow In GRIDJO.Rows
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
                        ROLLDIEAMETER = row.Cells(GROLLDIAMETER.Index).Value.ToString
                        COREPIPEWIDTH = row.Cells(GCOREPIPEWIDTH.Index).Value.ToString
                        PALLETIZED = row.Cells(GPALLETIZED.Index).Value.ToString
                        NARRATION = row.Cells(GNARRATION.Index).Value.ToString
                        QTY = Val(row.Cells(GQTY.Index).Value)
                        UNIT = row.Cells(GUNIT.Index).Value.ToString
                        If Convert.ToBoolean(row.Cells(GCLOSED.Index).Value) = True Then CLOSED = 1 Else CLOSED = 0
                        READYQTY = Val(row.Cells(GREADYQTY.Index).Value)
                        FROMNO = Val(row.Cells(GFROMNO.Index).Value)
                        FROMSRNO = Val(row.Cells(GFROMSRNO.Index).Value)
                        TYPE = row.Cells(GTYPE.Index).Value.ToString
                        If Convert.ToBoolean(row.Cells(GPRODISSDONE.Index).Value) = True Then PRODISSDONE = 1 Else PRODISSDONE = 0

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
                        ROLLDIEAMETER = ROLLDIEAMETER & "|" & row.Cells(GROLLDIAMETER.Index).Value.ToString
                        COREPIPEWIDTH = COREPIPEWIDTH & "|" & row.Cells(GCOREPIPEWIDTH.Index).Value.ToString
                        PALLETIZED = PALLETIZED & "|" & row.Cells(GPALLETIZED.Index).Value.ToString
                        NARRATION = NARRATION & "|" & row.Cells(GNARRATION.Index).Value.ToString
                        QTY = QTY & "|" & Val(row.Cells(GQTY.Index).Value)
                        UNIT = UNIT & "|" & row.Cells(GUNIT.Index).Value.ToString
                        If Convert.ToBoolean(row.Cells(GCLOSED.Index).Value) = True Then CLOSED = CLOSED & "|" & "1" Else CLOSED = CLOSED & "|" & "0"
                        READYQTY = READYQTY & "|" & Val(row.Cells(GREADYQTY.Index).Value)
                        FROMNO = FROMNO & "|" & Val(row.Cells(GFROMNO.Index).Value)
                        FROMSRNO = FROMSRNO & "|" & Val(row.Cells(GFROMSRNO.Index).Value)
                        TYPE = TYPE & "|" & row.Cells(GTYPE.Index).Value.ToString
                        If Convert.ToBoolean(row.Cells(GPRODISSDONE.Index).Value) = True Then PRODISSDONE = PRODISSDONE & "|" & "1" Else PRODISSDONE = PRODISSDONE & "|" & "0"

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

            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim DT As DataTable = objclsPurord.SAVE()
                MessageBox.Show("Details Added")
                TXTJONO.Text = DT.Rows(0).Item(0)
            Else


                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPJONO)
                IntResult = objclsPurord.UPDATE()
                MessageBox.Show("Details Updated")
                EDIT = False
            End If

            PRINTREPORT(Val(TXTJONO.Text.Trim))
            clear()
            CMBNAME.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub PRINTREPORT(ByVal JOBNO As Integer)
        Try
            If MsgBox("Wish to Print Job Order?", MsgBoxStyle.YesNo) = vbNo Then Exit Sub
            Dim OBJJO As New JobOrderDesign
            OBJJO.FRMSTRING = "JOPE"
            OBJJO.JOBNO = TXTSONO.Text
            'OBJJO.JOBSRNO = Dim row As DataGridViewRow = GRIDJO.Rows(GFROMSRNO.Index)
            Dim selectedRow As DataGridViewRow = GRIDJO.CurrentRow
            If selectedRow IsNot Nothing Then
                OBJJO.JOBSRNO = selectedRow.Cells(GFROMSRNO.Index).Value.ToString()
            End If
            OBJJO.MdiParent = MDIMain
            OBJJO.Show()
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

        If DTDATE.Text = "__/__/____" Then
            EP.SetError(DTDATE, " Please Enter Proper Date")
            bln = False
        Else
            If Not datecheck(DTDATE.Text) Then
                EP.SetError(DTDATE, "Date not in Accounting Year")
                bln = False
            End If
        End If

        If GRIDJO.RowCount = 0 Then
            EP.SetError(CMBNAME, " Please Enter Item Details ")
            bln = False
        End If



        Return bln
    End Function

    Private Sub cmddelete_Click(sender As Object, e As EventArgs) Handles cmddelete.Click

        Dim IntResult As Integer
        Try

            If EDIT = True Then
                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                If lbllocked.Visible = True Then
                    MsgBox("Unable To Delete, Order Is Locked ", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                TEMPMSG = MsgBox("Delete Job Order For Extrusion?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim alParaval As New ArrayList
                    alParaval.Add(TXTJONO.Text.Trim)
                    alParaval.Add(Userid)
                    alParaval.Add(CmpId)
                    alParaval.Add(YearId)

                    Dim ClsINCTAG As New ClsJobOrderForPE()
                    ClsINCTAG.alParaval = alParaval
                    IntResult = ClsINCTAG.Delete()
                    MsgBox("Job Order For Extrusion Deleted")
                    clear()
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
            GRIDJO.RowCount = 0
LINE1:
            TEMPJONO = Val(TXTJONO.Text) - 1
            If TEMPJONO > 0 Then
                EDIT = True
                JobOrderForPE_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If

            If GRIDJO.RowCount = 0 And TEMPJONO > 1 Then
                TXTJONO.Text = TEMPJONO
                GoTo LINE1
            End If
            CMBNAME.Enabled = False
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(sender As Object, e As EventArgs) Handles toolnext.Click
        Try
            GRIDJO.RowCount = 0
LINE1:
            TEMPJONO = Val(TXTJONO.Text) + 1
            getmax_JONO()
            Dim MAXNO As Integer = TXTJONO.Text.Trim
            clear()
            If Val(TXTJONO.Text) - 1 >= TEMPJONO Then
                EDIT = True
                JobOrderForPE_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDJO.RowCount = 0 And TEMPJONO < MAXNO Then
                TXTJONO.Text = TEMPJONO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub getmax_JONO()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(JO_NO),0) + 1 ", "JOBORDERFORPE", "  AND JO_cmpid=" & CmpId & " and JO_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTJONO.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Private Sub OpenToolStripButton_Click(sender As Object, e As EventArgs) Handles OpenToolStripButton.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim objINVDTLS As New JobOrderForPEDetails
            objINVDTLS.MdiParent = MDIMain
            objINVDTLS.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(sender As Object, e As EventArgs) Handles SaveToolStripButton.Click
        Try
            Call cmdok_Click(sender, e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDJO_KeyDown(sender As Object, e As KeyEventArgs) Handles GRIDJO.KeyDown
        Try
            If Convert.ToBoolean(GRIDJO.Rows(GRIDJO.CurrentRow.Index).Cells(GCLOSED.Index).Value) = True Then
                MsgBox("Item Locked", MsgBoxStyle.Critical)
                Exit Sub
            End If
            If e.KeyCode = Keys.Delete And GRIDJO.RowCount > 0 Then

                'dont allow user if any of the grid line is in edit mode.....
                'cmbMERCHANT.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                GRIDJO.Rows.RemoveAt(GRIDJO.CurrentRow.Index)
                TOTAL()
                getsrno(GRIDJO)
            ElseIf e.KeyCode = Keys.F5 Then
                EDITROW()
            ElseIf e.KeyCode = Keys.F12 And GRIDJO.RowCount > 0 Then
                If GRIDJO.CurrentRow.Cells(GFINISHEDQUALITY.Index).Value <> "" Then GRIDJO.Rows.Add(CloneWithValues(GRIDJO.CurrentRow))
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
    Public Function CloneWithValues(ByVal row As DataGridViewRow) As DataGridViewRow
        CloneWithValues = CType(row.Clone(), DataGridViewRow)
        For index As Int32 = 0 To row.Cells.Count - 1
            CloneWithValues.Cells(index).Value = row.Cells(index).Value
        Next
    End Function

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

    Private Sub JobOrderForPE_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.E Then
                Call cmdselectso_Click(sender, e)
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.F5 Then
                GRIDJO.Focus()
            ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for Delete
                tstxtbillno.Focus()
                tstxtbillno.SelectAll()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Sub Fillgrid()
        Try
            If GRIDDOUBLECLICK = False Then
                GRIDJO.Rows.Add(Val(txtsrno.Text.Trim), CMBFINISHED.Text.Trim, TXTDESC.Text.Trim, TXTGSM.Text.Trim, TXTGSMDETAILS.Text.Trim, TXTMOTHERSIZE.Text.Trim, TXTSIZE.Text.Trim, TXTSIZEDETAILS.Text.Trim, CMBFOIL.Text.Trim, TXTFOILGSM.Text.Trim, TXTPEGSM.Text.Trim, TXTROLLDIAMETER.Text.Trim, TXTCOREPIPEWIDTH.Text.Trim, CMBPALLETIZED.Text.Trim, TXTNARRATION.Text.Trim, Format(Val(TXTQTY.Text.Trim), "0.00"), CMBUNIT.Text.Trim, 0, 0, 0, 0, "", 0)
                getsrno(GRIDJO)
            ElseIf GRIDDOUBLECLICK = True Then
                GRIDJO.Item(GSRNO.Index, TEMPROW).Value = Val(txtsrno.Text.Trim)
                GRIDJO.Item(GFINISHEDQUALITY.Index, TEMPROW).Value = CMBFINISHED.Text.Trim
                GRIDJO.Item(GDESC.Index, TEMPROW).Value = TXTDESC.Text.Trim
                GRIDJO.Item(GGSM.Index, TEMPROW).Value = (TXTGSM.Text.Trim)
                GRIDJO.Item(GGSMDETAILS.Index, TEMPROW).Value = (TXTGSMDETAILS.Text.Trim)
                GRIDJO.Item(GMOTHERSIZE.Index, TEMPROW).Value = (TXTMOTHERSIZE.Text.Trim)
                GRIDJO.Item(GSIZE.Index, TEMPROW).Value = TXTSIZE.Text.Trim
                GRIDJO.Item(GSIZEDETAILS.Index, TEMPROW).Value = (TXTSIZEDETAILS.Text.Trim)
                GRIDJO.Item(GFOILQUALITY.Index, TEMPROW).Value = (CMBFOIL.Text.Trim)
                GRIDJO.Item(GFOILGSM.Index, TEMPROW).Value = (TXTFOILGSM.Text.Trim)
                GRIDJO.Item(GPEGSM.Index, TEMPROW).Value = (TXTPEGSM.Text.Trim)
                GRIDJO.Item(GROLLDIAMETER.Index, TEMPROW).Value = (TXTROLLDIAMETER.Text.Trim)
                GRIDJO.Item(GCOREPIPEWIDTH.Index, TEMPROW).Value = (TXTCOREPIPEWIDTH.Text.Trim)
                GRIDJO.Item(GPALLETIZED.Index, TEMPROW).Value = CMBPALLETIZED.Text.Trim
                GRIDJO.Item(GNARRATION.Index, TEMPROW).Value = (TXTNARRATION.Text.Trim)
                GRIDJO.Item(GQTY.Index, TEMPROW).Value = Format(Val(TXTQTY.Text.Trim), "0.00")
                GRIDJO.Item(GUNIT.Index, TEMPROW).Value = (CMBUNIT.Text.Trim)



                GRIDDOUBLECLICK = False

            End If
            TOTAL()
            GRIDJO.FirstDisplayedScrollingRowIndex = GRIDJO.RowCount - 1

            txtsrno.Text = GRIDJO.RowCount + 1
            CMBFINISHED.Text = ""
            TXTDESC.Text = ""
            TXTGSM.Clear()
            TXTGSMDETAILS.Clear()
            TXTSIZE.Clear()
            TXTSIZEDETAILS.Clear()
            CMBFOIL.Text = ""
            TXTFOILGSM.Clear()
            TXTPEGSM.Clear()
            TXTROLLDIAMETER.Clear()
            TXTCOREPIPEWIDTH.Clear()
            CMBPALLETIZED.Text = ""
            TXTNARRATION.Clear()
            TXTQTY.Clear()
            CMBUNIT.Text = ""
            TXTMOTHERSIZE.Clear()


            txtsrno.Focus()
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
    Private Sub CMBCURRENCY_Validating(sender As Object, e As CancelEventArgs) Handles CMBCURRENCY.Validating
        Try
            If CMBCURRENCY.Text <> "" Then CURRENCYVALIDATE(CMBCURRENCY, e, Me)
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

    Private Sub tstxtbillno_Validating(sender As Object, e As CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                GRIDJO.RowCount = 0
                TEMPJONO = Val(tstxtbillno.Text)
                If TEMPJONO > 0 Then
                    EDIT = True
                    JobOrderForPE_Load(sender, e)
                    TOTAL()

                Else
                    clear()
                    EDIT = False
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub EDITROW()
        Try
            If GRIDJO.CurrentRow.Index >= 0 And GRIDJO.Item(GSRNO.Index, GRIDJO.CurrentRow.Index).Value <> Nothing Then

                GRIDDOUBLECLICK = True
                txtsrno.Text = GRIDJO.Item(GSRNO.Index, GRIDJO.CurrentRow.Index).Value.ToString
                CMBFINISHED.Text = GRIDJO.Item(GFINISHEDQUALITY.Index, GRIDJO.CurrentRow.Index).Value.ToString
                TXTDESC.Text = GRIDJO.Item(GDESC.Index, GRIDJO.CurrentRow.Index).Value.ToString
                TXTGSM.Text = GRIDJO.Item(GGSM.Index, GRIDJO.CurrentRow.Index).Value.ToString
                TXTGSMDETAILS.Text = GRIDJO.Item(GGSMDETAILS.Index, GRIDJO.CurrentRow.Index).Value.ToString
                TXTMOTHERSIZE.Text = GRIDJO.Item(GMOTHERSIZE.Index, GRIDJO.CurrentRow.Index).Value.ToString

                TXTSIZE.Text = GRIDJO.Item(GSIZE.Index, GRIDJO.CurrentRow.Index).Value.ToString
                TXTSIZEDETAILS.Text = GRIDJO.Item(GSIZEDETAILS.Index, GRIDJO.CurrentRow.Index).Value.ToString
                CMBFOIL.Text = GRIDJO.Item(GFOILQUALITY.Index, GRIDJO.CurrentRow.Index).Value.ToString
                TXTFOILGSM.Text = GRIDJO.Item(GFOILGSM.Index, GRIDJO.CurrentRow.Index).Value.ToString
                TXTPEGSM.Text = GRIDJO.Item(GPEGSM.Index, GRIDJO.CurrentRow.Index).Value.ToString
                TXTROLLDIAMETER.Text = GRIDJO.Item(GROLLDIAMETER.Index, GRIDJO.CurrentRow.Index).Value.ToString
                TXTCOREPIPEWIDTH.Text = GRIDJO.Item(GCOREPIPEWIDTH.Index, GRIDJO.CurrentRow.Index).Value.ToString

                CMBPALLETIZED.Text = GRIDJO.Item(GPALLETIZED.Index, GRIDJO.CurrentRow.Index).Value.ToString
                TXTNARRATION.Text = GRIDJO.Item(GNARRATION.Index, GRIDJO.CurrentRow.Index).Value.ToString
                TXTQTY.Text = GRIDJO.Item(GQTY.Index, GRIDJO.CurrentRow.Index).Value.ToString
                CMBUNIT.Text = GRIDJO.Item(GUNIT.Index, GRIDJO.CurrentRow.Index).Value.ToString

                TEMPROW = GRIDJO.CurrentRow.Index
                TXTDESC.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DTDATE_GotFocus(sender As Object, e As EventArgs) Handles DTDATE.GotFocus
        DTDATE.SelectionStart = 0
    End Sub

    Private Sub GRIDJO_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRIDJO.CellDoubleClick
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

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Call cmddelete_Click(sender, e)
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

    Private Sub CMBPORTLOADING_Validating(sender As Object, e As CancelEventArgs) Handles CMBPORTLOADING.Validating
        Try
            If CMBPORTLOADING.Text.Trim <> "" Then portvalidate(CMBPORTLOADING, e, Me)
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

    Private Sub cmdselectso_Click(sender As Object, e As EventArgs) Handles cmdselectso.Click
        Try
            EP.Clear()
            If CMBNAME.Text.Trim = "" Then
                MsgBox("Please Fill Party Name", MsgBoxStyle.Critical)
                CMBNAME.Focus()
                Exit Sub
            End If

            Dim OBJSO As New SelectSO
            OBJSO.PARTYNAME = CMBNAME.Text.Trim
            OBJSO.FRMSTRING = "SOPE"
            Dim DT As DataTable = OBJSO.DT
            OBJSO.ShowDialog()

            If DT.Rows.Count > 0 Then
                'FETCH DATA FROM SALEORDER_DESC WITH RESPECT TO SELECTED SONO
                CMBNAME.Text = DT.Rows(0).Item("NAME")
                TXTSONO.Text = Val(DT.Rows(0).Item("SONO"))

                DTSODATE.Text = DT.Rows(0).Item("DATE")
                CMBSHIPTO.Text = DT.Rows(0).Item("SHIPTO")
                TXTSOTYPE.Text = DT.Rows(0).Item("TYPE")
                CMBPORTDISCHARGE.Text = DT.Rows(0).Item("PORTDISCHARGE")
                CMBPORTLOADING.Text = DT.Rows(0).Item("PORTLOADING")
                CMBCURRENCY.Text = DT.Rows(0).Item("CURRENCY")
                TXTPROFORMANO.Text = DT.Rows(0).Item("PROFORMANO")
                CMBCIFFOB.Text = DT.Rows(0).Item("CIFFOB")
                CMBBANKDETAILS.Text = DT.Rows(0).Item("BANKDETAILS")
                CMBDESTINATION.Text = DT.Rows(0).Item("DESTINATION")
                TXTWASTAGEPER.Text = DT.Rows(0).Item("WASTAGEPER")

                For Each ROW As DataRow In DT.Rows
                    Dim OBJCMN As New ClsCommon
                    Dim DTSO As DataTable = OBJCMN.SEARCH("ISNULL(ITEMMASTER.ITEM_NAME, '') AS FINISHEDQUALITY, ISNULL(ALLSALEORDER_DESC.SO_GSM, 0) AS GSM, ISNULL(ALLSALEORDER_DESC.SO_GSMDETAILS, '') AS GSMDETAILS, ISNULL(ALLSALEORDER_DESC.SO_SIZE, 0) AS SIZE, ISNULL(ALLSALEORDER_DESC.SO_SIZEDETAILS, '') AS SIZEDETAILS, ISNULL(FOILITEMMASTER.ITEM_NAME, '') AS FOILQUALITY, ISNULL(ALLSALEORDER_DESC.SO_FOILGSM, '') AS FOILGSM, ISNULL(ALLSALEORDER_DESC.SO_PEGSM, '') AS PEGSM, ISNULL(ALLSALEORDER_DESC.SO_ROLLDIAMETER, '') AS ROLLDIAMETER, ISNULL(ALLSALEORDER_DESC.SO_COREPIPEWIDTH, '') AS COREPIPEWIDTH, ISNULL(ALLSALEORDER_DESC.SO_PALLETIZED, '') AS PALLETIZED, ISNULL(ALLSALEORDER_DESC.SO_NARRATION, '') AS NARRATION, ISNULL(ALLSALEORDER_DESC.SO_QTY - ALLSALEORDER_DESC.SO_JOQTYPE, 0) AS QTY, ISNULL(ALLSALEORDER_DESC.SO_GRIDSRNO, 0) AS GRIDSRNO, ISNULL(ALLSALEORDER_DESC.SO_DESC, '') AS GRIDDESC, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT,ISNULL(ALLSALEORDER_DESC.SO_NO, 0) AS SONO , ISNULL(ALLSALEORDER_DESC.TYPE, '') AS TYPE,  ISNULL(ALLSALEORDER_DESC.SO_MOTHERSIZE, 0) AS MOTHERSIZE ", "", "  ALLSALEORDER_DESC LEFT OUTER JOIN UNITMASTER ON ALLSALEORDER_DESC.SO_UNITID = UNITMASTER.unit_id INNER JOIN ITEMMASTER ON ITEMMASTER.item_id = ALLSALEORDER_DESC.SO_FINISHEDQUALITYID LEFT OUTER JOIN ITEMMASTER AS FOILITEMMASTER ON FOILITEMMASTER.item_id = ALLSALEORDER_DESC.SO_FOILQUALITYID", " AND ALLSALEORDER_DESC.SO_NO = " & Val(TXTSONO.Text.Trim) & " AND ALLSALEORDER_DESC.SO_GRIDSRNO = " & Val(ROW("GRIDSRNO")) & " AND ALLSALEORDER_DESC.TYPE = '" & TXTSOTYPE.Text.Trim & "' AND ALLSALEORDER_DESC.SO_YEARID = " & YearId)
                    For Each DTROW As DataRow In DTSO.Rows
                        GRIDJO.Rows.Add(0, DTROW("FINISHEDQUALITY").ToString, DTROW("GRIDDESC").ToString, DTROW("GSM").ToString, DTROW("GSMDETAILS").ToString, DTROW("MOTHERSIZE"), DTROW("SIZE"), DTROW("SIZEDETAILS").ToString, DTROW("FOILQUALITY").ToString, DTROW("FOILGSM").ToString, DTROW("PEGSM").ToString, DTROW("ROLLDIAMETER").ToString, DTROW("COREPIPEWIDTH".ToString), DTROW("PALLETIZED").ToString, DTROW("NARRATION").ToString, Format(DTROW("QTY"), "0.00"), DTROW("UNIT").ToString, 0, 0, Val(DTROW("SONO")), Val(DTROW("GRIDSRNO")), DTROW("TYPE").ToString)
                    Next
                Next
                getsrno(GRIDJO)
                total()
                cmdselectso.Enabled = False
            End If

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

    Private Sub CMBFINISHED_Validated(sender As Object, e As EventArgs) Handles CMBFINISHED.Validated
        Try
            If CMBFINISHED.Text <> "" And CMBNAME.Text <> "" Then
                Dim dt As New DataTable
                Dim OBJCMN As New ClsCommon
                Dim DTTCS As DataTable = OBJCMN.SEARCH(" PAR_STAMPING ", "", " PARTYITEMWISECHART LEFT OUTER JOIN ITEMMASTER ON PARTYITEMWISECHART.PAR_ITEMID = ITEMMASTER.item_id LEFT OUTER JOIN LEDGERS ON PARTYITEMWISECHART.PAR_LEDGERID = LEDGERS.Acc_id", " AND ISNULL(ITEMMASTER.ITEM_NAME,'')='" & CMBFINISHED.Text & "'  AND ISNULL(LEDGERS.Acc_name,'')='" & CMBNAME.Text & "' and PAR_cmpid=" & CmpId & " AND  PAR_YEARID = " & YearId)
                If DTTCS.Rows.Count > 0 Then TXTDESC.Text = DTTCS.Rows(0).Item("PAR_STAMPING")

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBUNIT_Validated(sender As Object, e As EventArgs) Handles CMBUNIT.Validated
        Try
            If CMBFINISHED.Text.Trim <> "" Then
                Fillgrid()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TOTAL()
        Try
            LBLTOTALQTY.Text = 0.00
            For Each row As DataGridViewRow In GRIDJO.Rows
                If Val(row.Cells(GQTY.Index).EditedFormattedValue) > 0 Then LBLTOTALQTY.Text = Format(Val(LBLTOTALQTY.Text) + Val(row.Cells(GQTY.Index).EditedFormattedValue), "0.00")
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTQTY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTQTY.KeyPress
        numdot(e, TXTQTY, Me)
    End Sub

    Private Sub CMBSHIPTO_Validating(sender As Object, e As CancelEventArgs) Handles CMBSHIPTO.Validating
        Try
            If CMBSHIPTO.Text.Trim <> "" Then namevalidate(CMBSHIPTO, CMBCODE, e, Me, TXTADD, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS'", "SUNDRY DEBTORS")
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

    Private Sub PrintToolStripButton_Click(sender As Object, e As EventArgs) Handles PrintToolStripButton.Click
        Try
            If EDIT = True Then PRINTREPORT(TEMPJONO)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBFINISHED_Validating(sender As Object, e As CancelEventArgs) Handles CMBFINISHED.Validating
        Try
            If CMBFINISHED.Text.Trim <> "" Then ITEMVALIDATE(CMBFINISHED, e, Me, "", "MERCHANT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBFINISHED_Enter(sender As Object, e As EventArgs) Handles CMBFINISHED.Enter
        Try
            If CMBFINISHED.Text.Trim = "" Then FILLITEMNAME(CMBFINISHED, "")
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

    Private Sub CMBFOIL_Enter(sender As Object, e As EventArgs) Handles CMBFOIL.Enter
        Try
            If CMBFOIL.Text.Trim = "" Then FILLITEMNAME(CMBFOIL, "", " AND ITEMMASTER.item_ITEMTYPE = 'FOIL'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTGSM_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTGSM.KeyPress, TXTWASTAGEPER.KeyPress, TXTMOTHERSIZE.KeyPress
        numdotkeypress(e, sender, Me)
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

    Private Sub TXTQTY_Validated(sender As Object, e As EventArgs) Handles TXTQTY.Validated
        Try
            If CMBFINISHED.Text.Trim <> "" Then
                Fillgrid()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class