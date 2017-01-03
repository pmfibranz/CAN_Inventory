Imports System.Data.OleDb
Imports System.IO
Imports System.Text
Public Class frmMain

    'User List
    Public dbAccess As DB_Access
    Public userHand As New UserHandling()
    Public comRoutes As New CommonRoutines
    '-------------- Form General ----------------

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim listCount As Integer = 0

        dbAccess = New DB_Access(lblStatus)

        UpdateUserCombo()

        'Set recent donation date range
        dtpDFromDate.MaxDate = Now()
        dtpDFromDate.Value = Now.AddMonths(-1)


        dtpDToDate.MaxDate = Now()
        dtpDToDate.Value = dtpDToDate.MaxDate

        '-------------- Inventory Transaction Tab ----------------
        ' Fills Transaction Type combo box
        Call comRoutes.fillDropDownListBox(cmbTranType, "transaction_type", "id", "description", "transaction_type.description In ('In','Out') AND transaction_type.active=True", 0)

        ' Fills Category combo box
        Call comRoutes.fillDropDownListBox(cmbTranFilterByCategory, "categories", "id", "category", "active=True", -1)
        cmbTranFilterByCategory.SelectedIndex = 0 'Ensure sub-category list loaded

        '-------------- Item Manager Tab ----------------
        Dim itemTab As New uclItemMan
        With itemTab
            .Name = "itemTab"
            .Location = New Point(0, 0)
            .Width = Me.tbpItmManag.Width
            .Height = Me.tbpItmManag.Height
            .Anchor = AnchorStyles.Bottom Or AnchorStyles.Right Or AnchorStyles.Top Or AnchorStyles.Left
        End With

        tbpItmManag.Controls.Add(itemTab)

        '-------------- Settings Tab ----------------
        Dim settingsTab As New uclSettings
        With settingsTab
            .Name = "settingsTab"
            .Location = New Point(5, 10)
        End With

        Me.tbpSettings.Controls.Add(settingsTab)

        Call loadRecentDonations()

        Me.Enabled = False

        ' Displays Initial Login Before allowing control of application
        'Dim login As New frmLogin()
        'login.Show()
        Me.Hide()
        frmLogin.Show()
    End Sub

    '-------------- Menu Strip ----------------

    Private Sub tsiAddUser_Click(sender As Object, e As EventArgs) Handles tsiAddUser.Click
        Dim addU As New frmAddUser()

        addU.Show()

    End Sub

    Private Sub cbxUserSelect_Leave(sender As Object, e As EventArgs) Handles cmbUserSelect.Leave
        userHand.SetCurrentUser(cmbUserSelect.SelectedItem.ToString())
    End Sub

    Public Sub UpdateUserCombo()
        Dim users() As String

        'Updates user list for combo box
        userHand.UpdateUserList()
        users = userHand.GetUsernames()
        cmbUserSelect.Items.Clear()

        For i As Integer = 0 To userHand.GetUserCount() - 1
            cmbUserSelect.Items.Add(users(i))
        Next
    End Sub

    Private Sub txtSearchTran_Click(sender As Object, e As EventArgs) Handles txtSearchTran.Click
        If txtSearchTran.Text = "Search..." Then
            txtSearchTran.Text = ""
            txtSearchTran.ForeColor = SystemColors.WindowText
        End If
    End Sub


    Private Sub btnQAddContact_Click(sender As Object, e As EventArgs) Handles btnQAddContact.Click, AddContactToolStripMenuItem.Click
        Dim newCont As New frmNewContact()

        newCont.Show()
    End Sub

    Private Sub tsiAddDonor_Click(sender As Object, e As EventArgs) Handles tsiAddDonor.Click
        Dim newBen As New frmNewDonor()

        newBen.Show()
    End Sub

    Private Sub AddBaseItemToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddBaseItemToolStripMenuItem.Click
        Dim newBaseItem As New frmNewBaseItem()

        newBaseItem.Show()
    End Sub


    '-------------- Dashboard Tab ---------------

    Private Sub loadRecentDonations()

        Dim dsUser As New DataSet()

        Try
            dsUser = dbAccess.DataStoredProcGetRecentTransactions()

            'txtUsername.Text = dsUser.Tables(0).Rows(0).Item("username").ToString
            'txtUserFN.Text = dsUser.Tables(0).Rows(0).Item("first_name").ToString
            'txtUserLN.Text = dsUser.Tables(0).Rows(0).Item("last_name").ToString

            dgvRecentDonations.DataSource = dsUser.Tables(0)
        Catch ex As Exception
            lblStatus.Text = ex.Message()
        End Try

    End Sub

    '-------------- Inventory Trans Tab ---------



    '-------------- Item Manager Tab ------------



    '-------------- Reports Tab -----------------

    Private Sub radWishlist_CheckedChanged(sender As Object, e As EventArgs) Handles radWishlist.CheckedChanged
        pnlInventory.Visible = False
        pnlBenefactor.Visible = False
        pnlTransReport.Visible = False
        pnlWishlist.Visible = True
    End Sub

    Private Sub radInventory_CheckedChanged(sender As Object, e As EventArgs) Handles radInventory.CheckedChanged
        pnlBenefactor.Visible = False
        pnlWishlist.Visible = False
        pnlTransReport.Visible = False
        pnlInventory.Visible = True
    End Sub

    Private Sub radBenefactor_CheckedChanged(sender As Object, e As EventArgs) Handles radBenefactor.CheckedChanged
        pnlInventory.Visible = False
        pnlWishlist.Visible = False
        pnlTransReport.Visible = False
        pnlBenefactor.Visible = True
    End Sub

    Private Sub radTransactions_CheckedChanged(sender As Object, e As EventArgs) Handles radTransactions.CheckedChanged
        pnlInventory.Visible = False
        pnlBenefactor.Visible = False
        pnlWishlist.Visible = False
        pnlTransReport.Visible = True
    End Sub

    Private Sub AddNewBaseItemToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddNewBaseItemToolStripMenuItem.Click
        Dim newBaseItem As New frmNewBaseItem()

        newBaseItem.Show()
    End Sub

    Private Sub dtpDFromDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpDFromDate.ValueChanged
        Call loadRecentDonations()
    End Sub

    Private Sub dtpDToDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpDToDate.ValueChanged
        Call loadRecentDonations()
    End Sub

    Private Sub cmbTranFilterByCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTranFilterByCategory.SelectedIndexChanged
        Dim sqlCriteria As String

        'Clear or populate
        If cmbTranFilterByCategory.SelectedIndex = -1 Then
            cmbTranFilterBySubCategory.Items.Clear()
        Else
            sqlCriteria = "(((sub_categories.category_id)=" & cmbTranFilterByCategory.SelectedValue.ToString() & ") AND (sub_categories.active=True))"

            ' Fills Transaction Inventory Sub-Category combo box
            Call comRoutes.fillDropDownListBox(cmbTranFilterBySubCategory, "sub_categories", "id", "sub_category", sqlCriteria, 0)
        End If

    End Sub

End Class


'-------------- Contacts Tab ----------------



