Public Class ReturnsApprovalForm

    Private _user As User = Nothing

    Public Sub New(user As User)
        InitializeComponent()
        _user = user
    End Sub

    Private Sub ReturnsApprovalForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadPending()
        tmrRefresh.Start()
    End Sub

    Private Sub ReturnsApprovalForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        tmrRefresh.Stop()
    End Sub

    Private Sub tmrRefresh_Tick(sender As Object, e As EventArgs) Handles tmrRefresh.Tick
        LoadPending()
    End Sub

    Private Sub LoadPending()
        Try
            dgvPending.DataSource = DatabaseHelper.GetPendingReturns()

            If dgvPending.Columns.Count > 0 Then
                If dgvPending.Columns.Contains("IssuanceID") Then dgvPending.Columns("IssuanceID").Visible = False
                If dgvPending.Columns.Contains("Department") Then dgvPending.Columns("Department").Visible = False
                If dgvPending.Columns.Contains("DateIssued") Then dgvPending.Columns("DateIssued").Visible = False

                SetCol("ItemName", "Item", 180)
                SetCol("QuantityIssued", "Qty", 50)
                SetCol("IssuedTo", "Issued To", 130)
                SetCol("IssuedBy", "Issued By", 110)
                SetCol("ReturnRequestedBy", "Return Requested By", 140)
                SetCol("ReturnRequestDate", "Request Date", 130)
            End If

            If dgvPending.Rows.Count = 0 Then ClearDetails()
        Catch ex As Exception
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
        lblDepartment.Text = "--"
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
        If row.Cells("ReturnRequestedBy").Value IsNot DBNull.Value Then lblRequestedBy.Text = row.Cells("ReturnRequestedBy").Value.ToString()
        If row.Cells("IssuedTo").Value IsNot DBNull.Value Then lblIssuedTo.Text = row.Cells("IssuedTo").Value.ToString()
        If row.Cells("QuantityIssued").Value IsNot DBNull.Value Then lblQty.Text = row.Cells("QuantityIssued").Value.ToString()
        If row.Cells("Department").Value IsNot DBNull.Value Then lblDepartment.Text = row.Cells("Department").Value.ToString()

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
            "Approve return of " & qty & "x '" & itemName & "' from " & issuedTo & "?" & vbCrLf &
            "Stock will be added back to inventory.",
            "Confirm Return Approval", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If confirm <> DialogResult.Yes Then Return

        If DatabaseHelper.ApproveReturn(issuanceID, _user.Username) Then
            ActivityLogger.Log(_user,
                               "Approved return of " & qty & "x '" & itemName & "' from " & issuedTo,
                               "Hardware", 0, False)
            tmrRefresh.Stop()
            MessageBox.Show("Return approved and stock updated!", "Approved",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Else
            MessageBox.Show("Failed to approve return.", "Approval Failed",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnReject_Click(sender As Object, e As EventArgs) Handles btnReject.Click
        If dgvPending.SelectedRows.Count = 0 Then Return

        Dim row As DataGridViewRow = dgvPending.SelectedRows(0)
        Dim issuanceID As Integer = Convert.ToInt32(row.Cells("IssuanceID").Value)
        Dim itemName As String = row.Cells("ItemName").Value.ToString()
        Dim issuedTo As String = row.Cells("IssuedTo").Value.ToString()

        Dim confirm As DialogResult = MessageBox.Show(
            "Reject the return request for '" & itemName & "' from " & issuedTo & "?",
            "Confirm Rejection", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If confirm <> DialogResult.Yes Then Return

        If DatabaseHelper.RejectReturn(issuanceID, _user.Username) Then
            ActivityLogger.Log(_user,
                               "Rejected return of '" & itemName & "' from " & issuedTo,
                               "Hardware", 0, False)
            tmrRefresh.Stop()
            MessageBox.Show("Return request rejected.", "Rejected",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Else
            MessageBox.Show("Failed to reject return.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadPending()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        tmrRefresh.Stop()
        Me.Close()
    End Sub

End Class