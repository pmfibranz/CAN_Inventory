<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class uclBaseItem
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
        Me.nbxInitQty = New System.Windows.Forms.NumericUpDown()
        Me.lblInitQty = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.nbxLwQty = New System.Windows.Forms.NumericUpDown()
        Me.lblLwQty = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.cmbSubCat = New System.Windows.Forms.ComboBox()
        Me.cmbCategory = New System.Windows.Forms.ComboBox()
        Me.txtDefValue = New System.Windows.Forms.TextBox()
        Me.cmbProgram = New System.Windows.Forms.ComboBox()
        Me.cmbBin = New System.Windows.Forms.ComboBox()
        Me.cmbLocation = New System.Windows.Forms.ComboBox()
        Me.cmbFacility = New System.Windows.Forms.ComboBox()
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
        Me.cmbCondition = New System.Windows.Forms.ComboBox()
        Me.lblCondition = New System.Windows.Forms.Label()
        Me.grpItemMode = New System.Windows.Forms.GroupBox()
        Me.rdoItemModeAdd = New System.Windows.Forms.RadioButton()
        Me.rdoItemModeEdit = New System.Windows.Forms.RadioButton()
        Me.txtDescript = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnUpdateItem = New System.Windows.Forms.Button()
        CType(Me.nbxInitQty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nbxLwQty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpItemMode.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'nbxInitQty
        '
        Me.nbxInitQty.Location = New System.Drawing.Point(17, 368)
        Me.nbxInitQty.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.nbxInitQty.Name = "nbxInitQty"
        Me.nbxInitQty.Size = New System.Drawing.Size(80, 22)
        Me.nbxInitQty.TabIndex = 13
        '
        'lblInitQty
        '
        Me.lblInitQty.AutoSize = True
        Me.lblInitQty.Location = New System.Drawing.Point(13, 347)
        Me.lblInitQty.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblInitQty.Name = "lblInitQty"
        Me.lblInitQty.Size = New System.Drawing.Size(70, 17)
        Me.lblInitQty.TabIndex = 12
        Me.lblInitQty.Text = "Initial Qty:"
        '
        'lblStatus
        '
        Me.lblStatus.Location = New System.Drawing.Point(13, 527)
        Me.lblStatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(231, 16)
        Me.lblStatus.TabIndex = 65
        '
        'nbxLwQty
        '
        Me.nbxLwQty.Location = New System.Drawing.Point(272, 368)
        Me.nbxLwQty.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.nbxLwQty.Name = "nbxLwQty"
        Me.nbxLwQty.Size = New System.Drawing.Size(108, 22)
        Me.nbxLwQty.TabIndex = 15
        '
        'lblLwQty
        '
        Me.lblLwQty.AutoSize = True
        Me.lblLwQty.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLwQty.Location = New System.Drawing.Point(268, 347)
        Me.lblLwQty.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblLwQty.Name = "lblLwQty"
        Me.lblLwQty.Size = New System.Drawing.Size(113, 17)
        Me.lblLwQty.TabIndex = 14
        Me.lblLwQty.Text = "Low Qty Trigger:"
        '
        'txtName
        '
        Me.txtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.Location = New System.Drawing.Point(16, 85)
        Me.txtName.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(488, 31)
        Me.txtName.TabIndex = 1
        '
        'cmbSubCat
        '
        Me.cmbSubCat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSubCat.Enabled = False
        Me.cmbSubCat.FormattingEnabled = True
        Me.cmbSubCat.Location = New System.Drawing.Point(272, 255)
        Me.cmbSubCat.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbSubCat.Name = "cmbSubCat"
        Me.cmbSubCat.Size = New System.Drawing.Size(173, 24)
        Me.cmbSubCat.TabIndex = 7
        '
        'cmbCategory
        '
        Me.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategory.FormattingEnabled = True
        Me.cmbCategory.Location = New System.Drawing.Point(16, 255)
        Me.cmbCategory.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbCategory.Name = "cmbCategory"
        Me.cmbCategory.Size = New System.Drawing.Size(219, 24)
        Me.cmbCategory.TabIndex = 5
        '
        'txtDefValue
        '
        Me.txtDefValue.Location = New System.Drawing.Point(272, 313)
        Me.txtDefValue.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtDefValue.Name = "txtDefValue"
        Me.txtDefValue.Size = New System.Drawing.Size(173, 22)
        Me.txtDefValue.TabIndex = 11
        '
        'cmbProgram
        '
        Me.cmbProgram.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProgram.FormattingEnabled = True
        Me.cmbProgram.Location = New System.Drawing.Point(16, 498)
        Me.cmbProgram.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbProgram.Name = "cmbProgram"
        Me.cmbProgram.Size = New System.Drawing.Size(160, 24)
        Me.cmbProgram.TabIndex = 23
        '
        'cmbBin
        '
        Me.cmbBin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBin.Enabled = False
        Me.cmbBin.FormattingEnabled = True
        Me.cmbBin.Location = New System.Drawing.Point(383, 438)
        Me.cmbBin.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbBin.Name = "cmbBin"
        Me.cmbBin.Size = New System.Drawing.Size(120, 24)
        Me.cmbBin.TabIndex = 21
        '
        'cmbLocation
        '
        Me.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLocation.Enabled = False
        Me.cmbLocation.FormattingEnabled = True
        Me.cmbLocation.Location = New System.Drawing.Point(205, 438)
        Me.cmbLocation.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbLocation.Name = "cmbLocation"
        Me.cmbLocation.Size = New System.Drawing.Size(151, 24)
        Me.cmbLocation.TabIndex = 19
        '
        'cmbFacility
        '
        Me.cmbFacility.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFacility.FormattingEnabled = True
        Me.cmbFacility.Location = New System.Drawing.Point(17, 438)
        Me.cmbFacility.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbFacility.Name = "cmbFacility"
        Me.cmbFacility.Size = New System.Drawing.Size(163, 24)
        Me.cmbFacility.TabIndex = 17
        '
        'PictureBox7
        '
        Me.PictureBox7.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox7.BackgroundImage = Global.CAN_Inventory_db.My.Resources.Resources.horiz_divider
        Me.PictureBox7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox7.Location = New System.Drawing.Point(16, 398)
        Me.PictureBox7.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(487, 7)
        Me.PictureBox7.TabIndex = 63
        Me.PictureBox7.TabStop = False
        '
        'lblProgram
        '
        Me.lblProgram.AutoSize = True
        Me.lblProgram.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProgram.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblProgram.Location = New System.Drawing.Point(14, 477)
        Me.lblProgram.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblProgram.MaximumSize = New System.Drawing.Size(333, 0)
        Me.lblProgram.Name = "lblProgram"
        Me.lblProgram.Size = New System.Drawing.Size(119, 17)
        Me.lblProgram.TabIndex = 22
        Me.lblProgram.Text = "Default Program: "
        '
        'lblBin
        '
        Me.lblBin.AutoSize = True
        Me.lblBin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBin.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblBin.Location = New System.Drawing.Point(379, 418)
        Me.lblBin.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblBin.MaximumSize = New System.Drawing.Size(333, 0)
        Me.lblBin.Name = "lblBin"
        Me.lblBin.Size = New System.Drawing.Size(85, 17)
        Me.lblBin.TabIndex = 20
        Me.lblBin.Text = "Default Bin: "
        '
        'lblDescript
        '
        Me.lblDescript.AutoSize = True
        Me.lblDescript.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescript.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDescript.Location = New System.Drawing.Point(14, 127)
        Me.lblDescript.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDescript.MaximumSize = New System.Drawing.Size(333, 0)
        Me.lblDescript.Name = "lblDescript"
        Me.lblDescript.Size = New System.Drawing.Size(143, 17)
        Me.lblDescript.TabIndex = 2
        Me.lblDescript.Text = "Detailed Description: "
        '
        'lblDefValue
        '
        Me.lblDefValue.AutoSize = True
        Me.lblDefValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDefValue.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDefValue.Location = New System.Drawing.Point(268, 293)
        Me.lblDefValue.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDefValue.MaximumSize = New System.Drawing.Size(333, 0)
        Me.lblDefValue.Name = "lblDefValue"
        Me.lblDefValue.Size = New System.Drawing.Size(101, 17)
        Me.lblDefValue.TabIndex = 10
        Me.lblDefValue.Text = "Default Value: "
        '
        'lblLocation
        '
        Me.lblLocation.AutoSize = True
        Me.lblLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLocation.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblLocation.Location = New System.Drawing.Point(201, 418)
        Me.lblLocation.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblLocation.MaximumSize = New System.Drawing.Size(333, 0)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(119, 17)
        Me.lblLocation.TabIndex = 18
        Me.lblLocation.Text = "Default Location: "
        '
        'lblFacility
        '
        Me.lblFacility.AutoSize = True
        Me.lblFacility.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFacility.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblFacility.Location = New System.Drawing.Point(14, 417)
        Me.lblFacility.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFacility.MaximumSize = New System.Drawing.Size(333, 0)
        Me.lblFacility.Name = "lblFacility"
        Me.lblFacility.Size = New System.Drawing.Size(108, 17)
        Me.lblFacility.TabIndex = 16
        Me.lblFacility.Text = "Default Facility: "
        '
        'lblSubCat
        '
        Me.lblSubCat.AutoSize = True
        Me.lblSubCat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubCat.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblSubCat.Location = New System.Drawing.Point(268, 235)
        Me.lblSubCat.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSubCat.MaximumSize = New System.Drawing.Size(333, 0)
        Me.lblSubCat.Name = "lblSubCat"
        Me.lblSubCat.Size = New System.Drawing.Size(103, 17)
        Me.lblSubCat.TabIndex = 6
        Me.lblSubCat.Text = "Sub-Category: "
        '
        'lblCategory
        '
        Me.lblCategory.AutoSize = True
        Me.lblCategory.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCategory.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCategory.Location = New System.Drawing.Point(14, 234)
        Me.lblCategory.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCategory.MaximumSize = New System.Drawing.Size(333, 0)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Size = New System.Drawing.Size(73, 17)
        Me.lblCategory.TabIndex = 4
        Me.lblCategory.Text = "Category: "
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblName.Location = New System.Drawing.Point(14, 64)
        Me.lblName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblName.MaximumSize = New System.Drawing.Size(333, 0)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(79, 17)
        Me.lblName.TabIndex = 0
        Me.lblName.Text = "Item Name:"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(384, 521)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(100, 28)
        Me.btnCancel.TabIndex = 25
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnAddItem
        '
        Me.btnAddItem.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddItem.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAddItem.Location = New System.Drawing.Point(252, 521)
        Me.btnAddItem.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnAddItem.Name = "btnAddItem"
        Me.btnAddItem.Size = New System.Drawing.Size(124, 28)
        Me.btnAddItem.TabIndex = 24
        Me.btnAddItem.Text = "Add Base Item"
        Me.btnAddItem.UseVisualStyleBackColor = True
        '
        'cmbCondition
        '
        Me.cmbCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCondition.FormattingEnabled = True
        Me.cmbCondition.Location = New System.Drawing.Point(16, 311)
        Me.cmbCondition.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbCondition.Name = "cmbCondition"
        Me.cmbCondition.Size = New System.Drawing.Size(219, 24)
        Me.cmbCondition.TabIndex = 9
        '
        'lblCondition
        '
        Me.lblCondition.AutoSize = True
        Me.lblCondition.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCondition.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCondition.Location = New System.Drawing.Point(14, 290)
        Me.lblCondition.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCondition.MaximumSize = New System.Drawing.Size(333, 0)
        Me.lblCondition.Name = "lblCondition"
        Me.lblCondition.Size = New System.Drawing.Size(75, 17)
        Me.lblCondition.TabIndex = 8
        Me.lblCondition.Text = "Condition: "
        '
        'grpItemMode
        '
        Me.grpItemMode.Controls.Add(Me.rdoItemModeEdit)
        Me.grpItemMode.Controls.Add(Me.rdoItemModeAdd)
        Me.grpItemMode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpItemMode.Location = New System.Drawing.Point(16, 4)
        Me.grpItemMode.Name = "grpItemMode"
        Me.grpItemMode.Size = New System.Drawing.Size(487, 42)
        Me.grpItemMode.TabIndex = 66
        Me.grpItemMode.TabStop = False
        Me.grpItemMode.Text = "Mode"
        '
        'rdoItemModeAdd
        '
        Me.rdoItemModeAdd.AutoSize = True
        Me.rdoItemModeAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoItemModeAdd.Location = New System.Drawing.Point(85, 12)
        Me.rdoItemModeAdd.Name = "rdoItemModeAdd"
        Me.rdoItemModeAdd.Size = New System.Drawing.Size(134, 24)
        Me.rdoItemModeAdd.TabIndex = 0
        Me.rdoItemModeAdd.TabStop = True
        Me.rdoItemModeAdd.Text = "Add New Item"
        Me.rdoItemModeAdd.UseVisualStyleBackColor = True
        '
        'rdoItemModeEdit
        '
        Me.rdoItemModeEdit.AutoSize = True
        Me.rdoItemModeEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoItemModeEdit.Location = New System.Drawing.Point(261, 12)
        Me.rdoItemModeEdit.Name = "rdoItemModeEdit"
        Me.rdoItemModeEdit.Size = New System.Drawing.Size(160, 24)
        Me.rdoItemModeEdit.TabIndex = 1
        Me.rdoItemModeEdit.TabStop = True
        Me.rdoItemModeEdit.Text = "Edit Existing Item"
        Me.rdoItemModeEdit.UseVisualStyleBackColor = True
        '
        'txtDescript
        '
        Me.txtDescript.Location = New System.Drawing.Point(16, 148)
        Me.txtDescript.Margin = New System.Windows.Forms.Padding(4)
        Me.txtDescript.Multiline = True
        Me.txtDescript.Name = "txtDescript"
        Me.txtDescript.Size = New System.Drawing.Size(487, 73)
        Me.txtDescript.TabIndex = 3
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = Global.CAN_Inventory_db.My.Resources.Resources.horiz_divider
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(17, 53)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(487, 7)
        Me.PictureBox1.TabIndex = 67
        Me.PictureBox1.TabStop = False
        '
        'btnUpdateItem
        '
        Me.btnUpdateItem.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUpdateItem.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnUpdateItem.Location = New System.Drawing.Point(241, 521)
        Me.btnUpdateItem.Margin = New System.Windows.Forms.Padding(4)
        Me.btnUpdateItem.Name = "btnUpdateItem"
        Me.btnUpdateItem.Size = New System.Drawing.Size(135, 28)
        Me.btnUpdateItem.TabIndex = 68
        Me.btnUpdateItem.Text = "Update Base Item"
        Me.btnUpdateItem.UseVisualStyleBackColor = True
        '
        'uclBaseItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btnUpdateItem)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.grpItemMode)
        Me.Controls.Add(Me.cmbCondition)
        Me.Controls.Add(Me.lblCondition)
        Me.Controls.Add(Me.nbxInitQty)
        Me.Controls.Add(Me.lblInitQty)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.nbxLwQty)
        Me.Controls.Add(Me.lblLwQty)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.cmbSubCat)
        Me.Controls.Add(Me.cmbCategory)
        Me.Controls.Add(Me.txtDefValue)
        Me.Controls.Add(Me.txtDescript)
        Me.Controls.Add(Me.cmbProgram)
        Me.Controls.Add(Me.cmbBin)
        Me.Controls.Add(Me.cmbLocation)
        Me.Controls.Add(Me.cmbFacility)
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
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "uclBaseItem"
        Me.Size = New System.Drawing.Size(516, 572)
        CType(Me.nbxInitQty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nbxLwQty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpItemMode.ResumeLayout(False)
        Me.grpItemMode.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents nbxInitQty As NumericUpDown
    Friend WithEvents lblInitQty As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents nbxLwQty As NumericUpDown
    Friend WithEvents lblLwQty As Label
    Friend WithEvents txtName As TextBox
    Friend WithEvents cmbSubCat As ComboBox
    Friend WithEvents cmbCategory As ComboBox
    Friend WithEvents txtDefValue As TextBox
    Friend WithEvents cmbProgram As ComboBox
    Friend WithEvents cmbBin As ComboBox
    Friend WithEvents cmbLocation As ComboBox
    Friend WithEvents cmbFacility As ComboBox
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
    Friend WithEvents cmbCondition As System.Windows.Forms.ComboBox
    Friend WithEvents lblCondition As System.Windows.Forms.Label
    Friend WithEvents grpItemMode As GroupBox
    Friend WithEvents rdoItemModeEdit As RadioButton
    Friend WithEvents rdoItemModeAdd As RadioButton
    Friend WithEvents txtDescript As TextBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btnUpdateItem As Button
End Class
