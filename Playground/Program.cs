using BL.Core;
using BL.Core.Flags;
using BL.Builtins;

using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Text.Json;


using ILoggerFactory factory = LoggerFactory.Create(builder => {
    builder.AddConsole();
});
ILogger logger = factory.CreateLogger("GitViewer");

const string GIT_EXE_PATH = @"C:\Program Files\Git\bin\";

ProcessStartInfo psi = new()
{
    WorkingDirectory = @"C:\Users\mineb\Desktop\code\GitViewer",
};

using FileStream fs = new FileStream("config.json", FileMode.Open);

var json = JsonSerializer.Deserialize<CommandConfig>(fs);
Console.WriteLine(json);
Console.WriteLine(json.CommitList);
Console.WriteLine(json.FilesList);


GitExecutable git = new(GIT_EXE_PATH, logger, psi);
string output = git.Do(json.CommitList);
Console.WriteLine(output);
Console.WriteLine();
Console.WriteLine(git.Do(json.FilesList));
Console.ReadKey();