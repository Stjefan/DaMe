
Option Strict Off
Imports System.Drawing

Public Class UserControl_Messpunkte

    Public bKuFi As Boolean = False
    Public bUhrzeitUpdate As Boolean = False

    Private Sub UserControl_Messpunkte_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' If Not IsNothing(selectedDate) Then If selectedDate >= Me.DTP_1.MinDate Then Me.DTP_1.Value = selectedDate
        If Not IsNothing(selectedDate) Then
            If selectedME > 0 Then Me.LB_ME.SelectedIndex = selectedME - 1
            If selectedDate < Me.DTP_1.MinDate Then selectedDate = Me.DTP_1.MinDate
            Me.DTP_1.Value = selectedDate
            Me.DTP_Uhrzeit.Value = selectedDate
        End If
        'Else
        Me.LB_ME.SelectedIndex = 2
        Dim tmpDat As Date = CDate(Me.DTP_Uhrzeit.Value)
        Dim iMin As Integer = 45
        If Now.Minute < 15 Then
            iMin = 0
        ElseIf Now.Minute < 30 Then
            iMin = 15
        ElseIf Now.Minute < 45 Then
            iMin = 30
        End If
        tmpDat = New Date(tmpDat.Year, tmpDat.Month, tmpDat.Day, Now.Hour, iMin, 0)
        Me.DTP_Uhrzeit.Value = tmpDat
        'End If

        Aktuallisieren(True)
    End Sub
   
    Private Sub Paint_Diagramme(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim tPB As PictureBox = CType(sender, PictureBox)

        Dim gr As Graphics = e.Graphics

        Dim pn1 As New Pen(Color.Turquoise)
        pn1.Width = 4
        Dim pn2 As New Pen(Color.Magenta)
        pn2.Width = 4
        Dim pn3 As New Pen(Color.Green)
        pn3.Width = 4
 
        Dim anzZeitPkte As Integer = 10
         
    End Sub

    Private Function Get_Date() As Date '(ByVal bFirst As Boolean) 
        'If bFirst Then
        Get_Date = New Date(Me.DTP_1.Value.Year, Me.DTP_1.Value.Month, Me.DTP_1.Value.Day, Me.DTP_Uhrzeit.Value.Hour, Me.DTP_Uhrzeit.Value.Minute, 0)

    End Function

    Private Sub PB_Diagramm_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PB_Diagramm.Paint
        Dim gr As Graphics = e.Graphics

        'Achsenskalierung wird auf PB_Diagramm gezeichnet.
        Dim vonZeit As Date = Me.DTP_Uhrzeit.Value 'Get_Date() '(True)
        Dim bisZeit As Date = vonZeit.AddMinutes(15) 'Get_Date(False)
        'Dim lSec As Long = DateDiff(DateInterval.Second, vonZeit, bisZeit)

        Dim fnt As New Font("Tahoma", 9, FontStyle.Regular)

        For i As Integer = 0 To 15


            Dim x As Integer = Me.Panel_Diagramm.Location.X + i * 60 - -Me.PB_Diagramm.Location.X
            Dim y As Integer = Me.Panel_Diagramm.Location.Y + Me.Panel_Diagramm.Height - Me.PB_Diagramm.Location.Y

            gr.DrawLine(Pens.Black, x, y, x, y + 10)

            Dim tmpStr As String = vonZeit.AddMinutes(i).ToString("t") '.Hour & ":" & vonZeit.AddMinutes(i).Minute

            Dim sf As New StringFormat()
            sf.Alignment = StringAlignment.Center
            Dim siz As SizeF = gr.MeasureString(tmpStr, fnt)
            gr.DrawString(tmpStr, fnt, Brushes.Black, _
                x, y + 10, sf)
            sf.Dispose()
        Next


        'waagrechte Diagrammlinien
        Dim yMin As Integer = Me.NUD_P_max.Value - Me.NUD_P_Wertebereich.Value

        Dim y1 As Integer = yMin
        Dim yD As Integer = 10
        Dim pDiff As Integer = Me.NUD_P_Wertebereich.Value
        Dim sizH As Integer = gr.MeasureString("bla", fnt).Height

        Dim j As Integer = 0

        Do While yMin + j * yD <= Me.NUD_P_max.Value
            Dim CurPeg As Integer = y1 + j * yD

            Dim x As Integer = Me.Panel_Diagramm.Location.X - 10 - Me.PB_Diagramm.Location.X
            Dim y As Integer = Me.Panel_Diagramm.Location.Y + Get_Y(CurPeg) - Me.PB_Diagramm.Location.Y

            gr.DrawLine(Pens.Black, x, y, x + 10, y)

            gr.DrawString(CurPeg.ToString, fnt, Brushes.Black, _
                x - 25, y - (sizH / 2)) ' Me.Panel_Diagramm.Height * (CurPeg - Me.NUD_P_Wertebereich.Value) / pDiff)
            j = j + 1
        Loop

        Dim fntGr As Font = New Font("Arial", 12)
        sizH = gr.MeasureString("Uhrzeit", fntGr).Width
        gr.DrawString("Uhrzeit", fntGr, Brushes.Black, Me.Panel_Diagramm.Location.X - Me.PB_Diagramm.Location.X + Me.Panel_Diagramm.Width / 2 - sizH / 2, Me.Panel_Diagramm.Location.Y - Me.PB_Diagramm.Location.Y + Me.Panel_Diagramm.Height + 30)

        sizH = gr.MeasureString("Schalldruckpegel [dB(A)]", fntGr).Width
        gr.ResetTransform()
        gr.TranslateTransform(30, 10 + Me.Panel_Diagramm.Height / 2 + sizH / 2) '50, 10 + Me.Panel_Diagramm.Height / 2)
        gr.RotateTransform(-90)
        Draw_Rotation(gr, fntGr)

        ''Dim sfo As New StringFormat()
        ''sfo.Alignment = StringAlignment.Center
        ''sfo.FormatFlags = StringFormatFlags.DirectionVertical
        ' ''gr.RotateTransform(90)
        ' '' gr.TranslateTransform(0, 0)
        ''gr.DrawString("Schalldruckpegel [dB(A)]", fnt, Brushes.Black, _
        ''            10, 10, sfo) ' Me.Panel_Diagramm.Height * (CurPeg - Me.NUD_P_Wertebereich.Value) / pDiff)
        ' ''gr.DrawString("Schalldruckpegel [dB(A)]", fnt, Brushes.Black, _
        ' ''             50, 10 + Me.Panel_Diagramm.Height / 2, sfo) ' Me.Panel_Diagramm.Height * (CurPeg - Me.NUD_P_Wertebereich.Value) / pDiff)
        ''sfo.Dispose()
        ''gr.ResetTransform()
    End Sub
    Private Sub Draw_Rotation(ByVal gr As Graphics, ByVal fnt As Font)
        gr.DrawString("Schalldruckpegel [dB(A)]", fnt, Brushes.Black, _
                     0, 0)
    End Sub
    Private Sub Button_Links_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Links.Click
        Me.DTP_Uhrzeit.Value = Me.DTP_Uhrzeit.Value.AddMinutes(-15)
        Aktuallisieren(False)
    End Sub
    Private Sub Button_LinksLinks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_LinksLinks.Click
        Me.DTP_1.Value = Me.DTP_1.Value.AddDays(-1)
        Aktuallisieren(True)
    End Sub
    Private Sub Button_Rechts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Rechts.Click
        Me.DTP_Uhrzeit.Value = Me.DTP_Uhrzeit.Value.AddMinutes(15)
        Aktuallisieren(False)
    End Sub
    Private Sub Button_RechtsRechts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_RechtsRechts.Click
        Me.DTP_1.Value = Me.DTP_1.Value.AddDays(1)
        Aktuallisieren(True)
    End Sub
    Private Sub Button_Oben_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Oben.Click
        Dim i As Integer = Me.LB_ME.SelectedIndex - 1
        If i < 0 Then
            Me.LB_ME.SelectedIndex = 2
        Else
            Me.LB_ME.SelectedIndex = i
        End If
        Aktuallisieren(True)

    End Sub
    Private Sub Button_Unten_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Unten.Click
        Dim i As Integer = Me.LB_ME.SelectedIndex + 1
        If i > 2 Then
            Me.LB_ME.SelectedIndex = 0
        Else
            Me.LB_ME.SelectedIndex = i
        End If
        Aktuallisieren(True)
    End Sub

    Private Sub Aktuallisieren(ByVal bTag As Boolean)
        Me.Cursor = Cursors.WaitCursor
        'Wenn sich der Tag verändert hat, dann müssen die Mainresults neu eingelesen werden (werden immer tageweise eingelesen)
        If bTag Then

            If Set_MainResults(Get_Date(), Get_Messstelle) = False Then
                MsgBox("Es konnten relevante Dateien, nicht geöffnet werden, da sie von einem anderen Prozess verwendet werden." & _
                    " Versuchen Sie es später noch einmal.", MsgBoxStyle.OkOnly, "Zugriffskonflikt")
                MainResults.Clear()
            End If
        End If

        Me.PB_Diagramm.Invalidate()
        Me.Panel_Diagramm.Invalidate()
        Me.Cursor = Cursors.Default
    End Sub

    Private Function Get_Messstelle() As Byte
        Return Me.LB_ME.SelectedIndex + 1
    End Function

    Private Sub NUD_P_max_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUD_P_max.ValueChanged

        Aktuallisieren(False)
    End Sub
    Private Sub NUD_P_Wertebereich_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUD_P_Wertebereich.ValueChanged

        Aktuallisieren(False)
    End Sub

    Private Sub DTP_Uhrzeit_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTP_Uhrzeit.ValueChanged
        If bUhrzeitUpdate = False Then
            bUhrzeitUpdate = True
            Me.NUD_h.Value = Me.DTP_Uhrzeit.Value.Hour
            ' Me.NUD_Min.Value = Me.DTP_Uhrzeit.Value.Minute
            bUhrzeitUpdate = False
        End If
        Aktuallisieren(False)
    End Sub

    Private Function Get_Y(ByVal L As Single) As Integer
        'Me.NUD_P_Wertebereich.Value -> 420 PX
        Dim px_L As Single = 420 / Me.NUD_P_Wertebereich.Value 'PX-Spekturm für einen Pegelwert

        Return (Me.NUD_P_max.Value - L) * px_L
    End Function

    Private Sub Panel_Diagramm_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel_Diagramm.Paint
        'Maximalpegel
        Dim iMax As MaximalPegelME_Data = Maximalpegel.Max_ME1
        Select Case Get_Messstelle()
            Case 2
                iMax = Maximalpegel.Max_ME2
            Case 3
                iMax = Maximalpegel.Max_ME3
        End Select
        'Grenzwerte welches Zeitraums relevant?
        Dim iMax_VF As Integer = iMax.GNacht_MAX_VF
        Dim iMax_RQ As Integer = iMax.GNacht_MAX_RQ
        If Me.DTP_Uhrzeit.Value.Hour >= 6 And Me.DTP_Uhrzeit.Value.Hour < 22 Then
            iMax_VF = iMax.GTag_MAX_VF
            iMax_RQ = iMax.GTag_MAX_RQ
        End If

        Dim gr As Graphics = e.Graphics

        If MainResults.Count > 0 Then

            'Herausfinden, welcher index der angegebenen gewünschten Zeit entspricht
            Dim i As Integer = Me.DTP_Uhrzeit.Value.Hour * 60 * 60 + Me.DTP_Uhrzeit.Value.Minute * 60

            Dim yMin As Integer = Me.NUD_P_max.Value - Me.NUD_P_Wertebereich.Value

            Dim y1 As Integer = yMin
            Dim yD As Integer = 10
            Dim pDiff As Integer = Me.NUD_P_Wertebereich.Value

            Dim j As Integer = 0
            Do While yMin + j * yD <= Me.NUD_P_max.Value
                Dim CurPeg As Integer = y1 + j * yD
                gr.DrawLine(Pens.Gray, 0, Get_Y(CurPeg), Me.Panel_Diagramm.Width, Get_Y(CurPeg))

                j = j + 1
            Loop



            For iSek As Integer = 0 To 900 - 1

                Dim pnts() As System.Drawing.PointF = Nothing
                Do While iSek < 900
                    If MainResults(i + iSek) = "" Then Exit Do
                    If MainResults(i + iSek).split(Chr(59))(1) = "" Then Exit Do

                    Dim iLen As Integer = 0
                    If Not IsNothing(pnts) Then iLen = pnts.Length
                    ReDim Preserve pnts(iLen)
                    Dim tmpStr As String = MainResults(i + iSek).ToString

                    pnts(iLen) = New System.Drawing.PointF(iSek, Get_Y(MainResults(i + iSek).ToString.Split(";")(1).Replace(".", ",")))
                    iSek = iSek + 1
                Loop
                If Not IsNothing(pnts) Then If pnts.Length > 1 Then gr.DrawLines(Pens.Black, pnts)
            Next


            If bKuFi Then
                'VF()
                For iSek As Integer = 0 To 900 - 1

                    Dim pnts() As System.Drawing.PointF = Nothing
                    Do While iSek < 900
                        If MainResults(i + iSek) = "" Then Exit Do
                        'Dim tStr As String = MainResults(i + iSek)
                        If MainResults(i + iSek).ToString.Split(";")(2) = "" Then Exit Do
                        If CByte(MainResults(i + iSek).ToString.Split(";")(2)) <> 1 And CByte(MainResults(i + iSek).ToString.Split(";")(2)) <> 3 Then Exit Do

                        Dim iLen As Integer = 0
                        If Not IsNothing(pnts) Then iLen = pnts.Length
                        ReDim Preserve pnts(iLen)
                        Dim tmpStr As String = MainResults(i + iSek).ToString

                        pnts(iLen) = New System.Drawing.PointF(iSek, Get_Y(MainResults(i + iSek).ToString.Split(";")(1).Replace(".", ",")))
                        iSek = iSek + 1
                    Loop
                    If Not IsNothing(pnts) Then If pnts.Length > 1 Then gr.DrawLines(Pens.Red, pnts)
                Next

                'RQ
                For iSek As Integer = 0 To 900 - 1

                    Dim pnts() As System.Drawing.PointF = Nothing
                    Do While iSek < 900
                        If MainResults(i + iSek) = "" Then Exit Do
                        If MainResults(i + iSek).ToString.Split(";")(2) = "" Then Exit Do
                        If CByte(MainResults(i + iSek).ToString.Split(";")(2)) <> 2 And CByte(MainResults(i + iSek).ToString.Split(";")(2)) <> 3 Then Exit Do

                        Dim iLen As Integer = 0
                        If Not IsNothing(pnts) Then iLen = pnts.Length
                        ReDim Preserve pnts(iLen)
                        Dim tmpStr As String = MainResults(i + iSek).ToString

                        pnts(iLen) = New System.Drawing.PointF(iSek, Get_Y(MainResults(i + iSek).ToString.Split(";")(1).Replace(".", ",")))
                        iSek = iSek + 1
                    Loop
                    If Not IsNothing(pnts) Then If pnts.Length > 1 Then gr.DrawLines(Pens.Blue, pnts)
                    If Not IsNothing(pnts) Then If pnts.Length = 1 Then gr.DrawEllipse(Pens.Blue, pnts(0).X, pnts(0).Y, 1, 1)
                Next

                Dim penBlue As New Pen(Color.Blue, 3)
                Dim penRed As New Pen(Color.Red, 3)
                If iMax_VF <> iMax_RQ Then gr.DrawLine(penRed, 0, Get_Y(iMax_VF), 900, Get_Y(iMax_VF))
                If iMax_VF <> iMax_RQ Then gr.DrawLine(penBlue, 0, Get_Y(iMax_RQ), 900, Get_Y(iMax_RQ))

                If iMax_VF = iMax_RQ Then
                    For iSe As Integer = 0 To 29
                        gr.DrawLine(penRed, iSe * 30, Get_Y(iMax_VF), iSe * 30 + 15, Get_Y(iMax_VF))
                        gr.DrawLine(penBlue, iSe * 30 + 15, Get_Y(iMax_VF), iSe * 30 + 30, Get_Y(iMax_VF))
                    Next
                End If
            End If
        End If
    End Sub

    Private Sub DTP_1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTP_1.ValueChanged
        Aktuallisieren(True)
    End Sub

    Private Sub UserControl_Messpunkte_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        selectedDate = Me.DTP_1.Value
    End Sub

    Private Sub Panel_Legende_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel_Legende.Paint
        Dim gr As Graphics = e.Graphics

        'gr.DrawLine(Pens.Black, 10, 8, 35, 8)
        gr.DrawLine(Pens.Red, 10, 27, 35, 27)
        gr.DrawLine(Pens.Blue, 10, 42, 35, 42)

    End Sub

    'Private Sub NUD_h_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles NUD_h.Scroll
    '    If e.OldValue < e.NewValue Then
    '        Me.DTP_Uhrzeit.Value = Me.DTP_Uhrzeit.Value.AddHours(1)
    '    Else
    '        Me.DTP_Uhrzeit.Value = Me.DTP_Uhrzeit.Value.AddHours(-1)
    '    End If
    'End Sub


    'Private Sub NUD_Min_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles NUD_Min.Scroll
    '    If e.OldValue < e.NewValue Then
    '        Me.DTP_Uhrzeit.Value = Me.DTP_Uhrzeit.Value.AddMinutes(15)
    '    Else
    '        Me.DTP_Uhrzeit.Value = Me.DTP_Uhrzeit.Value.AddMinutes(-15)
    '    End If
    'End Sub

    Private Sub NUD_h_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUD_h.ValueChanged
        
        If bUhrzeitUpdate = False Then
            bUhrzeitUpdate = True
            If Me.NUD_h.Value = -1 Then Me.NUD_h.Value = 23
            If Me.NUD_h.Value = 24 Then Me.NUD_h.Value = 0

            Dim tDate As Date = Me.DTP_Uhrzeit.Value
            Me.DTP_Uhrzeit.Value = tDate.AddHours(-(tDate.Hour - Me.NUD_h.Value)) ', me.DTP_Uhrzeit.Value
            bUhrzeitUpdate = False
        End If
    End Sub

    'Private Sub NUD_Min_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If bUhrzeitUpdate = True Then

    '        Dim tDate As Date = Me.DTP_Uhrzeit.Value
    '        Me.DTP_Uhrzeit.Value = tDate.AddMinutes(-(tDate.Minute - Me.NUD_Min.Value)) ', me.DTP_Uhrzeit.Value
    '    End If
    'End Sub
End Class
