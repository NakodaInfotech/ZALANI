Imports DB
Public Class ClsOpeningPurchaseOrder
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
        Try
            'save purchase order
            Dim strCommand As String = "SP_TRANS_PURCHASE_OPENINGPURCHASEORDER_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@PONO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DELIVERY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERREFNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROFORMANO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROFORMADATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROFORMATYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKING", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QUALITYNOTES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DIAMETER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PAYMENTTERM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BILLINGINFO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INSURANCE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@VERIFIED", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I = I + 1


                'grid parameters********************************
                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NARRATION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GSM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SIZE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QTYUNIT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AMOUNT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RECDQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CLOSED", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@STOCK", alParaval(I)))
                I = I + 1
            End With

            Dim DT As DataTable = objDBOperation.execute(strCommand, alParameter).Tables(0)
            Return DT
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function UPDATE() As Integer
        Dim intResult As Integer
        Try
            'Update purchase order
            Dim strCommand As String = "SP_TRANS_PURCHASE_OPENINGPURCHASEORDER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter
                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@PONO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DELIVERY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ORDERREFNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROFORMANO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROFORMADATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROFORMATYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKING", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QUALITYNOTES", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DIAMETER", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PAYMENTTERM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BILLINGINFO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@INSURANCE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALAMT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@VERIFIED", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(I)))
                I = I + 1


                'grid parameters********************************
                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NARRATION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GSM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SIZE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QTYUNIT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@AMOUNT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RECDQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CLOSED", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@STOCK", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TEMPPONO", alParaval(I)))
                I = I + 1



            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function SELECTPO(ByVal PONO As Integer, ByVal YEARID As Integer) As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_SELECTOPENINGPO_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@PONO", PONO))
                .Add(New SqlClient.SqlParameter("@YEARID", YEARID))
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
            Dim strCommand As String = "SP_TRANS_PURCHASE_OPENINGPURCHASEORDER_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@PONO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(1)))
            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

End Class
