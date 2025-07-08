
Imports BL
Imports DevExpress.XtraGrid.Views.Grid

Public Class ProformaInvoiceClose

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub ProformaInvoiceClose_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub ProformaInvoiceClose_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'SALE INVOICE'")
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
            If RBPENDING.Checked = True Then
                dt = objclsCMST.search("*", "", " (SELECT ALLPROFORMAINVOICEMASTER.INVOICE_NO AS PROFORMANO, ALLPROFORMAINVOICEMASTER_DESC.INVOICE_GRIDSRNO AS PROFORMAGRIDSRNO, ALLPROFORMAINVOICEMASTER.INVOICE_DATE AS DATE, LEDGERS.Acc_cmpname AS NAME, ISNULL(COUNTRYMASTER.country_name, '') AS DESTINATION, ISNULL(DISCHARGEPORTMASTER.PORT_name, '') AS DISCHARGEPORT, ISNULL(LOADINGPORTMASTER.PORT_name, '') AS LOADINGPORT, ITEMMASTER.ITEM_NAME AS ITEMNAME, ISNULL(ALLPROFORMAINVOICEMASTER_DESC.INVOICE_GSM, '') AS GSM, ISNULL(ALLPROFORMAINVOICEMASTER_DESC.INVOICE_GSMDETAILS, '') AS GSMDETAILS,ISNULL(ALLPROFORMAINVOICEMASTER_DESC.INVOICE_SIZE, '') AS SIZE, ALLPROFORMAINVOICEMASTER_DESC.INVOICE_QTY AS QTY, UNITMASTER.unit_abbr AS UNIT, ALLPROFORMAINVOICEMASTER_DESC.INVOICE_RATE AS RATE, ALLPROFORMAINVOICEMASTER_DESC.INVOICE_AMOUNT AS AMOUNT, ALLPROFORMAINVOICEMASTER.INVOICE_TYPE AS TYPE, ALLPROFORMAINVOICEMASTER_DESC.INVOICE_CLOSED AS CLOSED FROM ALLPROFORMAINVOICEMASTER INNER JOIN ALLPROFORMAINVOICEMASTER_DESC ON ALLPROFORMAINVOICEMASTER.INVOICE_NO = ALLPROFORMAINVOICEMASTER_DESC.INVOICE_NO AND ALLPROFORMAINVOICEMASTER.INVOICE_YEARID = ALLPROFORMAINVOICEMASTER_DESC.INVOICE_YEARID AND ALLPROFORMAINVOICEMASTER.INVOICE_TYPE = ALLPROFORMAINVOICEMASTER_DESC.INVOICE_TYPE INNER JOIN LEDGERS ON ALLPROFORMAINVOICEMASTER.INVOICE_LEDGERID = LEDGERS.Acc_id INNER JOIN ITEMMASTER ON ALLPROFORMAINVOICEMASTER_DESC.INVOICE_FINISHEDQUALITYID = ITEMMASTER.item_id INNER JOIN COUNTRYMASTER ON ALLPROFORMAINVOICEMASTER.INVOICE_DESTINATIONID = COUNTRYMASTER.country_id INNER JOIN UNITMASTER ON ALLPROFORMAINVOICEMASTER_DESC.INVOICE_UNITID = UNITMASTER.unit_id LEFT OUTER JOIN PORTMASTER AS LOADINGPORTMASTER ON ALLPROFORMAINVOICEMASTER.INVOICE_PORTLOADINGID = LOADINGPORTMASTER.PORT_id LEFT OUTER JOIN PORTMASTER AS DISCHARGEPORTMASTER ON ALLPROFORMAINVOICEMASTER.INVOICE_PORTDISCHARGEID = DISCHARGEPORTMASTER.PORT_id WHERE ALLPROFORMAINVOICEMASTER_DESC.INVOICE_CLOSED = 'FALSE' AND ALLPROFORMAINVOICEMASTER_DESC.INVOICE_PODONE = 'FALSE' AND ALLPROFORMAINVOICEMASTER_DESC.INVOICE_SODONE = 'FALSE' AND dbo.ALLPROFORMAINVOICEMASTER.INVOICE_YEARID=" & YearId & ") AS T", " ORDER BY PROFORMANO, PROFORMAGRIDSRNO")
            Else
                dt = objclsCMST.search("*", "", " (SELECT ALLPROFORMAINVOICEMASTER.INVOICE_NO AS PROFORMANO, ALLPROFORMAINVOICEMASTER_DESC.INVOICE_GRIDSRNO AS PROFORMAGRIDSRNO, ALLPROFORMAINVOICEMASTER.INVOICE_DATE AS DATE, LEDGERS.Acc_cmpname AS NAME, ISNULL(COUNTRYMASTER.country_name, '') AS DESTINATION, ISNULL(DISCHARGEPORTMASTER.PORT_name, '') AS DISCHARGEPORT, ISNULL(LOADINGPORTMASTER.PORT_name, '') AS LOADINGPORT, ITEMMASTER.ITEM_NAME AS ITEMNAME, ISNULL(ALLPROFORMAINVOICEMASTER_DESC.INVOICE_GSM, '') AS GSM, ISNULL(ALLPROFORMAINVOICEMASTER_DESC.INVOICE_GSMDETAILS, '') AS GSMDETAILS, ISNULL(ALLPROFORMAINVOICEMASTER_DESC.INVOICE_SIZE, '') AS SIZE, ALLPROFORMAINVOICEMASTER_DESC.INVOICE_QTY AS QTY, UNITMASTER.unit_abbr AS UNIT, ALLPROFORMAINVOICEMASTER_DESC.INVOICE_RATE AS RATE, ALLPROFORMAINVOICEMASTER_DESC.INVOICE_AMOUNT AS AMOUNT, ALLPROFORMAINVOICEMASTER.INVOICE_TYPE AS TYPE, ALLPROFORMAINVOICEMASTER_DESC.INVOICE_CLOSED AS CLOSED FROM ALLPROFORMAINVOICEMASTER INNER JOIN ALLPROFORMAINVOICEMASTER_DESC ON ALLPROFORMAINVOICEMASTER.INVOICE_NO = ALLPROFORMAINVOICEMASTER_DESC.INVOICE_NO AND ALLPROFORMAINVOICEMASTER.INVOICE_YEARID = ALLPROFORMAINVOICEMASTER_DESC.INVOICE_YEARID AND ALLPROFORMAINVOICEMASTER.INVOICE_TYPE = ALLPROFORMAINVOICEMASTER_DESC.INVOICE_TYPE INNER JOIN LEDGERS ON ALLPROFORMAINVOICEMASTER.INVOICE_LEDGERID = LEDGERS.Acc_id INNER JOIN ITEMMASTER ON ALLPROFORMAINVOICEMASTER_DESC.INVOICE_FINISHEDQUALITYID = ITEMMASTER.item_id INNER JOIN COUNTRYMASTER ON ALLPROFORMAINVOICEMASTER.INVOICE_DESTINATIONID = COUNTRYMASTER.country_id INNER JOIN UNITMASTER ON ALLPROFORMAINVOICEMASTER_DESC.INVOICE_UNITID = UNITMASTER.unit_id LEFT OUTER JOIN PORTMASTER AS LOADINGPORTMASTER ON ALLPROFORMAINVOICEMASTER.INVOICE_PORTLOADINGID = LOADINGPORTMASTER.PORT_id LEFT OUTER JOIN PORTMASTER AS DISCHARGEPORTMASTER ON ALLPROFORMAINVOICEMASTER.INVOICE_PORTDISCHARGEID = DISCHARGEPORTMASTER.PORT_id WHERE ALLPROFORMAINVOICEMASTER_DESC.INVOICE_CLOSED = 'TRUE' AND ALLPROFORMAINVOICEMASTER_DESC.INVOICE_PODONE = 'FALSE' AND ALLPROFORMAINVOICEMASTER_DESC.INVOICE_SODONE = 'FALSE' AND dbo.ALLPROFORMAINVOICEMASTER.INVOICE_YEARID=" & YearId & ") AS T", " ORDER BY PROFORMANO, PROFORMAGRIDSRNO")
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
                If MsgBox("You have trying to Re-Open Closed Proforma, Wish to Proceed?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            End If

            Dim OBJCMN As New ClsCommon
            For I As Integer = 0 To gridbill.RowCount - 1
                Dim DTROW As DataRow = gridbill.GetDataRow(I)
                If RBPENDING.Checked = True Then
                    If Convert.ToBoolean(DTROW("CLOSED")) = True Then
                        If DTROW("TYPE") = "PROFORMA" Then Dim DT As DataTable = OBJCMN.Execute_Any_String("UPDATE PROFORMAINVOICEMASTER_DESC SET INVOICE_CLOSED = 1 WHERE INVOICE_NO = " & Val(DTROW("PROFORMANO")) & " AND INVOICE_GRIDSRNO = " & Val(DTROW("PROFORMAGRIDSRNO")) & " AND INVOICE_YEARID = " & YearId, "", "") Else Dim DT As DataTable = OBJCMN.Execute_Any_String("UPDATE OPENINGPROFORMAINVOICEMASTER_DESC SET INVOICE_CLOSED = 1 WHERE INVOICE_NO = " & Val(DTROW("PROFORMANO")) & " AND INVOICE_GRIDSRNO = " & Val(DTROW("PROFORMAGRIDSRNO")) & " AND INVOICE_YEARID = " & YearId, "", "")
                    End If
                Else
                    If Convert.ToBoolean(DTROW("CLOSED")) = True Then
                        If DTROW("TYPE") = "PROFORMA" Then Dim DT As DataTable = OBJCMN.Execute_Any_String("UPDATE PROFORMAINVOICEMASTER_DESC SET INVOICE_CLOSED = 0 WHERE INVOICE_NO = " & Val(DTROW("PROFORMANO")) & " AND INVOICE_GRIDSRNO = " & Val(DTROW("PROFORMAGRIDSRNO")) & " AND INVOICE_YEARID = " & YearId, "", "") Else Dim DT As DataTable = OBJCMN.Execute_Any_String("UPDATE OPENINGPROFORMAINVOICEMASTER_DESC SET INVOICE_CLOSED = 0 WHERE INVOICE_NO = " & Val(DTROW("PROFORMANO")) & " AND INVOICE_GRIDSRNO = " & Val(DTROW("PROFORMAGRIDSRNO")) & " AND INVOICE_YEARID = " & YearId, "", "")
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

            Dim PATH As String = Application.StartupPath & "\Proforma Invoice Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Proforma Invoice Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Proforma Invoice Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            MsgBox("Proforma Invoice Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
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