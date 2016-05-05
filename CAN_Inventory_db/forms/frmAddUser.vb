Public Class frmAddUser
    Private Sub btnAddUser_Click(sender As Object, e As EventArgs) Handles btnAddUser.Click

        If txtFirstName.Text = "" Or txtLastName.Text = "" Or txtUsername.Text = "" Then
            lblStatus.Text = "No user information has been entered."
        Else
            Dim data(1) As String
            Dim listCount As Integer = 0
            Dim i As Integer = 0

            'Creates query command to send
            data(0) = "username , first_name , last_name , active"
            data(1) = "'" + txtUsername.Text + "' , '" + txtFirstName.Text + "' , '" + txtLastName.Text + "' , True"

            'Pushes created command to the database
            If frmMain.dbAccess.DataPush("users", data) = False Then

                lblStatus.Text = "User Creation Failed"
            End If
            Debug.Print(sender)
            'Updates user list for combo box
            frmMain.UpdateUserCombo()
            If sender.Equals(frmLogin) Then
                Dim j As Integer = 0
                'Updates user list for combo box
                frmLogin.cbxUsers.Items.Clear()
                While j < frmMain.cbxUserSelect.Items.Count()
                    frmLogin.cbxUsers.Items.Add(frmMain.cbxUserSelect.Items(i))
                    j += 1
                End While
            End If
            Me.Close()
            End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

End Class