﻿Imports System.ComponentModel
Imports Newtonsoft.Json.Linq
    Imports BL
    Imports System.IO

    Public Class SendWhatsapp

        Public PARTYNAME As String = ""
        Public AGENTNAME As String = ""
        Public OTHERNAME1 As String = ""
        Public OTHERNAME2 As String = ""
        Public OTHERNAME3 As String = ""
        Public PATH As New ArrayList
        Public FILENAME As New ArrayList
        Dim RESPONSE As String = ""
        Public FRMSTRING As String = ""

        Public MSG As String = ""

        Private Sub cmdcancel_Click(sender As Object, e As EventArgs) Handles cmdcancel.Click
            Me.Close()
        End Sub

        Public Sub SendWhatsapp_Load(sender As Object, e As EventArgs) Handles Me.Load
            Try

                If FRMSTRING = "DIRECTWHATSAPP" Then FILLGRID()


                'IF AUTOCC IS TRUE THEN GET THE MOBILE NO FROM CMPMASTER AND SHOW IN AUTOCC
                Dim OBJCMN As New ClsCommon
                Dim DT As New DataTable
                If WHATSAPPAUTOCC = True Then
                    DT = OBJCMN.SEARCH("ISNULL(CMP_TEL,'') AS MOBILENO", "", " CMPMASTER ", " AND CMP_ID = " & CmpId)
                    If DT.Rows.Count > 0 Then TXTAUTOCC.Text = DT.Rows(0).Item("MOBILENO")
                End If

                TXTMESSAGE.Text = MSG

                fillname(CMBNAME, False, "")
                fillname(CMBAGENTNAME, False, " AND GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors' AND LEDGERS.ACC_TYPE='AGENT'")
                fillname(CMBOTHERNAME1, False, "")
                fillname(CMBOTHERNAME2, False, "")
                fillname(CMBOTHERNAME3, False, "")

                CMBNAME.Text = PARTYNAME
                CMBAGENTNAME.Text = AGENTNAME
                CMBOTHERNAME1.Text = OTHERNAME1
                CMBOTHERNAME2.Text = OTHERNAME2
                CMBOTHERNAME3.Text = OTHERNAME3

                'GETSALESMAN NO FOR KOTHARI
                If ClientName = "KOTHARI" Or ClientName = "KOTHARINEW" Then
                    DT = OBJCMN.Execute_Any_String("SELECT ISNULL(SALESMAN_MOBILENO,'') AS MOBILENO FROM LEDGERS INNER JOIN SALESMANMASTER ON LEDGERS.ACC_SALESMANID = SALESMAN_ID WHERE LEDGERS.ACC_CMPNAME = '" & PARTYNAME & "' AND LEDGERS.ACC_YEARID = " & YearId, "", "")
                    If DT.Rows.Count > 0 Then TXTOTHERNO2.Text = DT.Rows(0).Item("MOBILENO")
                End If


                Dim EN As New CancelEventArgs
                If PARTYNAME <> "" Then CMBNAME_Validating(CMBNAME, EN)
                If AGENTNAME <> "" Then CMBAGENTNAME_Validating(CMBAGENTNAME, EN)
                If OTHERNAME1 <> "" Then CMBOTHERNAME1_Validating(CMBOTHERNAME1, EN)
                If OTHERNAME2 <> "" Then CMBOTHERNAME2_Validating(CMBOTHERNAME2, EN)
                If OTHERNAME3 <> "" Then CMBOTHERNAME3_Validating(CMBOTHERNAME3, EN)

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Sub FILLGRID()
            Try

                Dim objclsCMST As New ClsCommonMaster
                Dim dt As DataTable = objclsCMST.search(" CAST(0 AS BIT) AS CHK, ISNULL(LEDGERS.Acc_cmpname, '') AS NAME, ISNULL(GROUPMASTER.group_name, '') AS [GROUP], ISNULL(CITYMASTER.city_name, '') AS CITY,  ISNULL(AREAMASTER.area_name, '') AS AREA, ISNULL(LEDGERS.ACC_WHATSAPPNO, '') AS WHATSAPP, ISNULL(GROUPOFCOMPANIESMASTER.GOC_NAME, '') AS GRPCOM ", "", " GROUPMASTER RIGHT OUTER JOIN LEDGERS LEFT OUTER JOIN GROUPOFCOMPANIESMASTER ON LEDGERS.ACC_GOCID = GROUPOFCOMPANIESMASTER.GOC_ID LEFT OUTER JOIN AREAMASTER ON LEDGERS.Acc_areaid = AREAMASTER.area_id LEFT OUTER JOIN CITYMASTER ON LEDGERS.Acc_cityid = CITYMASTER.city_id ON GROUPMASTER.group_id = LEDGERS.Acc_groupid ", " AND GROUPMASTER.GROUP_SECONDARY IN ('SUNDRY CREDITORS', 'SUNDRY DEBTORS')  AND LEDGERS.ACC_WHATSAPPNO <> '' and acc_yearid = " & YearId)
                gridbilldetails.DataSource = dt
                If dt.Rows.Count > 0 Then
                    gridbill.FocusedRowHandle = gridbill.RowCount - 1
                    gridbill.TopRowIndex = gridbill.RowCount - 15
                End If

        Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub CMBNAME_Validating(sender As Object, e As CancelEventArgs) Handles CMBNAME.Validating
            Try
                If CMBNAME.Text.Trim <> "" Then namevalidate(CMBNAME, CMBCODE, e, Me, TXTADD, " ", "SUNDRY DEBTORS", "ACCOUNTS", "", "", TXTPARTYNO.Text)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub CMBAGENTNAME_Validating(sender As Object, e As CancelEventArgs) Handles CMBAGENTNAME.Validating
            Try
                If CMBAGENTNAME.Text.Trim <> "" Then namevalidate(CMBAGENTNAME, CMBCODE, e, Me, TXTADD, " AND GROUPMASTER.GROUP_SECONDARY = 'Sundry Creditors' AND LEDGERS.ACC_TYPE='AGENT'", "SUNDRY CREDITORS", "ACCOUNTS", "", "", TXTAGENTNO.Text)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub CMBOTHERNAME1_Validating(sender As Object, e As CancelEventArgs) Handles CMBOTHERNAME1.Validating
            Try
                If CMBOTHERNAME1.Text.Trim <> "" Then namevalidate(CMBOTHERNAME1, CMBCODE, e, Me, TXTADD, "", "SUNDRY DEBTORS", "ACCOUNTS", "", "", TXTOTHERNO1.Text)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub CMBOTHERNAME2_Validating(sender As Object, e As CancelEventArgs) Handles CMBOTHERNAME2.Validating
            Try
                If CMBOTHERNAME2.Text.Trim <> "" Then namevalidate(CMBOTHERNAME2, CMBCODE, e, Me, TXTADD, "", "SUNDRY DEBTORS", "ACCOUNTS", "", "", TXTOTHERNO2.Text)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub CMBOTHERNAME3_Validating(sender As Object, e As CancelEventArgs) Handles CMBOTHERNAME3.Validating
            Try
                If CMBOTHERNAME3.Text.Trim <> "" Then namevalidate(CMBOTHERNAME3, CMBCODE, e, Me, TXTADD, "", "SUNDRY DEBTORS", "ACCOUNTS", "", "", TXTOTHERNO3.Text)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Async Sub CMDSEND_Click(sender As Object, e As EventArgs) Handles CMDSEND.Click
            Try

                'FIRST CHECK STATUS OF MOBILE CONNECTION
                Dim CONNECTSTATUS As String = JObject.Parse(Await CHECKMOBILECONNECTSTATUS())("success")
                If CONNECTSTATUS = "False" Then
                    MsgBox("Mobile Not connected, Please Check Connection", MsgBoxStyle.Critical)
                    Exit Sub
                End If

            If PATH.Count = 0 Then Exit Sub


                For I As Integer = 0 To PATH.Count - 1
                    If TXTPARTYNO.Text.Trim <> "" Then
                        RESPONSE = Await SENDWHATSAPPATTACHMENT("91" & TXTPARTYNO.Text.Trim, PATH(I), FILENAME(I))
                        ERRORMESSAGE(TXTPARTYNO.Text)
                    End If
                    If TXTAGENTNO.Text.Trim <> "" Then
                        RESPONSE = Await SENDWHATSAPPATTACHMENT("91" & TXTAGENTNO.Text.Trim, PATH(I), FILENAME(I))
                        ERRORMESSAGE(TXTAGENTNO.Text)
                    End If
                    If TXTOTHERNO1.Text.Trim <> "" Then
                        RESPONSE = Await SENDWHATSAPPATTACHMENT("91" & TXTOTHERNO1.Text.Trim, PATH(I), FILENAME(I))
                        ERRORMESSAGE(TXTOTHERNO1.Text)
                    End If
                    If TXTOTHERNO2.Text.Trim <> "" Then
                        RESPONSE = Await SENDWHATSAPPATTACHMENT("91" & TXTOTHERNO2.Text.Trim, PATH(I), FILENAME(I))
                        ERRORMESSAGE(TXTOTHERNO2.Text)
                    End If
                    If TXTOTHERNO3.Text.Trim <> "" Then
                        RESPONSE = Await SENDWHATSAPPATTACHMENT("91" & TXTOTHERNO3.Text.Trim, PATH(I), FILENAME(I))
                        ERRORMESSAGE(TXTOTHERNO3.Text)
                    End If
                    If TXTAUTOCC.Text.Trim <> "" Then
                        RESPONSE = Await SENDWHATSAPPATTACHMENT("91" & TXTAUTOCC.Text.Trim, PATH(I), FILENAME(I))
                        ERRORMESSAGE(TXTAUTOCC.Text)
                    End If


                    'SENDING WHATSAPP TO MULTIPLE LEDGERS SELECTED
                    If FRMSTRING = "DIRECTWHATSAPP" Then
                        For J As Integer = 0 To gridbill.RowCount - 1
                            Dim dtrow As DataRow = gridbill.GetDataRow(J)
                            If Convert.ToBoolean(dtrow("CHK")) = True Then
                                RESPONSE = Await SENDWHATSAPPATTACHMENT("91" & dtrow("WHATSAPP"), PATH(I), FILENAME(I))
                                ERRORMESSAGE(dtrow("WHATSAPP"))
                            End If
                        Next
                    End If
                Next


                'DELETE ALL THE FILES IN PATH ARRAY
                If FRMSTRING = "DIRECTWHATSAPP" Then
                    For I As Integer = 0 To PATH.Count - 1
                        If File.Exists(PATH(I)) Then File.Delete(PATH(I))
                    Next
                End If


                'TEXT MESSAGE SHOULD BE SEND ONLY ONCE
                If TXTMESSAGE.Text.Trim <> "" Then
                    If TXTPARTYNO.Text.Trim <> "" Then Await SENDWHATSAPPMESSAGE("91" & TXTPARTYNO.Text.Trim, TXTMESSAGE.Text.Trim)
                    If TXTAGENTNO.Text.Trim <> "" Then Await SENDWHATSAPPMESSAGE("91" & TXTAGENTNO.Text.Trim, TXTMESSAGE.Text.Trim)
                    If TXTOTHERNO1.Text.Trim <> "" Then Await SENDWHATSAPPMESSAGE("91" & TXTOTHERNO1.Text.Trim, TXTMESSAGE.Text.Trim)
                    If TXTOTHERNO2.Text.Trim <> "" Then Await SENDWHATSAPPMESSAGE("91" & TXTOTHERNO2.Text.Trim, TXTMESSAGE.Text.Trim)
                    If TXTOTHERNO3.Text.Trim <> "" Then Await SENDWHATSAPPMESSAGE("91" & TXTOTHERNO3.Text.Trim, TXTMESSAGE.Text.Trim)
                    If TXTAUTOCC.Text.Trim <> "" Then Await SENDWHATSAPPMESSAGE("91" & TXTAUTOCC.Text.Trim, TXTMESSAGE.Text.Trim)

                    'SENDING WHATSAPP TO MULTIPLE LEDGERS SELECTED
                    If FRMSTRING = "DIRECTWHATSAPP" Then
                        For J As Integer = 0 To gridbill.RowCount - 1
                            Dim dtrow As DataRow = gridbill.GetDataRow(J)
                            If Convert.ToBoolean(dtrow("CHK")) = True Then
                                RESPONSE = Await SENDWHATSAPPMESSAGE("91" & dtrow("WHATSAPP"), TXTMESSAGE.Text.Trim)
                            End If
                        Next
                    End If
                End If


                MsgBox("Message Sent", MsgBoxStyle.Information)
                Me.Close()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Sub ERRORMESSAGE(NO As String)
            Try
                If RESPONSE <> "" Then
                    Dim STATUS As String = JObject.Parse(RESPONSE)("success")
                    Dim ERRORMSG As String = JObject.Parse(RESPONSE)("message")
                    If STATUS = "False" Then MsgBox("Error While Sending Msg to " & NO & ", Error - " & ERRORMSG & ", Response - " & RESPONSE)
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

    Private Sub SendWhatsapp_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try
            If FRMSTRING = "DIRECTWHATSAPP" Then TabControl1.Visible = True
        Catch ex As Exception
            Throw ex
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