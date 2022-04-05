using System.Text.Json.Serialization;

namespace BonusNotifier.Application.Models;

[Serializable]
public class DiscordBody
{
    [JsonPropertyName("content")]
    public string Content { get; set; }

    public DiscordBody(string content)
    {
        Content = content;
    }
}