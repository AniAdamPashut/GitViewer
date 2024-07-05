using BL.Core;
using BL.Core.Flags;

namespace BL.Builtins;

public class CommandBuilder
{
    private Command _command;

    public CommandBuilder(string cmd, HashSet<string> allowedFlags)
    {
        _command = new Command(cmd, allowedFlags);
    }

    public CommandBuilder AddFlag(Flag flag)
    {
        _command.AddFlag(flag);
        return this;
    }

    public Command Build()
    {
        return _command;
    }
}
