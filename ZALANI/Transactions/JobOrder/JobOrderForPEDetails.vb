
Imports BL
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Public Class JobOrderForPEDetails


    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
        Public TEMPJONO As String
    Private Sub JobOrderForPEDetails_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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

    Private Sub JobOrderForPEDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'JOB WORK'")
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

    Private Sub TOOLREFRESH_Click(sender As Object, e As EventArgs) Handles TOOLREFRESH.Click
            Try
                FILLGRID()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
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

        Sub FILLGRID()
            Try
            Dim OBJDEPT As New ClsJobOrderForPE
            OBJDEPT.alParaval.Add(0)
                OBJDEPT.alParaval.Add(CmpId)
                OBJDEPT.alParaval.Add(YearId)
                Dim DT As DataTable = OBJDEPT.selectJOPE(0, CmpId, YearId)
                gridbilldetails.DataSource = DT
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub cmdexit_Click(sender As Object, e As EventArgs) Handles cmdexit.Click
            Me.Close()
        End Sub

        Sub showform(ByVal editval As Boolean, ByVal TEMPJONO As Integer)
            Try
                If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If

                If (editval = False) Or (editval = True And gridbill.RowCount > 0) Then
                Dim objgdn As New JobOrderForPE
                objgdn.MdiParent = MDIMain
                    objgdn.EDIT = editval
                    objgdn.TEMPJONO = TEMPJONO
                    objgdn.Show()
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
        Private Sub gridbilldetails_DoubleClick(sender As Object, e As EventArgs) Handles gridbilldetails.DoubleClick
            Try
                showform(True, gridbill.GetFocusedRowCellValue("TEMPJONO"))
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

    Private Sub TOOLPRINT_Click(sender As Object, e As EventArgs) Handles TOOLPRINT.Click
        Try
            If (Val(TXTFROM.Text.Trim) = 0 Or Val(TXTTO.Text.Trim) = 0 Or Val(TXTCOPIES.Text.Trim) = 0) AndAlso gridbill.SelectedRowsCount = 0 Then Exit Sub


            'IF WE HAVE SELECTED FROM AND TO THEN WORK WITH THE CURRENT CODE ELSE GO FOR SELECTED ENTRIES CODE
            If Val(TXTFROM.Text.Trim) > 0 And Val(TXTTO.Text.Trim) > 0 Then
                If Val(TXTFROM.Text.Trim) > Val(TXTTO.Text.Trim) Then
                    MsgBox("Enter Proper Job Order Nos", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                If MsgBox("Wish to Print Job Order for Extrusion from " & TXTFROM.Text.Trim & " To " & TXTTO.Text.Trim & " ?", MsgBoxStyle.YesNo) = vbYes Then
                    SERVERPROPDIRECT()
                End If
            Else
                If MsgBox("Wish to Print Selected Job Order for Extrusion ?", MsgBoxStyle.YesNo) = vbYes Then
                    SERVERPROPSELECTED()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SERVERPROPDIRECT(Optional ByVal INVOICEMAIL As Boolean = False, Optional ByVal WHATSAPP As Boolean = False)
        Try



            Dim PRINTPARTYDESIGN As Boolean = False
            Dim ALATTACHMENT As New ArrayList
            Dim FILENAME As New ArrayList
            If INVOICEMAIL = False And WHATSAPP = False Then
                If PrintDialog.ShowDialog = DialogResult.OK Then PRINTDOC.PrinterSettings = PrintDialog.PrinterSettings Else Exit Sub
            End If
            For I As Integer = Val(TXTFROM.Text.Trim) To Val(TXTTO.Text.Trim)
                Dim OBJPO As New JobOrderDesign
                OBJPO.MdiParent = MDIMain
                OBJPO.DIRECTPRINT = True
                OBJPO.FRMSTRING = "JOPE"
                OBJPO.DIRECTMAIL = INVOICEMAIL
                OBJPO.DIRECTWHATSAPP = WHATSAPP
                OBJPO.PRINTSETTING = PRINTDIALOG
                OBJPO.JOBNO = Val(I)
                OBJPO.NOOFCOPIES = Val(TXTCOPIES.Text.Trim)
                OBJPO.Show()
                OBJPO.Close()

                ALATTACHMENT.Add(Application.StartupPath & "\JOPEREPORT_" & I & ".pdf")
                FILENAME.Add("JOPEREPORT_" & I & ".pdf")
            Next

            If INVOICEMAIL Then
                Dim OBJMAIL As New SendMail
                OBJMAIL.ALATTACHMENT = ALATTACHMENT
                OBJMAIL.subject = "JOPEREPORT"
                OBJMAIL.ShowDialog()
            End If

            If WHATSAPP = True Then
                Dim OBJWHATSAPP As New SendMultipleWhatsapp
                OBJWHATSAPP.PATH = ALATTACHMENT
                OBJWHATSAPP.FILENAME = FILENAME
                OBJWHATSAPP.ShowDialog()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub SERVERPROPSELECTED(Optional ByVal INVOICEMAIL As Boolean = False, Optional ByVal WHATSAPP As Boolean = False)
        Try


            Dim ALATTACHMENT As New ArrayList
            Dim FILENAME As New ArrayList
            If INVOICEMAIL = False And WHATSAPP = False Then
                If PrintDialog.ShowDialog = DialogResult.OK Then PRINTDOC.PrinterSettings = PrintDialog.PrinterSettings Else Exit Sub
            End If
            Dim SELECTEDROWS As Int32() = gridbill.GetSelectedRows()
            For I As Integer = 0 To Val(SELECTEDROWS.Length - 1)
                Dim ROW As DataRow = gridbill.GetDataRow(SELECTEDROWS(I))

                Dim OBJPO As New JobOrderDesign
                OBJPO.MdiParent = MDIMain
                OBJPO.DIRECTPRINT = True
                OBJPO.FRMSTRING = "JOPE"
                OBJPO.DIRECTMAIL = INVOICEMAIL
                OBJPO.DIRECTWHATSAPP = WHATSAPP
                OBJPO.PRINTSETTING = PRINTDIALOG
                OBJPO.JOBNO = Val(ROW("TEMPJONO"))
                OBJPO.NOOFCOPIES = Val(TXTCOPIES.Text.Trim)
                OBJPO.Show()
                OBJPO.Close()
                ALATTACHMENT.Add(Application.StartupPath & "\JOPEREPORT_" & Val(ROW("TEMPJONO")) & ".pdf")
                FILENAME.Add("JOPEREPORT_" & Val(ROW("TEMPJONO")) & ".pdf")
            Next

            If INVOICEMAIL Then
                Dim OBJMAIL As New SendMail
                OBJMAIL.ALATTACHMENT = ALATTACHMENT
                OBJMAIL.subject = "JOPEREPORT"
                OBJMAIL.ShowDialog()
            End If

            If WHATSAPP = True Then
                Dim OBJWHATSAPP As New SendWhatsapp
                OBJWHATSAPP.PATH = ALATTACHMENT
                OBJWHATSAPP.FILENAME = FILENAME
                OBJWHATSAPP.ShowDialog()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(sender As Object, e As EventArgs) Handles cmdok.Click
        Try
            showform(True, gridbill.GetFocusedRowCellValue("TEMPJONO"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub TOOLEXCEL_Click(sender As Object, e As EventArgs) Handles TOOLEXCEL.Click
            Try

                Dim PATH As String = Application.StartupPath & "\ JOB ORDER FOR PE Details.XLS"
                Dim opti As New DevExpress.XtraPrinting.XlsExportOptions
                opti.ShowGridLines = True
                opti.SheetName = " JOB ORDER FOR PE Details"
                gridbill.ExportToXls(PATH, opti)
            EXCELCMPHEADER(PATH, " JOB ORDER FOR PE Details", gridbill.VisibleColumns.Count + gridbill.GroupCount)
        Catch ex As Exception
                MsgBox(" JOB ORDER FOR PE Details Excel File is Open, Please Close the File first then try to Export", MsgBoxStyle.Critical)
            End Try
        End Sub
        Private Sub TXTFROM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTFROM.KeyPress, TXTTO.KeyPress
            numkeypress(e, sender, Me)
        End Sub

    End Class