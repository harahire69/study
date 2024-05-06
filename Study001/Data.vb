Public Class SampleHeader
    Public Property HeaderId As Long
    Public Property HeaderName As String
    Public Property LastUpdate As Date

End Class

Public Class SampleDetail
    Public Property DetailId As Long
    Public Property HeaderId As Long
    Public Property ItemId As Long
    Public Property Quantity As Integer
    Public Property LastUpdate As Date
End Class

Public Class SampleItem
    Public Property ItemId As Long
    Public Property ItemName As String
    Public Property ItemTypeCode As String
    Public Property ItemPrice As Decimal
    Public Property LastUpdate As Date
End Class

Public Class SampleDetailWithItem
    Public Property DetailId As Long
    Public Property HeaderId As Long
    Public Property ItemId As Long
    Public Property Quantity As Integer
    Public Property ItemName As String
    Public Property ItemTypeCode As String
    Public Property ItemPrice As Decimal
End Class
