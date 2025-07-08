
Imports DB

Public Class ClsPaperMaterial

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

#Region "Function"

    Public Function save() As Integer
        Dim intResult As Integer

        Try

            'save CategoryMaster
            Dim strCommand As String = "SP_MASTER_PAPERMATERIAL_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@PAPERMATERIAL", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@remarks", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@FRMSTR", alParaval(7)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function update() As Integer
        Dim intResult As Integer

        Try

            'save CategoryMaster
            Dim strCommand As String = "SP_MASTER_PAPERMATERIAL_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                .Add(New SqlClient.SqlParameter("@PAPERMATERIAL", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@remarks", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@userid", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(5)))
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(6)))
                .Add(New SqlClient.SqlParameter("@FRMSTR", alParaval(7)))
                .Add(New SqlClient.SqlParameter("@TEMPID", alParaval(8)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0

    End Function

    Public Function DELETE() As Integer
        Dim dtTable As New Integer
        Dim strcommand As String = ""
        Try
            strcommand = "SP_MASTER_PAPERMATERIAL_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@PAPERMATERIAL", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@FRMSTR", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@TEMPID", alParaval(3)))
            End With
            dtTable = objDBOperation.executeNonQuery(strcommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

#End Region

End Class
