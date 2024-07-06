using BL.Core.Models;
using BL.Core.Models.Flags;

namespace BL.Builtins;

public class CommandBuilder
{
    private readonly string _command;
    private readonly List<Flag> _flags = [];
    private readonly List<string> _arguments = [];

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
        return new Command(_command, [.. _arguments], _flags.ToArray());
    }
}
