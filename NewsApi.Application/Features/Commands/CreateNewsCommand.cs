using MediatR;
using Microsoft.EntityFrameworkCore;
using NewsApi.Application.Mappers;
using NewsApi.DataAccess;
using NewsApi.DataAccess.Entities;
using NewsApi.Domain.Common.Validation;
using NewsApi.Domain.Models;

namespace NewsApi.Application.Features.Commands;

public record CreateNewsCommand(string Title, string Content, int CategoryId) 
    : IRequest<Result<long, Error>>;


public class CreateNewsHandler(NewsDbContext context, NewsMapper mapper) 
    : IRequestHandler<CreateNewsCommand, Result<long, Error>>
{
    public async Task<Result<long, Error>> Handle(CreateNewsCommand request, CancellationToken ct)
    {
        var category = Category.Create(request.CategoryId);
        
        var news = News.Create(request.Title, request.Content, category);
        
        var entity = new NewsEntity
        {
            Title = news.Title,
            Content = news.Content,
            PublishedAt = news.PublishedAt
        };

        var categoryEntry = context.Categories.Attach(new CategoryEntity { Id = category.Id });
        entity.Category = categoryEntry.Entity;
            
        try 
        {
            await context.News.AddAsync(entity, ct);
            await context.SaveChangesAsync(ct);
        
            return entity.Id;
        }
        catch (DbUpdateException)
        {
            return Errors.General.ValueIsInvalid("CategoryId");
        }
    }
}