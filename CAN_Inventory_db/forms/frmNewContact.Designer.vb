<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNewContact
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNewContact))
        Me.cmbContactType = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TextBox21 = New System.Windows.Forms.TextBox()
        Me.TextBox20 = New System.Windows.Forms.TextBox()
        Me.TextBox19 = New System.Windows.Forms.TextBox()
        Me.TextBox18 = New System.Windows.Forms.TextBox()
        Me.TextBox17 = New System.Windows.Forms.TextBox()
        Me.TextBox16 = New System.Windows.Forms.TextBox()
        Me.TextBox15 = New System.Windows.Forms.TextBox()
        Me.txtContactEmail = New System.Windows.Forms.TextBox()
        Me.TextBox13 = New System.Windows.Forms.TextBox()
        Me.TextBox12 = New System.Windows.Forms.TextBox()
        Me.txtContactJobTitle = New System.Windows.Forms.TextBox()
        Me.txtContactLastName = New System.Windows.Forms.TextBox()
        Me.txtContactFirstName = New System.Windows.Forms.TextBox()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.lblContactEmail = New System.Windows.Forms.Label()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.lblContactJobTitle = New System.Windows.Forms.Label()
        Me.lblContactLastName = New System.Windows.Forms.Label()
        Me.lblContactFirstName = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.btnAddBenefactor = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cmbContactType
        '
        Me.cmbContactType.FormattingEnabled = True
        Me.cmbContactType.Location = New System.Drawing.Point(324, 19)
        Me.cmbContactType.Name = "cmbContactType"
        Me.cmbContactType.Size = New System.Drawing.Size(125, 21)
        Me.cmbContactType.TabIndex = 57
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(321, 3)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(74, 13)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "Contact Type:"
        '
        'TextBox21
        '
        Me.TextBox21.Location = New System.Drawing.Point(233, 139)
        Me.TextBox21.Multiline = True
        Me.TextBox21.Name = "TextBox21"
        Me.TextBox21.Size = New System.Drawing.Size(216, 90)
        Me.TextBox21.TabIndex = 27
        '
        'TextBox20
        '
        Me.TextBox20.Location = New System.Drawing.Point(24, 209)
        Me.TextBox20.Name = "TextBox20"
        Me.TextBox20.Size = New System.Drawing.Size(130, 20)
        Me.TextBox20.TabIndex = 18
        '
        'TextBox19
        '
        Me.TextBox19.Location = New System.Drawing.Point(69, 110)
        Me.TextBox19.Name = "TextBox19"
        Me.TextBox19.Size = New System.Drawing.Size(115, 20)
        Me.TextBox19.TabIndex = 10
        '
        'TextBox18
        '
        Me.TextBox18.Location = New System.Drawing.Point(136, 165)
        Me.TextBox18.Name = "TextBox18"
        Me.TextBox18.Size = New System.Drawing.Size(48, 20)
        Me.TextBox18.TabIndex = 16
        '
        'TextBox17
        '
        Me.TextBox17.Location = New System.Drawing.Point(69, 165)
        Me.TextBox17.Name = "TextBox17"
        Me.TextBox17.Size = New System.Drawing.Size(26, 20)
        Me.TextBox17.TabIndex = 14
        '
        'TextBox16
        '
        Me.TextBox16.Location = New System.Drawing.Point(69, 139)
        Me.TextBox16.Name = "TextBox16"
        Me.TextBox16.Size = New System.Drawing.Size(115, 20)
        Me.TextBox16.TabIndex = 12
        '
        'TextBox15
        '
        Me.TextBox15.Location = New System.Drawing.Point(69, 84)
        Me.TextBox15.Name = "TextBox15"
        Me.TextBox15.Size = New System.Drawing.Size(115, 20)
        Me.TextBox15.TabIndex = 9
        '
        'txtContactEmail
        '
        Me.txtContactEmail.Location = New System.Drawing.Point(274, 47)
        Me.txtContactEmail.Name = "txtContactEmail"
        Me.txtContactEmail.Size = New System.Drawing.Size(175, 20)
        Me.txtContactEmail.TabIndex = 21
        '
        'TextBox13
        '
        Me.TextBox13.Location = New System.Drawing.Point(274, 99)
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.Size = New System.Drawing.Size(100, 20)
        Me.TextBox13.TabIndex = 25
        '
        'TextBox12
        '
        Me.TextBox12.Location = New System.Drawing.Point(274, 73)
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.Size = New System.Drawing.Size(100, 20)
        Me.TextBox12.TabIndex = 23
        '
        'txtContactJobTitle
        '
        Me.txtContactJobTitle.Location = New System.Drawing.Point(71, 51)
        Me.txtContactJobTitle.Name = "txtContactJobTitle"
        Me.txtContactJobTitle.Size = New System.Drawing.Size(113, 20)
        Me.txtContactJobTitle.TabIndex = 7
        '
        'txtContactLastName
        '
        Me.txtContactLastName.Location = New System.Drawing.Point(147, 19)
        Me.txtContactLastName.Name = "txtContactLastName"
        Me.txtContactLastName.Size = New System.Drawing.Size(171, 20)
        Me.txtContactLastName.TabIndex = 3
        '
        'txtContactFirstName
        '
        Me.txtContactFirstName.Location = New System.Drawing.Point(14, 19)
        Me.txtContactFirstName.Name = "txtContactFirstName"
        Me.txtContactFirstName.Size = New System.Drawing.Size(122, 20)
        Me.txtContactFirstName.TabIndex = 1
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.Location = New System.Drawing.Point(230, 123)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(54, 13)
        Me.Label59.TabIndex = 26
        Me.Label59.Text = "Comment:"
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Location = New System.Drawing.Point(21, 193)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(107, 13)
        Me.Label56.TabIndex = 17
        Me.Label56.Text = "Benefactor Affiliation:"
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Location = New System.Drawing.Point(230, 103)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(27, 13)
        Me.Label55.TabIndex = 24
        Me.Label55.Text = "Fax:"
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Location = New System.Drawing.Point(111, 168)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(25, 13)
        Me.Label53.TabIndex = 15
        Me.Label53.Text = "Zip:"
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Location = New System.Drawing.Point(34, 168)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(35, 13)
        Me.Label52.TabIndex = 13
        Me.Label52.Text = "State:"
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Location = New System.Drawing.Point(41, 142)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(27, 13)
        Me.Label51.TabIndex = 11
        Me.Label51.Text = "City:"
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Location = New System.Drawing.Point(20, 87)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(48, 13)
        Me.Label50.TabIndex = 8
        Me.Label50.Text = "Address:"
        '
        'lblContactEmail
        '
        Me.lblContactEmail.AutoSize = True
        Me.lblContactEmail.Location = New System.Drawing.Point(230, 51)
        Me.lblContactEmail.Name = "lblContactEmail"
        Me.lblContactEmail.Size = New System.Drawing.Size(35, 13)
        Me.lblContactEmail.TabIndex = 20
        Me.lblContactEmail.Text = "Email:"
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Location = New System.Drawing.Point(230, 77)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(41, 13)
        Me.Label48.TabIndex = 22
        Me.Label48.Text = "Phone:"
        '
        'lblContactJobTitle
        '
        Me.lblContactJobTitle.AutoSize = True
        Me.lblContactJobTitle.Location = New System.Drawing.Point(21, 54)
        Me.lblContactJobTitle.Name = "lblContactJobTitle"
        Me.lblContactJobTitle.Size = New System.Drawing.Size(50, 13)
        Me.lblContactJobTitle.TabIndex = 6
        Me.lblContactJobTitle.Text = "Job Title:"
        '
        'lblContactLastName
        '
        Me.lblContactLastName.AutoSize = True
        Me.lblContactLastName.Location = New System.Drawing.Point(144, 3)
        Me.lblContactLastName.Name = "lblContactLastName"
        Me.lblContactLastName.Size = New System.Drawing.Size(61, 13)
        Me.lblContactLastName.TabIndex = 2
        Me.lblContactLastName.Text = "Last Name:"
        '
        'lblContactFirstName
        '
        Me.lblContactFirstName.AutoSize = True
        Me.lblContactFirstName.Location = New System.Drawing.Point(11, 3)
        Me.lblContactFirstName.Name = "lblContactFirstName"
        Me.lblContactFirstName.Size = New System.Drawing.Size(60, 13)
        Me.lblContactFirstName.TabIndex = 0
        Me.lblContactFirstName.Text = "First Name:"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(374, 237)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 29
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSubmit
        '
        Me.btnSubmit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSubmit.Location = New System.Drawing.Point(293, 237)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(75, 23)
        Me.btnSubmit.TabIndex = 28
        Me.btnSubmit.Text = "Submit"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'btnAddBenefactor
        '
        Me.btnAddBenefactor.Location = New System.Drawing.Point(159, 209)
        Me.btnAddBenefactor.Name = "btnAddBenefactor"
        Me.btnAddBenefactor.Size = New System.Drawing.Size(25, 20)
        Me.btnAddBenefactor.TabIndex = 19
        Me.btnAddBenefactor.Text = "+"
        Me.btnAddBenefactor.UseVisualStyleBackColor = True
        '
        'frmNewContact
        '
        Me.AcceptButton = Me.btnSubmit
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(461, 263)
        Me.Controls.Add(Me.btnAddBenefactor)
        Me.Controls.Add(Me.cmbContactType)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TextBox21)
        Me.Controls.Add(Me.TextBox20)
        Me.Controls.Add(Me.TextBox19)
        Me.Controls.Add(Me.TextBox18)
        Me.Controls.Add(Me.TextBox17)
        Me.Controls.Add(Me.TextBox16)
        Me.Controls.Add(Me.TextBox15)
        Me.Controls.Add(Me.txtContactEmail)
        Me.Controls.Add(Me.TextBox13)
        Me.Controls.Add(Me.TextBox12)
        Me.Controls.Add(Me.txtContactJobTitle)
        Me.Controls.Add(Me.txtContactLastName)
        Me.Controls.Add(Me.txtContactFirstName)
        Me.Controls.Add(Me.Label59)
        Me.Controls.Add(Me.Label56)
        Me.Controls.Add(Me.Label55)
        Me.Controls.Add(Me.Label53)
        Me.Controls.Add(Me.Label52)
        Me.Controls.Add(Me.Label51)
        Me.Controls.Add(Me.Label50)
        Me.Controls.Add(Me.lblContactEmail)
        Me.Controls.Add(Me.Label48)
        Me.Controls.Add(Me.lblContactJobTitle)
        Me.Controls.Add(Me.lblContactLastName)
        Me.Controls.Add(Me.lblContactFirstName)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSubmit)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmNewContact"
        Me.Text = "Add New Contact"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmbContactType As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents TextBox21 As TextBox
    Friend WithEvents TextBox20 As TextBox
    Friend WithEvents TextBox19 As TextBox
    Friend WithEvents TextBox18 As TextBox
    Friend WithEvents TextBox17 As TextBox
    Friend WithEvents TextBox16 As TextBox
    Friend WithEvents TextBox15 As TextBox
    Friend WithEvents txtContactEmail As TextBox
    Friend WithEvents TextBox13 As TextBox
    Friend WithEvents TextBox12 As TextBox
    Friend WithEvents txtContactJobTitle As TextBox
    Friend WithEvents txtContactLastName As TextBox
    Friend WithEvents txtContactFirstName As TextBox
    Friend WithEvents Label59 As Label
    Friend WithEvents Label56 As Label
    Friend WithEvents Label55 As Label
    Friend WithEvents Label53 As Label
    Friend WithEvents Label52 As Label
    Friend WithEvents Label51 As Label
    Friend WithEvents Label50 As Label
    Friend WithEvents lblContactEmail As Label
    Friend WithEvents Label48 As Label
    Friend WithEvents lblContactJobTitle As Label
    Friend WithEvents lblContactLastName As Label
    Friend WithEvents lblContactFirstName As Label
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSubmit As Button
    Friend WithEvents btnAddBenefactor As Button
End Class
