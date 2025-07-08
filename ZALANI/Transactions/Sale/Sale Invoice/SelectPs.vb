
Imports BL

Public Class SelectPS

    Public FRMSTRING As String = ""
    Public PARTYNAME As String = ""
    Public DT As New DataTable


    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub SelectProformaForPO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub SelectPS_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        fillgrid()
    End Sub

    Sub fillgrid(Optional ByVal where As String = "")
        Try
            Cursor.Current = Cursors.WaitCursor
            If PARTYNAME <> "" Then where = where & " AND LEDGERS.Acc_cmpname='" & PARTYNAME & "'"
            Dim OBJCMN As New ClsCommon()
            Dim DT As New DataTable

            DT = OBJCMN.SEARCH("ISNULL(PACKINGSLIP.PS_NO, 0) AS PSNO, PACKINGSLIP.PS_DATE AS PSDATE, ISNULL(PACKINGSLIP.PS_CIFOB, '') AS CIFFOB, ISNULL(PACKINGSLIP.PS_CONTAINER, '') AS CONTAINER, ISNULL(PACKINGSLIP.PS_REMARKS, '') AS REMARKS, ISNULL(PACKINGSLIP.PS_PROFORMANO, 0) AS PROFORMANO, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(SHIPTOLEDGERS.Acc_cmpname, '') AS SHIPTO, ISNULL(TRANSLEDGERS.Acc_cmpname,  '') AS TRANSPORTNAME, ISNULL(PORTMASTER.PORT_name, '') AS PORTDISCHARGE, ISNULL(PORTLOADPORTMASTER.PORT_name, '') AS PORTLOADING, ISNULL(CURRENCYMASTER.CURR_NAME, '') AS CURRENCY,  ISNULL(PACKINGSLIP_DESC.PS_GRIDSRNO, 0) AS GRIDSRNO, ISNULL(PACKINGSLIP_DESC.PS_ROLLNO, '') AS ROLLNO, ISNULL(PACKINGSLIP_DESC.PS_DESC, '') AS GRIDDESC, ISNULL(PACKINGSLIP_DESC.PS_RATE, 0)  AS RATE, ISNULL(PACKINGSLIP_DESC.PS_GSM, 0) AS GSM, ISNULL(PACKINGSLIP_DESC.PS_GSMDETAILS, '') AS GSMDETAILS, ISNULL(PACKINGSLIP_DESC.PS_SIZE, 0) AS SIZE, ISNULL(PACKINGSLIP_DESC.PS_FINALWT, 0)  AS QTY, ISNULL(PACKINGSLIP_DESC.PS_JOINT, '') AS JOINT, ISNULL(PACKINGSLIP_DESC.PS_WT, 0) AS WT, ISNULL(PACKINGSLIP_DESC.PS_MTRS, 0) AS MTRS, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT,  ISNULL(ITEMMASTER.ITEM_NAME, '') AS FINISHEDQUALITY, ISNULL(PACKINGSLIP.PS_ORDERREFNO, '') AS ORDERREFNO, ISNULL(PACKINGSLIP_DESC.PS_CLOSED, 0) AS CLOSED,  ISNULL(PACKINGSLIP_DESC.PS_BARCODE, '') AS BARCODE, ISNULL(PACKINGSLIP_DESC.PS_FROMNO, 0) AS FROMNO, ISNULL(PACKINGSLIP_DESC.PS_FROMSRNO, 0) AS FROMSRNO,  ISNULL(COUNTRYMASTER.country_name, '') AS DESTINATION ", "", " ITEMMASTER RIGHT OUTER JOIN PACKINGSLIP_DESC ON ITEMMASTER.item_id = PACKINGSLIP_DESC.PS_QUALITYID RIGHT OUTER JOIN UNITMASTER ON PACKINGSLIP_DESC.PS_UNITID = UNITMASTER.unit_id RIGHT OUTER JOIN PACKINGSLIP LEFT OUTER JOIN COUNTRYMASTER ON PACKINGSLIP.PS_DESTINATIONID = COUNTRYMASTER.country_id LEFT OUTER JOIN GODOWNMASTER ON PACKINGSLIP.PS_GODOWNID = GODOWNMASTER.GODOWN_id ON PACKINGSLIP_DESC.PS_YEARID = PACKINGSLIP.PS_YEARID AND  PACKINGSLIP_DESC.PS_NO = PACKINGSLIP.PS_NO LEFT OUTER JOIN CURRENCYMASTER ON PACKINGSLIP.PS_CURRENCYID = CURRENCYMASTER.CURR_ID LEFT OUTER JOIN PORTMASTER AS PORTLOADPORTMASTER ON PACKINGSLIP.PS_PORTLOADINGID = PORTLOADPORTMASTER.PORT_id LEFT OUTER JOIN PORTMASTER ON PACKINGSLIP.PS_PORTDISCHARGEID = PORTMASTER.PORT_id LEFT OUTER JOIN LEDGERS AS TRANSLEDGERS ON PACKINGSLIP.PS_TRANSLEDGERID = TRANSLEDGERS.Acc_id LEFT OUTER JOIN LEDGERS AS SHIPTOLEDGERS ON PACKINGSLIP.PS_SHIPTOID = SHIPTOLEDGERS.Acc_id LEFT OUTER JOIN LEDGERS ON PACKINGSLIP.PS_LEDGERID = LEDGERS.Acc_id ", " AND PACKINGSLIP_DESC.PS_CLOSED = 'FALSE' AND PACKINGSLIP.PS_YEARID = " & YearId & where & " ORDER BY PACKINGSLIP.PS_NO, PACKINGSLIP_DESC.PS_GRIDSRNO")

            gridbilldetails.DataSource = DT
            If DT.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default

        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            DT.Columns.Add("PSNO")
            DT.Columns.Add("PSDATE")
            DT.Columns.Add("PROFORMANO")
            DT.Columns.Add("NAME")
            DT.Columns.Add("ORDERREFNO")
            DT.Columns.Add("REMARKS")
            DT.Columns.Add("SHIPTO")
            DT.Columns.Add("PORTLOADING")
            DT.Columns.Add("PORTDISCHARGE")
            DT.Columns.Add("CIFFOB")
            DT.Columns.Add("DESTINATION")
            DT.Columns.Add("TRANSPORTNAME")
            DT.Columns.Add("CURRENCY")
            DT.Columns.Add("CONTAINER")
            DT.Columns.Add("GRIDSRNO")
            DT.Columns.Add("FINISHEDQUALITY")
            DT.Columns.Add("GRIDDESC")
            DT.Columns.Add("ROLLNO")
            DT.Columns.Add("GSM")
            DT.Columns.Add("GSMDETAILS")
            DT.Columns.Add("SIZE")
            DT.Columns.Add("QTY")
            DT.Columns.Add("UNIT")
            DT.Columns.Add("RATE")


            Dim SELECTEDROWS As Int32() = gridbill.GetSelectedRows()
                For I As Integer = 0 To Val(SELECTEDROWS.Length - 1)
                    Dim dtrow As DataRow = gridbill.GetDataRow(SELECTEDROWS(I))
                DT.Rows.Add(dtrow("PSNO"), dtrow("PSDATE"), dtrow("PROFORMANO"), dtrow("NAME"), dtrow("ORDERREFNO"), dtrow("REMARKS"), dtrow("SHIPTO"), dtrow("PORTLOADING"), dtrow("PORTDISCHARGE"), dtrow("CIFFOB"), dtrow("DESTINATION"), dtrow("TRANSPORTNAME"), dtrow("CURRENCY"), dtrow("CONTAINER"), dtrow("GRIDSRNO"), dtrow("FINISHEDQUALITY"), dtrow("GRIDDESC"), dtrow("ROLLNO"), dtrow("GSM"), dtrow("GSMDETAILS"), dtrow("SIZE"), Val(dtrow("QTY")), dtrow("UNIT"), Val(dtrow("RATE")))
            Next
                Me.Close()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

End Class