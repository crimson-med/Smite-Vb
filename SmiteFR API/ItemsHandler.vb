'This Class is the model for Items based on the JSON response
Public Class Item
    Public Property ChildItemId As Integer
    Public Property DeviceName As String
    Public Property IconId As Integer
    Public Property ItemDescription As ItemDescription
    Public Property ItemId As Integer
    Public Property ItemTier As Integer
    Public Property Price As Integer
    Public Property RootItemId As Integer
    Public Property ShortDesc As String
    Public Property StartingItem As Boolean
    Public Property Type As String
    Public Property itemIcon_URL As String
    Public Property ret_msg As String
End Class

Public Class ItemDescription
    Public Property Description As String
    Public Property Menuitems As List(Of Menuitems)
    Public Property SecondaryDescription As String

End Class

Public Class Menuitems
    Public Property Description As String
    Public Property Value As String
End Class