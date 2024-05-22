public static class ItemNameGenerator
{
    #region ITEM NAME TABLES

    private static readonly Dictionary<ItemRarity, List<string>> ItemRarityAdjectives = new()
    {
        { ItemRarity.Normal, new List<string> 
            { "Common", "Plain", "Basic", "Simple", "Standard", "Ordinary", "Usual", "Regular", "Everyday", "Normal", "Routine", "Typical" } },
        { ItemRarity.Magic, new List<string> 
            { "Enchanted", "Mystic", "Arcane", "Magical", "Charmed", "Bewitched", "Sorcerous", "Wizardly", "Spellbound", "Otherworldly", "Fabled", "Mystical" } },
        { ItemRarity.Rare, new List<string> 
            { "Exquisite", "Grand", "Elegant", "Precious", "Valuable", "Rare", "Unique", "Uncommon", "Exceptional", "Extraordinary", "Special", "Distinctive" } },
        { ItemRarity.Cursed, new List<string> 
            { "Cursed", "Haunted", "Accursed", "Hexed", "Damned", "Malevolent", "Eerie", "Sinister", "Ominous", "Baleful", "Unholy", "Blighted" } }
    };

    private static readonly Dictionary<ItemType, List<string>> ItemTypeNames = new()
    {
        { ItemType.Head, new List<string> 
            { "Helmet", "Cap", "Hood", "Cowl", "Hat", "Headgear", "Helm", "Mask", "Crown", "Tiara", "Visor", "Headdress" } },
        { ItemType.Chest, new List<string> 
            { "Armor", "Vest", "Robe", "Chestplate", "Jerkin", "Tunic", "Tabard", "Brigandine", "Cuirass", "Breastplate", "Gambeson", "Doublet" } },
        { ItemType.Hands, new List<string> 
            { "Gloves", "Gauntlets", "Bracers", "Mitts", "Handwraps", "Fistguards", "Handguards", "Vambraces", "Claws", "Grips", "Paw", "Talons" } },
        { ItemType.Legs, new List<string> 
            { "Pants", "Leggings", "Greaves", "Breeches", "Trousers", "Hose", "Chaps", "Kilt", "Cuisses", "Skirt", "Legguards", "Shinguards" } },
        { ItemType.Feet, new List<string> 
            { "Boots", "Shoes", "Sandals", "Footwear", "Slippers", "Sabatons", "Moccasins", "Greaves", "Socks", "Spats", "Footwraps", "Clogs" } }
    };

    #endregion

    private static Random random = new();

    public static string GenerateItemName(ItemRarity rarity, ItemType type)
    {
        if (!ItemRarityAdjectives.ContainsKey(rarity) || !ItemTypeNames.ContainsKey(type))
        {
            throw new ArgumentException("Invalid rarity or type specified.");
        }

        string rarityString = GetRandomElement(ItemRarityAdjectives[rarity]);
        string typeString = GetRandomElement(ItemTypeNames[type]);

        return $"{rarityString} {typeString}";
    }
    private static string GetRandomElement(List<string> list) => list[random.Next(list.Count)];
}