﻿
Imports BL
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class PurchaseReturnChallanDetails
    Public EDIT As Boolean
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private Sub cmdexit_Click(sender As Object, e As EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub PurchaseReturnChallanDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.Escape Then
                Me.Close()
            ElseIf e.KeyCode = Keys.N And e.Control = True Then
                showform(False, 0)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub PurchaseReturnChallanDetails_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'PURCHASE RETURN'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub FILLGRID()
        Try
            Dim obj As New ClsCommonMaster
            Dim dt As DataTable
            dt = obj.search("ISNULL(PURCHASERETURNCHALLAN.PRCH_PONO, '') AS PONO, PURCHASERETURNCHALLAN.PRCH_PODATE AS PODATE, ISNULL(PURCHASERETURNCHALLAN.PRCH_PARTYREFNO, 0) AS PARTYREFNO, ISNULL(PURCHASERETURNCHALLAN.PRCH_NO, 0) AS PRCHNO, PURCHASERETURNCHALLAN.PRCH_DATE AS DATE, ISNULL(PURCHASERETURNCHALLAN.PRCH_CHALLANNO, '') AS CHALLANNO, PURCHASERETURNCHALLAN.PRCH_CHALLANDATE AS CHALLANDATE, ISNULL(PURCHASERETURNCHALLAN.PRCH_INVTYPE, '') AS INVTYPE, ISNULL(PURCHASERETURNCHALLAN.PRCH_TOTALQTY, 0) AS TOTALQTY, ISNULL(PURCHASERETURNCHALLAN.PRCH_TOTALREELNO, 0) AS TOTALREELNO, ISNULL(PURCHASERETURNCHALLAN.PRCH_REMARKS, '') AS REMARKS, PURCHASERETURNCHALLAN.PRCH_DONE AS DONE, ISNULL(PURCHASERETURNCHALLAN_DESC.PRCH_GRIDSRNO, 0) AS GRIDSRNO, ISNULL(PURCHASERETURNCHALLAN_DESC.PRCH_LOTNO, '') AS LOTNO, ISNULL(PURCHASERETURNCHALLAN_DESC.PRCH_REELNO, 0) AS REELNO, ISNULL(PURCHASERETURNCHALLAN_DESC.PRCH_GSM, '0') AS GSM, ISNULL(PURCHASERETURNCHALLAN_DESC.PRCH_SIZE, 0) AS SIZE, ISNULL(PURCHASERETURNCHALLAN_DESC.PRCH_QTY, 0) AS QTY, ISNULL(PURCHASERETURNCHALLAN_DESC.PRCH_GRIDDONE, 0) AS GRIDDONE, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(GODOWNMASTER.GODOWN_name, '') AS GODOWN, ISNULL(UNITMASTER.unit_abbr, '') AS UNIT, ISNULL(ITEMMASTER.ITEM_NAME, '') AS QUALITY", "", "LEDGERS RIGHT OUTER JOIN GODOWNMASTER RIGHT OUTER JOIN ITEMMASTER RIGHT OUTER JOIN PURCHASERETURNCHALLAN LEFT OUTER JOIN PURCHASERETURNCHALLAN_DESC ON PURCHASERETURNCHALLAN.PRCH_NO = PURCHASERETURNCHALLAN_DESC.PRCH_NO ON ITEMMASTER.item_id = PURCHASERETURNCHALLAN_DESC.PRCH_QUALITYID LEFT OUTER JOIN UNITMASTER ON PURCHASERETURNCHALLAN_DESC.PRCH_UNITID = UNITMASTER.unit_id ON GODOWNMASTER.GODOWN_id = PURCHASERETURNCHALLAN.PRCH_GODOWNID ON LEDGERS.Acc_id = PURCHASERETURNCHALLAN.PRCH_LEDGERID ")
            gridbilldetails.DataSource = dt
            If dt.Rows.Count > 0 Then
                gridbill.FocusedRowHandle = gridbill.RowCount - 1
                gridbill.TopRowIndex = gridbill.RowCount - 15
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Sub showform(ByVal editval As Boolean, ByVal PRCHNO As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim OBJPURCH As New PurchaseReturnChallan
                OBJPURCH.MdiParent = MDIMain
                OBJPURCH.EDIT = editval
                OBJPURCH.TEMPPRCHNO = PRCHNO
                OBJPURCH.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Try
            If USERADD = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If
            showform(False, 0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub gridpayment_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridbill.DoubleClick
        Try
            showform(True, gridbill.GetFocusedRowCellValue("PRCHNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("PRCHNO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TXTFROM_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTFROM.Validated
        If TXTFROM.Text.Trim <> "" Then TXTTO.Focus()
    End Sub

    Private Sub TXTCOPIES_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TXTCOPIES.Validating
        If Val(TXTCOPIES.Text.Trim) <= 0 Then TXTCOPIES.Text = 1
    End Sub

    Private Sub TXTFROM_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTFROM.KeyPress, TXTTO.KeyPress, TXTCOPIES.KeyPress
        numkeypress(e, sender, Me)
    End Sub

    Private Sub ToolStripButton9_Click(sender As Object, e As EventArgs) Handles ToolStripButton9.Click
        Try
            Dim OBJ As New PurchaseReturnGridDetails
            OBJ.MdiParent = MDIMain
            OBJ.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    'Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
    '    Try
    '        'IF WE HAVE SELECTED FROM AND TO THEN WORK WITH THE CURRENT CODE ELSE GO FOR SELECTED ENTRIES CODE
    '        If Val(TXTFROM.Text.Trim) > 0 And Val(TXTTO.Text.Trim) > 0 Then
    '            If Val(TXTFROM.Text.Trim) > Val(TXTTO.Text.Trim) Then
    '                MsgBox("Enter Proper Challan Nos", MsgBoxStyle.Critical)
    '                Exit Sub
    '            End If
    '            If MsgBox("Wish to Print Challan from " & TXTFROM.Text.Trim & " To " & TXTTO.Text.Trim & " ?", MsgBoxStyle.YesNo) = vbYes Then
    '                If PRINTDIALOG.ShowDialog = DialogResult.OK Then PRINTDOC.PrinterSettings = PRINTDIALOG.PrinterSettings
    '                serverprop(Val(TXTFROM.Text.Trim), Val(TXTTO.Text.Trim), Val(TXTCOPIES.Text.Trim))
    '            End If
    '        Else
    '            If MsgBox("Wish to Print Selected Challan ?", MsgBoxStyle.YesNo) = vbYes Then
    '                If PRINTDIALOG.ShowDialog = DialogResult.OK Then PRINTDOC.PrinterSettings = PRINTDIALOG.PrinterSettings
    '                cmdok.Focus()
    '                SERVERPROPSELECTED(Val(TXTFROM.Text.Trim), Val(TXTTO.Text.Trim), Val(TXTCOPIES.Text.Trim))
    '            End If
    '        End If

    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub


    'Sub serverprop(ByVal fromno As Integer, ByVal tono As Integer, Optional ByVal NOOFCOPIES As Integer = 1, Optional ByVal FRMSTRING As String = "PRINT")
    '    Try
    '        Dim ALATTACHMENT As New ArrayList
    '        Dim FILENAME As New ArrayList

    '        For I As Integer = fromno To tono

    '            '**************** SET SERVER ************************
    '            Dim crParameterFieldDefinitions As ParameterFieldDefinitions
    '            Dim crParameterFieldDefinition As ParameterFieldDefinition
    '            Dim crParameterValues As New ParameterValues
    '            Dim crParameterDiscreteValue As New ParameterDiscreteValue

    '            Dim crtableLogonInfo As New TableLogOnInfo
    '            Dim crConnecttionInfo As New ConnectionInfo
    '            Dim crTables As Tables
    '            Dim crTable As Table

    '            With crConnecttionInfo
    '                .ServerName = SERVERNAME
    '                .DatabaseName = DatabaseName
    '                .UserID = DBUSERNAME
    '                .Password = Dbpassword
    '                .IntegratedSecurity = Dbsecurity
    '            End With

    '            Dim expo As New ExportOptions
    '            Dim oDfDopt As New DiskFileDestinationOptions

    '            Dim OBJ As Object = New PurchaseReturnChallanReport

    '            crTables = OBJ.Database.Tables
    '            For Each crTable In crTables
    '                crtableLogonInfo = crTable.LogOnInfo
    '                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
    '                crTable.ApplyLogOnInfo(crtableLogonInfo)
    '            Next

    '            OBJ.RecordSelectionFormula = "{PURCHASERETURNCHALLAN.PRCH_no}=" & Val(I) & " and {PURCHASERETURNCHALLAN.PRCH_yearid}=" & YearId

    '            If FRMSTRING = "PRINT" Then
    '                OBJ.PrintOptions.PrinterName = PRINTDIALOG.PrinterSettings.PrinterName
    '                OBJ.PrintOptions.PaperSize = PaperSize.DefaultPaperSize
    '                OBJ.PrintToPrinter(Val(NOOFCOPIES), True, 0, 0)
    '            Else
    '                oDfDopt.DiskFileName = Application.StartupPath & "\PRCH_" & I & ".pdf"
    '                expo = OBJ.ExportOptions
    '                expo.ExportDestinationType = ExportDestinationType.DiskFile
    '                expo.ExportFormatType = ExportFormatType.PortableDocFormat
    '                expo.DestinationOptions = oDfDopt
    '                OBJ.Export()
    '                ALATTACHMENT.Add(oDfDopt.DiskFileName)
    '                FILENAME.Add("PRCH_" & I & ".pdf")
    '            End If
    '        Next

    '        If FRMSTRING = "MAIL" Then
    '            Dim OBJMAIL As New SendMail
    '            OBJMAIL.ALATTACHMENT = ALATTACHMENT
    '            OBJMAIL.subject = "Purchase Return"
    '            OBJMAIL.ShowDialog()
    '        End If

    '        'If FRMSTRING = "WHATSAPP" = True Then
    '        '    Dim OBJWHATSAPP As New SendWhatsapp
    '        '    OBJWHATSAPP.PATH = ALATTACHMENT
    '        '    OBJWHATSAPP.FILENAME = FILENAME
    '        '    OBJWHATSAPP.ShowDialog()
    '        'End If

    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    'Sub SERVERPROPSELECTED(ByVal fromno As Integer, ByVal tono As Integer, Optional ByVal NOOFCOPIES As Integer = 1, Optional ByVal FRMSTRING As String = "PRINT")
    '    Try

    '        Dim ALATTACHMENT As New ArrayList
    '        Dim FILENAME As New ArrayList

    '        Dim SELECTEDROWS As Int32() = gridbill.GetSelectedRows()
    '        For I As Integer = 0 To gridbill.RowCount - 1
    '            Dim ROW As DataRow = gridbill.GetDataRow(I)
    '            If ROW("CHK") = True Then
    '                '**************** SET SERVER ************************
    '                Dim crParameterFieldDefinitions As ParameterFieldDefinitions
    '                Dim crParameterFieldDefinition As ParameterFieldDefinition
    '                Dim crParameterValues As New ParameterValues
    '                Dim crParameterDiscreteValue As New ParameterDiscreteValue

    '                Dim crtableLogonInfo As New TableLogOnInfo
    '                Dim crConnecttionInfo As New ConnectionInfo
    '                Dim crTables As Tables
    '                Dim crTable As Table

    '                With crConnecttionInfo
    '                    .ServerName = SERVERNAME
    '                    .DatabaseName = DatabaseName
    '                    .UserID = DBUSERNAME
    '                    .Password = Dbpassword
    '                    .IntegratedSecurity = Dbsecurity
    '                End With

    '                Dim expo As New ExportOptions
    '                Dim oDfDopt As New DiskFileDestinationOptions


    '                Dim OBJ As Object = New PurchaseReturnChallanReport

    '                crTables = OBJ.Database.Tables
    '                For Each crTable In crTables
    '                    crtableLogonInfo = crTable.LogOnInfo
    '                    crtableLogonInfo.ConnectionInfo = crConnecttionInfo
    '                    crTable.ApplyLogOnInfo(crtableLogonInfo)
    '                Next

    '                OBJ.RecordSelectionFormula = "{PURCHASERETURNCHALLAN.PRCH_no}=" & Val(ROW("PRCHNO")) & " and {PURCHASERETURNCHALLAN.PRCH_yearid}=" & YearId

    '                If FRMSTRING = "PRINT" Then
    '                    OBJ.PrintOptions.PrinterName = PRINTDIALOG.PrinterSettings.PrinterName
    '                    OBJ.PrintOptions.PaperSize = PaperSize.DefaultPaperSize
    '                    OBJ.PrintToPrinter(Val(NOOFCOPIES), True, 0, 0)
    '                Else
    '                    oDfDopt.DiskFileName = Application.StartupPath & "\PRCH_" & ROW("PRCHNO") & ".pdf"
    '                    expo = OBJ.ExportOptions
    '                    expo.ExportDestinationType = ExportDestinationType.DiskFile
    '                    expo.ExportFormatType = ExportFormatType.PortableDocFormat
    '                    expo.DestinationOptions = oDfDopt
    '                    OBJ.Export()
    '                    ALATTACHMENT.Add(oDfDopt.DiskFileName)
    '                    FILENAME.Add("PRCH_" & ROW("PRCHNO") & ".pdf")
    '                End If

    '            End If
    '        Next

    '        If FRMSTRING = "MAIL" Then
    '            Dim OBJMAIL As New SendMail
    '            OBJMAIL.ALATTACHMENT = ALATTACHMENT
    '            OBJMAIL.subject = "Purchase Return"
    '            OBJMAIL.ShowDialog()
    '        End If

    '        If FRMSTRING = "WHATSAPP" = True Then
    '            Dim OBJWHATSAPP As New SendWhatsapp
    '            OBJWHATSAPP.PATH = ALATTACHMENT
    '            OBJWHATSAPP.FILENAME = FILENAME
    '            OBJWHATSAPP.ShowDialog()
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Private Sub TOOLGRIDDETAILS_Click(sender As Object, e As EventArgs) Handles TOOLGRIDDETAILS.Click
        Try
            Dim OBJ As New PurchaseReturnGridDetails
            OBJ.MdiParent = MDIMain
            OBJ.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Try
            FILLGRID()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        Try
            Dim PATH As String = Application.StartupPath & "\Purchase Return Challan Details.XLS"
            Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
            opti.ShowGridLines = True
            opti.SheetName = "Purchase Return Challan Details"
            gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, "Purchase Return Challan Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
            MsgBox("Purchase Return Challan Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
        End Try
    End Sub

    'Private Sub TOOLWHATSAPP_Click(sender As Object, e As EventArgs) Handles TOOLWHATSAPP.Click
    '    Try
    '        If Val(TXTFROM.Text.Trim) > 0 And Val(TXTTO.Text.Trim) > 0 Then
    '            If Val(TXTFROM.Text.Trim) > Val(TXTTO.Text.Trim) Then
    '                MsgBox("Enter Proper Purchase Return Challan Nos", MsgBoxStyle.Critical)
    '                Exit Sub
    '            Else
    '                If MsgBox("Wish to Whatsapp Purchase Return Challan from " & Val(TXTFROM.Text.Trim) & " To " & Val(TXTTO.Text.Trim) & " ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
    '                serverprop(Val(TXTFROM.Text.Trim), Val(TXTTO.Text.Trim), Val(TXTCOPIES.Text.Trim), "WHATSAPP")
    '            End If
    '        Else
    '            If MsgBox("Wish to Whatsapp Selected Purchase Return Challan ?", MsgBoxStyle.YesNo) = vbYes Then
    '                cmdok.Focus()
    '                SERVERPROPSELECTED(Val(TXTFROM.Text.Trim), Val(TXTTO.Text.Trim), Val(TXTCOPIES.Text.Trim), "WHATSAPP")
    '            End If
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    'Private Sub TOOLMAIL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOOLMAIL.Click
    '    Try
    '        If Val(TXTFROM.Text.Trim) > 0 And Val(TXTTO.Text.Trim) > 0 Then
    '            If Val(TXTFROM.Text.Trim) > Val(TXTTO.Text.Trim) Then
    '                MsgBox("Enter Proper Challan Nos", MsgBoxStyle.Critical)
    '                Exit Sub
    '            Else
    '                If MsgBox("Wish to Mail Purchase Return Challan from " & Val(TXTFROM.Text.Trim) & " To " & Val(TXTTO.Text.Trim) & " ?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
    '                serverprop(Val(TXTFROM.Text.Trim), Val(TXTTO.Text.Trim), Val(TXTCOPIES.Text.Trim), "MAIL")
    '            End If
    '        Else
    '            If MsgBox("Wish to Mail Selected Purchase Return Challan ?", MsgBoxStyle.YesNo) = vbYes Then
    '                cmdok.Focus()
    '                SERVERPROPSELECTED(Val(TXTFROM.Text.Trim), Val(TXTTO.Text.Trim), Val(TXTCOPIES.Text.Trim), "MAIL")
    '            End If
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub
End Class