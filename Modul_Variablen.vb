Module Modul_Variablen
    'Public bAktuallisieren As New Class_Aktuallisieren

    Public Const DownloadPfad As String = "\\Notebook-pc\svantek_sv200\Messdaten\Daten_KuFi\" '"G:\8\86\861\8615\Programm\04_Testumbegung\" '
    'Public Const Messeinheit1 As String = "SV 200_26831\"

    Public Const Messtelle1 As String = "SV 200_26867" 'BAU 73
    Public Const Messtelle2 As String = "SV 200_26866" 'BAU 11 Wetterstation
    Public Const Messtelle3 As String = "SV 200_26868" 'BAU 50

    Public Const iCol_RestTyp As Integer = 11   '12 1/4h-Werte   '11 5-Min-Werte     '10 ku

    Public selectedDate As Date
    Public selectedME As Byte

#Region "Immissionsort"
    Public Structure Vorbeifahrt_Data
        Public bVF As Boolean
        Public A As Double
        Public B As Double
        Public C As Double
        Public D As Double
        Public E As Double
        Public bBed2 As Boolean
        Public Bed2 As Integer
        Public A_Bed2 As Double
        Public B_Bed2 As Double
        Public C_Bed2 As Double
        Public D_Bed2 As Double
        Public E_Bed2 As Double
        Public bBed3 As Boolean
        Public Bed3 As Integer
        Public A_Bed3 As Double
        Public B_Bed3 As Double
        Public C_Bed3 As Double
        Public D_Bed3 As Double
        Public E_Bed3 As Double
    End Structure

    Public Structure MaximalPegelME_Data
        Public GTag_MAX_VF As Integer
        Public GNacht_MAX_VF As Integer
        Public GTag_MAX_RQ As Integer
        Public GNacht_MAX_RQ As Integer

    End Structure
    Public Structure MaximalPegel_Data

        Public Max_ME1 As MaximalPegelME_Data
        Public Max_ME2 As MaximalPegelME_Data
        Public Max_ME3 As MaximalPegelME_Data
    End Structure
    Public Maximalpegel As MaximalPegel_Data

    Public Structure Immissionsort_Data
        Public ID As Integer

        <VBFixedString(100)> Public Bezeichnung As String
        Public gk As GKVector2d

        Public bRuhezeit As Boolean

        Public GTag_IO As Integer
        Public GNacht_IO As Integer

        Public ME1_VF As Vorbeifahrt_Data
        Public ME2_VF As Vorbeifahrt_Data
        Public ME3_VF As Vorbeifahrt_Data

        Public btME_RQ As Byte
        Public RQ_A As Double
        Public RQ_B As Double
        Public RQ_C As Double
        Public RQ_D As Double
        Public RQ_E As Double

        Public bME2_RQ As Boolean
        Public RQ_ME2_A As Double
        Public RQ_ME2_B As Double
        Public RQ_ME2_C As Double
        Public RQ_ME2_D As Double
        Public RQ_ME2_E As Double


    End Structure
    Public Immissionsort() As Immissionsort_Data
#End Region

    Public Structure Allgemein_Data
        'Public Schwellen As Schwellen_Data
        Public Stand As Date

        'Public archivMonate As Integer
        'Public archivPfad As String

        'Public bAutoMonatsbericht As Boolean

        'Public SMTP As String
        'Public LoginName As String
        'Public Passwort As String
        'Public Sender As String
        'Public bWochenende As Boolean
        'Public Sendeintervall As Integer

        'Public Max_Verteiler As Integer '# Verteiler, an den die E-Mails gehen bei einer Max-Pegel-Überschreitung
        'Public Max_Sperrung_tags As Integer
        'Public Max_Sperrung_nachts As Integer
        'Public Max_Sperrung_Mitteilung As String

        'Public Fehler_Verteiler As Integer

        'Public Verteiler() As String 'List(Of String)

        'Public Schwellen_RK() As Schwellen_Data 'Rundkurs
        'Public Schwellen_SP() As Schwellen_Data 'Skidpad

    End Structure
    Public Allgemein As Allgemein_Data
    'Public Schwellen() As Schwellen_Data

    'Public Structure Schwellen_Data
    '    Public bSperrung As Boolean 'As List(Of Boolean)
    '    Public Verteiler As Integer 'List(Of Integer)
    '    Public Mitteilung As String
    '    Public H0 As Integer 'List(Of Integer)
    '    Public H1 As Integer 'List(Of Integer)
    '    Public H2 As Integer 'List(Of Integer)
    '    Public H3 As Integer 'List(Of Integer)
    '    Public H4 As Integer 'List(Of Integer)
    '    Public H5 As Integer 'List(Of Integer)
    '    Public H6 As Integer 'List(Of Integer)
    '    Public H7 As Integer 'List(Of Integer)
    '    Public H8 As Integer 'List(Of Integer)
    '    Public H9 As Integer 'List(Of Integer)
    '    Public H10 As Integer 'List(Of Integer)
    '    Public H11 As Integer 'List(Of Integer)
    '    Public H12 As Integer 'List(Of Integer)
    '    Public H13 As Integer 'List(Of Integer)
    '    Public H14 As Integer 'List(Of Integer)
    '    Public H15 As Integer 'List(Of Integer)
    '    Public H16 As Integer 'List(Of Integer)
    '    Public H17 As Integer 'List(Of Integer)
    '    Public H18 As Integer 'List(Of Integer)
    '    Public H19 As Integer 'List(Of Integer)
    '    Public H20 As Integer 'List(Of Integer)
    '    Public H21 As Integer 'List(Of Integer)
    '    Public H22 As Integer 'List(Of Integer)
    '    Public H23 As Integer 'List(Of Integer)
    'End Structure

    Public Structure FrequenzDS_Data

        Public f20 As Single
        Public f25 As Single
        Public f31_5 As Single
        Public f40 As Single
        Public f50 As Single
        Public f63 As Single
        Public f80 As Single
        Public f100 As Single
        Public f125 As Single
        Public f160 As Single
        Public f200 As Single
        Public f250 As Single
        Public f315 As Single
        Public f400 As Single
        Public f500 As Single
        Public f630 As Single
        Public f800 As Single
        Public f1000 As Single
        Public f1250 As Single
        Public f1600 As Single
        Public f2000 As Single
        Public f2500 As Single
        Public f3150 As Single
        Public f4000 As Single
        Public f5000 As Single
        Public f6300 As Single
        Public f8000 As Single
        Public f10000 As Single
        Public f12500 As Single
        Public f16000 As Single
        Public f20000 As Single

    End Structure

#Region "Messwerte-Definitionen"

    Public Wetter As New ArrayList() 'String() 'Wetter_Data
    Public MainResults As New ArrayList() 'String 'MainResults_Data

    Public Auswertung As Auswertung_Data 'New ArrayList() 'String 'Auswertung_Data
    Public AuswertungDAUERND As Auswertung_Data
    Public AuswertungMonat As Auswertung_Data
    Public AuswertungUEBER As Auswertung_Data

    Public Structure Auswertung_Data
        Dim Tagzeitraum As Beurteilungszeitraum_Data
        Dim Nachtzeitraum_0 As Beurteilungszeitraum_Data
        Dim Nachtzeitraum_1 As Beurteilungszeitraum_Data
        Dim Nachtzeitraum_2 As Beurteilungszeitraum_Data
        Dim Nachtzeitraum_3 As Beurteilungszeitraum_Data
        Dim Nachtzeitraum_4 As Beurteilungszeitraum_Data
        Dim Nachtzeitraum_5 As Beurteilungszeitraum_Data
        Dim Nachtzeitraum_22 As Beurteilungszeitraum_Data
        Dim Nachtzeitraum_23 As Beurteilungszeitraum_Data
    End Structure

    Public Structure Beurteilungszeitraum_Data
        'Dim GW_ME As Single
        Dim prozVF As Single
        Dim prozRQ As Single
        Dim prozGes As Single
        Dim Restlaufzeit As Integer
        Dim Messeinhei As Byte
        Dim iRowIX As Integer 'Zeile der Restlaufzeit in Datei AUS_IO#.. -> gleiche Zeile in Datei AUS_ME#... gesucht
        Dim bMaxVF As Boolean
        Dim bMaxRQ As Boolean
        Dim GW As Single

        Dim Pegel As ArrayList
    End Structure

    Public Structure Frequenzen_Data
        Public iTimeCol As Integer
        Public f20Col As Single
        Public f25Col As Single
        Public f31_5Col As Single
        Public f40Col As Single
        Public f50Col As Single
        Public f63Col As Single
        Public f80Col As Single
        Public f100Col As Single
        Public f125Col As Single
        Public f160Col As Single
        Public f200Col As Single
        Public f250Col As Single
        Public f315Col As Single
        Public f400Col As Single
        Public f500Col As Single
        Public f630Col As Single
        Public f800Col As Single
        Public f1000Col As Single
        Public f1250Col As Single
        Public f1600Col As Single
        Public f2000Col As Single
        Public f2500Col As Single
        Public f3150Col As Single
        Public f4000Col As Single
        Public f5000Col As Single
        Public f6300Col As Single
        Public f8000Col As Single
        Public f10000Col As Single
        Public f12500Col As Single
        Public f16000Col As Single
        Public f20000Col As Single

        Public Arry As String()

    End Structure
    Public Frequenzen As Frequenzen_Data

#End Region

#Region "Diagramm"
    Public Structure Diagramm_Data
        Public Zeit As Date
        Public Wert As Single
    End Structure

    Public Structure Diagramme

        Public Name As String
        Public Messstelle As String

    End Structure

    Public MS1() As Diagramme
#End Region

#Region "Messpunkte"
    Public Structure Messpunkt_Data
        Public GK As GKVector2d
    End Structure
    Public Messpunkt(2) As Messpunkt_Data
    Public IOrt(4) As Messpunkt_Data
#End Region

#Region "Karte"
    'Public Structure Karten_Data
    Public Name As String
    'Public bStatus_Georef As Boolean

    Public Const GKR_A As Single = 3492500.0                             'Gauss-Krüger-Rechts-Koordinate Passpunkt A
    Public Const GKH_A As Single = 5413000.0                             'Gauss-Krüger-Hoch-Koordinate Passpunkt A
    Public Const GKR_B As Single = 3495500.0                              'Gauss-Krüger-Rechts-Koordinate Passpunkt B
    Public Const GKH_B As Single = 5411000.0                             'Gauss-Krüger-Hoch-Koordinate Passpunkt B
    Public Const PX_A As Integer = 170                            'Pixel-X-Koordinate Passpunkt A
    Public Const PY_A As Integer = 256                           'Pixel-Y-Koordinate Passpunkt A
    Public Const PX_B As Integer = 3713                           'Pixel-X-Koordinate Passpunkt B
    Public Const PY_B As Integer = 2620                           'Pixel-Y-Koordinate Passpunkt B
    Public Const IM_X_orig As Short = 4055
    Public Const IM_Y_orig As Short = 3150
    Public Const q_GK_Pixel As Double = 0.84651943789745931
    Public Const alpha_GK_Pixel As Double = -1.5704056255059271
    Public Const q_Pixel_GK As Double = 1.1813077824695293
    Public Const alpha_Pixel_GK As Double = 1.5704056255059269

    Public Const E_OO_Rechts As Double = 3492356.0
    Public Const E_OO_Hoch As Double = 5413217.0
    Public Const E_B_Rechts As Double = 3495789.0
    Public Const E_B_Hoch As Double = 5413218.0
    Public Const E_H_Rechts As Double = 3492357.0
    Public Const E_H_Hoch As Double = 5410550.0
    Public Const E_BH_Rechts As Double = 3495790.0
    Public Const E_BH_Hoch As Double = 5410551.0

    'End Structure

    'Public Karte As Karten_Data

    Public Structure GKVector2d
        'Gauss-Krüger-Koordinaten haben einen Wertebereich von 8 Stellen vor dem Komma und 2 Dezimalstellen -> Double
        Public Hoch As Double
        Public Rechts As Double

        Public Sub New(ByVal Rechts As Double, ByVal Hoch As Double)
            Me.Rechts = Rechts
            Me.Hoch = Hoch
        End Sub

        Public Shared Function Add(ByVal aVektor As GKVector2d, ByVal bVektor As GKVector2d) As GKVector2d
            Dim tmp As GKVector2d
            tmp.Hoch = aVektor.Hoch + bVektor.Hoch
            tmp.Rechts = aVektor.Rechts + bVektor.Rechts
            Return tmp
        End Function

        Public Sub Scale(ByVal dFaktor As Double)
            Me.Hoch = Hoch * dFaktor
            Me.Rechts = Rechts * dFaktor
        End Sub

        Public Shared Function Normale(ByVal nVector As GKVector2d) As GKVector2d
            '10er-Normalenvektor ist der um 90° gedrehte Vektor zu nVector (Länge 10)

            Dim tmp As GKVector2d
            tmp.Rechts = -1 * nVector.Hoch
            tmp.Hoch = nVector.Rechts
            tmp.Scale(1000 / Betrag(tmp))
            Return tmp
        End Function

        Public Shared Function Norm(ByVal Vektor As GKVector2d) As GKVector2d
            Dim dTmp As Double = Betrag(Vektor)
            Dim tmp As GKVector2d

            tmp.Hoch = 1000 * Vektor.Hoch / dTmp
            tmp.Rechts = 1000 * Vektor.Rechts / dTmp
            Return tmp
        End Function

        Public Shared Function Linksrichtung(ByVal Lagepkt As GKVector2d, ByVal pktA As GKVector2d, ByVal pktB As GKVector2d) As Boolean
            Dim rvAB As GKVector2d = Richtungsvektor(pktA, pktB)
            Dim bvAL As GKVector2d = Richtungsvektor(pktA, Lagepkt)

            Dim dTmp As Double = rvAB.Rechts * bvAL.Hoch - bvAL.Rechts * rvAB.Hoch

            If dTmp < 0 Then
                Return False
            Else
                Return True
            End If
        End Function

        Public Shared Function Winkelhalbierende(ByVal Scheitel As GKVector2d, ByVal SchenkelA As GKVector2d, ByVal SchenkelB As GKVector2d) As GKVector2d
            'Die Winkelhalbierende wird berechnet über den Ortsvektor Scheitel und die normierten Richtungsvektoren 
            'rvSA und rvSB vom Scheitel zu den Punkten A und B. Ist rvSA = -rbSB, ist die Winkelhalbierende die Normale zu 
            'rvSB bzw -rvSA. Andernfalls ist die Winkelhalbierende der Vektor rvSA + rvSB. In diesem Fall muss die 
            'Winkelhalbierende außerdem in Linksrichtung der angelegten Trasse gebracht werden.

            Dim tmp As GKVector2d
            Dim rvSA As GKVector2d = Norm(Richtungsvektor(Scheitel, SchenkelA))
            Dim rvSB As GKVector2d = Norm(Richtungsvektor(Scheitel, SchenkelB))
            Dim testVekt As GKVector2d

            tmp.Hoch = rvSA.Hoch + rvSB.Hoch
            tmp.Rechts = rvSA.Rechts + rvSB.Rechts

            If tmp.Hoch = 0 And tmp.Rechts = 0 Then
                tmp = Normale(rvSB)
            Else
                'Herausfinden, auf welche Seite von Pkt A zu Scheitel der berechnete Vektor zeigt
                testVekt.Hoch = Scheitel.Hoch + tmp.Hoch
                testVekt.Rechts = Scheitel.Rechts + tmp.Rechts

                If Linksrichtung(testVekt, SchenkelA, Scheitel) = False Then
                    tmp.Hoch = -tmp.Hoch
                    tmp.Rechts = -tmp.Rechts
                End If
                tmp.Scale(1000 / Betrag(tmp))
            End If

            Return tmp
        End Function

        Public Shared Function Abstand(ByVal aVector As GKVector2d, ByVal bVector As GKVector2d) As Single
            'Abstand zwischen aVector und bVector
            Dim tmp As Single
            tmp = CSng(Math.Sqrt((bVector.Hoch - aVector.Hoch) ^ 2 + (bVector.Rechts - aVector.Rechts) ^ 2))
            Return tmp
        End Function

        Public Shared Function Betrag(ByVal bVector As GKVector2d) As Double
            'Betrag eines Vektors
            Dim tmp As Double
            tmp = Math.Sqrt(bVector.Hoch ^ 2 + bVector.Rechts ^ 2)
            Return tmp
        End Function

        Public Shared Function Richtungsvektor(ByVal first As GKVector2d, ByVal last As GKVector2d) As GKVector2d
            'Richtungsvektor vom Punkt des Ortsvektors first zum Punkte des Ortsvektors last
            Dim tmp As GKVector2d
            tmp.Hoch = last.Hoch - first.Hoch
            tmp.Rechts = last.Rechts - first.Rechts
            Return tmp
        End Function
    End Structure
#End Region
End Module
