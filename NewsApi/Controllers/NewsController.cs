using MediatR;
using Microsoft.AspNetCore.Mvc;
using NewsApi.Application.Dto;
using NewsApi.Application.Features.Commands;
using NewsApi.Application.Features.Queries;

namespace NewsApi.Controllers;

[ApiController]
[Route("news")]
public class NewsController(IMediator mediator) : ControllerBase
{
    
    [HttpGet("{id:long}")]
    public async Task<ActionResult<NewsWithCategoriesDto>> GetNewsWithCategories(long id)
    {
        var result = await mediator.Send(new GetNewsByIdQuery(id));
        
        if(result.IsFailure)
            return BadRequest(result.Error);
        
        return Ok(result.Value);
        
    }
    
    [HttpGet("category/{categoryId:int}")]
    public async Task<ActionResult> GetNewsByCategory(int categoryId)
    {
        return Ok();
    }
    
    [HttpPost("new")]
    public async Task<ActionResult<long>> AddNews([FromBody] CreateNewsCommand request)
    {
        var result = await mediator.Send(request);
        return Ok(result.Value);
    }
    

}