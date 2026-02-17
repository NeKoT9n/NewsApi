using NewsApi.Application.Dto;
using NewsApi.Application.Mappers;
using NewsApi.DataAccess.Entities;

namespace NewsApi.Application.Extensions;

public static class NewsProjections 
{
    public static IQueryable<NewsWithCategoriesDto> ProjectToNewsWithCategoriesDto(
        this IQueryable<NewsEntity> query, NewsMapper mapper) 
        => mapper.ProjectToDto(query);
}