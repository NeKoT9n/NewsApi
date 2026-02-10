namespace NewsApi.Application.Dto;

public record NewsWithCategoriesDto(string Title, string Content, ICollection<CategoryDto> Categories);
public record NewsDto(string Title, string Content);
public record CategoryDto(string Name);