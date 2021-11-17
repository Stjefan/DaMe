Option Strict Off
Imports System.IO
Imports System.Text

Module Modul_Datenabfrage
    Public xDoc_Allgemein As System.Xml.XmlDocument

    Public ndAllgemein As XmlNode

    'Private alleZeilen As String()

    Public Const btWetter As Byte = 1
    Public Const btErgebnis As Byte = 2
    Public Const btMax As Byte = 3
    Public Const btOctave As Byte = 4
    Public Const btFrequenzen As Byte = 5
    Public Const btAuswertung As Byte = 6
    Public Const btAuswertungDAUERND As Byte = 7
    Public Const btAuswertungMONAT As Byte = 8
    Public Const btAuswertungUEBER As Byte = 9

    Public Function Get_Himmelsrichtung(ByVal vonZeit As Date) As Integer
        Get_Himmelsrichtung = 170
    End Function


#Region "Set-Fkten: Messwerte in Variablen speichern"
    Public Function Set_Wetter(ByVal vonZeit As Date, ByVal bisZeit As Date) As Boolean 'As Wetter_Data
        Wetter = New ArrayList() 'Nothing
        Return Read_Daten(vonZeit, btWetter, 2) 'Wetter ist nur an Messstelle 2
    End Function
    Public Function Set_Auswertung(ByVal vonZeit As Date) As Boolean 'ByVal bisZeit As Date, 
        'Auswertung = New ArrayList() 'Nothing
        Return Read_Auswertung(vonZeit, btAuswertung)
    End Function
    Public Function Set_AuswertungMonat(ByVal vonZeit As Date) As Boolean
        Return Read_Auswertung(vonZeit, btAuswertungMonat)
    End Function
    Public Function Set_AuswertungDAUERBETRIEB(ByVal vonZeit As Date) As Boolean ', ByVal bisZeit As Date
        'AuswertungDAUERND = New ArrayList
        Return Read_Auswertung(vonZeit, btAuswertungDAUERND)
    End Function
    Public Function Set_AuswertungUEBER(ByVal vonZeit As Date) As Boolean
        Return Read_Auswertung(vonZeit, btAuswertungUEBER)
    End Function
    Public Function Set_MainResults(ByVal vonZeit As Date, ByVal btMessstelle As Byte) As Boolean
        MainResults = New ArrayList() '86400)
        Dim ar(86400) As String
        'ReDim Preserve ar()
        MainResults.AddRange(ar)
        Return Read_Daten(vonZeit, btMax, btMessstelle)
    End Function
    'Public Function Set_Octave(ByVal vonZeit As Date, ByVal bisZeit As Date, ByVal btMessstelle As Byte) As Boolean 'As Octave_Data 
    '    Octave = Nothing
    '    Return Read_Daten(vonZeit, btOctave, btMessstelle)
    'End Function
#End Region


    'Public Sub Daten_Alarm_Speichern()
    '    Daten_Email_Speichern()
    '    Daten_Schwellen_Speichern()
    'End Sub

    'Public Function Daten_Alarm_einlesen() As Boolean
    '    Allgemein = Nothing

    '    If Daten_Email_einlesen() And Daten_Schwellen_einlesen() Then
    '        Allgemein.Stand = Now
    '        Return True
    '    Else
    '        Return False
    '    End If

    'End Function
    
    'Public Function Daten_Schwellen_einlesen() As Boolean
    '    Dim fio As IO.FileInfo = New IO.FileInfo(My.Settings.PfadZielordner & "\SA.DAT")

    '    If fio.Exists = True Then
    '        Try
    '            Dim stFilename As String
    '            Dim RLen As Short

    '            'Daten zu Immissionsorten aus Datei einlesen
    '            '=======================================

    '            Dim Schwellen_Record As Schwellen_Data
    '            Schwellen_Record = Nothing
    '            Dim Schwellen_bRecord As System.ValueType = Schwellen_Record

    '            RLen = CShort(Len(CType(Schwellen_Record, Schwellen_Data)))
    '            stFilename = My.Settings.PfadZielordner & "\SA.DAT"

    '            FileOpen(1, stFilename, OpenMode.Random, , , RLen)

    '            Dim iDS As Integer = 0

    '            Do While Not EOF(1)
    '                FileGet(1, Schwellen_bRecord)
    '                Schwellen_Record = CType(Schwellen_bRecord, Schwellen_Data)
    '                Schwellen(iDS) = Schwellen_Record
    '                iDS = iDS + 1
    '            Loop

    '            FileClose(1)

    '            Return True

    '        Catch ex As Exception
    '            Return False

    '        End Try
    '    Else
    '        Daten_Schwellen_Speichern()
    '    End If
    'End Function
    'Public Sub Daten_Schwellen_Speichern()
    '    Dim stFilename As String
    '    Dim RLen As Short
    '    Dim iDSLaenge As Integer
    '    'Daten zu Maximalpegel in Datei speichern
    '    '=======================================
    '    Dim fil As New IO.FileInfo(My.Settings.PfadZielordner & "\SA.DAT")
    '    If fil.Exists Then fil.Delete()

    '    Dim Schwellen_Record As Schwellen_Data
    '    Schwellen_Record = Nothing

    '    iDSLaenge = 0

    '    RLen = CShort(Len(CType(Schwellen_Record, Schwellen_Data)))
    '    stFilename = My.Settings.PfadZielordner & "\SA.DAT"

    '    FileOpen(1, stFilename, OpenMode.Random, , , RLen)

    '    If Not IsNothing(Schwellen) Then
    '        For iDS As Integer = 0 To Schwellen.Length - 1
    '            Schwellen_Record = Schwellen(iDS)

    '            iDSLaenge = CInt(iDSLaenge + 1)
    '            FilePut(1, Schwellen_Record, iDSLaenge)
    '        Next
    '    End If
    '    FileClose(1)

    'End Sub
 
    Public Sub XML_Create_CalcMes(ByVal datPfad As String)
        'Aufbau:

        '## Tags können KEINE Leerzeichen enthalten!!
        Dim enc As New System.Text.UnicodeEncoding
        Dim XMLobj As Xml.XmlTextWriter
        XMLobj = New Xml.XmlTextWriter(datPfad, enc)
        XMLobj.Formatting = Xml.Formatting.Indented
        XMLobj.Indentation = 4

        XMLobj.WriteStartDocument()
        XMLobj.WriteStartElement("Allgemein")
        XMLobj.WriteAttributeString("archivMonate", "24")
        XMLobj.WriteAttributeString("archivKompressionsLevel", "5")
        XMLobj.WriteAttributeString("archivPfad", "")
        XMLobj.WriteAttributeString("dateiStreckeninfo", "")
        XMLobj.WriteAttributeString("bAutoMonatsbericht", "true")

        XMLobj.WriteAttributeString("SMTP", "")
        XMLobj.WriteAttributeString("LoginName", "")
        XMLobj.WriteAttributeString("Passwort", "")
        XMLobj.WriteAttributeString("Sender", "")
        XMLobj.WriteAttributeString("bWochenende", "false")
        XMLobj.WriteAttributeString("Sendeintervall", "1")
        XMLobj.WriteAttributeString("Test_Verteiler", "1")

        XMLobj.WriteAttributeString("Max_Verteiler", "1")
        XMLobj.WriteAttributeString("Max_Sperrung_tags", "4")
        XMLobj.WriteAttributeString("Max_Sperrung_nachts", "2")
        XMLobj.WriteAttributeString("Max_Sperrung_Mitteilung", "")
        XMLobj.WriteAttributeString("Fehler_Verteiler", "1")

        XMLobj.WriteStartElement("Verteiler")
        XMLobj.WriteEndElement() 'Verteiler

        XMLobj.WriteStartElement("Schwellen_RK")
        XMLobj.WriteEndElement() 'Schwellen Rundkurs

        XMLobj.WriteStartElement("Schwellen_SP")
        XMLobj.WriteEndElement() 'Schwellen Skidpad


        XMLobj.WriteEndElement() 'Allgemein

        XMLobj.WriteEndDocument()
        XMLobj.Close()
    End Sub
    Public Function XML_Add_Verteiler() As XmlNode
        Dim xVerteilerNr As XmlNode = xDoc_Allgemein.CreateElement("VerteilerNr")
        xVerteilerNr.Attributes.Append(xDoc_Allgemein.CreateAttribute("Empfaenger", ""))

        ndAllgemein.Item("Verteiler").AppendChild(xVerteilerNr)

        Return xVerteilerNr
    End Function
    Public Function XML_Add_Schwelle(ByRef ndParent As XmlNode) As XmlNode
        Dim xSchwelle As XmlNode = xDoc_Allgemein.CreateElement("Schwelle")
        xSchwelle.Attributes.Append(XML_Attribut("bSperrung", "false")) 'xDoc_Allgemein.CreateAttribute("bSperrung", "false"))
        xSchwelle.Attributes.Append(XML_Attribut("Verteiler", "1")) 'xDoc_Allgemein.CreateAttribute("Verteiler", ""))
        xSchwelle.Attributes.Append(XML_Attribut("Mitteilung", "")) 'xDoc_Allgemein.CreateAttribute("Mitteilung", ""))
        xSchwelle.Attributes.Append(XML_Attribut("H0", "90")) 'xDoc_Allgemein.CreateAttribute("H0", "90"))
        xSchwelle.Attributes.Append(XML_Attribut("H1", "90")) 'xDoc_Allgemein.CreateAttribute("H1", "90"))
        xSchwelle.Attributes.Append(XML_Attribut("H2", "90")) 'xDoc_Allgemein.CreateAttribute("H2", "90"))
        xSchwelle.Attributes.Append(XML_Attribut("H3", "90")) 'xDoc_Allgemein.CreateAttribute("H3", "90"))
        xSchwelle.Attributes.Append(XML_Attribut("H4", "90")) 'xDoc_Allgemein.CreateAttribute("H4", "90"))
        xSchwelle.Attributes.Append(XML_Attribut("H5", "90")) 'xDoc_Allgemein.CreateAttribute("H5", "90"))
        xSchwelle.Attributes.Append(XML_Attribut("H6", "90")) 'xDoc_Allgemein.CreateAttribute("H6", "90"))
        xSchwelle.Attributes.Append(XML_Attribut("H7", "90")) 'xDoc_Allgemein.CreateAttribute("H7", "90"))
        xSchwelle.Attributes.Append(XML_Attribut("H8", "90")) 'xDoc_Allgemein.CreateAttribute("H8", "90"))
        xSchwelle.Attributes.Append(XML_Attribut("H9", "90")) 'xDoc_Allgemein.CreateAttribute("H9", "90"))
        xSchwelle.Attributes.Append(XML_Attribut("H10", "90")) 'xDoc_Allgemein.CreateAttribute("H10", "90"))
        xSchwelle.Attributes.Append(XML_Attribut("H11", "90")) 'xDoc_Allgemein.CreateAttribute("H11", "90"))
        xSchwelle.Attributes.Append(XML_Attribut("H12", "90")) 'xDoc_Allgemein.CreateAttribute("H12", "90"))
        xSchwelle.Attributes.Append(XML_Attribut("H13", "90")) 'xDoc_Allgemein.CreateAttribute("H13", "90"))
        xSchwelle.Attributes.Append(XML_Attribut("H14", "90")) 'xDoc_Allgemein.CreateAttribute("H14", "90"))
        xSchwelle.Attributes.Append(XML_Attribut("H15", "90")) 'xDoc_Allgemein.CreateAttribute("H15", "90"))
        xSchwelle.Attributes.Append(XML_Attribut("H16", "90")) 'xDoc_Allgemein.CreateAttribute("H16", "90"))
        xSchwelle.Attributes.Append(XML_Attribut("H17", "90")) 'xDoc_Allgemein.CreateAttribute("H17", "90"))
        xSchwelle.Attributes.Append(XML_Attribut("H18", "90")) 'xDoc_Allgemein.CreateAttribute("H18", "90"))
        xSchwelle.Attributes.Append(XML_Attribut("H19", "90")) 'xDoc_Allgemein.CreateAttribute("H19", "90"))
        xSchwelle.Attributes.Append(XML_Attribut("H20", "90")) 'xDoc_Allgemein.CreateAttribute("H20", "90"))
        xSchwelle.Attributes.Append(XML_Attribut("H21", "90")) 'xDoc_Allgemein.CreateAttribute("H21", "90"))
        xSchwelle.Attributes.Append(XML_Attribut("H22", "90")) 'xDoc_Allgemein.CreateAttribute("H22", "90"))
        xSchwelle.Attributes.Append(XML_Attribut("H23", "90")) 'xDoc_Allgemein.CreateAttribute("H23", "90"))

        ndParent.AppendChild(xSchwelle)

        'Daten_Allgemein_Speichern()

        Return xSchwelle
    End Function
    Public Function XML_Attribut(ByVal AName As String, ByVal AValue As String) As XmlAttribute
        Dim xAttribut As XmlAttribute = xDoc_Allgemein.CreateAttribute(AName)
        xAttribut.Value = AValue
        Return xAttribut
    End Function

    Public Sub Daten_Allgemein_Speichern()
        Dim fil As New IO.FileInfo(My.Settings.PfadZielordner & "\All.DAT")
        If fil.Exists Then fil.Delete()

        xDoc_Allgemein.Save(fil.FullName)


        'Daten_Schwellen_Speichern()

        'Dim stFilename As String
        'Dim RLen As Short
        'Dim iDSLaenge As Integer
        ''Daten zu Maximalpegel in Datei speichern
        ''=======================================
        'Dim fil As New IO.FileInfo(My.Settings.PfadZielordner & "\All.DAT")
        'If fil.Exists Then fil.Delete()

        'Dim Allgemein_Record As Allgemein_Data
        'Allgemein_Record = Nothing

        'iDSLaenge = 0

        'RLen = CShort(Len(CType(Allgemein_Record, Allgemein_Data)))
        'stFilename = My.Settings.PfadZielordner & "\All.DAT"

        'FileOpen(1, stFilename, OpenMode.Random, , , RLen)


        'Allgemein_Record = Allgemein
        'iDSLaenge = CInt(iDSLaenge + 1)
        'FilePut(1, Allgemein_Record, iDSLaenge)


        'FileClose(1)

    End Sub

    Public Function Daten_Allgemein_einlesen() As Boolean
        xDoc_Allgemein = New System.Xml.XmlDocument
        Dim fio As IO.FileInfo = New IO.FileInfo(My.Settings.PfadZielordner & "\All.DAT")
        If fio.Exists = False Then XML_Create_CalcMes(fio.FullName)
        Try

            xDoc_Allgemein.Load(fio.FullName)

            Allgemein.Stand = Now

            ndAllgemein = xDoc_Allgemein.Item("Allgemein")

            Return True

        Catch ex As Exception
            MsgBox("Die All.DAT konnte nicht richtig eingelesen werden.", MsgBoxStyle.OkOnly, "Fehler")
            Return False
        End Try

        ''Dim fio As IO.FileInfo = New IO.FileInfo(My.Settings.PfadZielordner & "\All.DAT")

        ''If fio.Exists = True Then
        ''    Try
        ''        Dim stFilename As String
        ''        Dim RLen As Short

        ''        'Daten zu Immissionsorten aus Datei einlesen
        ''        '=======================================

        ''        Dim Alarm_Record As Allgemein_Data
        ''        Alarm_Record = Nothing
        ''        Dim Alarm_bRecord As System.ValueType = Alarm_Record

        ''        RLen = CShort(Len(CType(Alarm_Record, Allgemein_Data)))
        ''        stFilename = My.Settings.PfadZielordner & "\All.DAT"

        ''        FileOpen(1, stFilename, OpenMode.Random, , , RLen)

        ''        'Do While Not EOF(1)
        ''        FileGet(1, Alarm_bRecord)
        ''        Alarm_Record = CType(Alarm_bRecord, Allgemein_Data)
        ''        Allgemein = Alarm_Record
        ''        'Loop

        ''        FileClose(1)

        ''        If Allgemein.Sendeintervall = 0 Then Allgemein.Sendeintervall = 1
        ''        Return True

        ''    Catch ex As Exception
        ''        FileClose(1)
        ''        Return False

        ''    End Try
        ''Else
        ''    Daten_Email_Speichern()
        ''    If Allgemein.Sendeintervall = 0 Then Allgemein.Sendeintervall = 1
        ''End If


    End Function

    Public Function Daten_einlesen() As Boolean
        If Daten_Max_einlesen() Then
            Return Daten_IO_einlesen()
        Else
            Return False
        End If
    End Function
    Public Sub Daten_Max_Speichern()
        Dim stFilename As String
        Dim RLen As Short
        Dim iDSLaenge As Integer
        'Daten zu Maximalpegel in Datei speichern
        '=======================================
        Dim fil As New IO.FileInfo(My.Settings.PfadZielordner & "\MP.DAT")
        If fil.Exists Then fil.Delete()

        Dim MaximalPegel_Record As MaximalPegel_Data
        MaximalPegel_Record = Nothing

        iDSLaenge = 0

        RLen = CShort(Len(CType(MaximalPegel_Record, MaximalPegel_Data)))
        stFilename = My.Settings.PfadZielordner & "\MP.DAT"

        FileOpen(1, stFilename, OpenMode.Random, , , RLen)


        MaximalPegel_Record = Maximalpegel
        iDSLaenge = CInt(iDSLaenge + 1)
        FilePut(1, MaximalPegel_Record, iDSLaenge)


        FileClose(1)

    End Sub
    Public Function Daten_Max_einlesen() As Boolean
        Dim fio As IO.FileInfo = New IO.FileInfo(My.Settings.PfadZielordner & "\MP.DAT")

        If fio.Exists = True Then
            Try
                Dim stFilename As String
                Dim RLen As Short

                'Daten zu Immissionsorten aus Datei einlesen
                '=======================================

                Dim MaximalPegel_Record As MaximalPegel_Data
                MaximalPegel_Record = Nothing
                Dim MaximalPegel_bRecord As System.ValueType = MaximalPegel_Record

                RLen = CShort(Len(CType(MaximalPegel_Record, MaximalPegel_Data)))
                stFilename = My.Settings.PfadZielordner & "\MP.DAT"

                FileOpen(1, stFilename, OpenMode.Random, , , RLen)

                Do While Not EOF(1)
                    FileGet(1, MaximalPegel_bRecord)
                    MaximalPegel_Record = CType(MaximalPegel_bRecord, MaximalPegel_Data)
                    Maximalpegel = MaximalPegel_Record
                Loop

                FileClose(1)
                Return True
                'Catch ex As IO.IOException
                '    'MsgBox("Exception", MsgBoxStyle.OkOnly)
                '    Daten_Max_einlesen()
            Catch ex As Exception
                FileClose(1)
                Return False
                'Form_Haupt.Cursor = Cursors.Default
                'MsgBox("Fehler beim Einlesen der MP-Datei.")
            End Try
        End If

    End Function
    Public Function Daten_IO_einlesen() As Boolean
        Dim fio As IO.FileInfo = New IO.FileInfo(My.Settings.PfadZielordner & "\ES.DAT")

        'If fio.Exists = False Then
        '    MsgBox("Die Datei " & fio.FullName & " kann nicht gefunden werden." & Chr(13) & Chr(10), MsgBoxStyle.OkOnly, "Fehlermeldung")
        'Else
        Try
            Dim stFilename As String
            Dim RLen As Short
            Dim sSA As Short
            'Dim oVekt As vector2d

            'Daten zu Immissionsorten aus Datei einlesen
            '=======================================

            Dim Immissionsort_Record As Immissionsort_Data
            Immissionsort_Record = Nothing
            Dim Immissionsort_bRecord As System.ValueType = Immissionsort_Record


            RLen = CShort(Len(CType(Immissionsort_Record, Immissionsort_Data)))
            stFilename = My.Settings.PfadZielordner & "\ES.DAT"

            FileOpen(1, stFilename, OpenMode.Random, , , RLen)

            sSA = 0

            Do While Not EOF(1)
                'Dim iLen As Integer = 0
                'If Not IsNothing(Immissionsort) Then iLen = Immissionsort.Length
                ReDim Preserve Immissionsort(sSA)

                FileGet(1, Immissionsort_bRecord)
                Immissionsort_Record = CType(Immissionsort_bRecord, Immissionsort_Data)
                Immissionsort(sSA) = Immissionsort_Record

                'Immissionsort(sSA).lfdNummer = CShort(Immissionsort_Record.lfdNummer)
                'Immissionsort(sSA).GK_Vektor.z = CSng(Immissionsort_Record.GK_Vektor.z)
                'Immissionsort(sSA).GK_Vektor.GK.Hoch = Immissionsort_Record.GK_Vektor.GK.Hoch
                'Immissionsort(sSA).GK_Vektor.GK.Rechts = Immissionsort_Record.GK_Vektor.GK.Rechts


                sSA = CShort(sSA + 1)
            Loop

            FileClose(1)
            Return True
            'Catch ex As IO.IOException
            '    'MsgBox("Exception", MsgBoxStyle.OkOnly)
            '    Daten_IO_einlesen()
        Catch ex As Exception
            FileClose(1)
            Return False
            'Form_Haupt.Cursor = Cursors.Default
            'MsgBox("Fehler beim Einlesen der IO-Datei.")
        End Try
        'End If

    End Function
    Public Sub Daten_IO_speichern()
        Try
            Dim stFilename As String
            Dim RLen As Short
            Dim sSA As Short
            Dim iDSLaenge As Integer


            'Daten zu Immissionsort in Datei speichern
            '=======================================
            Dim fil As New IO.FileInfo(My.Settings.PfadZielordner & "\ES.DAT")
            If fil.Exists Then fil.Delete()

            Dim Immissionsort_Record As Immissionsort_Data
            Immissionsort_Record = Nothing

            iDSLaenge = 0

            RLen = CShort(Len(CType(Immissionsort_Record, Immissionsort_Data)))
            stFilename = My.Settings.PfadZielordner & "\ES.DAT"

            FileOpen(1, stFilename, OpenMode.Random, , , RLen)

            For sSA = 0 To Immissionsort.Length - 1 'Max_Immissionsort - 1

                Immissionsort_Record = Immissionsort(sSA)
                iDSLaenge = CInt(iDSLaenge + 1)
                FilePut(1, Immissionsort_Record, iDSLaenge)

            Next sSA

            FileClose(1)
        Catch ex As IO.IOException
            'MsgBox("Exception", MsgBoxStyle.OkOnly)
            Daten_IO_speichern()
        End Try
    End Sub
   
    Public Function Read_Auswertung(ByVal vonZeit As Date, ByVal Type As Byte) As Boolean
        Try

            Dim iYear As Integer = vonZeit.Year
            Dim iMonth As Integer = vonZeit.Month
            Dim iDay As Integer = vonZeit.Day

            '*** Tagesauswertung
            'If Type = btAuswertung Or Type = btAuswertungDAUERND Then
            Dim jjjjmmtt As String = iYear & "_" & _
                        IIf(CStr(iMonth).Length = 1, "0" & CStr(iMonth), CStr(iMonth)).ToString & "_" & _
                        IIf(CStr(iDay).Length = 1, "0" & CStr(iDay), CStr(iDay)).ToString

            If btAuswertungDAUERND = Type Then
                AuswertungDAUERND = Nothing
            ElseIf btAuswertung = Type Then
                Auswertung = Nothing
            ElseIf btAuswertungMonat = Type Then
                AuswertungMonat = Nothing
            ElseIf btAuswertungUEBER = Type Then
                AuswertungUEBER = Nothing
            End If

            Dim tmpAuswertung As Auswertung_Data = Nothing

            '*** Zeiträume durchlaufen
            For i As Integer = 0 To 8
                Dim iStart As Integer = i
                If i = 7 Then iStart = 22
                If i = 8 Then iStart = 23

                Dim tmpZeitraum As Beurteilungszeitraum_Data = Nothing
                With tmpZeitraum
                    ' Tagzeitraum
                    Dim tRest_Ar As String() = Get_minRest_Messeinheit_iX(iYear, iMonth, iDay, iStart).Split(";")

                    If tRest_Ar.Length > 1 Then
                        'Daten aus IO-DAtei
                        .Restlaufzeit = CInt(tRest_Ar(0))
                        'Dim IO_IX As Integer = CInt(tRest_Ar(1))
                        .Messeinhei = CByte(tRest_Ar(1))
                        .iRowIX = CInt(tRest_Ar(2)) '- iStart * 12 'tRest_Ar(2) beinhaltet den Index auf den Tag bezogen,iRow auf den Beurteilungszeitraum
                        .prozVF = round1Dez(CSng(tRest_Ar(3)))
                        .prozRQ = round1Dez(CSng(tRest_Ar(4)))
                        .prozGes = round1Dez(CSng(tRest_Ar(5)))

                        'MaxPegel aus allen ME-Dateien vergleichen
                        Dim tmpBMaxVF As Boolean = False
                        Dim tmpBMaxRQ As Boolean = False
                        For iME As Byte = 1 To 3
                            'Maximalpegel
                            Dim iMax As MaximalPegelME_Data = Maximalpegel.Max_ME1
                            If iME = 2 Then
                                iMax = Maximalpegel.Max_ME2
                            ElseIf iME = 3 Then
                                iMax = Maximalpegel.Max_ME3
                            End If
                            'Grenzwerte welches Zeitraums relevant?
                            Dim iMax_VF As Integer = iMax.GNacht_MAX_VF
                            Dim iMax_RQ As Integer = iMax.GNacht_MAX_RQ
                            If iStart = 6 Then
                                iMax_VF = iMax.GTag_MAX_VF
                                iMax_RQ = iMax.GTag_MAX_RQ
                            End If

                            Dim filME As IO.FileInfo = New IO.FileInfo(My.Settings.PfadZielordner & "\" & jjjjmmtt & _
                                     "\AUS_ME" & iME & "_" & jjjjmmtt & ".csv")
                            If filME.Exists Then
                                Dim tPegel As ArrayList = New ArrayList(System.IO.File.ReadAllLines(filME.FullName))
                                'Maxwerte vergleichen
                                Dim iRow As Integer = (iStart + 1) * 12 '- 1
                                If iStart = 6 Then iRow = 264 '191 '
                                If tPegel(iRow) <> "" Then
                                    If iMax_VF <= CSng(tPegel(iRow).split(Chr(59))(4)) Then tmpBMaxVF = True
                                    If iMax_RQ <= CSng(tPegel(iRow).split(Chr(59))(5)) Then tmpBMaxRQ = True
                                End If
                            End If
                        Next
                        .bMaxVF = tmpBMaxVF
                        .bMaxRQ = tmpBMaxRQ

                        'Pegel aus ME-Datei holen
                        Dim fil As IO.FileInfo = New IO.FileInfo(My.Settings.PfadZielordner & "\" & jjjjmmtt & _
                                    "\AUS_ME" & .Messeinhei & "_" & jjjjmmtt & ".csv")
                        If fil.Exists Then
                            'Pegel auslesen
                            .Pegel = New ArrayList(System.IO.File.ReadAllLines(fil.FullName))

                            'Bereich einschränken
                            Dim iEnde As Integer = 12 * (iStart + 1) + 1
                            If i = 6 Then iEnde = 265
                            If i = 7 Then iEnde = 277
                            If i < 8 Then .Pegel.RemoveRange(iEnde, .Pegel.Count - iEnde) 'Zeile 266 bis Zeile 289 weg
                            .Pegel.RemoveRange(0, iStart * 12 + 1) 'iEnde - 12) 'Zeile 1 bis Zeile 73 weg
                            '.iRowIX = .iRowIX - 1

                            .iRowIX = CInt(tRest_Ar(2)) - iStart * 12 - 1

                            'Grenzwert
                            .GW = 0
                            For iP As Integer = .Pegel.Count - 1 To 0 Step -1
                                Dim thisStr As String() = .Pegel(iP).ToString.Split(Chr(59))
                                Dim letzterPegel As Single = 0
                                If thisStr(3) <> "" Then letzterPegel = CSng(thisStr(3).Replace(".", ","))
                                If letzterPegel > 0 Then
                                    .GW = 10 * Math.Log10((100 * (10 ^ (0.1 * letzterPegel) - 1) / .prozGes) + 1)

                                    Exit For
                                End If
                            Next
                            'If Single.IsInfinity(.GW) Then
                        End If



                        Select Case i
                            Case 0
                                tmpAuswertung.Nachtzeitraum_0 = tmpZeitraum
                            Case 1
                                tmpAuswertung.Nachtzeitraum_1 = tmpZeitraum
                            Case 2
                                tmpAuswertung.Nachtzeitraum_2 = tmpZeitraum
                            Case 3
                                tmpAuswertung.Nachtzeitraum_3 = tmpZeitraum
                            Case 4
                                tmpAuswertung.Nachtzeitraum_4 = tmpZeitraum
                            Case 5
                                tmpAuswertung.Nachtzeitraum_5 = tmpZeitraum
                            Case 6
                                tmpAuswertung.Tagzeitraum = tmpZeitraum
                            Case 7
                                tmpAuswertung.Nachtzeitraum_22 = tmpZeitraum
                            Case 8
                                tmpAuswertung.Nachtzeitraum_23 = tmpZeitraum
                        End Select
                    ElseIf tRest_Ar(0) = "False" Then
                        Return "False"
                    End If
                End With
            Next

            If btAuswertungDAUERND = Type Then
                AuswertungDAUERND = tmpAuswertung
            ElseIf btAuswertung = Type Then
                Auswertung = tmpAuswertung
            ElseIf btAuswertungMonat = Type Then
                AuswertungMonat = tmpAuswertung
            ElseIf btAuswertungUEBER = Type Then
                AuswertungUEBER = tmpAuswertung
            End If

            Return True
        Catch ex As IO.IOException
            Return False
        End Try
    End Function
    Public Function round1Dez(ByVal Zahl As Single) As Single
        Dim strProz As String = Zahl.ToString
        If InStr(strProz, ",") Then
            Dim tmpStr As String() = strProz.Split(",")
            If tmpStr(1).Length > 1 Then
                Dim nachKomma As String = Left(tmpStr(1), 1)
                Dim intZahl As Single = CSng(tmpStr(0) & "," & nachKomma)
                strProz = IIf(CInt(Mid(tmpStr(1), 2, 1)) < 5, intZahl, intZahl + 0.1)
            End If
        End If
        Return CSng(strProz)
    End Function
    'Public Function round2Dez(ByVal Zahl As Single) As Single
    '    Dim strProz As String = Zahl.ToString
    '    If InStr(strProz, ",") Then
    '        Dim tmpStr As String() = strProz.Split(",")
    '        If tmpStr(1).Length > 2 Then
    '            Dim nachKomma As String = Left(tmpStr(1), 2)
    '            strProz = tmpStr(0) & "," & IIf(CInt(Mid(tmpStr(1), 3, 1)) < 5, nachKomma, CInt(nachKomma) + 1)
    '        End If
    '    End If
    '    Return CSng(strProz)
    'End Function
    'Public Function Read_Daten(ByVal vonZeit As Date, ByVal bisZeit As Date, ByVal Type As Byte, ByVal iMessstelle As Integer) As Boolean
    Public Function Read_Daten(ByVal vonZeit As Date, ByVal Type As Byte, ByVal iMessstelle As Integer) As Boolean

        '  alleZeilen = Nothing
        Dim iYear As Integer = vonZeit.Year
        Dim iMonth As Integer = vonZeit.Month
        Dim iDay As Integer = vonZeit.Day

        Dim strME As String = "ME1 - " & Messtelle1

        If iMessstelle = 2 Then
            strME = "ME2 - " & Messtelle2
        ElseIf iMessstelle = 3 Then
            strME = "ME3 - " & Messtelle3
        End If

    
        For iHour As Integer = 0 To 23
            Dim sOrdner As String = ""

            Select Case Type
                Case btWetter
                    sOrdner = "MET\"
                Case btMax
                    sOrdner = "ERG\"
                    'sOrdner = "RES\"
                Case btOctave
                    sOrdner = "OCT\"
            End Select

            
            Dim dir As New IO.DirectoryInfo(My.Settings.PfadZielordner & "\" & iYear & "_" & _
               IIf(CStr(iMonth).Length = 1, "0" & CStr(iMonth), CStr(iMonth)).ToString & "_" & _
               IIf(CStr(iDay).Length = 1, "0" & iDay, iDay).ToString & "\" & strME & "\" & _
               IIf(CStr(iHour).Length = 1, "0" & iHour, iHour).ToString & "\" & _
               sOrdner)

            Dim fil As IO.FileInfo
            If dir.Exists Then
                For Each fil In dir.GetFiles("*.csv")
                    If fil.Name.Split("_").Length > 1 Then
                        Select Case Type
                            Case btWetter
                                'Read_Wetter(vonZeit, bisZeit, fil.FullName)
                                If Read_Wetter(fil.FullName) = False Then
                                    Return False
                                End If
                               
                            Case btMax
                                Dim ar() As String = fil.Name.Split(".")(0).Split("_")
                                If Microsoft.VisualBasic.Left(ar(1), 2) = "ME" Then
                                    If Read_MAXWerte(fil.FullName, ar(5), ar(6)) = False Then
                                        Return False
                                    End If
                                End If

                                'Read_MainResults(vonZeit, bisZeit, fil.FullName)
                                'Case btOctave
                                '    Read_Octave(vonZeit, bisZeit, fil.FullName)
                                'Case btFrequenzen
                                '    Read_Frequenzen(vonZeit, bisZeit, fil.FullName)
                        End Select
                    End If
                Next
            End If
        Next
        'End If
        Return True

    End Function

#Region "Messdaten in Array einlesen"


    'Private Function Read_Frequenzen(ByVal vonZeit As Date, ByVal bisZeit As Date, ByVal sDateiname As String) As Boolean
    '    Try

    '        Dim alleZeilen As String() = System.IO.File.ReadAllLines(sDateiname)
    '        Dim i As Integer
    '        For i = 0 To alleZeilen.Length - 1
    '            If alleZeilen(i) = "1/3 OCTAVE" Then Exit For
    '        Next

    '        'Spalten finden
    '        i = i + 2
    '        Dim tmpZeile() As String = alleZeilen(i).Split(";")
    '        With Frequenzen
    '            For iCol As Integer = 0 To tmpZeile.Length - 1
    '                Select Case tmpZeile(iCol)
    '                    Case "Time"
    '                        .iTimeCol = iCol
    '                    Case "20,0 Hz [dB]"
    '                        .f20Col = iCol
    '                    Case "25,0 Hz [dB]"
    '                        .f25Col = iCol
    '                    Case "31,5 Hz [dB]"
    '                        .f31_5Col = iCol
    '                    Case "40,0 Hz [dB]"
    '                        .f40Col = iCol
    '                    Case "50 Hz [dB]"
    '                        .f50Col = iCol
    '                    Case "63 Hz [dB]"
    '                        .f63Col = iCol
    '                    Case "80 Hz [dB]"
    '                        .f80Col = iCol
    '                    Case "100 Hz [dB]"
    '                        .f100Col = iCol
    '                    Case "125 Hz [dB]"
    '                        .f125Col = iCol
    '                    Case "160 Hz [dB]"
    '                        .f160Col = iCol
    '                    Case "200 Hz [dB]"
    '                        .f200Col = iCol
    '                    Case "250 Hz [dB]"
    '                        .f250Col = iCol
    '                    Case "315 Hz [dB]"
    '                        .f315Col = iCol
    '                    Case "400 Hz [dB]"
    '                        .f400Col = iCol
    '                    Case "500 Hz [dB]"
    '                        .f500Col = iCol
    '                    Case "630 Hz [dB]"
    '                        .f630Col = iCol
    '                    Case "800 Hz [dB]"
    '                        .f800Col = iCol
    '                    Case "1000 Hz [dB]"
    '                        .f1000Col = iCol
    '                    Case "1250 Hz [dB]"
    '                        .f1250Col = iCol
    '                    Case "1600 Hz [dB]"
    '                        .f1600Col = iCol
    '                    Case "2000 Hz [dB]"
    '                        .f2000Col = iCol
    '                    Case "2500 Hz [dB]"
    '                        .f2500Col = iCol
    '                    Case "3150 Hz [dB]"
    '                        .f3150Col = iCol
    '                    Case "4000 Hz [dB]"
    '                        .f4000Col = iCol
    '                    Case "5000 Hz [dB]"
    '                        .f5000Col = iCol
    '                    Case "6300 Hz [dB]"
    '                        .f6300Col = iCol
    '                    Case "8000 Hz [dB]"
    '                        .f8000Col = iCol
    '                    Case "10000 Hz [dB]"
    '                        .f10000Col = iCol
    '                    Case "12500 Hz [dB]"
    '                        .f12500Col = iCol
    '                    Case "16000 Hz [dB]"
    '                        .f16000Col = iCol
    '                    Case "20000 Hz [dB]"
    '                        .f20000Col = iCol
    '                End Select
    '            Next
    '        End With

    '        'Datenzeilen in Array speichern
    '        i = i + 1
    '        For iRow As Integer = i To alleZeilen.Length - 1
    '            tmpZeile = alleZeilen(iRow).Split(";")

    '            If IsDate(tmpZeile(Frequenzen.iTimeCol)) Then
    '                Dim iLen As Integer = 0
    '                If Not IsNothing(Frequenzen.Arry) Then iLen = Frequenzen.Arry.Length
    '                ReDim Preserve Frequenzen.Arry(iLen)

    '                Frequenzen.Arry(iLen) = alleZeilen(iRow)
    '            End If
    '        Next
    '        Return True
    '    Catch ex As IO.IOException
    '        Return False
    '    End Try
    'End Function

    'Private Sub Read_Octave(ByVal vonZeit As Date, ByVal bisZeit As Date, ByVal sDateiname As String)
    '    alleZeilen = System.IO.File.ReadAllLines(sDateiname)
    '    Dim i As Integer
    '    For i = 0 To alleZeilen.Length - 1
    '        If alleZeilen(i) = "1/3 OCTAVE" Then Exit For
    '    Next

    '    'Spalten finden
    '    i = i + 2
    '    Dim tmpZeile() As String = alleZeilen(i).Split(";")
    '    With Octave
    '        For iCol As Integer = 0 To tmpZeile.Length - 1
    '            Select Case tmpZeile(iCol)
    '                Case "Time"
    '                    .iTimeCol = iCol
    '                Case "Total A [dB]"
    '                    .iALeqCol = iCol
    '                Case "Total C [dB]"
    '                    .iCLeqCol = iCol
    '                Case "Total Z [dB]"
    '                    .iZLeqCol = iCol
    '            End Select
    '        Next
    '    End With

    '    'Datenzeilen einlesen
    '    i = i + 1
    '    For iRow As Integer = i To alleZeilen.Length - 1
    '        tmpZeile = alleZeilen(iRow).Split(";")

    '        If IsDate(tmpZeile(Octave.iTimeCol)) Then
    '            Dim iLen As Integer = 0
    '            If Not IsNothing(Octave.Arry) Then iLen = Octave.Arry.Length
    '            ReDim Preserve Octave.Arry(iLen)

    '            Octave.Arry(iLen) = alleZeilen(iRow)
    '        End If
    '    Next
    'End Sub

    'Private Sub Read_MAXWerte(ByVal vonZeit As Date, ByVal bisZeit As Date, ByVal sDateiname As String)
    Private Function Read_MAXWerte(ByVal sDateiname As String, ByVal iHour As Integer, ByVal iMin As Integer) As Boolean
        Try

            Dim alleZeilen As String() = System.IO.File.ReadAllLines(sDateiname) 'String()
            Dim tmpArList As New ArrayList
            tmpArList.AddRange(alleZeilen)
            tmpArList.RemoveAt(0)

            Dim ix As Integer = iHour * 60 * 60 + iMin * 60

            MainResults.InsertRange(ix, tmpArList) '(iRow)

            alleZeilen = Nothing
            tmpArList.Clear()
            Return True
        Catch ex As IO.IOException
            Return False
        End Try
    End Function

    Private Function Read_Wetter(ByVal sDateiname As String) As Boolean
        Try


            Dim alleZeilen As String() = System.IO.File.ReadAllLines(sDateiname)
            Dim tmpArList As New ArrayList
            tmpArList.AddRange(alleZeilen)
            tmpArList.RemoveAt(0)

            Wetter.AddRange(tmpArList)

            'For iRow As Integer = 1 To alleZeilen.Length - 1
            '    Wetter.Add(alleZeilen(iRow))
            'Next


            ' ''Dim i As Integer = 2

            ' ''For iRow As Integer = i To alleZeilen.Length - 1
            ' ''    Dim tmpZeile As String() = alleZeilen(iRow).Split(";")

            ' ''    If IsDate(tmpZeile(0)) Then
            ' ''        'If CDate(tmpZeile(0)) >= vonZeit And CDate(tmpZeile(0)) <= bisZeit Then
            ' ''        Dim iLen As Integer = 0
            ' ''        If Not IsNothing(Wetter) Then iLen = Wetter.Length
            ' ''        ReDim Preserve Wetter(iLen)

            ' ''        Wetter(iLen) = alleZeilen(iRow)
            ' ''        'End If 
            ' ''    Else
            ' ''        'Exit For
            ' ''    End If
            ' ''Next


            alleZeilen = Nothing
            tmpArList.Clear()
            Return True
        Catch ex As IO.IOException
            Return False
        End Try
    End Function

  #End Region


End Module
