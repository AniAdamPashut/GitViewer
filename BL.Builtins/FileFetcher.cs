using BL.Core;
using BL.Core.Models;

namespace BL.Builtins;

public class FileFetcher
{
    private Command _command;
    private IExecutable _executor;
    private Func<string, List<string>> _parse;

    public FileFetcher(IExecutable exe, Command command, Func<string, List<string>> parse)
    {
        _command = command;
        _executor = exe;
        _parse = parse;
    }

    public List<string> Fetch(string commitHash)
    {
        _command = _command with { Arguments = [commitHash] };
        var files = _executor.Do(_command);
        return _parse(files);
    }
}
