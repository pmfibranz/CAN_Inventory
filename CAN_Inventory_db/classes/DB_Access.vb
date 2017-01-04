Imports System.Data.OleDb
Imports System.IO
Imports System.Text
Public Class DB_Access
    Private Shared dBasePath As String
    Private Shared statusLabel As Object

    Sub New()

    End Sub

    'Constructor that creates and/or verifies path to database
    Sub New(ByRef lblStatus As Object)
        Dim pmtFindDB As New OpenFileDialog()
        Dim dr As DialogResult
        Dim provider As String = "Provider=Microsoft.Jet.OLEDB.4.0;"
        Dim path(1) As String
        Dim dataSrc As String = ""
        Dim SYS_PATH As String = "CAN-sys.bin"
        'Dim pmtFindDB As New OpenFileDialog()

        statusLabel = lblStatus

        pmtFindDB.Filter = "Microsoft Database files (*.mdb)|*.mdb"
        pmtFindDB.FilterIndex = 1

        Try
            'Creates bin file with path to database if one does not exist
            If My.Computer.FileSystem.FileExists(SYS_PATH) Then

                path = IO.File.ReadAllLines(SYS_PATH)

            Else
                dr = pmtFindDB.ShowDialog()
                ' Creates bin file
                If dr = DialogResult.OK Then

                    File.WriteAllText(SYS_PATH, pmtFindDB.FileName())
                    path(0) = pmtFindDB.FileName()

                ElseIf dr = DialogResult.Cancel Then
                    Application.Exit()
                End If
            End If

            dataSrc = "Data Source='" + path(0) + "'"
            dBasePath = provider + dataSrc

            'Updates File with new path if old path fails to open
            While DBValidate() = False
                dr = pmtFindDB.ShowDialog()

                If dr = DialogResult.OK Then

                    File.WriteAllText(SYS_PATH, pmtFindDB.FileName())
                    path(0) = pmtFindDB.FileName()

                    dataSrc = "Data Source='" + path(0) + "'"
                    dBasePath = provider + dataSrc

                ElseIf dr = DialogResult.Cancel Then
                    Application.Exit()

                Else
                    lblStatus.Text = "Failure in Updating System Info File"
                End If
            End While

        Catch ex As Exception
            lblStatus.Text = "Failure in Creating New System Info File" + ex.Message
        End Try

    End Sub

    'Verifies that the application can connect to the database
    Function DBValidate() As Boolean
        Using db As New OleDb.OleDbConnection
            db.ConnectionString = dBasePath
            Try
                db.Open()
                statusLabel.Text = ""
                statusLabel.Text += "The Database is Connected: "
                statusLabel.Text += db.DataSource
                db.Close()
                Return True
            Catch ex As Exception
                statusLabel.Text = "Failed to Connect to Database!"
                statusLabel.Text += " Please contact the system administrator"
            End Try
        End Using

        Return False
    End Function

    'Sends data to the database
    Function DataPush(table As String, data() As String) As Integer
        Using db As New OleDb.OleDbConnection(dBasePath)
            Dim cmd As OleDb.OleDbCommand
            Dim query As String
            Dim query2 As String
            Dim newId As Integer

            Try
                query = "INSERT INTO " + table + " (" + data(0) + ") VALUES(" + data(1) + "); "
                query2 = "SELECT @@Identity;"
                Debug.Print(query)
                db.Open()
                cmd = New OleDbCommand(query, db)
                cmd.ExecuteNonQuery()
                cmd.CommandText = query2
                newId = cmd.ExecuteScalar()
                db.Close()
                Return newId
            Catch ex As Exception
                If db.State = ConnectionState.Open Then
                    db.Close()
                End If
                Return -1
            End Try

        End Using
        Return True
    End Function

    'Retrieves data based on passed query and returns a DataSet
    Function DataGet(query As String) As DataSet
        Dim connect As OleDbConnection
        Dim adapt As OleDbDataAdapter
        Dim data As New DataSet

        connect = New OleDbConnection(dBasePath)
        Try
            connect.Open()
            adapt = New OleDbDataAdapter(query, connect)
            adapt.Fill(data)
            adapt.Dispose()
            connect.Close()

        Catch ex As Exception
            statusLabel.Text = "Failed to retrieve data."
        End Try
        Return data

    End Function

    'Recent Transactions
    Function DataStoredProcGetRecentTransactions() As DataSet
        Dim connect As OleDbConnection
        Dim adapt As OleDbDataAdapter
        Dim data As New DataSet
        Dim cmd As New OleDbCommand

        connect = New OleDbConnection(dBasePath)
        Try
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "queryRecentTransactions"
            cmd.Parameters.Add("@startDate", OleDbType.Date).Value = frmMain.dtpDFromDate.Value ' From date
            cmd.Parameters.Add("@endDate", OleDbType.Date).Value = frmMain.dtpDToDate.MaxDate ' To date
            cmd.Connection = connect
            connect.Open()

            adapt = New OleDbDataAdapter(cmd)
            adapt.Fill(data, "Table1")

            connect.Close()
        Catch ex As Exception
            statusLabel.Text = "Failed to retrieve data."
        End Try
        Return data
    End Function

    'Inventory Notifications
    Function DataStoredProcGetInventoryNotifications() As DataSet
        Dim connect As OleDbConnection
        Dim adapt As OleDbDataAdapter
        Dim data As New DataSet
        Dim cmd As New OleDbCommand

        connect = New OleDbConnection(dBasePath)
        Try
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "queryItemLowInventory"
            cmd.Connection = connect
            connect.Open()

            adapt = New OleDbDataAdapter(cmd)
            adapt.Fill(data, "Table1")

            connect.Close()
        Catch ex As Exception
            statusLabel.Text = "Failed to retrieve data."
        End Try
        Return data
    End Function

    'Determine total "in" count for given item
    Function DataStoredProcGetQuantityIn(itemId As Integer) As DataSet
        Dim connect As OleDbConnection
        Dim adapt As OleDbDataAdapter
        Dim data As New DataSet
        Dim cmd As New OleDbCommand

        connect = New OleDbConnection(dBasePath)
        Try
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "queryCountItemIn"
            cmd.Parameters.Add("@ItemId", OleDbType.Integer).Value = itemId
            cmd.Connection = connect
            connect.Open()

            adapt = New OleDbDataAdapter(cmd)
            adapt.Fill(data, "Table1")

            connect.Close()
        Catch ex As Exception
            statusLabel.Text = "Failed to retrieve data."
        End Try
        Return data
    End Function

    'Determine total "out" count for given item
    Function DataStoredProcGetQuantityOut(itemId As Integer) As DataSet
        Dim connect As OleDbConnection
        Dim adapt As OleDbDataAdapter
        Dim data As New DataSet
        Dim cmd As New OleDbCommand

        connect = New OleDbConnection(dBasePath)
        Try
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "queryCountItemOut"
            cmd.Parameters.Add("@ItemId", OleDbType.Integer).Value = itemId
            cmd.Connection = connect
            connect.Open()

            adapt = New OleDbDataAdapter(cmd)
            adapt.Fill(data, "Table1")

            connect.Close()
        Catch ex As Exception
            statusLabel.Text = "Failed to retrieve data."
        End Try
        Return data
    End Function

    'Builds Query 
    Function QueryBuilder(ByRef table As String, ByVal data As String,
                          Optional ByVal where As String = "",
                          Optional ByRef action As String = "SELECT") As String
        Dim query As String
        'Data Read Query
        If action = "SELECT" Then
            query = "SELECT " + data + " FROM " + table
            If where <> "" Then
                query += (" WHERE " + where + ";")
            Else
                query += ";"
            End If

        ElseIf action = "UPDATE" Then

            query = "UPDATE " + table + " SET " + data +
                " WHERE id=" + where + " ;"
        Else
            Throw New System.Exception("Unable to build query")
        End If

        Debug.Print(query)
        Return query
    End Function

    Function SetInactive(ByRef table As String, ByVal where As String) As Boolean
        Dim query As String

        query = "UPDATE " + table + " SET active=False  WHERE id=" + where + " ;"

        Debug.Print(query)

        Return PassUpdate(query)
    End Function

    Function GetDB_Path() As String
        Return dBasePath
    End Function

    Function PassUpdate(query As String) As Boolean
        Dim connect As OleDbConnection
        Dim cmd As OleDbCommand

        connect = New OleDbConnection(dBasePath)

        Try
            connect.Open()
            cmd = New OleDbCommand(query, connect)
            cmd.ExecuteNonQuery()
            connect.Close()

            Return True
        Catch ex As Exception
            statusLabel.Text = "Failed to Update data."
        End Try

        Return False
    End Function

End Class

