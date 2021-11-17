
Imports System.Net.Mail

Public Class UserControl_Einstellungen

    Dim bLoad As Boolean = True

    Private Sub Button_Pfad_Zielordner_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Pfad_Zielordner.Click
        Me.FBD_Messpfade.SelectedPath = Me.TB_Pfad_Zielordner.Text
        If Me.FBD_Messpfade.ShowDialog() = DialogResult.OK Then
            Me.TB_Pfad_Zielordner.Text = Me.FBD_Messpfade.SelectedPath
        End If
    End Sub
    Private Sub Einstellungen_Enable(ByVal bEnable As Boolean)
        'Me.Panel_Archivierung.Enabled = bEnable
        Me.NUD_Archivierung_Monate.Enabled = bEnable
        Me.NUD_archivKompressionsLevel.Enabled = bEnable
        Me.TB_Archivierung_Pfad.Enabled = bEnable
        Me.Button_Archivierung_Pfad.Enabled = bEnable

        'Me.Panel_Dateiablage.Enabled = bEnable
        Me.TB_DateiablageStreckeninfo.Enabled = bEnable
        Me.Button_DateiablageStreckeninfo.Enabled = bEnable

        'Me.Panel_Monatsbericht.Enabled = bEnable
        Me.ChB_autoMonatsbericht.Enabled = bEnable

        '# Alarm-Meldungen: EMAIL
        Me.TB_SMTPServer.Enabled = bEnable
        Me.TB_LoginName.Enabled = bEnable
        Me.TB_Passwort.Enabled = bEnable
        Me.TB_Sender.Enabled = bEnable
        Me.ChB_Wochenende.Enabled = bEnable
        Me.NUD_SendeIntervall.Enabled = bEnable
        For i As Integer = 0 To Me.Panel_Empfaenger.Controls.Count - 1
            Me.Panel_Empfaenger.Controls(i).Enabled = bEnable
        Next

        Me.Button_Add_Schwelle_RK.Enabled = bEnable
        For i As Integer = 0 To Me.Panel_Schwellen_RK.Controls.Count - 1
            Me.Panel_Schwellen_RK.Controls(i).Enabled = bEnable
        Next
        Me.Button_Add_Schwelle_SP.Enabled = bEnable
        For i As Integer = 0 To Me.Panel_Schwellen_SP.Controls.Count - 1
            Me.Panel_Schwellen_SP.Controls(i).Enabled = bEnable
        Next

        'Me.Panel_Alarm_MaxWert.Enabled = bEnable
        Me.NUD_Max_Verteiler.Enabled = bEnable
        Me.NUD_Sperrung_Max_tags.Enabled = bEnable
        Me.NUD_Sperrung_Max_nachts.Enabled = bEnable
        Me.TB_Max_Sperrung_Mitteilung.Enabled = bEnable

        'Me.Panel_Alarm_fehlerWerte.Enabled = bEnable
        Me.NUD_Fehler_Verteiler.Enabled = bEnable
    End Sub

    Private Sub UserControl_Einstellungen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        bLoad = True


        Me.TB_Pfad_Zielordner.Text = My.Settings.PfadZielordner
        Me.NUD_SekWetter.Value = My.Settings.SekWetter

        If My.Settings.PfadZielordner <> "" Then
            If New IO.DirectoryInfo(My.Settings.PfadZielordner).Exists Then

                '  Daten_Alarm_einlesen()'<- wird immer erledigt, wenn TB_Pfad_Zielordner geändert wird!!

                If Allgemein.Stand > Me.DTP_Stand.MinDate Then Me.DTP_Stand.Value = Allgemein.Stand

                Dim tmpNDAllgemein As XmlNode = ndAllgemein

                If ndAllgemein.Attributes("archivMonate").Value = "" Then ndAllgemein.Attributes("archivMonate").Value = "24"
                If ndAllgemein.Attributes("archivMonate").Value < Me.NUD_Archivierung_Monate.Minimum Then
                    Me.NUD_Archivierung_Monate.Value = 24
                Else
                    Me.NUD_Archivierung_Monate.Value = ndAllgemein.Attributes("archivMonate").Value 'My.Settings.bAutoMonatsbericht
                End If
                If ndAllgemein.Attributes("archivKompressionsLevel").Value = "" Then ndAllgemein.Attributes("archivKompressionsLevel").Value = "5"
                If ndAllgemein.Attributes("archivKompressionsLevel").Value < Me.NUD_archivKompressionsLevel.Minimum Then
                    Me.NUD_archivKompressionsLevel.Value = 5
                Else
                    Me.NUD_archivKompressionsLevel.Value = ndAllgemein.Attributes("archivKompressionsLevel").Value
                End If
                Me.TB_Archivierung_Pfad.Text = ndAllgemein.Attributes("archivPfad").Value 'My.Settings.bAutoMonatsbericht

                Me.TB_DateiablageStreckeninfo.Text = ndAllgemein.Attributes("dateiStreckeninfo").Value

                If ndAllgemein.Attributes("bAutoMonatsbericht").Value = "" Then ndAllgemein.Attributes("bAutoMonatsbericht").Value = "false"
                Me.ChB_autoMonatsbericht.Checked = ndAllgemein.Attributes("bAutoMonatsbericht").Value 'My.Settings.bAutoMonatsbericht

                '# Email-Daten
                Me.TB_SMTPServer.Text = ndAllgemein.Attributes("SMTP").Value
                Me.TB_LoginName.Text = ndAllgemein.Attributes("LoginName").Value
                Me.TB_Passwort.Text = ndAllgemein.Attributes("Passwort").Value
                Me.TB_Sender.Text = ndAllgemein.Attributes("Sender").Value
                If ndAllgemein.Attributes("bWochenende").Value = "" Then ndAllgemein.Attributes("bWochenende").Value = "true"
                Me.ChB_Wochenende.Checked = ndAllgemein.Attributes("bWochenende").Value
                'Me.NUD_SendeIntervall.Value = 1
                'If ndAllgemein.Attributes("Sendeintervall").Value > 0 Then _
                If Not IsNumeric(ndAllgemein.Attributes("Sendeintervall").Value) Then
                    ndAllgemein.Attributes("Sendeintervall").Value = Me.NUD_SendeIntervall.Minimum
                ElseIf ndAllgemein.Attributes("Sendeintervall").Value < Me.NUD_SendeIntervall.Minimum Then
                    ndAllgemein.Attributes("Sendeintervall").Value = Me.NUD_SendeIntervall.Minimum
                End If
                Me.NUD_SendeIntervall.Value = ndAllgemein.Attributes("Sendeintervall").Value

                Update_Verteiler()

                '# Schwellen-Daten
                Update_Schwellen_RK()
                Update_Schwellen_SP()

                '#Max-Pegle
                Me.NUD_Max_Verteiler.Value = ndAllgemein.Attributes("Max_Verteiler").Value
                Me.NUD_Sperrung_Max_tags.Value = ndAllgemein.Attributes("Max_Sperrung_tags").Value
                Me.NUD_Sperrung_Max_nachts.Value = ndAllgemein.Attributes("Max_Sperrung_nachts").Value
                Me.TB_Max_Sperrung_Mitteilung.Text = ndAllgemein.Attributes("Max_Sperrung_Mitteilung").Value '

                '# Fehlerhafte werte
                Me.NUD_Fehler_Verteiler.Value = ndAllgemein.Attributes("Fehler_Verteiler").Value
            End If

            'If Email_Pruefung() Then
            '    bStopped_Email = False
            '    'Control_Start()

            '    Einstellungen_Enable(False)

            'Else
            '    bStopped_Email = True
            '    Me.Button_Email_Go.BackColor = System.Drawing.Color.SandyBrown

            '    Einstellungen_Enable(True)

            'End If
        End If

        Einstellungen_Enable(False)

        bLoad = False
    End Sub
    Public Sub Update_Verteiler()
        For i As Integer = Me.Panel_Empfaenger.Controls.Count - 1 To 0 Step -1
            If TypeOf (Me.Panel_Empfaenger.Controls(i)) Is UC_Verteiler Then Me.Panel_Empfaenger.Controls(i).Dispose()
        Next

        If ndAllgemein.Item("Verteiler").ChildNodes.Count > 0 Then
            For i As Integer = 0 To ndAllgemein.Item("Verteiler").ChildNodes.Count - 1 '.Length - 1
                Add_Verteiler(i + 1) 'ndAllgemein.Item("Verteiler").ChildNodes(i), i + 1)

            Next
        End If
    End Sub
    Public Sub Update_Schwellen_RK()
        For i As Integer = Me.Panel_Schwellen_RK.Controls.Count - 1 To 0 Step -1
            If TypeOf (Me.Panel_Schwellen_RK.Controls(i)) Is UC_Warnstufe Then Me.Panel_Schwellen_RK.Controls(i).Dispose()
        Next

        If ndAllgemein.Item("Schwellen_RK").ChildNodes.Count > 0 Then
            For i As Integer = 0 To ndAllgemein.Item("Schwellen_RK").ChildNodes.Count - 1
                Add_Schwelle_RK(i + 1)
            Next
        End If
 

    End Sub
    Public Sub Update_Schwellen_SP()
        For i As Integer = Me.Panel_Schwellen_SP.Controls.Count - 1 To 0 Step -1
            If TypeOf (Me.Panel_Schwellen_SP.Controls(i)) Is UC_Warnstufe Then Me.Panel_Schwellen_SP.Controls(i).Dispose()
        Next

        If ndAllgemein.Item("Schwellen_SP").ChildNodes.Count > 0 Then
            For i As Integer = 0 To ndAllgemein.Item("Schwellen_SP").ChildNodes.Count - 1
                Add_Schwelle_SP(i + 1)
            Next
        End If

    End Sub
    Private Sub Button_Drucken_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Drucken.Click
        Me.Cursor = Cursors.WaitCursor
        'For i As Integer = 1 To 12
        'If Drucke_Monatsbericht(i, Me.DTP_Drucken.Value.Year, True) = False Then
        If Drucke_Monatsbericht(Me.DTP_Drucken.Value.Month, Me.DTP_Drucken.Value.Year, False) = False Then
            MsgBox("Es konnten Dateien, die zur Erstellung des Monatsberichts benötigt werden, nicht geöffnet werden, da sie von einem anderen Prozess verwendet werden. Versuchen Sie es später noch einmal.", MsgBoxStyle.OkOnly, "Zugriffskonflikt")
        End If
        'Next
        Me.Cursor = Cursors.Default
    End Sub

#Region "Alarm-Meldungen"

    'Private Sub Button_Email_Bearbeiten_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    bStopped_Email = True
    '    Me.Button_Email_Go.BackColor = System.Drawing.Color.SandyBrown

    '    Einstellungen_Enable(True)

    '    'Me.TB_Empfaenger.Enabled = True
    '    'Me.TB_LoginName.Enabled = True
    '    'Me.TB_Passwort.Enabled = True
    '    'Me.TB_Sender.Enabled = True
    '    'Me.TB_SMTPServer.Enabled = True
    '    'Me.ChB_Wochenende.Enabled = True
    '    'Me.NUD_SendeIntervall.Enabled = True
    'End Sub
    'Private Sub Button_Email_Go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    '    'If bReadyExists Then
    '    If Email_Pruefung() Then
    '        bStopped_Email = False

    '        Me.Button_Email_Go.BackColor = System.Drawing.SystemColors.Control

    '        'Me.TB_Empfaenger.Enabled = False
    '        Me.TB_LoginName.Enabled = False
    '        Me.TB_Passwort.Enabled = False
    '        Me.TB_Sender.Enabled = False
    '        Me.TB_SMTPServer.Enabled = False
    '        Me.ChB_Wochenende.Enabled = False
    '        Me.NUD_SendeIntervall.Enabled = False



    '        'ndAllgemein.Attributes("bWochenende").Value = Me.ChB_Wochenende.Checked
    '        'ndAllgemein.Attributes("Sendeintervall").Value = CInt(Me.NUD_SendeIntervall.Value)
    '        'ndAllgemein.Attributes("SMTP").Value = Me.TB_SMTPServer.Text
    '        'ndAllgemein.Attributes("LoginName").Value = Me.TB_LoginName.Text
    '        'ndAllgemein.Attributes("Passwort").Value = Me.TB_Passwort.Text
    '        'ndAllgemein.Attributes("Sender").Value = Me.TB_Sender.Text
    '        ''ndAllgemein.Attributes("Verteiler").Value = Nothing '.Clear()
    '        ''For i As Integer = 0 To Me.Panel_Empfaenger.Controls.Count - 1
    '        ''    If TypeOf (Me.Panel_Empfaenger.Controls(i)) Is UC_Verteiler Then


    '        ''        Dim iLen As Integer = 0
    '        ''        If Not IsNothing(Allgemein.Verteiler) Then iLen = Allgemein.Verteiler.Length
    '        ''        ReDim Preserve Allgemein.Verteiler(iLen)
    '        ''        Allgemein.Verteiler(iLen) = CType(Me.Panel_Empfaenger.Controls(i), UC_Verteiler).TB_Empfaenger.Text
    '        ''        'Alarm.Verteiler.Add(CType(Me.Panel_Empfaenger.Controls(i), UC_Verteiler).TB_Empfaenger.Text)

    '        ''    End If
    '        ''Next

    '        'Allgemein.Max_Verteiler = Me.NUD_Max_Verteiler.Value

    '        'For i As Integer = 0 To Me.Panel_Alarm.Controls.Count - 1
    '        '    If TypeOf (Me.Panel_Alarm.Controls(i)) Is UC_Warnstufe Then
    '        '        Dim iLen As Integer = 0
    '        '        If Not IsNothing(Schwellen) Then iLen = Schwellen.Length
    '        '        ReDim Preserve Schwellen(iLen)
    '        '        With Schwellen(iLen)
    '        '            'Dim tSchwelle As Schwellen_Data
    '        '            .Verteiler = CType(Me.Panel_Alarm.Controls(i), UC_Warnstufe).NUD_Verteiler.Value
    '        '            .bSperrung = CType(Me.Panel_Alarm.Controls(i), UC_Warnstufe).ChB_Sperrung.Checked
    '        '            .H0 = CType(Me.Panel_Alarm.Controls(i), UC_Warnstufe).NUD_proz_0.Value
    '        '            .H1 = CType(Me.Panel_Alarm.Controls(i), UC_Warnstufe).NUD_proz_1.Value
    '        '            .H2 = CType(Me.Panel_Alarm.Controls(i), UC_Warnstufe).NUD_proz_2.Value
    '        '            .H3 = CType(Me.Panel_Alarm.Controls(i), UC_Warnstufe).NUD_proz_3.Value
    '        '            .H4 = CType(Me.Panel_Alarm.Controls(i), UC_Warnstufe).NUD_proz_4.Value
    '        '            .H5 = CType(Me.Panel_Alarm.Controls(i), UC_Warnstufe).NUD_proz_5.Value
    '        '            .H6 = CType(Me.Panel_Alarm.Controls(i), UC_Warnstufe).NUD_proz_6.Value
    '        '            .H7 = CType(Me.Panel_Alarm.Controls(i), UC_Warnstufe).NUD_proz_7.Value
    '        '            .H8 = CType(Me.Panel_Alarm.Controls(i), UC_Warnstufe).NUD_proz_8.Value
    '        '            .H9 = CType(Me.Panel_Alarm.Controls(i), UC_Warnstufe).NUD_proz_9.Value
    '        '            .H10 = CType(Me.Panel_Alarm.Controls(i), UC_Warnstufe).NUD_proz_10.Value
    '        '            .H11 = CType(Me.Panel_Alarm.Controls(i), UC_Warnstufe).NUD_proz_11.Value
    '        '            .H12 = CType(Me.Panel_Alarm.Controls(i), UC_Warnstufe).NUD_proz_12.Value
    '        '            .H13 = CType(Me.Panel_Alarm.Controls(i), UC_Warnstufe).NUD_proz_13.Value
    '        '            .H14 = CType(Me.Panel_Alarm.Controls(i), UC_Warnstufe).NUD_proz_14.Value
    '        '            .H15 = CType(Me.Panel_Alarm.Controls(i), UC_Warnstufe).NUD_proz_15.Value
    '        '            .H16 = CType(Me.Panel_Alarm.Controls(i), UC_Warnstufe).NUD_proz_16.Value
    '        '            .H17 = CType(Me.Panel_Alarm.Controls(i), UC_Warnstufe).NUD_proz_17.Value
    '        '            .H18 = CType(Me.Panel_Alarm.Controls(i), UC_Warnstufe).NUD_proz_18.Value
    '        '            .H19 = CType(Me.Panel_Alarm.Controls(i), UC_Warnstufe).NUD_proz_19.Value
    '        '            .H20 = CType(Me.Panel_Alarm.Controls(i), UC_Warnstufe).NUD_proz_20.Value
    '        '            .H21 = CType(Me.Panel_Alarm.Controls(i), UC_Warnstufe).NUD_proz_21.Value
    '        '            .H22 = CType(Me.Panel_Alarm.Controls(i), UC_Warnstufe).NUD_proz_22.Value
    '        '            .H23 = CType(Me.Panel_Alarm.Controls(i), UC_Warnstufe).NUD_proz_23.Value
    '        '        End With
    '        '    End If
    '        'Next

    '        'Control_Start()
    '    Else
    '        bStopped_Email = True
    '        Me.Button_Email_Go.BackColor = System.Drawing.Color.SandyBrown

    '        Einstellungen_Enable(True)

    '        'Me.TB_Empfaenger.Enabled = True
    '        'Me.TB_LoginName.Enabled = True
    '        'Me.TB_Passwort.Enabled = True
    '        'Me.TB_Sender.Enabled = True
    '        'Me.TB_SMTPServer.Enabled = True
    '        'Me.ChB_Wochenende.Enabled = True
    '        'Me.NUD_SendeIntervall.Enabled = True
    '    End If

    'End Sub
    Private Sub Button_SendTestEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_SendTestEmail.Click
        'SendMessage("Test-Email von DaMe", "Die zu versendende Test-Email von DETECT_DaMe!") ', Now
        Dim obj As Date = SendMessage("Test-Email von DaMe", "Die zu versendende Test-Email von DaMe!", Me.NUD_Verteiler_Test.Value)
        'bSending = False
        If obj.Year = Now.Year Then
            MsgBox("Nachricht versendet.", MsgBoxStyle.OkOnly, "Info")
        Else
            MsgBox("Nachricht konnte NICHT versendet werden!", MsgBoxStyle.OkOnly, "Info")
        End If
    End Sub

#End Region

    Private Sub NUD_SekWetter_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUD_SekWetter.ValueChanged
        If bLoad = False Then
            My.Settings.SekWetter = CInt(Me.NUD_SekWetter.Value)
            My.Settings.Save()
        End If
    End Sub

    Private Sub TB_Pfad_Zielordner_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_Pfad_Zielordner.TextChanged

        If bLoad = False Then
            My.Settings.PfadZielordner = Me.TB_Pfad_Zielordner.Text
            My.Settings.Save()
        End If

        If New IO.DirectoryInfo(Me.TB_Pfad_Zielordner.Text).Exists = False Then
            Me.TB_Pfad_Zielordner.BackColor = System.Drawing.Color.SandyBrown
        Else
            Me.TB_Pfad_Zielordner.BackColor = System.Drawing.SystemColors.Window
            Daten_Allgemein_einlesen()
        End If

    End Sub

    Private Sub NUD_Archivierung_Monate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUD_Archivierung_Monate.ValueChanged
        If bLoad = False Then
            ndAllgemein.Attributes("archivMonate").Value = Me.NUD_Archivierung_Monate.Value
            'Daten_Allgemein_Speichern()
        End If

    End Sub
    Private Sub NUD_archivKompressionsLevel_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUD_archivKompressionsLevel.ValueChanged
        If bLoad = False Then
            ndAllgemein.Attributes("archivKompressionsLevel").Value = Me.NUD_archivKompressionsLevel.Value
            'Daten_Allgemein_Speichern()
        End If
    End Sub
    Private Sub TB_Archivierung_Pfad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_Archivierung_Pfad.TextChanged
        If bLoad = False Then
            ndAllgemein.Attributes("archivPfad").Value = Me.TB_Archivierung_Pfad.Text
            'Daten_Allgemein_Speichern()
        End If

        If New IO.DirectoryInfo(Me.TB_Archivierung_Pfad.Text).Exists = False Then
            Me.TB_Archivierung_Pfad.BackColor = System.Drawing.Color.SandyBrown
        Else
            Me.TB_Archivierung_Pfad.BackColor = System.Drawing.SystemColors.Window
        End If
    End Sub
    Private Sub Button_Archivierung_Pfad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Archivierung_Pfad.Click
        If Me.TB_Archivierung_Pfad.Text <> "" Then Me.FBD_Archivierung.SelectedPath = Me.TB_Archivierung_Pfad.Text
        If Me.FBD_Archivierung.ShowDialog = DialogResult.OK Then
            Me.TB_Archivierung_Pfad.Text = Me.FBD_Archivierung.SelectedPath
        End If
    End Sub

    Private Sub TB_DateiablageStreckeninfo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_DateiablageStreckeninfo.TextChanged
        If bLoad = False Then
            ndAllgemein.Attributes("dateiStreckeninfo").Value = Me.TB_DateiablageStreckeninfo.Text
            'Daten_Allgemein_Speichern()
        End If

        'If New IO.DirectoryInfo(Me.TB_DateiablageStreckeninfo.Text).Exists = False Then
        '    Me.TB_DateiablageStreckeninfo.BackColor = System.Drawing.Color.SandyBrown
        'Else
        '    Me.TB_DateiablageStreckeninfo.BackColor = System.Drawing.SystemColors.Window
        'End If
    End Sub
    Private Sub Button_DateiablageStreckeninfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_DateiablageStreckeninfo.Click
        If Me.TB_DateiablageStreckeninfo.Text <> "" Then Me.SFD_Streckeninfo.FileName = Me.TB_DateiablageStreckeninfo.Text
        If Me.SFD_Streckeninfo.ShowDialog = DialogResult.OK Then
            Me.TB_DateiablageStreckeninfo.Text = Me.SFD_Streckeninfo.FileName
        End If
    End Sub

    Private Sub ChB_autoMonatsbericht_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChB_autoMonatsbericht.CheckedChanged
        If bLoad = False Then
           
            ndAllgemein.Attributes("bAutoMonatsbericht").Value = Me.ChB_autoMonatsbericht.Checked
            'Daten_Allgemein_Speichern()
        End If
    End Sub

    Private Sub TB_SMTPServer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_SMTPServer.TextChanged
        ndAllgemein.Attributes("SMTP").Value = Me.TB_SMTPServer.Text
        'Daten_Allgemein_Speichern()
    End Sub
    Private Sub TB_LoginName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_LoginName.TextChanged
        ndAllgemein.Attributes("LoginName").Value = Me.TB_LoginName.Text
        'Daten_Allgemein_Speichern()
    End Sub
    Private Sub TB_Passwort_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_Passwort.TextChanged
        ndAllgemein.Attributes("Passwort").Value = Me.TB_Passwort.Text
        'Daten_Allgemein_Speichern()
    End Sub
    Private Sub TB_Sender_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_Sender.TextChanged
        ndAllgemein.Attributes("Sender").Value = Me.TB_Sender.Text
        'Daten_Allgemein_Speichern()
    End Sub
    Private Sub ChB_Wochenende_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChB_Wochenende.CheckedChanged
        ndAllgemein.Attributes("bWochenende").Value = Me.ChB_Wochenende.Checked
        'Daten_Allgemein_Speichern()
    End Sub
    Private Sub NUD_SendeIntervall_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUD_SendeIntervall.ValueChanged
        If bLoad = False Then
            ndAllgemein.Attributes("Sendeintervall").Value = CInt(Me.NUD_SendeIntervall.Value)
            'Daten_Allgemein_Speichern()
        End If
    End Sub

    Private Sub NUD_Max_Verteiler_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUD_Max_Verteiler.ValueChanged
        If bLoad = False Then
            ndAllgemein.Attributes("Max_Verteiler").Value = CInt(Me.NUD_Max_Verteiler.Value)
            'Daten_Allgemein_Speichern()
        End If
    End Sub
    Private Sub NUD_Sperrung_Max_nachts_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUD_Sperrung_Max_nachts.ValueChanged
        If bLoad = False Then
            ndAllgemein.Attributes("Max_Sperrung_nachts").Value = CInt(Me.NUD_Sperrung_Max_nachts.Value)
            'Daten_Allgemein_Speichern()
        End If
    End Sub
    Private Sub NUD_Sperrung_Max_tags_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUD_Sperrung_Max_tags.ValueChanged
        If bLoad = False Then
            ndAllgemein.Attributes("Max_Sperrung_tags").Value = CInt(Me.NUD_Sperrung_Max_tags.Value)
            'Daten_Allgemein_Speichern()
        End If
    End Sub
    Private Sub TB_Streckenmitteilung_Max_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_Max_Sperrung_Mitteilung.TextChanged
        If bLoad = False Then
            ndAllgemein.Attributes("Max_Sperrung_Mitteilung").Value = Me.TB_Max_Sperrung_Mitteilung.Text
            'Daten_Allgemein_Speichern()
        End If
    End Sub

    Private Sub NUD_Fehler_Verteiler_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUD_Fehler_Verteiler.ValueChanged
        If bLoad = False Then
            ndAllgemein.Attributes("Fehler_Verteiler").Value = Me.NUD_Fehler_Verteiler.Value
            'Daten_Allgemein_Speichern()
        End If
    End Sub

    Private Sub Button_Add_Verteiler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Add_Verteiler.Click
        XML_Add_Verteiler()
        Add_Verteiler(ndAllgemein.Item("Verteiler").ChildNodes.Count) 'XML_Add_Verteiler(), 
    End Sub
    Public Sub Add_Verteiler(ByVal ixNode As Integer) 'ByRef ndVerteilerNr As XmlNode, ByVal ixNode As Integer) As UC_Verteiler


        Dim ucVert As UC_Verteiler = New UC_Verteiler
        ucVert.Dock = DockStyle.Left
        ucVert.ndVerteilerNr = ndAllgemein.Item("Verteiler").ChildNodes(ixNode - 1) 'ndVerteilerNr
        ucVert.Label_Verteiler.Text = "Verteiler " & ixNode 'ndVerteilerNr.ParentNode.ChildNodes.Count

        Me.Panel_Empfaenger.Controls.Add(ucVert)
        Me.Panel_Empfaenger.Controls.SetChildIndex(ucVert, 0)


        'Update_Layout_Verteiler()
        'Return ucVert
    End Sub
    'Public Function Add_Ctr_Verteiler(ByVal ndVerteilerNr As XmlNode)
    '    Dim ucVert As UC_Verteiler = New UC_Verteiler
    '    ucVert.Dock = DockStyle.Left
    '    ucVert.ndVerteilerNr = ndVerteilerNr

    '    'ucVert.Label_Verteiler.Text = "Verteiler " & Me.Panel_Empfaenger.Controls.Count - 1
    '    Me.Panel_Empfaenger.Controls.Add(ucVert)
    '    Me.Panel_Empfaenger.Controls.SetChildIndex(ucVert, 0)

    '    'Update_Layout_Verteiler()
    '    Return ucVert
    'End Function
    'Public Sub Update_Layout_Verteiler()
    '    For iCtr As Integer = 0 To Me.Panel_Empfaenger.Controls.Count - 1
    '        If TypeOf (Me.Panel_Empfaenger.Controls(iCtr)) Is UC_Verteiler Then
    '            Dim tVert As UC_Verteiler = Me.Panel_Empfaenger.Controls(iCtr)
    '            Dim i As Integer = Me.Panel_Empfaenger.Controls.Count - iCtr - 1

    '            tVert.Label_Verteiler.Text = "Verteiler " & i 'Me.Panel_Empfaenger.Controls.Count - iCtr

    '            If i Mod 2 = 0 Then
    '                tVert.BackColor = Color.LightGray
    '            Else
    '                tVert.BackColor = Color.WhiteSmoke
    '            End If
    '        End If
    '    Next
    'End Sub
    Private Sub Button_Add_Schwelle_RK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Add_Schwelle_RK.Click
        XML_Add_Schwelle(ndAllgemein.Item("Schwellen_RK"))
        Add_Schwelle_RK(ndAllgemein.Item("Schwellen_RK").ChildNodes.Count)
    End Sub
    Public Sub Add_Schwelle_RK(ByVal ixNode As Integer) 'ByRef ndSchwelle As XmlNode) As UC_Warnstufe ' As UC_Warnstufe

        Dim ucSchwelle As UC_Warnstufe = New UC_Warnstufe
        ucSchwelle.Dock = DockStyle.Top
        ucSchwelle.sTyp = "RK"
        'ucSchwelle.ndSchwelle = ndAllgemein.Item("Schwellen_RK").ChildNodes(ixNode - 1) 'ndSchwelle
        ucSchwelle.Label_Schwelle.Text = "Stufe " & ixNode

        Me.Panel_Schwellen_RK.Controls.Add(ucSchwelle)
        Me.Panel_Alarm_RK.Height = Me.Panel_Schwellen_RK.Controls.Count * ucSchwelle.Height + 62
        Me.Panel_Schwellen_RK.Controls.SetChildIndex(ucSchwelle, 0)

        'Return ucSchwelle

    End Sub
    Private Sub Button_Add_Schwelle_SP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Add_Schwelle_SP.Click
        XML_Add_Schwelle(ndAllgemein.Item("Schwellen_SP"))
        Add_Schwelle_SP(ndAllgemein.Item("Schwellen_SP").ChildNodes.Count)
    End Sub
    Public Function Add_Schwelle_SP(ByVal ixNode As Integer) 'ByRef ndSchwelle As XmlNode) As UC_Warnstufe ' As UC_Warnstufe

        Dim ucSchwelle As UC_Warnstufe = New UC_Warnstufe
        ucSchwelle.Dock = DockStyle.Top
        ucSchwelle.sTyp = "SP"
        'ucSchwelle.ndSchwelle = ndAllgemein.Item("Schwellen_SP").ChildNodes(ixNode - 1) 'ndSchwelle
        ucSchwelle.Label_Schwelle.Text = "Stufe " & ixNode
        'ucSchwelle.ndSchwelle = ndSchwelle

        Me.Panel_Schwellen_SP.Controls.Add(ucSchwelle)
        Me.Panel_Alarm_SP.Height = Me.Panel_Schwellen_SP.Controls.Count * ucSchwelle.Height + 62
        Me.Panel_Schwellen_SP.Controls.SetChildIndex(ucSchwelle, 0)

        'Return ucSchwelle

    End Function

    'Public Function Add_Ctr_Warnstufe() As UC_Warnstufe
    '    Dim ucSchwelle As UC_Warnstufe = New UC_Warnstufe
    '    ucSchwelle.Dock = DockStyle.Top
    '    'ucSchwelle.Label_Bez.Text = Me.Panel_Schwellen.Controls.Count + 1 & ". Stufe"
    '    Me.Panel_Schwellen_SP.Controls.Add(ucSchwelle)
    '    Me.Panel_Schwellen_SP.Controls.SetChildIndex(ucSchwelle, 0)

    '    Update_Layout_Warnstufe()

    '    Return ucSchwelle

    'End Function

    'Public Sub Update_Layout_Warnstufe()
    '    For iCtr As Integer = 0 To Me.Panel_Schwellen_SP.Controls.Count - 1
    '        If TypeOf (Me.Panel_Schwellen_SP.Controls(iCtr)) Is UC_Warnstufe Then
    '            Dim tWarn As UC_Warnstufe = Me.Panel_Schwellen_SP.Controls(iCtr)
    '            Dim i As Integer = Me.Panel_Schwellen_SP.Controls.Count - iCtr

    '            tWarn.Label_Bez.Text = i & ". Stufe"

    '            If i Mod 2 <> 0 Then
    '                tWarn.BackColor = Color.LightGray
    '            Else
    '                tWarn.BackColor = Color.WhiteSmoke
    '            End If
    '        End If
    '    Next
    'End Sub

    Private Sub Button_Bearbeiten_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Bearbeiten.Click
        Dim fio As IO.FileInfo = New IO.FileInfo(My.Settings.PfadZielordner & "\All_OPEN.DAT")
        If Me.Button_Bearbeiten.Text = "Bearbeiten" Then
            If fio.Exists Then
                MsgBox("Die allgemeinen Einstellungen befindet sich durch einen anderen Benutzer in Bearbeitung!", MsgBoxStyle.OkOnly, "Info")
                '            Gebaeude_einlesen = False
            Else
                If Daten_Allgemein_einlesen() Then
                    Dim fiOrig As IO.FileInfo = New IO.FileInfo(My.Settings.PfadZielordner & "\All.DAT")
                    fiOrig.CopyTo(fio.FullName)
                    Einstellungen_Enable(True)
                    Me.Button_Bearbeiten.Text = "Speichern"
                End If
            End If
        Else
            'If Daten_Allgemein_Speichern() Then
            Einstellungen_Enable(False)
            Daten_Allgemein_Speichern()

            If fio.Exists Then fio.Delete()
            Me.Button_Bearbeiten.Text = "Bearbeiten"


            'End If
        End If
    End Sub

    Private Sub NUD_Verteiler_Test_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUD_Verteiler_Test.ValueChanged
        If bLoad = False Then ndAllgemein.Attributes("Test_Verteiler").Value = Me.NUD_Verteiler_Test.Value
    End Sub



    Private Sub TabControl1_Selecting(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles TabControl1.Selecting
        '# wenn der anwender wegschalten möchte -> hindern
        If Me.Button_Bearbeiten.Text = "Speichern" Then
            MsgBox("Die Eingaben müssen zuerst gespeichert werden.", MsgBoxStyle.OkOnly, "Info")
            e.Cancel = True
        End If
    End Sub

End Class
