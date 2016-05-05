﻿Imports System.Data.OleDb
Imports System.IO
Imports System.Text
Public Class frmMain

    'User List
    Public dbAccess As DB_Access
    Public userHand As New UserHandling()


    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim pmtFindDB As New OpenFileDialog()
        Dim listCount As Integer = 0

        dbAccess = New DB_Access(lblStatus, pmtFindDB)

        UpdateUserCombo()

        ' Displays Initial Login Before allowing control of application
        Dim login As New frmLogin()
        login.Show()
        Me.Enabled = False


        'Set recent donation date range
        dtpDFromDate.MaxDate = Now()
        dtpDFromDate.Value = Now.AddMonths(-1)

        'Occational error MaxDate Issue ****************
        dtpDToDate.MaxDate = Now()
        dtpDToDate.Value = Now()



    End Sub

    Private Sub tsiAddUser_Click(sender As Object, e As EventArgs) Handles tsiAddUser.Click
        Dim addU As New frmAddUser()

        addU.Show()

    End Sub

    Private Sub cbxUserSelect_DropDown(sender As Object, e As EventArgs) Handles cbxUserSelect.DropDown
        cbxUserSelect.ForeColor = Color.Black
    End Sub

    Private Sub cbxUserSelect_Leave(sender As Object, e As EventArgs) Handles cbxUserSelect.Leave
        userHand.SetCurrentUser(cbxUserSelect.SelectedItem.ToString())
    End Sub

    Public Sub UpdateUserCombo()
        Dim users() As String
        Dim i As Integer

        'Updates user list for combo box
        userHand.UpdateUserList()
        users = userHand.GetUsernames()
        cbxUserSelect.Items.Clear()

        While i < userHand.GetUserCount()
            cbxUserSelect.Items.Add(users(i))
            i += 1
        End While
    End Sub

    Private Sub TextBox3_Click(sender As Object, e As EventArgs) Handles TextBox3.Click
        If TextBox3.Text = "Search..." Then
            TextBox3.Text = ""
            TextBox3.ForeColor = SystemColors.WindowText

        End If
    End Sub


    Private Sub btnQAddContact_Click(sender As Object, e As EventArgs) Handles btnQAddContact.Click, AddContactToolStripMenuItem.Click
        Dim newCont As New frmNewContact()

        newCont.Show()
    End Sub

    Private Sub AddBenefactorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddBenefactorToolStripMenuItem.Click
        Dim newBen As New frmNewBenefactor()

        newBen.Show()
    End Sub

    Private Sub AddBaseItemToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddBaseItemToolStripMenuItem.Click
        Dim newBaseItem As New frmNewBaseItem()

        newBaseItem.Show()
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        pnlInventory.Visible = False
        pnlBenefactor.Visible = False
        pnlTransReport.Visible = False
        pnlWishlist.Visible = True
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        pnlBenefactor.Visible = False
        pnlWishlist.Visible = False
        pnlTransReport.Visible = False
        pnlInventory.Visible = True
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        pnlInventory.Visible = False
        pnlWishlist.Visible = False
        pnlTransReport.Visible = False
        pnlBenefactor.Visible = True
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        pnlInventory.Visible = False
        pnlBenefactor.Visible = False
        pnlWishlist.Visible = False
        pnlTransReport.Visible = True
    End Sub

End Class

