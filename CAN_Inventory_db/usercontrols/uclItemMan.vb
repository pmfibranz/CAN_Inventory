Public Class uclItemMan
    Private bsSelectedBranch As New BindingSource()
    Private itemPnl As New uclBaseItem
    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        AddHandler uclBaseItem.RefreshItemDisp, AddressOf FillCategoryTree

    End Sub
    Private Sub uclItemMan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim itmPnlX As Double = dgvItems.Location.X + dgvItems.Size.Width - 5
        FillCategoryTree()

        dgvItems.DataSource = bsSelectedBranch
        '-------------- Item Creator ----------------

        With itemPnl
            .Name = "itemPnl"
            .Location = New Point(itmPnlX, 10)
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

    Private Sub trvBaseItemTree_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles trvBaseItemTree.AfterSelect
        'Debug.Print(trvBaseItemTree.SelectedNode.FullPath.ToString())
        Dim dsSelectedBranch As DataSet
        Dim query As String

        Select Case trvBaseItemTree.SelectedNode.Level
            Case 1
                query = "SELECT " +
                    "items.item_name AS 'Item'," +
                    "items.item_desc AS 'Item Description'," +
                    "categories.category AS 'Category'," +
                    "sub_categories.sub_category AS 'Subcategory'," +
                    "items.def_value AS 'Default Value'," +
                    "facilities.facility AS 'Default Facility'," +
                    "locations.location AS 'Location'," +
                    "bins.bin AS 'Bin'" +
                    "From programs INNER Join (bins INNER Join ((facilities INNER Join (categories INNER Join (sub_categories INNER Join items On sub_categories.id = items.sub_category_id) " +
                    "ON categories.id = sub_categories.category_id) ON facilities.id = items.def_facility_id) INNER Join locations On facilities.id = locations.facility_id) " +
                    "ON (locations.id = bins.location_id) And (bins.id = items.def_bin_id)) ON programs.id = items.def_program_id Where (((categories.category) ='" +
                    trvBaseItemTree.SelectedNode.Text + "') AND ((items.active)=True));"
                'Debug.Print(query)

            Case 2
                query = "SELECT " +
                    "items.item_name AS 'Item'," +
                    "items.item_desc AS 'Item Description'," +
                    "categories.category AS 'Category'," +
                    "sub_categories.sub_category AS 'Subcategory'," +
                    "items.def_value AS 'Default Value'," +
                    "facilities.facility AS 'Default Facility'," +
                    "locations.location AS 'Location'," +
                    "bins.bin AS 'Bin'" +
                    "From programs INNER Join (bins INNER Join ((facilities INNER Join (categories INNER Join (sub_categories INNER Join items On sub_categories.id = items.sub_category_id) " +
                    "ON categories.id = sub_categories.category_id) ON facilities.id = items.def_facility_id) INNER Join locations On facilities.id = locations.facility_id) " +
                    "ON (locations.id = bins.location_id) And (bins.id = items.def_bin_id)) ON programs.id = items.def_program_id Where (((sub_categories.sub_category) ='" +
                    trvBaseItemTree.SelectedNode.Text + "') AND ((items.active)=True));"
            Case Else
                query = "SELECT " +
                    "items.item_name AS 'Item'," +
                    "items.item_desc AS 'Item Description'," +
                    "categories.category AS 'Category'," +
                    "sub_categories.sub_category AS 'Subcategory'," +
                    "items.def_value AS 'Default Value'," +
                    "facilities.facility AS 'Default Facility'," +
                    "locations.location AS 'Location'," +
                    "bins.bin AS 'Bin'" +
                    "From programs INNER Join (bins INNER Join ((facilities INNER Join (categories INNER Join (sub_categories INNER Join items On sub_categories.id = items.sub_category_id) " +
                    "ON categories.id = sub_categories.category_id) ON facilities.id = items.def_facility_id) INNER Join locations On facilities.id = locations.facility_id) " +
                    "ON (locations.id = bins.location_id) And (bins.id = items.def_bin_id)) ON programs.id = items.def_program_id WHERE ((items.active)=True);"

        End Select

        dsSelectedBranch = frmMain.dbAccess.DataGet(query)
        bsSelectedBranch.DataSource = dsSelectedBranch.Tables(0)
        With dgvItems
            .ReadOnly = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .RowHeadersVisible = False
            .DataSource = bsSelectedBranch
            .AutoResizeColumns()
            .Columns.Item(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End With

    End Sub

    Private Sub dgvItems_SelectionChanged(sender As Object, e As EventArgs) Handles dgvItems.SelectionChanged
        Dim itemID As String = dgvItems.SelectedRows.Item(0).Cells.Item(0).Value

        itemPnl.FillWith(itemID)
    End Sub
End Class
