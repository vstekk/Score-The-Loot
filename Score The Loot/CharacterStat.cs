public class CharacterStat
{
    public float BaseValue;
    public float Value => GetValue();

    private readonly List<StatModifier> statModifiers;

    private float _value;
    private bool isDirty = true;

    public CharacterStat(float baseValue)
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
        var finalValue = (BaseValue + flat) * (1 + additive/100);

        foreach (var mod in statModifiers.Where(x => x.Type == StatModType.Multiplicative))
        {
            finalValue *= 1 + mod.Value/100;
        }
        
        return MathF.Round(finalValue, MidpointRounding.AwayFromZero);
    }
}