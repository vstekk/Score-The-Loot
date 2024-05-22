﻿using Score_The_Loot;

var player = new Player(0);
Item item;

for (int i = 0; i < 5; i++)
{
    var type = EnumUtils.GetRandomValue<ItemType>();
    var rarity = EnumUtils.GetRandomValue<ItemRarity>();
    
    item = new Item(rarity, type);
    Console.WriteLine(item.DisplayString());
}
