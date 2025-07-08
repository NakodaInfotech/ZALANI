
Imports DB
Public Class ClsLabeling
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
            'save  LABELING
            Dim strCommand As String = "SP_TRANS_SALE_LABELING_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@LABNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PARTYNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JODATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SODATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GODOWN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HANDLINGINFO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OTHERINFO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROFORMANO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKEDBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JONO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JOSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JOTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SONO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SOTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARK", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALROLL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALLABWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALFINALWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALDIFF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALWASWT", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@GRADE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ROLLNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GSM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GSMDETAILS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SIZE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ROLLOD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ROLLID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FINALWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DIFF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UNIT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JOINT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NARRATION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BARCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OUTQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMTYPE", alParaval(I)))
                I = I + 1

                'WASTAGE GRID PARAMETERS ***************************

                .Add(New SqlClient.SqlParameter("@GRIDWASTAGESRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WASTAGETYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WASTAGEWT", alParaval(I)))
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
            Dim strCommand As String = "SP_TRANS_SALE_LABELING_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@LABNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PARTYNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JODATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SODATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GODOWN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HANDLINGINFO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OTHERINFO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROFORMANO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PACKEDBY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JONO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JOSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JOTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SONO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SOTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARK", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALROLL", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALLABWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALFINALWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALDIFF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALWASWT", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@GRADE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ROLLNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GSM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GSMDETAILS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SIZE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ROLLOD", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ROLLID", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FINALWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DIFF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UNIT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JOINT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NARRATION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BARCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OUTQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMTYPE", alParaval(I)))
                I = I + 1

                'WASTAGE GRID PARAMETERS ***************************

                .Add(New SqlClient.SqlParameter("@GRIDWASTAGESRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WASTAGETYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WASTAGEWT", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@TEMPLABNO", alParaval(I)))
                I = I + 1
            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function SELECTLABELING(ByVal TEMPLABNO As Integer, ByVal Cmpid As Integer, ByVal YearID As Integer) As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_SELECT_LABELING_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@LABNO", TEMPLABNO))
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
            Dim strCommand As String = "SP_TRANS_SALE_LABELING_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@LABNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@YearID", alParaval(1)))

            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region
End Class
