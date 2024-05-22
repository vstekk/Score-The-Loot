using System.Security.Cryptography;
using Score_The_Loot;

public static class ItemModsGenerator
{
    #region MODIFIER RANGES

    private static readonly Dictionary<StatModType, Dictionary<ItemRarity, (int Min, int Max)>> Ranges = new()
    {
        {
            StatModType.Flat, new Dictionary<ItemRarity, (int Min, int Max)>
            {
                { ItemRarity.Basic, (5, 15) },
                { ItemRarity.Magical, (10, 20) },
                { ItemRarity.Rare, (15, 25) },
                { ItemRarity.Cursed, (25, 40) }
            }
        },
        {
            StatModType.Additive, new Dictionary<ItemRarity, (int Min, int Max)>
            {
                { ItemRarity.Basic, (10, 50) },
                { ItemRarity.Magical, (30, 80) },
                { ItemRarity.Rare, (50, 120) },
                { ItemRarity.Cursed, (80, 160) }
            }
        },
        {
            StatModType.Multiplicative, new Dictionary<ItemRarity, (int Min, int Max)>
            {
                { ItemRarity.Basic, (10, 30) },
                { ItemRarity.Magical, (15, 45) },
                { ItemRarity.Rare, (30, 60) },
                { ItemRarity.Cursed, (50, 90) }
            }
        }
    };

    #endregion
    
    public static List<StatModifier> GenerateMods(Random random, ItemRarity rarity)
    {
        var mods = new List<StatModifier>();
        mods.Add(GenerateMod(random, rarity));
        
        if (rarity == ItemRarity.Cursed)
        {
            StatModifier cursedMod;
            do
            {
                cursedMod = GenerateMod(random, rarity, true);
            } while (mods.Any(x => x.Type == cursedMod.Type));
            mods.Add(cursedMod);
        }
        
        return mods;
    }

    private static StatModifier GenerateMod(Random random, ItemRarity rarity, bool cursed = false)
    {
        var modType = EnumUtils.GetRandomValue<StatModType>(); //GetRandomModType();
        var range = Ranges[modType][rarity];
        var value = GetRandomValue(random, range.Min, range.Max);
        if (cursed) value *= -1;
        
        return new StatModifier(value, modType);
    }
    
    private static int GetRandomValue(Random random, int min, int max) => random.Next(min, max); 
    
    
}