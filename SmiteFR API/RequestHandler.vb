Imports System.IO
Imports System.Net
'This Module handles everything related with creating grequests
Module RequestHandler
    'Sends a request URL and gets the response
    Public Function RequestApi(ByVal Url As String) As String
        'Create a Web Request
        Dim request As WebRequest = WebRequest.Create(Url)
        'Give a default proxy in case there is company firewall
        Dim proxy As IWebProxy = WebRequest.GetSystemWebProxy()
        proxy.Credentials = CredentialCache.DefaultCredentials
        request.Proxy = proxy
        'Get the response from the API
        Dim response As WebResponse = request.GetResponse()
        'Read the response
        Dim dataStream As Stream = response.GetResponseStream()
        Dim reader As New StreamReader(dataStream)
        Dim responseFromServer As String = reader.ReadToEnd()
        'Close Reader and Response
        '
        'Future Note: Implement USING!!!
        '
        reader.Close()
        response.Close()
        'Resturn the data
        Return responseFromServer
    End Function

    'Function to get data 
    'Called:    METHOD, PARAMETER, FORMAT
    'Example:   getData("getitems","3","json")  = Get all items in french in JSON format.
    'Parameters: parameters can be language or player ID etc
    Public Function RequestData(ByVal ApiMethod As String, Optional ApiParameter As String = "", Optional ApiFormat As String = "json") As String
        Dim Signature As String
        Dim TimeStamp As String = DateTime.Now.ToUniversalTime.ToString("yyyyMMddHHmmss")
        'Generate request signature
        Signature = GetSignature(ApiMethod, TimeStamp)
        'Handle different formats
        Dim rqFormat As String
        If ApiFormat = "json" Then
            rqFormat = "json"
        Else
            rqFormat = "xml"
        End If
        'Create the WebRequest
        Dim request As WebRequest
        'Handle Parameter possibility
        If ApiParameter <> "" Then
            request = WebRequest.Create(ApiPrefix & ApiMethod & rqFormat & "/" & DevKey & "/" & Signature & "/" & SessionKey & "/" & TimeStamp & "/" & ApiParameter)
        Else
            request = WebRequest.Create(ApiPrefix & ApiMethod & rqFormat & "/" & DevKey & "/" & Signature & "/" & SessionKey & "/" & TimeStamp)
        End If
        'Handle default proxy
        Dim proxy As IWebProxy = WebRequest.GetSystemWebProxy()
        proxy.Credentials = CredentialCache.DefaultCredentials
        request.Proxy = proxy
        'Get the Web Response
        Dim response As WebResponse = request.GetResponse()
        'Initiate Responses Stream
        Dim dataStream As Stream = response.GetResponseStream()
        Dim reader As New StreamReader(dataStream)
        'Get the Responses Data
        Dim responseFromServer As String = reader.ReadToEnd()
        'Return the data
        Return responseFromServer
    End Function

    'This Function creates a signature needed to verify the request
    'SMITE API Dev Guide gives the Signature format as: Dev Key --> API Method --> Auth Key --> TimeStamp
    Public Function GetSignature(ByVal ApiMethod As String, ByVal TimeStamp As String) As String
        Dim mySignature As String
        'Hash the signature
        mySignature = GetMD5Hash(DevKey & ApiMethod & AuthKey & TimeStamp)
        'Return the signature
        Return mySignature
    End Function

    'This function tests if the API is online
    Public Function RequestPing() As Boolean
        Dim Online As Boolean = False
        'Create the WebRequest
        Dim request As WebRequest
        request = WebRequest.Create(ApiPrefix & "pingjson")
        'Handle default proxy
        Dim proxy As IWebProxy = WebRequest.GetSystemWebProxy()
        proxy.Credentials = CredentialCache.DefaultCredentials
        request.Proxy = proxy
        'Get the Web Response
        Dim response As WebResponse = request.GetResponse()
        'Initiate Responses Stream
        Dim dataStream As Stream = response.GetResponseStream()
        Dim reader As New StreamReader(dataStream)
        'Get the Responses Data
        Dim responseFromServer As String = reader.ReadToEnd()
        'Return the data
        If responseFromServer.Contains("Ping successful") Then
            Online = True
        Else
            Online = False
        End If
        Return Online
    End Function
End Module
