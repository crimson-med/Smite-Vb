Imports System.Net
Imports System.Web.Script.Serialization
'This Form handles the basic player information
'
'Future Implement: Match History and more detailed information about the player like for instance the Clan
'
Public Class V_PlayerStats
    'Get the searched Player ID
    Dim MyPlayer As Player
    Private Sub V_PlayerStats_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Get the data of the getplayer method
        Dim responseFromServer As String = RequestData("getplayer", PlayerSearch, "json")
        'Use WebClient to extract data
        '
        'Future Implement: Integrate the WebClient Extraction to DataHandler
        '
        Using web = New WebClient()
            web.Encoding = System.Text.Encoding.UTF8
            Dim jsonString = responseFromServer
            Dim jss = New JavaScriptSerializer()
            'Quite annoying but the getplayer returns [] at beginning and end
            'If we don't remove it VB can't deserialize directly to our class
            If jsonString.IndexOf("[") = 0 Then
                jsonString = jsonString.Remove(0, 1)
            End If
            If jsonString.LastIndexOf("]") = jsonString.Length - 1 Then
                jsonString = jsonString.Remove(jsonString.Length - 1, 1)
            End If
            'Deserialize the data
            MyPlayer = jss.Deserialize(Of Player)(jsonString)
            'Update the avatar if empty use defalut one
            If MyPlayer.Avatar_URL = "" Then
                PictureBox1.ImageLocation = "http://hydra-media.cursecdn.com/smite.gamepedia.com/2/26/Icon_Player_Default.png"
            Else
                PictureBox1.ImageLocation = MyPlayer.Avatar_URL
            End If
            'Load all the data
            playername.Text = MyPlayer.Name
            clanname.Text = MyPlayer.Team_Name
            wins.Text = MyPlayer.Wins
            looses.Text = MyPlayer.Losses
            leaves.Text = MyPlayer.Leaves
            leveler.Text = "Level: " & MyPlayer.Level
        End Using
    End Sub
End Class