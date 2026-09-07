Imports System.Drawing

Public Class HardwareItem
    Inherits BaseItem

    Public Overrides Function GetStatusColor() As Color
        Select Case Status
            Case "Available" : Return Color.Green
            Case "Assigned" : Return Color.FromArgb(52, 152, 219)
            Case "In Use" : Return Color.FromArgb(241, 196, 15)
            Case Else : Return Color.Gray
        End Select
    End Function

    Public Overrides Function GetStatusIcon() As String
        Select Case Status
            Case "Available" : Return "✅"
            Case "Assigned" : Return "📋"
            Case "In Use" : Return "🔄"
            Case Else : Return "⚪"
        End Select
    End Function

End Class