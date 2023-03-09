using TecNM.Project.Core.Entities;

namespace TecNM.Project.App.Repositories.Interfaces;

public interface IUserRepository
{
    //metodo para guardar categoria
    Task<User> SaveAsync(User category);
    
    //metodo para actualizar las categorias
    Task<User> UpdateAsync(User category);
    
    //metodo para retornar una lista de categorias
    Task<List<User>> GetAllAsync();

    //metodo para retornar el id de las categorias que borrara
    Task<bool> DeleteAsync(int id);
    
    //metodo para obtener una categoria por id
    Task<User> GetById(int id);
}