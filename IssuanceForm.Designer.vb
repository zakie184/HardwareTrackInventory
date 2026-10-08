<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class IssuanceForm
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
        Me.lblItemLbl = New System.Windows.Forms.Label()
        Me.lblItemName = New System.Windows.Forms.Label()
        Me.lblStockLbl = New System.Windows.Forms.Label()
        Me.lblStock = New System.Windows.Forms.Label()
        Me.lblQuantity = New System.Windows.Forms.Label()
        Me.numQuantity = New System.Windows.Forms.NumericUpDown()
        Me.lblIssuedTo = New System.Windows.Forms.Label()
        Me.cmbIssuedTo = New System.Windows.Forms.ComboBox()
        Me.lblDepartment = New System.Windows.Forms.Label()
        Me.cmbDepartment = New System.Windows.Forms.ComboBox()
        Me.pnlBottom = New System.Windows.Forms.Panel()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.pnlHeader.SuspendLayout()
        CType(Me.numQuantity, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pnlHeader.Size = New System.Drawing.Size(500, 70)
        Me.pnlHeader.TabIndex = 0
        '
        'lblHeaderTitle
        '
        Me.lblHeaderTitle.AutoSize = True
        Me.lblHeaderTitle.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblHeaderTitle.ForeColor = System.Drawing.Color.White
        Me.lblHeaderTitle.Location = New System.Drawing.Point(25, 12)
        Me.lblHeaderTitle.Name = "lblHeaderTitle"
        Me.lblHeaderTitle.Size = New System.Drawing.Size(180, 25)
        Me.lblHeaderTitle.TabIndex = 0
        Me.lblHeaderTitle.Text = "Issue Hardware"
        '
        'lblHeaderSub
        '
        Me.lblHeaderSub.AutoSize = True
        Me.lblHeaderSub.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblHeaderSub.ForeColor = System.Drawing.Color.FromArgb(189, 195, 199)
        Me.lblHeaderSub.Location = New System.Drawing.Point(27, 42)
        Me.lblHeaderSub.Name = "lblHeaderSub"
        Me.lblHeaderSub.Size = New System.Drawing.Size(320, 15)
        Me.lblHeaderSub.TabIndex = 1
        Me.lblHeaderSub.Text = "Fill in the required fields marked with *"
        '
        'lblItemLbl
        '
        Me.lblItemLbl.AutoSize = True
        Me.lblItemLbl.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblItemLbl.ForeColor = System.Drawing.Color.Gray
        Me.lblItemLbl.Location = New System.Drawing.Point(30, 95)
        Me.lblItemLbl.Name = "lblItemLbl"
        Me.lblItemLbl.Size = New System.Drawing.Size(34, 15)
        Me.lblItemLbl.TabIndex = 2
        Me.lblItemLbl.Text = "Item:"
        '
        'lblItemName
        '
        Me.lblItemName.AutoSize = True
        Me.lblItemName.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblItemName.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80)
        Me.lblItemName.Location = New System.Drawing.Point(80, 94)
        Me.lblItemName.Name = "lblItemName"
        Me.lblItemName.Size = New System.Drawing.Size(80, 19)
        Me.lblItemName.TabIndex = 3
        Me.lblItemName.Text = "(item name)"
        '
        'lblStockLbl
        '
        Me.lblStockLbl.AutoSize = True
        Me.lblStockLbl.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblStockLbl.ForeColor = System.Drawing.Color.Gray
        Me.lblStockLbl.Location = New System.Drawing.Point(30, 120)
        Me.lblStockLbl.Name = "lblStockLbl"
        Me.lblStockLbl.Size = New System.Drawing.Size(55, 15)
        Me.lblStockLbl.TabIndex = 4
        Me.lblStockLbl.Text = "In Stock:"
        '
        'lblStock
        '
        Me.lblStock.AutoSize = True
        Me.lblStock.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblStock.ForeColor = System.Drawing.Color.FromArgb(46, 204, 113)
        Me.lblStock.Location = New System.Drawing.Point(100, 119)
        Me.lblStock.Name = "lblStock"
        Me.lblStock.Size = New System.Drawing.Size(30, 19)
        Me.lblStock.TabIndex = 5
        Me.lblStock.Text = "0"
        '
        'lblQuantity
        '
        Me.lblQuantity.AutoSize = True
        Me.lblQuantity.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblQuantity.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80)
        Me.lblQuantity.Location = New System.Drawing.Point(30, 160)
        Me.lblQuantity.Name = "lblQuantity"
        Me.lblQuantity.Size = New System.Drawing.Size(105, 15)
        Me.lblQuantity.TabIndex = 6
        Me.lblQuantity.Text = "Quantity to Issue *"
        '
        'numQuantity
        '
        Me.numQuantity.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.numQuantity.Location = New System.Drawing.Point(30, 180)
        Me.numQuantity.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.numQuantity.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numQuantity.Name = "numQuantity"
        Me.numQuantity.Size = New System.Drawing.Size(150, 25)
        Me.numQuantity.TabIndex = 7
        Me.numQuantity.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblIssuedTo
        '
        Me.lblIssuedTo.AutoSize = True
        Me.lblIssuedTo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblIssuedTo.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80)
        Me.lblIssuedTo.Location = New System.Drawing.Point(30, 225)
        Me.lblIssuedTo.Name = "lblIssuedTo"
        Me.lblIssuedTo.Size = New System.Drawing.Size(68, 15)
        Me.lblIssuedTo.TabIndex = 8
        Me.lblIssuedTo.Text = "Issued To *"
        '
        'cmbIssuedTo
        '
        Me.cmbIssuedTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbIssuedTo.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmbIssuedTo.FormattingEnabled = True
        Me.cmbIssuedTo.Location = New System.Drawing.Point(30, 245)
        Me.cmbIssuedTo.Name = "cmbIssuedTo"
        Me.cmbIssuedTo.Size = New System.Drawing.Size(420, 25)
        Me.cmbIssuedTo.TabIndex = 9
        '
        'lblDepartment
        '
        Me.lblDepartment.AutoSize = True
        Me.lblDepartment.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblDepartment.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80)
        Me.lblDepartment.Location = New System.Drawing.Point(30, 290)
        Me.lblDepartment.Name = "lblDepartment"
        Me.lblDepartment.Size = New System.Drawing.Size(84, 15)
        Me.lblDepartment.TabIndex = 10
        Me.lblDepartment.Text = "Department *"
        '
        'cmbDepartment
        '
        Me.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDepartment.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cmbDepartment.FormattingEnabled = True
        Me.cmbDepartment.Location = New System.Drawing.Point(30, 310)
        Me.cmbDepartment.Name = "cmbDepartment"
        Me.cmbDepartment.Size = New System.Drawing.Size(420, 25)
        Me.cmbDepartment.TabIndex = 11
        '
        'pnlBottom
        '
        Me.pnlBottom.BackColor = System.Drawing.Color.FromArgb(248, 249, 250)
        Me.pnlBottom.Controls.Add(Me.btnSave)
        Me.pnlBottom.Controls.Add(Me.btnCancel)
        Me.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBottom.Location = New System.Drawing.Point(0, 380)
        Me.pnlBottom.Name = "pnlBottom"
        Me.pnlBottom.Size = New System.Drawing.Size(500, 70)
        Me.pnlBottom.TabIndex = 12
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(52, 152, 219)
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(200, 15)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(150, 40)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "Issue Now"
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
        Me.btnCancel.Location = New System.Drawing.Point(360, 15)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(90, 40)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'IssuanceForm
        '
        Me.AcceptButton = Me.btnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(500, 450)
        Me.Controls.Add(Me.cmbDepartment)
        Me.Controls.Add(Me.lblDepartment)
        Me.Controls.Add(Me.cmbIssuedTo)
        Me.Controls.Add(Me.lblIssuedTo)
        Me.Controls.Add(Me.numQuantity)
        Me.Controls.Add(Me.lblQuantity)
        Me.Controls.Add(Me.lblStock)
        Me.Controls.Add(Me.lblStockLbl)
        Me.Controls.Add(Me.lblItemName)
        Me.Controls.Add(Me.lblItemLbl)
        Me.Controls.Add(Me.pnlBottom)
        Me.Controls.Add(Me.pnlHeader)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "IssuanceForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Issue Hardware"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        CType(Me.numQuantity, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBottom.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblHeaderTitle As System.Windows.Forms.Label
    Friend WithEvents lblHeaderSub As System.Windows.Forms.Label
    Friend WithEvents lblItemLbl As System.Windows.Forms.Label
    Friend WithEvents lblItemName As System.Windows.Forms.Label
    Friend WithEvents lblStockLbl As System.Windows.Forms.Label
    Friend WithEvents lblStock As System.Windows.Forms.Label
    Friend WithEvents lblQuantity As System.Windows.Forms.Label
    Friend WithEvents numQuantity As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblIssuedTo As System.Windows.Forms.Label
    Friend WithEvents cmbIssuedTo As System.Windows.Forms.ComboBox
    Friend WithEvents lblDepartment As System.Windows.Forms.Label
    Friend WithEvents cmbDepartment As System.Windows.Forms.ComboBox
    Friend WithEvents pnlBottom As System.Windows.Forms.Panel
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class