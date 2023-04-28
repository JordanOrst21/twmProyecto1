using TecNM.Project.App.Repositories.Interfaces;
using TecNM.Project.App.Services.Interfaces;
using TecNM.Project.Core.Dto;
using TecNM.Project.Core.Entities;

namespace TecNM.Project.App.Services;
//Creamos el arcivo y luego implementamos la interfaz y agregamos todos Luego modificacmos y agregamos lo sig
public class UserService : IUserService
{

    private readonly IUserRepository _userRepository;//Como trabajara con Dto debe apuntar hacia alla

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<UserDto> SaveAsync(UserDto categoryDto)
    {
        if (string.IsNullOrEmpty(categoryDto.Name))
        {
            throw new ArgumentException("El nombre de categoría no puede estar vacío o nulo.", nameof(categoryDto.Name));
        }

        // throw new NotImplementedException();
        var category = new User
        {
            Name = categoryDto.Name,
            Password = categoryDto.Password,
            Email = categoryDto.Email,
            CreatedBy = "",
            CreatedDate = DateTime.Now,
            UpdatedBy = "",
            UpdateDate = DateTime.Now,
        };
    
        category = await _userRepository.SaveAsync(category);
        category.Id = category.Id;

        return categoryDto;
    }

    // public Task<ArticleCategoryDto> UpdateAsync(ArticleCategoryDto category)
    // {
    //     throw new NotImplementedException();
    // }
    
    public async Task<UserDto> UpdateAsync(UserDto categoryDto)
    {
        var category = await _userRepository.GetById(categoryDto.Id);

        if (category == null)
            throw new Exception("User not found");
        category.Name = categoryDto.Name;
        category.Email = categoryDto.Email;
        category.Password = categoryDto.Password;
        category.UpdateDate = DateTime.Now;
        category.UpdatedBy = "";
        await _userRepository.UpdateAsync(category);

        return categoryDto;
    }

    public async Task<List<UserDto>> GetAllAsync()
    {
        // throw new NotImplementedException();
        var categories = await _userRepository.GetAllAsync();
        var categoriesDto = 
            categories.Select(c => new UserDto(c)).ToList();
        return categoriesDto;
    }

    // public Task<bool> ArticleCategoryExist(int id)
    // {
    //     throw new NotImplementedException();
    // }
    
    public async Task<bool> UserExist(int id)
    {
        var category = await _userRepository.GetById(id);
        return (category != null);
    }

    public async Task<UserDto> GetById(int id)
    {
        // throw new NotImplementedException();
        var category = await _userRepository.GetById(id);
        if (category == null)
            throw new Exception("User not found");
        var categoryDto = new UserDto(category);
        return categoryDto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _userRepository.DeleteAsync(id);
    }


}