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
                { ItemRarity.Basic, (2, 4) },
                { ItemRarity.Magic, (5, 9) },
                { ItemRarity.Rare, (10, 14) },
                { ItemRarity.Cursed, (15, 20) }
            }
        },
        {
            StatModType.Additive, new Dictionary<ItemRarity, (int Min, int Max)>
            {
                { ItemRarity.Basic, (10, 19) },
                { ItemRarity.Magic, (20, 29) },
                { ItemRarity.Rare, (30, 39) },
                { ItemRarity.Cursed, (40, 50) }
            }
        },
        {
            StatModType.Multiplicative, new Dictionary<ItemRarity, (int Min, int Max)>
            {
                { ItemRarity.Basic, (5, 9) },
                { ItemRarity.Magic, (10, 14) },
                { ItemRarity.Rare, (15, 19) },
                { ItemRarity.Cursed, (20, 25) }
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
        var modType = Utils.GetRandomValue<StatModType>(); //GetRandomModType();
        var range = Ranges[modType][rarity];
        var value = GetRandomValue(random, range.Min, range.Max);
        if (cursed) value *= -1;
        
        return new StatModifier(value, modType);
    }
    
    private static int GetRandomValue(Random random, int min, int max) => random.Next(min, max); 
    
    
}