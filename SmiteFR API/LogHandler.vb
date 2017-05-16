Imports System.IO
'This Module handles all the logging.
'In future should implement for details
Module LogHandler
    'Log the session created
    Public Sub LogSession(ByVal TimeStamp As DateTime)
        'Check if file exists
        If File.Exists(AppLog & "\Session.log") Then
            'Append the information of the new session
            Dim CurrentData, Input, ToWrite As String
            CurrentData = File.ReadAllText(AppLog & "\Session.log")
            Input = "New Session Created: " & SessionKey & " At: " & TimeStamp.ToString("M/dd/yyyy h:mm:ss tt")
            ToWrite = CurrentData & vbNewLine & Input
            File.WriteAllText(AppLog & "\Session.log", ToWrite)
        Else
            'Create the information of the new session
            Dim Input As String
            Input = "New Session Created: " & SessionKey & " At: " & TimeStamp.ToString("M/dd/yyyy h:mm:ss tt")
            File.WriteAllText(AppLog & "\Session.log", Input)
        End If
        'Update or Create the session information file
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

    'Log an error to the log file
    Public Sub LogError(ByVal Data As String, ByVal TimeStamp As DateTime, ByVal ErrorType As String)
        'Append the information if the file already exist
        If File.Exists(AppLog & "\Error.log") Then
            Dim CurrentData, Input, ToWrite As String
            CurrentData = File.ReadAllText(AppLog & "\Error.log")
            Input = "Error " & ErrorType & ": " & Data & " At: " & TimeStamp.ToString("M/dd/yyyy h:mm:ss tt")
            ToWrite = CurrentData & vbNewLine & Input
            File.WriteAllText(AppLog & "\Error.log", ToWrite)
        Else
            'Create new data for the error
            Dim Input As String
            Input = "Error " & ErrorType & ": " & Data & " At: " & TimeStamp.ToString("M/dd/yyyy h:mm:ss tt")
            File.WriteAllText(AppLog & "\Error.log", Input)
        End If
    End Sub
End Module
