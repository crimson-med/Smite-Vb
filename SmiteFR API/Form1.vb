
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
    '   ---   GLOBAL VARIABLES   ---   
    'Variable to check if session is active
    Dim isSession As Boolean
    'Variable to store the Gods once loaded
    Dim GodsList As New List(Of Gods)
    'Variable to store the Items once loaded
    Dim ItemList As New List(Of Item)
    '   ----------------------------

    'Form Load Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Load languages in combobox
        For Each Language As String In GetLanguageName()
            ComboBox1.Items.Add(Language)
        Next
        'Block the edit mode by user of the DGV
        DataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically
        'Update the platform Image
        UpdateImage()
        'Update the debug status
        UpdateDebug()
        'If stored session isn't valid
        If GetSession() = False Then
            'Then create a new session
            CreateSession()
        End If
        'Check the first debug status
        If IsDebug = False Then
            Label4.ForeColor = Color.DarkRed
            Label4.Text = "Debug Mode = Off"
        Else
            Label4.ForeColor = Color.DarkGreen
            Label4.Text = "Debug Mode = On"
        End If
        'Show the information box
        V_Information.Show()
        'Start Timer1
        Timer1.Start()
        'Start Timer2
        Timer2.Start()
    End Sub

    'Function to update the corresponding image to the chosen platform
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

    'Function to show the correct size depending on the debug
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

    'Get Gods Button Sub 
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Clear the DGV
        DataGridView1.Rows.Clear()
        DataGridView1.Columns.Clear()
        'Generate the columns for the Gods
        For Each Col As String In GodStructure
            DataGridView1.Columns.Add(Col, Col)
        Next
        'Get the data following the getgods method
        Dim responseFromServer As String = RequestData("getgods", GetLanguageCode(ComboBox1), "json")
        'Use a WebClient to dynamically deserialize the JSON
        Using web = New WebClient()
            'Set the encoding UTF8 is what I needed
            web.Encoding = System.Text.Encoding.UTF8
            'Load the data
            Dim jsonString = responseFromServer
            'Create the Deserializer
            Dim jss = New JavaScriptSerializer()
            'Deserialize to our structure
            GodsList = jss.Deserialize(Of List(Of Gods))(jsonString)
            'Initialise a string to store only god names if needed
            'Dim GodsListStr As String = ""
            'For every god in the list load the data
            For Each x As Gods In GodsList
                'Isolate just the God Name
                'GodsListStr = Convert.ToString(GodsListStr & Convert.ToString(", ")) & x.Name
                'Add the data to the DGV
                DataGridView1.Rows.Add(New Object() {x.id, x.AttackSpeed, x.AttackSpeedPerLevel, x.Cons, x.HP5PerLevel, x.Health, x.HealthPerFive, x.HealthPerLevel, x.Lore, x.MP5PerLevel, x.MagicProtection, x.MagicProtectionPerLevel, x.MagicalPower, x.MagicalPowerPerLevel, x.Mana, x.ManaPerFive, x.ManaPerLevel, x.Name, x.OnFreeRotation, x.Pantheon, x.PhysicalPower, x.PhysicalPowerPerLevel, x.PhysicalProtection, x.PhysicalProtectionPerLevel, x.Pros, x.Roles, x.Speed, x.Title, x.Type, x.godIcon_URL, x.godCard_URL, x.latestGod})
            Next
            'Clear the debug box
            TextBox2.Clear()
            'Load the response to debug box
            TextBox2.Text = responseFromServer
        End Using
    End Sub

    'Search Player Button Sub 
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'Set the global variable to the searched player name
        PlayerSearch = TextBox1.Text
        'Clear the debug box
        TextBox2.Clear()
        'Load the response to debug box
        TextBox2.Text = RequestData("getplayer", TextBox1.Text, "json")
        'Open the Player Stats Form
        V_PlayerStats.Show()
    End Sub


    'Get Items Button Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'Clear the DGV
        DataGridView1.Rows.Clear()
        DataGridView1.Columns.Clear()
        'Generate the columns for the Items
        For Each Col As String In ItemStructure
            DataGridView1.Columns.Add(Col, Col)
        Next
        'Get the data following the getitems method
        Dim responseFromServer As String = RequestData("getitems", GetLanguageCode(ComboBox1), "json")
        'Use a WebClient to dynamically deserialize the JSON
        Using web = New WebClient()
            'Set the encoding UTF8 is what I needed
            web.Encoding = System.Text.Encoding.UTF8
            'Load the data
            Dim jsonString = responseFromServer
            'Create the Deserializer
            Dim jss = New JavaScriptSerializer()
            'Deserialize to our structure
            ItemList = jss.Deserialize(Of List(Of Item))(jsonString)
            'For every god in the list load the data
            For Each x As Item In ItemList
                'Add the data to the DGV
                DataGridView1.Rows.Add(New Object() {x.ChildItemId, x.DeviceName, x.IconId, x.ItemDescription.Description & "--" & x.ItemDescription.Description, x.ItemId, x.ItemTier, x.Price, x.RootItemId, x.ShortDesc, x.StartingItem, x.Type, x.itemIcon_URL, x.ret_msg})
            Next
        End Using
        'Clear the debug box
        TextBox2.Clear()
        'Load the response to debug box
        TextBox2.Text = responseFromServer
    End Sub

    'Export Gods Button Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        'Initialise empty variables
        Dim rqsql As String = ""
        'For every God in the List
        For Each godd As Gods In GodsList
            'Dynamic Sql Query Generation
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
        'Write the generated SQL to file
        File.WriteAllText(Application.StartupPath & "/gods.sql", rqsql)
    End Sub

    'Export Abilities Button Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        'Initialise empty variables
        Dim rqsql As String = ""
        'For every God in the List
        For Each g As Gods In GodsList
            'Create a variable to hold the ability query
            Dim final As String
            'Generate the ability query
            final = GetAbility1(g) & vbNewLine & GetAbility2(g) & vbNewLine & GetAbility3(g) & vbNewLine & GetAbility4(g) & vbNewLine & GetAbility5(g)
            'Dynamic Sql Query Generation
            rqsql = rqsql & final & vbNewLine
        Next
        'Write the generated SQL to file
        File.WriteAllText(Application.StartupPath & "/ability.sql", rqsql)
    End Sub

    'Function to generate the SQL Query for Ability1
    Public Function GetAbility1(ByVal g As Gods) As String
        'Initialise variables
        Dim rqsql As String = ""
        Dim temp As AbilityDescription
        Dim tempitems As New Menuitem
        Dim ability As String = ""
        Dim affects As String = ""
        Dim damage As String = ""
        Dim range As String = ""
        'Get the ability description
        temp = g.abilityDescription1.itemDescription
        'Isolate the sub items (need some work to be more precise)
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
        'Generate the dynamic query
        rqsql = "INSERT INTO smitefr_ability
            (AbilityID, GodID, Cooldown, Description, Ability, Affects, Damage, ARange, Name, URL) VALUES
            ('" & g.abilityId1 & "', '" & g.id & "', '" & temp.cooldown & "', '" & temp.description.Replace("'", "''") & "', '" & ability.Replace("'", "''") & "', 
            '" & affects & "', '" & damage & "', '" & range & "', '" & g.Ability1.Replace("'", "''") & "', '" & "" & g.godAbility1_URL & "');"
        'Return the finishe query
        Return rqsql
    End Function

    'Function to generate the SQL Query for Ability2
    Public Function GetAbility2(ByVal g As Gods) As String
        'Initialise variables
        Dim rqsql As String = ""
        Dim temp As AbilityDescription
        Dim tempitems As New Menuitem
        Dim ability As String = ""
        Dim affects As String = ""
        Dim damage As String = ""
        Dim range As String = ""
        'Get the ability description
        temp = g.abilityDescription2.itemDescription
        'Isolate the sub items (need some work to be more precise)
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
        'Generate the dynamic query
        rqsql = "INSERT INTO smitefr_ability
            (AbilityID, GodID, Cooldown, Description, Ability, Affects, Damage, ARange, Name, URL) VALUES
            ('" & g.abilityId2 & "', '" & g.id & "', '" & temp.cooldown & "', '" & temp.description.Replace("'", "''") & "', '" & ability.Replace("'", "''") & "', 
            '" & affects & "', '" & damage & "', '" & range & "', '" & g.Ability2.Replace("'", "''") & "', '" & "" & g.godAbility2_URL & "');"

        'Return the finishe query
        Return rqsql
    End Function

    'Function to generate the SQL Query for Ability3
    Public Function GetAbility3(ByVal g As Gods) As String
        'Initialise variables
        Dim rqsql As String = ""
        Dim temp As AbilityDescription
        Dim tempitems As New Menuitem
        Dim ability As String = ""
        Dim affects As String = ""
        Dim damage As String = ""
        Dim range As String = ""
        'Get the ability description
        temp = g.abilityDescription3.itemDescription
        'Isolate the sub items (need some work to be more precise)
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
        'Generate the dynamic query
        rqsql = "INSERT INTO smitefr_ability
            (AbilityID, GodID, Cooldown, Description, Ability, Affects, Damage, ARange, Name, URL) VALUES
            ('" & g.abilityId3 & "', '" & g.id & "', '" & temp.cooldown & "', '" & temp.description.Replace("'", "''") & "', '" & ability.Replace("'", "''") & "', 
            '" & affects & "', '" & damage & "', '" & range & "', '" & g.Ability3.Replace("'", "''") & "', '" & "" & g.godAbility3_URL & "');"
        'Return the finishe query
        Return rqsql
    End Function

    'Function to generate the SQL Query for Ability4
    Public Function GetAbility4(ByVal g As Gods) As String
        'Initialise variables
        Dim rqsql As String = ""
        Dim temp As AbilityDescription
        Dim tempitems As New Menuitem
        Dim ability As String = ""
        Dim affects As String = ""
        Dim damage As String = ""
        Dim range As String = ""
        'Get the ability description
        temp = g.abilityDescription4.itemDescription
        'Isolate the sub items (need some work to be more precise)
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
        'Generate the dynamic query
        rqsql = "INSERT INTO smitefr_ability
            (AbilityID, GodID, Cooldown, Description, Ability, Affects, Damage, ARange, Name, URL) VALUES
            ('" & g.abilityId4 & "', '" & g.id & "', '" & temp.cooldown & "', '" & temp.description.Replace("'", "''") & "', '" & ability.Replace("'", "''") & "', 
            '" & affects & "', '" & damage & "', '" & range & "', '" & g.Ability4.Replace("'", "''") & "', '" & "" & g.godAbility4_URL & "');"
        'Return the finishe query
        Return rqsql
    End Function

    'Function to generate the SQL Query for Ability5
    Public Function GetAbility5(ByVal g As Gods) As String
        'Initialise variables
        Dim rqsql As String = ""
        Dim temp As AbilityDescription
        Dim tempitems As New Menuitem
        Dim ability As String = ""
        Dim affects As String = ""
        Dim damage As String = ""
        Dim range As String = ""
        'Get the ability description
        temp = g.abilityDescription5.itemDescription
        'Isolate the sub items (need some work to be more precise)
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
        'Return the finishe query
        Return rqsql
    End Function

    'Timer to check the session status and regenerate a session if needed
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'Get the current universal time
        Dim CurrentDate As DateTime = DateAndTime.Now.ToUniversalTime
        'Create a variable to store the difference
        Dim TimeDiff As TimeSpan
        'Get the time difference
        TimeDiff = SessionExpiration.Subtract(CurrentDate)
        'If the time remaining is more than 1 minute then we are ok
        'I chose 1 minute as that way it will stop having a problem if the user clicks a request while the session just expired
        'That way we always stay ocnnected
        If TimeDiff.TotalMinutes > 1 Then
            'Format remaining time
            sessionexpire_txt.ForeColor = Color.DarkBlue
            sessionexpire_txt.Text = TimeDiff.Minutes.ToString & " Minutes " & TimeDiff.Seconds.ToString & " Seconds"
        Else
            'Stop the timer in case it takes time to create the session
            Timer1.Stop()
            'Format expired time
            sessionexpire_txt.ForeColor = Color.Red
            sessionexpire_txt.Text = "Expired!"
            'Create new session
            CreateSession()
            'start the timer again
            Timer1.Start()
        End If
    End Sub

    'Sub to generate baloon notification
    Public Sub GiveNotification(ByVal Title As String, ByVal Message As String)
        'Format the notification
        NotifyIcon1.BalloonTipTitle = Title
        NotifyIcon1.BalloonTipText = Message
        NotifyIcon1.ShowBalloonTip(3000)
    End Sub

    'Debug Button sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Button only visible in debug mode
        'It clears the DGV
        DataGridView1.Rows.Clear()
        DataGridView1.Columns.Clear()
    End Sub

    'This timer executes every 5 seconds to not consume to much
    'It checks if the API is online 
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        'Get the current status of the API
        Dim IsOnline As Boolean = RequestPing()
        'Format the current API status
        If IsOnline = True Then
            Label2.ForeColor = Color.DarkGreen
            Label2.Text = "Online"
        Else
            Label2.ForeColor = Color.DarkRed
            Label2.Text = "Offline"
        End If
    End Sub

    'Show Preferences Button Sub
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        V_Preferences.Show()
    End Sub

End Class


'SessionInfo class should be moved to its own module/class
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


