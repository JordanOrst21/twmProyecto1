using Microsoft.AspNetCore.Mvc;
using TecNM.Project.App.Repositories.Interfaces;
using TecNM.Project.Core.Entities;
using TecNM.Project.Core.Http;

namespace TecNM.Project.App.Controllers;

[ApiController]
[Route(template: "api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet]
    public async Task<ActionResult<Response<List<User>>>> GetAll()
    {
        var categories = await _userRepository.GetAllAsync();
        var response = new Response<List<User>>();
        response.Data = categories;

        return Ok(response);
    }
    
    [HttpPost]
    public async Task<ActionResult<Response<User>>> Post([FromBody] User category)
    {
        category = await _userRepository.SaveAsync(category);
        
        var response = new Response<User>();
        response.Data = category;
        
        return Created($"/api/[controller]/{category.Id}", category);
    }
    
    [HttpPut]
    public async Task<ActionResult<Response<User>>> Update([FromBody] User category)
    {
        var result = await _userRepository.UpdateAsync(category);
        var response = new Response<User> { Data = result };

        return Ok(response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<User>>> GetById(int id)
    {
        var category = await _userRepository.GetById(id);
        var response = new Response<User>();
        response.Data = category;

        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<User>>> Delete(int id)
    {
        var result = await _userRepository.DeleteAsync(id);
        var response = new Response<User>();

        return Ok(response.Data);
    }
}