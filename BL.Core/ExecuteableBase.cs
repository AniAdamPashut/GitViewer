using BL.Core.Models;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace BL.Core;

public abstract class ExecuteableBase : IExecutable
{
    protected StreamReader ProcessOutput => InnerProcess.StandardOutput;

    protected readonly ILogger Logger;
    protected readonly Process InnerProcess;
    protected readonly ProcessStartInfo StartInformation;

    public ExecuteableBase(string exePath, string exeName, ILogger logger, ProcessStartInfo psi)
    {
        Logger = logger;
        psi.FileName = $@"{exePath}/{exeName}";
        psi.RedirectStandardOutput = true;
        StartInformation = psi;
        InnerProcess = new() { StartInfo = StartInformation };
    }

    public virtual void Send(Command cmd)
    {
        Logger.LogInformation("Arguemnts Receieved: {cmd}", cmd);
        StartInformation.Arguments = cmd.ToString();
        InnerProcess.Start();
    }

    public virtual string Do(Command cmd)
    {
        Send(cmd);
        return ProcessOutput.ReadToEnd();
    }
}
 