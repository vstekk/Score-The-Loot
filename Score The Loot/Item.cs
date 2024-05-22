public class Item
{
    public readonly string Name;
    public readonly List<StatModifier> _mods;

    public Item(ItemRarity rarity, ItemType type)
    {
        Name = ItemNameGenerator.GenerateItemName(rarity, type);
        _mods = ItemModsGenerator.GenerateMods(rarity);
    }
}

public enum ItemRarity
{
    Normal,
    Magic,
    Rare,
    Cursed
}
public enum ItemType
{
    Head,
    Chest,
    Hands,
    Legs,
    Feet
}