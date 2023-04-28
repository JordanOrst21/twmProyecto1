using Microsoft.AspNetCore.Mvc;
using TecNM.Project.App.Repositories.Interfaces;
using TecNM.Project.App.Services.Interfaces;
using TecNM.Project.Core.Dto;
using TecNM.Project.Core.Entities;
using TecNM.Project.Core.Http;

namespace TecNM.Project.App.Controllers;

[ApiController]
[Route(template: "api/[controller]")]
public class ArticleCategoriesController : ControllerBase
{
    private readonly IArticleCategoryService _articleCategoryService;
    
     public ArticleCategoriesController(IArticleCategoryService articleCategoryService)
     {
         _articleCategoryService = articleCategoryService;
     }

    [HttpGet]
    public async Task<ActionResult<Response<List<ArticleCategoryDto>>>> GetAll()
    {
        
        var response = new Response<List<ArticleCategoryDto>>
        {
            Data = await _articleCategoryService.GetAllAsync()
        };

        return Ok(response);
    }
    [HttpPost]
    public async Task<ActionResult<Response<ArticleCategoryDto>>> Post([FromBody] ArticleCategoryDto categoryDto)
    {
        if (string.IsNullOrWhiteSpace(categoryDto.Name))
        {
            return BadRequest("The category name cannot be empty, null, or contain only white spaces.");
        }
        var response = new Response<ArticleCategoryDto>
        {
        Data = await _articleCategoryService.SaveAsync(categoryDto)
        };
        
        return Created($"/api/[controller]/{response.Data.Id}", response);
    }
    
    [HttpPut]
    public async Task<ActionResult<Response<ArticleCategoryDto>>> Update([FromBody] ArticleCategoryDto categoryDto)
    {
        if (string.IsNullOrWhiteSpace(categoryDto.Name))
        {
            return BadRequest("The category name cannot be empty, null, or contain only white spaces.");
        }
        
        if (categoryDto.Id == null || categoryDto.Id == 0 )
        {
            return BadRequest("The value of 'Id' must be a valid integer number.");
        }
        
        var response = new Response<ArticleCategoryDto>();
        if (!await _articleCategoryService.ArticleCategoryExist(categoryDto.Id))
        {
            response.Errors.Add("Article Category Not Found");
            return NotFound(response);
        }
        
    
        var updatedCategoryDto = await _articleCategoryService.UpdateAsync(categoryDto);
        response.Data = updatedCategoryDto;
    
        return Ok(response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<ArticleCategoryDto>>> GetById(int id)
    {
        var response = new Response<ArticleCategoryDto>();
        if (!await _articleCategoryService.ArticleCategoryExist(id))
        {
            response.Errors.Add("Article category not found");
            return NotFound(response);
        }

        response.Data = await _articleCategoryService.GetById(id);
        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:int}")]

    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var response = new Response<bool>();
        var result = await _articleCategoryService.DeleteAsync(id);
        response.Data = result;

        return Ok(response);
    }
}
   //// private readonly IArticleCategoryRepository _articleCategoryRepository;
       //Cuando añadimos la interfaz  de service
       
       //// public ArticleCategoriesController(IArticleCategoryRepository articleCategoryRepository)
       // {
       //     _articleCategoryRepository = articleCategoryRepository;
       // }
           // var response = new Response<List<ArticleCategoryDto>>();
           // var categories = await _articleCategoryRepository.GetAllAsync();
           // response.Data = categories.Select(c => new ArticleCategoryDto(c)).ToList();
           //
           // return Ok(response);
       // SinDTO
       // public async Task<ActionResult<Response<List<ArticleCategory>>>> GetAll()
       // {
       //     var categories = await _articleCategoryRepository.GetAllAsync();
       //     var response = new Response<List<ArticleCategory>>();
       //     response.Data = categories;
       //
       //     return Ok(response);
       // }
       
       
       //sIN INTERFACE
       // public async Task<ActionResult<Response<ArticleCategoryDto>>> Post([FromBody] ArticleCategoryDto categoryDto)
       // {
       //     var response = new Response<ArticleCategoryDto>();
       //     var category = new ArticleCategory()
       //     {
       //         Name = categoryDto.Name,
       //         CreatedBy = "",
       //         CreatedDate = DateTime.Now,
       //         UpdatedBy = "",
       //         UpdateDate = DateTime.Now,
       //     };
       //
       //     category = await _articleCategoryRepository.SaveAsync(category);
       //     category.Id = category.Id;
       //
       //     response.Data = categoryDto;
       //     
       //     return Created($"/api/[controller]/{category.Id}", category);
       // }
       
       // SinDto
       // public async Task<ActionResult<Response<ArticleCategory>>> Post([FromBody] ArticleCategory category)
       // {
       //     category = await _articleCategoryRepository.SaveAsync(category);
       //     
       //     var response = new Response<ArticleCategory>();
       //     response.Data = category;
       //     
       //     return Created($"/api/[controller]/{category.Id}", category);
       // } 
    // [HttpPut]
    // public async Task<ActionResult<Response<ArticleCategoryDto>>> Update([FromBody] ArticleCategoryDto categoryDto)
    // {
    //     var response = new Response<ArticleCategoryDto>();
    //     if (!await _articleCategoryService.ArticleCategoryExist(categoryDto.Id))
    //     {
    //         response.Errors.Add("Article Category Not Found");
    //         return NotFound(response);
    //     }
    //     return Ok(response);
    // }
    
    //Sin interface
    // public async Task<ActionResult<Response<ArticleCategoryDto>>> Update([FromBody] ArticleCategoryDto categoryDto)
    // {
    //     var response = new Response<ArticleCategoryDto>();
    //     var category = await _articleCategoryRepository.GetById(categoryDto.Id);
    //     if (category == null)
    //     {
    //         response.Errors.Add("Article category not found");
    //         return NotFound(response);
    //     }
    //
    //     category.Name = categoryDto.Name;
    //     var result = await _articleCategoryRepository.UpdateAsync(category);
    //
    //     response.Data = categoryDto;
    //     return Ok(response);
    // }
    

    //SinDTO
    // public async Task<ActionResult<Response<ArticleCategory>>> Update([FromBody] ArticleCategory category)
    // {
    //     var result = await _articleCategoryRepository.UpdateAsync(category);
    //     var response = new Response<ArticleCategory> { Data = result };
    //
    //     return Ok(response);
    // }
    //Sin las interfaces
    // public async Task<ActionResult<Response<ArticleCategoryDto>>> GetById(int id)
    // {
    //     var response = new Response<ArticleCategoryDto>();
    //     var category = await _articleCategoryRepository.GetById(id);
    //     if (category == null)
    //     {
    //         response.Errors.Add("Product Category Not Found");
    //         return NotFound(response);
    //     }
    //
    //     var categoryDto = new ArticleCategoryDto(category);
    //     response.Data = categoryDto;
    //
    //     return Ok(response);
    // }

    //Sin DTO
    // public async Task<ActionResult<Response<ArticleCategory>>> GetById(int id)
    // {
    //     var category = await _articleCategoryRepository.GetById(id);
    //     var response = new Response<ArticleCategory>();
    //     response.Data = category;
    //
    //     return Ok(response);
    // }
    // public async Task<ActionResult<Response<ArticleCategory>>> Delete(int id)
    // {
    //     //var result = await _articleCategoryRepository.DeleteAsync(id);
    //     var response = new Response<ArticleCategory>();
    //
    //     return Ok(response.Data);
    // }
