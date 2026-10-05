<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ReturnForm
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
        Me.lblIssuedToLbl = New System.Windows.Forms.Label()
        Me.lblIssuedTo = New System.Windows.Forms.Label()
        Me.lblDateIssuedLbl = New System.Windows.Forms.Label()
        Me.lblDateIssued = New System.Windows.Forms.Label()
        Me.lblQtyIssuedLbl = New System.Windows.Forms.Label()
        Me.lblQtyIssued = New System.Windows.Forms.Label()
        Me.lblQtyReturnedLbl = New System.Windows.Forms.Label()
        Me.lblQtyReturned = New System.Windows.Forms.Label()
        Me.lblQtyToReturn = New System.Windows.Forms.Label()
        Me.numQtyToReturn = New System.Windows.Forms.NumericUpDown()
        Me.lblReturnNotes = New System.Windows.Forms.Label()
        Me.txtReturnNotes = New System.Windows.Forms.TextBox()
        Me.pnlBottom = New System.Windows.Forms.Panel()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.pnlHeader.SuspendLayout()
        CType(Me.numQtyToReturn, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.lblHeaderTitle.Size = New System.Drawing.Size(195, 25)
        Me.lblHeaderTitle.TabIndex = 0
        Me.lblHeaderTitle.Text = "Return Hardware"
        '
        'lblHeaderSub
        '
        Me.lblHeaderSub.AutoSize = True
        Me.lblHeaderSub.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblHeaderSub.ForeColor = System.Drawing.Color.FromArgb(230, 230, 230)
        Me.lblHeaderSub.Location = New System.Drawing.Point(27, 42)
        Me.lblHeaderSub.Name = "lblHeaderSub"
        Me.lblHeaderSub.Size = New System.Drawing.Size(280, 15)
        Me.lblHeaderSub.TabIndex = 1
        Me.lblHeaderSub.Text = "Record items returned from the borrower"
        '
        'lblItemLbl
        '
        Me.lblItemLbl.AutoSize = True
        Me.lblItemLbl.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblItemLbl.ForeColor = System.Drawing.Color.Gray
        Me.lblItemLbl.Location = New System.Drawing.Point(30, 85)
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
        Me.lblItemName.Location = New System.Drawing.Point(30, 105)
        Me.lblItemName.Name = "lblItemName"
        Me.lblItemName.Size = New System.Drawing.Size(80, 19)
        Me.lblItemName.TabIndex = 3
        Me.lblItemName.Text = "(item name)"
        '
        'lblIssuedToLbl
        '
        Me.lblIssuedToLbl.AutoSize = True
        Me.lblIssuedToLbl.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblIssuedToLbl.ForeColor = System.Drawing.Color.Gray
        Me.lblIssuedToLbl.Location = New System.Drawing.Point(30, 135)
        Me.lblIssuedToLbl.Name = "lblIssuedToLbl"
        Me.lblIssuedToLbl.Size = New System.Drawing.Size(58, 15)
        Me.lblIssuedToLbl.TabIndex = 4
        Me.lblIssuedToLbl.Text = "Issued To:"
        '
        'lblIssuedTo
        '
        Me.lblIssuedTo.AutoSize = True
        Me.lblIssuedTo.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblIssuedTo.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80)
        Me.lblIssuedTo.Location = New System.Drawing.Point(30, 155)
        Me.lblIssuedTo.Name = "lblIssuedTo"
        Me.lblIssuedTo.Size = New System.Drawing.Size(80, 19)
        Me.lblIssuedTo.TabIndex = 5
        Me.lblIssuedTo.Text = "(person)"
        '
        'lblDateIssuedLbl
        '
        Me.lblDateIssuedLbl.AutoSize = True
        Me.lblDateIssuedLbl.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblDateIssuedLbl.ForeColor = System.Drawing.Color.Gray
        Me.lblDateIssuedLbl.Location = New System.Drawing.Point(30, 185)
        Me.lblDateIssuedLbl.Name = "lblDateIssuedLbl"
        Me.lblDateIssuedLbl.Size = New System.Drawing.Size(72, 15)
        Me.lblDateIssuedLbl.TabIndex = 6
        Me.lblDateIssuedLbl.Text = "Date Issued:"
        '
        'lblDateIssued
        '
        Me.lblDateIssued.AutoSize = True
        Me.lblDateIssued.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblDateIssued.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80)
        Me.lblDateIssued.Location = New System.Drawing.Point(30, 205)
        Me.lblDateIssued.Name = "lblDateIssued"
        Me.lblDateIssued.Size = New System.Drawing.Size(80, 19)
        Me.lblDateIssued.TabIndex = 7
        Me.lblDateIssued.Text = "(date)"
        '
        'lblQtyIssuedLbl
        '
        Me.lblQtyIssuedLbl.AutoSize = True
        Me.lblQtyIssuedLbl.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblQtyIssuedLbl.ForeColor = System.Drawing.Color.Gray
        Me.lblQtyIssuedLbl.Location = New System.Drawing.Point(280, 185)
        Me.lblQtyIssuedLbl.Name = "lblQtyIssuedLbl"
        Me.lblQtyIssuedLbl.Size = New System.Drawing.Size(72, 15)
        Me.lblQtyIssuedLbl.TabIndex = 8
        Me.lblQtyIssuedLbl.Text = "Qty Issued:"
        '
        'lblQtyIssued
        '
        Me.lblQtyIssued.AutoSize = True
        Me.lblQtyIssued.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblQtyIssued.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80)
        Me.lblQtyIssued.Location = New System.Drawing.Point(280, 205)
        Me.lblQtyIssued.Name = "lblQtyIssued"
        Me.lblQtyIssued.Size = New System.Drawing.Size(30, 19)
        Me.lblQtyIssued.TabIndex = 9
        Me.lblQtyIssued.Text = "0"
        '
        'lblQtyReturnedLbl
        '
        Me.lblQtyReturnedLbl.AutoSize = True
        Me.lblQtyReturnedLbl.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblQtyReturnedLbl.ForeColor = System.Drawing.Color.Gray
        Me.lblQtyReturnedLbl.Location = New System.Drawing.Point(30, 240)
        Me.lblQtyReturnedLbl.Name = "lblQtyReturnedLbl"
        Me.lblQtyReturnedLbl.Size = New System.Drawing.Size(90, 15)
        Me.lblQtyReturnedLbl.TabIndex = 10
        Me.lblQtyReturnedLbl.Text = "Already Returned:"
        '
        'lblQtyReturned
        '
        Me.lblQtyReturned.AutoSize = True
        Me.lblQtyReturned.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblQtyReturned.ForeColor = System.Drawing.Color.FromArgb(155, 89, 182)
        Me.lblQtyReturned.Location = New System.Drawing.Point(150, 239)
        Me.lblQtyReturned.Name = "lblQtyReturned"
        Me.lblQtyReturned.Size = New System.Drawing.Size(30, 19)
        Me.lblQtyReturned.TabIndex = 11
        Me.lblQtyReturned.Text = "0"
        '
        'lblQtyToReturn
        '
        Me.lblQtyToReturn.AutoSize = True
        Me.lblQtyToReturn.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblQtyToReturn.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80)
        Me.lblQtyToReturn.Location = New System.Drawing.Point(30, 280)
        Me.lblQtyToReturn.Name = "lblQtyToReturn"
        Me.lblQtyToReturn.Size = New System.Drawing.Size(115, 15)
        Me.lblQtyToReturn.TabIndex = 12
        Me.lblQtyToReturn.Text = "Quantity to Return *"
        '
        'numQtyToReturn
        '
        Me.numQtyToReturn.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.numQtyToReturn.Location = New System.Drawing.Point(30, 300)
        Me.numQtyToReturn.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.numQtyToReturn.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numQtyToReturn.Name = "numQtyToReturn"
        Me.numQtyToReturn.Size = New System.Drawing.Size(150, 25)
        Me.numQtyToReturn.TabIndex = 13
        Me.numQtyToReturn.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblReturnNotes
        '
        Me.lblReturnNotes.AutoSize = True
        Me.lblReturnNotes.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblReturnNotes.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80)
        Me.lblReturnNotes.Location = New System.Drawing.Point(30, 340)
        Me.lblReturnNotes.Name = "lblReturnNotes"
        Me.lblReturnNotes.Size = New System.Drawing.Size(42, 15)
        Me.lblReturnNotes.TabIndex = 14
        Me.lblReturnNotes.Text = "Notes"
        '
        'txtReturnNotes
        '
        Me.txtReturnNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReturnNotes.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txtReturnNotes.Location = New System.Drawing.Point(30, 360)
        Me.txtReturnNotes.Multiline = True
        Me.txtReturnNotes.Name = "txtReturnNotes"
        Me.txtReturnNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtReturnNotes.Size = New System.Drawing.Size(420, 60)
        Me.txtReturnNotes.TabIndex = 15
        '
        'pnlBottom
        '
        Me.pnlBottom.BackColor = System.Drawing.Color.FromArgb(248, 249, 250)
        Me.pnlBottom.Controls.Add(Me.btnSave)
        Me.pnlBottom.Controls.Add(Me.btnCancel)
        Me.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBottom.Location = New System.Drawing.Point(0, 445)
        Me.pnlBottom.Name = "pnlBottom"
        Me.pnlBottom.Size = New System.Drawing.Size(500, 70)
        Me.pnlBottom.TabIndex = 16
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(155, 89, 182)
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(220, 15)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(130, 40)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "Return"
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
        'ReturnForm
        '
        Me.AcceptButton = Me.btnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(500, 515)
        Me.Controls.Add(Me.txtReturnNotes)
        Me.Controls.Add(Me.lblReturnNotes)
        Me.Controls.Add(Me.numQtyToReturn)
        Me.Controls.Add(Me.lblQtyToReturn)
        Me.Controls.Add(Me.lblQtyReturned)
        Me.Controls.Add(Me.lblQtyReturnedLbl)
        Me.Controls.Add(Me.lblQtyIssued)
        Me.Controls.Add(Me.lblQtyIssuedLbl)
        Me.Controls.Add(Me.lblDateIssued)
        Me.Controls.Add(Me.lblDateIssuedLbl)
        Me.Controls.Add(Me.lblIssuedTo)
        Me.Controls.Add(Me.lblIssuedToLbl)
        Me.Controls.Add(Me.lblItemName)
        Me.Controls.Add(Me.lblItemLbl)
        Me.Controls.Add(Me.pnlBottom)
        Me.Controls.Add(Me.pnlHeader)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ReturnForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Return Hardware"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        CType(Me.numQtyToReturn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBottom.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblHeaderTitle As System.Windows.Forms.Label
    Friend WithEvents lblHeaderSub As System.Windows.Forms.Label
    Friend WithEvents lblItemLbl As System.Windows.Forms.Label
    Friend WithEvents lblItemName As System.Windows.Forms.Label
    Friend WithEvents lblIssuedToLbl As System.Windows.Forms.Label
    Friend WithEvents lblIssuedTo As System.Windows.Forms.Label
    Friend WithEvents lblDateIssuedLbl As System.Windows.Forms.Label
    Friend WithEvents lblDateIssued As System.Windows.Forms.Label
    Friend WithEvents lblQtyIssuedLbl As System.Windows.Forms.Label
    Friend WithEvents lblQtyIssued As System.Windows.Forms.Label
    Friend WithEvents lblQtyReturnedLbl As System.Windows.Forms.Label
    Friend WithEvents lblQtyReturned As System.Windows.Forms.Label
    Friend WithEvents lblQtyToReturn As System.Windows.Forms.Label
    Friend WithEvents numQtyToReturn As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblReturnNotes As System.Windows.Forms.Label
    Friend WithEvents txtReturnNotes As System.Windows.Forms.TextBox
    Friend WithEvents pnlBottom As System.Windows.Forms.Panel
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class