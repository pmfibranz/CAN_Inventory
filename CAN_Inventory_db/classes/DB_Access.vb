Imports System.Data.OleDb
Imports System.IO
Imports System.Text
Public Class DB_Access
    Private Shared dBasePath As String
    Private Shared statusLabel As Object

    Sub New()

    End Sub

    'Constructor that creates and/or verifies path to database
    Sub New(ByRef lblStatus As Object, ByRef pmtFindDB As OpenFileDialog)
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

                ' Creates bin file
                If pmtFindDB.ShowDialog() = DialogResult.OK Then

                    File.WriteAllText(SYS_PATH, pmtFindDB.FileName())

                    pmtFindDB.Reset()
                ElseIf pmtFindDB.ShowDialog() = DialogResult.Cancel Then
                    Application.Exit()
                End If
            End If

            dataSrc = "Data Source='" + path(0) + "'"
            dBasePath = provider + dataSrc

            'Updates File with new path if old path fails to open
            While DBValidate() = False
                If pmtFindDB.ShowDialog() = DialogResult.OK Then

                    File.WriteAllText(SYS_PATH, pmtFindDB.FileName())

                    dataSrc = "Data Source='" + path(0) + "'"
                    dBasePath = provider + dataSrc
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
                statusLabel.Text = "Failed to Connect to Database"
                statusLabel.Text += vbNewLine + "Please contact the system administrator"
            End Try

        End Using
        Return False
    End Function

    'Sends data to the database
    Function DataPush(table As String, data() As String) As Boolean
        Using db As New OleDb.OleDbConnection(dBasePath)
            Dim cmd As OleDb.OleDbCommand
            Dim query As String

            Try
                query = "INSERT INTO " + table + "(" + data(0) + ") VALUES(" + data(1) + ")"
                Debug.Print(query)
                db.Open()
                cmd = New OleDbCommand(query, db)
                cmd.ExecuteNonQuery()
                db.Close()
                Return True
            Catch ex As Exception
                If db.State = ConnectionState.Open Then
                    db.Close()
                End If
                Return False
            End Try

        End Using
        Return True
    End Function

    'Builds Query 
    Function QueryBuilder(ByRef table As String, ByVal data As String, Optional ByVal where As String = "") As String
        Dim query As String
        'Data Read Query
        query = "SELECT " + data + " FROM " + table
        If where <> "" Then
            query += (" WHERE " + where + ";")
        Else
            query += ";"
        End If

        Debug.Print(query)
        Return query
    End Function


    ''Updates the user list as new users are added
    'Public Function UpdateUserList(ByRef list() As CAN_User) As Integer
    '    Dim i As Integer = 0
    '    Using db As New OleDbConnection(GetDB_Path())
    '        Dim query As String
    '        Dim cmd As OleDbCommand
    '        Dim reader As OleDbDataReader
    '        query = QueryBuilder("users", "*", "(((users.active)=True))")

    '        Try
    '            db.Open()
    '            cmd = New OleDbCommand(query, db)
    '            reader = cmd.ExecuteReader()

    '            While reader.Read()
    '                ReDim Preserve list(i + 1)
    '                list(i).id = reader(0).ToString()
    '                list(i).username = reader(1).ToString()
    '                list(i).firstName = reader(2).ToString()
    '                list(i).lastName = reader(3).ToString()
    '                list(i).active = reader(4).ToString()

    '                i += 1

    '            End While
    '            db.Close()

    '        Catch ex As Exception
    '            If db.State = ConnectionState.Open Then
    '                db.Close()
    '            End If

    '        End Try
    '    End Using
    '    Return i
    'End Function

    Function GetDB_Path() As String
        Return dBasePath
    End Function
End Class

