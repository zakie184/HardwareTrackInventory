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

    Public Function CanRequestIssuance() As Boolean
        Return Role = "Administrator" OrElse Role = "Inventory Manager" OrElse Role = "Staff"
    End Function

    Public Function CanProcessReturn() As Boolean
        Return Role = "Administrator" OrElse Role = "Inventory Manager" OrElse Role = "Staff"
    End Function

    Public Function CanApproveIssuance() As Boolean
        Return Role = "Administrator"
    End Function

    Public Function CanApproveReturn() As Boolean
        Return Role = "Administrator"
    End Function

    Public Function CanViewIssuanceHistory() As Boolean
        Return Role = "Administrator" OrElse Role = "Inventory Manager" OrElse Role = "Staff"
    End Function

    Public Function CanViewAllIssuances() As Boolean
        Return Role = "Administrator" OrElse Role = "Inventory Manager"
    End Function

End Class