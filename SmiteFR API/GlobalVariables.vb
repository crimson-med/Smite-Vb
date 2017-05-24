Imports System.IO

'This module is created to store and hold all the global variables
Module GlobalVariables
    'API DEV KEY
    Public DevKey As String = """"
    'API AUTHENTIFICATION KEY
    Public AuthKey As String = ""
    'Default platform is PS4 (personal choice ;))
    Public CurrentPlatform As Platform = Platform.PS4
    'Get the correct API Endpoint depending on the platform
    Public ApiPrefix As String = GetApiPrefix(CurrentPlatform)
    'Holds the current session key
    Public SessionKey As String = ""
    'Hold the current Session Expiration time (session generated + 15 min)
    Public SessionExpiration As DateTime
    'Get the Data folder
    Public AppData As String = GetAppData()
    'Get the Log folder
    Public AppLog As String = GetAppLog()
    'Get the ID folder
    Public AppID As String = GetAppID()
    'Holds the searched player's ID
    Public PlayerSearch As String = ""
    'Holds the current debug mode status
    Public IsDebug As Boolean = False

    'Enum for clear platform possibilities
    Enum Platform
        Xbox
        PS4
        PC
    End Enum

    'Function to get the correct API Endpoint
    Public Function GetApiPrefix(ByVal MyPlatform As Platform) As String
        Dim Prefix As String = "http://api.ps4.smitegame.com/smiteapi.svc/"
        Select Case MyPlatform
            Case Platform.PS4
                Prefix = "http://api.ps4.smitegame.com/smiteapi.svc/"
            Case Platform.Xbox
                Prefix = "http://api.xbox.smitegame.com/smiteapi.svc/"
            Case Platform.PC
                Prefix = "http://api.smitegame.com/smiteapi.svc/"
        End Select
        Return Prefix
    End Function

    'Function to get the Data Folder
    Private Function GetAppData() As String
        Dim Pather As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
        Pather = GetApp(Pather)
        If Not Directory.Exists(Pather & "\Data") Then
            Directory.CreateDirectory(Pather & "\Data")
            Pather = Pather & "\Data"
        Else
            Pather = Pather & "\Data"
        End If
        Return Pather
    End Function

    'Function to get the ID Folder
    Private Function GetAppID() As String
        Dim Pather As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
        Pather = GetApp(Pather)
        If Not Directory.Exists(Pather & "\ID") Then
            Directory.CreateDirectory(Pather & "\ID")
            Pather = Pather & "\ID"
        Else
            Pather = Pather & "\ID"
        End If
        Return Pather
    End Function

    'Function to get the Log Folder
    Private Function GetAppLog() As String
        Dim Pather As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
        Pather = GetApp(Pather)
        If Not Directory.Exists(Pather & "\Log") Then
            Directory.CreateDirectory(Pather & "\Log")
            Pather = Pather & "\Log"
        Else
            Pather = Pather & "\Log"
        End If
        Return Pather
    End Function

    'Function to get the App Folder
    Public Function GetApp(ByVal Pather As String) As String
        Dim Result As String = ""
        If Not Directory.Exists(Pather & "\SmiteFR") Then
            Directory.CreateDirectory(Pather & "\SmiteFR")
            Result = Pather & "\SmiteFR"
        Else
            Result = Pather & "\SmiteFR"
        End If
        Return Result
    End Function

End Module
