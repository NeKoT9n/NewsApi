namespace NewsApi.Application.Dto;

public record NewsWithCategoriesDto(string Title, string Content, string Category);
public record NewsDto(string Title, string Content);
