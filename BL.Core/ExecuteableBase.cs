﻿using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace BL.Core;

public abstract class ExecuteableBase : IExecutable
{
    protected readonly ILogger Logger;
    protected readonly Process InnerProcess;
    protected readonly ProcessStartInfo StartInformation;

    protected StreamReader _processOutput => InnerProcess.StandardOutput;
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
        Logger.LogInformation($"Arguemnts Receieved: {cmd}");
        StartInformation.Arguments = cmd.ToString();
        InnerProcess.Start();
    }
    public string Do(Command cmd)
    {
        Send(cmd);
        return _processOutput.ReadToEnd();
    }
}
