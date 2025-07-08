
Imports System.Windows.Forms
Imports BL
Imports DevExpress.XtraGrid.Views.Grid

Public Class SelectGRN
    Public DT As New DataTable
    Public TEMPGRNNO As Integer
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
            Dim DT As DataTable = OBJCMN.SEARCH(" CAST(0 AS BIT) AS CHK, ISNULL(GRN.GRN_NO, 0) AS GRNNO, GRN.GRN_DATE AS DATE, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(GRN_DESC.GRN_GRIDSRNO, 0) AS SRNO, ISNULL(ITEMMASTER.ITEM_NAME, '') AS QUALITY, ISNULL(GRN_DESC.GRN_LOTNO, 0) AS LOTNO, ISNULL(GRN_DESC.GRN_REELNO, 0) AS REELNO, ISNULL(GRN_DESC.GRN_GSM, '') AS GSM, ISNULL(GRN_DESC.GRN_GSMDETAILS, '') AS GSMDETAILS, ISNULL(GRN_DESC.GRN_SIZE, 0) AS SIZE, ISNULL(GRN_DESC.GRN_QTY, 0) AS QTY, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT, ISNULL(GRN.GRN_CHALLANNO, '') AS CHALLANNO, ISNULL(GRN.GRN_CHALLANDT,'') AS CHALLANDATE ", "", " GRN INNER JOIN GODOWNMASTER ON GRN.GRN_GODOWNID = GODOWNMASTER.GODOWN_id INNER JOIN LEDGERS ON GRN.GRN_LEDGERID = LEDGERS.Acc_id INNER JOIN GRN_DESC ON GRN.GRN_NO = GRN_DESC.GRN_NO AND GRN.GRN_YEARID = GRN_DESC.GRN_YEARID INNER JOIN ITEMMASTER ON ITEMMASTER.item_id = GRN_DESC.GRN_ITEMID LEFT OUTER JOIN UNITMASTER ON GRN_DESC.GRN_UNITID = UNITMASTER.unit_id", " AND GRN_DESC.GRN_CHECKDONE = 'FALSE' AND GRN.GRN_YEARID = " & YearId & " ORDER BY GRN.GRN_NO ")
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
            DT.Columns.Add("GRNNO")
            DT.Columns.Add("SRNO")
            DT.Columns.Add("NAME")
            DT.Columns.Add("DATE")
            DT.Columns.Add("QUALITY")
            DT.Columns.Add("LOTNO")
            DT.Columns.Add("REELNO")
            DT.Columns.Add("GSM")
            DT.Columns.Add("GSMDETAILS")
            DT.Columns.Add("SIZE")
            DT.Columns.Add("QTY")
            DT.Columns.Add("UNIT")
            DT.Columns.Add("CHALLANNO")
            DT.Columns.Add("CHALLANDATE")

            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    DT.Rows.Add(Val(dtrow("GRNNO")), Val(dtrow("SRNO")), dtrow("NAME"), dtrow("DATE"), dtrow("QUALITY"), dtrow("LOTNO"), dtrow("REELNO"), dtrow("GSM"), dtrow("GSMDETAILS"), dtrow("SIZE"), Val(dtrow("QTY")), dtrow("UNIT"), dtrow("CHALLANNO"), dtrow("CHALLANDATE"))
                End If
            Next
            Me.Close()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CHKSELECTALL_CheckedChanged(sender As Object, e As EventArgs) Handles CHKSELECTALL.CheckedChanged
        Try
            If gridbilldetails.Visible = True Then
                For i As Integer = 0 To gridbill.RowCount - 1
                    Dim dtrow As DataRow = gridbill.GetDataRow(i)
                    dtrow("CHK") = CHKSELECTALL.Checked
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class