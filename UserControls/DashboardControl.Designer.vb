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
        Me.pnlContainer = New System.Windows.Forms.Panel()
        Me.lblWelcome = New System.Windows.Forms.Label()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.pnlApprovalNotification = New System.Windows.Forms.Panel()
        Me.lblApprovalIcon = New System.Windows.Forms.Label()
        Me.lblApprovalText = New System.Windows.Forms.Label()
        Me.btnViewApprovals = New System.Windows.Forms.Button()
        Me.tlpStats = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlTotal = New System.Windows.Forms.Panel()
        Me.lblTotalIcon = New System.Windows.Forms.Label()
        Me.lblTotalCount = New System.Windows.Forms.Label()
        Me.lblTotalLabel = New System.Windows.Forms.Label()
        Me.pnlAvailable = New System.Windows.Forms.Panel()
        Me.lblAvailableIcon = New System.Windows.Forms.Label()
        Me.lblAvailableCount = New System.Windows.Forms.Label()
        Me.lblAvailableLabel = New System.Windows.Forms.Label()
        Me.pnlAssigned = New System.Windows.Forms.Panel()
        Me.lblAssignedIcon = New System.Windows.Forms.Label()
        Me.lblAssignedCount = New System.Windows.Forms.Label()
        Me.lblAssignedLabel = New System.Windows.Forms.Label()
        Me.pnlPeripheral = New System.Windows.Forms.Panel()
        Me.lblPeripheralIcon = New System.Windows.Forms.Label()
        Me.lblPeripheralCount = New System.Windows.Forms.Label()
        Me.lblPeripheralLabel = New System.Windows.Forms.Label()
        Me.pnlLowStock = New System.Windows.Forms.Panel()
        Me.lblLowStockIcon = New System.Windows.Forms.Label()
        Me.lblLowStockCount = New System.Windows.Forms.Label()
        Me.lblLowStockLabel = New System.Windows.Forms.Label()
        Me.tlpCharts = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlPieChart = New System.Windows.Forms.Panel()
        Me.lblPieTitle = New System.Windows.Forms.Label()
        Me.picPieChart = New System.Windows.Forms.PictureBox()
        Me.pnlBarChart = New System.Windows.Forms.Panel()
        Me.lblBarTitle = New System.Windows.Forms.Label()
        Me.picBarChart = New System.Windows.Forms.PictureBox()
        Me.tlpBottom = New System.Windows.Forms.TableLayoutPanel()
        Me.pnlActivity = New System.Windows.Forms.Panel()
        Me.lblActivityTitle = New System.Windows.Forms.Label()
        Me.lvActivity = New System.Windows.Forms.ListView()
        Me.colTime = New System.Windows.Forms.ColumnHeader()
        Me.colUser = New System.Windows.Forms.ColumnHeader()
        Me.colAction = New System.Windows.Forms.ColumnHeader()
        Me.pnlLowStockGrid = New System.Windows.Forms.Panel()
        Me.lblLowStockGridTitle = New System.Windows.Forms.Label()
        Me.dgvLowStock = New System.Windows.Forms.DataGridView()
        Me.pnlActions = New System.Windows.Forms.Panel()
        Me.btnAddHardware = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.pnlContainer.SuspendLayout()
        Me.pnlApprovalNotification.SuspendLayout()
        Me.tlpStats.SuspendLayout()
        Me.pnlTotal.SuspendLayout()
        Me.pnlAvailable.SuspendLayout()
        Me.pnlAssigned.SuspendLayout()
        Me.pnlPeripheral.SuspendLayout()
        Me.pnlLowStock.SuspendLayout()
        Me.tlpCharts.SuspendLayout()
        Me.pnlPieChart.SuspendLayout()
        CType(Me.picPieChart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBarChart.SuspendLayout()
        CType(Me.picBarChart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpBottom.SuspendLayout()
        Me.pnlActivity.SuspendLayout()
        Me.pnlLowStockGrid.SuspendLayout()
        CType(Me.dgvLowStock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlActions.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlContainer
        '
        Me.pnlContainer.AutoScroll = True
        Me.pnlContainer.BackColor = System.Drawing.Color.FromArgb(240, 242, 245)
        Me.pnlContainer.Controls.Add(Me.lblWelcome)
        Me.pnlContainer.Controls.Add(Me.lblDate)
        Me.pnlContainer.Controls.Add(Me.pnlApprovalNotification)
        Me.pnlContainer.Controls.Add(Me.tlpStats)
        Me.pnlContainer.Controls.Add(Me.tlpCharts)
        Me.pnlContainer.Controls.Add(Me.tlpBottom)
        Me.pnlContainer.Controls.Add(Me.pnlActions)
        Me.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContainer.Location = New System.Drawing.Point(0, 0)
        Me.pnlContainer.Name = "pnlContainer"
        Me.pnlContainer.Padding = New System.Windows.Forms.Padding(15)
        Me.pnlContainer.Size = New System.Drawing.Size(1100, 780)
        Me.pnlContainer.TabIndex = 0
        '
        'lblWelcome
        '
        Me.lblWelcome.AutoSize = True
        Me.lblWelcome.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80)
        Me.lblWelcome.Location = New System.Drawing.Point(15, 15)
        Me.lblWelcome.Name = "lblWelcome"
        Me.lblWelcome.Size = New System.Drawing.Size(200, 32)
        Me.lblWelcome.TabIndex = 0
        Me.lblWelcome.Text = "👋 Welcome back!"
        '
        'lblDate
        '
        Me.lblDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDate.AutoSize = True
        Me.lblDate.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblDate.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141)
        Me.lblDate.Location = New System.Drawing.Point(860, 20)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(100, 19)
        Me.lblDate.TabIndex = 1
        Me.lblDate.Text = "Today's Date"
        '
        'pnlApprovalNotification
        '
        Me.pnlApprovalNotification.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlApprovalNotification.BackColor = System.Drawing.Color.FromArgb(255, 243, 205)
        Me.pnlApprovalNotification.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlApprovalNotification.Controls.Add(Me.lblApprovalIcon)
        Me.pnlApprovalNotification.Controls.Add(Me.lblApprovalText)
        Me.pnlApprovalNotification.Controls.Add(Me.btnViewApprovals)
        Me.pnlApprovalNotification.Location = New System.Drawing.Point(15, 60)
        Me.pnlApprovalNotification.Name = "pnlApprovalNotification"
        Me.pnlApprovalNotification.Size = New System.Drawing.Size(1060, 50)
        Me.pnlApprovalNotification.TabIndex = 100
        Me.pnlApprovalNotification.Visible = False
        '
        'lblApprovalIcon
        '
        Me.lblApprovalIcon.Font = New System.Drawing.Font("Segoe UI", 16.0!)
        Me.lblApprovalIcon.ForeColor = System.Drawing.Color.FromArgb(241, 196, 15)
        Me.lblApprovalIcon.Location = New System.Drawing.Point(15, 8)
        Me.lblApprovalIcon.Name = "lblApprovalIcon"
        Me.lblApprovalIcon.Size = New System.Drawing.Size(32, 32)
        Me.lblApprovalIcon.TabIndex = 0
        Me.lblApprovalIcon.Text = "🔐"
        Me.lblApprovalIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblApprovalText
        '
        Me.lblApprovalText.AutoSize = True
        Me.lblApprovalText.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblApprovalText.ForeColor = System.Drawing.Color.FromArgb(150, 90, 0)
        Me.lblApprovalText.Location = New System.Drawing.Point(55, 14)
        Me.lblApprovalText.Name = "lblApprovalText"
        Me.lblApprovalText.Size = New System.Drawing.Size(380, 20)
        Me.lblApprovalText.TabIndex = 1
        Me.lblApprovalText.Text = "You have pending approval requests."
        '
        'btnViewApprovals
        '
        Me.btnViewApprovals.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnViewApprovals.BackColor = System.Drawing.Color.FromArgb(241, 196, 15)
        Me.btnViewApprovals.FlatAppearance.BorderSize = 0
        Me.btnViewApprovals.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewApprovals.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnViewApprovals.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80)
        Me.btnViewApprovals.Location = New System.Drawing.Point(900, 9)
        Me.btnViewApprovals.Name = "btnViewApprovals"
        Me.btnViewApprovals.Size = New System.Drawing.Size(145, 32)
        Me.btnViewApprovals.TabIndex = 2
        Me.btnViewApprovals.Text = "View Requests"
        Me.btnViewApprovals.UseVisualStyleBackColor = False
        '
        'tlpStats
        '
        Me.tlpStats.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tlpStats.ColumnCount = 5
        Me.tlpStats.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpStats.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpStats.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpStats.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpStats.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tlpStats.Controls.Add(Me.pnlTotal, 0, 0)
        Me.tlpStats.Controls.Add(Me.pnlAvailable, 1, 0)
        Me.tlpStats.Controls.Add(Me.pnlAssigned, 2, 0)
        Me.tlpStats.Controls.Add(Me.pnlPeripheral, 3, 0)
        Me.tlpStats.Controls.Add(Me.pnlLowStock, 4, 0)
        Me.tlpStats.Location = New System.Drawing.Point(15, 60)
        Me.tlpStats.Name = "tlpStats"
        Me.tlpStats.RowCount = 1
        Me.tlpStats.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpStats.Size = New System.Drawing.Size(1060, 100)
        Me.tlpStats.TabIndex = 2
        '
        'pnlTotal
        '
        Me.pnlTotal.BackColor = System.Drawing.Color.White
        Me.pnlTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlTotal.Controls.Add(Me.lblTotalIcon)
        Me.pnlTotal.Controls.Add(Me.lblTotalCount)
        Me.pnlTotal.Controls.Add(Me.lblTotalLabel)
        Me.pnlTotal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlTotal.Location = New System.Drawing.Point(3, 3)
        Me.pnlTotal.Name = "pnlTotal"
        Me.pnlTotal.Size = New System.Drawing.Size(206, 94)
        Me.pnlTotal.TabIndex = 0
        '
        'lblTotalIcon
        '
        Me.lblTotalIcon.Font = New System.Drawing.Font("Segoe UI", 22.0!)
        Me.lblTotalIcon.Location = New System.Drawing.Point(8, 10)
        Me.lblTotalIcon.Name = "lblTotalIcon"
        Me.lblTotalIcon.Size = New System.Drawing.Size(45, 40)
        Me.lblTotalIcon.Text = "💻"
        '
        'lblTotalCount
        '
        Me.lblTotalCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalCount.Font = New System.Drawing.Font("Segoe UI", 22.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalCount.ForeColor = System.Drawing.Color.FromArgb(52, 152, 219)
        Me.lblTotalCount.Location = New System.Drawing.Point(100, 10)
        Me.lblTotalCount.Name = "lblTotalCount"
        Me.lblTotalCount.Size = New System.Drawing.Size(95, 40)
        Me.lblTotalCount.Text = "0"
        Me.lblTotalCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalLabel
        '
        Me.lblTotalLabel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblTotalLabel.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141)
        Me.lblTotalLabel.Location = New System.Drawing.Point(8, 55)
        Me.lblTotalLabel.Name = "lblTotalLabel"
        Me.lblTotalLabel.Size = New System.Drawing.Size(190, 20)
        Me.lblTotalLabel.Text = "Total Hardware"
        '
        'pnlAvailable
        '
        Me.pnlAvailable.BackColor = System.Drawing.Color.White
        Me.pnlAvailable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlAvailable.Controls.Add(Me.lblAvailableIcon)
        Me.pnlAvailable.Controls.Add(Me.lblAvailableCount)
        Me.pnlAvailable.Controls.Add(Me.lblAvailableLabel)
        Me.pnlAvailable.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAvailable.Location = New System.Drawing.Point(215, 3)
        Me.pnlAvailable.Name = "pnlAvailable"
        Me.pnlAvailable.Size = New System.Drawing.Size(206, 94)
        Me.pnlAvailable.TabIndex = 1
        '
        'lblAvailableIcon
        '
        Me.lblAvailableIcon.Font = New System.Drawing.Font("Segoe UI", 22.0!)
        Me.lblAvailableIcon.Location = New System.Drawing.Point(8, 10)
        Me.lblAvailableIcon.Name = "lblAvailableIcon"
        Me.lblAvailableIcon.Size = New System.Drawing.Size(45, 40)
        Me.lblAvailableIcon.Text = "✅"
        '
        'lblAvailableCount
        '
        Me.lblAvailableCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAvailableCount.Font = New System.Drawing.Font("Segoe UI", 22.0!, System.Drawing.FontStyle.Bold)
        Me.lblAvailableCount.ForeColor = System.Drawing.Color.FromArgb(46, 204, 113)
        Me.lblAvailableCount.Location = New System.Drawing.Point(100, 10)
        Me.lblAvailableCount.Name = "lblAvailableCount"
        Me.lblAvailableCount.Size = New System.Drawing.Size(95, 40)
        Me.lblAvailableCount.Text = "0"
        Me.lblAvailableCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblAvailableLabel
        '
        Me.lblAvailableLabel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblAvailableLabel.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141)
        Me.lblAvailableLabel.Location = New System.Drawing.Point(8, 55)
        Me.lblAvailableLabel.Name = "lblAvailableLabel"
        Me.lblAvailableLabel.Size = New System.Drawing.Size(190, 20)
        Me.lblAvailableLabel.Text = "Available Items"
        '
        'pnlAssigned
        '
        Me.pnlAssigned.BackColor = System.Drawing.Color.White
        Me.pnlAssigned.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlAssigned.Controls.Add(Me.lblAssignedIcon)
        Me.pnlAssigned.Controls.Add(Me.lblAssignedCount)
        Me.pnlAssigned.Controls.Add(Me.lblAssignedLabel)
        Me.pnlAssigned.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAssigned.Location = New System.Drawing.Point(427, 3)
        Me.pnlAssigned.Name = "pnlAssigned"
        Me.pnlAssigned.Size = New System.Drawing.Size(206, 94)
        Me.pnlAssigned.TabIndex = 2
        '
        'lblAssignedIcon
        '
        Me.lblAssignedIcon.Font = New System.Drawing.Font("Segoe UI", 22.0!)
        Me.lblAssignedIcon.Location = New System.Drawing.Point(8, 10)
        Me.lblAssignedIcon.Name = "lblAssignedIcon"
        Me.lblAssignedIcon.Size = New System.Drawing.Size(45, 40)
        Me.lblAssignedIcon.Text = "📋"
        '
        'lblAssignedCount
        '
        Me.lblAssignedCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAssignedCount.Font = New System.Drawing.Font("Segoe UI", 22.0!, System.Drawing.FontStyle.Bold)
        Me.lblAssignedCount.ForeColor = System.Drawing.Color.FromArgb(241, 196, 15)
        Me.lblAssignedCount.Location = New System.Drawing.Point(100, 10)
        Me.lblAssignedCount.Name = "lblAssignedCount"
        Me.lblAssignedCount.Size = New System.Drawing.Size(95, 40)
        Me.lblAssignedCount.Text = "0"
        Me.lblAssignedCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblAssignedLabel
        '
        Me.lblAssignedLabel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblAssignedLabel.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141)
        Me.lblAssignedLabel.Location = New System.Drawing.Point(8, 55)
        Me.lblAssignedLabel.Name = "lblAssignedLabel"
        Me.lblAssignedLabel.Size = New System.Drawing.Size(190, 20)
        Me.lblAssignedLabel.Text = "Assigned Items"
        '
        'pnlPeripheral
        '
        Me.pnlPeripheral.BackColor = System.Drawing.Color.White
        Me.pnlPeripheral.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlPeripheral.Controls.Add(Me.lblPeripheralIcon)
        Me.pnlPeripheral.Controls.Add(Me.lblPeripheralCount)
        Me.pnlPeripheral.Controls.Add(Me.lblPeripheralLabel)
        Me.pnlPeripheral.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlPeripheral.Location = New System.Drawing.Point(639, 3)
        Me.pnlPeripheral.Name = "pnlPeripheral"
        Me.pnlPeripheral.Size = New System.Drawing.Size(206, 94)
        Me.pnlPeripheral.TabIndex = 3
        '
        'lblPeripheralIcon
        '
        Me.lblPeripheralIcon.Font = New System.Drawing.Font("Segoe UI", 22.0!)
        Me.lblPeripheralIcon.Location = New System.Drawing.Point(8, 10)
        Me.lblPeripheralIcon.Name = "lblPeripheralIcon"
        Me.lblPeripheralIcon.Size = New System.Drawing.Size(45, 40)
        Me.lblPeripheralIcon.Text = "🖱️"
        '
        'lblPeripheralCount
        '
        Me.lblPeripheralCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPeripheralCount.Font = New System.Drawing.Font("Segoe UI", 22.0!, System.Drawing.FontStyle.Bold)
        Me.lblPeripheralCount.ForeColor = System.Drawing.Color.FromArgb(155, 89, 182)
        Me.lblPeripheralCount.Location = New System.Drawing.Point(100, 10)
        Me.lblPeripheralCount.Name = "lblPeripheralCount"
        Me.lblPeripheralCount.Size = New System.Drawing.Size(95, 40)
        Me.lblPeripheralCount.Text = "0"
        Me.lblPeripheralCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPeripheralLabel
        '
        Me.lblPeripheralLabel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblPeripheralLabel.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141)
        Me.lblPeripheralLabel.Location = New System.Drawing.Point(8, 55)
        Me.lblPeripheralLabel.Name = "lblPeripheralLabel"
        Me.lblPeripheralLabel.Size = New System.Drawing.Size(190, 20)
        Me.lblPeripheralLabel.Text = "Peripheral Items"
        '
        'pnlLowStock
        '
        Me.pnlLowStock.BackColor = System.Drawing.Color.White
        Me.pnlLowStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlLowStock.Controls.Add(Me.lblLowStockIcon)
        Me.pnlLowStock.Controls.Add(Me.lblLowStockCount)
        Me.pnlLowStock.Controls.Add(Me.lblLowStockLabel)
        Me.pnlLowStock.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlLowStock.Location = New System.Drawing.Point(851, 3)
        Me.pnlLowStock.Name = "pnlLowStock"
        Me.pnlLowStock.Size = New System.Drawing.Size(206, 94)
        Me.pnlLowStock.TabIndex = 4
        '
        'lblLowStockIcon
        '
        Me.lblLowStockIcon.Font = New System.Drawing.Font("Segoe UI", 22.0!)
        Me.lblLowStockIcon.Location = New System.Drawing.Point(8, 10)
        Me.lblLowStockIcon.Name = "lblLowStockIcon"
        Me.lblLowStockIcon.Size = New System.Drawing.Size(45, 40)
        Me.lblLowStockIcon.Text = "⚠️"
        '
        'lblLowStockCount
        '
        Me.lblLowStockCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLowStockCount.Font = New System.Drawing.Font("Segoe UI", 22.0!, System.Drawing.FontStyle.Bold)
        Me.lblLowStockCount.ForeColor = System.Drawing.Color.FromArgb(231, 76, 60)
        Me.lblLowStockCount.Location = New System.Drawing.Point(100, 10)
        Me.lblLowStockCount.Name = "lblLowStockCount"
        Me.lblLowStockCount.Size = New System.Drawing.Size(95, 40)
        Me.lblLowStockCount.Text = "0"
        Me.lblLowStockCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblLowStockLabel
        '
        Me.lblLowStockLabel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblLowStockLabel.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141)
        Me.lblLowStockLabel.Location = New System.Drawing.Point(8, 55)
        Me.lblLowStockLabel.Name = "lblLowStockLabel"
        Me.lblLowStockLabel.Size = New System.Drawing.Size(190, 20)
        Me.lblLowStockLabel.Text = "Low Stock Items"
        '
        'tlpCharts
        '
        Me.tlpCharts.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tlpCharts.BackColor = System.Drawing.Color.White
        Me.tlpCharts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tlpCharts.ColumnCount = 2
        Me.tlpCharts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpCharts.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpCharts.Controls.Add(Me.pnlPieChart, 0, 0)
        Me.tlpCharts.Controls.Add(Me.pnlBarChart, 1, 0)
        Me.tlpCharts.Location = New System.Drawing.Point(15, 170)
        Me.tlpCharts.Name = "tlpCharts"
        Me.tlpCharts.RowCount = 1
        Me.tlpCharts.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpCharts.Size = New System.Drawing.Size(1060, 190)
        Me.tlpCharts.TabIndex = 3
        '
        'pnlPieChart
        '
        Me.pnlPieChart.Controls.Add(Me.lblPieTitle)
        Me.pnlPieChart.Controls.Add(Me.picPieChart)
        Me.pnlPieChart.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlPieChart.Location = New System.Drawing.Point(3, 3)
        Me.pnlPieChart.Name = "pnlPieChart"
        Me.pnlPieChart.Size = New System.Drawing.Size(523, 182)
        Me.pnlPieChart.TabIndex = 0
        '
        'lblPieTitle
        '
        Me.lblPieTitle.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblPieTitle.Location = New System.Drawing.Point(10, 5)
        Me.lblPieTitle.Name = "lblPieTitle"
        Me.lblPieTitle.Size = New System.Drawing.Size(490, 20)
        Me.lblPieTitle.Text = "📊 Inventory Distribution"
        '
        'picPieChart
        '
        Me.picPieChart.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picPieChart.BackColor = System.Drawing.Color.White
        Me.picPieChart.Location = New System.Drawing.Point(10, 28)
        Me.picPieChart.Name = "picPieChart"
        Me.picPieChart.Size = New System.Drawing.Size(503, 148)
        Me.picPieChart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picPieChart.TabIndex = 1
        Me.picPieChart.TabStop = False
        '
        'pnlBarChart
        '
        Me.pnlBarChart.Controls.Add(Me.lblBarTitle)
        Me.pnlBarChart.Controls.Add(Me.picBarChart)
        Me.pnlBarChart.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlBarChart.Location = New System.Drawing.Point(532, 3)
        Me.pnlBarChart.Name = "pnlBarChart"
        Me.pnlBarChart.Size = New System.Drawing.Size(523, 182)
        Me.pnlBarChart.TabIndex = 1
        '
        'lblBarTitle
        '
        Me.lblBarTitle.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblBarTitle.Location = New System.Drawing.Point(10, 5)
        Me.lblBarTitle.Name = "lblBarTitle"
        Me.lblBarTitle.Size = New System.Drawing.Size(490, 20)
        Me.lblBarTitle.Text = "📈 Category Distribution"
        '
        'picBarChart
        '
        Me.picBarChart.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picBarChart.BackColor = System.Drawing.Color.White
        Me.picBarChart.Location = New System.Drawing.Point(10, 28)
        Me.picBarChart.Name = "picBarChart"
        Me.picBarChart.Size = New System.Drawing.Size(503, 148)
        Me.picBarChart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picBarChart.TabIndex = 1
        Me.picBarChart.TabStop = False
        '
        'tlpBottom
        '
        Me.tlpBottom.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tlpBottom.BackColor = System.Drawing.Color.White
        Me.tlpBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tlpBottom.ColumnCount = 2
        Me.tlpBottom.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpBottom.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpBottom.Controls.Add(Me.pnlActivity, 0, 0)
        Me.tlpBottom.Controls.Add(Me.pnlLowStockGrid, 1, 0)
        Me.tlpBottom.Location = New System.Drawing.Point(15, 370)
        Me.tlpBottom.Name = "tlpBottom"
        Me.tlpBottom.RowCount = 1
        Me.tlpBottom.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpBottom.Size = New System.Drawing.Size(1060, 310)
        Me.tlpBottom.TabIndex = 4
        '
        'pnlActivity
        '
        Me.pnlActivity.Controls.Add(Me.lblActivityTitle)
        Me.pnlActivity.Controls.Add(Me.lvActivity)
        Me.pnlActivity.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlActivity.Location = New System.Drawing.Point(3, 3)
        Me.pnlActivity.Name = "pnlActivity"
        Me.pnlActivity.Size = New System.Drawing.Size(523, 302)
        Me.pnlActivity.TabIndex = 0
        '
        'lblActivityTitle
        '
        Me.lblActivityTitle.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblActivityTitle.Location = New System.Drawing.Point(10, 5)
        Me.lblActivityTitle.Name = "lblActivityTitle"
        Me.lblActivityTitle.Size = New System.Drawing.Size(490, 20)
        Me.lblActivityTitle.Text = "🕐 Recent Activity"
        '
        'lvActivity
        '
        Me.lvActivity.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvActivity.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colTime, Me.colUser, Me.colAction})
        Me.lvActivity.FullRowSelect = True
        Me.lvActivity.GridLines = True
        Me.lvActivity.Location = New System.Drawing.Point(10, 28)
        Me.lvActivity.Name = "lvActivity"
        Me.lvActivity.Size = New System.Drawing.Size(503, 264)
        Me.lvActivity.TabIndex = 1
        Me.lvActivity.View = System.Windows.Forms.View.Details
        Me.colTime.Text = "Time"
        Me.colTime.Width = 80
        Me.colUser.Text = "User"
        Me.colUser.Width = 130
        Me.colAction.Text = "Action"
        Me.colAction.Width = 280
        '
        'pnlLowStockGrid
        '
        Me.pnlLowStockGrid.Controls.Add(Me.lblLowStockGridTitle)
        Me.pnlLowStockGrid.Controls.Add(Me.dgvLowStock)
        Me.pnlLowStockGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlLowStockGrid.Location = New System.Drawing.Point(532, 3)
        Me.pnlLowStockGrid.Name = "pnlLowStockGrid"
        Me.pnlLowStockGrid.Size = New System.Drawing.Size(523, 302)
        Me.pnlLowStockGrid.TabIndex = 1
        '
        'lblLowStockGridTitle
        '
        Me.lblLowStockGridTitle.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblLowStockGridTitle.ForeColor = System.Drawing.Color.FromArgb(231, 76, 60)
        Me.lblLowStockGridTitle.Location = New System.Drawing.Point(10, 5)
        Me.lblLowStockGridTitle.Name = "lblLowStockGridTitle"
        Me.lblLowStockGridTitle.Size = New System.Drawing.Size(490, 20)
        Me.lblLowStockGridTitle.Text = "⚠️ Low Stock Items"
        '
        'dgvLowStock
        '
        Me.dgvLowStock.AllowUserToAddRows = False
        Me.dgvLowStock.AllowUserToDeleteRows = False
        Me.dgvLowStock.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvLowStock.BackgroundColor = System.Drawing.Color.White
        Me.dgvLowStock.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvLowStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLowStock.Location = New System.Drawing.Point(10, 28)
        Me.dgvLowStock.Name = "dgvLowStock"
        Me.dgvLowStock.ReadOnly = True
        Me.dgvLowStock.RowHeadersVisible = False
        Me.dgvLowStock.Size = New System.Drawing.Size(503, 264)
        Me.dgvLowStock.TabIndex = 1
        '
        'pnlActions
        '
        Me.pnlActions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlActions.Controls.Add(Me.btnAddHardware)
        Me.pnlActions.Controls.Add(Me.btnRefresh)
        Me.pnlActions.Location = New System.Drawing.Point(15, 690)
        Me.pnlActions.Name = "pnlActions"
        Me.pnlActions.Size = New System.Drawing.Size(1060, 50)
        Me.pnlActions.TabIndex = 5
        '
        'btnAddHardware
        '
        Me.btnAddHardware.BackColor = System.Drawing.Color.FromArgb(52, 152, 219)
        Me.btnAddHardware.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddHardware.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnAddHardware.ForeColor = System.Drawing.Color.White
        Me.btnAddHardware.Location = New System.Drawing.Point(0, 8)
        Me.btnAddHardware.Name = "btnAddHardware"
        Me.btnAddHardware.Size = New System.Drawing.Size(120, 35)
        Me.btnAddHardware.TabIndex = 0
        Me.btnAddHardware.Text = "➕ Add Item"
        Me.btnAddHardware.UseVisualStyleBackColor = False
        '
        'btnRefresh
        '
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Location = New System.Drawing.Point(130, 8)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(100, 35)
        Me.btnRefresh.TabIndex = 1
        Me.btnRefresh.Text = "🔄 Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'DashboardControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.pnlContainer)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Name = "DashboardControl"
        Me.Size = New System.Drawing.Size(1100, 780)
        Me.pnlContainer.ResumeLayout(False)
        Me.pnlContainer.PerformLayout()
        Me.pnlApprovalNotification.ResumeLayout(False)
        Me.pnlApprovalNotification.PerformLayout()
        Me.tlpStats.ResumeLayout(False)
        Me.pnlTotal.ResumeLayout(False)
        Me.pnlAvailable.ResumeLayout(False)
        Me.pnlAssigned.ResumeLayout(False)
        Me.pnlPeripheral.ResumeLayout(False)
        Me.pnlLowStock.ResumeLayout(False)
        Me.tlpCharts.ResumeLayout(False)
        Me.pnlPieChart.ResumeLayout(False)
        CType(Me.picPieChart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBarChart.ResumeLayout(False)
        CType(Me.picBarChart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpBottom.ResumeLayout(False)
        Me.pnlActivity.ResumeLayout(False)
        Me.pnlLowStockGrid.ResumeLayout(False)
        CType(Me.dgvLowStock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlActions.ResumeLayout(False)
        Me.ResumeLayout(False)

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
    Friend WithEvents pnlPeripheral As System.Windows.Forms.Panel
    Friend WithEvents lblPeripheralIcon As System.Windows.Forms.Label
    Friend WithEvents lblPeripheralCount As System.Windows.Forms.Label
    Friend WithEvents lblPeripheralLabel As System.Windows.Forms.Label
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