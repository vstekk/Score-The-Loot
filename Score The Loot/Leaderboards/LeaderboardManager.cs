using System.Text.Json;

public static class LeaderboardManager
{
    private static readonly string FilePath = "scores.json";

    public static void SaveLeaderboard(Leaderboard leaderboard)
    {
        string jsonString = JsonSerializer.Serialize(leaderboard);
        File.WriteAllText(FilePath, jsonString);
    }

    public static Leaderboard LoadScores()
    {
        if (!File.Exists(FilePath))
        {
            return new Leaderboard();
        }

        string jsonString = File.ReadAllText(FilePath);
        return JsonSerializer.Deserialize<Leaderboard>(jsonString) ?? new Leaderboard();
    }
}