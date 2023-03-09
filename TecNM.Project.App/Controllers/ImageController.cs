using Microsoft.AspNetCore.Mvc;
using TecNM.Project.App.Repositories.Interfaces;
using TecNM.Project.Core.Entities;
using TecNM.Project.Core.Http;

namespace TecNM.Project.App.Controllers;

[ApiController]
[Route(template: "api/[controller]")]
public class ImageController : ControllerBase
{
    private readonly IImageRepository _imageRepository;

    public ImageController(IImageRepository imageRepository)
    {
        _imageRepository = imageRepository;
    }

    [HttpGet]
    public async Task<ActionResult<Response<List<Image>>>> GetAll()
    {
        var categories = await _imageRepository.GetAllAsync();
        var response = new Response<List<Image>>();
        response.Data = categories;

        return Ok(response);
    }
    
    [HttpPost]
    public async Task<ActionResult<Response<Image>>> Post([FromBody] Image category)
    {
        category = await _imageRepository.SaveAsync(category);
        
        var response = new Response<Image>();
        response.Data = category;
        
        return Created($"/api/[controller]/{category.Id}", category);
    }
    
    [HttpPut]
    public async Task<ActionResult<Response<Image>>> Update([FromBody] Image category)
    {
        var result = await _imageRepository.UpdateAsync(category);
        var response = new Response<Image> { Data = result };

        return Ok(response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<Image>>> GetById(int id)
    {
        var category = await _imageRepository.GetById(id);
        var response = new Response<Image>();
        response.Data = category;

        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<Image>>> Delete(int id)
    {
        var result = await _imageRepository.DeleteAsync(id);
        var response = new Response<Image>();

        return Ok(response.Data);
    }
}