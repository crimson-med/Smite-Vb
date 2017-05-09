Imports System.IO

Module GlobalVariables
    Public DevKey As String = """"
    Public AuthKey As String = ""
    Public CurrentPlatform As Platform = Platform.PS4
    Public ApiPrefix As String = GetApiPrefix(CurrentPlatform)
    Public SessionKey As String = ""
    Public SessionExpiration As DateTime
    Public AppData As String = GetAppData()
    Public AppLog As String = GetAppLog()
    Public AppID As String = GetAppID()
    Public PlayerSearch As String = ""
    Public IsDebug As Boolean = False

    Enum Platform
        Xbox
        PS4
        PC
    End Enum

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
