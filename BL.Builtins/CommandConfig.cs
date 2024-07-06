using BL.Core.Models;
using System.Text.Json.Serialization;

namespace BL.Builtins;

[JsonSerializable(typeof(CommandConfig))]
public record CommandConfig
{
    [JsonPropertyName("commitListCommand")]
    public Command GetCommits { get; init; }
    [JsonPropertyName("fileListCommand")]
    public Command GetFiles { get; init; }
}

