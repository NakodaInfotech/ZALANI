Imports BL

Public Class NonInvItemMasterDetailReport

    Public WHERECLAUSE As String
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean

    Private Sub cmdcancel_Click(sender As Object, e As EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub CMDREFRESH_Click(sender As Object, e As EventArgs) Handles CMDREFRESH.Click
        Try
            fillgrid("" & WHERECLAUSE)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDEXCEL_Click(sender As Object, e As EventArgs) Handles CMDEXCEL.Click
        Try
            Dim PATH As String = "" = ""
            If FileIO.FileSystem.FileExists(PATH) = True Then FileIO.FileSystem.DeleteFile(PATH)
            PATH = Application.StartupPath & "\NonInv Item MasterDetails Report.XLS"

            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True

            Dim workbook As String = PATH
            If FileIO.FileSystem.FileExists(PATH) = True Then Interaction.GetObject(workbook).close(False)
            GC.Collect()
            'For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
            '    proc.Kill()
            'Next

            Dim PERIOD As String = AccFrom & " - " & AccTo

            opti.SheetName = "NonInv Item MasterDetails Report"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "NonInv Item MasterDetails Report", gridbill.VisibleColumns.Count + gridbill.GroupCount, "", PERIOD)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub NonInvItemMasterDetailReport_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Or (e.KeyCode = Keys.X And e.Alt = True) Then
                Me.Close()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid(ByVal WHERECLAUSE As String)
        Try
            Dim objclsCMST As New ClsCommonMaster
            Dim dt As DataTable = objclsCMST.search(" NONINVITEMMASTER.NONINV_NAME AS ITEMNAME, HSNMASTER.HSN_CODE AS HSNCODE, CATEGORYMASTER.category_name AS CATEGORYNAME, ISNULL(ITEMMASTER.item_code, '') AS INVITEMCODE, NONINVITEMMASTER.NONINV_LENGTH AS LENGTH, NONINVITEMMASTER.NONINV_WIDTH AS WIDTH, NONINVITEMMASTER.NONINV_GSM AS GSM, NONINVITEMMASTER.NONINV_REMARKS AS REMARKS, NONINVITEMMASTER.NONINV_ISPLATE AS ISPLATE, NONINV_ISPAPER AS ISPAPER, ISNULL(PAPERMATERIALMASTER.PAPERMATERIAL_NAME, '') AS PAPERMATERIAL, ISNULL(PAPERMILLMASTER.PAPERMILL_NAME, '') AS PAPERMILL ", "", " NONINVITEMMASTER LEFT OUTER JOIN HSNMASTER ON NONINVITEMMASTER.NONINV_HSNCODEID = HSNMASTER.HSN_ID LEFT OUTER JOIN CATEGORYMASTER ON NONINVITEMMASTER.NONINV_CATEGORYID = CATEGORYMASTER.category_id LEFT OUTER JOIN PAPERMATERIALMASTER ON NONINVITEMMASTER.NONINV_PAPERMATERIALID = PAPERMATERIALMASTER.PAPERMATERIAL_ID LEFT OUTER JOIN ITEMMASTER ON NONINVITEMMASTER.NONINV_INVITEMID = ITEMMASTER.item_id LEFT OUTER JOIN PAPERMILLMASTER ON NONINVITEMMASTER.NONINV_PAPERMILLID = PAPERMILLMASTER.PAPERMILL_ID ", WHERECLAUSE & " AND NONINV_yearid = " & YearId & " ORDER BY NONINV_NAME ")
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then gridbill.FocusedRowHandle = gridbill.RowCount - 1
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub NonInvItemMasterDetailReport_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            fillgrid("" & WHERECLAUSE)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class