using System.Text;
using System.Text.Json.Serialization;

public class Leaderboard
{
    private List<ScoreRecord> _records;

    public Leaderboard()
    {
        _records = new List<ScoreRecord>();
    }

    public void AddScore(string playerName, int score)
    {
        _records.Add(new ScoreRecord(playerName, score));
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        if (_records.Count == 0) 
            sb.AppendLine("NO SCORE");
        else if (_records.Count == 1) 
            sb.AppendLine($"{_records.First().ToString()}");
        else
        {
            sb.AppendLine("ABSOLUTE MAXIMUM:");
            sb.AppendLine($"{_records.MaxBy(x => x.Score)?.ToString()}");
            sb.AppendLine("ABSOLUTE MINIMUM:");
            sb.AppendLine($"{_records.MinBy(x => x.Score)?.ToString()}");
        }
        
        return sb.ToString();
    }
}