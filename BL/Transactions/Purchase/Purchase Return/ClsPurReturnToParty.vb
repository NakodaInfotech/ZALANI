Imports DB

Public Class ClsPurReturnToParty
    Private objDBOperation As DBOperation
    Public alParaval As New ArrayList

#Region "Constructor"
        Public Sub New()
            Try
                objDBOperation = New DBOperation
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
#End Region

#Region "functions"

        Public Function SAVE() As DataTable
            Dim DTTABLE As DataTable
            Try
            'SAVE PURCHASE RETURN
            Dim strCommand As String = "SP_TRANS_PURCHASE_PURCHASERETURNTOPARTY_SAVE"
            Dim alParameter As New ArrayList
                With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GODOWN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHALLANNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHALLANDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1


                'grid parameters
                .Add(New SqlClient.SqlParameter("@gridsrno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@STOREITEMNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NARRATION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@qty", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@unit", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDDONE", alParaval(I)))
                I = I + 1




                End With

                DTTABLE = objDBOperation.execute(strCommand, alParameter).Tables(0)
                Return DTTABLE

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function UPDATE() As Integer
            Dim intResult As Integer
            Try
            'UPDATE PURCHASE RETURN
            Dim strCommand As String = "SP_TRANS_PURCHASE_PURCHASERETURNTOPARTY_UPDATE"
            Dim alParameter As New ArrayList
                With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GODOWN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHALLANNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHALLANDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1


                'grid parameters
                .Add(New SqlClient.SqlParameter("@gridsrno", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@STOREITEMNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NARRATION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@qty", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@unit", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDDONE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@PRCHNO", alParaval(I)))
                    I = I + 1

                End With
                intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

            Catch ex As Exception
                Throw ex
            End Try
            Return 0
        End Function

    Public Function SELECTPURCHASERETURNTOPARTY() As DataTable

        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_SELECTPURCHASERETURNTOPARTY_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@PRCHNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@YearID", alParaval(1)))
            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

    Public Function DELETE() As Integer
            Dim intResult As Integer
            Try
            Dim strCommand As String = "SP_TRANS_PURCHASE_PURCHASERETURNTOPARTY_DELETE"
            Dim alParameter As New ArrayList
                With alParameter
                    .Add(New SqlClient.SqlParameter("@PRCHNO", alParaval(0)))
                    .Add(New SqlClient.SqlParameter("@userID", alParaval(1)))
                    .Add(New SqlClient.SqlParameter("@YearID", alParaval(2)))
                End With
                intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

#End Region





    End Class
