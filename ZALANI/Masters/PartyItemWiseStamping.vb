﻿Imports BL

Public Class PartyItemWiseStamping

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim GRIDDOUBLECLICK As Boolean
    Dim TEMPROW As Integer
    Public tempItemName, tempItemCODE, frmstring As String
    Public EDIT As Boolean          'used for editing

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True

        Dim OBJCMN As New ClsCommon
        Dim DT As New DataTable

        'FOR RAJKRIPA PARTY NAME IS NOT MANDATE
        If ClientName = "RAJKRIPA" Then
            DT = OBJCMN.SEARCH(" ISNULL(PARTYITEMWISECHART.PAR_NO,0) AS ID ", "", " PARTYITEMWISECHART LEFT OUTER JOIN LEDGERS ON PARTYITEMWISECHART.PAR_LEDGERID = LEDGERS.Acc_id INNER JOIN ITEMMASTER ON PARTYITEMWISECHART.PAR_ITEMID = ITEMMASTER.item_id ", " AND ITEMMASTER.ITEM_NAME = '" & CMBITEM.Text.Trim & "' AND PAR_YEARID = " & YearId & " AND PAR_CMPID = " & CmpId)
            If DT.Rows.Count > 0 Then
                If GRIDDOUBLECLICK = False Or (GRIDDOUBLECLICK = True And Val(TXTNO.Text) <> Val(DT.Rows(0).Item(0))) Then
                    EP.SetError(CMBNAME, "Stamping for This Item Already Exist in Grid below")
                    bln = False
                End If
            End If


        Else
            DT = OBJCMN.SEARCH(" ISNULL(PARTYITEMWISECHART.PAR_NO,0) AS ID ", "", " PARTYITEMWISECHART LEFT OUTER JOIN LEDGERS ON PARTYITEMWISECHART.PAR_LEDGERID = LEDGERS.Acc_id INNER JOIN ITEMMASTER ON PARTYITEMWISECHART.PAR_ITEMID = ITEMMASTER.item_id ", " AND ledgers.acc_cmpname = '" & CMBNAME.Text.Trim & "' AND ITEMMASTER.ITEM_NAME = '" & CMBITEM.Text.Trim & "'  AND PAR_YEARID = " & YearId & " AND PAR_CMPID = " & CmpId)
            If DT.Rows.Count > 0 Then
                If GRIDDOUBLECLICK = False Or (GRIDDOUBLECLICK = True And Val(TXTNO.Text) <> Val(DT.Rows(0).Item(0))) Then
                    EP.SetError(CMBNAME, "Stamping for This party & Item Already Exist in Grid below")
                    bln = False
                End If
            End If

            If CMBNAME.Text.Trim.Length = 0 Then
                EP.SetError(CMBNAME, "Select Party")
                bln = False
            End If
        End If


        If CMBITEM.Text.Trim.Length = 0 Then
            EP.SetError(CMBITEM, "Select Item")
            bln = False
        End If

        Return bln
    End Function

    Sub FILLGRID()
        Try
            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.SEARCH(" ISNULL(PARTYITEMWISECHART.PAR_NO, 0) AS ID, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(ITEMMASTER.ITEM_NAME, '') AS ITEM, ISNULL(PARTYITEMWISECHART.PAR_STAMPING, '') AS STAMPING", "", " PARTYITEMWISECHART LEFT OUTER JOIN LEDGERS ON PARTYITEMWISECHART.PAR_LEDGERID = LEDGERS.Acc_id INNER JOIN ITEMMASTER ON PARTYITEMWISECHART.PAR_ITEMID = ITEMMASTER.item_id ", " AND PAR_YEARID = " & YearId & " AND PAR_CMPID = " & CmpId)

            gridbilldetails.DataSource = DT
            CMBNAME.Text = ""
            CMBITEM.Text = ""
            TXTSTAMPING.Clear()
            TXTNO.Clear()
            EP.Clear()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub KarigarWiseLabour_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemPipe Then
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Sub FILLCMB()
        Try
            fillname(CMBNAME, EDIT, " AND GROUPMASTER.GROUP_SECONDARY = 'SUNDRY DEBTORS' AND ACC_TYPE = 'ACCOUNTS'")
            fillitemname(CMBITEM, " AND ITEMMASTER.ITEM_FRMSTRING = 'MERCHANT'")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub CLEAR()
        Try
            EP.Clear()
            TXTNO.Clear()
            CMBNAME.Text = ""
            CMBITEM.Text = ""
            TXTSTAMPING.Clear()
            gridbilldetails.DataSource = Nothing

            GRIDDOUBLECLICK = False
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub KarigarWiseLabour_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ACCOUNTS MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)


            Dim OBJCMN As New ClsCommon
            Dim dttable As New DataTable

            FILLCMB()
            CLEAR()
            FILLGRID()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Private Sub TXTSTAMPING_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTSTAMPING.Validated
        Try
            If CMBITEM.Text.Trim <> "" And TXTSTAMPING.Text.Trim.Length > 0 Then
                If Not errorvalid() Then
                    MsgBox("Stamping for This Party & Item Already Exist in Grid below", MsgBoxStyle.Critical)
                    CMBNAME.Focus()
                    Exit Sub
                End If
                SAVE()
            End If
            CMBNAME.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBNAME.Enter
        Try
            fillname(CMBNAME, EDIT, "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CMBNAME.KeyDown
        Try
            If e.KeyCode = Keys.Oemcomma Then e.SuppressKeyPress = True
            If e.KeyCode = Keys.OemQuotes Then e.SuppressKeyPress = True

            If e.KeyCode = Keys.F1 Then
                Dim OBJLEDGER As New SelectLedger
                OBJLEDGER.STRSEARCH = " AND GROUPMASTER.GROUP_SECONDARY ='SUNDRY DEBTORS' AND LEDGERS.ACC_TYPE = 'ACCOUNTS'"
                OBJLEDGER.ShowDialog()
                If OBJLEDGER.TEMPCODE <> "" Then CMBCODE.Text = OBJLEDGER.TEMPCODE
                If OBJLEDGER.TEMPNAME <> "" Then CMBNAME.Text = OBJLEDGER.TEMPNAME
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMBNAME_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBNAME.Validating
        Try
            If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, CMBCODE, e, Me, TXTADD, "", "", "", "")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbitem_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBITEM.Enter
        Try
            If CMBNAME.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("ITEM_NAME", "", " ItemMaster ", " and ITEM_FRMSTRING = '" & frmstring & "' and Item_cmpid = " & CmpId & " and Item_locationid = " & Locationid & " and Item_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "ITEM_NAME"
                    CMBNAME.DataSource = dt
                    CMBNAME.DisplayMember = "ITEM_NAME"
                    CMBNAME.Text = ""
                End If
                CMBNAME.SelectAll()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmbiteM_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles CMBITEM.Validating
        If CMBITEM.Text.Trim <> "" Then
            uppercase(CMBNAME)
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable
            If (EDIT = False) Or (EDIT = True And LCase(CMBNAME.Text) <> LCase(tempItemName)) Then
                dt = objclscommon.search("ITEM_NAME", "", "ItemMaster", " and ITEM_NAME = '" & CMBNAME.Text.Trim & "'  And item_cmpid = " & CmpId & " And item_locationid = " & Locationid & " And item_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    MsgBox("Item Name Already Exists", MsgBoxStyle.Critical, "ZALANI")
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub CMDCLEAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDCLEAR.Click
        CLEAR()
        FILLGRID()
        CMBNAME.Focus()
    End Sub

    Sub SAVE()
        Try

            If USERADD = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim ALPARAVAL As New ArrayList
            Dim OBJCONFIG As New ClsPartyItemWiseChart

            ALPARAVAL.Add(Val(TXTNO.Text.Trim))
            ALPARAVAL.Add(CMBNAME.Text.Trim)
            ALPARAVAL.Add(CMBITEM.Text.Trim)
            ALPARAVAL.Add(TXTSTAMPING.Text.Trim)
            ALPARAVAL.Add(CmpId)
            ALPARAVAL.Add(Userid)
            ALPARAVAL.Add(YearId)


            OBJCONFIG.alParaval = ALPARAVAL

            Dim INT As Integer = OBJCONFIG.SAVE()
            FILLGRID()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDDELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDDELETE.Click

        Try
            If USERDELETE = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If GRIDDOUBLECLICK = True Then
                MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                Exit Sub
            End If

            Dim TEMPMSG As Integer = MsgBox("Wish To Delete?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbNo Then Exit Sub


            'DELETE FROM TABLE
            Dim OBJSM As New ClsPartyItemWiseChart
            Dim ALPARAVAL As New ArrayList
            ALPARAVAL.Add(gridbill.GetFocusedRowCellValue("ID"))
            ALPARAVAL.Add(Userid)


            OBJSM.alParaval = ALPARAVAL
            Dim INTRES As Integer = OBJSM.DELETE()
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        EDITROW()

    End Sub

    Sub EDITROW()
        Try
            If gridbill.GetFocusedRowCellValue("ID") > 0 Then
                GRIDDOUBLECLICK = True
                TXTNO.Text = gridbill.GetFocusedRowCellValue("ID")
                CMBNAME.Text = gridbill.GetFocusedRowCellValue("NAME")
                CMBITEM.Text = gridbill.GetFocusedRowCellValue("ITEM")
                TXTSTAMPING.Text = gridbill.GetFocusedRowCellValue("STAMPING")
                CMBNAME.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gridbill.KeyDown
        Try
            If e.KeyCode = Keys.Delete Then
                Call CMDDELETE_Click(sender, e)
            ElseIf e.KeyCode = Keys.F5 Then
                EDITROW()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class