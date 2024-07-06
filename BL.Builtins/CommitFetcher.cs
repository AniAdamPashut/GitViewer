using BL.Core;
using BL.Core.Models;

namespace BL.Builtins;

public class CommitFetcher
{
    protected Func<string, IEnumerable<Commit>> Parser { get; init; }

    private readonly Command _command;
    private readonly IExecutable _executor;

    protected virtual IEnumerable<Commit> Parse(string input)
    {
        return input.Split("##")
            .Where(line => !String.IsNullOrWhiteSpace(line))
            .Select(line => line.Split('~'))
            .Select(sections =>
                new Commit(
                    sections[0].TrimStart(), 
                    sections[1], 
                    sections[2], 
                    sections[4], 
                    sections[3], 
                    sections[5]
                   )
                )
            .ToHashSet()
            .OrderByDescending(commit => commit.Date);
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

