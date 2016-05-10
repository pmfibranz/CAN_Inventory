Imports System.Data.OleDb
Imports System.IO
Imports System.Text

Public Class UserHandling
    Private Shared users() As CAN_User
    Private Shared userCount As Integer
    Private Shared currentUser As CAN_User

    'Updates the user list as new users are added
    Public Function UpdateUserList() As Boolean

        Using db As New OleDbConnection(frmMain.dbAccess.GetDB_Path())
            Dim query As String
            Dim cmd As OleDbCommand
            Dim reader As OleDbDataReader

            'Construct Query
            query = frmMain.dbAccess.QueryBuilder("users", "*", "(((users.active)=True))")

            Try
                userCount = 0
                db.Open()
                cmd = New OleDbCommand(query, db)
                reader = cmd.ExecuteReader()

                'Read user info to userlist and add users to main form dropdown
                While reader.Read()
                    ReDim Preserve users(userCount + 1)
                    users(userCount).id = reader(0).ToString()
                    users(userCount).username = reader(1).ToString()
                    users(userCount).firstName = reader(2).ToString()
                    users(userCount).lastName = reader(3).ToString()
                    users(userCount).active = reader(4).ToString()

                    'frmMain.cbxUserSelect.Items.Add(users(userCount).username)
                    userCount += 1

                End While
                db.Close()

            Catch ex As Exception
                If db.State = ConnectionState.Open Then
                    db.Close()
                End If
                frmMain.lblStatus.Text = "Failed to update user list: " + ex.Message
                Return False
            End Try
        End Using

        Return True
    End Function

    Public Function SetCurrentUser(currUsr As String) As Boolean
        Dim i As Integer = 0
        'frmMain.currentUser.username = cbxUsers.SelectedItem.ToString()
        While users(i).username.ToString() <> currUsr
            i += 1
        End While
        currentUser.id = users(i).id
        currentUser.username = users(i).username
        currentUser.firstName = users(i).firstName
        currentUser.lastName = users(i).lastName
        Return True
    End Function

    Public Function GetUsernames() As String()
        Dim i As Integer = 0
        Dim usernames(userCount) As String
        While i < userCount
            usernames(i) = users(i).username
            i += 1
        End While
        Return usernames
    End Function

    Public Function GetCurrentUsr() As CAN_User
        Return currentUser
    End Function

    Public Function GetCurrentUsrID() As Integer
        Return currentUser.id
    End Function

    Public Function GetUserCount() As Integer
        Return userCount
    End Function
End Class

Public Structure CAN_User
    Dim id As Integer
    Dim username As String
    Dim firstName As String
    Dim lastName As String
    Dim active As Boolean
End Structure