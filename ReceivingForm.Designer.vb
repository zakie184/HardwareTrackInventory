<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ReceivingForm
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
        Me.lblSupplier = New System.Windows.Forms.Label()
        Me.cmbSupplier = New System.Windows.Forms.ComboBox()
        Me.lblNotes = New System.Windows.Forms.Label()
        Me.txtNotes = New System.Windows.Forms.TextBox()
        Me.lblItems = New System.Windows.Forms.Label()
        Me.dgvItems = New System.Windows.Forms.DataGridView()
        Me.colItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCategory = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colLocation = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnAddRow = New System.Windows.Forms.Button()
        Me.btnRemoveRow = New System.Windows.Forms.Button()
        Me.pnlBottom = New System.Windows.Forms.Panel()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.pnlHeader.SuspendLayout()
        CType(Me.dgvItems, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlHeader.Size = New System.Drawing.Size(720, 70)
        Me.pnlHeader.TabIndex = 0
        '
        'lblHeaderTitle
        '
        Me.lblHeaderTitle.AutoSize = True
        Me.lblHeaderTitle.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblHeaderTitle.ForeColor = System.Drawing.Color.White
        Me.lblHeaderTitle.Location = New System.Drawing.Point(25, 12)
        Me.lblHeaderTitle.Name = "lblHeaderTitle"
        Me.lblHeaderTitle.Size = New System.Drawing.Size(200, 25)
        Me.lblHeaderTitle.TabIndex = 0
        Me.lblHeaderTitle.Text = "Receive Delivery"
        '
        'lblHeaderSub
        '
        Me.lblHeaderSub.AutoSize = True
        Me.lblHeaderSub.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblHeaderSub.ForeColor = System.Drawing.Color.FromArgb(220, 240, 230)
        Me.lblHeaderSub.Location = New System.Drawing.Point(27, 42)
        Me.lblHeaderSub.Name = "lblHeaderSub"
        Me.lblHeaderSub.Size = New System.Drawing.Size(400, 15)
        Me.lblHeaderSub.TabIndex = 1
        Me.lblHeaderSub.Text = "Record incoming stock from supplier"
        '
        'lblSupplier
        '
        Me.lblSupplier.AutoSize = True
        Me.lblSupplier.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblSupplier.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80)
        Me.lblSupplier.Location = New System.Drawing.Point(30, 90)
        Me.lblSupplier.Name = "lblSupplier"
        Me.lblSupplier.Size = New System.Drawing.Size(58, 15)
        Me.lblSupplier.TabIndex = 2
        Me.lblSupplier.Text = "Supplier"
        '
        'cmbSupplier
        '
        Me.cmbSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        Me.cmbSupplier.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmbSupplier.FormattingEnabled = True
        Me.cmbSupplier.Location = New System.Drawing.Point(30, 110)
        Me.cmbSupplier.Name = "cmbSupplier"
        Me.cmbSupplier.Size = New System.Drawing.Size(280, 25)
        Me.cmbSupplier.TabIndex = 3
        '
        'lblNotes
        '
        Me.lblNotes.AutoSize = True
        Me.lblNotes.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblNotes.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80)
        Me.lblNotes.Location = New System.Drawing.Point(340, 90)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(42, 15)
        Me.lblNotes.TabIndex = 4
        Me.lblNotes.Text = "Notes"
        '
        'txtNotes
        '
        Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNotes.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtNotes.Location = New System.Drawing.Point(340, 110)
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(350, 25)
        Me.txtNotes.TabIndex = 5
        '
        'lblItems
        '
        Me.lblItems.AutoSize = True
        Me.lblItems.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblItems.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80)
        Me.lblItems.Location = New System.Drawing.Point(30, 155)
        Me.lblItems.Name = "lblItems"
        Me.lblItems.Size = New System.Drawing.Size(150, 19)
        Me.lblItems.TabIndex = 6
        Me.lblItems.Text = "Items to Receive"
        '
        'dgvItems
        '
        Me.dgvItems.AllowUserToAddRows = False
        Me.dgvItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvItems.BackgroundColor = System.Drawing.Color.White
        Me.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colItemName, Me.colCategory, Me.colLocation, Me.colQty})
        Me.dgvItems.Location = New System.Drawing.Point(30, 180)
        Me.dgvItems.Name = "dgvItems"
        Me.dgvItems.RowHeadersVisible = False
        Me.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvItems.Size = New System.Drawing.Size(660, 260)
        Me.dgvItems.TabIndex = 7
        '
        'colItemName
        '
        Me.colItemName.HeaderText = "Item Name"
        Me.colItemName.Name = "colItemName"
        Me.colItemName.Width = 220
        '
        'colCategory
        '
        Me.colCategory.HeaderText = "Category"
        Me.colCategory.Name = "colCategory"
        Me.colCategory.Width = 140
        '
        'colLocation
        '
        Me.colLocation.HeaderText = "Location"
        Me.colLocation.Name = "colLocation"
        Me.colLocation.Width = 140
        '
        'colQty
        '
        Me.colQty.HeaderText = "Qty"
        Me.colQty.Name = "colQty"
        Me.colQty.Width = 80
        '
        'btnAddRow
        '
        Me.btnAddRow.BackColor = System.Drawing.Color.FromArgb(52, 152, 219)
        Me.btnAddRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddRow.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnAddRow.ForeColor = System.Drawing.Color.White
        Me.btnAddRow.Location = New System.Drawing.Point(30, 450)
        Me.btnAddRow.Name = "btnAddRow"
        Me.btnAddRow.Size = New System.Drawing.Size(120, 32)
        Me.btnAddRow.TabIndex = 8
        Me.btnAddRow.Text = "➕ Add Item"
        Me.btnAddRow.UseVisualStyleBackColor = False
        '
        'btnRemoveRow
        '
        Me.btnRemoveRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRemoveRow.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnRemoveRow.Location = New System.Drawing.Point(160, 450)
        Me.btnRemoveRow.Name = "btnRemoveRow"
        Me.btnRemoveRow.Size = New System.Drawing.Size(140, 32)
        Me.btnRemoveRow.TabIndex = 9
        Me.btnRemoveRow.Text = "🗑️ Remove Selected"
        Me.btnRemoveRow.UseVisualStyleBackColor = True
        '
        'pnlBottom
        '
        Me.pnlBottom.BackColor = System.Drawing.Color.FromArgb(248, 249, 250)
        Me.pnlBottom.Controls.Add(Me.btnSave)
        Me.pnlBottom.Controls.Add(Me.btnCancel)
        Me.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBottom.Location = New System.Drawing.Point(0, 500)
        Me.pnlBottom.Name = "pnlBottom"
        Me.pnlBottom.Size = New System.Drawing.Size(720, 70)
        Me.pnlBottom.TabIndex = 10
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(39, 174, 96)
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(380, 15)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(170, 40)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "Submit"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.White
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(189, 195, 199)
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.btnCancel.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80)
        Me.btnCancel.Location = New System.Drawing.Point(565, 15)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(125, 40)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'ReceivingForm
        '
        Me.AcceptButton = Me.btnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(720, 570)
        Me.Controls.Add(Me.btnRemoveRow)
        Me.Controls.Add(Me.btnAddRow)
        Me.Controls.Add(Me.dgvItems)
        Me.Controls.Add(Me.lblItems)
        Me.Controls.Add(Me.txtNotes)
        Me.Controls.Add(Me.lblNotes)
        Me.Controls.Add(Me.cmbSupplier)
        Me.Controls.Add(Me.lblSupplier)
        Me.Controls.Add(Me.pnlBottom)
        Me.Controls.Add(Me.pnlHeader)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ReceivingForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Receive Delivery"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        CType(Me.dgvItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBottom.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblHeaderTitle As System.Windows.Forms.Label
    Friend WithEvents lblHeaderSub As System.Windows.Forms.Label
    Friend WithEvents lblSupplier As System.Windows.Forms.Label
    Friend WithEvents cmbSupplier As System.Windows.Forms.ComboBox
    Friend WithEvents lblNotes As System.Windows.Forms.Label
    Friend WithEvents txtNotes As System.Windows.Forms.TextBox
    Friend WithEvents lblItems As System.Windows.Forms.Label
    Friend WithEvents dgvItems As System.Windows.Forms.DataGridView
    Friend WithEvents colItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCategory As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colLocation As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnAddRow As System.Windows.Forms.Button
    Friend WithEvents btnRemoveRow As System.Windows.Forms.Button
    Friend WithEvents pnlBottom As System.Windows.Forms.Panel
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class