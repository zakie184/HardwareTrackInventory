
Imports MySql.Data.MySqlClient


Public Class ActivityLogger

    Public Shared Sub Log(user As User, action As String,
                          Optional targetType As String = Nothing,
                          Optional targetID As Integer = 0,
                          Optional isGlobal As Boolean = False)

        If user Is Nothing OrElse String.IsNullOrWhiteSpace(action) Then Return

        Try
            Using conn As MySqlConnection = KeyData.GetConnection()
                conn.Open()
                Dim query As String =
                    "INSERT INTO Activities (UserID, Username, UserRole, Action, TargetType, TargetID, IsGlobal) " &
                    "VALUES (@uid, @un, @ur, @ac, @tt, @tid, @gl)"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@uid", user.ID)
                    cmd.Parameters.AddWithValue("@un", user.Username)
                    cmd.Parameters.AddWithValue("@ur", user.Role)
                    cmd.Parameters.AddWithValue("@ac", action)
                    cmd.Parameters.AddWithValue("@tt", If(targetType, CObj(DBNull.Value)))
                    cmd.Parameters.AddWithValue("@tid", targetID)
                    cmd.Parameters.AddWithValue("@gl", If(isGlobal, 1, 0))
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch
        End Try
    End Sub

    Public Shared Function GetActivitiesForUser(user As User, Optional limit As Integer = 20) As DataTable
        Dim dt As New DataTable()
        If user Is Nothing Then Return dt

        Try
            Using conn As MySqlConnection = KeyData.GetConnection()
                conn.Open()
                Dim query As String =
                    "SELECT ActivityDate, Username, UserRole, Action " &
                    "FROM Activities " &
                    "WHERE IsGlobal = 1 " &
                    "   OR UserRole = @role " &
                    "   OR Username = @un " &
                    "ORDER BY ActivityDate DESC " &
                    "LIMIT @lim"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@role", user.Role)
                    cmd.Parameters.AddWithValue("@un", user.Username)
                    cmd.Parameters.AddWithValue("@lim", limit)
                    Dim adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        Catch
        End Try

        Return dt
    End Function

End Class