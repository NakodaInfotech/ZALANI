
Imports BL
Imports System.Windows.Forms
Imports System.IO
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Printing
Imports DevExpress.XtraGrid.Views.Base

Public Class ItemDetails

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Public FRMSTRING As String

    Private Sub ItemDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.E Then       'for Saving
            Call cmdedit_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
            Me.Close()
        ElseIf (e.Control = True And e.KeyCode = Windows.Forms.Keys.N) Or (e.Alt = True And e.KeyCode = Windows.Forms.Keys.A) Then
            showform(False, "")
        End If
    End Sub

    Private Sub ItemDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'ITEM MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)
            fillgriditem()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try

    End Sub

    Sub fillgriditem(Optional ByVal WHERE As String = "")

        If USEREDIT = False And USERVIEW = False Then
            MsgBox("Insufficient Rights")
            Exit Sub
        End If

        Dim dttable As New DataTable
        Dim objClsCommon As New ClsCommonMaster
        dttable = objClsCommon.search(" ISNULL(ITEM_NAME, '') AS NAME, ISNULL(item_materialtype, '') AS MATERIAL, ISNULL(ITEM_BLOCKED, 0) AS BLOCKED, ISNULL(item_ITEMTYPE, '') AS ITEMTYPE", "", " ITEMMASTER ", " AND ITEM_FRMSTRING = '" & FRMSTRING & "' and Item_yearid = " & YearId & WHERE & " order by item_NAME")
        GRIDNAME.DataSource = dttable
    End Sub

    Sub getdetails(ByRef name As String)

        Dim dttable As New DataTable
        Dim objClsCommon As New ClsCommonMaster
        dttable = objClsCommon.search("  ISNULL(ITEMMASTER.item_id, 0) AS ITEMID, ISNULL(ITEMMASTER.ITEM_NAME, '') AS NAME, ISNULL(ITEMMASTER.item_materialtype, '') AS MATERIAL, ISNULL(ITEMMASTER.ITEM_NAME, '') AS NAME, ISNULL(ITEMMASTER.ITEM_RATE, 0) AS RATE, ISNULL(ITEMMASTER.ITEM_BLOCKED, 0) AS BLOCKED, ISNULL(ITEMMASTER.ITEM_FRMSTRING, '') AS FRMSTRING, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT,  ISNULL(HSNMASTER.HSN_CODE, '') AS HSNCODE, ISNULL(ITEMMASTER_DESC.ITEM_QUALITY, '0') AS QTY, ISNULL(ITEMMASTER_1.ITEM_NAME, '') AS GRIDITEMNAME, ISNULL(ITEMMASTER.item_ITEMTYPE, '')  AS ITEMTYPE", "", "ITEMMASTER AS ITEMMASTER_1 RIGHT OUTER JOIN ITEMMASTER_DESC ON ITEMMASTER_1.item_id = ITEMMASTER_DESC.ITEM_ITEMID RIGHT OUTER JOIN ITEMMASTER ON ITEMMASTER_DESC.ITEM_ID = ITEMMASTER.item_id LEFT OUTER JOIN HSNMASTER ON ITEMMASTER.ITEM_HSNCODEID = HSNMASTER.HSN_ID LEFT OUTER JOIN UNITMASTER ON ITEMMASTER.item_unitid = UNITMASTER.unit_id", " and ITEMMASTER.Item_NAME = '" & name & "' and ITEMMASTER.Item_yearid = " & YearId)
        cleartextbox()
        If dttable.Rows.Count > 0 Then
            For Each ROW As DataRow In dttable.Rows

                TXTCATEGORYS.Text = ROW("ITEMTYPE").ToString
                TXTITEMNAMES.Text = ROW("NAME").ToString
                TXTMATERIALS.Text = ROW("MATERIAL").ToString
                TXTHSNS.Text = ROW("HSNCODE").ToString
                TXTRATES.Text = Val(ROW("RATE").ToString)
                TXTGRIDITEMNAME.Text = ROW("GRIDITEMNAME").ToString
                TXTQTY.Text = ROW("QTY").ToString

            Next


            ''GET RATE FROM ITEMPRICELIST
            'Dim DTRATE As DataTable = objClsCommon.search("  RATE1, RATE2, RATE3, RATE4, RATE5, RATE6, RATE7, RATE8, RATE9, RATE10 ", "", " ITEMPRICELIST ", " AND ITEMID = " & dttable.Rows(0).Item("ITEMID") & " AND YEARID = " & YearId)
            'If DTRATE.Rows.Count > 0 Then
            '    TXTRATE1.Text = Val(DTRATE.Rows(0).Item("RATE1"))
            '    TXTRATE2.Text = Val(DTRATE.Rows(0).Item("RATE2"))
            '    TXTRATE3.Text = Val(DTRATE.Rows(0).Item("RATE3"))
            '    TXTRATE4.Text = Val(DTRATE.Rows(0).Item("RATE4"))
            '    TXTRATE5.Text = Val(DTRATE.Rows(0).Item("RATE5"))
            '    TXTRATE6.Text = Val(DTRATE.Rows(0).Item("RATE6"))
            '    TXTRATE7.Text = Val(DTRATE.Rows(0).Item("RATE7"))
            '    TXTRATE8.Text = Val(DTRATE.Rows(0).Item("RATE8"))
            '    TXTRATE9.Text = Val(DTRATE.Rows(0).Item("RATE9"))
            '    TXTRATE10.Text = Val(DTRATE.Rows(0).Item("RATE10"))
            'End If
        End If

    End Sub

    Sub cleartextbox()
        txtmaterial.Clear()
        txtcategory.Clear()
        txtitemname.Clear()
        TXTRATE.Clear()
        TXTQTY.Clear()
        TXTGRIDITEMNAME.Clear()
        TXTHSNCODE.Clear()
        TXTRATE1.Clear()
        TXTRATE2.Clear()
        TXTRATE3.Clear()
        TXTRATE4.Clear()
        TXTRATE5.Clear()
        TXTRATE6.Clear()
        TXTRATE7.Clear()
        TXTRATE8.Clear()
        TXTRATE9.Clear()
        TXTRATE10.Clear()

    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdedit.Click
        Try
            showform(True, gridledger.GetFocusedRowCellValue("NAME"))
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub showform(ByVal editval As Boolean, ByVal name As String)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And gridledger.RowCount > 0) Then
                Dim objItemmaster As New ItemMaster
                objItemmaster.MdiParent = MDIMain
                objItemmaster.EDIT = editval
                objItemmaster.tempItemName = name
                objItemmaster.frmstring = FRMSTRING
                objItemmaster.Show()
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub


    Private Sub gridledger_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridledger.Click
        Try
            getdetails(gridledger.GetFocusedRowCellValue("NAME"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridledger_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridledger.DoubleClick
        Try
            showform(True, gridledger.GetFocusedRowCellValue("NAME"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridledger_FocusedRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles gridledger.FocusedRowChanged
        Try
            getdetails(gridledger.GetFocusedRowCellValue("NAME"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdadd.Click
        Try
            showform(False, "")
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMDREFRESH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDREFRESH.Click
        Try
            fillgriditem()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub



    Private Sub PBEXCEL_Click(sender As Object, e As EventArgs) Handles PBEXCEL.Click
        Try
            Dim OBJACC As New ItemExcelDetails
            OBJACC.MdiParent = MDIMain
            OBJACC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDUPDATERATE_Click(sender As Object, e As EventArgs) Handles CMDUPDATERATE.Click
        Try
            If gridledger.GetFocusedRowCellValue("NAME") = "" Then Exit Sub

            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.Execute_Any_String(" DELETE ITEMPRICELIST FROM ITEMPRICELIST INNER JOIN ITEMMASTER ON ITEMMASTER.ITEM_ID = ITEMPRICELIST.ITEMID WHERE ITEMMASTER.ITEM_NAME = '" & gridledger.GetFocusedRowCellValue("NAME") & "' AND ITEMMASTER.ITEM_YEARID = " & YearId, "", "")
            DT = OBJCMN.Execute_Any_String("INSERT INTO ITEMPRICELIST VALUES ((SELECT ISNULL(item_category, '') AS CATEGORY FROM ITEMMASTER WHERE ITEMMASTER.ITEM_NAME = '" & gridledger.GetFocusedRowCellValue("NAME") & "' AND ITEMMASTER.ITEM_YEARID = " & YearId & "), (SELECT ISNULL(ITEMMASTER.ITEM_ID,0) FROM ITEMMASTER WHERE ITEMMASTER.ITEM_NAME = '" & gridledger.GetFocusedRowCellValue("NAME") & "' AND ITEMMASTER.ITEM_YEARID = " & YearId & ")," & Val(TXTRATE1.Text.Trim) & "," & Val(TXTRATE2.Text.Trim) & "," & Val(TXTRATE3.Text.Trim) & "," & Val(TXTRATE4.Text.Trim) & "," & Val(TXTRATE5.Text.Trim) & "," & Val(TXTRATE6.Text.Trim) & "," & Val(TXTRATE7.Text.Trim) & "," & Val(TXTRATE8.Text.Trim) & "," & Val(TXTRATE9.Text.Trim) & "," & Val(TXTRATE10.Text.Trim) & "," & CmpId & "," & Userid & "," & YearId & ")", "", "")
            MsgBox("Rates Modified Successfully")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTCOPIES_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCOPIES.KeyPress
        numkeypress(e, sender, Me)
    End Sub
End Class