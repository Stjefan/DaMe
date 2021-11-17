Option Strict Off

Public Class UserControl_Karte

    'Dim frm_koordSpeicher As New Form_KoordinatenSpeicher

    Dim bDown As Boolean
    'Dim bUebersicht As Boolean
    Dim ptMouse As System.Drawing.Point
    Dim ptMouseArea As System.Drawing.Point
    Dim dScaleKarte As Double
    'Dim dScaleLaerm As Double

    Public SQGroesse As Integer = 5

    'Public iTK As Integer
    'Public iSelPegel As Integer

    Public bGetPegel As Boolean
    Public ptGetPegel As System.Drawing.PointF = Nothing

    Public bShowImmi As Boolean


#Region "NEU"

    Private Sub UserControl_Karte_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        'Private Sub UserControl_Karte_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        Dim chTMP As Integer = AscW(e.KeyChar)

        If AscW(e.KeyChar) = 7 Then 'Strg + G
            If Dialog_Passwort.ShowDialog() = DialogResult.OK Then
                bShowImmi = True
            End If
            'ElseIf AscW(e.KeyChar) = 6 Then 'Strg + F


            'ElseIf AscW(e.KeyChar) = 20 Then 'Strg + T


            'ElseIf AscW(e.KeyChar) = 1 Then 'Strg + A

        End If
    End Sub

    Private Sub Form_Karten_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Messpunkt(0).GK.Rechts = 3493402
        'Messpunkt(0).GK.Hoch = 5412428
        Messpunkt(0).GK.Rechts = 3493296
        Messpunkt(0).GK.Hoch = 5411675
        Messpunkt(1).GK.Rechts = 3493274
        Messpunkt(1).GK.Hoch = 5412043
        Messpunkt(2).GK.Rechts = 3492864
        Messpunkt(2).GK.Hoch = 5412527

        bShowImmi = False

        'Pegeladdition = 0
        'iSelPegel = -1

        'If bGetPegel Then
        '    Show_Teilk_pt()
        'End If
        'If iTK = -1 Then
        '    If Not IsNothing(Karten.Uebersichtskarte.Pfad) Then
        '        Dim fio As New IO.FileInfo(stProjekt_Pfad & "\" & "Karten" & "\" & Karten.Uebersichtskarte.Pfad)
        '        'Karten.Uebersichtskarte.Pfad = stProjekt_Pfad & "\" & fio.Name

        '        If fio.Exists Then
        Show_Karte_Uebersicht()
        '        End If
        '    End If
        'iTK = -1
        'Else
        'Show_Karte_Teil(iTK)
        'Me.PictureBox_Karte.Cursor = Cursors.UpArrow
        'End If
    End Sub

    Private Sub ShowImmi(ByVal bShow As Boolean)
        bShowImmi = bShow

        If bShow Then
            Me.TSB_neuIOrt.Visible = True
            Me.TSB_KoordSpeicher.Visible = True
            Me.TSSB_Immissionsort.Visible = True

        Else
            Me.TSB_neuIOrt.Visible = False
            Me.TSB_KoordSpeicher.Visible = False
            Me.TSSB_Immissionsort.Visible = False

        End If
    End Sub
#Region "Events- Picturebox_Karte"

    Private Sub Panel_Karte_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel_Karte.MouseWheel
        Try
            Dim iDelta As Integer = e.Delta
            'e.X

            Dim sngskale As Single = Get_sngSkale_PicInPB(New System.Drawing.Point(Me.PictureBox_Karte.Width - iDelta, (Me.PictureBox_Karte.Width - iDelta) * Me.PictureBox_Karte.Height / Me.PictureBox_Karte.Width), New System.Drawing.Point(Me.PictureBox_Karte.Width, Me.PictureBox_Karte.Height))
            If sngskale > 0.02 Then 'skale>1 verkleinert, skale<1 vergrößert

                'With Karte

                Dim tmpGKd As System.Drawing.Point = Trafo_PX(New System.Drawing.Point(e.X, e.Y), Me.PictureBox_Karte.Width, IM_X_orig, GKH_A, GKR_A, q_GK_Pixel, alpha_GK_Pixel, PX_A, PY_A)
                Dim tmpGK As System.Drawing.PointF = New System.Drawing.PointF(Me.TSSL_Rechts.Text, Me.TSSL_Hoch.Text)
                Dim tmpPXAlt As System.Drawing.PointF '= New System.Drawing.PointF(e.X, e.Y)

                tmpPXAlt = Trafo_GK_PXaktuell(tmpGK.X, tmpGK.Y, Me.PictureBox_Karte.Width, IM_X_orig, PX_A, PY_A, q_Pixel_GK, alpha_Pixel_GK, GKR_A, GKH_A)

                Me.PictureBox_Karte.Width = CInt(Me.PictureBox_Karte.Width / sngskale) 'My.Resources._303307_Werksplan_01_07_2009_gesamt_fuer_Download.Width / sngSkale) '/ 10)  '700
                Me.PictureBox_Karte.Height = CInt(Me.PictureBox_Karte.Height / sngskale) 'My.Resources._303307_Werksplan_01_07_2009_gesamt_fuer_Download.Height / sngSkale) '/ 10) '540

                Dim tmpPXNeu As System.Drawing.Point
                tmpPXNeu = Trafo_GK_PXaktuell(tmpGK.X, tmpGK.Y, Me.PictureBox_Karte.Width, IM_X_orig, PX_A, PY_A, q_Pixel_GK, alpha_Pixel_GK, GKR_A, GKH_A)

                Me.PictureBox_Karte.Location = New System.Drawing.Point(Me.PictureBox_Karte.Location.X + tmpPXAlt.X - tmpPXNeu.X, Me.PictureBox_Karte.Location.Y + tmpPXAlt.Y - tmpPXNeu.Y)
                'End With
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub PictureBox_Karte_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox_Karte.MouseDown
        bDown = True
        ptMouse.X = e.X
        ptMouse.Y = e.Y
    End Sub
    Private Sub PictureBox_Karte_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox_Karte.MouseMove
        If bDown Then
            If Me.PictureBox_Karte.Cursor = Cursors.Hand Then
                Dim pt As New System.Drawing.Point
                pt.X = Me.PictureBox_Karte.Location.X + (e.X - ptMouse.X) 'e.Delta
                pt.Y = Me.PictureBox_Karte.Location.Y + (e.Y - ptMouse.Y)

                Me.PictureBox_Karte.Location = pt
                ptMouse.X = e.X
                ptMouse.Y = e.Y
            ElseIf Me.PictureBox_Karte.Cursor = Cursors.Cross Then
                ptMouseArea.X = e.X - ptMouse.X
                ptMouseArea.Y = e.Y - ptMouse.Y
            End If
        End If

        If Not IsNothing(Me.PictureBox_Karte.BackgroundImage) Then
            'With Karte 'n.Uebersichtskarte
            Dim tmpGK As System.Drawing.Point = Trafo_PX(New System.Drawing.Point(e.X, e.Y), Me.PictureBox_Karte.Width, IM_X_orig, GKH_A, GKR_A, q_GK_Pixel, alpha_GK_Pixel, PX_A, PY_A)
            Me.TSSL_Rechts.Text = tmpGK.X
            Me.TSSL_Hoch.Text = tmpGK.Y
            'End With
        End If

        PictureBox_Karte.Invalidate()
    End Sub
    Private Sub PictureBox_Karte_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox_Karte.MouseUp
        bDown = False

        If Me.PictureBox_Karte.Cursor = Cursors.Cross Then
            Dim sngSkale As Single = Get_sngSkale_PicInPB(New System.Drawing.Point(ptMouseArea.X, ptMouseArea.Y), New System.Drawing.Point(Me.Panel_Karte.Width, Me.Panel_Karte.Height))
            If sngSkale > 0.02 Then
                Me.PictureBox_Karte.Width = CInt(Me.PictureBox_Karte.Width / sngSkale) 'My.Resources._303307_Werksplan_01_07_2009_gesamt_fuer_Download.Width / sngSkale) '/ 10)  '700
                Me.PictureBox_Karte.Height = CInt(Me.PictureBox_Karte.Height / sngSkale) 'My.Resources._303307_Werksplan_01_07_2009_gesamt_fuer_Download.Height / sngSkale) '/ 10) '540
                Me.PictureBox_Karte.Location = New System.Drawing.Point(-ptMouse.X / sngSkale, -ptMouse.Y / sngSkale)
            End If
            ptMouseArea.X = 0
            ptMouseArea.Y = 0
        ElseIf Me.PictureBox_Karte.Cursor = Cursors.UpArrow Then
            Dim fio As IO.FileInfo = New IO.FileInfo(My.Settings.PfadZielordner & "\ES.DAT")
            
            'With Karte
            Dim tmpGK As System.Drawing.Point = Trafo_PX(New System.Drawing.Point(e.X, e.Y), Me.PictureBox_Karte.Width, IM_X_orig, GKH_A, GKR_A, q_GK_Pixel, alpha_GK_Pixel, PX_A, PY_A)

            Dialog_Immissionsort.iCurIO = -1
            Dialog_Immissionsort.ptKoordinaten.X = tmpGK.X 'Rechts
            Dialog_Immissionsort.ptKoordinaten.Y = tmpGK.Y 'Hoch
            Dialog_Immissionsort.ShowDialog()
            'End With
            'End If
        End If
    End Sub

    Private Sub PictureBox_Karte_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox_Karte.MouseEnter
        Me.Panel_Karte.Focus()
    End Sub

    Private Sub PictureBox_Karte_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PictureBox_Karte.Paint
        Dim pn1 As New Pen(Color.Turquoise)
        pn1.Width = 4
        Dim pn2 As New Pen(Color.Magenta)
        pn2.Width = 4
        Dim pn3 As New Pen(Color.Green)
        pn3.Width = 4

        Dim gr As Graphics = e.Graphics

        'Fenster aufziehen zum Vergrößern
        If Me.PictureBox_Karte.Cursor = Cursors.Cross Then
            Dim brs As Brush
            brs = New SolidBrush(Color.FromArgb(50, 100, 100, 100))
            gr.FillRectangle(brs, ptMouse.X, ptMouse.Y, ptMouseArea.X, ptMouseArea.Y)
        End If

        If Not IsNothing(Me.PictureBox_Karte.BackgroundImage) Then
            '## Fadenkreuze zeichnen
            'blau->pixel
            Dim pt As System.Drawing.Point = Me.PictureBox_Karte.PointToClient(Control.MousePosition)
            gr.DrawLine(Pens.DarkBlue, 0, pt.Y, Me.PictureBox_Karte.Width, pt.Y)
            gr.DrawLine(Pens.DarkBlue, pt.X, 0, pt.X, Me.PictureBox_Karte.Height)

            'yellowgreen->gk
            Dim GK0 As System.Drawing.Point
            Dim PX1 As System.Drawing.Point
            Dim PX2 As System.Drawing.Point
            Dim PX3 As System.Drawing.Point
            Dim PX4 As System.Drawing.Point

            'With Karte 'n.Uebersichtskarte
            GK0 = Trafo_PX(pt, Me.PictureBox_Karte.Width, IM_X_orig, GKH_A, GKR_A, q_GK_Pixel, alpha_GK_Pixel, PX_A, PY_A)
            PX1 = Trafo_GK_PXaktuell(GK0.X - 10000, GK0.Y, Me.PictureBox_Karte.Width, IM_X_orig, PX_A, PY_A, q_Pixel_GK, alpha_Pixel_GK, GKR_A, GKH_A)
            PX2 = Trafo_GK_PXaktuell(GK0.X, GK0.Y - 10000, Me.PictureBox_Karte.Width, IM_X_orig, PX_A, PY_A, q_Pixel_GK, alpha_Pixel_GK, GKR_A, GKH_A)
            PX3 = Trafo_GK_PXaktuell(GK0.X + 10000, GK0.Y, Me.PictureBox_Karte.Width, IM_X_orig, PX_A, PY_A, q_Pixel_GK, alpha_Pixel_GK, GKR_A, GKH_A)
            PX4 = Trafo_GK_PXaktuell(GK0.X, GK0.Y + 10000, Me.PictureBox_Karte.Width, IM_X_orig, PX_A, PY_A, q_Pixel_GK, alpha_Pixel_GK, GKR_A, GKH_A)

            gr.DrawLine(Pens.YellowGreen, PX1.X, PX1.Y, PX3.X, PX3.Y)
            gr.DrawLine(Pens.YellowGreen, PX2.X, PX2.Y, PX4.X, PX4.Y)

            '## Messpunkte zeichnen

            PX1 = Trafo_GK_PXaktuell(Messpunkt(0).GK.Rechts, Messpunkt(0).GK.Hoch, Me.PictureBox_Karte.Width, IM_X_orig, PX_A, PY_A, q_Pixel_GK, alpha_Pixel_GK, GKR_A, GKH_A)
            gr.FillEllipse(Brushes.Green, PX1.X - 3, PX1.Y - 3, 7, 7)
            gr.DrawString("Bau 73: ME 3", New System.Drawing.Font("Arial", 11, FontStyle.Bold), Brushes.Black, PX1.X, PX1.Y)

            PX2 = Trafo_GK_PXaktuell(Messpunkt(1).GK.Rechts, Messpunkt(1).GK.Hoch, Me.PictureBox_Karte.Width, IM_X_orig, PX_A, PY_A, q_Pixel_GK, alpha_Pixel_GK, GKR_A, GKH_A)
            gr.FillEllipse(Brushes.Green, PX2.X - 3, PX2.Y - 3, 7, 7)
            gr.DrawString("Bau 11: ME 2", New System.Drawing.Font("Arial", 11, FontStyle.Bold), Brushes.Black, PX2.X, PX2.Y)

            PX3 = Trafo_GK_PXaktuell(Messpunkt(2).GK.Rechts, Messpunkt(2).GK.Hoch, Me.PictureBox_Karte.Width, IM_X_orig, PX_A, PY_A, q_Pixel_GK, alpha_Pixel_GK, GKR_A, GKH_A)
            gr.FillEllipse(Brushes.Green, PX3.X - 3, PX3.Y - 3, 7, 7)
            gr.DrawString("Bau 50: ME 1", New System.Drawing.Font("Arial", 11, FontStyle.Bold), Brushes.Black, PX3.X, PX3.Y)


            '## Immissionsorte zeichnen
            If bShowImmi Then

            End If
            'End With
        End If

    End Sub
#End Region

#Region "Karten-Toolstripe-Fkten"

    Private Sub TSB_Hand_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TSB_Hand.CheckedChanged
        If Me.TSB_Hand.Checked Then
            Me.TSB_Arrow.Checked = False
            Me.TSB_KoordSpeicher.Checked = False
            Me.TSB_Rahmen.Checked = False
            Me.TSB_neuIOrt.Checked = False
        End If
    End Sub
    Private Sub TSB_Hand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSB_Hand.Click
        Me.PictureBox_Karte.Cursor = Cursors.Hand
    End Sub

    Private Sub TSB_Rahmen_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TSB_Rahmen.CheckedChanged
        If Me.TSB_Rahmen.Checked Then
            Me.TSB_Arrow.Checked = False
            Me.TSB_KoordSpeicher.Checked = False
            Me.TSB_Hand.Checked = False
            Me.TSB_neuIOrt.Checked = False
        End If
    End Sub

    Private Sub TSB_Rahmen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSB_Rahmen.Click
        Me.PictureBox_Karte.Cursor = Cursors.Cross
    End Sub

    Private Sub TSB_Arrow_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TSB_Arrow.CheckedChanged
        If Me.TSB_Arrow.Checked Then
            Me.TSB_Rahmen.Checked = False
            Me.TSB_KoordSpeicher.Checked = False
            Me.TSB_Hand.Checked = False
            Me.TSB_neuIOrt.Checked = False
        End If
    End Sub

    Private Sub TSB_Arrow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSB_Arrow.Click
        Me.PictureBox_Karte.Cursor = Cursors.Default
    End Sub

    Private Sub TSB_KoordSpeicher_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TSB_KoordSpeicher.CheckedChanged
        If Me.TSB_KoordSpeicher.Checked Then
            Me.TSB_Rahmen.Checked = False
            Me.TSB_Arrow.Checked = False
            Me.TSB_Hand.Checked = False
            Me.TSB_neuIOrt.Checked = False
        End If
    End Sub
    Private Sub TSB_KoordSpeicher_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSB_KoordSpeicher.Click
        Me.PictureBox_Karte.Cursor = Cursors.Help
    End Sub

    Private Sub TSB_neuIOrt_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSB_neuIOrt.CheckedChanged

        If Me.TSB_neuIOrt.Checked Then
            Me.TSB_KoordSpeicher.Checked = False
            Me.TSB_Rahmen.Checked = False
            Me.TSB_Arrow.Checked = False
            Me.TSB_Hand.Checked = False
        End If
    End Sub
    Private Sub TSB_neuIOrt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSB_neuIOrt.Click
        Me.PictureBox_Karte.Cursor = Cursors.UpArrow
    End Sub

    'Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar1.Scroll
    '    SQGroesse = Me.TrackBar1.Value
    '    Me.PictureBox_Karte.Invalidate()
    'End Sub
#End Region

    Private Sub Show_Karte_Uebersicht() '(ByVal IXWerk As Integer)
        Dim img As Image = My.Resources.soundplan_export

        Dim sngSkale As Single = Get_sngSkale_PicInPB(New System.Drawing.Point(img.Width, img.Height), New System.Drawing.Point(Me.Panel_Karte.Width, Me.Panel_Karte.Height))

        Me.PictureBox_Karte.Width = CInt(img.Width / sngSkale) 'My.Resources._303307_Werksplan_01_07_2009_gesamt_fuer_Download.Width / sngSkale) '/ 10)  '700
        Me.PictureBox_Karte.Height = CInt(img.Height / sngSkale) 'My.Resources._303307_Werksplan_01_07_2009_gesamt_fuer_Download.Height / sngSkale) '/ 10) '540
        Me.PictureBox_Karte.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox_Karte.BackgroundImage = img 'My.Resources._303307_Werksplan_01_07_2009_gesamt_fuer_Download
    End Sub

    Private Function Get_sngSkale_PicInPB(ByVal picSize As System.Drawing.Point, ByVal pbSize As System.Drawing.Point) As Single

        If picSize.X / pbSize.X < picSize.Y / pbSize.Y Then
            Get_sngSkale_PicInPB = CSng(picSize.Y / pbSize.Y)
        Else
            Get_sngSkale_PicInPB = CSng(picSize.X / pbSize.X)
        End If
    End Function

#End Region

#Region "Karten/Pläne GK/Pixel"
    Public Function Trafo_PX(ByVal Pkt_PX As System.Drawing.Point, ByVal IM_X_aktuell As Integer, ByVal IM_X_original As Integer, _
            ByVal GKH_A As Single, ByVal GKR_A As Single, _
            ByVal q_GK_Pixel As Double, ByVal alpha_GK_Pixel As Double, _
            ByVal PX_A As Integer, ByVal PY_A As Integer) As System.Drawing.Point
        'PX_A/PY_A = Pixelpkt in Karte mit Originalgröße

        Dim ratio As Double = IM_X_original / IM_X_aktuell
        Dim dHoch As Double = CDbl(((GKH_A + q_GK_Pixel * Math.Sin(alpha_GK_Pixel) * (Pkt_PX.Y * ratio - PY_A) + _
        q_GK_Pixel * Math.Cos(alpha_GK_Pixel) * (Pkt_PX.X * ratio - PX_A))) * 100) / 100
        Dim dRechts As Double = CDbl(((GKR_A + q_GK_Pixel * Math.Cos(alpha_GK_Pixel) * (Pkt_PX.Y * ratio - PY_A) - _
        q_GK_Pixel * Math.Sin(alpha_GK_Pixel) * (Pkt_PX.X * ratio - PX_A))) * 100) / 100

        Trafo_PX.Y = CInt(dHoch * 100) / 100
        Trafo_PX.X = CInt(dRechts * 100) / 100
    End Function
    Public Function Trafo_GK_PXaktuell(ByVal Rechts As Single, ByVal Hoch As Single, ByVal IM_X_aktuell As Integer, ByVal IM_X_original As Integer, _
            ByVal PX_A As Integer, ByVal PY_A As Integer, _
            ByVal q_Pixel_GK As Single, ByVal alpha_Pixel_GK As Single, _
            ByVal GKR_A As Single, ByVal GKH_A As Single) As System.Drawing.Point

        Try
            Dim ratio As Double = IM_X_aktuell / IM_X_original
            Dim iX As Integer = CInt(PX_A + q_Pixel_GK * Math.Sin(alpha_Pixel_GK) * (Rechts - GKR_A) + _
            q_Pixel_GK * Math.Cos(alpha_Pixel_GK) * (Hoch - GKH_A))
            Dim iY As Integer = CInt(PY_A + q_Pixel_GK * Math.Cos(alpha_Pixel_GK) * (Rechts - GKR_A) - _
            q_Pixel_GK * Math.Sin(alpha_Pixel_GK) * (Hoch - GKH_A))

            Trafo_GK_PXaktuell.X = iX * ratio
            Trafo_GK_PXaktuell.Y = iY * ratio

            'Return New Point(CInt(Rechts * Me.PictureBox_Karte.Width / My.Resources._009_Dachaufsicht.Width), _
            '    CInt(Hoch * Me.PictureBox_Karte.Height / My.Resources._009_Dachaufsicht.Height))
        Catch ex As Exception

        End Try
    End Function

#End Region


 
    Private Sub TSB_Entsprerren_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSB_Entsprerren.Click
        If Dialog_Passwort.ShowDialog() = DialogResult.OK Then
            ShowImmi(True)
        End If
    End Sub

    Private Sub TSSB_Immissionsort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSSB_Immissionsort.Click
        'Dim fio As IO.FileInfo = New IO.FileInfo(My.Settings.PfadZielordner & "\ES.DAT")


        'If fio.Exists = False Then
        '    MsgBox("Die Datei für Berechnungsparameter kann unter folgendem Pfad nicht gefunden werden: " & Chr(13) & Chr(10), MsgBoxStyle.OkOnly, "Fehlermeldung")
        'Else
        Dialog_Immissionsort.iCurIO = -1
        Dialog_Immissionsort.ptKoordinaten.X = 0 ' tmpGK.X 'Rechts
        Dialog_Immissionsort.ptKoordinaten.Y = 0 'tmpGK.Y 'Hoch
        Dialog_Immissionsort.ShowDialog()
        'End If
    End Sub

    Private Sub PictureBox_Karte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox_Karte.Click

    End Sub

    Private Sub ToolStrip2_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ToolStrip2.ItemClicked

    End Sub

    Private Sub ToolStrip2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ToolStrip2.KeyPress
        Dim tChar As Char = e.KeyChar
    End Sub
End Class