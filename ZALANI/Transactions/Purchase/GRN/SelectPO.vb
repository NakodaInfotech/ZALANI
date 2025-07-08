
Imports System.Windows.Forms
Imports BL
Imports DevExpress.XtraGrid.Views.Grid

Public Class SelectPO
    Public DT As New DataTable
    Public TEMPPONO As Integer
    Public PARTYNAME As String = ""
    Public FRMSTRING As String = ""

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub SelectPO_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SelectPO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FILLGRID("")
    End Sub

    Sub FILLGRID(ByVal WHERE As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.SEARCH(" CAST(0 AS BIT) AS CHK, ISNULL(ALLPURCHASEORDER.PO_NO, 0) AS PONO, ISNULL(ALLPURCHASEORDER_DESC.PO_GRIDSRNO, 0) AS SRNO, ALLPURCHASEORDER.PO_DATE AS DATE, ISNULL(ITEMMASTER.ITEM_NAME, '') AS QUALITY, ISNULL(ALLPURCHASEORDER_DESC.PO_NARRATION, '') AS NARRATION, ISNULL(ALLPURCHASEORDER_DESC.PO_GSM, '') AS GSM, ISNULL(ALLPURCHASEORDER_DESC.PO_SIZE, 0) AS SIZE, ROUND(ALLPURCHASEORDER_DESC.PO_QTY-ALLPURCHASEORDER_DESC.PO_RECDQTY, 2) AS QTY, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT, ISNULL(ALLPURCHASEORDER_DESC.PO_RATE, 0) AS RATE, ISNULL(ALLPURCHASEORDER_DESC.PO_AMT, 0) AS AMOUNT, ALLPURCHASEORDER.TYPE AS POTYPE ", "", " ALLPURCHASEORDER INNER JOIN ALLPURCHASEORDER_DESC ON ALLPURCHASEORDER_DESC.PO_NO = ALLPURCHASEORDER.PO_NO AND ALLPURCHASEORDER_DESC.PO_YEARID = ALLPURCHASEORDER.PO_YEARID AND ALLPURCHASEORDER_DESC.TYPE = ALLPURCHASEORDER.TYPE INNER JOIN ITEMMASTER ON ITEMMASTER.item_id = ALLPURCHASEORDER_DESC.PO_QUALITYID LEFT OUTER JOIN UNITMASTER ON ALLPURCHASEORDER_DESC.PO_QTYUNITID = UNITMASTER.unit_id INNER JOIN LEDGERS ON ALLPURCHASEORDER.PO_LEDGERID = LEDGERS.Acc_id", " AND LEDGERS.ACC_CMPNAME = '" & PARTYNAME & "' AND ALLPURCHASEORDER_DESC.PO_CLOSED = 'FALSE' AND ROUND(ALLPURCHASEORDER_DESC.PO_QTY-ALLPURCHASEORDER_DESC.PO_RECDQTY, 2) > 0 and ALLPURCHASEORDER.PO_YEARID=" & YearId & "  ORDER BY ALLPURCHASEORDER.PO_NO ")
            gridbilldetails.DataSource = DT
            If DT.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            DT.Columns.Add("PONO")
            DT.Columns.Add("POSRNO")
            DT.Columns.Add("POTYPE")
            DT.Columns.Add("DATE")
            DT.Columns.Add("QUALITY")
            DT.Columns.Add("NARRATION")
            DT.Columns.Add("GSM")
            DT.Columns.Add("SIZE")
            DT.Columns.Add("QTY")
            DT.Columns.Add("UNIT")
            DT.Columns.Add("RATE")
            DT.Columns.Add("AMOUNT")

            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    DT.Rows.Add(Val(dtrow("PONO")), Val(dtrow("SRNO")), dtrow("POTYPE"), dtrow("DATE"), dtrow("QUALITY"), dtrow("NARRATION"), Val(dtrow("GSM")), Val(dtrow("SIZE")), Val(dtrow("QTY")), dtrow("UNIT"), Val(dtrow("RATE")), Val(dtrow("AMOUNT")))
                End If
            Next
            Me.Close()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

End Class