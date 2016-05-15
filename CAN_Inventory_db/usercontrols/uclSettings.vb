Public Class uclSettings
    Private Shared ready As Boolean

    Private Sub uclSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        SettingsControlLoad()

    End Sub

    Private Sub lnkAddCat_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAddCat.LinkClicked
        Dim data(1) As String
        Dim catID As Integer

        If txtNewCat.Text <> "" Then
            Try
                data(0) = "category , active "
                data(1) = "'" + txtNewCat.Text + "' , True"

                catID = frmMain.dbAccess.DataPush("categories", data)

                If catID = -1 Then
                    Throw New System.Exception("Category Creation Failure")
                End If

                txtNewCat.Text = ""
                SettingsControlLoad()
            Catch ex As Exception
                frmMain.lblStatus.Text = ex.Message()
            End Try

        End If

    End Sub

    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        Dim data(1) As String
        Dim subCatID As Integer

        If txtNewSubCat.Text <> "" Then
            Try
                data(0) = "sub_category , category_id , active "
                data(1) = "'" + txtNewSubCat.Text + "' , " +
                            cbxCat4Sub.SelectedValue.ToString() + ", True"

                subCatID = frmMain.dbAccess.DataPush("sub_categories", data)

                If subCatID = -1 Then
                    Throw New System.Exception("Sub-Category Creation Failure")
                End If
            Catch ex As Exception
                frmMain.lblStatus.Text = ex.Message()
            End Try

            txtNewSubCat.Text = ""
            SubCatListLoad()

        End If

    End Sub

    Private Sub cbxCat4Sub_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCat4Sub.SelectedIndexChanged

        SubCatListLoad()

    End Sub

    'Settings Panel Load Sub
    Sub SettingsControlLoad()
        Dim dsCat As New DataSet()
        Dim dsCat2 As New DataSet()
        Dim query As String

        ready = False


        query = frmMain.dbAccess.QueryBuilder("categories", "*", "(((categories.active)=True))")
        dsCat = frmMain.dbAccess.DataGet(query)

        lbxCategories.DataSource = dsCat.Tables(0)
        lbxCategories.ValueMember = "id"
        lbxCategories.DisplayMember = "category"
        lbxCategories.SelectedIndex = -1

        dsCat2 = dsCat.Copy()

        cbxCat4Sub.DataSource = dsCat2.Tables(0)
        cbxCat4Sub.ValueMember = "id"
        cbxCat4Sub.DisplayMember = "category"
        cbxCat4Sub.SelectedIndex = -1

        ready = True
    End Sub

    Sub SubCatListLoad()
        Dim dsSubCat As New DataSet()
        Dim query As String
        Dim sqlCriteria As String
        If ready = True Then
            Try
                sqlCriteria = "(((sub_categories.category_id)=" + cbxCat4Sub.SelectedValue.ToString() +
                            ") AND ((sub_categories.active)=True))"

                query = frmMain.dbAccess.QueryBuilder("sub_categories", "*", sqlCriteria)
                dsSubCat = frmMain.dbAccess.DataGet(query)

                lbxSubCat.DataSource = dsSubCat.Tables(0)
                lbxSubCat.ValueMember = "id"
                lbxSubCat.DisplayMember = "sub_category"
                'lbxSubCat.SelectedIndex = -1
            Catch ex As Exception
                frmMain.lblStatus.Text = ex.Message()
            End Try
        End If
    End Sub

    Private Sub lnkRmvCat_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkRmvCat.LinkClicked
        Dim where(0) As String
        Dim i As Integer = 0
        Dim numSel As Integer

        numSel = lbxCategories.SelectedItems.Count()
        ReDim Preserve where(numSel - 1)

        For Each item As DataRowView In lbxCategories.SelectedItems

            frmMain.dbAccess.SetInactive("categories", item(0).ToString())
            i += 1
        Next

        SettingsControlLoad()

    End Sub

    Private Sub lnkRmvSubCat_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkRmvSubCat.LinkClicked
        Dim where(0) As String
        Dim i As Integer = 0
        Dim numSel As Integer

        numSel = lbxSubCat.SelectedItems.Count()
        ReDim Preserve where(numSel - 1)

        For Each item As DataRowView In lbxSubCat.SelectedItems

            frmMain.dbAccess.SetInactive("sub_categories", item(0).ToString())
            i += 1
        Next

        SubCatListLoad()
    End Sub
End Class
