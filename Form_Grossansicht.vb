Public Class Form_Grossansicht
    Public mytimerDelegate As New Threading.TimerCallback(AddressOf Update_Anzeige_Dauernd)
    Public tm As New Threading.Timer(mytimerDelegate, Nothing, 20000, 1000 * 5 * 60) 'alle 5Min ausführen, das erste Mal nach 2 Sek

    Private Const bSlateGrey As Boolean = False

    Private Sub Clear_Anzeige()
        Do While Me.SplitContainer2.Panel1.Controls("Panel1").Controls.Count > 0
            Me.SplitContainer2.Panel1.Controls("Panel1").Controls.Remove(Me.SplitContainer2.Panel1.Controls("Panel1").Controls(0))
        Loop
    End Sub

#Region "Form Load + Closing"
    Private Sub Form_Grossansicht_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Cursor = Cursors.WaitCursor
        tm.Dispose()

        Threading.Thread.Sleep(2000)
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub Form_Grossansicht_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'MsgBox(CDate("31.3.2019").AddMonths(-1), MsgBoxStyle.OkOnly)

        Daten_einlesen() '# Max-Pegel und Immiorte
        If My.Settings.PfadZielordner <> "" Then
            If New IO.DirectoryInfo(My.Settings.PfadZielordner).Exists = False Then
                PB_Einstellungen_Click(Nothing, Nothing)
            Else
                Daten_Allgemein_einlesen()

                PB_Gesamtansicht_Click(Nothing, Nothing)

                LV_Ueberschreitungen_Update()
            End If
        Else
            PB_Einstellungen_Click(Nothing, Nothing)
        End If
        If My.Settings.UEBER_Seit > Me.DTP_UEBER_startDatum.MinDate Then Me.DTP_UEBER_startDatum.Value = My.Settings.UEBER_Seit
        Me.NUD_UEBER_Anzahl.Value = My.Settings.UEBER_Anz
        Me.NUD_UEBER_Prozent.Value = My.Settings.UEBER_Proz
    End Sub
#End Region

#Region "Menüpunkte"
    Private Sub PB_Wetter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_Wetter.Click
        If Me.SplitContainer2.Panel1.Controls("Panel1").Controls.Count > 0 Then
            If TypeOf (Me.SplitContainer2.Panel1.Controls("Panel1").Controls(0)) Is UserControl_Einstellungen Then
                If CType(Me.SplitContainer2.Panel1.Controls("Panel1").Controls(0), UserControl_Einstellungen).Button_Bearbeiten.Text = "Speichern" Then
                    '# wenn der anwender wegschalten möchte -> hindern
                    MsgBox("Die Eingaben müssen zuerst gespeichert werden.", MsgBoxStyle.OkOnly, "Info")
                    Exit Sub
                End If
            End If
        End If

        Me.Cursor = Cursors.WaitCursor
        MenueFarbe(3)

        Clear_Anzeige()

        Dim uc_Wetter As New UserControl_Wetter
        'uc_Wetter.Dock = DockStyle.Fill
        uc_Wetter.BackColor = Color.WhiteSmoke
        If bSlateGrey Then uc_Wetter.BackColor = Color.SlateGray
        Me.SplitContainer2.Panel1.Controls("Panel1").Controls.Add(uc_Wetter)

        Me.Cursor = Cursors.Default
    End Sub
    Private Sub PB_Gesamtansicht_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_Gesamtansicht.Click
        If Me.SplitContainer2.Panel1.Controls("Panel1").Controls.Count > 0 Then
            If TypeOf (Me.SplitContainer2.Panel1.Controls("Panel1").Controls(0)) Is UserControl_Einstellungen Then
                If CType(Me.SplitContainer2.Panel1.Controls("Panel1").Controls(0), UserControl_Einstellungen).Button_Bearbeiten.Text = "Speichern" Then
                    '# wenn der anwender wegschalten möchte -> hindern
                    MsgBox("Die Eingaben müssen zuerst gespeichert werden.", MsgBoxStyle.OkOnly, "Info")
                    Exit Sub
                End If
            End If
        End If

        MenueFarbe(1)
        Me.Cursor = Cursors.WaitCursor

        Clear_Anzeige()

        Dim uc_Gesammtansicht As New UserControl_Gesammtansicht
        'uc_Gesammtansicht.Dock = DockStyle.Fill
        uc_Gesammtansicht.BackColor = Color.WhiteSmoke
        If bSlateGrey Then uc_Gesammtansicht.BackColor = Color.SlateGray
        Me.SplitContainer2.Panel1.Controls("Panel1").Controls.Add(uc_Gesammtansicht)

        Me.Cursor = Cursors.Default
    End Sub
    Private Sub PB_Uebersicht_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_Uebersicht.Click
        If Me.SplitContainer2.Panel1.Controls("Panel1").Controls.Count > 0 Then
            If TypeOf (Me.SplitContainer2.Panel1.Controls("Panel1").Controls(0)) Is UserControl_Einstellungen Then
                If CType(Me.SplitContainer2.Panel1.Controls("Panel1").Controls(0), UserControl_Einstellungen).Button_Bearbeiten.Text = "Speichern" Then
                    '# wenn der anwender wegschalten möchte -> hindern
                        MsgBox("Die Eingaben müssen zuerst gespeichert werden.", MsgBoxStyle.OkOnly, "Info")
                    Exit Sub
                End If
            End If
        End If

        Me.Cursor = Cursors.WaitCursor
        MenueFarbe(4)

        Clear_Anzeige()

        Dim uc_Karte As New UserControl_Karte
        'uc_Karte.Dock = DockStyle.Fill
        uc_Karte.BackColor = Color.WhiteSmoke
        If bSlateGrey Then uc_Karte.BackColor = Color.SlateGray
        Me.SplitContainer2.Panel1.Controls("Panel1").Controls.Add(uc_Karte)

        Me.Cursor = Cursors.Default
    End Sub
    Public Sub PB_Einstellungen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_Einstellungen.Click
        If Me.SplitContainer2.Panel1.Controls("Panel1").Controls.Count > 0 Then
            If TypeOf (Me.SplitContainer2.Panel1.Controls("Panel1").Controls(0)) Is UserControl_Einstellungen Then
                If CType(Me.SplitContainer2.Panel1.Controls("Panel1").Controls(0), UserControl_Einstellungen).Button_Bearbeiten.Text = "Speichern" Then
                    '# wenn der anwender wegschalten möchte -> hindern
                    MsgBox("Die Eingaben müssen zuerst gespeichert werden.", MsgBoxStyle.OkOnly, "Info")
                    Exit Sub
                End If
            End If
        End If

        Me.Cursor = Cursors.WaitCursor
        MenueFarbe(5)

        Clear_Anzeige()


        Dim uc_Einstellungen As New UserControl_Einstellungen
        'uc_Einstellungen.Dock = DockStyle.Fill
        uc_Einstellungen.BackColor = Color.WhiteSmoke
        If bSlateGrey Then uc_Einstellungen.BackColor = Color.SlateGray
        Me.SplitContainer2.Panel1.Controls("Panel1").Controls.Add(uc_Einstellungen)

        Me.Cursor = Cursors.Default
    End Sub
    Private Sub PB_Messstellen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_Messstellen.Click
        If Me.SplitContainer2.Panel1.Controls("Panel1").Controls.Count > 0 Then
            If TypeOf (Me.SplitContainer2.Panel1.Controls("Panel1").Controls(0)) Is UserControl_Einstellungen Then
                If CType(Me.SplitContainer2.Panel1.Controls("Panel1").Controls(0), UserControl_Einstellungen).Button_Bearbeiten.Text = "Speichern" Then
                    '# wenn der anwender wegschalten möchte -> hindern
                    MsgBox("Die Eingaben müssen zuerst gespeichert werden.", MsgBoxStyle.OkOnly, "Info")
                    Exit Sub
                End If
            End If
        End If

        Me.Cursor = Cursors.WaitCursor
        MenueFarbe(2)

        Clear_Anzeige()

        Dim uc_Messpunkte As New UserControl_Messpunkte
        'uc_Messpunkte.Dock = DockStyle.Fill
        uc_Messpunkte.BackColor = Color.WhiteSmoke
        If bSlateGrey Then uc_Messpunkte.BackColor = Color.SlateGray
        Me.SplitContainer2.Panel1.Controls("Panel1").Controls.Add(uc_Messpunkte)

        Me.Cursor = Cursors.Default
    End Sub
    Private Sub MenueFarbe(ByVal iButton As Integer)
        Me.PB_Gesamtansicht.BackColor = Color.SlateGray
        Me.PB_Messstellen.BackColor = Color.SlateGray
        Me.PB_Wetter.BackColor = Color.SlateGray
        Me.PB_Uebersicht.BackColor = Color.SlateGray
        Me.PB_Einstellungen.BackColor = Color.SlateGray

        Select Case iButton
            Case 1
                'Me.PB_Gesamtansicht.BackColor = Color.Gainsboro
                Me.PB_Gesamtansicht.BackColor = Color.Gray
            Case 2
                'Me.PB_Messstellen.BackColor = Color.Gainsboro
                Me.PB_Messstellen.BackColor = Color.Gray
            Case 3
                'Me.PB_Wetter.BackColor = Color.Gainsboro
                Me.PB_Wetter.BackColor = Color.Gray
            Case 4
                'Me.PB_Uebersicht.BackColor = Color.WhiteSmoke
                Me.PB_Uebersicht.BackColor = Color.Gray
            Case 5
                'Me.PB_Einstellungen.BackColor = Color.Gainsboro
                Me.PB_Einstellungen.BackColor = Color.Gray
        End Select
    End Sub
#End Region


    Private Sub LV_Ueberschreitungen_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles LV_Ueberschreitungen.DoubleClick
        Dim lvi As ListViewItem = Me.LV_Ueberschreitungen.SelectedItems(0)
        Dim lvi1 As String = lvi.SubItems(1).ToString.Replace("ListViewSubItem: {", "").Replace("}", "")
        Dim lviDate As Date = CDate(lvi1 & ":00:00") 'lvi.SubItems(1).ToString.Replace("{", "").Replace("}", ""))

        selectedDate = lviDate 'Me.DTP_1.Value
        selectedME = lvi.SubItems(4).Text.Replace("ME ", "")

        If Not IsNothing(Me.Panel1.Controls(0)) Then
            If TypeOf (Me.Panel1.Controls(0)) Is UserControl_Gesammtansicht Then
                CType(Me.Panel1.Controls(0), UserControl_Gesammtansicht).DTP_1.Value = lviDate 'lvi1
            ElseIf TypeOf (Me.Panel1.Controls(0)) Is UserControl_Messpunkte Then
                CType(Me.Panel1.Controls(0), UserControl_Messpunkte).DTP_1.Value = lviDate 'lvi1
                CType(Me.Panel1.Controls(0), UserControl_Messpunkte).DTP_Uhrzeit.Value = lviDate 'lvi1
            End If

        End If
        'Dim IX As Integer = e.Item
        'Dim sDS() As String = ubArr.Item(IX).Split(";")
    End Sub

    Private Sub LV_Ueberschreitungen_BeforeLabelEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.LabelEditEventArgs) Handles LV_Ueberschreitungen.BeforeLabelEdit
        Dim ixRow As Integer = CInt(Me.LV_Ueberschreitungen.Items(e.Item).Tag)
        Dim dDate As Date = CDate(Me.LV_Ueberschreitungen.Items(e.Item).SubItems(1).Text & ":00:00")
        Dim jjjjmmtt As String = dDate.Year & "_" & Format(dDate, "MM") & "_" & Format(dDate, "dd")
        Dim ixME As Integer = CInt(Me.LV_Ueberschreitungen.Items(e.Item).SubItems(4).Text.Replace("ME ", ""))

        Dim fil As IO.FileInfo = New IO.FileInfo(My.Settings.PfadZielordner & "\" & jjjjmmtt & _
                           "\AUS_ME" & ixME & "_" & jjjjmmtt & ".csv")
        If fil.Exists Then
            Dim tArr As String() = System.IO.File.ReadAllLines(fil.FullName)
            Dim tRow As String() = tArr(ixRow).Split(";")

            Dim dlg_Bemerkung As Dialog_Bemerkung = New Dialog_Bemerkung
            'If tRow.Length >= 11 Then dlg_Bemerkung.TB_Bemerkung.Text = tRow(11).Replace(Chr(10), Chr(13))
            Dim jjjjmmttHH As String = Format(dDate, "yyyy_MM_dd_HH")
            Dim filB As IO.FileInfo = New IO.FileInfo(My.Settings.PfadZielordner & "\" & jjjjmmtt & "\AUS_ME" & ixME & "_" & jjjjmmttHH & ".txt")
            If filB.Exists Then dlg_Bemerkung.TB_Bemerkung.Text = System.IO.File.ReadAllText(filB.FullName)

            If dlg_Bemerkung.ShowDialog = Windows.Forms.DialogResult.OK Then
                'Dim ubArr As List(Of String) = New List(Of String)
                'ubArr.AddRange(tArr)
                'Dim sDS() As String = ubArr.Item(ixRow).Split(";")
                'If sDS.Length < 11 Then ReDim Preserve sDS(11)
                'Dim s As String = ""
                'For i As Integer = 0 To 10
                '    s = s & sDS(i) & ";"
                'Next
                ''Dim tmpi As Integer = Asc(dlg_Bemerkung.TB_Bemerkung.Text)
                's = s & dlg_Bemerkung.TB_Bemerkung.Text.Replace(Chr(13), Chr(10))
                'ubArr.Item(ixRow) = s
                'tArr = ubArr.ToArray()

                'Using sw As New IO.StreamWriter(fil.FullName)
                '    sw.Write(Microsoft.VisualBasic.Join(tArr, Chr(13)))
                'End Using
                Me.LV_Ueberschreitungen.Items(e.Item).SubItems(0).Text = dlg_Bemerkung.TB_Bemerkung.Text
                If dlg_Bemerkung.TB_Bemerkung.Text = "" Then
                    If filB.Exists Then filB.Delete()
                Else
                    System.IO.File.WriteAllText(filB.FullName, dlg_Bemerkung.TB_Bemerkung.Text)
                End If
            End If
            e.CancelEdit = True
        End If

    End Sub
    'Private Sub LV_Ueberschreitungen_AfterLabelEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.LabelEditEventArgs) Handles LV_Ueberschreitungen.AfterLabelEdit
    '    Dim ixRow As Integer = CInt(Me.LV_Ueberschreitungen.Items(e.Item).Tag)
    '    Dim dDate As Date = CDate(Me.LV_Ueberschreitungen.Items(e.Item).SubItems(1).Text & ":00:00")
    '    Dim jjjjmmtt As String = dDate.Year & "_" & Format(dDate, "MM") & "_" & Format(dDate, "dd")
    '    Dim ixME As Integer = CInt(Me.LV_Ueberschreitungen.Items(e.Item).SubItems(4).Text.Replace("ME ", ""))

    '    Dim fil As IO.FileInfo = New IO.FileInfo(My.Settings.PfadZielordner & "\" & jjjjmmtt & _
    '                                        "\AUS_ME" & ixME & "_" & jjjjmmtt & ".csv")
    '    Dim ubArr As List(Of String) = New List(Of String)
    '    If fil.Exists Then
    '        Dim tArr As String() = System.IO.File.ReadAllLines(fil.FullName)
    '        ubArr.AddRange(tArr)

    '        'Dim IX As Integer = e.Item
    '        Dim sDS() As String = ubArr.Item(ixRow).Split(";")
    '        If sDS.Length < 11 Then ReDim Preserve sDS(11)
    '        Dim s As String = ""
    '        For i As Integer = 0 To 10
    '            s = s & sDS(i) & ";"
    '        Next
    '        s = s & e.Label
    '        '            sDS(11) = e.Label
    '        ubArr.Item(ixRow) = s
    '        tArr = ubArr.ToArray()

    '        Using sw As New IO.StreamWriter(fil.FullName)
    '            sw.Write(Microsoft.VisualBasic.Join(tArr, Chr(13)))
    '        End Using
    '    End If


    '    'Dim fio As IO.FileInfo = New IO.FileInfo(My.Settings.PfadZielordner & "\UB_LOG.csv")
    '    'Dim ubArr As List(Of String) = New List(Of String)
    '    'If fio.Exists Then
    '    '    Dim tArr As String() = System.IO.File.ReadAllLines(fio.FullName)
    '    '    ubArr.AddRange(tArr)

    '    '    Dim IX As Integer = e.Item
    '    '    Dim sDS() As String = ubArr.Item(IX).Split(";")
    '    '    sDS(3) = e.Label
    '    '    ubArr.Item(IX) = sDS(0) & ";" & sDS(1) & ";" & sDS(2) & ";" & e.Label
    '    '    tArr = ubArr.ToArray()

    '    '    Using sw As New IO.StreamWriter(fio.FullName)
    '    '        sw.Write(Microsoft.VisualBasic.Join(tArr, Chr(13)))
    '    '    End Using
    '    'End If
    'End Sub

#Region "Dauernd"

    Private Sub Button_UEBER_Aktuallisieren_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_UEBER_Aktuallisieren.Click
        LV_Ueberschreitungen_Update()
    End Sub

    Private Sub DTP_UEBER_startDatum_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTP_UEBER_startDatum.ValueChanged
        LV_Ueberschreitungen.Items.Clear()
        My.Settings.UEBER_Seit = Me.DTP_UEBER_startDatum.Value
        My.Settings.Save()
    End Sub

    Private Sub NUD_UEBER_Anzahl_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUD_UEBER_Anzahl.ValueChanged
        LV_Ueberschreitungen.Items.Clear()
        My.Settings.UEBER_Anz = Me.NUD_UEBER_Anzahl.Value
        My.Settings.Save()
    End Sub

    Private Sub NUD_UEBER_Prozent_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUD_UEBER_Prozent.ValueChanged
        LV_Ueberschreitungen.Items.Clear()
        My.Settings.UEBER_Proz = Me.NUD_UEBER_Prozent.Value
        My.Settings.Save()
    End Sub
    'Private Function Get_HourByRowIX(ByVal ixRow As Integer) As Integer
    '    Select Case ixRow
    '        Case Is < 14
    '            Return 0
    '        Case Is < 26
    '            Return 1
    '        Case Is < 38
    '            Return 2
    '        Case Is < 50
    '            Return 3
    '        Case Is < 62
    '            Return 4
    '        Case Is < 74
    '            Return 5
    '        Case Is < 86
    '            Return 6
    '        Case Is < 98
    '            Return 7
    '        Case Is < 110
    '            Return 8
    '        Case Is < 122
    '            Return 9
    '        Case Is < 134
    '            Return 10
    '        Case Is < 146
    '            Return 11
    '        Case Is < 158
    '            Return 12
    '        Case Is < 170
    '            Return 13
    '        Case Is < 182
    '            Return 14
    '        Case Is < 174
    '            Return 15
    '        Case Is < 206
    '            Return 16
    '        Case Is < 218
    '            Return 17
    '        Case Is < 230
    '            Return 18
    '        Case Is < 242
    '            Return 19
    '        Case Is < 254
    '            Return 20
    '        Case Is < 266
    '            Return 21
    '        Case Is < 278
    '            Return 22
    '        Case Else 'Is < 290
    '            Return 23
    '    End Select

    'End Function

    Public Sub LV_Ueberschreitungen_Update()

        LV_Ueberschreitungen.Items.Clear()

        Dim tDate As Date = Now
        '        tDate = New Date(2014, 4, 3, 0, 0, 0)
        Dim sDate As Date = Me.DTP_UEBER_startDatum.Value
        Dim anz As Integer = Me.NUD_UEBER_Anzahl.Value
        Dim proz As Integer = Me.NUD_UEBER_Prozent.Value

        If tDate >= sDate Then
            Me.Cursor = Cursors.WaitCursor

            Dim ubArr As List(Of String) = New List(Of String)

            Do Until tDate < sDate
                'If tDate.Month = 2 And tDate.Day = 6 Then
                '    MsgBox("stop", MsgBoxStyle.OkOnly)
                'End If
                If Set_AuswertungUEBER(tDate) = False Then
                    MsgBox("Es konnten Dateien, die zur Erstellung der Überschreitungsliste benötigt werden, nicht geöffnet werden, da sie von einem anderen Prozess verwendet werden. Versuchen Sie es später noch einmal.", MsgBoxStyle.OkOnly, "Zugriffskonflikt")
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If

                Dim tmpZR As Beurteilungszeitraum_Data = AuswertungUEBER.Nachtzeitraum_0
                For i As Integer = 0 To 8
                    Dim iStart As Integer = 0
                    With AuswertungUEBER
                        Select Case i
                            Case 0
                                tmpZR = .Nachtzeitraum_0
                                iStart = 0
                            Case 1
                                tmpZR = .Nachtzeitraum_1
                                iStart = 1
                            Case 2
                                tmpZR = .Nachtzeitraum_2
                                iStart = 2
                            Case 3
                                tmpZR = .Nachtzeitraum_3
                                iStart = 3
                            Case 4
                                tmpZR = .Nachtzeitraum_4
                                iStart = 4
                            Case 5
                                tmpZR = .Nachtzeitraum_5
                                iStart = 5
                            Case 6
                                tmpZR = .Tagzeitraum
                                Select Case .Tagzeitraum.iRowIX
                                    Case Is < 14
                                        iStart = 6
                                    Case Is < 26
                                        iStart = 7
                                    Case Is < 38
                                        iStart = 8
                                    Case Is < 50
                                        iStart = 9
                                    Case Is < 62
                                        iStart = 10
                                    Case Is < 74
                                        iStart = 11
                                    Case Is < 86
                                        iStart = 12
                                    Case Is < 98
                                        iStart = 13
                                    Case Is < 110
                                        iStart = 14
                                    Case Is < 122
                                        iStart = 15
                                    Case Is < 134
                                        iStart = 16
                                    Case Is < 146
                                        iStart = 17
                                    Case Is < 158
                                        iStart = 18
                                    Case Is < 170
                                        iStart = 19
                                    Case Is < 182
                                        iStart = 20
                                    Case Is < 174
                                        iStart = 21
                                End Select
                            Case 7
                                tmpZR = .Nachtzeitraum_22
                                iStart = 22
                            Case 8
                                tmpZR = .Nachtzeitraum_23
                                iStart = 23
                        End Select
                    End With

                    With tmpZR
                        If Not IsNothing(.Pegel) Then
                            '.iRowIX = CInt(tRest_Ar(2)) - iStart * 12 - 1
                            Dim iRow As Integer = .iRowIX + 1 + iStart * 12
                            Dim Datum As Date = New Date(tDate.Year, tDate.Month, tDate.Day, iStart, 0, 0) 'arPegel(0)
                            Dim arPegel() As String = .Pegel(.iRowIX).split(";")

                            Dim str As String = "" '.iRowIX  

                            If .bMaxRQ And .bMaxVF Then
                                str = ";RQ+VF;"
                            ElseIf .bMaxVF Then
                                str = ";VF;"
                            ElseIf .bMaxRQ Then
                                str = ";RQ;"
                            Else
                                str = ";;"
                            End If
                            'If str <> "" Then ubArr.Add(str)

                            If .prozGes >= proz Then _
                                str = str & IIf(.prozGes > 100, "100", .prozGes) & " %"

                            If str <> ";;" Then
                                Dim jjjjmmttHH As String = Format(Datum, "yyyy_MM_dd_hh")
                                Dim Bemerkung As String = ""
                                Dim fil As IO.FileInfo = New IO.FileInfo(My.Settings.PfadZielordner & "\" & Format(Datum, "yyyy_MM_dd") & "\AUS_ME" & .Messeinhei & "_" & jjjjmmttHH & ".txt")
                                If fil.Exists Then Bemerkung = System.IO.File.ReadAllText(fil.FullName)
                                'If arPegel.Length > 11 Then Bemerkung = arPegel(11)

                                ubArr.Add(Format(Datum, "dd.MM.yyyy hh") & str & ";ME " & .Messeinhei & ";" & Bemerkung & ";" & iRow)
                            End If

                        End If
                    End With

                    If ubArr.Count >= anz Then Exit Do
                Next

                tDate = tDate.AddDays(-1)
            Loop


            For iAr As Integer = 0 To ubArr.Count - 1
                Dim tDS As String() = ubArr(iAr).Split(";")
                Dim lvi As ListViewItem = Me.LV_Ueberschreitungen.Items.Add(tDS(tDS.Length - 2)) '0)) 'tDS.Length - 2))
                lvi.Tag = tDS(tDS.Length - 1)
                If iAr Mod 2 <> 0 Then lvi.BackColor = Color.White 'farbe1
                'Else : ListView1.Items.Item(i).BackColor = Color.LightGray 'farbe2
                'End If
                For iDS As Integer = 0 To tDS.Length - 3 ' 2
                    lvi.SubItems.Add(tDS(iDS))
                Next
            Next

            Me.LV_Ueberschreitungen.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)

            Me.LV_Ueberschreitungen.Columns(0).DisplayIndex = 3

            Me.Cursor = Cursors.Default
        Else
            MsgBox("Das Startdatum muss vor heute liegen.", MsgBoxStyle.OkOnly, "Fehler")
        End If

    End Sub
    Public Function Get_Schwellen_H(ByVal iH As Integer, ByVal bRK As Boolean) As List(Of Integer)
        Dim tList As List(Of Integer) = New List(Of Integer)

        Dim tNodeSchwellen As XmlNode = ndAllgemein.Item("Schwellen_SP")
        If bRK Then tNodeSchwellen = ndAllgemein.Item("Schwellen_RK")

        With tNodeSchwellen
            For iSch As Integer = 0 To .ChildNodes.Count - 1 'Schwellen.Length - 1
                Select Case iH
                    Case 0
                        tList.Add(.ChildNodes(iSch).Attributes("H0").Value)
                    Case 1
                        tList.Add(.ChildNodes(iSch).Attributes("H1").Value)
                    Case 2
                        tList.Add(.ChildNodes(iSch).Attributes("H2").Value)
                    Case 3
                        tList.Add(.ChildNodes(iSch).Attributes("H3").Value)
                    Case 4
                        tList.Add(.ChildNodes(iSch).Attributes("H4").Value)
                    Case 5
                        tList.Add(.ChildNodes(iSch).Attributes("H5").Value)
                    Case 6
                        tList.Add(.ChildNodes(iSch).Attributes("H6").Value)
                    Case 7
                        tList.Add(.ChildNodes(iSch).Attributes("H7").Value)
                    Case 8
                        tList.Add(.ChildNodes(iSch).Attributes("H8").Value)
                    Case 9
                        tList.Add(.ChildNodes(iSch).Attributes("H9").Value)
                    Case 10
                        tList.Add(.ChildNodes(iSch).Attributes("H10").Value)
                    Case 11
                        tList.Add(.ChildNodes(iSch).Attributes("H11").Value)
                    Case 12
                        tList.Add(.ChildNodes(iSch).Attributes("H12").Value)
                    Case 13
                        tList.Add(.ChildNodes(iSch).Attributes("H13").Value)
                    Case 14
                        tList.Add(.ChildNodes(iSch).Attributes("H14").Value)
                    Case 15
                        tList.Add(.ChildNodes(iSch).Attributes("H15").Value)
                    Case 16
                        tList.Add(.ChildNodes(iSch).Attributes("H16").Value)
                    Case 17
                        tList.Add(.ChildNodes(iSch).Attributes("H17").Value)
                    Case 18
                        tList.Add(.ChildNodes(iSch).Attributes("H18").Value)
                    Case 19
                        tList.Add(.ChildNodes(iSch).Attributes("H19").Value)
                    Case 20
                        tList.Add(.ChildNodes(iSch).Attributes("H20").Value)
                    Case 21
                        tList.Add(.ChildNodes(iSch).Attributes("H21").Value)
                    Case 22
                        tList.Add(.ChildNodes(iSch).Attributes("H22").Value)
                    Case 23
                        tList.Add(.ChildNodes(iSch).Attributes("H23").Value)
                End Select
            Next

            'End If
        End With

        Return tList
    End Function
    Public Sub Update_Anzeige_Dauernd(ByVal obj As Object)

        If Daten_einlesen() = False Then Exit Sub 'IO und MAX

        If Set_AuswertungDAUERBETRIEB(New Date(Now.Year, Now.Month, Now.Day, 0, 0, 0)) Then
            With AuswertungDAUERND

                Dim tmpZR As Beurteilungszeitraum_Data
                Dim sngProz_RK As List(Of Integer) = Get_Schwellen_H(0, True) ' Schwellen.H0  
                Dim sngProz_SP As List(Of Integer) = Get_Schwellen_H(0, False) ' Schwellen.H0  
                Select Case Now.Hour
                    Case 0
                        tmpZR = .Nachtzeitraum_0
                    Case 1
                        tmpZR = .Nachtzeitraum_1
                        sngProz_RK = Get_Schwellen_H(1, True)
                        sngProz_SP = Get_Schwellen_H(1, False)
                    Case 2
                        sngProz_RK = Get_Schwellen_H(2, True)
                        sngProz_SP = Get_Schwellen_H(2, False)
                        tmpZR = .Nachtzeitraum_2
                    Case 3
                        sngProz_RK = Get_Schwellen_H(3, True)
                        sngProz_SP = Get_Schwellen_H(3, False)
                        tmpZR = .Nachtzeitraum_3
                    Case 4
                        sngProz_RK = Get_Schwellen_H(4, True)
                        sngProz_SP = Get_Schwellen_H(4, False)
                        tmpZR = .Nachtzeitraum_4
                    Case 5
                        sngProz_RK = Get_Schwellen_H(5, True)
                        sngProz_SP = Get_Schwellen_H(5, False)
                        tmpZR = .Nachtzeitraum_5
                    Case 6
                        sngProz_RK = Get_Schwellen_H(6, True)
                        sngProz_SP = Get_Schwellen_H(6, False)
                        tmpZR = .Tagzeitraum
                    Case 7
                        sngProz_RK = Get_Schwellen_H(7, True)
                        sngProz_SP = Get_Schwellen_H(7, False)
                        tmpZR = .Tagzeitraum
                    Case 8
                        sngProz_RK = Get_Schwellen_H(8, True)
                        sngProz_SP = Get_Schwellen_H(8, False)
                        tmpZR = .Tagzeitraum
                    Case 9
                        sngProz_RK = Get_Schwellen_H(9, True)
                        sngProz_SP = Get_Schwellen_H(9, False)
                        tmpZR = .Tagzeitraum
                    Case 10
                        sngProz_RK = Get_Schwellen_H(10, True)
                        sngProz_SP = Get_Schwellen_H(10, False)
                        tmpZR = .Tagzeitraum
                    Case 11
                        sngProz_RK = Get_Schwellen_H(11, True)
                        sngProz_SP = Get_Schwellen_H(11, False)
                        tmpZR = .Tagzeitraum
                    Case 12
                        sngProz_RK = Get_Schwellen_H(12, True)
                        sngProz_SP = Get_Schwellen_H(12, False)
                        tmpZR = .Tagzeitraum
                    Case 13
                        sngProz_RK = Get_Schwellen_H(13, True)
                        sngProz_SP = Get_Schwellen_H(13, False)
                        tmpZR = .Tagzeitraum
                    Case 14
                        sngProz_RK = Get_Schwellen_H(14, True)
                        sngProz_SP = Get_Schwellen_H(14, False)
                        tmpZR = .Tagzeitraum
                    Case 15
                        sngProz_RK = Get_Schwellen_H(15, True)
                        sngProz_SP = Get_Schwellen_H(15, False)
                        tmpZR = .Tagzeitraum
                    Case 16
                        sngProz_RK = Get_Schwellen_H(16, True)
                        sngProz_SP = Get_Schwellen_H(16, False)
                        tmpZR = .Tagzeitraum
                    Case 17
                        sngProz_RK = Get_Schwellen_H(17, True)
                        sngProz_SP = Get_Schwellen_H(17, False)
                        tmpZR = .Tagzeitraum
                    Case 18
                        sngProz_RK = Get_Schwellen_H(18, True)
                        sngProz_SP = Get_Schwellen_H(18, False)
                        tmpZR = .Tagzeitraum
                    Case 19
                        sngProz_RK = Get_Schwellen_H(19, True)
                        sngProz_SP = Get_Schwellen_H(19, False)
                        tmpZR = .Tagzeitraum
                    Case 20
                        sngProz_RK = Get_Schwellen_H(20, True)
                        sngProz_SP = Get_Schwellen_H(20, False)
                        tmpZR = .Tagzeitraum
                    Case 21
                        sngProz_RK = Get_Schwellen_H(21, True)
                        sngProz_SP = Get_Schwellen_H(21, False)
                        tmpZR = .Tagzeitraum
                    Case 22
                        sngProz_RK = Get_Schwellen_H(22, True)
                        sngProz_SP = Get_Schwellen_H(22, False)
                        tmpZR = .Nachtzeitraum_22
                    Case 23
                        sngProz_RK = Get_Schwellen_H(23, True)
                        sngProz_SP = Get_Schwellen_H(23, False)
                        tmpZR = .Nachtzeitraum_23
                End Select

                ' ''""""   EMAILS  """""""
                ''If Not IsNothing(sngProz) Then
                ''    If sngProz.Count > 0 Then

                ''        For i As Integer = 0 To sngProz.Count - 1
                ''            If tmpZR.prozGes >= sngProz(i) Then

                ''                '### ALARMSCHWELLE ÜBERSCHRITTEN ###
                ''                '*** Wenn in diesem Stundenabschnitt noch nicht versendet, dann...
                ''                If timeEMAIL_Prozent.Year = Now.Year And timeEMAIL_Prozent.Month = Now.Month _
                ''                    And timeEMAIL_Prozent.Day = Now.Day _
                ''                    And timeEMAIL_Prozent.Hour = Now.Hour Then
                ''                Else
                ''                    If bStopped_Email = False Then

                ''                        Dim tmpDate As Date = SendMessage("DaMe: " & i + 1 & ". Alarmschwelle am " & Now.Date & " für die Stunde " & Now.Hour & " bis " & Now.Hour + 1 & " erreicht!", _
                ''                                "Es wurde die " & sngProz(i) & "%-Marke des Gesamtbeurteilungspegels erreicht." & _
                ''                             CStr(IIf(tmpZR.Messeinhei > 0, " Der höchste Anteil am Beurteilungspegel kommt von der Messstelle " & tmpZR.Messeinhei & ".", "")), ndAllgemein.Item("Verteiler").ChildNodes(i).Attributes("Empfaenger").Value)
                ''                        If tmpDate.Year = Now.Year _
                ''                         Then timeEMAIL_Prozent = Now
                ''                        Exit For '# nur für eine Schwellenüberschreitung Meldung absetzen


                ''                    End If

                ''                End If
                ''            End If
                ''        Next

                ''    End If

                ' ''### MAX-KRITERIUM ###
                ' ''*** Wenn in diesem Beurteilungszeitraum noch nicht versendet, dann...
                ''If timeEMAIL_Max.Year = Now.Year And timeEMAIL_Max.Month = Now.Month _
                ''    And timeEMAIL_Max.Day = Now.Day _
                ''    And timeEMAIL_Max.Hour < CInt(IIf(Now.Hour >= 6 And Now.Hour < 22, 22, Now.Hour + 1)) _
                ''    And timeEMAIL_Max.Hour >= CInt(IIf(Now.Hour >= 6 And Now.Hour < 22, 6, Now.Hour)) Then

                ''Else
                ''    'Emails: Prozentuale Auslastung und evtl. MaxPegel-Überschreitungen im aktuellen 
                ''    'Beurteilungszeitraum feststellen
                ''    If tmpZR.bMaxVF Or tmpZR.bMaxRQ Then
                ''        Dim tmpDate As Date = SendMessage("DaMe: Maximalpegel-Kriterium überschritten", _
                ''                "Der Maximalpegel wurde bei der letzten Auswertung vor " & Now.Hour & ":" & Now.Minute & _
                ''                " Uhr innerhalb des Auswertezeitraums von etwa 18 min überschritten.", Allgemein.Max_Verteiler)
                ''        ' bSending = False
                ''        If tmpDate.Year = Now.Year _
                ''            Then timeEMAIL_Max = Now
                ''    End If
                ''End If
                ''End If


                '""""   ANZEIGE  """""""
                Dim iSek As Integer = tmpZR.Restlaufzeit 'Get_Restlaufzeit_Sekunden_ME(Now.Year, Now.Month, Now.Day, CInt(IIf(Now.Hour >= 6 And Now.Hour < 22, 6, Now.Hour)), Get_Messeinheit)
                Dim iStu As Integer = CInt(CStr(iSek / 3600).Split(Chr(44))(0)) '",")(0))
                Dim iMin As Integer = CInt(CStr((iSek - iStu * 3600) / 60).Split(Chr(59))(0)) '",")(0))

                If Not IsNothing(Me.TB_Stunden) Then
                    Me.TB_Stunden.CheckForIllegalCrossThreadCalls = False
                    Me.TB_Stunden.Text = CStr(iStu)
                    Me.TB_Minuten.Text = CStr(iMin)
                    Me.Label_ME.Text = "ME " & CStr(IIf(tmpZR.Messeinhei = 0, "", tmpZR.Messeinhei))

                    Me.PB_Prozentbalken_Ges.Location = New System.Drawing.Point(CInt(tmpZR.prozGes * 5 - 2), 0)
                    Me.PB_Prozentbalken_VF.Location = New System.Drawing.Point(CInt(tmpZR.prozVF * 2 - 2), 0)
                    Me.PB_Prozentbalken_RQ.Location = New System.Drawing.Point(CInt(tmpZR.prozRQ * 2 - 2), 0)

                    'Maxwerte eintragen
                    If tmpZR.bMaxVF Or tmpZR.bMaxRQ Then
                        Me.P_Max_dauernd.BackColor = Color.Red
                        Me.Label_Max_dauernd.Text = IIf(tmpZR.bMaxVF And tmpZR.bMaxRQ, "VF+RQ", IIf(tmpZR.bMaxVF, "VF", IIf(tmpZR.bMaxRQ, "RQ", ""))).ToString
                    Else
                        Me.P_Max_dauernd.BackColor = Color.Green
                        Me.Label_Max_dauernd.Text = "-"
                    End If

                    'Falls gerade die UserControl_Gesamtansicht geöffnet ist und im DTP das heutige Datum steht, dann 
                    'wird Aktuallisieren ausgeführt.
                    ' Me.SplitContainer2.Panel1.Controls("Panel1").Controls.Add(uc_Messpunkte)

                    If Not IsNothing(Me.SplitContainer2.Panel1.Controls("Panel1").Controls) Then
                        If TypeOf Me.SplitContainer2.Panel1.Controls("Panel1").Controls(0) Is UserControl_Gesammtansicht Then
                            Dim ucGes As UserControl_Gesammtansicht = CType(Me.SplitContainer2.Panel1.Controls("Panel1").Controls(0), UserControl_Gesammtansicht)
                            If ucGes.DTP_1.Value.Year = Now.Year And ucGes.DTP_1.Value.Month = Now.Month And ucGes.DTP_1.Value.Day = Now.Day Then
                                ucGes.Aktuallisieren(True)
                            End If
                        End If
                    End If
                End If
            End With
        End If

        '""""   MONATSBERICHT  """""""
        'Monatsbericht speichern
        Dim tmpNDAllgemein As XmlNode = ndAllgemein
        If ndAllgemein.Attributes("bAutoMonatsbericht").Value = "" Then ndAllgemein.Attributes("bAutoMonatsbericht").Value = "false"
        If ndAllgemein.Attributes("bAutoMonatsbericht").Value Then 'My.Settings.bAutoMonatsbericht Then
            Dim dateLetzter As Date = Now.AddMonths(-1)
            Dim dateMake As Date = New Date(Now.Year, Now.Month, 1, 5, 10, 0)

            Dim tFilename As String = "PG Monatsbericht " & dateLetzter.Year & "_" & IIf(dateLetzter.Month < 10, "0" & dateLetzter.Month, dateLetzter.Month).ToString
            Dim fi As IO.FileInfo = New IO.FileInfo(My.Settings.PfadZielordner & "\_Monatsberichte\" & tFilename & ".xlsx")

            If My.Settings.PfadZielordner <> "" Then
                Dim di As IO.DirectoryInfo = New IO.DirectoryInfo(My.Settings.PfadZielordner)
                If di.Exists Then If fi.Exists = False And Now > dateMake Then Drucke_Monatsbericht(Now.AddMonths(-1).Month, Now.AddMonths(-1).Year, True)
            End If
        End If
    End Sub
#End Region


    Private Sub LV_Ueberschreitungen_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LV_Ueberschreitungen.SelectedIndexChanged

    End Sub
End Class
