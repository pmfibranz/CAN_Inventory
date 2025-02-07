﻿Public Class uclBaseItem
    Private Shared ready As Boolean
    Friend Shared Event RefreshItemDisp()
    Friend Shared Event RefreshExistingItemGrid()

    Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AddHandler frmMain.ClearItemDetails, AddressOf theCloser
        AddHandler frmMain.InitializeItemDetailControls, AddressOf initializeItemDetailControls
    End Sub
    Private Sub uclBaseItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        initializeItemDetailControls()

    End Sub

    Private Sub cmbCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCategory.SelectedIndexChanged
        Try
            If ready = True Then
                If cmbCategory.SelectedValue = -1 Then
                    cmbSubCat.Enabled = False
                Else
                    Dim ds As New DataSet()
                    Dim query As String
                    Dim sqlCriteria As String
                    ready = False

                    sqlCriteria = "sub_categories.category_id=" & cmbCategory.SelectedValue.ToString() & " AND sub_categories.active=True"

                    query = frmMain.dbAccess.QueryBuilder("sub_categories", "*", sqlCriteria)

                    ds = frmMain.dbAccess.DataGet(query)
                    cmbSubCat.DataSource = ds.Tables(0)
                    cmbSubCat.ValueMember = "id"
                    cmbSubCat.DisplayMember = "sub_category"
                    cmbSubCat.SelectedIndex = -1              ' Sets default selected item to empty
                    cmbSubCat.Enabled = True
                    ready = True
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbFacility_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFacility.SelectedIndexChanged
        Try
            If ready = True Then
                If cmbFacility.SelectedValue = -1 Then
                    cmbLocation.Enabled = False
                Else
                    Dim ds As New DataSet()
                    Dim query As String
                    Dim sqlCriteria As String
                    ready = False

                    sqlCriteria = "locations.facility_id=" & cmbFacility.SelectedValue.ToString() & " AND locations.active=True"

                    query = frmMain.dbAccess.QueryBuilder("locations", "*", sqlCriteria)

                    ds = frmMain.dbAccess.DataGet(query)
                    cmbLocation.DataSource = ds.Tables(0)
                    cmbLocation.ValueMember = "id"
                    cmbLocation.DisplayMember = "location"
                    cmbLocation.SelectedIndex = -1              ' Sets default selected item to empty
                    cmbLocation.Enabled = True

                    ready = True
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbLocation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLocation.SelectedIndexChanged
        Try
            If ready = True Then
                If cmbLocation.SelectedValue = -1 Then
                    cmbBin.Enabled = False
                Else
                    Dim ds As New DataSet()
                    Dim query As String
                    Dim sqlCriteria As String
                    ready = False

                    sqlCriteria = "bins.location_id=" & cmbLocation.SelectedValue.ToString() & " AND bins.active=True"

                    query = frmMain.dbAccess.QueryBuilder("bins", "*", sqlCriteria)

                    ds = frmMain.dbAccess.DataGet(query)
                    cmbBin.DataSource = ds.Tables(0)
                    cmbBin.ValueMember = "id"
                    cmbBin.DisplayMember = "bin"
                    cmbBin.SelectedIndex = -1              ' Sets default selected item to empty
                    cmbBin.Enabled = True

                    ready = True
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        theCloser()
    End Sub

    Private Sub btnAddItem_Click(sender As Object, e As EventArgs) Handles btnAddItem.Click
        Dim TrDate As Date
        Dim data(1) As String
        Dim itemID As Integer
        Dim transID As Integer

        If txtName.Text = "" Or cmbCategory.SelectedValue = Nothing Or cmbSubCat.SelectedValue = Nothing Or cmbCondition.SelectedValue = Nothing Then
            ' Requires Item Name, Category, Sub-Category 
            ' other fields can be added at a later time
            lblStatus.Text = "Required Information Missing!"
            If txtName.Text = "" Then
                lblName.ForeColor = Color.Red
            End If
            If cmbCategory.SelectedValue = Nothing Then
                lblCategory.ForeColor = Color.Red
            End If
            If cmbSubCat.SelectedValue = Nothing Then
                lblSubCat.ForeColor = Color.Red
            End If
        Else
            Try
                ready = False

                'Create a logical item
                data(0) = "item_name , item_desc , sub_category_id , def_facility_id , def_location_id , " +
                    "def_bin_id , def_program_id , def_value , low_qty , times_accessed , active "
                data(1) = "'" + txtName.Text + "' , '" +
                                txtDescript.Text + "' , " +
                                cmbSubCat.SelectedValue.ToString() + " , " +
                                blankFiller(cmbFacility) + " , " +
                                blankFiller(cmbLocation) + " , " +
                                blankFiller(cmbBin) + " , " +
                                blankFiller(cmbProgram) + " , " +
                                blankFiller(txtDefValue, "Money") + " , " +
                                blankFiller(nbxLwQty) + " , 0 , True"

                itemID = frmMain.dbAccess.DataPush("items", data)

                If itemID = -1 Then
                    Throw New System.Exception("Item Creation Failure")
                End If

                'Create physical item using a transaction
                If nbxInitQty.Value > 0 Then
                    TrDate = DateTime.Now()

                    data(0) = "trans_type_id , donor_thanked , user_id , trans_date "
                    data(1) = "'1' , " +
                                  " False , " +
                                  Convert.ToString(frmMain.userHand.GetCurrentUsrID()) + ", '" +
                                  TrDate + "'"

                    transID = frmMain.dbAccess.DataPush("transactions", data)

                    If transID = -1 Then
                        Throw New System.Exception("Transaction Creation Failure")
                    End If

                    data(0) = "transaction_id , item_id , condition_id, bin_id , program_id , quantity , comment , specific_value"
                    data(1) = transID.ToString() + " , " +
                                  itemID.ToString() + " , " +
                                  blankFiller(cmbCondition) + " , " +
                                  blankFiller(cmbBin) + " , " +
                                  blankFiller(cmbProgram) + " , " +
                                  blankFiller(nbxInitQty) + " , " +
                                  "'Initial Quantity of Item' , " +
                                  blankFiller(txtDefValue, "Money")

                    If frmMain.dbAccess.DataPush("inventory", data) = -1 Then
                        Throw New System.Exception("Inventory Item Creation Failure")
                    End If

                    theCloser()

                    'RaiseEvent RefreshItemDisp()
                End If

                'Update list of existing items
                RaiseEvent RefreshExistingItemGrid()
            Catch ex As Exception
                lblStatus.Text = ex.Message
            Finally
                ready = True
            End Try
        End If
    End Sub

    Private Sub btnUpdateItem_Click(sender As Object, e As EventArgs) Handles btnUpdateItem.Click
        'LEFT OFF HERE
    End Sub

    Function blankFiller(field As Object, Optional format As String = "") As String
        Dim t As Type = field.GetType()

        If t.Equals(GetType(TextBox)) And format = "Money" Then
            If field.Text = "" Then
                Return "0.00"
            End If
            Return field.Text()
        ElseIf t.Equals(GetType(TextBox)) And format = "Text" Then
            If field.Text = "" Then
                Return ""
            End If
            Return field.Text()
        ElseIf t.Equals(GetType(NumericUpDown)) Then
            If field.Value = Nothing Then
                Return "0"
            End If
            Return field.Value.ToString()
        ElseIf t.Equals(GetType(ComboBox)) Then
            If field.SelectedValue = Nothing Then
                Return "0"
            End If
            Return field.SelectedValue.ToString()
        Else
            Throw New System.Exception("Could not handle data type: From Empty Field Filler")
        End If

    End Function

    Sub theCloser()

        ready = False

        If ParentForm.ToString <> frmMain.ToString Then
            ParentForm.Close()
        Else
            txtName.Clear()
            txtDescript.Clear()
            txtDefValue.Clear()
            cmbCategory.SelectedIndex = -1
            cmbSubCat.SelectedIndex = -1
            cmbFacility.SelectedIndex = -1
            cmbLocation.SelectedIndex = -1
            cmbBin.SelectedIndex = -1
            cmbProgram.SelectedIndex = -1
            nbxInitQty.Value = 0
            nbxLwQty.Value = 0
            rdoItemModeAdd.Checked = True
        End If

        ready = True
    End Sub

    Sub FillWith(baseItem As DataRowView)
        txtName.Text = baseItem.Item("Item")
        txtDescript.Text = baseItem.Item("Description")
        cmbCategory.Text = baseItem.Item("Category")
        cmbSubCat.Text = baseItem.Item("Subcategory")
        txtDefValue.Text = baseItem.Item("Default Value")
        'Select Facility then initiate event to populate Location
        cmbFacility.SelectedIndex = cmbFacility.FindStringExact(baseItem.Item("Facility"))

        'Select Location then initiate event to populate Bin
        cmbLocation.SelectedIndex = cmbLocation.FindStringExact(baseItem.Item("Location"))

        'Select Bin
        cmbBin.SelectedIndex = cmbBin.FindStringExact(baseItem.Item("Bin"))

        'Select Program
        cmbProgram.SelectedIndex = cmbProgram.FindStringExact(baseItem.Item("Program"))
        'nbxLwQty.Value = baseItem.Item("Low Qty")

        'Default mode to Add
        rdoItemModeAdd.Checked = True
    End Sub

    Private Sub rdoItemModeAdd_CheckedChanged(sender As Object, e As EventArgs) Handles rdoItemModeAdd.CheckedChanged
        btnAddItem.Visible = True
        btnUpdateItem.Visible = False
    End Sub

    Private Sub rdoItemModeEdit_CheckedChanged(sender As Object, e As EventArgs) Handles rdoItemModeEdit.CheckedChanged
        btnAddItem.Visible = False
        btnUpdateItem.Visible = True
    End Sub

    Private Sub initializeItemDetailControls()
        Dim dsCat As New DataSet()
        Dim dsFac As New DataSet()
        Dim dsProg As New DataSet()
        Dim query As String

        ready = False

        ' Fills Category combo box
        query = frmMain.dbAccess.QueryBuilder("categories", "*", "categories.active=True")
        dsCat = frmMain.dbAccess.DataGet(query)

        cmbCategory.DataSource = dsCat.Tables(0)
        cmbCategory.ValueMember = "id"
        cmbCategory.DisplayMember = "category"
        cmbCategory.SelectedIndex = -1              ' Sets default selected item to empty

        ' Fills Facility combo box
        query = frmMain.dbAccess.QueryBuilder("facilities", "id, facility, active", "facilities.active=True")
        dsFac = frmMain.dbAccess.DataGet(query)

        cmbFacility.DataSource = dsFac.Tables(0)
        cmbFacility.ValueMember = "id"
        cmbFacility.DisplayMember = "facility"
        cmbFacility.SelectedIndex = -1              ' Sets default selected item to empty

        ' Fills program combo box
        query = frmMain.dbAccess.QueryBuilder("programs", "id, program, active", "programs.active=True")
        dsProg = frmMain.dbAccess.DataGet(query)

        cmbProgram.DataSource = dsProg.Tables(0)
        cmbProgram.ValueMember = "id"
        cmbProgram.DisplayMember = "program"
        cmbProgram.SelectedIndex = -1              ' Sets default selected item to empty

        ' Fills Condition combo box
        query = frmMain.dbAccess.QueryBuilder("conditions", "id, condition, active", "conditions.active=True")
        dsCat = frmMain.dbAccess.DataGet(query)

        cmbCondition.DataSource = dsCat.Tables(0)
        cmbCondition.ValueMember = "id"
        cmbCondition.DisplayMember = "condition"
        cmbCondition.SelectedIndex = 0              ' Sets default selected item to New

        ' Set mode
        rdoItemModeAdd.Checked = True

        ready = True
    End Sub
End Class