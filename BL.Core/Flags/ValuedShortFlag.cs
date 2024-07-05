namespace BL.Core.Flags;

public record ValuedShortFlag(string Flag, string Value) 
    : Flag($"-{Flag} {Value}", Flag);