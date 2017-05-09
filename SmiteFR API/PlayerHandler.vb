Public Class Player
    Public Property Avatar_URL() As String
        Get
            Return m_Avatar_URL
        End Get
        Set
            m_Avatar_URL = Value
        End Set
    End Property
    Private m_Avatar_URL As String

    Public Property Created_Datetime() As String
        Get
            Return m_Created_Datetime
        End Get
        Set
            m_Created_Datetime = Value
        End Set
    End Property
    Private m_Created_Datetime As String

    Public Property Id() As Integer
        Get
            Return m_Id
        End Get
        Set
            m_Id = Value
        End Set
    End Property
    Private m_Id As Integer

    Public Property Last_Login_Datetime() As String
        Get
            Return m_Last_Login_Datetime
        End Get
        Set
            m_Last_Login_Datetime = Value
        End Set
    End Property
    Private m_Last_Login_Datetime As String

    Public Property Leaves() As Integer
        Get
            Return m_Leaves
        End Get
        Set
            m_Leaves = Value
        End Set
    End Property
    Private m_Leaves As Integer

    Public Property Level() As Integer
        Get
            Return m_Level
        End Get
        Set
            m_Level = Value
        End Set
    End Property
    Private m_Level As Integer

    Public Property Losses() As Integer
        Get
            Return m_Losses
        End Get
        Set
            m_Losses = Value
        End Set
    End Property
    Private m_Losses As Integer

    Public Property MasteryLevel() As Integer
        Get
            Return m_MasteryLevel
        End Get
        Set
            m_MasteryLevel = Value
        End Set
    End Property
    Private m_MasteryLevel As Integer

    Public Property Name() As String
        Get
            Return m_Name
        End Get
        Set
            m_Name = Value
        End Set
    End Property
    Private m_Name As String

    Public Property Personal_Status_Message() As String
        Get
            Return m_Personal_Status_Message
        End Get
        Set
            m_Personal_Status_Message = Value
        End Set
    End Property
    Private m_Personal_Status_Message As String

    Public Property Rank_Stat_Conquest() As Integer
        Get
            Return m_Rank_Stat_Conquest
        End Get
        Set
            m_Rank_Stat_Conquest = Value
        End Set
    End Property
    Private m_Rank_Stat_Conquest As Integer

    Public Property Rank_Stat_Duel() As Integer
        Get
            Return m_Rank_Stat_Duel
        End Get
        Set
            m_Rank_Stat_Duel = Value
        End Set
    End Property
    Private m_Rank_Stat_Duel As Integer

    Public Property Rank_Stat_Joust() As Integer
        Get
            Return m_Rank_Stat_Joust
        End Get
        Set
            m_Rank_Stat_Joust = Value
        End Set
    End Property
    Private m_Rank_Stat_Joust As Integer

    Public Property RankedConquest() As Ranked
        Get
            Return m_RankedConquest
        End Get
        Set
            m_RankedConquest = Value
        End Set
    End Property
    Private m_RankedConquest As Ranked

    Public Property RankedDuel() As Ranked
        Get
            Return m_RankedDuel
        End Get
        Set
            m_RankedDuel = Value
        End Set
    End Property
    Private m_RankedDuel As Ranked

    Public Property RankedJoust() As Ranked
        Get
            Return m_RankedJoust
        End Get
        Set
            m_RankedJoust = Value
        End Set
    End Property
    Private m_RankedJoust As Ranked

    Public Property Region() As String
        Get
            Return m_Region
        End Get
        Set
            m_Region = Value
        End Set
    End Property
    Private m_Region As String

    Public Property TeamId() As Integer
        Get
            Return m_TeamId
        End Get
        Set
            m_TeamId = Value
        End Set
    End Property
    Private m_TeamId As Integer

    Public Property Team_Name() As String
        Get
            Return m_Team_Name
        End Get
        Set
            m_Team_Name = Value
        End Set
    End Property
    Private m_Team_Name As String

    Public Property Tier_Conquest() As Integer
        Get
            Return m_Tier_Conquest
        End Get
        Set
            m_Tier_Conquest = Value
        End Set
    End Property
    Private m_Tier_Conquest As Integer

    Public Property Tier_Duel() As Integer
        Get
            Return m_Tier_Duel
        End Get
        Set
            m_Tier_Duel = Value
        End Set
    End Property
    Private m_Tier_Duel As Integer

    Public Property Tier_Joust() As Integer
        Get
            Return m_Tier_Joust
        End Get
        Set
            m_Tier_Joust = Value
        End Set
    End Property
    Private m_Tier_Joust As Integer

    Public Property Total_Achievements() As Integer
        Get
            Return m_Total_Achievements
        End Get
        Set
            m_Total_Achievements = Value
        End Set
    End Property
    Private m_Total_Achievements As Integer

    Public Property Total_Worshippers() As Integer
        Get
            Return m_Total_Worshippers
        End Get
        Set
            m_Total_Worshippers = Value
        End Set
    End Property
    Private m_Total_Worshippers As Integer

    Public Property Wins() As Integer
        Get
            Return m_Wins
        End Get
        Set
            m_Wins = Value
        End Set
    End Property
    Private m_Wins As Integer
End Class

Public Class Ranked
    Public Property Leaves() As Integer
        Get
            Return m_Leaves
        End Get
        Set
            m_Leaves = Value
        End Set
    End Property
    Private m_Leaves As Integer

    Public Property Losses() As Integer
        Get
            Return m_Losses
        End Get
        Set
            m_Losses = Value
        End Set
    End Property
    Private m_Losses As Integer

    Public Property Name() As String
        Get
            Return m_Name
        End Get
        Set
            m_Name = Value
        End Set
    End Property
    Private m_Name As String

    Public Property Points() As Integer
        Get
            Return m_Points
        End Get
        Set
            m_Points = Value
        End Set
    End Property
    Private m_Points As Integer

    Public Property PrevRank() As Integer
        Get
            Return m_PrevRank
        End Get
        Set
            m_PrevRank = Value
        End Set
    End Property
    Private m_PrevRank As Integer

    Public Property Rank() As Integer
        Get
            Return m_Rank
        End Get
        Set
            m_Rank = Value
        End Set
    End Property
    Private m_Rank As Integer

    Public Property Rank_Stat_Conquest() As String
        Get
            Return m_Rank_Stat_Conquest
        End Get
        Set
            m_Rank_Stat_Conquest = Value
        End Set
    End Property
    Private m_Rank_Stat_Conquest As String

    Public Property Rank_Stat_Duel() As String
        Get
            Return m_Rank_Stat_Duel
        End Get
        Set
            m_Rank_Stat_Duel = Value
        End Set
    End Property
    Private m_Rank_Stat_Duel As String

    Public Property Rank_Stat_Joust() As String
        Get
            Return m_Rank_Stat_Joust
        End Get
        Set
            m_Rank_Stat_Joust = Value
        End Set
    End Property
    Private m_Rank_Stat_Joust As String
    Public Property Season() As Integer
        Get
            Return m_Season
        End Get
        Set
            m_Season = Value
        End Set
    End Property
    Private m_Season As Integer

    Public Property Tier() As Integer
        Get
            Return m_Tier
        End Get
        Set
            m_Tier = Value
        End Set
    End Property
    Private m_Tier As Integer

    Public Property Trend() As Integer
        Get
            Return m_Trend
        End Get
        Set
            m_Trend = Value
        End Set
    End Property
    Private m_Trend As Integer

    Public Property Wins() As Integer
        Get
            Return m_Wins
        End Get
        Set
            m_Wins = Value
        End Set
    End Property
    Private m_Wins As Integer

    Public Property player_id() As String
        Get
            Return m_player_id
        End Get
        Set
            m_player_id = Value
        End Set
    End Property
    Private m_player_id As String

End Class
