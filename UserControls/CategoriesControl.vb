Imports MySql.Data.MySqlClient
Imports System.Drawing

Public Class CategoriesControl
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
        LoadCategories()
    End Sub

    Public Sub RefreshData()
        LoadCategories()
    End Sub

    Private Sub ApplyPermissions()
        btnAdd.Enabled = currentUser IsNot Nothing AndAlso currentUser.CanEdit()
        btnEdit.Enabled = False
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
        btnEdit.Enabled = False
        btnDelete.Enabled = False
        selectedID = -1
        selectedName = ""
    End Sub

    Private Sub dgvCategories_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCategories.CellClick
        If e.RowIndex >= 0 Then
            Try
                Dim row As DataGridViewRow = dgvCategories.Rows(e.RowIndex)
                selectedID = Convert.ToInt32(row.Cells(0).Value)
                selectedName = row.Cells(1).Value.ToString()
                lblName.Text = row.Cells(1).Value.ToString()
                lblDesc.Text = "Description: " & row.Cells(2).Value.ToString()
                btnEdit.Enabled = currentUser IsNot Nothing AndAlso currentUser.CanEdit()
                btnDelete.Enabled = currentUser IsNot Nothing AndAlso currentUser.CanDelete()
            Catch ex As Exception
                MessageBox.Show("Error selecting category: " & ex.Message, "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not currentUser.CanEdit() Then
            MessageBox.Show("Permission denied.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim name As String = InputBox("Enter category name:", "Add Category")
        If String.IsNullOrWhiteSpace(name) Then Return
        Dim desc As String = InputBox("Enter description:", "Add Category")

        If DatabaseHelper.AddCategory(name, desc) Then
            LoadCategories()
            MessageBox.Show("Category added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Failed to add category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If selectedID = -1 Then
            MessageBox.Show("Select a category first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim name As String = InputBox("Enter new name:", "Edit Category", selectedName)
        If String.IsNullOrWhiteSpace(name) Then Return
        Dim desc As String = InputBox("Enter new description:", "Edit Category", lblDesc.Text.Replace("Description: ", ""))

        If DatabaseHelper.UpdateCategory(selectedID, name, desc) Then
            LoadCategories()
            MessageBox.Show("Category updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Failed to update category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    ' ============================================================
    ' ✅ DELETE BUTTON - FULLY WORKING
    ' ============================================================
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
            $"Are you sure you want to delete category '{selectedName}'?" & vbCrLf &
            "This action cannot be undone.",
            "Confirm Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning
        )

        If result = DialogResult.Yes Then
            Try
                If DatabaseHelper.DeleteCategory(selectedID) Then
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