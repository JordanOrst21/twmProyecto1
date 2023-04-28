using TecNM.Project.Core.Dto;
using TecNM.Project.Core.Entities;

namespace TecNM.Project.App.Services.Interfaces;
//Estos de la carpeta Repositories/Interfaces/IArticleCategoryRepository
public interface IArticleCategoryService
{
    //metodo para guardar categoria
    Task<ArticleCategoryDto> SaveAsync(ArticleCategoryDto category);
    
    //metodo para actualizar las categorias
    Task<ArticleCategoryDto> UpdateAsync(ArticleCategoryDto category);
    
    //metodo para retornar una lista de categorias
    Task<List<ArticleCategoryDto>> GetAllAsync();

    //metodo para retornar el id de las categorias que borrara
    // Task<bool> DeleteAsync(int id);
    Task<bool> ArticleCategoryExist(int id);
    
    //metodo para obtener una categoria por id
    Task<ArticleCategoryDto> GetById(int id);
    
    Task<bool> DeleteAsync (int id);
    
}