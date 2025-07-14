
Imports System.ComponentModel
Imports BL

Public Class ProdReceived

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE, GRIDDOUBLECLICK, GRIDWASTAGEDOUBLECLICK, GRIDPROCESSDOUBLECLICK, GRIDSINGLEDOUBLECLICK As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public EDIT As Boolean          'used for editing
    Public TEMPPRODRECDNO As String
    Public TEMPMSG As Integer
    Dim TEMPROW, TEMPWASTAGEROW, TEMPPROCESSROW, TEMPSINGLEROW As Integer

    Private Sub cmdclear_Click(sender As Object, e As EventArgs) Handles cmdclear.Click
        clear()
        EDIT = False
        DTRECDDATE.Focus()
    End Sub

    Private Sub cmdexit_Click(sender As Object, e As EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub clear()

        TXTRECDNO.ReadOnly = True
        CMBGODOWN.Text = ""
        TXTPROFORMANO.Clear()
        TXTMACHINENO.Clear()
        TXTJONO.Clear()
        TXTPROFORMANO.Clear()
        TXTFINALQUALITY.Clear()
        TXTJONO.Clear()
        GRIDPRODISSUE.RowCount = 0
        GRIDWASTAGE.RowCount = 0
        GRIDRECD.RowCount = 0
        GRIDGSM.RowCount = 0
        '   PBRECD.Visible = False
        lbllocked.Visible = False
        PBlock.Visible = False
        '   cmdshowdetails.Enabled = True
        TXTJOSRNO.Clear()
        DTJODATE.Text = Now.Date
        TXTJOTYPE.Clear()
        TXTSONO.Text = ""
        TXTSOTYPE.Clear()
        TXTISSUENO.Text = ""
        DTISSUEDATE.Text = Now.Date
        DTSODATE.Text = Now.Date
        TXTGRIDPRISSUSRNO.Text = ""
        TXTGRIDPRISSUSRNO.Text = 1
        CMBQUALITY.Text = ""
        TXTLOTNO.Clear()
        TXTREELROLLNO.Clear()
        TXTGSM.Clear()
        TXTSIZE.Clear()
        TXTOURQTY.Clear()
        TXTDIFF.Clear()
        CMBUNIT.Text = ""
        TXTGRIDWASTAGESRNO.Text = 1
        CMBWASTAGETYPE.Text = ""
        TXTWT.Clear()
        getmax_RECDNO()
        tstxtbillno.Clear()
        TXTISSUENO.Clear()
        DTRECDDATE.Text = Now.Date
        TXTREMARK.Clear()
        CMBOPERATOR.Text = ""
        TXTSHIFT.Clear()
        TXTHEATINGTIME.Clear()
        TXTRUNNINGTIME.Clear()
        TXTSTOPTIME.Clear()
        TXTTOTALISSWT.Clear()
        TXTTOTALRECDWT.Clear()
        TXTTOTALBALWT.Clear()
        TXTTOTALWASWT.Clear()
        TXTTOTALFINALBALWT.Clear()
        TXTWASTAGEPERCENTAGE.Clear()
        LBLTOTALISSUEROLLNO.Text = 0.0
        LBLTOTALISSUEDIFF.Text = 0.0
        LBLTOTALWASTAGEWT.Text = 0.0
        LBLTOTALROLLNO.Text = 0.0
        LBLRECDWT.Text = 0.0
        LBLTOTALGSM.Text = 0.0
        CMDSELECTISSUE.Enabled = True
        TXTGRIDSINGLERECDSRNO.Text = 1
        TXTROLLNO.Clear()
        TXTRECDWT.Clear()
        CMBIUNIT.Text = ""
        TXTJOINT.Clear()
        TXTNARRATION.Clear()
        TXTGRIDPROCESSSRNO.Text = 1
        CMBGRADE.Text = ""
        TXTMICRON.Clear()
        TXTMGSM.Clear()
        TXTMILLQTY.Clear()
        TXTNAME.Clear()
        GRIDDOUBLECLICK = False
        GRIDWASTAGEDOUBLECLICK = False
        GRIDPROCESSDOUBLECLICK = False
        GRIDSINGLEDOUBLECLICK = False

        TXTIGSMDETAILS.Clear()
        TXTIGSMDETAILS.Clear()
        TXTRLOTNO.Clear()
        TXTRGSM.Clear()
        TXTRSIZE.Clear()

        lbllocked.Visible = False
        PBlock.Visible = False

    End Sub

    Sub getmax_RECDNO()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(RECD_NO),0) + 1 ", "PRODUCTRECEIVED", "  AND RECD_cmpid=" & CmpId & " and RECD_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTRECDNO.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Private Sub GRIDPRODISSUE_KeyDown(sender As Object, e As KeyEventArgs) Handles GRIDPRODISSUE.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDPRODISSUE.RowCount > 0 Then
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                GRIDPRODISSUE.Rows.RemoveAt(GRIDPRODISSUE.CurrentRow.Index)
                TOTAL()
                getsrno(GRIDPRODISSUE)
            ElseIf e.KeyCode = Keys.F5 Then
                EDITROW()

            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GRIDWASTAGE_KeyDown(sender As Object, e As KeyEventArgs) Handles GRIDWASTAGE.KeyDown
        Try
            If e.KeyCode = Keys.Delete Then
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                GRIDWASTAGE.Rows.RemoveAt(GRIDWASTAGE.CurrentRow.Index)
                TOTAL()
                getsrno(GRIDWASTAGE)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLCMB()
        Try
            If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, EDIT)
            If CMBQUALITY.Text.Trim = "" Then FILLITEMNAME(CMBQUALITY, " AND ITEM_FRMSTRING = 'MERCHANT'")
            If CMBUNIT.Text.Trim = "" Then FILLUNIT(CMBUNIT)
            If CMBIUNIT.Text.Trim = "" Then FILLUNIT(CMBIUNIT)
            If CMBOPERATOR.Text.Trim = "" Then FILLOPERATOR(CMBOPERATOR)
            If CMBWASTAGETYPE.Text.Trim = "" Then FILLWASTEITEM(CMBWASTAGETYPE, "AND ITEMMASTER.ITEM_MATERIALTYPE = 'WASTAGE'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ProdReceived_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow

            DTROW = USERRIGHTS.Select("FormName = 'SALE INVOICE'")

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
                Dim OBJCLSINCENTIVE As New ClsProdReceived
                Dim dttable As New DataTable

                dttable = OBJCLSINCENTIVE.selectRECEIVED(TEMPPRODRECDNO, CmpId, YearId)
                If dttable.Rows.Count > 0 Then

                    For Each dr As DataRow In dttable.Rows

                        TXTRECDNO.Text = TEMPPRODRECDNO
                        TXTRECDNO.ReadOnly = True
                        DTRECDDATE.Text = Format(Convert.ToDateTime(dr("RECDDATE")), "dd/MM/yyyy")
                        DTJODATE.Text = Format(Convert.ToDateTime(dr("JODATE")), "dd/MM/yyyy")
                        TXTJOTYPE.Text = dr("JOTYPE")
                        DTSODATE.Text = Format(Convert.ToDateTime(dr("SODATE")), "dd/MM/yyyy")
                        TXTSOTYPE.Text = dr("SOTYPE")
                        CMBGODOWN.Text = Convert.ToString(dr("GODOWN"))
                        TXTMACHINENO.Text = dr("MACHINE")
                        TXTPROFORMANO.Text = dr("PROFORMANO")
                        TXTFINALQUALITY.Text = dr("FINALQUALITY")
                        TXTJONO.Text = dr("JONO")
                        TXTJOSRNO.Text = dr("JOSRNO")
                        TXTSONO.Text = dr("SONO")
                        TXTREMARK.Text = dr("REMARK")
                        TXTISSUENO.Text = dr("ISSUENO")
                        DTISSUEDATE.Text = Format(Convert.ToDateTime(dr("ISSUEDATE")), "dd/MM/yyyy")
                        CMBOPERATOR.Text = Convert.ToString(dr("OPERATOR"))
                        TXTSHIFT.Text = dr("SHIFT")
                        TXTHEATINGTIME.Text = dr("HEATINGTIME")
                        TXTRUNNINGTIME.Text = dr("RUNNINGTIME")
                        TXTSTOPTIME.Text = dr("STOPTIME")
                        TXTTOTALISSWT.Text = dr("TOTALISSWT")
                        TXTTOTALRECDWT.Text = dr("TOTALRECDWT")
                        TXTTOTALBALWT.Text = dr("TOTALBALWT")
                        TXTTOTALWASWT.Text = dr("TOTALWASWT")
                        TXTTOTALFINALBALWT.Text = dr("TOTALFINALBALWT")
                        TXTWASTAGEPERCENTAGE.Text = dr("WASTAGEPERCENTAGE")
                        LBLTOTALISSUEROLLNO.Text = dr("TOTALREELNO")
                        LBLTOTALISSUEDIFF.Text = dr("TOTALDIFF")
                        LBLTOTALWASTAGEWT.Text = dr("TOTALWT")
                        LBLTOTALROLLNO.Text = dr("TOTALROLLNO")
                        LBLRECDWT.Text = dr("TOTALISSRECDWT")
                        LBLTOTALGSM.Text = dr("TOTALGSM")
                        TXTNAME.Text = dr("NAME")


                        GRIDPRODISSUE.Rows.Add(dr("GRIDPRISSUSRNO").ToString, dr("QUALITY").ToString, dr("LOTNO").ToString, dr("REELROLLNO").ToString, dr("GSM").ToString, dr("IGSMDETAILS").ToString, dr("SIZE").ToString, Val(dr("MILLQTY")), Val(dr("OURQTY")), Val(dr("DIFF")), dr("UNIT").ToString, Val(dr("FROMNO")), Val(dr("FROMSRNO")))
                        'FOR WASTAGE
                    Next
                    Dim OBJPRI As New ClsCommon
                    dttable = OBJPRI.SEARCH("ISNULL(PRODUCTRECEIVED_WASTAGE.RECD_GRIDWASTAGESRNO, 0) AS GRIDWASTAGESRNO, ISNULL(ITEMMASTER.item_name, '') AS WASTAGETYPE, ISNULL(PRODUCTRECEIVED_WASTAGE.RECD_WT, '') AS WT ", "", " PRODUCTRECEIVED_WASTAGE LEFT OUTER JOIN ITEMMASTER ON PRODUCTRECEIVED_WASTAGE.RECD_WASTAGETYPEID = ITEMMASTER.item_id", " AND RECD_NO = " & TEMPPRODRECDNO & " AND RECD_CMPID = " & CmpId & " AND RECD_YEARID = " & YearId)
                    If dttable.Rows.Count > 0 Then
                        For Each dr As DataRow In dttable.Rows
                            GRIDWASTAGE.Rows.Add(dr("GRIDWASTAGESRNO").ToString, dr("WASTAGETYPE").ToString, Val(dr("WT")))
                        Next
                    End If

                    'FOR PROCESS

                    Dim OBJPRO As New ClsCommon
                    dttable = OBJPRO.SEARCH("ISNULL(PRODUCTRECEIVED_PROCESS.RECD_GRIDPROCESSSRNO, 0) AS GRIDPROCESSSRNO, ISNULL(ITEMMASTER.ITEM_NAME, '') AS GRADE, ISNULL(PRODUCTRECEIVED_PROCESS.RECD_MICRON, '') AS MICRON, ISNULL(PRODUCTRECEIVED_PROCESS.RECD_GSM, '') AS MGSM ", "", " PRODUCTRECEIVED_PROCESS LEFT OUTER JOIN ITEMMASTER ON PRODUCTRECEIVED_PROCESS.RECD_GRADEID = ITEMMASTER.item_id", " AND RECD_NO = " & TEMPPRODRECDNO & " AND RECD_CMPID = " & CmpId & " AND RECD_YEARID = " & YearId)
                    If dttable.Rows.Count > 0 Then
                        For Each dr As DataRow In dttable.Rows
                            GRIDGSM.Rows.Add(dr("GRIDPROCESSSRNO").ToString, dr("GRADE").ToString, dr("MICRON").ToString, dr("MGSM").ToString)
                        Next
                    End If
                    'FOR SINGLE
                    Dim OBJSING As New ClsCommon
                    dttable = OBJPRI.SEARCH("ISNULL(PRODUCTRECEIVED_SINGLERECD.RECD_GRIDSINGLERECDSRNO, 0) AS GRIDSINGLERECDSRNO, ISNULL(PRODUCTRECEIVED_SINGLERECD.RECD_ROLLNO, '') AS IROLLNO, ISNULL(PRODUCTRECEIVED_SINGLERECD.RECD_LOTNO, '') AS RLOTNO, ISNULL(PRODUCTRECEIVED_SINGLERECD.RECD_GSM, 0) AS RGSM, ISNULL(PRODUCTRECEIVED_SINGLERECD.RECD_GSMDETAILS, 0) AS GSMDETAILS, ISNULL(PRODUCTRECEIVED_SINGLERECD.RECD_SIZE, 0)AS RSIZE, ISNULL(PRODUCTRECEIVED_SINGLERECD.RECD_RECDWT,0) AS RECDWT, ISNULL(UNITMASTER.unit_abbr, '') AS IUNIT, ISNULL(PRODUCTRECEIVED_SINGLERECD.RECD_JOINT,'') AS JOINT, ISNULL(PRODUCTRECEIVED_SINGLERECD.RECD_NARRATION, '') AS NARRATION , ISNULL(PRODUCTRECEIVED_SINGLERECD.RECD_FQCDONE, '') AS FQCDONE , ISNULL(PRODUCTRECEIVED_SINGLERECD.RECD_BARCODE, '') AS BARCODE , ISNULL(PRODUCTRECEIVED_SINGLERECD.RECD_DONE, 0) AS DONE  , ISNULL(PRODUCTRECEIVED_SINGLERECD.RECD_OUTQTY, 0) AS OUTQTY  ", "", " PRODUCTRECEIVED_SINGLERECD LEFT OUTER JOIN UNITMASTER ON PRODUCTRECEIVED_SINGLERECD.RECD_UNITID = UNITMASTER.unit_id", " AND RECD_NO = " & TEMPPRODRECDNO & " AND RECD_CMPID = " & CmpId & " AND RECD_YEARID = " & YearId)
                    If dttable.Rows.Count > 0 Then
                        For Each dr As DataRow In dttable.Rows
                            GRIDRECD.Rows.Add(dr("GRIDSINGLERECDSRNO").ToString, dr("IROLLNO").ToString, dr("RLOTNO").ToString, Val(dr("RGSM")).ToString, dr("GSMDETAILS").ToString, Val(dr("RSIZE")).ToString, Val(dr("RECDWT")).ToString, dr("IUNIT").ToString, dr("JOINT").ToString, dr("NARRATION").ToString, dr("BARCODE").ToString, dr("FQCDONE").ToString, Val(dr("DONE")), Val(dr("OUTQTY")))

                            If Convert.ToBoolean(dr("FQCDONE")) = True Or Val(dr("FQCDONE")) > 0 Then
                                GRIDRECD.Rows(GRIDRECD.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                                lbllocked.Visible = True
                                PBlock.Visible = True
                            End If

                            If Convert.ToBoolean(dr("DONE")) = True Or Val(dr("OUTQTY")) > 0 Then
                                GRIDRECD.Rows(GRIDRECD.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                                lbllocked.Visible = True
                                PBlock.Visible = True
                            End If


                        Next
                    End If

                    TOTAL()
                    GRIDPRODISSUE.FirstDisplayedScrollingRowIndex = GRIDPRODISSUE.RowCount - 1
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
            If TXTRECDNO.ReadOnly = False Then
                alParaval.Add(Val(TXTRECDNO.Text.Trim))
            Else
                alParaval.Add(0)
            End If
            alParaval.Add(Format(Convert.ToDateTime(DTRECDDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(Format(Convert.ToDateTime(DTJODATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(TXTJOTYPE.Text.Trim)
            alParaval.Add(Format(Convert.ToDateTime(DTSODATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(TXTSOTYPE.Text.Trim)
            alParaval.Add(CMBGODOWN.Text.Trim)
            alParaval.Add(TXTMACHINENO.Text.Trim)
            alParaval.Add(TXTPROFORMANO.Text.Trim)
            alParaval.Add(TXTFINALQUALITY.Text.Trim)
            alParaval.Add(TXTJONO.Text.Trim)
            alParaval.Add(TXTJOSRNO.Text.Trim)
            alParaval.Add(TXTSONO.Text.Trim)
            alParaval.Add(TXTREMARK.Text.Trim)
            alParaval.Add(TXTISSUENO.Text.Trim)
            alParaval.Add(Format(Convert.ToDateTime(DTISSUEDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(CMBOPERATOR.Text.Trim)
            alParaval.Add(TXTSHIFT.Text.Trim)
            alParaval.Add(TXTHEATINGTIME.Text.Trim)
            alParaval.Add(TXTRUNNINGTIME.Text.Trim)
            alParaval.Add(TXTSTOPTIME.Text.Trim)
            alParaval.Add(TXTTOTALISSWT.Text.Trim)
            alParaval.Add(TXTTOTALRECDWT.Text.Trim)
            alParaval.Add(TXTTOTALBALWT.Text.Trim)
            alParaval.Add(TXTTOTALWASWT.Text.Trim)
            alParaval.Add(TXTTOTALFINALBALWT.Text.Trim)
            alParaval.Add(TXTWASTAGEPERCENTAGE.Text.Trim)
            alParaval.Add(Val(LBLTOTALISSUEROLLNO.Text.Trim))
            alParaval.Add(Val(LBLTOTALISSUEDIFF.Text.Trim))
            alParaval.Add(Val(LBLTOTALWASTAGEWT.Text.Trim))
            alParaval.Add(Val(LBLTOTALROLLNO.Text.Trim))
            alParaval.Add(Val(LBLRECDWT.Text.Trim))
            alParaval.Add(Val(LBLTOTALGSM.Text.Trim))
            alParaval.Add(TXTNAME.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)

            Dim GRIDPRISSUESRNO As String = ""
            Dim QUALITY As String = ""
            Dim LOTNO As String = ""
            Dim REELROLLNO As String = ""
            Dim GSM As String = ""
            Dim IGSMDETAILS As String = ""
            Dim SIZE As String = ""
            Dim MILLQTY As String = ""
            Dim OURQTY As String = ""
            Dim DIFF As String = ""
            Dim UNIT As String = ""
            Dim FROMNO As String = ""
            Dim FROMSRNO As String = ""


            For Each row As Windows.Forms.DataGridViewRow In GRIDPRODISSUE.Rows
                If row.Cells(0).Value <> Nothing Then
                    If GRIDPRISSUESRNO = "" Then
                        GRIDPRISSUESRNO = Val(row.Cells(GRECDSRNO.Index).Value)
                        QUALITY = row.Cells(GQUALITY.Index).Value.ToString
                        LOTNO = row.Cells(GLOTNO.Index).Value.ToString
                        REELROLLNO = row.Cells(GREELROLLNO.Index).Value.ToString
                        GSM = Val(row.Cells(GGSM.Index).Value)
                        IGSMDETAILS = row.Cells(GGSMDETAILS.Index).Value.ToString
                        SIZE = Val(row.Cells(GSIZE.Index).Value)
                        MILLQTY = Val(row.Cells(GMILLQTY.Index).Value)
                        OURQTY = Val(row.Cells(GOURQTY.Index).Value)
                        DIFF = Val(row.Cells(GDIFF.Index).Value)
                        UNIT = row.Cells(GUNIT.Index).Value.ToString
                        FROMNO = Val(row.Cells(GFROMNO.Index).Value)
                        FROMSRNO = Val(row.Cells(GFROMSRNO.Index).Value)
                    Else

                        GRIDPRISSUESRNO = GRIDPRISSUESRNO & "|" & Val(row.Cells(GRECDSRNO.Index).Value)
                        QUALITY = QUALITY & "|" & row.Cells(GQUALITY.Index).Value.ToString
                        LOTNO = LOTNO & "|" & row.Cells(GLOTNO.Index).Value.ToString
                        REELROLLNO = REELROLLNO & "|" & row.Cells(GREELROLLNO.Index).Value.ToString
                        GSM = GSM & "|" & Val(row.Cells(GGSM.Index).Value)
                        IGSMDETAILS = IGSMDETAILS & "|" & row.Cells(GGSMDETAILS.Index).Value.ToString
                        SIZE = SIZE & "|" & Val(row.Cells(GSIZE.Index).Value)
                        MILLQTY = MILLQTY & "|" & Val(row.Cells(GMILLQTY.Index).Value)
                        OURQTY = OURQTY & "|" & Val(row.Cells(GOURQTY.Index).Value)
                        DIFF = DIFF & "|" & Val(row.Cells(GDIFF.Index).Value)
                        UNIT = UNIT & "|" & row.Cells(GUNIT.Index).Value.ToString
                        FROMNO = FROMNO & "|" & Val(row.Cells(GFROMNO.Index).Value)
                        FROMSRNO = FROMSRNO & "|" & Val(row.Cells(GFROMSRNO.Index).Value)
                    End If
                End If
            Next

            alParaval.Add(GRIDPRISSUESRNO)
            alParaval.Add(QUALITY)
            alParaval.Add(LOTNO)
            alParaval.Add(REELROLLNO)
            alParaval.Add(GSM)
            alParaval.Add(IGSMDETAILS)
            alParaval.Add(SIZE)
            alParaval.Add(MILLQTY)
            alParaval.Add(OURQTY)
            alParaval.Add(DIFF)
            alParaval.Add(UNIT)
            alParaval.Add(FROMNO)
            alParaval.Add(FROMSRNO)

            '' FOR WASTAGE GRID''
            Dim GRIDWASTAGESRNO As String = ""
            Dim WASTAGETYPE As String = ""
            Dim WT As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDWASTAGE.Rows
                If row.Cells(0).Value <> Nothing Then
                    If GRIDWASTAGESRNO = "" Then
                        GRIDWASTAGESRNO = Val(row.Cells(GWASTAGESRNO.Index).Value)
                        WASTAGETYPE = row.Cells(GWASTAGETYPE.Index).Value.ToString
                        WT = Val(row.Cells(GWASTAGEWT.Index).Value)

                    Else

                        GRIDWASTAGESRNO = GRIDWASTAGESRNO & "|" & Val(row.Cells(GWASTAGESRNO.Index).Value)
                        WASTAGETYPE = WASTAGETYPE & "|" & row.Cells(GWASTAGETYPE.Index).Value.ToString
                        WT = WT & "|" & Val(row.Cells(GWASTAGEWT.Index).Value)

                    End If
                End If
            Next

            alParaval.Add(GRIDWASTAGESRNO)
            alParaval.Add(WASTAGETYPE)
            alParaval.Add(WT)

            'PROCESS ---

            Dim GRIDPROCESSSRNO As String = ""
            Dim GRADE As String = ""
            Dim MICRON As String = ""
            Dim MGSM As String = ""

            For Each row As Windows.Forms.DataGridViewRow In GRIDGSM.Rows
                If row.Cells(0).Value <> Nothing Then
                    If GRIDPROCESSSRNO = "" Then
                        GRIDPROCESSSRNO = Val(row.Cells(MGRIDPROCESSSRNO.Index).Value)
                        GRADE = row.Cells(MGRADE.Index).Value.ToString
                        MICRON = row.Cells(MMICRON.Index).Value.ToString
                        MGSM = row.Cells(MMGSM.Index).Value.ToString

                    Else

                        GRIDPROCESSSRNO = GRIDPROCESSSRNO & "|" & Val(row.Cells(MGRIDPROCESSSRNO.Index).Value)
                        GRADE = GRADE & "|" & row.Cells(MGRADE.Index).Value.ToString
                        MICRON = MICRON & "|" & row.Cells(MMICRON.Index).Value.ToString
                        MGSM = MGSM & "|" & row.Cells(MMGSM.Index).Value.ToString

                    End If
                End If
            Next

            alParaval.Add(GRIDPROCESSSRNO)
            alParaval.Add(GRADE)
            alParaval.Add(MICRON)
            alParaval.Add(MGSM)

            ' SINGLE ISSUSUE

            Dim GRIDSINGLERECDSRNO As String = ""
            Dim ROLLNO As String = ""
            Dim RLOTNO As String = ""
            Dim RGSM As String = ""
            Dim GSMDETAILS As String = ""
            Dim RSIZE As String = ""
            Dim RECDWT As String = ""
            Dim IUNIT As String = ""
            Dim JOINT As String = ""
            Dim NARRATION As String = ""
            Dim BARCODE As String = ""
            Dim FQCDONE As String = ""
            Dim DONE As String = ""
            Dim OUTQTY As String = ""



            For Each row As Windows.Forms.DataGridViewRow In GRIDRECD.Rows
                If row.Cells(0).Value <> Nothing Then
                    If GRIDSINGLERECDSRNO = "" Then
                        GRIDSINGLERECDSRNO = Val(row.Cells(SGRIDSINGLERECDSRNO.Index).Value)
                        ROLLNO = row.Cells(SROLLNO.Index).Value.ToString
                        RLOTNO = row.Cells(SLOTNO.Index).Value.ToString
                        RGSM = Val(row.Cells(SGSM.Index).Value)
                        GSMDETAILS = row.Cells(SGSMDETAILS.Index).Value.ToString
                        RSIZE = Val(row.Cells(SSIZE.Index).Value)
                        RECDWT = Val(row.Cells(SRECDWT.Index).Value)
                        IUNIT = row.Cells(SIUNIT.Index).Value.ToString
                        JOINT = row.Cells(SJOINT.Index).Value.ToString
                        NARRATION = row.Cells(SNARRATION.Index).Value.ToString
                        BARCODE = row.Cells(GBARCODE.Index).Value.ToString
                        If row.Cells(SFQCDONE.Index).Value = True Then
                            FQCDONE = 1
                        Else
                            FQCDONE = 0
                        End If

                        If row.Cells(GDONE.Index).Value = True Then
                            DONE = 1
                        Else
                            DONE = 0
                        End If
                        OUTQTY = Val(row.Cells(GOUTQTY.Index).Value)

                    Else

                        GRIDSINGLERECDSRNO = GRIDSINGLERECDSRNO & "|" & Val(row.Cells(SGRIDSINGLERECDSRNO.Index).Value)
                        ROLLNO = ROLLNO & "|" & row.Cells(SROLLNO.Index).Value.ToString
                        RLOTNO = RLOTNO & "|" & row.Cells(SLOTNO.Index).Value.ToString
                        RGSM = RGSM & "|" & Val(row.Cells(SGSM.Index).Value)
                        GSMDETAILS = GSMDETAILS & "|" & row.Cells(SGSMDETAILS.Index).Value.ToString
                        RSIZE = RSIZE & "|" & Val(row.Cells(SSIZE.Index).Value)
                        RECDWT = RECDWT & "|" & Val(row.Cells(SRECDWT.Index).Value)
                        IUNIT = IUNIT & "|" & row.Cells(SIUNIT.Index).Value.ToString
                        JOINT = JOINT & "|" & row.Cells(SJOINT.Index).Value.ToString
                        NARRATION = NARRATION & "|" & row.Cells(SNARRATION.Index).Value.ToString
                        BARCODE = BARCODE & "|" & row.Cells(GBARCODE.Index).Value.ToString
                        If row.Cells(SFQCDONE.Index).Value = True Then
                            FQCDONE = FQCDONE & "|" & "1"
                        Else
                            FQCDONE = FQCDONE & "|" & "0"
                        End If
                        If row.Cells(GDONE.Index).Value = True Then
                            DONE = DONE & "|" & "1"
                        Else
                            DONE = DONE & "|" & "0"
                        End If
                        OUTQTY = OUTQTY & "|" & Val(row.Cells(GOUTQTY.Index).Value)


                    End If
                End If
            Next

            alParaval.Add(GRIDSINGLERECDSRNO)
            alParaval.Add(ROLLNO)
            alParaval.Add(RLOTNO)
            alParaval.Add(RGSM)
            alParaval.Add(GSMDETAILS)
            alParaval.Add(RSIZE)
            alParaval.Add(RECDWT)
            alParaval.Add(IUNIT)
            alParaval.Add(JOINT)
            alParaval.Add(NARRATION)
            alParaval.Add(BARCODE)
            alParaval.Add(FQCDONE)
            alParaval.Add(DONE)
            alParaval.Add(OUTQTY)


            Dim objclsPurord As New ClsProdReceived()
            objclsPurord.alParaval = alParaval

            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim DT As DataTable = objclsPurord.SAVE()
                MessageBox.Show("Details Added")
                TXTRECDNO.Text = DT.Rows(0).Item(0)
            Else


                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPPRODRECDNO)
                IntResult = objclsPurord.UPDATE()
                MessageBox.Show("Details Updated")
                EDIT = False
            End If

            PRINTREPORT(TXTRECDNO.Text.Trim)
            clear()
            CMBQUALITY.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Function ERRORVALID() As Boolean

        Dim bln As Boolean = True
        If CMBGODOWN.Text.Trim.Length = 0 Then
            EP.SetError(CMBGODOWN, " Please Fill Godown ")
            bln = False
        End If

        If DTRECDDATE.Text = "__/__/____" Then
            EP.SetError(DTRECDDATE, " Please Enter Proper Date")
            bln = False
        Else
            If Not datecheck(DTRECDDATE.Text) Then
                EP.SetError(DTRECDDATE, "Date not in Accounting Year")
                bln = False
            End If
        End If

        If GRIDPRODISSUE.RowCount = 0 Then
            EP.SetError(GRIDPRODISSUE, " Please Select Issue Details ")
            bln = False
        End If

        If GRIDRECD.RowCount = 0 Then
            EP.SetError(GRIDRECD, " Please Enter Recd Roll Details ")
            bln = False
        End If

        For Each row As DataGridViewRow In GRIDPRODISSUE.Rows
            If Val(row.Cells(GOURQTY.Index).Value) = 0 Then
                EP.SetError(LBLTOTALISSUEDIFF, "Mtrs & Pcs Cannot be 0")
                bln = False
            End If
        Next

        If lbllocked.Visible = True Then
            EP.SetError(lbllocked, "Entry Locked ")
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
                    MsgBox("Production Locked", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                TEMPMSG = MsgBox("Delete Product Received ?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim alParaval As New ArrayList
                    alParaval.Add(TXTRECDNO.Text.Trim)
                    alParaval.Add(Userid)
                    alParaval.Add(CmpId)
                    alParaval.Add(YearId)

                    Dim ClsINCTAG As New ClsProdReceived()
                    ClsINCTAG.alParaval = alParaval
                    IntResult = ClsINCTAG.Delete()
                    MsgBox("Product Received Deleted")
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
            GRIDPRODISSUE.RowCount = 0
LINE1:
            TEMPPRODRECDNO = Val(TXTRECDNO.Text) - 1
            If TEMPPRODRECDNO > 0 Then
                EDIT = True
                ProdReceived_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If

            If GRIDPRODISSUE.RowCount = 0 And TEMPPRODRECDNO > 1 Then
                TXTRECDNO.Text = TEMPPRODRECDNO
                GoTo LINE1
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(sender As Object, e As EventArgs) Handles toolnext.Click
        Try
            GRIDPRODISSUE.RowCount = 0
LINE1:
            TEMPPRODRECDNO = Val(TXTRECDNO.Text) + 1
            getmax_RECDNO()
            Dim MAXNO As Integer = TXTRECDNO.Text.Trim
            clear()
            If Val(TXTRECDNO.Text) - 1 >= TEMPPRODRECDNO Then
                EDIT = True
                ProdReceived_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDPRODISSUE.RowCount = 0 And TEMPPRODRECDNO < MAXNO Then
                TXTRECDNO.Text = TEMPPRODRECDNO
                GoTo LINE1
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub FILLGRID()
        Try
            If GRIDDOUBLECLICK = False Then
                GRIDPRODISSUE.Rows.Add(Val(TXTISSUENO.Text.Trim), CMBQUALITY.Text.Trim, TXTLOTNO.Text.Trim, TXTREELROLLNO.Text.Trim, TXTGSM.Text.Trim, TXTIGSMDETAILS.Text.Trim, TXTSIZE.Text.Trim, TXTMILLQTY.Text.Trim, TXTOURQTY.Text.Trim, TXTDIFF.Text.Trim, CMBUNIT.Text.Trim)
                getsrno(GRIDPRODISSUE)
            ElseIf GRIDDOUBLECLICK = True Then
                GRIDPRODISSUE.Item(GRECDSRNO.Index, TEMPROW).Value = Val(TXTGRIDPRISSUSRNO.Text.Trim)
                GRIDPRODISSUE.Item(GQUALITY.Index, TEMPROW).Value = CMBQUALITY.Text.Trim
                GRIDPRODISSUE.Item(GLOTNO.Index, TEMPROW).Value = (TXTLOTNO.Text.Trim)
                GRIDPRODISSUE.Item(GREELROLLNO.Index, TEMPROW).Value = (TXTREELROLLNO.Text.Trim)
                GRIDPRODISSUE.Item(GGSM.Index, TEMPROW).Value = (TXTGSM.Text.Trim)
                GRIDPRODISSUE.Item(GGSMDETAILS.Index, TEMPROW).Value = (TXTIGSMDETAILS.Text.Trim)
                GRIDPRODISSUE.Item(GSIZE.Index, TEMPROW).Value = (TXTSIZE.Text.Trim)
                GRIDPRODISSUE.Item(GMILLQTY.Index, TEMPROW).Value = (TXTMILLQTY.Text.Trim)
                GRIDPRODISSUE.Item(GOURQTY.Index, TEMPROW).Value = (TXTOURQTY.Text.Trim)
                GRIDPRODISSUE.Item(GDIFF.Index, TEMPROW).Value = (TXTDIFF.Text.Trim)
                GRIDPRODISSUE.Item(GUNIT.Index, TEMPROW).Value = (CMBUNIT.Text.Trim)


                GRIDDOUBLECLICK = False

            End If

            GRIDPRODISSUE.FirstDisplayedScrollingRowIndex = GRIDPRODISSUE.RowCount - 1

            TXTGRIDPRISSUSRNO.Text = GRIDPRODISSUE.RowCount + 1
            CMBQUALITY.Text = ""
            TXTLOTNO.Clear()
            TXTREELROLLNO.Clear()
            TXTGSM.Clear()
            TXTSIZE.Clear()
            TXTMILLQTY.Clear()
            TXTOURQTY.Clear()
            TXTDIFF.Clear()
            CMBUNIT.Text = ""


            CMBQUALITY.Focus()
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

    Sub EDITROW()
        Try
            If GRIDPRODISSUE.CurrentRow.Index >= 0 And GRIDPRODISSUE.Item(GRECDSRNO.Index, GRIDPRODISSUE.CurrentRow.Index).Value <> Nothing Then
                GRIDDOUBLECLICK = True
                TXTGRIDPRISSUSRNO.Text = GRIDPRODISSUE.Item(GRECDSRNO.Index, GRIDPRODISSUE.CurrentRow.Index).Value.ToString
                CMBQUALITY.Text = GRIDPRODISSUE.Item(GQUALITY.Index, GRIDPRODISSUE.CurrentRow.Index).Value.ToString
                TXTLOTNO.Text = GRIDPRODISSUE.Item(GLOTNO.Index, GRIDPRODISSUE.CurrentRow.Index).Value.ToString
                TXTREELROLLNO.Text = GRIDPRODISSUE.Item(GREELROLLNO.Index, GRIDPRODISSUE.CurrentRow.Index).Value.ToString
                TXTGSM.Text = GRIDPRODISSUE.Item(GGSM.Index, GRIDPRODISSUE.CurrentRow.Index).Value.ToString
                TXTSIZE.Text = GRIDPRODISSUE.Item(GSIZE.Index, GRIDPRODISSUE.CurrentRow.Index).Value.ToString
                TXTMILLQTY.Text = GRIDPRODISSUE.Item(GMILLQTY.Index, GRIDPRODISSUE.CurrentRow.Index).Value.ToString
                TXTOURQTY.Text = GRIDPRODISSUE.Item(GOURQTY.Index, GRIDPRODISSUE.CurrentRow.Index).Value.ToString
                TXTDIFF.Text = GRIDPRODISSUE.Item(GDIFF.Index, GRIDPRODISSUE.CurrentRow.Index).Value.ToString
                CMBUNIT.Text = GRIDPRODISSUE.Item(GUNIT.Index, GRIDPRODISSUE.CurrentRow.Index).Value.ToString


                TEMPROW = GRIDPRODISSUE.CurrentRow.Index
                CMBQUALITY.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub DTISSUEDATE_GotFocus(sender As Object, e As EventArgs) Handles DTISSUEDATE.GotFocus
        DTISSUEDATE.SelectionStart = 0
    End Sub

    Private Sub GRIDPRODISSUE_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRIDPRODISSUE.CellDoubleClick
        Try
            EDITROW()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBWASTAGETYPE_Enter(sender As Object, e As EventArgs) Handles CMBWASTAGETYPE.Enter
        Try
            If CMBWASTAGETYPE.Text.Trim = "" Then FILLWASTEITEM(CMBWASTAGETYPE, "AND ITEMMASTER.ITEM_MATERIALTYPE = 'WASTAGE'")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBWASTAGETYPE_Validating(sender As Object, e As CancelEventArgs) Handles CMBWASTAGETYPE.Validating
        Try
            If CMBWASTAGETYPE.Text.Trim <> "" Then ITEMWASTEVALIDATE(CMBWASTAGETYPE, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'", "MERCHANT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBUNIT_Validated(sender As Object, e As EventArgs) Handles CMBUNIT.Validated
        Try
            Fillgrid()
            TOTAL()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Private Sub CMBMACHINENO_Validating(sender As Object, e As CancelEventArgs)
    '    Try
    '        If CMBMACHINENO.Text.Trim <> "" Then MACHINEVALIDATE(CMBMACHINENO, e, Me)
    '    Catch ex As Exception
    '        If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
    '    End Try
    'End Sub

    'Private Sub CMBMACHINENO_Enter(sender As Object, e As EventArgs)
    '    Try
    '        If CMBMACHINENO.Text.Trim <> "" Then FILLMACHINE(CMBMACHINENO)

    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

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

    Private Sub GRIDWASTAG_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRIDWASTAGE.CellDoubleClick
        Try
            If GRIDWASTAGE.CurrentRow.Index >= 0 And GRIDWASTAGE.Item(GRECDSRNO.Index, GRIDWASTAGE.CurrentRow.Index).Value <> Nothing Then
                GRIDDOUBLECLICK = True
                TXTGRIDWASTAGESRNO.Text = GRIDWASTAGE.Item(GWASTAGESRNO.Index, GRIDWASTAGE.CurrentRow.Index).Value.ToString
                CMBWASTAGETYPE.Text = GRIDWASTAGE.Item(GWASTAGETYPE.Index, GRIDWASTAGE.CurrentRow.Index).Value.ToString
                TXTWT.Text = GRIDWASTAGE.Item(GWASTAGEWT.Index, GRIDWASTAGE.CurrentRow.Index).Value.ToString

                TEMPROW = GRIDWASTAGE.CurrentRow.Index
                CMBWASTAGETYPE.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBOPERATOR_Enter(sender As Object, e As EventArgs) Handles CMBOPERATOR.Enter
        Try
            If CMBOPERATOR.Text.Trim <> "" Then FILLOPERATOR(CMBOPERATOR)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBOPERATOR_Validating(sender As Object, e As CancelEventArgs) Handles CMBOPERATOR.Validating
        Try
            If CMBOPERATOR.Text.Trim <> "" Then OPERATORVALIDATE(CMBOPERATOR, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGRADE_Enter(sender As Object, e As EventArgs) Handles CMBGRADE.Enter
        Try
            If CMBGRADE.Text.Trim = "" Then FILLITEMNAME(CMBGRADE, "")
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

    Private Sub CMBQUALITY_Validating(sender As Object, e As CancelEventArgs) Handles CMBQUALITY.Validating
        Try
            If CMBQUALITY.Text.Trim <> "" Then ITEMVALIDATE(CMBQUALITY, e, Me, "", "MERCHANT")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBGRADE_Validating(sender As Object, e As CancelEventArgs) Handles CMBGRADE.Validating
        Try
            If CMBGRADE.Text.Trim <> "" Then ITEMVALIDATE(CMBGRADE, e, Me, "", "MERCHANT")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBIUNIT_Enter(sender As Object, e As EventArgs)
        Try
            If CMBIUNIT.Text.Trim = "" Then FILLUNIT(CMBIUNIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBUNIT_Enter(sender As Object, e As EventArgs) Handles CMBUNIT.Enter
        Try
            If CMBUNIT.Text.Trim = "" Then FILLUNIT(CMBUNIT)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBUNIT_Validating(sender As Object, e As CancelEventArgs) Handles CMBUNIT.Validating
        Try
            If CMBUNIT.Text.Trim <> "" Then unitvalidate(CMBUNIT, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBIUNIT_Validating(sender As Object, e As CancelEventArgs)
        Try
            If CMBIUNIT.Text.Trim <> "" Then unitvalidate(CMBIUNIT, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillwastagegrid()
        If GRIDWASTAGEDOUBLECLICK = False Then
            GRIDWASTAGE.Rows.Add(Val(TXTGRIDWASTAGESRNO.Text.Trim), CMBWASTAGETYPE.Text.Trim, Val(TXTWT.Text.Trim))
            getsrno(GRIDWASTAGE)
        ElseIf GRIDWASTAGEDOUBLECLICK = True Then
            GRIDWASTAGE.Item(GWASTAGESRNO.Index, TEMPWASTAGEROW).Value = Val(TXTGRIDWASTAGESRNO.Text.Trim)
            GRIDWASTAGE.Item(GWASTAGETYPE.Index, TEMPWASTAGEROW).Value = CMBWASTAGETYPE.Text.Trim
            GRIDWASTAGE.Item(GWASTAGEWT.Index, TEMPWASTAGEROW).Value = (TXTWT.Text.Trim)

            GRIDWASTAGEDOUBLECLICK = False

        End If

        GRIDWASTAGE.FirstDisplayedScrollingRowIndex = GRIDWASTAGE.RowCount - 1

        TXTGRIDWASTAGESRNO.Clear()
        CMBWASTAGETYPE.Text = ""
        TXTWT.Clear()
        CMBWASTAGETYPE.Focus()
    End Sub

    Sub EDITWASTAGEROW()
        Try

            If GRIDWASTAGE.CurrentRow.Index >= 0 And GRIDWASTAGE.Item(GWASTAGESRNO.Index, GRIDWASTAGE.CurrentRow.Index).Value <> Nothing Then
                GRIDWASTAGEDOUBLECLICK = True
                TXTGRIDWASTAGESRNO.Text = GRIDWASTAGE.Item(GWASTAGESRNO.Index, GRIDWASTAGE.CurrentRow.Index).Value.ToString
                CMBWASTAGETYPE.Text = GRIDWASTAGE.Item(GWASTAGETYPE.Index, GRIDWASTAGE.CurrentRow.Index).Value.ToString
                TXTWT.Text = GRIDWASTAGE.Item(GWASTAGEWT.Index, GRIDWASTAGE.CurrentRow.Index).Value.ToString

                TEMPWASTAGEROW = GRIDWASTAGE.CurrentRow.Index
                CMBWASTAGETYPE.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDWASTAGE_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRIDWASTAGE.CellDoubleClick
        Try
            EDITWASTAGEROW()
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
            Dim objgrndetails As New ProdReceivedDetails
            objgrndetails.MdiParent = MDIMain
            objgrndetails.Show()
            objgrndetails.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub TXTWT_Validated(sender As Object, e As EventArgs) Handles TXTWT.Validated
        Try
            fillwastagegrid()
            TOTAL()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDSELECTISSUEENTRY_Click(sender As Object, e As EventArgs)

    End Sub

    Sub FILLGRIDPROCESS()
        If GRIDPROCESSDOUBLECLICK = False Then
            GRIDGSM.Rows.Add(Val(TXTGRIDPROCESSSRNO.Text.Trim), CMBGRADE.Text.Trim, TXTMICRON.Text.Trim, TXTMGSM.Text.Trim)
            getsrno(GRIDGSM)
        ElseIf GRIDPROCESSDOUBLECLICK = True Then
            GRIDGSM.Item(MGRIDPROCESSSRNO.Index, TEMPPROCESSROW).Value = Val(TXTGRIDPROCESSSRNO.Text.Trim)
            GRIDGSM.Item(MGRADE.Index, TEMPPROCESSROW).Value = CMBGRADE.Text.Trim
            GRIDGSM.Item(MMICRON.Index, TEMPPROCESSROW).Value = (TXTMICRON.Text.Trim)
            GRIDGSM.Item(MMGSM.Index, TEMPPROCESSROW).Value = (TXTMGSM.Text.Trim)


            GRIDPROCESSDOUBLECLICK = False

        End If
        ' TOTAL()

        GRIDGSM.FirstDisplayedScrollingRowIndex = GRIDGSM.RowCount - 1

        TXTGRIDPROCESSSRNO.Clear()
        CMBGRADE.Text = ""
        TXTMICRON.Clear()
        TXTMGSM.Clear()

        CMBGRADE.Focus()

    End Sub

    Sub EDITPROCESSROW()
        Try

            If GRIDGSM.CurrentRow.Index >= 0 And GRIDGSM.Item(MGRIDPROCESSSRNO.Index, GRIDGSM.CurrentRow.Index).Value <> Nothing Then
                GRIDPROCESSDOUBLECLICK = True
                TXTGRIDPROCESSSRNO.Text = GRIDGSM.Item(MGRIDPROCESSSRNO.Index, GRIDGSM.CurrentRow.Index).Value.ToString
                CMBGRADE.Text = GRIDGSM.Item(MGRADE.Index, GRIDGSM.CurrentRow.Index).Value.ToString
                TXTMICRON.Text = GRIDGSM.Item(MMICRON.Index, GRIDGSM.CurrentRow.Index).Value.ToString
                TXTMGSM.Text = GRIDGSM.Item(MMGSM.Index, GRIDGSM.CurrentRow.Index).Value.ToString

                TEMPPROCESSROW = GRIDGSM.CurrentRow.Index
                CMBGRADE.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDSELECTISSUE_Click(sender As Object, e As EventArgs) Handles CMDSELECTISSUE.Click
        Try
            EP.Clear()
            Dim OBJSO As New SelectIssue
            Dim DT As DataTable = OBJSO.DT
            OBJSO.ShowDialog()
            If DT.Rows.Count > 0 Then

                ''FETCH DATA FROM PRODUCTISSUE
                TXTISSUENO.Text = Val(DT.Rows(0).Item("ISSUENO"))
                DTISSUEDATE.Text = DT.Rows(0).Item("DATE")
                TXTJONO.Text = Val(DT.Rows(0).Item("JONO"))
                DTJODATE.Text = DT.Rows(0).Item("JODATE")
                TXTJOSRNO.Text = Val(DT.Rows(0).Item("JOSRNO"))
                TXTJOTYPE.Text = DT.Rows(0).Item("JOTYPE")
                TXTPROFORMANO.Text = Val(DT.Rows(0).Item("PROFORMANO"))
                TXTSONO.Text = Val(DT.Rows(0).Item("SONO"))
                DTSODATE.Text = DT.Rows(0).Item("SODATE")
                TXTSOTYPE.Text = DT.Rows(0).Item("SOTYPE")
                TXTFINALQUALITY.Text = DT.Rows(0).Item("FINALQUALITY")
                TXTMACHINENO.Text = DT.Rows(0).Item("MACHINE")
                TXTNAME.Text = DT.Rows(0).Item("NAME")


                For Each DTROW As DataRow In DT.Rows
                    GRIDPRODISSUE.Rows.Add(Val(DTROW("GRIDISSUESRNO")), DTROW("QUALITY"), DTROW("LOTNO"), DTROW("ROLLNO"), Val(DTROW("GSM")), DTROW("GSMDETAILS"), Val(DTROW("SIZE")), DTROW("MILLQTY"), DTROW("OURQTY"), DTROW("DIFF"), DTROW("UNIT"), DTROW("ISSUENO"), DTROW("GRIDSRNO"))
                Next
                GETMAXROLLNO()
            End If
            TOTAL()
            getsrno(GRIDPRODISSUE)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub GETMAXROLLNO()
        Try
            'Dim OBJCMN As New ClsCommon
            ''DONT ADD YEARID CLAUSE, WE WANT CONTINIOUS NO IRRESPECTIVE TO YEAR
            'Dim DT As DataTable = OBJCMN.Execute_Any_String("SELECT isnull(max(PRODUCTRECEIVED_SINGLERECD.RECD_ROLLNO),0) + 1 AS ROLLNO FROM  PRODUCTRECEIVED INNER JOIN PRODUCTRECEIVED_SINGLERECD ON PRODUCTRECEIVED.RECD_NO = PRODUCTRECEIVED_SINGLERECD.RECD_NO AND PRODUCTRECEIVED.RECD_YEARID = PRODUCTRECEIVED_SINGLERECD.RECD_YEARID INNER JOIN MACHINEMASTER ON PRODUCTRECEIVED.RECD_MACHINEID = MACHINEMASTER.MACHINE_ID WHERE MACHINEMASTER.MACHINE_NAME ='" & TXTMACHINENO.Text.Trim & "'", "", "")
            'If DT.Rows.Count > 0 Then TXTROLLNO.Text = Val(DT.Rows(0).Item("ROLLNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Dim IntResult As Integer
        Try

            If EDIT = True Then
                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                TEMPMSG = MsgBox("Delete Product Received ?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim alParaval As New ArrayList
                    alParaval.Add(TXTRECDNO.Text.Trim)
                    alParaval.Add(Userid)
                    alParaval.Add(CmpId)
                    alParaval.Add(YearId)

                    Dim ClsINCTAG As New ClsProdReceived()
                    ClsINCTAG.alParaval = alParaval
                    IntResult = ClsINCTAG.Delete()
                    MsgBox("Product Product Received Deleted")
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

    Private Sub GRIDPROCESS_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRIDGSM.CellDoubleClick
        Try
            EDITPROCESSROW()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTMGSM_Validated(sender As Object, e As EventArgs) Handles TXTMGSM.Validated
        Try
            FILLGRIDPROCESS()
            TOTAL()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRIDSINGLERECD()

        If GRIDSINGLEDOUBLECLICK = False Then
            GRIDRECD.Rows.Add(Val(TXTGRIDSINGLERECDSRNO.Text.Trim), TXTROLLNO.Text.Trim, TXTRLOTNO.Text.Trim, Format(Val(TXTRGSM.Text.Trim), "0.00"), TXTGSMDETAILS.Text.Trim, Val(TXTRSIZE.Text.Trim), TXTRECDWT.Text.Trim, CMBIUNIT.Text.Trim, TXTJOINT.Text.Trim, TXTNARRATION.Text.Trim, 0)
            getsrno(GRIDRECD)
        ElseIf GRIDSINGLEDOUBLECLICK = True Then
            GRIDRECD.Item(SGRIDSINGLERECDSRNO.Index, TEMPSINGLEROW).Value = Val(TXTGRIDSINGLERECDSRNO.Text.Trim)
            GRIDRECD.Item(SROLLNO.Index, TEMPSINGLEROW).Value = TXTROLLNO.Text.Trim
            GRIDRECD.Item(SLOTNO.Index, TEMPSINGLEROW).Value = TXTRLOTNO.Text.Trim
            GRIDRECD.Item(SGSM.Index, TEMPSINGLEROW).Value = Val(TXTRGSM.Text.Trim)
            GRIDRECD.Item(SGSMDETAILS.Index, TEMPSINGLEROW).Value = TXTGSMDETAILS.Text.Trim
            GRIDRECD.Item(SSIZE.Index, TEMPSINGLEROW).Value = Val(TXTRSIZE.Text.Trim)
            GRIDRECD.Item(SRECDWT.Index, TEMPSINGLEROW).Value = Val(TXTRECDWT.Text.Trim)
            GRIDRECD.Item(SIUNIT.Index, TEMPSINGLEROW).Value = CMBIUNIT.Text.Trim
            GRIDRECD.Item(SJOINT.Index, TEMPSINGLEROW).Value = Val(TXTJOINT.Text.Trim)
            GRIDRECD.Item(SNARRATION.Index, TEMPSINGLEROW).Value = TXTNARRATION.Text.Trim

            GRIDSINGLEDOUBLECLICK = False

        End If
        TOTAL()

        GRIDRECD.FirstDisplayedScrollingRowIndex = GRIDRECD.RowCount - 1

        TXTGRIDSINGLERECDSRNO.Text = GRIDRECD.RowCount + 1
        TXTROLLNO.Clear()
        TXTGSM.Clear()
        TXTGSMDETAILS.Clear()
        TXTSIZE.Clear()
        TXTRECDWT.Clear()
        CMBUNIT.Text = ""
        TXTJOINT.Clear()
        TXTNARRATION.Clear()

        'If GRIDRECD.RowCount > 0 Then TXTROLLNO.Text = Val(GRIDRECD.Rows(GRIDRECD.RowCount - 1).Cells(SROLLNO.Index).Value) + 1 Else GETMAXROLLNO()

        TXTROLLNO.Focus()
    End Sub

    Sub EDITSINGLEROW()
        Try
            If GRIDRECD.CurrentRow.Index >= 0 And GRIDRECD.Item(SGRIDSINGLERECDSRNO.Index, GRIDRECD.CurrentRow.Index).Value <> Nothing Then
                GRIDSINGLEDOUBLECLICK = True
                TXTGRIDSINGLERECDSRNO.Text = GRIDRECD.Item(SGRIDSINGLERECDSRNO.Index, GRIDRECD.CurrentRow.Index).Value.ToString
                TXTROLLNO.Text = GRIDRECD.Item(SROLLNO.Index, GRIDRECD.CurrentRow.Index).Value.ToString
                TXTRLOTNO.Text = GRIDRECD.Item(SLOTNO.Index, GRIDRECD.CurrentRow.Index).Value.ToString
                TXTRGSM.Text = GRIDRECD.Item(SGSM.Index, GRIDRECD.CurrentRow.Index).Value.ToString
                TXTGSMDETAILS.Text = GRIDRECD.Item(SGSMDETAILS.Index, GRIDRECD.CurrentRow.Index).Value.ToString
                TXTRSIZE.Text = GRIDRECD.Item(SSIZE.Index, GRIDRECD.CurrentRow.Index).Value.ToString
                TXTRECDWT.Text = GRIDRECD.Item(SRECDWT.Index, GRIDRECD.CurrentRow.Index).Value.ToString
                CMBIUNIT.Text = GRIDRECD.Item(SIUNIT.Index, GRIDRECD.CurrentRow.Index).Value.ToString
                TXTJOINT.Text = GRIDRECD.Item(SJOINT.Index, GRIDRECD.CurrentRow.Index).Value.ToString
                TXTNARRATION.Text = GRIDRECD.Item(SNARRATION.Index, GRIDRECD.CurrentRow.Index).Value.ToString

                TEMPSINGLEROW = GRIDRECD.CurrentRow.Index
                TXTROLLNO.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(sender As Object, e As EventArgs) Handles PrintToolStripButton.Click
        If EDIT = True Then PRINTREPORT(TEMPPRODRECDNO)
    End Sub

    Sub PRINTREPORT(ByVal PRODNO As Integer)
        Try
            If MsgBox("Wish to Print Product Recd?", MsgBoxStyle.YesNo) = vbNo Then Exit Sub
            Dim OBJPROD As New ProductionDesign
            OBJPROD.FRMSTRING = "PRODREC"
            OBJPROD.PRODNO = PRODNO
            OBJPROD.FORMULA = "{PRODUCTRECEIVED.RECD_NO} = " & PRODNO & " AND {PRODUCTRECEIVED.RECD_YEARID} = " & YearId
            OBJPROD.PARTYNAME = TXTNAME.Text.Trim
            OBJPROD.MdiParent = MDIMain
            OBJPROD.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTNARRATION_Validated(sender As Object, e As EventArgs) Handles TXTNARRATION.Validated
        If Val(TXTRGSM.Text.Trim) > 0 And Val(TXTRSIZE.Text.Trim) > 0 And Val(TXTRECDWT.Text.Trim) > 0 Then FILLGRIDSINGLERECD()
    End Sub

    Sub TOTAL()
        Try

            LBLRECDWT.Text = 0.0
            TXTTOTALRECDWT.Text = 0.0
            For Each ROW As DataGridViewRow In GRIDRECD.Rows
                If ROW.Cells(SGRIDSINGLERECDSRNO.Index).Value <> Nothing Then
                    LBLRECDWT.Text = Format(Val(LBLRECDWT.Text) + Val(ROW.Cells(SRECDWT.Index).EditedFormattedValue), "0.00")
                End If
            Next
            TXTTOTALRECDWT.Text = Format(Val(LBLRECDWT.Text.Trim), "0.00")


            LBLTOTALWASTAGEWT.Text = 0.0
            TXTTOTALWASWT.Text = 0.0
            For Each ROW As DataGridViewRow In GRIDWASTAGE.Rows
                If ROW.Cells(GWASTAGESRNO.Index).Value <> Nothing Then
                    LBLTOTALWASTAGEWT.Text = Format(Val(LBLTOTALWASTAGEWT.Text) + Val(ROW.Cells(GWASTAGEWT.Index).EditedFormattedValue), "0.00")
                End If
            Next
            TXTTOTALWASWT.Text = Format(Val(LBLTOTALWASTAGEWT.Text.Trim), "0.00")


            LBLTOTALGSM.Text = 0.0
            For Each ROW As DataGridViewRow In GRIDGSM.Rows
                If ROW.Cells(MGRIDPROCESSSRNO.Index).Value <> Nothing Then
                    LBLTOTALGSM.Text = Format(Val(LBLTOTALGSM.Text) + Val(ROW.Cells(MMGSM.Index).EditedFormattedValue), "0.00")
                End If
            Next


            LBLTOTALISSUEDIFF.Text = 0.0
            TXTTOTALISSWT.Text = 0.0
            For Each ROW As DataGridViewRow In GRIDPRODISSUE.Rows
                If ROW.Cells(GRECDSRNO.Index).Value <> Nothing Then
                    LBLTOTALISSUEDIFF.Text = Format(Val(LBLTOTALISSUEDIFF.Text) + Val(ROW.Cells(GDIFF.Index).EditedFormattedValue), "0.00")
                    TXTTOTALISSWT.Text = Format(Val(TXTTOTALISSWT.Text) + Val(ROW.Cells(GOURQTY.Index).EditedFormattedValue), "0.00")
                End If
            Next


            TXTTOTALBALWT.Text = Format(Val(TXTTOTALISSWT.Text.Trim) - Val(TXTTOTALRECDWT.Text.Trim), "0.00")
            TXTWASTAGEPERCENTAGE.Text = Format(Val(TXTTOTALWASWT.Text.Trim) / Val(TXTTOTALISSWT.Text.Trim) * 100, "0.00")
            TXTTOTALFINALBALWT.Text = Format(Val(TXTTOTALBALWT.Text.Trim) - Val(TXTTOTALWASWT.Text.Trim), "0.00")


            REELCOUNT()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub REELCOUNT()
        Try
            LBLTOTALISSUEROLLNO.Text = 0
            LBLTOTALROLLNO.Text = 0

            Dim dic As New Dictionary(Of String, Integer)()
            Dim cellValue As String
            For i = 0 To GRIDRECD.Rows.Count - 1
                If Not GRIDRECD.Rows(i).IsNewRow Then
                    cellValue = GRIDRECD(SROLLNO.Index, i).EditedFormattedValue.ToString()
                    If cellValue <> "" Then
                        If Not dic.ContainsKey(cellValue) Then
                            dic.Add(cellValue, 1)
                        Else
                            dic(cellValue) += 1
                        End If
                    End If
                End If
            Next
            LBLTOTALROLLNO.Text = Val(dic.Count)
            cellValue = ""
            dic.Clear()

            For i = 0 To GRIDPRODISSUE.Rows.Count - 1
                If Not GRIDPRODISSUE.Rows(i).IsNewRow Then
                    cellValue = GRIDPRODISSUE(GREELROLLNO.Index, i).EditedFormattedValue.ToString()
                    If cellValue <> "" Then
                        If Not dic.ContainsKey(cellValue) Then
                            dic.Add(cellValue, 1)
                        Else
                            dic(cellValue) += 1
                        End If
                    End If
                End If
            Next
            LBLTOTALISSUEROLLNO.Text = Val(dic.Count)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub tstxtbillno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tstxtbillno.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub TXTRECDWT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTRECDWT.KeyPress, TXTWT.KeyPress, TXTMGSM.KeyPress, TXTRSIZE.KeyPress, TXTRGSM.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub GRIDSINGLERECD_KeyDown(sender As Object, e As KeyEventArgs) Handles GRIDRECD.KeyDown
        Try
            If e.KeyCode = Keys.Delete Then
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                GRIDRECD.Rows.RemoveAt(GRIDRECD.CurrentRow.Index)
                TOTAL()
                getsrno(GRIDRECD)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDPROCESS_KeyDown(sender As Object, e As KeyEventArgs) Handles GRIDGSM.KeyDown
        Try
            If e.KeyCode = Keys.Delete Then
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                GRIDGSM.Rows.RemoveAt(GRIDGSM.CurrentRow.Index)
                TOTAL()
                getsrno(GRIDGSM)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ProdReceived_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                If ERRORVALID() = True Then
                    Dim tempmsg As Integer = MessageBox.Show("Save Changes?", "", MessageBoxButtons.YesNo)
                    If tempmsg = vbYes Then cmdok_Click(sender, e)
                End If
                Me.Close()

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
                GRIDPRODISSUE.Focus()
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
                GRIDPRODISSUE.RowCount = 0
                TEMPPRODRECDNO = Val(tstxtbillno.Text)
                If TEMPPRODRECDNO > 0 Then
                    EDIT = True
                    ProdReceived_Load(sender, e)
                Else
                    clear()
                    EDIT = False
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GRIDSINGLERECD_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRIDRECD.CellDoubleClick
        EDITSINGLEROW()
    End Sub


End Class