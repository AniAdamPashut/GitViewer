namespace BL.Core.Flags;

public record ShortFlag(string Value) 
    : Flag(Value, $"-{Value}");
