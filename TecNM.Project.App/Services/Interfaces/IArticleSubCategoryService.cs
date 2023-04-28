using TecNM.Project.Core.Dto;
using TecNM.Project.Core.Entities;

namespace TecNM.Project.App.Services.Interfaces;
//Estos de la carpeta Repositories/Interfaces/IArticleCategoryRepository
public interface IArticleSubCategoryService
{
    //metodo para guardar categoria
    Task<ArticleSubCategoryDto> SaveAsync(ArticleSubCategoryDto category);
    
    //metodo para actualizar las categorias
    Task<ArticleSubCategoryDto> UpdateAsync(ArticleSubCategoryDto category);
    
    //metodo para retornar una lista de categorias
    Task<List<ArticleSubCategoryDto>> GetAllAsync();

    //metodo para retornar el id de las categorias que borrara
    // Task<bool> DeleteAsync(int id);
    Task<bool> ArticleSubCategoryExist(int id);
    
    //metodo para obtener una categoria por id
    Task<ArticleSubCategoryDto> GetById(int id);
    
    Task<bool> DeleteAsync (int id);
    
}