<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ReceivingsApprovalForm
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
        Me.dgvReceivings = New System.Windows.Forms.DataGridView()
        Me.pnlDetails = New System.Windows.Forms.Panel()
        Me.dgvDetailItems = New System.Windows.Forms.DataGridView()
        Me.lblDetailsTitle = New System.Windows.Forms.Label()
        Me.lblSupplier = New System.Windows.Forms.Label()
        Me.lblReceivedBy = New System.Windows.Forms.Label()
        Me.lblNotes = New System.Windows.Forms.Label()
        Me.pnlBottom = New System.Windows.Forms.Panel()
        Me.btnApprove = New System.Windows.Forms.Button()
        Me.btnReject = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.tmrRefresh = New System.Windows.Forms.Timer(Me.components)
        Me.pnlHeader.SuspendLayout()
        CType(Me.dgvReceivings, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDetails.SuspendLayout()
        CType(Me.dgvDetailItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBottom.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(39, 174, 96)
        Me.pnlHeader.Controls.Add(Me.lblHeaderTitle)
        Me.pnlHeader.Controls.Add(Me.lblHeaderSub)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(950, 70)
        Me.pnlHeader.TabIndex = 0
        '
        'lblHeaderTitle
        '
        Me.lblHeaderTitle.AutoSize = True
        Me.lblHeaderTitle.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblHeaderTitle.ForeColor = System.Drawing.Color.White
        Me.lblHeaderTitle.Location = New System.Drawing.Point(20, 10)
        Me.lblHeaderTitle.Name = "lblHeaderTitle"
        Me.lblHeaderTitle.Size = New System.Drawing.Size(250, 25)
        Me.lblHeaderTitle.TabIndex = 0
        Me.lblHeaderTitle.Text = "Pending Receivings"
        '
        'lblHeaderSub
        '
        Me.lblHeaderSub.AutoSize = True
        Me.lblHeaderSub.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblHeaderSub.ForeColor = System.Drawing.Color.FromArgb(220, 240, 230)
        Me.lblHeaderSub.Location = New System.Drawing.Point(22, 40)
        Me.lblHeaderSub.Name = "lblHeaderSub"
        Me.lblHeaderSub.Size = New System.Drawing.Size(500, 15)
        Me.lblHeaderSub.TabIndex = 1
        Me.lblHeaderSub.Text = "Review and approve or reject incoming delivery requests. Auto-refreshes every 3s."
        '
        'dgvReceivings
        '
        Me.dgvReceivings.AllowUserToAddRows = False
        Me.dgvReceivings.AllowUserToDeleteRows = False
        Me.dgvReceivings.BackgroundColor = System.Drawing.Color.White
        Me.dgvReceivings.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvReceivings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReceivings.Location = New System.Drawing.Point(15, 85)
        Me.dgvReceivings.MultiSelect = False
        Me.dgvReceivings.Name = "dgvReceivings"
        Me.dgvReceivings.ReadOnly = True
        Me.dgvReceivings.RowHeadersVisible = False
        Me.dgvReceivings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvReceivings.Size = New System.Drawing.Size(430, 440)
        Me.dgvReceivings.TabIndex = 1
        '
        'pnlDetails
        '
        Me.pnlDetails.BackColor = System.Drawing.Color.FromArgb(248, 249, 250)
        Me.pnlDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlDetails.Controls.Add(Me.dgvDetailItems)
        Me.pnlDetails.Controls.Add(Me.lblNotes)
        Me.pnlDetails.Controls.Add(Me.lblReceivedBy)
        Me.pnlDetails.Controls.Add(Me.lblSupplier)
        Me.pnlDetails.Controls.Add(Me.lblDetailsTitle)
        Me.pnlDetails.Location = New System.Drawing.Point(460, 85)
        Me.pnlDetails.Name = "pnlDetails"
        Me.pnlDetails.Size = New System.Drawing.Size(475, 440)
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
        Me.lblDetailsTitle.Text = "Delivery Details"
        '
        'lblSupplier
        '
        Me.lblSupplier.AutoSize = True
        Me.lblSupplier.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblSupplier.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80)
        Me.lblSupplier.Location = New System.Drawing.Point(15, 45)
        Me.lblSupplier.Name = "lblSupplier"
        Me.lblSupplier.Size = New System.Drawing.Size(100, 15)
        Me.lblSupplier.TabIndex = 1
        Me.lblSupplier.Text = "Supplier: --"
        '
        'lblReceivedBy
        '
        Me.lblReceivedBy.AutoSize = True
        Me.lblReceivedBy.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblReceivedBy.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80)
        Me.lblReceivedBy.Location = New System.Drawing.Point(15, 68)
        Me.lblReceivedBy.Name = "lblReceivedBy"
        Me.lblReceivedBy.Size = New System.Drawing.Size(120, 15)
        Me.lblReceivedBy.TabIndex = 2
        Me.lblReceivedBy.Text = "Received By: --"
        '
        'lblNotes
        '
        Me.lblNotes.AutoSize = True
        Me.lblNotes.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblNotes.ForeColor = System.Drawing.Color.Gray
        Me.lblNotes.Location = New System.Drawing.Point(15, 91)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(60, 15)
        Me.lblNotes.TabIndex = 3
        Me.lblNotes.Text = "Notes: --"
        '
        'dgvDetailItems
        '
        Me.dgvDetailItems.AllowUserToAddRows = False
        Me.dgvDetailItems.AllowUserToDeleteRows = False
        Me.dgvDetailItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDetailItems.BackgroundColor = System.Drawing.Color.White
        Me.dgvDetailItems.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvDetailItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetailItems.Location = New System.Drawing.Point(15, 120)
        Me.dgvDetailItems.Name = "dgvDetailItems"
        Me.dgvDetailItems.ReadOnly = True
        Me.dgvDetailItems.RowHeadersVisible = False
        Me.dgvDetailItems.Size = New System.Drawing.Size(445, 305)
        Me.dgvDetailItems.TabIndex = 4
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
        Me.pnlBottom.Size = New System.Drawing.Size(950, 60)
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
        Me.btnApprove.Size = New System.Drawing.Size(200, 36)
        Me.btnApprove.TabIndex = 0
        Me.btnApprove.Text = "✅ Accept && Add Stock"
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
        Me.btnReject.Location = New System.Drawing.Point(225, 12)
        Me.btnReject.Name = "btnReject"
        Me.btnReject.Size = New System.Drawing.Size(150, 36)
        Me.btnReject.TabIndex = 1
        Me.btnReject.Text = "❌ Cancel"
        Me.btnReject.UseVisualStyleBackColor = False
        '
        'btnRefresh
        '
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.btnRefresh.Location = New System.Drawing.Point(385, 12)
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
        Me.btnClose.Location = New System.Drawing.Point(835, 12)
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
        'ReceivingsApprovalForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(950, 600)
        Me.Controls.Add(Me.pnlBottom)
        Me.Controls.Add(Me.pnlDetails)
        Me.Controls.Add(Me.dgvReceivings)
        Me.Controls.Add(Me.pnlHeader)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.MinimizeBox = False
        Me.Name = "ReceivingsApprovalForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Pending Receivings"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        CType(Me.dgvReceivings, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDetails.ResumeLayout(False)
        Me.pnlDetails.PerformLayout()
        CType(Me.dgvDetailItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBottom.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblHeaderTitle As System.Windows.Forms.Label
    Friend WithEvents lblHeaderSub As System.Windows.Forms.Label
    Friend WithEvents dgvReceivings As System.Windows.Forms.DataGridView
    Friend WithEvents pnlDetails As System.Windows.Forms.Panel
    Friend WithEvents lblDetailsTitle As System.Windows.Forms.Label
    Friend WithEvents lblSupplier As System.Windows.Forms.Label
    Friend WithEvents lblReceivedBy As System.Windows.Forms.Label
    Friend WithEvents lblNotes As System.Windows.Forms.Label
    Friend WithEvents dgvDetailItems As System.Windows.Forms.DataGridView
    Friend WithEvents pnlBottom As System.Windows.Forms.Panel
    Friend WithEvents btnApprove As System.Windows.Forms.Button
    Friend WithEvents btnReject As System.Windows.Forms.Button
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents tmrRefresh As System.Windows.Forms.Timer
End Class