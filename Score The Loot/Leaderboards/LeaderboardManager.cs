using System.Text.Json;

public static class LeaderboardManager
{
    private const string FilePath = "scores.json";

    public static void SaveLeaderboard(Leaderboard leaderboard)
    {
        string jsonString = JsonSerializer.Serialize(leaderboard.Records);
        File.WriteAllText(FilePath, jsonString);
    }

    public static Leaderboard LoadScores()
    {
        if (!File.Exists(FilePath))
        {
            return new Leaderboard();
        }

        string jsonString = File.ReadAllText(FilePath);
        var records = JsonSerializer.Deserialize<ScoreRecord[]>(jsonString);
        
        return records != null ? new Leaderboard(records) : new Leaderboard();
        
    }
}