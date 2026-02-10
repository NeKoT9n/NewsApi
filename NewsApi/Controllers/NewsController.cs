using Microsoft.AspNetCore.Mvc;
using NewsApi.Application.Dto;
using NewsApi.Domain.Abstractions;
using NewsApi.Domain.Models;
using NewsApi.Dtos;

namespace NewsApi.Controllers;

[ApiController]
[Route("news")]
public class NewsController(INewsRepository repository) : ControllerBase
{
    
    [HttpGet("{id:long}")]
    public async Task<ActionResult<NewsWithCategoriesDto>> GetNewsWithCategories(long id)
    {

        var model = await repository.GetNewsWithCategoriesById(id);

        var response = new NewsWithCategoriesDto(
            model.Title,
            model.Content,
            model.Categories
                .Select(c => new CategoryDto(c.Name))
                .ToList());
        
        return Ok(response);
    }
    
    [HttpGet("category/{categoryId:int}")]
    public async Task<ActionResult<NewsDto>> GetNewsByCategory(int categoryId)
    {

        var model = await repository.GetNewsByCategory(categoryId);

        var response = model.Select(n => new NewsDto(
            n.Title,
            n.Content));
        
        return Ok(response);
    }
    
    [HttpPost("new")]
    public async Task<ActionResult<long>> AddNews([FromBody] CreateNewsRequest request)
    {

        var categories = new List<Category>();
        
        foreach (var categoryId in request.CategoriesId)
            categories.Add(Category.Create(categoryId));

        var newsToCreate = News.Create(request.Title, request.Content, categories);
          
        var response = await repository.AddNews(newsToCreate);
            
        return Ok(response);
    }
    

}