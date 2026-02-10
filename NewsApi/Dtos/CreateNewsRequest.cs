namespace NewsApi.Dtos;

public record CreateNewsRequest(string Title, string Content, IReadOnlyList<int> CategoriesId);