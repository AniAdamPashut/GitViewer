using BL.Core;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace BL.Builtins;

public class GitExecutable : ExecuteableBase
{
    public GitExecutable(string gitPath, ILogger logger, ProcessStartInfo psi) 
        : base(gitPath, "git.exe", logger, psi)
    {
    }
}

