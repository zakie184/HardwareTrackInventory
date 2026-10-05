Public Class HardwareForm

    Private _currentUser As User = Nothing

    Public Sub New(user As User)
        InitializeComponent()
        _currentUser = user
    End Sub

    Private Sub HardwareForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCategoriesIntoCombo()
        LoadLocationsIntoCombo()
        LoadStatuses()

        numQuantity.Value = 1
        cmbStatus.SelectedItem = "Available"
    End Sub

    Private Sub LoadCategoriesIntoCombo()
        cmbCategory.Items.Clear()
        Try
            Dim dt As DataTable = DatabaseHelper.GetAllCategories()
            For Each row As DataRow In dt.Rows
                cmbCategory.Items.Add(row("Name").ToString())
            Next
        Catch
        End Try

        If cmbCategory.Items.Count = 0 Then
            cmbCategory.Items.Add("Laptop")
            cmbCategory.Items.Add("Desktop")
            cmbCategory.Items.Add("Monitor")
            cmbCategory.Items.Add("Printer")
            cmbCategory.Items.Add("Network")
            cmbCategory.Items.Add("Peripheral")
            cmbCategory.Items.Add("Other")
        End If

        If cmbCategory.Items.Count > 0 Then cmbCategory.SelectedIndex = 0
    End Sub

    Private Sub LoadLocationsIntoCombo()
        cmbLocation.Items.Clear()
        Try
            Dim dt As DataTable = DatabaseHelper.GetAllLocations()
            For Each row As DataRow In dt.Rows
                cmbLocation.Items.Add(row("Name").ToString())
            Next
        Catch
        End Try

        If cmbLocation.Items.Count = 0 Then
            cmbLocation.Items.Add("Main Office")
            cmbLocation.Items.Add("Storage Room")
            cmbLocation.Items.Add("IT Department")
            cmbLocation.Items.Add("Warehouse")
        End If

        If cmbLocation.Items.Count > 0 Then cmbLocation.SelectedIndex = 0
    End Sub

    Private Sub LoadStatuses()
        cmbStatus.Items.Clear()
        cmbStatus.Items.Add("Available")
        cmbStatus.Items.Add("Assigned")
        cmbStatus.Items.Add("In Use")
        cmbStatus.Items.Add("Maintenance")
        cmbStatus.Items.Add("Retired")
        cmbStatus.SelectedIndex = 0
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrWhiteSpace(txtName.Text) Then
            MessageBox.Show("Please enter the item name.", "Validation",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtName.Focus()
            Return
        End If

        If cmbCategory.SelectedIndex < 0 Then
            MessageBox.Show("Please select a category.", "Validation",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If cmbLocation.SelectedIndex < 0 Then
            MessageBox.Show("Please select a location.", "Validation",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim name As String = txtName.Text.Trim()
        Dim category As String = cmbCategory.SelectedItem.ToString()
        Dim quantity As Integer = CInt(numQuantity.Value)
        Dim location As String = cmbLocation.SelectedItem.ToString()
        Dim status As String = cmbStatus.SelectedItem.ToString()
        Dim notes As String = txtNotes.Text.Trim()

        If DatabaseHelper.AddHardware(name, category, quantity, location, status, notes) Then
            If _currentUser IsNot Nothing Then
                ActivityLogger.Log(_currentUser,
                                   "Added new hardware '" & name & "' (Qty: " & quantity & ", " & category & ")",
                                   "Hardware", 0, False)
            End If

            Me.DialogResult = DialogResult.OK
            Me.Close()
        Else
            MessageBox.Show("Failed to add the hardware item. Please try again.",
                            "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

End Class