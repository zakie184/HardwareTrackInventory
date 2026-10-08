Public Class IssuanceForm

    Private _user As User = Nothing
    Private _hardwareID As Integer = 0
    Private _itemName As String = ""
    Private _currentStock As Integer = 0

    Public Sub New(user As User, hardwareID As Integer, itemName As String, currentStock As Integer)
        InitializeComponent()
        _user = user
        _hardwareID = hardwareID
        _itemName = itemName
        _currentStock = currentStock
    End Sub

    Private ReadOnly Property IsAdmin As Boolean
        Get
            Return _user IsNot Nothing AndAlso _user.Role = "Administrator"
        End Get
    End Property

    Private Sub IssuanceForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If _user IsNot Nothing AndAlso Not _user.CanRequestIssuance() Then
            MessageBox.Show("Viewers cannot issue or request items.",
                            "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
            Return
        End If

        lblItemName.Text = _itemName
        lblStock.Text = _currentStock.ToString()

        If IsAdmin Then
            lblHeaderTitle.Text = "Issue Hardware"
            lblHeaderSub.Text = "Administrator - issuance will be applied immediately"
            btnSave.Text = "Issue Now"
        Else
            lblHeaderTitle.Text = "Request Issuance"
            lblHeaderSub.Text = "Your request will be sent to an Administrator for approval"
            btnSave.Text = "Submit Request"
        End If

        LoadIssuedToOptions()
        LoadDepartmentOptions()

        If _currentStock <= 0 Then
            numQuantity.Maximum = 1
            numQuantity.Enabled = False
            btnSave.Enabled = False
            lblStock.ForeColor = Color.Red
        Else
            numQuantity.Maximum = _currentStock
            numQuantity.Value = 1
        End If
    End Sub

    Private Sub LoadIssuedToOptions()
        cmbIssuedTo.Items.Clear()
        Try
            Dim dt As DataTable = DatabaseHelper.GetUsersForIssuance()
            For Each row As DataRow In dt.Rows
                cmbIssuedTo.Items.Add(row("FullName").ToString())
            Next
        Catch
        End Try

        If cmbIssuedTo.Items.Count = 0 Then
            cmbIssuedTo.Items.Add("(no users available)")
        End If

        cmbIssuedTo.SelectedIndex = 0
    End Sub

    Private Sub LoadDepartmentOptions()
        cmbDepartment.Items.Clear()
        Try
            Dim dt As DataTable = DatabaseHelper.GetAllDepartments()
            For Each row As DataRow In dt.Rows
                cmbDepartment.Items.Add(row("Name").ToString())
            Next
        Catch
        End Try

        If cmbDepartment.Items.Count = 0 Then
            cmbDepartment.Items.Add("Other")
        End If

        cmbDepartment.SelectedIndex = 0
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If cmbIssuedTo.SelectedIndex < 0 Then
            MessageBox.Show("Please select who this is being issued to.",
                            "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbIssuedTo.Focus()
            Return
        End If

        If cmbDepartment.SelectedIndex < 0 Then
            MessageBox.Show("Please select a department.",
                            "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbDepartment.Focus()
            Return
        End If

        Dim qty As Integer = CInt(numQuantity.Value)
        Dim issuedTo As String = cmbIssuedTo.SelectedItem.ToString()
        Dim dept As String = cmbDepartment.SelectedItem.ToString()

        Dim requiresApproval As Boolean = Not IsAdmin

        Dim ok As Boolean = DatabaseHelper.IssueHardware(_hardwareID, _itemName, qty, issuedTo,
                                                         dept, _user.Username, requiresApproval)

        If Not ok Then
            MessageBox.Show("Failed to submit issuance. Please try again.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If requiresApproval Then
            ActivityLogger.Log(_user,
                               "Requested issuance of " & qty & "x '" & _itemName & "' to " & issuedTo & " (pending approval)",
                               "Hardware", _hardwareID, False)
            MessageBox.Show("Request submitted! An Administrator must approve it before stock is issued.",
                            "Pending Approval", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            ActivityLogger.Log(_user,
                               "Issued " & qty & "x '" & _itemName & "' to " & issuedTo,
                               "Hardware", _hardwareID, False)
        End If

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

End Class