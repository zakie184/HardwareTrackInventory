Public Class ReturnForm

    Private _user As User = Nothing
    Private _issuanceID As Integer = 0
    Private _itemName As String = ""
    Private _issuedTo As String = ""
    Private _qtyIssued As Integer = 0
    Private _qtyReturned As Integer = 0
    Private _dateIssued As DateTime = DateTime.MinValue

    Public Sub New(user As User, issuanceID As Integer, itemName As String,
                   issuedTo As String, qtyIssued As Integer, qtyReturned As Integer,
                   dateIssued As DateTime)
        InitializeComponent()
        _user = user
        _issuanceID = issuanceID
        _itemName = itemName
        _issuedTo = issuedTo
        _qtyIssued = qtyIssued
        _qtyReturned = qtyReturned
        _dateIssued = dateIssued
    End Sub

    Private Sub ReturnForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblItemName.Text = _itemName
        lblIssuedTo.Text = _issuedTo
        lblDateIssued.Text = _dateIssued.ToString("MMM dd, yyyy HH:mm")
        lblQtyIssued.Text = _qtyIssued.ToString()
        lblQtyReturned.Text = _qtyReturned.ToString()

        Dim outstanding As Integer = _qtyIssued - _qtyReturned
        If outstanding <= 0 Then
            numQtyToReturn.Maximum = 1
            numQtyToReturn.Enabled = False
            btnSave.Enabled = False
        Else
            numQtyToReturn.Maximum = outstanding
            numQtyToReturn.Value = outstanding
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim qty As Integer = CInt(numQtyToReturn.Value)
        Dim notes As String = txtReturnNotes.Text.Trim()

        If DatabaseHelper.ReturnHardware(_issuanceID, qty, notes) Then
            ActivityLogger.Log(_user,
                               "Returned " & qty & "x '" & _itemName & "' from " & _issuedTo,
                               "Hardware", 0, False)
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Else
            MessageBox.Show("Failed to process return. Please try again.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

End Class