using System.Text.Json.Serialization;
public class ScoreRecord
{
    public string PlayerName { get; set; }
    public int Score { get; set; }

    public ScoreRecord(string playerName, int score)
    {
        PlayerName = playerName;
        Score = score;
    }

    public override string ToString()
    {
        return $"{PlayerName}: {Score}";
    }
}