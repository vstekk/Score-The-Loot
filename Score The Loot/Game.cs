using System.Text;

namespace Score_The_Loot;

public class Game
{
    private readonly int _rounds;
    private readonly int _lootAmount;
    private Random _rand;
    private Player _player;
    
    public Game(int rounds = 10, int baseScore = 0, int lootAmount = 3)
    {
        _rand = new Random();
        _rounds = rounds;
        _lootAmount = lootAmount;
        _player = new Player(baseScore);
    }

    public void Play()
    {
        for (int i = 0; i < _rounds; i++)
        {
            PlayRound(i + 1);
        }

        var sb = new StringBuilder();
        sb.AppendLine($"Score: {_player.Score.Value}");
        sb.AppendLine("Items:");
        sb.AppendLine();
        sb.AppendLine(_player.GetEquipmentString());

        Console.WriteLine(sb.ToString());
        
    }

    private void PlayRound(int currentRound)
    {
        var itemsOnOffer = new Dictionary<int, Item>();

        for (int i = 0; i < _lootAmount; i++)
        {
            itemsOnOffer.Add(i + 1, new Item(_rand));
        }

        var sb = new StringBuilder();
        AppendRoundInfo(currentRound, sb);

        foreach (var item in itemsOnOffer)
        {
            sb.Append($"{item.Key}. ");
            sb.AppendLine($"{item.Value.DisplayString()}");

        }

        sb.AppendLine();
        sb.AppendLine("Select Item by pressing 1 to 3 or see your items by pressing TAB.");
        Console.WriteLine(sb.ToString());

        ConsoleKey key;
        do
        {
            key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.Tab:
                    ShowInventory(currentRound);
                    Console.WriteLine(sb.ToString());
                    break;
                case ConsoleKey.D1:
                    _player.EquipItem(itemsOnOffer[1]);
                    key = ConsoleKey.Escape;
                    break;
                case ConsoleKey.D2:
                    _player.EquipItem(itemsOnOffer[2]);
                    key = ConsoleKey.Escape;
                    break;
                case ConsoleKey.D3:
                    _player.EquipItem(itemsOnOffer[3]);
                    key = ConsoleKey.Escape;
                    break;
            }
        } while (key != ConsoleKey.Escape);

        Console.Clear();
    }

    private void AppendRoundInfo(int currentRound, StringBuilder sb)
    {
        sb.AppendLine($"Round: {currentRound}");
        sb.AppendLine($"Score: {_player.Score.Value} ");
        sb.AppendLine();
    }

    private void ShowInventory(int currentRound)
    {
        Console.Clear();

        var sb = new StringBuilder();
        AppendRoundInfo(currentRound, sb);
        sb.AppendLine(_player.GetEquipmentString());
        sb.AppendLine("Press TAB to exit.");
        Console.WriteLine(sb.ToString());
        
        ConsoleKey key;
        do key = Console.ReadKey(true).Key;
        while (key != ConsoleKey.Tab);
        
        Console.Clear();
    }
}