Imports System.Drawing

Public MustInherit Class BaseItem

    Public Property ID As Integer
    Public Property Name As String
    Public Property Category As String
    Public Property Quantity As Integer
    Public Property Location As String
    Public Property Status As String

    Public MustOverride Function GetStatusColor() As Color
    Public MustOverride Function GetStatusIcon() As String

    Public Overridable Function IsAvailable() As Boolean
        Return Status = "Available" AndAlso Quantity > 0
    End Function

    Public Overridable Function IsLowStock() As Boolean
        Return Quantity <= 5
    End Function

End Class