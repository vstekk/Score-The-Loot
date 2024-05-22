public class CharacterStat
{
    public int BaseValue;
    public float Value => GetValue();

    private readonly List<StatModifier> statModifiers;

    private float _value;
    private bool isDirty = true;

    public CharacterStat(int baseValue)
    {
        BaseValue = baseValue;
        statModifiers = new List<StatModifier>();
    }

    public void AddModifier(StatModifier mod)
    {
        isDirty = true;
        statModifiers.Add(mod);
    }

    public bool RemoveModifier(StatModifier mod)
    {
        isDirty = true;
        return statModifiers.Remove(mod);
    }

    private float GetValue()
    {
        if (isDirty)
        {
            _value = CalculateFinalValue();
            isDirty = false;
        }

        return _value;
    }

    private float CalculateFinalValue()
    {
        var flat = statModifiers.Where(x => x.Type == StatModType.Flat).Sum(x => x.Value);
        var additive = statModifiers.Where(x => x.Type == StatModType.Additive).Sum(x => x.Value);
        var finalValue = (BaseValue + flat) * (1 + (float)additive/100);

        foreach (var mod in statModifiers.Where(x => x.Type == StatModType.Multiplicative))
        {
            finalValue *= (1 + (float)mod.Value / 100);
        }

        Console.WriteLine($"({flat} * {additive}) * {String.Join(" *", statModifiers.Where(x => x.Type == StatModType.Multiplicative).Select(x => (1 + (float)(x.Value / 100))))}");
        return MathF.Round(finalValue, 2,MidpointRounding.AwayFromZero);
    }
}