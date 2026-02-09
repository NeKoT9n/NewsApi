using NewsApi.Domain.Models;

namespace NewsApi.DataAccess.Entities;

public class NewsEntity
{
    public long Id { get; init; }
    
    public string Title { get; init; } = string.Empty;
    
    public string Content { get; init; } = string.Empty;
    
    public ICollection<CategoryEntity> Categories { get; init; } = new List<CategoryEntity>();
    
    public Sentiment Sentiment { get; init; } = Sentiment.Neutral;
    
    public float SentimentScore { get; init; } = 0;
    
    public DateTime PublishedAt { get; init; } = DateTime.UtcNow;
}