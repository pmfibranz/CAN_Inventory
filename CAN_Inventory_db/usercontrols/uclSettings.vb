﻿Public Class uclSettings
    Private Shared ready As Boolean

    Private Sub uclSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        SettingsControlLoad()

    End Sub

    'Item Categories Group ------------------------------------------------------------

    '----------------Add Button---------------------------------------------
    Private Sub lnkAddCat_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAddCat.LinkClicked
        Dim data(1) As String
        Dim catID As Integer
        Dim indexHold As Integer

        If txtNewCat.Text <> "" Then
            Try
                data(0) = "category , active "
                data(1) = "'" + txtNewCat.Text + "' , True"

                catID = frmMain.dbAccess.DataPush("categories", data)

                If catID = -1 Then
                    Throw New System.Exception("Category Creation Failure")
                End If

                'Reset Form
                txtNewCat.Text = ""
                CategoryListLoad(lbxCategories)
                lbxCategories.SelectedIndex = -1

                indexHold = cbxCat4Sub.SelectedIndex
                CategoryListLoad(cbxCat4Sub)
                cbxCat4Sub.SelectedIndex = indexHold
            Catch ex As Exception
                frmMain.lblStatus.Text = ex.Message()
            End Try

        End If

    End Sub

    '----------------Remove Selected Button---------------------------------------------
    ' + Add for removal of affiliated sub-categories
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

        CategoryListLoad(lbxCategories)
        lbxCategories.SelectedIndex = -1

    End Sub


    'Item Sub Categories Group --------------------------------------------------------

    '----------------Add Button---------------------------------------------
    Private Sub lnkAddSubCat_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAddSubCat.LinkClicked
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

            txtNewSubCat.Clear()
            SubCatListLoad()

        End If

    End Sub

    '----------------Sub Category Selection Change---------------------------------------------
    Private Sub cbxCat4Sub_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCat4Sub.SelectedIndexChanged
        If ready = True Then
            SubCatListLoad()

            txtNewSubCat.Enabled = True
            lnkAddSubCat.Enabled = True
            lbxSubCat.Enabled = True
            lnkRmvSubCat.Enabled = True
        End If

    End Sub

    '----------------Remove Selected Button---------------------------------------------
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


    'Facility Group --------------------------------------------------------

    '----------------Add Button---------------------------------------------
    Private Sub lnkAddFacility_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAddFacility.LinkClicked
        Dim data(1) As String
        Dim facID As Integer
        Dim indexHold As Integer

        If txtAddFacility.Text <> "" Then
            Try
                data(0) = "facility , address_1 , address_2 , city , state , zipcode , active "
                data(1) = "'" + txtAddFacility.Text +
                          "','" + txtFacAdd1.Text +
                          "','" + txtFacAdd2.Text +
                          "','" + txtFacCity.Text +
                          "','" + cbxFacState.Text +
                          "','" + txtFacZip.Text +
                          "' , True"

                facID = frmMain.dbAccess.DataPush("facilities", data)

                If facID = -1 Then
                    Throw New System.Exception("Facility Creation Failure")
                End If

                'Reset Form
                txtAddFacility.Clear()
                txtFacAdd1.Clear()
                txtFacAdd2.Clear()
                txtFacCity.Clear()
                cbxFacState.SelectedIndex = -1
                txtFacZip.Clear()

                FacilityListLoad(lbxFacilities)
                lbxFacilities.SelectedIndex = -1

                indexHold = cbxFacilityL.SelectedIndex
                FacilityListLoad(cbxFacilityL)
                cbxFacilityL.SelectedIndex = indexHold

                indexHold = cbxFacilityB.SelectedIndex
                FacilityListLoad(cbxFacilityB)
                cbxFacilityB.SelectedIndex = indexHold

            Catch ex As Exception
                frmMain.lblStatus.Text = ex.Message()
            End Try

        End If

    End Sub

    '----------------List Selection Changed----------------------------------
    Private Sub lbxFacilities_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbxFacilities.SelectedIndexChanged

    End Sub

    '----------------Remove Selected Button---------------------------------------------
    ' + Add for removal of affiliated Locations and bins
    Private Sub lnkRmvFacility_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkRmvFacility.LinkClicked
        Dim where(0) As String
        Dim i As Integer = 0
        Dim numSel As Integer

        numSel = lbxFacilities.SelectedItems.Count()
        ReDim Preserve where(numSel - 1)

        For Each item As DataRowView In lbxFacilities.SelectedItems

            frmMain.dbAccess.SetInactive("facilities", item(0).ToString())
            i += 1
        Next

        FacilityListLoad(lbxFacilities)
        lbxFacilities.SelectedIndex = -1
    End Sub


    'Location Group --------------------------------------------------------

    '----------------Add Button---------------------------------------------
    Private Sub lnkAddLocation_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAddLocation.LinkClicked
        Dim data(1) As String
        Dim locID As Integer
        Dim indexHold As Integer

        If txtAddLocation.Text <> "" Then

            Try
                data(0) = "location , facility_id , active "
                data(1) = "'" + txtAddLocation.Text + "' , " +
                            cbxFacilityL.SelectedValue.ToString() + ", True"

                locID = frmMain.dbAccess.DataPush("locations", data)

                If locID = -1 Then
                    Throw New System.Exception("Location Creation Failure")
                End If

                txtAddLocation.Clear()
                LocationListLoad(lbxLocations, cbxFacilityL)
                lbxLocations.SelectedIndex = -1

                indexHold = cbxLocationB.SelectedIndex
                LocationListLoad(cbxLocationB)
                cbxLocationB.SelectedIndex = indexHold

            Catch ex As Exception
                frmMain.lblStatus.Text = ex.Message()
            End Try

        End If
    End Sub

    '----------------Remove Selected Button---------------------------------------------
    ' + Add for removal of affiliated bins
    Private Sub lnkRmvLocation_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkRmvLocation.LinkClicked
        Dim where(0) As String
        Dim i As Integer = 0
        Dim numSel As Integer
        Dim indexHold As Integer

        numSel = lbxLocations.SelectedItems.Count()
        ReDim Preserve where(numSel - 1)

        For Each item As DataRowView In lbxLocations.SelectedItems

            frmMain.dbAccess.SetInactive("locations", item(0).ToString())
            i += 1
        Next

        LocationListLoad(lbxLocations, cbxFacilityL)
        lbxLocations.SelectedIndex = -1

        indexHold = cbxLocationB.SelectedIndex
        LocationListLoad(cbxLocationB)
        cbxLocationB.SelectedIndex = indexHold
    End Sub

    '----------------Facility Selection Changed---------------------------------------------
    Private Sub cbxFacilityL_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxFacilityL.SelectedIndexChanged
        If ready = True Then
            LocationListLoad(lbxLocations, cbxFacilityL)

            txtAddLocation.Enabled = True
            lnkAddLocation.Enabled = True
            lbxLocations.Enabled = True
            lnkRmvLocation.Enabled = True
            lbxLocations.SelectedIndex = -1

        End If
    End Sub


    'Bins Group --------------------------------------------------------

    '----------------Add Button---------------------------------------------
    Private Sub lnkAddBin_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAddBin.LinkClicked
        Dim data(1) As String
        Dim binID As Integer


        If txtAddBin.Text <> "" Then

            Try
                data(0) = "bin , location_id , active "
                data(1) = "'" + txtAddBin.Text + "' , " +
                            cbxLocationB.SelectedValue.ToString() + ", True"

                binID = frmMain.dbAccess.DataPush("bins", data)

                If binID = -1 Then
                    Throw New System.Exception("Bin Creation Failure")
                End If

                txtAddBin.Clear()
                BinListLoad(lbxBins, cbxLocationB)
                lbxBins.SelectedIndex = -1

            Catch ex As Exception
                frmMain.lblStatus.Text = ex.Message()
            End Try

        End If
    End Sub

    '----------------Remove Selected Button---------------------------------------------
    Private Sub lnkRmvBin_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkRmvBin.LinkClicked
        Dim where(0) As String
        Dim i As Integer = 0
        Dim numSel As Integer


        numSel = lbxBins.SelectedItems.Count()
        ReDim Preserve where(numSel - 1)

        For Each item As DataRowView In lbxBins.SelectedItems

            frmMain.dbAccess.SetInactive("bins", item(0).ToString())
            i += 1
        Next

        BinListLoad(lbxBins, cbxLocationB)
        lbxLocations.SelectedIndex = -1

    End Sub

    '----------------Facility Selection Change---------------------------------------------
    Private Sub cbxFacilityB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxFacilityB.SelectedIndexChanged
        If ready = True Then
            ready = False
            LocationListLoad(cbxLocationB, cbxFacilityB)
            cbxLocationB.SelectedIndex = -1
            cbxLocationB.Enabled = True
            ready = True
        End If
    End Sub

    '----------------Location Selection Change---------------------------------------------
    Private Sub cbxLocationB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxLocationB.SelectedIndexChanged
        If ready = True Then
            ready = False
            BinListLoad(lbxBins, cbxLocationB)

            txtAddBin.Enabled = True
            lnkAddBin.Enabled = True
            lbxBins.Enabled = True
            lnkRmvBin.Enabled = True
            lbxBins.SelectedIndex = -1
            ready = True
        End If

    End Sub



    '**************************  Additional Subs  ********************************************
    'Settings Panel Load Sub
    Sub SettingsControlLoad()
        ready = False

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

        ready = True

    End Sub


    'Load Sub Category Listbox
    Sub SubCatListLoad()
        Dim dsSubCat As New DataSet()
        Dim query As String
        Dim sqlCriteria As String

        Try
            ready = False
            sqlCriteria = "(((sub_categories.category_id)=" + cbxCat4Sub.SelectedValue.ToString() +
                            ") AND ((sub_categories.active)=True))"

            query = frmMain.dbAccess.QueryBuilder("sub_categories", "*", sqlCriteria)
            dsSubCat = frmMain.dbAccess.DataGet(query)

            lbxSubCat.DataSource = dsSubCat.Tables(0)
            lbxSubCat.ValueMember = "id"
            lbxSubCat.DisplayMember = "sub_category"

        Catch ex As Exception
            frmMain.lblStatus.Text = ex.Message()
        End Try

        ready = True
    End Sub

    'Loads Facility Listbox
    Sub FacilityListLoad(ob As Object)
        Dim dsFacility As New DataSet()
        Dim query As String

        Try
            ready = False
            query = frmMain.dbAccess.QueryBuilder("facilities", "*", "(((facilities.active)=True))")
            dsFacility = frmMain.dbAccess.DataGet(query)

            ob.DataSource = dsFacility.Tables(0)
            ob.ValueMember = "id"
            ob.DisplayMember = "facility"

        Catch ex As Exception
            frmMain.lblStatus.Text = ex.Message()
        End Try

        ready = True
    End Sub

    'Loads Location  
    Sub LocationListLoad(ob As Object, Optional from As ComboBox = Nothing)
        Dim dsLocation As New DataSet()
        Dim query As String
        Dim sqlCriteria As String

        Try
            ready = False
            If from Is Nothing Then
                sqlCriteria = "((locations.active)=True)"
            Else
                sqlCriteria = "(((locations.facility_id)=" + from.SelectedValue.ToString() +
                            ") AND ((locations.active)=True))"
            End If


            query = frmMain.dbAccess.QueryBuilder("locations", "*", sqlCriteria)
            dsLocation = frmMain.dbAccess.DataGet(query)

            ob.DataSource = dsLocation.Tables(0)
            ob.ValueMember = "id"
            ob.DisplayMember = "location"

        Catch ex As Exception
            frmMain.lblStatus.Text = ex.Message()
        End Try

        ready = True
    End Sub

    Sub BinListLoad(ob As Object, Optional from As ComboBox = Nothing)
        Dim dsBins As New DataSet()
        Dim query As String
        Dim sqlCriteria As String

        Try
            ready = False
            If from Is Nothing Then
                sqlCriteria = "((bins.active)=True)"
            Else
                sqlCriteria = "(((bins.location_id)=" + from.SelectedValue.ToString() +
                            ") AND ((bins.active)=True))"
            End If


            query = frmMain.dbAccess.QueryBuilder("bins", "*", sqlCriteria)
            dsBins = frmMain.dbAccess.DataGet(query)

            ob.DataSource = dsBins.Tables(0)
            ob.ValueMember = "id"
            ob.DisplayMember = "bin"

        Catch ex As Exception
            frmMain.lblStatus.Text = ex.Message()
        End Try

        ready = True
    End Sub


End Class
