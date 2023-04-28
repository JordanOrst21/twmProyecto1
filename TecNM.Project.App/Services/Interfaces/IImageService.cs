using TecNM.Project.Core.Dto;
using TecNM.Project.Core.Entities;

namespace TecNM.Project.App.Services.Interfaces;
//Estos de la carpeta Repositories/Interfaces/IArticleCategoryRepository
public interface IImageService
{
    //metodo para guardar categoria
    Task<ImageDto> SaveAsync(ImageDto category);
    
    //metodo para actualizar las categorias
    Task<ImageDto> UpdateAsync(ImageDto category);
    
    //metodo para retornar una lista de categorias
    Task<List<ImageDto>> GetAllAsync();

    //metodo para retornar el id de las categorias que borrara
    // Task<bool> DeleteAsync(int id);
    Task<bool> ImageExist(int id);
    
    //metodo para obtener una categoria por id
    Task<ImageDto> GetById(int id);
    
    Task<bool> DeleteAsync (int id);
    
}