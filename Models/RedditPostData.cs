namespace BonusNotifier.Application.Models;

[Serializable]
public class RedditPostData
{
    public string Title { get; set; } = default!;
    public double Created { get; set; }
    public string Permalink { get; set; } = default!;
}