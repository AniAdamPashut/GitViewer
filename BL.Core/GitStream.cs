using Microsoft.Extensions.Logging;

using System.Diagnostics;

namespace BL.Core;

public class GitStream
{
    public readonly string GitBashFolder = @"C:\Program Files\Git\bin\";
    public readonly string GitBashExe = @"git.exe";
    
    private readonly ILogger _logger;
    public GitStream(ILogger logger)
    {
        _logger = logger;
    }

    public void OpenGitWindow()
    {
        ProcessStartInfo startInfo = new()
        {
            FileName = GitBashFolder + GitBashExe,
            UseShellExecute = false,
            RedirectStandardOutput = true,
            Arguments = "log",
            WindowStyle = ProcessWindowStyle.Hidden,
        };
        Process process = new()
        {
            StartInfo = startInfo,
        };
        process.Start();
        _logger.LogInformation("Test, Opening Git Commands");
        var output = process.StandardOutput.ReadToEnd();
        Console.WriteLine(output);
    }
}