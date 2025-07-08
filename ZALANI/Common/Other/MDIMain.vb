
Imports BL
Imports WAProAPI

Public Class MDIMain

    Private Sub MDIMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.Text = CmpName & " (" & AccFrom & " - " & AccTo & ")                     User - " & UserName
            GETCONN()


            'GET COMPANY'S DATA FOR VALIDATIONS OF EWB AND GST
            Dim OBJCMN As New ClsCommon
            Dim DT As DataTable = OBJCMN.SEARCH("ISNULL(CMP_EWBUSER,'') AS EWBUSER, ISNULL(CMP_EWBPASS,'') AS EWBPASS, ISNULL(CMP_GSTIN,'') AS CMPGSTIN, ISNULL(CMP_ZIPCODE,'') AS CMPPINCODE, ISNULL(CITY_NAME,'') AS CITYNAME, CAST(STATE_NAME AS VARCHAR(50)) AS STATENAME, CAST(STATE_REMARK AS VARCHAR(50)) AS STATECODE, ISNULL(NOOFEWAYBILLS,0) AS EWAYCOUNTER, ISNULL(CMPMASTER.CMP_BANKNAME,'') AS BANKNAME, ISNULL(CMPMASTER.CMP_BANKACNO,'') AS ACCOUNTNO, ISNULL(CMPMASTER.CMP_IFSCCODE,'') AS IFSC, ISNULL(CMPMASTER.CMP_UPI,'') AS UPI, ISNULL(CMP_ADD1,'') AS CMPADDRESS, ISNULL(CMP_TEL,'') AS CMPTEL", "", " STATEMASTER INNER JOIN CMPMASTER ON STATE_ID = CMP_STATEID LEFT OUTER JOIN CITYMASTER ON CMP_FROMCITYID = CITY_ID LEFT OUTER JOIN EWAYCOUNTER ON CMP_ID = EWAYCOUNTER.CMPID ", " AND CMP_ID = " & CmpId)
            If DT.Rows.Count > 0 Then
                CMPEWBUSER = DT.Rows(0).Item("EWBUSER")
                CMPEWBPASS = DT.Rows(0).Item("EWBPASS")
                CMPGSTIN = DT.Rows(0).Item("CMPGSTIN")
                CMPPINCODE = DT.Rows(0).Item("CMPPINCODE")
                CMPCITYNAME = DT.Rows(0).Item("CITYNAME")
                CMPSTATENAME = DT.Rows(0).Item("STATENAME")
                CMPSTATECODE = DT.Rows(0).Item("STATECODE")
                CMPBANK = DT.Rows(0).Item("BANKNAME")
                CMPACCNO = DT.Rows(0).Item("ACCOUNTNO")
                CMPIFSC = DT.Rows(0).Item("IFSC")
                CMPUPI = DT.Rows(0).Item("UPI")
                CMPADDRESS = DT.Rows(0).Item("CMPADDRESS")
                CMPTEL = DT.Rows(0).Item("CMPTEL")

                DT = OBJCMN.SEARCH("ISNULL(SUM(NOOFEWAYBILLS),0) AS EWAYCOUNTER", "", " EWAYCOUNTER ", " AND CMPID = " & CmpId)
                CMPEWAYCOUNTER = Val(DT.Rows(0).Item("EWAYCOUNTER"))
                DT = OBJCMN.SEARCH("ISNULL(MAX(DATE), GETDATE()) AS EWAYEXPDATE", "", " EWAYCOUNTER ", " AND CMPID = " & CmpId)
                EWAYEXPDATE = Convert.ToDateTime(DT.Rows(0).Item("EWAYEXPDATE")).Date.AddYears(1)

                DT = OBJCMN.SEARCH("ISNULL(SUM(NOOFEINVOICE),0) AS EINVOICECOUNTER", "", " EINVOICECOUNTER ", " AND CMPID = " & CmpId)
                CMPEINVOICECOUNTER = Val(DT.Rows(0).Item("EINVOICECOUNTER"))
                DT = OBJCMN.SEARCH("ISNULL(MAX(DATE), GETDATE()) AS EINVOICEEXPDATE", "", " EINVOICECOUNTER ", " AND CMPID = " & CmpId)
                EINVOICEEXPDATE = Convert.ToDateTime(DT.Rows(0).Item("EINVOICEEXPDATE")).Date.AddYears(1)
            End If


            'GET USERGODOWN
            DT = OBJCMN.SEARCH("ISNULL(GODOWN_NAME,'') AS USERGODOWN", "", " USERGODOWNTAGGING INNER JOIN USERMASTER ON USERGODOWNTAGGING.GODOWN_USERID = USERMASTER.[User_id]	 INNER JOIN GODOWNMASTER ON USERGODOWNTAGGING.GODOWN_GODOWNID = GODOWNMASTER.GODOWN_id  ", " AND USER_NAME ='" & UserName & "' AND  USERGODOWNTAGGING.GODOWN_CMPID = " & CmpId)
            If DT.Rows.Count > 0 Then USERGODOWN = DT.Rows(0).Item("USERGODOWN")



            'BLOCKTRANSFER VARIABLES
            BLOCKMASTERTRANSFER = False
            BLOCKOTHERTRANSFER = False
            BLOCKACCDATATRANSFER = False
            BLOCKSTOCKSTRANSFER = False


            DT = OBJCMN.SEARCH("ISNULL(BLOCK_LEDGER,0) AS BLOCKMASTER, ISNULL(BLOCK_OTHER,0) AS BLOCKOTHERMASTER, ISNULL(BLOCK_DATA,0) AS BLOCKACCDATA, ISNULL(BLOCK_STOCK,0) AS BLOCKSTOCK", "", " BLOCKDATA ", " AND BLOCK_YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                BLOCKMASTERTRANSFER = Convert.ToBoolean(DT.Rows(0).Item("BLOCKMASTER"))
                BLOCKOTHERTRANSFER = Convert.ToBoolean(DT.Rows(0).Item("BLOCKOTHERMASTER"))
                BLOCKACCDATATRANSFER = Convert.ToBoolean(DT.Rows(0).Item("BLOCKACCDATA"))
                BLOCKSTOCKSTRANSFER = Convert.ToBoolean(DT.Rows(0).Item("BLOCKSTOCK"))
            End If



            Dim DT1 As DataTable = OBJCMN.SEARCH("HOME , PO , GRN , MATREC , INHOUSECHECK, CHALLAN , JOBOUT , JOBIN , ISSUEPACKING , RECPACKING, PURINVOICE , SALEINVOICE , SHOWDASHBOARD, RECOUTSTANDING , PAYOUTSTANDING , PENDINGPO , PENDINGSO, STOCKDETAILS , SALEPURMONTHLY,SALEORDER,GRNCHECKING, ISNULL(CHALLANSO,0) AS CHALLANSO, ISNULL(BILLCHECKDISPUTE,0) AS BILLCHECKDISPUTE, ISNULL(LOCKPENDING,0) AS LOCKPENDING, ISNULL(CHANGEBARCODE,0) AS CHANGEBARCODE, ISNULL(STOCKADJUSTMENT,0) AS STOCKADJUSTMENT, ISNULL(ADJMTRSDIFF,0) AS ADJMTRSDIFF, ISNULL(ALLOWINVAFTEREINV,0) AS ALLOWINVAFTEREINV, ISNULL(ALLOWPOSOCLOSE,0) AS ALLOWPOSOCLOSE, ISNULL(ALLOWMERGEPARAMETER,0) AS ALLOWMERGEPARAMETER ,ISNULL(ALLOWLRRECD,0) AS ALLOWLRRECD ,ISNULL(ALLOWWAFORUSER,0) AS ALLOWWAFORUSER ", "", "SPECIALRIGHTS inner join usermaster on userid = user_id", " AND USER_name= '" & UserName & "'")
            If DT1.Rows.Count > 0 Then
                HOME = DT1.Rows(0).Item(0)
                POTOOLVISIBLE = DT1.Rows(0).Item(1)
                GRNTOOLVISIBLE = DT1.Rows(0).Item(2)
                MATRECTOOLVISIBLE = DT1.Rows(0).Item(3)
                INHOUSECHKTOOLVISIBLE = DT1.Rows(0).Item(4)
                GDNTOOLVISIBLE = DT1.Rows(0).Item(5)
                JOTOOLVISIBLE = DT1.Rows(0).Item(6)
                JITOOLVISIBLE = DT1.Rows(0).Item(7)
                ISSPACKTOOLVISIBLE = DT1.Rows(0).Item(8)
                RECPACKTOOLVISIBLE = DT1.Rows(0).Item(9)
                PURCHASETOOLVISIBLE = DT1.Rows(0).Item(10)
                SALETOOLVISIBLE = DT1.Rows(0).Item(11)
                DASHBOARDTOOLVISIBLE = DT1.Rows(0).Item(12)
                RECOUTSTANDTOOLVISIBLE = DT1.Rows(0).Item(13)
                PAYOUTSTANDTOOLVISIBLE = DT1.Rows(0).Item(14)
                PENDINGPOTOOLVISIBLE = DT1.Rows(0).Item(15)
                PENDINGSOTOOLVISIBLE = DT1.Rows(0).Item(16)
                STOCKTOOLVISIBLE = DT1.Rows(0).Item(17)
                MONTHLYTOOLVISIBLE = DT1.Rows(0).Item(18)
                SOTOOLVISIBLE = DT1.Rows(0).Item(19)
                GRNCHECKTOOLVISIBLE = DT1.Rows(0).Item(20)
                CHALLANWITHOUTSO = DT1.Rows(0).Item(21)
                ALLOWBILLCHECKDISPUTE = DT1.Rows(0).Item(22)
                ALLOWLOCKPENDING = DT1.Rows(0).Item(23)
                ALLOWCHANGEBARCODE = DT1.Rows(0).Item(24)
                ALLOWSTOCKADJUSTMENT = DT1.Rows(0).Item("STOCKADJUSTMENT")
                ALLOWADJMTRSDIFF = DT1.Rows(0).Item("ADJMTRSDIFF")
                ALLOWINVAFTEREINV = DT1.Rows(0).Item("ALLOWINVAFTEREINV")
                ALLOWPOSOCLOSE = DT1.Rows(0).Item("ALLOWPOSOCLOSE")
                ALLOWMERGEPARAMETER = DT1.Rows(0).Item("ALLOWMERGEPARAMETER")
                ALLOWLRRECD = DT1.Rows(0).Item("ALLOWLRRECD")
                ALLOWWAFORUSER = DT1.Rows(0).Item("ALLOWWAFORUSER")
            End If


            'CHECKING BLOCKDATE FOR BACK DATED ENTRIES
            DT = OBJCMN.SEARCH("*", "", "BLOCKDATE", " AND YEARID = " & YearId)
            If DT.Rows.Count > 0 Then
                SALEBLOCKDATE = DT.Rows(0).Item("SALEDATE")
                PURBLOCKDATE = DT.Rows(0).Item("PURDATE")
                CNBLOCKDATE = DT.Rows(0).Item("CNDATE")
                DNBLOCKDATE = DT.Rows(0).Item("DNDATE")
                EXPBLOCKDATE = DT.Rows(0).Item("EXPDATE")
                GREYRTBLOCKDATE = DT.Rows(0).Item("GREYRECTRANSDATE")
                GREYRPBLOCKDATE = DT.Rows(0).Item("GREYRECPROCESSDATE")
                GRNBLOCKDATE = DT.Rows(0).Item("GRNDATE")
                DYEINGRECBLOCKDATE = DT.Rows(0).Item("DYEINGRECDATE")
                ISSUEPACKBLOCKDATE = DT.Rows(0).Item("ISSUEPAC")
                RECPACKBLOCKDATE = DT.Rows(0).Item("RECPACKDATE")
                JOBLOCKDATE = DT.Rows(0).Item("JODATE")
                JIBLOCKDATE = DT.Rows(0).Item("JIDATE")
                STOCKADJBLOCKDATE = DT.Rows(0).Item("STOCKADJDATE")
                SALERETCHBLOCKDATE = DT.Rows(0).Item("SRCHALLANDATE")
                PURRETCHBLOCKDATE = DT.Rows(0).Item("PRCHALLANDATE")
                POBLOCKDATE = DT.Rows(0).Item("PODATE")
                SOBLOCKDATE = DT.Rows(0).Item("SODATE")
                STOREPOBLOCKDATE = DT.Rows(0).Item("STOREPODATE")
            Else
                SALEBLOCKDATE = AccFrom.Date
                PURBLOCKDATE = AccFrom.Date
                CNBLOCKDATE = AccFrom.Date
                CNBLOCKDATE = AccFrom.Date
                EXPBLOCKDATE = AccFrom.Date
                GREYRTBLOCKDATE = AccFrom.Date
                GREYRPBLOCKDATE = AccFrom.Date
                GRNBLOCKDATE = AccFrom.Date
                DYEINGRECBLOCKDATE = AccFrom.Date
                ISSUEPACKBLOCKDATE = AccFrom.Date
                RECPACKBLOCKDATE = AccFrom.Date
                JOBLOCKDATE = AccFrom.Date
                JIBLOCKDATE = AccFrom.Date
                STOCKADJBLOCKDATE = AccFrom.Date
                SALERETCHBLOCKDATE = AccFrom.Date
                PURRETCHBLOCKDATE = AccFrom.Date
                POBLOCKDATE = AccFrom.Date
                SOBLOCKDATE = AccFrom.Date
                STOREPOBLOCKDATE = AccFrom.Date

            End If


            SETENABILITY()
            HEADERVISIBLE()

            If ALLOWWHATSAPP = True Then
                Dim BASEURL As String = GETWHATSAPPBASEURL()
                If BASEURL <> "" Then
                    APIMethods.BaseURL = BASEURL
                Else
                    MsgBox("Whastapp Base URL Is Missing", MsgBoxStyle.Critical)
                End If
            End If

            If ClientName = "SST" Then
                GRN_MASTER.Visible = False
            End If

            If DISCONTINUECLIENT = True Then
                CMPADD.Enabled = False
                CMPEDIT.Enabled = False
                YEARADD.Enabled = False
            End If



            If HIDEPAYROLL = True Then
                EMPLOYEE_MASTER.Enabled = False
                SALARYSLIP_MASTER.Enabled = False
                SALARYSLIPADD.Enabled = False
                SALARYSLIPEDIT.Enabled = False
                SALARYREPORT_MASTER.Enabled = False
            End If


            If ALLOWPOSOCLOSE = False Then
                POCLOSE.Enabled = False
                SOCLOSE.Enabled = False
            End If

            'If FETCHITEMWISEDESIGN = True Then MILL_MASTER.Visible = True

            If ALLOWMERGEPARAMETER = True Then MERGEDETAILS_MASTER.Enabled = True
        Catch ex As Exception
            Throw ex

        End Try
    End Sub

    Sub SETENABILITY()
        Try
            If UserName = "Admin" Then
                CMP_MASTER.Enabled = True
                YEAR_MASTER.Enabled = True
                ADMIN_MASTER.Enabled = True
                MERGELEDGER.Enabled = True
                DATATRANSFER_MASTER.Enabled = True
                STOCKTRANSFER_MASTER.Enabled = True
                RECODATA_MASTER.Enabled = True
                BLOCKDETAILS_MASTER.Enabled = True
                USERTRANSFER.Enabled = True
                SPECIALRIGHTS_MASTER.Enabled = True
                BLOCKDATEMENU.Enabled = True
                USERGODOWN_MASTER.Enabled = True
                LOCKACCYEAR_MASTER.Enabled = True
                LOGS_MASTER.Enabled = True
                RENUMBERING_MASTER.Enabled = True

            Else
                'ONLY TO CHANGE PASSWORD
                ADMIN_MASTER.Enabled = True
                USERADD.Enabled = False
                USEREDIT.Enabled = True
            End If

            If ALLOWLOCKPENDING = True Or UserName = "Admin" Then
                'LOCKPENDINGENTRIES_MENU.Enabled = True
                UPDATEPENDINGENTRIES_MENU.Enabled = True
            End If

            If ALLOWSTOCKADJUSTMENT = True Then
                STOCKADJUSTMENT_MASTER.Enabled = True
            End If

            For Each DTROW As DataRow In USERRIGHTS.Rows

                'MASTERS
                If DTROW(0).ToString = "GROUP MASTER" Then
                    If DTROW(1).ToString = True Then
                        GROUP_MASTER.Enabled = True
                        GROUPADD.Enabled = True
                    Else
                        GROUPADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        GROUP_MASTER.Enabled = True
                        GROUPEDIT.Enabled = True
                    Else
                        GROUPEDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "ACCOUNTS MASTER" Then
                    If DTROW(1).ToString = True Then
                        ACC_MASTER.Enabled = True
                        ACCADD.Enabled = True
                        NARRATION_MASTER.Enabled = True
                        PARTYBANK_MASTER.Enabled = True
                        NARRATIONADD.Enabled = True
                        PARTYBANKADD.Enabled = True
                        CURRENCY_MASTER.Enabled = True
                        CURRENCYADD.Enabled = True
                    Else
                        ACCADD.Enabled = False
                        NARRATIONADD.Enabled = False
                        PARTYBANKADD.Enabled = False
                        CURRENCYADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        ACC_MASTER.Enabled = True
                        ACCEDIT.Enabled = True
                        NARRATION_MASTER.Enabled = True
                        PARTYBANK_MASTER.Enabled = True
                        NARRATIONEDIT.Enabled = True
                        PARTYBANKEDIT.Enabled = True
                        CURRENCY_MASTER.Enabled = True
                        CURRENCYEDIT.Enabled = True
                    Else
                        ACCEDIT.Enabled = False
                        NARRATIONEDIT.Enabled = False
                        PARTYBANKEDIT.Enabled = False
                        CURRENCYEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "EMPLOYEE MASTER" Then
                    If DTROW(1).ToString = True Then
                        EMPLOYEE_MASTER.Enabled = True
                        EMPLOYEEADD.Enabled = True
                    Else
                        EMPLOYEEADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        EMPLOYEE_MASTER.Enabled = True
                        EMPLOYEEEDIT.Enabled = True
                    Else
                        EMPLOYEEEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "HSNMASTER" Then
                    If DTROW(1).ToString = True Then
                        HSN_MASTER.Enabled = True
                        HSNADD.Enabled = True
                    Else
                        HSNADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        HSN_MASTER.Enabled = True
                        HSNEDIT.Enabled = True
                    Else
                        HSNEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "REGISTER MASTER" Then
                    If (DTROW(1) = True) Or (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        REG_MASTER.Enabled = True
                    End If


                ElseIf DTROW(0).ToString = "ITEM MASTER" Then
                    If DTROW(1).ToString = True Then
                        CATEGORY_MASTER.Enabled = True
                        ITEM_MASTER.Enabled = True
                        MACHINE_MASTER.Enabled = True
                        REORDERLEVEL_MASTER.Enabled = True

                        CATEGORYADD.Enabled = True
                        ITEMADD.Enabled = True
                        MACHINEADD.Enabled = True
                    Else
                        CATEGORYADD.Enabled = False
                        ITEMADD.Enabled = False
                        MACHINEADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        CATEGORY_MASTER.Enabled = True
                        ITEM_MASTER.Enabled = True
                        MACHINE_MASTER.Enabled = True
                        REORDERLEVEL_MASTER.Enabled = True

                        CATEGORYEDIT.Enabled = True
                        ITEMEDIT.Enabled = True
                        MACHINEEDIT.Enabled = True
                    Else
                        CATEGORYEDIT.Enabled = False
                        ITEMEDIT.Enabled = False
                        NARRATIONEDIT.Enabled = False
                        PARTYBANKEDIT.Enabled = False
                        MACHINEEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "DEPARTMENT MASTER" Then
                    If DTROW(1).ToString = True Then
                        DEPARTMENT_MASTER.Enabled = True
                        DEPARTMENTADD.Enabled = True
                    Else
                        DEPARTMENTADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        DEPARTMENT_MASTER.Enabled = True
                        DEPARTMENTEDIT.Enabled = True
                    Else
                        DEPARTMENTEDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "UNIT MASTER" Then
                    If DTROW(1).ToString = True Then
                        UNIT_MASTER.Enabled = True
                        UNITADD.Enabled = True
                    Else
                        UNITADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        UNIT_MASTER.Enabled = True
                        UNITEDIT.Enabled = True
                    Else
                        UNITEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "STORE ITEM MASTER" Then
                    If DTROW(1).ToString = True Then
                        STOREITEM_MASTER.Enabled = True
                        STOREITEMADD.Enabled = True
                    Else
                        STOREITEMADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        STOREITEM_MASTER.Enabled = True
                        STOREITEMEDIT.Enabled = True
                    Else
                        STOREITEMEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "OPENING" Then
                    If DTROW(1).ToString = True Or (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        OPENST_MASTER.Enabled = True
                        INHOUSEST.Enabled = True
                    End If

                ElseIf DTROW(0).ToString = "LOCATION MASTER" Then
                    If (DTROW(1) = True) Or (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        LOC_MASTER.Enabled = True
                    End If


                    'PURCHASE
                ElseIf DTROW(0).ToString = "PURCHASE ORDER" Then
                    If DTROW(1).ToString = True Then
                        PO_MASTER.Enabled = True
                        PO_TOOL.Enabled = True
                        POCLOSE.Enabled = True
                        POADD.Enabled = True
                        OPPO_MASTER.Enabled = True
                        OPPOADD.Enabled = True
                    Else
                        POADD.Enabled = False
                        OPPOADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        PO_MASTER.Enabled = True
                        PO_TOOL.Enabled = True
                        POCLOSE.Enabled = True
                        POEDIT.Enabled = True
                        OPPO_MASTER.Enabled = True
                        OPPOEDIT.Enabled = True
                    Else
                        POEDIT.Enabled = False
                        OPPOEDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "STORES" Then
                    If DTROW(1).ToString = True Then
                        OPENING_STORESTOCK.Enabled = True
                        STORESPO_MASTER.Enabled = True
                        STORESPOCLOSE.Enabled = True
                        STOREINWARD_MASTER.Enabled = True
                        STORECONSUMPTION_MASTER.Enabled = True
                        TRANSFERSTORES_MASTER.Enabled = True
                        STORESPOADD.Enabled = True
                        STOREINWARDADD.Enabled = True
                        STORECONSUMPTIONADD.Enabled = True
                        TRANSFERSTORESADD.Enabled = True
                    Else
                        STORESPOADD.Enabled = False
                        STOREINWARDADD.Enabled = False
                        STORECONSUMPTIONADD.Enabled = False
                        TRANSFERSTORESADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        OPENING_STORESTOCK.Enabled = True
                        STORESPO_MASTER.Enabled = True
                        STORESPOCLOSE.Enabled = True
                        STOREINWARD_MASTER.Enabled = True
                        STORECONSUMPTION_MASTER.Enabled = True
                        TRANSFERSTORES_MASTER.Enabled = True
                        STORESPOEDIT.Enabled = True
                        STOREINWARDEDIT.Enabled = True
                        STORECONSUMPTIONEDIT.Enabled = True
                        TRANSFERSTORESEDIT.Enabled = True
                    Else
                        STORESPOEDIT.Enabled = False
                        STOREINWARDEDIT.Enabled = False
                        STORECONSUMPTIONEDIT.Enabled = False
                        TRANSFERSTORESEDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "GRN" Then
                    If DTROW(1).ToString = True Then
                        GRN_MASTER.Enabled = True
                        GRNGREY_TOOL.Enabled = True
                        GRNADD.Enabled = True
                    Else
                        GRNADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        GRN_MASTER.Enabled = True
                        GRNGREY_TOOL.Enabled = True
                        GRNEDIT.Enabled = True
                    Else
                        GRNEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "QUALITY CHECK" Then
                    If DTROW(1).ToString = True Then
                        GRNCHECKING_MASTER.Enabled = True
                        GRNCHECKING_TOOL.Enabled = True
                        GRNCHECKINGADD.Enabled = True
                    Else
                        GRNCHECKINGADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        GRNCHECKING_MASTER.Enabled = True
                        GRNCHECKING_TOOL.Enabled = True
                        GRNCHECKINGEDIT.Enabled = True
                    Else
                        GRNCHECKINGEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "PURCHASE RETURN" Then
                    If DTROW(1).ToString = True Then
                        PURRETCHALLAN_MASTER.Enabled = True
                        PURRETCHALLANADD.Enabled = True
                    Else
                        PURRETCHALLANADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        PURRETCHALLAN_MASTER.Enabled = True
                        PURRETCHALLANEDIT.Enabled = True
                    Else
                        PURRETCHALLANEDIT.Enabled = False
                    End If


                    'SALE
                ElseIf DTROW(0).ToString = "SALE ORDER" Then
                    If DTROW(1).ToString = True Then
                        SO_TOOL.Enabled = True
                        SO_MASTER.Enabled = True
                        SOADD.Enabled = True
                        OPSO_MASTER.Enabled = True
                        OPSOADD.Enabled = True
                        SOCLOSE.Enabled = True

                    Else
                        SOADD.Enabled = False
                        OPSOADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        SO_MASTER.Enabled = True
                        SOEDIT.Enabled = True
                        OPSO_MASTER.Enabled = True
                        OPSOEDIT.Enabled = True
                        SOCLOSE.Enabled = True
                    Else
                        SOEDIT.Enabled = False
                        OPSOEDIT.Enabled = False
                    End If

                ElseIf DTROW(0).ToString = "GDN" Then
                    If DTROW(1).ToString = True Then
                        GDN_MASTER.Enabled = True
                        GDNADD.Enabled = True
                        INTERGODOWNTRANSFER_MASTER.Enabled = True
                        INTERGODOWNADD.Enabled = True
                        STOCKTAKING_MASTER.Enabled = True
                        STOCKTAKINGADD.Enabled = True
                    Else
                        GDNADD.Enabled = False
                        INTERGODOWNADD.Enabled = False
                        STOCKTAKINGADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        GDN_MASTER.Enabled = True
                        GDNEDIT.Enabled = True
                        INTERGODOWNTRANSFER_MASTER.Enabled = True
                        INTERGODOWNEDIT.Enabled = True
                        STOCKTAKING_MASTER.Enabled = True
                        STOCKTAKINGEDIT.Enabled = True
                    Else
                        GDNEDIT.Enabled = False
                        INTERGODOWNEDIT.Enabled = False
                        STOCKTAKINGEDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "SALE INVOICE" Then
                    If DTROW(1).ToString = True Then
                        PROFORMASALE_MASTER.Enabled = True
                        PROFORMASALE_TOOL.Enabled = True
                        PROFORMASALECLOSE.Enabled = True
                        PROFORMASALEADD.Enabled = True
                    Else
                        PROFORMASALEADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        PROFORMASALE_MASTER.Enabled = True
                        PROFORMASALE_TOOL.Enabled = True
                        PROFORMASALECLOSE.Enabled = True
                        PROFORMASALEEDIT.Enabled = True
                    Else
                        PROFORMASALEEDIT.Enabled = False
                    End If




                    'ACCOUNTS
                ElseIf DTROW(0).ToString = "PAYMENT" Then
                    If DTROW(1).ToString = True Then
                        PAY_MASTER.Enabled = True
                        PAYADD.Enabled = True
                    Else
                        PAYADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        PAY_MASTER.Enabled = True
                        PAYEDIT.Enabled = True
                    Else
                        PAYEDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "RECEIPT" Then
                    If DTROW(1).ToString = True Then
                        REC_MASTER.Enabled = True
                        RECADD.Enabled = True
                    Else
                        RECADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        REC_MASTER.Enabled = True
                        RECEDIT.Enabled = True
                    Else
                        RECEDIT.Enabled = False
                    End If


                ElseIf DTROW(0).ToString = "PAYROLL" Then
                    If DTROW(1).ToString = True Then
                        SALARYSLIP_MASTER.Enabled = True
                        SALARYSLIPADD.Enabled = True
                    Else
                        SALARYSLIPADD.Enabled = False
                    End If
                    If (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        SALARYSLIP_MASTER.Enabled = True
                        SALARYSLIPEDIT.Enabled = True
                    Else
                        SALARYSLIPEDIT.Enabled = False
                    End If

                    'REPORTS
                ElseIf DTROW(0).ToString = "PURCHASE REPORTS" Then
                    If (DTROW(1) = True) Or (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        PUR_REPORTS.Enabled = True
                    End If


                ElseIf DTROW(0).ToString = "SALE REPORTS" Then
                    If (DTROW(1) = True) Or (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        SALE_REPORTS.Enabled = True
                    End If


                ElseIf DTROW(0).ToString = "STOCK REPORTS" Then
                    If (DTROW(1) = True) Or (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        STOCK_REPORTS.Enabled = True
                    End If


                ElseIf DTROW(0).ToString = "ACCOUNT REPORTS" Then
                    If (DTROW(1) = True) Or (DTROW(2) = True) Or (DTROW(3) = True) Or (DTROW(4) = True) Then
                        REGISTER_MAIN.Enabled = True
                        BANKREGISTER_MASTER.Enabled = True
                        CASHREGISTER_MASTER.Enabled = True
                        OTHERREPORT_MAIN.Enabled = True
                        PAYMENTREGISTER_MENU.Enabled = True
                        RECEIPTREGISTER_MENU.Enabled = True
                    End If


                End If
            Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub HEADERVISIBLE()
        Try
            PO_TOOL.Visible = POTOOLVISIBLE
            PO_TOOLSTRIP.Visible = POTOOLVISIBLE
            GRNGREY_TOOL.Visible = GRNTOOLVISIBLE
            GRNGREY_TOOLSTRIP.Visible = GRNTOOLVISIBLE
            PROFORMASALE_TOOL.Visible = SALETOOLVISIBLE
            SALE_TOOLSTRIP.Visible = SALETOOLVISIBLE
            SO_TOOL.Visible = SOTOOLVISIBLE
            SO_TOOLSTRIP.Visible = SOTOOLVISIBLE
            GRNCHECKING_TOOL.Visible = GRNCHECKTOOLVISIBLE
            GRNCHECKING_TOOLSTRIP.Visible = GRNCHECKTOOLVISIBLE
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub AddNewCategoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CATEGORYADD.Click
        Try
            Dim objCategory As New CategoryMaster
            objCategory.frmString = "CATEGORY"
            objCategory.MdiParent = Me
            objCategory.Show()
            objCategory.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub AddNewGroupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GROUPADD.Click
        Try
            Dim objGroupMaster As New GroupMaster
            objGroupMaster.MdiParent = Me
            objGroupMaster.Show()
            objGroupMaster.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub AddNewCityToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewCityToolStripMenuItem.Click
        Try
            Dim objcitymaster As New citymaster
            objcitymaster.MdiParent = Me
            objcitymaster.frmstring = "CITYMASTER"
            objcitymaster.Show()
            objcitymaster.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub AddNewStateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewStateToolStripMenuItem.Click
        Try
            Dim objcitymaster As New citymaster
            objcitymaster.MdiParent = Me
            objcitymaster.frmstring = "STATEMASTER"
            objcitymaster.Show()
            objcitymaster.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub AddNewCountryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewCountryToolStripMenuItem.Click
        Try
            Dim objcitymaster As New citymaster
            objcitymaster.MdiParent = Me
            objcitymaster.frmstring = "COUNTRYMASTER"
            objcitymaster.Show()
            objcitymaster.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub AddNewAreaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewAreaToolStripMenuItem.Click
        Try
            Dim objcitymaster As New citymaster
            objcitymaster.MdiParent = Me
            objcitymaster.frmstring = "AREAMASTER"
            objcitymaster.Show()
            objcitymaster.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try

    End Sub

    Private Sub AddNewItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ITEMADD.Click
        Try
            Dim objItemMaster As New ItemMaster
            objItemMaster.MdiParent = Me
            objItemMaster.frmstring = "MERCHANT"
            objItemMaster.Show()
            objItemMaster.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub AddNewAccountsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ACCADD.Click
        Try
            Dim objAccountMaster As New AccountsMaster
            objAccountMaster.MdiParent = Me
            objAccountMaster.frmstring = "ACCOUNTS"
            objAccountMaster.Show()
            objAccountMaster.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub EditExistingGroupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GROUPEDIT.Click
        Try
            Dim objGroupDetails As New GroupDetails
            objGroupDetails.MdiParent = Me
            objGroupDetails.Show()
            objGroupDetails.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub EditExistingAccoutsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ACCEDIT.Click
        Try
            Dim objAccountDetails As New AccountsDetails
            objAccountDetails.MdiParent = Me
            objAccountDetails.frmstring = "ACCOUNTS"
            objAccountDetails.Show()
            objAccountDetails.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub EditExistingItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ITEMEDIT.Click
        Try
            Dim objItemDetails As New ItemDetails
            objItemDetails.MdiParent = Me
            objItemDetails.FRMSTRING = "MERCHANT"
            objItemDetails.Show()
            objItemDetails.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub EditExistingCategoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CATEGORYEDIT.Click
        Try
            Dim objCategoryDetails As New CategoryDetails
            objCategoryDetails.MdiParent = Me
            objCategoryDetails.FRMSTRING = "CATEGORY"
            objCategoryDetails.Show()
            objCategoryDetails.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub EditExistingAreaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditExistingAreaToolStripMenuItem.Click
        Try
            Dim objCityDetails As New CityDetails
            objCityDetails.MdiParent = Me
            objCityDetails.frmstring = "AREAMASTER"
            objCityDetails.Show()
            objCityDetails.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub EditExistingCityToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditExistingCityToolStripMenuItem.Click
        Try
            Dim objCityDetails As New CityDetails
            objCityDetails.MdiParent = Me
            objCityDetails.frmstring = "CITYMASTER"
            objCityDetails.Show()
            objCityDetails.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub EditExistingStateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditExistingStateToolStripMenuItem.Click
        Try
            Dim objCityDetails As New CityDetails
            objCityDetails.MdiParent = Me
            objCityDetails.frmstring = "STATEMASTER"
            objCityDetails.Show()
            objCityDetails.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub EditExistingCountryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditExistingCountryToolStripMenuItem.Click
        Try
            Dim objCityDetails As New CityDetails
            objCityDetails.MdiParent = Me
            objCityDetails.frmstring = "COUNTRYMASTER"
            objCityDetails.Show()
            objCityDetails.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub AddNewUnitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UNITADD.Click
        Try
            Dim objunitmaster As New UnitMaster
            objunitmaster.MdiParent = Me
            objunitmaster.frmString = "UNIT"
            objunitmaster.Show()
            objunitmaster.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub EditExistingUnitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UNITEDIT.Click
        Try
            Dim objUnitDetails As New UnitDetails
            objUnitDetails.MdiParent = Me
            objUnitDetails.frmstring = "UNIT"
            objUnitDetails.Show()
            objUnitDetails.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub addUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles USERADD.Click
        Try
            Dim objuser As New UserMaster
            objuser.MdiParent = Me
            objuser.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub editUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles USEREDIT.Click
        Try
            Dim objuser As New UserDetails
            objuser.MdiParent = Me
            objuser.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Sub opencmp(ByVal CMP As String)
        Try

            Dim objcmn As New ClsCommon
            Dim DT As DataTable

            DT = objcmn.SEARCH("CMPMASTER.CMP_NAME, YearMaster.YEAR_DBNAME, Cmpmaster.CMP_ID, YearMaster.YEAR_STARTDATE, YearMaster.YEAR_ENDDATE, YearMaster.YEAR_ID", "", " CMPMASTER INNER JOIN YEARMASTER ON YEARMASTER.YEAR_CMPID = CMPMASTER.CMP_ID", " And CMPMASTER.CMP_NAME = '" & CMP & "'")
            CmpName = DT.Rows(0).Item(0).ToString
            DBName = DT.Rows(0).Item(1).ToString
            CmpId = DT.Rows(0).Item(2).ToString
            AccFrom = DT.Rows(0).Item(3)
            AccTo = DT.Rows(0).Item(4)
            YearId = DT.Rows(0).Item(5).ToString
            Cmppassword.cmdback.Visible = False
            Cmppassword.lblretype.Visible = False
            Cmppassword.txtretypepassword.Visible = False
            Cmppassword.cmdnext.Text = "&Ok"
            Cmppassword.ShowDialog()

        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub AddNewRegisterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewRegisterToolStripMenuItem.Click
        Try
            Dim objregistermaster As New RegisterMaster
            objregistermaster.MdiParent = Me
            objregistermaster.frmstring = "PURCHASE"
            objregistermaster.Show()
            objregistermaster.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub ToolStripMenuItem14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem14.Click
        Try
            Dim objregistermaster As New RegisterMaster
            objregistermaster.MdiParent = Me
            objregistermaster.frmstring = "SALE"
            objregistermaster.Show()
            objregistermaster.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub ToolStripMenuItem17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem17.Click
        Try
            Dim objregistermaster As New RegisterMaster
            objregistermaster.MdiParent = Me
            objregistermaster.frmstring = "JOURNAL"
            objregistermaster.Show()
            objregistermaster.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub ToolStripMenuItem19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem19.Click
        Try
            Dim objregistermaster As New RegisterMaster
            objregistermaster.MdiParent = Me
            objregistermaster.frmstring = "CONTRA"
            objregistermaster.Show()
            objregistermaster.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub ToolStripMenuItem21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem21.Click
        Try
            Dim objregistermaster As New RegisterMaster
            objregistermaster.MdiParent = Me
            objregistermaster.frmstring = "PAYMENT"
            objregistermaster.Show()
            objregistermaster.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub ToolStripMenuItem23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem23.Click
        Try
            Dim objregistermaster As New RegisterMaster
            objregistermaster.MdiParent = Me
            objregistermaster.frmstring = "RECEIPT"
            objregistermaster.Show()
            objregistermaster.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewExpenseRegisterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewExpenseRegisterToolStripMenuItem.Click
        Try
            Dim objregistermaster As New RegisterMaster
            objregistermaster.MdiParent = Me
            objregistermaster.frmstring = "EXPENSE"
            objregistermaster.Show()
            objregistermaster.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub AddNewRegisterToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewRegisterToolStripMenuItem1.Click
        Try
            Dim objregistermaster As New RegisterMaster
            objregistermaster.MdiParent = Me
            objregistermaster.frmstring = "CREDITNOTE"
            objregistermaster.Show()
            objregistermaster.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub AddNewRegisterToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewRegisterToolStripMenuItem2.Click
        Try
            Dim objregistermaster As New RegisterMaster
            objregistermaster.MdiParent = Me
            objregistermaster.frmstring = "DEBITNOTE"
            objregistermaster.Show()
            objregistermaster.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub DEPARTMENTADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DEPARTMENTADD.Click
        Try
            Dim objCategory As New CategoryMaster
            objCategory.frmString = "DEPARTMENT"
            objCategory.MdiParent = Me
            objCategory.Show()
            objCategory.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub DEPARTMENTEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DEPARTMENTEDIT.Click
        Try
            Dim objCategoryDetails As New CategoryDetails
            objCategoryDetails.MdiParent = Me
            objCategoryDetails.FRMSTRING = "DEPARTMENT"
            objCategoryDetails.Show()
            objCategoryDetails.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub ChangeCompany_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeCompany.Click
        Try
            'close all child forms
            Dim frm As Form
            For Each frm In MdiChildren
                frm.Close()
            Next

            Me.Dispose()
            Cmpdetails.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ChangeUserToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeUserToolStripMenuItem.Click
        Try
            'close all child forms
            Dim frm As Form
            For Each frm In MdiChildren
                frm.Close()
            Next

            Me.Dispose()
            Login.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMPEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMPEDIT.Click
        Try
            Cmpmaster.EDIT = True
            Cmpmaster.TEMPCMPNAME = CmpName
            Cmpmaster.ShowDialog()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CMPADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMPADD.Click
        Try
            Dim obj As New Cmpmaster
            obj.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GRNADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GRNADD.Click
        Try
            Dim OBJGRN As New GRN
            OBJGRN.MdiParent = Me
            OBJGRN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRNEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GRNEDIT.Click
        Try
            Dim OBJGRN As New GRNDetails
            OBJGRN.MdiParent = Me
            OBJGRN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GreyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles INHOUSEST.Click
        Try
            Dim OBJ As New OpeningStock
            OBJ.MdiParent = Me
            OBJ.Show()
        Catch ex As Exception
        Throw ex
        End Try
    End Sub

    Private Sub GRN_TOOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GRNGREY_TOOL.Click
        Try
            Dim OBJGRN As New GRN
            OBJGRN.MdiParent = Me
            OBJGRN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GDN_TOOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim OBJGDN As New PackingSlip
            OBJGDN.MdiParent = Me
            OBJGDN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MDIMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            Dim TEMPMSG As Integer = MsgBox("Wish to Exit?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbNo Then
                Dim OBJCMN As New ClsCommon
                Dim DT2 As DataTable = OBJCMN.Execute_Any_String(" UPDATE USERMASTER SET USER_CHK = 0", " WHERE USER_NAME='" & UserName & "' and user_cmpid='" & CmpId & "' and user_locationid='" & Locationid & "' and user_yearid='" & YearId & "'", "")
                e.Cancel = True
                Exit Sub
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRNGREYADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GRNADD.Click
        Try
            Dim OBJGRN As New GRN
            OBJGRN.MdiParent = Me
            OBJGRN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRNGREYEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GRNEDIT.Click
        Try
            Dim OBJGRN As New GRNDetails
            OBJGRN.MdiParent = Me
            OBJGRN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub POADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles POADD.Click
        Try
            Dim ObjPurchaseOrder As New PurchaseOrder
            ObjPurchaseOrder.MdiParent = Me
            ObjPurchaseOrder.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub POEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles POEDIT.Click
        Try
            Dim ObjPurchaseOrder As New PurchaseOrderDetails
            ObjPurchaseOrder.MdiParent = Me
            ObjPurchaseOrder.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GDNADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GDNADD.Click
        Try
            Dim Objgdn As New PackingSlip
            Objgdn.MdiParent = Me
            Objgdn.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GDNEDIT_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles GDNEDIT.Click
        Try
            Dim Objgdndetails As New PackingSlipDetails
            Objgdndetails.MdiParent = Me
            Objgdndetails.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SOADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SOADD.Click
        Try
            Dim ObjSO As New SaleOrder
            ObjSO.MdiParent = Me
            ObjSO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ReprintBarcodeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReprintBarcodeToolStripMenuItem.Click
        Try
            Dim OBJREPRINT As New Reprint
            OBJREPRINT.MdiParent = Me
            OBJREPRINT.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SOEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SOEDIT.Click
        Try
            Dim ObjSO As New SaleOrderDetails
            ObjSO.MdiParent = Me
            ObjSO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OutStockDetailsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OutStockDetailsToolStripMenuItem.Click
        Try
            Dim ObjOutStockReport As New OutStockReport
            ObjOutStockReport.MdiParent = Me
            ObjOutStockReport.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PAYADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PAYADD.Click
        Try
            Dim OBJPAY As New PaymentMaster
            OBJPAY.MdiParent = Me
            OBJPAY.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PAYEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PAYEDIT.Click
        Try
            Dim OBJPAY As New PaymentDetails
            OBJPAY.MdiParent = Me
            OBJPAY.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RECADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RECADD.Click
        Try
            Dim OBJREC As New Receipt
            OBJREC.MdiParent = Me
            OBJREC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RECEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RECEDIT.Click
        Try
            Dim OBJREC As New ReceiptDetails
            OBJREC.MdiParent = Me
            OBJREC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub NARRATIONADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NARRATIONADD.Click
        Try
            Dim objCategory As New CategoryMaster
            objCategory.frmString = "NARRATION"
            objCategory.MdiParent = Me
            objCategory.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub PARTYBANKADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PARTYBANKADD.Click
        Try
            Dim objCategory As New CategoryMaster
            objCategory.frmString = "PARTYBANK"
            objCategory.MdiParent = Me
            objCategory.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub PARYUBANKEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PARTYBANKEDIT.Click
        Try
            Dim objCategory As New CategoryDetails
            objCategory.FRMSTRING = "PARTYBANK"
            objCategory.MdiParent = Me
            objCategory.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub NARRATIONEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NARRATIONEDIT.Click
        Try
            Dim objCategory As New CategoryDetails
            objCategory.FRMSTRING = "NARRATION"
            objCategory.MdiParent = Me
            objCategory.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub SALE_TOOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PROFORMASALE_TOOL.Click
        Try
            Dim OBJINVOICE As New ProformaInvoice
            OBJINVOICE.MdiParent = Me
            OBJINVOICE.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BackupCompany_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackupCompany.Click
        Try
            backup()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub backup()
        'TAKE BACKUP
        Dim TEMPMSG As Integer = MsgBox("Create Backup?", MsgBoxStyle.YesNo)
        If TEMPMSG = vbYes Then

            'CHECKING FOR BACKUP FOLDER
            If FileIO.FileSystem.DirectoryExists("C:\ZALANIBACKUP") = False Then FileIO.FileSystem.CreateDirectory("C:\ZALANIBACKUP")

            'IF SAME DATE'S BACKUP EXIST THEN DELETE IT THEN RECREATE IT
            If FileIO.FileSystem.FileExists("C:\ZALANIBACKUP\BACKUP " & Now.Day & "-" & Now.Month & "-" & Now.Year & ".bak") Then FileIO.FileSystem.DeleteFile("C:\ZALANIBACKUP\BACKUP " & Now.Day & "-" & Now.Month & "-" & Now.Year & ".bak")

            Dim OBJCMN As New ClsCommon
            On Error Resume Next
            Dim DT As DataTable = OBJCMN.Execute_Any_String(" BACKUP DATABASE ZALANI TO DISK='C:\ZALANIBACKUP\BACKUP " & Now.Day & "-" & Now.Month & "-" & Now.Year & ".BAK'", "", "")
            MsgBox("Backup Completed")
        End If

    End Sub

    Private Sub MERGELEDGER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MERGELEDGER.Click
        Try
            Dim OBJMERGE As New MergeLedger
            OBJMERGE.MdiParent = Me
            OBJMERGE.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MergeParameterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MergeParameterToolStripMenuItem.Click
        Try
            Dim OBJmerger As New MergeParameter
            OBJmerger.MdiParent = Me
            OBJmerger.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub YEARADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles YEARADD.Click
        Try
            Dim TEMPMSG As Integer = MsgBox("Create New Accounting Year?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbYes Then
                Dim obj As New YearMaster
                obj.cmdback.Visible = False
                obj.EDIT = False
                obj.FRMSTRING = "ADDYEAR"
                obj.Show()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DataTransferToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DATATRANSFER_MASTER.Click
        Try
            Dim OBJYEAR As New YearTransfer
            OBJYEAR.FRMSTRING = "YEARTRANSFER"
            OBJYEAR.MdiParent = Me
            OBJYEAR.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewStockAdjustmentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles STOCKADJUSTMENTADD.Click
        Try
            Dim OBJDSTOCK As New StockReco
            OBJDSTOCK.MdiParent = Me
            OBJDSTOCK.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingAdjustmentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles STOCKADJUSTMENTEDIT.Click
        Try
            Dim OBJDSTOCK As New StockRecoDetails
            OBJDSTOCK.MdiParent = Me
            OBJDSTOCK.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PO_TOOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PO_TOOL.Click
        Try
            Dim OBJPO As New PurchaseOrder
            OBJPO.MdiParent = Me
            OBJPO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub STOREINWARDADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles STOREINWARDADD.Click
        Try
            Dim OBJSTORE As New StoreInward
            OBJSTORE.MdiParent = Me
            OBJSTORE.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub STOREINWARDEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles STOREINWARDEDIT.Click
        Try
            Dim OBJSTORE As New StoreInwardDetails
            OBJSTORE.MdiParent = Me
            OBJSTORE.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewItemToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles STOREITEMADD.Click
        Try
            Dim OBJSTORE As New StoreItemMaster
            OBJSTORE.MdiParent = Me
            OBJSTORE.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingItemToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles STOREITEMEDIT.Click
        Try
            Dim OBJSTORE As New StoreItemDetails
            OBJSTORE.MdiParent = Me
            OBJSTORE.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OPENING_STORESTOCK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OPENING_STORESTOCK.Click
        Try
            Dim OBJOP As New OpeningStoreStock
            OBJOP.MdiParent = Me
            OBJOP.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub STOCKTRANSFER_MASTER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles STOCKTRANSFER_MASTER.Click
        Try
            Dim OBJYEAR As New YearTransfer
            OBJYEAR.FRMSTRING = "STOCKTRANSFER"
            OBJYEAR.MdiParent = Me
            OBJYEAR.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub UPLOADACCOUNTMENU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UPLOADACCOUNTMENU.Click
        Try
            If InputBox("Enter Master Password") <> "Infosys@123" Then Exit Sub

            '************************************ LEDGER UPLOAD ****************************
            'upload the files data
            ''Reading from Excel Woorkbook
            Dim cPart As Microsoft.Office.Interop.Excel.Range
            Dim oExcel As Microsoft.Office.Interop.Excel.Application = CreateObject("Excel.Application")
            Dim oBook As Microsoft.Office.Interop.Excel.Workbook = oExcel.Workbooks.Open("D:\" & InputBox("Enter File Name").ToString.Trim, , False)
            Dim oSheet As New Microsoft.Office.Interop.Excel.Worksheet
            oSheet = oBook.Worksheets("Sheet1")

            'GRID
            Dim ADDITEM As Boolean = True
            Dim TEMPITEMNAME As String = ""

            Dim DTSAVE As New System.Data.DataTable
            DTSAVE.Columns.Add("CODE")
            DTSAVE.Columns.Add("COMPANYNAME")
            DTSAVE.Columns.Add("ADD1")
            DTSAVE.Columns.Add("ADD2")
            DTSAVE.Columns.Add("ADDRESS")
            DTSAVE.Columns.Add("CITYNAME")
            DTSAVE.Columns.Add("PINNO")
            DTSAVE.Columns.Add("STATE")
            DTSAVE.Columns.Add("COUNTRY")
            DTSAVE.Columns.Add("PHONENO")
            DTSAVE.Columns.Add("MOBILENO")
            DTSAVE.Columns.Add("GSTIN")
            DTSAVE.Columns.Add("GROUPNAME")
            DTSAVE.Columns.Add("PANNO")
            DTSAVE.Columns.Add("BROKER")
            DTSAVE.Columns.Add("TRANSPORT")
            DTSAVE.Columns.Add("EMAIL")
            DTSAVE.Columns.Add("CRDAYS")
            DTSAVE.Columns.Add("SALESMAN")
            DTSAVE.Columns.Add("TDSPER")
            DTSAVE.Columns.Add("TDSSECTION")
            DTSAVE.Columns.Add("CMPNONCMP")
            DTSAVE.Columns.Add("DISCOUNT")
            DTSAVE.Columns.Add("CASHDISC")
            DTSAVE.Columns.Add("COMMISSION")
            DTSAVE.Columns.Add("SHIPPINGADD")
            DTSAVE.Columns.Add("RESINO")
            DTSAVE.Columns.Add("ALTNO")
            DTSAVE.Columns.Add("FAX")
            DTSAVE.Columns.Add("WEBSITE")
            DTSAVE.Columns.Add("REMARKS")
            DTSAVE.Columns.Add("INTPER")
            DTSAVE.Columns.Add("DELIVERYAT")
            DTSAVE.Columns.Add("DELIVERYPINCODE")
            DTSAVE.Columns.Add("KMS")
            DTSAVE.Columns.Add("BROKERAGECOMM")
            DTSAVE.Columns.Add("WHATSAPPNO")
            DTSAVE.Columns.Add("AREA")
            DTSAVE.Columns.Add("TYPE")

            Dim ARR As New ArrayList
            Dim COLIND As Integer = 0
            Dim DTROWSAVE As System.Data.DataRow = DTSAVE.NewRow()

            Dim FROMROWNO As Integer = Val(InputBox("Enter Start Row No"))
            Dim TOROWNO As Integer = Val(InputBox("Enter End Row No"))

            For I As Integer = FROMROWNO To TOROWNO

                If IsDBNull(oSheet.Range("A" & I.ToString).Text) = False Then
                    DTROWSAVE("CODE") = oSheet.Range("A" & I.ToString).Text
                Else
                    DTROWSAVE("CODE") = ""
                End If

                If IsDBNull(oSheet.Range("B" & I.ToString).Text) = False Then
                    DTROWSAVE("COMPANYNAME") = oSheet.Range("B" & I.ToString).Text
                Else
                    DTROWSAVE("COMPANYNAME") = ""
                End If

                If IsDBNull(oSheet.Range("C" & I.ToString).Text) = False Then
                    DTROWSAVE("ADD1") = oSheet.Range("C" & I.ToString).Text
                Else
                    DTROWSAVE("ADD1") = ""
                End If

                If IsDBNull(oSheet.Range("D" & I.ToString).Text) = False Then
                    DTROWSAVE("ADD2") = oSheet.Range("D" & I.ToString).Text
                Else
                    DTROWSAVE("ADD2") = ""
                End If

                If IsDBNull(oSheet.Range("E" & I.ToString).Text) = False Then
                    DTROWSAVE("ADDRESS") = oSheet.Range("E" & I.ToString).Text
                Else
                    DTROWSAVE("ADDRESS") = ""
                End If

                If IsDBNull(oSheet.Range("F" & I.ToString).Text) = False Then
                    DTROWSAVE("CITYNAME") = oSheet.Range("F" & I.ToString).Text
                Else
                    DTROWSAVE("CITYNAME") = ""
                End If

                If IsDBNull(oSheet.Range("G" & I.ToString).Text) = False Then
                    DTROWSAVE("PINNO") = oSheet.Range("G" & I.ToString).Text
                Else
                    DTROWSAVE("PINNO") = 0
                End If

                If IsDBNull(oSheet.Range("H" & I.ToString).Text) = False Then
                    DTROWSAVE("STATE") = oSheet.Range("H" & I.ToString).Text
                Else
                    DTROWSAVE("STATE") = ""
                End If

                If IsDBNull(oSheet.Range("I" & I.ToString).Text) = False Then
                    DTROWSAVE("COUNTRY") = oSheet.Range("I" & I.ToString).Text
                Else
                    DTROWSAVE("COUNTRY") = ""
                End If

                If IsDBNull(oSheet.Range("J" & I.ToString).Text) = False Then
                    DTROWSAVE("PHONENO") = oSheet.Range("J" & I.ToString).Text
                Else
                    DTROWSAVE("PHONENO") = ""
                End If

                If IsDBNull(oSheet.Range("K" & I.ToString).Text) = False Then
                    DTROWSAVE("MOBILENO") = oSheet.Range("K" & I.ToString).Text
                Else
                    DTROWSAVE("MOBILENO") = 0
                End If


                If IsDBNull(oSheet.Range("L" & I.ToString).Text) = False Then
                    DTROWSAVE("GSTIN") = oSheet.Range("L" & I.ToString).Text
                Else
                    DTROWSAVE("GSTIN") = ""
                End If

                If IsDBNull(oSheet.Range("M" & I.ToString).Text) = False Then
                    DTROWSAVE("GROUPNAME") = oSheet.Range("M" & I.ToString).Text
                Else
                    DTROWSAVE("GROUPNAME") = ""
                End If

                If IsDBNull(oSheet.Range("N" & I.ToString).Text) = False Then
                    DTROWSAVE("PANNO") = oSheet.Range("N" & I.ToString).Text
                Else
                    DTROWSAVE("PANNO") = ""
                End If

                If IsDBNull(oSheet.Range("O" & I.ToString).Text) = False Then
                    DTROWSAVE("BROKER") = oSheet.Range("O" & I.ToString).Text
                Else
                    DTROWSAVE("BROKER") = ""
                End If

                If IsDBNull(oSheet.Range("P" & I.ToString).Text) = False Then
                    DTROWSAVE("TRANSPORT") = oSheet.Range("P" & I.ToString).Text
                Else
                    DTROWSAVE("TRANSPORT") = ""
                End If

                If IsDBNull(oSheet.Range("Q" & I.ToString).Text) = False Then
                    DTROWSAVE("EMAIL") = oSheet.Range("Q" & I.ToString).Text
                Else
                    DTROWSAVE("EMAIL") = ""
                End If

                If IsDBNull(oSheet.Range("R" & I.ToString).Text) = False Then
                    DTROWSAVE("CRDAYS") = oSheet.Range("R" & I.ToString).Text
                Else
                    DTROWSAVE("CRDAYS") = ""
                End If

                If IsDBNull(oSheet.Range("S" & I.ToString).Text) = False Then
                    DTROWSAVE("SALESMAN") = oSheet.Range("S" & I.ToString).Text
                Else
                    DTROWSAVE("SALESMAN") = ""
                End If

                If IsDBNull(oSheet.Range("T" & I.ToString).Text) = False Then
                    DTROWSAVE("TDSPER") = oSheet.Range("T" & I.ToString).Text
                Else
                    DTROWSAVE("TDSPER") = ""
                End If

                If IsDBNull(oSheet.Range("U" & I.ToString).Text) = False Then
                    DTROWSAVE("TDSSECTION") = oSheet.Range("U" & I.ToString).Text
                Else
                    DTROWSAVE("TDSSECTION") = ""
                End If

                If IsDBNull(oSheet.Range("V" & I.ToString).Text) = False Then
                    DTROWSAVE("CMPNONCMP") = oSheet.Range("V" & I.ToString).Text
                Else
                    DTROWSAVE("CMPNONCMP") = ""
                End If

                If IsDBNull(oSheet.Range("W" & I.ToString).Text) = False Then
                    DTROWSAVE("DISCOUNT") = oSheet.Range("W" & I.ToString).Text
                Else
                    DTROWSAVE("DISCOUNT") = ""
                End If

                If IsDBNull(oSheet.Range("X" & I.ToString).Text) = False Then
                    DTROWSAVE("CASHDISC") = oSheet.Range("X" & I.ToString).Text
                Else
                    DTROWSAVE("CASHDISC") = ""
                End If

                If IsDBNull(oSheet.Range("Y" & I.ToString).Text) = False Then
                    DTROWSAVE("COMMISSION") = oSheet.Range("Y" & I.ToString).Text
                Else
                    DTROWSAVE("COMMISSION") = ""
                End If

                If IsDBNull(oSheet.Range("Z" & I.ToString).Text) = False Then
                    DTROWSAVE("SHIPPINGADD") = oSheet.Range("Z" & I.ToString).Text
                Else
                    DTROWSAVE("SHIPPINGADD") = ""
                End If

                If IsDBNull(oSheet.Range("AA" & I.ToString).Text) = False Then
                    DTROWSAVE("RESINO") = oSheet.Range("AA" & I.ToString).Text
                Else
                    DTROWSAVE("RESINO") = ""
                End If

                If IsDBNull(oSheet.Range("AB" & I.ToString).Text) = False Then
                    DTROWSAVE("ALTNO") = oSheet.Range("AB" & I.ToString).Text
                Else
                    DTROWSAVE("ALTNO") = ""
                End If

                If IsDBNull(oSheet.Range("AC" & I.ToString).Text) = False Then
                    DTROWSAVE("FAX") = oSheet.Range("AC" & I.ToString).Text
                Else
                    DTROWSAVE("FAX") = ""
                End If

                If IsDBNull(oSheet.Range("AD" & I.ToString).Text) = False Then
                    DTROWSAVE("WEBSITE") = oSheet.Range("AD" & I.ToString).Text
                Else
                    DTROWSAVE("WEBSITE") = ""
                End If

                If IsDBNull(oSheet.Range("AE" & I.ToString).Text) = False Then
                    DTROWSAVE("REMARKS") = oSheet.Range("AE" & I.ToString).Text
                Else
                    DTROWSAVE("REMARKS") = ""
                End If

                If IsDBNull(oSheet.Range("AF" & I.ToString).Text) = False Then
                    DTROWSAVE("INTPER") = Val(oSheet.Range("AF" & I.ToString).Text)
                Else
                    DTROWSAVE("INTPER") = 0
                End If

                If IsDBNull(oSheet.Range("AG" & I.ToString).Text) = False Then
                    DTROWSAVE("DELIVERYAT") = oSheet.Range("AG" & I.ToString).Text
                Else
                    DTROWSAVE("DELIVERYAT") = ""
                End If

                If IsDBNull(oSheet.Range("AH" & I.ToString).Text) = False Then
                    DTROWSAVE("DELIVERYPINCODE") = oSheet.Range("AH" & I.ToString).Text
                Else
                    DTROWSAVE("DELIVERYPINCODE") = ""
                End If

                If IsDBNull(oSheet.Range("AI" & I.ToString).Text) = False Then
                    DTROWSAVE("KMS") = Val(oSheet.Range("AI" & I.ToString).Text)
                Else
                    DTROWSAVE("KMS") = 0
                End If

                If IsDBNull(oSheet.Range("AJ" & I.ToString).Text) = False Then
                    DTROWSAVE("BROKERAGECOMM") = Val(oSheet.Range("AJ" & I.ToString).Text)
                Else
                    DTROWSAVE("BROKERAGECOMM") = 0
                End If

                If IsDBNull(oSheet.Range("AK" & I.ToString).Text) = False Then
                    DTROWSAVE("WHATSAPPNO") = oSheet.Range("AK" & I.ToString).Text
                Else
                    DTROWSAVE("WHATSAPPNO") = ""
                End If

                If IsDBNull(oSheet.Range("AL" & I.ToString).Text) = False Then
                    DTROWSAVE("AREA") = oSheet.Range("AL" & I.ToString).Text
                Else
                    DTROWSAVE("AREA") = ""
                End If

                If IsDBNull(oSheet.Range("AM" & I.ToString).Text) = False Then
                    DTROWSAVE("TYPE") = oSheet.Range("AM" & I.ToString).Text
                Else
                    DTROWSAVE("TYPE") = ""
                End If



                Dim ALPARAVAL As New ArrayList
                Dim OBJCMN As New ClsCommon
                Dim DTTABLE As DataTable = OBJCMN.SEARCH("CITY_ID AS CITYID", "", "CITYMASTER ", "AND CITY_NAME = '" & DTROWSAVE("CITYNAME") & "' AND CITY_YEARID = " & YearId)
                If DTTABLE.Rows.Count = 0 Then
                    'ADD NEW CITYNAME
                    Dim objyearmaster As New ClsYearMaster
                    objyearmaster.savecity(DTROWSAVE("CITYNAME"), CmpId, Locationid, Userid, YearId, " and city_name = '" & DTROWSAVE("CITYNAME") & "' AND CITY_CMPID = " & CmpId & " AND CITY_LOCATIONID = " & Locationid & " AND CITY_YEARID = " & YearId)
                End If


                DTTABLE = OBJCMN.SEARCH("CITY_ID AS CITYID", "", "CITYMASTER ", "AND CITY_NAME = '" & DTROWSAVE("DELIVERYAT") & "' AND CITY_YEARID = " & YearId)
                If DTTABLE.Rows.Count = 0 Then
                    'ADD NEW CITYNAME
                    Dim objyearmaster As New ClsYearMaster
                    objyearmaster.savecity(DTROWSAVE("DELIVERYAT"), CmpId, Locationid, Userid, YearId, " and city_name = '" & DTROWSAVE("DELIVERYAT") & "' AND CITY_CMPID = " & CmpId & " AND CITY_LOCATIONID = " & Locationid & " AND CITY_YEARID = " & YearId)
                End If


                DTTABLE = OBJCMN.SEARCH("AREA_ID AS AREAID", "", "AREAMASTER ", "AND AREA_NAME = '" & DTROWSAVE("AREA") & "' AND AREA_YEARID = " & YearId)
                If DTTABLE.Rows.Count = 0 Then
                    'ADD NEW AREA
                    Dim objyearmaster As New ClsYearMaster
                    objyearmaster.savearea(DTROWSAVE("AREA"), CmpId, Locationid, Userid, YearId, " and AREA_name = '" & DTROWSAVE("AREA") & "' AND AREA_CMPID = " & CmpId & " AND AREA_LOCATIONID = " & Locationid & " AND AREA_YEARID = " & YearId)
                End If


                DTTABLE = OBJCMN.SEARCH("STATE_ID AS STATEID", "", "STATEMASTER ", "AND STATE_NAME = '" & DTROWSAVE("STATE") & "' AND STATE_YEARID = " & YearId)
                If DTTABLE.Rows.Count = 0 Then
                    'ADD NEW STATE
                    Dim objyearmaster As New ClsYearMaster
                    objyearmaster.savestate(DTROWSAVE("STATE"), CmpId, Locationid, Userid, YearId, " and STATE_name = '" & DTROWSAVE("STATE") & "' AND STATE_YEARID = " & YearId)
                End If


                DTTABLE = OBJCMN.SEARCH("COUNTRY_ID AS COUNTRYID", "", "COUNTRYMASTER ", "AND COUNTRY_NAME = '" & DTROWSAVE("COUNTRY") & "' AND COUNTRY_YEARID = " & YearId)
                If DTTABLE.Rows.Count = 0 Then
                    'ADD NEW COUNTRY
                    Dim objyearmaster As New ClsYearMaster
                    objyearmaster.savecountry(DTROWSAVE("COUNTRY"), CmpId, Locationid, Userid, YearId, " and COUNTRY_name = '" & DTROWSAVE("COUNTRY") & "' AND COUNTRY_YEARID = " & YearId)
                End If


                'check whether ITEMNAME is already present or not
                DTTABLE = OBJCMN.SEARCH("ACC_CMPNAME AS COMPANYNAME", "", "LEDGERS ", " AND ACC_CMPNAME = '" & DTROWSAVE("COMPANYNAME") & "' AND ACC_YEARID = " & YearId)
                If DTTABLE.Rows.Count > 0 Then GoTo SKIPLINE



                'ADD IN ACCOUNTSMASTER
                ALPARAVAL.Clear()
                Dim OBJSM As New ClsAccountsMaster

                ALPARAVAL.Add(DTROWSAVE("COMPANYNAME"))
                ALPARAVAL.Add("")   'NAME
                ALPARAVAL.Add(DTROWSAVE("GROUPNAME"))
                ALPARAVAL.Add(0)    'OPBAL
                ALPARAVAL.Add("Cr.")
                ALPARAVAL.Add(Val(DTROWSAVE("INTPER")))    'INTPER
                ALPARAVAL.Add(0)    'PROFITPER
                ALPARAVAL.Add(DTROWSAVE("ADD1"))
                ALPARAVAL.Add(DTROWSAVE("ADD2"))
                ALPARAVAL.Add(DTROWSAVE("AREA"))   'AREA
                ALPARAVAL.Add("")   'STD
                ALPARAVAL.Add(DTROWSAVE("CITYNAME"))
                ALPARAVAL.Add(DTROWSAVE("PINNO"))
                ALPARAVAL.Add(DTROWSAVE("STATE"))
                ALPARAVAL.Add(DTROWSAVE("COUNTRY"))
                ALPARAVAL.Add(Val(DTROWSAVE("CRDAYS")))
                ALPARAVAL.Add(0)    'CRLIMIT
                ALPARAVAL.Add(DTROWSAVE("RESINO"))   'RESI
                ALPARAVAL.Add(DTROWSAVE("ALTNO"))   'ALT
                ALPARAVAL.Add(DTROWSAVE("PHONENO"))
                ALPARAVAL.Add(DTROWSAVE("MOBILENO"))
                ALPARAVAL.Add(DTROWSAVE("WHATSAPPNO"))   'WHATSAPPNO
                ALPARAVAL.Add(DTROWSAVE("FAX"))   'FAX
                ALPARAVAL.Add(DTROWSAVE("WEBSITE"))   'WEBSITE
                ALPARAVAL.Add(DTROWSAVE("EMAIL"))   'EMAIL

                ALPARAVAL.Add(DTROWSAVE("TRANSPORT"))   'TRANS
                ALPARAVAL.Add(DTROWSAVE("BROKER"))   'AGENT
                ALPARAVAL.Add(Val(DTROWSAVE("COMMISSION")))    'AGENTCOM
                ALPARAVAL.Add(Val(DTROWSAVE("DISCOUNT")))    'DISC
                ALPARAVAL.Add(Val(DTROWSAVE("CASHDISC")))    'CDPER
                ALPARAVAL.Add(Val(DTROWSAVE("KMS")))    'KMS

                ALPARAVAL.Add(DTROWSAVE("PANNO"))   'PAN
                ALPARAVAL.Add("")   'EXISE
                ALPARAVAL.Add("")   'RANGE
                ALPARAVAL.Add("")   'ADDLESS
                ALPARAVAL.Add("")   'CST
                ALPARAVAL.Add("")   'TIN
                ALPARAVAL.Add("")   'ST
                ALPARAVAL.Add("")   'VAT
                ALPARAVAL.Add(DTROWSAVE("GSTIN"))
                ALPARAVAL.Add("")   'REGISTER
                ALPARAVAL.Add(DTROWSAVE("ADDRESS"))
                ALPARAVAL.Add(DTROWSAVE("SHIPPINGADD"))   'SHIPADD
                ALPARAVAL.Add(DTROWSAVE("REMARKS"))   'REMARKS
                ALPARAVAL.Add("")   'PARTYBANK
                ALPARAVAL.Add("")   'ACCTYPE
                ALPARAVAL.Add("")   'ACCNO
                ALPARAVAL.Add("")   'IFSCCODE
                ALPARAVAL.Add("")   'BRANCH
                ALPARAVAL.Add("")   'BANKCITY
                ALPARAVAL.Add("")   'GROUPOFCOMPANIES
                ALPARAVAL.Add(0)    'BLOCKED
                ALPARAVAL.Add(0)    'RCM
                ALPARAVAL.Add(0)    'OVERSEAS
                ALPARAVAL.Add(0)    'HOLDFORAPPROVAL
                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(Userid)
                ALPARAVAL.Add(YearId)
                ALPARAVAL.Add(0)    'TRANSFER
                ALPARAVAL.Add(DTROWSAVE("CODE"))
                ALPARAVAL.Add("")    'PRICELIST
                ALPARAVAL.Add("")    'PACKINGTYPE
                ALPARAVAL.Add("")    'TERM
                ALPARAVAL.Add(DTROWSAVE("SALESMAN"))    'SALESMAN
                ALPARAVAL.Add(DTROWSAVE("CITYNAME"))    'DELIVERYAT (SAME AS CITY WHILE UPLOADING)



                'TDS
                '*******************************
                ALPARAVAL.Add(0)    'ISTDS
                ALPARAVAL.Add("")   'DEDUCTEETYPER
                ALPARAVAL.Add("")   'TDSFORM
                ALPARAVAL.Add("")   'TDSCOMPANY
                ALPARAVAL.Add(0)    'ISLOWER

                ALPARAVAL.Add(DTROWSAVE("TDSSECTION"))   'SECTION
                ALPARAVAL.Add(Val(0))   'TDSRATE
                ALPARAVAL.Add(Val(DTROWSAVE("TDSPER")))    'TDSPER
                ALPARAVAL.Add(0) 'SURCHARGE
                ALPARAVAL.Add(0) 'LIMIT
                '*******************************

                ALPARAVAL.Add(0)    'TDSAC
                ALPARAVAL.Add("NON SEZ")    'SEZTYPE
                ALPARAVAL.Add(DTROWSAVE("CMPNONCMP"))   'NATUREOFPAY
                If DTROWSAVE("TYPE") <> "" Then ALPARAVAL.Add(DTROWSAVE("TYPE")) Else ALPARAVAL.Add("ACCOUNTS")   'TYPE
                ALPARAVAL.Add("")   'CALC
                ALPARAVAL.Add(0)                        'POMNADTE
                ALPARAVAL.Add(DTROWSAVE("PINNO"))       'DELIVERYPINCODE (SAME AS PINCODE WHILE UPLOADING)
                ALPARAVAL.Add("")   'UPI
                ALPARAVAL.Add("")   'MSME
                ALPARAVAL.Add(0)    'TCS
                ALPARAVAL.Add("")   'TDSDEDUCTEDAC
                ALPARAVAL.Add(0)    'TDSONGTOTAL
                ALPARAVAL.Add(Val(DTROWSAVE("BROKERAGECOMM")))    'COMMISSION
                ALPARAVAL.Add("")   'DISTRICT
                ALPARAVAL.Add("")   'WARNING TEXT
                ALPARAVAL.Add(0)   'GSTINVERIFIED
                ALPARAVAL.Add(0)   'PARTYTDS
                ALPARAVAL.Add(0)   'RD

                OBJSM.alParaval = ALPARAVAL
                Dim INTRES As Integer = OBJSM.SAVE()

                DTROWSAVE = DTSAVE.NewRow()

SKIPLINE:
            Next

            oBook.Close()

            Exit Sub

            '************************************ END OF CODE FOR LEDGER UPLOAD ****************************



        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GODOWNADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GODOWNADD.Click
        Try
            Dim objCategory As New CategoryMaster
            objCategory.frmString = "GODOWN"
            objCategory.MdiParent = Me
            objCategory.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub GODOWNEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GODOWNEDIT.Click
        Try
            Dim objCategory As New CategoryDetails
            objCategory.FRMSTRING = "GODOWN"
            objCategory.MdiParent = Me
            objCategory.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub AddNewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OPSOADD.Click
        Try
            Dim OBJOPSO As New OpeningSaleOrder
            OBJOPSO.MdiParent = Me
            OBJOPSO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingOpeningSaleOrderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OPSOEDIT.Click
        Try
            Dim OBJOPSO As New OpeningSaleOrderDetails
            OBJOPSO.MdiParent = Me
            OBJOPSO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ReconcileDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RECODATA_MASTER.Click
        Try
            Dim OBJRECO As New ReconcileData
            OBJRECO.MdiParent = Me
            OBJRECO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub HSNADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HSNADD.Click
        Try
            Dim OBJHSN As New HSNMaster
            OBJHSN.MdiParent = Me
            OBJHSN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub HSNEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HSNEDIT.Click
        Try
            Dim OBJHSN As New HSNDetails
            OBJHSN.MdiParent = Me
            OBJHSN.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DefaultRegisterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DefaultRegisterToolStripMenuItem.Click
        Try
            Dim objCategory As New DefaultRegister
            objCategory.MdiParent = Me
            objCategory.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BLOCKUSER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BLOCKUSER.Click
        Try
            Dim OBJUSER As New BlockUser
            OBJUSER.MdiParent = Me
            OBJUSER.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub USERTRANSFER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles USERTRANSFER.Click
        Try
            Dim OBJYEAR As New YearTransfer
            OBJYEAR.FRMSTRING = "USERTRANSFER"
            OBJYEAR.MdiParent = Me
            OBJYEAR.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MACHINEADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MACHINEADD.Click
        Try
            Dim objMACHINE As New MachineMaster
            objMACHINE.MdiParent = Me
            objMACHINE.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MACHINEEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MACHINEEDIT.Click
        Try
            Dim objMACHINE As New MachineDetails
            objMACHINE.MdiParent = Me
            objMACHINE.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PARTYITEMWISECHART_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PARTYITEMWISESTAMPING.Click
        Try
            Dim objdes As New PartyItemWiseStamping
            objdes.MdiParent = Me
            objdes.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub ADDNEWGROUPCOMPANY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ADDNEWGROUPCOMPANY.Click
        Try
            Dim objhp As New GroupOfCompanies
            objhp.MdiParent = Me
            objhp.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EDITGROUPCOMPANY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EDITGROUPCOMPANY.Click
        Try
            Dim objhp As New GroupOfCompaniesDetails
            objhp.MdiParent = Me
            objhp.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SOCLOSE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SOCLOSE.Click
        Try
            Dim OBJPO As New PurchaseOrderClose
            OBJPO.MdiParent = Me
            OBJPO.Show()
            OBJPO.FRMSTRING = "SALE"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SPECIALRIGHTS_MASTER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SPECIALRIGHTS_MASTER.Click
        Try
            Dim OBJSO As New SpecialRights
            OBJSO.MdiParent = Me
            OBJSO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub UPLOADITEMMENU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UPLOADITEMMENU.Click

        Try
            If InputBox("Enter Master Password") <> "Infosys@123" Then Exit Sub
            '************************************ ITEM UPLOAD ****************************
            'upload the files data
            ''Reading from Excel Woorkbook
            Dim cPart As Microsoft.Office.Interop.Excel.Range
            Dim oExcel As Microsoft.Office.Interop.Excel.Application = CreateObject("Excel.Application")
            Dim oBook As Microsoft.Office.Interop.Excel.Workbook = oExcel.Workbooks.Open("D:\" & InputBox("Enter File Name").ToString.Trim, , False)
            Dim oSheet As New Microsoft.Office.Interop.Excel.Worksheet
            oSheet = oBook.Worksheets("Sheet1")

            'GRID
            Dim ADDITEM As Boolean = True
            Dim TEMPITEMNAME As String = ""

            Dim DTSAVE As New System.Data.DataTable
            DTSAVE.Columns.Add("ITEMNAME")
            DTSAVE.Columns.Add("SELVEDGE")
            DTSAVE.Columns.Add("REMARKS")
            DTSAVE.Columns.Add("WIDTH")
            DTSAVE.Columns.Add("HSNCODE")
            DTSAVE.Columns.Add("CATEGORY")
            DTSAVE.Columns.Add("RATE")


            Dim ARR As New ArrayList
            Dim COLIND As Integer = 0
            Dim DTROWSAVE As System.Data.DataRow = DTSAVE.NewRow()

            Dim FROMROWNO As Integer = Val(InputBox("Enter Start Row No"))
            Dim TOROWNO As Integer = Val(InputBox("Enter End Row No"))

            For I As Integer = FROMROWNO To TOROWNO

                If IsDBNull(oSheet.Range("A" & I.ToString).Text) = False Then
                    DTROWSAVE("ITEMNAME") = oSheet.Range("A" & I.ToString).Text
                Else
                    DTROWSAVE("ITEMNAME") = ""
                End If

                If IsDBNull(oSheet.Range("B" & I.ToString).Text) = False Then
                    DTROWSAVE("SELVEDGE") = oSheet.Range("B" & I.ToString).Text
                Else
                    DTROWSAVE("SELVEDGE") = ""
                End If

                If IsDBNull(oSheet.Range("C" & I.ToString).Text) = False Then
                    DTROWSAVE("REMARKS") = oSheet.Range("C" & I.ToString).Text
                Else
                    DTROWSAVE("REMARKS") = ""
                End If

                If IsDBNull(oSheet.Range("D" & I.ToString).Text) = False Then
                    DTROWSAVE("WIDTH") = oSheet.Range("D" & I.ToString).Text
                Else
                    DTROWSAVE("WIDTH") = ""
                End If

                If IsDBNull(oSheet.Range("E" & I.ToString).Text) = False Then
                    DTROWSAVE("HSNCODE") = oSheet.Range("E" & I.ToString).Text
                Else
                    DTROWSAVE("HSNCODE") = ""
                End If

                If IsDBNull(oSheet.Range("F" & I.ToString).Text) = False Then
                    DTROWSAVE("CATEGORY") = oSheet.Range("F" & I.ToString).Text
                Else
                    DTROWSAVE("CATEGORY") = ""
                End If


                If IsDBNull(oSheet.Range("G" & I.ToString).Text) = False Then
                    DTROWSAVE("RATE") = Val(oSheet.Range("G" & I.ToString).Text)
                Else
                    DTROWSAVE("RATE") = 0
                End If

                Dim ALPARAVAL As New ArrayList
                Dim OBJCMN As New ClsCommon
                Dim DTTABLE As DataTable = OBJCMN.SEARCH("CATEGORY_ID AS CATEGORYID", "", "CATEGORYMASTER", "AND CATEGORY_NAME = '" & DTROWSAVE("CATEGORY") & "' AND CATEGORY_YEARID = " & YearId)
                If DTTABLE.Rows.Count = 0 Then
                    'ADD NEW CATEGORY
                    Dim OBJCATEGORY As New ClsCategoryMaster
                    OBJCATEGORY.alParaval.Add(DTROWSAVE("CATEGORY"))
                    OBJCATEGORY.alParaval.Add("")
                    OBJCATEGORY.alParaval.Add(CmpId)
                    OBJCATEGORY.alParaval.Add(0)
                    OBJCATEGORY.alParaval.Add(Userid)
                    OBJCATEGORY.alParaval.Add(YearId)
                    OBJCATEGORY.alParaval.Add(0)
                    Dim INTRESCAT As Integer = OBJCATEGORY.save()
                End If


                'check whether ITEMNAME is already present or not
                DTTABLE = OBJCMN.SEARCH("ITEM_NAME AS ITEMNAME", "", "ITEMMASTER", " AND ITEM_NAME = '" & DTROWSAVE("ITEMNAME") & "' AND ITEM_YEARID = " & YearId)
                If DTTABLE.Rows.Count > 0 Then GoTo SKIPLINE


                'ADD IN ACCOUNTSMASTER
                ALPARAVAL.Clear()
                Dim OBJSM As New clsItemmaster

                ALPARAVAL.Add("Finished Goods")
                ALPARAVAL.Add(DTROWSAVE("CATEGORY"))
                ALPARAVAL.Add(DTROWSAVE("ITEMNAME"))
                ALPARAVAL.Add(UCase(DTROWSAVE("ITEMNAME")))

                ALPARAVAL.Add("")   'DEPARTMENT
                ALPARAVAL.Add(DTROWSAVE("ITEMNAME"))
                ALPARAVAL.Add("")   'UNIT
                ALPARAVAL.Add("")   'FOLD
                ALPARAVAL.Add(Val(DTROWSAVE("RATE")))    'RATE   
                ALPARAVAL.Add(0)    'VALUATIONRATE   
                ALPARAVAL.Add(0)    'TRANSPORTRATE   
                ALPARAVAL.Add(0)    'CHECKINGRATE   
                ALPARAVAL.Add(0)    'PACKINGRATE   
                ALPARAVAL.Add(0)    'DESIGNRATE   
                ALPARAVAL.Add(0)    'REORDER
                ALPARAVAL.Add(0)    'UPPER
                ALPARAVAL.Add(0)    'LOWER
                ALPARAVAL.Add(DTROWSAVE("HSNCODE"))
                ALPARAVAL.Add(0)    'BLOCKED
                ALPARAVAL.Add(0)    'HIDEINDESIGN

                ALPARAVAL.Add(DTROWSAVE("WIDTH"))
                ALPARAVAL.Add("")   'GREYWIDTH
                ALPARAVAL.Add(0)    'SHIRINKFROM
                ALPARAVAL.Add(0)    'SHRINKTO
                ALPARAVAL.Add(DTROWSAVE("SELVEDGE"))

                ALPARAVAL.Add("")   'RATETYPE
                ALPARAVAL.Add("")   'GRIDRATE

                ALPARAVAL.Add("")   'YARNWUALITY
                ALPARAVAL.Add("")   'PER

                ALPARAVAL.Add("")   'GRIDSRNO
                ALPARAVAL.Add("")   'PROCESS

                ALPARAVAL.Add(DTROWSAVE("REMARKS"))
                ALPARAVAL.Add("MERCHANT")
                ALPARAVAL.Add(DBNull.Value)

                ALPARAVAL.Add("")   'WARP
                ALPARAVAL.Add("")   'WEFT


                ALPARAVAL.Add(CmpId)
                ALPARAVAL.Add(Locationid)
                ALPARAVAL.Add(Userid)
                ALPARAVAL.Add(YearId)
                ALPARAVAL.Add(0)


                ALPARAVAL.Add("")   'WARPSRNO
                ALPARAVAL.Add("")   'WARPQUALITY
                ALPARAVAL.Add("")   'WARPSHADE
                ALPARAVAL.Add("")   'WARPENDS
                ALPARAVAL.Add("")   'WARPWT
                ALPARAVAL.Add("")   'WARPRATE
                ALPARAVAL.Add("")   'WARPAMOUNT

                ALPARAVAL.Add("")   'WEFTSRNO
                ALPARAVAL.Add("")   'WEFTQUALITY
                ALPARAVAL.Add("")   'WEFTSHADE
                ALPARAVAL.Add("")   'WEFTPICK
                ALPARAVAL.Add("")   'WEFTWT
                ALPARAVAL.Add("")   'WEFTRATE
                ALPARAVAL.Add("")   'WEFTAMOUNT

                ALPARAVAL.Add(0)    'WARPTL
                ALPARAVAL.Add(0)    'WEFTTL
                ALPARAVAL.Add(0)    'REED
                ALPARAVAL.Add(0)    'REEDSPACE
                ALPARAVAL.Add(0)    'PICKS
                ALPARAVAL.Add(0)    'TOTALWT
                ALPARAVAL.Add(0)    'TOTALWARPWT
                ALPARAVAL.Add(0)    'TOTALWEFTWT
                ALPARAVAL.Add("")   'WEAVE
                ALPARAVAL.Add("")   'GREYCATEGORY


                ALPARAVAL.Add(0)    'ACTUALWT
                ALPARAVAL.Add(0)    'ACTUALAMT
                ALPARAVAL.Add(0)    'DHARAPER
                ALPARAVAL.Add(0)    'DHARAAMT
                ALPARAVAL.Add(0)    'WASTAGEPER
                ALPARAVAL.Add(0)    'WASTAGEAMT
                ALPARAVAL.Add(0)    'WEAVINGCHGS
                ALPARAVAL.Add(0)    'WEAVINGAMT
                ALPARAVAL.Add(0)    'GSTPER
                ALPARAVAL.Add(0)    'GSTAMT
                ALPARAVAL.Add(0)    'AMOUNT
                ALPARAVAL.Add(0)    'TOTALGSTPER
                ALPARAVAL.Add(0)    'TOTALAMT
                ALPARAVAL.Add(0)    'WARPTOTALAMT
                ALPARAVAL.Add(0)    'WEFTTOTALAMT

                ALPARAVAL.Add("")   'COLORNO
                ALPARAVAL.Add("")   'COLORSRNO

                ALPARAVAL.Add(0)    'VALUELOSSPER

                OBJSM.alParaval = ALPARAVAL
                Dim INTRES As Integer = OBJSM.SAVE()

                DTROWSAVE = DTSAVE.NewRow()

SKIPLINE:
            Next

            oBook.Close()

            Exit Sub

            '************************************ END OF CODE FOR ITEM UPLOAD ****************************



        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SO_TOOL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SO_TOOL.Click
        Try
            Dim OBJSO As New SaleOrder
            OBJSO.MdiParent = Me
            OBJSO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OPPOADD_Click(sender As Object, e As EventArgs) Handles OPPOADD.Click
        Try
            Dim OBJOPPO As New OpeningPurchaseOrder
            OBJOPPO.MdiParent = Me
            OBJOPPO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OPPOEDIT_Click(sender As Object, e As EventArgs) Handles OPPOEDIT.Click
        Try
            Dim OBJOPPO As New OpeningPurchaseOrderDetails
            OBJOPPO.MdiParent = Me
            OBJOPPO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub UPLOADSIGN_Click(sender As Object, e As EventArgs) Handles UPLOADSIGN.Click
        Try
            Dim OBJOPPO As New UploadSign
            OBJOPPO.MdiParent = Me
            OBJOPPO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TERMSANDCONDITIONS_Click(sender As Object, e As EventArgs) Handles TERMSANDCONDITIONS.Click
        Try
            Dim OBJOPPO As New TermsAndConditions
            OBJOPPO.MdiParent = Me
            OBJOPPO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub POCLOSE_Click(sender As Object, e As EventArgs) Handles POCLOSE.Click
        Try
            Dim OBJPO As New PurchaseOrderClose
            OBJPO.MdiParent = Me
            OBJPO.Show()
            OBJPO.FRMSTRING = "PURCHASE"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LOCKACCYEAR_MASTER_Click(sender As Object, e As EventArgs) Handles LOCKACCYEAR_MASTER.Click
        Try
            Dim OBJLOCK As New LockAccYear
            OBJLOCK.MdiParent = Me
            OBJLOCK.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BLOCKDATEMENU_Click(sender As Object, e As EventArgs) Handles BLOCKDATEMENU.Click
        Try
            Dim OBJBLOCK As New BlockDateEntry
            OBJBLOCK.MdiParent = Me
            OBJBLOCK.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub USERGODOWNADD_Click(sender As Object, e As EventArgs) Handles USERGODOWNADD.Click
        Try
            Dim OBJPROFORMA As New UserGodownTagging
            OBJPROFORMA.MdiParent = Me
            OBJPROFORMA.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub USERGODOWNEDIT_Click(sender As Object, e As EventArgs) Handles USERGODOWNEDIT.Click
        Try
            Dim OBJPROFORMA As New UserGodownTaggingDetails
            OBJPROFORMA.MdiParent = Me
            OBJPROFORMA.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CURRENCYADD_Click(sender As Object, e As EventArgs) Handles CURRENCYADD.Click
        Try
            Dim OBJCON As New CurrencyMaster
            OBJCON.MdiParent = Me
            OBJCON.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CURRENCYEDIT_Click(sender As Object, e As EventArgs) Handles CURRENCYEDIT.Click
        Try
            Dim OBJCON As New CurrencyMasterDetails
            OBJCON.MdiParent = Me
            OBJCON.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub STORECONSUMPTIONADD_Click(sender As Object, e As EventArgs) Handles STORECONSUMPTIONADD.Click
        Try
            Dim OBJSTORE As New StoreConsumption
            OBJSTORE.MdiParent = Me
            OBJSTORE.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub STORECONSUMPTIONEDIT_Click(sender As Object, e As EventArgs) Handles STORECONSUMPTIONEDIT.Click
        Try
            Dim OBJSTORE As New StoreConsumptionDetails
            OBJSTORE.MdiParent = Me
            OBJSTORE.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingREgisterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditExistingREgisterToolStripMenuItem.Click
        Try
            Dim objregistermaster As New RegisterMasterDelete
            objregistermaster.MdiParent = Me
            objregistermaster.frmstring = "PURCHASE"
            objregistermaster.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub ToolStripMenuItem16_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem16.Click
        Try
            Dim objregistermaster As New RegisterMasterDelete
            objregistermaster.MdiParent = Me
            objregistermaster.frmstring = "SALE"
            objregistermaster.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub ToolStripMenuItem18_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem18.Click
        Try
            Dim objregistermaster As New RegisterMasterDelete
            objregistermaster.MdiParent = Me
            objregistermaster.frmstring = "JOURNAL"
            objregistermaster.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub ToolStripMenuItem20_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem20.Click
        Try
            Dim objregistermaster As New RegisterMasterDelete
            objregistermaster.MdiParent = Me
            objregistermaster.frmstring = "CONTRA"
            objregistermaster.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub EditExistingExpenseRegisterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditExistingExpenseRegisterToolStripMenuItem.Click
        Try
            Dim objregistermaster As New RegisterMasterDelete
            objregistermaster.MdiParent = Me
            objregistermaster.frmstring = "EXPENSE"
            objregistermaster.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub ToolStripMenuItem22_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem22.Click
        Try
            Dim objregistermaster As New RegisterMasterDelete
            objregistermaster.MdiParent = Me
            objregistermaster.frmstring = "PAYMENT"
            objregistermaster.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub ToolStripMenuItem24_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem24.Click
        Try
            Dim objregistermaster As New RegisterMasterDelete
            objregistermaster.MdiParent = Me
            objregistermaster.frmstring = "RECEIPT"
            objregistermaster.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub DeleteExistingRegisterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteExistingRegisterToolStripMenuItem.Click
        Try
            Dim objregistermaster As New RegisterMasterDelete
            objregistermaster.MdiParent = Me
            objregistermaster.frmstring = "CREDITNOTE"
            objregistermaster.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub DeleteExistingRegisterToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DeleteExistingRegisterToolStripMenuItem1.Click
        Try
            Dim objregistermaster As New RegisterMasterDelete
            objregistermaster.MdiParent = Me
            objregistermaster.frmstring = "DEBITNOTE"
            objregistermaster.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub STOCKTAKINGADD_Click(sender As Object, e As EventArgs) Handles STOCKTAKINGADD.Click
        Try
            Dim OBJSTOCK As New StockTaking
            OBJSTOCK.MdiParent = Me
            OBJSTOCK.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub STOCKTAKINGEDIT_Click(sender As Object, e As EventArgs) Handles STOCKTAKINGEDIT.Click
        Try
            Dim OBJSTOCK As New StockTakingDetails
            OBJSTOCK.MdiParent = Me
            OBJSTOCK.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PROFORMASALEADD_Click(sender As Object, e As EventArgs) Handles PROFORMASALEADD.Click
        Try
            Dim OBJINVOICE As New ProformaInvoice
            OBJINVOICE.MdiParent = Me
            OBJINVOICE.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PROFORMASALEEDIT_Click(sender As Object, e As EventArgs) Handles PROFORMASALEEDIT.Click
        Try
            Dim OBJINVOICE As New ProformaInvoiceDetails
            OBJINVOICE.MdiParent = Me
            OBJINVOICE.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub REORDERLEVEL_MASTER_Click(sender As Object, e As EventArgs) Handles REORDERLEVEL_MASTER.Click
        Try
            Dim OBJREORDER As New ReOrderLevel
            OBJREORDER.MdiParent = Me
            OBJREORDER.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub UNUSEDLEDGERS_MASTER_Click(sender As Object, e As EventArgs) Handles UNUSEDLEDGERS_MASTER.Click
        Try
            Dim OBJLEDGERS As New UnusedLedgers
            OBJLEDGERS.MdiParent = Me
            OBJLEDGERS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub UPDATELOGS_MASTER_Click(sender As Object, e As EventArgs) Handles UPDATELOGS_MASTER.Click
        Try
            Dim OBJLOGS As New LogsUpdate
            OBJLOGS.MdiParent = Me
            OBJLOGS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DELETELOGS_MASTER_Click(sender As Object, e As EventArgs) Handles DELETELOGS_MASTER.Click
        Try
            Dim OBJLOGS As New LogsDelete
            OBJLOGS.MdiParent = Me
            OBJLOGS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewDistrictToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddNewDistrictToolStripMenuItem.Click
        Try
            Dim objCategory As New CategoryMaster
            objCategory.frmString = "DISTRICT"
            objCategory.MdiParent = Me
            objCategory.Show()
            objCategory.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub EditExistingDistrictToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditExistingDistrictToolStripMenuItem.Click
        Try
            Dim objCategory As New CategoryDetails
            objCategory.FRMSTRING = "DISTRICT"
            objCategory.MdiParent = Me
            objCategory.Show()
            objCategory.BringToFront()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub ADDNEWEMPLOYEE_Click(sender As Object, e As EventArgs) Handles EMPLOYEEADD.Click
        Try
            Dim OBJEMP As New EmployeeMaster
            OBJEMP.MdiParent = Me
            OBJEMP.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EDITEXISTINGEMPLOYEE_Click(sender As Object, e As EventArgs) Handles EMPLOYEEEDIT.Click
        Try
            Dim OBJEMP As New EmployeeDetails
            OBJEMP.MdiParent = Me
            OBJEMP.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SALARYSLIPADD_Click(sender As Object, e As EventArgs) Handles SALARYSLIPADD.Click
        Try
            Dim OBJSAL As New SalaryMaster
            OBJSAL.MdiParent = Me
            OBJSAL.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SALARYSLIPEDIT_Click(sender As Object, e As EventArgs) Handles SALARYSLIPEDIT.Click
        Try
            Dim OBJSAL As New SalaryDetails
            OBJSAL.MdiParent = Me
            OBJSAL.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub UPLOADBANKDETAILS_Click(sender As Object, e As EventArgs) Handles UPLOADBANKDETAILS.Click
        Try
            Dim OBJUPLOADBANK As New CmpBankDetails
            OBJUPLOADBANK.MdiParent = Me
            OBJUPLOADBANK.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OpeningStock_Click(sender As Object, e As EventArgs) Handles OpeningStock.Click
        Try
            Dim OBJSTOCK As New OpeningStockReport
            OBJSTOCK.MdiParent = Me
            OBJSTOCK.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RECEIPT_RENUM_Click(sender As Object, e As EventArgs) Handles RECEIPT_RENUM.Click
        Try

            If InputBox("Enter Master Password", "ZALANI") <> "Infosys@123" Then
                MsgBox("Invalid Password")
                Exit Sub
            End If

            If MsgBox("You are about to Renumber Entries, Please Take Backup First, Wish to Proceed?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            If MsgBox("Wish To Renumber Receipt Entries?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then RECEIPTRENUMBERING()
            MsgBox("Re-Numbering Done Successfully")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub RECEIPTRENUMBERING()
        Try
            'RENUMBER JOUNRAL VOUCHER FIRST
            Dim OBJCMN As New ClsCommon
            Dim DTREGISTER As DataTable = OBJCMN.SEARCH("REGISTER_ID AS REGID, REGISTER_NAME AS REGNAME, REGISTER_ABBR AS REGABBR, REGISTER_INITIALS AS REGINITIALS", "", " REGISTERMASTER ", " AND REGISTER_TYPE = 'RECEIPT' AND REGISTER_YEARID = " & YearId)
            If DTREGISTER.Rows.Count > 0 Then
                For Each REGROW As DataRow In DTREGISTER.Rows

                    'SEARCH ENTRY IN THIS REGISTER AND ADD IN TEMP TABLE
                    'FROM THIS TEMPTABLE WE WILL UPDATE THE ENTRIES
                    'WE WILL UPDATE THE ENTRYIES FROM THEIR OLDINITIALS, AND REPLACE WITH NEW INITIALS
                    'BUT NEW INITIALS WILL CONTAIN A SPECIAL CHARACTER SO THAT WE CAN DISTINGUISH BETWEEN OLD AND NEW INITIALS\
                    'ONCE ALL ENTRIES ARE UPDATED WE WILL REMOVE THAT SPECIAL CHARACTER
                    Dim DTENTRY As DataTable = OBJCMN.SEARCH("DISTINCT  RECEIPT_NO AS OLDNO, RECEIPT_registerid AS REGID, RECEIPT_DATE AS DATE, RECEIPT_initials AS OLDINITIALS, RECEIPT_yearid AS YEARID ", "", " RECEIPTMASTER ", " AND RECEIPT_registerid = " & REGROW("REGID") & " AND RECEIPT_YEARID = " & YearId & " ORDER BY RECEIPT_registerid, RECEIPT_date, RECEIPT_no")
                    Dim NEWBILLNO As Integer = 1
                    Dim TEMPDT As DataTable = OBJCMN.Execute_Any_String("DELETE FROM TEMPRENUMBERING WHERE YEARID = " & YearId, "", "")
                    For Each DTROW As DataRow In DTENTRY.Rows
                        TEMPDT = OBJCMN.Execute_Any_String("INSERT INTO TEMPRENUMBERING VALUES (" & DTROW("REGID") & ",'" & Format(Convert.ToDateTime(DTROW("DATE")).Date, "MM/dd/yyyy") & "'," & DTROW("YEARID") & "," & DTROW("OLDNO") & ",'" & DTROW("OLDINITIALS") & "'," & NEWBILLNO & ",'" & REGROW("REGINITIALS") & "-" & NEWBILLNO & "N')", "", "")


                        'UPDATE IN RECEIPT MASTER
                        TEMPDT = OBJCMN.Execute_Any_String("UPDATE RECEIPTMASTER SET RECEIPT_NO = " & NEWBILLNO & ", RECEIPT_INITIALS = '" & REGROW("REGINITIALS") & "-" & NEWBILLNO & "N' WHERE RECEIPT_INITIALS = '" & DTROW("OLDINITIALS") & "' AND RECEIPT_YEARID = " & YearId, "", "")
                        TEMPDT = OBJCMN.Execute_Any_String("UPDATE RECEIPTMASTER_DESC SET RECEIPT_NO = " & NEWBILLNO & ", RECEIPT_INITIALS = '" & REGROW("REGINITIALS") & "-" & NEWBILLNO & "N' WHERE RECEIPT_INITIALS = '" & DTROW("OLDINITIALS") & "' AND RECEIPT_YEARID = " & YearId, "", "")
                        TEMPDT = OBJCMN.Execute_Any_String("UPDATE RECEIPTMASTER_GRIDDESC SET RECEIPT_NO = " & NEWBILLNO & ", RECEIPT_INITIALS = '" & REGROW("REGINITIALS") & "-" & NEWBILLNO & "N' WHERE RECEIPT_INITIALS = '" & DTROW("OLDINITIALS") & "' AND RECEIPT_YEARID = " & YearId, "", "")


                        'UPDATE IN JOURNALMASTER
                        TEMPDT = OBJCMN.Execute_Any_String("UPDATE JOURNALMASTER SET JOURNAL_REFNO = '" & REGROW("REGINITIALS") & "-" & NEWBILLNO & "N' WHERE JOURNAL_REFNO = '" & DTROW("OLDINITIALS") & "' AND JOURNAL_YEARID = " & YearId, "", "")


                        'UPDATE IN ACCMASTER 
                        TEMPDT = OBJCMN.Execute_Any_String("UPDATE ACCMASTER SET ACC_BILLNO = " & NEWBILLNO & ",ACC_INITIALS = '" & REGROW("REGINITIALS") & "-" & NEWBILLNO & "N' WHERE ACC_INITIALS = '" & DTROW("OLDINITIALS") & "' AND ACC_YEARID = " & YearId, "", "")


                        'UPDATE IN PAYMENTMASTER 
                        TEMPDT = OBJCMN.Execute_Any_String("UPDATE PAYMENTMASTER_DESC SET PAYMENT_BILLINITIALS = '" & REGROW("REGINITIALS") & "-" & NEWBILLNO & "N' WHERE PAYMENT_BILLINITIALS = '" & DTROW("OLDINITIALS") & "' AND PAYMENT_YEARID = " & YearId, "", "")
                        TEMPDT = OBJCMN.Execute_Any_String("UPDATE PAYMENTMASTER_GRIDDESC SET PAYMENT_PAYBILLINITIALS = '" & REGROW("REGINITIALS") & "-" & NEWBILLNO & "N' WHERE PAYMENT_PAYBILLINITIALS = '" & DTROW("OLDINITIALS") & "' AND PAYMENT_YEARID = " & YearId, "", "")

                        'UPDATE IN CREDITNOTEMASTER_BILLDESC
                        TEMPDT = OBJCMN.Execute_Any_String("UPDATE CREDITNOTEMASTER_BILLDESC SET CN_BILLINITIALS = '" & REGROW("REGINITIALS") & "-" & NEWBILLNO & "N' WHERE CN_BILLINITIALS = '" & DTROW("OLDINITIALS") & "' AND CN_YEARID = " & YearId, "", "")

                        'UPDATE IN DEBITNOTEMASTER_BILLDESC
                        TEMPDT = OBJCMN.Execute_Any_String("UPDATE DEBITNOTEMASTER_BILLDESC SET DN_BILLINITIALS = '" & REGROW("REGINITIALS") & "-" & NEWBILLNO & "N' WHERE DN_BILLINITIALS = '" & DTROW("OLDINITIALS") & "' AND DN_YEARID = " & YearId, "", "")

                        'UPDATE IN MANUALMATCHING_DESC
                        TEMPDT = OBJCMN.Execute_Any_String("UPDATE MANUALMATCHING_DESC SET MATCH_BILLINITIALS = '" & REGROW("REGINITIALS") & "-" & NEWBILLNO & "N' WHERE MATCH_BILLINITIALS = '" & DTROW("OLDINITIALS") & "' AND MATCH_YEARID = " & YearId, "", "")


                        NEWBILLNO += 1
                    Next

                    'REMOVE SPECIAL CHARACTER FROM INTIIALS
                    TEMPDT = OBJCMN.Execute_Any_String("UPDATE RECEIPTMASTER SET RECEIPT_INITIALS = LEFT(RECEIPT_INITIALS, LEN(RECEIPT_INITIALS)-1) FROM RECEIPTMASTER INNER JOIN TEMPRENUMBERING ON NEWINITIALS = RECEIPT_INITIALS AND YEARID = RECEIPT_YEARID  WHERE RECEIPT_YEARID = " & YearId, "", "")
                    TEMPDT = OBJCMN.Execute_Any_String("UPDATE RECEIPTMASTER_DESC SET RECEIPT_INITIALS = LEFT(RECEIPT_INITIALS, LEN(RECEIPT_INITIALS)-1) FROM RECEIPTMASTER_DESC INNER JOIN TEMPRENUMBERING ON NEWINITIALS = RECEIPT_INITIALS AND YEARID = RECEIPT_YEARID  WHERE RECEIPT_YEARID = " & YearId, "", "")
                    TEMPDT = OBJCMN.Execute_Any_String("UPDATE RECEIPTMASTER_GRIDDESC SET RECEIPT_INITIALS = LEFT(RECEIPT_INITIALS, LEN(RECEIPT_INITIALS)-1) FROM RECEIPTMASTER_GRIDDESC INNER JOIN TEMPRENUMBERING ON NEWINITIALS = RECEIPT_INITIALS AND YEARID = RECEIPT_YEARID WHERE RECEIPT_YEARID = " & YearId, "", "")
                    TEMPDT = OBJCMN.Execute_Any_String("UPDATE JOURNALMASTER SET JOURNAL_REFNO = LEFT(JOURNAL_REFNO, LEN(JOURNAL_REFNO)-1) FROM JOURNALMASTER INNER JOIN TEMPRENUMBERING ON NEWINITIALS = JOURNAL_REFNO AND YEARID = JOURNAL_YEARID WHERE JOURNAL_YEARID = " & YearId, "", "")
                    TEMPDT = OBJCMN.Execute_Any_String("UPDATE ACCMASTER SET ACC_INITIALS = LEFT(ACC_INITIALS, LEN(ACC_INITIALS)-1) WHERE ACC_YEARID = " & YearId & " AND ACC_TYPE = 'RECEIPT' AND ACC_REGTYPE = '" & REGROW("REGABBR") & "'", "", "")
                    TEMPDT = OBJCMN.Execute_Any_String("UPDATE PAYMENTMASTER_DESC SET PAYMENT_BILLINITIALS = LEFT(PAYMENT_BILLINITIALS, LEN(PAYMENT_BILLINITIALS)-1) FROM PAYMENTMASTER_DESC INNER JOIN TEMPRENUMBERING ON NEWINITIALS = PAYMENT_BILLINITIALS AND YEARID = PAYMENT_YEARID  WHERE PAYMENT_YEARID = " & YearId, "", "")
                    TEMPDT = OBJCMN.Execute_Any_String("UPDATE PAYMENTMASTER_GRIDDESC SET PAYMENT_PAYBILLINITIALS = LEFT(PAYMENT_PAYBILLINITIALS, LEN(PAYMENT_PAYBILLINITIALS)-1) FROM PAYMENTMASTER_GRIDDESC INNER JOIN TEMPRENUMBERING ON NEWINITIALS = PAYMENT_PAYBILLINITIALS AND YEARID = PAYMENT_YEARID WHERE PAYMENT_YEARID = " & YearId, "", "")
                    TEMPDT = OBJCMN.Execute_Any_String("UPDATE CREDITNOTEMASTER_BILLDESC SET CN_BILLINITIALS = LEFT(CN_BILLINITIALS, LEN(CN_BILLINITIALS)-1) FROM CREDITNOTEMASTER_BILLDESC INNER JOIN TEMPRENUMBERING ON NEWINITIALS = CN_BILLINITIALS AND YEARID = CN_YEARID  WHERE CN_YEARID = " & YearId, "", "")
                    TEMPDT = OBJCMN.Execute_Any_String("UPDATE DEBITNOTEMASTER_BILLDESC SET DN_BILLINITIALS = LEFT(DN_BILLINITIALS, LEN(DN_BILLINITIALS)-1) FROM DEBITNOTEMASTER_BILLDESC INNER JOIN TEMPRENUMBERING ON NEWINITIALS = DN_BILLINITIALS AND YEARID = DN_YEARID  WHERE DN_YEARID = " & YearId, "", "")
                    TEMPDT = OBJCMN.Execute_Any_String("UPDATE MANUALMATCHING_DESC SET MATCH_BILLINITIALS = LEFT(MATCH_BILLINITIALS, LEN(MATCH_BILLINITIALS)-1) FROM MANUALMATCHING_DESC INNER JOIN TEMPRENUMBERING ON NEWINITIALS = MATCH_BILLINITIALS AND YEARID = MATCH_YEARID  WHERE MATCH_YEARID = " & YearId, "", "")
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PAYMENT_RENUM_Click(sender As Object, e As EventArgs) Handles PAYMENT_RENUM.Click
        Try

            If InputBox("Enter Master Password", "ZALANI") <> "Infosys@123" Then
                MsgBox("Invalid Password")
                Exit Sub
            End If

            If MsgBox("You are about to Renumber Entries, Please Take Backup First, Wish to Proceed?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            If MsgBox("Wish To Renumber Payment Entries?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then PAYMENTRENUMBERING()
            MsgBox("Re-Numbering Done Successfully")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub PAYMENTRENUMBERING()
        Try
            'RENUMBER JOUNRAL VOUCHER FIRST
            Dim OBJCMN As New ClsCommon
            Dim DTREGISTER As DataTable = OBJCMN.SEARCH("REGISTER_ID AS REGID, REGISTER_NAME AS REGNAME, REGISTER_ABBR AS REGABBR, REGISTER_INITIALS AS REGINITIALS", "", " REGISTERMASTER ", " AND REGISTER_TYPE = 'PAYMENT' AND REGISTER_YEARID = " & YearId)
            If DTREGISTER.Rows.Count > 0 Then
                For Each REGROW As DataRow In DTREGISTER.Rows

                    'SEARCH ENTRY IN THIS REGISTER AND ADD IN TEMP TABLE
                    'FROM THIS TEMPTABLE WE WILL UPDATE THE ENTRIES
                    'WE WILL UPDATE THE ENTRYIES FROM THEIR OLDINITIALS, AND REPLACE WITH NEW INITIALS
                    'BUT NEW INITIALS WILL CONTAIN A SPECIAL CHARACTER SO THAT WE CAN DISTINGUISH BETWEEN OLD AND NEW INITIALS\
                    'ONCE ALL ENTRIES ARE UPDATED WE WILL REMOVE THAT SPECIAL CHARACTER
                    Dim DTENTRY As DataTable = OBJCMN.SEARCH("DISTINCT  PAYMENT_NO AS OLDNO, PAYMENT_registerid AS REGID, PAYMENT_DATE AS DATE, PAYMENT_initials AS OLDINITIALS, PAYMENT_yearid AS YEARID ", "", " PAYMENTMASTER ", " AND PAYMENT_registerid = " & REGROW("REGID") & " AND PAYMENT_YEARID = " & YearId & " ORDER BY PAYMENT_registerid, PAYMENT_date, PAYMENT_no")
                    Dim NEWBILLNO As Integer = 1
                    Dim TEMPDT As DataTable = OBJCMN.Execute_Any_String("DELETE FROM TEMPRENUMBERING WHERE YEARID = " & YearId, "", "")
                    For Each DTROW As DataRow In DTENTRY.Rows
                        TEMPDT = OBJCMN.Execute_Any_String("INSERT INTO TEMPRENUMBERING VALUES (" & DTROW("REGID") & ",'" & Format(Convert.ToDateTime(DTROW("DATE")).Date, "MM/dd/yyyy") & "'," & DTROW("YEARID") & "," & DTROW("OLDNO") & ",'" & DTROW("OLDINITIALS") & "'," & NEWBILLNO & ",'" & REGROW("REGINITIALS") & "-" & NEWBILLNO & "N')", "", "")

                        'UPDATE IN PAYMENT MASTER
                        TEMPDT = OBJCMN.Execute_Any_String("UPDATE PAYMENTMASTER SET PAYMENT_NO = " & NEWBILLNO & ", PAYMENT_INITIALS = '" & REGROW("REGINITIALS") & "-" & NEWBILLNO & "N' WHERE PAYMENT_INITIALS = '" & DTROW("OLDINITIALS") & "' AND PAYMENT_YEARID = " & YearId, "", "")
                        TEMPDT = OBJCMN.Execute_Any_String("UPDATE PAYMENTMASTER_DESC SET PAYMENT_NO = " & NEWBILLNO & ", PAYMENT_INITIALS = '" & REGROW("REGINITIALS") & "-" & NEWBILLNO & "N' WHERE PAYMENT_INITIALS = '" & DTROW("OLDINITIALS") & "' AND PAYMENT_YEARID = " & YearId, "", "")
                        TEMPDT = OBJCMN.Execute_Any_String("UPDATE PAYMENTMASTER_GRIDDESC SET PAYMENT_NO = " & NEWBILLNO & ", PAYMENT_INITIALS = '" & REGROW("REGINITIALS") & "-" & NEWBILLNO & "N' WHERE PAYMENT_INITIALS = '" & DTROW("OLDINITIALS") & "' AND PAYMENT_YEARID = " & YearId, "", "")


                        'UPDATE IN JOURNALMASTER
                        TEMPDT = OBJCMN.Execute_Any_String("UPDATE JOURNALMASTER SET JOURNAL_REFNO = '" & REGROW("REGINITIALS") & "-" & NEWBILLNO & "N' WHERE JOURNAL_REFNO = '" & DTROW("OLDINITIALS") & "' AND JOURNAL_YEARID = " & YearId, "", "")

                        'UPDATE IN ACCMASTER 
                        TEMPDT = OBJCMN.Execute_Any_String("UPDATE ACCMASTER SET ACC_BILLNO = " & NEWBILLNO & ",ACC_INITIALS = '" & REGROW("REGINITIALS") & "-" & NEWBILLNO & "N' WHERE ACC_INITIALS = '" & DTROW("OLDINITIALS") & "' AND ACC_YEARID = " & YearId, "", "")


                        'UPDATE IN RECEIPTMASTER 
                        TEMPDT = OBJCMN.Execute_Any_String("UPDATE RECEIPTMASTER_DESC SET RECEIPT_BILLINITIALS = '" & REGROW("REGINITIALS") & "-" & NEWBILLNO & "N' WHERE RECEIPT_BILLINITIALS = '" & DTROW("OLDINITIALS") & "' AND RECEIPT_YEARID = " & YearId, "", "")
                        TEMPDT = OBJCMN.Execute_Any_String("UPDATE RECEIPTMASTER_GRIDDESC SET RECEIPT_PAYBILLINITIALS = '" & REGROW("REGINITIALS") & "-" & NEWBILLNO & "N' WHERE RECEIPT_PAYBILLINITIALS = '" & DTROW("OLDINITIALS") & "' AND RECEIPT_YEARID = " & YearId, "", "")


                        'UPDATE IN CREDITNOTEMASTER_BILLDESC
                        TEMPDT = OBJCMN.Execute_Any_String("UPDATE CREDITNOTEMASTER_BILLDESC SET CN_BILLINITIALS = '" & REGROW("REGINITIALS") & "-" & NEWBILLNO & "N' WHERE CN_BILLINITIALS = '" & DTROW("OLDINITIALS") & "' AND CN_YEARID = " & YearId, "", "")

                        'UPDATE IN DEBITNOTEMASTER_BILLDESC
                        TEMPDT = OBJCMN.Execute_Any_String("UPDATE DEBITNOTEMASTER_BILLDESC SET DN_BILLINITIALS = '" & REGROW("REGINITIALS") & "-" & NEWBILLNO & "N' WHERE DN_BILLINITIALS = '" & DTROW("OLDINITIALS") & "' AND DN_YEARID = " & YearId, "", "")

                        'UPDATE IN MANUALMATCHING_DESC
                        TEMPDT = OBJCMN.Execute_Any_String("UPDATE MANUALMATCHING_DESC SET MATCH_BILLINITIALS = '" & REGROW("REGINITIALS") & "-" & NEWBILLNO & "N' WHERE MATCH_BILLINITIALS = '" & DTROW("OLDINITIALS") & "' AND MATCH_YEARID = " & YearId, "", "")


                        NEWBILLNO += 1
                    Next

                    'REMOVE SPECIAL CHARACTER FROM INTIIALS
                    TEMPDT = OBJCMN.Execute_Any_String("UPDATE PAYMENTMASTER SET PAYMENT_INITIALS = LEFT(PAYMENT_INITIALS, LEN(PAYMENT_INITIALS)-1) FROM PAYMENTMASTER INNER JOIN TEMPRENUMBERING ON NEWINITIALS = PAYMENT_INITIALS AND YEARID = PAYMENT_YEARID  WHERE PAYMENT_YEARID = " & YearId, "", "")
                    TEMPDT = OBJCMN.Execute_Any_String("UPDATE PAYMENTMASTER_DESC SET PAYMENT_INITIALS = LEFT(PAYMENT_INITIALS, LEN(PAYMENT_INITIALS)-1) FROM PAYMENTMASTER_DESC INNER JOIN TEMPRENUMBERING ON NEWINITIALS = PAYMENT_INITIALS AND YEARID = PAYMENT_YEARID  WHERE PAYMENT_YEARID = " & YearId, "", "")
                    TEMPDT = OBJCMN.Execute_Any_String("UPDATE PAYMENTMASTER_GRIDDESC SET PAYMENT_INITIALS = LEFT(PAYMENT_INITIALS, LEN(PAYMENT_INITIALS)-1) FROM PAYMENTMASTER_GRIDDESC INNER JOIN TEMPRENUMBERING ON NEWINITIALS = PAYMENT_INITIALS AND YEARID = PAYMENT_YEARID WHERE PAYMENT_YEARID = " & YearId, "", "")
                    TEMPDT = OBJCMN.Execute_Any_String("UPDATE JOURNALMASTER SET JOURNAL_REFNO = LEFT(JOURNAL_REFNO, LEN(JOURNAL_REFNO)-1) FROM JOURNALMASTER INNER JOIN TEMPRENUMBERING ON NEWINITIALS = JOURNAL_REFNO AND YEARID = JOURNAL_YEARID WHERE JOURNAL_YEARID = " & YearId, "", "")
                    TEMPDT = OBJCMN.Execute_Any_String("UPDATE ACCMASTER SET ACC_INITIALS = LEFT(ACC_INITIALS, LEN(ACC_INITIALS)-1) WHERE ACC_YEARID = " & YearId & " AND ACC_TYPE = 'PAYMENT' AND ACC_REGTYPE = '" & REGROW("REGABBR") & "'", "", "")
                    TEMPDT = OBJCMN.Execute_Any_String("UPDATE RECEIPTMASTER_DESC SET RECEIPT_BILLINITIALS = LEFT(RECEIPT_BILLINITIALS, LEN(RECEIPT_BILLINITIALS)-1) FROM RECEIPTMASTER_DESC INNER JOIN TEMPRENUMBERING ON NEWINITIALS = RECEIPT_BILLINITIALS AND YEARID = RECEIPT_YEARID  WHERE RECEIPT_YEARID = " & YearId, "", "")
                    TEMPDT = OBJCMN.Execute_Any_String("UPDATE RECEIPTMASTER_GRIDDESC SET RECEIPT_PAYBILLINITIALS = LEFT(RECEIPT_PAYBILLINITIALS, LEN(RECEIPT_PAYBILLINITIALS)-1) FROM RECEIPTMASTER_GRIDDESC INNER JOIN TEMPRENUMBERING ON NEWINITIALS = RECEIPT_PAYBILLINITIALS AND YEARID = RECEIPT_YEARID WHERE RECEIPT_YEARID = " & YearId, "", "")
                    TEMPDT = OBJCMN.Execute_Any_String("UPDATE CREDITNOTEMASTER_BILLDESC SET CN_BILLINITIALS = LEFT(CN_BILLINITIALS, LEN(CN_BILLINITIALS)-1) FROM CREDITNOTEMASTER_BILLDESC INNER JOIN TEMPRENUMBERING ON NEWINITIALS = CN_BILLINITIALS AND YEARID = CN_YEARID  WHERE CN_YEARID = " & YearId, "", "")
                    TEMPDT = OBJCMN.Execute_Any_String("UPDATE DEBITNOTEMASTER_BILLDESC SET DN_BILLINITIALS = LEFT(DN_BILLINITIALS, LEN(DN_BILLINITIALS)-1) FROM DEBITNOTEMASTER_BILLDESC INNER JOIN TEMPRENUMBERING ON NEWINITIALS = DN_BILLINITIALS AND YEARID = DN_YEARID  WHERE DN_YEARID = " & YearId, "", "")
                    TEMPDT = OBJCMN.Execute_Any_String("UPDATE MANUALMATCHING_DESC SET MATCH_BILLINITIALS = LEFT(MATCH_BILLINITIALS, LEN(MATCH_BILLINITIALS)-1) FROM MANUALMATCHING_DESC INNER JOIN TEMPRENUMBERING ON NEWINITIALS = MATCH_BILLINITIALS AND YEARID = MATCH_YEARID  WHERE MATCH_YEARID = " & YearId, "", "")
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub STORESPOADD_Click(sender As Object, e As EventArgs) Handles STORESPOADD.Click
        Try
            Dim OBJPROFORMA As New StoresPurchaseOrder
            OBJPROFORMA.MdiParent = Me
            OBJPROFORMA.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub STORESPOEDIT_Click(sender As Object, e As EventArgs) Handles STORESPOEDIT.Click
        Try
            Dim OBJPROFORMA As New StoresPurchaseOrderDetails
            OBJPROFORMA.MdiParent = Me
            OBJPROFORMA.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub STORESPOCLOSE_Click(sender As Object, e As EventArgs) Handles STORESPOCLOSE.Click
        Try
            Dim OBJSTORES As New StoresPurchaseOrderClose
            OBJSTORES.MdiParent = Me
            OBJSTORES.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TRANSFERSTORESADD_Click(sender As Object, e As EventArgs) Handles TRANSFERSTORESADD.Click
        Try
            Dim OBJSTORES As New InterGodownTransferStores
            OBJSTORES.MdiParent = Me
            OBJSTORES.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TRANSFERSTORESEDIT_Click(sender As Object, e As EventArgs) Handles TRANSFERSTORESEDIT.Click
        Try
            Dim OBJSTORES As New InterGodownTransferStoresDetails
            OBJSTORES.MdiParent = Me
            OBJSTORES.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SendMailToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SendMailToolStripMenuItem1.Click
        Try
            Dim OBJMAIL As New E_Mail
            OBJMAIL.MdiParent = Me
            OBJMAIL.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BLOCKDATASTOCKTRANSFER_Click(sender As Object, e As EventArgs) Handles BLOCKDATASTOCKTRANSFER.Click
        Try
            Dim OBJBLOCK As New BlockDataTransfer
            OBJBLOCK.MdiParent = Me
            OBJBLOCK.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        Try
            Dim objCategory As New CategoryMaster
            objCategory.frmString = "PORTMASTER"
            objCategory.MdiParent = Me
            objCategory.Show()
            objCategory.BringToFront()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditeExistingPortToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditeExistingPortToolStripMenuItem.Click
        Try
            Dim objCategory As New CategoryDetails
            objCategory.FRMSTRING = "PORTMASTER"
            objCategory.MdiParent = Me
            objCategory.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub AddNewUnitConversionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddNewUnitConversionToolStripMenuItem.Click
        Try
            Dim objUNITC As New UnitConversion
            objUNITC.frmString = "UNIT"
            objUNITC.MdiParent = Me
            objUNITC.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub EditExistingUnitConversionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditExistingUnitConversionToolStripMenuItem.Click
        Try
            Dim objUNITC As New UnitConversionDetails
            'objUNITC.frmString = "UNIT"
            objUNITC.MdiParent = Me
            objUNITC.Show()
        Catch ex As Exception
            If ErrHandle(ex.Message.GetHashCode) = False Then Throw ex
        End Try
    End Sub

    Private Sub AddNewOperatorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddNewOperatorToolStripMenuItem.Click
        Try
            Dim objCategory As New CategoryMaster
            objCategory.frmString = "OPERATORMASTER"
            objCategory.MdiParent = Me
            objCategory.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingOperatorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditExistingOperatorToolStripMenuItem.Click
        Try
            Dim objCategory As New CategoryDetails
            objCategory.FRMSTRING = "OPERATORMASTER"
            objCategory.MdiParent = Me
            objCategory.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewQCToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddNewQCToolStripMenuItem.Click
        Try
            Dim objCategory As New CategoryMaster
            objCategory.FRMSTRING = "QCPARAMETERMASTER"
            objCategory.MdiParent = Me
            objCategory.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingQCToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditExistingQCToolStripMenuItem.Click
        Try
            Dim objCategory As New CategoryDetails
            objCategory.FRMSTRING = "QCPARAMETERMASTER"
            objCategory.MdiParent = Me
            objCategory.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewNonInvItemMasterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddNewNonInvItemMasterToolStripMenuItem.Click
        Try
            Dim OBJSTOCK As New StoreItemMaster
            OBJSTOCK.MdiParent = Me
            OBJSTOCK.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingNonInvItemMasterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditExistingNonInvItemMasterToolStripMenuItem.Click
        Try
            Dim OBJSTOCK As New StoreItemDetails
            OBJSTOCK.MdiParent = Me
            OBJSTOCK.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewJOForPEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JOPEADD.Click
        Try
            Dim OBJJO As New JobOrderForPE
            OBJJO.MdiParent = Me
            OBJJO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PURRETCHALLANADD_Click(sender As Object, e As EventArgs) Handles PURRETCHALLANADD.Click
        Try
            Dim OBJQC As New PurchaseReturnChallan
            OBJQC.MdiParent = Me
            OBJQC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PURRETCHALLANEDIT_Click(sender As Object, e As EventArgs) Handles PURRETCHALLANEDIT.Click
        Try
            Dim OBJQC As New PurchaseReturnChallanDetails
            OBJQC.MdiParent = Me
            OBJQC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingJOForPEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JOPEEDIT.Click
        Try
            Dim OBJJO As New JobOrderForPEDetails
            OBJJO.MdiParent = Me
            OBJJO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewJOForLaminationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JOLAMINATIONADD.Click
        Try
            Dim OBJJO As New JobOrderForLamination
            OBJJO.MdiParent = Me
            OBJJO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingJOForLaminationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JOLAMINATIONEDIT.Click
        Try
            Dim OBJJO As New JobOrderForLaminationDetails
            OBJJO.MdiParent = Me
            OBJJO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewJOForSlittingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JOSLITTINGADD.Click
        Try
            Dim OBJJO As New JobOrderForSlitting
            OBJJO.MdiParent = Me
            OBJJO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingJOForSlittingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JOSLITTINGEDIT.Click
        Try
            Dim OBJJO As New JobOrderForSlittingDetails
            OBJJO.MdiParent = Me
            OBJJO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewOpeningJOForPEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddNewOpeningJOForPEToolStripMenuItem.Click
        Try
            Dim OBJJO As New JobOpeningOrderForPE
            OBJJO.MdiParent = Me
            OBJJO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingOpeningJOForPEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditExistingOpeningJOForPEToolStripMenuItem.Click
        Try
            Dim OBJJO As New JobOpeningOrderForPEDetails
            OBJJO.MdiParent = Me
            OBJJO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewOpeningJOForLaminationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddNewOpeningJOForLaminationToolStripMenuItem.Click
        Try
            Dim OBJJO As New JobOpeningForLamination
            OBJJO.MdiParent = Me
            OBJJO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingOpeningJOForLaminationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditExistingOpeningJOForLaminationToolStripMenuItem.Click
        Try
            Dim OBJJO As New JobOpeningForLaminationDetails
            OBJJO.MdiParent = Me
            OBJJO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewOpeningJOForSlittingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddNewOpeningJOForSlittingToolStripMenuItem.Click
        Try
            Dim OBJJO As New JobOpeningForSlitting
            OBJJO.MdiParent = Me
            OBJJO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingOpeningJOForSlittingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditExistingOpeningJOForSlittingToolStripMenuItem.Click
        Try
            Dim OBJJO As New JobOpeningForSlittingDetails
            OBJJO.MdiParent = Me
            OBJJO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles STOREPURRETURNADD.Click
        Try
            Dim OBJQC As New PurReturnToParty
            OBJQC.MdiParent = Me
            OBJQC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingEntryToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles STOREPURRETURNEDIT.Click
        Try
            Dim OBJQC As New PurReturnToPartyDetails
            OBJQC.MdiParent = Me
            OBJQC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub IssueNewProductToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PRODISSADD.Click
        Try
            Dim OBJQC As New ProdIssue
            OBJQC.MdiParent = Me
            OBJQC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingIssueProductToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PRODISSEDIT.Click
        Try
            Dim OBJQC As New ProdIssueDetails
            OBJQC.MdiParent = Me
            OBJQC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles STORECONSUMPTIONRETADD.Click
        Try
            Dim OBJSTORE As New StoreConsumptionReturn
            OBJSTORE.MdiParent = Me
            OBJSTORE.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingEntryToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles STORECONSUMPTIONRETEDIT.Click
        Try
            Dim OBJSTORE As New StoreConsumptionReturnDetails
            OBJSTORE.MdiParent = Me
            OBJSTORE.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PROFORMASALECLOSE_Click(sender As Object, e As EventArgs) Handles PROFORMASALECLOSE.Click
        Try
            Dim OBJPROFORM As New ProformaInvoiceClose
            OBJPROFORM.MdiParent = Me
            OBJPROFORM.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewOpeningToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddNewOpeningToolStripMenuItem.Click
        Try
            Dim OBJPROFORM As New OpeningProformaInvoice
            OBJPROFORM.MdiParent = Me
            OBJPROFORM.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingProformaInvoiceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditExistingProformaInvoiceToolStripMenuItem.Click
        Try
            Dim OBJPROFORM As New OpeningProformaInvoiceDetails
            OBJPROFORM.MdiParent = Me
            OBJPROFORM.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub JobOrderShortCloseLaminationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JOLAMINATIONCLOSE.Click
        Try
            Dim objjob As New JobOrderShortClose
            objjob.FRMSTRING = "CLOSELAMINATION"
            objjob.MdiParent = Me
            objjob.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub JobOrderShortCloseSlittingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JOSLITTINGCLOSE.Click
        Try
            Dim objjob As New JobOrderShortClose
            objjob.FRMSTRING = "CLOSESLITTING"
            objjob.MdiParent = Me
            objjob.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub JobOrderShortCloseToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles JOPECLOSE.Click
        Try
            Dim objjob As New JobOrderShortClose
            objjob.FRMSTRING = "CLOSEPE"
            objjob.MdiParent = Me
            objjob.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRNCHECKINGADD_Click(sender As Object, e As EventArgs) Handles GRNCHECKINGADD.Click
        Try
            Dim OBJQC As New QualityCheck
            OBJQC.MdiParent = Me
            OBJQC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRNCHECKINGEDIT_Click(sender As Object, e As EventArgs) Handles GRNCHECKINGEDIT.Click
        Try
            Dim OBJQC As New QualityCheckDetails
            OBJQC.MdiParent = Me
            OBJQC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GRNCHECKING_TOOL_Click(sender As Object, e As EventArgs) Handles GRNCHECKING_TOOL.Click
        Try
            Dim OBJQC As New QualityCheck
            OBJQC.MdiParent = Me
            OBJQC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewEntryToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PRODRECADD.Click
        Try
            Dim OBJQC As New ProdReceived
            OBJQC.MdiParent = Me
            OBJQC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingEntryToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles PRODRECEDIT.Click
        Try
            Dim OBJQC As New ProdReceivedDetails
            OBJQC.MdiParent = Me
            OBJQC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewPackingSlipToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PSADD.Click
        Try
            Dim OBJQC As New PackingSlip
            OBJQC.MdiParent = Me
            OBJQC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewLabelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LABELADD.Click
        Try
            Dim OBJQC As New LabelingDepartment
            OBJQC.MdiParent = Me
            OBJQC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewEntryToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles FINALQCADD.Click
        Try
            Dim OBJQC As New FinalQualityCheck
            OBJQC.MdiParent = Me
            OBJQC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingEntryToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles FINALQCEDIT.Click
        Try
            Dim OBJQC As New FinalQualityCheckDetails
            OBJQC.MdiParent = Me
            OBJQC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingLabelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LABELEDIT.Click
        Try
            Dim OBJQC As New LabelingDepartmentDetail
            OBJQC.MdiParent = Me
            OBJQC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CloseMultipleOpeningProformaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseMultipleOpeningProformaToolStripMenuItem.Click
        Try
            Dim OBJPROFORM As New ProformaInvoiceClose
            OBJPROFORM.MdiParent = Me
            OBJPROFORM.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OpeninJobOrderShortClosePEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpeninJobOrderShortClosePEToolStripMenuItem.Click
        Try
            Dim objjob As New JobOrderShortClose
            objjob.FRMSTRING = "CLOSEPE"
            objjob.MdiParent = Me
            objjob.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OpeninJobOrderShortCloseSlittingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpeninJobOrderShortCloseSlittingToolStripMenuItem.Click
        Try
            Dim objjob As New JobOrderShortClose
            objjob.FRMSTRING = "CLOSESLITTING"
            objjob.MdiParent = Me
            objjob.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub OpeninJobOrderShortCloseLaminationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpeninJobOrderShortCloseLaminationToolStripMenuItem.Click
        Try
            Dim objjob As New JobOrderShortClose
            objjob.FRMSTRING = "CLOSELAMINATION"
            objjob.MdiParent = Me
            objjob.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewEntryToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles AddNewEntryToolStripMenuItem.Click
        Try
            Dim OBJPROFORM As New InvoiceMaster
            OBJPROFORM.MdiParent = Me
            OBJPROFORM.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditExistingEntryToolStripMenuItem.Click
        Try
            Dim OBJPROFORM As New InvoiceMasterDetails
            OBJPROFORM.MdiParent = Me
            OBJPROFORM.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub AddNewEntryToolStripMenuItem1_Click_1(sender As Object, e As EventArgs) Handles MATREQADD.Click
        Try
            Dim OBJQC As New MaterialRequirement
            OBJQC.MdiParent = Me
            OBJQC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub EditExistingEntryToolStripMenuItem1_Click_1(sender As Object, e As EventArgs) Handles MATREQEDIT.Click
        Try
            Dim OBJQC As New MaterialRequirementDetails
            OBJQC.MdiParent = Me
            OBJQC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PSEDIT_Click(sender As Object, e As EventArgs) Handles PSEDIT.Click
        Try
            Dim OBJPS As New PackingSlipDetails
            OBJPS.MdiParent = Me
            OBJPS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub JOPE_TOOL_Click(sender As Object, e As EventArgs) Handles JOPE_TOOL.Click
        Try
            Dim OBJJO As New JobOrderForPE
            OBJJO.MdiParent = Me
            OBJJO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub JOLAMINATION_TOOL_Click(sender As Object, e As EventArgs) Handles JOLAMINATION_TOOL.Click
        Try
            Dim OBJJO As New JobOrderForLamination
            OBJJO.MdiParent = Me
            OBJJO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub JOSLITTING_TOOL_Click(sender As Object, e As EventArgs) Handles JOSLITTING_TOOL.Click
        Try
            Dim OBJJO As New JobOrderForSlitting
            OBJJO.MdiParent = Me
            OBJJO.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PRODISS_TOOL_Click(sender As Object, e As EventArgs) Handles PRODISS_TOOL.Click
        Try
            Dim OBJISS As New ProdIssue
            OBJISS.MdiParent = Me
            OBJISS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PRODREC_TOOL_Click(sender As Object, e As EventArgs) Handles PRODREC_TOOL.Click
        Try
            Dim OBJREC As New ProdReceived
            OBJREC.MdiParent = Me
            OBJREC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FINALQC_TOOL_Click(sender As Object, e As EventArgs) Handles FINALQC_TOOL.Click
        Try
            Dim OBJQC As New FinalQualityCheck
            OBJQC.MdiParent = Me
            OBJQC.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LABELLING_TOOL_Click(sender As Object, e As EventArgs) Handles LABELLING_TOOL.Click
        Try
            Dim OBJLABEL As New LabelingDepartment
            OBJLABEL.MdiParent = Me
            OBJLABEL.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PS_TOOL_Click(sender As Object, e As EventArgs) Handles PS_TOOL.Click
        Try
            Dim OBJPS As New PackingSlip
            OBJPS.MdiParent = Me
            OBJPS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MATREQ_TOOL_Click(sender As Object, e As EventArgs) Handles MATREQ_TOOL.Click
        Try
            Dim OBJMATREQ As New MaterialRequirement
            OBJMATREQ.MdiParent = Me
            OBJMATREQ.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub STORESTOCKREPORT_MASTER_Click(sender As Object, e As EventArgs) Handles STORESTOCKREPORT_MASTER.Click
        Try
            Dim OBJSTORE As New StoreStockFilter
            OBJSTORE.MdiParent = Me
            OBJSTORE.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub StockDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StockDetailsToolStripMenuItem.Click
        Try
            Dim OBJSTOCK As New StockDetails
            OBJSTOCK.MdiParent = Me
            OBJSTOCK.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SALE_TOOL_Click_1(sender As Object, e As EventArgs) Handles SALE_TOOL.Click
        Try
            Dim OBJPS As New InvoiceMaster
            OBJPS.MdiParent = Me
            OBJPS.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class

