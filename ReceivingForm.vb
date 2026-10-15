Public Class ReceivingForm

    Private _user As User = Nothing

    Public Sub New(user As User)
        InitializeComponent()
        _user = user
    End Sub

    Private ReadOnly Property IsAdmin As Boolean
        Get
            Return _user IsNot Nothing AndAlso _user.Role = "Administrator"
        End Get
    End Property

    Private Sub ReceivingForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If _user Is Nothing OrElse Not _user.CanRestock() Then
            MessageBox.Show("You don't have permission to receive stock.",
                            "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
            Return
        End If

        If IsAdmin Then
            lblHeaderSub.Text = "Administrator — stock will be added immediately"
            btnSave.Text = "Receive Now"
        Else
            lblHeaderSub.Text = "Your request will be sent to Administrator for approval"
            btnSave.Text = "Submit Request"
        End If

        LoadComboBoxColumns()
        LoadSuppliers()
        LoadLowStockItems()
    End Sub

    Private Sub LoadSuppliers()
        cmbSupplier.Items.Clear()
        Try
            Dim dt As DataTable = DatabaseHelper.GetAllSuppliers()
            For Each row As DataRow In dt.Rows
                cmbSupplier.Items.Add(row("Name").ToString())
            Next
        Catch
        End Try

        If cmbSupplier.Items.Count > 0 Then
            cmbSupplier.SelectedIndex = 0
        End If
    End Sub

    Private Sub LoadComboBoxColumns()
        colCategory.Items.Clear()
        colLocation.Items.Clear()

        Try
            Dim dtCat As DataTable = DatabaseHelper.GetAllCategories()
            For Each row As DataRow In dtCat.Rows
                colCategory.Items.Add(row("Name").ToString())
            Next
        Catch
        End Try

        Try
            Dim dtLoc As DataTable = DatabaseHelper.GetAllLocations()
            For Each row As DataRow In dtLoc.Rows
                colLocation.Items.Add(row("Name").ToString())
            Next
        Catch
        End Try
    End Sub

    Private Sub LoadLowStockItems()
        dgvItems.Rows.Clear()
        Try
            Dim dt As DataTable = DatabaseHelper.GetLowStockItems()
            For Each row As DataRow In dt.Rows
                Dim idx As Integer = dgvItems.Rows.Add()
                dgvItems.Rows(idx).Cells("colItemName").Value = row("Name").ToString()
                dgvItems.Rows(idx).Cells("colCategory").Value = row("Category").ToString()
                dgvItems.Rows(idx).Cells("colLocation").Value = row("Location").ToString()
                dgvItems.Rows(idx).Cells("colQty").Value = 1
            Next
        Catch
        End Try
    End Sub

    Private Sub btnAddRow_Click(sender As Object, e As EventArgs) Handles btnAddRow.Click
        Dim idx As Integer = dgvItems.Rows.Add()
        dgvItems.Rows(idx).Cells("colQty").Value = 1
        If colCategory.Items.Count > 0 Then
            dgvItems.Rows(idx).Cells("colCategory").Value = colCategory.Items(0).ToString()
        End If
        If colLocation.Items.Count > 0 Then
            dgvItems.Rows(idx).Cells("colLocation").Value = colLocation.Items(0).ToString()
        End If
    End Sub

    Private Sub btnRemoveRow_Click(sender As Object, e As EventArgs) Handles btnRemoveRow.Click
        If dgvItems.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a row to remove.", "No Selection",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        dgvItems.Rows.Remove(dgvItems.SelectedRows(0))
    End Sub

    Private Function ValidateAndBuildItems() As List(Of ReceivingLine)
        Dim lines As New List(Of ReceivingLine)

        For Each row As DataGridViewRow In dgvItems.Rows
            Dim itemName As String = If(row.Cells("colItemName").Value IsNot Nothing, row.Cells("colItemName").Value.ToString().Trim(), "")
            Dim category As String = If(row.Cells("colCategory").Value IsNot Nothing, row.Cells("colCategory").Value.ToString().Trim(), "")
            Dim location As String = If(row.Cells("colLocation").Value IsNot Nothing, row.Cells("colLocation").Value.ToString().Trim(), "")
            Dim qtyVal As Object = row.Cells("colQty").Value

            If String.IsNullOrWhiteSpace(itemName) Then Continue For
            If String.IsNullOrWhiteSpace(category) Then
                MessageBox.Show("Row " & (row.Index + 1) & ": Category is required.", "Validation",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return Nothing
            End If
            If String.IsNullOrWhiteSpace(location) Then
                MessageBox.Show("Row " & (row.Index + 1) & ": Location is required.", "Validation",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return Nothing
            End If

            Dim qty As Integer = 1
            If qtyVal IsNot Nothing Then Integer.TryParse(qtyVal.ToString(), qty)
            If qty < 1 Then
                MessageBox.Show("Row " & (row.Index + 1) & ": Quantity must be at least 1.", "Validation",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return Nothing
            End If

            Dim line As New ReceivingLine()
            line.ItemName = itemName
            line.Category = category
            line.Location = location
            line.Quantity = qty
            lines.Add(line)
        Next

        If lines.Count = 0 Then
            MessageBox.Show("Please add at least one item.", "Validation",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return Nothing
        End If

        Return lines
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If DatabaseHelper.HasPendingReceiving() Then
            MessageBox.Show("There is already a pending receiving request. Please wait for the Administrator to approve or cancel it before submitting a new one.",
                            "Pending Request Exists", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim lines As List(Of ReceivingLine) = ValidateAndBuildItems()
        If lines Is Nothing Then Return

        Dim supplier As String = cmbSupplier.Text.Trim()
        Dim notes As String = txtNotes.Text.Trim()
        Dim requiresApproval As Boolean = Not IsAdmin

        Dim ok As Boolean = DatabaseHelper.CreateReceivingRequest(supplier, notes, _user.Username, requiresApproval, lines)

        If Not ok Then
            MessageBox.Show("Failed to submit receiving request. Please try again.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim summary As String = lines.Count & " item" & If(lines.Count = 1, "", "s")

        If requiresApproval Then
            ActivityLogger.Log(_user,
                               "Submitted receiving request (" & summary & ") — pending approval",
                               "Hardware", 0, False)
            MessageBox.Show("Receiving request submitted! Administrator must approve it before stock is added.",
                            "Pending Approval", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            ActivityLogger.Log(_user,
                               "Received " & summary & " from " & If(String.IsNullOrEmpty(supplier), "unknown supplier", supplier),
                               "Hardware", 0, False)
            MessageBox.Show("Delivery received! Stock has been added.",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

End Class