


Imports System.Windows.Forms
Imports BL
Imports DevExpress.XtraGrid.Views.Grid

Public Class SelectStock
    Public DT As New DataTable
    Public TEMPPRCHNO As Integer
    Public FRMSTRING As String = ""
    Public GODOWN As String

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub SelectStock_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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

    Private Sub SelectStock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FILLGRID("")
    End Sub

    Sub FILLGRID(ByVal WHERE As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim OBJCMN As New ClsCommon
            Dim DT As New DataTable

            If FRMSTRING = "FQC" Then
                'DT = OBJCMN.SEARCH(" CAST(0 AS BIT) AS CHK, ISNULL(FROMNO, 0) AS FROMNO, ISNULL(FROMSRNO, 0) AS FROMSRNO, ISNULL(ITEMNAME, '') AS ITEMNAME, ISNULL(LOTNO, '') AS LOTNO, ISNULL(REELNO, '') AS REELNO, ISNULL(GSM, 0) AS GSM, ISNULL(GSMDETAILS, '') AS GSMDETAILS, ISNULL(SIZE, 0) AS SIZE, SUM(ISNULL(QTY, 0)) AS QTY, ISNULL(UNIT, '') AS UNIT, MATERIALTYPE, GODOWN  ", "", " STOCKREGISTER ", " AND GODOWN = '" & GODOWN & "' AND MATERIALTYPE = 'FINISHED' AND YEARID=" & YearId & "  GROUP BY ISNULL(FROMNO, 0), ISNULL(FROMSRNO, 0), ISNULL(ITEMNAME, ''), ISNULL(LOTNO, ''), ISNULL(REELNO, ''), ISNULL(GSM, 0), ISNULL(GSMDETAILS, ''), ISNULL(SIZE, 0), ISNULL(UNIT, ''), MATERIALTYPE, GODOWN  HAVING SUM(QTY) > 0")
                ' DT = OBJCMN.SEARCH(" CAST(0 AS BIT) AS CHK, ISNULL(FROMNO, 0) AS FROMNO,  ISNULL(FROMSRNO, 0) AS FROMSRNO, FORMAT(ENTRYDATE, 'dd-MM-yyyy') AS ENTRYDATE ,  ISNULL(ITEMNAME, '') AS ITEMNAME, ISNULL(LOTNO, '') AS LOTNO, ISNULL(REELNO, '') AS REELNO, ISNULL(GSM, 0) AS GSM, ISNULL(GSMDETAILS, '') AS GSMDETAILS, ISNULL(SIZE, 0) AS SIZE, SUM(ISNULL(QTY, 0)) AS QTY, ISNULL(UNIT, '') AS UNIT, MATERIALTYPE, GODOWN,BARCODE  ,FROMTYPE   ", "", " BARCODESTOCK ", " AND GODOWN = '" & GODOWN & "' AND MATERIALTYPE = 'FINISHED' AND YEARID=" & YearId & "  GROUP BY ISNULL(FROMNO, 0), ISNULL(FROMSRNO, 0), ENTRYDATE ,ISNULL(ITEMNAME, ''), ISNULL(LOTNO, ''), ISNULL(REELNO, ''), ISNULL(GSM, 0), ISNULL(GSMDETAILS, ''), ISNULL(SIZE, 0), ISNULL(UNIT, ''), MATERIALTYPE, GODOWN ,BARCODE ,FROMTYPE HAVING SUM(QTY) > 0")
                DT = OBJCMN.SEARCH(" CAST(0 AS BIT) AS CHK, ISNULL(FROMNO, 0) AS FROMNO, ISNULL(FROMSRNO, 0) AS FROMSRNO, FORMAT(ENTRYDATE, 'dd-MM-yyyy') AS ENTRYDATE , ISNULL(ITEMNAME, '') AS ITEMNAME, ISNULL(LOTNO, '') AS LOTNO, ISNULL(REELNO, '') AS REELNO, ISNULL(GSM, 0) AS GSM, ISNULL(GSMDETAILS,'') AS GSMDETAILS, ISNULL(SIZE, 0) AS SIZE, SUM(ISNULL(QTY, 0)) AS QTY, ISNULL(UNIT, '') AS UNIT, ISNULL(ROLLWT, 0) AS ROLLWT, BARCODE, GODOWN ,MATERIALTYPE , FROMTYPE , '' AS ROLLOD , '' AS ROLLID ", "", " BARCODESTOCK ", " AND GODOWN = '" & GODOWN & "' AND BARCODESTOCK.YEARID=" & YearId & "  AND BARCODESTOCK.READYFINALQC = 1  GROUP BY ISNULL(FROMNO, 0), ISNULL(FROMSRNO, 0), ENTRYDATE ,ISNULL(ITEMNAME, ''), ISNULL(LOTNO, ''), ISNULL(REELNO, ''), ISNULL(GSM, 0), ISNULL(GSMDETAILS,''), ISNULL(SIZE, 0), ISNULL(UNIT, '') , ISNULL(ROLLWT, 0) , BARCODE, GODOWN ,MATERIALTYPE , FROMTYPE , ROLLOD ,ROLLID HAVING SUM(QTY) > 0 ORDER BY ENTRYDATE")

                'ElseIf FRMSTRING = "PS" Then
                '    DT = OBJCMN.SEARCH(" CAST(0 AS BIT) AS CHK, ISNULL(FROMNO, 0) AS FROMNO, ISNULL(FROMSRNO, 0) AS FROMSRNO, FORMAT(ENTRYDATE, 'dd-MM-yyyy') AS ENTRYDATE , ISNULL(ITEMNAME, '') AS ITEMNAME, ISNULL(LOTNO, '') AS LOTNO, ISNULL(REELNO, '') AS REELNO, ISNULL(GSM, 0) AS GSM, ISNULL(GSMDETAILS,'') AS GSMDETAILS, ISNULL(SIZE, 0) AS SIZE, SUM(ISNULL(QTY, 0)) AS QTY, ISNULL(UNIT, '') AS UNIT, ISNULL(ROLLWT, 0) AS ROLLWT, BARCODE, GODOWN ,MATERIALTYPE , FROMTYPE ", "", " BARCODESTOCK ", " AND GODOWN = '" & GODOWN & "' AND BARCODESTOCK.YEARID=" & YearId & " GROUP BY ISNULL(FROMNO, 0), ISNULL(FROMSRNO, 0), ENTRYDATE ,ISNULL(ITEMNAME, ''), ISNULL(LOTNO, ''), ISNULL(REELNO, ''), ISNULL(GSM, 0), ISNULL(GSMDETAILS,''), ISNULL(SIZE, 0), ISNULL(UNIT, '') , ISNULL(ROLLWT, 0) , BARCODE, GODOWN ,MATERIALTYPE , FROMTYPE HAVING SUM(QTY) > 0")

                'ElseIf FRMSTRING = "LABELING" Then
                '    ' DT = OBJCMN.SEARCH(" CAST(0 AS BIT) AS CHK, 0 AS FROMNO, 0 AS FROMSRNO, ISNULL(ITEMNAME, '') AS ITEMNAME, ISNULL(LOTNO, '') AS LOTNO, ISNULL(REELNO, '') AS REELNO, ISNULL(GSM, 0) AS GSM, ISNULL(GSMDETAILS,'') AS GSMDETAILS, ISNULL(SIZE, 0) AS SIZE, SUM(ISNULL(QTY, 0)) AS QTY, ISNULL(UNIT, '') AS UNIT, MATERIALTYPE, GODOWN ", "", " STOCKREGISTER", " AND GODOWN = '" & GODOWN & "' AND STOCKREGISTER.YEARID=" & YearId & " GROUP BY ISNULL(ITEMNAME, ''), ISNULL(LOTNO, ''), ISNULL(REELNO, ''), ISNULL(GSM, 0), ISNULL(GSMDETAILS,''), ISNULL(SIZE, 0), ISNULL(UNIT, ''), MATERIALTYPE, GODOWN HAVING SUM(QTY) > 0")
                '    DT = OBJCMN.SEARCH(" CAST(0 AS BIT) AS CHK, ISNULL(FROMNO, 0) AS FROMNO, ISNULL(FROMSRNO, 0) AS FROMSRNO, FORMAT(ENTRYDATE, 'dd-MM-yyyy') AS ENTRYDATE , ISNULL(ITEMNAME, '') AS ITEMNAME, ISNULL(LOTNO, '') AS LOTNO, ISNULL(REELNO, '') AS REELNO, ISNULL(GSM, 0) AS GSM, ISNULL(GSMDETAILS,'') AS GSMDETAILS, ISNULL(SIZE, 0) AS SIZE, SUM(ISNULL(QTY, 0)) AS QTY, ISNULL(UNIT, '') AS UNIT, ISNULL(ROLLWT, 0) AS ROLLWT, BARCODE, GODOWN ,MATERIALTYPE , FROMTYPE ", "", " BARCODESTOCK ", " AND GODOWN = '" & GODOWN & "' AND BARCODESTOCK.YEARID=" & YearId & " AND BARCODESTOCK.READYFINALQC = 0 GROUP BY ISNULL(FROMNO, 0), ISNULL(FROMSRNO, 0), ENTRYDATE ,ISNULL(ITEMNAME, ''), ISNULL(LOTNO, ''), ISNULL(REELNO, ''), ISNULL(GSM, 0), ISNULL(GSMDETAILS,''), ISNULL(SIZE, 0), ISNULL(UNIT, '') , ISNULL(ROLLWT, 0) , BARCODE, GODOWN ,MATERIALTYPE , FROMTYPE HAVING SUM(QTY) > 0")

                'ElseIf FRMSTRING = "PRODISSUE" Then
                '    'DT = OBJCMN.SEARCH(" CAST(0 AS BIT) AS CHK, 0 AS FROMNO, 0 AS FROMSRNO, ISNULL(ITEMNAME, '') AS ITEMNAME, ISNULL(LOTNO, '') AS LOTNO, ISNULL(REELNO, '') AS REELNO, ISNULL(GSM, 0) AS GSM, ISNULL(GSMDETAILS,'') AS GSMDETAILS, ISNULL(SIZE, 0) AS SIZE, SUM(ISNULL(QTY, 0)) AS QTY, ISNULL(UNIT, '') AS UNIT, MATERIALTYPE, GODOWN ", "", " STOCKREGISTER", " AND GODOWN = '" & GODOWN & "' AND STOCKREGISTER.YEARID=" & YearId & " GROUP BY ISNULL(ITEMNAME, ''), ISNULL(LOTNO, ''), ISNULL(REELNO, ''), ISNULL(GSM, 0), ISNULL(GSMDETAILS,''), ISNULL(SIZE, 0), ISNULL(UNIT, ''), MATERIALTYPE, GODOWN HAVING SUM(QTY) > 0")
                '    'DT = OBJCMN.SEARCH(" CAST(0 AS BIT) AS CHK, 0 AS FROMNO, 0 AS FROMSRNO, ISNULL(ITEMNAME, '') AS ITEMNAME, ISNULL(LOTNO, '') AS LOTNO, ISNULL(REELNO, '') AS REELNO, ISNULL(GSM, 0) AS GSM, ISNULL(GSMDETAILS,'') AS GSMDETAILS, ISNULL(SIZE, 0) AS SIZE, SUM(ISNULL(QTY, 0)) AS QTY, ISNULL(UNIT, '') AS UNIT, MATERIALTYPE, GODOWN ", "", " STOCKREGISTER", " AND GODOWN = '" & GODOWN & "' AND STOCKREGISTER.YEARID=" & YearId & " GROUP BY ISNULL(ITEMNAME, ''), ISNULL(LOTNO, ''), ISNULL(REELNO, ''), ISNULL(GSM, 0), ISNULL(GSMDETAILS,''), ISNULL(SIZE, 0), ISNULL(UNIT, ''), MATERIALTYPE, GODOWN HAVING SUM(QTY) > 0")
                '    DT = OBJCMN.SEARCH(" CAST(0 AS BIT) AS CHK,  ISNULL(FROMNO,0) AS FROMNO,  FORMAT(ENTRYDATE, 'dd-MM-yyyy') AS ENTRYDATE ,  ISNULL(FROMSRNO,0) AS FROMSRNO, ISNULL(ITEMNAME, '') AS ITEMNAME, ISNULL(LOTNO, '') AS LOTNO, ISNULL(REELNO, '') AS REELNO, ISNULL(GSM, 0) AS GSM, ISNULL(GSMDETAILS,'') AS GSMDETAILS, ISNULL(SIZE, 0) AS SIZE, SUM(ISNULL(QTY, 0)) AS QTY, ISNULL(UNIT, '') AS UNIT, MATERIALTYPE, GODOWN ,BARCODE , FROMTYPE ", "", " BARCODESTOCK", " AND GODOWN = '" & GODOWN & "' AND BARCODESTOCK.YEARID= " & YearId & " GROUP BY  ISNULL(FROMNO,0) ,ENTRYDATE , ISNULL(FROMSRNO,0) ,ISNULL(ITEMNAME, ''), ISNULL(LOTNO, ''), ISNULL(REELNO, ''), ISNULL(GSM, 0), ISNULL(GSMDETAILS,''), ISNULL(SIZE, 0), ISNULL(UNIT, ''), MATERIALTYPE, GODOWN ,BARCODE , FROMTYPE HAVING SUM(QTY) > 0")
            Else
                'DT = OBJCMN.SEARCH(" CAST(0 AS BIT) AS CHK, 0 AS FROMNO, 0 AS FROMSRNO, ISNULL(ITEMNAME, '') AS ITEMNAME, ISNULL(LOTNO, '') AS LOTNO, ISNULL(REELNO, '') AS REELNO, ISNULL(GSM, 0) AS GSM, ISNULL(GSMDETAILS,'') AS GSMDETAILS, ISNULL(SIZE, 0) AS SIZE, SUM(ISNULL(QTY, 0)) AS QTY, ISNULL(UNIT, '') AS UNIT, MATERIALTYPE, GODOWN ", "", " STOCKREGISTER", " AND GODOWN = '" & GODOWN & "' AND STOCKREGISTER.YEARID=" & YearId & " GROUP BY ISNULL(ITEMNAME, ''), ISNULL(LOTNO, ''), ISNULL(REELNO, ''), ISNULL(GSM, 0), ISNULL(GSMDETAILS,''), ISNULL(SIZE, 0), ISNULL(UNIT, ''), MATERIALTYPE, GODOWN HAVING SUM(QTY) > 0")
                DT = OBJCMN.SEARCH(" CAST(0 AS BIT) AS CHK, ISNULL(FROMNO, 0) AS FROMNO, ISNULL(FROMSRNO, 0) AS FROMSRNO, FORMAT(ENTRYDATE, 'dd-MM-yyyy') AS ENTRYDATE , ISNULL(ITEMNAME, '') AS ITEMNAME, ISNULL(LOTNO, '') AS LOTNO, ISNULL(REELNO, '') AS REELNO, ISNULL(GSM, 0) AS GSM, ISNULL(GSMDETAILS,'') AS GSMDETAILS, ISNULL(SIZE, 0) AS SIZE, SUM(ISNULL(QTY, 0)) AS QTY, ISNULL(UNIT, '') AS UNIT, ISNULL(ROLLWT, 0) AS ROLLWT, BARCODE, GODOWN ,MATERIALTYPE , FROMTYPE , ISNULL(ROLLOD,'') AS ROLLOD , ISNULL(ROLLID,'') AS ROLLID ", "", " BARCODESTOCK ", " AND GODOWN = '" & GODOWN & "' AND BARCODESTOCK.YEARID=" & YearId & " AND BARCODESTOCK.READYFINALQC = 0 GROUP BY ISNULL(FROMNO, 0), ISNULL(FROMSRNO, 0), ENTRYDATE ,ISNULL(ITEMNAME, ''), ISNULL(LOTNO, ''), ISNULL(REELNO, ''), ISNULL(GSM, 0), ISNULL(GSMDETAILS,''), ISNULL(SIZE, 0), ISNULL(UNIT, '') , ISNULL(ROLLWT, 0) , BARCODE, GODOWN ,MATERIALTYPE , FROMTYPE, ROLLOD ,ROLLID HAVING SUM(QTY) > 0 ORDER BY ENTRYDATE")
            End If

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
            If FRMSTRING = "PS" Or FRMSTRING = "FQC" Or FRMSTRING = "LABELING" Or FRMSTRING = "PRODISSUE" Then

                DT.Columns.Add("FROMNO")
                DT.Columns.Add("FROMSRNO")
                DT.Columns.Add("ITEMNAME")
                DT.Columns.Add("LOTNO")
                DT.Columns.Add("REELNO")
                DT.Columns.Add("GSM")
                DT.Columns.Add("GSMDETAILS")
                DT.Columns.Add("SIZE")
                DT.Columns.Add("QTY")
                DT.Columns.Add("UNIT")
                DT.Columns.Add("ROLLWT")
                DT.Columns.Add("BARCODE")
                DT.Columns.Add("FROMTYPE")
                DT.Columns.Add("ROLLOD")
                DT.Columns.Add("ROLLID")



                For i As Integer = 0 To gridbill.RowCount - 1
                    Dim dtrow As DataRow = gridbill.GetDataRow(i)
                    If Convert.ToBoolean(dtrow("CHK")) = True Then
                        DT.Rows.Add(Val(dtrow("FROMNO")), Val(dtrow("FROMSRNO")), dtrow("ITEMNAME"), dtrow("LOTNO"), dtrow("REELNO"), Val(dtrow("GSM")), dtrow("GSMDETAILS"), Val(dtrow("SIZE")), Val(dtrow("QTY")), dtrow("UNIT"), Val(dtrow("ROLLWT")), dtrow("BARCODE"), dtrow("FROMTYPE"), dtrow("ROLLOD"), dtrow("ROLLID"))

                    End If
                Next
                Me.Close()

            Else

                DT.Columns.Add("FROMNO")
                DT.Columns.Add("FROMSRNO")
                DT.Columns.Add("ITEMNAME")
                DT.Columns.Add("LOTNO")
                DT.Columns.Add("REELNO")
                DT.Columns.Add("GSM")
                DT.Columns.Add("GSMDETAILS")
                DT.Columns.Add("SIZE")
                DT.Columns.Add("QTY")
                DT.Columns.Add("UNIT")
                DT.Columns.Add("ROLLWT")
                DT.Columns.Add("BARCODE")
                DT.Columns.Add("FROMTYPE")
                DT.Columns.Add("ROLLOD")
                DT.Columns.Add("ROLLID")



                For i As Integer = 0 To gridbill.RowCount - 1
                    Dim dtrow As DataRow = gridbill.GetDataRow(i)
                    If Convert.ToBoolean(dtrow("CHK")) = True Then
                        DT.Rows.Add(Val(dtrow("FROMNO")), Val(dtrow("FROMSRNO")), dtrow("ITEMNAME"), dtrow("LOTNO"), dtrow("REELNO"), Val(dtrow("GSM")), dtrow("GSMDETAILS"), Val(dtrow("SIZE")), Val(dtrow("QTY")), dtrow("UNIT"), Val(dtrow("ROLLWT")), dtrow("BARCODE"), dtrow("FROMTYPE"), dtrow("ROLLOD"), dtrow("ROLLID"))

                    End If
                Next
                Me.Close()

            End If

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