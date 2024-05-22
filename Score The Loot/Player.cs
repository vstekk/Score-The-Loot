public class Player
{
    public CharacterStat Score;
    public Dictionary<ItemType, Item> Items;

    public Player(int baseScore)
    {
        Score = new CharacterStat(baseScore);
        Items = new Dictionary<ItemType, Item>();
    }

    public void EquipItem(Item item)
    {
        if (Items.ContainsKey(item.Type))
        {
            UnequipItem(Items[item.Type]);
        }

        Items[item.Type] = item;
        foreach (var mod in item._mods)
        {
            Score.AddModifier(mod);
        }
    }

    private void UnequipItem(Item item)
    {
        foreach (var mod in item._mods)
        {
            Score.RemoveModifier(mod);
        }
    }
}