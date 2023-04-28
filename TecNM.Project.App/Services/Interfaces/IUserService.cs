using TecNM.Project.Core.Dto;
using TecNM.Project.Core.Entities;

namespace TecNM.Project.App.Services.Interfaces;
//Estos de la carpeta Repositories/Interfaces/IArticleCategoryRepository
public interface IUserService
{
    //metodo para guardar categoria
    Task<UserDto> SaveAsync(UserDto category);
    
    //metodo para actualizar las categorias
    Task<UserDto> UpdateAsync(UserDto category);
    
    //metodo para retornar una lista de categorias
    Task<List<UserDto>> GetAllAsync();

    //metodo para retornar el id de las categorias que borrara
    // Task<bool> DeleteAsync(int id);
    Task<bool> UserExist(int id);
    
    //metodo para obtener una categoria por id
    Task<UserDto> GetById(int id);
    
    Task<bool> DeleteAsync (int id);
    
}