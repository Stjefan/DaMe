Option Strict Off
Imports System.Drawing

Public Class UserControl_Gesammtansicht

   
    Private Sub UserControl_Gesammtansicht_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim startD As Date = CDate(Now.Day & "." & Now.Month & "." & Now.Year & " 00:00:00") '#now.month/now.day/now.year 00:00 AM#

        Me.CheckForIllegalCrossThreadCalls = False

        If selectedDate.Year > 1001 Then
            Me.DTP_1.Value = selectedDate
        Else
            Me.DTP_1.Value = Now
        End If

        '    Aktuallisieren(True)
        'Thread, der in bestimmten Intervallen eine Update-Panel_Aktuell ausführt.
    End Sub

    Private Function Get_Kr_mitStunde(ByVal Datum As Date) As Single
        If Datum.DayOfWeek = DayOfWeek.Sunday Or Get_Feiertag(Datum) Then
            If (Datum.Hour >= 6 And Datum.Hour <= 9) Or _
                    (Datum.Hour >= 13 And Datum.Hour <= 15) Or _
                    (Datum.Hour >= 20 And Datum.Hour <= 22) Then
                Return 6
            Else
                Return 0
            End If
        Else
            If (Datum.Hour >= 6 And Datum.Hour <= 7) Or (Datum.Hour >= 20 And Datum.Hour <= 22) Then
                Return 6
            Else
                Return 0
            End If
        End If
    End Function
    Public Function Get_Feiertag(ByVal Datum As Date) As Boolean
        Dim Ostersonntag As Date
        ' Osterfunktion nach Carl Friedrich Gauß (1800). Rückgabewert
        ' ist das Datum des Ostersonntags im angegebenen (ersatzweise:
        ' aktuellen) Jahr. Gültigkeitsbereich: 1583 - 8702 (auf das
        ' Auslösen von Laufzeitfehlern bei Unter- oder Überschreitung
        ' dieses Gültigkeitsbereichs wird hier absichtlich verzichtet).
        Dim a As Integer, b As Integer, c As Integer, d As Integer, e As Integer, f As Integer

        ' Wurde kein Jahr angegeben, wird das aktuelle Jahr verwendet:
        Dim Jahr As Integer = Datum.Year

        ' Die "magische" Gauss-Formel anwenden:
        a = Jahr Mod 19
        b = Jahr \ 100
        c = (8 * b + 13) \ 25 - 2
        d = b - (Jahr \ 400) - 2
        e = (19 * (Jahr Mod 19) + ((15 - c + d) Mod 30)) Mod 30
        If e = 28 Then
            If a > 10 Then
                e = 27
            End If
        ElseIf e = 29 Then
            e = 28
        End If
        f = (d + 6 * e + 2 * (Jahr Mod 4) + 4 * (Jahr Mod 7) + 6) Mod 7

        ' Rückgabewert als Datum bereitstellen
        Ostersonntag = DateSerial(Jahr, 3, e + f + 22)

        '*** Feiertage abhängig vom Ostersonntag ***
        If Ostersonntag = Datum Then Return True 'Ostersonntag
        If Ostersonntag.AddDays(-2) = Datum Then Return True 'Karfreitag
        If Ostersonntag.AddDays(1) = Datum Then Return True 'Ostermontag
        If Ostersonntag.AddDays(39) = Datum Then Return True 'Christi Himmelfahrt
        If Ostersonntag.AddDays(50) = Datum Then Return True 'Pfingstmontag
        If Ostersonntag.AddDays(60) = Datum Then Return True 'Frohenleichnahm
        If Ostersonntag.AddDays(60) = Datum Then Return True 'Frohenleichnahm

        '*** Feiertage fest ***
        If DateSerial(Jahr, 1, 1) = Datum Then Return True 'Neujahr
        If DateSerial(Jahr, 1, 6) = Datum Then Return True 'Hl. Drei Könige
        If DateSerial(Jahr, 5, 1) = Datum Then Return True 'Maifeiertag
        If DateSerial(Jahr, 10, 3) = Datum Then Return True 'Tag der deutschen Einheit
        If DateSerial(Jahr, 11, 1) = Datum Then Return True 'Allerheiligen
        If DateSerial(Jahr, 12, 25) = Datum Then Return True '1. Weihnachtsfeiertag
        If DateSerial(Jahr, 12, 26) = Datum Then Return True '2. Weihnachtsfeiertag
        'Weihnachten und Silvester zählen bei der TA-Lärm zu normalen Werktagen


    End Function

#Region "Eingabeänderungen"
    Private Sub NUD_P_max_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUD_P_max.ValueChanged
        Aktuallisieren(False)
    End Sub
    Private Sub NUD_P_Wertebereich_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUD_P_Wertebereich.ValueChanged
        Aktuallisieren(False)
    End Sub

    Private Sub DTP_1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTP_1.ValueChanged
        selectedDate = Me.DTP_1.Value
        Aktuallisieren(True)
    End Sub
    Private Sub Button_Back_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Back.Click
        Me.DTP_1.Value = Me.DTP_1.Value.AddDays(-1)
    End Sub
    Private Sub Button_Forward_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Forward.Click
        Me.DTP_1.Value = Me.DTP_1.Value.AddDays(1)
    End Sub
#End Region

#Region "Anzeige updaten"
    Public Sub Aktuallisieren(ByVal bTag As Boolean)
        'Wenn sich der Tag verändert hat, dann müssen die Auswertungen neu eingelesen werden (werden immer tageweise eingelesen)
        Me.Label_keineDaten.Visible = False

        If bTag Then
            '*** bei Daten-Änderungen
            If Daten_einlesen() = False Then Exit Sub 'IO und MAX

            If Set_Auswertung(Me.DTP_1.Value) = False Then
                Auswertung = Nothing '.Clear()
                Me.Label_keineDaten.Visible = True
                'Exit Sub
            End If

            Update_Anzeige_Prozent_Max()
        Else
            '*** bei Wertebereich-Änderungen
            Update_DiagrammHintergrund()
        End If

        '*** bei Daten- und Wertebereich-Änderungen
        Update_Diagramme()
    End Sub

    

    Private Sub Update_DiagrammHintergrund()
        Me.Panel_Tagzeitraum.Invalidate()
        Me.Panel_Nachtstunden.Invalidate()
    End Sub
    Private Sub Update_Diagramme()
        Me.PB_3_T.Invalidate()
        Me.PB_3_N0.Invalidate()
        Me.PB_3_N1.Invalidate()
        Me.PB_3_N2.Invalidate()
        Me.PB_3_N3.Invalidate()
        Me.PB_3_N4.Invalidate()
        Me.PB_3_N5.Invalidate()
        Me.PB_3_N22.Invalidate()
        Me.PB_3_N23.Invalidate()
    End Sub
    Private Sub Update_Anzeige_Prozent_Max() '(ByVal bDauernd As Boolean)
        'Dim tmpDate As Date = Me.DTP_1.Value
        Dim tmpAus As Auswertung_Data = Auswertung

        For iZR As Integer = 0 To 8
            Dim tmpZR As Beurteilungszeitraum_Data
            Dim hStart As Integer = iZR
            Select Case iZR
                Case 0
                    tmpZR = tmpAus.Nachtzeitraum_0
                Case 1
                    tmpZR = tmpAus.Nachtzeitraum_1
                Case 2
                    tmpZR = tmpAus.Nachtzeitraum_2
                Case 3
                    tmpZR = tmpAus.Nachtzeitraum_3
                Case 4
                    tmpZR = tmpAus.Nachtzeitraum_4
                Case 5
                    tmpZR = tmpAus.Nachtzeitraum_5
                Case 6
                    tmpZR = tmpAus.Tagzeitraum
                Case 7
                    tmpZR = tmpAus.Nachtzeitraum_22
                    hStart = 22
                Case 8
                    tmpZR = tmpAus.Nachtzeitraum_23
                    hStart = 23
            End Select
            'Steuerelemente des Zeitraums finden
            Dim ctrl_Label_Proz_VF As System.Windows.Forms.Label = Me.Panel_ME3.Controls.Find("Label_Proz_VF_N" & hStart, True)(0)
            Dim ctrl_Label_Proz_RQ As System.Windows.Forms.Label = Me.Panel_ME3.Controls.Find("Label_Proz_RQ_N" & hStart, True)(0)
            Dim ctrl_Label_Proz_Ges As System.Windows.Forms.Label = Me.Panel_ME3.Controls.Find("Label_Proz_Ges_N" & hStart, True)(0)
            Dim ctrl_Label_ME As System.Windows.Forms.Label = Me.Panel_ME3.Controls.Find("Label_ME_" & hStart, True)(0)

            Dim ctrl_P_Max As Panel = Me.Panel_ME3.Controls.Find("P_Max_N" & hStart, True)(0) '0.BackColor = Color.Red
            Dim ctrl_Label_Max As System.Windows.Forms.Label = Me.Panel_ME3.Controls.Find("Label_Max_N" & hStart, True)(0) 'N0

            ctrl_Label_Proz_VF.Text = IIf(tmpZR.prozVF.ToString.Split(",").Length = 1, tmpZR.prozVF & ",0 %", tmpZR.prozVF & " %").ToString
            ctrl_Label_Proz_RQ.Text = IIf(tmpZR.prozRQ.ToString.Split(",").Length = 1, tmpZR.prozRQ & ",0 %", tmpZR.prozRQ & " %").ToString 'tmpZR.prozRQ & " %"
            ctrl_Label_Proz_Ges.Text = IIf(tmpZR.prozGes.ToString.Split(",").Length = 1, tmpZR.prozGes & ",0 %", tmpZR.prozGes & " %").ToString 'tmpZR.prozGes & " %"
            ctrl_Label_ME.Text = "ME " & CStr(IIf(tmpZR.Messeinhei = 0, "", tmpZR.Messeinhei)) 'tmpZR.Messeinheit

            '*** Maximalkriterium ***
            If tmpZR.bMaxVF Or tmpZR.bMaxRQ Then
                ctrl_P_Max.BackColor = Color.Red
                ctrl_Label_Max.Text = IIf(tmpZR.bMaxVF And tmpZR.bMaxRQ, "VF+RQ", IIf(tmpZR.bMaxVF, "VF", IIf(tmpZR.bMaxRQ, "RQ", ""))).ToString
            Else
                ctrl_P_Max.BackColor = Color.Green
                ctrl_Label_Max.Text = "-"
            End If

        Next
    End Sub

#Region "Paint-Events"
    Private Sub Panel_Legende_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel_Legende.Paint
        Dim gr As Graphics = e.Graphics

        gr.DrawLine(Pens.Black, 10, 8, 35, 8)
        gr.DrawLine(Pens.Red, 10, 23, 35, 23)
        gr.DrawLine(Pens.Blue, 10, 38, 35, 38)

        Dim orangePen As New Pen(Color.Orange, 3)
        gr.DrawLine(orangePen, 65, 83, 90, 83)
        'gr.DrawLine(orangePen, 60, 85, 25, 85)

    End Sub

    Private Sub Panel_Tagzeitraum_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel_Tagzeitraum.Paint
        Dim gr As Graphics = e.Graphics
        Dim fnt As New Font("Tahoma", 9, FontStyle.Regular)

        'waagrechte Diagrammlinien
        Dim yMin As Integer = CInt(Me.NUD_P_max.Value - Me.NUD_P_Wertebereich.Value)

        Dim y1 As Integer = yMin
        Dim yD As Integer = 10
        Dim pDiff As Integer = CInt(Me.NUD_P_Wertebereich.Value)
        Dim sizH As Integer = CInt(gr.MeasureString("bla", fnt).Height)

        Dim j As Integer = 0

        'Beschriftung der y-Achsen aller Beurteilungszeiträume
        Do While yMin + j * yD <= Me.NUD_P_max.Value
            Dim CurPeg As Integer = y1 + j * yD
            gr.DrawLine(Pens.Black, Me.PB_3_T.Location.X - 10, CInt(Me.PB_3_T.Location.Y + Me.PB_3_T.Height - j * Me.PB_3_T.Height * yD / pDiff), Me.PB_3_T.Location.X, CInt(Me.PB_3_T.Location.Y + Me.PB_3_T.Height - j * Me.PB_3_T.Height * yD / pDiff))

            gr.DrawString(CurPeg.ToString, fnt, Brushes.Black, Me.PB_3_T.Location.X - 35, CInt(Me.PB_3_T.Location.Y + Me.PB_3_T.Height - (sizH / 2) - j * Me.PB_3_T.Height * yD / pDiff))

            j = j + 1
        Loop

        '279°-gedrehte Beschriftung der Diagramme für "Tagzeitraum" und "lauteste Nachtstunde" 
        Dim fettFont As Font = New Font("Tahoma", 10, FontStyle.Bold)
        Dim mSt As Integer = CInt(gr.MeasureString("Tagzeitraum [dB(A)]", fettFont).Width)
        gr.RotateTransform(270)
        gr.DrawString("Tagzeitraum [dB(A)]", fettFont, Brushes.Black, -Me.PB_3_T.Location.Y - Me.PB_3_T.Height + (Me.PB_3_T.Height - mSt) / 2, 5) ' + Me.PB_3_T.Height / 3, 5) ', 5)'-Me.PB_3_N0.Location.Y - Me.PB_3_N0.Height + Me.PB_3_N0.Height / 7, 5)

    End Sub
    Private Sub Panel_Nachtstunden_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel_Nachtstunden.Paint
        Dim gr As Graphics = e.Graphics
        Dim fnt As New Font("Tahoma", 9, FontStyle.Regular)

        'waagrechte Diagrammlinien
        Dim yMin As Integer = CInt(Me.NUD_P_max.Value - Me.NUD_P_Wertebereich.Value)

        Dim y1 As Integer = yMin
        Dim yD As Integer = 10
        Dim pDiff As Integer = CInt(Me.NUD_P_Wertebereich.Value)
        Dim sizH As Integer = CInt(gr.MeasureString("bla", fnt).Height)

        Dim j As Integer = 0

        'Beschriftung der y-Achsen aller Beurteilungszeiträume
        Do While yMin + j * yD <= Me.NUD_P_max.Value
            Dim CurPeg As Integer = y1 + j * yD
            gr.DrawLine(Pens.Black, Me.PB_3_N0.Location.X - 10, CInt(Me.PB_3_N0.Location.Y + Me.PB_3_T.Height - j * Me.PB_3_T.Height * yD / pDiff), Me.PB_3_N0.Location.X, CInt(Me.PB_3_N0.Location.Y + Me.PB_3_T.Height - j * Me.PB_3_T.Height * yD / pDiff))
            gr.DrawLine(Pens.Black, Me.PB_3_N22.Location.X - 10, CInt(Me.PB_3_N22.Location.Y + Me.PB_3_T.Height - j * Me.PB_3_T.Height * yD / pDiff), Me.PB_3_N22.Location.X, CInt(Me.PB_3_N22.Location.Y + Me.PB_3_T.Height - j * Me.PB_3_T.Height * yD / pDiff))

            gr.DrawString(CurPeg.ToString, fnt, Brushes.Black, Me.PB_3_N0.Location.X - 35, CInt(Me.PB_3_N0.Location.Y + Me.PB_3_T.Height - (sizH / 2) - j * Me.PB_3_T.Height * yD / pDiff))
            gr.DrawString(CurPeg.ToString, fnt, Brushes.Black, Me.PB_3_N22.Location.X - 35, CInt(Me.PB_3_N22.Location.Y + Me.PB_3_T.Height - (sizH / 2) - j * Me.PB_3_T.Height * yD / pDiff))

            j = j + 1
        Loop

        '279°-gedrehte Beschriftung der Diagramme für "Tagzeitraum" und "lauteste Nachtstunde" 
        Dim fettFont As Font = New Font("Tahoma", 10, FontStyle.Bold)
        Dim mSt As Integer = CInt(gr.MeasureString("lauteste Nachtstunde [dB(A)]", fettFont).Width)
        gr.RotateTransform(270)
        gr.DrawString("lauteste Nachtstunde [dB(A)]", fettFont, Brushes.Black, -Me.PB_3_N0.Location.Y - Me.PB_3_N0.Height + (Me.PB_3_T.Height - mSt) / 2, 5) ' + Me.PB_3_N0.Height / 7, 5)

    End Sub

    Private Sub PB_3_T_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PB_3_T.Paint
        Dim gr As Graphics = e.Graphics
        Dim PB As PictureBox = CType(sender, PictureBox)

        Paint_DiagrammLinienTag(gr, PB.Width, PB.Height)
        Paint_Auswertung(gr, 6, PB.Width)
    End Sub
    Private Sub PB_3_N0_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PB_3_N0.Paint
        Dim gr As Graphics = e.Graphics
        Dim PB As PictureBox = CType(sender, PictureBox)

        Paint_DiagrammLinienNacht(gr, PB.Width, PB.Height)
        Paint_Auswertung(gr, 0, PB.Width)
    End Sub
    Private Sub PB_3_N1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PB_3_N1.Paint
        Dim gr As Graphics = e.Graphics
        Dim PB As PictureBox = CType(sender, PictureBox)

        Paint_DiagrammLinienNacht(gr, PB.Width, PB.Height)
        Paint_Auswertung(gr, 1, PB.Width)
    End Sub
    Private Sub PB_3_N2_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PB_3_N2.Paint
        Dim gr As Graphics = e.Graphics
        Dim PB As PictureBox = CType(sender, PictureBox)

        Paint_DiagrammLinienNacht(gr, PB.Width, PB.Height)
        Paint_Auswertung(gr, 2, PB.Width)
    End Sub
    Private Sub PB_3_N3_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PB_3_N3.Paint
        Dim gr As Graphics = e.Graphics
        Dim PB As PictureBox = CType(sender, PictureBox)

        Paint_DiagrammLinienNacht(gr, PB.Width, PB.Height)
        Paint_Auswertung(gr, 3, PB.Width)
    End Sub
    Private Sub PB_3_N4_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PB_3_N4.Paint
        Dim gr As Graphics = e.Graphics
        Dim PB As PictureBox = CType(sender, PictureBox)

        Paint_DiagrammLinienNacht(gr, PB.Width, PB.Height)
        Paint_Auswertung(gr, 4, PB.Width)
    End Sub
    Private Sub PB_3_N5_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PB_3_N5.Paint
        Dim gr As Graphics = e.Graphics
        Dim PB As PictureBox = CType(sender, PictureBox)

        Paint_DiagrammLinienNacht(gr, PB.Width, PB.Height)
        Paint_Auswertung(gr, 5, PB.Width)
    End Sub
    Private Sub PB_3_N22_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PB_3_N22.Paint
        Dim gr As Graphics = e.Graphics
        Dim PB As PictureBox = CType(sender, PictureBox)

        Paint_DiagrammLinienNacht(gr, PB.Width, PB.Height)
        Paint_Auswertung(gr, 22, PB.Width)
    End Sub
    Private Sub PB_3_N23_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PB_3_N23.Paint
        Dim gr As Graphics = e.Graphics
        Dim PB As PictureBox = CType(sender, PictureBox)

        Paint_DiagrammLinienNacht(gr, PB.Width, PB.Height)
        Paint_Auswertung(gr, 23, PB.Width)
    End Sub
#End Region

#Region "Paint-Prozeduren"
    Private Function Get_Y(ByVal L As Single) As Integer
        'Me.NUD_P_Wertebereich.Value -> 420 PX
        Dim px_L As Single = Me.PB_3_T.Height / Me.NUD_P_Wertebereich.Value 'PX-Spekturm für einen Pegelwert

        Return CInt((Me.NUD_P_max.Value - L) * px_L)
    End Function
    Private Sub Paint_Auswertung(ByVal gr As Graphics, ByVal startH As Integer, ByVal breiteDiagramm As Integer)

        Dim skaleX_Sek As Single = CSng(breiteDiagramm / 12)

        If Not IsNothing(Auswertung) Then
            Dim tmpZR As Beurteilungszeitraum_Data = Nothing
            Select Case startH
                Case 0
                    tmpZR = Auswertung.Nachtzeitraum_0
                Case 1
                    tmpZR = Auswertung.Nachtzeitraum_1
                Case 2
                    tmpZR = Auswertung.Nachtzeitraum_2
                Case 3
                    tmpZR = Auswertung.Nachtzeitraum_3
                Case 4
                    tmpZR = Auswertung.Nachtzeitraum_4
                Case 5
                    tmpZR = Auswertung.Nachtzeitraum_5
                Case 6
                    skaleX_Sek = CSng(breiteDiagramm / 192) 'bei 192 Datenpunkten
                    tmpZR = Auswertung.Tagzeitraum
                Case 22
                    tmpZR = Auswertung.Nachtzeitraum_22
                Case 23
                    tmpZR = Auswertung.Nachtzeitraum_23
            End Select
            If Not IsNothing(tmpZR.Pegel) Then
                'Grenzwert
                Dim orangePen As New Pen(Color.Orange, 3)
                'Dim thisStr As String() = tmpZR.Pegel(tmpZR.Pegel.Count - 1).ToString.Split(Chr(59))
                'Dim letzterPegel As Single = 0
                'If thisStr(3) <> "" Then letzterPegel = CSng(thisStr(3).Replace(".", ","))
                'Dim sngGW As Single = 10 * Math.Log10(100 * 10 ^ (0.1 * letzterPegel) / tmpZR.prozGes)

                If Not Single.IsInfinity(tmpZR.GW) Then gr.DrawLine(orangePen, 0, Get_Y(tmpZR.GW), breiteDiagramm, Get_Y(tmpZR.GW))
                ' If Not Single.IsInfinity(tmpZR.GW) Then gr.DrawLine(Pens.Red, 0, Get_Y(tmpZR.GW), breiteDiagramm, Get_Y(tmpZR.GW))

                Dim tOben As Integer = tmpZR.Pegel.Count - 1
                'For iAI As Integer = 0 To tOben 'tmpZR.Pegel.LastIndexOf(tmpZR.Pegel)
                Dim pnts() As System.Drawing.PointF = Nothing
                Dim pnts_VF() As System.Drawing.PointF = Nothing
                Dim pnts_RQ() As System.Drawing.PointF = Nothing

                For iAI As Integer = 0 To tOben 'tmpZR.Pegel.LastIndexOf(tmpZR.Pegel)
                    'Do While iAI < tOben 'tmpZR.Pegel.LastIndexOf(tmpZR.Pegel)
                    If tmpZR.Pegel(iAI).ToString = "" Then
                        Paint_Beurteilungspegel(gr, skaleX_Sek, 3, pnts)
                        Paint_Beurteilungspegel(gr, skaleX_Sek, 1, pnts_VF)
                        Paint_Beurteilungspegel(gr, skaleX_Sek, 2, pnts_RQ)
                        'Exit Do
                    Else

                        Dim tmpStr As String() = tmpZR.Pegel(iAI).ToString.Split(Chr(59))
                        Dim Pc As Single = 0
                        If tmpStr(3) <> "" Then Pc = CSng(tmpStr(3).Replace(".", ","))
                        If Pc = 0 Then
                            Paint_Beurteilungspegel(gr, skaleX_Sek, 3, pnts)
                            '    Exit Do
                        Else
                            Dim iLen As Integer = 0
                            If Not IsNothing(pnts) Then iLen = pnts.Length
                            ReDim Preserve pnts(iLen)
                            pnts(iLen) = New System.Drawing.PointF(skaleX_Sek * iAI, Get_Y(Pc))
                        End If

                        Pc = 0
                        If tmpStr(1) <> "" Then Pc = CSng(tmpStr(1).Replace(".", ","))
                        If Pc = 0 Then
                            Paint_Beurteilungspegel(gr, skaleX_Sek, 1, pnts_VF)
                            '    Exit Do
                        Else
                            Dim iLen As Integer = 0
                            If Not IsNothing(pnts_VF) Then iLen = pnts_VF.Length
                            ReDim Preserve pnts_VF(iLen)
                            pnts_VF(iLen) = New System.Drawing.PointF(skaleX_Sek * iAI, Get_Y(Pc))
                        End If

                        Pc = 0
                        If tmpStr(2) <> "" Then Pc = CSng(tmpStr(2).Replace(".", ","))
                        If Pc = 0 Then
                            Paint_Beurteilungspegel(gr, skaleX_Sek, 2, pnts_RQ)
                        Else
                            Dim iLen As Integer = 0
                            If Not IsNothing(pnts_RQ) Then iLen = pnts_RQ.Length
                            ReDim Preserve pnts_RQ(iLen)
                            pnts_RQ(iLen) = New System.Drawing.PointF(skaleX_Sek * iAI, Get_Y(Pc))
                        End If
                    End If
                Next
                Paint_Beurteilungspegel(gr, skaleX_Sek, 3, pnts)
                Paint_Beurteilungspegel(gr, skaleX_Sek, 1, pnts_VF)
                Paint_Beurteilungspegel(gr, skaleX_Sek, 2, pnts_RQ)
            End If
        End If
    End Sub
    Private Sub Paint_Beurteilungspegel(ByVal gr As Graphics, ByVal skaleX_Sek As Single, ByVal btEreignis As Byte, ByRef pnts() As System.Drawing.PointF)
        If Not IsNothing(pnts) Then

            Dim thisPen As New Pen(Color.Black, 2)
            Select Case btEreignis
                Case 1
                    thisPen = New Pen(Color.Red, 1) 'VF
                Case 2
                    thisPen = New Pen(Color.Blue, 1) 'RQ
            End Select

            Dim tmpPnts(pnts.Length) As System.Drawing.PointF
            tmpPnts(0).X = (pnts(0).X / skaleX_Sek - 1) * skaleX_Sek
            tmpPnts(0).Y = Get_Y(0)

            For i As Integer = 0 To pnts.Length - 1
                tmpPnts(i + 1) = pnts(i)
            Next


            If pnts.Length > 1 Then gr.DrawLines(thisPen, tmpPnts)

          

            pnts = Nothing
        End If

    End Sub

    Private Sub Paint_DiagrammLinienTag(ByVal gr As Graphics, ByVal Breite As Integer, ByVal Hoehe As Integer)
        'Diagramm-Gitternetz
        'x-Achse
        For i As Integer = 1 To 64 'viertelstunden-Striche
            If Math.IEEERemainder(i, 4) = 0 Then
                gr.DrawLine(Pens.Gray, CInt(i * Breite / 64), 0, CInt(i * Breite / 64), Hoehe)
            ElseIf Math.IEEERemainder(i, 2) = 0 Then
                gr.DrawLine(Pens.LightGray, CInt(i * Breite / 64), 0, CInt(i * Breite / 64), Hoehe)
                'Else
                '    gr.DrawLine(Pens.LightGray, CInt(i * Breite / 64), 0, CInt(i * Breite / 64), Hoehe)
            End If

        Next
        'y-Achsen-Richtung
        Dim yMin As Integer = CInt(Me.NUD_P_max.Value - Me.NUD_P_Wertebereich.Value)
        Dim yD As Integer = 10
        Dim pDiff As Integer = CInt(Me.NUD_P_Wertebereich.Value)
        Dim j As Integer = 0

        Do While yMin + j * yD <= Me.NUD_P_max.Value
            gr.DrawLine(Pens.LightGray, 0, CInt(Me.PB_3_T.Height - j * Me.PB_3_T.Height * yD / pDiff), Breite, CInt(Me.PB_3_T.Height - j * Me.PB_3_T.Height * yD / pDiff))

            j = j + 1
        Loop
    End Sub
    Private Sub Paint_DiagrammLinienNacht(ByVal gr As Graphics, ByVal Breite As Integer, ByVal Hoehe As Integer)
        'Diagramm-Gitternetz
        'x-Achse
        For i As Integer = 1 To 1 'viertelstunden-Striche
            gr.DrawLine(Pens.LightGray, CInt(i * Breite / 2), 0, CInt(i * Breite / 2), Hoehe)
        Next
        'y-Achsen-Richtung
        Dim yMin As Integer = CInt(Me.NUD_P_max.Value - Me.NUD_P_Wertebereich.Value)
        Dim yD As Integer = 10
        Dim pDiff As Integer = CInt(Me.NUD_P_Wertebereich.Value)
        Dim j As Integer = 0

        Do While yMin + j * yD <= Me.NUD_P_max.Value
            gr.DrawLine(Pens.LightGray, 0, CInt(Me.PB_3_T.Height - j * Me.PB_3_T.Height * yD / pDiff), Breite, CInt(Me.PB_3_T.Height - j * Me.PB_3_T.Height * yD / pDiff))

            j = j + 1
        Loop
    End Sub
#End Region
#End Region

#Region "Show Info"
    Private Sub PB_3_T_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_3_T.Click
        Show_Info(6)

    End Sub
    Private Sub PB_3_N0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_3_N0.Click

        Show_Info(0)
    End Sub
    Private Sub PB_3_N1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_3_N1.Click
        Show_Info(1)

    End Sub
    Private Sub PB_3_N2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_3_N2.Click
        Show_Info(2)

    End Sub
    Private Sub PB_3_N3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_3_N3.Click
        Show_Info(3)
    End Sub
    Private Sub PB_3_N4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_3_N4.Click
        Show_Info(4)

    End Sub
    Private Sub PB_3_N5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_3_N5.Click
        Show_Info(5)

    End Sub
    Private Sub PB_3_N22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_3_N22.Click
        Show_Info(22)

    End Sub
    Private Sub PB_3_N23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_3_N23.Click
        Show_Info(23)

    End Sub

    Private Sub Show_Info(ByVal startH As Integer)
        If False Then
            Dim tmpZR As Beurteilungszeitraum_Data = Nothing
            Select Case startH
                Case 0
                    tmpZR = Auswertung.Nachtzeitraum_0
                Case 1
                    tmpZR = Auswertung.Nachtzeitraum_1
                Case 2
                    tmpZR = Auswertung.Nachtzeitraum_2
                Case 3
                    tmpZR = Auswertung.Nachtzeitraum_3
                Case 4
                    tmpZR = Auswertung.Nachtzeitraum_4
                Case 5
                    tmpZR = Auswertung.Nachtzeitraum_5
                Case 6
                    tmpZR = Auswertung.Tagzeitraum
                Case 22
                    tmpZR = Auswertung.Nachtzeitraum_22
                Case 23
                    tmpZR = Auswertung.Nachtzeitraum_23
            End Select
            If Not IsNothing(tmpZR.Pegel) Then
                MsgBox("Restzeit [sek]: " & tmpZR.Restlaufzeit & Chr(13) & Chr(10) & _
                        "Proz. VF:     " & tmpZR.prozVF & Chr(13) & Chr(10) & _
                        "Proz. RQ:     " & tmpZR.prozRQ & Chr(13) & Chr(10) & _
                        "Proz. ges:    " & tmpZR.prozGes & Chr(13) & Chr(10) & _
                         "ME:           " & tmpZR.Messeinhei & Chr(13) & Chr(10) & _
                        "Pegel VF:     " & tmpZR.Pegel(tmpZR.iRowIX).split(";")(1) & Chr(13) & Chr(10) & _
                        "Pegel RQ:     " & tmpZR.Pegel(tmpZR.iRowIX).split(";")(2) & Chr(13) & Chr(10) & _
                        "Pegel Ges:    " & tmpZR.Pegel(tmpZR.iRowIX).split(";")(3) & Chr(13) & Chr(10) & _
                        "Berechnung %: 100 * 10 ^ (Pc * 0.1) / 10 ^ (GW * 0.1)", MsgBoxStyle.OkOnly, "INFO")
            Else
                MsgBox("Restzeit [sek]: " & tmpZR.Restlaufzeit & Chr(13) & Chr(10) & _
                        "Proz. VF:     " & tmpZR.prozVF & Chr(13) & Chr(10) & _
                        "Proz. RQ:     " & tmpZR.prozRQ & Chr(13) & Chr(10) & _
                        "Proz. ges:    " & tmpZR.prozGes & Chr(13) & Chr(10) & _
                        "ME:           " & tmpZR.Messeinhei & Chr(13) & Chr(10) & _
                        "Berechnung %: 100 * 10 ^ (Pc * 0.1) / 10 ^ (GW * 0.1)", MsgBoxStyle.OkOnly, "INFO")
            End If
        End If
    End Sub
#End Region

    Private Sub UserControl_Gesammtansicht_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        '  selectedDate = Me.DTP_1.Value
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
