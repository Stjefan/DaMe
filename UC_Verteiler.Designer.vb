<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UC_Verteiler
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
        Me.Button_Remove_Verteiler = New System.Windows.Forms.Button
        Me.Label_Verteiler = New System.Windows.Forms.Label
        Me.TB_Empfaenger = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'Button_Remove_Verteiler
        '
        Me.Button_Remove_Verteiler.Location = New System.Drawing.Point(175, 0)
        Me.Button_Remove_Verteiler.Name = "Button_Remove_Verteiler"
        Me.Button_Remove_Verteiler.Size = New System.Drawing.Size(28, 23)
        Me.Button_Remove_Verteiler.TabIndex = 167
        Me.Button_Remove_Verteiler.Text = "-"
        Me.Button_Remove_Verteiler.UseVisualStyleBackColor = True
        '
        'Label_Verteiler
        '
        Me.Label_Verteiler.AutoSize = True
        Me.Label_Verteiler.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Verteiler.Location = New System.Drawing.Point(5, 4)
        Me.Label_Verteiler.Name = "Label_Verteiler"
        Me.Label_Verteiler.Size = New System.Drawing.Size(66, 13)
        Me.Label_Verteiler.TabIndex = 166
        Me.Label_Verteiler.Text = "Verteiler 1"
        '
        'TB_Empfaenger
        '
        Me.TB_Empfaenger.Location = New System.Drawing.Point(3, 24)
        Me.TB_Empfaenger.Multiline = True
        Me.TB_Empfaenger.Name = "TB_Empfaenger"
        Me.TB_Empfaenger.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TB_Empfaenger.Size = New System.Drawing.Size(200, 77)
        Me.TB_Empfaenger.TabIndex = 165
        '
        'UC_Verteiler
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Button_Remove_Verteiler)
        Me.Controls.Add(Me.Label_Verteiler)
        Me.Controls.Add(Me.TB_Empfaenger)
        Me.Name = "UC_Verteiler"
        Me.Size = New System.Drawing.Size(208, 104)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button_Remove_Verteiler As System.Windows.Forms.Button
    Friend WithEvents Label_Verteiler As System.Windows.Forms.Label
    Friend WithEvents TB_Empfaenger As System.Windows.Forms.TextBox

End Class
