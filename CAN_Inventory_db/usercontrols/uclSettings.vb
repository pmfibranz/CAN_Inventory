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

    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAddSubCat.LinkClicked
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
        If ready = True Then
            SubCatListLoad()

            txtNewSubCat.Enabled = True
            lnkAddSubCat.Enabled = True
            lbxSubCat.Enabled = True
            lnkRmvSubCat.Enabled = True
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

    Private Sub cbxFacilityL_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxFacilityL.SelectedIndexChanged
        If ready = True Then
            LocationListLoad(lbxLocations, cbxFacilityL)

            txtAddLocation.Enabled = True
            lnkAddLocation.Enabled = True
            lbxLocations.Enabled = True
            lnkRmvLocation.Enabled = True
        End If
    End Sub


    Private Sub cbxFacilityB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxFacilityB.SelectedIndexChanged
        If ready = True Then
            LocationListLoad(cbxLocationB, cbxFacilityB)
            cbxLocationB.SelectedIndex = -1
            cbxLocationB.Enabled = True

        End If
    End Sub


    'Settings Panel Load Sub
    Sub SettingsControlLoad()

        'Categories
        CategoryListLoad(lbxCategories)
        lbxCategories.SelectedIndex = -1

        CategoryListLoad(cbxCat4Sub)
        cbxCat4Sub.SelectedIndex = -1

        'Facilities

        FacilityListLoad(lbxFacilities)
        lbxFacilities.SelectedIndex = -1

        FacilityListLoad(cbxFacilityL)
        cbxFacilityL.SelectedIndex = -1

        FacilityListLoad(cbxFacilityB)
        cbxFacilityB.SelectedIndex = -1


        ready = True
    End Sub

    'Load Category Listbox
    Sub CategoryListLoad(ob As Object)
        Dim dsCat As New DataSet()
        Dim query As String

        ready = False

        'Categories
        query = frmMain.dbAccess.QueryBuilder("categories", "*", "(((categories.active)=True))")
        dsCat = frmMain.dbAccess.DataGet(query)

        ob.DataSource = dsCat.Tables(0)
        ob.ValueMember = "id"
        ob.DisplayMember = "category"

    End Sub


    'Load Sub Category Listbox
    Sub SubCatListLoad()
        Dim dsSubCat As New DataSet()
        Dim query As String
        Dim sqlCriteria As String

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
    End Sub

    'Loads Facility Listbox  ****** (So far just copy of location use to replace larger initial settings control load.
    Sub FacilityListLoad(ob As Object)
        Dim dsFacility As New DataSet()
        Dim query As String

        Try

            query = frmMain.dbAccess.QueryBuilder("facilities", "*", "(((facilities.active)=True))")
            dsFacility = frmMain.dbAccess.DataGet(query)

            ob.DataSource = dsFacility.Tables(0)
            ob.ValueMember = "id"
            ob.DisplayMember = "facility"
            'ob.SelectedIndex = -1
        Catch ex As Exception
            frmMain.lblStatus.Text = ex.Message()
        End Try
    End Sub

    'Loads Location  *************  Add parameters to handle different objects to input dataset
    Sub LocationListLoad(ob As Object, Optional from As ComboBox = Nothing)
        Dim dsLocation As New DataSet()
        Dim query As String
        Dim sqlCriteria As String

        Try
            If from Is Nothing Then
                sqlCriteria = "((locations.active)=True))"
            Else
                sqlCriteria = "(((locations.facility_id)=" + from.SelectedValue.ToString() +
                            ") AND ((locations.active)=True))"
            End If


            query = frmMain.dbAccess.QueryBuilder("locations", "*", sqlCriteria)
            dsLocation = frmMain.dbAccess.DataGet(query)

            ob.DataSource = dsLocation.Tables(0)
            ob.ValueMember = "id"
            ob.DisplayMember = "location"
            'lbxLocations.SelectedIndex = -1
        Catch ex As Exception
            frmMain.lblStatus.Text = ex.Message()
        End Try
    End Sub


End Class
