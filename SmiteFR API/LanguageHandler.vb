Imports System.Text.RegularExpressions
'Here we handle on a global scale the language selection so it can be included in every necessary request
Module LanguageHandler
    'List of languages (stored in combobox)
    Public Languages As List(Of String) = GetLanguageName()
    'Current supported languages by SMITE (cf: SMITE API Dev Guide)
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

    'Get the selected language code
    Public Function GetLanguageCode(ByVal MyCombo As ComboBox) As Integer
        'Default language is French (Yup I'm a french dev)
        Dim Result As Integer = 3
        'Regex match to isolate the code
        Dim match As Match = Regex.Match(MyCombo.Text, "\d\d")
        If match.Success Then
            Result = Convert.ToInt32(match.Value)
        End If
        Return Result
    End Function
End Module
