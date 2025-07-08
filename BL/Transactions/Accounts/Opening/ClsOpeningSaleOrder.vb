Imports DB

Public Class ClsOpeningSaleOrder
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
        Dim DT As DataTable
        Try
            'save SALE order
            Dim strCommand As String = "SP_TRANS_SALE_OPENINGSALEORDER_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@SONO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHIPTO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROFORMANO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROFORMADATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROFORMATYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DESTINATION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PORTDISCHARGE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PORTLOADING", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CURRENCY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERREFNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PAYMENTTERM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CIFFOB", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BANKDETAILS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALAMOUNT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FREIGHT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INSURANCE", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@FINISHEDQUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DESC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GSM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GSMDETAILS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SIZE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FOILQUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FOILGSM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PEGSM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ROLLDIAMETER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COREPIPEWIDTH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PALLETIZED", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NARRATION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UNIT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AMOUNT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JOQTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JOQTYLAMINATION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JOQTYSLITTING", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OUTQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CLOSED", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REQDONE", alParaval(I)))
                I = I + 1




            End With

            DT = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DT

    End Function

    Public Function UPDATE() As Integer
        Dim intResult As Integer
        Try
            'Update SALE order
            Dim strCommand As String = "SP_TRANS_SALE_OPENINGSALEORDER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@SONO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHIPTO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROFORMANO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROFORMADATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROFORMATYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DESTINATION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PORTDISCHARGE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PORTLOADING", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CURRENCY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERREFNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PAYMENTTERM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CIFFOB", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BANKDETAILS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALAMOUNT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FREIGHT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INSURANCE", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@FINISHEDQUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DESC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GSM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GSMDETAILS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SIZE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FOILQUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FOILGSM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PEGSM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ROLLDIAMETER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@COREPIPEWIDTH", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PALLETIZED", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NARRATION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UNIT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AMOUNT", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@JOQTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JOQTYLAMINATION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JOQTYSLITTING", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OUTQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CLOSED", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REQDONE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TEMPSONO", alParaval(I)))
                I = I + 1
            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function SELECTSO(ByVal SONO As Integer, ByVal YearID As Integer) As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_SELECTOPENINGSO_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@SONO", SONO))
                .Add(New SqlClient.SqlParameter("@YearID", YearID))
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
            Dim strCommand As String = "SP_TRANS_SALE_OPENINGSALEORDER_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@SONO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@YearID", alParaval(1)))
            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region
End Class
