public static class ModTypeFormatting
{
    
    private static Dictionary<StatModType, string> formattingStrings = new()
    {
        { StatModType.Flat, "{0} {1} score" },
        { StatModType.Additive, "{0} {1}% score" }
    };

    public static string ToString(StatModifier mod)
    {
        if (mod.Type == StatModType.Multiplicative)
        {
            return FormatMultiplicativeModifier(mod.Value);
        }
        
        if (!formattingStrings.ContainsKey(mod.Type))
        {
            throw new ArgumentException("Invalid stat modifier type specified.");
        }

        string sign = mod.Value < 0 ? "-" : "+";

        return string.Format(formattingStrings[mod.Type], sign, Math.Abs(mod.Value));
    }

    private static string FormatMultiplicativeModifier(double value)
    {
        string effect = value < 0 ? "less" : "more";

        return $"{Math.Abs(value)}% {effect} score";
    }
}