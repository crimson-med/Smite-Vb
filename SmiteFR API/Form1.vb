
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.IO
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports System.Security.Cryptography
Imports System.Net
Imports System.Runtime.Serialization
Imports System.Web.Script.Serialization

Public Class Form1

    Private timestamp As String = DateTime.UtcNow.ToString("yyyyMMddHHmmss")
    Dim isSession As Boolean

    Dim sessionPath As String = Application.StartupPath & "\session.id"
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each Language As String In GetLanguageName()
            ComboBox1.Items.Add(Language)
        Next
        DataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically
        UpdateImage()
        UpdateDebug()
        If GetSession() = False Then
            CreateSession()
        End If
        If IsDebug = False Then
            Label4.ForeColor = Color.DarkRed
            Label4.Text = "Debug Mode = Off"
        Else
            Label4.ForeColor = Color.DarkGreen
            Label4.Text = "Debug Mode = On"
        End If
        V_Information.Show()
        Timer1.Start()
        Timer2.Start()
    End Sub

    Public Sub UpdateImage()
        Select Case CurrentPlatform
            Case Platform.PS4
                PictureBox1.BackgroundImage = My.Resources.play
            Case Platform.Xbox
                PictureBox1.BackgroundImage = My.Resources.xbox
            Case Platform.PC
                PictureBox1.BackgroundImage = My.Resources.pc
        End Select
        PictureBox1.Refresh()
    End Sub

    Public Sub UpdateDebug()
        If IsDebug = True Then
            MaximumSize = New Size(1125, 758)
            MinimumSize = New Size(1125, 758)
            Size = New Size(1125, 758)
            TextBox2.Visible = True
            Button2.Visible = True
            Label4.ForeColor = Color.DarkGreen
            Label4.Text = "Debug Mode = On"
        Else
            MaximumSize = New Size(1125, 438)
            MinimumSize = New Size(1125, 438)
            Size = New Size(1125, 438)
            TextBox2.Visible = False
            Button2.Visible = False
            Label4.ForeColor = Color.DarkRed
            Label4.Text = "Debug Mode = Off"
        End If
    End Sub

    Public Sub New()
        InitializeComponent()
    End Sub
    Dim GodsList As New List(Of Gods)
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DataGridView1.Rows.Clear()
        DataGridView1.Columns.Clear()
        For Each Col As String In GodStructure
            DataGridView1.Columns.Add(Col, Col)
        Next
        Dim responseFromServer As String = RequestData("getgods", GetLanguageCode(ComboBox1), "json")

        Using web = New WebClient()
            web.Encoding = System.Text.Encoding.UTF8
            Dim jsonString = responseFromServer
            Dim jss = New JavaScriptSerializer()
            GodsList = jss.Deserialize(Of List(Of Gods))(jsonString)
            Dim GodsListStr As String = ""
            For Each x As Gods In GodsList
                GodsListStr = Convert.ToString(GodsListStr & Convert.ToString(", ")) & x.Name
                DataGridView1.Rows.Add(New Object() {x.id, x.AttackSpeed, x.AttackSpeedPerLevel, x.Cons, x.HP5PerLevel, x.Health, x.HealthPerFive, x.HealthPerLevel, x.Lore, x.MP5PerLevel, x.MagicProtection, x.MagicProtectionPerLevel, x.MagicalPower, x.MagicalPowerPerLevel, x.Mana, x.ManaPerFive, x.ManaPerLevel, x.Name, x.OnFreeRotation, x.Pantheon, x.PhysicalPower, x.PhysicalPowerPerLevel, x.PhysicalProtection, x.PhysicalProtectionPerLevel, x.Pros, x.Roles, x.Speed, x.Title, x.Type, x.godIcon_URL, x.godCard_URL, x.latestGod})
            Next
            TextBox2.Clear()
            'TextBox2.Text = Convert.ToString("Here are the Gods: ") & GodsListStr
            TextBox2.Text = jsonString
        End Using
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        PlayerSearch = TextBox1.Text
        TextBox2.Clear()
        TextBox2.Text = RequestData("getplayer", TextBox1.Text, "json")
        'To Implement
        'TextBox2.Text = RequestData("getmatchhistory", TextBox1.Text, "json")
        V_PlayerStats.Show()
    End Sub


    Dim ItemList As New List(Of Item)
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        DataGridView1.Rows.Clear()
        DataGridView1.Columns.Clear()
        For Each Col As String In ItemStructure
            DataGridView1.Columns.Add(Col, Col)
        Next
        Dim responseFromServer As String = RequestData("getitems", GetLanguageCode(ComboBox1), "json")
        TextBox2.Clear()
        TextBox2.Text = responseFromServer
        Using web = New WebClient()
            web.Encoding = System.Text.Encoding.UTF8
            Dim jsonString = responseFromServer
            Dim jss = New JavaScriptSerializer()
            ItemList = jss.Deserialize(Of List(Of Item))(jsonString)
            For Each x As Item In ItemList
                DataGridView1.Rows.Add(New Object() {x.ChildItemId, x.DeviceName, x.IconId, x.ItemDescription.Description & "--" & x.ItemDescription.Description, x.ItemId, x.ItemTier, x.Price, x.RootItemId, x.ShortDesc, x.StartingItem, x.Type, x.itemIcon_URL, x.ret_msg})
            Next
        End Using
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim rqsql As String = ""
        Dim abisql As String = ""
        For Each godd As Gods In GodsList
            rqsql = rqsql & "INSERT INTO `mmostreaysuser`.`smitefr_gods` 
(`GodID`, `AttackSpeed`, `AttackSpeedPerLevel`, `Cons`, `HP5PerLevel`, `Health`, `HealthPer5`, `HealthPerLevel`, 
`Lore`, `MP5PerLevel`, `MagicProtection`, `MagicProtectionPerLevel`, `MagicalPower`, `MagicalPowerPerLevel`, 
`Mana`, `ManaPerFive`, `ManaPerLevel`, `Name`, `OnFreeRotation`, `Pantheon`, `PhysicalPower`, 
`PhysicalPowerPerLevel`, `PhysicalProtection`, `PhysicalProtectionPerLevel`, `Pros`, `Roles`, `Speed`, 
`Title`, `Type`, `GodIcon`, `GodCard`, `LastestGod`, `BasicAttackDmg`, `BasicAttackProgression`) 
VALUES ('" & godd.id & "', '" & godd.AttackSpeed & "', '" & godd.AttackSpeedPerLevel & "', '" & godd.Cons & "', '" & godd.HP5PerLevel & "', '" & godd.Health & "', '" & godd.HealthPerFive & "', '" & godd.HealthPerLevel _
& "', '" & godd.Lore.Replace("'", "''") & "', '" & godd.MP5PerLevel & "', '" & godd.MagicProtection & "', '" & godd.MagicProtectionPerLevel & "', '" & godd.MagicalPower & "', '" & godd.MagicalPowerPerLevel _
& "', '" & godd.Mana & "', '" & godd.ManaPerFive & "', '" & godd.ManaPerLevel & "', '" & godd.Name.Replace("'", "''") & "', '" & godd.OnFreeRotation & "', '" & godd.Pantheon & "', '" & godd.PhysicalPower _
& "', '" & godd.PhysicalPowerPerLevel & "', '" & godd.PhysicalProtection & "', '" & godd.PhysicalProtectionPerLevel & "', '" & godd.Pros.Replace("'", "''") & "', '" & godd.Roles & "', '" & godd.Speed _
& "', '" & godd.Title.Replace("'", "''") & "', '" & godd.Type & "', '" & godd.godIcon_URL & "', '" & godd.godCard_URL & "', '" & godd.latestGod & "', '" & "52" & "', '" & "1" & "');" & vbNewLine

        Next
        File.WriteAllText(Application.StartupPath & "/gods.sql", rqsql)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim rqsql As String = ""
        For Each g As Gods In GodsList
            Dim final As String
            final = GetAbility1(g) & vbNewLine & GetAbility2(g) & vbNewLine & GetAbility3(g) & vbNewLine & GetAbility4(g) & vbNewLine & GetAbility5(g)
            rqsql = rqsql & final & vbNewLine
        Next
        File.WriteAllText(Application.StartupPath & "/ability.sql", rqsql)
    End Sub

    Public Function GetAbility1(ByVal g As Gods) As String
        Dim rqsql As String = ""
        Dim temp As AbilityDescription
        temp = g.abilityDescription1.itemDescription
        Dim tempitems As New Menuitem
        Dim ability As String = ""
        Dim affects As String = ""
        Dim damage As String = ""
        Dim range As String = ""
        For Each tempitems In g.abilityDescription1.itemDescription.menuitems
            If tempitems.description.Contains("Compétence") Then
                ability = tempitems.value
            ElseIf tempitems.description.Contains("Affecte") Then
                affects = tempitems.value
            ElseIf tempitems.description.Contains("Dégâts") Then
                damage = tempitems.value
            ElseIf tempitems.description.Contains("Rayon") Then
                range = tempitems.value
            End If
        Next
        rqsql = "INSERT INTO smitefr_ability
            (AbilityID, GodID, Cooldown, Description, Ability, Affects, Damage, ARange, Name, URL) VALUES
            ('" & g.abilityId1 & "', '" & g.id & "', '" & temp.cooldown & "', '" & temp.description.Replace("'", "''") & "', '" & ability.Replace("'", "''") & "', 
            '" & affects & "', '" & damage & "', '" & range & "', '" & g.Ability1.Replace("'", "''") & "', '" & "" & g.godAbility1_URL & "');"
        Return rqsql
    End Function

    Public Function GetAbility2(ByVal g As Gods) As String
        Dim rqsql As String = ""
        Dim temp As AbilityDescription
        temp = g.abilityDescription2.itemDescription
        Dim tempitems As New Menuitem
        Dim ability As String = ""
        Dim affects As String = ""
        Dim damage As String = ""
        Dim range As String = ""
        For Each tempitems In g.abilityDescription2.itemDescription.menuitems
            If tempitems.description.Contains("Compétence") Then
                ability = tempitems.value
            ElseIf tempitems.description.Contains("Affecte") Then
                affects = tempitems.value
            ElseIf tempitems.description.Contains("Dégâts") Then
                damage = tempitems.value
            ElseIf tempitems.description.Contains("Rayon") Then
                range = tempitems.value
            End If
        Next
        rqsql = "INSERT INTO smitefr_ability
            (AbilityID, GodID, Cooldown, Description, Ability, Affects, Damage, ARange, Name, URL) VALUES
            ('" & g.abilityId2 & "', '" & g.id & "', '" & temp.cooldown & "', '" & temp.description.Replace("'", "''") & "', '" & ability.Replace("'", "''") & "', 
            '" & affects & "', '" & damage & "', '" & range & "', '" & g.Ability2.Replace("'", "''") & "', '" & "" & g.godAbility2_URL & "');"
        Return rqsql
    End Function

    Public Function GetAbility3(ByVal g As Gods) As String
        Dim rqsql As String = ""
        Dim temp As AbilityDescription
        temp = g.abilityDescription3.itemDescription
        Dim tempitems As New Menuitem
        Dim ability As String = ""
        Dim affects As String = ""
        Dim damage As String = ""
        Dim range As String = ""
        For Each tempitems In g.abilityDescription3.itemDescription.menuitems
            If tempitems.description.Contains("Compétence") Then
                ability = tempitems.value
            ElseIf tempitems.description.Contains("Affecte") Then
                affects = tempitems.value
            ElseIf tempitems.description.Contains("Dégâts") Then
                damage = tempitems.value
            ElseIf tempitems.description.Contains("Rayon") Then
                range = tempitems.value
            End If
        Next
        rqsql = "INSERT INTO smitefr_ability
            (AbilityID, GodID, Cooldown, Description, Ability, Affects, Damage, ARange, Name, URL) VALUES
            ('" & g.abilityId3 & "', '" & g.id & "', '" & temp.cooldown & "', '" & temp.description.Replace("'", "''") & "', '" & ability.Replace("'", "''") & "', 
            '" & affects & "', '" & damage & "', '" & range & "', '" & g.Ability3.Replace("'", "''") & "', '" & "" & g.godAbility3_URL & "');"
        Return rqsql
    End Function

    Public Function GetAbility4(ByVal g As Gods) As String
        Dim rqsql As String = ""
        Dim temp As AbilityDescription
        temp = g.abilityDescription4.itemDescription
        Dim tempitems As New Menuitem
        Dim ability As String = ""
        Dim affects As String = ""
        Dim damage As String = ""
        Dim range As String = ""
        For Each tempitems In g.abilityDescription4.itemDescription.menuitems
            If tempitems.description.Contains("Compétence") Then
                ability = tempitems.value
            ElseIf tempitems.description.Contains("Affecte") Then
                affects = tempitems.value
            ElseIf tempitems.description.Contains("Dégâts") Then
                damage = tempitems.value
            ElseIf tempitems.description.Contains("Rayon") Then
                range = tempitems.value
            End If
        Next
        rqsql = "INSERT INTO smitefr_ability
            (AbilityID, GodID, Cooldown, Description, Ability, Affects, Damage, ARange, Name, URL) VALUES
            ('" & g.abilityId4 & "', '" & g.id & "', '" & temp.cooldown & "', '" & temp.description.Replace("'", "''") & "', '" & ability.Replace("'", "''") & "', 
            '" & affects & "', '" & damage & "', '" & range & "', '" & g.Ability4.Replace("'", "''") & "', '" & "" & g.godAbility4_URL & "');"
        Return rqsql
    End Function

    Public Function GetAbility5(ByVal g As Gods) As String
        Dim rqsql As String = ""
        Dim temp As AbilityDescription
        temp = g.abilityDescription5.itemDescription
        Dim tempitems As New Menuitem
        Dim ability As String = ""
        Dim affects As String = ""
        Dim damage As String = ""
        Dim range As String = ""
        For Each tempitems In g.abilityDescription5.itemDescription.menuitems
            If tempitems.description.Contains("Compétence") Then
                ability = tempitems.value
            ElseIf tempitems.description.Contains("Affecte") Then
                affects = tempitems.value
            ElseIf tempitems.description.Contains("Dégâts") Then
                damage = tempitems.value
            ElseIf tempitems.description.Contains("Rayon") Then
                range = tempitems.value
            End If
        Next
        rqsql = "INSERT INTO smitefr_ability
            (AbilityID, GodID, Cooldown, Description, Ability, Affects, Damage, ARange, Name, URL) VALUES
            ('" & g.abilityId5 & "', '" & g.id & "', '" & temp.cooldown & "', '" & temp.description.Replace("'", "''") & "', '" & ability.Replace("'", "''") & "', 
            '" & affects & "', '" & damage & "', '" & range & "', '" & g.Ability5.Replace("'", "''") & "', '" & "" & g.godAbility5_URL & "');"
        Return rqsql
    End Function

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim CurrentDate As DateTime = DateAndTime.Now.ToUniversalTime
        Dim TimeDiff As TimeSpan
        TimeDiff = SessionExpiration.Subtract(CurrentDate)
        If TimeDiff.TotalMinutes > 1 Then
            sessionexpire_txt.ForeColor = Color.DarkBlue
            sessionexpire_txt.Text = TimeDiff.Minutes.ToString & " Minutes " & TimeDiff.Seconds.ToString & " Seconds"
        Else
            Timer1.Stop()
            sessionexpire_txt.ForeColor = Color.Red
            sessionexpire_txt.Text = "Expired!"
            CreateSession()
            Timer1.Start()
        End If
    End Sub

    Public Sub GiveNotification(ByVal Title As String, ByVal Message As String)
        NotifyIcon1.BalloonTipTitle = Title
        NotifyIcon1.BalloonTipText = Message
        NotifyIcon1.ShowBalloonTip(3000)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        DataGridView1.Rows.Clear()
        DataGridView1.Columns.Clear()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Dim IsOnline As Boolean = RequestPing()
        If IsOnline = True Then
            Label2.ForeColor = Color.DarkGreen
            Label2.Text = "Online"
        Else
            Label2.ForeColor = Color.DarkRed
            Label2.Text = "Offline"
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        V_Preferences.Show()
    End Sub
End Class





Public Class SessionInfo
    Public Property ret_msg() As String
        Get
            Return m_ret_msg
        End Get
        Set
            m_ret_msg = Value
        End Set
    End Property
    Private m_ret_msg As String
    Public Property session_id() As String
        Get
            Return m_session_id
        End Get
        Set
            m_session_id = Value
        End Set
    End Property
    Private m_session_id As String
    Public Property timestamp() As String
        Get
            Return m_timestamp
        End Get
        Set
            m_timestamp = Value
        End Set
    End Property
    Private m_timestamp As String

End Class


