using BL.Core.Models;
using System.Text.Json.Serialization;

namespace BL.Builtins;

[JsonSerializable(typeof(CommandConfig))]
public record CommandConfig
{
    [JsonPropertyName("commitListCommand")]
    public Command FetchCommitsCommand { get; init; }
    [JsonPropertyName("fileListCommand")]
    public Command FetchFilesCommand { get; init; }
}

