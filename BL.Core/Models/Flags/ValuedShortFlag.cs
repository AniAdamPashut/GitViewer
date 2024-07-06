namespace BL.Core.Models.Flags;

public record ValuedShortFlag(string Flag, string Value)
    : Flag(Flag, $"-{Flag} {Value}");