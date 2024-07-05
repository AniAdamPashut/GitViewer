using BL.Core;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

using ILoggerFactory factory = LoggerFactory.Create(builder => {
    builder.AddConsole();
});
ILogger logger = factory.CreateLogger("GitViewer");
string gitExePath = @"C:\Program Files\Git\bin\git.exe";
ProcessStartInfo psi = new()
{
    FileName = gitExePath,
};
GitStream git = new(logger, psi);
string output = git.Do("ls-files");
Console.WriteLine(output);
Console.ReadKey();