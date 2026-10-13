Public Class LocationForm

    Public Enum FormMode
        AddNew
        RenameExisting
    End Enum

    Private _user As User = Nothing
    Private _mode As FormMode = FormMode.AddNew
    Private _editID As Integer = -1

    Private ReadOnly SuggestedNames As String() = {
        "Main Office", "Storage Room", "IT Department", "Warehouse",
        "Server Room", "Conference Room", "Reception", "Faculty Room",
        "Computer Lab", "Library", "Finance Office", "Registrar Office",
        "HR Office", "Maintenance Area", "Other"
    }

    Public Sub New(user As User, mode As FormMode)
        InitializeComponent()
        _user = user
        _mode = mode
    End Sub

    Public Sub PrefillForRename(currentName As String, currentDescription As String)
        cmbName.Text = currentName
        txtDesc.Text = currentDescription
    End Sub

    Private Sub LocationForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadExistingNames()

        If _mode = FormMode.AddNew Then
            Me.Text = "Add Location"
            lblHeaderTitle.Text = "Add Location"
            btnSave.Text = "Add Location"
        Else
            Me.Text = "Rename Location"
            lblHeaderTitle.Text = "Rename Location"
            btnSave.Text = "Save Changes"
        End If

        cmbName.Focus()
    End Sub

    Private Sub LoadExistingNames()
        cmbName.Items.Clear()

        Try
            Dim dt As DataTable = DatabaseHelper.GetAllLocations()
            For Each row As DataRow In dt.Rows
                cmbName.Items.Add(row("Name").ToString())
            Next
        Catch
        End Try

        For Each s As String In SuggestedNames
            If Not cmbName.Items.Contains(s) Then cmbName.Items.Add(s)
        Next
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim name As String = cmbName.Text.Trim()
        If String.IsNullOrWhiteSpace(name) Then
            MessageBox.Show("Please enter or select a location name.", "Validation",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbName.Focus()
            Return
        End If

        Dim desc As String = txtDesc.Text.Trim()
        Dim success As Boolean = False

        If _mode = FormMode.AddNew Then
            success = DatabaseHelper.AddLocation(name, desc)
            If success AndAlso _user IsNot Nothing Then
                ActivityLogger.Log(_user, "Added location '" & name & "'", "Location", 0, False)
            End If
        Else
            success = DatabaseHelper.UpdateLocation(_editID, name, desc)
            If success AndAlso _user IsNot Nothing Then
                ActivityLogger.Log(_user, "Renamed location to '" & name & "'", "Location", _editID, False)
            End If
        End If

        If success Then
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Else
            MessageBox.Show("Failed to save. The name may already exist.",
                            "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

End Class