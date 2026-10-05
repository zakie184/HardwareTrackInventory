Imports System.Drawing

Public Class CategoriesControl
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
        LoadCategories()
    End Sub

    Public Sub RefreshData()
        LoadCategories()
    End Sub

    Private Sub ApplyPermissions()
        btnAdd.Enabled = currentUser IsNot Nothing AndAlso currentUser.CanEdit()
        btnRename.Enabled = False
        btnDelete.Enabled = False
    End Sub

    Private Sub LoadCategories()
        Try
            dgvCategories.DataSource = DatabaseHelper.GetAllCategories()
            If dgvCategories.Columns.Count > 0 Then
                dgvCategories.Columns(0).HeaderText = "ID"
                dgvCategories.Columns(1).HeaderText = "Name"
                dgvCategories.Columns(2).HeaderText = "Description"
                dgvCategories.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            End If
            ClearDetails()
            lblCount.Text = dgvCategories.RowCount & " records found"
        Catch ex As Exception
            MessageBox.Show("Error loading categories: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ClearDetails()
        lblName.Text = "Select a category"
        lblDesc.Text = ""
        btnRename.Enabled = False
        btnDelete.Enabled = False
        selectedID = -1
        selectedName = ""
        selectedDesc = ""
    End Sub

    Private Sub dgvCategories_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCategories.CellClick
        If e.RowIndex >= 0 Then
            Try
                Dim row As DataGridViewRow = dgvCategories.Rows(e.RowIndex)
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
                MessageBox.Show("Error selecting category: " & ex.Message, "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If currentUser Is Nothing OrElse Not currentUser.CanEdit() Then
            MessageBox.Show("Permission denied.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Using frm As New CategoryForm(currentUser, CategoryForm.FormMode.AddNew)
            If frm.ShowDialog(Me) = DialogResult.OK Then
                LoadCategories()
                MessageBox.Show("Category added successfully!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End Using
    End Sub

    Private Sub btnRename_Click(sender As Object, e As EventArgs) Handles btnRename.Click
        If selectedID = -1 Then
            MessageBox.Show("Please select a category first.", "No Selection",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If currentUser Is Nothing OrElse Not currentUser.CanEdit() Then
            MessageBox.Show("Permission denied.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Using frm As New CategoryForm(currentUser, CategoryForm.FormMode.RenameExisting,
                                      selectedID, selectedName, selectedDesc)
            If frm.ShowDialog(Me) = DialogResult.OK Then
                LoadCategories()
                MessageBox.Show("Category renamed successfully!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End Using
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If selectedID = -1 Then
            MessageBox.Show("Please select a category first.", "No Selection",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If currentUser Is Nothing OrElse Not currentUser.CanDelete() Then
            MessageBox.Show("You don't have permission to delete categories.", "Access Denied",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim result As DialogResult = MessageBox.Show(
            "Are you sure you want to delete category '" & selectedName & "'?" & vbCrLf &
            "This action cannot be undone.",
            "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If result = DialogResult.Yes Then
            Try
                If DatabaseHelper.DeleteCategory(selectedID) Then
                    ActivityLogger.Log(currentUser, "Deleted category '" & selectedName & "'",
                                       "Category", selectedID, False)
                    LoadCategories()
                    ClearDetails()
                    MessageBox.Show("Category deleted successfully!", "Deleted",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Failed to delete category. It may be referenced by hardware items.",
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MessageBox.Show("Error deleting category: " & ex.Message, "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadCategories()
    End Sub

End Class