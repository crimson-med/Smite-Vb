Imports System.IO

Module LogHandler
    Public Sub LogSession(ByVal TimeStamp As DateTime)
        If File.Exists(AppLog & "\Session.log") Then
            Dim CurrentData, Input, ToWrite As String
            CurrentData = File.ReadAllText(AppLog & "\Session.log")
            Input = "New Session Created: " & SessionKey & " At: " & TimeStamp.ToString("M/dd/yyyy h:mm:ss tt")
            ToWrite = CurrentData & vbNewLine & Input
            File.WriteAllText(AppLog & "\Session.log", ToWrite)
        Else
            Dim Input As String
            Input = "New Session Created: " & SessionKey & " At: " & TimeStamp.ToString("M/dd/yyyy h:mm:ss tt")
            File.WriteAllText(AppLog & "\Session.log", Input)
        End If
        If File.Exists(AppData & "\Session.crimson") Then
            File.Delete(AppData & "\Session.crimson")
            Dim Input As String
            Input = SessionKey & "***" & TimeStamp.ToString("M/dd/yyyy h:mm:ss tt")
            File.WriteAllText(AppData & "\Session.crimson", Input)
        Else
            Dim Input As String
            Input = SessionKey & "***" & TimeStamp.ToString("M/dd/yyyy h:mm:ss tt")
            File.WriteAllText(AppData & "\Session.crimson", Input)
        End If
    End Sub

    Public Sub LogError(ByVal Data As String, ByVal TimeStamp As DateTime, ByVal ErrorType As String)
        If File.Exists(AppLog & "\Error.log") Then
            Dim CurrentData, Input, ToWrite As String
            CurrentData = File.ReadAllText(AppLog & "\Error.log")
            Input = "Error " & ErrorType & ": " & Data & " At: " & TimeStamp.ToString("M/dd/yyyy h:mm:ss tt")
            ToWrite = CurrentData & vbNewLine & Input
            File.WriteAllText(AppLog & "\Error.log", ToWrite)
        Else
            Dim Input As String
            Input = "Error " & ErrorType & ": " & Data & " At: " & TimeStamp.ToString("M/dd/yyyy h:mm:ss tt")
            File.WriteAllText(AppLog & "\Error.log", Input)
        End If
    End Sub
End Module
