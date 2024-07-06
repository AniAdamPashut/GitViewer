using BL.Builtins;
using BL.Core.Models;
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

var config = JsonSerializer.Deserialize<CommandConfig>(fs);

GitExecutable git = new(GIT_EXE_PATH, logger, psi);

var fetcher = new CommitFetcher(config.GetCommits, git);
var commits = fetcher.Fetch();

Console.WriteLine(commits);
Console.ReadKey();