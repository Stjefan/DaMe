Option Strict Off
Imports System.Net.Mail
Imports System.Threading
Imports System.Text

Module Modul_Thread

    Public bStopped_Email As Boolean

    Public timeEMAIL_Prozent As Date
    Public timeEMAIL_Max As Date
    Public bSending As Boolean

    Public Function Email_Pruefung() As Boolean
        Dim bReadyExists As Boolean = True
        If ndAllgemein.Attributes("Sender").Value = "" Or _
                ndAllgemein.Attributes("SMTP").Value = "" Then 'Or ndAllgemein.Attributes("EmpfaengerEmail").Value = ""'Or Me.TB_LoginName.Text = ""
            bReadyExists = False
        End If
        Return bReadyExists
    End Function

    Public Function SendMessage(ByVal betrSend As String, ByVal txtSend As String, ByVal Verteiler As String) As Date ', Optional ByVal tAttachments() As String = Nothing, Optional ByVal tEmpfaenger As String = Nothing) As Date ' As Boolean
        'Wenn die Attachments zu groﬂ werden, gibt es Probleme mit dem Senden der Emails
        Try

            If bSending = False Then    'Wenn eine Email gesendet wird, wird das Senden weiterer Emails geblockt
                bSending = True

                'Wenn angegeben ist, dass am Wochenende keine Emails versendet werden sollen, dann in Log-File schreiben
                If ndAllgemein.Attributes("bWochenende").Value = False And _
                        (Now.DayOfWeek = DayOfWeek.Saturday Or Now.DayOfWeek = DayOfWeek.Sunday) Then

                    '******** hier weiter ********************
                    'in txt-File schreiben
                    Dim strDatNAME As String = My.Settings.PfadZielordner & "\_Send_Log\Send_Log_" & Now.ToString.Replace(".", "_").Replace(":", "_") & ".txt"
                    Dim fio As IO.FileInfo = New IO.FileInfo(strDatNAME)
                    Dim bAppend As Boolean = False
                    If fio.Exists Then bAppend = True 'Falls die Datei existiert, wird Text angeh‰ngt, 
                    'andernfalls wird die Datei erzeugt.

                    Dim sw As IO.StreamWriter
                    sw = New IO.StreamWriter(strDatNAME, bAppend)
                    sw.WriteLine(Chr(13) & Chr(10) & "Nachricht von : " & Now)
                    sw.WriteLine(Chr(13) & Chr(10) & betrSend)
                    sw.WriteLine(Chr(13) & Chr(10) & txtSend & Chr(13) & Chr(10))
                    sw.Close()

                    SendMessage = Now 'True
                    bSending = False
                    Exit Function
                Else
                    ' ''10 Attachments pro Email
                    ''Dim iCounter As Integer = 0

                    ''Dim iL As Integer = 0
                    ''If Not IsNothing(tAttachments) Then iL = tAttachments.Length

                    ''Do While iCounter <= iL

                    Dim smtp As SmtpClient
                    Dim msg As MailMessage

                    Dim Sender As String = ndAllgemein.Attributes("Sender").Value 'me.TB_Sender.Text
                    Dim tmpEm As String '= Me.TB_Empfaenger.Text.Replace(Chr(13), "").Replace(Chr(10), "").Split(";")

                    Dim rEmpf() As String = Nothing

                    'If IsNothing(tEmpfaenger) Then
                    Dim verteilerNr As Integer = ndAllgemein.Attributes("Test_Verteiler").Value
                    If ndAllgemein.Item("Verteiler").ChildNodes.Count < verteilerNr Then
                        SendMessage = Nothing
                        bSending = False
                        Exit Function
                    End If
                    Dim Empfaenger() As String = ndAllgemein.Item("Verteiler").ChildNodes(verteilerNr - 1).Attributes("Empfaenger").Value.Replace(Chr(13), "").Replace(Chr(10), "").Split(Chr(59)) 'Me.TB_Empfaenger.Text.Replace(Chr(13), "").Replace(Chr(10), "").Split(Chr(59)) '(";")

                    For i As Integer = 0 To Empfaenger.Length - 1
                        If Empfaenger(i) <> "" Then

                            Dim iLen As Integer = 0
                            If Not IsNothing(rEmpf) Then iLen = rEmpf.Length

                            ReDim Preserve rEmpf(iLen)
                            rEmpf(iLen) = Empfaenger(i)
                        End If
                    Next
                   

                    If IsNothing(rEmpf) Or Sender = "" Or InStr(Sender, "@") = 0 Or InStr(Sender, ".") = 0 Then
                        SendMessage = Nothing
                        bSending = False
                        Exit Function
                    Else
                        If Sender <> "" And rEmpf.Length > 0 Then ' <> "" Then
                            msg = New MailMessage(Sender, Trim(rEmpf(0)))
                            '            msg.From = New System.Net.Mail.MailAddress(Sender)
                            msg.Sender = New System.Net.Mail.MailAddress(Sender)
                            '           msg.To = New System.Net.Mail.MailAddress(rEmpf(0))
                            For i As Integer = 1 To rEmpf.Length - 1 'Me.LV_Empfaenger.Items.Count - 1
                                tmpEm = Trim(rEmpf(i)) '.Replace(Chr(13), "").Replace(Chr(10), ""))
                                If tmpEm <> "" Then msg.To.Add(tmpEm) 'Me.LV_Empfaenger.Items(i).Text)
                            Next

                            msg.Subject = betrSend
                            msg.SubjectEncoding = Encoding.GetEncoding("ISO-8859-1") 'System.Text.Encoding.UTF8
                            msg.Body = txtSend
                            msg.BodyEncoding = Encoding.GetEncoding("ISO-8859-1") 'System.Text.Encoding.UTF8
                         
                            smtp = New SmtpClient(ndAllgemein.Attributes("SMTP").Value) 'Me.TB_SMTPServer.Text)
                            smtp.DeliveryMethod = SmtpDeliveryMethod.Network
                            smtp.Credentials = New System.Net.NetworkCredential(ndAllgemein.Attributes("LoginName").Value, ndAllgemein.Attributes("Passwort").value) 'Me.TB_LoginName.Text, Me.TB_Passwort.Text)
                            Dim iTime As Integer = smtp.Timeout
                            smtp.Timeout = 300000
                            smtp.Send(msg)

                            SendMessage = Now

                        Else
                            SendMessage = Nothing
                            bSending = False
                            Exit Function
                        End If
                    End If
                    ''Loop
                End If

                bSending = False
            Else
                Return Nothing
            End If


        Catch ex As Exception
            bSending = False
            Return Nothing

        End Try
    End Function

    'Public Function Get_PfadDatum(ByVal Datum As Date, ByVal ME_IX As Byte) As String
    '    Return Datum.Year & "_" & _
    '        IIf(Datum.Month < 10, "0" & Datum.Month, Datum.Month).ToString & "_" & _
    '        IIf(Datum.Day < 10, "0" & Datum.Day, Datum.Day).ToString & "\" & _
    '        Get_Ordnername_ME(ME_IX) & "\"
    'End Function

    'Private Function Get_Ordnername_ME(ByVal btME As Byte) As String
    '    If btME = 1 Then
    '        Return "ME1 - " & Messtelle1
    '    ElseIf btME = 2 Then
    '        Return "ME2 - " & Messtelle2
    '    ElseIf btME = 3 Then
    '        Return "ME3 - " & Messtelle3
    '    Else
    '        Return ""
    '    End If
    'End Function
End Module
