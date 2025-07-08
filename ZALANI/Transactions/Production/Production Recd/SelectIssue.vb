


Imports System.Windows.Forms
    Imports BL
    Imports DevExpress.XtraGrid.Views.Grid

Public Class SelectIssue

    Public DT As New DataTable
    Public MACHINENO As String = ""
    Public FRMSTRING As String = ""

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub SelectIssue_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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

    Private Sub SelectIssue_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FILLGRID("")
    End Sub

    Sub FILLGRID(ByVal WHERE As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.SEARCH("CAST(0 AS BIT) AS CHK, ISNULL(MACHINEMASTER.MACHINE_NAME, '') AS MACHINE, ISNULL(ITEMMASTERDESC.ITEM_NAME, '') AS QUALITY, ISNULL(PRODUCTISSUE.ISS_NO, 0) AS ISSUENO, PRODUCTISSUE.ISS_ISSUEDATE AS DATE, PRODUCTISSUE.ISS_JODATE AS JODATE, ISNULL(PRODUCTISSUE.ISS_JOTYPE, '') AS JOTYPE, PRODUCTISSUE.ISS_SODATE AS SODATE, ISNULL(PRODUCTISSUE.ISS_SOTYPE, '') AS SOTYPE, ISNULL(PRODUCTISSUE.ISS_PROFORMANO, 0) AS PROFORMANO, ISNULL(PRODUCTISSUE.ISS_JONO, 0) AS JONO, ISNULL(PRODUCTISSUE.ISS_JOSRNO, 0) AS JOSRNO, ISNULL(PRODUCTISSUE.ISS_SONO, 0) AS SONO, ISNULL(PRODUCTISSUE.ISS_REMARK, '') AS REMARK, ISNULL(PRODUCTISSUE_DESC.ISS_LOTNO, '') AS LOTNO, ISNULL(PRODUCTISSUE_DESC.ISS_ROLLNO, '') AS ROLLNO, ISNULL(PRODUCTISSUE_DESC.ISS_GSM, 0) AS GSM, ISNULL(PRODUCTISSUE_DESC.ISS_GSMDETAILS, 0) AS GSMDETAILS, ISNULL(PRODUCTISSUE_DESC.ISS_SIZE, 0) AS SIZE, ISNULL(PRODUCTISSUE_DESC.ISS_OURQTY - PRODUCTISSUE_DESC.ISS_RECDWT , 0) AS OURQTY, ISNULL(PRODUCTISSUE_DESC.ISS_DIFF, '') AS DIFF,  ISNULL(GODOWNMASTER.GODOWN_name, '') AS GODOWN, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT, ISNULL(PRODUCTISSUE_DESC.ISS_GRIDISSUESRNO, 0) AS GRIDISSUESRNO,  ISNULL(PRODUCTISSUE_DESC.ISS_MILLQTY, 0) AS MILLQTY, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(ITEMMASTER.ITEM_NAME, '') AS FINALQUALITY , ISNULL(PRODUCTISSUE_DESC.ISS_GRIDISSUESRNO, 0) AS GRIDSRNO ", "", "  PRODUCTISSUE INNER JOIN PRODUCTISSUE_DESC ON PRODUCTISSUE.ISS_YEARID = PRODUCTISSUE_DESC.ISS_YEARID AND PRODUCTISSUE.ISS_NO = PRODUCTISSUE_DESC.ISS_NO LEFT OUTER JOIN LEDGERS ON PRODUCTISSUE.ISS_LEDGERID = LEDGERS.Acc_id LEFT OUTER JOIN ITEMMASTER ON PRODUCTISSUE.ISS_FINALQUALITYID = ITEMMASTER.item_id LEFT OUTER JOIN GODOWNMASTER ON PRODUCTISSUE.ISS_GODOWNID = GODOWNMASTER.GODOWN_id LEFT OUTER JOIN ITEMMASTER AS ITEMMASTERDESC ON PRODUCTISSUE_DESC.ISS_QUALITYID = ITEMMASTERDESC.item_id LEFT OUTER JOIN MACHINEMASTER ON PRODUCTISSUE.ISS_MACHINEID = MACHINEMASTER.MACHINE_ID LEFT OUTER JOIN UNITMASTER ON PRODUCTISSUE_DESC.ISS_UNITID = UNITMASTER.unit_id", " AND ISNULL(PRODUCTISSUE_DESC.ISS_OURQTY - PRODUCTISSUE_DESC.ISS_RECDWT,0) > 0 AND PRODUCTISSUE.ISS_YEARID=" & YearId & "  ORDER BY PRODUCTISSUE.ISS_NO")
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
            DT.Columns.Add("ISSUENO")
            DT.Columns.Add("DATE")
            DT.Columns.Add("JONO")
            DT.Columns.Add("JODATE")
            DT.Columns.Add("JOSRNO")
            DT.Columns.Add("JOTYPE")
            DT.Columns.Add("PROFORMANO")
            DT.Columns.Add("SONO")
            DT.Columns.Add("SODATE")
            DT.Columns.Add("SOTYPE")
            DT.Columns.Add("FINALQUALITY")
            DT.Columns.Add("MACHINE")
            DT.Columns.Add("GRIDISSUESRNO")
            DT.Columns.Add("QUALITY")
            DT.Columns.Add("LOTNO")
            DT.Columns.Add("ROLLNO")
            DT.Columns.Add("GSM")
            DT.Columns.Add("GSMDETAILS")
            DT.Columns.Add("SIZE")
            DT.Columns.Add("MILLQTY")
            DT.Columns.Add("OURQTY")
            DT.Columns.Add("DIFF")
            DT.Columns.Add("UNIT")
            DT.Columns.Add("NAME")
            DT.Columns.Add("GRIDSRNO")




            For i As Integer = 0 To gridbill.RowCount - 1
                Dim dtrow As DataRow = gridbill.GetDataRow(i)
                If Convert.ToBoolean(dtrow("CHK")) = True Then
                    'DT.Rows.Add(Val(dtrow("GRIDISSUESRNO")), dtrow("QUALITY"), dtrow("LOTNO"), dtrow("ROLLNO"), Val(dtrow("GSM")), Val(dtrow("SIZE")), dtrow("OURQTY"), dtrow("DIFF"), dtrow("UNIT"))
                    DT.Rows.Add(Val(dtrow("ISSUENO")), dtrow("DATE"), dtrow("JONO"), dtrow("JODATE"), Val(dtrow("JOSRNO")), dtrow("JOTYPE"), dtrow("PROFORMANO"), dtrow("SONO"), dtrow("SODATE"), dtrow("SOTYPE"), dtrow("FINALQUALITY"), dtrow("MACHINE"), Val(dtrow("GRIDISSUESRNO")), dtrow("QUALITY"), dtrow("LOTNO"), dtrow("ROLLNO"), Val(dtrow("GSM")), dtrow("GSMDETAILS"), Val(dtrow("SIZE")), dtrow("MILLQTY"), dtrow("OURQTY"), dtrow("DIFF"), dtrow("UNIT"), dtrow("NAME"), dtrow("GRIDSRNO"))
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