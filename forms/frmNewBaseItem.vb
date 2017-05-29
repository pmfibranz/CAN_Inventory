
Public Class frmNewBaseItem


    Private Sub frmNewBaseItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim baseUsrCtrl As New uclBaseItem
        With baseUsrCtrl
            .Name = "baseUsrCtrl"

            .Location = New Point(0, 0)
        End With

        Me.Controls.Add(baseUsrCtrl)

    End Sub
End Class

