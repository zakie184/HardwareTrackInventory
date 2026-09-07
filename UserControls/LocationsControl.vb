Imports MySql.Data.MySqlClient
Imports System.Drawing

Public Class LocationsControl
    Inherits UserControl

    Private currentUser As User = Nothing
    Private selectedID As Integer = -1
    Private selectedName As String = ""

    Public Sub New()
        InitializeComponent()
        btnDelete.Enabled = False
    End Sub

    Public Sub SetCurrentUser(user As User)
        currentUser = user
        ApplyPermissions()
        LoadLocations()
    End Sub

    Public Sub RefreshData()
        LoadLocations()
    End Sub

    Private Sub ApplyPermissions()
        btnAdd.Enabled = currentUser IsNot Nothing AndAlso currentUser.CanEdit()
        btnEdit.Enabled = False
        btnDelete.Enabled = False
    End Sub

    Private Sub LoadLocations()
        Try
            dgvLocations.DataSource = DatabaseHelper.GetAllLocations()
            If dgvLocations.Columns.Count > 0 Then
                dgvLocations.Columns(0).HeaderText = "ID"
                dgvLocations.Columns(1).HeaderText = "Name"
                dgvLocations.Columns(2).HeaderText = "Description"
                dgvLocations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            End If
            ClearDetails()
            lblCount.Text = dgvLocations.RowCount & " records found"
        Catch ex As Exception
            MessageBox.Show("Error loading locations: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ClearDetails()
        lblName.Text = "Select a location"
        lblDesc.Text = ""
        btnEdit.Enabled = False
        btnDelete.Enabled = False
        selectedID = -1
        selectedName = ""
    End Sub

    Private Sub dgvLocations_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLocations.CellClick
        If e.RowIndex >= 0 Then
            Try
                Dim row As DataGridViewRow = dgvLocations.Rows(e.RowIndex)
                selectedID = Convert.ToInt32(row.Cells(0).Value)
                selectedName = row.Cells(1).Value.ToString()
                lblName.Text = row.Cells(1).Value.ToString()
                lblDesc.Text = "Description: " & row.Cells(2).Value.ToString()
                btnEdit.Enabled = currentUser IsNot Nothing AndAlso currentUser.CanEdit()
                btnDelete.Enabled = currentUser IsNot Nothing AndAlso currentUser.CanDelete()
            Catch ex As Exception
                MessageBox.Show("Error selecting location: " & ex.Message, "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not currentUser.CanEdit() Then
            MessageBox.Show("Permission denied.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim name As String = InputBox("Enter location name:", "Add Location")
        If String.IsNullOrWhiteSpace(name) Then Return
        Dim desc As String = InputBox("Enter description:", "Add Location")

        If DatabaseHelper.AddLocation(name, desc) Then
            LoadLocations()
            MessageBox.Show("Location added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Failed to add location.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If selectedID = -1 Then
            MessageBox.Show("Select a location first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim name As String = InputBox("Enter new name:", "Edit Location", selectedName)
        If String.IsNullOrWhiteSpace(name) Then Return
        Dim desc As String = InputBox("Enter new description:", "Edit Location", lblDesc.Text.Replace("Description: ", ""))

        If DatabaseHelper.UpdateLocation(selectedID, name, desc) Then
            LoadLocations()
            MessageBox.Show("Location updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Failed to update location.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    ' ============================================================
    ' ✅ DELETE BUTTON - FULLY WORKING
    ' ============================================================
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If selectedID = -1 Then
            MessageBox.Show("Please select a location first.", "No Selection",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If currentUser Is Nothing OrElse Not currentUser.CanDelete() Then
            MessageBox.Show("You don't have permission to delete locations.", "Access Denied",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim result As DialogResult = MessageBox.Show(
            $"Are you sure you want to delete location '{selectedName}'?" & vbCrLf &
            "This action cannot be undone.",
            "Confirm Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning
        )

        If result = DialogResult.Yes Then
            Try
                If DatabaseHelper.DeleteLocation(selectedID) Then
                    LoadLocations()
                    ClearDetails()
                    MessageBox.Show("Location deleted successfully!", "Deleted",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Failed to delete location. It may be referenced by hardware items.",
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MessageBox.Show("Error deleting location: " & ex.Message, "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadLocations()
    End Sub

End Class