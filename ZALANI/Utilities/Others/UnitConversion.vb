
Imports System.ComponentModel
Imports BL
Public Class UnitConversion

    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim IntResult As Integer
    Public frmString As String      'Used for all Unit form
    Public Tempname As String       'Used for edit name
    Public Tempabbr As String       'Used for validating abbr
    Public tempid As Integer        'Used for id
    Public EDIT As Boolean          'Used for edit
    Public TEMPUNIT As String
    Public TEMPUNITNO As String
    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub
    Private Sub UnitConversion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow = USERRIGHTS.Select("FormName = 'UNIT MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            FILLCMB()
            TXTUNITNO.Text = TEMPUNITNO
            If EDIT = True Then

                If USEREDIT = False And USERVIEW = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                Dim ALPARAVAL As New ArrayList
                ALPARAVAL.Add(TEMPUNIT)
                ALPARAVAL.Add(YearId)
                Dim OBJSELECT As New ClsUnitConversion
                OBJSELECT.ALPARAVAL = ALPARAVAL
                Dim dttable As DataTable = OBJSELECT.GETUNITCONVERSION()
                For Each ITEM As DataRow In dttable.Rows
                    TEMPUNITNO = ITEM("UNITID")
                    CMBFROMUNIT.Text = ITEM("FROMUNIT").ToString
                    CMBTOUNIT.Text = ITEM("TOUNIT").ToString
                    TXTVALUE.Text = ITEM("VALUE").ToString
                Next
            End If
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
    Sub FILLCMB()

        Dim objclscommon As New ClsCommonMaster
        Dim dt As DataTable
        If CMBFROMUNIT.Text = "" Then fillunit(CMBFROMUNIT)
        If CMBTOUNIT.Text = "" Then fillunit(CMBTOUNIT)

    End Sub
    Sub CLEAR()
        CMBFROMUNIT.Text = ""
        CMBFROMUNIT.Text = ""
        TXTVALUE.Clear()
    End Sub
    Private Sub CMBFROMUNIT_Enter(sender As Object, e As EventArgs) Handles CMBFROMUNIT.Enter
        Try
            If CMBFROMUNIT.Text.Trim = "" Then fillunit(CMBFROMUNIT)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub cmdok_Click(sender As Object, e As EventArgs) Handles cmdok.Click
        Try
            Ep.Clear()
            ' If Not errorvalid() Then
            ' Exit Sub
            ' End If
            Dim IntResult As Integer
            Dim alParaval As New ArrayList
            alParaval.Add(CMBFROMUNIT.Text.Trim)
            alParaval.Add(CMBTOUNIT.Text.Trim)
            alParaval.Add(TXTVALUE.Text.Trim)
            alParaval.Add(CmpId)
            alParaval.Add(Userid)
            alParaval.Add(YearId)


            Dim objclsItemMaster As New ClsUnitConversion
            objclsItemMaster.alParaval = alParaval

            If EDIT = False Then
                If USERADD = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                IntResult = objclsItemMaster.SAVE()
                MsgBox("Details Added")
            Else
                If USEREDIT = False Then
                    MsgBox("Insufficient Rights")
                    Exit Sub
                End If
                alParaval.Add(TEMPUNIT)
                IntResult = objclsItemMaster.UPDATE()
                MsgBox("Details Updated")

            End If
            EDIT = False

            CLEAR()
            CMBFROMUNIT.Focus()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
    Private Sub CMBFROMUNIT_Validating(sender As Object, e As CancelEventArgs) Handles CMBFROMUNIT.Validating
        Try
            If CMBFROMUNIT.Text.Trim <> "" Then unitvalidate(CMBFROMUNIT, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBTOUNIT_Validating(sender As Object, e As CancelEventArgs) Handles CMBTOUNIT.Validating
        Try
            If CMBTOUNIT.Text.Trim <> "" Then unitvalidate(CMBTOUNIT, e, Me)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub CMBTOUNIT_Enter(sender As Object, e As EventArgs) Handles CMBTOUNIT.Enter
        Try
            If CMBTOUNIT.Text.Trim = "" Then fillunit(CMBTOUNIT)
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub
End Class