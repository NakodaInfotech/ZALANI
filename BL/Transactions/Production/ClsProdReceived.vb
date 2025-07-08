Imports DB
Public Class ClsProdReceived

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
            Dim strCommand As String = "SP_TRANS_PRODUCT_PRODRECD_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@RECDNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RECDDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JODATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JOTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SODATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SOTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GODOWN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MACHINENO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROFORMANO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FINALQUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JONO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JOSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SONO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARK", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ISSUENO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ISSUEDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OPERATOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHIFT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HEATINGTIME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RUNNINGTIME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@STOPTIME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALISSWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALRECDWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALBALWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALWASWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALFINALBALWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WASTAGEPERCENTAGE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALREELNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALDIFF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALROLLNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALISSRECDWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALGSM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1

                'grid parameters********************************

                .Add(New SqlClient.SqlParameter("@GRIDRECDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REELROLLNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GSM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@IGSMDETAILS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SIZE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MILLQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OURQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DIFF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UNIT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMSRNO", alParaval(I)))
                I = I + 1

                'WASTAGE GRID PARAMETERS ***************************

                .Add(New SqlClient.SqlParameter("@GRIDWASTAGESRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WASTAGETYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WT", alParaval(I)))
                I = I + 1


                'PROCESS GRID PARAMETERS ***************************

                .Add(New SqlClient.SqlParameter("@GRIDPROCESSSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRADE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MICRON", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MGSM", alParaval(I)))
                I = I + 1


                'grid SINGLEISSUE parameters********************************

                .Add(New SqlClient.SqlParameter("@GRIDSINGLERECDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ROLLNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RLOTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RGSM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GSMDETAILS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RSIZE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RECDWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@IUNIT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JOINT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NARRATION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BARCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FQCDONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OUTQTY", alParaval(I)))
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
            Dim strCommand As String = "SP_TRANS_PRODUCT_PRODRECD_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@RECDNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RECDDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JODATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JOTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SODATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SOTYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GODOWN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MACHINENO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@PROFORMANO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FINALQUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JONO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JOSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SONO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARK", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ISSUENO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ISSUEDATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OPERATOR", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SHIFT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@HEATINGTIME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RUNNINGTIME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@STOPTIME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALISSWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALRECDWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALBALWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALWASWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALFINALBALWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WASTAGEPERCENTAGE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALREELNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALDIFF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALROLLNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALISSRECDWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@TOTALGSM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1

                'grid parameters********************************

                .Add(New SqlClient.SqlParameter("@GRIDRECDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QUALITY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@LOTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REELROLLNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GSM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@IGSMDETAILS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@SIZE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MILLQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OURQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DIFF", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UNIT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FROMSRNO", alParaval(I)))
                I = I + 1

                'WASTAGE GRID PARAMETERS ***************************

                .Add(New SqlClient.SqlParameter("@GRIDWASTAGESRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WASTAGETYPE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@WT", alParaval(I)))
                I = I + 1


                'PROCESS GRID PARAMETERS ***************************

                .Add(New SqlClient.SqlParameter("@GRIDPROCESSSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRADE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MICRON", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@MGSM", alParaval(I)))
                I = I + 1


                'grid SINGLEISSUE parameters********************************

                .Add(New SqlClient.SqlParameter("@GRIDSINGLERECDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ROLLNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RLOTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RGSM", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GSMDETAILS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RSIZE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@RECDWT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@IUNIT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@JOINT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@NARRATION", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BARCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FQCDONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OUTQTY", alParaval(I)))
                I = I + 1


                .Add(New SqlClient.SqlParameter("@TEMPPRODRECDNO", alParaval(I)))
                I = I + 1


            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function selectRECEIVED(ByVal RECDNO As Integer, ByVal CMPID As Integer, ByVal YearID As Integer) As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_SELECTPRODRECD_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@RECDNO", RECDNO))
                .Add(New SqlClient.SqlParameter("@CMPID", RECDNO))
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
            Dim strCommand As String = "SP_TRANS_PRODUCT_PRODRECD_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@RECDNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@YearID", alParaval(3)))

            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region
End Class
