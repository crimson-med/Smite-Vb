Imports System.Net
Imports System.Web.Script.Serialization

Public Class V_PlayerStats
    Dim MyPlayer As Player
    Private Sub V_PlayerStats_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim responseFromServer As String = RequestData("getplayer", PlayerSearch, "json")

        Using web = New WebClient()
            web.Encoding = System.Text.Encoding.UTF8
            Dim jsonString = responseFromServer
            Dim jss = New JavaScriptSerializer()
            If jsonString.IndexOf("[") = 0 Then
                jsonString = jsonString.Remove(0, 1)
            End If
            If jsonString.LastIndexOf("]") = jsonString.Length - 1 Then
                jsonString = jsonString.Remove(jsonString.Length - 1, 1)
            End If
            MyPlayer = jss.Deserialize(Of Player)(jsonString)
            If MyPlayer.Avatar_URL = "" Then
                PictureBox1.ImageLocation = "http://hydra-media.cursecdn.com/smite.gamepedia.com/2/26/Icon_Player_Default.png"
            Else
                PictureBox1.ImageLocation = MyPlayer.Avatar_URL
            End If
            playername.Text = MyPlayer.Name
            clanname.Text = MyPlayer.Team_Name
            wins.Text = MyPlayer.Wins
            looses.Text = MyPlayer.Losses
            leaves.Text = MyPlayer.Leaves
            leveler.Text = "Level: " & MyPlayer.Level
        End Using
    End Sub
End Class