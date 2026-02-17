using NewsApi.Application.Dto;
using NewsApi.DataAccess.Entities;
using NewsApi.Domain.Models;
using Riok.Mapperly.Abstractions;

namespace NewsApi.Application.Mappers;

[Mapper]
public partial class NewsMapper
{
    public News EntityToDomain(NewsEntity entity) => 
        News.Create(
            entity.Id,
            entity.Title,
            entity.Content,
            entity.Category != null ? MapCategory(entity.Category) : null,
            MapRatings(entity.Ratings),
            entity.Sentiment != null ? MapSentiment(entity.Sentiment) : null,
            entity.PublishedAt
        );

    public NewsEntity DomainToEntity(News domain) => new NewsEntity()
    {
        Title =  domain.Title,
        Content = domain.Content,
        PublishedAt = domain.PublishedAt,
        Category = MapCategory(domain.Category),
    };
    
    public partial IQueryable<NewsWithCategoriesDto> ProjectToDto(IQueryable<NewsEntity> query);
    
    private CategoryEntity MapCategory(Category domain) => new()
    {
        Id = domain.Id,
        Name = domain.Name
    };
    
    private Category MapCategory(CategoryEntity entity) => 
        Category.Create(entity.Id, entity.Name);

    private Rating MapRating(RatingEntity entity) => 
        Rating.Create(entity.Id, entity.Value);

    private Sentiment MapSentiment(SentimentEntity entity) => 
        Sentiment.Create(entity.Type, entity.Score);
    
    private partial IReadOnlyCollection<Rating> MapRatings(IEnumerable<RatingEntity> entities);
    
    private string MapCategoryToString(CategoryEntity category) => category.Name;
}