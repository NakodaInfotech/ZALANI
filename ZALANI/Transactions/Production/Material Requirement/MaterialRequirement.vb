
Imports System.ComponentModel
Imports BL

Public Class MaterialRequirement

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE, GRIDDOUBLECLICK As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public EDIT As Boolean          'used for editing
    Public TEMPMATREQNO As String
    Public TEMPMSG As Integer
    Dim TEMPROW As Integer

    Private Sub cmdclear_Click(sender As Object, e As EventArgs) Handles cmdclear.Click
        clear()
        EDIT = False
    End Sub

    Private Sub cmdexit_Click(sender As Object, e As EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub clear()

        TXTMATREQ.ReadOnly = True
        CMBGODOWN.Text = ""
        TXTPROFORMANO.Clear()
        CMBMACHINENO.Text = ""
        TXTSONO.Clear()
        TXTPROFORMANO.Clear()
        TXTFINALQUALITY.Clear()
        GRIDMATREQ.RowCount = 0

        TXTSOSRNO.Clear()
        TXTSONO.Text = ""
        TXTMATREQ.Text = ""
        DTMATREQDATE.Text = Now.Date
        DTSODATE.Text = ""

        getmax_MATREQNO()
        tstxtbillno.Clear()
        TXTREMARK.Clear()
        TXTSOTYPE.Clear()
        EP.Clear()
        LBLTOTALREELNO.Text = 0.0
        LBLTOTALDIFF.Text = 0
        LBLTOTALMILLQTY.Text = 0
        TXTWASTAGEPER.Clear()

        CMDSELECTSTOCK.Enabled = True
        CMDSELECTSO.Enabled = True
        CMBMACHINENO.Enabled = True
        TXTPARTYNAME.Clear()
        GRIDDOUBLECLICK = False
        TXTWASTAGEPER.BackColor = Color.White
        TXTWASTAGEPER.ReadOnly = False


        LBLTOTALSALEMILLQTY.Text = 0
        GRIDSALEORDER.RowCount = 0
        LBLTOTALSALEMILLQTY.Text = 0






    End Sub

    Sub getmax_MATREQNO()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(MATREQ_NO),0) + 1 ", "MATERIALREQUIREMENT", "  AND MATREQ_cmpid=" & CmpId & " and MATREQ_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTMATREQ.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Private Sub GRIDPRODISSUE_KeyDown(sender As Object, e As KeyEventArgs) Handles GRIDMATREQ.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDMATREQ.RowCount > 0 Then
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                GRIDMATREQ.Rows.RemoveAt(GRIDMATREQ.CurrentRow.Index)
                TOTAL()
                getsrno(GRIDMATREQ)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub FILLCMB()
        Try
            If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, EDIT)
            If CMBMACHINENO.Text.Trim = "" Then FILLMACHINE(CMBMACHINENO)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MaterialRequirement_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow

            DTROW = USERRIGHTS.Select("FormName = 'MATERIAL REQUIREMENT'")

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
                Dim OBJCLSINCENTIVE As New ClsMaterialRequirement
                Dim dttable As New DataTable

                dttable = OBJCLSINCENTIVE.selectMATREQ(TEMPMATREQNO, CmpId, YearId)
                If dttable.Rows.Count > 0 Then

                    For Each dr As DataRow In dttable.Rows

                        TXTMATREQ.Text = TEMPMATREQNO
                        TXTMATREQ.ReadOnly = True
                        DTMATREQDATE.Text = Format(Convert.ToDateTime(dr("DATE")), "dd/MM/yyyy")
                        DTSODATE.Text = Format(Convert.ToDateTime(dr("SODATE")), "dd/MM/yyyy")
                        TXTSOTYPE.Text = dr("SOTYPE")
                        CMBGODOWN.Text = Convert.ToString(dr("GODOWN"))
                        CMBMACHINENO.Text = Convert.ToString(dr("MACHINE"))
                        TXTPROFORMANO.Text = dr("PROFORMANO")
                        TXTFINALQUALITY.Text = dr("FINALQUALITY")
                        TXTSOSRNO.Text = dr("SOSRNO")
                        TXTSONO.Text = dr("SONO")
                        TXTREMARK.Text = dr("REMARKS")
                        LBLTOTALREELNO.Text = dr("TOTALRELL")
                        LBLTOTALDIFF.Text = dr("TOTALDIFF")
                        LBLTOTALMILLQTY.Text = dr("TOTALMILLQTY")
                        TXTPARTYNAME.Text = dr("PARTYNAME")
                        TXTWASTAGEPER.Text = dr("WASTAGEPER")
                        LBLTOTALSALEMILLQTY.Text = dr("TOTALSALEMILLQTY")


                        GRIDMATREQ.Rows.Add(dr("GRIDSRNO").ToString, dr("QUALITY").ToString, dr("LOTNO").ToString, dr("ROLLNO").ToString, dr("GSM").ToString, dr("SIZE").ToString, dr("MILLQTY").ToString, dr("DIFF").ToString, dr("UNIT").ToString, dr("BARCODE").ToString, dr("RECDWT").ToString, Val(dr("FROMNO")), Val(dr("FROMSRNO")), dr("CLOSED"))
                        'If Convert.ToBoolean(dr("CLOSED")) = True Then
                        '    GRIDMATREQ.Rows(GRIDMATREQ.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                        '    lbllocked.Visible = True
                        '    PBlock.Visible = True
                        'End If

                    Next
                    'SALEORDER Grid
                    Dim OBJPRI As New ClsCommon
                    dttable = OBJPRI.SEARCH("ISNULL(MATERIALREQUIREMENT_SALEORDERDESC.MATREQ_GRIDSALESRNO, 0) AS GRIDSALESRNO, ISNULL(ITEMMASTER.ITEM_NAME, '') AS SALEQUALITY,  ISNULL(MATERIALREQUIREMENT_SALEORDERDESC.MATREQ_SALEGSM, 0) AS SALEGSM, ISNULL(MATERIALREQUIREMENT_SALEORDERDESC.MATREQ_SALESIZE, 0) AS SALESIZE,  ISNULL(MATERIALREQUIREMENT_SALEORDERDESC.MATREQ_SALEMILLQTY, 0) AS SALEMILLQTY, ISNULL(UNITMASTER.unit_abbr, '') AS SALEUNIT,ISNULL(MATERIALREQUIREMENT_SALEORDERDESC.MATREQ_SONO, 0) AS SONO, ISNULL(MATERIALREQUIREMENT_SALEORDERDESC.MATREQ_SOSRNO, 0) AS SOSRNO, ISNULL(MATERIALREQUIREMENT_SALEORDERDESC.MATREQ_SOTYPE, '') AS SOTYPE  ", "", " MATERIALREQUIREMENT_SALEORDERDESC LEFT OUTER JOIN UNITMASTER ON MATERIALREQUIREMENT_SALEORDERDESC.MATREQ_SALEUNITID = UNITMASTER.unit_id LEFT OUTER JOIN ITEMMASTER ON MATERIALREQUIREMENT_SALEORDERDESC.MATREQ_SALEQUALITYID = ITEMMASTER.item_id", " AND MATREQ_NO = " & TEMPMATREQNO & " AND MATREQ_CMPID = " & CmpId & " AND MATREQ_YEARID = " & YearId)
                    If dttable.Rows.Count > 0 Then
                        For Each dr As DataRow In dttable.Rows
                            GRIDSALEORDER.Rows.Add(dr("GRIDSALESRNO").ToString, dr("SALEQUALITY").ToString, dr("SALEGSM").ToString, dr("SALESIZE").ToString, dr("SALEMILLQTY").ToString, dr("SALEUNIT").ToString, dr("SONO").ToString, dr("SOSRNO").ToString, dr("SOTYPE").ToString)
                        Next
                    End If



                    GRIDMATREQ.FirstDisplayedScrollingRowIndex = GRIDMATREQ.RowCount - 1
                    TOTAL()
                    ' CMDSELECTSTOCK.Enabled = False
                    CMDSELECTSO.Enabled = False
                    TXTWASTAGEPER.BackColor = Color.Linen
                    TXTWASTAGEPER.ReadOnly = True

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
            If TXTMATREQ.ReadOnly = False Then
                alParaval.Add(Val(TXTMATREQ.Text.Trim))
            Else
                alParaval.Add(0)
            End If

            alParaval.Add(Format(Convert.ToDateTime(DTMATREQDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(Format(Convert.ToDateTime(DTSODATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(TXTSOTYPE.Text.Trim)
            alParaval.Add(CMBGODOWN.Text.Trim)
            alParaval.Add(CMBMACHINENO.Text.Trim)
            alParaval.Add(TXTPROFORMANO.Text.Trim)
            alParaval.Add(TXTFINALQUALITY.Text.Trim)
            alParaval.Add(TXTSOSRNO.Text.Trim)
            alParaval.Add(TXTSONO.Text.Trim)
            alParaval.Add(TXTREMARK.Text.Trim)
            alParaval.Add(Val(LBLTOTALREELNO.Text.Trim))
            alParaval.Add(Val(LBLTOTALDIFF.Text.Trim))
            alParaval.Add(Val(LBLTOTALMILLQTY.Text.Trim))
            alParaval.Add(TXTPARTYNAME.Text.Trim)
            alParaval.Add(TXTWASTAGEPER.Text.Trim)
            alParaval.Add(LBLTOTALSALEMILLQTY.Text.Trim)


            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)

            Dim GRIDPRISSUESRNO As String = ""
            Dim QUALITY As String = ""
            Dim LOTNO As String = ""
            Dim ROLLNO As String = ""
            Dim GSM As String = ""
            Dim SIZE As String = ""
            Dim MILLQTY As String = ""
            Dim DIFF As String = ""
            Dim UNIT As String = ""
            Dim BARCODE As String = ""
            Dim RECDWT As String = ""
            Dim FROMNO As String = ""
            Dim FROMSRNO As String = ""
            Dim CLOSED As String = ""


            For Each row As Windows.Forms.DataGridViewRow In GRIDMATREQ.Rows
                If row.Cells(0).Value <> Nothing Then
                    If GRIDPRISSUESRNO = "" Then
                        GRIDPRISSUESRNO = Val(row.Cells(GISSUESRNO.Index).Value)
                        QUALITY = row.Cells(GQUALITY.Index).Value.ToString
                        LOTNO = row.Cells(GLOTNO.Index).Value.ToString
                        ROLLNO = row.Cells(GREELROLLNO.Index).Value.ToString
                        GSM = row.Cells(GGSM.Index).Value.ToString
                        SIZE = row.Cells(GSIZE.Index).Value.ToString
                        MILLQTY = row.Cells(GMILLQTY.Index).Value.ToString
                        DIFF = row.Cells(GDIFF.Index).Value.ToString
                        UNIT = row.Cells(GUNIT.Index).Value.ToString
                        BARCODE = row.Cells(GBARCODE.Index).Value.ToString
                        RECDWT = Val(row.Cells(GRECDWT.Index).Value)
                        FROMNO = Val(row.Cells(GFROMNO.Index).Value)
                        FROMSRNO = Val(row.Cells(GFROMSRNO.Index).Value)
                        If Convert.ToBoolean(row.Cells(GCLOSED.Index).Value) = True Then CLOSED = 1 Else CLOSED = 0


                    Else

                        GRIDPRISSUESRNO = GRIDPRISSUESRNO & "|" & Val(row.Cells(GISSUESRNO.Index).Value)
                        QUALITY = QUALITY & "|" & row.Cells(GQUALITY.Index).Value.ToString
                        LOTNO = LOTNO & "|" & row.Cells(GLOTNO.Index).Value.ToString
                        ROLLNO = ROLLNO & "|" & row.Cells(GREELROLLNO.Index).Value.ToString
                        GSM = GSM & "|" & row.Cells(GGSM.Index).Value.ToString
                        SIZE = SIZE & "|" & row.Cells(GSIZE.Index).Value.ToString
                        MILLQTY = MILLQTY & "|" & row.Cells(GMILLQTY.Index).Value.ToString
                        DIFF = DIFF & "|" & row.Cells(GDIFF.Index).Value.ToString
                        UNIT = UNIT & "|" & row.Cells(GUNIT.Index).Value.ToString
                        BARCODE = BARCODE & "|" & row.Cells(GBARCODE.Index).Value.ToString
                        RECDWT = RECDWT & "|" & Val(row.Cells(GRECDWT.Index).Value)
                        FROMNO = FROMNO & "|" & Val(row.Cells(GFROMNO.Index).Value)
                        FROMSRNO = FROMSRNO & "|" & Val(row.Cells(GFROMSRNO.Index).Value)
                        If Convert.ToBoolean(row.Cells(GCLOSED.Index).Value) = True Then CLOSED = CLOSED & "|" & "1" Else CLOSED = CLOSED & "|" & "0"

                    End If
                End If
            Next

            alParaval.Add(GRIDPRISSUESRNO)
            alParaval.Add(QUALITY)
            alParaval.Add(LOTNO)
            alParaval.Add(ROLLNO)
            alParaval.Add(GSM)
            alParaval.Add(SIZE)
            alParaval.Add(MILLQTY)
            alParaval.Add(DIFF)
            alParaval.Add(UNIT)
            alParaval.Add(BARCODE)
            alParaval.Add(RECDWT)
            alParaval.Add(FROMNO)
            alParaval.Add(FROMSRNO)
            alParaval.Add(CLOSED)



            Dim GRIDSALESRNO As String = ""
            Dim SALEQUALITY As String = ""
            Dim SALEGSM As String = ""
            Dim SALESIZE As String = ""
            Dim SALEMILLQTY As String = ""
            Dim SALEUNIT As String = ""
            Dim SONO As String = ""
            Dim SOSRNO As String = ""
            Dim SOTYPE As String = ""




            For Each row As Windows.Forms.DataGridViewRow In GRIDSALEORDER.Rows
                If row.Cells(0).Value <> Nothing Then
                    If GRIDSALESRNO = "" Then
                        GRIDSALESRNO = Val(row.Cells(EISSUESRNO.Index).Value)
                        SALEQUALITY = row.Cells(EQUALITY.Index).Value.ToString
                        SALEGSM = row.Cells(EGSM.Index).Value.ToString
                        SALESIZE = row.Cells(ESIZE.Index).Value.ToString
                        SALEMILLQTY = row.Cells(EMILLQTY.Index).Value.ToString
                        SALEUNIT = row.Cells(EUNIT.Index).Value.ToString
                        SONO = row.Cells(EFROMNO.Index).Value.ToString
                        SOSRNO = row.Cells(EFROMSRNO.Index).Value.ToString
                        SOTYPE = row.Cells(EFROMTYPE.Index).Value.ToString

                    Else

                        GRIDSALESRNO = GRIDSALESRNO & "|" & Val(row.Cells(EISSUESRNO.Index).Value)
                        SALEQUALITY = SALEQUALITY & "|" & row.Cells(EQUALITY.Index).Value.ToString
                        SALEGSM = SALEGSM & "|" & row.Cells(EGSM.Index).Value.ToString
                        SALESIZE = SALESIZE & "|" & row.Cells(ESIZE.Index).Value.ToString
                        SALEMILLQTY = SALEMILLQTY & "|" & row.Cells(EMILLQTY.Index).Value.ToString
                        SALEUNIT = SALEUNIT & "|" & row.Cells(EUNIT.Index).Value.ToString
                        SONO = SONO & "|" & row.Cells(EFROMNO.Index).Value.ToString
                        SOSRNO = SOSRNO & "|" & row.Cells(EFROMSRNO.Index).Value.ToString
                        SOTYPE = SOTYPE & "|" & row.Cells(EFROMTYPE.Index).Value.ToString

                    End If
                End If
            Next

            alParaval.Add(GRIDSALESRNO)
            alParaval.Add(SALEQUALITY)
            alParaval.Add(SALEGSM)
            alParaval.Add(SALESIZE)
            alParaval.Add(SALEMILLQTY)
            alParaval.Add(SALEUNIT)
            alParaval.Add(SONO)
            alParaval.Add(SOSRNO)
            alParaval.Add(SOTYPE)



            Dim objclsPurord As New ClsMaterialRequirement()
            objclsPurord.alParaval = alParaval

            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim DT As DataTable = objclsPurord.SAVE()
                MessageBox.Show("Details Added")
                TXTMATREQ.Text = DT.Rows(0).Item(0)
            Else


                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPMATREQNO)
                IntResult = objclsPurord.UPDATE()
                MessageBox.Show("Details Updated")
                EDIT = False
            End If

            clear()
            CMBMACHINENO.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub PRINTREPORT(ByVal MATREQNO As Integer)
        Try
            If MsgBox("Wish to Print Material Req?", MsgBoxStyle.YesNo) = vbNo Then Exit Sub
            Dim OBJPROFORMA As New JobOrderDesign
            OBJPROFORMA.FRMSTRING = "MATREQ"
            OBJPROFORMA.JOBNO = MATREQNO
            OBJPROFORMA.PARTYNAME = TXTPARTYNAME.Text.Trim
            OBJPROFORMA.MdiParent = MDIMain
            OBJPROFORMA.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function ERRORVALID() As Boolean

        Dim bln As Boolean = True
        If CMBGODOWN.Text.Trim.Length = 0 Then
            EP.SetError(CMBGODOWN, " Please Fill Godown ")
            bln = False
        End If

        If DTMATREQDATE.Text = "__/__/____" Then
            EP.SetError(DTMATREQDATE, " Please Enter Proper Date")
            bln = False
        Else
            If Not datecheck(DTMATREQDATE.Text) Then
                EP.SetError(DTMATREQDATE, "Date not in Accounting Year")
                bln = False
            End If
        End If

        If Val(TXTSOSRNO.Text.Trim) = 0 Then
            EP.SetError(TXTSOSRNO, " Please Select Sale Order")
            bln = False
        End If

        If CMBMACHINENO.Text.Trim.Length = 0 Then
            EP.SetError(CMBMACHINENO, " Please Fill Machine No  ")
            bln = False
        End If

        If GRIDMATREQ.RowCount = 0 Then
            EP.SetError(GRIDMATREQ, " Please Enter Proper Details ")
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
                TEMPMSG = MsgBox("Delete Material Requirement?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim alParaval As New ArrayList
                    alParaval.Add(TXTMATREQ.Text.Trim)
                    alParaval.Add(YearId)

                    Dim ClsINCTAG As New ClsMaterialRequirement()
                    ClsINCTAG.alParaval = alParaval
                    IntResult = ClsINCTAG.Delete()
                    MsgBox("Material Requirement Deleted")
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
            GRIDMATREQ.RowCount = 0
LINE1:
            TEMPMATREQNO = Val(TXTMATREQ.Text) - 1
            If TEMPMATREQNO > 0 Then
                EDIT = True
                MaterialRequirement_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If

            If GRIDMATREQ.RowCount = 0 And TEMPMATREQNO > 1 Then
                TXTMATREQ.Text = TEMPMATREQNO
                GoTo LINE1
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(sender As Object, e As EventArgs) Handles toolnext.Click
        Try
            GRIDMATREQ.RowCount = 0
LINE1:
            TEMPMATREQNO = Val(TXTMATREQ.Text) + 1
            getmax_MATREQNO()
            Dim MAXNO As Integer = TXTMATREQ.Text.Trim
            clear()
            If Val(TXTMATREQ.Text) - 1 >= TEMPMATREQNO Then
                EDIT = True
                MaterialRequirement_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDMATREQ.RowCount = 0 And TEMPMATREQNO < MAXNO Then
                TXTMATREQ.Text = TEMPMATREQNO
                GoTo LINE1
            End If
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

    Private Sub OpenToolStripButton_Click(sender As Object, e As EventArgs) Handles OpenToolStripButton.Click
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim objINVDTLS As New MaterialRequirementDetails
            objINVDTLS.MdiParent = MDIMain
            objINVDTLS.Show()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Try
            Call cmddelete_Click(sender, e)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(sender As Object, e As EventArgs) Handles PrintToolStripButton.Click
        Try
            If EDIT = True Then PRINTREPORT(TEMPMATREQNO)
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


    Private Sub DTMATREQDATE_GotFocus(sender As Object, e As EventArgs) Handles DTMATREQDATE.GotFocus
        DTMATREQDATE.SelectionStart = 0
    End Sub



    Private Sub CMBMACHINENO_Validating(sender As Object, e As CancelEventArgs) Handles CMBMACHINENO.Validating
        Try
            If CMBMACHINENO.Text.Trim <> "" Then MACHINEVALIDATE(CMBMACHINENO, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBMACHINENO_Enter(sender As Object, e As EventArgs) Handles CMBMACHINENO.Enter
        Try
            If CMBMACHINENO.Text.Trim <> "" Then FILLMACHINE(CMBMACHINENO)

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


    Private Sub CMBSELECTSO_Click(sender As Object, e As EventArgs) Handles CMDSELECTSO.Click
        Try
            If TXTWASTAGEPER.Text.Trim = "" Then
                MsgBox("Please Fill Wastage Percent", MsgBoxStyle.Critical)
                TXTWASTAGEPER.Focus()
                Exit Sub
            End If
            If Val(TXTWASTAGEPER.Text.Trim) = 0 Then Exit Sub


            Dim OBJSO As New SelectSO
            OBJSO.FRMSTRING = "MATERIALREQUIREMENT"
            OBJSO.ShowDialog()
            Dim DT As DataTable = OBJSO.DT
            If DT.Rows.Count > 0 Then
                For Each DTR As DataRow In DT.Rows
                    TXTSONO.Text = DTR("SONO").ToString
                    TXTSOSRNO.Text = DTR("GRIDSRNO").ToString
                    TXTSOTYPE.Text = DTR("TYPE").ToString
                    ''FETCH DATA FROM joborder

                    TXTPROFORMANO.Text = Val(DT.Rows(0).Item("PROFORMANO"))
                    DTSODATE.Text = DT.Rows(0).Item("DATE")
                    TXTFINALQUALITY.Text = DT.Rows(0).Item("FINISHEDQUALITY")
                    TXTPARTYNAME.Text = DT.Rows(0).Item("NAME")
                    TXTREMARK.Text = DT.Rows(0).Item("SPECIALREMARKS")


                    Dim OBJCMN As New ClsCommon
                    'Dim DTSO As DataTable = OBJCMN.SEARCH(" ISNULL(ALLSALEORDER_DESC.SO_GRIDSRNO, 0) AS GRIDSRNO, ISNULL(ITEMMASTER.ITEM_NAME, '') AS QUALITY, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT, ISNULL(MAINITEMUNITMASTER.unit_abbr, '') AS MAINITEMUNIT, ISNULL(ALLSALEORDER_DESC.SO_GSM, 0) AS GSM,  ISNULL(ALLSALEORDER_DESC.SO_SIZE, 0) AS SIZE, ISNULL(ALLSALEORDER_DESC.SO_DESC, '') AS JOBDESC, ISNULL(ALLSALEORDER_DESC.SO_FOILGSM, 0) AS FOILGSM, ISNULL(ALLSALEORDER_DESC.SO_PEGSM, 0)  AS PEGSM, ISNULL(ALLSALEORDER_DESC.SO_ROLLDIAMETER, '') AS ROLLDIAMETER, ISNULL(ALLSALEORDER_DESC.SO_COREPIPEWIDTH, '') AS COREPIPEWIDTH, ISNULL(ALLSALEORDER_DESC.SO_PALLETIZED, '')  AS PALLETIZED, ISNULL(ALLSALEORDER_DESC.SO_NARRATION, '') AS NARRATION, ISNULL(ALLSALEORDER_DESC.SO_QTY, 0) AS QTY, ISNULL(ALLSALEORDER_DESC.SO_RATE, 0) AS RATE,  ISNULL(ALLSALEORDER_DESC.SO_AMOUNT, 0) AS AMOUNT, ISNULL(FINISHEDITEMMASTER.ITEM_NAME, '') AS ITEMNAME", "", "  ALLSALEORDER_DESC INNER JOIN ITEMMASTER AS FINISHEDITEMMASTER  ON ALLSALEORDER_DESC.SO_FINISHEDQUALITYID = FINISHEDITEMMASTER.item_id INNER JOIN ITEMMASTER_DESC ON FINISHEDITEMMASTER.item_id = ITEMMASTER_DESC.ITEM_ID INNER JOIN ITEMMASTER ON ITEMMASTER.item_id = ITEMMASTER_DESC.ITEM_ITEMID LEFT OUTER JOIN UNITMASTER ON UNITMASTER.unit_id = ITEMMASTER.item_unitid LEFT OUTER JOIN UNITMASTER AS MAINITEMUNITMASTER ON ALLSALEORDER_DESC.SO_UNITID = MAINITEMUNITMASTER.UNIT_ID ", "AND ALLSALEORDER_DESC.TYPE = '" & (TXTSOTYPE.Text.Trim) & "' AND ALLSALEORDER_DESC.SO_NO = " & Val(TXTSONO.Text.Trim) & " AND ALLSALEORDER_DESC.SO_GRIDSRNO = " & Val(TXTSOSRNO.Text.Trim) & " AND ALLSALEORDER_DESC.SO_YEARID = " & YearId)
                    Dim DTSO As DataTable = OBJCMN.SEARCH(" ISNULL(ALLSALEORDER_DESC.SO_NO, '') AS SONO ,ISNULL(ALLSALEORDER_DESC.SO_GRIDSRNO, 0) AS GRIDSRNO,ISNULL(ALLSALEORDER_DESC.TYPE, '') AS FROMTYPE ,ISNULL(UNITMASTER.unit_abbr, '') AS UNIT, ISNULL(MAINITEMUNITMASTER.unit_abbr, '') AS MAINITEMUNIT, ISNULL(ALLSALEORDER_DESC.SO_GSM, 0) AS GSM, ISNULL(ALLSALEORDER_DESC.SO_SIZE, 0) AS SIZE, ISNULL(ALLSALEORDER_DESC.SO_DESC, '') AS JOBDESC, ISNULL(ALLSALEORDER_DESC.SO_FOILGSM, 0) AS FOILGSM, ISNULL(ALLSALEORDER_DESC.SO_PEGSM, 0) AS PEGSM, ISNULL(ALLSALEORDER_DESC.SO_ROLLDIAMETER, '') AS ROLLDIAMETER, ISNULL(ALLSALEORDER_DESC.SO_COREPIPEWIDTH, '') AS COREPIPEWIDTH, ISNULL(ALLSALEORDER_DESC.SO_PALLETIZED, '') AS PALLETIZED, ISNULL(ALLSALEORDER_DESC.SO_NARRATION, '') AS NARRATION, ISNULL(ALLSALEORDER_DESC.SO_QTY, 0) AS QTY, ISNULL(ALLSALEORDER_DESC.SO_RATE, 0) AS RATE, ISNULL(ALLSALEORDER_DESC.SO_AMOUNT, 0) AS AMOUNT, ISNULL(COALESCE(ITEMMASTER.ITEM_NAME,FINISHEDITEMMASTER.ITEM_NAME),'') AS QUALITY ", "", "  ALLSALEORDER_DESC INNER JOIN ITEMMASTER AS FINISHEDITEMMASTER ON ALLSALEORDER_DESC.SO_FINISHEDQUALITYID = FINISHEDITEMMASTER.item_id AND ALLSALEORDER_DESC.SO_YEARID = FINISHEDITEMMASTER.item_yearid LEFT OUTER JOIN ITEMMASTER_DESC ON FINISHEDITEMMASTER.item_id = ITEMMASTER_DESC.ITEM_ID LEFT OUTER JOIN ITEMMASTER ON ITEMMASTER.item_id = ITEMMASTER_DESC.ITEM_ITEMID LEFT OUTER JOIN UNITMASTER ON UNITMASTER.unit_id = ITEMMASTER.item_unitid LEFT OUTER JOIN UNITMASTER AS MAINITEMUNITMASTER ON ALLSALEORDER_DESC.SO_UNITID = MAINITEMUNITMASTER.unit_id ", "AND ALLSALEORDER_DESC.TYPE = '" & (TXTSOTYPE.Text.Trim) & "' AND ALLSALEORDER_DESC.SO_NO = " & Val(TXTSONO.Text.Trim) & " AND ALLSALEORDER_DESC.SO_GRIDSRNO =  " & Val(TXTSOSRNO.Text.Trim) & " AND ALLSALEORDER_DESC.SO_YEARID = " & YearId)
                    ' Dim DTSO As DataTable = OBJCMN.SEARCH(" ISNULL(ALLSALEORDER_DESC.SO_NO, '') AS SONO, ISNULL(ALLSALEORDER_DESC.SO_GRIDSRNO, 0) AS GRIDSRNO, ISNULL(ALLSALEORDER_DESC.TYPE, '') AS FROMTYPE, ISNULL(FINISHEDITEMMASTER.ITEM_NAME, '') AS QUALITY, ISNULL(MAINITEMUNITMASTER.unit_abbr, '') AS MAINITEMUNIT, ISNULL(ALLSALEORDER_DESC.SO_GSM, 0) AS GSM, ISNULL(ALLSALEORDER_DESC.SO_SIZE, 0) AS SIZE, ISNULL(ALLSALEORDER_DESC.SO_DESC, '') AS JOBDESC, ISNULL(ALLSALEORDER_DESC.SO_FOILGSM, 0) AS FOILGSM, ISNULL(ALLSALEORDER_DESC.SO_PEGSM, 0) AS PEGSM, ISNULL(ALLSALEORDER_DESC.SO_ROLLDIAMETER, '') AS ROLLDIAMETER, ISNULL(ALLSALEORDER_DESC.SO_COREPIPEWIDTH, '') AS COREPIPEWIDTH, ISNULL(ALLSALEORDER_DESC.SO_PALLETIZED, '') AS PALLETIZED, ISNULL(ALLSALEORDER_DESC.SO_NARRATION, '') AS NARRATION, ISNULL(ALLSALEORDER_DESC.SO_QTY, 0) AS QTY, ISNULL(ALLSALEORDER_DESC.SO_RATE, 0) AS RATE, ISNULL(ALLSALEORDER_DESC.SO_AMOUNT, 0) AS AMOUNT, ISNULL(FINISHEDITEMMASTER.ITEM_NAME, '') AS ITEMNAME  ", "", "  ALLSALEORDER_DESC INNER JOIN ITEMMASTER AS FINISHEDITEMMASTER ON ALLSALEORDER_DESC.SO_FINISHEDQUALITYID = FINISHEDITEMMASTER.item_id AND ALLSALEORDER_DESC.SO_YEARID = FINISHEDITEMMASTER.item_yearid LEFT OUTER JOIN UNITMASTER AS MAINITEMUNITMASTER ON ALLSALEORDER_DESC.SO_UNITID = MAINITEMUNITMASTER.unit_id  ", "AND ALLSALEORDER_DESC.TYPE = '" & (TXTSOTYPE.Text.Trim) & "' AND ALLSALEORDER_DESC.SO_NO = " & Val(TXTSONO.Text.Trim) & " AND ALLSALEORDER_DESC.SO_GRIDSRNO =  " & Val(TXTSOSRNO.Text.Trim) & " AND ALLSALEORDER_DESC.SO_YEARID = " & YearId)


                    For Each DTROW As DataRow In DTSO.Rows

                        'GET PE GSM AND CALCULATE THE WT
                        Dim TOTALGSM As Double = Val(DTROW("GSM")) + Val(DTROW("PEGSM")) + Val(DTROW("FOILGSM"))
                        Dim PROFORMAWT As Double = 0.00
                        Dim QTY As Double = 0.00
                        Dim GSM As Double = 0.00
                        Dim SIZE As Integer = 0

                        If DTROW("MAINITEMUNIT") = "MTS" Then PROFORMAWT = DTROW("QTY") * 1000

                        If (DTROW("QUALITY") = "LDPE" Or DTROW("QUALITY") = "ADHESIVE") And Val(DTROW("PEGSM")) > 0 Then
                            QTY = Format(PROFORMAWT / TOTALGSM * Val(DTROW("PEGSM")), "0.000")
                            GSM = Val(DTROW("PEGSM"))
                            SIZE = 0
                        ElseIf DTROW("QUALITY") = "FOIL" Then
                            QTY = Format(PROFORMAWT / TOTALGSM * Val(DTROW("FOILGSM")), "0.000")
                            GSM = Val(DTROW("FOILGSM"))
                            SIZE = 0
                        Else
                            QTY = Format(PROFORMAWT / TOTALGSM * Val(DTROW("GSM")), "0.000")
                            GSM = Val(DTROW("GSM"))
                            SIZE = Val(DTROW("SIZE"))
                        End If

                        QTY = Format(QTY + (Val(TXTWASTAGEPER.Text.Trim) * QTY / 100), "0.00")
                        GRIDSALEORDER.Rows.Add(0, DTROW("QUALITY"), GSM, SIZE, Val(QTY), DTROW("MAINITEMUNIT"), Val(DTROW("SONO")), Val(DTROW("GRIDSRNO")), DTROW("FROMTYPE"))
                    Next

                    'For Each DTROW As DataRow In DTSO.Rows

                    '    'GET PE GSM AND CALCULATE THE WT
                    '    Dim TOTALGSM As Double = Val(DTROW("GSM")) + Val(DTROW("PEGSM")) + Val(DTROW("FOILGSM"))
                    '    Dim PROFORMAWT As Double = 0.00
                    '    Dim QTY As Double = 0.00
                    '    Dim GSM As Double = 0.00
                    '    Dim SIZE As Integer = 0

                    '    If DTROW("MAINITEMUNIT") = "MTS" Then PROFORMAWT = DTROW("QTY") * 1000

                    '    If (DTROW("ITEMNAME") = "LDPE" Or DTROW("ITEMNAME") = "ADHESIVE") And Val(DTROW("PEGSM")) > 0 Then
                    '        QTY = Format(PROFORMAWT / TOTALGSM * Val(DTROW("PEGSM")), "0.000")
                    '        GSM = Val(DTROW("PEGSM"))
                    '        SIZE = 0
                    '    ElseIf DTROW("ITEMNAME") = "FOIL" Then
                    '        QTY = Format(PROFORMAWT / TOTALGSM * Val(DTROW("FOILGSM")), "0.000")
                    '        GSM = Val(DTROW("FOILGSM"))
                    '        SIZE = 0
                    '    Else
                    '        QTY = Format(PROFORMAWT / TOTALGSM * Val(DTROW("GSM")), "0.000")
                    '        GSM = Val(DTROW("GSM"))
                    '        SIZE = Val(DTROW("SIZE"))
                    '    End If

                    '    QTY = Format(QTY + (Val(TXTWASTAGEPER.Text.Trim) * QTY / 100), "0.00")
                    '    GRIDSALEORDER.Rows.Add(0, DTROW("ITEMNAME"), GSM, SIZE, Val(QTY), DTROW("MAINITEMUNIT"), Val(DTROW("SONO")), Val(DTROW("GRIDSRNO")), DTROW("FROMTYPE"))
                    'Next



                    getsrno(GRIDSALEORDER)
                Next
                TOTAL()

                CMDSELECTSO.Enabled = False
            End If


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

            If CMBMACHINENO.Text.Trim <> "" Then

                Dim OBJSELECTPO As New SelectStock
                OBJSELECTPO.FRMSTRING = "MATREQ"
                OBJSELECTPO.GODOWN = CMBGODOWN.Text.Trim
                Dim DTPO As DataTable = OBJSELECTPO.DT
                OBJSELECTPO.ShowDialog()

                If DTPO.Rows.Count > 0 Then
                    For Each DTROWPS As DataRow In DTPO.Rows

                        For Each ROW As DataGridViewRow In GRIDMATREQ.Rows
                            If DTROWPS("BARCODE") <> "" And LCase(ROW.Cells(GBARCODE.Index).Value) = LCase(DTROWPS("BARCODE")) Or (DTROWPS("BARCODE") = "" And Val(ROW.Cells(GFROMNO.Index).Value) = Val(DTROWPS("FROMNO")) And Val(ROW.Cells(GFROMSRNO.Index).Value) = Val(DTROWPS("FROMSRNO"))) Then GoTo LINE1
                        Next

                        GRIDMATREQ.Rows.Add(0, DTROWPS("ITEMNAME"), DTROWPS("LOTNO"), DTROWPS("REELNO"), Val(DTROWPS("GSM")), Val(DTROWPS("SIZE")), Val(DTROWPS("QTY")), 0, DTROWPS("UNIT"), DTROWPS("BARCODE"), 0, Val(DTROWPS("FROMNO")), Val(DTROWPS("FROMSRNO")), 0)

LINE1:
                    Next

                    getsrno(GRIDMATREQ)
                    TOTAL()
                    'CMDSELECTSTOCK.Enabled = False

                End If
            Else
                MsgBox("Enter Machine No Name")
                CMBMACHINENO.Focus()
            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Sub



    Private Sub MaterialRequirement_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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
                GRIDMATREQ.Focus()
            ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for Delete
                tstxtbillno.Focus()
                tstxtbillno.SelectAll()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_Validating(sender As Object, e As CancelEventArgs) Handles tstxtbillno.Validating
        Try
            If Val(tstxtbillno.Text.Trim) > 0 Then
                GRIDMATREQ.RowCount = 0
                TEMPMATREQNO = Val(tstxtbillno.Text)
                If TEMPMATREQNO > 0 Then
                    EDIT = True
                    MaterialRequirement_Load(sender, e)
                Else
                    clear()
                    EDIT = False
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub TOTAL()
        Try
            LBLTOTALREELNO.Text = 0.0
            LBLTOTALDIFF.Text = 0.0
            LBLTOTALMILLQTY.Text = 0.0
            LBLTOTALSALEMILLQTY.Text = 0.0





            For Each ROW As DataGridViewRow In GRIDMATREQ.Rows
                If ROW.Cells(GISSUESRNO.Index).Value <> Nothing Then
                    LBLTOTALDIFF.Text = Val(LBLTOTALDIFF.Text) + Val(ROW.Cells(GDIFF.Index).EditedFormattedValue)
                    LBLTOTALMILLQTY.Text = Val(LBLTOTALMILLQTY.Text) + Val(ROW.Cells(GMILLQTY.Index).EditedFormattedValue)

                End If
            Next

            For Each ROW As DataGridViewRow In GRIDSALEORDER.Rows
                If ROW.Cells(EISSUESRNO.Index).Value <> Nothing Then
                    LBLTOTALSALEMILLQTY.Text = Val(LBLTOTALSALEMILLQTY.Text) + Val(ROW.Cells(EMILLQTY.Index).EditedFormattedValue)
                End If
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
            For i = 0 To GRIDMATREQ.Rows.Count - 1
                If Not GRIDMATREQ.Rows(i).IsNewRow Then
                    cellValue = GRIDMATREQ(GREELROLLNO.Index, i).EditedFormattedValue.ToString()
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

    Private Sub GRIDSALEORDER_KeyDown(sender As Object, e As KeyEventArgs) Handles GRIDSALEORDER.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDSALEORDER.RowCount > 0 Then
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                GRIDSALEORDER.Rows.RemoveAt(GRIDSALEORDER.CurrentRow.Index)
                TOTAL()
                getsrno(GRIDSALEORDER)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
End Class