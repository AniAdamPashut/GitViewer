namespace BL.Core.Flags;

public record ValuedLongFlag(string Flag, string Value) 
    : Flag($"--{Flag}={Value}", Flag);