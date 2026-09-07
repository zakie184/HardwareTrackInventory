Imports MySql.Data.MySqlClient
Imports System.Drawing

Public Class HardwareControl
    Inherits UserControl

    Private currentUser As User = Nothing
    Private selectedID As Integer = -1
    Private selectedName As String = ""

    Public Sub New()
        InitializeComponent()
        ' Ensure delete button is enabled initially
        btnDelete.Enabled = False
    End Sub

    Public Sub SetCurrentUser(user As User)
        currentUser = user
        ApplyPermissions()
        LoadHardware()
    End Sub

    Public Sub RefreshData()
        LoadHardware()
    End Sub

    Private Sub ApplyPermissions()
        btnAdd.Enabled = currentUser IsNot Nothing AndAlso currentUser.CanEdit()
        btnEdit.Enabled = False
        btnDelete.Enabled = False
    End Sub

    Private Sub LoadHardware()
        Try
            dgvHardware.DataSource = DatabaseHelper.GetAllHardware()
            If dgvHardware.Columns.Count > 0 Then
                dgvHardware.Columns(0).HeaderText = "ID"
                dgvHardware.Columns(1).HeaderText = "Name"
                dgvHardware.Columns(2).HeaderText = "Category"
                dgvHardware.Columns(3).HeaderText = "Qty"
                dgvHardware.Columns(4).HeaderText = "Location"
                dgvHardware.Columns(5).HeaderText = "Status"
                dgvHardware.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

                For Each row As DataGridViewRow In dgvHardware.Rows
                    Dim status As String = row.Cells(5).Value.ToString()
                    Select Case status
                        Case "Available" : row.Cells(5).Style.ForeColor = Color.Green
                        Case "Assigned" : row.Cells(5).Style.ForeColor = Color.FromArgb(52, 152, 219)
                        Case "In Use" : row.Cells(5).Style.ForeColor = Color.FromArgb(241, 196, 15)
                        Case Else : row.Cells(5).Style.ForeColor = Color.Gray
                    End Select
                Next
            End If
            ClearDetails()
            lblCount.Text = dgvHardware.RowCount & " records found"
        Catch ex As Exception
            MessageBox.Show("Error loading hardware: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ClearDetails()
        lblName.Text = "Select an item"
        lblCategory.Text = ""
        lblQty.Text = ""
        lblLocation.Text = ""
        lblStatus.Text = ""
        btnEdit.Enabled = False
        btnDelete.Enabled = False
        selectedID = -1
        selectedName = ""
    End Sub

    Private Sub dgvHardware_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvHardware.CellClick
        If e.RowIndex >= 0 Then
            Try
                Dim row As DataGridViewRow = dgvHardware.Rows(e.RowIndex)
                selectedID = Convert.ToInt32(row.Cells(0).Value)
                selectedName = row.Cells(1).Value.ToString()
                lblName.Text = row.Cells(1).Value.ToString()
                lblCategory.Text = "Category: " & row.Cells(2).Value.ToString()
                lblQty.Text = "Quantity: " & row.Cells(3).Value.ToString()
                lblLocation.Text = "Location: " & row.Cells(4).Value.ToString()
                lblStatus.Text = row.Cells(5).Value.ToString()
                btnEdit.Enabled = currentUser IsNot Nothing AndAlso currentUser.CanEdit()
                btnDelete.Enabled = currentUser IsNot Nothing AndAlso currentUser.CanDelete()
            Catch ex As Exception
                MessageBox.Show("Error selecting item: " & ex.Message, "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not currentUser.CanEdit() Then
            MessageBox.Show("Permission denied.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim name As String = InputBox("Enter hardware name:", "Add Hardware")
        If String.IsNullOrWhiteSpace(name) Then Return
        Dim category As String = InputBox("Enter category:", "Add Hardware")
        Dim qty As String = InputBox("Enter quantity:", "Add Hardware")
        Dim location As String = InputBox("Enter location:", "Add Hardware")

        If DatabaseHelper.AddHardware(name, category, Convert.ToInt32(qty), location, "Available") Then
            LoadHardware()
            MessageBox.Show("Hardware added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Failed to add hardware.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If selectedID = -1 Then
            MessageBox.Show("Select an item first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim newStatus As String = InputBox("Enter new status (Available/Assigned/In Use):", "Update Status")
        If String.IsNullOrWhiteSpace(newStatus) Then Return

        If DatabaseHelper.UpdateHardwareStatus(selectedID, newStatus) Then
            LoadHardware()
            MessageBox.Show("Status updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Failed to update status.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    ' ============================================================
    ' ✅ DELETE BUTTON - FULLY WORKING
    ' ============================================================
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        ' Check if an item is selected
        If selectedID = -1 Then
            MessageBox.Show("Please select an item first.", "No Selection",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Check if user has permission
        If currentUser Is Nothing Then
            MessageBox.Show("You are not logged in.", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If Not currentUser.CanDelete() Then
            MessageBox.Show("You don't have permission to delete items.", "Access Denied",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Show confirmation dialog
        Dim result As DialogResult = MessageBox.Show(
            $"Are you sure you want to delete '{selectedName}'?" & vbCrLf &
            "This action cannot be undone.",
            "Confirm Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning
        )

        If result = DialogResult.Yes Then
            ' Attempt to delete
            Try
                If DatabaseHelper.DeleteHardware(selectedID) Then
                    LoadHardware()
                    ClearDetails()
                    MessageBox.Show("Item deleted successfully!", "Deleted",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Failed to delete item. It may be referenced elsewhere.",
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MessageBox.Show("Error deleting item: " & ex.Message, "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadHardware()
    End Sub

End Class