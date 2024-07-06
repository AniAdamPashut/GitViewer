namespace BL.Core.Models;

public sealed record Commit : IEquatable<Commit>
{
    public string Display 
        => String.IsNullOrWhiteSpace(Ref) ? Hash : Ref;
    public string Hash { get; init; }
    public string Commiter { get; init; }
    public string HumanizedDate { get; init; }
    public DateTime Date { get; init; }
    public string Message { get; init; }
    public string Ref { get; init; }

    public Commit(
        string hash,
        string commiter,
        string humanizedDate,
        string date,
        string message,
        string reference
        )
    {
        Hash = hash;
        Commiter = commiter;
        HumanizedDate = humanizedDate;
        Message = message;
        Ref = reference;

        if (!DateTime.TryParse(date, out DateTime parsed))
            throw new ArgumentException($"Cannot parse date {date} into a DateTime object");
        Date = parsed;
    }

    public override int GetHashCode()
    {
        return Hash.GetHashCode();
    }

    public bool Equals(Commit? other)
    {
        if (other is null)
            return false;
        return Hash == other.Hash;
    }
}

