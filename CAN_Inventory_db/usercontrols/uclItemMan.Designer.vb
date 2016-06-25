<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uclItemMan
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("All Categories")
        Me.DataGridView5 = New System.Windows.Forms.DataGridView()
        Me.trvBaseItemTree = New System.Windows.Forms.TreeView()
        CType(Me.DataGridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView5
        '
        Me.DataGridView5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView5.Location = New System.Drawing.Point(194, 12)
        Me.DataGridView5.Name = "DataGridView5"
        Me.DataGridView5.Size = New System.Drawing.Size(514, 569)
        Me.DataGridView5.TabIndex = 10
        '
        'trvBaseItemTree
        '
        Me.trvBaseItemTree.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.trvBaseItemTree.Location = New System.Drawing.Point(11, 12)
        Me.trvBaseItemTree.Name = "trvBaseItemTree"
        TreeNode1.Name = "allCat"
        TreeNode1.Text = "All Categories"
        Me.trvBaseItemTree.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1})
        Me.trvBaseItemTree.Size = New System.Drawing.Size(177, 569)
        Me.trvBaseItemTree.TabIndex = 9
        '
        'uclItemMan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.DataGridView5)
        Me.Controls.Add(Me.trvBaseItemTree)
        Me.Name = "uclItemMan"
        Me.Size = New System.Drawing.Size(1089, 601)
        CType(Me.DataGridView5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DataGridView5 As DataGridView
    Friend WithEvents trvBaseItemTree As TreeView
End Class
