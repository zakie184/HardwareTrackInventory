<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DashboardControl
    Inherits System.Windows.Forms.UserControl

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        pnlContainer = New Panel()
        lblWelcome = New Label()
        lblDate = New Label()
        pnlApprovalNotification = New Panel()
        lblApprovalIcon = New Label()
        lblApprovalText = New Label()
        btnViewApprovals = New Button()
        tlpStats = New TableLayoutPanel()
        pnlTotal = New Panel()
        lblTotalIcon = New Label()
        lblTotalCount = New Label()
        lblTotalLabel = New Label()
        pnlAvailable = New Panel()
        lblAvailableIcon = New Label()
        lblAvailableCount = New Label()
        lblAvailableLabel = New Label()
        pnlAssigned = New Panel()
        lblAssignedIcon = New Label()
        lblAssignedCount = New Label()
        lblAssignedLabel = New Label()
        pnlLowStock = New Panel()
        lblLowStockIcon = New Label()
        lblLowStockCount = New Label()
        lblLowStockLabel = New Label()
        tlpCharts = New TableLayoutPanel()
        pnlPieChart = New Panel()
        lblPieTitle = New Label()
        picPieChart = New PictureBox()
        pnlBarChart = New Panel()
        lblBarTitle = New Label()
        picBarChart = New PictureBox()
        tlpBottom = New TableLayoutPanel()
        pnlActivity = New Panel()
        lblActivityTitle = New Label()
        lvActivity = New ListView()
        colTime = New ColumnHeader()
        colUser = New ColumnHeader()
        colAction = New ColumnHeader()
        pnlLowStockGrid = New Panel()
        lblLowStockGridTitle = New Label()
        dgvLowStock = New DataGridView()
        pnlActions = New Panel()
        btnAddHardware = New Button()
        btnRefresh = New Button()
        pnlContainer.SuspendLayout()
        pnlApprovalNotification.SuspendLayout()
        tlpStats.SuspendLayout()
        pnlTotal.SuspendLayout()
        pnlAvailable.SuspendLayout()
        pnlAssigned.SuspendLayout()
        pnlLowStock.SuspendLayout()
        tlpCharts.SuspendLayout()
        pnlPieChart.SuspendLayout()
        CType(picPieChart, ComponentModel.ISupportInitialize).BeginInit()
        pnlBarChart.SuspendLayout()
        CType(picBarChart, ComponentModel.ISupportInitialize).BeginInit()
        tlpBottom.SuspendLayout()
        pnlActivity.SuspendLayout()
        pnlLowStockGrid.SuspendLayout()
        CType(dgvLowStock, ComponentModel.ISupportInitialize).BeginInit()
        pnlActions.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlContainer
        ' 
        pnlContainer.AutoScroll = True
        pnlContainer.BackColor = Color.FromArgb(CByte(240), CByte(242), CByte(245))
        pnlContainer.Controls.Add(lblWelcome)
        pnlContainer.Controls.Add(lblDate)
        pnlContainer.Controls.Add(pnlApprovalNotification)
        pnlContainer.Controls.Add(tlpStats)
        pnlContainer.Controls.Add(tlpCharts)
        pnlContainer.Controls.Add(tlpBottom)
        pnlContainer.Controls.Add(pnlActions)
        pnlContainer.Dock = DockStyle.Fill
        pnlContainer.Location = New Point(0, 0)
        pnlContainer.Name = "pnlContainer"
        pnlContainer.Padding = New Padding(15)
        pnlContainer.Size = New Size(1100, 760)
        pnlContainer.TabIndex = 0
        ' 
        ' lblWelcome
        ' 
        lblWelcome.AutoSize = True
        lblWelcome.Font = New Font("Segoe UI", 18.0F, FontStyle.Bold)
        lblWelcome.ForeColor = Color.FromArgb(CByte(44), CByte(62), CByte(80))
        lblWelcome.Location = New Point(15, 15)
        lblWelcome.Name = "lblWelcome"
        lblWelcome.Size = New Size(228, 32)
        lblWelcome.TabIndex = 0
        lblWelcome.Text = "👋 Welcome back!"
        ' 
        ' lblDate
        ' 
        lblDate.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        lblDate.AutoSize = True
        lblDate.Font = New Font("Segoe UI", 10.0F)
        lblDate.ForeColor = Color.FromArgb(CByte(127), CByte(140), CByte(141))
        lblDate.Location = New Point(860, 20)
        lblDate.Name = "lblDate"
        lblDate.Size = New Size(87, 19)
        lblDate.TabIndex = 1
        lblDate.Text = "Today's Date"
        ' 
        ' pnlApprovalNotification
        ' 
        pnlApprovalNotification.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        pnlApprovalNotification.BackColor = Color.FromArgb(CByte(255), CByte(243), CByte(205))
        pnlApprovalNotification.BorderStyle = BorderStyle.FixedSingle
        pnlApprovalNotification.Controls.Add(lblApprovalIcon)
        pnlApprovalNotification.Controls.Add(lblApprovalText)
        pnlApprovalNotification.Controls.Add(btnViewApprovals)
        pnlApprovalNotification.Location = New Point(15, 60)
        pnlApprovalNotification.Name = "pnlApprovalNotification"
        pnlApprovalNotification.Size = New Size(1060, 50)
        pnlApprovalNotification.TabIndex = 100
        pnlApprovalNotification.Visible = False
        ' 
        ' lblApprovalIcon
        ' 
        lblApprovalIcon.Font = New Font("Segoe UI", 16.0F)
        lblApprovalIcon.ForeColor = Color.FromArgb(CByte(241), CByte(196), CByte(15))
        lblApprovalIcon.Location = New Point(15, 8)
        lblApprovalIcon.Name = "lblApprovalIcon"
        lblApprovalIcon.Size = New Size(32, 32)
        lblApprovalIcon.TabIndex = 0
        lblApprovalIcon.Text = "🔐"
        lblApprovalIcon.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblApprovalText
        ' 
        lblApprovalText.AutoSize = True
        lblApprovalText.Font = New Font("Segoe UI", 11.0F, FontStyle.Bold)
        lblApprovalText.ForeColor = Color.FromArgb(CByte(150), CByte(90), CByte(0))
        lblApprovalText.Location = New Point(55, 14)
        lblApprovalText.Name = "lblApprovalText"
        lblApprovalText.Size = New Size(266, 20)
        lblApprovalText.TabIndex = 1
        lblApprovalText.Text = "You have pending approval requests."
        ' 
        ' btnViewApprovals
        ' 
        btnViewApprovals.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnViewApprovals.BackColor = Color.FromArgb(CByte(241), CByte(196), CByte(15))
        btnViewApprovals.FlatAppearance.BorderSize = 0
        btnViewApprovals.FlatStyle = FlatStyle.Flat
        btnViewApprovals.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        btnViewApprovals.ForeColor = Color.FromArgb(CByte(44), CByte(62), CByte(80))
        btnViewApprovals.Location = New Point(900, 9)
        btnViewApprovals.Name = "btnViewApprovals"
        btnViewApprovals.Size = New Size(145, 32)
        btnViewApprovals.TabIndex = 2
        btnViewApprovals.Text = "View Requests"
        btnViewApprovals.UseVisualStyleBackColor = False
        ' 
        ' tlpStats
        ' 
        tlpStats.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        tlpStats.ColumnCount = 4
        tlpStats.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25.0F))
        tlpStats.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25.0F))
        tlpStats.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25.0F))
        tlpStats.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25.0F))
        tlpStats.Controls.Add(pnlTotal, 0, 0)
        tlpStats.Controls.Add(pnlAvailable, 1, 0)
        tlpStats.Controls.Add(pnlAssigned, 2, 0)
        tlpStats.Controls.Add(pnlLowStock, 3, 0)
        tlpStats.Location = New Point(15, 60)
        tlpStats.Name = "tlpStats"
        tlpStats.RowCount = 1
        tlpStats.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0F))
        tlpStats.Size = New Size(1060, 100)
        tlpStats.TabIndex = 2
        ' 
        ' pnlTotal
        ' 
        pnlTotal.BackColor = Color.White
        pnlTotal.BorderStyle = BorderStyle.FixedSingle
        pnlTotal.Controls.Add(lblTotalIcon)
        pnlTotal.Controls.Add(lblTotalCount)
        pnlTotal.Controls.Add(lblTotalLabel)
        pnlTotal.Dock = DockStyle.Fill
        pnlTotal.Location = New Point(3, 3)
        pnlTotal.Name = "pnlTotal"
        pnlTotal.Size = New Size(259, 94)
        pnlTotal.TabIndex = 0
        ' 
        ' lblTotalIcon
        ' 
        lblTotalIcon.Font = New Font("Segoe UI", 24.0F)
        lblTotalIcon.Location = New Point(10, 10)
        lblTotalIcon.Name = "lblTotalIcon"
        lblTotalIcon.Size = New Size(50, 40)
        lblTotalIcon.TabIndex = 0
        lblTotalIcon.Text = "💻"
        ' 
        ' lblTotalCount
        ' 
        lblTotalCount.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        lblTotalCount.Font = New Font("Segoe UI", 24.0F, FontStyle.Bold)
        lblTotalCount.ForeColor = Color.FromArgb(CByte(52), CByte(152), CByte(219))
        lblTotalCount.Location = New Point(140, 10)
        lblTotalCount.Name = "lblTotalCount"
        lblTotalCount.Size = New Size(100, 40)
        lblTotalCount.TabIndex = 1
        lblTotalCount.Text = "0"
        lblTotalCount.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' lblTotalLabel
        ' 
        lblTotalLabel.Font = New Font("Segoe UI", 10.0F)
        lblTotalLabel.ForeColor = Color.FromArgb(CByte(127), CByte(140), CByte(141))
        lblTotalLabel.Location = New Point(10, 55)
        lblTotalLabel.Name = "lblTotalLabel"
        lblTotalLabel.Size = New Size(230, 20)
        lblTotalLabel.TabIndex = 2
        lblTotalLabel.Text = "Total Hardware"
        ' 
        ' pnlAvailable
        ' 
        pnlAvailable.BackColor = Color.White
        pnlAvailable.BorderStyle = BorderStyle.FixedSingle
        pnlAvailable.Controls.Add(lblAvailableIcon)
        pnlAvailable.Controls.Add(lblAvailableCount)
        pnlAvailable.Controls.Add(lblAvailableLabel)
        pnlAvailable.Dock = DockStyle.Fill
        pnlAvailable.Location = New Point(268, 3)
        pnlAvailable.Name = "pnlAvailable"
        pnlAvailable.Size = New Size(259, 94)
        pnlAvailable.TabIndex = 1
        ' 
        ' lblAvailableIcon
        ' 
        lblAvailableIcon.Font = New Font("Segoe UI", 24.0F)
        lblAvailableIcon.Location = New Point(10, 10)
        lblAvailableIcon.Name = "lblAvailableIcon"
        lblAvailableIcon.Size = New Size(50, 40)
        lblAvailableIcon.TabIndex = 0
        lblAvailableIcon.Text = "✅"
        ' 
        ' lblAvailableCount
        ' 
        lblAvailableCount.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        lblAvailableCount.Font = New Font("Segoe UI", 24.0F, FontStyle.Bold)
        lblAvailableCount.ForeColor = Color.FromArgb(CByte(46), CByte(204), CByte(113))
        lblAvailableCount.Location = New Point(140, 10)
        lblAvailableCount.Name = "lblAvailableCount"
        lblAvailableCount.Size = New Size(100, 40)
        lblAvailableCount.TabIndex = 1
        lblAvailableCount.Text = "0"
        lblAvailableCount.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' lblAvailableLabel
        ' 
        lblAvailableLabel.Font = New Font("Segoe UI", 10.0F)
        lblAvailableLabel.ForeColor = Color.FromArgb(CByte(127), CByte(140), CByte(141))
        lblAvailableLabel.Location = New Point(10, 55)
        lblAvailableLabel.Name = "lblAvailableLabel"
        lblAvailableLabel.Size = New Size(230, 20)
        lblAvailableLabel.TabIndex = 2
        lblAvailableLabel.Text = "Available Items"
        ' 
        ' pnlAssigned
        ' 
        pnlAssigned.BackColor = Color.White
        pnlAssigned.BorderStyle = BorderStyle.FixedSingle
        pnlAssigned.Controls.Add(lblAssignedIcon)
        pnlAssigned.Controls.Add(lblAssignedCount)
        pnlAssigned.Controls.Add(lblAssignedLabel)
        pnlAssigned.Dock = DockStyle.Fill
        pnlAssigned.Location = New Point(533, 3)
        pnlAssigned.Name = "pnlAssigned"
        pnlAssigned.Size = New Size(259, 94)
        pnlAssigned.TabIndex = 2
        ' 
        ' lblAssignedIcon
        ' 
        lblAssignedIcon.Font = New Font("Segoe UI", 24.0F)
        lblAssignedIcon.Location = New Point(10, 10)
        lblAssignedIcon.Name = "lblAssignedIcon"
        lblAssignedIcon.Size = New Size(50, 40)
        lblAssignedIcon.TabIndex = 0
        lblAssignedIcon.Text = "📋"
        ' 
        ' lblAssignedCount
        ' 
        lblAssignedCount.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        lblAssignedCount.Font = New Font("Segoe UI", 24.0F, FontStyle.Bold)
        lblAssignedCount.ForeColor = Color.FromArgb(CByte(241), CByte(196), CByte(15))
        lblAssignedCount.Location = New Point(140, 10)
        lblAssignedCount.Name = "lblAssignedCount"
        lblAssignedCount.Size = New Size(100, 40)
        lblAssignedCount.TabIndex = 1
        lblAssignedCount.Text = "0"
        lblAssignedCount.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' lblAssignedLabel
        ' 
        lblAssignedLabel.Font = New Font("Segoe UI", 10.0F)
        lblAssignedLabel.ForeColor = Color.FromArgb(CByte(127), CByte(140), CByte(141))
        lblAssignedLabel.Location = New Point(10, 55)
        lblAssignedLabel.Name = "lblAssignedLabel"
        lblAssignedLabel.Size = New Size(230, 20)
        lblAssignedLabel.TabIndex = 2
        lblAssignedLabel.Text = "Assigned Items"
        ' 
        ' pnlLowStock
        ' 
        pnlLowStock.BackColor = Color.White
        pnlLowStock.BorderStyle = BorderStyle.FixedSingle
        pnlLowStock.Controls.Add(lblLowStockIcon)
        pnlLowStock.Controls.Add(lblLowStockCount)
        pnlLowStock.Controls.Add(lblLowStockLabel)
        pnlLowStock.Dock = DockStyle.Fill
        pnlLowStock.Location = New Point(798, 3)
        pnlLowStock.Name = "pnlLowStock"
        pnlLowStock.Size = New Size(259, 94)
        pnlLowStock.TabIndex = 3
        ' 
        ' lblLowStockIcon
        ' 
        lblLowStockIcon.Font = New Font("Segoe UI", 24.0F)
        lblLowStockIcon.Location = New Point(10, 10)
        lblLowStockIcon.Name = "lblLowStockIcon"
        lblLowStockIcon.Size = New Size(50, 40)
        lblLowStockIcon.TabIndex = 0
        lblLowStockIcon.Text = "⚠️"
        ' 
        ' lblLowStockCount
        ' 
        lblLowStockCount.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        lblLowStockCount.Font = New Font("Segoe UI", 24.0F, FontStyle.Bold)
        lblLowStockCount.ForeColor = Color.FromArgb(CByte(231), CByte(76), CByte(60))
        lblLowStockCount.Location = New Point(140, 10)
        lblLowStockCount.Name = "lblLowStockCount"
        lblLowStockCount.Size = New Size(100, 40)
        lblLowStockCount.TabIndex = 1
        lblLowStockCount.Text = "0"
        lblLowStockCount.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' lblLowStockLabel
        ' 
        lblLowStockLabel.Font = New Font("Segoe UI", 10.0F)
        lblLowStockLabel.ForeColor = Color.FromArgb(CByte(127), CByte(140), CByte(141))
        lblLowStockLabel.Location = New Point(10, 55)
        lblLowStockLabel.Name = "lblLowStockLabel"
        lblLowStockLabel.Size = New Size(230, 20)
        lblLowStockLabel.TabIndex = 2
        lblLowStockLabel.Text = "Low Stock Items"
        ' 
        ' tlpCharts
        ' 
        tlpCharts.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        tlpCharts.BackColor = Color.White
        tlpCharts.BorderStyle = BorderStyle.FixedSingle
        tlpCharts.ColumnCount = 2
        tlpCharts.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0F))
        tlpCharts.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0F))
        tlpCharts.Controls.Add(pnlPieChart, 0, 0)
        tlpCharts.Controls.Add(pnlBarChart, 1, 0)
        tlpCharts.Location = New Point(15, 170)
        tlpCharts.Name = "tlpCharts"
        tlpCharts.RowCount = 1
        tlpCharts.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0F))
        tlpCharts.Size = New Size(1060, 190)
        tlpCharts.TabIndex = 3
        ' 
        ' pnlPieChart
        ' 
        pnlPieChart.Controls.Add(lblPieTitle)
        pnlPieChart.Controls.Add(picPieChart)
        pnlPieChart.Dock = DockStyle.Fill
        pnlPieChart.Location = New Point(3, 3)
        pnlPieChart.Name = "pnlPieChart"
        pnlPieChart.Size = New Size(523, 182)
        pnlPieChart.TabIndex = 0
        ' 
        ' lblPieTitle
        ' 
        lblPieTitle.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        lblPieTitle.Location = New Point(10, 5)
        lblPieTitle.Name = "lblPieTitle"
        lblPieTitle.Size = New Size(490, 20)
        lblPieTitle.TabIndex = 0
        lblPieTitle.Text = "📊 Inventory Distribution"
        ' 
        ' picPieChart
        ' 
        picPieChart.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        picPieChart.BackColor = Color.White
        picPieChart.Location = New Point(10, 28)
        picPieChart.Name = "picPieChart"
        picPieChart.Size = New Size(503, 148)
        picPieChart.SizeMode = PictureBoxSizeMode.Zoom
        picPieChart.TabIndex = 1
        picPieChart.TabStop = False
        ' 
        ' pnlBarChart
        ' 
        pnlBarChart.Controls.Add(lblBarTitle)
        pnlBarChart.Controls.Add(picBarChart)
        pnlBarChart.Dock = DockStyle.Fill
        pnlBarChart.Location = New Point(532, 3)
        pnlBarChart.Name = "pnlBarChart"
        pnlBarChart.Size = New Size(523, 182)
        pnlBarChart.TabIndex = 1
        ' 
        ' lblBarTitle
        ' 
        lblBarTitle.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        lblBarTitle.Location = New Point(10, 5)
        lblBarTitle.Name = "lblBarTitle"
        lblBarTitle.Size = New Size(490, 20)
        lblBarTitle.TabIndex = 0
        lblBarTitle.Text = "📈 Category Distribution"
        ' 
        ' picBarChart
        ' 
        picBarChart.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        picBarChart.BackColor = Color.White
        picBarChart.Location = New Point(10, 28)
        picBarChart.Name = "picBarChart"
        picBarChart.Size = New Size(503, 148)
        picBarChart.SizeMode = PictureBoxSizeMode.Zoom
        picBarChart.TabIndex = 1
        picBarChart.TabStop = False
        ' 
        ' tlpBottom
        ' 
        tlpBottom.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        tlpBottom.BackColor = Color.White
        tlpBottom.BorderStyle = BorderStyle.FixedSingle
        tlpBottom.ColumnCount = 2
        tlpBottom.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0F))
        tlpBottom.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0F))
        tlpBottom.Controls.Add(pnlActivity, 0, 0)
        tlpBottom.Controls.Add(pnlLowStockGrid, 1, 0)
        tlpBottom.Location = New Point(15, 370)
        tlpBottom.Name = "tlpBottom"
        tlpBottom.RowCount = 1
        tlpBottom.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0F))
        tlpBottom.Size = New Size(1060, 257)
        tlpBottom.TabIndex = 4
        ' 
        ' pnlActivity
        ' 
        pnlActivity.Controls.Add(lblActivityTitle)
        pnlActivity.Controls.Add(lvActivity)
        pnlActivity.Dock = DockStyle.Fill
        pnlActivity.Location = New Point(3, 3)
        pnlActivity.Name = "pnlActivity"
        pnlActivity.Size = New Size(523, 249)
        pnlActivity.TabIndex = 0
        ' 
        ' lblActivityTitle
        ' 
        lblActivityTitle.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        lblActivityTitle.Location = New Point(10, 5)
        lblActivityTitle.Name = "lblActivityTitle"
        lblActivityTitle.Size = New Size(490, 20)
        lblActivityTitle.TabIndex = 0
        lblActivityTitle.Text = "🕐 Recent Activity"
        ' 
        ' lvActivity
        ' 
        lvActivity.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lvActivity.Columns.AddRange(New ColumnHeader() {colTime, colUser, colAction})
        lvActivity.FullRowSelect = True
        lvActivity.GridLines = True
        lvActivity.Location = New Point(10, 28)
        lvActivity.Name = "lvActivity"
        lvActivity.Size = New Size(503, 211)
        lvActivity.TabIndex = 1
        lvActivity.UseCompatibleStateImageBehavior = False
        lvActivity.View = View.Details
        ' 
        ' colTime
        ' 
        colTime.Text = "Time"
        colTime.Width = 80
        ' 
        ' colUser
        ' 
        colUser.Text = "User"
        colUser.Width = 130
        ' 
        ' colAction
        ' 
        colAction.Text = "Action"
        colAction.Width = 280
        ' 
        ' pnlLowStockGrid
        ' 
        pnlLowStockGrid.Controls.Add(lblLowStockGridTitle)
        pnlLowStockGrid.Controls.Add(dgvLowStock)
        pnlLowStockGrid.Dock = DockStyle.Fill
        pnlLowStockGrid.Location = New Point(532, 3)
        pnlLowStockGrid.Name = "pnlLowStockGrid"
        pnlLowStockGrid.Size = New Size(523, 249)
        pnlLowStockGrid.TabIndex = 1
        ' 
        ' lblLowStockGridTitle
        ' 
        lblLowStockGridTitle.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        lblLowStockGridTitle.ForeColor = Color.FromArgb(CByte(231), CByte(76), CByte(60))
        lblLowStockGridTitle.Location = New Point(10, 5)
        lblLowStockGridTitle.Name = "lblLowStockGridTitle"
        lblLowStockGridTitle.Size = New Size(490, 20)
        lblLowStockGridTitle.TabIndex = 0
        lblLowStockGridTitle.Text = "⚠️ Low Stock Items"
        ' 
        ' dgvLowStock
        ' 
        dgvLowStock.AllowUserToAddRows = False
        dgvLowStock.AllowUserToDeleteRows = False
        dgvLowStock.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvLowStock.BackgroundColor = Color.White
        dgvLowStock.BorderStyle = BorderStyle.None
        dgvLowStock.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvLowStock.Location = New Point(10, 28)
        dgvLowStock.Name = "dgvLowStock"
        dgvLowStock.ReadOnly = True
        dgvLowStock.RowHeadersVisible = False
        dgvLowStock.Size = New Size(503, 211)
        dgvLowStock.TabIndex = 1
        ' 
        ' pnlActions
        ' 
        pnlActions.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        pnlActions.Controls.Add(btnAddHardware)
        pnlActions.Controls.Add(btnRefresh)
        pnlActions.Location = New Point(15, 647)
        pnlActions.Name = "pnlActions"
        pnlActions.Size = New Size(1060, 50)
        pnlActions.TabIndex = 5
        ' 
        ' btnAddHardware
        ' 
        btnAddHardware.BackColor = Color.FromArgb(CByte(52), CByte(152), CByte(219))
        btnAddHardware.FlatStyle = FlatStyle.Flat
        btnAddHardware.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        btnAddHardware.ForeColor = Color.White
        btnAddHardware.Location = New Point(0, 8)
        btnAddHardware.Name = "btnAddHardware"
        btnAddHardware.Size = New Size(120, 35)
        btnAddHardware.TabIndex = 0
        btnAddHardware.Text = "➕ Add Item"
        btnAddHardware.UseVisualStyleBackColor = False
        ' 
        ' btnRefresh
        ' 
        btnRefresh.FlatStyle = FlatStyle.Flat
        btnRefresh.Location = New Point(130, 8)
        btnRefresh.Name = "btnRefresh"
        btnRefresh.Size = New Size(100, 35)
        btnRefresh.TabIndex = 1
        btnRefresh.Text = "🔄 Refresh"
        btnRefresh.UseVisualStyleBackColor = True
        ' 
        ' DashboardControl
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        Controls.Add(pnlContainer)
        Font = New Font("Segoe UI", 9.0F)
        Name = "DashboardControl"
        Size = New Size(1100, 760)
        pnlContainer.ResumeLayout(False)
        pnlContainer.PerformLayout()
        pnlApprovalNotification.ResumeLayout(False)
        pnlApprovalNotification.PerformLayout()
        tlpStats.ResumeLayout(False)
        pnlTotal.ResumeLayout(False)
        pnlAvailable.ResumeLayout(False)
        pnlAssigned.ResumeLayout(False)
        pnlLowStock.ResumeLayout(False)
        tlpCharts.ResumeLayout(False)
        pnlPieChart.ResumeLayout(False)
        CType(picPieChart, ComponentModel.ISupportInitialize).EndInit()
        pnlBarChart.ResumeLayout(False)
        CType(picBarChart, ComponentModel.ISupportInitialize).EndInit()
        tlpBottom.ResumeLayout(False)
        pnlActivity.ResumeLayout(False)
        pnlLowStockGrid.ResumeLayout(False)
        CType(dgvLowStock, ComponentModel.ISupportInitialize).EndInit()
        pnlActions.ResumeLayout(False)
        ResumeLayout(False)

    End Sub

    Friend WithEvents pnlContainer As System.Windows.Forms.Panel
    Friend WithEvents lblWelcome As System.Windows.Forms.Label
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents pnlApprovalNotification As System.Windows.Forms.Panel
    Friend WithEvents lblApprovalIcon As System.Windows.Forms.Label
    Friend WithEvents lblApprovalText As System.Windows.Forms.Label
    Friend WithEvents btnViewApprovals As System.Windows.Forms.Button
    Friend WithEvents tlpStats As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlTotal As System.Windows.Forms.Panel
    Friend WithEvents lblTotalIcon As System.Windows.Forms.Label
    Friend WithEvents lblTotalCount As System.Windows.Forms.Label
    Friend WithEvents lblTotalLabel As System.Windows.Forms.Label
    Friend WithEvents pnlAvailable As System.Windows.Forms.Panel
    Friend WithEvents lblAvailableIcon As System.Windows.Forms.Label
    Friend WithEvents lblAvailableCount As System.Windows.Forms.Label
    Friend WithEvents lblAvailableLabel As System.Windows.Forms.Label
    Friend WithEvents pnlAssigned As System.Windows.Forms.Panel
    Friend WithEvents lblAssignedIcon As System.Windows.Forms.Label
    Friend WithEvents lblAssignedCount As System.Windows.Forms.Label
    Friend WithEvents lblAssignedLabel As System.Windows.Forms.Label
    Friend WithEvents pnlLowStock As System.Windows.Forms.Panel
    Friend WithEvents lblLowStockIcon As System.Windows.Forms.Label
    Friend WithEvents lblLowStockCount As System.Windows.Forms.Label
    Friend WithEvents lblLowStockLabel As System.Windows.Forms.Label
    Friend WithEvents tlpCharts As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlPieChart As System.Windows.Forms.Panel
    Friend WithEvents lblPieTitle As System.Windows.Forms.Label
    Friend WithEvents picPieChart As System.Windows.Forms.PictureBox
    Friend WithEvents pnlBarChart As System.Windows.Forms.Panel
    Friend WithEvents lblBarTitle As System.Windows.Forms.Label
    Friend WithEvents picBarChart As System.Windows.Forms.PictureBox
    Friend WithEvents tlpBottom As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlActivity As System.Windows.Forms.Panel
    Friend WithEvents lblActivityTitle As System.Windows.Forms.Label
    Friend WithEvents lvActivity As System.Windows.Forms.ListView
    Friend WithEvents colTime As System.Windows.Forms.ColumnHeader
    Friend WithEvents colUser As System.Windows.Forms.ColumnHeader
    Friend WithEvents colAction As System.Windows.Forms.ColumnHeader
    Friend WithEvents pnlLowStockGrid As System.Windows.Forms.Panel
    Friend WithEvents lblLowStockGridTitle As System.Windows.Forms.Label
    Friend WithEvents dgvLowStock As System.Windows.Forms.DataGridView
    Friend WithEvents pnlActions As System.Windows.Forms.Panel
    Friend WithEvents btnAddHardware As System.Windows.Forms.Button
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
End Class