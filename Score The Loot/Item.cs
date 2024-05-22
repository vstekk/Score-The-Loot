using System.Text;

public class Item
{
    public readonly string Name;
    public readonly ItemType Type;
    public readonly List<StatModifier> _mods;

    public Item(ItemRarity rarity, ItemType type)
    {
        Type = type;
        Name = ItemNameGenerator.GenerateItemName(rarity, type);
        _mods = ItemModsGenerator.GenerateMods(rarity);
    }

    public string DisplayString()
    {
        var sb = new StringBuilder();

        sb.AppendLine(Name);
        foreach (var mod in _mods)
        {
            sb.AppendLine(mod.DisplayString);
        }
        return sb.ToString();
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