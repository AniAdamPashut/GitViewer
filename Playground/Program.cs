using BL.Core;
using Microsoft.Extensions.Logging;

using ILoggerFactory factory = LoggerFactory.Create(builder => {
    builder.AddConsole();
});
ILogger logger = factory.CreateLogger("GitViewer"   );

GitStream git = new(logger);
git.OpenGitWindow();