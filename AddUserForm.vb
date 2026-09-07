Public Class AddUserForm

    <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)>
    Public Property NewUsername As String = ""

    <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)>
    Public Property NewPassword As String = ""

    <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)>
    Public Property NewFullName As String = ""

    <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)>
    Public Property NewRole As String = ""

    <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)>
    Public Property NewStatus As String = ""

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrWhiteSpace(txtUsername.Text) Then
            MessageBox.Show("Username is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUsername.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(txtPassword.Text) Then
            MessageBox.Show("Password is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPassword.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(txtFullName.Text) Then
            MessageBox.Show("Full Name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFullName.Focus()
            Return
        End If

        NewUsername = txtUsername.Text.Trim()
        NewPassword = txtPassword.Text.Trim()
        NewFullName = txtFullName.Text.Trim()
        NewRole = cmbRole.SelectedItem.ToString()
        NewStatus = cmbStatus.SelectedItem.ToString()

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub AddUserForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbRole.Items.Add("Administrator")
        cmbRole.Items.Add("Inventory Manager")
        cmbRole.Items.Add("Staff")
        cmbRole.Items.Add("Viewer")
        cmbRole.SelectedIndex = 2

        cmbStatus.Items.Add("Active")
        cmbStatus.Items.Add("Inactive")
        cmbStatus.SelectedIndex = 0

        txtPassword.PasswordChar = "*"c
    End Sub
End Class