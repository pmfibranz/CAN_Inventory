Public Class uclSettings
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

        If txtCategory.Text <> "" Then
            Try
                data(0) = "category , active "
                data(1) = "'" + txtCategory.Text + "' , True"

                catID = frmMain.dbAccess.DataPush("categories", data)

                If catID = -1 Then
                    Throw New System.Exception("Category Creation Failure")
                End If

                'Reset Form
                txtCategory.Clear()
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

    '----------------Update Button---------------------------------------------
    Private Sub lnkUpdateCat_Click(sender As Object, e As EventArgs) Handles lnkUpdateCat.Click
        Dim query As String
        Dim setVal As String
        Dim catid As String
        Dim indexHold As Integer

        setVal = "category='" + txtCategory.Text + "'"
        catid = lbxCategories.SelectedValue.ToString

        Try
            query = frmMain.dbAccess.QueryBuilder("categories", setVal, catid, "UPDATE")
            frmMain.dbAccess.PassUpdate(query)

            'Reset Form
            txtCategory.Clear()

            CategoryListLoad(lbxCategories)
            lbxCategories.SelectedIndex = -1
            lnkUpdateCat.Visible = False
            lnkAddCat.Visible = True

            indexHold = cbxCat4Sub.SelectedIndex
            CategoryListLoad(cbxCat4Sub)
            cbxCat4Sub.SelectedIndex = indexHold

        Catch ex As Exception
            frmMain.lblStatus.Text = ex.Message()
        End Try
    End Sub

    '----------------Reset Button---------------------------------------------
    Private Sub lnkResetCat_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkResetCat.LinkClicked
        If ready = True Then
            txtCategory.Clear()
            lnkUpdateCat.Visible = False
            lnkResetCat.Visible = False
            lnkAddCat.Visible = True
        End If
    End Sub

    '----------------Selection Change is a Reset---------------------------------------------
    Private Sub lbxCategories_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbxCategories.SelectedIndexChanged
        If ready = True And lbxCategories.SelectedIndex > -1 Then
            txtCategory.Clear()
            lnkUpdateCat.Visible = False
            lnkResetCat.Visible = False
            lnkAddCat.Visible = True
        End If
    End Sub

    '----------------Selecting Category for Editing ---------------------------------------------
    Private Sub lbxCategories_DoubleClick(sender As Object, e As EventArgs) Handles lbxCategories.DoubleClick
        If ready = True And lbxCategories.SelectedIndex > -1 Then
            lnkAddCat.Visible = False
            lnkUpdateCat.Visible = True
            lnkResetCat.Visible = True
            txtCategory.Text = lbxCategories.Text
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

        If txtSubCategory.Text <> "" Then
            Try
                data(0) = "sub_category , category_id , active "
                data(1) = "'" + txtSubCategory.Text + "' , " +
                            cbxCat4Sub.SelectedValue.ToString() + ", True"

                subCatID = frmMain.dbAccess.DataPush("sub_categories", data)

                If subCatID = -1 Then
                    Throw New System.Exception("Sub-Category Creation Failure")
                End If
            Catch ex As Exception
                frmMain.lblStatus.Text = ex.Message()
            End Try

            txtSubCategory.Clear()
            SubCatListLoad()
        End If
    End Sub

    '----------------Sub Category Selection Change---------------------------------------------
    Private Sub cbxCat4Sub_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCat4Sub.SelectedIndexChanged
        If ready = True And cbxCat4Sub.SelectedIndex > -1 Then
            txtSubCategory.Clear()
            SubCatListLoad()

            txtSubCategory.Enabled = True
            lnkAddSubCat.Enabled = True
            lbxSubCat.Enabled = True
            lnkRmvSubCat.Enabled = True
            lnkAddSubCat.Visible = True
            lnkUpdateSubCat.Visible = False
            lnkResetSubCat.Visible = False
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

    '----------------Update Button---------------------------------------------
    Private Sub lnkUpdateSub_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkUpdateSubCat.LinkClicked
        Dim query As String
        Dim setVal As String
        Dim subCatID As String

        setVal = "sub_category='" + txtSubCategory.Text + "'"
        subCatID = lbxSubCat.SelectedValue.ToString

        Try
            query = frmMain.dbAccess.QueryBuilder("sub_categories", setVal, subCatID, "UPDATE")
            frmMain.dbAccess.PassUpdate(query)

            'Reset Form
            txtSubCategory.Clear()

            SubCatListLoad()
            lbxSubCat.SelectedIndex = -1
            lnkUpdateSubCat.Visible = False
            lnkResetSubCat.Visible = False
            lnkAddSubCat.Visible = True

        Catch ex As Exception
            frmMain.lblStatus.Text = ex.Message()
        End Try
    End Sub

    '----------------Reset Button---------------------------------------------
    Private Sub lnkResetSubCat_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkResetSubCat.LinkClicked
        If ready = True Then
            txtSubCategory.Clear()
            lnkUpdateSubCat.Visible = False
            lnkResetSubCat.Visible = False
            lnkAddSubCat.Visible = True
        End If
    End Sub

    '----------------Selecting SubCat for Editing ---------------------------------------------
    Private Sub lbxSubCat_DoubleClick(sender As Object, e As EventArgs) Handles lbxSubCat.DoubleClick
        If ready = True And lbxSubCat.SelectedIndex > -1 Then
            lnkAddSubCat.Visible = False
            lnkUpdateSubCat.Visible = True
            lnkResetSubCat.Visible = True
            txtSubCategory.Text = lbxSubCat.Text
        End If
    End Sub

    '----------------Reset for New SubCat Based On Selection Change---------------------------------------------
    Private Sub lbxSubCat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbxSubCat.SelectedIndexChanged
        If ready = True And lbxSubCat.SelectedIndex > -1 Then
            lnkAddSubCat.Visible = True
            lnkUpdateSubCat.Visible = False
            lnkResetSubCat.Visible = False
            txtSubCategory.Clear()
        End If
    End Sub

    'Facility Group --------------------------------------------------------

    '----------------Add Button---------------------------------------------
    Private Sub lnkAddFacility_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAddFacility.LinkClicked
        Dim data(1) As String
        Dim facID As Integer
        Dim indexHold As Integer

        If txtFacName.Text <> "" Then
            Try
                data(0) = "facility , address_1 , address_2 , city , state , zipcode , active "
                data(1) = "'" + txtFacName.Text +
                          "','" + txtFacAdd1.Text +
                          "','" + txtFacAdd2.Text +
                          "','" + txtFacCity.Text +
                          "','" + txtFacState.Text +
                          "','" + txtFacZip.Text +
                          "' , True"

                facID = frmMain.dbAccess.DataPush("facilities", data)

                If facID = -1 Then
                    Throw New System.Exception("Facility Creation Failure")
                End If

                'Reset Form
                txtFacName.Clear()
                txtFacAdd1.Clear()
                txtFacAdd2.Clear()
                txtFacCity.Clear()
                txtFacState.Clear()
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

    '----------------Load Facility for Editing----------------------------------
    Private Sub lbxFacilities_DoubleClick(sender As Object, e As EventArgs) Handles lbxFacilities.DoubleClick
        If ready = True And lbxFacilities.SelectedIndex > -1 Then
            Dim fid As String
            Dim dsFac As New DataSet()
            Dim query As String

            Try
                ready = False
                fid = lbxFacilities.SelectedValue.ToString

                query = frmMain.dbAccess.QueryBuilder("facilities", "*", "id=" + fid + " AND active=True")
                dsFac = frmMain.dbAccess.DataGet(query)

                txtFacName.Text = dsFac.Tables(0).Rows(0).Item("facility").ToString
                txtFacAdd1.Text = dsFac.Tables(0).Rows(0).Item("address_1").ToString
                txtFacAdd2.Text = dsFac.Tables(0).Rows(0).Item("address_2").ToString
                txtFacCity.Text = dsFac.Tables(0).Rows(0).Item("city").ToString
                If Trim(dsFac.Tables(0).Rows(0).Item("state").ToString()).Length > 0 Then
                    txtFacState.Text = dsFac.Tables(0).Rows(0).Item("state").ToString
                Else
                    txtFacState.Text = "MI"
                End If
                txtFacZip.Text = dsFac.Tables(0).Rows(0).Item("zipcode").ToString

                lnkUpdateFacility.Visible = True
                lnkResetFacility.Visible = True
                lnkAddFacility.Visible = False
            Catch ex As Exception
                frmMain.lblStatus.Text = ex.Message()
            End Try

            ready = True
        End If
    End Sub

    '----------------Reset for New Facility Based On Selection Change---------------------------------------------
    Private Sub lbxFacilities_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles lbxFacilities.SelectedIndexChanged
        If ready = True And lbxFacilities.SelectedIndex > -1 Then
            txtFacName.Clear()
            txtFacAdd1.Clear()
            txtFacAdd2.Clear()
            txtFacCity.Clear()
            txtFacState.Text = "MI"
            txtFacZip.Clear()
            lnkAddFacility.Visible = True
            lnkUpdateFacility.Visible = False
            lnkResetFacility.Visible = False
        End If
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

    '----------------Update Button---------------------------------------------
    Private Sub lnkUpdateFacility_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkUpdateFacility.LinkClicked
        Dim query As String
        Dim data As String
        Dim fID As String
        Dim indexHold As Integer

        data = "facility='" + txtFacName.Text + "',address_1='" + txtFacAdd1.Text + "', address_2='" + txtFacAdd2.Text + "', city='" + txtFacCity.Text + "', state='" + txtFacState.Text + "', zipcode='" + txtFacZip.Text + "'"
        fID = lbxFacilities.SelectedValue.ToString

        Try
            query = frmMain.dbAccess.QueryBuilder("facilities", data, fID, "UPDATE")
            frmMain.dbAccess.PassUpdate(query)

            'Reset Form
            txtFacName.Clear()
            txtFacAdd1.Clear()
            txtFacAdd2.Clear()
            txtFacCity.Clear()
            txtFacState.Clear()
            txtFacZip.Clear()
            lnkUpdateFacility.Visible = False
            lnkResetFacility.Visible = False
            lnkAddFacility.Visible = True

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
    End Sub

    'Location Group --------------------------------------------------------

    '----------------Add Button---------------------------------------------
    Private Sub lnkAddLocation_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAddLocation.LinkClicked
        Dim data(1) As String
        Dim locID As Integer
        Dim indexHold As Integer

        If txtLocation.Text <> "" Then
            Try
                data(0) = "location , facility_id , active "
                data(1) = "'" + txtLocation.Text + "' , " +
                            cbxFacilityL.SelectedValue.ToString() + ", True"

                locID = frmMain.dbAccess.DataPush("locations", data)

                If locID = -1 Then
                    Throw New System.Exception("Location Creation Failure")
                End If

                txtLocation.Clear()
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

    '----------------Update Button---------------------------------------------
    Private Sub lnkUpdateLocation_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkUpdateLocation.LinkClicked
        Dim query As String
        Dim setVal As String
        Dim locID As String
        Dim indexHold As Integer

        setVal = "location='" + txtLocation.Text + "'"
        locID = lbxLocations.SelectedValue.ToString

        Try
            query = frmMain.dbAccess.QueryBuilder("locations", setVal, locID, "UPDATE")
            frmMain.dbAccess.PassUpdate(query)

            'Reset Form
            txtLocation.Clear()

            LocationListLoad(lbxLocations, cbxFacilityL)
            lbxLocations.SelectedIndex = -1

            indexHold = cbxLocationB.SelectedIndex
            LocationListLoad(cbxLocationB)
            cbxLocationB.SelectedIndex = indexHold

            lnkUpdateLocation.Visible = False
            lnkResetLocation.Visible = False
            lnkAddLocation.Visible = True
        Catch ex As Exception
            frmMain.lblStatus.Text = ex.Message()
        End Try
    End Sub

    '----------------Reset Button---------------------------------------------
    Private Sub lnkResetLocation_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkResetLocation.LinkClicked
        If ready = True And lbxLocations.SelectedIndex > -1 Then
            txtLocation.Clear()
            lnkAddLocation.Visible = True
            lnkUpdateLocation.Visible = False
            lnkResetLocation.Visible = False
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
        If ready = True And cbxFacilityL.SelectedIndex > -1 Then
            LocationListLoad(lbxLocations, cbxFacilityL)

            txtLocation.Enabled = True
            lnkAddLocation.Enabled = True
            lnkUpdateLocation.Visible = False
            lnkResetLocation.Visible = False
            lnkAddLocation.Visible = True
            lbxLocations.Enabled = True
            lnkRmvLocation.Enabled = True
            lbxLocations.SelectedIndex = -1
            txtLocation.Clear()
        End If
    End Sub

    '----------------Location Selection Change---------------------------------------------
    Private Sub lbxLocations_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbxLocations.SelectedIndexChanged
        If ready = True And lbxLocations.SelectedIndex > -1 Then
            txtLocation.Clear()
            lnkUpdateLocation.Visible = False
            lnkResetLocation.Visible = False
            lnkAddLocation.Visible = True
        End If
    End Sub

    '----------------Selecting Location for Editing ---------------------------------------------
    Private Sub lbxLocations_DoubleClick(sender As Object, e As EventArgs) Handles lbxLocations.DoubleClick
        If ready = True And lbxLocations.SelectedIndex > -1 Then
            lnkAddLocation.Visible = False
            lnkUpdateLocation.Visible = True
            lnkResetLocation.Visible = True
            txtLocation.Text = lbxLocations.Text
        End If
    End Sub

    'Bins Group --------------------------------------------------------

    '----------------Add Button---------------------------------------------
    Private Sub lnkAddBin_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAddBin.LinkClicked
        Dim data(1) As String
        Dim binID As Integer

        If txtBin.Text <> "" Then
            Try
                data(0) = "bin , location_id , active "
                data(1) = "'" + txtBin.Text + "' , " +
                            cbxLocationB.SelectedValue.ToString() + ", True"

                binID = frmMain.dbAccess.DataPush("bins", data)

                If binID = -1 Then
                    Throw New System.Exception("Bin Creation Failure")
                End If

                txtBin.Clear()
                BinListLoad(lbxBins, cbxLocationB)
                lbxBins.SelectedIndex = -1
            Catch ex As Exception
                frmMain.lblStatus.Text = ex.Message()
            End Try
        End If
    End Sub

    '----------------Update Button---------------------------------------------
    Private Sub lnkUpdateBin_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkUpdateBin.LinkClicked
        Dim query As String
        Dim setVal As String
        Dim binID As String

        setVal = "bin='" + txtBin.Text + "'"
        binID = lbxBins.SelectedValue.ToString

        Try
            query = frmMain.dbAccess.QueryBuilder("bins", setVal, binID, "UPDATE")
            frmMain.dbAccess.PassUpdate(query)

            'Reset Form
            txtBin.Clear()

            BinListLoad(lbxBins, cbxLocationB)
            lbxBins.SelectedIndex = -1

            lnkUpdateBin.Visible = False
            lnkResetBin.Visible = False
            lnkAddBin.Visible = True
        Catch ex As Exception
            frmMain.lblStatus.Text = ex.Message()
        End Try
    End Sub

    '----------------Reset Button---------------------------------------------
    Private Sub lnkResetBin_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkResetBin.LinkClicked
        If ready = True And lbxBins.SelectedIndex > -1 Then
            txtBin.Clear()
            lnkUpdateBin.Visible = False
            lnkResetBin.Visible = False
            lnkAddBin.Visible = True
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
        If ready = True And cbxFacilityB.SelectedIndex > -1 Then
            ready = False
            LocationListLoad(cbxLocationB, cbxFacilityB)
            cbxLocationB.SelectedIndex = -1
            cbxLocationB.Enabled = True
            txtBin.Enabled = False
            txtBin.Clear()
            lnkUpdateBin.Visible = False
            lnkResetBin.Visible = False
            lnkAddBin.Enabled = False
            lnkAddBin.Visible = True
            lbxBins.Enabled = False
            lbxBins.DataSource = Nothing
            ready = True
        End If
    End Sub

    '----------------Location Selection Change---------------------------------------------
    Private Sub cbxLocationB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxLocationB.SelectedIndexChanged
        If ready = True And cbxLocationB.SelectedIndex > -1 Then
            ready = False
            BinListLoad(lbxBins, cbxLocationB)

            txtBin.Enabled = True
            txtBin.Clear()
            lnkAddBin.Enabled = True
            lnkAddBin.Visible = True
            lnkUpdateBin.Visible = False
            lnkResetBin.Visible = False
            lbxBins.Enabled = True
            lnkRmvBin.Enabled = True
            lbxBins.SelectedIndex = -1
            ready = True
        End If
    End Sub

    '----------------Bin Selection Change---------------------------------------------
    Private Sub lbxBins_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbxBins.SelectedIndexChanged
        If ready = True And lbxBins.SelectedIndex > -1 Then
            txtBin.Clear()
            lnkUpdateBin.Visible = False
            lnkResetBin.Visible = False
            lnkAddBin.Visible = True
        End If
    End Sub

    '----------------Selecting Bin for Editing ---------------------------------------------
    Private Sub lbxBins_DoubleClick(sender As Object, e As EventArgs) Handles lbxBins.DoubleClick
        If ready = True And lbxBins.SelectedIndex > -1 Then
            lnkAddBin.Visible = False
            lnkUpdateBin.Visible = True
            lnkResetBin.Visible = True
            txtBin.Text = lbxBins.Text
        End If
    End Sub

    'Conditions Group --------------------------------------------------------

    '----------------Add Button---------------------------------------------
    Private Sub lnkAddCondition_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAddCondition.LinkClicked
        Dim data(1) As String
        Dim condID As Integer

        If txtCondition.Text <> "" Then
            Try
                data(0) = "condition , active "
                data(1) = "'" + txtCondition.Text + "' , True"

                condID = frmMain.dbAccess.DataPush("conditions", data)

                If condID = -1 Then
                    Throw New System.Exception("Condition Creation Failure")
                End If

                'Reset Form
                txtCondition.Clear()

                ConditionListLoad(lbxConditions)
                lbxConditions.SelectedIndex = -1

            Catch ex As Exception
                frmMain.lblStatus.Text = ex.Message()
            End Try
        End If
    End Sub

    '----------------Update Button---------------------------------------------
    Private Sub lnkUpdateCondition_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkUpdateCondition.LinkClicked
        Dim query As String
        Dim setVal As String
        Dim conID As String

        setVal = "condition='" + txtCondition.Text + "'"
        conID = lbxConditions.SelectedValue.ToString

        Try
            query = frmMain.dbAccess.QueryBuilder("conditions", setVal, conID, "UPDATE")
            frmMain.dbAccess.PassUpdate(query)

            'Reset Form
            txtCondition.Clear()

            ConditionListLoad(lbxConditions)
            lbxConditions.SelectedIndex = -1

            lnkUpdateCondition.Visible = False
            lnkResetCondition.Visible = False
            lnkAddCondition.Visible = True
        Catch ex As Exception
            frmMain.lblStatus.Text = ex.Message()
        End Try
    End Sub

    '----------------Reset Button---------------------------------------------
    Private Sub lnkResetCondition_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkResetCondition.LinkClicked
        If ready = True And lbxConditions.SelectedIndex > -1 Then
            txtCondition.Clear()
            lnkUpdateCondition.Visible = False
            lnkResetCondition.Visible = False
            lnkAddCondition.Visible = True
        End If
    End Sub

    '----------------Remove Selected Button---------------------------------------------
    Private Sub lnkRmvCondtion_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkRmvCondtion.LinkClicked
        Dim where(0) As String
        Dim i As Integer = 0
        Dim numSel As Integer

        numSel = lbxConditions.SelectedItems.Count()
        ReDim Preserve where(numSel - 1)

        For Each item As DataRowView In lbxConditions.SelectedItems

            frmMain.dbAccess.SetInactive("conditions", item(0).ToString())
            i += 1
        Next

        ConditionListLoad(lbxConditions)
        lbxConditions.SelectedIndex = -1
    End Sub

    '----------------Condition Selection Change---------------------------------------------
    Private Sub lbxConditions_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbxConditions.SelectedIndexChanged
        If ready = True And lbxConditions.SelectedIndex > -1 Then
            txtCondition.Clear()
            lnkAddCondition.Visible = True
            lnkUpdateCondition.Visible = False
            lnkResetCondition.Visible = False
        End If
    End Sub

    '----------------Selecting Condition for Editing ---------------------------------------------
    Private Sub lbxConditions_DoubleClick(sender As Object, e As EventArgs) Handles lbxConditions.DoubleClick
        If ready = True And lbxConditions.SelectedIndex > -1 Then
            lnkAddCondition.Visible = False
            lnkUpdateCondition.Visible = True
            lnkResetCondition.Visible = True
            txtCondition.Text = lbxConditions.Text
        End If
    End Sub

    'Programs Group --------------------------------------------------------

    '----------------Add Button---------------------------------------------
    Private Sub lnkAddProg_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAddProg.LinkClicked
        Dim data(1) As String
        Dim progID As Integer

        If txtProgram.Text <> "" Then
            Try
                data(0) = "program , active "
                data(1) = "'" + txtProgram.Text + "' , True"

                progID = frmMain.dbAccess.DataPush("programs", data)

                If progID = -1 Then
                    Throw New System.Exception("Program Creation Failure")
                End If

                'Reset Form
                txtProgram.Clear()

                ProgramListLoad(lbxProgs)
                lbxProgs.SelectedIndex = -1

            Catch ex As Exception
                frmMain.lblStatus.Text = ex.Message()
            End Try
        End If
    End Sub

    '----------------Update Button---------------------------------------------
    Private Sub lnkUpdateProgram_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkUpdateProg.LinkClicked
        Dim query As String
        Dim setVal As String
        Dim progsID As String

        setVal = "program='" + txtProgram.Text + "'"
        progsID = lbxProgs.SelectedValue.ToString

        Try
            query = frmMain.dbAccess.QueryBuilder("programs", setVal, progsID, "UPDATE")
            frmMain.dbAccess.PassUpdate(query)

            'Reset Form
            txtProgram.Clear()

            ProgramListLoad(lbxProgs)
            lbxProgs.SelectedIndex = -1

            lnkUpdateProg.Visible = False
            lnkResetProg.Visible = False
            lnkAddProg.Visible = True
        Catch ex As Exception
            frmMain.lblStatus.Text = ex.Message()
        End Try
    End Sub

    '----------------Reset Button---------------------------------------------
    Private Sub lnkResetProgram_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkResetProg.LinkClicked
        If ready = True And lbxProgs.SelectedIndex > -1 Then
            txtProgram.Clear()
            lnkUpdateProg.Visible = False
            lnkResetProg.Visible = False
            lnkAddProg.Visible = True
        End If
    End Sub

    '----------------Remove Selected Button---------------------------------------------
    Private Sub lnkRmvProg_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkRmvProg.LinkClicked
        Dim where(0) As String
        Dim i As Integer = 0
        Dim numSel As Integer

        numSel = lbxProgs.SelectedItems.Count()
        ReDim Preserve where(numSel - 1)

        For Each item As DataRowView In lbxProgs.SelectedItems

            frmMain.dbAccess.SetInactive("programs", item(0).ToString())
            i += 1
        Next

        ProgramListLoad(lbxProgs)
        lbxProgs.SelectedIndex = -1
    End Sub

    '----------------Program Selection Change---------------------------------------------
    Private Sub lbxProgs_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbxProgs.SelectedIndexChanged
        If ready = True And lbxProgs.SelectedIndex > -1 Then
            txtProgram.Clear()
            lnkAddProg.Visible = True
            lnkUpdateProg.Visible = False
            lnkResetProg.Visible = False
        End If
    End Sub

    '----------------Selecting Program for Editing ---------------------------------------------
    Private Sub lbxProgs_DoubleClick(sender As Object, e As EventArgs) Handles lbxProgs.DoubleClick
        If ready = True And lbxProgs.SelectedIndex > -1 Then
            lnkAddProg.Visible = False
            lnkUpdateProg.Visible = True
            lnkResetProg.Visible = True
            txtProgram.Text = lbxProgs.Text
        End If
    End Sub

    'User Maintenance Group --------------------------------------------------------

    '----------------Add Button---------------------------------------------
    Private Sub lnkAddUser_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAddUser.LinkClicked
        Dim data(1) As String
        Dim userID As Integer

        If txtUsername.Text <> "" Then
            Try
                data(0) = "username , first_name , last_name , active "
                data(1) = "'" + txtUsername.Text +
                    "' , '" + txtUserFN.Text +
                    "' , '" + txtUserLN.Text +
                    "' , True"

                userID = frmMain.dbAccess.DataPush("users", data)

                If userID = -1 Then
                    Throw New System.Exception("User Creation Failure")
                End If

                'Reset Form
                txtUsername.Clear()
                txtUserFN.Clear()
                txtUserLN.Clear()

                UserListLoad(lbxUserMaint)
                lbxUserMaint.SelectedIndex = -1
            Catch ex As Exception
                frmMain.lblStatus.Text = ex.Message()
            End Try
        End If
    End Sub

    '----------------Remove Selected Button---------------------------------------------
    Private Sub lnkRmvUser_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkRmvUser.LinkClicked
        Dim where(0) As String
        Dim i As Integer = 0
        Dim numSel As Integer

        numSel = lbxUserMaint.SelectedItems.Count()
        ReDim Preserve where(numSel - 1)

        For Each item As DataRowView In lbxUserMaint.SelectedItems

            frmMain.dbAccess.SetInactive("users", item(0).ToString())
            i += 1
        Next

        UserListLoad(lbxUserMaint)
        lbxUserMaint.SelectedIndex = -1
    End Sub

    '----------------Selecting User for Editing---------------------------------------------
    Private Sub lbxUserMaint_DoubleClick(sender As Object, e As EventArgs) Handles lbxUserMaint.DoubleClick
        If ready = True And lbxUserMaint.SelectedIndex > -1 Then
            Dim uid As String
            Dim dsUser As New DataSet()
            Dim query As String

            Try
                ready = False
                uid = lbxUserMaint.SelectedValue.ToString

                query = frmMain.dbAccess.QueryBuilder("users", "*", "users.id=" + uid + " AND users.active=True")
                dsUser = frmMain.dbAccess.DataGet(query)

                txtUsername.Text = dsUser.Tables(0).Rows(0).Item("username").ToString
                txtUserFN.Text = dsUser.Tables(0).Rows(0).Item("first_name").ToString
                txtUserLN.Text = dsUser.Tables(0).Rows(0).Item("last_name").ToString

                lnkResetUser.Visible = True
                lnkUpdateUser.Visible = True
                lnkAddUser.Visible = False
            Catch ex As Exception
                frmMain.lblStatus.Text = ex.Message()
            End Try

            ready = True
        End If
    End Sub

    '----------------User Selection Change---------------------------------------------
    Private Sub lbxUserMaint_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbxUserMaint.SelectedIndexChanged
        If ready = True And lbxUserMaint.SelectedIndex > -1 Then
            txtUsername.Clear()
            txtUserFN.Clear()
            txtUserLN.Clear()
            lnkUpdateUser.Visible = False
            lnkResetUser.Visible = False
            lnkAddUser.Visible = True
        End If
    End Sub

    '----------------Reset User Form---------------------------------------------
    Private Sub lnkResetUser_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkResetUser.LinkClicked
        'Reset Form
        txtUsername.Clear()
        txtUserFN.Clear()
        txtUserLN.Clear()

        UserListLoad(lbxUserMaint)
        lbxUserMaint.SelectedIndex = -1
        lnkResetUser.Visible = False
        lnkUpdateUser.Visible = False
        lnkAddUser.Visible = True
    End Sub

    '----------------Update User in DB---------------------------------------------
    Private Sub lnkUpdateUser_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkUpdateUser.LinkClicked
        Dim query As String
        Dim setVal As String
        Dim uid As String

        setVal = "username='" + txtUsername.Text +
               "', first_name='" + txtUserFN.Text +
               "', last_name='" + txtUserLN.Text + "'"
        uid = lbxUserMaint.SelectedValue.ToString

        Try
            query = frmMain.dbAccess.QueryBuilder("users", setVal, uid, "UPDATE")
            frmMain.dbAccess.PassUpdate(query)

            'Reset Form
            txtUsername.Clear()
            txtUserFN.Clear()
            txtUserLN.Clear()

            UserListLoad(lbxUserMaint)
            lbxUserMaint.SelectedIndex = -1
            lnkResetUser.Visible = False
            lnkUpdateUser.Visible = False
            lnkAddUser.Visible = True

        Catch ex As Exception
            frmMain.lblStatus.Text = ex.Message()
        End Try
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
        txtFacState.ReadOnly = True
        txtFacState.Text = "MI"
        FacilityListLoad(lbxFacilities)
        lbxFacilities.SelectedIndex = -1

        FacilityListLoad(cbxFacilityL)
        cbxFacilityL.SelectedIndex = -1

        FacilityListLoad(cbxFacilityB)
        cbxFacilityB.SelectedIndex = -1

        'Condtions
        ConditionListLoad(lbxConditions)
        lbxConditions.SelectedIndex = -1

        'Condtions
        ProgramListLoad(lbxProgs)
        lbxProgs.SelectedIndex = -1

        'Users
        UserListLoad(lbxUserMaint)
        lbxUserMaint.SelectedIndex = -1

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
            sqlCriteria = "sub_categories.category_id=" + cbxCat4Sub.SelectedValue.ToString() +
                            " AND sub_categories.active=True"

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
            query = frmMain.dbAccess.QueryBuilder("facilities", "*", "active=True")
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
                sqlCriteria = "locations.active=True"
            Else
                sqlCriteria = "locations.facility_id=" + from.SelectedValue.ToString() +
                            " AND locations.active=True"
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

    'Loads Bin Listbox
    Sub BinListLoad(ob As Object, Optional from As ComboBox = Nothing)
        Dim dsBins As New DataSet()
        Dim query As String
        Dim sqlCriteria As String

        Try
            ready = False
            If from Is Nothing Then
                sqlCriteria = "bins.active)=True"
            Else
                sqlCriteria = "bins.location_id=" + from.SelectedValue.ToString() +
                            " AND bins.active=True"
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

    'Loads Conditions Listbox
    Sub ConditionListLoad(ob As Object)
        Dim dsCondition As New DataSet()
        Dim query As String

        Try
            ready = False
            query = frmMain.dbAccess.QueryBuilder("conditions", "*", "conditions.active=True")
            dsCondition = frmMain.dbAccess.DataGet(query)

            ob.DataSource = dsCondition.Tables(0)
            ob.ValueMember = "id"
            ob.DisplayMember = "condition"

        Catch ex As Exception
            frmMain.lblStatus.Text = ex.Message()
        End Try

        ready = True
    End Sub

    'Loads Conditions Listbox
    Sub ProgramListLoad(ob As Object)
        Dim dsProgram As New DataSet()
        Dim query As String

        Try
            ready = False
            query = frmMain.dbAccess.QueryBuilder("programs", "*", "programs.active=True")
            dsProgram = frmMain.dbAccess.DataGet(query)

            ob.DataSource = dsProgram.Tables(0)
            ob.ValueMember = "id"
            ob.DisplayMember = "program"

        Catch ex As Exception
            frmMain.lblStatus.Text = ex.Message()
        End Try

        ready = True
    End Sub

    'Loads User Maintenance Listbox
    Sub UserListLoad(ob As Object)
        Dim dsUser As New DataSet()
        Dim query As String

        Try
            ready = False
            query = frmMain.dbAccess.QueryBuilder("users", "*", "users.active=True")
            dsUser = frmMain.dbAccess.DataGet(query)

            ob.DataSource = dsUser.Tables(0)
            ob.ValueMember = "id"
            ob.DisplayMember = "username"

        Catch ex As Exception
            frmMain.lblStatus.Text = ex.Message()
        End Try

        ready = True
    End Sub
End Class