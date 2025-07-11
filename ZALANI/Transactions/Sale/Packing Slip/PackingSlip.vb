
Imports System.ComponentModel
Imports BL

Public Class PackingSlip

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE, GRIDDOUBLECLICK As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public EDIT As Boolean          'used for editing
    Public TEMPPSNO As String
    Dim TEMPROW As Integer


    Private Sub cmdexit_Click(sender As Object, e As EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdclear_Click(sender As Object, e As EventArgs) Handles cmdclear.Click
        clear()
        EDIT = False
        CMBNAME.Focus()
    End Sub

    Sub CLEAR()

        'CMBGODOWN.Text = ""
        'If USERGODOWN <> "" Then CMBGODOWN.Text = USERGODOWN Else CMBGODOWN.Text = ""
        CMBGODOWN.Text = ""

        TXTPSNO.ReadOnly = True
        TXTCONTAINER.Clear()
        CMBDESTINATION.Text = ""
        CMBTRANSPORTNAME.Text = ""
        CMBSHIPTO.Text = ""
        CMBPORTLOADING.Text = ""
        CMBPORTDISCHARGE.Text = ""
        CMBCURRENCY.Text = ""
        CMBCIFFOB.Text = ""
        TXTPROFORMANO.Clear()
        TXTREMARKS.Clear()
        GRIDJO.RowCount = 0
        txtsrno.Clear()
        CMBFINISHED.Text = ""
        TXTDESC.Clear()
        TXTGSM.Clear()
        TXTSIZE.Clear()
        TXTROLLDIAMETER.Clear()
        TXTCOREPIPEWIDTH.Clear()
        TXTNARRATION.Clear()
        TXTMTRS.Clear()
        TXTSOSRNO.Clear()
        TXTSONO.Clear()
        TXTSOTYPE.Clear()
        TXTWT.Clear()
        TXTLOTNO.Clear()
        CMBUNIT.Text = ""
        TXTREMARKS.Clear()
        CMBNAME.Text = ""
        getmax_PSNO()
        txtsrno.Text = 1
        tstxtbillno.Clear()
        DTDATE.Text = Now.Date
        LBLCLOSED.Visible = False
        TXTRATE.Clear()
        TXTROLLNO.Clear()
        TXTJOINT.Clear()
        CMBGODOWN.Text = ""
        TXTFINALWT.Clear()
        TXTTOTALPALLETTEWT.Clear()
        TXTVEHICLENO.Clear()
        GRIDDOUBLECLICK = False
        CMDSELECTSTOCK.Enabled = True
        cmdselectso.Enabled = True
        EP.Clear()
        LBLTOTALROLL.Text = 0
        LBLTOTALFINALWT.Text = 0.0
        LBLTOTALWT.Text = 0.0
        LBLTOTALMTRS.Text = 0.0


    End Sub

    Private Sub PackingSlip_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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


            If EDIT = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim OBJCMN As New ClsCommon
                Dim OBJCLSINCENTIVE As New ClsPackingSlip
                Dim dttable As New DataTable

                dttable = OBJCLSINCENTIVE.selectPACKING(TEMPPSNO, CmpId, YearId)
                If dttable.Rows.Count > 0 Then

                    For Each dr As DataRow In dttable.Rows

                        TXTPSNO.Text = TEMPPSNO
                        TXTPSNO.ReadOnly = True
                        DTDATE.Text = Format(Convert.ToDateTime(dr("DATE")), "dd/MM/yyyy")
                        CMBNAME.Text = Convert.ToString(dr("NAME"))
                        CMBPORTDISCHARGE.Text = Convert.ToString(dr("PORTDISCHARGE"))
                        CMBPORTLOADING.Text = Convert.ToString(dr("PORTLOADING"))
                        CMBDESTINATION.Text = Convert.ToString(dr("DESTINATION"))
                        CMBCIFFOB.Text = Convert.ToString(dr("CIFOB"))
                        CMBCURRENCY.Text = Convert.ToString(dr("CURRENCY"))
                        CMBSHIPTO.Text = Convert.ToString(dr("SHIPTO"))
                        TXTPROFORMANO.Text = dr("PROFORMANO")
                        TXTREMARKS.Text = dr("REMARKS")
                        'TXTBARCODE.Text = dr("BARCODE")
                        TXTVEHICLENO.Text = dr("VEHICLENO")
                        CMBTRANSPORTNAME.Text = Convert.ToString(dr("TRANSPORTNAME"))
                        TXTTOTALPALLETTEWT.Text = dr("TOTALPALLETTEWT")
                        CMBGODOWN.Text = Convert.ToString(dr("GODOWN"))
                        TXTORDERREFNO.Text = dr("ORDERREFNO")
                        LBLTOTALMTRS.Text = dr("TOTALMTRS")
                        LBLTOTALWT.Text = dr("TOTALWT")
                        LBLTOTALFINALWT.Text = dr("TOTALFINALWT")
                        LBLTOTALROLL.Text = dr("TOTALROLL")
                        TXTSOSRNO.Text = dr("SOSRNO")
                        TXTSONO.Text = dr("SONO")
                        TXTSOTYPE.Text = dr("SOTYPE")
                        TXTCONTAINER.Text = dr("CONTAINER")

                        GRIDJO.Rows.Add(Val(dr("GRIDSRNO")), dr("FINISHEDQUALITY"), dr("GRIDDESC"), dr("LOTNO").ToString, Format(Val(dr("RATE")), "0.00"), dr("ROLLNO"), Val(dr("GSM")), dr("GSMDETAILS"), Val(dr("SIZE")), Format(Val(dr("WT")), "0.00"), Format(Val(dr("FINALWT")), "0.00"), dr("ROLLDIAMETER"), dr("COREPIPEWIDTH"), dr("JOINT"), Format(Val(dr("MTRS")), "0.00"), dr("UNIT"), dr("NARRATION"), dr("CLOSED"), dr("BARCODE"), Val(dr("FROMNO")), Val(dr("FROMSRNO")), dr("FROMTYPE"))
                        If Convert.ToBoolean(dr("CLOSED")) = True Then
                            GRIDJO.Rows(GRIDJO.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                            lbllocked.Visible = True
                            If Convert.ToBoolean(dr("CLOSED")) = True Then LBLCLOSED.Visible = True
                            PBlock.Visible = True
                        End If
                        CMDSELECTSTOCK.Enabled = False
                        cmdselectso.Enabled = False
                    Next


                    GRIDJO.FirstDisplayedScrollingRowIndex = GRIDJO.RowCount - 1
                    GRIDJO.FirstDisplayedScrollingRowIndex = GRIDJO.RowCount - 1
                    total()
                    DTDATE.Focus()
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
            If TXTPSNO.ReadOnly = False Then
                alParaval.Add(Val(TXTPSNO.Text.Trim))
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
            alParaval.Add(TXTREMARKS.Text.Trim)
            alParaval.Add(TXTCONTAINER.Text.Trim)
            'alParaval.Add(TXTBARCODE.Text.Trim)
            alParaval.Add(TXTVEHICLENO.Text.Trim)
            alParaval.Add(CMBTRANSPORTNAME.Text.Trim)
            alParaval.Add(TXTTOTALPALLETTEWT.Text.Trim)
            alParaval.Add(CMBGODOWN.Text.Trim)
            alParaval.Add(TXTORDERREFNO.Text.Trim)
            alParaval.Add(Val(LBLTOTALMTRS.Text.Trim))
            alParaval.Add(Val(LBLTOTALWT.Text.Trim))
            alParaval.Add(Val(LBLTOTALFINALWT.Text.Trim))
            alParaval.Add(Val(LBLTOTALROLL.Text.Trim))
            alParaval.Add(TXTSOSRNO.Text.Trim)
            alParaval.Add(TXTSONO.Text.Trim)
            alParaval.Add(TXTSOTYPE.Text.Trim)


            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)

            Dim gridsrno As String = ""
            Dim FINISHEDQUALITY As String = ""
            Dim DESC As String = ""
            Dim LOTNO As String = ""
            Dim RATE As String = ""
            Dim ROLLNO As String = ""
            Dim GSM As String = ""
            Dim GSMDETAILS As String = ""
            Dim SIZE As String = ""
            Dim WT As String = ""
            Dim FINALWT As String = ""
            Dim ROLLDIAMETER As String = ""
            Dim COREPIPEWIDTH As String = ""
            Dim JOINT As String = ""
            Dim MTRS As String = ""
            Dim UNIT As String = ""
            Dim NARRATION As String = ""
            Dim CLOSED As String = ""
            Dim BARCODE As String = ""
            Dim FROMNO As String = ""
            Dim FROMSRNO As String = ""
            Dim TYPE As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDJO.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = Val(row.Cells(GSRNO.Index).Value)
                        FINISHEDQUALITY = row.Cells(GFINISHEDQUALITY.Index).Value.ToString
                        DESC = row.Cells(GDESC.Index).Value.ToString
                        LOTNO = row.Cells(GLOTNO.Index).Value.ToString
                        RATE = row.Cells(GRATE.Index).Value.ToString
                        ROLLNO = row.Cells(GROLLNO.Index).Value.ToString
                        GSM = row.Cells(GGSM.Index).Value.ToString
                        GSMDETAILS = row.Cells(GGSMDETAILS.Index).Value.ToString
                        SIZE = row.Cells(GSIZE.Index).Value.ToString
                        WT = row.Cells(GWT.Index).Value.ToString
                        FINALWT = row.Cells(GFINALWT.Index).Value.ToString
                        ROLLDIAMETER = row.Cells(GROLLDIAMETER.Index).Value.ToString
                        COREPIPEWIDTH = row.Cells(GCOREPIPEWIDTH.Index).Value.ToString
                        JOINT = row.Cells(GJOINT.Index).Value.ToString
                        MTRS = row.Cells(GMTRS.Index).Value.ToString
                        UNIT = row.Cells(GUNIT.Index).Value.ToString
                        NARRATION = row.Cells(GNARRATION.Index).Value.ToString
                        If Convert.ToBoolean(row.Cells(GCLOSED.Index).Value) = True Then CLOSED = 1 Else CLOSED = 0
                        BARCODE = row.Cells(GBARCODE.Index).Value.ToString
                        FROMNO = Val(row.Cells(GFROMNO.Index).Value)
                        FROMSRNO = Val(row.Cells(GFROMSRNO.Index).Value)
                        TYPE = row.Cells(GTYPE.Index).Value.ToString


                    Else

                        gridsrno = gridsrno & "|" & Val(row.Cells(GSRNO.Index).Value)
                        FINISHEDQUALITY = FINISHEDQUALITY & "|" & row.Cells(GFINISHEDQUALITY.Index).Value.ToString
                        DESC = DESC & "|" & row.Cells(GDESC.Index).Value.ToString
                        LOTNO = LOTNO & "|" & row.Cells(GLOTNO.Index).Value.ToString
                        RATE = RATE & "|" & row.Cells(GRATE.Index).Value.ToString
                        ROLLNO = ROLLNO & "|" & row.Cells(GROLLNO.Index).Value.ToString
                        GSM = GSM & "|" & row.Cells(GGSM.Index).Value.ToString
                        GSMDETAILS = GSMDETAILS & "|" & row.Cells(GGSMDETAILS.Index).Value.ToString
                        SIZE = SIZE & "|" & row.Cells(GSIZE.Index).Value.ToString
                        WT = WT & "|" & row.Cells(GWT.Index).Value.ToString
                        FINALWT = FINALWT & "|" & row.Cells(GFINALWT.Index).Value.ToString
                        ROLLDIAMETER = ROLLDIAMETER & "|" & row.Cells(GROLLDIAMETER.Index).Value.ToString
                        COREPIPEWIDTH = COREPIPEWIDTH & "|" & row.Cells(GCOREPIPEWIDTH.Index).Value.ToString
                        JOINT = JOINT & "|" & row.Cells(GJOINT.Index).Value.ToString
                        MTRS = MTRS & "|" & row.Cells(GMTRS.Index).Value.ToString
                        UNIT = UNIT & "|" & row.Cells(GUNIT.Index).Value.ToString
                        NARRATION = NARRATION & "|" & row.Cells(GNARRATION.Index).Value.ToString
                        If Convert.ToBoolean(row.Cells(GCLOSED.Index).Value) = True Then CLOSED = CLOSED & "|" & "1" Else CLOSED = CLOSED & "|" & "0"
                        BARCODE = BARCODE & "|" & row.Cells(GBARCODE.Index).Value.ToString
                        FROMNO = FROMNO & "|" & Val(row.Cells(GFROMNO.Index).Value)
                        FROMSRNO = FROMSRNO & "|" & Val(row.Cells(GFROMSRNO.Index).Value)
                        TYPE = TYPE & "|" & row.Cells(GTYPE.Index).Value.ToString

                    End If
                End If
            Next

            alParaval.Add(gridsrno)
            alParaval.Add(FINISHEDQUALITY)
            alParaval.Add(DESC)
            alParaval.Add(LOTNO)
            alParaval.Add(RATE)
            alParaval.Add(ROLLNO)
            alParaval.Add(GSM)
            alParaval.Add(GSMDETAILS)
            alParaval.Add(SIZE)
            alParaval.Add(WT)
            alParaval.Add(FINALWT)
            alParaval.Add(ROLLDIAMETER)
            alParaval.Add(COREPIPEWIDTH)
            alParaval.Add(JOINT)
            alParaval.Add(MTRS)
            alParaval.Add(UNIT)
            alParaval.Add(NARRATION)
            alParaval.Add(CLOSED)
            alParaval.Add(BARCODE)
            alParaval.Add(FROMNO)
            alParaval.Add(FROMSRNO)
            alParaval.Add(TYPE)


            Dim objclsPurord As New ClsPackingSlip()
            objclsPurord.alParaval = alParaval

            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim DT As DataTable = objclsPurord.SAVE()
                MessageBox.Show("Details Added")
                TXTPSNO.Text = DT.Rows(0).Item(0)
            Else


                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPPSNO)
                IntResult = objclsPurord.UPDATE()
                MessageBox.Show("Details Updated")
                EDIT = False
            End If

            clear()
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

        For Each row As DataGridViewRow In GRIDJO.Rows
            If Val(row.Cells(GFINALWT.Index).Value) = 0 Then
                EP.SetError(TXTFINALWT, "Final WT Cannot be 0")
                bln = False
            End If
        Next

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

        If CMBGODOWN.Text.Trim.Length = 0 Then
            EP.SetError(CMBGODOWN, " Please Fill Godown ")
            bln = False
        End If



        Return bln
    End Function

    Private Sub cmddelete_Click(sender As Object, e As EventArgs) Handles cmddelete.Click
        Try
            If EDIT = True Then
                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                If MsgBox("Delete Packing Slip?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                Dim alParaval As New ArrayList
                alParaval.Add(TXTPSNO.Text.Trim)
                ''alParaval.Add(Userid)
                alParaval.Add(CmpId)
                alParaval.Add(YearId)

                Dim ClsINCTAG As New ClsPackingSlip()
                ClsINCTAG.alParaval = alParaval
                Dim IntResult As Integer = ClsINCTAG.Delete()
                MsgBox("Packing Slip Deleted")
                CLEAR()
                EDIT = False
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
            TEMPPSNO = Val(TXTPSNO.Text) - 1
            If TEMPPSNO > 0 Then
                EDIT = True
                PackingSlip_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If

            If GRIDJO.RowCount = 0 And TEMPPSNO > 1 Then
                TXTPSNO.Text = TEMPPSNO
                GoTo LINE1
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(sender As Object, e As EventArgs) Handles toolnext.Click
        Try
            GRIDJO.RowCount = 0
LINE1:
            TEMPPSNO = Val(TXTPSNO.Text) + 1
            getmax_PSNO()
            Dim MAXNO As Integer = TXTPSNO.Text.Trim
            clear()
            If Val(TXTPSNO.Text) - 1 >= TEMPPSNO Then
                EDIT = True
                PackingSlip_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDJO.RowCount = 0 And TEMPPSNO < MAXNO Then
                TXTPSNO.Text = TEMPPSNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub getmax_PSNO()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(PS_NO),0) + 1 ", "PackingSlip", "  AND PS_cmpid=" & CmpId & " and PS_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTPSNO.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Private Sub OpenToolStripButton_Click(sender As Object, e As EventArgs) Handles OpenToolStripButton.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim objINVDTLS As New PackingSlipDetails
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
                total()
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
            If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, EDIT)
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

    Private Sub PackingSlip_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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
                GRIDJO.Rows.Add(Val(txtsrno.Text.Trim), CMBFINISHED.Text.Trim, TXTDESC.Text.Trim, TXTLOTNO.Text.Trim, TXTRATE.Text.Trim, Format(Val(TXTROLLNO.Text.Trim), "0.00"), TXTGSM.Text.Trim, TXTGSMDETAILS.Text.Trim, TXTSIZE.Text.Trim, Format(Val(TXTFINALWT.Text.Trim), "0.00"), Format(Val(TXTWT.Text.Trim), "0.00"), TXTROLLDIAMETER.Text.Trim, TXTCOREPIPEWIDTH.Text.Trim, TXTJOINT.Text.Trim, Format(Val(TXTMTRS.Text.Trim), "0.00"), CMBUNIT.Text.Trim, TXTNARRATION.Text.Trim)
                getsrno(GRIDJO)
            ElseIf GRIDDOUBLECLICK = True Then
                GRIDJO.Item(GSRNO.Index, TEMPROW).Value = Val(txtsrno.Text.Trim)
                GRIDJO.Item(GFINISHEDQUALITY.Index, TEMPROW).Value = CMBFINISHED.Text.Trim
                GRIDJO.Item(GDESC.Index, TEMPROW).Value = TXTDESC.Text.Trim
                GRIDJO.Item(GLOTNO.Index, TEMPROW).Value = TXTLOTNO.Text.Trim
                GRIDJO.Item(GRATE.Index, TEMPROW).Value = TXTRATE.Text.Trim
                GRIDJO.Item(GROLLNO.Index, TEMPROW).Value = Val(TXTROLLNO.Text.Trim)
                GRIDJO.Item(GGSM.Index, TEMPROW).Value = (TXTGSM.Text.Trim)
                GRIDJO.Item(GGSMDETAILS.Index, TEMPROW).Value = TXTGSMDETAILS.Text.Trim
                GRIDJO.Item(GSIZE.Index, TEMPROW).Value = TXTSIZE.Text.Trim
                GRIDJO.Item(GFINALWT.Index, TEMPROW).Value = Val(TXTFINALWT.Text.Trim)
                GRIDJO.Item(GWT.Index, TEMPROW).Value = Val(TXTWT.Text.Trim)
                GRIDJO.Item(GROLLDIAMETER.Index, TEMPROW).Value = (TXTROLLDIAMETER.Text.Trim)
                GRIDJO.Item(GCOREPIPEWIDTH.Index, TEMPROW).Value = (TXTCOREPIPEWIDTH.Text.Trim)
                GRIDJO.Item(GJOINT.Index, TEMPROW).Value = TXTJOINT.Text.Trim
                GRIDJO.Item(GMTRS.Index, TEMPROW).Value = Val(TXTMTRS.Text.Trim)
                GRIDJO.Item(GUNIT.Index, TEMPROW).Value = (CMBUNIT.Text.Trim)
                GRIDJO.Item(GNARRATION.Index, TEMPROW).Value = (TXTNARRATION.Text.Trim)



                GRIDDOUBLECLICK = False

            End If
            total()
            GRIDJO.FirstDisplayedScrollingRowIndex = GRIDJO.RowCount - 1

            txtsrno.Text = GRIDJO.RowCount + 1
            CMBFINISHED.Text = ""
            TXTDESC.Clear()
            TXTGSM.Clear()
            TXTSIZE.Clear()
            TXTGSMDETAILS.Clear()
            TXTROLLDIAMETER.Clear()
            TXTCOREPIPEWIDTH.Clear()
            TXTNARRATION.Clear()
            TXTLOTNO.Clear()
            CMBUNIT.Text = ""
            TXTRATE.Clear()
            TXTROLLNO.Clear()
            TXTJOINT.Clear()
            TXTMTRS.Clear()
            TXTWT.Clear()
            TXTFINALWT.Clear()

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
                TEMPPSNO = Val(tstxtbillno.Text)
                If TEMPPSNO > 0 Then
                    EDIT = True
                    PackingSlip_Load(sender, e)
                    total()

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
                TXTLOTNO.Text = GRIDJO.Item(GLOTNO.Index, GRIDJO.CurrentRow.Index).Value.ToString
                TXTRATE.Text = GRIDJO.Item(GRATE.Index, GRIDJO.CurrentRow.Index).Value.ToString
                TXTROLLNO.Text = GRIDJO.Item(GROLLNO.Index, GRIDJO.CurrentRow.Index).Value.ToString
                TXTGSM.Text = GRIDJO.Item(GGSM.Index, GRIDJO.CurrentRow.Index).Value.ToString
                TXTGSMDETAILS.Text = GRIDJO.Item(GGSMDETAILS.Index, GRIDJO.CurrentRow.Index).Value.ToString
                TXTSIZE.Text = GRIDJO.Item(GSIZE.Index, GRIDJO.CurrentRow.Index).Value.ToString
                TXTFINALWT.Text = GRIDJO.Item(GFINALWT.Index, GRIDJO.CurrentRow.Index).Value.ToString
                TXTWT.Text = GRIDJO.Item(GWT.Index, GRIDJO.CurrentRow.Index).Value.ToString
                TXTROLLDIAMETER.Text = GRIDJO.Item(GROLLDIAMETER.Index, GRIDJO.CurrentRow.Index).Value.ToString
                TXTCOREPIPEWIDTH.Text = GRIDJO.Item(GCOREPIPEWIDTH.Index, GRIDJO.CurrentRow.Index).Value.ToString
                TXTJOINT.Text = GRIDJO.Item(GJOINT.Index, GRIDJO.CurrentRow.Index).Value.ToString
                TXTMTRS.Text = GRIDJO.Item(GMTRS.Index, GRIDJO.CurrentRow.Index).Value.ToString
                TXTNARRATION.Text = GRIDJO.Item(GNARRATION.Index, GRIDJO.CurrentRow.Index).Value.ToString
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

    'Private Sub GRIDJO_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRIDJO.CellDoubleClick
    '    Try
    '        EDITROW()
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub
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
            OBJSO.FRMSTRING = "PACKINGSLIP"
            Dim DT As DataTable = OBJSO.DT
            OBJSO.ShowDialog()

            If DT.Rows.Count > 0 Then
                'FETCH DATA FROM SALEORDER_DESC WITH RESPECT TO SELECTED SONO
                CMBNAME.Text = DT.Rows(0).Item("NAME")
                CMBSHIPTO.Text = DT.Rows(0).Item("SHIPTO")
                CMBPORTDISCHARGE.Text = DT.Rows(0).Item("PORTDISCHARGE")
                CMBPORTLOADING.Text = DT.Rows(0).Item("PORTLOADING")
                CMBCURRENCY.Text = DT.Rows(0).Item("CURRENCY")
                TXTPROFORMANO.Text = DT.Rows(0).Item("PROFORMANO")
                CMBCIFFOB.Text = DT.Rows(0).Item("CIFFOB")
                CMBDESTINATION.Text = DT.Rows(0).Item("DESTINATION")
                TXTSOSRNO.Text = DT.Rows(0).Item("GRIDSRNO")
                TXTSONO.Text = DT.Rows(0).Item("SONO")
                TXTSOTYPE.Text = DT.Rows(0).Item("TYPE")


                If CMBSHIPTO.Text.Trim <> "" Then CMBSHIPTO_Validated(sender, e)

                '  cmdselectso.Enabled = False

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
            If CMBFINISHED.Text.Trim <> "" And CMBUNIT.Text.Trim <> "" And TXTWT.Text.Trim <> "" Then
                Fillgrid()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TOTAL()
        Try
            LBLTOTALFINALWT.Text = 0.0
            LBLTOTALWT.Text = 0.0
            LBLTOTALMTRS.Text = 0.0


            For Each ROW As DataGridViewRow In GRIDJO.Rows
                If ROW.Cells(GSRNO.Index).Value <> Nothing Then
                    LBLTOTALFINALWT.Text = Format(Val(LBLTOTALFINALWT.Text) + Val(ROW.Cells(GFINALWT.Index).EditedFormattedValue), "0.00")
                    LBLTOTALWT.Text = Format(Val(LBLTOTALWT.Text) + Val(ROW.Cells(GWT.Index).EditedFormattedValue), "0.00")
                    LBLTOTALMTRS.Text = Format(Val(LBLTOTALMTRS.Text) + Val(ROW.Cells(GMTRS.Index).EditedFormattedValue), "0.00")
                End If
            Next
            REELCOUNT()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub REELCOUNT()
        Try
            LBLTOTALROLL.Text = 0
            Dim dic As New Dictionary(Of String, Integer)()
            Dim cellValue As String
            For i = 0 To GRIDJO.Rows.Count - 1
                If Not GRIDJO.Rows(i).IsNewRow Then
                    cellValue = GRIDJO(GROLLNO.Index, i).EditedFormattedValue.ToString()
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


    Private Sub CMBSHIPTO_Validated(sender As Object, e As EventArgs) Handles CMBSHIPTO.Validated
        Try
            'GET MODEOF SHIPMENT FROM EXCEISE COLUMN
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.SEARCH(" ISNULL(Acc_exciseno,'') AS MODEOFSHIP", "", "LEDGERS ", " AND ACC_CMPNAME = '" & CMBSHIPTO.Text.Trim & "' AND ACC_YEARID = " & YearId)
            If DT.Rows.Count > 0 AndAlso DT.Rows(0).Item("MODEOFSHIP") <> "" Then
                CMBSHIPTO.Text = DT.Rows(0).Item("MODEOFSHIP")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub TXTWT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTWT.KeyPress, TXTROLLNO.KeyPress, TXTMTRS.KeyPress
        numdot(e, TXTWT, Me)
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
            If CMBSHIPTO.Text.Trim = "" Then FILLNAME(CMBSHIPTO, EDIT, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(sender As Object, e As EventArgs) Handles PrintToolStripButton.Click
        Try
            If EDIT = True Then PRINTREPORT(TEMPPSNO)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub PRINTREPORT(ByVal PSNO As Integer)
        Try
            If MsgBox("Wish to Print Packing Slip?", MsgBoxStyle.YesNo) = vbNo Then Exit Sub
            Dim OBJPACKINGSLIP As New SaleInvoiceDesign
            OBJPACKINGSLIP.FRMSTRING = "PACKINGSLIP"
            OBJPACKINGSLIP.INVNO = PSNO
            OBJPACKINGSLIP.PARTYNAME = CMBNAME.Text.Trim
            OBJPACKINGSLIP.MdiParent = MDIMain
            OBJPACKINGSLIP.Show()
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


    Private Sub CMBFINISHED_Enter(sender As Object, e As EventArgs) Handles CMBFINISHED.Enter
        Try
            If CMBFINISHED.Text.Trim = "" Then FILLITEMNAME(CMBFINISHED, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub TXTGSM_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTGSM.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub TXTSIZE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTSIZE.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub CMBNAME_Validated(sender As Object, e As EventArgs) Handles CMBNAME.Validated

        Try
            If CMBNAME.Text.Trim <> "" Then
                'GET PORTDISCHARGE,PORTLOADING AND PAYMENTTERM AND WARNING TEXT
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.SEARCH(" ISNULL(PORTMASTER.PORT_name, '') AS PORTDISCHARGE, ISNULL(PORTLOADINGPORTMASTER.PORT_name, '') AS PORTLOADING, ISNULL(LEDGERS.ACC_WARNING, '') AS WARNING, ISNULL(LEDGERS.Acc_remarks, '')  AS REMARKS, ISNULL(COUNTRYMASTER.country_name, '') AS DESTINATION", "", " LEDGERS LEFT OUTER JOIN COUNTRYMASTER ON LEDGERS.Acc_countryid = COUNTRYMASTER.country_id LEFT OUTER JOIN PORTMASTER AS PORTLOADINGPORTMASTER ON LEDGERS.ACC_PORTLOADINGID = PORTLOADINGPORTMASTER.PORT_id LEFT OUTER JOIN PORTMASTER ON LEDGERS.ACC_PORTDISCHARGEID = PORTMASTER.PORT_id ", " and LEDGERS.acc_cmpname = '" & CMBNAME.Text.Trim & "' and LEDGERS.acc_YEARid = " & YearId)
                If DT.Rows.Count > 0 Then
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


    Private Sub CMDSELECTSTOCK_Click(sender As Object, e As EventArgs) Handles CMDSELECTSTOCK.Click
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

            If CMBNAME.Text.Trim <> "" Then

                Dim OBJSELECTPS As New SelectStock
                OBJSELECTPS.FRMSTRING = "PS"
                OBJSELECTPS.GODOWN = CMBGODOWN.Text.Trim
                Dim DTPO As DataTable = OBJSELECTPS.DT
                OBJSELECTPS.ShowDialog()

                If DTPO.Rows.Count > 0 Then

                    '    ''  GETTING DISTINCT PSNO NO IN TEXTBOX
                    '    'Dim DV As DataView = DTPO.DefaultView
                    '    'Dim NEWDT As DataTable = DV.ToTable(True, "FROMNO")
                    '    'For Each DTR As DataRow In NEWDT.Rows
                    '    '    If TXTPSNO.Text.Trim = "" Then
                    '    '        TXTPSNO.Text = DTR("FROMNO").ToString
                    '    '    Else
                    '    '        TXTPSNO.Text = TXTPSNO.Text & "," & DTR("FROMNO").ToString

                    '    '    End If
                    '    Next

                    For Each DTROW As DataRow In DTPO.Rows

                        'For Each ROW As DataGridViewRow In GRIDJO.Rows
                        '    If Val(TXTPSNO.Text.Trim) = Val(DTROW("FROMNO")) And Val(ROW.Cells(GSRNO.Index).Value) = Val(DTROW("FROMSRNO")) Then GoTo NEXTLINE
                        'Next

                        GRIDJO.Rows.Add(0, DTROW("ITEMNAME"), "", DTROW("LOTNO"), "", DTROW("REELNO"), Val(DTROW("GSM")), DTROW("GSMDETAILS"), Val(DTROW("SIZE")), Val(DTROW("QTY")), Val(DTROW("QTY")), DTROW("ROLLOD"), DTROW("ROLLID"), 0, 0, DTROW("UNIT"), "", 0, DTROW("BARCODE"), DTROW("FROMNO"), DTROW("FROMSRNO"), DTROW("FROMTYPE"))

NEXTLINE:
                    Next

                    getsrno(GRIDJO)
                    TOTAL()
                    'CMBNAME.Enabled = False
                    ' CMDSELECTSTOCK.Enabled = False

                End If
            Else
                MsgBox("Enter Party Name")
                CMBNAME.Focus()
            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTBARCODE_Validated(sender As Object, e As EventArgs) Handles TXTBARCODE.Validated
        Try
            If TXTBARCODE.Text.Trim.Length > 0 Then

                If CMBGODOWN.Text.Trim = "" Then
                    MsgBox("Select Godown First", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.SEARCH("*", "", "BARCODESTOCK", " AND BARCODE = '" & TXTBARCODE.Text.Trim & "' AND YEARID = " & YearId)
                If DT.Rows.Count > 0 Then

                    'VALIDATE GODOWN
                    If DT.Rows(0).Item("GODOWN") <> CMBGODOWN.Text.Trim Then
                        MsgBox("Item Not in Selected Godown", MsgBoxStyle.Critical)
                        TXTBARCODE.Clear()
                        Exit Sub
                    End If

                    'CHECK WHETHER BARCODE IS ALREADY PRESENT IN GRID OR NOT
                    For Each ROW As DataGridViewRow In GRIDJO.Rows
                        If LCase(ROW.Cells(GBARCODE.Index).Value) = LCase(TXTBARCODE.Text.Trim) Then GoTo LINE1
                    Next



                    GRIDJO.Rows.Add(GRIDJO.RowCount + 1, DT.Rows(0).Item("ITEMNAME"), 0, DT.Rows(0).Item("LOTNO"), 0, DT.Rows(0).Item("REELNO"), DT.Rows(0).Item("GSM"), DT.Rows(0).Item("GSMDETAILS"), DT.Rows(0).Item("SIZE"), DT.Rows(0).Item("QTY"), DT.Rows(0).Item("ROLLWT"), 0, 0, 0, 0, DT.Rows(0).Item("UNIT"), "", 0, DT.Rows(0).Item("BARCODE"), DT.Rows(0).Item("FROMNO"), DT.Rows(0).Item("FROMSRNO"), DT.Rows(0).Item("FROMTYPE"))
                    TOTAL()
                    GRIDJO.FirstDisplayedScrollingRowIndex = GRIDJO.RowCount - 1


LINE1:
                    TXTBARCODE.Clear()
                    TXTBARCODE.Focus()
                Else
                    MsgBox("Invalid Barcode", MsgBoxStyle.Critical)
                    TXTBARCODE.Clear()
                End If
            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTBARCODE_Validating(sender As Object, e As CancelEventArgs) Handles TXTBARCODE.Validating
        Try
            If TXTBARCODE.Text.Trim <> "" Then
                'CHECKING WHETHER IS IS GONE OUT OR NOT
                Dim OBJCMN As New ClsCommon
                Dim DT As DataTable = OBJCMN.SEARCH("FROMTYPE, FROMNO", "", " OUTBARCODESTOCK ", " AND BARCODE = '" & TXTBARCODE.Text.Trim & "' AND CMPID = " & CmpId & " AND YEARID = " & YearId)
                If DT.Rows.Count > 0 Then
                    MsgBox("Barcode Already Used in " & DT.Rows(0).Item("FROMTYPE") & " Sr No " & DT.Rows(0).Item("FROMNO"))
                    TXTBARCODE.Clear()
                    e.Cancel = True
                    'Else
                    '    MsgBox("Invalid Barcode", MsgBoxStyle.Critical)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGODOWN_Validating(sender As Object, e As CancelEventArgs) Handles CMBGODOWN.Validating
        Try
            If CMBGODOWN.Text.Trim <> "" Then GODOWNVALIDATE(CMBGODOWN, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBGODOWN_Enter(sender As Object, e As EventArgs) Handles CMBGODOWN.Enter
        Try
            If CMBGODOWN.Text.Trim <> "" Then fillGODOWN(CMBGODOWN, EDIT)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub



    Private Sub CMBTRANSPORTNAME_Validating(sender As Object, e As CancelEventArgs) Handles CMBTRANSPORTNAME.Validating
        Try
            If CMBTRANSPORTNAME.Text.Trim <> "" Then namevalidate(CMBTRANSPORTNAME, CMBCODE, e, Me, TXTADD, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS'", "SUNDRY CREDITORS", "TRANSPORT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBTRANSPORTNAME_Enter(sender As Object, e As EventArgs) Handles CMBTRANSPORTNAME.Enter
        Try
            If CMBTRANSPORTNAME.Text.Trim = "" Then FILLNAME(CMBTRANSPORTNAME, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'SUNDRY CREDITORS' AND LEDGERS.ACC_TYPE = 'TRANSPORT'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTNARRATION_Validated(sender As Object, e As EventArgs) Handles TXTNARRATION.Validated
        Try
            If CMBFINISHED.Text.Trim <> "" And CMBUNIT.Text.Trim <> "" And TXTWT.Text.Trim <>"" Then
                Fillgrid()
                TOTAL()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDJO_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles GRIDJO.CellValidating
        Dim colNum As Integer = GRIDJO.Columns(e.ColumnIndex).Index
        If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return
        Select Case colNum

            Case GFINALWT.Index
                Dim dDebit As Decimal
                Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                If bValid Then
                    If GRIDJO.CurrentCell.Value = Nothing Then GRIDJO.CurrentCell.Value = "0.00"
                    GRIDJO.CurrentCell.Value = Convert.ToDecimal(GRIDJO.Item(colNum, e.RowIndex).Value)
                    TOTAL()
                Else
                    MessageBox.Show("Invalid Number Entered")
                    e.Cancel = True
                    'Exit Sub
                End If


        End Select
    End Sub
End Class