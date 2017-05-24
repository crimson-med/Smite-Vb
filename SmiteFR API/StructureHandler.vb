'This Module handles everything related with structures for the DGV
Module StructureHandler
    'generate list of all the columns to implement
    Public ItemStructure As List(Of String) = GetItemStructure()
    Public GodStructure As List(Of String) = GetGodStructure()

    'Current Item Structure this will depend on your database or the data you want to work with
    'Maybe you don't need all of the data
    Public Function GetItemStructure() As List(Of String)
        Dim Ini As New List(Of String)
        Ini.Add("ChildItemId")
        Ini.Add("DeviceName")
        Ini.Add("IconId")
        Ini.Add("ItemDescription")
        Ini.Add("ItemId")
        Ini.Add("ItemTier")
        Ini.Add("Price")
        Ini.Add("RootItemId")
        Ini.Add("ShortDesc")
        Ini.Add("StartingItem")
        Ini.Add("Type")
        Ini.Add("itemIcon_Url")
        Ini.Add("ret_msg")
        Return Ini
    End Function

    'Current God Structure this will depend on your database or the data you want to work with
    'Maybe you don't need all of the data
    Public Function GetGodStructure() As List(Of String)
        Dim Ini As New List(Of String)
        Ini.Add("GodID")
        Ini.Add("AttackSpeed")
        Ini.Add("AttackSpeedPerLevel")
        Ini.Add("Cons")
        Ini.Add("HP5PerLevel")
        Ini.Add("Health")
        Ini.Add("HealthPer5")
        Ini.Add("HealthPerLevel")
        Ini.Add("Lore")
        Ini.Add("MP5PerLevel")
        Ini.Add("MagicProtection")
        Ini.Add("MagicProtectionPerLevel")
        Ini.Add("MagicalPower")
        Ini.Add("MagicalPowerPerLevel")
        Ini.Add("Mana")
        Ini.Add("ManaPerFive")
        Ini.Add("ManaPerLevel")
        Ini.Add("Name")
        Ini.Add("OnFreeRotation")
        Ini.Add("Pantheon")
        Ini.Add("PhysicalPower")
        Ini.Add("PhysicalPowerPerLevel")
        Ini.Add("PhysicalProtection")
        Ini.Add("PhysicalProtectionPerLevel")
        Ini.Add("Pros")
        Ini.Add("Roles")
        Ini.Add("Speed")
        Ini.Add("Title")
        Ini.Add("Type")
        Ini.Add("GodIcon")
        Ini.Add("GodCard")
        Ini.Add("LatestGod")
        'Ini.Add("BasicAttackDmg")
        'Ini.Add("BasicAttackProgression")
        Return Ini
    End Function
End Module
