namespace BL.Core.Models.Flags;

public record ShortFlag(string Value)
    : Flag(Value, $"-{Value}");
