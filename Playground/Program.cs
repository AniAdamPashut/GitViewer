using BL.Core;
using BL.Builtins;

using Microsoft.Extensions.Logging;
using System.Diagnostics;
using BL.Core.Flags;


using ILoggerFactory factory = LoggerFactory.Create(builder => {
    builder.AddConsole();
});
ILogger logger = factory.CreateLogger("GitViewer");

const string GIT_EXE_PATH = @"C:\Program Files\Git\bin\";

ProcessStartInfo psi = new()
{
    WorkingDirectory = @"C:\Users\mineb\Desktop\code\GitViewer",
};

Command gitReflogShow = new CommandBuilder("add", [])
    .AddArgument(".")
    .Build();

GitExecutable git = new(GIT_EXE_PATH, logger, psi);
string output = git.Do(gitReflogShow);
Console.WriteLine(output);
Console.ReadKey();