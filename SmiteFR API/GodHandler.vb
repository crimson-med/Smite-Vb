'This Class is the model for Gods based on the JSON response
Public Class Menuitem
    Public Property description() As String
        Get
            Return m_description
        End Get
        Set
            m_description = Value
        End Set
    End Property
    Private m_description As String
    Public Property value() As String
        Get
            Return m_value
        End Get
        Set
            m_value = Value
        End Set
    End Property
    Private m_value As String
End Class

Public Class Rankitem
    Public Property description() As String
        Get
            Return m_description
        End Get
        Set
            m_description = Value
        End Set
    End Property
    Private m_description As String
    Public Property value() As String
        Get
            Return m_value
        End Get
        Set
            m_value = Value
        End Set
    End Property
    Private m_value As String
End Class

Public Class AbilityDescription
    Public Property description() As String
        Get
            Return m_description
        End Get
        Set
            m_description = Value
        End Set
    End Property
    Private m_description As String
    Public Property secondaryDescription() As String
        Get
            Return m_secondaryDescription
        End Get
        Set
            m_secondaryDescription = Value
        End Set
    End Property
    Private m_secondaryDescription As String
    Public Property menuitems() As List(Of Menuitem)
        Get
            Return m_menuitems
        End Get
        Set
            m_menuitems = Value
        End Set
    End Property
    Private m_menuitems As List(Of Menuitem)
    Public Property rankitems() As List(Of Rankitem)
        Get
            Return m_rankitems
        End Get
        Set
            m_rankitems = Value
        End Set
    End Property
    Private m_rankitems As List(Of Rankitem)
    Public Property cooldown() As String
        Get
            Return m_cooldown
        End Get
        Set
            m_cooldown = Value
        End Set
    End Property
    Private m_cooldown As String
    Public Property cost() As String
        Get
            Return m_cost
        End Get
        Set
            m_cost = Value
        End Set
    End Property
    Private m_cost As String
End Class

Public Class AbilityRoot
    Public Property itemDescription() As AbilityDescription
        Get
            Return m_itemDescription
        End Get
        Set
            m_itemDescription = Value
        End Set
    End Property
    Private m_itemDescription As AbilityDescription
End Class

Public Class Gods
    Public Property abilityId1() As Integer
        Get
            Return m_abilityId1
        End Get
        Set
            m_abilityId1 = Value
        End Set
    End Property
    Private m_abilityId1 As Integer
    Public Property abilityId2() As Integer
        Get
            Return m_abilityId2
        End Get
        Set
            m_abilityId2 = Value
        End Set
    End Property
    Private m_abilityId2 As Integer
    Public Property abilityId3() As Integer
        Get
            Return m_abilityId3
        End Get
        Set
            m_abilityId3 = Value
        End Set
    End Property
    Private m_abilityId3 As Integer
    Public Property abilityId4() As Integer
        Get
            Return m_abilityId4
        End Get
        Set
            m_abilityId4 = Value
        End Set
    End Property
    Private m_abilityId4 As Integer
    Public Property abilityId5() As Integer
        Get
            Return m_abilityId5
        End Get
        Set
            m_abilityId5 = Value
        End Set
    End Property
    Private m_abilityId5 As Integer
    Public Property abilityDescription1() As AbilityRoot
        Get
            Return m_abilityDescription1
        End Get
        Set
            m_abilityDescription1 = Value
        End Set
    End Property
    Private m_abilityDescription1 As AbilityRoot
    Public Property abilityDescription2() As AbilityRoot
        Get
            Return m_abilityDescription2
        End Get
        Set
            m_abilityDescription2 = Value
        End Set
    End Property
    Private m_abilityDescription2 As AbilityRoot
    Public Property abilityDescription3() As AbilityRoot
        Get
            Return m_abilityDescription3
        End Get
        Set
            m_abilityDescription3 = Value
        End Set
    End Property
    Private m_abilityDescription3 As AbilityRoot
    Public Property abilityDescription4() As AbilityRoot
        Get
            Return m_abilityDescription4
        End Get
        Set
            m_abilityDescription4 = Value
        End Set
    End Property
    Private m_abilityDescription4 As AbilityRoot
    Public Property abilityDescription5() As AbilityRoot
        Get
            Return m_abilityDescription5
        End Get
        Set
            m_abilityDescription5 = Value
        End Set
    End Property
    Private m_abilityDescription5 As AbilityRoot
    Public Property id() As Integer
        Get
            Return m_id
        End Get
        Set
            m_id = Value
        End Set
    End Property
    Private m_id As Integer
    Public Property Cons() As String
        Get
            Return m_Cons
        End Get
        Set
            m_Cons = Value
        End Set
    End Property
    Private m_Cons As String
    Public Property godCard_URL() As String
        Get
            Return m_godCard_URL
        End Get
        Set
            m_godCard_URL = Value
        End Set
    End Property
    Private m_godCard_URL As String
    Public Property latestGod() As String
        Get
            Return m_latestGod
        End Get
        Set
            m_latestGod = Value
        End Set
    End Property
    Private m_latestGod As String

    Public Property godIcon_URL() As String
        Get
            Return m_godIcon_URL
        End Get
        Set
            m_godIcon_URL = Value
        End Set
    End Property
    Private m_godIcon_URL As String
    Public Property Pros() As String
        Get
            Return m_Pros
        End Get
        Set
            m_Pros = Value
        End Set
    End Property
    Private m_Pros As String
    Public Property Type() As String
        Get
            Return m_Type
        End Get
        Set
            m_Type = Value
        End Set
    End Property
    Private m_Type As String
    Public Property Roles() As String
        Get
            Return m_Roles
        End Get
        Set
            m_Roles = Value
        End Set
    End Property
    Private m_Roles As String
    Public Property Name() As String
        Get
            Return m_Name
        End Get
        Set
            m_Name = Value
        End Set
    End Property
    Private m_Name As String
    Public Property Title() As String
        Get
            Return m_Title
        End Get
        Set
            m_Title = Value
        End Set
    End Property
    Private m_Title As String
    Public Property OnFreeRotation() As String
        Get
            Return m_OnFreeRotation
        End Get
        Set
            m_OnFreeRotation = Value
        End Set
    End Property
    Private m_OnFreeRotation As String
    Public Property Lore() As String
        Get
            Return m_Lore
        End Get
        Set
            m_Lore = Value
        End Set
    End Property
    Private m_Lore As String
    Public Property Health() As Integer
        Get
            Return m_Health
        End Get
        Set
            m_Health = Value
        End Set
    End Property
    Private m_Health As Integer
    Public Property HealthPerLevel() As [Double]
        Get
            Return m_HealthPerLevel
        End Get
        Set
            m_HealthPerLevel = Value
        End Set
    End Property
    Private m_HealthPerLevel As [Double]
    Public Property Speed() As [Double]
        Get
            Return m_Speed
        End Get
        Set
            m_Speed = Value
        End Set
    End Property
    Private m_Speed As [Double]
    Public Property HealthPerFive() As [Double]
        Get
            Return m_HealthPerFive
        End Get
        Set
            m_HealthPerFive = Value
        End Set
    End Property
    Private m_HealthPerFive As [Double]
    Public Property HP5PerLevel() As [Double]
        Get
            Return m_HP5PerLevel
        End Get
        Set
            m_HP5PerLevel = Value
        End Set
    End Property
    Private m_HP5PerLevel As [Double]
    Public Property Mana() As [Double]
        Get
            Return m_Mana
        End Get
        Set
            m_Mana = Value
        End Set
    End Property
    Private m_Mana As [Double]
    Public Property ManaPerLevel() As [Double]
        Get
            Return m_ManaPerLevel
        End Get
        Set
            m_ManaPerLevel = Value
        End Set
    End Property
    Private m_ManaPerLevel As [Double]
    Public Property ManaPerFive() As [Double]
        Get
            Return m_ManaPerFive
        End Get
        Set
            m_ManaPerFive = Value
        End Set
    End Property
    Private m_ManaPerFive As [Double]
    Public Property MP5PerLevel() As [Double]
        Get
            Return m_MP5PerLevel
        End Get
        Set
            m_MP5PerLevel = Value
        End Set
    End Property
    Private m_MP5PerLevel As [Double]
    Public Property PhysicalProtection() As [Double]
        Get
            Return m_PhysicalProtection
        End Get
        Set
            m_PhysicalProtection = Value
        End Set
    End Property
    Private m_PhysicalProtection As [Double]
    Public Property PhysicalProtectionPerLevel() As [Double]
        Get
            Return m_PhysicalProtectionPerLevel
        End Get
        Set
            m_PhysicalProtectionPerLevel = Value
        End Set
    End Property
    Private m_PhysicalProtectionPerLevel As [Double]
    Public Property MagicProtection() As [Double]
        Get
            Return m_MagicProtection
        End Get
        Set
            m_MagicProtection = Value
        End Set
    End Property
    Private m_MagicProtection As [Double]
    Public Property MagicProtectionPerLevel() As [Double]
        Get
            Return m_MagicProtectionPerLevel
        End Get
        Set
            m_MagicProtectionPerLevel = Value
        End Set
    End Property
    Private m_MagicProtectionPerLevel As [Double]
    Public Property MagicalPower() As [Double]
        Get
            Return m_MagicalPower
        End Get
        Set
            m_MagicalPower = Value
        End Set
    End Property
    Private m_MagicalPower As [Double]
    Public Property MagicalPowerPerLevel() As [Double]
        Get
            Return m_MagicalPowerPerLevel
        End Get
        Set
            m_MagicalPowerPerLevel = Value
        End Set
    End Property
    Private m_MagicalPowerPerLevel As [Double]
    Public Property PhysicalPower() As [Double]
        Get
            Return m_PhysicalPower
        End Get
        Set
            m_PhysicalPower = Value
        End Set
    End Property
    Private m_PhysicalPower As [Double]
    Public Property PhysicalPowerPerLevel() As [Double]
        Get
            Return m_PhysicalPowerPerLevel
        End Get
        Set
            m_PhysicalPowerPerLevel = Value
        End Set
    End Property
    Private m_PhysicalPowerPerLevel As [Double]
    Public Property AttackSpeed() As [Double]
        Get
            Return m_AttackSpeed
        End Get
        Set
            m_AttackSpeed = Value
        End Set
    End Property
    Private m_AttackSpeed As [Double]
    Public Property AttackSpeedPerLevel() As [Double]
        Get
            Return m_AttackSpeedPerLevel
        End Get
        Set
            m_AttackSpeedPerLevel = Value
        End Set
    End Property
    Private m_AttackSpeedPerLevel As [Double]
    Public Property Pantheon() As String
        Get
            Return m_Pantheon
        End Get
        Set
            m_Pantheon = Value
        End Set
    End Property
    Private m_Pantheon As String
    Public Property Ability1() As String
        Get
            Return m_Ability1
        End Get
        Set
            m_Ability1 = Value
        End Set
    End Property
    Private m_Ability1 As String
    Public Property Ability2() As String
        Get
            Return m_Ability2
        End Get
        Set
            m_Ability2 = Value
        End Set
    End Property
    Private m_Ability2 As String
    Public Property Ability3() As String
        Get
            Return m_Ability3
        End Get
        Set
            m_Ability3 = Value
        End Set
    End Property
    Private m_Ability3 As String
    Public Property Ability4() As String
        Get
            Return m_Ability4
        End Get
        Set
            m_Ability4 = Value
        End Set
    End Property
    Private m_Ability4 As String
    Public Property Ability5() As String
        Get
            Return m_Ability5
        End Get
        Set
            m_Ability5 = Value
        End Set
    End Property
    Private m_Ability5 As String
    Public Property godAbility1_URL() As String
        Get
            Return m_godAbility1_URL
        End Get
        Set
            m_godAbility1_URL = Value
        End Set
    End Property
    Private m_godAbility1_URL As String
    Public Property godAbility2_URL() As String
        Get
            Return m_godAbility2_URL
        End Get
        Set
            m_godAbility2_URL = Value
        End Set
    End Property
    Private m_godAbility2_URL As String
    Public Property godAbility3_URL() As String
        Get
            Return m_godAbility3_URL
        End Get
        Set
            m_godAbility3_URL = Value
        End Set
    End Property
    Private m_godAbility3_URL As String
    Public Property godAbility4_URL() As String
        Get
            Return m_godAbility4_URL
        End Get
        Set
            m_godAbility4_URL = Value
        End Set
    End Property
    Private m_godAbility4_URL As String
    Public Property godAbility5_URL() As String
        Get
            Return m_godAbility5_URL
        End Get
        Set
            m_godAbility5_URL = Value
        End Set
    End Property
    Private m_godAbility5_URL As String
    Public Property Item1() As String
        Get
            Return m_Item1
        End Get
        Set
            m_Item1 = Value
        End Set
    End Property
    Private m_Item1 As String
    Public Property Item2() As String
        Get
            Return m_Item2
        End Get
        Set
            m_Item2 = Value
        End Set
    End Property
    Private m_Item2 As String
    Public Property Item3() As String
        Get
            Return m_Item3
        End Get
        Set
            m_Item3 = Value
        End Set
    End Property
    Private m_Item3 As String
    Public Property Item4() As String
        Get
            Return m_Item4
        End Get
        Set
            m_Item4 = Value
        End Set
    End Property
    Private m_Item4 As String
    Public Property Item5() As String
        Get
            Return m_Item5
        End Get
        Set
            m_Item5 = Value
        End Set
    End Property
    Private m_Item5 As String
    Public Property Item6() As String
        Get
            Return m_Item6
        End Get
        Set
            m_Item6 = Value
        End Set
    End Property
    Private m_Item6 As String
    Public Property Item7() As String
        Get
            Return m_Item7
        End Get
        Set
            m_Item7 = Value
        End Set
    End Property
    Private m_Item7 As String
    Public Property Item8() As String
        Get
            Return m_Item8
        End Get
        Set
            m_Item8 = Value
        End Set
    End Property
    Private m_Item8 As String
    Public Property Item9() As String
        Get
            Return m_Item9
        End Get
        Set
            m_Item9 = Value
        End Set
    End Property
    Private m_Item9 As String
    Public Property ItemId1() As Integer
        Get
            Return m_ItemId1
        End Get
        Set
            m_ItemId1 = Value
        End Set
    End Property
    Private m_ItemId1 As Integer
    Public Property ItemId2() As Integer
        Get
            Return m_ItemId2
        End Get
        Set
            m_ItemId2 = Value
        End Set
    End Property
    Private m_ItemId2 As Integer
    Public Property ItemId3() As Integer
        Get
            Return m_ItemId3
        End Get
        Set
            m_ItemId3 = Value
        End Set
    End Property
    Private m_ItemId3 As Integer
    Public Property ItemId4() As Integer
        Get
            Return m_ItemId4
        End Get
        Set
            m_ItemId4 = Value
        End Set
    End Property
    Private m_ItemId4 As Integer
    Public Property ItemId5() As Integer
        Get
            Return m_ItemId5
        End Get
        Set
            m_ItemId5 = Value
        End Set
    End Property
    Private m_ItemId5 As Integer
    Public Property ItemId6() As Integer
        Get
            Return m_ItemId6
        End Get
        Set
            m_ItemId6 = Value
        End Set
    End Property
    Private m_ItemId6 As Integer
    Public Property ItemId7() As Integer
        Get
            Return m_ItemId7
        End Get
        Set
            m_ItemId7 = Value
        End Set
    End Property
    Private m_ItemId7 As Integer
    Public Property ItemId8() As Integer
        Get
            Return m_ItemId8
        End Get
        Set
            m_ItemId8 = Value
        End Set
    End Property
    Private m_ItemId8 As Integer
    Public Property ItemId9() As Integer
        Get
            Return m_ItemId9
        End Get
        Set
            m_ItemId9 = Value
        End Set
    End Property
    Private m_ItemId9 As Integer
    Public Property ret_msg() As String
        Get
            Return m_ret_msg
        End Get
        Set
            m_ret_msg = Value
        End Set
    End Property
    Private m_ret_msg As String
End Class