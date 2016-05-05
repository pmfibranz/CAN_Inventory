<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogin
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogin))
        Me.cbxUsers = New System.Windows.Forms.ComboBox()
        Me.lblUsername = New System.Windows.Forms.Label()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.btnAddUser = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cbxUsers
        '
        Me.cbxUsers.FormattingEnabled = True
        Me.cbxUsers.Location = New System.Drawing.Point(82, 12)
        Me.cbxUsers.Name = "cbxUsers"
        Me.cbxUsers.Size = New System.Drawing.Size(121, 21)
        Me.cbxUsers.TabIndex = 0
        '
        'lblUsername
        '
        Me.lblUsername.AutoSize = True
        Me.lblUsername.Location = New System.Drawing.Point(19, 15)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(58, 13)
        Me.lblUsername.TabIndex = 1
        Me.lblUsername.Text = "Username:"
        '
        'btnLogin
        '
        Me.btnLogin.Location = New System.Drawing.Point(209, 12)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(75, 23)
        Me.btnLogin.TabIndex = 2
        Me.btnLogin.Text = "Login"
        Me.btnLogin.UseVisualStyleBackColor = True
        '
        'btnAddUser
        '
        Me.btnAddUser.Location = New System.Drawing.Point(209, 70)
        Me.btnAddUser.Name = "btnAddUser"
        Me.btnAddUser.Size = New System.Drawing.Size(75, 23)
        Me.btnAddUser.TabIndex = 2
        Me.btnAddUser.Text = "Add User"
        Me.btnAddUser.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(209, 41)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'lblStatus
        '
        Me.lblStatus.Location = New System.Drawing.Point(19, 46)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(184, 47)
        Me.lblStatus.TabIndex = 3
        '
        'frmLogin
        '
        Me.AcceptButton = Me.btnLogin
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(298, 103)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.btnAddUser)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnLogin)
        Me.Controls.Add(Me.lblUsername)
        Me.Controls.Add(Me.cbxUsers)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cbxUsers As ComboBox
    Friend WithEvents lblUsername As Label
    Friend WithEvents btnLogin As Button
    Friend WithEvents btnAddUser As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents lblStatus As Label
End Class
