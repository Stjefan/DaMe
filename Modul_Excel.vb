Option Strict Off
Imports Microsoft.Office.Interop.Excel

Module Modul_Excel
    Public Function Drucke_Monatsbericht(ByVal Monat As Integer, ByVal Jahr As Integer, ByVal bAuto As Boolean) As Boolean
        Dim xlApp As Application
        Dim xlMappe As Workbook = Nothing
        Dim xlBlatt As Worksheet

        Try
            xlApp = CType(CreateObject("Excel.Application"), Application)
            xlMappe = CType(xlApp.Workbooks.Open(My.Settings.PfadZielordner & "\Monatsbericht Vorlage.xltx", UpdateLinks:=True, ReadOnly:=True), Workbook)   'sPathXLDB & "Muster_Export.xls"

            Dim bExist As Boolean = False
            For Each ws As Worksheet In xlMappe.Worksheets
                If ws.Name = "Tabelle1" Then bExist = True
            Next ws
            If bExist Then
                xlBlatt = CType(xlMappe.Worksheets("Tabelle1"), Worksheet)

                '%Zahlen vom Tagzeitraum und den kritischsten Wert in der Nacht

                For iTag As Integer = 1 To Date.DaysInMonth(Jahr, Monat)

                    Dim tDate As Date = New Date(Jahr, Monat, iTag)
                    If Daten_einlesen() = False Then Exit Function 'IO und MAX
                    If Set_AuswertungMonat(tDate) = False Then
                        MsgBox("Es konnten Dateien, die zur Erstellung des Monatsberichts benötigt werden, nicht geöffnet werden, da sie von einem anderen Prozess verwendet werden. Versuchen Sie es später noch einmal.", MsgBoxStyle.OkOnly, "Zugriffskonflikt")
                        xlMappe.Close()
                        Exit Function
                    End If

                    'Dim prozAnteilN As Integer = 0
                    Dim prozAnteilN As Integer() '= CInt(AuswertungMonat.Nachtzeitraum_0.prozGes)
                    ReDim Preserve prozAnteilN(2)
                    prozAnteilN(0) = CInt(AuswertungMonat.Nachtzeitraum_0.prozVF)
                    prozAnteilN(1) = CInt(AuswertungMonat.Nachtzeitraum_0.prozRQ)
                    prozAnteilN(2) = CInt(AuswertungMonat.Nachtzeitraum_0.prozGes)
                    Dim tProz As Integer() ' = Auswertung.Nachtzeitraum_1.prozGes
                    ReDim Preserve tProz(2)

                    For iNacht As Integer = 0 To 23
                        If iNacht <= 6 Or iNacht >= 22 Then
                            Select Case iNacht
                                Case 1
                                    tProz(0) = CInt(AuswertungMonat.Nachtzeitraum_1.prozVF)
                                    tProz(1) = CInt(AuswertungMonat.Nachtzeitraum_1.prozRQ)
                                    tProz(2) = CInt(AuswertungMonat.Nachtzeitraum_1.prozGes)
                                Case 2
                                    tProz(0) = CInt(AuswertungMonat.Nachtzeitraum_2.prozVF)
                                    tProz(1) = CInt(AuswertungMonat.Nachtzeitraum_2.prozRQ)
                                    tProz(2) = CInt(AuswertungMonat.Nachtzeitraum_2.prozGes)
                                Case 3
                                    tProz(0) = CInt(AuswertungMonat.Nachtzeitraum_3.prozVF)
                                    tProz(1) = CInt(AuswertungMonat.Nachtzeitraum_3.prozRQ)
                                    tProz(2) = CInt(AuswertungMonat.Nachtzeitraum_3.prozGes)
                                Case 4
                                    tProz(0) = CInt(AuswertungMonat.Nachtzeitraum_4.prozVF)
                                    tProz(1) = CInt(AuswertungMonat.Nachtzeitraum_4.prozRQ)
                                    tProz(2) = CInt(AuswertungMonat.Nachtzeitraum_4.prozGes)
                                Case 5
                                    tProz(0) = CInt(AuswertungMonat.Nachtzeitraum_5.prozVF)
                                    tProz(1) = CInt(AuswertungMonat.Nachtzeitraum_5.prozRQ)
                                    tProz(2) = CInt(AuswertungMonat.Nachtzeitraum_5.prozGes)
                                Case 22
                                    tProz(0) = CInt(AuswertungMonat.Nachtzeitraum_22.prozVF)
                                    tProz(1) = CInt(AuswertungMonat.Nachtzeitraum_22.prozRQ)
                                    tProz(2) = CInt(AuswertungMonat.Nachtzeitraum_22.prozGes)
                                Case 23
                                    tProz(0) = CInt(AuswertungMonat.Nachtzeitraum_23.prozVF)
                                    tProz(1) = CInt(AuswertungMonat.Nachtzeitraum_23.prozRQ)
                                    tProz(2) = CInt(AuswertungMonat.Nachtzeitraum_23.prozGes)
                            End Select

                            If prozAnteilN(2) < tProz(2) Then
                                prozAnteilN(0) = tProz(0)
                                prozAnteilN(1) = tProz(1)
                                prozAnteilN(2) = tProz(2)
                            End If
                        End If
                    Next
                    'Next

                    'prozAnteil: Maximaler Wert für 1=VF, 2=RQ, 3=Ges
                    xlBlatt.Cells(iTag + 1, 1 + 1).value = AuswertungMonat.Tagzeitraum.prozVF 'prozAnteilT
                    xlBlatt.Cells(iTag + 1, 1 + 2).value = AuswertungMonat.Tagzeitraum.prozRQ
                    xlBlatt.Cells(iTag + 1, 1 + 3).value = AuswertungMonat.Tagzeitraum.prozGes
                    xlBlatt.Cells(iTag + 1, 4 + 1).value = prozAnteilN(0)
                    xlBlatt.Cells(iTag + 1, 4 + 2).value = prozAnteilN(1)
                    xlBlatt.Cells(iTag + 1, 4 + 3).value = prozAnteilN(2)
                    'Next
                Next

                For iTag As Integer = Date.DaysInMonth(Jahr, Monat) + 1 To 31
                    xlBlatt.Range(xlBlatt.Cells(iTag + 1, 1), xlBlatt.Cells(iTag + 1, 11)).Value = ""
                Next

                xlBlatt.Cells(1, 1).value = "'" & System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.MonthNames(Monat - 1) & " " & Jahr
                xlBlatt.Cells(60, 1).value = "'" & IIf(Now.Day < 10, "0" & Now.Day, Now.Day).ToString & "." & IIf(Now.Month < 10, "0" & Now.Month, Now.Month).ToString & "." & Now.Year
            End If

            Dim tFilename As String = "PG Monatsbericht " & Jahr & "_" & IIf(Monat < 10, "0" & Monat, Monat).ToString
            If bAuto Then
                xlApp.DisplayAlerts = False
                Dim dio As IO.DirectoryInfo = New IO.DirectoryInfo(My.Settings.PfadZielordner & "\_Monatsberichte\")
                If dio.Exists = False Then dio.Create()
                xlMappe.SaveAs(My.Settings.PfadZielordner & "\_Monatsberichte\" & tFilename & ".xlsx")
                xlMappe.Close()
                xlApp.DisplayAlerts = True

            Else
                Form_Grossansicht.SaveFileDialog_Monatsbericht.FileName = tFilename
                Form_Grossansicht.SaveFileDialog_Monatsbericht.InitialDirectory = My.Settings.PfadZielordner

                Form_Grossansicht.SaveFileDialog_Monatsbericht.ShowDialog()

                xlMappe.SaveAs(Form_Grossansicht.SaveFileDialog_Monatsbericht.FileName)
                xlMappe.Close()

                Diagnostics.Process.Start(Form_Grossansicht.SaveFileDialog_Monatsbericht.FileName)
            End If

            AuswertungMonat = Nothing
            Return True
        Catch ex As IO.IOException
            If Not IsNothing(xlMappe) Then xlMappe.Close()
            AuswertungMonat = Nothing
            Return False
        Catch ex As Exception
            'If Not IsNothing(xlMappe) Then xlMappe.Close()
            MsgBox("Es konnte nicht gedruckt werden.", MsgBoxStyle.OkOnly, "Druckfehler")
            AuswertungMonat = Nothing
            Return False
        End Try
    End Function
End Module
