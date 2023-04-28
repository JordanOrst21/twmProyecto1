using Microsoft.AspNetCore.Mvc;
using TecNM.Project.App.Repositories.Interfaces;
using TecNM.Project.App.Services.Interfaces;
using TecNM.Project.Core.Dto;
using TecNM.Project.Core.Entities;
using TecNM.Project.Core.Http;

namespace TecNM.Project.App.Controllers;

[ApiController]
[Route(template: "api/[controller]")]
public class ArticleController : ControllerBase
{
    // private readonly IArticleRepository _articleRepository;
    //
    // public ArticleController(IArticleRepository articleRepository)
    // {
    //     _articleRepository = articleRepository;
    // }
    //
    // [HttpGet]
    // public async Task<ActionResult<Response<List<Article>>>> GetAll()
    // {
    //     var subcategories = await _articleRepository.GetAllAsync();
    //     var response = new Response<List<Article>>();
    //     response.Data = subcategories;
    //
    //     return Ok(response);
    // }
    //
    // [HttpPost]
    // public async Task<ActionResult<Response<Article>>> Post([FromBody] Article subcategory)
    // {
    //     subcategory = await _articleRepository.SaveAsync(subcategory);
    //     
    //     var response = new Response<Article>();
    //     response.Data = subcategory;
    //     
    //     return Created($"/api/[controller]/{subcategory.Id}", subcategory);
    // }
    //
    // [HttpPut]
    // public async Task<ActionResult<Response<Article>>> Update([FromBody] Article subcategory)
    // {
    //     var result = await _articleRepository.UpdateAsync(subcategory);
    //     var response = new Response<Article> { Data = result };
    //
    //     return Ok(response);
    // }
    //
    // [HttpGet]
    // [Route("{id:int}")]
    // public async Task<ActionResult<Response<Article>>> GetById(int id)
    // {
    //     var subcategory = await _articleRepository.GetById(id);
    //     var response = new Response<Article>();
    //     response.Data = subcategory;
    //
    //     return Ok(response);
    // }
    //
    // [HttpDelete]
    // [Route("{id:int}")]
    // public async Task<ActionResult<Response<Article>>> Delete(int id)
    // {
    //     var result = await _articleRepository.DeleteAsync(id);
    //     var response = new Response<Article>();
    //
    //     return Ok(response.Data);
    // }
    
    private readonly IArticleService _articleService;

    public ArticleController(IArticleService articleService)
    {
        _articleService = articleService;
    }
    
    
    [HttpGet]
    public async Task<ActionResult<Response<List<ArticleDto>>>> GetAll()
    {
        var response = new Response<List<ArticleDto>>
        {
            Data = await _articleService.GetAllAsync()
        };
    
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<ActionResult<Response<ArticleDto>>> Post([FromBody] ArticleDto categoryDto)
    {
        if (string.IsNullOrWhiteSpace(categoryDto.Information))
        {
            return BadRequest("The 'information' field cannot be empty, null, or contain only white spaces.");
        }
        
        if (categoryDto.Category_id == null || categoryDto.Category_id == 0 )
        {
            return BadRequest("The value of 'Category_id' must be a valid integer number.");
        }

        var response = new Response<ArticleDto>
        {
            Data = await _articleService.SaveAsync(categoryDto)
        };
        
        return Created($"/api/[controller]/{response.Data.Id}", response);
    }
    
    [HttpPut]
    public async Task<ActionResult<Response<ArticleDto>>> Update([FromBody] ArticleDto categoryDto)
    {
        if (string.IsNullOrWhiteSpace(categoryDto.Information))
        {
            return BadRequest("The 'information' field cannot be empty, null, or contain only white spaces.");
        }
        
        if (categoryDto.Id == null || categoryDto.Id == 0 )
        {
            return BadRequest("The value of 'Id' must be a valid integer number.");
        }
        
        if (categoryDto.Category_id == null || categoryDto.Category_id == 0 )
        {
            return BadRequest("The value of 'Category_id' must be a valid integer number.");
        }
        
        var response = new Response<ArticleDto>();
        if (!await _articleService.ArticleExist(categoryDto.Id))
        {
            response.Errors.Add("Article Category Not Found");
            return NotFound(response);
        }
        
        var updatedCategoryDto = await _articleService.UpdateAsync(categoryDto);
        response.Data = updatedCategoryDto;
        
        return Ok(response);
    }
    
    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<ArticleDto>>> GetById(int id)
    {
        var response = new Response<ArticleDto>();
        if (!await _articleService.ArticleExist(id))
        {
            response.Errors.Add("Article category not found");
            return NotFound(response);
        }
    
        response.Data = await _articleService.GetById(id);
        return Ok(response);
    }
    
    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var response = new Response<bool>();
        var result = await _articleService.DeleteAsync(id);
        response.Data = result;
    
        return Ok(response);
    }
}