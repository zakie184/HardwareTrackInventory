<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ReturnsApprovalForm
    Inherits System.Windows.Forms.Form

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
        Me.components = New System.ComponentModel.Container()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblHeaderTitle = New System.Windows.Forms.Label()
        Me.lblHeaderSub = New System.Windows.Forms.Label()
        Me.dgvPending = New System.Windows.Forms.DataGridView()
        Me.pnlDetails = New System.Windows.Forms.Panel()
        Me.lblDepartment = New System.Windows.Forms.Label()
        Me.lblQty = New System.Windows.Forms.Label()
        Me.lblIssuedTo = New System.Windows.Forms.Label()
        Me.lblRequestedBy = New System.Windows.Forms.Label()
        Me.lblItemName = New System.Windows.Forms.Label()
        Me.lblDepartmentLbl = New System.Windows.Forms.Label()
        Me.lblQtyLbl = New System.Windows.Forms.Label()
        Me.lblIssuedToLbl = New System.Windows.Forms.Label()
        Me.lblRequestedByLbl = New System.Windows.Forms.Label()
        Me.lblItemNameLbl = New System.Windows.Forms.Label()
        Me.lblDetailsTitle = New System.Windows.Forms.Label()
        Me.pnlBottom = New System.Windows.Forms.Panel()
        Me.btnApprove = New System.Windows.Forms.Button()
        Me.btnReject = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.tmrRefresh = New System.Windows.Forms.Timer(Me.components)
        Me.pnlHeader.SuspendLayout()
        CType(Me.dgvPending, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDetails.SuspendLayout()
        Me.pnlBottom.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(155, 89, 182)
        Me.pnlHeader.Controls.Add(Me.lblHeaderTitle)
        Me.pnlHeader.Controls.Add(Me.lblHeaderSub)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(900, 70)
        Me.pnlHeader.TabIndex = 0
        '
        'lblHeaderTitle
        '
        Me.lblHeaderTitle.AutoSize = True
        Me.lblHeaderTitle.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblHeaderTitle.ForeColor = System.Drawing.Color.White
        Me.lblHeaderTitle.Location = New System.Drawing.Point(20, 10)
        Me.lblHeaderTitle.Name = "lblHeaderTitle"
        Me.lblHeaderTitle.Size = New System.Drawing.Size(230, 25)
        Me.lblHeaderTitle.TabIndex = 0
        Me.lblHeaderTitle.Text = "Pending Return Requests"
        '
        'lblHeaderSub
        '
        Me.lblHeaderSub.AutoSize = True
        Me.lblHeaderSub.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblHeaderSub.ForeColor = System.Drawing.Color.FromArgb(230, 230, 230)
        Me.lblHeaderSub.Location = New System.Drawing.Point(22, 40)
        Me.lblHeaderSub.Name = "lblHeaderSub"
        Me.lblHeaderSub.Size = New System.Drawing.Size(500, 15)
        Me.lblHeaderSub.TabIndex = 1
        Me.lblHeaderSub.Text = "Review and approve or reject return requests. Auto-refreshes every 3 seconds."
        '
        'dgvPending
        '
        Me.dgvPending.AllowUserToAddRows = False
        Me.dgvPending.AllowUserToDeleteRows = False
        Me.dgvPending.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPending.BackgroundColor = System.Drawing.Color.White
        Me.dgvPending.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvPending.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPending.Location = New System.Drawing.Point(15, 85)
        Me.dgvPending.MultiSelect = False
        Me.dgvPending.Name = "dgvPending"
        Me.dgvPending.ReadOnly = True
        Me.dgvPending.RowHeadersVisible = False
        Me.dgvPending.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPending.Size = New System.Drawing.Size(560, 440)
        Me.dgvPending.TabIndex = 1
        '
        'pnlDetails
        '
        Me.pnlDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlDetails.BackColor = System.Drawing.Color.FromArgb(248, 249, 250)
        Me.pnlDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlDetails.Controls.Add(Me.lblDepartment)
        Me.pnlDetails.Controls.Add(Me.lblDepartmentLbl)
        Me.pnlDetails.Controls.Add(Me.lblQty)
        Me.pnlDetails.Controls.Add(Me.lblQtyLbl)
        Me.pnlDetails.Controls.Add(Me.lblIssuedTo)
        Me.pnlDetails.Controls.Add(Me.lblIssuedToLbl)
        Me.pnlDetails.Controls.Add(Me.lblRequestedBy)
        Me.pnlDetails.Controls.Add(Me.lblRequestedByLbl)
        Me.pnlDetails.Controls.Add(Me.lblItemName)
        Me.pnlDetails.Controls.Add(Me.lblItemNameLbl)
        Me.pnlDetails.Controls.Add(Me.lblDetailsTitle)
        Me.pnlDetails.Location = New System.Drawing.Point(590, 85)
        Me.pnlDetails.Name = "pnlDetails"
        Me.pnlDetails.Size = New System.Drawing.Size(295, 440)
        Me.pnlDetails.TabIndex = 2
        '
        'lblDetailsTitle
        '
        Me.lblDetailsTitle.AutoSize = True
        Me.lblDetailsTitle.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblDetailsTitle.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80)
        Me.lblDetailsTitle.Location = New System.Drawing.Point(15, 15)
        Me.lblDetailsTitle.Name = "lblDetailsTitle"
        Me.lblDetailsTitle.Size = New System.Drawing.Size(150, 20)
        Me.lblDetailsTitle.TabIndex = 0
        Me.lblDetailsTitle.Text = "Return Request Details"
        '
        'lblItemNameLbl
        '
        Me.lblItemNameLbl.AutoSize = True
        Me.lblItemNameLbl.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblItemNameLbl.ForeColor = System.Drawing.Color.Gray
        Me.lblItemNameLbl.Location = New System.Drawing.Point(15, 55)
        Me.lblItemNameLbl.Name = "lblItemNameLbl"
        Me.lblItemNameLbl.Size = New System.Drawing.Size(40, 13)
        Me.lblItemNameLbl.TabIndex = 1
        Me.lblItemNameLbl.Text = "ITEM"
        '
        'lblItemName
        '
        Me.lblItemName.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.lblItemName.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80)
        Me.lblItemName.Location = New System.Drawing.Point(15, 73)
        Me.lblItemName.Name = "lblItemName"
        Me.lblItemName.Size = New System.Drawing.Size(260, 25)
        Me.lblItemName.TabIndex = 2
        Me.lblItemName.Text = "--"
        '
        'lblRequestedByLbl
        '
        Me.lblRequestedByLbl.AutoSize = True
        Me.lblRequestedByLbl.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblRequestedByLbl.ForeColor = System.Drawing.Color.Gray
        Me.lblRequestedByLbl.Location = New System.Drawing.Point(15, 115)
        Me.lblRequestedByLbl.Name = "lblRequestedByLbl"
        Me.lblRequestedByLbl.Size = New System.Drawing.Size(90, 13)
        Me.lblRequestedByLbl.TabIndex = 3
        Me.lblRequestedByLbl.Text = "RETURN REQUESTED BY"
        '
        'lblRequestedBy
        '
        Me.lblRequestedBy.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.lblRequestedBy.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80)
        Me.lblRequestedBy.Location = New System.Drawing.Point(15, 133)
        Me.lblRequestedBy.Name = "lblRequestedBy"
        Me.lblRequestedBy.Size = New System.Drawing.Size(260, 25)
        Me.lblRequestedBy.TabIndex = 4
        Me.lblRequestedBy.Text = "--"
        '
        'lblIssuedToLbl
        '
        Me.lblIssuedToLbl.AutoSize = True
        Me.lblIssuedToLbl.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblIssuedToLbl.ForeColor = System.Drawing.Color.Gray
        Me.lblIssuedToLbl.Location = New System.Drawing.Point(15, 175)
        Me.lblIssuedToLbl.Name = "lblIssuedToLbl"
        Me.lblIssuedToLbl.Size = New System.Drawing.Size(70, 13)
        Me.lblIssuedToLbl.TabIndex = 5
        Me.lblIssuedToLbl.Text = "ISSUED TO"
        '
        'lblIssuedTo
        '
        Me.lblIssuedTo.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.lblIssuedTo.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80)
        Me.lblIssuedTo.Location = New System.Drawing.Point(15, 193)
        Me.lblIssuedTo.Name = "lblIssuedTo"
        Me.lblIssuedTo.Size = New System.Drawing.Size(260, 25)
        Me.lblIssuedTo.TabIndex = 6
        Me.lblIssuedTo.Text = "--"
        '
        'lblQtyLbl
        '
        Me.lblQtyLbl.AutoSize = True
        Me.lblQtyLbl.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblQtyLbl.ForeColor = System.Drawing.Color.Gray
        Me.lblQtyLbl.Location = New System.Drawing.Point(15, 235)
        Me.lblQtyLbl.Name = "lblQtyLbl"
        Me.lblQtyLbl.Size = New System.Drawing.Size(30, 13)
        Me.lblQtyLbl.TabIndex = 7
        Me.lblQtyLbl.Text = "QTY"
        '
        'lblQty
        '
        Me.lblQty.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblQty.ForeColor = System.Drawing.Color.FromArgb(52, 152, 219)
        Me.lblQty.Location = New System.Drawing.Point(15, 253)
        Me.lblQty.Name = "lblQty"
        Me.lblQty.Size = New System.Drawing.Size(260, 25)
        Me.lblQty.TabIndex = 8
        Me.lblQty.Text = "--"
        '
        'lblDepartmentLbl
        '
        Me.lblDepartmentLbl.AutoSize = True
        Me.lblDepartmentLbl.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblDepartmentLbl.ForeColor = System.Drawing.Color.Gray
        Me.lblDepartmentLbl.Location = New System.Drawing.Point(15, 295)
        Me.lblDepartmentLbl.Name = "lblDepartmentLbl"
        Me.lblDepartmentLbl.Size = New System.Drawing.Size(75, 13)
        Me.lblDepartmentLbl.TabIndex = 9
        Me.lblDepartmentLbl.Text = "DEPARTMENT"
        '
        'lblDepartment
        '
        Me.lblDepartment.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblDepartment.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80)
        Me.lblDepartment.Location = New System.Drawing.Point(15, 313)
        Me.lblDepartment.Name = "lblDepartment"
        Me.lblDepartment.Size = New System.Drawing.Size(260, 110)
        Me.lblDepartment.TabIndex = 10
        Me.lblDepartment.Text = "--"
        '
        'pnlBottom
        '
        Me.pnlBottom.BackColor = System.Drawing.Color.FromArgb(248, 249, 250)
        Me.pnlBottom.Controls.Add(Me.btnApprove)
        Me.pnlBottom.Controls.Add(Me.btnReject)
        Me.pnlBottom.Controls.Add(Me.btnRefresh)
        Me.pnlBottom.Controls.Add(Me.btnClose)
        Me.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBottom.Location = New System.Drawing.Point(0, 540)
        Me.pnlBottom.Name = "pnlBottom"
        Me.pnlBottom.Size = New System.Drawing.Size(900, 60)
        Me.pnlBottom.TabIndex = 3
        '
        'btnApprove
        '
        Me.btnApprove.BackColor = System.Drawing.Color.FromArgb(46, 204, 113)
        Me.btnApprove.Enabled = False
        Me.btnApprove.FlatAppearance.BorderSize = 0
        Me.btnApprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnApprove.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnApprove.ForeColor = System.Drawing.Color.White
        Me.btnApprove.Location = New System.Drawing.Point(15, 12)
        Me.btnApprove.Name = "btnApprove"
        Me.btnApprove.Size = New System.Drawing.Size(160, 36)
        Me.btnApprove.TabIndex = 0
        Me.btnApprove.Text = "Approve Return"
        Me.btnApprove.UseVisualStyleBackColor = False
        '
        'btnReject
        '
        Me.btnReject.BackColor = System.Drawing.Color.FromArgb(231, 76, 60)
        Me.btnReject.Enabled = False
        Me.btnReject.FlatAppearance.BorderSize = 0
        Me.btnReject.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReject.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnReject.ForeColor = System.Drawing.Color.White
        Me.btnReject.Location = New System.Drawing.Point(185, 12)
        Me.btnReject.Name = "btnReject"
        Me.btnReject.Size = New System.Drawing.Size(150, 36)
        Me.btnReject.TabIndex = 1
        Me.btnReject.Text = "Reject Return"
        Me.btnReject.UseVisualStyleBackColor = False
        '
        'btnRefresh
        '
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.btnRefresh.Location = New System.Drawing.Point(345, 12)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(100, 36)
        Me.btnRefresh.TabIndex = 2
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(189, 195, 199)
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.btnClose.Location = New System.Drawing.Point(785, 12)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(100, 36)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'tmrRefresh
        '
        Me.tmrRefresh.Interval = 3000
        '
        'ReturnsApprovalForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(900, 600)
        Me.Controls.Add(Me.pnlBottom)
        Me.Controls.Add(Me.pnlDetails)
        Me.Controls.Add(Me.dgvPending)
        Me.Controls.Add(Me.pnlHeader)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.MinimizeBox = False
        Me.Name = "ReturnsApprovalForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Pending Return Requests"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        CType(Me.dgvPending, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDetails.ResumeLayout(False)
        Me.pnlDetails.PerformLayout()
        Me.pnlBottom.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblHeaderTitle As System.Windows.Forms.Label
    Friend WithEvents lblHeaderSub As System.Windows.Forms.Label
    Friend WithEvents dgvPending As System.Windows.Forms.DataGridView
    Friend WithEvents pnlDetails As System.Windows.Forms.Panel
    Friend WithEvents lblDetailsTitle As System.Windows.Forms.Label
    Friend WithEvents lblItemNameLbl As System.Windows.Forms.Label
    Friend WithEvents lblItemName As System.Windows.Forms.Label
    Friend WithEvents lblRequestedByLbl As System.Windows.Forms.Label
    Friend WithEvents lblRequestedBy As System.Windows.Forms.Label
    Friend WithEvents lblIssuedToLbl As System.Windows.Forms.Label
    Friend WithEvents lblIssuedTo As System.Windows.Forms.Label
    Friend WithEvents lblQtyLbl As System.Windows.Forms.Label
    Friend WithEvents lblQty As System.Windows.Forms.Label
    Friend WithEvents lblDepartmentLbl As System.Windows.Forms.Label
    Friend WithEvents lblDepartment As System.Windows.Forms.Label
    Friend WithEvents pnlBottom As System.Windows.Forms.Panel
    Friend WithEvents btnApprove As System.Windows.Forms.Button
    Friend WithEvents btnReject As System.Windows.Forms.Button
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents tmrRefresh As System.Windows.Forms.Timer
End Class