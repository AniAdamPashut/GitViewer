using BL.Core;
using BL.Builtins;

using Microsoft.Extensions.Logging;
using System.Diagnostics;
using BL.Core.Flags;


using ILoggerFactory factory = LoggerFactory.Create(builder => {
    builder.AddConsole();
});
ILogger logger = factory.CreateLogger("GitViewer");

const string gitExePath = @"C:\Program Files\Git\bin\bash.exe";

ProcessStartInfo psi = new()
{
    WorkingDirectory = @"C:\Users\mineb\Desktop\code\GitViewer",
    FileName = gitExePath,
};

Command echoHelloWorld = new("echo Hello World", new());

Command bashExe = new CommandBuilder("", new()
{
    "c",
})
    .AddFlag(new ValuedShortFlag("c", $"\"{echoHelloWorld}\""))
    .Build();

Console.WriteLine(bashExe.ToString());

GitStream git = new(logger, psi);
string output = git.Do(bashExe.ToString());
Console.WriteLine(output);
Console.ReadKey();