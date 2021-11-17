<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControl_Karte
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserControl_Karte))
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip
        Me.TSB_Hand = New System.Windows.Forms.ToolStripButton
        Me.TSB_Rahmen = New System.Windows.Forms.ToolStripButton
        Me.TSB_Arrow = New System.Windows.Forms.ToolStripButton
        Me.TSB_Entsprerren = New System.Windows.Forms.ToolStripButton
        Me.TSB_KoordSpeicher = New System.Windows.Forms.ToolStripButton
        Me.TSB_neuIOrt = New System.Windows.Forms.ToolStripButton
        Me.TSSB_Immissionsort = New System.Windows.Forms.ToolStripButton
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.TSSL_Rechts = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel
        Me.TSSL_Hoch = New System.Windows.Forms.ToolStripStatusLabel
        Me.Panel_Karte = New System.Windows.Forms.Panel
        Me.PictureBox_Karte = New System.Windows.Forms.PictureBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ToolStrip2.SuspendLayout()
        Me.Panel_Karte.SuspendLayout()
        CType(Me.PictureBox_Karte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStrip2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSB_Hand, Me.TSB_Rahmen, Me.TSB_Arrow, Me.TSB_Entsprerren, Me.TSB_KoordSpeicher, Me.TSB_neuIOrt, Me.TSSB_Immissionsort, Me.ToolStripLabel1, Me.ToolStripStatusLabel2, Me.TSSL_Rechts, Me.ToolStripStatusLabel4, Me.TSSL_Hoch})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(1073, 31)
        Me.ToolStrip2.TabIndex = 4
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'TSB_Hand
        '
        Me.TSB_Hand.CheckOnClick = True
        Me.TSB_Hand.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSB_Hand.Image = CType(resources.GetObject("TSB_Hand.Image"), System.Drawing.Image)
        Me.TSB_Hand.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSB_Hand.Name = "TSB_Hand"
        Me.TSB_Hand.Size = New System.Drawing.Size(23, 28)
        Me.TSB_Hand.Text = "Verschieben"
        '
        'TSB_Rahmen
        '
        Me.TSB_Rahmen.CheckOnClick = True
        Me.TSB_Rahmen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSB_Rahmen.Image = CType(resources.GetObject("TSB_Rahmen.Image"), System.Drawing.Image)
        Me.TSB_Rahmen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSB_Rahmen.Name = "TSB_Rahmen"
        Me.TSB_Rahmen.Size = New System.Drawing.Size(23, 28)
        Me.TSB_Rahmen.Text = "Ausschnitt vergrößern"
        '
        'TSB_Arrow
        '
        Me.TSB_Arrow.CheckOnClick = True
        Me.TSB_Arrow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSB_Arrow.Image = CType(resources.GetObject("TSB_Arrow.Image"), System.Drawing.Image)
        Me.TSB_Arrow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSB_Arrow.Name = "TSB_Arrow"
        Me.TSB_Arrow.Size = New System.Drawing.Size(23, 28)
        Me.TSB_Arrow.Text = "Zeiger"
        '
        'TSB_Entsprerren
        '
        Me.TSB_Entsprerren.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSB_Entsprerren.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSB_Entsprerren.Name = "TSB_Entsprerren"
        Me.TSB_Entsprerren.Size = New System.Drawing.Size(23, 28)
        Me.TSB_Entsprerren.Text = "ToolStripButton1"
        '
        'TSB_KoordSpeicher
        '
        Me.TSB_KoordSpeicher.CheckOnClick = True
        Me.TSB_KoordSpeicher.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSB_KoordSpeicher.Image = CType(resources.GetObject("TSB_KoordSpeicher.Image"), System.Drawing.Image)
        Me.TSB_KoordSpeicher.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSB_KoordSpeicher.Name = "TSB_KoordSpeicher"
        Me.TSB_KoordSpeicher.Size = New System.Drawing.Size(23, 28)
        Me.TSB_KoordSpeicher.Text = "Koord-Speicher"
        Me.TSB_KoordSpeicher.ToolTipText = "Koordinaten-Speicher"
        Me.TSB_KoordSpeicher.Visible = False
        '
        'TSB_neuIOrt
        '
        Me.TSB_neuIOrt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSB_neuIOrt.Image = CType(resources.GetObject("TSB_neuIOrt.Image"), System.Drawing.Image)
        Me.TSB_neuIOrt.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSB_neuIOrt.Name = "TSB_neuIOrt"
        Me.TSB_neuIOrt.Size = New System.Drawing.Size(23, 28)
        Me.TSB_neuIOrt.Text = "neuer Immissionsort"
        Me.TSB_neuIOrt.Visible = False
        '
        'TSSB_Immissionsort
        '
        Me.TSSB_Immissionsort.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TSSB_Immissionsort.Image = CType(resources.GetObject("TSSB_Immissionsort.Image"), System.Drawing.Image)
        Me.TSSB_Immissionsort.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSSB_Immissionsort.Name = "TSSB_Immissionsort"
        Me.TSSB_Immissionsort.Size = New System.Drawing.Size(23, 28)
        Me.TSSB_Immissionsort.Text = "ToolStripButton1"
        Me.TSSB_Immissionsort.Visible = False
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(424, 28)
        Me.ToolStripLabel1.Text = "                                                                                 " & _
            "  "
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(64, 26)
        Me.ToolStripStatusLabel2.Text = "Rechts"
        '
        'TSSL_Rechts
        '
        Me.TSSL_Rechts.Name = "TSSL_Rechts"
        Me.TSSL_Rechts.Size = New System.Drawing.Size(79, 26)
        Me.TSSL_Rechts.Text = "              "
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(49, 26)
        Me.ToolStripStatusLabel4.Text = "Hoch"
        '
        'TSSL_Hoch
        '
        Me.TSSL_Hoch.Name = "TSSL_Hoch"
        Me.TSSL_Hoch.Size = New System.Drawing.Size(79, 26)
        Me.TSSL_Hoch.Text = "              "
        '
        'Panel_Karte
        '
        Me.Panel_Karte.AutoScroll = True
        Me.Panel_Karte.Controls.Add(Me.PictureBox_Karte)
        Me.Panel_Karte.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel_Karte.Location = New System.Drawing.Point(0, 31)
        Me.Panel_Karte.Name = "Panel_Karte"
        Me.Panel_Karte.Size = New System.Drawing.Size(1073, 574)
        Me.Panel_Karte.TabIndex = 11
        '
        'PictureBox_Karte
        '
        Me.PictureBox_Karte.BackgroundImage = Global.DaMe_20190306.My.Resources.Resources.soundplan_export
        Me.PictureBox_Karte.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox_Karte.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox_Karte.Name = "PictureBox_Karte"
        Me.PictureBox_Karte.Size = New System.Drawing.Size(4055, 3150)
        Me.PictureBox_Karte.TabIndex = 2
        Me.PictureBox_Karte.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ToolStrip2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1073, 31)
        Me.Panel1.TabIndex = 12
        '
        'UserControl_Karte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel_Karte)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "UserControl_Karte"
        Me.Size = New System.Drawing.Size(1073, 605)
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.Panel_Karte.ResumeLayout(False)
        CType(Me.PictureBox_Karte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents TSB_Hand As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSB_Rahmen As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSB_Arrow As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSB_KoordSpeicher As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSB_neuIOrt As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel_Karte As System.Windows.Forms.Panel
    Friend WithEvents PictureBox_Karte As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TSSL_Rechts As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TSSL_Hoch As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents TSB_Entsprerren As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSSB_Immissionsort As System.Windows.Forms.ToolStripButton

End Class
