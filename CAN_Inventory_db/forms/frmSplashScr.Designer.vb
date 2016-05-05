<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSplashScr
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblAppTitle = New System.Windows.Forms.Label()
        Me.lblAppVer = New System.Windows.Forms.Label()
        Me.pmtFindDB = New System.Windows.Forms.OpenFileDialog()
        Me.SuspendLayout()
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblStatus.Location = New System.Drawing.Point(258, 261)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(226, 33)
        Me.lblStatus.TabIndex = 1
        '
        'lblAppTitle
        '
        Me.lblAppTitle.AutoSize = True
        Me.lblAppTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblAppTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAppTitle.Location = New System.Drawing.Point(253, 208)
        Me.lblAppTitle.Name = "lblAppTitle"
        Me.lblAppTitle.Size = New System.Drawing.Size(239, 31)
        Me.lblAppTitle.TabIndex = 2
        Me.lblAppTitle.Text = "lnventory System"
        '
        'lblAppVer
        '
        Me.lblAppVer.AutoSize = True
        Me.lblAppVer.BackColor = System.Drawing.Color.Transparent
        Me.lblAppVer.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAppVer.Location = New System.Drawing.Point(258, 239)
        Me.lblAppVer.Name = "lblAppVer"
        Me.lblAppVer.Size = New System.Drawing.Size(91, 17)
        Me.lblAppVer.TabIndex = 2
        Me.lblAppVer.Text = "Version 1.0"
        '
        'pmtFindDB
        '
        Me.pmtFindDB.FileName = "OpenFileDialog1"
        '
        'frmSplashScr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.CAN_Inventory_db.My.Resources.Resources.splash_graphic
        Me.ClientSize = New System.Drawing.Size(496, 303)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblAppVer)
        Me.Controls.Add(Me.lblAppTitle)
        Me.Controls.Add(Me.lblStatus)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSplashScr"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblStatus As Label
    Friend WithEvents lblAppTitle As Label
    Friend WithEvents lblAppVer As Label
    Friend WithEvents pmtFindDB As OpenFileDialog
End Class
