
Public Class frmLogin
    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim i As Integer = 0
        'Updates user list for combo box
        cbxUsers.Items.Clear()
        While i < frmMain.cbxUserSelect.Items.Count()
            cbxUsers.Items.Add(frmMain.cbxUserSelect.Items(i))
            i += 1
        End While
    End Sub

    Private Sub btnAddUser_Click(sender As Object, e As EventArgs) Handles btnAddUser.Click
        Dim addU As New frmAddUser()

        addU.Show()
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If cbxUsers.SelectedItem <> Nothing Then
            frmMain.userHand.SetCurrentUser(cbxUsers.SelectedItem.ToString())
            frmMain.Enabled = True
            frmMain.cbxUserSelect.SelectedItem = cbxUsers.SelectedItem
            Me.Close()
        Else
            lblStatus.Text = "Please select or add a user."
        End If

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Application.Exit()
    End Sub
End Class