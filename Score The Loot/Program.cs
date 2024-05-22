
Console.WriteLine("Hello, World!");

var item = new Item(ItemRarity.Normal, ItemType.Head);

var player = new Player(0);
Console.WriteLine(player.Score.Value);
player.Score.AddModifier(item._mods[0]);
Console.WriteLine(player.Score.Value);
