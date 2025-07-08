
Imports BL

Public Class UnitMaster

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Public frmString As String      'Used for all Unit form
    Public Tempname As String       'Used for edit name
    Public Tempabbr As String       'Used for validating abbr
    Public tempid As Integer        'Used for id
    Public EDIT As Boolean          'Used for edit

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Function errorvalid() As Boolean
        Dim bln As Boolean = True
        If txtname.Text.Trim.Length = 0 Then
            Ep.SetError(txtname, "Fill Name")
            bln = False
        End If

        If txtabbr.Text.Trim.Length = 0 Then
            Ep.SetError(txtabbr, "Fill Abbr")
            bln = False
        End If

        If Tempabbr = "in" Or Tempabbr = "mm" Then
            Ep.SetError(txtabbr, "Build In Unit Cannot edit")
            bln = False
        End If

        Return bln
    End Function

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try

            Ep.Clear()
            If Not errorvalid() Then
                Exit Sub
            End If

            Dim IntResult As Integer
            Dim alParaval As New ArrayList

            alParaval.Add(UCase(txtname.Text.Trim))
            alParaval.Add(UCase(txtabbr.Text.Trim))
            alParaval.Add(txtremarks.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)
            alParaval.Add(0)

            If frmString = "UNIT" Then

                Dim objclsUnitMaster As New ClsUnitMaster
                objclsUnitMaster.alParaval = alParaval
                If edit = False Then
                    If USERADD = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    IntResult = objclsUnitMaster.save()
                    MsgBox("Details Added")
                ElseIf edit = True Then
                    If USEREDIT = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    alParaval.Add(tempid)
                    IntResult = objclsUnitMaster.update()
                    MsgBox("Details Updated")
                    edit = False

                End If
            End If
            clear()
            txtname.Focus()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub clear()
        txtname.Clear()
        txtabbr.Clear()
        txtremarks.Clear()
    End Sub

    Private Sub cmbpackingunit_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbpackingunit.Enter
        Try
            If cmbpackingunit.Text.Trim = "" Then
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable
                dt = objclscommon.search("packingunit_name", "", "PackingUnitMaster", " and PackingUnit_cmpid = " & CmpId & " and PackingUnit_locationid = " & Locationid & " and PackingUnit_yearid = " & YearId)
                If dt.Rows.Count > 0 Then
                    dt.DefaultView.Sort = "packingunit_name"
                    cmbpackingunit.DataSource = dt
                    cmbpackingunit.DisplayMember = "packingunit_name"
                    cmbpackingunit.Text = ""
                End If
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtname_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtname.Validating
        Try
            'for search
            Dim objclscommon As New ClsCommonMaster
            Dim dt As DataTable

            If (edit = False) Or (edit = True And LCase(Tempname) <> LCase(txtname.Text.Trim)) Then
                If frmString = "UNIT" Then
                    dt = objclscommon.search("unit_name", "", "unitMaster", " and unit_name = '" & txtname.Text.Trim & "' And Unit_yearid = " & yearid)
                    If dt.Rows.Count > 0 Then
                        MsgBox("Unit Name Already Exists", MsgBoxStyle.Critical, "ZALANI")
                        e.Cancel = True
                    End If
                End If
            End If
            uppercase(txtname)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmddelete_Click(sender As Object, e As EventArgs) Handles cmddelete.Click
        Try
            MsgBox("Insufficient Rights")
            Exit Sub
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub UnitMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Alt = True And e.KeyCode = Windows.Forms.Keys.S Then       'fOR sAVE
            Call cmdok_Click(sender, e)
        ElseIf (e.Alt = True And e.KeyCode = Windows.Forms.Keys.X) Or (e.KeyCode = Windows.Forms.Keys.Escape) Then               'FOR EXIT
            Me.Close()
        End If
    End Sub

    Private Sub UnitMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim dttable As New DataTable
            Dim objCommon As New ClsCommonMaster

            If frmString = "UNIT" Then
                Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'UNIT MASTER'")
                USERADD = DTROW(0).Item(1)
                USEREDIT = DTROW(0).Item(2)
                USERVIEW = DTROW(0).Item(3)
                USERDELETE = DTROW(0).Item(4)


                Me.Text = "Unit Master"
                lblgroup.Text = "Unit"
                lblabbr.Text = "Abbr."
                lbl.Text = "Enter Unit " & vbNewLine & "(e.g.  Mtrs,Gram..., etc. )"
                If edit = True Then
                    If USEREDIT = False And USERVIEW = False Then
                        MsgBox("Insufficient Rights")
                        Exit Sub
                    End If
                    dttable = objCommon.search(" unit_name, unit_abbr, unit_remarks", "", "UnitMaster", " and unit_id = " & tempid)

                End If
            End If

            If dttable.Rows.Count > 0 Then
                txtname.Text = dttable.Rows(0).Item(0).ToString
                txtabbr.Text = dttable.Rows(0).Item(1).ToString
                txtremarks.Text = dttable.Rows(0).Item(2).ToString
                Tempabbr = txtabbr.Text.Trim
            End If


        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub txtabbr_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtabbr.Validating
        Try
            If txtabbr.Text.Trim <> "" Then
                'for search
                Dim objclscommon As New ClsCommonMaster
                Dim dt As DataTable

                If (EDIT = False) Or (EDIT = True And LCase(Tempabbr) <> LCase(txtabbr.Text.Trim)) Then
                    If frmString = "UNIT" Then
                        dt = objclscommon.search("unit_abbr", "", "unitMaster", " and unit_abbr = '" & txtabbr.Text.Trim & "' And Unit_yearid = " & YearId)
                        If dt.Rows.Count > 0 Then
                            MsgBox("Unit Abbr Already Exists", MsgBoxStyle.Critical, "ZALANI")
                            e.Cancel = True
                        End If
                    End If
                End If
                uppercase(txtname)
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

End Class