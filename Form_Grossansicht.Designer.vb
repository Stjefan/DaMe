<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Grossansicht
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Grossansicht))
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.PB_Gesamtansicht = New System.Windows.Forms.PictureBox
        Me.PB_Einstellungen = New System.Windows.Forms.PictureBox
        Me.PB_Uebersicht = New System.Windows.Forms.PictureBox
        Me.PB_Wetter = New System.Windows.Forms.PictureBox
        Me.PB_Messstellen = New System.Windows.Forms.PictureBox
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel_aktuell = New System.Windows.Forms.Panel
        Me.Label_ME = New System.Windows.Forms.Label
        Me.Label_Max_dauernd = New System.Windows.Forms.Label
        Me.P_Max_dauernd = New System.Windows.Forms.Panel
        Me.Label25 = New System.Windows.Forms.Label
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.PB_Prozentbalken_RQ = New System.Windows.Forms.PictureBox
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.TB_Stunden = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.PB_Prozentbalken_Ges = New System.Windows.Forms.PictureBox
        Me.Panel_Balken = New System.Windows.Forms.Panel
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.PB_Prozentbalken_VF = New System.Windows.Forms.PictureBox
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.Label2 = New System.Windows.Forms.Label
        Me.TB_Minuten = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.LV_Ueberschreitungen = New System.Windows.Forms.ListView
        Me.CH_Bemerkung = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader5 = New System.Windows.Forms.ColumnHeader
        Me.Panel7 = New System.Windows.Forms.Panel
        Me.Button_UEBER_Aktuallisieren = New System.Windows.Forms.Button
        Me.NUD_UEBER_Prozent = New System.Windows.Forms.NumericUpDown
        Me.Label7 = New System.Windows.Forms.Label
        Me.NUD_UEBER_Anzahl = New System.Windows.Forms.NumericUpDown
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DTP_UEBER_startDatum = New System.Windows.Forms.DateTimePicker
        Me.SaveFileDialog_Monatsbericht = New System.Windows.Forms.SaveFileDialog
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.PB_Gesamtansicht, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PB_Einstellungen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PB_Uebersicht, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PB_Wetter, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PB_Messstellen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.Panel_aktuell.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.PB_Prozentbalken_RQ, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.PB_Prozentbalken_Ges, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.PB_Prozentbalken_VF, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel7.SuspendLayout()
        CType(Me.NUD_UEBER_Prozent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUD_UEBER_Anzahl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Magenta
        Me.ImageList1.Images.SetKeyName(0, "gear_2.bmp")
        Me.ImageList1.Images.SetKeyName(1, "gear_32.bmp")
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.SlateGray
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.SplitContainer1.Panel1.Controls.Add(Me.TableLayoutPanel1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.AutoScroll = True
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.SlateGray
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(1370, 676)
        Me.SplitContainer1.SplitterDistance = 80
        Me.SplitContainer1.TabIndex = 9
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.PB_Gesamtansicht, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.PB_Einstellungen, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.PB_Uebersicht, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.PB_Wetter, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.PB_Messstellen, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(80, 676)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'PB_Gesamtansicht
        '
        Me.PB_Gesamtansicht.BackColor = System.Drawing.Color.Silver
        Me.PB_Gesamtansicht.BackgroundImage = CType(resources.GetObject("PB_Gesamtansicht.BackgroundImage"), System.Drawing.Image)
        Me.PB_Gesamtansicht.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PB_Gesamtansicht.Location = New System.Drawing.Point(3, 3)
        Me.PB_Gesamtansicht.Name = "PB_Gesamtansicht"
        Me.PB_Gesamtansicht.Size = New System.Drawing.Size(74, 129)
        Me.PB_Gesamtansicht.TabIndex = 9
        Me.PB_Gesamtansicht.TabStop = False
        '
        'PB_Einstellungen
        '
        Me.PB_Einstellungen.BackColor = System.Drawing.Color.Gray
        Me.PB_Einstellungen.BackgroundImage = CType(resources.GetObject("PB_Einstellungen.BackgroundImage"), System.Drawing.Image)
        Me.PB_Einstellungen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PB_Einstellungen.InitialImage = Nothing
        Me.PB_Einstellungen.Location = New System.Drawing.Point(3, 543)
        Me.PB_Einstellungen.Name = "PB_Einstellungen"
        Me.PB_Einstellungen.Size = New System.Drawing.Size(74, 130)
        Me.PB_Einstellungen.TabIndex = 6
        Me.PB_Einstellungen.TabStop = False
        '
        'PB_Uebersicht
        '
        Me.PB_Uebersicht.BackColor = System.Drawing.Color.SlateGray
        Me.PB_Uebersicht.BackgroundImage = CType(resources.GetObject("PB_Uebersicht.BackgroundImage"), System.Drawing.Image)
        Me.PB_Uebersicht.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PB_Uebersicht.Location = New System.Drawing.Point(3, 408)
        Me.PB_Uebersicht.Name = "PB_Uebersicht"
        Me.PB_Uebersicht.Size = New System.Drawing.Size(74, 129)
        Me.PB_Uebersicht.TabIndex = 0
        Me.PB_Uebersicht.TabStop = False
        '
        'PB_Wetter
        '
        Me.PB_Wetter.BackColor = System.Drawing.Color.SlateGray
        Me.PB_Wetter.BackgroundImage = CType(resources.GetObject("PB_Wetter.BackgroundImage"), System.Drawing.Image)
        Me.PB_Wetter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PB_Wetter.Location = New System.Drawing.Point(3, 273)
        Me.PB_Wetter.Name = "PB_Wetter"
        Me.PB_Wetter.Size = New System.Drawing.Size(74, 129)
        Me.PB_Wetter.TabIndex = 8
        Me.PB_Wetter.TabStop = False
        '
        'PB_Messstellen
        '
        Me.PB_Messstellen.BackColor = System.Drawing.Color.SlateGray
        Me.PB_Messstellen.BackgroundImage = CType(resources.GetObject("PB_Messstellen.BackgroundImage"), System.Drawing.Image)
        Me.PB_Messstellen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PB_Messstellen.Image = CType(resources.GetObject("PB_Messstellen.Image"), System.Drawing.Image)
        Me.PB_Messstellen.Location = New System.Drawing.Point(3, 138)
        Me.PB_Messstellen.Name = "PB_Messstellen"
        Me.PB_Messstellen.Size = New System.Drawing.Size(74, 129)
        Me.PB_Messstellen.TabIndex = 7
        Me.PB_Messstellen.TabStop = False
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.Panel1)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Panel_aktuell)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.LV_Ueberschreitungen)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Panel7)
        Me.SplitContainer2.Size = New System.Drawing.Size(1286, 676)
        Me.SplitContainer2.SplitterDistance = 995
        Me.SplitContainer2.TabIndex = 68
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 71)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(995, 605)
        Me.Panel1.TabIndex = 0
        '
        'Panel_aktuell
        '
        Me.Panel_aktuell.BackColor = System.Drawing.Color.SlateGray
        Me.Panel_aktuell.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel_aktuell.Controls.Add(Me.Label_ME)
        Me.Panel_aktuell.Controls.Add(Me.Label_Max_dauernd)
        Me.Panel_aktuell.Controls.Add(Me.P_Max_dauernd)
        Me.Panel_aktuell.Controls.Add(Me.Label25)
        Me.Panel_aktuell.Controls.Add(Me.Panel5)
        Me.Panel_aktuell.Controls.Add(Me.TB_Stunden)
        Me.Panel_aktuell.Controls.Add(Me.Label18)
        Me.Panel_aktuell.Controls.Add(Me.Panel2)
        Me.Panel_aktuell.Controls.Add(Me.Label6)
        Me.Panel_aktuell.Controls.Add(Me.Label20)
        Me.Panel_aktuell.Controls.Add(Me.Label19)
        Me.Panel_aktuell.Controls.Add(Me.Panel3)
        Me.Panel_aktuell.Controls.Add(Me.Label2)
        Me.Panel_aktuell.Controls.Add(Me.TB_Minuten)
        Me.Panel_aktuell.Controls.Add(Me.Label4)
        Me.Panel_aktuell.Controls.Add(Me.Label3)
        Me.Panel_aktuell.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel_aktuell.Location = New System.Drawing.Point(0, 0)
        Me.Panel_aktuell.Name = "Panel_aktuell"
        Me.Panel_aktuell.Size = New System.Drawing.Size(995, 71)
        Me.Panel_aktuell.TabIndex = 67
        '
        'Label_ME
        '
        Me.Label_ME.AutoSize = True
        Me.Label_ME.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_ME.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label_ME.Location = New System.Drawing.Point(-2, 2)
        Me.Label_ME.Name = "Label_ME"
        Me.Label_ME.Size = New System.Drawing.Size(39, 23)
        Me.Label_ME.TabIndex = 31
        Me.Label_ME.Text = "ME"
        '
        'Label_Max_dauernd
        '
        Me.Label_Max_dauernd.AutoSize = True
        Me.Label_Max_dauernd.Font = New System.Drawing.Font("Tahoma", 15.75!)
        Me.Label_Max_dauernd.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label_Max_dauernd.Location = New System.Drawing.Point(992, 32)
        Me.Label_Max_dauernd.Name = "Label_Max_dauernd"
        Me.Label_Max_dauernd.Size = New System.Drawing.Size(79, 25)
        Me.Label_Max_dauernd.TabIndex = 335
        Me.Label_Max_dauernd.Text = "VF+RQ"
        '
        'P_Max_dauernd
        '
        Me.P_Max_dauernd.BackColor = System.Drawing.Color.Green
        Me.P_Max_dauernd.Location = New System.Drawing.Point(1039, 0)
        Me.P_Max_dauernd.Name = "P_Max_dauernd"
        Me.P_Max_dauernd.Size = New System.Drawing.Size(27, 26)
        Me.P_Max_dauernd.TabIndex = 334
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label25.Location = New System.Drawing.Point(990, 0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(49, 25)
        Me.Label25.TabIndex = 32
        Me.Label25.Text = "Max"
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.PB_Prozentbalken_RQ)
        Me.Panel5.Controls.Add(Me.Panel6)
        Me.Panel5.Location = New System.Drawing.Point(618, 35)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(200, 30)
        Me.Panel5.TabIndex = 27
        '
        'PB_Prozentbalken_RQ
        '
        Me.PB_Prozentbalken_RQ.BackColor = System.Drawing.Color.Black
        Me.PB_Prozentbalken_RQ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PB_Prozentbalken_RQ.Location = New System.Drawing.Point(0, 0)
        Me.PB_Prozentbalken_RQ.Name = "PB_Prozentbalken_RQ"
        Me.PB_Prozentbalken_RQ.Size = New System.Drawing.Size(5, 30)
        Me.PB_Prozentbalken_RQ.TabIndex = 12
        Me.PB_Prozentbalken_RQ.TabStop = False
        '
        'Panel6
        '
        Me.Panel6.BackgroundImage = CType(resources.GetObject("Panel6.BackgroundImage"), System.Drawing.Image)
        Me.Panel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel6.Location = New System.Drawing.Point(0, 5)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(200, 20)
        Me.Panel6.TabIndex = 9
        '
        'TB_Stunden
        '
        Me.TB_Stunden.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TB_Stunden.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TB_Stunden.Enabled = False
        Me.TB_Stunden.Font = New System.Drawing.Font("Tahoma", 15.75!)
        Me.TB_Stunden.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TB_Stunden.Location = New System.Drawing.Point(852, 30)
        Me.TB_Stunden.Name = "TB_Stunden"
        Me.TB_Stunden.ReadOnly = True
        Me.TB_Stunden.Size = New System.Drawing.Size(32, 33)
        Me.TB_Stunden.TabIndex = 20
        Me.TB_Stunden.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label18.Location = New System.Drawing.Point(828, 33)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(29, 25)
        Me.Label18.TabIndex = 31
        Me.Label18.Text = "in"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.PB_Prozentbalken_Ges)
        Me.Panel2.Controls.Add(Me.Panel_Balken)
        Me.Panel2.Location = New System.Drawing.Point(78, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(500, 66)
        Me.Panel2.TabIndex = 25
        '
        'PB_Prozentbalken_Ges
        '
        Me.PB_Prozentbalken_Ges.BackColor = System.Drawing.Color.Black
        Me.PB_Prozentbalken_Ges.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PB_Prozentbalken_Ges.Location = New System.Drawing.Point(0, 0)
        Me.PB_Prozentbalken_Ges.Name = "PB_Prozentbalken_Ges"
        Me.PB_Prozentbalken_Ges.Size = New System.Drawing.Size(5, 66)
        Me.PB_Prozentbalken_Ges.TabIndex = 12
        Me.PB_Prozentbalken_Ges.TabStop = False
        '
        'Panel_Balken
        '
        Me.Panel_Balken.BackgroundImage = CType(resources.GetObject("Panel_Balken.BackgroundImage"), System.Drawing.Image)
        Me.Panel_Balken.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel_Balken.Location = New System.Drawing.Point(0, 11)
        Me.Panel_Balken.Name = "Panel_Balken"
        Me.Panel_Balken.Size = New System.Drawing.Size(500, 43)
        Me.Panel_Balken.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label6.Location = New System.Drawing.Point(-2, 35)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 23)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = "Gesamt"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label20.Location = New System.Drawing.Point(583, 36)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(39, 23)
        Me.Label20.TabIndex = 29
        Me.Label20.Text = "RQ"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label19.Location = New System.Drawing.Point(584, 3)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(34, 23)
        Me.Label19.TabIndex = 28
        Me.Label19.Text = "VF"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.PB_Prozentbalken_VF)
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Location = New System.Drawing.Point(618, 1)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(200, 30)
        Me.Panel3.TabIndex = 26
        '
        'PB_Prozentbalken_VF
        '
        Me.PB_Prozentbalken_VF.BackColor = System.Drawing.Color.Black
        Me.PB_Prozentbalken_VF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PB_Prozentbalken_VF.Location = New System.Drawing.Point(0, 0)
        Me.PB_Prozentbalken_VF.Name = "PB_Prozentbalken_VF"
        Me.PB_Prozentbalken_VF.Size = New System.Drawing.Size(5, 30)
        Me.PB_Prozentbalken_VF.TabIndex = 12
        Me.PB_Prozentbalken_VF.TabStop = False
        '
        'Panel4
        '
        Me.Panel4.BackgroundImage = CType(resources.GetObject("Panel4.BackgroundImage"), System.Drawing.Image)
        Me.Panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel4.Location = New System.Drawing.Point(0, 5)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(200, 20)
        Me.Panel4.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label2.Location = New System.Drawing.Point(828, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(155, 25)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Überschreitung"
        '
        'TB_Minuten
        '
        Me.TB_Minuten.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TB_Minuten.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TB_Minuten.Enabled = False
        Me.TB_Minuten.Font = New System.Drawing.Font("Tahoma", 15.75!)
        Me.TB_Minuten.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TB_Minuten.Location = New System.Drawing.Point(901, 30)
        Me.TB_Minuten.Name = "TB_Minuten"
        Me.TB_Minuten.ReadOnly = True
        Me.TB_Minuten.Size = New System.Drawing.Size(32, 33)
        Me.TB_Minuten.TabIndex = 23
        Me.TB_Minuten.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 15.75!)
        Me.Label4.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label4.Location = New System.Drawing.Point(930, 33)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 25)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "min"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 15.75!)
        Me.Label3.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label3.Location = New System.Drawing.Point(880, 33)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(24, 25)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "h"
        '
        'LV_Ueberschreitungen
        '
        Me.LV_Ueberschreitungen.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LV_Ueberschreitungen.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.CH_Bemerkung, Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader5})
        Me.LV_Ueberschreitungen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LV_Ueberschreitungen.FullRowSelect = True
        Me.LV_Ueberschreitungen.GridLines = True
        Me.LV_Ueberschreitungen.LabelEdit = True
        Me.LV_Ueberschreitungen.Location = New System.Drawing.Point(0, 71)
        Me.LV_Ueberschreitungen.MultiSelect = False
        Me.LV_Ueberschreitungen.Name = "LV_Ueberschreitungen"
        Me.LV_Ueberschreitungen.Size = New System.Drawing.Size(287, 605)
        Me.LV_Ueberschreitungen.TabIndex = 68
        Me.LV_Ueberschreitungen.UseCompatibleStateImageBehavior = False
        Me.LV_Ueberschreitungen.View = System.Windows.Forms.View.Details
        '
        'CH_Bemerkung
        '
        Me.CH_Bemerkung.DisplayIndex = 3
        Me.CH_Bemerkung.Text = "Bemerkung"
        Me.CH_Bemerkung.Width = 68
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.DisplayIndex = 0
        Me.ColumnHeader1.Text = "Datum"
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.DisplayIndex = 1
        Me.ColumnHeader2.Text = "MAX"
        Me.ColumnHeader2.Width = 47
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.DisplayIndex = 2
        Me.ColumnHeader3.Text = "Lr %"
        Me.ColumnHeader3.Width = 38
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "ME"
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.SlateGray
        Me.Panel7.Controls.Add(Me.Button_UEBER_Aktuallisieren)
        Me.Panel7.Controls.Add(Me.NUD_UEBER_Prozent)
        Me.Panel7.Controls.Add(Me.Label7)
        Me.Panel7.Controls.Add(Me.NUD_UEBER_Anzahl)
        Me.Panel7.Controls.Add(Me.Label5)
        Me.Panel7.Controls.Add(Me.Label1)
        Me.Panel7.Controls.Add(Me.DTP_UEBER_startDatum)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.Location = New System.Drawing.Point(0, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(287, 71)
        Me.Panel7.TabIndex = 0
        '
        'Button_UEBER_Aktuallisieren
        '
        Me.Button_UEBER_Aktuallisieren.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Button_UEBER_Aktuallisieren.Location = New System.Drawing.Point(277, 4)
        Me.Button_UEBER_Aktuallisieren.Name = "Button_UEBER_Aktuallisieren"
        Me.Button_UEBER_Aktuallisieren.Size = New System.Drawing.Size(31, 63)
        Me.Button_UEBER_Aktuallisieren.TabIndex = 6
        Me.Button_UEBER_Aktuallisieren.Text = "GO"
        Me.Button_UEBER_Aktuallisieren.UseVisualStyleBackColor = False
        '
        'NUD_UEBER_Prozent
        '
        Me.NUD_UEBER_Prozent.Location = New System.Drawing.Point(222, 45)
        Me.NUD_UEBER_Prozent.Name = "NUD_UEBER_Prozent"
        Me.NUD_UEBER_Prozent.Size = New System.Drawing.Size(50, 20)
        Me.NUD_UEBER_Prozent.TabIndex = 5
        Me.NUD_UEBER_Prozent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(3, 49)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(220, 13)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "%-Schwelle anzuzeigender Überschreitungen"
        '
        'NUD_UEBER_Anzahl
        '
        Me.NUD_UEBER_Anzahl.Location = New System.Drawing.Point(222, 24)
        Me.NUD_UEBER_Anzahl.Name = "NUD_UEBER_Anzahl"
        Me.NUD_UEBER_Anzahl.Size = New System.Drawing.Size(50, 20)
        Me.NUD_UEBER_Anzahl.TabIndex = 3
        Me.NUD_UEBER_Anzahl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(3, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(198, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Anzahl anzuzeigender Überschreitungen"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Überschreitungen seit"
        '
        'DTP_UEBER_startDatum
        '
        Me.DTP_UEBER_startDatum.CustomFormat = "dd.MM.yyyy HH:mm:ss"
        Me.DTP_UEBER_startDatum.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTP_UEBER_startDatum.Location = New System.Drawing.Point(129, 3)
        Me.DTP_UEBER_startDatum.Name = "DTP_UEBER_startDatum"
        Me.DTP_UEBER_startDatum.Size = New System.Drawing.Size(143, 20)
        Me.DTP_UEBER_startDatum.TabIndex = 0
        '
        'SaveFileDialog_Monatsbericht
        '
        Me.SaveFileDialog_Monatsbericht.Filter = "Excel| *.xlsx"
        '
        'Form_Grossansicht
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SlateGray
        Me.ClientSize = New System.Drawing.Size(1370, 676)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form_Grossansicht"
        Me.Text = "DaMe"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.PB_Gesamtansicht, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PB_Einstellungen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PB_Uebersicht, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PB_Wetter, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PB_Messstellen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        Me.Panel_aktuell.ResumeLayout(False)
        Me.Panel_aktuell.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        CType(Me.PB_Prozentbalken_RQ, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.PB_Prozentbalken_Ges, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        CType(Me.PB_Prozentbalken_VF, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        CType(Me.NUD_UEBER_Prozent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUD_UEBER_Anzahl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents PB_Einstellungen As System.Windows.Forms.PictureBox
    Friend WithEvents PB_Messstellen As System.Windows.Forms.PictureBox
    Friend WithEvents PB_Uebersicht As System.Windows.Forms.PictureBox
    Friend WithEvents PB_Wetter As System.Windows.Forms.PictureBox
    Friend WithEvents PB_Gesamtansicht As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents SaveFileDialog_Monatsbericht As System.Windows.Forms.SaveFileDialog
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel_aktuell As System.Windows.Forms.Panel
    Friend WithEvents Label_ME As System.Windows.Forms.Label
    Friend WithEvents Label_Max_dauernd As System.Windows.Forms.Label
    Friend WithEvents P_Max_dauernd As System.Windows.Forms.Panel
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents PB_Prozentbalken_RQ As System.Windows.Forms.PictureBox
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents TB_Stunden As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents PB_Prozentbalken_Ges As System.Windows.Forms.PictureBox
    Friend WithEvents Panel_Balken As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents PB_Prozentbalken_VF As System.Windows.Forms.PictureBox
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TB_Minuten As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents LV_Ueberschreitungen As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents CH_Bemerkung As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DTP_UEBER_startDatum As System.Windows.Forms.DateTimePicker
    Friend WithEvents NUD_UEBER_Anzahl As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents NUD_UEBER_Prozent As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Button_UEBER_Aktuallisieren As System.Windows.Forms.Button

End Class
