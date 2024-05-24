using System.Text;

namespace Score_The_Loot;

public class Game
{
    private readonly Leaderboard _leaderboard;
    private readonly int _rounds;
    private readonly int _lootAmount;
    private readonly Random _rand;
    private readonly Player _player;
    
    public Game(Leaderboard leaderboard, int rounds = 10, int baseScore = 0, int lootAmount = 3)
    {
        _rand = new Random();
        _leaderboard = leaderboard;
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
        
        EndGame();
    }

    private void EndGame()
    {
        Console.Clear();
        
        var sb = new StringBuilder();
        sb.AppendLine($"Score: {_player.Score.Value}");
        sb.AppendLine("Your Inventory:");
        sb.AppendLine();
        sb.AppendLine(_player.GetEquipmentString());
        sb.AppendLine("ENTER to Continue");
        Console.WriteLine(sb.ToString());
        do
        {
        } while (Console.ReadKey(true).Key != ConsoleKey.Enter);
        Console.Clear();
        
        Console.WriteLine("Enter your Name and press ENTER");
        var name = Console.ReadLine();
        if (!string.IsNullOrEmpty(name))
        {
            _leaderboard.AddScore(name, _player.Score.Value);
        }

    }

    private void PlayRound(int currentRound)
    {
        Console.Clear();
        
        var itemsOnOffer = new Dictionary<int, Item>();
        for (int i = 0; i < _lootAmount; i++)
        {
            itemsOnOffer.Add(i + 1, new Item(_rand));
        }

        //var itemsOnOffer = Enumerable.Range(0, _lootAmount).Select(_ => new Item(_rand)).ToArray();

        var sb = new StringBuilder();
        AppendRoundInfo(currentRound, sb);

        foreach (var item in itemsOnOffer)
        {
            sb.Append($"{item.Key}. ");
            sb.AppendLine($"{item.Value.DisplayString()}");
        }

        sb.AppendLine();
        sb.AppendLine("1/2/3 to select Item");
        sb.AppendLine("TAB to show Inventory");
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
                case ConsoleKey.NumPad1:
                    _player.EquipItem(itemsOnOffer[1]);
                    key = ConsoleKey.Escape;
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    _player.EquipItem(itemsOnOffer[2]);
                    key = ConsoleKey.Escape;
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
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
        sb.AppendLine("My Items:");
        sb.AppendLine(_player.GetEquipmentString());
        sb.AppendLine("Press TAB to exit.");
        Console.WriteLine(sb.ToString());
        
        ConsoleKey key;
        do key = Console.ReadKey(true).Key;
        while (key != ConsoleKey.Tab);
        
        Console.Clear();
    }
}