using BL.Core;
using BL.Core.Models;

namespace BL.Builtins;

public class FileFetcher
{
    private readonly Command _command;
    private readonly IExecutable _executor;
    private readonly Func<string, IEnumerable<string>> _parse;

    protected virtual IEnumerable<string> Parse(string input)
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

    public IEnumerable<string> Fetch(Commit commit)
    {
        var files = _executor.Do(_command with { Arguments = [commit.Hash] });
        return _parse(files);
    }

    public IEnumerable<string> Fetch(string commitHash)
    {
        var files = _executor.Do(_command with { Arguments = [commitHash] });
        return _parse(files);
    }
}
