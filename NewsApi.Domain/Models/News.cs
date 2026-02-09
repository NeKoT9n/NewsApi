namespace NewsApi.Domain.Models;

public class News
{
    public long Id { get; }
    public string Title { get; }
    public string Content { get; }
    public IReadOnlyCollection<Category> Categories { get; }
    public Sentiment Sentiment { get; }
    public float SentimentScore { get; }
    public DateTime PublishedAt { get; } 
    
    private News(
        long id,
        string title,
        string content,
        IReadOnlyCollection<Category> categories,
        DateTime publishedAt, float sentimentScore, Sentiment sentiment)
    {
        Id = id;
        Title = title;
        Content = content;
        Categories = categories;
        PublishedAt = publishedAt;
        SentimentScore = sentimentScore;
        Sentiment = sentiment;
    }

    public static News Create(
        long id,
        string title,
        string content,
        IReadOnlyCollection<Category> categories,
        DateTime publishedAt,
        Sentiment sentiment,
        float sentimentScore)
    {
        //TODO: Validate parameters
        
        return new News(id, title, content, categories, publishedAt, sentimentScore, sentiment);
    }
    
    
}