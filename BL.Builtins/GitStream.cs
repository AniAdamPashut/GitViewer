using BL.Core;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace BL.Builtins;

public class GitStream : IExecutable
{
    private readonly ILogger _logger;
    private readonly Process _process;
    private readonly ProcessStartInfo _startInfo;

    private StreamReader _processOutput => _process.StandardOutput;
    public GitStream(ILogger logger, ProcessStartInfo psi)
    {
        _logger = logger;
        psi.RedirectStandardOutput = true;
        _startInfo = psi;
        _process = new() { StartInfo = _startInfo };
    }
    public void Send(string cmd)
    {
        _logger.LogInformation($"Arguemnts Receieved: {cmd}");
        _startInfo.Arguments = cmd;
        _process.Start();
    }
    public string Do(string cmd)
    {
        Send(cmd);
        string output = _processOutput.ReadToEnd();
        return output;
    }
}