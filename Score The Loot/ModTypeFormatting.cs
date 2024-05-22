public static class ModTypeFormatting
{
    private static Dictionary<StatModType, string> formattingStrings = new()
    {
        { StatModType.Flat, "+ {0} score" },
        { StatModType.Additive, "+ {0}% score" },
        { StatModType.Multiplicative, "{0}% more score" }
    };
    
    public static string ToString(StatModifier mod)
    {
        if (!formattingStrings.ContainsKey(mod.Type))
        {
            throw new ArgumentException("Invalid stat modifier type specified.");
        }

        return string.Format(formattingStrings[mod.Type], mod.Value);
    }
}