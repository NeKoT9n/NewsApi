using NewsApi.Domain.Models;

namespace NewsApi.DataAccess.Entities;

public class NewsEntity
{
    public long Id { get; init; }
    public string Title { get; init; } = string.Empty;
    public string Content { get; init; } = string.Empty;
    public DateTime PublishedAt { get; init; } = DateTime.UtcNow;
    public ICollection<CategoryEntity> Categories { get; init; } = [];
    public SentimentEntity? Sentiment { get; init; }
    public ICollection<RatingEntity> Ratings { get; init; } = [];
    
}