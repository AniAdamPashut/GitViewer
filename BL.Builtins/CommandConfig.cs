using BL.Core;
using System.Text.Json.Serialization;

namespace BL.Builtins;

[JsonSerializable(typeof(CommandConfig))]
public record CommandConfig
{
    [JsonPropertyName("commitListCommand")]
    public Command CommitList { get; init; }
    [JsonPropertyName("fileListCommand")]
    public Command FilesList { get; init; }
}

