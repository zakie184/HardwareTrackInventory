Public Class ReceivingsApprovalForm

    Private _user As User = Nothing

    Public Sub New(user As User)
        InitializeComponent()
        _user = user
    End Sub

    Private Sub ReceivingsApprovalForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadPending()
        tmrRefresh.Start()
    End Sub

    Private Sub ReceivingsApprovalForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        tmrRefresh.Stop()
    End Sub

    Private Sub tmrRefresh_Tick(sender As Object, e As EventArgs) Handles tmrRefresh.Tick
        LoadPending()
    End Sub

    Private Sub LoadPending()
        Try
            dgvReceivings.DataSource = DatabaseHelper.GetPendingReceivings()

            If dgvReceivings.Columns.Count > 0 Then
                If dgvReceivings.Columns.Contains("ReceivingID") Then dgvReceivings.Columns("ReceivingID").Visible = False
                SetCol("Supplier", "Supplier", 140)
                SetCol("ReceivedBy", "Requested By", 110)
                SetCol("DateReceived", "Date", 130)
                If dgvReceivings.Columns.Contains("Notes") Then dgvReceivings.Columns("Notes").Visible = False
            End If

            If dgvReceivings.Rows.Count = 0 Then ClearDetails()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SetCol(name As String, header As String, width As Integer)
        If dgvReceivings.Columns.Contains(name) Then
            dgvReceivings.Columns(name).HeaderText = header
            dgvReceivings.Columns(name).Width = width
        End If
    End Sub

    Private Sub ClearDetails()
        lblSupplier.Text = "Supplier: --"
        lblReceivedBy.Text = "Received By: --"
        lblNotes.Text = "Notes: --"
        dgvDetailItems.DataSource = Nothing
        btnApprove.Enabled = False
        btnReject.Enabled = False
    End Sub

    Private Sub dgvReceivings_SelectionChanged(sender As Object, e As EventArgs) Handles dgvReceivings.SelectionChanged
        If dgvReceivings.SelectedRows.Count = 0 Then
            ClearDetails()
            Return
        End If

        Dim row As DataGridViewRow = dgvReceivings.SelectedRows(0)
        Dim rid As Integer = Convert.ToInt32(row.Cells("ReceivingID").Value)

        Dim supplier As String = "(none)"
        If row.Cells("Supplier").Value IsNot DBNull.Value Then
            supplier = row.Cells("Supplier").Value.ToString()
        End If

        lblSupplier.Text = "Supplier: " & supplier
        lblReceivedBy.Text = "Received By: " & row.Cells("ReceivedBy").Value.ToString()

        If row.Cells("Notes").Value IsNot DBNull.Value Then
            lblNotes.Text = "Notes: " & row.Cells("Notes").Value.ToString()
        Else
            lblNotes.Text = "Notes: --"
        End If

        Try
            dgvDetailItems.DataSource = DatabaseHelper.GetReceivingItems(rid)
            If dgvDetailItems.Columns.Count > 0 Then
                dgvDetailItems.Columns("IsNewItem").Visible = False
                If dgvDetailItems.Columns.Contains("ItemName") Then dgvDetailItems.Columns("ItemName").HeaderText = "Item"
                If dgvDetailItems.Columns.Contains("Category") Then dgvDetailItems.Columns("Category").HeaderText = "Category"
                If dgvDetailItems.Columns.Contains("Location") Then dgvDetailItems.Columns("Location").HeaderText = "Location"
                If dgvDetailItems.Columns.Contains("Quantity") Then dgvDetailItems.Columns("Quantity").HeaderText = "Qty"
            End If
        Catch
        End Try

        btnApprove.Enabled = True
        btnReject.Enabled = True
    End Sub

    Private Sub btnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        If dgvReceivings.SelectedRows.Count = 0 Then Return

        Dim rid As Integer = Convert.ToInt32(dgvReceivings.SelectedRows(0).Cells("ReceivingID").Value)

        Dim confirm As DialogResult = MessageBox.Show(
            "Accept this delivery? Stock will be added to inventory.",
            "Confirm Accept", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If confirm <> DialogResult.Yes Then Return

        If DatabaseHelper.ApproveReceiving(rid, _user.Username) Then
            ActivityLogger.Log(_user, "Accepted delivery request #" & rid & " (stock added)",
                               "Hardware", rid, False)
            tmrRefresh.Stop()
            MessageBox.Show("Delivery accepted! Stock has been added.",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Else
            MessageBox.Show("Failed to accept delivery.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnReject_Click(sender As Object, e As EventArgs) Handles btnReject.Click
        If dgvReceivings.SelectedRows.Count = 0 Then Return

        Dim rid As Integer = Convert.ToInt32(dgvReceivings.SelectedRows(0).Cells("ReceivingID").Value)

        Dim reason As String = InputBox("Enter reason for cancelling:", "Cancel Delivery", "")
        If reason Is Nothing Then Return
        If String.IsNullOrWhiteSpace(reason) Then
            MessageBox.Show("A reason is required.", "Validation",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If DatabaseHelper.RejectReceiving(rid, _user.Username, reason) Then
            ActivityLogger.Log(_user, "Cancelled delivery request #" & rid & " - Reason: " & reason,
                               "Hardware", rid, False)
            tmrRefresh.Stop()
            MessageBox.Show("Delivery request cancelled.",
                            "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Else
            MessageBox.Show("Failed to cancel delivery.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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