using Microsoft.AspNetCore.Mvc;
using TecNM.Project.App.Repositories.Interfaces;
using TecNM.Project.App.Services.Interfaces;
using TecNM.Project.Core.Dto;
using TecNM.Project.Core.Entities;
using TecNM.Project.Core.Http;

namespace TecNM.Project.App.Controllers;

[ApiController]
[Route(template: "api/[controller]")]
public class ImageController : ControllerBase
{
    private readonly IImageService _imageService;

    public ImageController(IImageService articleService)
    {
        _imageService = articleService;
    }

    [HttpGet]
    public async Task<ActionResult<Response<List<ImageDto>>>> GetAll()
    {
        var response = new Response<List<ImageDto>>
        {
            Data = await _imageService.GetAllAsync()
        };

        return Ok(response);
    }
    
    [HttpPost]
    public async Task<ActionResult<Response<ImageDto>>> Post([FromBody] ImageDto categoryDto)
    {
        if (string.IsNullOrWhiteSpace(categoryDto.Name))
        {
            return BadRequest("The 'Name' field cannot be empty, null, or contain only white spaces.");
        }
        
        if (categoryDto.Article_id == null || categoryDto.Article_id == 0 )
        {
            return BadRequest("The value of 'Article_id' must be a valid integer number.");
        }
        
        var response = new Response<ImageDto>
        {
            Data = await _imageService.SaveAsync(categoryDto)
        };
        
        return Created($"/api/[controller]/{response.Data.Id}", response);
    }
    
    [HttpPut]
    public async Task<ActionResult<Response<ImageDto>>> Update([FromBody] ImageDto categoryDto)
    {
        if (string.IsNullOrWhiteSpace(categoryDto.Name))
        {
            return BadRequest("The 'Name' field cannot be empty, null, or contain only white spaces.");
        }
        
        if (categoryDto.Article_id == null || categoryDto.Article_id == 0 )
        {
            return BadRequest("The value of 'Article_id' must be a valid integer number.");
        }
        
        var response = new Response<ImageDto>();
        if (!await _imageService.ImageExist(categoryDto.Id))
        {
            response.Errors.Add("Article Category Not Found");
            return NotFound(response);
        }
        
        var updatedCategoryDto = await _imageService.UpdateAsync(categoryDto);
        response.Data = updatedCategoryDto;
        
        return Ok(response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<ImageDto>>> GetById(int id)
    {
        var response = new Response<ImageDto>();
        if (!await _imageService.ImageExist(id))
        {
            response.Errors.Add("Article category not found");
            return NotFound(response);
        }

        response.Data = await _imageService.GetById(id);
        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var response = new Response<bool>();
        var result = await _imageService.DeleteAsync(id);
        response.Data = result;

        return Ok(response);
    }
    // private readonly IImageRepository _imageRepository;
    //
    // public ImageController(IImageRepository imageRepository)
    // {
    //     _imageRepository = imageRepository;
    // }
    //
    // [HttpGet]
    // public async Task<ActionResult<Response<List<Image>>>> GetAll()
    // {
    //     var categories = await _imageRepository.GetAllAsync();
    //     var response = new Response<List<Image>>();
    //     response.Data = categories;
    //
    //     return Ok(response);
    // }
    //
    // [HttpPost]
    // public async Task<ActionResult<Response<Image>>> Post([FromBody] Image category)
    // {
    //     category = await _imageRepository.SaveAsync(category);
    //     
    //     var response = new Response<Image>();
    //     response.Data = category;
    //     
    //     return Created($"/api/[controller]/{category.Id}", category);
    // }
    //
    // [HttpPut]
    // public async Task<ActionResult<Response<Image>>> Update([FromBody] Image category)
    // {
    //     var result = await _imageRepository.UpdateAsync(category);
    //     var response = new Response<Image> { Data = result };
    //
    //     return Ok(response);
    // }
    //
    // [HttpGet]
    // [Route("{id:int}")]
    // public async Task<ActionResult<Response<Image>>> GetById(int id)
    // {
    //     var category = await _imageRepository.GetById(id);
    //     var response = new Response<Image>();
    //     response.Data = category;
    //
    //     return Ok(response);
    // }
    //
    // [HttpDelete]
    // [Route("{id:int}")]
    // public async Task<ActionResult<Response<Image>>> Delete(int id)
    // {
    //     var result = await _imageRepository.DeleteAsync(id);
    //     var response = new Response<Image>();
    //
    //     return Ok(response.Data);
    // }
}