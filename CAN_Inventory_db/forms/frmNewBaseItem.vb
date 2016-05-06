Imports System.IO
Imports System.Text

Public Class frmNewBaseItem
    Private Shared ready As Boolean

    Private Sub frmNewBaseItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim ds As New DataSet()
        Dim query As String

        ready = False
        query = frmMain.dbAccess.QueryBuilder("categories", "*", "(((categories.active)=True))")

        ds = frmMain.dbAccess.DataGet(query)

        cbxCategory.DataSource = ds.Tables(0)
        cbxCategory.ValueMember = "id"
        cbxCategory.DisplayMember = "category"
        cbxCategory.SelectedIndex = -1              ' Sets default selected item to empty
        ready = True

    End Sub

    Private Sub btnAddItem_Click(sender As Object, e As EventArgs) Handles btnAddItem.Click
        If txtName.Text = "" Or cbxCategory.SelectedItem = "" Or cbxSubCat.SelectedItem = "" Then
            ' Requires Item Name, Category, and Sub-Category
            ' other fields can be added at a later time
            lblStatus.Text = "Required Information Missing!"
            If txtName.Text = "" Then
                lblName.ForeColor = Color.Red
            End If
            If cbxCategory.SelectedItem = "" Then
                lblCategory.ForeColor = Color.Red
            End If
            If cbxSubCat.SelectedItem = "" Then
                lblSubCat.ForeColor = Color.Red
            End If
        Else
            Dim data(1) As String
            data(0) = "items.item_name , items.item_desc , items.def_value , items.unit_count , " +
                "items.low_qty , items.times_accessed , items.active , "
            data(1) = "'" + txtName.Text + "' , '" + txtDescript.Text + "' , '" + txtDefValue.Text + "' , '" +
                nbxInitQty.Text + "' , '" + nbxLwQty.Value + "' , 0 , True"
            If frmMain.dbAccess.DataPush("items", data) = False Then
                lblStatus.Text = "Item Creation Failure"
            End If

        End If
    End Sub


    Private Sub cbxCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCategory.SelectedIndexChanged
        Try
            If ready = True Then
                If cbxCategory.SelectedValue = -1 Then
                    cbxSubCat.Enabled = False
                Else
                    Dim ds As New DataSet()
                    Dim query As String
                    Dim sqlCriteria As String
                    ready = False

                    sqlCriteria = "(((sub_categories.category_id)=" + cbxCategory.SelectedValue.ToString() +
                        ") AND ((sub_categories.active)=True))"

                    query = frmMain.dbAccess.QueryBuilder("sub_categories", "*", sqlCriteria)

                    ds = frmMain.dbAccess.DataGet(query)
                    cbxSubCat.DataSource = ds.Tables(0)
                    cbxSubCat.ValueMember = "id"
                    cbxSubCat.DisplayMember = "sub_category"
                    cbxSubCat.SelectedIndex = -1              ' Sets default selected item to empty
                    cbxSubCat.Enabled = True
                    ready = True
                End If
            End If


        Catch ex As Exception

        End Try
    End Sub
End Class