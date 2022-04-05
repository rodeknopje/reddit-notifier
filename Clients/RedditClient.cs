using System.Text.Json;
using System.Text.Json.Nodes;
using BonusNotifier.Application.Models;

namespace BonusNotifier.Application.Clients;

public class RedditClient
{
    private readonly HttpClient _httpClient;

    private const string BaseUri = "https://www.reddit.com/r/";
    public RedditClient()
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri(BaseUri)
        };
    }

    public async Task<List<RedditPost>> GetRecentPostsAsync()
    {
        var json = await _httpClient.GetStringAsync("persoonlijkebonus/new.json");
        
        var redditData = JsonNode.Parse(json);

        if (redditData is null)
        {
            return new List<RedditPost>();
        }

        var postsJson = redditData["data"]!["children"]!.ToJsonString();

        var posts = JsonSerializer.Deserialize<List<RedditPost>>(postsJson, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
        
        return posts ?? new List<RedditPost>();
    }
}