Imports System.Net
Imports System.Web.Script.Serialization
Imports System.IO


Module DataHandler
    Public Function GetMD5Hash(ByVal Input As String) As String
        Dim md5 = New System.Security.Cryptography.MD5CryptoServiceProvider()
        Dim bytes = System.Text.Encoding.UTF8.GetBytes(Input)
        bytes = md5.ComputeHash(bytes)
        Dim sb = New System.Text.StringBuilder()
        For Each b As Byte In bytes
            sb.Append(b.ToString("x2").ToLower())
        Next
        Return sb.ToString()
    End Function

    Public Function ExtractSession(ByVal Data As String) As Boolean
        Using web = New WebClient()
            Try
                web.Encoding = System.Text.Encoding.UTF8
                Dim jsonString = Data
                Dim jss = New JavaScriptSerializer()
                Dim g = jss.Deserialize(Of SessionInfo)(jsonString)
                SessionKey = g.session_id
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Using
    End Function

    Public Function CheckCredentials() As Boolean
        Dim Result As Boolean = False
        Dim temp As String = ""
        If File.Exists(AppID & "\ID.crimson") Then
            Try

                temp = File.ReadAllText(AppID & "\ID.crimson")
                Dim splitted() As String = temp.Split("*")
                DevKey = splitted(0)
                AuthKey = splitted(1)

                Result = True
            Catch ex As Exception
                Result = False
            End Try
        Else
            Result = False
        End If
        Return Result
    End Function
End Module
