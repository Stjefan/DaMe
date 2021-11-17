Public Class UC_Warnstufe
    Public sTyp As String
    Private sTypNode As String
    Private iSNr As Integer
    'Public ndSchwelle As XmlNode
    Private bLoad As Boolean

    Private Sub UC_Warnstufe_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If sTyp = "RK" Then
            sTypNode = "Schwellen_RK"
        ElseIf sTyp = "SP" Then
            sTypNode = "Schwellen_SP"
        End If

        iSNr = Me.Label_Schwelle.Text.Replace("Stufe ", "") - 1

        For i As Integer = 0 To 23
            Dim ctr As NumericUpDown = CType(Me.Controls.Find("NUD_proz_" & i, True)(0), NumericUpDown)
            AddHandler ctr.ValueChanged, AddressOf NUD_proz_ValueChanged
        Next

        Update_Anzeige() '    If Not IsNothing(ndSchwelle) Then

    End Sub

    Private Sub Button_Remove_Warn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Remove_Warn.Click

        ndAllgemein.Item(sTypNode).RemoveChild( _
                ndAllgemein.Item(sTypNode).ChildNodes(iSNr))

        Update_Anzeige_Einstellungen_Schwellen()

    End Sub
    Private Sub NUD_Proz_Col(ByVal tNUD As NumericUpDown, ByVal tVal As Single, ByVal prevVal As Single)
        If prevVal <= tVal Then
            tNUD.BackColor = System.Drawing.Color.OrangeRed
        Else
            tNUD.BackColor = System.Drawing.SystemColors.Window
        End If
    End Sub
    Private Sub NUD_proz_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles NUD_proz_0.ValueChanged
        'If bLoad = False Then
        Dim tNUD As NumericUpDown = CType(sender, NumericUpDown)
        Dim iH As Integer = CInt(tNUD.Name.Replace("NUD_proz_", ""))
        Dim iAr As Integer = Me.Parent.Controls.Count - Me.Parent.Controls.GetChildIndex(Me) - 1

        With ndAllgemein.Item(sTypNode).ChildNodes(iSNr)
            Dim sHour As String = "H0"

            Select Case iH
                Case 0
                    If bLoad = False Then .Attributes("H0").Value = Me.NUD_proz_0.Value
                    sHour = "H0"
                Case 1
                    If bLoad = False Then .Attributes("H1").Value = Me.NUD_proz_1.Value
                    sHour = "H1"
                Case 2
                    If bLoad = False Then .Attributes("H2").Value = Me.NUD_proz_2.Value
                    sHour = "H2"
                Case 3
                    If bLoad = False Then .Attributes("H3").Value = Me.NUD_proz_3.Value
                    sHour = "H3"
                Case 4
                    If bLoad = False Then .Attributes("H4").Value = Me.NUD_proz_4.Value
                    sHour = "H4"
                Case 5
                    If bLoad = False Then .Attributes("H5").Value = Me.NUD_proz_5.Value
                    sHour = "H5"
                Case 6
                    If bLoad = False Then .Attributes("H6").Value = Me.NUD_proz_6.Value
                    sHour = "H6"
                Case 7
                    If bLoad = False Then .Attributes("H7").Value = Me.NUD_proz_7.Value
                    sHour = "H7"
                Case 8
                    If bLoad = False Then .Attributes("H8").Value = Me.NUD_proz_8.Value
                    sHour = "H8"
                Case 9
                    If bLoad = False Then .Attributes("H9").Value = Me.NUD_proz_9.Value
                    sHour = "H9"
                Case 10
                    If bLoad = False Then .Attributes("H10").Value = Me.NUD_proz_10.Value
                    sHour = "H10"
                Case 11
                    If bLoad = False Then .Attributes("H11").Value = Me.NUD_proz_11.Value
                    sHour = "H11"
                Case 12
                    If bLoad = False Then .Attributes("H12").Value = Me.NUD_proz_12.Value
                    sHour = "H12"
                Case 13
                    If bLoad = False Then .Attributes("H13").Value = Me.NUD_proz_13.Value
                    sHour = "H13"
                Case 14
                    If bLoad = False Then .Attributes("H14").Value = Me.NUD_proz_14.Value
                    sHour = "H14"
                Case 15
                    If bLoad = False Then .Attributes("H15").Value = Me.NUD_proz_15.Value
                    sHour = "H15"
                Case 16
                    If bLoad = False Then .Attributes("H16").Value = Me.NUD_proz_16.Value
                    sHour = "H16"
                Case 17
                    If bLoad = False Then .Attributes("H17").Value = Me.NUD_proz_17.Value
                    sHour = "H17"
                Case 18
                    If bLoad = False Then .Attributes("H18").Value = Me.NUD_proz_18.Value
                    sHour = "H18"
                Case 19
                    If bLoad = False Then .Attributes("H19").Value = Me.NUD_proz_19.Value
                    sHour = "H19"
                Case 20
                    If bLoad = False Then .Attributes("H20").Value = Me.NUD_proz_20.Value
                    sHour = "H20"
                Case 21
                    If bLoad = False Then .Attributes("H21").Value = Me.NUD_proz_21.Value
                    sHour = "H21"
                Case 22
                    If bLoad = False Then .Attributes("H22").Value = Me.NUD_proz_22.Value
                    sHour = "H22"
                Case 23
                    If bLoad = False Then .Attributes("H23").Value = Me.NUD_proz_23.Value
                    sHour = "H23"
            End Select

            If iSNr > 0 Then NUD_Proz_Col(tNUD, .Attributes(sHour).Value, ndAllgemein.Item(sTypNode).ChildNodes(iSNr - 1).Attributes(sHour).Value)
            If iSNr < ndAllgemein.Item(sTypNode).ChildNodes.Count - 1 Then
                Dim nextWarnstufe As UC_Warnstufe = CType(Me.Parent.Controls(Me.Parent.Controls.GetChildIndex(Me) - 1), UC_Warnstufe)
                Dim nextNUD As NumericUpDown = CType(nextWarnstufe.Controls.Find("NUD_proz_" & iH, True)(0), NumericUpDown)

                NUD_Proz_Col(nextNUD, ndAllgemein.Item(sTypNode).ChildNodes(iSNr + 1).Attributes(sHour).Value, .Attributes(sHour).Value)
            End If

            'Daten_Allgemein_Speichern()
        End With
        'End If
    End Sub

    Public Sub Update_Anzeige()
        bLoad = True
        With ndAllgemein.Item(sTypNode).ChildNodes(iSNr)
            Me.NUD_proz_0.Value = .Attributes("H0").Value  'My.Settings.ProzSchwelle_0
            Me.NUD_proz_1.Value = .Attributes("H1").Value '
            Me.NUD_proz_2.Value = .Attributes("H2").Value
            Me.NUD_proz_3.Value = .Attributes("H3").Value
            Me.NUD_proz_4.Value = .Attributes("H4").Value
            Me.NUD_proz_5.Value = .Attributes("H5").Value
            Me.NUD_proz_6.Value = .Attributes("H6").Value
            Me.NUD_proz_7.Value = .Attributes("H7").Value
            Me.NUD_proz_8.Value = .Attributes("H8").Value
            Me.NUD_proz_9.Value = .Attributes("H9").Value
            Me.NUD_proz_10.Value = .Attributes("H10").Value
            Me.NUD_proz_11.Value = .Attributes("H11").Value
            Me.NUD_proz_12.Value = .Attributes("H12").Value
            Me.NUD_proz_13.Value = .Attributes("H13").Value
            Me.NUD_proz_14.Value = .Attributes("H14").Value
            Me.NUD_proz_15.Value = .Attributes("H15").Value
            Me.NUD_proz_16.Value = .Attributes("H16").Value
            Me.NUD_proz_17.Value = .Attributes("H17").Value
            Me.NUD_proz_18.Value = .Attributes("H18").Value
            Me.NUD_proz_19.Value = .Attributes("H19").Value
            Me.NUD_proz_20.Value = .Attributes("H20").Value
            Me.NUD_proz_21.Value = .Attributes("H21").Value
            Me.NUD_proz_22.Value = .Attributes("H22").Value
            Me.NUD_proz_23.Value = .Attributes("H23").Value

            Me.NUD_Verteiler.Value = .Attributes("Verteiler").Value
            Me.ChB_Sperrung.Checked = .Attributes("bSperrung").Value
            Me.TB_Streckenmitteilung.Text = .Attributes("Mitteilung").Value
        End With
        bLoad = False
    End Sub

    Private Sub NUD_Verteiler_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUD_Verteiler.ValueChanged
        'Dim iAr As Integer = Me.Parent.Controls.Count - Me.Parent.Controls.GetChildIndex(Me) - 1
        ndAllgemein.Item(sTypNode).ChildNodes(iSNr).Attributes("Verteiler").Value = Me.NUD_Verteiler.Value
        'Daten_Allgemein_Speichern()
    End Sub

    Private Sub ChB_Sperrung_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChB_Sperrung.CheckedChanged
        'Dim iAr As Integer = Me.Parent.Controls.Count - Me.Parent.Controls.GetChildIndex(Me) - 1
        ndAllgemein.Item(sTypNode).ChildNodes(iSNr).Attributes("bSperrung").Value = Me.ChB_Sperrung.Checked
        'Daten_Allgemein_Speichern()
    End Sub

    Private Sub TB_Streckenmitteilung_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_Streckenmitteilung.TextChanged
        'Dim iAr As Integer = Me.Parent.Controls.Count - Me.Parent.Controls.GetChildIndex(Me) - 1
        ndAllgemein.Item(sTypNode).ChildNodes(iSNr).Attributes("Mitteilung").Value = Me.TB_Streckenmitteilung.Text
        'Daten_Allgemein_Speichern()
    End Sub

    Private Sub Update_Anzeige_Einstellungen_Schwellen()
        Dim ctr As Control = Me.Parent
        Do Until TypeOf (ctr) Is UserControl_Einstellungen
            ctr = ctr.Parent
        Loop
        If TypeOf (ctr) Is UserControl_Einstellungen Then
            If sTyp = "RK" Then
                CType(ctr, UserControl_Einstellungen).Update_Schwellen_RK()
            ElseIf sTyp = "SP" Then
                CType(ctr, UserControl_Einstellungen).Update_Schwellen_SP()
            End If
        End If

    End Sub

    Private Sub Button_Hoch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Hoch.Click
        Dim iSNr As Integer = Me.Label_Schwelle.Text.Replace("Stufe ", "") - 1
        If iSNr > 0 Then
            With ndAllgemein.Item(sTypNode)
                .InsertBefore(.ChildNodes(iSNr), .ChildNodes(iSNr - 1))
            End With
        End If

        Update_Anzeige_Einstellungen_Schwellen()

    End Sub

    Private Sub Button_Runter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Runter.Click
        Dim iSNr As Integer = Me.Label_Schwelle.Text.Replace("Stufe ", "") - 1
        If iSNr < ndAllgemein.Item(sTypNode).ChildNodes.Count - 1 Then
            With ndAllgemein.Item(sTypNode)
                .InsertAfter(.ChildNodes(iSNr), .ChildNodes(iSNr + 1))
            End With
        End If

        Update_Anzeige_Einstellungen_Schwellen()

    End Sub
End Class
