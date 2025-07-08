Imports DB
Public Class ClsUnitConversion

    Private objDBOperation As DBOperation
    Public alParaval As New ArrayList
    Dim intResult As Integer

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

    Public Function SAVE() As Integer

        Try

            'save itemdetails
            Dim strCommand As String = "SP_UTILITIES_UNITCONVERSION_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@FROMUNIT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TOUNIT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@VALUE", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I += 1


            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function UPDATE() As Integer
        Dim strcommand As String = ""
        Try
            'Update AccountsMaster
            strcommand = "SP_UTILITIES_UNITCONVERSION_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@FROMUNIT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TOUNIT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@VALUE", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@TEMPUNIT", alParaval(I)))
                I += 1

            End With

            intResult = objDBOperation.executeNonQuery(strcommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function Delete() As Integer
        Dim intResult As Integer
        Try
            Dim strCommand As String = "SP_UTILITIES_UNITCONVERSION_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@ITEMNAME", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(2)))
            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GETUNITCONVERSION() As DataTable
        Try
            Dim dtTable As DataTable
            Dim strcommand As String = ""
            strcommand = "SP_UTILITIES_UNITCONVERSION_SELECT"

            Dim alParameter As New ArrayList
            With alParameter
                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@TEMPUNIT", alParaval(0)))
                I += 1
                .Add(New SqlClient.SqlParameter("@YEARID", alParaval(1)))
                I += 1
            End With
            dtTable = objDBOperation.execute(strcommand, alParameter).Tables(0)

            Return dtTable
        Catch ex As Exception
            Throw ex
        End Try
    End Function



#End Region

End Class
