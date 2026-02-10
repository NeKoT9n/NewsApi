namespace NewsApi.Domain.Models;

public class News
{
    public long Id { get; }
    public string Title { get; }
    public string Content { get; }
    public DateTime PublishedAt { get; } 
    public IReadOnlyCollection<Category> Categories { get; }
    public IReadOnlyCollection<Rating> Ratings { get; }
    public Sentiment Sentiment { get; set; }
    
    private News(
        long id,
        string title,
        string content,
        IReadOnlyCollection<Category> categories,
        IReadOnlyCollection<Rating> ratings,
        Sentiment sentiment,
        DateTime publishedAt)
    {
        Id = id;
        Title = title;
        Content = content;
        Categories = categories;
        PublishedAt = publishedAt;
        Ratings = ratings;
        Sentiment = sentiment;
    }

    public static News Create(
        long id,
        string title,
        string content,
        IReadOnlyCollection<Category> categories,
        IReadOnlyCollection<Rating> ratings,
        Sentiment sentiment,
        DateTime publishedAt)
    {
        //TODO: Validate parameters
        
        return new News(id, title, content, categories, ratings, sentiment, publishedAt);
    }
    
    public static News Create(
        string title,
        string content,
        IReadOnlyCollection<Category> categories
        )
    {
        return Create(-1, title, content, categories, [], null, DateTime.UtcNow);
    }
    
    
}