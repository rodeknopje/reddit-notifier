using BonusNotifier.Application.Clients;

var discordUrl = Environment.GetEnvironmentVariable("discord_url");

if (discordUrl is null)
{
    throw new NullReferenceException("no discord url :(");
}

var discordClient = new DiscordClient(discordUrl);
var redditClient = new RedditClient();

await discordClient.SendMessageAsync("Bot started :robot:");

var previousCheckDate = DateTime.Now.Subtract(TimeSpan.FromDays(1));

while (true)
{
    var posts = await redditClient.GetRecentPostsAsync();
    
    foreach (var post in posts)
    {
        var postDate = DateTimeOffset.FromUnixTimeSeconds((long) post.Data.Created);

        if (previousCheckDate <= postDate)
        {
            if (post.Data.Title.ToLower().Contains("gratis"))
            {
                await discordClient.SendMessageAsync($"https://www.reddit.com{post.Data.Permalink}");
            }
        }
    }
    
    previousCheckDate = DateTime.Now;
    
    await Task.Delay(TimeSpan.FromMinutes(5));
}