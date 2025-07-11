
Imports System.ComponentModel
Imports BL

Public Class QualityCheck

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE, GRIDDOUBLECLICK, GRIDPARAMETERDOUBLECLICK, GRIDUPLOADDOUBLECLICK As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public EDIT As Boolean          'used for editing
    Public TEMPQCNO As String
    Dim TEMPROW, TEMPPARAMETERROW, TEMPUPLOADROW As Integer

    Private Sub cmdok_Click(sender As Object, e As EventArgs) Handles cmdok.Click
        Try
            Cursor.Current = Cursors.WaitCursor

            Dim IntResult As Integer


            If Not ERRORVALID() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList
            alParaval.Add(Val(TXTQCNO.Text.Trim))

            alParaval.Add(Format(Convert.ToDateTime(DTDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(TXTNAME.Text.Trim)
            alParaval.Add(TXTGRNNO.Text.Trim)
            alParaval.Add(TXTQCDONEBY.Text.Trim)
            alParaval.Add(DTGRNDATE.Value)
            alParaval.Add(CMBGODOWN.Text.Trim)
            alParaval.Add(TXTCHALLANNO.Text.Trim)
            alParaval.Add(CHALLANDATE.Text)
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(Val(LBLTOTALQTY.Text))
            alParaval.Add(Val(LBLTOTALACCQTY.Text))
            alParaval.Add(Val(LBLTOTALWASTEQTY.Text))
            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            Dim gridsrno As String = ""
            Dim QUALITY As String = ""
            Dim LOTNO As String = ""
            Dim REELNO As String = ""
            Dim GSM As String = ""
            Dim GSMDETAILS As String = ""
            Dim SIZE As String = ""
            Dim QTY As String = ""
            Dim WASTEDQTY As String = ""
            Dim ACCEPTEDQTY As String = ""
            Dim Unit As String = ""
            Dim STATUS As String = ""
            Dim Narration As String = ""
            Dim GRNNO As String = ""
            Dim GRNSRNO As String = ""
            Dim GRNTYPE As String = ""
            Dim BARCODE As String = ""
            Dim DONE As String = ""
            Dim OUTQTY As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDQC.Rows
                If row.Cells(0).Value <> Nothing Then
                    If gridsrno = "" Then
                        gridsrno = Val(row.Cells(gsrno.Index).Value)
                        QUALITY = row.Cells(GQUALITY.Index).Value.ToString
                        LOTNO = row.Cells(GLOTNO.Index).Value
                        REELNO = row.Cells(GREELNO.Index).Value
                        GSM = row.Cells(GGSM.Index).Value.ToString
                        GSMDETAILS = row.Cells(GGSMDETAILS.Index).Value.ToString
                        SIZE = row.Cells(GSIZE.Index).Value
                        QTY = Val(row.Cells(GQTY.Index).Value)
                        WASTEDQTY = Val(row.Cells(GWASTEDQTY.Index).Value)
                        ACCEPTEDQTY = Val(row.Cells(GACCEPTEDQTY.Index).Value)
                        Unit = row.Cells(GUnit.Index).Value.ToString
                        STATUS = row.Cells(GSTATUS.Index).Value.ToString
                        Narration = row.Cells(GNarrationn.Index).Value.ToString
                        GRNNO = Val(row.Cells(GFROMNO.Index).Value)
                        GRNSRNO = Val(row.Cells(GFROMSRNO.Index).Value)
                        GRNTYPE = row.Cells(GFROMTYPE.Index).Value.ToString
                        BARCODE = row.Cells(GBARCODE.Index).Value
                        If row.Cells(GDONE.Index).Value = True Then
                            DONE = 1
                        Else
                            DONE = 0
                        End If
                        OUTQTY = Val(row.Cells(GOUTQTY.Index).Value)

                    Else

                        gridsrno = gridsrno & "|" & Val(row.Cells(gsrno.Index).Value)
                        QUALITY = QUALITY & "|" & row.Cells(GQUALITY.Index).Value.ToString
                        LOTNO = LOTNO & "|" & row.Cells(GLOTNO.Index).Value
                        REELNO = REELNO & "|" & row.Cells(GREELNO.Index).Value
                        GSM = GSM & "|" & row.Cells(GGSM.Index).Value.ToString
                        GSMDETAILS = GSMDETAILS & "|" & row.Cells(GGSMDETAILS.Index).Value.ToString
                        SIZE = SIZE & "|" & row.Cells(GSIZE.Index).Value
                        QTY = QTY & "|" & Val(row.Cells(GQTY.Index).Value)
                        WASTEDQTY = WASTEDQTY & "|" & Val(row.Cells(GWASTEDQTY.Index).Value)
                        ACCEPTEDQTY = ACCEPTEDQTY & "|" & Val(row.Cells(GACCEPTEDQTY.Index).Value)
                        Unit = Unit & "|" & row.Cells(GUnit.Index).Value.ToString
                        STATUS = STATUS & "|" & row.Cells(GSTATUS.Index).Value.ToString
                        Narration = Narration & "|" & row.Cells(GNarrationn.Index).Value.ToString
                        GRNNO = GRNNO & "|" & Val(row.Cells(GFROMNO.Index).Value)
                        GRNSRNO = GRNSRNO & "|" & Val(row.Cells(GFROMSRNO.Index).Value)
                        GRNTYPE = GRNTYPE & "|" & row.Cells(GFROMTYPE.Index).Value.ToString
                        BARCODE = BARCODE & "|" & row.Cells(GBARCODE.Index).Value
                        If row.Cells(GDONE.Index).Value = True Then
                            DONE = DONE & "|" & "1"
                        Else
                            DONE = DONE & "|" & "0"
                        End If
                        OUTQTY = OUTQTY & "|" & Val(row.Cells(GOUTQTY.Index).Value)


                    End If
                End If
            Next

            alParaval.Add(gridsrno)
            alParaval.Add(QUALITY)
            alParaval.Add(LOTNO)
            alParaval.Add(REELNO)
            alParaval.Add(GSM)
            alParaval.Add(GSMDETAILS)
            alParaval.Add(SIZE)
            alParaval.Add(QTY)
            alParaval.Add(WASTEDQTY)
            alParaval.Add(ACCEPTEDQTY)
            alParaval.Add(Unit)
            alParaval.Add(STATUS)
            alParaval.Add(Narration)
            alParaval.Add(GRNNO)
            alParaval.Add(GRNSRNO)
            alParaval.Add(GRNTYPE)
            alParaval.Add(BARCODE)
            alParaval.Add(DONE)
            alParaval.Add(OUTQTY)


            Dim PGRIDSRNO As String = ""
            Dim PARAMETER As String = ""
            Dim PARTYOBS As String = ""
            Dim OUROBS As String = ""


            For Each row As Windows.Forms.DataGridViewRow In GRIDPARAMETER.Rows
                If row.Cells(0).Value <> Nothing Then
                    If PGRIDSRNO = "" Then
                        PGRIDSRNO = Val(row.Cells(PSRNO.Index).Value)
                        PARAMETER = row.Cells(PPARAMETER.Index).Value.ToString
                        PARTYOBS = row.Cells(PPARTYOBS.Index).Value.ToString
                        OUROBS = row.Cells(POUROBS.Index).Value.ToString


                    Else

                        PGRIDSRNO = PGRIDSRNO & "|" & Val(row.Cells(PSRNO.Index).Value)
                        PARAMETER = PARAMETER & "|" & row.Cells(PPARAMETER.Index).Value.ToString
                        PARTYOBS = PARTYOBS & "|" & row.Cells(PPARTYOBS.Index).Value.ToString
                        OUROBS = OUROBS & "|" & row.Cells(POUROBS.Index).Value.ToString



                    End If
                End If
            Next

            alParaval.Add(PGRIDSRNO)
            alParaval.Add(PARAMETER)
            alParaval.Add(PARTYOBS)
            alParaval.Add(OUROBS)




            Dim objclsPurord As New ClsQualityCheck()
            objclsPurord.alParaval = alParaval

            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim DT As DataTable = objclsPurord.SAVE()
                TXTQCNO.Text = DT.Rows(0).Item(0)
                MessageBox.Show("Details Added")

            Else


                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPQCNO)
                IntResult = objclsPurord.Update()
                MessageBox.Show("Details Updated")
                EDIT = False
            End If

            If GRIDUPLOADDESC.RowCount > 0 Then SAVEIMAGE()

            CLEAR()
            TXTNAME.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub SAVEIMAGE()
        Try
            'UPLOAD IMAGE
            Dim OBJQC As New ClsQualityCheck
            For Each row As Windows.Forms.DataGridViewRow In GRIDUPLOADDESC.Rows
                Dim ALPARAVAL As New ArrayList
                If row.Cells(0).Value <> Nothing Then

                    ALPARAVAL.Add(Val(TXTQCNO.Text.Trim))
                    ALPARAVAL.Add(Val(row.Cells(DSRNO.Index).Value))
                    ALPARAVAL.Add(row.Cells(DNAME.Index).Value.ToString)

                    If row.Cells(DIMGPATH.Index).Value IsNot Nothing Then
                        Dim MS As New IO.MemoryStream
                        PBIMG.Image = row.Cells(DIMGPATH.Index).Value
                        Dim IMG As New Bitmap(PBIMG.Image)
                        IMG.Save(MS, Drawing.Imaging.ImageFormat.Png)
                        ALPARAVAL.Add(MS.ToArray)
                    Else
                        ALPARAVAL.Add(DBNull.Value)
                    End If

                    ALPARAVAL.Add(Val(row.Cells(DMAINSRNO.Index).Value))
                    ALPARAVAL.Add(CmpId)
                    ALPARAVAL.Add(YearId)

                    OBJQC.alParaval = ALPARAVAL
                    Dim INTRES As Integer = OBJQC.SAVEIMAGE()

                End If
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function ERRORVALID() As Boolean

        Dim bln As Boolean = True
        If TXTNAME.Text.Trim.Length = 0 Then
            EP.SetError(TXTNAME, " Please Fill Party Name ")
            bln = False
        End If

        If CMBGODOWN.Text.Trim.Length = 0 Then
            EP.SetError(CMBGODOWN, " Please Select Godown")
            bln = False
        End If

        If TXTQCDONEBY.Text.Trim.Length = 0 Then
            EP.SetError(TXTQCDONEBY, " Please Select QC Done By")
            bln = False
        End If

        If lbllocked.Visible = True Then
            EP.SetError(lbllocked, "Item Used, Item Locked")
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

        If GRIDQC.RowCount = 0 Then
            EP.SetError(GRIDQC, " Please Enter Proper Details ")
            bln = False
        End If

        For Each ROW As DataGridViewRow In GRIDQC.Rows
            If ROW.Cells(GSTATUS.Index).Value = "" Then
                EP.SetError(TXTQCDONEBY, " Please Select Status")
                bln = False
            End If
            If ROW.Cells(GSTATUS.Index).Value = "Approved" And ROW.Cells(GACCEPTEDQTY.Index).Value = "0" Then
                EP.SetError(cmdok, " Please Check The Entry")
                bln = False
            End If
            If ROW.Cells(GSTATUS.Index).Value = "Rejected" And ROW.Cells(GWASTEDQTY.Index).Value = "0" Then
                EP.SetError(cmdok, " Please Check The Entry")
                bln = False
            End If
        Next

        Return bln
    End Function


    Private Sub QualityCheck_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow

            DTROW = USERRIGHTS.Select("FormName = 'QUALITY CHECK'")

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
                Dim OBJCLSINCENTIVE As New ClsQualityCheck
                Dim dttable As New DataTable

                dttable = OBJCLSINCENTIVE.SELECTQC(TEMPQCNO, CmpId, 0, YearId)
                If dttable.Rows.Count > 0 Then

                    For Each dr As DataRow In dttable.Rows

                        TXTQCNO.Text = TEMPQCNO
                        TXTQCNO.ReadOnly = True
                        DTDATE.Text = Format(Convert.ToDateTime(dr("DATE")), "dd/MM/yyyy")
                        TXTNAME.Text = Convert.ToString(dr("NAME"))
                        TXTGRNNO.Text = Convert.ToString(dr("GRNNO"))
                        TXTQCDONEBY.Text = Convert.ToString(dr("QCDONEBY"))
                        DTGRNDATE.Text = Format(Convert.ToDateTime(dr("GRNDATE")), "dd/MM/yyyy")
                        TXTCHALLANNO.Text = dr("CHALLANNO")
                        CHALLANDATE.Text = dr("CHALLANDATE")
                        CMBGODOWN.Text = Convert.ToString(dr("GODOWN"))
                        txtremarks.Text = Convert.ToString(dr("REMARKS"))
                        LBLTOTALQTY.Text = Convert.ToString(dr("TOTALQTY"))
                        LBLTOTALWASTEQTY.Text = Convert.ToString(dr("TOTALWASTEDQTY"))
                        LBLTOTALACCQTY.Text = Convert.ToString(dr("TOTALACCQTY"))


                        GRIDQC.Rows.Add(dr("GRIDSRNO"), Convert.ToString(dr("QUALITY")), dr("LOTNO"), dr("REELNO"), Val(dr("GSM")), dr("GSMDETAILS"), Val(dr("SIZE")), Val(dr("QTY")), Val(dr("WASTEQTY")), Val(dr("ACCQTY")), Convert.ToString(dr("UNIT")), Convert.ToString(dr("STATUS")), dr("NARRATION"), Val(dr("FROMNO")), Val(dr("FROMSRNO")), dr("FROMTYPE"), dr("BARCODE"), dr("DONE"), dr("OUTQTY"))
                        If Convert.ToBoolean(dr("DONE")) = True Or Val(dr("OUTQTY")) > 0 Then
                            GRIDQC.Rows(GRIDQC.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If
                    Next
                    TOTAL()

                    Dim dt As DataTable = OBJCMN.SEARCH("  ISNULL(QUALITYCHECK_PARAMETERS.QC_NO, 0) AS QCNO, ISNULL(QUALITYCHECK_PARAMETERS.QC_PGRIDSRNO, 0) AS PGRIDSRNO, ISNULL(QUALITYCHECK_PARAMETERS.QC_PARTYOBS, '') AS PARTYOBS, ISNULL(QUALITYCHECK_PARAMETERS.QC_OUROBS, '') AS OUROBS, ISNULL(QCPARAMETERMASTER.QC_name, '') AS PARAMETERNAME", "", "  QUALITYCHECK_PARAMETERS LEFT OUTER JOIN QCPARAMETERMASTER ON QUALITYCHECK_PARAMETERS.QC_PARAMETERID = QCPARAMETERMASTER.QC_id ", "  AND QUALITYCHECK_PARAMETERS.QC_NO = " & TEMPQCNO & " AND  QUALITYCHECK_PARAMETERS.QC_YEARID = " & YearId & " ORDER BY  QUALITYCHECK_PARAMETERS.QC_Pgridsrno")
                    If dt.Rows.Count > 0 Then
                        For Each DTR As DataRow In dt.Rows
                            GRIDPARAMETER.Rows.Add(DTR("PGRIDSRNO"), DTR("PARAMETERNAME"), DTR("PARTYOBS"), DTR("OUROBS"))
                        Next
                    End If

                    Dim OBJCM As New ClsCommon
                    dttable = OBJCM.SEARCH(" QC_GRIDSRNO AS GRIDSRNO, QC_NAME AS NAME, QC_IMGPATH AS IMGPATH, QC_MAINSRNO AS MAINSRNO", "", " QUALITYCHECK_UPLOAD", " AND QC_NO = " & TEMPQCNO & " AND QC_YEARID = " & YearId)
                    If dttable.Rows.Count > 0 Then
                        For Each DTR As DataRow In dttable.Rows
                            If IsDBNull(DTR("IMGPATH")) = False Then GRIDUPLOADDESC.Rows.Add(Val(DTR("GRIDSRNO")), DTR("NAME"), Image.FromStream(New IO.MemoryStream(DirectCast(DTR("IMGPATH"), Byte()))), Val(DTR("MAINSRNO"))) Else GRIDUPLOADDESC.Rows.Add(Val(DTR("GRIDSRNO")), DTR("NAME"), Nothing, Val(DTR("MAINSRNO")))
                        Next
                    End If

                    GRIDQC.FirstDisplayedScrollingRowIndex = GRIDQC.RowCount - 1
                Else
                    EDIT = False
                    CLEAR()
                End If
                CMDSELECTGRN.Enabled = False
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub FILLCMB()
        Try
            If CMBGODOWN.Text = "" Then fillGODOWN(CMBGODOWN, EDIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CLEAR()

        EP.Clear()
        CMBGODOWN.Text = ""
        If USERGODOWN <> "" Then CMBGODOWN.Text = USERGODOWN Else CMBGODOWN.Text = ""
        TXTQCNO.ReadOnly = True
        CMBQUALITY.Text = ""
        TXTACCEPTEDQTY.Clear()
        TXTLOTNO.Clear()
        TXTLOTNO.Clear()
        TXTGSMDETAILS.Clear()
        txtremarks.Clear()
        CMBUNIT.Text = ""
        TXTWASTEDQTY.Clear()
        TXTNAME.Clear()
        GRIDQC.RowCount = 0
        txtsrno.Clear()
        getmax_PONO()
        txtsrno.Text = 1
        tstxtbillno.Clear()
        txtremarks.Clear()
        DTDATE.Text = Now.Date
        TXTGRNNO.Clear()
        DTGRNDATE.Text = Now.Date

        TXTCHALLANNO.Clear()
        CHALLANDATE.Clear()

        TXTQTY.Clear()
        TXTNARRATION.Clear()
        TXTQCDONEBY.Clear()
        CMBSTATUS.Text = ""
        TXTOUROBS.Clear()
        TXTPARTYOBS.Clear()
        CMBPARAMETER.Text = ""
        CMDSELECTGRN.Enabled = True
        GRIDPARAMETER.RowCount = 0
        TXTREELNO.Clear()
        TXTGSM.Clear()
        TXTSIZE.Clear()

        TXTUPLOADSRNO.Text = 1
        txtuploadname.Clear()
        gridupload.RowCount = 0
        GRIDUPLOADDESC.RowCount = 0


        PBIMG.Image = Nothing
        GRIDDOUBLECLICK = False
        GRIDPARAMETERDOUBLECLICK = False
        GRIDUPLOADDOUBLECLICK = False
        GACCEPTEDQTY.ReadOnly = False
        GWASTEDQTY.ReadOnly = False
        GSTATUS.ReadOnly = False
        GNarrationn.ReadOnly = False
        LBLTOTALACCQTY.Text = 0.00
        LBLTOTALQTY.Text = 0.00
        LBLTOTALWASTEQTY.Text = 0.00


        lbllocked.Visible = False
        PBlock.Visible = False



    End Sub

    Sub getmax_PONO()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(QC_NO),0) + 1 ", "QUALITYCHECK", "  AND QC_cmpid=" & CmpId & " and QC_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTQCNO.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Sub FILLGRID()
        GRIDQC.Enabled = True
        If GRIDDOUBLECLICK = False Then
            GRIDQC.Rows.Add(Val(txtsrno.Text.Trim), CMBQUALITY.Text.Trim, TXTLOTNO.Text.Trim, Val(TXTREELNO.Text.Trim), Val(TXTGSM.Text.Trim), TXTGSMDETAILS.Text.Trim, Val(TXTSIZE.Text.Trim), Val(TXTQTY.Text.Trim), Val(TXTWASTEDQTY.Text.Trim), Val(TXTACCEPTEDQTY.Text.Trim), CMBUNIT.Text.Trim, CMBSTATUS.Text.Trim, TXTNARRATION.Text.Trim, 0, 0, "", TXTBARCODE.Text.Trim, 0, 0)
            If EDIT = True Then
                'GET LAST BARCODE SRNO
                Dim LSRNO As Integer = 0
                Dim RSRNO As Integer = 0
                Dim SNO As Integer = 0
                LSRNO = InStr(GRIDQC.Rows(GRIDQC.RowCount - 1).Cells(GBARCODE.Index).Value, "/")
                RSRNO = InStr(LSRNO + 1, GRIDQC.Rows(GRIDQC.RowCount - 1).Cells(GBARCODE.Index).Value, "/")
                SNO = GRIDQC.Rows(GRIDQC.RowCount - 1).Cells(GBARCODE.Index).Value.ToString.Substring(LSRNO, (RSRNO - LSRNO) - 1)

                TXTBARCODE.Text = "Q-" & Val(TXTQCNO.Text.Trim) & "/" & SNO + 1 & "/" & YearId
            Else
                TXTBARCODE.Text = "Q-" & Val(TXTQCNO.Text.Trim) & "/" & GRIDQC.RowCount + 1 & "/" & YearId
            End If

            getsrno(GRIDQC)
            'ElseIf GRIDDOUBLECLICK = True Then
            '    GRIDQC.Item(gsrno.Index, TEMPROW).Value = Val(txtsrno.Text.Trim)
            '    GRIDQC.Item(GQUALITY.Index, TEMPROW).Value = CMBQUALITY.Text.Trim
            '    GRIDQC.Item(GLOTNO.Index, TEMPROW).Value = TXTLOTNO.Text.Trim
            '    GRIDQC.Item(GREELNO.Index, TEMPROW).Value = TXTREELNO.Text.Trim
            '    GRIDQC.Item(GGSM.Index, TEMPROW).Value = TXTGSM.Text.Trim
            '    GRIDQC.Item(GSIZE.Index, TEMPROW).Value = TXTSIZE.Text.Trim
            '    GRIDQC.Item(GQTY.Index, TEMPROW).Value = TXTQTY.Text.Trim
            '    GRIDQC.Item(GWASTEDQTY.Index, TEMPROW).Value = TXTWASTEDQTY.Text.Trim
            '    GRIDQC.Item(GACCEPTEDQTY.Index, TEMPROW).Value = TXTACCEPTEDQTY.Text.Trim
            '    GRIDQC.Item(GUnit.Index, TEMPROW).Value = CMBUNIT.Text.Trim
            '    GRIDQC.Item(GSTATUS.Index, TEMPROW).Value = CMBSTATUS.Text.Trim
            '    GRIDQC.Item(GNarrationn.Index, TEMPROW).Value = TXTNARRATION.Text.Trim

            '    GRIDDOUBLECLICK = False
        End If

        TOTAL()
        GRIDQC.FirstDisplayedScrollingRowIndex = GRIDQC.RowCount - 1

        txtsrno.Text = GRIDQC.RowCount + 1
        CMBQUALITY.Text = ""
        CMBUNIT.Text = ""
        TXTSIZE.Clear()
        TXTGSM.Clear()
        TXTGSMDETAILS.Clear()
        TXTREELNO.Clear()
        TXTACCEPTEDQTY.Clear()
        TXTLOTNO.Clear()
        TXTWASTEDQTY.Clear()
        CMBSTATUS.Text = ""
        TXTNARRATION.Clear()
        TXTQTY.Clear()

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

    Private Sub TOOLNEXT_Click(sender As Object, e As EventArgs) Handles TOOLNEXT.Click
        Try
            GRIDQC.RowCount = 0
LINE1:
            TEMPQCNO = Val(TXTQCNO.Text) + 1
            getmax_PONO()
            Dim MAXNO As Integer = TXTQCNO.Text.Trim
            CLEAR()
            If Val(TXTQCNO.Text) - 1 >= TEMPQCNO Then
                EDIT = True
                QualityCheck_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
            If GRIDQC.RowCount = 0 And TEMPQCNO < MAXNO Then
                TXTQCNO.Text = TEMPQCNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TOOLPREVIOUS_Click(sender As Object, e As EventArgs) Handles TOOLPREVIOUS.Click
        Try
            GRIDQC.RowCount = 0
LINE1:
            TEMPQCNO = Val(TXTQCNO.Text) - 1
            If TEMPQCNO > 0 Then
                EDIT = True
                QualityCheck_Load(sender, e)
            Else
                CLEAR()
                EDIT = False
            End If
            If GRIDQC.RowCount = 0 And TEMPQCNO > 1 Then
                TXTQCNO.Text = TEMPQCNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
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

    Private Sub CMBQUALITY_Enter(sender As Object, e As EventArgs) Handles CMBQUALITY.Enter
        Try
            If CMBQUALITY.Text.Trim = "" Then FILLITEMNAME(CMBQUALITY, "")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBQUALITY_Validating(sender As Object, e As CancelEventArgs) Handles CMBQUALITY.Validating
        Try
            If CMBQUALITY.Text.Trim <> "" Then ITEMVALIDATE(CMBQUALITY, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'", "MERCHANT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdclear_Click(sender As Object, e As EventArgs) Handles cmdclear.Click
        Try
            CLEAR()
            EDIT = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(sender As Object, e As EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub CMBPARAMETER_Enter(sender As Object, e As EventArgs) Handles CMBPARAMETER.Enter
        Try
            If CMBPARAMETER.Text.Trim = "" Then FILLPARAMETER(CMBPARAMETER, EDIT)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTNARRATION_Validated(sender As Object, e As EventArgs) Handles TXTNARRATION.Validated
        Try
            If CMBQUALITY.Text.Trim <> "" And Val(TXTQTY.Text.Trim) > 0 And (Val(TXTWASTEDQTY.Text.Trim) > 0 Or Val(TXTACCEPTEDQTY.Text.Trim) > 0) And CMBUNIT.Text.Trim <> "" Then FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLPARAMETERGRID()
        GRIDPARAMETER.Enabled = True
        If GRIDPARAMETERDOUBLECLICK = False Then
            GRIDPARAMETER.Rows.Add(Val(TXTPGRIDSRNO.Text.Trim), CMBPARAMETER.Text.Trim, TXTPARTYOBS.Text.Trim, TXTOUROBS.Text.Trim)
            getsrno(GRIDPARAMETER)
        ElseIf GRIDPARAMETERDOUBLECLICK = True Then
            GRIDPARAMETER.Item(PSRNO.Index, TEMPPARAMETERROW).Value = Val(TXTPGRIDSRNO.Text.Trim)
            GRIDPARAMETER.Item(PPARAMETER.Index, TEMPPARAMETERROW).Value = CMBPARAMETER.Text.Trim
            GRIDPARAMETER.Item(PPARTYOBS.Index, TEMPPARAMETERROW).Value = TXTPARTYOBS.Text.Trim
            GRIDPARAMETER.Item(POUROBS.Index, TEMPPARAMETERROW).Value = TXTOUROBS.Text.Trim
            GRIDPARAMETERDOUBLECLICK = False
        End If

        GRIDPARAMETER.FirstDisplayedScrollingRowIndex = GRIDPARAMETER.RowCount - 1
        TXTPGRIDSRNO.Text = GRIDPARAMETER.RowCount + 1
        CMBPARAMETER.Text = ""
        TXTPARTYOBS.Clear()
        TXTOUROBS.Clear()

        CMBPARAMETER.Focus()

    End Sub

    Private Sub TXTOUROBS_Validated(sender As Object, e As EventArgs) Handles TXTOUROBS.Validated
        Try
            If CMBPARAMETER.Text.Trim <> "" And TXTOUROBS.Text.Trim <> "" Then FILLPARAMETERGRID()
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
            Dim OBJPAYDTLS As New QualityCheckDetails
            OBJPAYDTLS.MdiParent = MDIMain
            OBJPAYDTLS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(sender As Object, e As EventArgs) Handles cmddelete.Click
        Dim IntResult As Integer
        Try
            If EDIT = True Then

                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                If lbllocked.Visible = True Then
                    MsgBox("Quality Check Locked", MsgBoxStyle.Critical)
                    Exit Sub
                End If


                If MsgBox("Delete Quality Check ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                Dim alParaval As New ArrayList
                alParaval.Add(TEMPQCNO)
                alParaval.Add(YearId)

                Dim clspo As New ClsQualityCheck
                clspo.alParaval = alParaval
                IntResult = clspo.DELETE()
                MsgBox("Quality Check Deleted")
                CLEAR()
                EDIT = False

            Else
                MsgBox("Delete is only in Edit Mode")
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBPARAMETER_Validating(sender As Object, e As CancelEventArgs) Handles CMBPARAMETER.Validating
        Try
            If CMBPARAMETER.Text.Trim <> "" Then PARAMETERvalidate(CMBPARAMETER, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDSELECTGRN_Click(sender As Object, e As EventArgs) Handles CMDSELECTGRN.Click
        Try

            If (EDIT = True And USEREDIT = False And USERVIEW = False) Or (EDIT = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim OBJSELECTGRN As New SelectGRN
            Dim DTPO As DataTable = OBJSELECTGRN.DT
            OBJSELECTGRN.ShowDialog()

            If DTPO.Rows.Count > 0 Then

                ''  GETTING DISTINCT PONO NO IN TEXTBOX
                Dim DV As DataView = DTPO.DefaultView
                Dim NEWDT As DataTable = DV.ToTable(True, "GRNNO")
                For Each DTR As DataRow In NEWDT.Rows
                    If TXTGRNNO.Text.Trim = "" Then
                        TXTGRNNO.Text = DTR("GRNNO").ToString

                    Else
                        TXTGRNNO.Text = TXTGRNNO.Text & "," & DTR("GRNNO").ToString
                    End If
                Next

                For Each DTROW As DataRow In DTPO.Rows
                    TXTNAME.Text = DTROW("NAME")
                    DTGRNDATE.Text = DTROW("DATE")
                    TXTCHALLANNO.Text = DTROW("CHALLANNO")
                    CHALLANDATE.Text = DTROW("CHALLANDATE")

                    GRIDQC.Rows.Add(0, DTROW("QUALITY"), DTROW("LOTNO"), DTROW("REELNO"), DTROW("GSM"), DTROW("GSMDETAILS"), DTROW("SIZE"), Val(DTROW("QTY")), 0, 0, DTROW("UNIT"), "", "", Val(DTROW("GRNNO")), Val(DTROW("SRNO")), "GRN", "", 0, 0)

NEXTLINE:
                Next

                getsrno(GRIDQC)
                TOTAL()
                TXTNAME.Enabled = False
                CMDSELECTGRN.Enabled = False

            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub GRIDQC_KeyDown(sender As Object, e As KeyEventArgs) Handles GRIDQC.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDQC.RowCount > 0 Then

                'dont allow user if any of the grid line is in edit mode.....
                'cmbMERCHANT.Text.Trim <> Val(txtqty.Text) <> 0 And Val(txtamount.Text.Trim) <> 0 And cmbqtyunit.Text.Trim <> 
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                GRIDQC.Rows.RemoveAt(GRIDQC.CurrentRow.Index)
                TOTAL()
                getsrno(GRIDQC)
            ElseIf e.KeyCode = Keys.F5 Then
                EDITROW()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub EDITROW()
        Try
            If GRIDQC.CurrentRow.Index >= 0 And GRIDQC.Item(gsrno.Index, GRIDQC.CurrentRow.Index).Value <> Nothing Then

                GRIDDOUBLECLICK = True
                txtsrno.Text = GRIDQC.Item(gsrno.Index, GRIDQC.CurrentRow.Index).Value.ToString
                CMBQUALITY.Text = GRIDQC.Item(GQUALITY.Index, GRIDQC.CurrentRow.Index).Value.ToString
                TXTLOTNO.Text = GRIDQC.Item(GLOTNO.Index, GRIDQC.CurrentRow.Index).Value.ToString
                TXTREELNO.Text = GRIDQC.Item(GREELNO.Index, GRIDQC.CurrentRow.Index).Value.ToString
                TXTGSM.Text = GRIDQC.Item(GGSM.Index, GRIDQC.CurrentRow.Index).Value.ToString
                TXTGSMDETAILS.Text = GRIDQC.Item(GGSMDETAILS.Index, GRIDQC.CurrentRow.Index).Value.ToString
                TXTSIZE.Text = GRIDQC.Item(GSIZE.Index, GRIDQC.CurrentRow.Index).Value.ToString
                TXTQTY.Text = GRIDQC.Item(GQTY.Index, GRIDQC.CurrentRow.Index).Value.ToString
                TXTWASTEDQTY.Text = GRIDQC.Item(GWASTEDQTY.Index, GRIDQC.CurrentRow.Index).Value.ToString
                TXTACCEPTEDQTY.Text = GRIDQC.Item(GACCEPTEDQTY.Index, GRIDQC.CurrentRow.Index).Value.ToString
                CMBUNIT.Text = GRIDQC.Item(GUnit.Index, GRIDQC.CurrentRow.Index).Value.ToString
                CMBSTATUS.Text = GRIDQC.Item(GSTATUS.Index, GRIDQC.CurrentRow.Index).Value.ToString
                TXTNARRATION.Text = GRIDQC.Item(GNarrationn.Index, GRIDQC.CurrentRow.Index).Value.ToString

                TEMPROW = GRIDQC.CurrentRow.Index
                CMBQUALITY.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TOTAL()
        Try
            LBLTOTALQTY.Text = 0.0
            LBLTOTALWASTEQTY.Text = 0.0
            LBLTOTALACCQTY.Text = 0.0

            For Each ROW As DataGridViewRow In GRIDQC.Rows
                If Val(ROW.Cells(GQTY.Index).EditedFormattedValue) > 0 Then LBLTOTALQTY.Text = Format(Val(LBLTOTALQTY.Text) + Val(ROW.Cells(GQTY.Index).EditedFormattedValue), "0.000")
                If Val(ROW.Cells(GWASTEDQTY.Index).EditedFormattedValue) > 0 Then LBLTOTALWASTEQTY.Text = Format(Val(LBLTOTALWASTEQTY.Text) + Val(ROW.Cells(GWASTEDQTY.Index).EditedFormattedValue), "0.000")
                If Val(ROW.Cells(GACCEPTEDQTY.Index).EditedFormattedValue) > 0 Then LBLTOTALACCQTY.Text = Format(Val(LBLTOTALACCQTY.Text) + Val(ROW.Cells(GACCEPTEDQTY.Index).EditedFormattedValue), "0.000")

            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtremarks_KeyDown(sender As Object, e As KeyEventArgs) Handles txtremarks.KeyDown
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

    'FOR IMAGE
    Sub FILLGRIDSCAN()
        Try
            If GRIDUPLOADDOUBLECLICK = False Then

                gridupload.Rows.Add(Val(TXTUPLOADSRNO.Text.Trim), txtuploadname.Text.Trim, PBIMG.Image, Val(GRIDQC.CurrentRow.Cells(gsrno.Index).Value))
                GRIDUPLOADDESC.Rows.Add(Val(TXTUPLOADSRNO.Text.Trim), txtuploadname.Text.Trim, PBIMG.Image, Val(GRIDQC.CurrentRow.Cells(gsrno.Index).Value))
                uploadgetsrno(gridupload)

            ElseIf GRIDUPLOADDOUBLECLICK = True Then


                'FIRST GETTING ROWNO WITH RESPECT TO GRIDPAYDESC'S SRNO AND PAYMENT'S GRIDSRNO
                Dim ROWNO As Integer = 0
                For Each ROW As DataGridViewRow In GRIDUPLOADDESC.Rows
                    If ROW.Cells(DSRNO.Index).Value = gridupload.CurrentRow.Cells(GGRIDUPLOADSRNO.Index).Value And ROW.Cells(DMAINSRNO.Index).Value = (GRIDQC.CurrentRow.Index + 1) Then
                        ROWNO = ROW.Index
                        Exit For
                    End If
                Next

                GRIDUPLOADDESC.Item(DSRNO.Index, ROWNO).Value = TXTUPLOADSRNO.Text.Trim
                GRIDUPLOADDESC.Item(DNAME.Index, ROWNO).Value = txtuploadname.Text.Trim
                GRIDUPLOADDESC.Item(DIMGPATH.Index, ROWNO).Value = PBIMG.Image


                gridupload.Item(GGRIDUPLOADSRNO.Index, TEMPUPLOADROW).Value = TXTUPLOADSRNO.Text.Trim
                gridupload.Item(GNAME.Index, TEMPUPLOADROW).Value = txtuploadname.Text.Trim
                gridupload.Item(GIMGPATH.Index, TEMPUPLOADROW).Value = PBIMG.Image

                GRIDUPLOADDOUBLECLICK = False

            End If
            gridupload.FirstDisplayedScrollingRowIndex = gridupload.RowCount - 1
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdupload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdupload.Click

        If (EDIT = True And USEREDIT = False And USERVIEW = False) Or (EDIT = False And USERADD = False) Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If

        OpenFileDialog1.Filter = "Pictures (*.bmp;*.jpeg;*.jpg;*.png)|*.bmp;*.jpeg;*.jpg;*.png"
        OpenFileDialog1.ShowDialog()

        OpenFileDialog1.AddExtension = True
        txtuploadname.Text = OpenFileDialog1.SafeFileName
        PBIMG.Load(OpenFileDialog1.FileName)

    End Sub

    Private Sub txtuploadname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtuploadname.Validating
        Try
            If PBIMG.ImageLocation <> "" And txtuploadname.Text.Trim <> "" And GRIDQC.RowCount > 0 Then
                FILLGRIDSCAN()
                txtuploadname.Clear()
                PBIMG.ImageLocation = ""
                txtuploadname.Focus()
                TXTUPLOADSRNO.Text = gridupload.RowCount + 1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub gridupload_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridupload.CellDoubleClick
        Try
            If gridupload.Rows(e.RowIndex).Cells(GGRIDUPLOADSRNO.Index).Value <> Nothing Then
                GRIDUPLOADDOUBLECLICK = True
                TEMPUPLOADROW = e.RowIndex
                TXTUPLOADSRNO.Text = gridupload.Rows(e.RowIndex).Cells(GGRIDUPLOADSRNO.Index).Value
                txtuploadname.Text = gridupload.Rows(e.RowIndex).Cells(GNAME.Index).Value
                PBIMG.Image = gridupload.Rows(e.RowIndex).Cells(GIMGPATH.Index).Value
                txtuploadname.Focus()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridupload_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridupload.KeyDown
        Try
            If e.KeyCode = Keys.Delete And gridupload.RowCount > 0 Then

                'if LINE IS IN EDIT MODE (GRIDDESCDOUBLECLICK = TRUE) THEN DONT ALLOW TO DELETE
                If GRIDUPLOADDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If


                'REMOVING ALL ROWS FROM GRIDUPLOADDESC AND THEN REINSERT WITH RESPECT TO MAIN SRNO
1:
                For Each ROW As DataGridViewRow In GRIDUPLOADDESC.Rows
                    If ROW.Cells(DMAINSRNO.Index).Value = (GRIDQC.CurrentRow.Index + 1) Then
                        GRIDUPLOADDESC.Rows.RemoveAt(ROW.Index)
                        GoTo 1
                    End If
                Next


                gridupload.Rows.RemoveAt(gridupload.CurrentRow.Index)
                uploadgetsrno(gridupload)
                TXTUPLOADSRNO.Text = gridupload.RowCount + 1

                'AGAIN INSERT THE COMPLETE GRIDUPLOAD IN GRIDUPLOADDESC
                For Each ROW As DataGridViewRow In gridupload.Rows
                    GRIDUPLOADDESC.Rows.Add(ROW.Cells(GGRIDUPLOADSRNO.Index).Value, ROW.Cells(GNAME.Index).Value, ROW.Cells(GIMGPATH.Index).Value, GRIDQC.CurrentRow.Index + 1)
                Next

            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub CMDREMOVE_Click(sender As Object, e As EventArgs) Handles CMDREMOVE.Click
        Try
            PBIMG.Image = Nothing
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDVIEW_Click(sender As Object, e As EventArgs) Handles CMDVIEW.Click
        Try
            If gridupload.SelectedRows.Count > 0 Then
                Dim objVIEW As New ViewImage
                objVIEW.pbsoftcopy.Image = PBIMG.Image
                objVIEW.ShowDialog()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtuploadsrno_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTUPLOADSRNO.GotFocus
        If GRIDUPLOADDOUBLECLICK = False Then
            If gridupload.RowCount > 0 Then
                TXTUPLOADSRNO.Text = Val(gridupload.Rows(gridupload.RowCount - 1).Cells(GGRIDUPLOADSRNO.Index).Value) + 1
            Else
                TXTUPLOADSRNO.Text = 1
            End If
        End If
    End Sub

    Sub uploadgetsrno(ByRef grid As System.Windows.Forms.DataGridView)
        Try
            'If edit = False Then
            Dim i As Integer = 0
            For Each row As DataGridViewRow In grid.Rows
                If row.Visible = True Then
                    row.Cells(GGRIDUPLOADSRNO.Index).Value = i + 1
                    i = i + 1
                End If
            Next
            'End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TOOLPRINT_Click(sender As Object, e As EventArgs) Handles TOOLPRINT.Click
        Try
            If EDIT = True Then PRINTREPORT(TEMPQCNO)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PRINTREPORT(ByVal QCNO As Integer)
        Try
            If MsgBox("Wish to Print Rejected QC Report?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim OBJGRN As New GRNDesign
                OBJGRN.MdiParent = MDIMain
                OBJGRN.GRNNO = QCNO
                OBJGRN.FRMSTRING = "QC"
                OBJGRN.FORMULA = "{QUALITYCHECK.QC_NO} = " & QCNO & " AND  {QUALITYCHECK.QC_YEARID} = " & YearId
                OBJGRN.Show()
            End If

            If MsgBox("Wish to Print QC Test Report?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim OBJGRN As New GRNDesign
                OBJGRN.MdiParent = MDIMain
                OBJGRN.GRNNO = QCNO
                OBJGRN.FRMSTRING = "QCTEST"
                OBJGRN.FORMULA = "{QUALITYCHECK.QC_NO} = " & QCNO & " AND {QUALITYCHECK.QC_YEARID} = " & YearId
                OBJGRN.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SaveToolStripButton_Click(sender As Object, e As EventArgs) Handles SaveToolStripButton.Click
        Call cmdok_Click(sender, e)
    End Sub

    Private Sub TOOLDELETE_Click(sender As Object, e As EventArgs) Handles TOOLDELETE.Click
        Call cmddelete_Click(sender, e)
    End Sub

    Private Sub QualityCheck_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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
                GRIDQC.Focus()
            ElseIf e.Alt = True And e.KeyCode = Keys.Left Then
                TOOLPREVIOUS_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Keys.Right Then
                TOOLNEXT_Click(sender, e)
            ElseIf e.Alt = True And e.KeyCode = Windows.Forms.Keys.F1 Then
                Call OpenToolStripButton_Click(sender, e)

            ElseIf e.KeyCode = Windows.Forms.Keys.F2 Then       'for billno foucs
                tstxtbillno.Focus()
                tstxtbillno.SelectAll()

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTGSM_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTGSM.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub TXTQTY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTQTY.KeyPress, TXTREELNO.KeyPress, TXTACCEPTEDQTY.KeyPress, TXTACCEPTEDQTY.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub GRIDPARAMETER_KeyDown(sender As Object, e As KeyEventArgs) Handles GRIDPARAMETER.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDPARAMETER.RowCount > 0 Then
                If GRIDPARAMETERDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If

                GRIDPARAMETER.Rows.RemoveAt(GRIDPARAMETER.CurrentRow.Index)
                getsrno(GRIDPARAMETER)

            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GRIDPARAMETER_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRIDPARAMETER.CellDoubleClick
        Try
            If GRIDPARAMETER.CurrentRow.Index >= 0 And GRIDPARAMETER.Item(PSRNO.Index, GRIDPARAMETER.CurrentRow.Index).Value <> Nothing Then

                GRIDPARAMETERDOUBLECLICK = True
                TXTPGRIDSRNO.Text = GRIDPARAMETER.Item(PSRNO.Index, GRIDPARAMETER.CurrentRow.Index).Value.ToString
                CMBPARAMETER.Text = GRIDPARAMETER.Item(PPARAMETER.Index, GRIDPARAMETER.CurrentRow.Index).Value.ToString
                TXTPARTYOBS.Text = GRIDPARAMETER.Item(PPARTYOBS.Index, GRIDPARAMETER.CurrentRow.Index).Value.ToString
                TXTOUROBS.Text = GRIDPARAMETER.Item(POUROBS.Index, GRIDPARAMETER.CurrentRow.Index).Value.ToString
                TEMPPARAMETERROW = GRIDPARAMETER.CurrentRow.Index
                CMBPARAMETER.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDQC_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles GRIDQC.CellValidating
        Dim colNum As Integer = GRIDQC.Columns(e.ColumnIndex).Index
        If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return
        Select Case colNum

            Case GWASTEDQTY.Index, GACCEPTEDQTY.Index
                Dim dDebit As Decimal
                Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                If bValid Then
                    If GRIDQC.CurrentCell.Value = Nothing Then GRIDQC.CurrentCell.Value = "0.00"
                    GRIDQC.CurrentCell.Value = Convert.ToDecimal(GRIDQC.Item(colNum, e.RowIndex).Value)
                    TOTAL()
                Else
                    MessageBox.Show("Invalid Number Entered")
                    e.Cancel = True
                    Exit Sub
                End If

            Case GSTATUS.Index
                If GRIDQC.Item(GSTATUS.Index, GRIDQC.CurrentRow.Index).EditedFormattedValue = "Approved" Then
                    GRIDQC.Item(GACCEPTEDQTY.Index, GRIDQC.CurrentRow.Index).Value = GRIDQC.Item(GQTY.Index, GRIDQC.CurrentRow.Index).EditedFormattedValue
                    GRIDQC.Item(GWASTEDQTY.Index, GRIDQC.CurrentRow.Index).Value = 0
                Else
                    GRIDQC.Item(GWASTEDQTY.Index, GRIDQC.CurrentRow.Index).Value = GRIDQC.Item(GQTY.Index, GRIDQC.CurrentRow.Index).EditedFormattedValue
                    GRIDQC.Item(GACCEPTEDQTY.Index, GRIDQC.CurrentRow.Index).Value = 0
                End If

        End Select

    End Sub

    Private Sub GRIDQC_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRIDQC.CellClick
        Try
            GETDESCDATA(GRIDQC.CurrentRow.Index + 1)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETDESCDATA(ByVal ROWNO As Integer)
        Try
            gridupload.RowCount = 0
            PBIMG.Image = Nothing
            txtuploadname.Clear()
            For Each ROW As DataGridViewRow In GRIDUPLOADDESC.Rows
                If ROW.Cells(DMAINSRNO.Index).Value = ROWNO Then
                    gridupload.Rows.Add(ROW.Cells(DSRNO.Index).Value, ROW.Cells(DNAME.Index).Value, ROW.Cells(DIMGPATH.Index).Value, Val(ROW.Cells(DMAINSRNO.Index).Value))
                End If
            Next
            getsrno(gridupload)
            TXTUPLOADSRNO.Text = gridupload.RowCount + 1

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class