
Imports System.IO
Imports BL
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class ProductionDesign

    Public FRMSTRING As String
    Public PRODNO As Integer
    Public PARTYNAME As String
    Public DIRECTPRINT As Boolean = False
    Public DIRECTMAIL As Boolean = False
    Public DIRECTWHATSAPP As Boolean = False
    Public PRINTSETTING As Object = Nothing
    Public NOOFCOPIES As Integer = 1
    Public FORMULA As String
    Dim strsearch As String = ""

    Dim OBJPRODISS As New ProdIssReport
    Dim OBJPRODREC As New ProdRecdReport

    Private Sub ProductionDesign_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.Control = True And e.KeyCode = Keys.P Then
            CRPO.PrintReport()
        ElseIf e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub ProductionDesign_Load(sender As Object, e As EventArgs) Handles Me.Load
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

            If FRMSTRING = "PRODISS" Then crTables = OBJPRODISS.Database.Tables
            If FRMSTRING = "PRODREC" Then crTables = OBJPRODREC.Database.Tables


            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next
            '************* END *******************

            CRPO.SelectionFormula = FORMULA
            If FRMSTRING = "PRODISS" Then
                CRPO.ReportSource = OBJPRODISS

            ElseIf FRMSTRING = "PRODREC" Then
                CRPO.ReportSource = OBJPRODREC

            End If

            CRPO.Zoom(100)
            CRPO.Refresh()


            'If FRMSTRING = "PRODISS" Then
            '    strsearch = strsearch & "  {PRODUCTISSUE.ISS_NO}= " & PRODNO & " and {PRODUCTISSUE.ISS_YEARID} = " & YearId
            '    CRPO.SelectionFormula = strsearch
            '    CRPO.ReportSource = OBJPRODISS

            'ElseIf FRMSTRING = "PRODREC" Then
            '    strsearch = strsearch & "  {PRODUCTRECEIVED.RECD_NO}= " & PRODNO & " and {PRODUCTRECEIVED.RECD_YEARID} = " & YearId
            '    CRPO.SelectionFormula = strsearch
            '    CRPO.ReportSource = OBJPRODREC
            'End If

            'CRPO.Zoom(100)
            'CRPO.Refresh()

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
            If FRMSTRING = "PRODISS" Then
                OBJ = New ProdIssReport
            ElseIf FRMSTRING = "PRODREC" Then
                OBJ = New ProdRecdReport
            End If


            crTables = OBJ.Database.Tables

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next

            OBJ.RecordSelectionFormula = FORMULA


            If DIRECTMAIL = False And DIRECTWHATSAPP = False Then
                OBJ.PrintOptions.PrinterName = PRINTSETTING.PrinterSettings.PrinterName
                OBJ.PrintToPrinter(Val(NOOFCOPIES), True, 0, 0)
            Else
                Dim expo As New ExportOptions
                Dim oDfDopt As New DiskFileDestinationOptions
                oDfDopt.DiskFileName = Application.StartupPath & "\PROD_" & PRODNO & ".pdf"

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
            tempattachment = "PROD_" & PRODNO
            objmail.subject = "PRODUCTION"

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
            oDfDopt.DiskFileName = Application.StartupPath & "\PROD_" & PRODNO & ".pdf"

            If FRMSTRING = "PRODISS" Then
                expo = OBJPRODISS.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                OBJPRODISS.Export()

            ElseIf FRMSTRING = "PRODREC" Then
                expo = OBJPRODREC.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                OBJPRODREC.Export()
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