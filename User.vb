Public Class User

    Public Property ID As Integer
    Public Property Username As String
    Public Property FullName As String
    Public Property Role As String
    Public Property IsActive As Boolean
    Public Property LastLogin As DateTime

    Public ReadOnly Property RoleDisplay As String
        Get
            Select Case Role
                Case "Administrator" : Return "🔴 Administrator"
                Case "Inventory Manager" : Return "🔵 Inventory Manager"
                Case "Staff" : Return "🟢 Staff"
                Case "Viewer" : Return "⚪ Viewer"
                Case Else : Return Role
            End Select
        End Get
    End Property

    Public Function CanAccess(section As String) As Boolean
        Select Case Role
            Case "Administrator" : Return True
            Case "Inventory Manager" : Return section <> "UserManagement"
            Case "Staff" : Return {"Dashboard", "Hardware"}.Contains(section)
            Case "Viewer" : Return {"Dashboard", "Hardware"}.Contains(section)
            Case Else : Return False
        End Select
    End Function

    Public Function CanEdit() As Boolean
        Return Role = "Administrator" OrElse Role = "Inventory Manager"
    End Function

    Public Function CanDelete() As Boolean
        Return Role = "Administrator"
    End Function

    ''' <summary>
    ''' Only Admin, Manager, and Staff can submit issuance requests.
    ''' Viewer is read-only and cannot request anything.
    ''' </summary>
    Public Function CanRequestIssuance() As Boolean
        Return Role = "Administrator" OrElse Role = "Inventory Manager" OrElse Role = "Staff"
    End Function

    ''' <summary>
    ''' Only Admin and Manager can process returns.
    ''' </summary>
    Public Function CanProcessReturn() As Boolean
        Return Role = "Administrator" OrElse Role = "Inventory Manager"
    End Function

    ''' <summary>
    ''' Only Admin can approve/reject issuance requests.
    ''' </summary>
    Public Function CanApproveIssuance() As Boolean
        Return Role = "Administrator"
    End Function

    ''' <summary>
    ''' Admin and Manager see all history. Staff sees only their own. Viewer sees none.
    ''' </summary>
    Public Function CanViewIssuanceHistory() As Boolean
        Return Role = "Administrator" OrElse Role = "Inventory Manager" OrElse Role = "Staff"
    End Function

    ''' <summary>
    ''' Only Admin and Manager see all records. Staff sees only their own.
    ''' </summary>
    Public Function CanViewAllIssuances() As Boolean
        Return Role = "Administrator" OrElse Role = "Inventory Manager"
    End Function

End Class