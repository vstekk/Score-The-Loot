using System.Text;
using Score_The_Loot;

public class Item
{
    public readonly string Name;
    public readonly ItemType Type;
    public readonly ItemRarity Rarity;
    public readonly List<StatModifier> Mods;

    public Item(Random random, int round = 0)
    {
        Type = EnumUtils.GetRandomValue<ItemType>();
        Rarity = RollRarity(random, round);
        Name = ItemNameGenerator.GenerateItemName(Rarity, Type);
        Mods = ItemModsGenerator.GenerateMods(random, Rarity);
    }

    private ItemRarity RollRarity(Random random, int round = 0)
    {
        var roll = random.Next(0, 100);
        if (roll < 10 + round * 3) return ItemRarity.Cursed;
        if (roll < 20 + round * 3) return ItemRarity.Rare;
        if (roll < 40 + round * 3) return ItemRarity.Magical;
        
        return ItemRarity.Basic;
    }

    public string DisplayString()
    {
        var sb = new StringBuilder();
        
        sb.AppendLine(Name);
        sb.AppendLine($"({Rarity} {Type})");
        sb.AppendLine("---");
        foreach (var mod in Mods)
        {
            sb.AppendLine(mod.DisplayString);
        }

        sb.AppendLine("===");
        return sb.ToString();
    }
}

public enum ItemRarity
{
    Basic,
    Magical,
    Rare,
    Cursed
}
public enum ItemType
{
    Hat,
    Top,
    Gloves,
    Bottoms,
    Footwear
}