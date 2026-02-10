using Microsoft.EntityFrameworkCore;
using NewsApi.DataAccess.Entities;
using NewsApi.DataAccess.Mappers;
using NewsApi.Domain.Abstractions;
using NewsApi.Domain.Models;

namespace NewsApi.DataAccess.Repositories;

public class NewsRepository(NewsDbContext context) : INewsRepository
{
    public async Task<News> GetNewsById(long id)
    {
        var entity = await context.News
                         .AsNoTracking()
                         .FirstOrDefaultAsync(x => x.Id == id)
            ?? throw new KeyNotFoundException($"News with id {id} not found");

        return NewsMapper.ToDomain(entity);
    }
    
    public async Task<News> GetNewsWithCategoriesById(long id)
    {
        var entity = await context.News
                         .AsNoTracking()
                         .Include(x => x.Categories)
                         .FirstOrDefaultAsync(x => x.Id == id)
                     ?? throw new KeyNotFoundException($"News with id {id} not found");

        return NewsMapper.ToDomain(entity);
    }

    public async Task<IReadOnlyList<News>> GetNewsByCategory(int categoryId)
    {
        var entities = await context.News
                           .AsNoTracking()
                           .Where(x => x.Categories.Any(c => c.Id == categoryId))
                           .ToListAsync()
                     ?? throw new KeyNotFoundException($"News category with id {categoryId} not found");

        return entities.Select(NewsMapper.ToDomain).ToList();
    }

    public async Task<long> AddNews(News model)
    {
        var entity = new NewsEntity
        {
            Title = model.Title,
            Content = model.Content,
            PublishedAt = model.PublishedAt
        };
        
        foreach (var category in model.Categories)
        {
            var categoryEntry = context.Categories.Attach(new CategoryEntity { Id = category.Id });
            entity.Categories.Add(categoryEntry.Entity);
        }
        
        await context.News.AddAsync(entity);
        await context.SaveChangesAsync();
        
        return entity.Id;
    }
}
