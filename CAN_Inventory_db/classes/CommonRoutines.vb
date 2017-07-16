Public Class CommonRoutines
    ' Fills combo box
    Public Sub fillDropDownListBox(ByRef cmb As ComboBox, table As String, valueMember As String, displayMember As String, sqlCriteria As String, defaultIndex As Integer)
        Dim query As String
        Dim ds As New DataSet

        query = frmMain.dbAccess.QueryBuilder(table, "*", sqlCriteria)
        ds = frmMain.dbAccess.DataGet(query)

        cmb.DataSource = ds.Tables(0)
        cmb.ValueMember = valueMember 'e.g. id
        cmb.DisplayMember = displayMember 'e.g. category
        cmb.SelectedIndex = defaultIndex 'e.g. -1
    End Sub
End Class