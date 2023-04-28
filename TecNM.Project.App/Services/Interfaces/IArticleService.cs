using TecNM.Project.Core.Dto;
using TecNM.Project.Core.Entities;

namespace TecNM.Project.App.Services.Interfaces;
//Estos de la carpeta Repositories/Interfaces/IArticleCategoryRepository
public interface IArticleService
{
    //metodo para guardar categoria
    Task<ArticleDto> SaveAsync(ArticleDto category);
    
    //metodo para actualizar las categorias
    Task<ArticleDto> UpdateAsync(ArticleDto category);
    
    //metodo para retornar una lista de categorias
    Task<List<ArticleDto>> GetAllAsync();

    //metodo para retornar el id de las categorias que borrara
    // Task<bool> DeleteAsync(int id);
    Task<bool> ArticleExist(int id);
    
    //metodo para obtener una categoria por id
    Task<ArticleDto> GetById(int id);
    
    Task<bool> DeleteAsync (int id);
    
}