namespace BL.Core.Flags;

public record LongFlag(string Value) 
    : Flag(Value, $"--{Value}");
