using BL.Core;
using BL.Core.Models;

namespace BL.Builtins;

public class FileFetcher
{
    private Command _command;
    private IExecutable _executor;
    private Func<string, IEnumerable<string>> _parse;

    protected IEnumerable<string> Parse(string input)
    {
        return input.Split(Environment.NewLine);
    }

    public FileFetcher(Command command, IExecutable executor)
    {
        _command = command;
        _executor = executor;
        _parse = Parse;
    }

    public FileFetcher(Command command, IExecutable exe, Func<string, List<string>> parse)
    {
        _command = command;
        _executor = exe;
        _parse = parse;
    }

    public IEnumerable<string> Fetch(string commitHash)
    {
        _command = _command with { Arguments = [commitHash] };
        var files = _executor.Do(_command);
        return _parse(files);
    }
}
