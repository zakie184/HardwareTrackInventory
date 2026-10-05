<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class HardwareControl
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
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.pnlToolbar = New System.Windows.Forms.Panel()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnApprovals = New System.Windows.Forms.Button()
        Me.btnHistory = New System.Windows.Forms.Button()
        Me.btnIssue = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.tlpMain = New System.Windows.Forms.TableLayoutPanel()
        Me.dgvHardware = New System.Windows.Forms.DataGridView()
        Me.pnlDetails = New System.Windows.Forms.Panel()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblLocation = New System.Windows.Forms.Label()
        Me.lblQty = New System.Windows.Forms.Label()
        Me.lblCategory = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblDetailsTitle = New System.Windows.Forms.Label()
        Me.pnlContainer.SuspendLayout()
        Me.pnlToolbar.SuspendLayout()
        Me.tlpMain.SuspendLayout()
        CType(Me.dgvHardware, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDetails.SuspendLayout()
        Me.SuspendLayout()
        '
        Me.pnlContainer.AutoScroll = True
        Me.pnlContainer.BackColor = System.Drawing.Color.FromArgb(240, 242, 245)
        Me.pnlContainer.Controls.Add(Me.lblTitle)
        Me.pnlContainer.Controls.Add(Me.pnlToolbar)
        Me.pnlContainer.Controls.Add(Me.tlpMain)
        Me.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContainer.Location = New System.Drawing.Point(0, 0)
        Me.pnlContainer.Name = "pnlContainer"
        Me.pnlContainer.Padding = New System.Windows.Forms.Padding(15)
        Me.pnlContainer.Size = New System.Drawing.Size(1100, 700)
        Me.pnlContainer.TabIndex = 0
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80)
        Me.lblTitle.Location = New System.Drawing.Point(15, 15)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(120, 32)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Hardware"
        '
        Me.pnlToolbar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlToolbar.BackColor = System.Drawing.Color.White
        Me.pnlToolbar.Controls.Add(Me.btnRefresh)
        Me.pnlToolbar.Controls.Add(Me.btnDelete)
        Me.pnlToolbar.Controls.Add(Me.btnApprovals)
        Me.pnlToolbar.Controls.Add(Me.btnHistory)
        Me.pnlToolbar.Controls.Add(Me.btnIssue)
        Me.pnlToolbar.Controls.Add(Me.btnAdd)
        Me.pnlToolbar.Controls.Add(Me.lblCount)
        Me.pnlToolbar.Location = New System.Drawing.Point(15, 60)
        Me.pnlToolbar.Name = "pnlToolbar"
        Me.pnlToolbar.Size = New System.Drawing.Size(1070, 50)
        Me.pnlToolbar.TabIndex = 1
        '
        Me.btnAdd.BackColor = System.Drawing.Color.FromArgb(52, 152, 219)
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.ForeColor = System.Drawing.Color.White
        Me.btnAdd.Location = New System.Drawing.Point(10, 10)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(60, 30)
        Me.btnAdd.TabIndex = 1
        Me.btnAdd.Text = "➕"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        Me.btnIssue.BackColor = System.Drawing.Color.FromArgb(155, 89, 182)
        Me.btnIssue.Enabled = False
        Me.btnIssue.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIssue.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnIssue.ForeColor = System.Drawing.Color.White
        Me.btnIssue.Location = New System.Drawing.Point(80, 10)
        Me.btnIssue.Name = "btnIssue"
        Me.btnIssue.Size = New System.Drawing.Size(90, 30)
        Me.btnIssue.TabIndex = 2
        Me.btnIssue.Text = "📤 Issue"
        Me.btnIssue.UseVisualStyleBackColor = False
        '
        Me.btnHistory.BackColor = System.Drawing.Color.FromArgb(52, 73, 94)
        Me.btnHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHistory.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnHistory.ForeColor = System.Drawing.Color.White
        Me.btnHistory.Location = New System.Drawing.Point(180, 10)
        Me.btnHistory.Name = "btnHistory"
        Me.btnHistory.Size = New System.Drawing.Size(100, 30)
        Me.btnHistory.TabIndex = 3
        Me.btnHistory.Text = "📜 History"
        Me.btnHistory.UseVisualStyleBackColor = False
        '
        Me.btnApprovals.BackColor = System.Drawing.Color.FromArgb(241, 196, 15)
        Me.btnApprovals.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnApprovals.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnApprovals.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80)
        Me.btnApprovals.Location = New System.Drawing.Point(290, 10)
        Me.btnApprovals.Name = "btnApprovals"
        Me.btnApprovals.Size = New System.Drawing.Size(130, 30)
        Me.btnApprovals.TabIndex = 4
        Me.btnApprovals.Text = "🔐 Approvals"
        Me.btnApprovals.UseVisualStyleBackColor = False
        Me.btnApprovals.Visible = False
        '
        Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(231, 76, 60)
        Me.btnDelete.Enabled = False
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.ForeColor = System.Drawing.Color.White
        Me.btnDelete.Location = New System.Drawing.Point(430, 10)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(60, 30)
        Me.btnDelete.TabIndex = 5
        Me.btnDelete.Text = "🗑️"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Location = New System.Drawing.Point(500, 10)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(90, 30)
        Me.btnRefresh.TabIndex = 6
        Me.btnRefresh.Text = "🔄 Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        Me.lblCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCount.AutoSize = True
        Me.lblCount.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Italic)
        Me.lblCount.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141)
        Me.lblCount.Location = New System.Drawing.Point(960, 15)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(87, 19)
        Me.lblCount.TabIndex = 0
        Me.lblCount.Text = "0 records found"
        '
        Me.tlpMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tlpMain.BackColor = System.Drawing.Color.White
        Me.tlpMain.ColumnCount = 2
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.tlpMain.Controls.Add(Me.dgvHardware, 0, 0)
        Me.tlpMain.Controls.Add(Me.pnlDetails, 1, 0)
        Me.tlpMain.Location = New System.Drawing.Point(15, 120)
        Me.tlpMain.Name = "tlpMain"
        Me.tlpMain.RowCount = 1
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMain.Size = New System.Drawing.Size(1070, 500)
        Me.tlpMain.TabIndex = 2
        '
        Me.dgvHardware.AllowUserToAddRows = False
        Me.dgvHardware.AllowUserToDeleteRows = False
        Me.dgvHardware.BackgroundColor = System.Drawing.Color.White
        Me.dgvHardware.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvHardware.Location = New System.Drawing.Point(3, 3)
        Me.dgvHardware.Name = "dgvHardware"
        Me.dgvHardware.ReadOnly = True
        Me.dgvHardware.RowHeadersVisible = False
        Me.dgvHardware.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvHardware.Size = New System.Drawing.Size(636, 494)
        Me.dgvHardware.TabIndex = 1
        '
        Me.pnlDetails.BackColor = System.Drawing.Color.FromArgb(248, 249, 250)
        Me.pnlDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlDetails.Controls.Add(Me.lblStatus)
        Me.pnlDetails.Controls.Add(Me.lblLocation)
        Me.pnlDetails.Controls.Add(Me.lblQty)
        Me.pnlDetails.Controls.Add(Me.lblCategory)
        Me.pnlDetails.Controls.Add(Me.lblName)
        Me.pnlDetails.Controls.Add(Me.lblDetailsTitle)
        Me.pnlDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDetails.Location = New System.Drawing.Point(645, 3)
        Me.pnlDetails.Name = "pnlDetails"
        Me.pnlDetails.Size = New System.Drawing.Size(422, 494)
        Me.pnlDetails.TabIndex = 0
        '
        Me.lblStatus.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblStatus.Location = New System.Drawing.Point(15, 210)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(390, 25)
        Me.lblStatus.Text = "Status: --"
        '
        Me.lblLocation.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.lblLocation.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141)
        Me.lblLocation.Location = New System.Drawing.Point(15, 170)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(390, 25)
        Me.lblLocation.Text = "Location: --"
        '
        Me.lblQty.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.lblQty.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141)
        Me.lblQty.Location = New System.Drawing.Point(15, 130)
        Me.lblQty.Name = "lblQty"
        Me.lblQty.Size = New System.Drawing.Size(390, 25)
        Me.lblQty.Text = "Quantity: --"
        '
        Me.lblCategory.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.lblCategory.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141)
        Me.lblCategory.Location = New System.Drawing.Point(15, 90)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Size = New System.Drawing.Size(390, 25)
        Me.lblCategory.Text = "Category: --"
        '
        Me.lblName.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblName.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80)
        Me.lblName.Location = New System.Drawing.Point(15, 50)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(390, 30)
        Me.lblName.Text = "Select an item"
        '
        Me.lblDetailsTitle.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblDetailsTitle.Location = New System.Drawing.Point(15, 15)
        Me.lblDetailsTitle.Name = "lblDetailsTitle"
        Me.lblDetailsTitle.Size = New System.Drawing.Size(390, 20)
        Me.lblDetailsTitle.Text = "📄 Item Details"
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.pnlContainer)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Name = "HardwareControl"
        Me.Size = New System.Drawing.Size(1100, 700)
        Me.pnlContainer.ResumeLayout(False)
        Me.pnlContainer.PerformLayout()
        Me.pnlToolbar.ResumeLayout(False)
        Me.pnlToolbar.PerformLayout()
        Me.tlpMain.ResumeLayout(False)
        CType(Me.dgvHardware, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDetails.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlContainer As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents pnlToolbar As System.Windows.Forms.Panel
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnApprovals As System.Windows.Forms.Button
    Friend WithEvents btnHistory As System.Windows.Forms.Button
    Friend WithEvents btnIssue As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents lblCount As System.Windows.Forms.Label
    Friend WithEvents tlpMain As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlDetails As System.Windows.Forms.Panel
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents lblLocation As System.Windows.Forms.Label
    Friend WithEvents lblQty As System.Windows.Forms.Label
    Friend WithEvents lblCategory As System.Windows.Forms.Label
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents lblDetailsTitle As System.Windows.Forms.Label
    Friend WithEvents dgvHardware As System.Windows.Forms.DataGridView
End Class