<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControl_Messpunkte
    Inherits System.Windows.Forms.UserControl

    'UserControl überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserControl_Messpunkte))
        Me.Label_MsgPfad_1 = New System.Windows.Forms.Label
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel8 = New System.Windows.Forms.Panel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Button_Rechts = New System.Windows.Forms.Button
        Me.NUD_h = New System.Windows.Forms.NumericUpDown
        Me.Label3 = New System.Windows.Forms.Label
        Me.Panel_Legende = New System.Windows.Forms.Panel
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.LB_ME = New System.Windows.Forms.ListBox
        Me.NUD_P_max = New System.Windows.Forms.NumericUpDown
        Me.Button_Unten = New System.Windows.Forms.Button
        Me.NUD_P_Wertebereich = New System.Windows.Forms.NumericUpDown
        Me.Button_Oben = New System.Windows.Forms.Button
        Me.Button_Links = New System.Windows.Forms.Button
        Me.DTP_1 = New System.Windows.Forms.DateTimePicker
        Me.Button_LinksLinks = New System.Windows.Forms.Button
        Me.DTP_Uhrzeit = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.Button_RechtsRechts = New System.Windows.Forms.Button
        Me.Panel_Diagramm = New System.Windows.Forms.Panel
        Me.PB_Diagramm = New System.Windows.Forms.PictureBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Panel8.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.NUD_h, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel_Legende.SuspendLayout()
        CType(Me.NUD_P_max, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUD_P_Wertebereich, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PB_Diagramm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label_MsgPfad_1
        '
        Me.Label_MsgPfad_1.AutoSize = True
        Me.Label_MsgPfad_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label_MsgPfad_1.ForeColor = System.Drawing.Color.Red
        Me.Label_MsgPfad_1.Location = New System.Drawing.Point(0, 3)
        Me.Label_MsgPfad_1.Name = "Label_MsgPfad_1"
        Me.Label_MsgPfad_1.Size = New System.Drawing.Size(880, 18)
        Me.Label_MsgPfad_1.TabIndex = 21
        Me.Label_MsgPfad_1.Text = "Der Dateipfad zu den Messwerten der Messstation 1 konnte nicht gefunden werden. Ü" & _
            "berprüfen Sie die Angaben in den Einstellungen."
        Me.Label_MsgPfad_1.Visible = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(2, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.ImageList1.Images.SetKeyName(0, "ZoomIn.bmp")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(488, 36)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(126, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Pegel-Zeit-Verlauf"
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel8.Controls.Add(Me.Panel1)
        Me.Panel8.Controls.Add(Me.Panel_Diagramm)
        Me.Panel8.Controls.Add(Me.PB_Diagramm)
        Me.Panel8.Controls.Add(Me.Label_MsgPfad_1)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel8.Location = New System.Drawing.Point(0, 0)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(1073, 605)
        Me.Panel8.TabIndex = 22
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel1.Controls.Add(Me.Button_Rechts)
        Me.Panel1.Controls.Add(Me.NUD_h)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Panel_Legende)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.LB_ME)
        Me.Panel1.Controls.Add(Me.NUD_P_max)
        Me.Panel1.Controls.Add(Me.Button_Unten)
        Me.Panel1.Controls.Add(Me.NUD_P_Wertebereich)
        Me.Panel1.Controls.Add(Me.Button_Oben)
        Me.Panel1.Controls.Add(Me.Button_Links)
        Me.Panel1.Controls.Add(Me.DTP_1)
        Me.Panel1.Controls.Add(Me.Button_LinksLinks)
        Me.Panel1.Controls.Add(Me.DTP_Uhrzeit)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Button_RechtsRechts)
        Me.Panel1.Location = New System.Drawing.Point(0, 24)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1073, 57)
        Me.Panel1.TabIndex = 352
        '
        'Button_Rechts
        '
        Me.Button_Rechts.BackgroundImage = CType(resources.GetObject("Button_Rechts.BackgroundImage"), System.Drawing.Image)
        Me.Button_Rechts.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button_Rechts.Location = New System.Drawing.Point(823, 3)
        Me.Button_Rechts.Name = "Button_Rechts"
        Me.Button_Rechts.Size = New System.Drawing.Size(47, 32)
        Me.Button_Rechts.TabIndex = 88
        Me.Button_Rechts.UseVisualStyleBackColor = True
        '
        'NUD_h
        '
        Me.NUD_h.Location = New System.Drawing.Point(760, 9)
        Me.NUD_h.Maximum = New Decimal(New Integer() {24, 0, 0, 0})
        Me.NUD_h.Minimum = New Decimal(New Integer() {1, 0, 0, -2147483648})
        Me.NUD_h.Name = "NUD_h"
        Me.NUD_h.ReadOnly = True
        Me.NUD_h.Size = New System.Drawing.Size(19, 23)
        Me.NUD_h.TabIndex = 352
        Me.NUD_h.Value = New Decimal(New Integer() {12, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(1, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 16)
        Me.Label3.TabIndex = 90
        Me.Label3.Text = "Max. Pegel"
        '
        'Panel_Legende
        '
        Me.Panel_Legende.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel_Legende.Controls.Add(Me.Label2)
        Me.Panel_Legende.Controls.Add(Me.Label21)
        Me.Panel_Legende.Controls.Add(Me.Label23)
        Me.Panel_Legende.Location = New System.Drawing.Point(916, 2)
        Me.Panel_Legende.Name = "Panel_Legende"
        Me.Panel_Legende.Size = New System.Drawing.Size(156, 53)
        Me.Panel_Legende.TabIndex = 351
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label21.Location = New System.Drawing.Point(43, 20)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(84, 13)
        Me.Label21.TabIndex = 314
        Me.Label21.Text = "VF (Vorbeifahrt)"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label23.Location = New System.Drawing.Point(43, 35)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(116, 13)
        Me.Label23.TabIndex = 315
        Me.Label23.Text = "RQ (Reifenquietschen)"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LB_ME
        '
        Me.LB_ME.Enabled = False
        Me.LB_ME.FormattingEnabled = True
        Me.LB_ME.ItemHeight = 16
        Me.LB_ME.Items.AddRange(New Object() {"Messstelle 1 - Bau 50", "Messstelle 2 - Bau 11", "Messstelle 3 - Bau 73"})
        Me.LB_ME.Location = New System.Drawing.Point(214, 3)
        Me.LB_ME.Name = "LB_ME"
        Me.LB_ME.Size = New System.Drawing.Size(169, 52)
        Me.LB_ME.TabIndex = 82
        '
        'NUD_P_max
        '
        Me.NUD_P_max.Increment = New Decimal(New Integer() {10, 0, 0, 0})
        Me.NUD_P_max.Location = New System.Drawing.Point(102, 3)
        Me.NUD_P_max.Margin = New System.Windows.Forms.Padding(4)
        Me.NUD_P_max.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        Me.NUD_P_max.Name = "NUD_P_max"
        Me.NUD_P_max.ReadOnly = True
        Me.NUD_P_max.Size = New System.Drawing.Size(51, 23)
        Me.NUD_P_max.TabIndex = 78
        Me.NUD_P_max.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NUD_P_max.Value = New Decimal(New Integer() {110, 0, 0, 0})
        '
        'Button_Unten
        '
        Me.Button_Unten.BackgroundImage = CType(resources.GetObject("Button_Unten.BackgroundImage"), System.Drawing.Image)
        Me.Button_Unten.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button_Unten.Location = New System.Drawing.Point(186, 33)
        Me.Button_Unten.Name = "Button_Unten"
        Me.Button_Unten.Size = New System.Drawing.Size(22, 22)
        Me.Button_Unten.TabIndex = 93
        Me.Button_Unten.UseVisualStyleBackColor = True
        '
        'NUD_P_Wertebereich
        '
        Me.NUD_P_Wertebereich.Increment = New Decimal(New Integer() {10, 0, 0, 0})
        Me.NUD_P_Wertebereich.Location = New System.Drawing.Point(102, 27)
        Me.NUD_P_Wertebereich.Margin = New System.Windows.Forms.Padding(4)
        Me.NUD_P_Wertebereich.Maximum = New Decimal(New Integer() {70, 0, 0, 0})
        Me.NUD_P_Wertebereich.Minimum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.NUD_P_Wertebereich.Name = "NUD_P_Wertebereich"
        Me.NUD_P_Wertebereich.ReadOnly = True
        Me.NUD_P_Wertebereich.Size = New System.Drawing.Size(51, 23)
        Me.NUD_P_Wertebereich.TabIndex = 80
        Me.NUD_P_Wertebereich.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NUD_P_Wertebereich.Value = New Decimal(New Integer() {60, 0, 0, 0})
        '
        'Button_Oben
        '
        Me.Button_Oben.BackgroundImage = CType(resources.GetObject("Button_Oben.BackgroundImage"), System.Drawing.Image)
        Me.Button_Oben.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button_Oben.Location = New System.Drawing.Point(186, 3)
        Me.Button_Oben.Name = "Button_Oben"
        Me.Button_Oben.Size = New System.Drawing.Size(22, 22)
        Me.Button_Oben.TabIndex = 94
        Me.Button_Oben.UseVisualStyleBackColor = True
        '
        'Button_Links
        '
        Me.Button_Links.BackgroundImage = CType(resources.GetObject("Button_Links.BackgroundImage"), System.Drawing.Image)
        Me.Button_Links.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button_Links.Location = New System.Drawing.Point(713, 3)
        Me.Button_Links.Name = "Button_Links"
        Me.Button_Links.Size = New System.Drawing.Size(47, 32)
        Me.Button_Links.TabIndex = 86
        Me.Button_Links.UseVisualStyleBackColor = True
        '
        'DTP_1
        '
        Me.DTP_1.CustomFormat = " dddd, d.MMM yyyy"
        Me.DTP_1.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right
        Me.DTP_1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTP_1.Location = New System.Drawing.Point(453, 8)
        Me.DTP_1.Name = "DTP_1"
        Me.DTP_1.ShowUpDown = True
        Me.DTP_1.Size = New System.Drawing.Size(202, 23)
        Me.DTP_1.TabIndex = 241
        '
        'Button_LinksLinks
        '
        Me.Button_LinksLinks.BackgroundImage = CType(resources.GetObject("Button_LinksLinks.BackgroundImage"), System.Drawing.Image)
        Me.Button_LinksLinks.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button_LinksLinks.Location = New System.Drawing.Point(405, 3)
        Me.Button_LinksLinks.Name = "Button_LinksLinks"
        Me.Button_LinksLinks.Size = New System.Drawing.Size(42, 32)
        Me.Button_LinksLinks.TabIndex = 87
        Me.Button_LinksLinks.UseVisualStyleBackColor = True
        '
        'DTP_Uhrzeit
        '
        Me.DTP_Uhrzeit.AllowDrop = True
        Me.DTP_Uhrzeit.CustomFormat = "HH:mm"
        Me.DTP_Uhrzeit.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right
        Me.DTP_Uhrzeit.Enabled = False
        Me.DTP_Uhrzeit.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTP_Uhrzeit.Location = New System.Drawing.Point(777, 9)
        Me.DTP_Uhrzeit.Name = "DTP_Uhrzeit"
        Me.DTP_Uhrzeit.ShowUpDown = True
        Me.DTP_Uhrzeit.Size = New System.Drawing.Size(63, 23)
        Me.DTP_Uhrzeit.TabIndex = 92
        Me.DTP_Uhrzeit.Value = New Date(2014, 3, 26, 12, 0, 0, 0)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(1, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 16)
        Me.Label4.TabIndex = 91
        Me.Label4.Text = "Wertebereich"
        '
        'Button_RechtsRechts
        '
        Me.Button_RechtsRechts.BackgroundImage = CType(resources.GetObject("Button_RechtsRechts.BackgroundImage"), System.Drawing.Image)
        Me.Button_RechtsRechts.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button_RechtsRechts.Location = New System.Drawing.Point(658, 3)
        Me.Button_RechtsRechts.Name = "Button_RechtsRechts"
        Me.Button_RechtsRechts.Size = New System.Drawing.Size(42, 32)
        Me.Button_RechtsRechts.TabIndex = 89
        Me.Button_RechtsRechts.UseVisualStyleBackColor = True
        '
        'Panel_Diagramm
        '
        Me.Panel_Diagramm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel_Diagramm.Location = New System.Drawing.Point(112, 107)
        Me.Panel_Diagramm.Name = "Panel_Diagramm"
        Me.Panel_Diagramm.Size = New System.Drawing.Size(900, 420)
        Me.Panel_Diagramm.TabIndex = 79
        '
        'PB_Diagramm
        '
        Me.PB_Diagramm.BackColor = System.Drawing.Color.Gainsboro
        Me.PB_Diagramm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PB_Diagramm.Location = New System.Drawing.Point(0, 88)
        Me.PB_Diagramm.Margin = New System.Windows.Forms.Padding(4)
        Me.PB_Diagramm.Name = "PB_Diagramm"
        Me.PB_Diagramm.Size = New System.Drawing.Size(1073, 501)
        Me.PB_Diagramm.TabIndex = 81
        Me.PB_Diagramm.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(3, 2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(136, 11)
        Me.Label2.TabIndex = 316
        Me.Label2.Text = "Maximalpegel-Grenzwerte"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'UserControl_Messpunkte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel8)
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "UserControl_Messpunkte"
        Me.Size = New System.Drawing.Size(1073, 605)
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.NUD_h, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel_Legende.ResumeLayout(False)
        Me.Panel_Legende.PerformLayout()
        CType(Me.NUD_P_max, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUD_P_Wertebereich, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PB_Diagramm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Label_MsgPfad_1 As System.Windows.Forms.Label
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents LB_ME As System.Windows.Forms.ListBox
    Friend WithEvents NUD_P_Wertebereich As System.Windows.Forms.NumericUpDown
    Friend WithEvents Panel_Diagramm As System.Windows.Forms.Panel
    Friend WithEvents NUD_P_max As System.Windows.Forms.NumericUpDown
    Friend WithEvents PB_Diagramm As System.Windows.Forms.PictureBox
    Friend WithEvents Button_LinksLinks As System.Windows.Forms.Button
    Friend WithEvents Button_Links As System.Windows.Forms.Button
    Friend WithEvents Button_RechtsRechts As System.Windows.Forms.Button
    Friend WithEvents Button_Rechts As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DTP_Uhrzeit As System.Windows.Forms.DateTimePicker
    Friend WithEvents Button_Oben As System.Windows.Forms.Button
    Friend WithEvents Button_Unten As System.Windows.Forms.Button
    Friend WithEvents DTP_1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Panel_Legende As System.Windows.Forms.Panel
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents NUD_h As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
