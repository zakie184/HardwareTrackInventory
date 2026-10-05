<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class IssuanceHistoryForm
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
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblHeaderTitle = New System.Windows.Forms.Label()
        Me.lblHeaderSub = New System.Windows.Forms.Label()
        Me.pnlFilter = New System.Windows.Forms.Panel()
        Me.lblShow = New System.Windows.Forms.Label()
        Me.cmbFilter = New System.Windows.Forms.ComboBox()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.dgvIssuances = New System.Windows.Forms.DataGridView()
        Me.pnlBottom = New System.Windows.Forms.Panel()
        Me.btnReturn = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.pnlHeader.SuspendLayout()
        Me.pnlFilter.SuspendLayout()
        CType(Me.dgvIssuances, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBottom.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(26, 43, 58)
        Me.pnlHeader.Controls.Add(Me.lblHeaderTitle)
        Me.pnlHeader.Controls.Add(Me.lblHeaderSub)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(950, 65)
        Me.pnlHeader.TabIndex = 0
        '
        'lblHeaderTitle
        '
        Me.lblHeaderTitle.AutoSize = True
        Me.lblHeaderTitle.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblHeaderTitle.ForeColor = System.Drawing.Color.White
        Me.lblHeaderTitle.Location = New System.Drawing.Point(20, 8)
        Me.lblHeaderTitle.Name = "lblHeaderTitle"
        Me.lblHeaderTitle.Size = New System.Drawing.Size(180, 25)
        Me.lblHeaderTitle.TabIndex = 0
        Me.lblHeaderTitle.Text = "Issuance History"
        '
        'lblHeaderSub
        '
        Me.lblHeaderSub.AutoSize = True
        Me.lblHeaderSub.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblHeaderSub.ForeColor = System.Drawing.Color.FromArgb(189, 195, 199)
        Me.lblHeaderSub.Location = New System.Drawing.Point(22, 38)
        Me.lblHeaderSub.Name = "lblHeaderSub"
        Me.lblHeaderSub.Size = New System.Drawing.Size(280, 15)
        Me.lblHeaderSub.TabIndex = 1
        Me.lblHeaderSub.Text = "Track who has what and process returns"
        '
        'pnlFilter
        '
        Me.pnlFilter.BackColor = System.Drawing.Color.FromArgb(248, 249, 250)
        Me.pnlFilter.Controls.Add(Me.lblShow)
        Me.pnlFilter.Controls.Add(Me.cmbFilter)
        Me.pnlFilter.Controls.Add(Me.lblCount)
        Me.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFilter.Location = New System.Drawing.Point(0, 65)
        Me.pnlFilter.Name = "pnlFilter"
        Me.pnlFilter.Size = New System.Drawing.Size(950, 50)
        Me.pnlFilter.TabIndex = 1
        '
        'lblShow
        '
        Me.lblShow.AutoSize = True
        Me.lblShow.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblShow.Location = New System.Drawing.Point(15, 15)
        Me.lblShow.Name = "lblShow"
        Me.lblShow.Size = New System.Drawing.Size(38, 15)
        Me.lblShow.TabIndex = 0
        Me.lblShow.Text = "Show:"
        '
        'cmbFilter
        '
        Me.cmbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFilter.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.cmbFilter.FormattingEnabled = True
        Me.cmbFilter.Location = New System.Drawing.Point(60, 12)
        Me.cmbFilter.Name = "cmbFilter"
        Me.cmbFilter.Size = New System.Drawing.Size(220, 23)
        Me.cmbFilter.TabIndex = 1
        '
        'lblCount
        '
        Me.lblCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCount.AutoSize = True
        Me.lblCount.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic)
        Me.lblCount.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141)
        Me.lblCount.Location = New System.Drawing.Point(760, 15)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(87, 15)
        Me.lblCount.TabIndex = 2
        Me.lblCount.Text = "0 records"
        '
        'dgvIssuances
        '
        Me.dgvIssuances.AllowUserToAddRows = False
        Me.dgvIssuances.AllowUserToDeleteRows = False
        Me.dgvIssuances.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvIssuances.BackgroundColor = System.Drawing.Color.White
        Me.dgvIssuances.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvIssuances.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvIssuances.Location = New System.Drawing.Point(15, 130)
        Me.dgvIssuances.MultiSelect = False
        Me.dgvIssuances.Name = "dgvIssuances"
        Me.dgvIssuances.ReadOnly = True
        Me.dgvIssuances.RowHeadersVisible = False
        Me.dgvIssuances.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvIssuances.Size = New System.Drawing.Size(915, 415)
        Me.dgvIssuances.TabIndex = 2
        '
        'pnlBottom
        '
        Me.pnlBottom.BackColor = System.Drawing.Color.FromArgb(248, 249, 250)
        Me.pnlBottom.Controls.Add(Me.btnReturn)
        Me.pnlBottom.Controls.Add(Me.btnRefresh)
        Me.pnlBottom.Controls.Add(Me.btnClose)
        Me.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBottom.Location = New System.Drawing.Point(0, 560)
        Me.pnlBottom.Name = "pnlBottom"
        Me.pnlBottom.Size = New System.Drawing.Size(950, 60)
        Me.pnlBottom.TabIndex = 3
        '
        'btnReturn
        '
        Me.btnReturn.BackColor = System.Drawing.Color.FromArgb(155, 89, 182)
        Me.btnReturn.Enabled = False
        Me.btnReturn.FlatAppearance.BorderSize = 0
        Me.btnReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReturn.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnReturn.ForeColor = System.Drawing.Color.White
        Me.btnReturn.Location = New System.Drawing.Point(15, 12)
        Me.btnReturn.Name = "btnReturn"
        Me.btnReturn.Size = New System.Drawing.Size(170, 36)
        Me.btnReturn.TabIndex = 0
        Me.btnReturn.Text = "Process Return"
        Me.btnReturn.UseVisualStyleBackColor = False
        '
        'btnRefresh
        '
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.btnRefresh.Location = New System.Drawing.Point(195, 12)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(100, 36)
        Me.btnRefresh.TabIndex = 1
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
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'IssuanceHistoryForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(950, 620)
        Me.Controls.Add(Me.pnlBottom)
        Me.Controls.Add(Me.dgvIssuances)
        Me.Controls.Add(Me.pnlFilter)
        Me.Controls.Add(Me.pnlHeader)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.MinimizeBox = False
        Me.Name = "IssuanceHistoryForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Issuance History"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlFilter.ResumeLayout(False)
        Me.pnlFilter.PerformLayout()
        CType(Me.dgvIssuances, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBottom.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblHeaderTitle As System.Windows.Forms.Label
    Friend WithEvents lblHeaderSub As System.Windows.Forms.Label
    Friend WithEvents pnlFilter As System.Windows.Forms.Panel
    Friend WithEvents lblShow As System.Windows.Forms.Label
    Friend WithEvents cmbFilter As System.Windows.Forms.ComboBox
    Friend WithEvents lblCount As System.Windows.Forms.Label
    Friend WithEvents dgvIssuances As System.Windows.Forms.DataGridView
    Friend WithEvents pnlBottom As System.Windows.Forms.Panel
    Friend WithEvents btnReturn As System.Windows.Forms.Button
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
End Class