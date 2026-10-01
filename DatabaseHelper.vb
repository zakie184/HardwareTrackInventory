Imports MySql.Data.MySqlClient

Public Class DatabaseHelper

    ' ========================================
    ' USER OPERATIONS
    ' ========================================

    Public Shared Function GetUser(username As String) As DataTable
        Dim dt As New DataTable()
        Try
            Using conn As MySqlConnection = KeyData.GetConnection()
                conn.Open()
                Dim query As String = "SELECT * FROM Users WHERE Username = @Username"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@Username", username)
                    Dim adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Database error: " & ex.Message, "Connection Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return dt
    End Function

    Public Shared Function GetAllUsers() As DataTable
        Dim dt As New DataTable()
        Try
            Using conn As MySqlConnection = KeyData.GetConnection()
                conn.Open()
                Dim query As String = "SELECT * FROM Users ORDER BY FullName"
                Dim adapter As New MySqlDataAdapter(query, conn)
                adapter.Fill(dt)
            End Using
        Catch ex As Exception
        End Try
        Return dt
    End Function

    Public Shared Function AddUser(username As String, password As String, fullName As String, role As String, status As String) As Boolean
        Try
            Using conn As MySqlConnection = KeyData.GetConnection()
                conn.Open()
                Dim query As String = "INSERT INTO Users (Username, PasswordHash, FullName, Role, Status) VALUES (@u, @p, @f, @r, @s)"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@u", username)
                    cmd.Parameters.AddWithValue("@p", password)
                    cmd.Parameters.AddWithValue("@f", fullName)
                    cmd.Parameters.AddWithValue("@r", role)
                    cmd.Parameters.AddWithValue("@s", status)
                    Return cmd.ExecuteNonQuery() > 0
                End Using
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function UpdateLastLogin(username As String) As Boolean
        Try
            Using conn As MySqlConnection = KeyData.GetConnection()
                conn.Open()
                Dim query As String = "UPDATE Users SET LastLogin = NOW() WHERE Username = @u"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@u", username)
                    Return cmd.ExecuteNonQuery() > 0
                End Using
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function ToggleUserStatus(userID As Integer) As Boolean
        Try
            Using conn As MySqlConnection = KeyData.GetConnection()
                conn.Open()
                Dim query As String = "UPDATE Users SET Status = IF(Status='Active','Inactive','Active') WHERE UserID = @id"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@id", userID)
                    Return cmd.ExecuteNonQuery() > 0
                End Using
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function DeleteUser(userID As Integer) As Boolean
        Try
            Using conn As MySqlConnection = KeyData.GetConnection()
                conn.Open()
                Dim query As String = "DELETE FROM Users WHERE UserID = @id"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@id", userID)
                    Return cmd.ExecuteNonQuery() > 0
                End Using
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function ResetPassword(userID As Integer) As Boolean
        Try
            Using conn As MySqlConnection = KeyData.GetConnection()
                conn.Open()
                Dim query As String = "UPDATE Users SET PasswordHash = 'password123' WHERE UserID = @id"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@id", userID)
                    Return cmd.ExecuteNonQuery() > 0
                End Using
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function

    ' ========================================
    ' HARDWARE OPERATIONS
    ' ========================================

    Public Shared Function GetAllHardware() As DataTable
        Dim dt As New DataTable()
        Try
            Using conn As MySqlConnection = KeyData.GetConnection()
                conn.Open()
                Dim query As String = "SELECT * FROM Hardware ORDER BY Name"
                Dim adapter As New MySqlDataAdapter(query, conn)
                adapter.Fill(dt)
            End Using
        Catch ex As Exception
        End Try
        Return dt
    End Function

    Public Shared Function GetHardwareByID(id As Integer) As DataTable
        Dim dt As New DataTable()
        Try
            Using conn As MySqlConnection = KeyData.GetConnection()
                conn.Open()
                Dim query As String = "SELECT * FROM Hardware WHERE HardwareID = @id"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@id", id)
                    Dim adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        Catch ex As Exception
        End Try
        Return dt
    End Function

    Public Shared Function AddHardware(name As String, category As String, quantity As Integer, location As String, status As String) As Boolean
        Try
            Using conn As MySqlConnection = KeyData.GetConnection()
                conn.Open()
                Dim query As String = "INSERT INTO Hardware (Name, Category, Quantity, Location, Status) VALUES (@n, @c, @q, @l, @s)"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@n", name)
                    cmd.Parameters.AddWithValue("@c", category)
                    cmd.Parameters.AddWithValue("@q", quantity)
                    cmd.Parameters.AddWithValue("@l", location)
                    cmd.Parameters.AddWithValue("@s", status)
                    Return cmd.ExecuteNonQuery() > 0
                End Using
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function UpdateHardwareFull(id As Integer, name As String, category As String,
                                              quantity As Integer, location As String, status As String) As Boolean
        Try
            Using conn As MySqlConnection = KeyData.GetConnection()
                conn.Open()
                Dim query As String =
                    "UPDATE Hardware SET Name=@n, Category=@c, Quantity=@q, Location=@l, Status=@s WHERE HardwareID=@id"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@n", name)
                    cmd.Parameters.AddWithValue("@c", category)
                    cmd.Parameters.AddWithValue("@q", quantity)
                    cmd.Parameters.AddWithValue("@l", location)
                    cmd.Parameters.AddWithValue("@s", status)
                    cmd.Parameters.AddWithValue("@id", id)
                    Return cmd.ExecuteNonQuery() > 0
                End Using
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function DeleteHardware(id As Integer) As Boolean
        Try
            Using conn As MySqlConnection = KeyData.GetConnection()
                conn.Open()
                Dim query As String = "DELETE FROM Hardware WHERE HardwareID = @id"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@id", id)
                    Return cmd.ExecuteNonQuery() > 0
                End Using
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function UpdateHardwareStatus(id As Integer, status As String) As Boolean
        Try
            Using conn As MySqlConnection = KeyData.GetConnection()
                conn.Open()
                Dim query As String = "UPDATE Hardware SET Status = @s WHERE HardwareID = @id"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@s", status)
                    cmd.Parameters.AddWithValue("@id", id)
                    Return cmd.ExecuteNonQuery() > 0
                End Using
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function GetTotalCount() As Integer
        Try
            Using conn As MySqlConnection = KeyData.GetConnection()
                conn.Open()
                Dim query As String = "SELECT COUNT(*) FROM Hardware"
                Using cmd As New MySqlCommand(query, conn)
                    Return Convert.ToInt32(cmd.ExecuteScalar())
                End Using
            End Using
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Shared Function GetAvailableCount() As Integer
        Try
            Using conn As MySqlConnection = KeyData.GetConnection()
                conn.Open()
                Dim query As String = "SELECT COUNT(*) FROM Hardware WHERE Status = 'Available'"
                Using cmd As New MySqlCommand(query, conn)
                    Return Convert.ToInt32(cmd.ExecuteScalar())
                End Using
            End Using
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Shared Function GetAssignedCount() As Integer
        Try
            Using conn As MySqlConnection = KeyData.GetConnection()
                conn.Open()
                Dim query As String = "SELECT COUNT(*) FROM Hardware WHERE Status IN ('Assigned','In Use')"
                Using cmd As New MySqlCommand(query, conn)
                    Return Convert.ToInt32(cmd.ExecuteScalar())
                End Using
            End Using
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Shared Function GetLowStockItems() As DataTable
        Dim dt As New DataTable()
        Try
            Using conn As MySqlConnection = KeyData.GetConnection()
                conn.Open()
                Dim query As String = "SELECT Name, Quantity, Location FROM Hardware WHERE Quantity <= 5 ORDER BY Quantity ASC"
                Dim adapter As New MySqlDataAdapter(query, conn)
                adapter.Fill(dt)
            End Using
        Catch ex As Exception
        End Try
        Return dt
    End Function

    ' ========================================
    ' CATEGORIES OPERATIONS
    ' ========================================

    Public Shared Function GetAllCategories() As DataTable
        Dim dt As New DataTable()
        Try
            Using conn As MySqlConnection = KeyData.GetConnection()
                conn.Open()
                Dim query As String = "SELECT * FROM Categories ORDER BY Name"
                Dim adapter As New MySqlDataAdapter(query, conn)
                adapter.Fill(dt)
            End Using
        Catch ex As Exception
        End Try
        Return dt
    End Function

    Public Shared Function AddCategory(name As String, description As String) As Boolean
        Try
            Using conn As MySqlConnection = KeyData.GetConnection()
                conn.Open()
                Dim query As String = "INSERT INTO Categories (Name, Description) VALUES (@n, @d)"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@n", name)
                    cmd.Parameters.AddWithValue("@d", description)
                    Return cmd.ExecuteNonQuery() > 0
                End Using
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function DeleteCategory(id As Integer) As Boolean
        Try
            Using conn As MySqlConnection = KeyData.GetConnection()
                conn.Open()
                Dim query As String = "DELETE FROM Categories WHERE CategoryID = @id"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@id", id)
                    Return cmd.ExecuteNonQuery() > 0
                End Using
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function UpdateCategory(id As Integer, name As String, description As String) As Boolean
        Try
            Using conn As MySqlConnection = KeyData.GetConnection()
                conn.Open()
                Dim query As String = "UPDATE Categories SET Name = @n, Description = @d WHERE CategoryID = @id"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@n", name)
                    cmd.Parameters.AddWithValue("@d", description)
                    cmd.Parameters.AddWithValue("@id", id)
                    Return cmd.ExecuteNonQuery() > 0
                End Using
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function GetCategoryCount() As Integer
        Try
            Using conn As MySqlConnection = KeyData.GetConnection()
                conn.Open()
                Dim query As String = "SELECT COUNT(*) FROM Categories"
                Using cmd As New MySqlCommand(query, conn)
                    Return Convert.ToInt32(cmd.ExecuteScalar())
                End Using
            End Using
        Catch ex As Exception
            Return 0
        End Try
    End Function

    ' ========================================
    ' LOCATIONS OPERATIONS
    ' ========================================

    Public Shared Function GetAllLocations() As DataTable
        Dim dt As New DataTable()
        Try
            Using conn As MySqlConnection = KeyData.GetConnection()
                conn.Open()
                Dim query As String = "SELECT * FROM Locations ORDER BY Name"
                Dim adapter As New MySqlDataAdapter(query, conn)
                adapter.Fill(dt)
            End Using
        Catch ex As Exception
        End Try
        Return dt
    End Function

    Public Shared Function AddLocation(name As String, description As String) As Boolean
        Try
            Using conn As MySqlConnection = KeyData.GetConnection()
                conn.Open()
                Dim query As String = "INSERT INTO Locations (Name, Description) VALUES (@n, @d)"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@n", name)
                    cmd.Parameters.AddWithValue("@d", description)
                    Return cmd.ExecuteNonQuery() > 0
                End Using
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function DeleteLocation(id As Integer) As Boolean
        Try
            Using conn As MySqlConnection = KeyData.GetConnection()
                conn.Open()
                Dim query As String = "DELETE FROM Locations WHERE LocationID = @id"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@id", id)
                    Return cmd.ExecuteNonQuery() > 0
                End Using
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function UpdateLocation(id As Integer, name As String, description As String) As Boolean
        Try
            Using conn As MySqlConnection = KeyData.GetConnection()
                conn.Open()
                Dim query As String = "UPDATE Locations SET Name = @n, Description = @d WHERE LocationID = @id"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@n", name)
                    cmd.Parameters.AddWithValue("@d", description)
                    cmd.Parameters.AddWithValue("@id", id)
                    Return cmd.ExecuteNonQuery() > 0
                End Using
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function GetLocationCount() As Integer
        Try
            Using conn As MySqlConnection = KeyData.GetConnection()
                conn.Open()
                Dim query As String = "SELECT COUNT(*) FROM Locations"
                Using cmd As New MySqlCommand(query, conn)
                    Return Convert.ToInt32(cmd.ExecuteScalar())
                End Using
            End Using
        Catch ex As Exception
            Return 0
        End Try
    End Function

End Class