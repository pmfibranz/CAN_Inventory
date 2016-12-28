
Public Class frmLogin

    Private Sub frmLogin_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        Call populateUserList()
    End Sub

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call populateUserList()
    End Sub

    Private Sub btnAddUser_Click(sender As Object, e As EventArgs) Handles btnAddUser.Click
        Dim addU As New frmAddUser()
        addU.callingForm() ="frmLogin"
        addU.Show(Me)
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If cmbUsers.SelectedItem <> Nothing Then
            frmMain.userHand.SetCurrentUser(cmbUsers.SelectedItem.ToString())
            frmMain.Enabled = True
            frmMain.cmbUserSelect.SelectedItem = cmbUsers.SelectedItem
            frmMain.Show()
            Me.Close()
        Else
            lblStatus.Text = "Please select or add a user."
        End If

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Application.Exit()
    End Sub

    Private Sub populateUserList()
        'Updates user list for combo box
        cmbUsers.Items.Clear()
        For i As Integer = 0 To frmMain.cmbUserSelect.Items.Count() - 1
            cmbUsers.Items.Add(frmMain.cmbUserSelect.Items(i))
        Next
    End Sub
End Class