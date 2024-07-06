namespace BL.Core.Models;


// Commit structure
// 1ebe868~Ben Amiel~Fri 19:33~2024-07-05T19:33:08+03:00~Starting to develop core 

public record Commit
{
    public string Hash { get; init; }
    public string Commiter { get; init; }
    public string HumanizedDate { get; init; }
    public DateTime Date { get; init; }
    public string Message { get; init; }

    public Commit(string commitToParse)
    {
        string[] values = commitToParse.Split('~');
        if (values.Length != 5)
            throw new ArgumentException($"CommitToParse was in a bad format: {commitToParse}");
        Hash = values[0];
        Commiter = values[1];
        HumanizedDate = values[2];
        Message = values[3];

        var date = values[4];
        if (!DateTime.TryParse(date, out DateTime parsed))
            throw new ArgumentException($"Cannot parse date {date} into a DateTime object");
        Date = parsed;
    }

    public Commit(
        string hash,
        string commiter,
        string humanizedDate,
        string date,
        string message
        )
    {
        Hash = hash;
        Commiter = commiter;
        HumanizedDate = humanizedDate;
        Message = message;

        if (!DateTime.TryParse(date, out DateTime parsed))
            throw new ArgumentException($"Cannot parse date {date} into a DateTime object");
        Date = parsed;
    }
}

