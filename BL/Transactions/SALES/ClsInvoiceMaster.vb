

Imports DB
Public Class ClsInvoiceMaster

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
            Dim strCommand As String = "SP_TRANS_SALE_INVOICEMASTER_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@INVOICENO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHIPTO", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@DELIVERYTIME", alParaval(I)))
                I = I + 1
                'EXPORT
                .Add(New SqlClient.SqlParameter("@ROE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXPTERMS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MARKNOS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXPINSURANCE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CONTAINER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXPHSN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GROSSWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NETTWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SQMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALUSDAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GSTINVRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CUSTOMINVRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXPDIFF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INWORDSUSD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROFORMANO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PSDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PSNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TRANSPORTNAME", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@HSNCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DESC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ROLLNO", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@RATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AMOUNT", alParaval(I)))
                I = I + 1

                'GRID PARAMETER CHARGES
                .Add(New SqlClient.SqlParameter("@ESRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ECHARGES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ETAXID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@billamt", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHARGES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SUBTOTAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@roundoff", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@grandtotal", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@inwords", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALROLL", alParaval(I)))
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
            Dim strCommand As String = "SP_TRANS_SALE_INVOICEMASTER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@INVOICENO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHIPTO", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@DELIVERYTIME", alParaval(I)))
                I = I + 1


                'EXPORT
                .Add(New SqlClient.SqlParameter("@ROE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXPTERMS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MARKNOS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXPINSURANCE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CONTAINER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXPHSN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GROSSWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NETTWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SQMTRS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALUSDAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GSTINVRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CUSTOMINVRATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EXPDIFF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INWORDSUSD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROFORMANO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PSDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PSNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TRANSPORTNAME", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@HSNCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DESC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ROLLNO", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@RATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AMOUNT", alParaval(I)))
                I = I + 1



                'GRID PARAMETER CHARGES
                .Add(New SqlClient.SqlParameter("@ESRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ECHARGES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EPER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@EAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ETAXID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@billamt", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CHARGES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SUBTOTAL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@roundoff", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@grandtotal", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@inwords", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALROLL", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TEMPINVOICENO", alParaval(I)))
                I = I + 1
            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function SELECTSALEINVOICE() As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_SELECTSALEINVOICE_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@INVOICENO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@Cmpid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@YearID", alParaval(I)))
                I += 1
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
            Dim strCommand As String = "SP_TRANS_SALE_INVOICEMASTER_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@INVOICENO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@Cmpid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@YearID", alParaval(I)))
                I += 1

            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region


End Class
