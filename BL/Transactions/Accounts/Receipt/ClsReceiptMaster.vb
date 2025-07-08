﻿
Imports DB

Public Class ClsReceiptMaster
    Private objDBOperation As DBOperation
    Public alParaval As New ArrayList

#Region "Constructor"
    Public Sub New()
        Try
            objDBOperation = New DBOperation()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Functions"

    Public Function SAVE() As DataTable
        Dim DT As DataTable
        Try
            'save PAYMENT MASTER
            Dim strCommand As String = "SP_TRANS_RECEIPTMASTER_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@RECEIPTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@registername", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@accdate", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@accname", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@name", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@chqamt", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@chqno", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@remarks", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BILLREMARKS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@OURREMARKS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@inwords", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CHECKPDC", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@RECODATE", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@gridsrno", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@paytype", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@billinitials", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@narr", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@amt", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@AMTPAID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@EXTRAAMT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@RETURN", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BALANCE", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@descgridsrno", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@descledgername", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@descnarr", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@descamt", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@descPAYGRIDSRNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@descPAYBILLINITIALS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BANKNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SPECIALREMARKS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CHEQUEDATE", alParaval(I)))
                I += 1

            End With

            DT = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DT

    End Function

    Public Function selectbill_edit(ByVal BILLno As Integer, ByVal REGISTERNAME As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_TRANS_SELECT_RECEIPTBILL_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@RECNO", BILLno))
                .Add(New SqlClient.SqlParameter("@REGISTERNAME", REGISTERNAME))
                .Add(New SqlClient.SqlParameter("@CMPID", CMPID))
                .Add(New SqlClient.SqlParameter("@LOCATIONID", LOCATIONID))
                .Add(New SqlClient.SqlParameter("@YEARID", YEARID))
            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

    Public Function UPDATE() As Integer
        Dim intResult As Integer
        Try
            'update purchase Requisition
            Dim strCommand As String = "SP_TRANS_RECEIPTMASTER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@RECEIPTNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@registername", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@accdate", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@accname", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@name", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@chqamt", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@chqno", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@remarks", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BILLREMARKS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@OURREMARKS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@inwords", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CHECKPDC", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@RECODATE", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@transfer", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@gridsrno", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@paytype", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@billinitials", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@narr", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@amt", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@AMTPAID", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@EXTRAAMT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@RETURN", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BALANCE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@descgridsrno", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@descledgername", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@descnarr", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@descamt", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@descPAYGRIDSRNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@descPAYBILLINITIALS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BANKNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SPECIALREMARKS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CHEQUEDATE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@RECno", alParaval(I)))
                I += 1


            End With
            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return 0
    End Function

    Public Function GETBILLS(ByVal CMPID As Integer, ByVal NAME As String, ByVal LOCATIONID As Integer, ByVal YEARID As Integer, Optional RECDATE As Date = Nothing) As DataTable
        Dim dtTable As DataTable
        Try
            If RECDATE = Nothing Then RECDATE = Now.Date

            Dim strCommand As String = "SP_TRANS_SELECT_RECEIPTMASTER_GETBILLS"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@NAME", NAME))
                .Add(New SqlClient.SqlParameter("@CMPID", CMPID))
                .Add(New SqlClient.SqlParameter("@LOCATIONID", LOCATIONID))
                .Add(New SqlClient.SqlParameter("@YEARID", YEARID))
                .Add(New SqlClient.SqlParameter("@RECDATE", RECDATE))
            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return dtTable
    End Function

    Public Function Delete() As DataTable
        Dim dtTable As DataTable
        Try
            Dim strCommand As String = "SP_TRANS_RECEIPTMASTER_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@RECNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@REGISTERNAME", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@Cmpid", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(4)))
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(5)))
            End With
            dtTable = objDBOperation.execute(strCommand, alParameter).Tables(0)
            Return dtTable
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region


End Class
