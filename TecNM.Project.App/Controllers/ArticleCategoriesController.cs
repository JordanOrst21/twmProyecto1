using Microsoft.AspNetCore.Mvc;
using TecNM.Project.App.Repositories.Interfaces;
using TecNM.Project.Core.Entities;
using TecNM.Project.Core.Http;

namespace TecNM.Project.App.Controllers;

[ApiController]
[Route(template: "api/[controller]")]
public class ArticleCategoriesController : ControllerBase
{
    private readonly IArticleCategoryRepository _articleCategoryRepository;

    public ArticleCategoriesController(IArticleCategoryRepository articleCategoryRepository)
    {
        _articleCategoryRepository = articleCategoryRepository;
    }

    [HttpGet]
    public async Task<ActionResult<Response<List<ArticleCategory>>>> GetAll()
    {
        var categories = await _articleCategoryRepository.GetAllAsync();
        var response = new Response<List<ArticleCategory>>();
        response.Data = categories;

        return Ok(response);
    }
    
    [HttpPost]
    public async Task<ActionResult<Response<ArticleCategory>>> Post([FromBody] ArticleCategory category)
    {
        category = await _articleCategoryRepository.SaveAsync(category);
        
        var response = new Response<ArticleCategory>();
        response.Data = category;
        
        return Created($"/api/[controller]/{category.Id}", category);
    }
    
    [HttpPut]
    public async Task<ActionResult<Response<ArticleCategory>>> Update([FromBody] ArticleCategory category)
    {
        var result = await _articleCategoryRepository.UpdateAsync(category);
        var response = new Response<ArticleCategory> { Data = result };

        return Ok(response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<ArticleCategory>>> GetById(int id)
    {
        var category = await _articleCategoryRepository.GetById(id);
        var response = new Response<ArticleCategory>();
        response.Data = category;

        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<ArticleCategory>>> Delete(int id)
    {
        var result = await _articleCategoryRepository.DeleteAsync(id);
        var response = new Response<ArticleCategory>();

        return Ok(response.Data);
    }
}