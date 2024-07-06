using BL.Core;
using BL.Core.Models;

namespace BL.Builtins;

public class CommitFetcher
{
    protected Func<string, IEnumerable<Commit>> Parser { get; init; }

    private Command _command;
    private IExecutable _executor;

    protected IEnumerable<Commit> Parse(string input)
    {
        return input.Split("##")
            .Where(line => line.Contains('~'))
            .Select(line => line.Split('~'))
            .Select(sections => new Commit(sections[0], sections[1], sections[2], sections[4], sections[3]))
            .ToHashSet();
    }

    public CommitFetcher(Command cmd, IExecutable exe)
    {
        _command = cmd;
        _executor = exe;
        Parser = Parse;
    }

    public CommitFetcher(Command cmd, IExecutable exe, Func<string, IEnumerable<Commit>> parser)
    {
        _command = cmd;
        _executor = exe;
        Parser = parser;
    }

    public IEnumerable<Commit> Fetch()
    {
        string exeOutput = _executor.Do(_command);
        return Parser.Invoke(exeOutput);
    }
}

