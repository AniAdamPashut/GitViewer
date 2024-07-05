using BL.Core.Flags;

using System.Text;

namespace BL.Core;

public class Command
{
    IEnumerable<Flag> Flags => _flags;

    private readonly HashSet<string> _allowedFlags;
    private readonly List<Flag> _flags = new();
    private readonly string _command;

    public Command(string cmd, HashSet<string> allowedFlags)
    {
        _command = cmd;
        _allowedFlags = allowedFlags;
    }

    public void AddFlag(Flag flag)
    {
        if (flag is null
            || !_allowedFlags.Contains(flag.Name))
        {
            throw new ArgumentException($"Flag {flag?.Name ?? "(Unknown Flag)"} " +
                $"is invalid in current command context ({_command})");
        }
        _flags.Add(flag);
    }

    public override string ToString()
    {
        StringBuilder sb = new();
        sb.Append(_command);
        foreach (Flag flag in Flags)
        {
            sb.Append(' ');
            sb.Append(flag.Value);
        }
        return sb.ToString();
    }
}
