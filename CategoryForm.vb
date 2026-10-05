Public Class CategoryForm

    Public Enum FormMode
        AddNew
        RenameExisting
    End Enum

    Private _user As User = Nothing
    Private _mode As FormMode = FormMode.AddNew
    Private _editID As Integer = -1

    Public Sub New(user As User, mode As FormMode)
        InitializeComponent()
        _user = user
        _mode = mode
    End Sub

    Public Sub New(user As User, mode As FormMode, categoryID As Integer,
                   currentName As String, currentDescription As String)
        InitializeComponent()
        _user = user
        _mode = mode
        _editID = categoryID

        If mode = FormMode.RenameExisting Then
            Me.Text = "Rename Category"
            lblHeaderTitle.Text = "Rename Category"
            btnSave.Text = "Save Changes"
            txtName.Text = currentName
            txtDesc.Text = currentDescription
        End If
    End Sub

    Private Sub CategoryForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If _mode = FormMode.AddNew Then
            Me.Text = "Add Category"
            lblHeaderTitle.Text = "Add Category"
            btnSave.Text = "Add Category"
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrWhiteSpace(txtName.Text) Then
            MessageBox.Show("Please enter a category name.", "Validation",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtName.Focus()
            Return
        End If

        Dim name As String = txtName.Text.Trim()
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
            MessageBox.Show("Failed to save category. The name may already exist.",
                            "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

End Class