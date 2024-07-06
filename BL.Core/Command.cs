using BL.Core.Flags;

using System.Text;

namespace BL.Core;

public class Command
{
    IEnumerable<Flag> Flags => _flags;
    IEnumerable<string> AllowedFlags => _allowedFlags;
    public string Name { get; }

    private readonly HashSet<string> _allowedFlags;
    private readonly List<Flag> _flags = [];
    private readonly List<string> _arguments;

    public Command(string cmd, List<string> arguments, HashSet<string> allowedFlags)
    {
        Name = cmd;
        _allowedFlags = allowedFlags;
        _arguments = arguments;
    }

    public void AddArgument(string arg)
    {
        _arguments.Add(arg);
    }

    public void AddFlag(Flag flag)
    {
        if (flag is null
            || !_allowedFlags.Contains(flag.Name))
        {
            throw new ArgumentException($"Flag {flag?.Name ?? "(Unknown Flag)"} " +
                $"is invalid in current command context ({Name})");
        }
        _flags.Add(flag);
    }

    public override string ToString()
    {
        StringBuilder sb = new();
        sb.Append(Name);
        foreach (var arg in _arguments)
        {
            sb.Append(' ');
            sb.Append(arg);
        }
        foreach (Flag flag in Flags)
        {
            sb.Append(' ');
            sb.Append(flag.Value);
        }
        return sb.ToString();
    }
}
