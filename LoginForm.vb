Imports MySql.Data.MySqlClient

Public Class LoginForm

    Private _currentUser As User = Nothing

    <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)>
    Public Property CurrentUser As User
        Get
            Return _currentUser
        End Get
        Set(value As User)
            _currentUser = value
        End Set
    End Property

    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtPassword.PasswordChar = "*"c
        txtUsername.Focus()
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        ' Validate inputs
        If String.IsNullOrWhiteSpace(txtUsername.Text) Then
            MessageBox.Show("Please enter your username.", "Login Required",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUsername.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(txtPassword.Text) Then
            MessageBox.Show("Please enter your password.", "Login Required",
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPassword.Focus()
            Return
        End If

        btnLogin.Enabled = False
        btnCancel.Enabled = False
        Cursor = Cursors.WaitCursor

        Try
            ' Get user from database
            Dim dt As DataTable = DatabaseHelper.GetUser(txtUsername.Text.Trim())

            If dt Is Nothing OrElse dt.Rows.Count = 0 Then
                MessageBox.Show("Username not found.", "Login Failed",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtPassword.Clear()
                txtUsername.Focus()
                Return
            End If

            Dim row As DataRow = dt.Rows(0)

            ' Check password
            If row("PasswordHash").ToString() <> txtPassword.Text Then
                MessageBox.Show("Invalid password.", "Login Failed",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtPassword.Clear()
                txtPassword.Focus()
                Return
            End If

            ' Check if active
            If row("Status").ToString() <> "Active" Then
                MessageBox.Show("Your account is inactive. Please contact the administrator.",
                              "Account Inactive", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtPassword.Clear()
                txtUsername.Focus()
                txtUsername.SelectAll()
                Return
            End If

            ' Create user object
            CurrentUser = New User()
            CurrentUser.ID = Convert.ToInt32(row("UserID"))
            CurrentUser.Username = row("Username").ToString()
            CurrentUser.FullName = row("FullName").ToString()
            CurrentUser.Role = row("Role").ToString()
            CurrentUser.IsActive = row("Status").ToString() = "Active"

            If row("LastLogin") IsNot DBNull.Value Then
                CurrentUser.LastLogin = Convert.ToDateTime(row("LastLogin"))
            Else
                CurrentUser.LastLogin = DateTime.MinValue
            End If

            ' Update last login
            DatabaseHelper.UpdateLastLogin(CurrentUser.Username)

            ' ✅ OPEN MAINFORM DIRECTLY
            Dim mainForm As New MainForm()
            mainForm.SetUser(CurrentUser)
            mainForm.Show()

            ' ✅ HIDE LOGINFORM (don't close it)
            Me.Hide()

        Catch ex As Exception
            MessageBox.Show("Login error: " & ex.Message, "Login Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            btnLogin.Enabled = True
            btnCancel.Enabled = True
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Application.Exit()
    End Sub

    Private Sub txtPassword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPassword.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            btnLogin.PerformClick()
            e.Handled = True
        End If
    End Sub

    Private Sub txtUsername_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUsername.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            txtPassword.Focus()
            e.Handled = True
        End If
    End Sub

End Class