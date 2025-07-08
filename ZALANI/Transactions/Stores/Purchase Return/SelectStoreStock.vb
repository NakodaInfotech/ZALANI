



Imports System.Windows.Forms
    Imports BL
    Imports DevExpress.XtraGrid.Views.Grid

Public Class SelectStoreStock

    Public DT As New DataTable
    Public TEMPPRCHNO As Integer
    Public NAME As String = ""
    Public FRMSTRING As String = ""

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub SelectStoreStock_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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

    Private Sub SelectStoreStock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FILLGRID("")
    End Sub

    Sub FILLGRID(ByVal WHERE As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.SEARCH(" CAST(0 AS BIT) AS CHK, ISNULL(STOREITEMMASTER.STOREITEM_NAME, '') AS STOREITEMNAME, ISNULL(STOCKMASTER_STORE.SMSTORE_QTY, 0) AS QTY, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT ", "", " STOCKMASTER_STORE LEFT OUTER JOIN STOREITEMMASTER ON STOCKMASTER_STORE.SMSTORE_ITEMID = STOREITEMMASTER.STOREITEM_ID LEFT OUTER JOIN UNITMASTER ON STOCKMASTER_STORE.SMSTORE_UNITID = UNITMASTER.unit_id ", " AND STOCKMASTER_STORE.SMSTORE_YEARID=" & YearId & "  ORDER BY STOCKMASTER_STORE.SMSTORE_NO ")
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
            'DT.Columns.Add("PONO")
            'DT.Columns.Add("POSRNO")
            'DT.Columns.Add("DATE")
            DT.Columns.Add("STOREITEMNAME")
            'DT.Columns.Add("NARRATION")
            DT.Columns.Add("QTY")
            DT.Columns.Add("UNIT")


            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    ' DT.Rows.Add(Val(dtrow("PONO")), Val(dtrow("SRNO")), dtrow("POTYPE"), dtrow("DATE"), dtrow("QUALITY"), dtrow("NARRATION"), Val(dtrow("GSM")), Val(dtrow("SIZE")), Val(dtrow("QTY")), dtrow("UNIT"), Val(dtrow("RATE")), Val(dtrow("AMOUNT")))
                    DT.Rows.Add(dtrow("STOREITEMNAME"), Val(dtrow("QTY")), dtrow("UNIT"))

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