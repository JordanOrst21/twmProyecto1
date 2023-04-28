using Microsoft.AspNetCore.Mvc;
using TecNM.Project.App.Repositories.Interfaces;
using TecNM.Project.App.Services.Interfaces;
using TecNM.Project.Core.Dto;
using TecNM.Project.Core.Entities;
using TecNM.Project.Core.Http;

namespace TecNM.Project.App.Controllers;

[ApiController]
[Route(template: "api/[controller]")]
public class UserController : ControllerBase
{
    
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    
    [HttpGet]
    public async Task<ActionResult<Response<List<UserDto>>>> GetAll()
    {
        var response = new Response<List<UserDto>>
        {
            Data = await _userService.GetAllAsync()
        };
    
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<ActionResult<Response<UserDto>>> Post([FromBody] UserDto categoryDto)
    {
        if (string.IsNullOrWhiteSpace(categoryDto.Name))
        {
            return BadRequest("El campo name no puede estar vacío, nulo o contener solo espacios en blanco.");
        }
        
        if (string.IsNullOrWhiteSpace(categoryDto.Email))
        {
            return BadRequest("El campo Email no puede estar vacío, nulo o contener solo espacios en blanco.");
        }
        
        if (string.IsNullOrWhiteSpace(categoryDto.Password ))
        {
            return BadRequest("El campo password no puede estar vacío, nulo o contener solo espacios en blanco.");
        }
       

        var response = new Response<UserDto>
        {
            Data = await _userService.SaveAsync(categoryDto)
        };
        
        return Created($"/api/[controller]/{response.Data.Id}", response);
    }
    
    [HttpPut]
    public async Task<ActionResult<Response<UserDto>>> Update([FromBody] UserDto categoryDto)
    {
        if (string.IsNullOrWhiteSpace(categoryDto.Name))
        {
            return BadRequest("El campo name no puede estar vacío, nulo o contener solo espacios en blanco.");
        }
        
        if (categoryDto.Id == null || categoryDto.Id == 0 )
        {
            return BadRequest("The value of 'Id' must be a valid integer number.");
        }
        
        if (string.IsNullOrWhiteSpace(categoryDto.Email))
        {
            return BadRequest("El campo Email no puede estar vacío, nulo o contener solo espacios en blanco.");
        }
        
        if (string.IsNullOrWhiteSpace(categoryDto.Password ))
        {
            return BadRequest("El campo password no puede estar vacío, nulo o contener solo espacios en blanco.");
        }
        
        var response = new Response<UserDto>();
        if (!await _userService.UserExist(categoryDto.Id))
        {
            response.Errors.Add("Article Category Not Found");
            return NotFound(response);
        }
        
        var updatedCategoryDto = await _userService.UpdateAsync(categoryDto);
        response.Data = updatedCategoryDto;
        
        return Ok(response);
    }
    
    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<UserDto>>> GetById(int id)
    {
        var response = new Response<UserDto>();
        if (!await _userService.UserExist(id))
        {
            response.Errors.Add("Article category not found");
            return NotFound(response);
        }
    
        response.Data = await _userService.GetById(id);
        return Ok(response);
    }
    
    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var response = new Response<bool>();
        var result = await _userService.DeleteAsync(id);
        response.Data = result;
    
        return Ok(response);
    }
    
    // private readonly IUserRepository _userRepository;
    //
    // public UserController(IUserRepository userRepository)
    // {
    //     _userRepository = userRepository;
    // }
    //
    // [HttpGet]
    // public async Task<ActionResult<Response<List<User>>>> GetAll()
    // {
    //     var categories = await _userRepository.GetAllAsync();
    //     var response = new Response<List<User>>();
    //     response.Data = categories;
    //
    //     return Ok(response);
    // }
    //
    // [HttpPost]
    // public async Task<ActionResult<Response<User>>> Post([FromBody] User category)
    // {
    //     category = await _userRepository.SaveAsync(category);
    //     
    //     var response = new Response<User>();
    //     response.Data = category;
    //     
    //     return Created($"/api/[controller]/{category.Id}", category);
    // }
    //
    // [HttpPut]
    // public async Task<ActionResult<Response<User>>> Update([FromBody] User category)
    // {
    //     var result = await _userRepository.UpdateAsync(category);
    //     var response = new Response<User> { Data = result };
    //
    //     return Ok(response);
    // }
    //
    // [HttpGet]
    // [Route("{id:int}")]
    // public async Task<ActionResult<Response<User>>> GetById(int id)
    // {
    //     var category = await _userRepository.GetById(id);
    //     var response = new Response<User>();
    //     response.Data = category;
    //
    //     return Ok(response);
    // }
    //
    // [HttpDelete]
    // [Route("{id:int}")]
    // public async Task<ActionResult<Response<User>>> Delete(int id)
    // {
    //     var result = await _userRepository.DeleteAsync(id);
    //     var response = new Response<User>();
    //
    //     return Ok(response.Data);
    // }
}