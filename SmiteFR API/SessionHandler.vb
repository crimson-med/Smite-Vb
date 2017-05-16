Imports System.IO
'This Module handles everything related with sessions
Module SessionHandler
    'Checks if the previous session is still valid True = Yes and False = No
    Public Function GetSession() As Boolean
        Dim Pather As String = AppData & "\Session.crimson"
        Dim Result As Boolean = False
        'Check session file exists
        If File.Exists(Pather) Then
            'Read the session file
            Dim toTreat As String = File.ReadAllText(Pather)
            'Split the read data
            Dim data() As String
            data = toTreat.Split(New String() {"***"}, StringSplitOptions.RemoveEmptyEntries
                 ).Where(
                     Function(s) Not String.IsNullOrWhiteSpace(s)
                 ).ToArray()
            'Check that we have a correct format
            If data.Length = 2 Then
                'Get the current universal time
                Dim now As DateTime = DateTime.Now.ToUniversalTime
                'Define time variable
                Dim sessionTime As New DateTime
                'Parse the stored session time as date
                sessionTime = Date.ParseExact(data(1).ToString.Trim(), "M/dd/yyyy h:mm:ss", Globalization.CultureInfo.InvariantCulture)
                'Get the difference between started time and now
                Dim span As TimeSpan = now.Subtract(sessionTime)
                'If the difference smaller than 15 Minutes
                If span.TotalMinutes < 15 Then
                    'Our session is still valid
                    Result = True
                    'Insert the session key
                    SessionKey = data(0)
                    'Insert the session expiration time
                    SessionExpiration = sessionTime.AddMinutes(15)
                    Form1.GiveNotification("Session Restored", "Session was restored with: " & SessionKey & vbNewLine & vbNewLine & "Will Expire at: " & SessionExpiration.ToLocalTime)
                Else
                    'Session isn't valid anymore
                    Result = False
                End If
                'Data isn't correct format
            ElseIf data.Length = 1 Then
                'Session isn't valid anymore
                Result = False
            End If
            'No session file
        Else
            'Session isn't valid anymore
            Result = False
        End If
        'Return if session is valid or not
        Return Result
    End Function

    'Create new session if created returns True otherwise False
    Public Function CreateSession() As Boolean
        'Default result is false it didn't work unless we managed to do it
        Dim Result As Boolean = False
        'Initialise Variables
        Dim TimeStamp As String = ""
        Dim SessionResult As String = ""
        'Get the current time
        Dim DTimeStamp As DateTime = DateTime.Now.ToUniversalTime
        'Format the time
        TimeStamp = DTimeStamp.ToString("yyyyMMddHHmmss")
        'Create a signature
        Dim Signature As String = GetMD5Hash(DevKey & "createsession" & AuthKey & TimeStamp)
        'Create a session request
        SessionResult = RequestApi(ApiPrefix & "createsessionjson/" & DevKey & "/" & Signature & "/" & TimeStamp)
        'Check the result of the session creation
        If ExtractSession(SessionResult) = True Then
            'Calculate the expiration time
            SessionExpiration = DTimeStamp.AddMinutes(15)
            'Log the session to files
            LogSession(DTimeStamp)
            'Give notification of session creation
            Form1.GiveNotification("Session Created", "New session was created with: " & SessionKey & vbNewLine & vbNewLine & "Will Expire at: " & SessionExpiration.ToLocalTime)
            'Update the result
            Result = True
        Else
            'Woohoo we have an error lets log it 
            LogError(SessionResult, DTimeStamp, "CreateSession")
            Result = False
        End If
        'Return the result
        Return Result
    End Function
End Module
