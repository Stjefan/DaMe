Public Class UC_Verteiler
    Public ndVerteilerNr As XmlNode
    Public bLoad As Boolean

    Private Sub UC_Verteiler_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        bLoad = True

        Me.TB_Empfaenger.Text = ndVerteilerNr.Attributes("Empfaenger").Value

        'Me.Label_Verteiler.Text = "Verteiler " & Me.Parent.Controls.Count - Me.Parent.Controls.GetChildIndex(Me)

        bLoad = False

    End Sub

    Private Sub TB_Empfaenger_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_Empfaenger.TextChanged

        Dim iCursorPos As Integer = Me.TB_Empfaenger.SelectionStart
        If iCursorPos > 1 Then
            Dim strZeichen As String = Microsoft.VisualBasic.Mid(Me.TB_Empfaenger.Text, iCursorPos, 1)
            If Microsoft.VisualBasic.Mid(Me.TB_Empfaenger.Text, iCursorPos, 1) = ";" Then
                Me.TB_Empfaenger.Text = Me.TB_Empfaenger.Text.Insert(iCursorPos, "" & Chr(13) & Chr(10) & "")
                Me.TB_Empfaenger.SelectionStart = iCursorPos + 2
            ElseIf Microsoft.VisualBasic.Mid(Me.TB_Empfaenger.Text, iCursorPos - 1, 1) = ";" Then
                Me.TB_Empfaenger.Text = Me.TB_Empfaenger.Text.Insert(iCursorPos - 1, "" & Chr(13) & Chr(10) & "")
                Me.TB_Empfaenger.SelectionStart = iCursorPos + 2
            End If
        End If
        If bLoad = False Then
            ndVerteilerNr.Attributes("Empfaenger").Value = Me.TB_Empfaenger.Text
            Dim iVNr As Integer = Me.Label_Verteiler.Text.Replace("Verteiler ", "") - 1
            ndAllgemein.Item("Verteiler").ChildNodes(iVNr).Attributes("Empfaenger").Value = Me.TB_Empfaenger.Text

            Dim tmpNd As XmlNode = ndAllgemein
        End If
    End Sub


    'Private Sub TB_Empfaenger_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TB_Empfaenger.Validating
    '    ndVerteilerNr.Attributes("Empfaenger").Value = Me.TB_Empfaenger.Text

    '    'Daten_Allgemein_Speichern()
    'End Sub

    Private Sub Button_Remove_Verteiler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Remove_Verteiler.Click
         
        Dim iVNr As Integer = Me.Label_Verteiler.Text.Replace("Verteiler ", "") - 1
        ndAllgemein.Item("Verteiler").RemoveChild(ndAllgemein.Item("Verteiler").ChildNodes(iVNr))

        Dim ctr As Control = Me.Parent
        Do Until TypeOf (ctr) Is UserControl_Einstellungen
            ctr = ctr.Parent
        Loop

        If TypeOf (ctr) Is UserControl_Einstellungen Then CType(ctr, UserControl_Einstellungen).Update_Verteiler()


    End Sub
End Class
