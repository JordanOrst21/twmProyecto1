using Microsoft.AspNetCore.Mvc;
using TecNM.Project.App.Repositories.Interfaces;
using TecNM.Project.Core.Entities;
using TecNM.Project.Core.Http;

namespace TecNM.Project.App.Controllers;

[ApiController]
[Route(template: "api/[controller]")]
public class ArticleController : ControllerBase
{
    private readonly IArticleRepository _articleRepository;

    public ArticleController(IArticleRepository articleRepository)
    {
        _articleRepository = articleRepository;
    }

    [HttpGet]
    public async Task<ActionResult<Response<List<Article>>>> GetAll()
    {
        var categories = await _articleRepository.GetAllAsync();
        var response = new Response<List<Article>>();
        response.Data = categories;

        return Ok(response);
    }
    
    [HttpPost]
    public async Task<ActionResult<Response<Article>>> Post([FromBody] Article category)
    {
        category = await _articleRepository.SaveAsync(category);
        
        var response = new Response<Article>();
        response.Data = category;
        
        return Created($"/api/[controller]/{category.Id}", category);
    }
    
    [HttpPut]
    public async Task<ActionResult<Response<Article>>> Update([FromBody] Article category)
    {
        var result = await _articleRepository.UpdateAsync(category);
        var response = new Response<Article> { Data = result };

        return Ok(response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<Article>>> GetById(int id)
    {
        var category = await _articleRepository.GetById(id);
        var response = new Response<Article>();
        response.Data = category;

        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<Article>>> Delete(int id)
    {
        var result = await _articleRepository.DeleteAsync(id);
        var response = new Response<Article>();

        return Ok(response.Data);
    }
}