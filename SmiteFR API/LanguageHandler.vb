Imports System.Text.RegularExpressions

Module LanguageHandler

    Public Languages As List(Of String) = GetLanguageName()

    Public Function GetLanguageName() As List(Of String)
        Dim Ini As New List(Of String)
        Ini.Add("01 - English")
        Ini.Add("02 - German")
        Ini.Add("03 - French")
        Ini.Add("07 - Spanish")
        Ini.Add("09 - Spanish (Latin America)")
        Ini.Add("10 - Portuguese")
        Ini.Add("11 - Russian")
        Ini.Add("12 - Polish")
        Ini.Add("13 - Turkish")
        Return Ini
    End Function

    Public Function GetLanguageCode(ByVal MyCombo As ComboBox) As Integer
        Dim Result As Integer = 3
        Dim match As Match = Regex.Match(MyCombo.Text, "\d\d")
        If match.Success Then
            Result = Convert.ToInt32(match.Value)
        End If
        Return Result
    End Function
End Module
