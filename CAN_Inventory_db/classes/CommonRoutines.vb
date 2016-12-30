Public Class CommonRoutines
    ' Fills combo box
    Public Sub fillDropDownListBox(ByRef cmb As ComboBox, table As String, valueMember As String, displayMember As String, sqlCriteria As String, defaultIndex As Integer)
        Dim query As String
        Dim ds As New DataSet

        query = frmMain.dbAccess.QueryBuilder(table, "*", sqlCriteria)
        ds = frmMain.dbAccess.DataGet(query)

        cmb.DataSource = ds.Tables(0)
        cmb.ValueMember = valueMember '"id"
        cmb.DisplayMember = displayMember '"category"
        cmb.SelectedIndex = defaultIndex '-1              ' Sets default selected item 
    End Sub
        
End Class