namespace Score_The_Loot;

public static class EnumUtils
{
    private static Random random = new();
    
    public static T GetRandomValue<T>() where T : struct, Enum
    {
        var v = Enum.GetValues<T>();
        return (T) v.GetValue (random.Next(v.Length))!;
    }
}