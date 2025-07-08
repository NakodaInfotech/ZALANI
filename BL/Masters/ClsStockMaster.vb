Imports DB
Imports System.Data

Public Class ClsStockMaster

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
    'DONE BY GULKIT
    'Public Function save() As Integer
    '    Dim intResult As Integer
    '    Try
    '        'save SALE order
    '        Dim strCommand As String = "SP_MASTER_STOCKMASTER_SAVE"
    '        Dim alParameter As New ArrayList
    '        With alParameter

    '            Dim I As Integer = 0

    '            .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
    '            I = I + 1
    '            .Add(New SqlClient.SqlParameter("@locationid", alParaval(I)))
    '            I = I + 1
    '            .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
    '            I = I + 1
    '            .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
    '            I = I + 1
    '            .Add(New SqlClient.SqlParameter("@transfer", alParaval(I)))
    '            I = I + 1

    '            .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
    '            I = I + 1
    '            .Add(New SqlClient.SqlParameter("@TYPE", alParaval(I)))
    '            I = I + 1

    '            .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
    '            I = I + 1
    '            .Add(New SqlClient.SqlParameter("@LOTNO", alParaval(I)))
    '            I = I + 1
    '            .Add(New SqlClient.SqlParameter("@PIECETYPE", alParaval(I)))
    '            I = I + 1
    '            .Add(New SqlClient.SqlParameter("@MERCHANT", alParaval(I)))
    '            I = I + 1
    '            .Add(New SqlClient.SqlParameter("@QUALITY", alParaval(I)))
    '            I = I + 1
    '            .Add(New SqlClient.SqlParameter("@DESIGN", alParaval(I)))
    '            I = I + 1
    '            .Add(New SqlClient.SqlParameter("@COLOR", alParaval(I)))
    '            I = I + 1
    '            .Add(New SqlClient.SqlParameter("@PROCESS", alParaval(I)))
    '            I = I + 1
    '            .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
    '            I = I + 1
    '            .Add(New SqlClient.SqlParameter("@TONAME", alParaval(I)))
    '            I = I + 1
    '            .Add(New SqlClient.SqlParameter("@GODOWN", alParaval(I)))
    '            I = I + 1
    '            .Add(New SqlClient.SqlParameter("@CUT", alParaval(I)))
    '            I = I + 1
    '            .Add(New SqlClient.SqlParameter("@wt", alParaval(I)))
    '            I = I + 1
    '            .Add(New SqlClient.SqlParameter("@UNIT", alParaval(I)))
    '            I = I + 1
    '            .Add(New SqlClient.SqlParameter("@PCS", alParaval(I)))
    '            I = I + 1
    '            .Add(New SqlClient.SqlParameter("@MTRS", alParaval(I)))
    '            I = I + 1
    '            .Add(New SqlClient.SqlParameter("@BARCODE", alParaval(I)))
    '            I = I + 1
    '            .Add(New SqlClient.SqlParameter("@DONE", alParaval(I)))
    '            I = I + 1
    '            .Add(New SqlClient.SqlParameter("@OUTPCS", alParaval(I)))
    '            I = I + 1
    '            .Add(New SqlClient.SqlParameter("@OUTMTRS", alParaval(I)))
    '            I = I + 1
    '        End With

    '        intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    '    Return intResult

    'End Function

    Public Function SAVE() As DataTable
        Dim DTTABLE As DataTable
        Try
            'save SALE order
            Dim strCommand As String = "SP_MASTER_STOCKMASTER_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ITEMNAME", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@PARTYNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GODOWN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FINALQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UNIT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@READYFINALQC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BARCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OUTQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(I)))
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
            'save SALE order
            Dim strCommand As String = "SP_MASTER_STOCKMASTER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@DATE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GRIDSRNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@ITEMNAME", alParaval(I)))
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
                .Add(New SqlClient.SqlParameter("@PARTYNAME", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@GODOWN", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@QTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@FINALQTY", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@UNIT", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@READYFINALQC", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@BARCODE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@DONE", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@OUTQTY", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(I)))
                I = I + 1

                .Add(New SqlClient.SqlParameter("@NO", alParaval(I)))
                I = I + 1

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return intResult

    End Function

    Public Function DELETE() As Integer
        Dim intResult As Integer
        Try
            'save SALE order
            Dim strCommand As String = "SP_MASTER_STOCKMASTER_DELETE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0

                .Add(New SqlClient.SqlParameter("@SMNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I = I + 1
                
            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return intResult

    End Function

#End Region

End Class
