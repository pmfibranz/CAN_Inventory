Public Class frmNewBaseItem
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

    Private Sub frmNewBaseItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class