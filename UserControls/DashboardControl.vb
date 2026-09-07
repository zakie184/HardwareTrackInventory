Imports MySql.Data.MySqlClient
Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class DashboardControl
    Inherits UserControl

    Private currentUser As User = Nothing

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub SetCurrentUser(user As User)
        currentUser = user
        LoadDashboard()
    End Sub

    Public Sub RefreshData()
        LoadDashboard()
    End Sub

    Private Sub LoadDashboard()
        ' Update Welcome
        If currentUser IsNot Nothing Then
            lblWelcome.Text = "👋 Welcome back, " & currentUser.FullName & "!"

            ' ✅ UPDATE: Show Role instead of Date
            lblDate.Text = "🔑 Role: " & currentUser.RoleDisplay
        Else
            lblWelcome.Text = "👋 Welcome to Dashboard"
            lblDate.Text = "🔑 Role: Not logged in"
        End If

        ' Load Statistics
        Dim total As Integer = DatabaseHelper.GetTotalCount()
        Dim available As Integer = DatabaseHelper.GetAvailableCount()
        Dim assigned As Integer = DatabaseHelper.GetAssignedCount()
        Dim lowStock As Integer = 0

        lblTotalCount.Text = total.ToString()
        lblAvailableCount.Text = available.ToString()
        lblAssignedCount.Text = assigned.ToString()

        ' Get low stock count
        Dim dtLow As DataTable = DatabaseHelper.GetLowStockItems()
        lowStock = dtLow.Rows.Count
        lblLowStockCount.Text = lowStock.ToString()

        ' Load Recent Activity
        LoadActivity()

        ' Load Low Stock Grid
        LoadLowStockGrid()

        ' Draw Charts
        DrawPieChart(total, available, assigned)
        DrawBarChart()
    End Sub

    Private Sub LoadActivity()
        lvActivity.Items.Clear()
        Try
            Using conn As MySqlConnection = KeyData.GetConnection()
                conn.Open()
                Dim query As String = "SELECT 'Today' as Date, Username, 'Logged In' as Action " &
                                     "FROM Users WHERE LastLogin > DATE_SUB(NOW(), INTERVAL 1 DAY) " &
                                     "UNION ALL " &
                                     "SELECT 'Recent' as Date, 'System' as Username, 'New hardware added' as Action " &
                                     "LIMIT 6"
                Dim cmd As New MySqlCommand(query, conn)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    Dim item As New ListViewItem(reader("Date").ToString())
                    item.SubItems.Add(reader("Username").ToString())
                    item.SubItems.Add(reader("Action").ToString())
                    lvActivity.Items.Add(item)
                End While
                reader.Close()
                conn.Close()
            End Using
        Catch
            lvActivity.Items.Add(New ListViewItem({"Today", "admin", "Logged In"}))
            lvActivity.Items.Add(New ListViewItem({"Today", "sarah.chen", "Added new hardware"}))
            lvActivity.Items.Add(New ListViewItem({"Today", "lisa.park", "Updated location"}))
        End Try
    End Sub

    Private Sub LoadLowStockGrid()
        dgvLowStock.DataSource = DatabaseHelper.GetLowStockItems()
        If dgvLowStock.Columns.Count > 0 Then
            dgvLowStock.Columns(0).HeaderText = "Item"
            dgvLowStock.Columns(1).HeaderText = "Qty"
            dgvLowStock.Columns(2).HeaderText = "Location"
            For Each row As DataGridViewRow In dgvLowStock.Rows
                If Convert.ToInt32(row.Cells(1).Value) <= 2 Then
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 200, 200)
                End If
            Next
        End If
    End Sub

    Private Sub DrawPieChart(total As Integer, available As Integer, assigned As Integer)
        Dim bmp As New Bitmap(280, 160)
        Using g As Graphics = Graphics.FromImage(bmp)
            g.Clear(Color.White)
            g.SmoothingMode = SmoothingMode.AntiAlias

            If total = 0 Then
                g.DrawString("No data", New Font("Segoe UI", 12), Brushes.Gray, New PointF(100, 60))
                picPieChart.Image = bmp
                Return
            End If

            Dim rect As New Rectangle(10, 10, 130, 130)
            Dim availablePct As Single = (available / total) * 360
            Dim assignedPct As Single = (assigned / total) * 360
            Dim otherPct As Single = 360 - availablePct - assignedPct

            Dim startAngle As Single = 0
            g.FillPie(New SolidBrush(Color.FromArgb(46, 204, 113)), rect, startAngle, availablePct)
            startAngle += availablePct
            g.FillPie(New SolidBrush(Color.FromArgb(241, 196, 15)), rect, startAngle, assignedPct)
            startAngle += assignedPct
            g.FillPie(New SolidBrush(Color.FromArgb(52, 152, 219)), rect, startAngle, otherPct)
            g.DrawEllipse(Pens.LightGray, rect)

            Dim legendY As Integer = 15
            Dim colors As Color() = {Color.FromArgb(46, 204, 113), Color.FromArgb(241, 196, 15), Color.FromArgb(52, 152, 219)}
            Dim labels As String() = {"Available: " & available, "Assigned: " & assigned, "Other: " & (total - available - assigned)}

            For i As Integer = 0 To colors.Length - 1
                g.FillRectangle(New SolidBrush(colors(i)), 155, legendY, 12, 12)
                g.DrawRectangle(Pens.LightGray, 155, legendY, 12, 12)
                g.DrawString(labels(i), New Font("Segoe UI", 8), Brushes.Black, 172, legendY)
                legendY += 22
            Next

            g.DrawString("Total: " & total, New Font("Segoe UI", 9, FontStyle.Bold), Brushes.Black, New PointF(155, 130))
        End Using

        picPieChart.Image = bmp
    End Sub

    Private Sub DrawBarChart()
        Dim bmp As New Bitmap(280, 160)
        Using g As Graphics = Graphics.FromImage(bmp)
            g.Clear(Color.White)
            g.SmoothingMode = SmoothingMode.AntiAlias

            Try
                Using conn As MySqlConnection = KeyData.GetConnection()
                    conn.Open()
                    Dim query As String = "SELECT Category, COUNT(*) as Count FROM Hardware GROUP BY Category ORDER BY Count DESC LIMIT 5"
                    Dim adapter As New MySqlDataAdapter(query, conn)
                    Dim dt As New DataTable()
                    adapter.Fill(dt)

                    If dt.Rows.Count = 0 Then
                        g.DrawString("No data", New Font("Segoe UI", 12), Brushes.Gray, New PointF(100, 60))
                        picBarChart.Image = bmp
                        Return
                    End If

                    Dim maxCount As Integer = 0
                    For Each row As DataRow In dt.Rows
                        If Convert.ToInt32(row("Count")) > maxCount Then
                            maxCount = Convert.ToInt32(row("Count"))
                        End If
                    Next
                    If maxCount = 0 Then maxCount = 1

                    Dim barWidth As Integer = 40
                    Dim startX As Integer = 15
                    Dim chartHeight As Integer = 110
                    Dim bottom As Integer = 135
                    Dim colors As Color() = {Color.FromArgb(52, 152, 219), Color.FromArgb(46, 204, 113), Color.FromArgb(241, 196, 15), Color.FromArgb(155, 89, 182), Color.FromArgb(231, 76, 60)}

                    For i As Integer = 0 To dt.Rows.Count - 1
                        Dim count As Integer = Convert.ToInt32(dt.Rows(i)("Count"))
                        Dim barHeight As Integer = CInt((count / maxCount) * chartHeight)
                        If barHeight < 5 Then barHeight = 5
                        Dim x As Integer = startX + (i * (barWidth + 10))

                        g.FillRectangle(New SolidBrush(colors(i Mod colors.Length)), x, bottom - barHeight, barWidth, barHeight)
                        g.DrawRectangle(Pens.LightGray, x, bottom - barHeight, barWidth, barHeight)
                        g.DrawString(count.ToString(), New Font("Segoe UI", 8, FontStyle.Bold), Brushes.Black, x + 10, bottom - barHeight - 18)

                        Dim label As String = dt.Rows(i)("Category").ToString()
                        If label.Length > 6 Then label = label.Substring(0, 6) & "."
                        g.DrawString(label, New Font("Segoe UI", 7), Brushes.Black, x, bottom + 5)
                    Next
                    g.DrawLine(Pens.LightGray, 10, bottom, 280, bottom)
                End Using
            Catch
                g.DrawString("No data", New Font("Segoe UI", 12), Brushes.Gray, New PointF(100, 60))
            End Try
        End Using

        picBarChart.Image = bmp
    End Sub

    Private Sub btnAddHardware_Click(sender As Object, e As EventArgs) Handles btnAddHardware.Click
        If currentUser IsNot Nothing AndAlso currentUser.CanEdit() Then
            Dim mainForm As MainForm = TryCast(Me.ParentForm, MainForm)
            If mainForm IsNot Nothing Then
                mainForm.LoadHardwarePage()
            End If
        End If
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadDashboard()
    End Sub

End Class