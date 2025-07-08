
Imports BL

Public Class SelectJO
    Public DT As New DataTable
    Public FRMSTRING As String = ""
    Public WHERECLAUSE As String = ""

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub SelectJO_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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

    Private Sub SelectJO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FILLGRID()
    End Sub

    Sub FILLGRID()
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.SEARCH(" CAST(0 AS BIT) AS CHK, ISNULL(ITEMMASTER.ITEM_NAME, '') AS QUALITY, ISNULL(ALLJOBORDER.JO_NO, 0) AS JONO, ISNULL(ALLJOBORDER.TYPE, '') AS JOTYPE, ISNULL(ALLJOBORDER.JO_PROFORMANO, 0)  AS PROFORMANO, ISNULL(ALLJOBORDER.JO_SONO, 0) AS SONO, ISNULL(ALLJOBORDER.JO_SOTYPE, '') AS SOTYPE, ISNULL(ALLJOBORDER_DESC.JO_GRIDSRNO, 0) AS JOSRNO, ALLJOBORDER.JO_DATE AS JODATE, ALLJOBORDER.JO_SODATE AS SODATE,  ISNULL(LEDGERS.Acc_cmpname, '') AS PARTYNAME ,ISNULL(ALLJOBORDER_DESC.JO_PEGSM, 0) AS PEGSM ", "", " ALLJOBORDER_DESC INNER JOIN ALLJOBORDER ON ALLJOBORDER_DESC.JO_NO = ALLJOBORDER.JO_NO AND ALLJOBORDER_DESC.JO_YEARID = ALLJOBORDER.JO_YEARID AND ALLJOBORDER_DESC.TYPE = ALLJOBORDER.TYPE INNER JOIN LEDGERS ON ALLJOBORDER.JO_LEDGERID = LEDGERS.Acc_id INNER JOIN ITEMMASTER ON ITEMMASTER.item_id = ALLJOBORDER_DESC.JO_QUALITYID ", WHERECLAUSE & " AND ALLJOBORDER_DESC.JO_CLOSED = 'FALSE' AND ALLJOBORDER.JO_YEARID =" & YearId & " ORDER BY ALLJOBORDER.JO_NO, ALLJOBORDER_DESC.JO_GRIDSRNO ")
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
            DT.Columns.Add("JONO")
            DT.Columns.Add("JODATE")
            DT.Columns.Add("JOSRNO")
            DT.Columns.Add("JOTYPE")
            DT.Columns.Add("PROFORMANO")
            DT.Columns.Add("SONO")
            DT.Columns.Add("SODATE")
            DT.Columns.Add("SOTYPE")
            DT.Columns.Add("QUALITY")
            DT.Columns.Add("PARTYNAME")
            DT.Columns.Add("PEGSM")



            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    DT.Rows.Add(Val(dtrow("JONO")), dtrow("JODATE"), Val(dtrow("JOSRNO")), dtrow("JOTYPE"), Val(dtrow("PROFORMANO")), Val(dtrow("SONO")), dtrow("SODATE"), dtrow("SOTYPE"), dtrow("QUALITY"), dtrow("PARTYNAME"), dtrow("PEGSM"))
                    Me.Close()
                    Exit Sub
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