Imports System.Drawing

Public Class LocationsControl
    Inherits UserControl

    Private currentUser As User = Nothing
    Private selectedID As Integer = -1
    Private selectedName As String = ""
    Private selectedDesc As String = ""

    Public Sub New()
        InitializeComponent()
        btnDelete.Enabled = False
        btnRename.Enabled = False
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
        btnRename.Enabled = False
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
        btnRename.Enabled = False
        btnDelete.Enabled = False
        selectedID = -1
        selectedName = ""
        selectedDesc = ""
    End Sub

    Private Sub dgvLocations_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLocations.CellClick
        If e.RowIndex >= 0 Then
            Try
                Dim row As DataGridViewRow = dgvLocations.Rows(e.RowIndex)
                selectedID = Convert.ToInt32(row.Cells(0).Value)
                selectedName = row.Cells(1).Value.ToString()

                selectedDesc = ""
                If row.Cells(2).Value IsNot DBNull.Value Then
                    selectedDesc = row.Cells(2).Value.ToString()
                End If

                lblName.Text = selectedName
                lblDesc.Text = "Description: " & selectedDesc

                Dim canEdit As Boolean = currentUser IsNot Nothing AndAlso currentUser.CanEdit()
                btnRename.Enabled = canEdit
                btnDelete.Enabled = currentUser IsNot Nothing AndAlso currentUser.CanDelete()
            Catch ex As Exception
                MessageBox.Show("Error selecting location: " & ex.Message, "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If currentUser Is Nothing OrElse Not currentUser.CanEdit() Then
            MessageBox.Show("Permission denied.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Using frm As New LocationForm(currentUser, LocationForm.FormMode.AddNew)
            If frm.ShowDialog(Me) = DialogResult.OK Then
                LoadLocations()
                MessageBox.Show("Location added successfully!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End Using
    End Sub

    Private Sub btnRename_Click(sender As Object, e As EventArgs) Handles btnRename.Click
        If selectedID = -1 Then
            MessageBox.Show("Please select a location first.", "No Selection",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If currentUser Is Nothing OrElse Not currentUser.CanEdit() Then
            MessageBox.Show("Permission denied.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Using frm As New LocationForm(currentUser, LocationForm.FormMode.RenameExisting,
                                      selectedID, selectedName, selectedDesc)
            If frm.ShowDialog(Me) = DialogResult.OK Then
                LoadLocations()
                MessageBox.Show("Location renamed successfully!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End Using
    End Sub

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
            "Are you sure you want to delete location '" & selectedName & "'?" & vbCrLf &
            "This action cannot be undone.",
            "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If result = DialogResult.Yes Then
            Try
                If DatabaseHelper.DeleteLocation(selectedID) Then
                    ActivityLogger.Log(currentUser, "Deleted location '" & selectedName & "'",
                                       "Location", selectedID, False)
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