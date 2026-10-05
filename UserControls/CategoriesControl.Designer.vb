<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CategoriesControl
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
        Me.btnRename = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.tlpMain = New System.Windows.Forms.TableLayoutPanel()
        Me.dgvCategories = New System.Windows.Forms.DataGridView()
        Me.pnlDetails = New System.Windows.Forms.Panel()
        Me.lblDesc = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblDetailsTitle = New System.Windows.Forms.Label()
        Me.pnlContainer.SuspendLayout()
        Me.pnlToolbar.SuspendLayout()
        Me.tlpMain.SuspendLayout()
        CType(Me.dgvCategories, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDetails.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlContainer
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
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80)
        Me.lblTitle.Location = New System.Drawing.Point(15, 15)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(130, 32)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Categories"
        '
        'pnlToolbar
        '
        Me.pnlToolbar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlToolbar.BackColor = System.Drawing.Color.White
        Me.pnlToolbar.Controls.Add(Me.btnRefresh)
        Me.pnlToolbar.Controls.Add(Me.btnDelete)
        Me.pnlToolbar.Controls.Add(Me.btnRename)
        Me.pnlToolbar.Controls.Add(Me.btnAdd)
        Me.pnlToolbar.Controls.Add(Me.lblCount)
        Me.pnlToolbar.Location = New System.Drawing.Point(15, 60)
        Me.pnlToolbar.Name = "pnlToolbar"
        Me.pnlToolbar.Size = New System.Drawing.Size(1070, 50)
        Me.pnlToolbar.TabIndex = 1
        '
        'btnRefresh
        '
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnRefresh.Location = New System.Drawing.Point(240, 10)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(100, 30)
        Me.btnRefresh.TabIndex = 4
        Me.btnRefresh.Text = "🔄 Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(231, 76, 60)
        Me.btnDelete.Enabled = False
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnDelete.ForeColor = System.Drawing.Color.White
        Me.btnDelete.Location = New System.Drawing.Point(170, 10)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(60, 30)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "🗑️"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'btnRename
        '
        Me.btnRename.BackColor = System.Drawing.Color.FromArgb(241, 196, 15)
        Me.btnRename.Enabled = False
        Me.btnRename.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRename.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnRename.Location = New System.Drawing.Point(80, 10)
        Me.btnRename.Name = "btnRename"
        Me.btnRename.Size = New System.Drawing.Size(80, 30)
        Me.btnRename.TabIndex = 2
        Me.btnRename.Text = "✏️ Rename"
        Me.btnRename.UseVisualStyleBackColor = False
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.FromArgb(52, 152, 219)
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnAdd.ForeColor = System.Drawing.Color.White
        Me.btnAdd.Location = New System.Drawing.Point(10, 10)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(60, 30)
        Me.btnAdd.TabIndex = 1
        Me.btnAdd.Text = "➕"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'lblCount
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
        'tlpMain
        '
        Me.tlpMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tlpMain.BackColor = System.Drawing.Color.White
        Me.tlpMain.ColumnCount = 2
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.tlpMain.Controls.Add(Me.dgvCategories, 0, 0)
        Me.tlpMain.Controls.Add(Me.pnlDetails, 1, 0)
        Me.tlpMain.Location = New System.Drawing.Point(15, 120)
        Me.tlpMain.Name = "tlpMain"
        Me.tlpMain.RowCount = 1
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMain.Size = New System.Drawing.Size(1070, 500)
        Me.tlpMain.TabIndex = 2
        '
        'dgvCategories
        '
        Me.dgvCategories.AllowUserToAddRows = False
        Me.dgvCategories.AllowUserToDeleteRows = False
        Me.dgvCategories.BackgroundColor = System.Drawing.Color.White
        Me.dgvCategories.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvCategories.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCategories.Location = New System.Drawing.Point(3, 3)
        Me.dgvCategories.MultiSelect = False
        Me.dgvCategories.Name = "dgvCategories"
        Me.dgvCategories.ReadOnly = True
        Me.dgvCategories.RowHeadersVisible = False
        Me.dgvCategories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCategories.Size = New System.Drawing.Size(636, 494)
        Me.dgvCategories.TabIndex = 1
        '
        'pnlDetails
        '
        Me.pnlDetails.BackColor = System.Drawing.Color.FromArgb(248, 249, 250)
        Me.pnlDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlDetails.Controls.Add(Me.lblDesc)
        Me.pnlDetails.Controls.Add(Me.lblName)
        Me.pnlDetails.Controls.Add(Me.lblDetailsTitle)
        Me.pnlDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDetails.Location = New System.Drawing.Point(645, 3)
        Me.pnlDetails.Name = "pnlDetails"
        Me.pnlDetails.Size = New System.Drawing.Size(422, 494)
        Me.pnlDetails.TabIndex = 0
        '
        'lblDesc
        '
        Me.lblDesc.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.lblDesc.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141)
        Me.lblDesc.Location = New System.Drawing.Point(15, 90)
        Me.lblDesc.Name = "lblDesc"
        Me.lblDesc.Size = New System.Drawing.Size(390, 120)
        Me.lblDesc.TabIndex = 2
        Me.lblDesc.Text = ""
        '
        'lblName
        '
        Me.lblName.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblName.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80)
        Me.lblName.Location = New System.Drawing.Point(15, 50)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(390, 30)
        Me.lblName.TabIndex = 1
        Me.lblName.Text = "Select a category"
        '
        'lblDetailsTitle
        '
        Me.lblDetailsTitle.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblDetailsTitle.Location = New System.Drawing.Point(15, 15)
        Me.lblDetailsTitle.Name = "lblDetailsTitle"
        Me.lblDetailsTitle.Size = New System.Drawing.Size(390, 20)
        Me.lblDetailsTitle.TabIndex = 0
        Me.lblDetailsTitle.Text = "📄 Category Details"
        '
        'CategoriesControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.pnlContainer)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Name = "CategoriesControl"
        Me.Size = New System.Drawing.Size(1100, 700)
        Me.pnlContainer.ResumeLayout(False)
        Me.pnlContainer.PerformLayout()
        Me.pnlToolbar.ResumeLayout(False)
        Me.pnlToolbar.PerformLayout()
        Me.tlpMain.ResumeLayout(False)
        CType(Me.dgvCategories, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDetails.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlContainer As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents pnlToolbar As System.Windows.Forms.Panel
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnRename As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents lblCount As System.Windows.Forms.Label
    Friend WithEvents tlpMain As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlDetails As System.Windows.Forms.Panel
    Friend WithEvents lblDetailsTitle As System.Windows.Forms.Label
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents lblDesc As System.Windows.Forms.Label
    Friend WithEvents dgvCategories As System.Windows.Forms.DataGridView
End Class