Public Class CategoryForm

    Public Enum FormMode
        AddNew
        RenameExisting
    End Enum

    Private _user As User = Nothing
    Private _mode As FormMode = FormMode.AddNew
    Private _editID As Integer = -1

    Private ReadOnly SuggestedNames As String() = {
        "Laptop", "Desktop", "Monitor", "Printer", "Network",
        "Peripheral", "Storage", "Server", "Tablet", "Phone",
        "Camera", "Cable", "Adapter", "Other"
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

    Private Sub CategoryForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadExistingNames()

        If _mode = FormMode.AddNew Then
            Me.Text = "Add Category"
            lblHeaderTitle.Text = "Add Category"
            btnSave.Text = "Add Category"
        Else
            Me.Text = "Rename Category"
            lblHeaderTitle.Text = "Rename Category"
            btnSave.Text = "Save Changes"
        End If

        cmbName.Focus()
    End Sub

    Private Sub LoadExistingNames()
        cmbName.Items.Clear()

        Try
            Dim dt As DataTable = DatabaseHelper.GetAllCategories()
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
            MessageBox.Show("Please enter or select a category name.", "Validation",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbName.Focus()
            Return
        End If

        Dim desc As String = txtDesc.Text.Trim()
        Dim success As Boolean = False

        If _mode = FormMode.AddNew Then
            success = DatabaseHelper.AddCategory(name, desc)
            If success AndAlso _user IsNot Nothing Then
                ActivityLogger.Log(_user, "Added category '" & name & "'", "Category", 0, False)
            End If
        Else
            success = DatabaseHelper.UpdateCategory(_editID, name, desc)
            If success AndAlso _user IsNot Nothing Then
                ActivityLogger.Log(_user, "Renamed category to '" & name & "'", "Category", _editID, False)
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