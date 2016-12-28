Public Class frmAddUser

    Private _callingForm As String
    Public Property callingForm() As String
        Get
            Return _callingForm
        End Get
        Set(ByVal value As String)
            _callingForm = value
        End Set
    End Property

    Private Sub btnAddUser_Click(sender As Object, e As EventArgs) Handles btnAddUser.Click
        
        If txtFirstName.Text = "" Or txtLastName.Text = "" Or txtUsername.Text = "" Then
            lblStatus.Text = "Please enter all user information."
        Else
            Dim data(1) As String
            Dim listCount As Integer = 0

            'Creates query command to send
            data(0) = "username , first_name , last_name , active"
            data(1) = "'" + txtUsername.Text + "' , '" + txtFirstName.Text + "' , '" + txtLastName.Text + "' , True"

            'Pushes created command to the database
            If frmMain.dbAccess.DataPush("users", data) = False Then
                lblStatus.Text = "User Creation Failed"
            End If

            'Debug.Print(sender)

            'Updates user list for combo box
            frmMain.UpdateUserCombo()

            If callingForm = "frmLogin" Then
                'Updates user list for combo box
                frmLogin.cmbUsers.Items.Clear()
                For i As Integer = 0 To frmMain.cmbUserSelect.Items.Count() - 1
                    frmLogin.cmbUsers.Items.Add(frmMain.cmbUserSelect.Items(i))
                Next
            End If

            Me.Close()
        End If
    End Sub


End Class