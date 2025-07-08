
Imports Excel
'Imports DB
'Imports AsianERPBL.ModGeneral
'Imports AsianERPBL.Account
Imports System.Data


'Imports Microsoft.Office.Interop.Excel


Public Class clsReportDesigner
    'Private objDBOperation As DB.DBOperation

    'Public objUserDetails As ObjUser
    'Private objRepCenter As New clsRepCenter
    Dim dsResult As New DataSet
    Public ALPARAVAL As New ArrayList
    Dim dv As New DataView

    Public Sub New()
        Try
            'objDBOperation = New DB.DBOperation
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#Region " INTERNAL MANAGEMENT DECLARATIONS ............. "


#Region "Private Declarations..."
    Private objColumn As New Hashtable
    Private objSheet As Excel.Worksheet
    Private objExcel As Excel.Application
    Private objBook As Excel.Workbook
    'Private objUser As New clsUser
    Private RowIndex As Integer
    Private currentColumn As String
    Private _Report_Title As String
    Private _SaveFilePath As String
    Private _PreviewOption As Integer
#End Region

    Public Sub New(ByVal Report_Title As String, ByVal SaveFilePath As String, ByVal PreivewOption As Integer)
        Dim proc As System.Diagnostics.Process
        Try
            _Report_Title = Report_Title
            _SaveFilePath = SaveFilePath
            _PreviewOption = PreivewOption
            'Try
            '    For Each proc In System.Diagnostics.Process.GetProcessesByName("Excel")
            '        proc.Kill()
            '    Next
            'Catch ex As Exception

            'End Try
            ' try{
            '    foreach (Process thisproc in Process.GetProcessesByName(processName)) {
            'if(!thisproc.CloseMainWindow()){
            '//If closing is not successful or no desktop window handle, then force termination.
            'thisproc.Kill();
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SetWorkSheet()
        Try
            objExcel = New Excel.Application
            If Not objExcel Is Nothing Then
                objBook = objExcel.Workbooks.Add
                objSheet = DirectCast(objBook.ActiveSheet, Excel.Worksheet)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Quit()
        Try
            objSheet = Nothing
            objBook.Close()
            ReleaseObject(objBook)
            objExcel.Quit()
            ReleaseObject(objExcel)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ReleaseObject(ByVal o As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(o)
        Catch
        Finally
            o = Nothing
        End Try
    End Sub

    Private Sub SaveAndClose()
        Try
            objExcel.AlertBeforeOverwriting = False
            objExcel.DisplayAlerts = False
            objSheet.SaveAs(_SaveFilePath)

            If _PreviewOption = 1 Then 'Open In Web Browser                
                objBook.WebPagePreview()
            ElseIf _PreviewOption = 2 Then 'Open In Excel                
                objExcel.Visible = True
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Try
                If _PreviewOption <> 2 Then Quit()
            Catch ex As Exception
            End Try
        End Try
    End Sub

    Private Sub SetColumn(ByVal Key As String, ByVal ForColumn As String)
        Try
            objColumn.Add(Key, ForColumn)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ReSetColumn()
        Try
            objColumn.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private ReadOnly Property Column(ByVal Key As String) As String
        Get
            Try
                Return objColumn.Item(Key).ToString
            Catch ex As Exception
                Throw ex
            End Try
        End Get
    End Property

    Private ReadOnly Property Range(ByVal Key As String) As String
        Get
            Try
                Return objColumn.Item(Key).ToString & RowIndex.ToString
            Catch ex As Exception
                Throw ex
            End Try
        End Get
    End Property

    Private Sub Write(ByVal Text As Object, ByVal Range As String, ByVal Align As Excel.XlHAlign, _
        Optional ByVal ToRange As String = Nothing, Optional ByVal FontBold As Boolean = False, _
        Optional ByVal FontSize As Int16 = 9, Optional ByVal WrapText As Boolean = False, Optional ByVal _
fontItalic As Boolean = False)
        Try
            objSheet.Range(Range).FormulaR1C1 = Text
            'objSheet.Range(Range).BorderAround()
            If Not ToRange Is Nothing Then
                objSheet.Range(Range, ToRange).Merge()
                'objSheet.Range(Range, ToRange).BorderAround()
            End If
            objSheet.Range(Range).HorizontalAlignment = Align
            If FontBold Then objSheet.Range(Range).Font.Bold = True
            If FontSize > 0 Then objSheet.Range(Range).Font.Size = FontSize
            If WrapText Then objSheet.Range(Range).WrapText = True
            If fontItalic Then objSheet.Range(Range).Font.Italic = True


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FORMULA(ByVal Text As Object, ByVal Range As String, ByVal Align As Excel.XlHAlign, _
       Optional ByVal ToRange As String = Nothing, Optional ByVal FontBold As Boolean = False, _
       Optional ByVal FontSize As Int16 = 9, Optional ByVal WrapText As Boolean = False, Optional ByVal _
fontItalic As Boolean = False)
        Try
            objSheet.Range(Range).Formula = Text
            'objSheet.Range(Range).BorderAround()
            If Not ToRange Is Nothing Then
                objSheet.Range(Range, ToRange).Merge()
                'objSheet.Range(Range, ToRange).BorderAround()
            End If
            objSheet.Range(Range).HorizontalAlignment = Align
            If FontBold Then objSheet.Range(Range).Font.Bold = True
            If FontSize > 0 Then objSheet.Range(Range).Font.Size = FontSize
            If WrapText Then objSheet.Range(Range).WrapText = True
            If fontItalic Then objSheet.Range(Range).Font.Italic = True


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LOCKCELLS(ByVal VALUE As Boolean, ByVal Range As String, Optional ByVal ToRange As String = Nothing)
        Try
            If Not ToRange Is Nothing Then
                objSheet.Range(Range, ToRange).Locked = VALUE
            Else
                objSheet.Range(Range).Locked = VALUE
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SetBorder(ByVal RowIndex As Integer, Optional ByVal Range As String = Nothing, Optional ByVal ToRange As String = Nothing)

        Dim intI As Integer = 0
        ''RowIndex = 0
        'obj()
        'objSheet.Selec
        'objExcel.Selection("A1:N17").ToString()
        objSheet.Range(Range, ToRange).Select()
        objSheet.Range(Range, ToRange).BorderAround(, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic, )
        'For intI = 1 To RowIndex
        '    objSheet.Range(Range, ToRange).Select()
        '    objSheet.Range(Range, ToRange).BorderAround(, XlBorderWeight.xlThin, XlColorIndex.xlColorIndexAutomatic, )
        '    intI += 1
        'Next
    End Sub

    Private Sub SetColumnWidth(ByVal Range As String, ByVal width As Integer)
        'objSheet.Range(Range).BorderAround()
        objSheet.Range(Range).ColumnWidth = width
        '  = objSheet.Range(Range).Select()
        'objSheet.Range(Range).EditionOptions(XlEditionType.xlPublisher, XlEditionOptionsOption.xlAutomaticUpdate, , , XlPictureAppearance.xlScreen, XlPictureAppearance.xlScreen)
    End Sub

    Private Function NextColumn() As String
        Dim nxtColumn As String = String.Empty
        Try
            Dim i As Integer = 0
            Dim length As Integer = currentColumn.Length
            For i = length - 1 To 0 Step -1
                If Not (currentColumn(i).ToString.ToUpper = "Z") Then
                    Dim substr As String = String.Empty
                    If i > 0 Then
                        substr = currentColumn.Substring(0, i)
                    End If
                    nxtColumn = Convert.ToString(Convert.ToChar(Convert.ToInt32(currentColumn(i)) + 1)) & nxtColumn
                    nxtColumn = substr & nxtColumn
                    Exit For
                ElseIf currentColumn(i).ToString.ToUpper = "Z" Then
                    nxtColumn = "A" & nxtColumn
                End If
                If i = 0 Then
                    If Convert.ToString(currentColumn(i)).ToUpper = "Z" Then
                        nxtColumn = "A" & nxtColumn
                    End If
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try
        currentColumn = nxtColumn
        Return nxtColumn
    End Function

    Private Sub MeargeCell(ByVal StartCol As String, ByVal StartRow As String, ByVal EndCol As String, ByVal EndRow As String)
        Try

            'objSheet.Range(StartCol & StartRow & ":" & EndCol & EndRow).Merge()
            objSheet.Range(StartCol, EndCol).Merge()

            'With objSheet.Selection                
            '    .WrapText = False
            '    .Orientation = 0
            '    .AddIndent = False
            '    .IndentLevel = 0
            '    .ShrinkToFit = False                
            '    .MergeCells = True
            'End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "CMPHEADER"

    Sub CMPHEADER(ByVal CMPID As Integer, ByVal REPORTTITLE As String)
        Try
            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            'CMPNAME
            Dim DTCMP As System.Data.DataTable = OBJCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            RowIndex = 2
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("6"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("6"))

            'ADD1
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range("6"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("6"))

            'ADD2
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range("6"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("6"))

            RowIndex += 1
            Write(REPORTTITLE, Range("1"), XlHAlign.xlHAlignCenter, Range("6"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("6"))


            'FREEZE TOP 7 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("6").ToString & 8).Select()
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("6").ToString & 8).Application.ActiveWindow.FreezePanes = True

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "INVOICE SUMMARY REPORT"

    Public Function INVOICE_SUMMARY_EXCEL(ByVal CONDITION As String) As Object
        Try
            Dim objCMN As New ClsCommon

            Dim DT As System.Data.DataTable = objCMN.search(" INVOICEMASTER.INVOICE_NO AS INVOICENO, INVOICEMASTER.INVOICE_DATE AS DATE, CUSTOMERMASTER.Customer_cmpname AS NAME, INVOICEMASTER.INVOICE_ORDERNO AS PONO, INVOICEMASTER.INVOICE_ORDERDATE AS PODATE, SUM(INVOICEMASTER_DESC.INVOICE_QTY) AS TOTALSETS, INVOICEMASTER.INVOICE_GRANDTOTAL AS TOTALAMT, (CASE WHEN SUM(INVOICE_QTY) < SALEORDER.SO_TOTALQTY THEN 'PENDING' ELSE 'COMPLETED' END) AS STATUS, CMPMASTER.cmp_name AS CMPNAME, CMPMASTER.cmp_add1 AS ADD1, CMPMASTER.cmp_add2 AS ADD2, CMPMASTER.cmp_invinitials AS CMPINITIALS ", "", " INVOICEMASTER_DESC INNER JOIN INVOICEMASTER ON INVOICEMASTER_DESC.INVOICE_NO = INVOICEMASTER.INVOICE_NO AND INVOICEMASTER_DESC.INVOICE_REGISTERID = INVOICEMASTER.INVOICE_REGISTERID AND INVOICEMASTER_DESC.INVOICE_INITIALS = INVOICEMASTER.INVOICE_INITIALS AND INVOICEMASTER_DESC.INVOICE_CMPID = INVOICEMASTER.INVOICE_CMPID AND INVOICEMASTER_DESC.INVOICE_LOCATIONID = INVOICEMASTER.INVOICE_LOCATIONID AND INVOICEMASTER_DESC.INVOICE_YEARID = INVOICEMASTER.INVOICE_YEARID INNER JOIN CUSTOMERMASTER ON INVOICEMASTER.INVOICE_LEDGERID = CUSTOMERMASTER.Customer_id AND INVOICEMASTER.INVOICE_CMPID = CUSTOMERMASTER.Customer_cmpid AND INVOICEMASTER.INVOICE_LOCATIONID = CUSTOMERMASTER.Customer_locationid AND INVOICEMASTER.INVOICE_YEARID = CUSTOMERMASTER.Customer_yearid INNER JOIN CMPMASTER ON INVOICEMASTER.INVOICE_CMPID = CMPMASTER.cmp_id LEFT OUTER JOIN SALEORDER ON INVOICEMASTER.INVOICE_YEARID = SALEORDER.so_yearid AND INVOICEMASTER.INVOICE_LOCATIONID = SALEORDER.so_locationid AND INVOICEMASTER.INVOICE_CMPID = SALEORDER.so_cmpid AND INVOICEMASTER.INVOICE_ORDERNO = SALEORDER.so_pono", CONDITION & " GROUP BY INVOICEMASTER.INVOICE_NO, INVOICEMASTER.INVOICE_DATE, CUSTOMERMASTER.Customer_cmpname, INVOICEMASTER.INVOICE_ORDERNO, INVOICEMASTER.INVOICE_ORDERDATE, INVOICEMASTER.INVOICE_GRANDTOTAL, SALEORDER.so_totalqty, CMPMASTER.cmp_name, CMPMASTER.cmp_add1, CMPMASTER.cmp_add2, CMPMASTER.cmp_invinitials")

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 6)
            Next

            SetColumnWidth("H1", 15)
            SetColumnWidth("E1", 15)
            'SetColumnWidth("T1", 7)
            'SetColumnWidth("U1", 10)


            '''''''''''Report Title
            'CMPNAME
            RowIndex += 1
            Write(DT.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("25"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("25"))

            'ADD1
            RowIndex += 1
            Write(DT.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range("25"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("25"))

            'ADD2
            RowIndex += 1
            Write(DT.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range("25"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("25"))

            RowIndex += 1
            Write("INVOICE SUMMARY", Range("1"), XlHAlign.xlHAlignCenter, Range("25"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("25"))


            RowIndex += 2
            Write("Inv No.", Range("1"), XlHAlign.xlHAlignCenter, Range("2"), True, 10)
            Write("Date", Range("3"), XlHAlign.xlHAlignCenter, Range("4"), True, 10)
            Write("Customer", Range("5"), XlHAlign.xlHAlignCenter, Range("7"), True, 10)
            Write("PO No", Range("8"), XlHAlign.xlHAlignCenter, Range("10"), True, 10)
            Write("PO Date", Range("11"), XlHAlign.xlHAlignCenter, Range("12"), True, 10)
            Write("Total Sets", Range("13"), XlHAlign.xlHAlignCenter, Range("14"), True, 10)
            Write("Total Amt", Range("15"), XlHAlign.xlHAlignCenter, Range("16"), True, 10)
            Write("Transport Name", Range("17"), XlHAlign.xlHAlignCenter, Range("19"), True, 10)
            Write("LR No", Range("20"), XlHAlign.xlHAlignCenter, Range("21"), True, 10)
            Write("LR Date", Range("22"), XlHAlign.xlHAlignCenter, Range("23"), True, 10)
            Write("Status", Range("24"), XlHAlign.xlHAlignCenter, Range("25"), True, 10)

            SetBorder(RowIndex, Range("1"), Range("25"))

            For Each dr As DataRow In DT.Rows
                RowIndex += 1
                Write(dr("INVOICENO"), Range("1"), XlHAlign.xlHAlignCenter, Range("2"), False, 10)
                Write(dr("DATE"), Range("3"), XlHAlign.xlHAlignLeft, Range("4"), False, 10)
                Write(dr("NAME"), Range("5"), XlHAlign.xlHAlignLeft, Range("7"), False, 10)
                Write(dr("PONO"), Range("8"), XlHAlign.xlHAlignLeft, Range("10"), False, 10)
                Write(dr("PODATE"), Range("11"), XlHAlign.xlHAlignLeft, Range("12"), False, 10)
                Write(dr("TOTALSETS"), Range("13"), XlHAlign.xlHAlignRight, Range("14"), False, 10)
                Write(dr("TOTALAMT"), Range("15"), XlHAlign.xlHAlignRight, Range("16"), False, 10)
            Next

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex - DT.Rows.Count, Range("2"))
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex - DT.Rows.Count, Range("4"))
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex - DT.Rows.Count, Range("7"))
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex - DT.Rows.Count, Range("10"))
            SetBorder(RowIndex, objColumn.Item("11").ToString & RowIndex - DT.Rows.Count, Range("12"))
            SetBorder(RowIndex, objColumn.Item("13").ToString & RowIndex - DT.Rows.Count, Range("14"))
            SetBorder(RowIndex, objColumn.Item("15").ToString & RowIndex - DT.Rows.Count, Range("16"))
            SetBorder(RowIndex, objColumn.Item("17").ToString & RowIndex - DT.Rows.Count, Range("19"))
            SetBorder(RowIndex, objColumn.Item("20").ToString & RowIndex - DT.Rows.Count, Range("21"))
            SetBorder(RowIndex, objColumn.Item("22").ToString & RowIndex - DT.Rows.Count, Range("23"))
            SetBorder(RowIndex, objColumn.Item("24").ToString & RowIndex - DT.Rows.Count, Range("25"))

            RowIndex += 1
            Write("Total :", Range("1"), XlHAlign.xlHAlignRight, Range("12"), True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("12"))

            Write(DT.Compute("sum(TOTALSETS)", ""), Range("13"), XlHAlign.xlHAlignRight, Range("14"), True, 10)
            Write(DT.Compute("sum(TOTALAMT)", ""), Range("15"), XlHAlign.xlHAlignRight, Range("16"), True, 10)
            SetBorder(RowIndex, objColumn.Item("13").ToString & RowIndex, Range("14"))
            SetBorder(RowIndex, objColumn.Item("15").ToString & RowIndex, Range("16"))
            SetBorder(RowIndex, objColumn.Item("17").ToString & RowIndex, Range("25"))


            RowIndex += 1
            Write("Status :", Range("1"), XlHAlign.xlHAlignRight, Range("12"), True, 10)
            Write(DT.Rows(0).Item("STATUS"), Range("13"), XlHAlign.xlHAlignLeft, Range("25"), True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("25"))

            objSheet.Range(objColumn.Item("13").ToString & 1, objColumn.Item("13").ToString & RowIndex).NumberFormat = "0.00"
            objSheet.Range(objColumn.Item("15").ToString & 1, objColumn.Item("15").ToString & RowIndex).NumberFormat = "0.00"

            objBook.Application.ActiveWindow.Zoom = 95

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlLandscape
            '    .TopMargin = 144
            '    .LeftMargin = 50.4
            '    .RightMargin = 0
            '    .BottomMargin = 0
            '    .Zoom = False
            '    '.FitToPagesTall = 1
            '    '.FitToPagesWide = 1
            'End With

            SetBorder(RowIndex, objColumn.Item("1").ToString & 2, objColumn.Item("25").ToString & RowIndex + 2)
            SaveAndClose()


        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "SALE SUMMARY (REGISTER WISE)"

    Public Function REGISTERSALESUMM_EXCEL(ByVal CONDITION As String, ByVal CMPID As Integer, ByVal LOCATIONID As Integer, ByVal YEARID As Integer) As Object
        Try
            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 15)
            Next

            Dim OBJCMN As New ClsCommon
            Dim DT As New System.Data.DataTable
            Dim DTREG As New System.Data.DataTable

            RowIndex += 6
            'DIRECTLY ADDING CLOUMS ADD TITLE LATER IN THE END 
            'COZ HERE WE DONT KNOW NO OF COLUMS
            Write("Month", Range("1"), XlHAlign.xlHAlignCenter, , False, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, Range("1"))

            Dim R As Integer = 2

            DTREG = OBJCMN.search("REGISTER_NAME AS REGNAME", "", "REGISTERMASTER", " AND REGISTER_TYPE = 'SALE' AND REGISTER_CMPID = " & CMPID & " AND REGISTER_LOCATIONID = " & LOCATIONID & " AND REGISTER_YEARID = " & YEARID)
            If DTREG.Rows.Count > 0 Then
                R = 2
                For Each DTREGROW As System.Data.DataRow In DTREG.Rows
                    Write(DTREGROW("REGNAME"), Range(R.ToString), XlHAlign.xlHAlignCenter, , False, 10)
                    SetBorder(RowIndex, objColumn.Item(R.ToString).ToString & RowIndex, Range(R.ToString))
                    R += 1
                Next
            End If
            Write("TOTAL SALES", Range((DTREG.Rows.Count + 2).ToString), XlHAlign.xlHAlignCenter, , True, 10)
            SetBorder(RowIndex, objColumn.Item((DTREG.Rows.Count + 2).ToString).ToString & RowIndex, Range((DTREG.Rows.Count + 2).ToString))


            Dim J As Integer = 0
            For I = 4 To 15

                'FOR GETTING MONTH
                J = I
                If J > 12 Then
                    J -= 12
                End If


                RowIndex += 1
                Write(MonthName(J), Range("1"), XlHAlign.xlHAlignLeft, , False, 10)

                DT = OBJCMN.search(" SUM(REPORT_SP_ACCOUNTS_INVOICESUMMARY.CREDIT) AS AMOUNT, [REGISTER NAME] AS REGNAME ", "", " REPORT_SP_ACCOUNTS_INVOICESUMMARY ", CONDITION & " AND MONTH(DATE) = " & J & " AND CMPID = " & CMPID & " AND LOCATIONID = " & LOCATIONID & " AND YEARID = " & YEARID & "  GROUP BY [REGISTER NAME]")
                If DT.Rows.Count > 0 Then
                    For Each DTROW As DataRow In DT.Rows
                        For P As Integer = 2 To DTREG.Rows.Count + 1
                            If objSheet.Range(objColumn.Item(P.ToString).ToString & 7).Text = DTROW("REGNAME") Then
                                Write(DTROW("AMOUNT"), Range(P.ToString), XlHAlign.xlHAlignRight, , False, 10)
                            End If
                        Next
                    Next
                End If

            Next

            RowIndex += 1
            Write("TOTAL", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item((DTREG.Rows.Count + 2).ToString).ToString & RowIndex)

            For P = 8 To RowIndex - 1
                FORMULA("=SUM(" & objColumn.Item("2").ToString & P & ":" & objColumn.Item(((DTREG.Rows.Count) + 1).ToString).ToString & P & ")", objColumn.Item(((DTREG.Rows.Count) + 2).ToString).ToString & P, XlHAlign.xlHAlignRight, , True, 10)
            Next

            For P = 1 To DTREG.Rows.Count + 2
                If P > 1 Then FORMULA("=SUM(" & objColumn.Item(P.ToString).ToString & RowIndex - 1 & ":" & objColumn.Item(P.ToString).ToString & 8 & ")", Range(P.ToString), XlHAlign.xlHAlignRight, , True, 10)
                SetBorder(RowIndex, objColumn.Item(P.ToString).ToString & 7, objColumn.Item(P.ToString).ToString & RowIndex)
            Next

            '''''''''''Report Title
            'CMPNAME
            Dim DTCMP As System.Data.DataTable = OBJCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            RowIndex = 2
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DTREG.Rows.Count) + 2).ToString), True, 14)
            SetBorder(RowIndex, Range("1"), Range(((DTREG.Rows.Count) + 2).ToString))

            'ADD1
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DTREG.Rows.Count) + 2).ToString), True, 10)
            SetBorder(RowIndex, Range("1"), Range(((DTREG.Rows.Count) + 2).ToString))

            'ADD2
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range(((DTREG.Rows.Count) + 2).ToString), True, 10)
            SetBorder(RowIndex, Range("1"), Range(((DTREG.Rows.Count) + 2).ToString))

            RowIndex += 1
            Write("SALE SUMMARY", Range("1"), XlHAlign.xlHAlignCenter, Range(((DTREG.Rows.Count) + 2).ToString), True, 12)
            SetBorder(RowIndex, Range("1"), Range(((DTREG.Rows.Count) + 2).ToString))


            'FREEZE TOP 7 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item(((DTREG.Rows.Count) + 2).ToString).ToString & 8).Select()
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item(((DTREG.Rows.Count) + 2).ToString).ToString & 8).Application.ActiveWindow.FreezePanes = True

            SetBorder(RowIndex + 1, objColumn.Item("1").ToString & RowIndex + 1, objColumn.Item(((DTREG.Rows.Count) + 2).ToString).ToString & RowIndex + 1)

            objBook.Application.ActiveWindow.Zoom = 100

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlPortrait
            '    .TopMargin = 10
            '    .LeftMargin = 5
            '    .RightMargin = 5
            '    .BottomMargin = 10
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

#Region "MIS REPORTS"

    Public Function MISALLDAILY_EXCEL(ByVal CMPID As Integer, ByVal YEARID As Integer, ByVal FROMDATE As Date, ByVal TODATE As Date) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 13)
            Next

            SetColumnWidth(Range("1"), 5)
            SetColumnWidth(Range("2"), 20)


            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            Dim DT As New System.Data.DataTable
            Dim DTNP As New System.Data.DataTable
            'CMPNAME
            Dim DTCMP As System.Data.DataTable = OBJCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            RowIndex = 2
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("12"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("12"))

            'ADD1
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range("12"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("12"))

            'ADD2
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range("12"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("12"))

            RowIndex += 1
            Write("DAILY MIS REPORT (" & Format(FROMDATE, "dd/MM/yyyy") & "-" & Format(TODATE, "dd/MM/yyyy") & ")", Range("1"), XlHAlign.xlHAlignCenter, Range("12"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("12"))


            'FREEZE TOP 6 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("12").ToString & 8).Select()
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("12").ToString & 8).Application.ActiveWindow.FreezePanes = True


            SetBorder(RowIndex + 1, objColumn.Item("1").ToString & RowIndex + 1, objColumn.Item("12").ToString & RowIndex + 1)

            RowIndex += 2
            Write("SR.", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10)
            Write("PARTICULARS", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("UNITS", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("TODAYS", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("UPTO LAST DATE", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("UPTO DATE (MONTH)", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("UPTO DATE (YEAR)", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & RowIndex, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & RowIndex, objColumn.Item("11").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("12").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("12").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)



            'SALES
            RowIndex += 1
            Write("1", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("SALES", Range("2"), XlHAlign.xlHAlignLeft, , True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)

            RowIndex += 1
            Write("Quantity", Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
            Write("Meters", Range("3"), XlHAlign.xlHAlignLeft, , False, 10)

            DT = OBJCMN.search(" ISNULL(SUM(INVOICE_TOTALMTRS),0) AS INVMTRS", "", " INVOICEMASTER ", " AND invoice_DATE = CAST(GETDATE() AS DATE) AND INVOICE_YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("INVMTRS")), Range("4"), XlHAlign.xlHAlignRight, , False, 10)

            DT = OBJCMN.search(" ISNULL(SUM(INVOICE_TOTALMTRS),0) AS INVMTRS", "", " INVOICEMASTER ", " AND invoice_DATE < CAST(GETDATE() AS DATE) AND MONTH(invoice_DATE) = MONTH(GETDATE()) AND INVOICE_YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("INVMTRS")), Range("5"), XlHAlign.xlHAlignRight, , False, 10)

            DT = OBJCMN.search(" ISNULL(SUM(INVOICE_TOTALMTRS),0) AS INVMTRS", "", " INVOICEMASTER ", " AND invoice_DATE <= CAST(GETDATE() AS DATE) AND MONTH(invoice_DATE) = MONTH(GETDATE()) AND INVOICE_YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("INVMTRS")), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)

            DT = OBJCMN.search(" ISNULL(SUM(INVOICE_TOTALMTRS),0) AS INVMTRS", "", " INVOICEMASTER ", " AND invoice_DATE <= CAST(GETDATE() AS DATE) AND INVOICE_YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("INVMTRS")), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)


            'SALES VALUE
            RowIndex += 1
            Write("Value", Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
            Write("Rupees", Range("3"), XlHAlign.xlHAlignLeft, , False, 10)

            DT = OBJCMN.search(" ISNULL(SUM(INVOICE_GRANDTOTAL),0) AS GTOTAL", "", " INVOICEMASTER ", " AND invoice_DATE = CAST(GETDATE() AS DATE) AND INVOICE_YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("GTOTAL")), Range("4"), XlHAlign.xlHAlignRight, , False, 10)

            DT = OBJCMN.search(" ISNULL(SUM(INVOICE_GRANDTOTAL),0) AS GTOTAL", "", " INVOICEMASTER ", " AND invoice_DATE < CAST(GETDATE() AS DATE) AND MONTH(invoice_DATE) = MONTH(GETDATE()) AND INVOICE_YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("GTOTAL")), Range("5"), XlHAlign.xlHAlignRight, , False, 10)

            DT = OBJCMN.search(" ISNULL(SUM(INVOICE_GRANDTOTAL),0) AS GTOTAL", "", " INVOICEMASTER ", " AND invoice_DATE <= CAST(GETDATE() AS DATE) AND MONTH(invoice_DATE) = MONTH(GETDATE()) AND INVOICE_YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("GTOTAL")), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)

            DT = OBJCMN.search(" ISNULL(SUM(INVOICE_GRANDTOTAL),0) AS GTOTAL", "", " INVOICEMASTER ", " AND invoice_DATE <= CAST(GETDATE() AS DATE) AND INVOICE_YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("GTOTAL")), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)





            'SALES ORDER
            RowIndex += 2
            Write("2", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("ORDERS RECEIVED", Range("2"), XlHAlign.xlHAlignLeft, , True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)

            RowIndex += 1
            Write("Number", Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
            Write("No.", Range("3"), XlHAlign.xlHAlignLeft, , False, 10)

            DT = OBJCMN.search(" ISNULL(COUNT(SO_NO),0) TOTALSO", "", " SALEORDER ", " AND SO_DATE = CAST(GETDATE() AS DATE) AND SO_YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("TOTALSO")), Range("4"), XlHAlign.xlHAlignRight, , False, 10)

            DT = OBJCMN.search(" ISNULL(COUNT(SO_NO),0) TOTALSO", "", " SALEORDER ", " AND SO_DATE < CAST(GETDATE() AS DATE) AND MONTH(SO_DATE) = MONTH(GETDATE()) AND SO_YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("TOTALSO")), Range("5"), XlHAlign.xlHAlignRight, , False, 10)

            DT = OBJCMN.search(" ISNULL(COUNT(SO_NO),0) TOTALSO", "", " SALEORDER ", " AND SO_DATE <= CAST(GETDATE() AS DATE) AND MONTH(SO_DATE) = MONTH(GETDATE()) AND SO_YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("TOTALSO")), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)

            DT = OBJCMN.search(" ISNULL(COUNT(SO_NO),0) TOTALSO", "", " SALEORDER ", " AND SO_DATE <= CAST(GETDATE() AS DATE) AND SO_YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("TOTALSO")), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)


            'ORDER METERS
            RowIndex += 1
            Write("Quantity", Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
            Write("Meters", Range("3"), XlHAlign.xlHAlignLeft, , False, 10)

            DT = OBJCMN.search(" ISNULL(SUM(SO_TOTALMTRS),0) TOTALSO", "", " SALEORDER ", " AND SO_DATE = CAST(GETDATE() AS DATE) AND SO_YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("TOTALSO")), Range("4"), XlHAlign.xlHAlignRight, , False, 10)

            DT = OBJCMN.search(" ISNULL(SUM(SO_TOTALMTRS),0) TOTALSO", "", " SALEORDER ", " AND SO_DATE < CAST(GETDATE() AS DATE) AND MONTH(SO_DATE) = MONTH(GETDATE()) AND SO_YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("TOTALSO")), Range("5"), XlHAlign.xlHAlignRight, , False, 10)

            DT = OBJCMN.search(" ISNULL(SUM(SO_TOTALMTRS),0) TOTALSO", "", " SALEORDER ", " AND SO_DATE <= CAST(GETDATE() AS DATE) AND MONTH(SO_DATE) = MONTH(GETDATE()) AND SO_YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("TOTALSO")), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)

            DT = OBJCMN.search(" ISNULL(SUM(SO_TOTALMTRS),0) TOTALSO", "", " SALEORDER ", " AND SO_DATE <= CAST(GETDATE() AS DATE) AND SO_YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("TOTALSO")), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)


            'ORDER VALUE
            RowIndex += 1
            Write("Value", Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
            Write("Rupees", Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)

            DT = OBJCMN.search(" ISNULL(SUM(SO_TOTALAMT),0) TOTALSO", "", " SALEORDER ", " AND SO_DATE = CAST(GETDATE() AS DATE) AND SO_YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("TOTALSO")), Range("4"), XlHAlign.xlHAlignRight, , False, 10)

            DT = OBJCMN.search(" ISNULL(SUM(SO_TOTALAMT),0) TOTALSO", "", " SALEORDER ", " AND SO_DATE < CAST(GETDATE() AS DATE) AND MONTH(SO_DATE) = MONTH(GETDATE()) AND SO_YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("TOTALSO")), Range("5"), XlHAlign.xlHAlignRight, , False, 10)

            DT = OBJCMN.search(" ISNULL(SUM(SO_TOTALAMT),0) TOTALSO", "", " SALEORDER ", " AND SO_DATE <= CAST(GETDATE() AS DATE) AND MONTH(SO_DATE) = MONTH(GETDATE()) AND SO_YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("TOTALSO")), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)

            DT = OBJCMN.search(" ISNULL(SUM(SO_TOTALAMT),0) TOTALSO", "", " SALEORDER ", " AND SO_DATE <= CAST(GETDATE() AS DATE) AND SO_YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("TOTALSO")), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)





            'GREY PURCHASE
            RowIndex += 2
            Write("3", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("GREY PURCHASE", Range("2"), XlHAlign.xlHAlignLeft, , True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)

            RowIndex += 1
            Write("Quantity", Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
            Write("Meters", Range("3"), XlHAlign.xlHAlignLeft, , False, 10)

            DT = OBJCMN.search(" ISNULL(SUM(GRN_TOTALMTRS),0) AS GRNMTRS", "", " GRN ", " AND GRN_TYPE = 'Job Work' AND GRN_DATE = CAST(GETDATE() AS DATE) AND GRN_YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("GRNMTRS")), Range("4"), XlHAlign.xlHAlignRight, , False, 10)

            DT = OBJCMN.search(" ISNULL(SUM(GRN_TOTALMTRS),0) AS GRNMTRS", "", " GRN ", " AND GRN_TYPE = 'Job Work' AND GRN_DATE < CAST(GETDATE() AS DATE) AND MONTH(GRN_DATE) = MONTH(GETDATE()) AND GRN_YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("GRNMTRS")), Range("5"), XlHAlign.xlHAlignRight, , False, 10)

            DT = OBJCMN.search(" ISNULL(SUM(GRN_TOTALMTRS),0) AS GRNMTRS", "", " GRN ", " AND GRN_TYPE = 'Job Work' AND GRN_DATE <= CAST(GETDATE() AS DATE) AND MONTH(GRN_DATE) = MONTH(GETDATE()) AND GRN_YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("GRNMTRS")), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)

            DT = OBJCMN.search(" ISNULL(SUM(GRN_TOTALMTRS),0) AS GRNMTRS", "", " GRN ", " AND GRN_TYPE = 'Job Work' AND GRN_DATE <= CAST(GETDATE() AS DATE) AND GRN_YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("GRNMTRS")), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)


            RowIndex += 1
            Write("Value", Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
            Write("Rupees", Range("3"), XlHAlign.xlHAlignLeft, , False, 10)

            DT = OBJCMN.search(" ISNULL(SUM(BILL_GRANDTOTAL),0) AS TOTALAMT", "", " PURCHASEMASTER ", " AND PURCHASEMASTER.BILL_PARTYBILLDATE = CAST(GETDATE() AS DATE) AND PURCHASEMASTER.BILL_YEARID = " & YEARID & " AND PURCHASEMASTER.BILL_INITIALS IN (SELECT DISTINCT BILL_INITIALS FROM GRN INNER JOIN PURCHASEMASTER_DESC ON GRN_NO = PURCHASEMASTER_DESC.BILL_GRNNO And grn_yearid = PURCHASEMASTER_DESC.BILL_yearid And PURCHASEMASTER_DESC.BILL_TYPE = 'Job Work' WHERE GRN_DATE = CAST(GETDATE() AS DATE) AND GRN_YEARID = " & YEARID & ")")
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("TOTALAMT")), Range("4"), XlHAlign.xlHAlignRight, , False, 10)

            DT = OBJCMN.search(" ISNULL(SUM(BILL_GRANDTOTAL),0) AS TOTALAMT", "", " PURCHASEMASTER ", " AND PURCHASEMASTER.BILL_PARTYBILLDATE < CAST(GETDATE() AS DATE) AND MONTH(PURCHASEMASTER.BILL_PARTYBILLDATE) = MONTH(GETDATE()) AND PURCHASEMASTER.BILL_YEARID = " & YEARID & " AND PURCHASEMASTER.BILL_INITIALS IN (SELECT DISTINCT BILL_INITIALS FROM GRN INNER JOIN PURCHASEMASTER_DESC ON GRN_NO = PURCHASEMASTER_DESC.BILL_GRNNO And grn_yearid = PURCHASEMASTER_DESC.BILL_yearid And PURCHASEMASTER_DESC.BILL_TYPE = 'Job Work' WHERE GRN_DATE < CAST(GETDATE() AS DATE) AND GRN_YEARID = " & YEARID & ")")
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("TOTALAMT")), Range("5"), XlHAlign.xlHAlignRight, , False, 10)

            DT = OBJCMN.search(" ISNULL(SUM(BILL_GRANDTOTAL),0) AS TOTALAMT", "", " PURCHASEMASTER ", " AND PURCHASEMASTER.BILL_PARTYBILLDATE <= CAST(GETDATE() AS DATE) AND MONTH(PURCHASEMASTER.BILL_PARTYBILLDATE) = MONTH(GETDATE()) AND PURCHASEMASTER.BILL_YEARID = " & YEARID & " AND PURCHASEMASTER.BILL_INITIALS IN (SELECT DISTINCT BILL_INITIALS FROM GRN INNER JOIN PURCHASEMASTER_DESC ON GRN_NO = PURCHASEMASTER_DESC.BILL_GRNNO And grn_yearid = PURCHASEMASTER_DESC.BILL_yearid And PURCHASEMASTER_DESC.BILL_TYPE = 'Job Work' WHERE GRN_DATE <= CAST(GETDATE() AS DATE) AND GRN_YEARID = " & YEARID & ")")
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("TOTALAMT")), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)

            DT = OBJCMN.search(" ISNULL(SUM(BILL_GRANDTOTAL),0) AS TOTALAMT", "", " PURCHASEMASTER ", " AND PURCHASEMASTER.BILL_PARTYBILLDATE <= CAST(GETDATE() AS DATE) AND PURCHASEMASTER.BILL_YEARID = " & YEARID & " AND PURCHASEMASTER.BILL_INITIALS IN (SELECT DISTINCT BILL_INITIALS FROM GRN INNER JOIN PURCHASEMASTER_DESC ON GRN_NO = PURCHASEMASTER_DESC.BILL_GRNNO And grn_yearid = PURCHASEMASTER_DESC.BILL_yearid And PURCHASEMASTER_DESC.BILL_TYPE = 'Job Work' WHERE GRN_DATE <= CAST(GETDATE() AS DATE) AND GRN_YEARID = " & YEARID & ")")
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("TOTALAMT")), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)




            'STOCK
            RowIndex += 2
            Write("STOCKS", Range("2"), XlHAlign.xlHAlignLeft, , True, 13)
            Write("UNITS", Range("3"), XlHAlign.xlHAlignCenter, , True, 13)
            Write("GREY STOCK TRANSPORT", Range("4"), XlHAlign.xlHAlignCenter, , True, 13)
            Write("GREY STOCK PROCESS", Range("5"), XlHAlign.xlHAlignCenter, , True, 13)
            Write("PROCESS STOCK", Range("6"), XlHAlign.xlHAlignCenter, , True, 13, True)
            Write("WIP TOTAL STOCK", Range("7"), XlHAlign.xlHAlignCenter, , True, 13, True)
            Write("GODOWN STOCK (FRESH)", Range("8"), XlHAlign.xlHAlignCenter, , True, 13, True)
            Write("GODOWN STOCK (PCS)", Range("9"), XlHAlign.xlHAlignCenter, , True, 13, True)
            Write("PACKING STOCK", Range("10"), XlHAlign.xlHAlignCenter, , True, 13, True)
            Write("READY FOR DISPATCH", Range("11"), XlHAlign.xlHAlignCenter, , True, 13, True)
            Write("FINISH TOTAL STOCK", Range("12"), XlHAlign.xlHAlignCenter, , True, 13, True)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)


            RowIndex += 1
            Write("4", Range("1"), XlHAlign.xlHAlignLeft, , False, 10)
            Write("Opening Stock", Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
            Write("Meters", Range("3"), XlHAlign.xlHAlignLeft, , False, 10)

            'GREY STOCK TRANSPORT
            DT = OBJCMN.SEARCH(" ISNULL(SUM(BALMTRS),0) AS GREYMTRS", "", " GREYSTOCKTRANSPORT ", " AND DATE < CAST(GETDATE() AS DATE) AND YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("GREYMTRS")), Range("4"), XlHAlign.xlHAlignRight, , False, 10)

            'GREY STOCK PROCESS
            DT = OBJCMN.SEARCH(" ISNULL(SUM(BALMTRS),0) AS GREYMTRS", "", " GREYSTOCKPROCESS ", " AND DATE < CAST(GETDATE() AS DATE) AND YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("GREYMTRS")), Range("5"), XlHAlign.xlHAlignRight, , False, 10)

            'PROCESS STOCK
            DT = OBJCMN.search(" ISNULL(SUM(BALMTRS),0) AS PROCESSMTRS", "", " LOT_VIEW ", " and LOT_VIEW.LOTCOMPLETED ='FALSE' AND DATE < CAST(GETDATE() AS DATE) AND YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("PROCESSMTRS")), Range("6"), XlHAlign.xlHAlignRight, , False, 10)

            'TOTAL WIP OPENING STOCK
            FORMULA("=SUM(" & objColumn.Item("4").ToString & RowIndex & ":" & objColumn.Item("6").ToString & RowIndex & ")", Range("7"), XlHAlign.xlHAlignRight, , True, 10)

            'BARCODE STOCK ONLY FRESH PIECETYPE
            DT = OBJCMN.search(" ISNULL(SUM(MTRS),0) AS TOTALMTRS", "", " BARCODESTOCK ", " and PIECETYPE ='FRESH' AND DATE < CAST(GETDATE() AS DATE) AND YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("TOTALMTRS")), Range("8"), XlHAlign.xlHAlignRight, , False, 10)


            'BARCODE STOCK ONLY PIECES PIECETYPE
            DT = OBJCMN.search(" ISNULL(SUM(MTRS),0) AS TOTALMTRS", "", " BARCODESTOCK ", " and PIECETYPE ='PIECES' AND DATE < CAST(GETDATE() AS DATE) AND YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("TOTALMTRS")), Range("9"), XlHAlign.xlHAlignRight, , False, 10)


            'INHOUSE PACKING STOCK
            DT = OBJCMN.search(" ISNULL(SUM(ROUND(ISSUEPACKING_DESC.ISS_MTRS - ISNULL(ISSUEPACKING_DESC.ISS_OUTMTRS, 0), 2)), 0) AS TOTALMTRS", "", " ISSUEPACKING_DESC INNER JOIN ISSUEPACKING ON ISSUEPACKING.ISS_NO = ISSUEPACKING_DESC.ISS_NO AND ISSUEPACKING.ISS_YEARID = ISSUEPACKING_DESC.ISS_YEARID", " and ISSUEPACKING.ISS_DATE < CAST(GETDATE() AS DATE) AND ROUND(ISSUEPACKING_DESC.ISS_MTRS - ISNULL(ISSUEPACKING_DESC.ISS_OUTMTRS, 0), 2) > 0  AND ISSUEPACKING.ISS_YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("TOTALMTRS")), Range("10"), XlHAlign.xlHAlignRight, , False, 10)

            'READY FOR DISPATCH
            DT = OBJCMN.SEARCH(" SUM(T.MTRS) AS MTRS ", "", " (SELECT ISNULL(SUM(GDN.GDN_TOTALMTRS), 0) AS MTRS FROM GDN WHERE  ROUND(ISNULL(GDN.GDN_OUTPCS,0),0) = 0 AND GDN.GDN_DATE < CAST(GETDATE() AS DATE)AND GDN.GDN_YEARID = " & YEARID & " UNION ALL SELECT ISNULL(SUM(OPENINGGDN.OPENINGGDN_TOTALMTRS), 0) AS MTRS FROM OPENINGGDN WHERE  ROUND(ISNULL(OPENINGGDN.OPENINGGDN_OUTPCS,0),0) = 0 AND OPENINGGDN.OPENINGGDN_DATE < CAST(GETDATE() AS DATE) AND OPENINGGDN.OPENINGGDN_YEARID = " & YEARID & " ) AS T", "")
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("MTRS")), Range("11"), XlHAlign.xlHAlignRight, , False, 10)

            'TOTAL FINISH OPENING STOCK
            FORMULA("=SUM(" & objColumn.Item("8").ToString & RowIndex & ":" & objColumn.Item("11").ToString & RowIndex & ")", Range("12"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)





            'TODAYS RECEIPT STOCK
            RowIndex += 1
            Write("Today's Receipt", Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
            Write("Meters", Range("3"), XlHAlign.xlHAlignLeft, , False, 10)

            'GREY STOCK TRANSPORT
            DT = OBJCMN.SEARCH(" ISNULL(SUM(BALMTRS),0) AS GREYMTRS", "", " GREYSTOCKTRANSPORT ", " AND DATE = CAST(GETDATE() AS DATE) AND YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("GREYMTRS")), Range("4"), XlHAlign.xlHAlignRight, , False, 10)

            'GREY STOCK PROCESS
            DT = OBJCMN.SEARCH(" ISNULL(SUM(BALMTRS),0) AS GREYMTRS", "", " GREYSTOCKPROCESS ", " AND DATE = CAST(GETDATE() AS DATE) AND YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("GREYMTRS")), Range("5"), XlHAlign.xlHAlignRight, , False, 10)


            'PROCESS STOCK
            DT = OBJCMN.search(" ISNULL(SUM(BALMTRS),0) AS PROCESSMTRS", "", " LOT_VIEW ", " and LOT_VIEW.LOTCOMPLETED ='FALSE' AND DATE = CAST(GETDATE() AS DATE) AND YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("PROCESSMTRS")), Range("6"), XlHAlign.xlHAlignRight, , False, 10)


            'TOTAL WIP TODAYS STOCK
            FORMULA("=SUM(" & objColumn.Item("4").ToString & RowIndex & ":" & objColumn.Item("6").ToString & RowIndex & ")", Range("7"), XlHAlign.xlHAlignRight, , True, 10)


            'BARCODE STOCK ONLY FRESH PIECETYPE
            DT = OBJCMN.search(" ISNULL(SUM(MTRS),0) AS TOTALMTRS", "", " BARCODESTOCK ", " and PIECETYPE ='FRESH' AND DATE = CAST(GETDATE() AS DATE) AND YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("TOTALMTRS")), Range("8"), XlHAlign.xlHAlignRight, , False, 10)


            'BARCODE STOCK ONLY PIECES PIECETYPE
            DT = OBJCMN.search(" ISNULL(SUM(MTRS),0) AS TOTALMTRS", "", " BARCODESTOCK ", " and PIECETYPE ='PIECES' AND DATE = CAST(GETDATE() AS DATE) AND YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("TOTALMTRS")), Range("9"), XlHAlign.xlHAlignRight, , False, 10)


            'INHOUSE PACKING STOCK
            DT = OBJCMN.search(" ISNULL(SUM(ROUND(ISSUEPACKING_DESC.ISS_MTRS - ISNULL(ISSUEPACKING_DESC.ISS_OUTMTRS, 0), 2)), 0) AS TOTALMTRS", "", " ISSUEPACKING_DESC INNER JOIN ISSUEPACKING ON ISSUEPACKING.ISS_NO = ISSUEPACKING_DESC.ISS_NO AND ISSUEPACKING.ISS_YEARID = ISSUEPACKING_DESC.ISS_YEARID", " and ISSUEPACKING.ISS_DATE = CAST(GETDATE() AS DATE) AND ROUND(ISSUEPACKING_DESC.ISS_MTRS - ISNULL(ISSUEPACKING_DESC.ISS_OUTMTRS, 0), 2) > 0  AND ISSUEPACKING.ISS_YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("TOTALMTRS")), Range("10"), XlHAlign.xlHAlignRight, , False, 10)


            'READY FOR DISPATCH
            DT = OBJCMN.SEARCH(" SUM(T.MTRS) AS MTRS ", "", " (SELECT ISNULL(SUM(GDN.GDN_TOTALMTRS), 0) AS MTRS FROM GDN WHERE  ROUND(ISNULL(GDN.GDN_OUTPCS,0),0) = 0 AND GDN.GDN_DATE = CAST(GETDATE() AS DATE)AND GDN.GDN_YEARID = " & YEARID & " UNION ALL SELECT ISNULL(SUM(OPENINGGDN.OPENINGGDN_TOTALMTRS), 0) AS MTRS FROM OPENINGGDN WHERE  ROUND(ISNULL(OPENINGGDN.OPENINGGDN_OUTPCS,0),0) = 0 AND OPENINGGDN.OPENINGGDN_DATE = CAST(GETDATE() AS DATE) AND OPENINGGDN.OPENINGGDN_YEARID = " & YEARID & " ) AS T", "")
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("MTRS")), Range("11"), XlHAlign.xlHAlignRight, , False, 10)


            'TOTAL FINISH TODAYS STOCK
            FORMULA("=SUM(" & objColumn.Item("8").ToString & RowIndex & ":" & objColumn.Item("11").ToString & RowIndex & ")", Range("12"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)



            'CLOSING STOCK
            RowIndex += 1
            Write("Closing Stock", Range("2"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("Meters", Range("3"), XlHAlign.xlHAlignLeft, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("4").ToString & RowIndex - 2 & ":" & objColumn.Item("4").ToString & RowIndex - 1 & ")", Range("4"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("5").ToString & RowIndex - 2 & ":" & objColumn.Item("5").ToString & RowIndex - 1 & ")", Range("5"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("6").ToString & RowIndex - 2 & ":" & objColumn.Item("6").ToString & RowIndex - 1 & ")", Range("6"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("7").ToString & RowIndex - 2 & ":" & objColumn.Item("7").ToString & RowIndex - 1 & ")", Range("7"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("8").ToString & RowIndex - 2 & ":" & objColumn.Item("8").ToString & RowIndex - 1 & ")", Range("8"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("9").ToString & RowIndex - 2 & ":" & objColumn.Item("9").ToString & RowIndex - 1 & ")", Range("9"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("10").ToString & RowIndex - 2 & ":" & objColumn.Item("10").ToString & RowIndex - 1 & ")", Range("10"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("11").ToString & RowIndex - 2 & ":" & objColumn.Item("11").ToString & RowIndex - 1 & ")", Range("11"), XlHAlign.xlHAlignRight, , True, 10)
            FORMULA("=SUM(" & objColumn.Item("12").ToString & RowIndex - 2 & ":" & objColumn.Item("12").ToString & RowIndex - 1 & ")", Range("12"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)




            'SALE ORDER
            RowIndex += 2
            Write("5", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("PENDING SALE ORDER", Range("2"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("UNITS", Range("3"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("OPENING ORDERS", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("PO ISSUED", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("BALANCE ORDER", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)

            RowIndex += 1
            Write("Quantity", Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
            Write("Meters", Range("3"), XlHAlign.xlHAlignLeft, , False, 10)

            DT = OBJCMN.search(" ISNULL(SUM(ALLSALEORDER_DESC.SO_MTRS - ALLSALEORDER_DESC.SO_RECDMTRS),0) AS ORDERMTRS", "", " ALLSALEORDER INNER JOIN ALLSALEORDER_DESC ON ALLSALEORDER.SO_NO = ALLSALEORDER_DESC.SO_NO AND ALLSALEORDER.TYPE = ALLSALEORDER_DESC.TYPE AND ALLSALEORDER.SO_YEARID = ALLSALEORDER_DESC.SO_YEARID ", " AND ALLSALEORDER_DESC.SO_CLOSED = 0 AND (ALLSALEORDER_DESC.SO_MTRS - ALLSALEORDER_DESC.SO_RECDMTRS) > 0 and ALLSALEORDER.SO_DATE < CAST(GETDATE() AS DATE) AND ALLSALEORDER_DESC.SO_YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("ORDERMTRS")), Range("4"), XlHAlign.xlHAlignRight, , False, 10)

            DT = OBJCMN.search(" ISNULL(SUM(ALLSALEORDER_DESC.SO_MTRS - ALLSALEORDER_DESC.SO_RECDMTRS),0) AS ORDERMTRS", "", " ALLSALEORDER INNER JOIN ALLSALEORDER_DESC ON ALLSALEORDER.SO_NO = ALLSALEORDER_DESC.SO_NO AND ALLSALEORDER.TYPE = ALLSALEORDER_DESC.TYPE AND ALLSALEORDER.SO_YEARID = ALLSALEORDER_DESC.SO_YEARID ", " AND ALLSALEORDER_DESC.SO_CLOSED = 0 AND (ALLSALEORDER_DESC.SO_MTRS - ALLSALEORDER_DESC.SO_RECDMTRS) > 0 and ALLSALEORDER.SO_DATE = CAST(GETDATE() AS DATE) AND ALLSALEORDER_DESC.SO_YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("ORDERMTRS")), Range("5"), XlHAlign.xlHAlignRight, , False, 10)


            FORMULA("=SUM(" & objColumn.Item("4").ToString & RowIndex & ":" & objColumn.Item("5").ToString & RowIndex & ")", Range("6"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)





            'PURCHASE ORDER
            RowIndex += 2
            Write("6", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("PENDING PURCHASE ORDER", Range("2"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("UNITS", Range("3"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("OPENING ORDERS", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("RECEIVED", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("BALANCE ORDER", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)

            RowIndex += 1
            Write("Quantity", Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
            Write("Meters", Range("3"), XlHAlign.xlHAlignLeft, , False, 10)

            DT = OBJCMN.search(" ISNULL(SUM(ALLPURCHASEORDER_DESC.PO_MTRS - ALLPURCHASEORDER_DESC.PO_RECDMTRS),0) AS ORDERMTRS", "", " PURCHASEORDER INNER JOIN ALLPURCHASEORDER_DESC ON PURCHASEORDER.PO_NO = ALLPURCHASEORDER_DESC.PO_NO AND PURCHASEORDER.TYPE = ALLPURCHASEORDER_DESC.TYPE AND PURCHASEORDER.PO_YEARID = ALLPURCHASEORDER_DESC.PO_YEARID ", " AND ALLPURCHASEORDER_DESC.PO_CLOSED = 0 AND (ALLPURCHASEORDER_DESC.PO_MTRS - ALLPURCHASEORDER_DESC.PO_RECDMTRS) > 0 and PURCHASEORDER.PO_DATE < CAST(GETDATE() AS DATE) AND ALLPURCHASEORDER_DESC.PO_YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("ORDERMTRS")), Range("4"), XlHAlign.xlHAlignRight, , False, 10)

            DT = OBJCMN.search(" ISNULL(SUM(ALLPURCHASEORDER_DESC.PO_MTRS - ALLPURCHASEORDER_DESC.PO_RECDMTRS),0) AS ORDERMTRS", "", " PURCHASEORDER INNER JOIN ALLPURCHASEORDER_DESC ON PURCHASEORDER.PO_NO = ALLPURCHASEORDER_DESC.PO_NO AND PURCHASEORDER.TYPE = ALLPURCHASEORDER_DESC.TYPE AND PURCHASEORDER.PO_YEARID = ALLPURCHASEORDER_DESC.PO_YEARID ", " AND ALLPURCHASEORDER_DESC.PO_CLOSED = 0 AND (ALLPURCHASEORDER_DESC.PO_MTRS - ALLPURCHASEORDER_DESC.PO_RECDMTRS) > 0 and PURCHASEORDER.PO_DATE = CAST(GETDATE() AS DATE) AND ALLPURCHASEORDER_DESC.PO_YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("ORDERMTRS")), Range("5"), XlHAlign.xlHAlignRight, , False, 10)


            FORMULA("=SUM(" & objColumn.Item("4").ToString & RowIndex & ":" & objColumn.Item("5").ToString & RowIndex & ")", Range("6"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)




            'RECEIVABLE BALANCE
            RowIndex += 2
            Write("7", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("RECEIVABLE", Range("2"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("UNITS", Range("3"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("OPENING BALANCE", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("SALES / DEBITNOTE", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("PAYMENT RECEIVED", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("CREDIT NOTE", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("CLOSING BALANCE", Range("8"), XlHAlign.xlHAlignCenter, , True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)

            RowIndex += 1
            Write("Value", Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
            Write("Rupees", Range("3"), XlHAlign.xlHAlignLeft, , False, 10)

            DT = OBJCMN.search(" ISNULL(SUM(DR)-SUM(CR),0) AS BALAMT", "", " REGISTER ", " AND Secondary = 'Sundry Debtors' AND  REGISTER.ACC_BILLDATE < CAST(GETDATE() AS DATE) AND YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("BALAMT")), Range("4"), XlHAlign.xlHAlignRight, , False, 10)

            DT = OBJCMN.search(" ISNULL(SUM(DR),0) AS DEBITAMT", "", " REGISTER ", " AND acc_type <> 'RECEIPT' AND Secondary = 'Sundry Debtors' AND  REGISTER.ACC_BILLDATE = CAST(GETDATE() AS DATE) AND YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("DEBITAMT")), Range("5"), XlHAlign.xlHAlignRight, , False, 10)

            DT = OBJCMN.search(" ISNULL(SUM(CR),0) AS RECAMT", "", " REGISTER ", " AND acc_type = 'RECEIPT' AND Secondary = 'Sundry Debtors' AND  REGISTER.ACC_BILLDATE = CAST(GETDATE() AS DATE) AND YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("RECAMT")), Range("6"), XlHAlign.xlHAlignRight, , False, 10)

            DT = OBJCMN.search(" ISNULL(SUM(CR),0) AS CREDITAMT", "", " REGISTER ", " AND acc_type <> 'RECEIPT' AND Secondary = 'Sundry Debtors' AND  REGISTER.ACC_BILLDATE = CAST(GETDATE() AS DATE) AND YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("CREDITAMT")), Range("7"), XlHAlign.xlHAlignRight, , False, 10)

            FORMULA("=SUM(" & objColumn.Item("4").ToString & RowIndex & ":" & objColumn.Item("5").ToString & RowIndex & ")-SUM(" & objColumn.Item("6").ToString & RowIndex & ":" & objColumn.Item("7").ToString & RowIndex & ")", Range("8"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)





            'PAYABLE BALANCE
            RowIndex += 2
            Write("8", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("PAYABLE", Range("2"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("UNITS", Range("3"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("OPENING BALANCE", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("PURCHASE / CREDITNOTE", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("PAYMENT MADE", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("DEBIT NOTE", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("CLOSING BALANCE", Range("8"), XlHAlign.xlHAlignCenter, , True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)

            RowIndex += 1
            Write("Value", Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
            Write("Rupees", Range("3"), XlHAlign.xlHAlignLeft, , False, 10)

            DT = OBJCMN.search(" ISNULL(SUM(CR)-SUM(DR),0) AS BALAMT", "", " REGISTER ", " AND Secondary = 'Sundry Creditors' AND  REGISTER.ACC_BILLDATE < CAST(GETDATE() AS DATE) AND YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("BALAMT")), Range("4"), XlHAlign.xlHAlignRight, , False, 10)

            DT = OBJCMN.search(" ISNULL(SUM(CR),0) AS CREDITAMT", "", " REGISTER ", " AND acc_type <> 'PAYMENT' AND Secondary = 'Sundry Creditors' AND  REGISTER.ACC_BILLDATE = CAST(GETDATE() AS DATE) AND YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("CREDITAMT")), Range("5"), XlHAlign.xlHAlignRight, , False, 10)

            DT = OBJCMN.search(" ISNULL(SUM(DR),0) AS PAYAMT", "", " REGISTER ", " AND acc_type = 'PAYMENT' AND Secondary = 'Sundry Creditors' AND  REGISTER.ACC_BILLDATE = CAST(GETDATE() AS DATE) AND YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("PAYAMT")), Range("6"), XlHAlign.xlHAlignRight, , False, 10)

            DT = OBJCMN.search(" ISNULL(SUM(DR),0) AS DEBITAMT", "", " REGISTER ", " AND acc_type <> 'PAYMENT' AND Secondary = 'Sundry Creditors' AND  REGISTER.ACC_BILLDATE = CAST(GETDATE() AS DATE) AND YEARID = " & YEARID)
            If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("DEBITAMT")), Range("7"), XlHAlign.xlHAlignRight, , False, 10)

            FORMULA("=SUM(" & objColumn.Item("4").ToString & RowIndex & ":" & objColumn.Item("5").ToString & RowIndex & ")-SUM(" & objColumn.Item("6").ToString & RowIndex & ":" & objColumn.Item("7").ToString & RowIndex & ")", Range("8"), XlHAlign.xlHAlignRight, , True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)





            'BANK A/C
            RowIndex += 2
            Write("9", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("BANK", Range("2"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("UNITS", Range("3"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("OPENING BALANCE", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("RECEIPT", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("PAYMENT", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("CLOSING BALANCE", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)

            DT = OBJCMN.search(" ACC_CMPNAME AS BANKNAME", "", " LEDGERS INNER JOIN GROUPMASTER ON ACC_GROUPID = GROUP_ID", " AND (GROUP_Secondary = 'BANK A/C' OR GROUP_Secondary = 'BANK OD A/C') AND  ACC_YEARID = " & YEARID)
            For Each ROW As DataRow In DT.Rows
                RowIndex += 1
                Write(ROW("BANKNAME"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                Write("Rupees", Range("3"), XlHAlign.xlHAlignLeft, , False, 10)

                DT = OBJCMN.search(" ISNULL(SUM(DR)-SUM(CR),0) AS BALAMT", "", " REGISTER ", " AND NAME = '" & ROW("BANKNAME") & "' AND  REGISTER.ACC_BILLDATE < CAST(GETDATE() AS DATE) AND YEARID = " & YEARID)
                If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("BALAMT")), Range("4"), XlHAlign.xlHAlignRight, , False, 10)

                DT = OBJCMN.search(" ISNULL(SUM(DR),0) AS DEBITAMT", "", " REGISTER ", " AND NAME = '" & ROW("BANKNAME") & "' AND (acc_type = 'RECEIPT' OR acc_type = 'CONTRA' OR acc_type = 'PAYMENT') AND  REGISTER.ACC_BILLDATE = CAST(GETDATE() AS DATE) AND YEARID = " & YEARID)
                If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("DEBITAMT")), Range("5"), XlHAlign.xlHAlignRight, , False, 10)

                DT = OBJCMN.search(" ISNULL(SUM(CR),0) AS CREDITAMT", "", " REGISTER ", "  AND NAME = '" & ROW("BANKNAME") & "' AND (acc_type = 'PAYMENT' OR acc_type = 'CONTRA' OR acc_type = 'RECEIPT') AND  REGISTER.ACC_BILLDATE = CAST(GETDATE() AS DATE) AND YEARID = " & YEARID)
                If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("CREDITAMT")), Range("6"), XlHAlign.xlHAlignRight, , False, 10)

                FORMULA("=SUM(" & objColumn.Item("4").ToString & RowIndex & ":" & objColumn.Item("5").ToString & RowIndex & ")-" & objColumn.Item("6").ToString & RowIndex, Range("7"), XlHAlign.xlHAlignRight, , True, 10)
                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)
            Next





            'CASH IN HAND
            RowIndex += 2
            Write("10", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("CASH LEDGER", Range("2"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("UNITS", Range("3"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("OPENING BALANCE", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("RECEIPT", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("PAYMENT", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("CLOSING BALANCE", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)

            DT = OBJCMN.search(" ACC_CMPNAME AS CASHNAME", "", " LEDGERS INNER JOIN GROUPMASTER ON ACC_GROUPID = GROUP_ID", " AND GROUP_Secondary = 'Cash In Hand' AND  ACC_YEARID = " & YEARID)
            For Each ROW As DataRow In DT.Rows
                RowIndex += 1
                Write(ROW("CASHNAME"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                Write("Rupees", Range("3"), XlHAlign.xlHAlignLeft, , False, 10)

                DT = OBJCMN.search(" ISNULL(SUM(DR)-SUM(CR),0) AS BALAMT", "", " REGISTER ", " AND NAME = '" & ROW("CASHNAME") & "' AND  REGISTER.ACC_BILLDATE < CAST(GETDATE() AS DATE) AND YEARID = " & YEARID)
                If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("BALAMT")), Range("4"), XlHAlign.xlHAlignRight, , False, 10)

                DT = OBJCMN.search(" ISNULL(SUM(DR),0) AS DEBITAMT", "", " REGISTER ", " AND NAME = '" & ROW("CASHNAME") & "' AND (acc_type = 'RECEIPT' OR acc_type = 'CONTRA' OR acc_type = 'PAYMENT') AND  REGISTER.ACC_BILLDATE = CAST(GETDATE() AS DATE) AND YEARID = " & YEARID)
                If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("DEBITAMT")), Range("5"), XlHAlign.xlHAlignRight, , False, 10)

                DT = OBJCMN.search(" ISNULL(SUM(CR),0) AS CREDITAMT", "", " REGISTER ", " AND NAME = '" & ROW("CASHNAME") & "' AND (acc_type = 'PAYMENT' OR acc_type = 'CONTRA' OR acc_type = 'RECEIPT') AND  REGISTER.ACC_BILLDATE = CAST(GETDATE() AS DATE) AND YEARID = " & YEARID)
                If DT.Rows.Count > 0 Then Write(Val(DT.Rows(0).Item("CREDITAMT")), Range("6"), XlHAlign.xlHAlignRight, , False, 10)

                FORMULA("=SUM(" & objColumn.Item("4").ToString & RowIndex & ":" & objColumn.Item("5").ToString & RowIndex & ")-" & objColumn.Item("6").ToString & RowIndex, Range("7"), XlHAlign.xlHAlignRight, , True, 10)
                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)
            Next




            'DYEING RECEIPT SUMMARY
            RowIndex += 2
            Write("11", Range("1"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("JOBBER NAME", Range("2"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("UNITS", Range("3"), XlHAlign.xlHAlignLeft, , True, 10)
            Write("RECEIPT FROM JOBBER", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("ISSUE TO JOBBER", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("10").ToString & RowIndex)

            DT = OBJCMN.SEARCH(" T.JOBBERNAME, SUM(T.ISSUEMTRS) AS ISSUEMTRS, SUM(T.RECMTRS) AS RECMTRS ", "", "(SELECT LEDGERS.ACC_CMPNAME AS JOBBERNAME, SUM(GRN.GRN_TOTALMTRS) AS ISSUEMTRS, 0 AS RECMTRS FROM GRN INNER JOIN LEDGERS ON GRN.GRN_TOLEDGERID = LEDGERS.ACC_ID WHERE GRN.GRN_YEARID = " & YEARID & " AND GRN.GRN_DATE = CAST(GETDATE() AS DATE) GROUP BY LEDGERS.ACC_CMPNAME UNION ALL SELECT LEDGERS.ACC_CMPNAME AS JOBBERNAME, SUM(JOBOUT.JO_TOTALMTRS) AS ISSUEMTRS, 0 AS RECMTRS FROM JOBOUT INNER JOIN LEDGERS ON JOBOUT.JO_LEDGERID = LEDGERS.ACC_ID WHERE JOBOUT.JO_YEARID = " & YEARID & " AND JOBOUT.JO_DATE = CAST(GETDATE() AS DATE) GROUP BY LEDGERS.ACC_CMPNAME UNION ALL SELECT LEDGERS.ACC_CMPNAME AS JOBBERNAME, 0 AS ISSUEMTRS, SUM(MATERIALRECEIPT.MATREC_TOTALRECDMTR) AS RECMTRS FROM MATERIALRECEIPT INNER JOIN LEDGERS ON MATERIALRECEIPT.MATREC_LEDGERID = LEDGERS.ACC_ID WHERE MATERIALRECEIPT.MATREC_YEARID = " & YEARID & " AND MATERIALRECEIPT.MATREC_DATE = CAST(GETDATE() AS DATE)  GROUP BY LEDGERS.ACC_CMPNAME UNION ALL SELECT LEDGERS.ACC_CMPNAME AS JOBBERNAME, 0 AS ISSUEMTRS, SUM(JOBIN.JI_TOTALMTRS) AS RECMTRS FROM JOBIN INNER JOIN LEDGERS ON JOBIN.JI_LEDGERID = LEDGERS.ACC_ID WHERE JOBIN.JI_YEARID = " & YEARID & " AND JOBIN.JI_DATE = CAST(GETDATE() AS DATE) GROUP BY LEDGERS.ACC_CMPNAME) AS T", " GROUP BY T.JOBBERNAME ")
            For Each ROW As DataRow In DT.Rows
                RowIndex += 1
                Write(ROW("JOBBERNAME"), Range("2"), XlHAlign.xlHAlignLeft, , False, 10)
                Write("Meters", Range("3"), XlHAlign.xlHAlignLeft, , False, 10)
                Write(Val(DT.Rows(0).Item("RECMTRS")), Range("4"), XlHAlign.xlHAlignRight, , False, 10)
                Write(Val(DT.Rows(0).Item("ISSUEMTRS")), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("12").ToString & RowIndex)
            Next




            SetBorder(RowIndex, objColumn.Item("1").ToString & 8, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 8, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 8, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 8, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 8, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 8, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 8, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & 8, objColumn.Item("8").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("9").ToString & 8, objColumn.Item("9").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("10").ToString & 8, objColumn.Item("10").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("11").ToString & 8, objColumn.Item("11").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("12").ToString & 8, objColumn.Item("12").ToString & RowIndex)


            objBook.Application.ActiveWindow.Zoom = 100

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlPortrait
            '    .TopMargin = 20
            '    .LeftMargin = 10
            '    .RightMargin = 5
            '    .BottomMargin = 10
            '    .Zoom = False
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

    Public Function DAILYDISPATCH_EXCEL(ByVal CMPID As Integer, ByVal YEARID As Integer, ByVal FROMDATE As Date, ByVal TODATE As Date) As Object
        Try

            SetWorkSheet()
            For I As Integer = 1 To 26
                SetColumn(I, Chr(64 + I))
            Next


            RowIndex = 1
            For i As Integer = 1 To 26
                SetColumnWidth(Range(i), 15)
            Next



            '''''''''''Report Title
            Dim OBJCMN As New ClsCommon
            Dim DT As New System.Data.DataTable
            Dim DTNP As New System.Data.DataTable
            'CMPNAME
            Dim DTCMP As System.Data.DataTable = OBJCMN.search(" CMP_NAME AS CMPNAME, CMP_ADD1 As ADD1, CMP_ADD2 AS ADD2", "", " CMPMASTER", " AND CMP_ID = " & CMPID)

            RowIndex = 2
            Write(DTCMP.Rows(0).Item("CMPNAME"), Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 14)
            SetBorder(RowIndex, Range("1"), Range("8"))

            'ADD1
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD1"), Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("8"))

            'ADD2
            RowIndex += 1
            Write(DTCMP.Rows(0).Item("ADD2"), Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 10)
            SetBorder(RowIndex, Range("1"), Range("8"))

            RowIndex += 1
            Write("DAILY DISPATCH REPORT (" & Format(FROMDATE, "dd/MM/yyyy") & "-" & Format(TODATE, "dd/MM/yyyy") & ")", Range("1"), XlHAlign.xlHAlignCenter, Range("8"), True, 12)
            SetBorder(RowIndex, Range("1"), Range("8"))


            'FREEZE TOP 6 ROWS
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("8").ToString & 8).Select()
            objSheet.Range(objColumn.Item("1").ToString & 8, objColumn.Item("8").ToString & 8).Application.ActiveWindow.FreezePanes = True


            SetBorder(RowIndex + 1, objColumn.Item("1").ToString & RowIndex + 1, objColumn.Item("8").ToString & RowIndex + 1)

            RowIndex += 2
            Write("DATE", Range("1"), XlHAlign.xlHAlignCenter, Range("1"), True, 10)
            Write("SALES (MTRS)", Range("2"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("SALES (MTRS TOTAL)", Range("3"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("DISPATCH (MTRS)", Range("4"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("DISPATCH (MTRS TOTAL)", Range("5"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("GR (MTRS)", Range("6"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("GR (MTRS TOTAL)", Range("7"), XlHAlign.xlHAlignCenter, , True, 10)
            Write("TOTAL MTRS", Range("8"), XlHAlign.xlHAlignCenter, , True, 10)

            SetBorder(RowIndex, objColumn.Item("1").ToString & RowIndex, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & RowIndex, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & RowIndex, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & RowIndex, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & RowIndex, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & RowIndex, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & RowIndex, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & RowIndex, objColumn.Item("8").ToString & RowIndex)



            'LOOP DAY WISE FOR CURRENT MONTH
            For I As Integer = 1 To Now.Day

                RowIndex += 1
                Write(" " & I & "/" & Now.Month & "/" & Now.Year, Range("1"), XlHAlign.xlHAlignLeft, , False, 10)

                'GET SALEMTRS
                DT = OBJCMN.search(" ISNULL(SUM(INVOICE_TOTALMTRS),0) AS INVMTRS", "", " INVOICEMASTER ", " AND DAY(invoice_DATE) = " & I & " AND MONTH(invoice_DATE) = " & Now.Month & " And INVOICE_YEARID = " & YEARID)
                If DT.Rows.Count > 0 Then
                    Write(Val(DT.Rows(0).Item("INVMTRS")), Range("2"), XlHAlign.xlHAlignRight, , False, 10)
                    If I = 1 Then Write(Val(DT.Rows(0).Item("INVMTRS")), Range("3"), XlHAlign.xlHAlignRight, , False, 10)
                End If

                'GET DISPATCHMTRS
                DT = OBJCMN.search(" ISNULL(SUM(GDN_TOTALMTRS),0) AS GDNMTRS", "", " GDN ", " AND DAY(GDN_DATE) = " & I & " AND MONTH(GDN_DATE) = " & Now.Month & " And GDN_YEARID = " & YEARID)
                If DT.Rows.Count > 0 Then
                    Write(Val(DT.Rows(0).Item("GDNMTRS")), Range("4"), XlHAlign.xlHAlignRight, , False, 10)
                    If I = 1 Then Write(Val(DT.Rows(0).Item("GDNMTRS")), Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                End If


                'GET GRMTRS
                DT = OBJCMN.search(" ISNULL(SUM(SALRET_TOTALMTRS),0) AS GRMTRS", "", " SALERETURN ", " AND DAY(SALRET_DATE) = " & I & " AND MONTH(SALRET_DATE) = " & Now.Month & " And SALRET_YEARID = " & YEARID)
                If DT.Rows.Count > 0 Then
                    Write(Val(DT.Rows(0).Item("GRMTRS")), Range("6"), XlHAlign.xlHAlignRight, , False, 10)
                    If I = 1 Then Write(Val(DT.Rows(0).Item("GRMTRS")), Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                End If


                'IF 1ST DAY THEN DONT ADD FORMULA
                If I > 1 Then
                    FORMULA("=(" & objColumn.Item("3").ToString & RowIndex - 1 & "+" & objColumn.Item("2").ToString & RowIndex & ")", Range("3"), XlHAlign.xlHAlignRight, , False, 10)
                    FORMULA("=(" & objColumn.Item("5").ToString & RowIndex - 1 & "+" & objColumn.Item("4").ToString & RowIndex & ")", Range("5"), XlHAlign.xlHAlignRight, , False, 10)
                    FORMULA("=(" & objColumn.Item("7").ToString & RowIndex - 1 & "+" & objColumn.Item("6").ToString & RowIndex & ")", Range("7"), XlHAlign.xlHAlignRight, , False, 10)
                End If

                FORMULA("=(" & objColumn.Item("4").ToString & RowIndex & "-" & objColumn.Item("6").ToString & RowIndex & ")", Range("8"), XlHAlign.xlHAlignRight, , False, 10)

            Next

            SetBorder(RowIndex, objColumn.Item("1").ToString & 8, objColumn.Item("1").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("2").ToString & 8, objColumn.Item("2").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("3").ToString & 8, objColumn.Item("3").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("4").ToString & 8, objColumn.Item("4").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("5").ToString & 8, objColumn.Item("5").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("6").ToString & 8, objColumn.Item("6").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("7").ToString & 8, objColumn.Item("7").ToString & RowIndex)
            SetBorder(RowIndex, objColumn.Item("8").ToString & 8, objColumn.Item("8").ToString & RowIndex)


            objBook.Application.ActiveWindow.Zoom = 100

            'With objSheet.PageSetup
            '    .Orientation = XlPageOrientation.xlPortrait
            '    .TopMargin = 20
            '    .LeftMargin = 10
            '    .RightMargin = 5
            '    .BottomMargin = 10
            '    .Zoom = False
            'End With

            SaveAndClose()

        Catch ex As Exception
            Throw ex
        End Try
        Return Nothing
    End Function

#End Region

End Class
