namespace NewsApi.DataAccess.Entities;

public class CategoryEntity
{
    public long Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public ICollection<NewsEntity> News { get; init; } = [];
}