
Imports BL
Imports DevExpress.XtraGrid.Views.Grid

Public Class PurchaseOrderClose
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public FRMSTRING As String = ""


    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub PurchaseOrderClose_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            ElseIf e.KeyCode = Keys.Space And e.Control = True Then
                'SELECT ALL DATA
                For i As Integer = 0 To gridbill.RowCount - 1
                    Dim dtrow As DataRow = gridbill.GetDataRow(i)
                    dtrow("CLOSED") = Not Convert.ToBoolean(dtrow("CLOSED"))
                Next
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub PurchaseOrderClose_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'SHORTCLOSE'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            fillgrid("")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal TEMPCONDITION)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As New DataTable
            If FRMSTRING = "PURCHASE" Then
                If RBPENDING.Checked = True Then
                    dt = objclsCMST.search("*", "", " (SELECT  CAST(0 AS BIT) AS CLOSED, ISNULL(ALLPURCHASEORDER.PO_NO, 0) AS PONO, ISNULL(ALLPURCHASEORDER.PO_DELIVERY, '') AS DELIVERY, ISNULL(ALLPURCHASEORDER.PO_ORDERREFNO, '') AS ORDERREFNO, ISNULL(ALLPURCHASEORDER.PO_PROFORMANO, 0) AS PROFORMANO, ISNULL(ALLPURCHASEORDER.PO_PROFORMATYPE, '') AS PROFORMATYPE, ISNULL(ALLPURCHASEORDER_DESC.PO_GRIDSRNO, 0) AS GRIDSRNO, ISNULL(ALLPURCHASEORDER_DESC.PO_QTY, 0) AS QTY, ISNULL(ALLPURCHASEORDER_DESC.PO_QTYUNITID, 0) AS UNIT, ISNULL(ALLPURCHASEORDER_DESC.PO_RATE, 0) AS RATE, ISNULL(ALLPURCHASEORDER_DESC.PO_AMT, 0) AS AMT, ISNULL(ALLPURCHASEORDER_DESC.PO_RECDQTY, 0) AS RECDQTY, ISNULL(ALLPURCHASEORDER_DESC.PO_DONE, 0) AS DONE, ALLPURCHASEORDER.PO_DATE AS DATE, ISNULL(ALLPURCHASEORDER_DESC.TYPE, '') AS TYPE, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(ITEMMASTER.ITEM_NAME, '') AS ITEMNAME FROM ITEMMASTER RIGHT OUTER JOIN ALLPURCHASEORDER_DESC ON ITEMMASTER.item_id = ALLPURCHASEORDER_DESC.PO_QUALITYID RIGHT OUTER JOIN ALLPURCHASEORDER LEFT OUTER JOIN LEDGERS ON ALLPURCHASEORDER.PO_LEDGERID = LEDGERS.Acc_id ON ALLPURCHASEORDER_DESC.PO_NO = ALLPURCHASEORDER.PO_NO AND ALLPURCHASEORDER_DESC.PO_YEARID = ALLPURCHASEORDER.PO_YEARID WHERE ALLPURCHASEORDER_DESC.PO_CLOSED = 'FALSE' AND  ALLPURCHASEORDER.PO_YEARID =  " & YearId & "  AND ROUND(ALLPURCHASEORDER_DESC.PO_QTY - ALLPURCHASEORDER_DESC.PO_RECDQTY,0) > 0" & ") AS T ", " ORDER BY T.DATE, T.PONO, T.GRIDSRNO")
                Else
                    dt = objclsCMST.search("*", "", " (SELECT  CAST(0 AS BIT) AS CLOSED, ISNULL(ALLPURCHASEORDER.PO_NO, 0) AS PONO, ISNULL(ALLPURCHASEORDER.PO_DELIVERY, '') AS DELIVERY, ISNULL(ALLPURCHASEORDER.PO_ORDERREFNO, '') AS ORDERREFNO, ISNULL(ALLPURCHASEORDER.PO_PROFORMANO, 0) AS PROFORMANO, ISNULL(ALLPURCHASEORDER.PO_PROFORMATYPE, '') AS PROFORMATYPE, ISNULL(ALLPURCHASEORDER_DESC.PO_GRIDSRNO, 0) AS GRIDSRNO, ISNULL(ALLPURCHASEORDER_DESC.PO_QTY, 0) AS QTY, ISNULL(ALLPURCHASEORDER_DESC.PO_QTYUNITID, 0) AS UNIT, ISNULL(ALLPURCHASEORDER_DESC.PO_RATE, 0) AS RATE, ISNULL(ALLPURCHASEORDER_DESC.PO_AMT, 0) AS AMT, ISNULL(ALLPURCHASEORDER_DESC.PO_RECDQTY, 0) AS RECDQTY, ISNULL(ALLPURCHASEORDER_DESC.PO_DONE, 0) AS DONE, ALLPURCHASEORDER.PO_DATE AS DATE, ISNULL(ALLPURCHASEORDER_DESC.TYPE, '') AS TYPE, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(ITEMMASTER.ITEM_NAME, '') AS ITEMNAME FROM ITEMMASTER RIGHT OUTER JOIN ALLPURCHASEORDER_DESC ON ITEMMASTER.item_id = ALLPURCHASEORDER_DESC.PO_QUALITYID RIGHT OUTER JOIN ALLPURCHASEORDER LEFT OUTER JOIN LEDGERS ON ALLPURCHASEORDER.PO_LEDGERID = LEDGERS.Acc_id ON ALLPURCHASEORDER_DESC.PO_NO = ALLPURCHASEORDER.PO_NO AND ALLPURCHASEORDER_DESC.PO_YEARID = ALLPURCHASEORDER.PO_YEARID WHERE ALLPURCHASEORDER_DESC.PO_CLOSED = 'TRUE' AND  ALLPURCHASEORDER.PO_YEARID =  " & YearId & "  AND ROUND(ALLPURCHASEORDER_DESC.PO_QTY - ALLPURCHASEORDER_DESC.PO_RECDQTY,0) > 0" & ") AS T ", " ORDER BY T.DATE, T.PONO, T.GRIDSRNO")
                End If
            Else
                If RBPENDING.Checked = True Then
                    dt = objclsCMST.search("*", "", " (SELECT  CAST(0 AS BIT) AS CLOSED,ISNULL(ALLSALEORDER.SO_NO, 0) AS PONO, ALLSALEORDER.SO_DATE AS DATE, ISNULL(ALLSALEORDER.TYPE, '') AS TYPE, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(ALLSALEORDER_DESC.SO_GRIDSRNO, 0) AS GRIDSRNO, ROUND(ALLSALEORDER_DESC.SO_QTY - (ALLSALEORDER_DESC.SO_JOQTYPE + ALLSALEORDER_DESC.SO_JOQTYLAMINATION + ALLSALEORDER_DESC.SO_JOQTYSLITTING),0) AS QTY, ISNULL(ALLSALEORDER_DESC.SO_RATE, 0) AS RATE, ISNULL(ALLSALEORDER_DESC.SO_AMOUNT, 0) AS AMT, ISNULL(ALLSALEORDER_DESC.SO_JOQTYPE, 0) AS QTYPE, ISNULL(ALLSALEORDER_DESC.SO_JOQTYLAMINATION, 0) AS QTYLAMINATION, ISNULL(ALLSALEORDER_DESC.SO_JOQTYSLITTING, 0) AS QTYSLITING, ISNULL(ALLSALEORDER_DESC.SO_OUTQTY, 0) AS RECDQTY, ISNULL(ITEMMASTER.ITEM_NAME, '') AS ITEMNAME, ISNULL(FOILITEMMASTER.ITEM_NAME, '') AS FOILITEM FROM  LEDGERS RIGHT OUTER JOIN ITEMMASTER RIGHT OUTER JOIN ITEMMASTER AS FOILITEMMASTER RIGHT OUTER JOIN ALLSALEORDER_DESC ON FOILITEMMASTER.item_id = ALLSALEORDER_DESC.SO_FOILQUALITYID ON ITEMMASTER.item_id = ALLSALEORDER_DESC.SO_FINISHEDQUALITYID RIGHT OUTER JOIN ALLSALEORDER ON ALLSALEORDER_DESC.SO_NO = ALLSALEORDER.SO_NO AND ALLSALEORDER_DESC.SO_YEARID = ALLSALEORDER.SO_YEARID ON LEDGERS.Acc_id = ALLSALEORDER.SO_LEDGERID WHERE ALLSALEORDER_DESC.SO_CLOSED = 'FALSE' AND  ALLSALEORDER.SO_YEARID = " & YearId & " AND  ROUND(ALLSALEORDER_DESC.SO_QTY - (ALLSALEORDER_DESC.SO_JOQTYPE + ALLSALEORDER_DESC.SO_JOQTYLAMINATION + ALLSALEORDER_DESC.SO_JOQTYSLITTING),0) >0 " & ") AS T ", " ORDER BY T.DATE, T.PONO, T.GRIDSRNO")
                Else
                    dt = objclsCMST.search("*", "", " (SELECT  CAST(0 AS BIT) AS CLOSED,ISNULL(ALLSALEORDER.SO_NO, 0) AS PONO, ALLSALEORDER.SO_DATE AS DATE, ISNULL(ALLSALEORDER.TYPE, '') AS TYPE, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(ALLSALEORDER_DESC.SO_GRIDSRNO, 0) AS GRIDSRNO, ROUND(ALLSALEORDER_DESC.SO_QTY - (ALLSALEORDER_DESC.SO_JOQTYPE + ALLSALEORDER_DESC.SO_JOQTYLAMINATION + ALLSALEORDER_DESC.SO_JOQTYSLITTING),0) AS QTY, ISNULL(ALLSALEORDER_DESC.SO_RATE, 0) AS RATE, ISNULL(ALLSALEORDER_DESC.SO_AMOUNT, 0) AS AMT, ISNULL(ALLSALEORDER_DESC.SO_JOQTYPE, 0) AS QTYPE, ISNULL(ALLSALEORDER_DESC.SO_JOQTYLAMINATION, 0) AS QTYLAMINATION, ISNULL(ALLSALEORDER_DESC.SO_JOQTYSLITTING, 0) AS QTYSLITING, ISNULL(ALLSALEORDER_DESC.SO_OUTQTY, 0) AS RECDQTY, ISNULL(ITEMMASTER.ITEM_NAME, '') AS ITEMNAME, ISNULL(FOILITEMMASTER.ITEM_NAME, '') AS FOILITEM FROM  LEDGERS RIGHT OUTER JOIN ITEMMASTER RIGHT OUTER JOIN ITEMMASTER AS FOILITEMMASTER RIGHT OUTER JOIN ALLSALEORDER_DESC ON FOILITEMMASTER.item_id = ALLSALEORDER_DESC.SO_FOILQUALITYID ON ITEMMASTER.item_id = ALLSALEORDER_DESC.SO_FINISHEDQUALITYID RIGHT OUTER JOIN ALLSALEORDER ON ALLSALEORDER_DESC.SO_NO = ALLSALEORDER.SO_NO AND ALLSALEORDER_DESC.SO_YEARID = ALLSALEORDER.SO_YEARID ON LEDGERS.Acc_id = ALLSALEORDER.SO_LEDGERID WHERE ALLSALEORDER_DESC.SO_CLOSED = 'TRUE' AND  ALLSALEORDER.SO_YEARID = " & YearId & "AND  ROUND(ALLSALEORDER_DESC.SO_QTY - (ALLSALEORDER_DESC.SO_JOQTYPE + ALLSALEORDER_DESC.SO_JOQTYLAMINATION + ALLSALEORDER_DESC.SO_JOQTYSLITTING),0) >0 " & ") AS T ", " ORDER BY T.DATE, T.PONO, T.GRIDSRNO")
                End If
            End If
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            If RBENTERED.Checked = True Then
                If MsgBox("You have trying to Re-Open Closed Orders, Wish to Proceed?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            End If

            Dim OBJCMN As New ClsCommon
            For I As Integer = 0 To gridbill.RowCount - 1
                Dim DTROW As DataRow = gridbill.GetDataRow(I)
                If FRMSTRING = "PURCHASE" Then
                    If RBPENDING.Checked = True Then
                        If Convert.ToBoolean(DTROW("CLOSED")) = True Then
                            If DTROW("TYPE") = "PURCHASEORDER" Then Dim DT As DataTable = OBJCMN.Execute_Any_String("UPDATE PURCHASEORDER_DESC SET PO_CLOSED = 1 WHERE PO_NO = " & Val(DTROW("PONO")) & " AND PO_GRIDSRNO = " & Val(DTROW("GRIDSRNO")) & " AND PO_YEARID = " & YearId, "", "") Else Dim DT As DataTable = OBJCMN.Execute_Any_String("UPDATE OPENINGPURCHASEORDER_DESC SET OPO_CLOSED = 1 WHERE OPO_NO = " & Val(DTROW("PONO")) & " AND OPO_GRIDSRNO = " & Val(DTROW("GRIDSRNO")) & " AND OPO_YEARID = " & YearId, "", "")
                        End If
                    Else
                        If Convert.ToBoolean(DTROW("CLOSED")) = True Then
                            If DTROW("TYPE") = "PURCHASEORDER" Then Dim DT As DataTable = OBJCMN.Execute_Any_String("UPDATE PURCHASEORDER_DESC SET PO_CLOSED = 0 WHERE PO_NO = " & Val(DTROW("PONO")) & " AND PO_GRIDSRNO = " & Val(DTROW("GRIDSRNO")) & " AND PO_YEARID = " & YearId, "", "") Else Dim DT As DataTable = OBJCMN.Execute_Any_String("UPDATE OPENINGPURCHASEORDER_DESC SET OPO_CLOSED = 0 WHERE OPO_NO = " & Val(DTROW("PONO")) & " AND OPO_GRIDSRNO = " & Val(DTROW("GRIDSRNO")) & " AND OPO_YEARID = " & YearId, "", "")
                        End If
                    End If
                Else
                    If RBPENDING.Checked = True Then
                        If Convert.ToBoolean(DTROW("CLOSED")) = True Then
                            If DTROW("TYPE") = "SALEORDER" Then Dim DT As DataTable = OBJCMN.Execute_Any_String("UPDATE SALEORDER_DESC SET SO_CLOSED = 1 WHERE SO_NO = " & Val(DTROW("PONO")) & " AND SO_GRIDSRNO = " & Val(DTROW("GRIDSRNO")) & " AND SO_YEARID = " & YearId, "", "") Else Dim DT As DataTable = OBJCMN.Execute_Any_String("UPDATE OPENINGSALEORDER_DESC SET OSO_CLOSED = 1 WHERE OSO_NO = " & Val(DTROW("PONO")) & " AND OSO_GRIDSRNO = " & Val(DTROW("GRIDSRNO")) & " AND OSO_YEARID = " & YearId, "", "")
                        End If
                    Else
                        If Convert.ToBoolean(DTROW("CLOSED")) = True Then
                            If DTROW("TYPE") = "SALEORDER" Then Dim DT As DataTable = OBJCMN.Execute_Any_String("UPDATE SALEORDER_DESC SET SO_CLOSED = 0 WHERE SO_NO = " & Val(DTROW("PONO")) & " AND SO_GRIDSRNO = " & Val(DTROW("GRIDSRNO")) & " AND SO_YEARID = " & YearId, "", "") Else Dim DT As DataTable = OBJCMN.Execute_Any_String("UPDATE OPENINGSALEORDER_DESC SET OSO_CLOSED = 0 WHERE OSO_NO = " & Val(DTROW("PONO")) & " AND OSO_GRIDSRNO = " & Val(DTROW("GRIDSRNO")) & " AND OSO_YEARID = " & YearId, "", "")
                        End If
                    End If
                End If
            Next
            MsgBox("Entries Updated")
            fillgrid("")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDREFRESH_Click(sender As Object, e As EventArgs) Handles CMDREFRESH.Click
        Try
            fillgrid("")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridbill_RowStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs) Handles gridbill.RowStyle
        Try
            If e.RowHandle >= 0 Then
                Dim View As GridView = sender
                If View.GetRowCellDisplayText(e.RowHandle, View.Columns("CLOSED")) = "Checked" Then
                    e.Appearance.Font = New System.Drawing.Font("CALIBRI", 9.0F, System.Drawing.FontStyle.Bold)
                    e.Appearance.BackColor = Color.Yellow
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        Try

            Dim PATH As String = Application.StartupPath & "\Purchase Order Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Purchase Order Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Purchase Order Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            MsgBox("Purchase Order Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub CHKSELECTALL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHKSELECTALL.CheckedChanged
        Try
            If gridbilldetails.Visible = True Then
                For i As Integer = 0 To gridbill.RowCount - 1
                    Dim dtrow As DataRow = gridbill.GetDataRow(i)
                    dtrow("CLOSED") = CHKSELECTALL.Checked
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class