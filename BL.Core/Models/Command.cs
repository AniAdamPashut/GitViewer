using BL.Core.Models.Flags;
using System.Text;
using System.Text.Json.Serialization;

namespace BL.Core.Models;

[JsonSerializable(typeof(Command))]
public record Command
{
    [JsonPropertyName("name")]
    public string Name { get; }
    [JsonPropertyName("arguments")]
    public string[] Arguments { get; init; }
    [JsonPropertyName("flags")]
    public Flag[] Flags { get; init; }


    public Command(string name, string[] arguments, Flag[] flags)
    {
        Name = name;
        Flags = flags;
        Arguments = arguments;
    }

    public override string ToString()
    {
        StringBuilder sb = new();
        sb.Append(Name);
        foreach (var arg in Arguments)
        {
            sb.Append(' ');
            sb.Append(arg);
        }
        foreach (Flag flag in Flags)
        {
            sb.Append(' ');
            sb.Append(flag.Value);
        }
        return sb.ToString();
    }
}
