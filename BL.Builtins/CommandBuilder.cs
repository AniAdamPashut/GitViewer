using BL.Core;
using BL.Core.Flags;

namespace BL.Builtins;

public class CommandBuilder
{
    private string _command;
    private List<Flag> _flags = [];
    private List<string> _arguments = [];

    public CommandBuilder(string cmd)
    {
        _command = cmd;
    }

    public CommandBuilder AddFlag(Flag flag)
    {
        _flags.Add(flag);
        return this;
    }
    
    public CommandBuilder AddArgument(string arg)
    {
        _arguments.Add(arg);
        return this;
    }
    public Command Build()
    {
        return new Command(_command, _arguments.ToArray(), _flags.ToArray());
    }
}
