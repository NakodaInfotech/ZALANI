
Imports BL
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Windows.Forms
Imports System.IO

Public Class GRNDesign

    Public FORMULA As String

    Dim RPTQC As New QCReport
    Dim RPTQCTEST As New QCReport
    Dim RPTFINALQC As New FinalQCReport
    Dim RPTFINALQCTEST As New FinalQCReport

    Dim TEMPATTACHMENT As String
    Dim ConInfo As New CrystalDecisions.Shared.TableLogOnInfo
    Dim expo As New ExportOptions
    Dim oDfDopt As New DiskFileDestinationOptions

    Public FRMSTRING As String
    Public PERIOD As String
    Public PARTYNAME As String
    Public AGENTNAME As String
    Public GRNNO As Integer

    Public PRINTSETTING As Object = Nothing
    Public DIRECTPRINT As Boolean = False
    Public DIRECTMAIL As Boolean = False
    Public DIRECTWHATSAPP As Boolean = False
    Public NOOFCOPIES As Integer = 1

    Private Sub GRNDesign_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.Control = True And e.KeyCode = Keys.P Then
            CRPO.PrintReport()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub GRNDesign_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try

            If DIRECTPRINT = True Then
                PRINTDIRECTLYTOPRINTER()
                Exit Sub
            End If

            Cursor.Current = Cursors.WaitCursor

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

            If FRMSTRING = "QC" Then
                crTables = RPTQC.Database.Tables
            ElseIf FRMSTRING = "QCTEST" Then
                crTables = RPTQCTEST.Database.Tables
            ElseIf FRMSTRING = "FINALQC" Then
                crTables = RPTFINALQC.Database.Tables
            ElseIf FRMSTRING = "FINALQCTEST" Then
                crTables = RPTFINALQCTEST.Database.Tables
            End If

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next

            crpo.SelectionFormula = FORMULA

            If FRMSTRING = "QC" Then
                crpo.ReportSource = RPTQC
            ElseIf FRMSTRING = "QCTEST" Then
                crpo.ReportSource = RPTQCTEST
            ElseIf FRMSTRING = "FINALQC" Then
                crpo.ReportSource = RPTFINALQC
            ElseIf FRMSTRING = "FINALQCTEST" Then
                crpo.ReportSource = RPTFINALQCTEST
            End If



            '************************ END *******************
            crpo.Zoom(100)
            crpo.Refresh()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub sendmailtool_Click(sender As Object, e As EventArgs) Handles sendmailtool.Click
        Try
            Dim emailid As String = ""
            Dim emailid1 As String = ""
            Windows.Forms.Cursor.Current = Cursors.WaitCursor
            Transfer()
            Dim tempattachment As String

            Dim objmail As New SendMail

            If PARTYNAME <> "" Then
                Dim OBJCMN As New ClsCommon
                Dim dt As DataTable = OBJCMN.SEARCH("ACC_EMAIL AS EMAILID", "", "LEDGERS", " and ACC_CMPNAME = '" & PARTYNAME & "' AND ACC_YEARID=" & YearId)
                If dt.Rows.Count > 0 Then
                    emailid = dt.Rows(0).Item(0).ToString
                End If
            End If

            tempattachment = "QC"
            objmail.subject = "Quality Check"


            objmail.attachment = tempattachment
            objmail.attachment = Application.StartupPath & "\" & tempattachment & ".PDF"
            If emailid <> "" Then objmail.cmbfirstadd.Text = emailid
            If emailid1 <> "" Then objmail.cmbsecondadd.Text = emailid1
            objmail.Show()
            objmail.BringToFront()
            Windows.Forms.Cursor.Current = Cursors.Arrow

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PRINTDIRECTLYTOPRINTER()
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

            If FRMSTRING = "QC" Then
                OBJ = New QCReport
            ElseIf FRMSTRING = "QCTEST" Then
                OBJ = New QCReport
            ElseIf FRMSTRING = "FINALQC" Then
                OBJ = New FinalQCReport
            ElseIf FRMSTRING = "FINALQCTEST" Then
                OBJ = New FinalQCReport
            End If

SKIPINVOICE:
            crTables = OBJ.Database.Tables

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next

            OBJ.RecordSelectionFormula = FORMULA
            OBJ.REFRESH()

            If DIRECTMAIL = False And DIRECTWHATSAPP = False Then
                OBJ.PrintOptions.PrinterName = PRINTSETTING.PrinterSettings.PrinterName
                OBJ.PrintToPrinter(Val(NOOFCOPIES), True, 0, 0)
            Else
                Dim expo As New ExportOptions
                Dim oDfDopt As New DiskFileDestinationOptions
                oDfDopt.DiskFileName = Application.StartupPath & "\QC_" & GRNNO & ".pdf"
                If File.Exists(oDfDopt.DiskFileName) Then File.Delete(oDfDopt.DiskFileName)
                expo = OBJ.ExportOptions
                OBJ.DataDefinition.FormulaFields("SENDMAIL").Text = 1
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                OBJ.Export()
                OBJ.DataDefinition.FormulaFields("SENDMAIL").Text = 0
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub Transfer()
        Try
            Dim expo As New ExportOptions
            Dim oDfDopt As New DiskFileDestinationOptions

            If FRMSTRING = "QC" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\QC.PDF"
                expo = RPTQC.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTQC.Export()

            ElseIf FRMSTRING = "QCTEST" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\QC.PDF"
                expo = RPTQCTEST.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTQCTEST.Export()

            ElseIf FRMSTRING = "FINALQC" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\QC.PDF"
                expo = RPTFINALQC.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTFINALQC.Export()

            ElseIf FRMSTRING = "FINALQCTEST" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\QC.PDF"
                expo = RPTFINALQCTEST.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTFINALQCTEST.Export()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub TOOLWHATSAPP_Click(sender As Object, e As EventArgs) Handles TOOLWHATSAPP.Click
        Try
            If ALLOWWHATSAPP = False Then Exit Sub
            Transfer()
            Dim OBJWHATSAPP As New SendWhatsapp
            OBJWHATSAPP.PATH.Add(Application.StartupPath & "\QC.PDF")
            OBJWHATSAPP.FILENAME.Add("QC.pdf")
            OBJWHATSAPP.ShowDialog()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class