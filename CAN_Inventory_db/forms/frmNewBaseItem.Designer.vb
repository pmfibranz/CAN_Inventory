﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNewBaseItem
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNewBaseItem))
        Me.nbxLwQty = New System.Windows.Forms.NumericUpDown()
        Me.lblLwQty = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.cbxSubCat = New System.Windows.Forms.ComboBox()
        Me.cbxCategory = New System.Windows.Forms.ComboBox()
        Me.txtDefValue = New System.Windows.Forms.TextBox()
        Me.txtDescript = New System.Windows.Forms.TextBox()
        Me.cbxProgram = New System.Windows.Forms.ComboBox()
        Me.cbxBin = New System.Windows.Forms.ComboBox()
        Me.cbxLocation = New System.Windows.Forms.ComboBox()
        Me.cbxFacility = New System.Windows.Forms.ComboBox()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.lblProgram = New System.Windows.Forms.Label()
        Me.lblBin = New System.Windows.Forms.Label()
        Me.lblDescript = New System.Windows.Forms.Label()
        Me.lblDefValue = New System.Windows.Forms.Label()
        Me.lblLocation = New System.Windows.Forms.Label()
        Me.lblFacility = New System.Windows.Forms.Label()
        Me.lblSubCat = New System.Windows.Forms.Label()
        Me.lblCategory = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnAddItem = New System.Windows.Forms.Button()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblInitQty = New System.Windows.Forms.Label()
        Me.nbxInitQty = New System.Windows.Forms.NumericUpDown()
        CType(Me.nbxLwQty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nbxInitQty, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'nbxLwQty
        '
        Me.nbxLwQty.Location = New System.Drawing.Point(203, 255)
        Me.nbxLwQty.Name = "nbxLwQty"
        Me.nbxLwQty.Size = New System.Drawing.Size(82, 20)
        Me.nbxLwQty.TabIndex = 6
        '
        'lblLwQty
        '
        Me.lblLwQty.AutoSize = True
        Me.lblLwQty.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLwQty.Location = New System.Drawing.Point(200, 238)
        Me.lblLwQty.Name = "lblLwQty"
        Me.lblLwQty.Size = New System.Drawing.Size(85, 13)
        Me.lblLwQty.TabIndex = 37
        Me.lblLwQty.Text = "Low Qty Trigger:"
        '
        'txtName
        '
        Me.txtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.Location = New System.Drawing.Point(109, 9)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(264, 26)
        Me.txtName.TabIndex = 1
        '
        'cbxSubCat
        '
        Me.cbxSubCat.Enabled = False
        Me.cbxSubCat.FormattingEnabled = True
        Me.cbxSubCat.Location = New System.Drawing.Point(203, 208)
        Me.cbxSubCat.Name = "cbxSubCat"
        Me.cbxSubCat.Size = New System.Drawing.Size(170, 21)
        Me.cbxSubCat.TabIndex = 4
        '
        'cbxCategory
        '
        Me.cbxCategory.FormattingEnabled = True
        Me.cbxCategory.Location = New System.Drawing.Point(17, 208)
        Me.cbxCategory.Name = "cbxCategory"
        Me.cbxCategory.Size = New System.Drawing.Size(165, 21)
        Me.cbxCategory.TabIndex = 3
        '
        'txtDefValue
        '
        Me.txtDefValue.Location = New System.Drawing.Point(17, 254)
        Me.txtDefValue.Name = "txtDefValue"
        Me.txtDefValue.Size = New System.Drawing.Size(131, 20)
        Me.txtDefValue.TabIndex = 5
        '
        'txtDescript
        '
        Me.txtDescript.Location = New System.Drawing.Point(17, 65)
        Me.txtDescript.Multiline = True
        Me.txtDescript.Name = "txtDescript"
        Me.txtDescript.Size = New System.Drawing.Size(356, 111)
        Me.txtDescript.TabIndex = 2
        '
        'cbxProgram
        '
        Me.cbxProgram.FormattingEnabled = True
        Me.cbxProgram.Location = New System.Drawing.Point(12, 368)
        Me.cbxProgram.Name = "cbxProgram"
        Me.cbxProgram.Size = New System.Drawing.Size(121, 21)
        Me.cbxProgram.TabIndex = 11
        '
        'cbxBin
        '
        Me.cbxBin.Enabled = False
        Me.cbxBin.FormattingEnabled = True
        Me.cbxBin.Location = New System.Drawing.Point(286, 325)
        Me.cbxBin.Name = "cbxBin"
        Me.cbxBin.Size = New System.Drawing.Size(91, 21)
        Me.cbxBin.TabIndex = 10
        '
        'cbxLocation
        '
        Me.cbxLocation.Enabled = False
        Me.cbxLocation.FormattingEnabled = True
        Me.cbxLocation.Location = New System.Drawing.Point(141, 325)
        Me.cbxLocation.Name = "cbxLocation"
        Me.cbxLocation.Size = New System.Drawing.Size(139, 21)
        Me.cbxLocation.TabIndex = 9
        '
        'cbxFacility
        '
        Me.cbxFacility.FormattingEnabled = True
        Me.cbxFacility.Location = New System.Drawing.Point(12, 325)
        Me.cbxFacility.Name = "cbxFacility"
        Me.cbxFacility.Size = New System.Drawing.Size(123, 21)
        Me.cbxFacility.TabIndex = 8
        '
        'PictureBox7
        '
        Me.PictureBox7.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox7.BackgroundImage = Global.CAN_Inventory_db.My.Resources.Resources.horiz_divider
        Me.PictureBox7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox7.Location = New System.Drawing.Point(12, 288)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(365, 6)
        Me.PictureBox7.TabIndex = 27
        Me.PictureBox7.TabStop = False
        '
        'lblProgram
        '
        Me.lblProgram.AutoSize = True
        Me.lblProgram.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProgram.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblProgram.Location = New System.Drawing.Point(9, 352)
        Me.lblProgram.MaximumSize = New System.Drawing.Size(250, 0)
        Me.lblProgram.Name = "lblProgram"
        Me.lblProgram.Size = New System.Drawing.Size(89, 13)
        Me.lblProgram.TabIndex = 26
        Me.lblProgram.Text = "Default Program: "
        '
        'lblBin
        '
        Me.lblBin.AutoSize = True
        Me.lblBin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBin.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblBin.Location = New System.Drawing.Point(283, 309)
        Me.lblBin.MaximumSize = New System.Drawing.Size(250, 0)
        Me.lblBin.Name = "lblBin"
        Me.lblBin.Size = New System.Drawing.Size(65, 13)
        Me.lblBin.TabIndex = 25
        Me.lblBin.Text = "Default Bin: "
        '
        'lblDescript
        '
        Me.lblDescript.AutoSize = True
        Me.lblDescript.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescript.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDescript.Location = New System.Drawing.Point(14, 49)
        Me.lblDescript.MaximumSize = New System.Drawing.Size(250, 0)
        Me.lblDescript.Name = "lblDescript"
        Me.lblDescript.Size = New System.Drawing.Size(108, 13)
        Me.lblDescript.TabIndex = 24
        Me.lblDescript.Text = "Detailed Description: "
        '
        'lblDefValue
        '
        Me.lblDefValue.AutoSize = True
        Me.lblDefValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDefValue.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDefValue.Location = New System.Drawing.Point(14, 238)
        Me.lblDefValue.MaximumSize = New System.Drawing.Size(250, 0)
        Me.lblDefValue.Name = "lblDefValue"
        Me.lblDefValue.Size = New System.Drawing.Size(77, 13)
        Me.lblDefValue.TabIndex = 23
        Me.lblDefValue.Text = "Default Value: "
        '
        'lblLocation
        '
        Me.lblLocation.AutoSize = True
        Me.lblLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLocation.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLocation.Location = New System.Drawing.Point(138, 309)
        Me.lblLocation.MaximumSize = New System.Drawing.Size(250, 0)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(91, 13)
        Me.lblLocation.TabIndex = 22
        Me.lblLocation.Text = "Default Location: "
        '
        'lblFacility
        '
        Me.lblFacility.AutoSize = True
        Me.lblFacility.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFacility.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblFacility.Location = New System.Drawing.Point(9, 309)
        Me.lblFacility.MaximumSize = New System.Drawing.Size(250, 0)
        Me.lblFacility.Name = "lblFacility"
        Me.lblFacility.Size = New System.Drawing.Size(82, 13)
        Me.lblFacility.TabIndex = 21
        Me.lblFacility.Text = "Default Facility: "
        '
        'lblSubCat
        '
        Me.lblSubCat.AutoSize = True
        Me.lblSubCat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubCat.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblSubCat.Location = New System.Drawing.Point(200, 192)
        Me.lblSubCat.MaximumSize = New System.Drawing.Size(250, 0)
        Me.lblSubCat.Name = "lblSubCat"
        Me.lblSubCat.Size = New System.Drawing.Size(77, 13)
        Me.lblSubCat.TabIndex = 20
        Me.lblSubCat.Text = "Sub-Category: "
        '
        'lblCategory
        '
        Me.lblCategory.AutoSize = True
        Me.lblCategory.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCategory.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCategory.Location = New System.Drawing.Point(14, 192)
        Me.lblCategory.MaximumSize = New System.Drawing.Size(250, 0)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Size = New System.Drawing.Size(55, 13)
        Me.lblCategory.TabIndex = 19
        Me.lblCategory.Text = "Category: "
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblName.Location = New System.Drawing.Point(13, 12)
        Me.lblName.MaximumSize = New System.Drawing.Size(250, 0)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(95, 20)
        Me.lblName.TabIndex = 18
        Me.lblName.Text = "Item Name:"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(299, 419)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 13
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnAddItem
        '
        Me.btnAddItem.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddItem.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAddItem.Location = New System.Drawing.Point(200, 419)
        Me.btnAddItem.Name = "btnAddItem"
        Me.btnAddItem.Size = New System.Drawing.Size(93, 23)
        Me.btnAddItem.TabIndex = 12
        Me.btnAddItem.Text = "Add Base Item"
        Me.btnAddItem.UseVisualStyleBackColor = True
        '
        'lblStatus
        '
        Me.lblStatus.Location = New System.Drawing.Point(9, 424)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(173, 13)
        Me.lblStatus.TabIndex = 39
        '
        'lblInitQty
        '
        Me.lblInitQty.AutoSize = True
        Me.lblInitQty.Location = New System.Drawing.Point(309, 238)
        Me.lblInitQty.Name = "lblInitQty"
        Me.lblInitQty.Size = New System.Drawing.Size(53, 13)
        Me.lblInitQty.TabIndex = 40
        Me.lblInitQty.Text = "Initial Qty:"
        '
        'nbxInitQty
        '
        Me.nbxInitQty.Location = New System.Drawing.Point(312, 255)
        Me.nbxInitQty.Name = "nbxInitQty"
        Me.nbxInitQty.Size = New System.Drawing.Size(61, 20)
        Me.nbxInitQty.TabIndex = 7
        '
        'frmNewBaseItem
        '
        Me.AcceptButton = Me.btnAddItem
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(386, 454)
        Me.Controls.Add(Me.nbxInitQty)
        Me.Controls.Add(Me.lblInitQty)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.nbxLwQty)
        Me.Controls.Add(Me.lblLwQty)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.cbxSubCat)
        Me.Controls.Add(Me.cbxCategory)
        Me.Controls.Add(Me.txtDefValue)
        Me.Controls.Add(Me.txtDescript)
        Me.Controls.Add(Me.cbxProgram)
        Me.Controls.Add(Me.cbxBin)
        Me.Controls.Add(Me.cbxLocation)
        Me.Controls.Add(Me.cbxFacility)
        Me.Controls.Add(Me.PictureBox7)
        Me.Controls.Add(Me.lblProgram)
        Me.Controls.Add(Me.lblBin)
        Me.Controls.Add(Me.lblDescript)
        Me.Controls.Add(Me.lblDefValue)
        Me.Controls.Add(Me.lblLocation)
        Me.Controls.Add(Me.lblFacility)
        Me.Controls.Add(Me.lblSubCat)
        Me.Controls.Add(Me.lblCategory)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnAddItem)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmNewBaseItem"
        Me.Text = "Add New Base Item"
        CType(Me.nbxLwQty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nbxInitQty, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents nbxLwQty As NumericUpDown
    Friend WithEvents lblLwQty As Label
    Friend WithEvents txtName As TextBox
    Friend WithEvents cbxSubCat As ComboBox
    Friend WithEvents cbxCategory As ComboBox
    Friend WithEvents txtDefValue As TextBox
    Friend WithEvents txtDescript As TextBox
    Friend WithEvents cbxProgram As ComboBox
    Friend WithEvents cbxBin As ComboBox
    Friend WithEvents cbxLocation As ComboBox
    Friend WithEvents cbxFacility As ComboBox
    Friend WithEvents PictureBox7 As PictureBox
    Friend WithEvents lblProgram As Label
    Friend WithEvents lblBin As Label
    Friend WithEvents lblDescript As Label
    Friend WithEvents lblDefValue As Label
    Friend WithEvents lblLocation As Label
    Friend WithEvents lblFacility As Label
    Friend WithEvents lblSubCat As Label
    Friend WithEvents lblCategory As Label
    Friend WithEvents lblName As Label
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnAddItem As Button
    Friend WithEvents lblStatus As Label
    Friend WithEvents lblInitQty As Label
    Friend WithEvents nbxInitQty As NumericUpDown
End Class
