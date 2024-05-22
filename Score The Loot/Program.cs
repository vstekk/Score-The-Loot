﻿using System.Text;
using System.Threading.Channels;
using Score_The_Loot;

Leaderboard leaderboard = LeaderboardManager.LoadScores();

MainMenu();


void MainMenu()
{
    Console.Clear();
    
    var sb = new StringBuilder();
    sb.AppendLine("ENTER to Start");
    sb.AppendLine("TAB to Leaderboard");
    sb.AppendLine("BACKSPACE to Exit");
    Console.WriteLine(sb.ToString());
    
    ConsoleKey key;
    do
    {
        key = Console.ReadKey(true).Key;
        switch (key)
        {
            case ConsoleKey.Enter:
                Game game = new Game(leaderboard);
                game.Play();
                break;
            case ConsoleKey.Tab:
                Console.Clear();
                Console.WriteLine(leaderboard.ToString());
                Console.ReadKey();
                break;
        }
        Console.Clear();
        Console.WriteLine(sb.ToString());
        
    } while (key != ConsoleKey.Backspace);

    LeaderboardManager.SaveLeaderboard(leaderboard);
    Console.Clear();
    Console.WriteLine("EXITING");
}