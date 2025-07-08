Imports DB
Public Class ClsJobOpeningOrderForPE

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
            Dim strCommand As String = "SP_TRANS_OPENINGJO_PE_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@JONO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PORTDISCHARGE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PORTLOADING", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DESTINATION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CIFFOB", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CURRENCY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHIPTO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROFORMANO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SONO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SOTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SODATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BANKDETAILS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALQTY", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@ROLLDIEAMETER", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@CLOSED", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@READYQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PRODISSDONE", alParaval(I)))
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
            Dim strCommand As String = "SP_TRANS_OPENINGJO_PE_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@JONO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PORTDISCHARGE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PORTLOADING", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DESTINATION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CIFFOB", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@CURRENCY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHIPTO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROFORMANO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SONO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SOTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SODATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BANKDETAILS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALQTY", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@ROLLDIEAMETER", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@CLOSED", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@READYQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@PRODISSDONE", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TEMPJONO", alParaval(I)))
                I = I + 1
            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function selectJOPE(ByVal JONO As Integer, ByVal Cmpid As Integer, ByVal YearID As Integer) As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_SELECTOPENINGJO_PE_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@JONO", JONO))
                .Add(New SqlClient.SqlParameter("@CmpID", Cmpid))
                .Add(New SqlClient.SqlParameter("@YearID", YearID))
            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

    Public Function Delete() As Integer
        Dim intResult As Integer
        Try
            Dim strCommand As String = "SP_TRANS_OPENINGJO_PE_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@JONO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@Cmpid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@YearID", alParaval(3)))

            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region


End Class
