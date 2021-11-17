Imports System.Windows.Forms

Public Class Dialog_Immissionsort
    Public ptKoordinaten As PointF

    Public iCurIO As Integer

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If iCurIO > -1 Then Save_Var(iCurIO)

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Update_Anzeige()
        
        Me.ListView_Immissionsort.Items.Clear()
        If Not IsNothing(Immissionsort) Then
            For iIO As Integer = 0 To Immissionsort.Length - 1
                With Immissionsort(iIO)
                    Dim lvItem As ListViewItem = Me.ListView_Immissionsort.Items.Add(iIO + 1 & " " & .Bezeichnung)
                    '                    lvItem.SubItems.Add(iIO + 1)
                    lvItem.Tag = iIO
                End With
            Next
        End If
    End Sub

    Private Sub Update_Anzeige_Immissionsort(ByVal iIO As Integer)
        Me.Panel_Eingabe.Enabled = False
        With Immissionsort(iIO)
            Dim tmpIO As Immissionsort_Data() = Immissionsort

            Me.TB_Bezeichnung.Text = .Bezeichnung

            Me.NUD_Rechts.Value = CDec(.gk.Rechts)
            Me.NUD_Hoch.Value = CDec(.gk.Hoch)

            Me.NUD_GTag_IO.Value = .GTag_IO
            Me.NUD_GNacht_IO.Value = .GNacht_IO

            Me.ChB_Ruhezeit.Checked = .bRuhezeit
            Me.ChB_ME1_VF.Checked = .ME1_VF.bVF
            Me.ChB_ME2.Checked = .ME2_VF.bVF
            Me.ChB_ME3.Checked = .ME3_VF.bVF

            Me.NUD_ME1_A.Value = CDec(.ME1_VF.A)
            Me.NUD_ME1_B.Value = CDec(.ME1_VF.B)
            Me.NUD_ME1_C.Value = CDec(.ME1_VF.C)
            Me.NUD_ME1_D.Value = CDec(.ME1_VF.D)
            Me.NUD_ME1_E.Value = CDec(.ME1_VF.E)
            Me.ChB_ME1_Bed2.Checked = .ME1_VF.bBed2
            Me.NUD_ME1_Bed2.Value = CDec(.ME1_VF.Bed2)
            Me.NUD_ME1_A_Bed2.Value = CDec(.ME1_VF.A_Bed2)
            Me.NUD_ME1_B_Bed2.Value = CDec(.ME1_VF.B_Bed2)
            Me.NUD_ME1_C_Bed2.Value = CDec(.ME1_VF.C_Bed2)
            Me.NUD_ME1_D_Bed2.Value = CDec(.ME1_VF.D_Bed2)
            Me.NUD_ME1_E_Bed2.Value = CDec(.ME1_VF.E_Bed2)
            Me.ChB_ME1_Bed3.Checked = .ME1_VF.bBed3
            Me.NUD_ME1_Bed3.Value = CDec(.ME1_VF.Bed3)
            Me.NUD_ME1_A_Bed3.Value = CDec(.ME1_VF.A_Bed3)
            Me.NUD_ME1_B_Bed3.Value = CDec(.ME1_VF.B_Bed3)
            Me.NUD_ME1_C_Bed3.Value = CDec(.ME1_VF.C_Bed3)
            Me.NUD_ME1_D_Bed3.Value = CDec(.ME1_VF.D_Bed3)
            Me.NUD_ME1_E_Bed3.Value = CDec(.ME1_VF.E_Bed3)

            Me.NUD_ME2_A.Value = CDec(.ME2_VF.A)
            Me.NUD_ME2_B.Value = CDec(.ME2_VF.B)
            Me.NUD_ME2_C.Value = CDec(.ME2_VF.C)
            Me.NUD_ME2_D.Value = CDec(.ME2_VF.D)
            Me.NUD_ME2_E.Value = CDec(.ME2_VF.E)
            Me.ChB_ME2_Bed2.Checked = .ME2_VF.bBed2
            Me.NUD_ME2_Bed2.Value = CDec(.ME2_VF.Bed2)
            Me.NUD_ME2_A_Bed2.Value = CDec(.ME2_VF.A_Bed2)
            Me.NUD_ME2_B_Bed2.Value = CDec(.ME2_VF.B_Bed2)
            Me.NUD_ME2_C_Bed2.Value = CDec(.ME2_VF.C_Bed2)
            Me.NUD_ME2_D_Bed2.Value = CDec(.ME2_VF.D_Bed2)
            Me.NUD_ME2_E_Bed2.Value = CDec(.ME2_VF.E_Bed2)
            Me.ChB_ME2_Bed3.Checked = .ME2_VF.bBed3
            Me.NUD_ME2_Bed3.Value = CDec(.ME2_VF.Bed3)
            Me.NUD_ME2_A_Bed3.Value = CDec(.ME2_VF.A_Bed3)
            Me.NUD_ME2_B_Bed3.Value = CDec(.ME2_VF.B_Bed3)
            Me.NUD_ME2_C_Bed3.Value = CDec(.ME2_VF.C_Bed3)
            Me.NUD_ME2_D_Bed3.Value = CDec(.ME2_VF.D_Bed3)
            Me.NUD_ME2_E_Bed3.Value = CDec(.ME2_VF.E_Bed3)

            Me.NUD_ME3_A.Value = CDec(.ME3_VF.A)
            Me.NUD_ME3_B.Value = CDec(.ME3_VF.B)
            Me.NUD_ME3_C.Value = CDec(.ME3_VF.C)
            Me.NUD_ME3_D.Value = CDec(.ME3_VF.D)
            Me.NUD_ME3_E.Value = CDec(.ME3_VF.E)
            Me.ChB_ME3_Bed2.Checked = .ME3_VF.bBed2
            Me.NUD_ME3_Bed2.Value = CDec(.ME3_VF.Bed2)
            Me.NUD_ME3_A_Bed2.Value = CDec(.ME3_VF.A_Bed2)
            Me.NUD_ME3_B_Bed2.Value = CDec(.ME3_VF.B_Bed2)
            Me.NUD_ME3_C_Bed2.Value = CDec(.ME3_VF.C_Bed2)
            Me.NUD_ME3_D_Bed2.Value = CDec(.ME3_VF.D_Bed2)
            Me.NUD_ME3_E_Bed2.Value = CDec(.ME3_VF.E_Bed2)
            Me.ChB_ME3_Bed3.Checked = .ME3_VF.bBed3
            Me.NUD_ME3_Bed3.Value = CDec(.ME3_VF.Bed3)
            Me.NUD_ME3_A_Bed3.Value = CDec(.ME3_VF.A_Bed3)
            Me.NUD_ME3_B_Bed3.Value = CDec(.ME3_VF.B_Bed3)
            Me.NUD_ME3_C_Bed3.Value = CDec(.ME3_VF.C_Bed3)
            Me.NUD_ME3_D_Bed3.Value = CDec(.ME3_VF.D_Bed3)
            Me.NUD_ME3_E_Bed3.Value = CDec(.ME3_VF.E_Bed3)

            If .btME_RQ = 1 Then
                Me.RB_ME1.Checked = True
            ElseIf .btME_RQ = 2 Then
                Me.RB_ME2.Checked = True
            ElseIf .btME_RQ = 3 Then
                Me.RB_ME3.Checked = True
            End If

            Me.NUD_RQ_A.Value = CDec(.RQ_A)
            Me.NUD_RQ_B.Value = CDec(.RQ_B)
            Me.NUD_RQ_C.Value = CDec(.RQ_C)
            Me.NUD_RQ_D.Value = CDec(.RQ_D)
            Me.NUD_RQ_E.Value = CDec(.RQ_E)

            Me.ChB_ME2_RQ.Checked = .bME2_RQ
            Me.NUD_ME2_RQ_A.Value = CDec(.RQ_ME2_A)
            Me.NUD_ME2_RQ_B.Value = CDec(.RQ_ME2_B)
            Me.NUD_ME2_RQ_C.Value = CDec(.RQ_ME2_C)
            Me.NUD_ME2_RQ_D.Value = CDec(.RQ_ME2_D)
            Me.NUD_ME2_RQ_E.Value = CDec(.RQ_ME2_E)
        End With
    End Sub
#Region "Buttons für Immissionsorte"
    Private Function Get_ID_NEXT() As Integer
        Dim tID As Integer = 1
        If Not IsNothing(Immissionsort) Then
            Dim bExist As Boolean = True
            Do While bExist = True
                bExist = False
                For iIO As Integer = 0 To Immissionsort.Length - 1
                    If Immissionsort(iIO).ID = tID Then
                        bExist = True
                        tID = tID + 1
                        Exit For
                    End If
                Next
            Loop
        End If
        Return tID
    End Function
    Private Function refExist(ByVal Name As String) As Boolean
        refExist = False
        If Not IsNothing(Immissionsort) Then
            For iRef As Integer = 0 To Immissionsort.Length - 1
                If Immissionsort(iRef).Bezeichnung = Name Then
                    Return True
                End If
            Next
        End If
    End Function
    Private Sub Save_Var(ByVal iIO As Integer)
        'For iRef As Integer = 0 To Me.ListView_Fenstertyp.Items.Count - 1
        'ReDim Preserve Immissionsort(iRef)
        With Immissionsort(iIO)

            .Bezeichnung = Me.TB_Bezeichnung.Text
            .gk.Rechts = Me.NUD_Rechts.Value
            .gk.Hoch = Me.NUD_Hoch.Value

            .bRuhezeit = Me.ChB_Ruhezeit.checked
            .ME1_VF.bVF = Me.ChB_ME1_VF.Checked
            .ME2_VF.bVF = Me.ChB_ME2.Checked
            .ME3_VF.bVF = Me.ChB_ME3.Checked
 
            .GTag_IO = CInt(Me.NUD_GTag_IO.Value)
            .GNacht_IO = CInt(Me.NUD_GNacht_IO.Value)

            
            .ME1_VF.A = Me.NUD_ME1_A.Value
            .ME1_VF.B = Me.NUD_ME1_B.Value
            .ME1_VF.C = Me.NUD_ME1_C.Value
            .ME1_VF.D = Me.NUD_ME1_D.Value
            .ME1_VF.E = Me.NUD_ME1_E.Value
            .ME1_VF.bBed2 = Me.ChB_ME1_Bed2.Checked
            .ME1_VF.Bed2 = CInt(Me.NUD_ME1_Bed2.Value)
            .ME1_VF.A_Bed2 = Me.NUD_ME1_A_Bed2.Value
            .ME1_VF.B_Bed2 = Me.NUD_ME1_B_Bed2.Value
            .ME1_VF.C_Bed2 = Me.NUD_ME1_C_Bed2.Value
            .ME1_VF.D_Bed2 = Me.NUD_ME1_D_Bed2.Value
            .ME1_VF.E_Bed2 = Me.NUD_ME1_E_Bed2.Value
            .ME1_VF.bBed3 = Me.ChB_ME1_Bed3.Checked
            .ME1_VF.Bed3 = CInt(Me.NUD_ME1_Bed3.Value)
            .ME1_VF.A_Bed3 = Me.NUD_ME1_A_Bed3.Value
            .ME1_VF.B_Bed3 = Me.NUD_ME1_B_Bed3.Value
            .ME1_VF.C_Bed3 = Me.NUD_ME1_C_Bed3.Value
            .ME1_VF.D_Bed3 = Me.NUD_ME1_D_Bed3.Value
            .ME1_VF.E_Bed3 = Me.NUD_ME1_E_Bed3.Value

            .ME2_VF.A = Me.NUD_ME2_A.Value
            .ME2_VF.B = Me.NUD_ME2_B.Value
            .ME2_VF.C = Me.NUD_ME2_C.Value
            .ME2_VF.D = Me.NUD_ME2_D.Value
            .ME2_VF.E = Me.NUD_ME2_E.Value
            .ME2_VF.bBed2 = Me.ChB_ME2_Bed2.Checked
            .ME2_VF.Bed2 = CInt(Me.NUD_ME2_Bed2.Value)
            .ME2_VF.A_Bed2 = Me.NUD_ME2_A_Bed2.Value
            .ME2_VF.B_Bed2 = Me.NUD_ME2_B_Bed2.Value
            .ME2_VF.C_Bed2 = Me.NUD_ME2_C_Bed2.Value
            .ME2_VF.D_Bed2 = Me.NUD_ME2_D_Bed2.Value
            .ME2_VF.E_Bed2 = Me.NUD_ME2_E_Bed2.Value
            .ME2_VF.bBed3 = Me.ChB_ME2_Bed3.Checked
            .ME2_VF.Bed3 = CInt(Me.NUD_ME2_Bed3.Value)
            .ME2_VF.A_Bed3 = Me.NUD_ME2_A_Bed3.Value
            .ME2_VF.B_Bed3 = Me.NUD_ME2_B_Bed3.Value
            .ME2_VF.C_Bed3 = Me.NUD_ME2_C_Bed3.Value
            .ME2_VF.D_Bed3 = Me.NUD_ME2_D_Bed3.Value
            .ME2_VF.E_Bed3 = Me.NUD_ME2_E_Bed3.Value

            .ME3_VF.A = Me.NUD_ME3_A.Value
            .ME3_VF.B = Me.NUD_ME3_B.Value
            .ME3_VF.C = Me.NUD_ME3_C.Value
            .ME3_VF.D = Me.NUD_ME3_D.Value
            .ME3_VF.E = Me.NUD_ME3_E.Value
            .ME3_VF.bBed2 = Me.ChB_ME3_Bed2.Checked
            .ME3_VF.Bed2 = CInt(Me.NUD_ME3_Bed2.Value)
            .ME3_VF.A_Bed2 = Me.NUD_ME3_A_Bed2.Value
            .ME3_VF.B_Bed2 = Me.NUD_ME3_B_Bed2.Value
            .ME3_VF.C_Bed2 = Me.NUD_ME3_C_Bed2.Value
            .ME3_VF.D_Bed2 = Me.NUD_ME3_D_Bed2.Value
            .ME3_VF.E_Bed2 = Me.NUD_ME3_E_Bed2.Value
            .ME3_VF.bBed3 = Me.ChB_ME3_Bed3.Checked
            .ME3_VF.Bed3 = CInt(Me.NUD_ME3_Bed3.Value)
            .ME3_VF.A_Bed3 = Me.NUD_ME3_A_Bed3.Value
            .ME3_VF.B_Bed3 = Me.NUD_ME3_B_Bed3.Value
            .ME3_VF.C_Bed3 = Me.NUD_ME3_C_Bed3.Value
            .ME3_VF.D_Bed3 = Me.NUD_ME3_D_Bed3.Value
            .ME3_VF.E_Bed3 = Me.NUD_ME3_E_Bed3.Value

            .btME_RQ = 1
            If Me.RB_ME2.Checked Then
                .btME_RQ = 2
            ElseIf Me.RB_ME3.Checked Then
                .btME_RQ = 3
            End If

            .RQ_A = Me.NUD_RQ_A.Value
            .RQ_B = Me.NUD_RQ_B.Value
            .RQ_C = Me.NUD_RQ_C.Value
            .RQ_D = Me.NUD_RQ_D.Value
            .RQ_E = Me.NUD_RQ_E.Value

            .bME2_RQ = Me.ChB_ME2_RQ.Checked
            If .bME2_RQ = False Then
                .RQ_ME2_A = 0
                .RQ_ME2_B = 0
                .RQ_ME2_C = 0
                .RQ_ME2_D = 0
                .RQ_ME2_E = 0
            Else
                .RQ_ME2_A = Me.NUD_ME2_RQ_A.Value
                .RQ_ME2_B = Me.NUD_ME2_RQ_B.Value
                .RQ_ME2_C = Me.NUD_ME2_RQ_C.Value
                .RQ_ME2_D = Me.NUD_ME2_RQ_D.Value
                .RQ_ME2_E = Me.NUD_ME2_RQ_E.Value
            End If
        End With

        Daten_IO_speichern()
    End Sub

    Private Sub Button_Neu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Neu.Click
        Immissionsort_Neu(0, 0)
    End Sub
    Private Sub Immissionsort_Neu(ByVal Rechts As Integer, ByVal Hoch As Integer)
        Dim iNr As Integer = 1
        Do While refExist("Immissionsort " & iNr)
            iNr = iNr + 1
        Loop

        Dim iLen As Integer = 0
        If Not IsNothing(Immissionsort) Then iLen = Immissionsort.Length
        ReDim Preserve Immissionsort(iLen)
        iCurIO = iLen

        Immissionsort(iLen).ID = Get_ID_NEXT
        Immissionsort(iLen).Bezeichnung = "Immissionsort " & iNr
        Me.TB_Bezeichnung.Text = "Immissionsort " & iNr

        Me.NUD_Rechts.Value = Rechts
        Me.NUD_Hoch.Value = Hoch

        Me.ChB_Ruhezeit.Checked = False

        'Me.RB_ME2_MAX.Checked = True
        'Me.RB_ME1_MAX.Checked = False
        'Me.RB_ME3_MAX.Checked = False

        'Me.NUD_GTag_MAX_VF.Value = 0
        'Me.NUD_GNacht_MAX_VF.Value = 0
        'Me.NUD_GTag_MAX_RQ.Value = 0
        'Me.NUD_GNacht_MAX_RQ.Value = 0
        Me.NUD_GTag_IO.Value = 0
        Me.NUD_GNacht_IO.Value = 0

        'Me.ChB_MAX_RQ_ME2.Checked = False
        'Me.NUD_GTag_MAX_RQ_ME2.Value = 0
        'Me.NUD_GNacht_MAX_RQ_ME2.Value = 0

        Me.ChB_ME1_VF.Checked = False
        Me.ChB_ME2.Checked = True
        Me.ChB_ME3.Checked = False

        Me.NUD_ME1_A.Value = 0
        Me.NUD_ME1_B.Value = 0
        Me.NUD_ME1_C.Value = 0
        Me.NUD_ME1_D.Value = 0
        Me.NUD_ME1_E.Value = 0
        Me.ChB_ME1_Bed2.Checked = False
        Me.NUD_ME1_Bed2.Value = 0
        Me.NUD_ME1_A_Bed2.Value = 0
        Me.NUD_ME1_B_Bed2.Value = 0
        Me.NUD_ME1_C_Bed2.Value = 0
        Me.NUD_ME1_D_Bed2.Value = 0
        Me.NUD_ME1_E_Bed2.Value = 0
        Me.ChB_ME1_Bed3.Checked = False
        Me.NUD_ME1_Bed3.Value = 0
        Me.NUD_ME1_A_Bed3.Value = 0
        Me.NUD_ME1_B_Bed3.Value = 0
        Me.NUD_ME1_C_Bed3.Value = 0
        Me.NUD_ME1_D_Bed3.Value = 0
        Me.NUD_ME1_E_Bed3.Value = 0

        Me.NUD_ME2_A.Value = 0
        Me.NUD_ME2_B.Value = 0
        Me.NUD_ME2_C.Value = 0
        Me.NUD_ME2_D.Value = 0
        Me.NUD_ME2_E.Value = 0
        Me.ChB_ME2_Bed2.Checked = False
        Me.NUD_ME2_Bed2.Value = 0
        Me.NUD_ME2_A_Bed2.Value = 0
        Me.NUD_ME2_B_Bed2.Value = 0
        Me.NUD_ME2_C_Bed2.Value = 0
        Me.NUD_ME2_D_Bed2.Value = 0
        Me.NUD_ME2_E_Bed2.Value = 0
        Me.ChB_ME2_Bed3.Checked = False
        Me.NUD_ME2_Bed3.Value = 0
        Me.NUD_ME2_A_Bed3.Value = 0
        Me.NUD_ME2_B_Bed3.Value = 0
        Me.NUD_ME2_C_Bed3.Value = 0
        Me.NUD_ME2_D_Bed3.Value = 0
        Me.NUD_ME2_E_Bed3.Value = 0

        Me.NUD_ME3_A.Value = 0
        Me.NUD_ME3_B.Value = 0
        Me.NUD_ME3_C.Value = 0
        Me.NUD_ME3_D.Value = 0
        Me.NUD_ME3_E.Value = 0
        Me.ChB_ME3_Bed2.Checked = False
        Me.NUD_ME3_Bed2.Value = 0
        Me.NUD_ME3_A_Bed2.Value = 0
        Me.NUD_ME3_B_Bed2.Value = 0
        Me.NUD_ME3_C_Bed2.Value = 0
        Me.NUD_ME3_D_Bed2.Value = 0
        Me.NUD_ME3_E_Bed2.Value = 0
        Me.ChB_ME3_Bed3.Checked = False
        Me.NUD_ME3_Bed3.Value = 0
        Me.NUD_ME3_A_Bed3.Value = 0
        Me.NUD_ME3_B_Bed3.Value = 0
        Me.NUD_ME3_C_Bed3.Value = 0
        Me.NUD_ME3_D_Bed3.Value = 0
        Me.NUD_ME3_E_Bed3.Value = 0

        Me.RB_ME2.Checked = True

        Me.NUD_RQ_A.Value = 0
        Me.NUD_RQ_B.Value = 0
        Me.NUD_RQ_C.Value = 0
        Me.NUD_RQ_D.Value = 0
        Me.NUD_RQ_E.Value = 0

        Me.ChB_ME2_RQ.Checked = False
        Me.NUD_ME2_RQ_A.Value = 0
        Me.NUD_ME2_RQ_B.Value = 0
        Me.NUD_ME2_RQ_C.Value = 0
        Me.NUD_ME2_RQ_D.Value = 0
        Me.NUD_ME2_RQ_E.Value = 0

        Save_Var(iLen)
        Update_Anzeige()

        iCurIO = iLen

        Me.Panel_Eingabe.Enabled = True
    End Sub

    Private Sub Button_Bearbeiten_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Bearbeiten.Click
        If Me.ListView_Immissionsort.SelectedItems.Count > 0 Then
            Dim iEl As Integer = CInt(Me.ListView_Immissionsort.SelectedItems(0).Tag)


            iCurIO = CInt(Me.ListView_Immissionsort.SelectedItems(0).Tag)
            Me.Panel_Eingabe.Enabled = True
        End If
    End Sub

    Private Sub Button_Speichern_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Speichern.Click
        If iCurIO > -1 Then
            Save_Var(iCurIO)
            Me.Panel_Eingabe.Enabled = False
            iCurIO = -1
        End If
    End Sub

    Private Sub Button_Loeschen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Loeschen.Click
        If Me.ListView_Immissionsort.SelectedItems.Count > 0 Then
            Dim iEl As Integer = CInt(Me.ListView_Immissionsort.SelectedItems(0).Tag)
            Dim ix As Integer = CInt(Me.ListView_Immissionsort.SelectedItems(0).Index)

            If Immissionsort(iEl).Bezeichnung = "Grundeinstellung" And iEl = 0 Then
                MsgBox("Die Grundeinstellung kann nicht gelöscht werden!", MsgBoxStyle.OkOnly, "Löschen")
            Else
                For i As Integer = iEl To Immissionsort.Length - 2
                    Immissionsort(i) = Immissionsort(i + 1)
                Next
                ReDim Preserve Immissionsort(Immissionsort.Length - 2)

                Update_Anzeige()

                If Me.ListView_Immissionsort.Items.Count - 1 >= ix Then
                    Me.ListView_Immissionsort.Items(ix).Selected = True
                Else
                    'Me.ListView_Fenstertyp.Items(ix - 1).Selected = True
                End If

            End If
        End If
    End Sub

    Private Sub TB_Bezeichnung_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TB_Bezeichnung.TextChanged

        If iCurIO > -1 Then
            Dim iEl As Integer
            For iEl = 0 To Me.ListView_Immissionsort.Items.Count - 1
                If CInt(Me.ListView_Immissionsort.Items(iEl).Tag) = iCurIO Then
                    Exit For
                End If
            Next
            If Me.ListView_Immissionsort.Items.Count > iEl Then Me.ListView_Immissionsort.Items(iEl).Text = Me.TB_Bezeichnung.Text
        End If
        'REFERENZ_Fenster(iCurRef).Bezeichnung = Me.TB_Bezeichnung.Text
    End Sub
#End Region


    Private Sub Dialog_Immissionsort_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
       
        Daten_einlesen() 'IO und MAX

        With Maximalpegel.Max_ME1
            Me.NUD_GTag_MAX_VF_ME1.Value = .GTag_MAX_VF
            Me.NUD_GNacht_MAX_VF_ME1.Value = .GNacht_MAX_VF
            Me.NUD_GTag_MAX_RQ_ME1.Value = .GTag_MAX_RQ
            Me.NUD_GNacht_MAX_RQ_ME1.Value = .GNacht_MAX_RQ
        End With

        With Maximalpegel.Max_ME2
            Me.NUD_GTag_MAX_VF_ME2.Value = .GTag_MAX_VF
            Me.NUD_GNacht_MAX_VF_ME2.Value = .GNacht_MAX_VF
            Me.NUD_GTag_MAX_RQ_ME2.Value = .GTag_MAX_RQ
            Me.NUD_GNacht_MAX_RQ_ME2.Value = .GNacht_MAX_RQ
        End With

        With Maximalpegel.Max_ME3
            Me.NUD_GTag_MAX_VF_ME3.Value = .GTag_MAX_VF
            Me.NUD_GNacht_MAX_VF_ME3.Value = .GNacht_MAX_VF
            Me.NUD_GTag_MAX_RQ_ME3.Value = .GTag_MAX_RQ
            Me.NUD_GNacht_MAX_RQ_ME3.Value = .GNacht_MAX_RQ
        End With

        Update_Anzeige()
        If iCurIO = -1 Then
            Me.Panel_Eingabe.Enabled = False
        End If

        If ptKoordinaten.X <> 0 Then
            Immissionsort_Neu(CInt(ptKoordinaten.X), CInt(ptKoordinaten.Y))
        Else
            iCurIO = -1
            If Me.ListView_Immissionsort.Items.Count > 0 Then Me.ListView_Immissionsort.Items(0).Selected = True ' = Me.ListView_Immissionsort.SelectedItems(0)
        End If
    End Sub

    Private Sub ChB_ME1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChB_ME1_VF.CheckedChanged
        Me.Panel_ME1_VF.Visible = Me.ChB_ME1_VF.Checked

        If Me.ChB_ME1_VF.Checked = False Then
            Me.NUD_ME1_A.Value = 0
            Me.NUD_ME1_B.Value = 0
            Me.NUD_ME1_C.Value = 0
            Me.NUD_ME1_D.Value = 0
            Me.NUD_ME1_E.Value = 0
        End If
    End Sub

    Private Sub ChB_ME2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChB_ME2.CheckedChanged
        Me.Panel_ME2_VF.Visible = Me.ChB_ME2.Checked

        If Me.ChB_ME2.Checked = False Then
            Me.NUD_ME2_A.Value = 0
            Me.NUD_ME2_B.Value = 0
            Me.NUD_ME2_C.Value = 0
            Me.NUD_ME2_D.Value = 0
            Me.NUD_ME2_E.Value = 0
        End If
    End Sub

    Private Sub ChB_ME3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChB_ME3.CheckedChanged
        Me.Panel_ME3_VF.Visible = Me.ChB_ME3.Checked

        If Me.ChB_ME3.Checked = False Then
            Me.NUD_ME3_A.Value = 0
            Me.NUD_ME3_B.Value = 0
            Me.NUD_ME3_C.Value = 0
            Me.NUD_ME3_D.Value = 0
            Me.NUD_ME3_E.Value = 0
        End If
    End Sub


    Private Sub ListView_Fenstertyp_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView_Immissionsort.SelectedIndexChanged
        If iCurIO > -1 Then
            If MsgBox("Soll die Eingabe gespeichert werden?", MsgBoxStyle.YesNo, "Speichern") = MsgBoxResult.Yes Then
                Save_Var(iCurIO)
                ''Else
                ''    Update_Eingabe(iCurRef)
                Me.Panel_Eingabe.Enabled = False
                iCurIO = -1
            Else
                iCurIO = -1
                Me.Panel_Eingabe.Enabled = False
            End If
        Else
            If Me.ListView_Immissionsort.SelectedItems.Count > 0 Then
                Dim ix As Integer = Me.ListView_Immissionsort.SelectedItems(0).Index
                Dim iEl As Integer = CInt(Me.ListView_Immissionsort.SelectedItems(0).Tag)

                Update_Anzeige_Immissionsort(iEl)

                Dim iCoun As Integer = Me.ListView_Immissionsort.SelectedItems.Count
            End If
        End If
    End Sub
 
    Private Sub ChB_ME1_Bed2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChB_ME1_Bed2.CheckedChanged
        Me.P_ME1_Bed2.Visible = Me.ChB_ME1_Bed2.Checked
        Me.ChB_ME1_Bed3.Visible = Me.ChB_ME1_Bed2.Checked
        If ChB_ME1_Bed2.Checked = False Then Me.ChB_ME1_Bed3.Checked = False
    End Sub
    Private Sub ChB_ME2_Bed2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChB_ME2_Bed2.CheckedChanged
        Me.P_ME2_Bed2.Visible = Me.ChB_ME2_Bed2.Checked
        Me.ChB_ME2_Bed3.Visible = Me.ChB_ME2_Bed2.Checked
        If ChB_ME2_Bed2.Checked = False Then Me.ChB_ME2_Bed3.Checked = False
    End Sub
    Private Sub ChB_ME3_Bed2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChB_ME3_Bed2.CheckedChanged
        Me.P_ME3_Bed2.Visible = Me.ChB_ME3_Bed2.Checked
        Me.ChB_ME3_Bed3.Visible = Me.ChB_ME3_Bed2.Checked
        If ChB_ME3_Bed2.Checked = False Then Me.ChB_ME3_Bed3.Checked = False
    End Sub

    Private Sub ChB_ME1_Bed3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChB_ME1_Bed3.CheckedChanged
        Me.P_ME1_Bed3.Visible = Me.ChB_ME1_Bed3.Checked
    End Sub
    Private Sub ChB_ME2_Bed3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChB_ME2_Bed3.CheckedChanged
        Me.P_ME2_Bed3.Visible = Me.ChB_ME2_Bed3.Checked
    End Sub
    Private Sub ChB_ME3_Bed3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChB_ME3_Bed3.CheckedChanged
        Me.P_ME3_Bed3.Visible = Me.ChB_ME3_Bed3.Checked
    End Sub

    Private Sub ChB_ME2_RQ_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChB_ME2_RQ.CheckedChanged
        Me.Panel_ME2_RQ.Visible = Me.ChB_ME2_RQ.Checked
        'Me.NUD_GTag_MAX_RQ_ME2.Enabled = Me.ChB_ME2_RQ.Checked
        'Me.NUD_GNacht_MAX_RQ_ME2.Enabled = Me.ChB_ME2_RQ.Checked
        'Me.ChB_MAX_RQ_ME2.Enabled = Me.ChB_ME2_RQ.Checked
    End Sub

    Private Sub RB_ME2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB_ME2.CheckedChanged
        If Me.RB_ME2.Checked Then
            Me.ChB_ME2_RQ.Checked = False
            Me.ChB_ME2_RQ.Enabled = False
            'Me.ChB_MAX_RQ_ME2.Checked = False
            'Me.Panel_ME2_RQ.Visible = False
            'Me.NUD_GTag_MAX_RQ_ME2.Visible = False
            'Me.NUD_GNacht_MAX_RQ_ME2.Visible = False
        Else
            Me.ChB_ME2_RQ.Enabled = True
            'Me.NUD_GTag_MAX_RQ_ME2.Visible = True
            'Me.NUD_GNacht_MAX_RQ_ME2.Visible = True
        End If
    End Sub

    Private Sub ChB_MAX_RQ_ME2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.NUD_GNacht_MAX_RQ_ME2.Enabled = Me.ChB_ME2_RQ.Checked
        'Me.ChB_MAX_RQ_ME2.Enabled = Me.ChB_ME2_RQ.Checked
    End Sub

   
    Private Sub Dialog_Immissionsort_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        With Maximalpegel.Max_ME1
            .GTag_MAX_VF = CInt(Me.NUD_GTag_MAX_VF_ME1.Value)
            .GNacht_MAX_VF = CInt(Me.NUD_GNacht_MAX_VF_ME1.Value)
            .GTag_MAX_RQ = CInt(Me.NUD_GTag_MAX_RQ_ME1.Value)
            .GNacht_MAX_RQ = CInt(Me.NUD_GNacht_MAX_RQ_ME1.Value)
        End With
        With Maximalpegel.Max_ME2
            .GTag_MAX_VF = CInt(Me.NUD_GTag_MAX_VF_ME2.Value)
            .GNacht_MAX_VF = CInt(Me.NUD_GNacht_MAX_VF_ME2.Value)
            .GTag_MAX_RQ = CInt(Me.NUD_GTag_MAX_RQ_ME2.Value)
            .GNacht_MAX_RQ = CInt(Me.NUD_GNacht_MAX_RQ_ME2.Value)
        End With
        With Maximalpegel.Max_ME3
            .GTag_MAX_VF = CInt(Me.NUD_GTag_MAX_VF_ME3.Value)
            .GNacht_MAX_VF = CInt(Me.NUD_GNacht_MAX_VF_ME3.Value)
            .GTag_MAX_RQ = CInt(Me.NUD_GTag_MAX_RQ_ME3.Value)
            .GNacht_MAX_RQ = CInt(Me.NUD_GNacht_MAX_RQ_ME3.Value)
        End With
        Daten_Max_Speichern()
    End Sub
End Class
