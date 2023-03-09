using Microsoft.AspNetCore.Mvc;
using TecNM.Project.App.Repositories.Interfaces;
using TecNM.Project.Core.Entities;
using TecNM.Project.Core.Http;

namespace TecNM.Project.App.Controllers;

[ApiController]
[Route(template: "api/[controller]")]
public class ArticleSubCategoriesController : ControllerBase
{
    private readonly IArticleSubCategoryRepository _articleSubCategoryRepository;

    public ArticleSubCategoriesController(IArticleSubCategoryRepository articleSubCategoryRepository)
    {
        _articleSubCategoryRepository = articleSubCategoryRepository;
    }

    [HttpGet]
    public async Task<ActionResult<Response<List<ArticleSubCategory>>>> GetAll()
    {
        var subcategories = await _articleSubCategoryRepository.GetAllAsync();
        var response = new Response<List<ArticleSubCategory>>();
        response.Data = subcategories;

        return Ok(response);
    }
    
    [HttpPost]
    public async Task<ActionResult<Response<ArticleSubCategory>>> Post([FromBody] ArticleSubCategory subcategory)
    {
        subcategory = await _articleSubCategoryRepository.SaveAsync(subcategory);
        
        var response = new Response<ArticleSubCategory>();
        response.Data = subcategory;
        
        return Created($"/api/[controller]/{subcategory.Id}", subcategory);
    }
    
    [HttpPut]
    public async Task<ActionResult<Response<ArticleSubCategory>>> Update([FromBody] ArticleSubCategory subcategory)
    {
        var result = await _articleSubCategoryRepository.UpdateAsync(subcategory);
        var response = new Response<ArticleSubCategory> { Data = result };

        return Ok(response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<ArticleSubCategory>>> GetById(int id)
    {
        var subcategory = await _articleSubCategoryRepository.GetById(id);
        var response = new Response<ArticleSubCategory>();
        response.Data = subcategory;

        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<ArticleSubCategory>>> Delete(int id)
    {
        var result = await _articleSubCategoryRepository.DeleteAsync(id);
        var response = new Response<ArticleSubCategory>();

        return Ok(response.Data);
    }
}