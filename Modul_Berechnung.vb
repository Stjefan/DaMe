Option Strict Off

Module Modul_Berechnung
    'Public Function Get_Messeinheit() As Byte
    '    Return 3
    'End Function

    Public Function Is_MaxKriterium_VF_RQ(ByVal bDauer As Boolean, ByVal startH As Integer) As String 'ByVal tME As Byte, 
        ' Daten_einlesen() -> in Sub RUN wird es erledigt, sobald neues File vorhanden
        Dim tAus As Auswertung_Data = Auswertung
        If bDauer Then tAus = AuswertungDAUERND

        'Dim tMaxPegel As MaximalPegelME_Data = Maximalpegel.Max_ME1
        'Select Case tME
        '    Case 2
        '        tMaxPegel = Maximalpegel.Max_ME2
        '    Case 3
        '        tMaxPegel = Maximalpegel.Max_ME3
        'End Select

        'Dim iMax_VF As Integer = tMaxPegel.GNacht_MAX_VF
        'Dim iMax_RQ As Integer = tMaxPegel.GNacht_MAX_RQ
        'Dim iMax_VF_aktuell As Single = tAus.Nachtzeitraum_0.MaxVF
        'Dim iMax_RQ_aktuell As Single = tAus.Nachtzeitraum_0.MaxRQ
        Dim tmpZR As Beurteilungszeitraum_Data = tAus.Nachtzeitraum_0
        If startH = 6 Then
            tmpZR = tAus.Tagzeitraum
            'iMax_VF = tMaxPegel.GTag_MAX_VF
            'iMax_RQ = tMaxPegel.GTag_MAX_RQ
            'iMax_VF_aktuell = tAus.Tagzeitraum.MaxVF
            'iMax_RQ_aktuell = tAus.Tagzeitraum.MaxRQ
        ElseIf startH = 1 Then
            tmpZR = tAus.Nachtzeitraum_1
            'iMax_VF_aktuell = tAus.Nachtzeitraum_1.MaxVF
            'iMax_RQ_aktuell = tAus.Nachtzeitraum_1.MaxRQ
        ElseIf startH = 2 Then
            tmpZR = tAus.Nachtzeitraum_2
            'iMax_VF_aktuell = tAus.Nachtzeitraum_2.MaxVF
            'iMax_RQ_aktuell = tAus.Nachtzeitraum_2.MaxRQ
        ElseIf startH = 3 Then
            tmpZR = tAus.Nachtzeitraum_3
            'iMax_VF_aktuell = tAus.Nachtzeitraum_3.MaxVF
            'iMax_RQ_aktuell = tAus.Nachtzeitraum_3.MaxRQ
        ElseIf startH = 4 Then
            tmpZR = tAus.Nachtzeitraum_4
            'iMax_VF_aktuell = tAus.Nachtzeitraum_4.MaxVF
            'iMax_RQ_aktuell = tAus.Nachtzeitraum_4.MaxRQ
        ElseIf startH = 5 Then
            tmpZR = tAus.Nachtzeitraum_5
            'iMax_VF_aktuell = tAus.Nachtzeitraum_5.MaxVF
            'iMax_RQ_aktuell = tAus.Nachtzeitraum_5.MaxRQ
        ElseIf startH = 22 Then
            tmpZR = tAus.Nachtzeitraum_22
            'iMax_VF_aktuell = tAus.Nachtzeitraum_22.MaxVF
            'iMax_RQ_aktuell = tAus.Nachtzeitraum_22.MaxRQ
        ElseIf startH = 23 Then
            tmpZR = tAus.Nachtzeitraum_23
            'iMax_VF_aktuell = tAus.Nachtzeitraum_23.MaxVF
            'iMax_RQ_aktuell = tAus.Nachtzeitraum_23.MaxRQ
        End If

        'Dim bVf As Boolean = IIf(iMax_VF <= iMax_VF_aktuell, True, False)
        'Dim bRQ As Boolean = IIf(iMax_RQ <= iMax_RQ_aktuell, True, False)

        Return CStr(tmpZR.bMaxVF) & ";" & CStr(tmpZR.bMaxRQ)

    End Function

    'Public Function Get_ProzentAngabe(ByVal bDauer As Boolean, ByVal iRestZeitME_Sek As Integer, ByVal Jahr As Integer, _
    '        ByVal Monat As Integer, ByVal Tag As Integer, ByVal btME As Byte, ByVal btEreignis As Byte, ByVal startH As Integer) As Single

    '    Dim Pc As Single = CSng(Get_LetzterPegel_tVerst_BeurtZR(bDauer, startH, btME, btEreignis).Split(";")(0))
    '    Dim GW As Single = Get_Grenzwert_ME(bDauer, iRestZeitME_Sek, Jahr, Monat, Tag, startH, btME)

    '    Dim prozAngabe As Single = CInt(100 * 10 ^ (Pc * 0.1) / 10 ^ (GW * 0.1))
    '    If GW = 0 And Pc = 0 Then prozAngabe = 0

    '    Return prozAngabe

    'End Function
    'Public Function Get_LetzterPegel_tVerst_BeurtZR(ByVal bDauer As Boolean, ByVal startH As Integer, ByVal btME As Byte, ByVal btEreignis As Byte) As String
    '    '1=vf,2=rq,3=ges
    '    Dim TB As Integer = 3600 '57600
    '    If startH = 6 Then TB = 57600

    '    'Für Bestimmung Grenzwert-Messstelle: Pc->letzter Pegel, tVerstr-> bis dahin verstrichene Zeit in Sek
    '    Dim Pc As Single = 0
    '    Dim tVerstr As Integer = 0
    '    Dim tAus As ArrayList = Auswertung
    '    If bDauer Then tAus = AuswertungDAUERND

    '    If tAus.Count > 0 Then
    '        'Herausfinden, welcher index der angegebenen gewünschten Zeit entspricht
    '        Dim i As Integer = CInt(startH * 60 / 5) '* 60
    '        'entweder 1 Stunde darstellen mit 12 DS oder 16 Stunden darstellen mit 192 DS: TB/300
    '        'For i5Min As Integer = CInt(TB / 300) - 1 To 0 Step -1

    '        Dim i5Min As Integer = CInt(TB / 300) - 1
    '        Do While i5Min >= 0 'CInt(TB / 300)
    '            'Dim iLen As Integer = 0

    '            Dim tmpStr As String() = tAus(i + i5Min).ToString.Split(Chr(59))
    '            If tmpStr(btEreignis) = "" Then
    '                Pc = 0
    '            Else
    '                Pc = CSng(tmpStr(btEreignis).Replace(".", ","))
    '            End If
    '            tVerstr = (i5Min + 1) * 300

    '            If tAus(i + i5Min).ToString <> "" And Pc > 0 Then Exit Do
    '            i5Min = i5Min - 1
    '        Loop
    '        'Next
    '    End If

    '    Return Pc & ";" & tVerstr
    'End Function
    'Public Function Get_Grenzwert_ME_neu(ByVal startH As Integer, ByVal bDauer As Boolean) As Single
    '    'Der Grenzwert über die Prognoserechnung anhand der letzten eingegangenen Pegel wird wie folgt bestimmt:
    '    'Lr,VF/RQ,prog = 10 * log( (TB * 10^(0,1 * Lr_VF/RQ) + n * Sum_Lr_VF/RQ_prog) / TB)
    '    'aus Lr_VF_prog und Lr_RQ_prog dann den Lr_ges_prog bestimmen -> = GW
    '    Dim TB As Integer = 3600
    '    If startH = 6 Then TB = 57600

    '    Dim Lr_VF_prog As Single = 0
    '    Dim Lr_RQ_prog As Single = 0
    '    Dim Lr_Ges_prog As Single = 0

    '    'AUS_IO#_...: iCol_RestTyp = 13 -> 1/4h-Werte, iCol_RestTyp = 12 -> 5-Min-Werte... -> n
    '    'AUS_ME#_...: Spalte 2 -> LrVF, Spalte 3 -> LrRQ
    '    'AUS_ME#_...: Spalte 7 und 8 -> Sum_Lr_VF/RQ_ME_prog5, Spalte 9 und 10 -> Sum_Lr_VF/RQ_ME_prog15

    '    Dim tmpZeitraum As Beurteilungszeitraum_Data = Auswertung.Nachtzeitraum_0
    '    If bDauer Then tmpZeitraum = AuswertungDAUERND.Nachtzeitraum_0

    '    Select Case startH
    '        Case 1
    '            If bDauer Then
    '                tmpZeitraum = AuswertungDAUERND.Nachtzeitraum_1
    '            Else
    '                tmpZeitraum = Auswertung.Nachtzeitraum_1
    '            End If
    '        Case 2
    '            If bDauer Then
    '                tmpZeitraum = AuswertungDAUERND.Nachtzeitraum_2
    '            Else
    '                tmpZeitraum = Auswertung.Nachtzeitraum_2
    '            End If
    '        Case 3
    '            If bDauer Then
    '                tmpZeitraum = AuswertungDAUERND.Nachtzeitraum_3
    '            Else
    '                tmpZeitraum = Auswertung.Nachtzeitraum_3
    '            End If
    '        Case 4
    '            If bDauer Then
    '                tmpZeitraum = AuswertungDAUERND.Nachtzeitraum_4
    '            Else
    '                tmpZeitraum = Auswertung.Nachtzeitraum_4
    '            End If
    '        Case 5
    '            If bDauer Then
    '                tmpZeitraum = AuswertungDAUERND.Nachtzeitraum_5
    '            Else
    '                tmpZeitraum = Auswertung.Nachtzeitraum_5
    '            End If
    '        Case 6
    '            If bDauer Then
    '                tmpZeitraum = AuswertungDAUERND.Tagzeitraum
    '            Else
    '                tmpZeitraum = Auswertung.Tagzeitraum
    '            End If
    '        Case 22
    '            If bDauer Then
    '                tmpZeitraum = AuswertungDAUERND.Nachtzeitraum_22
    '            Else
    '                tmpZeitraum = Auswertung.Nachtzeitraum_22
    '            End If
    '        Case 23
    '            If bDauer Then
    '                tmpZeitraum = AuswertungDAUERND.Nachtzeitraum_23
    '            Else
    '                tmpZeitraum = Auswertung.Nachtzeitraum_23
    '            End If
    '    End Select

    '    With tmpZeitraum
    '        Dim strZeile() As String = tmpZeitraum.Pegel(.iRowIX).split(";")

    '        Dim n As Integer = .Restlaufzeit / ((iCol_RestTyp * 2 - 21) * 300) 'falls 5-min-werte iCol_RestTyp=11, 15-min-werte iCol_RestTyp=12
    '        Dim lr_vf As Single = strZeile(1)
    '        Dim lr_rq As Single = strZeile(2)
    '        Dim Sum_Lr_VF_prog As Single = strZeile(6)
    '        Dim Sum_Lr_RQ_prog As Single = strZeile(7)

    '        Lr_VF_prog = 10 * Math.Log10((TB * 10 ^ (0.1 * lr_vf) + n * Sum_Lr_VF_prog) / TB)
    '        Lr_RQ_prog = 10 * Math.Log10((TB * 10 ^ (0.1 * lr_rq) + n * Sum_Lr_RQ_prog) / TB)
    '    End With

    '    'Beurteilungspegel Prognose gesamt
    '    If Lr_VF_prog > 0 Or Lr_RQ_prog > 0 Then
    '        If Lr_VF_prog > 0 And Lr_RQ_prog > 0 Then
    '            Lr_Ges_prog = 10 * Math.Log10(10 ^ (0.1 * Lr_VF_prog) + 10 ^ (0.1 * Lr_RQ_prog))
    '        ElseIf Lr_VF_prog > 0 Then
    '            Lr_Ges_prog = Lr_VF_prog
    '        ElseIf Lr_RQ_prog > 0 Then
    '            Lr_Ges_prog = Lr_RQ_prog
    '        End If
    '    End If
    '    Return Lr_Ges_prog
    'End Function
    'Public Function Get_Grenzwert_ME(ByVal bDauer As Boolean, ByVal tRestME As Integer, ByVal Jahr As Integer, ByVal Monat As Integer, ByVal Tag As Integer, ByVal startH As Integer, ByVal btME As Byte) As Single
    '    'Dim tRestME As Integer = Get_Restlaufzeit_Sekunden_ME(Jahr, Monat, Tag, startH, btME)
    '    'letzen Pegel LrGes
    '    Dim tAr As String() = Get_LetzterPegel_tVerst_BeurtZR(bDauer, startH, btME, 3).Split(";")

    '    Dim Pc As Single = CSng(tAr(0))
    '    Dim tVerst As Integer = CInt(tAr(1))

    '    'Grenzwert der Messstelle bestimmen
    '    Dim GW As Single = 0 '
    '    If tVerst > 0 Then GW = CSng(Pc * (1 + (tRestME / tVerst)))

    '    Return GW
    'End Function
    Public Function Get_minRest_Messeinheit_iX(ByVal Jahr As Integer, ByVal Monat As Integer, ByVal Tag As Integer, ByVal startH As Integer) As String
        Try
            'Daten_IO_einlesen()

            Dim tME As Byte = 0
            Dim tRest As Integer = 86401 '3600
            Dim ix As Integer = 84
            Dim prozVF As Single = 0
            Dim prozRQ As Single = 0
            Dim prozGes As Single = 0

            Select Case startH
                Case 0, 1, 2, 3, 4, 5, 22, 23
                    ix = (startH + 1) * 12
                Case Else
                    ix = 264
            End Select

            If Not IsNothing(Immissionsort) Then
                'Dim tIO_IX As Integer = 0
                For IO_IX As Integer = 0 To Immissionsort.Length - 1
                    'Immissionsort mit kleinster Restlaufzeit ermitteln
                    Dim tRlz As String = Get_RestlaufzeitSek_iX_ME_IO(Jahr, Monat, Tag, startH, IO_IX)
                    If tRlz.Split(";").Length > 1 Then
                        Dim tIO As String() = tRlz.Split(";")
                        If prozGes <= CInt(tIO(5)) Then
                            'If tRest > CInt(tIO(0)) Then
                            tRest = CInt(tIO(0))
                            ix = CInt(tIO(1))
                            tME = CByte(tIO(2)) 'tME = btMessstelle
                            prozVF = CSng(tIO(3))
                            prozRQ = CSng(tIO(4))
                            prozGes = CSng(tIO(5))
                            'tIO_IX = IO_IX
                        End If
                    ElseIf tRlz = "False" Then
                        Return "False"
                    End If
                Next

                Return tRest & ";" & tME & ";" & ix & ";" & prozVF & ";" & prozRQ & ";" & prozGes
            Else
                Return tRest & ";1;" & ix & ";0;0;0"
            End If

        Catch ex As Exception
            Return "False"
        End Try

    End Function
    Public Function Get_RestlaufzeitSek_iX_ME_IO(ByVal iYear As Integer, ByVal iMonth As Integer, ByVal iDay As Integer, ByVal startH As Integer, ByVal IO_IX As Integer) As String
        Try

            Dim tME As Byte = 0
            Dim tRest As Integer = 86400 '3600

            If IsNothing(Immissionsort) Then Daten_einlesen()
            If Not IsNothing(Immissionsort) Then
                Dim GW_IO As Integer = Immissionsort(IO_IX).GNacht_IO
                Dim prozVF As Single = 0
                Dim prozRQ As Single = 0
                Dim prozGes As Single = 0

                Dim ix As Integer = 84
                Select Case startH
                    Case 0, 1, 2, 3, 4, 5, 22, 23
                        ix = (startH + 1) * 12
                    Case Else
                        ix = 264
                        GW_IO = Immissionsort(IO_IX).GTag_IO
                End Select
                Dim jjjjmmtt As String = iYear & "_" & _
                        IIf(CStr(iMonth).Length = 1, "0" & CStr(iMonth), CStr(iMonth)).ToString & "_" & _
                        IIf(CStr(iDay).Length = 1, "0" & iDay, iDay).ToString

                Dim fil As IO.FileInfo = New IO.FileInfo(My.Settings.PfadZielordner & "\" & jjjjmmtt & "\AUS_IO" & Immissionsort(IO_IX).ID & "_" & jjjjmmtt & ".csv")

                If fil.Exists Then
                    'If Immissionsort(IO_IX).ID = 3 And startH = 6 Then
                    '    MsgBox("stop", MsgBoxStyle.OkOnly)
                    'End If
                    'Me.Label_Meldung.visible = True
                    Dim alle As String() = System.IO.File.ReadAllLines(fil.FullName)

                    Dim i As Integer = ix 'startH * 12
                    For i = ix To startH * 12 + 2 Step -1
                        If alle(i) <> "" Then If alle(i).Split(";")(iCol_RestTyp) <> "" Then Exit For
                    Next
                    ix = i

                    If alle(ix) <> "" Then
                        Dim tAlle() As String = alle(ix).Split(";")

                        If tAlle(iCol_RestTyp) <> "" Then
                            tRest = CInt(tAlle(iCol_RestTyp))   '** Restlaufzeit am IO IO_IX
                            'Dim tmpZaehler As Single = 10 ^ (0.1 * CSng(tAlle(4)))
                            'Dim tmpNenner As Single = 10 ^ (0.1 * GW_IO)

                            Dim tVF As Single = CSng(tAlle(4))
                            Dim tRQ As Single = CSng(tAlle(8))
                            Dim tGes As Single = CSng(tAlle(9))

                            If tVF > 0 Then prozVF = 100 * (10 ^ (0.1 * tVF) - 1) / (10 ^ (0.1 * GW_IO) - 1)
                            If tRQ > 0 Then prozRQ = 100 * (10 ^ (0.1 * tRQ) - 1) / (10 ^ (0.1 * GW_IO) - 1)
                            If tGes > 0 Then prozGes = 100 * (10 ^ (0.1 * tGes) - 1) / (10 ^ (0.1 * GW_IO) - 1)
                        End If

                        '** Bestimmung der Messeinheit mit dem größten Anteil am Pegel am IO IO_IX
                        Dim tMax As Single = 0
                        For iME As Byte = 1 To 3
                            Dim tCast1 As Single = 0
                            If tAlle(iME) <> "" Then tCast1 = CSng(tAlle(iME))
                            Dim tCast2 As Single = 0
                            If tAlle(iME) <> "" Then tCast2 = CSng(tAlle(iME + 4))
                            Dim tMEPeg As Single = Get_energSumme(tCast1, tCast2) 'CSng(tAlle(iME)), CSng(tAlle(iME + 4)))
                            If tMEPeg > tMax Then
                                tMax = tMEPeg
                                tME = iME
                            End If
                        Next
                    End If

                End If
                Return tRest & ";" & ix & ";" & tME & ";" & prozVF & ";" & prozRQ & ";" & prozGes
            Else
                Return "False"
            End If
        Catch ex As Exception
            Return "False"
        End Try
    End Function

    Function Get_energSumme(ByVal Pegel() As Single) As Single
        Dim sumPeg As Single = 0
        For iPeg As Integer = 0 To Pegel.Length - 1
            If Pegel(iPeg) > 0 Then sumPeg = sumPeg + 10 ^ (0.1 * Pegel(iPeg))
        Next

        If sumPeg > 1 Then
            Return 10 * Math.Log10(sumPeg)
        Else
            Return 0
        End If
    End Function
    Function Get_energSumme(ByVal Pegel1 As Single, ByVal pegel2 As Single) As Single
        Dim tAr(1) As Single
        tAr(0) = Pegel1
        tAr(1) = pegel2

        Return Get_energSumme(tAr)
    End Function
End Module
