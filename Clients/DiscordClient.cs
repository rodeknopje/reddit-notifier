using System.Text;
using System.Text.Json;
using BonusNotifier.Application.Models;

namespace BonusNotifier.Application.Clients;

public class DiscordClient
{
    private readonly HttpClient _client;

    public DiscordClient(string url)
    {
        _client = new HttpClient
        {
            BaseAddress = new Uri(url)
        };
    }

    public async Task SendMessageAsync(string message)
    {
        var body = JsonSerializer.Serialize(new DiscordBody(message));
        
        var msg = new StringContent(body, Encoding.UTF8, "application/json");
        
        await _client.PostAsync(string.Empty, msg);
    }
}