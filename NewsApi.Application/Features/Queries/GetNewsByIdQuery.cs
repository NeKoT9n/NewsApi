using MediatR;
using Microsoft.EntityFrameworkCore;
using NewsApi.Application.Dto;
using NewsApi.Application.Extensions;
using NewsApi.Application.Mappers;
using NewsApi.DataAccess;
using NewsApi.Domain.Common.Validation;

namespace NewsApi.Application.Features.Queries;

public record GetNewsByIdQuery(long Id) : IRequest<Result<NewsWithCategoriesDto, Error>>;

public class GetNewsByIdHandler(NewsDbContext context, NewsMapper mapper) : IRequestHandler<GetNewsByIdQuery, Result<NewsWithCategoriesDto, Error>>
{
    public async Task<Result<NewsWithCategoriesDto, Error>> Handle(GetNewsByIdQuery request, CancellationToken ct)
    {
        var news = await context.News
            .Where(n => n.Id == request.Id)
            .ProjectToNewsWithCategoriesDto(mapper)
            .FirstOrDefaultAsync(ct);

        if (news == null)
            return Errors.General.NotFound(request.Id);
        
        return news;
    }
}