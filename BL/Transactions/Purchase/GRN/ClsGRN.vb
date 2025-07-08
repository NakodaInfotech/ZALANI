

Imports DB

    Public Class ClsGRN
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

#Region "Functions"
        Public Function SAVE() As DataTable
            Dim DTTABLE As DataTable
            Try
                'save ENQUIRY 
                Dim I As Integer = 0
            Dim strCommand As String = "SP_TRANS_PURCHASE_GRN_SAVE"
            Dim alParameter As New ArrayList
                With alParameter

                .Add(New SqlClient.SqlParameter("@GRNDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PONO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PODATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PARTYREFNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHALLANNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GODOWN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHALLANDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALREELNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1

                'grid parameters********************************
                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REELNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GSM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GSMDETAILS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SIZE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UNIT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OUTQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHECKDONE", alParaval(I)))
                I = I + 1

                'PO grid parameters********************************
                .Add(New SqlClient.SqlParameter("@ORDERGRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERQUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERGSM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERSIZE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERPONO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERPOSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERPOTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERGRNQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERRATE", alParaval(I)))
                I = I + 1




            End With

                DTTABLE = objDBOperation.execute(strCommand, alParameter).Tables(0)
                Return DTTABLE

            Catch ex As Exception
                Throw ex
            End Try

        End Function

        Public Function UPDATE() As Integer
            Dim intresult As Integer
            Try
                'update ENQUIRY 
                Dim I As Integer = 0
            Dim strCommand As String = "SP_TRANS_PURCHASE_GRN_UPDATE"
            Dim alParameter As New ArrayList
                With alParameter

                .Add(New SqlClient.SqlParameter("@GRNDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PONO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PODATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PARTYREFNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHALLANNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GODOWN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHALLANDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALREELNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1

                'grid parameters********************************
                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REELNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GSM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GSMDETAILS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SIZE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UNIT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OUTQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHECKDONE", alParaval(I)))
                I = I + 1

                'PO grid parameters********************************
                .Add(New SqlClient.SqlParameter("@ORDERGRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERQUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERGSM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERSIZE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERPONO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERPOSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERPOTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERGRNQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERRATE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TEMPGRNNO", alParaval(I)))
                I = I + 1

                End With

                intresult = objDBOperation.executeNonQuery(strCommand, alParameter)


            Catch ex As Exception
                Throw ex
            End Try
            Return 0
        End Function

        Public Function selectGRN() As DataTable
            Dim dtTable As DataTable
            Try

                Dim strCommand As String = "SP_SELECTGRN_FOR_EDIT"
                Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@GRNNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@Yearid", alParaval(1)))
            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)

            Catch ex As Exception
                Throw ex
            End Try
            Return dtTable
        End Function

    Public Function DELETE() As Integer
        Try
            Dim intresult As Integer
            Dim STRCOMMAND As String = "SP_TRANS_PURCHASE_GRN_DELETE"
            Dim ALPARAMETER As New ArrayList
            With ALPARAMETER
                .Add(New SqlClient.SqlParameter("@GRNNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(1)))
            End With

            intresult = objDBOperation.executeNonQuery(STRCOMMAND, ALPARAMETER)
        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

#End Region



End Class
