namespace BL.Core.Models.Flags;

public record LongFlag(string Value)
    : Flag(Value, $"--{Value}");
