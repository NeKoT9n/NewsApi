namespace NewsApi.Domain.Models;

public class News
{
    public long Id { get; }
    public string Title { get; }
    public string Content { get; }
    public DateTime PublishedAt { get; } 
    public Category Category { get; set; }
    public Sentiment Sentiment { get; private set; }
    public IReadOnlyCollection<Rating> Ratings { get; }
    
    private News(
        long id,
        string title,
        string content,
        Category category,
        IReadOnlyCollection<Rating> ratings,
        Sentiment sentiment,
        DateTime publishedAt)
    {
        Id = id;
        Title = title;
        Content = content;
        Category = category;
        PublishedAt = publishedAt;
        Ratings = ratings;
        Sentiment = sentiment;
    }

    public static News Create(
        long id,
        string title,
        string content,
        Category? category,
        IReadOnlyCollection<Rating> ratings,
        Sentiment? sentiment,
        DateTime publishedAt)
    {
        //TODO: Validate parameters
        
        return new News(id, title, content, category, ratings, sentiment, publishedAt);
    }
    
    public static News Create(
        string title,
        string content,
        Category category
        )
    {
        return Create(0, title, content, category, [], null, DateTime.UtcNow);
    }
    
    
}