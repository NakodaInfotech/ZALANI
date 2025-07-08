
Imports BL
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Windows.Forms
Imports System.IO

Public Class StoresDesign

    Public FORMULA As String

    Dim RPTPO As New StoresPurchaseOrderReport
    Dim RPTINWARD As New StoresInwardReport
    Dim RPTCONSUME As New StoresConsumptionReport

    Dim tempattachment As String
    Dim ConInfo As New CrystalDecisions.Shared.TableLogOnInfo
    Dim expo As New ExportOptions
    Dim oDfDopt As New DiskFileDestinationOptions

    Public FRMSTRING As String
    Public PERIOD As String
    Public PARTYNAME As String
    Public PONO As Integer

    Public PRINTSETTING As Object = Nothing
    Public DIRECTPRINT As Boolean = False
    Public DIRECTMAIL As Boolean = False
    Public DIRECTWHATSAPP As Boolean = False
    Public NOOFCOPIES As Integer = 1

    Private Sub StoresDesign_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.Enter Then
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub StoresDesign_Load(sender As Object, e As EventArgs) Handles Me.Load
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

            If FRMSTRING = "POREPORT" Then
                crTables = RPTPO.Database.Tables
            ElseIf FRMSTRING = "INWARD" Then
                crTables = RPTINWARD.Database.Tables
            ElseIf FRMSTRING = "CONSUMPTION" Then
                crTables = RPTCONSUME.Database.Tables
            End If

            For Each crTable In crTables
                crtableLogonInfo = crTable.LogOnInfo
                crtableLogonInfo.ConnectionInfo = crConnecttionInfo
                crTable.ApplyLogOnInfo(crtableLogonInfo)
            Next

            crpo.SelectionFormula = FORMULA

            If FRMSTRING = "POREPORT" Then
                crpo.ReportSource = RPTPO
            ElseIf FRMSTRING = "INWARD" Then
                crpo.ReportSource = RPTINWARD
            ElseIf FRMSTRING = "CONSUMPTION" Then
                crpo.ReportSource = RPTCONSUME
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

    Private Sub sendmailtool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sendmailtool.Click
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

        If FRMSTRING = "POREPORT" Then
            tempattachment = "POREPORT"
            objmail.subject = "Purchase Order"
        ElseIf FRMSTRING = "INWARD" Then
            tempattachment = "INWARD"
            objmail.subject = "Stores Inward"
        ElseIf FRMSTRING = "CONSUMPTION" Then
            tempattachment = "CONSUMPTION"
            objmail.subject = "Stores Consumption"
        End If

        Try
            'Dim objmail As New SendMail
            objmail.attachment = tempattachment
            objmail.attachment = Application.StartupPath & "\" & tempattachment & ".PDF"
            If emailid <> "" Then objmail.cmbfirstadd.Text = emailid
            If emailid1 <> "" Then objmail.cmbsecondadd.Text = emailid1
            objmail.Show()
            objmail.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
        Windows.Forms.Cursor.Current = Cursors.Arrow
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

            If FRMSTRING = "POREPORT" Then
                OBJ = New POReport
            ElseIf FRMSTRING = "INWARD" Then
                OBJ = New StoresInwardReport
            ElseIf FRMSTRING = "CONSUMPTION" Then
                OBJ = New StoresConsumptionReport
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
                If FRMSTRING = "POREPORT" Then
                    oDfDopt.DiskFileName = Application.StartupPath & "\POREPORT_" & PONO & ".pdf"
                ElseIf FRMSTRING = "INWARD" Then
                    oDfDopt.DiskFileName = Application.StartupPath & "\INWARD_" & PONO & ".pdf"
                ElseIf FRMSTRING = "CONSUMPTION" Then
                    oDfDopt.DiskFileName = Application.StartupPath & "\CONSUME_" & PONO & ".pdf"
                End If
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

            If FRMSTRING = "POREPORT" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\POREPORT.PDF"
                expo = RPTPO.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTPO.Export()

            ElseIf FRMSTRING = "INWARD" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\INWARD.PDF"
                expo = RPTINWARD.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTINWARD.Export()

            ElseIf FRMSTRING = "CONSUMPTION" Then
                oDfDopt.DiskFileName = Application.StartupPath & "\CONSUME.PDF"
                expo = RPTCONSUME.ExportOptions
                expo.ExportDestinationType = ExportDestinationType.DiskFile
                expo.ExportFormatType = ExportFormatType.PortableDocFormat
                expo.DestinationOptions = oDfDopt
                RPTCONSUME.Export()
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
            OBJWHATSAPP.PATH.Add(Application.StartupPath & "\POREPORT.PDF")
            OBJWHATSAPP.FILENAME.Add("POREPORT.pdf")
            OBJWHATSAPP.ShowDialog()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class