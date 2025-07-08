
Imports BL
Imports System.IO
Imports System.ComponentModel

Public Class ItemMaster

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Dim IntResult As Integer
    Dim GRIDDOUBLECLICK, GRIDPROCESSDOUBLECLICK, GRIDSTORESDOUBLECLICK, GRIDMATCHDOUBLECLICK, GRIDBOMDOUBLECLICK, GRIDWEFTDOUBLECLICK, GRIDSHADEDOUBLECLICK As Boolean
    Dim TEMPROW, TEMPPROW, TEMPUPLOADROW, TEMPSROW, TEMPMATCHROW, TEMPWARPROW, TEMPWEFTROW, TEMPSHADEROW As Integer
    Public EDIT As Boolean
    Public tempItemName, tempItemCODE, frmstring As String
    Dim tempItemId As Integer

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            'IF WE MAKE ANY CHANGES IN SAVE CODE THEN DO THE SAME CHANGS IN THE FOLLOWING FORMS
            '1) UPLOADSTOCK AND UPLOADITEM ON MDIMAIN
            '2) TXTCHNO_VALIDATED IN GRN
            '3) TXTCCMPSO_VALIDATED IN SALEORDER
            '4) CMDSELECTGDN_CLICK IN PURCHASEINVOICE
            '5) TXTCHNO_VALIDATED IN STOCKRECO
            '6) CMDSELECTCHALLAN_CLICK IN SALEINVOICE


            Ep.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim alParaval As New ArrayList
            alParaval.Add(UCase(TXTCODE.Text.Trim))
            alParaval.Add(cmbmaterial.Text.Trim)
            alParaval.Add(CMBITEMTYPE.Text.Trim)
            alParaval.Add(UCase(CMBNAME.Text.Trim))

            alParaval.Add(cmbunit.Text.Trim)
            alParaval.Add(TXTRATE.Text.Trim)
            alParaval.Add(CMBHSNCODE.Text.Trim)
            alParaval.Add(CHKBLOCKED.CheckState)
            alParaval.Add(frmstring)


            'FOR GRIDPARAMETER
            Dim GRIDSRNO As String = ""
            Dim ITEMNAME As String = ""
            Dim QUALITY As String = ""

            For Each ROW As DataGridViewRow In GRIDBOMDETAILS.Rows
                If ROW.Cells(0).Value <> Nothing Then
                    If GRIDSRNO = "" Then
                        GRIDSRNO = ROW.Cells(GSRNO.Index).Value
                        ITEMNAME = ROW.Cells(GITEMNAME.Index).Value.ToString
                        QUALITY = ROW.Cells(GQUALITY.Index).Value
                    Else
                        GRIDSRNO = GRIDSRNO & "|" & ROW.Cells(GSRNO.Index).Value.ToString
                        ITEMNAME = ITEMNAME & "|" & ROW.Cells(GITEMNAME.Index).Value
                        QUALITY = QUALITY & "|" & ROW.Cells(GQUALITY.Index).Value
                    End If
                End If
            Next


            alParaval.Add(GRIDSRNO)
            alParaval.Add(ITEMNAME)
            alParaval.Add(QUALITY)

            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)
            alParaval.Add(CHKPE.CheckState)
            alParaval.Add(CHKLAMINATION.CheckState)
            alParaval.Add(CHKSLITTING.CheckState)
            alParaval.Add(TXTMICRON.Text.Trim)
            alParaval.Add(TXTCALCULATEON.Text.Trim)



            Dim objclsItemMaster As New clsItemmaster
            objclsItemMaster.alParaval = alParaval

            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = objclsItemMaster.SAVE()
                MsgBox("Details Added")
            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(tempItemId)
                IntResult = objclsItemMaster.UPDATE()
                MsgBox("Details Updated")

            End If
            EDIT = False

            CLEAR()
            CMBNAME.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Function CHECKDUPLICATE() As Boolean
        Try
            Dim BLN As Boolean = True
            pcase(CMBNAME)
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable
            If (EDIT = False) Or (EDIT = True And LCase(CMBNAME.Text) <> LCase(tempItemName)) Then
                dt = objclscommon.search("ITEM_NAME", "", "ItemMaster", " and ITEM_NAME = '" & CMBNAME.Text.Trim & "'  And item_cmpid = " & CmpId & " And item_locationid = " & Locationid & " And item_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    MsgBox("Item Name Already Exists", MsgBoxStyle.Critical, "ZALANI")
                    BLN = False
                End If
            End If
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function ERRORVALID() As Boolean

        Dim bln As Boolean = True
        If TXTCODE.Text.Trim.Length = 0 Then
            Ep.SetError(TXTCODE, "Fill Item Code")
            bln = False
        End If

        'If CMBHSNCODE.Text.Trim.Length = 0 Then
        '    Ep.SetError(CMBHSNCODE, "Fill HSN Code")
        '    bln = False
        'End If

        If CMBNAME.Text.Trim.Length = 0 Then
            Ep.SetError(CMBNAME, "Fill Item Name")
            bln = False
        End If

        If cmbunit.Text.Trim.Length = 0 Then
            Ep.SetError(cmbunit, "Fill Unit")
            bln = False
        End If


        If EDIT = False Then
            If Not CHECKDUPLICATE() Then
                Ep.SetError(CMBNAME, "Item Name Already Exists")
                bln = False
            End If
        End If

        If CMBITEMTYPE.Text.Trim.Length = 0 Then
            Ep.SetError(CMBITEMTYPE, "Fill Item Type")
            bln = False
        End If



        If cmbmaterial.Text.Trim.Length = 0 Then
            Ep.SetError(cmbmaterial, "Select Material Type")
            bln = False
        ElseIf cmbmaterial.Text.Trim = "FINISHED" And CHKPE.Checked = False And CHKLAMINATION.Checked = False And CHKSLITTING.Checked = False Then
            Ep.SetError(CHKPE, "Select Atleast 1 Process")
            bln = False
        End If


        Return bln
    End Function

    Sub CLEAR()

        cmbmaterial.Text = ""
        CMBITEMTYPE.Text = ""

        CMBNAME.Text = ""
        TXTCODE.Clear()
        cmbunit.Text = ""

        TXTRATE.Clear()

        If ClientName = "SOFTAS" Then CMBHSNCODE.Text = "540782" Else CMBHSNCODE.Text = ""

        CHKBLOCKED.CheckState = CheckState.Unchecked
        CHKPE.CheckState = CheckState.Unchecked
        CHKLAMINATION.CheckState = CheckState.Unchecked
        CHKSLITTING.CheckState = CheckState.Unchecked

        TXTWARPSRNO.Clear()
        CMBITEMNAME.Text = ""

        GRIDBOMDETAILS.RowCount = 0

        GRIDDOUBLECLICK = False
        GRIDPROCESSDOUBLECLICK = False
        GRIDSTORESDOUBLECLICK = False
        GRIDMATCHDOUBLECLICK = False
        GRIDBOMDOUBLECLICK = False
        GRIDWEFTDOUBLECLICK = False

    End Sub


    Sub FILLBOMGRID()

        If GRIDBOMDOUBLECLICK = False Then
            GRIDBOMDETAILS.Rows.Add(Val(TXTWARPSRNO.Text.Trim), CMBITEMNAME.Text.Trim, (TXTQUALITY.Text.Trim))
            getsrno(GRIDBOMDETAILS)
        ElseIf GRIDBOMDOUBLECLICK = True Then
            GRIDBOMDETAILS.Item(GSRNO.Index, TEMPWARPROW).Value = Val(TXTWARPSRNO.Text.Trim)
            GRIDBOMDETAILS.Item(GITEMNAME.Index, TEMPWARPROW).Value = CMBITEMNAME.Text.Trim
            GRIDBOMDETAILS.Item(GQUALITY.Index, TEMPWARPROW).Value = TXTQUALITY.Text.Trim

            TEMPWARPROW = GRIDBOMDETAILS.CurrentRow.Index
            GRIDBOMDOUBLECLICK = False
        End If

        CMBITEMNAME.Text = ""
        TXTQUALITY.Clear()
        TXTWARPSRNO.Text = GRIDBOMDETAILS.RowCount + 1
        CMBITEMNAME.Focus()
    End Sub

    Function CHECKBOMDETAILS() As Boolean
        Try
            Dim BLN As Boolean = True
            For Each row As DataGridViewRow In GRIDBOMDETAILS.Rows
                If (GRIDBOMDOUBLECLICK = True And TEMPWARPROW <> row.Index) Or GRIDBOMDOUBLECLICK = False Then
                    If CMBITEMNAME.Text.Trim = row.Cells(GITEMNAME.Index).Value Then BLN = False
                End If
            Next
            Return BLN
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    'Private Sub cmbcategory_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbcategory.Enter
    '    Try
    '        If cmbcategory.Text.Trim = "" Then fillCATEGORY(cmbcategory, EDIT)
    '    Catch ex As Exception
    '        If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
    '    End Try
    'End Sub

    'Private Sub cmbcategory_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbcategory.Validating
    '    Try
    '        If cmbcategory.Text.Trim <> "" Then CATEGORYVALIDATE(cmbcategory, e, Me)
    '    Catch ex As Exception
    '        If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
    '    End Try
    'End Sub

    Private Sub cmbunit_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbunit.Enter
        Try
            If cmbunit.Text.Trim = "" Then FILLUNIT(cmbunit)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbunit_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbunit.Validating
        Try
            If cmbunit.Text.Trim <> "" Then unitvalidate(cmbunit, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub ItemMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Sub FILLCMB()

        Dim objclscommon As New ClsCommonMaster
        Dim dt As DataTable

        '  fillCATEGORY(cmbcategory, False)

        dt = objclscommon.search("ITEM_NAME", "", "ItemMaster", " AND ITEM_FRMSTRING = '" & frmstring & "' and Item_cmpid = " & CmpId & " and Item_locationid = " & Locationid & " and Item_yearid = " & YearId)
        If dt.Rows.Count > 0 Then
            dt.DefaultView.Sort = "ITEM_NAME"
            CMBNAME.DataSource = dt
            CMBNAME.DisplayMember = "ITEM_NAME"
            CMBNAME.Text = ""
        End If

        If CMBHSNCODE.Text.Trim = "" Then FILLHSNITEMDESC(CMBHSNCODE)

    End Sub

    Private Sub CMBHSNCODE_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBHSNCODE.Enter
        Try
            If CMBHSNCODE.Text.Trim = "" Then FILLHSNITEMDESC(CMBHSNCODE)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLHSNITEMDESC(ByRef CMBHSNCODE As ComboBox)
        Try
            Dim objclscommon As New ClsCommon
            Dim dt As DataTable

            dt = objclscommon.SEARCH(" ISNULL(HSN_CODE, '') AS HSNCODE ", "", " HSNMASTER ", " AND HSN_YEARID = " & YearId)
            If dt.Rows.Count > 0 Then
                dt.DefaultView.Sort = "HSNCODE"
                CMBHSNCODE.DataSource = dt
                CMBHSNCODE.DisplayMember = "HSNCODE"
                CMBHSNCODE.Text = ""
            End If
            CMBHSNCODE.SelectAll()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBHSNCODE_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBHSNCODE.Validating
        Try
            If CMBHSNCODE.Text.Trim <> "" Then HSNITEMDESCVALIDATE(CMBHSNCODE, e, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ItemMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ITEM MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            FILLCMB()
            CLEAR()
            TXTCODE.Text = tempItemCODE
            CMBNAME.Text = tempItemName
            'If frmstring = "MERCHANT" Then
            '    cmbmaterial.Visible = False
            '    lblmaterial.Visible = False
            '    cmbmaterial.Text = "Finished Goods"
            'End If

            If EDIT = True Then

                Dim objCommon As New ClsCommonMaster
                Dim dttable As DataTable = objCommon.search("  ISNULL(ITEMMASTER.item_id, 0) AS ITEMID, ISNULL(ITEMMASTER.ITEM_NAME, '') AS NAME, ISNULL(ITEMMASTER.item_materialtype, '') AS MATERIAL, ISNULL(ITEMMASTER.ITEM_NAME, '') AS NAME, ISNULL(ITEMMASTER.ITEM_RATE, 0) AS RATE, ISNULL(ITEMMASTER.ITEM_BLOCKED, 0) AS BLOCKED, ISNULL(ITEMMASTER.ITEM_FRMSTRING, '') AS FRMSTRING, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT, ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(ITEMMASTER.ITEM_PE, 0) AS PE, ISNULL(ITEMMASTER.ITEM_LAMINATION, 0) AS LAMINATION, ISNULL(ITEMMASTER.ITEM_SLITTING, 0) AS SLITTING, ISNULL(ITEMMASTER.item_code, '') AS ITEMCODE, ISNULL(ITEMMASTER.item_ITEMTYPE, '') AS ITEMTYPE ,ISNULL(ITEMMASTER.item_MICRON, '') AS MICRON ,ISNULL(ITEMMASTER.item_CALCULATEON, '') AS CALCULATEON", "", " ITEMMASTER LEFT OUTER JOIN HSNMASTER ON ITEMMASTER.ITEM_HSNCODEID = HSNMASTER.HSN_ID LEFT OUTER JOIN UNITMASTER ON ITEMMASTER.item_unitid = UNITMASTER.unit_id", " and ITEMMASTER.ITEM_NAME = '" & tempItemName & "' AND ITEMMASTER.ITEM_FRMSTRING = '" & frmstring & "' and ITEMMASTER.Item_yearid = " & YearId)
                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                If dttable.Rows.Count > 0 Then
                    For Each ROW As DataRow In dttable.Rows
                        TXTCODE.Text = Convert.ToString(ROW("ITEMCODE"))
                        ' tempItemCODE = Convert.ToString(ROW("ITEMCODE"))
                        tempItemId = ROW("ITEMID")
                        cmbmaterial.Text = ROW("MATERIAL").ToString
                        CMBITEMTYPE.Text = ROW("ITEMTYPE").ToString
                        CMBNAME.Text = ROW("NAME").ToString
                        cmbunit.Text = ROW("UNIT").ToString
                        TXTRATE.Text = Val(ROW("RATE").ToString)
                        CMBHSNCODE.Text = ROW("HSNCODE").ToString
                        CHKBLOCKED.Checked = Convert.ToBoolean(dttable.Rows(0).Item("BLOCKED"))
                        CHKPE.Checked = Convert.ToBoolean(dttable.Rows(0).Item("PE"))
                        CHKLAMINATION.Checked = Convert.ToBoolean(dttable.Rows(0).Item("LAMINATION"))
                        CHKSLITTING.Checked = Convert.ToBoolean(dttable.Rows(0).Item("SLITTING"))
                        TXTMICRON.Text = Val(ROW("MICRON").ToString)
                        TXTCALCULATEON.Text = Val(ROW("CALCULATEON").ToString)

                    Next



                    'PROCESS GRID
                    Dim OBJCMN As New ClsCommon
                    Dim dt As DataTable = OBJCMN.SEARCH(" ISNULL(ITEMMASTER_DESC.ITEM_GRIDSRNO, 0) AS GRIDSRNO, ISNULL(ITEMMASTER_DESC.ITEM_QUALITY,0) AS QUALITY, ISNULL(ITEMMASTER.ITEM_NAME, '') AS NAME", "", "  ITEMMASTER_DESC LEFT OUTER JOIN ITEMMASTER ON ITEMMASTER_DESC.ITEM_ITEMID = ITEMMASTER.item_id", " AND ITEMMASTER_DESC.ITEM_ID = " & tempItemId & " AND ITEMMASTER_DESC.ITEM_YEARID = " & YearId)
                    If dt.Rows.Count > 0 Then
                        For Each DTR1 As DataRow In dt.Rows
                            GRIDBOMDETAILS.Rows.Add(DTR1("GRIDSRNO"), DTR1("NAME"), DTR1("QUALITY"))
                        Next
                    End If

                End If
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("item_NAME", "", " ItemMaster ", " and ITEM_FRMSTRING = '" & frmstring & "' and Item_cmpid = " & CmpId & " and Item_locationid = " & Locationid & " and Item_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "Item_NAME"
                    CMBNAME.DataSource = dt
                    CMBNAME.DisplayMember = "Item_NAME"
                    CMBNAME.Text = ""
                End If
                CMBNAME.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        If CMBNAME.Text.Trim <> "" Then
            uppercase(CMBNAME)
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable
            If (EDIT = False) Or (EDIT = True And LCase(CMBNAME.Text) <> LCase(tempItemName)) Then
                dt = objclscommon.search("item_NAME", "", "ItemMaster", " and item_NAME = '" & CMBNAME.Text.Trim & "'  And item_cmpid = " & CmpId & " And item_locationid = " & Locationid & " And item_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    MsgBox("Item Name Already Exists", MsgBoxStyle.Critical, "ZALANI")
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub cmddelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddelete.Click
        '**** code for to delete the selected imtem from item master *****
        ' ****Logic 
        ' looking for in SalesOrder_Desc Table if Item master Name is Exists OR Not
        If USERDELETE = False Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If
        If CMBNAME.Text.Trim = "" Then
            MsgBox("Item Name Can Not Be Blank ")
            Exit Sub
        End If

        If EDIT = False Then
            'since user can delete Master only in edit mode
            MsgBox("Item Name Can Delete only in Edit Mode", MsgBoxStyle.Critical, "ZALANI")
            Exit Sub
        End If
        If CMBNAME.Text.Trim <> "" Then
            pcase(CMBNAME)
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable

            dt = objclscommon.search("ITEM_NAME", "", " dbo.ITEMMASTER RIGHT OUTER JOIN  dbo.SALEORDER_DESC ON dbo.ITEMMASTER.item_id = dbo.SALEORDER_DESC.so_itemid ", " and ITEM_NAME = '" & CMBNAME.Text.Trim & "' AND item_yearid = " & YearId)
            If dt.Rows.Count > 0 Then
                MsgBox("Item Name Already Used in Transaction Forms", MsgBoxStyle.Critical, "ZALANI")
                Exit Sub
            End If

            dt = objclscommon.search("ITEMNAME", "", " BARCODESTOCK ", " and ITEMNAME = '" & CMBNAME.Text.Trim & "' AND YEARID = " & YearId)
            If dt.Rows.Count > 0 Then
                MsgBox("Item Name Already Used in Transaction Forms", MsgBoxStyle.Critical, "ZALANI")
                Exit Sub
            End If

            dt = objclscommon.search("ITEMNAME", "", " OUTBARCODESTOCK ", " and ITEMNAME = '" & CMBNAME.Text.Trim & "' AND YEARID = " & YearId)
            If dt.Rows.Count > 0 Then
                MsgBox("Item Name Already Used in Transaction Forms", MsgBoxStyle.Critical, "ZALANI")
                Exit Sub
            End If

        End If
        'Dim tempMsg As Integer
        ''if above all conditions are false then only user can delete Particular Master
        If MsgBox("Delete Item Name ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim alParaval As New ArrayList
            alParaval.Add(CMBNAME.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(YearId)
            Dim clsitemst As New clsItemmaster
            clsitemst.alParaval = alParaval
            IntResult = clsitemst.Delete()
            MsgBox("Item Deleted")
            CLEAR()
            EDIT = False
        End If

    End Sub
    Private Sub txtrate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTRATE.KeyPress, TXTMICRON.KeyPress, TXTCALCULATEON.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub CMBHSNCODE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBHSNCODE.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectHSN
                OBJLEDGER.STRSEARCH = " AND HSN_TYPE='GOODS'"
                OBJLEDGER.ShowDialog()
                'If OBJLEDGER.TEMPCODE <> "" Then TXTHSNCODE.Text = OBJLEDGER.TEMPCODE

                If OBJLEDGER.TEMPCODE <> "" Then CMBHSNCODE.Text = OBJLEDGER.TEMPCODE

            End If
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

    Private Sub TXTQUALITY_Validated(sender As Object, e As EventArgs) Handles TXTQUALITY.Validated
        Try
            Try
                If CMBITEMNAME.Text.Trim <> "" Then
                    If Not CHECKBOMDETAILS() Then
                        MsgBox("Yarn already Present in Grid below")
                        Exit Sub
                    End If
                    FILLBOMGRID()
                End If
            Catch ex As Exception
                Throw ex
            End Try


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBITEMNAME_Enter(sender As Object, e As EventArgs) Handles CMBITEMNAME.Enter
        Try
            If CMBITEMNAME.Text.Trim = "" Then FILLITEMNAME(CMBITEMNAME, "")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GRIDBOMDETAILS_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GRIDBOMDETAILS.CellDoubleClick
        Try
            If e.RowIndex >= 0 AndAlso GRIDBOMDETAILS.Item(GQUALITY.Index, e.RowIndex).Value <> Nothing Then
                GRIDBOMDOUBLECLICK = True
                TEMPWARPROW = e.RowIndex
                TXTWARPSRNO.Text = Val(GRIDBOMDETAILS.Item(GSRNO.Index, e.RowIndex).Value)
                CMBITEMNAME.Text = GRIDBOMDETAILS.Item(GITEMNAME.Index, e.RowIndex).Value
                TXTQUALITY.Text = GRIDBOMDETAILS.Item(GQUALITY.Index, e.RowIndex).Value
                CMBITEMNAME.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDBOMDETAILS_KeyDown(sender As Object, e As KeyEventArgs) Handles GRIDBOMDETAILS.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDBOMDETAILS.RowCount > 0 Then
                If GRIDBOMDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If

                GRIDBOMDETAILS.Rows.RemoveAt(GRIDBOMDETAILS.CurrentRow.Index)
                getsrno(GRIDBOMDETAILS)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub txtitemcode_Validating(sender As Object, e As CancelEventArgs) Handles TXTCODE.Validating
        Try
            If TXTCODE.Text.Trim <> "" Then
                pcase(TXTCODE)
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                If (EDIT = False) Then ' Or (EDIT = True And LCase(TXTCODE.Text) <> LCase(tempItemCODE)) Then
                    dt = objclscommon.search("item_CODE", "", "ItemMaster", " and item_CODE = '" & TXTCODE.Text.Trim & "' And item_yearid = " & YearId)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Item Code Already Exists", MsgBoxStyle.Critical, "PRINTPRO")
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Validated(sender As Object, e As EventArgs) Handles CMBNAME.Validated
        Try
            If TXTCODE.Text.Trim = "" And CMBNAME.Text.Trim <> "" Then TXTCODE.Text = CMBNAME.Text.Trim
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBITEMNAME_Validating(sender As Object, e As CancelEventArgs) Handles CMBITEMNAME.Validating
        Try
            If CMBITEMNAME.Text.Trim <> "" Then ITEMVALIDATE(CMBITEMNAME, e, Me, "", "MERCHANT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
End Class