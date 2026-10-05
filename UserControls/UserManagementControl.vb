Imports System.Drawing

Public Class UserManagementControl
    Inherits UserControl

    Private currentUser As User = Nothing
    Private selectedUserID As Integer = -1
    Private selectedUserName As String = ""
    Private usersList As List(Of User) = Nothing

    Public Sub New()
        InitializeComponent()
        SetupDataGridView()
        usersList = New List(Of User)()
        btnDelete.Enabled = False
    End Sub

    Private Sub SetupDataGridView()
        dgvUsers.Columns.Clear()

        dgvUsers.Columns.Add("colUserID", "USER ID")
        dgvUsers.Columns.Add("colUsername", "USERNAME")
        dgvUsers.Columns.Add("colFullName", "FULL NAME")
        dgvUsers.Columns.Add("colRole", "ROLE")
        dgvUsers.Columns.Add("colStatus", "STATUS")
        dgvUsers.Columns.Add("colLastLogin", "LAST LOGIN")

        dgvUsers.Columns(0).Width = 80
        dgvUsers.Columns(1).Width = 120
        dgvUsers.Columns(2).Width = 150
        dgvUsers.Columns(3).Width = 120
        dgvUsers.Columns(4).Width = 100
        dgvUsers.Columns(5).Width = 150

        dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        dgvUsers.AllowUserToAddRows = False
        dgvUsers.AllowUserToDeleteRows = False
        dgvUsers.ReadOnly = True
        dgvUsers.RowHeadersVisible = False
        dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub

    Public Sub SetCurrentUser(user As User)
        currentUser = user
        ApplyPermissions()
        LoadUsers()
    End Sub

    Public Sub RefreshData()
        LoadUsers()
    End Sub

    Private Sub ApplyPermissions()
        btnAdd.Enabled = currentUser IsNot Nothing AndAlso currentUser.CanDelete()
        btnToggle.Enabled = False
        btnResetPW.Enabled = False
        btnDelete.Enabled = False
    End Sub

    Private Sub LoadUsers()
        Try
            usersList = New List(Of User)()
            dgvUsers.Rows.Clear()

            Dim dt As DataTable = DatabaseHelper.GetAllUsers()

            For Each row As DataRow In dt.Rows
                Dim user As New User()
                user.ID = Convert.ToInt32(row("UserID"))
                user.Username = row("Username").ToString()
                user.FullName = row("FullName").ToString()
                user.Role = row("Role").ToString()
                user.IsActive = row("Status").ToString() = "Active"

                If row("LastLogin") IsNot DBNull.Value Then
                    user.LastLogin = Convert.ToDateTime(row("LastLogin"))
                Else
                    user.LastLogin = DateTime.MinValue
                End If

                usersList.Add(user)

                Dim rowIndex As Integer = dgvUsers.Rows.Add(
                    user.ID,
                    user.Username,
                    user.FullName,
                    user.Role,
                    If(user.IsActive, "Active", "Inactive"),
                    If(user.LastLogin = DateTime.MinValue, "Never", user.LastLogin.ToString("MMM dd, yyyy HH:mm"))
                )

                If user.IsActive Then
                    dgvUsers.Rows(rowIndex).Cells(4).Style.ForeColor = Color.Green
                Else
                    dgvUsers.Rows(rowIndex).Cells(4).Style.ForeColor = Color.Red
                End If
            Next

            If usersList.Count > 0 Then
                dgvUsers.Rows(0).Selected = True
                DisplayUserDetails(usersList(0))
            Else
                ClearDetails()
            End If

            lblCount.Text = usersList.Count & " records found"

        Catch ex As Exception
            MessageBox.Show("Error loading users: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DisplayUserDetails(user As User)
        If user Is Nothing Then
            ClearDetails()
            Return
        End If

        selectedUserID = user.ID
        selectedUserName = user.FullName

        lblName.Text = user.FullName
        lblRole.Text = "Role: " & user.Role
        lblStatus.Text = "Status: " & If(user.IsActive, "Active", "Inactive")

        If user.IsActive Then
            lblStatus.ForeColor = Color.Green
        Else
            lblStatus.ForeColor = Color.Red
        End If

        btnToggle.Enabled = currentUser IsNot Nothing AndAlso currentUser.CanDelete()
        btnResetPW.Enabled = currentUser IsNot Nothing AndAlso currentUser.CanDelete()
        btnDelete.Enabled = currentUser IsNot Nothing AndAlso currentUser.CanDelete()
    End Sub

    Private Sub ClearDetails()
        lblName.Text = "Select a user"
        lblRole.Text = ""
        lblStatus.Text = ""
        btnToggle.Enabled = False
        btnResetPW.Enabled = False
        btnDelete.Enabled = False
        selectedUserID = -1
        selectedUserName = ""
    End Sub

    Private Sub dgvUsers_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUsers.CellClick
        If e.RowIndex >= 0 AndAlso usersList IsNot Nothing AndAlso e.RowIndex < usersList.Count Then
            DisplayUserDetails(usersList(e.RowIndex))
        End If
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If usersList Is Nothing OrElse usersList.Count = 0 Then Return

        Dim searchText As String = txtSearch.Text.Trim().ToLower()

        If String.IsNullOrWhiteSpace(searchText) Then
            LoadUsers()
            Return
        End If

        Dim filtered As New List(Of User)()
        For Each u As User In usersList
            If u.Username.ToLower().Contains(searchText) OrElse
               u.FullName.ToLower().Contains(searchText) OrElse
               u.Role.ToLower().Contains(searchText) Then
                filtered.Add(u)
            End If
        Next

        dgvUsers.Rows.Clear()

        For Each user As User In filtered
            Dim rowIndex As Integer = dgvUsers.Rows.Add(
                user.ID,
                user.Username,
                user.FullName,
                user.Role,
                If(user.IsActive, "Active", "Inactive"),
                If(user.LastLogin = DateTime.MinValue, "Never", user.LastLogin.ToString("MMM dd, yyyy HH:mm"))
            )

            If user.IsActive Then
                dgvUsers.Rows(rowIndex).Cells(4).Style.ForeColor = Color.Green
            Else
                dgvUsers.Rows(rowIndex).Cells(4).Style.ForeColor = Color.Red
            End If
        Next

        If filtered.Count > 0 Then
            DisplayUserDetails(filtered(0))
        Else
            ClearDetails()
        End If

        lblCount.Text = filtered.Count & " records found"
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If currentUser Is Nothing OrElse Not currentUser.CanDelete() Then
            MessageBox.Show("Permission denied.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Using addForm As New AddUserForm()
            If addForm.ShowDialog() = DialogResult.OK Then
                If DatabaseHelper.AddUser(addForm.NewUsername, addForm.NewPassword,
                                          addForm.NewFullName, addForm.NewRole, addForm.NewStatus) Then
                    ActivityLogger.Log(currentUser,
                                       "Added new user '" & addForm.NewUsername & "' (" & addForm.NewRole & ")",
                                       "User", 0, False)
                    LoadUsers()
                    MessageBox.Show("User added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Failed to add user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End Using
    End Sub

    Private Sub btnToggle_Click(sender As Object, e As EventArgs) Handles btnToggle.Click
        If selectedUserID = -1 Then
            MessageBox.Show("Select a user first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If DatabaseHelper.ToggleUserStatus(selectedUserID) Then
            ActivityLogger.Log(currentUser, "Toggled status for user '" & selectedUserName & "'",
                               "User", selectedUserID, False)
            LoadUsers()
            MessageBox.Show("Status toggled!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnResetPW_Click(sender As Object, e As EventArgs) Handles btnResetPW.Click
        If selectedUserID = -1 Then
            MessageBox.Show("Select a user first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If DatabaseHelper.ResetPassword(selectedUserID) Then
            ActivityLogger.Log(currentUser, "Reset password for user '" & selectedUserName & "'",
                               "User", selectedUserID, False)
            MessageBox.Show("Password reset to 'password123'", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If selectedUserID = -1 Then
            MessageBox.Show("Please select a user first.", "No Selection",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If currentUser Is Nothing Then
            MessageBox.Show("You are not logged in.", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If Not currentUser.CanDelete() Then
            MessageBox.Show("You don't have permission to delete users.", "Access Denied",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If currentUser.ID = selectedUserID Then
            MessageBox.Show("You cannot delete your own account.", "Warning",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim userToDelete As User = Nothing
        For Each u As User In usersList
            If u.ID = selectedUserID Then
                userToDelete = u
                Exit For
            End If
        Next

        If userToDelete IsNot Nothing AndAlso userToDelete.Role = "Administrator" Then
            MessageBox.Show("Cannot delete an administrator account.", "Warning",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim result As DialogResult = MessageBox.Show(
            "Are you sure you want to delete user '" & selectedUserName & "'?" & vbCrLf &
            "This action cannot be undone.",
            "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If result = DialogResult.Yes Then
            Try
                If DatabaseHelper.DeleteUser(selectedUserID) Then
                    ActivityLogger.Log(currentUser, "Deleted user '" & selectedUserName & "'",
                                       "User", selectedUserID, False)
                    LoadUsers()
                    ClearDetails()
                    MessageBox.Show("User deleted successfully!", "Deleted",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Failed to delete user.", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MessageBox.Show("Error deleting user: " & ex.Message, "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadUsers()
        txtSearch.Clear()
    End Sub

End Class