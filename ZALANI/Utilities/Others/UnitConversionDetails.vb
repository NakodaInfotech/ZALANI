Imports BL
Public Class UnitConversionDetails

    Public EDIT As Boolean
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Private Sub UnitConversionDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim DTROW() As DataRow
            DTROW = USERRIGHTS.Select("FormName = 'UNIT MASTER'")
            USERADD = DTROW(0).Item(1)
            USEREDIT = DTROW(0).Item(2)
            USERVIEW = DTROW(0).Item(3)
            USERDELETE = DTROW(0).Item(4)

            If USEREDIT = False And USERVIEW = False Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDADDNEW_Click(sender As Object, e As EventArgs) Handles CMDADDNEW.Click
        Try
            showform(False, 0)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMDEXIT_Click(sender As Object, e As EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Private Sub CMDREFRESH_Click(sender As Object, e As EventArgs) Handles CMDREFRESH.Click
        Try
            fillgrid()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub fillgrid()
        Try
            Dim OBJSTORE As New ClsUnitConversion
            OBJSTORE.alParaval.Add(0)
            OBJSTORE.alParaval.Add(YearId)
            Dim DT As DataTable = OBJSTORE.GETUNITCONVERSION
            GRIDBILLDETAILS.DataSource = DT
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub CMDEDIT_Click(sender As Object, e As EventArgs) Handles CMDEDIT.Click
        Try
            showform(True, GRIDBILL.GetFocusedRowCellValue("UNITID"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Sub showform(ByVal editval As Boolean, ByVal UNITID As Integer)
        Try
            If (editval = True And USEREDIT = False And USERVIEW = False) Or (editval = False And USERADD = False) Then
                MsgBox("Insufficient Rights")
                Exit Sub
            End If

            Dim OBJSTORE As New UnitConversion
            OBJSTORE.MdiParent = MDIMain
            OBJSTORE.EDIT = editval
            OBJSTORE.tempid = UNITID
            OBJSTORE.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRIDBILL_DoubleClick(sender As Object, e As EventArgs) Handles GRIDBILL.DoubleClick
        Try
            showform(True, GRIDBILL.GetFocusedRowCellValue("UNITID"))
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub UnitConversionDetails_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Windows.Forms.Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class