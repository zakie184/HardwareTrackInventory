Public Class ApprovalsForm

    Private _user As User = Nothing

    Public Sub New(user As User)
        InitializeComponent()
        _user = user
    End Sub

    Private Sub ApprovalsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadPending()
    End Sub

    Private Sub LoadPending()
        Try
            dgvPending.DataSource = DatabaseHelper.GetPendingIssuances()

            If dgvPending.Columns.Count > 0 Then
                If dgvPending.Columns.Contains("IssuanceID") Then dgvPending.Columns("IssuanceID").Visible = False
                If dgvPending.Columns.Contains("HardwareID") Then dgvPending.Columns("HardwareID").Visible = False
                If dgvPending.Columns.Contains("ExpectedReturn") Then dgvPending.Columns("ExpectedReturn").Visible = False
                If dgvPending.Columns.Contains("Notes") Then dgvPending.Columns("Notes").Visible = False
                If dgvPending.Columns.Contains("Department") Then dgvPending.Columns("Department").Visible = False
                If dgvPending.Columns.Contains("Purpose") Then dgvPending.Columns("Purpose").Visible = False

                SetCol("ItemName", "Item", 200)
                SetCol("QuantityIssued", "Qty", 50)
                SetCol("IssuedTo", "Issued To", 140)
                SetCol("IssuedBy", "Requested By", 110)
                SetCol("DateIssued", "Requested", 130)
            End If

            If dgvPending.Rows.Count = 0 Then ClearDetails()
        Catch ex As Exception
            MessageBox.Show("Error loading pending approvals: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SetCol(name As String, header As String, width As Integer)
        If dgvPending.Columns.Contains(name) Then
            dgvPending.Columns(name).HeaderText = header
            dgvPending.Columns(name).Width = width
        End If
    End Sub

    Private Sub ClearDetails()
        lblItemName.Text = "--"
        lblRequestedBy.Text = "--"
        lblIssuedTo.Text = "--"
        lblQty.Text = "--"
        lblPurpose.Text = "--"
        btnApprove.Enabled = False
        btnReject.Enabled = False
    End Sub

    Private Sub dgvPending_SelectionChanged(sender As Object, e As EventArgs) Handles dgvPending.SelectionChanged
        If dgvPending.SelectedRows.Count = 0 Then
            ClearDetails()
            Return
        End If

        Dim row As DataGridViewRow = dgvPending.SelectedRows(0)

        If row.Cells("ItemName").Value IsNot DBNull.Value Then lblItemName.Text = row.Cells("ItemName").Value.ToString()
        If row.Cells("IssuedBy").Value IsNot DBNull.Value Then lblRequestedBy.Text = row.Cells("IssuedBy").Value.ToString()
        If row.Cells("IssuedTo").Value IsNot DBNull.Value Then lblIssuedTo.Text = row.Cells("IssuedTo").Value.ToString()
        If row.Cells("QuantityIssued").Value IsNot DBNull.Value Then lblQty.Text = row.Cells("QuantityIssued").Value.ToString()

        If row.Cells("Purpose").Value Is DBNull.Value Then
            lblPurpose.Text = "(no purpose stated)"
        Else
            lblPurpose.Text = row.Cells("Purpose").Value.ToString()
        End If

        btnApprove.Enabled = True
        btnReject.Enabled = True
    End Sub

    Private Sub btnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        If dgvPending.SelectedRows.Count = 0 Then Return

        Dim row As DataGridViewRow = dgvPending.SelectedRows(0)
        Dim issuanceID As Integer = Convert.ToInt32(row.Cells("IssuanceID").Value)
        Dim itemName As String = row.Cells("ItemName").Value.ToString()
        Dim issuedTo As String = row.Cells("IssuedTo").Value.ToString()
        Dim qty As Integer = Convert.ToInt32(row.Cells("QuantityIssued").Value)

        Dim confirm As DialogResult = MessageBox.Show(
            "Approve issuance of " & qty & "x '" & itemName & "' to " & issuedTo & "?",
            "Confirm Approval", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If confirm <> DialogResult.Yes Then Return

        If DatabaseHelper.ApproveIssuance(issuanceID, _user.Username) Then
            ActivityLogger.Log(_user,
                               "Approved issuance of " & qty & "x '" & itemName & "' to " & issuedTo,
                               "Hardware", 0, False)
            LoadPending()
            MessageBox.Show("Issuance approved and stock updated!", "Approved",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Failed to approve. The item may no longer have enough stock.",
                            "Approval Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnReject_Click(sender As Object, e As EventArgs) Handles btnReject.Click
        If dgvPending.SelectedRows.Count = 0 Then Return

        Dim row As DataGridViewRow = dgvPending.SelectedRows(0)
        Dim issuanceID As Integer = Convert.ToInt32(row.Cells("IssuanceID").Value)
        Dim itemName As String = row.Cells("ItemName").Value.ToString()
        Dim issuedTo As String = row.Cells("IssuedTo").Value.ToString()

        Dim reason As String = InputBox("Enter reason for rejection:", "Reject Issuance Request", "")
        If reason Is Nothing Then Return
        If String.IsNullOrWhiteSpace(reason) Then
            MessageBox.Show("A reason is required for rejection.", "Validation",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If DatabaseHelper.RejectIssuance(issuanceID, _user.Username, reason) Then
            ActivityLogger.Log(_user,
                               "Rejected issuance of '" & itemName & "' to " & issuedTo & " — Reason: " & reason,
                               "Hardware", 0, False)
            LoadPending()
            MessageBox.Show("Issuance request rejected.", "Rejected",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Failed to reject the issuance.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadPending()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

End Class