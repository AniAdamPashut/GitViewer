using Microsoft.Extensions.Logging;

using System.Diagnostics;

namespace BL.Core;

public class GitStream : IGitConnection
{
    private readonly ILogger _logger;
    private Process _process;
    private readonly ProcessStartInfo _startInfo;

    private StreamReader _processOutput => _process.StandardOutput;
    public GitStream(ILogger logger, ProcessStartInfo psi)
    {
        _logger = logger;
        psi.RedirectStandardOutput = true;
        _startInfo = psi;
        _process = new() { StartInfo = _startInfo };
    }

    public string Do(string cmd)
    {
        _logger.LogInformation($"Message received: {cmd}");
        _startInfo.Arguments = cmd;
        _process.Start();
        string output = _processOutput.ReadToEnd();
        return output;

    }
}