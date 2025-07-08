Imports System.ComponentModel
Imports BL

Public Class ProdIssue

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE, GRIDDOUBLECLICK, GRIDWASTAGEDOUBLECLICK As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public EDIT As Boolean          'used for editing
    Public TEMPPRODISSUENO As String
    Public TEMPMSG As Integer
    Dim TEMPROW As Integer
    Dim TEMPWASTAGEROW As Integer

    Private Sub cmdclear_Click(sender As Object, e As EventArgs) Handles cmdclear.Click
        clear()
        EDIT = False
        DTISSUEDATE.Focus()
    End Sub

    Private Sub cmdexit_Click(sender As Object, e As EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub clear()

        TXTISSUENO.ReadOnly = True
        CMBGODOWN.Text = ""
        TXTPROFORMANO.Clear()
        CMBMACHINENO.Text = ""
        TXTJONO.Clear()
        TXTPROFORMANO.Clear()
        TXTFINALQUALITY.Clear()
        TXTJONO.Clear()
        GRIDPRODISSUE.RowCount = 0
        GRIDWASTAGE.RowCount = 0
        TXTJOSRNO.Clear()
        DTJODATE.Text = Now.Date
        TXTSONO.Text = ""
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
        TXTMILLQTY.Clear()
        TXTOURQTY.Clear()
        TXTDIFF.Clear()
        CMBUNIT.Text = ""

        TXTGRIDWASTAGESRNO.Clear()
        TXTGRIDWASTAGESRNO.Text = 1
        CMBWASTAGETYPE.Text = ""
        TXTWT.Clear()
        getmax_ISSUENO()
        tstxtbillno.Clear()
        TXTREMARK.Clear()
        TXTSOTYPE.Clear()
        TXTJOTYPE.Clear()
        TXTPEGSM.Clear()

        EP.Clear()
        LBLTOTALREELNO.Text = 0.0
        LBLTOTALDIFF.Text = 0
        LBLTOTALWT.Text = 0
        LBLTOTALMILLQTY.Text = 0
        LBLTOTALOURQTY.Text = 0

        CMDSELECTSTOCK.Enabled = True
        CMDSELECTJO.Enabled = True
        CMBMACHINENO.Enabled = True
        TXTPARTYNAME.Clear()
        GRIDWASTAGEDOUBLECLICK = False
        GRIDDOUBLECLICK = False
        lbllocked.Visible = False
        PBlock.Visible = False

    End Sub

    Sub getmax_ISSUENO()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(ISS_NO),0) + 1 ", "PRODUCTISSUE", "  AND ISS_cmpid=" & CmpId & " and ISS_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTISSUENO.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Private Sub GRIDPRODISSUE_KeyDown(sender As Object, e As KeyEventArgs)
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

    Sub FILLCMB()
        Try
            If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, EDIT)
            If CMBMACHINENO.Text.Trim = "" Then FILLMACHINE(CMBMACHINENO)
            If CMBQUALITY.Text.Trim = "" Then FILLITEMNAME(CMBQUALITY, " AND ITEM_FRMSTRING = 'MERCHANT'")
            If CMBUNIT.Text.Trim = "" Then FILLUNIT(CMBUNIT)
            If CMBWASTAGETYPE.Text.Trim = "" Then FILLWASTEITEM(CMBWASTAGETYPE, "AND ITEM_FRMSTRING = 'MERCHANT'AND ITEMMASTER.ITEM_MATERIALTYPE = 'WASTAGE' ")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ProdIssue_Load(sender As Object, e As EventArgs) Handles Me.Load
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
                Dim OBJCLSINCENTIVE As New ClsProdIssue
                Dim dttable As New DataTable

                dttable = OBJCLSINCENTIVE.selectISSUE(TEMPPRODISSUENO, CmpId, YearId)
                If dttable.Rows.Count > 0 Then

                    For Each dr As DataRow In dttable.Rows

                        TXTISSUENO.Text = TEMPPRODISSUENO
                        TXTISSUENO.ReadOnly = True
                        DTISSUEDATE.Text = Format(Convert.ToDateTime(dr("ISSUEDATE")), "dd/MM/yyyy")
                        DTJODATE.Text = Format(Convert.ToDateTime(dr("JODATE")), "dd/MM/yyyy")
                        TXTJOTYPE.Text = dr("JOTYPE")
                        DTSODATE.Text = Format(Convert.ToDateTime(dr("SODATE")), "dd/MM/yyyy")
                        TXTSOTYPE.Text = dr("SOTYPE")
                        CMBGODOWN.Text = Convert.ToString(dr("GODOWN"))
                        CMBMACHINENO.Text = Convert.ToString(dr("MACHINE"))
                        TXTPROFORMANO.Text = dr("PROFORMANO")
                        TXTFINALQUALITY.Text = dr("FINALQUALITY")
                        TXTJONO.Text = dr("JONO")
                        TXTJOSRNO.Text = dr("JOSRNO")
                        TXTSONO.Text = dr("SONO")
                        TXTREMARK.Text = dr("REMARKS")
                        LBLTOTALREELNO.Text = dr("TOTALRELL")
                        LBLTOTALDIFF.Text = dr("TOTALDIFF")
                        LBLTOTALWT.Text = dr("TOTALWT")
                        LBLTOTALMILLQTY.Text = dr("TOTALMILLQTY")
                        LBLTOTALOURQTY.Text = dr("TOTALOURQTY")
                        TXTPARTYNAME.Text = dr("PARTYNAME")
                        TXTPEGSM.Text = dr("PEGSM")



                        GRIDPRODISSUE.Rows.Add(dr("GRIDISSUESRNO").ToString, dr("QUALITY").ToString, dr("LOTNO").ToString, dr("ROLLNO").ToString, dr("GSM").ToString, dr("GSMDETAILS").ToString, dr("SIZE").ToString, dr("MILLQTY").ToString, dr("OURQTY").ToString, dr("DIFF").ToString, dr("UNIT").ToString, dr("BARCODE").ToString, dr("RECDWT").ToString, Val(dr("FROMNO")), Val(dr("FROMSRNO")), dr("FROMTYPE").ToString, dr("DONE"), dr("CLOSED"))
                        If Convert.ToBoolean(dr("CLOSED")) = True Or Convert.ToBoolean(dr("DONE")) = True Or Val(dr("RECDWT")) > 0 Then
                            GRIDPRODISSUE.Rows(GRIDPRODISSUE.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If

                    Next
                    'WASTAGE Grid
                    Dim OBJPRI As New ClsCommon
                    dttable = OBJPRI.SEARCH("ISNULL(PRODUCTISSUE_WASTAGE.ISS_GRIDWASTAGESRNO, 0) AS GRIDWASTAGESRNO, ISNULL(ITEMMASTER.item_name, '') AS WASTAGETYPE, ISNULL(PRODUCTISSUE_WASTAGE.ISS_WT, '') AS WT ", "", " PRODUCTISSUE_WASTAGE LEFT OUTER JOIN ITEMMASTER ON PRODUCTISSUE_WASTAGE.ISS_WASTAGETYPEID = ITEMMASTER.item_id", " AND ISS_NO = " & TEMPPRODISSUENO & " AND ISS_CMPID = " & CmpId & " AND ISS_YEARID = " & YearId)
                    If dttable.Rows.Count > 0 Then
                        For Each dr As DataRow In dttable.Rows
                            GRIDWASTAGE.Rows.Add(dr("GRIDWASTAGESRNO").ToString, dr("WASTAGETYPE").ToString, dr("WT").ToString)

                        Next
                    End If


                    GRIDPRODISSUE.FirstDisplayedScrollingRowIndex = GRIDPRODISSUE.RowCount - 1
                    TOTAL()
                    CMDSELECTJO.Enabled = False
                    ' CMDSELECTSTOCK.Enabled = False
                    CMBWASTAGETYPE.Focus()
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
            If TXTISSUENO.ReadOnly = False Then
                alParaval.Add(Val(TXTISSUENO.Text.Trim))
            Else
                alParaval.Add(0)
            End If

            alParaval.Add(Format(Convert.ToDateTime(DTISSUEDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(Format(Convert.ToDateTime(DTJODATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(TXTJOTYPE.Text.Trim)
            alParaval.Add(Format(Convert.ToDateTime(DTSODATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(TXTSOTYPE.Text.Trim)
            alParaval.Add(CMBGODOWN.Text.Trim)
            alParaval.Add(CMBMACHINENO.Text.Trim)
            alParaval.Add(TXTPROFORMANO.Text.Trim)
            alParaval.Add(TXTFINALQUALITY.Text.Trim)
            alParaval.Add(TXTJONO.Text.Trim)
            alParaval.Add(TXTJOSRNO.Text.Trim)
            alParaval.Add(TXTSONO.Text.Trim)
            alParaval.Add(TXTREMARK.Text.Trim)
            alParaval.Add(Val(LBLTOTALREELNO.Text.Trim))
            alParaval.Add(Val(LBLTOTALDIFF.Text.Trim))
            alParaval.Add(Val(LBLTOTALWT.Text.Trim))
            alParaval.Add(Val(LBLTOTALMILLQTY.Text.Trim))
            alParaval.Add(Val(LBLTOTALOURQTY.Text.Trim))
            alParaval.Add(TXTPARTYNAME.Text.Trim)
            alParaval.Add(TXTPEGSM.Text.Trim)

            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)

            Dim GRIDPRISSUESRNO As String = ""
            Dim QUALITY As String = ""
            Dim LOTNO As String = ""
            Dim ROLLNO As String = ""
            Dim GSM As String = ""
            Dim GSMDETAILS As String = ""
            Dim SIZE As String = ""
            Dim MILLQTY As String = ""
            Dim OURQTY As String = ""
            Dim DIFF As String = ""
            Dim UNIT As String = ""
            Dim BARCODE As String = ""
            Dim RECDWT As String = ""
            Dim FROMNO As String = ""
            Dim FROMSRNO As String = ""
            Dim FROMTYPE As String = ""
            Dim DONE As String = ""
            Dim CLOSED As String = ""


            For Each row As Windows.Forms.DataGridViewRow In GRIDPRODISSUE.Rows
                If row.Cells(0).Value <> Nothing Then
                    If GRIDPRISSUESRNO = "" Then
                        GRIDPRISSUESRNO = Val(row.Cells(GISSUESRNO.Index).Value)
                        QUALITY = row.Cells(GQUALITY.Index).Value.ToString
                        LOTNO = row.Cells(GLOTNO.Index).Value.ToString
                        ROLLNO = row.Cells(GREELROLLNO.Index).Value.ToString
                        GSM = row.Cells(GGSM.Index).Value.ToString
                        GSMDETAILS = row.Cells(GGSMDETAILS.Index).Value.ToString
                        SIZE = row.Cells(GSIZE.Index).Value.ToString
                        MILLQTY = row.Cells(GMILLQTY.Index).Value.ToString
                        OURQTY = row.Cells(GOURQTY.Index).Value.ToString
                        DIFF = row.Cells(GDIFF.Index).Value.ToString
                        UNIT = row.Cells(GUNIT.Index).Value.ToString
                        BARCODE = row.Cells(GBARCODE.Index).Value
                        RECDWT = Val(row.Cells(GRECDWT.Index).Value)
                        FROMNO = Val(row.Cells(GFROMNO.Index).Value)
                        FROMSRNO = Val(row.Cells(GFROMSRNO.Index).Value)
                        FROMTYPE = row.Cells(GFROMTYPE.Index).Value.ToString
                        If row.Cells(GDONE.Index).Value = True Then
                            DONE = 1
                        Else
                            DONE = 0
                        End If
                        If Convert.ToBoolean(row.Cells(GCLOSED.Index).Value) = True Then CLOSED = 1 Else CLOSED = 0


                    Else

                        GRIDPRISSUESRNO = GRIDPRISSUESRNO & "|" & Val(row.Cells(GISSUESRNO.Index).Value)
                        QUALITY = QUALITY & "|" & row.Cells(GQUALITY.Index).Value.ToString
                        LOTNO = LOTNO & "|" & row.Cells(GLOTNO.Index).Value.ToString
                        ROLLNO = ROLLNO & "|" & row.Cells(GREELROLLNO.Index).Value.ToString
                        GSM = GSM & "|" & row.Cells(GGSM.Index).Value.ToString
                        GSMDETAILS = GSMDETAILS & "|" & row.Cells(GGSMDETAILS.Index).Value.ToString
                        SIZE = SIZE & "|" & row.Cells(GSIZE.Index).Value.ToString
                        MILLQTY = MILLQTY & "|" & row.Cells(GMILLQTY.Index).Value.ToString
                        OURQTY = OURQTY & "|" & row.Cells(GOURQTY.Index).Value.ToString
                        DIFF = DIFF & "|" & row.Cells(GDIFF.Index).Value.ToString
                        UNIT = UNIT & "|" & row.Cells(GUNIT.Index).Value.ToString
                        BARCODE = BARCODE & "|" & row.Cells(GBARCODE.Index).Value

                        RECDWT = RECDWT & "|" & Val(row.Cells(GRECDWT.Index).Value)
                        FROMNO = FROMNO & "|" & Val(row.Cells(GFROMNO.Index).Value)
                        FROMSRNO = FROMSRNO & "|" & Val(row.Cells(GFROMSRNO.Index).Value)
                        FROMTYPE = FROMTYPE & "|" & row.Cells(GFROMTYPE.Index).Value.ToString
                        If row.Cells(GDONE.Index).Value = True Then
                            DONE = DONE & "|" & "1"
                        Else
                            DONE = DONE & "|" & "0"
                        End If
                        If Convert.ToBoolean(row.Cells(GCLOSED.Index).Value) = True Then CLOSED = CLOSED & "|" & "1" Else CLOSED = CLOSED & "|" & "0"

                    End If
                End If
            Next

            alParaval.Add(GRIDPRISSUESRNO)
            alParaval.Add(QUALITY)
            alParaval.Add(LOTNO)
            alParaval.Add(ROLLNO)
            alParaval.Add(GSM)
            alParaval.Add(GSMDETAILS)
            alParaval.Add(SIZE)
            alParaval.Add(MILLQTY)
            alParaval.Add(OURQTY)
            alParaval.Add(DIFF)
            alParaval.Add(UNIT)
            alParaval.Add(BARCODE)
            alParaval.Add(RECDWT)
            alParaval.Add(FROMNO)
            alParaval.Add(FROMSRNO)
            alParaval.Add(FROMTYPE)
            alParaval.Add(DONE)
            alParaval.Add(CLOSED)


            '' FOR WASTAGE GRID''
            Dim GRIDWASTAGESRNO As String = ""
            Dim WASTAGETYPE As String = ""
            Dim WT As String = ""


            For Each row As Windows.Forms.DataGridViewRow In GRIDWASTAGE.Rows
                If row.Cells(0).Value <> Nothing Then
                    If GRIDWASTAGESRNO = "" Then
                        GRIDWASTAGESRNO = Val(row.Cells(GWASTAGESRNO.Index).Value)
                        WASTAGETYPE = row.Cells(GWASTAGETYPE.Index).Value.ToString
                        WT = row.Cells(GWT.Index).Value.ToString

                    Else

                        GRIDWASTAGESRNO = GRIDWASTAGESRNO & "|" & Val(row.Cells(GWASTAGESRNO.Index).Value)
                        WASTAGETYPE = WASTAGETYPE & "|" & row.Cells(GWASTAGETYPE.Index).Value.ToString
                        WT = WT & "|" & row.Cells(GWT.Index).Value.ToString


                    End If
                End If
            Next

            alParaval.Add(GRIDWASTAGESRNO)
            alParaval.Add(WASTAGETYPE)
            alParaval.Add(WT)




            Dim objclsPurord As New ClsProdIssue()
            objclsPurord.alParaval = alParaval

            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim DT As DataTable = objclsPurord.SAVE()
                MessageBox.Show("Details Added")
                TXTISSUENO.Text = DT.Rows(0).Item(0)
            Else


                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPPRODISSUENO)
                IntResult = objclsPurord.UPDATE()
                MessageBox.Show("Details Updated")
                EDIT = False
            End If

            PRINTREPORT(Val(TXTISSUENO.Text.Trim))
            clear()
            CMBQUALITY.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Sub PRINTREPORT(ByVal PRODNO As Integer)
        Try
            If MsgBox("Wish to Print Product Issue?", MsgBoxStyle.YesNo) = vbNo Then Exit Sub
            Dim OBJPROD As New ProductionDesign
            OBJPROD.FRMSTRING = "PRODISS"
            OBJPROD.PRODNO = PRODNO
            OBJPROD.FORMULA = "{PRODUCTISSUE.ISS_NO} = " & PRODNO & " AND {PRODUCTISSUE.ISS_YEARID} = " & YearId
            OBJPROD.PARTYNAME = TXTPARTYNAME.Text.Trim
            OBJPROD.MdiParent = MDIMain
            OBJPROD.Show()
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

        If DTISSUEDATE.Text = "__/__/____" Then
            EP.SetError(DTISSUEDATE, " Please Enter Proper Date")
            bln = False
        Else
            If Not datecheck(DTISSUEDATE.Text) Then
                EP.SetError(DTISSUEDATE, "Date not in Accounting Year")
                bln = False
            End If
        End If

        If Val(TXTJONO.Text.Trim) = 0 Then
            EP.SetError(TXTJONO, " Please Select Job Order")
            bln = False
        End If

        If CMBMACHINENO.Text.Trim.Length = 0 Then
            EP.SetError(CMBMACHINENO, " Please Fill Machine No  ")
            bln = False
        End If

        If GRIDPRODISSUE.RowCount = 0 Then
            EP.SetError(GRIDPRODISSUE, " Please Enter Proper Details ")
            bln = False
        End If

        If lbllocked.Visible = True Then
            EP.SetError(lbllocked, "Entry Locked ")
            bln = False
        End If



        For Each ROW As DataGridViewRow In GRIDPRODISSUE.Rows
            If ROW.Cells(GOURQTY.Index).Value = "0" Then
                EP.SetError(GRIDPRODISSUE, "The Value Of Our Qty Sholud be Greater 0")
                bln = False
            End If
        Next


        'WE WILL HAVE TO SKIP THIS COZ WE WILL ISSSUE THE ENTRIES AND SAVE IT.... THAT TIME OURWT WILL BE 0
        'For Each row As DataGridViewRow In GRIDPRODISSUE.Rows
        '    If Val(row.Cells(GOURQTY.Index).Value) = 0 Then
        '        EP.SetError(LBLTOTALOURQTY, "Our Qty Cannot be 0")
        '        bln = False
        '    End If
        'Next

        'WE WILL HAVE TO SKIP THIS COZ WE WILL ISSSUE THE ENTRIES AND SAVE IT.... THAT TIME EVERYTHING WILL BE SHOWN IN DIFF
        'If Val(LBLTOTALDIFF.Text) <> Val(LBLTOTALWT.Text) Then
        '    EP.SetError(LBLTOTALWT, "Diff And Total Wastage Value Does Not Match ")
        '    bln = False
        'End If


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
                    MsgBox("Issue Locked", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                TEMPMSG = MsgBox("Delete Product Issue?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim alParaval As New ArrayList
                    alParaval.Add(TXTISSUENO.Text.Trim)
                    alParaval.Add(YearId)

                    Dim ClsINCTAG As New ClsProdIssue()
                    ClsINCTAG.alParaval = alParaval
                    IntResult = ClsINCTAG.Delete()
                    MsgBox("Product Issue Deleted")
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
            TEMPPRODISSUENO = Val(TXTISSUENO.Text) - 1
            If TEMPPRODISSUENO > 0 Then
                EDIT = True
                ProdIssue_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If

            If GRIDPRODISSUE.RowCount = 0 And TEMPPRODISSUENO > 1 Then
                TXTISSUENO.Text = TEMPPRODISSUENO
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
            TEMPPRODISSUENO = Val(TXTISSUENO.Text) + 1
            getmax_ISSUENO()
            Dim MAXNO As Integer = TXTISSUENO.Text.Trim
            clear()
            If Val(TXTISSUENO.Text) - 1 >= TEMPPRODISSUENO Then
                EDIT = True
                ProdIssue_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDPRODISSUE.RowCount = 0 And TEMPPRODISSUENO < MAXNO Then
                TXTISSUENO.Text = TEMPPRODISSUENO
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

            Dim objINVDTLS As New ProdIssueDetails
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
            If EDIT = True Then PRINTREPORT(TEMPPRODISSUENO)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub



    Sub Fillgrid()
        Try
            If GRIDDOUBLECLICK = False Then
                GRIDPRODISSUE.Rows.Add(Val(TXTISSUENO.Text.Trim), CMBQUALITY.Text.Trim, TXTLOTNO.Text.Trim, TXTREELROLLNO.Text.Trim, TXTGSM.Text.Trim, TXTGSMDETAILS.Text.Trim, TXTSIZE.Text.Trim, TXTMILLQTY.Text.Trim, TXTOURQTY.Text.Trim, TXTDIFF.Text.Trim, CMBUNIT.Text.Trim, TXTBARCODE.Text.Trim)
                getsrno(GRIDPRODISSUE)
            ElseIf GRIDDOUBLECLICK = True Then
                GRIDPRODISSUE.Item(GISSUESRNO.Index, TEMPROW).Value = Val(TXTGRIDPRISSUSRNO.Text.Trim)
                GRIDPRODISSUE.Item(GQUALITY.Index, TEMPROW).Value = CMBQUALITY.Text.Trim
                GRIDPRODISSUE.Item(GLOTNO.Index, TEMPROW).Value = (TXTLOTNO.Text.Trim)
                GRIDPRODISSUE.Item(GREELROLLNO.Index, TEMPROW).Value = (TXTREELROLLNO.Text.Trim)
                GRIDPRODISSUE.Item(GGSM.Index, TEMPROW).Value = (TXTGSM.Text.Trim)
                GRIDPRODISSUE.Item(GGSMDETAILS.Index, TEMPROW).Value = (TXTGSMDETAILS.Text.Trim)
                GRIDPRODISSUE.Item(GSIZE.Index, TEMPROW).Value = (TXTSIZE.Text.Trim)
                GRIDPRODISSUE.Item(GMILLQTY.Index, TEMPROW).Value = (TXTMILLQTY.Text.Trim)
                GRIDPRODISSUE.Item(GOURQTY.Index, TEMPROW).Value = (TXTOURQTY.Text.Trim)
                GRIDPRODISSUE.Item(GDIFF.Index, TEMPROW).Value = (TXTDIFF.Text.Trim)
                GRIDPRODISSUE.Item(GUNIT.Index, TEMPROW).Value = (CMBUNIT.Text.Trim)
                GRIDPRODISSUE.Item(GBARCODE.Index, TEMPROW).Value = (TXTBARCODE.Text.Trim)



                GRIDDOUBLECLICK = False

            End If
            TOTAL()


            GRIDPRODISSUE.FirstDisplayedScrollingRowIndex = GRIDPRODISSUE.RowCount - 1

            TXTGRIDPRISSUSRNO.Text = GRIDPRODISSUE.RowCount + 1
            CMBQUALITY.Text = ""
            TXTLOTNO.Clear()
            TXTREELROLLNO.Clear()
            TXTGSM.Clear()
            TXTGSMDETAILS.Clear()
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
            If GRIDPRODISSUE.CurrentRow.Index >= 0 And GRIDPRODISSUE.Item(GISSUESRNO.Index, GRIDPRODISSUE.CurrentRow.Index).Value <> Nothing Then
                GRIDDOUBLECLICK = True
                TXTGRIDPRISSUSRNO.Text = GRIDPRODISSUE.Item(GISSUESRNO.Index, GRIDPRODISSUE.CurrentRow.Index).Value.ToString
                CMBQUALITY.Text = GRIDPRODISSUE.Item(GQUALITY.Index, GRIDPRODISSUE.CurrentRow.Index).Value.ToString
                TXTLOTNO.Text = GRIDPRODISSUE.Item(GLOTNO.Index, GRIDPRODISSUE.CurrentRow.Index).Value.ToString
                TXTREELROLLNO.Text = GRIDPRODISSUE.Item(GREELROLLNO.Index, GRIDPRODISSUE.CurrentRow.Index).Value.ToString
                TXTGSM.Text = GRIDPRODISSUE.Item(GGSM.Index, GRIDPRODISSUE.CurrentRow.Index).Value.ToString
                TXTGSMDETAILS.Text = GRIDPRODISSUE.Item(GGSMDETAILS.Index, GRIDPRODISSUE.CurrentRow.Index).Value.ToString
                TXTSIZE.Text = GRIDPRODISSUE.Item(GSIZE.Index, GRIDPRODISSUE.CurrentRow.Index).Value.ToString
                TXTMILLQTY.Text = GRIDPRODISSUE.Item(GMILLQTY.Index, GRIDPRODISSUE.CurrentRow.Index).Value.ToString
                TXTOURQTY.Text = GRIDPRODISSUE.Item(GOURQTY.Index, GRIDPRODISSUE.CurrentRow.Index).Value.ToString
                TXTDIFF.Text = GRIDPRODISSUE.Item(GDIFF.Index, GRIDPRODISSUE.CurrentRow.Index).Value.ToString
                CMBUNIT.Text = GRIDPRODISSUE.Item(GUNIT.Index, GRIDPRODISSUE.CurrentRow.Index).Value.ToString
                TXTBARCODE.Text = GRIDPRODISSUE.Item(GBARCODE.Index, GRIDPRODISSUE.CurrentRow.Index).Value.ToString



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

    'Private Sub GRIDPRODISSUE_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRIDPRODISSUE.CellDoubleClick
    '    Try
    '        EDITROW()
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub


    Private Sub CMBUNIT_Validated(sender As Object, e As EventArgs)
        Try
            If CMBUNIT.Text.Trim <> "" Then Fillgrid()

        Catch ex As Exception
            Throw ex
        End Try
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


    Private Sub TXTSIZE_KeyPress(sender As Object, e As KeyPressEventArgs)
        numkeypress(e, sender, Me)
    End Sub
    Private Sub TXTGSM_KeyPress(sender As Object, e As KeyPressEventArgs)
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub CMBQUALITY_Validating(sender As Object, e As CancelEventArgs)
        Try
            If CMBQUALITY.Text.Trim <> "" Then ITEMVALIDATE(CMBQUALITY, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'", "MERCHANT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBQUALITY_Enter(sender As Object, e As EventArgs)
        Try
            If CMBQUALITY.Text.Trim = "" Then FILLITEMNAME(CMBQUALITY, EDIT)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBUNIT_Validating(sender As Object, e As CancelEventArgs)
        Try
            If CMBUNIT.Text.Trim <> "" Then unitvalidate(CMBUNIT, e, Me)
            TOTAL()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBUNIT_Enter(sender As Object, e As EventArgs)
        Try
            If CMBUNIT.Text.Trim <> "" Then FILLUNIT(CMBUNIT)

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
            GRIDWASTAGE.Item(GWT.Index, TEMPWASTAGEROW).Value = (TXTWT.Text.Trim)

            GRIDWASTAGEDOUBLECLICK = False
        End If
        TOTAL()

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
                TXTWT.Text = GRIDWASTAGE.Item(GWT.Index, GRIDWASTAGE.CurrentRow.Index).Value.ToString

                TEMPWASTAGEROW = GRIDWASTAGE.CurrentRow.Index
                CMBWASTAGETYPE.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub CMBSELECTJO_Click(sender As Object, e As EventArgs) Handles CMDSELECTJO.Click
        Try
            Dim OBJSO As New SelectJO
            OBJSO.ShowDialog()
            Dim DT As DataTable = OBJSO.DT
            If DT.Rows.Count > 0 Then

                ''FETCH DATA FROM joborder
                TXTJONO.Text = Val(DT.Rows(0).Item("JONO"))
                DTJODATE.Text = DT.Rows(0).Item("JODATE")
                TXTJOSRNO.Text = Val(DT.Rows(0).Item("JOSRNO"))
                TXTJOTYPE.Text = DT.Rows(0).Item("JOTYPE")
                TXTPROFORMANO.Text = Val(DT.Rows(0).Item("PROFORMANO"))
                TXTSONO.Text = Val(DT.Rows(0).Item("SONO"))
                DTSODATE.Text = DT.Rows(0).Item("SODATE")
                TXTSOTYPE.Text = DT.Rows(0).Item("SOTYPE")
                TXTFINALQUALITY.Text = DT.Rows(0).Item("QUALITY")
                TXTPARTYNAME.Text = DT.Rows(0).Item("PARTYNAME")
                TXTPEGSM.Text = DT.Rows(0).Item("PEGSM")

                CMDSELECTJO.Enabled = False
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
                OBJSELECTPO.FRMSTRING = "PRODISSUE"
                OBJSELECTPO.GODOWN = CMBGODOWN.Text.Trim
                Dim DTPO As DataTable = OBJSELECTPO.DT
                OBJSELECTPO.ShowDialog()

                If DTPO.Rows.Count > 0 Then
                    For Each DTROW As DataRow In DTPO.Rows
                        GRIDPRODISSUE.Rows.Add(0, DTROW("ITEMNAME"), DTROW("LOTNO"), DTROW("REELNO"), Val(DTROW("GSM")), DTROW("GSMDETAILS"), Val(DTROW("SIZE")), Val(DTROW("QTY")), 0, 0, DTROW("UNIT"), DTROW("BARCODE"), 0, DTROW("FROMNO"), DTROW("FROMSRNO"), DTROW("FROMTYPE"), 0, 0)
                        If DTROW("ITEMNAME") = "LDPE" Then GRIDPRODISSUE.Rows(GRIDPRODISSUE.RowCount - 1).Cells(GMILLQTY.Index).ReadOnly = False
                    Next

                    getsrno(GRIDPRODISSUE)
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




    Private Sub ProdIssue_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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
                TEMPPRODISSUENO = Val(tstxtbillno.Text)
                If TEMPPRODISSUENO > 0 Then
                    EDIT = True
                    ProdIssue_Load(sender, e)
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
            LBLTOTALOURQTY.Text = 0.0




            For Each ROW As DataGridViewRow In GRIDPRODISSUE.Rows
                If ROW.Cells(GISSUESRNO.Index).Value <> Nothing Then
                    ROW.Cells(GDIFF.Index).Value = Format(Val(ROW.Cells(GMILLQTY.Index).EditedFormattedValue) - Val(ROW.Cells(GOURQTY.Index).EditedFormattedValue), "0.00")
                    LBLTOTALDIFF.Text = Val(LBLTOTALDIFF.Text) + Val(ROW.Cells(GDIFF.Index).EditedFormattedValue)
                    LBLTOTALMILLQTY.Text = Val(LBLTOTALMILLQTY.Text) + Val(ROW.Cells(GMILLQTY.Index).EditedFormattedValue)
                    LBLTOTALOURQTY.Text = Val(LBLTOTALOURQTY.Text) + Val(ROW.Cells(GOURQTY.Index).EditedFormattedValue)

                End If
            Next

            LBLTOTALWT.Text = 0.0

            For Each ROW As DataGridViewRow In GRIDWASTAGE.Rows
                If ROW.Cells(GWASTAGESRNO.Index).Value <> Nothing Then
                    LBLTOTALWT.Text = Val(LBLTOTALWT.Text) + Val(ROW.Cells(GWT.Index).EditedFormattedValue)

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
            LBLTOTALREELNO.Text = Val(dic.Count)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDCOPYWT_Click(sender As Object, e As EventArgs) Handles CMDCOPYWT.Click
        Try
            If MsgBox("Wish to Copy Wt in Our Wt Column?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            For Each ROW As DataGridViewRow In GRIDPRODISSUE.Rows
                ROW.Cells(GOURQTY.Index).Value = ROW.Cells(GMILLQTY.Index).Value
            Next
            TOTAL()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub TXTMILLQTY_KeyPress(sender As Object, e As KeyPressEventArgs)
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub TXTOURQTY_KeyPress(sender As Object, e As KeyPressEventArgs)
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub TXTDIFF_KeyPress(sender As Object, e As KeyPressEventArgs)
        numdotkeypress(e, sender, Me)
    End Sub


    Private Sub TXTWT_Validated(sender As Object, e As EventArgs) Handles TXTWT.Validated
        Try
            If CMBWASTAGETYPE.Text.Trim <> "" And Val(TXTWT.Text.Trim) > 0 Then fillwastagegrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBWASTAGETYPE_Validating(sender As Object, e As CancelEventArgs) Handles CMBWASTAGETYPE.Validating
        Try
            If CMBWASTAGETYPE.Text.Trim <> "" Then ITEMWASTEVALIDATE(CMBWASTAGETYPE, e, Me, " AND ITEMMASTER.ITEM_MATERIALTYPE = 'WASTAGE'", "MERCHANT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub



    Private Sub GRIDWASTAGE_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRIDWASTAGE.CellDoubleClick
        Try
            EDITWASTAGEROW()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBWASTAGETYPE_Enter(sender As Object, e As EventArgs) Handles CMBWASTAGETYPE.Enter
        Try
            If CMBWASTAGETYPE.Text.Trim = "" Then FILLWASTEITEM(CMBWASTAGETYPE, " AND ITEMMASTER.ITEM_MATERIALTYPE = 'WASTAGE'")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTWT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTWT.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub GRIDWASTAGE_KeyDown(sender As Object, e As KeyEventArgs) Handles GRIDWASTAGE.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDWASTAGE.RowCount > 0 Then
                If GRIDWASTAGEDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                GRIDWASTAGE.Rows.RemoveAt(GRIDWASTAGE.CurrentRow.Index)
                TOTAL()
                getsrno(GRIDWASTAGE)
            ElseIf e.KeyCode = Keys.F5 Then
                EDITWASTAGEROW()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GRIDPRODISSUE_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles GRIDPRODISSUE.CellValidating
        Dim colNum As Integer = GRIDPRODISSUE.Columns(e.ColumnIndex).Index
        If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return
        Select Case colNum

            Case GOURQTY.Index
                Dim dDebit As Decimal
                Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                If bValid Then
                    If GRIDPRODISSUE.CurrentCell.Value = Nothing Then GRIDPRODISSUE.CurrentCell.Value = "0.00"
                    GRIDPRODISSUE.CurrentCell.Value = Convert.ToDecimal(GRIDPRODISSUE.Item(colNum, e.RowIndex).Value)
                    TOTAL()
                Else
                    MessageBox.Show("Invalid Number Entered")
                    e.Cancel = True
                    'Exit Sub
                End If


        End Select
    End Sub
End Class