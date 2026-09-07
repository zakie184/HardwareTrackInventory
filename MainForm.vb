Imports MySql.Data.MySqlClient
Imports System.Drawing

Public Class MainForm

    Private currentUser As User = Nothing

    ' UserControls (5 Pages)
    Private dashboardPage As DashboardControl = Nothing
    Private hardwarePage As HardwareControl = Nothing
    Private categoriesPage As CategoriesControl = Nothing
    Private locationsPage As LocationsControl = Nothing
    Private usersPage As UserManagementControl = Nothing

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub InitializePages()
        Try
            If dashboardPage Is Nothing Then dashboardPage = New DashboardControl()
            If hardwarePage Is Nothing Then hardwarePage = New HardwareControl()
            If categoriesPage Is Nothing Then categoriesPage = New CategoriesControl()
            If locationsPage Is Nothing Then locationsPage = New LocationsControl()
            If usersPage Is Nothing Then usersPage = New UserManagementControl()
        Catch ex As Exception
            MessageBox.Show("Error initializing pages: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()
        End Try
    End Sub

    Public Sub SetUser(user As User)
        Try
            If user Is Nothing Then
                MessageBox.Show("User is null.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Application.Exit()
                Return
            End If

            currentUser = user

            InitializePages()

            If lblHeaderUser IsNot Nothing Then
                lblHeaderUser.Text = "👤 " & user.FullName & "  |  " & user.RoleDisplay
            End If

            If lblFooterRight IsNot Nothing Then
                lblFooterRight.Text = "Logged in as: " & user.FullName & " | Role: " & user.Role
            End If

            If dashboardPage IsNot Nothing Then dashboardPage.SetCurrentUser(currentUser)
            If hardwarePage IsNot Nothing Then hardwarePage.SetCurrentUser(currentUser)
            If categoriesPage IsNot Nothing Then categoriesPage.SetCurrentUser(currentUser)
            If locationsPage IsNot Nothing Then locationsPage.SetCurrentUser(currentUser)
            If usersPage IsNot Nothing Then usersPage.SetCurrentUser(currentUser)

            ApplyPermissions()

            If dashboardPage IsNot Nothing AndAlso pnlContent IsNot Nothing Then
                LoadPage(dashboardPage)
                HighlightButton(btnDashboard)
            End If

            If lblHeaderSub IsNot Nothing Then
                lblHeaderSub.Text = "Welcome, " & user.FullName
            End If

        Catch ex As Exception
            MessageBox.Show("Error in SetUser: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()
        End Try
    End Sub

    Private Sub ApplyPermissions()
        btnDashboard.Visible = True
        btnHardware.Visible = True
        btnCategories.Visible = True
        btnLocations.Visible = True
        btnUsers.Visible = True

        If currentUser Is Nothing Then Return

        If currentUser.Role <> "Administrator" Then
            btnUsers.Visible = False
        End If

        If currentUser.Role = "Viewer" OrElse currentUser.Role = "Staff" Then
            btnCategories.Visible = False
            btnLocations.Visible = False
            btnUsers.Visible = False
        End If
    End Sub

    Private Sub LoadPage(page As UserControl)
        If page Is Nothing Then Return
        If pnlContent Is Nothing Then Return

        pnlContent.Controls.Clear()
        page.Dock = DockStyle.Fill
        pnlContent.Controls.Add(page)
        pnlContent.Refresh()
    End Sub

    Private Sub HighlightButton(activeButton As Button)
        If activeButton Is Nothing Then Return

        Dim buttons As Button() = {btnDashboard, btnHardware, btnCategories, btnLocations, btnUsers}

        For Each btn As Button In buttons
            If btn IsNot Nothing AndAlso btn.Visible Then
                btn.BackColor = Color.Transparent
                btn.ForeColor = Color.FromArgb(189, 195, 199)
                btn.Font = New Font(btn.Font, FontStyle.Regular)
            End If
        Next

        If activeButton.Visible Then
            activeButton.BackColor = Color.FromArgb(52, 152, 219)
            activeButton.ForeColor = Color.White
            activeButton.Font = New Font(activeButton.Font, FontStyle.Bold)
        End If
    End Sub

    Public Sub LoadHardwarePage()
        If hardwarePage IsNot Nothing Then
            LoadPage(hardwarePage)
            HighlightButton(btnHardware)
        End If
    End Sub

    Private Sub btnDashboard_Click(sender As Object, e As EventArgs) Handles btnDashboard.Click
        If dashboardPage IsNot Nothing Then
            LoadPage(dashboardPage)
            HighlightButton(btnDashboard)
        End If
    End Sub

    Private Sub btnHardware_Click(sender As Object, e As EventArgs) Handles btnHardware.Click
        If hardwarePage IsNot Nothing Then
            LoadPage(hardwarePage)
            HighlightButton(btnHardware)
        End If
    End Sub

    Private Sub btnCategories_Click(sender As Object, e As EventArgs) Handles btnCategories.Click
        If categoriesPage IsNot Nothing Then
            LoadPage(categoriesPage)
            HighlightButton(btnCategories)
        End If
    End Sub

    Private Sub btnLocations_Click(sender As Object, e As EventArgs) Handles btnLocations.Click
        If locationsPage IsNot Nothing Then
            LoadPage(locationsPage)
            HighlightButton(btnLocations)
        End If
    End Sub

    Private Sub btnUsers_Click(sender As Object, e As EventArgs) Handles btnUsers.Click
        If usersPage IsNot Nothing Then
            LoadPage(usersPage)
            HighlightButton(btnUsers)
        End If
    End Sub

    ' ============================================================
    ' ✅ LOGOUT - HIDE MAINFORM, SHOW LOGINFORM
    ' ============================================================
    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        If MessageBox.Show("Are you sure you want to logout?", "Confirm Logout",
                          MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            ' Hide MainForm
            Me.Hide()

            ' Create new LoginForm and show it
            Dim login As New LoginForm()
            login.Show()

            ' Close this MainForm (it's hidden, but we need to clean up)
            ' We'll let the user close it, but we don't want to exit the app
        End If
    End Sub

    Private Sub btnHeaderLogout_Click(sender As Object, e As EventArgs) Handles btnHeaderLogout.Click
        btnLogout.PerformClick()
    End Sub

    ' ============================================================
    ' ✅ WHEN MAINFORM CLOSES, EXIT THE APPLICATION
    ' ============================================================
    Private Sub MainForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub

    ' ===== HOVER EFFECTS =====
    Private Sub btnDashboard_MouseEnter(sender As Object, e As EventArgs) Handles btnDashboard.MouseEnter
        If btnDashboard.Visible AndAlso btnDashboard.BackColor <> Color.FromArgb(52, 152, 219) Then
            btnDashboard.BackColor = Color.FromArgb(44, 62, 80)
        End If
    End Sub

    Private Sub btnDashboard_MouseLeave(sender As Object, e As EventArgs) Handles btnDashboard.MouseLeave
        If btnDashboard.Visible AndAlso btnDashboard.BackColor <> Color.FromArgb(52, 152, 219) Then
            btnDashboard.BackColor = Color.Transparent
        End If
    End Sub

    Private Sub btnHardware_MouseEnter(sender As Object, e As EventArgs) Handles btnHardware.MouseEnter
        If btnHardware.Visible AndAlso btnHardware.BackColor <> Color.FromArgb(52, 152, 219) Then
            btnHardware.BackColor = Color.FromArgb(44, 62, 80)
        End If
    End Sub

    Private Sub btnHardware_MouseLeave(sender As Object, e As EventArgs) Handles btnHardware.MouseLeave
        If btnHardware.Visible AndAlso btnHardware.BackColor <> Color.FromArgb(52, 152, 219) Then
            btnHardware.BackColor = Color.Transparent
        End If
    End Sub

    Private Sub btnCategories_MouseEnter(sender As Object, e As EventArgs) Handles btnCategories.MouseEnter
        If btnCategories.Visible AndAlso btnCategories.BackColor <> Color.FromArgb(52, 152, 219) Then
            btnCategories.BackColor = Color.FromArgb(44, 62, 80)
        End If
    End Sub

    Private Sub btnCategories_MouseLeave(sender As Object, e As EventArgs) Handles btnCategories.MouseLeave
        If btnCategories.Visible AndAlso btnCategories.BackColor <> Color.FromArgb(52, 152, 219) Then
            btnCategories.BackColor = Color.Transparent
        End If
    End Sub

    Private Sub btnLocations_MouseEnter(sender As Object, e As EventArgs) Handles btnLocations.MouseEnter
        If btnLocations.Visible AndAlso btnLocations.BackColor <> Color.FromArgb(52, 152, 219) Then
            btnLocations.BackColor = Color.FromArgb(44, 62, 80)
        End If
    End Sub

    Private Sub btnLocations_MouseLeave(sender As Object, e As EventArgs) Handles btnLocations.MouseLeave
        If btnLocations.Visible AndAlso btnLocations.BackColor <> Color.FromArgb(52, 152, 219) Then
            btnLocations.BackColor = Color.Transparent
        End If
    End Sub

    Private Sub btnUsers_MouseEnter(sender As Object, e As EventArgs) Handles btnUsers.MouseEnter
        If btnUsers.Visible AndAlso btnUsers.BackColor <> Color.FromArgb(52, 152, 219) Then
            btnUsers.BackColor = Color.FromArgb(44, 62, 80)
        End If
    End Sub

    Private Sub btnUsers_MouseLeave(sender As Object, e As EventArgs) Handles btnUsers.MouseLeave
        If btnUsers.Visible AndAlso btnUsers.BackColor <> Color.FromArgb(52, 152, 219) Then
            btnUsers.BackColor = Color.Transparent
        End If
    End Sub

    Private Sub btnLogout_MouseEnter(sender As Object, e As EventArgs) Handles btnLogout.MouseEnter
        btnLogout.BackColor = Color.FromArgb(192, 57, 43)
        btnLogout.ForeColor = Color.White
    End Sub

    Private Sub btnLogout_MouseLeave(sender As Object, e As EventArgs) Handles btnLogout.MouseLeave
        btnLogout.BackColor = Color.Transparent
        btnLogout.ForeColor = Color.FromArgb(231, 76, 60)
    End Sub

    Private Sub MainForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control Then
            Select Case e.KeyCode
                Case Keys.D : btnDashboard.PerformClick()
                Case Keys.H : btnHardware.PerformClick()
                Case Keys.C : btnCategories.PerformClick()
                Case Keys.L : btnLocations.PerformClick()
                Case Keys.U : btnUsers.PerformClick()
            End Select
        End If
    End Sub

End Class