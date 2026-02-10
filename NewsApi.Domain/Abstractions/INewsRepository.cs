using NewsApi.Domain.Models;

namespace NewsApi.Domain.Abstractions;

public interface INewsRepository
{
    public Task<News> GetNewsById(long id);
    public Task<News> GetNewsWithCategoriesById(long id);
    public Task<long> AddNews(News model);
    public Task<IReadOnlyList<News>> GetNewsByCategory(int categoryId);
}