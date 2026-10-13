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

    Private ReadOnly Property IsAdmin() As Boolean
        Get
            Return currentUser IsNot Nothing AndAlso currentUser.Role = "Administrator"
        End Get
    End Property

    Private Sub LoadDashboard()
        If currentUser IsNot Nothing Then
            lblWelcome.Text = "👋 Welcome back, " & currentUser.FullName & "!"
            lblDate.Text = "🔑 Role: " & currentUser.RoleDisplay
        Else
            lblWelcome.Text = "👋 Welcome to Dashboard"
            lblDate.Text = "🔑 Role: Not logged in"
        End If

        UpdateApprovalBanner()

        Dim total As Integer = DatabaseHelper.GetTotalCount()
        Dim available As Integer = DatabaseHelper.GetAvailableCount()
        Dim assigned As Integer = DatabaseHelper.GetAssignedCount()
        Dim peripheral As Integer = DatabaseHelper.GetPeripheralCount()

        lblTotalCount.Text = total.ToString()
        lblAvailableCount.Text = available.ToString()
        lblAssignedCount.Text = assigned.ToString()
        lblPeripheralCount.Text = peripheral.ToString()

        Dim dtLow As DataTable = DatabaseHelper.GetLowStockItems()
        lblLowStockCount.Text = dtLow.Rows.Count.ToString()

        LoadActivity()
        LoadLowStockGrid()
        DrawPieChart(total, available, assigned, peripheral)
        DrawBarChart()
    End Sub

    Private Sub UpdateApprovalBanner()
        Dim showBanner As Boolean = False

        If IsAdmin Then
            Dim pendingCount As Integer = DatabaseHelper.GetPendingApprovalCount()
            Dim returnCount As Integer = DatabaseHelper.GetPendingReturnCount()

            If pendingCount > 0 OrElse returnCount > 0 Then
                showBanner = True
                pnlApprovalNotification.Visible = True

                Dim parts As New List(Of String)
                If pendingCount > 0 Then
                    parts.Add(pendingCount & " pending issuance" & If(pendingCount = 1, "", "s"))
                End If
                If returnCount > 0 Then
                    parts.Add(returnCount & " pending return" & If(returnCount = 1, "", "s"))
                End If

                lblApprovalText.Text = "You have " & String.Join(" and ", parts) & " awaiting your review."
            End If
        End If

        If Not showBanner Then
            pnlApprovalNotification.Visible = False
        End If

        LayoutDashboard(showBanner)
    End Sub

    Private Sub LayoutDashboard(bannerVisible As Boolean)
        Dim shift As Integer = If(bannerVisible, 60, 0)

        tlpStats.Location = New Point(15, 60 + shift)
        tlpCharts.Location = New Point(15, 170 + shift)

        Dim bottomY As Integer = 370 + shift
        Dim availableHeight As Integer = pnlContainer.ClientSize.Height - bottomY - 75
        If availableHeight < 250 Then availableHeight = 250

        tlpBottom.Location = New Point(15, bottomY)
        tlpBottom.Size = New Size(pnlContainer.ClientSize.Width - 30, availableHeight)

        Dim actionsY As Integer = bottomY + availableHeight + 10
        pnlActions.Location = New Point(15, actionsY)
        pnlActions.Size = New Size(pnlContainer.ClientSize.Width - 30, 50)
    End Sub

    Private Sub DashboardControl_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If currentUser IsNot Nothing Then
            LayoutDashboard(pnlApprovalNotification.Visible)
        End If
    End Sub

    Private Sub btnViewApprovals_Click(sender As Object, e As EventArgs) Handles btnViewApprovals.Click
        If Not IsAdmin Then Return

        Using frm As New ApprovalsForm(currentUser)
            frm.ShowDialog(Me)
        End Using

        LoadDashboard()
    End Sub

    Private Sub LoadActivity()
        lvActivity.Items.Clear()
        If currentUser Is Nothing Then Return

        Dim dt As DataTable = ActivityLogger.GetActivitiesForUser(currentUser, 20)

        If dt.Rows.Count = 0 Then
            lvActivity.Items.Add(New ListViewItem(New String() {"", "", "No recent activity for your role yet."}))
            Return
        End If

        For Each row As DataRow In dt.Rows
            Dim dtTime As DateTime = Convert.ToDateTime(row("ActivityDate"))
            Dim timeStr As String
            Dim diff As TimeSpan = DateTime.Now - dtTime

            If diff.TotalMinutes < 1 Then
                timeStr = "just now"
            ElseIf diff.TotalMinutes < 60 Then
                timeStr = CInt(diff.TotalMinutes) & "m ago"
            ElseIf diff.TotalHours < 24 Then
                timeStr = CInt(diff.TotalHours) & "h ago"
            Else
                timeStr = dtTime.ToString("MMM dd HH:mm")
            End If

            Dim item As New ListViewItem(timeStr)
            item.SubItems.Add(row("Username").ToString() & " (" & row("UserRole").ToString() & ")")
            item.SubItems.Add(row("Action").ToString())
            lvActivity.Items.Add(item)
        Next
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

    Private Sub DrawPieChart(total As Integer, available As Integer, assigned As Integer, peripheral As Integer)
        Dim bmp As New Bitmap(320, 190)
        Using g As Graphics = Graphics.FromImage(bmp)
            g.Clear(Color.White)
            g.SmoothingMode = SmoothingMode.AntiAlias
            g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

            If total = 0 Then
                g.DrawString("No data available", New Font("Segoe UI", 11), Brushes.Gray, 90.0F, 85.0F)
                picPieChart.Image = bmp
                Return
            End If

            Dim others As Integer = total - available - assigned - peripheral
            If others < 0 Then others = 0

            Dim values As Integer() = {available, assigned, peripheral, others}
            Dim colors As Color() = {
                Color.FromArgb(46, 204, 113),
                Color.FromArgb(241, 196, 15),
                Color.FromArgb(155, 89, 182),
                Color.FromArgb(52, 152, 219)
            }
            Dim labels As String() = {"Available", "Assigned", "Peripheral", "Other"}

            Dim pieSize As Integer = 160
            Dim pieX As Integer = 90 - pieSize \ 2
            Dim pieY As Integer = 95 - pieSize \ 2
            Dim rect As New Rectangle(pieX, pieY, pieSize, pieSize)

            Dim startAngle As Single = -90.0F
            For i As Integer = 0 To values.Length - 1
                Dim sweep As Single = CSng(values(i) / total * 360.0)
                If sweep <= 0 Then Continue For

                Using br As New SolidBrush(colors(i))
                    g.FillPie(br, rect, startAngle, sweep)
                End Using

                If sweep > 25 Then
                    Dim midAngle As Single = startAngle + sweep / 2.0F
                    Dim midRad As Single = CSng(midAngle * Math.PI / 180.0F)
                    Dim cx As Single = rect.X + rect.Width / 2.0F
                    Dim cy As Single = rect.Y + rect.Height / 2.0F
                    Dim radius As Single = rect.Width / 2.0F * 0.68F
                    Dim lx As Single = cx + radius * CSng(Math.Cos(midRad)) - 12.0F
                    Dim ly As Single = cy + radius * CSng(Math.Sin(midRad)) - 8.0F
                    Dim pct As String = CInt(Math.Round(values(i) / total * 100)) & "%"
                    g.DrawString(pct, New Font("Segoe UI", 8, FontStyle.Bold), Brushes.White, lx, ly)
                End If

                startAngle += sweep
            Next

            Dim holeSize As Integer = CInt(pieSize * 0.46)
            Dim holeX As Integer = rect.X + (pieSize - holeSize) \ 2
            Dim holeY As Integer = rect.Y + (pieSize - holeSize) \ 2

            Using holeBrush As New SolidBrush(Color.White)
                g.FillEllipse(holeBrush, holeX, holeY, holeSize, holeSize)
            End Using

            Dim totalStr As String = total.ToString()
            Dim fontBig As New Font("Segoe UI", 12, FontStyle.Bold)
            Dim sizeBig As SizeF = g.MeasureString(totalStr, fontBig)
            g.DrawString(totalStr, fontBig, New SolidBrush(Color.FromArgb(44, 62, 80)),
                         CSng(rect.X + rect.Width / 2.0F - sizeBig.Width / 2.0F),
                         CSng(holeY + holeSize / 2.0F - sizeBig.Height / 2.0F - 4))

            Dim fontSmall As New Font("Segoe UI", 7)
            Dim sizeSmall As SizeF = g.MeasureString("Total", fontSmall)
            g.DrawString("Total", fontSmall, Brushes.Gray,
                         CSng(rect.X + rect.Width / 2.0F - sizeSmall.Width / 2.0F),
                         CSng(holeY + holeSize / 2.0F + 8))

            g.DrawEllipse(New Pen(Color.FromArgb(220, 220, 220), 1), rect)

            Dim legendX As Integer = 190
            Dim legendY As Integer = 15
            For i As Integer = 0 To values.Length - 1
                g.FillRectangle(New SolidBrush(colors(i)), legendX, legendY + 4, 14, 14)
                g.DrawRectangle(Pens.LightGray, legendX, legendY + 4, 14, 14)

                Dim pct As String = If(total > 0, CInt(Math.Round(values(i) / total * 100)) & "%", "0%")
                g.DrawString(labels(i) & " (" & values(i) & ")", New Font("Segoe UI", 9), Brushes.Black,
                             CSng(legendX + 22), CSng(legendY))
                g.DrawString(pct, New Font("Segoe UI", 9, FontStyle.Bold),
                             New SolidBrush(colors(i)),
                             CSng(legendX + 22), CSng(legendY + 17))

                legendY += 42
            Next
        End Using

        picPieChart.Image = bmp
    End Sub

    Private Sub DrawBarChart()
        Dim bmp As New Bitmap(320, 190)
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
                        g.DrawString("No data available", New Font("Segoe UI", 11), Brushes.Gray, 90.0F, 85.0F)
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

                    Dim barWidth As Integer = 42
                    Dim startX As Integer = 20
                    Dim chartHeight As Integer = 130
                    Dim bottom As Integer = 155
                    Dim colors As Color() = {
                        Color.FromArgb(52, 152, 219),
                        Color.FromArgb(46, 204, 113),
                        Color.FromArgb(241, 196, 15),
                        Color.FromArgb(155, 89, 182),
                        Color.FromArgb(231, 76, 60)
                    }

                    For i As Integer = 0 To dt.Rows.Count - 1
                        Dim count As Integer = Convert.ToInt32(dt.Rows(i)("Count"))
                        Dim barHeight As Integer = CInt((count / maxCount) * chartHeight)
                        If barHeight < 6 Then barHeight = 6
                        Dim x As Integer = startX + (i * (barWidth + 12))

                        g.FillRectangle(New SolidBrush(colors(i Mod colors.Length)),
                                        CSng(x), CSng(bottom - barHeight), CSng(barWidth), CSng(barHeight))
                        g.DrawRectangle(Pens.LightGray, x, bottom - barHeight, barWidth, barHeight)
                        g.DrawString(count.ToString(), New Font("Segoe UI", 9, FontStyle.Bold),
                                     Brushes.Black, CSng(x + 14), CSng(bottom - barHeight - 18))

                        Dim label As String = dt.Rows(i)("Category").ToString()
                        If label.Length > 8 Then label = label.Substring(0, 8) & "."
                        g.DrawString(label, New Font("Segoe UI", 8), Brushes.Black, CSng(x), CSng(bottom + 6))
                    Next
                    g.DrawLine(Pens.LightGray, 10.0F, CSng(bottom), 310.0F, CSng(bottom))
                End Using
            Catch
                g.DrawString("No data available", New Font("Segoe UI", 11), Brushes.Gray, 90.0F, 85.0F)
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