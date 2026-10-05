Imports System.Drawing

Public Class IssuanceHistoryForm

    Private _user As User = Nothing
    Private _allData As DataTable = Nothing

    Public Sub New(user As User)
        InitializeComponent()
        _user = user
    End Sub

    Private Sub IssuanceHistoryForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If _user Is Nothing OrElse Not _user.CanViewIssuanceHistory() Then
            MessageBox.Show("You don't have permission to view issuance history.",
                            "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
            Return
        End If

        cmbFilter.Items.Add("All")
        cmbFilter.Items.Add("Pending approval")
        cmbFilter.Items.Add("Approved (outstanding)")
        cmbFilter.Items.Add("Partial return")
        cmbFilter.Items.Add("Fully returned")
        cmbFilter.Items.Add("Rejected")
        cmbFilter.SelectedIndex = 0

        Dim canReturn As Boolean = _user.CanProcessReturn()
        btnReturn.Visible = canReturn

        LoadIssuances()
    End Sub

    Private Sub LoadIssuances()
        Try
            Dim dt As DataTable = DatabaseHelper.GetAllIssuances()

            If _user.CanViewAllIssuances() Then
                _allData = dt
            Else
                Dim view As DataView = dt.DefaultView
                Dim safeUsername As String = _user.Username.Replace("'", "''")
                view.RowFilter = "IssuedBy = '" & safeUsername & "'"
                _allData = view.ToTable()
            End If

            ApplyFilter()
        Catch ex As Exception
            MessageBox.Show("Error loading issuances: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ApplyFilter()
        If _allData Is Nothing Then Return

        Dim view As DataView = _allData.DefaultView
        Select Case cmbFilter.SelectedIndex
            Case 1 : view.RowFilter = "ApprovalStatus = 'Pending'"
            Case 2 : view.RowFilter = "ApprovalStatus = 'Approved' AND Status = 'Issued'"
            Case 3 : view.RowFilter = "Status = 'Partial'"
            Case 4 : view.RowFilter = "Status = 'Returned'"
            Case 5 : view.RowFilter = "ApprovalStatus = 'Rejected'"
            Case Else : view.RowFilter = ""
        End Select

        dgvIssuances.DataSource = view
        FormatGrid()
        lblCount.Text = dgvIssuances.RowCount & " record(s)"
    End Sub

    Private Sub FormatGrid()
        If dgvIssuances.Columns.Count = 0 Then Return

        Dim hideCols As String() = {"IssuanceID", "HardwareID", "Notes", "ReturnNotes", "Purpose", "RejectionReason"}
        For Each c As String In hideCols
            If dgvIssuances.Columns.Contains(c) Then dgvIssuances.Columns(c).Visible = False
        Next

        SetCol("ItemName", "Item", 150)
        SetCol("QuantityIssued", "Qty", 40)
        SetCol("QuantityReturned", "Ret.", 40)
        SetCol("IssuedTo", "Issued To", 110)
        SetCol("Department", "Dept", 90)
        SetCol("IssuedBy", "By", 75)
        SetCol("DateIssued", "Date Issued", 115)
        SetCol("ExpectedReturn", "Expected", 85)
        SetCol("DateReturned", "Returned", 85)
        SetCol("Status", "Return", 70)
        SetCol("ApprovalStatus", "Approval", 80)
        SetCol("ApprovedBy", "Approved By", 90)
        SetCol("ApprovalDate", "Approved On", 115)

        ' Staff does not see approval details
        If _user.Role = "Staff" Then
            If dgvIssuances.Columns.Contains("ApprovedBy") Then dgvIssuances.Columns("ApprovedBy").Visible = False
            If dgvIssuances.Columns.Contains("ApprovalDate") Then dgvIssuances.Columns("ApprovalDate").Visible = False
        End If

        For Each row As DataGridViewRow In dgvIssuances.Rows
            If dgvIssuances.Columns.Contains("ApprovalStatus") AndAlso row.Cells("ApprovalStatus").Value IsNot DBNull.Value Then
                Select Case row.Cells("ApprovalStatus").Value.ToString()
                    Case "Pending" : row.Cells("ApprovalStatus").Style.ForeColor = Color.FromArgb(241, 196, 15)
                    Case "Approved" : row.Cells("ApprovalStatus").Style.ForeColor = Color.Green
                    Case "Rejected" : row.Cells("ApprovalStatus").Style.ForeColor = Color.Red
                End Select
            End If

            If dgvIssuances.Columns.Contains("Status") AndAlso row.Cells("Status").Value IsNot DBNull.Value Then
                Select Case row.Cells("Status").Value.ToString()
                    Case "Issued" : row.Cells("Status").Style.ForeColor = Color.OrangeRed
                    Case "Partial" : row.Cells("Status").Style.ForeColor = Color.Orange
                    Case "Returned" : row.Cells("Status").Style.ForeColor = Color.Green
                    Case "Rejected" : row.Cells("Status").Style.ForeColor = Color.Gray
                End Select
            End If
        Next
    End Sub

    Private Sub SetCol(name As String, header As String, width As Integer)
        If dgvIssuances.Columns.Contains(name) Then
            dgvIssuances.Columns(name).HeaderText = header
            dgvIssuances.Columns(name).Width = width
        End If
    End Sub

    Private Sub cmbFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFilter.SelectedIndexChanged
        ApplyFilter()
    End Sub

    Private Sub dgvIssuances_SelectionChanged(sender As Object, e As EventArgs) Handles dgvIssuances.SelectionChanged
        If dgvIssuances.SelectedRows.Count = 0 Then
            btnReturn.Enabled = False
            Return
        End If

        If _user Is Nothing OrElse Not _user.CanProcessReturn() Then
            btnReturn.Enabled = False
            Return
        End If

        Dim appr As String = ""
        Dim ret As String = ""

        If dgvIssuances.Columns.Contains("ApprovalStatus") AndAlso dgvIssuances.SelectedRows(0).Cells("ApprovalStatus").Value IsNot DBNull.Value Then
            appr = dgvIssuances.SelectedRows(0).Cells("ApprovalStatus").Value.ToString()
        End If
        If dgvIssuances.Columns.Contains("Status") AndAlso dgvIssuances.SelectedRows(0).Cells("Status").Value IsNot DBNull.Value Then
            ret = dgvIssuances.SelectedRows(0).Cells("Status").Value.ToString()
        End If

        btnReturn.Enabled = (appr = "Approved") AndAlso (ret <> "Returned")
    End Sub

    Private Sub btnReturn_Click(sender As Object, e As EventArgs) Handles btnReturn.Click
        If _user Is Nothing OrElse Not _user.CanProcessReturn() Then
            MessageBox.Show("Only Administrators and Inventory Managers can process returns.",
                            "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If dgvIssuances.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select an issuance first.",
                            "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim row As DataGridViewRow = dgvIssuances.SelectedRows(0)
        Dim issuanceID As Integer = Convert.ToInt32(row.Cells("IssuanceID").Value)
        Dim itemName As String = row.Cells("ItemName").Value.ToString()
        Dim issuedTo As String = row.Cells("IssuedTo").Value.ToString()
        Dim qtyIssued As Integer = Convert.ToInt32(row.Cells("QuantityIssued").Value)
        Dim qtyReturned As Integer = Convert.ToInt32(row.Cells("QuantityReturned").Value)
        Dim dateIssued As DateTime = Convert.ToDateTime(row.Cells("DateIssued").Value)

        Using frm As New ReturnForm(_user, issuanceID, itemName, issuedTo, qtyIssued, qtyReturned, dateIssued)
            If frm.ShowDialog(Me) = DialogResult.OK Then
                LoadIssuances()
                MessageBox.Show("Return processed successfully!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End Using
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadIssuances()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

End Class