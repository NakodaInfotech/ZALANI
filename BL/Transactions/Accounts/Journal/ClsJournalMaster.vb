﻿Imports DB

Public Class ClsJournalMaster

    Private objDBOperation As DBOperation
    Public alParaval As New ArrayList
    Public alP As New ArrayList

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

    Public Function save() As DataTable
        Dim DT As DataTable
        Try
            'save Journal
            Dim strCommand As String = "SP_TRANS_JOURNALMASTER_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@JOURNALNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@registername", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@JVdate", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TOTALDEBIT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TOTALCREDIT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@remarks", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BILLREMARKS", alParaval(I)))
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

                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@PAYTYPE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@REFNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DEBIT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CREDIT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@gridsrno", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SPLREMARKS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@PARTYBILLNO", alParaval(I)))
                I += 1

            End With

            DT = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DT

    End Function

    Public Function ACCDELETE() As Integer
        Try
            Dim intResult As Integer
            Dim STRCOMMAND As String
            Dim OBJCOMMON As New ClsCommonMaster
            Dim DTTABLE As DataTable = OBJCOMMON.search(" REGISTER_ABBR", "", " REGISTERMASTER", " AND REGISTER_TYPE = 'JOURNAL' AND REGISTER_NAME = '" & alP(0) & "' AND REGISTER_CMPID = " & alP(2) & " AND REGISTER_LOCATIONID = " & alP(3) & " AND REGISTER_YEARID = " & alP(4))

            STRCOMMAND = "DELETE FROM ACCMASTER WHERE ACC_REGTYPE = '" & DTTABLE.Rows(0).Item(0).ToString & "' AND ACC_TYPE=  'JOURNAL' AND ACC_BILLNO = " & alP(1) & " AND ACC_CMPID = " & alP(2) & " AND ACC_LOCATIONID = " & alP(3) & " AND ACC_YEARID = " & alP(4)
            Dim DT As DataTable = objDBOperation.execute(STRCOMMAND).Tables(0)
            DTTABLE = objDBOperation.execute(STRCOMMAND).Tables(0)
            Return intResult

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ACCOUNTS() As Integer
        Dim intResult As Integer
        Try
            Dim strCommand As String

            'save Journal
            strCommand = "SP_TRANS_JOURNALMASTER_ACCOUNTS_SAVE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@FROMIDNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@AMT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TOIDNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@JVNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@JVdate", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@REMARKS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@REGISTERNAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@cmpid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@locationid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@userid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@yearid", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@PARTYBILLNO", alParaval(I)))
                I += 1

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return intResult

    End Function

    Public Function selectjournal_edit(ByVal JVNO As Integer, ByVal REGISTERNAME As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As DataTable
        Dim dtTable As DataTable
        Try

            Dim strCommand As String = "SP_TRANS_SELECT_JOURNAL_FOR_EDIT"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@JVNO", JVNO))
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

    Public Function update() As DataTable
        Dim DT As DataTable
        Try
            'update Journal Entry
            Dim strCommand As String = "SP_TRANS_JOURNALMASTER_UPDATE"
            Dim alParameter As New ArrayList
            With alParameter

                Dim I As Integer = 0
                .Add(New SqlClient.SqlParameter("@JOURNALNO", alParaval(I)))
                I = I + 1
                .Add(New SqlClient.SqlParameter("@registername", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@JVdate", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TOTALDEBIT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TOTALCREDIT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@remarks", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@BILLREMARKS", alParaval(I)))
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

                .Add(New SqlClient.SqlParameter("@TYPE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@NAME", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@PAYTYPE", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@REFNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@DEBIT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@CREDIT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@gridsrno", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@SPLREMARKS", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@PARTYBILLNO", alParaval(I)))
                I += 1

                .Add(New SqlClient.SqlParameter("@JVNO", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@AMT", alParaval(I)))
                I += 1
                .Add(New SqlClient.SqlParameter("@TDS", alParaval(I)))
                I += 1



            End With
            DT = objDBOperation.execute(strCommand, alParameter).Tables(0)

        Catch ex As Exception
            Throw ex
        End Try
        Return DT
    End Function

    Public Function COPY() As Integer
        Dim intResult As Integer
        Try
            'save purchase Requisition
            Dim strCommand As String = "SP_TRANS_JOURNALMASTER_COPY"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@CPJOURNAL_NO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@REGISTERNAME", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@CMPID", alParaval(2)))

            End With

            intResult = objDBOperation.executeNonQuery(strCommand, alParameter)

        Catch ex As Exception
            Throw ex
        End Try
        Return intResult

    End Function

    Public Function Delete() As DataTable
        Dim dtTable As DataTable
        Try
            Dim strCommand As String = "SP_TRANS_JOURNAL_DELETE"
            Dim alParameter As New ArrayList
            With alParameter
                .Add(New SqlClient.SqlParameter("@JVNO", alParaval(0)))
                .Add(New SqlClient.SqlParameter("@REGISTERNAME", alParaval(1)))
                .Add(New SqlClient.SqlParameter("@USERID", alParaval(2)))
                .Add(New SqlClient.SqlParameter("@Cmpid", alParaval(3)))
                .Add(New SqlClient.SqlParameter("@LOCATIONid", alParaval(4)))
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
