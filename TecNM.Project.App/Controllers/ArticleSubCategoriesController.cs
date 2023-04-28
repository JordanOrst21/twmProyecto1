using Microsoft.AspNetCore.Mvc;
using TecNM.Project.App.Repositories.Interfaces;
using TecNM.Project.App.Services.Interfaces;
using TecNM.Project.Core.Dto;
using TecNM.Project.Core.Entities;
using TecNM.Project.Core.Http;

namespace TecNM.Project.App.Controllers;

[ApiController]
[Route(template: "api/[controller]")]
public class ArticleSubCategoriesController : ControllerBase
{
    
    private readonly IArticleSubCategoryService _articleSubCategoryService;
    
     public ArticleSubCategoriesController(IArticleSubCategoryService articleSubCategoryService)
     {
         _articleSubCategoryService = articleSubCategoryService;
     }

    [HttpGet]
    public async Task<ActionResult<Response<List<ArticleSubCategoryDto>>>> GetAll()
    {
        
        var response = new Response<List<ArticleSubCategoryDto>>
        {
            Data = await _articleSubCategoryService.GetAllAsync()
        };

        return Ok(response);
    }
    [HttpPost]
    public async Task<ActionResult<Response<ArticleSubCategoryDto>>> Post([FromBody] ArticleSubCategoryDto categoryDto)
    {
        if (string.IsNullOrWhiteSpace(categoryDto.Name))
        {
            return BadRequest("The 'Name' field cannot be empty, null, or contain only white spaces.");
        }
        
        if (categoryDto.Category_id == null || categoryDto.Category_id == 0 )
        {
            return BadRequest("The value of 'Category_id' must be a valid integer number.");
        }

        var response = new Response<ArticleSubCategoryDto>
        {
        Data = await _articleSubCategoryService.SaveAsync(categoryDto)
        };
        
        return Created($"/api/[controller]/{response.Data.Id}", response);
    }
    
    [HttpPut]
    public async Task<ActionResult<Response<ArticleSubCategoryDto>>> Update([FromBody] ArticleSubCategoryDto categoryDto)
    {
        if (string.IsNullOrWhiteSpace(categoryDto.Name))
        {
            return BadRequest("The 'Name' field cannot be empty, null, or contain only white spaces.");
        }
        
        if (categoryDto.Id == null || categoryDto.Id == 0 )
        {
            return BadRequest("The value of 'Id' must be a valid integer number.");
        }
        
        if (categoryDto.Category_id == null || categoryDto.Category_id == 0 )
        {
            return BadRequest("The value of 'Category_id' must be a valid integer number.");
        }
        
        var response = new Response<ArticleSubCategoryDto>();
        if (!await _articleSubCategoryService.ArticleSubCategoryExist(categoryDto.Id))
        {
            response.Errors.Add("Article Category Not Found");
            return NotFound(response);
        }
    
        var updatedCategoryDto = await _articleSubCategoryService.UpdateAsync(categoryDto);
        response.Data = updatedCategoryDto;
    
        return Ok(response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<ArticleSubCategoryDto>>> GetById(int id)
    {
        var response = new Response<ArticleSubCategoryDto>();
        if (!await _articleSubCategoryService.ArticleSubCategoryExist(id))
        {
            response.Errors.Add("Article category not found");
            return NotFound(response);
        }

        response.Data = await _articleSubCategoryService.GetById(id);
        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:int}")]

    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var response = new Response<bool>();
        var result = await _articleSubCategoryService.DeleteAsync(id);
        response.Data = result;

        return Ok(response);
    }
}
    
    // private readonly IArticleSubCategoryRepository _articleSubCategoryRepository;
    //
    // public ArticleSubCategoriesController(IArticleSubCategoryRepository articleSubCategoryRepository)
    // {
    //     _articleSubCategoryRepository = articleSubCategoryRepository;
    // }
    //
    // [HttpGet]
    // public async Task<ActionResult<Response<List<ArticleSubCategory>>>> GetAll()
    // {
    //     var subcategories = await _articleSubCategoryRepository.GetAllAsync();
    //     var response = new Response<List<ArticleSubCategory>>();
    //     response.Data = subcategories;
    //
    //     return Ok(response);
    // }
    //
    // [HttpPost]
    // public async Task<ActionResult<Response<ArticleSubCategory>>> Post([FromBody] ArticleSubCategory subcategory)
    // {
    //     if (string.IsNullOrEmpty(subcategory.Name))
    //     {
    //         return BadRequest("El nombre de la subcategoría no puede estar vacío o nulo.");
    //     }
    //     
    //     if (subcategory.IsDeleted)
    //     {
    //         return BadRequest("No se puede crear una subcategoría con isDeleted en true.");
    //     }
    //     
    //     
    //     subcategory = await _articleSubCategoryRepository.SaveAsync(subcategory);
    //     
    //     var response = new Response<ArticleSubCategory>();
    //     response.Data = subcategory;
    //     
    //     return Created($"/api/[controller]/{subcategory.Id}", subcategory);
    // }
    //
    // [HttpPut]
    // public async Task<ActionResult<Response<ArticleSubCategory>>> Update([FromBody] ArticleSubCategory subcategory)
    // {
    //     var result = await _articleSubCategoryRepository.UpdateAsync(subcategory);
    //     var response = new Response<ArticleSubCategory> { Data = result };
    //
    //     return Ok(response);
    // }
    //
    // [HttpGet]
    // [Route("{id:int}")]
    // public async Task<ActionResult<Response<ArticleSubCategory>>> GetById(int id)
    // {
    //     var subcategory = await _articleSubCategoryRepository.GetById(id);
    //     var response = new Response<ArticleSubCategory>();
    //     response.Data = subcategory;
    //
    //     return Ok(response);
    // }
    //
    // [HttpDelete]
    // [Route("{id:int}")]
    // public async Task<ActionResult<Response<ArticleSubCategory>>> Delete(int id)
    // {
    //     var result = await _articleSubCategoryRepository.DeleteAsync(id);
    //     var response = new Response<ArticleSubCategory>();
    //
    //     return Ok(response.Data);
    // }
