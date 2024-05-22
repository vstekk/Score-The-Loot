﻿using System.Security.Cryptography;
using Score_The_Loot;

public static class ItemModsGenerator
{
    #region MODIFIER RANGES

    private static readonly Dictionary<StatModType, Dictionary<ItemRarity, (int Min, int Max)>> Ranges = new()
    {
        {
            StatModType.Flat, new Dictionary<ItemRarity, (int Min, int Max)>
            {
                { ItemRarity.Normal, (1, 10) },
                { ItemRarity.Magic, (5, 15) },
                { ItemRarity.Rare, (10, 20) },
                { ItemRarity.Cursed, (10, 30) }
            }
        },
        {
            StatModType.Additive, new Dictionary<ItemRarity, (int Min, int Max)>
            {
                { ItemRarity.Normal, (10, 20) },
                { ItemRarity.Magic, (10, 30) },
                { ItemRarity.Rare, (20, 50) },
                { ItemRarity.Cursed, (30, 60) }
            }
        },
        {
            StatModType.Multiplicative, new Dictionary<ItemRarity, (int Min, int Max)>
            {
                { ItemRarity.Normal, (2, 5) },
                { ItemRarity.Magic, (3, 8) },
                { ItemRarity.Rare, (5, 12) },
                { ItemRarity.Cursed, (10, 20) }
            }
        }
    };

    #endregion
    
    private static Random random = new ();
    public static List<StatModifier> GenerateMods(ItemRarity rarity)
    {
        var mods = new List<StatModifier>();
        mods.Add(GenerateMod(rarity));
        
        if (rarity == ItemRarity.Cursed)
        {
            StatModifier cursedMod;
            do
            {
                cursedMod = GenerateMod(rarity, true);
            } while (mods.Any(x => x.Type == cursedMod.Type));
            mods.Add(cursedMod);
        }
        
        return mods;
    }

    private static StatModifier GenerateMod(ItemRarity rarity, bool cursed = false)
    {
        var modType = EnumUtils.GetRandomValue<StatModType>(); //GetRandomModType();
        var range = Ranges[modType][rarity];
        var value = GetRandomValue(range.Min, range.Max);
        if (cursed) value *= -1;
        
        return new StatModifier(value, modType);
    }
    
    private static int GetRandomValue(int min, int max) => random.Next(min, max); 
    
    private static StatModType GetRandomModType()
    {
        var values = Enum.GetValues<StatModType>();
        return (StatModType) (values.GetValue(random.Next(values.Length)) ?? StatModType.Additive);
    }
    
    
}