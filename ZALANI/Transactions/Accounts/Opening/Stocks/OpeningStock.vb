
Imports System.ComponentModel
Imports BL

Public Class OpeningStock

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim GRIDDOUBLECLICK As Boolean
    Dim TEMPROW As Integer
    Public EDIT As Boolean

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
            If GRIDSTOCK.CurrentRow.Index >= 0 And GRIDSTOCK.Item(gsrno.Index, GRIDSTOCK.CurrentRow.Index).Value <> Nothing Then

                If Convert.ToBoolean(GRIDSTOCK.Rows(GRIDSTOCK.CurrentRow.Index).Cells(GDONE.Index).Value) = True Then 'If row.Cells(16).Value <> "0" Then 
                    MsgBox("Item Locked", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                If GRIDSTOCK.Rows(GRIDSTOCK.CurrentRow.Index).DefaultCellStyle.BackColor = Color.Yellow Then
                    MsgBox("Item Locked", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                GRIDDOUBLECLICK = True
                TXTNO.Text = GRIDSTOCK.Item(GNO.Index, GRIDSTOCK.CurrentRow.Index).Value.ToString
                txtsrno.Text = GRIDSTOCK.Item(gsrno.Index, GRIDSTOCK.CurrentRow.Index).Value.ToString
                CMBITEMNAME.Text = GRIDSTOCK.Item(GITEMNAME.Index, GRIDSTOCK.CurrentRow.Index).Value.ToString
                TXTLOTNO.Text = GRIDSTOCK.Item(GLOTNO.Index, GRIDSTOCK.CurrentRow.Index).Value.ToString
                TXTREELNO.Text = GRIDSTOCK.Item(GREELNO.Index, GRIDSTOCK.CurrentRow.Index).Value.ToString
                TXTGSM.Text = GRIDSTOCK.Item(GGSM.Index, GRIDSTOCK.CurrentRow.Index).Value.ToString
                TXTGSMDETAILS.Text = GRIDSTOCK.Item(GGSMDETAILS.Index, GRIDSTOCK.CurrentRow.Index).Value.ToString
                TXTSIZE.Text = GRIDSTOCK.Item(GSIZE.Index, GRIDSTOCK.CurrentRow.Index).Value.ToString
                CMBNAME.Text = GRIDSTOCK.Item(GNAME.Index, GRIDSTOCK.CurrentRow.Index).Value.ToString
                CMBGODOWN.Text = GRIDSTOCK.Item(GGODOWN.Index, GRIDSTOCK.CurrentRow.Index).Value.ToString
                TXTQTY.Text = GRIDSTOCK.Item(GQTY.Index, GRIDSTOCK.CurrentRow.Index).Value.ToString
                TXTFINALQTY.Text = GRIDSTOCK.Item(GFINALQTY.Index, GRIDSTOCK.CurrentRow.Index).Value.ToString
                CMBUNIT.Text = GRIDSTOCK.Item(Gunit.Index, GRIDSTOCK.CurrentRow.Index).Value.ToString
                TXTREMARKS.Text = GRIDSTOCK.Item(GGRIDREMARKS.Index, GRIDSTOCK.CurrentRow.Index).Value.ToString
                TXTBARCODE.Text = GRIDSTOCK.Item(GBARCODE.Index, GRIDSTOCK.CurrentRow.Index).Value.ToString

                TEMPROW = GRIDSTOCK.CurrentRow.Index
                txtsrno.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridSO_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GRIDSTOCK.CellDoubleClick
        EDITROW()
    End Sub

    Private Sub cmbname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBNAME.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors' and LEDGERS.acc_cmpid = " & CmpId & " and LEDGERS.acc_LOCATIONid = " & Locationid & " and LEDGERS.acc_YEARid = " & YearId
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPNAME <> "" Then CMBNAME.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, CMBCODE, e, Me, txtadd, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors'", "Sundry Creditors", "ACCOUNTS")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbname_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            If CMBNAME.Text.Trim = "" Then FILLNAME(CMBNAME, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors'")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbMERCHANT_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBITEMNAME.Enter
        Try
            If CMBITEMNAME.Text.Trim = "" Then FILLITEMNAME(CMBITEMNAME, " AND ITEMMASTER.ITEM_FRMSTRING IN ('MERCHANT')")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbMERCHANT_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBITEMNAME.Validating
        Try
            If CMBITEMNAME.Text.Trim <> "" Then ITEMVALIDATE(CMBITEMNAME, e, Me, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT' ", "MERCHANT")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub fillcmb()
        Try

            If CMBITEMNAME.Text.Trim = "" Then FILLITEMNAME(CMBITEMNAME, " AND ITEMMASTER.ITEM_FRMSTRING IN ('MERCHANT')")
            FILLNAME(CMBNAME, EDIT, " and GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors'")
            fillGODOWN(CMBGODOWN, EDIT)
            FILLUNIT(CMBUNIT)
            If CMBUNIT.Text.Trim = "" Then FILLUNIT(CMBUNIT)

            CMBUNIT.Text = "Pcs"

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub FILLGRID()

        GRIDSTOCK.Enabled = True

        If GRIDDOUBLECLICK = False Then
            GRIDSTOCK.Rows.Add(Val(txtsrno.Text.Trim), Val(TXTNO.Text.Trim), CMBITEMNAME.Text.Trim, TXTLOTNO.Text.Trim, TXTREELNO.Text.Trim, Val(TXTGSM.Text.Trim), TXTGSMDETAILS.Text.Trim, Val(TXTSIZE.Text.Trim), CMBNAME.Text.Trim, CMBGODOWN.Text, Val(TXTQTY.Text.Trim), Val(TXTFINALQTY.Text.Trim), CMBUNIT.Text.Trim, CMBREADYFINALQC.Text.Trim, TXTREMARKS.Text.Trim, TXTBARCODE.Text.Trim)
            getsrno(GRIDSTOCK)
            GRIDSTOCK.FirstDisplayedScrollingRowIndex = GRIDSTOCK.RowCount - 1
        ElseIf GRIDDOUBLECLICK = True Then
            GRIDSTOCK.Item(gsrno.Index, TEMPROW).Value = Val(txtsrno.Text.Trim)
            GRIDSTOCK.Item(GNO.Index, TEMPROW).Value = Val(TXTNO.Text.Trim)
            GRIDSTOCK.Item(GITEMNAME.Index, TEMPROW).Value = CMBITEMNAME.Text.Trim
            GRIDSTOCK.Item(GLOTNO.Index, TEMPROW).Value = TXTLOTNO.Text.Trim
            GRIDSTOCK.Item(GREELNO.Index, TEMPROW).Value = TXTREELNO.Text.Trim
            GRIDSTOCK.Item(GGSM.Index, TEMPROW).Value = Val(TXTGSM.Text.Trim)
            GRIDSTOCK.Item(GGSMDETAILS.Index, TEMPROW).Value = TXTGSMDETAILS.Text.Trim
            GRIDSTOCK.Item(GSIZE.Index, TEMPROW).Value = Val(TXTSIZE.Text.Trim)
            GRIDSTOCK.Item(GNAME.Index, TEMPROW).Value = CMBNAME.Text.Trim
            GRIDSTOCK.Item(GGODOWN.Index, TEMPROW).Value = CMBGODOWN.Text.Trim
            GRIDSTOCK.Item(GQTY.Index, TEMPROW).Value = Val(TXTQTY.Text.Trim)
            GRIDSTOCK.Item(GFINALQTY.Index, TEMPROW).Value = Val(TXTFINALQTY.Text.Trim)
            GRIDSTOCK.Item(Gunit.Index, TEMPROW).Value = CMBUNIT.Text.Trim
            GRIDSTOCK.Item(GREADYFINALQC.Index, TEMPROW).Value = CMBREADYFINALQC.Text.Trim
            GRIDSTOCK.Item(GGRIDREMARKS.Index, TEMPROW).Value = TXTREMARKS.Text.Trim
            GRIDSTOCK.Item(GBARCODE.Index, TEMPROW).Value = TXTBARCODE.Text.Trim
            GRIDDOUBLECLICK = False
        End If

        txtsrno.Text = GRIDSTOCK.RowCount + 1
        TXTQTY.Clear()
        TXTFINALQTY.Clear()
        TXTREMARKS.Clear()
        TXTGSMDETAILS.Clear()
        TXTNO.Clear()
        CMBITEMNAME.Focus()
        TXTBARCODE.Clear()
        TOTAL()

    End Sub

    Private Sub OpeningStock_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf e.KeyCode = Keys.F5 Then
            GRIDSTOCK.Focus()
        ElseIf e.KeyCode = Keys.F12 And GRIDSTOCK.RowCount > 0 Then
            If GRIDSTOCK.SelectedRows.Count = 0 Then Exit Sub
            Dim TEMPROWINDEX As Integer = GRIDSTOCK.CurrentRow.Index
            txtsrno.Text = GRIDSTOCK.Item(gsrno.Index, TEMPROWINDEX).Value
            TXTNO.Text = GRIDSTOCK.Item(GNO.Index, TEMPROWINDEX).Value
            CMBITEMNAME.Text = GRIDSTOCK.Item(GITEMNAME.Index, TEMPROWINDEX).Value
            TXTLOTNO.Text = GRIDSTOCK.Item(GLOTNO.Index, TEMPROWINDEX).Value
            TXTREELNO.Text = GRIDSTOCK.Item(GREELNO.Index, TEMPROWINDEX).Value
            TXTGSM.Text = Val(GRIDSTOCK.Item(GGSM.Index, TEMPROWINDEX).Value)
            TXTGSMDETAILS.Text = GRIDSTOCK.Item(GGSMDETAILS.Index, TEMPROWINDEX).Value
            TXTSIZE.Text = Val(GRIDSTOCK.Item(GSIZE.Index, TEMPROWINDEX).Value)
            CMBNAME.Text = GRIDSTOCK.Item(GNAME.Index, TEMPROWINDEX).Value
            CMBGODOWN.Text = GRIDSTOCK.Item(GGODOWN.Index, TEMPROWINDEX).Value
            TXTQTY.Text = Val(GRIDSTOCK.Item(GQTY.Index, TEMPROWINDEX).Value)
            TXTFINALQTY.Text = Val(GRIDSTOCK.Item(GFINALQTY.Index, TEMPROWINDEX).Value)
            CMBUNIT.Text = GRIDSTOCK.Item(Gunit.Index, TEMPROWINDEX).Value
            CMBREADYFINALQC.Text = GRIDSTOCK.Item(GREADYFINALQC.Index, TEMPROWINDEX).Value
            TXTREMARKS.Text = GRIDSTOCK.Item(GGRIDREMARKS.Index, TEMPROWINDEX).Value
            TXTBARCODE.Text = GRIDSTOCK.Item(GBARCODE.Index, TEMPROWINDEX).Value

            CMBITEMNAME.Focus()

        ElseIf e.KeyCode = Keys.Oemcomma Then
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub CMBGODOWN_ENTER(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBGODOWN.Enter
        Try
            If CMBGODOWN.Text.Trim = "" Then fillGODOWN(CMBGODOWN, EDIT)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBGODOWN_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBGODOWN.Validating
        Try
            If CMBGODOWN.Text.Trim <> "" Then GODOWNVALIDATE(CMBGODOWN, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
    Private Sub OpeningStock_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'OPENING'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)


            fillcmb()
            CMBREADYFINALQC.Text = "NO"
            CMBITEMNAME.SelectedIndex = 0
            If USERGODOWN <> "" Then CMBGODOWN.Text = USERGODOWN Else CMBGODOWN.Text = ""
            openingdate.Value = AccFrom.Date

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim OBJCMN As New ClsCommon
            Dim dttable As DataTable = OBJCMN.Execute_Any_String(" SELECT  STOCKMASTER.SM_DATE AS DATE, ISNULL(STOCKMASTER.SM_GRIDSRNO, 0) AS GRIDSRNO, ISNULL(STOCKMASTER.SM_NO, 0) AS NO, ISNULL(STOCKMASTER.SM_LOTNO, '') AS LOTNO, ISNULL(STOCKMASTER.SM_REELNO, '') AS REELNO, ISNULL(STOCKMASTER.SM_GSM,0) AS GSM, ISNULL(STOCKMASTER.SM_GSMDETAILS,0) AS GSMDETAILS, ISNULL(STOCKMASTER.SM_SIZE,0) AS SIZE, ISNULL(STOCKMASTER.SM_QTY, 0) AS QTY, ISNULL(STOCKMASTER.SM_REMARKS, '') AS REMARKS, ISNULL(ITEMMASTER.ITEM_NAME, '') AS ITEMNAME, ISNULL(GODOWNMASTER.GODOWN_name, '') AS GODOWN, ISNULL(LEDGERS.Acc_cmpname, '') AS PARTYNAME, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT, ISNULL(STOCKMASTER.SM_BARCODE,'') AS BARCODE , ISNULL(STOCKMASTER.SM_FINALQTY, 0) AS FINALQTY, ISNULL(STOCKMASTER.SM_DONE, 0) AS DONE , ISNULL(STOCKMASTER.SM_OUTQTY, 0) AS OUTQTY , ISNULL(STOCKMASTER.SM_READYFINALQC,'') AS READYFINALQC  FROM STOCKMASTER LEFT OUTER JOIN UNITMASTER ON STOCKMASTER.SM_UNITID = UNITMASTER.unit_id LEFT OUTER JOIN LEDGERS ON STOCKMASTER.SM_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN GODOWNMASTER ON STOCKMASTER.SM_GODOWNID = GODOWNMASTER.GODOWN_id LEFT OUTER JOIN ITEMMASTER ON STOCKMASTER.SM_ITEMID = ITEMMASTER.item_id  WHERE STOCKMASTER.SM_YEARID = " & YearId & " ORDER BY SM_NO", "", "")
            If dttable.Rows.Count > 0 Then
                GRIDSTOCK.RowCount = 0
                For Each DR As DataRow In dttable.Rows
                    openingdate.Value = Format(Convert.ToDateTime(DR("DATE")).Date, "dd/MM/yyyy")
                    GRIDSTOCK.Rows.Add(Val(DR("GRIDSRNO")), DR("NO"), DR("ITEMNAME"), DR("LOTNO"), DR("REELNO"), Val(DR("GSM")), DR("GSMDETAILS"), Val(DR("SIZE")), DR("PARTYNAME"), DR("GODOWN"), Format(Val(DR("QTY")), "0.00"), Format(Val(DR("FINALQTY")), "0.00"), DR("UNIT"), DR("READYFINALQC"), DR("REMARKS"), DR("BARCODE"), DR("DONE"), Val(DR("OUTQTY")))
                    If Convert.ToBoolean(DR("DONE")) = True Or Val(DR("OUTQTY")) > 0 Then GRIDSTOCK.Rows(GRIDSTOCK.RowCount - 1).DefaultCellStyle.BackColor = Color.Yellow
                Next
                getsrno(GRIDSTOCK)
                GRIDSTOCK.FirstDisplayedScrollingRowIndex = GRIDSTOCK.RowCount - 1
                TOTAL()
            End If

            If GRIDSTOCK.RowCount > 0 Then
                txtsrno.Text = Val(GRIDSTOCK.Rows(GRIDSTOCK.RowCount - 1).Cells(0).Value) + 1
            Else
                txtsrno.Text = 1
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmbunit_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBUNIT.Enter
        Try
            If CMBUNIT.Text.Trim = "" Then FILLUNIT(CMBUNIT)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbunit_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBUNIT.Validating
        Try
            If CMBUNIT.Text.Trim <> "" Then unitvalidate(CMBUNIT, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub SAVE()
        Try
            If ISLOCKYEAR = True Then
                MsgBox("Unable to Make changes, Year is Locked", MsgBoxStyle.Critical)
                Exit Sub
            End If


            Dim ALPARAVAL As New ArrayList
            Dim OBJSM As New ClsStockMaster

            ALPARAVAL.Add(openingdate.Value.Date)
            ALPARAVAL.Add(Val(txtsrno.Text.Trim))
            ALPARAVAL.Add(CMBITEMNAME.Text.Trim)
            ALPARAVAL.Add(TXTLOTNO.Text.Trim)
            ALPARAVAL.Add(TXTREELNO.Text.Trim)
            ALPARAVAL.Add(Val(TXTGSM.Text.Trim))
            ALPARAVAL.Add(TXTGSMDETAILS.Text.Trim)
            ALPARAVAL.Add(Val(TXTSIZE.Text.Trim))
            ALPARAVAL.Add(CMBNAME.Text.Trim)
            ALPARAVAL.Add(CMBGODOWN.Text.Trim)
            ALPARAVAL.Add(Val(TXTQTY.Text.Trim))
            ALPARAVAL.Add(Val(TXTFINALQTY.Text.Trim))
            ALPARAVAL.Add(CMBUNIT.Text.Trim)
            If CMBREADYFINALQC.Text.Trim = "NO" Then
                ALPARAVAL.Add(0)
            Else
                ALPARAVAL.Add(1)
            End If
            ALPARAVAL.Add(TXTREMARKS.Text.Trim)
            ALPARAVAL.Add(TXTBARCODE.Text.Trim)
            ALPARAVAL.Add(0)
            ALPARAVAL.Add(0)  'FOR OUTQTY
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Locationid)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)
            ALPARAVAL.Add(0)


            OBJSM.alParaval = ALPARAVAL
            If GRIDDOUBLECLICK = False Then

                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                Dim DT As DataTable = OBJSM.SAVE()
                If DT.Rows.Count > 0 Then TXTNO.Text = DT.Rows(0).Item(0)
                BARCODE()
            Else

                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                ALPARAVAL.Add(Val(TXTNO.Text.Trim))
                Dim INTRES As Integer = OBJSM.UPDATE()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTQTY_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTQTY.KeyPress, TXTGSM.KeyPress
        Try
            numdotkeypress(e, sender, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridstock_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GRIDSTOCK.KeyDown
        Try
            If e.KeyCode = Keys.Delete And GRIDSTOCK.RowCount > 0 Then

                If ISLOCKYEAR = True Then
                    MsgBox("Unable to Make changes, Year is Locked", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                If USERDELETE = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                If GRIDDOUBLECLICK = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If

                If GRIDSTOCK.Rows(GRIDSTOCK.CurrentRow.Index).DefaultCellStyle.BackColor = Color.Yellow Then
                    MessageBox.Show("Row Locked, You Cannot Delete This Row")
                    Exit Sub
                End If

                If Val(GRIDSTOCK.Rows(GRIDSTOCK.CurrentRow.Index).Cells(GOUTQTY.Index).Value) > 0 Then
                    MessageBox.Show("Row Locked, You Cannot Delete This Row")
                    Exit Sub
                End If

                Dim TEMPMSG As Integer = MsgBox("Wish To Delete?", MsgBoxStyle.YesNo)
                If TEMPMSG = vbNo Then Exit Sub

                'DELETE FROM STOCKMASTER
                Dim OBJSM As New ClsStockMaster
                Dim ALPARAVAL As New ArrayList
                ALPARAVAL.Add(GRIDSTOCK.Rows(GRIDSTOCK.CurrentRow.Index).Cells(GNO.Index).Value)
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(YearId)

                OBJSM.alParaval = ALPARAVAL
                Dim INTRES As Integer = OBJSM.DELETE()

                GRIDSTOCK.Rows.RemoveAt(GRIDSTOCK.CurrentRow.Index)
                getsrno(GRIDSTOCK)
            ElseIf e.KeyCode = Keys.F5 Then
                EDITROW()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbmerchant_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBITEMNAME.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJItem As New SelectItem
                OBJItem.FRMSTRING = "MERCHANT"
                OBJItem.STRSEARCH = " and ITEM_cmpid = " & CmpId & " and ITEM_LOCATIONid = " & Locationid & " and ITEM_YEARid = " & YearId
                OBJItem.ShowDialog()
                If OBJItem.TEMPNAME <> "" Then CMBITEMNAME.Text = OBJItem.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbgodown_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBGODOWN.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJGODOWN As New SelectGodown
                OBJGODOWN.FRMSTRING = "GODOWN"
                OBJGODOWN.ShowDialog()
                If OBJGODOWN.TEMPNAME <> "" Then CMBGODOWN.Text = OBJGODOWN.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTREMARKS_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTREMARKS.Validating
        Try
            If CMBITEMNAME.Text.Trim <> "" And Val(TXTQTY.Text.Trim) > 0 And CMBUNIT.Text.Trim <> "" And CMBGODOWN.Text.Trim <> "" Then
                SAVE()
                FILLGRID()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub TOTAL()
        Try
            LBLTOTALQTY.Text = 0.00
            If GRIDSTOCK.RowCount > 0 Then
                For Each row As DataGridViewRow In GRIDSTOCK.Rows
                    If Val(row.Cells(GQTY.Index).EditedFormattedValue) > 0 Then LBLTOTALQTY.Text = Format(Val(LBLTOTALQTY.Text) + Val(row.Cells(GQTY.Index).EditedFormattedValue), "0.00")
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTSIZE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTSIZE.KeyPress
        numdotkeypress(e, sender, Me)
    End Sub

    Private Sub TXTFINALQTY_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTFINALQTY.KeyPress
        Try
            numdotkeypress(e, sender, Me)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub BARCODE()
        Try
            'GET BARCODE NO FROM DATABASE
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.SEARCH(" SM_BARCODE AS BARCODE ", "", " STOCKMASTER ", " AND SM_NO = " & Val(TXTNO.Text.Trim) & " AND SM_CMPID = " & CmpId & " AND SM_LOCATIONID = " & Locationid & " AND SM_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then TXTBARCODE.Text = DT.Rows(0).Item("BARCODE")
            ' PRINTBARCODE()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTQTY_Validated(sender As Object, e As EventArgs) Handles TXTQTY.Validated
        Try
            If Val(TXTQTY.Text.Trim) > 0 And Val(TXTFINALQTY.Text.Trim) = 0 Then TXTFINALQTY.Text = Val(TXTQTY.Text.Trim)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTREELNO_Validating(sender As Object, e As CancelEventArgs) Handles TXTREELNO.Validating
        Try
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.SEARCH(" STOCKMASTER.SM_REELNO AS REELNO, ITEMMASTER.ITEM_NAME AS ITEMNAME ", "", " STOCKMASTER LEFT OUTER JOIN ITEMMASTER ON STOCKMASTER.SM_ITEMID = ITEMMASTER.item_id ", " AND STOCKMASTER.SM_REELNO ='" & TXTREELNO.Text.Trim & "' AND ITEMMASTER.ITEM_NAME = '" & CMBITEMNAME.Text & "' AND SM_CMPID = " & CmpId & " AND SM_LOCATIONID = " & Locationid & " AND SM_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                If MsgBox("ReelNo is already present Wish to Proceed?", MsgBoxStyle.YesNo) = vbNo Then
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Private Sub TXTREELNO_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TXTREELNO.KeyPress
    '    numkeypress(e, sender, Me)
    'End Sub
End Class