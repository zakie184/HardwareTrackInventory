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
    ' HARDWARE
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

    Public Shared Function AddHardware(name As String, category As String, quantity As Integer,
                                       location As String, status As String, notes As String) As Boolean
        Try
            Using conn As MySqlConnection = KeyData.GetConnection()
                conn.Open()
                Dim query As String = "INSERT INTO Hardware (Name, Category, Quantity, Location, Status, Notes) " &
                                      "VALUES (@n, @c, @q, @l, @s, @notes)"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@n", name)
                    cmd.Parameters.AddWithValue("@c", category)
                    cmd.Parameters.AddWithValue("@q", quantity)
                    cmd.Parameters.AddWithValue("@l", location)
                    cmd.Parameters.AddWithValue("@s", status)
                    cmd.Parameters.AddWithValue("@notes", If(String.IsNullOrEmpty(notes), CObj(DBNull.Value), notes))
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

    Public Shared Function GetTotalCount() As Integer
        Try
            Using conn As MySqlConnection = KeyData.GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand("SELECT COUNT(*) FROM Hardware", conn)
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
                Using cmd As New MySqlCommand("SELECT COUNT(*) FROM Hardware WHERE Status = 'Available'", conn)
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
                Using cmd As New MySqlCommand("SELECT COUNT(*) FROM Hardware WHERE Status IN ('Assigned','In Use')", conn)
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
                Dim adapter As New MySqlDataAdapter("SELECT Name, Quantity, Location FROM Hardware WHERE Quantity <= 5 ORDER BY Quantity ASC", conn)
                adapter.Fill(dt)
            End Using
        Catch ex As Exception
        End Try
        Return dt
    End Function

    ' ========================================
    ' ISSUANCE
    ' ========================================

    Public Shared Function IssueHardware(hardwareID As Integer, itemName As String, quantity As Integer,
                                         issuedTo As String, department As String, purpose As String,
                                         expectedReturn As DateTime?, issuedBy As String, notes As String,
                                         requiresApproval As Boolean) As Boolean
        Try
            Using conn As MySqlConnection = KeyData.GetConnection()
                conn.Open()
                Using trans As MySqlTransaction = conn.BeginTransaction()
                    Try
                        Dim stock As Integer = 0
                        Using cmd As New MySqlCommand("SELECT Quantity FROM Hardware WHERE HardwareID = @id", conn, trans)
                            cmd.Parameters.AddWithValue("@id", hardwareID)
                            Dim result As Object = cmd.ExecuteScalar()
                            If result Is Nothing OrElse result Is DBNull.Value Then
                                trans.Rollback()
                                Return False
                            End If
                            stock = Convert.ToInt32(result)
                        End Using

                        If stock < quantity Then
                            trans.Rollback()
                            Return False
                        End If

                        Dim approvalStatus As String = If(requiresApproval, "Pending", "Approved")
                        Dim initialStatus As String = If(requiresApproval, "Pending", "Issued")

                        Dim insQuery As String =
                            "INSERT INTO Issuances (HardwareID, ItemName, QuantityIssued, IssuedTo, Department, " &
                            "Purpose, IssuedBy, ExpectedReturn, Notes, Status, ApprovalStatus, ApprovedBy, ApprovalDate) " &
                            "VALUES (@hid, @name, @qty, @to, @dept, @purp, @by, @exp, @notes, @st, @appr, @apprby, @apprdate)"

                        Using cmd As New MySqlCommand(insQuery, conn, trans)
                            cmd.Parameters.AddWithValue("@hid", hardwareID)
                            cmd.Parameters.AddWithValue("@name", itemName)
                            cmd.Parameters.AddWithValue("@qty", quantity)
                            cmd.Parameters.AddWithValue("@to", issuedTo)
                            cmd.Parameters.AddWithValue("@dept", If(String.IsNullOrEmpty(department), CObj(DBNull.Value), department))
                            cmd.Parameters.AddWithValue("@purp", If(String.IsNullOrEmpty(purpose), CObj(DBNull.Value), purpose))
                            cmd.Parameters.AddWithValue("@by", issuedBy)
                            If expectedReturn.HasValue Then
                                cmd.Parameters.AddWithValue("@exp", expectedReturn.Value)
                            Else
                                cmd.Parameters.AddWithValue("@exp", DBNull.Value)
                            End If
                            cmd.Parameters.AddWithValue("@notes", If(String.IsNullOrEmpty(notes), CObj(DBNull.Value), notes))
                            cmd.Parameters.AddWithValue("@st", initialStatus)
                            cmd.Parameters.AddWithValue("@appr", approvalStatus)

                            If requiresApproval Then
                                cmd.Parameters.AddWithValue("@apprby", DBNull.Value)
                                cmd.Parameters.AddWithValue("@apprdate", DBNull.Value)
                            Else
                                cmd.Parameters.AddWithValue("@apprby", issuedBy)
                                cmd.Parameters.AddWithValue("@apprdate", DateTime.Now)
                            End If

                            cmd.ExecuteNonQuery()
                        End Using

                        If Not requiresApproval Then
                            Using cmd As New MySqlCommand("UPDATE Hardware SET Quantity = Quantity - @qty WHERE HardwareID = @id", conn, trans)
                                cmd.Parameters.AddWithValue("@qty", quantity)
                                cmd.Parameters.AddWithValue("@id", hardwareID)
                                cmd.ExecuteNonQuery()
                            End Using
                        End If

                        trans.Commit()
                        Return True
                    Catch
                        Try
                            trans.Rollback()
                        Catch
                        End Try
                        Return False
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function ApproveIssuance(issuanceID As Integer, approvedBy As String) As Boolean
        Try
            Using conn As MySqlConnection = KeyData.GetConnection()
                conn.Open()
                Using trans As MySqlTransaction = conn.BeginTransaction()
                    Try
                        Dim hardwareID As Integer = 0
                        Dim qty As Integer = 0
                        Dim apprStatus As String = ""

                        Using cmd As New MySqlCommand("SELECT HardwareID, QuantityIssued, ApprovalStatus FROM Issuances WHERE IssuanceID = @id", conn, trans)
                            cmd.Parameters.AddWithValue("@id", issuanceID)
                            Using r As MySqlDataReader = cmd.ExecuteReader()
                                If Not r.Read() Then
                                    r.Close()
                                    trans.Rollback()
                                    Return False
                                End If
                                hardwareID = Convert.ToInt32(r("HardwareID"))
                                qty = Convert.ToInt32(r("QuantityIssued"))
                                apprStatus = r("ApprovalStatus").ToString()
                                r.Close()
                            End Using
                        End Using

                        If apprStatus <> "Pending" Then
                            trans.Rollback()
                            Return False
                        End If

                        Dim stock As Integer = 0
                        Using cmd As New MySqlCommand("SELECT Quantity FROM Hardware WHERE HardwareID = @id", conn, trans)
                            cmd.Parameters.AddWithValue("@id", hardwareID)
                            stock = Convert.ToInt32(cmd.ExecuteScalar())
                        End Using

                        If stock < qty Then
                            trans.Rollback()
                            Return False
                        End If

                        Using cmd As New MySqlCommand("UPDATE Hardware SET Quantity = Quantity - @qty WHERE HardwareID = @id", conn, trans)
                            cmd.Parameters.AddWithValue("@qty", qty)
                            cmd.Parameters.AddWithValue("@id", hardwareID)
                            cmd.ExecuteNonQuery()
                        End Using

                        Using cmd As New MySqlCommand(
                            "UPDATE Issuances SET ApprovalStatus='Approved', Status='Issued', ApprovedBy=@by, ApprovalDate=NOW() WHERE IssuanceID=@id", conn, trans)
                            cmd.Parameters.AddWithValue("@by", approvedBy)
                            cmd.Parameters.AddWithValue("@id", issuanceID)
                            cmd.ExecuteNonQuery()
                        End Using

                        trans.Commit()
                        Return True
                    Catch
                        Try
                            trans.Rollback()
                        Catch
                        End Try
                        Return False
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function RejectIssuance(issuanceID As Integer, rejectedBy As String, reason As String) As Boolean
        Try
            Using conn As MySqlConnection = KeyData.GetConnection()
                conn.Open()
                Dim q As String =
                    "UPDATE Issuances SET ApprovalStatus='Rejected', Status='Rejected', " &
                    "ApprovedBy=@by, ApprovalDate=NOW(), RejectionReason=@reason " &
                    "WHERE IssuanceID=@id AND ApprovalStatus='Pending'"
                Using cmd As New MySqlCommand(q, conn)
                    cmd.Parameters.AddWithValue("@by", rejectedBy)
                    cmd.Parameters.AddWithValue("@reason", If(String.IsNullOrEmpty(reason), CObj(DBNull.Value), reason))
                    cmd.Parameters.AddWithValue("@id", issuanceID)
                    Return cmd.ExecuteNonQuery() > 0
                End Using
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function GetPendingApprovalCount() As Integer
        Try
            Using conn As MySqlConnection = KeyData.GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand("SELECT COUNT(*) FROM Issuances WHERE ApprovalStatus='Pending'", conn)
                    Return Convert.ToInt32(cmd.ExecuteScalar())
                End Using
            End Using
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Shared Function GetPendingIssuances() As DataTable
        Dim dt As New DataTable()
        Try
            Using conn As MySqlConnection = KeyData.GetConnection()
                conn.Open()
                Dim q As String =
                    "SELECT IssuanceID, HardwareID, ItemName, QuantityIssued, IssuedTo, Department, " &
                    "Purpose, IssuedBy, DateIssued, ExpectedReturn, Notes " &
                    "FROM Issuances WHERE ApprovalStatus='Pending' ORDER BY DateIssued ASC"
                Dim adapter As New MySqlDataAdapter(q, conn)
                adapter.Fill(dt)
            End Using
        Catch ex As Exception
        End Try
        Return dt
    End Function

    Public Shared Function ReturnHardware(issuanceID As Integer, quantityToReturn As Integer, returnNotes As String) As Boolean
        Try
            Using conn As MySqlConnection = KeyData.GetConnection()
                conn.Open()
                Using trans As MySqlTransaction = conn.BeginTransaction()
                    Try
                        Dim hardwareID As Integer = 0
                        Dim quantityIssued As Integer = 0
                        Dim quantityReturned As Integer = 0
                        Dim apprStatus As String = ""

                        Using cmd As New MySqlCommand("SELECT HardwareID, QuantityIssued, QuantityReturned, ApprovalStatus FROM Issuances WHERE IssuanceID = @id", conn, trans)
                            cmd.Parameters.AddWithValue("@id", issuanceID)
                            Using r As MySqlDataReader = cmd.ExecuteReader()
                                If Not r.Read() Then
                                    r.Close()
                                    trans.Rollback()
                                    Return False
                                End If
                                hardwareID = Convert.ToInt32(r("HardwareID"))
                                quantityIssued = Convert.ToInt32(r("QuantityIssued"))
                                quantityReturned = Convert.ToInt32(r("QuantityReturned"))
                                apprStatus = r("ApprovalStatus").ToString()
                                r.Close()
                            End Using
                        End Using

                        If apprStatus <> "Approved" Then
                            trans.Rollback()
                            Return False
                        End If

                        Dim newReturned As Integer = quantityReturned + quantityToReturn
                        If newReturned > quantityIssued Then
                            trans.Rollback()
                            Return False
                        End If

                        Dim newStatus As String = If(newReturned >= quantityIssued, "Returned", "Partial")

                        Dim updateQ As String
                        If newReturned >= quantityIssued Then
                            updateQ = "UPDATE Issuances SET QuantityReturned = @qr, Status = @st, ReturnNotes = @rn, DateReturned = NOW() WHERE IssuanceID = @id"
                        Else
                            updateQ = "UPDATE Issuances SET QuantityReturned = @qr, Status = @st, ReturnNotes = @rn WHERE IssuanceID = @id"
                        End If

                        Using cmd As New MySqlCommand(updateQ, conn, trans)
                            cmd.Parameters.AddWithValue("@qr", newReturned)
                            cmd.Parameters.AddWithValue("@st", newStatus)
                            cmd.Parameters.AddWithValue("@rn", If(String.IsNullOrEmpty(returnNotes), CObj(DBNull.Value), returnNotes))
                            cmd.Parameters.AddWithValue("@id", issuanceID)
                            cmd.ExecuteNonQuery()
                        End Using

                        Using cmd As New MySqlCommand("UPDATE Hardware SET Quantity = Quantity + @qty WHERE HardwareID = @id", conn, trans)
                            cmd.Parameters.AddWithValue("@qty", quantityToReturn)
                            cmd.Parameters.AddWithValue("@id", hardwareID)
                            cmd.ExecuteNonQuery()
                        End Using

                        trans.Commit()
                        Return True
                    Catch
                        Try
                            trans.Rollback()
                        Catch
                        End Try
                        Return False
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function GetAllIssuances() As DataTable
        Dim dt As New DataTable()
        Try
            Using conn As MySqlConnection = KeyData.GetConnection()
                conn.Open()
                Dim q As String =
                    "SELECT IssuanceID, HardwareID, ItemName, QuantityIssued, QuantityReturned, " &
                    "IssuedTo, Department, Purpose, IssuedBy, DateIssued, ExpectedReturn, " &
                    "DateReturned, Status, Notes, ReturnNotes, ApprovalStatus, ApprovedBy, " &
                    "ApprovalDate, RejectionReason " &
                    "FROM Issuances ORDER BY DateIssued DESC"
                Dim adapter As New MySqlDataAdapter(q, conn)
                adapter.Fill(dt)
            End Using
        Catch ex As Exception
        End Try
        Return dt
    End Function

    ' ========================================
    ' CATEGORIES
    ' ========================================

    Public Shared Function GetAllCategories() As DataTable
        Dim dt As New DataTable()
        Try
            Using conn As MySqlConnection = KeyData.GetConnection()
                conn.Open()
                Dim adapter As New MySqlDataAdapter("SELECT * FROM Categories ORDER BY Name", conn)
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
                Using cmd As New MySqlCommand("INSERT INTO Categories (Name, Description) VALUES (@n, @d)", conn)
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
                Using cmd As New MySqlCommand("DELETE FROM Categories WHERE CategoryID = @id", conn)
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
                Using cmd As New MySqlCommand("UPDATE Categories SET Name = @n, Description = @d WHERE CategoryID = @id", conn)
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
                Using cmd As New MySqlCommand("SELECT COUNT(*) FROM Categories", conn)
                    Return Convert.ToInt32(cmd.ExecuteScalar())
                End Using
            End Using
        Catch ex As Exception
            Return 0
        End Try
    End Function

    ' ========================================
    ' LOCATIONS
    ' ========================================

    Public Shared Function GetAllLocations() As DataTable
        Dim dt As New DataTable()
        Try
            Using conn As MySqlConnection = KeyData.GetConnection()
                conn.Open()
                Dim adapter As New MySqlDataAdapter("SELECT * FROM Locations ORDER BY Name", conn)
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
                Using cmd As New MySqlCommand("INSERT INTO Locations (Name, Description) VALUES (@n, @d)", conn)
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
                Using cmd As New MySqlCommand("DELETE FROM Locations WHERE LocationID = @id", conn)
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
                Using cmd As New MySqlCommand("UPDATE Locations SET Name = @n, Description = @d WHERE LocationID = @id", conn)
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
                Using cmd As New MySqlCommand("SELECT COUNT(*) FROM Locations", conn)
                    Return Convert.ToInt32(cmd.ExecuteScalar())
                End Using
            End Using
        Catch ex As Exception
            Return 0
        End Try
    End Function

End Class