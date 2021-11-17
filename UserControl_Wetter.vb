Option Strict Off
Imports System.Drawing

Public Class UserControl_Wetter

    'Private bSet_NOSW As Boolean
    'Private bDown_NOSW As Boolean
    Private ptNOSW As System.Drawing.Point
    Private dwPOSW As Single
    Private dNOSW As Point

    'Private Const SekWetter As Integer = 180

    Private Sub UserControl_Wetter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim tmpDate As Date = Me.DTP_1.Value
        'Set_Wetter(New Date(tmpDate.Year, tmpDate.Month, tmpDate.Day, 6, 0, 0), _
        'New Date(tmpDate.AddDays(1).Year, tmpDate.AddDays(1).Month, tmpDate.AddDays(1).Day, 6, 0, 0))
        Aktuallisieren()
    End Sub

#Region "Diagramme"

    Private Sub PB_Luftdruck_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PB_Luftdruck.Paint
        Dim gr As Graphics = e.Graphics

        Dim Wertebereich As Integer = 100
        Dim MinWert As Integer = 950
        Dim IntervalleAnz As Integer = 10

        'Diagramm-Gitternetz
        'x-Achse
        For i As Integer = 1 To 24
            gr.DrawLine(Pens.Gray, i * 20, 0, i * 20, Me.PB_Luftfeuchte.Height)
        Next
        'y-Achsen-Richtung
        Dim tmpIntervall As Integer = CInt(Me.PB_Luftdruck.Height / (IntervalleAnz - 1)) '11)
        For i As Integer = 1 To IntervalleAnz '12
            'If i = 5 Then '8 Then'12), _
            '    gr.DrawLine(Pens.LightCoral, 0, i * CInt(Me.PB_Luftfeuchte.Height / IntervalleAnz), _
            '            Me.PB_Temperatur.Width, i * CInt(Me.PB_Luftfeuchte.Height / IntervalleAnz)) '12))
            'Else
            If Math.IEEERemainder(i, 2) = 0 Then
                gr.DrawLine(Pens.Gray, 0, i * CInt(Me.PB_Luftfeuchte.Height / IntervalleAnz), _
                    Me.PB_Temperatur.Width, i * CInt(Me.PB_Luftfeuchte.Height / IntervalleAnz))
            Else
                gr.DrawLine(Pens.LightGray, 0, i * CInt(Me.PB_Luftfeuchte.Height / IntervalleAnz), _
                    Me.PB_Temperatur.Width, i * CInt(Me.PB_Luftfeuchte.Height / IntervalleAnz))
            End If
        Next
        'mittlerer Luftdruck
        gr.DrawLine(Pens.LightCoral, 0, Me.PB_Luftdruck.Height - CInt((Me.PB_Luftdruck.Height * (1013.25 - MinWert)) / Wertebereich), _
                    Me.PB_Temperatur.Width, Me.PB_Luftdruck.Height - CInt((Me.PB_Luftdruck.Height * (1013.25 - MinWert)) / Wertebereich))


        '1 Pixel entspricht 3 min
        'Luftdruck-Datenpunkte eintragen
        If Wetter.Count > 0 Then
            'If Not IsNothing(Wetter) Then
            'For iDS As Integer = 0 To Wetter.Length - 1
            '    With Wetter(iDS).Luftdruck
            For iDS As Integer = 0 To Wetter.Count - 1
                If Wetter(iDS) <> "" Then
                    With Wetter(iDS)
                        Dim Zeit As Date = .Split(Chr(59))(0) '.Zeit
                        Dim Wert As String = .Split(Chr(59))(2).Replace(".", ",") '.Luftdruck
                        If Wert <> "N/A" Then '-1 Then
                            'Umrechnung der Zeit in Pixel (vom Ursprung entfernt auf x-Achse) -> 1 Pixel entspricht 3 min
                            '-> Pixelentfernung der Zeit: CInt(((.Zeit.Hour - 6) * 60 + .Zeit.Minute) / 3)                        
                            'Dim x As Integer = CInt(((Zeit.AddHours(-6).Hour) * 60 + Zeit.Minute) / 3)
                            Dim x As Integer = CInt(((Zeit.Hour) * 60 + Zeit.Minute) / 3)

                            'Wertebereich geht von 950 - 150 hPa '980 - 1040 hPa
                            Dim y As Integer = Me.PB_Luftdruck.Height - CInt((Me.PB_Luftdruck.Height * (Wert - MinWert)) / Wertebereich) '980)) / 60)
                            gr.FillRectangle(New SolidBrush(Color.Blue), x, y, 1, 1)
                            'gr.DrawEllipse(Pens.Blue, x, y, 1, 1)
                        End If
                    End With
                End If
                iDS = iDS + My.Settings.SekWetter - 1
            Next
        End If

    End Sub

    Private Sub PB_Luftfeuchte_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PB_Luftfeuchte.Paint
        Dim gr As Graphics = e.Graphics

        'Diagramm-Gitternetz
        'x-Achse
        For i As Integer = 1 To 24
            gr.DrawLine(Pens.Gray, i * 20, 0, i * 20, Me.PB_Luftfeuchte.Height)
        Next
        'y-Achse
        For i As Integer = 1 To 5
            gr.DrawLine(Pens.Gray, 0, i * CInt(Me.PB_Luftfeuchte.Height / 5), _
                    Me.PB_Luftfeuchte.Width, i * CInt(Me.PB_Luftfeuchte.Height / 5))
        Next

        '1 Pixel entspricht 3 min
        'Luftfeuchte-Datenpunkte eintragen
        If Wetter.Count > 0 Then
            'If Not IsNothing(Wetter) Then
            For iDS As Integer = 0 To Wetter.Count - 1
                If Wetter(iDS) <> "" Then
                    With Wetter(iDS) '.Luftfeuchtigkeit
                        Dim Zeit As Date = .Split(Chr(59))(0) '.Zeit
                        Dim Wert As Single = .Split(Chr(59))(3).Replace(".", ",") '.Luftfeuchtigkeit
                        '.Luftfeuchtigkeit.Wert = CSng(tmpZeile(iFeuchtigkeit).Replace(".", ","))
                        If Wert >= 0 And Wert <= 100 Then '<> -1 Then
                            'Umrechnung der Zeit in Pixel (vom Ursprung entfernt auf x-Achse) -> 1 Pixel entspricht 3 min
                            '-> Pixelentfernung der Zeit: CInt(((.Zeit.Hour - 6) * 60 + .Zeit.Minute) / 3)                        
                            'Dim x As Integer = CInt(((Zeit.AddHours(-6).Hour) * 60 + Zeit.Minute) / 3)
                            Dim x As Integer = CInt(((Zeit.Hour) * 60 + Zeit.Minute) / 3)

                            'Wertebereich geht von 0 - 100 %
                            Dim y As Integer = Me.PB_Luftfeuchte.Height - CInt((Me.PB_Luftfeuchte.Height * Wert) / 100)
                            gr.FillRectangle(New SolidBrush(Color.Blue), x, y, 1, 1)
                            'gr.DrawEllipse(Pens.Red, x, y, 1, 1)
                        End If
                    End With
                End If
                iDS = iDS + My.Settings.SekWetter - 1
            Next
        End If

    End Sub

    Private Sub PB_Regen_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PB_Regen.Paint
        Dim gr As Graphics = e.Graphics

        '1 Pixel entspricht 3 min
        'Regen-Datenpunkte eintragen
        If Wetter.Count > 0 Then
            'If Not IsNothing(Wetter) Then
            For iDS As Integer = 0 To Wetter.Count - 1
                If Wetter(iDS) <> "" Then
                    With Wetter(iDS) '.Regen
                        Dim Zeit As Date = .Split(Chr(59))(0) '.Zeit
                        Dim Wert As Integer = .Split(Chr(59))(7).Replace(".", ",") '.Regen
                        If Wert = 1 Then '<> -1  Then
                            Dim tmpZeit As Date = Zeit

                            'Umrechnung der Zeit in Pixel (vom Ursprung entfernt auf x-Achse) -> 1 Pixel entspricht 3 min
                            '-> Pixelentfernung der Zeit: CInt(((.Zeit.Hour - 6) * 60 + .Zeit.Minute) / 3)                        
                            'Dim x As Integer = CInt(((Zeit.AddHours(-6).Hour) * 60 + Zeit.Minute) / 3)
                            Dim x As Integer = CInt(((Zeit.Hour) * 60 + Zeit.Minute) / 3)

                            'Mit Windrichtung und Pixel-Radius liegt der Punkt in Polarkoordinaten vor
                            '-> Transformation in Kartesische Koordinaten und Translation in den Pixel-Ursprung der Grafik pOrigin
                            Dim y As Integer = Me.PB_Regen.Height
                            gr.DrawLine(Pens.Red, x, 0, x, y)

                        End If
                    End With
                End If
                iDS = iDS + My.Settings.SekWetter - 1
            Next
        End If
        'Diagramm-Gitternetz
        'x-Achse
        For i As Integer = 1 To 24
            gr.DrawLine(Pens.Black, i * 20, CInt(Me.PB_Regen.Height / 2), i * 20, Me.PB_Regen.Height)
        Next

    End Sub

    Private Sub PB_Temperatur_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PB_Temperatur.Paint
        Dim gr As Graphics = e.Graphics

        'Diagramm-Gitternetz
        'x-Achse
        For i As Integer = 1 To 24
            gr.DrawLine(Pens.Gray, i * 20, 0, i * 20, Me.PB_Temperatur.Height)
        Next
        'y-Achsen-Richtung
        Dim tmpIntervall As Integer = CInt(Me.PB_Temperatur.Height / 15)
        For i As Integer = 1 To 16
            If i = 9 Then
                gr.DrawLine(Pens.LightCoral, 0, i * CInt(Me.PB_Temperatur.Height / 16), _
                        Me.PB_Temperatur.Width, i * CInt(Me.PB_Temperatur.Height / 16))
            ElseIf Math.IEEERemainder(i, 2) <> 0 Then
                gr.DrawLine(Pens.Gray, 0, i * CInt(Me.PB_Temperatur.Height / 16), _
                    Me.PB_Temperatur.Width, i * CInt(Me.PB_Temperatur.Height / 16))
            Else
                gr.DrawLine(Pens.LightGray, 0, i * CInt(Me.PB_Temperatur.Height / 16), _
                    Me.PB_Temperatur.Width, i * CInt(Me.PB_Temperatur.Height / 16))
            End If
        Next

        'y-Achse: 1° entspr. 6 PX -> 5° entspr. 30 PX
        'Temperatur-Datenpunkte eintragen
        If Wetter.Count > 0 Then
            'If Not IsNothing(Wetter) Then
            For iDS As Integer = 0 To Wetter.Count - 1
                If Wetter(iDS) <> "" Then
                    With Wetter(iDS) '.Temperatur
                        Dim Zeit As Date = .Split(Chr(59))(0) '.Zeit
                        Dim Wert As Single = .Split(Chr(59))(1).Replace(".", ",") '.Temperatur
                        '.Temperatur.Wert = CSng(tmpZeile(iTemperatur).Replace(".", ","))
                        If Wert >= -35 And Wert <= 45 Then '<> -1 Then
                            'Umrechnung der Zeit in Pixel (vom Ursprung entfernt auf x-Achse) -> 1 Pixel entspricht 3 min
                            '-> Pixelentfernung der Zeit: CInt(((.Zeit.Hour - 6) * 60 + .Zeit.Minute) / 3)                        
                            'Dim x As Integer = CInt(((Zeit.AddHours(-6).Hour) * 60 + Zeit.Minute) / 3)
                            Dim x As Integer = CInt(((Zeit.Hour) * 60 + Zeit.Minute) / 3)

                            'Wertebereich geht von -35° bis 45°
                            Dim y As Integer = Me.PB_Temperatur.Height - CInt((Me.PB_Temperatur.Height * (Wert + 35)) / 80)
                            gr.FillRectangle(New SolidBrush(Color.Blue), x, y, 1, 1)
                        End If
                    End With
                End If
                iDS = iDS + My.Settings.SekWetter - 1
            Next
        End If

    End Sub

    Private Sub PB_Windgeschwindigkeit_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PB_Windgeschwindigkeit.Paint
        Dim gr As Graphics = e.Graphics

        'Diagramm-Gitternetz
        'x-Achse
        For i As Integer = 1 To 24
            gr.DrawLine(Pens.Gray, i * 20, 0, i * 20, Me.PB_Windgeschwindigkeit.Height)
        Next
        'y-Achsen-Richtung
        Dim tmpIntervall As Integer = CInt(Me.PB_Windgeschwindigkeit.Height / 11)
        For i As Integer = 1 To 12
            If Math.IEEERemainder(i, 2) = 0 Then
                gr.DrawLine(Pens.Gray, 0, i * CInt(Me.PB_Windgeschwindigkeit.Height / 12), _
                    Me.PB_Windgeschwindigkeit.Width, i * CInt(Me.PB_Windgeschwindigkeit.Height / 12))
            Else
                gr.DrawLine(Pens.LightGray, 0, i * CInt(Me.PB_Windgeschwindigkeit.Height / 12), _
                    Me.PB_Windgeschwindigkeit.Width, i * CInt(Me.PB_Windgeschwindigkeit.Height / 12))
            End If
        Next

        'Windgeschwindigkeit-Datenpunkte eintragen
        If Wetter.Count > 0 Then
            'If Not IsNothing(Wetter) Then
            For iDS As Integer = 0 To Wetter.Count - 1
                If Wetter(iDS) <> "" Then

                    With Wetter(iDS) '.Windgeschwindigkeit
                        Dim Zeit As Date = .Split(Chr(59))(0) '.Zeit
                        Dim Wert As Single = .Split(Chr(59))(4).Replace(".", ",") * 3.6 '.Windgeschwindigkeit

                        If Wert >= 0 And Wert <= 120 Then '<> -1 Then
                            'Umrechnung der Zeit in Pixel (vom Ursprung entfernt auf x-Achse) -> 1 Pixel entspricht 3 min
                            '-> Pixelentfernung der Zeit: CInt(((.Zeit.Hour - 6) * 60 + .Zeit.Minute) / 3)                        
                            'Dim x As Integer = CInt(((Zeit.AddHours(-6).Hour) * 60 + Zeit.Minute) / 3)
                            Dim x As Integer = CInt(((Zeit.Hour) * 60 + Zeit.Minute) / 3)

                            'Wertebereich geht von 0 bis 120 kmh
                            Dim y As Integer = CInt(Me.PB_Windgeschwindigkeit.Height - (Me.PB_Windgeschwindigkeit.Height * Wert / 120))
                            gr.FillRectangle(New SolidBrush(Color.Blue), x, y, 1, 1)
                            'gr.DrawEllipse(Pens.Blue, x, y, 1, 1)
                        End If
                    End With
                End If
                iDS = iDS + My.Settings.SekWetter - 1 '1 wird eh wieder draufgezählt
            Next
        End If

    End Sub
#End Region

#Region "NOSW"
    Private Sub Set_NOSW(ByVal rotation As Single)
        'bSet_NOSW = True

        PB_NOSW.Invalidate()
    End Sub
    Private Sub PB_NOSW_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PB_NOSW.Paint
        '150; 150 -> 124
        Dim gr As Graphics = e.Graphics
        'Zeitkreis zeichnen
        Dim sngWdth() As String = CStr(Me.PB_NOSW.Width / 2).Split(",")
        'Es sollte eine ungerade Zahl der Breite und Höhe vorliegen, um einen Mittelpunkt in der Grafik zu haben
        If sngWdth.Length = 1 Then
            Me.PB_NOSW.Width = Me.PB_NOSW.Width + 1
            Me.PB_NOSW.Height = Me.PB_NOSW.Width
        End If

        sngWdth = CStr((Me.PB_NOSW.Width - 1) / 24).Split(",")
        Dim iSchritte As Integer = CInt(sngWdth(0))
        Dim firstStep As Integer = (Me.PB_NOSW.Width - 1) / 2 - iSchritte * 12
        Dim pOrigin As New Point((Me.PB_NOSW.Width - 1) / 2, (Me.PB_NOSW.Width - 1) / 2)

        'Windrichtung-Datenpunkte eintragen
        If Wetter.Count > 0 Then
            'If Not IsNothing(Wetter) Then
            For iDS As Integer = 0 To Wetter.Count - 1
                If Wetter(iDS) <> "" Then
                    With Wetter(iDS) '.Windrichtung
                        Dim Zeit As Date = .Split(Chr(59))(0) '.Zeit
                        Dim Wert As String = .Split(Chr(59))(5).Replace(".", ",") '.Windrichtung
                        If Wert <> "N/A" Then '-1 Then
                            Dim tmpZeit As Date = Zeit
                            Dim rPX As Integer
                            'Umrechnung der Zeit in Pixel (vom Ursprung entfernt) -> 1 Pixel entspricht 6 min
                            '-> Pixelradius der Zeit: CInt(((.Zeit.Hour - 6) * 60 + .Zeit.Minute) / 6)
                            'rPX = firstStep + CInt(((Zeit.Hour - 6) * 60 + Zeit.Minute) / 6)
                            rPX = firstStep + CInt((Zeit.Hour * 60 + Zeit.Minute) / 6)

                            '0° Windrichtung entspricht Norden
                            'Mit Windrichtung und Pixel-Radius liegt der Punkt in Polarkoordinaten vor
                            '-> Transformation in Kartesische Koordinaten und Translation in den Pixel-Ursprung der Grafik pOrigin
                            Dim x As Integer = pOrigin.X + rPX * Math.Sin(Wert * 2 * Math.PI / 360)
                            Dim y As Integer = pOrigin.Y + rPX * Math.Cos(Wert * 2 * Math.PI / 360)
                            gr.DrawEllipse(Pens.Red, x, y, 1, 1)
                            'gr.DrawEllipse(Pens.Red, x - 1, y - 1, 3, 3)

                            '** Die unten gehen nicht -> nichts zu sehen
                            'gr.DrawLine(Pens.Red, x, y, x, y)
                            'gr.FillEllipse(Brushes.Red, x, y, 1, 1)
                        End If
                    End With
                End If
                iDS = iDS + My.Settings.SekWetter - 1 '1 wird eh wieder draufgezählt
            Next
        End If

        'Uhrzeitbeschriftung eintragen
        For iStep As Integer = 0 To 12
            Dim iUhr As Integer = iStep * 2
            If iUhr >= 24 Then iUhr = iUhr - 24
            Select Case iStep
                Case 6
                    gr.DrawEllipse(Pens.DarkRed, pOrigin.X - firstStep - iStep * iSchritte - 1, pOrigin.Y - firstStep - iStep * iSchritte - 1, 1 + 2 * (firstStep + iStep * iSchritte), 1 + 2 * (firstStep + iStep * iSchritte))
                    gr.DrawString(iUhr & ":00", New System.Drawing.Font("Tahoma", 8, FontStyle.Regular), Brushes.DarkRed, pOrigin.X, pOrigin.Y - firstStep - iStep * iSchritte - 1)
                Case 3, 9
                    gr.DrawEllipse(Pens.DarkOrange, pOrigin.X - firstStep - iStep * iSchritte - 1, pOrigin.Y - firstStep - iStep * iSchritte - 1, 1 + 2 * (firstStep + iStep * iSchritte), 1 + 2 * (firstStep + iStep * iSchritte))
                    gr.DrawString(iUhr & ":00", New System.Drawing.Font("Tahoma", 8, FontStyle.Regular), Brushes.DarkOrange, pOrigin.X, pOrigin.Y - firstStep - iStep * iSchritte - 1)
                Case Else
                    gr.DrawEllipse(Pens.Olive, pOrigin.X - firstStep - iStep * iSchritte - 1, pOrigin.Y - firstStep - iStep * iSchritte - 1, 1 + 2 * (firstStep + iStep * iSchritte), 1 + 2 * (firstStep + iStep * iSchritte))
                    gr.DrawString(iUhr & ":00", New System.Drawing.Font("Tahoma", 8, FontStyle.Regular), Brushes.Black, pOrigin.X, pOrigin.Y - firstStep - iStep * iSchritte - 1)
            End Select

        Next
        
    End Sub
   
#End Region

    Private Sub DTP_1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTP_1.ValueChanged
        Aktuallisieren()
    End Sub
    Private Sub Aktuallisieren()
        Dim tmpDate As Date = Me.DTP_1.Value

        Me.Cursor = Cursors.WaitCursor

        If Set_Wetter(New Date(tmpDate.Year, tmpDate.Month, tmpDate.Day, 0, 0, 0), _
                New Date(tmpDate.AddDays(1).Year, tmpDate.AddDays(1).Month, tmpDate.AddDays(1).Day, 0, 0, 0)) = False Then
            MsgBox("Es konnten relevante Dateien, nicht geöffnet werden, da sie von einem anderen Prozess verwendet werden. Versuchen Sie es später noch einmal.", MsgBoxStyle.OkOnly, "Zugriffskonflikt")
            Wetter.Clear() ' = Nothing
        End If

        Update_Anzeige()

        Me.Cursor = Cursors.Default
    End Sub
    Private Sub Update_Anzeige()
        Dim myThread_NOSW As New Threading.Thread(AddressOf PB_NOSW_Update)
        myThread_NOSW.Start()

        Dim myThread_Luftdruck As New Threading.Thread(AddressOf PB_Luftdruck_Update)
        myThread_Luftdruck.Start()

        Dim myThread_Luftfeuchte As New Threading.Thread(AddressOf PB_Luftfeuchte_Update)
        myThread_Luftfeuchte.Start()

        Dim myThread_Regen As New Threading.Thread(AddressOf PB_Regen_Update)
        myThread_Regen.Start()

        Dim myThread_Temperatur As New Threading.Thread(AddressOf PB_Temperatur_Update)
        myThread_Temperatur.Start()

        Dim myThread_Windgeschwindigkeit As New Threading.Thread(AddressOf PB_Windgeschwindigkeit_Update)
        myThread_Windgeschwindigkeit.Start()



        'Me.PB_NOSW.Invalidate()
        'Me.PB_Luftdruck.Invalidate()
        'Me.PB_Luftfeuchte.Invalidate()
        'Me.PB_Regen.Invalidate()
        'Me.PB_Temperatur.Invalidate()
        'Me.PB_Windgeschwindigkeit.Invalidate()

    End Sub
    Private Sub PB_Windgeschwindigkeit_Update(ByVal obj As Object)
        Me.PB_Windgeschwindigkeit.Invalidate()
    End Sub
    Private Sub PB_Temperatur_Update(ByVal obj As Object)
        Me.PB_Temperatur.Invalidate()
    End Sub
    Private Sub PB_Regen_Update(ByVal obj As Object)
        Me.PB_Regen.Invalidate()
    End Sub
    Private Sub PB_Luftfeuchte_Update(ByVal obj As Object)
        Me.PB_Luftfeuchte.Invalidate()
    End Sub
    Private Sub PB_Luftdruck_Update(ByVal obj As Object)
        Me.PB_Luftdruck.Invalidate()
    End Sub
    Private Sub PB_NOSW_Update(ByVal obj As Object)
        Me.PB_NOSW.Invalidate()
    End Sub

    Private Sub Button_Refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Refresh.Click
        Aktuallisieren()
    End Sub

    Private Sub PB_Luftdruck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_Luftdruck.Click

    End Sub
End Class

