﻿Public Class uclItemMan
    Private bsSelectedBranch As New BindingSource()
    Private itemPnl As New uclBaseItem
    Private ready As Boolean = False

    Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        AddHandler uclBaseItem.RefreshItemDisp, AddressOf FillCategoryTree
        AddHandler uclBaseItem.RefreshExistingItemGrid, AddressOf fillExistingItemGrid
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
            ' .nbxInitQty.Visible = False
            ' .lblInitQty.Visible = False
        End With

        Me.Controls.Add(itemPnl)
    End Sub

    Sub FillCategoryTree()
        Dim query As String
        Dim dsCat As New DataSet()
        Dim dsSubCat As New DataSet()
        Dim where As String

        query = frmMain.dbAccess.QueryBuilder("categories", "*", "categories.active=True", "SELECT")
        dsCat = frmMain.dbAccess.DataGet(query)

        For Each cat As DataRow In dsCat.Tables(0).Rows
            trvBaseItemTree.Nodes.Item(0).Nodes.Add(cat(0).ToString, cat(1).ToString)

            where = "sub_categories.active=True AND sub_categories.category_id=" & cat(0).ToString()

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

    Private Sub fillExistingItemGrid()
        Dim dsSelectedBranch As DataSet
        Dim query As String
        Dim invColumn As New DataColumn()
        Dim dsInvQtyIn As DataSet
        Dim dsInvQtyOut As DataSet
        Dim qtyIn As Integer
        Dim qytOut As Integer
        Dim itemID As Integer

        ready = False

        'Proceed only if a treeview node was selected
        If Not trvBaseItemTree.SelectedNode Is Nothing Then
            query = "SELECT " &
                    "items.id AS [ItemID]," &
                    "items.item_name AS [Item]," &
                    "items.item_desc AS [Description]," &
                    "categories.category AS [Category]," &
                    "sub_categories.sub_category AS [Subcategory]," &
                    "items.def_value AS [Default Value]," &
                    "facilities.facility AS [Facility]," &
                    "locations.location AS [Location]," &
                    "bins.bin AS [Bin]," &
                    "programs.program as [Program] " &
                    "From programs INNER Join (bins INNER Join ((facilities INNER Join (categories INNER Join (sub_categories INNER Join items On sub_categories.id = items.sub_category_id) " &
                    "ON categories.id = sub_categories.category_id) ON facilities.id = items.def_facility_id) INNER Join locations On facilities.id = locations.facility_id) " &
                    "ON (locations.id = bins.location_id) And (bins.id = items.def_bin_id)) ON programs.id = items.def_program_id "

            Select Case trvBaseItemTree.SelectedNode.Level
                Case 1
                    query = query + "WHERE categories.category ='" + trvBaseItemTree.SelectedNode.Text + "' AND items.active=True;"
                Case 2
                    query = query + "WHERE sub_categories.sub_category ='" + trvBaseItemTree.SelectedNode.Text + "' AND items.active=True;"
                Case Else
                    query = query + "WHERE items.active=True;"

            End Select

            dsSelectedBranch = frmMain.dbAccess.DataGet(query)
            dsSelectedBranch.Tables(0).Columns.Add(invColumn)
            invColumn.ColumnName = "On Hand"

            For Each row As DataRow In dsSelectedBranch.Tables(0).Rows
                itemID = CLng(row.Item("ItemID").ToString)

                dsInvQtyIn = frmMain.dbAccess.DataStoredProcGetQuantityIn(itemID)
                dsInvQtyOut = frmMain.dbAccess.DataStoredProcGetQuantityOut(itemID)

                If dsInvQtyIn.Tables.Count > 0 Then
                    qtyIn = dsInvQtyIn.Tables(0).Rows(0).Item("qtyIn")
                Else
                    qtyIn = 0
                End If

                If dsInvQtyOut.Tables.Count > 0 Then
                    qytOut = dsInvQtyOut.Tables(0).Rows(0).Item("qtyOut")
                Else
                    qytOut = 0
                End If

                row.Item(invColumn) = (qtyIn - qytOut).ToString
                dsInvQtyIn.Clear()
                dsInvQtyOut.Clear()
            Next

            bsSelectedBranch.DataSource = dsSelectedBranch.Tables(0)

            With dgvItems
                .Columns.Item("ItemID").Visible = False
                .ReadOnly = True
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .RowHeadersVisible = False
                .DataSource = bsSelectedBranch
                .AutoResizeColumns()
                .AllowUserToAddRows = False
                .AllowUserToDeleteRows = False
                .AllowUserToResizeRows = False
                .ClearSelection()
            End With
        End If

        ready = True
    End Sub

    Private Sub trvBaseItemTree_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles trvBaseItemTree.AfterSelect
        Call fillExistingItemGrid()
    End Sub

    Private Sub dgvItems_SelectionChanged(sender As Object, e As EventArgs) Handles dgvItems.SelectionChanged
        If ready = True And dgvItems.RowCount > 0 Then
            itemPnl.FillWith(dgvItems.CurrentRow.DataBoundItem)
        End If
    End Sub
End Class
