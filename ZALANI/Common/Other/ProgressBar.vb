Imports BL
Imports Microsoft.VisualBasic

Public Class ProgressBar

    Public alParaval As ArrayList

    Private Sub ProgressBar_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try

            bar.Step = 1
            getcmpid()
            CREATEDEPARTMENT()
            CREATEGODOWN()
            createUser()
            createUNIT()


            CREATESTATE()
            creategroup()
            createledger()
            createREGISTER()

            createMATERIALTYPE()


            'GETTING RIGHTS IN DATATABLE
            Dim OBJCMN As New ClsCommon
            USERRIGHTS = OBJCMN.search("User_formName as [FormName], User_add as [Add], User_Edit as [Edit], User_View as [View], User_Delete as [Delete]", "", "USERMASTER_RIGHTS INNER JOIN USERMASTER ON USERMASTER.USER_ID = USERMASTER_RIGHTS.USER_ID AND USERMASTER.USER_CMPID = USERMASTER_RIGHTS.USER_CMPID", " and USERMASTER.USER_NAME = '" & UserName & "' and usermaster.user_CMPID = " & CmpId)



            Dim objmain As New MDIMain
            Me.Close()
            objmain.Show()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try

    End Sub

    Sub getcmpid()
        Try
            Dim objclscommon As New ClsCommon
            Dim dt As DataTable
            dt = objclscommon.SEARCH("cmp_id,cmp_userid", "", "CmpMaster", " and Cmp_name = '" & alParaval(0) & "'")
            If dt.Rows.Count > 0 Then
                CmpId = dt.Rows(0).Item(0).ToString
                Userid = dt.Rows(0).Item(1).ToString
            End If

            dt = objclscommon.SEARCH("max(year_id)", "", "YearMaster", " and Year_cmpid = " & CmpId)
            If dt.Rows.Count > 0 Then
                YearId = dt.Rows(0).Item(0).ToString
            End If

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    '***************** GENERAL ********************
    Sub CREATEGODOWN()
        Try
            Dim alParaval As New ArrayList
            Dim INTRESULT As Integer

            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)

            Dim objprogressbar As New ClsProgressBar
            objprogressbar.alParaval = alParaval
            INTRESULT = objprogressbar.CREATEGODOWN()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub createUser()
        Try
            Dim alParaval As New ArrayList
            Dim INTRESULT As Integer

            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)

            Dim objprogressbar As New ClsProgressBar
            objprogressbar.alParaval = alParaval
            INTRESULT = objprogressbar.CREATEUSER()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub CREATEDEPARTMENT()
        Try
            Dim alParaval As New ArrayList
            Dim INTRESULT As Integer

            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)

            Dim objprogressbar As New ClsProgressBar
            objprogressbar.alParaval = alParaval
            INTRESULT = objprogressbar.CREATEDEPARTMENT()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub createUNIT()
        Try
            Dim alParaval As New ArrayList
            Dim INTRESULT As Integer

            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)

            Dim objprogressbar As New ClsProgressBar
            objprogressbar.alParaval = alParaval
            INTRESULT = objprogressbar.CREATEUNIT()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub createPARAMETER()
        Try
            Dim alParaval As New ArrayList
            Dim INTRESULT As Integer

            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)

            Dim objprogressbar As New ClsProgressBar
            objprogressbar.alParaval = alParaval
            INTRESULT = objprogressbar.CREATEPARAMETER()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub CREATESTATE()
        Try
            Dim alParaval As New ArrayList
            Dim INTRESULT As Integer

            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)

            Dim objprogressbar As New ClsProgressBar
            objprogressbar.alParaval = alParaval
            INTRESULT = objprogressbar.CREATESTATE()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    '***************** GENERAL ********************




    '***************** ACCUNTS ********************

    Sub creategroup()
        Try
            Dim alParaval As New ArrayList
            Dim INTRESULT As Integer

            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)

            Dim objprogressbar As New ClsProgressBar
            objprogressbar.alParaval = alParaval
            INTRESULT = objprogressbar.CREATEGROUP()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub createledger()
        Try
            Dim alParaval As New ArrayList
            Dim INTRESULT As Integer

            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)

            Dim objprogressbar As New ClsProgressBar
            objprogressbar.alParaval = alParaval
            INTRESULT = objprogressbar.CREATELEDGER()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub createREGISTER()
        Try
            Dim alParaval As New ArrayList
            Dim INTRESULT As Integer

            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)

            Dim objprogressbar As New ClsProgressBar
            objprogressbar.alParaval = alParaval
            INTRESULT = objprogressbar.CREATEREGISTER()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    '***************** ACCUNTS ********************



    '***************** ITEM ********************

    Sub createMATERIALTYPE()
        Try
            Dim alParaval As New ArrayList
            Dim INTRESULT As Integer

            alParaval.Add(CmpId)
            alParaval.Add(Locationid)
            alParaval.Add(Userid)
            alParaval.Add(YearId)

            Dim objprogressbar As New ClsProgressBar
            objprogressbar.alParaval = alParaval
            INTRESULT = objprogressbar.CREATEMATERIALTYPE

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    '***************** ITEM ********************


    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            If bar.Value <= 20 Then
                Timer1.Interval = 1000
                lbl.Text = "Creating Database....."
            ElseIf bar.Value <= 50 Then
                Timer1.Interval = 200
                lbl.Text = "Importing Books....."
            ElseIf bar.Value <= 80 Then
                Timer1.Interval = 100
                lbl.Text = "Importing Masters....."
            Else
                lbl.Text = "Please Wait....."
            End If

            If bar.Value = 100 Then
                'Dim objmain As New MDIMain
                Me.Close()
                'objmain.Show()
            End If
            bar.PerformStep()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

End Class