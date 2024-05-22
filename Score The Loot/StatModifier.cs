public class StatModifier
{
    public readonly int Value;
    public readonly StatModType Type;

    public StatModifier(int value, StatModType type)
    {
        Value = value;
        Type = type;
    }
}

public enum StatModType
{
    Flat,
    Additive,
    Multiplicative
}