Imports System.Drawing

Public Class HardwareControl
    Inherits UserControl

    Private currentUser As User = Nothing
    Private selectedID As Integer = -1
    Private selectedName As String = ""
    Private selectedStock As Integer = 0

    Public Sub New()
        InitializeComponent()
        btnDelete.Enabled = False
        btnIssue.Enabled = False
    End Sub

    Public Sub SetCurrentUser(user As User)
        currentUser = user
        ApplyPermissions()
        LoadHardware()
    End Sub

    Public Sub RefreshData()
        LoadHardware()
        RefreshBadges()
    End Sub

    Private Sub ApplyPermissions()
        If currentUser Is Nothing Then Return

        btnAdd.Enabled = currentUser.CanEdit()
        btnIssue.Enabled = False
        btnDelete.Enabled = False

        btnHistory.Visible = currentUser.CanViewIssuanceHistory()
        btnApprovals.Visible = currentUser.CanApproveIssuance()
        btnReturns.Visible = currentUser.CanApproveReturn()

        RefreshBadges()
    End Sub

    Private Sub RefreshBadges()
        If currentUser Is Nothing Then Return

        If currentUser.CanApproveIssuance() Then
            Try
                Dim count As Integer = DatabaseHelper.GetPendingApprovalCount()
                If count > 0 Then
                    btnApprovals.Text = "🔐 Approvals (" & count & ")"
                    btnApprovals.BackColor = Color.FromArgb(231, 76, 60)
                    btnApprovals.ForeColor = Color.White
                Else
                    btnApprovals.Text = "🔐 Approvals"
                    btnApprovals.BackColor = Color.FromArgb(241, 196, 15)
                    btnApprovals.ForeColor = Color.FromArgb(44, 62, 80)
                End If
            Catch
            End Try
        End If

        If currentUser.CanApproveReturn() Then
            Try
                Dim retCount As Integer = DatabaseHelper.GetPendingReturnCount()
                If retCount > 0 Then
                    btnReturns.Text = "📥 Returns (" & retCount & ")"
                    btnReturns.BackColor = Color.FromArgb(231, 76, 60)
                    btnReturns.ForeColor = Color.White
                Else
                    btnReturns.Text = "📥 Returns"
                    btnReturns.BackColor = Color.FromArgb(155, 89, 182)
                    btnReturns.ForeColor = Color.White
                End If
            Catch
            End Try
        End If
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
                        Case "Maintenance" : row.Cells(5).Style.ForeColor = Color.OrangeRed
                        Case "Retired" : row.Cells(5).Style.ForeColor = Color.Gray
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
        btnIssue.Enabled = False
        btnDelete.Enabled = False
        selectedID = -1
        selectedName = ""
        selectedStock = 0
    End Sub

    Private Sub dgvHardware_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvHardware.CellClick
        If e.RowIndex >= 0 Then
            Try
                Dim row As DataGridViewRow = dgvHardware.Rows(e.RowIndex)
                selectedID = Convert.ToInt32(row.Cells(0).Value)
                selectedName = row.Cells(1).Value.ToString()
                selectedStock = Convert.ToInt32(row.Cells(3).Value)

                lblName.Text = row.Cells(1).Value.ToString()
                lblCategory.Text = "Category: " & row.Cells(2).Value.ToString()
                lblQty.Text = "Quantity: " & row.Cells(3).Value.ToString()
                lblLocation.Text = "Location: " & row.Cells(4).Value.ToString()
                lblStatus.Text = row.Cells(5).Value.ToString()

                Dim canRequest As Boolean = currentUser IsNot Nothing AndAlso currentUser.CanRequestIssuance()
                btnIssue.Enabled = canRequest AndAlso selectedStock > 0
                btnDelete.Enabled = currentUser IsNot Nothing AndAlso currentUser.CanDelete()
            Catch ex As Exception
                MessageBox.Show("Error selecting item: " & ex.Message, "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If currentUser Is Nothing OrElse Not currentUser.CanEdit() Then
            MessageBox.Show("Permission denied.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Using frm As New HardwareForm(currentUser)
            If frm.ShowDialog(Me) = DialogResult.OK Then
                LoadHardware()
                MessageBox.Show("Hardware added successfully!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End Using
    End Sub

    Private Sub btnIssue_Click(sender As Object, e As EventArgs) Handles btnIssue.Click
        If selectedID = -1 Then
            MessageBox.Show("Please select an item to issue first.",
                            "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If currentUser Is Nothing OrElse Not currentUser.CanRequestIssuance() Then
            MessageBox.Show("Permission denied. Viewers cannot request items.",
                            "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If selectedStock <= 0 Then
            MessageBox.Show("This item has no stock available to issue.",
                            "Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Using frm As New IssuanceForm(currentUser, selectedID, selectedName, selectedStock)
            If frm.ShowDialog(Me) = DialogResult.OK Then
                LoadHardware()
                RefreshBadges()
                If currentUser.Role = "Administrator" Then
                    MessageBox.Show("Item issued successfully!", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Request submitted! Waiting for Administrator approval.",
                                    "Pending Approval", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        End Using
    End Sub

    Private Sub btnApprovals_Click(sender As Object, e As EventArgs) Handles btnApprovals.Click
        If currentUser Is Nothing OrElse Not currentUser.CanApproveIssuance() Then
            MessageBox.Show("Only Administrators can access approvals.",
                            "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Using frm As New ApprovalsForm(currentUser)
            frm.ShowDialog(Me)
        End Using

        LoadHardware()
        RefreshBadges()
    End Sub

    Private Sub btnReturns_Click(sender As Object, e As EventArgs) Handles btnReturns.Click
        If currentUser Is Nothing OrElse Not currentUser.CanApproveReturn() Then
            MessageBox.Show("Only Administrators can access return approvals.",
                            "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Using frm As New ReturnsApprovalForm(currentUser)
            frm.ShowDialog(Me)
        End Using

        LoadHardware()
        RefreshBadges()
    End Sub

    Private Sub btnHistory_Click(sender As Object, e As EventArgs) Handles btnHistory.Click
        If currentUser Is Nothing Then Return

        If Not currentUser.CanViewIssuanceHistory() Then
            MessageBox.Show("You don't have permission to view issuance history.",
                            "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Using frm As New IssuanceHistoryForm(currentUser)
            frm.ShowDialog(Me)
        End Using
        LoadHardware()
        RefreshBadges()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If selectedID = -1 Then
            MessageBox.Show("Please select an item first.", "No Selection",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If currentUser Is Nothing OrElse Not currentUser.CanDelete() Then
            MessageBox.Show("You don't have permission to delete items.", "Access Denied",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim result As DialogResult = MessageBox.Show(
            "Are you sure you want to delete '" & selectedName & "'?" & vbCrLf &
            "This action cannot be undone.",
            "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If result = DialogResult.Yes Then
            Try
                If DatabaseHelper.DeleteHardware(selectedID) Then
                    ActivityLogger.Log(currentUser, "Deleted hardware '" & selectedName & "'",
                                       "Hardware", selectedID, False)
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
        RefreshBadges()
    End Sub

End Class