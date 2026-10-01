Public Class HardwareForm

    Public Enum FormMode
        AddNew
        EditExisting
    End Enum

    Private _mode As FormMode = FormMode.AddNew
    Private _editID As Integer = -1
    Private _currentUser As User = Nothing

    <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)>
    Public Property ResultName As String = ""

    <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)>
    Public Property ResultCategory As String = ""

    <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)>
    Public Property ResultQuantity As Integer = 0

    <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)>
    Public Property ResultLocation As String = ""

    <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)>
    Public Property ResultStatus As String = "Available"

    Public Sub New(user As User, Optional mode As FormMode = FormMode.AddNew, Optional editID As Integer = -1)
        InitializeComponent()
        _currentUser = user
        _mode = mode
        _editID = editID
    End Sub

    Private Sub HardwareForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCategoriesIntoCombo()
        LoadLocationsIntoCombo()
        LoadStatuses()

        If _mode = FormMode.EditExisting Then
            lblHeaderTitle.Text = "Edit Hardware"
            Me.Text = "Edit Hardware"
            LoadExistingItem()
        Else
            lblHeaderTitle.Text = "Add New Hardware"
            Me.Text = "Add Hardware"
            numQuantity.Value = 1
            cmbStatus.SelectedItem = "Available"
        End If
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

    Private Sub LoadExistingItem()
        Try
            Dim dt As DataTable = DatabaseHelper.GetHardwareByID(_editID)
            If dt Is Nothing OrElse dt.Rows.Count = 0 Then
                MessageBox.Show("Item not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.DialogResult = DialogResult.Cancel
                Me.Close()
                Return
            End If

            Dim row As DataRow = dt.Rows(0)
            txtName.Text = row("Name").ToString()
            SetComboValue(cmbCategory, row("Category").ToString())
            numQuantity.Value = Convert.ToDecimal(row("Quantity"))
            SetComboValue(cmbLocation, row("Location").ToString())
            SetComboValue(cmbStatus, row("Status").ToString())
        Catch ex As Exception
            MessageBox.Show("Error loading item: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SetComboValue(cmb As ComboBox, value As String)
        If cmb Is Nothing OrElse String.IsNullOrEmpty(value) Then Return
        For i As Integer = 0 To cmb.Items.Count - 1
            If String.Equals(cmb.Items(i).ToString(), value, StringComparison.OrdinalIgnoreCase) Then
                cmb.SelectedIndex = i
                Return
            End If
        Next
        cmb.Items.Add(value)
        cmb.SelectedIndex = cmb.Items.Count - 1
    End Sub

    Private Function ValidateInputs() As Boolean
        If String.IsNullOrWhiteSpace(txtName.Text) Then
            MessageBox.Show("Please enter the item name.", "Validation",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtName.Focus()
            Return False
        End If

        If cmbCategory.SelectedIndex < 0 Then
            MessageBox.Show("Please select a category.", "Validation",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbCategory.Focus()
            Return False
        End If

        If numQuantity.Value < 0 Then
            MessageBox.Show("Quantity cannot be negative.", "Validation",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            numQuantity.Focus()
            Return False
        End If

        If cmbLocation.SelectedIndex < 0 Then
            MessageBox.Show("Please select a location.", "Validation",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbLocation.Focus()
            Return False
        End If

        If cmbStatus.SelectedIndex < 0 Then
            MessageBox.Show("Please select a status.", "Validation",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbStatus.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not ValidateInputs() Then Return

        ResultName = txtName.Text.Trim()
        ResultCategory = cmbCategory.SelectedItem.ToString()
        ResultQuantity = CInt(numQuantity.Value)
        ResultLocation = cmbLocation.SelectedItem.ToString()
        ResultStatus = cmbStatus.SelectedItem.ToString()

        Dim success As Boolean = False

        If _mode = FormMode.AddNew Then
            success = DatabaseHelper.AddHardware(ResultName, ResultCategory,
                                                 ResultQuantity, ResultLocation, ResultStatus)
            If success AndAlso _currentUser IsNot Nothing Then
                ActivityLogger.Log(_currentUser,
                                   "Added new hardware '" & ResultName & "' (Qty: " & ResultQuantity & ", " & ResultCategory & ")",
                                   "Hardware", 0, False)
            End If
        Else
            success = DatabaseHelper.UpdateHardwareFull(_editID, ResultName, ResultCategory,
                                                        ResultQuantity, ResultLocation, ResultStatus)
            If success AndAlso _currentUser IsNot Nothing Then
                ActivityLogger.Log(_currentUser,
                                   "Updated hardware '" & ResultName & "' (Qty: " & ResultQuantity & ", Status: " & ResultStatus & ")",
                                   "Hardware", _editID, False)
            End If
        End If

        If success Then
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Else
            MessageBox.Show("Failed to save the hardware item. Please try again.",
                            "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

End Class