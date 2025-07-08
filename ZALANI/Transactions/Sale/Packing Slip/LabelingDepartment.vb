Imports System.ComponentModel
Imports BL

Public Class LabelingDepartment

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE, GRIDDOUBLECLICK, GRIDWASTAGEDOUBLECLICK As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public EDIT As Boolean          'used for editing
    Public TEMPLABNO As String
    Public TEMPMSG As Integer
    Dim TEMPROW As Integer
    Dim TEMPWASTAGEROW As Integer

    Private Sub cmdclear_Click(sender As Object, e As EventArgs) Handles cmdclear.Click
        clear()
        EDIT = False
    End Sub

    Private Sub cmdexit_Click(sender As Object, e As EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Sub clear()
        TXTLABNO.ReadOnly = True
        CMBGODOWN.Text = ""
        TXTPROFORMANO.Clear()
        TXTJONO.Clear()
        TXTPROFORMANO.Clear()
        TXTJONO.Clear()
        GRIDLAB.RowCount = 0
        GRIDWASTAGE.RowCount = 0
        TXTJOSRNO.Clear()
        DTJODATE.Text = ""
        TXTSONO.Text = ""
        TXTLABNO.Text = ""
        DTLABDATE.Text = Now.Date
        DTSODATE.Text = ""
        TXTGRIDWASTAGESRNO.Clear()
        TXTGRIDWASTAGESRNO.Text = 1
        CMBWASTAGETYPE.Text = ""
        getmax_LABNO()
        tstxtbillno.Clear()
        TXTREMARK.Clear()
        TXTSOTYPE.Clear()
        TXTJOTYPE.Text = ""
        EP.Clear()
        LBLTOTALROLL.Text = 0.0
        LBLTOTALLABWT.Text = 0.0
        LBLTOTALFINALWT.Text = 0.0
        LBLTOTALDIFF.Text = 0
        LBLTOTALWASWT.Text = 0
        TXTOTHERINFO.Clear()
        TXTPACKEDBY.Clear()
        TXTHANDLINGINFO.Clear()
        CMDSELECTSTOCK.Enabled = True
        CMBGODOWN.Enabled = True
        GRIDLAB.Focus()
        CMDSELECTJO.Enabled = True
        GRIDDOUBLECLICK = False
        GRIDWASTAGEDOUBLECLICK = False
        TXTPARTYNAME.Clear()

        lbllocked.Visible = False
        PBlock.Visible = False


    End Sub

    Sub getmax_LABNO()
        Dim DTTABLE As New DataTable
        DTTABLE = getmax(" isnull(max(LAB_NO),0) + 1 ", "LABELING", "  AND LAB_cmpid=" & CmpId & " and LAB_yearid=" & YearId)
        If DTTABLE.Rows.Count > 0 Then TXTLABNO.Text = DTTABLE.Rows(0).Item(0)
    End Sub

    Private Sub GRIDLAB_KeyDown(sender As Object, e As KeyEventArgs) Handles GRIDLAB.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDLAB.RowCount > 0 Then
                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                GRIDLAB.Rows.RemoveAt(GRIDLAB.CurrentRow.Index)
                TOTAL()
                getsrno(GRIDLAB)
                'ElseIf e.KeyCode = Keys.F5 Then
                '    EDITROW()
            ElseIf e.KeyCode = Keys.F12 And GRIDLAB.RowCount > 0 Then
                If GRIDLAB.CurrentRow.Cells(GGRADE.Index).Value <> "" Then GRIDLAB.Rows.Add(CloneWithValues(GRIDLAB.CurrentRow))

            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub FILLCMB()
        Try

            If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, EDIT)
            If CMBWASTAGETYPE.Text.Trim = "" Then FILLWASTEITEM(CMBWASTAGETYPE, "AND ITEM_FRMSTRING = 'MERCHANT'AND ITEMMASTER.ITEM_MATERIALTYPE = 'WASTAGE' ")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LabelingDepartment_Load(sender As Object, e As EventArgs) Handles Me.Load
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
                Dim OBJCLSINCENTIVE As New ClsLabeling
                Dim dttable As New DataTable

                dttable = OBJCLSINCENTIVE.SELECTLABELING(TEMPLABNO, CmpId, YearId)
                If dttable.Rows.Count > 0 Then

                    For Each dr As DataRow In dttable.Rows

                        TXTLABNO.Text = TEMPLABNO
                        TXTLABNO.ReadOnly = True
                        DTLABDATE.Text = Format(Convert.ToDateTime(dr("DATE")), "dd/MM/yyyy")
                        DTJODATE.Text = Format(Convert.ToDateTime(dr("JODATE")), "dd/MM/yyyy")
                        TXTJOTYPE.Text = dr("JOTYPE")
                        DTSODATE.Text = Format(Convert.ToDateTime(dr("SODATE")), "dd/MM/yyyy")
                        TXTSOTYPE.Text = dr("SOTYPE")
                        CMBGODOWN.Text = Convert.ToString(dr("GODOWN"))
                        TXTPROFORMANO.Text = dr("PROFORMANO")
                        TXTJONO.Text = dr("JONO")
                        TXTJOSRNO.Text = dr("JOSRNO")
                        TXTSONO.Text = dr("SONO")
                        TXTREMARK.Text = dr("REMARK")
                        TXTHANDLINGINFO.Text = dr("HANDLINGINFO")
                        TXTOTHERINFO.Text = dr("OTHERINFO")
                        TXTPACKEDBY.Text = dr("PACKEDBY")
                        LBLTOTALROLL.Text = dr("TOTALROLL")
                        LBLTOTALLABWT.Text = dr("TOTALLABWT")
                        LBLTOTALFINALWT.Text = dr("TOTALFINALWT")
                        LBLTOTALDIFF.Text = dr("TOTALDIFF")
                        TXTPARTYNAME.Text = dr("PARTYNAME")




                        GRIDLAB.Rows.Add(dr("GRIDSRNO").ToString, dr("GRADE").ToString, dr("LOTNO").ToString, dr("ROLLNO").ToString, dr("GSM").ToString, dr("GSMDETAILS").ToString, dr("SIZE").ToString, dr("WT").ToString, dr("ROLLOD").ToString, dr("ROLLID").ToString, dr("FINALWT").ToString, dr("DIFF").ToString, dr("UNIT").ToString, dr("JOINT").ToString, dr("NARRATION").ToString, dr("BARCODE").ToString, dr("DONE").ToString, Val(dr("OUTQTY")), Val(dr("FROMNO")), Val(dr("FROMSRNO")), dr("FROMTYPE"))

                        If Convert.ToBoolean(dr("DONE")) = True Or Val(dr("OUTQTY")) > 0 Then
                            GRIDLAB.Rows(GRIDLAB.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                            lbllocked.Visible = True
                            PBlock.Visible = True
                        End If

                    Next
                    'WASTAGE Grid
                    Dim OBJPRI As New ClsCommon
                    dttable = OBJPRI.SEARCH("ISNULL(ITEMMASTER.ITEM_NAME, '') AS WASTAGETYPE, ISNULL(LABELING_WASTAGE.LAB_GRIDWASTAGESRNO, 0) AS GRIDWASTAGESRNO, ISNULL(LABELING_WASTAGE.LAB_WASTAGEWT, '') AS WASTAGEWT ", "", " LABELING_WASTAGE LEFT OUTER JOIN ITEMMASTER ON LABELING_WASTAGE.LAB_WASTAGETYPEID = ITEMMASTER.item_id", " AND LAB_NO = " & TEMPLABNO & " AND LAB_CMPID = " & CmpId & " AND LAB_YEARID = " & YearId)
                    If dttable.Rows.Count > 0 Then
                        For Each dr As DataRow In dttable.Rows
                            GRIDWASTAGE.Rows.Add(dr("GRIDWASTAGESRNO").ToString, dr("WASTAGETYPE").ToString, dr("WASTAGEWT").ToString)
                        Next
                    End If


                    GRIDLAB.FirstDisplayedScrollingRowIndex = GRIDLAB.RowCount - 1
                    TOTAL()
                    CMBWASTAGETYPE.Focus()
                    CMDSELECTJO.Enabled = False
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
            ' If TXTLABNO.ReadOnly = False Then
            alParaval.Add(Val(TXTLABNO.Text.Trim))
            'Else
            ' alParaval.Add(0)
            ' End If

            alParaval.Add(Format(Convert.ToDateTime(DTLABDATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(TXTPARTYNAME.Text.Trim)
            alParaval.Add(Format(Convert.ToDateTime(DTJODATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(Format(Convert.ToDateTime(DTSODATE.Text).Date, "MM/dd/yyyy"))
            alParaval.Add(CMBGODOWN.Text.Trim)
            alParaval.Add(TXTHANDLINGINFO.Text.Trim)
            alParaval.Add(TXTOTHERINFO.Text.Trim)
            alParaval.Add(TXTPROFORMANO.Text.Trim)
            alParaval.Add(TXTPACKEDBY.Text.Trim)
            alParaval.Add(TXTJONO.Text.Trim)
            alParaval.Add(TXTJOSRNO.Text.Trim)
            alParaval.Add(TXTJOTYPE.Text.Trim)
            alParaval.Add(TXTSONO.Text.Trim)
            alParaval.Add(TXTSOTYPE.Text.Trim)
            alParaval.Add(TXTREMARK.Text.Trim)
            alParaval.Add(Val(LBLTOTALROLL.Text.Trim))
            alParaval.Add(Val(LBLTOTALLABWT.Text.Trim))
            alParaval.Add(Val(LBLTOTALFINALWT.Text.Trim))
            alParaval.Add(Val(LBLTOTALDIFF.Text.Trim))
            alParaval.Add(Val(LBLTOTALWASWT.Text.Trim))

            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)

            Dim GRIDLABSRNO As String = ""
            Dim GRADE As String = ""
            Dim LOTNO As String = ""
            Dim ROLLNO As String = ""
            Dim GSM As String = ""
            Dim GSMDETAILS As String = ""
            Dim SIZE As String = ""
            Dim WT As String = ""
            Dim ROLLOD As String = ""
            Dim ROLLID As String = ""
            Dim FINALWT As String = ""
            Dim DIFF As String = ""
            Dim UNIT As String = ""
            Dim JOINT As String = ""
            Dim NARRATION As String = ""
            Dim BARCODE As String = ""
            Dim DONE As String = ""
            Dim OUTQTY As String = ""
            Dim FROMNO As String = ""
            Dim FROMSRNO As String = ""
            Dim FROMTYPE As String = ""


            For Each row As Windows.Forms.DataGridViewRow In GRIDLAB.Rows
                If row.Cells(0).Value <> Nothing Then
                    If GRIDLABSRNO = "" Then
                        GRIDLABSRNO = Val(row.Cells(GLABSRNO.Index).Value)
                        GRADE = row.Cells(GGRADE.Index).Value.ToString
                        LOTNO = row.Cells(GLOTNO.Index).Value.ToString
                        ROLLNO = row.Cells(GROLLNO.Index).Value.ToString
                        GSM = Val(row.Cells(GGSM.Index).Value)
                        GSMDETAILS = row.Cells(GGSMDETAILS.Index).Value.ToString
                        SIZE = Val(row.Cells(GSIZE.Index).Value)
                        WT = row.Cells(GWT.Index).Value.ToString
                        ROLLOD = row.Cells(GROLLOD.Index).Value.ToString
                        ROLLID = row.Cells(GROLLID.Index).Value.ToString
                        FINALWT = row.Cells(GFINALWT.Index).Value.ToString
                        DIFF = row.Cells(GDIFF.Index).Value.ToString
                        UNIT = row.Cells(GUNIT.Index).Value.ToString
                        JOINT = row.Cells(GJOINT.Index).Value.ToString
                        NARRATION = row.Cells(GNARRATION.Index).Value.ToString
                        BARCODE = row.Cells(GBARCODE.Index).Value.ToString
                        If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then DONE = 1 Else DONE = 0
                        OUTQTY = Val(row.Cells(GOUTQTY.Index).Value)
                        FROMNO = Val(row.Cells(GFROMNO.Index).Value)
                        FROMSRNO = Val(row.Cells(GFROMSRNO.Index).Value)
                        FROMTYPE = row.Cells(GFROMTYPE.Index).Value.ToString



                    Else

                        GRIDLABSRNO = GRIDLABSRNO & "|" & Val(row.Cells(GLABSRNO.Index).Value)
                        GRADE = GRADE & "|" & row.Cells(GGRADE.Index).Value.ToString
                        LOTNO = LOTNO & "|" & row.Cells(GLOTNO.Index).Value.ToString
                        ROLLNO = ROLLNO & "|" & row.Cells(GROLLNO.Index).Value.ToString
                        GSM = GSM & "|" & Val(row.Cells(GGSM.Index).Value)
                        GSMDETAILS = GSMDETAILS & "|" & row.Cells(GGSMDETAILS.Index).Value.ToString
                        SIZE = SIZE & "|" & Val(row.Cells(GSIZE.Index).Value)
                        WT = WT & "|" & row.Cells(GWT.Index).Value.ToString
                        ROLLOD = ROLLOD & "|" & row.Cells(GROLLOD.Index).Value.ToString
                        ROLLID = ROLLID & "|" & row.Cells(GROLLID.Index).Value.ToString
                        FINALWT = FINALWT & "|" & row.Cells(GFINALWT.Index).Value.ToString
                        DIFF = DIFF & "|" & row.Cells(GDIFF.Index).Value.ToString
                        UNIT = UNIT & "|" & row.Cells(GUNIT.Index).Value.ToString
                        JOINT = JOINT & "|" & row.Cells(GJOINT.Index).Value.ToString
                        NARRATION = NARRATION & "|" & row.Cells(GNARRATION.Index).Value.ToString
                        BARCODE = BARCODE & "|" & row.Cells(GBARCODE.Index).Value.ToString
                        If Convert.ToBoolean(row.Cells(GDONE.Index).Value) = True Then DONE = DONE & "|" & "1" Else DONE = DONE & "|" & "0"
                        OUTQTY = OUTQTY & "|" & Val(row.Cells(GOUTQTY.Index).Value)
                        FROMNO = FROMNO & "|" & Val(row.Cells(GFROMNO.Index).Value)
                        FROMSRNO = FROMSRNO & "|" & Val(row.Cells(GFROMSRNO.Index).Value)
                        FROMTYPE = FROMTYPE & "|" & row.Cells(GFROMTYPE.Index).Value.ToString



                    End If
                End If
            Next

            alParaval.Add(GRIDLABSRNO)
            alParaval.Add(GRADE)
            alParaval.Add(LOTNO)
            alParaval.Add(ROLLNO)
            alParaval.Add(GSM)
            alParaval.Add(GSMDETAILS)
            alParaval.Add(SIZE)
            alParaval.Add(WT)
            alParaval.Add(ROLLOD)
            alParaval.Add(ROLLID)
            alParaval.Add(FINALWT)
            alParaval.Add(DIFF)
            alParaval.Add(UNIT)
            alParaval.Add(JOINT)
            alParaval.Add(NARRATION)
            alParaval.Add(BARCODE)
            alParaval.Add(DONE)
            alParaval.Add(OUTQTY)
            alParaval.Add(FROMNO)
            alParaval.Add(FROMSRNO)
            alParaval.Add(FROMTYPE)



            '' FOR WASTAGE GRID''
            Dim GRIDWASTAGESRNO As String = ""
            Dim WASTAGETYPE As String = ""
            Dim WASTAGEWT As String = ""


            For Each row As Windows.Forms.DataGridViewRow In GRIDWASTAGE.Rows
                If row.Cells(0).Value <> Nothing Then
                    If GRIDWASTAGESRNO = "" Then
                        GRIDWASTAGESRNO = Val(row.Cells(GWASTAGESRNO.Index).Value)
                        WASTAGETYPE = row.Cells(GWASTAGETYPE.Index).Value.ToString
                        WASTAGEWT = row.Cells(GWASTAGEWT.Index).Value.ToString

                    Else

                        GRIDWASTAGESRNO = GRIDWASTAGESRNO & "|" & Val(row.Cells(GWASTAGESRNO.Index).Value)
                        WASTAGETYPE = WASTAGETYPE & "|" & row.Cells(GWASTAGETYPE.Index).Value.ToString
                        WASTAGEWT = WASTAGEWT & "|" & row.Cells(GWASTAGEWT.Index).Value.ToString


                    End If
                End If
            Next

            alParaval.Add(GRIDWASTAGESRNO)
            alParaval.Add(WASTAGETYPE)
            alParaval.Add(WASTAGEWT)




            Dim objclsPurord As New ClsLabeling()
            objclsPurord.alParaval = alParaval

            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim DT As DataTable = objclsPurord.SAVE()
                MessageBox.Show("Details Added")
                TEMPLABNO = DT.Rows(0).Item(0)
            Else


                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPLABNO)
                IntResult = objclsPurord.UPDATE()
                MessageBox.Show("Details Updated")
                EDIT = False
            End If
            CMBGODOWN.Focus()
            clear()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub
    Sub PRINTREPORT(ByVal LABNO As Integer)
        Try
            If MsgBox("Wish to Print Labeling?", MsgBoxStyle.YesNo) = vbNo Then Exit Sub
            Dim OBJLAB As New SaleInvoiceDesign
            OBJLAB.FRMSTRING = "LABLENING"
            ' OBJLAB.LABNO = LABNO
            OBJLAB.PARTYNAME = CMBGODOWN.Text.Trim
            OBJLAB.MdiParent = MDIMain
            OBJLAB.Show()
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

        If DTLABDATE.Text = "__/__/____" Then
            EP.SetError(DTLABDATE, " Please Enter Proper Date")
            bln = False
        Else
            If Not datecheck(DTLABDATE.Text) Then
                EP.SetError(DTLABDATE, "Date not in Accounting Year")
                bln = False
            End If
        End If
        If Val(TXTJONO.Text.Trim) = 0 Then
            EP.SetError(TXTJONO, " Please Select Job Order")
            bln = False
        End If

        If GRIDLAB.RowCount = 0 Then
            EP.SetError(GRIDLAB, " Please Enter Proper Details ")
            bln = False
        End If
        'If GRIDLAB.RowCount = 0 Then
        '    EP.SetError(GGRAD, " Please Enter Quality Details ")
        '    bln = False
        'End If

        If LBLTOTALDIFF.Text <> LBLTOTALWASWT.Text Then
            EP.SetError(LBLTOTALDIFF, "Diff And Total Wastage Value Does Not Match ")
            bln = False
        End If

        If lbllocked.Visible = True Then
            EP.SetError(lbllocked, "Entry Locked!!")
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
                    MsgBox(" Labeling Locked", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                TEMPMSG = MsgBox("Delete Labeling?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbYes Then
                    Dim alParaval As New ArrayList
                    alParaval.Add(TXTLABNO.Text.Trim)
                    alParaval.Add(YearId)

                    Dim ClsINCTAG As New ClsLabeling()
                    ClsINCTAG.alParaval = alParaval
                    IntResult = ClsINCTAG.Delete()
                    MsgBox("Labeling Deleted")
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
            GRIDLAB.RowCount = 0
LINE1:
            TEMPLABNO = Val(TXTLABNO.Text) - 1
            If TEMPLABNO > 0 Then
                EDIT = True
                LabelingDepartment_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If

            If GRIDLAB.RowCount = 0 And TEMPLABNO > 1 Then
                TXTLABNO.Text = TEMPLABNO
                GoTo LINE1
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub toolnext_Click(sender As Object, e As EventArgs) Handles toolnext.Click
        Try
            GRIDLAB.RowCount = 0
LINE1:
            TEMPLABNO = Val(TXTLABNO.Text) + 1
            getmax_LABNO()
            Dim MAXNO As Integer = TXTLABNO.Text.Trim
            clear()
            If Val(TXTLABNO.Text) - 1 >= TEMPLABNO Then
                EDIT = True
                LabelingDepartment_Load(sender, e)
            Else
                clear()
                EDIT = False
            End If
            If GRIDLAB.RowCount = 0 And TEMPLABNO < MAXNO Then
                TXTLABNO.Text = TEMPLABNO
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

            Dim objINVDTLS As New LabelingDepartmentDetail
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
            If EDIT = True Then PRINTREPORT(TEMPLABNO)
            ' If GRIDLAB.RowCount > 0 Then PRINTBARCODE()
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
            ElseIf e.KeyCode = Keys.F12 And GRIDWASTAGE.RowCount > 0 Then
                If GRIDWASTAGE.CurrentRow.Cells(GWASTAGETYPE.Index).Value <> "" Then GRIDWASTAGE.Rows.Add(CloneWithValues(GRIDWASTAGE.CurrentRow))

            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub


    'Sub Fillgrid()
    '    Try
    '        If GRIDDOUBLECLICK = False Then
    '            GRIDLAB.Rows.Add(Val(TXTLABNO.Text.Trim), CMBGRADE.Text.Trim, TXTROLLNO.Text.Trim, TXTGSM.Text.Trim, TXTSIZE.Text.Trim, TXTLABWT.Text.Trim, TXTROLLOD.Text.Trim, TXTROLLID.Text.Trim, TXTFINALWT.Text.Trim, TXTDIFF.Text.Trim, CMBUNIT.Text.Trim, TXTJOINT.Text.Trim, TXTNARRATION.Text.Trim, TXTBARCODE.Text.Trim)
    '            getsrno(GRIDLAB)
    '        ElseIf GRIDDOUBLECLICK = True Then
    '            GRIDLAB.Item(GLABSRNO.Index, TEMPROW).Value = Val(TXTGRIDLABSRNO.Text.Trim)
    '            GRIDLAB.Item(GGRADE.Index, TEMPROW).Value = CMBGRADE.Text.Trim
    '            GRIDLAB.Item(GROLLNO.Index, TEMPROW).Value = (TXTROLLNO.Text.Trim)
    '            GRIDLAB.Item(GGSM.Index, TEMPROW).Value = (TXTGSM.Text.Trim)
    '            GRIDLAB.Item(GGSMDETAILS.Index, TEMPROW).Value = (TXTGSMDETAILS.Text.Trim)
    '            GRIDLAB.Item(GSIZE.Index, TEMPROW).Value = (TXTSIZE.Text.Trim)
    '            GRIDLAB.Item(GWT.Index, TEMPROW).Value = (TXTLABWT.Text.Trim)
    '            GRIDLAB.Item(GROLLOD.Index, TEMPROW).Value = (TXTROLLOD.Text.Trim)
    '            GRIDLAB.Item(GROLLID.Index, TEMPROW).Value = (TXTROLLID.Text.Trim)
    '            GRIDLAB.Item(GFINALWT.Index, TEMPROW).Value = (TXTFINALWT.Text.Trim)
    '            GRIDLAB.Item(GDIFF.Index, TEMPROW).Value = (TXTDIFF.Text.Trim)
    '            GRIDLAB.Item(GUNIT.Index, TEMPROW).Value = (CMBUNIT.Text.Trim)
    '            GRIDLAB.Item(GJOINT.Index, TEMPROW).Value = (TXTJOINT.Text.Trim)
    '            GRIDLAB.Item(GNARRATION.Index, TEMPROW).Value = (TXTNARRATION.Text.Trim)
    '            GRIDLAB.Item(GBARCODE.Index, TEMPROW).Value = (TXTBARCODE.Text.Trim)


    '            GRIDDOUBLECLICK = False

    '        End If
    '        TOTAL()


    '        GRIDLAB.FirstDisplayedScrollingRowIndex = GRIDLAB.RowCount - 1

    '        TXTGRIDLABSRNO.Text = GRIDLAB.RowCount + 1
    '        CMBGRADE.Text = ""
    '        TXTROLLNO.Clear()
    '        TXTGSM.Clear()
    '        TXTGSMDETAILS.Clear()
    '        TXTSIZE.Clear()
    '        TXTLABWT.Clear()
    '        TXTROLLOD.Clear()
    '        TXTROLLID.Clear()
    '        TXTFINALWT.Clear()
    '        TXTDIFF.Clear()
    '        CMBUNIT.Text = ""
    '        TXTJOINT.Clear()
    '        TXTNARRATION.Clear()
    '        TXTBARCODE.Clear()

    '        TXTROLLOD.Focus()
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

    'Sub EDITROW()
    '    Try
    '        If GRIDLAB.CurrentRow.Index >= 0 And GRIDLAB.Item(GLABSRNO.Index, GRIDLAB.CurrentRow.Index).Value <> Nothing Then
    '            GRIDDOUBLECLICK = True
    '            TXTGRIDLABSRNO.Text = GRIDLAB.Item(GLABSRNO.Index, GRIDLAB.CurrentRow.Index).Value.ToString
    '            CMBGRADE.Text = GRIDLAB.Item(GGRADE.Index, GRIDLAB.CurrentRow.Index).Value.ToString
    '            TXTROLLNO.Text = GRIDLAB.Item(GROLLNO.Index, GRIDLAB.CurrentRow.Index).Value.ToString
    '            TXTGSM.Text = GRIDLAB.Item(GGSM.Index, GRIDLAB.CurrentRow.Index).Value.ToString
    '            TXTGSMDETAILS.Text = GRIDLAB.Item(GGSMDETAILS.Index, GRIDLAB.CurrentRow.Index).Value.ToString
    '            TXTSIZE.Text = GRIDLAB.Item(GSIZE.Index, GRIDLAB.CurrentRow.Index).Value.ToString
    '            TXTLABWT.Text = GRIDLAB.Item(GWT.Index, GRIDLAB.CurrentRow.Index).Value.ToString
    '            TXTROLLOD.Text = GRIDLAB.Item(GROLLOD.Index, GRIDLAB.CurrentRow.Index).Value.ToString
    '            TXTROLLID.Text = GRIDLAB.Item(GROLLID.Index, GRIDLAB.CurrentRow.Index).Value.ToString
    '            TXTFINALWT.Text = GRIDLAB.Item(GFINALWT.Index, GRIDLAB.CurrentRow.Index).Value.ToString
    '            TXTDIFF.Text = GRIDLAB.Item(GDIFF.Index, GRIDLAB.CurrentRow.Index).Value.ToString
    '            CMBUNIT.Text = GRIDLAB.Item(GUNIT.Index, GRIDLAB.CurrentRow.Index).Value.ToString
    '            TXTJOINT.Text = GRIDLAB.Item(GJOINT.Index, GRIDLAB.CurrentRow.Index).Value.ToString
    '            TXTNARRATION.Text = GRIDLAB.Item(GNARRATION.Index, GRIDLAB.CurrentRow.Index).Value.ToString
    '            TXTBARCODE.Text = GRIDLAB.Item(GBARCODE.Index, GRIDLAB.CurrentRow.Index).Value.ToString


    '            TEMPROW = GRIDLAB.CurrentRow.Index
    '            TXTROLLID.Focus()
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub


    Private Sub DTLABDATE_GotFocus(sender As Object, e As EventArgs) Handles DTLABDATE.GotFocus
        DTLABDATE.SelectionStart = 0
    End Sub

    'Private Sub GRIDLAB_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRIDLAB.CellDoubleClick
    '    Try
    '        EDITROW()
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


    Private Sub TXTSIZE_KeyPress(sender As Object, e As KeyPressEventArgs)
        numkeypress(e, sender, Me)
    End Sub
    Private Sub TXTGSM_KeyPress(sender As Object, e As KeyPressEventArgs)
        numdotkeypress(e, sender, Me)
    End Sub




    'Private Sub CMBGRADE_Validating(sender As Object, e As CancelEventArgs)
    '    Try
    '        If CMBGRADE.Text.Trim <> "" Then ITEMVALIDATE(CMBGRADE, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'", "MERCHANT")
    '    Catch ex As Exception
    '        If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
    '    End Try
    'End Sub

    'Private Sub CMBQUALITY_Enter(sender As Object, e As EventArgs)
    '    Try
    '        If CMBGRADE.Text.Trim = "" Then FILLITEMNAME(CMBGRADE, EDIT)

    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    'Private Sub CMBUNIT_Validating(sender As Object, e As CancelEventArgs)
    '    Try
    '        If CMBUNIT.Text.Trim <> "" Then unitvalidate(CMBUNIT, e, Me)
    '        TOTAL()
    '    Catch ex As Exception
    '        If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
    '    End Try
    'End Sub

    'Private Sub CMBUNIT_Enter(sender As Object, e As EventArgs)
    '    Try
    '        If CMBUNIT.Text.Trim <> "" Then FILLUNIT(CMBUNIT)

    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Private Sub CMBWASTAGETYPE_Validating(sender As Object, e As CancelEventArgs) Handles CMBWASTAGETYPE.Validating
        Try
            If CMBWASTAGETYPE.Text.Trim <> "" Then ITEMWASTEVALIDATE(CMBWASTAGETYPE, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'", "MERCHANT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBWASTAGETYPE_Enter(sender As Object, e As EventArgs) Handles CMBWASTAGETYPE.Enter
        Try
            If CMBWASTAGETYPE.Text.Trim = "" Then FILLWASTEITEM(CMBWASTAGETYPE, "AND ITEMMASTER.ITEM_MATERIALTYPE = 'WASTAGE'")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub



    Sub fillwastagegrid()
        If GRIDWASTAGEDOUBLECLICK = False Then
            GRIDWASTAGE.Rows.Add(Val(TXTGRIDWASTAGESRNO.Text.Trim), CMBWASTAGETYPE.Text.Trim, Val(TXTWASTAGEWT.Text.Trim))
            getsrno(GRIDWASTAGE)
        ElseIf GRIDWASTAGEDOUBLECLICK = True Then
            GRIDWASTAGE.Item(GWASTAGESRNO.Index, TEMPWASTAGEROW).Value = Val(TXTGRIDWASTAGESRNO.Text.Trim)
            GRIDWASTAGE.Item(GWASTAGETYPE.Index, TEMPWASTAGEROW).Value = CMBWASTAGETYPE.Text.Trim
            GRIDWASTAGE.Item(GWASTAGEWT.Index, TEMPWASTAGEROW).Value = (TXTWASTAGEWT.Text.Trim)



            GRIDWASTAGEDOUBLECLICK = False

        End If
        TOTAL()

        GRIDWASTAGE.FirstDisplayedScrollingRowIndex = GRIDWASTAGE.RowCount - 1

        TXTGRIDWASTAGESRNO.Clear()
        CMBWASTAGETYPE.Text = ""
        TXTWASTAGEWT.Clear()
        CMBWASTAGETYPE.Focus()
    End Sub

    Sub EDITWASTAGEROW()
        Try

            If GRIDWASTAGE.CurrentRow.Index >= 0 And GRIDWASTAGE.Item(GWASTAGESRNO.Index, GRIDWASTAGE.CurrentRow.Index).Value <> Nothing Then
                GRIDWASTAGEDOUBLECLICK = True
                TXTGRIDWASTAGESRNO.Text = GRIDWASTAGE.Item(GWASTAGESRNO.Index, GRIDWASTAGE.CurrentRow.Index).Value.ToString
                CMBWASTAGETYPE.Text = GRIDWASTAGE.Item(GWASTAGETYPE.Index, GRIDWASTAGE.CurrentRow.Index).Value.ToString
                TXTWASTAGEWT.Text = GRIDWASTAGE.Item(GWASTAGEWT.Index, GRIDWASTAGE.CurrentRow.Index).Value.ToString

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

    Private Sub TXTWT_Validated(sender As Object, e As EventArgs)
        Try
            If CMBWASTAGETYPE.Text.Trim <> "" And Val(TXTWASTAGEWT.Text.Trim) > 0 Then fillwastagegrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LabelingDepartment_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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
                GRIDLAB.Focus()
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
                GRIDLAB.RowCount = 0
                TEMPLABNO = Val(tstxtbillno.Text)
                If TEMPLABNO > 0 Then
                    EDIT = True
                    LabelingDepartment_Load(sender, e)
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
            LBLTOTALROLL.Text = 0.0
            LBLTOTALLABWT.Text = 0.0
            LBLTOTALFINALWT.Text = 0.0
            LBLTOTALDIFF.Text = 0.0


            For Each ROW As DataGridViewRow In GRIDLAB.Rows
                If ROW.Cells(GLABSRNO.Index).Value <> Nothing Then
                    LBLTOTALLABWT.Text = Format(Val(LBLTOTALLABWT.Text) + Val(ROW.Cells(GWT.Index).EditedFormattedValue), "0.00")
                    LBLTOTALFINALWT.Text = Format(Val(LBLTOTALFINALWT.Text) + Val(ROW.Cells(GFINALWT.Index).EditedFormattedValue), "0")
                    ROW.Cells(GDIFF.Index).Value = Format(Val(ROW.Cells(GFINALWT.Index).EditedFormattedValue) - Val(ROW.Cells(GWT.Index).EditedFormattedValue), "0.00")
                    LBLTOTALDIFF.Text = Val(LBLTOTALDIFF.Text) + Val(ROW.Cells(GDIFF.Index).EditedFormattedValue)
                End If
            Next

            LBLTOTALWASWT.Text = 0

            For Each ROW As DataGridViewRow In GRIDWASTAGE.Rows
                If ROW.Cells(GWASTAGESRNO.Index).Value <> Nothing Then
                    LBLTOTALWASWT.Text = Val(LBLTOTALWASWT.Text) + Val(ROW.Cells(GWASTAGEWT.Index).EditedFormattedValue)

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
            For i = 0 To GRIDLAB.Rows.Count - 1
                If Not GRIDLAB.Rows(i).IsNewRow Then
                    cellValue = GRIDLAB(GROLLNO.Index, i).EditedFormattedValue.ToString()
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

    'Private Sub TXTBARCODE_Validated(sender As Object, e As EventArgs)
    '    Try
    '        If CMBGRADE.Text.Trim <> "" And CMBUNIT.Text.Trim <> "" Then Fillgrid()
    '        TOTAL()
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Private Sub TXTWASTAGEWT_Validated(sender As Object, e As EventArgs) Handles TXTWASTAGEWT.Validated
        Try
            If CMBWASTAGETYPE.Text.Trim <> "" And Val(TXTWASTAGEWT.Text.Trim) > 0 Then fillwastagegrid()
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

            If CMBGODOWN.Text.Trim <> "" Then

                Dim OBJSELECTLABLE As New SelectStock
                OBJSELECTLABLE.FRMSTRING = "LABELING"
                Dim DTPO As DataTable = OBJSELECTLABLE.DT
                OBJSELECTLABLE.GODOWN = CMBGODOWN.Text.Trim
                OBJSELECTLABLE.ShowDialog()

                Dim BARCODE As String = ""

                For Each DTROW As DataRow In DTPO.Rows

                    If EDIT = True Then
                        'GET LAST BARCODE SRNO
                        Dim LSRNO As Integer = 0
                        Dim RSRNO As Integer = 0
                        Dim SNO As Integer = 0
                        LSRNO = InStr(GRIDLAB.Rows(GRIDLAB.RowCount - 1).Cells(GBARCODE.Index).Value, "/")
                        RSRNO = InStr(LSRNO + 1, GRIDLAB.Rows(GRIDLAB.RowCount - 1).Cells(GBARCODE.Index).Value, "/")
                        SNO = GRIDLAB.Rows(GRIDLAB.RowCount - 1).Cells(GBARCODE.Index).Value.ToString.Substring(LSRNO, (RSRNO - LSRNO) - 1)

                        BARCODE = "L-" & Val(TXTLABNO.Text.Trim) & "/" & SNO + 1 & "/" & YearId
                    Else
                        BARCODE = "L-" & Val(TXTLABNO.Text.Trim) & "/" & GRIDLAB.RowCount + 1 & "/" & YearId
                    End If


                    GRIDLAB.Rows.Add(0, DTROW("ITEMNAME"), DTROW("LOTNO"), DTROW("REELNO"), Val(DTROW("GSM")), DTROW("GSMDETAILS"), Val(DTROW("SIZE")), Val(DTROW("QTY")), DTROW("ROLLOD"), DTROW("ROLLID"), 0, 0, DTROW("UNIT"), 0, "", BARCODE, 0, 0, DTROW("FROMNO"), DTROW("FROMSRNO"), DTROW("FROMTYPE"))

NEXTLINE:
                Next




                getsrno(GRIDLAB)
                TOTAL()
                CMBGODOWN.Enabled = False
                CMDSELECTSTOCK.Enabled = True

            Else
                MsgBox("Enter Godown Name")
                CMBGODOWN.Focus()
            End If




        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDSELECTJO_Click(sender As Object, e As EventArgs) Handles CMDSELECTJO.Click
        Try
            EP.Clear()
            If CMBGODOWN.Text.Trim = "" Then
                MsgBox("Please Fill Godown Name", MsgBoxStyle.Critical)
                CMBGODOWN.Focus()
                Exit Sub
            End If

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
                TXTPARTYNAME.Text = DT.Rows(0).Item("PARTYNAME")




            End If
            CMDSELECTJO.Enabled = True
            getsrno(GRIDLAB)


        Catch ex As Exception
            Throw ex
        End Try
    End Sub



    'Private Sub TXTNARRATION_Validated(sender As Object, e As EventArgs)
    '    Try
    '        If CMBGRADE.Text.Trim <> "" Then
    '            CMBGRADE.Enabled = False
    '            'If FRMSTRING = "GRN FANCY" Then
    '            If TXTBARCODE.Text = "" Then
    '                If EDIT = True Then
    '                    'GET LAST BARCODE SRNO
    '                    Dim LSRNO As Integer = 0
    '                    Dim RSRNO As Integer = 0
    '                    Dim SNO As Integer = 0
    '                    LSRNO = InStr(GRIDLAB.Rows(GRIDLAB.RowCount - 1).Cells(GBARCODE.Index).Value, "/")
    '                    RSRNO = InStr(LSRNO + 1, GRIDLAB.Rows(GRIDLAB.RowCount - 1).Cells(GBARCODE.Index).Value, "/")
    '                    SNO = GRIDLAB.Rows(GRIDLAB.RowCount - 1).Cells(GBARCODE.Index).Value.ToString.Substring(LSRNO, (RSRNO - LSRNO) - 1)

    '                    TXTBARCODE.Text = "L-" & Val(TXTLABNO.Text.Trim) & "/" & SNO + 1 & "/" & YearId
    '                Else
    '                    TXTBARCODE.Text = "L-" & Val(TXTLABNO.Text.Trim) & "/" & GRIDLAB.RowCount + 1 & "/" & YearId
    '                End If
    '            End If
    '            'End If
    '            Fillgrid()
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Private Sub TXTLABWT_KeyPress(sender As Object, e As KeyPressEventArgs)
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub TXTFINALWT_KeyPress(sender As Object, e As KeyPressEventArgs)
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub TXTDIFF_KeyPress(sender As Object, e As KeyPressEventArgs)
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub TXTJOINT_KeyPress(sender As Object, e As KeyPressEventArgs)
        numkeypress(e, sender, Me)
    End Sub

    Private Sub GRIDLAB_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles GRIDLAB.CellValidating
        Dim colNum As Integer = GRIDLAB.Columns(e.ColumnIndex).Index
        If String.IsNullOrEmpty(e.FormattedValue.ToString) Then Return
        Select Case colNum

            Case GFINALWT.Index
                Dim dDebit As Decimal
                Dim bValid As Boolean = Decimal.TryParse(e.FormattedValue.ToString, dDebit)

                If bValid Then
                    If GRIDLAB.CurrentCell.Value = Nothing Then GRIDLAB.CurrentCell.Value = "0.00"
                    GRIDLAB.CurrentCell.Value = Convert.ToDecimal(GRIDLAB.Item(colNum, e.RowIndex).Value)
                    TOTAL()
                Else
                    MessageBox.Show("Invalid Number Entered")
                    e.Cancel = True
                    'Exit Sub
                End If


        End Select
    End Sub
End Class