Imports System.IO
Imports System.Text

Public Class frmNewBaseItem
    Private Shared ready As Boolean

    Private Sub frmNewBaseItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim dsCat As New DataSet()
        Dim dsFac As New DataSet()
        Dim dsProg As New DataSet()
        Dim query As String

        ready = False

        ' Fills Category combo box
        query = frmMain.dbAccess.QueryBuilder("categories", "*", "(((categories.active)=True))")
        dsCat = frmMain.dbAccess.DataGet(query)

        cbxCategory.DataSource = dsCat.Tables(0)
        cbxCategory.ValueMember = "id"
        cbxCategory.DisplayMember = "category"
        cbxCategory.SelectedIndex = -1              ' Sets default selected item to empty


        ' Fills Facility combo box
        query = frmMain.dbAccess.QueryBuilder("facilities", "id, facility, active", "(((facilities.active)=True))")
        dsFac = frmMain.dbAccess.DataGet(query)

        cbxFacility.DataSource = dsFac.Tables(0)
        cbxFacility.ValueMember = "id"
        cbxFacility.DisplayMember = "facility"
        cbxFacility.SelectedIndex = -1              ' Sets default selected item to empty

        ' Fills program combo box
        query = frmMain.dbAccess.QueryBuilder("programs", "id, program, active", "(((programs.active)=True))")
        dsProg = frmMain.dbAccess.DataGet(query)

        cbxProgram.DataSource = dsProg.Tables(0)
        cbxProgram.ValueMember = "id"
        cbxProgram.DisplayMember = "program"
        cbxProgram.SelectedIndex = -1              ' Sets default selected item to empty

        ready = True

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

    Private Sub cbxFacility_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxFacility.SelectedIndexChanged
        Try
            If ready = True Then
                If cbxFacility.SelectedValue = -1 Then
                    cbxLocation.Enabled = False
                Else
                    Dim ds As New DataSet()
                    Dim query As String
                    Dim sqlCriteria As String
                    ready = False

                    sqlCriteria = "(((locations.facility_id)=" + cbxFacility.SelectedValue.ToString() +
                        ") AND ((locations.active)=True))"

                    query = frmMain.dbAccess.QueryBuilder("locations", "*", sqlCriteria)

                    ds = frmMain.dbAccess.DataGet(query)
                    cbxLocation.DataSource = ds.Tables(0)
                    cbxLocation.ValueMember = "id"
                    cbxLocation.DisplayMember = "location"
                    cbxLocation.SelectedIndex = -1              ' Sets default selected item to empty
                    cbxLocation.Enabled = True

                    ready = True
                End If
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbxLocation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxLocation.SelectedIndexChanged
        Try
            If ready = True Then
                If cbxLocation.SelectedValue = -1 Then
                    cbxBin.Enabled = False
                Else
                    Dim ds As New DataSet()
                    Dim query As String
                    Dim sqlCriteria As String
                    ready = False

                    sqlCriteria = "(((bins.location_id)=" + cbxLocation.SelectedValue.ToString() +
                        ") AND ((bins.active)=True))"

                    query = frmMain.dbAccess.QueryBuilder("bins", "*", sqlCriteria)

                    ds = frmMain.dbAccess.DataGet(query)
                    cbxBin.DataSource = ds.Tables(0)
                    cbxBin.ValueMember = "id"
                    cbxBin.DisplayMember = "bin"
                    cbxBin.SelectedIndex = -1              ' Sets default selected item to empty
                    cbxBin.Enabled = True

                    ready = True
                End If
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnAddItem_Click(sender As Object, e As EventArgs) Handles btnAddItem.Click
        If txtName.Text = "" Or cbxCategory.SelectedValue = Nothing Or cbxSubCat.SelectedValue = Nothing Then
            ' Requires Item Name, Category, and Sub-Category
            ' other fields can be added at a later time
            lblStatus.Text = "Required Information Missing!"
            If txtName.Text = "" Then
                lblName.ForeColor = Color.Red
            End If
            If cbxCategory.SelectedValue = Nothing Then
                lblCategory.ForeColor = Color.Red
            End If
            If cbxSubCat.SelectedValue = Nothing Then
                lblSubCat.ForeColor = Color.Red
            End If
        Else

            Try
                Dim data(1) As String
                Dim itemID As Integer
                Dim transID As Integer




                data(0) = "item_name , item_desc , sub_category_id , def_facility_id , def_location_id , " +
                    "def_bin_id , def_program_id , def_value , low_qty , times_accessed , active "
                data(1) = "'" + txtName.Text + "' , '" +
                                txtDescript.Text + "' , " +
                                cbxSubCat.SelectedValue.ToString() + " , " +
                                blankFiller(cbxFacility) + " , " +
                                blankFiller(cbxLocation) + " , " +
                                blankFiller(cbxBin) + " , " +
                                blankFiller(cbxProgram) + " , " +
                                blankFiller(txtDefValue, "Money") + " , " +
                                blankFiller(nbxLwQty) + " , 0 , True"

                itemID = frmMain.dbAccess.DataPush("items", data)

                If itemID = -1 Then
                    Throw New System.Exception("Item Creation Failure")
                End If

                If nbxInitQty.Value > 0 Then
                    Dim TrDate As Date

                    TrDate = DateTime.Now()

                    data(0) = "trans_type , donor_thanked , user_id , trans_date "
                    data(1) = "'Initial' , " +
                              " -1 , " +
                              Convert.ToString(frmMain.userHand.GetCurrentUsrID()) + ", '" +
                              TrDate + "'"

                    transID = frmMain.dbAccess.DataPush("transactions", data)

                    If transID = -1 Then
                        Throw New System.Exception("Transaction Creation Failure")
                    End If

                    data(0) = "transaction_id , item_id , bin_id , program_id , quantity , comment , specific_value"
                    data(1) = transID.ToString() + " , " +
                              itemID.ToString() + " , " +
                              blankFiller(cbxBin) + " , " +
                              blankFiller(cbxProgram) + " , " +
                              blankFiller(nbxInitQty) + " , " +
                              "'Initial Quantity of Item' , " +
                              blankFiller(txtDefValue, "Money")



                    If frmMain.dbAccess.DataPush("inventory", data) = -1 Then
                        Throw New System.Exception("Inventory Item Creation Failure")
                    End If

                    Me.Close()
                End If
            Catch ex As Exception
                lblStatus.Text = ex.Message
            End Try




        End If
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
End Class

