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

Command gitReflogShow = new CommandBuilder("reflog")
    .AddArgument("show")
    .AddFlag(new ValuedLongFlag("pretty", "%h~%cn~%ch~%cI~%s"))
    .Build();

var json = JsonSerializer.Deserialize<CommandConfig>(fs);
Console.WriteLine(json);
Console.WriteLine(json.CommitList);
Console.WriteLine(json.FilesList);


GitExecutable git = new(GIT_EXE_PATH, logger, psi);
string output = git.Do(gitReflogShow);
Console.WriteLine(output);
Console.ReadKey();