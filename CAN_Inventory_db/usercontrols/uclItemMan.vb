Public Class uclItemMan

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        AddHandler uclBaseItem.RefreshItemDisp, AddressOf FillCategoryTree

    End Sub
    Private Sub uclItemMan_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        FillCategoryTree()


        '-------------- Item Creator ----------------
        Dim itemPnl As New uclBaseItem
        With itemPnl
            .Name = "itemPnl"
            .Location = New Point(972, 10)
            .Anchor = AnchorStyles.Right Or AnchorStyles.Top
        End With

        Me.Controls.Add(itemPnl)
    End Sub

    'Private Sub itemPnl_RefeshItemDisp(sender As Object, ByVal e As System.EventArgs) Handles RefreshItemDisp

    'End Sub

    Sub FillCategoryTree()
        Dim query As String
        Dim dsCat As New DataSet()


        query = frmMain.dbAccess.QueryBuilder("categories", "*", "categories.active=True", "SELECT")
        dsCat = frmMain.dbAccess.DataGet(query)
        For Each cat As DataRow In dsCat.Tables(0).Rows
            trvBaseItemTree.Nodes.Item(0).Nodes.Add(cat(0).ToString, cat(1).ToString)

            Dim dsSubCat As New DataSet()
            Dim where As String = "(sub_categories.active=True) AND (sub_categories.category_id=" +
                cat(0).ToString() + ")"

            query = frmMain.dbAccess.QueryBuilder("sub_categories", "*", where, "SELECT")
            dsSubCat = frmMain.dbAccess.DataGet(query)

            For Each subCat As DataRow In dsSubCat.Tables(0).Rows
                trvBaseItemTree.Nodes.Item(0).Nodes.Item(cat(0).ToString).Nodes.Add(subCat(0).ToString, subCat(1).ToString)
            Next

        Next
        trvBaseItemTree.Nodes.Item(0).Expand()

        'trvBaseItemTree.Nodes.Add()
        'trvBaseItemTree.Nodes.Item().Nodes.Add()

    End Sub


End Class
