
Imports System.IO
Imports BL
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class SaleInvoiceDesign

    Public FRMSTRING As String
    Public INVNO As Integer
    Public REGNAME As String
    Public PARTYNAME As String
    Public FORMULA As String
    Public PROFORMANO As Integer
    Public DIRECTPRINT As Boolean = False
    Public DIRECTMAIL As Boolean = False
    Public DIRECTWHATSAPP As Boolean = False
    Public PRINTSETTING As Object = Nothing
    Public NOOFCOPIES As Integer = 1
    Public vendorname As String
    Public AGENTNAME As String
    Dim tempattachment As String
    Dim strsearch As String = ""

    Dim OBJSO As New SOReport

    Dim OBJPROFORMA As New ProformaInvoiceReport
    Dim OBJPACKINGSLIP As New PackingSlipReport


    Private Sub SaleInvoiceDesign_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.Control = True And e.KeyCode = Keys.P Then
            CRPO.PrintReport()
        End If
    End Sub

    Private Sub SaleInvoiceDesign_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try
            If DIRECTPRINT = True Then
                PRINTDIRECTADVICE()
                Exit Sub
            End If


            '**************** SET SERVER ************************
            Dim crtableLogonInfo As New TableLogOnInfo
            Dim crConnecttionInfo As New ConnectionInfo
            Dim crTables As Tables
            Dim crTable As Table


            With crConnecttionInfo
                .ServerName = SERVERNAME
                .DatabaseName = DatabaseName
                .UserID = DBUSERNAME
                .Password = Dbpassword
                .IntegratedSecurity = Dbsecurity
            End With

            If FRMSTRING = "PROFORMA" Then crTables = OBJPROFORMA.Database.Tables
            If FRMSTRING = "SALEORDER" Then crTables = OBJSO.Database.Tables
            If FRMSTRING = "PACKINGSLIP" Then crTables = OBJPACKINGSLIP.Database.Tables



            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next
            '************* END *******************

            If FRMSTRING = "PROFORMA" Then
                strsearch = strsearch & "  {PROFORMAINVOICEMASTER.INVOICE_NO}= " & INVNO & " and {PROFORMAINVOICEMASTER.INVOICE_YEARID} = " & YearId
                CRPO.SelectionFormula = strsearch
                CRPO.ReportSource = OBJPROFORMA
                OBJPROFORMA.DataDefinition.FormulaFields("SENDMAIL").Text = "1"


            ElseIf FRMSTRING = "SALEORDER" Then
                strsearch = strsearch & "  {SALEORDER.SO_NO}= " & INVNO & " and {SALEORDER.SO_YEARID} = " & YearId
                CRPO.SelectionFormula = strsearch
                CRPO.ReportSource = OBJSO


            ElseIf FRMSTRING = "PACKINGSLIP" Then
                strsearch = strsearch & "  {PACKINGSLIP.PS_NO}= " & INVNO & " and {PACKINGSLIP.PS_YEARID} = " & YearId
                CRPO.SelectionFormula = strsearch
                CRPO.ReportSource = OBJPACKINGSLIP
                OBJPACKINGSLIP.DataDefinition.FormulaFields("SENDMAIL").Text = "1"

            End If

            CRPO.Zoom(100)
            CRPO.Refresh()

        Catch Exp As LoadSaveReportException
            MsgBox("Incorrect path For loading report.",
                    MsgBoxStyle.Critical, "Load Report Error")
        Catch Exp As Exception
            MsgBox(Exp.Message, MsgBoxStyle.Critical, "General Error")

        End Try
    End Sub

    Sub PRINTDIRECTADVICE()
        Try
            Dim crParameterFieldDefinitions As ParameterFieldDefinitions
            Dim crParameterFieldDefinition As ParameterFieldDefinition
            Dim crParameterValues As New ParameterValues
            Dim crParameterDiscreteValue As New ParameterDiscreteValue

            '**************** SET SERVER ************************
            Dim crtableLogonInfo As New TableLogOnInfo
            Dim crConnecttionInfo As New ConnectionInfo
            Dim crTables As Tables
            Dim crTable As Table


            With crConnecttionInfo
                .ServerName = SERVERNAME
                .DatabaseName = DatabaseName
                .UserID = DBUSERNAME
                .Password = Dbpassword
                .IntegratedSecurity = Dbsecurity
            End With

            Dim OBJ As New Object
            If FRMSTRING = "PROFORMA" Then
                strsearch = "  {PROFORMAINVOICEMASTER.INVOICE_NO}= " & INVNO & " and {PROFORMAINVOICEMASTER.INVOICE_YEARID} = " & YearId
                OBJ = New ProformaInvoiceReport
                OBJ.DataDefinition.FormulaFields("SENDMAIL").Text = "1"

            ElseIf FRMSTRING = "SALEORDER" Then
                strsearch = "  {SALEORDER.SO_NO}= " & INVNO & " and {SALEORDER.SO_YEARID} = " & YearId
                OBJ = New SOReport


            ElseIf FRMSTRING = "PACKINGSLIP" Then
                strsearch = "  {PACKINGSLIP.PS_NO}= " & INVNO & " and {PACKINGSLIP.PS_YEARID} = " & YearId
                OBJ = New PackingSlipReport
                OBJ.DataDefinition.FormulaFields("SENDMAIL").Text = "1"

            End If

            crTables = OBJ.Database.Tables

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next

            OBJ.RecordSelectionFormula = strsearch


            If DIRECTMAIL = False And DIRECTWHATSAPP = False Then
                OBJ.PrintOptions.PrinterName = PRINTSETTING.PrinterSettings.PrinterName
                OBJ.PrintToPrinter(Val(NOOFCOPIES), True, 0, 0)
            Else
                Dim expo As New ExportOptions
                Dim oDfDopt As New DiskFileDestinationOptions
                If FRMSTRING = "PROFORMA" Then oDfDopt.DiskFileName = Application.StartupPath & "\" & PARTYNAME & "PROFORMA_" & INVNO & ".pdf"
                If FRMSTRING = "SALEORDER" Then oDfDopt.DiskFileName = Application.StartupPath & "\" & PARTYNAME & "SALEORDER_" & INVNO & ".pdf"
                If FRMSTRING = "PACKINGSLIP" Then oDfDopt.DiskFileName = Application.StartupPath & "\" & PARTYNAME & "PACKINGSLIP_" & INVNO & ".pdf"


                'CHECK WHETHER FILE IS PRESENT OR NOT, IF PRESENT THEN DELETE FIRST AND THEN EXPORT
                If File.Exists(oDfDopt.DiskFileName) Then File.Delete(oDfDopt.DiskFileName)
                OBJ.DataDefinition.FormulaFields("SENDMAIL").Text = "1"
                expo = OBJ.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                OBJ.Export()
                OBJ.DataDefinition.FormulaFields("SENDMAIL").Text = "0"
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub sendmailtool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sendmailtool.Click
        Try
            Dim emailid As String = ""
            Windows.Forms.Cursor.Current = Cursors.WaitCursor
            Transfer()
            Dim tempattachment As String = ""

            Dim objmail As New SendMail

            If FRMSTRING = "PROFORMA" Then
                tempattachment = PARTYNAME & "PROFORMA_" & INVNO
                objmail.subject = "PROFORAM INVOICE"

            ElseIf FRMSTRING = "PACKINGSLIP" Then
                tempattachment = PARTYNAME & "PACKINGSLIP_" & INVNO
                objmail.subject = "PACKINGSLIP"

            ElseIf FRMSTRING = "SALEORDER" Then
                tempattachment = PARTYNAME & "SALEORDER_" & INVNO
                objmail.subject = "SALE ORDER"

            End If

            'Dim objmail As New SendMail
            objmail.attachment = tempattachment
            objmail.attachment = Application.StartupPath & "\" & tempattachment & ".PDF"
            If emailid <> "" Then objmail.cmbfirstadd.Text = emailid
            objmail.Show()
            objmail.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
        Windows.Forms.Cursor.Current = Cursors.Arrow
    End Sub

    Sub Transfer()
        Try
            Dim expo As New ExportOptions
            Dim oDfDopt As New DiskFileDestinationOptions

            If FRMSTRING = "PROFORMA" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\" & PARTYNAME & "PROFORMA_" & INVNO & ".pdf"
                expo = OBJPROFORMA.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                OBJPROFORMA.Export()

            ElseIf FRMSTRING = "SALEORDER" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\" & PARTYNAME & "SALEORDER_" & INVNO & ".pdf"
                expo = OBJSO.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                OBJSO.Export()

            ElseIf FRMSTRING = "PACKINGSLIP" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\" & PARTYNAME & "PACKINGSLIP_" & INVNO & ".pdf"
                expo = OBJSO.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                OBJSO.Export()

            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub TOOLWHATSAPP_Click(sender As Object, e As EventArgs) Handles TOOLWHATSAPP.Click
        'Try
        '    If ALLOWWHATSAPP = False Then Exit Sub
        '    Transfer()

        '    If FRMSTRING = "" Then
        '        tempattachment = PARTYNAME & "_PIREPORT"
        '    ElseIf FRMSTRING = "PIREPORT" Or FRMSTRING = "SOCAD" Then
        '        tempattachment = PARTYNAME & "_PIREPORT"
        '    ElseIf FRMSTRING = "SCHEDULEREPORT" Then
        '        tempattachment = "SCHEDULEREPORT"
        '    ElseIf FRMSTRING = "SAMPLENOTE" Then
        '        tempattachment = "SAMPLENOTE"
        '    ElseIf FRMSTRING = "SAMPLEPRICELIST" Then
        '        tempattachment = "SAMPLEPRICELIST"
        '    End If

        '    Dim OBJWHATSAPP As New SendWhatsapp
        '    OBJWHATSAPP.PARTYNAME = PARTYNAME
        '    If ClientName <> "MAHAVIRPOLYCOT" Then OBJWHATSAPP.AGENTNAME = AGENTNAME
        '    ' If PARTYNAME <> SHIPTONAME Then OBJWHATSAPP.OTHERNAME1 = SHIPTONAME
        '    OBJWHATSAPP.PATH.Add(Application.StartupPath & "\" & tempattachment & ".PDF")
        '    OBJWHATSAPP.FILENAME.Add(tempattachment & ".pdf")
        '    OBJWHATSAPP.ShowDialog()
        'Catch ex As Exception
        '    Throw ex
        'End Try
    End Sub
End Class