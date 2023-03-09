using TecNM.Project.Core.Entities;

namespace TecNM.Project.App.Repositories.Interfaces;

public interface IImageRepository
{
    //metodo para guardar categoria
    Task<Image> SaveAsync(Image category);
    
    //metodo para actualizar las categorias
    Task<Image> UpdateAsync(Image category);
    
    //metodo para retornar una lista de categorias
    Task<List<Image>> GetAllAsync();

    //metodo para retornar el id de las categorias que borrara
    Task<bool> DeleteAsync(int id);
    
    //metodo para obtener una categoria por id
    Task<Image> GetById(int id);
}