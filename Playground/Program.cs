using BL.Builtins;

using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Text.Json;

using ILoggerFactory factory = LoggerFactory.Create(builder =>
{
    builder.AddConsole();
});
ILogger logger = factory.CreateLogger("GitViewer");

const string GIT_EXE_PATH = @"C:\Program Files\Git\bin\";

ProcessStartInfo psi = new()
{
    WorkingDirectory = @"C:\Users\mineb\Desktop\code\GitViewer",
};

using FileStream fs = new("config.json", FileMode.Open);

var config = JsonSerializer.Deserialize<CommandConfig>(fs);

GitExecutable git = new(GIT_EXE_PATH, logger, psi);

var commitFetcher = new CommitFetcher(config.FetchCommitsCommand, git);
var commits = commitFetcher.Fetch();
foreach (var commit in commits)
{
    Console.WriteLine(commit.Display);
}

var fileFetcher = new FileFetcher(config.FetchFilesCommand, git);
foreach (var commit in commits)
{
    var files = fileFetcher.Fetch(commit);
    foreach (var file in files)
    {
        Console.WriteLine(file);
    }
    Console.WriteLine("################################");
}

Console.ReadKey();