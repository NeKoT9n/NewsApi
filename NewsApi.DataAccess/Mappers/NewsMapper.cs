using NewsApi.DataAccess.Entities;
using NewsApi.Domain.Models;

namespace NewsApi.DataAccess.Mappers;

public static class NewsMapper
{
    public static News ToDomain(NewsEntity entity)
    {
        return News.Create(
            entity.Id,
            entity.Title,
            entity.Content,
            entity.Categories.Select(CategoryMapper.ToDomain).ToList(),
            entity.Ratings.Select(RatingMapper.ToDomain).ToList(),
            entity.Sentiment == null ? null :SentimentMapper.ToDomain(entity.Sentiment),
            entity.PublishedAt);
    }
    
}

public static class CategoryMapper 
{
    public static Category ToDomain(CategoryEntity entity)
    {
        return Category.Create(
            entity.Id,
            entity.Name);
    }
}

public static class RatingMapper 
{
    public static Rating ToDomain(RatingEntity entity)
    {
        return Rating.Create(
            entity.Id,
            entity.Value);
    }
}

public static class SentimentMapper 
{
    public static Sentiment ToDomain(SentimentEntity entity)
    {
        return Sentiment.Create(
            entity.Type,
            entity.Score);
    }
}